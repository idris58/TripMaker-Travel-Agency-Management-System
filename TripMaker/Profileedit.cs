using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace TripMaker
{
    public partial class Profileedit : UserControl
    {
        private static Profileedit instance;
        public static Profileedit Instance => instance ?? (instance = new Profileedit());
        public static Profileedit setInstance { set { instance = value; } }

        public Profileedit()
        {
            InitializeComponent();
        }

        private void btnup_Click(object sender, EventArgs e)
        {
            if (!Session.IsLoggedIn)
            {
                MessageBox.Show("Please login first.");
                return;
            }

            if (string.IsNullOrEmpty(txtname.Text) || string.IsNullOrEmpty(txtemail.Text) ||
                string.IsNullOrEmpty(txtpn.Text) || string.IsNullOrEmpty(richTxtAdrs.Text))
            {
                MessageBox.Show("Please fill up all information.");
                return;
            }

            string name = txtname.Text.Trim();
            if (!Regex.IsMatch(name, @"^([a-zA-Z\s]+)$"))
            {
                MessageBox.Show("Please enter a valid name.");
                return;
            }

            string email = txtemail.Text.Trim();
            if (!Regex.IsMatch(email, @"[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Please enter a valid email address.");
                return;
            }

            string pn = txtpn.Text.Trim();
            if (!Regex.IsMatch(pn, @"^[0-9]{11}$"))
            {
                MessageBox.Show("Please enter a valid phone number.");
                return;
            }

            string gender = rdbMale.Checked ? "Male" : rdbFemale.Checked ? "Female" : "";
            if (string.IsNullOrEmpty(gender))
            {
                MessageBox.Show("Please select a gender.");
                return;
            }

            string addressRaw = richTxtAdrs.Text.Trim();
            string[] parts = addressRaw.Split(',');
            if (parts.Length != 3)
            {
                MessageBox.Show("Please enter address as 'Street, City, Country'.");
                return;
            }

            string street = parts[0].Trim();
            string city = parts[1].Trim();
            string country = parts[2].Trim();
            string username = Session.LoggedInUsername;

            try
            {
                using (var con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                {
                    con.Open();

                    // Step 1: Get A_ID from Customer
                    int aid = -1;
                    string aidQuery = "SELECT A_ID FROM Customer WHERE C_Username = :username";
                    using (var cmd = new OracleCommand(aidQuery, con))
                    {
                        cmd.Parameters.Add(":username", OracleDbType.Varchar2).Value = username;
                        object result = cmd.ExecuteScalar();
                        if (result != null) aid = Convert.ToInt32(result);
                    }

                    if (aid == -1)
                    {
                        MessageBox.Show("Failed to find associated address.");
                        return;
                    }

                    // Step 2: Update Address table
                    string updateAddress = @"UPDATE Address SET Street = :street, City = :city, Country = :country WHERE A_ID = :aid";
                    using (var cmd = new OracleCommand(updateAddress, con))
                    {
                        cmd.Parameters.Add(":street", OracleDbType.Varchar2).Value = street;
                        cmd.Parameters.Add(":city", OracleDbType.Varchar2).Value = city;
                        cmd.Parameters.Add(":country", OracleDbType.Varchar2).Value = country;
                        cmd.Parameters.Add(":aid", OracleDbType.Int32).Value = aid;
                        cmd.ExecuteNonQuery();
                    }

                    // Step 3: Update Customer basic info
                    string updateCustomer = @"UPDATE Customer SET Name = :name, Email = :email, Phone = :phone, Gender = :gender WHERE C_Username = :username";
                    using (var cmd = new OracleCommand(updateCustomer, con))
                    {
                        cmd.BindByName = true;
                        cmd.Parameters.Add(":name", OracleDbType.Varchar2).Value = name;
                        cmd.Parameters.Add(":email", OracleDbType.Varchar2).Value = email;
                        cmd.Parameters.Add(":phone", OracleDbType.Varchar2).Value = pn;
                        cmd.Parameters.Add(":gender", OracleDbType.Varchar2).Value = gender;
                        cmd.Parameters.Add(":username", OracleDbType.Varchar2).Value = username;
                        cmd.ExecuteNonQuery();
                    }

                    // Step 4: Save profile image locally to avoid Oracle BLOB read issues.
                    var resizedImage = ResizeImage(picturebox.Image, 256, 256);
                    if (resizedImage != null)
                    {
                        ProfileImageStore.Save(username, resizedImage);
                    }
                    MessageBox.Show("Profile successfully updated.");
                }
                profile.Instance.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating profile: " + ex.Message);
            }
        }

        private void txtun_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Username cannot be changed.");
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files| *.jpg; *.jpeg; *.png; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                Image original = Image.FromFile(open.FileName);
                picturebox.Image = ResizeImage(original, 256, 256); // Resize before setting
            }
        }

        private byte[] convertImageToBytes(Image img)
        {
            if (img == null)
                return null;
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        public Image convertByteArrayToImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return new Bitmap(Image.FromStream(ms));
            }
        }

        private Image ResizeImage(Image image, int maxWidth, int maxHeight)
        {
            if (image == null) return null;
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            int newWidth = (int)(image.Width * ratio);
            int newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);
            using (var graphics = Graphics.FromImage(newImage))
            {
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);
            }
            return newImage;
        }
    }
}

using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace TripMaker
{
    public partial class profile : UserControl
    {
        private static profile instance;
        public static profile Instance => instance ?? (instance = new profile());
        public static profile setInstance { set { instance = value; } }

        public profile()
        {
            InitializeComponent();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files| *.jpg; *.jpeg; *.png; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                Image original = Image.FromFile(open.FileName);
                btnsave.Enabled = true;
                picturebox.Image = ResizeImage(original, 256, 256); // Resize to limit size
            }
            btnadd.Visible = false;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveImageToDatabase(Session.LoggedInUsername, picturebox.Image);
                MessageBox.Show("Picture successfully added");
                btnsave.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please add a picture: " + ex.Message);
            }
        }

        private string username;

        private void SaveImageToDatabase(string username, Image image)
        {
            try
            {
                using (var con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                {
                    con.Open();
                    string query = "UPDATE Customer SET Profile_Image = :image WHERE C_Username = :username";
                    using (var cmd = new OracleCommand(query, con))
                    {
                        cmd.Parameters.Add(":image", OracleDbType.Blob).Value = ConvertImageToBytes(image);
                        cmd.Parameters.Add(":username", OracleDbType.Varchar2).Value = username;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Image Save Error: " + ex.Message);
            }
        }

        private byte[] ConvertImageToBytes(Image img)
        {
            if (img == null)
            {
                return null;
            }
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

        private void btnup_Click(object sender, EventArgs e)
        {
            if (!Session.IsLoggedIn)
            {
                MessageBox.Show("Please login to edit profile.");
                return;
            }

            try
            {
                string query = @"
                  SELECT c.Name, c.C_Username, c.Email, c.Phone, c.Gender, c.Profile_Image,
                  a.Street, a.City, a.Country
                  FROM Customer c
                  LEFT JOIN Address a ON c.A_ID = a.A_ID
                  WHERE c.C_Username = :username";

                string error;
                OracleParameter[] parameters =
                {
                    new OracleParameter("username", Session.LoggedInUsername)
                };

                DataTable dt = DataAccess.GetData(query, parameters, out error);

                if (!string.IsNullOrEmpty(error))
                {
                    MessageBox.Show(error);
                    return;
                }

                if (dt.Rows.Count > 0)
                {
                    var row = dt.Rows[0];
                    Profileedit.Instance.Controls["txtname"].Text = row["Name"].ToString();
                    Profileedit.Instance.Controls["txtun"].Text = row["C_Username"].ToString();
                    Profileedit.Instance.Controls["txtemail"].Text = row["Email"].ToString();
                    Profileedit.Instance.Controls["txtpn"].Text = row["Phone"].ToString();

                    string gender = row["Gender"].ToString();
                    if (gender == "Male")
                        ((RadioButton)Profileedit.Instance.Controls["rdbMale"]).Checked = true;
                    else if (gender == "Female")
                        ((RadioButton)Profileedit.Instance.Controls["rdbFemale"]).Checked = true;

                    string fullAddress = $"{row["Street"]}, {row["City"]}, {row["Country"]}";
                    Profileedit.Instance.Controls["richTxtAdrs"].Text = fullAddress;

                    if (row["Profile_Image"] != DBNull.Value)
                    {
                        byte[] imageBytes = (byte[])row["Profile_Image"];
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            ((PictureBox)Profileedit.Instance.Controls["picturebox"]).Image = new Bitmap(Image.FromStream(ms));
                        }
                    }
                }

                Profileedit.Instance.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Utility method to resize images before saving
        private Image ResizeImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);
            using (var g = Graphics.FromImage(newImage))
            {
                g.DrawImage(image, 0, 0, newWidth, newHeight);
            }
            return newImage;
        }
    }
}

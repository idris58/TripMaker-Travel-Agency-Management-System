using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace TripMaker
{
    public partial class Signup : UserControl
    {
        private static Signup instance;
        public static Signup Instance => instance ?? (instance = new Signup());
        public static Signup setInstance { set { instance = value; } }

        public Signup()
        {
            InitializeComponent();
            Resize += (s, e) => ApplyResponsiveLayout();
            ApplyResponsiveLayout();
        }

        private void ApplyResponsiveLayout()
        {
            int w = ClientSize.Width;
            int h = ClientSize.Height;

            const int leftWidth = 250;
            const int rightWidth = 388;
            const int blockGap = 0;
            int totalWidth = leftWidth + blockGap + rightWidth;

            int left = Math.Max(12, (w - totalWidth) / 2);
            int top = Math.Max(15, (h - panel1.Height) / 2);

            panel1.Left = left;
            panel1.Top = top;

            panel2.Left = left + leftWidth + blockGap;
            panel2.Top = top;
        }

        private void password_change(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPass.Text) || string.IsNullOrEmpty(txtCpass.Text))
            {
                lblpdnm.Visible = false;
            }
            else if (txtPass.Text != txtCpass.Text)
            {
                lblpdnm.Visible = true;
            }
            else
            {
                lblpdnm.Visible = false;
            }
        }

        private void UsernameCheck(object sender, EventArgs e)
        {
            string un = txtun.Text.Trim();

            if (un.Length < 3 && un.Length > 0)
            {
                lblUsername.Visible = true;      
                pbUsernameab.Visible = false;         
                return;
            }

            try
            {
                using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                {
                    con.Open();

                    string query = "SELECT COUNT(*) FROM Customer WHERE C_Username = :username";
                    using (OracleCommand cmd = new OracleCommand(query, con))
                    {
                        cmd.Parameters.Add("username", OracleDbType.Varchar2).Value = un;
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count > 0)
                        {
                            lblUsername.Visible = true;       
                            pbUsernameab.Visible = false;
                        }
                        else if (un.Length <= 0)
                        {
                            pbUsernameab.Visible = false;     
                            lblUsername.Visible = false;      
                        }
                        else
                        {
                            lblUsername.Visible = false;
                            pbUsernameab.Visible = true;       
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Signup error: " + ex.Message);
            }
        }


        private void btnOpen_Click(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = false;
            txtCpass.UseSystemPasswordChar = false;
            btncloseps.Visible = true;
            btnopenps.Visible = false;
            btnclosecp.Visible = true;
            btnopencp.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = true;
            txtCpass.UseSystemPasswordChar = true;
            btncloseps.Visible = false;
            btnopenps.Visible = true;
            btnclosecp.Visible = false;
            btnopencp.Visible = true;
        }

        private void newdata(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtun.Text = "";
            txtEmail.Text = "";
            txtPN.Text = "";
            rdbMale.Checked = false;
            rdbFemale.Checked = false;
            txtPass.Text = "";
            txtCpass.Text = "";
            richTxtAdrs.Text = "";
            lblpdnm.Visible = false;
        }

        private void singup_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtun.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtPN.Text) ||
                string.IsNullOrWhiteSpace(txtPass.Text) || string.IsNullOrWhiteSpace(txtCpass.Text) ||
                string.IsNullOrWhiteSpace(richTxtAdrs.Text))
            {
                MessageBox.Show("Please fill up all information.");
                return;
            }

            string name = txtName.Text.Trim();
            string un = txtun.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPN.Text.Trim();
            string pass = txtPass.Text;
            string confirmPass = txtCpass.Text;
            string gender = rdbMale.Checked ? "Male" : rdbFemale.Checked ? "Female" : "";
            string addressText = richTxtAdrs.Text.Trim();

            if (!Regex.IsMatch(name, @"^([a-zA-Z\s]+)$"))
            {
                MessageBox.Show("Invalid name.");
                return;
            }

            if (!Regex.IsMatch(email, @"[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Invalid email.");
                return;
            }

            if (!Regex.IsMatch(phone, @"^[0-9]{11}$"))
            {
                MessageBox.Show("Phone number must be 11 digits.");
                return;
            }

            if (gender == "")
            {
                MessageBox.Show("Please select gender.");
                return;
            }

            if (pass != confirmPass)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            string[] addressParts = addressText.Split(',');
            if (addressParts.Length != 3)
            {
                MessageBox.Show("Address must be in format: Street, City, Country");
                return;
            }

            string street = addressParts[0].Trim();
            string city = addressParts[1].Trim();
            string country = addressParts[2].Trim();

            try
            {
                using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                {
                    con.Open();

                    // Check if username already exists
                    string checkUserQuery = "SELECT COUNT(*) FROM Customer WHERE C_Username = :username";
                    using (OracleCommand checkCmd = new OracleCommand(checkUserQuery, con))
                    {
                        checkCmd.Parameters.Add("username", OracleDbType.Varchar2).Value = un;
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if (count > 0)
                        {
                            MessageBox.Show("Username already taken. Please choose a different one.");
                            return;
                        }
                    }

                    // Insert Address
                    string insertAddress = @"INSERT INTO Address (A_ID, Street, City, Country) 
                                             VALUES (seq_Address.NEXTVAL, :street, :city, :country)";
                    using (OracleCommand cmd = new OracleCommand(insertAddress, con))
                    {
                        cmd.Parameters.Add(":street", OracleDbType.Varchar2).Value = street;
                        cmd.Parameters.Add(":city", OracleDbType.Varchar2).Value = city;
                        cmd.Parameters.Add(":country", OracleDbType.Varchar2).Value = country;
                        cmd.ExecuteNonQuery();
                    }

                    int addressId;
                    using (OracleCommand cmd = new OracleCommand("SELECT MAX(A_ID) FROM Address", con))
                    {
                        addressId = Convert.ToInt32(cmd.ExecuteScalar());
                    }


                    int adminId;
                    using (OracleCommand cmd = new OracleCommand(
                        "SELECT Admin_Id FROM (SELECT Admin_Id FROM Admin ORDER BY DBMS_RANDOM.VALUE) WHERE ROWNUM = 1", con))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result == DBNull.Value || result == null)
                        {
                            MessageBox.Show("No admin found in the system. Contact support.");
                            return;
                        }
                        adminId = Convert.ToInt32(result);
                    }


                    // Insert Customer
                    string insertCustomer = @"INSERT INTO Customer 
                        (Name, C_Username, Password, Email, Phone, Gender, A_ID, Admin_ID)
                        VALUES (:name, :username, :password, :email, :phone, :gender, :aid, :adminid)";
                    using (OracleCommand cmd = new OracleCommand(insertCustomer, con))
                    {
                        cmd.Parameters.Add(":name", OracleDbType.Varchar2).Value = name;
                        cmd.Parameters.Add(":username", OracleDbType.Varchar2).Value = un;
                        cmd.Parameters.Add(":password", OracleDbType.Varchar2).Value = pass;
                        cmd.Parameters.Add(":email", OracleDbType.Varchar2).Value = email;
                        cmd.Parameters.Add(":phone", OracleDbType.Varchar2).Value = phone;
                        cmd.Parameters.Add(":gender", OracleDbType.Varchar2).Value = gender;
                        cmd.Parameters.Add(":aid", OracleDbType.Int32).Value = addressId;
                        cmd.Parameters.Add(":adminid", OracleDbType.Int32).Value = adminId;

                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            // Set session
                            Session.LoggedInUsername = un;
                            Session.IsAdmin = false;

                            MessageBox.Show("Successfully signed up.");

                            // Optionally redirect to Home
                            Home.Instance.BringToFront();
                            LogoutPanel.Instance.BringToFront();

                            newdata(sender, e); // Clear form
                        }

                        else
                        {
                            MessageBox.Show("Signup failed.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Signup error: " + ex.Message);
            }
        }

    }
}

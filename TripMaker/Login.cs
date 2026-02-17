using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using Oracle.ManagedDataAccess.Client;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace TripMaker
{
    public partial class Login : UserControl
    {
        private static Login instance;
        public static Login Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Login();
                }
                return instance;
            }
        }

        public static Login setInstance
        {
            set
            {
                instance = value;
            }
        }

        public Login()
        {
            InitializeComponent();
        }

        private void ClearData()
        {
            txtUN.Text = "";
            txtPassword.Text = "";
            cbAdmin.Checked = false;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
            btnClose.Visible = true;
            btnOpen.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;
            btnClose.Visible = false;
            btnOpen.Visible = true;
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            string un = txtUN.Text.Trim();
            string pass = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(un) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Please enter both username and password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                {
                    con.Open();
                    string query = !cbAdmin.Checked
                        ? "SELECT 1 FROM Customer WHERE C_Username = :un AND Password = :pass"
                        : "SELECT 1 FROM Admin WHERE Admin_Username = :un AND Password = :pass";

                    using (OracleCommand cmd = new OracleCommand(query, con))
                    {
                        cmd.BindByName = true;
                        cmd.Parameters.Add(":un", OracleDbType.Varchar2).Value = un;
                        cmd.Parameters.Add(":pass", OracleDbType.Varchar2).Value = pass;

                        object result = cmd.ExecuteScalar();
                        if (result == null)
                        {
                            MessageBox.Show("Invalid Username or Password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (!cbAdmin.Checked)
                        {
                            ClearData();
                            Session.LoggedInUsername = un;
                            Session.IsAdmin = false;
                            Home.Instance.BringToFront();
                            LogoutPanel.Instance.BringToFront();
                        }
                        else
                        {
                            ClearData();
                            Session.LoggedInUsername = un;
                            Session.IsAdmin = true;
                            AdminMainForm obj = new AdminMainForm();
                            LogoutPanel.Instance.BringToFront();
                            ParentForm.Hide();
                            obj.Show();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login Error: " + ex.Message);
            }
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            Signup.Instance.BringToFront();
        }
    }
}

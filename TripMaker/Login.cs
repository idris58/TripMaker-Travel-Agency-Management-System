using System;
using System.Configuration;
using System.Data;
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
                    string query = "";

                    if (!cbAdmin.Checked)
                    {
                        query = "SELECT * FROM Customer WHERE C_Username = :un AND Password = :pass";
                    }
                    else
                    {
                        query = "SELECT * FROM Admin WHERE Admin_Username = :un AND Password = :pass";
                    }

                    using (OracleCommand cmd = new OracleCommand(query, con))
                    {
                        cmd.Parameters.Add("username", OracleDbType.Varchar2).Value = un;
                        cmd.Parameters.Add("password", OracleDbType.Varchar2).Value = pass;

                        using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            if (dt.Rows.Count == 0)
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
                                AdminHome obj = new AdminHome();
                                LogoutPanel.Instance.BringToFront();
                                ParentForm.Hide();
                                obj.Show();
                            }
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

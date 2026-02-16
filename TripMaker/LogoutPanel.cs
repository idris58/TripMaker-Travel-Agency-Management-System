using Oracle.ManagedDataAccess.Client;
using OracleInternal.Secure.Network;
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TripMaker
{
    public partial class LogoutPanel : UserControl
    {
        private static LogoutPanel instance;

        public static LogoutPanel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LogoutPanel();
                }
                return instance;
            }
        }

        public LogoutPanel()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Logout();
            LoginAndSignupPanel.Instance.BringToFront();
            Login.Instance.BringToFront();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            profile.Instance.Controls["btnsave"].Enabled = false;
            if (!Session.IsLoggedIn)
            {
                MessageBox.Show("Please login to view profile.");
                return;
            }

            try
            {
                string query = @"
                   SELECT c.Name, c.C_Username, c.Email, c.Phone, c.Gender,
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
                    profile.Instance.Controls["lblname"].Text = row["Name"].ToString();
                    profile.Instance.Controls["lblun"].Text = row["C_Username"].ToString();
                    profile.Instance.Controls["lblemail"].Text = row["Email"].ToString();
                    profile.Instance.Controls["lblpn"].Text = row["Phone"].ToString();
                    profile.Instance.Controls["lblgender"].Text = row["Gender"].ToString();

                    string address = $"{row["Street"]}, {row["City"]}, {row["Country"]}";
                    profile.Instance.Controls["lbladrs"].Text = address;
                    LoadProfileImage(Session.LoggedInUsername);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            profile.Instance.BringToFront();
        }

        private void LoadProfileImage(string username)
        {
            var pictureBox = (PictureBox)profile.Instance.Controls["picturebox"];
            var image = ProfileImageStore.Load(username);
            pictureBox.BackgroundImage = image;
            pictureBox.BackgroundImageLayout = ImageLayout.Stretch;

            var addButton = (Button)profile.Instance.Controls["btnadd"];
            var saveButton = (Button)profile.Instance.Controls["btnsave"];
            bool hasImage = image != null;
            addButton.Visible = !hasImage;
            saveButton.Visible = !hasImage;
            saveButton.Enabled = false;
        }

    }
}

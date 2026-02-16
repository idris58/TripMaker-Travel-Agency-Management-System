using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TripMaker
{
    public partial class AdminHome : MetroFramework.Forms.MetroForm
    {
        public AdminHome()
        {
            InitializeComponent();
            this.FormClosing += AdminHome_FormClosing;
        }


        private void btnHotelRooms_Click(object sender, EventArgs e)
        {
            ManageHotelRooms obj = new ManageHotelRooms();
            obj.Show();

            this.Hide();
        }

        private void btnManageFlight_Click(object sender, EventArgs e)
        {
            FlightManagerView obj = new FlightManagerView();
            obj.Show();

            this.Hide();
        }


        private void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Logout();
            this.Hide();
            Form1 obj = new Form1();
            obj.Show();
            LoginAndSignupPanel.Instance.BringToFront();
            Login.Instance.BringToFront();

        }

        private void btnManageBus_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManegerBus obj = new ManegerBus();
            obj.Show();
        }

        private void btnManageUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManegerSignup obj = new ManegerSignup();
            obj.Show();
        }

        private void btnManageHotels_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageHotels obj = new ManageHotels();
            obj.Show();
        }

        private void btnManageTrain_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManegerTrain obj = new ManegerTrain();
            obj.Show();
        }

        private void btnManageActivity_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManegerActivity obj = new ManegerActivity();
            obj.Show();
        }

        private void btnAnalytics_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminAnalyticsForm obj = new AdminAnalyticsForm(this);
            obj.Show();
        }

        private void AdminHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

    }
}

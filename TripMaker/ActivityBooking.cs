using System;
using System.Windows.Forms;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace TripMaker
{
    public partial class ActivityBooking : UserControl
    {
        private static ActivityBooking instance;
        public static ActivityBooking Instance => instance ?? (instance = new ActivityBooking());

        public static ActivityBooking setInstance
        {
            set { instance = value; }
        }

        public ActivityBooking()
        {
            InitializeComponent();
            Resize += (s, e) => ApplyResponsiveLayout();
            ApplyResponsiveLayout();
        }

        private void ApplyResponsiveLayout()
        {
            int delta = Math.Max(0, ClientSize.Width - 674);

            LblName.Left = Math.Max(180, (ClientSize.Width - LblName.Width) / 2);
            loc.Left = 314 + delta;
            label2.Left = 313 + delta;
            lblLocation.Left = 409 + delta;
            lblCategory.Left = 408 + delta;
            co.Left = 342 + delta;
            lblPrice.Left = 409 + delta;
            btnbook.Left = 535 + delta;

            panel1.Left = 63;
            panel1.Width = Math.Max(551, 551 + delta);
        }

        private string name, price, location, category;

        public string ActivityName
        {
            get => name;
            set { name = value; LblName.Text = value; }
        }

        public string Price
        {
            get => price;
            set { price = value; lblPrice.Text = value; }
        }

        public string AcLocation
        {
            get => location;
            set { location = value; lblLocation.Text = value; }
        }

        public string Category
        {
            get => category;
            set
            {
                category = value;
                lblCategory.Text = value;

                pbResturant.Visible = false;
                pbSports.Visible = false;
                pbOthers.Visible = false;

                if (category.ToLower().Contains("rest"))
                    pbResturant.Visible = true;
                else if (category.ToLower().Contains("sport"))
                    pbSports.Visible = true;
                else
                    pbOthers.Visible = true;
            }
        }

        public void btnbook_Click(object sender, EventArgs e)
        {
            if (!Session.IsLoggedIn)
            {
                MessageBox.Show("You must be logged in to book.");
                return;
            }

            var confirm = ActivityConfirmBook.Instance;
            confirm.ActivityName = this.ActivityName;
            confirm.Price = this.Price;
            confirm.acLocation = this.AcLocation;
            confirm.Category = this.Category;

            confirm.activityconfirmbook_Load();
            confirm.BringToFront();
        }
    }
}

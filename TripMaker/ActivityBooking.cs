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

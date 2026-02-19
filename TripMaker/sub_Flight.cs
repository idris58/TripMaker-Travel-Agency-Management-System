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
    public partial class sub_Flight : UserControl
    {
        private static sub_Flight instance;
        public static sub_Flight Instance => instance ?? (instance = new sub_Flight());

        public static sub_Flight setInstance
        {
            set { instance = value; }
        }
        public sub_Flight()
        {
            InitializeComponent();
            Resize += (s, e) => ApplyResponsiveLayout();
            ApplyResponsiveLayout();
        }

        private void ApplyResponsiveLayout()
        {
            int delta = Math.Max(0, ClientSize.Width - 701);

            lblAirlineName.Left = Math.Max(180, (ClientSize.Width - lblAirlineName.Width) / 2);
            aa.Left = 306 + delta;
            aaa.Left = 464 + delta;
            label1.Left = 612 + delta;
            lblDepTime.Left = 334 + delta;
            lblLandTime.Left = 477 + delta;
            lblPrice.Left = 603 + delta;
            btnbook.Left = 615 + delta;

            panel1.Left = 75;
            panel1.Width = Math.Max(551, 551 + delta);
        }

        private string airLineName;
        private string date;
        private string depTime;
        private string landTime; 
        private string price;

        public string airlineName
        {
            get
            {
                return airLineName;
            }
            set
            {
                airLineName = value;
                lblAirlineName.Text = value;
            }
        }

        public string Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
                lblDate.Text = value;
            }
        }

        public string DepTime
        {
            get
            {
                return depTime;
            }
            set
            {
                depTime = value;
                lblDepTime.Text = value;
            }
        }
        public string LandTime
        {
            get
            {
                return landTime;
            }
            set
            {
                landTime = value;
                lblLandTime.Text = value;
            }
        }

        public string Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
                lblPrice.Text = value;
            }
        }

        public void btnbook_Click(object sender, EventArgs e)
        {
            if (!Session.IsLoggedIn)
            {
                MessageBox.Show("You must be logged in to book.");
                return;
            }
            var FlightconfirmBookInstance = Flightconfirmbook.Instance;
            FlightconfirmBookInstance.airlineName = this.airlineName;
            FlightconfirmBookInstance.date = this.Date;
            FlightconfirmBookInstance.depTime = this.DepTime;
            FlightconfirmBookInstance.landTime = this.LandTime;
            FlightconfirmBookInstance.price = this.Price;

            Flightconfirmbook.Instance.flightconfirmbook_Load();
            Flightconfirmbook.Instance.BringToFront();

        }
    }
}

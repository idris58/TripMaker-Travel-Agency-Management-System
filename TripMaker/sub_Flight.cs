﻿using System;
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

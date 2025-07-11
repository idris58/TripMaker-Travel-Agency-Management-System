﻿using System;
using System.Windows.Forms;

namespace TripMaker
{
    public partial class Sub_RoomInfo : UserControl
    {
        public Sub_RoomInfo()
        {
            InitializeComponent();
        }

        private string breakfast;
        private string lunch;
        private string dinner;
        private string hotelName;
        private string roomName;
        private string guest;
        private string price;

        public void HideCheckBox()
        {
            checkBox.Visible = false;
        }

        public string Breakfast
        {
            get { return breakfast; }
            set { breakfast = value; lblBreakfast.Text = value; }
        }

        public string Lunch
        {
            get { return lunch; }
            set { lunch = value; lblLunch.Text = value; }
        }

        public string Dinner
        {
            get { return dinner; }
            set { dinner = value; lblDinner.Text = value; }
        }

        public string HotelName
        {
            get { return hotelName; }
            set { hotelName = value; }
        }

        public string RoomName
        {
            get { return roomName; }
            set { roomName = value; lblRoomName.Text = value; }
        }

        public string Guest
        {
            get { return guest; }
            set { guest = value; lblGuest.Text = value; }
        }

        public string Price
        {
            get { return price; }
            set { price = value; lblPrice.Text = value; }
        }

        public bool checkBox_checker()
        {
            return checkBox.Checked;
        }
    }
}

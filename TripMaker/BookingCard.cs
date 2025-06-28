using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TripMaker
{
    public partial class BookingCard: UserControl
    {
        public BookingCard()
        {
            InitializeComponent();
        }

        public void SetBookingData(string bookingId, string bookingDate, string bookingType)
        {
            lblBookingId.Text = "Booking ID: " + bookingId;
            lblBookingDate.Text = "Date: " + bookingDate;
            lblBookingType.Text = "Type: " + bookingType;

            panelTransport.Visible = bookingType == "Bus" || bookingType == "Flight" || bookingType == "Train";
            panelHotel.Visible = bookingType == "Hotel";
            panelActivity.Visible = bookingType == "Activity";
        }

        // Transport Section
        public void SetTransportData(string transportName, string seatNumber, string departure, string arrival, string price)
        {
            lblTransportName.Text = "Transport: " + transportName;
            lblSeatNumber.Text = "Seat: " + seatNumber;
            lblDeparture.Text = "Dep: " + departure;
            lblArrival.Text = "Arr: " + arrival;
            lblTransportPrice.Text = "Price: " + price;
        }

        // Hotel Section
        public void SetHotelData(string hotelName, string roomType, string checkIn, string checkOut, string price)
        {
            lblHotelName.Text = "Hotel: " + hotelName;
            lblRoomType.Text = "Room: " + roomType;
            lblCheckIn.Text = "Check-In: " + checkIn;
            lblCheckOut.Text = "Check-Out: " + checkOut;
            lblHotelPrice.Text = "Price: " + price;
        }

        // Activity Section
        public void SetActivityData(string activityName, string location, string price)
        {
            lblActivityName.Text = "Activity: " + activityName;
            lblLocation.Text = "Location: " + location;
            lblActivityPrice.Text = "Price: " + price;
        }
    }

}


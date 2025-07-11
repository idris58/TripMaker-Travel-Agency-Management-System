using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace TripMaker
{
    public partial class BookingInfo : UserControl
    {
        private static BookingInfo instance;
        public static BookingInfo Instance => instance ?? (instance = new BookingInfo());

        public BookingInfo()
        {
            InitializeComponent();
        }

        private void BookingInfo_Load(object sender, EventArgs e)
        {
            cmbBookingType.Items.AddRange(new string[] { "All", "Bus", "Flight", "Train", "Hotel", "Activity" });
            cmbBookingType.SelectedIndex = 0;
            dtpFrom.Value = DateTime.Now.AddDays(-30);
            dtpTo.Value = DateTime.Now.AddDays(1);
            LoadBookings();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadBookings();
        }

        private void cmbBookingType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBookings();
        }

        public void LoadBookings()
        {

            FlowLayoutPanel.Controls.Clear();

            string typeFilter = cmbBookingType.SelectedItem.ToString();
            string query = @"
            SELECT b.Booking_Id, TO_CHAR(b.Booking_Date, 'DD-MON-YYYY') AS Booking_Date, b.Booking_Type,
                   t.Transport_Name, t.Departure_Time, t.Arrival_Time, ti.Seat_Number, t.Price,
                   h.Hotel_Name, r.Normal, r.Super_Deluxe, r.Deluxe, rh.CheckIn_Date AS Check_In, rh.CheckOut_Date AS Check_Out, r.Price AS HotelPrice,
                   a.Activity_Name, a.Location, a.Price AS ActivityPrice
            FROM Booking_Info b
            LEFT JOIN Ticket ti ON b.Ticket_Number = ti.Ticket_Number
            LEFT JOIN Transport t ON ti.Transport_Id = t.Transport_Id
            LEFT JOIN Room_Booking rh ON b.Room_Booking_Id = rh.Room_Booking_Id
            LEFT JOIN Room r ON rh.Room_Id = r.Room_Id
            LEFT JOIN Hotel h ON r.Hotel_Id = h.Hotel_Id
            LEFT JOIN Activity_Booking ab ON b.Act_Booking_Id = ab.Act_Booking_Id
            LEFT JOIN Activity a ON ab.Activity_Id = a.Activity_Id
            WHERE b.C_Username = :username AND b.Booking_Date BETWEEN :fromDate AND :toDate";


            string error;
            List<OracleParameter> paramList = new List<OracleParameter>
            {
                new OracleParameter("username", Session.LoggedInUsername),
                new OracleParameter("fromDate", dtpFrom.Value.Date),
                new OracleParameter("toDate", dtpTo.Value.Date)
            };

            if (typeFilter != "All")
            {
                query += " AND b.Booking_Type = :typeFilter";
                paramList.Add(new OracleParameter("typeFilter", typeFilter));
            }
            query += " ORDER BY b.Booking_Date DESC";

            DataTable dt = DataAccess.GetData(query, paramList.ToArray(), out error);

            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show("Error loading bookings: " + error);
                return;
            }

            foreach (DataRow row in dt.Rows)
            {
                BookingCard card = new BookingCard();
                card.Width = FlowLayoutPanel.Width - 25;

                string type = row["Booking_Type"].ToString();
                card.SetBookingData(row["Booking_Id"].ToString(), row["Booking_Date"].ToString(), type);

                switch (type)
                {
                    case "Bus":
                    case "Flight":
                    case "Train":
                        card.SetTransportData(
                            row["Transport_Name"]?.ToString() ?? "N/A",
                            row["Seat_Number"]?.ToString() ?? "N/A",
                            row["Departure_Time"]?.ToString() ?? "N/A",
                            row["Arrival_Time"]?.ToString() ?? "N/A",
                            row["Price"]?.ToString() ?? "N/A"
                        );
                        break;

                    case "Hotel":
                        string roomType = "N/A";
                        if (row["Normal"]?.ToString() == "Yes") roomType = "Normal";
                        else if (row["Super_Deluxe"]?.ToString() == "Yes") roomType = "Super Deluxe";
                        else if (row["Deluxe"]?.ToString() == "Yes") roomType = "Deluxe";
                        card.SetHotelData(
                            row["Hotel_Name"]?.ToString() ?? "N/A",
                            roomType,
                            row["Check_In"]?.ToString() ?? "N/A",
                            row["Check_Out"]?.ToString() ?? "N/A",
                            row["HotelPrice"]?.ToString() ?? "N/A"
                        );
                        break;

                    case "Activity":
                        card.SetActivityData(
                            row["Activity_Name"]?.ToString() ?? "N/A",
                            row["Location"]?.ToString() ?? "N/A",
                            row["ActivityPrice"]?.ToString() ?? "N/A"
                        );
                        break;
                }

                FlowLayoutPanel.Controls.Add(card);
            }

            lblTotalBookings.Text = "Total Bookings: " + dt.Rows.Count;
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            LoadBookings();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            LoadBookings();
        }

    }
}
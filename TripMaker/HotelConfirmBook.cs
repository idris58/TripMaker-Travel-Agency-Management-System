using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace TripMaker
{
    public partial class HotelConfirmBook : UserControl
    {
        private static HotelConfirmBook instance;
        public static HotelConfirmBook Instance => instance ?? (instance = new HotelConfirmBook());
        public static HotelConfirmBook setInstance { set => instance = value; }

        private List<Sub_RoomInfo> selectedRooms;
        private string hotelName;

        public HotelConfirmBook()
        {
            InitializeComponent();
        }

        public void SetRoomSelection(List<Sub_RoomInfo> rooms, string hotel)
        {
            selectedRooms = rooms;
            hotelName = hotel;
            flowLayoutPanelRooms.Controls.Clear();
            decimal totalPrice = 0;

            foreach (var room in rooms)
            {
                flowLayoutPanelRooms.Controls.Add(room);

                // Sum up total price
                string priceText = room.Price.Replace(" TK", "").Trim();
                if (decimal.TryParse(priceText, out decimal price))
                {
                    totalPrice += price;
                }
            }

            lblTotalPrice.Text = "Total Price: " + totalPrice.ToString("0") + " TK";

            // Reset selections
            radioBkash.Checked = false;
            radioNagod.Checked = false;
            radioRocket.Checked = false;
            radioUpay.Checked = false;
            cmbNumber.SelectedIndex = -1;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            HotelRoom.Instance.BringToFront();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!(radioBkash.Checked || radioNagod.Checked || radioRocket.Checked || radioUpay.Checked))
            {
                MessageBox.Show("Please select a payment method.");
                return;
            }

            if (cmbNumber.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a number.");
                return;
            }

            if (!Session.IsLoggedIn)
            {
                MessageBox.Show("You must be logged in to confirm booking.");
                return;
            }

            try
            {
                using (var con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                {
                    con.Open();

                    DateTime checkInDate = Hotel.Instance.CheckInDate;
                    DateTime checkOutDate = Hotel.Instance.CheckOutDate;

                    // Get Hotel_Id
                    string getHotelIdQuery = "SELECT Hotel_Id FROM Hotel WHERE Hotel_Name = :hotelName";
                    int hotelId = 0;
                    using (OracleCommand cmd = new OracleCommand(getHotelIdQuery, con))
                    {
                        cmd.Parameters.Add("hotelName", OracleDbType.Varchar2).Value = hotelName;
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            hotelId = Convert.ToInt32(result);
                        }
                        else
                        {
                            MessageBox.Show("Hotel not found.");
                            return;
                        }
                    }

                    foreach (var roomInfo in selectedRooms)
                    {
                        // Determine Room Column
                        string roomType = roomInfo.RoomName;
                        string roomColumn = roomType == "Normal" ? "Normal" :
                                            roomType == "Deluxe" ? "Deluxe" :
                                            "Super_Deluxe";

                        // Get Room_Id
                        string query = $@"
                    SELECT Room_Id FROM Room 
                    WHERE Hotel_Id = :hotelId AND {roomColumn} = 'Yes' AND ROWNUM = 1";

                        int roomId = 0;
                        using (OracleCommand cmd = new OracleCommand(query, con))
                        {
                            cmd.Parameters.Add("hotelId", OracleDbType.Int32).Value = hotelId;
                            object result = cmd.ExecuteScalar();
                            if (result == null)
                            {
                                MessageBox.Show($"No available {roomType} room found.");
                                return;
                            }
                            roomId = Convert.ToInt32(result);
                        }

                        // Insert into Room_Booking
                        int roomBookingId = 0;
                        string insertRoomBooking = @"
                    INSERT INTO Room_Booking 
                    (Room_Booking_Id, Checkin_Date, Checkout_Date, C_Username, Room_Id)
                    VALUES (seq_Room_Booking.NEXTVAL, :checkin, :checkout, :username, :roomId)
                    RETURNING Room_Booking_Id INTO :roomBookingId";

                        using (OracleCommand cmd = new OracleCommand(insertRoomBooking, con))
                        {
                            cmd.Parameters.Add("checkin", OracleDbType.Date).Value = checkInDate;
                            cmd.Parameters.Add("checkout", OracleDbType.Date).Value = checkOutDate;
                            cmd.Parameters.Add("username", OracleDbType.Varchar2).Value = Session.LoggedInUsername;
                            cmd.Parameters.Add("roomId", OracleDbType.Int32).Value = roomId;
                            cmd.Parameters.Add("roomBookingId", OracleDbType.Int32).Direction = ParameterDirection.Output;

                            cmd.ExecuteNonQuery();
                            roomBookingId = ((Oracle.ManagedDataAccess.Types.OracleDecimal)cmd.Parameters["roomBookingId"].Value).ToInt32();
                        }

                        // Insert into Booking_Info
                        string insertBooking = @"
                    INSERT INTO Booking_Info 
                    (Booking_Id, Booking_Date, Booking_Type, C_Username, Ticket_Number, Room_Booking_Id, Act_Booking_Id)
                    VALUES (seq_Booking_Info.NEXTVAL, SYSDATE, 'Hotel', :username, NULL, :roomBookingId, NULL)";

                        using (OracleCommand cmd = new OracleCommand(insertBooking, con))
                        {
                            cmd.Parameters.Add("username", OracleDbType.Varchar2).Value = Session.LoggedInUsername;
                            cmd.Parameters.Add("roomBookingId", OracleDbType.Int32).Value = roomBookingId;
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Hotel room(s) booked successfully!");
                    Hotel.Instance.BringToFront();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Booking failed: " + ex.Message);
            }
        }
    }

}
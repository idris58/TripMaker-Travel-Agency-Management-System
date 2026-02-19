using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace TripMaker
{
    public partial class Flightconfirmbook : UserControl
    {
        private static Flightconfirmbook instance;
        public static Flightconfirmbook Instance => instance ?? (instance = new Flightconfirmbook());
        public static Flightconfirmbook setInstance { set { instance = value; } }

        public Flightconfirmbook()
        {
            InitializeComponent();
            Resize += (s, e) => ApplyResponsiveLayout();
        }

        private string airlinename,Date, dateTimePicker, deptime, landtime, Price;
        public string airlineName { get => airlinename; set { airlinename = value; lblAirlineName.Text = value; } }
        public string date { get => Date; set { Date = value; lblDate.Text = value; } }
        public string depTime { get => deptime; set { deptime = value; lblDepTime.Text = value; } }
        public string landTime { get => landtime; set { landtime = value; lblLandTime.Text = value; } }
        public string price { get => Price; set { Price = value; lblprice.Text = value; } }
        public string DateTimePicker { get => dateTimePicker; set { dateTimePicker = value; lblDate.Text = value; } }

        private Label selectedSeatLabel = null;
        private string selectedSeat = "";
        private List<string> bookedSeats = new List<string>();

        public void flightconfirmbook_Load()
        {
            GenerateSeatLabels();
            ApplyResponsiveLayout();
        }

        private void ApplyResponsiveLayout()
        {
            int w = ClientSize.Width;
            int h = ClientSize.Height;
            int shift = Math.Max(0, (w - 701) / 2);

            panel.Width = w;
            panel3.Left = shift + 2;
            label2.Left = shift + 48;
            pnlSeatNo.Left = shift + 21;
            label3.Left = shift + 317;
            cmbNumber.Left = shift + 313;
            gbPaymentMethods.Left = shift + 488;
            btnBack.Left = shift + 313;
            btnConfirm.Left = shift + 392;

            label4.Left = Math.Max(0, (panel.Width - label4.Width) / 2);
            panel3.Width = Math.Min(697, Math.Max(620, w - (shift * 2) - 4));
            pnlSeatNo.Height = Math.Max(228, h - pnlSeatNo.Top - 8);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Flight.Instance.BringToFront();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedSeat))
            {
                MessageBox.Show("Please select a seat.");
                return;
            }

            if (!(radioBkash.Checked || radioRocket.Checked || radioNagod.Checked || radioUpay.Checked))
            {
                MessageBox.Show("Please select a payment method.");
                return;
            }

            if (string.IsNullOrEmpty(cmbNumber.Text))
            {
                MessageBox.Show("Please select a number.");
                return;
            }

            if (!Session.IsLoggedIn)
            {
                MessageBox.Show("You must be logged in to book.");
                return;
            }

            string error;

            string query1 = @"SELECT Transport_Id FROM Transport WHERE Transport_Name = :name AND Type = 'Flight'";
            OracleParameter[] param1 = new OracleParameter[] { new OracleParameter("name", airlineName) };
            DataTable dt = DataAccess.GetData(query1, param1, out error);
            if (!string.IsNullOrEmpty(error) || dt.Rows.Count == 0)
            {
                MessageBox.Show("Flight not found.");
                return;
            }

            int transportId = Convert.ToInt32(dt.Rows[0][0]);

            string insertTicket = @"INSERT INTO Ticket (Ticket_Number, Ticket_Price, Seat_Number, Transport_Id, C_Username) VALUES (seq_Ticket.NEXTVAL, :price, :seat, :transportId, :username)";
            OracleParameter[] param2 = new OracleParameter[]
            {
                new OracleParameter("price", Convert.ToDecimal(new string(Price.Where(char.IsDigit).ToArray()))),
                new OracleParameter("seat", selectedSeat),
                new OracleParameter("transportId", transportId),
                new OracleParameter("username", Session.LoggedInUsername)
            };
            DataAccess.ExecuteData(insertTicket, param2, out error);
            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show("Failed to book ticket: " + error);
                return;
            }

            string getTicketQuery = "SELECT MAX(Ticket_Number) FROM Ticket WHERE C_Username = :username";
            OracleParameter[] param3 = { new OracleParameter("username", Session.LoggedInUsername) };
            DataTable dtTicket = DataAccess.GetData(getTicketQuery, param3, out error);
            if (!string.IsNullOrEmpty(error) || dtTicket.Rows.Count == 0)
            {
                MessageBox.Show("Failed to retrieve ticket number.");
                return;
            }

            int ticketNumber = Convert.ToInt32(dtTicket.Rows[0][0]);

            string insertBooking = @"INSERT INTO Booking_Info (Booking_Id, Booking_Date, Booking_Type, C_Username, Ticket_Number, Room_Booking_Id, Act_Booking_Id) VALUES (seq_Booking_Info.NEXTVAL, SYSDATE, 'Flight', :username, :ticketNumber, NULL, NULL)";
            OracleParameter[] param4 = new OracleParameter[]
            {
                new OracleParameter("username", Session.LoggedInUsername),
                new OracleParameter("ticketNumber", ticketNumber)
            };
            DataAccess.ExecuteData(insertBooking, param4, out error);
            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show("Failed to record booking info: " + error);
                return;
            }

            MessageBox.Show("Flight ticket booked successfully!");
            Flight.Instance.BringToFront();
        }

        private List<string> GetBookedSeatsForCurrentFlight()
        {
            List<string> seats = new List<string>();
            string query = @"SELECT t.Seat_Number FROM Ticket t JOIN Transport tr ON t.Transport_Id = tr.Transport_Id WHERE tr.Transport_Name = :name AND tr.Type = 'Flight'";
            OracleParameter[] param = { new OracleParameter("name", airlineName) };

            string error;
            DataTable dt = DataAccess.GetData(query, param, out error);
            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show("Failed to retrieve booked seats: " + error);
                return seats;
            }

            foreach (DataRow row in dt.Rows)
            {
                if (row["Seat_Number"] != DBNull.Value)
                    seats.Add(row["Seat_Number"].ToString());
            }

            return seats;
        }

        private void GenerateSeatLabels()
        {
            pnlSeatNo.Controls.Clear();
            bookedSeats = GetBookedSeatsForCurrentFlight();

            char rowChar = 'A';
            int totalSeats = 40;
            int seatsPerRow = 4;
            int labelWidth = 40;
            int labelHeight = 30;
            int spacing = 10;

            for (int i = 0; i < totalSeats; i++)
            {
                string seatId = $"{(char)(rowChar + (i / seatsPerRow))}{(i % seatsPerRow) + 1}";

                Label lblSeat = new Label
                {
                    Name = "lbl" + seatId,
                    Text = seatId,
                    Width = labelWidth,
                    Height = labelHeight,
                    BorderStyle = BorderStyle.FixedSingle,
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.LightGray,
                    Margin = new Padding(5),
                    Cursor = Cursors.Hand
                };

                if (bookedSeats.Contains(seatId))
                {
                    lblSeat.BackColor = Color.DarkGray;
                    lblSeat.Enabled = false;
                }
                else
                {
                    lblSeat.Click += (s, e) =>
                    {
                        if (selectedSeatLabel != null)
                            selectedSeatLabel.BackColor = Color.LightGray;

                        selectedSeatLabel = (Label)s;
                        selectedSeatLabel.BackColor = Color.LightGreen;
                        selectedSeat = selectedSeatLabel.Text;
                    };
                }

                pnlSeatNo.Controls.Add(lblSeat);
            }

            pnlSeatNo.AutoScroll = true;
            pnlSeatNo.Padding = new Padding(10);
            pnlSeatNo.WrapContents = true;
            pnlSeatNo.FlowDirection = FlowDirection.LeftToRight;
        }
    }
}

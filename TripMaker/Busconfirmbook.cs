using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TripMaker
{
    public partial class Busconfirmbook : UserControl
    {
        private static Busconfirmbook instance;
        public static Busconfirmbook Instance => instance ?? (instance = new Busconfirmbook());

        public static Busconfirmbook setInstance
        {
            set { instance = value; }
        }

        public Busconfirmbook()
        {
            InitializeComponent();
        }
        private List<string> bookedSeats = new List<string>();

        private string dateTimePicker, busname, start, ending, type, depTime, arrTime, price;

        public string Busname
        {
            get => busname;
            set { busname = value; Lblname.Text = value; }
        }

        public string Start
        {
            get => start;
            set { start = value; lblstart.Text = value; }
        }

        public string Ending
        {
            get => ending;
            set { ending = value; lblEnding.Text = value; }
        }

        public string DepTime
        {
            get => depTime;
            set { depTime = value; lbldepT.Text = value; }
        }

        public string ArrTime
        {
            get => arrTime;
            set { arrTime = value; lblarvT.Text = value; }
        }

        public string Price
        {
            get => price;
            set { price = value; lblprice.Text = value; }
        }

        public string DateTimePicker
        {
            get => dateTimePicker;
            set { dateTimePicker = value; lblDate.Text = value; }
        }

        public void busconfirmbook_Load()
        {
            GenerateSeatLabels();
            // Intentionally left blank — any pre-loading logic can go here.
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // Validate
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

            // Step 1: Find Transport_Id
            string query1 = @"
            SELECT Transport_Id FROM Transport 
            WHERE Transport_Name = :name AND Type = 'Bus' AND From_Location = :b_from AND To_Location = :b_to";

            OracleParameter[] param1 = new OracleParameter[]
            {
                new OracleParameter("name", Busname),
                new OracleParameter("b_from", Start),
                new OracleParameter("b_to", Ending)
            };

            DataTable dt = DataAccess.GetData(query1, param1, out error);
            

            if (!string.IsNullOrEmpty(error) || dt.Rows.Count == 0)
            {
                MessageBox.Show("Bus not found.");
                return;
            }

            int transportId = Convert.ToInt32(dt.Rows[0][0]);

            // Step 2: Insert Ticket
            string insertTicket = @"INSERT INTO Ticket 
            (Ticket_Number, Ticket_Price, Seat_Number, Transport_Id, C_Username) 
            VALUES (seq_Ticket.NEXTVAL, :price, :seat, :transportId, :username)";

            OracleParameter[] param2 = new OracleParameter[]
            {
                new OracleParameter("price", Convert.ToDecimal(new string(Price.Where(char.IsDigit).ToArray()))),
                new OracleParameter("seat", string.IsNullOrEmpty(selectedSeat) ? "A1" : selectedSeat),
                new OracleParameter("transportId", transportId),
                new OracleParameter("username", Session.LoggedInUsername)
            };

            DataAccess.ExecuteData(insertTicket, param2, out error);
            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show("Failed to book ticket: " + error);
                return;
            }

            // Step 3: Get Ticket Number
            string getTicketQuery = "SELECT MAX(Ticket_Number) FROM Ticket WHERE C_Username = :username";
            OracleParameter[] param3 = { new OracleParameter("username", Session.LoggedInUsername) };
            DataTable dtTicket = DataAccess.GetData(getTicketQuery, param3, out error);
            if (!string.IsNullOrEmpty(error) || dtTicket.Rows.Count == 0)
            {
                MessageBox.Show("Failed to retrieve ticket number.");
                return;
            }

            int ticketNumber = Convert.ToInt32(dtTicket.Rows[0][0]);

            // Step 4: Insert into Booking_Info
            string insertBooking = @"INSERT INTO Booking_Info 
            (Booking_Id, Booking_Date, Booking_Type, C_Username, Ticket_Number, Room_Booking_Id, Act_Booking_Id) 
            VALUES (seq_Booking_Info.NEXTVAL, SYSDATE, 'Bus', :username, :ticketNumber, NULL, NULL)";

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

            MessageBox.Show("Bus ticket booked successfully!");
            Bus.Instance.BringToFront();



        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Bus.Instance.BringToFront();
        }

        private List<string> GetBookedSeatsForCurrentBus()
        {
            List<string> seats = new List<string>();

            string query = @"
              SELECT t.Seat_Number 
              FROM Ticket t
              JOIN Transport tr ON t.Transport_Id = tr.Transport_Id
              WHERE tr.Transport_Name = :name AND tr.Type = 'Bus' 
              AND tr.From_Location = :fromLoc AND tr.To_Location = :toLoc";

            OracleParameter[] param = new OracleParameter[]
            {
                new OracleParameter("name", Busname),
                new OracleParameter("fromLoc", Start),
                new OracleParameter("toLoc", Ending)
            };

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




        private Label selectedSeatLabel = null;
        private string selectedSeat = "";

        private void GenerateSeatLabels()
        {
            pnlSeatNo.Controls.Clear();
            bookedSeats = GetBookedSeatsForCurrentBus(); 

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
                    BackColor = Color.FromArgb(237, 237, 237),
                    Margin = new Padding(5),
                    Cursor = Cursors.Hand
                };

                if (bookedSeats.Contains(seatId))
                {
                    lblSeat.BackColor = Color.FromArgb(114, 114, 144);
                    lblSeat.Enabled = false;
                }
                else
                {
                    lblSeat.Click += (s, e) =>
                    {
                        if (selectedSeatLabel != null)
                            selectedSeatLabel.BackColor = Color.FromArgb(237, 237, 237);

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

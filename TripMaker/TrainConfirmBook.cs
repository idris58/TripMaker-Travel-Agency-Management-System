using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace TripMaker
{
    public partial class TrainConfirmBook : UserControl
    {
        private static TrainConfirmBook instance;
        public static TrainConfirmBook Instance => instance ?? (instance = new TrainConfirmBook());
        public static TrainConfirmBook setInstance
        {
            set { instance = value; }
        }

        public TrainConfirmBook()
        {
            InitializeComponent();
            Resize += (s, e) => ApplyResponsiveLayout();
        }

        private List<string> bookedSeats = new List<string>();
        private Label selectedSeatLabel = null;
        private string selectedSeat = "";

        private string dateTimePicker, trainname, start, ending, type, depTime, arrTime, price;

        public string Trainname
        {
            get => trainname;
            set { trainname = value; Lblname.Text = value; }
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

        public void trainconfirmbook_Load()
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
            panel1.Left = shift + 2;
            label1.Left = shift + 48;
            pnlSeatNo.Left = shift + 21;
            label4.Left = shift + 317;
            cmbNumber.Left = shift + 313;
            gbPaymentMethods.Left = shift + 488;
            btnBack.Left = shift + 311;
            btnConfirm.Left = shift + 392;

            lblDate.Left = Math.Max(0, (panel.Width - lblDate.Width) / 2);
            panel1.Width = Math.Min(699, Math.Max(620, w - (shift * 2) - 2));
            pnlSeatNo.Height = Math.Max(228, h - pnlSeatNo.Top - 8);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedSeat))
            {
                MessageBox.Show("Please select a seat.");
                return;
            }

            if (!Session.IsLoggedIn)
            {
                MessageBox.Show("You must be logged in to book.");
                return;
            }

            string error;

            string query1 = @"SELECT Transport_Id FROM Transport 
                               WHERE Transport_Name = :name AND Type = 'Train' 
                               AND From_Location = :fromLoc AND To_Location = :toLoc";

            OracleParameter[] param1 = new OracleParameter[]
            {
                new OracleParameter("name", Trainname),
                new OracleParameter("fromLoc", Start),
                new OracleParameter("toLoc", Ending)
            };

            DataTable dt = DataAccess.GetData(query1, param1, out error);
            if (!string.IsNullOrEmpty(error) || dt.Rows.Count == 0)
            {
                MessageBox.Show("Train not found.");
                return;
            }

            int transportId = Convert.ToInt32(dt.Rows[0][0]);

            string insertTicket = @"INSERT INTO Ticket 
                (Ticket_Number, Ticket_Price, Seat_Number, Transport_Id, C_Username) 
                VALUES (seq_Ticket.NEXTVAL, :price, :seat, :transportId, :username)";

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

            string insertBooking = @"INSERT INTO Booking_Info 
                (Booking_Id, Booking_Date, Booking_Type, C_Username, Ticket_Number, Room_Booking_Id, Act_Booking_Id) 
                VALUES (seq_Booking_Info.NEXTVAL, SYSDATE, 'Train', :username, :ticketNumber, NULL, NULL)";

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

            MessageBox.Show("Train ticket booked successfully!");
            Train.Instance.BringToFront();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Train.Instance.BringToFront();
        }

        private List<string> GetBookedSeatsForCurrentTrain()
        {
            List<string> seats = new List<string>();

            string query = @"SELECT t.Seat_Number 
                             FROM Ticket t
                             JOIN Transport tr ON t.Transport_Id = tr.Transport_Id
                             WHERE tr.Transport_Name = :name AND tr.Type = 'Train' 
                             AND tr.From_Location = :fromLoc AND tr.To_Location = :toLoc";

            OracleParameter[] param = new OracleParameter[]
            {
                new OracleParameter("name", Trainname),
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

        private void GenerateSeatLabels()
        {
            pnlSeatNo.Controls.Clear();
            bookedSeats = GetBookedSeatsForCurrentTrain();

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

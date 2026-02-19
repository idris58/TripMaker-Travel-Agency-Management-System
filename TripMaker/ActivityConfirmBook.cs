using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace TripMaker
{
    public partial class ActivityConfirmBook : UserControl
    {
        private static ActivityConfirmBook instance;
        public static ActivityConfirmBook Instance => instance ?? (instance = new ActivityConfirmBook());

        public static ActivityConfirmBook setInstance
        {
            set { instance = value; }
        }

        public ActivityConfirmBook()
        {
            InitializeComponent();
            Resize += (s, e) => ApplyResponsiveLayout();
            VisibleChanged += (s, e) => { if (Visible) ApplyResponsiveLayout(); };
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

        public string acLocation
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

        public void activityconfirmbook_Load()
        {
            ApplyResponsiveLayout();
        }

        private void ApplyResponsiveLayout()
        {
            int w = ClientSize.Width;
            int shift = Math.Max(0, (w - 701) / 2);

            panel.Width = w;
            panel1.Left = shift + 1;
            label3.Left = shift + 168;
            cmbNumber.Left = shift + 169;
            gbPaymentMethods.Left = shift + 370;
            btnBack.Left = shift + 169;
            btnConfirm.Left = shift + 252;
            pp.Left = Math.Max(0, (panel.Width - pp.Width) / 2);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Activity.Instance.BringToFront();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // Validate
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
            string activityIdQuery = "SELECT Activity_Id FROM Activity WHERE Activity_Name = :name AND Location = :loc";
            OracleParameter[] param1 = new OracleParameter[]
            {
                new OracleParameter("name", ActivityName),
                new OracleParameter("loc", acLocation)
            };
            DataTable dtAct = DataAccess.GetData(activityIdQuery, param1, out error);
            if (!string.IsNullOrEmpty(error) || dtAct.Rows.Count == 0)
            {
                MessageBox.Show("Activity not found.");
                return;
            }

            int activityId = Convert.ToInt32(dtAct.Rows[0][0]);

            string insertActBook = "INSERT INTO Activity_Booking VALUES (seq_Activity_Booking.NEXTVAL, SYSDATE, :activityId, :username)";
            OracleParameter[] param2 = new OracleParameter[]
            {
                new OracleParameter("activityId", activityId),
                new OracleParameter("username", Session.LoggedInUsername)
            };
            DataAccess.ExecuteData(insertActBook, param2, out error);
            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show("Failed to book activity: " + error);
                return;
            }

            string getActBookIdQuery = "SELECT MAX(Act_Booking_Id) FROM Activity_Booking WHERE C_Username = :username";
            OracleParameter[] param3 = { new OracleParameter("username", Session.LoggedInUsername) };
            DataTable dtActBookId = DataAccess.GetData(getActBookIdQuery, param3, out error);
            if (!string.IsNullOrEmpty(error) || dtActBookId.Rows.Count == 0)
            {
                MessageBox.Show("Failed to retrieve booking ID.");
                return;
            }

            int actBookingId = Convert.ToInt32(dtActBookId.Rows[0][0]);

            string insertBookingInfo = @"INSERT INTO Booking_Info
                (Booking_Id, Booking_Date, Booking_Type, C_Username, Ticket_Number, Room_Booking_Id, Act_Booking_Id)
                VALUES (seq_Booking_Info.NEXTVAL, SYSDATE, 'Activity', :username, NULL, NULL, :actBookingId)";

            OracleParameter[] param4 = new OracleParameter[]
            {
                new OracleParameter("username", Session.LoggedInUsername),
                new OracleParameter("actBookingId", actBookingId)
            };

            DataAccess.ExecuteData(insertBookingInfo, param4, out error);
            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show("Failed to record booking info: " + error);
                return;
            }

            MessageBox.Show("Activity booked successfully!");
            Activity.Instance.BringToFront();
        }
    }
}

using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;

namespace TripMaker
{
    public partial class Flight : UserControl
    {
        private static Flight instance;
        private sub_Flight[] flightCards;
        private int[] index;
        private string dateTimePicker;

        public string DateTimePicker => dateTimePicker;
        
        public static Flight Instance => instance ?? (instance = new Flight());

        public static Flight setInstance
        {
            set { instance = value; }
        }

        public Flight()
        {
            InitializeComponent();
            Resize += (s, e) => ApplyResponsiveLayout();
            flowFlightPanel.Resize += (s, e) => ResizeBookingCards();
        }

        private void Flight_Load(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT DISTINCT From_Location, To_Location FROM Transport WHERE Type = 'Flight'";
                string error;
                DataTable dt = DataAccess.GetData(query, out error);

                if (!string.IsNullOrEmpty(error))
                {
                    MessageBox.Show("Error loading stations: " + error);
                    return;
                }
                cbFromAirport.Items.Clear();
                cbToAirport.Items.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    if (!cbFromAirport.Items.Contains(row["From_Location"].ToString()))
                        cbFromAirport.Items.Add(row["From_Location"].ToString());
                    if (!cbToAirport.Items.Contains(row["To_Location"].ToString()))
                        cbToAirport.Items.Add(row["To_Location"].ToString());
                }

                //cbFromAirport.DropDownStyle = ComboBoxStyle.DropDownList;
                //cbToAirport.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception during loading stations: " + ex.Message);
            }
            ApplyResponsiveLayout();
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            panel.Visible = false;
            flowFlightPanel.Controls.Clear();

            if (string.IsNullOrEmpty(cbFromAirport.Text) || string.IsNullOrEmpty(cbToAirport.Text))
            {
                MessageBox.Show("Please select both From and To locations.");
                return;
            }

            try
            {
                //string from = cbFromAirport.SelectedItem.ToString();
                //string to = cbToAirport.SelectedItem.ToString();


                string query = @"SELECT * FROM Transport 
                             WHERE Type = 'Flight' 
                             AND From_Location = :FromLoc 
                             AND To_Location = :ToLoc";
                OracleParameter[] parameters = new OracleParameter[]
                {
                    new OracleParameter("FromLoc", cbFromAirport.Text),
                    new OracleParameter("ToLoc", cbToAirport.Text)
                };

                string error;
                DataTable dt = DataAccess.GetData(query, parameters, out error);

                if (!string.IsNullOrEmpty(error))
                {
                    MessageBox.Show("Error loading flights: " + error);
                    return;
                }

                flightCards = new sub_Flight[dt.Rows.Count];
                index = new int[flightCards.Length];

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No flights found for selected route.");
                    return;
                }

                dateTimePicker = dtbjourney.Value.ToShortDateString();
                Flightconfirmbook.Instance.DateTimePicker = this.dateTimePicker;

                for (int i = 0; i < flightCards.Length; i++)
                {
                    flightCards[i] = new sub_Flight
                    {
                        airlineName = dt.Rows[i]["Transport_Name"].ToString(),
                        Date = dtbjourney.Value.ToShortDateString(),
                        DepTime = Convert.ToDateTime(dt.Rows[i]["Departure_Time"]).ToShortTimeString(),
                        LandTime = Convert.ToDateTime(dt.Rows[i]["Arrival_Time"]).ToShortTimeString(),
                        Price = dt.Rows[i]["Price"].ToString() + " BDT"
                    };

                    flowFlightPanel.Controls.Add(flightCards[i]);
                    panel.Visible = true;
                }
                ResizeBookingCards();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search failed: " + ex.Message);
            }
        }

        private void ApplyResponsiveLayout()
        {
            int w = ClientSize.Width;
            int h = ClientSize.Height;
            int shift = Math.Max(0, (w - 701) / 2);

            label5.Left = shift + ((701 - label5.Width) / 2);

            label3.Left = shift + 78;
            cbFromAirport.Left = shift + 82;

            label4.Left = shift + 233;
            cbToAirport.Left = shift + 277;

            DateLbl.Left = shift + 459;
            dtbjourney.Left = shift + 462;
            btnSearch.Left = shift + 577;

            panel.Left = 0;
            panel.Width = w;

            flowFlightPanel.Width = w;
            flowFlightPanel.Height = Math.Max(0, h - flowFlightPanel.Top);
            ResizeBookingCards();
        }

        private void ResizeBookingCards()
        {
            int cardWidth = Math.Max(701, flowFlightPanel.ClientSize.Width - 20);
            foreach (Control control in flowFlightPanel.Controls)
            {
                if (control is sub_Flight)
                {
                    control.Width = cardWidth;
                }
            }
        }

    }
}

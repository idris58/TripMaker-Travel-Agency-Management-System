using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;

namespace TripMaker
{
    public partial class Bus : UserControl
    {
        private static Bus instance;
        private Busbooking[] operetor;
        private int[] index;
        private string dateTimePicker;

        public string DateTimePicker => dateTimePicker;

        public static Bus Instance => instance ?? (instance = new Bus());

        public static Bus setInstance
        {
            set { instance = value; }
        }

        public Bus()
        {
            InitializeComponent();
            Resize += (s, e) => ApplyResponsiveLayout();
            flowLayoutPanel1.Resize += (s, e) => ResizeBookingCards();
        }

        private void Bus_Load(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT DISTINCT From_Location, To_Location FROM Transport WHERE Type = 'Bus'";
                string error;
                DataTable dt = DataAccess.GetData(query, out error);

                if (!string.IsNullOrEmpty(error))
                {
                    MessageBox.Show("Error loading stations: " + error);
                    return;
                }

                cmbstart.Items.Clear();
                cmbto.Items.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    if (!cmbstart.Items.Contains(row["From_Location"].ToString()))
                        cmbstart.Items.Add(row["From_Location"].ToString());
                    if (!cmbto.Items.Contains(row["To_Location"].ToString()))
                        cmbto.Items.Add(row["To_Location"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception during loading stations: " + ex.Message);
            }
            ApplyResponsiveLayout();
        }

        private void ApplyResponsiveLayout()
        {
            int w = ClientSize.Width;
            int h = ClientSize.Height;
            int shift = Math.Max(0, (w - 701) / 2);

            label2.Left = shift + 42;
            cmbstart.Left = shift + 45;

            label1.Left = shift + 190;
            cmbto.Left = shift + 193;

            panel1.Left = shift + 380;

            label3.Left = shift + 436;
            dtbjourney.Left = shift + 440;
            btnSearch.Left = shift + 606;

            label5.Left = shift + ((701 - label5.Width) / 2);

            panel.Left = 0;
            panel.Width = w;

            flowLayoutPanel1.Left = 0;
            flowLayoutPanel1.Width = w;
            flowLayoutPanel1.Height = Math.Max(0, h - flowLayoutPanel1.Top);
            ResizeBookingCards();
        }

        private void ResizeBookingCards()
        {
            int cardWidth = Math.Max(674, flowLayoutPanel1.ClientSize.Width - 25);
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is Busbooking)
                {
                    control.Width = cardWidth;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            panel.Visible = false;
            flowLayoutPanel1.Controls.Clear();

            if (string.IsNullOrEmpty(cmbstart.Text) || string.IsNullOrEmpty(cmbto.Text))
            {
                MessageBox.Show("Please select both From and To locations.");
                return;
            }

            try
            {
                string query = @"SELECT * FROM Transport 
                             WHERE Type = 'Bus' 
                             AND From_Location = :fromLoc 
                             AND To_Location = :toLoc";

                OracleParameter[] parameters = new OracleParameter[]
                {
                new OracleParameter("fromLoc", cmbstart.Text),
                new OracleParameter("toLoc", cmbto.Text)
                };

                string error;
                DataTable dt = DataAccess.GetData(query, parameters, out error);

                if (!string.IsNullOrEmpty(error))
                {
                    MessageBox.Show("Error loading Buses: " + error);
                    return;
                }

                operetor = new Busbooking[dt.Rows.Count];
                index = new int[operetor.Length];

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No buses found for selected route.");
                    return;
                }

                dateTimePicker = dtbjourney.Value.ToShortDateString();
                Busconfirmbook.Instance.DateTimePicker = this.dateTimePicker;

                for (int i = 0; i < operetor.Length; i++)
                {
                    operetor[i] = new Busbooking
                    {
                        busname = dt.Rows[i]["Transport_Name"].ToString(),
                        Start = dt.Rows[i]["From_Location"].ToString(),
                        Ending = dt.Rows[i]["To_Location"].ToString(),
                        DepTime = Convert.ToDateTime(dt.Rows[i]["Departure_Time"]).ToString("HH:mm"),
                        ArrTime = Convert.ToDateTime(dt.Rows[i]["Arrival_Time"]).ToString("HH:mm"),
                        Price = dt.Rows[i]["Price"].ToString() + " BDT",
                    };

                    flowLayoutPanel1.Controls.Add(operetor[i]);
                    panel.Visible = true;
                }
                ResizeBookingCards();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search failed: " + ex.Message);
            }
        }
    }
}

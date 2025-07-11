using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;

namespace TripMaker
{
    public partial class Train : UserControl
    {
        private static Train instance;
        private TrainBooking[] operators;
        private int[] index;
        private string dateTimePicker;

        public string DateTimePicker => dateTimePicker;

        public static Train Instance => instance ?? (instance = new Train());

        public static Train setInstance
        {
            set { instance = value; }
        }

        public Train()
        {
            InitializeComponent();
        }

        private void Train_Load(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT DISTINCT From_Location, To_Location FROM Transport WHERE Type = 'Train'";
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
                         WHERE Type = 'Train' 
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
                    MessageBox.Show("Error loading Trains: " + error);
                    return;
                }

                operators = new TrainBooking[dt.Rows.Count];
                index = new int[operators.Length];

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No trains found for selected route.");
                    return;
                }

                dateTimePicker = dtbjourney.Value.ToShortDateString();
                TrainConfirmBook.Instance.DateTimePicker = this.dateTimePicker;

                for (int i = 0; i < operators.Length; i++)
                {
                    operators[i] = new TrainBooking
                    {
                        trainname = dt.Rows[i]["Transport_Name"].ToString(),
                        Start = dt.Rows[i]["From_Location"].ToString(),
                        Ending = dt.Rows[i]["To_Location"].ToString(),
                        DepTime = Convert.ToDateTime(dt.Rows[i]["Departure_Time"]).ToString("HH:mm"),
                        ArrTime = Convert.ToDateTime(dt.Rows[i]["Arrival_Time"]).ToString("HH:mm"),
                        Price = dt.Rows[i]["Price"].ToString() + " BDT",
                        Ttype = dt.Rows[i]["Type"].ToString()
                    };

                    flowLayoutPanel1.Controls.Add(operators[i]);
                    panel.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search failed: " + ex.Message);
            }
        }

    }
}
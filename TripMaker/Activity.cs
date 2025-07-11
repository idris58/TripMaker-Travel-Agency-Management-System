using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;

namespace TripMaker
{
    public partial class Activity : UserControl
    {
        private static Activity instance;
        private ActivityBooking[] activityCards;

        public static Activity Instance => instance ?? (instance = new Activity());

        public static Activity setInstance
        {
            set { instance = value; }
        }

        public Activity()
        {
            InitializeComponent();
        }

        private void Activity_Load(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT DISTINCT Location FROM Activity";
                string error;
                DataTable dt = DataAccess.GetData(query, out error);

                if (!string.IsNullOrEmpty(error))
                {
                    MessageBox.Show("Error loading locations: " + error);
                    return;
                }

                cmbLocation.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    cmbLocation.Items.Add(row["Location"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception during loading locations: " + ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            panel.Visible = false;
            flowLayoutPanel1.Controls.Clear();

            if (string.IsNullOrEmpty(cmbLocation.Text))
            {
                MessageBox.Show("Please select a location.");
                return;
            }

            try
            {
                string query = "SELECT * FROM Activity WHERE Location = :location";
                OracleParameter[] parameters = new OracleParameter[]
                {
                    new OracleParameter("location", cmbLocation.Text)
                };

                string error;
                DataTable dt = DataAccess.GetData(query, parameters, out error);

                if (!string.IsNullOrEmpty(error))
                {
                    MessageBox.Show("Error loading activities: " + error);
                    return;
                }

                activityCards = new ActivityBooking[dt.Rows.Count];

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No activities found at this location.");
                    return;
                }

                for (int i = 0; i < activityCards.Length; i++)
                {
                    activityCards[i] = new ActivityBooking
                    {
                        ActivityName = dt.Rows[i]["Activity_Name"].ToString(),
                        Category = dt.Rows[i]["Category"].ToString(),
                        AcLocation = dt.Rows[i]["Location"].ToString(),
                        Price = dt.Rows[i]["Price"].ToString()
                    };

                    flowLayoutPanel1.Controls.Add(activityCards[i]);
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

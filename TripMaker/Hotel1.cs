using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace TripMaker
{
    public partial class Hotel : UserControl
    {
        private Sub_HotelName[] sub_HotelName;
        private int[] index;
        private static Hotel instance;
        private string dateTimePicker11;
        private string dateTimePicker22;

        public DateTime CheckInDate => dateTimePicker1.Value.Date;
        public DateTime CheckOutDate => dateTimePicker2.Value.Date;

        public static Hotel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Hotel();
                }
                return instance;
            }
        }

        public static Hotel setInstance { set => instance = value; }

        public Hotel()
        {
            InitializeComponent();
            Resize += (s, e) => ApplyResponsiveLayout();
            flowLayoutPanel1.Resize += (s, e) => ResizeHotelCards();
        }

        private void Hotel_Load(object sender, EventArgs e)
        {
            string error = "";
            try
            {
                using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                {
                    con.Open();
                    string query = "SELECT DISTINCT Location FROM Hotel";
                    using (OracleCommand cmd = new OracleCommand(query, con))
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbDestination.Items.Add(reader.GetString(0));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading destinations: " + ex.Message);
            }
            ApplyResponsiveLayout();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();

            if (string.IsNullOrEmpty(cmbDestination.Text))
                return;

            string selectedLocation = cmbDestination.Text;
            try
            {
                using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                {
                    con.Open();
                    string query = "SELECT Hotel_Name FROM Hotel WHERE Location = :location";
                    using (OracleCommand cmd = new OracleCommand(query, con))
                    {
                        cmd.Parameters.Add("location", OracleDbType.Varchar2).Value = selectedLocation;

                        using (OracleDataAdapter da = new OracleDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            sub_HotelName = new Sub_HotelName[dt.Rows.Count];
                            index = new int[dt.Rows.Count];

                            if (dt.Rows.Count == 0)
                            {
                                panel.Visible = false;
                                return;
                            }

                            dateTimePicker11 = dateTimePicker1.Value.ToShortDateString();
                            dateTimePicker22 = dateTimePicker2.Value.ToShortDateString();

                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                sub_HotelName[i] = new Sub_HotelName();
                                sub_HotelName[i].HotelNamee = dt.Rows[i]["Hotel_Name"].ToString();
                                flowLayoutPanel1.Controls.Add(sub_HotelName[i]);
                            }
                            ResizeHotelCards();

                            panel.Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during search: " + ex.Message);
            }
        }

        private void ApplyResponsiveLayout()
        {
            int w = ClientSize.Width;
            int h = ClientSize.Height;
            int shift = Math.Max(0, (w - 701) / 2);

            label2.Left = shift + 32;
            cmbDestination.Left = shift + 36;

            label4.Left = shift + 322;
            dateTimePicker1.Left = shift + 325;

            label5.Left = shift + 540;
            dateTimePicker2.Left = shift + 544;

            btnSearch.Left = shift + 596;

            panel.Left = 0;
            panel.Width = w;

            flowLayoutPanel1.Width = w;
            flowLayoutPanel1.Height = Math.Max(0, h - flowLayoutPanel1.Top);
            ResizeHotelCards();
        }

        private void ResizeHotelCards()
        {
            int cardWidth = Math.Max(698, flowLayoutPanel1.ClientSize.Width - 20);
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is Sub_HotelName)
                {
                    control.Width = cardWidth;
                }
            }
        }
    }
}

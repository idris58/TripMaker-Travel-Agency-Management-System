using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace TripMaker
{
    public partial class ManegerBus : MetroFramework.Forms.MetroForm
    {
        public ManegerBus()
        {
            InitializeComponent();
        }

        private void loadgrid()
        {
            string error;
            try
            {
                string query = @"SELECT b.bus_id, b.bus_company,
                                        bs1.station_name AS departure_station,
                                        bs2.station_name AS arrival_station,
                                        b.departure_time, b.arrival_time,
                                        b.bus_type, b.price
                                FROM Transport b
                                JOIN Bus_Station bs1 ON b.departure_station_id = bs1.station_id
                                JOIN Bus_Station bs2 ON b.arrival_station_id = bs2.station_id
                                WHERE b.type = 'Bus'";

                DataTable dt = DataAccess.GetData(query, out error);
                if (!string.IsNullOrEmpty(error))
                {
                    MessageBox.Show(error);
                    return;
                }

                metroGrid.DataSource = dt;
                metroGrid.Refresh();
                metroGrid.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ManegerBus_Load(object sender, EventArgs e)
        {
            this.loadgrid();
        }

        private void metroGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string id = metroGrid.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.loaddetail(id);
            }
        }

        private void loaddetail(string id)
        {
            string error;
            try
            {
                string query = @"SELECT b.bus_id, b.bus_company,
                                        bs1.station_name AS departure_station,
                                        bs2.station_name AS arrival_station,
                                        b.departure_time, b.arrival_time,
                                        b.bus_type, b.price
                                FROM Transport b
                                JOIN Bus_Station bs1 ON b.departure_station_id = bs1.station_id
                                JOIN Bus_Station bs2 ON b.arrival_station_id = bs2.station_id
                                WHERE b.bus_id = " + id;

                DataTable dt = DataAccess.GetData(query, out error);

                if (!string.IsNullOrEmpty(error))
                {
                    MessageBox.Show(error);
                    return;
                }

                txtid.Text = dt.Rows[0]["bus_id"].ToString();
                txtName.Text = dt.Rows[0]["bus_company"].ToString();
                txtds.Text = dt.Rows[0]["departure_station"].ToString();
                txtas.Text = dt.Rows[0]["arrival_station"].ToString();
                txtdt.Text = dt.Rows[0]["departure_time"].ToString();
                txtat.Text = dt.Rows[0]["arrival_time"].ToString();
                txtbt.Text = dt.Rows[0]["bus_type"].ToString();
                txtprice.Text = dt.Rows[0]["price"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            string error;
            try
            {
                if (string.IsNullOrEmpty(txtid.Text))
                {
                    MessageBox.Show("Please Select A Row");
                    return;
                }

                var msg = MessageBox.Show("Are You Sure ?", "Confirmation", MessageBoxButtons.YesNo);
                if (msg == DialogResult.Yes)
                {
                    string query = "DELETE FROM Transport WHERE Transport_Id = " + txtid.Text;

                    DataAccess.ExecuteData(query, out error);
                    if (!string.IsNullOrEmpty(error))
                    {
                        MessageBox.Show(error);
                        return;
                    }

                    this.loadgrid();
                    this.newdata();
                    MessageBox.Show("Deleted");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            this.loadgrid();
            this.newdata();
        }

        private void newdata()
        {
            txtid.Text = "";
            txtName.Text = "";
            txtds.Text = "";
            txtas.Text = "";
            txtdt.Text = "";
            txtat.Text = "";
            txtbt.Text = "";
            txtprice.Text = "";
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            string id = txtid.Text;
            string bname = txtName.Text;
            string Ds = txtds.Text;
            string ass = txtas.Text;
            string dt = txtdt.Text;
            string at = txtat.Text;
            string bt = txtbt.Text;
            string price = txtprice.Text;
            string error = ""; ;

            try
            {
                // Get departure station id
                string q1 = $"SELECT station_id FROM bus_station_table WHERE station_name = '{Ds}'";
                DataTable dt1 = DataAccess.GetData(q1, out error);
                if (!string.IsNullOrEmpty(error))
                {
                    MessageBox.Show(error);
                    return;
                }
                if (dt1.Rows.Count == 0)
                {
                    MessageBox.Show("Invalid departure station");
                    return;
                }
                int depId = Convert.ToInt32(dt1.Rows[0][0]);

                // Get arrival station id
                string q2 = $"SELECT station_id FROM bus_station_table WHERE station_name = '{ass}'";
                DataTable dt2 = DataAccess.GetData(q2, out error);
                if (!string.IsNullOrEmpty(error))
                {
                    MessageBox.Show(error);
                    return;
                }
                if (dt2.Rows.Count == 0)
                {
                    MessageBox.Show("Invalid arrival station");
                    return;
                }
                int arrId = Convert.ToInt32(dt2.Rows[0][0]);

                if (string.IsNullOrEmpty(id))
                {
                    // INSERT
                    string q = $@"

                        INSERT INTO Transport (Transport_Id, Transport_Name, Type, Seat_Capacity, Departure_Time, Arrival_Time, Price, Admin_Id)
                        VALUES (seq_Transport.NEXTVAL, '{bname}', 'Bus', 40, TO_DATE('{dt}','YYYY-MM-DD HH24:MI'), TO_DATE('{at}','YYYY-MM-DD HH24:MI'), {price}, 1)";
                    DataAccess.ExecuteData(q, out error);
                    if (!string.IsNullOrEmpty(error))
                    {
                        MessageBox.Show(error);
                        return;
                    }
                    MessageBox.Show("Bus added successfully");
                }
                else
                {
                    // UPDATE
                    string q = $@"
                    UPDATE Transport
                    SET Transport_Name = '{bname}',
                    Type = 'Bus',
                    Departure_Time = TO_DATE('{dt}','YYYY-MM-DD HH24:MI'),
                    Arrival_Time = TO_DATE('{at}','YYYY-MM-DD HH24:MI'),
                    Price = {price}
                    WHERE Transport_Id = {id}";
                    DataAccess.ExecuteData(q, out error);
                    if (!string.IsNullOrEmpty(error))
                    {
                        MessageBox.Show(error);
                        return;
                    }
                    MessageBox.Show("Bus updated successfully");
                }

                this.loadgrid();
                this.newdata();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected Error: " + ex.Message);
            }

        }



        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminHome obj = new AdminHome();
            obj.Show();
        }
    }
}

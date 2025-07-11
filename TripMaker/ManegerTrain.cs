﻿using System;
using System.Data;
using System.Windows.Forms;

namespace TripMaker
{
    public partial class ManegerTrain : MetroFramework.Forms.MetroForm
    {
        public ManegerTrain()
        {
            InitializeComponent();
        }

        private void loadgrid()
        {
            string error;
            try
            {
                string query = @"SELECT Transport_Id AS train_id,
                                Transport_Name AS train_company,
                                TO_CHAR(Departure_Time, 'YYYY-MM-DD HH24:MI') AS departure_time,
                                TO_CHAR(Arrival_Time, 'YYYY-MM-DD HH24:MI') AS arrival_time,
                                From_Location AS From_Location,
                                To_Location AS To_Location,
                                SEAT_CAPACITY AS seat_cap,
                                Type AS train_type,
                                Price
                         FROM Transport
                         WHERE Type = 'Train'";

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

        private void ManegerTrain_Load(object sender, EventArgs e)
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.loadgrid();
            this.newdata();
        }

        private void loaddetail(string id)
        {
            string error;
            try
            {
                string query = $@"SELECT Transport_Id AS train_id,
                                         Transport_Name AS train_name,
                                         TO_CHAR(Departure_Time, 'YYYY-MM-DD HH24:MI') AS departure_time,
                                         TO_CHAR(Arrival_Time, 'YYYY-MM-DD HH24:MI') AS arrival_time,
                                         From_Location AS From_Location,
                                         To_Location AS To_Location,
                                         SEAT_CAPACITY AS seat_cap,
                                         Type AS train_type,
                                         Price
                                  FROM Transport
                                  WHERE Transport_Id = {id}";

                DataTable dt = DataAccess.GetData(query, out error);
                if (!string.IsNullOrEmpty(error))
                {
                    MessageBox.Show(error);
                    return;
                }

                if (dt.Rows.Count > 0)
                {
                    txtid.Text = dt.Rows[0]["train_id"].ToString();
                    txtName.Text = dt.Rows[0]["train_name"].ToString();
                    txtdt.Text = dt.Rows[0]["departure_time"].ToString();
                    txtat.Text = dt.Rows[0]["arrival_time"].ToString();
                    txtbt.Text = dt.Rows[0]["seat_cap"].ToString();
                    txtds.Text = dt.Rows[0]["From_Location"].ToString();
                    txtas.Text = dt.Rows[0]["To_Location"].ToString();
                    txtprice.Text = dt.Rows[0]["price"].ToString();
                    txtid.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string error;
            try
            {
                if (string.IsNullOrEmpty(txtid.Text))
                {
                    MessageBox.Show("Please Select A Row");
                    return;
                }

                var msg = MessageBox.Show("Are You Sure?", "Confirmation", MessageBoxButtons.YesNo);
                if (msg == DialogResult.Yes)
                {
                    string query = $"DELETE FROM Transport WHERE Transport_Id = {txtid.Text}";

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            string id = txtid.Text;
            string tname = txtName.Text;
            string dt = txtdt.Text;
            string at = txtat.Text;
            string fl = txtds.Text;
            string tl = txtas.Text;
            string bt = txtbt.Text;
            string price = txtprice.Text;
            string error = "";

            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    // INSERT
                    string q = $@"
                    INSERT INTO Transport (Transport_Id, Transport_Name, Type, Seat_Capacity, Departure_Time, Arrival_Time, Price, Admin_Id, From_Location, To_Location)
                    VALUES (
                    seq_Transport.NEXTVAL,
                    '{tname}',
                    'Train',
                    {bt},
                    TO_DATE('{dt}', 'YYYY-MM-DD HH24:MI'),
                    TO_DATE('{at}', 'YYYY-MM-DD HH24:MI'),
                    {price},
                    (SELECT Admin_Id FROM Admin WHERE Admin_Username = '{Session.LoggedInUsername}'),
                    '{fl}',
                    '{tl}'
                    )";

                    DataAccess.ExecuteData(q, out error);
                    if (!string.IsNullOrEmpty(error))
                    {
                        MessageBox.Show(error);
                        return;
                    }
                    MessageBox.Show("Train added successfully");
                }
                else
                {
                    // UPDATE
                    string q = $@"
                    UPDATE Transport
                    SET Transport_Name = '{tname}',
                        Departure_Time = TO_DATE('{dt}', 'YYYY-MM-DD HH24:MI'),
                        Arrival_Time = TO_DATE('{at}', 'YYYY-MM-DD HH24:MI'),
                        From_Location='{dt}',To_Location='{tl}',
                        Seat_Capacity={bt},
                        Price = {price}
                    WHERE Transport_Id = {id}";

                    DataAccess.ExecuteData(q, out error);
                    if (!string.IsNullOrEmpty(error))
                    {
                        MessageBox.Show(error);
                        return;
                    }

                    MessageBox.Show("Train updated successfully");
                }

                this.loadgrid();
                this.newdata();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected Error: " + ex.Message);
            }
        }

        private void newdata()
        {
            txtid.Text = "";
            txtName.Text = "";
            txtdt.Text = "";
            txtat.Text = "";
            txtbt.Text = "";
            txtds.Text = "";
            txtas.Text = "";
            txtprice.Text = "";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminHome obj = new AdminHome();
            obj.Show();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            btnSave_Click(sender, e);
        }
    }
}

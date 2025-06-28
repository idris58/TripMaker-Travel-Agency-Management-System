using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace TripMaker
{
    public partial class ManageHotelRooms : MetroFramework.Forms.MetroForm
    {
        public ManageHotelRooms()
        {
            InitializeComponent();
        }

        private void ManageHotelRooms_Load(object sender, EventArgs e)
        {
            LoadRooms();

            try
            {
                using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                {
                    con.Open();
                    var query = "SELECT * FROM Hotel";
                    using (OracleCommand cmd = new OracleCommand(query, con))
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbHotel.Items.Add(reader.GetString(reader.GetOrdinal("Hotel_Name")));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading hotels: " + ex.Message);
            }
        }

        private void LoadRooms()
        {
            try
            {
                using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                {
                    con.Open();
                    string query = "SELECT * FROM Room";
                    using (OracleDataAdapter adapter = new OracleDataAdapter(query, con))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvManageHotelRooms.AutoGenerateColumns = false;
                        dgvManageHotelRooms.DataSource = dt;
                        dgvManageHotelRooms.Refresh();
                        dgvManageHotelRooms.ClearSelection();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading rooms: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadRooms();
            newData();
        }

        private void dgvManageHotelRooms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string id = dgvManageHotelRooms.Rows[e.RowIndex].Cells[0].Value.ToString();
                LoadDetails(id);
            }
        }

        private void LoadDetails(string id)
        {
            try
            {
                using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                {
                    con.Open();
                    string query = "SELECT * FROM Room WHERE Room_Id = :id";
                    using (OracleCommand cmd = new OracleCommand(query, con))
                    {
                        cmd.Parameters.Add("id", OracleDbType.Int32).Value = int.Parse(id);
                        using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                txtId.Text = dt.Rows[0]["Room_Id"].ToString();
                                txtPrice.Text = dt.Rows[0]["Price"].ToString();
                                txtRoomType.Text = "-";
                                txtGuest.Text = "-";
                                txtHotelid.Text = dt.Rows[0]["Hotel_Id"].ToString();
                                rbBreakfastYes.Checked = false;
                                rbBreakfastNo.Checked = false;
                                rbLunchYes.Checked = false;
                                rbLunchNo.Checked = false;
                                rbDinnerYes.Checked = false;
                                rbDinnerNo.Checked = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading room details: " + ex.Message);
            }
        }

        private void newData()
        {
            txtId.Text = "";
            txtPrice.Text = "";
            txtRoomType.Text = "";
            txtGuest.Text = "";
            txtHotelid.Text = "";
            rbLunchYes.Checked = false;
            rbLunchNo.Checked = false;
            rbBreakfastYes.Checked = false;
            rbBreakfastNo.Checked = false;
            rbDinnerYes.Checked = false;
            rbDinnerNo.Checked = false;
            dgvManageHotelRooms.Refresh();
            dgvManageHotelRooms.ClearSelection();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            newData();
            LoadRooms();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Please select a row");
                return;
            }

            if (MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                    {
                        con.Open();
                        string query = "DELETE FROM Room WHERE Room_Id = :id";
                        using (OracleCommand cmd = new OracleCommand(query, con))
                        {
                            cmd.Parameters.Add("id", OracleDbType.Int32).Value = int.Parse(txtId.Text);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    LoadRooms();
                    newData();
                    MessageBox.Show("Deleted");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting room: " + ex.Message);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string room_id = txtId.Text;
            string price = txtPrice.Text;
            string hotel_id = txtHotelid.Text;
            string breakfast = rbBreakfastYes.Checked ? "Yes" : "No";
            string lunch = rbLunchYes.Checked ? "Yes" : "No";
            string dinner = rbDinnerYes.Checked ? "Yes" : "No";
            string normal = txtRoomType.Text == "Normal" ? "Yes" : "No";
            string deluxe = txtRoomType.Text == "Deluxe" ? "Yes" : "No";
            string superDeluxe = txtRoomType.Text == "Super Deluxe" ? "Yes" : "No";

            try
            {
                using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                {
                    con.Open();

                    string query;
                    if (string.IsNullOrEmpty(room_id))
                    {
                        query = "INSERT INTO Room (Room_Id, Normal, Super_Deluxe, Deluxe, Availability, Price, Hotel_Id) VALUES (seq_Room.NEXTVAL, :normal, :superDeluxe, :deluxe, 'Available', :price, :hotelId)";
                    }
                    else
                    {
                        query = "UPDATE Room SET Normal = :normal, Super_Deluxe = :superDeluxe, Deluxe = :deluxe, Price = :price, Hotel_Id = :hotelId WHERE Room_Id = :id";
                    }

                    using (OracleCommand cmd = new OracleCommand(query, con))
                    {
                        cmd.Parameters.Add("normal", OracleDbType.Varchar2).Value = normal;
                        cmd.Parameters.Add("superDeluxe", OracleDbType.Varchar2).Value = superDeluxe;
                        cmd.Parameters.Add("deluxe", OracleDbType.Varchar2).Value = deluxe;
                        cmd.Parameters.Add("price", OracleDbType.Int32).Value = int.Parse(price);
                        cmd.Parameters.Add("hotelId", OracleDbType.Int32).Value = int.Parse(hotel_id);

                        if (!string.IsNullOrEmpty(room_id))
                        {
                            cmd.Parameters.Add("id", OracleDbType.Int32).Value = int.Parse(room_id);
                        }

                        cmd.ExecuteNonQuery();
                    }
                }

                newData();
                LoadRooms();
                MessageBox.Show("Successfully saved");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving room: " + ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminHome obj = new AdminHome();
            obj.Show();
        }

        private void ManageHotelRooms_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            AdminHome obj = new AdminHome();
            obj.Show();
        }

        private void cmbHotel_SelectedIndexChanged(object sender, EventArgs e)
        {
            string hotel = cmbHotel.SelectedItem.ToString();
            try
            {
                using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                {
                    con.Open();
                    string query = "SELECT Hotel_Id FROM Hotel WHERE Hotel_Name = :hotel";
                    using (OracleCommand cmd = new OracleCommand(query, con))
                    {
                        cmd.Parameters.Add("hotel", OracleDbType.Varchar2).Value = hotel;
                        txtHotelid.Text = cmd.ExecuteScalar()?.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading hotel id: " + ex.Message);
            }
        }

        private void dgvManageHotelRooms_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}

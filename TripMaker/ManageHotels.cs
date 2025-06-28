using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace TripMaker
{
    public partial class ManageHotels : MetroFramework.Forms.MetroForm
    {
        public ManageHotels()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminHome obj = new AdminHome();
            obj.Show();
        }

        private void ManageHotels_Load(object sender, EventArgs e)
        {
            LoadHotels();

            cmbDestination.Items.Clear();

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
        }

        private void LoadHotels()
        {
            try
            {
                using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                {
                    con.Open();
                    string query = "SELECT * FROM Hotel";
                    using (OracleDataAdapter adapter = new OracleDataAdapter(query, con))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvManageHotels.AutoGenerateColumns = false;
                        dgvManageHotels.DataSource = dt;
                        dgvManageHotels.Refresh();
                        dgvManageHotels.ClearSelection();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading hotels: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadHotels();
            newData();
        }

        private void newData()
        {
            txtId.Text = "";
            txtHotelName.Text = "";
            txtDestination.Text = "";
            dgvManageHotels.Refresh();
            dgvManageHotels.ClearSelection();
        }

        private void dgvManageHotels_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string id = dgvManageHotels.Rows[e.RowIndex].Cells[0].Value.ToString();
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
                    string query = "SELECT * FROM Hotel WHERE Hotel_Id = :id";
                    using (OracleCommand cmd = new OracleCommand(query, con))
                    {
                        cmd.Parameters.Add("id", OracleDbType.Int32).Value = int.Parse(id);
                        using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                txtId.Text = dt.Rows[0]["Hotel_Id"].ToString();
                                txtHotelName.Text = dt.Rows[0]["Hotel_Name"].ToString();
                                txtDestination.Text = dt.Rows[0]["Location"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading hotel details: " + ex.Message);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            LoadHotels();
            newData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Please select a row");
                return;
            }

            var result = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;

            try
            {
                using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                {
                    con.Open();
                    string query = "DELETE FROM Hotel WHERE Hotel_Id = :id";
                    using (OracleCommand cmd = new OracleCommand(query, con))
                    {
                        cmd.Parameters.Add("id", OracleDbType.Int32).Value = int.Parse(txtId.Text);
                        cmd.ExecuteNonQuery();
                    }
                }

                LoadHotels();
                newData();
                MessageBox.Show("Deleted");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting hotel: " + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string hotel_id = txtId.Text;
            string hotel_name = txtHotelName.Text;
            string location = txtDestination.Text;
            int admin_id = 1; // you can adjust this value accordingly

            if (string.IsNullOrEmpty(hotel_name) || string.IsNullOrEmpty(location))
            {
                MessageBox.Show("Hotel name and location are required.");
                return;
            }

            try
            {
                using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                {
                    con.Open();
                    string query = string.IsNullOrEmpty(hotel_id) ?
                        "INSERT INTO Hotel (Hotel_Id, Hotel_Name, Location, Admin_Id) VALUES (seq_Hotel.NEXTVAL, :name, :location, :adminId)" :
                        "UPDATE Hotel SET Hotel_Name = :name, Location = :location, Admin_Id = :adminId WHERE Hotel_Id = :id";

                    using (OracleCommand cmd = new OracleCommand(query, con))
                    {
                        cmd.Parameters.Add("name", OracleDbType.Varchar2).Value = hotel_name;
                        cmd.Parameters.Add("location", OracleDbType.Varchar2).Value = location;
                        cmd.Parameters.Add("adminId", OracleDbType.Int32).Value = admin_id;

                        if (!string.IsNullOrEmpty(hotel_id))
                        {
                            cmd.Parameters.Add("id", OracleDbType.Int32).Value = int.Parse(hotel_id);
                        }

                        cmd.ExecuteNonQuery();
                    }
                }

                newData();
                LoadHotels();
                MessageBox.Show("Successfully saved");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving hotel: " + ex.Message);
            }
        }

        private void cmbDestination_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDestination.Text = cmbDestination.SelectedItem.ToString();
        }
    }
}

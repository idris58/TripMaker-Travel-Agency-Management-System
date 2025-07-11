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
        private void ManageHotels_Load(object sender, EventArgs e)
        {
            this.LoadGrid();
        }
        private void LoadGrid()
        {
            string error;
            try
            {
                string query = @"SELECT Hotel_Id AS hotel_id,
                                        Hotel_Name AS hotel_name,
                                        Location
                                 FROM Hotel";

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
        private void metroGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var cellValue = metroGrid.Rows[e.RowIndex].Cells[0].Value;
                if (cellValue != null)
                {
                    string id = cellValue.ToString();
                    this.LoadDetails(id);
                }
            }
        }
        private void LoadDetails(string id)
        {
            string error;
            try
            {
                string query = $@"SELECT Hotel_Id AS hotel_id,
                                        Hotel_Name AS hotel_name,
                                        Location
                                 FROM Hotel
                                 WHERE Hotel_Id = {id}";

                DataTable dt = DataAccess.GetData(query, out error);
                if (!string.IsNullOrEmpty(error))
                {
                    MessageBox.Show(error);
                    return;
                }

                if (dt.Rows.Count > 0)
                {
                    txtId.Text = dt.Rows[0]["hotel_id"].ToString();
                    txtHotelName.Text = dt.Rows[0]["hotel_name"].ToString();
                    txtLocation.Text = dt.Rows[0]["Location"].ToString();
                    txtId.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.LoadGrid();
            this.ClearForm();

        }
        


        private void btnDelete_Click(object sender, EventArgs e)
        {
            string error;
            try
            {
                if (string.IsNullOrEmpty(txtId.Text))
                {
                    MessageBox.Show("Please Select A Row");
                    return;
                }

                var msg = MessageBox.Show("Are You Sure?", "Confirmation", MessageBoxButtons.YesNo);
                if (msg == DialogResult.Yes)
                {
                    string query = $"DELETE FROM Hotel WHERE Hotel_Id = {txtId.Text}";

                    DataAccess.ExecuteData(query, out error);
                    if (!string.IsNullOrEmpty(error))
                    {
                        MessageBox.Show(error);
                        return;
                    }

                    this.LoadGrid();
                    this.ClearForm();
                    MessageBox.Show("Deleted");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            btnSave_Click(sender, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;
            string name = txtHotelName.Text;
            string location = txtLocation.Text;
            string error = "";

            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    string query = @"
                    INSERT INTO Hotel (Hotel_Id, Hotel_Name, Location, Admin_Id)
                    VALUES (
                        seq_Hotel.NEXTVAL,
                        :name,
                        :location,
                        (SELECT Admin_Id FROM Admin WHERE Admin_Username = :username)
                    )";

                    OracleParameter[] parameters = new OracleParameter[]
                    {
                        new OracleParameter("name", name),
                        new OracleParameter("location", location),
                        new OracleParameter("username", Session.LoggedInUsername)
                    };

                    DataAccess.ExecuteData(query, parameters, out error);

                    if (!string.IsNullOrEmpty(error))
                    {
                        MessageBox.Show(error);
                        return;
                    }
                    MessageBox.Show("Hotel added successfully");
                }
                else
                {
                    string query = $@"
                        UPDATE Hotel
                        SET Hotel_Name = '{name}',
                            Location = '{location}'
                        WHERE Hotel_Id = {id}";

                    DataAccess.ExecuteData(query, out error);
                    if (!string.IsNullOrEmpty(error))
                    {
                        MessageBox.Show(error);
                        return;
                    }

                    MessageBox.Show("Hotel updated successfully");
                }

                this.LoadGrid();
                this.ClearForm();
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

        private void ClearForm()
        {
            txtId.Text = "";
            txtHotelName.Text = "";
            txtLocation.Text = "";
        }


    }

    
 }


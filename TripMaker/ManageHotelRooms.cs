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
            this.FormClosing += AdminForm_FormClosing;
        }
        private void LoadGrid()
        {
            string error;
            try
            {
                string query = @"SELECT Room_Id,
                                        Normal,
                                        Super_Deluxe,
                                        Deluxe,
                                        Availability,
                                        Price,
                                        Hotel_Id
                                 FROM Room";

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
        private void ManageHotelRooms_Load(object sender, EventArgs e)
        {
            cmbRoomType.Items.Clear();
            cmbRoomType.Items.Add("Normal");
            cmbRoomType.Items.Add("Deluxe");
            cmbRoomType.Items.Add("Super_Deluxe");
            cmbRoomType.SelectedIndex = -1;

            this.LoadGrid();
        }
        private void metroGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string id = metroGrid.Rows[e.RowIndex].Cells[0].Value.ToString();
                LoadDetails(id);
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadGrid();
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
            string error;
            try
            {
                string query = $@"SELECT Room_Id,
                                         Normal,
                                         Super_Deluxe,
                                         Deluxe,
                                         Availability,
                                         Price,
                                         Hotel_Id
                                  FROM Room
                                  WHERE Room_Id = {id}";

                DataTable dt = DataAccess.GetData(query, out error);
                if (!string.IsNullOrEmpty(error))
                {
                    MessageBox.Show(error);
                    return;
                }

                if (dt.Rows.Count > 0)
                {
                    textId.Text = dt.Rows[0]["Room_Id"].ToString();
                    cmbRoomType.SelectedItem = dt.Rows[0]["Normal"].ToString() == "Yes" ? "Normal" : dt.Rows[0]["Deluxe"].ToString() == "Yes" ? "Deluxe" : "Super_Deluxe";
                    txtdt.Text = dt.Rows[0]["Availability"].ToString();
                    txtPrice.Text = dt.Rows[0]["Price"].ToString();
                    txthid.Text = dt.Rows[0]["Hotel_Id"].ToString();
                    txthid.Enabled = false; // Disable Hotel ID on edit
                    textId.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnRefresh1_Click(object sender, EventArgs e)
        {
            LoadGrid();
            newData();
        }
        private void btnDelete1_Click(object sender, EventArgs e)
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
                    string query = $"DELETE FROM Room WHERE Room_Id = {txtId.Text}";

                    DataAccess.ExecuteData(query, out error);
                    if (!string.IsNullOrEmpty(error))
                    {
                        MessageBox.Show(error);
                        return;
                    }

                    LoadGrid();
                    newData();
                    MessageBox.Show("Deleted");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       



        private void btnSave1_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;
            string availability = txtdt.Text;
            string price = txtPrice.Text;
            string hotelId = txthid.Text;
            string roomType = cmbRoomType.SelectedItem?.ToString();
            string normal = "No", deluxe = "No", superDeluxe = "No";
            string error = "";

            if (roomType == "Normal") normal = "Yes";
            else if (roomType == "Deluxe") deluxe = "Yes";
            else if (roomType == "Super_Deluxe") superDeluxe = "Yes";

            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    string query = $@"
                        INSERT INTO Room (Room_Id, Normal, Super_Deluxe, Deluxe, Availability, Price, Hotel_Id)
                        VALUES (seq_Room.NEXTVAL, '{normal}', '{superDeluxe}', '{deluxe}', '{availability}', {price}, {hotelId})";

                    DataAccess.ExecuteData(query, out error);
                    if (!string.IsNullOrEmpty(error))
                    {
                        MessageBox.Show(error);
                        return;
                    }
                    MessageBox.Show("Room added successfully");
                }
                else
                {
                    string query = $@"
                        UPDATE Room
                        SET Normal = '{normal}',
                            Super_Deluxe = '{superDeluxe}',
                            Deluxe = '{deluxe}',
                            Availability = '{availability}',
                            Price = {price}
                        WHERE Room_Id = {id}";

                    DataAccess.ExecuteData(query, out error);
                    if (!string.IsNullOrEmpty(error))
                    {
                        MessageBox.Show(error);
                        return;
                    }
                    MessageBox.Show("Room updated successfully");
                }

                LoadGrid();
                newData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected Error: " + ex.Message);
            }
        }
        private void btnNew1_Click(object sender, EventArgs e)
        {
            btnSave1_Click(sender, e);
        }
        private void newData()
        {
            txtId.Text = "";
            txtdt.Text = "";
            txtPrice.Text = "";
            txthid.Text = "";
            cmbRoomType.SelectedIndex = -1;
            txthid.Enabled = true; // Enable Hotel ID only for new insert
        }
       
        private void btnBack1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminHome obj = new AdminHome();
            obj.Show();
        }

        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }
    }
}

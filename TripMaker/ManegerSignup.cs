using Oracle.ManagedDataAccess.Client;
using System;
using System.Configuration;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace TripMaker
{
    public partial class ManegerSignup : MetroFramework.Forms.MetroForm
    {
        public ManegerSignup()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void btnAddAdmin_Click(object sender, EventArgs e)
        {
            pnlAddAdmin.Visible = true;
            pnlAddAdmin.BringToFront();
            pnlAddCustomer.Visible = false;
            btnAddCustomer.Visible = true;
            ClearAdminFields();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            pnlAddCustomer.Visible = true;
            pnlAddCustomer.BringToFront();
            pnlAddAdmin.Visible = false;
            btnAddAdmin.Visible = true;
            ClearCustomerFields();
        }

        private void btnASave_Click(object sender, EventArgs e)
        {
            string name = txtAName.Text.Trim();
            string uname = txtAUName.Text.Trim();
            string pass = txtAPass.Text.Trim();
            string email = txtAemail.Text.Trim();
            string Agender = rdbAMale.Checked ? "Male" : rdbAFemale.Checked ? "Female" : "";

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(uname) || string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Fill all admin fields.");
                return;
            }

            string error;
            string checkQuery = $"SELECT COUNT(*) FROM Admin WHERE Admin_Username = '{uname}'";
            object exists = DataAccess.GetSingleValue(checkQuery, out error);
            if (!string.IsNullOrEmpty(error)) { MessageBox.Show(error); return; }
            if (Convert.ToInt32(exists) > 0)
            {
                string updateQuery = $"UPDATE Admin SET Admin_Name='{name}', Password='{pass}', Email='{email}', Gender='{Agender}' WHERE Admin_Username='{uname}'";
                DataAccess.ExecuteData(updateQuery, out error);
                MessageBox.Show(string.IsNullOrEmpty(error) ? "Admin updated successfully." : error);
            }
            else
            {
                string insertQuery = $"INSERT INTO Admin (Admin_ID, Admin_Name, Admin_Username, Password, Email,Gender, User_Type) VALUES (seq_Admin.NEXTVAL, '{name}', '{uname}', '{pass}', '{email}','{Agender}', 'Admin')";
                DataAccess.ExecuteData(insertQuery, out error);
                MessageBox.Show(string.IsNullOrEmpty(error) ? "Admin added successfully." : error);
            }

            LoadUsers();
            ClearAdminFields();
        }

        private void btnCSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string uname = txtUName.Text.Trim();
            string pass = txtPass.Text.Trim();
            string email = txtemail.Text.Trim();
            string phone = txtpn.Text.Trim();
            string gender = rdbMale.Checked ? "Male" : rdbFemale.Checked ? "Female" : "";
            string addressRaw = txtAddress.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(uname) || string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(addressRaw))
            {
                MessageBox.Show("Fill all customer fields.");
                return;
            }

            string[] parts = addressRaw.Split(',');
            if (parts.Length != 3)
            {
                MessageBox.Show("Address must be in format: Street, City, Country.");
                return;
            }

            string street = parts[0].Trim();
            string city = parts[1].Trim();
            string country = parts[2].Trim();

            string error = "";
            string getAid = "SELECT seq_Address.NEXTVAL FROM dual";
            object result = DataAccess.GetSingleValue(getAid, out error);
            if (!string.IsNullOrEmpty(error) || result == null) { MessageBox.Show(error ?? "Failed to get A_ID"); return; }
            int aid = Convert.ToInt32(result);

            string insertAddress = $"INSERT INTO Address (A_ID, Street, City, Country) VALUES ({aid}, '{street}', '{city}', '{country}')";
            DataAccess.ExecuteData(insertAddress, out error);
            if (!string.IsNullOrEmpty(error)) { MessageBox.Show(error); return; }

            string checkQuery = $"SELECT COUNT(*) FROM Customer WHERE C_Username = '{uname}'";
            object exists = DataAccess.GetSingleValue(checkQuery, out error);
            if (!string.IsNullOrEmpty(error)) { MessageBox.Show(error); return; }

            if (Convert.ToInt32(exists) > 0)
            {
                string updateQuery = $"UPDATE Customer SET Name='{name}', Password='{pass}', Email='{email}', Phone='{phone}', Gender='{gender}', A_ID={aid} WHERE C_Username='{uname}'";
                DataAccess.ExecuteData(updateQuery, out error);
                MessageBox.Show(string.IsNullOrEmpty(error) ? "Customer updated successfully." : error);
            }
            else
            {
                string query = $"INSERT INTO Customer (Name, C_Username, Password, Email, Phone, Gender, A_ID, Admin_ID, Profile_Image) VALUES ('{name}', '{uname}', '{pass}', '{email}', '{phone}', '{gender}', {aid}, (SELECT Admin_Id FROM Admin WHERE Admin_Username = '{Session.LoggedInUsername}'), NULL)";
                DataAccess.ExecuteData(query, out error);
                MessageBox.Show(string.IsNullOrEmpty(error) ? "Customer added successfully." : error);
            }

            LoadUsers();
            ClearCustomerFields();
        }

        private void LoadUsers()
        {
            string query = @"SELECT Admin_ID AS ID, 
                            Admin_Name AS Name, 
                            Admin_Username AS Username, 
                            Email, 
                            Password,Gender, 
                            'Admin' AS Type 
                     FROM Admin
                     UNION
                     SELECT NULL AS ID, 
                            Name, 
                            C_Username AS Username, 
                            Email, 
                            Password,Gender, 
                            'Customer' AS Type 
                     FROM Customer";

            string error;
            metroGrid.DataSource = DataAccess.GetData(query, out error);
            if (!string.IsNullOrEmpty(error))
                MessageBox.Show(error);
        }


        private void metroGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string uname = metroGrid.Rows[e.RowIndex].Cells[2].Value.ToString();
                string type = metroGrid.Rows[e.RowIndex].Cells[6].Value.ToString();
                string error;

                if (type == "Admin")
                {
                    pnlAddAdmin.Visible = true;
                    pnlAddCustomer.Visible = false;

                    string q = $"SELECT * FROM Admin WHERE Admin_Username = '{uname}'";
                    DataTable dt = DataAccess.GetData(q, out error);
                    if (dt.Rows.Count > 0)
                    {
                        txtAName.Text = dt.Rows[0]["Admin_Name"].ToString();
                        txtAUName.Text = dt.Rows[0]["Admin_Username"].ToString();
                        txtAPass.Text = dt.Rows[0]["Password"].ToString();
                        txtAemail.Text = dt.Rows[0]["Email"].ToString();
                        string Agender = dt.Rows[0]["Gender"].ToString();
                        rdbAMale.Checked = Agender == "Male";
                        rdbAFemale.Checked = Agender == "Female";
                        txtAUName.Enabled = false; // Disable username field for Admin
                    }
                }
                else
                {
                    pnlAddCustomer.Visible = true;
                    pnlAddAdmin.Visible = false;

                    string q = $@"SELECT c.*, a.Street || ', ' || a.City || ', ' || a.Country AS FullAddress
                                FROM Customer c
                                JOIN Address a ON c.A_ID = a.A_ID
                                WHERE C_Username = '{uname}'";

                    DataTable dt = DataAccess.GetData(q, out error);
                    if (dt.Rows.Count > 0)
                    {
                        txtName.Text = dt.Rows[0]["Name"].ToString();
                        txtUName.Text = dt.Rows[0]["C_Username"].ToString();
                        txtPass.Text = dt.Rows[0]["Password"].ToString();
                        txtemail.Text = dt.Rows[0]["Email"].ToString();
                        txtpn.Text = dt.Rows[0]["Phone"].ToString();
                        txtAddress.Text = dt.Rows[0]["FullAddress"].ToString();
                        string gender = dt.Rows[0]["Gender"].ToString();
                        rdbMale.Checked = gender == "Male";
                        rdbFemale.Checked = gender == "Female";
                        txtUName.Enabled = false; // Disable username field for Customer
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (metroGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to delete.");
                return;
            }

            var type = metroGrid.SelectedRows[0].Cells[6].Value.ToString();
            var uname = metroGrid.SelectedRows[0].Cells[2].Value.ToString();
            var confirm = MessageBox.Show("Are you sure you want to delete this user?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;

            string query = type == "Admin"
                ? $"DELETE FROM Admin WHERE Admin_Username = '{uname}'"
                : $"DELETE FROM Customer WHERE C_Username = '{uname}'";

            string error;
            DataAccess.ExecuteData(query, out error);
            if (!string.IsNullOrEmpty(error)) MessageBox.Show(error);
            else
            {
                MessageBox.Show("Deleted successfully.");
                LoadUsers();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadUsers();
            ClearAdminFields();
            ClearCustomerFields();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AdminHome().Show();
        }

        private void ClearCustomerFields()
        {
            txtName.Text = txtUName.Text = txtPass.Text = txtemail.Text = txtpn.Text = txtAddress.Text = "";
            rdbMale.Checked = rdbFemale.Checked = false;
        }

        private void ClearAdminFields()
        {
            txtAName.Text = txtAUName.Text = txtAPass.Text = txtAemail.Text = "";
            rdbAMale.Checked = rdbAFemale.Checked = false;
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TripMaker
{
    public partial class ManegerActivity : MetroFramework.Forms.MetroForm
    {
        public ManegerActivity()
        {
            InitializeComponent();
            this.FormClosing += AdminForm_FormClosing;
        }
        private void loadgrid()
        {
            string error;
            try
            {
                string query = @"SELECT Activity_Id AS activity_id,
                                        Activity_Name AS activity_name,
                                        Category,
                                        Location,
                                        Price
                                 FROM Activity";

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
        private void metroGrid_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string id = metroGrid.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.loaddetail(id);
            }
        }

        private void ManegerActivity_Load_1(object sender, EventArgs e)
        {
            this.loadgrid();
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
                string query = $@"SELECT Activity_Id AS activity_id,
                                        Activity_Name AS activity_name,
                                        Category,
                                        Location,
                                        Price
                                 FROM Activity
                                 WHERE Activity_Id = {id}";

                DataTable dt = DataAccess.GetData(query, out error);
                if (!string.IsNullOrEmpty(error))
                {
                    MessageBox.Show(error);
                    return;
                }

                if (dt.Rows.Count > 0)
                {
                    txtid.Text = dt.Rows[0]["activity_id"].ToString();
                    txtName.Text = dt.Rows[0]["activity_name"].ToString();
                    txtds.Text = dt.Rows[0]["Category"].ToString();
                    txtas.Text = dt.Rows[0]["Location"].ToString();
                    txtprice.Text = dt.Rows[0]["Price"].ToString();
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
                    string query = $"DELETE FROM Activity WHERE Activity_Id = {txtid.Text}";

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
            string name = txtName.Text;
            string cat = txtds.Text;
            string loc = txtas.Text;
            string price = txtprice.Text;
            string error = "";

            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    string q = $@"
                        INSERT INTO Activity (Activity_Id, Activity_Name, Category, Location, Price, Admin_Id)
                        VALUES (seq_Activity.NEXTVAL, '{name}', '{cat}', '{loc}', {price}, (SELECT Admin_Id FROM Admin WHERE Admin_Username = '{Session.LoggedInUsername}'))";

                    DataAccess.ExecuteData(q, out error);
                    if (!string.IsNullOrEmpty(error))
                    {
                        MessageBox.Show(error);
                        return;
                    }
                    MessageBox.Show("Activity added successfully");
                }
                else
                {
                    string q = $@"
                        UPDATE Activity
                        SET Activity_Name = '{name}',
                            Category = '{cat}',
                            Location = '{loc}',
                            Price = {price}
                        WHERE Activity_Id = {id}";

                    DataAccess.ExecuteData(q, out error);
                    if (!string.IsNullOrEmpty(error))
                    {
                        MessageBox.Show(error);
                        return;
                    }

                    MessageBox.Show("Activity updated successfully");
                }

                this.loadgrid();
                this.newdata();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected Error: " + ex.Message);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            btnSave_Click(sender, e);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminHome obj = new AdminHome();
            obj.Show();

        }
        private void newdata()
        {
            txtid.Text = "";
            txtName.Text = "";
            txtds.Text = "";
            txtas.Text = "";
            txtprice.Text = "";
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

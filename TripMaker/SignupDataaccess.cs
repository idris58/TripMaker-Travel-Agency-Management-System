using System;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace TripMaker
{
    public class SignupDataaccess
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        public bool RegisterCustomer(string name, string username, string password, string email, string phone, string gender, int addressId, int adminId)
        {
            try
            {
                using (OracleConnection con = new OracleConnection(connectionString))
                {
                    con.Open();

                    string query = @"INSERT INTO Customer 
                    (Name, C_Username, Password, Email, Phone, Gender, A_ID, Admin_ID) 
                    VALUES (:name, :username, :password, :email, :phone, :gender, :addressId, :adminId)";

                    using (OracleCommand cmd = new OracleCommand(query, con))
                    {
                        cmd.Parameters.Add("name", OracleDbType.Varchar2).Value = name;
                        cmd.Parameters.Add("username", OracleDbType.Varchar2).Value = username;
                        cmd.Parameters.Add("password", OracleDbType.Varchar2).Value = password;
                        cmd.Parameters.Add("email", OracleDbType.Varchar2).Value = email;
                        cmd.Parameters.Add("phone", OracleDbType.Varchar2).Value = phone;
                        cmd.Parameters.Add("gender", OracleDbType.Varchar2).Value = gender;
                        cmd.Parameters.Add("addressId", OracleDbType.Int32).Value = addressId;
                        cmd.Parameters.Add("adminId", OracleDbType.Int32).Value = adminId;

                        int rowsInserted = cmd.ExecuteNonQuery();
                        return rowsInserted > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Optional: log the error
                System.Windows.Forms.MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }
    }
}

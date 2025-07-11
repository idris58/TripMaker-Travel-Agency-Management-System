using Oracle.ManagedDataAccess.Client;
using System;
using System.Configuration;
using System.Data;

namespace TripMaker
{
    static class DataAccess
    {
        // Executes a non-query SQL command (INSERT, UPDATE, DELETE)
        public static void ExecuteData(string query, OracleParameter[] parameters, out string error)
        {
            error = "";
            try
            {
                using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                {
                    con.Open();
                    using (OracleCommand cmd = new OracleCommand(query, con))
                    {
                        cmd.BindByName = true; // Ensure parameters match by name
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
        }
        // Overload for simple ExecuteData calls without parameters
        public static void ExecuteData(string query, out string error)
        {
            ExecuteData(query, null, out error);
        }

        // Executes a SELECT query and returns a DataTable
        public static DataTable GetData(string query, OracleParameter[] parameters, out string error)
        {
            error = "";
            DataTable dt = new DataTable();

            try
            {
                using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                {
                    con.Open();
                    using (OracleCommand cmd = new OracleCommand(query, con))
                    {
                        cmd.BindByName = true; // Fix parameter binding
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }

                        using (OracleDataAdapter da = new OracleDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return dt;
        }

        // Overload for simple GetData calls without parameters
        public static DataTable GetData(string query, out string error)
        {
            return GetData(query, null, out error);
        }

        public static object GetSingleValue(string query, out string error)
        {
            error = "";
            try
            {
                using (var con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                {
                    con.Open();
                    using (var cmd = new OracleCommand(query, con))
                    {
                        return cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return null;
            }
        }
    }

}
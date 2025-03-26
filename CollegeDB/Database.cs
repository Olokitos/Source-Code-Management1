using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace CollegeDB
{
    public class Database
    {
        private string connectionString = "server=localhost;database=CollegeDB;user=root;password=123456789;";

        public void ExecuteQuery(string query, params MySqlParameter[] parameters)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable GetDataTable(string query, params MySqlParameter[] parameters)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }
}

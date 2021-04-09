using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Data.SqlClient;

namespace AlutechShopDiploma.SQL
{
    public class SqlWorker
    {
        private string connectionString;
        public SqlWorker(string userConnectionString)
        {
            this.connectionString = userConnectionString;
        }
        public string SelectDataFromDB(string query)
        {
            string data = "";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        data += reader.GetValue(0) + "";
                    }
                    reader.Close();
                }
            }
            return data;
        }

        public List<string> SelectDataFromDBMult(string query)
        {
            List<string> data = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        data.Add(Convert.ToString(reader.GetValue(0)));
                    }
                    reader.Close();
                }
            }
            return data;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDB
{
    internal class SQL
    {
        private const string connection = "server=DESKTOP-RLSUGQE\\SQLEXPRESS;database=INFOBP217;trusted_connection=true;integrated security=true";
        private static SqlConnection conn = new SqlConnection(connection);


        public int ExecuteCommant(string commant)
        {
            int result = 0;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(commant, conn);
                result = cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        public DataTable ExecuteQuery(string query)
        {
            DataTable table = new DataTable();

            try
            {
                conn.Open();
                SqlDataAdapter adapter =new SqlDataAdapter(query,connection);
                adapter.Fill(table);

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return table;
        }
    }


}

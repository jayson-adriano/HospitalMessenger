using System.Data.SqlClient;
using System.Data;
using System;
using System.Configuration;
namespace HospitalMessenger
{
    public class Helper
    {
        public DataTable resultHelper(SqlCommand cmd)
        {
            DataTable dt = null;
            SqlConnection con = new SqlConnection("Data Source = .\\SQLEXPRESS; Initial Catalog = HospitalMessenger; Integrated Security = False; User ID = melly; Password=1234567");
            SqlDataAdapter objDataAdapter = new SqlDataAdapter();
            try
            {
                objDataAdapter.SelectCommand = cmd;
                dt = new DataTable();
                objDataAdapter.Fill(dt);
            }
            catch
            {

            }
            finally
            {
                if (cmd != null)
                    cmd.Dispose();
                if (objDataAdapter != null)
                    objDataAdapter.Dispose();
            }
            return dt;
        }

        public string addHelper(SqlCommand cmd, SqlConnection con)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                cmd.ExecuteNonQuery();
                return "Success connection.";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        public string checkingHelper(SqlCommand cmd, SqlConnection con)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                cmd.ExecuteNonQuery();
                //int result = (int)cmd.ExecuteScalar();
                return "Success connection.";
                //return result.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }
    }
}
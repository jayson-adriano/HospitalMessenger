using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace HospitalMessenger
{
    public class Doctor
    {
        SqlConnection con = new SqlConnection("Data Source = .\\SQLEXPRESS; Initial Catalog = HospitalMessenger; Integrated Security = False; User ID = melly; Password=1234567");
        Helper hlp = new Helper();
        public string CheckIfDoctorAccount(int ID)
        {
            SqlCommand cmd = new SqlCommand("CheckIfDoctor", con); //check if doctor
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = ID;
            SqlParameter sqlParam = new SqlParameter("@Result", DbType.Boolean);
            sqlParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(sqlParam);

            hlp.checkingHelper(cmd, con);
            int result = int.Parse(cmd.Parameters["@Result"].Value.ToString());

            if (result == 1)
            {
                return "patient";
            }
            else {
                return "doctor";
            }
        }
    }
}

using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Linq;

namespace HospitalMessenger
{
    public class Patient
    {

        SqlConnection con = new SqlConnection("Data Source = .\\SQLEXPRESS; Initial Catalog = HospitalMessenger; Integrated Security = False; User ID = melly; Password=1234567");
        Helper hlp = new Helper();

        public int LogIn(string userName, string password)
        {
            SqlCommand cmd = new SqlCommand("PatCheckIfUsernameExists", con); //check if username does not exists
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@username", SqlDbType.NVarChar, 20).Value = userName;
            SqlParameter sqlParam = new SqlParameter("@Result", DbType.Boolean);
            sqlParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(sqlParam);

            hlp.checkingHelper(cmd, con);
            int result = int.Parse(cmd.Parameters["@Result"].Value.ToString());

            if (result == 1)
            {
                return -2; //username does no exist
            }
            else
            {
                cmd = new SqlCommand("PatCheckUserNameAndPasswordMatch", con); //check if username and password matches
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@username", SqlDbType.VarChar, 20).Value = userName;
                cmd.Parameters.Add("@password", SqlDbType.VarChar, 20).Value = password;
                sqlParam = new SqlParameter("@Result", DbType.Boolean);
                sqlParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(sqlParam);

                hlp.checkingHelper(cmd, con);
                result = int.Parse(cmd.Parameters["@Result"].Value.ToString());

                if (result == 1)
                {
                    return -3; //username and password does not match
                }
                else
                {
                    cmd = new SqlCommand("ObtainAccountID", con); //get accountID
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@userName", SqlDbType.NVarChar, 20).Value = userName;
                    cmd.Parameters.Add("@password", SqlDbType.NVarChar, 20).Value = password;

                    DataTable dt = hlp.resultHelper(cmd);

                    if (dt.Rows.Count > 0)
                    {
                        int accountID = int.Parse(dt.Rows[0][0].ToString());
                        return accountID;
                    }
                    else
                    {
                        return -1;  //invalid input: empty
                    }
                }
            }
        }

        public string RegisterAccount(string gender, string address, DateTime birthday, string first, string last, string middle, string password, string user, string contact, string email)
        {
            SqlCommand cmd = new SqlCommand("PatCheckIfUsernameExists", con); //check if username does not exists
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@username", SqlDbType.NVarChar, 20).Value = user;
            SqlParameter sqlParam = new SqlParameter("@result", DbType.Boolean);
            sqlParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(sqlParam);

            hlp.checkingHelper(cmd, con);
            int result = int.Parse(cmd.Parameters["@Result"].Value.ToString());

            if (result == 1)
            {
                //username does no exist, allow registration

                cmd = new SqlCommand("PatCreateAccount", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Last_Name", SqlDbType.VarChar, 20).Value = last;
                cmd.Parameters.Add("@First_Name", SqlDbType.VarChar, 20).Value = first;
                cmd.Parameters.Add("@Middle_Name", SqlDbType.VarChar, 20).Value = middle;
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar, 75).Value = address;
                cmd.Parameters.Add("@Birthday", SqlDbType.Date).Value = birthday.ToShortDateString();
                cmd.Parameters.Add("@User_Name", SqlDbType.NVarChar, 20).Value = user;
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 20).Value = password;
                cmd.Parameters.Add("@Contact", SqlDbType.VarChar, 11).Value = contact;
                cmd.Parameters.Add("@Gender", SqlDbType.VarChar, 6).Value = gender;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = email;
                return hlp.addHelper(cmd, con);
            }
            else
            {
                return "username exists"; //username exists

            }
        }

        public string UpdateAccount(string address, string first, string last, string middle, string password, string contact, string email)
        {
            SqlCommand cmd = new SqlCommand("PatUpdateAccount", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Last_Name", SqlDbType.VarChar, 20).Value = last;
                cmd.Parameters.Add("@First_Name", SqlDbType.VarChar, 20).Value = first;
                cmd.Parameters.Add("@Middle_Name", SqlDbType.VarChar, 20).Value = middle;
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar, 75).Value = address;
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 20).Value = password;
                cmd.Parameters.Add("@Contact", SqlDbType.VarChar, 11).Value = contact;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = email;
                return hlp.addHelper(cmd, con);
            
        }

        public string[] GetAccountDetails(int ID)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("PatGetAccountDetails", con);
            cmd.Parameters.Add("@AccountID", SqlDbType.Int).Value = ID;
            cmd.CommandType = CommandType.StoredProcedure;

            dt = hlp.resultHelper(cmd);

            string[] dets = dt.Rows[0].ItemArray.Select(x => x.ToString()).ToArray();
            return dets;


        }
    }
}
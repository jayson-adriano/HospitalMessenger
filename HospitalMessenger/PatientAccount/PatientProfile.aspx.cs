using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalMessenger.PatientAccount
{
    public partial class PatientProfile : System.Web.UI.Page
    {
        Patient pnt = new Patient();
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] actDets = pnt.GetAccountDetails(int.Parse(Session["userID"].ToString()));

            txtAddress.Text = actDets[0].ToString();
            txtFirst.Text = actDets[1].ToString();
            txtLast.Text = actDets[2].ToString();
            txtMiddle.Text = actDets[3].ToString();
            txtUsername.Text = actDets[4].ToString();
            txtPassword.Text = actDets[5].ToString();
            txtContact.Text = actDets[6].ToString();
            txtEmail.Text = actDets[7].ToString();
            txtBirthday.Text = actDets[8].ToString();
            txtGender.Text = actDets[9].ToString();
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            if (txtAddress.Text != String.Empty &&
         txtBirthday.Text != String.Empty &&
         txtContact.Text != String.Empty &&
         txtEmail.Text != String.Empty &&
         txtFirst.Text != String.Empty &&
         txtLast.Text != String.Empty &&
         txtMiddle.Text != String.Empty &&
         txtPassword.Text != String.Empty &&
         txtUsername.Text != String.Empty)
            {
                string check = pnt.UpdateAccount(txtAddress.Text, txtFirst.Text, txtLast.Text, txtMiddle.Text, txtPassword.Text, txtContact.Text, txtEmail.Text);
                if (check == "Success connection.")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:alert('Update successful.');", true);
                    txtAddress.Text = String.Empty;
                    txtContact.Text = String.Empty;
                    txtEmail.Text = String.Empty;
                    txtFirst.Text = String.Empty;
                    txtLast.Text = String.Empty;
                    txtMiddle.Text = String.Empty;
                    txtPassword.Text = String.Empty;

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:alert('Something went wrong.');", true);


                }

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:alert('Please fill in the missing details.');", true);
            }

        }
    }
}
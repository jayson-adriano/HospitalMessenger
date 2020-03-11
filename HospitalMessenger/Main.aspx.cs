using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalMessenger
{
    public partial class Main : System.Web.UI.Page
    {
        Patient pnt = new Patient();
        Doctor dct = new Doctor();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Session["userID"] = pnt.LogIn(txtUsername.Text.ToString(), txtPassword.Text.ToString());
            string acType = dct.CheckIfDoctorAccount(int.Parse(Session["userID"].ToString())).ToString();

            if (txtPassword.Text == String.Empty || txtPassword.Text == String.Empty)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:alert('Username or Password must not be empty!');", true);
                txtPassword.Text = String.Empty;
                txtPassword.Text = String.Empty;
            }
            else if (int.Parse(Session["userID"].ToString()) == -1) //??
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:alert('Invalid account details.');", true);
                txtPassword.Text = String.Empty;
                txtPassword.Text = String.Empty;
            }
            else if (int.Parse(Session["userID"].ToString()) == -2) //USERNAME NOT EXISTING
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:alert('Username does not exist in the database.');", true);
                txtPassword.Text = String.Empty;
                txtPassword.Text = String.Empty;
            }
            else if (int.Parse(Session["userID"].ToString()) == -3) //DID NOT MATCH
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:alert('Username and Password provided does not match.');", true);
                txtPassword.Text = String.Empty;
                txtPassword.Text = String.Empty;
            }
            else if (acType == "doctor")
            {

                txtPassword.Text = String.Empty;
                txtPassword.Text = String.Empty;
                Response.Redirect("~/DoctorAccount/DoctorRates.aspx");
            }
            else
            { 

                txtPassword.Text = String.Empty;
                txtPassword.Text = String.Empty;
                Response.Redirect("~/PatientAccount/PatientProfile.aspx");
            }


        }

    }
}
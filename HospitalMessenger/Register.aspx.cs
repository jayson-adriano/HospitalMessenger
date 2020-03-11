using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalMessenger
{
    public partial class Register : System.Web.UI.Page
    {
        Patient pnt = new Patient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Register_Click(object sender, EventArgs e)
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
                string check = pnt.RegisterAccount(ddGender.SelectedItem.ToString(), txtAddress.Text, DateTime.Parse(txtBirthday.Text), txtFirst.Text, txtLast.Text, txtMiddle.Text, txtPassword.Text, txtUsername.Text, txtContact.Text, txtEmail.Text);
                if (check == "username exists")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:alert('Your username already exists.');", true);
                    txtUsername.Text = String.Empty;
                    txtPassword.Text = String.Empty;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:alert('Registration successful.');", true);
                    txtAddress.Text = String.Empty;
                    txtBirthday.Text = String.Empty;
                    txtContact.Text = String.Empty;
                    txtEmail.Text = String.Empty;
                    txtFirst.Text = String.Empty;
                    txtLast.Text = String.Empty;
                    txtMiddle.Text = String.Empty;
                    txtPassword.Text = String.Empty;
                    txtUsername.Text = String.Empty;
                }

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:alert('Please fill in the missing details.');", true);
            }

        }
    }
}
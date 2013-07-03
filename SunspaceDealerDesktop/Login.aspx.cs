using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SunspaceDealerDesktop
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                if (Session["loginErrorMessage"] == null)
                {
                    Session.Add("loginErrorMessage", "");
                }

                lblError.Text = Session["loginErrorMessage"].ToString();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            
                //something like so
                //Session.Add("loggedIn", aUser.UserId);
                if (txtUsername.Text == "" || txtPassword.Text == "")
                {
                    Session["loginErrorMessage"] = "Please enter your information into the text boxes.";
                    lblError.Text = Session["loginErrorMessage"].ToString();
                }
                else
                {
                    string userHash = GlobalFunctions.CalculateMD5Hash(txtPassword.Text);
                    Console.WriteLine(userHash);
                    //queries here
                    //WHERE username = txtusername.text
                    //AND password = userHash
                    //if results=0, error

                    //else login                
                    Session["loginErrorMessage"] = "";

                    Session.Add("loggedIn", "userA");
                    Response.Redirect("Home.aspx");
                }
        }
    }
}
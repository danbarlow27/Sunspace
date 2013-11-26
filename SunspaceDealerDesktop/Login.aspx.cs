using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SunspaceDealerDesktop
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Error is on session as to keep it whenever they return, as their values may stick from browser options
            if (Session["loginErrorMessage"] == null)
            {
                Session.Add("loginErrorMessage", "");
            }

            //Set error text to the session value, which may be blank
            lblError.Text = Session["loginErrorMessage"].ToString();
            txtUsername.Focus();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {            
            //If either entry is blank, stop checks
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                Session["loginErrorMessage"] = "Please enter your username and password.";
                lblError.Text = Session["loginErrorMessage"].ToString();
            }
            else
            {
                //If entered, get name and password for querying db
                string userName = GlobalFunctions.escapeSqlString(txtUsername.Text);
                string userHash = GlobalFunctions.CalculateSHAHash(txtPassword.Text);

                //Get the customers assosciated with this dealer. status=1 requires it to be an active account.
                sdsLogin.SelectCommand = "SELECT login, password, user_type, user_group, reference_id, user_id FROM users WHERE login='" + userName + "' AND password='" + userHash + "' AND status=1";

                //assign the table names to the dataview object
                DataView dvUsers = (DataView)sdsLogin.Select(System.Web.UI.DataSourceSelectArguments.Empty);

                //If nothing was found, let them know there was an error
                if (dvUsers.Count == 0)
                {
                    Session["loginErrorMessage"] = "Username or password invalid.";
                    lblError.Text = Session["loginErrorMessage"].ToString();
                }
                else
                {
                    Session["loginErrorMessage"] = "";
                    //Sunspace
                    if (dvUsers[0][2].ToString() == "S")
                    {
                        //-1 is not a valid dealer ID, so on later checks, if -1, the user will need to spoof, which changes this
                        Session.Add("dealer_id", "-1");
                        Session.Add("user_id", dvUsers[0][5].ToString());
                        Session.Add("user_type", dvUsers[0][2].ToString());
                        Session.Add("user_group", dvUsers[0][3].ToString());
                        Session.Add("loggedIn", dvUsers[0][0].ToString());
                    }
                    //If dealer
                    else if (dvUsers[0][2].ToString() == "D")
                    {
                        Session.Add("dealer_id", dvUsers[0][4].ToString());
                        Session.Add("user_id", dvUsers[0][5].ToString());
                        Session.Add("user_type", dvUsers[0][2].ToString());
                        Session.Add("user_group", dvUsers[0][3].ToString());
                        Session.Add("loggedIn", dvUsers[0][0].ToString());
                    }

                    //Login means we need to update the last_access date
                    //get current date right now
                    DateTime aDate = DateTime.Now;
                    sdsLogin.UpdateCommand = "UPDATE users SET last_access='" + aDate.ToString("yyyy/MM/dd") + "' "
                                            + "WHERE login='" + userName + "'";
                    sdsLogin.Update();

                    //Finally, we check what kind of user they are. Send sunspace users to spoof page by default, otherwise to home
                    if (dvUsers[0][2].ToString() == "S")
                    {
                        Response.Redirect("Spoof.aspx");
                    }
                    else
                    {
                        Response.Redirect("Home.aspx");
                    }
                }                    
            }
        }
    }
}
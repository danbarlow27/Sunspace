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
                if (Session["loginErrorMessage"] == null)
                {
                    Session.Add("loginErrorMessage", "");
                }

                lblError.Text = Session["loginErrorMessage"].ToString();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {            
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                Session["loginErrorMessage"] = "Please enter your information into the text boxes.";
                lblError.Text = Session["loginErrorMessage"].ToString();
            }
            else
            {
                string userName = txtUsername.Text;
                string userHash = GlobalFunctions.CalculateMD5Hash(txtPassword.Text);

                //Get the customers assosciated with this dealer
                sdsLogin.SelectCommand = "SELECT login, password, user_type, user_group, user_type, reference_id FROM users WHERE login='" + userName + "' AND password='" + userHash + "'"; //and status=1

                //assign the table names to the dataview object
                DataView dvUsers = (DataView)sdsLogin.Select(System.Web.UI.DataSourceSelectArguments.Empty);

                if (dvUsers.Count == 0)
                {
                    Session["loginErrorMessage"] = "Username or password invalid.";
                }
                else
                {
                    //Sunspace
                    if (dvUsers[0][2].ToString() == "S")
                    {
                        //-1 is not a valid dealer ID, so on later checks, if -1, that means don't restrict searches by dealer_id
                        Session.Add("dealer_id", "-1");
                        Session.Add("user_type", dvUsers[0][4].ToString());
                        Session.Add("user_group", dvUsers[0][3].ToString());
                        Session.Add("loggedIn", dvUsers[0][0].ToString());
                    }
                    //If dealer
                    else if (dvUsers[0][2].ToString() == "D")
                    {
                        sdsLogin.SelectCommand = "SELECT dealer_id FROM dealers WHERE dealer_name='" + userName + "'";

                        //assign the table names to the dataview object
                        DataView dvDealer = (DataView)sdsLogin.Select(System.Web.UI.DataSourceSelectArguments.Empty);

                        string test = dvDealer[0][0].ToString();
                        //queries here
                        //WHERE username = txtusername.text
                        //AND password = userHash
                        //if results=0, error

                        //else login                
                        Session["loginErrorMessage"] = "";

                        Session.Add("dealer_id", dvDealer[0][5].ToString());
                        Session.Add("user_type", dvUsers[0][4].ToString());
                        Session.Add("user_group", dvUsers[0][3].ToString());
                        Session.Add("loggedIn", dvUsers[0][0].ToString());
                    }

                    DateTime aDate = DateTime.Now;
                    sdsLogin.UpdateCommand = "UPDATE users SET last_access='" + aDate.ToString("yyyy/MM/dd") + "' "
                                            + "WHERE login='" + userName + "'";
                    sdsLogin.Update();
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
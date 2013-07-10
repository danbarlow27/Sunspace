using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SunspaceDealerDesktop
{
    public partial class Home1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedIn"] == null)
            {
                //uncomment me when login functionality is working
                Response.Redirect("Login.aspx");
                //Session.Add("loggedIn", "1");
            }
        }

        protected void btnPreferences_Click(object sender, EventArgs e)
        {
            Response.Redirect("Preferences.aspx");
        }

        protected void btnAddUsers_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddUsers.aspx");
        }

        protected void btnSpoof_Click(object sender, EventArgs e)
        {
            Response.Redirect("Spoof.aspx");
        }
    }
}
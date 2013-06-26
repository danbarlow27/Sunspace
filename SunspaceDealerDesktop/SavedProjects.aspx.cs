using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SunspaceWizard
{
    public partial class SavedProjects : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedIn"] == null)
            {
                //uncomment me when login functionality is working
                //Response.Redirect("Login.aspx");
                Session.Add("loggedIn", "userA");
            }
        }
    }
}
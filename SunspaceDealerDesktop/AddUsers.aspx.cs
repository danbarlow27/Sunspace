using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SunspaceDealerDesktop
{
    public partial class AddUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedIn"] == null)
            {
                //uncomment me when login functionality is working
                Response.Redirect("Login.aspx");
                //Session.Add("loggedIn", "1");
            }

            //if >-1 it cannot be a sunspace user, so we hide controls accordingly
            if (Convert.ToInt32(Session["dealer_id"].ToString()) > -1)
            {
                UserGroupDiv.Visible = false;
                UserTypeDiv.Visible = false;
            }

            //populate user type
            ddlUserType.Items.Add("Sunspace");
            ddlUserType.Items.Add("Dealer");

            //populate user group
            ddlUserGroup.Items.Add("Admin");
            ddlUserGroup.Items.Add("Sales Rep"); //CSR if sunspace selected, SR if dealer selected.
        }
    }
}
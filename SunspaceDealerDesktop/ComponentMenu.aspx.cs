using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SunspaceDealerDesktop
{
    public partial class MainMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { 
            if (Session["updateSelected"] != null)
            {
                Session.Remove("updateSelected");
            }

            if (Session["viewSelected"] != null)
            {
                Session.Remove("viewSelected");
            }

            if (Session["loggedIn"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else if (Session["user_type"].ToString() != "S")
            {
                btnSelectDisplay.Visible = false;
                btnSelectUpdate.Visible = false;
            }
        }

        protected void btnSelectUpdate_Click(object sender, EventArgs e)
        {
            Session.Add("updateSelected", true);
            Response.Redirect("ProductSelect.aspx");
        }

        protected void btnSelectDisplay_Click(object sender, EventArgs e)
        {
            Session.Add("viewSelected", true);
            Response.Redirect("ProductSelect.aspx");
        }

        protected void btnSelectInsert_Click(object sender, EventArgs e)
        {
            Session.Add("insertSelected", true);
            Response.Redirect("Insert.aspx");
        }

        protected void btnSelectPricing_Click(object sender, EventArgs e)
        {
            Session.Add("globalSelected", true);
            Response.Redirect("GlobalUpdate.aspx");
        }
    }
}
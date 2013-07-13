using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SunspaceDealerDesktop
{
    public partial class Spoof : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedIn"] == null)
            {
                //uncomment me when login functionality is working
                Response.Redirect("Login.aspx");
                //Session.Add("loggedIn", "1");
            }

            if (Session["user_type"].ToString() == "D")
            {
                //don't allow dealers or dealer reps to this page
                Response.Redirect("Home.aspx");
            }

            //Get the customers assosciated with this dealer
            sdsDealers.SelectCommand = "SELECT first_name, last_name, dealer_id FROM dealers";

            //assign the table names to the dataview object
            DataView dvDealers = (DataView)sdsDealers.Select(System.Web.UI.DataSourceSelectArguments.Empty);

            ddlDealers.Items.Clear();

            for (int i = 0; i < dvDealers.Count; i++)
            {
                ddlDealers.Items.Add(new ListItem(dvDealers[i][0].ToString() + dvDealers[i][1].ToString(), dvDealers[i][2].ToString()));
            }
        }

        protected void btnDealers_Click(object sender, EventArgs e)
        {
            Session["dealer_id"] = ddlDealers.SelectedValue;
            Response.Redirect("Home.aspx");
        }
    }
}
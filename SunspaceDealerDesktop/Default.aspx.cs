using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SunspaceDealerDesktop
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["newSession"];
            


        }

        protected void doneDrawing_Click(object sender, EventArgs e)
        {
            Session.Add("testing", hiddenParent.Value);
            Response.Redirect("TestingHiddens.aspx");
        }
    }
}
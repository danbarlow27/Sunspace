using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SunspaceWizard
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLayout_Click(object sender, EventArgs e)
        {
            //If custom btnLayout, Page 2, else, page3
            Response.Redirect("http://www.google.ca");
        }
    }
}
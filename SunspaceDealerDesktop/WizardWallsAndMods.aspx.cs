using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SunspaceDealerDesktop
{
    public partial class WizardWallsAndMods : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string newString = "abc";
            Session["numberOfWalls"] = 5;
        }
    }
}
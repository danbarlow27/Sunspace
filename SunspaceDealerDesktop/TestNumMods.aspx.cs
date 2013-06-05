using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SunspaceDealerDesktop
{
    public partial class TestNumMods : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Wall aWall = new Wall();
            aWall.Length = 120f;
            aWall.TotalCornerLength = 4f;
            aWall.TotalStarterLength = 1.5f;
            tester.InnerHtml = aWall.FindOptimalNumberOfMods();
        }
    }
}
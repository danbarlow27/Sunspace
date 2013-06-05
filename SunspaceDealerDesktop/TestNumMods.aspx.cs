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
            aWall.Length = 177f;
            aWall.TotalCornerLength = 4.5f;
            aWall.TotalStarterLength = 0;
            tester.InnerHtml = aWall.FindOptimalNumberOfMods();
            tester2.InnerHtml = aWall.FindOptimalSizeOfMods(10);
        }
    }
}
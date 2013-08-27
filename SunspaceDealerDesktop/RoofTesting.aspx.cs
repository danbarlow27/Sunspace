using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SunspaceDealerDesktop
{
    public partial class RoofTesting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Roof aRoof = (Roof)Session["completedRoof"];
            RoofModule aRoofModule = aRoof.RoofModules[0];
            RoofModule aGableModule = aRoof.RoofModules[1];
            List<RoofItem> aRoofModuleItemList = aRoofModule.RoofItems;
            List<RoofItem> aGableModuleItemList = aGableModule.RoofItems;

            Label aLabel = new Label();
            aLabel.Text = "Roof is of sizes: Projection: " + aRoof.Projection + ", Width: " + aRoof.Width;
            testHolder.Controls.Add(aLabel);
            testHolder.Controls.Add(new LiteralControl("<br/><br/>"));

            for (int i = 0; i < aRoofModuleItemList.Count; i++)
            {
                aLabel = new Label();
                aLabel.Text = "Type: " + aRoofModuleItemList[i].ItemType + ", Projection: " + aRoofModuleItemList[i].Projection + ", Width: " + aRoofModuleItemList[i].Width;
                testHolder.Controls.Add(aLabel);
                testHolder.Controls.Add(new LiteralControl("<br/>"));
            }

            testHolder.Controls.Add(new LiteralControl("<br/><br/>"));

            for (int i = 0; i < aGableModuleItemList.Count; i++)
            {
                aLabel = new Label();
                aLabel.Text = "Type: " + aGableModuleItemList[i].ItemType + ", Projection: " + aGableModuleItemList[i].Projection + ", Width: " + aGableModuleItemList[i].Width;
                testHolder.Controls.Add(aLabel);
                testHolder.Controls.Add(new LiteralControl("<br/>"));
            }
        }
    }
}
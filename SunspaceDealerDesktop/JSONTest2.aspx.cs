using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace SunspaceDealerDesktop
{
    public partial class JSONTest2 : System.Web.UI.Page
    {
        string json;
        protected int wallCount = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            List<Wall> aListOfWalls = new List<Wall>();

            Wall aWall = new Wall();
            aWall.Name = "Apple";
            aWall.StartHeight = 133;
            aWall.EndHeight = 133;
            aWall.FireProtection = false;
            aWall.GablePeak = 155;
            aWall.Length = 133;

            Wall anWall = new Wall();
            anWall.Name = "Orange";
            anWall.StartHeight = 133;
            anWall.EndHeight = 133;
            anWall.FireProtection = false;
            anWall.GablePeak = 155;
            anWall.Length = 133;

            aListOfWalls.Add(aWall);
            aListOfWalls.Add(anWall);

            foreach (Wall wall in aListOfWalls)
            {
                json = JsonConvert.SerializeObject(wall);
                hidRealHidden.Value += json;
            }

            for (int i = 0; i < aListOfWalls.Count(); i++)
            {
                json = JsonConvert.SerializeObject(aListOfWalls[i]);
                hidRealHidden.Value = json;
                //now create hidden fields for each and stoer the values
                hidWallInfo.InnerHtml += "<input id=\"hidWall" + i + "Info\" type=\"hidden\" runat=\"server\" name=\"hidWall" + i + "Info\" value=\"" + json + "\" />";
                wallCount++;
            }

        }

        protected void btnFuck_Click(object sender, EventArgs e)
        {
            Wall aWall2 = JsonConvert.DeserializeObject<Wall>(Request.Form[hidRealHidden.UniqueID].ToString());
            string temp;
        }
    }
}
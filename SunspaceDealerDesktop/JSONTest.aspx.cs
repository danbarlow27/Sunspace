using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace SunspaceDealerDesktop
{
    public partial class JSONTest : System.Web.UI.Page
    {
        string json = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            Wall aWall = new Wall();
            aWall.Name = "Apple";
            aWall.StartHeight = 133;
            aWall.EndHeight = 133;
            aWall.FireProtection = false;
            aWall.GablePeak = 155;
            aWall.Length = 133;

            json = JsonConvert.SerializeObject(aWall);
            hidRealHidden.Value = json;
        }

        protected void btnFuck_Click(object sender, EventArgs e)
        {
            Wall aWall = JsonConvert.DeserializeObject<Wall>(hidRealHidden.Value);
            string temp;
        }
    }
}
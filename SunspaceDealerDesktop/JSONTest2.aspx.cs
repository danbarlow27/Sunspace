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
            Wall aWall2 = JsonConvert.DeserializeObject<Wall>(Request.Form[hidRealHidden.UniqueID].ToString());
            string temp;
        }
    }
}
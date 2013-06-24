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
            /***hard coded session variables***/
            Session["numberOfWalls"] = 4;
            Session["coordList"] = "125,387.5,162.5,162.5,E,S/187.5,187.5,162.5,275,P,W/187.5,300,275,275,P,S/300,300,275,162.5,P,E/";
            /**********************************/
            hiddenFieldsDiv.InnerHtml = createHiddenFields(); //create hidden fields on page load dynamically
        }

        protected void txtWallLengths_TextChanged(object sender, EventArgs e)
        { 
            
        }

        /// <summary>
        /// This method creates hidden fields dynamically on page load to store the values of wall lengths to be validated on client side
        /// </summary>
        /// <returns>html hidden field tags</returns>
        protected string createHiddenFields()
        {
            string html = "";

            for (int i = 1; i <= (int)Session["numberOfWalls"]; i++)
            {
                html += "<input id=\"hidWall" + i + "Length\" type=\"hidden\" runat=\"server\" />";
            }
            return html;
        }

        public class PositionData
        {

            private string listValue;
            private string listName;

            public PositionData(string listValue, string listName)
            {
                this.listValue = listValue;
                this.listName = listName;
            }

            public string ListValue
            {
                get
                {
                    return listValue;
                }
            }

            public string ListName
            {
                get
                {
                    return listName;
                }
            }
        }
    }
}
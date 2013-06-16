using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SunspaceDealerDesktop
{
    public partial class TestingHiddens : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //testField.InnerText = Session["testing"].ToString();
            string[] newViewingArray = (string[])Session["viewingArray"];

            for (int i = 0; i < newViewingArray.Length; i++)
            {
                formattedOutput.InnerHtml += newViewingArray[i].ToString() + "<br />";
            }
            
        }
    }
}
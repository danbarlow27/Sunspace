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
            testField.InnerText = (string)Session["testing"];
            //string[] newViewingArray = (string[])Session["viewingArray"];

            //for (int i = 0; i < newViewingArray.Length; i++)
            //{
            //    formattedOutput.InnerHtml += newViewingArray[i].ToString() + "<br />";
            //}

            //int numOfWalls = (int)Session["numberOfWalls"];

            //int numOfElements = (int)Session["numberOfElements"];

            //string[,] testArray = (string[,])Session["testArray"];

            //for (int i = 0; i < numOfWalls; i++)
            //{
            //    for (int j = 0; j < numOfElements; j++)
            //    {
            //        formattedOutput.InnerHtml += testArray[i, j].ToString() + "<br />";
            //    }
            //}
        }
    }
}
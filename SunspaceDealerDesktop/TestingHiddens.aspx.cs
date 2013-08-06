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
            FrenchDoor thisDoor = (FrenchDoor)Session["Door0"];
            testField.InnerText = (string)Session["DoorCount2"];
            testField.InnerText += "\t" + (string)thisDoor.DoorType;
            testField.InnerText += "\t" + (string)thisDoor.DoorStyle;
            testField.InnerText += "\t" + (string)thisDoor.Colour;
            testField.InnerText += "\t" + Convert.ToString(thisDoor.FHeight);
            testField.InnerText += "\t" + Convert.ToString(thisDoor.FLength);
            testField.InnerText += "\t" + (string)thisDoor.ScreenType;

            if ((string)thisDoor.DoorType == "Cabana")
            {
                FrenchDoor typeDoor = (FrenchDoor)thisDoor;
                testField.InnerText += "\t" + (string)typeDoor.GlassTint;
            }
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
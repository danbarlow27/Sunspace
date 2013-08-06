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
            testField.InnerText = (string)Session["DoorCount2"];            

            if (typeof(CabanaDoor) == Session["Door0"].GetType())
            {
                CabanaDoor typeDoor = (CabanaDoor)Session["Door0"];
                testField.InnerText += "\t" + (string)typeDoor.DoorType;
                testField.InnerText += "\t" + (string)typeDoor.DoorStyle;
                testField.InnerText += "\t" + (string)typeDoor.Colour;
                testField.InnerText += "\t" + Convert.ToString(typeDoor.FHeight);
                testField.InnerText += "\t" + Convert.ToString(typeDoor.FLength);
                testField.InnerText += "\t" + (string)typeDoor.ScreenType;
                testField.InnerText += "\t" + (string)typeDoor.GlassTint;
            }
            if (typeof(FrenchDoor) == Session["Door0"].GetType())
            {
                FrenchDoor typeDoor = (FrenchDoor)Session["Door0"];
                testField.InnerText += "\t" + (string)typeDoor.DoorType;
                testField.InnerText += "\t" + (string)typeDoor.DoorStyle;
                testField.InnerText += "\t" + (string)typeDoor.Colour;
                testField.InnerText += "\t" + Convert.ToString(typeDoor.FHeight);
                testField.InnerText += "\t" + Convert.ToString(typeDoor.FLength);
                testField.InnerText += "\t" + (string)typeDoor.ScreenType;
                testField.InnerText += "\t" + (string)typeDoor.GlassTint;
            }
            if (typeof(PatioDoor) == Session["Door0"].GetType())
            {
                PatioDoor typeDoor = (PatioDoor)Session["Door0"];
                testField.InnerText += "\t" + (string)typeDoor.DoorType;
                testField.InnerText += "\t" + (string)typeDoor.DoorStyle;
                testField.InnerText += "\t" + (string)typeDoor.Colour;
                testField.InnerText += "\t" + Convert.ToString(typeDoor.FHeight);
                testField.InnerText += "\t" + Convert.ToString(typeDoor.FLength);
                testField.InnerText += "\t" + (string)typeDoor.ScreenType;
                testField.InnerText += "\t" + (string)typeDoor.GlassTint;
            }
            if (typeof(OpenSpaceDoor) == Session["Door0"].GetType())
            {
                OpenSpaceDoor typeDoor = (OpenSpaceDoor)Session["Door0"];
                testField.InnerText += "\t" + (string)typeDoor.DoorType;
                testField.InnerText += "\t" + (string)typeDoor.DoorStyle;
                testField.InnerText += "\t" + (string)typeDoor.Colour;
                testField.InnerText += "\t" + Convert.ToString(typeDoor.FHeight);
                testField.InnerText += "\t" + Convert.ToString(typeDoor.FLength);
                testField.InnerText += "\t" + (string)typeDoor.ScreenType;
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
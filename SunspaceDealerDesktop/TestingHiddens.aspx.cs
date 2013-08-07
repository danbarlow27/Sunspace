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
            //testField.InnerText = (string)Session["Wall4DoorCount2"];            

            if (typeof(CabanaDoor) == Session["Wall4Door0"].GetType())
            {
                CabanaDoor typeDoor = (CabanaDoor)Session["Wall4Door0"];

                //Door fields
                testField.InnerText += "Type: " + typeDoor.DoorType + " | ";
                testField.InnerText += "Style: " + typeDoor.DoorStyle + " | ";
                testField.InnerText += "Colour: " + typeDoor.Colour + " | ";
                testField.InnerText += "FramedHeight: " + typeDoor.FHeight + " | ";
                testField.InnerText += "FramedLength: " + typeDoor.FLength + " | ";
                testField.InnerText += "ScreenType: " + typeDoor.ScreenType + " | ";

                //Cabana fields
                testField.InnerText += "Height: " + typeDoor.Height + " | ";
                testField.InnerText += "Length: " + typeDoor.Length + " | ";
                testField.InnerText += "VinylTint: " + typeDoor.VinylTint + " | ";
                testField.InnerText += "ScreenType: " + typeDoor.ScreenType + " | ";
                testField.InnerText += "GlassTint: " + typeDoor.GlassTint + " | ";
                testField.InnerText += "Hinge: " + typeDoor.Hinge + " | ";
                testField.InnerText += "Swing: " + typeDoor.Swing + " | ";
                testField.InnerText += "HardwareType: " + typeDoor.HardwareType + " | ";
            }
            if (typeof(FrenchDoor) == Session["Wall4Door0"].GetType())
            {
                FrenchDoor typeDoor = (FrenchDoor)Session["Wall4Door0"];

                //Door fields
                testField.InnerText += "Type: " + typeDoor.DoorType + " | ";
                testField.InnerText += "Style: " + typeDoor.DoorStyle + " | ";
                testField.InnerText += "Colour: " + typeDoor.Colour + " | ";
                testField.InnerText += "FramedHeight: " + typeDoor.FHeight + " | ";
                testField.InnerText += "FramedLength: " + typeDoor.FLength + " | ";
                testField.InnerText += "ScreenType: " + typeDoor.ScreenType + " | ";

                //Cabana fields
                testField.InnerText += "Height: " + typeDoor.Height + " | ";
                testField.InnerText += "Length: " + typeDoor.Length + " | ";
                testField.InnerText += "GlassTint: " + typeDoor.GlassTint + " | ";
                testField.InnerText += "ScreenType: " + typeDoor.ScreenType + " | ";
                testField.InnerText += "VinylTint: " + typeDoor.VinylTint + " | ";
                testField.InnerText += "Swing: " + typeDoor.Swing + " | ";
                testField.InnerText += "OperatingDoor: " + typeDoor.OperatingDoor + " | ";
                testField.InnerText += "HardwareType: " + typeDoor.HardwareType + " | ";
            }
            if (typeof(PatioDoor) == Session["Wall4Door0"].GetType())
            {
                PatioDoor typeDoor = (PatioDoor)Session["Wall4Door0"];

                //Door fields
                testField.InnerText += "Type: " + typeDoor.DoorType + " | ";
                testField.InnerText += "Style: " + typeDoor.DoorStyle + " | ";
                testField.InnerText += "Colour: " + typeDoor.Colour + " | ";
                testField.InnerText += "FramedHeight: " + typeDoor.FHeight + " | ";
                testField.InnerText += "FramedLength: " + typeDoor.FLength + " | ";
                testField.InnerText += "ScreenType: " + typeDoor.ScreenType + " | ";

                //Cabana fields
                testField.InnerText += "Height: " + typeDoor.Height + " | ";
                testField.InnerText += "Length: " + typeDoor.Length + " | ";
                testField.InnerText += "GlassTint: " + typeDoor.GlassTint + " | ";
                testField.InnerText += "MovingDoor: " + typeDoor.MovingDoor + " | ";
                
            }
            if (typeof(OpenSpaceDoor) == Session["Wall4Door0"].GetType())
            {
                OpenSpaceDoor typeDoor = (OpenSpaceDoor)Session["Wall4Door0"];

                //Door fields
                testField.InnerText += "Type: " + typeDoor.DoorType + " | ";
                testField.InnerText += "Style: " + typeDoor.DoorStyle + " | ";
                testField.InnerText += "Colour: " + typeDoor.Colour + " | ";
                testField.InnerText += "FramedHeight: " + typeDoor.FHeight + " | ";
                testField.InnerText += "FramedLength: " + typeDoor.FLength + " | ";
                testField.InnerText += "ScreenType: " + typeDoor.ScreenType + " | ";

                //OpenSpace fields
                testField.InnerText += "Height: " + typeDoor.Height + " | ";
                testField.InnerText += "Lenght: " + typeDoor.Length + " | ";
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
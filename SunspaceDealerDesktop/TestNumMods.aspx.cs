using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SunspaceDealerDesktop
{
    public partial class TestNumMods : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Wall aWall = new Wall();
            Receiver aReceiver = new Receiver();
            Mod aMod = new Mod();
            Corner aCorner = new Corner();
            Filler aFiller = new Filler();

            aWall.ProposedLength = 178f;

            aReceiver.Length = 2f;
            aWall.addToItemList(aReceiver);
            aReceiver = new Receiver();

            aWall.addToItemList(aFiller);
            aFiller = new Filler();

            aMod.Length = 30f;
            aWall.addToItemList(new Mod());
            aMod = new Mod();

            aMod.Length = 30f;
            aWall.addToItemList(new Mod());
            aMod = new Mod();

            aMod.Length = 30f;
            aWall.addToItemList(new Mod());
            aMod = new Mod();

            aWall.addToItemList(aFiller);
            aFiller = new Filler();

            aCorner.Length = 3.125f;
            aWall.addToItemList(new Corner());
            aCorner = new Corner();

            List<Object> listOfItems = aWall.LinearItems;

            for (int i = 0; i <= listOfItems.Count-1; i++)
            {
                string currentObjectType = listOfItems[i].ToString();
                int index = currentObjectType.IndexOf(".");
                if (index > 0)
                    currentObjectType = currentObjectType.Substring(index+1, (currentObjectType.Length-index-1)); //from one past the index to end of string

                tester.InnerHtml += currentObjectType + " - ";
            }

            //int numberOfMods = aWall.FindOptimalNumberOfMods();
            //tester.InnerHtml += "\n" + "Proposed: " + aWall.ProposedLength + ", Actual: " + aWall.ActualLength; 
            //tester2.InnerHtml = aWall.FindOptimalSizeOfMods(10); 
        }
    }
}
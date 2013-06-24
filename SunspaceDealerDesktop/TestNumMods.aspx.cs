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
            aWall.addToItemList(aMod);
            aMod = new Mod();

            aMod.Length = 30f;
            aWall.addToItemList(aMod);
            aMod = new Mod();

            aMod.Length = 30f;
            aWall.addToItemList(aMod);
            aMod = new Mod();

            aWall.addToItemList(aFiller);
            aFiller = new Filler();

            aCorner.Length = 3.125f;
            aWall.addToItemList(aCorner);
            aCorner = new Corner();

            List<Object> listOfItems = aWall.LinearItems;

            for (int i = 0; i <= listOfItems.Count-1; i++)
            {
                string currentObjectType = listOfItems[i].ToString();
                int index = currentObjectType.IndexOf(".");
                if (index > 0)
                    currentObjectType = currentObjectType.Substring(index+1, (currentObjectType.Length-index-1)); //from one past the index to end of string
                
                if (currentObjectType.Equals("Receiver"))
                {
                    aReceiver = (Receiver)listOfItems[i];
                    tester.InnerHtml += (currentObjectType + " at length " + aReceiver.Length.ToString() + "<br/>");
                }
                else if (currentObjectType.Equals("Filler"))
                {
                    aFiller = (Filler)listOfItems[i];
                    tester.InnerHtml += (currentObjectType + " at length " + aFiller.Length.ToString() + "<br/>");
                }
                else if (currentObjectType.Equals("Mod"))
                {
                    aMod = (Mod)listOfItems[i];
                    tester.InnerHtml += (currentObjectType + " at length " + aMod.Length.ToString() + "<br/>");
                }
                else if (currentObjectType.Equals("Corner"))
                {
                    aCorner = (Corner)listOfItems[i];
                    tester.InnerHtml += (currentObjectType + " at length " + aCorner.Length.ToString() + "<br/>");
                }
            }

            tester.InnerHtml += "Total Wall Length currently set to: " + aWall.ProposedLength + "<br/>";

            float[] testArray = aWall.FindOptimalNumberOfMods(2f, 2f);
            tester.InnerHtml = testArray[0] + " " + testArray[1] + " " + testArray[2];
            testArray = aWall.FindMinimumNumberOfMods(2f, 2f);
            tester2.InnerHtml = testArray[0] + " " + testArray[1] + " " + testArray[2]; 
        }
    }
}
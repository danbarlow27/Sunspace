using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SunspaceDealerDesktop
{
    public partial class ProjectPreview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Wall> sentWalls = new List<Wall>;
            sentWalls.Add(new Wall());
            sentWalls.Add(new Wall());
            sentWalls.Add(new Wall());
            sentWalls[0].ProposedLength=240f;
            sentWalls[1].ProposedLength=240f;
            sentWalls[2].ProposedLength=240f;

            Receiver leftReceiver = new Receiver(1f);
            Receiver rightReceiver = new Receiver(1f);
            Filler leftFiller = new Filler(1f);
            Filler rightFiller = new Filler(1f);
            List<Object> listOfDoors = new List<Object>();
            
            Mod aMod = new Mod();
            List<Object> modularItems = aMod.ModularItems;
            modularItems.Add(new Door());
            listOfDoors.Add(aMod);

            aMod = new Mod();
            modularItems = aMod.ModularItems;
            modularItems.Add(new Door());
            listOfDoors.Add(aMod);

            aMod = new Mod();
            modularItems = aMod.ModularItems;
            modularItems.Add(new Door());
            listOfDoors.Add(aMod);

            float workableStart;
            float workableEnd;

            for (int i = 0; i <= sentWalls.Count(); i++)
            {
                float tempWallLength = sentWalls[i].ProposedLength - leftReceiver.Length - leftFiller.Length;

                for (int j = 0; j <= listOfDoors.Count(); j++)
                {

                }
            }
        }
    }
}
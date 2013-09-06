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
            if (Session["loggedIn"] == null)
            {
                //uncomment me when login functionality is working
                //Response.Redirect("Login.aspx");
                Session.Add("loggedIn", "userA");
            }
            
            //List<Wall> sentWalls = new List<Wall>();
            //sentWalls.Add(new Wall());
            //sentWalls[0].Length=240f;

            //Receiver leftReceiver = new Receiver(1f);
            //Receiver rightReceiver = new Receiver(1f);
            //Filler leftFiller = new Filler(1f);
            //Filler rightFiller = new Filler(1f);
            //List<Object> listOfDoors = new List<Object>();
            
            //Mod aMod = new Mod();
            //List<Object> modularItems = aMod.ModularItems;
            //modularItems.Add(new Door());
            //listOfDoors.Add(aMod);


            //aMod = new Mod();
            //modularItems = aMod.ModularItems;
            //modularItems.Add(new Door());
            //listOfDoors.Add(aMod);

            //aMod = new Mod();
            //modularItems = aMod.ModularItems;
            //modularItems.Add(new Door());
            //listOfDoors.Add(aMod);

        }
    }
}
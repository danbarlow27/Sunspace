using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class PricingFunctions
    {
        public static float PriceSunroom()//Sunroom aSunroom
        {
            float sunroomPrice = 0.0f;
            int numberOfWalls = 4;
            for (int i = 0; i < numberOfWalls; i++)
            {
                sunroomPrice += PriceWall();
            }
            return sunroomPrice;
        }

        public static float PriceWall()//Wall aWall
        {
            float wallPrice = 0.0f;
            Mod[] listOfMods = null;
            foreach (Mod aMod in listOfMods) {
                wallPrice += PriceMod(aMod);
            }
            return wallPrice;
        }

        public static float PriceMod(Mod aMod)//Mod aMod
        {
            float modPrice = 0.0f;
            if (aMod.ModType == "Door")
            {
                PriceDoor();
            }
            else
            {
                PriceWindow();
            }
            return modPrice;
        }

        public static float PriceWindow()//Window aWindow
        {
            float windowPrice = 0.0f;
            //Pricing logic specifics
            return windowPrice;
        }

        public static float PriceDoor()//Door aDoor
        {
            Door aDoor = new Door();
            float doorPrice = 0.0f;
            //Pricing logic specifics
            if (aDoor.DoorType == "Cabana")
            {
                //MODEL 200,300
                //4-Track Vertical Vinyl Door
                //Full View Glass
                //Full View Colonial Glass
            }
            else if (aDoor.DoorType == "French")
            {
            }
            else if (aDoor.DoorType == "Patio")
            {
            }
            else//NoDoor
            { 
            }
            return doorPrice;
        }
    }
}
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
            Wall aWall = new Wall();

            float sunroomPrice = 0.0f;
            int numberOfWalls = 4;
            for (int i = 0; i < numberOfWalls; i++)
            {
                sunroomPrice += PriceWall(aWall);
            }
            return sunroomPrice;
        }

        public static float PriceWall(Wall aWall)//Wall aWall
        {
            float wallPrice = 0.0f;           
            int sunroomModel = 100;            
            
            switch(sunroomModel){
                case 100:
                    //Screen only
                    PriceModel100Wall(aWall);
                    break;
                case 200:
                    //2-4 page in MSRP
                    break;
                case 300:
                    //3-4 page in MSRP
                    break;
                case 400:
                    //V4T
                    break;
            }
            return wallPrice;
        }

        public static float PriceModel100Wall(Wall aWall)
        {
            float wallPrice = 0.0f;
            int numberOfDoors = 0;
            float lengthOfDoors = 0.0f;
            float lengthOfWindows = 0.0f;
            float lengthOfSolidWall = 0.0f;
            List<LinearItem> listOfMods = (List<LinearItem>)aWall.LinearItems;
            foreach (LinearItem aLinearItem in listOfMods)
            {
                //wallPrice += PriceMod(aMod);
                if (aLinearItem.ItemType == "Mod")
                {
                    Mod aMod = (Mod)aLinearItem;

                    if (aMod.ModType == "Door")
                    {
                        numberOfDoors++;
                        lengthOfDoors += aMod.Length;
                    }
                    else if (aMod.ModType == "Window") //Solid Wall
                    {
                        lengthOfWindows += aMod.Length;
                    }
                    else
                    {
                        lengthOfSolidWall += aMod.Length;
                    }
                }
            }

            switch (numberOfDoors) { 
                case 1:
                    wallPrice = PricingConstants.MODEL_100_SCREEN_OPENING_1_SCREEN_DOOR * lengthOfDoors;
                    break;
                case 2:
                    wallPrice = PricingConstants.MODEL_100_SCREEN_OPENING_2_SCREEN_DOORS * lengthOfDoors;
                    break;
                case 3:
                    wallPrice = PricingConstants.MODEL_100_SCREEN_OPENING_3_SCREEN_DOORS * lengthOfDoors;
                    break;
            }

            wallPrice += PricingConstants.MODEL_100_SOLID_WALL_PANEL * lengthOfSolidWall;

            if (aWall.EndHeight > 96 && aWall.EndHeight < 120)
            {
                wallPrice += PricingConstants.MODEL_100_NON_STANDARD_PANEL_HEIGHTS * aWall.Length;
            }
            else if (aWall.EndHeight >= 120)
            {
                wallPrice += PricingConstants.MODEL_100_NON_STANDARD_PANEL_HEIGHTS_HIGHER * aWall.Length;
            }

            return wallPrice;
        }

        //Window only order
        public static float PriceWindow()//Window aWindow
        {
            float windowPrice = 0.0f;
            //Pricing logic specifics
            return windowPrice;
        }

        //Door only order
        public static float PriceDoor(Door aDoor)//Door aDoor, ModelNumber (0 will be door only order)
        {
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
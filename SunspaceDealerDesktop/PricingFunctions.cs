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
            float lengthOfMods = 0.0f;
            float lengthOfSolidWall = 0.0f;
            float lengthOfOpen = 0.0f;
            List<LinearItem> listOfMods = (List<LinearItem>)aWall.LinearItems;
            foreach (LinearItem aLinearItem in listOfMods)
            {
                if (aLinearItem.ItemType == "Mod")
                {                    
                    Mod aMod = (Mod)aLinearItem;
                    if (aMod.ModType == "Door")
                    {
                        Door aDoor = (Door)aMod.ModularItems[0];
                        if (aDoor.DoorType == "NoDoor")
                        {
                            lengthOfOpen += aLinearItem.Length;
                        }
                        else
                        {
                            numberOfDoors++;
                            lengthOfMods += aLinearItem.Length;
                        }                        
                    }
                    else if (aMod.ModType == "Window")
                    {
                        Kneewall aKneewall = (Kneewall)aMod.ModularItems[0]; //Kneewall
                        if (aKneewall.FLength > 20)
                        {
                            //Add pricing for custom kneewall height
                        }
                        else
                        {

                        }
                    }
                    else if (aMod.ModType == "Open" && aLinearItem.Length >= 8)
                    {
                        lengthOfOpen += aLinearItem.Length;
                    }
                    else 
                    {
                        lengthOfMods += aLinearItem.Length;
                    }
                    
                }   
                else //Check to see if everything else other than mods are included
                {                    
                    if (aLinearItem.Length >= 8)
                    {
                        lengthOfSolidWall += aLinearItem.Length;
                        lengthOfMods -= aLinearItem.Length;
                    }
                }
            }

            switch (numberOfDoors)
            {
                case 1:
                    wallPrice += PricingConstants.MODEL_100_SCREEN_OPENING_1_SCREEN_DOOR * lengthOfMods;
                    break;
                case 2:
                    wallPrice += PricingConstants.MODEL_100_SCREEN_OPENING_2_SCREEN_DOORS * lengthOfMods;
                    break;
                case 3:
                    wallPrice += PricingConstants.MODEL_100_SCREEN_OPENING_3_SCREEN_DOORS * lengthOfMods;
                    break;
            }

            wallPrice += PricingConstants.MODEL_100_SOLID_WALL_PANEL * lengthOfSolidWall;

            if ((aWall.EndHeight > 96 && aWall.EndHeight < 120) || (aWall.StartHeight > 96 && aWall.StartHeight < 120))
            {
                wallPrice += PricingConstants.MODEL_100_NON_STANDARD_PANEL_HEIGHTS * aWall.Length;
            }
            else if (aWall.EndHeight >= 120 || aWall.StartHeight >= 120)
            {
                wallPrice += PricingConstants.MODEL_100_NON_STANDARD_PANEL_HEIGHTS_HIGHER * aWall.Length;
            }

            if (aWall.FireProtection == true) {
                wallPrice += PricingConstants.MODEL_100_FP_SCREEN_OPENINGS_INCLUDES_1_SCREEN_DOOR * lengthOfMods;
                wallPrice += PricingConstants.MODEL_100_FP_SOLID_WALL_PANEL * lengthOfSolidWall;
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
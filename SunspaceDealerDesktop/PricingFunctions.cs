using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class PricingFunctions
    {

        protected static int numberOfPatioDoors = 0;
        protected static int numberOfV4TDoors = 0;
        protected static int numberOfV4TFrenchDoors = 0;
        protected static int numberOfFullViewDoors = 0;
        protected static int numberOfFullViewFrenchDoors = 0;
        protected static int numberOfFullViewColonialDoors = 0;
        protected static int numberOfFullViewColonialFrenchDoors = 0;

        public static float PriceSunroom()//Sunroom aSunroom
        {
            Wall aWall = new Wall();
            int sunroomModel = 100;      

            float sunroomPrice = 0.0f;
            int numberOfWalls = 4;
            for (int i = 0; i < numberOfWalls; i++)
            {
                sunroomPrice += PriceWall(aWall);
            }

            switch (sunroomModel)
            {
                case 100:
                    break;
                case 200:
                    //Price entry doors for model 200
                    sunroomPrice += PriceModel200EntryDoors();
                    break;
                case 300:
                    break;
                case 400:
                    break;
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
                    wallPrice += PriceModel100Wall(aWall);
                    break;
                case 200:
                    //2-4 page in MSRP
                    wallPrice += PriceModel200Wall(aWall);
                    break;
                case 300:
                    //3-4 page in MSRP
                    wallPrice += PriceModel300Wall(aWall);
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
            //Loop through linear items
            foreach (LinearItem aLinearItem in listOfMods)
            {
                //Linear item is a mdo
                if (aLinearItem.ItemType == "Mod")
                {                    
                    //Cast linear item as a mod
                    Mod aMod = (Mod)aLinearItem;
                    //Mod is a door
                    if (aMod.ModType == "Door")
                    {
                        Door aDoor = (Door)aMod.ModularItems[0];
                        //Non door add linear length to lengthOfOpen
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
                        //Mod is a window
                    else if (aMod.ModType == "Window")
                    {
                        Kneewall aKneewall = (Kneewall)aMod.ModularItems[0]; //Kneewall
                        Window aWindow = (Window)aMod.ModularItems[1];
                        if (aKneewall.FLength > 20)
                        {
                            //Add pricing for custom kneewall height
                        }
                        else
                        {

                        }

                        if (aWindow.ScreenType == "No See Ums 20 x 20 Mesh")
                        {
                            wallPrice += PricingConstants.MODEL_100_NO_SEE_UMS_FIBERGLASS_20_X_20_MESH * aLinearItem.Length;
                        }
                        else if (aWindow.ScreenType == "Solar Insect Screening")
                        {
                            wallPrice += PricingConstants.MODEL_100_SOLAR_INSECT_SCREENING * aLinearItem.Length;
                        }
                        else if (aWindow.ScreenType == "Tuff Screen")
                        {
                            wallPrice += PricingConstants.MODEL_100_TUFF_SCREEN * aLinearItem.Length;
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

            //Set price based on number of doors in the sunroom
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

            //Add solid wall pricing
            wallPrice += PricingConstants.MODEL_100_SOLID_WALL_PANEL * lengthOfSolidWall;

            //Find wall height and set appropriate pricing
            if ((aWall.EndHeight > 96 && aWall.EndHeight < 120) || (aWall.StartHeight > 96 && aWall.StartHeight < 120))
            {
                wallPrice += PricingConstants.MODEL_100_NON_STANDARD_PANEL_HEIGHTS * aWall.Length;
            }
            else if (aWall.EndHeight >= 120 || aWall.StartHeight >= 120)
            {
                wallPrice += PricingConstants.MODEL_100_NON_STANDARD_PANEL_HEIGHTS_HIGHER * aWall.Length;
            }

            //Add pricing for fire protection
            if (aWall.FireProtection == true) {
                wallPrice += PricingConstants.MODEL_100_FP_SCREEN_OPENINGS_INCLUDES_1_SCREEN_DOOR * lengthOfMods;
                wallPrice += PricingConstants.MODEL_100_FP_SOLID_WALL_PANEL * lengthOfSolidWall;
            }

            return wallPrice;
        }

        //Find the price for a Model 200 wall
        public static float PriceModel200Wall(Wall aWall)
        {
            float wallPrice = 0.0f;
            float lengthOfStandard = 0.0f;
            float lengthOfSolidWall = 0.0f;
            float lengthOfOpen = 0.0f;
            float lengthOfFixedVinyl = 0.0f;
            List<LinearItem> listOfMods = (List<LinearItem>)aWall.LinearItems;

            if (aWall.Orientation != "N" && aWall.Orientation != "S" && aWall.Orientation != "E" && aWall.Orientation != "W")
            {
                wallPrice = PricingConstants.MODEL_200_45_DEGREE_WALLS;
            }

            //Loop through linear items
            foreach (LinearItem aLinearItem in listOfMods)
            {
                if (aLinearItem.ItemType == "Electrical Chase")
                {
                    wallPrice += PricingConstants.MODEL_200_VERTICAL_ELECTRICAL_CHASE;
                }
                //Linear item is a mod
                else if (aLinearItem.ItemType == "Mod")
                {
                    /******************************************
                     * NEED SOMETHING FOR PRICING TRANSOMS    *
                     * NEED SOMETHING FOR MISCELLANEOUS ITEMS *
                     * ****************************************/
                    //Cast linear item as a mod
                    Mod aMod = (Mod)aLinearItem;
                    //Mod is a door
                    if (aMod.ModType == "Door")
                    {
                        Door aDoor = (Door)aMod.ModularItems[0];
                        //Non door add linear length to lengthOfOpen
                        if (aDoor.DoorType == "Patio") 
                        {
                            numberOfPatioDoors++;
                            //Cast the window within the door to a window object
                            Window aDoorWindow = aDoor.DoorWindow;
                            //Must be a glass window
                            if (aDoorWindow.WindowStyle.Contains("Glass") || aDoorWindow.WindowStyle == "Single Slider" || aDoorWindow.WindowStyle == "Horizontal Roller") 
                            {
                                //Cast window item to vinyl window item
                                VinylWindow aVinylDoorWindow = (VinylWindow)aDoorWindow;
                                //If glass window tint is grey or bronze, additional pricing occurs
                                if (aVinylDoorWindow.VinylTint.Contains("Grey") || aVinylDoorWindow.VinylTint.Contains("Bronze")){
                                    wallPrice += PricingConstants.MODEL_200_TINTED_GLASS_IN_PATIO_DOOR;
                                }
                            }
                        }
                        else if (aDoor.DoorType == "NoDoor")
                        {
                            //Add length to open door length
                            lengthOfOpen += aLinearItem.Length;
                        }
                        else
                        {
                            //Add length to standard pricing
                            lengthOfStandard += aLinearItem.Length;
                        }

                        /**************************************
                         * BLOCK TO HANDLE ENTRY DOOR PRICING *
                         * ************************************/
                        if (aDoor.DoorStyle == "Vertical Four Track" && aDoor.DoorType != "French")
                        {                        
                            //Add length to standard pricing
                            lengthOfStandard += aLinearItem.Length;
                            numberOfV4TDoors++;
                        }
                        else if (aDoor.DoorStyle == "Vertical Four Track" && aDoor.DoorType == "French")
                        {
                            //Add length to standard pricing
                            lengthOfStandard += aLinearItem.Length;
                            numberOfV4TFrenchDoors++;
                        }
                        
                        if (aDoor.DoorStyle == "Full View" && aDoor.DoorType != "French")
                        {                        
                            numberOfFullViewDoors++;
                        }
                        else if (aDoor.DoorStyle == "Full View" && aDoor.DoorType == "French")
                        {                        
                            numberOfFullViewFrenchDoors++;
                        }
                        
                        if (aDoor.DoorStyle == "Full View Colonial" && aDoor.DoorType != "French")
                        {                        
                            numberOfFullViewColonialDoors++;
                        }
                        else if (aDoor.DoorStyle == "Full View Colonial" && aDoor.DoorType == "French")
                        {                        
                            numberOfFullViewColonialFrenchDoors++;
                        }
                    }
                    //Mod is a window
                    else if (aMod.ModType == "Window")
                    {
                        Kneewall aKneewall = (Kneewall)aMod.ModularItems[0]; //Kneewall
                        Window aWindow = (Window)aMod.ModularItems[1];
                        if (aKneewall.FLength > 20)
                        {
                            //Add pricing for custom kneewall height
                        }
                        else
                        {

                        }

                        //Add length for fixed vinyl
                        if (aWindow.WindowStyle.Contains("Fixed")) //Possibilities: Fixed Vinyl, Fixed Glass 2", Fixed Glass 3"
                        {
                            lengthOfFixedVinyl += aLinearItem.Length;
                        }

                        if (aWindow.ScreenType == "No See Ums 20 x 20 Mesh")
                        {
                            wallPrice += PricingConstants.MODEL_200_NO_SEE_UMS * aLinearItem.Length;
                        }
                        else if (aWindow.ScreenType == "Solar Insect Screening")
                        {
                            wallPrice += PricingConstants.MODEL_200_SOLAR_INSECT_SCREENING * aLinearItem.Length;
                        }
                        else if (aWindow.ScreenType == "Tuff Screen")
                        {
                            wallPrice += PricingConstants.MODEL_200_TUFF_SCREEN * aLinearItem.Length;
                        }
                    }
                    else if (aMod.ModType == "Open" && aLinearItem.Length >= 8)
                    {
                        lengthOfOpen += aLinearItem.Length;
                    }
                    else
                    {
                        lengthOfStandard += aLinearItem.Length;
                    }

                }
                else //Check to see if everything else other than mods are included
                {
                    if (aLinearItem.Length >= 8)
                    {
                        lengthOfSolidWall += aLinearItem.Length;
                        lengthOfStandard -= aLinearItem.Length;
                    }
                }
            }

            //Add various wall pricing types to wall price based on length
            wallPrice += PricingConstants.MODEL_200_VINYL_HORIZONTAL_ROLLER * lengthOfStandard;
            wallPrice += PricingConstants.MODEL_200_SOLID_WALL_PANEL * lengthOfSolidWall;
            wallPrice += PricingConstants.MODEL_200_MANUFACTURED_OPEN_WALLS * lengthOfOpen;
            wallPrice += PricingConstants.MODEL_200_FIXED_VINYL_WALL * lengthOfFixedVinyl;

            //Find wall height and set appropriate pricing
            if ((aWall.EndHeight > 96 && aWall.EndHeight < 120) || (aWall.StartHeight > 96 && aWall.StartHeight < 120))
            {
                wallPrice += PricingConstants.MODEL_200_NON_STANDARD_PANEL_HEIGHTS * aWall.Length;
            }
            else if (aWall.EndHeight >= 120 || aWall.StartHeight >= 120)
            {
                wallPrice += PricingConstants.MODEL_200_NON_STANDARD_PANEL_HEIGHTS_HIGHER * aWall.Length;
            }

            //Add pricing for fire protection
            if (aWall.FireProtection == true)
            {
                wallPrice += PricingConstants.MODEL_200_FP_HORIZONTAL_ROLLER * lengthOfStandard;
                wallPrice += PricingConstants.MODEL_200_FP_MANUFACTURED_OPEN_WALLS * lengthOfOpen;
                wallPrice += PricingConstants.MODEL_200_FP_SOLID_WALL_PANEL * lengthOfSolidWall;
                wallPrice += PricingConstants.MODEL_200_FP_FIXED_VINYL_WALL * lengthOfFixedVinyl;
            }

            return wallPrice;
        }

        //Find the pricing for the entry doors within the Model 200 sunroom
        private static float PriceModel200EntryDoors() 
        {
            float entryDoorsPrice = 0.0f;

            //No patio doors exist, find upgraded door and price appropriately
            if (numberOfPatioDoors == 0)
            {
                if (numberOfFullViewColonialFrenchDoors > 0)
                {
                    entryDoorsPrice += PricingConstants.MODEL_200_FULL_VIEW_COLONIAL_GLASS_UPGRADE;
                    numberOfFullViewColonialFrenchDoors--;
                }
                else if (numberOfFullViewColonialDoors > 0)
                {
                    entryDoorsPrice += PricingConstants.MODEL_200_FULL_VIEW_COLONIAL_GLASS_UPGRADE;
                    numberOfFullViewColonialDoors--;
                }
                else if (numberOfFullViewFrenchDoors > 0)
                {
                    entryDoorsPrice += PricingConstants.MODEL_200_FULL_VIEW_GLASS_UPGRADE;
                    numberOfFullViewFrenchDoors--;
                }
                else if (numberOfFullViewDoors > 0)
                {
                    entryDoorsPrice += PricingConstants.MODEL_200_FULL_VIEW_GLASS_UPGRADE;
                    numberOfFullViewDoors--;
                }
                else if (numberOfV4TFrenchDoors > 0)
                {
                    entryDoorsPrice += PricingConstants.MODEL_200_4_TRACK_VERTICAL_VINYL_DOOR_UPGRADE;
                    numberOfV4TFrenchDoors--;
                }
                else if (numberOfV4TDoors > 0)
                {
                    entryDoorsPrice += PricingConstants.MODEL_200_4_TRACK_VERTICAL_VINYL_DOOR_UPGRADE;
                    numberOfV4TDoors--;
                }

                entryDoorsPrice += PricingConstants.MODEL_200_FULL_VIEW_COLONIAL_GLASS_ADDITIONAL * numberOfFullViewColonialDoors;
                entryDoorsPrice += PricingConstants.MODEL_200_FULL_VIEW_GLASS_ADDITIONAL * numberOfFullViewDoors;
                entryDoorsPrice += PricingConstants.MODEL_200_4_TRACK_VERTICAL_VINYL_DOOR_ADDITIONAL * numberOfV4TDoors;
                entryDoorsPrice += PricingConstants.MODEL_200_F_FULL_VIEW_COLONIAL_GLASS_ADDITIONAL * numberOfFullViewColonialFrenchDoors;
                entryDoorsPrice += PricingConstants.MODEL_200_F_FULL_VIEW_GLASS_ADDITIONAL * numberOfFullViewFrenchDoors;
                entryDoorsPrice += PricingConstants.MODEL_200_F_4_TRACK_VERTICAL_VINYL_DOOR_ADDITIONAL * numberOfV4TFrenchDoors;
            }
            else
            {
                //No upgrades occured
                entryDoorsPrice += PricingConstants.MODEL_200_FULL_VIEW_COLONIAL_GLASS_ADDITIONAL * numberOfFullViewColonialDoors;
                entryDoorsPrice += PricingConstants.MODEL_200_FULL_VIEW_GLASS_ADDITIONAL * numberOfFullViewDoors;
                entryDoorsPrice += PricingConstants.MODEL_200_4_TRACK_VERTICAL_VINYL_DOOR_ADDITIONAL * numberOfV4TDoors;
                entryDoorsPrice += PricingConstants.MODEL_200_F_FULL_VIEW_COLONIAL_GLASS_ADDITIONAL * numberOfFullViewColonialFrenchDoors;
                entryDoorsPrice += PricingConstants.MODEL_200_F_FULL_VIEW_GLASS_ADDITIONAL * numberOfFullViewFrenchDoors;
                entryDoorsPrice += PricingConstants.MODEL_200_F_4_TRACK_VERTICAL_VINYL_DOOR_ADDITIONAL * numberOfV4TFrenchDoors;
            }

            numberOfPatioDoors = 0;
            numberOfV4TDoors = 0;
            numberOfV4TFrenchDoors = 0;
            numberOfFullViewDoors = 0;
            numberOfFullViewFrenchDoors = 0;
            numberOfFullViewColonialDoors = 0;
            numberOfFullViewColonialFrenchDoors = 0;

            return entryDoorsPrice;
        }

        //Find the price for a Model 300 wall
        /****NEEDS REVIEWING, NOT COMPLETE****/
        public static float PriceModel300Wall(Wall aWall)
        {
            float wallPrice = 0.0f;
            float lengthOfStandard = 0.0f;
            float lengthOfSolidWall = 0.0f;
            float lengthOfOpen = 0.0f;
            float lengthOfFixedVinyl = 0.0f;
            List<LinearItem> listOfMods = (List<LinearItem>)aWall.LinearItems;

            if (aWall.Orientation != "N" && aWall.Orientation != "S" && aWall.Orientation != "E" && aWall.Orientation != "W")
            {
                wallPrice = PricingConstants.MODEL_300_45_DEGREE_WALLS;
            }

            //Loop through linear items
            foreach (LinearItem aLinearItem in listOfMods)
            {
                //Linear item is a mod
                if (aLinearItem.ItemType == "Mod")
                {
                    //Cast linear item as a mod
                    Mod aMod = (Mod)aLinearItem;
                    //Mod is a door
                    if (aMod.ModType == "Door")
                    {
                        Door aDoor = (Door)aMod.ModularItems[0];
                        //Non door add linear length to lengthOfOpen
                        if (aDoor.DoorType == "Vertical Four Track")
                        {
                            lengthOfStandard += aLinearItem.Length;
                        }
                        else if (aDoor.DoorType == "NoDoor")
                        {
                            lengthOfOpen += aLinearItem.Length;
                        }
                        else
                        {
                            lengthOfStandard += aLinearItem.Length;
                        }
                    }
                    //Mod is a window
                    else if (aMod.ModType == "Window")
                    {
                        Kneewall aKneewall = (Kneewall)aMod.ModularItems[0]; //Kneewall
                        Window aWindow = (Window)aMod.ModularItems[0];
                        if (aKneewall.FLength > 20)
                        {
                            //Add pricing for custom kneewall height
                        }
                        else
                        {

                        }

                        //Add length for fixed vinyl
                        if (aWindow.WindowStyle.Contains("Fixed")) //Possibilities: Fixed Vinyl, Fixed Glass 2", Fixed Glass 3"
                        {
                            lengthOfFixedVinyl += aLinearItem.Length;
                        }
                    }
                    else if (aMod.ModType == "Open" && aLinearItem.Length >= 8)
                    {
                        lengthOfOpen += aLinearItem.Length;
                    }
                    else
                    {
                        lengthOfStandard += aLinearItem.Length;
                    }

                }
                else //Check to see if everything else other than mods are included
                {
                    if (aLinearItem.Length >= 8)
                    {
                        lengthOfSolidWall += aLinearItem.Length;
                        lengthOfStandard -= aLinearItem.Length;
                    }
                }
            }

            //Add various wall pricing types to wall price based on length
            wallPrice += PricingConstants.MODEL_300_VINYL_HORIZONTAL_ROLLER_WINDOW * lengthOfStandard;
            wallPrice += PricingConstants.MODEL_300_SOLID_WALL_PANEL * lengthOfSolidWall;
            wallPrice += PricingConstants.MODEL_300_MANUFACTURED_OPEN_WALLS * lengthOfOpen;
            wallPrice += PricingConstants.MODEL_300_FIXED_WINDOWS * lengthOfFixedVinyl;

            //Find wall height and set appropriate pricing
            if ((aWall.EndHeight > 96 && aWall.EndHeight < 120) || (aWall.StartHeight > 96 && aWall.StartHeight < 120))
            {
                wallPrice += PricingConstants.MODEL_300_NON_STANDARD_PANEL_HEIGHTS * aWall.Length;
            }
            else if (aWall.EndHeight >= 120 || aWall.StartHeight >= 120)
            {
                wallPrice += PricingConstants.MODEL_300_NON_STANDARD_PANEL_HEIGHTS_HIGHER * aWall.Length;
            }

            //Add pricing for fire protection
            if (aWall.FireProtection == true)
            {
                wallPrice += PricingConstants.MODEL_300_FP_HORIZONTAL_ROLLER * lengthOfStandard;
                wallPrice += PricingConstants.MODEL_300_FP_MANUFACTURED_OPEN_WALLS * lengthOfOpen;
                wallPrice += PricingConstants.MODEL_300_FP_SOLID_WALL_PANEL * lengthOfSolidWall;
                wallPrice += PricingConstants.MODEL_300_FP_FIXED_WINDOWS * lengthOfFixedVinyl;
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
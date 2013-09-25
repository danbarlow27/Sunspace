using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class Wall
    {
        #region Attributes

        private float length; //length of the wall in inches
        private int firstItemIndex; //Index of First Item in Wall
        private int lastItemIndex; //Index of Last Item in Wall
        private string orientation; //N, NE, E, S, SE, NW, SW, W
        private string name; //Name of the wall – For project editor referencing
        private string wallType; //type of wall - existing, proposed, full gable wall, partial gable wall, gable post
        private string modelType; 
        private float startHeight; //Start height of the wall
        private float endHeight; //End height of the wall
        private float soffitLength; //Soffit length (only for fascia install)
        private float gablePeak;
        private float totalCornerLength;
        private float totalReceiverLength;
        //private float slope; //slope of the roof that is sitting on this wall
        List<LinearItem> linearItems = new List<LinearItem>();
        List<Object> obstructions = new List<Object>();
        //colours?

        #endregion

        #region Constructors
        public Wall()
        {
            Length = 0.0F;
            FirstItemIndex = -1;
            LastItemIndex = -1;
            Orientation = "";
            Name = "";
            WallType = "";
            StartHeight = 0.0F;
            EndHeight = 0.0F;
            SoffitLength = 0.0F;
            TotalCornerLength = 0.0F;
            TotalReceiverLength = 0.0F;
            ModelType = "";
            GablePeak = 0.0F;
            //Slope = 0.0F;
        }

        //parameterized constructor to create wall objects after we have lengths, heights and doors.
        public Wall(float length, string orientation, string name, string wallType, float startHeight, float endHeight, float soffitLength, string modelType)//, float slope)
        {
            Length = length;
            Orientation = orientation;
            Name = name;
            WallType = wallType;
            StartHeight = startHeight;
            EndHeight = endHeight;
            SoffitLength = soffitLength;
            ModelType = modelType;
            //Slope = slope;
        }

        #endregion

        #region Class Functions

        public float calculateWorkableSpace()
        {
            float workableSpace = Length;
            workableSpace -= TotalCornerLength;
            workableSpace -= TotalReceiverLength;

            return workableSpace;
        }

        public float[] FindOptimalNumberOfMods(float leftFiller, float rightFiller)
        {
            float numberOfMods = 0;
            float optimalModSize = 0;
            float remainingWallLength;

            remainingWallLength = calculateWorkableSpace();
            remainingWallLength -= (leftFiller + rightFiller); 

            if (remainingWallLength > Constants.SOFT_MAX_WINDOW_SIZE)
            {
                numberOfMods = 1;
                optimalModSize = remainingWallLength;

                while (optimalModSize > Constants.SOFT_MAX_WINDOW_SIZE)
                {
                    numberOfMods++;
                    optimalModSize = remainingWallLength / numberOfMods;
                }
            }

            optimalModSize = GlobalFunctions.RoundDownToNearestEighthInch(optimalModSize);

            float extraFiller = remainingWallLength - (optimalModSize * numberOfMods);

            float fillerOne = 2f;
            float fillerTwo = 2f;

            GlobalFunctions.splitFillerToOutside(ref fillerOne, ref fillerTwo, extraFiller);

            return new float[] { numberOfMods, optimalModSize, extraFiller };
        }

        public float[] FindMinimumNumberOfMods(float leftFiller, float rightFiller)
        {
            float numberOfMods = 0;
            float optimalModSize = 0;
            float remainingWallLength;

            remainingWallLength = calculateWorkableSpace();
            remainingWallLength -= (leftFiller + rightFiller);

            numberOfMods = (float)((int)(remainingWallLength / Constants.SOFT_MAX_MOD_SIZE));
            optimalModSize = remainingWallLength / numberOfMods;

            optimalModSize = GlobalFunctions.RoundDownToNearestEighthInch(optimalModSize);

            float extraFiller = remainingWallLength - (optimalModSize * numberOfMods);

            float fillerOne = 2f;
            float fillerTwo = 2f;

            GlobalFunctions.splitFillerToOutside(ref fillerOne, ref fillerTwo, extraFiller);

            return new float[] { numberOfMods, optimalModSize, extraFiller };
        }

        public float[] FindMaximumNumberOfMods(float leftFiller, float rightFiller)
        {
            float numberOfMods = 0;
            float optimalModSize = 0;
            float remainingWallLength;

            remainingWallLength = calculateWorkableSpace();
            remainingWallLength -= (leftFiller + rightFiller);

            numberOfMods = (float)((int)(remainingWallLength / Constants.SOFT_MIN_MOD_SIZE));
            optimalModSize = remainingWallLength / numberOfMods;

            optimalModSize = GlobalFunctions.RoundDownToNearestEighthInch(optimalModSize);

            float extraFiller = remainingWallLength - (optimalModSize * numberOfMods);

            float fillerOne = 2f;
            float fillerTwo = 2f;

            GlobalFunctions.splitFillerToOutside(ref fillerOne, ref fillerTwo, extraFiller);

            return new float[] { numberOfMods, optimalModSize, extraFiller };
        }

        /*
        public String FindOptimalSizeOfMods(int numberOfMods)
        {
            float optimalModSize = 0;
            float remainingWallLength = ProposedLength;
            int noDecimalModSize;

            remainingWallLength -= TotalCornerLength;
            remainingWallLength -= TotalReceiverLength;

            remainingWallLength -= (Constants.DEFAULT_FILLER * 2);

            optimalModSize = remainingWallLength / numberOfMods;
            noDecimalModSize = (int)optimalModSize;

            float decimalRound = optimalModSize - noDecimalModSize;
            float addedToFiller = decimalRound * numberOfMods;

            if (decimalRound > 0.875f)
            {
                decimalRound = 0.875f;
            }
            else if (decimalRound > 0.75f)
            {
                decimalRound = 0.75f;
            }
            else if (decimalRound > 0.625f)
            {
                decimalRound = 0.625f; 
            }
            else if (decimalRound > 0.5f)
            {
                decimalRound = 0.5f;
            }
            else if (decimalRound > 0.375f)
            {
                decimalRound = 0.375f;
            }
            else if (decimalRound > 0.25f)
            {
                decimalRound = 0.25f;
            }
            else
            {
                decimalRound = 0;
            }

            optimalModSize = noDecimalModSize + decimalRound;

            return "Suggested " + numberOfMods + " mods at " + optimalModSize + " inches, adding " + addedToFiller/2 + " inches to both fillers.";
        }
        */

        public void addToItemList(LinearItem anObject)
        {
            linearItems.Add(anObject);
        }

        public float GetHeightAtLocation(float location)
        {
            //slope = rise/run
            //rise = slope*run
            //rise = (trise/trun)*run
            return ((this.EndHeight - this.StartHeight)/this.Length)*location;
        }

        public float FindHighestDoorPunch()
        {
            return 0f;
        }

        public void FillSpaceWithWindows(string windowType, string windowColour, string framingColour, int numberOfVents, float kneewallHeight, string kneewallType, string transomType, 
            bool sunshade, string valance, string fabric, string openness, string chain)
        {
            float currentLocation = 0f;

            //Loop through linear items using currentLocation to keep track
            for (int i = 0; i < LinearItems.Count; i++)
            {
                //If an item starts at this location, we aren't in a workable area
                if (LinearItems[i].FixedLocation == currentLocation)
                {
                    //We set the location equal to the length of the linear item, which is the end of it
                    currentLocation = LinearItems[i].Length;
                }
                //Item must start after current
                else if (LinearItems[i].FixedLocation > currentLocation)
                {
                    //The space is equal to where the next item starts - current location
                    float space = LinearItems[i].FixedLocation - currentLocation;
                    float height;
                    //We have a space, so create a window mod to fill it
                    Mod aMod = new Mod();
                    aMod.FixedLocation = currentLocation;
                    aMod.StartHeight = this.GetHeightAtLocation(currentLocation);
                    aMod.EndHeight = this.GetHeightAtLocation(currentLocation+LinearItems[i].FixedLocation);
                    aMod.ItemType = "Mod";
                    aMod.Length = space;
                    aMod.ModType = "Window";
                    aMod.Sunshade = sunshade;
                    aMod.SunshadeValance = valance;
                    aMod.SunshadeFabric = fabric;
                    aMod.SunshadeOpenness = openness;
                    aMod.SunshadeChain = chain;

                    height = Math.Max(aMod.StartHeight, aMod.EndHeight);

                    //Check for kneewall info
                    if (kneewallHeight > 0)
                    {
                        //Have one
                        Kneewall aKneewall = new Kneewall();
                        aKneewall.FEndHeight = aKneewall.FStartHeight = kneewallHeight;
                        height -= kneewallHeight; //Remove this from usable height, as the kneewall takes it up
                        aKneewall.KneewallType = kneewallType;
                        aKneewall.ItemType = "Kneewall";
                        aKneewall.FLength = space - 2;
                        aMod.ModularItems.Add(aKneewall);
                    }

                    float highestPunch = 0f;
                    //Kneewall will have been added now, or not, either way we add the window
                    //find highest punch
                    for (int j = 0; j < LinearItems.Count; j++)
                    {
                        if (LinearItems[j].ItemType == "Mod")
                        {
                            Mod tempMod = (Mod) LinearItems[j];

                            if (tempMod.ModType == "Door")
                            {
                                //check 0 because door will always be first item in door mod
                                if (((Door)tempMod.ModularItems[0]).Punch > highestPunch)
                                {
                                    highestPunch = ((Door)tempMod.ModularItems[0]).Punch;
                                }
                            }
                        }
                    }

                    //Now we know where the ending height is, so we subtract kneewall to get the height of the window
                    float windowHeight = highestPunch - kneewallHeight;
                    //Create the window
                    Window aWindow = new Window();
                    aWindow.FEndHeight = aWindow.FStartHeight = windowHeight + 2.125f; //CHANGEME hardcoded 2.125
                    aWindow.EndHeight = aWindow.StartHeight = windowHeight;
                    aWindow.FLength = aMod.Length - 2;
                    aWindow.Length = aWindow.FLength - 2f - 2.125f; //CHANGEME hardcoded
                    aWindow.FrameColour = windowColour;
                    aWindow.ItemType = "Window";
                    aWindow.NumVents=numberOfVents;
                    //aWindow.ScreenType; //CHANGEME Dan, if you need to send something for this, send it
                    aWindow.WindowType = windowType;

                    //Check for spreader bar boolean
                    if ((windowType == "Vertical 4 Track" && aWindow.FLength > Constants.V4T_SPREADER_BAR_NEEDED) || 
                        (windowType == "Horizontal Roller" && aWindow.FLength > Constants.HORIZONTAL_ROLLER_SPREADER_BAR_NEEDED))
                    {
                        aWindow.SpreaderBar = true;
                    }
                    else
                    {
                        aWindow.SpreaderBar = false;
                    }

                    aMod.ModularItems.Add(aWindow);

                    //Now we handle transom
                    float modStartWallHeight = GlobalFunctions.getHeightAtPosition(this.StartHeight, this.EndHeight, currentLocation, this.Length);
                    float modEndWallHeight = GlobalFunctions.getHeightAtPosition(this.StartHeight, this.EndHeight, (currentLocation + aMod.Length), this.Length);
                    float spaceAbovePunch = Math.Max(modStartWallHeight, modEndWallHeight) - highestPunch - .25f; //Punch physical space

                    float[] transomInfo = GlobalFunctions.findOptimalHeightsOfWindows(spaceAbovePunch, transomType);

                    if (this.StartHeight == this.EndHeight)
                    {
                        //rectangular window
                        for (int currentWindow = 0; currentWindow < transomInfo[0]; currentWindow++)
                        {
                            //Set window properties
                            Window aTransom = new Window();
                            aTransom.FEndHeight = aTransom.FStartHeight = transomInfo[1];
                            aTransom.EndHeight = aTransom.StartHeight = transomInfo[1] - 2.125f; //Framing size
                            aTransom.Colour = windowColour;
                            aTransom.ItemType = "Window";
                            aTransom.Length = aMod.Length - 2;
                            aTransom.WindowType = transomType;
                            if (currentWindow == 0)
                            {
                                aTransom.FEndHeight += transomInfo[2];
                                aTransom.FStartHeight += transomInfo[2];
                                aTransom.EndHeight += transomInfo[2];
                                aTransom.StartHeight += transomInfo[2];
                            }
                            aMod.ModularItems.Add(aTransom);
                        }
                    }
                    else
                    {
                        //trapezoid
                        for (int currentWindow = 0; currentWindow < transomInfo[0]; currentWindow++)
                        {
                            //Set window properties
                            Window aTransom = new Window();
                            aTransom.FEndHeight = aTransom.FStartHeight = transomInfo[1];
                            aTransom.EndHeight = aTransom.StartHeight = transomInfo[1] - 2.125f;
                            aTransom.Colour = windowColour;
                            aTransom.ItemType = "Window";
                            aTransom.Length = aMod.Length - 2;
                            aTransom.WindowType = transomType;
                            //Add remaining area to first window
                            if (currentWindow == 0)
                            {
                                aTransom.FEndHeight += transomInfo[2];
                                aTransom.FStartHeight += transomInfo[2];
                                aTransom.EndHeight += transomInfo[2];
                                aTransom.StartHeight += transomInfo[2];
                            }
                            //If last window, we need to change a height to make it sloped
                            if (currentWindow == transomInfo[0] - 1)
                            {
                                //If start wall is higher, we lower end height
                                if (modStartWallHeight == Math.Max(modStartWallHeight, modEndWallHeight))
                                {
                                    aTransom.FEndHeight -= (modStartWallHeight - modEndWallHeight);
                                    aTransom.EndHeight -= (modStartWallHeight - modEndWallHeight);
                                }
                                //Otherwise we lower start height
                                else
                                {
                                    aTransom.FStartHeight -= (modEndWallHeight - modStartWallHeight);
                                    aTransom.StartHeight -= (modEndWallHeight - modStartWallHeight);
                                }
                            }
                            aMod.ModularItems.Add(aTransom);
                        }
                    }

                    //float[] windowInfo = GlobalFunctions.findOptimalHeightsOfWindows
                    //Find where to place the mod, and place it
                    for (int j = 0; j < LinearItems.Count; j++)
                    {
                        if (LinearItems[j].FixedLocation > aMod.FixedLocation)
                        {
                            //j is past, so we insert into j-1 and exit the loop
                            LinearItems.Insert(j - 1, aMod);
                            break;
                        }
                    }
                    //Sets currentlocation to the ending location of current linear item
                    currentLocation = currentLocation + space + linearItems[i].Length;
                }
            }
        }
        #endregion

        #region Accessors
        public float Length
        {
            get
            {
                return length;
            }

            set
            {
                length = value;
            }
        }
        
        public int FirstItemIndex
        {
            get
            {
                return firstItemIndex;
            }

            set
            {
                firstItemIndex = value;
            }
        }

        public int LastItemIndex
        {
            get
            {
                return lastItemIndex;
            }

            set
            {
                lastItemIndex = value;
            }
        }

        public string Orientation
        {
            get
            {
                return orientation;
            }

            set
            {
                orientation = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string WallType
        {
            get
            {
                return wallType;
            }

            set
            {
                wallType = value;
            }
        }

        public float StartHeight
        {
            get
            {
                return startHeight;
            }

            set
            {
                startHeight = value;
            }
        }

        public float EndHeight
        {
            get
            {
                return endHeight;
            }

            set
            {
                endHeight = value;
            }
        }

        public float SoffitLength
        {
            get
            {
                return soffitLength;
            }

            set
            {
                soffitLength = value;
            }
        }

        public float TotalCornerLength
        {
            get
            {
                return totalCornerLength;
            }

            set
            {
                totalCornerLength = value;
            }
        }

        public float TotalReceiverLength
        {
            get
            {
                return totalReceiverLength;
            }

            set
            {
                totalReceiverLength = value;
            }
        }

        //public float Slope
        //{
        //    get
        //    {
        //        return slope;
        //    }

        //    set
        //    {
        //        slope = value;
        //    }
        //}

        public List<LinearItem> LinearItems
        {
            get
            {
                return linearItems;
            }

            set
            {
                linearItems = value;
            }
        }

        public List<Object> Obstructions
        {
            get
            {
                return obstructions;
            }

            set
            {
                obstructions = value;
            }
        }

        public string ModelType
        {
            get
            {
                return modelType;
            }

            set
            {
                modelType = value;
            }
        }

        public float GablePeak
        {
            get
            {
                return gablePeak;
            }

            set
            {
                gablePeak = value;
            }
        }
        #endregion
    }
}
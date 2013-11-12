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

        public float[] FindOptimalLengthOfWindowModsGivenSpace(float sentSpace, float MIN_MOD_WIDTH, float MAX_MOD_WIDTH)
        {
            int windowCounter = 0;
            float finalWindowSize = 0;
            float spaceRemaining = sentSpace;

            while (spaceRemaining >= MIN_MOD_WIDTH)
            {
                if (spaceRemaining >= MAX_MOD_WIDTH)
                {
                    spaceRemaining -= MAX_MOD_WIDTH;
                    windowCounter++;
                }
                else if (spaceRemaining < MAX_MOD_WIDTH && spaceRemaining > MIN_MOD_WIDTH)
                {
                    spaceRemaining = 0;
                    windowCounter++;
                }
                else if (spaceRemaining == MIN_MOD_WIDTH)
                {
                    spaceRemaining = 0;
                    windowCounter++;
                }
            }

            if (spaceRemaining > 0 && windowCounter > 0)
            {
                //Should never get here? will always hit one of the spaceRemaining=0 above
                windowCounter++;
                finalWindowSize = sentSpace / windowCounter;
                spaceRemaining = 0;
            }
            else if (spaceRemaining > 0 && windowCounter == 0)
            {
                //Should never get here? will always hit one of the spaceRemaining=0 above
                //add spaceRemaining to filler
                //fillFiller(space, wall, start);
                //spaceRemaining = 0;
            }
            else
            {
                finalWindowSize = sentSpace / windowCounter;
            }

            float roundedWindowSize = GlobalFunctions.RoundDownToNearestEighthInch(finalWindowSize);

            //Set space remaining equal to amount lost via rounding
            //spaceRemaining += finalWindowSize - roundedWindowSize;
            spaceRemaining = sentSpace - (roundedWindowSize * windowCounter);

            //Need to return space * windowcounter, since we lost that amount PER WINDOW
            float[] anArray = { roundedWindowSize, windowCounter, spaceRemaining };
            return (anArray);
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
            float returnValue = 0f;

            if (this.StartHeight == this.EndHeight)
            {
                returnValue = StartHeight;
            }
            else
            {
                //slope = rise/run
                //rise = start-end
                //slope == (start-end)/wallLength
                //height at position = start height + (difference = slope*position)
                returnValue = startHeight + (((endHeight - startHeight) / this.Length) * location);
            }

            return returnValue;
        }

        public float FindHighestDoorPunch()
        {
            return 0f;
        }

        public void FillSpaceWithWindows(string windowType, string windowColour, string framingColour, int numberOfVents, float kneewallHeight, string kneewallType, string transomType, 
            bool sunshade, string valance, string fabric, string openness, string chain, string screenType)
        {
            float currentLocation = 0f;

            //Loop through linear items using currentLocation to keep track
            for (int i = 0; i <= LinearItems.Count; i++)//
            {
                try
                {
                    //If an item starts at this location, we aren't in a workable area
                    if (LinearItems[i].FixedLocation == currentLocation)
                    {
                        //We set the location equal to the length of the linear item, which is the end of it
                        currentLocation += LinearItems[i].Length;
                    }
                    //Item must start after current
                    else if (LinearItems[i].FixedLocation > currentLocation)
                    {
                        //The space is equal to where the next item starts - current location
                        float space = LinearItems[i].FixedLocation - currentLocation;
                        float numOfWindowsInThisSpace = 1; //If the space is too large for one window mod, we need this many
                        float eachSpace = space; //If the space is too large for one window mod, we'll have a # of mods of this size

                        float MAX_MOD_WIDTH = 0;
                        float MIN_MOD_WIDTH = 0;

                        switch (windowType)
                        {
                            case "Vinyl":
                                MIN_MOD_WIDTH = Constants.VINYL_TRAP_MIN_WIDTH_WARRANTY; //We use the trap version because they can have both
                                MAX_MOD_WIDTH = Constants.VINYL_TRAP_MAX_WIDTH_WARRANTY;
                                break;

                            case "Glass":
                                MIN_MOD_WIDTH = Constants.VINYL_TRAP_MIN_WIDTH_WARRANTY; //We use the trap version because they can have both
                                MAX_MOD_WIDTH = Constants.VINYL_TRAP_MAX_WIDTH_WARRANTY;
                                break;

                            case "Vertical 4 Track":
                                MIN_MOD_WIDTH = Constants.V4T_4V_MIN_WIDTH_WARRANTY; //We use the trap version because they can have both
                                MAX_MOD_WIDTH = Constants.V4T_4V_MAX_WIDTH_WARRANTY;
                                break;

                            case "Horizontal 2 Track":
                                MIN_MOD_WIDTH = Constants.HORIZONTAL_ROLLER_MIN_WIDTH_WARRANTY; //We use the trap version because they can have both
                                MAX_MOD_WIDTH = Constants.HORIZONTAL_ROLLER_MAX_WIDTH_WARRANTY;
                                break;

                            case "Horizontal Roller":
                                MIN_MOD_WIDTH = Constants.HORIZONTAL_ROLLER_MIN_WIDTH_WARRANTY; //We use the trap version because they can have both
                                MAX_MOD_WIDTH = Constants.HORIZONTAL_ROLLER_MAX_WIDTH_WARRANTY;
                                break;

                            case "Single Slider":
                                MIN_MOD_WIDTH = Constants.SINGLE_SLIDER_MIN_WIDTH_WARRANTY; //We use the trap version because they can have both
                                MAX_MOD_WIDTH = Constants.SINGLE_SLIDER_MAX_WIDTH_WARRANTY;
                                break;

                            case "Double Slider":
                                MIN_MOD_WIDTH = Constants.DOUBLE_SLIDER_MIN_WIDTH_WARRANTY; //We use the trap version because they can have both
                                MAX_MOD_WIDTH = Constants.DOUBLE_SLIDER_MAX_WIDTH_WARRANTY;
                                break;

                            case "Screen":
                                MIN_MOD_WIDTH = Constants.SCREEN_MIN_WIDTH_WARRANTY; //We use the trap version because they can have both
                                MAX_MOD_WIDTH = Constants.SCREEN_MAX_WIDTH_WARRANTY;
                                break;
                        }

                        //Find optimal lengths of window mods given space
                        float[] windowSpecifics = FindOptimalLengthOfWindowModsGivenSpace(space, MIN_MOD_WIDTH, MAX_MOD_WIDTH);

                        float height;

                        //Loop mod creation for each window counted in this space
                        for (int windowCounter = 0; windowCounter < windowSpecifics[1]; windowCounter++)
                        {
                            //We have a space, so create a window mod to fill it
                            Mod aMod = new Mod();
                            aMod.FixedLocation = currentLocation;
                            aMod.StartHeight = this.GetHeightAtLocation(currentLocation);
                            aMod.EndHeight = this.GetHeightAtLocation(LinearItems[i].FixedLocation);
                            aMod.ItemType = "Mod";
                            aMod.Length = windowSpecifics[0];
                            if (windowCounter == 0)
                            {
                                aMod.Length += windowSpecifics[2];
                            }
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
                                aKneewall.EndHeight = aKneewall.StartHeight = kneewallHeight - 2.125f;
                                height -= kneewallHeight; //Remove this from usable height, as the kneewall takes it up
                                aKneewall.KneewallType = kneewallType;
                                aKneewall.ItemType = "Kneewall";
                                aKneewall.FLength = aMod.Length - 2;
                                aMod.ModularItems.Add(aKneewall);
                            }

                            float highestPunch = 0f;
                            //Kneewall will have been added now, or not, either way we add the window
                            //find highest punch
                            for (int j = 0; j < LinearItems.Count; j++)
                            {
                                if (LinearItems[j].ItemType == "Mod")
                                {
                                    Mod tempMod = (Mod)LinearItems[j];

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
                            
                            //If punch is 0 at this point there are no doors, in such a case, we will set the punch to be a set distance below the min height of the wall
                            //That way we arbitrarily set a location for the transom to start and maintain consistency.
                            if (highestPunch == 0)
                            {
                                highestPunch = Math.Min(aMod.StartHeight, aMod.EndHeight) - 4.125F - Constants.KNEEWALL_PUNCH; //changeme based on type
                            }
                            //Now we know where the ending height is, so we subtract kneewall to get the height of the window
                            //Punch takes up space too, so subtract it as well
                            float windowHeight = highestPunch - kneewallHeight - Constants.KNEEWALL_PUNCH;
                            //Create the window
                            Window aWindow = new Window();
                            aWindow.FEndHeight = aWindow.FStartHeight = windowHeight; //CHANGEME hardcoded 2.125
                            aWindow.RightHeight = aWindow.LeftHeight = windowHeight - 2.125f;
                            aWindow.FLength = aMod.Length - 2;
                            aWindow.Width = aWindow.FLength - 2.125f; //CHANGEME hardcoded
                            aWindow.Colour = windowColour;
                            aWindow.FrameColour = framingColour;
                            aWindow.ItemType = "Window";
                            aWindow.NumVents = numberOfVents;
                            aWindow.ScreenType = screenType; //fixt
                            aWindow.WindowStyle = windowType;

                            //Check for spreader bar boolean
                            if (windowType == "Vertical 4 Track" && aWindow.FLength > Constants.V4T_SPREADER_BAR_NEEDED)
                            {
                                aWindow.SpreaderBar = (aWindow.FLength/2) - (Constants.SPREADER_BAR_SIZE/2); //Find center of window, then place center of spreader bar at that position (by subtracting half of it)
                            }
                            if (windowType == "Horizontal Roller" && aWindow.FLength > Constants.HORIZONTAL_ROLLER_SPREADER_BAR_NEEDED)
                            {
                                aWindow.SpreaderBar = (aWindow.FEndHeight/2) - (Constants.SPREADER_BAR_SIZE/2);
                            }
                            if (windowType == "Vinyl")
                            {
                                if (aWindow.FLength > Constants.TRANSOM_SPREADER_BAR_REQUIRED || aWindow.FEndHeight > Constants.TRANSOM_SPREADER_BAR_REQUIRED || aWindow.FStartHeight > Constants.TRANSOM_SPREADER_BAR_REQUIRED)
                                {
                                    //If length is longer, vertical bar, else horizontal bar
                                    if (aWindow.Width >= aWindow.FEndHeight && aWindow.Width >= aWindow.FStartHeight)
                                    {
                                        aWindow.SpreaderBar = (aWindow.FLength / 2) - (Constants.SPREADER_BAR_SIZE / 2);
                                    }
                                    else
                                    {
                                        aWindow.SpreaderBar = (aWindow.FEndHeight / 2) - (Constants.SPREADER_BAR_SIZE / 2);
                                    }
                                    //If dimensions are equal?
                                }
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
                                    aTransom.FEndHeight = aTransom.FStartHeight = transomInfo[1]; //Window with frame
                                    aTransom.RightHeight = aTransom.LeftHeight = transomInfo[1] - 2.125f; //Window itself
                                    aTransom.Colour = windowColour;
                                    aTransom.ItemType = "Window";
                                    aTransom.Width = aMod.Length - 2;
                                    aTransom.WindowStyle = transomType;
                                    if (currentWindow == 0)
                                    {
                                        aTransom.FEndHeight += transomInfo[2];
                                        aTransom.FStartHeight += transomInfo[2];
                                        aTransom.RightHeight += transomInfo[2];
                                        aTransom.LeftHeight += transomInfo[2];
                                    }

                                    if (aTransom.FLength > Constants.TRANSOM_SPREADER_BAR_REQUIRED || aTransom.FEndHeight > Constants.TRANSOM_SPREADER_BAR_REQUIRED || aTransom.FStartHeight > Constants.TRANSOM_SPREADER_BAR_REQUIRED)
                                    {
                                        //If length is longer, vertical bar, else horizontal bar
                                        if (aTransom.Width > aTransom.FEndHeight && aTransom.Width > aTransom.FStartHeight)
                                        {
                                            aTransom.SpreaderBar = (aTransom.FLength / 2) - (Constants.SPREADER_BAR_SIZE / 2);
                                        }
                                        else
                                        {
                                            aTransom.SpreaderBar = (aTransom.FEndHeight / 2) - (Constants.SPREADER_BAR_SIZE / 2);
                                        }
                                        //If dimensions are equal?
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
                                    aTransom.RightHeight = aTransom.LeftHeight = transomInfo[1] - 2.125f;
                                    aTransom.Colour = windowColour;
                                    aTransom.ItemType = "Window";
                                    aTransom.FLength = aMod.Length - 2;
                                    aTransom.Width = aMod.Length - 2 - 2.125f;
                                    aTransom.WindowStyle = transomType;
                                    //Add remaining area to first window
                                    if (currentWindow == 0)
                                    {
                                        aTransom.FEndHeight += transomInfo[2];
                                        aTransom.FStartHeight += transomInfo[2];
                                        aTransom.RightHeight += transomInfo[2];
                                        aTransom.LeftHeight += transomInfo[2];
                                    }
                                    //If last window, we need to change a height to make it sloped
                                    if (currentWindow == transomInfo[0] - 1)
                                    {
                                        //If start wall is higher, we lower end height
                                        if (modStartWallHeight == Math.Max(modStartWallHeight, modEndWallHeight))
                                        {
                                            aTransom.FEndHeight -= (modStartWallHeight - modEndWallHeight);
                                            aTransom.RightHeight -= (modStartWallHeight - modEndWallHeight);
                                        }
                                        //Otherwise we lower start height
                                        else
                                        {
                                            aTransom.FStartHeight -= (modEndWallHeight - modStartWallHeight);
                                            aTransom.LeftHeight -= (modEndWallHeight - modStartWallHeight);
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
                                    LinearItems.Insert(j, aMod);
                                    break;
                                }
                            }
                            //Sets currentlocation to the ending location of current linear item
                            currentLocation = currentLocation + aMod.Length;
                        }
                    }
                }
                catch (Exception ex)
                {
                    //If caught, it's because we tried to touch the next linear item but it was past the last
                    //Check currentLocation to see if there is still space left
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
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class Wall
    {
        #region Attributes
        private float proposedLength;
        private int firstItemIndex; //Index of First Item in Wall
        private int lastItemIndex; //Index of Last Item in Wall
        private String orientation; //N, NE, E, S, SE, NW, SW, W
        private String name; //Name of the wall – For user few
        private String wallType; 
        private float startHeight; //Start height of the wall
        private float endHeight; //End height of the wall
        private float soffitLength; //Soffit length (only for fascia install)
        private float totalCornerLength;
        private float totalReceiverLength;
        List<Object> linearItems = new List<Object>();
        List<Object> obstructions = new List<Object>();
        #endregion

        #region Constructors
        public Wall()
        {
            ProposedLength = 0.0F;
            FirstItemIndex = -1;
            LastItemIndex = -1;
            Orientation = "";
            Name = "";
            StartHeight = 0.0F;
            EndHeight = 0.0F;
            SoffitLength = 0.0F;
            TotalCornerLength = 0.0f;
            TotalReceiverLength = 0.0f;
        }
        #endregion

        #region Class Functions

        public float calculateWorkableSpace()
        {
            float workableSpace = ProposedLength;
            workableSpace -= TotalCornerLength;
            workableSpace -= TotalReceiverLength;

            return workableSpace;
        }

        public string FindOptimalNumberOfMods(float leftFiller, float rightFiller)
        {
            int numberOfMods = 0;
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

            return "Suggested " + numberOfMods + " mods at " + optimalModSize + " inches, adding " + extraFiller + " inches to filler.";
        }

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

        public void addToItemList(Object anObject)
        {
            linearItems.Add(anObject);
        }

        #endregion

        #region Accessors
        public float ProposedLength
        {
            get
            {
                return proposedLength;
            }

            set
            {
                proposedLength = value;
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

        public String Orientation
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

        public String Name
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

        public List<Object> LinearItems
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

        #endregion
    }
}
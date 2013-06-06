using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class Wall
    {
        private float proposedLength;
        private float actualLength;
        private int firstItemIndex; //Index of First Item in Wall
        private int lastItemIndex; //Index of Last Item in Wall
        private String orientation; //N, NE, E, S, SE, NW, SW, W
        private String name; //Name of the wall – For user few
        private String wallType; //P - Proposed, E - Existing, G - Gable Post
        //private float secondSide; //???????????????
        private float startHeight; //Start height of the wall
        private float endHeight; //End height of the wall
        //private bool isGableWall; //????????????????
        //private bool customHeight; //???????????????
        private float soffit; //Soffit length (only for fascia install)
        private float totalCornerLength;
        private float totalReceiverLength;
        /*
         * ??NOT SURE IF THESE ARE REQUIRED
            ExistingKneewall As Single
            ExistingWidth As Single
            ExistingRight As Boolean
            ExistingDrawBrick As Boolean
 
         */

        public Wall()
        {
            ProposedLength = 0.0F;
            ActualLength = 0.0F;
            FirstItemIndex = -1;
            LastItemIndex = -1;
            Orientation = "";
            Name = "";
            StartHeight = 0.0F;
            EndHeight = 0.0F;
            Soffit = 0.0F;
            TotalCornerLength = 0.0f;
            TotalReceiverLength = 0.0f;
        }

        public String FindOptimalNumberOfMods()
        {
            int numberOfMods = 0;
            float optimalModSize = 0;
            float remainingWallLength = ProposedLength;
            float DEFAULT_FILLER = 2.0F; //constants module?
            int noDecimalModSize;

            float SOFT_MIN_WINDOW_SIZE = 30.0F; //inches
            float SOFT_MAX_WINDOW_SIZE = 58.0F; //inches

            remainingWallLength -= TotalCornerLength;
            remainingWallLength -= TotalReceiverLength;
            remainingWallLength -= (DEFAULT_FILLER * 2);

            if (remainingWallLength > SOFT_MAX_WINDOW_SIZE)
            {
                numberOfMods = 1;
                optimalModSize = remainingWallLength;

                while (optimalModSize > SOFT_MAX_WINDOW_SIZE)
                {
                    numberOfMods++;
                    optimalModSize = remainingWallLength / numberOfMods;
                }
            }

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

            return "Suggested " + numberOfMods + " mods at " + optimalModSize + " inches, adding " + addedToFiller / 2 + " inches to both fillers.";
        }

        public String FindOptimalSizeOfMods(int numberOfMods)
        {
            float optimalModSize = 0;
            float remainingWallLength = ProposedLength;
            float DEFAULT_FILLER = 2.0F; //constants module?
            int noDecimalModSize;

            remainingWallLength -= TotalCornerLength;
            remainingWallLength -= TotalReceiverLength;

            remainingWallLength -= (DEFAULT_FILLER * 2);

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

        public float ActualLength
        {
            get
            {
                return actualLength;
            }

            set
            {
                actualLength = value;
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

        public float Soffit
        {
            get
            {
                return soffit;
            }

            set
            {
                soffit = value;
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
    }
}
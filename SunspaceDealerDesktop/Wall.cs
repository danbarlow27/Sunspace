﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class Wall
    {
        private float length; //Total Width Of Wall (in inches)
        private int firstItemIndex; //Index of First Item in Wall
        private int lastItemIndex; //Index of Last Item in Wall
        private String orientation; //N, NE, E, S, SE, NW, SW, W
        private String name; //Name of the wall – For user few
        private bool isExisting; //True if Wall exists
        //private float secondSide; //???????????????
        private float startHeight; //Start height of the wall
        private float endHeight; //End height of the wall
        //private bool isGableWall; //????????????????
        //private bool customHeight; //???????????????
        private float soffit; //Soffit length (only for fascia install)

        /*
         * ??NOT SURE IF THESE ARE REQUIRED
            ExistingKneewall As Single
            ExistingWidth As Single
            ExistingRight As Boolean
            ExistingDrawBrick As Boolean
 
         */

        public Wall()
        {
            Length = 0.0F;
            FirstItemIndex = -1;
            LastItemIndex = -1;

        }

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

        public bool IsExisting
        {
            get
            {
                return isExisting;
            }

            set
            {
                isExisting = value;
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
    }
}
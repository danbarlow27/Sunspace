using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class LinearItem
    {
        #region Attributes
        private int linearIndex;
        private string itemType; //Mod, boxheader, chase, etc.
        private float startHeight;
        private float endHeight;
        private float length;
        private string frameColour;
        private string sex;
        private float fixedLocation; //The position (in inches) this item is in the wall
        private bool attachedTo;
        

        #endregion

        #region Constructors
        public LinearItem() { }

        public LinearItem(string sentType)
        {
            ItemType = sentType;
        }
        #endregion

        #region Class Functions

        #endregion

        #region Accessors

        public int LinearIndex
        {
            get
            {
                return linearIndex;
            }

            set
            {
                linearIndex = value;
            }
        }

        public string ItemType
        {
            get
            {
                return itemType;
            }
            set
            {
                itemType = value;
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

        public string FrameColour
        {
            get 
            {
                return frameColour;
            }
            set
            {
                frameColour = value;
            }
        }

        public string Sex
        {
            get
            {
                return sex;
            }
            set
            {
                sex = value;
            }
        }

        public float FixedLocation
        {
            get
            {
                return fixedLocation;
            }
            set
            {
                fixedLocation = value;
            }
        }

        public bool AttachedTo
        {
            get
            {
                return attachedTo;
            }
            set
            {
                attachedTo = value;
            }
        }
        
        #endregion
    }
}
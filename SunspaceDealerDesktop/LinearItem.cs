using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class LinearItem
    {
        #region Attributes
        private string itemType; //Mod, boxheader, chase, etc.
        private float fixedLocation; //The position (in inches) this item is in the wall
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
        #endregion
    }
}
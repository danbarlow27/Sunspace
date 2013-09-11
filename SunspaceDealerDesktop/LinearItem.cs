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
        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class RoofItem
    {
        #region Attributes
        private string itemType; //Receiver, Awning Track, I-Beam, Pressure Cap I-Beam, Foam Panel, Acrylic Panel, T-Bar
        private float projection;
        private float width;
        #endregion

        #region Constructors
        public RoofItem()
        {
            ItemType = "";
            Projection = 0;
            Width = 0;
        }

        public RoofItem(string sentItemType, float sentProjection, float sentWidth)
        {
            ItemType = sentItemType;
            Projection = sentProjection;
            Width = sentWidth;
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
        public float Projection
        {
            get
            {
                return projection;
            }
            set
            {
                projection = value;
            }
        }
        public float Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
            }
        }
        #endregion
    }
}
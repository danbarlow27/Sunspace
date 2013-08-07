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
        private double projection;
        private double width;
        #endregion

        #region Constructors
        public RoofItem()
        {
            ItemType = "";
            Projection = 0;
            Width = 0;
        }

        public RoofItem(string sentItemType, double sentProjection, double sentWidth)
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
        public double Projection
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
        public double Width
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
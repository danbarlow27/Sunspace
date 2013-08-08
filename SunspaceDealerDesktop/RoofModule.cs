using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class RoofModule
    {
        #region Attributes
        private double projection;  
        private double width;
        private string interiorSkin;
        private string exteriorSkin;
        private List<RoofItem> roofItems;
        #endregion

        #region Constructors
        public RoofModule()
        {
            Projection = 0;
            Width = 0;
            InteriorSkin = "";
            ExteriorSkin = "";
        }

        public RoofModule(double sentProjection, double sentWidth, string sentInteriorSkin, string sentExteriorSkin, List<RoofItem> sentRoofItems)
        {
            Projection = sentProjection;
            Width = sentWidth;
            InteriorSkin = sentInteriorSkin;
            ExteriorSkin = sentExteriorSkin;
            RoofItems = sentRoofItems;
        }
        #endregion

        #region Class Functions

        #endregion

        #region Accessors
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
        public string InteriorSkin
        {
            get
            {
                return interiorSkin;
            }
            set
            {
                interiorSkin = value;
            }
        }
        public string ExteriorSkin
        {
            get
            {
                return exteriorSkin;
            }
            set
            {
                exteriorSkin = value;
            }
        }
        public List<RoofItem> RoofItems
        {
            get
            {
                return roofItems;
            }
            set
            {
                roofItems = value;
            }
        }
        #endregion
    }
}
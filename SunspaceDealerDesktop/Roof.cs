using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class Roof
    {
        #region Attributes
        private string type;
        private string interiorSkin;
        private string exteriorSkin;
        private double thickness;
        private bool fireProtection;
        private bool thermadeck;
        private bool gutters;
        private bool gutterPro;
        private string gutterColour;
        private string stripeColour;
        private int numberSupports;
        private double projection;
        private double width;
        private List<RoofModule> roofModules; //a list of roof modules that make up this roof
        #endregion

        #region Constructors
        public Roof()
        {
            Type="";
            InteriorSkin="";
            ExteriorSkin="";
            Thickness=0;
            FireProtection=false;
            Thermadeck=false;
            Gutters=false;
            GutterPro=false;
            GutterColour = "";
            StripeColour = "";
            NumberSupports=0;
            Projection=0;
            Width=0;
            RoofModules = new List<RoofModule>();
        }

        public Roof(string sentType, string sentInteriorSkin, string sentExteriorSkin, double sentThickness, bool sentFireProtection, bool sentThermadeck, bool sentGutters, bool sentGutterPro, string sentGutterColour, string sentStripeColour, int sentNumberSupports, double sentProjection, double sentWidth, List<RoofModule> sentModules)
        {
            Type = sentType;
            InteriorSkin = sentInteriorSkin;
            ExteriorSkin = sentExteriorSkin;
            Thickness = sentThickness;
            FireProtection = sentFireProtection;
            Thermadeck = sentThermadeck;
            Gutters = sentGutters;
            GutterPro = sentGutterPro;
            GutterColour = sentGutterColour;
            StripeColour = sentStripeColour;
            NumberSupports = sentNumberSupports;
            Projection = sentProjection;
            Width = sentWidth;
            RoofModules = sentModules;
        }
        #endregion

        #region Class Functions
        #endregion

        #region Accessors
        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
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

        public double Thickness
        {
            get
            {
                return thickness;
            }

            set
            {
                thickness = value;
            }
        }

        public bool FireProtection
        {
            get
            {
                return fireProtection;
            }

            set
            {
                fireProtection = value;
            }
        }

        public bool Thermadeck
        {
            get
            {
                return thermadeck;
            }

            set
            {
                thermadeck = value;
            }
        }

        public bool Gutters
        {
            get
            {
                return gutters;
            }

            set
            {
                gutters = value;
            }
        }

        public bool GutterPro
        {
            get
            {
                return gutterPro;
            }

            set
            {
                gutterPro = value;
            }
        }

        public string GutterColour
        {
            get
            {
                return gutterColour;
            }

            set
            {
                gutterColour = value;
            }
        }

        public string StripeColour
        {
            get
            {
                return stripeColour;
            }

            set
            {
                stripeColour = value;
            }
        }

        public int NumberSupports
        {
            get
            {
                return numberSupports;
            }

            set
            {
                numberSupports = value;
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

        public List<RoofModule> RoofModules
        {
            get
            {
                return roofModules;
            }

            set
            {
                roofModules = value;
            }
        }
        #endregion Acessors
    }
}
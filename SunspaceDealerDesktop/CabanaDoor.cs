using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class CabanaDoor : Door
    {
        #region Attributes
        private float height = 0f;          //Door height: 80" (stored value: 80)
        private float length = 0f;          //Door width: 30" (stored value: 30)
        private string vinylTint = null;    //Door vinyl tint: Smoke Grey, DarkGrey, Bronze, Clear, Mixed (stored value: Smoke Grey)
        private string screenType = null;   //Door screen type: Better Vue Insect Screen, No See Ums 20x20 Mesh, Solar Insect Screening, Tuff Screen, No Screen (stored value: Better Vue Insect Screen)
        private string glassTint = null;    //Door glass tint: Grey, Bronze, Clear
        private string hinge = null;        //Door hinge placement: Left or Right (stored value: Left)
        private string swing = null;        //Door swing: In or Out (stored value: In)
        private string hardwareType = null; //Door hardware type: Satin Silver, Bright Brass, Antique Brass (stored value: Satin Silver)
        #endregion

        #region Constructor
        public CabanaDoor() : base() {}
        #endregion

        #region Accessors
        public float Height
        {
            get
            {
                return height;
            }

            set
            {
                height = value;
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
        public string VinylTint
        {
            get
            {
                return vinylTint;
            }

            set
            {
                vinylTint = value;
            }
        }
        public string GlassTint
        {
            get
            {
                return glassTint;
            }

            set
            {
                glassTint = value;
            }
        }
        public string ScreenType
        {
            get
            {
                return screenType;
            }

            set
            {
                screenType = value;
            }
        }
        public string Hinge
        {
            get
            {
                return hinge;
            }

            set
            {
                hinge = value;
            }
        }
        public string Swing
        {
            get
            {
                return swing;
            }

            set
            {
                swing = value;
            }
        }
        public string HardwareType
        {
            get
            {
                return hardwareType;
            }

            set
            {
                hardwareType = value;
            }
        }
        #endregion
    }
}
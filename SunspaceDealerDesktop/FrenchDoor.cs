using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class FrenchDoor : Door
    {
        #region Attributes
        private float height = 0f;
        private float length = 0f;
        private string vinylTint = null;
        private string screenType = null;
        private string glassTint = null;
        private string swing = null;
        private string operatingDoor = null; //Can't use operator, C# built in function/method
        private string hardwareType = null;
        private string numberVents = null;
        #endregion

        #region Constructor
        public FrenchDoor() : base() {}
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
        public string OperatingDoor
        {
            get
            {
                return operatingDoor;
            }

            set
            {
                operatingDoor = value;
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
        public string NumberVents
        {
            get
            {
                return numberVents;
            }

            set
            {
                numberVents = value;
            }
        }
        #endregion
    }
}
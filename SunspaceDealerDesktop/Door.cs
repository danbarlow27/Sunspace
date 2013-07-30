using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class Door
    {
        #region Attributes
        private int itemIndex = 0; //LinearItems Array Index
        private string doorType = null; //Type of Door
        private string doorStyle = null;
        private string screenType = null;
        private float fHeight = 0f; //Height of Door
        private float fLength = 0f; //Width of Door
        private string colour = null;
        #endregion

        #region Constructor
        public Door() {}
        #endregion

        #region Accessors
        public int ItemIndex
        {
            get
            {
                return itemIndex;
            }

            set
            {
                itemIndex = value;
            }
        }
        public String DoorType
        {
            get
            {
                return doorType;
            }

            set
            {
                doorType = value;
            }
        }              
        public String DoorStyle
        {
            get
            {
                return doorStyle;
            }

            set
            {
                doorStyle = value.ToLower();
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
        public float FHeight
        {
            get
            {
                return fHeight;
            }

            set
            {
                fHeight = value;
            }
        }
        public float FLength
        {
            get
            {
                return fLength;
            }

            set
            {
                fLength = value;
            }
        }
        public string Colour
        {
            get
            {
                return colour;
            }

            set
            {
                colour = value;
            }
        }
        #endregion

        /*
        bool patioXO; //??????????????
        int glassTint; 
        bool cabanaSwingOut;
        bool cabanaLHH;
        bool boxHeader;
        bool boxHeader2;
        float kneewallHeight;
        int hardware;
        int ventCount;
        bool customWidth;
        bool customHeight;
        bool doubleTransom;
        bool temperedTransom;
        String mixedTint;
        bool isFrench;
        bool priLeft;
        bool hasGrills;
        int sunShade; //1 = control Left, 2 = control right
        */
    }
}
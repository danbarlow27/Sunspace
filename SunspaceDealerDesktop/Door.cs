using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class Door : ModuleItem
    {
        #region Attributes
        private string doorType = null;     //Door type: Cabana, French, Patio, NoDoor (stored value: Cabana)
        private string doorStyle = null;    //Door style: Full View, Vertical Four Track, Full View Colonial, etc... (stored value: Full View)
        private string screenType = null;   //Door screen type: Better Vue Insect Screen, No See Ums 20x20 Mesh, Solar Insect Screening, Tuff Screen, No Screen (stored value: Better Vue Insect Screen)
        private float kickplate = 0f;       //Door kickplate height: 6" (stored value: 6)
        private float punch = 0f;           //Door header punch location
        #endregion

        #region Constructor
        public Door() {}
        #endregion

        #region Accessors
        public string DoorType
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
        public string DoorStyle
        {
            get
            {
                return doorStyle;
            }

            set
            {
                doorStyle = value;
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
        public float Kickplate
        {
            get
            {
                return kickplate;
            }

            set
            {
                kickplate = value;
            }
        }
        public float Punch
        {
            get
            {
                return punch;
            }
            set
            {
                punch = value;
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
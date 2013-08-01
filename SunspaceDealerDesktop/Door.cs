using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class Door
    {
        #region Attributes
        private int itemIndex = 0;          //LinearItems Array Index (stored value: 1)
        private string doorType = null;     //Door type: Cabana, French, Patio, NoDoor (stored value: Cabana)
        private string doorStyle = null;    //Door style: Full View, Vertical Four Track, Full View Colonial, etc... (stored value: Full View)
        private string screenType = null;   //Door screen type: Better Vue Insect Screen, No See Ums 20x20 Mesh, Solar Insect Screening, Tuff Screen, No Screen (stored value: Better Vue Insect Screen)
        private float fHeight = 0f;         //Door height including frame: 79.125" (stored value: 79.125)
        private float fLength = 0f;         //Door lenth including frame: 32.125" (stored value: 32.125)
        private string colour = null;       //Door colour: White, Driftwood, Bronze, Green, Black, Ivory, Cherrywood, Grey (stored value: White)
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
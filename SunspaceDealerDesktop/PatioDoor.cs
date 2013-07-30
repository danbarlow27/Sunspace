using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class PatioDoor : Door
    {
        #region Attributes
        private float height;
        private float length;
        private string screenType;
        private string glassTint;
        private string movingDoor;
        #endregion

        #region Constructor
        public PatioDoor() : base() {}
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
        public string MovingDoor
        {
            get
            {
                return movingDoor;
            }

            set
            {
                movingDoor = value;
            }
        }
        #endregion
    }
}
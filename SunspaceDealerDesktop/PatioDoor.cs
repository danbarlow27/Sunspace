using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class PatioDoor : Door
    {
        #region Attributes
        private float height = 0f;          //Door height: 80" (stored value: 80)
        private float length = 0f;          //Door width: 30" (stored value: 30)
        private string screenType = null;   //Door screen type: Better Vue Insect Screen, No See Ums 20x20 Mesh, Solar Insect Screening, Tuff Screen, No Screen (stored value: Better Vue Insect Screen)
        private string glassTint = null;    //Door glass tint: Grey, Bronze, Clear (stored value: Grey)
        private string movingDoor = null;   //Door moving door: Left or Right (stored value: Left)
        private string operatingDoor = null;    //Door operator: Left or Right (stored value: Left), can't use operator C# built in function/method
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
        #endregion
    }
}
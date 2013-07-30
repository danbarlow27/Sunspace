using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class OpenSpaceDoor : Door
    {
        #region Attributes
        private float height = 0f;
        private float length = 0f;
        #endregion

        #region Constructor
        public OpenSpaceDoor() : base() {}
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
        #endregion

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class OpenSpaceDoor : Door
    {
        #region Attributes
        private float height = 0f;  //Door height: 80" (stored value: 80)
        private float length = 0f;  //Door width: 30" (stored value: 30)
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
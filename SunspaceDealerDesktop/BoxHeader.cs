using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class BoxHeader
    {
        #region Attributes
        private float length;
        #endregion

        #region Constructors
        public BoxHeader()
        {
            length = 3.25f;
        }
        #endregion

        #region Accessors

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
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
        /// <summary>
        /// Instantiate a new boxHeader at constant lengths, based on true/false whether or not it is a boxHeader/Receiever piece.
        /// </summary>
        /// <param name="receiever">true if this is a boxHeader receiever, otherwise false.</param>
        public BoxHeader(bool receiever)
        {
            if (receiever == true)
            {
                Length = Constants.BOXHEADER_RECEIVER_LENGTH;
            }
            else
            {
                Length = Constants.BOXHEADER_LENGTH;
            }
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class BoxHeader
    {
        #region Attributes
        private float width;
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
        public BoxHeader(bool receiever, float sentWidth)
        {
            if (receiever == true)
            {
                Length = Constants.BOXHEADER_RECEIVER_LENGTH;
            }
            else
            {
                Length = Constants.BOXHEADER_LENGTH;
            }
            Width = sentWidth;
        }
        #endregion

        #region Accessors
        /// <summary>
        /// The length of a boxheader refers to it's thickness, or it's girth.  On a vertical boxheader, it is left to right
        /// commonly a small number of inches. On a horizontal box header, it is bottom to top, corresponding to the same dimension
        /// in another direction.
        /// </summary>
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
        /// <summary>
        /// The width of a boxheader refers to it's projection, or it's height.  On a vertical boxheader, it is bottom to top
        /// commonly a longer number of inches. On a horizontal box header, it is left to right, corresponding to the same dimension
        /// in another direction.
        /// </summary>
        public float Width
        {
            get
            {
                return width;
            }

            set
            {
                width = value;
            }
        }
        #endregion
    }
}
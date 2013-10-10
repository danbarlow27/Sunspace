using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class BoxHeader : LinearItem
    {
        #region Attributes
        private bool isReceiver;
        private bool isTwoPiece;
        #endregion

        #region Constructors
        public BoxHeader() { }
        #endregion

        #region Accessors
        public bool IsReceiver
        {
            get
            {
                return isReceiver;
            }
            set
            {
                isReceiver = value;
            }
        }
        public bool IsTwoPiece
        {
            get
            {
                return isTwoPiece;
            }
            set
            {
                isTwoPiece = value;
            }
        }
        #endregion
    }
}
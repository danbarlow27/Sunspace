using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class BoxHeader : LinearItem
    {
        #region Attributes
        private bool hasReceiver;
        private bool isTwoPiece;
        #endregion

        #region Constructors
        public BoxHeader() { }
        #endregion

        #region Accessors
        public bool HasReceiver
        {
            get
            {
                return hasReceiver;
            }
            set
            {
                hasReceiver = value;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class Kneewall : ModuleItem
    {
        #region Attributes
        private string kneewallType = "";       //What type of kneewall it is, glass, panel, etc
        private float startHeight;
        private float endHeight;
        private float length;
        private string frameColour;
        private bool spreaderBar;
        #endregion

        #region Constructors
        public Kneewall() { }
        #endregion

        #region Accessors
        public string KneewallType
        {
            get
            {
                return kneewallType;
            }
            set
            {
                kneewallType = value;
            }
        }
        public float StartHeight
        {
            get
            {
                return startHeight;
            }
            set
            {
                startHeight = value;
            }
        }

        public float EndHeight
        {
            get
            {
                return endHeight;
            }
            set
            {
                endHeight = value;
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

        public string FrameColour
        {
            get
            {
                return frameColour;
            }
            set
            {
                frameColour = value;
            }
        }

        public bool SpreaderBar
        {
            get
            {
                return spreaderBar;
            }
            set
            {
                spreaderBar = value;
            }
        }
        #endregion
    }
}
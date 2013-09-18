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
        private string colour = null;       //handles both tints and panel textures
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
        public string Colour
        {
            get
            {
                return colour;
            }
            set
            {
                colour = value;
            }
        }
        #endregion
    }
}
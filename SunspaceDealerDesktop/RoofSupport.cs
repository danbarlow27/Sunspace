using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    //NOTE: Maybe unnecessary, could just hold a list of sizes repeatedly
    public class RoofSupport
    {
        #region Attributes
        private int height;
        #endregion

        public RoofSupport() {
            height = 0;
        }

        public RoofSupport(int sentHeight)
        {
            height = sentHeight;
        }

        public int Height
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
    }
}
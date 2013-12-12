using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class RoofSupport
    {
        #region Attributes
        private double height;
        #endregion

        public RoofSupport() {
            height = 0;
        }

        public RoofSupport(double sentHeight)
        {
            height = sentHeight;
        }
    }
}
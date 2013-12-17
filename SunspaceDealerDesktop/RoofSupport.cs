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
        private int height;     //7', 8', 9', 10'
        private int width;      //3", 6"
        private string type;    //Fluted (3"), Railing (6")
        #endregion

        #region Constructors
        public RoofSupport() {
            Height = 0;
            Width = 0;
            Type = "";
        }

        public RoofSupport(int sentHeight, int sentWidth, string sentType)
        {
            Height = sentHeight;
            Width = sentWidth;
            Type = sentType;
        }
        #endregion

        #region Accessor
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

        public int Width
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

        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }
        #endregion
    }
}
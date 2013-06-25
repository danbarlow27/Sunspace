using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class Mod
    {
        #region Attributes

        private int linearIndex;
        private bool sunshade;
        private float fixedValue;
        List<Object> modularItems = new List<Object>();

        #endregion

        #region Constructors

        public Mod()
        {
            LinearIndex = 0;
            Sunshade = false;
            FixedValue = 0.0f;
        }

        #endregion

        #region Accessors

        public int LinearIndex
        {
            get
            {
                return linearIndex;
            }

            set
            {
                linearIndex = value;
            }
        }

        public bool Sunshade
        {
            get
            {
                return sunshade;
            }

            set
            {
                sunshade = value;
            }
        }

        public float FixedValue
        {
            get
            {
                return fixedValue;
            }
            set
            {
                fixedValue = value;
            }
        }

        #endregion
    }
}
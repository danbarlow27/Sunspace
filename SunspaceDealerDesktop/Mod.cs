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
        private float fixedLocation;
        private string modType;
        List<Object> modularItems = new List<Object>();

        #endregion

        #region Constructors

        public Mod()
        {
            LinearIndex = 0;
            Sunshade = false;
            FixedLocation = 0.0f;
            ModType = "";
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

        public List<Object> ModularItems
        {
            get
            {
                return modularItems;
            }

            set
            {
                modularItems = value;
            }
        }
        public float FixedLocation
        {
            get
            {
                return fixedLocation;
            }
            set
            {
                fixedLocation = value;
            }
        }

        public string ModType
        {
            get
            {
                return modType;
            }
            set
            {
                modType = value;
            }
        }

        #endregion Accessors
    }
}
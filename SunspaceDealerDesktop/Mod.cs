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
        private float visibleSpace;
        private float physicalSpace;
        private float usableSpace;
        List<Object> modularItems = new List<Object>();

        #endregion

        #region Constructors

        public Mod()
        {
            LinearIndex = 0;
            Sunshade = false;
            FixedLocation = 0.0f;
            ModType = "";
            VisibleSpace = 0f;
            PhysicalSpace = 0f;
            UsableSpace = 0f;
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
        public float VisibleSpace
        {
            get
            {
                return visibleSpace;
            }
            set
            {
                visibleSpace = value;
            }
        }
        public float PhysicalSpace
        {
            get
            {
                return physicalSpace;
            }
            set
            {
                physicalSpace = value;
            }
        }
        public float UsableSpace
        {
            get
            {
                return usableSpace;
            }
            set
            {
                usableSpace = value;
            }
        }
        
        #endregion Accessors
    }
}
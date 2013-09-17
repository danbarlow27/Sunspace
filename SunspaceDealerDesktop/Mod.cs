using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class Mod : LinearItem
    {
        #region Attributes

        private int linearIndex;
        private bool sunshade;
        private string modType;
        private float height;
        private float length;
        private string sex; //MM MF FM FF
        List<ModuleItem> modularItems = new List<ModuleItem>();

        #endregion

        #region Constructors

        public Mod()
        {
            this.ItemType = "Mod";
            LinearIndex = 0;
            Sunshade = false;
            FixedLocation = 0.0f;
            ModType = "";
            Height = 0f;
            Length = 0f;
            Sex = "";
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

        public List<ModuleItem> ModularItems
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
        public float Height
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

        public string Sex
        {
            get
            {
                return sex;
            }
            set
            {
                sex = value;
            }
        }
        #endregion Accessors
    }
}
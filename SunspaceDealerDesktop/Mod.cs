using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class Mod : LinearItem
    {
        #region Attributes

        private bool sunshade;
        private string sunshadeValance;
        private string sunshadeFabric;
        private string sunshadeOpenness;
        private string sunshadeChain;
        private string modType;
        private string sex; //MM MF FM FF
        List<ModuleItem> modularItems = new List<ModuleItem>();

        #endregion

        #region Constructors

        public Mod()
        {
            this.ItemType = "Mod";
            Sunshade = false;
            SunshadeValance = "";
            SunshadeFabric = "";
            SunshadeOpenness = "";
            SunshadeChain = "";
            FixedLocation = 0.0f;
            ModType = "";
            Sex = "";
        }

        #endregion

        #region Accessors       

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

        public string SunshadeValance
        {
            get
            {
                return sunshadeValance;
            }

            set
            {
                sunshadeValance = value;
            }
        }

        public string SunshadeFabric
        {
            get
            {
                return sunshadeFabric;
            }

            set
            {
                sunshadeFabric = value;
            }
        }

        public string SunshadeOpenness
        {
            get
            {
                return sunshadeOpenness;
            }

            set
            {
                sunshadeOpenness = value;
            }
        }

        public string SunshadeChain
        {
            get
            {
                return sunshadeChain;
            }

            set
            {
                sunshadeChain = value;
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
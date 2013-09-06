using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class ModuleItem
    {
        #region Attributes
        private int moduleIndex = 0;         //ModuleItems Array Index (stored value: 1)
        private string itemType = "";       //What type of module item it is: door, window, etc.
        private float fHeight = 0f;         //Item height including frame: 79.125" (stored value: 79.125)
        private float fLength = 0f;         //Item lenth including frame: 32.125" (stored value: 32.125)
        private string colour = null;       //Door colour: White, Driftwood, Bronze, Green, Black, Ivory, Cherrywood, Grey (stored value: White)
        #endregion

        #region Constructor
        public ModuleItem() { }
        #endregion

        #region Accessors    
        public int ModuleIndex
        {
            get
            {
                return moduleIndex;
            }
            set
            {
                moduleIndex = value;
            }
        }
        public string ItemType
        {
            get
            {
                return itemType;
            }
            set
            {
                itemType = value;
            }
        }
        public float FHeight
        {
            get
            {
                return fHeight;
            }

            set
            {
                fHeight = value;
            }
        }
        public float FLength
        {
            get
            {
                return fLength;
            }

            set
            {
                fLength = value;
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
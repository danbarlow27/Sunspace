using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class Window
    {
        #region Attributes

        private int linearIndex;
        private int moduleIndex;
        private string windowType;
        private string screenType;
        private float startHeight;
        private float endHeight;
        private float length;
        private string frameColour;
        private bool spreaderBar;
        private int numVents;

        #endregion

        #region Constructors

        public Window()
        {
            LinearIndex = 0;
            ModuleIndex = 0;
            WindowType = "";
            ScreenType = "";
            StartHeight = 0.0f;
            EndHeight = 0.0f;
            Length = 0.0f;
            FrameColour = "";
            SpreaderBar = false;
            NumVents = 0;
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

        public string WindowType
        {
            get
            {
                return windowType;
            }
            set
            {
                windowType = value;
            }
        }

        public string ScreenType
        {
            get
            {
                return screenType;
            }
            set
            {
                screenType = value;
            }
        }

        public float StartHeight
        {
            get
            {
                return startHeight;
            }
            set
            {
                startHeight = value;
            }
        }

        public float EndHeight
        {
            get
            {
                return endHeight;
            }
            set
            {
                endHeight = value;
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

        public string FrameColour
        {
            get
            {
                return frameColour;
            }
            set
            {
                frameColour = value;
            }
        }

        public bool SpreaderBar
        {
            get
            {
                return spreaderBar;
            }
            set
            {
                spreaderBar = value;
            }
        }

        public int NumVents
        {
            get
            {
                return numVents;
            }
            set
            {
                numVents = value;
            }
        }

        #endregion
    }
}
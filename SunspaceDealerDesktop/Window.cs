using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class Window : ModuleItem
    {
        #region Attributes
        private string windowStyle;
        private string screenType;
        private float leftHeight;
        private float rightHeight;
        private float width;
        private string frameColour;
        private float spreaderBar; //this is in vinyl window class, but here also to suppress errors
        private int numVents; //this is in vinyl window class, but here also to suppress errors
        private double integratedRailing;
        #endregion

        #region Constructors

        public Window()
        {
            WindowStyle = "";
            ScreenType = "";
            LeftHeight = 0.0f;
            RightHeight = 0.0f;
            Width = 0.0f;
            FrameColour = "";
            //SpreaderBar = -1f;
            //NumVents = 0;
            IntegratedRailing = -1;
        }

        #endregion

        #region Accessors
        public string WindowStyle
        {
            get
            {
                return windowStyle;
            }
            set
            {
                windowStyle = value;
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

        public float LeftHeight
        {
            get
            {
                return leftHeight;
            }
            set
            {
                leftHeight = value;
            }
        }

        public float RightHeight
        {
            get
            {
                return rightHeight;
            }
            set
            {
                rightHeight = value;
            }
        }

        public float Width
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

        public float SpreaderBar  //this is in vinyl window class, but here also to suppress errors
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

        public int NumVents  //this is in vinyl window class, but here also to suppress errors
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

        public double IntegratedRailing
        {
            get
            {
                return integratedRailing;
            }
            set
            {
                integratedRailing = value;
            }
        }

        #endregion
    }
}
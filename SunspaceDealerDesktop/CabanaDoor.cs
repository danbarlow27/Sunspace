using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class CabanaDoor
    {
        #region Attributes
        private float width;
        private float height; //79.125 if 2", 82.125 if 3"
        private string swingDirection; //in or out
        private string hingePosition; //Left or Right
        private string boxHeader; //Left, right, both. Must have one on hinge, must have one on strike if it meets solid wall
        #endregion

        #region Constructors
        public CabanaDoor()
        {
            width = 0f;
            height = 79.125f;
            swingDirection = "out";
            hingePosition = "left";
            boxHeader = "left";
        }
        #endregion

        #region Accessors
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
        public string SwingDirection
        {
            get
            {
                return swingDirection;
            }

            set
            {
                swingDirection = value;
            }
        }
        public string HingePosition
        {
            get
            {
                return hingePosition;
            }

            set
            {
                hingePosition = value;
            }
        }
        public string BoxHeader
        {
            get
            {
                return boxHeader;
            }

            set
            {
                boxHeader = value;
            }
        }
        #endregion
    }
}
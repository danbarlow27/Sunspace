using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class FrenchDoor
    {
        #region Attributes
        private float width;
        private float height; //79.125 if 2", 82.125 if 3"
        private string swingDirection; //in or out
        private string boxHeader; //Left, right, both. Must have one on hinge, must have one on strike if it meets solid wall
        #endregion

        #region Constructors
        public FrenchDoor()
        {
            width = 0f;
            height = 79.125f;
            swingDirection = "out";
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class Sunroom
    {
        #region Attributes

        private string sunroomType;
        private int numWalls;
        private int numFloors;
        private int numRoofs;
        private string aluminumColour;
        private string vinylColour;

        #endregion

        #region Constructors

        public Sunroom()
        {
            SunroomType = "";
            NumWalls = 0;
            NumFloors = 0;
            NumRoofs = 0;
            AluminumColour = "";
            VinylColour = "";
        }

        #endregion

        #region Accessors

        public string SunroomType
        {
            get
            {
                return sunroomType;
            }
            set
            {
                sunroomType = value;
            }
        }

        public int NumWalls
        {
            get
            {
                return numWalls;
            }
            set
            {
                numWalls = value;
            }
        }

        public int NumFloors
        {
            get
            {
                return numFloors;
            }
            set
            {
                numFloors = value;
            }
        }

        public int NumRoofs
        {
            get
            {
                return numRoofs;
            }
            set
            {
                numRoofs = value;
            }
        }

        public string AluminumColour
        {
            get
            {
                return aluminumColour;
            }
            set
            {
                aluminumColour = value;
            }
        }

        public string VinylColour
        {
            get
            {
                return vinylColour;
            }
            set
            {
                vinylColour = value;
            }
        }

        #endregion
    }
}
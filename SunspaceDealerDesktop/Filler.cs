using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class Filler
    {
        private float length;

        public Filler()
        {
            Length = Constants.DEFAULT_FILLER;
        }

        public Filler(float sentLength)
        {
            Length = sentLength;
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
    }
}
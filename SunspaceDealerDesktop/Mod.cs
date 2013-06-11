using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class Mod
    {
        private float length;

        public Mod()
        {
            Length = 0f;
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
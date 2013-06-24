using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class Kneewall
    {
        private String kneewallType;
        private float width;
        private float height;
        private String colour;
        private String tint;

        public Kneewall()
        {
            KneewallType = "";
            Width = 0f;
            Height = 0f;
            Colour = "";
            Tint = "";
        }

        public String KneewallType
        {
            get
            {
                return kneewallType;
            }
            set
            {
                kneewallType = value;
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
        public String Colour
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
        public String Tint
        {
            get
            {
                return tint;
            }
            set
            {
                tint = value;
            }
        }    
    }
}
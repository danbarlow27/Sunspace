using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class Transom
    {
        private String transomType;
        private float width;
        private float height;
        private String colour;
        private String tint;

        public Transom()
        {
            TransomType = "";
            Width = 0f;
            Height = 0f;
            Colour = "";
            Tint = "";
        }

        public String TransomType
        {
            get
            {
                return transomType;
            }
            set
            {
                transomType = value;
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
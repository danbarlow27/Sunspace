using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class Mod
    {
        private string modelType;
        private int indices;
        private float length;
        private float height;
        //colours?

        public Mod()
        {
            modelType = "";
            Indices = 0;
            Length = 0f;
            Height = 0f;
        }

        public string ModelType
        {
            get
            {
                return modelType;
            }
            set
            {
                modelType = value;
            }
        }
        public int Indices
        {
            get
            {
                return indices;
            }
            set
            {
                indices = value;
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
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class Door
    {
        private String typeOfDoor; //Type of Door String
        //private bool isPatioDoor; //True if Patio Door ?????????????
        private int itemIndex; //LinearItems Array Index
        private String transomStyle; //Transom Style: 0-Solid, 1-Glass, 2-Vinyl , glass rect, vinyl rect
        private String transomTint;
        //private int underHeaderStyle; //Transom Style: 0-Solid, 1-Glass, 2-Vinyl , glass rect, vinyl rect
        //private int underHeaderTint; //?????????????????????????????????????????????????????????????????
        private float height; //Punch Height of Door
        private float width; //Door Width (Not including Frame)

        public Door()
        {
            TypeOfDoor = "entry"; 
            ItemIndex = -1;
            TransomStyle = "solid"; 
            TransomTint = "glass";
            Height = 80.5f; 
            Width = 60.6f;
        }

        public String TypeOfDoor
        {
            get
            {
                return typeOfDoor;
            }

            set
            {
                typeOfDoor = value.ToLower();
            }
        }
       
        public int ItemIndex
        {
            get
            {
                return itemIndex;
            }

            set
            {
                itemIndex = value;
            }
        }

        public String TransomStyle
        {
            get
            {
                return transomStyle;
            }

            set
            {
                transomStyle = value.ToLower();
            }
        }

        public String TransomTint
        {
            get
            {
                return transomTint;
            }

            set
            {
                transomTint = value.ToLower();
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

        /*
        bool patioXO; //??????????????
        int glassTint; 
        bool cabanaSwingOut;
        bool cabanaLHH;
        bool boxHeader;
        bool boxHeader2;
        float kneewallHeight;
        int hardware;
        int ventCount;
        bool customWidth;
        bool customHeight;
        bool doubleTransom;
        bool temperedTransom;
        String mixedTint;
        bool isFrench;
        bool priLeft;
        bool hasGrills;
        int sunShade; //1 = control Left, 2 = control right
        */
    }
}
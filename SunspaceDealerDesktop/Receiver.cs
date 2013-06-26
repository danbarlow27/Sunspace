using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class Receiver
    {
        
        //anthony smells
        
        int itemIndex; //LinearItems Array Index
        float length; //temporary
        //float cutLength; //Length to Cut Starter At ?????????????????
        String colour; //Colour of the receiver
        //bool isTwoPiece; //???????????

        public Receiver()
        {
            ItemIndex = -1;
            Length = 0f;
            Colour = "red";
        }

        public Receiver(float sentLength)
        {
            ItemIndex = -1;
            Length = sentLength;
            Colour = "Red";
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

        public String Colour
        {
            get
            {
                return colour;
            }

            set
            {
                colour = value.ToLower();
            }
        }
    }
}
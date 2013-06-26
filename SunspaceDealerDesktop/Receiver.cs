 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class Receiver
    {
        int itemIndex; //LinearItems Array Index
        //float cutLength; //Length to Cut Starter At ?????????????????
        String colour; //Colour of the receiver
        //bool isTwoPiece; //???????????

        public Receiver()
        {
            ItemIndex = -1;
            Colour = "red";
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class Receiver : LinearItem
    {
        private int itemIndex; //LinearItems Array Index
        private string colour; //Colour of the receiver
        bool isTwoPiece; //???????????

        public Receiver() { }

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

        public string Colour
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

        public bool IsTwoPiece
        {
            get
            {
                return isTwoPiece;
            }

            set
            {
                isTwoPiece = value;
            }
        }
    }
}
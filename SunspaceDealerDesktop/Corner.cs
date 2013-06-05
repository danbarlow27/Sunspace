using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class Corner
    {
        private int itemIndex; //LinearItems Array Index
        private bool angleIs90; //True if 90, False if 45
        private float cutLength; //Length to Cut Corner At ??????????????
        private String colour; //Colour of the corner
        private bool outsideCorner; //True is Normal Corner, False if inside corner
    }
}
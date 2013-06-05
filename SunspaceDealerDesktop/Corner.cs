using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class Corner
    {
        int itemIndex; //LinearItems Array Index
        bool angleIs90; //True if 90, False if 45
        float cutLength; //Length to Cut Corner At ??????????????
        String colour; //Colour of the corner
        bool outsideCorner; //True is Normal Corner, False if inside corner
    }
}
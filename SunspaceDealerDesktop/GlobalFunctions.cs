using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public static class GlobalFunctions
    {
        public static float RoundDownToNearestEighthInch(float numberToRound)
        {
            int noDecimalNumber = (int)numberToRound;
            float decimalHeld;

            if (numberToRound > 0.875f)
            {
                decimalHeld = 0.875f;
            }
            else if (numberToRound > 0.75f)
            {
                decimalHeld = 0.75f;
            }
            else if (numberToRound > 0.625f)
            {
                decimalHeld = 0.625f;
            }
            else if (numberToRound > 0.5f)
            {
                decimalHeld = 0.5f;
            }
            else if (numberToRound > 0.375f)
            {
                decimalHeld = 0.375f;
            }
            else if (numberToRound > 0.25f)
            {
                decimalHeld = 0.25f;
            }
            else
            {
                decimalHeld = 0;
            }

            return (noDecimalNumber + decimalHeld);
        }
    }
}
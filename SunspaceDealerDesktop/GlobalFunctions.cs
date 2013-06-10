using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public static class GlobalFunctions
    {
        /**
         * RoundDownToNearestEighthInch
         * sent float numberToRound, the number sent which needs to be rounded
         * return float, the number rounded down to the nearest eighth of an inch
         * 
         * This method will convert type to int to drop the decimal, then use logic
         * to round only the decimal to the nearest eighth (.125, .250, etc) later
         * putting the int and decimal together to return.
         */
        public static float RoundDownToNearestEighthInch(float numberToRound)
        {
            int noDecimalNumber = (int)numberToRound;
            float decimalHeld = numberToRound - noDecimalNumber;
            float returnDecimal;

            if (decimalHeld > 0.875f)
            {
                returnDecimal = 0.875f;
            }
            else if (decimalHeld > 0.75f)
            {
                returnDecimal = 0.75f;
            }
            else if (decimalHeld > 0.625f)
            {
                returnDecimal = 0.625f;
            }
            else if (decimalHeld > 0.5f)
            {
                returnDecimal = 0.5f;
            }
            else if (decimalHeld > 0.375f)
            {
                returnDecimal = 0.375f;
            }
            else if (decimalHeld > 0.25f)
            {
                returnDecimal = 0.25f;
            }
            else
            {
                returnDecimal = 0;
            }

            return (noDecimalNumber + returnDecimal);
        }
                
        /**
         * splitFillerToOutside
         * sent byRef fillerOne, The filler on the left side (beginning) of the wall
         * sent byRef fillerTwo, the filler on the right side (ending) of the wall
         * sent float fillerToAdd, the amount of filler that needs to be spread between the two fillers
         * 
         * This method will evenly split filler to the two ref values of filler for every even number of filler to add, 
         * but will give a left side favored split to the odd numbers. Currently is using floats, will later use filler
         * objects.
         */ 
        public static void splitFillerToOutside(ref float fillerOne, ref float fillerTwo, float fillerToAdd)
        {
            int noDecimalNumber = (int)fillerToAdd;
            float decimalHeld = fillerToAdd - noDecimalNumber;
            
            fillerOne += (noDecimalNumber/2f); //change to resizing filler size later
            fillerTwo += (noDecimalNumber/2f); //change to resizing filler size later
         
            if (decimalHeld == 0.125f)
            {
                fillerOne += 0.125f;
            }
            else if (decimalHeld == 0.375f)
            {
                fillerOne += 0.250f;
                fillerTwo += 0.125f;
            }
            else if (decimalHeld == 0.625f)
            {
                fillerOne += 0.375f;
                fillerTwo += 0.250f;
            }
            else if (decimalHeld == 0.875f)
            {
                fillerOne += 0.5f;
                fillerTwo += 0.375f;
            }
            else
            {
                fillerOne += (decimalHeld/2f);
                fillerTwo += (decimalHeld/2f);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

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

            return (float)(noDecimalNumber + returnDecimal);
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

        /**
         * CalculateSHAHash
         * sent string input, The string to be converted to a hash
         * 
         * This method will take a string input, convert it to a SHA512 hash, and then return the 128 character hash. Used for encryption.
         * Currently unsalted, if you would like to salt this encryption, add a pattern of characters to input before any of the currently implemented code.
         */
        public static string CalculateSHAHash(string input)
        {
            // step 1, calculate sha512 hash from input
            SHA512 sha512 = SHA512Managed.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hash = sha512.ComputeHash(inputBytes);
            
            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
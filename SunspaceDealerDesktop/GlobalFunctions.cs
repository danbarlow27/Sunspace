using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI.WebControls;

namespace SunspaceDealerDesktop
{
    public static class GlobalFunctions
    {
        public static List<ListItem> FractionOptions()
        {
            List<ListItem> options = new List<ListItem>();

            ListItem lst0 = new ListItem("---", "0", true);
            ListItem lst18 = new ListItem("1/8", ".125");
            ListItem lst14 = new ListItem("1/4", ".25");
            ListItem lst38 = new ListItem("3/8", ".375");
            ListItem lst12 = new ListItem("1/2", ".5");
            ListItem lst58 = new ListItem("5/8", ".625");
            ListItem lst34 = new ListItem("3/4", ".75");
            ListItem lst78 = new ListItem("7/8", ".875");

            options.Add(lst0);
            options.Add(lst18);
            options.Add(lst14);
            options.Add(lst38);
            options.Add(lst12);
            options.Add(lst58);
            options.Add(lst34);
            options.Add(lst78);

            return options;
        }
        
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

            if (decimalHeld >= 0.875f)
            {
                returnDecimal = 0.875f;
            }
            else if (decimalHeld >= 0.75f)
            {
                returnDecimal = 0.75f;
            }
            else if (decimalHeld >= 0.625f)
            {
                returnDecimal = 0.625f;
            }
            else if (decimalHeld >= 0.5f)
            {
                returnDecimal = 0.5f;
            }
            else if (decimalHeld >= 0.375f)
            {
                returnDecimal = 0.375f;
            }
            else if (decimalHeld >= 0.25f)
            {
                returnDecimal = 0.25f;
            }
            else if (decimalHeld >= 0.125f)
            {
                returnDecimal = 0.125f;
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

        /// <summary>
        /// This function will take data regarding specifications of a wall and calculate the height of the wall at a given position
        /// along the wall.
        /// </summary>
        /// <param name="startHeight">The starting height of the wall.</param>
        /// <param name="endHeight">The ending height of the wall</param>
        /// <param name="sentPosition">The distance from the start (start height side) the position is located</param>
        /// <param name="wallLength">The total length of this wall</param>
        /// <returns>The height of the wall at the specified sent position</returns>
        public static float getHeightAtPosition(float startHeight, float endHeight, float sentPosition, float wallLength)
        {
            float returnValue = 0f;

            if (startHeight == endHeight)
            {
                returnValue = startHeight;
            }
            else
            {
                //slope = rise/run
                //rise = start-end
                //slope == (start-end)/wallLength
                //height at position = start height + (difference = slope*position)
                returnValue = startHeight + (((endHeight - startHeight) / wallLength) * sentPosition);
            }

            return returnValue;
        }

        /// <summary>
        /// This function, given a height, space that a mod has to fill up with windows, will find the number of windows that need
        /// to be used, in order to have the windows be similar. Returns a float array[number of windows, size of windows, remaining space].
        /// </summary>
        /// <param name="space">The height of the area that needs to be filled with windows</param>
        /// <param name="windowType">The type of window to fill with</param>
        public static float[] findOptimalHeightsOfWindows(float space, string windowType)
        {
            float[] returnArray = {0, 0, 0};
            float removableSpace = space;

            switch (windowType)
            {
                case "Vinyl":
                    if (space <= Constants.VINYL_LITE_MAX_HEIGHT_WARRANTY)
                    {
                        returnArray[0] = 1;
                        returnArray[1] = space;
                    }
                    else
                    {
                        while (removableSpace > Constants.VINYL_LITE_MAX_HEIGHT_WARRANTY)
                        {
                            returnArray[0]++;
                            removableSpace -= Constants.VINYL_LITE_MAX_HEIGHT_WARRANTY;
                        }

                        returnArray[1] = RoundDownToNearestEighthInch((float)(space / returnArray[0]));
                        returnArray[2] = removableSpace;
                    }
                    break;

                case "Glass":
                    if (space <= Constants.VINYL_LITE_MAX_HEIGHT_WARRANTY)
                    {
                        returnArray[0] = 1;
                        returnArray[1] = space;
                    }
                    else
                    {
                        while (removableSpace > Constants.VINYL_LITE_MAX_HEIGHT_WARRANTY)
                        {
                            returnArray[0]++;
                            removableSpace -= Constants.VINYL_LITE_MAX_HEIGHT_WARRANTY;
                        }

                        returnArray[1] = RoundDownToNearestEighthInch((float)(space / returnArray[0]));
                        returnArray[2] = removableSpace;
                    }
                    break;
                
                case "Vertical 4 Track":
                    if (space <= Constants.V4T_4V_MAX_HEIGHT_WARRANTY)
                    {
                        returnArray[0] = 1;
                        returnArray[1] = space;
                    }
                    else
                    {
                        while (removableSpace > Constants.V4T_4V_MAX_HEIGHT_WARRANTY)
                        {
                            returnArray[0]++;
                            removableSpace -= Constants.V4T_4V_MAX_HEIGHT_WARRANTY;
                        }

                        returnArray[1] = RoundDownToNearestEighthInch((float)(space / returnArray[0]));
                        returnArray[2] = removableSpace;
                    }
                    break;

                case "Horizontal 2 Track":
                    if (space <= Constants.HORIZONTAL_ROLLER_MAX_HEIGHT_WARRANTY)
                    {
                        returnArray[0] = 1;
                        returnArray[1] = space;
                    }
                    else
                    {
                        while (removableSpace > Constants.HORIZONTAL_ROLLER_MAX_HEIGHT_WARRANTY)
                        {
                            returnArray[0]++;
                            removableSpace -= Constants.HORIZONTAL_ROLLER_MAX_HEIGHT_WARRANTY;
                        }

                        returnArray[1] = RoundDownToNearestEighthInch((float)(space / returnArray[0]));
                        returnArray[2] = removableSpace;
                    }
                    break;

                case "Horizontal Roller":
                    if (space <= Constants.HORIZONTAL_ROLLER_MAX_HEIGHT_WARRANTY)
                    {
                        returnArray[0] = 1;
                        returnArray[1] = space;
                    }
                    else
                    {
                        while (removableSpace > Constants.HORIZONTAL_ROLLER_MAX_HEIGHT_WARRANTY)
                        {
                            returnArray[0]++;
                            removableSpace -= Constants.HORIZONTAL_ROLLER_MAX_HEIGHT_WARRANTY;
                        }

                        returnArray[1] = RoundDownToNearestEighthInch((float)(space / returnArray[0]));
                        returnArray[2] = removableSpace;
                    }
                    break;

                case "Single Slider":
                    if (space <= Constants.SINGLE_SLIDER_MAX_HEIGHT_WARRANTY)
                    {
                        returnArray[0] = 1;
                        returnArray[1] = space;
                    }
                    else
                    {
                        while (removableSpace > Constants.SINGLE_SLIDER_MAX_HEIGHT_WARRANTY)
                        {
                            returnArray[0]++;
                            removableSpace -= Constants.SINGLE_SLIDER_MAX_HEIGHT_WARRANTY;
                        }

                        returnArray[1] = RoundDownToNearestEighthInch((float)(space / returnArray[0]));
                        returnArray[2] = removableSpace;
                    }
                    break;

                case "Double Slider":
                    if (space <= Constants.DOUBLE_SLIDER_MAX_HEIGHT_WARRANTY)
                    {
                        returnArray[0] = 1;
                        returnArray[1] = space;
                    }
                    else
                    {
                        while (removableSpace > Constants.DOUBLE_SLIDER_MAX_HEIGHT_WARRANTY)
                        {
                            returnArray[0]++;
                            removableSpace -= Constants.DOUBLE_SLIDER_MAX_HEIGHT_WARRANTY;
                        }

                        returnArray[1] = RoundDownToNearestEighthInch((float)(space / returnArray[0]));
                        returnArray[2] = removableSpace;
                    }
                    break;

                case "Screen":
                    if (space <= Constants.SCREEN_MAX_HEIGHT_WARRANTY)
                    {
                        returnArray[0] = 1;
                        returnArray[1] = space;
                    }
                    else
                    {
                        while (removableSpace > Constants.SCREEN_MAX_HEIGHT_WARRANTY)
                        {
                            returnArray[0]++;
                            removableSpace -= Constants.SCREEN_MAX_HEIGHT_WARRANTY;
                        }

                        returnArray[1] = RoundDownToNearestEighthInch((float)(space / returnArray[0]));
                        returnArray[2] = removableSpace;
                    }
                    break;
            }
            return returnArray;
        }

        public static float[] validateWindowModSize(float space, string windowType/*, size, number, wall, start*/) 
        {
            float MIN_MOD_WIDTH = 0f;
            float MAX_MOD_WIDTH = 0f;
            int windowCounter = 0;
            float finalWindowSize = 0;
            float spaceRemaining = space;

            //get constants based on type
            switch (windowType)
            {
                case "Vinyl":
                    MIN_MOD_WIDTH = Constants.VINYL_TRAP_MIN_WIDTH_WARRANTY; //We use the trap version because they can have both
                    MAX_MOD_WIDTH = Constants.VINYL_TRAP_MAX_WIDTH_WARRANTY;
                    break;

                case "Glass":
                    MIN_MOD_WIDTH = Constants.VINYL_TRAP_MIN_WIDTH_WARRANTY; //We use the trap version because they can have both
                    MAX_MOD_WIDTH = Constants.VINYL_TRAP_MAX_WIDTH_WARRANTY;
                    break;

                case "Vertical 4 Track":
                    MIN_MOD_WIDTH = Constants.V4T_4V_MIN_WIDTH_WARRANTY; //We use the trap version because they can have both
                    MAX_MOD_WIDTH = Constants.V4T_4V_MAX_WIDTH_WARRANTY;
                    break;

                case "Horizontal 4 Track":
                    MIN_MOD_WIDTH = Constants.HORIZONTAL_ROLLER_MIN_WIDTH_WARRANTY; //We use the trap version because they can have both
                    MAX_MOD_WIDTH = Constants.HORIZONTAL_ROLLER_MAX_WIDTH_WARRANTY;
                    break;

                case "Horizontal Roller":
                    MIN_MOD_WIDTH = Constants.HORIZONTAL_ROLLER_MIN_WIDTH_WARRANTY; //We use the trap version because they can have both
                    MAX_MOD_WIDTH = Constants.HORIZONTAL_ROLLER_MAX_WIDTH_WARRANTY;
                    break;

                case "Single Slider":
                    MIN_MOD_WIDTH = Constants.SINGLE_SLIDER_MIN_WIDTH_WARRANTY; //We use the trap version because they can have both
                    MAX_MOD_WIDTH = Constants.SINGLE_SLIDER_MAX_WIDTH_WARRANTY;
                    break;

                case "Double Slider":
                    MIN_MOD_WIDTH = Constants.DOUBLE_SLIDER_MIN_WIDTH_WARRANTY; //We use the trap version because they can have both
                    MAX_MOD_WIDTH = Constants.DOUBLE_SLIDER_MAX_WIDTH_WARRANTY;
                    break;

                case "Screen":
                    MIN_MOD_WIDTH = Constants.SCREEN_MIN_WIDTH_WARRANTY; //We use the trap version because they can have both
                    MAX_MOD_WIDTH = Constants.SCREEN_MAX_WIDTH_WARRANTY;
                    break;
            }
            while (spaceRemaining >= MIN_MOD_WIDTH)
            {
                if (spaceRemaining >= MAX_MOD_WIDTH)
                {
                    spaceRemaining -= MAX_MOD_WIDTH;
                    windowCounter++;
                }
                else if (spaceRemaining < MAX_MOD_WIDTH && spaceRemaining > MIN_MOD_WIDTH)
                {
                    spaceRemaining = 0;
                    windowCounter++;
                }
                else if (spaceRemaining == MIN_MOD_WIDTH)
                {
                    spaceRemaining = 0;
                    windowCounter++;
                }
            }

            if (spaceRemaining > 0 && windowCounter > 0)
            {
                //Should never get here? will always hit one of the spaceRemaining=0 above
                windowCounter++;
                finalWindowSize = space / windowCounter;
                spaceRemaining = 0;
            }
            else if (spaceRemaining > 0 && windowCounter == 0)
            {
                //Should never get here? will always hit one of the spaceRemaining=0 above
                //add spaceRemaining to filler
                //fillFiller(space, wall, start);
                //spaceRemaining = 0;
            }
            else
            {
                finalWindowSize = space / windowCounter;
            }
    
            var roundedWindowSize = RoundDownToNearestEighthInch(finalWindowSize);

            //Set space remaining equal to amount lost via rounding
            //spaceRemaining += finalWindowSize - roundedWindowSize;
            spaceRemaining = space - (roundedWindowSize * windowCounter);
    
            //Need to return space * windowcounter, since we lost that amount PER WINDOW
            float[] anArray = { roundedWindowSize, windowCounter, spaceRemaining }; /* * windowCounter */
            return (anArray);
        }

        /**
         * This function will take a string, and escape any possibly damaging character to SQL code
         */ 
        public static string escapeSqlString(string sentString)
        {
            string escapedString = "";

            for (int i = 0; i < sentString.Length; i++)
            {
                string currentChar = sentString.Substring(i, 1);

                if (currentChar.All(Char.IsLetterOrDigit) || currentChar == " ")
                {
                    escapedString += currentChar;
                }
                else
                {
                    escapedString += @"\"; //Adds the escape character to the string in front of this character
                    escapedString += currentChar;
                }
            }

            return escapedString;
        }
    }
}
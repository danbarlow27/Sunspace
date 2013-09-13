/** 
        This function is used to validate decimal to eighth of an inch. 
        If its not exactly an eighth, round it down to the nearest eighth.
        @param number - the given number of height that's calculated using the slope to be validated
        @return decimal - the validated number that is exactly an eighth of an inch
        */
function validateDecimal(number) {

    number += ''; //covert the given number to string
    var decimal = number.split("."); //split the number at the decimal point
    decimal[1] = "0." + decimal[1]; //add "0." to the decimal values to make a valid decimal number

    /******************************/
    //these constants below will have to be 
    //moved to a constants file, or at least
    //have global scope within this file.
    var ONE_EIGHTH = 0.125;
    var TWO_EIGHTH = 0.25;
    var THREE_EIGHTH = 0.375;
    var FOUR_EIGHTH = 0.5;
    var FIVE_EIGHTH = 0.625;
    var SIX_EIGHTH = 0.75;
    var SEVEN_EIGHTH = 0.875;
    /******************************/

    //reset the decimal value if its not exactly an eighth
    //round it down to the nearest eighth
    decimal[1] = (decimal[1] >= SEVEN_EIGHTH) ? SEVEN_EIGHTH :
        (decimal[1] >= SIX_EIGHTH) ? SIX_EIGHTH :
        (decimal[1] >= FIVE_EIGHTH) ? FIVE_EIGHTH :
        (decimal[1] >= FOUR_EIGHTH) ? FOUR_EIGHTH :
        (decimal[1] >= THREE_EIGHTH) ? THREE_EIGHTH :
        (decimal[1] >= TWO_EIGHTH) ? TWO_EIGHTH :
        (decimal[1] >= ONE_EIGHTH) ? ONE_EIGHTH : 0;

    return decimal; //return the corrected decimal value as an array of two elements, 0: value before the decimal, 1: value after the decimal
}

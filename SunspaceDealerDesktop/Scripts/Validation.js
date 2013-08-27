/*
    FileName: Validation.js
    Author: Dan Barlow
    DateCreated: June 17, 2013

    This file contains client-side validation functions for user input.
*/

function validatePhone(input)
{
    var MIN_AREA = 200;
    var MAX_AREA = 999;
    var MIN_EXCHANGE = 200;
    var MAX_EXCHANGE = 999;
    var PHONE_LENGTH = 10;

    var areaCode = input.substring(0,3);
    var exchange = input.substring(3,6);
    var lastFour = input.substring(6);

    var errorMsg = "";
             

        if (isNaN(areaCode)) {
            errorMsg += "Your area code must be numeric.\n";
        }

        if (areaCode < MIN_AREA || areaCode > MAX_AREA) {
            errorMsg += "Your area code must be between 200 and 999 inclusive.\n";
        }

        if (isNaN(exchange)) {
            errorMsg += "Your phone exchange must be numeric.\n";
        }

        if (exchange < MIN_EXCHANGE || exchange > MAX_EXCHANGE){
            errorMsg += "Your phone exchange must be between 200 and 999 inclusive.\n";
        }

        if (isNaN(lastFour)) {
            errorMsg += "The last four digits of your phone number must be numeric.\n";
        }

        return errorMsg;
}

function checkPostalCode(postalCode) {
    if (postalCode.search(/^([A-Za-z][0-9][A-Za-z][0-9][A-Za-z][0-9]$)/) != -1)
    {
        return true;
    }
    else
    {
        return false;
    }
}
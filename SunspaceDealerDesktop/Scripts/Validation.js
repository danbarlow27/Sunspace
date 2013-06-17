/*
    FileName: Validation.js
    Author: Dan Barlow
    DateCreated: June 17, 2013

    This file contains client-side validation functions for user input.
*/

function validatePhone(input)
{
    var firstThree = input.substring(0,2);
    var secondThree = input.substring(3,5);
    var lastFour = input.substring(6, 10);

    if (isNaN(firstThree) || isNaN(secondThree) || isNaN(lastFour)) {
        return false;
    }
    else {
        return true;
    }
}
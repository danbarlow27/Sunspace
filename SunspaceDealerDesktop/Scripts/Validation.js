/*
    FileName: Validation.js
    Author: Dan Barlow
    DateCreated: June 17, 2013

    This file contains client-side validation functions for user input.
*/
function findLineAxis(theLine)
{
    if (parseFloat(theLine.x1) == parseFloat(theLine.x2)) // vertical line
    {
        return "V"; // return V for vertical
    }
    else if (parseFloat(theLine.y1) == parseFloat(theLine.y2)) // horizontal line
    {
        return "H"; // return H for horizontal
    }
    else // diagonal line
    {
        return "D"; // return D for diagonal
    }
}

//function findLineDirection(theLine)
//{
//    if (findLineAxis(theLine) == "V") // vertical line, check for down or up direction
//    {
//        if (parseFloat(theLine.y1) < parseFloat(theLine.y2)) // the line was drawn top to bottom
//        {
//            return "down"; // the line goes down
//        }
//        else if (parseFloat(theLine.y1) > parseFloat(theLine.y2)) // the line was drawn bottom to top
//        {
//            return "up"; // the line goes up
//        }
//    }
//    else if (findLineAxis(theLine) == "H") // horizontal line, check for left or right direction
//    {
//        if (parseFloat(theLine.x1) > parseFloat(theLine.x2)) // line was drawn right to left
//        {
//            return "left"; // line goes left
//        }
//        else if (parseFloat(theLine.x1) < parseFloat(theLine.x2)) // the line was drawn left to right
//        {
//            return "right"; // line goes right
//        }
//    }
//    else if (findLineAxis(theLine) == "D") // diagonal line, check for upLeft, upRight, downLeft, downRight direction
//    {
//        if (parseFloat(theLine.x1) < parseFloat(theLine.x2) && parseFloat(theLine.y1) > parseFloat(theLine.y2)) // line goes upRight
//        {
//            return "upRight"; // return upRight
//        }
//        else if (parseFloat(theLine.x1) < parseFloat(theLine.x2) && parseFloat(theLine.y1) < parseFloat(theLine.y2)) // line goes downRight
//        {
//            return "downRight"; // return downRight
//        }
//        else if (parseFloat(theLine.x1) > parseFloat(theLine.x2) && parseFloat(theLine.y1) < parseFloat(theLine.y2)) // line goes downLeft
//        {
//            return "downLeft"; // return downLeft
//        }
//        else if (parseFloat(theLine.x1) > parseFloat(theLine.x2) && parseFloat(theLine.y1) > parseFloat(theLine.y2)) // line goes upLeft
//        {
//            return "upLeft"; // return upLeft
//        }
//    }
//}

function findLineEndTouch(firstLine, secondLine)
{
    //Find end to end touch
    if (parseFloat(firstLine.x1) == parseFloat(secondLine.x1) && parseFloat(firstLine.y1) == parseFloat(secondLine.y1)) {
        return true;
    }
    else if (parseFloat(firstLine.x1) == parseFloat(secondLine.x2) && parseFloat(firstLine.y1) == parseFloat(secondLine.y2)) {
        return true;
    }
    else if (parseFloat(firstLine.x2) == parseFloat(secondLine.x1) && parseFloat(firstLine.y2) == parseFloat(secondLine.y1)) {
        return true;
    }
    else if (parseFloat(firstLine.x2) == parseFloat(secondLine.x2) && parseFloat(firstLine.y2) == parseFloat(secondLine.y2)) {
        return true;
    }
    else {
        return false;
    }
}

function findLinePerpendicularTouch(firstLine, secondLine)
{
    //Find a perpendicular touch
    if ((findLineAxis(firstLine) == "V" && findLineAxis(secondLine) == "H") || (findLineAxis(firstLine) == "H" && findLineAxis(secondLine) == "V"))
    {
        //first line is vertical - T or Upside down T shape
        if (((parseFloat(firstLine.y1) == parseFloat(secondLine.y1) && parseFloat(firstLine.y1) == parseFloat(secondLine.y2))
            || (parseFloat(firstLine.y2) == parseFloat(secondLine.y1) && parseFloat(firstLine.y2) == parseFloat(secondLine.y2)))
            && (parseFloat(firstLine.x1) > parseFloat(secondLine.x1) && parseFloat(firstLine.x2) < parseFloat(secondLine.x2)))
        {
            return true;
        }
        //first line is horizontal - T or Upside down T shape
        else if (((parseFloat(secondLine.y1) == parseFloat(firstLine.y1) && parseFloat(secondLine.y1) == parseFloat(firstLine.y2))
            || (parseFloat(secondLine.y2) == parseFloat(firstLine.y1) && parseFloat(secondLine.y2) == parseFloat(firstLine.y2)))
            && (parseFloat(firstLine.x1) < parseFloat(secondLine.x1) && parseFloat(firstLine.x2) > parseFloat(secondLine.x2)))
        {
            return true;
        }
        //first line is vertical - Sideways T shape
        if (((parseFloat(firstLine.x1) == parseFloat(secondLine.x1) && parseFloat(firstLine.x1) == parseFloat(secondLine.x2))
            || (parseFloat(firstLine.x2) == parseFloat(secondLine.x1) && parseFloat(firstLine.x2) == parseFloat(secondLine.x2)))
            && (parseFloat(firstLine.y1) > parseFloat(secondLine.y1) && parseFloat(firstLine.y2) < parseFloat(secondLine.y2)))
        {
            return true;
        }
        //first line is horizontal - Sideways T shape the opposite direction
        else if (((parseFloat(secondLine.x1) == parseFloat(firstLine.x1) && parseFloat(secondLine.x1) == parseFloat(firstLine.x2))
            || (parseFloat(secondLine.x2) == parseFloat(firstLine.x1) && parseFloat(secondLine.x2) == parseFloat(firstLine.x2)))
            && (parseFloat(firstLine.y1) < parseFloat(secondLine.y1) && parseFloat(firstLine.y2) > parseFloat(secondLine.y2)))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    else if (findLineAxis(firstLine) == "D" && findLineAxis(secondLine) == "D")
    {
        if ((parseFloat(secondLine.x1) > parseFloat(firstLine.x1) && parseFloat(secondLine.x1) < parseFloat(firstLine.x2)) &&
            (parseFloat(secondLine.y1) < parseFloat(firstLine.y1) && parseFloat(secondLine.y1) > parseFloat(firstLine.y2)) &&
            parseFloat(secondLine.y1) == (parseFloat(firstLine.y1) - (parseFloat(secondLine.x1) - parseFloat(firstLine.x1)))) 
        {
            return true;
        }

        else if ((parseFloat(firstLine.x1) > parseFloat(secondLine.x1) && parseFloat(firstLine.x1) < parseFloat(secondLine.x2)) &&
            (parseFloat(firstLine.y1) < parseFloat(secondLine.y1) && parseFloat(firstLine.y1) > parseFloat(secondLine.y2)) &&
            parseFloat(firstLine.y1) == (parseFloat(secondLine.y1) - (parseFloat(firstLine.x1) - parseFloat(secondLine.x1))))
        {
            return true;
        }

        else if ((parseFloat(secondLine.x1) > parseFloat(firstLine.x1) && parseFloat(secondLine.x1) < parseFloat(firstLine.x2)) &&
            (parseFloat(secondLine.y1) > parseFloat(firstLine.y1) && parseFloat(secondLine.y1) < parseFloat(firstLine.y2)) &&
            parseFloat(secondLine.y1) == (parseFloat(firstLine.y1) + (parseFloat(secondLine.x1) - parseFloat(firstLine.x1))))
        {
            return true;
        }

        else if ((parseFloat(firstLine.x1) > parseFloat(secondLine.x1) && parseFloat(firstLine.x1) < parseFloat(secondLine.x2)) &&
            (parseFloat(firstLine.y1) > parseFloat(secondLine.y1) && parseFloat(firstLine.y1) < parseFloat(secondLine.y2)) &&
            parseFloat(firstLine.y1) == (parseFloat(secondLine.y1) + (parseFloat(firstLine.x1) - parseFloat(secondLine.x1))))
        {
            return true;
        }

        else if ((parseFloat(firstLine.x2) > parseFloat(secondLine.x1) && parseFloat(firstLine.x2) < parseFloat(secondLine.x2)) &&
            (parseFloat(firstLine.y2) < parseFloat(secondLine.y1) && parseFloat(firstLine.y2) > parseFloat(secondLine.y2)) &&
            parseFloat(firstLine.y2) == (parseFloat(secondLine.y1) - (parseFloat(firstLine.x2) - parseFloat(secondLine.x1))))
        {
            return true;
        }

        else if ((parseFloat(firstLine.x2) > parseFloat(secondLine.x1) && parseFloat(firstLine.x1) < parseFloat(secondLine.x2)) &&
            (parseFloat(firstLine.y2) < parseFloat(secondLine.y2) && parseFloat(firstLine.y1) > parseFloat(secondLine.y2)) &&
            parseFloat(secondLine.y2) == (parseFloat(firstLine.y2) + (parseFloat(firstLine.x2) - parseFloat(secondLine.x2))))
        {
            return true;
        }

        else if ((parseFloat(firstLine.x2) > parseFloat(secondLine.x1) && parseFloat(firstLine.x2) < parseFloat(secondLine.x2)) &&
            (parseFloat(firstLine.y2) > parseFloat(secondLine.y1) && parseFloat(firstLine.y2) < parseFloat(secondLine.y2)) &&
            parseFloat(firstLine.y2) == (parseFloat(secondLine.y2) - (parseFloat(secondLine.x2) - parseFloat(firstLine.x2))))
        {
            return true;
        }

        else if ((parseFloat(secondLine.x2) > parseFloat(firstLine.x1) && parseFloat(secondLine.x2) < parseFloat(firstLine.x2)) &&
            (parseFloat(secondLine.y2) > parseFloat(firstLine.y1) && parseFloat(secondLine.y2) < parseFloat(firstLine.y2)) &&
            parseFloat(secondLine.y2) == (parseFloat(firstLine.y2) - (parseFloat(firstLine.x2) - parseFloat(secondLine.x2))))
        {
            return true;
        }

        else if ((parseFloat(secondLine.x1) > parseFloat(firstLine.x2) && parseFloat(secondLine.x1) < parseFloat(firstLine.x1)) &&
            (parseFloat(secondLine.y1) > parseFloat(firstLine.y2) && parseFloat(secondLine.y1) < parseFloat(firstLine.y1)) &&
            parseFloat(secondLine.y1) == (parseFloat(firstLine.y1) - (parseFloat(firstLine.x1) - parseFloat(secondLine.x1))))
        {
            return true;
        }

        else if ((parseFloat(firstLine.x1) > parseFloat(secondLine.x2) && parseFloat(firstLine.x1) < parseFloat(secondLine.x1)) &&
            (parseFloat(firstLine.y1) > parseFloat(secondLine.y2) && parseFloat(firstLine.y1) < parseFloat(secondLine.y1)) &&
            parseFloat(firstLine.y1) == (parseFloat(secondLine.y1) - (parseFloat(secondLine.x1) - parseFloat(firstLine.x1))))
        {
            return true;
        }

        else if ((parseFloat(firstLine.x2) < parseFloat(secondLine.x1) && parseFloat(firstLine.x2) > parseFloat(secondLine.x2)) &&
            (parseFloat(firstLine.y2) > parseFloat(secondLine.y2) && parseFloat(firstLine.y2) < parseFloat(secondLine.y1)) &&
            parseFloat(firstLine.y2) == (parseFloat(secondLine.y1) - (parseFloat(secondLine.x1) - parseFloat(firstLine.x2))))
        {
            return true;
        }

        else if ((parseFloat(secondLine.x2) > parseFloat(firstLine.x2) && parseFloat(secondLine.x2) < parseFloat(firstLine.x1)) &&
            (parseFloat(secondLine.y2) > parseFloat(firstLine.y2) && parseFloat(secondLine.y2) < parseFloat(firstLine.y1)) &&
            parseFloat(secondLine.y2) == (parseFloat(firstLine.y1) - (parseFloat(firstLine.x1) - parseFloat(secondLine.x2))))
        {
            return true;
        }

        else if ((parseFloat(secondLine.x1) > parseFloat(firstLine.x2) && parseFloat(secondLine.x1) < parseFloat(firstLine.x1)) &&
            (parseFloat(secondLine.y1) > parseFloat(firstLine.y1) && parseFloat(secondLine.y1) < parseFloat(firstLine.y2)) &&
            parseFloat(secondLine.y1) == (parseFloat(firstLine.y2) - (parseFloat(secondLine.x1) - parseFloat(firstLine.x2))))
        {
            return true;
        }

        else if ((parseFloat(firstLine.x1) > parseFloat(secondLine.x2) && parseFloat(firstLine.x1) < parseFloat(secondLine.x1)) &&
            (parseFloat(firstLine.y1) > parseFloat(secondLine.y1) && parseFloat(firstLine.y1) < parseFloat(secondLine.y2)) &&
            parseFloat(firstLine.y1) == (parseFloat(secondLine.y2) - (parseFloat(firstLine.x1) - parseFloat(secondLine.x2))))
        {
            return true;
        }

        else if ((parseFloat(firstLine.x2) > parseFloat(secondLine.x2) && parseFloat(firstLine.x2) < parseFloat(secondLine.x1)) &&
            (parseFloat(firstLine.y2) > parseFloat(secondLine.y1) && parseFloat(firstLine.y2) < parseFloat(secondLine.y2)) &&
            parseFloat(firstLine.y2) == (parseFloat(secondLine.y1) + (parseFloat(secondLine.x1) - parseFloat(firstLine.x2))))
        {
            return true;
        }

        else if ((parseFloat(secondLine.x2) > parseFloat(firstLine.x2) && parseFloat(secondLine.x2) < parseFloat(firstLine.x1)) &&
            (parseFloat(secondLine.y2) > parseFloat(firstLine.y1) && parseFloat(secondLine.y2) < parseFloat(firstLine.y2)) &&
            parseFloat(secondLine.y2) == (parseFloat(firstLine.y2) - (parseFloat(secondLine.x2) - parseFloat(firstLine.x2))))
        {
            return true;
        }

            //perpendicular lines do not touch
        else
        {
            return false;
        }
    }
    else
    {
        return false;
    }
}


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
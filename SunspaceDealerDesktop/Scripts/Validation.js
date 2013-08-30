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

function findLineDirection(theLine)
{
    if (findLineAxis(theLine) == "V") // vertical line, check for down or up direction
    {
        if (parseFloat(theLine.y1) < parseFloat(theLine.y2)) // the line was drawn top to bottom
        {
            return "down"; // the line goes down
        }
        else if (parseFloat(theLine.y1) > parseFloat(theLine.y2)) // the line was drawn bottom to top
        {
            return "up"; // the line goes up
        }
    }
    else if (findLineAxis(theLine) == "H") // horizontal line, check for left or right direction
    {
        if (parseFloat(theLine.x1) > parseFloat(theLine.x2)) // line was drawn right to left
        {
            return "left"; // line goes left
        }
        else if (parseFloat(theLine.x1) < parseFloat(theLine.x2)) // the line was drawn left to right
        {
            return "right"; // line goes right
        }
    }
    else if (findLineAxis(theLine) == "D") // diagonal line, check for upLeft, upRight, downLeft, downRight direction
    {
        if (parseFloat(theLine.x1) < parseFloat(theLine.x2) && parseFloat(theLine.y1) > parseFloat(theLine.y2)) // line goes upRight
        {
            return "upRight"; // return upRight
        }
        else if (parseFloat(theLine.x1) < parseFloat(theLine.x2) && parseFloat(theLine.y1) < parseFloat(theLine.y2)) // line goes downRight
        {
            return "downRight"; // return downRight
        }
        else if (parseFloat(theLine.x1) > parseFloat(theLine.x2) && parseFloat(theLine.y1) < parseFloat(theLine.y2)) // line goes downLeft
        {
            return "downLeft"; // return downLeft
        }
        else if (parseFloat(theLine.x1) > parseFloat(theLine.x2) && parseFloat(theLine.y1) > parseFloat(theLine.y2)) // line goes upLeft
        {
            return "upLeft"; // return upLeft
        }
    }
}

function findLinesTouch(firstLine, secondLine)
    /*
        This function takes two line arguments and determines whether or not they touch.
        If it is determined that the lines touch, a string containing 4 important pieces of information is returned.
        The format for this returned string is:
        (firstLineDirection)(secondLineDirection)(WhereTheLinesMeet[End/Mid])
        Example: (down)(down)(end)(end) = firstLineDirection of "Down", secondLineDirection of "Down", firstLine touches secondLine via firstLines "End", secondLine touches firstLine via secondLines "End"
    */
{
    if (findLineDirection(firstLine) == "down") // first line drawn top to bottom
    {
        if (findLineDirection(secondLine) == "down") // second line drawn top to bottom
        {
            if ((parseFloat(firstLine.y2) == parseFloat(secondLine.y1)) && (parseFloat(firstLine.x1) == parseFloat(secondLine.x1)))
            {
                return "(down)(down)(end)(start)";
            }
            else
            {
                return "";
            }
        }
        else if (findLineDirection(secondLine) == "up") //second line done bottom to top
        {
            if ((parseFloat(secondLine.x1) == parseFloat(firstLine.x1) || parseFloat(secondLine.x2) == parseFloat(firstLine.x1)) &&
                (parseFloat(firstLine.y1) == parseFloat(secondLine.y1) || parseFloat(firstLine.y2) == parseFloat(secondLine.y2)))
            {
                return "(down)(up)(end)(end)";
            }
            else
            {
                return "";
            }

        }
        else if (findLineDirection(secondLine) == "left") //
        {
            if ((parseFloat(secondLine.x1) == parseFloat(firstLine.x1) || parseFloat(secondLine.x2) == parseFloat(firstLine.x1)) &&
                (parseFloat(secondLine.y1) > parseFloat(firstLine.y1) && parseFloat(secondLine.y2) < parseFloat(firstLine.y2)))
            {
                return "(down)(left)(mid)(end)";
            }
            else if ((parseFloat(secondLine.x1) == parseFloat(firstLine.x1) || parseFloat(secondLine.x2) == parseFloat(firstLine.x1)) &&
                ((parseFloat(secondLine.y1) == parseFloat(firstLine.y1) || parseFloat(secondLine.y2) == parseFloat(firstLine.y1)) ||
                (parseFloat(secondLine.y1) == parseFloat(firstLine.y2) || parseFloat(secondLine.y2) == parseFloat(firstLine.y2))))
            {
                return "(down)(left)(end)(end)";
            }
            else if ((parseFloat(secondLine.y1) == parseFloat(firstLine.y1) || parseFloat(secondLine.y2) == parseFloat(firstLine.y2)) &&
                (parseFloat(firstLine.x1) < parseFloat(secondLine.x1) && parseFloat(firstLine.x2) > parseFloat(secondLine.x2)))
            {
                return "(down)(left)(end)(mid)";
            }
            else
            {
                return "";
            }
        }
        else if (findLineDirection(secondLine) == "right") //
        {
            if ((parseFloat(secondLine.x1) == parseFloat(firstLine.x1) || parseFloat(secondLine.x2) == parseFloat(firstLine.x1)) &&
                (parseFloat(secondLine.y1) > parseFloat(firstLine.y1) && parseFloat(secondLine.y2) < parseFloat(firstLine.y2)))
            {
                return "(down)(right)(mid)(end)";
            }
            else if ((parseFloat(secondLine.x1) == parseFloat(firstLine.x1) || parseFloat(secondLine.x2) == parseFloat(firstLine.x1)) &&
                ((parseFloat(secondLine.y1) == parseFloat(firstLine.y1) || parseFloat(secondLine.y2) == parseFloat(firstLine.y1)) ||
                (parseFloat(secondLine.y1) == parseFloat(firstLine.y2) || parseFloat(secondLine.y2) == parseFloat(firstLine.y2))))
            {
                return "(down)(right)(end)(end)";
            }
            else if ((parseFloat(secondLine.y1) == parseFloat(firstLine.y1) || parseFloat(secondLine.y2) == parseFloat(firstLine.y2)) &&
                (parseFloat(firstLine.x1) > parseFloat(secondLine.x1) && parseFloat(firstLine.x2) < parseFloat(secondLine.x2)))
            {
                return "(down)(left)(end)(mid)";
            }
            else
            {
                return "";
            }
        }
        else if (findLineDirection(secondLine) == "upRight")//
        {
            if ((parseFloat(secondLine.x1) == parseFloat(firstLine.x1) || parseFloat(secondLine.x2) == parseFloat(firstLine.x1)) &&
                ((parseFloat(secondLine.x2) == parseFloat(firstLine.x1) && parseFloat(secondLine.y2) == parseFloat(firstLine.y1)) ||
                (parseFloat(secondLine.x2) == parseFloat(firstLine.x2) && parseFloat(secondLine.y2) == parseFloat(firstLine.y2)) ||
                (parseFloat(secondLine.x1) == parseFloat(firstLine.x1) && parseFloat(secondLine.y1) == parseFloat(firstLine.y1)) ||
                (parseFloat(secondLine.x1) == parseFloat(firstLine.x2) && parseFloat(secondLine.y1) == parseFloat(firstLine.y2))))
            {
                return "(down)(upRight)(end)(end)";
            }
            else if ((parseFloat(secondLine.x1) == parseFloat(firstLine.x1) || parseFloat(secondLine.x2) == parseFloat(firstLine.x1)) &&
                (parseFloat(secondLine.y1) > parseFloat(firstLine.y1) && parseFloat(secondLine.y1) < parseFloat(firstLine.y2)))
            {
                return "(down)(upRight)(mid)(end)";
            }
            else if ((parseFloat(firstLine.x1) > parseFloat(secondLine.x1) && parseFloat(firstLine.x2) < parseFloat(secondLine.x2)) &&
                ((parseFloat(secondLine.y1) - (parseFloat(firstLine.x2) - parseFloat(secondLine.x1))) == parseFloat(firstLine.y2) ||
                (parseFloat(secondLine.y1) - (parseFloat(firstLine.x2) - parseFloat(secondLine.x1))) == parseFloat(firstLine.y1)))
            {
                return "(down)(upRight)(end)(mid)";
            }
            else
            {
                return "";
            }
        }
        else if (findLineDirection(secondLine) == "downLeft") //
        {
            if ((parseFloat(secondLine.x1) == parseFloat(firstLine.x1) || parseFloat(secondLine.x2) == parseFloat(firstLine.x1)) &&
                ((parseFloat(secondLine.x2) == parseFloat(firstLine.x1) && parseFloat(secondLine.y2) == parseFloat(firstLine.y1)) ||
                (parseFloat(secondLine.x2) == parseFloat(firstLine.x2) && parseFloat(secondLine.y2) == parseFloat(firstLine.y2)) ||
                (parseFloat(secondLine.x1) == parseFloat(firstLine.x1) && parseFloat(secondLine.y1) == parseFloat(firstLine.y1)) ||
                (parseFloat(secondLine.x1) == parseFloat(firstLine.x2) && parseFloat(secondLine.y1) == parseFloat(firstLine.y2))))
            {
                return "(down)(downLeft)(end)(end)";
            }
            else if ((parseFloat(secondLine.x1) == parseFloat(firstLine.x1) || parseFloat(secondLine.x2) == parseFloat(firstLine.x1)) &&
                (parseFloat(secondLine.y1) > parseFloat(firstLine.y1) && parseFloat(secondLine.y1) < parseFloat(firstLine.y2)))
            {
                return "(down)(downLeft)(mid)(end)";
            }
            else if ((parseFloat(secondLine.x1) > parseFloat(firstLine.x1) && parseFloat(secondLine.x2) < parseFloat(firstLine.x2)) &&
                ((parseFloat(secondLine.y2) - (parseFloat(firstLine.x1) - parseFloat(secondLine.x2)) == parseFloat(firstLine.y1)) ||
                (parseFloat(secondLine.y2) - (parseFloat(firstLine.x1) - parseFloat(secondLine.x2)) == parseFloat(firstLine.y2))))
            {
                return "(down)(downLeft)(end)(mid)";
            }
            else
            {
                return "";
            }
        }
        else if (findLineDirection(secondLine) == "downRight") //
        {
            if ((parseFloat(secondLine.x1) == parseFloat(firstLine.x1) || parseFloat(secondLine.x2) == parseFloat(firstLine.x1)) &&
                ((parseFloat(secondLine.x2) == parseFloat(firstLine.x1) && parseFloat(secondLine.y2) == parseFloat(firstLine.y1)) ||
                (parseFloat(secondLine.x2) == parseFloat(firstLine.x2) && parseFloat(secondLine.y2) == parseFloat(firstLine.y2)) ||
                (parseFloat(secondLine.x1) == parseFloat(firstLine.x1) && parseFloat(secondLine.y1) == parseFloat(firstLine.y1)) ||
                (parseFloat(secondLine.x1) == parseFloat(firstLine.x2) && parseFloat(secondLine.y1) == parseFloat(firstLine.y2))))
            {
                return "(down)(downRight)(end)(end)";
            }
            else if ((parseFloat(secondLine.x1) == parseFloat(firstLine.x1) || parseFloat(secondLine.x2) == parseFloat(firstLine.x1)) && 
                ((parseFloat(secondLine.y2) > parseFloat(firstLine.y1) && parseFloat(secondLine.y2) < parseFloat(firstLine.y2)) ||
                (parseFloat(secondLine.y1) > parseFloat(firstLine.y1) && parseFloat(secondLine.y1) < parseFloat(firstLine.y2))))
            {
                return "(down)(downRight)(mid)(end)";
            }
            else if ((parseFloat(firstLine.x1) > parseFloat(secondLine.x1) && parseFloat(firstLine.x2) < parseFloat(secondLine.x2)) &&
                ((parseFloat(firstLine.y2) + (parseFloat(secondLine.x2) - parseFloat(firstLine.x2))) == parseFloat(secondLine.y2) ||
                (parseFloat(firstLine.y1) + (parseFloat(secondLine.x2) - parseFloat(firstLine.x2))) == parseFloat(secondLine.y2)))
            {
                return "(down)(downRight)(end)(mid)";
            }
            else
            {
                return "";
            }
        }
        else if (findLineDirection(secondLine) == "upLeft") // ***********
        {
            if ((parseFloat(secondLine.x1) == parseFloat(firstLine.x1) || parseFloat(secondLine.x2) == parseFloat(firstLine.x1)) &&
                ((parseFloat(secondLine.x2) == parseFloat(firstLine.x1) && parseFloat(secondLine.y2) == parseFloat(firstLine.y1)) ||
                (parseFloat(secondLine.x2) == parseFloat(firstLine.x2) && parseFloat(secondLine.y2) == parseFloat(firstLine.y2)) ||
                (parseFloat(secondLine.x1) == parseFloat(firstLine.x1) && parseFloat(secondLine.y1) == parseFloat(firstLine.y1)) ||
                (parseFloat(secondLine.x1) == parseFloat(firstLine.x2) && parseFloat(secondLine.y1) == parseFloat(firstLine.y2))))
            {
                return "(down)(upLeft)(end)(end)";
            }
            else if ((parseFloat(secondLine.x1) == parseFloat(firstLine.x1) || parseFloat(secondLine.x2) == parseFloat(firstLine.x1)) &&
                ((parseFloat(secondLine.y1) > parseFloat(firstLine.y1) && parseFloat(secondLine.y1) < parseFloat(firstLine.y2)) ||
                (parseFloat(secondLine.y2) > parseFloat(firstLine.y1) && parseFloat(secondLine.y2) < parseFloat(firstLine.y2))))
            {
                return "(down)(upLeft)(mid)(end)";
            }
            else if ((parseFloat(firstLine.x1) > parseFloat(secondLine.x1) && parseFloat(firstLine.x2) < parseFloat(secondLine.x2)) &&
                (parseFloat(firstLine.y1) - (parseFloat(firstLine.x1) - parseFloat(secondLine.x2)) == parseFloat(secondLine.y2) ||
                (parseFloat(firstLine.y2) + (parseFloat(firstLine.x1) - parseFloat(secondLine.x2)) == parseFloat(secondLine.y2))))
            {
                return "(down)(upLeft)(end)(mid)";
            }
            else {
                return "";
            }
        }        
    }
    else if (findLineDirection(firstLine) == "up") //
    {
        if (findLineDirection(secondLine) == "down") //
        {

        }
        else if (findLineDirection(secondLine) == "up") //
        {

        }
        else if (findLineDirection(secondLine) == "left") //
        {

        }
        else if (findLineDirection(secondLine) == "right") //
        {

        }
        else if (findLineDirection(secondLine) == "upRight")//
        {

        }
        else if (findLineDirection(secondLine) == "downRight") //
        {

        }
        else if (findLineDirection(secondLine) == "upLeft") //
        {

        }
        else if (findLineDirection(secondLine) == "downLeft") //
        {

        }
    }
    else if (findLineDirection(firstLine) == "left") //
    {
        if (findLineDirection(secondLine) == "down") //
        {

        }
        else if (findLineDirection(secondLine) == "up") //
        {

        }
        else if (findLineDirection(secondLine) == "left") //
        {

        }
        else if (findLineDirection(secondLine) == "right") //
        {

        }
        else if (findLineDirection(secondLine) == "upRight")//
        {

        }
        else if (findLineDirection(secondLine) == "downRight") //
        {

        }
        else if (findLineDirection(secondLine) == "upLeft") //
        {

        }
        else if (findLineDirection(secondLine) == "downLeft") //
        {

        }
    }
    else if (findLineDirection(firstLine) == "right") //
    {
        if (findLineDirection(secondLine) == "down") //
        {

        }
        else if (findLineDirection(secondLine) == "up") //
        {

        }
        else if (findLineDirection(secondLine) == "left") //
        {

        }
        else if (findLineDirection(secondLine) == "right") //
        {

        }
        else if (findLineDirection(secondLine) == "upRight")//
        {

        }
        else if (findLineDirection(secondLine) == "downRight") //
        {

        }
        else if (findLineDirection(secondLine) == "upLeft") //
        {

        }
        else if (findLineDirection(secondLine) == "downLeft") //
        {

        }
    }
    else if (findLineDirection(firstLine) == "upRight") //
    {
        if (findLineDirection(secondLine) == "down") //
        {

        }
        else if (findLineDirection(secondLine) == "up") //
        {

        }
        else if (findLineDirection(secondLine) == "left") //
        {

        }
        else if (findLineDirection(secondLine) == "right") //
        {

        }
        else if (findLineDirection(secondLine) == "upRight")//
        {

        }
        else if (findLineDirection(secondLine) == "downRight") //
        {

        }
        else if (findLineDirection(secondLine) == "upLeft") //
        {

        }
        else if (findLineDirection(secondLine) == "downLeft") //
        {

        }
    }
    else if (findLineDirection(firstLine) == "downRight") //
    {
        if (findLineDirection(secondLine) == "down") //
        {

        }
        else if (findLineDirection(secondLine) == "up") //
        {

        }
        else if (findLineDirection(secondLine) == "left") //
        {

        }
        else if (findLineDirection(secondLine) == "right") //
        {

        }
        else if (findLineDirection(secondLine) == "upRight")//
        {

        }
        else if (findLineDirection(secondLine) == "downRight") //
        {

        }
        else if (findLineDirection(secondLine) == "upLeft") //
        {

        }
        else if (findLineDirection(secondLine) == "downLeft") //
        {

        }
    }
    else if (findLineDirection(firstLine) == "upLeft") //
    {
        if (findLineDirection(secondLine) == "down") //
        {

        }
        else if (findLineDirection(secondLine) == "up") //
        {

        }
        else if (findLineDirection(secondLine) == "left") //
        {

        }
        else if (findLineDirection(secondLine) == "right") //
        {

        }
        else if (findLineDirection(secondLine) == "upRight")//
        {

        }
        else if (findLineDirection(secondLine) == "downRight") //
        {

        }
        else if (findLineDirection(secondLine) == "upLeft") //
        {

        }
        else if (findLineDirection(secondLine) == "downLeft") //
        {

        }
    }
    else if (findLineDirection(firstLine) == "downLeft") //
    {
        if (findLineDirection(secondLine) == "down") //
        {

        }
        else if (findLineDirection(secondLine) == "up") //
        {

        }
        else if (findLineDirection(secondLine) == "left") //
        {

        }
        else if (findLineDirection(secondLine) == "right") //
        {

        }
        else if (findLineDirection(secondLine) == "upRight")//
        {

        }
        else if (findLineDirection(secondLine) == "downRight") //
        {

        }
        else if (findLineDirection(secondLine) == "upLeft") //
        {

        }
        else if (findLineDirection(secondLine) == "downLeft") //
        {

        }
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
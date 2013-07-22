<%@ Page Title="New Project - Project Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WizardWallsAndMods.aspx.cs" Inherits="SunspaceDealerDesktop.WizardWallsAndMods" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <script src="Scripts/Validation.js"></script>
    <%-- Hidden field populating scripts 
    =================================== --%>
    <script>

        var detailsOfAllLines = '<%= (string)Session["coordList"] %>'; //all the coordinates and details of all the lines, coming from the session
        var lineList = detailsOfAllLines.substr(0, detailsOfAllLines.length - 1).split("/"); //a list of individual lines and their coordinates and details 
        var coordList = new Array(); //new 2d array to store each individual coordinate and details of each line
        for (var i = 0; i < lineList.length; i++) 
            coordList[i] = lineList[i].split(","); //populate the 2d array
        
        //var wallSlopeArray = new Array(); //array to store slope of each wall
        var wallLengthArray = new Array(); //array to store the length of each wall
        var wallLeftFillerArray = new Array(); //array to store left filler of each wall
        var wallRightFillerArray = new Array(); //array to store right filler of each wall
        var wallSetBackArray = new Array(); //array to store the setback for each wall
        var wallSoffitArray = new Array(); //array to store soffit length of each wall
        var wallStartHeightArray = new Array(); //array to store start height of each wall
        var wallEndHeightArray = new Array(); //array to store end height of each wall

        var wallProperties = [
            "wallId",
            "length",
            "height",
            "doors",
            "windows"
        ]
        var doorModProperties = [
            "index",
            "distanceFromLeft",
            "type",
            "style",
            "vinylTint",
            "numberOfVents",
            "transom",
            "transomVinyl",
            "transomGlass",
            "kickplate",
            "color",
            "internalGrills",
            "height",
            "width",
            "operator",
            "boxHeader",
            "glassTint",
            "hinge",
            "screenOptions",
            "hardware",
            "swing",
            "position"
        ]

        var backWall = "south"; //index of the back wall to determine wall heights
        var backWallIndex = 0;

        var existingWallCount = 0;
        var proposedWallCount = 0;
        for (var i = 0; i < coordList.length; i++) {
            if (coordList[i][4] === "E")
                existingWallCount++;
            else
                proposedWallCount++
        }

        var wallDoors = new Array(); //array to store the walls and their respective door objects

        var DOOR_MAX_WIDTH = '<%= DOOR_MAX_WIDTH %>';
        var DOOR_MIN_WIDTH = '<%= DOOR_MIN_WIDTH %>';
        var DOOR_FRENCH_MIN_WIDTH = '<%= DOOR_FRENCH_MIN_WIDTH %>';
        var DOOR_FRENCH_MAX_WIDTH = '<%= DOOR_FRENCH_MAX_WIDTH %>';
        var projection = 120; //hard coded for testing, will come from the previous pages in the wizard
        var soffitLength = 0; //hard coded for testing, will come from the previous pages in the wizard
        var RUN = 12; //a constant for run in calculating the slope, which is always 12 for slope over 12
        var model = '<%= currentModel %>';        
        
        $(document).ready(function () {
            $("#MainContent_btnQuestion3").click(submitDoorData);
        });

        /**
        This function calculates the "setback" of each wall, i.e. the number the current wall adds to the projection.
        This is calculated based on the orientation or facing-direction of the given wall. The value is then stored
        in an array called wallSetBackArray, at the appropriate index.
        @param index - index of the wall on which to calculate setback
        */
        function calculateSetBack(index) {
            /*
            SOUTH       :   ZERO
            NORTH       :   ZERO
            WEST        :   LENGTH
            EAST        :   NEGATIVE LENGTH
            SOUTHWEST   :   (2a^2 = L^2)
            NORTHWEST   :   (2a^2 = L^2)            
            SOUTHEAST   :   NEGATIVE (2a^2 = L^2)  
            NORTHEAST   :   NEGATIVE (2a^2 = L^2) 
            */

            //length of the given wall
            var L = document.getElementById("MainContent_txtWall" + index + "Length").value;

            //get the orientation of the given wall
            switch (coordList[index][5]) { //5 = orientation
                case "S": //if south
                case "N": //or north
                    wallSetBackArray[index] = 0; //line is horizontal, setback = 0
                    break;
                case "W": //if west
                    wallSetBackArray[index] = L; //line is horizontal facing west, setback is the same as the length of wall
                    break;
                case "E": //if east
                    wallSetBackArray[index] = -L; //similar to west, line is horizontal, facing east, setback is the same value as the length, but in the opposite direction
                    break;
                case "SW": //if southwest
                case "NW": //or northwest
                    wallSetBackArray[index] = Math.sqrt((Math.pow(L, 2)) / 2); //line is diagonal, use the given formula to calculate setback
                    break;
                case "SE": //if southeast
                case "NE": //or northeast
                    wallSetBackArray[index] = -(Math.sqrt((Math.pow(L, 2)) / 2)); //similar to SW and NW, use the given formula, but the value is negative
                    break;
            }
        }


        /**
        This function uses the setbackArray which is already populated by calculateSetBack() function
            to calculate the projection by simply adding each setback value.
        @return highestProjection - i.e. projection
        */
        function calculateProjection() {
            var tempProjection = 0; //variable to store each setback
            var highestProjection = 0; //variable to store the highest projection calculated, which at the end is the projection.
            for (var i = 0; i < wallSetBackArray.length; i++) { //run through all the setbacks
                tempProjection = +tempProjection + +wallSetBackArray[i]; //add the values to temp variable
                if (tempProjection > highestProjection) { //determine if the current temp projection is greater than the highest projection calculated
                    highestProjection = tempProjection; // reset the highest projection
                }
            }
            return highestProjection; //return the highest projection calculated
        }

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

        

        /*
        This function determines start and end height of each wall based on roof slope and length.
        Depending on which wall is considered the back wall for the purposes of roof slope, this function
            goes from wall 1 to the end setting start and end heights of each wall, or goes from the last
            wall to the first, setting end and start height of each wall (going backwards).
        */
        function determineStartAndEndHeightOfEachWall() {

            if (backWall === "north") { //if back wall is a north facing wall, i.e. is not existing wall 
                wallStartHeightArray[backWallIndex] = hidBackWallHeight.value;
                wallEndHeightArray[backWallIndex] = hidBackWallHeight.value;
                
                for (var i = (backWallIndex - 1); i >= 0; i--) { //0 = index of first wall


                    if (coordList[i][4] === "E") { //existing wall
                        //if (coordList[i][5] === "S") {

                        ///this is assuming that back wall is an existing wall...
                        wallStartHeightArray[i] = hidBackWallHeight.value;
                        wallEndHeightArray[i] = hidBackWallHeight.value;
                        //}

                    }
                    else { //proposed wall

                        wallEndHeightArray[i] = wallStartHeightArray[i + 1];

                        switch (coordList[i][5]) {
                            case "S": //if south
                            case "N": //or north
                                wallStartHeightArray[i] = wallEndtHeightArray[i];
                                break;
                            case "W": //if west
                                wallStartHeightArray[i] = wallEndHeightArray[i] - ((((wallLengthArray[i] - wallSoffitArray[i]) * m) / RUN).toFixed(2)); //determine rise based on slope and length, and subtract it from start height
                                break;
                            case "E": //if east
                                wallStartHeightArray[i] = wallEndHeightArray[i] + ((((wallLengthArray[i] - wallSoffitArray[i]) * m) / RUN).toFixed(2)); //determine rise based on slope and length, and add it to start height
                                break;
                            case "SW": //if southwest
                            case "SE": //or northwest
                                wallStartHeightArray[i] = wallEndHeightArray[i] - ((((wallSetBackArray[i] - wallSoffitArray[i]) * m) / RUN).toFixed(2)); //determine rise based on slope and setback, then subtract it from start height 
                                break;
                            case "NW": //if southeast
                            case "NE": //or northeast
                                wallStartHeightArray[i] = wallEndHeightArray[i] + ((((wallSetBackArray[i] - wallSoffitArray[i]) * m) / RUN).toFixed(2)); //determine rise based on slope and setback, then add it to start height 
                                break;
                        }
                    }
                }
            }
            else if (backWall === "south") { //if backwall is a south facing wall.. i.e. is existing
                for (var i = 0; i < coordList.length; i++) {
                    if (coordList[i][4] === "E") { //existing wall
                            wallStartHeightArray[i] = hidBackWallHeight.value;
                            wallEndHeightArray[i] = hidBackWallHeight.value;
                    }
                    else { //proposed wall
                    //if (coordList[i][4] === "P") {

                        wallStartHeightArray[i] = wallEndHeightArray[i - 1];

                        switch (coordList[i][5]) {
                            case "S": //if south
                            case "N": //or north
                                wallEndHeightArray[i] = wallStartHeightArray[i];
                                break;
                            case "W": //if west
                                wallEndHeightArray[i] = wallStartHeightArray[i] - ((((wallLengthArray[i] - wallSoffitArray[i]) * m) / RUN).toFixed(2)); //determine rise based on slope and length, and subtract it from start height
                                break;
                            case "E": //if east
                                wallEndHeightArray[i] = wallStartHeightArray[i] + ((((wallLengthArray[i] - wallSoffitArray[i]) * m) / RUN).toFixed(2)); //determine rise based on slope and length, and add it to start height
                                break;
                            case "SW": //if southwest
                            case "SE": //or northwest
                                wallEndHeightArray[i] = wallStartHeightArray[i] - ((((wallSetBackArray[i] - wallSoffitArray[i]) * m) / RUN).toFixed(2)); //determine rise based on slope and setback, then subtract it from start height 
                                break;
                            case "NW": //if southeast
                            case "NE": //or northeast
                                wallEndHeightArray[i] = wallStartHeightArray[i] + ((((wallSetBackArray[i] - wallSoffitArray[i]) * m) / RUN).toFixed(2)); //determine rise based on slope and setback, then add it to start height 
                                break;
                        }
                    }
                }
            }
        }


        /*
        This function populates the wall soffit array by determining the orientation of each wall 
            and checking to see if the soffit length would affect it or not 


            ////this function needs more functionality to account for soffit length on diagonal walls 
                and soffit length that's greater than the length of a wall
                    (if there a case when soffit length would be greater than wall length,
                     and span multiple walls???)

            ////note: soffit only affects the first wall and the last wall... 
                        if they are vertical and perpendicular to the existing walls


Dan H:
"There is no default size and yes a soffit can span multiple walls. When that occurs the first wall is considered no slope and the second wall is slope with soffit.
Soffit is not limited to first and last wall. The value saved is probably best though of as slopestart... the soffit of the house is, of course, used to determine that slopestart position."



see "new soffit conundrum" image on desktop for new soffit conundrum... 


        */
        function determineSoffitLengthOfEachWall() {
            
            var firstWallLength = document.getElementById("hidWall" + (existingWallCount + 1) + "Length").value;
            var lastWallLength = document.getElementById("hidWall" + (coordList.length - 1) + "Length").value;

            /*************************************************************************************/
            /*************************************************************************************/
            /*************************************************************************************/
            var firstWallStartPoint = coordList[existingWallCount + 1][2]; // 2 = y1
            var lastWallEndPoint = coordList[coordList.length - 1][3]; // 3 = y2
            /*************************************************************************************/
            /*************************************************************************************/
            /*************************************************************************************/

            for (var i = 0; i < coordList.length; i++) {
                if (i === (existingWallCount + 1) || i === (coordList.length - 1)) { //first proposed wall or last proposed wall
                    if (coordList[i][5] === "W" || coordList[i][5] === "E") { //if its vertical and perpendicular to existing wall 
                        wallSoffitArray[i] = soffitLength; //set the soffit length
                        if (firstWallLength > lastWallLength) //if different lengths
                            wallSoffitArray[existingWallCount + 1] += (firstWallLength - lastWallLength); //add the difference to the appropriate wall
                        else if (lastWallLength > firstWallLength) //if different lengths
                            wallSoffitArray[coordList.length - 1] += (lastWallLength - firstWallLength); //add the difference to the appropriate wall
                    }
                    else //if they are not vertical perpendicular
                        wallSoffitArray[i] = 0; //no soffit
                }
                else //if not first or last proposed wall
                    wallSoffitArray[i] = 0; //no soffit
            }


            //for (var i = 0; i < coordList.length; i++)
            //    if (coordList[i][4] === "E") { //if existing wall  
            //        //wallSoffitArray[index] = 0; //slope is unimportant
            //    }
            //    else { //if proposed wall
            //        //get the orientation of the proposed wall
            //        switch (coordList[i][5]) { //5 = orientation
            //            case "S": //if south
            //            case "N": //or north
            //                wallSoffitArray[i] = 0; //soffit length is unimportant thus zero
            //                break;

            //                /**********************************************************************************************/
            //                /**********************************************************************************************/
            //                /**********************************************************************************************/
            //                /**********************************************************************************************/
            //                /**********************************************************************************************/
            //            case "SW": //or southwest
            //            case "NW": //or northwest
            //            case "SE": //or southeast
            //            case "NE": //or northeast
            //                /**********************************************************************************************/
            //                /**********************************************************************************************/
            //                /**********************************************************************************************/
            //                /**********************************************************************************************/
            //                /**********************************************************************************************/
            //                break;
            //            case "W": //if west
            //            case "E": //or
            //                coordList

            //                
                                /**********************************************************************************************/
                                /******************* the following was done to account for multiple ***************************/
                                /*******************    proposed walls touching existing walls      ***************************/
                                /*******************    multiple existing walls not relevant atm    ***************************/
                                /**********************************************************************************************/
                                //for (var j = 0; j < coordList.length; j++) { //run through all the walls
                                //    if (coordList[j][4] === "E") { //if there's an existing wall
                                //        if (coordList[j][2] === coordList[i][2]) {  ///y1 = y1, check if the coordinates match, i.e. proposed line is touching the existing line
                                //            wallSoffitArray[i] = soffitLength; //set the soffit length
                                //            break; //break out of the loop
                                //        }
                                //    }
                                //}
                                //break; //break out of the switch
                                /**********************************************************************************************/
                                /**********************************************************************************************/
                                /**********************************************************************************************/
                                /**********************************************************************************************/
                                /**********************************************************************************************/

                                /**********************************************************************************************/
                                /******************* the following was done to differentiate between ***************************/
                                /*******************    beginning soffit and ending soffit       ***************************/
                                /*******************    soffit placement on wall no longer desired    ***************************/
                                /**********************************************************************************************/
                                //case "E": //if east
                                //    for (var j = 0; j < coordList.length; j++) { //run through all the walls
                                //        if (coordList[j][4] === "E") { //if there's an existing wall
                                //            if (coordList[j][2] === coordList[i][2]) {  ///y1 = y1, check if the coordinates match, i.e. proposed line is touching the existing line
                                //                wallSoffitArray[i] = -soffitLength; //should probably be positive soffit length, but just to differentiate between beginning soffit and ending soffit
                                //                break; //break out of the loop
                                //            }
                                //        }
                                //    }
                                //    break; //break out of the switch
                                /**********************************************************************************************/
                                /**********************************************************************************************/
                                /**********************************************************************************************/
                                /**********************************************************************************************/
                                /**********************************************************************************************/
                            
                //}
            //}
        }

        /**
        This function calculates the slope (over 12), based on the given heights
        @return slope over 12
        */
        function calculateSlope() {
            var rise; //m = ((rise * run)/(projection - soffitLength)) slope over 12

            rise = ((document.getElementById("MainContent_txtBackWallHeight").value //textbox value
                + document.getElementById("MainContent_ddlBackInchFractions").options[document.getElementById("MainContent_ddlBackInchFractions").selectedIndex].value) //dropdown listitem value
                - (document.getElementById("MainContent_txtFrontWallHeight").value //textbox value
                + document.getElementById("MainContent_ddlFrontInchFractions").options[document.getElementById("MainContent_ddlFrontInchFractions").selectedIndex].value)); //dropdown listitem value

            return (((rise * RUN) / (projection - soffitLength)).toFixed(2));  //slope over 12, rounded to 2 decimal places
        }


        /**
        This function calculates the rise based on the slope (over 12) and one of the heights
        @return rise (from the slope equation)
        */
        function calculateRise() {
            var m;    //m = ((rise * run)/(projection - soffitLength)) slope over 12

            m = document.getElementById("MainContent_txtRoofSlope").value; //get the slope from the textbox

            return ((((projection - soffitLength) * m) / RUN).toFixed(2)); //rise, rounded to 2 decimal places
        }

        /**
        This function is used to validate the user input for question 1, i.e. wall lengths
        */
        function checkQuestion1() {
            //disable 'next slide' button until after validation (this is currently enabled for debugging purposes)
            document.getElementById('MainContent_btnQuestion1').disabled = false;
            //document.getElementById('MainContent_btnQuestion2').disabled = false;
            //document.getElementById('MainContent_btnQuestion3').disabled = false;

            //var lengthList = new Array();
            var isValid;// = true; //to do valid input or invalid input logic
            var answer = ""; //answer, to be displayed on the side panel

            //run through all the textboxes and check if the values in there are valid numbers
            for (var i = 1; i <= lineList.length; i++) {
                if (coordList[i - 1][4] === "P") {
                    if (isNaN(document.getElementById("MainContent_txtWall" + (i) + "Length").value) //if invalid numbers
                        || document.getElementById("MainContent_txtWall" + (i) + "Length").value <= 0 //zero should be changed to MIN_WALL_LENGTH
                        || isNaN(document.getElementById("MainContent_txtWall" + (i) + "LeftFiller").value)
                        || document.getElementById("MainContent_txtWall" + (i) + "LeftFiller").value < 0
                        || isNaN(document.getElementById("MainContent_txtWall" + (i) + "RightFiller").value)
                        || document.getElementById("MainContent_txtWall" + (i) + "RightFiller").value < 0)
                        isValid = false; //set isvalid to false
                    else
                        isValid = true;
                }
            }

            if (isValid) { //if everything is valid

                determineSoffitLengthOfEachWall(); //calculate and store soffitlength of each wall
                for (var i = 1; i <= lineList.length; i++) { //populate the hidden fields for each wall
                    if (coordList[i - 1][4] === "P") {
                        calculateSetBack((i - 1)); //calculate setback of the given wall
                        
                        document.getElementById("hidWall" + i + "SetBack").value = wallSetBackArray[i - 1]; //store wall setback 
                        wallLeftFillerArray[i-1] = document.getElementById("hidWall" + i + "LeftFiller").value = document.getElementById("MainContent_txtWall" + i + "LeftFiller").value + document.getElementById("MainContent_ddlWall" + i + "LeftInchFractions").options[document.getElementById("MainContent_ddlWall" + i + "LeftInchFractions").selectedIndex].value; //store left filler
                        wallLengthArray[i-1] = document.getElementById("hidWall" + i + "Length").value = document.getElementById("MainContent_txtWall" + i + "Length").value + document.getElementById("MainContent_ddlWall" + i + "InchFractions").options[document.getElementById("MainContent_ddlWall" + i + "InchFractions").selectedIndex].value; //store length
                        wallRightFillerArray[i-1] = document.getElementById("hidWall" + i + "RightFiller").value = document.getElementById("MainContent_txtWall" + i + "RightFiller").value + document.getElementById("MainContent_ddlWall" + i + "RightInchFractions").options[document.getElementById("MainContent_ddlWall" + i + "RightInchFractions").selectedIndex].value; //store right filler
                        document.getElementById("hidWall" + i + "SoffitLength").value = wallSoffitArray[i - 1];//store wall soffitlength
                        answer += "Wall " + i + ": " + document.getElementById("hidWall" + i + "Length").value; //store the values in the answer variable to be displayed
                  
                    }
                }
                //store projection in the projection variable and hidden field
                document.getElementById("MainContent_hidProjection").value = projection = calculateProjection(); 

                //Set answer on side pager and enable button
                $('#MainContent_lblWallLengthsAnswer').text(answer);
                document.getElementById('pagerOne').style.display = "inline";
                document.getElementById('MainContent_btnQuestion1').disabled = false;
            }
            else { //not valid
                //error styling or something
                //Set answer on side pager and enable button
                $('#MainContent_lblWallLengthsAnswer').text("Invalid Input");
                document.getElementById('pagerOne').style.display = "inline";
                document.getElementById('MainContent_btnQuestion1').disabled = false;
            }

            return false;
        }

        /**
        This function is used to validate the user input for question 2, i.e. wall heights.
        Depending on the user selection of the radio button, it also calculates the slope, or one of the heights 
            by calling the appropriate functions
        */
        function checkQuestion2() {
            //alert("here i am, rock you like a hurricane"); //i'll leave that in there for shenanigans
            //disable 'next slide' button until after validation (this is currently enabled for debugging purposes)
            //document.getElementById('MainContent_btnQuestion1').disabled = false;
            //document.getElementById('MainContent_btnQuestion2').disabled = false;
            //document.getElementById('MainContent_btnQuestion3').disabled = false;

            var isValid = true; //to do valid input or invalid input logic
            var answer = ""; //answer to be displayed on the side panel
            
            //if user wants to auto calculate the slope
            if (document.getElementById("MainContent_radAutoRoofSlope").checked) {
                //we have front wall height and back wall height, calculate slope
                if (!isNaN(document.getElementById("MainContent_txtBackWallHeight").value) //if the other textbox values are valid
                    && document.getElementById("MainContent_txtBackWallHeight").value > 0
                    && !isNaN(document.getElementById("MainContent_txtFrontWallHeight").value)
                    && document.getElementById("MainContent_txtFrontWallHeight").value > 0) {
                    
                    isValid = true; //valid is true
                    
                    document.getElementById("MainContent_txtRoofSlope").value = calculateSlope(); //output the slope to the appropriate textbox
                }
                else //if textbox values are not valid
                    isValid = false; //valid is false
            }
            //the user wants to auto calculate front height
            else if (document.getElementById("MainContent_radAutoFrontWallHeight").checked) {
                //we have back wall height and slope, calculate front wall height
                if (!isNaN(document.getElementById("MainContent_txtBackWallHeight").value) //if the other textbox values are valid
                    && document.getElementById("MainContent_txtBackWallHeight").value > 0
                    && !isNaN(document.getElementById("MainContent_txtRoofSlope").value)
                    && document.getElementById("MainContent_txtRoofSlope").value > 0) {

                    var frontHeight; //to store calculated frontwall height
                    var newFrontHeight; //to store the correctred front wall height
                    var rise; //to store the calculated rise from the slope equation

                    isValid = true; //valid is true

                    rise = calculateRise(); //calculate and store rise
                    
                    //calculate frontwall height by subtracting rise from the backwall height
                    frontHeight = +(document.getElementById("MainContent_txtBackWallHeight").value + document.getElementById("MainContent_ddlBackInchFractions").options[document.getElementById("MainContent_ddlBackInchFractions").selectedIndex].value) - +rise;

                    //calculate new front wall height with the valid eighth inch decimal
                    newFrontHeight = validateDecimal(frontHeight);

                    //output the whole number of the new front wall height to the textbox
                    document.getElementById("MainContent_txtFrontWallHeight").value = newFrontHeight[0];

                    //select the decimal value of the new front wall height in the dropdown list
                    for (var i = 0; i < document.getElementById("MainContent_ddlFrontInchFractions").length - 1 ; i++) { //run through each element of the dropdown
                        if ((newFrontHeight[1] += '') == ("0" + document.getElementById("MainContent_ddlFrontInchFractions").options[i].value)) //if the value in the dropdown list matches the decimal value
                            document.getElementById("MainContent_ddlFrontInchFractions").selectedIndex = i; //select the index of that value
                    }

                    //check if the old front wall height and the new front wall height are different
                    if (frontHeight != (+newFrontHeight[0] + +newFrontHeight[1])) //if they are different
                        document.getElementById("MainContent_txtRoofSlope").value = calculateSlope(); //recalculate the slope based on the new front wall height
                }
                else //other textbox values are not valid
                    isValid = false; //valid is false
            }
            //the user wants to auto calculate back wall height
            else if (document.getElementById("MainContent_radAutoBackWallHeight").checked) {
                //we have front wall height and slope, calculate back wall height
                if (!isNaN(document.getElementById("MainContent_txtFrontWallHeight").value) //check if other textbox values are valid
                    && document.getElementById("MainContent_txtFrontWallHeight").value > 0
                    && !isNaN(document.getElementById("MainContent_txtRoofSlope").value)
                    && document.getElementById("MainContent_txtRoofSlope").value > 0) {

                    var backHeight; //to store calculated backwall height
                    var newBackHeight; //to store corrected back wall height
                    var rise; //to store rise from the slope equation

                    isValid = true; //valid is true

                    rise = calculateRise(); //calculate and store rise

                    //calculate the backwall height by adding the rise to the front wall height
                    backHeight = +(document.getElementById("MainContent_txtFrontWallHeight").value + document.getElementById("MainContent_ddlFrontInchFractions").options[document.getElementById("MainContent_ddlFrontInchFractions").selectedIndex].value) + +rise;

                    //calculate new back wall height with valid eighth inch decimal
                    newBackHeight = validateDecimal(backHeight);

                    //output the whole number of the new back wall height to the textbox
                    document.getElementById("MainContent_txtBackWallHeight").value = newBackHeight[0];

                    //select the decimal value of the new back wall height in the dropdown list
                    for (var i = 0; i < document.getElementById("MainContent_ddlBackInchFractions").length - 1 ; i++) { //run through each element of the dropdown
                        if ((newBackHeight[1] += '') == ("0" + document.getElementById("MainContent_ddlBacktInchFractions").options[i].value)) //if the value in the dropdown list matches the decimal value
                            document.getElementById("MainContent_ddlBackInchFractions").selectedIndex = i; //select the index of that value
                    }

                    //check if the old back wall height and the new back wall height are different
                    if (backHeight != (+newBackHeight[0] + +newBackHeight[1])) //if they are different
                        document.getElementById("MainContent_txtRoofSlope").value = calculateSlope(); //recalculate the slope based on the new back wall height
                }
                else //value in the other textboxes are not valid
                    isValid = false; //valid is false
            }

            //if the calculated slope is invalid, i.e. negative or zero
            if (document.getElementById("MainContent_txtRoofSlope").value <= 0)
                isValid = false; //valid is false
            else //if the slope is valid
                isValid = true; //valid is true
            
            if (isValid) { //if all is valid
                //store the values in the appropriate hidden fields
                document.getElementById("MainContent_hidBackWallHeight").value = document.getElementById("MainContent_txtBackWallHeight").value + document.getElementById("MainContent_ddlBackInchFractions").options[document.getElementById("MainContent_ddlBackInchFractions").selectedIndex].value;
                document.getElementById("MainContent_hidFrontWallHeight").value = document.getElementById("MainContent_txtFrontWallHeight").value + document.getElementById("MainContent_ddlFrontInchFractions").options[document.getElementById("MainContent_ddlFrontInchFractions").selectedIndex].value;
                document.getElementById("MainContent_hidRoofSlope").value = document.getElementById("MainContent_txtRoofSlope").value;

                //store the values in the answer variable to be displayed on the side panel
                answer += "Back Wall: " + document.getElementById("MainContent_hidBackWallHeight").value;
                answer += "Front Wall: " + document.getElementById("MainContent_hidFrontWallHeight").value;
                answer += "Roof Slope: " + document.getElementById("MainContent_hidRoofSlope").value;

                //display the answer on the side panel
                $('#MainContent_lblWallHeightsAnswer').text(answer);
                document.getElementById('pagerTwo').style.display = "inline";
                document.getElementById('MainContent_btnQuestion2').disabled = false;   
            }
            else {
                //error styling or something
                //Set answer on side pager and enable button
                $('#MainContent_lblWallHeightsAnswer').text("Invalid Input");
                document.getElementById('pagerTwo').style.display = "inline";
                document.getElementById('MainContent_btnQuestion2').disabled = false;
            }
            return false;
        }
        
        /**
        *typeOfRowsDisplayed
        *This function finds which type of door is selected and displays the appropriate fields
        *from a table hidden to the user
        *@param wallNumber - holds an integer to know which wall is currently being affected
        *@param type - gets the type of door selected (i.e. Cabana, French, Patio, Opening Only (No Door))
        */
        function typeRowsDisplayed(wallNumber, type) {

            /****START:TABLE ROWS BY ID****/
            var doorTitle = document.getElementById("MainContent_rowDoorTitle" + wallNumber + type);
            var doorStyleTable = document.getElementById("MainContent_rowDoorStyle" + wallNumber + type);
            var doorVinylTint = document.getElementById("MainContent_rowDoorVinylTint" + wallNumber + type);
            var doorNumberOfVents = document.getElementById("MainContent_rowDoorNumberOfVents" + wallNumber + type);
            var doorTransom = document.getElementById("MainContent_rowDoorTransom" + wallNumber + type);
            var doorTransomVinyl = document.getElementById("MainContent_rowDoorTransomVinylTypes" + wallNumber + type);
            var doorTransomGlass = document.getElementById("MainContent_rowDoorTransomGlassTypes" + wallNumber + type);
            var doorKickplate = document.getElementById("MainContent_rowDoorKickplate" + wallNumber + type);
            var doorKicplateCustom = document.getElementById("MainContent_rowDoorCustomKickplate" + wallNumber + type);
            var doorColor = document.getElementById("MainContent_rowDoorColor" + wallNumber + type);
            var doorInternalGrillsYes = document.getElementById("MainContent_rowDoorInternalGrillsYes" + wallNumber + type);
            var doorInternalGrillsNo = document.getElementById("MainContent_rowDoorInternalGrillsNo" + wallNumber + type);
            var doorHeight = document.getElementById("MainContent_rowDoorHeight" + wallNumber + type);
            var doorHeightCustom = document.getElementById("MainContent_rowDoorCustomHeight" + wallNumber + type);
            var doorWidth = document.getElementById("MainContent_rowDoorWidth" + wallNumber + type);
            var doorWidthCustom = document.getElementById("MainContent_rowDoorCustomWidth" + wallNumber + type);
            var doorOperatorLHH = document.getElementById("MainContent_rowDoorOperatorLHH" + wallNumber + type);
            var doorOperatorRHH = document.getElementById("MainContent_rowDoorOperatorRHH" + wallNumber + type);
            var doorBoxHeader = document.getElementById("MainContent_rowDoorBoxHeader" + wallNumber + type);
            var doorGlassTint = document.getElementById("MainContent_rowDoorGlassTint" + wallNumber + type);
            var doorLHH = document.getElementById("MainContent_rowDoorLHH" + wallNumber + type);
            var doorRHH = document.getElementById("MainContent_rowDoorRHH" + wallNumber + type);
            var doorScreenOptions = document.getElementById("MainContent_rowDoorScreenOptions" + wallNumber + type);            
            var doorHardware = document.getElementById("MainContent_rowDoorHardware" + wallNumber + type);
            var doorSwingIn = document.getElementById("MainContent_rowDoorSwingIn" + wallNumber + type);
            var doorSwingOut = document.getElementById("MainContent_rowDoorSwingOut" + wallNumber + type);
            var doorPosition = document.getElementById("MainContent_rowDoorPosition" + wallNumber + type);
            var doorPositionCustom = document.getElementById("MainContent_rowDoorCustomPosition" + wallNumber + type);
            /****END:TABLE ROWS BY ID****/

            /****START:RADIO BUTTONS TO BE CHECKED INITIALLY****/
            var doorInternalGrillYesChecked = document.getElementById("MainContent_radDoorInternalGrillsYes" + wallNumber + type);
            var doorPositionCustom = document.getElementById("MainContent_ddlDoorPosition" + wallNumber + type).options[document.getElementById("MainContent_ddlDoorPosition" + wallNumber + type).selectedIndex].value;
            var doorLHHChecked = document.getElementById("MainContent_radDoorLHH" + wallNumber + type);
            var doorSwingInChecked = document.getElementById("MainContent_radDoorSwingIn" + wallNumber + type);

            //FRENCH/PATIO DOOR ONLY
            var doorOperatorLHHChecked = document.getElementById("MainContent_radDoorOperatorLHH" + wallNumber + type);
            /****END:RADIO BUTTONS TO BE CHECKED INITIALLY****/

            //If type is Cabana, display the appropriate fields
            if (type == "Cabana") {               

                //General
                doorTitle.style.display = "inherit";
                doorStyleTable.style.display = "inherit";
                doorColor.style.display = "inherit";
                doorHeight.style.display = "inherit";
                doorWidth.style.display = "inherit";
                doorBoxHeader.style.display = "inherit";
                doorTransom.style.display = "inherit";
                doorKickplate.style.display = "inherit";

                //Cabana Specific                            
                doorGlassTint.style.display = "inherit";
                doorLHH.style.display = "inherit";
                doorRHH.style.display = "inherit";
                doorSwingIn.style.display = "inherit";
                doorSwingOut.style.display = "inherit";
                doorHardware.style.display = "inherit";
                doorPosition.style.display = "inherit";
                            
                if (doorPositionCustom == "cPosition") {
                    customDimension(wallNumber, type, "Position");
                }

                //Model Specifics
                if (model === "M400") {                                
                    doorInternalGrillsYes.style.display = "inherit";
                    doorInternalGrillsNo.style.display = "inherit";
                    doorInternalGrillYesChecked.setAttribute("checked", "checked");
                }

                //Radio button defaults
                doorLHHChecked.setAttribute("checked", "checked");
                doorSwingInChecked.setAttribute("checked", "checked");

                doorStyle(type, wallNumber);
                doorTransomStyle(type, wallNumber);
            }
                //If type is French, display the appropriate fields
            else if (type == "French") {                

                //General
                doorTitle.style.display = "inherit";
                doorStyleTable.style.display = "inherit";
                doorColor.style.display = "inherit";
                doorHeight.style.display = "inherit";
                doorWidth.style.display = "inherit";
                doorBoxHeader.style.display = "inherit";
                doorTransom.style.display = "inherit";
                doorKickplate.style.display = "inherit";

                //French specific
                doorOperatorLHH.style.display = "inherit";
                doorOperatorRHH.style.display = "inherit";
                doorSwingIn.style.display = "inherit";
                doorSwingOut.style.display = "inherit";
                doorHardware.style.display = "inherit";
                doorPosition.style.display = "inherit";

                if (doorPositionCustom == "cPosition") {
                    customDimension(wallNumber, type, "Position");
                }

                //Model Specifics
                if (model === "M400") {
                    doorInternalGrillsYes.style.display = "inherit";
                    doorInternalGrillsNo.style.display = "inherit";
                    doorInternalGrillYesChecked.setAttribute("checked", "checked");
                }

                //Radio button defaults
                doorOperatorLHHChecked.setAttribute("checked", "checked");
                doorSwingInChecked.setAttribute("checked", "checked");

                doorStyle(type, wallNumber);
                doorTransomStyle(type, wallNumber);
            }
                //If type is Patio, display the appropriate fields
            else if (type == "Patio") {

                //General
                doorTitle.style.display = "inherit";
                doorStyleTable.style.display = "inherit";
                doorColor.style.display = "inherit";
                doorHeight.style.display = "inherit";
                doorWidth.style.display = "inherit";
                doorTransom.style.display = "inherit";
                doorBoxHeader.style.display = "inherit";

                //Patio Specifics
                doorGlassTint.style.display = "inherit";
                doorOperatorLHH.style.display = "inherit";
                doorOperatorRHH.style.display = "inherit";
                doorPosition.style.display = "inherit";
                doorScreenOptions.style.display = "inherit";

                if (doorPositionCustom == "cPosition") {
                    customDimension(wallNumber, type, "Position");
                }

                //Model Specifics
                if (model === "M400") {
                    doorInternalGrillsYes.style.display = "inherit";
                    doorInternalGrillsNo.style.display = "inherit";
                    doorInternalGrillYesChecked.setAttribute("checked", "checked");
                }

                //Radio button defaults
                doorOperatorLHHChecked.setAttribute("checked", "checked");

                doorStyle(type, wallNumber);
                doorTransomStyle(type, wallNumber);
            }
                //If type is NoDoor, display the appropriate fields
            else if (type == "NoDoor") {

                doorHeight.style.display = "inherit";
                doorWidth.style.display = "inherit";
                doorPosition.style.display = "inherit";

                if (doorPositionCustom == "cPosition") {
                    customDimension(wallNumber, type, "Position");
                }
            }                    
        }

        /**
        *customDimension
        *Checks the drop down selection on change, if the selection is custom, displays additional fields,
        *else custom field is hidden (i.e. css style.display = none)
        *@param wallNumber - holds an integer to know which wall is currently being affected
        *@param type - gets the type of door selected (i.e. Cabana, French, Patio, Opening Only (No Door));
        *@param dimension - gets the dimension currently being called (i.e Width, Height)
        */
        function customDimension(wallNumber, type, dimension) {

            var dimensionDDL = document.getElementById('MainContent_ddlDoor' + dimension + wallNumber + type).options[document.getElementById('MainContent_ddlDoor' + dimension + wallNumber + type).selectedIndex].value;

            if (document.getElementById('MainContent_radType' + wallNumber + type).checked && dimensionDDL == 'c' + dimension) {
                document.getElementById('MainContent_rowDoorCustom' + dimension + wallNumber + type).style.display = 'inherit';
            }
            else {
                document.getElementById('MainContent_rowDoorCustom' + dimension + wallNumber + type).style.display = 'none';
            }
        }

        /**
        *doorStyle
        *Door style function is triggered when the user selects Vertical Four Track, 
        *vinyl tint becomes displayed, since Vertical Four Track is the only door style
        *that has vinyl tint options
        *@param type - holds the type of door selected (i.e. Cabana, French, Patio, Opening Only (No Door));
        *@param wallNumber - holds an integer to know which wall is currently being affected
        */
        function doorStyle(type, wallNumber) {
            var heightDDL = document.getElementById('MainContent_ddlDoorStyle' + wallNumber + type).options[document.getElementById('MainContent_ddlDoorStyle' + wallNumber + type).selectedIndex].value;

            if (heightDDL == 'v4TCabana') {
                document.getElementById('MainContent_rowDoorVinylTint' + wallNumber + type).style.display = 'inherit';
                document.getElementById('MainContent_rowDoorNumberOfVents' + wallNumber + type).style.display = 'inherit';
            }
            else {
                document.getElementById('MainContent_rowDoorVinylTint' + wallNumber + type).style.display = 'none';
                document.getElementById('MainContent_rowDoorNumberOfVents' + wallNumber + type).style.display = 'none';
            }
        }

        /**
        *doorTransomStyle
        *Door transom style function is triggered when the user selects Vinyl or Glass, 
        *vinyl or glass tint becomes displayed.
        *@param type - gets the type of door selected (i.e. Cabana, French, Patio, Opening Only (No Door));
        *@param wallNumber - holds an integer to know which wall is currently being affected
        */
        function doorTransomStyle(type, wallNumber) {

            var transomType = document.getElementById('MainContent_ddlDoorTransom' + wallNumber + type).options[document.getElementById('MainContent_ddlDoorTransom' + wallNumber + type).selectedIndex].value;

            if (transomType == 'vinyl') {
                document.getElementById('MainContent_rowDoorTransomVinylTypes' + wallNumber + type).style.display = 'inherit';
                document.getElementById('MainContent_rowDoorTransomGlassTypes' + wallNumber + type).style.display = 'none';
            }
            else if (transomType == 'glass') {
                document.getElementById('MainContent_rowDoorTransomVinylTypes' + wallNumber + type).style.display = 'none';
                document.getElementById('MainContent_rowDoorTransomGlassTypes' + wallNumber + type).style.display = 'inherit';
            }
            else {
                document.getElementById('MainContent_rowDoorTransomVinylTypes' + wallNumber + type).style.display = 'none';
                document.getElementById('MainContent_rowDoorTransomGlassTypes' + wallNumber + type).style.display = 'none';
            }
        }

        /**
        *doorKickplateStyle
        *Door kickplate style function changes the fields being displayed based on the selected index.
        *@param type - gets the type of door selected (i.e. Cabana, French, Patio, Opening Only (No Door));
        *@param wallNumber - holds an integer to know which wall is currently being affected
        */
        function doorKickplateStyle(type, wallNumber) {

            var KickplateType = document.getElementById('MainContent_ddlDoorKickplate' + wallNumber + type).options[document.getElementById('MainContent_ddlDoorKickplate' + wallNumber + type).selectedIndex].value;

            if (KickplateType == 'cKickplate') {
                document.getElementById('MainContent_rowDoorCustomKickplate' + wallNumber + type).style.display = 'inherit';
            }
            else {
                document.getElementById('MainContent_rowDoorCustomKickplate' + wallNumber + type).style.display = 'none';
            }
        }

        /**
        *calculateActualDoorDimension
        *This function calculates a doors actual dimension based on model number, dimension, custom dimension, and
        *the current wall selected. This is needed because there is frame added to doors anywhere from 1.125 
        *to 3.625 depending on the type of door and the sunroom model.
        *@param type - gets the type of door selected (i.e. Cabana, French, Patio, Opening Only (No Door));
        *@param dimension - gets the dimension currently being called (i.e. Width, Height)
        *@param custom - this argument is used to determine if a custom dimension is being entered and which controls to use
        *@param wallNumber - holds an integer to know which wall is currently being affected
        */
        function calculateActualDoorDimension(type, dimension, custom, wallNumber) {

            var newDimension;

            var controlToUse;

            if (custom === true) {
                controlToUse = parseFloat(document.getElementById('MainContent_txtDoorCustom' + dimension + wallNumber + type).value)
                    + parseFloat(document.getElementById('MainContent_ddlInchCustom' + dimension + wallNumber + type).options[document.getElementById('MainContent_ddlInchCustom' + dimension + wallNumber + type).selectedIndex].value);
            }
            else {

                controlToUse = parseFloat(document.getElementById('MainContent_ddlDoor' + dimension + wallNumber + type).options[document.getElementById('MainContent_ddlDoor' + dimension + wallNumber + type).selectedIndex].value);
            }

            if (type === 'Cabana') {
                newDimension = (model === 400) ? controlToUse + 3.625 : controlToUse + 2.125;
            }
            else if (type === 'French') {
                newDimension = (model === 400) ? ((controlToUse + 3.625) - 1.625) * 2 + 2 : ((controlToUse + 2.125) - 1.625) * 2 + 2;
            }
            else if (type == 'Patio') {
                newDimension = (model === 400) ? controlToUse + 1.165 : controlToUse + 1.125;
            }
            else {
                newDimension = controlToUse;
            }   

            return newDimension;
        }
            
        /**
        *addDoor
        *This function is used to add doors to an array of wall objects
        *@param wallNumber - holds an integer to know which wall is currently being affected
        *@param type - gets the type of door selected (i.e. Cabana, French, Patio, Opening Only (No Door))
        */
        function addDoor(wallNumber, type) {
                        
            /****PAGER VARIABLES****/
            var pagerText = document.getElementById("MainContent_lblQuestion3SpaceInfoWall" + wallNumber);
            var pagerTextAnswer = document.getElementById("wall" + wallNumber + "DoorsAdded");
            var pagerTextDoor = document.getElementById("MainContent_lblQuestion3DoorsInfoWall" + wallNumber);
            var proposedWall = document.getElementById("MainContent_lblTextArea" + wallNumber);
                        
            /****LOGICAL AND FUNCTIONALITY VARIABLES****/                    
            var isValid = true;
            var spacesRemaining = null;
            var doorMods = new Array();

            /****CALCULATION VARIABLES****/
            var wallLength = parseFloat(document.getElementById('MainContent_txtWall' + wallNumber + 'Length').value);                            
            var leftFiller = parseFloat(document.getElementById('MainContent_txtWall' + wallNumber + 'LeftFiller').value);
            var rightFiller = parseFloat(document.getElementById('MainContent_txtWall' + wallNumber + 'RightFiller').value);
            var usableSpace = wallLength - leftFiller - rightFiller;
            var doorCustomPosition = parseFloat(document.getElementById('MainContent_txtDoorCustomPosition' + wallNumber + type).value
                + document.getElementById('MainContent_ddlInchSpecificLeft' + wallNumber + type).options[document.getElementById('MainContent_ddlInchSpecificLeft' + wallNumber + type).selectedIndex].value);
            var positionDropDown = document.getElementById('MainContent_ddlDoorPosition' + wallNumber + type).options[document.getElementById('MainContent_ddlDoorPosition' + wallNumber + type).selectedIndex].value;
            var widthDropDown = document.getElementById('MainContent_ddlDoorWidth' + wallNumber + type).options[document.getElementById('MainContent_ddlDoorWidth' + wallNumber + type).selectedIndex].value;
            var heightDropDown = document.getElementById('MainContent_ddlDoorHeight' + wallNumber + type).options[document.getElementById('MainContent_ddlDoorHeight' + wallNumber + type).selectedIndex].value;

            /****START:VARIABLES USED TO STORE DOOR INFO****/
            var doorWidth;
            var doorHeight;
            /****END:VARIABLES USED TO STORE DOOR INFO****/

            /*Set the variable to the appropriate value to be used for calculations*/
            if (widthDropDown === "cWidth") {                            
                doorWidth = parseFloat(calculateActualDoorDimension(type, 'Width', true, wallNumber));
            }
            else {
                doorWidth = parseFloat(calculateActualDoorDimension(type, 'Width', false, wallNumber));                            
            }

            /*Set the variable to the appropriate value to be used for calculations*/
            if (widthDropDown === "cHeight") {
                doorHeight = parseFloat(calculateActualDoorDimension(type, 'Height', true, wallNumber));
            }
            else {
                doorHeight = parseFloat(calculateActualDoorDimension(type, 'Height', false, wallNumber));
            }
                        

            /*Insert the door with the appropriate variables based on drop down selected index*/
            if (positionDropDown === "left") {
                doorMods[doorMods.length] = {
                    "index": doorMods.length + 1,
                    "width": doorWidth,
                    "distanceFromLeft": 0
                };
            }
            else if (positionDropDown === "right") {
                doorMods[doorMods.length] = {
                    "index": doorMods.length + 1,
                    "width": doorWidth,
                    "distanceFromLeft": usableSpace - doorWidth
                };
            }
            else if (positionDropDown === "center") {
                doorMods[doorMods.length] = {
                    "index": doorMods.length + 1,
                    "width": doorWidth,
                    "distanceFromLeft": usableSpace / 2 - doorWidth / 2
                };
            }
            else if (positionDropDown === "cPosition") {
                if (!isNaN(doorCustomPosition)) {
                    //alert("Custom " + doorCustomPosition);
                    doorMods[doorMods.length] = {
                        "index": doorMods.length + 1,
                        "width": doorWidth,
                        "distanceFromLeft": doorCustomPosition
                    };
                }
                else {
                    isValid = false;
                    alert("Please enter a valid number into the custom distance text box");
                }
            }                        

            //Validation of blank non-custom field passed
            if (isValid) {

                //Updates doorMods array from the appropriate index in walldoorMods array                
                updateDoorModsArray(doorMods, wallNumber);

                //Update doorMods by sorting most recent addition into previous array
                doorMods = sortDoorModsLeftToRight(doorMods);

                //Valid door was entered, perform various functions
                if (checkQuestion3(doorMods, spacesRemaining, usableSpace)) {

                    //Update spacesRemaining array
                    spacesRemaining = availableSpacesArrayUpdate(usableSpace, doorMods);

                    //Update total space left in the wall
                    var space = totalSpaceLeftInWall(usableSpace, doorMods);

                    //Block to add content to the pager
                    $("#MainContent_lblQuestion3SpaceInfoWallAnswer" + wallNumber).text(space);
                    document.getElementById("pagerThree").style.display = "inline";
                    document.getElementById("wall" + wallNumber + "SpaceRemaining").style.display = "inline";
                    pagerText.setAttribute("style", "display:block;");
                    pagerTextAnswer.setAttribute("style", "display:block");
                    pagerTextDoor.innerHTML = "Wall " + (proposedWall.innerHTML).substr(14, 2) + " Doors";

                    //Display appropriate message and controls within the pager
                    updateDoorPager(doorMods, type, wallNumber);

                    //Update drop downs based on selected value
                    updateDoorDropDowns(positionDropDown, wallNumber, true);

                    //Update walldoorMods array with most current addition
                    updateWallsArray(wallNumber, usableSpace, doorMods, spacesRemaining)

                }                      
            }
        }
        
        /**
        *fillWallWithdoorMods
        *This function is used to fill the wall with as may doorMods as possible, they'll be centered and
        *the ends will be filler
        *@param wallNumber - holds an integer to know which wall is currently being affected
        *@param type - gets the type of door selected (i.e. Cabana, French, Patio, Opening Only (No Door))
        */
        function fillWallWithDoorMods(wallNumber, type) {    
            
            var isValid = true;

            for (var wallDoorModsCount = 0; wallDoorModsCount < wallDoors.length; wallDoorModsCount++) {

                if (wallDoors[wallDoorModsCount].wallId == wallNumber) {

                    if (wallDoors[wallDoorModsCount].doorsSorted.length > 0) {
                        isValid = false;
                        alert("To fill the wall no doorMods can exist, please delete all existing doorMods");
                    }
                }
            }
            if (isValid) {
                
                var spacesRemaining = new Array();
                var doorMods = new Array();

                /****PAGER VARIABLES****/
                var pagerText = document.getElementById("MainContent_lblQuestion3SpaceInfoWall" + wallNumber);
                var pagerTextAnswer = document.getElementById("wall" + wallNumber + "DoorsAdded");
                var pagerTextDoor = document.getElementById("MainContent_lblQuestion3DoorsInfoWall" + wallNumber);
                var proposedWall = document.getElementById("MainContent_lblTextArea" + wallNumber);

                /****CALCULATION VARIABLES****/
                var wallLength = parseFloat(document.getElementById('MainContent_txtWall' + wallNumber + 'Length').value);
                var leftFiller = parseFloat(document.getElementById('MainContent_txtWall' + wallNumber + 'LeftFiller').value);
                var rightFiller = parseFloat(document.getElementById('MainContent_txtWall' + wallNumber + 'RightFiller').value);
                var usableSpace = wallLength - leftFiller - rightFiller;

                var widthDropDown = document.getElementById('MainContent_ddlDoorWidth' + wallNumber + type).options[document.getElementById('MainContent_ddlDoorWidth' + wallNumber + type).selectedIndex].value;

                if (widthDropDown === "cWidth") {
                    doorWidth = parseFloat(calculateActualDoorDimension(type, 'Width', true, wallNumber));
                }
                else {
                    doorWidth = parseFloat(calculateActualDoorDimension(type, 'Width', false, wallNumber));
                }                

                var numberOfdoorMods = parseInt(usableSpace / doorWidth);

                spacesRemaining[spacesRemaining.length] = { "distanceFromLeft": 0, "space": (usableSpace - (doorWidth * numberOfdoorMods)) / 2 };
                spacesRemaining[spacesRemaining.length] = { "distanceFromLeft": doorWidth * numberOfdoorMods + ((usableSpace - (doorWidth * numberOfdoorMods)) / 2), "space": (usableSpace - (doorWidth * numberOfdoorMods)) / 2 };

                for (var doorCount = 0; doorCount < numberOfdoorMods; doorCount++) {
                    doorMods[doorMods.length] = { "width": doorWidth, "distanceFromLeft": spacesRemaining[0].space + (doorCount * doorWidth) };
                }

                //Updates doorMods array from the appropriate index in walldoorMods array
                updateDoorModsArray(doorMods, wallNumber);               

                //Update doorMods by sorting most recent addition into previous array
                doorMods = sortDoorModsLeftToRight(doorMods);

                //Update total space left in the wall
                var space = totalSpaceLeftInWall(usableSpace, doorMods);

                //Block to add content to the pager
                $("#MainContent_lblQuestion3SpaceInfoWallAnswer" + wallNumber).text(space);
                document.getElementById("pagerThree").style.display = "inline";
                document.getElementById("wall" + wallNumber + "SpaceRemaining").style.display = "inline";
                pagerText.setAttribute("style", "display:block;");
                pagerTextAnswer.setAttribute("style", "display:block");
                pagerTextDoor.innerHTML = "Wall " + (proposedWall.innerHTML).substr(14, 2) + " doorMods";

                //Display appropriate message and controls within the pager
                var pagerTextDoorAnswer = document.getElementById("MainContent_lblQuestion3DoorsInfoWallAnswer" + wallNumber);

                $("#MainContent_lblQuestion3DoorsInfoWallAnswer" + wallNumber).empty();

                /****DELETE BUTTON CREATION ADDITION****/
                var deleteButton = document.createElement("input");
                deleteButton.id = "btnDeleteDoorFill" + type + "Wall" + wallNumber;
                deleteButton.setAttribute("type", "button");
                deleteButton.setAttribute("value", "Remove Fill");
                deleteButton.setAttribute("onclick", "deleteDoorFill(\"" + type + "\", \"" + wallNumber + "\")");
                deleteButton.setAttribute("class", "btnSubmit");

                var labelForButton = document.createElement("label");
                labelForButton.id = "lblDeleteDoorFill" + type + "Wall" + wallNumber;
                labelForButton.setAttribute("for", "btnDeleteDoorFill" + type + "Wall" + wallNumber);
                labelForButton.innerHTML = "Wall Filled With " + numberOfdoorMods + " " + type + " doorMods";

                var labelBreakLineForButton = document.createElement("label");
                labelBreakLineForButton.id = "lblDeleteDoorFillBR" + type + "Wall" + wallNumber;
                labelBreakLineForButton.setAttribute("for", "btnDeleteDoorFill" + type + "Wall" + wallNumber);
                labelBreakLineForButton.innerHTML = "<br/>";

                pagerTextDoorAnswer.appendChild(labelForButton);
                pagerTextDoorAnswer.appendChild(deleteButton);
                pagerTextDoorAnswer.appendChild(labelBreakLineForButton);

                //Update drop downs based on selected value
                updateDoorDropDowns("all", wallNumber, true);

                //Update walldoorMods array with most current addition
                updateWallsArray(wallNumber, usableSpace, doorMods, spacesRemaining)
                    
            }            
        }

        /**
        *updateDoorsArray
        *This function is used to update the doors array
        *@param doors - holds an array of doors 
        *@param wallNumber - holds an integer to know which wall is currently being affected
        */
        function updateDoorModsArray(doors, wallNumber) {
            //Load doors array info from wallDoors array
            if (wallDoors.length > 0) {
                for (var i = 0; i < wallDoors.length; i++) {
                    //Store the index if wallId and wallCount are equal
                    if (wallDoors[i].wallId == wallNumber) {
                        for (var h = 0; h < wallDoors[i].doorsSorted.length; h++) {
                            doors[doors.length] = { "width": wallDoors[i].doorsSorted[h].width, "distanceFromLeft": wallDoors[i].doorsSorted[h].distanceFromLeft };
                        }
                        break;
                    }
                }
            }
        }

        /**
        *updateWallsArray
        *This function is used to update the wallDoors array
        *@param wallNumber - holds an integer to know which wall is currently being affected
        *@param doorMods - holds an array of sorted doors left to right
        *@param spacesRemaining - holds an array of remaining spaces within the wall
        */
        function updateWallsArray(wallNumber, wallLength, doorMods, spacesRemaining) {

            //Variable to hold wall index to update
            var indexToStoreAt = null;

            //Loop to find if a wallDoors object exist for the current wall count
            for (var i = 0; i < wallDoors.length; i++) {
                //Store the index if wallId and wallCount are equal
                if (wallDoors[i].wallId == wallNumber) {
                    indexToStoreAt = i;
                    break;
                }
            }
            //If no matches exist, create a new wallDoors object within the array
            if (indexToStoreAt == null) {
                wallDoors[wallDoors.length] = { "wallId": wallNumber, "wallLength": wallLength, "doorsSorted": doorMods, "spaces": spacesRemaining };
            }
            else {
                wallDoors[indexToStoreAt] = { "wallId": wallNumber, "wallLength": wallLength, "doorsSorted": doorMods, "spaces": spacesRemaining };
            }
        }

        /**
        *updateDoorPager
        *This function is used to update the pager details based on added or removed (deleted) doors
        *@param walldoorMods - holds an array of sorted doors left to right
        *@param type - gets the type of door selected (i.e. Cabana, French, Patio, Opening Only (No Door))
        *@param wallNumber - holds an integer to know which wall is currently being affected
        */
        function updateDoorPager(doorMods, type, wallNumber) {
            
            var pagerTextDoorAnswer = document.getElementById("MainContent_lblQuestion3DoorsInfoWallAnswer" + wallNumber);

            $("#MainContent_lblQuestion3DoorsInfoWallAnswer" + wallNumber).empty();

            if (doorMods.length > 0) {                

                for (var childControls = 1; childControls <= doorMods.length ; childControls++) {
                    //Rename controls and their attributes
                    /****DELETE BUTTON CREATION ADDITION****/
                    var deleteButton = document.createElement("input");
                    deleteButton.id = "btnDeleteDoor" + childControls + type + "Wall" + wallNumber;
                    deleteButton.setAttribute("type", "button");
                    deleteButton.setAttribute("value", "X");
                    deleteButton.setAttribute("onclick", "deleteDoor(\"" + childControls + "\", \"" + type + "\", \"" + wallNumber + "\")");
                    deleteButton.setAttribute("class", "btnSubmit");
                    deleteButton.setAttribute("style", "width:24px; height:24px; vertical-align:middle;");

                    var labelForButton = document.createElement("label");
                    labelForButton.id = "lblDeleteDoor" + childControls + type + "Wall" + wallNumber;
                    labelForButton.setAttribute("for", "btnDeleteDoor" + childControls + type + "Wall" + wallNumber);
                    labelForButton.innerHTML = "Door " + childControls + " " + type + " added";

                    var labelBreakLineForButton = document.createElement("label");
                    labelBreakLineForButton.id = "lblDeleteDoorBR" + childControls + type + "Wall" + wallNumber;
                    labelBreakLineForButton.setAttribute("for", "btnDeleteDoor" + childControls + type + "Wall" + wallNumber);
                    labelBreakLineForButton.innerHTML = "<br/>";
                    pagerTextDoorAnswer.appendChild(labelForButton);
                    pagerTextDoorAnswer.appendChild(deleteButton);
                    pagerTextDoorAnswer.appendChild(labelBreakLineForButton);
                }

            }
            else {
                document.getElementById("wall" + wallNumber + "DoorsAdded").style.display = "none";
            }
        }
        
        /**
        *deleteDoor
        *This function is used to perform certain task when a door is deleted (called on click), remove
        *controls from pager, reset wallDoors[index].spaces to the appropriate value based on the door deleted.
        *Same goes for wallDoors[index].doorsSorted the appropriate door is removed from the array.
        *@param doorToDelete - holds the index of the door to be deleted
        *@param type - gets the type of door selected (i.e. Cabana, French, Patio, Opening Only (No Door))
        *@param wallNumber - holds an integer to know which wall is currently being affected
        */
        function deleteDoor(doorToDelete, type, wallNumber) {

            for (var wallDoorsCount = 0; wallDoorsCount < wallDoors.length; wallDoorsCount++) {

                if (wallDoors[wallDoorsCount].wallId == wallNumber) {

                    //Controls to Delete
                    var deleteButtonToRemove = document.getElementById("btnDeleteDoor" + doorToDelete + type + "Wall" + wallNumber);
                    var deleteLabelToRemove = document.getElementById("lblDeleteDoor" + doorToDelete + type + "Wall" + wallNumber);
                    var deleteBreakLineLabelToRemove = document.getElementById("lblDeleteDoorBR" + doorToDelete + type + "Wall" + wallNumber);
                    
                    var positionInWall = findPosition(wallDoors[wallDoorsCount].wallLength, wallDoors[wallDoorsCount].doorsSorted, (doorToDelete - 1));

                    //Removes object at specified index
                    wallDoors[wallDoorsCount].doorsSorted.splice(doorToDelete - 1, 1);

                    //Resetting spaces property in the wallDoors array
                    var spacesRemaining = availableSpacesArrayUpdate(wallDoors[wallDoorsCount].wallLength, wallDoors[wallDoorsCount].doorsSorted);
                    wallDoors[wallDoorsCount].spaces = spacesRemaining;

                    //Used to redisplay the appropriate space left in the wall
                    var space = totalSpaceLeftInWall(wallDoors[wallDoorsCount].wallLength, wallDoors[wallDoorsCount].doorsSorted)                    

                    //Removes controls displayed in the pager
                    deleteButtonToRemove.remove();
                    deleteLabelToRemove.remove();
                    deleteBreakLineLabelToRemove.remove();

                    //Need to reset pager titles
                    $("#MainContent_lblQuestion3SpaceInfoWallAnswer" + wallNumber).text(space);
                    updateDoorPager(wallDoors[wallDoorsCount].doorsSorted, type, wallNumber);
                    updateDoorDropDowns(positionInWall, wallNumber, false);
                }

            }

        }

        /**
        *deleteDoorFill
        *This function is used to perform certain task when a door is deleted (called on click), remove
        *controls from pager, reset wallDoors[index].spaces to null and same for wallDoors[index].doorsSorted.
        *@param type - gets the type of door selected (i.e. Cabana, French, Patio, Opening Only (No Door))
        *@param wallNumber - holds an integer to know which wall is currently being affected
        */
        function deleteDoorFill(type, wallNumber) {

            for (var wallDoorsCount = 0; wallDoorsCount < wallDoors.length; wallDoorsCount++) {

                if (wallDoors[wallDoorsCount].wallId == wallNumber) {

                    //Controls to Delete
                    var deleteButtonToRemove = document.getElementById("btnDeleteDoorFill" + type + "Wall" + wallNumber);
                    var deleteLabelToRemove = document.getElementById("lblDeleteDoorFill" + type + "Wall" + wallNumber);
                    var deleteBreakLineLabelToRemove = document.getElementById("lblDeleteDoorFillBR" + type + "Wall" + wallNumber);

                    //Removes controls displayed in the pager
                    deleteButtonToRemove.remove();
                    deleteLabelToRemove.remove();
                    deleteBreakLineLabelToRemove.remove();

                    wallDoors[wallDoorsCount].spaces = new Array();
                    wallDoors[wallDoorsCount].doorsSorted = new Array();

                    $("#MainContent_lblQuestion3SpaceInfoWallAnswer" + wallNumber).text(wallDoors[wallDoorsCount].wallLength);
                    document.getElementById("wall" + wallNumber + "DoorsAdded").style.display = "none";
                    updateDoorDropDowns("null", wallNumber, false);
                }
            }
        }

        /**
        *findPosition
        *This function is used to perform certain task when a door is deleted (called on click), remove
        *controls from pager, reset wallDoors[index].spaces to null and same for wallDoors[index].doorsSorted.
        *@param usable - holds the usable length within a wall
        *@param doorMods - holds an array of doors which are in order from left to right
        *@param indexToCheck - holds an integer of an index in which to get data from doorMods
        *@return position - returns a string of the position in which the deleted door belongs to 
        *for dropdown purposes (i.e. left, center, right);
        */
        function findPosition(usableLength, doorMods, indexToCheck) {
            var position = "";

            if (doorMods[indexToCheck].distanceFromLeft == 0)
                position = "left";
            else if (doorMods[indexToCheck].distanceFromLeft == (usableLength / 2 - doorMods[indexToCheck].width / 2))
                position = "center";
            else if (doorMods[indexToCheck].distanceFromLeft == (usableLength - doorMods[indexToCheck].width))
                position = "right";
            else
                position = "custom";

            return position;
        }

        /**
        *Prototype used to create an "insert" function for arrays. This function can insert elements at specific indices
        *@param index - is which index to insert the item at
        *@param item - which item is to be inserted
        */
        Array.prototype.insert = function (index, item) {
            this.splice(index, 0, item);
        };

        /**
        *sortDoorsLeftToRight
        *This function orders doors from left to right based on the distance from left
        *@param doors - holds an array of unsorted doors
        *@return doorMods - returns an array of sorted doors from left to right
        */
        function sortDoorModsLeftToRight(doors) {

            var doorMods = new Array();

            //TYPE FUNCTION TO BE MADE: FUNCTONALITY
            //AREA: SORT LEFT TO RIGHT
            //NECESSARY VARIABLES: doors[], doorMods[]
            if (doors.length > 0) {
                doorMods[0] = doors[0];
            }
            for (var i = 1; i < doors.length; i++) {
                var x;
                for (x = 0; x < doorMods.length; x++) {
                    if (doorMods[x].distanceFromLeft > doors[i].distanceFromLeft) {
                        doorMods.insert(x, doors[i]);
                        break;
                    }
                }
                if (x == doorMods.length) {
                    doorMods[doorMods.length] = doors[i];
                }
            }
            //ENDAREA: SORT LEFT TO RIGHT

            return doorMods;
        }

        /**
        *checkQuestion3
        *This function performs validtion on doors added, such as: enough space to add a door,
        *doors overlapping, doors outside of the wall, etc...
        *@param doorMods - holds an array of sorted doors from left to right
        *@param spacesRemaining - holds an array of remaining spaces within the wall
        *@param usableLength - holds the usable length on the current wall
        *@return isValid - returns whether the entered door(s) have met the validation
        */
        function checkQuestion3(doorMods, spacesRemaining, usableLength) {

            var isValid = true;

            //TYPE FUNCTION TO BE MADE: VALIDATION
            //AREA: CHECK OVERLAP AND OUT OF WALL BOUNDS
            //NECESSARY VARIABLES: doorMods[]
            for (var i = 0; i < doorMods.length - 1; i++) {
                if (doorMods[i].distanceFromLeft + doorMods[i].width > doorMods[i + 1].distanceFromLeft) {
                    alert("Doors " + doorMods[i].index + " and " + (doorMods[i].index + 1) + " overlap");
                    doors.splice(doorMods[i].index, 1);
                    doorMods.splice(doorMods[i].index, 1);
                    isValid = false;
                }
                else if (doorMods[i + 1].distanceFromLeft >= usableLength) {
                    alert("Door " + (doorMods[i].index + 1) + " is outside of the wall length");
                    isValid = false;
                }
                else if (doorMods[i + 1].distanceFromLeft < 0) {
                    alert("Door " + (doorMods[i].index + 1) + "'s position is smaller than zero");
                    isValid = false;
                }
                //if (doorMods.length == 4 && i == 3) {
                //    alert("Distance check " + doorMods[doorMods.length - 1].distanceFromLeft);
                //}
            }
            //ENDAREA: CHECK OVERLAP AND OUT OF WALL BOUNDS

            //TYPE FUNCTION TO BE MADE: VALIDATION
            //AREA: CHECK FOR POSSIBLE DOOR WIDTH IN SPACES, ONLY IF spacesRemaining IS NOT NULL
            if (spacesRemaining != null) {
                var goodSpace = 0;
                //Loop through all spaces in spacesRemaining and check it against the door width
                for (var j = 0; j < spacesRemaining.length; j++) {
                    //alert(spacesRemaining[j]);
                    //Check all spaces in wall
                    if (spacesRemaining[j].space > doors[doors.length - 1].width) {
                        goodSpace++;
                    }
                }
                //If no good spaces exist, display error message
                if (goodSpace == 0) {
                    isValid = false;
                    alert("This door is too small to fit in any available spaces");
                }
            }
            //ENDAREA: CHECK FOR POSSIBLE DOOR WIDTH IN SPACES, ONLY IF spacesRemaining IS NOT NULL


            return isValid;
        }

        /**
        *sortDoorsLeftToRight
        *This function disables and changes the selected index of all position drop downs in the current wall
        *@param dropDownValue - holds the value of the currently selected index
        *@param wallNumber - holds the number of the current wall
        */
        function updateDoorDropDowns(dropDownValue, wallNumber, toBeRemoved) {
            var dropDownName = 'MainContent_ddlDoorPosition' + wallNumber;
            
            //TYPE FUNCTION TO BE MADE: FUNCTIONALITY
            //AREA: CHANGE DROPDOWNS BASED ON SELECTED INDEX
            //NECESSARY VARIABLES: dropDownName, dropDownValue
            for (var typeCount = 1; typeCount <= 4; typeCount++) {

                var title = (typeCount == 1) ? "Cabana" : (typeCount == 2) ? "French" : (typeCount == 3) ? "Patio" : "NoDoor";

                var dropDown = document.getElementById(dropDownName + title);

                if (toBeRemoved && dropDownValue == "all") {
                    $('#' + dropDownName + title).attr('disabled', true);
                    document.getElementById("MainContent_rowDoorCustomPosition" + wallNumber + title).style.display = "none";
                }
                else if (!toBeRemoved && dropDown.disabled == true) {
                    $('#' + dropDownName + title).attr('disabled', false)                    
                }
                else if (toBeRemoved) {
                    if ($('#' + dropDownName + title).val() != "cPosition") {
                        $('#' + dropDownName + title + ' option[value=' + dropDownValue + ']').attr('disabled', true);
                    }

                    for (var dropDownLoop = 0; dropDownLoop < $('#' + dropDownName + title + ' option').size() ; dropDownLoop++) {
                        if ($('#' + dropDownName + title + ' option')[dropDownLoop].disabled == false) {
                            $('#' + dropDownName + title).prop("selectedIndex", dropDownLoop);
                            break;
                        }
                    }
                    customDimension(wallNumber, title, "Position");
                }
                else {
                    $('#' + dropDownName + title + ' option[value=' + dropDownValue + ']').attr('disabled', false);

                    for (var dropDownLoop = 0; dropDownLoop < $('#' + dropDownName + title + ' option').size() ; dropDownLoop++) {
                        if ($('#' + dropDownName + title + ' option')[dropDownLoop].disabled == false) {
                            $('#' + dropDownName + title).prop("selectedIndex", dropDownLoop);
                            break;
                        }
                    }
                    customDimension(wallNumber, title, "Position");
                }
            }
            //ENDAREA: CHANGE DROPDOWNS BASED ON SELECTED INDEX
        }

        /**
        *totalSpaceLeftInWall
        *This function performs calculations to find the total space left in a wall
        *@param usableLength - holds the length of the wall which mods can be put into
        *@param doorMods - holds a door array which are in proper order
        *@return totalSpace - returns the total space left on a specific wall
        */
        function totalSpaceLeftInWall(usableLength, doorMods) {

            var totalSpace = usableLength;

            for (var wallSpace = 0; wallSpace < doorMods.length; wallSpace++)
                totalSpace -= doorMods[wallSpace].width;

            return totalSpace;
        }

        /**
        *availableSpacesArrayUpdate
        *This function is used to update remainingSpaces array
        *@param usableLength - holds the length of the wall which mods can be put into
        *@param doorMods - holds a door array which are in proper order
        */
        function availableSpacesArrayUpdate(usableLength, doorMods) {

            var spacesRemaining = new Array();

            if (doorMods.length == 0) {
                spacesRemaining[spacesRemaining.length] = null;
            }
            else {
                //Block to store remaining spaces between various door(s)
                if (doorMods[0].distanceFromLeft > 0 && doorMods.length > 1) {
                    spacesRemaining[spacesRemaining.length] = { "distanceFromLeft": 0, "space": doorMods[0].distanceFromLeft };
                    for (var doorsLoop = 0; doorsLoop < doorMods.length - 1; doorsLoop++) {
                        spacesRemaining[spacesRemaining.length] = { "distanceFromLeft": doorMods[doorsLoop].width + doorMods[doorsLoop].distanceFromLeft, "space": doorMods[doorsLoop + 1].distanceFromLeft - (doorMods[doorsLoop].width + doorMods[doorsLoop].distanceFromLeft) };
                    }
                }
                else if (doorMods.length == 1) {
                    if (doorMods[0].distanceFromLeft == 0) {
                        spacesRemaining[spacesRemaining.length] = { "distanceFromLeft": doorMods[0].width, "space": usableLength - doorMods[0].width };
                    }
                    else if (doorMods[0].distanceFromLeft + doorMods[0].width == usableLength) {
                        spacesRemaining[spacesRemaining.length] = { "distanceFromLeft": 0, "space": usableLength - doorMods[0].width };
                    }
                    else if (doorMods[0].distanceFromLeft > 0) {
                        spacesRemaining[spacesRemaining.length] = { "distanceFromLeft": 0, "space": doorMods[0].distanceFromLeft };
                        spacesRemaining[spacesRemaining.length] = { "distanceFromLeft": doorMods[0].distanceFromLeft + doorMods[0].width, "space": usableLength - (doorMods[0].distanceFromLeft + doorMods[0].width) };
                    }
                }
                else {
                    //var doorsLoop;
                    for (var doorsLoop = 0; doorsLoop < doorMods.length - 1; doorsLoop++) {
                        spacesRemaining[spacesRemaining.length] = { "distanceFromLeft": doorMods[doorsLoop].width + doorMods[doorsLoop].distanceFromLeft, "space": doorMods[doorsLoop + 1].distanceFromLeft - (doorMods[doorsLoop].width + doorMods[doorsLoop].distanceFromLeft) };
                    }
                    if (doorMods[doorMods.length - 1].distanceFromLeft + doorMods[doorMods.length - 1].width < usableLength) {
                        spacesRemaining[spacesRemaining.length] = { "distanceFromLeft": doorMods[doorMods.length - 1].distanceFromLeft + doorMods[doorMods.length - 1].width, "space": usableLength - (doorMods[doorMods.length - 1].distanceFromLeft + doorMods[doorMods.length - 1].width) };
                    }
                }
            }
            return spacesRemaining;
        }


        function submitDoorData() {
            var hiddenOne = document.createElement("input");
            hiddenOne.setAttribute("type", "hidden");
            hiddenOne.setAttribute("name", "Blah1");
            hiddenOne.value = wallDoors[0].wallId;

            var hiddenDiv = document.getElementById("MainContent_hiddenFieldsDiv");
            hiddenDiv.appendChild(hiddenOne);
        }


        /************************************************************************************************************************************/
                    /****************                 new function to be written                *******************************/
        /************************************************************************************************************************************/
        function fillWindows() {

        }
        /************************************************************************************************************************************/
        /************************************************************************************************************************************/
        /************************************************************************************************************************************/




    </script>
    <%-- End hidden div populating scripts --%>

    <%-- SLIDES (QUESTIONS)
    ======================================== 
        
        onmousedown="event.preventDefault ? event.preventDefault() : event.returnValue = false"--%>
    <div class="slide-window" id="slide-window" >

        <div class="slide-wrapper">
            
            <%-- QUESTION 1 - Wall Lengths
            ======================================== --%>
            <div id="slide1" class="slide">

                <h1>
                    <%-- Label for question 1 (wall lengths) --%>
                    <asp:Label ID="lblQuestion1" runat="server" Text="Please enter the wall lengths"></asp:Label>
                </h1>        
                              
                <%-- div to store and organize the tables for textboxes and dropdowns for each wall length 
                    number of rows in the 2 tables below are added dynamically in the codebehind--%>
                <div id="tableWallLengths" class="tblWallLengths" runat="server" style="padding-right:15%; padding-left:15%; padding-top:5%;">
                    <%-- first table for existing walls, only contains input fields for lengths --%>
                    <%--<asp:Table ID="tblExistingWalls" runat="server">
                        <asp:TableRow>--%>
                            <%-- table headings --%>
                           <%-- <asp:TableHeaderCell >
                                Existing Walls
                            </asp:TableHeaderCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell></asp:TableCell>--%>
                            <%-- column headings --%>
                            <%--<asp:TableCell ColumnSpan="6" >
                                Length
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>--%>
                    <%-- end of existing walls table --%>
                    <br />
                    <%-- second table for proposed walls, contains input fields for lengths, as well as left and right fillers --%>
                    <asp:Table ID="tblProposedWalls" runat="server">
                        <%--<asp:TableRow>--%>
                            <%-- table headings --%>
                            <%--<asp:TableHeaderCell >
                                Proposed Walls
                            </asp:TableHeaderCell>
                        </asp:TableRow>--%>
                        
                        <asp:TableRow>
                            <asp:TableCell></asp:TableCell>
                            <%-- column headings --%>
                            <asp:TableCell ColumnSpan="2" >
                                Left Filler
                            </asp:TableCell>
                            <asp:TableCell ColumnSpan="2">
                                Length
                            </asp:TableCell>
                            <asp:TableCell ColumnSpan="2">
                                Right Filler
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <%-- end of proposed walls table --%>
                </div>
                <%-- end of div for lenghts tables --%>

                <asp:Label ID="lblErrorMessage" CssClass="lblErrorMessage" runat="server" Text="Label">Oh hello, I am an error message.</asp:Label>

                <%-- button to go to the next question --%>
                <asp:Button ID="btnQuestion1" Enabled="true" CssClass="btnSubmit float-right slidePanel" data-slide="#slide2" runat="server" Text="Next Question" />

            </div> 
            <%-- end #slide1 --%>

            <%-- QUESTION 2 - Wall Heights and Roof Slope
            ======================================== --%>
            <div id="slide2" class="slide">

                <h1>
                                    <%-- Label for question 2 (wall heights and roof slope) --%>
                    <asp:Label ID="lblQuestion2" runat="server" Text="Please enter the wall heights"></asp:Label>
                </h1>
           
                        <div class="tblWallLengths" runat="server" style="padding-right:15%; padding-left:15%; padding-top:5%;">
                            <ul>
                                <li>
                                    <%-- table contains textboxes, dropdowns, and radio buttons for user input --%>
                                    <asp:Table ID="tblWallHeights" CssClass="tblTxtFields" runat="server">

                                        <%-- row 1: backwall height --%>
                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <%-- label for back wall height --%>
                                                <asp:Label ID="lblBackWallHeight" AssociatedControlID="txtBackWallHeight" runat="server" Text="Back Wall Height:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <%-- textbox for backwall height whole numbers --%>
                                                <asp:TextBox ID="txtBackWallHeight" CssClass="txtField txtInput"  OnChange="checkQuestion2()" onblur="resetWalls()" OnFocus="highlightWallsHeight()" runat="server" MaxLength="3"></asp:TextBox>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <%-- placeholder for the dropdown list for the decimal values for back wall height 
                                                    dynamically added in codebehind--%>
                                                <asp:PlaceHolder ID="phBackHeights" runat="server" />
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <%-- radio button to auto calculate back wall height based on the given user input --%>
                                                <asp:RadioButton ID="radAutoBackWallHeight" GroupName="autoPopulate" runat="server" OnClick="checkQuestion2()" />
                                                <asp:Label ID="lblAutoBackWallHeightRadio" AssociatedControlID="radAutoBackWallHeight" runat="server"></asp:Label>
                                                <asp:Label ID="lblAutoBackWallHeight" AssociatedControlID="radAutoBackWallHeight" runat="server" Text="Auto Populate"></asp:Label>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                        <%-- end of row 1 --%>
                                        <%-- row 2: frontwall height --%>
                                        <asp:TableRow>
                                            
                                            <asp:TableCell>
                                                <%-- label for front wall height --%>
                                                <asp:Label ID="lblFrontWallHeight" AssociatedControlID="txtFrontWallHeight" runat="server" Text="Front Wall Height:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <%-- textbox for front wall height whole numbers --%>
                                                <asp:TextBox ID="txtFrontWallHeight" CssClass="txtField txtInput"  OnChange="checkQuestion2()" onblur="resetWalls()" OnFocus="highlightWallsHeight()" runat="server" MaxLength="3"></asp:TextBox>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <%-- placeholder for the dropdown list for the decimal values for front wall height
                                                    dynamically added in codebehind --%>
                                                <asp:PlaceHolder ID="phFrontHeights" runat="server" />
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <%-- radio button to auto calculate front wall height based on the given user input --%>
                                                <asp:RadioButton ID="radAutoFrontWallHeight" GroupName="autoPopulate" runat="server" OnClick="checkQuestion2()" />
                                                <asp:Label ID="lblAutoFrontWallHeightRadio" AssociatedControlID="radAutoFrontWallHeight" runat="server"></asp:Label>
                                                <asp:Label ID="lblAutoFrontWallHeight" AssociatedControlID="radAutoFrontWallHeight" runat="server" Text="Auto Populate"></asp:Label>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                        <%-- end of row 2 --%>
                                        <%-- row 3: roof slope --%>
                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <%-- label for roof slope --%>
                                                <asp:Label ID="lblRoofSlope" AssociatedControlID="txtRoofSlope" runat="server" Text="Roof Slope:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <%-- textbox for roof slope whole numbers --%>
                                                <asp:TextBox ID="txtRoofSlope" CssClass="txtField txtInput" onkeyup="checkQuestion2()" OnChange="checkQuestion2()" runat="server" MaxLength="6"></asp:TextBox>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <%-- label to emphasize that its not actual slope, its slope over 12 --%>
                                                <asp:Label ID="lblSlopeOver12" runat="server" Text="/ 12"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <%-- radio button to auto calculate roof slope based on the given user input --%>
                                                <asp:RadioButton ID="radAutoRoofSlope" GroupName="autoPopulate" runat="server" OnClick="checkQuestion2()" Checked="true"/>
                                                <asp:Label ID="lblAutoRoofSlopeRadio" AssociatedControlID="radAutoRoofSlope" runat="server"></asp:Label>
                                                <asp:Label ID="lblAutoRoofSlope" AssociatedControlID="radAutoRoofSlope" runat="server" Text="Auto Populate"></asp:Label>
                                            </asp:TableCell>

                                        </asp:TableRow>
                                        <%-- end of row 3 --%>
                                    </asp:Table>
                                    <%-- end of heights table --%>
                                </li>
                            </ul>            
                        </div> <%-- end .toggleContent --%>

                <%-- button to go to the next question --%>
                <asp:Button ID="btnQuestion2" Enabled="true" CssClass="btnSubmit float-right slidePanel" data-slide="#slide3" runat="server" Text="Next Question" />

            </div> 
            <%-- end #slide2 --%>

             <%-- QUESTION 3 - DOOR OPTIONS/DETAILS
            ======================================== --%>

            <div id="slide3" class="slide">
                <h1>
                    <asp:Label ID="lblDoorDetails" runat="server" Text="Door Details"></asp:Label>
                </h1>        
                              
                <ul class="toggleOptions">
                    <asp:PlaceHolder ID="wallDoorOptions" runat="server"></asp:PlaceHolder>                    
                </ul>            

                <asp:Button ID="btnQuestion3" Enabled="true" CssClass="btnSubmit float-right slidePanel" data-slide="#slide4" runat="server" Text="Next Question" />

            </div>
            <%-- end #slide3 --%>


             <%-- QUESTION 4 - WINDOW OPTIONS/DETAILS
            ======================================== --%>

            <div id="slide4" class="slide">
                <h1>
                    <asp:Label ID="lblWindowDetails" runat="server" Text="Window Details"></asp:Label>
                </h1>        
                              
                <ul class="toggleOptions">
                    <asp:PlaceHolder ID="wallWindowOptions" runat="server"></asp:PlaceHolder>                    
                </ul>            

                <asp:Button ID="btnQuestion4" Enabled="true" CssClass="btnSubmit float-right slidePanel" runat="server" Text="Submit" OnClick="btnQuestion4_Click" />

            </div>
            <%-- end #slide4 --%>



        </div> <%-- end .slide-wrapper --%>

    </div> 
    <%-- end .slide-window --%>
    

    <%-- SLIDE PAGING (QUESTION NAVIGATION)
    ======================================== --%>
    <div id="paging-wrapper">    
        <div id="paging"> 
            <h2>Wall Specifications</h2>

            <ul>
                <%-- MINI CANVAS (HIGHLIGHTS CURRENT WALL)
                ======================================== --%>
                <!--Div tag to hold the canvas/grid-->
                <div style="position:inherit; text-align:center; top:0px; right:0px;" id="mySunroom"></div>
                <%--==================================== --%>


                <%-- div to display the answers for question 1 --%>
                <div style="display: none" id="pagerOne">
                    <li>
                            <a href="#" data-slide="#slide1" class="slidePanel">
                                <asp:Label ID="lblWallLengthsSlidePanel" runat="server" Text="Wall Lengths"></asp:Label>
                                <asp:Label ID="lblWallLengthsAnswer" runat="server" Text="Wall Lengths"></asp:Label>
                            </a>
                    </li>
                </div>

                <%-- div to display the answers for question 2 --%>
                <div style="display: none" id="pagerTwo">
                    <li>
                            <a href="#" data-slide="#slide2" class="slidePanel">
                                <asp:Label ID="lblWallHeightsSlidePanel" runat="server" Text="Wall Heights"></asp:Label>
                                <asp:Label ID="lblWallHeightsAnswer" runat="server" Text="Wall Heights"></asp:Label>
                            </a>
                    </li>
                </div>

                <%-- div to display the answers for question 3 --%>
                <div style="display: none" id="pagerThree">
                    <li>
                        <asp:Label runat="server" Text="Wall and Door Details"></asp:Label>
                    </li>
                    <asp:PlaceHolder ID="pager3Information" runat="server"></asp:PlaceHolder>
                    <%--<li>
                            <a href="#" data-slide="#slide3" class="slidePanel">
                                <asp:Label ID="lblQuestion3Pager" runat="server" Text="Wall and Door Details"></asp:Label>
                                <asp:Label ID="lblQuestion3PagerAnswer" runat="server" Text=""></asp:Label>
                            </a>
                    </li>--%>
                </div>

                <%-- div to display the answers for question 4 --%>
                <div style="display: none" id="pagerFour">
                    <li>
                            <a href="#" data-slide="#slide4" class="slidePanel">
                                <asp:Label ID="Label27" runat="server" Text="Styling options"></asp:Label>
                                <asp:Label ID="lblQuestion4PagerAnswer" runat="server" Text="Question 4 Answer"></asp:Label>
                            </a>
                    </li>
                </div>

 <%--               <div style="display: none" id="pagerFive">
                    <li>
                            <a href="#" data-slide="#slide5" class="slidePanel">
                                <asp:Label ID="Label31" runat="server" Text="Foam protection"></asp:Label>
                                <asp:Label ID="lblQuestion5PagerAnswer" runat="server" Text="Question 5 Answer"></asp:Label>
                            </a>
                    </li>          
                </div>    
                  
                <div style="display: none" id="pagerSix">
                    <li>
                            <a href="#" data-slide="#slide6" class="slidePanel">
                                <asp:Label ID="Label1" runat="server" Text="Prefab floor"></asp:Label>
                                <asp:Label ID="lblQuestion6PagerAnswer" runat="server" Text="Question 6 Answer"></asp:Label>
                            </a>
                    </li>
                </div>

                <div style="display: none" id="pagerSeven">                
                    <li>
                            <a href="#" data-slide="#slide7" class="slidePanel">
                                <asp:Label ID="Label3" runat="server" Text="Roof"></asp:Label>
                                <asp:Label ID="lblQuestion7PagerAnswer" runat="server" Text="Question 7 Answer"></asp:Label>
                            </a>
                    </li>
                </div>

                <div style="display: none" id="pagerEight">
                    <li>
                            <a href="#" data-slide="#slide8" class="slidePanel">
                                <asp:Label ID="Label5" runat="server" Text="Layout"></asp:Label>
                                <asp:Label ID="lblQuestion8PagerAnswer" runat="server" Text="Question 8 Answer"></asp:Label>
                            </a>
                    </li>
                </div>--%>
            </ul>    
        </div> <%-- end #paging --%>
    </div>


    <%-- %>/*********************CANVAS FUNCTIONS*********************************/ --%>
    <script>

        

        /* CREATE CANVAS */
        var canvas = d3.select("#mySunroom")            //Select the div tag with id "mySunroom"
                    .append("svg")                      //Add an svg tag to the selected div tag
                    .attr("width", 200)    //Set the width of the canvas/grid to MAX_CANVAS_WIDTH
                    .attr("height", 200); //Set the height of the canvas/grid to MAX_CANVAS_HEIGHT  
        var svgGrid = document.getElementById("mySunroom");     //create the svg grid on the canvas
        
        //Creates rectangle area to draw in based on max canvas dimensions
        var rect = canvas.append("rect")                //Draws a rectangle for the canvas/grid to sit in
                    .attr("width", 200)    //Sets the width for the canvas/grid
                    .attr("height", 200)  //Sets the height for the canvas/grid
                    .attr("fill", "#f6f6f6");              //Sets the color of the rectangle to light grey

        var lineArray = new Array(); //to store the drawn lines to be changed/highlighted as needed

        //draw the lines on the canvas
        for (var i = 0; i < lineList.length; i++) { //draw all the lines with the given attributes
            lineArray[i] = canvas.append("line")
                    .attr("x1", (coordList[i][0] / 5) * 2) //0 = x1
                    .attr("y1", (coordList[i][2] / 5) * 2) //2 = y1
                    .attr("x2", (coordList[i][1] / 5) * 2) //1 = x2
                    .attr("y2", (coordList[i][3] / 5) * 2) //3 = y2
                    .attr("stroke-width", "2"); 
            
            if(coordList[i][4] == "E") //4 = wall facing
                lineArray[i].attr("stroke", "red"); //if existing wall, make line red
            else
                lineArray[i].attr("stroke", "black"); //if proposed wall, make line black
        }

        /**
        This function is used to highlight each individual walls for length question
        */
        function highlightWallsLength() {
            var wallNumber = (document.activeElement.id.substr(19,1)); //parse out the wall number from the id           

            lineArray[wallNumber - 1].attr("stroke", "cyan"); //highlight the wall cyan colour
            lineArray[wallNumber - 1].attr("stroke-width", "5"); //make it extra thick
               
        }

        /**
        This function resets the walls resets wall colours onblur
        */
        function resetWalls() {
            for (var i = 0; i < lineList.length; i++) { //run through all the lines
                lineArray[i].attr("stroke-width", "2"); //make them default thickness
                if (coordList[i][4] == "E") //4 = wall facing
                    lineArray[i].attr("stroke", "red"); //if existing wall, make red
                else
                    lineArray[i].attr("stroke", "black"); //if proposed wall, make black
            }
            if (document.getElementById("lowestPoint")) //if the lowest point is highlighted in case of a non-existing front wall
                d3.selectAll("#lowestPoint").remove(); //remove the highlighted lowest point
        }


        /**
        This function is used to highlight each back and front walls for heights question
        */
        function highlightWallsHeight() {
            var wall = (document.activeElement.id.substr(15, 1)); //parse out B or F (for back wall or front wall) from the id
            var southWalls = new Array(); //array to store all the south facing walls 
            var northWalls = new Array(); //array to store all the north facing walls
            var lowestWall = 0; //arbitrary number to determine the most south wall (i.e. the front wall) on the canvas
            var lowestIndex; //index of the most south wall
            var highestWall = 200; //arbitrary number to determine to least south wall (i.e. the back wall) on the canvas
            var highestIndex; //index of the least south wall
            var index = -1; //invalid to determine if there is a wall or not
            var southIsHigher = true;

            for (var i = 0; i < lineList.length; i++) { //run through the list of walls
                if (coordList[i][5] == "S") //5 = orientation... if the orientation is south
                    southWalls.push({ "y2": lineArray[i].attr("y2"), "number": i, "type": coordList[i][4] }); //populate south walls array.. 4 = wall type
                else if (coordList[i][5] == "N") //5 = orientation... if the orientation is north
                    northWalls.push({ "y2": lineArray[i].attr("y2"), "number": i, "type": coordList[i][4] }); //populate north walls array.. 4 = wall type

            }

            for (var i = 0; i < southWalls.length; i++) {
                for (var j = 0; j < northWalls.length; j++) {
                    if (southWalls[i].y2 < northWalls[j].y2)
                        southIsHigher = false; //north is higher
                }
            }

            if (wall == "B") { //if the textbox in focus is backwall textbox
                if (southIsHigher) {
                    index = getBackWall(southWalls, northWalls, southIsHigher); //get the index of the backwall
                }
                else { //northwall is higher
                    index = getBackWall(southIsHigher, northWalls, southIsHigher);
                }
            }
            else { //if (wall == "F") //if the textbox in focus is frontwall textbox
                if (southWalls[southWalls.length - 1].type === "P") { //check if the front wall is a proposed walls
                    index = getFrontWall(southWalls); //if its a proposed wall, get its index
                }
            } //if its not a proposed wall that means there is no front wall


            if (index >= 0) { //if valid index, i.e. there is a front wall
                lineArray[index].attr("stroke", "cyan"); //highlight the front wall cyan
                lineArray[index].attr("stroke-width", "5"); //make it extra think
            }
            else { //index, invalid ..there is no front wall
                highlightFrontPoint(); //highlight front point
            }

        }

        /**
        This function is used to determine the back wall index
        @param southWalls - the array of all south facing walls
        @param northWalls - the array of all north facing walls
        @param southIsHigher - used to determine which wall array to use
        @return lowestIndex - index of the top most south facing wall on the canvas, i.e. the back wall
        */
        function getBackWall(southWalls, northWalls, southIsHigher) {
            var lowestWall = 0; //arbitrary number to determine back wall (number represents value of coordinate, low number means top of canvas)
            var lowestIndex; //to store the index of the back wall

            if (southIsHigher) {
                for (var i = 0; i < southWalls.length; i++) { //run through all south facing walls
                    if (southWalls[i].y2 > lowestWall) { //if the y2 coordinate of the current wall is higher than the value of lowest wall
                        lowestWall = southWalls[i].y2; //that means we have a new lowest coordinate
                        lowestIndex = southWalls[i].number; //store the index of the wall
                    }
                }
                backWall = "south";
            }
            else { //northishigher
                for (var i = 0; i < northWalls.length; i++) { //run through all south facing walls
                    if (northWalls[i].y2 > lowestWall) { //if the y2 coordinate of the current wall is higher than the value of lowest wall
                        lowestWall = northWalls[i].y2; //that means we have a new lowest coordinate
                        lowestIndex = northWalls[i].number; //store the index of the wall
                    }
                }
                backWall = "north"
            }

            return backWallIndex = lowestIndex; //return the index of the lowest wall found, i.e. wall that's nearest to the top of canvas
        }

        /**
        This function is used to determine the front wall index
        @param southWalls - the array of all south facing walls
        @return highestIndex - index of the bottom most south facing wall on the canvas, i.e. the front wall
        */
        function getFrontWall(southWalls) {
            var highestWall = 500; //arbitrary number to determine back wall (number represents value of coordinate, low number means top of canvas)
            var highestIndex; //to store the index of the back wall

            for (var i = 0; i < southWalls.length; i++) { //run through all south facing walls
                if (coordList[southWalls[i].number][4] == "P") {
                    if (southWalls[i].y2 < highestWall) { //if the y2 coordinate of the current wall is lower than the value of highest wall
                        highestWall = southWalls[i].y2; //that means we have a new highest coordinate
                        highestIndex = southWalls[i].number; //store the index of the wall
                    }
                }

            }
            return highestIndex; //return the index of the highest wall found, i.e. wall that's nearest to the bottom of canvas
        }
        /**
        This function is used to highlight the front point if there is no front wall
        */
        function highlightFrontPoint() {
            var lowestX = 0; //to store the lowest x coordinate
            var lowestY = 0; //to store the lowest y coordinate
            var circle; //to draw the circle on the lowest point

            for (var i = 0; i < coordList.length; i++) { //run through all the lines in coordList
                if (coordList[i][3] > lowestY) { //(3 = y2 coordinate) if y2 coordinate of the given line is greater than the lowestY stored
                    //that means we have a new lowest point on the canvas, store the x and y values of the point
                    lowestY = coordList[i][3]; //3 = y2 coordinate
                    lowestX = coordList[i][1]; //1 = x2 coordinate
                }
            }

            //draw the circle on the lowest point based on lowest coordinate found in the coordList
            circle = canvas.append("circle") 
                           .attr("cx", (lowestX / 5) * 2) //x value of the origin of the circle (scaled to fit the mini canvas)
                           .attr("cy", (lowestY / 5) * 2) //y value of the origin of the circle (scaled to fit the mini canvas)
                           .attr("r", 5) //radius
                           .style("fill", "cyan") //fill it with cyan colour
                           .attr("id", "lowestPoint"); //give it an id, so we can remove the circle in resetWalls()
        }

            
/*******************************************************************************************************/
    </script>
    <%-- Hidden input tags 
    ======================= --%>

    <%-- hiddenFieldsDiv is used to store dynamically generated hidden fields from codebehind --%>
    <div id="hiddenFieldsDiv" runat="server"></div>
    <%-- <input id="hidSoffitLength" type="hidden" runat="server" /> --%>
    <input id="hidProjection" type="hidden" runat="server" />
    <input id="hidFrontWallHeight" type="hidden" runat="server" />
    <input id="hidBackWallHeight" type="hidden" runat="server" />
    <input id="hidRoofSlope" type="hidden" runat="server" />

    <%-- end hidden fields --%>    

    <script>
        $(function () {
            $('.ulNavMain').children('a').removeClass('active');
            $('#lnkMainNavNewProject').addClass('active');
        });
    </script>
</asp:Content>

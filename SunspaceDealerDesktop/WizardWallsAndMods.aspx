<%@ Page Title="New Project - Project Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WizardWallsAndMods.aspx.cs" Inherits="SunspaceDealerDesktop.WizardWallsAndMods" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <script src="Scripts/Validation.js"></script>
    <%-- Hidden field populating scripts 
    =================================== --%>
    <script>

        var detailsOfAllLines = '<%= (string)Session["coordList"] %>'; //all the coordinates and details of all the lines, coming from the session
        var lineList = detailsOfAllLines.substr(0, detailsOfAllLines.length - 1).split("/"); //a list of individual lines and their coordinates and details 
        var coordList = new Array(); //new 2d array to store each individual coordinate and details of each line
        for (var i = 0; i < lineList.length; i++) { 
            coordList[i] = lineList[i].split(","); //populate the 2d array
        }
        var wallSetBackArray = new Array(); //array to store the setback for each wall
        var DOOR_MAX_WIDTH = '<%= DOOR_MAX_WIDTH %>';
        var DOOR_MIN_WIDTH = '<%= DOOR_MIN_WIDTH %>';
        var DOOR_FRENCH_MIN_WIDTH = '<%= DOOR_FRENCH_MIN_WIDTH %>';
        var DOOR_FRENCH_MAX_WIDTH = '<%= DOOR_FRENCH_MAX_WIDTH %>';
        var projection = 120; //hard coded for testing, will come from the previous pages in the wizard
        var soffitLength = 0; //hard coded for testing, will come from the previous pages in the wizard
        //var soffit = document.getElementById("MainContent_hidSoffitLength").value = soffitLength;
        //alert(soffit);
        var RUN = 12; //a constant for run in calculating the slope, which is always 12 for slope over 12
        var model = '<%= currentModel %>';

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
            var isValid = true; //to do valid input or invalid input logic
            var answer = ""; //answer, to be displayed on the side panel

            //run through all the textboxes and check if the values in there are valid numbers
            for (var i = 1; i <= lineList.length; i++) {
                if (isNaN(document.getElementById("MainContent_txtWall" + (i) + "Length").value) //if invalid numbers
                    || document.getElementById("MainContent_txtWall" + (i) + "Length").value <= 0 //zero should be changed to MIN_WALL_LENGTH
                    || isNaN(document.getElementById("MainContent_txtWall" + (i) + "LeftFiller").value)
                    || document.getElementById("MainContent_txtWall" + (i) + "LeftFiller").value < 0
                    || isNaN(document.getElementById("MainContent_txtWall" + (i) + "RightFiller").value)
                    || document.getElementById("MainContent_txtWall" + (i) + "RightFiller").value < 0)
                    isValid = false; //set isvalid to false
            }

            if (isValid) { //if everything is valid
                for (var i = 1; i <= lineList.length; i++) { //populate the hidden fields for each wall

                    document.getElementById("hidWall" + i + "SetBack").value = wallSetBackArray[i]; //store wall setback 
                    document.getElementById("hidWall" + i + "LeftFiller").value = document.getElementById("MainContent_txtWall" + i + "LeftFiller").value + document.getElementById("MainContent_ddlWall" + i + "LeftInchFractions").options[document.getElementById("MainContent_ddlWall" + i + "LeftInchFractions").selectedIndex].value; //store left filler
                    document.getElementById("hidWall" + i + "Length").value = document.getElementById("MainContent_txtWall" + i + "Length").value + document.getElementById("MainContent_ddlWall" + i + "InchFractions").options[document.getElementById("MainContent_ddlWall" + i + "InchFractions").selectedIndex].value; //store length
                    document.getElementById("hidWall" + i + "RightFiller").value = document.getElementById("MainContent_txtWall" + i + "RightFiller").value + document.getElementById("MainContent_ddlWall" + i + "RightInchFractions").options[document.getElementById("MainContent_ddlWall" + i + "RightInchFractions").selectedIndex].value; //store right filler

                    answer += "Wall " + i + ": " + document.getElementById("hidWall" + i + "Length").value; //store the values in the answer variable to be displayed
                    calculateSetBack((i - 1)); //calculate setback of the given wall 
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
        
        function typeRowsDisplayed() {

            for (var wallCount = 1; wallCount < coordList.length; wallCount++) {             

                if (document.getElementById('MainContent_radWall' + wallCount).checked) {                    

                    if (document.getElementById('MainContent_radType' + wallCount + 'Cabana').checked) {

                        var doorTitle = document.getElementById("MainContent_rowDoorTitle" + wallCount + "Cabana");
                        var doorStyle = document.getElementById("MainContent_rowDoorStyle" + wallCount + "Cabana");
                        var doorColor = document.getElementById("MainContent_rowDoorColor" + wallCount + "Cabana");
                        var doorHeight = document.getElementById("MainContent_rowDoorHeight" + wallCount + "Cabana");
                        var doorWidth = document.getElementById("MainContent_rowDoorWidth" + wallCount + "Cabana");
                        var doorBoxHeader = document.getElementById("MainContent_rowDoorBoxHeader" + wallCount + "Cabana");

                        var doorNumberOfVents = document.getElementById("MainContent_rowDoorNumberOfVents" + wallCount + "Cabana");
                        var doorGlassTint = document.getElementById("MainContent_rowDoorGlassTint" + wallCount + "Cabana");
                        var doorLHH = document.getElementById("MainContent_rowDoorLHH" + wallCount + "Cabana");
                        var doorRHH = document.getElementById("MainContent_rowDoorRHH" + wallCount + "Cabana");
                        var doorHardware = document.getElementById("MainContent_rowDoorHardware" + wallCount + "Cabana");
                        var doorSwingIn = document.getElementById("MainContent_rowDoorSwingIn" + wallCount + "Cabana");
                        var doorSwingOut = document.getElementById("MainContent_rowDoorSwingOut" + wallCount + "Cabana");
                        var doorPositionDDL = document.getElementById("MainContent_rowDoorPositionDDL" + wallCount + "Cabana");

                        //General
                        doorTitle.style.display = "inherit";
                        doorStyle.style.display = "inherit";
                        doorColor.style.display = "inherit";
                        doorHeight.style.display = "inherit";
                        doorWidth.style.display = "inherit";
                        doorBoxHeader.style.display = "inherit";

                        //Cabana Specific
                        doorGlassTint.style.display = "inherit";
                        doorLHH.style.display = "inherit";
                        doorRHH.style.display = "inherit";
                        doorSwingIn.style.display = "inherit";
                        doorSwingOut.style.display = "inherit";
                        doorHardware.style.display = "inherit";
                        doorNumberOfVents.style.display = "inherit";
                        doorPositionDDL.style.display = "inherit";
                    }
                    else if (document.getElementById('MainContent_radType' + wallCount + 'French').checked) {

                        var doorTitle = document.getElementById("MainContent_rowDoorTitle" + wallCount + "French");
                        var doorStyle = document.getElementById("MainContent_rowDoorStyle" + wallCount + "French");
                        var doorColor = document.getElementById("MainContent_rowDoorColor" + wallCount + "French");
                        var doorHeight = document.getElementById("MainContent_rowDoorHeight" + wallCount + "French");
                        var doorWidth = document.getElementById("MainContent_rowDoorWidth" + wallCount + "French");
                        var doorBoxHeader = document.getElementById("MainContent_rowDoorBoxHeader" + wallCount + "French");

                        var doorOperatorLHH = document.getElementById("MainContent_rowDoorOperatorLHH" + wallCount+ "French");
                        var doorOperatorRHH = document.getElementById("MainContent_rowDoorOperatorRHH" + wallCount + "French");
                        var doorNumberOfVents = document.getElementById("MainContent_rowDoorNumberOfVents" + wallCount + "French");
                        var doorGlassTint = document.getElementById("MainContent_rowDoorGlassTint" + wallCount + "French");
                        var doorHardware = document.getElementById("MainContent_rowDoorHardware" + wallCount+ "French");
                        var doorSwingIn = document.getElementById("MainContent_rowDoorSwingIn" + wallCount + "French");
                        var doorSwingOut = document.getElementById("MainContent_rowDoorSwingOut" + wallCount + "French");
                        var doorPositionDDL = document.getElementById("MainContent_rowDoorPositionDDL" + wallCount + "French");

                        //General
                        doorTitle.style.display = "inherit";
                        doorStyle.style.display = "inherit";
                        doorColor.style.display = "inherit";
                        doorHeight.style.display = "inherit";
                        doorWidth.style.display = "inherit";
                        doorBoxHeader.style.display = "inherit";

                        //French specific
                        doorOperatorLHH.style.display = "inherit";
                        doorOperatorRHH.style.display = "inherit";
                        doorSwingIn.style.display = "inherit";
                        doorSwingOut.style.display = "inherit";
                        doorHardware.style.display = "inherit";
                        doorNumberOfVents.style.display = "inherit";
                        doorPositionDDL.style.display = "inherit";
                    }
                    else if (document.getElementById('MainContent_radType' + wallCount + 'Patio').checked) {

                        var doorTitle = document.getElementById("MainContent_rowDoorTitle" + wallCount + "Patio");
                        var doorStyle = document.getElementById("MainContent_rowDoorStyle" + wallCount + "Patio");
                        var doorColor = document.getElementById("MainContent_rowDoorColor" + wallCount + "Patio");
                        var doorHeight = document.getElementById("MainContent_rowDoorHeight" + wallCount + "Patio");
                        var doorWidth = document.getElementById("MainContent_rowDoorWidth" + wallCount + "Patio");
                        var doorBoxHeader = document.getElementById("MainContent_rowDoorBoxHeader" + wallCount + "Patio");

                        var doorOperatorLHH = document.getElementById("MainContent_rowDoorOperatorLHH" + wallCount + "Patio");
                        var doorOperatorRHH = document.getElementById("MainContent_rowDoorOperatorRHH" + wallCount + "Patio");
                        var doorNumberOfVents = document.getElementById("MainContent_rowDoorNumberOfVents" + wallCount + "Patio");
                        var doorGlassTint = document.getElementById("MainContent_rowDoorGlassTint" + wallCount + "Patio");
                        var doorScreenOptions = document.getElementById("MainContent_rowDoorScreenOptions" + wallCount + "Patio");
                        var doorPositionDDL = document.getElementById("MainContent_rowDoorPositionDDL" + wallCount + "Patio");

                        //General
                        doorTitle.style.display = "inherit";
                        doorStyle.style.display = "inherit";
                        doorColor.style.display = "inherit";
                        doorHeight.style.display = "inherit";
                        doorWidth.style.display = "inherit";
                        doorBoxHeader.style.display = "inherit";

                        //Patio Specifics
                        doorGlassTint.style.display = "inherit";
                        doorOperatorLHH.style.display = "inherit";
                        doorOperatorRHH.style.display = "inherit";
                        doorNumberOfVents.style.display = "inherit";
                        doorPositionDDL.style.display = "inherit";
                    }
                    else if (document.getElementById('MainContent_radType' + wallCount + 'OpeningOnly(NoDoor)').checked) {

                        var doorHeight = document.getElementById("MainContent_rowDoorHeight" + wallCount + "OpeningOnly(NoDoor)");
                        var doorWidth = document.getElementById("MainContent_rowDoorWidth" + wallCount + "OpeningOnly(NoDoor)");

                        doorHeight.style.display = "inherit";
                        doorWidth.style.display = "inherit";
                    }
                }

            }

            

        }

        function customDimension(type, dimension) {
            for (var wallCount = 1; wallCount < coordList.length; wallCount++) {

                if (document.getElementById('MainContent_radWall' + wallCount).checked) {

                    var dimensionDDL = document.getElementById('MainContent_ddlDoor' + dimension + wallCount + type).options[document.getElementById('MainContent_ddlDoor' + dimension + wallCount + type).selectedIndex].value;

                    if (document.getElementById('MainContent_radType' + wallCount + type).checked && dimensionDDL == 'c' + dimension) {
                        document.getElementById('MainContent_rowDoorCustom' + dimension + wallCount + type).style.display = 'inherit';                        
                    }
                    else {
                        document.getElementById('MainContent_rowDoorCustom' + dimension + wallCount + type).style.display = 'none';
                        alert(calculateActualDoorDimension(type, dimension, false));
                    }
                }
            }
        }

        function customPosition(type) {
            for (var wallCount = 1; wallCount < coordList.length; wallCount++) {

                if (document.getElementById('MainContent_radWall' + wallCount).checked) {
                    var positionDDL = document.getElementById('MainContent_ddlDoorPosition' + wallCount + type).options[document.getElementById('MainContent_ddlDoorPosition' + wallCount + type).selectedIndex].value;

                    if (document.getElementById('MainContent_radType' + wallCount + type).checked && positionDDL == 'cPosition') {
                        document.getElementById('MainContent_rowDoorPosition' + wallCount + type).style.display = 'inherit';
                    }
                    else {
                        document.getElementById('MainContent_rowDoorPosition' + wallCount + type).style.display = 'none';
                    }
                }
            }
        }

        function doorStyle(type) {
            for (var wallCount = 1; wallCount < coordList.length; wallCount++) {

                if (document.getElementById('MainContent_radWall' + wallCount).checked) {

                    var HeightDDL = document.getElementById('MainContent_ddlDoorStyle' + wallCount + type).options[document.getElementById('MainContent_ddlDoorStyle' + wallCount + type).selectedIndex].value;

                    if (document.getElementById('MainContent_radType' + wallCount + type).checked && HeightDDL == 'v4TCabana') {
                        document.getElementById('MainContent_rowDoorVinylTint' + wallCount + type).style.display = 'inherit';
                    }
                    else {
                        document.getElementById('MainContent_rowDoorVinylTint' + wallCount + type).style.display = 'none';
                    }
                }
            }
        }

        function calculateActualDoorDimension(type, dimension, custom) {
            
            var newDimension;

            for (var wallCount = 1; wallCount < coordList.length; wallCount++) {

                if (document.getElementById('MainContent_radWall' + wallCount).checked) {

                    var controlToUse;

                    if (custom == true) {

                        controlToUse = parseFloat(document.getElementById('MainContent_txtDoorCustom' + dimension + wallCount + type).value)
                            + parseFloat(document.getElementById('MainContent_ddlInchCustom' + dimension + wallCount + type).options[document.getElementById('MainContent_ddlInchCustom' + dimension + wallCount + type).selectedIndex].value);

                    }
                    else {

                        controlToUse = parseFloat(document.getElementById('MainContent_ddlDoor' + dimension + wallCount + type).options[document.getElementById('MainContent_ddlDoor' + dimension + wallCount + type).selectedIndex].value);

                    }

                    if (type == 'Cabana') {

                        newDimension = (model == 400) ? controlToUse + 3.625 : controlToUse + 2.125;

                    }
                    else if (type == 'French') {

                        newDimension = (model == 400) ? ((controlToUse + 3.625) - 1.625) * 2 + 2 : ((controlToUse + 2.125) - 1.625) * 2 + 2;
                        
                    }
                    else if (type == 'Patio') {
                        //Need more information
                    }
                }
            }

            return newDimension;
        }
        
        function checkDoorPlacement(){
            for (var m = 0; m < doors.length; m++) {                        
                for (var q = 0; q < doors.length; q++) {
                    if (doors[m].distanceFromLeft + doors[m].doorWidth > doors[q].distanceFromLeft || doors[m].distanceFromLeft > doors[q].distanceFromLeft + doors[q].doorWidth){
                        alert("Doors are overlapping");
                    }
                }
            }
        }

        

        //Used to insert items to specific array indices
        Array.prototype.insert = function (index, item) {
            this.splice(index, 0, item);
        };

        function availableSpaceOutput(doorsArray, usuableLength, position) {

            var pagerText = document.getElementById("MainContent_lblQuestion3PagerAnswer");
            var remainSpaces = new Array();
            var textToAdd = "";
            var realArrayLength = 0;
        //    if (position == "left") {
        //        if (doorsArray.length == 1) {
        //            textToAdd = "Left Door Right Hand Space " + parseFloat(usuableLength - doorsArray[0].doorWidth);
        //        }
        //        else {
        //            var closestDoor = doorsArray.sort();
        //            textToAdd = "Left Door Right Hand Space " + parseFloat(closestDoor[1].distanceFromLeft - doorsArray[0].doorWidth);
        //        }
        //    }
        //    else if (position == "right") {
        //        if (doorsArray.length == 1) {
        //            textToAdd = "Right Door Right Hand Space " + parseFloat(usuableLength - doorsArray[2].doorWidth);
        //        }
        //        else {
        //            var closestDoor = doorsArray.sort();
        //            textToAdd = "Right Door Right Hand Space " + parseFloat(doorsArray[2].distanceFromLeft - (closestDoor[1].distanceFromLeft - +closestDoor[1].doorWidth));
        //        }
        //    }
        //    else if (position == "center") {
        //        if (doorsArray.length == 1) {
        //            textToAdd = "Center Door Left Hand Space " + parseFloat(doorsArray[1].distanceFromLeft - doorsArray[1].doorWidth);
        //            textToAdd += "Center Door Right Hand Space " + parseFloat(doorsArray[1].distanceFromLeft - doorsArray[1].doorWidth);
        //        }
        //        else {
        //            textToAdd = "Center Door Left Hand Space " + parseFloat(doorsArray[1].distanceFromLeft - doorsArray[0].doorWidth);
        //            textToAdd += "Center Door Right Hand Space " + parseFloat(doorsArray[2].distanceFromLeft - (doorsArray[1].distanceFromLeft + doorsArray[1].doorWidth));
        //        }
        //    }
            for (var notNullsCount = 0; notNullsCount < doorsArray.length; notNullsCount++) {
                if (doorsArray[notNullsCount] != null) {
                    realArrayLength++;
                }
                //alert(doorsArray[notNullsCount].distanceFromLeft);
            }

            

            if (position === "left") {
                if (realArrayLength == 1) {
                    textToAdd = "Left Door Right Hand Space " + parseFloat(usuableLength - doorsArray[0].doorWidth);
                }
                else {
                    var closestDoor = new Array();
                    closestDoor = doorsArray.sort();
                    textToAdd = "Left Door Right Hand Space " + parseFloat(closestDoor[1].distanceFromLeft - doorsArray[0].doorWidth);
                }
            }
            else if (position === "right") {
                if (realArrayLength == 1) {
                    textToAdd = "Right Door Right Hand Space " + parseFloat(usuableLength - doorsArray[2].doorWidth);
                }
                else {
                    var closestDoor = new Array();
                    closestDoor = doorsArray.sort();
                    textToAdd = "Right Door Right Hand Space " + parseFloat(doorsArray[2].distanceFromLeft - (closestDoor[1].distanceFromLeft - +closestDoor[1].doorWidth));
                }
            }
            else if (position === "center") {
                if (realArrayLength == 1) {
                    textToAdd = "Center Door Left Hand Space " + parseFloat(doorsArray[1].distanceFromLeft - doorsArray[1].doorWidth);
                    textToAdd += "Center Door Right Hand Space " + parseFloat(doorsArray[1].distanceFromLeft - doorsArray[1].doorWidth);
                }
                else if (realArrayLength == 2) {                    
                    if (doorsArray[0].distanceFromLeft != null) {
                        alert(doorsArray[0].doorWidth + " / " + doorsArray[1].distanceFromLeft);
                        textToAdd = "Center Door Left Hand Space " + parseFloat(doorsArray[1].distanceFromLeft - doorsArray[0].doorWidth) + "<br/>";
                        textToAdd += "Center Door Right Hand Space " + parseFloat(usuableLength - (doorsArray[1].distanceFromLeft + doorsArray[1].doorWidth));
                    }
                    else if (doorsArray[2].distanceFromLeft != null) {
                        textToAdd = "Center Door Left Hand Space " + parseFloat(doorsArray[1].distanceFromLeft);
                        textToAdd += "Center Door Right Hand Space " + parseFloat(doorsArray[2].distanceFromLeft - (doorsArray[1].distanceFromLeft + doorsArray[1].doorWidth));
                    }
                }                
                else {
                    textToAdd = "Center Door Left Hand Space " + parseFloat(doorsArray[1].distanceFromLeft - doorsArray[0].doorWidth);
                    textToAdd += "Center Door Right Hand Space " + parseFloat(doorsArray[2].distanceFromLeft - (doorsArray[1].distanceFromLeft + doorsArray[1].doorWidth));
                }
                
            }

            pagerText.innerHTML = textToAdd;
        }

        //To be moved, used to store remain spaces on a wall
        var doors = new Array();
        doors[0] = null;
        doors[1] = null;
        doors[2] = null;
        var finalText;

        function addDoor(type) {

            var hiddenFieldsDiv = document.getElementById('MainContent_hiddenFieldsDiv');

            for (var wallCount = 1; wallCount < coordList.length; wallCount++) {                

                //Find if a door exist to set doorCount to the appropriate value
                if (document.getElementById('MainContent_radWall' + wallCount).checked) {
                    
                    var wallLength = parseFloat(document.getElementById('MainContent_txtWall' + wallCount + 'Length').value);
                    var leftFiller = parseFloat(document.getElementById('MainContent_txtWall' + wallCount + 'LeftFiller').value);
                    var rightFiller = parseFloat(document.getElementById('MainContent_txtWall' + wallCount + 'RightFiller').value);
                    var usuableSpace = wallLength - leftFiller - rightFiller;                    
                    var doorCustomPosition = parseFloat(document.getElementById('MainContent_txtDoorPosition' + wallCount + type)
                        + document.getElementById('MainContent_ddlInchSpecificLeft' + wallCount + type).options[document.getElementById('MainContent_ddlInchSpecificLeft' + wallCount + type).selectedIndex].value);
                    var positionDDLRemoval = document.getElementById('MainContent_ddlDoorPosition' + wallCount + type);
                    var positionDropDown = document.getElementById('MainContent_ddlDoorPosition' + wallCount + type).options[document.getElementById('MainContent_ddlDoorPosition' + wallCount + type).selectedIndex].value;
                    var widthDropDown = document.getElementById('MainContent_ddlDoorWidth' + wallCount + type).options[document.getElementById('MainContent_ddlDoorWidth' + wallCount + type).selectedIndex].value;
                    var heightDropDown = document.getElementById('MainContent_ddlDoorHeight' + wallCount + type).options[document.getElementById('MainContent_ddlDoorHeight' + wallCount + type).selectedIndex].value;                    
                    var doorWidth;

                    if (widthDropDown == "cWidth") {
                        doorWidth = parseFloat(calculateActualDoorDimension(type, 'Width', true));
                    }
                    else {
                        doorWidth = parseFloat(calculateActualDoorDimension(type, 'Width', false));
                    }

                    if (positionDropDown == "left") {
                        doors.insert(0, { "doorWidth": doorWidth, "distanceFromLeft": 0 });
                        positionDDLRemoval.options[0].disabled = true;
                        positionDDLRemoval.setAttribute("disabled", "true");
                        for (var i = 0; i < positionDDLRemoval.length; i++) {
                            
                            if (positionDDLRemoval.options[i].disabled === false) {
                                alert(positionDDLRemoval.options[i].disabled + " / " + i);
                                positionDDLRemoval.options[i].selectedIndex = true;
                                break;
                            }
                        }
                        availableSpaceOutput(doors, usuableSpace, positionDropDown);
                    }
                    else if (positionDropDown == "right") {
                        doors.insert(2, { "doorWidth": doorWidth, "distanceFromLeft": usuableSpace - doorWidth });
                        positionDDLRemoval.options[2].disabled = true;
                        $(positionDDLRemoval + "Option[value='right']").remove();
                        availableSpaceOutput(doors, usuableSpace, positionDropDown);
                    }
                    else if (positionDropDown == "center") {
                        doors.insert(1, { "doorWidth": doorWidth, "distanceFromLeft": usuableSpace / 2 - doorWidth / 2 });
                        positionDDLRemoval.options[1].disabled = true;
                        $(positionDDLRemoval + "Option[value='center']").remove();
                        availableSpaceOutput(doors, usuableSpace, positionDropDown);
                    }
                    else if (positionDropDown == "cPosition") {
                        //Custom length index to be 3
                    }
                    //>
                    else if (positionDropDown === "cPosition") {
                    }                   

                    $("#MainContent_lblQuestion3PagerAnswer").text(finalText);
                    document.getElementById("pagerThree").style.display = "inline";
                    //document.getElementById('MainContent_btnQuestion3').disabled = false;

                    /**This section handles storing individual door data and keeping count of
                    the amount of doors in each wall*/
                    /**********DATA STORING**********/
                    if (!document.getElementById("wall" + wallCount + "Doors")) {
                        
                        var hidDiv = document.createElement("div");
                        hidDiv.setAttribute("id", "wall" + wallCount + "Doors");

                        var hidDoorCount = document.createElement("input");
                        hidDoorCount.setAttribute("id", "wall" + wallCount);
                        hidDoorCount.setAttribute("type", "hidden");
                        hidDoorCount.value = 1;

                        var doorCount = hidDoorCount.value;

                        hidDiv.appendChild(hidDoorCount);
                    }
                    else {
                        var hidDiv = document.getElementById("wall" + wallCount + "Doors");

                        var counterHold = parseInt(document.getElementById("wall" + wallCount).value);
                        counterHold += 1;
                        document.getElementById("wall" + wallCount).value = counterHold;

                        var doorCount = document.getElementById("wall" + wallCount).value;
                    }                    

                    //Door Style
                    var hidDoorStyle = document.createElement("input");
                    hidDoorStyle.setAttribute("id", "door" + doorCount + "OfWall" + wallCount + type + "Style");
                    hidDoorStyle.setAttribute("type", "hidden");
                    hidDoorStyle.value = document.getElementById('MainContent_ddlDoorStyle' + wallCount + type).options[document.getElementById('MainContent_ddlDoorStyle' + wallCount + type).selectedIndex].value;

                    //Door Vinyl Tint
                    var hidDoorVinylTint = document.createElement("input");
                    hidDoorVinylTint.setAttribute("id", "door" + doorCount + "OfWall" + wallCount + type + "VinylTint");
                    hidDoorVinylTint.setAttribute("type", "hidden");
                    hidDoorVinylTint.value = document.getElementById('MainContent_ddlVinylTint' + wallCount + type).options[document.getElementById('MainContent_ddlVinylTint' + wallCount + type).selectedIndex].value;

                    //Door Color
                    var hidDoorColor = document.createElement("input");
                    hidDoorColor.setAttribute("id", "door" + doorCount + "OfWall" + wallCount + type + "Color");
                    hidDoorColor.setAttribute("type", "hidden");                
                    hidDoorColor.value = document.getElementById('MainContent_ddlDoorColor' + wallCount + type).options[document.getElementById('MainContent_ddlDoorColor' + wallCount + type).selectedIndex].value;

                    //Door Height
                    var hidDoorHeight = document.createElement("input");
                    hidDoorHeight.setAttribute("id", "door" + doorCount + "OfWall" + wallCount + type + "Height");
                    hidDoorHeight.setAttribute("type", "hidden");              

                    if (heightDropDown == 'cHeight') {
                        hidDoorHeight.value = parseFloat(calculateActualDoorDimension(type, 'Height', true));
                    }
                    else {
                        hidDoorHeight.value = parseFloat(calculateActualDoorDimension(type, 'Height', false));
                    }

                    //Door Width
                    var hidDoorWidth = document.createElement("input");
                    hidDoorWidth.setAttribute("id", "door" + doorCount + "OfWall" + wallCount + type + "Width");
                    hidDoorWidth.setAttribute("type", "hidden");
                    hidDoorWidth.value = doorWidth;

                    //Primary Operator
                    var hidDoorPrimaryOperator = document.createElement("input");
                    hidDoorPrimaryOperator.setAttribute("id", "door" + doorCount + "OfWall" + wallCount + type + "PrimaryOperator");
                    hidDoorPrimaryOperator.setAttribute("type", "hidden");

                    if (document.getElementById('MainContent_radDoorOperatorLHH' + wallCount + type).checked) {
                        hidDoorPrimaryOperator.value = "left";
                    }
                    else {
                        hidDoorPrimaryOperator.value = "right";
                    }

                    //Door Box Header Positiion
                    var hidDoorBoxHeaderPosition = document.createElement("input");
                    hidDoorBoxHeaderPosition.setAttribute("id", "door" + doorCount + "OfWall" + wallCount + type + "BoxHeaderPosition");
                    hidDoorBoxHeaderPosition.setAttribute("type", "hidden");
                    hidDoorBoxHeaderPosition.value = document.getElementById('MainContent_ddlDoorBoxHeader' + wallCount + type).options[document.getElementById('MainContent_ddlDoorBoxHeader' + wallCount + type).selectedIndex].value;

                    //Number Of Vents
                    var hidDoorNumberOfVents = document.createElement("input");
                    hidDoorNumberOfVents.setAttribute("id", "door" + doorCount + "OfWall" + wallCount + type + "NumberOfVents");
                    hidDoorNumberOfVents.setAttribute("type", "hidden");
                    hidDoorNumberOfVents.value = document.getElementById('MainContent_ddlNumberOfVents' + wallCount + type).options[document.getElementById('MainContent_ddlNumberOfVents' + wallCount + type).selectedIndex].value;

                    //Glass Tint
                    var hidDoorGlassTint = document.createElement("input");
                    hidDoorGlassTint.setAttribute("id", "door" + doorCount + "OfWall" + wallCount + type + "GlassTint");
                    hidDoorGlassTint.setAttribute("type", "hidden");
                    hidDoorGlassTint.value = document.getElementById('MainContent_ddlDoorGlassTint' + wallCount + type).options[document.getElementById('MainContent_ddlDoorGlassTint' + wallCount + type).selectedIndex].value;

                    //Hinge Placement
                    var hidDoorHingePlacement = document.createElement("input");
                    hidDoorHingePlacement.setAttribute("id", "door" + doorCount + "OfWall" + wallCount + type + "HingePlacement");
                    hidDoorHingePlacement.setAttribute("type", "hidden");
                    if (document.getElementById('MainContent_radDoorLHH' + wallCount + type).checked) {
                        hidDoorHingePlacement.value = "left";
                    }
                    else {
                        hidDoorHingePlacement.value = "right";
                    }

                    //Screen Options
                    var hidDoorScreenOptions = document.createElement("input");
                    hidDoorScreenOptions.setAttribute("id", "door" + doorCount + "OfWall" + wallCount + type + "ScreenOptions");
                    hidDoorScreenOptions.setAttribute("type", "hidden");
                    hidDoorScreenOptions.value = document.getElementById('MainContent_ddlDoorScreenOptions' + wallCount + type).options[document.getElementById('MainContent_ddlDoorScreenOptions' + wallCount + type).selectedIndex].value;

                    //Hardware
                    var hidDoorHardware = document.createElement("input");
                    hidDoorHardware.setAttribute("id", "door" + doorCount + "OfWall" + wallCount + type + "Hardware");
                    hidDoorHardware.setAttribute("type", "hidden");
                    hidDoorHardware.value = document.getElementById('MainContent_ddlDoorHardware' + wallCount + type).options[document.getElementById('MainContent_ddlDoorHardware' + wallCount + type).selectedIndex].value;

                    //Swing
                    var hidDoorSwing = document.createElement("input");
                    hidDoorSwing.setAttribute("id", "door" + doorCount + "OfWall" + wallCount + type + "Swing");
                    hidDoorSwing.setAttribute("type", "hidden");
                    if (document.getElementById('MainContent_radDoorSwingIn' + wallCount + type).checked) {
                        hidDoorSwing.value = "in";
                    }
                    else {
                        hidDoorSwing.value = "out";
                    }

                    //Position
                    var hidDoorPosition = document.createElement("input");
                    hidDoorPosition.setAttribute("id", "door" + doorCount + "OfWall" + wallCount + type + "Position");
                    hidDoorPosition.setAttribute("type", "hidden");
                    hidDoorPosition.setAttribute("runat", "server");
                    if (positionDropDown === "cPosition") {
                        hidDoorPosition.value = doorCustomPosition;
                    }
                    else {
                        hidDoorPosition.value = positionDropDown;
                    }

                    //Appending all created fields to hiddenFieldsDiv div tag                    
                    hidDiv.appendChild(hidDoorStyle);
                    hidDiv.appendChild(hidDoorVinylTint);
                    hidDiv.appendChild(hidDoorColor);
                    hidDiv.appendChild(hidDoorHeight);
                    hidDiv.appendChild(hidDoorWidth);
                    hidDiv.appendChild(hidDoorPrimaryOperator);
                    hidDiv.appendChild(hidDoorBoxHeaderPosition);
                    hidDiv.appendChild(hidDoorNumberOfVents);
                    hidDiv.appendChild(hidDoorGlassTint);
                    hidDiv.appendChild(hidDoorHingePlacement);
                    hidDiv.appendChild(hidDoorScreenOptions);
                    hidDiv.appendChild(hidDoorHardware);
                    hidDiv.appendChild(hidDoorSwing);
                    hidDiv.appendChild(hidDoorPosition);

                    hiddenFieldsDiv.appendChild(hidDiv);

                }
            }
        }

        //function onClickAddDoor(currentDoor) {
        //    var $doorDetails = $('#doorDetails');
        //    var $doorDetailsList = $('#doorDetailsList');
        //    var tblDoor = document.getElementById("MainContent_tblDoorDetails" + currentDoor);

        //    alert($doorDetailsList.size());

        //    if (tblDoor.style.display == "block") {
        //        var newClonedLi = $doorDetails.find('li:first').clone(true);
        //        newClonedLi.appendTo($doorDetails.find('ul'));
        //    }
        //    else {
        //        alert("Is this working?");
        //        tblDoor.style.display = "block";                
        //    }

        //}
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
                    <asp:Table ID="tblExistingWalls" runat="server">
                        <asp:TableRow>
                            <%-- table headings --%>
                            <asp:TableHeaderCell >
                                Existing Walls
                            </asp:TableHeaderCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell></asp:TableCell>
                            <%-- column headings --%>
                            <asp:TableCell ColumnSpan="6" >
                                Length
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <%-- end of existing walls table --%>
                    <br />
                    <%-- second table for proposed walls, contains input fields for lengths, as well as left and right fillers --%>
                    <asp:Table ID="tblProposedWalls" runat="server">
                        <asp:TableRow>
                            <%-- table headings --%>
                            <asp:TableHeaderCell >
                                Proposed Walls
                            </asp:TableHeaderCell>
                        </asp:TableRow>
                        
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
                <asp:Button ID="Button1" Enabled="true" CssClass="btnSubmit float-right slidePanel" data-slide="#slide3" runat="server" Text="Next Question" />

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

                <asp:Button ID="btnQuestion3" OnClick="createWallObjects" Enabled="true" CssClass="btnSubmit float-right slidePanel" runat="server" Text="Next Question" />

            </div>
            <%-- end #slide3 --%>
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
                            <a href="#" data-slide="#slide3" class="slidePanel">
                                <asp:Label ID="lblQuestion3Pager" runat="server" Text="Wall Length Left"></asp:Label>
                                <asp:Label ID="lblQuestion3PagerAnswer" runat="server" Text="Question 3 Answer"></asp:Label>
                            </a>
                    </li>
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
            var lowestWall = 0; //arbitrary number to determine the most south wall (i.e. the front wall) on the canvas
            var lowestIndex; //index of the most south wall
            var highestWall = 200; //arbitrary number to determine to least south wall (i.e. the back wall) on the canvas
            var highestIndex; //index of the least south wall
            var index = -1; //invalid to determine if there is a wall or not
            

            for (var i = 0; i < lineList.length; i++) { //run through the list of walls
                if (coordList[i][5] == "S") //5 = orientation... if the orientation is south
                    southWalls.push({ "y2": lineArray[i].attr("y2"), "number": i, "type": coordList[i][4] }); //populate south walls array.. 4 = wall type
            }

            if (wall == "B") //if the textbox in focus is backwall textbox
                index = getBackWall(southWalls); //get the index of the backwall
            else { //if (wall == "F") //if the textbox in focus is frontwall textbox
                if (southWalls[southWalls.length - 1].type == "P") //check if the front wall is a proposed walls
                    index = getFrontWall(southWalls); //if its a proposed wall, get its index
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
        @return lowestIndex - index of the top most south facing wall on the canvas, i.e. the back wall
        */
        function getBackWall(southWalls) {
            var lowestWall = 0; //arbitrary number to determine back wall (number represents value of coordinate, low number means top of canvas)
            var lowestIndex; //to store the index of the back wall
            for (var i = 0; i < southWalls.length; i++) { //run through all south facing walls
                if (southWalls[i].y2 > lowestWall) { //if the y2 coordinate of the current wall is higher than the value of lowest wall
                    lowestWall = southWalls[i].y2; //that means we have a new lowest coordinate
                    lowestIndex = southWalls[i].number; //store the index of the wall
                }
            }
            return lowestIndex; //return the index of the lowest wall found, i.e. wall that's nearest to the top of canvas
        }

        /**
        This function is used to determine the front wall index
        @param southWalls - the array of all south facing walls
        @return highestIndex - index of the bottom most south facing wall on the canvas, i.e. the front wall
        */
        function getFrontWall(southWalls) {
            var highestWall = 501; //arbitrary number to determine back wall (number represents value of coordinate, low number means top of canvas)
            var highestIndex; //to store the index of the back wall
            for (var i = 0; i < southWalls.length; i++) { //run through all south facing walls
                if (southWalls[i].y2 < highestWall) { //if the y2 coordinate of the current wall is lower than the value of highest wall
                    highestWall = southWalls[i].y2; //that means we have a new highest coordinate
                    highestIndex = southWalls[i].number; //store the index of the wall
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

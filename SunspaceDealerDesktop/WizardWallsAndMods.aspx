<%@ Page Title="New Project - Project Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WizardWallsAndMods.aspx.cs" Inherits="SunspaceDealerDesktop.WizardWallsAndMods" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <script src="Scripts/Validation.js"></script>
    <script>
        //Embedded variables needed before call or addition of DoorSlideFunction.js
        var model = '<%= currentModel %>';
        var CABANA_MAX_WIDTH = '<%= Session["CABANA_MAX_WIDTH"] %>';
        var CABANA_MIN_WIDTH = '<%= Session["CABANA_MIN_WIDTH"] %>';
        var CABANA_MAX_HEIGHT = '<%= Session["CABANA_MAX_HEIGHT"] %>';
        var CABANA_MIN_HEIGHT = '<%= Session["CABANA_MIN_HEIGHT"] %>';
        var PATIO_DOOR_MIN_WIDTH = '<%= Session["PATIO_DOOR_MIN_WIDTH"] %>';
        var PATIO_DOOR_MAX_WIDTH = '<%= Session["PATIO_DOOR_MAX_WIDTH"] %>';
        var PATIO_DOOR_MIN_HEIGHT = '<%= Session["PATIO_DOOR_MIN_HEIGHT"] %>';
        var PATIO_DOOR_MAX_HEIGHT = '<%= Session["PATIO_DOOR_MAX_HEIGHT"] %>';
    </script>
    <script src="Scripts/DoorSlideFunctions.js"></script>
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

        

        var projection = 120; //room projection from the left ... hard coded for testing
        var antiProjection = 120; //room projection from the right ... hard coded for testing
        var roomProjection = 120; //the higher of the two room projections
        var soffitLength = '<%= soffitLength %>'; //hard coded for testing, will come from the previous pages in the wizard
        var RUN = 12; //a constant for run in calculating the slope, which is always 12 for slope over 12
         
        
        var walls = []; //array to store the walls

        //This array holds the name of all the properties attributed to walls
        //ADD AS NEEDED
        var wallProperties = [
            "wallId",
            "length",
            "height",
            "doors",
            "windows"
        ]
        
        /**
        *Adding onclick events to next question buttons
        */
        $(document).ready(function () {            
            $('#MainContent_btnQuestion1').click(loadWallData);
            $('#MainContent_btnQuestion2').click(determineStartAndEndHeightOfEachWall);
            $('#MainContent_btnQuestion4').click(submitData);
        });

        /**
        *submitData
        *This function will submit data to the session which will be used within C#
        *to create objects.
        */
        function submitData() {

            var hiddenDiv = document.getElementById("MainContent_hiddenFieldsDiv");
            var proposedWalls = 0;
            //Loop through all the lines(walls)
            for (var i = 1; i <= lineList.length; i++) {
                //If the wall is of type "P" (proposed), perform this block
                if (coordList[i - 1][4] === "P") {

                    proposedWalls++;
                    var wall = walls[i];
                    var hiddenDoorCount = document.createElement("input");
                    hiddenDoorCount.setAttribute("type", "hidden");
                    hiddenDoorCount.setAttribute("name", "wall" + i + "DoorCount");
                    hiddenDoorCount.value = wall.doors.length;

                    hiddenDiv.appendChild(hiddenDoorCount);

                    for (var doorCount = 0; doorCount < wall.doors.length; doorCount++) {

                        var door = wall.doors[doorCount];

                        var hiddenPropertiesCount = document.createElement("input");
                        hiddenPropertiesCount.setAttribute("type", "hidden");
                        hiddenPropertiesCount.setAttribute("name", "wall" + i + "Door" + doorCount + "PropertyCount");
                        hiddenPropertiesCount.value = Object.keys(door).length;

                        hiddenDiv.appendChild(hiddenPropertiesCount);

                        for (var prop in door) {
                            if (door.hasOwnProperty(prop)) {
                                var hiddenDoorProperty = document.createElement("input");
                                hiddenDoorProperty.setAttribute("type", "hidden");
                                hiddenDoorProperty.setAttribute("name", "wall" + i + "Door" + doorCount + prop[0].toUpperCase() + prop.substr(1));
                                hiddenDoorProperty.value = door[prop];

                                hiddenDiv.appendChild(hiddenDoorProperty);
                            }
                        }
                    }
                }
            }
            var hiddenWallCount = document.createElement("input");
            hiddenWallCount.setAttribute("type", "hidden");
            hiddenWallCount.setAttribute("name", "wallCount");
            hiddenWallCount.value = proposedWalls;

            hiddenDiv.appendChild(hiddenWallCount);
        }

        /**
        *loadWallData
        *This function loads the respective wall information (lenght, and filler sizes)
        *into the respective wall objects
        *NOTE: The data is being loaded on the line index. In example, their are 2 existing walls and 2 proposed walls.
        *The data of the first proposed wall is being loaded into index 3 and the second proposed wall is being loaded
        *into index 4 (i.e. walls[4].length)
        */
        function loadWallData() {

            //New array of walls
            walls = [];

            //Array containing fields to get from the first slide
            var wallInfo = [
                ["LeftFiller", "LeftInchFractions"],
                ["Length", "InchFractions"],
                ["RightFiller", "RightInchFractions"]
            ];

            //Loop through all the lines(walls)
            for (var i = 1; i <= lineList.length; i++) {
                //If the wall is of type "P" (proposed), perform this block
                if (coordList[i - 1][4] === "P") {

                    //Create variable wall to hold hold the current walls id and various properties
                    var wall = {
                        "id": i,
                        "doors": [],
                        "windows": []
                    };

                    //For loop to get values from first slide controls, which are: Left Filler, Length, Right Filler.
                    //These are repeated for every proposed wall.
                    for (var inner = 0; inner < wallInfo.length; inner++) {
                        //Get the text box value of the current pair of controls
                        var valueText = parseFloat($('#MainContent_txtWall' + i + wallInfo[inner][0]).val());
                        //Get the drop down value of the current pair of controls
                        var valueDDL = parseFloat($('#MainContent_ddlWall' + i + wallInfo[inner][1]).val());

                        //Store the respective values to a property in wall, they are named as follows:
                        //leftFiller, length, rightFiller
                        wall[wallInfo[inner][0][0].toLowerCase() + wallInfo[inner][0].substr(1)] = parseFloat(valueText) + parseFloat(valueDDL);
                    }
                    //Store the current wall within the walls array
                    walls[i] = wall;
                }
            }
        }
        
        /**
        This function calculates the "setback" of each wall, i.e. the number of inches the current wall adds to the projection.
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
            var L = +(document.getElementById("MainContent_txtWall" + (index+1) + "Length").value);

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
            to calculate the room projection and antiProjection by simply adding each setback value.
        @return projection - i.e. room projection from the left
        @return antiProjection - i.e. room projection from the right
        */
        function calculateProjection() {
            var tempProjection = 0; //variable to store each setback
            var highestProjection = 0; //variable to store the highest projection calculated from the left side of the room
            var lowestProjection = 0; //variable to store the highest projection calculated from the right side of the room
            //var overallProjection;
            for (var i = 0; i < wallSetBackArray.length; i++) { //run through all the setbacks
                if (wallSetBackArray[i]) { //if its not null (it would be null for existing walls
                    tempProjection = +tempProjection + +wallSetBackArray[i]; //add the values to temp variable
                    if (tempProjection > highestProjection) { //determine if the current temp projection is greater than the highest projection calculated
                        highestProjection = tempProjection; // reset the highest projection
                    }
                    if (tempProjection < lowestProjection) {
                        lowestProjection = tempProjection;
                    }
                }
            }

            projection = highestProjection;
            antiProjection = highestProjection + (lowestProjection * -1);

            if (antiProjection > projection)
                return antiProjection;
            else 
                return projection;

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

            m = document.getElementById("MainContent_txtRoofSlope").value;

            if (backWall === "north") { //if back wall is a north facing wall, i.e. is not existing wall 
                wallStartHeightArray[backWallIndex] = +document.getElementById("MainContent_hidBackWallHeight").value;
                wallEndHeightArray[backWallIndex] = +document.getElementById("MainContent_hidBackWallHeight").value;
                
                for (var i = (backWallIndex - 1); i >= 0; i--) { //0 = index of first wall


                    if (coordList[i][4] === "E") { //existing wall
                        //if (coordList[i][5] === "S") {

                        ///this is assuming that back wall is an existing wall...
                        wallStartHeightArray[i] = +document.getElementById("MainContent_hidBackWallHeight").value;
                        wallEndHeightArray[i] = +document.getElementById("MainContent_hidBackWallHeight").value;
                        //}

                    }
                    else { //proposed wall

                        wallEndHeightArray[i] = +wallStartHeightArray[i + 1];

                        switch (coordList[i][5]) {
                            case "S": //if south
                            case "N": //or north
                                wallStartHeightArray[i] = +wallEndtHeightArray[i];
                                break;
                            case "W": //if west
                                wallStartHeightArray[i] = +wallEndHeightArray[i] - parseFloat((((+wallLengthArray[i] - wallSoffitArray[i]) * m) / RUN).toFixed(2)); //determine rise based on slope and length, and subtract it from start height
                                break;
                            case "E": //if east
                                wallStartHeightArray[i] = +wallEndHeightArray[i] + parseFloat((((+wallLengthArray[i] - wallSoffitArray[i]) * m) / RUN).toFixed(2)); //determine rise based on slope and length, and add it to start height
                                break;
                            case "SW": //if southwest
                            case "SE": //or northwest
                                wallStartHeightArray[i] = +wallEndHeightArray[i] - parseFloat((((+wallSetBackArray[i] - wallSoffitArray[i]) * m) / RUN).toFixed(2)); //determine rise based on slope and setback, then subtract it from start height 
                                break;
                            case "NW": //if southeast
                            case "NE": //or northeast
                                wallStartHeightArray[i] = +wallEndHeightArray[i] + parseFloat((((+wallSetBackArray[i] - wallSoffitArray[i]) * m) / RUN).toFixed(2)); //determine rise based on slope and setback, then add it to start height 
                                break;
                        }
                    }
                    console.log("North facing starting: " + wallStartHeightArray[i]);
                    console.log("North facing ending: " + wallEndHeightArray[i]);
                }
            }
            else if (backWall === "south") { //if backwall is a south facing wall.. i.e. is existing
                for (var i = 0; i < coordList.length; i++) {
                    if (coordList[i][4] === "E") { //existing wall
                        wallStartHeightArray[i] = +document.getElementById("MainContent_hidBackWallHeight").value;
                        wallEndHeightArray[i] = +document.getElementById("MainContent_hidBackWallHeight").value;
                    }
                    else { //proposed wall
                    //if (coordList[i][4] === "P") {

                        wallStartHeightArray[i] = +wallEndHeightArray[i - 1];

                        switch (coordList[i][5]) {
                            case "S": //if south
                            case "N": //or north
                                wallEndHeightArray[i] = +wallStartHeightArray[i];
                                break;
                            case "W": //if west
                                wallEndHeightArray[i] = +wallStartHeightArray[i] - parseFloat((((+wallLengthArray[i] - wallSoffitArray[i]) * m) / RUN).toFixed(2)); //determine rise based on slope and length, and subtract it from start height
                                break;
                            case "E": //if east
                                wallEndHeightArray[i] = +wallStartHeightArray[i] + parseFloat((((+wallLengthArray[i] - wallSoffitArray[i]) * m) / RUN).toFixed(2)); //determine rise based on slope and length, and add it to start height
                                break;
                            case "SW": //if southwest
                            case "SE": //or northwest
                                wallEndHeightArray[i] = +wallStartHeightArray[i] - parseFloat((((+wallSetBackArray[i] - wallSoffitArray[i]) * m) / RUN).toFixed(2)); //determine rise based on slope and setback, then subtract it from start height 
                                break;
                            case "NW": //if southeast
                            case "NE": //or northeast
                                wallEndHeightArray[i] = +wallStartHeightArray[i] + parseFloat((((+wallSetBackArray[i] - wallSoffitArray[i]) * m) / RUN).toFixed(2)); //determine rise based on slope and setback, then add it to start height 
                                break;
                        }
                    }
                    console.log("South facing starting: " + wallStartHeightArray[i]);
                    console.log("South facing ending: " + wallEndHeightArray[i]);
                    console.log("Soffit: " + wallSoffitArray[i]);
                    console.log("Wall length: " + wallLengthArray[i]);
                    console.log("Wall setback: " + wallSetBackArray[i]);
                    console.log("--------------------------------");
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

            /*
            IF PROJECTION > ANTI-PROJECTION
                ROOF-LENGTH = ANTI-PROJECTION - SOFFIT-RIGHT
                SOFFIT-LEFT = PROJECTION - ROOF-LENGTH
            IF PROJECTION < ANTI-PROJECTION
                ROOF-LENGTH = PROJECTION - SOFFIT-LEFT
                SOFFIT-RIGHT = ANTI-PROJECTION - ROOF-LENGTH
            IF PROJECTION = ANTI-PROJECTION
                SOFFIT-LEFT = SOFFIT-RIGHT
            */
            
            var soffitLeft = 0, soffitRight = 0, roofLength = 0;
            var soffitLeftArray = new Array();
            var soffitRightArray = new Array();
            var iLeft = 0, iRight = 0;

            if (projection > antiProjection) {
                soffitRight = soffitLength;
                roofLength = antiProjection - soffitRight;
                soffitLeft = projection - roofLength;
            }
            else if (projection < antiProjection) {
                soffitLeft = soffitLength;
                roofLength = projection - soffitLeft;
                soffitRight = antiProjection - roofLength;
            }
            else { //projection === antiProjection
                soffitLeft = soffitRight = soffitLength;
            }

            //console.log("Left soffit:", soffitLeft);
            //console.log("Right soffit:", soffitRight);

            soffitLeftArray[0] = soffitLeft;
            soffitRightArray[0] = soffitRight;

            //determine how many walls the left soffit spans
            do {
                if (soffitLeftArray[iLeft] > wallLengthArray[existingWallCount + iLeft]) { //if the length of the left soffit is greater than the (first) proposed wall length
                    soffitLeftArray[iLeft] = wallLengthArray[existingWallCount + iLeft]; //set the element of left soffit array to length of the proposed wall
                    soffitLeftArray[iLeft + 1] = parseFloat(soffitLeftArray[iLeft]) - parseFloat(wallLengthArray[existingWallCount + iLeft]); //subtract the length of the proposed wall from soffit length
                                                                                                           //set the remaining soffit length to the next element of the left soffit array
                    iLeft++; //increment the counter
                }
                else //if the length of the left soffit is the same or less than proposed wall length
                    soffitLeftArray[iLeft] = soffitLeft; //set the element of the left soffit array to length of the left soffit

                console.log("DO left soffit array:", soffitLeftArray[iLeft]);
                console.log("DO wall length:", wallLengthArray[existingWallCount + iLeft]);
                console.log("count:", existingWallCount + iLeft);
                console.log("iLeft:", iLeft);
                console.log("DO left soffit array TWO:", soffitLeftArray[iLeft + 1]);

            } while (iLeft > 0 && soffitLeftArray[iLeft] > wallLengthArray[existingWallCount + iLeft]); //continue while the counter is greater than 0 and the soffit length remaining is greater than next wall's length

            //determine how many walls the right soffit spans
            do {

                console.log("DO right soffit array:", soffitRightArray[iRight]);
                console.log("DO wall length:", wallLengthArray[wallLengthArray.length - 1 - iRight]);
                console.log("count:", wallLengthArray.length - 1 - iRight);
                console.log("iRight:", iRight);
                if (soffitRightArray[iRight] > wallLengthArray[wallLengthArray.length - 1 - iRight]) { //if the length of the right soffit is greater than the (last) proposed wall length
                    soffitRightArray[iRight] = wallLengthArray[wallLengthArray.length - 1 - iRight]; //set the element of right soffit array to length of the proposed wall
                    soffitRightArray[iRight + 1] = soffitRight - wallLengthArray[wallLengthArray.length - 1 - iRight]; //subtract the length of the proposed wall from soffit length
                                                                                                                    //set the remaining soffit length to the next element of the right soffit array
                    iRight++; //increment the counter
                }
                else //if the length of the right soffit is the same or less than proposed wall length
                    soffitRightArray[iRight] = soffitRight;  //set the element of the right soffit array to length of the right soffit
            } while (iRight > 0 && soffitRightArray[iRight] > wallLengthArray[wallLengthArray.length - 1 - iRight]); //continue while the counter is greater than 0 and the soffit length remaining is greater than next wall's length


            //for (var i = 0; i < soffitLeftArray.length; i++)
            //    console.log("left soffit array:", soffitLeftArray[i]);
            //for (var i = 0; i < soffitRightArray.length; i++)
            //    console.log("right soffit array:", soffitRightArray[i]);

            for (var i = 0; i < soffitLeftArray.length; i++) {
                wallSoffitArray[existingWallCount + 1 + i] = soffitLeftArray[i];
                //console.log(soffitLeftArray[i]);
            }

            for (var i = 0; i < soffitRightArray.length; i++) {
                wallSoffitArray[coordList.length - 1 - i] = soffitRightArray[i];
                //console.log(soffitRightArray[i]);
            }


















            //var firstWallLength = document.getElementById("hidWall" + (existingWallCount + 1) + "Length").value;
            //var lastWallLength = document.getElementById("hidWall" + (coordList.length - 1) + "Length").value;

            ///*************************************************************************************/
            ///*************************************************************************************/
            ///*************************************************************************************/
            //var firstWallStartPoint = coordList[existingWallCount + 1][2]; // 2 = y1
            //var lastWallEndPoint = coordList[coordList.length - 1][3]; // 3 = y2
            ///*************************************************************************************/
            ///*************************************************************************************/
            ///*************************************************************************************/

            //for (var i = 0; i < coordList.length; i++) {
            //    if (i === (existingWallCount + 1) || i === (coordList.length - 1)) { //first proposed wall or last proposed wall
            //        if (coordList[i][5] === "W" || coordList[i][5] === "E") { //if its vertical and perpendicular to existing wall 
            //            wallSoffitArray[i] = soffitLength; //set the soffit length
            //            if (firstWallLength > lastWallLength) //if different lengths
            //                wallSoffitArray[existingWallCount + 1] += (firstWallLength - lastWallLength); //add the difference to the appropriate wall
            //            else if (lastWallLength > firstWallLength) //if different lengths
            //                wallSoffitArray[coordList.length - 1] += (lastWallLength - firstWallLength); //add the difference to the appropriate wall
            //        }
            //        else //if they are not vertical perpendicular
            //            wallSoffitArray[i] = 0; //no soffit
            //    }
            //    else //if not first or last proposed wall
            //        wallSoffitArray[i] = 0; //no soffit
            //}


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
            var rise; //m = ((rise * run)/(roomProjection - soffitLength)) slope over 12
            var backWallHeight, frontWallHeight;

            backWallHeight = +(document.getElementById("MainContent_txtBackWallHeight").value) + +(document.getElementById("MainContent_ddlBackInchFractions").options[document.getElementById("MainContent_ddlBackInchFractions").selectedIndex].value);
            frontWallHeight = +(document.getElementById("MainContent_txtFrontWallHeight").value) + +(document.getElementById("MainContent_ddlFrontInchFractions").options[document.getElementById("MainContent_ddlFrontInchFractions").selectedIndex].value);

            rise = backWallHeight - frontWallHeight;

            return (((rise * RUN) / (roomProjection - soffitLength)).toFixed(2));  //slope over 12, rounded to 2 decimal places
        }
        
        /**
        This function calculates the rise based on the slope (over 12) and one of the heights
        @return rise (from the slope equation)
        */
        function calculateRise() {
            var m;    //m = ((rise * run)/(roomProjection - soffitLength)) slope over 12

            m = +(document.getElementById("MainContent_txtRoofSlope").value); //get the slope from the textbox

            return ((((roomProjection - soffitLength) * m) / RUN).toFixed(2)); //rise, rounded to 2 decimal places
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


                for (var i = 1; i <= lineList.length; i++) { //populate the hidden fields for each wall
                    if (coordList[i - 1][4] === "P") {
                        calculateSetBack((i - 1)); //calculate setback of the given wall
                        
                        document.getElementById("hidWall" + i + "SetBack").value = wallSetBackArray[i - 1]; //store wall setback 
                        wallLeftFillerArray[i - 1] = document.getElementById("hidWall" + i + "LeftFiller").value = //store left filler
                            +(document.getElementById("MainContent_txtWall" + i + "LeftFiller").value) + //textbox value
                            +(document.getElementById("MainContent_ddlWall" + i + "LeftInchFractions").options[document.getElementById("MainContent_ddlWall" + i + "LeftInchFractions").selectedIndex].value); //dropdown value
                        wallLengthArray[i - 1] = document.getElementById("hidWall" + i + "Length").value = //store length
                            +(document.getElementById("MainContent_txtWall" + i + "Length").value) + //textbox value
                            +(document.getElementById("MainContent_ddlWall" + i + "InchFractions").options[document.getElementById("MainContent_ddlWall" + i + "InchFractions").selectedIndex].value); //dropdown value
                        wallRightFillerArray[i - 1] = document.getElementById("hidWall" + i + "RightFiller").value = //store right filler
                            +(document.getElementById("MainContent_txtWall" + i + "RightFiller").value) + //textbox value
                            +(document.getElementById("MainContent_ddlWall" + i + "RightInchFractions").options[document.getElementById("MainContent_ddlWall" + i + "RightInchFractions").selectedIndex].value); //dropdown value
                        document.getElementById("hidWall" + i + "SoffitLength").value = wallSoffitArray[i - 1];//store wall soffitlength
                        answer += "Wall " + i + ": " + document.getElementById("hidWall" + i + "Length").value; //store the values in the answer variable to be displayed
                  
                    }

                }

                determineSoffitLengthOfEachWall(); //calculate and store soffitlength of each wall

                //store roomProjection in the roomProjection variable and hidden field
                document.getElementById("MainContent_hidroomProjection").value = roomProjection = calculateProjection(); 

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
                document.getElementById("MainContent_hidBackWallHeight").value =
                    +(document.getElementById("MainContent_txtBackWallHeight").value) +
                    +(document.getElementById("MainContent_ddlBackInchFractions").options[document.getElementById("MainContent_ddlBackInchFractions").selectedIndex].value);
                document.getElementById("MainContent_hidFrontWallHeight").value =
                    +(document.getElementById("MainContent_txtFrontWallHeight").value) +
                    +(document.getElementById("MainContent_ddlFrontInchFractions").options[document.getElementById("MainContent_ddlFrontInchFractions").selectedIndex].value);
                document.getElementById("MainContent_hidRoofSlope").value = +(document.getElementById("MainContent_txtRoofSlope").value);

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
    <div id="sidebar">
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

        <asp:Label ID="lblErrorMessage" CssClass="lblErrorMessage" runat="server" Text="Label">Oh hello, I am an error message.</asp:Label> 
    </div>
    
<script src="Scripts/MiniCanvasFunctions.js"></script>

    <%-- Hidden input tags 
    ======================= --%>

    <%-- hiddenFieldsDiv is used to store dynamically generated hidden fields from codebehind --%>
    <div id="hiddenFieldsDiv" runat="server"></div>
    <%-- <input id="hidSoffitLength" type="hidden" runat="server" /> --%>
    <input id="hidroomProjection" type="hidden" runat="server" />
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

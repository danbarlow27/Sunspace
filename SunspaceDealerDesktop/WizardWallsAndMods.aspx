﻿<%@ Page Title="New Project - Project Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WizardWallsAndMods.aspx.cs" Inherits="SunspaceDealerDesktop.WizardWallsAndMods" %>

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
        var MODEL_100_200_300_TRANSOM_MINIMUM_SIZE = '<%= Session["MODEL_100_200_300_TRANSOM_MINIMUM_SIZE"] %>';
        var MODEL_400_TRANSOM_MINIMUM_SIZE = '<%= Session["MODEL_400_TRANSOM_MINIMUM_SIZE"] %>';
        //var MIN_WINDOW_WIDTH = 
        //var MAX_WINDOW_WIDTH = 
        //var MIN_MOD_WIDTH = MIN_WINDOW_WIDTH + 2;
        //var MAX_MOD_WIDTH = MAX_WINDOW_WIDTH + 2;
        var kneewallType = '<%= Session["kneewallType"] %>';
        var kneewallHeight = '<%= Session["kneewallHeight"] %>';
        var transomType = '<%= Session["transomType"] %>';
        var transomHeight = '<%= Session["transomHeight"] %>';
        
        //Mods holds all common information for doors
        function Mods() {
            this.id = null;                 //mod id
            this.typeMod = null;            //Holds: Door, Window
            this.mStartHeight = null;       //start height of the mod
            this.mEndHeight = null;         //end height of the mod
            this.mWidth = null;             //width of the mod
            this.wall = null;               //the wall in belongs in
            this.position = null;           //distance from the left
            this.transomType = null;        //Glass, Vinyl, Solid Wall, Screen
            this.transomStartHeight = null; //start height of transom
            this.transomEndHeight = null;   //end height of transom
            this.kneewallPunch = null;      //location of the kneewall punch, or false if no kneewall
            this.headerPunch = null;        //location of the header punch
        }
    </script>
    <script src="Scripts/DoorSlideFunctions.js"></script>
    <script src="Scripts/WindowSlideFunctions.js"></script>
    <%-- Hidden field populating scripts 
    =================================== --%>
    <script>       
        //Displaying line information passed from custom drawing tool
        console.log('<%= (string)Session["lineInfo"] %>');

        var gable = '<%= Session["isGable"] %>';

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

        var southWalls = new Array(); //array to store all the south facing walls 
        var northWalls = new Array(); //array to store all the north facing walls
        var backWall = "south"; //index of the back wall to determine wall heights
        for (var i = 0; i < lineList.length; i++) { //run through the list of walls
            if (coordList[i][5] == "S") //5 = orientation... if the orientation is south
                southWalls.push({ "y2": coordList[i][3], "number": i, "type": coordList[i][4] }); //populate south walls array.. 4 = wall type
            else if (coordList[i][5] == "N") //5 = orientation... if the orientation is north
                northWalls.push({ "y2": coordList[i][3], "number": i, "type": coordList[i][4] }); //populate north walls array.. 4 = wall type
        }
        for (var i = 0; i < southWalls.length; i++) {
            for (var j = 0; j < northWalls.length; j++) {
                if (southWalls[i].y2 < northWalls[j].y2) 
                    backWall = "south";
                else 
                    backWall = "north";
            }
        }
        var backWallIndex = 0;

        var existingWallCount = 0;
        var proposedWallCount = 0;
        for (var i = 0; i < coordList.length; i++) {
            if (coordList[i][4] === "E")
                existingWallCount++;
            else
                proposedWallCount++
        }               

        var projection = 0; //room projection from the left ... hard coded for testing
        var antiProjection = 0; //room projection from the right ... hard coded for testing
        var roomProjection = 0; //the higher of the two room projections
        var roomWidth; //the width of the room from the far left to the far right
        var soffitLength = '<%= soffitLength %>'//hard coded for testing, will come from the previous pages in the wizard
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
            //$('#MainContent_btnQuestion2').click(determineStartAndEndHeightOfEachWall(gable));
            $('#MainContent_btnQuestion2').click(loadWallData);
            $('#MainContent_btnQuestion4').click(submitData);

            $('#MainContent_txtWall1Length').val('20');
            $('#MainContent_txtWall3Length').val('120');
            $('#MainContent_txtWall4Length').val('50');
            $('#MainContent_txtWall5Length').val('50');
            $('#MainContent_txtWall6Length').val('12');
            $('#MainContent_txtLeftWallHeight').val('60');
            $('#MainContent_txtRightWallHeight').val('60');
            $('#MainContent_txtGablePostHeight').val('12');
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

                    if (proposedWalls == 1) {
                        var hiddenWallStartIndex = document.createElement("input");
                        hiddenWallStartIndex.setAttribute("type", "hidden");
                        hiddenWallStartIndex.setAttribute("name", "wallStartIndex");
                        hiddenWallStartIndex.value = i;
                        hiddenDiv.appendChild(hiddenWallStartIndex);
                    }

                    var wall = walls[i];
                    var hiddenDoorCount = document.createElement("input");
                    hiddenDoorCount.setAttribute("type", "hidden");
                    hiddenDoorCount.setAttribute("name", "wall" + i + "DoorCount");
                    hiddenDoorCount.value = wall.doors.length;                    

                    hiddenDiv.appendChild(hiddenDoorCount);                    

                    for (var doorCount = 0; doorCount < wall.doors.length; doorCount++) {

                        var door = wall.doors[doorCount];

                        //console.log(door["colour"]);

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

                                console.log("wall" + i + "Door" + doorCount + prop[0].toUpperCase() + prop.substr(1) + " \ " + door[prop]);

                                hiddenDiv.appendChild(hiddenDoorProperty);
                            }
                        }
                    }
                }
            }
            var hiddenWallCount = document.createElement("input");
            hiddenWallCount.setAttribute("type", "hidden");
            hiddenWallCount.setAttribute("name", "wallCount");
            hiddenWallCount.value = lineList.length;

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
                        "startHeight": wallStartHeightArray[i - 1],
                        "endHeight": wallEndHeightArray[i - 1],
                        //"doors": [],
                        //"windows": []
                        "mods" : []
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
            var tempAntiProjection = 0;
            var highestProjection = 0; //variable to store the highest projection calculated from the left side of the room
            var lowestProjection = 0; //variable to store the highest projection calculated from the right side of the room
            //var overallProjection;
            for (var i = 0; i < wallSetBackArray.length; i++) { //run through all the setbacks
                if (wallSetBackArray[i]) { //if its not null (it would be null for existing walls
                    tempProjection = +tempProjection + +wallSetBackArray[i]; //add the values to temp variable
                    if (tempProjection > highestProjection) { //determine if the current temp projection is greater than the highest projection calculated
                        highestProjection = tempProjection; // reset the highest projection
                        projection = highestProjection;
                    }
                    if (wallSetBackArray[i] < 0) {
                        //alert(antiProjection);
                        tempAntiProjection = tempAntiProjection + wallSetBackArray[i] * -1;
                        antiProjection = tempAntiProjection;
                    }
                }
            }

            if (antiProjection > projection)
                return antiProjection;
            else 
                return projection;

        }

        /**
        This function is used to calculate the width of the sunroom using the setback formula.
        Once the width is determined it gets stored in the global roomWidth variable.
        */
        function calculateWidth() {
            var tempWidth = 0; //variable to store each setback
            var highestWidth = 0; //variable to store the highest width calculated from the left side of the room
            var width = 0;

            for (var index = 0; index < wallSetBackArray.length; index++) { //run through all the setbacks
                if (wallSetBackArray[index]) { //if its not null (it would be null for existing walls

                    /*
                    WEST        :   ZERO
                    EAST        :   ZERO
                    SOUTH       :   LENGTH
                    NORTH       :   NEGATIVE LENGTH
                    SOUTHEAST   :   (2a^2 = L^2)
                    NORTHEAST   :   (2a^2 = L^2)            
                    SOUTHWEST   :   NEGATIVE (2a^2 = L^2)  
                    NORTHWEST   :   NEGATIVE (2a^2 = L^2) 
                    */

                    //length of the given wall
                    var L = +(document.getElementById("MainContent_txtWall" + (index + 1) + "Length").value);

                    //get the orientation of the given wall
                    switch (coordList[index][5]) { //5 = orientation
                        case "S": //if south
                            width = L;
                            break;
                        case "N": //or north
                            width = -L;
                            break;
                        case "W": //if west
                        case "E": //if east
                            width = 0;
                            break;
                        case "SW": //if southwest
                        case "NW": //or northwest
                            width = -(Math.sqrt((Math.pow(L, 2)) / 2));
                            break;
                        case "SE": //if southeast
                        case "NE": //or northeast
                            width = Math.sqrt((Math.pow(L, 2)) / 2);
                            break;
                    }

                    tempWidth = +tempWidth + width //add the values to temp variable

                    if (tempWidth > highestWidth) { //determine if the current temp projection is greater than the highest projection calculated
                        highestWidth = tempWidth; // reset the highest projection
                    }
                }
            }

            roomWidth = highestWidth;
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
        function determineStartAndEndHeightOfEachWall(gable) {

            if (gable == "True") {

                var proposedCount = 0;

                for (var i = 0; i < coordList.length; i++) {
                    if (coordList[i][4] === "G") {
                        wallStartHeightArray[i] = parseFloat(document.getElementById("hidGableWallHeight").value);
                        wallEndHeightArray[i] = parseFloat(document.getElementById("hidGableWallHeight").value);
                    }
                    else if (coordList[i][4] === "P") {
                        proposedCount++;
                        if (proposedCount == 1) {
                            wallStartHeightArray[i] = parseFloat(document.getElementById("hidLeftWallHeight").value);
                            wallEndHeightArray[i] = parseFloat(document.getElementById("hidLeftWallHeight").value);
                        }
                        else if (proposedCount == 2) {
                            wallStartHeightArray[i] = parseFloat(document.getElementById("hidLeftWallHeight").value);
                            wallEndHeightArray[i] = parseFloat(document.getElementById("hidGableWallHeight").value);
                        }
                        else if (proposedCount == 3) {
                            wallStartHeightArray[i] = parseFloat(document.getElementById("hidGableWallHeight").value);
                            wallEndHeightArray[i] = parseFloat(document.getElementById("hidRightWallHeight").value);
                        }
                        else if (proposedCount == 4) {
                            wallStartHeightArray[i] = parseFloat(document.getElementById("hidRightWallHeight").value);
                            wallEndHeightArray[i] = parseFloat(document.getElementById("hidRightWallHeight").value);
                        }
                    }
                }
            }
            else {
                var m = parseFloat(document.getElementById("MainContent_txtRoofSlope").value);

                if (backWall === "north") { //if back wall is a north facing wall, i.e. is not existing wall 
                    wallStartHeightArray[backWallIndex] = parseFloat(document.getElementById("MainContent_hidBackWallHeight").value);
                    wallEndHeightArray[backWallIndex] = parseFloat(document.getElementById("MainContent_hidBackWallHeight").value);

                    for (var i = (backWallIndex - 1) ; i >= 0; i--) { //0 = index of first wall

                        if (coordList[i][4] === "E") { //existing wall
                            //if (coordList[i][5] === "S") {

                            ///this is assuming that back wall is an existing wall...
                            wallStartHeightArray[i] = parseFloat(document.getElementById("MainContent_hidBackWallHeight").value);
                            wallEndHeightArray[i] = parseFloat(document.getElementById("MainContent_hidBackWallHeight").value);
                            //}
                        }
                        else { //proposed wall

                            wallEndHeightArray[i] = parseFloat(wallStartHeightArray[i + 1]);

                            switch (coordList[i][5]) {
                                case "S": //if south
                                case "N": //or north
                                    wallStartHeightArray[i] = parseFloat(wallEndtHeightArray[i]);
                                    break;
                                case "W": //if west
                                    wallStartHeightArray[i] = parseFloat(wallEndHeightArray[i]) - parseFloat((((wallLengthArray[i] - wallSoffitArray[i]) * m) / RUN).toFixed(2)); //determine rise based on slope and length, and subtract it from start height
                                    break;
                                case "E": //if east
                                    wallStartHeightArray[i] = parseFloat(wallEndHeightArray[i]) + parseFloat((((wallLengthArray[i] - wallSoffitArray[i]) * m) / RUN).toFixed(2)); //determine rise based on slope and length, and add it to start height
                                    break;
                                case "SW": //if southwest
                                case "SE": //or northwest
                                    wallStartHeightArray[i] = parseFloat(wallEndHeightArray[i]) - parseFloat((((wallSetBackArray[i] - wallSoffitArray[i]) * m) / RUN).toFixed(2)); //determine rise based on slope and setback, then subtract it from start height 
                                    break;
                                case "NW": //if southeast
                                case "NE": //or northeast
                                    wallStartHeightArray[i] = parseFloat(wallEndHeightArray[i]) + parseFloat((((wallSetBackArray[i] - wallSoffitArray[i]) * m) / RUN).toFixed(2)); //determine rise based on slope and setback, then add it to start height 
                                    break;
                            }
                        }
                    }
                }
                else if (backWall === "south") { //if backwall is a south facing wall.. i.e. is existing
                    for (var i = 0; i < coordList.length; i++) {
                        if (coordList[i][4] === "E") { //existing wall
                            wallStartHeightArray[i] = parseFloat(document.getElementById("MainContent_hidBackWallHeight").value);
                            wallEndHeightArray[i] = parseFloat(document.getElementById("MainContent_hidBackWallHeight").value);
                        }
                        else { //proposed wall
                            //if (coordList[i][4] === "P") {

                            wallStartHeightArray[i] = parseFloat(wallEndHeightArray[i - 1]);

                            switch (coordList[i][5]) {
                                case "S": //if south
                                case "N": //or north
                                    wallEndHeightArray[i] = parseFloat(wallStartHeightArray[i]);
                                    break;
                                case "W": //if west
                                    wallEndHeightArray[i] = parseFloat(wallStartHeightArray[i]) - parseFloat((((wallLengthArray[i] - wallSoffitArray[i]) * m) / RUN)); //determine rise based on slope and length, and subtract it from start height
                                    break;
                                case "E": //if east
                                    wallEndHeightArray[i] = parseFloat(wallStartHeightArray[i]) + parseFloat((((wallLengthArray[i] - wallSoffitArray[i]) * m) / RUN)); //determine rise based on slope and length, and add it to start height
                                    break;
                                case "SW": //if southwest
                                case "SE": //or northwest
                                    wallEndHeightArray[i] = parseFloat(wallStartHeightArray[i]) - parseFloat((((wallSetBackArray[i] - wallSoffitArray[i]) * m) / RUN)); //determine rise based on slope and setback, then subtract it from start height 
                                    break;
                                case "NW": //if southeast
                                case "NE": //or northeast
                                    wallEndHeightArray[i] = parseFloat(wallStartHeightArray[i]) + parseFloat((((wallSetBackArray[i] - wallSoffitArray[i]) * m) / RUN)); //determine rise based on slope and setback, then add it to start height 
                                    break;
                            }
                        }
                    }
                }
            }
        }

        /**
        This function is used to populate the wallSoffitArray.
            It takes the number of wall on which to start applying the soffit and 
            whether to go forward in the array from that wall, or to go backwards
        @param count - the wall number at which the soffit starts
        @param back - true or false, whether to go backwards or forwards from 'count'
        */
        function populateSoffitArray(count, back) {

            wallSoffitArray[count] = soffitLength;

            do {
                if (wallSoffitArray[count] > Math.abs(wallSetBackArray[count])) { //if the length of the left soffit is greater than the (first) proposed wall length
                    wallSoffitArray[count] = Math.abs(wallSetBackArray[count]); //set the element of left soffit array to length of the proposed wall
                    if (back) {
                        wallSoffitArray[count - 1] = parseFloat(soffitLength) - parseFloat(Math.abs(wallSetBackArray[count])); //subtract the length of the proposed wall from soffit length
                        count--;
                    }
                    else {
                        wallSoffitArray[count + 1] = parseFloat(soffitLength) - parseFloat(Math.abs(wallSetBackArray[count])); //subtract the length of the proposed wall from soffit length
                        count++;
                    }
                }
                else //if the length of the left soffit is the same or less than proposed wall length
                    wallSoffitArray[count] = soffitLength; //set the element of the left soffit array to length of the left soffit

            } while (wallSoffitArray[count] > Math.abs(wallSetBackArray[count])); //continue while the soffit length remaining is greater than next wall's length

        }

        /**
        This function populates the wall soffit array by determining the orientation of each wall 
            and checking to see if the soffit length would affect it or not
        
        This function calls populateSoffitArray with appropriate values, to populate soffit array.
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
            
           
            for (var i = 0; i < coordList.length; i++)
                wallSoffitArray[i] = 0;

            if (backWall === "south") {
                if (projection > antiProjection)
                    populateSoffitArray(existingWallCount, false);
                else if (projection < antiProjection)
                    populateSoffitArray(wallSetBackArray.length - 1, true);
                else { //projection === antiProjection
                    populateSoffitArray(existingWallCount, false);
                    populateSoffitArray(wallSetBackArray.length - 1, true);
                }
            }
        }

        /**
        This function calculates the slope (over 12), based on the given heights
        @return slope over 12
        */
        function calculateSlope(backWallHeight, frontWallHeight) {
            var rise; //m = ((rise * run)/(roomProjection - soffitLength)) slope over 12

            rise = parseFloat(backWallHeight) - parseFloat(frontWallHeight);

            return (((rise * RUN) / (roomProjection - soffitLength)).toFixed(2));  //slope over 12, rounded to 2 decimal places
        }
        
        /**
        This function calculates the rise based on the slope (over 12) and one of the heights
        @return rise (from the slope equation)
        */
        function calculateRise(side) {
            var m;    //m = ((rise * run)/(roomProjection - soffitLength)) slope over 12

            m = +(document.getElementById("MainContent_txt" + side + "RoofSlope").value); //get the slope from the textbox

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
                if (coordList[i - 1][4] === "P" || coordList[i - 1][4] === "G") {
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
                    if (coordList[i - 1][4] === "P" || coordList[i - 1][4] === "G") {
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
                        answer += "Wall " + i + ": " + document.getElementById("hidWall" + i + "Length").value + "<br/>"; //store the values in the answer variable to be displayed
                  
                    }

                }

                //store roomProjection in the roomProjection variable and hidden field
                document.getElementById("MainContent_hidRoomProjection").value = roomProjection = calculateProjection(); 
                document.getElementById("MainContent_hidRoomWidth").value = roomWidth;
                determineSoffitLengthOfEachWall(); //calculate and store soffitlength of each wall

                //Set answer on side pager and enable button
                $('#MainContent_lblWallLengthsAnswer').html(answer);
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
        function checkQuestion2(isGable) {
            //alert("here i am, rock you like a hurricane"); //i'll leave that in there for shenanigans
            //disable 'next slide' button until after validation (this is currently enabled for debugging purposes)
            //document.getElementById('MainContent_btnQuestion1').disabled = false;
            //document.getElementById('MainContent_btnQuestion2').disabled = false;
            //document.getElementById('MainContent_btnQuestion3').disabled = false;

            var isValid = false; //to do valid input or invalid input logic
            var answer = ""; //answer to be displayed on the side panel
            var slope;

            if (isGable == "True") {

                //if user wants to auto calculate the slope
                if (document.getElementById("MainContent_radAutoRoofSlope").checked) {
                    //we have front wall height and back wall height, calculate slope
                    if (!isNaN(document.getElementById("MainContent_txtLeftWallHeight").value) //if the other textbox values are valid
                        && document.getElementById("MainContent_txtLeftWallHeight").value > 0
                        && !isNaN(document.getElementById("MainContent_txtRightWallHeight").value)
                        && document.getElementById("MainContent_txtRightWallHeight").value > 0
                        && !isNaN(document.getElementById("MainContent_txtGablePostHeight").value)
                        && document.getElementById("MainContent_txtGablePostHeight").value > 0) {

                        isValid = true;

                        var gablePostHeight = parseFloat(document.getElementById("MainContent_txtGablePostHeight").value) + parseFloat($("#MainContent_gablePostInchSpecificDDL").val());
                        var frontLeftWallHeight = parseFloat(document.getElementById("MainContent_txtLeftWallHeight").value) + parseFloat($("#MainContent_leftWallInchSpecificDDL").val());
                        var frontRightWallHeight = parseFloat(document.getElementById("MainContent_txtRightWallHeight").value) + parseFloat($("#MainContent_rightWallInchSpecificDDL").val());

                        document.getElementById("MainContent_txtLeftRoofSlope").value = calculateSlope(gablePostHeight, frontLeftWallHeight); //output the slope to the appropriate textbox
                        document.getElementById("MainContent_txtRightRoofSlope").value = calculateSlope(gablePostHeight, frontRightWallHeight); //output the slope to the appropriate textbox
                        
                        //store the values in the appropriate hidden fields
                        document.getElementById("hidLeftWallHeight").value =
                            parseFloat(document.getElementById("MainContent_txtLeftWallHeight").value) + parseFloat($("#MainContent_leftWallInchSpecificDDL").val());
                        document.getElementById("hidRightWallHeight").value =
                            parseFloat(document.getElementById("MainContent_txtRightWallHeight").value) + parseFloat($("#MainContent_rightWallInchSpecificDDL").val());
                        document.getElementById("hidGableWallHeight").value =
                            parseFloat(document.getElementById("MainContent_txtGablePostHeight").value) + parseFloat($("#MainContent_gablePostInchSpecificDDL").val());
                        document.getElementById("hidLeftRoofSlope").value = parseFloat(document.getElementById("MainContent_txtLeftRoofSlope").value);
                        document.getElementById("hidRightRoofSlope").value = parseFloat(document.getElementById("MainContent_txtRightRoofSlope").value);                        

                    }
                }
                    //the user wants to auto calculate front height
                else if (document.getElementById("MainContent_radAutoLeftWallHeight").checked) {
                    //we have back wall height and slope, calculate front wall height
                    if (!isNaN(document.getElementById("MainContent_txtLeftRoofSlope").value)
                        && document.getElementById("MainContent_txtLeftRoofSlope").value > 0
                        && !isNaN(document.getElementById("MainContent_txtGablePostHeight").value)
                        && document.getElementById("MainContent_txtGablePostHeight").value > 0) {

                        var backHeight; //to store calculated frontwall height
                        var newBackHeight; //to store the correctred front wall height
                        var rise; //to store the calculated rise from the slope equation

                        rise = calculateRise("Left"); //calculate and store rise

                        //calculate frontwall height by subtracting rise from the backwall height
                        backHeight = parseFloat(document.getElementById("MainContent_txtGablePostHeight").value) + parseFloat($("#MainContent_gablePostInchSpecificDDL").val()) - parseFloat(rise);

                        //calculate new front wall height with the valid eighth inch decimal
                        newBackHeight = validateDecimal(backHeight);

                        //output the whole number of the new front wall height to the textbox
                        document.getElementById("MainContent_txtLeftWallHeight").value = newBackHeight[0];

                        //select the decimal value of the new front wall height in the dropdown list
                        for (var i = 0; i < document.getElementById("MainContent_leftWallInchSpecificDDL").length - 1 ; i++) { //run through each element of the dropdown
                            if ((newBackHeight[1] += '') == ("0" + document.getElementById("MainContent_leftWallInchSpecificDDL").options[i].value)) //if the value in the dropdown list matches the decimal value
                                document.getElementById("MainContent_leftWallInchSpecificDDL").selectedIndex = i; //select the index of that value
                        }

                        slope = calculateSlope(newBackHeight, backHeight);
                        //check if the old front wall height and the new front wall height are different
                        if (backHeight != (+newBackHeight[0] + +newBackHeight[1])) //if they are different
                            document.getElementById("MainContent_txtLeftRoofSlope").value = slope; //recalculate the slope based on the new front wall height4
                        
                        //if the calculated slope is valid
                        if (slope >= 0)
                            isValid = true;

                        console.log(isValid);

                        //store the values in the appropriate hidden fields
                        document.getElementById("hidLeftWallHeight").value =
                            parseFloat(document.getElementById("MainContent_txtLeftWallHeight").value) + parseFloat($("#MainContent_leftWallInchSpecificDDL").val());
                        document.getElementById("hidRightWallHeight").value =
                            parseFloat(document.getElementById("MainContent_txtRightWallHeight").value) + parseFloat($("#MainContent_rightWallInchSpecificDDL").val());
                        document.getElementById("hidGableWallHeight").value =
                            parseFloat(document.getElementById("MainContent_txtGablePostHeight").value) + parseFloat($("#MainContent_gablePostInchSpecificDDL").val());
                        document.getElementById("hidLeftRoofSlope").value = parseFloat(document.getElementById("MainContent_txtLeftRoofSlope").value);
                        document.getElementById("hidRightRoofSlope").value = parseFloat(document.getElementById("MainContent_txtRightRoofSlope").value);
                    }
                }
                    //the user wants to auto calculate back wall height
                else if (document.getElementById("MainContent_radAutoRightWallHeight").checked) {
                    //we have front wall height and slope, calculate back wall height
                    if (!isNaN(document.getElementById("MainContent_txtRightRoofSlope").value)
                        && document.getElementById("MainContent_txtRightRoofSlope").value > 0
                        && !isNaN(document.getElementById("MainContent_txtGablePostHeight").value)
                        && document.getElementById("MainContent_txtGablePostHeight").value > 0) {

                        var backHeight; //to store calculated backwall height
                        var newBackHeight; //to store corrected back wall height
                        var rise; //to store rise from the slope equation

                        rise = calculateRise("Right"); //calculate and store rise

                        //calculate frontwall height by subtracting rise from the backwall height
                        backHeight = parseFloat(document.getElementById("MainContent_txtGablePostHeight").value) + parseFloat($("#MainContent_gablePostInchSpecificDDL").val()) - parseFloat(rise);

                        //calculate new front wall height with the valid eighth inch decimal
                        newBackHeight = validateDecimal(backHeight);

                        //output the whole number of the new front wall height to the textbox
                        document.getElementById("MainContent_txtRightWallHeight").value = newBackHeight[0];

                        //select the decimal value of the new front wall height in the dropdown list
                        for (var i = 0; i < document.getElementById("MainContent_rightWallInchSpecificDDL").length - 1 ; i++) { //run through each element of the dropdown
                            if ((newBackHeight[1] += '') == ("0" + document.getElementById("MainContent_rightWallInchSpecificDDL").options[i].value)) //if the value in the dropdown list matches the decimal value
                                document.getElementById("MainContent_rightWallInchSpecificDDL").selectedIndex = i; //select the index of that value
                        }

                        slope = calculateSlope(newBackHeight, backHeight);
                        //check if the old front wall height and the new front wall height are different
                        if (backHeight != (+newBackHeight[0] + +newBackHeight[1])) //if they are different
                            document.getElementById("MainContent_txtRightRoofSlope").value = slope; //recalculate the slope based on the new front wall height4

                        //if the calculated slope is valid
                        if (slope >= 0)
                            isValid = true;

                        //store the values in the appropriate hidden fields
                        document.getElementById("hidLeftWallHeight").value =
                            parseFloat(document.getElementById("MainContent_txtLeftWallHeight").value) + parseFloat($("#MainContent_leftWallInchSpecificDDL").val());
                        document.getElementById("hidRightWallHeight").value =
                            parseFloat(document.getElementById("MainContent_txtRightWallHeight").value) + parseFloat($("#MainContent_rightWallInchSpecificDDL").val());
                        document.getElementById("hidGableWallHeight").value =
                            parseFloat(document.getElementById("MainContent_txtGablePostHeight").value) + parseFloat($("#MainContent_gablePostInchSpecificDDL").val());
                        document.getElementById("hidLeftRoofSlope").value = parseFloat(document.getElementById("MainContent_txtLeftRoofSlope").value);
                        document.getElementById("hidRightRoofSlope").value = parseFloat(document.getElementById("MainContent_txtRightRoofSlope").value);

                    }
                }                

                if (isValid) { //if all is valid        

                    //store the values in the answer variable to be displayed on the side panel
                    answer += "Left Wall: " + document.getElementById("hidLeftWallHeight").value + "<br/>";
                    answer += "Right Wall: " + document.getElementById("hidRightWallHeight").value + "<br/>";
                    answer += "Gable Wall: " + document.getElementById("hidGableWallHeight").value + "<br/>";
                    answer += "Left Roof Slope: " + document.getElementById("hidLeftRoofSlope").value + "<br/>";
                    answer += "Right Roof Slope: " + document.getElementById("hidRightRoofSlope").value + "<br/>";

                    //display the answer on the side panel
                    $('#MainContent_lblWallHeightsAnswer').html(answer);
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
            }
            else {
                //if user wants to auto calculate the slope
                if (document.getElementById("MainContent_radAutoRoofSlope").checked) {
                    //we have front wall height and back wall height, calculate slope
                    if (!isNaN(document.getElementById("MainContent_txtBackWallHeight").value) //if the other textbox values are valid
                        && document.getElementById("MainContent_txtBackWallHeight").value > 0
                        && !isNaN(document.getElementById("MainContent_txtFrontWallHeight").value)
                        && document.getElementById("MainContent_txtFrontWallHeight").value > 0) {

                        isValid = true; //valid is true

                        var backWallHeight = parseFloat(document.getElementById("MainContent_txtBackWallHeight").value) + parseFloat($("#MainContent_backWallInchSpecificDDL").val());
                        var frontWallHeight = parseFloat(document.getElementById("MainContent_txtFrontWallHeight").value) + parseFloat($("#MainContent_frontWallInchSpecificDDL").val());

                        document.getElementById("MainContent_txtRoofSlope").value = calculateSlope(backWallHeight, frontWallHeight); //output the slope to the appropriate textbox

                    }
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

                        rise = calculateRise(""); //calculate and store rise

                        //calculate frontwall height by subtracting rise from the backwall height
                        frontHeight = parseFloat(document.getElementById("MainContent_txtBackWallHeight").value) + parseFloat($("#MainContent_backWallInchSpecificDDL").val()) - parseFloat(rise);

                        //calculate new front wall height with the valid eighth inch decimal
                        newFrontHeight = validateDecimal(frontHeight);

                        //output the whole number of the new front wall height to the textbox
                        document.getElementById("MainContent_txtFrontWallHeight").value = newFrontHeight[0];

                        //select the decimal value of the new front wall height in the dropdown list
                        for (var i = 0; i < document.getElementById("MainContent_frontWallInchSpecificDDL").length - 1 ; i++) { //run through each element of the dropdown
                            if ((newFrontHeight[1] += '') == ("0" + document.getElementById("MainContent_frontWallInchSpecificDDL").options[i].value)) //if the value in the dropdown list matches the decimal value
                                document.getElementById("MainContent_frontWallInchSpecificDDL").selectedIndex = i; //select the index of that value
                        }

                        //check if the old front wall height and the new front wall height are different
                        if (frontHeight != (+newFrontHeight[0] + +newFrontHeight[1])) //if they are different
                            document.getElementById("MainContent_txtRoofSlope").value = calculateSlope(); //recalculate the slope based on the new front wall height
                    }
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
                        backHeight = parseFloat(document.getElementById("MainContent_txtFrontWallHeight").value) + parseFloat($("#MainContent_frontWallInchSpecificDDL").val()) + parseFloat(rise);

                        //calculate new back wall height with valid eighth inch decimal
                        newBackHeight = validateDecimal(backHeight);

                        //output the whole number of the new back wall height to the textbox
                        document.getElementById("MainContent_txtBackWallHeight").value = newBackHeight[0];

                        //select the decimal value of the new back wall height in the dropdown list
                        for (var i = 0; i < document.getElementById("MainContent_backWallInchSpecificDDL").length - 1 ; i++) { //run through each element of the dropdown
                            if ((newBackHeight[1] += '') == ("0" + document.getElementById("MainContent_backWallInchSpecificDDL").options[i].value)) //if the value in the dropdown list matches the decimal value
                                document.getElementById("MainContent_backWallInchSpecificDDL").selectedIndex = i; //select the index of that value
                        }

                        //check if the old back wall height and the new back wall height are different
                        if (backHeight != (+newBackHeight[0] + +newBackHeight[1])) //if they are different
                            document.getElementById("MainContent_txtRoofSlope").value = calculateSlope(); //recalculate the slope based on the new back wall height

                    }
                }

                //if the calculated slope is invalid, i.e. negative or zero
                if (document.getElementById("MainContent_txtRoofSlope").value >= 0)
                    isValid = true; //valid is false

                if (isValid) { //if all is valid
                    //store the values in the appropriate hidden fields
                    document.getElementById("MainContent_hidBackWallHeight").value =
                        parseFloat(document.getElementById("MainContent_txtBackWallHeight").value) + parseFloat($("#MainContent_backWallInchSpecificDDL").val());
                    document.getElementById("MainContent_hidFrontWallHeight").value =
                        parseFloat(document.getElementById("MainContent_txtFrontWallHeight").value) + parseFloat($("#MainContent_frontWallInchSpecificDDL").val());
                    document.getElementById("MainContent_hidRoofSlope").value = parseFloat(document.getElementById("MainContent_txtRoofSlope").value);

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
            }
            return isValid;
        }
        
        function sameWallHeight() {

            if ($('#MainContent_chkAutoWalls').prop('checked')) {
                if ($('#MainContent_txtLeftWallHeight').val() == "") {
                    $('#MainContent_txtLeftWallHeight').val($('#MainContent_txtRightWallHeight').val());
                }
                else {
                    $('#MainContent_txtRightWallHeight').val($('#MainContent_txtLeftWallHeight').val());
                }

                $('#MainContent_txtRightWallHeight').attr('disabled', 'disabled');
            }
            else {
                $('#MainContent_txtRightWallHeight').removeAttr('disabled');
            }
        }

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
                <div id="tableWallLengths" class="tblWallLengths" runat="server" >
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
                    
                    <%-- second table for proposed walls, contains input fields for lengths, as well as left and right fillers --%>
                    <asp:Table ID="tblProposedWalls" runat="server">
                        <%--<asp:TableRow>--%>
                            <%-- table headings --%>
                            <%--<asp:TableHeaderCell >
                                Proposed Walls
                            </asp:TableHeaderCell>
                        </asp:TableRow>--%>
                        
                        <asp:TableRow  style="text-align:center">
                            <asp:TableCell></asp:TableCell>
                            <%-- column headings --%>
                            <asp:TableCell ColumnSpan="2">
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
           
                        <div class="tblWallLengths" runat="server" >
                            <ul>
                                <li>
                                    <%-- table contains textboxes, dropdowns, and radio buttons for user input --%>
                                    <asp:Table ID="tblWallHeights" runat="server">

                                       
                                    </asp:Table>
                                    <%-- end of heights table --%>
                                </li>
                            </ul>            
                        </div> <%-- end .toggleContent --%>

                <%-- button to go to the next question --%>
                <asp:Button ID="btnQuestion2" OnClientClick="determineStartAndEndHeightOfEachWall(gable)" Enabled="true" CssClass="btnSubmit float-right slidePanel" data-slide="#slide3" runat="server" Text="Next Question" />

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

        <%--<asp:Label ID="lblErrorMessage" CssClass="lblErrorMessage" runat="server" Text="Label">Oh hello, I am an error message.</asp:Label>--%>
        <textarea id="txtErrorMessage" class="txtErrorMessage" disabled="disabled" rows="5"></textarea>
    </div>
    
<script src="Scripts/MiniCanvasFunctions.js"></script>

    <%-- Hidden input tags 
    ======================= --%>

    <%-- hiddenFieldsDiv is used to store dynamically generated hidden fields from codebehind --%>
    <div id="hiddenFieldsDiv" runat="server"></div>
    <%-- <input id="hidSoffitLength" type="hidden" runat="server" /> --%>
    <input id="hidRoomProjection" type="hidden" runat="server" />
    <input id="hidRoomWidth" type="hidden" runat="server" />

    <%-- end hidden fields --%>    

    <script>
        $(function () {
            $('.ulNavMain').children('a').removeClass('active');
            $('#lnkMainNavNewProject').addClass('active');
        });
    </script>
</asp:Content>

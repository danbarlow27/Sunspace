<%@ Page Title="New Project - Project Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WizardWallsAndMods.aspx.cs" Inherits="SunspaceDealerDesktop.WizardWallsAndMods" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <script src="Scripts/Validation.js"></script>
    <%-- Hidden div populating scripts 
    =================================== --%>
    <script>

        var detailsOfAllLines = '<%= (string)Session["coordList"] %>'; //all the coordinates and details of all the lines
        var lineList = detailsOfAllLines.substr(0, detailsOfAllLines.length - 1).split("/"); //a list of individual lines and their coordinates and details 
        var coordList = new Array(); //new 2d array to store each individual coordinate and details of each line
        for (var i = 0; i < lineList.length; i++) { 
            coordList[i] = lineList[i].split(","); //populate the 2d array
        }
        var wallSetBackArray = new Array();
        var projection = 10; //hard coded to testing
        var DOOR_MAX_WIDTH = '<%= DOOR_MAX_WIDTH %>';
        var DOOR_MIN_WIDTH = '<%= DOOR_MIN_WIDTH %>';
        var DOOR_FRENCH_MIN_WIDTH = '<%= DOOR_FRENCH_MIN_WIDTH %>';
        var DOOR_FRENCH_MAX_WIDTH = '<%= DOOR_FRENCH_MAX_WIDTH %>';
        var projection = 120; //hard coded for testing
        var soffitLength = 0; //hard coded for testing
        var RUN = 12; //a constant for run in calculating the slope, which is always 12 for slope over 12

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

            var L = document.getElementById("MainContent_txtWall" + i + "Length").value;

            switch (coordList[index][5]) { //5 = orientation
                case "S":
                case "N":
                    wallSetBackArray[index] = 0;
                    break;
                case "W":
                    wallSetBackArray[index] = L;
                    break;
                case "E":
                    wallSetBackArray[index] = -L;
                    break;
                case "SW":
                case "NW":
                    wallSetBackArray[index] = Math.sqrt((Math.pow(L, 2)) / 2);
                    break;
                case "SE":
                case "NE":
                    wallSetBackArray[index] = -(Math.sqrt((Math.pow(L, 2)) / 2));
                    break;
            }
        }

        function calculateProjection() {
            var tempProjection = 0;
            var highestSetBack = 0;
            for (var i = 0; i < wallSetBackArray.length; i++) {
                tempProjection = +tempProjection + +wallSetBackArray[i];
                if (tempProjection > highestSetBack) {
                    highestSetBack = tempProjection;
                }
            }
            return highestSetBack;
        }

        //validate decimal to eighth of an inch 
        function validateDecimal(number) {
            var givenDecimal;
            number += ''; //covert to string
            var decimal = number.split(".");
            decimal[1] = "0." + decimal[1];

            givenDecimal = decimal[1];

            var ONE_EIGHTH = 0.125;
            var TWO_EIGHTH = 0.25;
            var THREE_EIGHTH = 0.375;
            var FOUR_EIGHTH = 0.5;
            var FIVE_EIGHTH = 0.625;
            var SIX_EIGHTH = 0.75;
            var SEVEN_EIGHTH = 0.875;
            
            decimal[1] = (decimal[1] >= SEVEN_EIGHTH) ? SEVEN_EIGHTH :
                (decimal[1] >= SIX_EIGHTH) ? SIX_EIGHTH :
                (decimal[1] >= FIVE_EIGHTH) ? FIVE_EIGHTH :
                (decimal[1] >= FOUR_EIGHTH) ? FOUR_EIGHTH :
                (decimal[1] >= THREE_EIGHTH) ? THREE_EIGHTH :
                (decimal[1] >= TWO_EIGHTH) ? TWO_EIGHTH :
                (decimal[1] >= ONE_EIGHTH) ? ONE_EIGHTH : 0;

            return decimal;
        }

        function calculateSlope() {
            var rise; //m = ((rise * run)/(projection - soffitLength)) slope over 12
           
            rise = ((document.getElementById("MainContent_txtBackWallHeight").value //textbox value
                + document.getElementById("MainContent_ddlBackInchFractions").options[document.getElementById("MainContent_ddlBackInchFractions").selectedIndex].value) //dropdown listitem value
                - (document.getElementById("MainContent_txtFrontWallHeight").value //textbox value
                + document.getElementById("MainContent_ddlFrontInchFractions").options[document.getElementById("MainContent_ddlFrontInchFractions").selectedIndex].value)); //dropdown listitem value

            return (((rise * RUN) / (projection - soffitLength)).toFixed(2));  //slope over 12, rounded to 2 decimal places

        }

        function calculateRise() {
            var m;    //m = ((rise * run)/(projection - soffitLength)) slope over 12

            m = document.getElementById("MainContent_txtRoofSlope").value;

            return ((((projection - soffitLength) * m) / RUN).toFixed(2)); //rise, rounded to 2 decimal places
        }

        function checkQuestion1() {
            //disable 'next slide' button until after validation (this is currently enabled for debugging purposes)
            document.getElementById('MainContent_btnQuestion1').disabled = false;
            //document.getElementById('MainContent_btnQuestion2').disabled = false;
            //document.getElementById('MainContent_btnQuestion3').disabled = false;

            //var lengthList = new Array();
            var isValid = true;
            var answer = "";

            for (var i = 1; i <= lineList.length; i++) {
                if (isNaN(document.getElementById("MainContent_txtWall" + (i) + "Length").value)
                    || document.getElementById("MainContent_txtWall" + (i) + "Length").value <= 0 //zero should be changed to MIN_WALL_LENGTH
                    || isNaN(document.getElementById("MainContent_txtWall" + (i) + "LeftFiller").value)
                    || document.getElementById("MainContent_txtWall" + (i) + "LeftFiller").value < 0
                    || isNaN(document.getElementById("MainContent_txtWall" + (i) + "RightFiller").value)
                    || document.getElementById("MainContent_txtWall" + (i) + "RightFiller").value < 0)
                    isValid = false;
            }

            if (isValid) {
                for (var i = 1; i <= lineList.length; i++) { //add up length and filler and populate the hidden fields
                    document.getElementById("hidWall" + i + "SetBack").value = wallSetBackArray[i]; //store wall setback

                    document.getElementById("hidWall" + i + "LeftFiller").value = document.getElementById("MainContent_txtWall" + i + "LeftFiller").value + document.getElementById("MainContent_ddlWall" + i + "LeftInchFractions").options[document.getElementById("MainContent_ddlWall" + i + "LeftInchFractions").selectedIndex].value;
                    document.getElementById("hidWall" + i + "Length").value = document.getElementById("MainContent_txtWall" + i + "Length").value + document.getElementById("MainContent_ddlWall" + i + "InchFractions").options[document.getElementById("MainContent_ddlWall" + i + "InchFractions").selectedIndex].value;
                    document.getElementById("hidWall" + i + "RightFiller").value = document.getElementById("MainContent_txtWall" + i + "RightFiller").value + document.getElementById("MainContent_ddlWall" + i + "RightInchFractions").options[document.getElementById("MainContent_ddlWall" + i + "RightInchFractions").selectedIndex].value;

                    //alert(document.getElementById("hidWall" + i + "Length").value);

                    answer += "Wall " + i + ": " + document.getElementById("hidWall" + i + "Length").value;
                    calculateSetBack((i - 1));
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

        function checkQuestion2() {
            //alert("here i am, rock you like a hurricane");
            //disable 'next slide' button until after validation (this is currently enabled for debugging purposes)
            //document.getElementById('MainContent_btnQuestion1').disabled = false;
            //document.getElementById('MainContent_btnQuestion2').disabled = false;
            //document.getElementById('MainContent_btnQuestion3').disabled = false;

            var isValid = true;
            var answer = "";
            var rise;
            
            if (document.getElementById("MainContent_radAutoRoofSlope").checked) {
                //we have front wall height and back wall height, calculate slope
                if (!isNaN(document.getElementById("MainContent_txtBackWallHeight").value)
                    && document.getElementById("MainContent_txtBackWallHeight").value > 0
                    && !isNaN(document.getElementById("MainContent_txtFrontWallHeight").value)
                    && document.getElementById("MainContent_txtFrontWallHeight").value > 0) {
                    
                    isValid = true;
                    
                    document.getElementById("MainContent_txtRoofSlope").value = calculateSlope(); //output the slope to the appropriate textbox
                }
                else
                    isValid = false;
            }
            else if (document.getElementById("MainContent_radAutoFrontWallHeight").checked) {
                //we have back wall height and slope, calculate front wall height
                if (!isNaN(document.getElementById("MainContent_txtBackWallHeight").value)
                    && document.getElementById("MainContent_txtBackWallHeight").value > 0
                    && !isNaN(document.getElementById("MainContent_txtRoofSlope").value)
                    && document.getElementById("MainContent_txtRoofSlope").value > 0) {

                    var frontHeight;
                    var newFrontHeight;

                    isValid = true;

                    rise = calculateRise();
                    
                    frontHeight = +(document.getElementById("MainContent_txtBackWallHeight").value + document.getElementById("MainContent_ddlBackInchFractions").options[document.getElementById("MainContent_ddlBackInchFractions").selectedIndex].value) - +rise;

                    newFrontHeight = validateDecimal(frontHeight);

                    document.getElementById("MainContent_txtFrontWallHeight").value = newFrontHeight[0];

                    if (frontHeight != (+newFrontHeight[0] + +newFrontHeight[1]))
                        document.getElementById("MainContent_txtRoofSlope").value = calculateSlope();


                    for (var i = 0; i < document.getElementById("MainContent_ddlFrontInchFractions").length - 1 ; i++) {
                        if ((newFrontHeight[1] += '') === ("0" + document.getElementById("MainContent_ddlFrontInchFractions").options[i].value))
                            document.getElementById("MainContent_ddlFrontInchFractions").selectedIndex = i;
                    }
                }
                else
                    isValid = false;
            }
            else if (document.getElementById("MainContent_radAutoBackWallHeight").checked) {
                //we have front wall height and slope, calculate back wall height
                if (!isNaN(document.getElementById("MainContent_txtFrontWallHeight").value)
                    && document.getElementById("MainContent_txtFrontWallHeight").value > 0
                    && !isNaN(document.getElementById("MainContent_txtRoofSlope").value)
                    && document.getElementById("MainContent_txtRoofSlope").value > 0) {

                    var backHeight;
                    var newBackHeight;

                    isValid = true;

                    rise = calculateRise();

                    backHeight = +(document.getElementById("MainContent_txtFrontWallHeight").value + document.getElementById("MainContent_ddlFrontInchFractions").options[document.getElementById("MainContent_ddlFrontInchFractions").selectedIndex].value) + +rise;

                    newBackHeight = validateDecimal(backHeight);

                    if (backHeight != (+newBackHeight[0] + +newBackHeight[1])) 
                        document.getElementById("MainContent_txtRoofSlope").value = calculateSlope();
                    
                    document.getElementById("MainContent_txtBackWallHeight").value = newBackHeight[0];

                    for (var i = 0; i < document.getElementById("MainContent_ddlBackInchFractions").length - 1 ; i++) {
                        if ((newBackHeight[1] += '') === ("0" + document.getElementById("MainContent_ddlBacktInchFractions").options[i].value))
                            document.getElementById("MainContent_ddlBackInchFractions").selectedIndex = i;
                    }
                }
                else
                    isValid = false;
            }

            if (document.getElementById("MainContent_txtBackWallHeight").value <= document.getElementById("MainContent_txtFrontWallHeight").value)
                isValid = false;
            else
                isValid = true;
            
            if (isValid) {
                document.getElementById("MainContent_hidBackWallHeight").value = document.getElementById("MainContent_txtBackWallHeight").value + document.getElementById("MainContent_ddlBackInchFractions").options[document.getElementById("MainContent_ddlBackInchFractions").selectedIndex].value;
                document.getElementById("MainContent_hidFrontWallHeight").value = document.getElementById("MainContent_txtFrontWallHeight").value + document.getElementById("MainContent_ddlFrontInchFractions").options[document.getElementById("MainContent_ddlFrontInchFractions").selectedIndex].value;
                document.getElementById("MainContent_hidRoofSlope").value = document.getElementById("MainContent_txtRoofSlope").value;
                answer += "Back Wall: " + document.getElementById("MainContent_hidBackWallHeight").value;
                answer += "Front Wall: " + document.getElementById("MainContent_hidFrontWallHeight").value;
                answer += "Roof Slope: " + document.getElementById("MainContent_hidRoofSlope").value;

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
        
        function checkQuestion3() {

            for (var wallCount = 1; wallCount < coordList.length; wallCount++) {             

                if (document.getElementById('MainContent_radWall' + wallCount).checked) {                    

                    if (document.getElementById('MainContent_radType' + wallCount + 'Cabana').checked) {

                        var doorTitle = document.getElementById("MainContent_rowDoorTitle" + wallCount + "Cabana");
                        var doorStyle = document.getElementById("MainContent_rowDoorStyle" + wallCount + "Cabana");
                        var doorColor = document.getElementById("MainContent_rowDoorColor" + wallCount + "Cabana");
                        var doorHeight = document.getElementById("MainContent_rowDoorHeight" + wallCount + "Cabana");
                        var doorWidth = document.getElementById("MainContent_rowDoorWidth" + wallCount + "Cabana");

                        var doorCustomHeight = document.getElementById("MainContent_rowDoorCustomHeight" + wallCount + "Cabana");
                        var doorCustomWidth = document.getElementById("MainContent_rowDoorCustomWidth" + wallCount + "Cabana");
                        var doorOperatorLHH = document.getElementById("MainContent_rowOperatorLHH" + wallCount + "Cabana");
                        var doorOperatorRHH = document.getElementById("MainContent_rowOperatorRHH" + wallCount + "Cabana");
                        var doorBoxHeaderLHH = document.getElementById("MainContent_rowDoorBoxHeaderLHH" + wallCount + "Cabana");
                        var doorBoxHeaderRHH = document.getElementById("MainContent_rowDoorBoxHeaderRHH" + wallCount + "Cabana");
                        var doorBoxHeaderBoth = document.getElementById("MainContent_rowDoorBoxHeaderBoth" + wallCount + "Cabana");
                        var doorBoxHeaderNone = document.getElementById("MainContent_rowDoorBoxHeaderNone" + wallCount + "Cabana");
                        var doorNumberOfVents = document.getElementById("MainContent_rowDoorNumberOfVents" + wallCount + "Cabana");
                        var doorGlassTint = document.getElementById("MainContent_rowDoorGlassTint" + wallCount + "Cabana");
                        var doorLHH = document.getElementById("MainContent_rowDoorLHH" + wallCount + "Cabana");
                        var doorRHH = document.getElementById("MainContent_rowDoorRHH" + wallCount + "Cabana");
                        var doorScreenOptions = document.getElementById("MainContent_rowDoorScreenOptions" + wallCount + "Cabana");
                        var doorHardware = document.getElementById("MainContent_rowDoorHardware" + wallCount + "Cabana");
                        var doorVinylTint = document.getElementById("MainContent_rowDoorVinylTint" + wallCount + "Cabana");
                        var doorSwingIn = document.getElementById("MainContent_rowDoorSwingIn" + wallCount + "Cabana");
                        var doorSwingOut = document.getElementById("MainContent_rowDoorSwingOut" + wallCount + "Cabana");
                        var doorPosition = document.getElementById("MainContent_rowDoorPosition" + wallCount + "Cabana");

                        //General
                        doorTitle.style.display = "inherit";
                        doorStyle.style.display = "inherit";
                        doorColor.style.display = "inherit";
                        doorHeight.style.display = "inherit";
                        doorWidth.style.display = "inherit";
                        doorBoxHeaderLHH.style.display = "inherit";
                        doorBoxHeaderRHH.style.display = "inherit";
                        doorBoxHeaderBoth.style.display = "inherit";
                        doorBoxHeaderNone.style.display = "inherit";

                        //Cabana Specific
                        doorGlassTint.style.display = "inherit";
                        doorLHH.style.display = "inherit";
                        doorRHH.style.display = "inherit";
                        doorSwingIn.style.display = "inherit";
                        doorSwingOut.style.display = "inherit";
                        doorHardware.style.display = "inherit";
                        doorNumberOfVents.style.display = "inherit";
                        doorPosition.style.display = "inherit";
                    }
                    else if (document.getElementById('MainContent_radType' + wallCount + 'French').checked) {

                        var doorTitle = document.getElementById("MainContent_rowDoorTitle" + wallCount + "French");
                        var doorStyle = document.getElementById("MainContent_rowDoorStyle" + wallCount + "French");
                        var doorColor = document.getElementById("MainContent_rowDoorColor" + wallCount + "French");
                        var doorHeight = document.getElementById("MainContent_rowDoorHeight" + wallCount + "French");
                        var doorWidth = document.getElementById("MainContent_rowDoorWidth" + wallCount + "French");

                        var doorCustomHeight = document.getElementById("MainContent_rowDoorCustomHeight" + wallCount + "French");
                        var doorCustomWidth = document.getElementById("MainContent_rowDoorCustomWidth" + wallCount + "French");
                        var doorOperatorLHH = document.getElementById("MainContent_rowDoorOperatorLHH" + wallCount+ "French");
                        var doorOperatorRHH = document.getElementById("MainContent_rowDoorOperatorRHH" + wallCount + "French");
                        var doorBoxHeaderLHH = document.getElementById("MainContent_rowDoorBoxHeaderLHH" + wallCount + "French");
                        var doorBoxHeaderRHH = document.getElementById("MainContent_rowDoorBoxHeaderRHH" + wallCount + "French");
                        var doorBoxHeaderBoth = document.getElementById("MainContent_rowDoorBoxHeaderBoth" + wallCount + "French");
                        var doorBoxHeaderNone = document.getElementById("MainContent_rowDoorBoxHeaderNone" + wallCount + "French");
                        var doorNumberOfVents = document.getElementById("MainContent_rowDoorNumberOfVents" + wallCount + "French");
                        var doorGlassTint = document.getElementById("MainContent_rowDoorGlassTint" + wallCount + "French");
                        var doorLHH = document.getElementById("MainContent_rowDoorLHH" + wallCount + "French");
                        var doorRHH = document.getElementById("MainContent_rowDoorRHH" + wallCount + "French");
                        var doorScreenOptions = document.getElementById("MainContent_rowDoorScreenOptions" + wallCount + "French");
                        var doorHardware = document.getElementById("MainContent_rowDoorHardware" + wallCount+ "French");
                        var doorVinylTint = document.getElementById("MainContent_rowDoorVinylTint" + wallCount + "French");
                        var doorSwingIn = document.getElementById("MainContent_rowDoorSwingIn" + wallCount + "French");
                        var doorSwingOut = document.getElementById("MainContent_rowDoorSwingOut" + wallCount + "French");
                        var doorPosition = document.getElementById("MainContent_rowDoorPosition" + wallCount + "French");

                        //General
                        doorTitle.style.display = "inherit";
                        doorStyle.style.display = "inherit";
                        doorColor.style.display = "inherit";
                        doorHeight.style.display = "inherit";
                        doorWidth.style.display = "inherit";
                        doorBoxHeaderLHH.style.display = "inherit";
                        doorBoxHeaderRHH.style.display = "inherit";
                        doorBoxHeaderBoth.style.display = "inherit";
                        doorBoxHeaderNone.style.display = "inherit";

                        //French specific
                        doorOperatorLHH.style.display = "inherit";
                        doorOperatorRHH.style.display = "inherit";
                        doorSwingIn.style.display = "inherit";
                        doorSwingOut.style.display = "inherit";
                        doorHardware.style.display = "inherit";
                        doorNumberOfVents.style.display = "inherit";
                        doorPosition.style.display = "inherit";
                    }
                    else if (document.getElementById('MainContent_radType' + wallCount + 'Patio').checked) {

                        var doorTitle = document.getElementById("MainContent_rowDoorTitle" + wallCount + "Patio");
                        var doorStyle = document.getElementById("MainContent_rowDoorStyle" + wallCount + "Patio");
                        var doorColor = document.getElementById("MainContent_rowDoorColor" + wallCount + "Patio");
                        var doorHeight = document.getElementById("MainContent_rowDoorHeight" + wallCount + "Patio");
                        var doorWidth = document.getElementById("MainContent_rowDoorWidth" + wallCount + "Patio");

                        var doorCustomHeight = document.getElementById("MainContent_rowDoorCustomHeight" + wallCount + "Patio");
                        var doorCustomWidth = document.getElementById("MainContent_rowDoorCustomWidth" + wallCount + "Patio");
                        var doorOperatorLHH = document.getElementById("MainContent_rowDoorOperatorLHH" + wallCount + "Patio");
                        var doorOperatorRHH = document.getElementById("MainContent_rowDoorOperatorRHH" + wallCount + "Patio");
                        var doorBoxHeaderLHH = document.getElementById("MainContent_rowDoorBoxHeaderLHH" + wallCount + "Patio");
                        var doorBoxHeaderRHH = document.getElementById("MainContent_rowDoorBoxHeaderRHH" + wallCount + "Patio");
                        var doorBoxHeaderBoth = document.getElementById("MainContent_rowDoorBoxHeaderBoth" + wallCount + "Patio");
                        var doorBoxHeaderNone = document.getElementById("MainContent_rowDoorBoxHeaderNone" + wallCount + "Patio");
                        var doorNumberOfVents = document.getElementById("MainContent_rowDoorNumberOfVents" + wallCount + "Patio");
                        var doorGlassTint = document.getElementById("MainContent_rowDoorGlassTint" + wallCount + "Patio");
                        var doorLHH = document.getElementById("MainContent_rowDoorLHH" + wallCount + "Patio");
                        var doorRHH = document.getElementById("MainContent_rowDoorRHH" + wallCount + "Patio");
                        var doorScreenOptions = document.getElementById("MainContent_rowDoorScreenOptions" + wallCount + "Patio");
                        var doorHardware = document.getElementById("MainContent_rowDoorHardware" + wallCount + "Patio");
                        var doorVinylTint = document.getElementById("MainContent_rowDoorVinylTint" + wallCount + "Patio");
                        var doorSwingIn = document.getElementById("MainContent_rowDoorSwingIn" + wallCount + "Patio");
                        var doorSwingOut = document.getElementById("MainContent_rowDoorSwingOut" + wallCount + "Patio");
                        var doorPosition = document.getElementById("MainContent_rowDoorPosition" + wallCount + "Patio");

                        //General
                        doorTitle.style.display = "inherit";
                        doorStyle.style.display = "inherit";
                        doorColor.style.display = "inherit";
                        doorHeight.style.display = "inherit";
                        doorWidth.style.display = "inherit";
                        doorBoxHeaderLHH.style.display = "inherit";
                        doorBoxHeaderRHH.style.display = "inherit";
                        doorBoxHeaderBoth.style.display = "inherit";
                        doorBoxHeaderNone.style.display = "inherit";

                        //Patio Specifics
                        doorGlassTint.style.display = "inherit";
                        doorOperatorLHH.style.display = "inherit";
                        doorOperatorRHH.style.display = "inherit";
                        doorNumberOfVents.style.display = "inherit";
                    }
                    else if (document.getElementById('MainContent_radType' + wallCount + 'Opening Only (No Door)').checked) {
                        document.getElementById("div_" + wallCount + "Opening Only (No Door)").className = "";
                        document.getElementById("div_" + wallCount + "Opening Only (No Door)").style.display = "none";
                    }
                }

            }

            

        }

        function customWidth(type) {
            for (var wallCount = 1; wallCount < coordList.length; wallCount++) {

                if (document.getElementById('MainContent_radWall' + wallCount).checked) {

                    var widthDDL = document.getElementById('MainContent_ddlDoorWidth' + wallCount + type).options[document.getElementById('MainContent_ddlDoorWidth' + wallCount + type).selectedIndex].value;

                    if (document.getElementById('MainContent_radType' + wallCount + type).checked && widthDDL === 'cWidth') {
                        document.getElementById('MainContent_rowDoorCustomWidth' + wallCount + type).style.display = 'inherit';
                    }
                    else {
                        document.getElementById('MainContent_rowDoorCustomWidth' + wallCount + type).style.display = 'none';
                    }
                }
            }
        }

        function customHeight(type) {
            for (var wallCount = 1; wallCount < coordList.length; wallCount++) {

                if (document.getElementById('MainContent_radWall' + wallCount).checked) {

                    var HeightDDL = document.getElementById('MainContent_ddlDoorHeight' + wallCount + type).options[document.getElementById('MainContent_ddlDoorHeight' + wallCount + type).selectedIndex].value;

                    if (document.getElementById('MainContent_radType' + wallCount + type).checked && HeightDDL === 'cHeight') {
                        document.getElementById('MainContent_rowDoorCustomHeight' + wallCount + type).style.display = 'inherit';
                    }
                    else {
                        document.getElementById('MainContent_rowDoorCustomHeight' + wallCount + type).style.display = 'none';
                    }
                }
            }
        }

        function doorStyle(type) {
            for (var wallCount = 1; wallCount < coordList.length; wallCount++) {

                if (document.getElementById('MainContent_radWall' + wallCount).checked) {

                    var HeightDDL = document.getElementById('MainContent_ddlDoorStyle' + wallCount + type).options[document.getElementById('MainContent_ddlDoorStyle' + wallCount + type).selectedIndex].value;

                    if (document.getElementById('MainContent_radType' + wallCount + type).checked && HeightDDL === 'v4TCabana') {
                        document.getElementById('MainContent_rowDoorVinylTint' + wallCount + type).style.display = 'inherit';
                    }
                    else {
                        document.getElementById('MainContent_rowDoorVinylTint' + wallCount + type).style.display = 'none';
                    }
                }
            }
        }

        //function onClickAddDoor(currentDoor) {
        //    var $doorDetails = $('#doorDetails');
        //    var $doorDetailsList = $('#doorDetailsList');
        //    var tblDoor = document.getElementById("MainContent_tblDoorDetails" + currentDoor);

        //    alert($doorDetailsList.size());

        //    if (tblDoor.style.display === "block") {
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
                    <asp:Label ID="lblQuestion1" runat="server" Text="Please enter the wall lengths"></asp:Label>
                </h1>        
                              
                <div id="tableWallLengths" class="tblWallLengths" runat="server" style="padding-right:15%; padding-left:15%; padding-top:5%;">
                    <asp:Table ID="tblExistingWalls" runat="server">
                        <asp:TableRow>
                            <asp:TableHeaderCell >
                                Existing Walls
                            </asp:TableHeaderCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell></asp:TableCell>
                            <asp:TableCell ColumnSpan="6" >
                                Length
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <br />
                    <asp:Table ID="tblProposedWalls" runat="server">
                        <asp:TableRow>
                            <asp:TableHeaderCell >
                                Proposed Walls
                            </asp:TableHeaderCell>
                        </asp:TableRow>
                        
                        <asp:TableRow>
                            <asp:TableCell></asp:TableCell>
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
                    
                </div>

                <asp:Button ID="btnQuestion1" Enabled="true" CssClass="btnSubmit float-right slidePanel" data-slide="#slide2" runat="server" Text="Next Question" />

            </div> 
            <%-- end #slide1 --%>

            <%-- QUESTION 2 - Wall Heights
            ======================================== --%>
            <div id="slide2" class="slide">

                <h1>
                    <asp:Label ID="lblQuestion2" runat="server" Text="Please enter the wall heights"></asp:Label>
                </h1>
           
                        <div class="tblWallLengths" runat="server" style="padding-right:15%; padding-left:15%; padding-top:5%;">
                            <ul>
                                <li>
                                    <asp:Table ID="tblWallHeights" CssClass="tblTxtFields" runat="server">

                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblBackWallHeight" AssociatedControlID="txtBackWallHeight" runat="server" Text="Back Wall Height:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:TextBox ID="txtBackWallHeight" CssClass="txtField txtInput" onkeyup="checkQuestion2()" OnChange="checkQuestion2()" onblur="resetWalls()" OnFocus="highlightWallsHeight()" runat="server" MaxLength="3"></asp:TextBox>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:PlaceHolder ID="phBackHeights" runat="server" />
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:RadioButton ID="radAutoBackWallHeight" GroupName="autoPopulate" runat="server" OnClick="checkQuestion2()" />
                                                <asp:Label ID="lblAutoBackWallHeightRadio" AssociatedControlID="radAutoBackWallHeight" runat="server"></asp:Label>
                                                <asp:Label ID="lblAutoBackWallHeight" AssociatedControlID="radAutoBackWallHeight" runat="server" Text="Auto Populate"></asp:Label>
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblFrontWallHeight" AssociatedControlID="txtFrontWallHeight" runat="server" Text="Front Wall Height:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:TextBox ID="txtFrontWallHeight" CssClass="txtField txtInput" onkeyup="checkQuestion2()" OnChange="checkQuestion2()" onblur="resetWalls()" OnFocus="highlightWallsHeight()" runat="server" MaxLength="3"></asp:TextBox>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:PlaceHolder ID="phFrontHeights" runat="server" />
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:RadioButton ID="radAutoFrontWallHeight" GroupName="autoPopulate" runat="server" OnClick="checkQuestion2()" />
                                                <asp:Label ID="lblAutoFrontWallHeightRadio" AssociatedControlID="radAutoFrontWallHeight" runat="server"></asp:Label>
                                                <asp:Label ID="lblAutoFrontWallHeight" AssociatedControlID="radAutoFrontWallHeight" runat="server" Text="Auto Populate"></asp:Label>
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblRoofSlope" AssociatedControlID="txtRoofSlope" runat="server" Text="Roof Slope:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:TextBox ID="txtRoofSlope" CssClass="txtField txtInput" onkeyup="checkQuestion2()" OnChange="checkQuestion2()" runat="server" MaxLength="6"></asp:TextBox>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:Label ID="lblSlopeOver12" runat="server" Text="/ 12"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:RadioButton ID="radAutoRoofSlope" GroupName="autoPopulate" runat="server" OnClick="checkQuestion2()" Checked="true"/>
                                                <asp:Label ID="lblAutoRoofSlopeRadio" AssociatedControlID="radAutoRoofSlope" runat="server"></asp:Label>
                                                <asp:Label ID="lblAutoRoofSlope" AssociatedControlID="radAutoRoofSlope" runat="server" Text="Auto Populate"></asp:Label>
                                            </asp:TableCell>

                                        </asp:TableRow>

                                    </asp:Table>
                                </li>
                            </ul>            
                        </div> <%-- end .toggleContent --%>

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

                <asp:Button ID="btnQuestion3"  Enabled="true" CssClass="btnSubmit float-right slidePanel" data-slide="#slide1" runat="server" Text="Next Question" />

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

                <div style="/*max-width:500px; max-height:500px; min-width:200px; min-height:200px; margin: auto auto;*/ position:inherit; /*padding-top:10%; padding-right:5%;*/ text-align:center; /*position:fixed; */top:0px; right:0px;" id="mySunroom"></div>

                <div style="display: none" id="pagerOne">
                    <li>
                            <a href="#" data-slide="#slide1" class="slidePanel">
                                <asp:Label ID="lblWallLengthsSlidePanel" runat="server" Text="Wall Lengths"></asp:Label>
                                <asp:Label ID="lblWallLengthsAnswer" runat="server" Text="Wall Lengths"></asp:Label>
                            </a>
                    </li>
                </div>

                <div style="display: none" id="pagerTwo">
                    <li>
                            <a href="#" data-slide="#slide2" class="slidePanel">
                                <asp:Label ID="lblWallHeightsSlidePanel" runat="server" Text="Wall Heights"></asp:Label>
                                <asp:Label ID="lblWallHeightsAnswer" runat="server" Text="Wall Heights"></asp:Label>
                            </a>
                    </li>
                </div>

                <div style="display: none" id="pagerThree">
                    <li>
                            <a href="#" data-slide="#slide3" class="slidePanel">
                                <asp:Label ID="lblQuestion3Pager" runat="server" Text="Door"></asp:Label>
                                <asp:Label ID="lblQuestion3PagerAnswer" runat="server" Text="Question 3 Answer"></asp:Label>
                            </a>
                    </li>
                </div>

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

    <%-- MINI CANVAS (HIGHLIGHTS CURRENT WALL)
    ======================================== --%>
    <!--Div tag to hold the canvas/grid-->
    
    <script>
/*CANVAS STUFF**********************************************************************************************/
        //var slideWindow = document.getElementById("paging");
        //slideWindow.appendChild(document.getElementById("mySunroom"));

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

        var lineArray = new Array();

        //draw the canvas with the lines
        for (var i = 0; i < lineList.length; i++) { //draw all the lines with the given attributes
            lineArray[i] = canvas.append("line")
                    .attr("x1", (coordList[i][0] / 5) * 2) //0 = x1
                    .attr("y1", (coordList[i][2] / 5) * 2) //1 = y1
                    .attr("x2", (coordList[i][1] / 5) * 2) //2 = x2
                    .attr("y2", (coordList[i][3] / 5) * 2) //3 = y2
                    .attr("stroke-width", "2");
            //lineArray[i].attr("mouseover", alert("hwllo"));
            
            if(coordList[i][4] === "E") //4 = wall facing
                lineArray[i].attr("stroke", "red");
            else
                lineArray[i].attr("stroke", "black");
        }

        //highlight each individual walls for length question
        function highlightWallsLength() {
            var wallNumber = (document.activeElement.id.substr(19,1)); //parse out the wall number from the id           

            lineArray[wallNumber - 1].attr("stroke", "cyan"); 
            lineArray[wallNumber - 1].attr("stroke-width", "5");
               
        }

        //reset wall colours onblur
        function resetWalls() {
            for (var i = 0; i < lineList.length; i++) {
                lineArray[i].attr("stroke-width", "2");
                if (coordList[i][4] === "E") //4 = wall facing
                    lineArray[i].attr("stroke", "red");
                else
                    lineArray[i].attr("stroke", "black");
            }
            if (document.getElementById("lowestPoint"))
                d3.selectAll("#lowestPoint").remove();
        }

        //highlight back and front walls for height question
        function highlightWallsHeight() {
            var textbox = (document.activeElement.id.substr(15, 1)); //parse out B or F (for back wall or front wall) from the id
            var southWalls = new Array();
            var lowestWall = 0; //arbitrary number
            var lowestIndex;
            var highestWall = 200; //arbitrary number
            var highestIndex;
            var index = -1; //invalid to determine if there is a wall or not
            //var typeOfWall;

            for (var i = 0; i < lineList.length; i++) {
                if (coordList[i][5] == "S") //5 = orientation
                    southWalls.push({ "y2": lineArray[i].attr("y2"), "number": i, "type": coordList[i][4] }); //populate south walls array.. 4 = wall type
            }
            if (textbox === "B")
                index = getBackWall(southWalls);
            else { //if (textbox === "F")
                if (southWalls[southWalls.length - 1].type == "P")
                    index = getFrontWall(southWalls);
            }

            if (index >= 0) { //if valid index
                lineArray[index].attr("stroke", "cyan");
                lineArray[index].attr("stroke-width", "5");
            }
            else { //there is no front wall
                highlightFrontPoint(); //highlight front point
            }
        }

        //determine the back wall index
        function getBackWall(southWalls) {
            var lowestWall = 0; //arbitrary number
            var lowestIndex;
            for (var i = 0; i < southWalls.length; i++) {
                if (southWalls[i].y2 > lowestWall) {
                    lowestWall = southWalls[i].y2;
                    lowestIndex = southWalls[i].number;
                }
            }
            return lowestIndex;
        }

        //determine the front wall index
        function getFrontWall(southWalls) {
            var highestWall = 501; //arbitrary number
            var highestIndex;
            for (var i = 0; i < southWalls.length; i++) {
                if (southWalls[i].y2 < highestWall) {
                    highestWall = southWalls[i].y2;
                    highestIndex = southWalls[i].number;
                }
            }
            return highestIndex;
        }

        //highlight the front point if there is no front wall
        function highlightFrontPoint() {
            var lowestX = 0;
            var lowestY = 0;
            var circle;
            for (var i = 0; i < coordList.length; i++) {
                if (coordList[i][3] > lowestY) { //3 = y2 coordinate
                    lowestY = coordList[i][3]; //3 = y2 coordinate
                    lowestX = coordList[i][1]; //1 = x2 coordinate
                }
            }
            circle = canvas.append("circle")
                           .attr("cx", (lowestX / 5) * 2)
                           .attr("cy", (lowestY / 5) * 2)
                           .attr("r", 5) //radius
                           .style("fill", "cyan")
                           .attr("id", "lowestPoint");
        }

            
/*******************************************************************************************************/
    </script>
    <%-- Hidden input tags 
    ======================= --%>
<%-- %><input id="hidWallLengthsAndHeights" type="hidden" runat="server" /> wall length hidden fields will be created dynamically --%>
    <div id="hiddenFieldsDiv" runat="server"></div>
    <input id="hidProjection" type="hidden" runat="server" />
    <input id="hidFrontWallHeight" type="hidden" runat="server" />
    <input id="hidBackWallHeight" type="hidden" runat="server" />
    <input id="hidRoofSlope" type="hidden" runat="server" />
    <input id="hidDoorType" type="hidden" runat="server" />
    <input id="hidDoorColour" type="hidden" runat="server" />
    <input id="hidDoorHeight" type="hidden" runat="server" />
    <input id="hidSwingingDoor" type="hidden" runat="server" />
    <input id="hidWallDoorPlacement" type="hidden" runat="server" />
    <input id="hidWallDoorPosition" type="hidden" runat="server" />

    <%-- end hidden divs --%>

    

    <script>
        $(function () {
            $('.ulNavMain').children('a').removeClass('active');
            $('#lnkMainNavNewProject').addClass('active');
        });
    </script>
</asp:Content>

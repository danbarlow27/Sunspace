<%@ Page Title="Window Ordering Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WizardWindowOnly.aspx.cs" Inherits="SunspaceDealerDesktop.WizardWindowOnly" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <script src="Scripts/GlobalFunctions.js"></script>
    <script src="Scripts/Validation.js"></script>
    <%-- Hidden field populating scripts 
    =================================== --%>
    <script>       
        
        var currentModel = "M200";
        var vinylCount = 0; //a counter to keep track of how many vinyl windows the user wants to buy
        var glassCount = 0; //a counter to keep track of how many glass windows the user wants to buy
        var ScreenCount = 0; //a counter to keep track of how many screen windows the user wants to buy

        /**
        *Adding onclick events to next question buttons
        */
        $(document).ready(function () {
            $('#MainContent_btnQuestion2').click(loadWallData);
            $('#MainContent_btnSubmit').click(submitData);
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

                                //console.log("wall" + i + "Door" + doorCount + prop[0].toUpperCase() + prop.substr(1) + " \ " + door[prop]);

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
        This function is used to validate the user input for question 1, i.e. wall lengths
        */
        function checkQuestion1() {
            //disable 'next slide' button until after validation (this is currently enabled for debugging purposes)
            document.getElementById('MainContent_btnQuestion1').disabled = false;
            //document.getElementById('MainContent_btnQuestion2').disabled = false;
            //document.getElementById('MainContent_btnQuestion3').disabled = false;


            var isValid;// = true; //to do valid input or invalid input logic
            var answer = ""; //answer, to be displayed on the side panel

            //validate the window type textboxes for numeric and greater than zero
            if (isNaN(document.getElementById("MainContent_txtVinylWindowCount").value) //if invalid numbers
                || document.getElementById("MainContent_txtVinylWindowCount").value < 0  
                || isNaN(document.getElementById("MainContent_txtGlassWindowCount").value)
                || document.getElementById("MainContent_txtGlassWindowCount").value < 0
                || isNaN(document.getElementById("MainContent_txtScreenWindowCount").value)
                || document.getElementById("MainContent_txtScreenWindowCount").value < 0) { 
                isValid = false; //set isvalid to false
                answer = "Please enter a numeric value of 0 or more";
            }
            else {
                if (document.getElementById("MainContent_txtVinylWindowCount").value === 0 //check to make sure that the user has put a value for at least one type of window
                    && document.getElementById("MainContent_txtVinylWindowCount").value === 0
                    && document.getElementById("MainContent_txtVinylWindowCount").value === 0) {
                    isValid = false;
                    answer = "Please enter the number of windows you would like to purchase next to the window types";
                }
                else
                    isValid = true;
            }

            if (isValid) { //if everything is valid
                //Set answer on side pager and enable button
                $('#MainContent_lblWallLengthsAnswer').html(answer);
                document.getElementById('pagerOne').style.display = "inline";
                document.getElementById('MainContent_btnQuestion1').disabled = false;
            }
            else { //not valid
                //error styling or something
                //Set answer on side pager and enable button
                $('#MainContent_lblWallLengthsAnswer').html(answer);
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
            if ($('#MainContent_chkAutoWalls').prop('checked')) {
                {
                    //var theValue = $('#MainContent_txtLeftWallHeight').val();
                    document.getElementById("MainContent_txtRightWallHeight").value = $('#MainContent_txtLeftWallHeight').val();
                }
            }

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
                    document.getElementById("hidBackWallHeight").value =
                        parseFloat($("#MainContent_txtBackWallHeight").val()) + parseFloat($("#MainContent_backWallInchSpecificDDL").val());
                    document.getElementById("hidFrontWallHeight").value =
                        parseFloat(document.getElementById("MainContent_txtFrontWallHeight").value) + parseFloat($("#MainContent_frontWallInchSpecificDDL").val());
                    document.getElementById("hidRoofSlope").value = parseFloat(document.getElementById("MainContent_txtRoofSlope").value);

                    //store the values in the answer variable to be displayed on the side panel
                    answer += "Back Wall: " + document.getElementById("hidBackWallHeight").value;
                    answer += "<br/>Front Wall: " + document.getElementById("hidFrontWallHeight").value;
                    answer += "<br/>Roof Slope: " + document.getElementById("hidRoofSlope").value;

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

            //Cheat the shit out of it
            //Update Constants now that we know frontwall/sidewall Heights
            if (isGable == "True") {
                cabanaMaxHeight = Math.min(parseFloat(document.getElementById("hidLeftWallHeight").value), parseFloat(document.getElementById("hidRightWallHeight").value)) - parseFloat(4.125);
                frenchMaxHeight = Math.min(parseFloat(document.getElementById("hidLeftWallHeight").value), parseFloat(document.getElementById("hidRightWallHeight").value)) - parseFloat(4.125);
                patioMaxHeight = Math.min(parseFloat(document.getElementById("hidLeftWallHeight").value), parseFloat(document.getElementById("hidRightWallHeight").value)) - parseFloat(4.125);
            }
            else{
                cabanaMaxHeight = parseFloat(document.getElementById("hidFrontWallHeight").value) - parseFloat(4.125);
                frenchMaxHeight = parseFloat(document.getElementById("hidFrontWallHeight").value) - parseFloat(4.125);
                patioMaxHeight = parseFloat(document.getElementById("hidFrontWallHeight").value) - parseFloat(4.125);                
            }
            
            checkRoofPanels();

            return isValid;
        }

        function checkQuestion3()
        {
            if (currentModel == "M200")
            {
                for (var i = 0; i < coordList.length; i++)
                {
                    if (coordList[i][4] == "P")
                    {                        
                        // Checks for french doors
                        if ($('#MainContent_ddlDoorStyle' + (i + 1) + 'French').val() == "Vertical Four Track")
                        {
                            if ($('#MainContent_ddlDoorVinylTint' + (i + 1) + 'French').val() == "Mixed")
                            {
                                if ($('#MainContent_ddlDoorNumberOfVents' + (i + 1) + 'French').val() == "2")
                                {
                                    document.getElementById('MainContent_row0Door' + (i + 1) + 'TintFrench').style.display = "inherit";
                                    document.getElementById('MainContent_row1Door' + (i + 1) + 'TintFrench').style.display = "inherit";
                                    document.getElementById('MainContent_row2Door' + (i + 1) + 'TintFrench').style.display = "none";
                                    document.getElementById('MainContent_row3Door' + (i + 1) + 'TintFrench').style.display = "none";
                                }
                                else if ($('#MainContent_ddlDoorNumberOfVents' + (i + 1) + 'French').val() == "3")
                                {
                                    document.getElementById('MainContent_row0Door' + (i + 1) + 'TintFrench').style.display = "inherit";
                                    document.getElementById('MainContent_row1Door' + (i + 1) + 'TintFrench').style.display = "inherit";
                                    document.getElementById('MainContent_row2Door' + (i + 1) + 'TintFrench').style.display = "inherit";
                                    document.getElementById('MainContent_row3Door' + (i + 1) + 'TintFrench').style.display = "none";
                                }
                                else if ($('#MainContent_ddlDoorNumberOfVents' + (i + 1) + 'French').val() == "4")
                                {
                                    document.getElementById('MainContent_row0Door' + (i + 1) + 'TintFrench').style.display = "inherit";
                                    document.getElementById('MainContent_row1Door' + (i + 1) + 'TintFrench').style.display = "inherit";
                                    document.getElementById('MainContent_row2Door' + (i + 1) + 'TintFrench').style.display = "inherit";
                                    document.getElementById('MainContent_row3Door' + (i + 1) + 'TintFrench').style.display = "inherit";
                                }
                            }
                            else
                            {
                                document.getElementById('MainContent_row0Door' + (i + 1) + 'TintFrench').style.display = "none";
                                document.getElementById('MainContent_row1Door' + (i + 1) + 'TintFrench').style.display = "none";
                                document.getElementById('MainContent_row2Door' + (i + 1) + 'TintFrench').style.display = "none";
                                document.getElementById('MainContent_row3Door' + (i + 1) + 'TintFrench').style.display = "none";
                            }
                        }
                        else 
                        {
                            document.getElementById('MainContent_row0Door' + (i + 1) + 'TintFrench').style.display = "none";
                            document.getElementById('MainContent_row1Door' + (i + 1) + 'TintFrench').style.display = "none";
                            document.getElementById('MainContent_row2Door' + (i + 1) + 'TintFrench').style.display = "none";
                            document.getElementById('MainContent_row3Door' + (i + 1) + 'TintFrench').style.display = "none";
                        }


                        // Checks for Cabana Doors
                        if ($('#MainContent_ddlDoorStyle' + (i + 1) + 'Cabana').val() == "Vertical Four Track")
                        {
                            if ($('#MainContent_ddlDoorVinylTint' + (i + 1) + 'Cabana').val() == "Mixed")
                            {
                                if ($('#MainContent_ddlDoorNumberOfVents' + (i + 1) + 'Cabana').val() == "2")
                                {
                                    document.getElementById('MainContent_row0Door' + (i + 1) + 'TintCabana').style.display = "inherit";
                                    document.getElementById('MainContent_row1Door' + (i + 1) + 'TintCabana').style.display = "inherit";
                                    document.getElementById('MainContent_row2Door' + (i + 1) + 'TintCabana').style.display = "none";
                                    document.getElementById('MainContent_row3Door' + (i + 1) + 'TintCabana').style.display = "none";
                                }
                                else if ($('#MainContent_ddlDoorNumberOfVents' + (i + 1) + 'Cabana').val() == "3")
                                {
                                    document.getElementById('MainContent_row0Door' + (i + 1) + 'TintCabana').style.display = "inherit";
                                    document.getElementById('MainContent_row1Door' + (i + 1) + 'TintCabana').style.display = "inherit";
                                    document.getElementById('MainContent_row2Door' + (i + 1) + 'TintCabana').style.display = "inherit";
                                    document.getElementById('MainContent_row3Door' + (i + 1) + 'TintCabana').style.display = "none";
                                }
                                else if ($('#MainContent_ddlDoorNumberOfVents' + (i + 1) + 'Cabana').val() == "4")
                                {
                                    document.getElementById('MainContent_row0Door' + (i + 1) + 'TintCabana').style.display = "inherit";
                                    document.getElementById('MainContent_row1Door' + (i + 1) + 'TintCabana').style.display = "inherit";
                                    document.getElementById('MainContent_row2Door' + (i + 1) + 'TintCabana').style.display = "inherit";
                                    document.getElementById('MainContent_row3Door' + (i + 1) + 'TintCabana').style.display = "inherit";
                                }
                            }
                            else
                            {
                                document.getElementById('MainContent_row0Door' + (i + 1) + 'TintCabana').style.display = "none";
                                document.getElementById('MainContent_row1Door' + (i + 1) + 'TintCabana').style.display = "none";
                                document.getElementById('MainContent_row2Door' + (i + 1) + 'TintCabana').style.display = "none";
                                document.getElementById('MainContent_row3Door' + (i + 1) + 'TintCabana').style.display = "none";
                            }
                        }
                        else 
                        {
                            document.getElementById('MainContent_row0Door' + (i + 1) + 'TintCabana').style.display = "none";
                            document.getElementById('MainContent_row1Door' + (i + 1) + 'TintCabana').style.display = "none";
                            document.getElementById('MainContent_row2Door' + (i + 1) + 'TintCabana').style.display = "none";
                            document.getElementById('MainContent_row3Door' + (i + 1) + 'TintCabana').style.display = "none";
                        }
                    }
                }
            }
        }
        
        
        //loop for each line
        //add to array each usable area ie:
        //40
        //20,20
        //40
        //use usable area function
        //set labels 
        function WindowPreparation() {
            //First we call reset hidden to be sure we don't duplicate entries
            resetHiddens();                       

            var currentLocation=0;
            var modLocation=0;
            var areaPositionCounter=0;
            var wallPositionCounter=0;
            
            var wallAreaArray = new Array();
            for (var i = 0; i < lineList.length; i++) {
                wallAreaArray[i] = new Array();
            }
            
            for (var i=1;i<=lineList.length;i++)
            {
                currentLocation=0;
                modLocation=0;
                areaPositionCounter=0;

                if (coordList[i - 1][4] == "P")
                {
                    if(walls[i].mods.length > 0)
                    {
                        for (var j=0;j<=walls[i].mods.length;j++)
                        {   
                            //console.log("current: " + currentLocation);
                            try
                            {
                                //Try to reference the mod's position, if it fails, there is no mod, so we must have finished them all                              
                                modLocation = parseFloat(walls[i].mods[j].position);
                            }
                            catch (err)
                            {
                                //if caught, that means the last mod has been passed, and we're in the last usable area   
                                //we subtract current location from total length to get last usable area, then remove filler
                                wallAreaArray[wallPositionCounter][areaPositionCounter] = walls[i].length - currentLocation - walls[i].rightFiller;
                                //New current location is equal to ending position of mod (start+width)
                                currentLocation = walls[i].length;

                                if (walls[i].mods[j-1].boxHeader == "Right" || walls[i].mods[j-1].boxHeader == "Both")
                                {
                                    console.log("Final mod has right or both boxheader, decrease area");
                                    wallAreaArray[wallPositionCounter][areaPositionCounter] -= BOXHEADER_LENGTH;
                                }
                                break;
                            }   

                            //if the mod is at the start of the wall, we have no usable area at the start, so increase currentLocation
                            if (walls[i].mods[j].boxHeader == "Left" || walls[i].mods[j].boxHeader == "Both")
                            {
                                if(modLocation == walls[i].leftFiller + BOXHEADER_LENGTH)
                                {
                                    //New current location is equal to ending position of mod (start+width)
                                    currentLocation = walls[i].leftFiller + walls[i].mods[j].mwidth + BOXHEADER_LENGTH;

                                    if (walls[i].mods[j].boxHeader == "Right" || walls[i].mods[j].boxHeader == "Both")
                                    {
                                        console.log("Right or both boxheader, increasing location from " + currentLocation + " to " + (currentLocation+BOXHEADER_LENGTH));
                                        currentLocation += BOXHEADER_LENGTH;
                                    }
                                }
                            }
                            else
                            {
                                if(modLocation == walls[i].leftFiller)
                                {
                                    //New current location is equal to ending position of mod (start+width)
                                    currentLocation = walls[i].leftFiller + walls[i].mods[j].mwidth;

                                    if (walls[i].mods[j].boxHeader == "Right" || walls[i].mods[j].boxHeader == "Both")
                                    {
                                        console.log("Right or both boxheader, increasing location from " + currentLocation + " to " + (currentLocation+BOXHEADER_LENGTH));
                                        currentLocation += BOXHEADER_LENGTH;
                                    }
                                }
                            }
                                
                            //If this is the first mod in the wall, and it's not located at the start, we have a workable area first
                            if(currentLocation == 0)
                            {
                                //Since its from start of wall to first mod, the size of the first usable area is equal to
                                //the position of the first mod in the wall. We then subtract left filler, as its first workable area

                                wallAreaArray[wallPositionCounter][areaPositionCounter] = modLocation - walls[i].leftFiller;
                                
                                //New current location is equal to ending position of mod (start+width)
                                currentLocation = modLocation + parseFloat(walls[i].mods[j].mwidth);

                                if (walls[i].mods[j].boxHeader == "Left" || walls[i].mods[j].boxHeader == "Both")
                                {
                                    console.log("First mod, not left flush, decreasing size of area from " + wallAreaArray[wallPositionCounter][areaPositionCounter] + " to " + (wallAreaArray[wallPositionCounter][areaPositionCounter] - BOXHEADER_LENGTH));
                                    wallAreaArray[wallPositionCounter][areaPositionCounter] -= BOXHEADER_LENGTH;
                                }

                                if (walls[i].mods[j].boxHeader == "Right" || walls[i].mods[j].boxHeader == "Both")
                                {
                                    console.log("Right or both boxheader, increasing location from " + currentLocation + " to " + (currentLocation+BOXHEADER_LENGTH));
                                    currentLocation += BOXHEADER_LENGTH;
                                }
                                
                                areaPositionCounter++;
                            }
                                //it isn't at the start and is not immediately following a left flush door
                            else if (currentLocation > 0 && currentLocation < modLocation)
                            {
                                wallAreaArray[wallPositionCounter][areaPositionCounter] = modLocation - currentLocation;

                                //New current location is equal to ending position of mod (start+width)
                                currentLocation = modLocation + parseFloat(walls[i].mods[j].mwidth);

                                if (walls[i].mods[j].boxHeader == "Left" || walls[i].mods[j].boxHeader == "Both")
                                {
                                    console.log("Left or both boxheader found, decreasing size from " + wallAreaArray[wallPositionCounter][areaPositionCounter] + " to " + (wallAreaArray[wallPositionCounter][areaPositionCounter] - BOXHEADER_LENGTH));
                                    wallAreaArray[wallPositionCounter][areaPositionCounter] -= parseFloat(BOXHEADER_LENGTH * 2);
                                }

                                areaPositionCounter++;
                            }
                        }

                        //if it doesn't get in any other block, the mods are done and this is the last usable area to 
                        //the furthest right, so we'll do what we need
                        if (currentLocation != walls[i].length)
                        {
                            wallAreaArray[wallPositionCounter][areaPositionCounter] = walls[i].length - currentLocation;
                            //console.log(walls[i].mods[j]);
                        }

                        //if last element of array is zero, remove it
                        if (wallAreaArray[wallPositionCounter][wallAreaArray[wallPositionCounter].length-1] == 0)
                        {
                            wallAreaArray[wallPositionCounter].pop();
                        }

                        //THIS IS NOW HANDLED IN CATCH BLOCK ABOVE
                        ////now that we're done the mod loop, we subtract right filler from the final usable area (which will always be there)
                        //wallAreaArray[wallPositionCounter][wallAreaArray[wallPositionCounter].length-1] -= 2;

                        //if (wallAreaArray[wallPositionCounter][wallAreaArray[wallPositionCaddDoorounter].length-1] == 0)
                        //{
                        //    wallAreaArray[wallPositionCounter][wallAreaArray[wallPositionCounter].length-1] = null;
                        //}
                    }
                    else
                    {
                        wallAreaArray[wallPositionCounter][0] = walls[i].length - walls[i].leftFiller - walls[i].rightFiller;
                    }
                    wallPositionCounter++;
                }
            }

            //We have an array of usable area, now we get information about window generation for confirmation
            var additionalRemoves = 0;

            //Gables have been handled oddly on the drawing tool, so we need to reduce the counter of the next loop accordingly
            if(gable == "True")
            {
                //A dealer gable has one additional entry for the gable post itself, so we'll subtract by 1 and it is essentially just proposed walls as if it were not gable
                if (gableType == "Dealer Gable")
                {
                    additionalRemoves = 1;
                }
                else
                {                    
                    additionalRemoves = 1;
                }
            }

            for (var i=0;i<(wallAreaArray.length-existingWallCount-additionalRemoves);i++)
            {
                console.log(wallAreaArray.length + ", " + existingWallCount);
                document.getElementById("MainContent_lblOutputArea" + i).innerHTML = "";
                var html = "";
                //console.log("");

                var MIN_MOD_WIDTH = 0;
                var MAX_MOD_WIDTH =0;

                switch (document.getElementById("<%=hidWindowType.ClientID%>").value) {
                    case "Vinyl":
                        MIN_MOD_WIDTH = <%=VINYL_TRAP_MIN_WIDTH_WARRANTY%>; //We use the trap version because they can have both
                        MAX_MOD_WIDTH = <%=VINYL_TRAP_MAX_WIDTH_WARRANTY%>;
                        break;

                    case "Glass":
                        MIN_MOD_WIDTH = <%=VINYL_TRAP_MIN_WIDTH_WARRANTY%>; //We use the trap version because they can have both
                        MAX_MOD_WIDTH = <%=VINYL_TRAP_MAX_WIDTH_WARRANTY%>;
                        break;

                    case "Vertical 4 Track":
                        MIN_MOD_WIDTH = <%=V4T_4V_MIN_WIDTH_WARRANTY%>; //We use the trap version because they can have both
                        MAX_MOD_WIDTH = <%=V4T_4V_MAX_WIDTH_WARRANTY%>;
                        break;

                    case "Horizontal 4 Track":
                        MIN_MOD_WIDTH = <%=HORIZONTAL_ROLLER_MIN_WIDTH_WARRANTY%>; //We use the trap version because they can have both
                        MAX_MOD_WIDTH = <%=HORIZONTAL_ROLLER_MAX_WIDTH_WARRANTY%>;
                        break;

                    case "Horizontal Roller":
                        MIN_MOD_WIDTH = <%=HORIZONTAL_ROLLER_MIN_WIDTH_WARRANTY%>; //We use the trap version because they can have both
                        MAX_MOD_WIDTH = <%=HORIZONTAL_ROLLER_MAX_WIDTH_WARRANTY%>;
                        break;

                    case "Single Slider":
                        MIN_MOD_WIDTH = <%=SINGLE_SLIDER_MIN_WIDTH_WARRANTY%>; //We use the trap version because they can have both
                        MAX_MOD_WIDTH = <%=SINGLE_SLIDER_MAX_WIDTH_WARRANTY%>;
                        break;

                    case "Double Slider":
                        MIN_MOD_WIDTH = <%=DOUBLE_SLIDER_MIN_WIDTH_WARRANTY%>; //We use the trap version because they can have both
                        MAX_MOD_WIDTH = <%=DOUBLE_SLIDER_MAX_WIDTH_WARRANTY%>;
                        break;

                    case "Screen":
                        MIN_MOD_WIDTH = <%=SCREEN_MIN_WIDTH_WARRANTY%>; //We use the trap version because they can have both
                        MAX_MOD_WIDTH = <%=SCREEN_MAX_WIDTH_WARRANTY%>;
                        break;
                }
                
                for (var j=0;j<wallAreaArray[i].length;j++)
                {
                    var validatedWindow = validateWindowModSize(wallAreaArray[i][j], MIN_MOD_WIDTH, MAX_MOD_WIDTH);

                    //Only display an area if it's more than a 0 area
                    if (validatedWindow[0] >= 0)
                    {
                        document.getElementById("MainContent_lblOutputArea" + i).innerHTML += "Sizes: " + validatedWindow[0] + ", Number of windows: " + validatedWindow[1];

                        if (validatedWindow[2] >0)
                        {
                            if (validatedWindow[1] > 0)
                            {
                                document.getElementById("MainContent_lblOutputArea" + i).innerHTML += ", Remaining filler: " + validatedWindow[2] + " added to window number " + Math.ceil(validatedWindow[1] /2 ) + "<br/>";
                            }
                            else
                            {
                                document.getElementById("MainContent_lblOutputArea" + i).innerHTML += ", Remaining filler: " + validatedWindow[2] + "<br/>";
                            }
                        }
                        else
                        {
                            document.getElementById("MainContent_lblOutputArea" + i).innerHTML += "<br/>";
                        }

                        html = "<input id=\"hidWall" + (i+1+existingWallCount) + "WindowInfo" + "\" type=\"hidden\" name=\"hidWall" + (i+1+existingWallCount) + "WindowInfo" + "\"/>";
                        document.getElementById("MainContent_hiddenFieldsDiv").innerHTML += html;
                        document.getElementById("hidWall" + (i+1+existingWallCount) + "WindowInfo").value += validatedWindow[0] + "," + validatedWindow[1] + "," + validatedWindow[2] + ",";
                    }
                }
            }

            //Now move all other required data into hidden fields.
            for (var i=1;i<=lineList.length;i++)
            {
                if (coordList[i - 1][4] == "P")
                {
                    document.getElementById("hidWall" + i + "StartHeight").value = walls[i].startHeight;
                    document.getElementById("hidWall" + i + "EndHeight").value = walls[i].endHeight;
                    document.getElementById("hidWall" + i + "Orientation").value = coordList[i-1][5];
                    document.getElementById("hidWall" + i + "DoorCount").value = walls[i].mods.length;

                    if(walls[i].mods.length > 0)
                    {                        
                        for (var j=0;j<walls[i].mods.length;j++)
                        {                           
                            if (walls[i].mods[j].type == "Cabana")
                            {                         
                                var html = "";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "boxHeader\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "boxHeader\" >";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "colour\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "colour\" >";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "fheight\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "fheight\" >";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "fwidth\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "fwidth\" >";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "glassTint\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "glassTint\" >";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "hardware\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "hardware\" >";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "height\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "height\" >";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "hinge\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "hinge\" >";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "kickplate\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "kickplate\" >";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "mheight\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "mheight\" >";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "mwidth\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "mwidth\" >";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "numberOfVents\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "numberOfVents\" >";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "position\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "position\" >";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "style\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "style\" >";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "swing\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "swing\" >";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "type\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "type\" >";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "vinylTint\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "vinylTint\" >";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "width\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "width\" >";
                                document.getElementById("MainContent_removableHiddenFieldsDiv").innerHTML += html;
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "boxHeader").value = walls[i].mods[j].boxHeader;
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "colour").value = walls[i].mods[j].colour;
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "fheight").value = walls[i].mods[j].fheight;
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "fwidth").value = walls[i].mods[j].fwidth;
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "glassTint").value = walls[i].mods[j].glassTint;
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "hardware").value = walls[i].mods[j].hardware;
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "height").value = walls[i].mods[j].height;
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "hinge").value = walls[i].mods[j].hinge;
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "kickplate").value = walls[i].mods[j].kickplate;
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "mheight").value = walls[i].mods[j].mheight;
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "mwidth").value = walls[i].mods[j].mwidth;
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "numberOfVents").value = walls[i].mods[j].numberOfVents;
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "position").value = parseFloat(walls[i].mods[j].position[0]) + parseFloat(walls[i].mods[j].position[1]);
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "style").value = walls[i].mods[j].style;
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "swing").value = walls[i].mods[j].swing;
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "type").value = walls[i].mods[j].type;

                                
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "vinylTint").value = walls[i].mods[j].vinylTint;
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "width").value = walls[i].mods[j].width;
                            }
                            else if (walls[i].mods[j].type == "French")
                            {
                                var html = "";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "boxHeader\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "boxHeader\" >";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "colour\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "colour\" >";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "fheight\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "fheight\" >";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "fwidth\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "fwidth\" >";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "glassTint\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "glassTint\" >";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "hardware\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "hardware\" >";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "height\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "height\" >";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "kickplate\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "kickplate\" >";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "mheight\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "mheight\" >";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "mwidth\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "mwidth\" >";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "numberOfVents\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "numberOfVents\" >";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "operator\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "operator\" >";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "position\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "position\" >";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "style\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "style\" >";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "swing\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "swing\" >";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "type\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "type\" >";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "vinylTint\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "vinylTint\" >";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "width\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "width\" >";
                                document.getElementById("MainContent_removableHiddenFieldsDiv").innerHTML += html;
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "boxHeader").value = walls[i].mods[j].boxHeader;
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "colour").value = walls[i].mods[j].colour;
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "fheight").value = walls[i].mods[j].fheight;
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "fwidth").value = walls[i].mods[j].fwidth;
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "glassTint").value = walls[i].mods[j].glassTint;
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "hardware").value = walls[i].mods[j].hardware;
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "height").value = walls[i].mods[j].height;
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "kickplate").value = walls[i].mods[j].kickplate;
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "mheight").value = walls[i].mods[j].mheight;
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "mwidth").value = walls[i].mods[j].mwidth;
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "numberOfVents").value = walls[i].mods[j].numberOfVents;
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "operator").value = walls[i].mods[j].operator;
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "position").value = walls[i].mods[j].position;
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "style").value = walls[i].mods[j].style;
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "swing").value = walls[i].mods[j].swing;
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "type").value = walls[i].mods[j].type;

                                // need if logic here for mixed tint
                                
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "vinylTint").value = walls[i].mods[j].vinylTint;
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "width").value = walls[i].mods[j].width;
                            }
                            else if (walls[i].mods[j].type == "Patio")
                            {
                                var html = "";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "boxHeader\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "boxHeader\" >";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "colour\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "colour\" >";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "fheight\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "fheight\" >";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "fwidth\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "fwidth\" >";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "glassTint\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "glassTint\" >";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "height\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "height\" >";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "mheight\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "mheight\" >";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "mwidth\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "mwidth\" >";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "operator\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "operator\" >";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "position\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "position\" >";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "style\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "style\" >";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "type\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "type\" >";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "width\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "width\" >";
                                document.getElementById("MainContent_removableHiddenFieldsDiv").innerHTML += html;
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "boxHeader").value = walls[i].mods[j].boxHeader;
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "colour").value = walls[i].mods[j].colour;
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "fheight").value = walls[i].mods[j].fheight;
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "fwidth").value = walls[i].mods[j].fwidth;
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "glassTint").value = walls[i].mods[j].glassTint;
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "height").value = walls[i].mods[j].height;
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "mheight").value = walls[i].mods[j].mheight;
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "mwidth").value = walls[i].mods[j].mwidth;
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "operator").value = walls[i].mods[j].operator;
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "position").value = walls[i].mods[j].position;
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "style").value = walls[i].mods[j].style;
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "type").value = walls[i].mods[j].type;
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "width").value = walls[i].mods[j].width;
                            }
                            else //NoDoor
                            {
                                var html = "";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "fheight\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "fheight\" >";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "fwidth\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "fwidth\" >";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "height\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "height\" >";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "mheight\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "mheight\" >";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "mwidth\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "mwidth\" >";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "position\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "position\" >";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "type\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "type\" >";
                                html += "<input id=\"hidWall" + i + "Door" + (j+1) + "width\" type=\"hidden\" name=\"hidWall" + i + "Door" + (j+1) + "width\" >";
                                document.getElementById("MainContent_removableHiddenFieldsDiv").innerHTML += html;
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "fheight").value = walls[i].mods[j].fheight;
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "fwidth").value = walls[i].mods[j].fwidth;
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "height").value = walls[i].mods[j].height;
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "mheight").value = walls[i].mods[j].mheight;
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "mwidth").value = walls[i].mods[j].mwidth;
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "position").value = walls[i].mods[j].position;
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "type").value = walls[i].mods[j].type;
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "width").value = walls[i].mods[j].width;
                            }
                        }
                    }
                }
            }

            
            
            ////check the usable area array in console
            //for (var i=0;i<wallAreaArray.length-existingWallCount;i++)
            //{
            //    console.log("Proposed " + (i+1) + ":");
            //    for (var j=0;j<wallAreaArray[i].length;j++)
            //    {
            //        console.log(wallAreaArray[i][j]);
            //    }
            //}
            //Now move blank values to empty hidden fields
            sunshadeToggle();
            valanceChange();
            fabricChange();
            openChange();
            chainChange();
        }

        function resetHiddens()
        {
            $('#MainContent_removableHiddenFieldsDiv').empty();//Then we move values to hidden fields
            //document.getElementById("hidWindowType");
            //document.getElementById("hidWindowColour");
            if (currentModel == "M100")
            {
                document.getElementById("<%=hidWindowType.ClientID%>").value = "Screen";
            }
            else if ($('#MainContent_radV4T').is(':checked')) 
            {
                //move v4t
                document.getElementById("<%=hidWindowType.ClientID%>").value = "Vertical 4 Track";

                //check colours
                if ($('#MainContent_radV4TClear').is(':checked'))
                {
                    document.getElementById("<%=hidWindowColour.ClientID%>").value = "CCCC";
                }
                if ($('#MainContent_radV4TSmokeGrey').is(':checked'))
                {
                    document.getElementById("<%=hidWindowColour.ClientID%>").value = "SSSS";
                }
                if ($('#MainContent_radV4TDarkGrey').is(':checked'))
                {
                    document.getElementById("<%=hidWindowColour.ClientID%>").value = "DDDD";
                }
                if ($('#MainContent_radV4TBronze').is(':checked'))
                {
                    document.getElementById("<%=hidWindowColour.ClientID%>").value = "BBBB";
                }
                if ($('#MainContent_radV4TMixed').is(':checked'))
                {
                    document.getElementById("<%=hidWindowColour.ClientID%>").value = "";
                    document.getElementById("<%=hidWindowColour.ClientID%>").value += document.getElementById("MainContent_ddlV4TVinylTint1").value;
                    document.getElementById("<%=hidWindowColour.ClientID%>").value += document.getElementById("MainContent_ddlV4TVinylTint2").value;
                    document.getElementById("<%=hidWindowColour.ClientID%>").value += document.getElementById("MainContent_ddlV4TVinylTint3").value;
                    document.getElementById("<%=hidWindowColour.ClientID%>").value += document.getElementById("MainContent_ddlV4TVinylTint4").value;
                }
            }
            else if ($('#MainContent_radHorizontalRoller').is(':checked')) 
            {                
                //move v4t
                document.getElementById("<%=hidWindowType.ClientID%>").value = "Horizontal Roller";

                //check colours
                if ($('#MainContent_radHorizontalRollerClear').is(':checked'))
                {
                    document.getElementById("<%=hidWindowColour.ClientID%>").value = "Clear";
                }
                if ($('#MainContent_radHorizontalRollerSmokeGrey').is(':checked'))
                {
                    document.getElementById("<%=hidWindowColour.ClientID%>").value = "Smoke Grey";
                }
                if ($('#MainContent_radHorizontalRollerDarkGrey').is(':checked'))
                {
                    document.getElementById("<%=hidWindowColour.ClientID%>").value = "Dark Grey";
                }
                if ($('#MainContent_radHorizontalRollerBronze').is(':checked'))
                {
                    document.getElementById("<%=hidWindowColour.ClientID%>").value = "Bronze";
                }
            }
            else if ($('#MainContent_radFixedVinyl').is(':checked')) 
            {
                //move v4t
                document.getElementById("<%=hidWindowType.ClientID%>").value = "Fixed Vinyl";
                //check colours
                if ($('#MainContent_radFixedVinylClear').is(':checked'))
                {
                    document.getElementById("<%=hidWindowColour.ClientID%>").value = "Clear";
                }
                if ($('#MainContent_radFixedVinylSmokeGrey').is(':checked'))
                {
                    document.getElementById("<%=hidWindowColour.ClientID%>").value = "Smoke Grey";
                }
                if ($('#MainContent_radFixedVinylDarkGrey').is(':checked'))
                {
                    document.getElementById("<%=hidWindowColour.ClientID%>").value = "Dark Grey";
                }
                if ($('#MainContent_radFixedVinylBronze').is(':checked'))
                {
                    document.getElementById("<%=hidWindowColour.ClientID%>").value = "Bronze";
                }
            }
            else if ($('#MainContent_radOpenWall').is(':checked')) 
            {
                document.getElementById("<%=hidWindowType.ClientID%>").value = "Open Wall";
            }
            else if ($('#MainContent_radSolidWall').is(':checked')) 
            {
                document.getElementById("<%=hidWindowType.ClientID%>").value = "Solid Wall";
            }
            else if ($('#MainContent_radSingleSlider').is(':checked')) 
            {
                //move v4t
                document.getElementById("<%=hidWindowType.ClientID%>").value = "Single Slider";
                //check colours
                if ($('#MainContent_radSingleSliderClear').is(':checked'))
                {
                    document.getElementById("<%=hidWindowColour.ClientID%>").value = "Clear";
                }
                if ($('#MainContent_radSingleSliderGrey').is(':checked'))
                {
                    document.getElementById("<%=hidWindowColour.ClientID%>").value = "Grey";
                }
                if ($('#MainContent_radSingleSliderBronze').is(':checked'))
                {
                    document.getElementById("<%=hidWindowColour.ClientID%>").value = "Bronze";
                }
            }
            else if ($('#MainContent_radDoubleSlider').is(':checked')) 
            {
                //move v4t
                document.getElementById("<%=hidWindowType.ClientID%>").value = "Horizontal 2 Track";
                //check colours
                if ($('#MainContent_radDoubleSliderClear').is(':checked'))
                {
                    document.getElementById("<%=hidWindowColour.ClientID%>").value = "Clear";
                }
                if ($('#MainContent_radDoubleSliderGrey').is(':checked'))
                {
                    document.getElementById("<%=hidWindowColour.ClientID%>").value = "Grey";
                }
                if ($('#MainContent_radDoubleSliderBronze').is(':checked'))
                {
                    document.getElementById("<%=hidWindowColour.ClientID%>").value = "Bronze";
                }
            }
            else if ($('#MainContent_radFixedGlass').is(':checked')) 
            {
                //move v4t
                if (currentModel == "M400")
                {
                    document.getElementById("<%=hidWindowType.ClientID%>").value = "Fixed Glass 3\"";
                }
                else
                {
                    document.getElementById("<%=hidWindowType.ClientID%>").value = "Fixed Glass 2\"";
                }

                //check colours
                if ($('#MainContent_radFixedGlassClear').is(':checked'))
                {
                    document.getElementById("<%=hidWindowColour.ClientID%>").value = "Clear";
                }
                if ($('#MainContent_radFixedGlassGrey').is(':checked'))
                {
                    document.getElementById("<%=hidWindowColour.ClientID%>").value = "Grey";
                }
                if ($('#MainContent_radFixedGlassBronze').is(':checked'))
                {
                    document.getElementById("<%=hidWindowColour.ClientID%>").value = "Bronze";
                }
            }

            //check colours
    if ($('#MainContent_radBetterVueInsectScreen').is(':checked'))
    {
        document.getElementById("<%=hidScreenType.ClientID%>").value = "BetterVueInsectScreen";
            }
            if ($('#MainContent_radNoSeeUms20x20Mesh').is(':checked'))
            {
                document.getElementById("<%=hidScreenType.ClientID%>").value = "NoSeeUms2020Mesh";
            }
            if ($('#MainContent_radSolarInsectScreening').is(':checked'))
            {
                document.getElementById("<%=hidScreenType.ClientID%>").value = "SolarInsectScreening";
            }
            if ($('#MainContent_radToughScreen').is(':checked'))
            {
                document.getElementById("<%=hidScreenType.ClientID%>").value = "TuffScreen";
            }
            if ($('#MainContent_radNoScreen').is(':checked'))
            {
                document.getElementById("<%=hidScreenType.ClientID%>").value = "NoScreen";
            }

            if ($('#MainContent_radFrameBronze').is(':checked'))
            {
                document.getElementById("<%=hidWindowFramingColour.ClientID%>").value = "Bronze";
            }
            else if ($('#MainContent_radFrameWhite').is(':checked'))
            {
                document.getElementById("<%=hidWindowFramingColour.ClientID%>").value = "White";
            }
            else if ($('#MainContent_radFrameDriftwood').is(':checked'))
            {
                document.getElementById("<%=hidWindowFramingColour.ClientID%>").value = "Driftwood";
            }
            else if ($('#MainContent_radFrameGrey').is(':checked'))
            {
                document.getElementById("<%=hidWindowFramingColour.ClientID%>").value = "Grey";
            }
            else if ($('#MainContent_radFrameGreen').is(':checked'))
            {
                document.getElementById("<%=hidWindowFramingColour.ClientID%>").value = "Green";
            }
            else if ($('#MainContent_radFrameIvory').is(':checked'))
            {
                document.getElementById("<%=hidWindowFramingColour.ClientID%>").value = "Ivory";
            }
            else if ($('#MainContent_radFrameCherrywood').is(':checked'))
            {
                document.getElementById("<%=hidWindowFramingColour.ClientID%>").value = "Cherrywood";
            }
            else if ($('#MainContent_radFrameBlack').is(':checked'))
            {
                document.getElementById("<%=hidWindowFramingColour.ClientID%>").value = "Black";//
            }

            ////check the usable area array in console
            //for (var i=0;i<wallAreaArray.length-existingWallCount;i++)
            //{
            //    console.log("Proposed " + (i+1) + ":");
            //    for (var j=0;j<wallAreaArray[i].length;j++)
            //    {
            //        console.log(wallAreaArray[i][j]);
            //    }
            //}
}

function sunshadeToggle()
{
    if ($('#MainContent_chkSunshade').is(':checked'))
    {
        document.getElementById('valanceRow').style.display = "table-row";
        document.getElementById('fabricRow').style.display = "table-row";
        document.getElementById('openRow').style.display = "table-row";
        document.getElementById('chainRow').style.display = "table-row";

        document.getElementById("<%=hidSunshade.ClientID%>").value = "true";
                document.getElementById("<%=hidValance.ClientID%>").value = $('#MainContent_ddlValance').val();
                document.getElementById("<%=hidFabric.ClientID%>").value = $('#MainContent_ddlFabric').val();
                document.getElementById("<%=hidOpenness.ClientID%>").value = $('#MainContent_ddlOpen').val();
                document.getElementById("<%=hidChain.ClientID%>").value = $('#MainContent_ddlChain').val();
            }
            else
            {
                document.getElementById('valanceRow').style.display = "none";
                document.getElementById('fabricRow').style.display = "none";
                document.getElementById('openRow').style.display = "none";
                document.getElementById('chainRow').style.display = "none";

                document.getElementById("<%=hidSunshade.ClientID%>").value = "false";
                document.getElementById("<%=hidValance.ClientID%>").value = "";
                document.getElementById("<%=hidFabric.ClientID%>").value = "";
                document.getElementById("<%=hidOpenness.ClientID%>").value = "";
                document.getElementById("<%=hidChain.ClientID%>").value = "";
            }
        }

        function valanceChange()
        {
            document.getElementById("<%=hidValance.ClientID%>").value = $('#MainContent_ddlValance').val();
        }

        function fabricChange()
        {
            document.getElementById("<%=hidFabric.ClientID%>").value = $('#MainContent_ddlFabric').val();
        }

        function openChange()
        {
            document.getElementById("<%=hidOpenness.ClientID%>").value = $('#MainContent_ddlOpen').val();
        }

        function chainChange()
        {
            document.getElementById("<%=hidChain.ClientID%>").value = $('#MainContent_ddlChain').val();
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
                    <asp:Label ID="lblQuestion1" runat="server" Text="Please enter the number of windows you would like to purchase"></asp:Label>
                </h1>        
                              
                <%-- div to store and organize the tables for textboxes and dropdowns for each wall length 
                    number of rows in the 2 tables below are added dynamically in the codebehind--%>
                <div id="divWindowTypesTable" class="tblWallLengths" runat="server" >
                    <%-- table for for asking the user how many of each type of window the user wants to purchase --%>
                    <asp:Table ID="tblExistingWalls" runat="server">
                        <asp:TableRow>
                            <%-- column headings --%>
                           <asp:TableHeaderCell>
                                Window Types
                            </asp:TableHeaderCell>
                            <asp:TableHeaderCell >
                                Number of Windows
                            </asp:TableHeaderCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <%-- vinyl windows --%>
                            <asp:TableCell>
                                Vinyl Windows
                            </asp:TableCell>
                             <asp:TableCell>
                                <%-- textbox for user input or dropdown --%>
                                <asp:TextBox ID="txtVinylWindowCount" MaxLength="2" Text="0" OnChange="checkQuestion1()" ToolTip="Enter the number of vinyl windows you would like to purchase" runat="server" ></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <%-- glass windows --%>
                            <asp:TableCell>
                                Glass Windows
                            </asp:TableCell>
                            <asp:TableCell>
                                <%-- textbox for user input or dropdown --%>
                                <asp:TextBox ID="txtGlassWindowCount" MaxLength="2" Text="0" OnChange="checkQuestion1()"  ToolTip="Enter the number of vinyl windows you would like to purchase" runat="server" ></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <%-- screen windows --%>
                            <asp:TableCell>
                                Screen Window
                            </asp:TableCell>
                            <asp:TableCell>
                                <%-- textbox for user input or dropdown --%>
                                <asp:TextBox ID="txtScreenWindowCount" MaxLength="2" Text="0" OnChange="checkQuestion1()"  ToolTip="Enter the number of vinyl windows you would like to purchase" runat="server" ></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <%-- end of existing walls table --%>
                    
                    
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
           
                        <div id="Div1" class="tblWallLengths" runat="server" >
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

                <asp:Button ID="btnQuestion3" Enabled="true" CssClass="btnSubmit float-right slidePanel" data-slide="#slide4" runat="server" Text="Next Question"/>

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
                    <asp:PlaceHolder ID="plcFrameOptions" runat="server"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="plcScreenOptions" runat="server"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="plcSunshade" runat="server"></asp:PlaceHolder>           
                </ul>  
                 
                <asp:Button ID="btnQuestion4" CssClass="btnSubmit float-right slidePanel" data-slide="#slide5" runat="server" Text="Next Question" OnClientClick="WindowPreparation();return false;"/>     
            </div>
            <%-- end #slide4 --%>


            <%-- QUESTION 5 - WALL PREVIEW PAGE
            ======================================== --%>
            <div id="slide5" class="slide">
                <h1>
                    <asp:Label ID="lblWallPreview" runat="server" Text="Wall Preview:"></asp:Label>
                </h1>        
                              
                <ul class="toggleOptions">
                    <asp:PlaceHolder ID="wallPreviewPlaceholder" runat="server"></asp:PlaceHolder>                   
                </ul> 

                <asp:Button ID="btnSubmit" Enabled="true" CssClass="btnSubmit float-right slidePanel" runat="server" Text="Submit"  />

            </div>
            <%-- end #slide5 --%>

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
                            <asp:Label ID="Label1" runat="server" Text="Wall and Door Details"></asp:Label>
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

                   <div style="display: none" id="pagerFive">
                        <li>
                                <a href="#" data-slide="#slide5" class="slidePanel">
                                    <asp:Label ID="Label31" runat="server" Text="Foam protection"></asp:Label>
                                    <asp:Label ID="lblQuestion5PagerAnswer" runat="server" Text="Question 5 Answer"></asp:Label>
                                </a>
                        </li>          
                    </div>    
                  
                    <%-- <div style="display: none" id="pagerSix">
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
        <textarea id="txtErrorMessage" class="txtErrorMessage" disabled="disabled" rows="5" runat="server"></textarea>
    </div>
   

    <%-- Hidden input tags 
    ======================= --%>

    <%-- hiddenFieldsDiv is used to store dynamically generated hidden fields from codebehind --%>
    <div id="hiddenFieldsDiv" runat="server"></div>
    <div id="removableHiddenFieldsDiv" runat="server"></div>
    
    <%-- <input id="hidSoffitLength" type="hidden" runat="server" /> --%>
    <input id="hidWindowType" type="hidden" runat="server" />
    <input id="hidWindowColour" type="hidden" runat="server" />
    <input id="hidWindowFramingColour" type="hidden" runat="server" />
    <input id="hidScreenType" type="hidden" runat="server" value="" />
    <input id="hidSunshade" type="hidden" runat="server" value=""/>
    <input id="hidValance" type="hidden" runat="server" value="" />
    <input id="hidFabric" type="hidden" runat="server" value="" />
    <input id="hidOpenness" type="hidden" runat="server" value="" />
    <input id="hidChain" type="hidden" runat="server" value="" />

    <%-- end hidden fields --%>    

    <script>
        $(function () {
            $('.ulNavMain').children('a').removeClass('active');
            $('#lnkMainNavNewProject').addClass('active');
        });
    </script>
</asp:Content>

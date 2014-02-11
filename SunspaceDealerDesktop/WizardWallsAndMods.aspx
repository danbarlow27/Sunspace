<%@ Page Title="New Project - Project Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WizardWallsAndMods.aspx.cs" Inherits="SunspaceDealerDesktop.WizardWallsAndMods" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <script src="Scripts/GlobalFunctions.js"></script>
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
        var BOXHEADER_LENGTH = <%= BOXHEADER_LENGTH %>;
        var BOXHEADER_RECEIVER_LENGTH = <%= BOXHEADER_RECEIVER_LENGTH %>;
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

        /**
*createDoorObject
*This function creates a door object by loading values from fields within the table
*on the page
*@param wallNumber - used to hold the current wall number
*@param type - used to hold the type of door being made
*@return framedDoor - returns an object containing all information for the specific door (i.e. height, width, style, type, etc.)
*
***************RADIO BUTTON VALUES NOT STORING PROPERLY, TO BE FIXED***************
*/
        function createDoorObject(wallNumber, type) {
            //Object variable to hold the current door being built
            var framedDoor;

            //Switch case to instantiate, object variable to the appropriate type
            switch (type) {
                case "Cabana":
                    framedDoor = new CabanaDoor();
                    break;
                case "French":
                    framedDoor = new FrenchDoor();
                    break;
                case "Patio":
                    framedDoor = new PatioDoor();
                    break;
                case "NoDoor":
                    framedDoor = new OpenSpaceDoor();
                    break;
                default:
                    return;
            }

            //Array to get all field values by name
            var controlsArray = [
                "ddlDoorStyle",
                "ddlDoorVinylTint",
                "ddlDoorNumberOfVents",
                "ddlDoorKickplate",
                "ddlDoorColour",
                "ddlDoorHeight",
                "ddlDoorWidth",
                "radDoorOperator",
                "ddlDoorBoxHeader",
                "ddlDoorGlassTint",
                "radDoorHinge",
                "ddlDoorScreenOptions",
                "ddlDoorHardware",
                "radDoorSwing",
                "ddlDoorPosition",
            ];

            //Array to get custom field values
            var customControls = [
                "Kickplate",
                "Height",
                "Width",
                "Position"
            ];

            //Loop to find all visible controls on the slide and get the appropriate controls value
            for (var i = 0; i < controlsArray.length; i++) {
                var styleDropDown = $("#MainContent_" + controlsArray[i] + wallNumber + type);

                //If the controls parent 'tr' is visible, perform block
                if (styleDropDown.closest('tr').filter(':visible').length == 1) {
                    var value;

                    //If the control is of type radio, perform block
                    if (styleDropDown.attr('type') == 'radio') {
                        //Get the checked value
                        value = styleDropDown.closest('table').find('input[name=\"' + styleDropDown.attr('name') + '\"]:checked').val();
                    }
                        //Else, perform block
                    else {
                        //Get control value
                        value = styleDropDown.val();
                    }            

                    //Create identifier for property within door object. In example, 
                    //"ddlDoorStyle" now becomes "style" property inside of framedDoor
                    var identifier = controlsArray[i][7].toLowerCase() + controlsArray[i].substr(8);

                    if (identifier in framedDoor) {
                        //Store value to appropriate obejct property
                        framedDoor[identifier] = value;
                    }
                }
            }                         
                            
            
            // need if logic here for mixed tint
            if ("<%=currentModel%>" == "M200")
            {
                for (var i = 0; i < coordList.length; i++)
                {
                    if ((i+1) == parseInt(wallNumber))
                    {
                        if (coordList[i][4] == "P")
                        { 
                            var tintCode = "";
                        
                            if (framedDoor.type == "Cabana")
                            {
                                // Checks for cabana doors
                                if ($('#MainContent_ddlDoorStyle' + (i + 1) + 'Cabana').val() == "Vertical Four Track")
                                {
                                    if ($('#MainContent_ddlDoorVinylTint' + (i + 1) + 'Cabana').val() == "Mixed")
                                    {
                                        if ($('#MainContent_ddlDoorNumberOfVents' + (i + 1) + 'Cabana').val() == "2")
                                        {
                                            tintCode += $('#MainContent_ddlDoor' + (i + 1) + 'Tint0Cabana').val();
                                            tintCode += $('#MainContent_ddlDoor' + (i + 1) + 'Tint1Cabana').val();
                                        }
                                        else if ($('#MainContent_ddlDoorNumberOfVents' + (i + 1) + 'Cabana').val() == "3")
                                        {
                                            tintCode += $('#MainContent_ddlDoor' + (i + 1) + 'Tint0Cabana').val();
                                            tintCode += $('#MainContent_ddlDoor' + (i + 1) + 'Tint1Cabana').val();
                                            tintCode += $('#MainContent_ddlDoor' + (i + 1) + 'Tint2Cabana').val();
                                        }
                                        else if ($('#MainContent_ddlDoorNumberOfVents' + (i + 1) + 'Cabana').val() == "4")
                                        {
                                            tintCode += $('#MainContent_ddlDoor' + (i + 1) + 'Tint0Cabana').val();
                                            tintCode += $('#MainContent_ddlDoor' + (i + 1) + 'Tint1Cabana').val();
                                            tintCode += $('#MainContent_ddlDoor' + (i + 1) + 'Tint2Cabana').val();
                                            tintCode += $('#MainContent_ddlDoor' + (i + 1) + 'Tint3Cabana').val();
                                        }

                                        framedDoor.vinylTint = tintCode;
                                        break;
                                    }
                                    else if ($('#MainContent_ddlDoorVinylTint' + (i + 1) + 'Cabana').val() == "Clear")
                                    {
                                        if ($('#MainContent_ddlDoorNumberOfVents' + (i + 1) + 'Cabana').val() == "2")
                                        {
                                            tintCode = "CC";
                                        }
                                        else if ($('#MainContent_ddlDoorNumberOfVents' + (i + 1) + 'Cabana').val() == "3")
                                        {
                                            tintCode = "CCC";
                                        }
                                        else if ($('#MainContent_ddlDoorNumberOfVents' + (i + 1) + 'Cabana').val() == "4")
                                        {
                                            tintCode = "CCCC";
                                        }

                                        framedDoor.vinylTint = tintCode;
                                        break;
                                    }
                                    else if ($('#MainContent_ddlDoorVinylTint' + (i + 1) + 'Cabana').val() == "Smoke Grey")
                                    {
                                        if ($('#MainContent_ddlDoorNumberOfVents' + (i + 1) + 'Cabana').val() == "2")
                                        {
                                            tintCode = "SS";
                                        }
                                        else if ($('#MainContent_ddlDoorNumberOfVents' + (i + 1) + 'Cabana').val() == "3")
                                        {
                                            tintCode = "SSS";
                                        }
                                        else if ($('#MainContent_ddlDoorNumberOfVents' + (i + 1) + 'Cabana').val() == "4")
                                        {
                                            tintCode = "SSSS";
                                        }

                                        framedDoor.vinylTint = tintCode;
                                        break;
                                    }
                                    else if ($('#MainContent_ddlDoorVinylTint' + (i + 1) + 'Cabana').val() == "Dark Grey")
                                    {
                                        if ($('#MainContent_ddlDoorNumberOfVents' + (i + 1) + 'Cabana').val() == "2")
                                        {
                                            tintCode = "DD";
                                        }
                                        else if ($('#MainContent_ddlDoorNumberOfVents' + (i + 1) + 'Cabana').val() == "3")
                                        {
                                            tintCode = "DDD";
                                        }
                                        else if ($('#MainContent_ddlDoorNumberOfVents' + (i + 1) + 'Cabana').val() == "4")
                                        {
                                            tintCode = "DDDD";
                                        }

                                        framedDoor.vinylTint = tintCode;
                                        break;
                                    }
                                    else if ($('#MainContent_ddlDoorVinylTint' + (i + 1) + 'Cabana').val() == "Bronze")
                                    {
                                        if ($('#MainContent_ddlDoorNumberOfVents' + (i + 1) + 'Cabana').val() == "2")
                                        {
                                            tintCode = "BB";
                                        }
                                        else if ($('#MainContent_ddlDoorNumberOfVents' + (i + 1) + 'Cabana').val() == "3")
                                        {
                                            tintCode = "BBB";
                                        }
                                        else if ($('#MainContent_ddlDoorNumberOfVents' + (i + 1) + 'Cabana').val() == "4")
                                        {
                                            tintCode = "BBBB";
                                        }

                                        framedDoor.vinylTint = tintCode;
                                        break;
                                    }
                                }
                                else 
                                {
                                    framedDoor.vinylTint = "";
                                    break;
                                }
                            }
                            else if (framedDoor.type == "French")
                            {
                                // Checks for french doors
                                if ($('#MainContent_ddlDoorStyle' + (i + 1) + 'French').val() == "Vertical Four Track")
                                {
                                    if ($('#MainContent_ddlDoorVinylTint' + (i + 1) + 'French').val() == "Mixed")
                                    {
                                        if ($('#MainContent_ddlDoorNumberOfVents' + (i + 1) + 'French').val() == "2")
                                        {
                                            tintCode += $('#MainContent_ddlDoor' + (i + 1) + 'Tint0French').val();
                                            tintCode += $('#MainContent_ddlDoor' + (i + 1) + 'Tint1French').val();
                                        }
                                        else if ($('#MainContent_ddlDoorNumberOfVents' + (i + 1) + 'French').val() == "3")
                                        {
                                            tintCode += $('#MainContent_ddlDoor' + (i + 1) + 'Tint0French').val();
                                            tintCode += $('#MainContent_ddlDoor' + (i + 1) + 'Tint1French').val();
                                            tintCode += $('#MainContent_ddlDoor' + (i + 1) + 'Tint2French').val();
                                        }
                                        else if ($('#MainContent_ddlDoorNumberOfVents' + (i + 1) + 'French').val() == "4")
                                        {
                                            tintCode += $('#MainContent_ddlDoor' + (i + 1) + 'Tint0French').val();
                                            tintCode += $('#MainContent_ddlDoor' + (i + 1) + 'Tint1French').val();
                                            tintCode += $('#MainContent_ddlDoor' + (i + 1) + 'Tint2French').val();
                                            tintCode += $('#MainContent_ddlDoor' + (i + 1) + 'Tint3French').val();
                                        }

                                        framedDoor.vinylTint = tintCode;
                                        break;
                                    }
                                    else if ($('#MainContent_ddlDoorVinylTint' + (i + 1) + 'French').val() == "Clear")
                                    {
                                        if ($('#MainContent_ddlDoorNumberOfVents' + (i + 1) + 'French').val() == "2")
                                        {
                                            tintCode = "CC";
                                        }
                                        else if ($('#MainContent_ddlDoorNumberOfVents' + (i + 1) + 'French').val() == "3")
                                        {
                                            tintCode = "CCC";
                                        }
                                        else if ($('#MainContent_ddlDoorNumberOfVents' + (i + 1) + 'French').val() == "4")
                                        {
                                            tintCode = "CCCC";
                                        }

                                        framedDoor.vinylTint = tintCode;
                                        break;
                                    }
                                    else if ($('#MainContent_ddlDoorVinylTint' + (i + 1) + 'French').val() == "Smoke Grey")
                                    {
                                        if ($('#MainContent_ddlDoorNumberOfVents' + (i + 1) + 'French').val() == "2")
                                        {
                                            tintCode = "SS";
                                        }
                                        else if ($('#MainContent_ddlDoorNumberOfVents' + (i + 1) + 'French').val() == "3")
                                        {
                                            tintCode = "SSS";
                                        }
                                        else if ($('#MainContent_ddlDoorNumberOfVents' + (i + 1) + 'French').val() == "4")
                                        {
                                            tintCode = "SSSS";
                                        }

                                        framedDoor.vinylTint = tintCode;
                                        break;
                                    }
                                    else if ($('#MainContent_ddlDoorVinylTint' + (i + 1) + 'French').val() == "Dark Grey")
                                    {
                                        if ($('#MainContent_ddlDoorNumberOfVents' + (i + 1) + 'French').val() == "2")
                                        {
                                            tintCode = "DD";
                                        }
                                        else if ($('#MainContent_ddlDoorNumberOfVents' + (i + 1) + 'French').val() == "3")
                                        {
                                            tintCode = "DDD";
                                        }
                                        else if ($('#MainContent_ddlDoorNumberOfVents' + (i + 1) + 'French').val() == "4")
                                        {
                                            tintCode = "DDDD";
                                        }

                                        framedDoor.vinylTint = tintCode;
                                        break;
                                    }
                                    else if ($('#MainContent_ddlDoorVinylTint' + (i + 1) + 'French').val() == "Bronze")
                                    {
                                        if ($('#MainContent_ddlDoorNumberOfVents' + (i + 1) + 'French').val() == "2")
                                        {
                                            tintCode = "BB";
                                        }
                                        else if ($('#MainContent_ddlDoorNumberOfVents' + (i + 1) + 'French').val() == "3")
                                        {
                                            tintCode = "BBB";
                                        }
                                        else if ($('#MainContent_ddlDoorNumberOfVents' + (i + 1) + 'French').val() == "4")
                                        {
                                            tintCode = "BBBB";
                                        }

                                        framedDoor.vinylTint = tintCode;
                                        break;
                                    }
                                }
                                else 
                                {
                                    framedDoor.vinylTint = "";
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            //Changes any custom values to the actual value entered
            for (var k = 0; k < customControls.length; k++) {

                //Create the appropriate identifier for storing purposes
                var identifier = customControls[k][0].toLowerCase() + customControls[k].substr(1);

                if (!(identifier in framedDoor))
                    continue;

                //Get the value from the field being checked (i.e. width = "cWidth" or "30");
                var value = framedDoor[identifier];

                //If the value is custom (i.e. "cWidth"), perform block
                if (value == 'c' + customControls[k]) {
                    //Get textbox value
                    var valueText = $('#MainContent_txtDoor' + customControls[k] + 'Custom' + wallNumber + type).val();
                    //Get drop down value
                    var valueDropDown = $('#MainContent_ddlDoor' + customControls[k] + 'Custom' + wallNumber + type).val();

                    //Store numeric value of the sum of the text box value and drop down value
                    framedDoor[identifier] = parseFloat(valueText) + parseFloat(valueDropDown);
                }
                    //Else, perform block (non-custom field)
                else if (identifier != "position") {
                    //Parse the value into the same property (i.e. "30" string, if now 30 numeric);
                    framedDoor[identifier] = parseFloat(framedDoor[identifier]);
                }
            }

            //Gets the value of width and height with the frame added, based on model number
            var dimensions = calculateActualDoorDimension(framedDoor.width, framedDoor.height, type);
        
            framedDoor.fheight = dimensions.height; //Store frame height into fheight
            framedDoor.fwidth = dimensions.width;   //Store frame width into fwidth
            framedDoor.mheight = dimensions.height + 2;
            framedDoor.mwidth = dimensions.width + 2;

            framedDoor.kickplate = <%= Session["newProjectKneewallHeight"] %>;
            /*Insert the door with the appropriate variables based on drop down selected index*/
            if (framedDoor.position === "Left") {
                if (framedDoor.boxHeader == "Left" || framedDoor.boxHeader == "Both") {
                    framedDoor.position = walls[wallNumber].leftFiller + BOXHEADER_LENGTH;
                }
                else {
                    framedDoor.position = walls[wallNumber].leftFiller;
                }
            }
            else if (framedDoor.position === "Right") {
                if (framedDoor.boxHeader == "Right" || framedDoor.boxHeader == "Both") {
                    framedDoor.position = walls[wallNumber].length - framedDoor.mwidth - walls[wallNumber].rightFiller - BOXHEADER_LENGTH;
                }
                else {
                    framedDoor.position = walls[wallNumber].length - framedDoor.mwidth - walls[wallNumber].rightFiller;
                }
            }
            else if (framedDoor.position === "Center") {
                framedDoor.position = validateDecimal(walls[wallNumber].length / 2 - framedDoor.mwidth / 2);
            }
            //Return framedDoor object
            console.log(framedDoor.position);
            return framedDoor;
        }
    </script>
    <script src="Scripts/DoorSlideFunctions.js"></script>
    <script src="Scripts/WindowSlideFunctions.js"></script>
    <%-- Hidden field populating scripts 
    =================================== --%>
    <script>       
        //Displaying line information passed from custom drawing tool
        //console.log('<%= (string)Session["lineInfo"] %>');

        var gable = '<%= Session["isGable"] %>';
        var gableType = '<%= gableType %>';
        var detailsOfAllLines = '<%= (string)Session["lineInfo"] %>'; //all the coordinates and details of all the lines, coming from the session
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
        //var wallProperties = [
        //    "wallId",
        //    "length",
        //    "height",
        //    "doors",
        //    "windows"
        //]
        
        /**
        *Adding onclick events to next question buttons
        */
        $(document).ready(function () {
            //$('#MainContent_btnQuestion2').on('click', checkQuestion2(gable));
            //$('#MainContent_btnQuestion2').on('click', determineStartAndEndHeightOfEachWall(gable));
            //$('#MainContent_btnQuestion2').on('click', loadWallData);
            $('#MainContent_btnSubmit').on('click', submitData);

            //$('#MainContent_txtWall1Length').val('20');
            //$('#MainContent_txtWall3Length').val('120');
            //$('#MainContent_txtWall4Length').val('50');
            //$('#MainContent_txtWall5Length').val('50');
            //$('#MainContent_txtWall6Length').val('12');
            //$('#MainContent_txtLeftWallHeight').val('60');
            //$('#MainContent_txtRightWallHeight').val('60');
            //$('#MainContent_txtGablePostHeight').val('12');
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
            var isGable = false;
            for (var index = 0; index < coordList.length; index++) { //run through all the setbacks
                if (coordList[index][4] === "G")
                {
                    isGable = true;
                }
                if (coordList[index][4] === "P") {
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
                    if (isGable == false)
                    {
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
                    }
                    else{
                        switch (coordList[index][5])
                        {
                            case "S":
                            case "N":
                                width = 0;
                                break;
                            case "W":
                                width = L;
                                break;
                            case "E":
                                width = -L;
                                break;
                            case "SE":
                            case "NE":
                                width = -(Math.sqrt((Math.pow(L, 2)) / 2));
                                break;
                            case "SW":
                            case "NW":
                                width = Math.sqrt((Math.pow(L, 2)) / 2);
                                break;
                        }
                    }

                    tempWidth = +tempWidth + width //add the values to temp variable

                    if (tempWidth > highestWidth) { //determine if the current temp projection is greater than the highest projection calculated
                        highestWidth = tempWidth; // reset the highest projection
                    }
                }
            }

            roomWidth = highestWidth;
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
                    wallStartHeightArray[backWallIndex] = parseFloat(document.getElementById("hidBackWallHeight").value);
                    wallEndHeightArray[backWallIndex] = parseFloat(document.getElementById("hidBackWallHeight").value);

                    for (var i = (backWallIndex - 1) ; i >= 0; i--) { //0 = index of first wall

                        if (coordList[i][4] === "E") { //existing wall
                            //if (coordList[i][5] === "S") {

                            ///this is assuming that back wall is an existing wall...
                            wallStartHeightArray[i] = parseFloat(document.getElementById("hidBackWallHeight").value);
                            wallEndHeightArray[i] = parseFloat(document.getElementById("hidBackWallHeight").value);
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
                    console.log(backWallIndex);

                    wallStartHeightArray[backWallIndex] = parseFloat(document.getElementById("hidBackWallHeight").value);
                    wallEndHeightArray[backWallIndex] = parseFloat(document.getElementById("hidBackWallHeight").value);

                    console.log(wallStartHeightArray[backWallIndex].toString());
                    for (var i = 0; i < coordList.length; i++) {
                        if (coordList[i][4] === "E") { //existing wall
                            wallStartHeightArray[i] = parseFloat(document.getElementById("hidBackWallHeight").value);
                            wallEndHeightArray[i] = parseFloat(document.getElementById("hidBackWallHeight").value);
                        }
                        else { //proposed wall
                            //if (coordList[i][4] === "P") {

                            wallStartHeightArray[i] = parseFloat(wallEndHeightArray[i - 1]);

                            switch (coordList[i][5]) {
                                case "S": //if south
                                case "N": //or north
                                    wallEndHeightArray[i] = parseFloat(wallStartHeightArray[i-1]);
                                    break;
                                case "W": //if west
                                    wallEndHeightArray[i] = parseFloat(wallStartHeightArray[i-1]) - parseFloat((((wallLengthArray[i] - wallSoffitArray[i]) * m) / RUN)); //determine rise based on slope and length, and subtract it from start height
                                    break;
                                case "E": //if east
                                    wallEndHeightArray[i] = parseFloat(wallStartHeightArray[i-1]) + parseFloat((((wallLengthArray[i] - wallSoffitArray[i]) * m) / RUN)); //determine rise based on slope and length, and add it to start height
                                    break;
                                case "SW": //if southwest
                                case "SE": //or northwest
                                    wallEndHeightArray[i] = parseFloat(wallStartHeightArray[i-1]) - parseFloat((((wallSetBackArray[i] - wallSoffitArray[i]) * m) / RUN)); //determine rise based on slope and setback, then subtract it from start height 
                                    break;
                                case "NW": //if southeast
                                case "NE": //or northeast
                                    wallEndHeightArray[i] = parseFloat(wallStartHeightArray[i-1]) + parseFloat((((wallSetBackArray[i] - wallSoffitArray[i]) * m) / RUN)); //determine rise based on slope and setback, then add it to start height 
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
        This function calculates the slope (over RUN, set at the top), based on the given heights
        @return slope over RUN, set at the top
        */
        function calculateSlope(backWallHeight, frontWallHeight) {
            var rise; //m = ((rise * run)/(roomProjection - soffitLength)) slope over 12

            rise = parseFloat(backWallHeight) - parseFloat(frontWallHeight);

            return ((rise / (roomProjection - soffitLength)) * 12).toFixed(2);  //slope over 12, rounded to 2 decimal places
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
                if (coordList[i - 1][4] === "P"/* || coordList[i - 1][4] === "G"*/) {
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

            //Used for 'cheat' below
            var cheatCounter = 0;

            if (isValid) { //if everything is valid

                var existingWallCount=0;
                for (var i = 1; i <= lineList.length; i++) { //populate the hidden fields for each wall
                    
                    if (coordList[i - 1][4] === "P"/* || coordList[i - 1][4] === "G"*/) {
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
                        answer += "Wall " + (i-existingWallCount) + ": " + document.getElementById("hidWall" + i + "Length").value + "<br/>"; //store the values in the answer variable to be displayed

                        //The current program hasn't considered the space receievers or corner posts take up in a wall's length
                        //So we're going to cheat it here by adding that 'space' to the fillers, and removing it later when the
                        //Wall objects are being built.
                        if (cheatCounter ==0)
                        {
                            document.getElementById("hidWall" + i + "LeftFiller").value = parseFloat(document.getElementById("hidWall" + i + "LeftFiller").value) + parseFloat(1);//CHANGEME receiver length
                            cheatCounter++;
                        }
                        //If not the first, we add a corner post length to left filler
                        else
                        {
                            if ("<%=currentModel%>" == "M400")
                            {
                                document.getElementById("hidWall" + i + "LeftFiller").value = parseFloat(document.getElementById("hidWall" + i + "LeftFiller").value) + parseFloat(4.125); //CHANGEME corner post
                            }
                            else
                            {
                                document.getElementById("hidWall" + i + "LeftFiller").value = parseFloat(document.getElementById("hidWall" + i + "LeftFiller").value) + parseFloat(3.125); //CHANGEME corner post
                            }
                        }
                       
                        try
                        {
                            //If next wall is proposed we add a corner post's length to right filler
                            if (coordList[i][4] == "P")
                            {
                                if ("<%=currentModel%>" == "M400")
                                {
                                    document.getElementById("hidWall" + i + "RightFiller").value = parseFloat(document.getElementById("hidWall" + i + "RightFiller").value) + parseFloat(4.125); //CHANGEME corner post
                                }
                                else
                                {
                                    document.getElementById("hidWall" + i + "RightFiller").value = parseFloat(document.getElementById("hidWall" + i + "RightFiller").value) + parseFloat(3.125); //CHANGEME corner post
                                }
                            }
                        }
                        //If we catch an error, this is the last wall, add receiever instead of post
                        catch(err)
                        {
                            document.getElementById("hidWall" + i + "RightFiller").value = parseFloat(document.getElementById("hidWall" + i + "RightFiller").value) + parseFloat(1); //CHANGEME corner post
                        }                  
                    }
                    else{
                        existingWallCount++;
                    }
                }

                //store roomProjection in the roomProjection variable and hidden field
                document.getElementById("MainContent_hidRoomProjection").value = roomProjection = calculateProjection(); 
                calculateWidth();
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
                document.getElementById('MainContent_btnQuestion1').disabled = true;
            }
            
            checkRoofPanels();
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
                        && document.getElementById("MainContent_txtLeftWallHeight").value != ""
                        && document.getElementById("MainContent_txtLeftWallHeight").value > 0
                        && !isNaN(document.getElementById("MainContent_txtRightWallHeight").value)
                        && document.getElementById("MainContent_txtRightWallHeight").value != ""
                        && document.getElementById("MainContent_txtRightWallHeight").value > 0
                        && !isNaN(document.getElementById("MainContent_txtGablePostHeight").value)
                        && document.getElementById("MainContent_txtGablePostHeight").value != ""
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
                        && document.getElementById("MainContent_txtLeftRoofSlope").value != ""
                        && document.getElementById("MainContent_txtLeftRoofSlope").value > 0
                        && !isNaN(document.getElementById("MainContent_txtGablePostHeight").value)
                        && document.getElementById("MainContent_txtGablePostHeight").value != ""
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
                        && document.getElementById("MainContent_txtRightRoofSlope").value != ""
                        && document.getElementById("MainContent_txtRightRoofSlope").value > 0
                        && !isNaN(document.getElementById("MainContent_txtGablePostHeight").value)
                        && document.getElementById("MainContent_txtGablePostHeight").value != ""
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
                    document.getElementById('MainContent_btnQuestion2').disabled = true;
                }
            }
            else {
                //if user wants to auto calculate the slope
                if (document.getElementById("MainContent_radAutoRoofSlope").checked) {
                    //we have front wall height and back wall height, calculate slope
                    if (!isNaN(document.getElementById("MainContent_txtBackWallHeight").value) //if the other textbox values are valid
                        && document.getElementById("MainContent_txtBackWallHeight").value != ""
                        && document.getElementById("MainContent_txtBackWallHeight").value > 0
                        && !isNaN(document.getElementById("MainContent_txtFrontWallHeight").value)
                        && document.getElementById("MainContent_txtFrontWallHeight").value != ""
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
                        && document.getElementById("MainContent_txtBackWallHeight").value != ""
                        && document.getElementById("MainContent_txtBackWallHeight").value > 0
                        && !isNaN(document.getElementById("MainContent_txtRoofSlope").value)
                        && document.getElementById("MainContent_txtRoofSlope").value != ""
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
                    if (!isNaN(document.getElementById("MainContent_txtFrontWallHeight").value) 
                        && document.getElementById("MainContent_txtFrontWallHeight").value != "" //check if other textbox values are valid
                        && document.getElementById("MainContent_txtFrontWallHeight").value > 0
                        && !isNaN(document.getElementById("MainContent_txtRoofSlope").value) 
                        && document.getElementById("MainContent_txtRoofSlope").value !=""
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
                if (document.getElementById("MainContent_txtRoofSlope").value != "" && document.getElementById("MainContent_txtRoofSlope").value >= 0)
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
                    document.getElementById('MainContent_btnQuestion2').disabled = true;
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
            if ("<%=currentModel%>" == "M200")
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

            //Validate custom kickplate
            for (var i = 0; i < coordList.length; i++)
            {
                if (isNaN(document.getElementById('MainContent_rowDoorCustomKickplate' + i + "Cabana").value))
                {
                    document.getElementById("<%=txtErrorMessage.ClientID%>").value = "Kickplates must be a valid number.";                   
                }
                else if(document.getElementById('MainContent_rowDoorCustomKickplate' + i + "Cabana").value != 4 && document.getElementById('MainContent_rowDoorCustomKickplate' + i + "Cabana").value <10)
                {
                    document.getElementById("<%=txtErrorMessage.ClientID%>").value = "Kickplates must equal 4\" or be greater than or equal to 10\"";     
                }
            }
        }
        
        function checkRoofPanels() {
            if (gable != "True"){
                document.getElementById("<%=txtErrorMessage.ClientID%>").value = ""
                var checkRoofSlope = (document.getElementById("MainContent_txtRoofSlope").value)/RUN;
                var checkRoofProjection = roomProjection - soffitLength;
                var roofRise = checkRoofSlope * checkRoofProjection;

                var roofPanelProjection = Math.sqrt(Math.pow(roofRise,2) + Math.pow(checkRoofProjection, 2));
            
                if (roofPanelProjection > parseFloat('<%=FOAM_PANEL_PROJECTION%>'))
                {
                    document.getElementById("<%=txtErrorMessage.ClientID%>").value = "You may not have foam panels with this projection\n";
                }
                if (roofPanelProjection > parseFloat('<%=ACRYLIC_PANEL_PROJECTION%>'))
                {
                    document.getElementById("<%=txtErrorMessage.ClientID%>").value += "You may not have acrylic panels with this projection\n";
                }
                if (roofPanelProjection > parseFloat('<%=THERMADECK_PANEL_PROJECTION%>'))
                {
                    document.getElementById("<%=txtErrorMessage.ClientID%>").value = "You may not have a roof with this projection\n";
                }
            }
            else
            {
                document.getElementById("<%=txtErrorMessage.ClientID%>").value = ""
                var checkLeftRoofSlope = (document.getElementById("MainContent_txtLeftRoofSlope").value)/RUN;
                var roofLeftRise = (document.getElementById("MainContent_txtGablePostHeight").value) - (document.getElementById("MainContent_txtLeftWallHeight").value);
                var checkRoofLeftProjection = Math.sqrt(Math.pow((roomProjection/2),2) + Math.pow(roofLeftRise,2));

                var checkRightRoofSlope = (document.getElementById("MainContent_txtRightRoofSlope").value)/RUN;
                var roofRightRise = (document.getElementById("MainContent_txtGablePostHeight").value) - (document.getElementById("MainContent_txtRightWallHeight").value);
                var checkRoofRightProjection = Math.sqrt(Math.pow((roomProjection/2),2) + Math.pow(roofRightRise,2));
            
                if (checkRoofLeftProjection > parseFloat('<%=FOAM_PANEL_PROJECTION%>'))
                {
                    document.getElementById("<%=txtErrorMessage.ClientID%>").value = "You may not have foam panels with this left projection\n";
                }
                if (checkRoofLeftProjection > parseFloat('<%=ACRYLIC_PANEL_PROJECTION%>'))
                {
                    document.getElementById("<%=txtErrorMessage.ClientID%>").value += "You may not have acrylic panels with this left projection\n";
                }
                if (checkRoofLeftProjection > parseFloat('<%=THERMADECK_PANEL_PROJECTION%>'))
                {
                    document.getElementById("<%=txtErrorMessage.ClientID%>").value = "You may not have a roof with this left projection\n";
                }
                if (checkRoofRightProjection > parseFloat('<%=FOAM_PANEL_PROJECTION%>'))
                {
                    document.getElementById("<%=txtErrorMessage.ClientID%>").value = "You may not have foam panels with this right projection\n";
                }
                if (checkRoofRightProjection > parseFloat('<%=ACRYLIC_PANEL_PROJECTION%>'))
                {
                    document.getElementById("<%=txtErrorMessage.ClientID%>").value += "You may not have acrylic panels with this right projection\n";
                }
                if (checkRoofRightProjection > parseFloat('<%=THERMADECK_PANEL_PROJECTION%>'))
                {
                    document.getElementById("<%=txtErrorMessage.ClientID%>").value = "You may not have a roof with this right projection\n";
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
        function WindowPreparation()
        {
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
                if ('<%=Session["model"].ToString()%>' == 'M100')
                {
                    document.getElementById("MainContent_hidWindowType").value = "Screen";
                    console.log("Adjusted M100 to screen");
                }

                console.log(wallAreaArray.length + ", " + existingWallCount);
                document.getElementById("MainContent_lblOutputArea" + i).innerHTML = "";
                var html = "";
                //console.log("");

                var MIN_MOD_WIDTH = 0;
                var MAX_MOD_WIDTH =0;

                switch (document.getElementById("<%=hidWindowType.ClientID%>").value) {
                    case "Fixed Vinyl":
                        MIN_MOD_WIDTH = <%=VINYL_TRAP_MIN_WIDTH_WARRANTY%>; //We use the trap version because they can have both
                        MAX_MOD_WIDTH = <%=VINYL_TRAP_MAX_WIDTH_WARRANTY%>;
                        break;

                    case "Fixed Glass 2\"":
                        MIN_MOD_WIDTH = <%=VINYL_TRAP_MIN_WIDTH_WARRANTY%>; //We use the trap version because they can have both
                        MAX_MOD_WIDTH = <%=VINYL_TRAP_MAX_WIDTH_WARRANTY%>;
                        break;
                        
                    case "Fixed Glass 3\"":
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
                    
                    case "Horizontal 2 Track":
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

                    case "Open Wall":
                        MIN_MOD_WIDTH = <%=V4T_4V_MIN_WIDTH_WARRANTY%>; //We use the trap version because they can have both
                        MAX_MOD_WIDTH = <%=V4T_4V_MAX_WIDTH_WARRANTY%>;
                        break;

                    case "Solid Wall":
                        MIN_MOD_WIDTH = <%=V4T_4V_MIN_WIDTH_WARRANTY%>; //We use the trap version because they can have both
                        MAX_MOD_WIDTH = <%=V4T_4V_MAX_WIDTH_WARRANTY%>;
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
                    console.log("Proposed wall succeeded");
                    console.log(walls[i].startHeight);
                    console.log(walls[i].endHeight);

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
                                document.getElementById("hidWall" + i + "Door" + (j+1) + "position").value = parseFloat(walls[i].mods[j].position);
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

            if($('#MainContent_chkRailing').prop('checked') == true)
            {
                document.getElementById("MainContent_hidRailing").value  = "Yes";
                document.getElementById("MainContent_hidRailingHeight").value  = $('#MainContent_ddlRailing :selected').text();
                console.log("Railings are to be included");
            }
            else
            {
                document.getElementById("MainContent_hidRailing").value  = "No";
                document.getElementById("MainContent_hidRailingHeight").value  = "";
                console.log("Railings are NOT to be included");
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
            if ("<%=currentModel%>" == "M100")
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
                if ('<%=currentModel%>' == "M400")
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
                    <asp:Label ID="lblQuestion1" runat="server" Text="Please enter the wall lengths"></asp:Label>
                </h1>        
                              
                <%-- div to store and organize the tables for textboxes and dropdowns for each wall length 
                    number of rows in the 2 tables below are added dynamically in the codebehind--%>
                <div id="tableWallLengths" class="tblWallLengths" runat="server" >
                    <%-- first table for existing walls, only contains input fields for lengths --%>
                    <%--<asp:Table ID="tblExistingWalls" runat="server">
                        <asp:TableRow>
                            <%-- table headings --%>
                           <%--<asp:TableHeaderCell >
                                Existing Walls
                            </asp:TableHeaderCell>--%>
                        <%--</asp:TableRow>
                        <asp:TableRow>--%>
                            <%--<asp:TableCell></asp:TableCell>--%>
                            <%-- column headings --%>
                            <%--<asp:TableCell ColumnSpan="6" >
                                Length
                            </asp:TableCell>--%>
                        <%--</asp:TableRow>--%>
                    <%--</asp:Table>--%>
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
                <asp:Button ID="btnQuestion1" Enabled="false" OnClientClick="checkQuestion1()" CssClass="btnSubmit float-right slidePanel" data-slide="#slide2" runat="server" Text="Next Question" />

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
                <input type="button" id="btnQuestion2" onclick="checkQuestion2(gable); determineStartAndEndHeightOfEachWall(gable); loadWallData();" class="btnSubmit float-right slidePanel" data-slide="#slide3" runat="server" value="Next Question" disabled/>

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

                <asp:Button ID="btnQuestion3" Enabled="true" OnClientClick="checkQuestion3()" CssClass="btnSubmit float-right slidePanel" data-slide="#slide4" runat="server" Text="Next Question"/>

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

                <asp:Button ID="btnSubmit" Enabled="true" CssClass="btnSubmit float-right slidePanel" runat="server" Text="Submit" OnClick="btnSubmit_Click" />

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
    
<script src="Scripts/MiniCanvasFunctions.js"></script>

    <%-- Hidden input tags 
    ======================= --%>

    <%-- hiddenFieldsDiv is used to store dynamically generated hidden fields from codebehind --%>
    <div id="hiddenFieldsDiv" runat="server"></div>
    <div id="removableHiddenFieldsDiv" runat="server"></div>
    <div id="hiddenWallInfo" runat="server"></div>

    <%-- <input id="hidSoffitLength" type="hidden" runat="server" /> --%>
    <input id="hidRoomProjection" type="hidden" runat="server" />
    <input id="hidRoomWidth" type="hidden" runat="server" />
    <input id="hidWindowType" type="hidden" runat="server" />
    <input id="hidWindowColour" type="hidden" runat="server" />
    <input id="hidWindowFramingColour" type="hidden" runat="server" />
    <input id="hidScreenType" type="hidden" runat="server" value="" />
    <input id="hidSunshade" type="hidden" runat="server" value=""/>
    <input id="hidValance" type="hidden" runat="server" value="" />
    <input id="hidFabric" type="hidden" runat="server" value="" />
    <input id="hidOpenness" type="hidden" runat="server" value="" />
    <input id="hidChain" type="hidden" runat="server" value="" />
    <input id="hidRailing" type="hidden" runat="server" value="No" />
    <input id="hidRailingHeight" type="hidden" runat="server" />

    <%-- end hidden fields --%>    

    <script>
        $(function () {
            $('.ulNavMain').children('a').removeClass('active');
            $('#lnkMainNavNewProject').addClass('active');
        });
    </script>
</asp:Content>

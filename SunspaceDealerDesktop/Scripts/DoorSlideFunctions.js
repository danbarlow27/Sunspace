/********************************************************************************************
*Author:        Patrique Ouimet                                                             *
*Date Created:  24/07/2013                                                                  *
*Version:       1.0                                                                         *
*Description:   This file contains all the contructors, prototypes, and functions to make   *
*               the door slide on WizardWallsAndMods.aspx page functional. This section     *
*               will create objects, validate them, and display appropriate messages to the *
*               user based on validation.                                                   *
*********************************************************************************************/

/******************************************VALIDATION VARIABLES******************************************/


var cabanaMinValues = calculateActualDoorDimension(parseInt(CABANA_MIN_WIDTH), parseInt(CABANA_MIN_HEIGHT), "Cabana");
var cabanaMaxValues = calculateActualDoorDimension(parseInt(CABANA_MAX_WIDTH), parseInt(CABANA_MAX_HEIGHT), "Cabana");

var cabanaMinWidth = cabanaMinValues.width;
var cabanaMinHeight = cabanaMinValues.height;

var cabanaMaxWidth = cabanaMaxValues.width;
var cabanaMaxHeight = cabanaMaxValues.height;

var frenchMinValues = calculateActualDoorDimension(parseInt(CABANA_MIN_WIDTH) * 2, parseInt(CABANA_MIN_HEIGHT), "French");
var frenchMaxValues = calculateActualDoorDimension(parseInt(CABANA_MAX_WIDTH) * 2, parseInt(CABANA_MAX_HEIGHT), "French");

var frenchMinWidth = frenchMinValues.width;
var frenchMinHeight = frenchMinValues.height;

var frenchMaxWidth = frenchMaxValues.width;
var frenchMaxHeight = frenchMaxValues.height;

var patioMinValues = calculateActualDoorDimension(parseInt(PATIO_DOOR_MIN_WIDTH), parseInt(PATIO_DOOR_MIN_HEIGHT), "Patio");
var patioMaxValues = calculateActualDoorDimension(parseInt(PATIO_DOOR_MAX_WIDTH), parseInt(PATIO_DOOR_MAX_HEIGHT), "Patio");

var patioMinWidth = patioMinValues.width;
var patioMinHeight = patioMinValues.height;

var patioMaxWidth = patioMaxValues.width;
var patioMaxHeight = patioMaxValues.height;

/******************************************CONSTRUCTORS AND PROTOTYPES******************************************/

/**
*Prototype used to create an "insert" function for arrays. This function can insert elements at specific indices
*@param index - is which index to insert the item at
*@param item - which item is to be inserted
*/
Array.prototype.insert = function (index, item) {
    this.splice(index, 0, item);
};


//Framed Door holds all common information for doors
function FramedDoor() {
    this.type = null;           //Cabana, French, Patio, Open Space (No Door)
    this.style = null;          //Full Screen, Vertical Four Track, Full View, Full View Colonial, Half Lite, Half Lite Venting, Full Lite, Half Lite With Mini Blinds, Full View With Mini Blinds
    this.screenOptions = null;  //Better Vue Insect Screen, No See Ums 20x20 Mesh, Solar Insect Screen, Tuff Screen, No Screen
    this.fheight = null;        //In example, 80" door stores 80.875 to this field(inches)
    this.fwidth = null;         //In example, 30" door stores 32.125 to this field(inches)
    this.color = null;          //White, Driftwood, Bronze, Green, Black, Ivory, Cherrywood, Grey
    this.position = null;       //Left, Center, Right, Custom
    this.boxHeader = null;      //Left, Right, Both, None
    this.transom = null;        //Vinyl, Glass, Solid
    this.transomVinyl = null;   //Vinyl Tints: Clear, Smoke Grey, Dark Grey, Bronze, Mixed 
    this.transomGlass = null;   //Glass Tints: Grey, Bronze
}

//Constructor to hold cabana door specific information
function CabanaDoor() {
    this.type = "Cabana";       //Sets the door type to Cabana
    this.height = null;         //Used to hold various heights, currently: 80", and Custom for all models and door types
    this.width = null;          //Used to hold various widths (varies on door type), in example: 30", 32", 34", 36", Custom
    this.vinylTint = null;      //Holds one of the vinyl tints: Clear, Smoke Grey, Dark Grey, Bronze, Mixed 
    this.glassTint = null;      //Holds one of the glass tints: Grey, Bronze
    this.hinge = null;          //Holds the hinge placement: Right or Left
    this.swing = null;          //Holds the swing orientation: In or Out
    this.hardware = null;       //Holds the kind of hardware used: Satin Silver, Bright Brass, Antique Brass
    this.numberOfVents = null;  //Holds the number of vents: 2, 3, 4
    this.kickplate = null;      //Holds the height of the kickplate: 6", 7", 8", 9"...24", Custom
}

//Used to include general door information to CabanaDoor instances
CabanaDoor.prototype = new FramedDoor();

//Constructor to hold french door specific information
function FrenchDoor() {
    this.type = "French";       //Sets the door type to French
    this.height = null;         //Used to hold various heights, currently: 80", and Custom for all models and door types
    this.width = null;          //Used to hold various widths (varies on door type), in example: 30", 32", 34", 36", Custom
    this.vinylTint = null;      //Holds one of the vinyl tints: Clear, Smoke Grey, Dark Grey, Bronze, Mixed 
    this.glassTint = null;      //Holds one of the glass tints: Grey, Bronze
    this.swing = null;          //Holds the swing orientation: In or Out
    this.operator = null;       //Holds the operator: Left or Right
    this.hardware = null;       //Holds the kind of hardware used: Satin Silver, Bright Brass, Antique Brass
    this.numberOfVents = null;  //Holds the number of vents: 2, 3, 4
    this.kickplate = null;      //Holds the height of the kickplate: 6", 7", 8", 9"...24", Custom
}

//Used to include general door information to FrenchDoor instances
FrenchDoor.prototype = new FramedDoor();

//Constructor to hold patio door specific information
/****MORE TO BE ADDED****/
function PatioDoor() {
    this.type = "Patio";        //Sets the door type to Patio
    this.height = null;         //Used to hold various heights, currently: 80", and Custom for all models and door types
    this.width = null;          //Used to hold various widths (varies on door type), in example: 30", 32", 34", 36", Custom
    this.glassTint = null;      //Holds one of the glass tints: Grey, Bronze
    this.operator = null;       //Holds the operator: Left or Right
}

//Used to include general door information to PatioDoor instances
PatioDoor.prototype = new FramedDoor();

//Constructor to hold open space specific information
function OpenSpaceDoor() {
    this.type = "NoDoor";       //Sets the door type to NoDoor
    this.height = null;         //Used to hold various heights, currently: 80", and Custom for all models and door types
    this.width = null;          //Used to hold various widths (varies on door type), in example: 30", 32", 34", 36", Custom
}

//Used to include general door information to OpenSpaceDoor instances
OpenSpaceDoor.prototype = new FramedDoor();


/******************************************FUNCTIONS******************************************/

/**
*addDoor
*This function is used to add doors to an array of wall objects
*@param wallNumber - holds an integer to know which wall is currently being affected
*@param type - gets the type of door selected (i.e. Cabana, French, Patio, Opening Only (No Door))
*/
function addDoor(wallNumber, type) {

    //Call to createDoorObject function to create the appropriate door object based on type
    var door = createDoorObject(wallNumber, type);

    //Call to validateDoor, if false is returned, return (or exit) this function 
    if (!validateDoor(door, walls[wallNumber])) {
        return;
    }
    //Validate door(s) width/height parameters
    if (!validateDoorParameters(door, walls[wallNumber])) {
        return;
    }

    //Call to insertDoor to place the valid door in its respective place
    insertDoor(door, walls[wallNumber]);

    //Display appropriate message and controls within the pager
    updateDoorPager(walls[wallNumber]);

}

/**
*calculateActualDoorDimension
*This function calculates a doors actual dimension based on model number, dimension, custom dimension, and
*the current wall selected. This is needed because there is frame added to doors anywhere from 1.125 
*to 3.625 depending on the type of door and the sunroom model.
*@param dimension - gets the dimension currently being called (i.e. Width, Height)
*/
function calculateActualDoorDimension(width, height, type) {

    //If the type is Cabana, perform the following block
    if (type === 'Cabana') {
        //Return width and height, may change if the model is M400
        return {
            width: (model === 'M400') ? width + 3.625 : width + 2.125,
            height: (model === 'M400') ? height + 2.125 : height + 0.875
        };
    }
        //If the type is French, perform the following block
    else if (type === 'French') {
        //Return width and height, may change if the model is M400
        return {
            width: (model === 'M400') ? ((width/2 + 3.625) - 1.625)*2 + 2 : ((width/2 + 2.125) - 1.625)*2 + 2,
            height: (model === 'M400') ? height + 2.125 : height + 0.875
        };
    }
        //If the type is Patio, perform the following block
    else if (type == 'Patio') {
        //Return width and height, may change if the model is M400
        return {
            width: (model === 'M400') ? width + 3.625 : width + 2.125,
            height: (model === 'M400') ? height + 1.625 : height + 1.125
        };
    }
        //Else, perform the following block
    else {
        //Return width and height, no changes for no door (Open space)
        return {
            width: width,
            height: height
        };
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

    //Get the respective drop downs selected value, store it into dimensionDDL variable
    var dimensionDDL = document.getElementById('MainContent_ddlDoor' + dimension + wallNumber + type).options[document.getElementById('MainContent_ddlDoor' + dimension + wallNumber + type).selectedIndex].value;

    //If the selected value is custom (i.e. cWidth, etc), perform block
    if (document.getElementById('MainContent_radType' + wallNumber + type).checked && dimensionDDL == 'c' + dimension) {
        //Set display style of respective row to "inherit"
        document.getElementById('MainContent_rowDoorCustom' + dimension + wallNumber + type).style.display = 'inherit';
    }
        //Else, perform block
    else {
        //Set display style of respective row to "none"
        document.getElementById('MainContent_rowDoorCustom' + dimension + wallNumber + type).style.display = 'none';
    }
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
        "ddlDoorTransom",
        "ddlDoorTransomVinyl",
        "ddlDoorTransomGlass",
        "ddlDoorKickplate",
        "ddlDoorColor",
        "radDoorInternalGrills",
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
                //console.log("Framed Door: " + framedDoor[identifier] + " / Identifier: " + identifier);
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

    /*Insert the door with the appropriate variables based on drop down selected index*/
    if (framedDoor.position === "Left") {
        framedDoor.position = walls[wallNumber].leftFiller;
    }
    else if (framedDoor.position === "Right") {
        framedDoor.position = walls[wallNumber].length - framedDoor.fwidth - walls[wallNumber].rightFiller;
    }
    else if (framedDoor.position === "Center") {
        framedDoor.position = walls[wallNumber].length / 2 - framedDoor.fwidth / 2;
    }

    //Return framedDoor object
    return framedDoor;
}

/**
*deleteDoor
*This function is used to perform certain task when a door is deleted (called on click), remove
*controls from pager, remove the door from walls[index].
*@param doorToDelete - holds the index of the door to be deleted
*@param type - gets the type of door selected (i.e. Cabana, French, Patio, Opening Only (No Door))
*@param wallNumber - holds an integer to know which wall is currently being affected
*/
function deleteDoor(doorToDelete, type, wallNumber) {

    //Removes object at specified index
    walls[wallNumber].doors.splice(doorToDelete - 1, 1);

    //Used to redisplay the appropriate space left in the wall
    var space = totalSpaceLeftInWall(walls[wallNumber]);

    //Call to updateDoorPager to display appropriate values within the pager
    updateDoorPager(walls[wallNumber]);
}

/**
*deleteDoorFill
*This function is used to perform certain task when a door fill is deleted (called on click).
*@param type - gets the type of door selected (i.e. Cabana, French, Patio, Opening Only (No Door))
*@param wallNumber - holds an integer to know which wall is currently being affected
*/
function deleteDoorFill(type, wallNumber) {

    //Reset specific wall's doors array to a new blank array
    walls[wallNumber].doors = [];

    //Call to updateDoorPager to display appropriate values within the pager
    updateDoorPager(walls[wallNumber]);
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

    //Get value of door style drop down
    var doorStyleDDL = document.getElementById('MainContent_ddlDoorStyle' + wallNumber + type).options[document.getElementById('MainContent_ddlDoorStyle' + wallNumber + type).selectedIndex].value;

    //If drop down value is v4TCabana, perform block
    if (doorStyleDDL == 'Vertical Four Track') {
        //Change door vinyl tint row display style to inherit
        document.getElementById('MainContent_rowDoorVinylTint' + wallNumber + type).style.display = 'inherit';
        //Change door number of vents row display style to inherit
        document.getElementById('MainContent_rowDoorNumberOfVents' + wallNumber + type).style.display = 'inherit';
        //Change door screen options row display style to none
        document.getElementById('MainContent_rowDoorScreenOptions' + wallNumber + type).style.display = 'none';
    }
    else if (doorStyleDDL == 'Full Screen' || doorStyleDDL == 'Screen')
    {
        //Change door screen options row display style to inherit
        document.getElementById('MainContent_rowDoorScreenOptions' + wallNumber + type).style.display = 'inherit';
        //Change door vinyl tint row display style to none
        document.getElementById('MainContent_rowDoorVinylTint' + wallNumber + type).style.display = 'none';
        //Change door number of vents row display style to inherit
        document.getElementById('MainContent_rowDoorNumberOfVents' + wallNumber + type).style.display = 'none';
    }
        //else, perform block
    else {
        //Change door vinyl tint row display style to none
        document.getElementById('MainContent_rowDoorVinylTint' + wallNumber + type).style.display = 'none';
        //Change door number of vents row display style to inherit
        document.getElementById('MainContent_rowDoorNumberOfVents' + wallNumber + type).style.display = 'none';
        //Change door screen options row display style to none
        document.getElementById('MainContent_rowDoorScreenOptions' + wallNumber + type).style.display = 'none';
    }
}

/**
*doorKickplateStyle
*Door kickplate style function changes the fields being displayed based on the selected index.
*@param type - gets the type of door selected (i.e. Cabana, French, Patio, Opening Only (No Door));
*@param wallNumber - holds an integer to know which wall is currently being affected
*/
function doorKickplateStyle(type, wallNumber) {

    //Get kickplate drop down value
    var kickplateType = document.getElementById('MainContent_ddlDoorKickplate' + wallNumber + type).options[document.getElementById('MainContent_ddlDoorKickplate' + wallNumber + type).selectedIndex].value;

    //If kickplateType is custom, perform block
    if (kickplateType == 'cKickplate') {
        //Change door kickplate custom display style to inherit
        document.getElementById('MainContent_rowDoorCustomKickplate' + wallNumber + type).style.display = 'inherit';
    }
        //Else, perform block
    else {
        //Change door kickplate custom display style to inherit
        document.getElementById('MainContent_rowDoorCustomKickplate' + wallNumber + type).style.display = 'none';
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

    //Get transom drop down value
    var transomType = document.getElementById('MainContent_ddlDoorTransom' + wallNumber + type).options[document.getElementById('MainContent_ddlDoorTransom' + wallNumber + type).selectedIndex].value;

    //If transomType value is vinyl, perform block
    if (transomType == 'Vinyl') {
        //Change transom vinyl row display style to inherit
        document.getElementById('MainContent_rowDoorTransomVinyl' + wallNumber + type).style.display = 'inherit';
        //Change transom glass row display style to none
        document.getElementById('MainContent_rowDoorTransomGlass' + wallNumber + type).style.display = 'none';
    }
        //Else if transomType value is glass, perform block
    else if (transomType == 'Glass') {
        //Change transom vinyl row display style to none
        document.getElementById('MainContent_rowDoorTransomVinyl' + wallNumber + type).style.display = 'none';
        //Change transom glass row display style to inherit
        document.getElementById('MainContent_rowDoorTransomGlass' + wallNumber + type).style.display = 'inherit';
    }
        //Else, perform this block
    else {
        //Change transom vinyl row display style to none
        document.getElementById('MainContent_rowDoorTransomVinyl' + wallNumber + type).style.display = 'none';
        //Change transom glass row display style to none
        document.getElementById('MainContent_rowDoorTransomGlass' + wallNumber + type).style.display = 'none';
    }
}

/**
*fillWallWithdoorMods
*This function is used to fill the wall with as may doorMods as possible, they'll be centered and
*the ends will be filler
*@param type - gets the type of door selected (i.e. Cabana, French, Patio, Opening Only (No Door))
*@param wallNumber - holds an integer to know which wall is currently being affected
*/
function fillWallWithDoorMods(type, wallNumber) {

    //Call to createDoorObject returns object stored into door variable
    var door = createDoorObject(wallNumber, type);

    //If type is NoDoor, perform this block
    if (type == "NoDoor") {
        //Change the start position of the door to be beside the left filler of the wall
        door.position = walls[wallNumber].leftFiller;
        //Find the frame size
        //var frameSize = door.fwidth - door.width;
        //Set the dimensions
        door.fwidth = walls[wallNumber].length - walls[wallNumber].leftFiller - walls[wallNumber].rightFiller;
        door.width = door.fwidth; // - frameSize
    }
    
    //If validation fails, perform block
    if (!validateDoorFill(door, walls[wallNumber])) {
        return;
    }
    //Validate door(s) width/height parameters
    if (!validateDoorParameters(door, walls[wallNumber])) {
        return;
    }

    //Variable to hold the amount of doors that can't fit within the specified wall
    var amountOfDoors = parseInt((walls[wallNumber].length - walls[wallNumber].leftFiller - walls[wallNumber].rightFiller) / door.fwidth);
    //Gets the amount of filler to put on both sides to center the doors and change the start position
    var padding = ((walls[wallNumber].length - walls[wallNumber].leftFiller - walls[wallNumber].rightFiller) - (amountOfDoors * door.fwidth)) / 2;
    //Holds the padding to later be incremented
    var currentPosition = padding;

    for (var i = 0; i < amountOfDoors; i++) {
        var newDoor = $.extend(true, {}, door);
        newDoor.position = currentPosition;
        insertDoor(newDoor, walls[wallNumber]);
        currentPosition += door.fwidth;
    }

    //Update total space left in the wall
    var space = totalSpaceLeftInWall(walls[wallNumber]);

    /****PAGER VARIABLES****/
    var pagerText = document.getElementById("MainContent_lblQuestion3SpaceInfoWall" + wallNumber);
    var pagerTextAnswer = document.getElementById("wall" + wallNumber + "DoorsAdded");
    var pagerTextDoor = document.getElementById("MainContent_lblQuestion3DoorsInfoWall" + wallNumber);
    var proposedWall = document.getElementById("MainContent_lblTextArea" + wallNumber);

    //Block to add content to the pager
    $("#MainContent_lblQuestion3SpaceInfoWallAnswer" + wallNumber).text(space);
    document.getElementById("pagerThree").style.display = "inline";
    document.getElementById("wall" + wallNumber + "SpaceRemaining").style.display = "inline";
    pagerText.setAttribute("style", "display:block;");
    pagerTextAnswer.setAttribute("style", "display:block");
    pagerTextDoor.innerHTML = "Wall " + (proposedWall.innerHTML).substr(14, 2) + " Door Mods";

    //Display appropriate message and controls within the pager
    var pagerTextDoorAnswer = document.getElementById("MainContent_lblQuestion3DoorsInfoWallAnswer" + wallNumber);

    //Empties the parent control of all child controls
    $("#MainContent_lblQuestion3DoorsInfoWallAnswer" + wallNumber).empty();

    /****DELETE BUTTON CREATION ADDITION****/
    var deleteButton = document.createElement("input");
    deleteButton.id = "btnDeleteDoorFill" + type + "Wall" + wallNumber;
    deleteButton.setAttribute("type", "button");
    deleteButton.setAttribute("value", "Remove Fill");
    deleteButton.setAttribute("onclick", "deleteDoorFill(\"" + type + "\", \"" + wallNumber + "\")");
    deleteButton.setAttribute("class", "btnSubmit");

    /****LABEL FOR DELETE BUTTON****/
    var labelForButton = document.createElement("label");
    labelForButton.id = "lblDeleteDoorFill" + type + "Wall" + wallNumber;
    labelForButton.setAttribute("for", "btnDeleteDoorFill" + type + "Wall" + wallNumber);
    labelForButton.innerHTML = "Wall Filled With " + amountOfDoors + " " + type + " Door Mods";

    /****BR LABEL FOR DELETE BUTTON****/
    var labelBreakLineForButton = document.createElement("label");
    labelBreakLineForButton.id = "lblDeleteDoorFillBR" + type + "Wall" + wallNumber;
    labelBreakLineForButton.setAttribute("for", "btnDeleteDoorFill" + type + "Wall" + wallNumber);
    labelBreakLineForButton.innerHTML = "<br/>";

    /****APPENDING ALL CONTROLS TO PARENT CONTROL****/
    pagerTextDoorAnswer.appendChild(labelForButton);
    pagerTextDoorAnswer.appendChild(deleteButton);
    pagerTextDoorAnswer.appendChild(labelBreakLineForButton);
}

/**
*findCurrentWallHeight
*This function finds the height of the wall at any giving point within it.
*This function is used to ensure a door isn't outside of the limits of the wall.
*@param doors - holds an array of unsorted doors
*@param wall - used to hold the current wall information
*@return - the height at the current position within the current wall
*/
function findCurrentWallHeight(door, wall) {
    if (wall.startHeight > wall.endHeight)
        return ((wall.endHeight + (wall.startHeight - wall.endHeight) * ((door.position + door.fwidth) - wall.length) / (0 - wall.length)));
    else
        return (wall.startHeight + (wall.endHeight - wall.startHeight) * ((door.position + door.fwidth) - wall.length) / (0 - wall.length));
}

/**
*insertDoor
*This function inserts the current door to the appropriate wall and position
*@param doors - holds an array of unsorted doors
*@param wall - used to hold the current wall information
*/
function insertDoor(door, wall) {

    //Variable to hold the index in which position to store the current door
    var position;

    //Loop to find the right index/position to store the door
    for (position = 0; position < wall.doors.length; position++) {
        //If the existing door is larger than the new door, break out of the loop
        if (wall.doors[position].position > door.position) {
            break;
        }
    }

    //Insert the door into the index/position at which the loop breaks out
    wall.doors.insert(position, door);
}

/**
*typeOfRowsDisplayed
*This function finds which type of door is selected and displays the appropriate fields
*from a table hidden from the user
*@param type - gets the type of door selected (i.e. Cabana, French, Patio, Opening Only (No Door))
*@param wallNumber - holds an integer to know which wall is currently being affected
*/
function typeRowsDisplayed(type, wallNumber) {

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
    var doorHingeLHH = document.getElementById("MainContent_rowDoorHingeLHH" + wallNumber + type);
    var doorHingeRHH = document.getElementById("MainContent_rowDoorHingeRHH" + wallNumber + type);
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
    var doorHingeLHHChecked = document.getElementById("MainContent_radDoorHinge" + wallNumber + type);
    var doorSwingInChecked = document.getElementById("MainContent_radDoorSwing" + wallNumber + type);

    //FRENCH/PATIO DOOR ONLY
    var doorOperatorLHHChecked = document.getElementById("MainContent_radDoorOperator" + wallNumber + type);
    /****END:RADIO BUTTONS TO BE CHECKED INITIALLY****/

    //If type is Cabana, display the appropriate fields
    if (type == "Cabana") {

        /****FIELDS TO DISPLAY****/
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
        doorHingeLHH.style.display = "inherit";
        doorHingeRHH.style.display = "inherit";
        doorSwingIn.style.display = "inherit";
        doorSwingOut.style.display = "inherit";
        doorHardware.style.display = "inherit";
        doorPosition.style.display = "inherit";

        //If the value of position drop down is custom, display the appropriate field
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
        doorHingeLHHChecked.setAttribute("checked", "checked");
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

        //If the value of position drop down is custom, display the appropriate field
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

        //If the value of position drop down is custom, display the appropriate field
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

        //If the value of position drop down is custom, display the appropriate field
        if (doorPositionCustom == "cPosition") {
            customDimension(wallNumber, type, "Position");
        }
    }
}

/**
*updateDoorPager
*This function is used to update the pager details based on added or removed (deleted) doors
*@param wall - used to hold the current wall information
*/
function updateDoorPager(wall) {    

    /****PAGER VARIABLES****/    
    var pagerText = document.getElementById("MainContent_lblQuestion3SpaceInfoWall" + wall.id);
    var pagerTextAnswer = document.getElementById("wall" + wall.id + "DoorsAdded");
    var pagerTextDoorAnswer = document.getElementById("MainContent_lblQuestion3DoorsInfoWallAnswer" + wall.id);
    var pagerTextDoor = document.getElementById("MainContent_lblQuestion3DoorsInfoWall" + wall.id);
    var proposedWall = document.getElementById("MainContent_lblTextArea" + wall.id);

    //Update total space left in the wall
    var space = totalSpaceLeftInWall(walls[wall.id]);

    //Empties the parent control of all child controls
    $("#MainContent_lblQuestion3DoorsInfoWallAnswer" + wall.id).empty();

    //If there is a door, perform this block
    if (wall.doors.length > 0) {

        //Block to add content to the pager
        $("#MainContent_lblQuestion3SpaceInfoWallAnswer" + wall.id).text(space);
        document.getElementById("pagerThree").style.display = "inline";
        document.getElementById("wall" + wall.id + "SpaceRemaining").style.display = "inline";
        pagerText.setAttribute("style", "display:block;");
        pagerTextAnswer.setAttribute("style", "display:block");
        pagerTextDoor.innerHTML = "Wall " + (proposedWall.innerHTML).substr(14, 2) + " Doors";

        for (var childControls = 1; childControls <= wall.doors.length ; childControls++) {
            //Rename controls and their attributes
            /****DELETE BUTTON CREATION ADDITION****/
            var deleteButton = document.createElement("input");
            deleteButton.id = "btnDeleteDoor" + childControls + wall.doors[childControls - 1].type + "Wall" + wall.id;
            deleteButton.setAttribute("type", "button");
            deleteButton.setAttribute("value", "X");
            deleteButton.setAttribute("onclick", "deleteDoor(\"" + childControls + "\", \"" + wall.doors[childControls - 1].type + "\", \"" + wall.id + "\")");
            deleteButton.setAttribute("class", "btnSubmit");
            deleteButton.setAttribute("style", "width:24px; height:24px; vertical-align:middle;");

            /****LABEL FOR DELETE BUTTON****/
            var labelForButton = document.createElement("label");
            labelForButton.id = "lblDeleteDoor" + childControls + wall.doors[childControls - 1].type + "Wall" + wall.id;
            labelForButton.setAttribute("for", "btnDeleteDoor" + childControls + wall.doors[childControls - 1].type + "Wall" + wall.id);
            labelForButton.innerHTML = "Door " + childControls + " " + wall.doors[childControls - 1].type + " added";

            /****BR LABEL FOR DELETE BUTTON****/
            var labelBreakLineForButton = document.createElement("label");
            labelBreakLineForButton.id = "lblDeleteDoorBR" + childControls + wall.doors[childControls - 1].type + "Wall" + wall.id;
            labelBreakLineForButton.setAttribute("for", "btnDeleteDoor" + childControls + wall.doors[childControls - 1].type + "Wall" + wall.id);
            labelBreakLineForButton.innerHTML = "<br/>";

            /****APPENDING ALL CONTROLS TO PARENT CONTROL****/
            pagerTextDoorAnswer.appendChild(labelForButton);
            pagerTextDoorAnswer.appendChild(deleteButton);
            pagerTextDoorAnswer.appendChild(labelBreakLineForButton);
        }

    }
        //Else no doors exist, perform this block
    else {
        //Set door pager section display style to none
        document.getElementById("wall" + wall.id + "DoorsAdded").style.display = "none";
        //Update the space in the wall
        $("#MainContent_lblQuestion3SpaceInfoWallAnswer" + wall.id).text(space);
    }
}

/**
*totalSpaceLeftInWall
*This function performs calculations to find the total space left in a wall
*@param wall - used to hold the current wall information
*/
function totalSpaceLeftInWall(wall) {

    //Calculates usable length in the wall
    var totalSpace = wall.length - wall.leftFiller - wall.rightFiller;

    //Loop through all the doors
    for (var wallSpace = 0; wallSpace < wall.doors.length; wallSpace++) {
        //Substract each door from the usable space
        totalSpace -= wall.doors[wallSpace].fwidth;
    }

    //Return the total space remaining
    return totalSpace;
}

/**
*validateDoorParameters
*This function performs validtion of the current door's parameters (height/width)
*@param doors - holds an array of unsorted doors
*@param wall - used to hold the current wall information
*@return - boolean whether validation passed
*/
function validateDoorParameters(door, wall) {
    //If the door type is Cabana check for minimum and maximum height and width
    if (door.type == "Cabana") {
        //If the door frame width is larger than the acceptable size, display error message
        if (door.fwidth > cabanaMaxWidth) {
            alert("Your " + door.type + " door width is " + door.width + "\", the maximum is " + CABANA_MAX_WIDTH + "\" which is largest possible. Please try again.")
            return false;
        }
        //If the door frame width is smaller than the acceptable size, display error message
        if (door.fwidth < cabanaMinWidth) {
            alert("Your " + door.type + " door width is " + door.width + "\", the minimum is " + CABANA_MIN_WIDTH + "\" which is smallest possible. Please try again.")
            return false;
        }
        //If the door frame height is larger than the acceptable size, display error message
        if (door.fheight > cabanaMaxHeight) {
            alert("Your " + door.type + " door height is " + door.height + "\", the maximum is " + CABANA_MAX_HEIGHT + "\" which is largest possible. Please try again.")
            return false;
        }
        //If the door frame height is smaller than the acceptable size, display error message
        if (door.fheight < cabanaMinHeight) {
            alert("Your " + door.type + " door height is " + door.height + "\", the minimum is " + CABANA_MIN_HEIGHT + "\" which is smallest possible. Please try again.")
            return false;
        }
    }
        //If the door type is French check for minimum and maximum height and width
    else if (door.type == "French") {
        //If the door frame width is larger than the acceptable size, display error message
        if (door.fwidth > frenchMaxWidth) {
            alert("Your " + door.type + " door width is " + door.width + "\", the maximum is " + CABANA_MAX_WIDTH * 2 + "\" which is largest possible. Please try again.")
            return false;
        }
        //If the door frame width is smaller than the acceptable size, display error message
        if (door.fwidth < frenchMinWidth) {
            alert("Your " + door.type + " door width is " + door.width + "\", the minimum is " + CABANA_MIN_WIDTH * 2 + "\" which is smallest possible. Please try again.")
            return false;
        }
        //If the door frame height is larger than the acceptable size, display error message
        if (door.fheight > frenchMaxHeight) {
            alert("Your " + door.type + " door height is " + door.height + "\", the maximum is " + CABANA_MAX_HEIGHT + "\" which is largest possible. Please try again.")
            return false;
        }
        //If the door frame height is smaller than the acceptable size, display error message
        if (door.fheight < frenchMinHeight) {
            alert("Your " + door.type + " door height is " + door.height + "\", the minimum is " + CABANA_MIN_HEIGHT + "\" which is smallest possible. Please try again.")
            return false;
        }
    }
        //If the door type is Patio check for minimum and maximum height and width
    else if (door.type == "Patio") {
        //If the door frame width is larger than the acceptable size, display error message
        if (door.fwidth > patioMaxWidth) {
            alert("Your " + door.type + " door width is " + door.width + "\", the maximum is " + PATIO_DOOR_MAX_WIDTH + "\" which is largest possible. Please try again.")
            return false;
        }
        //If the door frame width is smaller than the acceptable size, display error message
        if (door.fwidth < patioMinWidth) {
            alert("Your " + door.type + " door width is " + door.width + "\", the minimum is " + PATIO_DOOR_MIN_WIDTH + "\" which is smallest possible. Please try again.")
            return false;
        }
        //If the door frame height is larger than the acceptable size, display error message
        if (door.fheight > patioMaxHeight) {
            alert("Your " + door.type + " door height is " + door.height + "\", the maximum is " + PATIO_DOOR_MAX_HEIGHT + "\" which is largest possible. Please try again.")
            return false;
        }
        //If the door frame height is smaller than the acceptable size, display error message
        if (door.fheight < patioMinHeight) {
            alert("Your " + door.type + " door height is " + door.height + "\", the minimum is " + PATIO_DOOR_MIN_HEIGHT + "\" which is smallest possible. Please try again.")
            return false;
        }
    }

    if (door.fheight > findCurrentWallHeight(door, wall)) {
        alert("Your " + door.type + " door's height in its current position is higher than the wall. Please try again.")
        return false;
    }

    return true;
}

/**
*validateDoor
*This function performs validtion of the current door on existing doors
*checks for overlaps, out of the wall, etc.
*@param doors - holds an array of unsorted doors
*@param wall - used to hold the current wall information
*@return - boolean whether validation passed
*/
function validateDoor(door, wall) {    

    //If the door's position is smaller than the left filler,
    //the door isn't within the usable space
    if (door.position < wall.leftFiller) {
        //Error message
        alert("Your door position is overlapping the left filler, or is a negative value. Please try again.");
        return false;
    }
        //Else if the door's position plus its length is larger than the right fillers position,
        //the door isn't within the usable space
    else if ((door.position + door.fwidth) > (wall.length - wall.rightFiller)) {
        //Error message
        alert("Your door position is overlapping the right filler, or larger than the wall length. Please try again.");
        return false;
    }

    //Variable to hold the index of which door is being overlapped
    var index;

    //Loop to find the right index to display
    for (index = 0; index < wall.doors.length; index++) {
        if (wall.doors[index].position > door.position) {
            break;
        }
    }

    //If the index value is smaller than the wall.doors arrays length
    //and this door is overlapping the door after it, display the appropriate message
    if (index < wall.doors.length && (door.position + door.fwidth) > wall.doors[index].position) {
        alert("The door you're trying to insert is overlapping door " + (index + 1) + ". Please try again.");
        return false;
    }

    //If the index value is larger than the zero
    //and this door is overlapping the door before it, display the appropriate message
    if (index > 0 && door.position < (wall.doors[index - 1].position + wall.doors[index - 1].fwidth)) {
        alert("The door you're trying to insert is overlapping door " + index + ". Please try again.");
        return false;
    }

    return true;
}

/**
*validateDoorFill
*This function validates doors that are being filled into a wall
*@param doors - holds an array of unsorted doors
*@param wall - used to hold the current wall information
*@returns true or false based on if validation passes
*/
function validateDoorFill(door, wall) {

    if ((wall.length - wall.rightFiller - wall.leftFiller) < door.fwidth) {
        alert("This wall is too small to have a door of width " + door.fwidth + ". Please try again.");
        return false;
    }

    if (wall.doors.length > 0) {
        alert("Fill cannot be used on a wall with existing doors. Please empty the wall first.");
        return false;
    }

    return true;
}


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

    var door = createDoorObject(wallNumber, type);

    if (!validateDoor(door, walls[wallNumber])) {
        return;
    }

    //Update doorMods by sorting most recent addition into previous array
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

    if (type === 'Cabana') {
        return {
            width: (model === 400) ? width + 3.625 : width + 2.125,
            height: (model === 400) ? height + 2.125 : height + 0.875
        };
    }
    else if (type === 'French') {
        return {
            width: (model === 400) ? ((width + 3.625) - 1.625) + 2 : ((width + 2.125) - 1.625) + 2,
            height: (model === 400) ? height + 2.125 : height + 0.875
        };
    }
    else if (type == 'Patio') {
        return {
            width: (model === 400) ? width + 3.625 : width + 2.125,
            height: (model === 400) ? height + 1.625 : height + 1.125
        };
    }
    else {
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

    var dimensionDDL = document.getElementById('MainContent_ddlDoor' + dimension + wallNumber + type).options[document.getElementById('MainContent_ddlDoor' + dimension + wallNumber + type).selectedIndex].value;

    if (document.getElementById('MainContent_radType' + wallNumber + type).checked && dimensionDDL == 'c' + dimension) {
        document.getElementById('MainContent_rowDoorCustom' + dimension + wallNumber + type).style.display = 'inherit';
    }
    else {
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
*/
function createDoorObject(wallNumber, type) {

    var framedDoor;

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

    var customControls = [
        "Kickplate",
        "Height",
        "Width",
        "Position"
    ];

    //Loop to find all visible controls on the slide and get the appropriate controls value
    for (var i = 0; i < controlsArray.length; i++) {
        var styleDropDown = $("#MainContent_" + controlsArray[i] + wallNumber + type);

        if (styleDropDown.closest('tr').filter(':visible').length == 1) {
            var value;
            if (styleDropDown.attr('type') == 'radio') {
                styleValue = styleDropDown.closest('table').find('input[name=\"' + styleDropDown.attr('name') + '\"]:checked').val();
            }
            else {
                value = styleDropDown.val();
            }

            var identifier = controlsArray[i][7].toLowerCase() + controlsArray[i].substr(8);

            if (identifier in framedDoor) {
                framedDoor[identifier] = value;
            }
        }
    }

    //Changes any custom values to the actual value entered
    for (var k = 0; k < customControls.length; k++) {

        var identifier = customControls[k][0].toLowerCase() + customControls[k].substr(1);

        if (!(identifier in framedDoor))
            continue;

        var value = framedDoor[identifier];

        if (value == 'c' + customControls[k]) {
            var valueText = $('#MainContent_txtDoor' + customControls[k] + 'Custom' + wallNumber + type).val();
            var valueDropDown = $('#MainContent_ddlDoor' + customControls[k] + 'Custom' + wallNumber + type).val();

            framedDoor[identifier] = parseFloat(valueText) + parseFloat(valueDropDown);
        }
        else if (identifier != "position") {
            framedDoor[identifier] = parseFloat(framedDoor[identifier]);
        }
    }

    var dimensions = calculateActualDoorDimension(framedDoor.width, framedDoor.height, type);

    framedDoor.fheight = dimensions.height;
    framedDoor.fwidth = dimensions.width;

    /*Insert the door with the appropriate variables based on drop down selected index*/
    if (framedDoor.position === "left") {
        framedDoor.position = walls[wallNumber].leftFiller;
    }
    else if (framedDoor.position === "right") {
        framedDoor.position = walls[wallNumber].length - framedDoor.fwidth - walls[wallNumber].rightFiller;
    }
    else if (framedDoor.position === "center") {
        framedDoor.position = walls[wallNumber].length / 2 - framedDoor.fwidth / 2;
    }

    for (var j = 0; j < customControls.length; j++) {
        var identifier = customControls[j][0].toLowerCase() + customControls[j].substr(1);

        framedDoor[identifier] = parseFloat(framedDoor[identifier]);
    }

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

    var positionInWall = findPosition(walls[wallNumber], doorToDelete);

    //Removes object at specified index
    walls[wallNumber].doors.splice(doorToDelete - 1, 1);

    //Used to redisplay the appropriate space left in the wall
    var space = totalSpaceLeftInWall(walls[wallNumber]);

    //Need to reset pager titles
    $("#MainContent_lblQuestion3SpaceInfoWallAnswer" + wallNumber).text(space);
    updateDoorPager(walls[wallNumber]);
}

/**
*deleteDoorFill
*This function is used to perform certain task when a door fill is deleted (called on click).
*@param type - gets the type of door selected (i.e. Cabana, French, Patio, Opening Only (No Door))
*@param wallNumber - holds an integer to know which wall is currently being affected
*/
function deleteDoorFill(type, wallNumber) {

    walls[wallNumber].doors = [];

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
*doorTransomStyle
*Door transom style function is triggered when the user selects Vinyl or Glass, 
*vinyl or glass tint becomes displayed.
*@param type - gets the type of door selected (i.e. Cabana, French, Patio, Opening Only (No Door));
*@param wallNumber - holds an integer to know which wall is currently being affected
*/
function doorTransomStyle(type, wallNumber) {

    var transomType = document.getElementById('MainContent_ddlDoorTransom' + wallNumber + type).options[document.getElementById('MainContent_ddlDoorTransom' + wallNumber + type).selectedIndex].value;

    if (transomType == 'vinyl') {
        document.getElementById('MainContent_rowDoorTransomVinyl' + wallNumber + type).style.display = 'inherit';
        document.getElementById('MainContent_rowDoorTransomGlass' + wallNumber + type).style.display = 'none';
    }
    else if (transomType == 'glass') {
        document.getElementById('MainContent_rowDoorTransomVinyl' + wallNumber + type).style.display = 'none';
        document.getElementById('MainContent_rowDoorTransomGlass' + wallNumber + type).style.display = 'inherit';
    }
    else {
        document.getElementById('MainContent_rowDoorTransomVinyl' + wallNumber + type).style.display = 'none';
        document.getElementById('MainContent_rowDoorTransomGlass' + wallNumber + type).style.display = 'none';
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

    var door = createDoorObject(wallNumber, type);

    if (type == "NoDoor") {
        door.position = walls[wallNumber].leftFiller;
        var frameSize = door.fwidth - door.width;
        door.fwidth = walls[wallNumber].length - walls[wallNumber].leftFiller - walls[wallNumber].rightFiller;
        door.width = door.fwidth - frameSize;
    }

    if (!validateDoor(door, walls[wallNumber])) {
        return;
    }

    var amountOfDoors = parseInt((walls[wallNumber].length - walls[wallNumber].leftFiller - walls[wallNumber].rightFiller) / door.fwidth);
    var padding = ((walls[wallNumber].length - walls[wallNumber].leftFiller - walls[wallNumber].rightFiller) - (amountOfDoors * door.fwidth)) / 2;
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
    labelForButton.innerHTML = "Wall Filled With " + amountOfDoors + " " + type + " Door Mods";

    var labelBreakLineForButton = document.createElement("label");
    labelBreakLineForButton.id = "lblDeleteDoorFillBR" + type + "Wall" + wallNumber;
    labelBreakLineForButton.setAttribute("for", "btnDeleteDoorFill" + type + "Wall" + wallNumber);
    labelBreakLineForButton.innerHTML = "<br/>";

    pagerTextDoorAnswer.appendChild(labelForButton);
    pagerTextDoorAnswer.appendChild(deleteButton);
    pagerTextDoorAnswer.appendChild(labelBreakLineForButton);
}

/**
*findPosition
*This function is used to perform certain task when a door is deleted (called on click), remove
*controls from pager, reset walls[index].spaces to null and same for walls[index].doorsSorted.
*@param usable - holds the usable length within a wall
*@param doorMods - holds an array of doors which are in order from left to right
*@param indexToCheck - holds an integer of an index in which to get data from doorMods
*@return position - returns a string of the position in which the deleted door belongs to 
*for dropdown purposes (i.e. left, center, right);
*/
function findPosition(wall, indexToCheck) {
    var position = "";

    if (wall.doors[indexToCheck - 1].position == wall.leftFiller)
        position = "left";
    else if (wall.doors[indexToCheck - 1].position == (wall.length / 2 - wall.doors[indexToCheck - 1].fwidth / 2))
        position = "center";
    else if (wall.doors[indexToCheck - 1].position == (wall.length - wall.doors[indexToCheck - 1].fwidth))
        position = "right";
    else
        position = "custom";

    return position;
}

/**
*insertDoor
*This function inserts the current wall to the appropriate wall and position
*@param doors - holds an array of unsorted doors
*@param wall - used to hold the current wall information
*/
function insertDoor(door, wall) {

    var position;

    for (position = 0; position < wall.doors.length; position++) {
        if (wall.doors[position].position > door.position) {
            break;
        }
    }

    wall.doors.insert(position, door);
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
*validateDoorFill
*This function validates doors that are being filled into a wall
*@param doors - holds an array of unsorted doors
*@param wall - used to hold the current wall information
*@returns true or false based on if validation passes
*/
function validateDoorFill(door, wall) {

    if (wall.length < door.fwidth) {
        alert("This wall is too small to have a door of width " + door.fwidth + ". Please try again.");
        return false;
    }

    if (wall.doors.length > 0) {
        alert("Fill cannot be used on a wall with existing doors. Please empty the wall first.");
        return false;
    }

    return true;
}

/**
*updateDoorPager
*This function is used to update the pager details based on added or removed (deleted) doors
*@param wall - used to hold the current wall information
*/
function updateDoorPager(wall) {

    var pagerTextDoorAnswer = document.getElementById("MainContent_lblQuestion3DoorsInfoWallAnswer" + wall.id);

    /****PAGER VARIABLES****/
    var pagerText = document.getElementById("MainContent_lblQuestion3SpaceInfoWall" + wall.id);
    var pagerTextAnswer = document.getElementById("wall" + wall.id + "DoorsAdded");
    var pagerTextDoor = document.getElementById("MainContent_lblQuestion3DoorsInfoWall" + wall.id);
    var proposedWall = document.getElementById("MainContent_lblTextArea" + wall.id);

    //Update total space left in the wall
    var space = totalSpaceLeftInWall(walls[wall.id]);

    $("#MainContent_lblQuestion3DoorsInfoWallAnswer" + wall.id).empty();

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

            var labelForButton = document.createElement("label");
            labelForButton.id = "lblDeleteDoor" + childControls + wall.doors[childControls - 1].type + "Wall" + wall.id;
            labelForButton.setAttribute("for", "btnDeleteDoor" + childControls + wall.doors[childControls - 1].type + "Wall" + wall.id);
            labelForButton.innerHTML = "Door " + childControls + " " + wall.doors[childControls - 1].type + " added";

            var labelBreakLineForButton = document.createElement("label");
            labelBreakLineForButton.id = "lblDeleteDoorBR" + childControls + wall.doors[childControls - 1].type + "Wall" + wall.id;
            labelBreakLineForButton.setAttribute("for", "btnDeleteDoor" + childControls + wall.doors[childControls - 1].type + "Wall" + wall.id);
            labelBreakLineForButton.innerHTML = "<br/>";
            pagerTextDoorAnswer.appendChild(labelForButton);
            pagerTextDoorAnswer.appendChild(deleteButton);
            pagerTextDoorAnswer.appendChild(labelBreakLineForButton);
        }

    }
    else {
        document.getElementById("wall" + wall.id + "DoorsAdded").style.display = "none";
        $("#MainContent_lblQuestion3SpaceInfoWallAnswer" + wall.id).text(space);
    }
}

/**
*totalSpaceLeftInWall
*This function performs calculations to find the total space left in a wall
*@param wall - used to hold the current wall information
*/
function totalSpaceLeftInWall(wall) {

    var totalSpace = wall.length - wall.leftFiller - wall.rightFiller;

    for (var wallSpace = 0; wallSpace < wall.doors.length; wallSpace++) {
        totalSpace -= wall.doors[wallSpace].fwidth;
    }

    return totalSpace;
}

/**
*validateDoor
*This function performs validtion of the current door on existing doors
*checks for overlaps, out of the wall, etc.
*@param doors - holds an array of unsorted doors
*@param wall - used to hold the current wall information
*/
function validateDoor(door, wall) {

    if (door.position < wall.leftFiller) {
        alert("Your door has a negative position. Please try again.");
        return false;
    }
    else if ((door.position + door.fwidth) > (wall.length - wall.rightFiller)) {
        alert("Your door is positioned outside of the walls usable length. Please try again.");
        return false;
    }

    var index;

    for (index = 0; index < wall.doors.length; index++) {
        if (wall.doors[index].position > door.position) {
            break;
        }
    }

    if (index < wall.doors.length && (door.position + door.fwidth) > wall.doors[index].position) {
        alert("The door you're trying to insert is overlapping door " + (index + 1) + ". Please try again.");
        return false;
    }

    if (index > 0 && door.position < (wall.doors[index - 1].position + wall.doors[index - 1].fwidth)) {
        alert("The door you're trying to insert is overlapping door " + index + ". Please try again.");
        return false;
    }

    return true;
}



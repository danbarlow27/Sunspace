/************************************************************************************************************************************
*Author:        Taha Amjad
*Date:          13/08/2013
*Description:   



/************************************************************************************************************************************/


function Window() {
    this.typeMod = "Window";
    this.type = null; //Screen, V4T, H2T, Fixed Vinyl, Fixed Glass, Single Pane, Double Pane [, Open wall, Solid Wall]?
    this.fWidth = null; //frame width
    this.fHeight = null; //frame height
    this.frameColour = null; //White, Driftwood, Bronze, Green, Black, Ivory, Cherrywood, Grey
    this.position = null; //distance from left
    this.tint = null; //Clear, Smoke Grey, Dark Grey, Bronze 
    this.screenType = null; //Better Vue Insect Screen, No See Ums 20x20 Mesh, Solar Insect Screen, Tuff Screen, No Screen 
}

Window.prototype = new Mods();

//screen window = open wall mod with screen groove
//function ScreenWindow() {
//    this.type = "Screen";
//    this.height = null;
//    this.width = null;
//}

//ScreenWindow.prototype = new Window();

function V4TWindow() {
    this.type = "V4T";
    this.height = null;
    this.width = null;
    this.spreaderBar = null; //spreader bar, true or false
} 

V4TWindow.prototype = new Window();

function HorizontalSliderWindow() {
    this.type = "HorizontalSlider";
    this.height = null;
    this.width = null;
    this.spreaderBar = null; //spreader bar, true or false
}

HorizontalSliderWindow.prototype = new Window();

function FixedVinylWindow() {
    this.type = "FixedVinyl";
    this.height = null;
    this.width = null;
}

FixedVinylWindow.prototype = new Window();

function FixedGlassWindow() {
    this.type = "FixedGlass";
    this.height = null;
    this.width = null;
}

FixedGlassWindow.prototype = new Window();

function DoubleSliderWindow() {
    this.type = "DoubleSlider";
    this.height = null;
    this.width = null;
}

DoubleSliderWindow.prototype = new Window();

function SingleSliderWindow() {
    this.type = "SingleSlider";
    this.height = null;
    this.width = null;
}

SingleSliderWindow.prototype = new Window();



function fillWindowsMods() {

    var availableSpaces = new Array();
    var freeSpaceCounter = 0;

    for (var i = 0; i < walls.length; i++) { //for each wall in the list of wall objects
        if (coordList[i][4] === "P") { //if it is a proposed wall
            if (walls[i].mods.length > 0) { //if there is at least 1 door in the wall
                for (var j = 0; j < walls[i].mods.length; j++) {
                    var freeSpace;
                    if (walls[i].mods[j].position > 0) {
                        freeSpace = {
                            "wall": i,
                            "start": walls[i].mods[j].position - 1,
                            "end": walls[i].mods[j].fwidth + 1
                        };
                    }
                    else {
                        freeSpace = {
                            "wall": i,
                            "start": 0,
                            "end": walls[i].mods[j].fwidth + 1
                        };
                    }
                    availableSpaces[freeSpaceCounter] = freeSpace;
                    freeSpaceCounter++;
                }
            }
            else { //no pre-existing mods
                availableSpaces[0] = { "wall": i, "start": walls[i].leftFiller + 1, "end": walls[i].length - walls[i].rightFiller};
            }
        }
    }

    for (var k = 0; k < availableSpaces.length; k++) {
        var availableSpace = availableSpaces[k].end - availableSpaces[k].start;
        var windowSize = MAX_WINDOW_WIDTH;
        //var tryAgain = 1;

        //if (availableSpaces[k] >= MIN_MOD_WIDTH) { //if there's enough space to fit a min size window
        
        validateWindowModSize(availableSpace, windowSize, 1, availableSpaces[k].wall, availableSpaces[k].start); // call the function to find the appropriate size of windows
        
            //while (!validateModSize(availableSpace, (windowSize / tryAgain) + 2, tryAgain, availableSpaces[k].wall), availableSpaces[k].start) { //keep trying until windows fit in the space (with min filler)
            //    tryAgain++; //used to divide the window size by 2 at each try to try smaller window sizes
            //}
        }
    }

function validateWindowModSize(space/*, size, number, wall, start*/) {
    var MIN_MOD_WIDTH = 12;
    var MAX_MOD_WIDTH = 35;
    var windowCounter = 0;
    var finalWindowSize = 0;
    var spaceRemaining = space;

    while (spaceRemaining >= MIN_MOD_WIDTH) {
        if (spaceRemaining >= MAX_MOD_WIDTH) {
            spaceRemaining -= MAX_MOD_WIDTH;
            windowCounter++;
        }
        else if (spaceRemaining < MAX_MOD_WIDTH && spaceRemaining > MIN_MOD_WIDTH) {
            spaceRemaining = 0;
            windowCounter++;
        }
        else if (spaceRemaining == MIN_MOD_WIDTH) {
            spaceRemaining = 0;
            windowCounter++;
        }
    }

    if (spaceRemaining > 0) {
        windowCounter++;
    }

    finalWindowSize = space / windowCounter;
    spaceRemaining = 0;

    alert("Sizes: " + finalWindowSize + ", NumberOfWindows: " + windowCounter + ", Filler Remaining: " + spaceRemaining);


    //if (space >= MIN_MOD_WIDTH) {
    //    if (size > space) {
    //        size = size / 2;
    //        validateWindowModSize(space, size, number, wall, start);
    //    }
    //    else if (size < space) {
    //        var tempSize = validateDecimal(size); //make sure the size is 
    //        while (tempSize < space) {
    //            var multiplier = 1;
    //            tempSize = size * multiplier;
    //            multiplier++;
    //            if (tempSize === space) {
    //                fillMods(tempSize, multiplier, wall, 0, start);
    //            }
    //            else if (tempSize > space) {
    //                validateWindowModSize(space, tempSize, multiplier, wall, start);
    //            }
    //            else if ((space - tempSize) <= MIN_MOD_WIDTH) {
    //                fillMods(tempSize, number, wall, space - tempSize, start);
    //            }
    //        }
    //    }
    //    else { //size === space
    //        fillMods(tempSize, multiplier, wall, 0, start);
    //    }
    //}
    //else { //space < MIN_MOD_SIZE
    //    fillFiller(space, wall, start);
    //}
}


function fillMods(size, number, wall, filler, start) {
    var mod;

    if (filler > 0)
        fillFiller(filler / 2, wall, start);

    for (var i = 0; i < number; i++) {
        mod = {
            type: "Window",
            width: size / number,
            wall: wall,
            startHeight: findCurrentWallHeight(start + (filler / 2), wall),
            endHeight: findCurrentWallHeight(start + (filler / 2) + (size / number), wall),
            position: start + (filler / 2),
            kneewallType: kneewallType,
            kneewallHeight: kneewallHeight,
            transomType: transomType,
            transomHeight: transomHeight,
            window: []
        }
        start = start + (size / number);



        insertMod(mod, walls[wall]);
    }

    if (filler > 0)
        fillFiller(filler / 2, wall, start);
}

function fillFiller(filler, wall, start) {
    var mod;

    mod = {
        type: "Filler",
        width: filler,
        wall: wall,
        startHeight: findCurrentWallHeight(start, wall),
        endHeight: findCurrentWallHeight(start + filler, wall),
        position: start
    }
    insertMod(mod, walls[wall]);
}


/************************************************************************************************************************************/
/************************************************************************************************************************************/
/************************************************************************************************************************************/

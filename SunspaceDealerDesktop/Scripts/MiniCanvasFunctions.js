/*********************CANVAS FUNCTIONS*********************************/



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
    else if (coordList[i][4] == "G") {
        lineArray[i].attr("stroke", "green"); //if existing wall, make line red
        lineArray[i].attr("stroke-width", 3);
    }
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
        else if (coordList[i][4] == "G") {
            lineArray[i].attr("stroke", "green"); //if existing wall, make line red
            lineArray[i].attr("stroke-width", 3);
        }
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
            if (southWalls[i].y2 < northWalls[j].y2) {
                southIsHigher = false; //north is higher
                backWall = "north";
            }
            else {
                southIsHigher = true;
                backWall = "south";
            }
        }
    }

    if (wall == "B") { //if the textbox in focus is backwall textbox
        var lowestWall = 500; //arbitrary number to determine back wall (number represents value of coordinate, low number means top of canvas)
        
        for (var i = 0; i < coordList.length; i++) {
            if (coordList[i][5] === "N" || coordList[i][5] === "S") {
                if (coordList[i][2] < lowestWall) {
                    lowestWall = coordList[i][2];
                    index = i; 
                }
            }
        }
        //if (southIsHigher) {
        //    index = getBackWall(southWalls, northWalls, southIsHigher); //get the index of the backwall
        //}
        //else { //northwall is higher
        //    index = getBackWall(southIsHigher, northWalls, southIsHigher);
        //}
    }
    else { //if (wall == "F") //if the textbox in focus is frontwall textbox
        if (southWalls[southWalls.length - 1].type === "P") { //check if the front wall is a proposed walls
            index = backWallIndex = getFrontWall(southWalls); //if its a proposed wall, get its index
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

String.prototype.contains = function (stringToFind) { return this.indexOf(stringToFind) != -1; };

function highlightWallsHeightGable() {
    var controlString = document.activeElement.id;
    var indexToUse;

    if (controlString.contains("Left")) {
        for (var i = 0; i < lineList.length; i++) {
            if (coordList[i][4] == "P" && (coordList[i][0] == coordList[i][1])) {
                for (var k = 0; k < lineList.length; k++) {
                    if (coordList[i] != coordList[k] && coordList[i][0] < coordList[k][0]) {
                        indexToUse = i;
                    }
                }
            }
        }        
    }
    else if (controlString.contains("Right")) {
        for (var i = 0; i < lineList.length; i++) {
            if (coordList[i][4] == "P" && (coordList[i][0] == coordList[i][1])) {
                for (var k = 0; k < lineList.length; k++) {
                    if (coordList[i] != coordList[k] && coordList[i][0] > coordList[k][0]) {
                        indexToUse = i;
                    }
                }
            }
        }
    }
    else if (controlString.contains("Gable")) {
        for (var i = 0; i < lineList.length; i++) {
            if (coordList[i][4] == "G" && (coordList[i][0] != coordList[i][1])) {
                for (var k = 0; k < lineList.length; k++) {
                    if (coordList[i] != coordList[k] && coordList[i][0] > coordList[k][0]) {
                        indexToUse = i;
                    }
                }
            }
        }
    }
    lineArray[indexToUse].attr("stroke", "cyan");
    lineArray[indexToUse].attr("stroke-width", "5");
}

///**
//This function is used to determine the back wall index
//@param southWalls - the array of all south facing walls
//@param northWalls - the array of all north facing walls
//@param southIsHigher - used to determine which wall array to use
//@return lowestIndex - index of the top most south facing wall on the canvas, i.e. the back wall
//*/
//function getBackWall(southWalls, northWalls, southIsHigher) {
//    var lowestWall = 500; //arbitrary number to determine back wall (number represents value of coordinate, low number means top of canvas)
//    var lowestIndex; //to store the index of the back wall

//    for (var i = 0; i < coordList.length; i++) {
//        if (coordList[i][5] === "N" || coordList[i][5] === "S") {
//            if (coordList[i][2] < lowestWall) {
//                lowestWall = coordList[i][2];
//                lowestIndex = i;
//            }
//        }
//    }

//    if (southIsHigher) {
//        //for (var i = 0; i < southWalls.length; i++) { //run through all south facing walls
//        //    if (southWalls[i].y2 > lowestWall) { //if the y2 coordinate of the current wall is higher than the value of lowest wall
//        //        lowestWall = southWalls[i].y2; //that means we have a new lowest coordinate
//        //        lowestIndex = southWalls[i].number; //store the index of the wall
//        //    }
//        //}
//        backWall = "south";
//    }
//    else { //northishigher
//        //for (var i = 0; i < northWalls.length; i++) { //run through all south facing walls
//        //    if (northWalls[i].y2 > lowestWall) { //if the y2 coordinate of the current wall is higher than the value of lowest wall
//        //        lowestWall = northWalls[i].y2; //that means we have a new lowest coordinate
//        //        lowestIndex = northWalls[i].number; //store the index of the wall
//        //    }
//        //}
//        backWall = "north"
//    }

//    return backWallIndex = lowestIndex; //return the index of the lowest wall found, i.e. wall that's nearest to the top of canvas
//}

/**
This function is used to determine the front wall index
@param southWalls - the array of all south facing walls
@return highestIndex - index of the bottom most south facing wall on the canvas, i.e. the front wall
*/
function getFrontWall(southWalls) {
    var highestWall = 0; //arbitrary number to determine back wall (number represents value of coordinate, low number means top of canvas)
    var highestIndex; //to store the index of the back wall

    for (var i = 0; i < coordList.length; i++) {
        if (coordList[i][5] === "N" || coordList[i][5] === "S") {
            if (coordList[i][2] > highestWall) {
                highestWall = coordList[i][2];
                highestIndex = i;
            }
        }
    }


    //for (var i = 0; i < southWalls.length; i++) { //run through all south facing walls
    //    if (coordList[southWalls[i].number][4] == "P") {
    //        if (southWalls[i].y2 < highestWall) { //if the y2 coordinate of the current wall is lower than the value of highest wall
    //            highestWall = southWalls[i].y2; //that means we have a new highest coordinate
    //            highestIndex = southWalls[i].number; //store the index of the wall
    //        }
    //    }

    //}
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

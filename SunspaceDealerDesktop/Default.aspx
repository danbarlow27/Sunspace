<%@ Page Title="Custom Drawing Tool" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SunspaceDealerDesktop._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
               
            </hgroup>
            
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    
        <div id="buttons" style="width:20%; text-align:right; vertical-align:central; float:left; padding-top:10%">
            <ol>
                <li><input class="btnSubmit" type="button" value ="Undo" onclick="undo(true)" style="width:150px"/></li>

                <li><input class="btnSubmit" type="button" value ="Redo" onclick="redo()" style="width:150px"/></li>

                <li><input class="btnSubmit" type="button" value ="Clear Canvas" onclick ="clearCanvas()" style="width:150px"/></li>

                <li><input id="buttonDone" class="btnSubmit" type="button" value ="" onclick="buttonDoneOnClick()" style="width:150px"/></li>

            </ol>
        </div>
        <div style="max-width:500px; max-height:500px; min-width:100px; min-height:100px; float:left;" id="mySunroom"></div>
        <div style="width:20%; float:right; padding-right:10%;" >
            <textarea id="drawingLog" rows="31" cols="30" style="resize:none; border:0px;" readonly></textarea>
        </div>

    <input type="hidden" id="hiddenVar" runat="server" />
    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click1" />
         

    <script>
       
        //wall type enumeration
        var WALL_TYPE = {
            EXISTING: "E",
            PROPOSED: "P",
            INTERNAL: "I"
        }

        //wall facing enumeration
        var WALL_FACING = {
            SOUTH: 0,
            SOUTH_WEST: 1,
            WEST: 2,
            NORTH_WEST: 3,
            NORTH: 4,
            NORTH_EAST: 5,
            EAST: 6,
            SOUTH_EAST: 7
        }

        //minimum number of walls that makes up a complete sunroom
        var MIN_NUMBER_OF_WALLS = 3;
        
        //size of the squares in the grid
        var GRID_PADDING = 25;

        var CELL_PADDING = GRID_PADDING / 2; //cell padding is half less than the grid padding

        //max size of canvas (width and height)
        var MAX_CANVAS_WIDTH = 500;

        //create the canvas
        var canvas = d3.select("#mySunroom") 
                    .append("svg")
                    .attr("width", MAX_CANVAS_WIDTH)
                    .attr("height", MAX_CANVAS_WIDTH);

        //Variable to hold all child elements which has all the array information
        //var hiddenParent = document.getElementById("MainContent_hiddenVar");

        //variable to hold textarea tag
        var log = document.getElementById("drawingLog");

        //create the svg grid on the canvas
        var svgGrid = document.getElementById("mySunroom");

        //store the "Done" button in a variable for use in multiple functions
        var doneButton = document.getElementById("buttonDone");

        //true or false based on whether the user chose standalone or not in the wizard
        var standAlone = false;//confirm("standalone?");

        //keep track of track of click count (to be reset when the user is done drawing a type of wall)
        var startNewWall = true; 

        //an array of removed lines, for use in "redo" function
        var removed = new Array();
        
        //an array of lines drawn
        var coordList = new Array();

        //coordinates of a given line
        var x1, y1, x2, y2;

        //type of wall currently being drawn
        var wallType = WALL_TYPE.EXISTING;

        //Used to validate first walls, also after dblclick and E
        var validateFirstWall = false;

        //function appendChildToParent(){
        //    var child = document.createElement("child1");
        //    child.setAttribute("id", "child0");
        //    child.innerHTML = coordList[0].id;
        //   hiddenVar.appendChild(child);
        //}

        //when the DOM is loaded...
        $(document).ready(function () {
            drawGrid(); //Draws the initial grid
            window.onload = buttonDoneOnLoad(); //load the default text on the "Done" button depending on whether the user chose standAlone or not
            log.innerHTML += "Please draw an existing wall.\n\nPress 'E' to end a line.\n\n";
        });
        
        //On keypress "e" start new line on the grid
        $(document).on('keypress', function (e) { if (e.which === 101) { startNewWall = true; }});

        //set the name (value) of the "Done" button to the default value
        function buttonDoneOnLoad() {
            document.getElementById("buttonDone").value = (standAlone) ? "Done Proposed Walls" : "Done Existing Walls";
        }

        //on click event of "Done" button
        function buttonDoneOnClick() {
            //if user wants to finish drawing existing walls
            if (doneButton.value === "Done Existing Walls") {
                
                //if there are walls drawn and first wall is wall type "E"
                if (coordList.length > 0 && coordList[0].id === WALL_TYPE.EXISTING) {
                    //change the name (value) of the button
                    doneButton.value = "Done Proposed Walls";
                    //change wall type
                    wallType = WALL_TYPE.PROPOSED;
                    //reset click count
                    startNewWall = true;
                }
                //if walltype is not "E", means they have not drawn any existing walls
                else
                    //show error message
                    log.innerHTML += "No existing walls drawn, please draw one\n\n";
            }
            //if user wants to finish drawing external (i.e. proposed) walls
            else if (doneButton.value === "Done Proposed Walls") {
                //if its a valid sunroom
                if (sunroomCompleted()) { // && wallType === WALL_TYPE.PROPOSED                    
                    //change the name (value) of the button
                    doneButton.value = "Done Drawing";
                    //change wall type
                    //wallType = WALL_TYPE.INTERNAL;
                    //reset click count
                    startNewWall = true;
                }
            }

            else if (doneButton.value === "Done Drawing") {
                
                //appendChildToParent();
                
                var lineInfo = "";

                for (var i = 0; i < coordList.length; i++) {
                    lineInfo += coordList[i].x1 + ",";
                    lineInfo += coordList[i].x2 + ",";
                    lineInfo += coordList[i].y1 + ",";
                    lineInfo += coordList[i].y2 + ",";
                    lineInfo += coordList[i].id + ",";
                    lineInfo += coordList[i].orientation + "/";
                }
                console.log(lineInfo);
                document.getElementById("MainContent_hiddenVar").value = lineInfo;
            }
    
        }



        //clear canvas
        function clearCanvas() {
            d3.selectAll("#E").remove(); //remove existing walls
            d3.selectAll("#P").remove(); //remove proposed walls
            //d3.selectAll("#I").remove(); //remove internal walls
            startNewWall = true; //let the user begin another wall anywhere on the grid
            coordList = new Array(); //clear the list of lines
            removed = new Array(); //clear the list of removed lines
            wallType = WALL_TYPE.EXISTING; //reset the wall type to existing
            setButtonValue(); //set button value
       }


        //change the name (value) of the done button
        function setButtonValue() {
            doneButton.value = (coordList[coordList.length-1].id === WALL_TYPE.EXISTING) ? "Done Existing Walls" :
                (coordList[coordList.length-1].id === WALL_TYPE.PROPOSED) ? "Done Proposed Walls" : "Done Drawing";
        }

        /**undo last line
        @param toBeRemoved - true or false whether we want to remove the last element from the removed line list
        */
        function undo(toBeRemoved) {

            //if last line is removed, enable user to draw a line anywhere
            if (coordList.length === 0)
                startNewWall = true;
            else { //set the first coordinates of the next line to the last coordinates of the previous line
                //remove previously drawn walls
                d3.selectAll("#E").remove(); //remove existing walls
                d3.selectAll("#P").remove(); //remove proposed walls

                //if removed array needs to be popped at the end
                if (toBeRemoved)
                    removed.push(coordList[coordList.length - 1]); //pop it

                //set the appropriate button value
                setButtonValue();

                //delete last line from the list
                coordList.pop();

                //go through the list of lines, set wall type, and draw the lines
                for (var i = 0; i <= coordList.length - 1; i++) {
                    wallType = (coordList[i].id === WALL_TYPE.EXISTING) ? WALL_TYPE.EXISTING : WALL_TYPE.PROPOSED;

                    drawLine(coordList[i].x1, coordList[i].y1, coordList[i].x2, coordList[i].y2, false);
                }

                //set the starting coordinates of the next line to be drawn to the ending coordinates of the previous line drawn
                x1 = coordList[coordList.length - 1].x2;
                y1 = coordList[coordList.length - 1].y2;
            }

        }

        //redo last undo
        function redo() {
            
            //If an item exist within the removed array proceed with logic
            if (removed.length != 0) {
                
                //Change the wall type based on the id of the last element in the removed array
                wallType = (removed[removed.length - 1].id === WALL_TYPE.EXISTING) ? WALL_TYPE.EXISTING : WALL_TYPE.PROPOSED;
  

                //Add the last item in the removed array to the coordList array
                coordList.push(removed[removed.length - 1]);
                //Remove the last item in the removed array
                removed.pop();

                //Draw the last element in the coordList array
                drawLine(coordList[coordList.length - 1].x1, coordList[coordList.length - 1].y1, coordList[coordList.length - 1].x2, coordList[coordList.length - 1].y2, false);

                //Set the initial coordinates to the x2 and y2 coordinates of the last element in the coordList array
                x1 = coordList[coordList.length - 1].x2;
                y1 = coordList[coordList.length - 1].y2;

                //Call setButtonValue function to set the button text
                setButtonValue();
            }
        }

        //Draw the grid lines
        function drawGrid() {

            //Creates rectangle area to draw in based on max canvas dimensions
            var rect = canvas.append("rect")
                        .attr("width", MAX_CANVAS_WIDTH)
                        .attr("height", MAX_CANVAS_WIDTH)
                        .attr("fill", "white")

            //Draws left border line of canvas
            var line = canvas.append("line")
                        .attr("x1", 0)
                        .attr("y1", 0)
                        .attr("x2", 0)
                        .attr("y2", MAX_CANVAS_WIDTH)
                        .attr("stroke", "black");

            //Draws top border line of canvas
            var line = canvas.append("line")
                        .attr("x1", 0)
                        .attr("y1", 0)
                        .attr("x2", MAX_CANVAS_WIDTH)
                        .attr("y2", 0)
                        .attr("stroke", "black");

            //Draws bottom border line of canvas
            var line = canvas.append("line")
                        .attr("x1", 0)
                        .attr("y1", MAX_CANVAS_WIDTH)
                        .attr("x2", MAX_CANVAS_WIDTH)
                        .attr("y2", MAX_CANVAS_WIDTH)
                        .attr("stroke", "black");

            //Draws right border line of canvas
            var line = canvas.append("line")
                        .attr("x1", MAX_CANVAS_WIDTH)
                        .attr("y1", 0)
                        .attr("x2", MAX_CANVAS_WIDTH)
                        .attr("y2", MAX_CANVAS_WIDTH)
                        .attr("stroke", "black");

            //Draws vertical lines of the grid onto the canvas
            for (var i = 0; i < MAX_CANVAS_WIDTH; i += GRID_PADDING) {
                var line = canvas.append("line")
                        .attr("x1", i + GRID_PADDING)
                        .attr("y1", 0)
                        .attr("x2", i + GRID_PADDING)
                        .attr("y2", MAX_CANVAS_WIDTH)
                        .attr("stroke", "grey");
            }

            //Draws horizontal lines of the grid onto the canvas
            for (var i = 0; i < MAX_CANVAS_WIDTH; i += GRID_PADDING) {
                var line = canvas.append("line")
                        .attr("x1", 0)
                        .attr("y1", i + GRID_PADDING)
                        .attr("x2", MAX_CANVAS_WIDTH)
                        .attr("y2", i + GRID_PADDING)
                        .attr("stroke", "grey");
            }

        }
        //end of grid

        //Gets the current mouse position on the canvas/grid
        function getMousePos(myCanvas, evt) {
            //Get the coordinates within the canvas/grid
            var rect = myCanvas.getBoundingClientRect();
            return {
                //return x and y coordinates of the mouse within the canvas/grid
                x: evt.clientX - rect.left,
                y: evt.clientY - rect.top
            };
        };

        //svgGrid.addEventListener("dblclick",
        //function (evt) {
        //    startNewWall = true;
        //},
        //false);

        //On click event listener for the canvas/grid
        svgGrid.addEventListener("click",
        function (evt) {
            //Variable to hold the values return by getMousePos. X and Y coordinates within the canvas/grid
            var mousePos = getMousePos(svgGrid, evt);

            //console.log("array length: " + coordList.length);

            //If startNewWall is true, set the first pair of coordinates to the current mouse position
            //Used to define when the first click of on the canvas and reset removed array elements
            if (startNewWall === true) {
                x1 = mousePos.x;
                y1 = mousePos.y;

                //Set startNewWall to false to find logic to complete line coordinates
                startNewWall = false;

                //Delete all entries into removed array
                removed = new Array();

                if (!standAlone && coordList.length != 0 && wallType === WALL_TYPE.PROPOSED)
                    validateFirstWall = true;

            }
                //Logic for clicks after initial click to draw lines and store values into an array
            else {
                //Find 2nd pair of coordinates based on current mouse position within the canvas/grid
                x2 = mousePos.x;
                y2 = mousePos.y;

                //Draw the line and store the line into a variable named "line"
                var line = drawLine(x1, y1, x2, y2, false);

                //Find the orientation in string format to be stored into the array to be passed to C# classes
                var stringOrientation = getStringOrientation(line.attr("x1"), line.attr("y1"), line.attr("x2"), line.attr("y2"));

                //Store line starting and ending coordinates, along with line id and string orientation
                coordList[coordList.length] = { "x1": line.attr("x1"), "y1": line.attr("y1"), "x2": line.attr("x2"), "y2": line.attr("y2"), "id": line.attr("id"), "orientation": stringOrientation};
    
                //Validate
                if(!standAlone && validateFirstWall && coordList[coordList.length-1].id === WALL_TYPE.PROPOSED){
                    validateNotStandAlone(false);
                    validateFirstWall = false;
                }

                //Restart the start position for the next line to be drawn
                x1 = coordList[coordList.length - 1].x2;
                y1 = coordList[coordList.length - 1].y2;
            }
        },
        false);

        //Mouse mouse event listener for the canvas/grid
        svgGrid.addEventListener("mousemove",
        function (evt) {
            //Store mouse coordinates from within the canvas/grid into a variable named mousePos
            var mousePos = getMousePos(svgGrid, evt);
            //Store the lines 2nd pair of coordinates into variables
            x2 = mousePos.x;
            y2 = mousePos.y;

            //Remove all lines from the canvas/grid with the id "mouseMoveLine"
            d3.selectAll("#mouseMoveLine").remove();

            //If startNewWall is false, draw the line on mouse move event
            //This will occur after the first initial of every wall type (Existing Walls, Proposed Walls, Internal Walls)
            if (!startNewWall)
                drawLine(x1, y1, x2, y2, true);
        },
        false);

        //Mouse out event listener for the canvas/grid
        svgGrid.addEventListener("mouseout",
        function (evt) {
            //Remove all lines on the canvas/grid with the id "mouseMoveLine"
            d3.selectAll("#mouseMoveLine").remove();
        },
        false);

        /**
        *Draw line function takes in coordinates and a boolean to draw lines based on these arguments
        *@param x1 - first x coordinate of current line
        *@param y1 - first y coordinate of current line
        *@param x2 - second x coordinate of current line
        *@param y2 - second y coordinate of current line
        *@param mouseMove - boolean used to give an id to lines between drawn on mouse move event
        *@return line - returns line object and all its attributes
        */
        function drawLine(x1, y1, x2, y2, mouseMove) {
            var coordinates = setGridPoints(snapToGrid(x1, CELL_PADDING), snapToGrid(y1, CELL_PADDING), snapToGrid(x2, CELL_PADDING), snapToGrid(y2, CELL_PADDING));

            //Variables to hold starting/ending validated coordinates
            var coorx1 = coordinates.x1;
            var coorx2 = coordinates.x2;
            var coory1 = coordinates.y1;
            var coory2 = coordinates.y2;

            //Variables to hold the difference between the ending and starting points of x and y axes
            var dY = coory2 - coory1;
            var dX = coorx2 - coorx1;

            //if (!mouseMove)
            //   console.log(coorx2 + "," + coory2);

            //

            //If logical to check if the x2 value is outside of the right side of canvas/grid
            if (coorx2 > MAX_CANVAS_WIDTH) {
                //Set x2 coordinate value to the maximum size of the canvas/grid
                coorx2 = MAX_CANVAS_WIDTH;
                //Set y2 coordinate according to the x2,x1,y1 and slope
                coory2 = (dY / dX) * (coorx2 - coorx1) + coory1;
            }
                //If logical to check if the x2 value is outside of the left side of canvas/grid
            else if (coorx2 < 0) {
                //Set x2 coordinate to the minimum size of the canvas/grid
                coorx2 = 0;
                //Set y2 coordinate according to the x2,x1,y1 and slope
                coory2 = coory1 + (dY / dX) * (coorx2 - coorx1);
            }

            //if (!mouseMove)
            //    console.log(coorx2 + "," + coory2);

            //Local variable to store all the line information
            var line = canvas.append("line")
                    .attr("x1", coorx1)
                    .attr("y1", coory1)
                    .attr("x2", coorx2)
                    .attr("y2", coory2);

            //alert(wallType);

            //If wall type is existing do following logic
            if (wallType === WALL_TYPE.EXISTING) {
                //Make line id E for existing wall                
                line.attr("id", "E")
                    //Change the line color to red
                    .attr("stroke", "red")
                    //Make stroke width to 2
                    .attr("stroke-width", 2);                    
            }
                //If wall type is proposed do following logic
            else if (wallType === WALL_TYPE.PROPOSED) {
                //Make line id P for proposed wall
                line.attr("id", "P")
                    //Change the line color to black
                    .attr("stroke", "black")
                    //Make stroke width to 2
                    .attr("stroke-width", 2);
            }

            //If logic to change line id on mousemove event, if mouseMove is true
            if (mouseMove)
                line.attr("id", "mouseMoveLine");

            //Return the line
            return line;
        };

        /**
        *Find line orientation (string format)
        *@param x1 - first x coordinate of current line
        *@param y1 - first y coordinate of current line
        *@param x2 - second x coordinate of current line
        *@param y2 - second y coordinate of current line
        *@return orientation - variable containing compass direction (N, NE, E, SE, S, SW, W, NW)
        */
        function getStringOrientation(x1, y1, x2, y2) {
            //Variable to hold difference between x2 and x1 values
            var dX = x2 - x1;
            //Variable to hold difference between y2 and y1 values
            var dY = y2 - y1;
            //Variable to get orientation value, from 0 to 7
            var orientation = getOrientation(dX, dY);

            //Switch case on orientation values, from 0 to 7
            switch (orientation) {
                //Case when orientation is 0, set orientation to "S"
                case WALL_FACING.SOUTH:
                    orientation = "S";
                    break;
                //Case when orientation is 4, set orientation to "N"
                case WALL_FACING.NORTH:
                    orientation = "N";
                    break;
                //Case when orientation is 1, set orientation to "SW"
                case WALL_FACING.SOUTH_WEST:
                    orientation = "SW";
                    break;
                //Case when orientation is 5, set orientation to "NE"
                case WALL_FACING.NORTH_EAST:
                    orientation = "NE";
                    break;
                //Case when orientation is 2, set orientation to "W"
                case WALL_FACING.WEST:
                    orientation = "W";
                    break;
                //Case when orientation is 6, set orientation to "E"
                case WALL_FACING.EAST:
                    orientation = "E";
                    break;
                //Case when orientation is 3, set orientation to "NW"
                case WALL_FACING.NORTH_WEST:
                    orientation = "NW";
                    break;
                //Case when orientation is 7, set orientation to "SE"
                case WALL_FACING.SOUTH_EAST:
                    orientation = "SE";
                    break;
            }

            return orientation;
        }

        /**
        *Find line orientation (number)
        *@param dX - difference between the x coordinates of a line
        *@param dY - difference between the y coordinates of a line
        *@return - returns a value from 0 to 7 which determines which direction the line is going
        */
        function getOrientation(dX, dY) {    
            return ((Math.round(Math.atan2(dY, dX) / (Math.PI / 4))) + 8) % 8;
        }

        /**
        *Sets the line to 45 degrees or straight line
        *@param x1 - first x coordinate of current line
        *@param y1 - first y coordinate of current line
        *@param x2 - second x coordinate of current line
        *@param y2 - second y coordinate of current line
        *@return - an object which contains starting and ending coordinates for a valid line
        */
        function setGridPoints(x1, y1, x2, y2) {
            /**
            *Finds the sign value for the axes differences
            *@param val - difference between axes values (i.e. dX = (x2-x1))
            *@return - positive or negative 1 to assign the direction to coordinates (i.e. -1 or 1)
            */
            function sign(val) { return Math.abs(val) / val; }

            var dX, dY;
            var length;
            var orientation;

            //Calculates the difference between x values of the current line
            dX = x2 - x1;
            //Calculates the difference between y values of the current line
            dY = y2 - y1;
            //Find the orientation value (0 to 7)
            orientation = getOrientation(dX, dY);

            //Switch case to handle line direction based off of orientation value
            switch (orientation) {
                //Switch case when orientation is 0 or 4
                case WALL_FACING.SOUTH:
                case WALL_FACING.NORTH:
                    //Changes y2 equal to y1, creates horizontal line
                    y2 = y1;
                    break;
                //Switch case when orientation is 1 or 5
                case WALL_FACING.SOUTH_WEST:
                case WALL_FACING.NORTH_EAST:
                    //Changes y2 to create a 45 degree line
                    y2 = y1 + sign(dY) * Math.abs(dX);
                    break;
                //Switch case when orientation is 2 or 6
                case WALL_FACING.WEST:
                case WALL_FACING.EAST:
                    //Changes x2 equal to x1, creates vertical line
                    x2 = x1;
                    break;
                //Switch case when orientation is 3 or 7
                case WALL_FACING.NORTH_WEST:
                case WALL_FACING.SOUTH_EAST:
                    //Changes x2 to create a 45 degree line
                    x2 = x1 + sign(dX) * Math.abs(dY);
                    break;
            }            

            return {
                //Returns valid x1,y1,x2,y2 values
                'x1': x1,
                'y1': y1,
                'x2': x2,
                'y2': y2
            };
        };

        /**
        *Validates lines to see that the sunroom has been closed and snaps lines to their assumed end points
        *@return isValid - boolean to say whether the room is valid or not
        */
        function sunroomCompleted() {
            //Variable to say whether or not the sunroom is valid
            var isValid = false;
            //If logic to see that at least 1 wall exist
            if (coordList.length < MIN_NUMBER_OF_WALLS)
                //Alert to tell the user there current error
                log.innerHTML += "A complete sunroom must be enclosed (3 walls minimum). Please try again!\n\n";
                //Else if to check for standAlone rooms and if the room is closed
            else if (standAlone && coordList[coordList.length - 1].attr("x2") != coordList[0].x1)
                //Alert to tell the user there current error
                log.innerHTML += "A stand-alone sunroom must end at the start of the starting wall. Please try again!\n\n";
                //Else if logic to check for non-standAlone rooms
            else if (!standAlone) {
                //Assign isValid the value returned by validateNotStandAlone()
                isValid = validateNotStandAlone(true);
            }
                //Else, sunroom is ok, isValid is set to true
            else
                isValid = true;

            //return isValid based on above logic
            return isValid;
            }

        /**
        function to validate external walls when its not a standAlone sunroom
        @return isValid - true or false depending on whether the wall is drawn properly or not
        */
        function validateNotStandAlone(lastWall) {



            //array of calculated distances to determine the shortest distance
            var distanceBetweenLines = new Array();            

            //for storing the shortest calculated distance
            var shortest = 0;

            //true or false depending on whether the drawn wall is valid
            var isValid = false;

            //to store the wall number of the wall with shortest distance to the intercept
            var shortestDistanceWallNumber;


            //Needs functionality to handle existing wall corners
            
            //run through the list of lines
            for (var i = 0; i < coordList.length; i++) {
                //if it is an existing wall...
                if (coordList[i].id === WALL_TYPE.EXISTING) {

                    //find intercept
                    var intercept = findIntercept(i);

                    //if determinant is 0 means its a parallel line, meaning no intercept
                    if (intercept.det === 0) {
                        //alert("Sunroom must be enclosed. Please add another wall.");
                        //isValid = false;
                    }
                    else {//there is an intercept
                        isValid = true; //thus valid

                        //calculate the distance between the end of the last proposed line and the intercept
                        distanceBetweenLines[distanceBetweenLines.length] = { "distance": Math.sqrt(Math.pow((intercept.x - coordList[coordList.length - 1].x2), 2) + Math.pow((intercept.y - coordList[coordList.length - 1].y2), 2)), "x": intercept.x, "y": intercept.y };
                    }
                }
            }
                            //determine the shortest distance between all the intercepts
                            shortest = MAX_CANVAS_WIDTH; //arbitrary long number for getting at the shortest distance

                            //loop through all the lines and determine the shortest distance
                            for (var j = 0; j < distanceBetweenLines.length; j++) {
                                //if the calculated distance is less than the shortest distance...
                                if (distanceBetweenLines[j].distance < shortest) {
                                    shortest = distanceBetweenLines[j].distance; //set shortest distance to the calculated distance
                                    shortestDistanceWallNumber = j; //store the wall number for the shortest distance                                    
                                }
                            }

                            if(shortest != 0) {
                    
                                //undo the last drawn line, to be redrawn properly (i.e. snapped to the coordinate)
                                undo(false);

                                if(lastWall)
                                    //draw the snapped line
                                    var line = drawLine(intercept.x1, intercept.y1, distanceBetweenLines[shortestDistanceWallNumber].x, distanceBetweenLines[shortestDistanceWallNumber].y, false);
                                else{
                                    wallType = WALL_TYPE.PROPOSED;
                                    //coordList[coordList.length-1].attr("id","P");
                                    var line = drawLine(distanceBetweenLines[shortestDistanceWallNumber].x, distanceBetweenLines[shortestDistanceWallNumber].y, intercept.x2, intercept.y2, false);
                                    
                                    //var stringOrientation = getStringOrientation(line.attr("x1"), line.attr("y1"), line.attr("x2"), line.attr("y2"));
                                }
                                //get the orientation
                                var stringOrientation = getStringOrientation(line.attr("x1"), line.attr("y1"), line.attr("x2"), line.attr("y2"));
                                //store the new line into the list
                                coordList[coordList.length] = { "x1": line.attr("x1"), "x2": line.attr("x2"), "y1": line.attr("y1"), "y2": line.attr("y2"), "id": line.attr("id"), "orientation": stringOrientation }

                                //set the starting coordinates of the next line to the ending coordinates of this line
                                x1 = line.attr("x2");
                                y1 = line.attr("y2");

                            }
                
                        
            //return valid 
            return isValid;
        }

        

        /**
        This function runs through all of the lines in the list, and finds 
            the intercepting point between each line and the last drawn line
        @param lineNumber - the number of line for which we need to find intercept
        @return - a line object with the intercept point, the starting and ending coordinates, and the determinant
        */
        function findIntercept(lineNumber) {

            //the following variables hold the starting and ending x and y coordinates of a given line
            var cx2, cx1, cy2, cy1;

            //the following variables will be used for the line equation of the given line
            var A1, B1, C1;

            //the following variables will be used for the line equation of the last drawn line
            var A2, B2, C2;

            //initialize the given line coordinate variables, retrieving the coordinates from the list
            cx2 = coordList[lineNumber].x2; //initialize x2
            cx1 = coordList[lineNumber].x1; //initialize x1
            cy2 = coordList[lineNumber].y2; //initialize y2
            cy1 = coordList[lineNumber].y1; //initialize y1

            //calculate A1 for use in the line equation for the given line
            A1 = cy2 - cy1;
            //calculate B1 for use in the line equation for the given line
            B1 = cx1 - cx2;
            //make the line equation for the given line with A1, B1, and coordinates of the line
            C1 = A1 * cx1 + B1 * cy1;

            //initialize the last drawn line coordinate variables, retrieving the coordinates from the list
            cx2 = coordList[coordList.length - 1].x2; //initialize x2
            cx1 = coordList[coordList.length - 1].x1; //initialize x1
            cy2 = coordList[coordList.length - 1].y2; //initialize y2
            cy1 = coordList[coordList.length - 1].y1; //initialize y1

            //calculate A1 for use in the line equation for the last drawn line
            A2 = cy2 - cy1;
            //calculate B1 for use in the line equation for the last drawn line
            B2 = cx1 - cx2;
            //make the line equation for the last drawn line with A1, B1, and coordinates of the line
            C2 = A2 * cx1 + B2 * cy1;

            //calculate the determinant 
            var det = (A1 * B2) - (A2 * B1);
            //calculate the x value of the intercepting point
            var x = (B2 * C1 - B1 * C2) / det;
            //calculate the y value of the intercepting point
            var y = (A1 * C2 - A2 * C1) / det;

            return {
                "det": det, //return the determinant (0 if parallel)
                "x": x, //return the x coordinate of the intercept point
                "y": y, //return the y coordinate of the intercept point
                "x1": cx1, //return the initial x coordinate of the line
                "y1": cy1, //return the initial y coordinate of the line
                "y2": cy2, //return the ending x coodinate of the line
                "x2": cx2 //return the ending y coordinate of the line
            };
        }


        /**
        function snaps each drawn line to the corners of each cell in the grid;
            this prevents irregular lines being drawn
        @param coordinate - all of the coordinates (x1, y1, x2, y2), will be sent for snapping individually
        @return - return the new (snapped to grid) coordinate
        */
        function snapToGrid(coordinate) {
            //set to true or false depending on if the coordinate is less than cell padding * number of cells
            var endLoop = false;
            //initialize a counter to count the number of cells the coordinate is in
            var count = 0;
            //used to store validated coordinate
            var validCoordinate = 0;

            //run through a loop 
            while (!endLoop) {
                count++;// increment the counter every time the loop runs
                if (coordinate <= CELL_PADDING * count) { //if coordinate is less than cell padding * number of cells
                    endLoop = true; //end the loop
                    count--; //decrement the counter
                }
            }

            //if coordinate is closer to the one side of the grid line
            if ((coordinate - (count * CELL_PADDING)) <= CELL_PADDING / 2)
                validCoordinate = CELL_PADDING * count; //snap it to this line
            else //if coordinate is closer to the other side of the grid line
                validCoordinate = CELL_PADDING * (count + 1); //snap it to the other line

            return validCoordinate; //return the validated coordinate
        }



    </script>


</asp:Content>

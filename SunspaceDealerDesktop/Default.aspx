<%@ Page Title="Custom Drawing Tool" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SunspaceDealerDesktop._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
                <p> &nbsp; </p>
            </hgroup>
            
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div style="width:500px; height:500px;" id="mySunroom"></div>    
    <p> &nbsp; </p>

    <input type="button" value = "Done Drawing" onclick="sunroomCompleted()" />
        
    <input type="button" value ="Undo" onclick="undo(true)" />

    <input type="button" value ="Clear Canvas" onclick ="clearCanvas()"/>

    <input id="buttonDone" type="button" value ="" onclick="buttonDoneOnClick()"/>

    <input type="button" value ="Redo" onclick="redo()" />

    <input type="hidden" id="lineArrayInfo" runat="server" />
    
    <!--<p>
        Red is existing wall
        Black is proposed wall
    </p>-->

    <script>
        window.onload = buttonDoneOnLoad(); //load the default text on the "Done" button depending on whether the user chose standAlone or not

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

        //cell padding determines the size of each square in the grid 
        var cellPadding = 25;

        //max size of canvas (width and height)
        var MAX_CANVAS_WIDTH = 500;

        //create the canvas
        var canvas = d3.select("#mySunroom") 
                    .append("svg")
                    .attr("width", MAX_CANVAS_WIDTH)
                    .attr("height", MAX_CANVAS_WIDTH);

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

        


        //var existingWall = true;//standAlone ? false : confirm("existing wall?");
        //var internalWall = false;




        //set the name (value) of the "Done" button to the default value
        function buttonDoneOnLoad() {
            document.getElementById("buttonDone").value = (standAlone) ? "Done External Walls" : "Done Existing Walls";
        }

        //on click event of "Done" button
        function buttonDoneOnClick() {
            //if user wants to finish drawing existing walls
            if (doneButton.value === "Done Existing Walls") {
                //if the wallType is "E"
                if (wallType === WALL_TYPE.EXISTING) {
                    //change the name (value) of the button
                    doneButton.value = "Done External Walls";
                    //change wall type
                    wallType = WALL_TYPE.PROPOSED;
                    //reset click count
                    startNewWall = true;
                }
                //if walltype is not "E", means they have not drawn any existing walls
                else
                    //show error message
                    alert("No existing walls drawn, please draw one");
            }
            //if user wants to finish drawing external (i.e. proposed) walls
            else if (doneButton.value === "Done External Walls") {
                //if its a valid sunroom
                if (sunroomCompleted()) { // && wallType === WALL_TYPE.PROPOSED                    
                    //change the name (value) of the button
                    doneButton.value = "Done Internal Walls";
                    //change wall type
                    wallType = WALL_TYPE.INTERNAL;
                    //reset click count
                    startNewWall = true;
                }
            }
            //if the user wants to finish drawing internal walls 
            else {
                //if its a valid sunroom
                if (internalWalls()) {
                    //change the name (value) of the button
                    doneButton.value = "Done Drawing";
                    //reset click count
                    startNewWall = true;
                }
            }
        }

        //clear canvas
        function clearCanvas() {
            d3.selectAll("#E").remove(); //remove existing walls
            d3.selectAll("#P").remove(); //remove proposed walls
            d3.selectAll("#I").remove(); //remove internal walls
            startNewWall = true; //let the user begin another wall anywhere on the grid
            coordList = new Array(); //clear the list of lines
            removed = new Array(); //clear the list of removed lines
            wallType = WALL_TYPE.EXISTING; //reset the wall type to existing
       }


        //change the name (value) of the done button
        function setButtonValue() {
            doneButton.value = (coordList[coordList.length-1].id === WALL_TYPE.EXISTING) ? "Done Existing Walls" :
                (coordList[coordList.length-1].id === WALL_TYPE.PROPOSED) ? "Done External Walls" : "Done Internal Walls";
        }

        //undo last line
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
                    wallType = (coordList[i].id === WALL_TYPE.EXISTING) ? WALL_TYPE.EXISTING :
                        (coordList[i].id === WALL_TYPE.INTERNAL) ? WALL_TYPE.INTERNAL : WALL_TYPE.PROPOSED;

                    drawLine(coordList[i].x1, coordList[i].y1, coordList[i].x2, coordList[i].y2, false);
                }
                x1 = coordList[coordList.length - 1].x2;
                y1 = coordList[coordList.length - 1].y2;
            }

        }

        //redo last undo
        function redo() {
            
            //If an item exist within the removed array proceed with logic
            if (removed.length != 0) {
                
                //Change the wall type based on the id of the last element in the removed array
                wallType = (removed[removed.length - 1].id === WALL_TYPE.EXISTING) ? WALL_TYPE.EXISTING :
                    (removed[removed.length - 1].id === WALL_TYPE.INTERNAL) ? WALL_TYPE.INTERNAL : WALL_TYPE.PROPOSED;

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

            var rect = canvas.append("rect")
                        .attr("width", MAX_CANVAS_WIDTH)
                        .attr("height", MAX_CANVAS_WIDTH)
                        .attr("fill", "white")

            var line = canvas.append("line")
                        .attr("x1", 0)
                        .attr("y1", 0)
                        .attr("x2", 0)
                        .attr("y2", MAX_CANVAS_WIDTH)
                        .attr("stroke", "black");

            var line = canvas.append("line")
                        .attr("x1", 0)
                        .attr("y1", 0)
                        .attr("x2", MAX_CANVAS_WIDTH)
                        .attr("y2", 0)
                        .attr("stroke", "black");

            var line = canvas.append("line")
                        .attr("x1", 0)
                        .attr("y1", MAX_CANVAS_WIDTH)
                        .attr("x2", MAX_CANVAS_WIDTH)
                        .attr("y2", MAX_CANVAS_WIDTH)
                        .attr("stroke", "black");

            var line = canvas.append("line")
                        .attr("x1", MAX_CANVAS_WIDTH)
                        .attr("y1", 0)
                        .attr("x2", MAX_CANVAS_WIDTH)
                        .attr("y2", MAX_CANVAS_WIDTH)
                        .attr("stroke", "black");

            for (var i = 0; i < MAX_CANVAS_WIDTH; i += cellPadding) {
                var line = canvas.append("line")
                        .attr("x1", i + cellPadding)
                        .attr("y1", 0)
                        .attr("x2", i + cellPadding)
                        .attr("y2", MAX_CANVAS_WIDTH)
                        .attr("stroke", "grey");
            }
            for (var i = 0; i < MAX_CANVAS_WIDTH; i += cellPadding) {
                var line = canvas.append("line")
                        .attr("x1", 0)
                        .attr("y1", i + cellPadding)
                        .attr("x2", MAX_CANVAS_WIDTH)
                        .attr("y2", i + cellPadding)
                        .attr("stroke", "grey");
            }

        }
        //end of grid

        drawGrid();

        function getMousePos(myCanvas, evt) {
            var rect = myCanvas.getBoundingClientRect();
            return {
                x: evt.clientX - rect.left,
                y: evt.clientY - rect.top
            };
        };

        svgGrid.addEventListener("click",
        function (evt) {
            var mousePos = getMousePos(svgGrid, evt);

            console.log("array length: " + coordList.length);

            //startNewWall++;

            if (startNewWall === true) {
                x1 = mousePos.x;
                y1 = mousePos.y;
                startNewWall = false;

                removed = new Array();

            }
            else {
                x2 = mousePos.x;
                y2 = mousePos.y;

                var line = drawLine(x1, y1, x2, y2, false);

                var stringOrientation = getStringOrientation(line.attr("x1"), line.attr("y1"), line.attr("x2"), line.attr("y2"));

                coordList[coordList.length] = { "x1": line.attr("x1"), "y1": line.attr("y1"), "x2": line.attr("x2"), "y2": line.attr("y2"), "id": line.attr("id"), "orientation": stringOrientation};
                
                x1 = coordList[coordList.length - 1].x2;
                y1 = coordList[coordList.length - 1].y2;
            }
        },
        false);

        svgGrid.addEventListener("mousemove",
        function (evt) {
            var mousePos = getMousePos(svgGrid, evt);
            x2 = mousePos.x;
            y2 = mousePos.y;

            d3.selectAll("#mouseMoveLine").remove();

            if (!startNewWall)
                drawLine(x1, y1, x2, y2, true);
        },
        false);

        svgGrid.addEventListener("mouseout",
        function (evt) {
            d3.selectAll("#mouseMoveLine").remove();
        },
        false);

        function drawLine(x1, y1, x2, y2, mouseMove) {
            var coordinates = setGridPoints(snapToGrid(x1, cellPadding), snapToGrid(y1, cellPadding), snapToGrid(x2, cellPadding), snapToGrid(y2, cellPadding));
            var coorx1 = coordinates.x1;
            var coorx2 = coordinates.x2;
            var coory1 = coordinates.y1;
            var coory2 = coordinates.y2;
            var dY = coory2 - coory1;
            var dX = coorx2 - coorx1;

            if (!mouseMove)
                console.log(coorx2 + "," + coory2);

            if (coorx2 > MAX_CANVAS_WIDTH) {
                coorx2 = MAX_CANVAS_WIDTH;
                coory2 = (dY / dX) * (coorx2 - coorx1) + coory1;
            }
            else if (coorx2 < 0) {
                coorx2 = 0;
                coory2 = coory1 + (dY / dX) * (coorx2 - coorx1);
            }

            if (!mouseMove)
                console.log(coorx2 + "," + coory2);

            var line = canvas.append("line")
                    .attr("x1", coorx1)
                    .attr("y1", coory1)
                    .attr("x2", coorx2)
                    .attr("y2", coory2);

            //alert(wallType);

            if (wallType === WALL_TYPE.EXISTING) {
                line.attr("stroke", "red")
                    .attr("stroke-width", 1)
                    .attr("id", "E");
            }
            else if (wallType === WALL_TYPE.PROPOSED){
                line.attr("id", "P")
                    .attr("stroke", "black")
                    .attr("stroke-width", 2);
            }
            else if (wallType === WALL_TYPE.INTERNAL) {
                line.attr("id", "I")
                    .attr("stroke", "black")
                    .attr("stroke-width", 1);
            }
            
            if (mouseMove)
                line.attr("id", "mouseMoveLine");

            return line;
        };

        function getStringOrientation(x1, y1, x2, y2) {
            dX = x2 - x1;
            dY = y2 - y1;
            orientation = getOrientation(dX, dY);

            switch (orientation) {
                case WALL_FACING.SOUTH:
                    orientation = "S";
                    break;
                case WALL_FACING.NORTH:
                    orientation = "N";
                    break;
                case WALL_FACING.SOUTH_WEST:
                    orientation = "SW";
                    break;
                case WALL_FACING.NORTH_EAST:
                    orientation = "NE";
                    break;
                case WALL_FACING.WEST:
                    orientation = "W";
                    break;
                case WALL_FACING.EAST:
                    orientation = "E";
                    break;
                case WALL_FACING.NORTH_WEST:
                    orientation = "NW";
                    break;
                case WALL_FACING.SOUTH_EAST:
                    orientation = "SE";
                    break;
            }

            return orientation;
        }

        //orientation funtion
        function getOrientation(dX, dY) {    
            return ((Math.round(Math.atan2(dY, dX) / (Math.PI / 4))) + 8) % 8;
        }

        //Function to set the coordinate on a specific corner of the grid boxes
        function setGridPoints(x1, y1, x2, y2) {
            function sign(val) { return Math.abs(val) / val; }

            var dX;
            var dY;
            var length;
            var orientation;

            dX = x2 - x1;
            dY = y2 - y1;
            orientation = getOrientation(dX, dY);

            switch (orientation) {
                case WALL_FACING.SOUTH:
                case WALL_FACING.NORTH:
                    y2 = y1;
                    break;
                case WALL_FACING.SOUTH_WEST:
                case WALL_FACING.NORTH_EAST:
                    y2 = y1 + sign(dY) * Math.abs(dX);
                    break;
                case WALL_FACING.WEST:
                case WALL_FACING.EAST:
                    x2 = x1;
                    break;
                case WALL_FACING.NORTH_WEST:
                case WALL_FACING.SOUTH_EAST:
                    x2 = x1 + sign(dX) * Math.abs(dY);
                    break;
            }            

            return {
                'x1': x1,
                'y1': y1,
                'x2': x2,
                'y2': y2
            };
        };

        //determine if the sunroom is valid
        function sunroomCompleted() {
            var isValid = false;
            if (coordList.length < MIN_NUMBER_OF_WALLS)
                alert("A complete sunroom must be enclosed (3 walls minimum). Please try again!");
            else if (standAlone && coordList[coordList.length - 1].attr("x2") != coordList[0].x1)
                alert("A stand-alone sunroom must end at the start of the starting wall. Please try again!");
            else if (!standAlone) {
                isValid = validateNotStandAlone();
            }
            else
                isValid = true;

            alert(isValid);

            return isValid;
            }

        function validateNotStandAlone() {

            var distanceBetweenLines = new Array();            

            var shortest;

            var distance;

            var isValid = false;

            //var numberOfWallTypes = (internal) ? 3 : (proposed) ? 2 : 1;
            

            //var numberOfExistingWalls = 0;

            var shortestDistanceWallNumber;

            //var slopes = getAllSlopes();

            //Needs functionality to handle existing wall corners
            for (var i = 0; i < coordList.length; i++) {
                if (coordList[i].id === WALL_TYPE.EXISTING) {

                    var intercept = findIntercept(i);

                    //numberOfExistingWalls++;

                    if (intercept.det === 0) {
                        //lines are parallel
                        //alert("Sunroom must be enclosed. Please add another wall.");
                        //isValid = false;
                    }
                    else {
                        isValid = true;

                        if (intercept.x != coordList[coordList.length - 1].x2 || intercept.y != coordList[coordList.length - 1].y2) {
                            //distance = Math.sqrt(Math.pow((x - cx2), 2) + Math.pow((y - cy2), 2))
                            distanceBetweenLines[distanceBetweenLines.length] = { "distance": Math.sqrt(Math.pow((intercept.x - coordList[coordList.length - 1].x2), 2) + Math.pow((intercept.y - coordList[coordList.length - 1].y2), 2)), "x": intercept.x, "y": intercept.y };

                            shortest = MAX_CANVAS_WIDTH; //arbitrary long number
                            for (var i = 0; i < distanceBetweenLines.length; i++) {

                                if (distanceBetweenLines[i].distance < shortest) {
                                    shortest = distanceBetweenLines[i].distance;
                                    shortestDistanceWallNumber = i;
                                }
                            }
                            alert(intercept.x2 + " , If");

                            undo(false);

                            //alert(distanceBetweenLines[shortestDistanceWallNumber].x);

                            var line = drawLine(intercept.x1, intercept.y1, distanceBetweenLines[shortestDistanceWallNumber].x, distanceBetweenLines[shortestDistanceWallNumber].y, false);

                            coordList[coordList.length] = { "x1": line.attr("x1"), "x2": line.attr("x2"), "y1": line.attr("y1"), "y2": line.attr("y2"), "id": line.attr("id") }

                            x1 = line.attr("x2");
                            y1 = line.attr("y2");
                        }
                    }
                }
            }            

            return isValid;
        }

        

        //Used in validateNotStandAlone only
        function findIntercept(i) {
            var cx2;
            var cx1;
            var cy2;
            var cy1;

            var A1;
            var B1;
            var C1;

            var A2;
            var B2;
            var C2;

            cx2 = coordList[i].x2;
            cx1 = coordList[i].x1;
            cy2 = coordList[i].y2;
            cy1 = coordList[i].y1;

            A1 = cy2 - cy1;
            B1 = cx1 - cx2;
            C1 = A1 * cx1 + B1 * cy1;

            cx2 = coordList[coordList.length - 1].x2;
            cx1 = coordList[coordList.length - 1].x1;
            cy2 = coordList[coordList.length - 1].y2;
            cy1 = coordList[coordList.length - 1].y1;

            A2 = cy2 - cy1;
            B2 = cx1 - cx2;
            C2 = A2 * cx1 + B2 * cy1;

            var det = (A1 * B2) - (A2 * B1);
            var x = (B2 * C1 - B1 * C2) / det;
            var y = (A1 * C2 - A2 * C1) / det;

            return {
                "det": det,
                "x": x,
                "y": y,
                "x1": cx1,
                "y1": cy1,
                "y2": cy2,
                "x2": cx2
            };
        }

        function snapToGrid(coordinate, cellPadding) {
            var endLoop = false;
            var count = 0;
            var validCoordinate = 0;

            while (!endLoop) {
                count++;
                if (coordinate <= cellPadding * count) {
                    endLoop = true;
                    count--;
                }
            }

            if ((coordinate - (count * cellPadding)) <= cellPadding / 2)
                validCoordinate = cellPadding * count;
            else
                validCoordinate = cellPadding * (count + 1);

            return validCoordinate;
        }

        function internalWalls() {
            var isValid = true;
            for (var i = 0; i < coordList.length; i++) {

                    var intercept = findIntercept(i);

                    if (intercept.det === 0) {
                        isValid = false;
                    }
                    else {
                        isValid = true;

                        if (intercept.x != coordList[coordList.length - 1].x2 || intercept.y != coordList[coordList.length - 1].y2) {
                            //distance = Math.sqrt(Math.pow((x - cx2), 2) + Math.pow((y - cy2), 2))
                            distanceBetweenLines[distanceBetweenLines.length] = { "distance": Math.sqrt(Math.pow((intercept.x - coordList[coordList.length - 1].x2), 2) + Math.pow((intercept.y - coordList[coordList.length - 1].y2), 2)), "x": intercept.x, "y": intercept.y };

                            shortest = MAX_CANVAS_WIDTH; //arbitrary long number
                            for (var i = 0; i < distanceBetweenLines.length; i++) {

                                if (distanceBetweenLines[i].distance < shortest) {
                                    shortest = distanceBetweenLines[i].distance;
                                    shortestDistanceWallNumber = i;
                                }
                            }
                            alert(intercept.x2 + " , If");
                        }
                        else {
                            distanceBetweenLines[distanceBetweenLines.length] = { "distance": 0, "x": intercept.x2, "y": intercept.y2 };
                            alert(intercept.x2 + " , Else");
                        }
                    }
                
            }            

            undo(false);

            alert(distanceBetweenLines[shortestDistanceWallNumber].x);

            var line = drawLine(intercept.x1, intercept.y1, distanceBetweenLines[shortestDistanceWallNumber].x, distanceBetweenLines[shortestDistanceWallNumber].y, false);

            coordList[coordList.length] = { "x1": line.attr("x1"), "x2": line.attr("x2"), "y1": line.attr("y1"), "y2": line.attr("y2"), "id": line.attr("id") }

            x1 = line.attr("x2");
            y1 = line.attr("y2");

            return isValid;
                
        }
         

    </script>


</asp:Content>

<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SunspaceDealerDesktop._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
                <h2>Modify this template to jump-start your ASP.NET application.</h2>
            </hgroup>
            <p>
                To learn more about ASP.NET, visit <a href="http://asp.net" title="ASP.NET Website">http://asp.net</a>.
                The page features <mark>videos, tutorials, and samples</mark> to help you get the most from ASP.NET.
                If you have any questions about ASP.NET visit
                <a href="http://forums.asp.net/18.aspx" title="ASP.NET Forum">our forums</a>.
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div style="width:500px; height:500px;" id="mySunroom"></div>    
    <input type="button" value = "Done Drawing" onclick="sunroomCompleted()" />    
    <input type="button" value ="Undo" onclick="undo(true)" />
    <input type="button" value ="Clear Canvas" onclick ="clearCanvas()"/>
    <input type="button" value ="Done Existing Walls" onclick="if(!standAlone) doneExistingWalls()" />
    <input type="button" value ="Redo" onclick="redo()" />

    <input type="hidden" id="lineArrayInfo" runat="server" />
    <p>
        Red is existing wall
        Black is proposed wall
    </p>

    <script>

        var canvas = d3.select("#mySunroom")
                    .append("svg")
                    .attr("width", MAX_CANVAS_WIDTH)
                    .attr("height", MAX_CANVAS_WIDTH);
        var svgGrid = document.getElementById("mySunroom");
        var clickCount = 0;
        var cellPadding = 25;
        var MAX_CANVAS_WIDTH = 500;
        //var removePop = false;
        var removed = new Array();
        var standAlone = false;//confirm("standalone?");
        var existingWall = true;//standAlone ? false : confirm("existing wall?");
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
        var MIN_NUMBER_OF_WALLS = 3;
        var x1;
        var y1;
        var x2;
        var y2;

        var coordList = new Array();

        //clear canvas
        function clearCanvas() {
            location.reload();
        }

        //undo last line
        function undo(toBeRemoved) {

            d3.selectAll("#E").remove();
            d3.selectAll("#P").remove();

            if (toBeRemoved)
                removed.push(coordList[coordList.length - 1]);

            coordList.pop();

            for (var i = 0; i <= coordList.length - 1; i++){ 
                if (coordList[i].id === "E")
                    existingWall = true;
                else
                    existingWall = false;

                drawLine(coordList[i].x1, coordList[i].y1, coordList[i].x2, coordList[i].y2, false);
            }
            if (coordList.length === 0)
                clearCanvas();
            else {
                x1 = coordList[coordList.length - 1].x2;
                y1 = coordList[coordList.length - 1].y2;
            }
        }

        //redo last undo
        function redo() {
            if (removed.length != 0) {

                coordList.push(removed[removed.length - 1]);
                removed.pop();
                drawLine(coordList[coordList.length - 1].x1, coordList[coordList.length - 1].y1, coordList[coordList.length - 1].x2, coordList[coordList.length - 1].y2, false);
                x1 = coordList[coordList.length - 1].x2;
                y1 = coordList[coordList.length - 1].y2;
            }
        }

        //done drawing existing walls
        function doneExistingWalls(){            
            existingWall = false;
            clickCount = 0;
        }
        
        /*
        //create cookie
        function createCookie(id,value,days) {
            //Session("ExistingWallList") = coordList;
            if (days) {
		        var date = new Date();
		        date.setTime(date.getTime()+(days*24*60*60*1000));
		        var expires = "; expires="+date.toGMTString();
	        }
	        else var expires = "";
	        document.cookie = id+"="+value+expires+"; path=/"; 
        }

        //read cookie
        function readCookie(name) {
	        var nameEQ = name + "=";
	        var ca = document.cookie.split(';');
	        for(var i=0;i < ca.length;i++) {
		        var c = ca[i];
		        while (c.charAt(0)==' ') 
                    c = c.substring(1,c.length);
		        if (c.indexOf(nameEQ) == 0) 
                    return c.substring(nameEQ.length,c.length);
	        }
	        return null;
        }
        */

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

            clickCount++;

            if (clickCount === 1) {
                x1 = mousePos.x;
                y1 = mousePos.y;
            }
            else {
                x2 = mousePos.x;
                y2 = mousePos.y;

                var line = drawLine(x1, y1, x2, y2, false);

                var stringOrientation = getStringOrientation(line.attr("x1"), line.attr("y1"), line.attr("x2"), line.attr("y2"));

                coordList[coordList.length - 1] = { "x1": line.attr("x1"), "y1": line.attr("y1"), "x2": line.attr("x2"), "y2": line.attr("y2"), "id": line.attr("id"), "orientation": stringOrientation};
               
                alert(coordList[coordList.length - 1].orientation + ", " + coordList[coordList.length - 1].x1);

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

            if (clickCount != 0)
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
                    .attr("y2", coory2)
                    .attr("stroke", "black")
                    .attr("stroke-width", 2);

            //if (standAlone)
            //    line.attr("id", "standAlone");
            //else
            //    line.attr("id", "notStandAlone");

            if (existingWall) {
                line.attr("stroke", "red")
                    .attr("stroke-width", 1)
                    .attr("id", "E");
            }
            else{
                line.attr("id", "P")
                    .attr("stroke", "black")
                    .attr("stroke-width", 2);
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
                case WALL_FACING.SOUTH_EAST:
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
            if (coordList.length < MIN_NUMBER_OF_WALLS) 
                alert("A complete sunroom must be enclosed (3 walls minimum). Please try again!");
               else if (standAlone && coordList[coordList.length - 1].attr("x2") != coordList[0].x1)
                    alert("A stand-alone sunroom must end at the start of the starting wall. Please try again!");
                else if (!standAlone) {
                    validateNotStandAlone();
                }
            }

        function validateNotStandAlone() {

            var distanceBetweenLines = new Array();            

            var shortest;

            var distance;

            var numberOfExistingWalls = 0;

            var shortestDistanceWallNumber;

            var slopes = getAllSlopes();

            //Needs functionality to handle existing wall corners
            for (var i = 0; i < coordList.length; i++) {
                if (coordList[i].id === "E") {

                    var intercept = findIntercept(i);

                    numberOfExistingWalls++;

                    if (intercept.det === 0) {
                        //lines are parallel
                        alert("Sunroom must be enclosed. Please add another wall.");
                    }
                    else {      
                        if (intercept.x != coordList[coordList.length - 1].x2 || intercept.y != coordList[coordList.length - 1].y2) {
                            //distance = Math.sqrt(Math.pow((x - cx2), 2) + Math.pow((y - cy2), 2))
                            distanceBetweenLines[distanceBetweenLines.length] = { "distance": Math.sqrt(Math.pow((intercept.x - coordList[coordList.length - 1].x2), 2) + Math.pow((intercept.y - coordList[coordList.length - 1].y2), 2)), "x": intercept.x, "y": intercept.y };
                        }
                    }
                }
            }

            shortest = MAX_CANVAS_WIDTH; //arbitrary long number
            for (var i = 0; i < distanceBetweenLines.length; i++) {

                if (distanceBetweenLines[i].distance < shortest) {
                    shortest = distanceBetweenLines[i].distance;
                    shortestDistanceWallNumber = i;
                }
            }

            undo(false);

            var line = drawLine(intercept.x1, intercept.y1, distanceBetweenLines[shortestDistanceWallNumber].x, distanceBetweenLines[shortestDistanceWallNumber].y, false);

            coordList[coordList.length] = { "x1": line.attr("x1"), "x2": line.attr("x2"), "y1": line.attr("y1"), "y2": line.attr("y2"), "id": line.attr("id") }

            x1 = line.attr("x2");
            y1 = line.attr("y2");

        }

        function getAllSlopes() {
            var mExisting = new Array();

            var mProposed = new Array();

            for (var i = 0; i < coordList.length; i++) {

                if (coordList[i].id === "P") {
                    mProposed[mProposed.length] = (coordList[i].y2 - coordList[i].y1) / (coordList[i].x2 - coordList[i].x1)
                }
                else if (coordList[i].id === "E") {
                    mExisting[mExisting.length] = (coordList[i].y2 - coordList[i].y1) / (coordList[i].x2 - coordList[i].x1)
                }
            }
            return {
                "proposedSlopes": mProposed,
                "existingSlopes": mExisting
            };
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
                "y2": cx2,
                "x2": cy2
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

    </script>


</asp:Content>

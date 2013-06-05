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
    <input type="button" value ="Toggle Wall Type" onclick="existingWall = !existingWall"/>
    
    <p>
        Red is proposed wall
        Black is existing wall
    </p>

    <script>
        var canvas = d3.select("#mySunroom")
                    .append("svg")
                    .attr("width", 500)
                    .attr("height", 500);
        var svgGrid = document.getElementById("mySunroom");
        var counter = 0;
        var cellPadding = 25;
        var lineArray = new Array();
        var lineCount = 0;
        var existingWall = false;
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

        //alert(COMPASS.EAST);




        //Draw the grid lines
        function drawGrid() {

            var rect = canvas.append("rect")
                        .attr("width", 500)
                        .attr("height", 500)
                        .attr("fill", "white")

            var line = canvas.append("line")
                        .attr("x1", 0)
                        .attr("y1", 0)
                        .attr("x2", 0)
                        .attr("y2", 500)
                        .attr("stroke", "black");

            var line = canvas.append("line")
                        .attr("x1", 0)
                        .attr("y1", 0)
                        .attr("x2", 500)
                        .attr("y2", 0)
                        .attr("stroke", "black");

            var line = canvas.append("line")
                        .attr("x1", 0)
                        .attr("y1", 500)
                        .attr("x2", 500)
                        .attr("y2", 500)
                        .attr("stroke", "black");

            var line = canvas.append("line")
                        .attr("x1", 500)
                        .attr("y1", 0)
                        .attr("x2", 500)
                        .attr("y2", 500)
                        .attr("stroke", "black");

            for (var i = 0; i < 500; i += 25) {
                var line = canvas.append("line")
                        .attr("x1", i + 25)
                        .attr("y1", 0)
                        .attr("x2", i + 25)
                        .attr("y2", 500)
                        .attr("stroke", "grey");
            }
            for (var i = 0; i < 500; i += 25) {
                var line = canvas.append("line")
                        .attr("x1", 0)
                        .attr("y1", i + 25)
                        .attr("x2", 500)
                        .attr("y2", i + 25)
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

            console.log("array length: " + lineArray.length);

            counter++;

            if (counter === 1) {
                x1 = mousePos.x;
                y1 = mousePos.y;
            }
            else {
                x2 = mousePos.x;
                y2 = mousePos.y;

                var line = drawLine(x1, y1, x2, y2, false, existingWall);

                x1 = line.attr("x2");
                y1 = line.attr("y2");

                lineArray[lineCount] = line;
                lineCount++;

                for (var i = 0; i < lineArray.length ; i++)
                    lineArray[i];
            }
        },
        false);

        svgGrid.addEventListener("mousemove",
        function (evt) {
            var mousePos = getMousePos(svgGrid, evt);
            x2 = mousePos.x;
            y2 = mousePos.y;

            d3.selectAll("#mouseMoveLine").remove();

            if (counter != 0)
                drawLine(x1, y1, x2, y2, true, existingWall);
        },
        false);

        svgGrid.addEventListener("mouseout",
        function (evt) {
            d3.selectAll("#mouseMoveLine").remove();
        },
        false);

        function drawLine(x1, y1, x2, y2, mouseMove, existingWall) {

            var coordinates = setGridPoints(snapToGrid(x1, cellPadding), snapToGrid(y1, cellPadding), snapToGrid(x2, cellPadding), snapToGrid(y2, cellPadding));

            var line = canvas.append("line")
                    .attr("x1", coordinates.x1)
                    .attr("y1", coordinates.y1)
                    .attr("x2", coordinates.x2)
                    .attr("y2", coordinates.y2)

            if (existingWall) {
                line.attr("stroke", "red");
            }
            else {
                line.attr("stroke", "black")
                    .attr("stroke-width", 2);
            }

            if (mouseMove)
                line.attr("id", "mouseMoveLine");

            return line;
        };

        //orientation funtion
        function getOrientation(dX, dY) {
            return ((Math.round(Math.atan2(dY, dX) / (Math.PI / 4))) + 8) % 8;
        }

        //Function to set the coordinate on a specific corner of the grid boxes
        function setGridPoints(x1, y1, x2, y2) {
            function sign(val) { return Math.abs(val) / val; }
            var dX = x2 - x1;
            var dY = y2 - y1;
            var length;
            var orientation = getOrientation(dX, dY);
            

            switch (orientation) {
                case COMPASS.SOUTH:
                case COMPASS.NORTH:
                    y2 = y1;
                    break;
                case COMPASS.SOUTH_WEST:
                case COMPASS.NORTH_EAST:
                    y2 = y1 + sign(dY) * Math.abs(dX);
                    break;
                case COMPASS.WEST:
                case COMPASS.EAST:
                    x2 = x1;
                    break;
                case COMPASS.NORTH_WEST:
                case COMPASS.SOUTH_EAST:
                    x2 = x1 + sign(dX) * Math.abs(dY);
                    break;
            }

            /*
            if (Math.abs(dY) < Math.abs(dX))
                if (Math.abs(dY) > (Math.abs(dX) / 2))
                    y2 = y1 + sign(dY) * Math.abs(dX);
                else
                    y2 = y1;
            else
                if (Math.abs(dX) > (Math.abs(dY) / 2))
                    x2 = x1 + sign(dX) * Math.abs(dY);

                else
                    x2 = x1;
            */
            return {
                'x1': x1,
                'y1': y1,
                'x2': x2,
                'y2': y2
            };
        };

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

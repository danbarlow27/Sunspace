<%@ Page Title="Project Editor" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ProjEd.aspx.cs" Inherits="SunspaceDealerDesktop.ProjEd" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <!--Div tag to hold the canvas/grid-->
        <div style="max-width:100%; max-height:500px; min-width:100px; min-height:100px; margin: 0 auto;" id="myCanvas">
            <%--<canvas id="myCanvas" width="100%" height="100%"
                style="border:1px solid #000000;">
            </canvas>--%>
        </div>

        <asp:PlaceHolder ID="accordion" runat="server"></asp:PlaceHolder>

    <script>

        var GRID_PADDING = 25 / 2;                  //size of the squares in the grid        
        var CELL_PADDING = GRID_PADDING / 2;    //cell padding is half less than the grid padding
        var MAX_CANVAS_WIDTH = $("#myCanvas").width();             //max width of canvas
        var MAX_CANVAS_HEIGHT = 500;            //max height of canvas
        var CENTRE_X = MAX_CANVAS_WIDTH / 2;
        var CENTRE_Y = MAX_CANVAS_HEIGHT / 2;

        var wallStartHeight;
        var wallEndHeight;
        var wallWidth;

        ///* CREATE CANVAS */
        var canvas = d3.select("#myCanvas")            //Select the div tag with id "mySunroom"
                    .append("svg")                      //Add an svg tag to the selected div tag
                    .attr("width", MAX_CANVAS_WIDTH)    //Set the width of the canvas/grid to MAX_CANVAS_WIDTH
                    .attr("height", MAX_CANVAS_HEIGHT); //Set the height of the canvas/grid to MAX_CANVAS_HEIGHT
        var svgGrid = document.getElementById("myCanvas");     //create the svg grid on the canvas

        /**
        *drawCanvas
        *Draw canvas function; draws the canvas border
        */
        function drawCanvas() {

            //Creates rectangle area to draw in based on max canvas dimensions
            var rect = canvas.append("rect")                //Draws a rectangle for the canvas/grid to sit in
                        .attr("width", MAX_CANVAS_WIDTH)    //Sets the width for the canvas/grid
                        .attr("height", MAX_CANVAS_HEIGHT)  //Sets the height for the canvas/grid
                        .attr("fill", "white");              //Sets the color of the rectangle to white

            //Draws left border line of canvas
            var line = canvas.append("line")                //Draws the left line of the border of the canvas/grid
                        .attr("x1", 0)                      //Sets the first X value to 0
                        .attr("y1", 0)                      //Sets the first Y value to 0
                        .attr("x2", 0)                      //Sets the second X value to 0
                        .attr("y2", MAX_CANVAS_HEIGHT)      //Sets the second Y value to MAX_CANVAS_HEIGHT(500)
                        .attr("stroke", "black");           //Sets the line colour to black

            //Draws top border line of canvas
            var line = canvas.append("line")                //Draws the top line of the border of the canvas/grid
                        .attr("x1", 0)                      //Sets the first X value to 0
                        .attr("y1", 0)                      //Sets the first Y value to 0
                        .attr("x2", MAX_CANVAS_WIDTH)       //Sets the second X value to MAX_CANVAS_WIDTH
                        .attr("y2", 0)                      //Sets the second Y value to 0
                        .attr("stroke", "black");           //Sets the line colour to black

            //Draws bottom border line of canvas
            var line = canvas.append("line")                //Draws the bottom line of the border of the canvas/grid
                        .attr("x1", 0)                      //Sets the first X value to 0
                        .attr("y1", MAX_CANVAS_HEIGHT)      //Sets the first Y value to MAX_CANVAS_HEIGHT
                        .attr("x2", MAX_CANVAS_WIDTH)       //Sets the second X value to MAX_CANVAS_WIDTH
                        .attr("y2", MAX_CANVAS_HEIGHT)      //Sets the second Y value to MAX_CANVAS_HEIGHT
                        .attr("stroke", "black");           //Sets the line colour to black

            //Draws right border line of canvas
            var line = canvas.append("line")                //Draws the right line of the border of the canvas/grid
                        .attr("x1", MAX_CANVAS_WIDTH)       //Sets the first X value to MAX_CANVAS_WIDTH
                        .attr("y1", 0)                      //Sets the first Y value to 0
                        .attr("x2", MAX_CANVAS_WIDTH)       //Sets the second X value to MAX_CANVAS_WIDTH
                        .attr("y2", MAX_CANVAS_HEIGHT)      //Sets the second Y value to MAX_CANVAS_HEIGHt
                        .attr("stroke", "black");           //Sets the line colour to black

            //Draws vertical lines of the grid onto the canvas
            for (var i = 1; i < MAX_CANVAS_WIDTH; i += GRID_PADDING) {
                var line = canvas.append("line")            //Draws vertical lines based on the current i value of the loop
                        .attr("x1", i + GRID_PADDING)       //Sets the first X value to i plus the GRID_PADDING (25)
                        .attr("y1", 1)                      //Sets the frist Y value to 0
                        .attr("x2", i + GRID_PADDING)       //Sets the second X value to i plus GRID_PADDING(25)
                        .attr("y2", MAX_CANVAS_HEIGHT - 1)      //Sets the second Y value to MAX_CANVAS_HEIGHT
                        .attr("stroke", "#F0F0F0");            //Sets the line colour to grey
            }

            //Draws horizontal lines of the grid onto the canvas
            for (var i = 0; i < MAX_CANVAS_HEIGHT; i += GRID_PADDING) {
                var line = canvas.append("line")            //Draws horizontal lines based on the current i value of the loop
                        .attr("x1", 1)                      //Sets the first X value to 0
                        .attr("y1", i + GRID_PADDING)       //Sets the first Y value to i plus GRID_PADDING(25)
                        .attr("x2", MAX_CANVAS_WIDTH - 1)       //Sets the second X value to MAX_CANVAS_WIDTH
                        .attr("y2", i + GRID_PADDING)       //Sets the second Y value to i plus GRID_PADDING(25)
                        .attr("stroke", "#F0F0F0");            //Sets the line colour to grey
            }
        }

        $(document).ready(function () {
            drawCanvas(); //Draws the initial grid
        });


        /**
        This function gets called when the wall accordion is clicked.
        This function sets all the appropriate attributes 
        to the wall height and width variables
        */
        function drawWall(width, startHeight, endHeight) {
            //alert("width: " + width + ", start: " + startHeight + ", end: " + endHeight);

            d3.selectAll("#wall").remove();//remove any previously drawn walls

            wallWidth = width;
            wallStartHeight = startHeight;
            wallEndHeight = endHeight;

            var wallTopLeft = "" + (CENTRE_X - (width / 2)) + "," + (CENTRE_Y - (startHeight / 2));
            var wallTopRight = " " + (CENTRE_X + (width / 2)) + "," + (CENTRE_Y - (endHeight / 2));
            var wallBottomRight = " " + (CENTRE_X + (width / 2)) + "," + (CENTRE_Y + (endHeight / 2));
            var wallBottomLeft = " " + (CENTRE_X - (width / 2)) + "," + (CENTRE_Y + (endHeight / 2));

            var points = wallTopLeft + wallTopRight + wallBottomRight + wallBottomLeft;

            var wall = canvas.append("polygon")
                             .attr("id", "wall")
                             .attr("points", points)
                             .attr("fill", "white")
                             .attr("stroke", "black")
                             .attr("stroke-width", "1");

        }

    </script>

</asp:Content>

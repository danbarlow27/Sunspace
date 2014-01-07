﻿<%@ Page Title="Project Editor" Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProjectEditor.aspx.cs" Inherits="SunspaceDealerDesktop.ProjectEditor" %>


<asp:Content runat="server" ID="SecondaryNavigation" ContentPlaceHolderID="SecondaryNavigation">   
    <nav class="navEditor">
        <ul class="ulNavEditor">
            <li><asp:DropDownList ID="ddlSunroomObjects" Width="160" runat="server"></asp:DropDownList></li>
            <li><asp:HyperLink ID="lnkEditorNavMods" CssClass="editMods" runat="server">Edit Mods</asp:HyperLink></li>
            <li><asp:HyperLink ID="lnkEditorNavTools" runat="server">Tools</asp:HyperLink>
                <ul>
                    <li><asp:HyperLink ID="lnkEditorNavSave" runat="server">Save</asp:HyperLink></li>
                    <li><asp:HyperLink ID="lnkEditorNavUndo" runat="server">Undo</asp:HyperLink></li>
                    <li><asp:HyperLink ID="lnkEditorNavRedo" runat="server">Redo</asp:HyperLink></li>
                    <li><asp:HyperLink ID="lnkEditorNavAddMod" runat="server">Add</asp:HyperLink></li>
                    <li><asp:HyperLink ID="lnkEditorNavDeleteMod" runat="server">Delete</asp:HyperLink></li>
                    <li><asp:HyperLink ID="lnkEditorNavMoveLeft" runat="server">Left</asp:HyperLink></li>
                    <li><asp:HyperLink ID="lnkEditorNavMoveRight" runat="server">Right</asp:HyperLink></li>
                    <li><asp:HyperLink ID="lnkEditorNavPrint" runat="server">Print</asp:HyperLink></li>
                </ul>
            </li>
        </ul>
    </nav>
</asp:Content>

<asp:Content runat="server" ID="ModOverlay" ContentPlaceHolderID="ModOverlay">
    <%--<div class="overlayBg"></div>--%>
    <div class="overlayContainer">
        <div class="overlayClose"><a href="#"><span>X</span> Close Mods Editor</a></div>
        
        <ul class="toggleOptions">
            
            <asp:PlaceHolder ID="ModOptions" runat="server"></asp:PlaceHolder>                    

            <%-- Mod 1 --%>
            <%--<li>--%>
                <%--<asp:RadioButton ID="radProjectSunroom" GroupName="projectType" runat="server" />--%>
                <%--<asp:Label ID="lblProjectSunroomRadio" AssociatedControlID="radProjectSunroom" runat="server"></asp:Label>--%>
                <%--<asp:Label ID="lblProjectSunroom" AssociatedControlID="radProjectSunroom" runat="server" Text="Mod 1"></asp:Label>--%>
           
                <%--<div class="toggleContent">--%>
                    <%--<ul>--%>
                        <%--<li>--%>
                            <%--<asp:RadioButton ID="radSunroomModel100" OnClick="newProjectCheckQuestion3()" GroupName="sunroomModel" runat="server" />--%>
                            <%--<asp:Label ID="lblSunroomModel100Radio" AssociatedControlID="radSunroomModel100" runat="server"></asp:Label>--%>
                            <%--<asp:Label ID="lblSunroomModel100" AssociatedControlID="radSunroomModel100" runat="server" Text="Model 100"></asp:Label>--%>
                        <%--</li>--%>
                        <%--<li>--%>
                            <%--<asp:RadioButton ID="radSunroomModel200" OnClick="newProjectCheckQuestion3()" GroupName="sunroomModel" runat="server" />--%>
                            <%--<asp:Label ID="lblSunroomModel200Radio" AssociatedControlID="radSunroomModel200" runat="server"></asp:Label>--%>
                            <%--<asp:Label ID="lblSunroomModel200" AssociatedControlID="radSunroomModel200" runat="server" Text="Model 200"></asp:Label>--%>
                        <%--</li>--%>
                        <%--<li>
                            <%--<asp:RadioButton ID="radSunroomModel300" OnClick="newProjectCheckQuestion3()" GroupName="sunroomModel" runat="server" />--%>
                            <%--<asp:Label ID="lblSunroomModel300Radio" AssociatedControlID="radSunroomModel300" runat="server"></asp:Label>--%>
                            <%--<asp:Label ID="lblSunroomModel300" AssociatedControlID="radSunroomModel300" runat="server" Text="Model 300"></asp:Label>--%>
                        <%--</li>--%>
                        <%--<li>
                            <%--<asp:RadioButton ID="radSunroomModel400" OnClick="newProjectCheckQuestion3()" GroupName="sunroomModel" runat="server" />--%>
                            <%--<asp:Label ID="lblSunroomModel400Radio" AssociatedControlID="radSunroomModel400" runat="server"></asp:Label>--%>
                            <%--<asp:Label ID="lblSunroomModel400" AssociatedControlID="radSunroomModel400" runat="server" Text="Model 400"></asp:Label>--%>
                        <%--</li>--%>
                    <%--</ul>--%>            
                <%--</div>--%>
            <%--</li>--%>
        </ul>

    </div>   

    <%--<asp:Label ID="lblError" runat="server"></asp:Label>--%>
    <input id="hidJsonObjects" type="hidden" runat="server" />
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <!--Div tag to hold the canvas/grid-->
    <div style="max-width:100%; max-height:100%; min-width:100px; min-height:100px; margin: 0 auto;" id="myCanvas"></div>

    <script>

        var listOfWalls = <%= hidJsonObjects.Value %>;

        console.log(listOfWalls);

        var roofCount = '<%= roofCount %>';
        var floorCount = '<%= floorCount %>';
        var wallCount = '<%= wallCount %>';
        var projectId = '<%= projectId %>'; 

        $("#myCanvas").height($(window).height() - 170);
        $("#myCanvas").width($(window).width());

        var GRID_PADDING = 25 / 2;                  //size of the squares in the grid        
        var CELL_PADDING = GRID_PADDING / 2;    //cell padding is half less than the grid padding
        var MAX_CANVAS_WIDTH = $("#myCanvas").width();             //max width of canvas
        var MAX_CANVAS_HEIGHT = $("#myCanvas").height();            //max height of canvas
        var CENTRE_X = MAX_CANVAS_WIDTH / 2;
        var CENTRE_Y = MAX_CANVAS_HEIGHT / 2;

        var wallStartHeight;
        var wallEndHeight;
        var wallWidth;

        var wallSlope;

        ///* CREATE CANVAS */
        var canvas = d3.select("#myCanvas")            //Select the div tag with id "mySunroom"
                    .append("svg")                      //Add an svg tag to the selected div tag
                    .attr("width", MAX_CANVAS_WIDTH)    //Set the width of the canvas/grid to MAX_CANVAS_WIDTH
                    .attr("height", MAX_CANVAS_HEIGHT); //Set the height of the canvas/grid to MAX_CANVAS_HEIGHT
        var svgGrid = $("#myCanvas");     //create the svg grid on the canvas

        var gridPoints;


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
            //for (var i = 1; i < MAX_CANVAS_WIDTH; i += GRID_PADDING) {
            //    var line = canvas.append("line")            //Draws vertical lines based on the current i value of the loop
            //            .attr("x1", i + GRID_PADDING)       //Sets the first X value to i plus the GRID_PADDING (25)
            //            .attr("y1", 1)                      //Sets the frist Y value to 0
            //            .attr("x2", i + GRID_PADDING)       //Sets the second X value to i plus GRID_PADDING(25)
            //            .attr("y2", MAX_CANVAS_HEIGHT - 1)      //Sets the second Y value to MAX_CANVAS_HEIGHT
            //            .attr("stroke", "#F0F0F0");            //Sets the line colour to grey
            //}

            //Draws horizontal lines of the grid onto the canvas
            //for (var i = 0; i < MAX_CANVAS_HEIGHT; i += GRID_PADDING) {
            //    var line = canvas.append("line")            //Draws horizontal lines based on the current i value of the loop
            //            .attr("x1", 1)                      //Sets the first X value to 0
            //            .attr("y1", i + GRID_PADDING)       //Sets the first Y value to i plus GRID_PADDING(25)
            //            .attr("x2", MAX_CANVAS_WIDTH - 1)       //Sets the second X value to MAX_CANVAS_WIDTH
            //            .attr("y2", i + GRID_PADDING)       //Sets the second Y value to i plus GRID_PADDING(25)
            //            .attr("stroke", "#F0F0F0");            //Sets the line colour to grey
            //}
        }

        /**
        This function gets called when the wall accordion is clicked.
        This function sets all the appropriate attributes 
        to the wall height and width variables
        */
        function drawWall(width, startHeight, endHeight, wallNumber) {
            //alert("width: " + width + ", start: " + startHeight + ", end: " + endHeight);

            d3.selectAll("#wall").remove();//remove any previously drawn walls

            wallWidth = width;// * 2;
            wallStartHeight = startHeight;// * 2;
            wallEndHeight = endHeight;// * 2;

            var highHeight = (wallStartHeight < wallEndHeight) ? wallEndHeight : wallStartHeight;

            //wallSlope = wallEndHeight / wallWidth;

            //scaleWall(wallSlope, highHeight, wallWidth);
            scaleWallOptimally(highHeight, wallWidth);

            //var scaleX = d3.scale.linear()
            //       .domain([0, wallWidth])
            //       .range([0, MAX_CANVAS_WIDTH]);
            //var scaleY = d3.scale.linear()
            //       .domain([0, highHeight])
            //       .range([0, MAX_CANVAS_HEIGHT]);

            var wallTopLeft = { "x": (CENTRE_X - (wallWidth / 2)), "y": (CENTRE_Y - (wallStartHeight / 2)) };
            var wallTopRight = { "x": (CENTRE_X + (wallWidth / 2)), "y": (CENTRE_Y - (wallEndHeight / 2)) };
            var wallBottomRight = { "x": (CENTRE_X + (wallWidth / 2)), "y": (CENTRE_Y + (wallEndHeight / 2)) };
            var wallBottomLeft = { "x": (CENTRE_X - (wallWidth / 2)), "y": (CENTRE_Y + (wallEndHeight / 2)) };

            var points = gridPoints = [wallTopLeft, wallTopRight, wallBottomRight, wallBottomLeft];

            var wall = canvas.selectAll("polygon")
                             .data([points])
                             .enter().append("polygon")
                             .attr("id", "wall")
                                 .attr("points", function (d) {
                                     return d.map(function (d) {
                                         return [d.x, d.y].join(",");
                                     }).join(" ");
                                 })
                             .attr("fill", "white")
                             .attr("stroke", "black")
                             .attr("stroke-width", "1")
                             .attr("onmouseover", "$(\"#wall\").attr(\"fill\", \"#F3F3F3\");")
                             .attr("onmouseout", "$(\"#wall\").attr(\"fill\", \"white\");")
                             .attr("onclick", "$(\"#MainContent_txtWidth" + wallNumber + "\").focus();"); //put focus on the first editable field for the wall
        }

        /**
        This functions scales the currently selected wall to the optimal size to fit any size of canvas
        */
        function scaleWallOptimally(height, width) {

            var multiplier = 0; //to determine how much to increase/decrease the size

            if (height < MAX_CANVAS_HEIGHT && width < MAX_CANVAS_WIDTH) { //if the wall is smaller than the canvas

                var remainingWidth = MAX_CANVAS_WIDTH - width; //remaining space from the sides
                var remainingHeight = MAX_CANVAS_HEIGHT - height; //remaining space from the top

                if (remainingHeight < remainingWidth) { //if the remaining space at the top is less than remaining space on the sides
                    while (height < (MAX_CANVAS_HEIGHT - 50)) { //while the height is slightly less than the MAX HEIGHT
                        height = parseFloat(height) + 10; //increase height by 10
                        multiplier++; //keep count of how many times height was increased
                    }
                }
                else { //if the remaining space on the sides is less than or equal to the remaining space from the top
                    while (width < (MAX_CANVAS_WIDTH - 50)) { //while the width is slightly less than the MAX WIDTH
                        width = parseFloat(width) + 10; // increase width by 10
                        multiplier++; //keep count of how many times the width was increased
                    }
                }

                //adjust the width and height proportionally to optimally fit the wall on canvas
                wallWidth = parseFloat(wallWidth) + (10 * multiplier); //adjust the width
                wallStartHeight = parseFloat(wallStartHeight) + (10 * multiplier); //adjust the start height
                wallEndHeight = parseFloat(wallEndHeight) + (10 * multiplier); //adjust the end height
            }
            else { // if the wall is larger than the canvas

                var extraWidth = width - MAX_CANVAS_WIDTH; //extra space outside the canvas from the sides
                var extraHeight = height - MAX_CANVAS_HEIGHT; //extra space outside the canvas from the top

                //console.log(height+","+extraHeight);
                //console.log(width+","+extraWidth);

                if (extraHeight > extraWidth) { //if the space outside the canvas at the top is more than space outside the canvas on the sides
                    while (height > (MAX_CANVAS_HEIGHT - 50)) { //while the height is more than the MAX HEIGHT - 10
                        height = parseFloat(height) - 10; //decrease height by 10
                        multiplier++; //keep count of how many times height was increased
                        //console.log(height + "," + multiplier);
                    }
                }
                else { //if the space outside the canvas on the sides is more than or equal to the space from the top
                    while (width > (MAX_CANVAS_WIDTH - 50)) { //while the width is more than the MAX WIDTH - 10
                        width = parseFloat(width) - 10; // decrease width by 10
                        multiplier++; //keep count of how many times the width was increased
                        //console.log(width + "," + multiplier);
                    }
                }

                //adjust the width and height proportionally to optimally fit the wall on canvas
                wallWidth = parseFloat(wallWidth) - (10 * multiplier); //adjust the width
                wallStartHeight = parseFloat(wallStartHeight) - (10 * multiplier); //adjust the start height
                wallEndHeight = parseFloat(wallEndHeight) - (10 * multiplier); //adjust the end height

                //console.log(wallWidth + "," + wallStartHeight + "," + wallEndHeight);
            }
        }

        function sunroomObjectChanged(value) { 
            for (var i = 0; i < listOfWalls[listOfWalls.length - 1].LastItemIndex; i++) {
                $("#li"+i).css("display", "none");
            }
            for (var i = listOfWalls[value].FirstItemIndex; i <= listOfWalls[value].LastItemIndex; i++) {
                $("#li"+i).css("display", "block");
            }

            drawWall(listOfWalls[value].Length,listOfWalls[value].StartHeight,listOfWalls[value].EndHeight, value); 
        }

        $(document).ready(function () {
            drawCanvas(); //Draws the initial grid
            sunroomObjectChanged("0");
        });

    </script>


          <asp:SqlDataSource ID="sdsDBConnection" runat="server" ConnectionString="<%$ ConnectionStrings:sunspaceDealerDesktopConnectionString %>" SelectCommand="SELECT * FROM [users]"></asp:SqlDataSource>
</asp:Content>
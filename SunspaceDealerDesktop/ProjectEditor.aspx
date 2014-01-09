<%@ Page Title="Project Editor" Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProjectEditor.aspx.cs" Inherits="SunspaceDealerDesktop.ProjectEditor" %>


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
        var canvas = d3.select("#myCanvas")            //Select the div tag with id "myCanvas"
                    .append("svg")                      //Add an svg tag to the selected div tag
                    .attr("width", MAX_CANVAS_WIDTH)    //Set the width of the canvas/grid to MAX_CANVAS_WIDTH
                    .attr("height", MAX_CANVAS_HEIGHT) //Set the height of the canvas/grid to MAX_CANVAS_HEIGHT
                    .style("border", "1px solid black")
                    .append("g")
                    .attr("transform", "translate("+CENTRE_X+","+CENTRE_Y+")");

        var gridPoints;


        /**
        This function gets called when the wall accordion is clicked.
        This function sets all the appropriate attributes 
        to the wall height and width variables
        @param width - width of the wall to be drawn
        @param startHeight - start height of the wall to be drawn
        @param endHeight - end height of the wall to be drawn
        @param wallIndex - index of the wall for editing purposes; also used to draw linear items
        */
        function drawWall(width, startHeight, endHeight, wallIndex) {
            //alert("width: " + width + ", start: " + startHeight + ", end: " + endHeight);

            d3.selectAll("#wall").remove();//remove any previously drawn walls

            wallWidth = width;// * 2;
            wallStartHeight = startHeight;// * 2;
            wallEndHeight = endHeight;// * 2;

            var highHeight = (wallStartHeight < wallEndHeight) ? wallEndHeight : wallStartHeight;

            //wallSlope = wallEndHeight / wallWidth;
            //scaleWall(wallSlope, highHeight, wallWidth);
            
            
            
            


            //////////////// THIS FUNCTION /////////////////
            // scaleWallOptimally(highHeight, wallWidth); //
            /////////////// REQUIRES FIXING ////////////////









            //var scaleX = d3.scale.linear()
            //       .domain([0, wallWidth])
            //       .range([0, MAX_CANVAS_WIDTH]);
            //var scaleY = d3.scale.linear()
            //       .domain([0, highHeight])
            //       .range([0, MAX_CANVAS_HEIGHT]);

            //var wallTopLeft = { "x": (CENTRE_X - (wallWidth / 2)), "y": (CENTRE_Y - (wallStartHeight / 2)) };
            //var wallTopRight = { "x": (CENTRE_X + (wallWidth / 2)), "y": (CENTRE_Y - (wallEndHeight / 2)) };
            //var wallBottomRight = { "x": (CENTRE_X + (wallWidth / 2)), "y": (CENTRE_Y + (wallEndHeight / 2)) };
            //var wallBottomLeft = { "x": (CENTRE_X - (wallWidth / 2)), "y": (CENTRE_Y + (wallEndHeight / 2)) };

            var wallTopLeft = { "x": (-1 * parseFloat(wallWidth)), "y": (-1 * parseFloat(wallStartHeight)) };
            var wallTopRight = { "x": parseFloat(wallWidth), "y": (-1 * parseFloat(wallEndHeight)) };
            var wallBottomRight = { "x": parseFloat(wallWidth), "y": parseFloat(wallEndHeight) };
            var wallBottomLeft = { "x": (-1 * parseFloat(wallWidth)), "y": parseFloat(wallEndHeight) };

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
                             .attr("onclick", "$(\"#MainContent_txtWidth" + wallIndex + "\").focus();"); //put focus on the first editable field for the wall

            //drawLinearItems(wallIndex, wall);

        }

        /**
        This function draws all fo the linear items in the given wall
        @param wallIndex - specifies the wall whose linear items to draw
        @param wall - the html5 polygon which represents the wall on canvas
        */
        function drawLinearItems(wallIndex, wall) {
            var startingPoint = 0;
            for (var i = 0; i < listOfWalls[wallIndex].LinearItems.length; i++) {

                var width = listOfWalls[wallIndex].LinearItems[i].Width;
                var startHeight = listOfWalls[wallIndex].LinearItems[i].StartHeight;
                var endHeight = listOfWalls[wallIndex].LinearItems[i].EndHeight;

                var topLeft = { "x": startingPoint, "y": startingPoint };
                var topRight = { "x": width, "y": (CENTRE_Y - (endHeight / 2)) };
                var bottomRight = { "x": width, "y": (CENTRE_Y + (endHeight / 2)) };
                var bottomLeft = { "x": startingPoint, "y": (CENTRE_Y + (startHeight / 2)) };

                //var li = wall.append(canvas.selectAll("polygon"));

////. CHECK TRANSLATE/SCALE/ETC. https://developer.apple.com/library/safari/documentation/AudioVideo/Conceptual/HTML-canvas-guide/Translation,Rotation,andScaling/Translation,Rotation,andScaling.html

                startingPoint = parseFloat(width) + parseFloat(listOfWalls[wallIndex].LinearItems[i].width);
            }
        }

        /**
        This function scales the currently selected wall to the optimal size to fit any size of canvas
        @param height - height of the given wall
        @param width - width of the given wall
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
                        //console.log("height: " + height + ", multiplier: " + multiplier);
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
            sunroomObjectChanged("0");
        });

    </script>


          <asp:SqlDataSource ID="sdsDBConnection" runat="server" ConnectionString="<%$ ConnectionStrings:sunspaceDealerDesktopConnectionString %>" SelectCommand="SELECT * FROM [users]"></asp:SqlDataSource>
</asp:Content>
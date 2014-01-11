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

        var wallIndex = 0;

        $("#myCanvas").height($(window).height() - 170);
        $("#myCanvas").width($(window).width());

        var GRID_PADDING = 25 / 2;                  //size of the squares in the grid        
        var CELL_PADDING = GRID_PADDING / 2;    //cell padding is half less than the grid padding
        var MAX_CANVAS_WIDTH = $("#myCanvas").width();             //max width of canvas
        var MAX_CANVAS_HEIGHT = $("#myCanvas").height();            //max height of canvas
        var CENTRE_X = MAX_CANVAS_WIDTH / 2;
        var CENTRE_Y = MAX_CANVAS_HEIGHT / 2;

        //var wallStartHeight;
        //var wallEndHeight;
        //var wallWidth;

        /* CREATE CANVAS */
        var svg = d3.select("#myCanvas")            //Select the div tag with id "myCanvas"
                    .append("svg")                      //Add an svg tag to the selected div tag
                    .attr("width", MAX_CANVAS_WIDTH)    //Set the width of the canvas/grid to MAX_CANVAS_WIDTH
                    .attr("height", MAX_CANVAS_HEIGHT) //Set the height of the canvas/grid to MAX_CANVAS_HEIGHT
                    .style("border", "1px solid black");
        var canvas = svg.append("g")
                    .attr("transform", "translate("+CENTRE_X+","+CENTRE_Y+")");
        var wall;
        var scale = d3.scale.linear(); //used to fit the polygons optimally on the canvas

        /**
        This function gets called when the wall accordion is clicked.
        This function sets all the appropriate attributes 
        to the wall height and width variables
        */
        function drawWall() {

            var width = listOfWalls[wallIndex].Length; //wall width
            var startHeight = listOfWalls[wallIndex].StartHeight; //wall start height
            var endHeight = listOfWalls[wallIndex].EndHeight;  //wall end height

            var id = ""; //id to be given to the wall

            var g = wall.append("g").attr("transform", "translate(" + (-1 * scale(parseFloat(width/2))) + "," + (scale(parseFloat(startHeight/2))) + ")");

            console.log("wall w: " + width + ", " + "s: " + startHeight + ", " + "e: " + endHeight); 

            //var topLeft = { "x": (-1 * scale(parseFloat(width/2))), "y": (-1 * scale(parseFloat(startHeight/2))) }; //top left coordinates
            //var topRight = { "x": scale(parseFloat(width/2)), "y": (-1 * scale(parseFloat(endHeight/2))) }; //top right coordinates
            //var bottomRight = { "x": scale(parseFloat(width/2)), "y": scale(parseFloat(endHeight/2)) }; //bottom right coordinates
            //var bottomLeft = { "x": (-1 * scale(parseFloat(width/2))), "y": scale(parseFloat(endHeight/2)) }; //bottom left coordinates

            var topLeft = { "x": scale(parseFloat(0)), "y": (-1 * scale(parseFloat(startHeight))) }; //top left coordinates
            var topRight = { "x": scale(parseFloat(width)), "y": (-1 * scale(parseFloat(endHeight))) }; //top right coordinates
            var bottomRight = { "x": scale(parseFloat(width)), "y": scale(parseFloat(0)) }; //bottom right coordinates
            var bottomLeft = { "x": scale(parseFloat(0)), "y": scale(parseFloat(0)) }; //bottom left coordinates

            var points = [topLeft, topRight, bottomRight, bottomLeft]; //put all the coordinates together in an array

            drawPolygon(points, id, g); //draw the polygon to represent the wall with the given coordinates and id
            
            drawLinearItems((-1 * scale(parseFloat(width/2))),(scale(parseFloat(startHeight/2))));

        }

        /**
        This function draws all fo the linear items in the given wall
        */
        function drawLinearItems(x, y) {
            //var startingPoint = 0;

            var g = wall.append("g").attr("transform", "translate(" + x + "," + y + ")");



            for (var i = 0; i < listOfWalls[wallIndex].LinearItems.length; i++) {

                //alert(i+1);

                var id = "" + listOfWalls[wallIndex].LinearItems[i].LinearIndex;
                var width = listOfWalls[wallIndex].LinearItems[i].Length;
                var startHeight = listOfWalls[wallIndex].LinearItems[i].StartHeight;
                var endHeight = listOfWalls[wallIndex].LinearItems[i].EndHeight;

                console.log("i: " + i + ", " + "w: " + width + ", " + "s: " + startHeight + ", " + "e: " + endHeight); 
                
                var topLeft = { "x": scale(parseFloat(0)), "y": (-1 * scale(parseFloat(startHeight))) }; //top left coordinates
                var topRight = { "x": scale(parseFloat(width)), "y": (-1 * scale(parseFloat(endHeight))) }; //top right coordinates
                var bottomRight = { "x": scale(parseFloat(width)), "y": scale(parseFloat(0)) }; //bottom right coordinates
                var bottomLeft = { "x": scale(parseFloat(0)), "y": scale(parseFloat(0)) }; //bottom left coordinates

                var points = [topLeft, topRight, bottomRight, bottomLeft]; //put all the coordinates together in an array

                drawPolygon(points, id, g); //draw the polygon to represent the wall with the given coordinates and id

                x = parseFloat(x) + scale(parseFloat(width));

                g = wall.append("g").attr("transform", "translate("+ x + "," + y + ")");

                //startingPoint = parseFloat(width) + parseFloat(listOfWalls[wallIndex].LinearItems[i].width);
            }
        }

        /**
        This function draws a polygon on the canvas with the given data points as coordinates and sets it id to the given id
        @param points - coordinates of a given polygon
        @param id - to be given to the polygon object
        */
        function drawPolygon(points, id, g) {
            
            var poly = g.selectAll("polygon")
                     .data([points])
                     .enter().append("polygon")
                     .attr("id", id)
                         .attr("points", function (d) {
                             return d.map(function (d) {
                                 return [d.x, d.y].join(",");
                             }).join(" ");
                         })
                     .attr("fill", "white")
                     .attr("stroke", "black")
                     .attr("stroke-width", "1")
                     .attr("onmouseover", "$(\"#wall\").attr(\"fill\", \"#F3F3F3\");")
                     .attr("onmouseout", "$(\"#wall\").attr(\"fill\", \"white\");");
                     //.attr("onclick", "$(\"#MainContent_txtWidth" + wallIndex + "\").focus();"); //put focus on the first editable field for the wall
        }

        /**
        This function hides and calls the appropriate information according the wall that is selected.
        It also sets the scale of the polygons to be drawn on the canvas to make them fit the canvas optimally
        @param value - index of the wall selected ("value" should be changed to "index", if it's only walls that we're dealing with)
        */
        function sunroomObjectChanged(value) { 
            if ($("#wall"))
                d3.selectAll("#wall").remove(); //remove existing walls
            
            //hide all the li tags
            for (var i = 0; i < listOfWalls[listOfWalls.length - 1].LastItemIndex; i++) {
                $("#li"+i).css("display", "none");
                //if ($("#" + i))
                //    d3.selectAll("#" + i).remove(); //remove existing walls
            }
            //show only the appropriate li tags
            for (var i = listOfWalls[value].FirstItemIndex; i <= listOfWalls[value].LastItemIndex; i++) {
                $("#li"+i).css("display", "block");
            }

            wallIndex = value; //set the wall index global variable
            
            var startHeight = listOfWalls[wallIndex].StartHeight;
            var endHeight = listOfWalls[wallIndex].EndHeight;
            var highHeight = (startHeight > endHeight) ? startHeight : endHeight;

            //set the scale's domain and range according to wall size
            scale.domain([0 , highHeight])
                 .range([0 , (MAX_CANVAS_HEIGHT) - 100]);
            
            wall = canvas.append("g").attr("id", "wall");

            drawWall(); //draw the wall
        }

        $(document).ready(function () {
            sunroomObjectChanged("0"); //when page loads, call sunroomObjectChanged function to set all the default values for wall 0
        });

    </script>


          <asp:SqlDataSource ID="sdsDBConnection" runat="server" ConnectionString="<%$ ConnectionStrings:sunspaceDealerDesktopConnectionString %>" SelectCommand="SELECT * FROM [users]"></asp:SqlDataSource>
</asp:Content>
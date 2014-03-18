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

    <style>
        /*some styling for the axes*/
        .axis text {
            font: 14px sans-serif;
        }
        .axis path,
        .axis line {
              fill: none;
              stroke: #000;
              shape-rendering: crispEdges;
        }
        .label {
            position: absolute;
            /*visibility: hidden;*/
            height: auto;
            width: auto;
            /*z-index: 1;*/
        }
        g {
            position: static;
        }
    </style>

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

        //var GRID_PADDING = 25 / 2;                  //size of the squares in the grid        
        //var CELL_PADDING = GRID_PADDING / 2;    //cell padding is half less than the grid padding
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
        var gWall, gLi, gMod, gWindow, gScreen, gGlass, gVent;
        var scale = d3.scale.linear(); //used to fit the polygons optimally on the canvas

        //var arrLabels = new Array();
        

        /**
        This function gets called when the wall accordion is clicked.
        This function sets all the appropriate attributes 
        to the wall height and length variables
        */
        function drawWall() {

            var length = listOfWalls[wallIndex].Length; //wall length
            var startHeight = listOfWalls[wallIndex].StartHeight - 0.5; //wall start height
            var endHeight = listOfWalls[wallIndex].EndHeight - 0.5;  //wall end height

            var id = ""; //id to be given to the wall
            var title = "Wall " + wallIndex;

            var g = gWall.append("g").attr("transform", "translate(" + (-1 * scale(parseFloat(length/2))) + "," + (scale(parseFloat(startHeight/2))) + ")");

            var topLeft = { "x": scale(parseFloat(0)), "y": (-1 * scale(parseFloat(startHeight))) }; //top left coordinates
            var topRight = { "x": scale(parseFloat(length)), "y": (-1 * scale(parseFloat(endHeight))) }; //top right coordinates
            var bottomRight = { "x": scale(parseFloat(length)), "y": scale(parseFloat(0)) }; //bottom right coordinates
            var bottomLeft = { "x": scale(parseFloat(0)), "y": scale(parseFloat(0)) }; //bottom left coordinates
            var topReceiverLeft = { "x": scale(parseFloat(0)), "y": (-1 * scale(parseFloat(startHeight) + 0.5)) }; //bottom left coordinates;
            var topReceiverRight = { "x": scale(parseFloat(length)), "y": (-1 * scale(parseFloat(endHeight) + 0.5)) }; //bottom left coordinates;
            var bottomReceiverLeft = { "x": scale(parseFloat(0)), "y": scale(parseFloat(0) + 0.5) }; //bottom right coordinates
            var bottomReceiverRight = { "x": scale(parseFloat(length)), "y": scale(parseFloat(0) + 0.5) }; //bottom left coordinates

            var points = [topRight, topLeft, bottomLeft, bottomRight, topReceiverRight, topReceiverLeft, bottomReceiverLeft, bottomReceiverRight, bottomRight]; //put all the coordinates together in an array

            drawPolygon(points, id, title, g); //draw the polygon to represent the wall with the given coordinates and id
            
            drawAxes();
          
            drawLinearItems((-1 * scale(parseFloat(length/2))),(scale(parseFloat(startHeight/2)))); //bottom left coordinates
        }

        /**
        This function draws x and y axes to represent the height and length of the walls and the items within the walls
        */
        function drawAxes() { 

            var length = listOfWalls[wallIndex].Length; //wall length
            var startHeight = listOfWalls[wallIndex].StartHeight; //wall start height
            var endHeight = listOfWalls[wallIndex].EndHeight;  //wall end height

            var mod = 0, i = 0;

            while (!listOfWalls[wallIndex].LinearItems[i].ModularItems) {
                i++;
                mod++;
            }

            var kneewallHeight = listOfWalls[wallIndex].LinearItems[mod].ModularItems[0].FStartHeight;
            //console.log("mod: " + mod + ", height: " + kneewallHeight);

            //bottom (x) axis representing the length
            var bottomScale = d3.scale.ordinal()
                .domain([0 + "\"", length + "\""])
                .rangePoints([0, scale(length)]);

            var bottomAxis = d3.svg.axis()
                .scale(bottomScale)
                .orient("bottom");

            gWall.append("g")
                .attr("transform", "translate(" + 0 + "," + scale(startHeight)/2 + ")")
                .append("g")
                .attr("transform", "translate(" + (scale(length)/2) + "," + 0 + ")")
                .append("g")
                .attr("transform", "translate(" + 0 + "," + 20 + ")")
                .append("g")
                .attr("transform", "translate(" + (-1 * scale(length)) + "," + 0 + ")")
                .attr("class", "x axis")
                .call(bottomAxis);
            //end of bottom (x) axis

            //left (y) axis representing the start height
            var leftScale = d3.scale.ordinal()
                .domain([startHeight + "\"", 0 + "\""])
                .rangePoints([0, scale(startHeight)]);

            var leftAxis = d3.svg.axis()
                .scale(leftScale)
                .orient("left");

            gWall.append("g")
                .attr("transform", "translate(" + ((-1 * scale(parseFloat(length/2))) - 20) + "," + (-1 * scale(parseFloat(startHeight/2))) + ")")
                .attr("class", "x axis")
                .call(leftAxis);
            //end of left (y) axis

            //right (y) axis representing the end height
            var rightScale = d3.scale.ordinal()
                .domain([endHeight + "\"", 0 + "\""])
                .rangePoints([0, scale(endHeight)]);

            var rightAxis = d3.svg.axis()
                .scale(rightScale)
                .orient("right");

            gWall.append("g")
                .attr("transform", "translate(" + 0 + "," + scale(startHeight)/2 + ")")
                .append("g")
                .attr("transform", "translate(" + ((scale(length)/2) + 20) + "," + 0 + ")")
                .append("g")
                .attr("transform", "translate(" + 0 + "," + -1 * scale(endHeight) + ")")
                .attr("class", "x axis")
                .call(rightAxis);
            //end of right (y) axis
        }

        /**
        This function draws all the linear items in the given wall
        @param x - starting x coordinate
        @param y - starting y coordinate
        */
        function drawLinearItems(x,y) {

            var points, topLeft, topRight, bottomRight, bottomLeft;
            gLi = gWall.append("g").attr("transform", "translate(" + x + "," + y + ")");

            for (var i = 0; i < listOfWalls[wallIndex].LinearItems.length; i++) {

                var id = "" + listOfWalls[wallIndex].LinearItems[i].LinearIndex; //id to be given to the polygon
                var title = listOfWalls[wallIndex].LinearItems[i].ItemType;
                var length = listOfWalls[wallIndex].LinearItems[i].Length; //length of the linear item
                var startHeight = listOfWalls[wallIndex].LinearItems[i].StartHeight - 0.5; //start height of the linear item
                var endHeight = listOfWalls[wallIndex].LinearItems[i].EndHeight - 0.5; //end height of the linear item


                switch(listOfWalls[wallIndex].LinearItems[i].ItemType) {
                    case "Mod":
                        var modularItems = listOfWalls[wallIndex].LinearItems[i].ModularItems; //modular items in the linear item
                                                
                            var rise = (startHeight > endHeight) ? (startHeight - endHeight) : (endHeight - startHeight);
                            var height = (startHeight > endHeight) ? "start" : (endHeight === startHeight) ? "equal" : "end";
                            var slope = rise / length;

                        //LINEAR ITEM OUTLINE///////////////////////////////////////////////////////////////////////////////////

                        topLeft = { "x": scale(parseFloat(0)) - 1, "y": (-1 * scale(parseFloat(startHeight)) + 1) }; //top left coordinates
                        topRight = { "x": scale(parseFloat(length)), "y": (-1 * scale(parseFloat(endHeight)) + 1) }; //top right coordinates
                        bottomRight = { "x": scale(parseFloat(length)), "y": scale(parseFloat(0)) }; //bottom right coordinates
                        bottomLeft = { "x": scale(parseFloat(0)), "y": scale(parseFloat(0)) }; //bottom left coordinates

                            //MOD LEFT FRAME////////////////////////////////////////////////////////////////////////////////////////////

                            var insideLeftHeight = (height === "start") ? (startHeight - slope) : (height === "end") ? (startHeight + slope) : startHeight;

                            var insideTopLeft = { "x": scale(parseFloat(1)), "y": (-1 * scale(parseFloat(insideLeftHeight)) + 1) }; //inside top left coordinates
                            var insideBottomLeft = { "x": scale(parseFloat(1)), "y": scale(parseFloat(0)) }; //inside bottom left coordinates
                        
                            //MOD RIGHT FRAME//////////////////////////////////////////////////////////////////////////////////////////

                            var insideRightHeight = (height === "start") ? (endHeight + slope) : (height === "end") ? (endHeight - slope) : endHeight;

                            var insideTopRight = { "x": scale(parseFloat(length) - 1), "y": (-1 * scale(parseFloat(insideRightHeight)) + 1) }; //inside top right coordinates
                            var insideBottomRight = { "x": scale(parseFloat(length) - 1), "y": scale(parseFloat(0)) }; //inside bottom right coordinates

                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

                        points = [bottomLeft,topLeft,insideTopLeft,insideBottomLeft,insideBottomRight,insideTopRight,topRight,bottomRight]; //put all the coordinates together in an array
                        drawPolygon(points, id, title, gLi); //draw the polygon to represent the wall with the given coordinates and id

                        drawModularItems(modularItems, (parseFloat(x) + parseFloat(scale(1))), y, listOfWalls[wallIndex].LinearItems[i].LinearIndex, i);

                        x = parseFloat(x) + scale(parseFloat(length));

                        gLi = gWall.append("g").attr("transform", "translate("+ x + "," + y + ")"); //bottom right coordinates of the linear item
                        break;
                    case "2 Piece Receiver":
                    case "Box Header Receiver":
                    case "Receiver":
                    case "Box Header":
                    case "Filler":
                    case "Corner Post":
                    case "Starter Post":
                    case "Electrical Chase":
                    case "H Channel":
                        
                        topLeft = { "x": scale(parseFloat(0)), "y": (-1 * scale(parseFloat(startHeight)) + 1) }; //top left coordinates
                        topRight = { "x": scale(parseFloat(length)), "y": (-1 * scale(parseFloat(endHeight)) + 1) }; //top right coordinates
                        bottomRight = { "x": scale(parseFloat(length)), "y": scale(parseFloat(0)) }; //bottom right coordinates
                        bottomLeft = { "x": scale(parseFloat(0)), "y": scale(parseFloat(0)) }; //bottom left coordinates

                        points = [topLeft, topRight, bottomRight, bottomLeft]; //put all the coordinates together in an array

                        drawPolygon(points, "filler", title, gLi); //draw the polygon to represent the wall with the given coordinates and id

                        x = parseFloat(x) + scale(parseFloat(length));

                        gLi = gWall.append("g").attr("transform", "translate("+ x + "," + y + ")"); //bottom right coordinates of the linear item

                        break;
                }
                if (listOfWalls[wallIndex].LinearItems[i].ItemType === "Filler") {
                    var text = new Array();
                    text[0] = "F" + (parseInt(listOfWalls[wallIndex].LinearItems[i].LinearIndex) + 1);
                    points[0].y += scale(20);
                    points[1].y += scale(20);
                    points[1].x -= scale(8);
                    points[2].x -= scale(8);
                    addLabels(gLi, points, text);
                    points[0].y -= scale(20);
                    points[1].y -= scale(20);
                    points[1].x += scale(8);
                    points[2].x += scale(8);
                //    arrLabels[i] = { "g": gLi, "frame": points, "text": text };
                }
                //else if (listOfWalls[wallIndex].LinearItems[i].ItemType !== "Mod")
                //    arrLabels[i] = { "g": null, "frame": null, "text": null };
            }
        }

        /**
        This function draws all the modular items within a given linear item
        @param modularItems - the array containing modular items in a given linear item
        @param x - starting x coordinate
        @param y - starting y coordinate
        @param linearIndex - linear item index (to be passed on as an argument to the drawWindowDetails function)
        @param relativeLinearIndex - linear index relative to the particular wall drawn
        */
        function drawModularItems(modularItems, x, y, linearIndex, relativeLinearIndex) {

            var y2 = y;
            gMod = gWall.append("g").attr("transform", "translate("+ x + "," + y + ")"); //bottom right coordinates of the linear item

            for (var i = 0; i < modularItems.length; i++) { 

                var id = "";// + listOfWalls[wallIndex].LinearItems[i].LinearIndex; //id to be given to the polygon
                var title = modularItems[i].ItemType;
                var length = modularItems[i].FLength; ; //length of the modular item
                var startHeight = modularItems[i].FStartHeight; //start height of the modular item
                var endHeight = modularItems[i].FEndHeight; //end height of the modular item
                var leftHeight = modularItems[i].LeftHeight; //left height of the modular item
                var rightHeight = modularItems[i].RightHeight; //right height of the modular item

                switch(modularItems[i].ItemType) {
                    case "Panel":
                            var rise = (leftHeight > rightHeight) ? (leftHeight - rightHeight) : (rightHeight - leftHeight);
                            var height = (leftHeight > rightHeight) ? "start" : (leftHeight === rightHeight) ? "equal" : "end";
                            var slope = rise / length;

                            var topFrame = (i === parseFloat(modularItems.length) - 1) ? 0 : 0.5;
                            var bottomFrame = (i === 0) ? 0 : 0.5;
                            var frame = 0.5;

                        var topLeft = { "x": scale(parseFloat(0) + frame), "y": (-1 * scale(parseFloat(leftHeight) - topFrame)) }; //top left coordinates
                        var topRight = { "x": scale(parseFloat(length) - frame), "y": (-1 * scale(parseFloat(rightHeight) - topFrame)) }; //top right coordinates
                        var bottomRight = { "x": scale(parseFloat(length) - frame), "y": scale(parseFloat(0) - bottomFrame) }; //bottom right coordinates
                        var bottomLeft = { "x": scale(parseFloat(0) + frame), "y": scale(parseFloat(0) - bottomFrame) }; //bottom left coordinates

                        var points = [topLeft, topRight, bottomRight, bottomLeft]; //put all the coordinates together in an array

                        if (i < (parseFloat(modularItems.length) - 1)) {

                            var pt1 = { "x": scale(parseFloat(0)), "y": (-1 * scale(parseFloat(endHeight))) }; //line left coordinates
                            var pt2 = { "x": scale(parseFloat(length)), "y": (-1 * scale(parseFloat(endHeight))) }; //line left coordinates

                            drawLine(pt1, pt2, gMod);
                        }

                        break;
                    case "Transom":
                    case "Kneewall":
                    case "Window":
                        var id = "";// + listOfWalls[wallIndex].LinearItems[i].LinearIndex; //id to be given to the polygon
                        var title = modularItems[i].ItemType;
                        var length = modularItems[i].FLength; ; //length of the modular item
                        var startHeight = modularItems[i].FStartHeight; //start height of the modular item
                        var endHeight = modularItems[i].FEndHeight; //end height of the modular item
                        var leftHeight = modularItems[i].LeftHeight; //left height of the modular item
                        var rightHeight = modularItems[i].RightHeight; //right height of the modular item
                
                        var insideTopLeft = { "x": scale(parseFloat(0) + 1), "y": (-1 * scale(parseFloat(leftHeight) - 1)) }; //top left coordinates
                        var insideTopRight = { "x": scale(parseFloat(length) - 1), "y": (-1 * scale(parseFloat(rightHeight) - 1)) }; //top right coordinates
                        var insideBottomRight = { "x": scale(parseFloat(length) - 1), "y": scale(parseFloat(0) - 1) }; //bottom right coordinates
                        var insideBottomLeft = { "x": scale(parseFloat(0) + 1), "y": scale(parseFloat(0) - 1) }; //bottom left coordinates

                        var insidePoints = [insideTopLeft, insideTopRight, insideBottomRight, insideBottomLeft]; //put all the coordinates together in an array

                        drawWindowDetails(modularItems[i], insidePoints, modularItems.length, linearIndex, relativeLinearIndex);

                        if (i == 0) {

                            var pt1 = { "x": scale(parseFloat(0)), "y": (insideTopLeft.y - scale(1)) }; //line left coordinates
                            var pt2 = { "x": scale(parseFloat(length)), "y": (insideTopRight.y - scale(1)) }; //line left coordinates

                            drawLine(pt1, pt2, gMod);
                        }
                        else if (i == parseFloat(modularItems.length) - 1) {

                            var pt1 = { "x": scale(parseFloat(0)), "y": (insideBottomLeft.y + scale(1)) }; //line left coordinates
                            var pt2 = { "x": scale(parseFloat(length)), "y": (insideBottomRight.y + scale(1)) }; //line left coordinates

                            drawLine(pt1, pt2, gMod);
                        }
                        break;
                    case "Door":
                        break;
                    case "Box Header":
                        break;
                    case "Receiver":
                        break;
                }

                drawPolygon(insidePoints, id, title, gMod); //draw the polygon to represent the wall with the given coordinates and id

                y2 = parseFloat(y2) - scale(parseFloat(endHeight));

                //console.log("startHeight: " + startHeight + ", endheight: " + endHeight + ", y: " + y + ", y2: " + y2);

                gMod = gWall.append("g").attr("transform", "translate("+ x + "," + y2 + ")");
            }
        }


        /**
        This function draws the details of a given window
        @param window - the window object
        @param frame - the window frame coordinates
        @param transomIndex - modular index of the transom
        @param linearIndex - index of the linear item which contains this window
        @param relativeLinearIndex - index of the linear item relative to the wall drawn
        */
        function drawWindowDetails(window, frame, transomIndex, linearIndex, relativeLinearIndex) {

            var pt1, pt2, topLeft, topRight, bottomLeft, bottomRight, leftSlider, rightSlider;

            drawPolygon(frame, "", "", gMod); //draw the polygon to represent the wall with the given coordinates and id
            gWindow = gMod.append("g").attr("transform", "translate("+ frame[3].x + "," + frame[3].y + ")");

            switch(window.WindowStyle) {
                case "Double Slider": //glass model 300
                case "Single Slider": //glass model 400
                case "Horizontal Roller XX": //glass model 300
                case "Horizontal Roller": //H2T model 200
                case "Horizontal 2 Track": //H2T model 200
                case "Horizontal Two Track": //H2T model 200
                case "H2T": //H2T model 200

                    //window.SpreaderBar = window.LeftHeight / 2; //for debuggin purposes

                    pt1 = { "x": scale((window.Width / 2) - 1), "y": scale(0) }; //line left coordinates
                    pt2 = { "x": scale((window.Width / 2) - 1), "y": (-1 * scale(window.LeftHeight - 2)) }; //line left coordinates

                    drawLine(pt1, pt2, gWindow, 2);

                    topLeft = { "x": (frame[0].x + scale(1)), "y": (frame[0].y + scale(3)) }; //top left coordinates
                    topRight = { "x": scale((window.Width / 2) - 3), "y": (frame[1].y + scale(3)) }; //top right coordinates
                    bottomRight = { "x": scale((window.Width / 2) - 3), "y": (frame[2].y - scale(1)) }; //bottom right coordinates
                    bottomLeft = { "x": (frame[3].x + scale(1)), "y": (frame[3].y - scale(1)) }; //bottom left coordinates

                    leftSlider = [topLeft, topRight, bottomRight, bottomLeft]; //put all the coordinates together in an array

                    drawPolygon(leftSlider, "", "", gWindow); //draw the polygon to represent the wall with the given coordinates and id

                    if (window.SpreaderBar !== 0) {
                        gVent = gWindow.append("g");
                        pt1 = { "x": topLeft.x, "y": -scale(window.SpreaderBar) }; //lne left coordinates
                        pt2 = { "x": topRight.x, "y": -scale(window.SpreaderBar) }; //line left coordinates
                        drawLine(pt1, pt2, gVent, 2);
                    }

                    gWindow = gMod.append("g").attr("transform", "translate("+ frame[3].x + "," + frame[3].y + ")");

                    topLeft = { "x": scale((window.Width / 2) - 0.5), "y": (frame[0].y + scale(3)) }; //top left coordinates
                    topRight = { "x": scale(window.Width - 4), "y": (frame[1].y + scale(3)) }; //top right coordinates
                    bottomRight = { "x": scale(window.Width - 4), "y": (frame[2].y - scale(1)) }; //bottom right coordinates
                    bottomLeft = { "x": scale((window.Width / 2) - 0.5), "y": (frame[3].y - scale(1)) }; //bottom left coordinates

                    rightSlider = [topLeft, topRight, bottomRight, bottomLeft]; //put all the coordinates together in an array

                    drawPolygon(rightSlider, "", "", gWindow); //draw the polygon to represent the wall with the given coordinates and id

                    if (window.SpreaderBar !== 0) {
                        gVent = gWindow.append("g");
                        pt1 = { "x": topLeft.x, "y": -scale(window.SpreaderBar) }; //line left coordinates
                        pt2 = { "x": topRight.x, "y": -scale(window.SpreaderBar) }; //line left coordinates
                        drawLine(pt1, pt2, gVent, 2);
                    }
                        
                    //drawGlassLines(leftSlider);
                    //drawGlassLines(rightSlider);

                    break;

                case "Vertical 4 Track": //V4T
                case "Vertical Four Track": //V4T
                case "V4T": //V4T
                    var ventHeight = 0;
                    
                    gVent = gWindow.append("g");

                    for (var i = 0; i < window.NumVents; i++) {
                        ventHeight = scale(window.VentHeights[i] / 4); ///4 because the vent heights are messed up
                        
                        var yBottom = (i === (window.NumVents - 1)) ? -(ventHeight - scale(1)) : -(ventHeight - scale(0.5));

                        topLeft = { "x": scale(1), "y": scale(-1) }; //top left coordinates
                        topRight = { "x": scale(window.Width - 3), "y": scale(-1) }; //top right coordinates
                        bottomRight = { "x": scale(window.Width - 3), "y": yBottom }; //bottom right coordinates
                        bottomLeft = { "x": (scale(1)), "y": yBottom }; //bottom left coordinates

                        var slider = [topLeft, topRight, bottomRight, bottomLeft]; //put all the coordinates together in an array

                        drawPolygon(slider, "", "", gVent); //draw the polygon to represent the wall with the given coordinates and id

                        if (window.SpreaderBar !== 0) {

                            var yTop = (i === (window.NumVents - 1)) ? -(ventHeight - scale(1)) : -(ventHeight - scale(0.5));

                            pt1 = { "x": scale(window.SpreaderBar), "y": scale(-1) }; //line left coordinates
                            pt2 = { "x": scale(window.SpreaderBar), "y": yTop }; //line left coordinates
                            drawLine(pt1, pt2, gVent, 2);
                        }

                        //drawGlassLines(slider);

                        gVent = gVent.append("g").attr("transform", "translate("+ 0 + "," + (parseFloat(-ventHeight)) + ")");

                    }

                    ventHeight = 0;
                    for (var i = 0; i < window.NumVents - 1; i++) {
                        ventHeight += scale(window.VentHeights[i] / 4); ///4 because the vent heights are messed up
                        gVent = gWindow.append("g").attr("transform", "translate("+ 0 + "," + -ventHeight + ")");
                        pt1 = { "x": scale(0), "y": scale(0) }; //line left coordinates
                        pt2 = { "x": scale(parseFloat(window.Width) - 2), "y": scale(0) }; //line left coordinates
                        drawLine(pt1, pt2, gVent, 1);

                    }
                    
                    break;
                case "Vinyl":
                    break;
                case "Glass":
                    break;
                case "Screen":
                    break;
                case "Solid Wall":
                    break;
            }        

            if (window.ScreenType != "No Screen" && window.ScreenType != "NoScreen" && window.ScreenType != "" && typeof window.ScreenType !== 'undefined') 
                drawScreen(frame); //draw screen lines

            if (window.ModuleIndex != 0 && window.ModuleIndex != (transomIndex - 1)) {
                var text, width, height;
                //get the width of the window; if width contains a decimal value, convert it into a fraction string
                width = ((window.FLength + "").indexOf(".") != -1) ? convertDecimalToFractions(window.FLength + "") : window.FLength;
                //get the height of the window; if height contains a decinal value, convert it into a fraction string
                height = ((window.FStartHeight + "").indexOf(".") != -1) ? convertDecimalToFractions(window.FStartHeight + "") : window.FStartHeight;
                //set the label text
                text = new Array();
                text[0] = 'W' + (parseInt(linearIndex) + 1); 
                text[1] = width + "\" x " + height + "\" " + window.WindowStyle;

                //call the addLabels function to add the labels on the windows
                addLabels(gWindow, frame, text);

                //arrLabels[relativeLinearIndex] = { "g": gLi, "frame": frame, "text": text };
            }
        }

        /**
        This function draws the screen on a given window
        @param frame - the window frame coordinates
        */
        function drawScreen(frame) {

            var pt1, pt2;
            gScreen = gWindow.append("g");

            //Draws vertical lines of the screen onto the window
            for (var i = frame[0].x; i < frame[1].x - scale(1); i += scale(0.5)) {
                pt1 = { "x": i, "y": -1 }; //line left coordinates
                pt2 = { "x": i, "y":  (frame[1].y + scale(1) + 1) }; //line left coordinates
                drawLine(pt1, pt2, gScreen, 1, "black", 0.05);
            }

            //Draws horizontal lines of the screen onto the window
            for (var i = frame[1].y + scale(2); i < frame[2].y + scale(1); i += scale(0.5)) {
                pt1 = { "x": (frame[0].x - scale(1) + 1), "y": i }; //line left coordinates
                pt2 = { "x": (frame[1].x - scale(1) - 1), "y": i }; //line left coordinates
                drawLine(pt1, pt2, gScreen, 1, "black", 0.05);
            }
        }

        /**
        This function draws glass lines (3 diagonal lines) on a given window
        @param frame - the window frame coordinates
        */
        function drawGlassLines(frame) {

            var xMid, yMid;

            xMid = (frame[1].x - frame[0].x);
            yMid = (frame[1].y - frame[2].y);

            gGlass = gWindow.append("g").attr("transform", "translate("+ (xMid / 2) + "," + (yMid / 2) + ")");

            pt1 = { "x": -(xMid / 3), "y": -(yMid / 3) }; //line left coordinates
            pt2 = { "x": (xMid / 3), "y": (yMid / 3) }; //line left coordinates
            //drawLine(pt1, pt2, gGlass);

            /////work in progress

        }

        /**
        This function draws a polygon on the canvas with the given data points as coordinates and sets it id to the given id
        @param pt1 - x and y coordinates of starting point
        @param pt2 - x and y coordinates of ending point
        @param g - the <g> element on which to append the line
        @param strokeWidth - width of the line drawn
        @param stroke - colour of the line drawn
        @param opacity - transparency of the line
        */
        function drawLine(pt1, pt2, g, strokeWidth, stroke, opacity) {

            strokeWidth = typeof strokeWidth !== 'undefined' ? strokeWidth : 1;
            stroke = typeof stroke !== 'undefined' ? stroke : "black";
            opacity = typeof opacity !== 'undefined' ? opacity : 1.0;

            var poly = g.append("line")
                     .attr("x1", pt1.x)
                     .attr("y1", pt1.y)
                     .attr("x2", pt2.x)
                     .attr("y2", pt2.y)
                     .attr("stroke", stroke)
                     .attr("stroke-width", strokeWidth)
                     .attr("stroke-opacity", opacity);

            //.attr("onmouseover", "$(\"#wall\").attr(\"fill\", \"#F3F3F3\");")
            //.attr("onmouseout", "$(\"#wall\").attr(\"fill\", \"white\");");
            //.attr("onclick", "$(\"#MainContent_txtWidth" + wallIndex + "\").focus();"); //put focus on the first editable field for the wall
        }

        /**
        This function draws a polygon on the canvas with the given data points as coordinates and sets it id to the given id
        @param points - coordinates of a given polygon
        @param id - to be given to the polygon object
        @param title - to give a name to the shape drawn
        @param g - the <g> element on which to append the polygon
        */
        function drawPolygon(points, id, title, g) {
            //alert(title);
            var poly = g.selectAll("polygon")
                     .data([points])
                     .enter().append("polygon")
                     .attr("id", id)
                     .attr("title", title)
                         .attr("points", function (d) { 
                             return d.map(function (d) { 
                                 return [d.x, d.y].join(",");
                             }).join(" ");
                         })
                     .attr("fill", "white")
                     .attr("stroke", "black")
                     .attr("stroke-width", "1");
                     //.attr("onmouseover", "$(\"#wall\").attr(\"fill\", \"#F3F3F3\");")
                     //.attr("onmouseout", "$(\"#wall\").attr(\"fill\", \"white\");");
                     //.attr("onclick", "alert"); //put focus on the first editable field for the wall
        }

        /**
        This function draws a recangle on the canvas with the given data points as coordinates and sets it id to the given id
        @param g - the <g> element on which to append the rect
        @param width - rectangle width
        @param height - rectangle height
        @param x - starting x coordinate
        @param y - starting y coordinate
        @param colour - fill colour (default: white)
        @param opacity - fill opacity (default: 1.0)
        @param stroke - outline stroke colour (default: black)
        */
        function drawRect(g, width, height, x, y, colour, opacity, stroke) {
            
            colour = typeof colour !== 'undefined' ? colour : "white";
            opacity = typeof opacity !== 'undefined' ? opacity : 1.0;
            stroke = typeof stroke !== 'undefined' ? stroke : "black";

            var rect = g.style('z-index', 999).append('rect')
                .attr("class", "label")
                .attr('width', width)
                .attr('height', height)
                .attr('x', x)
                .attr('y', y)
                .style('fill', colour)
                .style('fill-opacity', opacity)
                .attr('stroke', stroke);
                
            //.attr("onmouseover", "$(\"#wall\").attr(\"fill\", \"#F3F3F3\");")
            //.attr("onmouseout", "$(\"#wall\").attr(\"fill\", \"white\");");
            //.attr("onclick", "alert"); //put focus on the first editable field for the wall
        }

        /**
        This function draws a polygon on the canvas with the given data points as coordinates and sets it id to the given id
        @param g - the <g> element in which to add the labels
        @param frame - coordinates of the frame in which to add labels
        @param label - label text in an array (for multi-line labels)
        */
        function addLabels(g, frame, label) {

            //for (var i = 0; i < arrLabels.length; i++) {

                //alert(arrLabels[i].text);

                //if (arrLabels[i].text) {

                    var count = 0; //count the characters in each string element of the label
                    var index = 0; //index of the label element with the longest string
                    var text = ""; //value of the longest string
            
                    for (var j = 0; j < label.length; j++) {
                        if (count < label[j].length) { //if this string is longer than the one before
                            count = label[j].length; //get its length 
                            index = j; //get its index 
                            text = label[j]; //get its text 
                        }
                    }

                    //this text is drawn temporarily only to determine how wide of a rectangle needs to be drawn
                    //this element will be deleted
                    drawText(g, (frame[1].x / 2), (frame[0].y / 2), "tempLabel", label); 
            
                    var labelElement = document.getElementById("tempLabel"); //get the temporary label element
            
                    var width = labelElement.clientWidth + 10; //width of the rectangle to be drawn, determined by the width of the temp label
                    var height = (labelElement.clientHeight * label.length) + 10; //height of the rectangle to be drawn, determined by the height of the temp label
                    var x = (frame[1].x / 2) - ((labelElement.clientWidth / 2) + 5); //starting x coordinate, determined by frame size and temp label width
                    var y = (frame[0].y / 2) - labelElement.clientHeight; //starting y coordinate, determined by frame size and temp label height
            
                    drawRect(g, width, height, x, y, "white", 0.9); //draw the rectangle
         
                    $("#tempLabel").remove(); //remove the temp label element from the DOM so we can redraw it with the same ID for other windows

                    drawText(g, (frame[1].x / 2), (frame[0].y / 2), "", label[0], "14px", "bold"); //draw the actual label text (line 1)
                    drawText(g, (frame[1].x / 2), ((frame[0].y / 2) + (height / 2) - 5), "", label[1]); //draw the actual label text (line 2)
                //}
            //}
        }

        /**
        This function adds the label text on the drawing
        @param g - the <g> element on which to append text
        @param x - starting x coordinate
        @param y - starting y coordinate
        @param id - element id
        @param text - label text
        @param size - font-size (default: 14px)
        @param weight - font-weight (default: normal)
        @param colour - font colour (default: black)
        @param anchor - text alignment (default: middle)
        */
        function drawText(g, x, y, id, text, size, weight, colour, anchor) {

            size = typeof size !== 'undefined' ? size : "14px";
            weight = typeof weight !== 'undefined' ? weight : "normal";
            colour = typeof colour !== 'undefined' ? colour : "black";
            anchor = typeof anchor !== 'undefined' ? anchor : "middle";

            //Add SVG Text Element Attributes
            var text = g.append("text")
                             .attr("x", x)
                             .attr("y", y)
                             .attr("id", id)
                             .attr("class", "label")
                             .text(text)
                             .style("text-anchor", anchor)
                             .attr("font-family", "sans-serif")
                             .attr("font-size", size)
                             .attr("font-weight", weight)
                             .attr("fill", colour);

            //.attr("onmouseover", "$(\"#wall\").attr(\"fill\", \"#F3F3F3\");")
            //.attr("onmouseout", "$(\"#wall\").attr(\"fill\", \"white\");");
            //.attr("onclick", "$(\"#MainContent_txtWidth" + wallIndex + "\").focus();"); //put focus on the first editable field for the wall
        }

        /**
        This function hides and calls the appropriate information according the wall that is selected.
        It also sets the scale of the polygons to be drawn on the canvas to make them fit the canvas optimally
        @param value - index of the wall selected ("value" should be changed to "index", if it's only walls that we're dealing with)
        */
        function sunroomObjectChanged(value) { 

            //arrLabels = new Array();

            if ($("#wall"))
                d3.selectAll("#wall").remove(); //remove existing walls
            
            //hide all the li tags
            for (var i = 0; i < listOfWalls[listOfWalls.length - 1].LastItemIndex; i++) 
                $("#li"+i).css("display", "none");
            
            //show only the appropriate li tags
            for (var i = listOfWalls[value].FirstItemIndex; i <= listOfWalls[value].LastItemIndex; i++) 
                $("#li"+i).css("display", "block");
            

            wallIndex = value; //set the wall index global variable
            
            var startHeight = listOfWalls[wallIndex].StartHeight;
            var endHeight = listOfWalls[wallIndex].EndHeight;
            var highHeight = (startHeight > endHeight) ? startHeight : endHeight;
            var length = listOfWalls[wallIndex].Length;

            //temporary scale to see if the enlarged wall will fit the canvas
            scale.domain([0 , highHeight])
                 .range([0 , MAX_CANVAS_HEIGHT - 100]);

            //check if the enlarged wall width is greater than canvas width
            //and set the upper domain and range
            var upperDomain = (scale(length) < (MAX_CANVAS_WIDTH - 200)) ? highHeight : length;
            var upperRange = (scale(length) < (MAX_CANVAS_WIDTH - 200)) ? (MAX_CANVAS_HEIGHT - 100) : (MAX_CANVAS_WIDTH - 150);
            
            //set the scale's domain and range according to wall size
            scale.domain([0 , upperDomain])
                 .range([0 , upperRange]);
            
            gWall = canvas.append("g").attr("id", "wall");

            drawWall(); //draw the wall
            //addLabels();
            //console.log(arrLabels);
        }

        /**
        This function converts a decimal number into its equivalent fraction value
        @param num - number to be converted
        @return fraction value as a string
        */
        function convertDecimalToFractions(num) {
            var numerator, denominator, factor, quotient, remainder, fraction;
            
            num = num.split("."); //split the left and right side of the decimal value
            numerator = num[0] + num[1]; //add the left and right side of the decimal value and set it to numerator
            denominator = Math.pow(10,num[1].length); //multiply the denominator to keep it proportional to the numerator
            factor  = highestCommonFactor(numerator, denominator); //get the greatest common factor (GCF)
            numerator /= factor; //divide numerator by the GCF
            denominator /= factor; //divide the denominator by the GCF
            
            if (numerator > denominator) { //if the numerator is greater than the denominator
                quotient = parseInt(numerator / denominator); //get the quotient
                remainder = parseInt(numerator % denominator); //get the remainder
                
                //convert the remainder into a fraction by recursively calling the same function
                //concatenate it with the quotient to get the complete fraction
                fraction = quotient + " " + convertDecimalToFractions("0." + remainder);
            }
            else {
                //concatenate the numerator and denominator to make a fraction
                fraction = numerator + "/" + denominator;
            }

            //return the fraction as a string
            return fraction;
        }

        /**
        Reference: https://codereview.stackexchange.com/questions/20258/converting-decimals-to-fractions-with-javascript-simplify-improve
        This function gives you the highest common factor for a given numerator and denominator
        @param a - numerator
        @param b - denominator
        @return highest common factor 
        */
        function highestCommonFactor(a,b) {
            if (b==0) return a;
            return highestCommonFactor(b,a%b);
        }

        function bringLabelsToFront() { 

            var elements = document.getElementsByTagName("*");
            var highest_index = 0;

            for (var i = 0; i < elements.length - 1; i++) {
                if (parseInt(elements[i].style.zIndex) > highest_index) {
                    highest_index = parseInt(elements[i].style.zIndex);
                    
                }
                //alert(elements[i].style.zIndex);
            }

            //alert(highest_index);

            // find all labels
            var labels = $(".label");

            for (var i = 0; i < labels.length; i++) {
                //$(".label").eq(i).css("z-index", (parseInt(highest_index) + 1));
                $(".label").eq(i).css("z-index", 1000);
                //alert($(".label").eq(i).html());
            }

            //// Set up click handlers for each box
            ////boxes.click(function() {
            ////    var el = $(this), // The box that was clicked
            //    var max = 0;

            //    // Find the highest z-index
            //    boxes.each(function() {
            //        // Find the current z-index value
            //        var z = parseInt( $( this ).css( "z-index" ), 10 );
            //        // Keep either the current max, or the current z-index, whichever is higher
            //        max = Math.max( max, z );
            //    });

            //    // Set the box that was clicked to the highest z-index plus one
            //    labelsel.css("z-index", max + 1 );
            ////});
        }


        $(document).ready(function () {
            sunroomObjectChanged("0"); //when page loads, call sunroomObjectChanged function to set all the default values for wall 0
            //$("#filler").style.zIndex = -1;
        });

    </script>
          <asp:SqlDataSource ID="sdsDBConnection" runat="server" ConnectionString="<%$ ConnectionStrings:sunspaceDealerDesktopConnectionString %>" SelectCommand="SELECT * FROM [users]"></asp:SqlDataSource>
</asp:Content>
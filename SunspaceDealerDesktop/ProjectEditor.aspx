<%@ Page Title="Project Editor" Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProjectEditor.aspx.cs" Inherits="SunspaceDealerDesktop.ProjectEditor" %>


<asp:Content runat="server" ID="SecondaryNavigation" ContentPlaceHolderID="SecondaryNavigation">   
    <nav class="navEditor">
        <ul class="ulNavEditor">
            <li><asp:DropDownList ID="ddlSunroomObjects" Width="160" runat="server"></asp:DropDownList></li>
            <!-- Note: this hyperlink has a javascript a click event attached to it, see the last few lines of Page_Load in codebehind -->
            <li><asp:HyperLink ID="lnkEditorNavMods" CssClass="editMods" runat="server">Edit Mods</asp:HyperLink></li>
            <li><asp:HyperLink ID="lnkEditorNavTools" runat="server">Tools</asp:HyperLink>
                <ul>
                    <li><asp:HyperLink ID="lnkEditorNavSave" runat="server" ToolTip="Save recent changes locally">Save</asp:HyperLink></li>
                    <li><asp:HyperLink ID="lnkEditorNavUndo" runat="server" ToolTip="Undo last change">Undo</asp:HyperLink></li>
                    <li><asp:HyperLink ID="lnkEditorNavRedo" runat="server" ToolTip="Redo last change">Redo</asp:HyperLink></li>
                    <li><asp:HyperLink ID="lnkEditorNavAddMod" runat="server" ToolTip="Add a mod in the selected position">Add</asp:HyperLink></li>
                    <li><asp:HyperLink ID="lnkEditorNavDeleteMod" runat="server" ToolTip="Delete selected mod">Delete</asp:HyperLink></li>
                    <li><asp:HyperLink ID="lnkEditorNavMoveLeft" runat="server" ToolTip="Move selected mod to the left">Left</asp:HyperLink></li>
                    <li><asp:HyperLink ID="lnkEditorNavMoveRight" runat="server" ToolTip="Move selected mod to the right">Right</asp:HyperLink></li>
                    <li><asp:HyperLink ID="lnkEditorNavPrint" runat="server" ToolTip="Print the sunroom specs">Print</asp:HyperLink></li>
                </ul>
            </li>
        </ul>
        <%--<ul id="saveButtons" class="ulNavEditor float-right">--%>
            <!-- Note: these 2 hyperlinks have javascript functions attached to their click events, see the last few lines of Page_Load in codebehind -->
            <%--<li class="float-right"><asp:HyperLink ID="lnkUpdateSunroom" runat="server" ToolTip="Click to update the sunroom temporarily/locally">Update</asp:HyperLink></li>--%>
            <%--<li class="float-right"><asp:HyperLink ID="lnkSubmitSunroom" runat="server" ToolTip="Click to submit the sunroom to the database to save it permanently">Submit</asp:HyperLink></li>--%>
        <%--</ul>--%>
    </nav>
</asp:Content>

<asp:Content runat="server" ID="ModOverlay" ContentPlaceHolderID="ModOverlay">
    <%--<asp:Label ID="lblProjectSunroom" AssociatedControlID="radProjectSunroom" runat="server" Text="Mod 1"></asp:Label>--%>
    <div class="overlayContainer">
        <div class="overlayClose"><a href="#"><span>X</span> Close Mods Editor</a></div>
        
        <ul class="toggleOptions">
            
            <asp:PlaceHolder ID="ModOptions" runat="server"></asp:PlaceHolder>                    

            <%--<div class="toggleContent">--%>            
                <%--<ul>--%>                
                    <%--<li>--%>                
                        <%--<asp:RadioButton ID="radSunroomModel100" OnClick="newProjectCheckQuestion3()" GroupName="sunroomModel" runat="server" />--%>                <%--<asp:Label ID="lblSunroomModel100Radio" AssociatedControlID="radSunroomModel100" runat="server"></asp:Label>--%>           
                            <%--<asp:Label ID="lblSunroomModel100" AssociatedControlID="radSunroomModel100" runat="server" Text="Model 100"></asp:Label>--%>                    <%--</li>--%>                        <%--<li>--%>                            <%--<asp:RadioButton ID="radSunroomModel200" OnClick="newProjectCheckQuestion3()" GroupName="sunroomModel" runat="server" />--%>                            <%--<asp:Label ID="lblSunroomModel200Radio" AssociatedControlID="radSunroomModel200" runat="server"></asp:Label>--%>                            <%--<asp:Label ID="lblSunroomModel200" AssociatedControlID="radSunroomModel200" runat="server" Text="Model 200"></asp:Label>--%>                        <%--</li>--%>                        <%--<li>
                            <%--<asp:RadioButton ID="radSunroomModel300" OnClick="newProjectCheckQuestion3()" GroupName="sunroomModel" runat="server" />--%>                            <%--<asp:Label ID="lblSunroomModel300Radio" AssociatedControlID="radSunroomModel300" runat="server"></asp:Label>--%>                            <%--<asp:Label ID="lblSunroomModel300" AssociatedControlID="radSunroomModel300" runat="server" Text="Model 300"></asp:Label>--%>                            <%--</li>--%>                        <%--<li>
                            <%--<asp:RadioButton ID="radSunroomModel400" OnClick="newProjectCheckQuestion3()" GroupName="sunroomModel" runat="server" />--%>                        <%--<asp:Label ID="lblSunroomModel400Radio" AssociatedControlID="radSunroomModel400" runat="server"></asp:Label>--%>                            <%--<asp:Label ID="lblSunroomModel400" AssociatedControlID="radSunroomModel400" runat="server" Text="Model 400"></asp:Label>--%>                            <%--</li>--%>                        <%--</ul>--%>                        <%--</div>--%>                            <%--</li>--%>                            <%--<asp:Label ID="lblError" runat="server"></asp:Label>--%>
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

    <asp:Label ID="lblTitle" runat="server" Text="Label" CssClass="float-right"></asp:Label> <br />
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
            z-index: 999;
        }
        g {
            position: relative;
        }
    </style>

    <script>

        var listOfWalls = <%= hidJsonObjects.Value %>; //get the list of walls from server side via codebehind
        version = 0; //version for undo/redo purposes
        var jsonVersions = new Array(); //to keep track of versions for undo/redo purposes
        jsonVersions[0] = listOfWalls; //initialize the first element of the array with the sunroom retrieved from the db

        //console.log(listOfWalls);
        //console.log(jsonVersions[0]);
        console.log(jsonVersions[version]);

        var roofCount = '<%= roofCount %>'; //not used
        var floorCount = '<%= floorCount %>'; //not used
        var wallCount = '<%= wallCount %>'; //not used
        var projectId = '<%= projectId %>';  //not used

        var wallIndex = 0; //the index of the wall currently selected and drawn on canvas (= -1 for room layout)

        $("#myCanvas").height($(window).height() - 170); //set the height of the svg canvas 
        $("#myCanvas").width($(window).width()); //set the width of the svg canvas

        var MAX_CANVAS_WIDTH = $("#myCanvas").width();             //max width of canvas 
        var MAX_CANVAS_HEIGHT = $("#myCanvas").height();            //max height of canvas
        var CENTRE_X = MAX_CANVAS_WIDTH / 2; //x coordinate for the centre of the canvas
        var CENTRE_Y = MAX_CANVAS_HEIGHT / 2; //y coordinate for the centre of the canvas

        /* CREATE CANVAS */
        var svg = d3.select("#myCanvas")            //Select the div tag with id "myCanvas"
                    .append("svg")                      //Add an svg tag to the selected div tag
                    .attr("width", MAX_CANVAS_WIDTH)    //Set the width of the canvas/grid to MAX_CANVAS_WIDTH
                    .attr("height", MAX_CANVAS_HEIGHT) //Set the height of the canvas/grid to MAX_CANVAS_HEIGHT
                    .style("border", "1px solid black");

        //append a <g> to the centre of the main canvas; this will be used to draw everything
        var canvas = svg.append("g")
                    .attr("transform", "translate("+CENTRE_X+","+CENTRE_Y+")");

        //declare some <g> element tags variables which will be used throughout
        var gLayout, gWall, gLi, gMod, gWindow, gDoor, gScreen, gGlass, gVent;

        //d3 linear scale for scaling the drawing appropriately
        var scale = d3.scale.linear(); //used to fit the polygons optimally on the canvas
        
        //projection; for room layout purposes
        var projection, antiProjection;

        //this was being used when attempting to bring all of the label to the front but it didn't work out
        //var arrLabels = new Array();


        /**
        This function gets called when the room layout dropdown is clicked.
        This function sets all the appropriate attributes 
            to the wall height and length variables
        This function approaches the layout in 2 ways: 
            Case 1. if the projection (on the left) is greater than or equal to the 
                antiprojection (on the right); it draws the layout from first wall to the last
                drawing the first wall perpendicular to the existing wall.
            Case 2. if the antiprojection (on the right) is greater than the projection 
                (on the left): it draws the layout from the last wall to the first
                drawing the last wall perpendicular to the existing wall.
        In each case, it draws each linear item in a given wall, swithing directions 
            as the orientation of the wall changes.
        This function also sets the text value of the label on the top right of the canvas
            with the name of linear item that is being hovered over with the mouse.

        Note: presently, cornerposts are not drawn correctly. They need to be attached to the
            end of the first wall and beginning of the next wall.
        */
        function drawRoomLayout() {

            //draw existing wall at the top
            drawRect(canvas, MAX_CANVAS_WIDTH, scale(10), -CENTRE_X, -CENTRE_Y, "existingWall", "#a8a8a8",1,"black","$(this).css('fill', '#ccffff'); $('#<%= lblTitle.ClientID %>').text('Existing Wall'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', '#a8a8a8'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "toggleDiv('"+id+"')");   
            
            //declare and initialize text variable to set the text of the label at the top right of the canvas
            var text = "";

            //Case 2//////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (antiProjection > projection) {
            
                //x and y coordinates for the layout <g> tag in which to draw all the layout drawings
                var x = scale(getWidth() / 2); //starting at the end (last wall) 
                var y = -parseFloat(CENTRE_Y) + (scale(parseFloat(10))); //starting perpendicular to the existing wall

                //create the layout <g> tag and position it appropriately 
                gLayout = canvas.append("g").attr("transform", "translate("+x+","+y+")").attr("id", "layout");

                // for each wall in the current json version of list of walls starting with the last and counting down
                for (var i = jsonVersions[version].length - 1; i >= 0; i--) {

                    //if it is an east facing wall
                    if (jsonVersions[version][i].Orientation.toLowerCase() === "e") {

                        //for each linear item in this wall starting with the last and counting down
                        for (var j = jsonVersions[version][i].LinearItems.length - 1; j >= 0; j--) {

                            var id = "div_"+jsonVersions[version][i].LinearItems[j].LinearIndex; //id to be given to the polygon
                            var title = jsonVersions[version][i].LinearItems[j].ItemType; //title for setting the label text
                            var length = jsonVersions[version][i].LinearItems[j].Length; //length of the linear item

                            //determine what type of linear item it is
                            switch (jsonVersions[version][i].LinearItems[j].ItemType.toLowerCase()) {
                                case "mod": //door/window mod
                                    
                                    //get the door or window type from the list of modular items in this mod (total modular items - 2 = door or window type)
                                    var modularItem = jsonVersions[version][i].LinearItems[j].ModularItems[jsonVersions[version][i].LinearItems[j].ModularItems.length - 2];
                                    //get the style of door or window for setting the label text
                                    var modularItemStyle = modularItem.ItemType === "Door" ? modularItem.DoorType + " " + modularItem.DoorStyle : modularItem.WindowStyle;
                                    //get the width of the window; if width contains a decimal value, convert it into a fraction string
                                    var width = ((modularItem.FLength + "").indexOf(".") != -1) ? convertDecimalToFractions(modularItem.FLength + "") : modularItem.FLength;
                                    //get the height of the window; if height contains a decinal value, convert it into a fraction string
                                    var height = ((modularItem.FStartHeight + "").indexOf(".") != -1) ? convertDecimalToFractions(modularItem.FStartHeight + "") : modularItem.FStartHeight;
                                    //set the label text
                                    text = width + "\" x " + height + "\" " +  modularItemStyle + " " + modularItem.ItemType;
                                    break;
                                case "2 piece receiver": case "2piecereceiver":
                                case "box header receiver": case "boxheaderreceiver":
                                case "receiver": case "receiever":
                                case "box header": case "boxheader":
                                case "filler":
                                case "corner post": case "corner": case "corner post": 
                                    //var topLeft = { "x": scale(parseFloat(0)), "y": (-1 * scale(parseFloat(startHeight))) }; //top left coordinates
                                    //var topRight;
                                    //var middleLeft;
                                    //var middleRight;
                                    //var bottomRight;
                                    //var bottomLeft;
                                    //var points;
                                case "starter post": case "starterpost":
                                case "electrical chase": case "electricalchase":
                                case "h channel": case "hchannel":
                                    text = title; //for setting the label text
                                    break;
                            }
                            //draw the rectangle representing the linear item
                            drawRect(gLayout, scale(2), scale(length), -scale(1), 0, "", "white", 1, "black", "$(this).css('fill', '#ccffff'); $('#<%= lblTitle.ClientID %>').text('"+text+"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "toggleDiv('"+id+"')");
                            //append another <g> tag for and position is appropriately for drawing the next linear item
                            gLayout = gLayout.append("g").attr("transform", "translate(0,"+scale(length)+")"); //bottom right coordinates of the linear item
                        }
                    }

                    //if it is an west facing wall
                    if (jsonVersions[version][i].Orientation.toLowerCase() === "w") {

                        //for each linear item in this wall starting with the last and counting down
                        for (var j = jsonVersions[version][i].LinearItems.length - 1; j >= 0; j--) {

                            var id = "div_"+jsonVersions[version][i].LinearItems[j].LinearIndex; //id to be given to the polygon
                            var title = jsonVersions[version][i].LinearItems[j].ItemType;//title for setting the label text
                            var length = jsonVersions[version][i].LinearItems[j].Length; //length of the linear item

                            //determine what type of linear item it is
                            switch (jsonVersions[version][i].LinearItems[j].ItemType.toLowerCase()) {
                                case "mod"://door/window mod
                                    
                                    //get the door or window type from the list of modular items in this mod (total modular items - 2 = door or window type)
                                    var modularItem = jsonVersions[version][i].LinearItems[j].ModularItems[jsonVersions[version][i].LinearItems[j].ModularItems.length - 2];
                                    //get the style of door or window for setting the label text
                                    var modularItemStyle = modularItem.ItemType === "Door" ? modularItem.DoorType + " " + modularItem.DoorStyle : modularItem.WindowStyle;
                                    //get the width of the window; if width contains a decimal value, convert it into a fraction string
                                    var width = ((modularItem.FLength + "").indexOf(".") != -1) ? convertDecimalToFractions(modularItem.FLength + "") : modularItem.FLength;
                                    //get the height of the window; if height contains a decinal value, convert it into a fraction string
                                    var height = ((modularItem.FStartHeight + "").indexOf(".") != -1) ? convertDecimalToFractions(modularItem.FStartHeight + "") : modularItem.FStartHeight;
                                    //set the label text
                                    text = width + "\" x " + height + "\" " +  modularItemStyle + " " + modularItem.ItemType;
                                    break;
                                case "2 piece receiver": case "2piecereceiver":
                                case "box header receiver": case "boxheaderreceiver":
                                case "receiver": case "receiever":
                                case "box header": case "boxheader":
                                case "filler":
                                case "corner post": case "corner": case "corner post": 
                                    //var topLeft = { "x": scale(parseFloat(0)), "y": (-1 * scale(parseFloat(startHeight))) }; //top left coordinates
                                    //var topRight;
                                    //var middleLeft;
                                    //var middleRight;
                                    //var bottomRight;
                                    //var bottomLeft;
                                    //var points;
                                case "starter post": case "starterpost":
                                case "electrical chase": case "electricalchase":
                                case "h channel": case "hchannel":
                                    text = title; //for setting the label text
                                    break;
                            }
                            //draw the rectangle representing the linear item
                            drawRect(gLayout, scale(2), scale(length), -scale(1), -scale(length), "", "white", 1, "black", "$(this).css('fill', '#ccffff'); $('#<%= lblTitle.ClientID %>').text('"+text+"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "toggleDiv('"+id+"')");
                            //append another <g> tag for and position is appropriately for drawing the next linear item
                            gLayout = gLayout.append("g").attr("transform", "translate(0,"+(-(scale(length)))+")"); //bottom right coordinates of the linear item
                        }
                    }
                    //if it is an south facing wall
                    if (jsonVersions[version][i].Orientation.toLowerCase() === "s") {

                        //for each linear item in this wall starting with the last and counting down
                        for (var j = jsonVersions[version][i].LinearItems.length - 1; j >= 0; j--) {

                            var id = "div_"+jsonVersions[version][i].LinearItems[j].LinearIndex; //id to be given to the polygon
                            var title = jsonVersions[version][i].LinearItems[j].ItemType;//title for setting the label text
                            var length = jsonVersions[version][i].LinearItems[j].Length; //length of the linear item

                            //determine what type of linear item it is
                            switch (jsonVersions[version][i].LinearItems[j].ItemType.toLowerCase()) {
                                case "mod"://door/window mod
                                    
                                    //get the door or window type from the list of modular items in this mod (total modular items - 2 = door or window type)
                                    var modularItem = jsonVersions[version][i].LinearItems[j].ModularItems[jsonVersions[version][i].LinearItems[j].ModularItems.length - 2];
                                    //get the style of door or window for setting the label text
                                    var modularItemStyle = modularItem.ItemType === "Door" ? modularItem.DoorType + " " + modularItem.DoorStyle : modularItem.WindowStyle;
                                    //get the width of the window; if width contains a decimal value, convert it into a fraction string
                                    var width = ((modularItem.FLength + "").indexOf(".") != -1) ? convertDecimalToFractions(modularItem.FLength + "") : modularItem.FLength;
                                    //get the height of the window; if height contains a decinal value, convert it into a fraction string
                                    var height = ((modularItem.FStartHeight + "").indexOf(".") != -1) ? convertDecimalToFractions(modularItem.FStartHeight + "") : modularItem.FStartHeight;
                                    //set the label text
                                    text = width + "\" x " + height + "\" " +  modularItemStyle + " " + modularItem.ItemType;
                                    break;
                                case "2 piece receiver": case "2piecereceiver":
                                case "box header receiver": case "boxheaderreceiver":
                                case "receiver": case "receiever":
                                case "box header": case "boxheader":
                                case "filler":
                                case "corner post": case "corner": case "corner post": 
                                    //var topLeft = { "x": scale(parseFloat(0)), "y": (-1 * scale(parseFloat(startHeight))) }; //top left coordinates
                                    //var topRight;
                                    //var middleLeft;
                                    //var middleRight;
                                    //var bottomRight;
                                    //var bottomLeft;
                                    //var points;
                                case "starter post": case "starterpost":
                                case "electrical chase": case "electricalchase":
                                case "h channel": case "hchannel":
                                    text = title; //for setting the label text
                                    break;
                            }
                            //draw the rectangle representing the linear item
                            drawRect(gLayout, scale(length), scale(2), (-(scale(length))), 0, "", "white", 1, "black", "$(this).css('fill', '#ccffff'); $('#<%= lblTitle.ClientID %>').text('"+text+"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "toggleDiv('"+id+"')");
                            //append another <g> tag for and position is appropriately for drawing the next linear item
                            gLayout = gLayout.append("g").attr("transform", "translate("+(-(scale(length)))+",0)"); //bottom right coordinates of the linear item
                        }
                    }
                    //if it is an north facing wall
                    else if (jsonVersions[version][i].Orientation.toLowerCase() === "n") {

                        //for each linear item in this wall starting with the last and counting down
                        for (var j = jsonVersions[version][i].LinearItems.length - 1; j >= 0; j--) {

                            var id = "div_"+jsonVersions[version][i].LinearItems[j].LinearIndex; //id to be given to the polygon
                            var title = jsonVersions[version][i].LinearItems[j].ItemType;//title for setting the label text
                            var length = jsonVersions[version][i].LinearItems[j].Length; //length of the linear item

                            //determine what type of linear item it is
                            switch (jsonVersions[version][i].LinearItems[j].ItemType.toLowerCase()) {
                                case "mod"://door/window mod
                                    
                                    //get the door or window type from the list of modular items in this mod (total modular items - 2 = door or window type)
                                    var modularItem = jsonVersions[version][i].LinearItems[j].ModularItems[jsonVersions[version][i].LinearItems[j].ModularItems.length - 2];
                                    //get the style of door or window for setting the label text
                                    var modularItemStyle = modularItem.ItemType === "Door" ? modularItem.DoorType + " " + modularItem.DoorStyle : modularItem.WindowStyle;
                                    //get the width of the window; if width contains a decimal value, convert it into a fraction string
                                    var width = ((modularItem.FLength + "").indexOf(".") != -1) ? convertDecimalToFractions(modularItem.FLength + "") : modularItem.FLength;
                                    //get the height of the window; if height contains a decinal value, convert it into a fraction string
                                    var height = ((modularItem.FStartHeight + "").indexOf(".") != -1) ? convertDecimalToFractions(modularItem.FStartHeight + "") : modularItem.FStartHeight;
                                    //set the label text
                                    text = width + "\" x " + height + "\" " +  modularItemStyle + " " + modularItem.ItemType;
                                    break;
                                case "2 piece receiver": case "2piecereceiver":
                                case "box header receiver":case "boxheaderreceiver":
                                case "receiver": case "receiever":
                                case "box header": case "boxheader":
                                case "filler":
                                case "corner post": case "corner": case "corner post": 
                                    //var topLeft = { "x": scale(parseFloat(0)), "y": (-1 * scale(parseFloat(startHeight))) }; //top left coordinates
                                    //var topRight;
                                    //var middleLeft;
                                    //var middleRight;
                                    //var bottomRight;
                                    //var bottomLeft;
                                    //var points;
                                case "starter post": case "starterpost":
                                case "electrical chase": case "electricalchase":
                                case "h channel": case "hchannel":
                                    text = title; //for setting the label text
                                    break;
                            }
                            //draw the rectangle representing the linear item
                            drawRect(gLayout, scale(2), scale(length), 0, 0, "", "white", 1, "black", "$(this).css('fill', '#ccffff'); $('#<%= lblTitle.ClientID %>').text('"+text+"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "toggleDiv('"+id+"')");
                            //append another <g> tag for and position is appropriately for drawing the next linear item
                            gLayout = gLayout.append("g").attr("transform", "translate(0,"+scale(length)+")"); //bottom right coordinates of the linear item
                        }
                    }
                }
            }//Case 2 end////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            else { //Case 1 //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                //x and y coordinates for the layout <g> tag in which to draw all the layout drawings
                var x = -scale(getWidth() / 2);//starting at the end (last wall) 
                var y = -parseFloat(CENTRE_Y) + (scale(parseFloat(10)));//starting perpendicular to the existing wall

                //create the layout <g> tag and position it appropriately 
                gLayout = canvas.append("g").attr("transform", "translate("+x+","+y+")").attr("id", "layout");

                // for each wall in the current json version of list of walls starting with the first and counting up
                for (var i = 0; i < jsonVersions[version].length; i++) {

                    //if it is an west facing wall
                    if (jsonVersions[version][i].Orientation.toLowerCase() === "w") {

                        //for each linear item in this wall starting with the first and counting up
                        for (var j = 0; j < jsonVersions[version][i].LinearItems.length; j++) {

                            var id = "div_"+jsonVersions[version][i].LinearItems[j].LinearIndex; //id to be given to the polygon
                            var title = jsonVersions[version][i].LinearItems[j].ItemType;//title for setting the label text
                            var length = jsonVersions[version][i].LinearItems[j].Length; //length of the linear item

                            //determine what type of linear item it is
                            switch (jsonVersions[version][i].LinearItems[j].ItemType.toLowerCase()) {
                                case "mod"://door/window mod
                                    
                                    //get the door or window type from the list of modular items in this mod (total modular items - 2 = door or window type)
                                    var modularItem = jsonVersions[version][i].LinearItems[j].ModularItems[jsonVersions[version][i].LinearItems[j].ModularItems.length - 2];
                                    //get the style of door or window for setting the label text
                                    var modularItemStyle = modularItem.ItemType === "Door" ? modularItem.DoorType + " " + modularItem.DoorStyle : modularItem.WindowStyle;
                                    //get the width of the window; if width contains a decimal value, convert it into a fraction string
                                    var width = ((modularItem.FLength + "").indexOf(".") != -1) ? convertDecimalToFractions(modularItem.FLength + "") : modularItem.FLength;
                                    //get the height of the window; if height contains a decinal value, convert it into a fraction string
                                    var height = ((modularItem.FStartHeight + "").indexOf(".") != -1) ? convertDecimalToFractions(modularItem.FStartHeight + "") : modularItem.FStartHeight;
                                    //set the label text
                                    text = width + "\" x " + height + "\" " +  modularItemStyle + " " + modularItem.ItemType;
                                    break;
                                case "2 piece receiver": case "2piecereceiver":
                                case "box header receiver": case "boxheaderreceiver":
                                case "receiver": case "receiever":
                                case "box header": case "boxheader":
                                case "filler":
                                case "corner post": case "corner": case "corner post": 
                                    //var topLeft = { "x": scale(parseFloat(0)), "y": (-1 * scale(parseFloat(startHeight))) }; //top left coordinates
                                    //var topRight;
                                    //var middleLeft;
                                    //var middleRight;
                                    //var bottomRight;
                                    //var bottomLeft;
                                    //var points;
                                case "starter post": case "starterpost":
                                case "electrical chase": case "electricalchase":
                                case "h channel": case "hchannel":
                                    text = title;
                                    break;
                            }
                            //draw the rectangle representing the linear item
                            drawRect(gLayout, scale(2), scale(length), -scale(1), 0, "", "white", 1, "black", "$(this).css('fill', '#ccffff'); $('#<%= lblTitle.ClientID %>').text('"+text+"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "toggleDiv('"+id+"')");
                            //append another <g> tag for and position is appropriately for drawing the next linear item
                            gLayout = gLayout.append("g").attr("transform", "translate(0,"+scale(length)+")"); //bottom right coordinates of the linear item
                        }
                    }
                    
                    //if it is an east facing wall
                    if (jsonVersions[version][i].Orientation.toLowerCase() === "e") {

                        //for each linear item in this wall starting with the first and counting up
                        for (var j = 0; j < jsonVersions[version][i].LinearItems.length; j++) {

                            var id = "div_"+jsonVersions[version][i].LinearItems[j].LinearIndex; //id to be given to the polygon
                            var title = jsonVersions[version][i].LinearItems[j].ItemType;//title for setting the label text
                            var length = jsonVersions[version][i].LinearItems[j].Length; //length of the linear item

                            //determine what type of linear item it is
                            switch (jsonVersions[version][i].LinearItems[j].ItemType.toLowerCase()) {
                                case "mod"://door/window mod
                                    
                                    //get the door or window type from the list of modular items in this mod (total modular items - 2 = door or window type)
                                    var modularItem = jsonVersions[version][i].LinearItems[j].ModularItems[jsonVersions[version][i].LinearItems[j].ModularItems.length - 2];
                                    //get the style of door or window for setting the label text
                                    var modularItemStyle = modularItem.ItemType === "Door" ? modularItem.DoorType + " " + modularItem.DoorStyle : modularItem.WindowStyle;
                                    //get the width of the window; if width contains a decimal value, convert it into a fraction string
                                    var width = ((modularItem.FLength + "").indexOf(".") != -1) ? convertDecimalToFractions(modularItem.FLength + "") : modularItem.FLength;
                                    //get the height of the window; if height contains a decinal value, convert it into a fraction string
                                    var height = ((modularItem.FStartHeight + "").indexOf(".") != -1) ? convertDecimalToFractions(modularItem.FStartHeight + "") : modularItem.FStartHeight;
                                    //set the label text
                                    text = width + "\" x " + height + "\" " +  modularItemStyle + " " + modularItem.ItemType;
                                    break;
                                case "2 piece receiver": case "2piecereceiver":
                                case "box header receiver": case "boxheaderreceiver":
                                case "receiver": case "receiever":
                                case "box header": case "boxheader":
                                case "filler":
                                case "corner post": case "corner": case "corner post": 
                                    //var topLeft = { "x": scale(parseFloat(0)), "y": (-1 * scale(parseFloat(startHeight))) }; //top left coordinates
                                    //var topRight;
                                    //var middleLeft;
                                    //var middleRight;
                                    //var bottomRight;
                                    //var bottomLeft;
                                    //var points;
                                case "starter post": case "starterpost":
                                case "electrical chase": case "electricalchase":
                                case "h channel": case "hchannel":
                                    text = title; //for setting the label text
                                    break;
                            }
                            //draw the rectangle representing the linear item
                            drawRect(gLayout, scale(2), scale(length), -scale(1), -scale(length), "", "white", 1, "black", "$(this).css('fill', '#ccffff'); $('#<%= lblTitle.ClientID %>').text('"+text+"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "toggleDiv('"+id+"')");
                            //append another <g> tag for and position is appropriately for drawing the next linear item
                            gLayout = gLayout.append("g").attr("transform", "translate(0,"+(-(scale(length)))+")"); //bottom right coordinates of the linear item
                        }
                    }

                    //if it is an south facing wall
                    if (jsonVersions[version][i].Orientation.toLowerCase() === "s") {

                        //for each linear item in this wall starting with the first and counting up
                        for (var j = 0; j < jsonVersions[version][i].LinearItems.length; j++) {

                            var id = "div_"+jsonVersions[version][i].LinearItems[j].LinearIndex; //id to be given to the polygon
                            var title = jsonVersions[version][i].LinearItems[j].ItemType;//title for setting the label text
                            var length = jsonVersions[version][i].LinearItems[j].Length; //length of the linear item

                            //determine what type of linear item it is
                            switch (jsonVersions[version][i].LinearItems[j].ItemType.toLowerCase()) {
                                case "mod"://door/window mod
                                    
                                    //get the door or window type from the list of modular items in this mod (total modular items - 2 = door or window type)
                                    var modularItem = jsonVersions[version][i].LinearItems[j].ModularItems[jsonVersions[version][i].LinearItems[j].ModularItems.length - 2];
                                    //get the style of door or window for setting the label text
                                    var modularItemStyle = modularItem.ItemType === "Door" ? modularItem.DoorType + " " + modularItem.DoorStyle : modularItem.WindowStyle;
                                    //get the width of the window; if width contains a decimal value, convert it into a fraction string
                                    var width = ((modularItem.FLength + "").indexOf(".") != -1) ? convertDecimalToFractions(modularItem.FLength + "") : modularItem.FLength;
                                    //get the height of the window; if height contains a decinal value, convert it into a fraction string
                                    var height = ((modularItem.FStartHeight + "").indexOf(".") != -1) ? convertDecimalToFractions(modularItem.FStartHeight + "") : modularItem.FStartHeight;
                                    //set the label text
                                    text = width + "\" x " + height + "\" " +  modularItemStyle + " " + modularItem.ItemType;
                                    break;
                                case "2 piece receiver": case "2piecereceiver":
                                case "box header receiver": case "boxheaderreceiver":
                                case "receiver": case "receiever":
                                case "box header": case "boxheader":
                                case "filler":
                                case "corner post": case "corner": case "corner post": 
                                    //var topLeft = { "x": scale(parseFloat(0)), "y": (-1 * scale(parseFloat(startHeight))) }; //top left coordinates
                                    //var topRight;
                                    //var middleLeft;
                                    //var middleRight;
                                    //var bottomRight;
                                    //var bottomLeft;
                                    //var points;
                                case "starter post": case "starterpost":
                                case "electrical chase": case "electricalchase":
                                case "h channel": case "hchannel":
                                    text = title; //for setting the label text
                                    break;
                            }
                            //draw the rectangle representing the linear item
                            drawRect(gLayout, scale(length), scale(2), 0, 0, "", "white", 1, "black", "$(this).css('fill', '#ccffff'); $('#<%= lblTitle.ClientID %>').text('"+text+"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "toggleDiv('"+id+"')");
                            //append another <g> tag for and position is appropriately for drawing the next linear item
                            gLayout = gLayout.append("g").attr("transform", "translate("+((scale(length)))+",0)"); //bottom right coordinates of the linear item
                        }
                    }

                    //if it is an north facing wall
                    else if (jsonVersions[version][i].Orientation.toLowerCase() === "n") {

                        //for each linear item in this wall starting with the first and counting up
                        for (var j = 0; j < jsonVersions[version][i].LinearItems.length; j++) {

                            var id = "div_"+jsonVersions[version][i].LinearItems[j].LinearIndex; //id to be given to the polygon
                            var title = jsonVersions[version][i].LinearItems[j].ItemType;//title for setting the label text
                            var length = jsonVersions[version][i].LinearItems[j].Length; //length of the linear item

                            //determine what type of linear item it is
                            switch (jsonVersions[version][i].LinearItems[j].ItemType.toLowerCase()) {
                                case "mod"://door/window mod
                                    
                                    //get the door or window type from the list of modular items in this mod (total modular items - 2 = door or window type)
                                    var modularItem = jsonVersions[version][i].LinearItems[j].ModularItems[jsonVersions[version][i].LinearItems[j].ModularItems.length - 2];
                                    //get the style of door or window for setting the label text
                                    var modularItemStyle = modularItem.ItemType === "Door" ? modularItem.DoorType + " " + modularItem.DoorStyle : modularItem.WindowStyle;
                                    //get the width of the window; if width contains a decimal value, convert it into a fraction string
                                    var width = ((modularItem.FLength + "").indexOf(".") != -1) ? convertDecimalToFractions(modularItem.FLength + "") : modularItem.FLength;
                                    //get the height of the window; if height contains a decinal value, convert it into a fraction string
                                    var height = ((modularItem.FStartHeight + "").indexOf(".") != -1) ? convertDecimalToFractions(modularItem.FStartHeight + "") : modularItem.FStartHeight;
                                    //set the label text
                                    text = width + "\" x " + height + "\" " +  modularItemStyle + " " + modularItem.ItemType;
                                    break;
                                case "2 piece receiver": case "2piecereceiver":
                                case "box header receiver": case "boxheaderreceiver":
                                case "receiver": case "receiever":
                                case "box header": case "boxheader":
                                case "filler":
                                case "corner post": case "corner": case "cornerpost": 
                                    //var topLeft = { "x": scale(parseFloat(0)), "y": (-1 * scale(parseFloat(startHeight))) }; //top left coordinates
                                    //var topRight;
                                    //var middleLeft;
                                    //var middleRight;
                                    //var bottomRight;
                                    //var bottomLeft;
                                    //var points;
                                case "starter post": case "starterpost":
                                case "electrical chase": case "electricalchase":
                                case "h channel": case "hchannel":
                                    text = title; //for setting the label text
                                    break;
                            }
                            //draw the rectangle representing the linear item
                            drawRect(gLayout, scale(length), scale(2), 0, 0, "", "white", 1, "black", "$(this).css('fill', '#ccffff'); $('#<%= lblTitle.ClientID %>').text('"+text+"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "toggleDiv('"+id+"')");
                            //append another <g> tag for and position is appropriately for drawing the next linear item
                            gLayout = gLayout.append("g").attr("transform", "translate(0,"+scale(length)+")"); //bottom right coordinates of the linear item
                        }
                    }
                }            
            } //Case 1 end//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        }        

        /**
        This function gets called when the wall dropdown is clicked.
        This function sets all the appropriate attributes 
        to the wall height and length variables and draws it on the canvas
        This function also calls the drawAxes() function to draw left/right/bottom axes on the canvas
        */
        function drawWall() {

            var length = jsonVersions[version][wallIndex].Length; //wall length
            var startHeight = jsonVersions[version][wallIndex].StartHeight - 0.5; //wall start height
            var endHeight = jsonVersions[version][wallIndex].EndHeight - 0.5;  //wall end height

            var id = "wall_" + jsonVersions[version][wallIndex].FirstItemIndex; //id to be given to the wall
            var title = "Wall " + wallIndex; //title to be given to the wall

            //create the <g> element in which all of the wall attributes will be drawn
            var g = gWall.append("g").attr("transform", "translate(" + (-1 * scale(parseFloat(length/2))) + "," + (scale(parseFloat(startHeight/2))) + ")");

            var topLeft = { "x": scale(parseFloat(0)), "y": (-1 * scale(parseFloat(startHeight))) }; //top left coordinates
            var topRight = { "x": scale(parseFloat(length)), "y": (-1 * scale(parseFloat(endHeight))) }; //top right coordinates
            var bottomRight = { "x": scale(parseFloat(length)), "y": scale(parseFloat(0)) }; //bottom right coordinates
            var bottomLeft = { "x": scale(parseFloat(0)), "y": scale(parseFloat(0)) }; //bottom left coordinates
            var topReceiverLeft = { "x": scale(parseFloat(0)), "y": (-1 * scale(parseFloat(startHeight) + 0.5)) }; //top right receiver coordinates;
            var topReceiverRight = { "x": scale(parseFloat(length)), "y": (-1 * scale(parseFloat(endHeight) + 0.5)) }; //top left receiver coordinates;
            var bottomReceiverLeft = { "x": scale(parseFloat(0)), "y": scale(parseFloat(0) + 0.5) }; //bottom left receiver coordinates
            var bottomReceiverRight = { "x": scale(parseFloat(length)), "y": scale(parseFloat(0) + 0.5) }; //bottom right receiver coordinates

            var points = [topRight, topLeft, bottomLeft, bottomRight, topReceiverRight, topReceiverLeft, bottomReceiverLeft, bottomReceiverRight, bottomRight]; //put all the coordinates together in an array

            //draw the polygon representing the wall
            drawPolygon(points, "", title, g, "white", 1, "black", "$(this).css('fill', '#ccffff'); $('#<%= lblTitle.ClientID %>').text('Top & Bottom Receivers'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "toggleDiv('"+id+"')"); //draw the polygon to represent the wall with the given coordinates and id
            
            //draw left/right/bottom axes
            drawAxes();
          
            //draw linear items for the selected wall
            drawLinearItems((-1 * scale(parseFloat(length/2))),(scale(parseFloat(startHeight/2)))); //passing wall bottom left coordinates as parameters
        }

        /**
        This function draws x and y axes to represent the height and length of the walls and the items within the walls

        Note: This function should also place ticks on the scales where the window/door start and end and 
            other relevant information about the wall, however, this function currently doesn't support that.
            This is because d3 scale doesn't allow for ticks to be placed on the scales randomly, only evenly
            spaced ticks can be placed on the scales. To support customized scales the scales need to be 
            drawn manually. D3 scales cannot be used. 
        */
        function drawAxes() { 

            var length = jsonVersions[version][wallIndex].Length; //wall length
            var startHeight = jsonVersions[version][wallIndex].StartHeight; //wall start height
            var endHeight = jsonVersions[version][wallIndex].EndHeight;  //wall end height

            //var mod = 0, i = 0;

            //while (!jsonVersions[version][wallIndex].LinearItems[i].ModularItems) {
            //    i++;
            //    mod++;
            //}


            //to set the tick for kneewall heights on the scales, but the scale doesn't allow ticks to be placed randomly
            //only even distanced ticks can be placed on the scale
            //var kneewallHeight = jsonVersions[version][wallIndex].LinearItems[mod].ModularItems[0].FStartHeight;
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
        If the linear item is a door or window mod, it calls the drawModularItems function
        This function also calls the label adding function for fillers.

        @param x - starting x coordinate
        @param y - starting y coordinate

        Note: Dan's project editor adds labels for other linear items as well (e.g. h channel)
            This function needs to be able to support that. See the if statement at the end of the function
            where it checks for "filler", simply add an elseif for hchannels (etc.) to add labels for them.
        */
        function drawLinearItems(x,y) {

            //declare variables which will be used in this function
            var points, topLeft, topRight, bottomRight, bottomLeft;
            //create the <g> element in which all linear item details will be drawn
            gLi = gWall.append("g").attr("transform", "translate(" + x + "," + y + ")");

            //for each linear item in the list of linear items in the selected wall
            for (var i = 0; i < jsonVersions[version][wallIndex].LinearItems.length; i++) {

                var id = "div_" + jsonVersions[version][wallIndex].LinearItems[i].LinearIndex; //id to be given to the polygon
                var title = jsonVersions[version][wallIndex].LinearItems[i].ItemType; //title to be given to the polygon
                var length = jsonVersions[version][wallIndex].LinearItems[i].Length; //length of the linear item
                var startHeight = jsonVersions[version][wallIndex].LinearItems[i].StartHeight - 0.5; //start height of the linear item
                var endHeight = jsonVersions[version][wallIndex].LinearItems[i].EndHeight - 0.5; //end height of the linear item

                //determine what type of linear item it is
                switch(jsonVersions[version][wallIndex].LinearItems[i].ItemType.toLowerCase()) {
                    case "mod": //if it is a door/window mod
                        var modularItems = jsonVersions[version][wallIndex].LinearItems[i].ModularItems; //modular items in the linear item
                            
                            //calculate the rise
                            var rise = (startHeight > endHeight) ? (startHeight - endHeight) : (endHeight - startHeight);
                            //determine whether start or end height is higher
                            var height = (startHeight > endHeight) ? "start" : (endHeight === startHeight) ? "equal" : "end";
                            //calculate the slope
                            var slope = rise / length;

                        //LINEAR ITEM OUTLINE///////////////////////////////////////////////////////////////////////////////////

                        topLeft = { "x": scale(parseFloat(0)) - 1, "y": (-1 * scale(parseFloat(startHeight)) + 1) }; //top left coordinates
                        topRight = { "x": scale(parseFloat(length)), "y": (-1 * scale(parseFloat(endHeight)) + 1) }; //top right coordinates
                        bottomRight = { "x": scale(parseFloat(length)), "y": scale(parseFloat(0)) }; //bottom right coordinates
                        bottomLeft = { "x": scale(parseFloat(0)), "y": scale(parseFloat(0)) }; //bottom left coordinates

                        //MOD LEFT FRAME////////////////////////////////////////////////////////////////////////////////////////////
                        //set the left height of the frame by adding or subtracting the slope from the start height depending on whether the start height or end height is higher
                        var insideLeftHeight = (height === "start") ? (startHeight - slope) : (height === "end") ? (startHeight + slope) : startHeight;

                        var insideTopLeft = { "x": scale(parseFloat(1)), "y": (-1 * scale(parseFloat(insideLeftHeight)) + 1) }; //inside top left coordinates
                        var insideBottomLeft = { "x": scale(parseFloat(1)), "y": scale(parseFloat(0)) }; //inside bottom left coordinates
                        
                        //MOD RIGHT FRAME//////////////////////////////////////////////////////////////////////////////////////////
                        //set the right height of the frame by adding or subtracting the slope from the start height depending on whether the start height or end height is higher
                        var insideRightHeight = (height === "start") ? (endHeight + slope) : (height === "end") ? (endHeight - slope) : endHeight;

                        var insideTopRight = { "x": scale(parseFloat(length) - 1), "y": (-1 * scale(parseFloat(insideRightHeight)) + 1) }; //inside top right coordinates
                        var insideBottomRight = { "x": scale(parseFloat(length) - 1), "y": scale(parseFloat(0)) }; //inside bottom right coordinates

                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

                        points = [bottomLeft,topLeft,insideTopLeft,insideBottomLeft,insideBottomRight,insideTopRight,topRight,bottomRight]; //put all the coordinates together in an array
                        
                        // THIS LINE IS THE RIGHT LINE ... THE LINE BELOW IS A HOT FIX ....drawPolygon(points, "", title, gLi, "white", 1, "black", "$(this).css('fill', '#ccffff'); $('#<%= lblTitle.ClientID %>').text('"+jsonVersions[version][wallIndex].LinearItems[i].ModularItems[jsonVersions[version][wallIndex].LinearItems[i].ModularItems.length - 2].ItemType+ " " + jsonVersions[version][wallIndex].LinearItems[i].ItemType + "'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "toggleDiv('"+id+"')"); //draw the polygon to represent the wall with the given coordinates and id
                        drawPolygon(points, "", title, gLi, "white", 1, "black", "$(this).css('fill', '#ccffff'); $('#<%= lblTitle.ClientID %>').text('"+jsonVersions[version][wallIndex].LinearItems[i].ModularItems[jsonVersions[version][wallIndex].LinearItems[i].ModularItems.length - 1].ItemType+ " " + jsonVersions[version][wallIndex].LinearItems[i].ItemType + "'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "toggleDiv('"+id+"')"); //draw the polygon to represent the wall with the given coordinates and id
                        
                        //call the modular items drawing function
                        drawModularItems(modularItems, (parseFloat(x) + parseFloat(scale(1))), y, jsonVersions[version][wallIndex].LinearItems[i].LinearIndex, i);

                        //set the x coordinate of the <g> element for the next linear item
                        x = parseFloat(x) + scale(parseFloat(length));

                        //create a <g> element for the next linear item to be drawn in
                        gLi = gWall.append("g").attr("transform", "translate("+ x + "," + y + ")"); //bottom right coordinates of the linear item
                        break;
                    case "2 piece receiver": case "2piecereceiver":
                    case "box header receiver": case "boxheaderreceiver":
                    case "receiver": case "receiever":
                    case "box header": case "boxheader":
                    case "filler":
                    case "corner post": case "cornerpost": case "corner":
                    case "starter post": case "starterpost": case "starter":
                    case "electrical chase": case "electricalchase":
                    case "h channel": case "hchannel":
                        
                        topLeft = { "x": scale(parseFloat(0)), "y": (-1 * scale(parseFloat(startHeight)) + 1) }; //top left coordinates
                        topRight = { "x": scale(parseFloat(length)), "y": (-1 * scale(parseFloat(endHeight)) + 1) }; //top right coordinates
                        bottomRight = { "x": scale(parseFloat(length)), "y": scale(parseFloat(0)) }; //bottom right coordinates
                        bottomLeft = { "x": scale(parseFloat(0)), "y": scale(parseFloat(0)) }; //bottom left coordinates

                        points = [topLeft, topRight, bottomRight, bottomLeft]; //put all the coordinates together in an array

                        drawPolygon(points, "", title, gLi, "white", 1, "black", "$(this).css('fill', '#ccffff'); $('#<%= lblTitle.ClientID %>').text('"+jsonVersions[version][wallIndex].LinearItems[i].ItemType+"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "toggleDiv('"+id+"')"); //draw the polygon to represent the wall with the given coordinates and id

                        //set the x coordinate for the <g> element for the next linear item
                        x = parseFloat(x) + scale(parseFloat(length));

                        //create a <g> element for the next linear item to be drawn in
                        gLi = gWall.append("g").attr("transform", "translate("+ x + "," + y + ")"); //bottom right coordinates of the linear item

                        break;
                }
                if (jsonVersions[version][wallIndex].LinearItems[i].ItemType === "filler") { //if its a filler, add labels
                    var text = new Array(); //array of strings representing lines of text on the label (for fillers, there will only be 1 line)
                    text[0] = "F" + (parseInt(jsonVersions[version][wallIndex].LinearItems[i].LinearIndex) + 1);
                    
                    //move the labels up and to the left a bit (hot fix) to avoid being overlapped by the next linear item
                    points[0].y += scale(20); //move up
                    points[1].y += scale(20); //move up
                    points[1].x -= scale(8); //move left
                    points[2].x -= scale(8); //move left
                    addLabels(gLi, points, text); //draw labels
                    points[0].y -= scale(20); //move back down
                    points[1].y -= scale(20); //move back down
                    points[1].x += scale(8); //move back right
                    points[2].x += scale(8); //move back right

                    //the line below was used to try to bring all labels to the front. didn't work out as planned.
                //    arrLabels[i] = { "g": gLi, "frame": points, "text": text };
                }
                //the line below was used to try to bring all labels to the front. didn't work out as planned.
                //else if (jsonVersions[version][wallIndex].LinearItems[i].ItemType !== "Mod")
                //    arrLabels[i] = { "g": null, "frame": null, "text": null };
            }
        }

        /**
        This function draws all the modular items within a given linear item
        This function calls the drawDoor/WindowDetails functions to accurately draw the approparite door/window

        @param modularItems - the array containing modular items in a given linear item
        @param x - starting x coordinate
        @param y - starting y coordinate
        @param linearIndex - linear item index (to be passed on as an argument to the drawWindowDetails function)
        @param relativeLinearIndex - linear index relative to the particular wall drawn
        */
        function drawModularItems(modularItems, x, y, linearIndex, relativeLinearIndex) {

            // copy y into y2 to leave the original y value as is
            var y2 = y;
            //create a <g> element for door/window to be drawn into and position it appropriately
            gMod = gWall.append("g").attr("transform", "translate("+ x + "," + y + ")"); //bottom right coordinates of the linear item

            //for each modular item
            for (var i = 0; i < modularItems.length; i++) { 

                var id = "div_" + linearIndex + modularItems[i].ModuleIndex;// + jsonVersions[version][wallIndex].LinearItems[i].LinearIndex; //id to be given to the polygon
                var title = modularItems[i].ItemType; //title to be given to the polygon
                var length = modularItems[i].FLength; ; //length of the modular item
                var startHeight = modularItems[i].FStartHeight; //start height of the modular item
                var endHeight = modularItems[i].FEndHeight; //end height of the modular item
                var leftHeight = modularItems[i].LeftHeight; //left height of the modular item
                var rightHeight = modularItems[i].RightHeight; //right height of the modular item

                //determine what type of modular item it is
                switch(modularItems[i].ItemType.toLowerCase()) {
                    case "panel":
                    case "kneewall":
                        //calculate the rise to calculate the slope, based on the left and right heights
                        var rise = (leftHeight > rightHeight) ? (leftHeight - rightHeight) : (rightHeight - leftHeight);
                        //determine whether left or right height is higher
                        var height = (leftHeight > rightHeight) ? "start" : (leftHeight === rightHeight) ? "equal" : "end";
                        //calculate the sloper
                        var slope = rise / length;

                        //top and bottom frame values are used to draw frame on 3 sides of the panel;
                        //if the panel is the first modular item (at the bottom) there is no frame at the bottom
                        //if the panel is the last modular item (at the top) there is not frame at the top
                        //set the value for top frame; if the panel is at the top, set the top frame value to 0 else 0.5
                        var topFrame = (i === parseFloat(modularItems.length) - 1) ? 0 : 0.5;
                        //set the value for bottom frame; if the panel is at the bottom, set the bottom frame value to 0 else 0.5
                        var bottomFrame = (i === 0) ? 0 : 0.5;
                        //value of frame around the panel
                        var frame = 0.5;

                        //draw the frame around the panel
                        var topLeft = { "x": scale(0), "y": (-1 * scale(leftHeight)) }; //top left coordinates
                        var topRight = { "x": scale(length), "y": (-1 * scale(rightHeight)) }; //top right coordinates
                        var bottomRight = { "x": scale(length), "y": scale(0) }; //bottom right coordinates
                        var bottomLeft = { "x": scale(0), "y": scale(0) }; //bottom left coordinates

                        var points = [topLeft, topRight, bottomRight, bottomLeft]; //put all the coordinates together in an array

                        drawPolygon(points, "", title, gMod, "white", 1, "black", "$(this).css('fill', '#ccffff'); $('#<%= lblTitle.ClientID %>').text('"+ modularItems[i].WindowStyle + " " +modularItems[i].ItemType+"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "toggleDiv('"+id+"')"); //draw the polygon to represent the wall with the given coordinates and id

                        //append another <g> element to draw the panel inside the frame
                        var ggMod = gMod.append("g");

                        //draw the panel inside the frame
                        var topLeft = { "x": scale(parseFloat(0) + frame), "y": (-1 * scale(parseFloat(leftHeight) - topFrame)) }; //top left coordinates
                        var topRight = { "x": scale(parseFloat(length) - frame), "y": (-1 * scale(parseFloat(rightHeight) - topFrame)) }; //top right coordinates
                        var bottomRight = { "x": scale(parseFloat(length) - frame), "y": scale(parseFloat(0) - bottomFrame) }; //bottom right coordinates
                        var bottomLeft = { "x": scale(parseFloat(0) + frame), "y": scale(parseFloat(0) - bottomFrame) }; //bottom left coordinates

                        var points = [topLeft, topRight, bottomRight, bottomLeft]; //put all the coordinates together in an array

                        drawPolygon(points, "", title, ggMod, "white", 1, "black", "$(this).css('fill', '#ccffff'); $('#<%= lblTitle.ClientID %>').text('"+ modularItems[i].WindowStyle + " " +modularItems[i].ItemType+"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "toggleDiv('"+id+"')"); //draw the polygon to represent the wall with the given coordinates and id

                        //if the panel is at the top, draw a line in between the panel and the modular item under it
                        if (i < (parseFloat(modularItems.length) - 1)) {

                            var pt1 = { "x": scale(parseFloat(0)), "y": (-1 * scale(parseFloat(endHeight))) }; //line left coordinates
                            var pt2 = { "x": scale(parseFloat(length)), "y": (-1 * scale(parseFloat(endHeight))) }; //line left coordinates

                            drawLine(pt1, pt2, gMod);
                        }

                        break;
                    case "transom":
                    case "window":
                        
                        var title = modularItems[i].ItemType;
                        var length = modularItems[i].FLength; ; //length of the modular item
                        var startHeight = modularItems[i].FStartHeight; //start height of the modular item
                        var endHeight = modularItems[i].FEndHeight; //end height of the modular item
                        var leftHeight = modularItems[i].LeftHeight; //left height of the modular item
                        var rightHeight = modularItems[i].RightHeight; //right height of the modular item
                
                        var outsideTopLeft = { "x": scale(parseFloat(0)), "y": (-1 * scale(parseFloat(leftHeight))) }; //top left coordinates
                        var outsideTopRight = { "x": scale(parseFloat(length)), "y": (-1 * scale(parseFloat(rightHeight))) }; //top right coordinates
                        var outsideBottomRight = { "x": scale(parseFloat(length)), "y": scale(parseFloat(0)) }; //bottom right coordinates
                        var outsideBottomLeft = { "x": scale(parseFloat(0)), "y": scale(parseFloat(0)) }; //bottom left coordinates

                        var outsidePoints = [outsideTopLeft, outsideTopRight, outsideBottomRight, outsideBottomLeft]; //put all the coordinates together in an array

                        //draw window frame
                        drawPolygon(outsidePoints, "", title, gMod, "white", 1, "black", "$(this).css('fill', '#ccffff'); $('#<%= lblTitle.ClientID %>').text('"+ modularItems[i].WindowStyle + " " +modularItems[i].ItemType+"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "toggleDiv('"+id+"')"); //draw the polygon to represent the wall with the given coordinates and id
                        //drawPolygon(outsidePoints, "", title, gMod);//, "white", 1, "black");
                        
                        //append another <g> element to draw the window inside the frame
                        gMod = gMod.append("g");

                        var insideTopLeft = { "x": scale(parseFloat(0) + 1), "y": (-1 * scale(parseFloat(leftHeight) - 1)) }; //top left coordinates
                        var insideTopRight = { "x": scale(parseFloat(length) - 1), "y": (-1 * scale(parseFloat(rightHeight) - 1)) }; //top right coordinates
                        var insideBottomRight = { "x": scale(parseFloat(length) - 1), "y": scale(parseFloat(0) - 1) }; //bottom right coordinates
                        var insideBottomLeft = { "x": scale(parseFloat(0) + 1), "y": scale(parseFloat(0) - 1) }; //bottom left coordinates

                        var insidePoints = [insideTopLeft, insideTopRight, insideBottomRight, insideBottomLeft]; //put all the coordinates together in an array

                        //call the window detail drawing function to draw window details inside the frame
                        drawWindowDetails(modularItems[i], insidePoints, modularItems.length, linearIndex, relativeLinearIndex, id);

                        //if the window is at the bottom, i.e. kneewall, draw a line between it and the modular item on top of it
                        if (i == 0) {

                            var pt1 = { "x": scale(parseFloat(0)), "y": (insideTopLeft.y - scale(1)) }; //line left coordinates
                            var pt2 = { "x": scale(parseFloat(length)), "y": (insideTopRight.y - scale(1)) }; //line left coordinates

                            drawLine(pt1, pt2, gMod);
                        }
                        //if the window is at the top, i.e. transom, draw a line between it and the modular item below it
                        else if (i == parseFloat(modularItems.length) - 1) {

                            var pt1 = { "x": scale(parseFloat(0)), "y": (insideBottomLeft.y + scale(1)) }; //line left coordinates
                            var pt2 = { "x": scale(parseFloat(length)), "y": (insideBottomRight.y + scale(1)) }; //line left coordinates

                            drawLine(pt1, pt2, gMod);
                        }
                        break;
                    case "door":

                        var title = modularItems[i].ItemType;
                        var length = modularItems[i].FLength; ; //length of the modular item
                        var leftHeight = modularItems[i].FStartHeight; //start height of the modular item
                        var rightHeight = modularItems[i].FEndHeight; //end height of the modular item

                        var insideTopLeft = { "x": scale(parseFloat(0) + 1), "y": (-1 * scale(parseFloat(leftHeight) - 1)) }; //top left coordinates
                        var insideTopRight = { "x": scale(parseFloat(length) - 1), "y": (-1 * scale(parseFloat(rightHeight) - 1)) }; //top right coordinates
                        var insideBottomRight = { "x": scale(parseFloat(length) - 1), "y": scale(parseFloat(0)) }; //bottom right coordinates
                        var insideBottomLeft = { "x": scale(parseFloat(0) + 1), "y": scale(parseFloat(0)) }; //bottom left coordinates

                        var insidePoints = [insideTopLeft, insideTopRight, insideBottomRight, insideBottomLeft]; //put all the coordinates together in an array

                        //draw door details inside the frame
                        drawDoorDetails(modularItems[i], insidePoints, modularItems.length, linearIndex, relativeLinearIndex, id);

                        //if (i == 0) {

                        //    var pt1 = { "x": scale(parseFloat(0)), "y": (insideTopLeft.y - scale(1)) }; //line left coordinates
                        //    var pt2 = { "x": scale(parseFloat(length)), "y": (insideTopRight.y - scale(1)) }; //line left coordinates

                        //    //drawLine(pt1, pt2, gMod);
                        //}
                        if (i == parseFloat(modularItems.length) - 1) {

                            var pt1 = { "x": scale(parseFloat(0)), "y": (insideBottomLeft.y + scale(1)) }; //line left coordinates
                            var pt2 = { "x": scale(parseFloat(length)), "y": (insideBottomRight.y + scale(1)) }; //line left coordinates

                            drawLine(pt1, pt2, gMod);
                        }

                        break;
                    case "box header": case "boxheader":
                        break;
                    case "receiver": case "receiever":
                        break;
                }

                drawPolygon(insidePoints, "", title, gMod); //draw the polygon to represent the modular item with the given coordinates and id

                //reset y2 for the next modular item
                y2 = parseFloat(y2) - scale(parseFloat(endHeight));

                //create another <g> element for the next modular item and position it appropriately
                gMod = gWall.append("g").attr("transform", "translate("+ x + "," + y2 + ")");
            }
        }

        /**
        This function draws the details of a given window
        This function also calls the add labels function to add labels on windows
        @param window - the window object
        @param frame - the window frame coordinates
        @param transomIndex - modular index of the transom
        @param linearIndex - index of the linear item which contains this window
        @param relativeLinearIndex - index of the linear item relative to the wall drawn
        @param id - id to be used for the onclick event to display the appropriate update form 
        */
        function drawWindowDetails(window, frame, transomIndex, linearIndex, relativeLinearIndex, id) {

            //declarations
            var pt1, pt2, topLeft, topRight, bottomLeft, bottomRight, leftSlider, rightSlider;

            //draw the outside window frame
            drawPolygon(frame, "", "", gMod, "white", 1, "black", "$(this).css('fill', '#ccffff'); $('#<%= lblTitle.ClientID %>').text('"+ window.WindowStyle + " " +window.ItemType+"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "toggleDiv('"+id+"')"); //draw the polygon to represent the wall with the given coordinates and id
            //drawPolygon(frame, "", "", gMod); //draw the polygon to represent the wall with the given coordinates and id
            //append another <g> element on top to draw window details inside
            gWindow = gMod.append("g").attr("transform", "translate("+ frame[3].x + "," + frame[3].y + ")");

            //determine window style
            switch(window.WindowStyle.toLowerCase()) {
                case "double slider": case "doubleslider": //glass model 300
                case "single slider": case "singleslider": //glass model 400
                case "horizontal roller xx": case "horizontalrollerxx": //glass model 300
                case "horizontal roller": case "horizontalroller": case "horizontal 2 track": case "horizontal2track": case "horizontal two track": case "horizontaltwotrack": case "h2t": //H2T model 200

                    pt1 = { "x": scale((window.Width / 2) - 1), "y": scale(0) }; //line left coordinates
                    pt2 = { "x": scale((window.Width / 2) - 1), "y": (-1 * scale(window.LeftHeight - 2)) }; //line left coordinates

                    //draw line to seperate the left and right slider
                    drawLine(pt1, pt2, gWindow, 2);

                    topLeft = { "x": (frame[0].x + scale(1)), "y": (frame[0].y + scale(3)) }; //top left coordinates
                    topRight = { "x": scale((window.Width / 2) - 3), "y": (frame[1].y + scale(3)) }; //top right coordinates
                    bottomRight = { "x": scale((window.Width / 2) - 3), "y": (frame[2].y - scale(1)) }; //bottom right coordinates
                    bottomLeft = { "x": (frame[3].x + scale(1)), "y": (frame[3].y - scale(1)) }; //bottom left coordinates

                    leftSlider = [topLeft, topRight, bottomRight, bottomLeft]; //put all the coordinates together in an array

                    //draw left slider
                    drawPolygon(leftSlider, "", "", gWindow, "white", 1, "black", "$(this).css('fill', '#ccffff'); $('#<%= lblTitle.ClientID %>').text('"+ window.WindowStyle + " " +window.ItemType+" Left Slider'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "toggleDiv('"+id+"')"); //draw the polygon to represent the wall with the given coordinates and id

                    //if spreaderbar, draw a line representing it on the left slider
                    if (window.SpreaderBar !== 0) {
                        gVent = gWindow.append("g");
                        pt1 = { "x": topLeft.x, "y": -scale(window.SpreaderBar) }; //lne left coordinates
                        pt2 = { "x": topRight.x, "y": -scale(window.SpreaderBar) }; //line left coordinates
                        drawLine(pt1, pt2, gVent, 2);
                    }

                    //append another <g> element to draw the right slider
                    gWindow = gMod.append("g").attr("transform", "translate("+ frame[3].x + "," + frame[3].y + ")");

                    topLeft = { "x": scale((window.Width / 2) - 0.5), "y": (frame[0].y + scale(3)) }; //top left coordinates
                    topRight = { "x": scale(window.Width - 4), "y": (frame[1].y + scale(3)) }; //top right coordinates
                    bottomRight = { "x": scale(window.Width - 4), "y": (frame[2].y - scale(1)) }; //bottom right coordinates
                    bottomLeft = { "x": scale((window.Width / 2) - 0.5), "y": (frame[3].y - scale(1)) }; //bottom left coordinates

                    rightSlider = [topLeft, topRight, bottomRight, bottomLeft]; //put all the coordinates together in an array

                    //draw right slider
                    drawPolygon(rightSlider, "", "", gWindow, "white", 1, "black", "$(this).css('fill', '#ccffff'); $('#<%= lblTitle.ClientID %>').text('"+ window.WindowStyle + " " +window.ItemType+" Right Slider'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "toggleDiv('"+id+"')"); //draw the polygon to represent the wall with the given coordinates and id

                    //if spreaderbar, draw a line representing it on the right slider
                    if (window.SpreaderBar !== 0) {
                        gVent = gWindow.append("g");
                        pt1 = { "x": topLeft.x, "y": -scale(window.SpreaderBar) }; //line left coordinates
                        pt2 = { "x": topRight.x, "y": -scale(window.SpreaderBar) }; //line left coordinates
                        drawLine(pt1, pt2, gVent, 2);
                    }
                        
                    //draw glass lines function not yet functional
                    //drawGlassLines(leftSlider);
                    //drawGlassLines(rightSlider);

                    break;
                case "vertical 4 track": case "vertical4track": case "verticalfourtrack": case "vertical four track": case "v4t": //V4T
                    var ventHeight = 0;
                    
                    //append a <g> element to draw vents in
                    gVent = gWindow.append("g");

                    //for each vent in the v4t window
                    for (var i = 0; i < window.NumVents; i++) {
                        ventHeight = scale(window.VentHeights[i] / 4); // divided by 4 because the vent heights are messed up; once vent heights in the db are fixed, simply delete "/ 4" from this line
                        
                        //this is used to overlap vents to create the depth in 4 vents
                        var yBottom = (i === (window.NumVents - 1)) ? -(ventHeight - scale(1)) : -(ventHeight - scale(0.5));

                        topLeft = { "x": scale(1), "y": scale(-1) }; //top left coordinates
                        topRight = { "x": scale(window.Width - 3), "y": scale(-1) }; //top right coordinates
                        bottomRight = { "x": scale(window.Width - 3), "y": yBottom }; //bottom right coordinates
                        bottomLeft = { "x": (scale(1)), "y": yBottom }; //bottom left coordinates

                        var slider = [topLeft, topRight, bottomRight, bottomLeft]; //put all the coordinates together in an array

                        //draw the vent
                        drawPolygon(slider, "", "", gVent, "white", 1, "black", "$(this).css('fill', '#ccffff'); $('#<%= lblTitle.ClientID %>').text('"+ window.WindowStyle + " " +window.ItemType+" Vent "+ (parseFloat(i) + parseFloat(1)) +"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "toggleDiv('"+id+"')"); //draw the polygon to represent the wall with the given coordinates and id
                        //drawPolygon(slider, "", "", gVent); //draw the polygon to represent the wall with the given coordinates and id

                        //if spreaderbar, draw a line representing it in the vent
                        if (window.SpreaderBar !== 0) {

                            var yTop = (i === (window.NumVents - 1)) ? -(ventHeight - scale(1)) : -(ventHeight - scale(0.5));

                            pt1 = { "x": scale(window.SpreaderBar), "y": scale(-1) }; //line left coordinates
                            pt2 = { "x": scale(window.SpreaderBar), "y": yTop }; //line left coordinates
                            drawLine(pt1, pt2, gVent, 2);
                        }

                        //draw glass lines function not yet functional
                        //drawGlassLines(slider);

                        //append another <g> element to draw the next vent in and position is appropriately
                        gVent = gVent.append("g").attr("transform", "translate("+ 0 + "," + (parseFloat(-ventHeight)) + ")");

                    }

                    //draw a line in between each vent seperating each vent
                    ventHeight = 0; //reset vent height
                    for (var i = 0; i < window.NumVents - 1; i++) {
                        ventHeight += scale(window.VentHeights[i] / 4); // divided by 4 because the vent heights are messed up; once the vent height value in the database is fixed, simply delete "/ 4"
                        //append <g> element to draw line on
                        gVent = gWindow.append("g").attr("transform", "translate("+ 0 + "," + -ventHeight + ")");
                        pt1 = { "x": scale(0), "y": scale(0) }; //line left coordinates
                        pt2 = { "x": scale(parseFloat(window.Width) - 2), "y": scale(0) }; //line left coordinates
                        drawLine(pt1, pt2, gVent, 1);

                    }
                    
                    break;
                case "Solid Wall": 
                    break;
            }        

            //if there is a screen draw it
            if (window.ScreenType.toLowerCase() != "no screen" && window.ScreenType != "noscreen" && window.ScreenType != "" && typeof window.ScreenType !== 'undefined') 
                drawScreen(gWindow, frame, window.ScreenType, id); //draw screen lines

            //if its not a transom or a kneewall, add label
            if (window.ModuleIndex != 0 && window.ModuleIndex != (transomIndex - 1)) {
                var text, width, height;
                //get the width of the window; if width contains a decimal value, convert it into a fraction string
                width = ((window.FLength + "").indexOf(".") != -1) ? convertDecimalToFractions(window.FLength + "") : window.FLength;
                //get the height of the window; if height contains a decinal value, convert it into a fraction string
                height = ((window.FStartHeight + "").indexOf(".") != -1) ? convertDecimalToFractions(window.FStartHeight + "") : window.FStartHeight;
                //set the label text
                text = new Array(); //array of strings, each element represents a line of text on the label
                text[0] = 'W' + (parseInt(linearIndex) + 1); 
                text[1] = width + "\" x " + height + "\" " + window.WindowStyle;

                //call the addLabels function to add the labels on the windows
                addLabels(gWindow, frame, text);

                //the function below was used to bring the labels to the front, but didn't work
                //arrLabels[relativeLinearIndex] = { "g": gLi, "frame": frame, "text": text };
            }
        }

        /**
        This function draws the details of a given door
        Note: this function needs to call the add labels function to add labels on the doors
            See the end of drawWindowDetails function for example of how to do that
        @param door - the door object
        @param frame - the door frame coordinates
        @param transomIndex - modular index of the transom
        @param linearIndex - index of the linear item which contains this door
        @param relativeLinearIndex - index of the linear item relative to the wall drawn
        @param id - id to be used for the onclick event to display the appropriate update form 
        */
        function drawDoorDetails(door, frame, transomIndex, linearIndex, relativeLinearIndex, id) {
            
            //if its a model 400 door, call the appropriate function, this function does not draw model 400 doors
            if (jsonVersions[version][wallIndex].ModelType.substring().toLowerCase() === "m400") { //if model 400
                drawModel400DoorDetails(door, frame, transomIndex, linearIndex, relativeLinearIndex, id);
                return; //exit out of this function so the rest of this function doesn't get executed
            }

            //declarations
            var pt1, pt2, topLeft, topRight, bottomLeft, bottomRight, leftSlider, rightSlider;

            var topLeft = { "x": parseFloat(frame[0].x) - scale(parseFloat(1)), "y": parseFloat(frame[0].y) - scale(parseFloat(1)) }; //top left coordinates
            var topRight = { "x": parseFloat(frame[1].x) + scale(parseFloat(1)), "y": parseFloat(frame[1].y) - scale(parseFloat(1)) }; //top right coordinates
            var bottomRight = { "x": parseFloat(frame[2].x) + scale(parseFloat(1)), "y": parseFloat(frame[2].y) }; //bottom right coordinates
            var bottomLeft = { "x": parseFloat(frame[3].x) - scale(parseFloat(1)), "y": parseFloat(frame[3].y) }; //bottom left coordinates
            
            var doorDoorFrame = [topLeft, topRight, bottomRight, bottomLeft]; //put all the coordinates together in an array

            //draw outside door frame
            drawPolygon(doorDoorFrame, "", "", gMod, "white", 1, "black", "$(this).css('fill', '#ccffff'); $('#<%= lblTitle.ClientID %>').text('"+ door.DoorStyle + " " +door.DoorType+" "+ door.ItemType +"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "toggleDiv('"+id+"')"); //draw the polygon to represent the wall with the given coordinates and id
            //draw inside door frame
            drawPolygon(frame, "", "", gMod, "white", 1, "black", "$(this).css('fill', '#ccffff'); $('#<%= lblTitle.ClientID %>').text('"+ door.DoorStyle + " " +door.DoorType+" "+ door.ItemType +"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "toggleDiv('"+id+"')"); //draw the polygon to represent the wall with the given coordinates and id
            //append a <g> element to draw door details in and position it appropriately
            gDoor = gMod.append("g").attr("transform", "translate("+ frame[3].x + "," + frame[3].y + ")");

            //determine the type of door
            switch(door.DoorType.toLowerCase()) {
                
                case "cabana": case "cabana door": case "cabanadoor":
                    var topLeft = { "x": parseFloat(frame[0].x) + scale(parseFloat(3.5)), "y": parseFloat(frame[0].y) + scale(parseFloat(2.5)) }; //top left coordinates
                    var topRight = { "x": parseFloat(frame[1].x) - scale(parseFloat(3.5)), "y": parseFloat(frame[1].y) + scale(parseFloat(2.5)) }; //top right coordinates
                    var bottomRight = { "x": parseFloat(frame[2].x) - scale(parseFloat(3.5)), "y": parseFloat(frame[2].y) - scale(parseFloat(door.Kickplate) + parseFloat(0.5)) }; //bottom right coordinates
                    var bottomLeft = { "x": parseFloat(frame[3].x) + scale(parseFloat(3.5)), "y": parseFloat(frame[3].y) - scale(parseFloat(door.Kickplate) + parseFloat(0.5)) }; //bottom left coordinates

                    var doorWindowFrame = [topLeft, topRight, bottomRight, bottomLeft]; //put all the coordinates together in an array

                    //append a <g> element to draw details in
                    gMod = gMod.append("g");
                    //draw door window frame
                    drawPolygon(doorWindowFrame, "", "", gMod, "white", 1, "black", "$(this).css('fill', '#ccffff'); $('#<%= lblTitle.ClientID %>').text('"+ door.DoorStyle + " " +door.DoorType+" "+ door.ItemType +"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "toggleDiv('"+id+"')"); //draw the polygon to represent the wall with the given coordinates and id

                    //doorknob radius
                    var r = scale(1.25);
                    //doorknob centre x coordinate
                    var cx = (door.Hinge === "R") ? parseFloat(frame[0].x) + scale(parseFloat(1.5)) : parseFloat(frame[1].x) - scale(parseFloat(1.5));
                    //doorknob centre y coordinate
                    var cy = -scale(door.FEndHeight / 2);

                    //append a <g> element to draw doorknob in
                    var ggMod = gMod.append("g");
                    
                    //draw door knob
                    drawCircle(ggMod, r, cx, cy, "", "yellow" /*hard coded for now*/, 1, "black", "$(this).css('fill', '#ccffff'); $('#<%= lblTitle.ClientID %>').text('"+ door.HardwareType + " Hardware'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'yellow'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "toggleDiv('"+id+"')"); //draw the polygon to represent the wall with the given coordinates and id

                    //////////////// DOOR WINDOW DETAILS

                    //call the door window details function
                    drawDoorWindowDetails(gMod, doorWindowFrame, door);

                    //////////////END DOOR WINDOW DETAILS
                    
                    //if there is a screen on the door, draw it
                    if (door.ScreenType.toLowerCase() != "no screen" && door.ScreenType.toLowerCase() != "noscreen" && door.ScreenType.toLowerCase() != "" && typeof door.ScreenType !== 'undefined') {
                     
                        topLeft = { "x": topLeft.x + parseFloat(scale(1)) , "y": topLeft.y - parseFloat(scale(1)) }; //top left coordinates
                        topRight = { "x": topRight.x + parseFloat(scale(1)) , "y": topRight.y - parseFloat(scale(1)) }; //top right coordinates
                        bottomRight = { "x": bottomLeft.x + parseFloat(scale(1)) , "y": bottomLeft.y }; //bottom right coordinates
                        bottomLeft = { "x": bottomRight.x + parseFloat(scale(1)) , "y": bottomRight.y }; //bottom left coordinates

                        doorWindowFrame = [topLeft, topRight, bottomRight, bottomLeft]; //put all the coordinates together in an array

                        drawScreen(gMod, doorWindowFrame, door.ScreenType, id, scale(door.Kickplate));
                    }
                    break;

                    //french doors are the same as cabana doors, except x2
                case "french": case "frenchdoor": case "french door":
                    //////////////LEFT DOOR
                    var topLeft = { "x": parseFloat(frame[0].x), "y": parseFloat(frame[0].y) }; //top left coordinates
                    var topRight = { "x": parseFloat(frame[1].x) - scale(parseFloat(door.FLength/2)) + scale(parseFloat(0.25)), "y": parseFloat(frame[1].y) }; //top right coordinates
                    var bottomRight = { "x": parseFloat(frame[2].x) - scale(parseFloat(door.FLength/2)) + scale(parseFloat(0.25)), "y": parseFloat(frame[2].y) }; //bottom right coordinates
                    var bottomLeft = { "x": parseFloat(frame[3].x), "y": parseFloat(frame[3].y) }; //bottom left coordinates

                    var doorWindowFrame = [topLeft, topRight, bottomRight, bottomLeft]; //put all the coordinates together in an array

                    var gDoorFrame = gMod.append("g");
                    drawPolygon(doorWindowFrame, "", "", gDoorFrame, "white", 1, "black", "$(this).css('fill', '#ccffff'); $('#<%= lblTitle.ClientID %>').text('"+ door.DoorStyle + " " +door.DoorType+" "+ door.ItemType +"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "toggleDiv('"+id+"')"); //draw the polygon to represent the wall with the given coordinates and id
                    
                    ///////////////END LEFT DOOR

                    /////////////////LEFT DOOR WINDOW

                    var topLeft1 = { "x": parseFloat(frame[0].x) + scale(parseFloat(3.5)), "y": parseFloat(frame[0].y) + scale(parseFloat(2.5)) }; //top left coordinates
                    var topRight1 = { "x": parseFloat(frame[1].x) - scale(parseFloat(3.5)) - scale(parseFloat(door.FLength/2)) - scale(parseFloat(0.25)), "y": parseFloat(frame[1].y) + scale(parseFloat(2.5)) }; //top right coordinates
                    var bottomRight1 = { "x": parseFloat(frame[2].x) - scale(parseFloat(3.5)) - scale(parseFloat(door.FLength/2)) - scale(parseFloat(0.25)), "y": parseFloat(frame[2].y) - scale(parseFloat(door.Kickplate) + parseFloat(0.5)) }; //bottom right coordinates
                    var bottomLeft1 = { "x": parseFloat(frame[3].x) + scale(parseFloat(3.5)), "y": parseFloat(frame[3].y) - scale(parseFloat(door.Kickplate) + parseFloat(0.5)) }; //bottom left coordinates

                    var doorWindowFrame1 = [topLeft1, topRight1, bottomRight1, bottomLeft1]; //put all the coordinates together in an array

                    var gDoorWindow = gMod.append("g");
                    drawPolygon(doorWindowFrame1, "", "", gDoorWindow, "white", 1, "black", "$(this).css('fill', '#ccffff'); $('#<%= lblTitle.ClientID %>').text('"+ door.DoorStyle + " " +door.DoorType+" "+ door.ItemType +"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "toggleDiv('"+id+"')"); //draw the polygon to represent the wall with the given coordinates and id

                    ///////////END LEFT DOOR WINDOW

                    //////////////LEFT DOORKNOB

                    var r = scale(1.25);
                    var cx = parseFloat(frame[1].x) - scale(parseFloat(1.6)) - scale(parseFloat(door.FLength/2)) - scale(parseFloat(0.25));
                    var cy = -scale(door.FEndHeight / 2);

                    var gDoorknob = gMod.append("g");
                    
                    drawCircle(gDoorknob, r, cx, cy, "", "yellow" /*hard coded for now*/, 1, "black", "$(this).css('fill', '#ccffff'); $('#<%= lblTitle.ClientID %>').text('"+ door.HardwareType + " Hardware'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'yellow'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "toggleDiv('"+id+"')"); //draw the polygon to represent the wall with the given coordinates and id

                    /////////////END LEFT DOORKNOB

                    //////////////// DOOR WINDOW DETAILS

                    drawDoorWindowDetails(gDoorWindow, doorWindowFrame1, door);

                    //////////////END DOOR WINDOW DETAILS
                    
                    ////////////////////LEFT DOOR SCREEN

                    if (door.ScreenType.toLowerCase() != "no screen" && door.ScreenType.toLowerCase() != "noscreen" && door.ScreenType.toLowerCase() != "" && typeof door.ScreenType !== 'undefined') {
                     
                        topLeft1 = { "x": topLeft1.x + parseFloat(scale(1)) , "y": topLeft1.y - parseFloat(scale(1)) }; //top left coordinates
                        topRight1 = { "x": topRight1.x + parseFloat(scale(1)) , "y": topRight1.y - parseFloat(scale(1)) }; //top right coordinates
                        bottomRight1 = { "x": bottomLeft1.x + parseFloat(scale(1)) , "y": bottomLeft1.y }; //bottom right coordinates
                        bottomLeft1 = { "x": bottomRight1.x + parseFloat(scale(1)) , "y": bottomRight1.y }; //bottom left coordinates

                        doorWindowFrame1 = [topLeft1, topRight1, bottomRight1, bottomLeft1]; //put all the coordinates together in an array

                        drawScreen(gMod, doorWindowFrame1, door.ScreenType, id, scale(door.Kickplate));
                    }

                    //////////////////END LEFT DOOR SCREEN

                    //////////////RIGHT DOOR
                    var topLeft = { "x": parseFloat(frame[0].x) + scale(parseFloat(door.FLength/2)) - scale(parseFloat(0.5)), "y": parseFloat(frame[0].y) }; //top left coordinates
                    var topRight = { "x": parseFloat(frame[1].x), "y": parseFloat(frame[1].y) }; //top right coordinates
                    var bottomRight = { "x": parseFloat(frame[2].x), "y": parseFloat(frame[2].y) }; //bottom right coordinates
                    var bottomLeft = { "x": parseFloat(frame[3].x) + scale(parseFloat(door.FLength/2)) - scale(parseFloat(0.5)), "y": parseFloat(frame[3].y) }; //bottom left coordinates

                    var doorWindowFrame = [topLeft, topRight, bottomRight, bottomLeft]; //put all the coordinates together in an array

                    gggMod = gDoorFrame.append("g");
                    drawPolygon(doorWindowFrame, "", "", gggMod, "white", 1, "black", "$(this).css('fill', '#ccffff'); $('#<%= lblTitle.ClientID %>').text('"+ door.DoorStyle + " " +door.DoorType+" "+ door.ItemType +"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "toggleDiv('"+id+"')"); //draw the polygon to represent the wall with the given coordinates and id
                    
                    ///////////////END RIGHT DOOR
                    
                    /////////////////RIGHT DOOR WINDOW

                    var topLeft1 = { "x": parseFloat(frame[0].x) + scale(parseFloat(3.5)) + scale(parseFloat(door.FLength/2)), "y": parseFloat(frame[0].y) + scale(parseFloat(2.5)) }; //top left coordinates
                    var topRight1 = { "x": parseFloat(frame[1].x) - scale(parseFloat(3.5)) - scale(parseFloat(0.25)), "y": parseFloat(frame[1].y) + scale(parseFloat(2.5)) }; //top right coordinates
                    var bottomRight1 = { "x": parseFloat(frame[2].x) - scale(parseFloat(3.5)) - scale(parseFloat(0.25)), "y": parseFloat(frame[2].y) - scale(parseFloat(door.Kickplate) + parseFloat(0.5)) }; //bottom right coordinates
                    var bottomLeft1 = { "x": parseFloat(frame[3].x) + scale(parseFloat(3.5)) + scale(parseFloat(door.FLength/2)), "y": parseFloat(frame[3].y) - scale(parseFloat(door.Kickplate) + parseFloat(0.5)) }; //bottom left coordinates

                    var doorWindowFrame1 = [topLeft1, topRight1, bottomRight1, bottomLeft1]; //put all the coordinates together in an array

                    ggMod = gDoorWindow.append("g");
                    drawPolygon(doorWindowFrame1, "", "", ggMod, "white", 1, "black", "$(this).css('fill', '#ccffff'); $('#<%= lblTitle.ClientID%>').text('"+ door.DoorStyle + " " +door.DoorType+" "+ door.ItemType +"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "toggleDiv('"+id+"')"); //draw the polygon to represent the wall with the given coordinates and id

                    ///////////END RIGHT DOOR WINDOW

                    /////////////RIGHT DOORKNOB

                    var r = scale(1.25);
                    var cx = parseFloat(frame[0].x) + scale(parseFloat(1.75)) + scale(parseFloat(door.FLength/2)) - scale(parseFloat(0.25));
                    var cy = -scale(door.FEndHeight / 2);

                    drawCircle(gDoorknob, r, cx, cy, "", "yellow" /*hard coded for now*/, 1, "black", "$(this).css('fill', '#ccffff'); $('#<%= lblTitle.ClientID %>').text('"+ door.HardwareType + " Hardware'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'yellow'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "toggleDiv('"+id+"')"); //draw the polygon to represent the wall with the given coordinates and id
                
                    ////////////END RIGHT DOORKNOB

                    //////////////// DOOR WINDOW DETAILS

                    drawDoorWindowDetails(ggMod, doorWindowFrame1, door);

                    //////////////END DOOR WINDOW DETAILS
                    
                    /////////////////RIGHT DOOR SCREEN

                    if (door.ScreenType.toLowerCase() != "no screen" && door.ScreenType.toLowerCase() != "noscreen" && door.ScreenType.toLowerCase() != "" && typeof door.ScreenType !== 'undefined') {
                     
                        topLeft1 = { "x": topLeft1.x + parseFloat(scale(1)) , "y": topLeft1.y - parseFloat(scale(1)) }; //top left coordinates
                        topRight1 = { "x": topRight1.x + parseFloat(scale(1)) , "y": topRight1.y - parseFloat(scale(1)) }; //top right coordinates
                        bottomRight1 = { "x": bottomLeft1.x + parseFloat(scale(1)) , "y": bottomLeft1.y }; //bottom right coordinates
                        bottomLeft1 = { "x": bottomRight1.x + parseFloat(scale(1)) , "y": bottomRight1.y }; //bottom left coordinates

                        doorWindowFrame1 = [topLeft1, topRight1, bottomRight1, bottomLeft1]; //put all the coordinates together in an array

                        drawScreen(gMod, doorWindowFrame1, door.ScreenType, id, scale(door.Kickplate));
                    }

                    /////////////END RIGHT DOOR SCREEN

                    break;
            }
        }

        /**
        This function draws the details of a given door that is of model 400
        @param door - the door object
        @param frame - the door frame coordinates
        @param transomIndex - modular index of the transom
        @param linearIndex - index of the linear item which contains this door
        @param relativeLinearIndex - index of the linear item relative to the wall drawn
        @param id - id to be used for the onclick event to display the appropriate update form 
        */
        function drawModel400DoorDetails(door, frame, transomIndex, linearIndex, relativeLinearIndex, id) {
            
            //declarations
            var pt1, pt2, topLeft, topRight, bottomLeft, bottomRight, leftSlider, rightSlider;

            var topLeft = { "x": parseFloat(frame[0].x) - scale(parseFloat(1)), "y": parseFloat(frame[0].y) - scale(parseFloat(1)) }; //top left coordinates
            var topRight = { "x": parseFloat(frame[1].x) + scale(parseFloat(1)), "y": parseFloat(frame[1].y) - scale(parseFloat(1)) }; //top right coordinates
            var bottomRight = { "x": parseFloat(frame[2].x) + scale(parseFloat(1)), "y": parseFloat(frame[2].y) }; //bottom right coordinates
            var bottomLeft = { "x": parseFloat(frame[3].x) - scale(parseFloat(1)), "y": parseFloat(frame[3].y) }; //bottom left coordinates
            
            var doorDoorFrame = [topLeft, topRight, bottomRight, bottomLeft]; //put all the coordinates together in an array

            //draw door frame
            drawPolygon(doorDoorFrame, "", "", gMod, "white", 1, "black", "$(this).css('fill', '#ccffff'); $('#<%= lblTitle.ClientID %>').text('"+ door.DoorStyle + " " +door.DoorType+" "+ door.ItemType +"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "toggleDiv('"+id+"')"); //draw the polygon to represent the wall with the given coordinates and id
            //draw door inside frame
            drawPolygon(frame, "", "", gMod, "white", 1, "black", "$(this).css('fill', '#ccffff'); $('#<%= lblTitle.ClientID %>').text('"+ door.DoorStyle + " " +door.DoorType+" "+ door.ItemType +"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "toggleDiv('"+id+"')"); //draw the polygon to represent the wall with the given coordinates and id
            
            //append a <g> element to draw door details in
            gDoor = gMod.append("g").attr("transform", "translate("+ frame[3].x + "," + frame[3].y + ")");

            //determine the type of door
            switch(door.DoorType.toLowerCase()) {
                
                case "cabana": case "cabana door": case "cabanadoor":
                    
                    //determine the style of door
                    switch(door.DoorStyle.toLowerCase()) {

                        case "half lite": case "half lite venting": case "half lite with mini blinds":
                        case "halflite": case "halfliteventing": case "halflitewithminiblinds":

                            var topLeft = { "x": parseFloat(frame[0].x) + scale(parseFloat(3.5)), "y": parseFloat(frame[0].y) + scale(parseFloat(2.5)) }; //top left coordinates
                            var topRight = { "x": parseFloat(frame[1].x) - scale(parseFloat(3.5)), "y": parseFloat(frame[1].y) + scale(parseFloat(2.5)) }; //top right coordinates
                            var bottomRight = { "x": parseFloat(frame[2].x) - scale(parseFloat(3.5)), "y": parseFloat(frame[2].y) - scale(parseFloat(door.Height / 2.3) + parseFloat(0.5)) }; //bottom right coordinates
                            var bottomLeft = { "x": parseFloat(frame[3].x) + scale(parseFloat(3.5)), "y": parseFloat(frame[3].y) - scale(parseFloat(door.Height / 2.3) + parseFloat(0.5)) }; //bottom left coordinates

                            var doorWindowFrame = [topLeft, topRight, bottomRight, bottomLeft]; //put all the coordinates together in an array

                            //append <g> element to draw door window in
                            gMod = gMod.append("g");
                            //draw door window frame
                            drawPolygon(doorWindowFrame, "", "", gMod, "white", 1, "black", "$(this).css('fill', '#ccffff'); $('#<%= lblTitle.ClientID %>').text('"+ door.DoorStyle + " " +door.DoorType+" "+ door.ItemType +"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "toggleDiv('"+id+"')"); //draw the polygon to represent the wall with the given coordinates and id

                            ////////////////////
                            //doorknob radius
                            var r = scale(1.25);
                            //doorknob centre x coordinate
                            var cx = (door.Hinge === "R") ? parseFloat(frame[0].x) + scale(parseFloat(1.5)) : parseFloat(frame[1].x) - scale(parseFloat(1.5));
                            //doorknob centre y coordinate
                            var cy = -scale(door.FEndHeight / 2);
                            //append <g> element to draw doorknob in
                            var ggMod = gMod.append("g");
                            //draw doorknob
                            drawCircle(ggMod, r, cx, cy, "", "yellow" /*hard coded for now*/, 1, "black", "$(this).css('fill', '#ccffff'); $('#<%= lblTitle.ClientID %>').text('"+ door.HardwareType + " Hardware'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'yellow'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "toggleDiv('"+id+"')"); //draw the polygon to represent the wall with the given coordinates and id

                            //////////////////
                            //draw the bottom half of the half lite window
                            var topBottomLeft = { "x": parseFloat(frame[0].x) + scale(parseFloat(4)), "y": parseFloat(frame[0].y) + scale(parseFloat(door.Height / 1.7)) }; //top left coordinates
                            var topBottomRight = { "x": parseFloat(frame[1].x) - scale(parseFloat(door.Length / 1.8)), "y": parseFloat(frame[1].y) + scale(parseFloat(door.Height / 1.7)) }; //top right coordinates
                            var bottomBottomRight = { "x": parseFloat(frame[2].x) - scale(parseFloat(door.Length / 1.8)), "y": parseFloat(frame[2].y) - scale(parseFloat(10)) }; //bottom right coordinates
                            var bottomBottomLeft = { "x": parseFloat(frame[3].x) + scale(parseFloat(4)), "y": parseFloat(frame[3].y) - scale(parseFloat(10)) }; //bottom left coordinates

                            var doorBottomFrame = [topBottomLeft, topBottomRight, bottomBottomRight, bottomBottomLeft]; //put all the coordinates together in an array

                            ggMod = ggMod.append("g");
                            drawPolygon(doorBottomFrame, "", "", ggMod, "white", 1, "black", "$(this).css('fill', '#ccffff'); $('#<%= lblTitle.ClientID %>').text('"+ door.DoorStyle + " " +door.DoorType+" "+ door.ItemType +"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "toggleDiv('"+id+"')"); //draw the polygon to represent the wall with the given coordinates and id

                            var topBottomLeft = { "x": parseFloat(frame[0].x) + scale(parseFloat(door.Length / 1.8)), "y": parseFloat(frame[0].y) + scale(parseFloat(door.Height / 1.7)) }; //top left coordinates
                            var topBottomRight = { "x": parseFloat(frame[1].x) - scale(parseFloat(4)), "y": parseFloat(frame[1].y) + scale(parseFloat(door.Height / 1.7)) }; //top right coordinates
                            var bottomBottomRight = { "x": parseFloat(frame[2].x) - scale(parseFloat(4)), "y": parseFloat(frame[2].y) - scale(parseFloat(10)) }; //bottom right coordinates
                            var bottomBottomLeft = { "x": parseFloat(frame[3].x) + scale(parseFloat(door.Length / 1.8)), "y": parseFloat(frame[3].y) - scale(parseFloat(10)) }; //bottom left coordinates

                            var doorBottomFrame = [topBottomLeft, topBottomRight, bottomBottomRight, bottomBottomLeft]; //put all the coordinates together in an array

                            ggMod = ggMod.append("g");
                            drawPolygon(doorBottomFrame, "", "", ggMod, "white", 1, "black", "$(this).css('fill', '#ccffff'); $('#<%= lblTitle.ClientID %>').text('"+ door.DoorStyle + " " +door.DoorType+" "+ door.ItemType +"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "toggleDiv('"+id+"')"); //draw the polygon to represent the wall with the given coordinates and id

                            ////////////////////////////////////
                            //draw the top half of the half lite window
                            var topBottomLeft = { "x": parseFloat(frame[0].x) + scale(parseFloat(4)) + scale(1), "y": parseFloat(frame[0].y) + scale(parseFloat(door.Height / 1.7)) + scale(1) }; //top left coordinates
                            var topBottomRight = { "x": parseFloat(frame[1].x) - scale(parseFloat(door.Length / 1.8)) - scale(1), "y": parseFloat(frame[1].y) + scale(parseFloat(door.Height / 1.7)) + scale(1) }; //top right coordinates
                            var bottomBottomRight = { "x": parseFloat(frame[2].x) - scale(parseFloat(door.Length / 1.8)) - scale(1), "y": parseFloat(frame[2].y) - scale(parseFloat(10)) - scale(1) }; //bottom right coordinates
                            var bottomBottomLeft = { "x": parseFloat(frame[3].x) + scale(parseFloat(4)) + scale(1), "y": parseFloat(frame[3].y) - scale(parseFloat(10)) - scale(1) }; //bottom left coordinates

                            var doorBottomFrame = [topBottomLeft, topBottomRight, bottomBottomRight, bottomBottomLeft]; //put all the coordinates together in an array

                            ggMod = ggMod.append("g");
                            drawPolygon(doorBottomFrame, "", "", ggMod, "white", 1, "black", "$(this).css('fill', '#ccffff'); $('#<%= lblTitle.ClientID %>').text('"+ door.DoorStyle + " " +door.DoorType+" "+ door.ItemType +"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "toggleDiv('"+id+"')"); //draw the polygon to represent the wall with the given coordinates and id

                            var topBottomLeft = { "x": parseFloat(frame[0].x) + scale(parseFloat(door.Length / 1.8)) + scale(1), "y": parseFloat(frame[0].y) + scale(parseFloat(door.Height / 1.7)) + scale(1) }; //top left coordinates
                            var topBottomRight = { "x": parseFloat(frame[1].x) - scale(parseFloat(4)) - scale(1), "y": parseFloat(frame[1].y) + scale(parseFloat(door.Height / 1.7)) + scale(1) }; //top right coordinates
                            var bottomBottomRight = { "x": parseFloat(frame[2].x) - scale(parseFloat(4)) - scale(1), "y": parseFloat(frame[2].y) - scale(parseFloat(10)) - scale(1) }; //bottom right coordinates
                            var bottomBottomLeft = { "x": parseFloat(frame[3].x) + scale(parseFloat(door.Length / 1.8)) + scale(1), "y": parseFloat(frame[3].y) - scale(parseFloat(10)) - scale(1) }; //bottom left coordinates

                            var doorBottomFrame = [topBottomLeft, topBottomRight, bottomBottomRight, bottomBottomLeft]; //put all the coordinates together in an array

                            ggMod = ggMod.append("g");
                            drawPolygon(doorBottomFrame, "", "", ggMod, "white", 1, "black", "$(this).css('fill', '#ccffff'); $('#<%= lblTitle.ClientID %>').text('"+ door.DoorStyle + " " +door.DoorType+" "+ door.ItemType +"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "toggleDiv('"+id+"')"); //draw the polygon to represent the wall with the given coordinates and id

                            ////////////////////

                            //////////////// DOOR WINDOW DETAILS

                            drawDoorWindowDetails(gMod, doorWindowFrame, door, id);

                            //////////////END DOOR WINDOW DETAILS
                    
                            if (door.ScreenType.toLowerCase() != "no screen" && door.ScreenType.toLowerCase() != "noscreen" && door.ScreenType.toLowerCase() != "" && typeof door.ScreenType !== 'undefined') {
                     
                                topLeft = { "x": topLeft.x + parseFloat(scale(1)) , "y": topLeft.y - parseFloat(scale(1)) }; //top left coordinates
                                topRight = { "x": topRight.x + parseFloat(scale(1)) , "y": topRight.y - parseFloat(scale(1)) }; //top right coordinates
                                bottomRight = { "x": bottomLeft.x + parseFloat(scale(1)) , "y": bottomLeft.y }; //bottom right coordinates
                                bottomLeft = { "x": bottomRight.x + parseFloat(scale(1)) , "y": bottomRight.y }; //bottom left coordinates

                                doorWindowFrame = [topLeft, topRight, bottomRight, bottomLeft]; //put all the coordinates together in an array

                                drawScreen(gMod, doorWindowFrame, door.ScreenType, id, scale(door.Height / 2.3));
                            }

                            break;

                        case "full lite": case "full view": case "full view with mini blinds": 
                        case "fulllite": case "fullview": case "fullviewwithminiblinds":
                            
                            var topLeft = { "x": parseFloat(frame[0].x) + scale(parseFloat(3.5)), "y": parseFloat(frame[0].y) + scale(parseFloat(2.5)) }; //top left coordinates
                            var topRight = { "x": parseFloat(frame[1].x) - scale(parseFloat(3.5)), "y": parseFloat(frame[1].y) + scale(parseFloat(2.5)) }; //top right coordinates
                            var bottomRight = { "x": parseFloat(frame[2].x) - scale(parseFloat(3.5)), "y": parseFloat(frame[2].y) - scale(parseFloat(5)) }; //bottom right coordinates
                            var bottomLeft = { "x": parseFloat(frame[3].x) + scale(parseFloat(3.5)), "y": parseFloat(frame[3].y) - scale(parseFloat(5)) }; //bottom left coordinates

                            var doorWindowFrame = [topLeft, topRight, bottomRight, bottomLeft]; //put all the coordinates together in an array

                            gMod = gMod.append("g");
                            drawPolygon(doorWindowFrame, "", "", gMod, "white", 1, "black", "$(this).css('fill', '#ccffff'); $('#<%= lblTitle.ClientID %>').text('"+ door.DoorStyle + " " +door.DoorType+" "+ door.ItemType +"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "toggleDiv('"+id+"')"); //draw the polygon to represent the wall with the given coordinates and id

                            ////////////////////////

                            var r = scale(1.25);
                            var cx = (door.Hinge === "R") ? parseFloat(frame[0].x) + scale(parseFloat(1.5)) : parseFloat(frame[1].x) - scale(parseFloat(1.5));
                            var cy = -scale(door.FEndHeight / 2);

                            var ggMod = gMod.append("g");
                    
                            drawCircle(ggMod, r, cx, cy, "", "yellow" /*hard coded for now*/, 1, "black", "$(this).css('fill', '#ccffff'); $('#<%= lblTitle.ClientID %>').text('"+ door.HardwareType + " Hardware'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'yellow'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "toggleDiv('"+id+"')"); //draw the polygon to represent the wall with the given coordinates and id

                            //////////////// DOOR WINDOW DETAILS

                            drawDoorWindowDetails(gMod, doorWindowFrame, door, id);

                            //////////////END DOOR WINDOW DETAILS
                    
                            if (door.ScreenType.toLowerCase() != "no screen" && door.ScreenType.toLowerCase() != "noscreen" && door.ScreenType.toLowerCase() != "" && typeof door.ScreenType !== 'undefined') {
                     
                                topLeft = { "x": topLeft.x + parseFloat(scale(1)) , "y": topLeft.y - parseFloat(scale(1)) }; //top left coordinates
                                topRight = { "x": topRight.x + parseFloat(scale(1)) , "y": topRight.y - parseFloat(scale(1)) }; //top right coordinates
                                bottomRight = { "x": bottomLeft.x + parseFloat(scale(1)) , "y": bottomLeft.y }; //bottom right coordinates
                                bottomLeft = { "x": bottomRight.x + parseFloat(scale(1)) , "y": bottomRight.y }; //bottom left coordinates

                                doorWindowFrame = [topLeft, topRight, bottomRight, bottomLeft]; //put all the coordinates together in an array

                                drawScreen(gMod, doorWindowFrame, door.ScreenType, id, scale(5));
                            }

                            break;
                    }

                    break;

                case "patio": case "patio door": case "patiodoor":

                    break;

            }


        }
        /**
        This function draws the details of the window within a given door
        @param g - the <g> element on which to append the line
        @param frame - the window frame coordinates
        @param door - the door object to retrieve the details out of
        @param id - 
        */
        function drawDoorWindowDetails(g, frame, door, id) {
 
            id = typeof id !== 'undefined' ? id : "";

            var gDoorWindowDetails = g.append("g").attr("transform", "translate("+ frame[0].x + "," + frame[0].y + ")"); //translate to top right

            switch(door.DoorStyle.toLowerCase()) {
                case "full screen": case "fullscreen": case "screen":  //model 100 cabana/french
                case "full view": case "fullview": //model 200/300 cabana/french
                case "aluminum storm screen": case "aluminumstormscreen": //model 100 patio
                case "aluminum storm glass": case "aluminumstormglass": //model 100/200/300 patio
                case "vinyl guard": case "vinylguard": //model 400 patio
                    //do nothing
                    break;
                
                case "full view colonial": case "fullviewcolonial": //model 200/300 cabana/french
                    
                    var xIncrement = (parseFloat(frame[1].x) - parseFloat(frame[0].x)) / 3; //take the frame width and divide it by 3
                    var yIncrement = (parseFloat(frame[2].y) - parseFloat(frame[1].y)) / 5; //take the frame height and divide it by 5

                    //vertical lines
                    for (var i = frame[0].x + scale(parseFloat(3.5)); i < frame[1].x - scale(1) - scale(parseFloat(3.5)); i += xIncrement) {
                        pt1 = { "x": i, "y": 0 }; //line left coordinates
                        pt2 = { "x": i, "y":  -(frame[1].y + 2) - scale(20) }; //line left coordinates
                        drawLine(pt1, pt2, gDoorWindowDetails, 1, "black", 1);//, "$(this).css('fill', '#ccffff'); $('#<%= lblTitle.ClientID %>').text('"+ type +"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "toggleDiv('"+id+"')");
                    }

                    //horizontal lines
                    for (var i = parseFloat(frame[1].y) + scale(parseFloat(50)) - scale(parseFloat(door.Kickplate)) + scale(parseFloat(1)); i < frame[2].y + parseFloat(0.5) + scale(parseFloat(20)); i += (parseFloat(yIncrement) + parseFloat(2))) {
                        pt1 = { "x": (frame[0].x - scale(4) - 3), "y": -i }; //line left coordinates
                        pt2 = { "x": (frame[1].x - scale(4) - 3), "y": -i }; //line left coordinates
                        drawLine(pt1, pt2, gDoorWindowDetails, 1, "black", 1);//, "$(this).css('fill', '#ccffff'); $('#<%= lblTitle.ClientID %>').text('"+ type +"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "toggleDiv('"+id+"')");
                    }

                    break;
                
                case "vertical four track": case "verticalfourtrack": case "vertical4track": case "vertical 4 track": case "v4t": //model 200 cabana/french
                    //////////////////////////////////////////////////////////
                    //////////////////////////////////////////////////////////
                    // this is just template code from drawing v4t windows  //
                    // can't test it until door window are working properly //
                    //////////////////////////////////////////////////////////
                    //////////////////////////////////////////////////////////
                    var ventHeight = 0;
                    var window = door.DoorWindow;

                    gVent = gDoorWindowDetails.append("g").attr("id", "HKLDFHAKJLDHF");

                    for (var i = 0; i < window.NumVents; i++) {
                        ventHeight = scale(window.VentHeights[i] / 4); ///4 because the vent heights are messed up
                        
                        var yBottom = (i === (window.NumVents - 1)) ? -(ventHeight - scale(1)) : -(ventHeight - scale(0.5));

                        var topLeft = { "x": scale(1), "y": scale(-1) }; //top left coordinates
                        var topRight = { "x": scale(window.Width - 3), "y": scale(-1) }; //top right coordinates
                        var bottomRight = { "x": scale(window.Width - 3), "y": yBottom }; //bottom right coordinates
                        var bottomLeft = { "x": (scale(1)), "y": yBottom }; //bottom left coordinates

                        var slider = [topLeft, topRight, bottomRight, bottomLeft]; //put all the coordinates together in an array

                        drawPolygon(slider, "", "", gVent, "white", 1, "black", "$(this).css('fill', '#ccffff'); $('#<%= lblTitle.ClientID %>').text('"+ window.WindowStyle + " " +window.ItemType+" Vent "+ (parseFloat(i) + parseFloat(1)) +"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "toggleDiv('"+id+"')"); //draw the polygon to represent the wall with the given coordinates and id
                        
                        if (window.SpreaderBar !== 0) {

                            var yTop = (i === (window.NumVents - 1)) ? -(ventHeight - scale(1)) : -(ventHeight - scale(0.5));

                            var pt1 = { "x": scale(window.SpreaderBar), "y": scale(-1) }; //line left coordinates
                            var pt2 = { "x": scale(window.SpreaderBar), "y": yTop }; //line left coordinates
                            drawLine(pt1, pt2, gVent, 2);
                        }

                        //drawGlassLines(slider);

                        gVent = gVent.append("g").attr("transform", "translate("+ 0 + "," + (parseFloat(-ventHeight)) + ")");

                    }

                    ventHeight = 0;
                    for (var i = 0; i < window.NumVents - 1; i++) {
                        ventHeight += scale(window.VentHeights[i] / 4); ///4 because the vent heights are messed up
                        gVent = gWindow.append("g").attr("transform", "translate("+ 0 + "," + -ventHeight + ")");
                        var pt1 = { "x": scale(0), "y": scale(0) }; //line left coordinates
                        var pt2 = { "x": scale(parseFloat(window.Width) - 2), "y": scale(0) }; //line left coordinates
                        drawLine(pt1, pt2, gVent, 1);

                    }

                    break;
                
                case "halflite": case "half lite": //model 400 cabana
                    var topLeft = { "x": parseFloat(frame[0].x) - parseFloat(scale(4.5)) + parseFloat(scale(1)), "y": parseFloat(frame[0].y) + parseFloat(scale(78.65)) + parseFloat(scale(1)) }; //top left coordinates
                    var topRight = { "x": parseFloat(frame[1].x) - parseFloat(scale(4.5)) - parseFloat(scale(1)), "y": parseFloat(frame[1].y) + parseFloat(scale(78.65)) + parseFloat(scale(1)) }; //top right coordinates
                    var bottomRight = { "x": parseFloat(frame[2].x) - parseFloat(scale(4.5)) - parseFloat(scale(1)), "y": parseFloat(frame[2].y) + parseFloat(scale(78.65)) - parseFloat(scale(1)) }; //bottom right coordinates
                    var bottomLeft = { "x": parseFloat(frame[3].x) - parseFloat(scale(4.5)) + parseFloat(scale(1)), "y": parseFloat(frame[3].y) + parseFloat(scale(78.65)) - parseFloat(scale(1)) }; //bottom left coordinates

                    var doorWindowFrame = [topLeft, topRight, bottomRight, bottomLeft]; //put all the coordinates together in an array

                    drawPolygon(doorWindowFrame, "", "", gDoorWindowDetails, "white", 1, "black", "$(this).css('fill', '#ccffff'); $('#<%= lblTitle.ClientID %>').text('"+ door.DoorStyle + " " +door.DoorType+" "+ door.ItemType +"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "toggleDiv('"+id+"')"); //draw the polygon to represent the wall with the given coordinates and id
                    break;
                
                case "half lite venting": case "halfliteventing": //model 400 cabana
                    var topLeft = { "x": parseFloat(frame[0].x) - parseFloat(scale(4.5)) + parseFloat(scale(1)), "y": parseFloat(frame[0].y) + parseFloat(scale(78.65)) + parseFloat(scale(1)) }; //top left coordinates
                    var topRight = { "x": parseFloat(frame[1].x) - parseFloat(scale(4.5)) - parseFloat(scale(1)), "y": parseFloat(frame[1].y) + parseFloat(scale(78.65)) + parseFloat(scale(1)) }; //top right coordinates
                    var bottomRight = { "x": parseFloat(frame[2].x) - parseFloat(scale(4.5)) - parseFloat(scale(1)), "y": parseFloat(frame[2].y) + parseFloat(scale(78.65)) - parseFloat(scale(1)) + (frame[2].y / 1.75) }; //bottom right coordinates
                    var bottomLeft = { "x": parseFloat(frame[3].x) - parseFloat(scale(4.5)) + parseFloat(scale(1)), "y": parseFloat(frame[3].y) + parseFloat(scale(78.65)) - parseFloat(scale(1)) + (frame[2].y / 1.75) }; //bottom left coordinates

                    var doorWindowFrame = [topLeft, topRight, bottomRight, bottomLeft]; //put all the coordinates together in an array

                    drawPolygon(doorWindowFrame, "", "", gDoorWindowDetails, "white", 1, "black", "$(this).css('fill', '#ccffff'); $('#<%= lblTitle.ClientID %>').text('"+ door.DoorStyle + " " +door.DoorType+" "+ door.ItemType +"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "toggleDiv('"+id+"')"); //draw the polygon to represent the wall with the given coordinates and id

                    var topLeft = { "x": parseFloat(frame[0].x) - parseFloat(scale(4.5)) + parseFloat(scale(1)), "y": parseFloat(frame[0].y) + parseFloat(scale(78.65)) + parseFloat(scale(1)) - (frame[2].y / 1.75) }; //top left coordinates
                    var topRight = { "x": parseFloat(frame[1].x) - parseFloat(scale(4.5)) - parseFloat(scale(1)), "y": parseFloat(frame[1].y) + parseFloat(scale(78.65)) + parseFloat(scale(1)) - (frame[2].y / 1.75) }; //top right coordinates
                    var bottomRight = { "x": parseFloat(frame[2].x) - parseFloat(scale(4.5)) - parseFloat(scale(1)), "y": parseFloat(frame[2].y) + parseFloat(scale(78.65)) - parseFloat(scale(1)) }; //bottom right coordinates
                    var bottomLeft = { "x": parseFloat(frame[3].x) - parseFloat(scale(4.5)) + parseFloat(scale(1)), "y": parseFloat(frame[3].y) + parseFloat(scale(78.65)) - parseFloat(scale(1)) }; //bottom left coordinates

                    var doorWindowFrame = [topLeft, topRight, bottomRight, bottomLeft]; //put all the coordinates together in an array

                    var g2 = gDoorWindowDetails.append("g");

                    drawPolygon(doorWindowFrame, "", "", g2, "white", 1, "black", "$(this).css('fill', '#ccffff'); $('#<%= lblTitle.ClientID %>').text('"+ door.DoorStyle + " " +door.DoorType+" "+ door.ItemType +"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "toggleDiv('"+id+"')"); //draw the polygon to represent the wall with the given coordinates and id
                    break;
                
                case "half lite with mini blinds": case "halflitewithminiblinds": //model 400 cabana
                    var topLeft = { "x": parseFloat(frame[0].x) - parseFloat(scale(4.5)) + parseFloat(scale(1)), "y": parseFloat(frame[0].y) + parseFloat(scale(78.65)) + parseFloat(scale(1)) }; //top left coordinates
                    var topRight = { "x": parseFloat(frame[1].x) - parseFloat(scale(4.5)) - parseFloat(scale(1)), "y": parseFloat(frame[1].y) + parseFloat(scale(78.65)) + parseFloat(scale(1)) }; //top right coordinates
                    var bottomRight = { "x": parseFloat(frame[2].x) - parseFloat(scale(4.5)) - parseFloat(scale(1)), "y": parseFloat(frame[2].y) + parseFloat(scale(78.65)) - parseFloat(scale(1)) }; //bottom right coordinates
                    var bottomLeft = { "x": parseFloat(frame[3].x) - parseFloat(scale(4.5)) + parseFloat(scale(1)), "y": parseFloat(frame[3].y) + parseFloat(scale(78.65)) - parseFloat(scale(1)) }; //bottom left coordinates

                    var doorWindowFrame = [topLeft, topRight, bottomRight, bottomLeft]; //put all the coordinates together in an array

                    drawPolygon(doorWindowFrame, "", "", gDoorWindowDetails, "white", 1, "black", "$(this).css('fill', '#ccffff'); $('#<%= lblTitle.ClientID %>').text('"+ door.DoorStyle + " " +door.DoorType+" "+ door.ItemType +"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "toggleDiv('"+id+"')"); //draw the polygon to represent the wall with the given coordinates and id

                    //Draws horizontal lines of the mini blinds onto the window
                    for (var i = doorWindowFrame[1].y; i < doorWindowFrame[2].y; i += scale(1.5)) {
                        var pt1 = { "x": (doorWindowFrame[0].x + scale(1)), "y": i }; //line left coordinates
                        var pt2 = { "x": (doorWindowFrame[1].x - scale(1)), "y": i }; //line left coordinates
                        drawLine(pt1, pt2, gDoorWindowDetails, 1, "black", 0.5, "$(this).css('fill', '#ccffff'); $('#<%= lblTitle.ClientID %>').text('"+ door.DoorStyle +"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "toggleDiv('"+id+"')");
                    }

                    break;
                case "full lite": case "fulllite": //model 400 cabana

                    var topLeft = { "x": parseFloat(frame[0].x) - parseFloat(scale(4.5)) + parseFloat(scale(1)), "y": parseFloat(frame[0].y) + parseFloat(scale(78.65)) + parseFloat(scale(1)) }; //top left coordinates
                    var topRight = { "x": parseFloat(frame[1].x) - parseFloat(scale(4.5)) - parseFloat(scale(1)), "y": parseFloat(frame[1].y) + parseFloat(scale(78.65)) + parseFloat(scale(1)) }; //top right coordinates
                    var bottomRight = { "x": parseFloat(frame[2].x) - parseFloat(scale(4.5)) - parseFloat(scale(1)), "y": parseFloat(frame[2].y) + parseFloat(scale(78.65)) - parseFloat(scale(1)) }; //bottom right coordinates
                    var bottomLeft = { "x": parseFloat(frame[3].x) - parseFloat(scale(4.5)) + parseFloat(scale(1)), "y": parseFloat(frame[3].y) + parseFloat(scale(78.65)) - parseFloat(scale(1)) }; //bottom left coordinates

                    var doorWindowFrame = [topLeft, topRight, bottomRight, bottomLeft]; //put all the coordinates together in an array

                    drawPolygon(doorWindowFrame, "", "", gDoorWindowDetails, "white", 1, "black", "$(this).css('fill', '#ccffff'); $('#<%= lblTitle.ClientID %>').text('"+ door.DoorStyle + " " +door.DoorType+" "+ door.ItemType +"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "toggleDiv('"+id+"')"); //draw the polygon to represent the wall with the given coordinates and id

                    break;
                case "full view with mini blinds": case "fullviewwithminiblinds": //model 400 cabana

                    var topLeft = { "x": parseFloat(frame[0].x) - parseFloat(scale(4.5)) + parseFloat(scale(1)), "y": parseFloat(frame[0].y) + parseFloat(scale(78.65)) + parseFloat(scale(1)) }; //top left coordinates
                    var topRight = { "x": parseFloat(frame[1].x) - parseFloat(scale(4.5)) - parseFloat(scale(1)), "y": parseFloat(frame[1].y) + parseFloat(scale(78.65)) + parseFloat(scale(1)) }; //top right coordinates
                    var bottomRight = { "x": parseFloat(frame[2].x) - parseFloat(scale(4.5)) - parseFloat(scale(1)), "y": parseFloat(frame[2].y) + parseFloat(scale(78.65)) - parseFloat(scale(1)) }; //bottom right coordinates
                    var bottomLeft = { "x": parseFloat(frame[3].x) - parseFloat(scale(4.5)) + parseFloat(scale(1)), "y": parseFloat(frame[3].y) + parseFloat(scale(78.65)) - parseFloat(scale(1)) }; //bottom left coordinates

                    var doorWindowFrame = [topLeft, topRight, bottomRight, bottomLeft]; //put all the coordinates together in an array

                    drawPolygon(doorWindowFrame, "", "", gDoorWindowDetails, "white", 1, "black", "$(this).css('fill', '#ccffff'); $('#<%= lblTitle.ClientID %>').text('"+ door.DoorStyle + " " +door.DoorType+" "+ door.ItemType +"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "toggleDiv('"+id+"')"); //draw the polygon to represent the wall with the given coordinates and id

                    //Draws horizontal lines of the mini blinds onto the window
                    for (var i = doorWindowFrame[1].y; i < doorWindowFrame[2].y; i += scale(1.5)) {
                        var pt1 = { "x": (doorWindowFrame[0].x + scale(1)), "y": i }; //line left coordinates
                        var pt2 = { "x": (doorWindowFrame[1].x - scale(1)), "y": i }; //line left coordinates
                        drawLine(pt1, pt2, gDoorWindowDetails, 1, "black", 0.5, "$(this).css('fill', '#ccffff'); $('#<%= lblTitle.ClientID %>').text('"+ door.DoorStyle +"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "toggleDiv('"+id+"')");
                    }

                    break;
            }
        }

        /**
        This function draws the screen on a given window
        @param g - the <g> element on which to append the line
        @param frame - the window frame coordinates
        @param type - screen type
        @param yBottom - if its a door window (hot fix)
        */
        function drawScreen(g, frame, type, id, yBottom) {

            yBottom = typeof yBottom !== 'undefined' ? yBottom : 0;

            var pt1, pt2;
            gScreen = g.append("g");

            //Draws vertical lines of the screen onto the window
            for (var i = frame[0].x; i < frame[1].x - scale(1); i += scale(0.5)) {
                pt1 = { "x": i, "y": -1 - yBottom }; //line left coordinates
                pt2 = { "x": i, "y":  (frame[1].y + scale(1) + 1) }; //line left coordinates
                drawLine(pt1, pt2, gScreen, 1, "black", 0.05, "$(this).css('fill', '#ccffff'); $('#<%= lblTitle.ClientID %>').text('"+ type +"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "toggleDiv('"+id+"')");
            }

            //Draws horizontal lines of the screen onto the window
            for (var i = frame[1].y + scale(2); i < frame[2].y + scale(1); i += scale(0.5)) {
                pt1 = { "x": (frame[0].x - scale(1) + 1), "y": i }; //line left coordinates
                pt2 = { "x": (frame[1].x - scale(1) - 1), "y": i }; //line left coordinates
                drawLine(pt1, pt2, gScreen, 1, "black", 0.05, "$(this).css('fill', '#ccffff'); $('#<%= lblTitle.ClientID %>').text('"+ type +"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "toggleDiv('"+id+"')");
            }
        }

        /**
        This function draws glass lines (3 diagonal lines) on a given window

        Note: this function is not functional yet

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
        @param mouseover -
        @param mouseout - 
        @param click - 
        */
        function drawLine(pt1, pt2, g, strokeWidth, stroke, opacity, mouseover, mouseout, click) {

            strokeWidth = typeof strokeWidth !== 'undefined' ? strokeWidth : 1;
            stroke = typeof stroke !== 'undefined' ? stroke : "black";
            opacity = typeof opacity !== 'undefined' ? opacity : 1.0;
            mouseover = typeof mouseover !== 'undefined' ? mouseover : "";
            mouseout = typeof mouseout !== 'undefined' ? mouseout : "";
            click = typeof click !== 'undefined' ? click : "";

            var poly = g.append("line")
                     .attr("x1", pt1.x)
                     .attr("y1", pt1.y)
                     .attr("x2", pt2.x)
                     .attr("y2", pt2.y)
                     .attr("stroke", stroke)
                     .attr("stroke-width", strokeWidth)
                     .attr("stroke-opacity", opacity)
                     .attr("onmouseover", mouseover)
                     .attr("onmouseout", mouseout)
                     .attr("onclick", click); 
        }

        /**
        This function draws a polygon on the canvas with the given data points as coordinates and sets it id to the given id
        @param points - coordinates of a given polygon
        @param id - to be given to the polygon object
        @param title - to give a name to the shape drawn
        @param g - the <g> element on which to append the polygon
        @param colour - fill colour (default: white)
        @param opacity - fill opacity (default: 1.0)
        @param stroke - outline stroke colour (default: black)
        @param mouseover
        @param mouseout
        @param click
        */
        function drawPolygon(points, id, title, g, colour, opacity, stroke, mouseover, mouseout, click) {
            id = typeof id !== 'undefined' ? id : "";
            colour = typeof colour !== 'undefined' ? colour : "white";
            opacity = typeof opacity !== 'undefined' ? opacity : 1.0;
            stroke = typeof stroke !== 'undefined' ? stroke : "black";
            mouseover = typeof mouseover !== 'undefined' ? mouseover : "";
            mouseout = typeof mouseout !== 'undefined' ? mouseout : "";
            click = typeof click !== 'undefined' ? click : "";

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
                     .attr("stroke-width", "1")
                     .style('fill', colour)
                     .style('fill-opacity', opacity)
                     .attr('stroke', stroke)
                     .attr("onmouseover", mouseover)
                     .attr("onmouseout", mouseout)
                     .attr("onclick", click); 
        }

        /**
        This function draws a recangle on the canvas with the given data points as coordinates and sets it id to the given id
        @param g - the <g> element on which to append the rect
        @param width - rectangle width
        @param height - rectangle height
        @param x - starting x coordinate
        @param y - starting y coordinate
        @param id - 
        @param colour - fill colour (default: white)
        @param opacity - fill opacity (default: 1.0)
        @param stroke - outline stroke colour (default: black)
        @param mouseover
        @param mouseout
        @param click
        */
        function drawRect(g, width, height, x, y, id, colour, opacity, stroke, mouseover, mouseout, click) {
            //alert(id);
            id = typeof id !== 'undefined' ? id : "";
            colour = typeof colour !== 'undefined' ? colour : "white";
            opacity = typeof opacity !== 'undefined' ? opacity : 1.0;
            stroke = typeof stroke !== 'undefined' ? stroke : "black";
            mouseover = typeof mouseover !== 'undefined' ? mouseover : "";
            mouseout = typeof mouseout !== 'undefined' ? mouseout : "";
            click = typeof click !== 'undefined' ? click : "";

            var rect = g.append('rect')
                //.attr("class", "label")
                .attr("id", id)
                .attr('width', width)
                .attr('height', height)
                .attr('x', x)
                .attr('y', y)
                .style('fill', colour)
                .style('fill-opacity', opacity)
                .attr('stroke', stroke)
                .attr("onmouseover", mouseover)
                .attr("onmouseout", mouseout)
                .attr("onclick", click); 
        }


        /**
        This function draws a circle on the canvas with the given data points as coordinates and sets it id to the given id
        @param g - the <g> element on which to append the rect
        @param r - radius of the circle
        @param cx - origin x coordinate
        @param cy - origin y coordinate
        @param id - 
        @param colour - fill colour (default: white)
        @param opacity - fill opacity (default: 1.0)
        @param stroke - outline stroke colour (default: black)
        @param mouseover
        @param mouseout
        @param click
        */
        function drawCircle(g, r, cx, cy, id, colour, opacity, stroke, mouseover, mouseout, click) {
            
            id = typeof id !== 'undefined' ? id : "";
            colour = typeof colour !== 'undefined' ? colour : "white";
            opacity = typeof opacity !== 'undefined' ? opacity : 1.0;
            stroke = typeof stroke !== 'undefined' ? stroke : "black";
            mouseover = typeof mouseover !== 'undefined' ? mouseover : "";
            mouseout = typeof mouseout !== 'undefined' ? mouseout : "";
            click = typeof click !== 'undefined' ? click : "";
            
            var circle = g.append("circle")
                .attr("id", id)
                .attr("r", r)
                .attr("cx", cx)
                .attr("cy", cy)
                .style("stroke", stroke)
                .style("fill", colour)
                .style('fill-opacity', opacity)
                .attr("onmouseover", mouseover)
                .attr("onmouseout", mouseout)
                .attr("onclick", click); 
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
            
                    drawRect(g, width, height, x, y, "", "white", 0.9); //draw the rectangle
         
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

            //hide all the li tags for each wall and each linear item and each modular item
            for (var i = 0; i < jsonVersions[version].length; i++) { 
                $("#wall"+jsonVersions[version][i].FirstItemIndex).css("display", "none");
                for (var j = 0; j < jsonVersions[version][i].LinearItems.length; j++) {
                    $("#li"+jsonVersions[version][i].LinearItems[j].LinearIndex).css("display", "none");
                    if (typeof jsonVersions[version][i].LinearItems[j].ModularItems !== 'undefined') {
                        for (var k = 0; k < jsonVersions[version][i].LinearItems[j].ModularItems.length; k++) {
                            $("#mod"+jsonVersions[version][i].LinearItems[j].LinearIndex+k).css("display", "none");
                        }
                    }
                }
            }
            
            if (value != "-1") {

                if ($("#existingWall"))
                    d3.selectAll("#existingWall").remove(); //remove existing walls

                if($("#layout"))
                    d3.selectAll("#layout").remove(); //remove room layout drawing
                

                //show the appropriate wall li mod tags
                $("#wall"+jsonVersions[version][value].FirstItemIndex).css("display", "block");
                ////show the appropriate wall li tag for the linear items and modular items of a selected wall
                //for (var i = 0; i < jsonVersions[version][value].LinearItems.length; i++) {
                //    $("#li"+jsonVersions[version][value].LinearItems[i].LinearIndex).css("display", "none");
                //    if (typeof jsonVersions[version][value].LinearItems[i].ModularItems !== 'undefined') {
                //        $("#li"+jsonVersions[version][value].LinearItems[i].LinearIndex).css("background-color", "#EBC79E");
                //        for (var j = 0; j < jsonVersions[version][value].LinearItems[i].ModularItems.length; j++) {
                //            $("#mod"+jsonVersions[version][value].LinearItems[i].LinearIndex+j).css("display", "none");
                //        }
                //    }
                //}

                for (var i = 0; i < jsonVersions[version][value].LinearItems.length; i++) {
                    $("#li"+jsonVersions[version][value].LinearItems[i].LinearIndex).css("display", "block");
                    if (typeof jsonVersions[version][value].LinearItems[i].ModularItems !== 'undefined') {
                        $("#li"+jsonVersions[version][value].LinearItems[i].LinearIndex).css("background-color", "#EBC79E");
                        for (var j = 0; j < jsonVersions[version][value].LinearItems[i].ModularItems.length; j++) {
                            $("#mod"+jsonVersions[version][value].LinearItems[i].LinearIndex+j).css("display", "block");
                        }
                    }
                }

                wallIndex = value; //set the wall index global variable
            
                var startHeight = jsonVersions[version][wallIndex].StartHeight;
                var endHeight = jsonVersions[version][wallIndex].EndHeight;
                var highHeight = (startHeight > endHeight) ? startHeight : endHeight;
                var length = jsonVersions[version][wallIndex].Length;

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
            else {

                ////show all the li tags for each wall and each linear item and each modular item
                //for (var i = 0; i < jsonVersions[version].length; i++) { 
                //    $("#wall"+jsonVersions[version][i].FirstItemIndex).css("display", "block");
                //    for (var j = 0; j < jsonVersions[version][i].LinearItems.length; j++) {
                //        $("#li"+jsonVersions[version][i].LinearItems[j].LinearIndex).css("display", "none");
                //        if (typeof jsonVersions[version][i].LinearItems[j].ModularItems !== 'undefined') {
                //            $("#li"+jsonVersions[version][i].LinearItems[j].LinearIndex).css("background-color", "#EBC79E");
                //            for (var k = 0; k < jsonVersions[version][i].LinearItems[j].ModularItems.length; k++) {
                //                $("#mod"+jsonVersions[version][i].LinearItems[j].LinearIndex+k).css("display", "none");
                //            }
                //        }
                //    }
                //}

                //show all the li tags for each wall and each linear item and each modular item
                for (var i = 0; i < jsonVersions[version].length; i++) { 
                    $("#wall"+jsonVersions[version][i].FirstItemIndex).css("display", "block");
                    for (var j = 0; j < jsonVersions[version][i].LinearItems.length; j++) {
                        $("#li"+jsonVersions[version][i].LinearItems[j].LinearIndex).css("display", "block");
                        if (typeof jsonVersions[version][i].LinearItems[j].ModularItems !== 'undefined') {
                            $("#li"+jsonVersions[version][i].LinearItems[j].LinearIndex).css("background-color", "#EBC79E");
                            for (var k = 0; k < jsonVersions[version][i].LinearItems[j].ModularItems.length; k++) {
                                $("#mod"+jsonVersions[version][i].LinearItems[j].LinearIndex+k).css("display", "block");
                            }
                        }
                    }
                }

                ///////////////////////////////////////////////////////////////////////////////
                //hard coding set back because its not being stored/retrieved from the database
                jsonVersions[version][0].SetBack = jsonVersions[version][0].Length; 
                jsonVersions[version][2].SetBack = -jsonVersions[version][2].Length;
                ///////////////////////////////////////////////////////////////////////////////

                var projection = getProjection();
                var width = getWidth();

                //temporary scale to see if the enlarged wall will fit the canvas
                scale.domain([0 , projection])
                     .range([0 , MAX_CANVAS_HEIGHT - 100]);

                //check if the enlarged wall width is greater than canvas width
                //and set the upper domain and range
                var upperDomain = (scale(width) < (MAX_CANVAS_WIDTH - 200)) ? parseFloat(projection) + parseFloat(scale(10)) : width;
                var upperRange = (scale(width) < (MAX_CANVAS_WIDTH - 200)) ? (MAX_CANVAS_HEIGHT - 100) : (MAX_CANVAS_WIDTH - 150);
            
                //set the scale's domain and range according to wall size
                scale.domain([0 , upperDomain ])
                     .range([0 , upperRange]);
            
                gWall = canvas.append("g").attr("id", "wall");

                drawRoomLayout(); //draw the wall
            }
        }

        /**
        This function slide toggles the appropriate divs based on item on the canvas that was clicked
        @param id - the id of the div to slide down
        */
        function toggleDiv(id) {

            //slide up everything
            for (var i = 0; i < jsonVersions[version].length; i++) { 
                $("#wall_"+jsonVersions[version][i].FirstItemIndex).slideUp();
                for (var j = 0; j < jsonVersions[version][i].LinearItems.length; j++) {
                    $("#div_"+jsonVersions[version][i].LinearItems[j].LinearIndex).slideUp();
                    if (typeof jsonVersions[version][i].LinearItems[j].ModularItems !== 'undefined') {
                        for (var k = 0; k < jsonVersions[version][i].LinearItems[j].ModularItems.length; k++) {
                            $("#div_"+jsonVersions[version][i].LinearItems[j].LinearIndex+k).slideUp();
                        }
                    }
                }
            }

            var container = $("#"+id); //the div to slide down
            var inputControls = (container.find("input")); //get all the inputs from the div
            $('.overlayContainer').slideDown(); //slide down the overlay container
            container.slideDown(); //slide down the div that was selected
            if (inputControls.length)
                inputControls[0].focus(); //put focus on the first input element in the selected div
            
            //for (var i = 0; i < inputs.length; i++) {
            //    if(inputs[i].is('input:text')) {
            //        inputs[i].focus();
            //        break;
            //    }
            //}
        }
        

        ///**
        //This function shows/hides the appropriate li rows depending on which wall is clicked
        //@param firstLiIndex - the first Li item to display for the selected wall
        //@param lastLiIndex - the last Li item to display for the selected wall
        //@param selected - is the wall radio button checked (true or false)
        //*/
        //function radWallClicked(firstLiIndex, lastLiIndex, selected) {

        //    for (var i = 0; i <= jsonVersions[version][jsonVersions[version].length - 1].LastItemIndex; i++) 
        //        $("#li"+i).css("display", "none");

        //    if (selected) {
        //        for (var i = firstLiIndex; i < lastLiIndex; i++) 
        //            $("#li"+i).css("display", "block");
        //    }
        //}

        ///**
        //This function shows/hides the appropriate mod rows depending on which li is clicked
        //@param liIndex - index of li
        //@param modCount - total mod count in this li
        //@param selected - is the wall radio button checked (true or false)
        //*/
        //function radModClicked(liIndex, modCount, selected) {

        //    for (var i = 0; i < modCount; i++) 
        //        $("#mod"+liIndex+i).css("display", "none");

        //    if (selected) {
        //        for (var i = 0; i < modCount; i++) 
        //            $("#mod"+liIndex+i).css("display", "block");
        //    }
        //}

        /**
        This function updates the sunroom locally/temporarily.
        It makes a backup of the previous sunroom for undo/redo purposes
        */
        function updateSunroom() {
            
            version++;
            jsonVersions[version] = JSON.parse(JSON.stringify(jsonVersions[version - 1]));

            var container;//, inputControls;

            for (var i = 0; i < jsonVersions[version].length; i++) { 
                updateValues($("#wall_"+jsonVersions[version][i].FirstItemIndex), i, -1, -1);
                for (var j = 0; j < jsonVersions[version][i].LinearItems.length; j++) {
                    updateValues($("#div_"+jsonVersions[version][i].LinearItems[j].LinearIndex), i, j, -1);
                    if (typeof jsonVersions[version][i].LinearItems[j].ModularItems !== 'undefined') {
                        for (var k = 0; k < jsonVersions[version][i].LinearItems[j].ModularItems.length; k++) {
                            updateValues($("#div_"+jsonVersions[version][i].LinearItems[j].LinearIndex+k), i, j, k);
                        }
                    }
                }
            }
        }

            
        /**
        This function resets all of the changeable values of the sunroom based on what is in the input controls of the project editor
        It then redraws the sunroom with the new specs.
        */
        function updateValues(container, wall, li, mod) {
            //console.log("wall: " + wall + ", li: " + li + ", mod: " + mod);
            //console.log(container);
            inputControls = container.find("input");
            //console.log(inputControls);
            //console.log(container);
            //console.log(jsonVersions);
            if (li === -1 && mod === -1) { //wall attributes
                firstItemIndex = jsonVersions[version][wall].FirstItemIndex;
                jsonVersions[version][wall].Name = $("#ModOverlay_txtWallName" + firstItemIndex).val();    
                jsonVersions[version][wall].Length = parseFloat($("#ModOverlay_txtWallLength" + firstItemIndex).val()) + parseFloat($("#ModOverlay_ddlWallLength" + firstItemIndex +" :selected").val());
                jsonVersions[version][wall].LeftHeight = parseFloat($("#ModOverlay_txtWallLeftHeight" + firstItemIndex).val()) + parseFloat($("#ModOverlay_ddlWallLeftHeight" + firstItemIndex +" :selected").val());
                jsonVersions[version][wall].RightHeight = parseFloat($("#ModOverlay_txtWallRightHeight" + firstItemIndex).val()) + parseFloat($("#ModOverlay_ddlWallRightHeight" + firstItemIndex +" :selected").val());
                jsonVersions[version][wall].FireProtection = $("#ModOverlay_radWallFireProtectionYes" + firstItemIndex).is(':checked');
            }
            else if (mod === -1) { //li attributes
                //reset all changable linear item attributes here
            }
            else { //mod attributes
                //reset all modular item attributes here
            }

            //redraw the sunroom with the new specs
            sunroomObjectChanged("0");

        }

        /**
        This function updates the sunroom in the db/permanently
        */
        function submitSunroom() {
            alert("submit sunroom");
        }

        /**
        This function reverts the sunroom back to a previously saved version
        */
        function undo() {
            if (version > 0) {
                version--;
                sunroomObjectChanged("0");
            }
            else {
                alert("Nothing left to undo");
            }
        }

        /**
        This function undoes the last undo and reverts the sunroom back to a newer version
        */
        function redo() { 
            if (version < jsonVersions.length - 1) {
                version++;
                sunroomObjectChanged("0");
            }
            else {
                alert("Nothing left to redo");
            }
        }

        /**
        This function moves a linear item to the left
        */
        function moveLeft() {
        
        }

        /**
        This function moves a linear item to the right
        */
        function moveRight() {
        
        }

        /**
        This function hides/shows appropriate rows depending on whether sunshade is selected or not
        @param sunshade - sunshade selected true or false
        @param id - linear item id
        */
        function sunshadeOptionChanged(sunshade, id) {

            if(sunshade) {
                $("#ModOverlay_rowLiSunshadeChain"+id).css("display","table-row");
                $("#ModOverlay_rowLiSunshadeFabric"+id).css("display","table-row");
                $("#ModOverlay_rowLiSunshadeOpenness"+id).css("display","table-row");
                $("#ModOverlay_rowLiSunshadeValance"+id).css("display","table-row");
            }
            else {
                $("#ModOverlay_rowLiSunshadeChain"+id).css("display","none");
                $("#ModOverlay_rowLiSunshadeFabric"+id).css("display","none");
                $("#ModOverlay_rowLiSunshadeOpenness"+id).css("display","none");
                $("#ModOverlay_rowLiSunshadeValance"+id).css("display","none");
            }
        }

        /**
        This functions shows/hides the kneewall tint row appropriately depending on whether solid wall or glass is selected
        @param id - id of the row to show/hide
        */
        function kneewallTypeChanged(id) {
            var value = $("#"+id+" :selected").text();
            if (value.toLowerCase() === "glass") 
                $("#ModOverlay_rowKneewallTint" + id.substring(id.length - 2, id.length)).show();
            else 
                $("#ModOverlay_rowKneewallTint" + id.substring(id.length - 2, id.length)).hide();
        }

        /**
        This function uses the list of walls to calculate the room projection and antiProjection 
            by simply adding the setback value of each wall.
        @return projection - i.e. room projection from the left
        @return antiProjection - i.e. room projection from the right
        */
        function getProjection() {
//            var projection;
//            var antiProjection;
            var tempProjection = 0; //variable to store each setback
            var tempAntiProjection = 0;
            var highestProjection = 0; //variable to store the highest projection calculated from the left side of the room
            var lowestProjection = 0; //variable to store the highest projection calculated from the right side of the room
            //var overallProjection;
            for (var i = 0; i < jsonVersions[version].length; i++) { //run through all the setbacks
                tempProjection = +tempProjection + +jsonVersions[version][i].SetBack; //add the values to temp variable
                if (tempProjection > highestProjection) { //determine if the current temp projection is greater than the highest projection calculated
                    highestProjection = tempProjection; // reset the highest projection
                    projection = highestProjection;
                }
                if (jsonVersions[version][i].SetBack < 0) {
                    tempAntiProjection = tempAntiProjection + jsonVersions[version][i].SetBack * -1;
                    antiProjection = tempAntiProjection;
                }
            }

            return (antiProjection > projection) ? antiProjection : projection;
        }

        /**
        This function is used to calculate the width of the sunroom using the setback formula.
        Once the width is determined it gets stored in the global roomWidth variable.
        @return highestWidth (i.e. room width)
        */
        function getWidth() {
            var tempWidth = 0; //variable to store each setback
            var highestWidth = 0; //variable to store the highest width calculated from the left side of the room
            var width = 0;
            var isGable = false;
            for (var index = 0; index < jsonVersions[version].length; index++) { //run through all the setbacks
                if (jsonVersions[version][index].WallType === "G")
                {
                    isGable = true;
                }
            
                /*
                WEST        :   ZERO
                EAST        :   ZERO
                SOUTH       :   LENGTH
                NORTH       :   NEGATIVE LENGTH
                SOUTHEAST   :   (2a^2 = L^2)
                NORTHEAST   :   (2a^2 = L^2)            
                SOUTHWEST   :   NEGATIVE (2a^2 = L^2)  
                NORTHWEST   :   NEGATIVE (2a^2 = L^2) 
                */

                //length of the given wall
                var L = +jsonVersions[version][index].Length;

                //get the orientation of the given wall
                if (isGable == false)
                {
                    switch (jsonVersions[version][index].Orientation) {
                        case "S": //if south
                            width = L;
                            break;
                        case "N": //or north
                            width = -L;
                            break;
                        case "W": //if west
                        case "E": //if east
                            width = 0;
                            break;
                        case "SW": //if southwest
                        case "NW": //or northwest
                            width = -(Math.sqrt((Math.pow(L, 2)) / 2));
                            break;
                        case "SE": //if southeast
                        case "NE": //or northeast
                            width = Math.sqrt((Math.pow(L, 2)) / 2);
                            break;
                    }
                }
                else{
                    switch (jsonVersions[version][index].Orientation)
                    {
                        case "S":
                        case "N":
                            width = 0;
                            break;
                        case "W":
                            width = L;
                            break;
                        case "E":
                            width = -L;
                            break;
                        case "SE":
                        case "NE":
                            width = -(Math.sqrt((Math.pow(L, 2)) / 2));
                            break;
                        case "SW":
                        case "NW":
                            width = Math.sqrt((Math.pow(L, 2)) / 2);
                            break;
                    }
                }

                tempWidth = +tempWidth + width //add the values to temp variable

                if (tempWidth > highestWidth) { //determine if the current temp projection is greater than the highest projection calculated
                    highestWidth = tempWidth; // reset the highest projection
                }
            }
            return highestWidth;
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

        /**
        This function was written in an attempt to bring all of the labels to front, by setting their z-index appropriately,
        but it didn't work out.
        */
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
            sunroomObjectChanged("0"); //when page loads, call sunroomObjectChanged function to set all the default values for room layout (-1 index = room layout)
            //$("#filler").style.zIndex = -1;
        });

    </script>
          <asp:SqlDataSource ID="sdsDBConnection" runat="server" ConnectionString="<%$ ConnectionStrings:sunspaceDealerDesktopConnectionString %>" SelectCommand="SELECT * FROM [users]"></asp:SqlDataSource>
</asp:Content>
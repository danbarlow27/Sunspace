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
    <%--<asp:Label ID="lblProjectSunroom" AssociatedControlID="radProjectSunroom" runat="server" Text="Mod 1"></asp:Label>--%>
    <div class="overlayContainer">
        <div class="overlayClose"><a href="#"><span>X</span> Close Mods Editor</a></div>
        
        <ul class="toggleOptions">
            
            <asp:PlaceHolder ID="ModOptions" runat="server"></asp:PlaceHolder>                    

            <%--<div class="toggleContent">--%>            <%--<ul>--%>                <%--<li>--%>                <%--<asp:RadioButton ID="radSunroomModel100" OnClick="newProjectCheckQuestion3()" GroupName="sunroomModel" runat="server" />--%>                <%--<asp:Label ID="lblSunroomModel100Radio" AssociatedControlID="radSunroomModel100" runat="server"></asp:Label>--%>           
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
    <button type="button" onclick="toggle()">Click Me!</button>
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
        function toggle() {
            $('.overlayContainer').slideToggle();
        }

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
        var gLayout, gWall, gLi, gMod, gWindow, gDoor, gScreen, gGlass, gVent;
        var scale = d3.scale.linear(); //used to fit the polygons optimally on the canvas
        var projection, antiProjection;
        //var arrLabels = new Array();

        /**
        This function gets called when the room layout dropdown is clicked.
        This function sets all the appropriate attributes 
        to the wall height and length variables
        */
        function drawRoomLayout() {

            drawRect(canvas, MAX_CANVAS_WIDTH, scale(10), -CENTRE_X, -CENTRE_Y, "existingWall", "#a8a8a8",1,"black","$(this).css('fill', 'cyan'); $('#<%= lblTitle.ClientID %>').text('Existing Wall'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', '#a8a8a8'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "alert('hello world')");   
            var text = "";

            if (antiProjection > projection) {
            
                var x = scale(getWidth() / 2);
                var y = -parseFloat(CENTRE_Y) + (scale(parseFloat(10)));

                gLayout = canvas.append("g").attr("transform", "translate("+x+","+y+")").attr("id", "layout");

                //alert(y);

                for (var i = listOfWalls.length - 1; i >= 0; i--) {

                    if (listOfWalls[i].Orientation.toLowerCase() === "e") {

                        for (var j = listOfWalls[i].LinearItems.length - 1; j >= 0; j--) {

                            var id = "layout"+listOfWalls[i].LinearItems[j].LinearIndex; //id to be given to the polygon
                            var title = listOfWalls[i].LinearItems[j].ItemType;
                            var length = listOfWalls[i].LinearItems[j].Length; //length of the linear item

                            switch (listOfWalls[i].LinearItems[j].ItemType.toLowerCase()) {
                                case "mod":
                                    
                                    var modularItem = listOfWalls[i].LinearItems[j].ModularItems[listOfWalls[i].LinearItems[j].ModularItems.length - 2];
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
                            drawRect(gLayout, scale(2), scale(length), -scale(1), 0, id, "white", 1, "black", "$(this).css('fill', 'cyan'); $('#<%= lblTitle.ClientID %>').text('"+text+"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "alert('hello world')");
                            gLayout = gLayout.append("g").attr("transform", "translate(0,"+scale(length)+")"); //bottom right coordinates of the linear item
                        }
                    }
                    
                    if (listOfWalls[i].Orientation.toLowerCase() === "w") {

                        for (var j = listOfWalls[i].LinearItems.length - 1; j >= 0; j--) {

                            var id = "layout"+listOfWalls[i].LinearItems[j].LinearIndex; //id to be given to the polygon
                            var title = listOfWalls[i].LinearItems[j].ItemType;
                            var length = listOfWalls[i].LinearItems[j].Length; //length of the linear item

                            switch (listOfWalls[i].LinearItems[j].ItemType.toLowerCase()) {
                                case "mod":
                                    var modularItem = listOfWalls[i].LinearItems[j].ModularItems[listOfWalls[i].LinearItems[j].ModularItems.length - 2];
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
                            drawRect(gLayout, scale(2), scale(length), -scale(1), -scale(length), id, "white", 1, "black", "$(this).css('fill', 'cyan'); $('#<%= lblTitle.ClientID %>').text('"+text+"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "alert('hello world')");
                            gLayout = gLayout.append("g").attr("transform", "translate(0,"+(-(scale(length)))+")"); //bottom right coordinates of the linear item
                        }
                    }
                    if (listOfWalls[i].Orientation.toLowerCase() === "s") {

                        for (var j = listOfWalls[i].LinearItems.length - 1; j >= 0; j--) {

                            var id = "layout"+listOfWalls[i].LinearItems[j].LinearIndex; //id to be given to the polygon
                            var title = listOfWalls[i].LinearItems[j].ItemType;
                            var length = listOfWalls[i].LinearItems[j].Length; //length of the linear item

                            switch (listOfWalls[i].LinearItems[j].ItemType.toLowerCase()) {
                                case "mod":
                                    var modularItem = listOfWalls[i].LinearItems[j].ModularItems[listOfWalls[i].LinearItems[j].ModularItems.length - 2];
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
                            drawRect(gLayout, scale(length), scale(2), (-(scale(length))), 0, id, "white", 1, "black", "$(this).css('fill', 'cyan'); $('#<%= lblTitle.ClientID %>').text('"+text+"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "alert('hello world')");
                            gLayout = gLayout.append("g").attr("transform", "translate("+(-(scale(length)))+",0)"); //bottom right coordinates of the linear item
                        }
                    }
                    else if (listOfWalls[i].Orientation.toLowerCase() === "n") {

                        for (var j = listOfWalls[i].LinearItems.length - 1; j >= 0; j--) {

                            var id = "layout"+listOfWalls[i].LinearItems[j].LinearIndex; //id to be given to the polygon
                            var title = listOfWalls[i].LinearItems[j].ItemType;
                            var length = listOfWalls[i].LinearItems[j].Length; //length of the linear item

                            switch (listOfWalls[i].LinearItems[j].ItemType.toLowerCase()) {
                                case "mod":
                                    var modularItem = listOfWalls[i].LinearItems[j].ModularItems[listOfWalls[i].LinearItems[j].ModularItems.length - 2];
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
                                    text = title;
                                    break;
                            }
                            drawRect(gLayout, scale(2), scale(length), 0, 0, id, "white", 1, "black", "$(this).css('fill', 'cyan'); $('#<%= lblTitle.ClientID %>').text('"+text+"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "alert('hello world')");
                            gLayout = gLayout.append("g").attr("transform", "translate(0,"+scale(length)+")"); //bottom right coordinates of the linear item
                        }
                    }
                }
            }
            else {

                var x = -scale(getWidth() / 2);
                var y = -parseFloat(CENTRE_Y) + (scale(parseFloat(10)));

                gLayout = canvas.append("g").attr("transform", "translate("+x+","+y+")").attr("id", "layout");

                for (var i = 0; i < listOfWalls.length; i++) {

                    if (listOfWalls[i].Orientation.toLowerCase() === "w") {

                        for (var j = 0; j < listOfWalls[i].LinearItems.length; j++) {

                            var id = "layout"+listOfWalls[i].LinearItems[j].LinearIndex; //id to be given to the polygon
                            var title = listOfWalls[i].LinearItems[j].ItemType;
                            var length = listOfWalls[i].LinearItems[j].Length; //length of the linear item

                            switch (listOfWalls[i].LinearItems[j].ItemType.toLowerCase()) {
                                case "mod":
                                    var modularItem = listOfWalls[i].LinearItems[j].ModularItems[listOfWalls[i].LinearItems[j].ModularItems.length - 2];
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
                            drawRect(gLayout, scale(2), scale(length), -scale(1), 0, id, "white", 1, "black", "$(this).css('fill', 'cyan'); $('#<%= lblTitle.ClientID %>').text('"+text+"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "alert('hello world')");
                            gLayout = gLayout.append("g").attr("transform", "translate(0,"+scale(length)+")"); //bottom right coordinates of the linear item
                        }
                    }
                    
                    if (listOfWalls[i].Orientation.toLowerCase() === "e") {

                        for (var j = 0; j < listOfWalls[i].LinearItems.length; j++) {

                            var id = "layout"+listOfWalls[i].LinearItems[j].LinearIndex; //id to be given to the polygon
                            var title = listOfWalls[i].LinearItems[j].ItemType;
                            var length = listOfWalls[i].LinearItems[j].Length; //length of the linear item

                            switch (listOfWalls[i].LinearItems[j].ItemType.toLowerCase()) {
                                case "mod":
                                    var modularItem = listOfWalls[i].LinearItems[j].ModularItems[listOfWalls[i].LinearItems[j].ModularItems.length - 2];
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
                            drawRect(gLayout, scale(2), scale(length), -scale(1), -scale(length), id, "white", 1, "black", "$(this).css('fill', 'cyan'); $('#<%= lblTitle.ClientID %>').text('"+text+"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "alert('hello world')");
                            gLayout = gLayout.append("g").attr("transform", "translate(0,"+(-(scale(length)))+")"); //bottom right coordinates of the linear item
                        }
                    }
                    if (listOfWalls[i].Orientation.toLowerCase() === "s") {

                        for (var j = 0; j < listOfWalls[i].LinearItems.length; j++) {

                            var id = "layout"+listOfWalls[i].LinearItems[j].LinearIndex; //id to be given to the polygon
                            var title = listOfWalls[i].LinearItems[j].ItemType;
                            var length = listOfWalls[i].LinearItems[j].Length; //length of the linear item

                            switch (listOfWalls[i].LinearItems[j].ItemType.toLowerCase()) {
                                case "mod":
                                    var modularItem = listOfWalls[i].LinearItems[j].ModularItems[listOfWalls[i].LinearItems[j].ModularItems.length - 2];
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
                            drawRect(gLayout, scale(length), scale(2), 0, 0, id, "white", 1, "black", "$(this).css('fill', 'cyan'); $('#<%= lblTitle.ClientID %>').text('"+text+"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "alert('hello world')");
                            gLayout = gLayout.append("g").attr("transform", "translate("+((scale(length)))+",0)"); //bottom right coordinates of the linear item
                        }
                    }
                    else if (listOfWalls[i].Orientation.toLowerCase() === "n") {

                        for (var j = 0; j < listOfWalls[i].LinearItems.length; j++) {

                            var id = "layout"+listOfWalls[i].LinearItems[j].LinearIndex; //id to be given to the polygon
                            var title = listOfWalls[i].LinearItems[j].ItemType;
                            var length = listOfWalls[i].LinearItems[j].Length; //length of the linear item

                            switch (listOfWalls[i].LinearItems[j].ItemType.toLowerCase()) {
                                case "mod":
                                    var modularItem = listOfWalls[i].LinearItems[j].ModularItems[listOfWalls[i].LinearItems[j].ModularItems.length - 2];
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
                                    text = title;
                                    break;
                            }
                            drawRect(gLayout, scale(length), scale(2), 0, 0, id, "white", 1, "black", "$(this).css('fill', 'cyan'); $('#<%= lblTitle.ClientID %>').text('"+text+"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "alert('hello world')");
                            gLayout = gLayout.append("g").attr("transform", "translate(0,"+scale(length)+")"); //bottom right coordinates of the linear item
                        }
                    }
                }            
            }
        }        

        /**
        This function gets called when the wall dropdown is clicked.
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

            drawPolygon(points, id, title, g, "white", 1, "black", "$(this).css('fill', 'cyan'); $('#<%= lblTitle.ClientID %>').text('Top & Bottom Receivers'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "alert('hello world')"); //draw the polygon to represent the wall with the given coordinates and id
            
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

                var id = "poly" + listOfWalls[wallIndex].LinearItems[i].LinearIndex; //id to be given to the polygon
                var title = listOfWalls[wallIndex].LinearItems[i].ItemType;
                var length = listOfWalls[wallIndex].LinearItems[i].Length; //length of the linear item
                var startHeight = listOfWalls[wallIndex].LinearItems[i].StartHeight - 0.5; //start height of the linear item
                var endHeight = listOfWalls[wallIndex].LinearItems[i].EndHeight - 0.5; //end height of the linear item


                switch(listOfWalls[wallIndex].LinearItems[i].ItemType.toLowerCase()) {
                    case "mod":
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
                        
                        drawPolygon(points, id, title, gLi, "white", 1, "black", "$(this).css('fill', 'cyan'); $('#<%= lblTitle.ClientID %>').text('"+listOfWalls[wallIndex].LinearItems[i].ModularItems[listOfWalls[wallIndex].LinearItems[i].ModularItems.length - 2].ItemType+ " " + listOfWalls[wallIndex].LinearItems[i].ItemType + "'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "alert('hello world')"); //draw the polygon to represent the wall with the given coordinates and id
                        
                        drawModularItems(modularItems, (parseFloat(x) + parseFloat(scale(1))), y, listOfWalls[wallIndex].LinearItems[i].LinearIndex, i);

                        x = parseFloat(x) + scale(parseFloat(length));

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

                        drawPolygon(points, id, title, gLi, "white", 1, "black", "$(this).css('fill', 'cyan'); $('#<%= lblTitle.ClientID %>').text('"+listOfWalls[wallIndex].LinearItems[i].ItemType+"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "alert('hello world')"); //draw the polygon to represent the wall with the given coordinates and id
                        //drawPolygon(points, "filler", title, gLi); //draw the polygon to represent the wall with the given coordinates and id

                        x = parseFloat(x) + scale(parseFloat(length));

                        gLi = gWall.append("g").attr("transform", "translate("+ x + "," + y + ")"); //bottom right coordinates of the linear item

                        break;
                }
                if (listOfWalls[wallIndex].LinearItems[i].ItemType === "filler") {
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

                switch(modularItems[i].ItemType.toLowerCase()) {
                    case "panel":
                    case "kneewall":
                        var rise = (leftHeight > rightHeight) ? (leftHeight - rightHeight) : (rightHeight - leftHeight);
                        var height = (leftHeight > rightHeight) ? "start" : (leftHeight === rightHeight) ? "equal" : "end";
                        var slope = rise / length;

                        var topFrame = (i === parseFloat(modularItems.length) - 1) ? 0 : 0.5;
                        var bottomFrame = (i === 0) ? 0 : 0.5;
                        var frame = 0.5;

                        var topLeft = { "x": scale(0), "y": (-1 * scale(leftHeight)) }; //top left coordinates
                        var topRight = { "x": scale(length), "y": (-1 * scale(rightHeight)) }; //top right coordinates
                        var bottomRight = { "x": scale(length), "y": scale(0) }; //bottom right coordinates
                        var bottomLeft = { "x": scale(0), "y": scale(0) }; //bottom left coordinates

                        var points = [topLeft, topRight, bottomRight, bottomLeft]; //put all the coordinates together in an array

                        drawPolygon(points, id, title, gMod, "white", 1, "black", "$(this).css('fill', 'cyan'); $('#<%= lblTitle.ClientID %>').text('"+ modularItems[i].WindowStyle + " " +modularItems[i].ItemType+"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "alert('hello world')"); //draw the polygon to represent the wall with the given coordinates and id

                        var ggMod = gMod.append("g");

                        var topLeft = { "x": scale(parseFloat(0) + frame), "y": (-1 * scale(parseFloat(leftHeight) - topFrame)) }; //top left coordinates
                        var topRight = { "x": scale(parseFloat(length) - frame), "y": (-1 * scale(parseFloat(rightHeight) - topFrame)) }; //top right coordinates
                        var bottomRight = { "x": scale(parseFloat(length) - frame), "y": scale(parseFloat(0) - bottomFrame) }; //bottom right coordinates
                        var bottomLeft = { "x": scale(parseFloat(0) + frame), "y": scale(parseFloat(0) - bottomFrame) }; //bottom left coordinates

                        var points = [topLeft, topRight, bottomRight, bottomLeft]; //put all the coordinates together in an array

                        drawPolygon(points, id, title, ggMod, "white", 1, "black", "$(this).css('fill', 'cyan'); $('#<%= lblTitle.ClientID %>').text('"+ modularItems[i].WindowStyle + " " +modularItems[i].ItemType+"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "alert('hello world')"); //draw the polygon to represent the wall with the given coordinates and id

                        if (i < (parseFloat(modularItems.length) - 1)) {

                            var pt1 = { "x": scale(parseFloat(0)), "y": (-1 * scale(parseFloat(endHeight))) }; //line left coordinates
                            var pt2 = { "x": scale(parseFloat(length)), "y": (-1 * scale(parseFloat(endHeight))) }; //line left coordinates

                            drawLine(pt1, pt2, gMod);
                        }

                        break;
                    case "transom":
                    case "window":
                        var id = "";// + listOfWalls[wallIndex].LinearItems[i].LinearIndex; //id to be given to the polygon
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

                        drawPolygon(outsidePoints, id, title, gMod, "white", 1, "black", "$(this).css('fill', 'cyan'); $('#<%= lblTitle.ClientID %>').text('"+ modularItems[i].WindowStyle + " " +modularItems[i].ItemType+"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "alert('hello world')"); //draw the polygon to represent the wall with the given coordinates and id
                        //drawPolygon(outsidePoints, id, title, gMod);//, "white", 1, "black");
                        
                        gMod = gMod.append("g");

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
                    case "door":

                        var id = "";// + listOfWalls[wallIndex].LinearItems[i].LinearIndex; //id to be given to the polygon
                        var title = modularItems[i].ItemType;
                        var length = modularItems[i].FLength; ; //length of the modular item
                        var leftHeight = modularItems[i].FStartHeight; //start height of the modular item
                        var rightHeight = modularItems[i].FEndHeight; //end height of the modular item
                        //var leftHeight = modularItems[i].LeftHeight; //left height of the modular item
                        //var rightHeight = modularItems[i].RightHeight; //right height of the modular item
                
                        //alert(listOfWalls[wallIndex].LinearItems[linearIndex - 1].ItemType);

                        var insideTopLeft = { "x": scale(parseFloat(0) + 1), "y": (-1 * scale(parseFloat(leftHeight) - 1)) }; //top left coordinates
                        var insideTopRight = { "x": scale(parseFloat(length) - 1), "y": (-1 * scale(parseFloat(rightHeight) - 1)) }; //top right coordinates
                        var insideBottomRight = { "x": scale(parseFloat(length) - 1), "y": scale(parseFloat(0)) }; //bottom right coordinates
                        var insideBottomLeft = { "x": scale(parseFloat(0) + 1), "y": scale(parseFloat(0)) }; //bottom left coordinates

                        var insidePoints = [insideTopLeft, insideTopRight, insideBottomRight, insideBottomLeft]; //put all the coordinates together in an array

                        drawDoorDetails(modularItems[i], insidePoints, modularItems.length, linearIndex, relativeLinearIndex);

                        if (i == 0) {

                            var pt1 = { "x": scale(parseFloat(0)), "y": (insideTopLeft.y - scale(1)) }; //line left coordinates
                            var pt2 = { "x": scale(parseFloat(length)), "y": (insideTopRight.y - scale(1)) }; //line left coordinates

                            //drawLine(pt1, pt2, gMod);
                        }
                        else if (i == parseFloat(modularItems.length) - 1) {

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

            drawPolygon(frame, "", "", gMod, "white", 1, "black", "$(this).css('fill', 'cyan'); $('#<%= lblTitle.ClientID %>').text('"+ window.WindowStyle + " " +window.ItemType+"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "alert('hello world')"); //draw the polygon to represent the wall with the given coordinates and id
            //drawPolygon(frame, "", "", gMod); //draw the polygon to represent the wall with the given coordinates and id
            gWindow = gMod.append("g").attr("transform", "translate("+ frame[3].x + "," + frame[3].y + ")");

            switch(window.WindowStyle.toLowerCase()) {
                case "double slider": case "doubleslider": //glass model 300
                case "single slider": case "singleslider": //glass model 400
                case "horizontal roller xx": case "horizontalrollerxx": //glass model 300
                case "horizontal roller": case "horizontalroller": case "horizontal 2 track": case "horizontal2track": case "horizontal two track": case "horizontaltwotrack": case "h2t": //H2T model 200

                    pt1 = { "x": scale((window.Width / 2) - 1), "y": scale(0) }; //line left coordinates
                    pt2 = { "x": scale((window.Width / 2) - 1), "y": (-1 * scale(window.LeftHeight - 2)) }; //line left coordinates

                    drawLine(pt1, pt2, gWindow, 2);

                    topLeft = { "x": (frame[0].x + scale(1)), "y": (frame[0].y + scale(3)) }; //top left coordinates
                    topRight = { "x": scale((window.Width / 2) - 3), "y": (frame[1].y + scale(3)) }; //top right coordinates
                    bottomRight = { "x": scale((window.Width / 2) - 3), "y": (frame[2].y - scale(1)) }; //bottom right coordinates
                    bottomLeft = { "x": (frame[3].x + scale(1)), "y": (frame[3].y - scale(1)) }; //bottom left coordinates

                    leftSlider = [topLeft, topRight, bottomRight, bottomLeft]; //put all the coordinates together in an array

                    drawPolygon(leftSlider, "", "", gWindow, "white", 1, "black", "$(this).css('fill', 'cyan'); $('#<%= lblTitle.ClientID %>').text('"+ window.WindowStyle + " " +window.ItemType+" Left Slider'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "alert('hello world')"); //draw the polygon to represent the wall with the given coordinates and id

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

                    drawPolygon(rightSlider, "", "", gWindow, "white", 1, "black", "$(this).css('fill', 'cyan'); $('#<%= lblTitle.ClientID %>').text('"+ window.WindowStyle + " " +window.ItemType+" Right Slider'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "alert('hello world')"); //draw the polygon to represent the wall with the given coordinates and id

                    if (window.SpreaderBar !== 0) {
                        gVent = gWindow.append("g");
                        pt1 = { "x": topLeft.x, "y": -scale(window.SpreaderBar) }; //line left coordinates
                        pt2 = { "x": topRight.x, "y": -scale(window.SpreaderBar) }; //line left coordinates
                        drawLine(pt1, pt2, gVent, 2);
                    }
                        
                    //drawGlassLines(leftSlider);
                    //drawGlassLines(rightSlider);

                    break;
                case "vertical 4 track": case "vertical4track": case "verticalfourtrack": case "vertical four track": case "v4t": //V4T
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

                        drawPolygon(slider, "", "", gVent, "white", 1, "black", "$(this).css('fill', 'cyan'); $('#<%= lblTitle.ClientID %>').text('"+ window.WindowStyle + " " +window.ItemType+" Vent "+ (parseFloat(i) + parseFloat(1)) +"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "alert('hello world')"); //draw the polygon to represent the wall with the given coordinates and id
                        //drawPolygon(slider, "", "", gVent); //draw the polygon to represent the wall with the given coordinates and id

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
                case "Solid Wall":
                    break;
            }        

            if (window.ScreenType.toLowerCase() != "no screen" && window.ScreenType != "noscreen" && window.ScreenType != "" && typeof window.ScreenType !== 'undefined') 
                drawScreen(gWindow, frame, window.ScreenType); //draw screen lines

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
        This function draws the details of a given door
        @param door - the door object
        @param frame - the door frame coordinates
        @param transomIndex - modular index of the transom
        @param linearIndex - index of the linear item which contains this door
        @param relativeLinearIndex - index of the linear item relative to the wall drawn
        */
        function drawDoorDetails(door, frame, transomIndex, linearIndex, relativeLinearIndex) {

            var pt1, pt2, topLeft, topRight, bottomLeft, bottomRight, leftSlider, rightSlider;

            var topLeft = { "x": parseFloat(frame[0].x) - scale(parseFloat(1)), "y": parseFloat(frame[0].y) - scale(parseFloat(1)) }; //top left coordinates
            var topRight = { "x": parseFloat(frame[1].x) + scale(parseFloat(1)), "y": parseFloat(frame[1].y) - scale(parseFloat(1)) }; //top right coordinates
            var bottomRight = { "x": parseFloat(frame[2].x) + scale(parseFloat(1)), "y": parseFloat(frame[2].y) }; //bottom right coordinates
            var bottomLeft = { "x": parseFloat(frame[3].x) - scale(parseFloat(1)), "y": parseFloat(frame[3].y) }; //bottom left coordinates
            
            var doorDoorFrame = [topLeft, topRight, bottomRight, bottomLeft]; //put all the coordinates together in an array

            drawPolygon(doorDoorFrame, "", "", gMod, "white", 1, "black", "$(this).css('fill', 'cyan'); $('#<%= lblTitle.ClientID %>').text('"+ door.DoorStyle + " " +door.DoorType+" "+ door.ItemType +"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "alert('hello world')"); //draw the polygon to represent the wall with the given coordinates and id
            drawPolygon(frame, "", "", gMod, "white", 1, "black", "$(this).css('fill', 'cyan'); $('#<%= lblTitle.ClientID %>').text('"+ door.DoorStyle + " " +door.DoorType+" "+ door.ItemType +"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "alert('hello world')"); //draw the polygon to represent the wall with the given coordinates and id
            
            gDoor = gMod.append("g").attr("transform", "translate("+ frame[3].x + "," + frame[3].y + ")");

            switch(door.DoorType.toLowerCase()) {
                
                case "cabana": case "cabana door": case "cabanadoor":
                    var topLeft = { "x": parseFloat(frame[0].x) + scale(parseFloat(3.5)), "y": parseFloat(frame[0].y) + scale(parseFloat(2.5)) }; //top left coordinates
                    var topRight = { "x": parseFloat(frame[1].x) - scale(parseFloat(3.5)), "y": parseFloat(frame[1].y) + scale(parseFloat(2.5)) }; //top right coordinates
                    var bottomRight = { "x": parseFloat(frame[2].x) - scale(parseFloat(3.5)), "y": parseFloat(frame[2].y) - scale(parseFloat(door.Kickplate) + parseFloat(0.5)) }; //bottom right coordinates
                    var bottomLeft = { "x": parseFloat(frame[3].x) + scale(parseFloat(3.5)), "y": parseFloat(frame[3].y) - scale(parseFloat(door.Kickplate) + parseFloat(0.5)) }; //bottom left coordinates

                    var doorWindowFrame = [topLeft, topRight, bottomRight, bottomLeft]; //put all the coordinates together in an array

                    gMod = gMod.append("g");
                    drawPolygon(doorWindowFrame, "", "", gMod, "white", 1, "black", "$(this).css('fill', 'cyan'); $('#<%= lblTitle.ClientID %>').text('"+ door.DoorStyle + " " +door.DoorType+" "+ door.ItemType +"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "alert('hello world')"); //draw the polygon to represent the wall with the given coordinates and id

                    var r = scale(1.25);
                    var cx = (door.Hinge === "R") ? parseFloat(frame[0].x) + scale(parseFloat(1.75)) : parseFloat(frame[1].x) - scale(parseFloat(1.75));
                    var cy = -scale(door.FEndHeight / 2);

                    var ggMod = gMod.append("g");
                    
                    drawCircle(ggMod, r, cx, cy, "", "yellow" /*hard coded for now*/, 1, "black", "$(this).css('fill', 'cyan'); $('#<%= lblTitle.ClientID %>').text('"+ door.HardwareType + " Hardware'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'yellow'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "alert('hello world')"); //draw the polygon to represent the wall with the given coordinates and id

                    //////////////// DOOR WINDOW DETAILS

                    drawDoorWindowDetails(gMod, doorWindowFrame, door);

                    //////////////END DOOR WINDOW DETAILS
                    
                    if (door.ScreenType.toLowerCase() != "no screen" && door.ScreenType != "noscreen" && door.ScreenType != "" && typeof door.ScreenType !== 'undefined') {
                     
                        topLeft = { "x": topLeft.x + parseFloat(scale(1)) , "y": topLeft.y - parseFloat(scale(1)) }; //top left coordinates
                        topRight = { "x": topRight.x + parseFloat(scale(1)) , "y": topRight.y - parseFloat(scale(1)) }; //top right coordinates
                        bottomRight = { "x": bottomLeft.x + parseFloat(scale(1)) , "y": bottomLeft.y }; //bottom right coordinates
                        bottomLeft = { "x": bottomRight.x + parseFloat(scale(1)) , "y": bottomRight.y }; //bottom left coordinates

                        doorWindowFrame = [topLeft, topRight, bottomRight, bottomLeft]; //put all the coordinates together in an array

                        drawScreen(gMod, doorWindowFrame, door.ScreenType, true);
                    }
                    break;
                case "french": case "frenchdoor": case "french door":
                    //////////////LEFT DOOR
                    var topLeft = { "x": parseFloat(frame[0].x), "y": parseFloat(frame[0].y) }; //top left coordinates
                    var topRight = { "x": parseFloat(frame[1].x) - scale(parseFloat(door.FLength/2)) - scale(parseFloat(0/*.25*/)), "y": parseFloat(frame[1].y) }; //top right coordinates
                    var bottomRight = { "x": parseFloat(frame[2].x) - scale(parseFloat(door.FLength/2)) - scale(parseFloat(0/*.25*/)), "y": parseFloat(frame[2].y) }; //bottom right coordinates
                    var bottomLeft = { "x": parseFloat(frame[3].x), "y": parseFloat(frame[3].y) }; //bottom left coordinates

                    var doorWindowFrame = [topLeft, topRight, bottomRight, bottomLeft]; //put all the coordinates together in an array

                    var gDoorFrame = gMod.append("g");
                    drawPolygon(doorWindowFrame, "", "", gDoorFrame, "white", 1, "black", "$(this).css('fill', 'cyan'); $('#<%= lblTitle.ClientID %>').text('"+ door.DoorStyle + " " +door.DoorType+" "+ door.ItemType +"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "alert('hello world')"); //draw the polygon to represent the wall with the given coordinates and id
                    
                    ///////////////END LEFT DOOR

                    /////////////////LEFT DOOR WINDOW

                    var topLeft1 = { "x": parseFloat(frame[0].x) + scale(parseFloat(3.5)), "y": parseFloat(frame[0].y) + scale(parseFloat(2.5)) }; //top left coordinates
                    var topRight1 = { "x": parseFloat(frame[1].x) - scale(parseFloat(3.5)) - scale(parseFloat(door.FLength/2)) - scale(parseFloat(0.25)), "y": parseFloat(frame[1].y) + scale(parseFloat(2.5)) }; //top right coordinates
                    var bottomRight1 = { "x": parseFloat(frame[2].x) - scale(parseFloat(3.5)) - scale(parseFloat(door.FLength/2)) - scale(parseFloat(0.25)), "y": parseFloat(frame[2].y) - scale(parseFloat(door.Kickplate) + parseFloat(0.5)) }; //bottom right coordinates
                    var bottomLeft1 = { "x": parseFloat(frame[3].x) + scale(parseFloat(3.5)), "y": parseFloat(frame[3].y) - scale(parseFloat(door.Kickplate) + parseFloat(0.5)) }; //bottom left coordinates

                    var doorWindowFrame1 = [topLeft1, topRight1, bottomRight1, bottomLeft1]; //put all the coordinates together in an array

                    var gDoorWindow = gMod.append("g");
                    drawPolygon(doorWindowFrame1, "", "", gDoorWindow, "white", 1, "black", "$(this).css('fill', 'cyan'); $('#<%= lblTitle.ClientID %>').text('"+ door.DoorStyle + " " +door.DoorType+" "+ door.ItemType +"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "alert('hello world')"); //draw the polygon to represent the wall with the given coordinates and id

                    ///////////END LEFT DOOR WINDOW

                    //////////////LEFT DOORKNOB

                    var r = scale(1.25);
                    var cx = parseFloat(frame[1].x) - scale(parseFloat(1.75)) - scale(parseFloat(door.FLength/2)) - scale(parseFloat(0.25));
                    var cy = -scale(door.FEndHeight / 2);

                    var gDoorknob = gMod.append("g");
                    
                    drawCircle(gDoorknob, r, cx, cy, "", "yellow" /*hard coded for now*/, 1, "black", "$(this).css('fill', 'cyan'); $('#<%= lblTitle.ClientID %>').text('"+ door.HardwareType + " Hardware'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'yellow'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "alert('hello world')"); //draw the polygon to represent the wall with the given coordinates and id

                    /////////////END LEFT DOORKNOB

                    //////////////// DOOR WINDOW DETAILS

                    //drawDoorWindowDetails();

                    //////////////END DOOR WINDOW DETAILS
                    
                    ////////////////////LEFT DOOR SCREEN

                    if (door.ScreenType.toLowerCase() != "no screen" && door.ScreenType != "noscreen" && door.ScreenType != "" && typeof door.ScreenType !== 'undefined') {
                     
                        topLeft1 = { "x": topLeft1.x + parseFloat(scale(1)) , "y": topLeft1.y - parseFloat(scale(1)) }; //top left coordinates
                        topRight1 = { "x": topRight1.x + parseFloat(scale(1)) , "y": topRight1.y - parseFloat(scale(1)) }; //top right coordinates
                        bottomRight1 = { "x": bottomLeft1.x + parseFloat(scale(1)) , "y": bottomLeft1.y }; //bottom right coordinates
                        bottomLeft1 = { "x": bottomRight1.x + parseFloat(scale(1)) , "y": bottomRight1.y }; //bottom left coordinates

                        doorWindowFrame1 = [topLeft1, topRight1, bottomRight1, bottomLeft1]; //put all the coordinates together in an array

                        drawScreen(gMod, doorWindowFrame1, door.ScreenType, true);
                    }

                    //////////////////END LEFT DOOR SCREEN

                    //////////////RIGHT DOOR
                    var topLeft = { "x": parseFloat(frame[0].x) + scale(parseFloat(door.FLength/2)), "y": parseFloat(frame[0].y) }; //top left coordinates
                    var topRight = { "x": parseFloat(frame[1].x), "y": parseFloat(frame[1].y) }; //top right coordinates
                    var bottomRight = { "x": parseFloat(frame[2].x), "y": parseFloat(frame[2].y) }; //bottom right coordinates
                    var bottomLeft = { "x": parseFloat(frame[3].x) + scale(parseFloat(door.FLength/2)), "y": parseFloat(frame[3].y) }; //bottom left coordinates

                    var doorWindowFrame = [topLeft, topRight, bottomRight, bottomLeft]; //put all the coordinates together in an array

                    gggMod = gDoorFrame.append("g");
                    drawPolygon(doorWindowFrame, "", "", gggMod, "white", 1, "black", "$(this).css('fill', 'cyan'); $('#<%= lblTitle.ClientID %>').text('"+ door.DoorStyle + " " +door.DoorType+" "+ door.ItemType +"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "alert('hello world')"); //draw the polygon to represent the wall with the given coordinates and id
                    
                    ///////////////END RIGHT DOOR
                    
                    /////////////////RIGHT DOOR WINDOW

                    var topLeft1 = { "x": parseFloat(frame[0].x) + scale(parseFloat(3.5)) + scale(parseFloat(door.FLength/2)), "y": parseFloat(frame[0].y) + scale(parseFloat(2.5)) }; //top left coordinates
                    var topRight1 = { "x": parseFloat(frame[1].x) - scale(parseFloat(3.5)) - scale(parseFloat(0.25)), "y": parseFloat(frame[1].y) + scale(parseFloat(2.5)) }; //top right coordinates
                    var bottomRight1 = { "x": parseFloat(frame[2].x) - scale(parseFloat(3.5)) - scale(parseFloat(0.25)), "y": parseFloat(frame[2].y) - scale(parseFloat(door.Kickplate) + parseFloat(0.5)) }; //bottom right coordinates
                    var bottomLeft1 = { "x": parseFloat(frame[3].x) + scale(parseFloat(3.5)) + scale(parseFloat(door.FLength/2)), "y": parseFloat(frame[3].y) - scale(parseFloat(door.Kickplate) + parseFloat(0.5)) }; //bottom left coordinates

                    var doorWindowFrame1 = [topLeft1, topRight1, bottomRight1, bottomLeft1]; //put all the coordinates together in an array

                    ggMod = gDoorWindow.append("g");
                    drawPolygon(doorWindowFrame1, "", "", ggMod, "white", 1, "black", "$(this).css('fill', 'cyan'); $('#<%= lblTitle.ClientID%>').text('"+ door.DoorStyle + " " +door.DoorType+" "+ door.ItemType +"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "alert('hello world')"); //draw the polygon to represent the wall with the given coordinates and id

                    ///////////END RIGHT DOOR WINDOW

                    /////////////RIGHT DOORKNOB

                    var r = scale(1.25);
                    var cx = parseFloat(frame[0].x) + scale(parseFloat(1.75)) + scale(parseFloat(door.FLength/2)) - scale(parseFloat(0.25));
                    var cy = -scale(door.FEndHeight / 2);

                    drawCircle(gDoorknob, r, cx, cy, "", "yellow" /*hard coded for now*/, 1, "black", "$(this).css('fill', 'cyan'); $('#<%= lblTitle.ClientID %>').text('"+ door.HardwareType + " Hardware'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'yellow'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "alert('hello world')"); //draw the polygon to represent the wall with the given coordinates and id
                
                    ////////////END RIGHT DOORKNOB

                    //////////////// DOOR WINDOW DETAILS

                    //drawDoorWindowDetails();

                    //////////////END DOOR WINDOW DETAILS
                    
                    /////////////////RIGHT DOOR SCREEN

                    if (door.ScreenType.toLowerCase() != "no screen" && door.ScreenType != "noscreen" && door.ScreenType != "" && typeof door.ScreenType !== 'undefined') {
                     
                        topLeft1 = { "x": topLeft1.x + parseFloat(scale(1)) , "y": topLeft1.y - parseFloat(scale(1)) }; //top left coordinates
                        topRight1 = { "x": topRight1.x + parseFloat(scale(1)) , "y": topRight1.y - parseFloat(scale(1)) }; //top right coordinates
                        bottomRight1 = { "x": bottomLeft1.x + parseFloat(scale(1)) , "y": bottomLeft1.y }; //bottom right coordinates
                        bottomLeft1 = { "x": bottomRight1.x + parseFloat(scale(1)) , "y": bottomRight1.y }; //bottom left coordinates

                        doorWindowFrame1 = [topLeft1, topRight1, bottomRight1, bottomLeft1]; //put all the coordinates together in an array

                        drawScreen(gMod, doorWindowFrame1, door.ScreenType, true);
                    }

                    /////////////END RIGHT DOOR SCREEN

                    break;
            }
        }

        /**
        This function draws the details of the window within a given door
        @param g - the <g> element on which to append the line
        @param frame - the window frame coordinates
        @param door - the door object to retrieve the details out of
        */
        function drawDoorWindowDetails(g, frame, door) {
 
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
                        pt2 = { "x": i, "y":  -(frame[1].y + 1) - scale(20) }; //line left coordinates
                        drawLine(pt1, pt2, gDoorWindowDetails, 1, "black", 1);//, "$(this).css('fill', 'cyan'); $('#<%= lblTitle.ClientID %>').text('"+ type +"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "alert('hello world')");
                    }

                    //horizontal lines
                    for (var i = parseFloat(frame[1].y) + scale(parseFloat(50)) - scale(parseFloat(door.Kickplate)); i < frame[2].y + scale(1) + parseFloat(0.5) + scale(parseFloat(20)); i += (parseFloat(yIncrement) + parseFloat(2))) {
                        pt1 = { "x": (frame[0].x - scale(4) - 1), "y": -i }; //line left coordinates
                        pt2 = { "x": (frame[1].x - scale(4) - 1), "y": -i }; //line left coordinates
                        drawLine(pt1, pt2, gDoorWindowDetails, 1, "black", 1);//, "$(this).css('fill', 'cyan'); $('#<%= lblTitle.ClientID %>').text('"+ type +"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "alert('hello world')");
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

                    gVent = gDoorWindowDetails.append("g");

                    for (var i = 0; i < window.NumVents; i++) {
                        ventHeight = scale(window.VentHeights[i] / 4); ///4 because the vent heights are messed up
                        
                        var yBottom = (i === (window.NumVents - 1)) ? -(ventHeight - scale(1)) : -(ventHeight - scale(0.5));

                        var topLeft = { "x": scale(1), "y": scale(-1) }; //top left coordinates
                        var topRight = { "x": scale(window.Width - 3), "y": scale(-1) }; //top right coordinates
                        var bottomRight = { "x": scale(window.Width - 3), "y": yBottom }; //bottom right coordinates
                        var bottomLeft = { "x": (scale(1)), "y": yBottom }; //bottom left coordinates

                        var slider = [topLeft, topRight, bottomRight, bottomLeft]; //put all the coordinates together in an array

                        drawPolygon(slider, "", "", gVent, "white", 1, "black", "$(this).css('fill', 'cyan'); $('#<%= lblTitle.ClientID %>').text('"+ window.WindowStyle + " " +window.ItemType+" Vent "+ (parseFloat(i) + parseFloat(1)) +"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "alert('hello world')"); //draw the polygon to represent the wall with the given coordinates and id
                        
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
                    break;
                case "half lite venting": case "halfliteventing": //model 400 cabana
                    break;
                case "half lite with mini blinds": case "halflitewithminiblinds": //model 400 cabana
                    break;
                case "full view with mini blinds": case "fullviewwithminiblinds": //model 400 cabana
                    break;
            }
        }

        /**
        This function draws the screen on a given window
        @param g - the <g> element on which to append the line
        @param frame - the window frame coordinates
        @param type - screen type
        @param door - if its a door window (hot fix)
        */
        function drawScreen(g, frame, type, door) {

            door = typeof door !== 'undefined' ? door : false;

            var pt1, pt2;
            gScreen = g.append("g");

            var yBottom = (door) ? scale(20) : 0;

            //Draws vertical lines of the screen onto the window
            for (var i = frame[0].x; i < frame[1].x - scale(1); i += scale(0.5)) {
                pt1 = { "x": i, "y": -1 - yBottom }; //line left coordinates
                pt2 = { "x": i, "y":  (frame[1].y + scale(1) + 1) }; //line left coordinates
                drawLine(pt1, pt2, gScreen, 1, "black", 0.05, "$(this).css('fill', 'cyan'); $('#<%= lblTitle.ClientID %>').text('"+ type +"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "alert('hello world')");
            }

            //Draws horizontal lines of the screen onto the window
            for (var i = frame[1].y + scale(2); i < frame[2].y + scale(1); i += scale(0.5)) {
                pt1 = { "x": (frame[0].x - scale(1) + 1), "y": i }; //line left coordinates
                pt2 = { "x": (frame[1].x - scale(1) - 1), "y": i }; //line left coordinates
                drawLine(pt1, pt2, gScreen, 1, "black", 0.05, "$(this).css('fill', 'cyan'); $('#<%= lblTitle.ClientID %>').text('"+ type +"'); $('#<%= lblTitle.ClientID %>').css('visibility','visible');","$(this).css('fill', 'white'); $('#<%= lblTitle.ClientID %>').css('visibility','hidden');", "alert('hello world')");
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
            
            //hide all the li tags
            for (var i = 0; i < listOfWalls[listOfWalls.length - 1].LastItemIndex; i++) 
                $("#li"+i).css("display", "none");
            
            if (value != "-1") {

                if ($("#existingWall"))
                    d3.selectAll("#existingWall").remove(); //remove existing walls

                if($("#layout"))
                    d3.selectAll("#layout").remove(); //remove room layout drawing
                

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
            else {
                ///////////////////////////////////////////////////////////////////////////////
                //hard coding set back because its not being stored/retrieved from the database
                listOfWalls[0].SetBack = listOfWalls[0].Length; 
                listOfWalls[2].SetBack = -listOfWalls[2].Length;
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
            for (var i = 0; i < listOfWalls.length; i++) { //run through all the setbacks
                tempProjection = +tempProjection + +listOfWalls[i].SetBack; //add the values to temp variable
                if (tempProjection > highestProjection) { //determine if the current temp projection is greater than the highest projection calculated
                    highestProjection = tempProjection; // reset the highest projection
                    projection = highestProjection;
                }
                if (listOfWalls[i].SetBack < 0) {
                    tempAntiProjection = tempAntiProjection + listOfWalls[i].SetBack * -1;
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
            for (var index = 0; index < listOfWalls.length; index++) { //run through all the setbacks
                if (listOfWalls[index].WallType === "G")
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
                var L = +listOfWalls[index].Length;

                //get the orientation of the given wall
                if (isGable == false)
                {
                    switch (listOfWalls[index].Orientation) {
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
                    switch (listOfWalls[index].Orientation)
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
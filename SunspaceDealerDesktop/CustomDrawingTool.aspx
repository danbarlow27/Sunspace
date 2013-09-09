<%@Page Title="Custom Drawing Tool" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomDrawingTool.aspx.cs" Inherits="SunspaceDealerDesktop.CustomDrawingTool" EnableViewStateMac="false"%>
<%--<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
               
            </hgroup>
            
        </div> 
    </section>
</asp:Content>--%>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <!--Div tag setup:
        |SECTION 1|SECTION 2|SECTION 3|
        |         |         |         |
        |BUTTONS  |GRID     |ERROR    |
        |ORDERED  |         |MESSAGES |
        |LIST     |         |         |
        
        This section contains div tags for buttons, grid, and error messages.
        
        Layout to consider: 

        |SECTION 1                  |
        |BUTTONS - ORDERED LIST     |
        -----------------------------
        |SECTION 2|SECTION 3        |
        |ERROR    |GRID             |
        |MESSAGES |                 |
        -->    

        <!--Div tag to hold canvas/grid buttons-->
        <div id="buttons" style="width:20%; text-align:center; float:left; margin-right: 20px;">
            <ul>
                <!--Checkbox for standalone or not-->
                <li><asp:CheckBox id="chkStandalone" runat="server" onclick="standaloneToggle()" />
                    <asp:Label ID="lblStandaloneCheck" AssociatedControlID="chkStandalone" runat="server"></asp:Label>
                    <asp:Label ID="lblStandalone" AssociatedControlID ="chkStandalone" Text="Standalone Sunroom" runat="server"></asp:Label>
                </li>

                <!--Undo button to undo the last line drawn-->
               <%-- <li><input id="btnUndo" class="btnDisabled" type="button" value ="Undo" onclick="undo(true)" style="width:150px" disabled/></li>--%>

                <!--Redo button to redo the last line drawn-->
                <!-- <li><input id="btnRedo" class="btnSubmit" type="button" value ="Redo" onclick="redo()" style="width:150px"/></li> -->

                <!--Clear Canvas button which clears the current canvas-->
                <li><input id="btnClear" class="btnDisabled" type="button" value ="Clear Canvas" onclick ="clearCanvas()" style="width:150px" disabled/></li>

                <!--Done button which ends the current operations (i.e. Done Existing Walls, Done Proposed Walls, Done Drawing)-->
                <li><input id="btnDone" class="btnSubmit" type="button" value ="" onclick="btnDoneOnClick()" style="width:150px"/></li>

                <li><hr /></li>

                <!--Button to send line information to C#-->
                <li><asp:Button ID="btnSubmitDrawing" CSSClass="btnDisabled" runat="server" Text="Submit Drawing" OnClick="Button1_Click1" style="width:150px"/></li>

            </ul>
        </div>

        <!--Div tag to hold the error log-->
        <div style="width:20%; float:right;" >
            <textarea id="drawingLog" rows="31" cols="30" style="resize:none; border:0px;" readonly></textarea>
        </div>

        <!--Div tag to hold the canvas/grid-->
        <div style="max-width:500px; max-height:500px; min-width:100px; min-height:100px; margin: 0 auto;" id="mySunroom"></div>
        
        

    <!--Hidden input field to hold concatenated string of line information to be passed to C#-->
    <input type="hidden" id="hiddenVar" runat="server" />
    <!--ASP button for testing, to be removed-->
    <script src="Scripts/Validation.js"></script>
    <script>

        var standAlone;
        /**************** CONSTANTS ****************/

        //Wall type enumeration(enumeration)
        var WALL_TYPE = {
            GABLE: "G",     //Gable Post (or wall)
            EXISTING: "E",  //Existing wall
            PROPOSED: "P"   //Proposed wall
        }

        //Wall facing object(enumeration)
        var WALL_FACING = {
            SOUTH: 0,       //South value 0
            SOUTH_WEST: 1,  //South West value 1
            WEST: 2,        //West value 2
            NORTH_WEST: 3,  //North West value 3
            NORTH: 4,       //North value 4
            NORTH_EAST: 5,  //North East value 5
            EAST: 6,        //East value 6
            SOUTH_EAST: 7   //South East value 7
        }

        var WALL_ORIENTATION = {
            SOUTH: "S",      
            SOUTH_WEST: "SW", 
            WEST: "W",        
            NORTH_WEST: "NW",  
            NORTH: "N",       
            NORTH_EAST: "NE", 
            EAST: "E",        
            SOUTH_EAST: "SE"
        }

        var MIN_NUMBER_OF_WALLS = 3;            //minimum number of walls that makes up a complete sunroom
        var GRID_PADDING = 25;                  //size of the squares in the grid        
        var CELL_PADDING = GRID_PADDING / 2;    //cell padding is half less than the grid padding
        var MAX_CANVAS_WIDTH = 500;             //max width of canvas
        var MAX_CANVAS_HEIGHT = 500;            //max height of canvas


        /**************** VARIABLES ****************/

        /**** DOM VARIABLES ****/
        /* CREATE CANVAS */
        var canvas = d3.select("#mySunroom")            //Select the div tag with id "mySunroom"
                    .append("svg")                      //Add an svg tag to the selected div tag
                    .attr("width", MAX_CANVAS_WIDTH)    //Set the width of the canvas/grid to MAX_CANVAS_WIDTH
                    .attr("height", MAX_CANVAS_HEIGHT); //Set the height of the canvas/grid to MAX_CANVAS_HEIGHT        

        var log = document.getElementById("drawingLog");        //variable to hold textarea tag
        var svgGrid = document.getElementById("mySunroom");     //create the svg grid on the canvas
        var doneButton = document.getElementById("btnDone"); //store the "Done" button in a variable


        /**** ARRAY VARIABLES ****/
        //var removed = new Array();      //an array of removed lines, for use in "redo" function
        var coordList = new Array();    //an array of lines drawn


        /**** FUNCTIONALITY VARIABLES ****/
        var x1, y1, x2, y2;             //Coordinates of a given line (start/end coordinates)
        var startNewWall = true;        //Variable to determine new set of walls being drawn
        var validateFirstWall = false;  //Used to validate first walls, also after E


        /**** WIZARD VARIABLES ****/
        var wallType;  //Type of wall currently being drawn, to be determined by wizard
        var standAlone = false;             //Variable to be set by wizard values
        var gable = true;                  //Variable to hold whether its a gable or not, to come from wizard

        /**** EVENTS ON LOAD ****/
        //window.onload = setButtonValue(); //load the default text on the "Done" button depending on whether the user chose standAlone or not


        /**** jQuery FUNCTIONS ****/

        //When the DOM is loaded and ready
        $(document).ready(function () {
            drawGrid(); //Draws the initial grid
            //Set initial text in log section
            document.getElementById("MainContent_btnSubmitDrawing").disabled = true;

            //check if user selected a dealer gable or not
            if ('<%= gableStyle %>' == "Dealer Gable")
                gable = true;
            else
                gable = false;

            if (gable == true)
                wallType = WALL_TYPE.GABLE;
            else
                wallType = WALL_TYPE.EXISTING;

            setButtonValue();

            if (gable)
                log.innerHTML += "Please draw a gable post.\n\nPress 'E' to end a line.\n\n";
            else
                log.innerHTML += "Please draw an existing wall.\n\nPress 'E' to end a line.\n\n";
        });

        //On keypress "e" start new line on the grid
        $(document).on('keypress', function (e) { if (e.which === 101) { startNewWall = true; } });


        /********************************************* JAVASCRIPT FUNCTIONS *********************************************/

        //on click event of "Done" button
        function btnDoneOnClick() {

            if (doneButton.value === "Done Gable Post") {
                if (coordList.length > 0 && coordList[coordList.length - 1].id === WALL_TYPE.GABLE)
                {
                    if ($('#<%=chkStandalone.ClientID%>').is(':checked'))
                    {
                        doneButton.value = "Done Proposed Walls";   //change the name (value) of the button
                        wallType = WALL_TYPE.PROPOSED;              //change wall type                    
                        startNewWall = true;                        //reset click count
                        log.innerHTML = "Please draw your proposed wall. \nPress \"E\" to end a line.";
                    }
                    else
                    {
                        doneButton.value = "Done Existing Walls";
                        wallType = WALL_TYPE.EXISTING;
                        startNewWall = true;
                        log.innerHTML = "Please draw your existing wall. \nPress \"E\" to end a line.";
                    }
                }
                else {
                    //show error message
                    log.innerHTML = "No gable wall has been drawn, please draw one\n\n";
                }
            }
            //if user wants to finish drawing existing walls
            else if (doneButton.value === "Done Existing Walls") {
                //if there are walls drawn and first wall is wall type "E"
                if (coordList.length > 0 && coordList[coordList.length-1].id === WALL_TYPE.EXISTING) {
                    doneButton.value = "Done Proposed Walls";   //change the name (value) of the button
                    wallType = WALL_TYPE.PROPOSED;              //change wall type                    
                    startNewWall = true;                        //reset click count
                    log.innerHTML = "Please draw your proposed wall. \nPress \"E\" to end a line.";
                }
                    //if walltype is not "E", means they have not drawn any existing walls
                else {
                    //show error message
                    log.innerHTML = "No existing walls drawn, please draw at least one\n\n";
                }
            }
                //if user wants to finish drawing external (i.e. proposed) walls
            else if (doneButton.value === "Done Proposed Walls") {

                //if its a valid sunroom
                if (gable == false) {
                    console.log('Calling Completed');
                    if (sunroomCompleted()) {
                        doneButton.value = "Done Drawing";  //change the name (value) of the button                    
                        wallType = WALL_TYPE.PROPOSED;      //change wall type                    
                        startNewWall = true;                //reset click count
                        log.innerHTML = "If you are done drawing, please click \"Done Drawing\". \n\nIf you are ready to proceed to the next page click \"Submit Drawing\"";
                    }
                }
                else {
                    /***********************************
                    VALIDATION FOR GABLE HERE
                    ***********************************/
                    if (validateGable()) {
                        doneButton.value = "Done Drawing";  //change the name (value) of the button
                        wallType = WALL_TYPE.PROPOSED;      //change wall type                    
                        startNewWall = true;                //reset click count
                        log.innerHTML = "If you are done drawing, please click \"Done Drawing\". \n\nIf you are ready to proceed to the next page click \"Submit Drawing\"";
                    }
                }
            }
                //If logic for passing values to C# (server-side)
            else if (doneButton.value === "Done Drawing") {

                $('#MainContent_btnSubmitDrawing').removeClass('btnDisabled');
                $('#MainContent_btnSubmitDrawing').addClass('btnSubmit');
                document.getElementById("MainContent_btnSubmitDrawing").disabled = false;

                $('#btnDone').removeClass('btnSubmit');
                $('#btnDone').addClass('btnDisabled');
                document.getElementById("btnDone").disabled = true;

                var lineInfo = "";  //Variable to hold array/line information to be passed to C# (server-side)

                //For loop to concatenate a string with array/line information
                for (var i = 0; i < coordList.length; i++) {
                    lineInfo += coordList[i].x1 + ",";          //First X coordinate of line index i
                    lineInfo += coordList[i].x2 + ",";          //First Y coordinate of line index i
                    lineInfo += coordList[i].y1 + ",";          //Second X coordinate of line index i
                    lineInfo += coordList[i].y2 + ",";          //Second Y coordinate of line index i
                    lineInfo += coordList[i].id + ",";          //ID of line index i
                    lineInfo += coordList[i].orientation + "/"; //Orientation of line index i
                }
                //Passing lineInfo (concatenated string) to hidden field to be pulled in C# (server-side)
                document.getElementById("MainContent_hiddenVar").value = lineInfo;
            }

        }

        /**
        *clearCanvas
        *Clear canvas function; clears canvas of all lines, resets arrays to null
        */
        function clearCanvas() {
            d3.selectAll("#G").remove(); //remove existing walls
            d3.selectAll("#E").remove(); //remove existing walls
            d3.selectAll("#P").remove(); //remove proposed walls
            startNewWall = true;         //let the user begin another wall anywhere on the grid
            coordList = new Array();     //clear the list of lines
            //removed = new Array();       //clear the list of removed lines
            if (gable) {
                wallType = WALL_TYPE.GABLE;
                log.innerHTML = "Please draw a gable post.\n\nPress 'E' to end a line.\n\n";
            }
            else {
                wallType = (!standAlone) ? WALL_TYPE.EXISTING : WALL_TYPE.PROPOSED; //reset the wall type to default
                log.innerHTML += "Please draw an existing wall.\n\nPress 'E' to end a line.\n\n";
            }
            setButtonValue();            //set button value
            //document.getElementById("btnUndo").disabled = true;
            document.getElementById("btnClear").disabled = true;
            //$('#btnUndo').addClass('btnDisabled');
            //$('#btnUndo').removeClass('btnSubmit');
            $('#btnClear').addClass('btnDisabled');
            $('#btnClear').removeClass('btnSubmit');

            $('#btnDone').removeClass('btnDisabled');
            $('#btnDone').addClass('btnSubmit');
            document.getElementById("btnDone").disabled = false;

            $('#MainContent_btnSubmitDrawing').removeClass('btnSubmit');
            $('#MainContent_btnSubmitDrawing').addClass('btnDisabled');
            document.getElementById("MainContent_btnSubmitDrawing").disabled = true;
        }

        /**
        *setButtonValue
        *Set button value function; sets the text inside btnDone
        */
        function setButtonValue() {
            if (gable == false) {
                doneButton.value = (wallType === WALL_TYPE.EXISTING) ? "Done Existing Walls" :
                    (wallType === WALL_TYPE.PROPOSED) ? "Done Proposed Walls" : "Done Drawing";
            }
            else {
                if (wallType == WALL_TYPE.GABLE)
                    doneButton.value = "Done Gable Post";
                else if (wallType == WALL_TYPE.EXISTING)
                    doneButton.value = "Done Existing Walls";
                else if (wallType == WALL_TYPE.PROPOSED)
                    doneButton.value = "Done Proposed Walls";
                else
                    doneButton.value = "Done Drawing";
            }
        }

        /**
        *undo
        *Undo function; removes last line drawn
        *@param toBeRemoved - true or false whether we want to add the last element to the removed line list
        */
        //function undo(addToRemovedList) {

        //    //if last line is removed, enable user to draw a line anywhere
        //    if (coordList.length === 0)
        //        startNewWall = true;
        //    else { //set the first coordinates of the next line to the last coordinates of the previous line
        //        //remove previously drawn walls
        //        d3.selectAll("#G").remove();
        //        d3.selectAll("#E").remove(); //remove existing walls
        //        d3.selectAll("#P").remove(); //remove proposed walls

        //        //if the element needs to be added to the removed list
        //        if (addToRemovedList)
        //            removed.push(coordList[coordList.length - 1]); //push it

                           
        //        coordList.pop();    //delete last line from the list
        //        console.log(coordList.length);
        //        if (coordList.length != null)
        //        {
        //        //go through the list of lines, set wall type, and draw the lines
        //            for (var i = 0; i <= coordList.length - 1; i++) {
        //                wallType = (coordList[i].id === WALL_TYPE.GABLE) ? WALL_TYPE.GABLE :
        //                    (coordList[i].id === WALL_TYPE.EXISTING) ? WALL_TYPE.EXISTING :
        //                    WALL_TYPE.PROPOSED;
        //                drawLine(coordList[i].x1, coordList[i].y1, coordList[i].x2, coordList[i].y2, false);
        //            }

        //            if (wallType != WALL_TYPE.GABLE)
        //            {
        //                if (coordList.length > 0)
        //                {
        //                    coordList[coordList.length].x1 = coordList[coordList.length - 1].x2;    //Sets the first X value of the new line to the second X value of the last line in the coordList array
        //                    coordList[coordList.length].y1 = coordList[coordList.length - 1].y2;    //Sets the first Y value of the new line to the second Y value of the last line in the coordList array
        //                }
        //                else
        //                {
        //                    coordList[0].id = WALL_TYPE.GABLE;
        //                    doneButton.value = "Done Gable Post";
        //                    log.innerHTML += "Please draw a gable post.\n\nPress 'E' to end a line.\n\n";
        //                    startNewWall = true;
        //                    document.getElementById("btnUndo").disabled = true;
        //                    document.getElementById("btnClear").disabled = true;
        //                    $('#btnUndo').addClass('btnDisabled');
        //                    $('#btnUndo').removeClass('btnSubmit');
        //                    $('#btnClear').addClass('btnDisabled');
        //                    $('#btnClear').removeClass('btnSubmit');
        //                }
        //            }
        //        }
        //        else
        //        {
        //            startNewWall = true;
        //        }
        //        setButtonValue();   //set the appropriate button value
        //    }
        //}

        ///**
        //*redo
        //*Redo function; redraws the last line undone
        //*/
        //function redo() {

        //    //If an item exist within the removed array proceed with logic
        //    if (removed.length != 0) {

        //        //Change the wall type based on the id of the last element in the removed array
        //        wallType = (removed[removed.length - 1].id === WALL_TYPE.GABLE)
        //            ? WALL_TYPE.GABLE : (removed[removed.length - 1].id === WALL_TYPE.EXISTING)
        //            ? WALL_TYPE.EXISTING : WALL_TYPE.PROPOSED;

        //        coordList.push(removed[removed.length - 1]); //Add the last item in the removed array to the coordList array
        //        removed.pop(); //Remove the last item in the removed array

        //        //Draw the last element in the coordList array
        //        drawLine(coordList[coordList.length - 1].x1, coordList[coordList.length - 1].y1, coordList[coordList.length - 1].x2, coordList[coordList.length - 1].y2, false);

        //        //Set the initial coordinates to the x2 and y2 coordinates of the last element in the coordList array
        //        coordList[coordList.length - 1].x1 = coordList[coordList.length - 1].x2;    //Sets the first X value of the new line to the second X value of the last line in the coordList array
        //        coordList[coordList.length - 1].y1 = coordList[coordList.length - 1].y2;    //Sets the first Y value of the new line to the second Y value of the last line in the coordList array

        //        setButtonValue(); //Call setButtonValue function to set the button text
        //    }
        //}

        /**
        *drawGrid
        *Draw grid function; draws the grid lines and border
        */
        function drawGrid() {

            //Creates rectangle area to draw in based on max canvas dimensions
            var rect = canvas.append("rect")                //Draws a rectangle for the canvas/grid to sit in
                        .attr("width", MAX_CANVAS_WIDTH)    //Sets the width for the canvas/grid
                        .attr("height", MAX_CANVAS_HEIGHT)  //Sets the height for the canvas/grid
                        .attr("fill", "white")              //Sets the color of the rectangle to white

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
            for (var i = 0; i < MAX_CANVAS_WIDTH; i += GRID_PADDING) {
                var line = canvas.append("line")            //Draws vertical lines based on the current i value of the loop
                        .attr("x1", i + GRID_PADDING)       //Sets the first X value to i plus the GRID_PADDING (25)
                        .attr("y1", 0)                      //Sets the frist Y value to 0
                        .attr("x2", i + GRID_PADDING)       //Sets the second X value to i plus GRID_PADDING(25)
                        .attr("y2", MAX_CANVAS_HEIGHT)      //Sets the second Y value to MAX_CANVAS_HEIGHT
                        .attr("stroke", "grey");            //Sets the line colour to grey
            }

            //Draws horizontal lines of the grid onto the canvas
            for (var i = 0; i < MAX_CANVAS_HEIGHT; i += GRID_PADDING) {
                var line = canvas.append("line")            //Draws horizontal lines based on the current i value of the loop
                        .attr("x1", 0)                      //Sets the first X value to 0
                        .attr("y1", i + GRID_PADDING)       //Sets the first Y value to i plus GRID_PADDING(25)
                        .attr("x2", MAX_CANVAS_WIDTH)       //Sets the second X value to MAX_CANVAS_WIDTH
                        .attr("y2", i + GRID_PADDING)       //Sets the second Y value to i plus GRID_PADDING(25)
                        .attr("stroke", "grey");            //Sets the line colour to grey
            }
        }

        //Gets the current mouse position on the canvas/grid
        function getMousePos(myCanvas, evt) {
            //Get the coordinates within the canvas/grid
            var rect = myCanvas.getBoundingClientRect();
            return {
                x: evt.clientX - rect.left, //return the X value of the mouse within the canvas/grid
                y: evt.clientY - rect.top   //return the Y value of the mouse within the canvas/grid
            };
        };

        /**
        *Draw line function takes in coordinates and a boolean to draw lines based on these arguments
        *@param x1 - first x coordinate of current line
        *@param y1 - first y coordinate of current line
        *@param x2 - second x coordinate of current line
        *@param y2 - second y coordinate of current line
        *@param mouseMove - boolean used to give an id to lines between drawn on mouse move event
        *@return line - returns line object and all its attributes
        */
        function drawLine(x1, y1, x2, y2, mouseMove) {
            var coordinates = setGridPoints(snapToGrid(x1, CELL_PADDING), snapToGrid(y1, CELL_PADDING), snapToGrid(x2, CELL_PADDING), snapToGrid(y2, CELL_PADDING));

            //Variables to hold starting/ending validated coordinates
            var coorx1 = coordinates.x1;
            var coorx2 = coordinates.x2;
            var coory1 = coordinates.y1;
            var coory2 = coordinates.y2;

            //Variables to hold the difference between the ending and starting points of x and y axes
            var dY = coory2 - coory1;
            var dX = coorx2 - coorx1;

            //If logical to check if the x2 value is outside of the right side of canvas/grid
            if (coorx2 > document.getElementById("mySunroom").clientWidth) {
                //Set x2 coordinate value to the maximum size of the canvas/grid
                coorx2 = document.getElementById("mySunroom").clientWidth;
                //Set y2 coordinate according to the x2,x1,y1 and slope
                coory2 = (dY / dX) * (coorx2 - coorx1) + coory1;
            }
                //If logical to check if the x2 value is outside of the left side of canvas/grid
            else if (coorx2 < 0) {
                //Set x2 coordinate to the minimum size of the canvas/grid
                coorx2 = 0;
                //Set y2 coordinate according to the x2,x1,y1 and slope
                coory2 = coory1 + (dY / dX) * (coorx2 - coorx1);
            }
            //If logical to check if the x2 value is outside of the right side of canvas/grid
            if (coory2 > document.getElementById("mySunroom").clientHeight) {
                //Set x2 coordinate value to the maximum size of the canvas/grid
                coory2 = document.getElementById("mySunroom").clientHeight;
                //Set y2 coordinate according to the x2,x1,y1 and slope
                coorx2 = (dY / dX) * (coory2 - coory1) + coorx1;
            }
                //If logical to check if the x2 value is outside of the left side of canvas/grid
            else if (coory2 < 0) {
                //Set x2 coordinate to the minimum size of the canvas/grid
                coory2 = 0;
                //Set y2 coordinate according to the x2,x1,y1 and slope
                coorx2 = coorx1 + (dY / dX) * (coory2 - coory1);
            }

            //Local variable to store all the line information
            var line = canvas.append("line")
                    .attr("x1", coorx1)
                    .attr("y1", coory1)
                    .attr("x2", coorx2)
                    .attr("y2", coory2);

            //alert(wallType);

            if (wallType === WALL_TYPE.GABLE) {
                //Make line id E for existing wall                
                line.attr("id", WALL_TYPE.GABLE)
                    //Change the line color to red
                    .attr("stroke", "green")
                    //Make stroke width to 2
                    .attr("stroke-width", 4);
            }
            //If wall type is existing do following logic
            else if (wallType === WALL_TYPE.EXISTING) {
                //Make line id E for existing wall                
                line.attr("id", WALL_TYPE.EXISTING)
                    //Change the line color to red
                    .attr("stroke", "red")
                    //Make stroke width to 2
                    .attr("stroke-width", 2);
            }
                //If wall type is proposed do following logic
            else if (wallType === WALL_TYPE.PROPOSED) {
                //Make line id P for proposed wall
                line.attr("id", WALL_TYPE.PROPOSED)
                    //Change the line color to black
                    .attr("stroke", "black")
                    //Make stroke width to 2
                    .attr("stroke-width", 2);
            }

            //If logic to change line id on mousemove event, if mouseMove is true
            if (mouseMove)
                line.attr("id", "mouseMoveLine");

            //if (document.getElementById("btnUndo").disabled == true)
            //{
            //    document.getElementById("btnUndo").disabled = false;
            //    $('#btnUndo').addClass('btnSubmit');
            //    $('#btnUndo').removeClass('btnDisabled');
            //}

            if (document.getElementById("btnClear").disabled == true)
            {
                document.getElementById("btnClear").disabled = false;
                $('#btnClear').addClass('btnSubmit');
                $('#btnClear').removeClass('btnDisabled');
            }

            //Return the line
            return line;
        };

        /**
        *Find line orientation (string format)
        *@param x1 - first x coordinate of current line
        *@param y1 - first y coordinate of current line
        *@param x2 - second x coordinate of current line
        *@param y2 - second y coordinate of current line
        *@return orientation - variable containing compass direction (N, NE, E, SE, S, SW, W, NW)
        */
        function getStringOrientation(x1, y1, x2, y2) {
            //Variable to hold difference between x2 and x1 values
            var dX = x2 - x1;
            //Variable to hold difference between y2 and y1 values
            var dY = y2 - y1;
            //Variable to get orientation value, from 0 to 7
            var orientation = getOrientation(dX, dY);

            //Switch case on orientation values, from 0 to 7
            switch (orientation) {
                //Case when orientation is 0, set orientation to "S"
                case WALL_FACING.SOUTH:
                    orientation = "S";
                    break;
                    //Case when orientation is 4, set orientation to "N"
                case WALL_FACING.NORTH:
                    orientation = "N";
                    break;
                    //Case when orientation is 1, set orientation to "SW"
                case WALL_FACING.SOUTH_WEST:
                    orientation = "SW";
                    break;
                    //Case when orientation is 5, set orientation to "NE"
                case WALL_FACING.NORTH_EAST:
                    orientation = "NE";
                    break;
                    //Case when orientation is 2, set orientation to "W"
                case WALL_FACING.WEST:
                    orientation = "W";
                    break;
                    //Case when orientation is 6, set orientation to "E"
                case WALL_FACING.EAST:
                    orientation = "E";
                    break;
                    //Case when orientation is 3, set orientation to "NW"
                case WALL_FACING.NORTH_WEST:
                    orientation = "NW";
                    break;
                    //Case when orientation is 7, set orientation to "SE"
                case WALL_FACING.SOUTH_EAST:
                    orientation = "SE";
                    break;
            }

            return orientation; //Return orientation in string format
        }

        /**
        *Find line orientation (number)
        *@param dX - difference between the x coordinates of a line
        *@param dY - difference between the y coordinates of a line
        *@return - returns a value from 0 to 7 which determines which direction the line is going
        */
        function getOrientation(dX, dY) {
            return ((Math.round(Math.atan2(dY, dX) / (Math.PI / 4))) + 8) % 8;
        }

        /**
        *Sets the line to 45 degrees or straight line
        *@param x1 - first x coordinate of current line
        *@param y1 - first y coordinate of current line
        *@param x2 - second x coordinate of current line
        *@param y2 - second y coordinate of current line
        *@return - an object which contains starting and ending coordinates for a valid line
        */
        function setGridPoints(x1, y1, x2, y2) {
            /**
            *Finds the sign value for the axes differences
            *@param val - difference between axes values (i.e. dX = (x2-x1))
            *@return - positive or negative 1 to assign the direction to coordinates (i.e. -1 or 1)
            */
            function sign(val) { return Math.abs(val) / val; }

            var dX, dY;         //Variables to hold delta X and Y, difference between second and first coordinates
            var length;         //Variable to hold the length between the coordinates
            var orientation;    //Variable to hold the orientation of the line

            dX = x2 - x1;       //Calculates the difference between x values of the current line            
            dY = y2 - y1;       //Calculates the difference between y values of the current line

            orientation = getOrientation(dX, dY); //Find the orientation value (0 to 7)

            //Switch case to handle line direction based off of orientation value
            switch (orientation) {
                //Switch case when orientation is 0 or 4
                case WALL_FACING.SOUTH:
                case WALL_FACING.NORTH:
                    //Changes y2 equal to y1, creates horizontal line
                    y2 = y1;
                    break;
                    //Switch case when orientation is 1 or 5
                case WALL_FACING.SOUTH_WEST:
                case WALL_FACING.NORTH_EAST:
                    //Changes y2 to create a 45 degree line
                    y2 = y1 + sign(dY) * Math.abs(dX);
                    break;
                    //Switch case when orientation is 2 or 6
                case WALL_FACING.WEST:
                case WALL_FACING.EAST:
                    //Changes x2 equal to x1, creates vertical line
                    x2 = x1;
                    break;
                    //Switch case when orientation is 3 or 7
                case WALL_FACING.NORTH_WEST:
                case WALL_FACING.SOUTH_EAST:
                    //Changes x2 to create a 45 degree line
                    x2 = x1 + sign(dX) * Math.abs(dY);
                    break;
            }

            return {
                'x1': x1, //return first X coordinate
                'y1': y1, //return first Y coordinate
                'x2': x2, //return second X coordinate
                'y2': y2  //return second Y coordinate
            };
        };

        /**
        *Validates lines to see that the sunroom has been closed and snaps lines to their assumed end points
        *@return isValid - boolean to say whether the room is valid or not
        */
        function sunroomCompleted() {
            //Variable to say whether or not the sunroom is valid
            var isValid = false;
            //If logic to see that at least 1 wall exist

            console.log("Standalone: " + standAlone);

            if (coordList.length < MIN_NUMBER_OF_WALLS) {
                //Error message to tell the user there current error
                log.innerHTML = "A complete sunroom must be enclosed (3 walls minimum). Please try again!\n\n";
            }
                //Else if to check for standAlone rooms and if the room is closed
            else if (standAlone && coordList[coordList.length - 1].x2 != coordList[0].x1) {
                //Alert to tell the user there current error
                log.innerHTML = "A stand-alone sunroom must end at the start of the starting wall. Please try again!\n\n";
            }
                //Else if logic to check for non-standAlone rooms
            else if (!standAlone) {
                //Assign isValid the value returned by validateNotStandAlone()
                isValid = validateNotStandAlone(true);
            }
                //Else, sunroom is ok, isValid is set to true
            else
                isValid = true;

            return isValid; //return isValid based on above logic
        }

        /**
        *validateNotStandAlone
        *Validate not stand alone function to validate external walls when its not a standAlone sunroom
        *@param lastWall - passes true or false whether the line being verified is the last wall
        *@return isValid - true or false depending on whether the wall is drawn properly or not
        */
        function validateNotStandAlone(lastWall) {

            //Array of calculated distances to determine the shortest distance
            var distanceBetweenLines = new Array();

            //Variable for storing the shortest calculated distance
            var shortest = 0;

            //Variable true or false depending on whether the drawn wall is valid
            var isValid = false;

            //Variable to store the wall number of the wall with shortest distance to the intercept
            var shortestDistanceWallNumber;

            //Run through the list of lines
            for (var i = 0; i < coordList.length; i++) {
                //If it is an existing wall...
                if (coordList[i].id === WALL_TYPE.EXISTING) {

                    var intercept = findIntercept(i); //Call to intercept function; finds intercept

                    //If determinant is 0 means its a parallel line, meaning no intercept
                    if (intercept.det === 0) {
                        //alert("Sunroom must be enclosed. Please add another wall.");
                    }
                        //There is an intercept
                    else {
                        isValid = true; //Thus valid

                        if (lastWall) {
                            //calculate the distance between the end of the last proposed line and the intercept
                            distanceBetweenLines[distanceBetweenLines.length] = {
                                //Calculated distance between intercept and second pair of coordinates
                                "distance": Math.sqrt(Math.pow((intercept.x - coordList[coordList.length - 1].x2), 2) + Math.pow((intercept.y - coordList[coordList.length - 1].y2), 2)),
                                "x": intercept.x,   //X value for intercept
                                "y": intercept.y    //Y value for intercept
                            };
                        }
                        else {
                            //calculate the distance between the end of the first proposed line and the intercept
                            distanceBetweenLines[distanceBetweenLines.length] = {
                                //Calculated distance between intercept and first pair of coordinates
                                "distance": Math.sqrt(Math.pow((intercept.x - coordList[coordList.length - 1].x1), 2) + Math.pow((intercept.y - coordList[coordList.length - 1].y1), 2)),
                                "x": intercept.x,   //X value for intercept
                                "y": intercept.y    //Y value for intercept
                            };
                        }
                    }
                }
            }
            //Determine the shortest distance between all the intercepts
            shortest = MAX_CANVAS_WIDTH; //Arbitrary long number for getting at the shortest distance

            //Loop through all the lines and determine the shortest distance
            for (var j = 0; j < distanceBetweenLines.length; j++) {
                //If the calculated distance is less than the shortest distance...
                if (distanceBetweenLines[j].distance < shortest) {
                    shortest = distanceBetweenLines[j].distance; //Set shortest distance to the calculated distance
                    shortestDistanceWallNumber = j;              //Store the wall number for the shortest distance                                    
                }
            }

            //If shortest isn't zero...
            if (shortest != 0) {

                //undo the last drawn line, to be redrawn properly (i.e. snapped to the coordinate)
                undo(false);    //Call to undo function

                if (lastWall) {
                    //Sraw the snapped line
                    var line = drawLine(intercept.x1, intercept.y1, distanceBetweenLines[shortestDistanceWallNumber].x, distanceBetweenLines[shortestDistanceWallNumber].y, false);
                }
                else {
                    //If the intercept.x2 (or y2) value and the x (or y) value of the shortest distance wall are the same..
                    if (distanceBetweenLines[shortestDistanceWallNumber].x === intercept.x2 && distanceBetweenLines[shortestDistanceWallNumber].y === intercept.y2) {
                        isValid = false;
                    }
                    else {
                        wallType = WALL_TYPE.PROPOSED;
                        //Draw the line with intercepts as the starting point and the lines second coordinates as the end coordinates
                        var line = drawLine(distanceBetweenLines[shortestDistanceWallNumber].x, distanceBetweenLines[shortestDistanceWallNumber].y, intercept.x2, intercept.y2, false);
                    }
                }

                //Get the orientation
                var stringOrientation = getStringOrientation(line.attr("x1"), line.attr("y1"), line.attr("x2"), line.attr("y2"));
                //Store the new line into the list
                coordList[coordList.length] = { "x1": line.attr("x1"), "x2": line.attr("x2"), "y1": line.attr("y1"), "y2": line.attr("y2"), "id": line.attr("id"), "orientation": stringOrientation }

                //Set the starting coordinates of the next line to the ending coordinates of this line
                x1 = line.attr("x2");
                y1 = line.attr("y2");
            }

            return isValid; //Returns true/false if the line is valid or not
        }

        /**
        *validateGable
        *Validates gable rooms, only rules that apply are that there has to be 2 parallel lines/walls and
        *the room must be enclosed
        *@return - true or false depending on whether the walls meet the conditions of being enclosed and,
        *at least 2 parallel lines/walls to support the gable
        */
        function validateGable()
        {
            log.innerHTML = "";

            var goodParallel = false; // determines if the side walls of a gable room are parallel
            var gablesDrawn = 0; // number of gable posts drawn. must be 1, max of 2 at end of validation
            var valid = 0; //must end up equal to amount of lines in coordlist
            var proposedTouchingGable = 0; // must be equal to (2 * number of gables drawn) at end of validation
            var proposedTouchingExisting = 0; // must be 2 at end of validation

            for (var i = 0; i < coordList.length; i++)
            {
                var currentLine = coordList[i];
                var proposedTouches = 0; // whenever this variable equals 2, break the secondary loop
                var existingTouches = 0; // whenever this variable equals 2, break the secondary loop
                var gableTouches = 0; // must be 2 for each gable drawn at end of secondary loop

                for (var j = 0; j < coordList.length; j++)
                {

                    if (currentLine != coordList[j])
                    {
                        if (currentLine.id == "E") //current wall is existing
                        {
                            if (coordList[j].id == "E") //next wall is existing
                            {
                                if (findLineEndTouch(currentLine, coordList[j]) || findLinePerpendicularTouch(currentLine, coordList[j])) 
                                {
                                    existingTouches++;
                                    if (existingTouches == 2) {
                                        valid++;
                                        existingTouches = 0;
                                        break;
                                    }
                                }
                            }
                            else if (coordList[j].id == "P") //next wall is proposed
                            {
                                if (findLineAxis(currentLine) == "V" && findLineAxis(coordList[j]) == "H") //current wall is vertical, proposed wall is horizontal
                                {
                                    if (findLineEndTouch(currentLine, coordList[j]) || findLinePerpendicularTouch(currentLine, coordList[j])) //this proposed wall touches somewhere on the existing wall
                                    {
                                        valid++;
                                        existingTouches++;
                                        break;
                                    }
                                }
                                else if (findLineAxis(currentLine) == "H" && findLineAxis(coordList[j]) == "V") //current wall is horizontal, proposed wall is vertical
                                {
                                    if (findLineEndTouch(currentLine, coordList[j]) || findLinePerpendicularTouch(currentLine, coordList[j])) //this proposed wall touches somewhere on the existing wall
                                    {
                                        valid++;
                                        existingTouches++;
                                        break;
                                    }
                                }
                                else if (findLineAxis(currentLine) == "D" && findLineAxis(coordList[j]) == "D") //current and proposed walls are both diagonals
                                {
                                    if (findLineEndTouch(currentLine, coordList[j]) || findLinePerpendicularTouch(currentLine, coordList[j])) //this proposed wall touches somewhere on the existing wall
                                    {
                                        valid++;
                                        existingTouches++;
                                        break;
                                    }
                                }
                            }
                        }
                        else if (currentLine.id == "P") //current wall is proposed
                        {
                            if (coordList[j].id == "E") //next wall is existing
                            {
                                if (findLineAxis(currentLine) == "V" && findLineAxis(coordList[j]) == "H") //current wall is vertical, existing wall is horizontal
                                {
                                    //does the proposed wall touch anywhere on this existing wall?
                                    if (findLineEndTouch(currentLine, coordList[j]) || findLinePerpendicularTouch(currentLine, coordList[j]))
                                    {
                                        proposedTouchingExisting++;
                                        proposedTouches++;

                                        if (parseInt(proposedTouches) == 2)
                                        {
                                            proposedTouches = 0;
                                            valid++;
                                            break;
                                        }
                                    }
                                }
                                else if (findLineAxis(currentLine) == "H" && findLineAxis(coordList[j]) == "V") //current wall is horizontal, existing wall is vertical
                                {
                                    //does the proposed wall touch anywhere on this existing wall?
                                    if (findLineEndTouch(currentLine, coordList[j]) || findLinePerpendicularTouch(currentLine, coordList[j]))
                                    {
                                        proposedTouchingExisting++;
                                        proposedTouches++;

                                        if (parseInt(proposedTouches) == 2)
                                        {
                                            proposedTouches = 0;
                                            valid++;
                                            break;
                                        }
                                    }
                                }
                                else if (findLineAxis(currentLine) == "D" && findLineAxis(coordList[j]) == "D") //current and existing walls are both diagonals
                                {
                                    if (findLinePerpendicularTouch(currentLine, coordList[j])) //this proposed wall touches somewhere on the existing wall
                                    {
                                        proposedTouchingExisting++;
                                        proposedTouches++;

                                        if (parseInt(proposedTouches) == 2)
                                        {
                                            proposedTouches = 0;
                                            valid++;
                                            break;
                                        }
                                    }
                                }
                            }
                            else if (coordList[j].id == "P") //next wall is proposed
                            {
                                //do these proposed walls meet?
                                if (findLineEndTouch(currentLine, coordList[j]))
                                {
                                    //find slope of lines, if equal it is an error, that's one wall not two silly pants
                                    if (((parseFloat(currentLine.y2) - parseFloat(currentLine.y1)) / (parseFloat(currentLine.x2) - parseFloat(currentLine.x1))) != 
                                        ((parseFloat(coordList[j].y2) - parseFloat(coordList[j].y1)) / (parseFloat(coordList[j].x2) - parseFloat(coordList[j].x1))))
                                    {
                                        proposedTouches++;

                                        if (parseInt(proposedTouches) == 2)
                                        {
                                            proposedTouches = 0;
                                            valid++;
                                            break;
                                        }
                                    }
                                }
                            }
                            else if (coordList[j].id == "G")
                            {
                                //does currentline touch this gable?
                                if (findLineEndTouch(currentLine, coordList[j]))
                                {
                                    //if gable is horizontal then proposed must also be horizontal
                                    if (findLineAxis(currentLine) == "H" && findLineAxis(coordList[j]) == "H")
                                    {
                                        proposedTouches++;

                                        if (parseInt(proposedTouches) == 2)
                                        {
                                            proposedTouches = 0;
                                            valid++;
                                            break;
                                        }
                                    }
                                        //if gable is vertical, proposed still has to be horizontal
                                    else if (findLineAxis(currentLine) == "H" && findLineAxis(coordList[j]) == "V")
                                    {
                                        proposedTouches++;

                                        if (parseInt(proposedTouches) == 2)
                                        {
                                            proposedTouches = 0;
                                            valid++;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        else if (currentLine.id == "G")
                        {
                            if (coordList[j].id == "P")
                            {
                                //does this gable attach to the end of an existing wall?
                                if (findLineEndTouch(currentLine, coordList[j]))
                                {
                                    if (findLineAxis(currentLine) != "D" && findLineAxis(coordList[j]) != "D")
                                    {
                                        gableTouches++;
                                        proposedTouchingGable++;

                                        if (parseInt(gableTouches) == 2)
                                        {
                                            gableTouches = 0;
                                            valid++;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            for (var i = 0; i < coordList.length; i++)
            {
                if (coordList[i].id == "G")
                {
                    gablesDrawn++;
                }
            }

            goodParallel = findGableParallel();

            if (parseInt(valid) != coordList.length)
            {
                log.innerHTML += "Your walls do not attach in a valid way.\n\n";
            }

            if (!$('#<%=chkStandalone.ClientID%>').is(':checked'))
            {
                if (parseInt(proposedTouchingExisting) != 2)
                {
                    log.innerHTML += "You require two proposed walls that attach to existing walls.\n\n";
                }
            }
            
            if (parseInt(gablesDrawn) == 0)
            {
                log.innerHTML += "You have not drawn any gable posts.\n\n";
            }
            else if (parseInt(gablesDrawn) > 2)
            {
                log.innerHTML += "You have drawn too many gable posts.\n\n";
            }
            else
            {
                if (parseInt(proposedTouchingGable) != (2 * parseInt(gablesDrawn)))
                {
                    log.innerHTML += "Your gable posts do not have the required number of proposed walls touching.\n\n";
                }
            }

            if (goodParallel == false)
            {
                log.innerHTML += "Your gable sunroom must have 2 parallel walls to support the roof. Please try again.\n\n";
            }

            if (log.innerHTML == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

            // ******************************************* PATS STUFF ****************************************************
            //var validLines = 0;         //Variable to determine if all walls are connected or the sunroom is enclosed
            //var goodParallel = false;   //Variable to determine if 2 walls are parallel

            ////Loop to set a wall to varify against
            //for (var i = 0; i < coordList.length; i++) {
                
            //    //Setting a line/wall variable to test against
            //    var currentLine = coordList[i];

            //    //Loop through lines/walls to varify against the outer loop one
            //    for (var k = 0; k < coordList.length; k++) {
                    
            //        //If the lines/walls aren't the same, perform this block
            //        if (currentLine != coordList[k]) {
            //            console.log(currentLine.id);
            //            console.log("currentLineX1: " + currentLine.x1 + ", currentLineX2: " + currentLine.x2 + ", currentLineY1: " + currentLine.y1 + ", currentLineY2: " + currentLine.y2);
            //            console.log("coordListKX1: " + coordList[k].x1 + ", coordListKX2: " + coordList[k].x2 + ", coordListKY1: " + coordList[k].y1 + ", coordListKY2: " + coordList[k].y2);
                        
            //            //if the lines/walls start or end coordinates are the same, add one to validLines
            //            if ((currentLine.x1 == coordList[k].x2 && currentLine.y1 == coordList[k].y2) || (currentLine.x1 == coordList[k].x1 && currentLine.y1 == coordList[k].y1)
            //                || (currentLine.x1 < coordList[k].x1 ) || (currentLine.y2 > coordList[k].y2 )) {
            //                validLines++;
            //            }
            //            //If this function returns true, perform this block
            //            if (validateOppositeWalls(currentLine, coordList[k])) {
            //                //Variable to hold the length of the first line/wall
            //                var lineOneLength = Math.sqrt(Math.pow((currentLine.x2 - currentLine.x1), 2) + Math.pow((currentLine.y2 - currentLine.y1), 2));
            //                //Variable to hold the lenght of the second line/wall
            //                var lineTwoLength = Math.sqrt(Math.pow((coordList[k].x2 - coordList[k].x1), 2) + Math.pow((coordList[k].y2 - coordList[k].y1), 2));

            //                //If the length of both lines/walls are the same, set the goodParellel value to true
            //                if (lineOneLength == lineTwoLength) {
            //                    goodParallel = true;
            //                }
            //            }
            //        }
            //    }
            //}

            ////If the validLines and length of the coordList array aren't the same, display error and return false
            ////Sunroom is not enclosed
            //if (validLines != coordList.length) {
            //    log.innerHTML = "Your gable sunroom must be enclosed. Please try again.";
            //    return false;
            //}
            //    //Else if no walls are parallel to support the gable, display error and return false
            //else if (goodParallel == false) {
            //    log.innerHTML = "Your gable sunroom must have 2 parallel walls to support the roof. Please try again.";
            //    return false;
            //}

            //return true;
        //}

        function findGableParallel()
        {
            var firstWall;
            var secondWall;
            
            for (var i = 0; i < coordList.length; i++)
            {
                if (coordList[i].id == "P")
                {
                    firstWall = coordList[i];
                    break;
                }
            }

            for (var i = parseInt(coordList.length - 1); i > 0; i--)
            {
                if (coordList[i].id == "P")
                {
                    secondWall = coordList[i];
                    break;
                }
            }

            if ((findLineAxis(firstWall) == "H" && findLineAxis(secondWall) == "H") ||
                (findLineAxis(firstWall) == "V" && findLineAxis(secondWall) == "V") ||
                (findLineAxis(firstWall) == "D" && findLineAxis(secondWall) == "D"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /**
        *validateOppositeWalls
        *This function determines whether or not the 2 lines passed are of opposite orientation
        *@param firstLine - first line to check values against
        *@param secondLine - second line to check values against
        *@return - a boolean whether or not the lines are opposites
        */
        function validateOppositeWalls(firstLine, secondLine) {

            /**
            *If any of the coordinates are of opposite values (i.e. East opposite is West, North opposite to South, etc.),
            *return true
            */
            if ((firstLine.orientation == WALL_ORIENTATION.EAST && secondLine.orientation == WALL_ORIENTATION.WEST) || (firstLine.orientation == WALL_ORIENTATION.WEST && secondLine.orientation == WALL_ORIENTATION.EAST)) {
                return true;
            }
            if ((firstLine.orientation == WALL_ORIENTATION.SOUTH && secondLine.orientation == WALL_ORIENTATION.NORTH) || (firstLine.orientation == WALL_ORIENTATION.NORTH && secondLine.orientation == WALL_ORIENTATION.SOUTH)) {
                return true;
            }
            if ((firstLine.orientation == WALL_ORIENTATION.SOUTH_WEST && secondLine.orientation == WALL_ORIENTATION.NORTH_EAST) || (firstLine.orientation == WALL_ORIENTATION.NORTH_EAST && secondLine.orientation == WALL_ORIENTATION.SOUTH_WEST)) {
                return true;
            }
            if ((firstLine.orientation == WALL_ORIENTATION.SOUTH_EAST && secondLine.orientation == WALL_ORIENTATION.NORTH_WEST) || (firstLine.orientation == WALL_ORIENTATION.NORTH_WEST && secondLine.orientation == WALL_ORIENTATION.SOUTH_EAST)) {
                return true;
            }

            return false;
        }

        /**
        *findIntercept
        *Find intercept function runs through all of the lines in the list, and finds 
        *    the intercepting point between each line and the last drawn line
        *@param lineNumber - the number of line for which we need to find intercept
        *@return - a line object with the intercept point, the starting and ending coordinates, and the determinant
        */
        function findIntercept(lineNumber) {

            //the following variables hold the starting and ending x and y coordinates of a given line
            var cx2, cx1, cy2, cy1;

            //the following variables will be used for the line equation of the given line
            var A1, B1, C1;

            //the following variables will be used for the line equation of the last drawn line
            var A2, B2, C2;

            //initialize the given line coordinate variables, retrieving the coordinates from the list
            cx2 = coordList[lineNumber].x2; //initialize x2
            cx1 = coordList[lineNumber].x1; //initialize x1
            cy2 = coordList[lineNumber].y2; //initialize y2
            cy1 = coordList[lineNumber].y1; //initialize y1

            //calculate A1 for use in the line equation for the given line
            A1 = cy2 - cy1;
            //calculate B1 for use in the line equation for the given line
            B1 = cx1 - cx2;
            //make the line equation for the given line with A1, B1, and coordinates of the line
            C1 = A1 * cx1 + B1 * cy1;

            //initialize the last drawn line coordinate variables, retrieving the coordinates from the list
            cx2 = coordList[coordList.length - 1].x2; //initialize x2
            cx1 = coordList[coordList.length - 1].x1; //initialize x1
            cy2 = coordList[coordList.length - 1].y2; //initialize y2
            cy1 = coordList[coordList.length - 1].y1; //initialize y1

            //calculate A1 for use in the line equation for the last drawn line
            A2 = cy2 - cy1;
            //calculate B1 for use in the line equation for the last drawn line
            B2 = cx1 - cx2;
            //make the line equation for the last drawn line with A1, B1, and coordinates of the line
            C2 = A2 * cx1 + B2 * cy1;

            //calculate the determinant 
            var det = (A1 * B2) - (A2 * B1);
            //calculate the x value of the intercepting point
            var x = (B2 * C1 - B1 * C2) / det;
            //calculate the y value of the intercepting point
            var y = (A1 * C2 - A2 * C1) / det;

            return {
                "det": det, //return the determinant (0 if parallel)
                "x": x,     //return the x coordinate of the intercept point
                "y": y,     //return the y coordinate of the intercept point
                "x1": cx1,  //return the initial x coordinate of the line
                "y1": cy1,  //return the initial y coordinate of the line
                "y2": cy2,  //return the ending x coodinate of the line
                "x2": cx2   //return the ending y coordinate of the line
            };
        }
        
        /**
        *snapToGrid
        *Snap to grid function snaps each drawn line to the corners of each cell in the grid;
        *    this prevents irregular lines being drawn
        *@param coordinate - all of the coordinates (x1, y1, x2, y2), will be sent for snapping individually
        *@return - return the new (snapped to grid) coordinate
        */
        function snapToGrid(coordinate) {
            //set to true or false depending on if the coordinate is less than cell padding * number of cells
            var endLoop = false;
            //initialize a counter to count the number of cells the coordinate is in
            var count = 0;
            //used to store validated coordinate
            var validCoordinate = 0;

            //run through a loop 
            while (!endLoop) {
                count++;// increment the counter every time the loop runs
                if (coordinate <= CELL_PADDING * count) { //if coordinate is less than cell padding * number of cells
                    endLoop = true; //end the loop
                    count--; //decrement the counter
                }
            }

            //if coordinate is closer to the one side of the grid line
            if ((coordinate - (count * CELL_PADDING)) <= CELL_PADDING / 2)
                validCoordinate = CELL_PADDING * count; //snap it to this line
            else //if coordinate is closer to the other side of the grid line
                validCoordinate = CELL_PADDING * (count + 1); //snap it to the other line

            return validCoordinate; //return the validated coordinate
        }

        /********************************************* JAVASCRIPT EVENTLISTENERS/HANDLERS *********************************************/

        /**
        *EventListner Type: onclick
        *Event target: svgGrid/document.getElementById("mySunroom")
        *Performs a function when the onclick event on the canvas/grid is triggered
        */
        svgGrid.addEventListener("click",
        function (evt) {
            //Variable to hold the values return by getMousePos. X and Y coordinates within the canvas/grid
            var mousePos = getMousePos(svgGrid, evt);

            //If startNewWall is true, set the first pair of coordinates to the current mouse position
            //Used to define when the first click of on the canvas and reset removed array elements
            if (startNewWall) {
                x1 = mousePos.x; //Find first X coordinates for the new line within the canvas/grid
                y1 = mousePos.y; //Find first Y coordinates for the new line within the canvas/grid

                //Set startNewWall to false to find logic to complete line coordinates
                startNewWall = false;

                removed = new Array(); //Delete all entries into removed array

                //Validation for these condition: not stand alone, existing walls exist, the current line being drawn is proposed wall type
                if (!standAlone && coordList.length != 0 && wallType === WALL_TYPE.PROPOSED)
                    validateFirstWall = true;

            }
                //Logic for clicks after initial click to draw lines and store values into an array
            else {
                x2 = mousePos.x; //Find second X coordinates for the current line within the canvas/grid
                y2 = mousePos.y; //Find second Y coordinates for the current line within the canvas/grid

                //Draw the line and store the line into a variable named "line"
                var line = drawLine(x1, y1, x2, y2, false);

                //Find the orientation in string format to be stored into the array to be passed to C# classes
                var stringOrientation = getStringOrientation(line.attr("x1"), line.attr("y1"), line.attr("x2"), line.attr("y2"));

                //Store line starting and ending coordinates, along with line id and string orientation
                coordList[coordList.length] = {
                    "x1": line.attr("x1"), //Sets the first X coordinate for the current line
                    "y1": line.attr("y1"), //Sets the first Y coordinate for the current line
                    "x2": line.attr("x2"), //Sets the second X coordinate for the current line
                    "y2": line.attr("y2"), //Sets the second Y coordinate for the current line
                    "id": line.attr("id"), //Sets the ID for the current line
                    "orientation": stringOrientation //Sets the line orientation for the current line
                };

                //Validation for lines that meet these conditions: non-stand alone, first wall, and are proposed walls.
                if (!standAlone && validateFirstWall && coordList[coordList.length - 1].id === WALL_TYPE.PROPOSED) {
                    if (gable == false) {
                        validateNotStandAlone(false); //Call to validateNotStandAlone to snap first line
                        validateFirstWall = false;    //Sets validateFirstWall to false since walls to be drawn won't be the first one
                    }
                }

                //Restart the start position for the next line to be drawn
                x1 = coordList[coordList.length - 1].x2; //Sets the starting X for the next line to the last X coordinate of the previous line
                y1 = coordList[coordList.length - 1].y2; //Sets the starting Y for the next line to the last Y coordinate of the previous line
            }
        }, false);


        /**
         *EventListner Type: mousemove
         *Event target: svgGrid/document.getElementById("mySunroom")
         *Performs a function when the mousemove event on the canvas/grid is triggered
         */
        svgGrid.addEventListener("mousemove",
        function (evt) {
            //Store mouse coordinates from within the canvas/grid into a variable named mousePos
            var mousePos = getMousePos(svgGrid, evt);

            //Store the lines 2nd pair of coordinates into variables
            x2 = mousePos.x;
            y2 = mousePos.y;

            //Remove all lines from the canvas/grid with the id "mouseMoveLine"
            d3.selectAll("#mouseMoveLine").remove();

            //If startNewWall is false, draw the line on mouse move event
            //This will occur after the first initial of every wall type (Existing Walls, Proposed Walls, Internal Walls)
            if (!startNewWall)
                drawLine(x1, y1, x2, y2, true);
        });
        
        /**
         *EventListner Type: mouseout
         *Event target: svgGrid/document.getElementById("mySunroom")
         *Performs a function when the mouseout event on the canvas/grid is triggered
         */
        svgGrid.addEventListener("mouseout",
        function () {
            //Remove all lines on the canvas/grid with the id "mouseMoveLine"
            d3.selectAll("#mouseMoveLine").remove();
        });

        function standaloneToggle(){
            if ($('#<%=chkStandalone.ClientID%>').is(':checked')) {
                standAlone = true;
                clearCanvas();
            }
            else {
                standAlone = false;
                clearCanvas();
            }
        }
    </script>
</asp:Content>
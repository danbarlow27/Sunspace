<%@ Page Title="New Project - Project Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WizardWallsAndMods.aspx.cs" Inherits="SunspaceDealerDesktop.WizardWallsAndMods" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <script src="Scripts/Validation.js"></script>
    <%-- Hidden div populating scripts 
    =================================== --%>
    <script>
        var detailsOfAllLines = '<%= (string)Session["coordList"] %>'; //all the coordinates and details of all the lines
        var lineList = detailsOfAllLines.substr(0, detailsOfAllLines.length - 1).split("/"); //a list of individual lines and their coordinates and details 
        var coordList = new Array(); //new 2d array to store each individual coordinate and details of each line
        for (var i = 0; i < lineList.length; i++) { 
            coordList[i] = lineList[i].split(","); //populate the 2d array
        }
        var wallSetBackArray = new Array();
        var projection = 10; //hard coded for testing

        function calculateSetBack(index) {
            /*
            SOUTH       :   ZERO
            NORTH       :   ZERO
            WEST        :   LENGTH
            EAST        :   NEGATIVE LENGTH
            SOUTHWEST   :   (2a^2 = L^2)
            NORTHWEST   :   (2a^2 = L^2)            
            SOUTHEAST   :   NEGATIVE (2a^2 = L^2)  
            NORTHEAST   :   NEGATIVE (2a^2 = L^2) 
            */

            var L = document.getElementById("MainContent_txtWall" + i + "Length").value;

            switch (coordList[index][5]) { //5 = orientation
                case "S":
                case "N":
                    wallSetBackArray[index] = 0;
                    break;
                case "W":
                    wallSetBackArray[index] = L;
                    break;
                case "E":
                    wallSetBackArray[index] = -L;
                    break;
                case "SW":
                case "NW":
                    wallSetBackArray[index] = Math.sqrt((Math.pow(L, 2)) / 2);
                    break;
                case "SE":
                case "NE":
                    wallSetBackArray[index] = -(Math.sqrt((Math.pow(L, 2)) / 2));
                    break;
            }
        }

        function calculateProjection() {
            var tempProjection = 0;
            var highestSetBack = 0;
            for (var i = 0; i < wallSetBackArray.length; i++) {
                tempProjection = +tempProjection + +wallSetBackArray[i];
                if (tempProjection > highestSetBack) {
                    highestSetBack = tempProjection;
                }
            }
            return highestSetBack;
        }

        function checkQuestion1() {

            //disable 'next slide' button until after validation (this is currently enabled for debugging purposes)
            document.getElementById('MainContent_btnQuestion1').disabled = false;
            //document.getElementById('MainContent_btnQuestion2').disabled = false;
            //document.getElementById('MainContent_btnQuestion3').disabled = false;

            //var lengthList = new Array();
            var isValid = true;
            var answer = "";

            for (var i = 1; i <= lineList.length; i++) {
                if (isNaN(document.getElementById("MainContent_txtWall" + (i) + "Length").value)
                    || document.getElementById("MainContent_txtWall" + (i) + "Length").value <= 0 //zero should be changed to MIN_WALL_LENGTH
                    || isNaN(document.getElementById("MainContent_txtWall" + (i) + "LeftFiller").value)
                    || document.getElementById("MainContent_txtWall" + (i) + "LeftFiller").value < 0
                    || isNaN(document.getElementById("MainContent_txtWall" + (i) + "RightFiller").value)
                    || document.getElementById("MainContent_txtWall" + (i) + "RightFiller").value < 0)
                    isValid = false;
            }

            if (isValid) {
                for (var i = 1; i <= lineList.length; i++) { //add up length and filler and populate the hidden fields
                    document.getElementById("hidWall" + i + "SetBack").value = wallSetBackArray[i]; //store wall setback
                    document.getElementById("hidWall" + i + "LeftFiller").value = document.getElementById("MainContent_txtWall" + i + "Length").value; 
                    document.getElementById("hidWall" + i + "Length").value = document.getElementById("MainContent_txtWall" + i + "Length").value;
                    document.getElementById("hidWall" + i + "RightFiller").value = document.getElementById("MainContent_txtWall" + i + "Length").value;
                    answer += "Wall " + i + ": " + document.getElementById("MainContent_txtWall" + i + "Length").value;
                    calculateSetBack((i - 1));
                }

                //store projection in the projection variable and hidden field
                document.getElementById("MainContent_hidProjection").value = projection = calculateProjection();

                //Set answer on side pager and enable button
                $('#MainContent_lblWallLengthsAnswer').text(answer);
                document.getElementById('pagerOne').style.display = "inline";
                document.getElementById('MainContent_btnQuestion1').disabled = false;
            }
            else { //not valid
                //error styling or something
                //Set answer on side pager and enable button
                $('#MainContent_lblWallLengthsAnswer').text("Invalid Input");
                document.getElementById('pagerOne').style.display = "inline";
                document.getElementById('MainContent_btnQuestion1').disabled = false;
            }

            return false;
        }

        function checkQuestion2() {
            //alert("here i am, rock you like a hurricane");
            //disable 'next slide' button until after validation (this is currently enabled for debugging purposes)
            //document.getElementById('MainContent_btnQuestion1').disabled = false;
            //document.getElementById('MainContent_btnQuestion2').disabled = false;
            //document.getElementById('MainContent_btnQuestion3').disabled = false;

            var isValid = true;
            var answer = "";
            var m;    //m = (rise(projection/12))/12 slope over 12
            var rise; //m = (rise(projection/12))/12 slope over 12
            var run = 12;  // m = (rise(projection/12))/12 slope over 12

            if (document.getElementById("MainContent_chkAutoRoofSlope").checked) {
                document.getElementById("MainContent_chkAutoBackWallHeight").checked = false;
                document.getElementById("MainContent_chkAutoFrontWallHeight").checked = false;
                //we have front wall height and back wall height, calculate slope
                if (!isNaN(document.getElementById("MainContent_txtBackWallHeight").value)
                    && document.getElementById("MainContent_txtBackWallHeight").value > 0
                    //&& document.getElementById("MainContent_txtBackWallHeight").value != ""
                    && !isNaN(document.getElementById("MainContent_txtFrontWallHeight").value)
                    && document.getElementById("MainContent_txtFrontWallHeight").value > 0) {
                    //&& document.getElementById("MainContent_txtFrontWallHeight").value != ""
                    //|| isNaN(document.getElementById("MainContent_txtRoofSlope").value)
                    //|| document.getElementById("MainContent_txtRoofSlope").value <= 0)

                    //alert("yello");
                    isValid = true;
                    //run = run / 12; //to get slope over 12 inches
                    rise = (document.getElementById("MainContent_txtBackWallHeight").value - document.getElementById("MainContent_txtFrontWallHeight").value);
                    rise = rise * (projection / 12); //to get slope over 12
                    
                    document.getElementById("MainContent_txtRoofSlope").value = m = (Math.round((rise / run) * 100)) / (100); //round m to 2 decimal places
                }
                else
                    isValid = false;
            }
            else if (document.getElementById("MainContent_chkAutoFrontWallHeight").checked) {
                document.getElementById("MainContent_chkAutoRoofSlope").checked = false;
                document.getElementById("MainContent_chkAutoBackWallHeight").checked = false;
                //we have back wall height and slope, calculate front wall height
                if (!isNaN(document.getElementById("MainContent_txtBackWallHeight").value)
                    && document.getElementById("MainContent_txtBackWallHeight").value > 0
                    //&& document.getElementById("MainContent_txtBackWallHeight").value != ""
                    //|| !isNaN(document.getElementById("MainContent_txtFrontWallHeight").value)
                    //|| document.getElementById("MainContent_txtFrontWallHeight").value > 0) {
                    && !isNaN(document.getElementById("MainContent_txtRoofSlope").value)
                    && document.getElementById("MainContent_txtRoofSlope").value > 0) {
                    //&& document.getElementById("MainContent_txtRoofSlope").value != ""

                    isValid = true;

                    m = document.getElementById("MainContent_txtRoofSlope").value;
                    //run = projection;
                    rise = (run * m) / (projection / 12);

                    document.getElementById("MainContent_txtFrontWallHeight").value = +document.getElementById("MainContent_txtBackWallHeight").value - rise;
                }
                else
                    isValid = false;
            }
            else if (document.getElementById("MainContent_chkAutoBackWallHeight").checked) {
                document.getElementById("MainContent_chkAutoFrontWallHeight").checked = false;
                document.getElementById("MainContent_chkAutoRoofSlope").checked = false;
                //we have front wall height and slope, calculate back wall height
                if (!isNaN(document.getElementById("MainContent_txtFrontWallHeight").value)
                    && document.getElementById("MainContent_txtFrontWallHeight").value > 0
                    //&& document.getElementById("MainContent_txtBackWallHeight").value != ""
                    //|| !isNaN(document.getElementById("MainContent_txtFrontWallHeight").value)
                    //|| document.getElementById("MainContent_txtFrontWallHeight").value > 0) {
                    && !isNaN(document.getElementById("MainContent_txtRoofSlope").value)
                    && document.getElementById("MainContent_txtRoofSlope").value > 0) {
                    //&& document.getElementById("MainContent_txtRoofSlope").value != ""

                    isValid = true;

                    m = document.getElementById("MainContent_txtRoofSlope").value;
                    //run = projection;
                    rise = (run * m) / (projection / 12);

                    document.getElementById("MainContent_txtBackWallHeight").value = +document.getElementById("MainContent_txtFrontWallHeight").value + +rise;
                }
                else
                    isValid = false;
            }
            else {
                if (isNaN(document.getElementById("MainContent_txtFrontWallHeight").value)
                    || document.getElementById("MainContent_txtFrontWallHeight").value <= 0
                    || document.getElementById("MainContent_txtFrontWallHeight").value != ""
                    || isNaN(document.getElementById("MainContent_txtBackWallHeight").value)
                    || document.getElementById("MainContent_txtBackWallHeight").value <= 0
                    || document.getElementById("MainContent_txtBackWallHeight").value != ""
                    || isNaN(document.getElementById("MainContent_txtRoofSlope").value)
                    || document.getElementById("MainContent_txtRoofSlope").value <= 0
                    || document.getElementById("MainContent_txtRoofSlope").value != ""
                    || document.getElementById("MainContent_txtBackWallHeight").value <= document.getElementById("MainContent_txtFrontWallHeight").value)
                    isValid = false;
                else
                    isValid = true;
            }



            if (isValid) {
                document.getElementById("MainContent_hidBackWallHeight").value = document.getElementById("MainContent_txtBackWallHeight").value;
                document.getElementById("MainContent_hidFrontWallHeight").value = document.getElementById("MainContent_txtFrontWallHeight").value;
                document.getElementById("MainContent_hidRoofSlope").value = document.getElementById("MainContent_txtRoofSlope").value;
                answer += "Back Wall: " + document.getElementById("MainContent_hidBackWallHeight").value;
                answer += "Front Wall: " + document.getElementById("MainContent_hidFrontWallHeight").value;
                answer += "Roof Slope: " + document.getElementById("MainContent_hidRoofSlope").value;

                $('#MainContent_lblWallHeightsAnswer').text(answer);
                document.getElementById('pagerTwo').style.display = "inline";
                document.getElementById('MainContent_btnQuestion2').disabled = false;   
            }
            else {
                //error styling or something
                //Set answer on side pager and enable button
                $('#MainContent_lblWallHeightsAnswer').text("Invalid Input");
                document.getElementById('pagerTwo').style.display = "inline";
                document.getElementById('MainContent_btnQuestion2').disabled = false;
            }
            return false;
        }
        
    </script>
    <%-- End hidden div populating scripts --%>

    <%-- SLIDES (QUESTIONS)
    ======================================== 
        
        onmousedown="event.preventDefault ? event.preventDefault() : event.returnValue = false"--%>
    <div class="slide-window" id="slide-window" >

        <div class="slide-wrapper">
            
            <%-- QUESTION 1 - Wall Lengths
            ======================================== --%>
            <div id="slide1" class="slide">

                <h1>
                    <asp:Label ID="lblQuestion1" runat="server" Text="Please enter the wall lengths"></asp:Label>
                </h1>        
                              
                <div id="tableWallLengths" class="tblWallLengths" runat="server" style="padding-right:15%; padding-left:15%; padding-top:5%;">
                    <asp:Table ID="tblWallLengths" runat="server">
                        <asp:TableRow>
                            <asp:TableCell></asp:TableCell>
                            <asp:TableCell ColumnSpan="2" >
                                Left Filler
                            </asp:TableCell>
                            <asp:TableCell ColumnSpan="2">
                                Length
                            </asp:TableCell>
                            <asp:TableCell ColumnSpan="2">
                                Right Filler
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </div>

                <asp:Button ID="btnQuestion1" Enabled="true" CssClass="btnSubmit float-right slidePanel" data-slide="#slide2" runat="server" Text="Next Question" />

            </div> 
            <%-- end #slide1 --%>

            <%-- QUESTION 2 - Wall Heights
            ======================================== --%>
            <div id="slide2" class="slide">

                <h1>
                    <asp:Label ID="lblQuestion2" runat="server" Text="Please enter the wall heights"></asp:Label>
                </h1>
           
                        <div class="tblWallLengths" runat="server" style="padding-right:15%; padding-left:15%; padding-top:5%;">
                            <ul>
                                <li>
                                    <asp:Table ID="tblWallHeights" CssClass="tblTxtFields" runat="server">

                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblBackWallHeight" AssociatedControlID="txtBackWallHeight" runat="server" Text="Back Wall Height:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:TextBox ID="txtBackWallHeight" CssClass="txtField txtInput" onkeyup="checkQuestion2()" OnChange="checkQuestion2()" onblur="resetWalls()" OnFocus="highlightWallsHeight()" runat="server" MaxLength="3"></asp:TextBox>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:PlaceHolder ID="phBackHeights" runat="server" />
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:CheckBox ID="chkAutoBackWallHeight" runat="server" OnClick="checkQuestion2()" />
                                                <asp:Label ID="lblAutoBackWallHeightCheckBox" AssociatedControlID="chkAutoBackWallHeight" runat="server"></asp:Label>
                                                <asp:Label ID="lblAutoBackWallHeight" AssociatedControlID="chkAutoBackWallHeight" runat="server" Text="Auto Populate"></asp:Label>
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblFrontWallHeight" AssociatedControlID="txtFrontWallHeight" runat="server" Text="Front Wall Height:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:TextBox ID="txtFrontWallHeight" CssClass="txtField txtInput" onkeyup="checkQuestion2()" OnChange="checkQuestion2()" onblur="resetWalls()" OnFocus="highlightWallsHeight()" runat="server" MaxLength="3"></asp:TextBox>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:PlaceHolder ID="phFrontHeights" runat="server" />
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:CheckBox ID="chkAutoFrontWallHeight" runat="server" OnClick="checkQuestion2()" />
                                                <asp:Label ID="lblAutoFrontWallHeightCheckBox" AssociatedControlID="chkAutoFrontWallHeight" runat="server"></asp:Label>
                                                <asp:Label ID="lblAutoFrontWallHeight" AssociatedControlID="chkAutoFrontWallHeight" runat="server" Text="Auto Populate"></asp:Label>
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblRoofSlope" AssociatedControlID="txtRoofSlope" runat="server" Text="Roof Slope:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:TextBox ID="txtRoofSlope" CssClass="txtField txtInput" onkeyup="checkQuestion2()" OnChange="checkQuestion2()" runat="server" MaxLength="3"></asp:TextBox>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                            
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:CheckBox ID="chkAutoRoofSlope" runat="server" OnClick="checkQuestion2()" />
                                                <asp:Label ID="lblAutoRoofSlopeCheckBox" AssociatedControlID="chkAutoRoofSlope" runat="server"></asp:Label>
                                                <asp:Label ID="lblAutoRoofSlope" AssociatedControlID="chkAutoRoofSlope" runat="server" Text="Auto Populate"></asp:Label>
                                            </asp:TableCell>

                                        </asp:TableRow>

                                    </asp:Table>
                                </li>
                            </ul>            
                        </div> <%-- end .toggleContent --%>

                <asp:Button ID="Button1" Enabled="true" CssClass="btnSubmit float-right slidePanel" data-slide="#slide3" runat="server" Text="Next Question" />

            </div> 
            <%-- end #slide2 --%>

             <%-- QUESTION 3 - DOOR DETAILS
            ======================================== --%>

            <div id="slide3" class="slide">
                <h1>
                    <asp:Label ID="lblQuestion3" runat="server" Text="Would you like a door on your sunroom?"></asp:Label>
                </h1>        
                              
                <ul class="toggleOptions">
                    <asp:PlaceHolder ID="wallDoorOptions" runat="server">

                    

</asp:PlaceHolder>                    
        </ul>            

                <asp:Button ID="btnQuestion3"  Enabled="true" CssClass="btnSubmit float-right slidePanel" data-slide="#slide4" runat="server" Text="Next Question" />

            </div>
            <%-- end #slide3 --%>

        </div> <%-- end .slide-wrapper --%>

    </div> 
    <%-- end .slide-window --%>
    

    <%-- SLIDE PAGING (QUESTION NAVIGATION)
    ======================================== --%>
    <div id="paging-wrapper">    
        <div id="paging"> 
            <h2>Wall Specifications</h2>

            <ul>

                <div style="/*max-width:500px; max-height:500px; min-width:200px; min-height:200px; margin: auto auto;*/ position:inherit; /*padding-top:10%; padding-right:5%;*/ text-align:center; /*position:fixed; */top:0px; right:0px;" id="mySunroom"></div>

                <div style="display: none" id="pagerOne">
                    <li>
                            <a href="#" data-slide="#slide1" class="slidePanel">
                                <asp:Label ID="lblWallLengthsSlidePanel" runat="server" Text="Wall Lengths"></asp:Label>
                                <asp:Label ID="lblWallLengthsAnswer" runat="server" Text="Wall Lengths"></asp:Label>
                            </a>
                    </li>
                </div>

                <div style="display: none" id="pagerTwo">
                    <li>
                            <a href="#" data-slide="#slide2" class="slidePanel">
                                <asp:Label ID="lblWallHeightsSlidePanel" runat="server" Text="Wall Heights"></asp:Label>
                                <asp:Label ID="lblWallHeightsAnswer" runat="server" Text="Wall Heights"></asp:Label>
                            </a>
                    </li>
                </div>

                <div style="display: none" id="pagerThree">
                    <li>
                            <a href="#" data-slide="#slide3" class="slidePanel">
                                <asp:Label ID="lblQuestion3Pager" runat="server" Text="Door"></asp:Label>
                                <asp:Label ID="lblQuestion3PagerAnswer" runat="server" Text="Question 3 Answer"></asp:Label>
                            </a>
                    </li>
                </div>

 <%--               <div style="display: none" id="pagerFour">
                    <li>
                            <a href="#" data-slide="#slide4" class="slidePanel">
                                <asp:Label ID="Label27" runat="server" Text="Styling options"></asp:Label>
                                <asp:Label ID="lblQuestion4PagerAnswer" runat="server" Text="Question 4 Answer"></asp:Label>
                            </a>
                    </li>
                </div>

                <div style="display: none" id="pagerFive">
                    <li>
                            <a href="#" data-slide="#slide5" class="slidePanel">
                                <asp:Label ID="Label31" runat="server" Text="Foam protection"></asp:Label>
                                <asp:Label ID="lblQuestion5PagerAnswer" runat="server" Text="Question 5 Answer"></asp:Label>
                            </a>
                    </li>          
                </div>    
                  
                <div style="display: none" id="pagerSix">
                    <li>
                            <a href="#" data-slide="#slide6" class="slidePanel">
                                <asp:Label ID="Label1" runat="server" Text="Prefab floor"></asp:Label>
                                <asp:Label ID="lblQuestion6PagerAnswer" runat="server" Text="Question 6 Answer"></asp:Label>
                            </a>
                    </li>
                </div>

                <div style="display: none" id="pagerSeven">                
                    <li>
                            <a href="#" data-slide="#slide7" class="slidePanel">
                                <asp:Label ID="Label3" runat="server" Text="Roof"></asp:Label>
                                <asp:Label ID="lblQuestion7PagerAnswer" runat="server" Text="Question 7 Answer"></asp:Label>
                            </a>
                    </li>
                </div>

                <div style="display: none" id="pagerEight">
                    <li>
                            <a href="#" data-slide="#slide8" class="slidePanel">
                                <asp:Label ID="Label5" runat="server" Text="Layout"></asp:Label>
                                <asp:Label ID="lblQuestion8PagerAnswer" runat="server" Text="Question 8 Answer"></asp:Label>
                            </a>
                    </li>
                </div>--%>
            </ul>    
        </div> <%-- end #paging --%>
    </div>

    <%-- MINI CANVAS (HIGHLIGHTS CURRENT WALL)
    ======================================== --%>
    <!--Div tag to hold the canvas/grid-->
    
    <script>
/*CANVAS STUFF**********************************************************************************************/
        //var slideWindow = document.getElementById("paging");
        //slideWindow.appendChild(document.getElementById("mySunroom"));

        /* CREATE CANVAS */
        var canvas = d3.select("#mySunroom")            //Select the div tag with id "mySunroom"
                    .append("svg")                      //Add an svg tag to the selected div tag
                    .attr("width", 200)    //Set the width of the canvas/grid to MAX_CANVAS_WIDTH
                    .attr("height", 200); //Set the height of the canvas/grid to MAX_CANVAS_HEIGHT  
        var svgGrid = document.getElementById("mySunroom");     //create the svg grid on the canvas
        
        //Creates rectangle area to draw in based on max canvas dimensions
        var rect = canvas.append("rect")                //Draws a rectangle for the canvas/grid to sit in
                    .attr("width", 200)    //Sets the width for the canvas/grid
                    .attr("height", 200)  //Sets the height for the canvas/grid
                    .attr("fill", "#f6f6f6");              //Sets the color of the rectangle to light grey

        var lineArray = new Array();

        //draw the canvas with the lines
        for (var i = 0; i < lineList.length; i++) { //draw all the lines with the given attributes
            lineArray[i] = canvas.append("line")
                    .attr("x1", (coordList[i][0] / 5) * 2) //0 = x1
                    .attr("y1", (coordList[i][2] / 5) * 2) //1 = y1
                    .attr("x2", (coordList[i][1] / 5) * 2) //2 = x2
                    .attr("y2", (coordList[i][3] / 5) * 2); //3 = y2
            //lineArray[i].attr("mouseover", alert("hwllo"));
            
            if(coordList[i][4] === "E") //4 = wall facing
                lineArray[i].attr("stroke", "red");
            else
                lineArray[i].attr("stroke", "black");
        }

        //highlight each individual walls for length question
        function highlightWallsLength() {
            var wallNumber = (document.activeElement.id.substr(19,1)); //parse out the wall number from the id           

            lineArray[wallNumber - 1].attr("stroke", "cyan"); 
            lineArray[wallNumber - 1].attr("stroke-width", "2");
               
        }

        //reset wall colours onblur
        function resetWalls() {
            for (var i = 0; i < lineList.length; i++) {
                lineArray[i].attr("stroke-width", "1");
                if (coordList[i][4] === "E") //4 = wall facing
                    lineArray[i].attr("stroke", "red");
                else
                    lineArray[i].attr("stroke", "black");
            }
            if (document.getElementById("lowestPoint"))
                d3.selectAll("#lowestPoint").remove();
        }

        //highlight back and front walls for height question
        function highlightWallsHeight() {
            var textbox = (document.activeElement.id.substr(15, 1)); //parse out B or F (for back wall or front wall) from the id
            var southWalls = new Array();
            var lowestWall = 0; //arbitrary number
            var lowestIndex;
            var highestWall = 200; //arbitrary number
            var highestIndex;
            var index = -1; //invalid to determine if there is a wall or not
            //var typeOfWall;

            for (var i = 0; i < lineList.length; i++) {
                if (coordList[i][5] == "S") //5 = orientation
                    southWalls.push({ "y2": lineArray[i].attr("y2"), "number": i, "type": coordList[i][4] }); //populate south walls array
            }
            if (textbox === "B")
                index = getBackWall(southWalls);
            else { //if (textbox === "F")
                if (southWalls[southWalls.length - 1].type == "P")
                    index = getFrontWall(southWalls);
            }

            if (index >= 0) { //if valid index
                lineArray[index].attr("stroke", "cyan");
                lineArray[index].attr("stroke-width", "2");
            }
            else {
                highlightFrontPoint();
            }
        }

        //determine the back wall index
        function getBackWall(southWalls) {
            var lowestWall = 0; //arbitrary number
            var lowestIndex;
            for (var i = 0; i < southWalls.length; i++) {
                if (southWalls[i].y2 > lowestWall) {
                    lowestWall = southWalls[i].y2;
                    lowestIndex = southWalls[i].number;
                }
            }
            return lowestIndex;
        }

        //determine the front wall index
        function getFrontWall(southWalls) {
            var highestWall = 200; //arbitrary number
            var highestIndex;
            for (var i = 0; i < southWalls.length; i++) {
                if (southWalls[i].y2 < highestWall) {
                    highestWall = southWalls[i].y2;
                    highestIndex = southWalls[i].number;
                }
            }
            return highestIndex;
        }

        //highlight the front point if there is no front wall
        function highlightFrontPoint() {
            var lowestX = 0;
            var lowestY = 0;
            var circle;
            for (var i = 0; i < coordList.length; i++) {
                if (coordList[i][3] > lowestY) { //3 = y2 coordinate
                    lowestY = coordList[i][3]; //3 = y2 coordinate
                    lowestX = coordList[i][1]; //1 = x2 coordinate
                }
            }
            circle = canvas.append("circle")
                           .attr("cx", (lowestX / 5) * 2)
                           .attr("cy", (lowestY / 5) * 2)
                           .attr("r", 5) //radius
                           .style("fill", "cyan")
                           .attr("id", "lowestPoint");
        }

            
/*******************************************************************************************************/
    </script>
    <%-- Hidden input tags 
    ======================= --%>
<%-- %><input id="hidWallLengthsAndHeights" type="hidden" runat="server" /> wall length hidden fields will be created dynamically --%>
    <div id="hiddenFieldsDiv" runat="server"></div>
    <input id="hidProjection" type="hidden" runat="server" />
    <input id="hidFrontWallHeight" type="hidden" runat="server" />
    <input id="hidBackWallHeight" type="hidden" runat="server" />
    <input id="hidRoofSlope" type="hidden" runat="server" />
    <input id="hidDoorType" type="hidden" runat="server" />
    <input id="hidDoorColour" type="hidden" runat="server" />
    <input id="hidDoorHeight" type="hidden" runat="server" />
    <input id="hidSwingingDoor" type="hidden" runat="server" />
    <input id="hidWallDoorPlacement" type="hidden" runat="server" />
    <input id="hidWallDoorPosition" type="hidden" runat="server" />

    <%-- end hidden divs --%>

    

    <script>
        $(function () {
            $('.ulNavMain').children('a').removeClass('active');
            $('#lnkMainNavNewProject').addClass('active');
        });
    </script>
</asp:Content>

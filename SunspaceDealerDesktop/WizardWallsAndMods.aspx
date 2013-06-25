<%@ Page Title="New Project - Project Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WizardWallsAndMods.aspx.cs" Inherits="SunspaceDealerDesktop.WizardWallsAndMods" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <script src="Scripts/Validation.js"></script>
    <%-- Hidden div populating scripts 
    =================================== --%>
    <script>

        var wallCount = '<%= (int)Session["numberOfWalls"] %>'; //number of walls drawn by the user
        var lines = '<%= (string)Session["coordList"] %>'; //all the coordinates of all the lines
        var lineList = lines.substr(0, lines.length-1).split("/"); //a list of lines and their coordinates
        var coordList = new Array(); //new 2d array to store each individual coordinate and details of each line
        for (var i = 0; i < lineList.length; i++) { 
            coordList[i] = lineList[i].split(","); //populate the 2d array
        }

        function checkQuestion1() {

            //disable 'next slide' button until after validation (this is currently enabled for debugging purposes)
            document.getElementById('MainContent_btnQuestion1').disabled = false;
            //document.getElementById('MainContent_btnQuestion2').disabled = false;
            //document.getElementById('MainContent_btnQuestion3').disabled = false;

            //if ($('#MainContent_radWallLengths').is(':checked')) {

                //var lengthList = new Array();
                var isValid = true;
                var answer = "";

                //creating hidden fields dynamically using js (this is currently being done in codebehind)
                /*for (var i = 1; i <= wallCount; i++) {
                    if (!document.getElementById("MainContent_hidWall1Length")) {
                    var hidWall1Length = document.createElement("input");
                    hidWall1Length.type = "hidden";
                    hidWall1Length.id = "hidWall1Length";
                    hidWall1Length.value = document.getElementById("MainContent_txtWall1Length").value;//$('#MainContent_txtWall1Length').val();
                }*/

                for (var i = 1; i <= wallCount; i++) {
                    if (isNaN(document.getElementById("MainContent_txtWall" + (i) + "Length").value) || document.getElementById("MainContent_txtWall" + (i) + "Length").value <= 0)
                        isValid = false;
                }

                if (isValid) {
                    for (var i = 1; i <= wallCount; i++) {
                        document.getElementById("hidWall" + i + "Length").value = document.getElementById("MainContent_txtWall" + i + "Length").value;
                        answer += "Wall " + i + ": " + document.getElementById("hidWall" + i + "Length").value;
                    }
                    //Set answer on side pager and enable button
                    $('#MainContent_lblWallLengthsAnswer').text(answer);
                    document.getElementById('pagerOne').style.display = "inline";
                    document.getElementById('MainContent_btnQuestion1').disabled = false;
                }
                else {
                    //error styling or something
                    //Set answer on side pager and enable button
                    $('#MainContent_lblWallLengthsAnswer').text("Wall Lengths Invalid");
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

            //if ($('#MainContent_radWallLengths').is(':checked')) {

            //var lengthList = new Array();
            var isValid = true;
            var answer = "";

            //for (var i = 1; i <= wallCount; i++) {
            if (isNaN(document.getElementById("MainContent_txtBackWallHeight").value)
                || document.getElementById("MainContent_txtBackWallHeight").value <= 0
                || (isNaN(document.getElementById("MainContent_txtFrontWallHeight").value))
                || document.getElementById("MainContent_txtFrontWallHeight").value <= 0
                || (isNaN(document.getElementById("MainContent_txtRoofSlope").value))
                || document.getElementById("MainContent_txtRoofSlope").value <= 0)
                    isValid = false;
            //}


            if (isValid) {
                
                //for (var i = 1; i <= wallCount; i++) {
                document.getElementById("MainContent_hidBackWallHeight").value = document.getElementById("MainContent_txtBackWallHeight").value;
                document.getElementById("MainContent_hidFrontWallHeight").value = document.getElementById("MainContent_txtFrontWallHeight").value;
                document.getElementById("MainContent_hidRoofSlope").value = document.getElementById("MainContent_txtRoofSlope").value;
                answer += "Back Wall: " + document.getElementById("MainContent_hidBackWallHeight").value;
                answer += "Front Wall: " + document.getElementById("MainContent_hidFrontWallHeight").value;
                answer += "Roof Slope: " + document.getElementById("MainContent_hidRoofSlope").value;


                //}
                //Set answer on side pager and enable button
                $('#MainContent_lblWallHeightsAnswer').text(answer);
                document.getElementById('pagerTwo').style.display = "inline";
                document.getElementById('MainContent_btnQuestion2').disabled = false;
                
            }
            else {
                //error styling or something
                //Set answer on side pager and enable button
                $('#MainContent_lblWallHeightsAnswer').text("Wall Heights Invalid");
                document.getElementById('pagerTwo').style.display = "inline";
                document.getElementById('MainContent_btnQuestion2').disabled = false;
            }

            return false;
        }

        /*
        *****Needs handling for multiple doors with different styles*****
        Swing in or out
        Sliding left or right
        */
        function checkQuestion3() {

            if ($('#MainContent_radDoorYes').is(':checked')) {
                //Variable used to get current index of dropbox and its value
                var dropdownDOM = document.getElementById("MainContent_inFrac");
                var totalDoorDistance = document.getElementById("MainContent_txtWallDoorPosition").value + dropdownDOM.options[dropdownDOM.selectedIndex].value;
                
                document.getElementById("MainContent_hidDoorType").value = document.getElementById("MainContent_ddlDoorType").options[document.getElementById("MainContent_ddlDoorType").selectedIndex].value;                
                document.getElementById("MainContent_hidDoorColour").value = document.getElementById("MainContent_ddlDoorColour").options[document.getElementById("MainContent_ddlDoorColour").selectedIndex].value;
                document.getElementById("MainContent_hidDoorHeight").value = document.getElementById("MainContent_ddlDoorHeight").options[document.getElementById("MainContent_ddlDoorHeight").selectedIndex].value;
                document.getElementById("MainContent_hidSwingingDoor").value = $('#MainContent_radSwingingDoorYes').is(':checked');
                document.getElementById("MainContent_hidWallDoorPlacement").value = document.getElementById("MainContent_ddlWallDoorPlacement").options[document.getElementById("MainContent_ddlWallDoorPlacement").selectedIndex].value;
                document.getElementById("MainContent_hidWallDoorPosition").value = totalDoorDistance;               

                if (document.getElementById("MainContent_hidWallDoorPosition").value != 0) {

                    document.getElementById('MainContent_btnQuestion3').disabled = false;
                    $('#MainContent_lblQuestion3Pager').text("Door");
                    $('#MainContent_lblQuestion3PagerAnswer').text(document.getElementById("MainContent_ddlDoorType").options[document.getElementById("MainContent_ddlDoorType").selectedIndex].value);
                    document.getElementById('pagerThree').style.display = "inline";
                }
                else {
                    $('#MainContent_lblQuestion3Pager').text("Door");
                    $('#MainContent_lblQuestion3PagerAnswer').text("");
                    document.getElementById('pagerThree').style.display = "inline";
                }

            }
            else {
                document.getElementById('MainContent_btnQuestion3').disabled = false;
                $('#MainContent_lblQuestion3Pager').text("Door");
                $('#MainContent_lblQuestion3PagerAnswer').text("No Door");
                document.getElementById('pagerThree').style.display = "inline";
            }
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
                              
                <div id="tableWallLengths" class="tblWallLengths" runat="server">
                    <asp:Table ID="tblWallLengths" MinHeight="200px" runat="server">
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
           
                        <div class="tblWallLengths" runat="server">
                            <ul>
                                <li>
                                    <asp:Table ID="Table1" CssClass="tblTxtFields" runat="server">

                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblBackWallHeight" AssociatedControlID="txtBackWallHeight" runat="server" Text="Back Wall Height:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:TextBox ID="txtBackWallHeight" CssClass="txtField txtInput" onkeyup="checkQuestion2()" OnChange="checkQuestion2()" runat="server" MaxLength="3"></asp:TextBox>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:PlaceHolder ID="ddlBackHeights" runat="server" />
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblFrontWallHeight" AssociatedControlID="txtFrontWallHeight" runat="server" Text="Front Wall Height:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:TextBox ID="txtFrontWallHeight" CssClass="txtField txtInput" onkeyup="checkQuestion2()" OnChange="checkQuestion2()" runat="server" MaxLength="3"></asp:TextBox>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:PlaceHolder ID="ddlFrontHeights" runat="server" />
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblRoofSlope" AssociatedControlID="txtRoofSlope" runat="server" Text="Roof Slope:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:TextBox ID="txtRoofSlope" CssClass="txtField txtInput" onkeyup="checkQuestion2()" OnChange="checkQuestion2()" runat="server" MaxLength="3"></asp:TextBox>
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

                    <%-- DOOR YES --%>
                    <li>
                        <asp:RadioButton ID="radDoorYes" OnClick="checkQuestion3()" GroupName="question3" runat="server" />
                        <asp:Label ID="lblDoorYesRadio" AssociatedControlID="radDoorYes" runat="server"></asp:Label>
                        <asp:Label ID="lblDoorYes" AssociatedControlID="radDoorYes" runat="server" Text="Yes"></asp:Label>
           
                        <div class="toggleContent">
                            <ul>
                                <li>
                                    <h3>Enter door details:</h3>

                                    <asp:Table ID="tblDoorYesInfo" CssClass="tblTxtFields" runat="server">

                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblDoorType" AssociatedControlID="ddlDoorType" runat="server" Text="Type Of Door:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:DropDownList ID="ddlDoorType" OnChange="checkQuestion3()" GroupName="question3" runat="server" >
                                                    <asp:ListItem Text="Cabana" Value="Cabana"/>
                                                    <asp:ListItem Text="French" Value="French" />
                                                    <asp:ListItem Text="Patio" Value="Patio" />
                                                </asp:DropDownList>                                                
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblDoorColour" AssociatedControlID="ddlDoorColour" runat="server" Text="Door Colour:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:DropDownList ID="ddlDoorColour" OnChange="checkQuestion3()" GroupName="question3" runat="server" >
                                                    <asp:ListItem Text="Clear" Value="Clear" />
                                                    <asp:ListItem Text="Grey" Value="Grey" />
                                                    <asp:ListItem Text="Bronze" Value="Bronze" />
                                                </asp:DropDownList>
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblDoorHeight" AssociatedControlID="ddlDoorHeight" runat="server" Text="Door height:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:DropDownList ID="ddlDoorHeight" OnChange="checkQuestion3()" GroupName="question3" runat="server" >
                                                    <asp:ListItem Text="5'" Value="5"/>
                                                    <asp:ListItem Text="6'" Value="6"/>
                                                    <asp:ListItem Text="7'" Value="7" />
                                                    <asp:ListItem Text="8'" Value="8" />
                                                </asp:DropDownList>                                                
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblSwingingDoor" runat="server" Text="Swinging Door:" ></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:RadioButton ID="radSwingingDoorYes" checked="true" GroupName="Swinging" runat="server" />
                                                <asp:Label ID="lblSwingingDoorYesRadio" AssociatedControlID="radSwingingDoorYes" runat="server"></asp:Label>
                                                <asp:Label ID="lblSwingingDoorYes" AssociatedControlID="radSwingingDoorYes" runat="server" Text="&nbsp; Yes"></asp:Label>                                               
                                            </asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow>
                                            <asp:TableCell>
                                                
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:RadioButton ID="radSwingingDoorNo" GroupName="Swinging" runat="server" />
                                                <asp:Label ID="lblSwingingDoorNoRadio" AssociatedControlID="radSwingingDoorNo" runat="server"></asp:Label>
                                                <asp:Label ID="lblSwingingDoorNo" AssociatedControlID="radSwingingDoorNo" runat="server" Text="&nbsp; No"></asp:Label>
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow ID="WallDoorPlacement">
                                            <asp:TableCell>
                                                <asp:Label ID="lblCustomerCity" AssociatedControlID="ddlWallDoorPlacement" runat="server" Text="Which wall is the door in:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:DropDownList ID="ddlWallDoorPlacement" OnChange="checkQuestion3()" GroupName="question3" runat="server" >
                                                </asp:DropDownList>
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblWallDoorPosition" AssociatedControlID="txtWallDoorPosition" runat="server" Text="Inches from left side the wall:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:TextBox ID="txtWallDoorPosition" onkeyup="checkQuestion3()" CssClass="txtField txtInput" runat="server" MaxLength="3"></asp:TextBox>
                                            </asp:TableCell>
                                            <asp:TableCell >
                                                <asp:PlaceHolder ID="inchesSpecifics" runat="server" />
                                            </asp:TableCell>
                                        </asp:TableRow>

                                    </asp:Table>
                                </li>
                            </ul>            
                        </div> <%-- end .toggleContent --%>
                    </li> <%-- end 'complete sunroom' option --%>

                    <%-- DOOR NO --%>
                    <li>
                        <asp:RadioButton ID="radDoorNo" OnClick="checkQuestion3()" GroupName="question3" runat="server" />
                        <asp:Label ID="lblDoorNoRadio" AssociatedControlID="radDoorNo" runat="server"></asp:Label>
                        <asp:Label ID="lblDoorNo" AssociatedControlID="radDoorNo" runat="server" Text="No"></asp:Label>
                    </li> <%-- end 'existing customer' option --%>

                </ul> <%-- end .toggleOptions --%>

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
    <div style="max-width:500px; max-height:500px; min-width:200px; min-height:200px; margin: auto auto; position:inherit; padding-top:10%; padding-right:5%; /*position:fixed; */top:0px; right:0px;" id="mySunroom"></div>
    <script>
/*CANVAS STUFF**********************************************************************************************/
        var slideWindow = document.getElementById("slide-window");
        slideWindow.appendChild(document.getElementById("mySunroom"));

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

        var lineArray = new Array(wallCount);

        //Local variable to store all the line information
        for (var i = 0; i < lineList.length; i++) { //draw all the lines with the given attributes
            lineArray[i] = canvas.append("line")
                    .attr("x1", (coordList[i][0] / 5) * 2)
                    .attr("y1", (coordList[i][2] / 5) * 2)
                    .attr("x2", (coordList[i][1] / 5) * 2)
                    .attr("y2", (coordList[i][3] / 5) * 2);
                    //.attr("id", "wall" + i);
                    //line.attr("onmouseover", alert("hwllo"));
            
            if(coordList[i][4] === "E")
                lineArray[i].attr("stroke", "red");
            else
                lineArray[i].attr("stroke", "black");
        }

        function highlightWall() {
            var wallNumber = (document.activeElement.id.substr(19,1) - 1);
            
            for (var i = 0; i < wallCount; i++) {
                if (coordList[i][4] == "P") {
                    if (i == wallNumber) {

                        lineArray[i].attr("stroke", "yellow");
                        lineArray[i].attr("stroke-width", "2");
                    }
                    else {
                        lineArray[i].attr("stroke", "black");
                        lineArray[i].attr("stroke-width", "1");
                    }
                }
            }
        }
/*******************************************************************************************************/
    </script>
    <%-- Hidden input tags 
    ======================= --%>
<%-- %><input id="hidWallLengthsAndHeights" type="hidden" runat="server" /> wall length hidden fields will be created dynamically --%>
    <div id="hiddenFieldsDiv" runat="server">
        
    </div>
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

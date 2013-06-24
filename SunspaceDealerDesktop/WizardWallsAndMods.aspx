﻿<%@ Page Title="New Project - Project Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WizardWallsAndMods.aspx.cs" Inherits="SunspaceDealerDesktop.WizardWallsAndMods" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <script src="Scripts/Validation.js"></script>
    <%-- Hidden div populating scripts 
    =================================== --%>
    <script>

        var wallCount = '<%= (int)Session["numberOfWalls"] %>';
        var lines = '<%= (string)Session["coordList"] %>';
        var lineList = lines.substr(0, -1).split("/");
        var coordList = new Array();
        for (var i = 0; i < lineList.length; i++) {
            coordList[i] = lineList[i].split(",");
        }



        //document.getElementById("btnQuestion1").onclick = checkQuestion1();

        //alert(wallCount);
                <%                    
        
                    ArrayList walls = new ArrayList();
                    walls.Add("1");
                    walls.Add("2");

                    slide4Repeater.DataSource = walls;
                    slide4Repeater.DataBind();
                    
                    ArrayList mods = new ArrayList();
                    walls.Add("1");
                    walls.Add("2");                                                            
        
                    DropDownList ddlInFrac = new DropDownList();
                    ddlInFrac.ID = "inFrac";
                    ListItem lst0 = new ListItem("---", "", true);
                    ListItem lst18 = new ListItem("1/8", ".125");
                    ListItem lst14 = new ListItem("1/4", ".25");
                    ListItem lst38 = new ListItem("3/8", ".375");
                    ListItem lst12 = new ListItem("1/2", ".5");
                    ListItem lst58 = new ListItem("5/8", ".625");
                    ListItem lst34 = new ListItem("3/4", ".75");
                    ListItem lst78 = new ListItem("7/8", ".875");
                    ddlInFrac.Items.Add(lst0);
                    ddlInFrac.Items.Add(lst18);
                    ddlInFrac.Items.Add(lst14);
                    ddlInFrac.Items.Add(lst38);
                    ddlInFrac.Items.Add(lst12);
                    ddlInFrac.Items.Add(lst58);
                    ddlInFrac.Items.Add(lst34);
                    ddlInFrac.Items.Add(lst78);
                    inchesSpecifics.Controls.Add(ddlInFrac);
                    
                    //Used to dynamically add values to ddlWallDoorPlacement
                    for(int i = 1; i <= (int)Session["numberOfWalls"]; i++)
                    {
                        ListItem numberOfWalls = new ListItem(Convert.ToString(i), Convert.ToString(i));
                        ddlWallDoorPlacement.Items.Add(numberOfWalls);                        
                    }
                    
                    for(int i = 1; i <= (int)Session["numberOfWalls"]; i++) //numberOfWalls is hard-coded to be 5 right now
                    {
                        TableRow row = new TableRow();
                        TableCell cell1 = new TableCell();
                        TableCell cell2 = new TableCell();
                        TableCell cell3 = new TableCell();
                        Label lblWallNumber = new Label();
                        TextBox txtWallLength = new TextBox();
                        DropDownList ddlInchFractions = new DropDownList();

                        ddlInchFractions.Items.Add(lst0);
                        ddlInchFractions.Items.Add(lst18);
                        ddlInchFractions.Items.Add(lst14);
                        ddlInchFractions.Items.Add(lst38);
                        ddlInchFractions.Items.Add(lst12);
                        ddlInchFractions.Items.Add(lst58);
                        ddlInchFractions.Items.Add(lst34);
                        ddlInchFractions.Items.Add(lst78);
                        
                        lblWallNumber.Text = "Wall " + i + " length: ";
                        lblWallNumber.ID = "lblWall" + i + "Length";
                        lblWallNumber.AssociatedControlID = "txtWall" + i + "Length";

                        txtWallLength.ID = "txtWall" + i + "Length";
                        txtWallLength.CssClass = "txtField txtInput";
                        txtWallLength.MaxLength = 3;
                        //txtWallLength.TextChanged += new EventHandler(txtWallLengths_TextChanged);
                        txtWallLength.Attributes.Add("onkeyup", "checkQuestion1()");
                        txtWallLength.Attributes.Add("OnChange", "checkQuestion1()");
                        
                        cell1.Controls.Add(lblWallNumber);
                        cell2.Controls.Add(txtWallLength);
                        cell3.Controls.Add(ddlInchFractions);

                        tblWallLengths.Rows.Add(row);
                        
                        row.Cells.Add(cell1);
                        row.Cells.Add(cell2);
                        row.Cells.Add(cell3);
                    }
                  %>

        
        $(document).ready(function() {
        });

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

            //alert("here i am");
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
    <div class="slide-window"  >

        <div class="slide-wrapper">
            
            <%-- QUESTION 1 - Wall Lengths
            ======================================== --%>
            <div id="slide1" class="slide">

                <h1>
                    <asp:Label ID="lblQuestion1" runat="server" Text="Please enter the wall lengths"></asp:Label>
                </h1>        
                              
                <ul class="toggleOptions">

                    <%-- Wall Lengths --%>
                    <li>
                        <asp:RadioButton ID="radWallLengths" GroupName="question1" runat="server" />
                        <asp:Label ID="lblWallLengthsRadio" AssociatedControlID="radWallLengths" runat="server"></asp:Label>
                        <asp:Label ID="lblWallLengths" AssociatedControlID="radWallLengths" runat="server" Text="Wall Lengths"></asp:Label>
           
                        <div class="toggleContent">
                            <ul>
                                <li>
                                    <asp:Table ID="tblWallLengths" CssClass="tblTxtFields" runat="server"></asp:Table>
                                </li>
                            </ul>            
                        </div> <%-- end .toggleContent --%>
                    </li> <%-- end 'complete sunroom' option --%>
                </ul> <%-- end .toggleOptions --%>

                <asp:Button ID="btnQuestion1" Enabled="true" CssClass="btnSubmit float-right slidePanel" data-slide="#slide2" runat="server" Text="Next Question" />

            </div> 
            <%-- end #slide1 --%>

            <%-- QUESTION 2 - Wall Heights
            ======================================== --%>
            <div id="slide2" class="slide">

                <h1>
                    <asp:Label ID="lblQuestion2" runat="server" Text="Please enter the wall heights"></asp:Label>
                </h1>        
                              
                <ul class="toggleOptions">

                    <%-- Wall Lengths --%>
                    <li>
                        <asp:RadioButton ID="radWallHeights" GroupName="question2" runat="server" />
                        <asp:Label ID="lblWallHeightsRadio" AssociatedControlID="radWallHeights" runat="server"></asp:Label>
                        <asp:Label ID="lblWallHeights" AssociatedControlID="radWallHeights" runat="server" Text="Wall Heights"></asp:Label>
           
                        <div class="toggleContent">
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
                                                <asp:DropDownList ID="ddlInchFractions" CssClass="" runat="server" >
                                                    <%-- there must be a better way to call a dropdown list from multiple places... --%>
                                                    <asp:ListItem Text="---" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="1/8" Value="1/8"></asp:ListItem>
                                                    <asp:ListItem Text="1/4" Value="1/4"></asp:ListItem>
                                                    <asp:ListItem Text="3/8" Value="3/8"></asp:ListItem>
                                                    <asp:ListItem Text="1/2" Value="1/2"></asp:ListItem>
                                                    <asp:ListItem Text="5/8" Value="5/8"></asp:ListItem>
                                                    <asp:ListItem Text="3/4" Value="3/4"></asp:ListItem>
                                                    <asp:ListItem Text="7/8" Value="7/8"></asp:ListItem>
                                                </asp:DropDownList>
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
                                                <asp:DropDownList ID="DropDownList1" CssClass="" runat="server" >
                                                    <%-- there must be a better way to call a dropdown list from multiple places... --%>
                                                    <asp:ListItem Text="---" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="1/8" Value="1/8"></asp:ListItem>
                                                    <asp:ListItem Text="1/4" Value="1/4"></asp:ListItem>
                                                    <asp:ListItem Text="3/8" Value="3/8"></asp:ListItem>
                                                    <asp:ListItem Text="1/2" Value="1/2"></asp:ListItem>
                                                    <asp:ListItem Text="5/8" Value="5/8"></asp:ListItem>
                                                    <asp:ListItem Text="3/4" Value="3/4"></asp:ListItem>
                                                    <asp:ListItem Text="7/8" Value="7/8"></asp:ListItem>
                                                </asp:DropDownList>
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
                    </li> <%-- end 'complete sunroom' option --%>

                </ul> <%-- end .toggleOptions --%>

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

            <%-- QUESTION 4 - WALL DETAILS
            ======================================== --%>
            <div id="slide4" class="slide">
                <h1>
                    <asp:Label ID="lblQuestion4" runat="server" Text="Wall Details"></asp:Label>
                </h1>        
                
                <asp:Repeater id="slide4Repeater" runat="server">
                    <HeaderTemplate>
                        <ul class="toggleOptions">
                    </HeaderTemplate>

                    <ItemTemplate>
                    <li>
                        <asp:RadioButton ID="radWall1" GroupName="question4" runat="server" />
                        <asp:Label ID="Label7" AssociatedControlID="radWall1" runat="server"></asp:Label>
                        <asp:Label ID="Label8" AssociatedControlID="radWall1" runat="server" Text="Wall 1"></asp:Label>
           
                        <div class="toggleContent">
                            <ul>
                                <li> 
                                    <asp:Label ID="Label11" AssociatedControlID="ddlNumberOfMods" runat="server" Text="Number of mods:"></asp:Label>
                                            
                                    <asp:DropDownList ID="ddlNumberOfMods" GroupName="question3" runat="server" >
                                        <asp:ListItem Text="1" Value="1"/>
                                        <asp:ListItem Text="2" Value="2"/>
                                        <asp:ListItem Text="3" Value="3"/>
                                        <asp:ListItem Text="4" Value="4"/>
                                        <asp:ListItem Text="5" Value="5"/>
                                        <asp:ListItem Text="6" Value="6"/>
                                        <asp:ListItem Text="7" Value="7"/>
                                        <asp:ListItem Text="8" Value="8"/>
                                    </asp:DropDownList>
                                    <ul class="toggleOptions">
                                    <li>
                                        <asp:RadioButton ID="radMod1" GroupName="questionMod4" runat="server" />
                                        <asp:Label ID="Label12" AssociatedControlID="radMod1" runat="server"></asp:Label>
                                        <asp:Label ID="Label13" AssociatedControlID="radMod1" runat="server" Text="Mod 1"></asp:Label>  
           
                                        <div class="toggleContent">
                                            <ul>
                                                <li> 
                                                        <asp:TextBox>This is working</asp:TextBox>
                                                </li>
                                            </ul>
                                        </div>
                                        </li>
                                    <li>
                                        <asp:RadioButton ID="radMod2" GroupName="questionMod4" runat="server" />
                                        <asp:Label ID="Label14" AssociatedControlID="radMod2" runat="server"></asp:Label>
                                        <asp:Label ID="Label15" AssociatedControlID="radMod2" runat="server" Text="Mod 2"></asp:Label>  
           
                                        <div class="toggleContent">
                                            <ul>
                                                <li> 
                                                        <asp:TextBox>This is working</asp:TextBox>
                                                </li>
                                            </ul>
                                        </div>
                                    </li>
                                    </ul>
                                </li>
                            </ul> 
                        </div> <%-- end .toggleContent --%>
                    </li> <%-- end 'complete sunroom' option --%>
                </ItemTemplate>

                <FooterTemplate>
                    </ul>
                </FooterTemplate>

                </asp:Repeater>

                <%--<ul class="toggleOptions">

                    <li>
                        <asp:RadioButton ID="radWall1" GroupName="question4" runat="server" />
                        <asp:Label ID="Label1" AssociatedControlID="radWall1" runat="server"></asp:Label>
                        <asp:Label ID="Label2" AssociatedControlID="radWall1" runat="server" Text="Wall 1"></asp:Label>
           
                        <div class="toggleContent">
                            <ul>
                                <li> 
                                                <asp:Label ID="lblNumberOfMods" AssociatedControlID="ddlNumberOfMods" runat="server" Text="Number of mods:"></asp:Label>
                                            
                                                <asp:DropDownList ID="ddlNumberOfMods" GroupName="question3" runat="server" >
                                                    <asp:ListItem Text="1" Value="1"/>
                                                    <asp:ListItem Text="2" Value="2"/>
                                                    <asp:ListItem Text="3" Value="3"/>
                                                    <asp:ListItem Text="4" Value="4"/>
                                                    <asp:ListItem Text="5" Value="5"/>
                                                    <asp:ListItem Text="6" Value="6"/>
                                                    <asp:ListItem Text="7" Value="7"/>
                                                    <asp:ListItem Text="8" Value="8"/>
                                                </asp:DropDownList>
                                                <ul class="toggleOptions">
                                                <li>
                                                    <asp:RadioButton ID="radMod1" GroupName="questionMod4" runat="server" />
                                                    <asp:Label ID="Label5" AssociatedControlID="radMod1" runat="server"></asp:Label>
                                                    <asp:Label ID="Label6" AssociatedControlID="radMod1" runat="server" Text="Mod 1"></asp:Label>  
           
                                                    <div class="toggleContent">
                                                        <ul>
                                                            <li id="Mod1Controls"> 
                                                                 <asp:TextBox>This is working</asp:TextBox>
                                                            </li>
                                                        </ul>
                                                    </div>
                                                 </li>
                                                <li>
                                                    <asp:RadioButton ID="radMod2" GroupName="questionMod4" runat="server" />
                                                    <asp:Label ID="Label9" AssociatedControlID="radMod2" runat="server"></asp:Label>
                                                    <asp:Label ID="Label10" AssociatedControlID="radMod2" runat="server" Text="Mod 2"></asp:Label>  
           
                                                    <div class="toggleContent">
                                                        <ul>
                                                            <li> 
                                                                 <asp:TextBox>This is working</asp:TextBox>
                                                            </li>
                                                        </ul>
                                                    </div>
                                                </li>
                                               </ul>
                                </li>
                            </ul> 
                        </div>
                    </li>

                    <li>
                        <asp:RadioButton ID="radWall2" GroupName="question4" runat="server" />
                        <asp:Label ID="Label3" AssociatedControlID="radWall2" runat="server"></asp:Label>
                        <asp:Label ID="Label4" AssociatedControlID="radWall2" runat="server" Text="Wall 2"></asp:Label>
                        
                        <div class="toggleContent">
                            <ul>
                                <li> 
                                </li>
                            </ul> 
                        </div> 
                    </li> 

                </ul>--%>

                <asp:Button ID="btnQuestion4"  Enabled="true" CssClass="btnSubmit float-right slidePanel" data-slide="#slide5" runat="server" Text="Next Question" />

            </div><%-- end #slide4 --%>
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

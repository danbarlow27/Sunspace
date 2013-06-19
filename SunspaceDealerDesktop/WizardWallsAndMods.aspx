<%@ Page Title="New Project - Project Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WizardWallsAndMods.aspx.cs" Inherits="SunspaceDealerDesktop.WizardWallsAndMods" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <script src="Scripts/Validation.js"></script>
    <%-- Hidden div populating scripts 
    =================================== --%>
    <script>

                <%
        
                    //TableRow row = new TableRow();
                    //TableCell cell1 = new TableCell();
                    //TableCell cell2 = new TableCell();
                    //TableCell cell3 = new TableCell();
                    //Label lblWallNumber = new Label();
                    //TextBox txtWallLength = new TextBox();
                    //DropDownList ddlInchFractions = new DropDownList();
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
                    //ddlInchFractions.Items.Add(lst0);
                    //ddlInchFractions.Items.Add(lst18);
                    //ddlInchFractions.Items.Add(lst14);
                    //ddlInchFractions.Items.Add(lst38);
                    //ddlInchFractions.Items.Add(lst12);
                    //ddlInchFractions.Items.Add(lst58);
                    //ddlInchFractions.Items.Add(lst34);
                    //ddlInchFractions.Items.Add(lst78);

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
                        txtWallLength.TextChanged += new EventHandler(txtWallLengths_TextChanged);
                        txtWallLength.Attributes.Add("onkeyup", "checkQuestion1()");
                        
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
            //var wallCount = '<% //Session["numberOfWalls"]; %>';
            //alert(wallCount);
        });
        

        function checkQuestion1() {

            alert("SUCCESS!");
            //disable 'next slide' button until after validation
            document.getElementById('MainContent_btnQuestion1').disabled = false;
            document.getElementById('MainContent_btnQuestion2').disabled = false;
            document.getElementById('MainContent_btnQuestion3').disabled = false;

            if ($('#MainContent_radWallLengths').is(':checked')) {
                document.getElementById("MainContent_hidWallLengthsAndHeights").value = $('#MainContent_txtWall1Length').val();
                //document.getElementById("MainContent_hidLastName").value = $('#MainContent_txtCustomerLastName').val();
                //document.getElementById("MainContent_hidAddress").value = $('#MainContent_txtCustomerAddress').val();
                //document.getElementById("MainContent_hidCity").value = $('#MainContent_txtCustomerCity').val();
                //document.getElementById("MainContent_hidZip").value = $('#MainContent_txtCustomerZip').val();
                //document.getElementById("MainContent_hidPhone").value = $('#MainContent_txtCustomerPhone').val();

                //Make sure the text boxes aren't blank
                if (document.getElementById("MainContent_hidWallLengthsAndHeights").value != "" ) {// &&
                    //document.getElementById("MainContent_hidLastName").value != "" &&
                    //document.getElementById("MainContent_hidAddress").value != "" &&
                    //document.getElementById("MainContent_hidCity").value != "" &&
                    //document.getElementById("MainContent_hidZip").value != "" &&
                    //document.getElementById("MainContent_hidPhone").value != "") {

                    //var lengthCheck = document.getElementById("MainContent_hidPhone").value;

                    //if (lengthCheck.length == 10) {
                    //    var validPhone = validatePhone(document.getElementById("MainContent_hidPhone").value);
                    //    console.log(validPhone);
                    //}

                    //var zipCode = document.getElementById("MainContent_hidZip").value;

                    //if (isNaN(zipCode) || zipCode.length < 5) {
                    //    console.log("invalid zip");
                    //}
                    //else {
                    //    console.log("valid zip");
                    //}

                    ////Set answer to 'new' on side pager and enable button
                    //$('#MainContent_lblSpecsProjectTypeAnswer').text("New");
                    //document.getElementById('pagerOne').style.display = "inline";
                    //document.getElementById('MainContent_btnQuestion1').disabled = false;
                }
                else {
                    //error styling or something
                }
            }
            //else if ($('#MainContent_radExistingCustomer').is(':checked')) {
            //    document.getElementById("MainContent_ddlExistingCustomer").value = $('#MainContent_ddlCustomerFirstName').val();

            //    if (document.getElementById("MainContent_ddlExistingCustomer").value != "Choose a Customer...") {
            //        //valid, so update pager and enable button
            //        $('#MainContent_lblSpecsProjectTypeAnswer').text("Existing");
            //        document.getElementById('pagerOne').style.display = "inline";
            //        document.getElementById('MainContent_btnQuestion1').disabled = false;
            //    }
            //}

            return false;
        }
        function checkQuestion3() {
            if ($('#MainContent_radDoorYes').is(':checked')) {
                //Variable used to get current index of dropbox and its value
                var dropdownDOM = document.getElementById("MainContent_inFrac");
                var totalDoorDistance = document.getElementById("MainContent_txtWallDoorPosition").value + dropdownDOM.options[dropdownDOM.selectedIndex].value;
                
                document.getElementById("MainContent_hidDoorType").value = document.getElementById("MainContent_ddlDoorType").options[document.getElementById("MainContent_ddlDoorType").selectedIndex].value;
                document.getElementById("MainContent_hidDoorColour").value = document.getElementById("MainContent_ddlDoorColour").options[document.getElementById("MainContent_ddlDoorColour").selectedIndex].value;
                document.getElementById("MainContent_hidSwingingDoor").value = $('#MainContent_radSwingingDoorYes').is(':checked');
                document.getElementById("MainContent_hidWallDoorPlacement").value = document.getElementById("MainContent_ddlWallDoorPlacement").options[document.getElementById("MainContent_ddlWallDoorPlacement").selectedIndex].value;
                document.getElementById("MainContent_hidWallDoorPosition").value = totalDoorDistance;
                
                //alert(document.getElementById("MainContent_ddlWallDoorPlacement").options[document.getElementById("MainContent_ddlWallDoorPlacement").selectedIndex].value);
                if(document.getElementById("MainContent_hidDoorType").value

                if (document.getElementById("MainContent_hidWallDoorPosition").value != "") {

                    document.getElementById('MainContent_btnQuestion5').disabled = true;

                    if ($('#MainContent_radFoamProtectedYes').is(':checked')) {
                        document.getElementById('MainContent_btnQuestion5').disabled = false;
                        $('#MainContent_lblQuestion5PagerAnswer').text("Yes");
                        document.getElementById('pagerFive').style.display = "inline";
                        document.getElementById("MainContent_hidFoamProtected").value = "Yes";
                    }
                    else if ($('#MainContent_radFoamProtectedNo').is(':checked')) {
                        document.getElementById('MainContent_btnQuestion5').disabled = false;
                        $('#MainContent_lblQuestion5PagerAnswer').text("No");
                        document.getElementById('pagerFive').style.display = "inline";
                        document.getElementById("MainContent_hidFoamProtected").value = "No";
                    }
                    else {
                        //no selection, errors
                    }
                }
                else {
                    //error styling or something
                }
            }
            else {
                //document.getElementById("MainContent_hidPhone").value = $('#MainContent_radDoorYes').val();
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

                                    <asp:Table ID="tblWallLengths" CssClass="tblTxtFields" runat="server">

                                        <%--<asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblWall1Length" AssociatedControlID="txtWall1Length" runat="server" Text="Wall 1 Length:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:TextBox ID="txtWall1Length" CssClass="txtField txtInput" onkeyup="checkQuestion1()" OnChange="checkQuestion1()" runat="server" MaxLength="3"></asp:TextBox>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:DropDownList ID="ddlInchFractions" CssClass="" runat="server" >
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
                                        </asp:TableRow>--%>

                                    </asp:Table>
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

                                        <%--<asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblWall1Length" AssociatedControlID="txtWall1Length" runat="server" Text="Wall 1 Length:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:TextBox ID="txtWall1Length" CssClass="txtField txtInput" onkeyup="checkQuestion1()" OnChange="checkQuestion1()" runat="server" MaxLength="3"></asp:TextBox>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:DropDownList ID="ddlInchFractions" CssClass="" runat="server" >
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
                                        </asp:TableRow>--%>

                                    </asp:Table>
                                </li>
                            </ul>            
                        </div> <%-- end .toggleContent --%>
                    </li> <%-- end 'complete sunroom' option --%>

                </ul> <%-- end .toggleOptions --%>

                <asp:Button ID="Button1" Enabled="true" CssClass="btnSubmit float-right slidePanel" data-slide="#slide3" runat="server" Text="Next Question" />

            </div> 
            <%-- end #slide1 --%>

             <%-- QUESTION 3 - DOOR DETAILS
            ======================================== --%>

            <div id="slide3" class="slide">
                <h1>
                    <asp:Label ID="lblQuestion3" runat="server" Text="Would you like a door on your sunroom?"></asp:Label>
                </h1>        
                              
                <ul class="toggleOptions">

                    <%-- DOOR YES --%>
                    <li>
                        <asp:RadioButton ID="radDoorYes" GroupName="question3" runat="server" />
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
                                                <asp:DropDownList ID="ddlDoorType" GroupName="question3" runat="server" >
                                                    <asp:ListItem Text="------" Value="0"/>
                                                    <asp:ListItem Text="Cabana" Value="Cabana"/>
                                                    <asp:ListItem Text="Patio" Value="Patio" />
                                                </asp:DropDownList>                                                
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblDoorColour" AssociatedControlID="ddlDoorColour" runat="server" Text="Door Colour:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:DropDownList ID="ddlDoorColour" GroupName="question3" runat="server" >
                                                    <asp:ListItem Text="------" Value="0" />
                                                    <asp:ListItem Text="Clear" Value="Clear" />
                                                    <asp:ListItem Text="Grey" Value="Grey" />
                                                    <asp:ListItem Text="Bronze" Value="Bronze" />
                                                </asp:DropDownList>
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblSwingingDoor" runat="server" Text="Swinging Door:" ></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:RadioButton ID="radSwingingDoorYes" GroupName="question3" runat="server" />
                                                <asp:Label ID="lblSwingingDoorYesRadio" AssociatedControlID="radSwingingDoorYes" runat="server"></asp:Label>
                                                <asp:Label ID="lblSwingingDoorYes" AssociatedControlID="radSwingingDoorYes" runat="server" Text="&nbsp; Yes"></asp:Label>                                               
                                            </asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow>
                                            <asp:TableCell>
                                                
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:RadioButton ID="radSwingingDoorNo" GroupName="question3" runat="server" />
                                                <asp:Label ID="lblSwingingDoorNoRadio" AssociatedControlID="radSwingingDoorNo" runat="server"></asp:Label>
                                                <asp:Label ID="lblSwingingDoorNo" AssociatedControlID="radSwingingDoorNo" runat="server" Text="&nbsp; No"></asp:Label>
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow ID="WallDoorPlacement">
                                            <asp:TableCell>
                                                <asp:Label ID="lblCustomerCity" AssociatedControlID="ddlWallDoorPlacement" runat="server" Text="Which wall is the door in:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:DropDownList ID="ddlWallDoorPlacement" GroupName="question3" runat="server" >
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
                        <asp:RadioButton ID="radDoorNo" GroupName="question3" runat="server" />
                        <asp:Label ID="lblDoorNoRadio" AssociatedControlID="radDoorNo" runat="server"></asp:Label>
                        <asp:Label ID="lblDoorNo" AssociatedControlID="radDoorNo" runat="server" Text="No"></asp:Label>
                    </li> <%-- end 'existing customer' option --%>

                </ul> <%-- end .toggleOptions --%>

                <asp:Button ID="btnQuestion3"  Enabled="true" CssClass="btnSubmit float-right slidePanel" data-slide="#slide3" runat="server" Text="Next Question" />

            </div><%-- end #slide3 --%>

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
                                <asp:Label ID="lblProjectTag" runat="server" Text="Project tag"></asp:Label>
                                <asp:Label ID="lblWallHeightsAnswer" runat="server" Text="Wall Heights"></asp:Label>
                            </a>
                    </li>
                </div>

<%--                 <div style="display: none" id="pagerThree">
                    <li>
                            <a href="#" data-slide="#slide3" class="slidePanel">
                                <asp:Label ID="lblDoor" runat="server" Text="Door"></asp:Label>
                                <asp:Label ID="lblDoorTypeAnswer" runat="server" Text="Question 3 Answer"></asp:Label>
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
    <input id="hidTypeOfDoor" type="hidden" runat="server" />
    <input id="hidDoorColour" type="hidden" runat="server" />
    <input id="hidSwingingDoor" type="hidden" runat="server" />
    <input id="hidWallDoorPlacement" type="hidden" runat="server" />
    <input id="hidWallDoorPosition" type="hidden" runat="server" />
    <%--<input id="hidFirstName" type="hidden" runat="server" />
    <input id="hidLastName" type="hidden" runat="server" />
    <input id="hidAddress" type="hidden" runat="server" />
    <input id="hidCity" type="hidden" runat="server" />
    <input id="hidZip" type="hidden" runat="server" />
    <input id="hidPhone" type="hidden" runat="server" />
   
    <input id="hidProjectTag" type="hidden" runat="server" />
       
    <input id="hidProjectType" type="hidden" runat="server" />
    <input id="hidModelNumber" type="hidden" runat="server" />

    <input id="hidKneewallType" type="hidden" runat="server" />
    <input id="hidKneewallColour" type="hidden" runat="server" />
    <input id="hidKneewallHeight" type="hidden" runat="server" />
    <input id="hidTransomType" type="hidden" runat="server" />
    <input id="hidTransomColour" type="hidden" runat="server" />
    <input id="hidTransomHeight" type="hidden" runat="server" />
    <input id="hidInteriorColour" type="hidden" runat="server" />
    <input id="hidInteriorSkin" type="hidden" runat="server" />
    <input id="hidExteriorColour" type="hidden" runat="server" />
    <input id="hidExteriorSkin" type="hidden" runat="server" />

    <input id="hidFoamProtected" type="hidden" runat="server" />

    <input id="hidPrefabFloor" type="hidden" runat="server" />

    <input id="hidRoof" type="hidden" runat="server" />
    <input id="hidRoofType" type="hidden" runat="server" />

    <input id="hidLayoutSelection" type="hidden" runat="server" />--%>

    <%-- end hidden divs --%>

    

    <script>
        $(function () {
            $('.ulNavMain').children('a').removeClass('active');
            $('#lnkMainNavNewProject').addClass('active');
        });
    </script>
</asp:Content>

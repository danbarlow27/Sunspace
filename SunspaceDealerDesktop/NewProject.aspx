<%@ Page Title="New Project - Project Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewProject.aspx.cs" Inherits="SunspaceWizard._Default" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <%-- Hidden div populating scripts 
    =================================== --%>
    <script>       

        function checkQuestion1() {
            //disable 'next slide' button until after validation
            document.getElementById('MainContent_btnQuestion1').disabled=true;

            if ($('#MainContent_radNewCustomer').is(':checked'))
            {
                document.getElementById("MainContent_hidFirstName").value = $('#MainContent_txtCustomerFirstName').val();
                document.getElementById("MainContent_hidLastName").value = $('#MainContent_txtCustomerLastName').val();
                document.getElementById("MainContent_hidAddress").value = $('#MainContent_txtCustomerAddress').val();
                document.getElementById("MainContent_hidCity").value = $('#MainContent_txtCustomerCity').val();
                document.getElementById("MainContent_hidZip").value = $('#MainContent_txtCustomerZip').val();
                document.getElementById("MainContent_hidPhone").value = $('#MainContent_txtCustomerPhone').val();

                //Make sure the text boxes aren't blank
                if (document.getElementById("MainContent_hidFirstName").value != "" &&
                    document.getElementById("MainContent_hidLastName").value != "" &&
                    document.getElementById("MainContent_hidAddress").value != "" &&
                    document.getElementById("MainContent_hidCity").value != "" &&
                    document.getElementById("MainContent_hidZip").value != "" &&
                    document.getElementById("MainContent_hidPhone").value != "") {

                    //Set answer to 'new' on side pager and enable button
                    $('#MainContent_lblSpecsProjectTypeAnswer').text("New");
                    document.getElementById('pagerOne').style.display = "inline";
                    document.getElementById('MainContent_btnQuestion1').disabled = false;
                }
                else {
                    //error styling or something
                }
            }
            else if ($('#MainContent_radExistingCustomer').is(':checked'))
            {
                document.getElementById("MainContent_ddlExistingCustomer").value = $('#MainContent_ddlCustomerFirstName').val();

                if (document.getElementById("MainContent_ddlExistingCustomer").value != "") {
                    //valid, so update pager and enable button
                    $('#MainContent_lblSpecsProjectTypeAnswer').text("Existing");
                    document.getElementById('pagerOne').style.display = "inline";
                    document.getElementById('MainContent_btnQuestion1').disabled = false;
                }
            }

            return false;
        }

        function checkQuestion2() {
            //disable 'next slide' button until after validation
            document.getElementById('MainContent_btnQuestion2').disabled = true;

            document.getElementById("MainContent_hidProjectTag").value = $('#MainContent_txtProjectName').val();

            if (document.getElementById("MainContent_hidProjectTag").value != "") {
                //valid, so update pager and enable button
                $('#MainContent_lblProjectTagAnswer').text(document.getElementById("MainContent_hidProjectTag").value);
                document.getElementById('pagerTwo').style.display = "inline";
                document.getElementById('MainContent_btnQuestion2').disabled = false;
            }
            else {
                //error styling or something
            }
            return false;
        }

        function checkQuestion3() {

            console.log("I got into the javascript function for question 3.");
            return false;
        }

        function checkQuestion4() {

            console.log("I got into the javascript function for question 4.");
            return false;
        }

        function checkQuestion5() {

            console.log("I got into the javascript function for question 5.");
            return false;
        }

        function checkQuestion6() {

            console.log("I got into the javascript function for question 6.");
            return false;
        }

        function checkQuestion7() {

            console.log("I got into the javascript function for question 7.");
            return false;
        }
        function checkQuestion8() {

            console.log("I got into the javascript function for question 8.");
            return false;
        }
    </script>
    <%-- End hidden div populating scripts --%>

    <%-- SLIDES (QUESTIONS)
    ======================================== 
        
        onmousedown="event.preventDefault ? event.preventDefault() : event.returnValue = false"--%>
    <div class="slide-window"  >

        <div class="slide-wrapper">
            
            <%-- QUESTION 1 - New or existing customer
            ======================================== --%>
            <div id="slide1" class="slide">

                <h1>
                    <asp:Label ID="lblQuestion1" runat="server" Text="Is this a new or existing customer?"></asp:Label>
                </h1>        
                              
                <ul class="toggleOptions">

                    <%-- NEW CUSTOMER --%>
                    <li>
                        <asp:RadioButton ID="radNewCustomer" GroupName="question1" runat="server" />
                        <asp:Label ID="lblNewCustomerRadio" AssociatedControlID="radNewCustomer" runat="server"></asp:Label>
                        <asp:Label ID="lblNewCustomer" AssociatedControlID="radNewCustomer" runat="server" Text="New customer"></asp:Label>
           
                        <div class="toggleContent">
                            <ul>
                                <li>
                                    <h3>Enter customer details:</h3>

                                    <asp:Table ID="tblNewCustomerInfo" CssClass="tblTxtFields" runat="server">

                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblCustomerFirstName" AssociatedControlID="txtCustomerFirstName" runat="server" Text="First Name:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:TextBox ID="txtCustomerFirstName" CssClass="txtField txtInput" onkeyup="checkQuestion1()" OnChange="checkQuestion1()" runat="server"></asp:TextBox>
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblCustomerLastName" AssociatedControlID="txtCustomerLastName" runat="server" Text="Last Name:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:TextBox ID="txtCustomerLastName" CssClass="txtField txtInput" onkeyup="checkQuestion1()" OnChange="checkQuestion1()" runat="server"></asp:TextBox>
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblCustomerAddress" AssociatedControlID="txtCustomerAddress" runat="server" Text="Address:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:TextBox ID="txtCustomerAddress" CssClass="txtField txtInput" onkeyup="checkQuestion1()" OnChange="checkQuestion1()" runat="server"></asp:TextBox>
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblCustomerCity" AssociatedControlID="txtCustomerCity" runat="server" Text="City:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:TextBox ID="txtCustomerCity" CssClass="txtField txtInput" onkeyup="checkQuestion1()" OnChange="checkQuestion1()" runat="server"></asp:TextBox>
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblCustomerZip" AssociatedControlID="txtCustomerZip" runat="server" Text="ZIP Code:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:TextBox ID="txtCustomerZip" CssClass="txtField txtZipPhone" onkeyup="checkQuestion1()" OnChange="checkQuestion1()" runat="server"></asp:TextBox>
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblCustomerPhone" AssociatedControlID="txtCustomerPhone" runat="server" Text="Phone Number:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:TextBox ID="txtCustomerPhone" CssClass="txtField txtZipPhone" onkeyup="checkQuestion1()" OnChange="checkQuestion1()" runat="server"></asp:TextBox>
                                            </asp:TableCell>
                                        </asp:TableRow>

                                    </asp:Table>
                                </li>
                            </ul>            
                        </div> <%-- end .toggleContent --%>
                    </li> <%-- end 'complete sunroom' option --%>

                    <%-- EXISTING CUSTOMER --%>
                    <li>
                        <asp:RadioButton ID="radExistingCustomer" GroupName="question1" runat="server" />
                        <asp:Label ID="lblExistingCustomerRadio" AssociatedControlID="radExistingCustomer" runat="server"></asp:Label>
                        <asp:Label ID="lblExistingCustomer" AssociatedControlID="radExistingCustomer" runat="server" Text="Existing customer"></asp:Label>

                        <div class="toggleContent">
                            <ul>
                                <li>
                                    <asp:DropDownList ID="ddlExistingCustomer" OnChange="checkQuestion1()" GroupName="question1" runat="server" />
                                </li>
                            </ul>            
                        </div> <%-- end .toggleContent --%>
                    </li> <%-- end 'existing customer' option --%>

                </ul> <%-- end .toggleOptions --%>

                <asp:Button ID="btnQuestion1" Enabled="false" CssClass="btnSubmit float-right slidePanel" data-slide="#slide2" runat="server" Text="Next Question" />

            </div> 
            <%-- end #slide1 --%>


            <%-- QUESTION 2 - Project tag
            ======================================== --%>
            <div id="slide2" class="slide">
                
                <h1>
                    <asp:Label ID="lblQuestion2" runat="server" Text="Enter a name for your project"></asp:Label>
                </h1> 

                <ul class="toggleOptions">
                    <li>
                        <asp:Table ID="tblProjectName" CssClass="tblTxtFields" runat="server">
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblProjectName" AssociatedControlID="txtProjectName" runat="server" Text="Project Name:"></asp:Label>
                                </asp:TableCell>

                                <asp:TableCell>
                                    <asp:TextBox ID="txtProjectName" CssClass="txtField txtInput" onkeyup="checkQuestion2()" runat="server"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </li>

                </ul> <%-- end .toggleOptions --%>

                <asp:Button ID="btnQuestion2" Enabled = "false" CssClass="btnSubmit float-right slidePanel" data-slide="#slide3" runat="server" Text="Next Question" />
                
            </div> 
            <%-- end #slide2 --%>


            <%-- QUESTION 3 - What type of project?
            ======================================== --%>
            <div id="slide3" class="slide">

                <h1>
                    <asp:Label ID="lblQuestion3" runat="server" Text="What type of project would you like to create?"></asp:Label>
                </h1>        
                              
                <ul class="toggleOptions">

                    <%-- COMPLETE SUNROOM --%>
                    <li>
                        <asp:RadioButton ID="radProjectSunroom" GroupName="projectType" runat="server" />
                        <asp:Label ID="lblProjectSunroomRadio" AssociatedControlID="radProjectSunroom" runat="server"></asp:Label>
                        <asp:Label ID="lblProjectSunroom" AssociatedControlID="radProjectSunroom" runat="server" Text="Complete Sunroom"></asp:Label>
           
                        <div class="toggleContent">
                            <ul>
                                <li>
                                    <asp:RadioButton ID="radSunroomModel100" GroupName="sunroomModel" runat="server" />
                                    <asp:Label ID="lblSunroomModel100Radio" AssociatedControlID="radSunroomModel100" runat="server"></asp:Label>
                                    <asp:Label ID="lblSunroomModel100" AssociatedControlID="radSunroomModel100" runat="server" Text="Model 100"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="radSunroomModel200" GroupName="sunroomModel" runat="server" />
                                    <asp:Label ID="lblSunroomModel200Radio" AssociatedControlID="radSunroomModel200" runat="server"></asp:Label>
                                    <asp:Label ID="lblSunroomModel200" AssociatedControlID="radSunroomModel200" runat="server" Text="Model 200"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="radSunroomModel300" GroupName="sunroomModel" runat="server" />
                                    <asp:Label ID="lblSunroomModel300Radio" AssociatedControlID="radSunroomModel300" runat="server"></asp:Label>
                                    <asp:Label ID="lblSunroomModel300" AssociatedControlID="radSunroomModel300" runat="server" Text="Model 300"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="radSunroomModel400" GroupName="sunroomModel" runat="server" />
                                    <asp:Label ID="lblSunroomModel400Radio" AssociatedControlID="radSunroomModel400" runat="server"></asp:Label>
                                    <asp:Label ID="lblSunroomModel400" AssociatedControlID="radSunroomModel400" runat="server" Text="Model 400"></asp:Label>
                                </li>
                            </ul>            
                        </div> <%-- end 'complete sunroom' options --%>
                    </li> <%-- end 'complete sunroom' --%>

                    <%-- WALLS --%>
                    <li>
                        <asp:RadioButton ID="radProjectWalls" GroupName="projectType" runat="server" />
                        <asp:Label ID="lblProjectWallsRadio" AssociatedControlID="radProjectWalls" runat="server"></asp:Label>
                        <asp:Label ID="lblProjectWalls" AssociatedControlID="radProjectWalls" runat="server" Text="Walls"></asp:Label>

                        <div class="toggleContent">
                            <ul class="checkboxes">
                                <li>
                                    <asp:RadioButton ID="radWallsModel100" GroupName="sunroomModel" runat="server" />
                                    <asp:Label ID="lblWallsModel100Radio" AssociatedControlID="radWallsModel100" runat="server"></asp:Label>
                                    <asp:Label ID="lblWallsModel100" AssociatedControlID="radWallsModel100" runat="server" Text="Model 100"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="radWallsModel200" GroupName="sunroomModel" runat="server" />
                                    <asp:Label ID="lblWallsModel200Radio" AssociatedControlID="radWallsModel200" runat="server"></asp:Label>
                                    <asp:Label ID="lblWallsModel200" AssociatedControlID="radWallsModel200" runat="server" Text="Model 200"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="radWallsModel300" GroupName="sunroomModel" runat="server" />
                                    <asp:Label ID="lblWallsModel300Radio" AssociatedControlID="radWallsModel300" runat="server"></asp:Label>
                                    <asp:Label ID="lblWallsModel300" AssociatedControlID="radWallsModel300" runat="server" Text="Model 300"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="radWallsModel400" GroupName="sunroomModel" runat="server" />
                                    <asp:Label ID="lblWallsModel400Radio" AssociatedControlID="radWallsModel400" runat="server"></asp:Label>
                                    <asp:Label ID="lblWallsModel400" AssociatedControlID="radWallsModel400" runat="server" Text="Model 400"></asp:Label>
                                </li>
                            </ul>            
                        </div> <%-- end 'wall' options --%>
                    </li> <%-- end 'walls' --%>

                    <%-- WINDOWS --%>
                    <li>
                        <asp:RadioButton ID="radProjectWindows" GroupName="projectType" runat="server" />
                        <asp:Label ID="lblProjectWindowsRadio" AssociatedControlID="radProjectWindows" runat="server"></asp:Label>
                        <asp:Label ID="lblProjectWindows" AssociatedControlID="radProjectWindows" runat="server" Text="Windows"></asp:Label>
                    </li> <%-- end 'windows' --%>

                    <%-- DOORS --%>
                    <li>
                        <asp:RadioButton ID="radProjectDoors" GroupName="projectType" runat="server" />
                        <asp:Label ID="lblProjectDoorsRadio" AssociatedControlID="radProjectDoors" runat="server"></asp:Label>
                        <asp:Label ID="lblProjectDoors" AssociatedControlID="radProjectDoors" runat="server" Text="Doors"></asp:Label>
                    </li> <%-- end 'doors' --%>

                    <%-- FLOORING --%>
                    <li>
                        <asp:RadioButton ID="radProjectFlooring" GroupName="projectType" runat="server" />
                        <asp:Label ID="lblProjectFlooringRadio" AssociatedControlID="radProjectFlooring" runat="server"></asp:Label>
                        <asp:Label ID="lblProjectFlooring" AssociatedControlID="radProjectFlooring" runat="server" Text="Flooring"></asp:Label>
                    </li> <%-- end 'flooring' --%>

                    <%-- ROOF --%>
                    <li>
                        <asp:RadioButton ID="radProjectRoof" GroupName="projectType" runat="server" />
                        <asp:Label ID="lblProjectRoofRadio" AssociatedControlID="radProjectRoof" runat="server"></asp:Label>
                        <asp:Label ID="lblProjectRoof" AssociatedControlID="radProjectRoof" runat="server" Text="Roof"></asp:Label>

                        <div class="toggleContent">
                            <ul class="checkboxes">
                                <li>
                                    <asp:RadioButton ID="radRoofIBeam" GroupName="roofType" runat="server" />
                                    <asp:Label ID="lblRoofIBeamRadio" AssociatedControlID="radRoofIBeam" runat="server"></asp:Label>
                                    <asp:Label ID="lblRoofIBeam" AssociatedControlID="radRoofIBeam" runat="server" Text="I-Beam"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="radRoofPressureCap" GroupName="roofType" runat="server" />
                                    <asp:Label ID="lblRoofPressureCapRadio" AssociatedControlID="radRoofPressureCap" runat="server"></asp:Label>
                                    <asp:Label ID="lblRoofPressureCap" AssociatedControlID="radRoofPressureCap" runat="server" Text="Pressure Cap"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="radRoofInterlocking" GroupName="roofType" runat="server" />
                                    <asp:Label ID="lblRoofInterlockingRadio" AssociatedControlID="radRoofInterlocking" runat="server"></asp:Label>
                                    <asp:Label ID="lblRoofInterlocking" AssociatedControlID="radRoofInterlocking" runat="server" Text="Interlocking"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="radRoofAcrylic" GroupName="roofType" runat="server" />
                                    <asp:Label ID="lblRoofAcrylicRadio" AssociatedControlID="radRoofAcrylic" runat="server"></asp:Label>
                                    <asp:Label ID="lblRoofAcrylic" AssociatedControlID="radRoofAcrylic" runat="server" Text="Acrylic"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="radRoofOSB" GroupName="roofType" runat="server" />
                                    <asp:Label ID="lblRoofOSBRadio" AssociatedControlID="radRoofOSB" runat="server"></asp:Label>
                                    <asp:Label ID="lblRoofOSB" AssociatedControlID="radRoofOSB" runat="server" Text="OSB/OSB"></asp:Label>
                                </li>
                            </ul>            
                        </div> <%-- end 'roof' options --%>
                    </li> <%-- end 'roof' --%>

                    <%-- COMPONENTS --%>
                    <li>
                        <asp:RadioButton ID="radProjectComponents" GroupName="projectType" runat="server" />
                        <asp:Label ID="lblProjectComponentsRadio" AssociatedControlID="radProjectComponents" runat="server"></asp:Label>
                        <asp:Label ID="lblProjectComponents" AssociatedControlID="radProjectComponents" runat="server" Text="Components"></asp:Label>
                    </li> <%-- end 'components' --%>

                    <%-- SHOWROOM --%>
                    <li>
                        <asp:RadioButton ID="radProjectShowroom" GroupName="projectType" runat="server" />
                        <asp:Label ID="lblProjectShowroomRadio" AssociatedControlID="radProjectComponents" runat="server"></asp:Label>
                        <asp:Label ID="lblProjectShowroom" AssociatedControlID="radProjectComponents" runat="server" Text="Showroom"></asp:Label>
                    </li> <%-- end 'components' --%>

                </ul> <%-- end .toggleOptions --%>

                <asp:Button ID="btnQuestion3" CssClass="btnSubmit float-right slidePanel" data-slide="#slide4" runat="server" Text="Next Question" />

            </div> 
            <%-- end #slide3 --%>

            
            <%-- QUESTION 4 - Styling Options
            ======================================== --%>
            <div id="slide4" class="slide">
                
                <h1>
                    <asp:Label ID="lblQuestion4" runat="server" Text="Styling Options"></asp:Label>
                </h1>  

                <ul class="toggleOptions">
                    <%-- Option 1 - Kneewall 
                    ======================================== --%>
                    <li>
                                    
                        <asp:RadioButton ID="radKneewallOptions" GroupName="styling" runat="server" />
                        <asp:Label ID="lblKneewallOptionsRadio" AssociatedControlID="radKneewallOptions" runat="server"></asp:Label>
                        <asp:Label ID="lblKneewallOptions" AssociatedControlID="radKneewallOptions" runat="server" Text="Kneewall"></asp:Label>

                        <div class="toggleContent">
                            <ul>                                
                                <li>
                                    <asp:TextBox ID="txtKneewallHeight" GroupName="styling" CssClass="txtField" runat="server" />
                                    <asp:Label ID="lblKneewallHeight" AssociatedControlID="txtKneewallHeight" runat="server" Text="Height" />
                                    <br />
                                    <asp:DropDownList ID="ddlKneewallType" GroupName="styling" runat="server" />
                                    <asp:Label ID="lblKneewallType" AssociatedControlID="txtKneewallHeight" runat="server" Text="Type" />
                                    <br />
                                    <asp:DropDownList ID="ddlKneewallColour" GroupName="styling" runat="server" />
                                    <asp:Label ID="lblKneewallColour" AssociatedControlID="txtKneewallHeight" runat="server" Text="Colour" />
                                </li>
                            </ul>   
                        </div> <%-- end .toggleContent --%>

                    </li> <%-- end Q4 option 1 --%>

                    <%-- Option 2 - Transom
                    ======================================== --%>
                    <li>
                
                        <asp:RadioButton ID="radTransomOptions" GroupName="styling" runat="server" />
                        <asp:Label ID="lblTransomOptionsRadio" AssociatedControlID="radTransomOptions" runat="server"></asp:Label>
                        <asp:Label ID="lblTransomOptions" AssociatedControlID="radTransomOptions" runat="server" Text="Transom"></asp:Label>

                        <div class="toggleContent">
                            <ul>                                
                                <li>
                                    <asp:TextBox ID="txtTransomHeight" GroupName="styling" CssClass="txtField" runat="server" />
                                    <asp:Label ID="lblTransomHeight" AssociatedControlID="txtTransomHeight" runat="server" Text="Height" />
                                    <br />
                                    <asp:DropDownList ID="ddlTransomType" GroupName="styling" runat="server" />
                                    <asp:Label ID="lblTransomType" AssociatedControlID="txtTransomHeight" runat="server" Text="Type" />
                                    <br />
                                    <asp:DropDownList ID="ddlTransomColour" GroupName="styling" runat="server" />
                                    <asp:Label ID="lblTransomColour" AssociatedControlID="txtTransomHeight" runat="server" Text="Colour" />
                                </li>
                            </ul>
                        </div> <%-- end .toggleContent --%>

                    </li> <%-- end Q4 option 2 --%>  
              
                    <%-- Option 3 - Framing
                    ======================================== --%>
                    <li>
                
                        <asp:RadioButton ID="radFramingOptions" GroupName="styling" runat="server" />
                        <asp:Label ID="lblFramingOptionsRadio" AssociatedControlID="radFramingOptions" runat="server"></asp:Label>
                        <asp:Label ID="lblFramingOptions" AssociatedControlID="radFramingOptions" runat="server" Text="Framing"></asp:Label>

                        <div class="toggleContent">
                            <ul>                                
                                <li>
                                    <asp:DropDownList ID="ddlInteriorColour" GroupName="styling" runat="server" />
                                    <asp:Label ID="lblInteriorColour" AssociatedControlID="ddlInteriorColour" runat="server" Text="Interior Colour" />
                                    <br />
                                    <asp:DropDownList ID="ddlInteriorSkin" GroupName="styling" runat="server" />
                                    <asp:Label ID="lblInteriorSkin" AssociatedControlID="ddlInteriorSkin" runat="server" Text="Interior Skin" />
                                    <br />
                                    <asp:DropDownList ID="ddlExteriorColour" GroupName="styling" runat="server" />
                                    <asp:Label ID="lblExteriorColour" AssociatedControlID="ddlExteriorColour" runat="server" Text="Exterior Colour" />
                                    <br />
                                    <asp:DropDownList ID="ddlExteriorSkin" GroupName="styling" runat="server" />
                                    <asp:Label ID="lblExteriorSkin" AssociatedControlID="ddlExteriorSkin" runat="server" Text="Exterior Skin" />
                                </li>
                            </ul>
                        </div> <%-- end .toggleContent --%>

                    </li> <%-- end Q2 option 2 --%>
                </ul> <%-- end .toggleOptions --%>

                <asp:Button ID="btnNext2" CssClass="btnSubmit float-right slidePanel" data-slide="#slide5" runat="server" Text="Next Question" />

            </div> 
            <%-- end #slide4 --%>


            <%-- QUESTION 5 - Foam Protection
            ======================================== --%>
            <div id="slide5" class="slide">
                
                <h1>
                    <asp:Label ID="lblFoamProtected" runat="server" Text="Would you like foam protected panels?"></asp:Label>
                </h1> 

                <ul class="toggleOptions">

                    <li>
                        <asp:RadioButton ID="radFoamProtectedYes" GroupName="foam" runat="server" />
                        <asp:Label ID="lblFoamProtectedYesRadio" AssociatedControlID="radFoamProtectedYes" runat="server"></asp:Label>
                        <asp:Label ID="lblFoamProtectedYes" AssociatedControlID="radFoamProtectedYes" runat="server" Text="Yes"></asp:Label>
                    </li>

                    <li>
                        <asp:RadioButton ID="radFoamProtectedNo" GroupName="foam" runat="server" />
                        <asp:Label ID="lblFoamProtectedNoRadio" AssociatedControlID="radFoamProtectedNo" runat="server"></asp:Label>
                        <asp:Label ID="lblFoamProtectedNo" AssociatedControlID="radFoamProtectedNo" runat="server" Text="No"></asp:Label>
                    </li>

                </ul> <%-- end .toggleOptions --%>

                <asp:Button ID="btnFoamProtected" CssClass="btnSubmit float-right slidePanel" data-slide="#slide6" runat="server" Text="Next Question" />

            </div> 
            <%-- end #slide5 --%>

            <%-- QUESTION 6 - Prefab Floor
            ======================================== --%>
            <div id="slide6" class="slide">
                
                <h1>
                    <asp:Label ID="lblPrefabFloor" runat="server" Text="Would you like a prefabricated floor?"></asp:Label>
                </h1> 

                <ul class="toggleOptions">

                    <li>
                        <asp:RadioButton ID="radPrefabFloorYes" GroupName="floor" runat="server" />
                        <asp:Label ID="lblPrefabFloorYesRadio" AssociatedControlID="radPrefabFloorYes" runat="server"></asp:Label>
                        <asp:Label ID="lblPrefabFloorYes" AssociatedControlID="radPrefabFloorYes" runat="server" Text="Yes"></asp:Label>
                    </li>

                    <li>
                        <asp:RadioButton ID="radPrefabFloorNo" GroupName="floor" runat="server" />
                        <asp:Label ID="lblPrefabFloorNoRadio" AssociatedControlID="radPrefabFloorNo" runat="server"></asp:Label>
                        <asp:Label ID="lblPrefabFloorNo" AssociatedControlID="radPrefabFloorNo" runat="server" Text="No"></asp:Label>
                    </li>

                </ul> <%-- end .toggleOptions --%>

                <asp:Button ID="btnPrefabFloor" CssClass="btnSubmit float-right slidePanel" data-slide="#slide7" runat="server" Text="Next Question" />

            </div> 
            <%-- end #slide6 --%>

            <%-- QUESTION 7 - Roof
            ======================================== --%>
            <div id="slide7" class="slide">
                
                <h1>
                    <asp:Label ID="lblRoof" runat="server" Text="Would you like to include a roof?"></asp:Label>
                </h1> 

                <ul class="toggleOptions">

                    <li>
                        <asp:RadioButton ID="radRoofYes" GroupName="roof" runat="server" />
                        <asp:Label ID="lblRoofYesRadio" AssociatedControlID="radRoofYes" runat="server"></asp:Label>
                        <asp:Label ID="lblRoofYes" AssociatedControlID="radRoofYes" runat="server" Text="Yes"></asp:Label>

                        <div class="toggleContent">
                            <ul>
                                <li>
                                    <asp:RadioButton ID="radStudio" GroupName="roof" runat="server" />
                                    <asp:Label ID="lblStudioRadio" AssociatedControlID="radStudio" runat="server"></asp:Label>
                                    <asp:Label ID="lblStudio" AssociatedControlID="radStudio" runat="server" Text="Studio"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="radDealerGable" GroupName="roof" runat="server" />
                                    <asp:Label ID="lblDealerGableRadio" AssociatedControlID="radDealerGable" runat="server"></asp:Label>
                                    <asp:Label ID="lblDealerGable" AssociatedControlID="radDealerGable" runat="server" Text="Dealer gable"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="radSunspaceGable" GroupName="roof" runat="server" />
                                    <asp:Label ID="lblSunspaceGableRadio" AssociatedControlID="radSunspaceGable" runat="server"></asp:Label>
                                    <asp:Label ID="lblSunspaceGable" AssociatedControlID="radSunspaceGable" runat="server" Text="Sunspace gable"></asp:Label>
                                </li>
                            </ul>
                        </div> <%-- end 'yes' option --%>
                    </li>

                    <li>
                        <asp:RadioButton ID="radRoofNo" GroupName="roof" runat="server" />
                        <asp:Label ID="lblRoofNoRadio" AssociatedControlID="radRoofYes" runat="server"></asp:Label>
                        <asp:Label ID="lblRoofNo" AssociatedControlID="radRoofYes" runat="server" Text="No"></asp:Label>
                    </li>

                </ul> <%-- end .toggleOptions --%>

                <asp:Button ID="btnRoof" CssClass="btnSubmit float-right slidePanel" data-slide="#slide8" runat="server" Text="Next Question" />

            </div> 
            <%-- end #slide7 --%>

            <%-- QUESTION 8 - Layout
            ======================================== --%>
            <div id="slide8" class="slide">
                
                <h1>
                    <asp:Label ID="lblLayout" runat="server" Text="Please choose a sunroom layout."></asp:Label>
                </h1> 

                <ul class="toggleOptions">

                    <li>
                        <asp:RadioButton ID="radPreset1" GroupName="layout" runat="server" />                        
                        <asp:Label ID="lblPreset1Radio" AssociatedControlID="radPreset1" runat="server"></asp:Label>
                        <asp:Image ID="imbPreset1" GroupName="layout" AssociatedControlID="radPreset1" AlternateText="missing preset image" ImageUrl="./images/layout/Preset1.png" runat="server" />                  
                    </li>
                    <li>
                        <asp:RadioButton ID="radPreset2" GroupName="layout" runat="server" />
                        <asp:Image ID="imbPreset2" GroupName="layout" AssociatedControlID="radPreset2" AlternateText="missing preset image" ImageUrl="./images/layout/Preset2.png" runat="server" />                  
                    </li>
                    <li>
                        <asp:RadioButton ID="radPreset3" GroupName="layout" runat="server" />
                        <asp:Image ID="imbPreset3" GroupName="layout" AssociatedControlID="radPreset3" AlternateText="missing preset image" ImageUrl="./images/layout/Preset3.png" runat="server" />                  
                    </li>
                    <li>
                        <asp:RadioButton ID="radPreset4" GroupName="layout" runat="server" />
                        <asp:Image ID="imbPreset4" GroupName="layout" AssociatedControlID="radPreset4" AlternateText="missing preset image" ImageUrl="./images/layout/Preset4.png" runat="server" />                  
                    </li>
                    <li>
                        <asp:RadioButton ID="radPreset5" GroupName="layout" runat="server" />
                        <asp:Image ID="imbPreset5" GroupName="layout" AssociatedControlID="radPreset5" AlternateText="missing preset image" ImageUrl="./images/layout/Preset5.png" runat="server" />                  
                    </li>
                    <li>
                        <asp:RadioButton ID="radPreset6" GroupName="layout" runat="server" />
                        <asp:Image ID="imbPreset6" GroupName="layout" AssociatedControlID="radPreset6" AlternateText="missing preset image" ImageUrl="./images/layout/Preset6.png" runat="server" />                  
                    </li>
                    <li>
                        <asp:RadioButton ID="radPreset7" GroupName="layout" runat="server" />
                        <asp:Image ID="imbPreset7" GroupName="layout" AssociatedControlID="radPreset7" AlternateText="missing preset image" ImageUrl="./images/layout/Preset7.png" runat="server" />                  
                    </li>
                    <li>
                        <asp:RadioButton ID="radPreset8" GroupName="layout" runat="server" />
                        <asp:Image ID="imbPreset8" GroupName="layout" AssociatedControlID="radPreset8" AlternateText="missing preset image" ImageUrl="./images/layout/Preset8.png" runat="server" />                  
                    </li>
                    <li>
                        <asp:RadioButton ID="radPreset9" GroupName="layout" runat="server" />
                        <asp:Image ID="imbPreset9" GroupName="layout" AssociatedControlID="radPreset9" AlternateText="missing preset image" ImageUrl="./images/layout/Preset9.png" runat="server" />                  
                    </li>
                    <li>
                        <asp:RadioButton ID="radPreset10" GroupName="layout" runat="server" />
                        <asp:Image ID="imbPreset10" GroupName="layout" AssociatedControlID="radPreset10" AlternateText="missing preset image" ImageUrl="./images/layout/Preset10.png" runat="server" />                  
                    </li>
                    <li>
                        <asp:RadioButton ID="radPresetF1" GroupName="layout" runat="server" />
                        <asp:Image ID="imbPresetF1" GroupName="layout" AssociatedControlID="radPresetF1" AlternateText="missing preset image" ImageUrl="./images/layout/PresetS1.png" runat="server" />                  
                    </li>
                    <li>
                        <asp:RadioButton ID="radPresetC1" GroupName="layout" runat="server" />
                        <asp:Image ID="imbPresetC1" GroupName="layout" AssociatedControlID="radPresetC1" AlternateText="missing preset image" ImageUrl="./images/layout/PresetC1.png" runat="server" />                  
                    </li>

                    <asp:Button ID="btnLayout" CssClass="btnSubmit float-right slidePanel" Text="Confirm all selections" runat="server" OnClientClick="checkQuestion8()" OnClick="btnLayout_Click"/>

                </ul> <%-- end .toggleOptions --%>

            </div> 
            <%-- end #slide8 --%>

            

        </div> <%-- end .slide-wrapper --%>

    </div> 
    <%-- end .slide-window --%>
    

    <%-- SLIDE PAGING (QUESTION NAVIGATION)
    ======================================== --%>
    <div id="paging-wrapper">    
        <div id="paging"> 
            <h2>Project Specifications</h2>

            <ul>
                <li>
                    <div style="display: none" id="pagerOne">
                        <a href="#" data-slide="#slide1" class="slidePanel">
                            <asp:Label ID="lblSpecsProjectType" runat="server" Text="New/Existing Customer"></asp:Label>
                            <asp:Label ID="lblSpecsProjectTypeAnswer" runat="server" Text="Customer Answer"></asp:Label>
                        </a>
                    </div>
                </li>
                <li>
                    <div style="display: none" id="pagerTwo">
                        <a href="#" data-slide="#slide2" class="slidePanel">
                            <asp:Label ID="lblProjectTag" runat="server" Text="Project tag"></asp:Label>
                            <asp:Label ID="lblProjectTagAnswer" runat="server" Text="Question 2 Answer"></asp:Label>
                        </a>
                    </div>
                </li>
                <li>
                    <a href="#" data-slide="#slide3" class="slidePanel">
                        <asp:Label ID="Label37" runat="server" Text="Type of project"></asp:Label>
                        <asp:Label ID="Label38" runat="server" Text="Question 3 Answer"></asp:Label>
                    </a>
                </li>
                <li>
                    <a href="#" data-slide="#slide4" class="slidePanel">
                        <asp:Label ID="Label27" runat="server" Text="Styling options"></asp:Label>
                        <asp:Label ID="Label30" runat="server" Text="Question 4 Answer"></asp:Label>
                    </a>
                </li>
                <li>
                    <a href="#" data-slide="#slide5" class="slidePanel">
                        <asp:Label ID="Label31" runat="server" Text="Foam protection"></asp:Label>
                        <asp:Label ID="Label32" runat="server" Text="Question 5 Answer"></asp:Label>
                    </a>
                </li>                
                <li>
                    <a href="#" data-slide="#slide6" class="slidePanel">
                        <asp:Label ID="Label1" runat="server" Text="Prefab floor"></asp:Label>
                        <asp:Label ID="Label2" runat="server" Text="Question 6 Answer"></asp:Label>
                    </a>
                </li>
                
                <li>
                    <a href="#" data-slide="#slide7" class="slidePanel">
                        <asp:Label ID="Label3" runat="server" Text="Roof"></asp:Label>
                        <asp:Label ID="Label4" runat="server" Text="Question 7 Answer"></asp:Label>
                    </a>
                </li>

                <li>
                    <a href="#" data-slide="#slide8" class="slidePanel">
                        <asp:Label ID="Label5" runat="server" Text="Layout"></asp:Label>
                        <asp:Label ID="Label6" runat="server" Text="Question 8 Answer"></asp:Label>
                    </a>
                </li>
            </ul>    
        </div> <%-- end #paging --%>
    </div>

    <%-- Hidden input tags 
    ======================= --%>
    <input id="hidExisting" type="hidden" runat="server" />
    <input id="hidFirstName" type="hidden" runat="server" />
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

    <input id="hidLayoutSelection" type="hidden" runat="server" />

    <%-- end hidden divs --%>

    

    <script>
        $(function () {
            $('.ulNavMain').children('a').removeClass('active');
            $('#lnkMainNavNewProject').addClass('active');
        });
    </script>

</asp:Content>

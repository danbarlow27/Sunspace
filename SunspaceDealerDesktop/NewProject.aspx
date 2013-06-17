<%@ Page Title="New Project - Project Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewProject.aspx.cs" Inherits="SunspaceWizard._Default" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <script src="Scripts/Validation.js"></script>
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

                    var validPhone = validatePhone(document.getElementById("MainContent_hidPhone").value);

                    if (!validPhone) {
                        console.log("invalid");
                    }
                    else {
                        console.log("valid");
                    }

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
            document.getElementById('MainContent_btnQuestion3').disabled = true;

            if ($('#MainContent_radProjectSunroom').is(':checked')) {
                if ($('#MainContent_radSunroomModel100').is(':checked')) {
                    document.getElementById("MainContent_hidModelNumber").value = "100";
                    document.getElementById('pagerThree').style.display = "inline";
                    document.getElementById('MainContent_btnQuestion3').disabled = false;
                }
                else if($('#MainContent_radSunroomModel200').is(':checked')) {
                    document.getElementById("MainContent_hidModelNumber").value = "200";
                    document.getElementById('pagerThree').style.display = "inline";
                    document.getElementById('MainContent_btnQuestion3').disabled = false;
                }
                else if($('#MainContent_radSunroomModel300').is(':checked')) {
                    document.getElementById("MainContent_hidModelNumber").value = "300";
                    document.getElementById('pagerThree').style.display = "inline";
                    document.getElementById('MainContent_btnQuestion3').disabled = false;
                }
                else if($('#MainContent_radSunroomModel400').is(':checked')) {
                    document.getElementById("MainContent_hidModelNumber").value = "400";
                    document.getElementById('pagerThree').style.display = "inline";
                    document.getElementById('MainContent_btnQuestion3').disabled = false;
                }
                
                document.getElementById("MainContent_hidProjectType").value = "Sunroom";
                $('#MainContent_lblProjectTypeAnswer').text(document.getElementById("MainContent_hidProjectType").value + " of Model " + document.getElementById("MainContent_hidModelNumber").value);
            }
            return false;
        }

        function checkQuestion4() {
            //document.getElementById('MainContent_btnQuestion4').disabled = true;
            //var optionChecksPassed = false;

            //if (document.getElementById("MainContent_txtKneewallHeight").value != "" &&
            //    document.getElementById("MainContent_ddlKneewallType").value != "" &&
            //    document.getElementById("MainContent_ddlKneewallColour").value != "") {

            //    document.getElementById("MainContent_hidKneewallHeight").value = document.getElementById("MainContent_txtKneewallHeight").value;
            //    document.getElementById("MainContent_hidKneewallType").value = document.getElementById("MainContent_ddlKneewallType").value;
            //    document.getElementById("MainContent_hidKneewallColour").value = document.getElementById("MainContent_ddlKneewallColour").value;
            //    optionChecksPassed = true;
            //}
            //else {
            //    optionChecksPassed = false;
            //    //kneewall error styling
            //}

            //if (document.getElementById("MainContent_txtTransomHeight").value != "" &&
            //    document.getElementById("MainContent_ddlTransomType").value != "" &&
            //    document.getElementById("MainContent_ddlTransomColour").value != "") {

            //    document.getElementById("MainContent_hidTransomHeight").value = document.getElementById("MainContent_txtTransomHeight").value;
            //    document.getElementById("MainContent_hidTransomType").value = document.getElementById("MainContent_ddlTransomType").value;
            //    document.getElementById("MainContent_hidTransomColour").value = document.getElementById("MainContent_ddlTransomColour").value;
            //    optionChecksPassed = true;
            //}
            //else {
            //    optionChecksPassed = false;
            //    //transom error styling
            //}

            //if (document.getElementById("MainContent_ddlInteriorColour").value != "" &&
            //    document.getElementById("MainContent_ddlInteriorSkin").value != "" &&
            //    document.getElementById("MainContent_ddlExteriorColour").value != "" &&
            //    document.getElementById("MainContent_ddlExteriorSkin").value != "") {

            //    document.getElementById("MainContent_hidInteriorColour").value = document.getElementById("MainContent_ddlInteriorColour").value;
            //    document.getElementById("MainContent_hidInteriorSkin").value = document.getElementById("MainContent_ddlInteriorSkin").value;
            //    document.getElementById("MainContent_hidExteriorColour").value = document.getElementById("MainContent_ddlExteriorColour").value;
            //    document.getElementById("MainContent_hidExteriorSkin").value = document.getElementById("MainContent_ddlExteriorSkin").value;
            //    optionChecksPassed = true;
            //}
            //else {
            //    optionChecksPassed = false;
            //    //framing error styling
            //}

            //if (optionChecksPassed) {
            //    document.getElementById('MainContent_btnQuestion4').disabled = false;
            //    $('#MainContent_lblQuestion4PagerAnswer').text("Entry Complete");
            //    document.getElementById('pagerFour').style.display = "inline";
            //}

            document.getElementById('MainContent_btnQuestion4').disabled = false;
            return false;
        }

        function checkQuestion5() {
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

            return false;
        }

        function checkQuestion6() {
            document.getElementById('MainContent_btnQuestion6').disabled = true;
            
            if ($('#MainContent_radPrefabFloorYes').is(':checked')) {
                document.getElementById('MainContent_btnQuestion6').disabled = false;
                $('#MainContent_lblQuestion6PagerAnswer').text("Yes");
                document.getElementById('pagerSix').style.display = "inline";
                document.getElementById("MainContent_hidPrefabFloor").value = "Yes";
            }
            else if ($('#MainContent_radPrefabFloorNo').is(':checked')) {
                document.getElementById('MainContent_btnQuestion6').disabled = false;
                $('#MainContent_lblQuestion6PagerAnswer').text("No");
                document.getElementById('pagerSix').style.display = "inline";
                document.getElementById("MainContent_hidPrefabFloor").value = "No";
            }
            else {
                //no selection, errors
            }

            return false;
        }

        function checkQuestion7() {
            document.getElementById('MainContent_btnQuestion7').disabled = true;
            
            
            if ($('#MainContent_radRoofNo').is(':checked')) {
                document.getElementById('MainContent_btnQuestion7').disabled = false;
                $('#MainContent_lblQuestion7PagerAnswer').text("None");
                document.getElementById('pagerSeven').style.display = "inline";
                document.getElementById("MainContent_hidRoof").value = "No";
            }
            else if ($('#MainContent_radStudio').is(':checked')) {
                document.getElementById('MainContent_btnQuestion7').disabled = false;
                $('#MainContent_lblQuestion7PagerAnswer').text("Studio");
                document.getElementById('pagerSeven').style.display = "inline";
                document.getElementById("MainContent_hidRoof").value = "Yes";
                document.getElementById("MainContent_hidRoofType").value = "Studio";
            }
            else if ($('#MainContent_radDealerGable').is(':checked')) {
                document.getElementById('MainContent_btnQuestion7').disabled = false;
                $('#MainContent_lblQuestion7PagerAnswer').text("Dealer Gable");
                document.getElementById('pagerSeven').style.display = "inline";
                document.getElementById("MainContent_hidRoof").value = "Yes";
                document.getElementById("MainContent_hidRoofType").value = "Dealer Gable";
            }
            else if ($('#MainContent_radSunspaceGable').is(':checked')) {
                document.getElementById('MainContent_btnQuestion7').disabled = false;
                $('#MainContent_lblQuestion7PagerAnswer').text("Sunspace Gable");
                document.getElementById('pagerSeven').style.display = "inline";
                document.getElementById("MainContent_hidRoof").value = "Yes";
                document.getElementById("MainContent_hidRoofType").value = "Sunspace Gable";
            }
            else {
                //no selection, errors
            }

            return false;
        }
        function checkQuestion8() {
            document.getElementById('MainContent_btnQuestion8').disabled = true;
            
            if ($('#MainContent_radPreset1').is(':checked')) {
                document.getElementById('MainContent_btnQuestion8').disabled = false;
                $('#MainContent_lblQuestion8PagerAnswer').text("Preset 1");
                document.getElementById('pagerEight').style.display = "inline";
                document.getElementById("MainContent_hidLayoutSelection").value = "1";
            }
            else if ($('#MainContent_radPreset2').is(':checked')) {
                document.getElementById('MainContent_btnQuestion8').disabled = false;
                $('#MainContent_lblQuestion8PagerAnswer').text("Preset 2");
                document.getElementById('pagerEight').style.display = "inline";
                document.getElementById("MainContent_hidLayoutSelection").value = "2";
            }
            else if ($('#MainContent_radPreset3').is(':checked')) {
                document.getElementById('MainContent_btnQuestion8').disabled = false;
                $('#MainContent_lblQuestion8PagerAnswer').text("Preset 3");
                document.getElementById('pagerEight').style.display = "inline";
                document.getElementById("MainContent_hidLayoutSelection").value = "3";
            }
            else if ($('#MainContent_radPreset4').is(':checked')) {
                document.getElementById('MainContent_btnQuestion8').disabled = false;
                $('#MainContent_lblQuestion8PagerAnswer').text("Preset 4");
                document.getElementById('pagerEight').style.display = "inline";
                document.getElementById("MainContent_hidLayoutSelection").value = "4";
            }
            else if ($('#MainContent_radPreset5').is(':checked')) {
                document.getElementById('MainContent_btnQuestion8').disabled = false;
                $('#MainContent_lblQuestion8PagerAnswer').text("Preset 5");
                document.getElementById('pagerEight').style.display = "inline";
                document.getElementById("MainContent_hidLayoutSelection").value = "5";
            }
            else if ($('#MainContent_radPreset6').is(':checked')) {
                document.getElementById('MainContent_btnQuestion8').disabled = false;
                $('#MainContent_lblQuestion8PagerAnswer').text("Preset 6");
                document.getElementById('pagerEight').style.display = "inline";
                document.getElementById("MainContent_hidLayoutSelection").value = "6";
            }
            else if ($('#MainContent_radPreset7').is(':checked')) {
                document.getElementById('MainContent_btnQuestion8').disabled = false;
                $('#MainContent_lblQuestion8PagerAnswer').text("Preset 7");
                document.getElementById('pagerEight').style.display = "inline";
                document.getElementById("MainContent_hidLayoutSelection").value = "7";
            }
            else if ($('#MainContent_radPreset8').is(':checked')) {
                document.getElementById('MainContent_btnQuestion8').disabled = false;
                $('#MainContent_lblQuestion8PagerAnswer').text("Preset 8");
                document.getElementById('pagerEight').style.display = "inline";
                document.getElementById("MainContent_hidLayoutSelection").value = "8";
            }
            else if ($('#MainContent_radPreset9').is(':checked')) {
                document.getElementById('MainContent_btnQuestion8').disabled = false;
                $('#MainContent_lblQuestion8PagerAnswer').text("Preset 9");
                document.getElementById('pagerEight').style.display = "inline";
                document.getElementById("MainContent_hidLayoutSelection").value = "9";
            }
            else if ($('#MainContent_radPreset10').is(':checked')) {
                document.getElementById('MainContent_btnQuestion8').disabled = false;
                $('#MainContent_lblQuestion8PagerAnswer').text("Preset 10");
                document.getElementById('pagerEight').style.display = "inline";
                document.getElementById("MainContent_hidLayoutSelection").value = "10";
            }
            else if ($('#MainContent_radPresetF1').is(':checked')) {
                document.getElementById('MainContent_btnQuestion8').disabled = false;
                $('#MainContent_lblQuestion8PagerAnswer').text("Preset F1");
                document.getElementById('pagerEight').style.display = "inline";
                document.getElementById("MainContent_hidLayoutSelection").value = "F1";
            }
            else if ($('#MainContent_radPresetC1').is(':checked')) {
                document.getElementById('MainContent_btnQuestion8').disabled = false;
                $('#MainContent_lblQuestion8PagerAnswer').text("Custom");
                document.getElementById('pagerEight').style.display = "inline";
                document.getElementById("MainContent_hidLayoutSelection").value = "Custom";
            }
            else {
                //no selection, errors
            }

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
                                                <asp:TextBox ID="txtCustomerPhone" CssClass="txtField txtZipPhone" onkeyup="checkQuestion1()" OnChange="checkQuestion1()" runat="server" MaxLength="10"></asp:TextBox>
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
                                    <asp:RadioButton ID="radSunroomModel100" OnClick="checkQuestion3()" GroupName="sunroomModel" runat="server" />
                                    <asp:Label ID="lblSunroomModel100Radio" AssociatedControlID="radSunroomModel100" runat="server"></asp:Label>
                                    <asp:Label ID="lblSunroomModel100" AssociatedControlID="radSunroomModel100" runat="server" Text="Model 100"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="radSunroomModel200" OnClick="checkQuestion3()" GroupName="sunroomModel" runat="server" />
                                    <asp:Label ID="lblSunroomModel200Radio" AssociatedControlID="radSunroomModel200" runat="server"></asp:Label>
                                    <asp:Label ID="lblSunroomModel200" AssociatedControlID="radSunroomModel200" runat="server" Text="Model 200"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="radSunroomModel300" OnClick="checkQuestion3()" GroupName="sunroomModel" runat="server" />
                                    <asp:Label ID="lblSunroomModel300Radio" AssociatedControlID="radSunroomModel300" runat="server"></asp:Label>
                                    <asp:Label ID="lblSunroomModel300" AssociatedControlID="radSunroomModel300" runat="server" Text="Model 300"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="radSunroomModel400" OnClick="checkQuestion3()" GroupName="sunroomModel" runat="server" />
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

                <asp:Button ID="btnQuestion3" Enabled="false" CssClass="btnSubmit float-right slidePanel" data-slide="#slide4" runat="server" Text="Next Question" />

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
                                    <asp:TextBox ID="txtKneewallHeight" onkeyup="checkQuestion4()" OnChange="checkQuestion4()" GroupName="styling" CssClass="txtField" runat="server" MaxLength="3" />
                                    
                                    <asp:Label ID="lblKneewallHeight" AssociatedControlID="txtKneewallHeight" runat="server" Text="Height" />
                                    <br />
                                    <asp:DropDownList ID="ddlKneewallType" OnChange="checkQuestion4()" GroupName="styling" runat="server" />
                                    <asp:Label ID="lblKneewallType" AssociatedControlID="txtKneewallHeight" runat="server" Text="Type" />
                                    <br />
                                    <asp:DropDownList ID="ddlKneewallColour" OnChange="checkQuestion4()" GroupName="styling" runat="server" />
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
                                    <asp:TextBox ID="txtTransomHeight" onkeyup="checkQuestion4()" OnChange="checkQuestion4()" GroupName="styling" CssClass="txtField" runat="server" />
                                    <asp:Label ID="lblTransomHeight" AssociatedControlID="txtTransomHeight" runat="server" Text="Height" />
                                    <br />
                                    <asp:DropDownList ID="ddlTransomType" OnChange="checkQuestion4()" GroupName="styling" runat="server" />
                                    <asp:Label ID="lblTransomType" AssociatedControlID="txtTransomHeight" runat="server" Text="Type" />
                                    <br />
                                    <asp:DropDownList ID="ddlTransomColour" OnChange="checkQuestion4()" GroupName="styling" runat="server" />
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
                                    <asp:DropDownList ID="ddlInteriorColour" OnChange="checkQuestion4()" GroupName="styling" runat="server" />
                                    <asp:Label ID="lblInteriorColour" AssociatedControlID="ddlInteriorColour" runat="server" Text="Interior Colour" />
                                    <br />
                                    <asp:DropDownList ID="ddlInteriorSkin" OnChange="checkQuestion4()" GroupName="styling" runat="server" />
                                    <asp:Label ID="lblInteriorSkin" AssociatedControlID="ddlInteriorSkin" runat="server" Text="Interior Skin" />
                                    <br />
                                    <asp:DropDownList ID="ddlExteriorColour" OnChange="checkQuestion4()" GroupName="styling" runat="server" />
                                    <asp:Label ID="lblExteriorColour" AssociatedControlID="ddlExteriorColour" runat="server" Text="Exterior Colour" />
                                    <br />
                                    <asp:DropDownList ID="ddlExteriorSkin" OnChange="checkQuestion4()" GroupName="styling" runat="server" />
                                    <asp:Label ID="lblExteriorSkin" AssociatedControlID="ddlExteriorSkin" runat="server" Text="Exterior Skin" />
                                </li>
                            </ul>
                        </div> <%-- end .toggleContent --%>

                    </li> <%-- end Q2 option 2 --%>
                </ul> <%-- end .toggleOptions --%>

                <asp:Button ID="btnQuestion4" Enabled="false" CssClass="btnSubmit float-right slidePanel" data-slide="#slide5" runat="server" Text="Next Question" />

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
                        <asp:RadioButton ID="radFoamProtectedYes" OnClick="checkQuestion5()" GroupName="foam" runat="server" />
                        <asp:Label ID="lblFoamProtectedYesRadio" AssociatedControlID="radFoamProtectedYes" runat="server"></asp:Label>
                        <asp:Label ID="lblFoamProtectedYes" AssociatedControlID="radFoamProtectedYes" runat="server" Text="Yes"></asp:Label>
                    </li>

                    <li>
                        <asp:RadioButton ID="radFoamProtectedNo" OnClick="checkQuestion5()" GroupName="foam" runat="server" />
                        <asp:Label ID="lblFoamProtectedNoRadio" AssociatedControlID="radFoamProtectedNo" runat="server"></asp:Label>
                        <asp:Label ID="lblFoamProtectedNo" AssociatedControlID="radFoamProtectedNo" runat="server" Text="No"></asp:Label>
                    </li>

                </ul> <%-- end .toggleOptions --%>

                <asp:Button ID="btnQuestion5" Enabled="false" CssClass="btnSubmit float-right slidePanel" data-slide="#slide6" runat="server" Text="Next Question" />

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
                        <asp:RadioButton ID="radPrefabFloorYes" OnClick="checkQuestion6()" GroupName="floor" runat="server" />
                        <asp:Label ID="lblPrefabFloorYesRadio" AssociatedControlID="radPrefabFloorYes" runat="server"></asp:Label>
                        <asp:Label ID="lblPrefabFloorYes" AssociatedControlID="radPrefabFloorYes" runat="server" Text="Yes"></asp:Label>
                    </li>

                    <li>
                        <asp:RadioButton ID="radPrefabFloorNo" OnClick="checkQuestion6()" GroupName="floor" runat="server" />
                        <asp:Label ID="lblPrefabFloorNoRadio" AssociatedControlID="radPrefabFloorNo" runat="server"></asp:Label>
                        <asp:Label ID="lblPrefabFloorNo" AssociatedControlID="radPrefabFloorNo" runat="server" Text="No"></asp:Label>
                    </li>

                </ul> <%-- end .toggleOptions --%>

                <asp:Button ID="btnQuestion6" Enabled="false" CssClass="btnSubmit float-right slidePanel" data-slide="#slide7" runat="server" Text="Next Question" />

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
                                    <asp:RadioButton ID="radStudio" OnClick="checkQuestion7()" GroupName="roofSub" runat="server" />
                                    <asp:Label ID="lblStudioRadio" AssociatedControlID="radStudio" runat="server"></asp:Label>
                                    <asp:Label ID="lblStudio" AssociatedControlID="radStudio" runat="server" Text="Studio"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="radDealerGable" OnClick="checkQuestion7()" GroupName="roofSub" runat="server" />
                                    <asp:Label ID="lblDealerGableRadio" AssociatedControlID="radDealerGable" runat="server"></asp:Label>
                                    <asp:Label ID="lblDealerGable" AssociatedControlID="radDealerGable" runat="server" Text="Dealer gable"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="radSunspaceGable" OnClick="checkQuestion7()" GroupName="roofSub" runat="server" />
                                    <asp:Label ID="lblSunspaceGableRadio" AssociatedControlID="radSunspaceGable" runat="server"></asp:Label>
                                    <asp:Label ID="lblSunspaceGable" AssociatedControlID="radSunspaceGable" runat="server" Text="Sunspace gable"></asp:Label>
                                </li>
                            </ul>
                        </div> <%-- end 'yes' option --%>
                    </li>

                    <li>
                        <asp:RadioButton ID="radRoofNo" OnClick="checkQuestion7()" GroupName="roof" runat="server" />
                        <asp:Label ID="lblRoofNoRadio" AssociatedControlID="radRoofNo" runat="server"></asp:Label>
                        <asp:Label ID="lblRoofNo" AssociatedControlID="radRoofNo" runat="server" Text="No"></asp:Label>
                    </li>

                </ul> <%-- end .toggleOptions --%>

                <asp:Button ID="btnQuestion7" Enabled="false" CssClass="btnSubmit float-right slidePanel" data-slide="#slide8" runat="server" Text="Next Question" />

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
                        <asp:RadioButton ID="radPreset1" OnClick="checkQuestion8()" GroupName="layout" runat="server" />                        
                        <asp:Label ID="lblPreset1Radio" AssociatedControlID="radPreset1" runat="server"></asp:Label>
                        <asp:Image ID="imbPreset1" GroupName="layout" AssociatedControlID="radPreset1" AlternateText="missing preset image" ImageUrl="./images/layout/Preset1.png" runat="server" />                  
                    </li>
                    <li>
                        <asp:RadioButton ID="radPreset2" OnClick="checkQuestion8()" GroupName="layout" runat="server" />                        
                        <asp:Label ID="lblPreset2Radio" AssociatedControlID="radPreset2" runat="server"></asp:Label>
                        <asp:Image ID="imbPreset2" GroupName="layout" AssociatedControlID="radPreset2" AlternateText="missing preset image" ImageUrl="./images/layout/Preset2.png" runat="server" />                  
                    </li>
                    <li>
                        <asp:RadioButton ID="radPreset3" OnClick="checkQuestion8()" GroupName="layout" runat="server" />                        
                        <asp:Label ID="lblPreset3Radio" AssociatedControlID="radPreset3" runat="server"></asp:Label>
                        <asp:Image ID="imbPreset3" GroupName="layout" AssociatedControlID="radPreset3" AlternateText="missing preset image" ImageUrl="./images/layout/Preset3.png" runat="server" />                  
                    </li>
                    <li>
                        <asp:RadioButton ID="radPreset4" OnClick="checkQuestion8()" GroupName="layout" runat="server" />                        
                        <asp:Label ID="lblPreset4Radio" AssociatedControlID="radPreset4" runat="server"></asp:Label>
                        <asp:Image ID="imbPreset4" GroupName="layout" AssociatedControlID="radPreset4" AlternateText="missing preset image" ImageUrl="./images/layout/Preset4.png" runat="server" />                  
                    </li>
                    <li>
                        <asp:RadioButton ID="radPreset5" OnClick="checkQuestion8()" GroupName="layout" runat="server" />                        
                        <asp:Label ID="lblPreset5Radio" AssociatedControlID="radPreset5" runat="server"></asp:Label>
                        <asp:Image ID="imbPreset5" GroupName="layout" AssociatedControlID="radPreset5" AlternateText="missing preset image" ImageUrl="./images/layout/Preset5.png" runat="server" />                  
                    </li>
                    <li>
                        <asp:RadioButton ID="radPreset6" OnClick="checkQuestion8()" GroupName="layout" runat="server" />                        
                        <asp:Label ID="lblPreset6Radio" AssociatedControlID="radPreset6" runat="server"></asp:Label>
                        <asp:Image ID="imbPreset6" GroupName="layout" AssociatedControlID="radPreset6" AlternateText="missing preset image" ImageUrl="./images/layout/Preset6.png" runat="server" />                  
                    </li>
                    <li>
                        <asp:RadioButton ID="radPreset7" OnClick="checkQuestion8()" GroupName="layout" runat="server" />                        
                        <asp:Label ID="lblPreset7Radio" AssociatedControlID="radPreset7" runat="server"></asp:Label>
                        <asp:Image ID="imbPreset7" GroupName="layout" AssociatedControlID="radPreset7" AlternateText="missing preset image" ImageUrl="./images/layout/Preset7.png" runat="server" />                  
                    </li>
                    <li>
                        <asp:RadioButton ID="radPreset8" OnClick="checkQuestion8()" GroupName="layout" runat="server" />                        
                        <asp:Label ID="lblPreset8Radio" AssociatedControlID="radPreset8" runat="server"></asp:Label>
                        <asp:Image ID="imbPreset8" GroupName="layout" AssociatedControlID="radPreset8" AlternateText="missing preset image" ImageUrl="./images/layout/Preset8.png" runat="server" />                  
                    </li>
                    <li>
                        <asp:RadioButton ID="radPreset9" OnClick="checkQuestion8()" GroupName="layout" runat="server" />                        
                        <asp:Label ID="lblPreset9Radio" AssociatedControlID="radPreset9" runat="server"></asp:Label>
                        <asp:Image ID="imbPreset9" GroupName="layout" AssociatedControlID="radPreset9" AlternateText="missing preset image" ImageUrl="./images/layout/Preset9.png" runat="server" />                  
                    </li>
                    <li>
                        <asp:RadioButton ID="radPreset10" OnClick="checkQuestion8()" GroupName="layout" runat="server" />                        
                        <asp:Label ID="lblPreset10Radio" AssociatedControlID="radPreset10" runat="server"></asp:Label>
                        <asp:Image ID="imbPreset10" GroupName="layout" AssociatedControlID="radPreset10" AlternateText="missing preset image" ImageUrl="./images/layout/Preset10.png" runat="server" />                  
                    </li>
                    <li>
                        <asp:RadioButton ID="radPresetF1" OnClick="checkQuestion8()" GroupName="layout" runat="server" />                        
                        <asp:Label ID="lblPresetF1Radio" AssociatedControlID="radPresetF1" runat="server"></asp:Label>
                        <asp:Image ID="imbPresetF1" GroupName="layout" AssociatedControlID="radPresetF1" AlternateText="missing preset image" ImageUrl="./images/layout/PresetS1.png" runat="server" />                  
                    </li>
                    <li>
                        <asp:RadioButton ID="radPresetC1" OnClick="checkQuestion8()" GroupName="layout" runat="server" />                        
                        <asp:Label ID="lblPresetC1Radio" AssociatedControlID="radPresetC1" runat="server"></asp:Label>
                        <asp:Image ID="imbPresetC1" GroupName="layout" AssociatedControlID="radPresetC1" AlternateText="missing preset image" ImageUrl="./images/layout/PresetC1.png" runat="server" />                  
                    </li>

                    <asp:Button ID="btnQuestion8" Enabled="false" CssClass="btnSubmit float-right slidePanel" Text="Confirm all selections" runat="server" OnClientClick="checkQuestion8()" OnClick="btnLayout_Click"/>

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
                <div style="display: none" id="pagerOne">
                    <li>
                            <a href="#" data-slide="#slide1" class="slidePanel">
                                <asp:Label ID="lblSpecsProjectType" runat="server" Text="New/Existing Customer"></asp:Label>
                                <asp:Label ID="lblSpecsProjectTypeAnswer" runat="server" Text="Customer Answer"></asp:Label>
                            </a>
                    </li>
                </div>

                <div style="display: none" id="pagerTwo">
                    <li>
                            <a href="#" data-slide="#slide2" class="slidePanel">
                                <asp:Label ID="lblProjectTag" runat="server" Text="Project tag"></asp:Label>
                                <asp:Label ID="lblProjectTagAnswer" runat="server" Text="Question 2 Answer"></asp:Label>
                            </a>
                    </li>
                </div>

                <div style="display: none" id="pagerThree">
                    <li>
                            <a href="#" data-slide="#slide3" class="slidePanel">
                                <asp:Label ID="lblProjectType" runat="server" Text="Type of project"></asp:Label>
                                <asp:Label ID="lblProjectTypeAnswer" runat="server" Text="Question 3 Answer"></asp:Label>
                            </a>
                    </li>
                </div>

                <div style="display: none" id="pagerFour">
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
                </div>
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

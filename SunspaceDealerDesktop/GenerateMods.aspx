<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GenerateMods.aspx.cs" Inherits="SunspaceDealerDesktop.GenerateMods" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <script src="Scripts/Validation.js"></script>
    <%-- Hidden div populating scripts 
    =================================== --%>
    <script>
        function checkQuestion1() {
            //disable 'next slide' button until after validation
            document.getElementById('MainContent_btnQuestion1').disabled = true;

            if ($('#MainContent_radNewCustomer').is(':checked')) {
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

                    var lengthCheck = document.getElementById("MainContent_hidPhone").value;

                    if (lengthCheck.length == 10) {
                        var validPhone = validatePhone(document.getElementById("MainContent_hidPhone").value);
                        console.log(validPhone);
                    }

                    var zipCode = document.getElementById("MainContent_hidZip").value;

                    if (isNaN(zipCode) || zipCode.length < 5) {
                        console.log("invalid zip");
                    }
                    else {
                        console.log("valid zip");
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
            else if ($('#MainContent_radExistingCustomer').is(':checked')) {
                document.getElementById("MainContent_ddlExistingCustomer").value = $('#MainContent_ddlCustomerFirstName').val();

                if (document.getElementById("MainContent_ddlExistingCustomer").value != "Choose a Customer...") {
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
                else if ($('#MainContent_radSunroomModel200').is(':checked')) {
                    document.getElementById("MainContent_hidModelNumber").value = "200";
                    document.getElementById('pagerThree').style.display = "inline";
                    document.getElementById('MainContent_btnQuestion3').disabled = false;
                }
                else if ($('#MainContent_radSunroomModel300').is(':checked')) {
                    document.getElementById("MainContent_hidModelNumber").value = "300";
                    document.getElementById('pagerThree').style.display = "inline";
                    document.getElementById('MainContent_btnQuestion3').disabled = false;
                }
                else if ($('#MainContent_radSunroomModel400').is(':checked')) {
                    document.getElementById("MainContent_hidModelNumber").value = "400";
                    document.getElementById('pagerThree').style.display = "inline";
                    document.getElementById('MainContent_btnQuestion3').disabled = false;
                }
                else if ($('#MainContent_radSunroomModelShowroom').is(':checked')) {
                    document.getElementById("MainContent_hidModelNumber").value = "Showroom";
                    document.getElementById('pagerThree').style.display = "inline";
                    document.getElementById('MainContent_btnQuestion3').disabled = false;
                }

                document.getElementById("MainContent_hidProjectType").value = "Sunroom";
                $('#MainContent_lblProjectTypeAnswer').text(document.getElementById("MainContent_hidProjectType").value + " of Model " + document.getElementById("MainContent_hidModelNumber").value);
            }
            return false;
        }

        function checkQuestion4() {
            console.log("Checking q4");
            document.getElementById('MainContent_btnQuestion4').disabled = true;
            var optionChecksPassed = false;

            if (document.getElementById("MainContent_txtKneewallHeight").value != "" &&
                document.getElementById("MainContent_ddlKneewallType").value != "" &&
                document.getElementById("MainContent_ddlKneewallColour").value != "") {

                if (isNaN(document.getElementById("MainContent_txtKneewallHeight").value)) {
                    console.log("Invalid kneewall height");
                }
                else {
                    document.getElementById("MainContent_hidKneewallHeight").value = document.getElementById("MainContent_txtKneewallHeight").value;
                    document.getElementById("MainContent_hidKneewallType").value = document.getElementById("MainContent_ddlKneewallType").value;
                    document.getElementById("MainContent_hidKneewallColour").value = document.getElementById("MainContent_ddlKneewallColour").value;
                    optionChecksPassed = true;
                }
            }
            else {
                optionChecksPassed = false;
                //kneewall error styling
            }

            if (document.getElementById("MainContent_txtTransomHeight").value != "" &&
                document.getElementById("MainContent_ddlTransomType").value != "" &&
                document.getElementById("MainContent_ddlTransomColour").value != "") {

                if (isNaN(document.getElementById("MainContent_txtTransomHeight").value)) {
                    console.log("Invalid transom height");
                }
                else {
                    document.getElementById("MainContent_hidTransomHeight").value = document.getElementById("MainContent_txtTransomHeight").value;
                    document.getElementById("MainContent_hidTransomType").value = document.getElementById("MainContent_ddlTransomType").value;
                    document.getElementById("MainContent_hidTransomColour").value = document.getElementById("MainContent_ddlTransomColour").value;
                    optionChecksPassed = true;
                }

            }
            else {
                optionChecksPassed = false;
                //transom error styling
            }

            if (document.getElementById("MainContent_ddlInteriorColour").value != "" &&
                document.getElementById("MainContent_ddlInteriorSkin").value != "" &&
                document.getElementById("MainContent_ddlExteriorColour").value != "" &&
                document.getElementById("MainContent_ddlExteriorSkin").value != "") {

                document.getElementById("MainContent_hidInteriorColour").value = document.getElementById("MainContent_ddlInteriorColour").value;
                document.getElementById("MainContent_hidInteriorSkin").value = document.getElementById("MainContent_ddlInteriorSkin").value;
                document.getElementById("MainContent_hidExteriorColour").value = document.getElementById("MainContent_ddlExteriorColour").value;
                document.getElementById("MainContent_hidExteriorSkin").value = document.getElementById("MainContent_ddlExteriorSkin").value;
                optionChecksPassed = true;
            }
            else {
                optionChecksPassed = false;
                //framing error styling
            }

            if (optionChecksPassed) {
                document.getElementById('MainContent_btnQuestion4').disabled = false;
                $('#MainContent_lblQuestion4PagerAnswer').text("Entry Complete");
                document.getElementById('pagerFour').style.display = "inline";
            }
            document.getElementById('MainContent_btnQuestion4').disabled = false; //autoenable, remove when dropdowns are populated
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
                                                <asp:TextBox ID="txtCustomerFirstName" CssClass="txtField txtInput" onkeyup="checkQuestion1()" OnChange="checkQuestion1()" runat="server" MaxLength="25"></asp:TextBox>
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblCustomerLastName" AssociatedControlID="txtCustomerLastName" runat="server" Text="Last Name:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:TextBox ID="txtCustomerLastName" CssClass="txtField txtInput" onkeyup="checkQuestion1()" OnChange="checkQuestion1()" runat="server" MaxLength="25"></asp:TextBox>
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblCustomerAddress" AssociatedControlID="txtCustomerAddress" runat="server" Text="Address:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:TextBox ID="txtCustomerAddress" CssClass="txtField txtInput" onkeyup="checkQuestion1()" OnChange="checkQuestion1()" runat="server" MaxLength="50"></asp:TextBox>
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblCustomerCity" AssociatedControlID="txtCustomerCity" runat="server" Text="City:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:TextBox ID="txtCustomerCity" CssClass="txtField txtInput" onkeyup="checkQuestion1()" OnChange="checkQuestion1()" runat="server" MaxLength="30"></asp:TextBox>
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblCustomerZip" AssociatedControlID="txtCustomerZip" runat="server" Text="ZIP Code:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:TextBox ID="txtCustomerZip" CssClass="txtField txtZipPhone" onkeyup="checkQuestion1()" OnChange="checkQuestion1()" runat="server" MaxLength="5"></asp:TextBox>
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

        </div> <%-- end .slide-wrapper --%>

    </div> 
    <%-- end .slide-window --%>
    

    <%-- SLIDE PAGING (QUESTION NAVIGATION)
    ======================================== --%>
    <div id="paging-wrapper">    
        <div id="paging"> 
            <h2>Module Specifications</h2>

            <ul>
                <div style="display: none" id="pagerOne">
                    <li>
                            <a href="#" data-slide="#slide1" class="slidePanel">
                                <asp:Label ID="lblSpecsProjectType" runat="server" Text="New/Existing Customer"></asp:Label>
                                <asp:Label ID="lblSpecsProjectTypeAnswer" runat="server" Text="Customer Answer"></asp:Label>
                            </a>
                    </li>
                </div>                
            </ul>    
        </div> <%-- end #paging --%>
    </div>

    <script>
        $(function () {
            $('.ulNavMain').children('a').removeClass('active');
            $('#lnkMainNavNewProject').addClass('active');
        });
    </script>
</asp:Content>


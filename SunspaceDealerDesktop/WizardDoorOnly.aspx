﻿<%@ Page Title="Door Order" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="WizardDoorOnly.aspx.cs" Inherits="SunspaceDealerDesktop.DoorOnlyOrder" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">    
    <script src="Scripts/GlobalFunctions.js"></script>
    <script src="Scripts/Validation.js"></script>
    <script>

        /**
        *customDimension
        *Checks the drop down selection on change, if the selection is custom, displays additional fields,
        *else custom field is hidden (i.e. css style.display = none)
        *@param type - gets the type of door selected (i.e. Cabana, French, Patio);
        *@param dimension - gets the dimension currently being called (i.e Width, Height)
        */
        function customDimension(type, dimension) {

            //Get the respective drop downs selected value, store it into dimensionDDL variable
            var dimensionDDL = document.getElementById('MainContent_ddlDoor' + dimension + type).options[document.getElementById('MainContent_ddlDoor' + dimension + type).selectedIndex].value;

            //If the selected value is custom (i.e. cWidth, etc), perform block
            if (document.getElementById('MainContent_radType' + type).checked && dimensionDDL == 'c' + dimension) {
                //Set display style of respective row to "inherit"
                document.getElementById('MainContent_rowDoorCustom' + dimension + type).style.display = 'inherit';
            }
                //Else, perform block
            else {
                //Set display style of respective row to "none"
                document.getElementById('MainContent_rowDoorCustom' + dimension + type).style.display = 'none';
            }
        }

        /**
        *doorStyle
        *Door style function is triggered when the user selects Vertical Four Track, 
        *vinyl tint becomes displayed, since Vertical Four Track is the only door style
        *that has vinyl tint options
        *@param type - holds the type of door selected (i.e. Cabana, French, Patio);
        */
        function doorStyle(type) {

            //Get value of door style drop down
            var doorStyleDDL = document.getElementById('MainContent_ddlDoorStyle' + type).options[document.getElementById('MainContent_ddlDoorStyle' + type).selectedIndex].value;
            
            //If drop down value is v4TCabana, perform block
            if (doorStyleDDL == 'Vertical 4 Track') {
                //Change door vinyl tint row display style to inherit
                //document.getElementById('MainContent_rowDoorVinylTint' + type).style.display = 'inherit';
                //Change door number of vents row display style to inherit
                //document.getElementById('MainContent_rowDoorNumberOfVents' + type).style.display = 'inherit';
                //Change door screen options row display style to none
                document.getElementById('MainContent_rowDoorScreenTypes' + type).style.display = 'none';
                //Change door glass tint row display style to none
                document.getElementById('MainContent_rowDoorGlassTint' + type).style.display = 'none';

                displayMixedTint(type);
            }
            else if (doorStyleDDL == 'Full Screen' || doorStyleDDL == 'Screen') {
                //Change door screen options row display style to inherit
                document.getElementById('MainContent_rowDoorScreenTypes' + type).style.display = 'inherit';
                //Change door vinyl tint row display style to none
                //document.getElementById('MainContent_rowDoorVinylTint' + type).style.display = 'none';
                //Change door number of vents row display style to inherit
                //document.getElementById('MainContent_rowDoorNumberOfVents' + type).style.display = 'none';
                //Change door glass tint row display style to none
                document.getElementById('MainContent_rowDoorGlassTint' + type).style.display = 'none';
            }
                //else, perform block
            else {
                //Change door vinyl tint row display style to none
                //document.getElementById('MainContent_rowDoorVinylTint' + type).style.display = 'none';
                //Change door number of vents row display style to inherit
                //document.getElementById('MainContent_rowDoorNumberOfVents' + type).style.display = 'none';
                //Change door screen options row display style to none
                document.getElementById('MainContent_rowDoorScreenTypes' + type).style.display = 'none';
                //Change door glass tint row display style to inherit
                document.getElementById('MainContent_rowDoorGlassTint' + type).style.display = 'inherit';
            }
        }

        /**
        *displayMixedTint
        *This function is used to display invidual window tints on a vertical 4 track
        *only if the "Mixed" option is selected.
        *@param type - holds the type of door selected (i.e. Cabana, French, Patio);
        */
        function displayMixedTint(type) {
            if ($('#MainContent_ddlDoorVinylTint' + type).val() == "Mixed") {
                if ($('#MainContent_ddlDoorNumberOfVents' + type).val() == "3") {
                    document.getElementById('MainContent_row0DoorTint' + type).style.display = "inherit";
                    document.getElementById('MainContent_row1DoorTint' + type).style.display = "inherit";
                    document.getElementById('MainContent_row2DoorTint' + type).style.display = "inherit";
                    document.getElementById('MainContent_row3DoorTint' + type).style.display = "none";
                }
                else if ($('#MainContent_ddlDoorNumberOfVents' + type).val() == "4") {
                    document.getElementById('MainContent_row0DoorTint' + type).style.display = "inherit";
                    document.getElementById('MainContent_row1DoorTint' + type).style.display = "inherit";
                    document.getElementById('MainContent_row2DoorTint' + type).style.display = "inherit";
                    document.getElementById('MainContent_row3DoorTint' + type).style.display = "inherit";
                }
            }
            else {
                document.getElementById('MainContent_row0DoorTint' + type).style.display = "none";
                document.getElementById('MainContent_row1DoorTint' + type).style.display = "none";
                document.getElementById('MainContent_row2DoorTint' + type).style.display = "none";
                document.getElementById('MainContent_row3DoorTint' + type).style.display = "none";
            }
        }

        /**
        *typeOfRowsDisplayed
        *This function finds which type of door is selected and displays the appropriate fields
        *from a table hidden from the user
        *@param type - gets the type of door selected (i.e. Cabana, French, Patio)
        */
        function typeRowsDisplayed(type) {

            /****START:TABLE ROWS BY ID****/
            var doorTitle = document.getElementById("MainContent_rowDoorTitle" + type);
            var doorStyleTable = document.getElementById("MainContent_rowDoorStyle" + type);
            var doorVinylTint = document.getElementById("MainContent_rowDoorVinylTint" + type);
            var doorNumberOfVents = document.getElementById("MainContent_rowDoorNumberOfVents" + type);
            var doorKickplate = document.getElementById("MainContent_rowDoorKickplate" + type);
            var doorKicplateCustom = document.getElementById("MainContent_rowDoorCustomKickplate" + type);
            var doorColour = document.getElementById("MainContent_rowDoorColour" + type);
            var doorHeight = document.getElementById("MainContent_rowDoorHeight" + type);
            var doorHeightCustom = document.getElementById("MainContent_rowDoorCustomHeight" + type);
            var doorWidth = document.getElementById("MainContent_rowDoorWidth" + type);
            var doorWidthCustom = document.getElementById("MainContent_rowDoorCustomWidth" + type);
            var doorOperatorLHH = document.getElementById("MainContent_rowDoorOperatorLHH" + type);
            var doorOperatorRHH = document.getElementById("MainContent_rowDoorOperatorRHH" + type);
            var doorBoxHeader = document.getElementById("MainContent_rowDoorBoxHeader" + type);
            var doorGlassTint = document.getElementById("MainContent_rowDoorGlassTint" + type);
            var doorHingeLHH = document.getElementById("MainContent_rowDoorHingeLHH" + type);
            var doorHingeRHH = document.getElementById("MainContent_rowDoorHingeRHH" + type);
            var doorScreenTypes = document.getElementById("MainContent_rowDoorScreenTypes" + type);
            var doorHardware = document.getElementById("MainContent_rowDoorHardware" + type);
            var doorSwingIn = document.getElementById("MainContent_rowDoorSwingIn" + type);
            var doorSwingOut = document.getElementById("MainContent_rowDoorSwingOut" + type);
            /****END:TABLE ROWS BY ID****/

            /****START:RADIO BUTTONS TO BE CHECKED INITIALLY****/
            var doorHingeLHHChecked = document.getElementById("MainContent_radDoorHinge" + type);
            var doorSwingInChecked = document.getElementById("MainContent_radDoorSwing" + type);

            //FRENCH/PATIO DOOR ONLY
            var doorOperatorLHHChecked = document.getElementById("MainContent_radDoorOperator" + type);
            /****END:RADIO BUTTONS TO BE CHECKED INITIALLY****/

            //If type is Cabana, display the appropriate fields
            if (type == "Cabana") {

                /****FIELDS TO DISPLAY****/
                //General
                doorTitle.style.display = "inherit";
                doorStyleTable.style.display = "inherit";
                doorColour.style.display = "inherit";
                doorHeight.style.display = "inherit";
                doorWidth.style.display = "inherit";
                //doorBoxHeader.style.display = "inherit";
                doorKickplate.style.display = "inherit";
                //doorVinylTint.style.display = "inherit";

                //Cabana Specific                            
                doorGlassTint.style.display = "inherit";
                doorHingeLHH.style.display = "inherit";
                doorHingeRHH.style.display = "inherit";
                doorSwingIn.style.display = "inherit";
                doorSwingOut.style.display = "inherit";
                doorHardware.style.display = "inherit";
                
                //Radio button defaults
                doorHingeLHHChecked.setAttribute("checked", "checked");
                doorSwingInChecked.setAttribute("checked", "checked");

                doorStyle(type);
            }
                //If type is French, display the appropriate fields
            else if (type == "French") {

                //General
                doorTitle.style.display = "inherit";
                doorStyleTable.style.display = "inherit";
                doorColour.style.display = "inherit";
                doorHeight.style.display = "inherit";
                doorWidth.style.display = "inherit";
                //doorBoxHeader.style.display = "inherit";
                doorKickplate.style.display = "inherit";
                //doorVinylTint.style.display = "inherit";

                //French specific
                doorOperatorLHH.style.display = "inherit";
                doorOperatorRHH.style.display = "inherit";
                doorSwingIn.style.display = "inherit";
                doorSwingOut.style.display = "inherit";
                doorHardware.style.display = "inherit";

                //Radio button defaults
                doorOperatorLHHChecked.setAttribute("checked", "checked");
                doorSwingInChecked.setAttribute("checked", "checked");

                doorStyle(type);
            }
                //If type is Patio, display the appropriate fields
            else if (type == "Patio") {

                //General
                doorTitle.style.display = "inherit";
                doorStyleTable.style.display = "inherit";
                doorColour.style.display = "inherit";
                doorHeight.style.display = "inherit";
                doorWidth.style.display = "inherit";
                //doorBoxHeader.style.display = "inherit";

                //Patio Specifics
                doorGlassTint.style.display = "inherit";
                doorOperatorLHH.style.display = "inherit";
                doorOperatorRHH.style.display = "inherit";
                doorScreenTypes.style.display = "inherit";

                //Radio button defaults
                doorOperatorLHHChecked.setAttribute("checked", "checked");

                doorStyle(type);
            }
        }


        /********FUNCTIONS TAKEN FROM WINDOW ONLY ORDER FOR UNEVEN VENTS*******/

        /*
        This function re validates and re calculates the values of height and width of the door and vent sizes
        */
        function recalculate() {

            var height = document.getElementById('MainContent_txtDoorHeightVinyl').value;
            var asIfHeight = document.getElementById('MainContent_txtDoorAsIfHeightVinyl').value;
            var width = document.getElementById('MainContent_txtDoorWidthVinyl').value;

            if (!validateInteger(asIfHeight)) asIfHeight = height; //if asIfHeight = null, set the value of height to it

            if (!validateInteger(height) || //height is not a valid integer
                !validateInteger(asIfHeight) || //as-if height is not a valid integer
                !validateInteger(width)) { //width is not a valid integer

                //error: please input a valid Height and Build-As-If Height
                //alert("enter some numbers you fool!");
                errorMessage.text("enter some numbers you foo!");
                document.getElementById('MainContent_radDoorBottomRadVinyl').checked = true;
                topOrBottomUnevenClicked();
            }
            else if (width < MIN_WIDTH_BUILDABLE || width > MAX_WIDTH_BUILDABLE ||
                 height < MIN_HEIGHT_BUILDABLE || height > MAX_HEIGHT_BUILDABLE ||
                 asIfHeight < MIN_HEIGHT_BUILDABLE || asIfHeight > MAX_HEIGHT_BUILDABLE) {
                //error: please input a valid Height and Build-As-If Height
                //alert("not buildable!");
                errorMessage.text("not buildable");
                document.getElementById('MainContent_radDoorBottomRadVinyl').checked = true;
                topOrBottomUnevenClicked();
            }
            else if (width < MIN_WIDTH_WARRANTY || width > MAX_WIDTH_WARRANTY ||
                 height < MIN_HEIGHT_WARRANTY || height > MAX_HEIGHT_WARRANTY ||
                 asIfHeight < MIN_HEIGHT_WARRANTY || asIfHeight > MAX_HEIGHT_WARRANTY) {
                //error: please input a valid Height and Build-As-If Height
                //alert("buildable but not under warranty!");
                errorMessage.text("buildable but not under warranty");
                document.getElementById('MainContent_radDoorBottomRadVinyl').checked = true;
                topOrBottomUnevenClicked();
            }
            else {
                getHeightAndWidthOfEachVent(true);
            }
            //everything including vent sizes, DLO/Deductions, etc.
        }


        /*
        This function checks if a value is a valid integer
        @param value - value to be checked
        @return valid - true or false
        */
        function validateInteger(value) {

            var valid;
            if (isNaN(value)) {
                valid = false;
            }
            else { //is a number
                if (value.indexOf('.') === -1) { //doesn't contain a period
                    valid = true;
                }
                else {
                    valid = false;
                }

                if (value <= 0) {  //negative number or zero
                    valid = false;
                }
                else { //positive number
                    valid = true;
                }
            }
            return valid;
        }

        /*
        This function gets the height and width of each vent on a V4T door
        Part of this code is the replica of Dan H's code to get the height and width 
        This function also determines and sets the size of each vent for an uneven vent door
        @param asIf - build as if value given (true or false)
        */
        function getHeightAndWidthOfEachVent(asIf) {

            if (typeof (asIf) === 'undefined') asIf = false; //if asIf not specified set it by default to false

            var ventCount = document.getElementById('MainContent_ddlDoorV4TNumberOfVentsVinyl').options[document.getElementById('MainContent_ddlDoorV4TNumberOfVentsVinyl').selectedIndex].value;
            var doorWidth = document.getElementById('MainContent_txtDoorWidthVinyl').value + document.getElementById('MainContent_ddlDoorWidthVinyl').options[document.getElementById('MainContent_ddlDoorWidthVinyl').selectedIndex].value;
            var doorHeight = (asIf) ? document.getElementById('MainContent_txtDoorAsIfHeightVinyl').value + document.getElementById('MainContent_ddlDoorAsIfHeightVinyl').options[document.getElementById('MainContent_ddlDoorAsIfHeightVinyl').selectedIndex].value :
                                        document.getElementById('MainContent_txtDoorHeightVinyl').value + document.getElementById('MainContent_ddlDoorHeightVinyl').options[document.getElementById('MainContent_ddlDoorHeightVinyl').selectedIndex].value;
            var asIfHeight = document.getElementById('MainContent_txtDoorAsIfHeightVinyl').value + document.getElementById('MainContent_ddlDoorAsIfHeightVinyl').options[document.getElementById('MainContent_ddlDoorAsIfHeightVinyl').selectedIndex].value;
            var height = document.getElementById('MainContent_txtDoorHeightVinyl').value + document.getElementById('MainContent_ddlDoorHeightVinyl').options[document.getElementById('MainContent_ddlDoorHeightVinyl').selectedIndex].value;

            if (ventCount > 8) {
                ventWidth = (parseFloat(doorWidth) - 1.5625 - 2.75) / 3;
            }
            else if (ventCount > 4) {
                ventWidth = (parseFloat(doorWidth) - 1.5625 - 1.6875) / 2;
            }
            else {
                ventWidth = parseFloat(doorWidth) - 1.5625;
            }

            if (ventCount % 4 === 0) {
                ventHeight = (parseFloat(doorHeight) + 2.187) / 4;
            }
            else if (ventCount % 3 === 0) {
                ventHeight = (parseFloat(doorHeight) + 1.3125) / 3;
            }
            else {
                ventHeight = (parseFloat(doorHeight) + 0.4375) / 2;
            }

            ventHeight = Math.round(parseFloat(ventHeight) * 100) / 100;
            ventWidth = Math.round(parseFloat(ventWidth) * 100) / 100;

            ventTopHeight = ventHeight;
            vent2Height = ventHeight;
            vent3Height = ventHeight;
            ventBottomHeight = ventHeight;

            if (parseFloat(height) > parseFloat(asIfHeight)) { //if height > as if height

                var extraHeight = parseFloat(height) - parseFloat(asIfHeight);

                if ($("#MainContent_radDoorTopRadVinyl").is(':checked')) {
                    ventTopHeight = parseFloat(ventTopHeight) - parseFloat(extraHeight);
                }
                else if ($("#MainContent_radDoorBottomRadVinyl").is(':checked')) {
                    ventBottomHeight = parseFloat(ventBottomHeight) - parseFloat(extraHeight);
                }
                else if ($("#MainContent_radDoorBothRadVinyl").is(':checked')) {
                    ventTopHeight = parseFloat(ventTopHeight) - (Math.round((parseFloat(extraHeight) / 2) * 100) / 100);
                    ventBottomHeight = parseFloat(ventBottomHeight) - (Math.round((parseFloat(extraHeight) / 2) * 100) / 100);
                }
            }
            else if (parseFloat(asIfHeight) > parseFloat(height)) { // if as if height > height

                var remainingHeight = parseFloat(asIfHeight) - parseFloat(height);

                if ($("#MainContent_radDoorTopRadVinyl").is(':checked')) {
                    ventTopHeight = parseFloat(ventTopHeight) + parseFloat(remainingHeight);
                }
                else if ($("#MainContent_radDoorBottomRadVinyl").is(':checked')) {
                    ventBottomHeight = parseFloat(ventBottomHeight) + parseFloat(remainingHeight);
                }
                else if ($("#MainContent_radDoorBothRadVinyl").is(':checked')) {
                    ventTopHeight = parseFloat(ventTopHeight) + (Math.round((parseFloat(remainingHeight) / 2) * 100) / 100);
                    ventBottomHeight = parseFloat(ventBottomHeight) + (Math.round((parseFloat(remainingHeight) / 2) * 100) / 100);
                }
            }
            else { //as if height === height, thus, not uneven

                ventTopHeight = ventHeight;
                vent2Height = ventHeight;
                vent3Height = ventHeight;
                ventBottomHeight = ventHeight;
            }

            $("#MainContent_txtDoorTopVentHeightVinyl").val(ventTopHeight);
            $("#MainContent_txtDoorBottomVentHeightVinyl").val(ventBottomHeight);

        }


        /**
        This function gets called when values in the top uneven vent or bottom unevent vent
        textboxes are changed. This function dynamically updates both textboxes (top and bottom)
        with the appropriate values 
        @param value - value in the textbox
        @param sender - "top" or "bottom" the textbox which triggered this function
        */
        function adjustVentHeights(value, sender) {

            var actualValue;

            if (value < 0 || value > (parseFloat(ventTopHeight) + parseFloat(ventBottomHeight))) {
                errorMessage.val("invalid change!");
            }
            else {

                if (sender === "top") {

                    if (parseFloat(value) > parseFloat(ventTopHeight)) {
                        actualValue = parseFloat(value) - parseFloat(ventTopHeight);
                        ventTopHeight = parseFloat(ventTopHeight) + parseFloat(actualValue);
                        ventBottomHeight = parseFloat(ventBottomHeight) - parseFloat(actualValue);
                    }
                    else if (parseFloat(value) < parseFloat(ventTopHeight)) {
                        actualValue = parseFloat(ventTopHeight) - parseFloat(value);
                        ventTopHeight = parseFloat(ventTopHeight) - parseFloat(actualValue);
                        ventBottomHeight = parseFloat(ventBottomHeight) + parseFloat(actualValue);
                    }
                }
                else if (sender === "bottom") {
                    if (parseFloat(value) > parseFloat(ventTopHeight)) {
                        actualValue = parseFloat(value) - parseFloat(ventBottomHeight);
                        ventTopHeight = parseFloat(ventTopHeight) - parseFloat(actualValue);
                        ventBottomHeight = parseFloat(ventBottomHeight) + parseFloat(actualValue);
                    }
                    else if (parseFloat(value) < parseFloat(ventTopHeight)) {
                        actualValue = parseFloat(ventBottomHeight) - parseFloat(value);
                        ventTopHeight = parseFloat(ventTopHeight) + parseFloat(actualValue);
                        ventBottomHeight = parseFloat(ventBottomHeight) - parseFloat(actualValue);
                    }
                }
            }
            $("#MainContent_txtDoorTopVentHeightVinyl").val(Math.round(parseFloat(ventTopHeight) * 100) / 100);
            $("#MainContent_txtDoorBottomVentHeightVinyl").val(Math.round(parseFloat(ventBottomHeight) * 100) / 100);

        }


        /*
        This function gets called when the user selects both uneven vents radio button
        It displays the appropriate rows and recalculates all the values
        */
        function bothUnevenClicked() {
            getHeightAndWidthOfEachVent(true);

            document.getElementById('MainContent_txtDoorTopVentHeightVinyl').value = ventTopHeight;
            document.getElementById('MainContent_txtDoorBottomVentHeightVinyl').value = ventBottomHeight;

            document.getElementById('MainContent_rowDoorUnevenVentsTopVinyl').style.display = 'table-row';
            document.getElementById('MainContent_rowDoorUnevenVentsBottomVinyl').style.display = 'table-row';

        }

        /*
        This function gets called when the user selects top or bottom uneven vents radio button
        It hides the appropriate rows (undoes what bothUnevenClicked() did)
        */
        function topOrBottomUnevenClicked() {
            document.getElementById('MainContent_txtDoorTopVentHeightVinyl').value = '';
            document.getElementById('MainContent_txtDoorBottomVentHeightVinyl').value = '';

            document.getElementById('MainContent_rowDoorUnevenVentsTopVinyl').style.display = 'none';
            document.getElementById('MainContent_rowDoorUnevenVentsBottomVinyl').style.display = 'none';

            getHeightAndWidthOfEachVent(true);
        }

        /*
        This function gets called when uneven vents check box is clicked
        It hides and displays appropriate rows depending on whether the checkbox is checked or unchecked
        @param checked - true or false
        */
        function unevenVentsChecked(checked, title) {
            if (checked) {
                document.getElementById('MainContent_rowDoorAsIfHeight' + title).style.display = 'table-row';
                document.getElementById('MainContent_rowDoorTopBottomBothRad' + title).style.display = 'table-row';

                if (document.getElementById('MainContent_txtDoorAsIfHeight' + title).value === '')
                    document.getElementById('MainContent_txtDoorAsIfHeight' + title).value = document.getElementById('MainContent_txtDoorHeight' + title).value;

                if (document.getElementById('MainContent_ddlDoorAsIfHeight' + title).selectedIndex === 0)
                    document.getElementById('MainContent_ddlDoorAsIfHeight' + title).selectedIndex = document.getElementById('MainContent_ddlDoorHeight' + title).selectedIndex;

                if (document.getElementById('MainContent_radDoorBothRad' + title).checked) {
                    bothUnevenClicked();
                }
            }
            else {
                document.getElementById('MainContent_rowDoorUnevenVentsTop' + title).style.display = 'none';
                document.getElementById('MainContent_txtDoorTopVentHeight' + title).value = '';
                document.getElementById('MainContent_rowDoorUnevenVentsBottom' + title).style.display = 'none';
                document.getElementById('MainContent_txtDoorBottomVentHeight' + title).value = '';
                document.getElementById('MainContent_rowDoorAsIfHeight' + title).style.display = 'none';
                document.getElementById('MainContent_rowDoorTopBottomBothRad' + title).style.display = 'none';
            }
        }

        /*
        This function gets called when tint options are changed
        It displays appropriate number of mixed tint rows based on the user selections
        */
        function tintOptionsChanged() {
            var tempVents;
            var tintValue = document.getElementById('MainContent_ddlDoorTintVinyl').options[document.getElementById('MainContent_ddlDoorTintVinyl').selectedIndex].value;
            var numOfVents = document.getElementById('MainContent_ddlDoorV4TNumberOfVentsVinyl').options[document.getElementById('MainContent_ddlDoorV4TNumberOfVentsVinyl').selectedIndex].value;

            var vinylRows = (numOfVents == 12) ? 4 :
                            (numOfVents == 9) ? 3 :
                            (numOfVents == 8) ? 4 :
                            (numOfVents == 6) ? 3 :
                            (numOfVents == 4) ? 4 : 3;

            if (tempVents != numOfVents) {
                tempVents = numOfVents;
                for (var i = 0; i < 4; i++) {
                    document.getElementById('MainContent_row' + i + 'DoorTintVinyl').style.display = 'none';
                }
                for (var i = 0; i < vinylRows; i++) {
                    document.getElementById('MainContent_row' + i + 'DoorTintVinyl').style.display = 'table-row';
                }
            }

            if (tintValue == "Mixed") {
                for (var i = 0; i < 4; i++) {
                    document.getElementById('MainContent_row' + i + 'DoorTintVinyl').style.display = 'none';
                }
                for (var i = 0; i < vinylRows; i++) {
                    document.getElementById('MainContent_row' + i + 'DoorTintVinyl').style.display = 'table-row';
                }
            }
            else {
                for (var i = 0; i < 4; i++) {
                    document.getElementById('MainContent_row' + i + 'DoorTintVinyl').style.display = 'none';
                }
            }
        }

    </script>

    <div class="slide-window" id="slide-window" >
        <div class="slide-wrapper">
            <%-- QUESTION 3 - DOOR OPTIONS/DETAILS
            ======================================== --%>

            <div id="slide3" class="slide">
                <h1>
                    <asp:Label ID="lblDoorDetails" runat="server" Text="Door Details"></asp:Label>
                </h1>        
                              
                <ul class="toggleOptions">
                    <asp:PlaceHolder ID="DoorOptions" runat="server"></asp:PlaceHolder>                    
                </ul>            

                <asp:Button ID="btnQuestion3" Enabled="true" CssClass="btnSubmit float-right slidePanel" runat="server" Text="Done Ordering Doors"/>

            </div>
            <%-- end #slide3 --%>

         </div>
    </div>

<%-- SLIDE PAGING (QUESTION NAVIGATION)
    ======================================== --%>
    <div id="sidebar">
        <div id="paging-wrapper">    
            <div id="paging"> 
                <h2>Door Specifications</h2>
                <asp:PlaceHolder ID="lblDoorPager" runat="server"></asp:PlaceHolder>  
            </div> <%-- end #paging --%>      
        </div>

        <%--<asp:Label ID="lblErrorMessage" CssClass="lblErrorMessage" runat="server" Text="Label">Oh hello, I am an error message.</asp:Label>--%>
        <textarea id="txtErrorMessage" class="txtErrorMessage" disabled="disabled" rows="5" runat="server"></textarea>
    </div>
    <div id="hiddenFieldsDiv" runat="server"></div>
</asp:Content>
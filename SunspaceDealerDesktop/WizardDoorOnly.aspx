<%@ Page Title="Door Order" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="WizardDoorOnly.aspx.cs" Inherits="SunspaceDealerDesktop.DoorOnlyOrder" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">    
    <script src="Scripts/GlobalFunctions.js"></script>
    <script src="Scripts/Validation.js"></script>
    <script>
        
        var V4T_3V_MIN_WIDTH_BUILDABLE = <%= V4T_3V_MIN_WIDTH_BUILDABLE%>;
        var V4T_4V_MIN_WIDTH_BUILDABLE = <%= V4T_4V_MIN_WIDTH_BUILDABLE%>;
        var V4T_3V_MIN_WIDTH_WARRANTY = <%= V4T_3V_MIN_WIDTH_WARRANTY%>;
        var V4T_4V_MIN_WIDTH_WARRANTY = <%= V4T_4V_MIN_WIDTH_WARRANTY%>;
        var V4T_3V_MAX_WIDTH_BUILDABLE = <%= V4T_3V_MAX_WIDTH_BUILDABLE%>;
        var V4T_4V_MAX_WIDTH_BUILDABLE = <%= V4T_4V_MAX_WIDTH_BUILDABLE%>;
        var V4T_3V_MAX_WIDTH_WARRANTY = <%= V4T_3V_MAX_WIDTH_WARRANTY%>;
        var V4T_4V_MAX_WIDTH_WARRANTY = <%= V4T_4V_MAX_WIDTH_WARRANTY%>;
        var V4T_3V_MIN_HEIGHT_BUILDABLE = <%= V4T_3V_MIN_HEIGHT_BUILDABLE%>;
        var V4T_4V_MIN_HEIGHT_BUILDABLE = <%= V4T_4V_MIN_HEIGHT_BUILDABLE%>;
        var V4T_3V_MIN_HEIGHT_WARRANTY = <%= V4T_3V_MIN_HEIGHT_WARRANTY%>;
        var V4T_4V_MIN_HEIGHT_WARRANTY = <%= V4T_4V_MIN_HEIGHT_WARRANTY%>;
        var V4T_3V_MAX_HEIGHT_BUILDABLE = <%= V4T_3V_MAX_HEIGHT_BUILDABLE%>;
        var V4T_4V_MAX_HEIGHT_BUILDABLE = <%= V4T_4V_MAX_HEIGHT_BUILDABLE%>;
        var V4T_3V_MAX_HEIGHT_WARRANTY = <%= V4T_3V_MAX_HEIGHT_WARRANTY%>;
        var V4T_4V_MAX_HEIGHT_WARRANTY = <%= V4T_4V_MAX_HEIGHT_WARRANTY%>;

        var ventHeight; //height vents

        var ventTopHeight;
        var vent2Height;
        var vent3Height;
        var ventBottomHeight;

        var ventWidth; //width vents

        var MIN_WIDTH_BUILDABLE;
        var MAX_WIDTH_BUILDABLE;
        var MIN_HEIGHT_BUILDABLE;
        var MAX_HEIGHT_BUILDABLE;
        var MIN_WIDTH_WARRANTY;
        var MAX_WIDTH_WARRANTY;
        var MIN_HEIGHT_WARRANTY;
        var MAX_HEIGHT_WARRANTY;

        var errorMessage;

        $(document).ready(function(){
            errorMessage = document.getElementById("MainContent_txtErrorMessage");
        });

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
                document.getElementById('MainContent_rowDoorVinylTint' + type).style.display = 'inherit';
                //Change door number of vents row display style to inherit
                document.getElementById('MainContent_rowDoorV4TNumberOfVents' + type).style.display = 'inherit';
                //Change door screen options row display style to none
                document.getElementById('MainContent_rowDoorScreenTypes' + type).style.display = 'none';
                //Change door glass tint row display style to none
                document.getElementById('MainContent_rowDoorGlassTint' + type).style.display = 'none';

                windowVinylNumberOfVentsChanged($('#MainContent_ddlDoorV4TNumberOfVents' + type + ' option:selected').val());

                displayMixedTint(type);
            }
            else if (doorStyleDDL == 'Full Screen' || doorStyleDDL == 'Screen') {
                //Change door screen options row display style to inherit
                document.getElementById('MainContent_rowDoorScreenTypes' + type).style.display = 'inherit';
                //Change door vinyl tint row display style to none
                document.getElementById('MainContent_rowDoorVinylTint' + type).style.display = 'none';
                //Change door number of vents row display style to inherit
                document.getElementById('MainContent_rowDoorV4TNumberOfVents' + type).style.display = 'none';
                //Change door glass tint row display style to none
                document.getElementById('MainContent_rowDoorGlassTint' + type).style.display = 'none';

                document.getElementById("MainContent_rowDoorAsIfHeight" + type).style.display = 'none';

                document.getElementById("MainContent_rowDoorTopBottomBothRad" + type).style.display = 'none';

                displayMixedTint(type);
            }
                //else, perform block
            else {
                //Change door vinyl tint row display style to none
                document.getElementById('MainContent_rowDoorVinylTint' + type).style.display = 'none';
                //Change door number of vents row display style to inherit
                document.getElementById('MainContent_rowDoorV4TNumberOfVents' + type).style.display = 'none';
                //Change door screen options row display style to none
                document.getElementById('MainContent_rowDoorScreenTypes' + type).style.display = 'none';
                //Change door glass tint row display style to inherit
                document.getElementById('MainContent_rowDoorGlassTint' + type).style.display = 'inherit';

                document.getElementById("MainContent_rowDoorAsIfHeight" + type).style.display = 'none';

                document.getElementById("MainContent_rowDoorTopBottomBothRad" + type).style.display = 'none';                

                displayMixedTint(type);
            }
        }

        /**
        This function sets the appropriate MIX/MAX size values depending on the number of vents
        */
        function windowVinylNumberOfVentsChanged(vents) {
            switch (vents) { //this switch statement checks the number of vents selected in a V4T type of window, and sets the validation constants to the values for a V4T window with that many vents
                case "3":
                    MIN_WIDTH_BUILDABLE = V4T_3V_MIN_WIDTH_BUILDABLE;
                    MAX_WIDTH_BUILDABLE = V4T_3V_MAX_WIDTH_BUILDABLE;
                    MIN_HEIGHT_BUILDABLE = V4T_3V_MIN_HEIGHT_BUILDABLE;
                    MAX_HEIGHT_BUILDABLE = V4T_3V_MAX_HEIGHT_BUILDABLE;
                    MIN_WIDTH_WARRANTY = V4T_3V_MIN_WIDTH_WARRANTY;
                    MAX_WIDTH_WARRANTY = V4T_3V_MAX_WIDTH_WARRANTY;
                    MIN_HEIGHT_WARRANTY = V4T_3V_MIN_HEIGHT_WARRANTY;
                    MAX_HEIGHT_WARRANTY = V4T_3V_MAX_HEIGHT_WARRANTY;
                    break;
                case "4":
                    MIN_WIDTH_BUILDABLE = V4T_4V_MIN_WIDTH_BUILDABLE;
                    MAX_WIDTH_BUILDABLE = V4T_4V_MAX_WIDTH_BUILDABLE;
                    MIN_HEIGHT_BUILDABLE = V4T_4V_MIN_HEIGHT_BUILDABLE;
                    MAX_HEIGHT_BUILDABLE = V4T_4V_MAX_HEIGHT_BUILDABLE;
                    MIN_WIDTH_WARRANTY = V4T_4V_MIN_WIDTH_WARRANTY;
                    MAX_WIDTH_WARRANTY = V4T_4V_MAX_WIDTH_WARRANTY;
                    MIN_HEIGHT_WARRANTY = V4T_4V_MIN_HEIGHT_WARRANTY;
                    MAX_HEIGHT_WARRANTY = V4T_4V_MAX_HEIGHT_WARRANTY;
                    break;
            }
        }


        /**
        *displayMixedTint
        *This function is used to display invidual window tints on a vertical 4 track
        *only if the "Mixed" option is selected.
        *@param type - holds the type of door selected (i.e. Cabana, French, Patio)
        */
        function displayMixedTint(type) {
            if ($('#MainContent_ddlDoorVinylTint' + type).val() == "Mixed") {
                if ($('#MainContent_ddlDoorV4TNumberOfVents' + type).val() == "3") {
                    document.getElementById('MainContent_row0DoorTint' + type).style.display = "inherit";
                    document.getElementById('MainContent_row1DoorTint' + type).style.display = "inherit";
                    document.getElementById('MainContent_row2DoorTint' + type).style.display = "inherit";
                    document.getElementById('MainContent_row3DoorTint' + type).style.display = "none";
                }
                else if ($('#MainContent_ddlDoorV4TNumberOfVents' + type).val() == "4") {
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
            if ($('#MainContent_ddlDoorStyle' + type + ' option:selected').val() != 'Vertical 4 Track') {
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
            var doorNumberOfVents = document.getElementById("MainContent_rowDoorV4TNumberOfVents" + type);
            var doorKickplate = document.getElementById("MainContent_rowDoorKickplate" + type);
            var doorKicplateCustom = document.getElementById("MainContent_rowDoorCustomKickplate" + type);
            var doorColour = document.getElementById("MainContent_rowDoorColour" + type);
            var doorHeight = document.getElementById("MainContent_rowDoorHeight" + type);
            var doorWidth = document.getElementById("MainContent_rowDoorWidth" + type);
            var topBotBothVents = document.getElementById("MainContent_rowDoorTopBottomBothRad" + type);
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
        function recalculate(title) {
            if ($('#MainContent_ddlDoorStyle' + title + ' option:selected').val() == 'Vertical 4 Track'){
                if ($('#MainContent_radTypeFrench').is(':checked')){
                    MIN_WIDTH_BUILDABLE = MIN_WIDTH_BUILDABLE * 2;
                    MAX_WIDTH_BUILDABLE = MAX_WIDTH_BUILDABLE * 2;
                    //MIN_HEIGHT_BUILDABLE *= 2;
                    //MAX_HEIGHT_BUILDABLE *= 2;
                    MIN_WIDTH_WARRANTY = MIN_WIDTH_WARRANTY * 2;
                    MAX_WIDTH_WARRANTY = MAX_WIDTH_WARRANTY * 2;
                    //MIN_HEIGHT_WARRANTY *= 2;
                    //MAX_HEIGHT_WARRANTY *= 2;
                }
                var height = document.getElementById('MainContent_txtDoorHeight' + title).value;
                var asIfHeight = document.getElementById('MainContent_txtDoorAsIfHeight' + title).value;
                var width = document.getElementById('MainContent_txtDoorWidth' + title).value;

                if (!validateInteger(asIfHeight)) asIfHeight = height; //if asIfHeight = null, set the value of height to it

                if (!validateInteger(height) || //height is not a valid integer
                    !validateInteger(asIfHeight) || //as-if height is not a valid integer
                    !validateInteger(width)) { //width is not a valid integer

                    //error: please input a valid Height and Build-As-If Height
                    //alert("enter some numbers you fool!");
                    errorMessage.value = "Please enter both a height and width.";
                    $('MainContent_radDoorBottomRad' + title).prop('checked', true);
                    //document.getElementById('MainContent_radDoorBottomRad' + title).checked = true;
                    topOrBottomUnevenClicked(title);
                }
                else if (width < MIN_WIDTH_BUILDABLE || width > MAX_WIDTH_BUILDABLE ||
                     height < MIN_HEIGHT_BUILDABLE || height > MAX_HEIGHT_BUILDABLE ||
                     asIfHeight < MIN_HEIGHT_BUILDABLE || asIfHeight > MAX_HEIGHT_BUILDABLE) {
                    //error: please input a valid Height and Build-As-If Height
                    //alert("not buildable!");
                    errorMessage.value = "Not buildable, the buildable dimensions are: " 
                        + MAX_HEIGHT_BUILDABLE + "(Height) x " + MAX_WIDTH_BUILDABLE + "(Width) to "
                        + MIN_HEIGHT_BUILDABLE + "(Height) x " + MIN_WIDTH_BUILDABLE + "(Width).";
                    $('MainContent_radDoorBottomRad' + title).prop('checked', true);
                    //document.getElementById('MainContent_radDoorBottomRad' + title).checked = true;
                    topOrBottomUnevenClicked(title);
                }
                else if (width < MIN_WIDTH_WARRANTY || width > MAX_WIDTH_WARRANTY ||
                     height < MIN_HEIGHT_WARRANTY || height > MAX_HEIGHT_WARRANTY ||
                     asIfHeight < MIN_HEIGHT_WARRANTY || asIfHeight > MAX_HEIGHT_WARRANTY) {
                    //error: please input a valid Height and Build-As-If Height
                    //alert("buildable but not under warranty!");
                    errorMessage.value = "Buildable but not under warranty. Warranty dimensions are: "
                        + MAX_HEIGHT_WARRANTY + "(Height) x " + MAX_WIDTH_WARRANTY + "(Width) to "
                        + MIN_HEIGHT_WARRANTY + "(Height) x " + MIN_WIDTH_WARRANTY + "(Width).";
                    $('MainContent_radDoorBottomRad' + title).prop('checked', true);
                    //document.getElementById('MainContent_radDoorBottomRad' + title).checked = true;
                    topOrBottomUnevenClicked(title);
                }
                else {
                    //alert("Here");
                    errorMessage.value = "";
                    getHeightAndWidthOfEachVent(true, title);
                }
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
        function getHeightAndWidthOfEachVent(asIf, title) {

            if (typeof (asIf) === 'undefined') asIf = false; //if asIf not specified set it by default to false

            var ventCount = $('#MainContent_ddlDoorV4TNumberOfVents' + title + ' option:selected').val();
            var doorWidth = $('#MainContent_txtDoorWidth' + title).val();
            var doorHeight = (asIf) ? $('#MainContent_txtDoorAsIfHeight' + title).val() : $('#MainContent_txtDoorHeight' + title).val();
            var asIfHeight = $('#MainContent_txtDoorAsIfHeight' + title).val();
            var height = $('#MainContent_txtDoorHeight' + title).val();

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

                if ($("#MainContent_radDoorTopRadVinyl" + title).is(':checked')) {
                    ventTopHeight = parseFloat(ventTopHeight) - parseFloat(extraHeight);
                }
                else if ($("#MainContent_radDoorBottomRadVinyl" + title).is(':checked')) {
                    ventBottomHeight = parseFloat(ventBottomHeight) - parseFloat(extraHeight);
                }
                else if ($("#MainContent_radDoorBothRadVinyl" + title).is(':checked')) {
                    ventTopHeight = parseFloat(ventTopHeight) - (Math.round((parseFloat(extraHeight) / 2) * 100) / 100);
                    ventBottomHeight = parseFloat(ventBottomHeight) - (Math.round((parseFloat(extraHeight) / 2) * 100) / 100);
                }
            }
            else if (parseFloat(asIfHeight) > parseFloat(height)) { // if as if height > height

                var remainingHeight = parseFloat(asIfHeight) - parseFloat(height);

                if ($("#MainContent_radDoorTopRadVinyl" + title).is(':checked')) {
                    ventTopHeight = parseFloat(ventTopHeight) + parseFloat(remainingHeight);
                }
                else if ($("#MainContent_radDoorBottomRadVinyl" + title).is(':checked')) {
                    ventBottomHeight = parseFloat(ventBottomHeight) + parseFloat(remainingHeight);
                }
                else if ($("#MainContent_radDoorBothRadVinyl" + title).is(':checked')) {
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

            $("#MainContent_txtDoorTopVentHeightVinyl" + title).val(ventTopHeight);
            $("#MainContent_txtDoorBottomVentHeightVinyl" + title).val(ventBottomHeight);

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
        function bothUnevenClicked(title) {

            console.log(title);
            getHeightAndWidthOfEachVent(true, title);

            //document.getElementById('MainContent_txtDoorTopVentHeight' + title).value 
            $('#MainContent_txtDoorTopVentHeight' + title).val(ventTopHeight);
            //document.getElementById('MainContent_txtDoorBottomVentHeight' + title).value
            $('#MainContent_txtDoorBottomVentHeight' + title).val(ventBottomHeight);

            document.getElementById('MainContent_rowDoorUnevenVentsTop' + title).style.display = 'inherit';
            document.getElementById('MainContent_rowDoorUnevenVentsBottom' + title).style.display = 'inherit';

        }

        /*
        This function gets called when the user selects top or bottom uneven vents radio button
        It hides the appropriate rows (undoes what bothUnevenClicked() did)
        */
        function topOrBottomUnevenClicked(title) {
            console.log(title);
            $('#MainContent_txtDoorTopVentHeight' + title).val('');
            //document.getElementById('MainContent_txtDoorTopVentHeight' + title).value = '';
            $('#MainContent_txtDoorBottomVentHeight' + title).val('');
            //document.getElementById('MainContent_txtDoorBottomVentHeight' + title).value = '';

            document.getElementById('MainContent_rowDoorUnevenVentsTop' + title).style.display = 'none';
            document.getElementById('MainContent_rowDoorUnevenVentsBottom' + title).style.display = 'none';

            getHeightAndWidthOfEachVent(true, title);
        }

        /*
        This function gets called when uneven vents check box is clicked
        It hides and displays appropriate rows depending on whether the checkbox is checked or unchecked
        @param checked - true or false
        */
        function unevenVentsChecked(checked, title) {
            if (checked) {
                document.getElementById('MainContent_rowDoorAsIfHeight' + title).style.display = 'inherit';
                document.getElementById('MainContent_rowDoorTopBottomBothRad' + title).style.display = 'inherit';

                if (document.getElementById('MainContent_txtDoorAsIfHeight' + title).value === '')
                    document.getElementById('MainContent_txtDoorAsIfHeight' + title).value = document.getElementById('MainContent_txtDoorHeight' + title).value;

                if (document.getElementById('MainContent_ddlDoorAsIfHeight' + title).selectedIndex === 0)
                    document.getElementById('MainContent_ddlDoorAsIfHeight' + title).selectedIndex = document.getElementById('MainContent_ddlDoorHeight' + title).selectedIndex;

                if (document.getElementById('MainContent_radDoorBothRad' + title).checked) {
                    bothUnevenClicked(title);
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
        function tintOptionsChanged(title) {
            var tempVents;
            var tintValue = $('#MainContent_ddlDoorVinylTint' + title + ' option:selected').val();
            var numOfVents = parseInt($('#MainContent_ddlDoorV4TNumberOfVents' + title + ' option:selected').val());            

            var vinylRows = (numOfVents == 4) ? 4 : 3;

            if (tempVents != numOfVents) {
                tempVents = numOfVents;
                for (var i = 0; i < 4; i++) {
                    document.getElementById('MainContent_row' + i + 'DoorTint' + title).style.display = 'none';
                }
                for (var i = 0; i < vinylRows; i++) {
                    document.getElementById('MainContent_row' + i + 'DoorTint' + title).style.display = 'table-row';
                }
            }

            if (tintValue == "Mixed") {
                for (var i = 0; i < 4; i++) {
                    document.getElementById('MainContent_row' + i + 'DoorTint' + title).style.display = 'none';
                }
                for (var i = 0; i < vinylRows; i++) {
                    document.getElementById('MainContent_row' + i + 'DoorTint' + title).style.display = 'table-row';
                }
            }
            else {
                for (var i = 0; i < 4; i++) {
                    document.getElementById('MainContent_row' + i + 'DoorTint' + title).style.display = 'none';
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
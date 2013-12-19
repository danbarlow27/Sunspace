<%@ Page Title="New Project - Windows Only" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WizardWindowsOnly.aspx.cs" Inherits="SunspaceDealerDesktop.WizardWindowsOnly" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">    
    <script src="Scripts/GlobalFunctions.js"></script>
    <script src="Scripts/Validation.js"></script>
    <script>
        var V4T_3V_MIN_WIDTH_BUILDABLE = <%= V4T_3V_MIN_WIDTH_BUILDABLE%>;
        var V4T_4V_MIN_WIDTH_BUILDABLE = <%= V4T_4V_MIN_WIDTH_BUILDABLE%>;
        var V4T_6V_MIN_WIDTH_BUILDABLE = <%= V4T_6V_MIN_WIDTH_BUILDABLE%>;
        var V4T_8V_MIN_WIDTH_BUILDABLE = <%= V4T_8V_MIN_WIDTH_BUILDABLE%>;
        var V4T_9V_MIN_WIDTH_BUILDABLE = <%= V4T_9V_MIN_WIDTH_BUILDABLE%>;
        var V4T_12V_MIN_WIDTH_BUILDABLE = <%= V4T_12V_MIN_WIDTH_BUILDABLE%>;
        var HORIZONTAL_ROLLER_MIN_WIDTH_BUILDABLE = <%= HORIZONTAL_ROLLER_MIN_WIDTH_BUILDABLE%>;
        var VINYL_LITE_MIN_WIDTH_BUILDABLE = <%= VINYL_LITE_MIN_WIDTH_BUILDABLE%>;
        var VINYL_TRAP_MIN_WIDTH_BUILDABLE = <%= VINYL_TRAP_MIN_WIDTH_BUILDABLE%>;

        var DOUBLE_SLIDER_MIN_WIDTH_BUILDABLE = <%= DOUBLE_SLIDER_MIN_WIDTH_BUILDABLE%>;
        var DOUBLE_SLIDER_LITE_MIN_WIDTH_BUILDABLE = <%= DOUBLE_SLIDER_LITE_MIN_WIDTH_BUILDABLE%>;
        var DOUBLE_SLIDER_TRAP_MIN_WIDTH_BUILDABLE = <%= DOUBLE_SLIDER_TRAP_MIN_WIDTH_BUILDABLE%>;

        var SINGLE_SLIDER_MIN_WIDTH_BUILDABLE = <%= SINGLE_SLIDER_MIN_WIDTH_BUILDABLE%>;
        var SINGLE_SLIDER_LITE_MIN_WIDTH_BUILDABLE = <%= SINGLE_SLIDER_LITE_MIN_WIDTH_BUILDABLE%>;
        var SINGLE_SLIDER_TRAP_MIN_WIDTH_BUILDABLE = <%= SINGLE_SLIDER_TRAP_MIN_WIDTH_BUILDABLE%>;

        var SCREEN_MIN_WIDTH_BUILDABLE = <%= SCREEN_MIN_WIDTH_BUILDABLE%>;

        var V4T_3V_MIN_WIDTH_WARRANTY = <%= V4T_3V_MIN_WIDTH_WARRANTY%>;
        var V4T_4V_MIN_WIDTH_WARRANTY = <%= V4T_4V_MIN_WIDTH_WARRANTY%>;
        var V4T_6V_MIN_WIDTH_WARRANTY = <%= V4T_6V_MIN_WIDTH_WARRANTY%>;
        var V4T_8V_MIN_WIDTH_WARRANTY = <%= V4T_8V_MIN_WIDTH_WARRANTY%>;
        var V4T_9V_MIN_WIDTH_WARRANTY = <%= V4T_9V_MIN_WIDTH_WARRANTY%>;
        var V4T_12V_MIN_WIDTH_WARRANTY = <%= V4T_12V_MIN_WIDTH_WARRANTY%>;
        var HORIZONTAL_ROLLER_MIN_WIDTH_WARRANTY = <%= HORIZONTAL_ROLLER_MIN_WIDTH_WARRANTY%>;
        var VINYL_LITE_MIN_WIDTH_WARRANTY = <%= VINYL_LITE_MIN_WIDTH_WARRANTY%>;
        var VINYL_TRAP_MIN_WIDTH_WARRANTY = <%= VINYL_TRAP_MIN_WIDTH_WARRANTY%>;

        var DOUBLE_SLIDER_MIN_WIDTH_WARRANTY = <%= DOUBLE_SLIDER_MIN_WIDTH_WARRANTY%>;
        var DOUBLE_SLIDER_LITE_MIN_WIDTH_WARRANTY = <%= DOUBLE_SLIDER_LITE_MIN_WIDTH_WARRANTY%>;
        var DOUBLE_SLIDER_TRAP_MIN_WIDTH_WARRANTY = <%= DOUBLE_SLIDER_TRAP_MIN_WIDTH_WARRANTY%>;

        var SINGLE_SLIDER_MIN_WIDTH_WARRANTY = <%= SINGLE_SLIDER_MIN_WIDTH_WARRANTY%>;
        var SINGLE_SLIDER_LITE_MIN_WIDTH_WARRANTY = <%= SINGLE_SLIDER_LITE_MIN_WIDTH_WARRANTY%>;
        var SINGLE_SLIDER_TRAP_MIN_WIDTH_WARRANTY = <%= SINGLE_SLIDER_TRAP_MIN_WIDTH_WARRANTY%>;

        var SCREEN_MIN_WIDTH_WARRANTY = <%= SCREEN_MIN_WIDTH_WARRANTY%>;

        var V4T_3V_MAX_WIDTH_BUILDABLE = <%= V4T_3V_MAX_WIDTH_BUILDABLE%>;
        var V4T_4V_MAX_WIDTH_BUILDABLE = <%= V4T_4V_MAX_WIDTH_BUILDABLE%>;
        var V4T_6V_MAX_WIDTH_BUILDABLE = <%= V4T_6V_MAX_WIDTH_BUILDABLE%>;
        var V4T_8V_MAX_WIDTH_BUILDABLE = <%= V4T_8V_MAX_WIDTH_BUILDABLE%>;
        var V4T_9V_MAX_WIDTH_BUILDABLE = <%= V4T_9V_MAX_WIDTH_BUILDABLE%>;
        var V4T_12V_MAX_WIDTH_BUILDABLE = <%= V4T_12V_MAX_WIDTH_BUILDABLE%>;
        var HORIZONTAL_ROLLER_MAX_WIDTH_BUILDABLE = <%= HORIZONTAL_ROLLER_MAX_WIDTH_BUILDABLE%>;
        var VINYL_LITE_MAX_WIDTH_BUILDABLE = <%= VINYL_LITE_MAX_WIDTH_BUILDABLE%>;
        var VINYL_TRAP_MAX_WIDTH_BUILDABLE = <%= VINYL_TRAP_MAX_WIDTH_BUILDABLE%>;

        var DOUBLE_SLIDER_MAX_WIDTH_BUILDABLE = <%= DOUBLE_SLIDER_MAX_WIDTH_BUILDABLE%>;
        var DOUBLE_SLIDER_LITE_MAX_WIDTH_BUILDABLE = <%= DOUBLE_SLIDER_LITE_MAX_WIDTH_BUILDABLE%>;
        var DOUBLE_SLIDER_TRAP_MAX_WIDTH_BUILDABLE = <%= DOUBLE_SLIDER_TRAP_MAX_WIDTH_BUILDABLE%>;

        var SINGLE_SLIDER_MAX_WIDTH_BUILDABLE = <%= SINGLE_SLIDER_MAX_WIDTH_BUILDABLE%>;
        var SINGLE_SLIDER_LITE_MAX_WIDTH_BUILDABLE = <%= SINGLE_SLIDER_LITE_MAX_WIDTH_BUILDABLE%>;
        var SINGLE_SLIDER_TRAP_MAX_WIDTH_BUILDABLE = <%= SINGLE_SLIDER_TRAP_MAX_WIDTH_BUILDABLE%>;

        var SCREEN_MAX_WIDTH_BUILDABLE = <%= SCREEN_MAX_WIDTH_BUILDABLE%>;

        var V4T_3V_MAX_WIDTH_WARRANTY = <%= V4T_3V_MAX_WIDTH_WARRANTY%>;
        var V4T_4V_MAX_WIDTH_WARRANTY = <%= V4T_4V_MAX_WIDTH_WARRANTY%>;
        var V4T_6V_MAX_WIDTH_WARRANTY = <%= V4T_6V_MAX_WIDTH_WARRANTY%>;
        var V4T_8V_MAX_WIDTH_WARRANTY = <%= V4T_8V_MAX_WIDTH_WARRANTY%>;
        var V4T_9V_MAX_WIDTH_WARRANTY = <%= V4T_9V_MAX_WIDTH_WARRANTY%>;
        var V4T_12V_MAX_WIDTH_WARRANTY = <%= V4T_12V_MAX_WIDTH_WARRANTY%>;
        var HORIZONTAL_ROLLER_MAX_WIDTH_WARRANTY = <%= HORIZONTAL_ROLLER_MAX_WIDTH_WARRANTY%>;
        var VINYL_LITE_MAX_WIDTH_WARRANTY = <%= VINYL_LITE_MAX_WIDTH_WARRANTY%>;
        var VINYL_TRAP_MAX_WIDTH_WARRANTY = <%= VINYL_TRAP_MAX_WIDTH_WARRANTY%>;

        var DOUBLE_SLIDER_MAX_WIDTH_WARRANTY = <%= DOUBLE_SLIDER_MAX_WIDTH_WARRANTY%>;
        var DOUBLE_SLIDER_LITE_MAX_WIDTH_WARRANTY = <%= DOUBLE_SLIDER_LITE_MAX_WIDTH_WARRANTY%>;
        var DOUBLE_SLIDER_TRAP_MAX_WIDTH_WARRANTY = <%= DOUBLE_SLIDER_TRAP_MAX_WIDTH_WARRANTY%>;

        var SINGLE_SLIDER_MAX_WIDTH_WARRANTY = <%= SINGLE_SLIDER_MAX_WIDTH_WARRANTY%>;
        var SINGLE_SLIDER_LITE_MAX_WIDTH_WARRANTY = <%= SINGLE_SLIDER_LITE_MAX_WIDTH_WARRANTY%>;
        var SINGLE_SLIDER_TRAP_MAX_WIDTH_WARRANTY = <%= SINGLE_SLIDER_TRAP_MAX_WIDTH_WARRANTY%>;

        var SCREEN_MAX_WIDTH_WARRANTY = <%= SCREEN_MAX_WIDTH_WARRANTY%>;

        var V4T_3V_MIN_HEIGHT_BUILDABLE = <%= V4T_3V_MIN_HEIGHT_BUILDABLE%>;
        var V4T_4V_MIN_HEIGHT_BUILDABLE = <%= V4T_4V_MIN_HEIGHT_BUILDABLE%>;
        var V4T_6V_MIN_HEIGHT_BUILDABLE = <%= V4T_6V_MIN_HEIGHT_BUILDABLE%>;
        var V4T_8V_MIN_HEIGHT_BUILDABLE = <%= V4T_8V_MIN_HEIGHT_BUILDABLE%>;
        var V4T_9V_MIN_HEIGHT_BUILDABLE = <%= V4T_9V_MIN_HEIGHT_BUILDABLE%>;
        var V4T_12V_MIN_HEIGHT_BUILDABLE = <%= V4T_12V_MIN_HEIGHT_BUILDABLE%>;
        var HORIZONTAL_ROLLER_MIN_HEIGHT_BUILDABLE = <%= HORIZONTAL_ROLLER_MIN_HEIGHT_BUILDABLE%>;
        var VINYL_LITE_MIN_HEIGHT_BUILDABLE = <%= VINYL_LITE_MIN_HEIGHT_BUILDABLE%>;
        var VINYL_TRAP_MIN_HEIGHT_BUILDABLE = <%= VINYL_TRAP_MIN_HEIGHT_BUILDABLE%>;

        var DOUBLE_SLIDER_MIN_HEIGHT_BUILDABLE = <%= DOUBLE_SLIDER_MIN_HEIGHT_BUILDABLE%>;
        var DOUBLE_SLIDER_LITE_MIN_HEIGHT_BUILDABLE = <%= DOUBLE_SLIDER_LITE_MIN_HEIGHT_BUILDABLE%>;
        var DOUBLE_SLIDER_TRAP_MIN_HEIGHT_BUILDABLE = <%= DOUBLE_SLIDER_TRAP_MIN_HEIGHT_BUILDABLE%>;

        var SINGLE_SLIDER_MIN_HEIGHT_BUILDABLE = <%= SINGLE_SLIDER_MIN_HEIGHT_BUILDABLE%>;
        var SINGLE_SLIDER_LITE_MIN_HEIGHT_BUILDABLE = <%= SINGLE_SLIDER_LITE_MIN_HEIGHT_BUILDABLE%>;
        var SINGLE_SLIDER_TRAP_MIN_HEIGHT_BUILDABLE = <%= SINGLE_SLIDER_TRAP_MIN_HEIGHT_BUILDABLE%>;

        var SCREEN_MIN_HEIGHT_BUILDABLE = <%= SCREEN_MIN_HEIGHT_BUILDABLE%>;

        var V4T_3V_MIN_HEIGHT_WARRANTY = <%= V4T_3V_MIN_HEIGHT_WARRANTY%>;
        var V4T_4V_MIN_HEIGHT_WARRANTY = <%= V4T_4V_MIN_HEIGHT_WARRANTY%>;
        var V4T_6V_MIN_HEIGHT_WARRANTY = <%= V4T_6V_MIN_HEIGHT_WARRANTY%>;
        var V4T_8V_MIN_HEIGHT_WARRANTY = <%= V4T_8V_MIN_HEIGHT_WARRANTY%>;
        var V4T_9V_MIN_HEIGHT_WARRANTY = <%= V4T_9V_MIN_HEIGHT_WARRANTY%>;
        var V4T_12V_MIN_HEIGHT_WARRANTY = <%= V4T_12V_MIN_HEIGHT_WARRANTY%>;
        var HORIZONTAL_ROLLER_MIN_HEIGHT_WARRANTY = <%= HORIZONTAL_ROLLER_MIN_HEIGHT_WARRANTY%>;
        var VINYL_LITE_MIN_HEIGHT_WARRANTY = <%= VINYL_LITE_MIN_HEIGHT_WARRANTY%>;
        var VINYL_TRAP_MIN_HEIGHT_WARRANTY = <%= VINYL_TRAP_MIN_HEIGHT_WARRANTY%>;

        var DOUBLE_SLIDER_MIN_HEIGHT_WARRANTY = <%= DOUBLE_SLIDER_MIN_HEIGHT_WARRANTY%>;
        var DOUBLE_SLIDER_LITE_MIN_HEIGHT_WARRANTY = <%= DOUBLE_SLIDER_LITE_MIN_HEIGHT_WARRANTY%>;
        var DOUBLE_SLIDER_TRAP_MIN_HEIGHT_WARRANTY = <%= DOUBLE_SLIDER_TRAP_MIN_HEIGHT_WARRANTY%>;

        var SINGLE_SLIDER_MIN_HEIGHT_WARRANTY = <%= SINGLE_SLIDER_MIN_HEIGHT_WARRANTY%>;
        var SINGLE_SLIDER_LITE_MIN_HEIGHT_WARRANTY = <%= SINGLE_SLIDER_LITE_MIN_HEIGHT_WARRANTY%>;
        var SINGLE_SLIDER_TRAP_MIN_HEIGHT_WARRANTY = <%= SINGLE_SLIDER_TRAP_MIN_HEIGHT_WARRANTY%>;

        var SCREEN_MIN_HEIGHT_WARRANTY = <%= SCREEN_MIN_HEIGHT_WARRANTY%>;

        var V4T_3V_MAX_HEIGHT_BUILDABLE = <%= V4T_3V_MAX_HEIGHT_BUILDABLE%>;
        var V4T_4V_MAX_HEIGHT_BUILDABLE = <%= V4T_4V_MAX_HEIGHT_BUILDABLE%>;
        var V4T_6V_MAX_HEIGHT_BUILDABLE = <%= V4T_6V_MAX_HEIGHT_BUILDABLE%>;
        var V4T_8V_MAX_HEIGHT_BUILDABLE = <%= V4T_8V_MAX_HEIGHT_BUILDABLE%>;
        var V4T_9V_MAX_HEIGHT_BUILDABLE = <%= V4T_9V_MAX_HEIGHT_BUILDABLE%>;
        var V4T_12V_MAX_HEIGHT_BUILDABLE = <%= V4T_12V_MAX_HEIGHT_BUILDABLE%>;
        var HORIZONTAL_ROLLER_MAX_HEIGHT_BUILDABLE = <%= HORIZONTAL_ROLLER_MAX_HEIGHT_BUILDABLE%>;
        var VINYL_LITE_MAX_HEIGHT_BUILDABLE = <%= VINYL_LITE_MAX_HEIGHT_BUILDABLE%>;
        var VINYL_TRAP_MAX_HEIGHT_BUILDABLE = <%= VINYL_TRAP_MAX_HEIGHT_BUILDABLE%>;

        var DOUBLE_SLIDER_MAX_HEIGHT_BUILDABLE = <%= DOUBLE_SLIDER_MAX_HEIGHT_BUILDABLE%>;
        var DOUBLE_SLIDER_LITE_MAX_HEIGHT_BUILDABLE = <%= DOUBLE_SLIDER_LITE_MAX_HEIGHT_BUILDABLE%>;
        var DOUBLE_SLIDER_TRAP_MAX_HEIGHT_BUILDABLE = <%= DOUBLE_SLIDER_TRAP_MAX_HEIGHT_BUILDABLE%>;

        var SINGLE_SLIDER_MAX_HEIGHT_BUILDABLE = <%= SINGLE_SLIDER_MAX_HEIGHT_BUILDABLE%>;
        var SINGLE_SLIDER_LITE_MAX_HEIGHT_BUILDABLE = <%= SINGLE_SLIDER_LITE_MAX_HEIGHT_BUILDABLE%>;
        var SINGLE_SLIDER_TRAP_MAX_HEIGHT_BUILDABLE = <%= SINGLE_SLIDER_TRAP_MAX_HEIGHT_BUILDABLE%>;

        var SCREEN_MAX_HEIGHT_BUILDABLE = <%= SCREEN_MAX_HEIGHT_BUILDABLE%>;

        var V4T_3V_MAX_HEIGHT_WARRANTY = <%= V4T_3V_MAX_HEIGHT_WARRANTY%>;
        var V4T_4V_MAX_HEIGHT_WARRANTY = <%= V4T_4V_MAX_HEIGHT_WARRANTY%>;
        var V4T_6V_MAX_HEIGHT_WARRANTY = <%= V4T_6V_MAX_HEIGHT_WARRANTY%>;
        var V4T_8V_MAX_HEIGHT_WARRANTY = <%= V4T_8V_MAX_HEIGHT_WARRANTY%>;
        var V4T_9V_MAX_HEIGHT_WARRANTY = <%= V4T_9V_MAX_HEIGHT_WARRANTY%>;
        var V4T_12V_MAX_HEIGHT_WARRANTY = <%= V4T_12V_MAX_HEIGHT_WARRANTY%>;
        var HORIZONTAL_ROLLER_MAX_HEIGHT_WARRANTY = <%= HORIZONTAL_ROLLER_MAX_HEIGHT_WARRANTY%>;
        var VINYL_LITE_MAX_HEIGHT_WARRANTY = <%= VINYL_LITE_MAX_HEIGHT_WARRANTY%>;
        var VINYL_TRAP_MAX_HEIGHT_WARRANTY = <%= VINYL_TRAP_MAX_HEIGHT_WARRANTY%>;

        var DOUBLE_SLIDER_MAX_HEIGHT_WARRANTY = <%= DOUBLE_SLIDER_MAX_HEIGHT_WARRANTY%>;
        var DOUBLE_SLIDER_LITE_MAX_HEIGHT_WARRANTY = <%= DOUBLE_SLIDER_LITE_MAX_HEIGHT_WARRANTY%>;
        var DOUBLE_SLIDER_TRAP_MAX_HEIGHT_WARRANTY = <%= DOUBLE_SLIDER_TRAP_MAX_HEIGHT_WARRANTY%>;

        var SINGLE_SLIDER_MAX_HEIGHT_WARRANTY = <%= SINGLE_SLIDER_MAX_HEIGHT_WARRANTY%>;
        var SINGLE_SLIDER_LITE_MAX_HEIGHT_WARRANTY = <%= SINGLE_SLIDER_LITE_MAX_HEIGHT_WARRANTY%>;
        var SINGLE_SLIDER_TRAP_MAX_HEIGHT_WARRANTY = <%= SINGLE_SLIDER_TRAP_MAX_HEIGHT_WARRANTY%>;

        var SCREEN_MAX_HEIGHT_WARRANTY = <%= SCREEN_MAX_HEIGHT_WARRANTY%>;


        var V4T_SPREADER_BAR_NEEDED = <%= V4T_SPREADER_BAR_NEEDED%>;
        var HORIZONTAL_ROLLER_SPREADER_BAR_NEEDED = <%= HORIZONTAL_ROLLER_SPREADER_BAR_NEEDED%>;


        var spreaderBar = -1; // value for the placement of spreader bar on the window; -1 denotes no spreaderbar
        var dlo = 2.0; // day light opening, window size for 2 inches if option selected
        var deductions = 0.0; // any deductions to be applied to the size of the window
        var tint; // tint values
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

        //var errorMessage = $("#MainContent_txtErrorMessage");
        var errorMessage = $("#MainContent_lblErrorMessage");

        /**
        This function gets called when dlo/tip to tip label is clicked
        It adjusts the value of dlo appropriately
        @param labelText - "DLO" or "Tip to Tip"
        */
        function dloClicked(labelText) {
            switch (labelText) {
                case "DLO":
                    dlo = 2.0;
                    break;
                case "Tip to Tip":
                    dlo = 0.0;
                    break;
            }
        }

        /**
        This function gets called when deductions label is clicked
        It adjusts the value of deductions appropriately
        @param labelText - "Deduct 1/4", "Deduct 1/8", "Deduct 3/8", "Deduct 1/2", "No Deductions"
        */
        function deductionsClicked(labelText) {
            switch (labelText) {
                case "Deduct 1/8\"":
                    deductions = 0.125;
                    break;
                case "Deduct 1/4\"":
                    deductions = 0.25;
                    break;
                case "Deduct 3/8\"":
                    deductions = 0.375;
                    break;
                case "Deduct 1/2\"":
                    deductions = 0.5;
                    break;
                case "No Deductions":
                    deductions = 0.0;
                    break;
            }
        }

        /*
        This function re validates and re calculates the values of height and width of the window and vent sizes
        */
        function recalculate() {

            var height = document.getElementById('MainContent_txtWindowHeightVinyl').value;
            var asIfHeight = document.getElementById('MainContent_txtWindowAsIfHeightVinyl').value;
            var width = document.getElementById('MainContent_txtWindowWidthVinyl').value;

            if(!validateInteger(asIfHeight)) asIfHeight = height; //if asIfHeight = null, set the value of height to it

            if (!validateInteger(height) || //height is not a valid integer
                !validateInteger(asIfHeight) || //as-if height is not a valid integer
                !validateInteger(width)) { //width is not a valid integer

                //error: please input a valid Height and Build-As-If Height
                //alert("enter some numbers you fool!");
                errorMessage.text("enter some numbers you foo!");
                document.getElementById('MainContent_radWindowBottomRadVinyl').checked = true;
                topOrBottomUnevenClicked();
            }
            else if (width < MIN_WIDTH_BUILDABLE || width > MAX_WIDTH_BUILDABLE ||
                 height < MIN_HEIGHT_BUILDABLE || height > MAX_HEIGHT_BUILDABLE ||
                 asIfHeight < MIN_HEIGHT_BUILDABLE || asIfHeight > MAX_HEIGHT_BUILDABLE) {
                //error: please input a valid Height and Build-As-If Height
                //alert("not buildable!");
                errorMessage.text("not buildable");
                document.getElementById('MainContent_radWindowBottomRadVinyl').checked = true;
                topOrBottomUnevenClicked();
            }
            else if (width < MIN_WIDTH_WARRANTY || width > MAX_WIDTH_WARRANTY ||
                 height < MIN_HEIGHT_WARRANTY || height > MAX_HEIGHT_WARRANTY ||
                 asIfHeight < MIN_HEIGHT_WARRANTY || asIfHeight > MAX_HEIGHT_WARRANTY) {
                //error: please input a valid Height and Build-As-If Height
                //alert("buildable but not under warranty!");
                errorMessage.text("buildable but not under warranty");
                document.getElementById('MainContent_radWindowBottomRadVinyl').checked = true;
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
        This function gets the height and width of each vent on a V4T window
        Part of this code is the replica of Dan H's code to get the height and width 
        This function also determines and sets the size of each vent for an uneven vent window
        @param asIf - build as if value given (true or false)
        */
        function getHeightAndWidthOfEachVent(asIf) {
            
            if(typeof(asIf)==='undefined') asIf = false; //if asIf not specified set it by default to false

            var ventCount = document.getElementById('MainContent_ddlWindowV4TNumberOfVentsVinyl').options[document.getElementById('MainContent_ddlWindowV4TNumberOfVentsVinyl').selectedIndex].value;
            var windowWidth = document.getElementById('MainContent_txtWindowWidthVinyl').value + document.getElementById('MainContent_ddlWindowWidthVinyl').options[document.getElementById('MainContent_ddlWindowWidthVinyl').selectedIndex].value;
            var windowHeight = (asIf) ? document.getElementById('MainContent_txtWindowAsIfHeightVinyl').value + document.getElementById('MainContent_ddlWindowAsIfHeightVinyl').options[document.getElementById('MainContent_ddlWindowAsIfHeightVinyl').selectedIndex].value : 
                                        document.getElementById('MainContent_txtWindowHeightVinyl').value + document.getElementById('MainContent_ddlWindowHeightVinyl').options[document.getElementById('MainContent_ddlWindowHeightVinyl').selectedIndex].value;
            var asIfHeight = document.getElementById('MainContent_txtWindowAsIfHeightVinyl').value + document.getElementById('MainContent_ddlWindowAsIfHeightVinyl').options[document.getElementById('MainContent_ddlWindowAsIfHeightVinyl').selectedIndex].value;
            var height = document.getElementById('MainContent_txtWindowHeightVinyl').value + document.getElementById('MainContent_ddlWindowHeightVinyl').options[document.getElementById('MainContent_ddlWindowHeightVinyl').selectedIndex].value;

            if (ventCount > 8) { 
                ventWidth = (parseFloat(windowWidth) - 1.5625 - 2.75) / 3;
            }
            else if (ventCount > 4) {
                ventWidth = (parseFloat(windowWidth) - 1.5625 - 1.6875) / 2;
            }
            else {
                ventWidth = parseFloat(windowWidth) - 1.5625;
            }

            if (ventCount % 4 === 0) {
                ventHeight = (parseFloat(windowHeight) + 2.187) / 4;
            }
            else if (ventCount % 3 === 0) {
                ventHeight = (parseFloat(windowHeight) + 1.3125) / 3;
            }
            else {
                ventHeight = (parseFloat(windowHeight) + 0.4375) / 2;
            }
                        
            ventHeight =  Math.round(parseFloat(ventHeight) * 100) / 100;
            ventWidth = Math.round(parseFloat(ventWidth) * 100) / 100;

            ventTopHeight = ventHeight;
            vent2Height = ventHeight;
            vent3Height = ventHeight;
            ventBottomHeight = ventHeight;

            if (parseFloat(height) > parseFloat(asIfHeight)) { //if height > as if height

                var extraHeight = parseFloat(height) - parseFloat(asIfHeight); 
                                 
                if ($("#MainContent_radWindowTopRadVinyl").is(':checked')) {
                    ventTopHeight = parseFloat(ventTopHeight) - parseFloat(extraHeight);
                }
                else if($("#MainContent_radWindowBottomRadVinyl").is(':checked')) {
                    ventBottomHeight = parseFloat(ventBottomHeight) - parseFloat(extraHeight);
                }
                else if($("#MainContent_radWindowBothRadVinyl").is(':checked')) {
                    ventTopHeight = parseFloat(ventTopHeight) - (Math.round((parseFloat(extraHeight) / 2) * 100) / 100);
                    ventBottomHeight = parseFloat(ventBottomHeight) - (Math.round((parseFloat(extraHeight) / 2) * 100) / 100);
                }
            }
            else if (parseFloat(asIfHeight) > parseFloat(height)) { // if as if height > height

                var remainingHeight = parseFloat(asIfHeight) - parseFloat(height); 
                                 
                if ($("#MainContent_radWindowTopRadVinyl").is(':checked')) {
                    ventTopHeight = parseFloat(ventTopHeight) + parseFloat(remainingHeight);
                }
                else if($("#MainContent_radWindowBottomRadVinyl").is(':checked')) {
                    ventBottomHeight = parseFloat(ventBottomHeight) + parseFloat(remainingHeight);
                }
                else if($("#MainContent_radWindowBothRadVinyl").is(':checked')) {
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

            $("#MainContent_txtWindowTopVentHeightVinyl").val(ventTopHeight);
            $("#MainContent_txtWindowBottomVentHeightVinyl").val(ventBottomHeight);
            
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

            if (sender === "top") {

                if (parseFloat(value) > parseFloat(ventTopHeight)) {
                    actualValue = parseFloat(value) - parseFloat(ventTopHeight);
                    ventTopHeight = parseFloat(ventTopHeight) + parseFloat(actualValue);
                    ventBottomHeight = parseFloat(ventBottomHeight) - parseFloat(value);
                }
                else if (parseFloat(value) < parseFloat(ventTopHeight)) {
                    actualValue = parseFloat(ventTopHeight) - parseFloat(value);
                    ventTopHeight = parseFloat(ventTopHeight) - parseFloat(actualValue);
                    ventBottomHeight = parseFloat(ventBottomHeight) + parseFloat(value);
                }
            }
            else if (sender === "bottom") { 
                if (parseFloat(value) > parseFloat(ventTopHeight)) {
                    actualValue = parseFloat(value) - parseFloat(ventBottomHeight);
                    ventTopHeight = parseFloat(ventTopHeight) - parseFloat(actualValue);
                    ventBottomHeight = parseFloat(ventBottomHeight) + parseFloat(value);
                }
                else if (parseFloat(value) < parseFloat(ventTopHeight)) {
                    actualValue = parseFloat(ventBottomHeight) - parseFloat(value);
                    ventTopHeight = parseFloat(ventTopHeight) + parseFloat(actualValue);
                    ventBottomHeight = parseFloat(ventBottomHeight) - parseFloat(value);
                }
            }

            $("#MainContent_txtWindowTopVentHeightVinyl").val(Math.round(parseFloat(ventTopHeight) * 100) / 100);
            $("#MainContent_txtWindowBottomVentHeightVinyl").val(Math.round(parseFloat(ventBottomHeight) * 100) / 100);
        }

            
        /*
        This function gets called when the user selects both uneven vents radio button
        It displays the appropriate rows and recalculates all the values
        */
        function bothUnevenClicked() {
            getHeightAndWidthOfEachVent(true);
                
            document.getElementById('MainContent_txtWindowTopVentHeightVinyl').value = ventTopHeight;
            document.getElementById('MainContent_txtWindowBottomVentHeightVinyl').value = ventBottomHeight;

            document.getElementById('MainContent_rowWindowUnevenVentsTopVinyl').style.display = 'table-row';
            document.getElementById('MainContent_rowWindowUnevenVentsBottomVinyl').style.display = 'table-row';

        }

        /*
        This function gets called when the user selects top or bottom uneven vents radio button
        It hides the appropriate rows (undoes what bothUnevenClicked() did)
        */
        function topOrBottomUnevenClicked(){
            document.getElementById('MainContent_txtWindowTopVentHeightVinyl').value = '';
            document.getElementById('MainContent_txtWindowBottomVentHeightVinyl').value = '';

            document.getElementById('MainContent_rowWindowUnevenVentsTopVinyl').style.display = 'none';
            document.getElementById('MainContent_rowWindowUnevenVentsBottomVinyl').style.display = 'none';

            getHeightAndWidthOfEachVent(true);
        }

        /*
        This function gets called when uneven vents check box is clicked
        It hides and displays appropriate rows depending on whether the checkbox is checked or unchecked
        @param checked - true or false
        */
        function unevenVentsChecked(checked) {
            if (checked) {
                document.getElementById('MainContent_rowWindowAsIfHeightVinyl').style.display = 'table-row';
                document.getElementById('MainContent_rowWindowTopBottomBothRadVinyl').style.display = 'table-row';

                if (document.getElementById('MainContent_txtWindowAsIfHeightVinyl').value === '')
                    document.getElementById('MainContent_txtWindowAsIfHeightVinyl').value = document.getElementById('MainContent_txtWindowHeightVinyl').value;

                if (document.getElementById('MainContent_ddlWindowAsIfHeightVinyl').selectedIndex === 0)
                    document.getElementById('MainContent_ddlWindowAsIfHeightVinyl').selectedIndex = document.getElementById('MainContent_ddlWindowHeightVinyl').selectedIndex;

                if (document.getElementById('MainContent_radWindowBothRadVinyl').checked) {
                    bothUnevenClicked();
                }
            }
            else {
                document.getElementById('MainContent_rowWindowUnevenVentsTopVinyl').style.display = 'none';
                document.getElementById('MainContent_txtWindowTopVentHeightVinyl').value = '';
                document.getElementById('MainContent_rowWindowUnevenVentsBottomVinyl').style.display = 'none';
                document.getElementById('MainContent_txtWindowBottomVentHeightVinyl').value = '';
                document.getElementById('MainContent_rowWindowAsIfHeightVinyl').style.display = 'none';
                document.getElementById('MainContent_rowWindowTopBottomBothRadVinyl').style.display = 'none';
            }
        }

        /*
        This function gets called when tint options are changed
        It displays appropriate number of mixed tint rows based on the user selections
        */
        function tintOptionsChanged() {
            var tempVents;
            var tintValue = document.getElementById('MainContent_ddlWindowTintVinyl').options[document.getElementById('MainContent_ddlWindowTintVinyl').selectedIndex].value;
            var numOfVents = document.getElementById('MainContent_ddlWindowV4TNumberOfVentsVinyl').options[document.getElementById('MainContent_ddlWindowV4TNumberOfVentsVinyl').selectedIndex].value;

            var vinylRows = (numOfVents == 12) ? 4 :
                            (numOfVents == 9) ? 3 :
                            (numOfVents == 8) ? 4 :
                            (numOfVents == 6) ? 3 :
                            (numOfVents == 4) ? 4 : 3;

            if (tempVents != numOfVents) {
                tempVents = numOfVents;
                for (var i = 0; i < 4; i++) {
                    document.getElementById('MainContent_row' + i + 'WindowTintVinyl').style.display = 'none';
                }
                for (var i = 0; i < vinylRows; i++) {
                    document.getElementById('MainContent_row' + i + 'WindowTintVinyl').style.display = 'table-row';
                }
            }

            if (tintValue == "Mixed") {
                for (var i = 0; i < 4; i++) {
                    document.getElementById('MainContent_row' + i + 'WindowTintVinyl').style.display = 'none';
                }
                for (var i = 0; i < vinylRows; i++) {
                    document.getElementById('MainContent_row' + i + 'WindowTintVinyl').style.display = 'table-row';
                }
            }
            else {
                for (var i = 0; i < 4; i++) {
                    document.getElementById('MainContent_row' + i + 'WindowTintVinyl').style.display = 'none';
                }
            }
        }

        /*
        This function gets called when inside and outside mount radio buttons are clicked
        It hides and displays the appropriate rows depending on which radio button is clicked
        @param checked - true/false, outsideMount checked or unchecked
        */
        function outsideMountChecked(checked) {
            if (typeof (checked) === 'undefined') checked = false; //if no value given, set it to false

            if (checked) 
                document.getElementById('MainContent_rowWindowScreenOptionsVinyl').style.display = 'table-row';
            else
                document.getElementById('MainContent_rowWindowScreenOptionsVinyl').style.display = 'none';
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
                case "6":
                    MIN_WIDTH_BUILDABLE = V4T_6V_MIN_WIDTH_BUILDABLE;
                    MAX_WIDTH_BUILDABLE = V4T_6V_MAX_WIDTH_BUILDABLE;
                    MIN_HEIGHT_BUILDABLE = V4T_6V_MIN_HEIGHT_BUILDABLE;
                    MAX_HEIGHT_BUILDABLE = V4T_6V_MAX_HEIGHT_BUILDABLE;
                    MIN_WIDTH_WARRANTY = V4T_6V_MIN_WIDTH_WARRANTY;
                    MAX_WIDTH_WARRANTY = V4T_6V_MAX_WIDTH_WARRANTY;
                    MIN_HEIGHT_WARRANTY = V4T_6V_MIN_HEIGHT_WARRANTY;
                    MAX_HEIGHT_WARRANTY = V4T_6V_MAX_HEIGHT_WARRANTY;
                    break;
                case "8":
                    MIN_WIDTH_BUILDABLE = V4T_8V_MIN_WIDTH_BUILDABLE;
                    MAX_WIDTH_BUILDABLE = V4T_8V_MAX_WIDTH_BUILDABLE;
                    MIN_HEIGHT_BUILDABLE = V4T_8V_MIN_HEIGHT_BUILDABLE;
                    MAX_HEIGHT_BUILDABLE = V4T_8V_MAX_HEIGHT_BUILDABLE;
                    MIN_WIDTH_WARRANTY = V4T_8V_MIN_WIDTH_WARRANTY;
                    MAX_WIDTH_WARRANTY = V4T_8V_MAX_WIDTH_WARRANTY;
                    MIN_HEIGHT_WARRANTY = V4T_8V_MIN_HEIGHT_WARRANTY;
                    MAX_HEIGHT_WARRANTY = V4T_8V_MAX_HEIGHT_WARRANTY;
                    break;
                case "9":
                    MIN_WIDTH_BUILDABLE = V4T_9V_MIN_WIDTH_BUILDABLE;
                    MAX_WIDTH_BUILDABLE = V4T_9V_MAX_WIDTH_BUILDABLE;
                    MIN_HEIGHT_BUILDABLE = V4T_9V_MIN_HEIGHT_BUILDABLE;
                    MAX_HEIGHT_BUILDABLE = V4T_9V_MAX_HEIGHT_BUILDABLE;
                    MIN_WIDTH_WARRANTY = V4T_9V_MIN_WIDTH_WARRANTY;
                    MAX_WIDTH_WARRANTY = V4T_9V_MAX_WIDTH_WARRANTY;
                    MIN_HEIGHT_WARRANTY = V4T_9V_MIN_HEIGHT_WARRANTY;
                    MAX_HEIGHT_WARRANTY = V4T_9V_MAX_HEIGHT_WARRANTY;
                    break;
                case "12":
                    MIN_WIDTH_BUILDABLE = V4T_12V_MIN_WIDTH_BUILDABLE;
                    MAX_WIDTH_BUILDABLE = V4T_12V_MAX_WIDTH_BUILDABLE;
                    MIN_HEIGHT_BUILDABLE = V4T_12V_MIN_HEIGHT_BUILDABLE;
                    MAX_HEIGHT_BUILDABLE = V4T_12V_MAX_HEIGHT_BUILDABLE;
                    MIN_WIDTH_WARRANTY = V4T_12V_MIN_WIDTH_WARRANTY;
                    MAX_WIDTH_WARRANTY = V4T_12V_MAX_WIDTH_WARRANTY;
                    MIN_HEIGHT_WARRANTY = V4T_12V_MIN_HEIGHT_WARRANTY;
                    MAX_HEIGHT_WARRANTY = V4T_12V_MAX_HEIGHT_WARRANTY;
                    break;
            }
        }


        /*
        This function gets called when the window style is changed for vinyl windows
        It hides and displays all appropriate rows for that type of window and sets all the default values for the validation constants
        @param dropdownValue - the style of vinyl window selected (V4T, H2T, H4T, Fixed, Trapezoid)
        */
        function windowVinylStyleChanged(dropdownValue) { 

            switch (dropdownValue) { // this switch statement checks the window style selected and sets values of that particular window style to the validation constants
                case "Vertical 4 Track":
                    //determine the max and min sizes based on the number of vents in a V4T window
                    windowVinylNumberOfVentsChanged(document.getElementById('MainContent_ddlWindowV4TNumberOfVentsVinyl').options[document.getElementById('MainContent_ddlWindowV4TNumberOfVentsVinyl').selectedIndex].value);
                    break;
                case "Horizontal 2 Track":
                case "Horizontal 4 Track":
                    MIN_WIDTH_BUILDABLE = HORIZONTAL_ROLLER_MIN_WIDTH_BUILDABLE;
                    MAX_WIDTH_BUILDABLE = HORIZONTAL_ROLLER_MAX_WIDTH_BUILDABLE;
                    MIN_HEIGHT_BUILDABLE = HORIZONTAL_ROLLER_MIN_HEIGHT_BUILDABLE;
                    MAX_HEIGHT_BUILDABLE = HORIZONTAL_ROLLER_MAX_HEIGHT_BUILDABLE;
                    MIN_WIDTH_WARRANTY = HORIZONTAL_ROLLER_MIN_WIDTH_WARRANTY;
                    MAX_WIDTH_WARRANTY = HORIZONTAL_ROLLER_MAX_WIDTH_WARRANTY;
                    MIN_HEIGHT_WARRANTY = HORIZONTAL_ROLLER_MIN_HEIGHT_WARRANTY;
                    MAX_HEIGHT_WARRANTY = HORIZONTAL_ROLLER_MAX_HEIGHT_WARRANTY;
                    break;
                case "Vinyl Fixed Lite":
                    MIN_WIDTH_BUILDABLE = VINYL_LITE_MIN_WIDTH_BUILDABLE;
                    MAX_WIDTH_BUILDABLE = VINYL_LITE_MAX_WIDTH_BUILDABLE;
                    MIN_HEIGHT_BUILDABLE = VINYL_LITE_MIN_HEIGHT_BUILDABLE;
                    MAX_HEIGHT_BUILDABLE = VINYL_LITE_MAX_HEIGHT_BUILDABLE;
                    MIN_WIDTH_WARRANTY = VINYL_LITE_MIN_WIDTH_WARRANTY;
                    MAX_WIDTH_WARRANTY = VINYL_LITE_MAX_WIDTH_WARRANTY;
                    MIN_HEIGHT_WARRANTY = VINYL_LITE_MIN_HEIGHT_WARRANTY;
                    MAX_HEIGHT_WARRANTY = VINYL_LITE_MAX_HEIGHT_WARRANTY;
                    break;
                case "Vinyl Fixed Trapezoid":
                    MIN_WIDTH_BUILDABLE = VINYL_TRAP_MIN_WIDTH_BUILDABLE;
                    MAX_WIDTH_BUILDABLE = VINYL_TRAP_MAX_WIDTH_BUILDABLE;
                    MIN_HEIGHT_BUILDABLE = VINYL_TRAP_MIN_HEIGHT_BUILDABLE;
                    MAX_HEIGHT_BUILDABLE = VINYL_TRAP_MAX_HEIGHT_BUILDABLE;
                    MIN_WIDTH_WARRANTY = VINYL_TRAP_MIN_WIDTH_WARRANTY;
                    MAX_WIDTH_WARRANTY = VINYL_TRAP_MAX_WIDTH_WARRANTY;
                    MIN_HEIGHT_WARRANTY = VINYL_TRAP_MIN_HEIGHT_WARRANTY;
                    MAX_HEIGHT_WARRANTY = VINYL_TRAP_MAX_HEIGHT_WARRANTY;
                    break;
            }


            if (dropdownValue === "Vertical 4 Track" ||
                dropdownValue === "Horizontal 2 Track" || 
                dropdownValue === "Horizontal 3 Track" || 
                dropdownValue === "Horizontal 4 Track") {
                    
                document.getElementById('MainContent_rowWindowHeightVinyl').style.display = 'table-row';
                document.getElementById('MainContent_rowWindowLeftHeightVinyl').style.display = 'none';
                document.getElementById('MainContent_rowWindowRightHeightVinyl').style.display = 'none';

                if (dropdownValue === "Vertical 4 Track") {
                    document.getElementById('MainContent_rowWindowInsideMountVinyl').style.display = 'table-row';
                    document.getElementById('MainContent_rowWindowOutsideMountVinyl').style.display = 'table-row';
                    document.getElementById('MainContent_cellWindowUnevenVentsVinyl').style.display = 'table-row';
                    document.getElementById('MainContent_cellWindowSpreaderBarVinyl').style.display = 'table-row';
                    document.getElementById('MainContent_rowWindowV4TNumberOfVentsVinyl').style.display = 'table-row';
                    document.getElementById('MainContent_rowWindowH4TNumberOfVentsVinyl').style.display = 'none';
                    document.getElementById('MainContent_rowWindowTintVinyl').style.display = 'table-row';
                    document.getElementById('MainContent_rowWindowTintNoMixedVinyl').style.display = 'none';
                }
                else if (dropdownValue === "Horizontal 2 Track" ||
                         dropdownValue === "Horizontal 4 Track") {

                    document.getElementById('MainContent_rowWindowInsideMountVinyl').style.display = 'none';
                    document.getElementById('MainContent_rowWindowOutsideMountVinyl').style.display = 'none';
                    document.getElementById('MainContent_cellWindowUnevenVentsVinyl').style.display = 'none';
                    document.getElementById('MainContent_cellWindowSpreaderBarVinyl').style.display = 'table-row';
                    document.getElementById('MainContent_rowWindowV4TNumberOfVentsVinyl').style.display = 'none';
                    document.getElementById('MainContent_rowWindowScreenOptionsVinyl').style.display = 'table-row';
                    document.getElementById('MainContent_rowWindowTintVinyl').style.display = 'none';
                    document.getElementById('MainContent_rowWindowTintNoMixedVinyl').style.display = 'table-row';
                    document.getElementById('MainContent_rowWindowTopBottomBothRadVinyl').style.display = 'none';
                    document.getElementById('MainContent_rowWindowAsIfHeightVinyl').style.display = 'none';
                    document.getElementById('MainContent_txtWindowTopVentHeightVinyl').value = '';
                    document.getElementById('MainContent_txtWindowBottomVentHeightVinyl').value = '';
                    document.getElementById('MainContent_rowWindowUnevenVentsTopVinyl').style.display = 'none';
                    document.getElementById('MainContent_rowWindowUnevenVentsBottomVinyl').style.display = 'none';

                    if (dropdownValue === "Horizontal 4 Track")
                        document.getElementById('MainContent_rowWindowH4TNumberOfVentsVinyl').style.display = 'table-row';
                    else
                        document.getElementById('MainContent_rowWindowH4TNumberOfVentsVinyl').style.display = 'none';
                }
            }
            else if (dropdownValue == 'Vinyl Trapezoid' || dropdownValue == 'Vinyl Fixed Lite') {

                for (var i = 0; i < 4; i++)
                    document.getElementById('MainContent_row' + i + 'WindowTintVinyl').style.display = 'none';

                document.getElementById('MainContent_rowWindowTintVinyl').style.display = 'none';
                document.getElementById('MainContent_rowWindowTintNoMixedVinyl').style.display = 'table-row';
                document.getElementById('MainContent_rowWindowTopBottomBothRadVinyl').style.display = 'none';
                document.getElementById('MainContent_rowWindowAsIfHeightVinyl').style.display = 'none';
                document.getElementById('MainContent_txtWindowTopVentHeightVinyl').value = '';
                document.getElementById('MainContent_txtWindowBottomVentHeightVinyl').value = '';
                document.getElementById('MainContent_rowWindowUnevenVentsTopVinyl').style.display = 'none';
                document.getElementById('MainContent_rowWindowUnevenVentsBottomVinyl').style.display = 'none';
                document.getElementById('MainContent_rowWindowHeightVinyl').style.display = 'table-row';
                document.getElementById('MainContent_rowWindowLeftHeightVinyl').style.display = 'none';
                document.getElementById('MainContent_rowWindowRightHeightVinyl').style.display = 'none';


                if (dropdownValue == 'Vinyl Trapezoid') {
                    document.getElementById('MainContent_rowWindowHeightVinyl').style.display = 'none';
                    document.getElementById('MainContent_rowWindowLeftHeightVinyl').style.display = 'table-row';
                    document.getElementById('MainContent_rowWindowRightHeightVinyl').style.display = 'table-row';
                }
                else {
                    document.getElementById('MainContent_rowWindowHeightVinyl').style.display = 'table-row';
                    document.getElementById('MainContent_rowWindowLeftHeightVinyl').style.display = 'none';
                    document.getElementById('MainContent_rowWindowRightHeightVinyl').style.display = 'none';
                }

                document.getElementById('MainContent_rowWindowScreenOptionsVinyl').style.display = 'none';
                document.getElementById('MainContent_rowWindowInsideMountVinyl').style.display = 'none';
                document.getElementById('MainContent_rowWindowOutsideMountVinyl').style.display = 'none';
                document.getElementById('MainContent_cellWindowUnevenVentsVinyl').style.display = 'none';
                document.getElementById('MainContent_rowWindowUnevenVentsTopVinyl').style.display = 'none';
                document.getElementById('MainContent_txtWindowTopVentHeightVinyl').value = '';
                document.getElementById('MainContent_rowWindowUnevenVentsBottomVinyl').style.display = 'none';
                document.getElementById('MainContent_txtWindowBottomVentHeightVinyl').value = '';
                document.getElementById('MainContent_cellWindowSpreaderBarVinyl').style.display = 'none';
                document.getElementById('MainContent_rowWindowTintVinyl').style.display = 'none';
                document.getElementById('MainContent_rowWindowV4TNumberOfVentsVinyl').style.display = 'none';
                document.getElementById('MainContent_rowWindowH4TNumberOfVentsVinyl').style.display = 'none';
            }
        }

        /*
        This function gets called when the window style is changed for glass windows
        It hides and displays all appropriate rows for that type of window and sets all the default values for the validation constants
        @param dropdownValue - the style of vinyl window selected 
        */
        function windowGlassStyleChanged(dropdownValue) {

            switch (dropdownValue) {
                case "PVC XO Single Glazed Horizontal Roller":
                    MIN_WIDTH_BUILDABLE = SINGLE_SLIDER_MIN_WIDTH_BUILDABLE;
                    MAX_WIDTH_BUILDABLE = SINGLE_SLIDER_MAX_WIDTH_BUILDABLE;
                    MIN_HEIGHT_BUILDABLE = SINGLE_SLIDER_MIN_HEIGHT_BUILDABLE;
                    MAX_HEIGHT_BUILDABLE = SINGLE_SLIDER_MAX_HEIGHT_BUILDABLE;
                    MIN_WIDTH_WARRANTY = SINGLE_SLIDER_MIN_WIDTH_WARRANTY;
                    MAX_WIDTH_WARRANTY = SINGLE_SLIDER_MAX_WIDTH_WARRANTY;
                    MIN_HEIGHT_WARRANTY = SINGLE_SLIDER_MIN_HEIGHT_WARRANTY;
                    MAX_HEIGHT_WARRANTY = SINGLE_SLIDER_MAX_HEIGHT_WARRANTY;
                    break;
                case "Aluminum Framed Picture":
                    MIN_WIDTH_BUILDABLE = SINGLE_SLIDER_LITE_MIN_WIDTH_BUILDABLE;
                    MAX_WIDTH_BUILDABLE = SINGLE_SLIDER_LITE_MAX_WIDTH_BUILDABLE;
                    MIN_HEIGHT_BUILDABLE = SINGLE_SLIDER_LITE_MIN_HEIGHT_BUILDABLE;
                    MAX_HEIGHT_BUILDABLE = SINGLE_SLIDER_LITE_MAX_HEIGHT_BUILDABLE;
                    MIN_WIDTH_WARRANTY = SINGLE_SLIDER_LITE_MIN_WIDTH_WARRANTY;
                    MAX_WIDTH_WARRANTY = SINGLE_SLIDER_LITE_MAX_WIDTH_WARRANTY;
                    MIN_HEIGHT_WARRANTY = SINGLE_SLIDER_LITE_MIN_HEIGHT_WARRANTY;
                    MAX_HEIGHT_WARRANTY = SINGLE_SLIDER_LITE_MAX_HEIGHT_WARRANTY;
                    break;
                case "Aluminum Framed Trapezoid":
                    MIN_WIDTH_BUILDABLE = SINGLE_SLIDER_TRAP_MIN_WIDTH_BUILDABLE;
                    MAX_WIDTH_BUILDABLE = SINGLE_SLIDER_TRAP_MAX_WIDTH_BUILDABLE;
                    MIN_HEIGHT_BUILDABLE = SINGLE_SLIDER_TRAP_MIN_HEIGHT_BUILDABLE;
                    MAX_HEIGHT_BUILDABLE = SINGLE_SLIDER_TRAP_MAX_HEIGHT_BUILDABLE;
                    MIN_WIDTH_WARRANTY = SINGLE_SLIDER_TRAP_MIN_WIDTH_WARRANTY;
                    MAX_WIDTH_WARRANTY = SINGLE_SLIDER_TRAP_MAX_WIDTH_WARRANTY;
                    MIN_HEIGHT_WARRANTY = SINGLE_SLIDER_TRAP_MIN_HEIGHT_WARRANTY;
                    MAX_HEIGHT_WARRANTY = SINGLE_SLIDER_TRAP_MAX_HEIGHT_WARRANTY;
                    break;
                case "Aluminum XX Horizontal Roller":
                    MIN_WIDTH_BUILDABLE = DOUBLE_SLIDER_MIN_WIDTH_BUILDABLE;
                    MAX_WIDTH_BUILDABLE = DOUBLE_SLIDER_MAX_WIDTH_BUILDABLE;
                    MIN_HEIGHT_BUILDABLE = DOUBLE_SLIDER_MIN_HEIGHT_BUILDABLE;
                    MAX_HEIGHT_BUILDABLE = DOUBLE_SLIDER_MAX_HEIGHT_BUILDABLE;
                    MIN_WIDTH_WARRANTY = DOUBLE_SLIDER_MIN_WIDTH_WARRANTY;
                    MAX_WIDTH_WARRANTY = DOUBLE_SLIDER_MAX_WIDTH_WARRANTY;
                    MIN_HEIGHT_WARRANTY = DOUBLE_SLIDER_MIN_HEIGHT_WARRANTY;
                    MAX_HEIGHT_WARRANTY = DOUBLE_SLIDER_MAX_HEIGHT_WARRANTY;
                    break;
                case "PVC Framed Single Glazed Picture":
                    MIN_WIDTH_BUILDABLE = DOUBLE_SLIDER_LITE_MIN_WIDTH_BUILDABLE;
                    MAX_WIDTH_BUILDABLE = DOUBLE_SLIDER_LITE_MAX_WIDTH_BUILDABLE;
                    MIN_HEIGHT_BUILDABLE = DOUBLE_SLIDER_LITE_MIN_HEIGHT_BUILDABLE;
                    MAX_HEIGHT_BUILDABLE = DOUBLE_SLIDER_LITE_MAX_HEIGHT_BUILDABLE;
                    MIN_WIDTH_WARRANTY = DOUBLE_SLIDER_LITE_MIN_WIDTH_WARRANTY;
                    MAX_WIDTH_WARRANTY = DOUBLE_SLIDER_LITE_MAX_WIDTH_WARRANTY;
                    MIN_HEIGHT_WARRANTY = DOUBLE_SLIDER_LITE_MIN_HEIGHT_WARRANTY;
                    MAX_HEIGHT_WARRANTY = DOUBLE_SLIDER_LITE_MAX_HEIGHT_WARRANTY;
                    break;
                case "PVC Framed Single Glazed Trapezoid":
                    MIN_WIDTH_BUILDABLE = DOUBLE_SLIDER_TRAP_MIN_WIDTH_BUILDABLE;
                    MAX_WIDTH_BUILDABLE = DOUBLE_SLIDER_TRAP_MAX_WIDTH_BUILDABLE;
                    MIN_HEIGHT_BUILDABLE = DOUBLE_SLIDER_TRAP_MIN_HEIGHT_BUILDABLE;
                    MAX_HEIGHT_BUILDABLE = DOUBLE_SLIDER_TRAP_MAX_HEIGHT_BUILDABLE;
                    MIN_WIDTH_WARRANTY = DOUBLE_SLIDER_TRAP_MIN_WIDTH_WARRANTY;
                    MAX_WIDTH_WARRANTY = DOUBLE_SLIDER_TRAP_MAX_WIDTH_WARRANTY;
                    MIN_HEIGHT_WARRANTY = DOUBLE_SLIDER_TRAP_MIN_HEIGHT_WARRANTY;
                    MAX_HEIGHT_WARRANTY = DOUBLE_SLIDER_TRAP_MAX_HEIGHT_WARRANTY;
                    break;
            }

            if (dropdownValue == 'Aluminum Framed Trapezoid' || dropdownValue == 'PVC Framed Single Glazed Trapezoid') {
                document.getElementById('MainContent_rowWindowHeightGlass').style.display = 'none';
                document.getElementById('MainContent_rowWindowLeftHeightGlass').style.display = 'table-row';
                document.getElementById('MainContent_rowWindowRightHeightGlass').style.display = 'table-row';
            }
            else {
                document.getElementById('MainContent_rowWindowHeightGlass').style.display = 'table-row';
                document.getElementById('MainContent_rowWindowLeftHeightGlass').style.display = 'none';
                document.getElementById('MainContent_rowWindowRightHeightGlass').style.display = 'none';
            }
        }

        /*
        This function gets called when the window style is changed for screen windows
        It hides and displays all appropriate rows for that type of window and sets all the default values for the validation constants
        @param dropdownValue - the style of vinyl window selected
        */
        function windowScreenStyleChanged(dropdownValue) {

            switch (dropdownValue) {
                case "Screen Fixed Lite":
                    MIN_WIDTH_BUILDABLE = SCREEN_MIN_WIDTH_BUILDABLE;
                    MAX_WIDTH_BUILDABLE = SCREEN_MAX_WIDTH_BUILDABLE;
                    MIN_HEIGHT_BUILDABLE = SCREEN_MIN_HEIGHT_BUILDABLE;
                    MAX_HEIGHT_BUILDABLE = SCREEN_MAX_HEIGHT_BUILDABLE;
                    MIN_WIDTH_WARRANTY = SCREEN_MIN_WIDTH_WARRANTY;
                    MAX_WIDTH_WARRANTY = SCREEN_MAX_WIDTH_WARRANTY;
                    MIN_HEIGHT_WARRANTY = SCREEN_MIN_HEIGHT_WARRANTY;
                    MAX_HEIGHT_WARRANTY = SCREEN_MAX_HEIGHT_WARRANTY;
                    break;
            }
        }


    </script>

    <div class="slide-window" id="slide-window" >

        <div class="slide-wrapper">
            <%-- QUESTION 3 - DOOR OPTIONS/DETAILS
            ======================================== --%>

            <div id="slide3" class="slide">
                <h1>
                    <asp:Label ID="lblWindowDetails" runat="server" Text="Window Details"></asp:Label>
                </h1>        
    
                <ul class="toggleOptions">
                    <asp:PlaceHolder ID="WindowOptions" runat="server"></asp:PlaceHolder>                    
                </ul>            

                <asp:Button ID="btnQuestion3" Enabled="true" CssClass="btnSubmit float-right slidePanel" data-slide="#slide1" runat="server" Text="Next Question"/>

            </div>
            <%-- end #slide3 --%>

         </div>
    </div>

<%-- SLIDE PAGING (QUESTION NAVIGATION)
    ======================================== --%>
    <div id="sidebar">
        <div id="paging-wrapper">    
            <div id="paging"> 
                <h2>Window Specifications</h2>
                <asp:PlaceHolder ID="lblWindowPager" runat="server"></asp:PlaceHolder>  
            </div> <%-- end #paging --%>      
        </div>

        <asp:Label ID="lblErrorMessage" CssClass="lblErrorMessage" runat="server" Text="Label">Oh hello, I am an error message.</asp:Label>
        <textarea id="txtErrorMessage" class="txtErrorMessage"  rows="5" runat="server"></textarea>
    </div>
</asp:Content>
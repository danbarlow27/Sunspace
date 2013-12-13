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


        var spreaderBar = -1;
        var dlo = 2.0;
        var deductions = 0.0;
        var tint;
        var ventHeight;
        var ventWidth;

        var MIN_WIDTH_BUILDABLE;
        var MAX_WIDTH_BUILDABLE;
        var MIN_HEIGHT_BUILDABLE;
        var MAX_HEIGHT_BUILDABLE;
        var MIN_WIDTH_WARRANTY;
        var MAX_WIDTH_WARRANTY;
        var MIN_HEIGHT_WARRANTY;
        var MAX_HEIGHT_WARRANTY;


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

        function recalculate() {
            //everything including vent sizes, DLO/Deductions, etc.
            //alert("recalculate");
        }


        function validateInteger(textbox) {

            var valid;
            if (isNaN(textbox.value)) {
                valid = false;
            }
            else { //is a number
                if (textbox.value.indexOf('.') === -1) { //doesn't contain a period
                    valid = true;
                }
                else {
                    valid = false;
                }

                if (textbox.value <= 0) {  //negative number or zero
                    valid = false;
                }
                else { //positive number
                    valid = true;
                }
            }
            return valid;
        }

        function getHeightAndWidthOfEachVent(asIf) {
            
            if(typeof(asIf)==='undefined') asIf = false;

            if (validateInteger(document.getElementById('MainContent_txtWindowHeightVinyl')) && //height is a valid integer
                validateInteger(document.getElementById('MainContent_txtWindowAsIfHeightVinyl')) && //as-if height is a valid integer
                validateInteger(document.getElementById('MainContent_txtWindowWidthVinyl'))) { //width is a valid integer


                var ventCount = document.getElementById('MainContent_ddlWindowV4TNumberOfVentsVinyl').options[document.getElementById('MainContent_ddlWindowV4TNumberOfVentsVinyl').selectedIndex].value;
                var windowWidth = document.getElementById('MainContent_txtWindowWidthVinyl').value + document.getElementById('MainContent_ddlWindowWidthVinyl').options[document.getElementById('MainContent_ddlWindowWidthVinyl').selectedIndex].value;
                var windowHeight = (asIf) ? document.getElementById('MainContent_txtWindowAsIfHeightVinyl').value + document.getElementById('MainContent_ddlWindowAsIfHeightVinyl').options[document.getElementById('MainContent_ddlWindowAsIfHeightVinyl').selectedIndex].value : 
                                            document.getElementById('MainContent_txtWindowHeightVinyl').value + document.getElementById('MainContent_ddlWindowHeightVinyl').options[document.getElementById('MainContent_ddlWindowHeightVinyl').selectedIndex].value;
            
                if (ventCount > 8) { 
                    ventWidth = (windowWidth - 1.5625 - 2.75) / 3;
                }
                else if (ventCount > 4) {
                    ventWidth = (windowWidth - 1.5625 - 1.6875) / 2;
                }
                else {
                    ventWidth = windowWidth - 1.5625;
                }

                if (ventCount % 4 === 0) {
                    ventHeight = (windowHeight + 2.187) / 4;
                }
                else if (ventCount % 3 === 0) {
                    ventHeight = (windowHeight + 1.3125) / 3;
                }
                else {
                    ventHeight = (windowHeight + 0.4375) / 2;
                }
                        
                ventHeight =  Math.round(ventHeight * 100) / 100;
                ventWidth = Math.round(ventWidth * 100) / 100;
            }

            else {
                //error: please input a valid Height and Build-As-If Height
                alert("enter some numbers you fool!");
                document.getElementById('MainContent_radWindowBottomRadVinyl').checked = true;
            }
        }
            
        function bothUnevenClicked() {
                getHeightAndWidthOfEachVent(true);
                
                document.getElementById('MainContent_txtWindowTopVentHeightVinyl').value = ventHeight;
                document.getElementById('MainContent_txtWindowBottomVentHeightVinyl').value = ventHeight;

                document.getElementById('MainContent_rowWindowUnevenVentsTopVinyl').style.display = 'table-row';
                document.getElementById('MainContent_rowWindowUnevenVentsBottomVinyl').style.display = 'table-row';
        }

        function topOrBottomUnevenClicked(){
            document.getElementById('MainContent_txtWindowTopVentHeightVinyl').value = '';
            document.getElementById('MainContent_txtWindowBottomVentHeightVinyl').value = '';

            document.getElementById('MainContent_rowWindowUnevenVentsTopVinyl').style.display = 'none';
            document.getElementById('MainContent_rowWindowUnevenVentsBottomVinyl').style.display = 'none';
        }

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

        function outsideMountChecked(checked) {
            if (typeof (checked) === 'undefined') checked = false;

            if (checked) 
                document.getElementById('MainContent_rowWindowScreenOptionsVinyl').style.display = 'table-row';
            else
                document.getElementById('MainContent_rowWindowScreenOptionsVinyl').style.display = 'none';
        }

        function windowVinylStyleChanged(dropdownValue) { 

            switch (dropdownValue) {
                case "Vertical 4 Track":
                    var vents = document.getElementById('MainContent_ddlWindowV4TNumberOfVentsVinyl').options[document.getElementById('MainContent_ddlWindowV4TNumberOfVentsVinyl').selectedIndex].value;
                    
                    switch (vents) {
                        case 3:
                            MIN_WIDTH_BUILDABLE = V4T_3V_MIN_WIDTH_BUILDABLE;
                            MAX_WIDTH_BUILDABLE = V4T_3V_MAX_WIDTH_BUILDABLE;
                            MIN_HEIGHT_BUILDABLE = V4T_3V_MIN_HEIGHT_BUILDABLE;
                            MAX_HEIGHT_BUILDABLE = V4T_3V_MAX_HEIGHT_BUILDABLE;
                            MIN_WIDTH_WARRANTY = V4T_3V_MIN_WIDTH_WARRANTY;
                            MAX_WIDTH_WARRANTY = V4T_3V_MAX_WIDTH_WARRANTY;
                            MIN_HEIGHT_WARRANTY = V4T_3V_MIN_HEIGHT_WARRANTY;
                            MAX_HEIGHT_WARRANTY = V4T_3V_MAX_HEIGHT_WARRANTY;
                            break;
                        case 4:
                            MIN_WIDTH_BUILDABLE = V4T_4V_MIN_WIDTH_BUILDABLE;
                            MAX_WIDTH_BUILDABLE = V4T_4V_MAX_WIDTH_BUILDABLE;
                            MIN_HEIGHT_BUILDABLE = V4T_4V_MIN_HEIGHT_BUILDABLE;
                            MAX_HEIGHT_BUILDABLE = V4T_4V_MAX_HEIGHT_BUILDABLE;
                            MIN_WIDTH_WARRANTY = V4T_4V_MIN_WIDTH_WARRANTY;
                            MAX_WIDTH_WARRANTY = V4T_4V_MAX_WIDTH_WARRANTY;
                            MIN_HEIGHT_WARRANTY = V4T_4V_MIN_HEIGHT_WARRANTY;
                            MAX_HEIGHT_WARRANTY = V4T_4V_MAX_HEIGHT_WARRANTY;
                            break;
                        case 6:
                            MIN_WIDTH_BUILDABLE = V4T_6V_MIN_WIDTH_BUILDABLE;
                            MAX_WIDTH_BUILDABLE = V4T_6V_MAX_WIDTH_BUILDABLE;
                            MIN_HEIGHT_BUILDABLE = V4T_6V_MIN_HEIGHT_BUILDABLE;
                            MAX_HEIGHT_BUILDABLE = V4T_6V_MAX_HEIGHT_BUILDABLE;
                            MIN_WIDTH_WARRANTY = V4T_6V_MIN_WIDTH_WARRANTY;
                            MAX_WIDTH_WARRANTY = V4T_6V_MAX_WIDTH_WARRANTY;
                            MIN_HEIGHT_WARRANTY = V4T_6V_MIN_HEIGHT_WARRANTY;
                            MAX_HEIGHT_WARRANTY = V4T_6V_MAX_HEIGHT_WARRANTY;
                            break;
                        case 8:
                            MIN_WIDTH_BUILDABLE = V4T_8V_MIN_WIDTH_BUILDABLE;
                            MAX_WIDTH_BUILDABLE = V4T_8V_MAX_WIDTH_BUILDABLE;
                            MIN_HEIGHT_BUILDABLE = V4T_8V_MIN_HEIGHT_BUILDABLE;
                            MAX_HEIGHT_BUILDABLE = V4T_8V_MAX_HEIGHT_BUILDABLE;
                            MIN_WIDTH_WARRANTY = V4T_8V_MIN_WIDTH_WARRANTY;
                            MAX_WIDTH_WARRANTY = V4T_8V_MAX_WIDTH_WARRANTY;
                            MIN_HEIGHT_WARRANTY = V4T_8V_MIN_HEIGHT_WARRANTY;
                            MAX_HEIGHT_WARRANTY = V4T_8V_MAX_HEIGHT_WARRANTY;
                            break;
                        case 9:
                            MIN_WIDTH_BUILDABLE = V4T_9V_MIN_WIDTH_BUILDABLE;
                            MAX_WIDTH_BUILDABLE = V4T_9V_MAX_WIDTH_BUILDABLE;
                            MIN_HEIGHT_BUILDABLE = V4T_9V_MIN_HEIGHT_BUILDABLE;
                            MAX_HEIGHT_BUILDABLE = V4T_9V_MAX_HEIGHT_BUILDABLE;
                            MIN_WIDTH_WARRANTY = V4T_9V_MIN_WIDTH_WARRANTY;
                            MAX_WIDTH_WARRANTY = V4T_9V_MAX_WIDTH_WARRANTY;
                            MIN_HEIGHT_WARRANTY = V4T_9V_MIN_HEIGHT_WARRANTY;
                            MAX_HEIGHT_WARRANTY = V4T_9V_MAX_HEIGHT_WARRANTY;
                            break;
                        case 12:
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

        <%--<asp:Label ID="lblErrorMessage" CssClass="lblErrorMessage" runat="server" Text="Label">Oh hello, I am an error message.</asp:Label>--%>
        <textarea id="txtErrorMessage" class="txtErrorMessage" disabled="disabled" rows="5" runat="server"></textarea>
    </div>
</asp:Content>
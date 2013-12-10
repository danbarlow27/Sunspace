<%@ Page Title="New Project - Windows Only" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WizardWindowsOnly.aspx.cs" Inherits="SunspaceDealerDesktop.WizardWindowsOnly" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">    
    <script src="Scripts/GlobalFunctions.js"></script>
    <script src="Scripts/Validation.js"></script>
    <script>

        var spreaderBar = 0.0;
        var dlo = 2.0;
        var deductions = 0.0;
        var tint;
        var ventHeight;
        var ventWidth;

        /**
        *customDimension
        *Checks the drop down selection on change, if the selection is custom, displays additional fields,
        *else custom field is hidden (i.e. css style.display = none)
        *@param wallNumber - holds an integer to know which wall is currently being affected
        *@param type - gets the type of window selected (i.e. Cabana, French, Patio, Opening Only (No Window));
        *@param dimension - gets the dimension currently being called (i.e Width, Height)
        */
        function customDimension(type, dimension) {

            //Get the respective drop downs selected value, store it into dimensionDDL variable
            var dimensionDDL = document.getElementById('MainContent_ddlWindow' + dimension + type).options[document.getElementById('MainContent_ddlWindow' + dimension + type).selectedIndex].value;

            //If the selected value is custom (i.e. cWidth, etc), perform block
            if (document.getElementById('MainContent_radType' + type).checked && dimensionDDL == 'c' + dimension) {
                //Set display style of respective row to "inherit"
                document.getElementById('MainContent_rowWindowCustom' + dimension + type).style.display = 'inherit';
            }
            else {
                //Set display style of respective row to "none"
                document.getElementById('MainContent_rowWindowCustom' + dimension + type).style.display = 'none';
            }
        }

        //function spreaderBar() {
        //    //maybe not necessary
        //    alert("ahoj spreader bar");
        //}

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

            var ventCount = document.getElementById('MainContent_ddlWindowV4TNumberOfVentsVinyl').options[document.getElementById('MainContent_ddlWindowV4TNumberOfVentsVinyl').selectedIndex].value;
            //var vinylRows = (ventCount == 12) ? 4 :
            //    (ventCount == 9) ? 3 :
            //    (ventCount == 8) ? 4 :
            //    (ventCount == 6) ? 3 :
            //    (ventCount == 4) ? 4 : 
            //    (ventCount == 3) ? 3 : 2;            
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

        function bothUnevenClicked() {
            
            if (validateInteger(document.getElementById('MainContent_txtWindowHeightVinyl')) && //height is a valid integer
                validateInteger(document.getElementById('MainContent_txtWindowAsIfHeightVinyl')) && //as-if height is a valid integer
                validateInteger(document.getElementById('MainContent_txtWindowWidthVinyl'))) { //width is a valid integer

                getHeightAndWidthOfEachVent(true);
                
                document.getElementById('MainContent_txtWindowTopVentHeightVinyl').value = ventHeight;
                document.getElementById('MainContent_txtWindowBottomVentHeightVinyl').value = ventHeight;

                document.getElementById('MainContent_rowWindowUnevenVentsTopVinyl').style.display = 'inherit';
                document.getElementById('MainContent_rowWindowUnevenVentsBottomVinyl').style.display = 'inherit';
            }
            else {
                //error: please input a valid Height and Build-As-If Height
                alert("enter some numbers you fool!");
                document.getElementById('MainContent_radWindowBottomRadVinyl').checked = true;
            }
        }

        function topOrBottomUnevenClicked(){
            document.getElementById('MainContent_txtWindowTopVentHeightVinyl').value = '';
            document.getElementById('MainContent_txtWindowBottomVentHeightVinyl').value = '';

            document.getElementById('MainContent_rowWindowUnevenVentsTopVinyl').style.display = 'none';
            document.getElementById('MainContent_rowWindowUnevenVentsBottomVinyl').style.display = 'none';
        }

        function unevenVentsChecked(checked) {
            if (checked) {
                document.getElementById('MainContent_rowWindowAsIfHeightVinyl').style.display = 'inherit';
                document.getElementById('MainContent_rowWindowTopBottomBothRadVinyl').style.display = 'inherit';

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
                    document.getElementById('MainContent_row' + i + 'WindowTintVinyl').style.display = 'inherit';
                }
            }

            if (tintValue == "Mixed") {
                for (var i = 0; i < 4; i++) {
                    document.getElementById('MainContent_row' + i + 'WindowTintVinyl').style.display = 'none';
                }
                for (var i = 0; i < vinylRows; i++) {
                    document.getElementById('MainContent_row' + i + 'WindowTintVinyl').style.display = 'inherit';
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

            if (checked) {
                document.getElementById('MainContent_rowWindowScreenOptionsVinyl').style.display = 'inherit';
                //document.getElementById('MainContent_
            }
            else
                document.getElementById('MainContent_rowWindowScreenOptionsVinyl').style.display = 'none';
        }

        function windowStyleChanged(dropdownValue) {
            if (dropdownValue === "Vertical 4 Track" ||
                dropdownValue === "Horizontal 2 Track" || 
                dropdownValue === "Horizontal 3 Track" || 
                dropdownValue === "Horizontal 4 Track") {
                    
                document.getElementById('MainContent_rowWindowHeight' + type).style.display = 'inherit';
                document.getElementById('MainContent_rowWindowLeftHeight' + type).style.display = 'none';
                document.getElementById('MainContent_rowWindowRightHeight' + type).style.display = 'none';

                if (dropdownValue === "Vertical 4 Track") {
                    document.getElementById('MainContent_rowWindowInsideMount' + type).style.display = 'inherit';
                    document.getElementById('MainContent_rowWindowOutsideMount' + type).style.display = 'inherit';
                    document.getElementById('MainContent_cellWindowUnevenVents' + type).style.display = 'inherit';
                    document.getElementById('MainContent_cellWindowSpreaderBar' + type).style.display = 'inherit';
                    document.getElementById('MainContent_rowWindowV4TNumberOfVents' + type).style.display = 'inherit';
                    document.getElementById('MainContent_rowWindowH4TNumberOfVents' + type).style.display = 'none';
                    document.getElementById('MainContent_rowWindowTint' + type).style.display = 'inherit';
                    document.getElementById('MainContent_rowWindowTintNoMixed' + type).style.display = 'none';
                }
                else if (dropdownValue === "Horizontal 2 Track" ||
                         dropdownValue === "Horizontal 4 Track") {
                    document.getElementById('MainContent_rowWindowInsideMount' + type).style.display = 'none';
                    document.getElementById('MainContent_rowWindowOutsideMount' + type).style.display = 'none';
                    document.getElementById('MainContent_cellWindowUnevenVents' + type).style.display = 'none';
                    document.getElementById('MainContent_cellWindowSpreaderBar' + type).style.display = 'inherit';
                    document.getElementById('MainContent_rowWindowV4TNumberOfVents' + type).style.display = 'none';
                    document.getElementById('MainContent_rowWindowScreenOptions' + type).style.display = 'inherit';
                    document.getElementById('MainContent_rowWindowTint' + type).style.display = 'none';
                    document.getElementById('MainContent_rowWindowTintNoMixed' + type).style.display = 'inherit';
                    document.getElementById('MainContent_rowWindowTopBottomBothRad' + type).style.display = 'none';
                    document.getElementById('MainContent_rowWindowAsIfHeight' + type).style.display = 'none';
                    document.getElementById('MainContent_txtWindowTopVentHeight' + type).value = '';
                    document.getElementById('MainContent_txtWindowBottomVentHeight' + type).value = '';
                    document.getElementById('MainContent_rowWindowUnevenVentsTop' + type).style.display = 'none';
                    document.getElementById('MainContent_rowWindowUnevenVentsBottom' + type).style.display = 'none';
                }
            }
            else if (dropdownValue == 'Vinyl Trapezoid' || dropdownValue == 'Vinyl Fixed Lite') {

                for (var i = 0; i < 4; i++)
                    document.getElementById('MainContent_row' + i + 'WindowTint' + type).style.display = 'none';

                document.getElementById('MainContent_rowWindowTint' + type).style.display = 'none';
                document.getElementById('MainContent_rowWindowTintNoMixed' + type).style.display = 'inherit';
                document.getElementById('MainContent_rowWindowTopBottomBothRad' + type).style.display = 'none';
                document.getElementById('MainContent_rowWindowAsIfHeight' + type).style.display = 'none';
                document.getElementById('MainContent_txtWindowTopVentHeight' + type).value = '';
                document.getElementById('MainContent_txtWindowBottomVentHeight' + type).value = '';
                document.getElementById('MainContent_rowWindowUnevenVentsTop' + type).style.display = 'none';
                document.getElementById('MainContent_rowWindowUnevenVentsBottom' + type).style.display = 'none';
                document.getElementById('MainContent_rowWindowHeight' + type).style.display = 'inherit';
                document.getElementById('MainContent_rowWindowLeftHeight' + type).style.display = 'none';
                document.getElementById('MainContent_rowWindowRightHeight' + type).style.display = 'none';


                if (dropdownValue == 'Vinyl Trapezoid') {
                    document.getElementById('MainContent_rowWindowHeight' + type).style.display = 'none';
                    document.getElementById('MainContent_rowWindowLeftHeight' + type).style.display = 'inherit';
                    document.getElementById('MainContent_rowWindowRightHeight' + type).style.display = 'inherit';
                }
                else {
                    document.getElementById('MainContent_rowWindowHeight' + type).style.display = 'inherit';
                    document.getElementById('MainContent_rowWindowLeftHeight' + type).style.display = 'none';
                    document.getElementById('MainContent_rowWindowRightHeight' + type).style.display = 'none';
                }

                document.getElementById('MainContent_rowWindowScreenOptions' + type).style.display = 'none';
                document.getElementById('MainContent_rowWindowInsideMount' + type).style.display = 'none';
                document.getElementById('MainContent_rowWindowOutsideMount' + type).style.display = 'none';
                document.getElementById('MainContent_cellWindowUnevenVents' + type).style.display = 'none';
                document.getElementById('MainContent_rowWindowUnevenVentsTop' + type).style.display = 'none';
                document.getElementById('MainContent_txtWindowTopVentHeight' + type).value = '';
                document.getElementById('MainContent_rowWindowUnevenVentsBottom' + type).style.display = 'none';
                document.getElementById('MainContent_txtWindowBottomVentHeight' + type).value = '';
                document.getElementById('MainContent_cellWindowSpreaderBar' + type).style.display = 'none';
                document.getElementById('MainContent_rowWindowTint' + type).style.display = 'none';
                document.getElementById('MainContent_rowWindowV4TNumberOfVents' + type).style.display = 'none';
                document.getElementById('MainContent_rowWindowH4TNumberOfVents' + type).style.display = 'none';
            }
        }
        //        //else, perform block
        //    //else if (type === "Glass") {
        //    //    document.getElementById('MainContent_rowWindowTint' + type).style.display = 'inherit';

        //        if (dropdownValue == 'Aluminum Framed Trapezoid' || dropdownValue == 'PVC Framed Single Glazed Trapezoid') {
        //            document.getElementById('MainContent_rowWindowHeight' + type).style.display = 'none';
        //            document.getElementById('MainContent_rowWindowLeftHeight' + type).style.display = 'inherit';
        //            document.getElementById('MainContent_rowWindowRightHeight' + type).style.display = 'inherit';
        //        }
        //        //else {
        //        //    document.getElementById('MainContent_rowWindowHeight' + type).style.display = 'inherit';
        //        //    document.getElementById('MainContent_rowWindowLeftHeight' + type).style.display = 'none';
        //        //    document.getElementById('MainContent_rowWindowRightHeight' + type).style.display = 'none';
        //        //}
            
        //    else {
        //        document.getElementById('MainContent_rowWindowInsideMount' + type).style.display = 'none';
        //        document.getElementById('MainContent_rowWindowOutsideMount' + type).style.display = 'none';
        //        document.getElementById('MainContent_cellWindowUnevenVents' + type).style.display = 'none';
        //        document.getElementById('MainContent_rowWindowUnevenVentsTop' + type).style.display = 'none';
        //        document.getElementById('MainContent_txtWindowTopVentHeight' + type).value = '';
        //        document.getElementById('MainContent_rowWindowUnevenVentsBottom' + type).style.display = 'none';
        //        document.getElementById('MainContent_txtWindowBottomVentHeight' + type).value = '';
        //        document.getElementById('MainContent_rowWindowTint' + type).style.display = 'none';
        //        document.getElementById('MainContent_rowWindowV4TNumberOfVents' + type).style.display = 'none';
        //        document.getElementById('MainContent_rowWindowH4TNumberOfVents' + type).style.display = 'none';
        //        document.getElementById('MainContent_rowWindowScreenOptions' + type).style.display = 'none';
        //        document.getElementById('MainContent_cellWindowSpreaderBar' + type).style.display = 'none';
        //        document.getElementById('MainContent_rowWindowTintNoMixed' + type).style.display = 'none';
        //        document.getElementById('MainContent_rowWindowTopBottomBothRad' + type).style.display = 'none';
        //        document.getElementById('MainContent_rowWindowAsIfHeight' + type).style.display = 'none';
        //    }

        //}

        //function validateUnevenVents(size) {

        //    size += ''; //covert the given number to string
        //    var decimal = size.split("."); //split the number at the decimal point
        //    decimal[1] = "0." + decimal[1]; //add "0." to the decimal values to make a valid decimal number

        //    /******************************/
        //    //these constants below will have to be 
        //    //moved to a constants file, or at least
        //    //have global scope within this file.
        //    var ONE_SIXTEENTH = 0.1667;
        //    var TWO_SIXTEENTH = 0.125;
        //    var THREE_SIXTEENTH = 0.1875;
        //    var FOUR_SIXTEENTH = 0.25;
        //    var FIVE_SIXTEENTH = 0.3125;
        //    var SIX_SIXTEENTH = 0.375;
        //    var SEVEN_SIXTEENTH = 0.4375;
        //    var EIGHT_SIXTEENTH = 0.5;
        //    var NINE_SIXTEENTH = 0.5625;
        //    var TEN_SIXTEENTH = 0.625;
        //    var ELEVEN_SIXTEENTH = 0.6875;
        //    var TWELVE_SIXTEENTH = 0.75;
        //    var THIRTEEN_SIXTEENTH = 0.8125;
        //    var FOURTEEN_SIXTEENTH = 0.875;
        //    var FIFTEEN_SIXTEENTH = 0.9375;
        //    /******************************/

        //    //reset the decimal value if its not exactly an eighth
        //    //round it down to the nearest eighth
        //    decimal[1] = (decimal[1] >= FIFTEEN_SIXTEENTH) ? FIFTEEN_SIXTEENTH :
        //        (decimal[1] >= FOURTEEN_SIXTEENTH) ? FOURTEEN_SIXTEENTH :
        //        (decimal[1] >= THIRTEEN_SIXTEENTH) ? THIRTEEN_SIXTEENTH :
        //        (decimal[1] >= TWELVE_SIXTEENTH) ? TWELVE_SIXTEENTH :
        //        (decimal[1] >= ELEVEN_SIXTEENTH) ? ELEVEN_SIXTEENTH :
        //        (decimal[1] >= TEN_SIXTEENTH) ? TEN_SIXTEENTH :
        //        (decimal[1] >= NINE_SIXTEENTH) ? NINE_SIXTEENTH :
        //        (decimal[1] >= EIGHT_SIXTEENTH) ? EIGHT_SIXTEENTH :
        //        (decimal[1] >= SEVEN_SIXTEENTH) ? SEVEN_SIXTEENTH :
        //        (decimal[1] >= SIX_SIXTEENTH) ? SIX_SIXTEENTH :
        //        (decimal[1] >= FIVE_SIXTEENTH) ? FIVE_SIXTEENTH :
        //        (decimal[1] >= FOUR_SIXTEENTH) ? FOUR_SIXTEENTH :
        //        (decimal[1] >= THREE_SIXTEENTH) ? THREE_SIXTEENTH :
        //        (decimal[1] >= TWO_SIXTEENTH) ? TWO_SIXTEENTH :
        //        (decimal[1] >= ONE_SIXTEENTH) ? ONE_SIXTEENTH : 0;

        //    return decimal; //return the corrected decimal value as an array of two elements, 0: value before the decimal, 1: value after the decimal

        //    ///add uneven vents validation code here

        //}

        /**
        *windowStyle
        *Window style function is triggered when the user selects Vertical Four Track, 
        *vinyl tint becomes displayed, since Vertical Four Track is the only window style
        *that has vinyl tint options
        *@param type - holds the type of window selected (i.e. Cabana, French, Patio, Opening Only (No Window));
        *@param wallNumber - holds an integer to know which wall is currently being affected
        */
        function windowStyleChanged(type, dropdownValue) {

            //var windowStyleDDL = document.getElementById('MainContent_ddlWindowStyle' + type).options[document.getElementById('MainContent_ddlWindowStyle' + type).selectedIndex].value;

            if (type === "Vinyl") {

                //Get value of window style drop down
                //var windowTintsDDL = document.getElementById('MainContent_ddlWindowTint' + type).options[document.getElementById('MainContent_ddlWindowTint' + type).selectedIndex].value;
                //var windowVentsDDL = document.getElementById('MainContent_ddlWindowV4TNumberOfVents' + type).options[document.getElementById('MainContent_ddlWindowV4TNumberOfVents' + type).selectedIndex].value;
                var vinylRows = (windowVentsDDL == 12) ? 4 :
                                (windowVentsDDL == 9) ? 3 :
                                (windowVentsDDL == 8) ? 4 :
                                (windowVentsDDL == 6) ? 3 :
                                (windowVentsDDL == 4) ? 4 : 3;

                var tempVents;

                if (dropdownValue === "Vertical 4 Track" ||
                    dropdownValue === "Horizontal 2 Track" || 
                    dropdownValue === "Horizontal 3 Track" || 
                    dropdownValue === "Horizontal 4 Track") {
                    
                    document.getElementById('MainContent_rowWindowHeight' + type).style.display = 'inherit';
                    document.getElementById('MainContent_rowWindowLeftHeight' + type).style.display = 'none';
                    document.getElementById('MainContent_rowWindowRightHeight' + type).style.display = 'none';

                    if (dropdownValue === "Vertical 4 Track") {
                        document.getElementById('MainContent_rowWindowInsideMount' + type).style.display = 'inherit';
                        document.getElementById('MainContent_rowWindowOutsideMount' + type).style.display = 'inherit';
                        document.getElementById('MainContent_cellWindowUnevenVents' + type).style.display = 'inherit';
                        document.getElementById('MainContent_cellWindowSpreaderBar' + type).style.display = 'inherit';
                        document.getElementById('MainContent_rowWindowV4TNumberOfVents' + type).style.display = 'inherit';
                        document.getElementById('MainContent_rowWindowH4TNumberOfVents' + type).style.display = 'none';
                        document.getElementById('MainContent_rowWindowTint' + type).style.display = 'inherit';
                        document.getElementById('MainContent_rowWindowTintNoMixed' + type).style.display = 'none';

                        windowVentsDDL = document.getElementById('MainContent_ddlWindowV4TNumberOfVents' + type).options[document.getElementById('MainContent_ddlWindowV4TNumberOfVents' + type).selectedIndex].value;
                        vinylRows = (windowVentsDDL == 12) ? 4 :
                                (windowVentsDDL == 9) ? 3 :
                                (windowVentsDDL == 8) ? 4 :
                                (windowVentsDDL == 6) ? 3 :
                                (windowVentsDDL == 4) ? 4 : 3;


                        if (tempVents != windowVentsDDL) {
                            tempVents = windowVentsDDL;
                            for (var i = 0; i < 4; i++) {
                                document.getElementById('MainContent_row' + i + 'WindowTint' + type).style.display = 'none';
                            }
                            for (var i = 0; i < vinylRows; i++) {
                                document.getElementById('MainContent_row' + i + 'WindowTint' + type).style.display = 'inherit';
                            }
                        }

                        if (windowTintsDDL == "Mixed") {
                            for (var i = 0; i < 4; i++) {
                                document.getElementById('MainContent_row' + i + 'WindowTint' + type).style.display = 'none';
                            }
                            for (var i = 0; i < vinylRows; i++) {
                                document.getElementById('MainContent_row' + i + 'WindowTint' + type).style.display = 'inherit';
                            }
                        }
                        else {
                            for (var i = 0; i < 4; i++) {
                                document.getElementById('MainContent_row' + i + 'WindowTint' + type).style.display = 'none';
                            }
                        }
                    }
                    else if (dropdownValue === "Horizontal 2 Track" ||
                             dropdownValue === "Horizontal 4 Track") {
                        document.getElementById('MainContent_rowWindowInsideMount' + type).style.display = 'none';
                        document.getElementById('MainContent_rowWindowOutsideMount' + type).style.display = 'none';
                        document.getElementById('MainContent_cellWindowUnevenVents' + type).style.display = 'none';
                        document.getElementById('MainContent_cellWindowSpreaderBar' + type).style.display = 'inherit';
                        document.getElementById('MainContent_rowWindowV4TNumberOfVents' + type).style.display = 'none';
                        document.getElementById('MainContent_rowWindowScreenOptions' + type).style.display = 'inherit';
                        document.getElementById('MainContent_rowWindowTint' + type).style.display = 'none';
                        document.getElementById('MainContent_rowWindowTintNoMixed' + type).style.display = 'inherit';
                        document.getElementById('MainContent_rowWindowTopBottomBothRad' + type).style.display = 'none';
                        document.getElementById('MainContent_rowWindowAsIfHeight' + type).style.display = 'none';
                        document.getElementById('MainContent_txtWindowTopVentHeight' + type).value = '';
                        document.getElementById('MainContent_txtWindowBottomVentHeight' + type).value = '';
                        document.getElementById('MainContent_rowWindowUnevenVentsTop' + type).style.display = 'none';
                        document.getElementById('MainContent_rowWindowUnevenVentsBottom' + type).style.display = 'none';

                        if (dropdownValue === "Horizontal 2 Track") {
                            windowVentsDDL = vinylRows = 2;
                            document.getElementById('MainContent_rowWindowH4TNumberOfVents' + type).style.display = 'none';
                        }  
                        else if (dropdownValue === "Horizontal 4 Track") {
                            document.getElementById('MainContent_rowWindowH4TNumberOfVents' + type).style.display = 'inherit';
                            windowVentsDDL = vinylRows = document.getElementById('MainContent_ddlWindowH4TNumberOfVents' + type).options[document.getElementById('MainContent_ddlWindowH4TNumberOfVents' + type).selectedIndex].value;
                        }

                        for (var i = 0; i < 4; i++) 
                            document.getElementById('MainContent_row' + i + 'WindowTint' + type).style.display = 'none';

                    }
                    else {
                        document.getElementById('MainContent_rowWindowInsideMount' + type).style.display = 'none';
                        document.getElementById('MainContent_rowWindowOutsideMount' + type).style.display = 'none';
                        document.getElementById('MainContent_cellWindowUnevenVents' + type).style.display = 'none';
                        document.getElementById('MainContent_cellWindowSpreaderBar' + type).style.display = 'none';
                        document.getElementById('MainContent_rowWindowV4TNumberOfVents' + type).style.display = 'none';
                        document.getElementById('MainContent_rowWindowH4TNumberOfVents' + type).style.display = 'none';
                        document.getElementById('MainContent_rowWindowAsIfHeight' + type).style.display = 'none';
                        document.getElementById('MainContent_txtWindowTopVentHeight' + type).value = '';
                        document.getElementById('MainContent_txtWindowBottomVentHeight' + type).value = '';
                        document.getElementById('MainContent_rowWindowUnevenVentsTop' + type).style.display = 'none';
                        document.getElementById('MainContent_rowWindowUnevenVentsBottom' + type).style.display = 'none';
                    }
                }
                else if (dropdownValue == 'Vinyl Trapezoid' || dropdownValue == 'Vinyl Fixed Lite') {

                    for (var i = 0; i < 4; i++)
                        document.getElementById('MainContent_row' + i + 'WindowTint' + type).style.display = 'none';

                    document.getElementById('MainContent_rowWindowTint' + type).style.display = 'none';
                    document.getElementById('MainContent_rowWindowTintNoMixed' + type).style.display = 'inherit';
                    document.getElementById('MainContent_rowWindowTopBottomBothRad' + type).style.display = 'none';
                    document.getElementById('MainContent_rowWindowAsIfHeight' + type).style.display = 'none';
                    document.getElementById('MainContent_txtWindowTopVentHeight' + type).value = '';
                    document.getElementById('MainContent_txtWindowBottomVentHeight' + type).value = '';
                    document.getElementById('MainContent_rowWindowUnevenVentsTop' + type).style.display = 'none';
                    document.getElementById('MainContent_rowWindowUnevenVentsBottom' + type).style.display = 'none';
                    document.getElementById('MainContent_rowWindowHeight' + type).style.display = 'inherit';
                    document.getElementById('MainContent_rowWindowLeftHeight' + type).style.display = 'none';
                    document.getElementById('MainContent_rowWindowRightHeight' + type).style.display = 'none';


                    if (dropdownValue == 'Vinyl Trapezoid') {
                        document.getElementById('MainContent_rowWindowHeight' + type).style.display = 'none';
                        document.getElementById('MainContent_rowWindowLeftHeight' + type).style.display = 'inherit';
                        document.getElementById('MainContent_rowWindowRightHeight' + type).style.display = 'inherit';
                    }
                    else {
                        document.getElementById('MainContent_rowWindowHeight' + type).style.display = 'inherit';
                        document.getElementById('MainContent_rowWindowLeftHeight' + type).style.display = 'none';
                        document.getElementById('MainContent_rowWindowRightHeight' + type).style.display = 'none';
                    }

                    document.getElementById('MainContent_rowWindowScreenOptions' + type).style.display = 'none';
                    document.getElementById('MainContent_rowWindowInsideMount' + type).style.display = 'none';
                    document.getElementById('MainContent_rowWindowOutsideMount' + type).style.display = 'none';
                    document.getElementById('MainContent_cellWindowUnevenVents' + type).style.display = 'none';
                    document.getElementById('MainContent_rowWindowUnevenVentsTop' + type).style.display = 'none';
                    document.getElementById('MainContent_txtWindowTopVentHeight' + type).value = '';
                    document.getElementById('MainContent_rowWindowUnevenVentsBottom' + type).style.display = 'none';
                    document.getElementById('MainContent_txtWindowBottomVentHeight' + type).value = '';
                    document.getElementById('MainContent_cellWindowSpreaderBar' + type).style.display = 'none';
                    document.getElementById('MainContent_rowWindowTint' + type).style.display = 'none';
                    document.getElementById('MainContent_rowWindowV4TNumberOfVents' + type).style.display = 'none';
                    document.getElementById('MainContent_rowWindowH4TNumberOfVents' + type).style.display = 'none';
                }
                    //else, perform block
                else {
                    document.getElementById('MainContent_rowWindowInsideMount' + type).style.display = 'none';
                    document.getElementById('MainContent_rowWindowOutsideMount' + type).style.display = 'none';
                    document.getElementById('MainContent_cellWindowUnevenVents' + type).style.display = 'none';
                    document.getElementById('MainContent_rowWindowUnevenVentsTop' + type).style.display = 'none';
                    document.getElementById('MainContent_txtWindowTopVentHeight' + type).value = '';
                    document.getElementById('MainContent_rowWindowUnevenVentsBottom' + type).style.display = 'none';
                    document.getElementById('MainContent_txtWindowBottomVentHeight' + type).value = '';
                    document.getElementById('MainContent_rowWindowTint' + type).style.display = 'none';
                    document.getElementById('MainContent_rowWindowV4TNumberOfVents' + type).style.display = 'none';
                    document.getElementById('MainContent_rowWindowH4TNumberOfVents' + type).style.display = 'none';
                    document.getElementById('MainContent_rowWindowScreenOptions' + type).style.display = 'none';
                    document.getElementById('MainContent_cellWindowSpreaderBar' + type).style.display = 'none';
                    document.getElementById('MainContent_rowWindowTintNoMixed' + type).style.display = 'none';
                    document.getElementById('MainContent_rowWindowTopBottomBothRad' + type).style.display = 'none';
                    document.getElementById('MainContent_rowWindowAsIfHeight' + type).style.display = 'none';
                }
            }
            else if (type === "Glass") {
                document.getElementById('MainContent_rowWindowTint' + type).style.display = 'inherit';

                if (dropdownValue == 'Aluminum Framed Trapezoid' || dropdownValue == 'PVC Framed Single Glazed Trapezoid') {
                    document.getElementById('MainContent_rowWindowHeight' + type).style.display = 'none';
                    document.getElementById('MainContent_rowWindowLeftHeight' + type).style.display = 'inherit';
                    document.getElementById('MainContent_rowWindowRightHeight' + type).style.display = 'inherit';
                }
                else {
                    document.getElementById('MainContent_rowWindowHeight' + type).style.display = 'inherit';
                    document.getElementById('MainContent_rowWindowLeftHeight' + type).style.display = 'none';
                    document.getElementById('MainContent_rowWindowRightHeight' + type).style.display = 'none';
                }

            }
            else {
                document.getElementById('MainContent_rowWindowTint' + type).style.display = 'none';
            }

        }
        /**
        *typeOfRowsDisplayed
        *This function finds which type of window is selected and displays the appropriate fields
        *from a table hidden from the user
        *@param type - gets the type of window selected (i.e. Cabana, French, Patio, Opening Only (No Window))
        *@param wallNumber - holds an integer to know which wall is currently being affected
        */
        function typeRowsDisplayed(type) {

            /****START:TABLE ROWS BY ID****/
            var windowTitle = document.getElementById("MainContent_rowWindowTitle" + type);
            var windowStyleTable = document.getElementById("MainContent_rowWindowStyle" + type);
            var windowTint = document.getElementById("MainContent_rowWindowTint" + type);
            //var windowNumberOfVents = document.getElementById("MainContent_rowWindowNumberOfVents" + type);
            var windowColour = document.getElementById("MainContent_rowWindowColour" + type);
            var windowHeight = document.getElementById("MainContent_rowWindowHeight" + type);
            var windowWidth = document.getElementById("MainContent_rowWindowWidth" + type);
            var windowScreenOptions = document.getElementById("MainContent_rowWindowScreenOptions" + type);
            
            /****END:TABLE ROWS BY ID****/

            //If type is Cabana, display the appropriate fields
            if (type == "Vinyl") {
                /****FIELDS TO DISPLAY****/
                //General
                windowTitle.style.display = "inherit";
                windowStyleTable.style.display = "inherit";
                windowColour.style.display = "inherit";
                windowHeight.style.display = "inherit";
                windowWidth.style.display = "inherit";

                windowStyleChanged(document.getElementById('MainContent_ddlWindowStyle' + type).options[document.getElementById('MainContent_ddlWindowStyle' + type).selectedIndex].value);
            }
                //If type is French, display the appropriate fields
            else if (type == "Glass") {

                //General
                windowTitle.style.display = "inherit";
                windowStyleTable.style.display = "inherit";
                windowColour.style.display = "inherit";
                windowHeight.style.display = "inherit";
                windowWidth.style.display = "inherit";

                windowStyle(type);
            }
                //If type is Patio, display the appropriate fields
            else if (type == "Screen") {

                windowTitle.style.display = "inherit";
                windowStyleTable.style.display = "inherit";
                windowColour.style.display = "inherit";
                windowHeight.style.display = "inherit";
                windowWidth.style.display = "inherit";

                windowGlassTint.style.display = "inherit";
                windowScreenOptions.style.display = "inherit";

                windowStyle(type);
            }
                //If type is NoWindow, display the appropriate fields
            
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
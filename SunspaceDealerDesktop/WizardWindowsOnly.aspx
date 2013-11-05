<%@ Page Title="New Project - Windows Only" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WizardWindowsOnly.aspx.cs" Inherits="SunspaceDealerDesktop.WizardWindowsOnly" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">    
    <script src="Scripts/GlobalFunctions.js"></script>
    <script src="Scripts/Validation.js"></script>
    <script>

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
                //Else, perform block
            else {
                //Set display style of respective row to "none"
                document.getElementById('MainContent_rowWindowCustom' + dimension + type).style.display = 'none';
            }
        }


        function validateUnevenVents() {

            ///add uneven vents validation code here

        }

        /**
        *windowStyle
        *Window style function is triggered when the user selects Vertical Four Track, 
        *vinyl tint becomes displayed, since Vertical Four Track is the only window style
        *that has vinyl tint options
        *@param type - holds the type of window selected (i.e. Cabana, French, Patio, Opening Only (No Window));
        *@param wallNumber - holds an integer to know which wall is currently being affected
        */
        function windowStyle(type) {

            var windowStyleDDL = document.getElementById('MainContent_ddlWindowStyle' + type).options[document.getElementById('MainContent_ddlWindowStyle' + type).selectedIndex].value;

            if (type === "Vinyl") {

                //Get value of window style drop down
                var windowVentsDDL = document.getElementById('MainContent_ddlWindowNumberOfVents' + type).options[document.getElementById('MainContent_ddlWindowNumberOfVents' + type).selectedIndex].value;
                var windowTintsDDL = document.getElementById('MainContent_ddlWindowTint' + type).options[document.getElementById('MainContent_ddlWindowTint' + type).selectedIndex].value;
                var vinylRows = (windowVentsDDL == 12) ? 4 :
                                (windowVentsDDL == 9) ? 3 :
                                (windowVentsDDL == 8) ? 4 :
                                (windowVentsDDL == 6) ? 3 :
                                (windowVentsDDL == 4) ? 4 : 3;

                var tempVents;

                if (windowStyleDDL === "Vertical 4 Track" ||
                    windowStyleDDL === "Horizontal 2 Track" || 
                    windowStyleDDL === "Horizontal 3 Track" || 
                    windowStyleDDL === "Horizontal 4 Track") {
                    document.getElementById('MainContent_rowWindowTint' + type).style.display = 'inherit';
                    document.getElementById('MainContent_rowWindowNumberOfVents' + type).style.display = 'inherit';
                    

                    if (windowStyleDDL === "Vertical 4 Track") {
                        document.getElementById('MainContent_rowWindowInsideMount' + type).style.display = 'inherit';
                        document.getElementById('MainContent_rowWindowOutsideMount' + type).style.display = 'inherit';
                        document.getElementById('MainContent_cellWindowUnevenVents' + type).style.display = 'inherit';
                        document.getElementById('MainContent_cellWindowSpreaderBar' + type).style.display = 'inherit';
                        document.getElementById('MainContent_rowWindowNumberOfVents' + type).style.display = 'inherit';

                        windowVentsDDL = document.getElementById('MainContent_ddlWindowNumberOfVents' + type).options[document.getElementById('MainContent_ddlWindowNumberOfVents' + type).selectedIndex].value;
                        vinylRows = (windowVentsDDL == 12) ? 4 :
                                (windowVentsDDL == 9) ? 3 :
                                (windowVentsDDL == 8) ? 4 :
                                (windowVentsDDL == 6) ? 3 :
                                (windowVentsDDL == 4) ? 4 : 3;

                        if (document.getElementById('MainContent_radWindowOutsideMount' + type).checked) {
                            document.getElementById('MainContent_rowWindowScreenOptions' + type).style.display = 'inherit';
                        }
                        else {
                            document.getElementById('MainContent_rowWindowScreenOptions' + type).style.display = 'none';
                        }


                        if (document.getElementById('MainContent_chkWindowUnevenVents' + type).checked) {

                            document.getElementById('MainContent_rowWindowUnevenVentsTop' + type).style.display = 'inherit';
                            document.getElementById('MainContent_rowWindowUnevenVentsBottom' + type).style.display = 'inherit';

                            var sizeOfEachVent = document.getElementById('MainContent_txtWindowHeightVinyl').value / vinylRows;

                            document.getElementById('MainContent_txtWindowTopVentHeight' + type).value = sizeOfEachVent;
                            document.getElementById('MainContent_txtWindowBottomVentHeight' + type).value = sizeOfEachVent;

                            /*
                            if (document.getElementById('MainContent_radWindowUnevenVentsDone' + type).checked) {
                                document.getElementById('MainContent_txtWindowTopVentHeight' + type).readOnly = "readonly";
                                document.getElementById('MainContent_txtWindowBottomVentHeight' + type).readOnly = "readonly";
                                document.getElementById('MainContent_ddlWindowTopVentHeight' + type).disabled = true;
                                document.getElementById('MainContent_ddlWindowBottomVentHeight' + type).disabled = true;

                                validateUnevenVents();
                            }
                            else {
                                document.getElementById('MainContent_txtWindowTopVentHeight' + type).readOnly = "";
                                document.getElementById('MainContent_txtWindowBottomVentHeight' + type).readOnly = "";
                                document.getElementById('MainContent_ddlWindowTopVentHeight' + type).disabled = false;
                                document.getElementById('MainContent_ddlWindowBottomVentHeight' + type).disabled = false;
                            }
                            */
                        }
                        else {
                            document.getElementById('MainContent_rowWindowUnevenVentsTop' + type).style.display = 'none';
                            document.getElementById('MainContent_txtWindowTopVentHeight' + type).value = '';
                            document.getElementById('MainContent_rowWindowUnevenVentsBottom' + type).style.display = 'none';
                            document.getElementById('MainContent_txtWindowBottomVentHeight' + type).value = '';
                        }
                    }
                    else if (windowStyleDDL === "Horizontal 2 Track" ||
                             windowStyleDDL === "Horizontal 3 Track" ||
                             windowStyleDDL === "Horizontal 4 Track") {
                        document.getElementById('MainContent_rowWindowInsideMount' + type).style.display = 'none';
                        document.getElementById('MainContent_rowWindowOutsideMount' + type).style.display = 'none';
                        document.getElementById('MainContent_cellWindowUnevenVents' + type).style.display = 'none';
                        document.getElementById('MainContent_cellWindowSpreaderBar' + type).style.display = 'inherit';
                        document.getElementById('MainContent_rowWindowNumberOfVents' + type).style.display = 'none';
                        document.getElementById('MainContent_rowWindowScreenOptions' + type).style.display = 'inherit';

                        windowVentsDDL = vinylRows = (windowStyleDDL === "Horizontal 2 Track") ? 2 :
                                                     (windowStyleDDL === "Horizontal 3 Track") ? 3 : 4;
                    }
                    else {
                        document.getElementById('MainContent_rowWindowInsideMount' + type).style.display = 'none';
                        document.getElementById('MainContent_rowWindowOutsideMount' + type).style.display = 'none';
                        document.getElementById('MainContent_cellWindowUnevenVents' + type).style.display = 'none';
                        document.getElementById('MainContent_cellWindowSpreaderBar' + type).style.display = 'none';
                        document.getElementById('MainContent_rowWindowNumberOfVents' + type).style.display = 'none';
                    }

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
                else if (windowStyleDDL == 'Vinyl Trapezoid' || windowStyleDDL == 'Vinyl Fixed Lite') {

                    if (windowStyleDDL == 'Vinyl Trapezoid') {
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
                    document.getElementById('MainContent_rowWindowNumberOfVents' + type).style.display = 'none';
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
                    document.getElementById('MainContent_rowWindowNumberOfVents' + type).style.display = 'none';
                    document.getElementById('MainContent_rowWindowScreenOptions' + type).style.display = 'none';
                    document.getElementById('MainContent_cellWindowSpreaderBar' + type).style.display = 'none';
                }
            }
            else if (type === "Glass") {
                document.getElementById('MainContent_rowWindowTint' + type).style.display = 'inherit';

                if (windowStyleDDL == 'Aluminum Framed Trapezoid' || windowStyleDDL == 'PVC Framed Single Glazed Trapezoid') {
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
            var windowNumberOfVents = document.getElementById("MainContent_rowWindowNumberOfVents" + type);
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

                windowStyle(type);
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
                <h2>Door Specifications</h2>
                <asp:PlaceHolder ID="lblWindowPager" runat="server"></asp:PlaceHolder>  
            </div> <%-- end #paging --%>      
        </div>

        <%--<asp:Label ID="lblErrorMessage" CssClass="lblErrorMessage" runat="server" Text="Label">Oh hello, I am an error message.</asp:Label>--%>
        <textarea id="txtErrorMessage" class="txtErrorMessage" disabled="disabled" rows="5" runat="server"></textarea>
    </div>
</asp:Content>
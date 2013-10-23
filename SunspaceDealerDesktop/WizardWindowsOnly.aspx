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

        /**
        *windowStyle
        *Window style function is triggered when the user selects Vertical Four Track, 
        *vinyl tint becomes displayed, since Vertical Four Track is the only window style
        *that has vinyl tint options
        *@param type - holds the type of window selected (i.e. Cabana, French, Patio, Opening Only (No Window));
        *@param wallNumber - holds an integer to know which wall is currently being affected
        */
        function windowStyle(type) {

            //Get value of window style drop down
            var windowStyleDDL = document.getElementById('MainContent_ddlWindowStyle' + type).options[document.getElementById('MainContent_ddlWindowStyle' + type).selectedIndex].value;

            //If drop down value is v4TCabana, perform block
            if (windowStyleDDL == 'Vertical Four Track') {
                //Change window vinyl tint row display style to inherit
                document.getElementById('MainContent_rowWindowVinylTint' + type).style.display = 'inherit';
                //Change window number of vents row display style to inherit
                document.getElementById('MainContent_rowWindowNumberOfVents' + type).style.display = 'inherit';
                //Change window screen options row display style to none
                document.getElementById('MainContent_rowWindowScreenOptions' + type).style.display = 'none';
            }
            else if (windowStyleDDL == 'Full Screen' || windowStyleDDL == 'Screen') {
                //Change window screen options row display style to inherit
                document.getElementById('MainContent_rowWindowScreenOptions' + type).style.display = 'inherit';
                //Change window vinyl tint row display style to none
                document.getElementById('MainContent_rowWindowVinylTint' + type).style.display = 'none';
                //Change window number of vents row display style to inherit
                document.getElementById('MainContent_rowWindowNumberOfVents' + type).style.display = 'none';
            }
                //else, perform block
            else {
                //Change window vinyl tint row display style to none
                document.getElementById('MainContent_rowWindowVinylTint' + type).style.display = 'none';
                //Change window number of vents row display style to inherit
                document.getElementById('MainContent_rowWindowNumberOfVents' + type).style.display = 'none';
                //Change window screen options row display style to none
                document.getElementById('MainContent_rowWindowScreenOptions' + type).style.display = 'none';
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
            var windowVinylTint = document.getElementById("MainContent_rowWindowVinylTint" + type);
            var windowNumberOfVents = document.getElementById("MainContent_rowWindowNumberOfVents" + type);
            var windowKickplate = document.getElementById("MainContent_rowWindowKickplate" + type);
            var windowKicplateCustom = document.getElementById("MainContent_rowWindowCustomKickplate" + type);
            var windowColour = document.getElementById("MainContent_rowWindowColour" + type);
            var windowHeight = document.getElementById("MainContent_rowWindowHeight" + type);
            var windowHeightCustom = document.getElementById("MainContent_rowWindowCustomHeight" + type);
            var windowWidth = document.getElementById("MainContent_rowWindowWidth" + type);
            var windowWidthCustom = document.getElementById("MainContent_rowWindowCustomWidth" + type);
            var windowOperatorLHH = document.getElementById("MainContent_rowWindowOperatorLHH" + type);
            var windowOperatorRHH = document.getElementById("MainContent_rowWindowOperatorRHH" + type);
            var windowBoxHeader = document.getElementById("MainContent_rowWindowBoxHeader" + type);
            var windowGlassTint = document.getElementById("MainContent_rowWindowGlassTint" + type);
            var windowHingeLHH = document.getElementById("MainContent_rowWindowHingeLHH" + type);
            var windowHingeRHH = document.getElementById("MainContent_rowWindowHingeRHH" + type);
            var windowScreenOptions = document.getElementById("MainContent_rowWindowScreenOptions" + type);
            var windowHardware = document.getElementById("MainContent_rowWindowHardware" + type);
            var windowSwingIn = document.getElementById("MainContent_rowWindowSwingIn" + type);
            var windowSwingOut = document.getElementById("MainContent_rowWindowSwingOut" + type);
            var windowPosition = document.getElementById("MainContent_rowWindowPosition" + type);
            var windowPositionCustom = document.getElementById("MainContent_rowWindowCustomPosition" + type);
            /****END:TABLE ROWS BY ID****/

            /****START:RADIO BUTTONS TO BE CHECKED INITIALLY****/
            var windowPositionCustom = document.getElementById("MainContent_ddlWindowPosition" + type).options[document.getElementById("MainContent_ddlWindowPosition" + type).selectedIndex].value;
            var windowHingeLHHChecked = document.getElementById("MainContent_radWindowHinge" + type);
            var windowSwingInChecked = document.getElementById("MainContent_radWindowSwing" + type);

            //FRENCH/PATIO DOOR ONLY
            var windowOperatorLHHChecked = document.getElementById("MainContent_radWindowOperator" + type);
            /****END:RADIO BUTTONS TO BE CHECKED INITIALLY****/

            //If type is Cabana, display the appropriate fields
            if (type == "Cabana") {

                /****FIELDS TO DISPLAY****/
                //General
                windowTitle.style.display = "inherit";
                windowStyleTable.style.display = "inherit";
                windowColour.style.display = "inherit";
                windowHeight.style.display = "inherit";
                windowWidth.style.display = "inherit";
                windowBoxHeader.style.display = "inherit";
                //windowKickplate.style.display = "inherit";

                //Cabana Specific                            
                windowGlassTint.style.display = "inherit";
                windowHingeLHH.style.display = "inherit";
                windowHingeRHH.style.display = "inherit";
                windowSwingIn.style.display = "inherit";
                windowSwingOut.style.display = "inherit";
                windowHardware.style.display = "inherit";
                windowPosition.style.display = "inherit";

                //If the value of position drop down is custom, display the appropriate field
                if (windowPositionCustom == "cPosition") {
                    customDimension(wallNumber, type, "Position");
                }

                //Radio button defaults
                windowHingeLHHChecked.setAttribute("checked", "checked");
                windowSwingInChecked.setAttribute("checked", "checked");

                windowStyle(type);
            }
                //If type is French, display the appropriate fields
            else if (type == "French") {

                //General
                windowTitle.style.display = "inherit";
                windowStyleTable.style.display = "inherit";
                windowColour.style.display = "inherit";
                windowHeight.style.display = "inherit";
                windowWidth.style.display = "inherit";
                windowBoxHeader.style.display = "inherit";
                windowKickplate.style.display = "inherit";

                //French specific
                windowOperatorLHH.style.display = "inherit";
                windowOperatorRHH.style.display = "inherit";
                windowSwingIn.style.display = "inherit";
                windowSwingOut.style.display = "inherit";
                windowHardware.style.display = "inherit";
                windowPosition.style.display = "inherit";

                //If the value of position drop down is custom, display the appropriate field
                if (windowPositionCustom == "cPosition") {
                    customDimension(wallNumber, type, "Position");
                }

                //Radio button defaults
                windowOperatorLHHChecked.setAttribute("checked", "checked");
                windowSwingInChecked.setAttribute("checked", "checked");

                windowStyle(type);
            }
                //If type is Patio, display the appropriate fields
            else if (type == "Patio") {

                //General
                windowTitle.style.display = "inherit";
                windowStyleTable.style.display = "inherit";
                windowColour.style.display = "inherit";
                windowHeight.style.display = "inherit";
                windowWidth.style.display = "inherit";
                windowBoxHeader.style.display = "inherit";

                //Patio Specifics
                windowGlassTint.style.display = "inherit";
                windowOperatorLHH.style.display = "inherit";
                windowOperatorRHH.style.display = "inherit";
                windowPosition.style.display = "inherit";
                windowScreenOptions.style.display = "inherit";

                //If the value of position drop down is custom, display the appropriate field
                if (windowPositionCustom == "cPosition") {
                    customDimension(wallNumber, type, "Position");
                }

                //Radio button defaults
                windowOperatorLHHChecked.setAttribute("checked", "checked");

                windowStyle(type);
            }
                //If type is NoWindow, display the appropriate fields
            else if (type == "NoWindow") {

                windowHeight.style.display = "inherit";
                windowWidth.style.display = "inherit";
                windowPosition.style.display = "inherit";

                //If the value of position drop down is custom, display the appropriate field
                if (windowPositionCustom == "cPosition") {
                    customDimension(wallNumber, type, "Position");
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

                <ul>
                    <!--Div tag to hold the canvas/grid-->
                    <div style="position:inherit; text-align:center; top:0px; right:0px;" id="mySunroom"></div>
                    <%--==================================== --%>


                    <%-- div to display the answers for question 1 --%>
                    <div style="display: block" id="pagerOne">
                        <li>
                            <a href="#" data-slide="#slide1" class="slidePanel">
                                <asp:Label ID="lblCabanaWindow" runat="server" Text="Text"></asp:Label>
                                <asp:Label ID="lblCabanaWindowAnswer" runat="server" Text="Answer"></asp:Label>
                            </a>
                        </li>
                    </div>
                </ul>    
            </div> <%-- end #paging --%>      
        </div>

        <%--<asp:Label ID="lblErrorMessage" CssClass="lblErrorMessage" runat="server" Text="Label">Oh hello, I am an error message.</asp:Label>--%>
        <textarea id="txtErrorMessage" class="txtErrorMessage" disabled="disabled" rows="5" runat="server"></textarea>
    </div>
</asp:Content>
<%@ Page Title="Door Order" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="DoorOnlyOrder.aspx.cs" Inherits="SunspaceDealerDesktop.DoorOnlyOrder" %>
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
                document.getElementById('MainContent_rowDoorVinylTint' + type).style.display = 'inherit';
                //Change door number of vents row display style to inherit
                document.getElementById('MainContent_rowDoorNumberOfVents' + type).style.display = 'inherit';
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
                document.getElementById('MainContent_rowDoorVinylTint' + type).style.display = 'none';
                //Change door number of vents row display style to inherit
                document.getElementById('MainContent_rowDoorNumberOfVents' + type).style.display = 'none';
                //Change door glass tint row display style to none
                document.getElementById('MainContent_rowDoorGlassTint' + type).style.display = 'none';
            }
                //else, perform block
            else {
                //Change door vinyl tint row display style to none
                document.getElementById('MainContent_rowDoorVinylTint' + type).style.display = 'none';
                //Change door number of vents row display style to inherit
                document.getElementById('MainContent_rowDoorNumberOfVents' + type).style.display = 'none';
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
                if ($('#MainContent_ddlDoorNumberOfVents' + type).val() == "2") {
                    document.getElementById('MainContent_row0DoorTint' + type).style.display = "inherit";
                    document.getElementById('MainContent_row1DoorTint' + type).style.display = "inherit";
                    document.getElementById('MainContent_row2DoorTint' + type).style.display = "none";
                    document.getElementById('MainContent_row3DoorTint' + type).style.display = "none";
                }
                else if ($('#MainContent_ddlDoorNumberOfVents' + type).val() == "3") {
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
        *@param type - gets the type of door selected (i.e. Cabana, French, Patio, Opening Only (No Door))
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
                doorVinylTint.style.display = "inherit";

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
                doorVinylTint.style.display = "inherit";

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

        /**
        *addDoor
        *This function is used to add doors to an array of door objects
        *@param title - gets the type of door selected (i.e. Cabana, French, Patio, Opening Only (No Door))
        */
        function addDoor(title) {
            if (title == 'Cabana') {
                var answer = $('#MainContent_ddlDoorStyleCabana').val() + '<br/>';
                answer += $('#MainContent_ddlDoorColourCabana').val() + '<br/>';
                answer += $('#MainContent_ddlDoorHeightCabana').val() + '<br/>';
                answer += $('#MainContent_ddlDoorWidthCabana').val() + '<br/>';
                answer += $('#MainContent_ddlDoorBoxHeaderCabana').val() + '<br/>';
                answer += $('#MainContent_ddlDoorGlassTintCabana').val() + '<br/>';
                if ($('#MainContent_radDoorHingeCabana:checked').val())
                    answer += 'Left<br/>';
                else
                    answer += 'Right<br/>';
                answer += $('#MainContent_ddlDoorScreenTypesCabana').val() + '<br/>';
                answer += $('#MainContent_ddlDoorHardwareCabana').val() + '<br/>';
                if ($('#MainContent_radDoorSwingCabana:checked').val())
                    answer += 'In<br/>';
                else
                    answer += 'Out<br/>';
            }
            else if (title == 'French') {
                var answer = $('#MainContent_ddlDoorStyleFrench').val() + '<br/>';
                answer += $('#MainContent_ddlDoorColourFrench').val() + '<br/>';
                answer += $('#MainContent_ddlDoorHeightFrench').val() + '<br/>';
                answer += $('#MainContent_ddlDoorWidthFrench').val() + '<br/>';
                answer += $('#MainContent_ddlDoorBoxHeaderFrench').val() + '<br/>';
                answer += $('#MainContent_ddlDoorGlassTintFrench').val() + '<br/>';
                if ($('#MainContent_radDoorHingeFrench:checked').val())
                    answer += 'Left<br/>';
                else
                    answer += 'Right<br/>';
                answer += $('#MainContent_ddlDoorScreenTypesFrench').val() + '<br/>';
                answer += $('#MainContent_ddlDoorHardwareFrench').val() + '<br/>';
                if ($('#MainContent_radDoorSwingFrench:checked').val())
                    answer += 'In<br/>';
                else
                    answer += 'Out<br/>';
            }
            else {
                var answer = $('#MainContent_ddlDoorStylePatio').val() + '<br/>';
                answer += $('#MainContent_ddlDoorColourPatio').val() + '<br/>';
                answer += $('#MainContent_ddlDoorHeightPatio').val() + '<br/>';
                answer += $('#MainContent_ddlDoorWidthPatio').val() + '<br/>';
                if ($('#MainContent_lblDoorOperatorLHHPatio:checked').val())
                    answer += 'Left<br/>';
                else
                    answer += 'Right<br/>';
                answer += $('#MainContent_ddlDoorBoxHeaderPatio').val() + '<br/>';
                answer += $('#MainContent_ddlDoorGlassTintPatio').val() + '<br/>';
                if ($('#MainContent_radDoorSwingPatio:checked').val())
                    answer += 'In<br/>';
                else
                    answer += 'Out<br/>';
            }
            $('#MainContent_lblDoor').html(title);
            $('#MainContent_lblDoorAnswer').html(answer);
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
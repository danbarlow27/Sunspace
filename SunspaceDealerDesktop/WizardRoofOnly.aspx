<%@ Page Title="Roof Only Order" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="WizardRoofOnly.aspx.cs" Inherits="SunspaceDealerDesktop.RoofOnlyOrder" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">    
    <script src="Scripts/GlobalFunctions.js"></script>
    <script src="Scripts/Validation.js"></script>

    <script>

        //Validate both dimensions, if there are no errors, recommend number of supports
        function validateDimensions(style) {
            var projectionBool = validateProjection(style);
            var widthBool = validateWidth(style);            

            if (widthBool == true && projectionBool == true) {
                $('#MainContent_txtErrorMessage').val('');
                recommendedSupports(style);
                displayButton('1', style);
            }
        }

        //Validation for width of the roof
        function validateWidth(style) {
            var answer = "";
            if (!$.isNumeric($('#MainContent_txtWidth' + style).val())) {
                answer = 'Please enter a numeric value for Width';
            }
            if (answer == "")
                return true;
            else
                $('#MainContent_txtErrorMessage').html(answer);
        }

        //Validation for projection of the roof
        function validateProjection(style) {
            var answer = "";
            if (style == "Studio") {
                if (!$.isNumeric($('#MainContent_txtProjection' + style).val())) {
                    answer = 'Please enter a numeric value for Projection';
                }
            }
            else {
                if (!$.isNumeric($('#MainContent_txtLeftProjection' + style).val())) {
                    answer = 'Please enter a numeric value for Left Projection';
                }
                else if (!$.isNumeric($('#MainContent_txtRightProjection' + style).val())) {
                    answer = 'Please enter a numeric value for Right Projection';
                }
            }
            if (answer == "")
                return true;
            else
                $('#MainContent_txtErrorMessage').html(answer);
        }

        //Set number of supports to recommended value
        function recommendedSupports(style) {
            var width, projection, projectionLeft, projectionRight, calculationValue, recommendAmount;

            if (style == "Studio") {
                width = $('#MainContent_txtWidth' + style).val();
                projection = $('#MainContent_txtProjection' + style).val();

                calculationValue = width > projection ? width : projection;

                recommendAmount = 2 * calculationValue / (6 * 12);
            }
            else {
                width = $('#MainContent_txtWidth' + style).val();
                projectionLeft = $('#MainContent_txtLeftProjection' + style).val();
                projectionRight = $('#MainContent_txtRightProjection' + style).val();

                calculationValue = width > (projectionLeft + projectionRight) ? width : (projectionLeft + projectionRight);

                recommendAmount = 2 * calculationValue / (6 * 12);
            }

            $('#MainContent_txtNumberOfSupports1' + style).val(Math.ceil(recommendAmount));
            $('#MainContent_txtErrorMessage').val('The recommend amount of supports(' + Math.ceil(recommendAmount) + ') has been inputted into the Number Of Supports field');
        }

        //Displays "Add More Sizes" when the values in the textbox is not 0
        function displayButton(number, style) {
            //If value in the textbox is zero, hide the "Add More Sizes" button
            if ($('#MainContent_txtNumberOfSupports1' + style).val() == '0') {
                document.getElementById('btnAddAnotherSize' + number + style).style.display = "none";
            }
                //If no other LI tags for Number Of Supports are displayed, set the button of the first LI to inherit
            else if (document.getElementById('liNumberOfSupports2' + style).style.display == 'none') {
                document.getElementById('btnAddAnotherSize' + number + style).style.display = "inherit";
            }
        }

        //Display more sizes for supports, changes the css of the LI tags
        function displayMoreSizes(numberToDisplay, style) {
            var number = parseInt(numberToDisplay) - 1;

            //Set display to inherit to show LI tag and hide previous button to add another size
            document.getElementById('liNumberOfSupports' + numberToDisplay + style).style.display="inherit";
            document.getElementById('btnAddAnotherSize' + number.toString() + style).style.display = "none";

            //If the button exist set display to none to hide the button
            if (document.getElementById('btnLessSizes' + number.toString() + style) != null)
                document.getElementById('btnLessSizes' + number.toString() + style).style.display = "none";

            setSelectedIndex(numberToDisplay, style);   //Used to set the selected index of dropdowns being displayed

            disableSelectedIndices(style);              //Used to disable appropriate sizes in all dropdowns being displayed 
            
        }

        //Display less sizes for supports, changes the css of the LI tags
        function displayLessSizes(numberToDisplay, style) {
            var number = parseInt(numberToDisplay) - 1;

            //Set display to none to hide LI tag and show previous button to add another size
            document.getElementById('liNumberOfSupports' + numberToDisplay + style).style.display = "none";
            $('#MainContent_txtNumberOfSupports' + numberToDisplay + style).val('');
            document.getElementById('btnAddAnotherSize' + number.toString() + style).style.display = "inline";

            //If the button exist set display to inline to show the button
            if (document.getElementById('btnLessSizes' + number.toString() + style) != null)
                document.getElementById('btnLessSizes' + number.toString() + style).style.display = "inline";
        }

        //Used to disable appropriate sizes in all dropdowns being displayed 
        function disableSelectedIndices(style) {

            //Loop to remove all disables and set text colour back to black
            for (var i = 1; i <= 4; i++) {
                for (var k = 1; k <= $('#MainContent_ddlRoofSupports1' + style + ' option').size() ; k++) {
                    $('#MainContent_ddlRoofSupports' + i + style + ' :nth-child(' + k + ')').removeAttr('disabled');
                    $('#MainContent_ddlRoofSupports' + i + style + ' :nth-child(' + k + ')').css('color', 'black');
                }
            }

            //Loop through all li tags for number of supports and perform task if li tag is displayed
            for (var i = 1; i <= 4; i++) {

                //Check to see if the number of supports li tag is displayed
                if (document.getElementById('liNumberOfSupports' + i + style).style.display == 'inherit') {

                    //Find the selected index of tags that are displayed
                    var value = $('#MainContent_ddlRoofSupports' + i + style + ' option:selected').index() + 1;
                    console.log('Value: ' + value);
                    //Loop to disable and set text to grey of selected indices of all the drop downs
                    for (var k = 1; k <= $('#MainContent_ddlRoofSupports1' + style + ' option').size() ; k++) {
                        
                        if (k != i) {
                            $('#MainContent_ddlRoofSupports' + k + style + ' :nth-child(' + value + ')').attr('disabled', 'disabled');
                            $('#MainContent_ddlRoofSupports' + k + style + ' :nth-child(' + value + ')').css('color', '#B3B3B3');
                        }
                        
                    }                    

                }

            }            

        }

        //Used to set the selected index of dropdowns being displayed
        function setSelectedIndex(number, style) {
            var newNumber = parseInt(number) - 1;
            
            //Index of previously open not disabled field
            var idx = $('#MainContent_ddlRoofSupports' + newNumber.toString() + style + ' option:not(:disabled):not(:selected)')[0].index;

            //Sets the selected index of the next control based on the index found
            $('#MainContent_ddlRoofSupports' + number + style).prop('selectedIndex', idx);         
        }

    </script>

    <div class="slide-window" id="slide-window" >
        <div class="slide-wrapper">
            <%-- QUESTION 3 - ROOF OPTIONS/DETAILS
            ======================================== --%>

            <div id="slide3" class="slide">
                <h1>
                    <asp:Label ID="lblRoofDetails" runat="server" Text="Roof Details"></asp:Label>
                </h1>        
                              
                <ul class="toggleOptions">
                    <asp:PlaceHolder ID="RoofOptions" runat="server"></asp:PlaceHolder>
                </ul>            

                <asp:Button ID="btnRoof" Enabled="true" CssClass="btnSubmit float-right slidePanel" runat="server" Text="Done"/>

            </div>
            <%-- end #slide3 --%>

         </div>
    </div>

<%-- SLIDE PAGING (QUESTION NAVIGATION)
    ======================================== --%>
    <div id="sidebar">
        <div id="paging-wrapper">    
            <div id="paging"> 
                
                <h2>Notifications and Error Messages</h2>
                
                <ul class="toggleOptions">
                    <asp:PlaceHolder ID="lblRoofPager" runat="server"></asp:PlaceHolder>
                </ul>
            </div> <%-- end #paging --%>      
        </div>

        <textarea id="txtErrorMessage" class="txtErrorMessage" disabled="disabled" rows="5" runat="server"></textarea>
    </div>
</asp:Content>
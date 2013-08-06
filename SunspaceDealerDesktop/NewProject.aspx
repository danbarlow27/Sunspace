<%@ Page Title="New Project - Project Details" EnableEventValidation="false" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewProject.aspx.cs" Inherits="SunspaceDealerDesktop.NewProject" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <script src="Scripts/Validation.js"></script>
  
    <script>
        function goComponents() {
            //changeme when component ordering is put into place
            window.location.replace("Home.aspx");
        }
        function newProjectCheckQuestion1() {
            console.log("onkeyup slide1");
            //disable 'next slide' button until after validation
            document.getElementById('<%=btnQuestion1.ClientID%>').disabled = true;
            //if they select new customer
            if ($('#<%=radNewCustomer.ClientID%>').is(':checked')) {
                //if checked, clear possible pager value from existing
                $('#<%=lblSpecsProjectTypeAnswer.ClientID%>').text("");

                //move textbox data into hidden fields
                document.getElementById("<%=hidCountry.ClientID%>").value = $('#<%=ddlCustomerCountry.ClientID%>').val();
                document.getElementById("<%=hidProvState.ClientID%>").value = $('#<%=ddlCustomerProvState.ClientID%>').val();
                document.getElementById("<%=hidFirstName.ClientID%>").value = $('#<%=txtCustomerFirstName.ClientID%>').val();
                document.getElementById("<%=hidLastName.ClientID%>").value = $('#<%=txtCustomerLastName.ClientID%>').val();
                document.getElementById("<%=hidAddress.ClientID%>").value = $('#<%=txtCustomerAddress.ClientID%>').val();
                document.getElementById("<%=hidCity.ClientID%>").value = $('#<%=txtCustomerCity.ClientID%>').val();
                document.getElementById("<%=hidZip.ClientID%>").value = $('#<%=txtCustomerZip.ClientID%>').val();
                document.getElementById("<%=hidPhone.ClientID%>").value = $('#<%=txtCustomerPhone.ClientID%>').val();
                document.getElementById("<%=hidCell.ClientID%>").value = $('#<%=txtCustomerCell.ClientID%>').val();
                document.getElementById("<%=hidEmail.ClientID%>").value = $('#<%=txtCustomerEmail.ClientID%>').val();
                //blank out existing
                document.getElementById("<%=hidExisting.ClientID%>").value = "";
                
                //Make sure the text boxes aren't blank before manually checking zip/postal and phone
                if (document.getElementById("<%=hidFirstName.ClientID%>").value != "" &&
                    document.getElementById("<%=hidLastName.ClientID%>").value != "" &&
                    document.getElementById("<%=hidAddress.ClientID%>").value != "" &&
                    document.getElementById("<%=hidCity.ClientID%>").value != "" &&
                    document.getElementById("<%=hidEmail.ClientID%>").value != "") {

                    //having troubles checking .value.length, so setting .value into a variable
                    var lengthCheck = document.getElementById("<%=hidPhone.ClientID%>").value;

                    //only check if a full 10digit number is entered
                    if (lengthCheck.length == 10) {
                        //validatePhone function returns an error message, blank if valid
                        var validPhone = validatePhone(document.getElementById("<%=hidPhone.ClientID%>").value);
                    }

                    //having troubles checking .value.length, so setting .value into a variable
                    var lengthCheck = document.getElementById("<%=hidCell.ClientID%>").value;

                    //only check if a full 10digit number is entered
                    if (lengthCheck.length == 10) {
                        //validatePhone function returns an error message, blank if valid
                        var validCell = validatePhone(document.getElementById("<%=hidCell.ClientID%>").value);
                    }

                    //same troubles as before, checking .value.length
                    var zipCode = document.getElementById("<%=hidZip.ClientID%>").value;
                    var isValid = true;

                    //if zip code is not valid numeric, or it is not 5 digits, it is not valid
                    if (!isNaN(zipCode) && zipCode.length == 5) {
                        
                    }
                    else {
                        isValid = false;
                    }

                    //only fully valid if no error message was returned
                    if (validPhone == "") {
                    }
                    else {
                        //invalid phone
                        isValid = false;
                    }
                    
                    //only fully valid if no error message was returned
                    if (validCell == "") {
                    }
                    else {
                        //invalid phone
                        isValid = false;
                    }

                    //check to see if email is valid
                    if (emailValidation() == false)
                    {
                        isValid = false;
                    }

                    //isValid remains true if nothing became false
                    if (isValid == true) {
                        //Set answer to 'new' on side pager and enable button
                        $('#<%=lblSpecsProjectTypeAnswer.ClientID%>').text("New");
                        document.getElementById('pagerOne').style.display = "inline";
                        document.getElementById('<%=btnQuestion1.ClientID%>').disabled = false;
                    }
                }
                else {
                    //error styling or something
                }
            }
                //if they select existing customer
            else if ($('#<%=radExistingCustomer.ClientID%>').is(':checked')) {
                //blank out new customer hiddens, just in case they did it first then came existing after
                document.getElementById("<%=hidFirstName.ClientID%>").value = "";
                document.getElementById("<%=hidLastName.ClientID%>").value = "";
                document.getElementById("<%=hidAddress.ClientID%>").value = "";
                document.getElementById("<%=hidCity.ClientID%>").value = "";
                document.getElementById("<%=hidZip.ClientID%>").value = "";
                document.getElementById("<%=hidPhone.ClientID%>").value = "";
                $('#<%=lblSpecsProjectTypeAnswer.ClientID%>').text("");

                //if selected value from dropdown is not the generic, it is a valid choice
                if (document.getElementById("<%=ddlExistingCustomer.ClientID%>").value != "Choose a Customer...") {
                    //valid, so update pager and enable button
                    $('#<%=lblSpecsProjectTypeAnswer.ClientID%>').text("Existing - " + $('#<%=ddlExistingCustomer.ClientID%>').val());
                    document.getElementById("<%=hidExisting.ClientID%>").value = $('#<%=ddlExistingCustomer.ClientID%>').val();
                    document.getElementById('pagerOne').style.display = "inline";
                    document.getElementById('<%=btnQuestion1.ClientID%>').disabled = false;
                }
            }

            return false;
        }

        function newProjectCheckQuestion2() {
            console.log("onkeyup slide2");
            //disable 'next slide' button until after validation
            document.getElementById('<%=btnQuestion2.ClientID%>').disabled = true;

            //move project name to hidden field
            document.getElementById("<%=hidProjectName.ClientID%>").value = $('#<%=txtProjectName.ClientID%>').val();

            //if its not blank, its valid
            if (document.getElementById("<%=hidProjectName.ClientID%>").value != "") {
                //valid, so update pager and enable button
                $('#<%=lblProjectNameAnswer.ClientID%>').text(document.getElementById("<%=hidProjectName.ClientID%>").value);
                document.getElementById('pagerTwo').style.display = "inline";
                document.getElementById('<%=btnQuestion2.ClientID%>').disabled = false;
            }
            else {
                //error styling or something
            }
            return false;
        }

        function newProjectCheckQuestion3() {
            document.getElementById('<%=btnQuestion3.ClientID%>').disabled = true;

            //if they pick sunroom
            if ($('#<%=radProjectSunroom.ClientID%>').is(':checked')) {
                //They check one of 4 model types
                //update pager, enable button, and update hidden value
                //corresponding to selected model #
                if ($('#<%=radSunroomModel100.ClientID%>').is(':checked')) {
                    document.getElementById("<%=hidModelNumber.ClientID%>").value = "100";
                    document.getElementById('pagerThree').style.display = "inline";
                    document.getElementById('<%=btnQuestion3.ClientID%>').disabled = false;
                }
                else if ($('#<%=radSunroomModel200.ClientID%>').is(':checked')) {
                    document.getElementById("<%=hidModelNumber.ClientID%>").value = "200";
                    document.getElementById('pagerThree').style.display = "inline";
                    document.getElementById('<%=btnQuestion3.ClientID%>').disabled = false;
                }
                else if ($('#<%=radSunroomModel300.ClientID%>').is(':checked')) {
                    document.getElementById("<%=hidModelNumber.ClientID%>").value = "300";
                    document.getElementById('pagerThree').style.display = "inline";
                    document.getElementById('<%=btnQuestion3.ClientID%>').disabled = false;
                }
                else if ($('#<%=radSunroomModel400.ClientID%>').is(':checked')) {
                    document.getElementById("<%=hidModelNumber.ClientID%>").value = "400";
                    document.getElementById('pagerThree').style.display = "inline";
                    document.getElementById('<%=btnQuestion3.ClientID%>').disabled = false;
                }

                //update hidden value for type, and display pager message based on the now
                //two hidden values type and model#
                document.getElementById("<%=hidProjectType.ClientID%>").value = "Sunroom";
                $('#<%=lblProjectTypeAnswer.ClientID%>').text(document.getElementById("<%=hidProjectType.ClientID%>").value + " of Model " + document.getElementById("<%=hidModelNumber.ClientID%>").value);

                //selected sunroom, so hide the walls only button, and re-show the normal button
                document.getElementById('<%=btnQuestion4.ClientID%>').style.display="inline";
                document.getElementById('<%=btnQuestion4Walls.ClientID%>').style.display="none";
            }
            else if ($('#<%=radProjectWalls.ClientID%>').is(':checked')) {
                //They check one of 4 model types
                //update pager, enable button, and update hidden value
                //corresponding to selected model #
                if ($('#<%=radWallsModel100.ClientID%>').is(':checked')) {
                    document.getElementById("<%=hidModelNumber.ClientID%>").value = "100";
                    document.getElementById('pagerThree').style.display = "inline";
                    document.getElementById('<%=btnQuestion3.ClientID%>').disabled = false;
                }
                else if ($('#<%=radWallsModel200.ClientID%>').is(':checked')) {
                    document.getElementById("<%=hidModelNumber.ClientID%>").value = "200";
                    document.getElementById('pagerThree').style.display = "inline";
                    document.getElementById('<%=btnQuestion3.ClientID%>').disabled = false;
                }
                else if ($('#<%=radWallsModel300.ClientID%>').is(':checked')) {
                    document.getElementById("<%=hidModelNumber.ClientID%>").value = "300";
                    document.getElementById('pagerThree').style.display = "inline";
                    document.getElementById('<%=btnQuestion3.ClientID%>').disabled = false;
                }
                else if ($('#<%=radWallsModel400.ClientID%>').is(':checked')) {
                    document.getElementById("<%=hidModelNumber.ClientID%>").value = "400";
                    document.getElementById('pagerThree').style.display = "inline";
                    document.getElementById('<%=btnQuestion3.ClientID%>').disabled = false;
                }                
                //update hidden value for type, and display pager message based on the now
                //two hidden values type and model#
                document.getElementById("<%=hidProjectType.ClientID%>").value = "Walls";
                $('#<%=lblProjectTypeAnswer.ClientID%>').text(document.getElementById("<%=hidProjectType.ClientID%>").value + " of Model " + document.getElementById("<%=hidModelNumber.ClientID%>").value);

                //selected walls, so hide the sunroom button, and re-show the walls button
                document.getElementById('<%=btnQuestion4.ClientID%>').style.display="none";
                document.getElementById('<%=btnQuestion4Walls.ClientID%>').style.display="inline";
            }
            //Now that we know what type of project they have, we can call this function for the colour dropdowns on the next slide
            newProjectChangeColours();
            return false;
        }

        function newProjectCheckQuestion4() {
            document.getElementById('<%=btnQuestion4.ClientID%>').disabled = true;
            //overall error check boolean
            var optionChecksPassed = true;

            //Only run validation if a number is entered and values selected
            if (document.getElementById("<%=txtKneewallHeight.ClientID%>").value != "" &&
                document.getElementById("<%=ddlKneewallType.ClientID%>").value != "") {

                //only requirement on height at this moment is that it is a valid number
                if (isNaN(document.getElementById("<%=txtKneewallHeight.ClientID%>").value)) {
                    //kneewall height error handling
                    optionChecksPassed = false;
                }
                else {
                    //by default, preferences will populate a selected value, but as long as a number is entered, and
                    //dropdowns have a selected value, its valid, set check bool to true, update hidden values
                    document.getElementById("<%=hidKneewallHeight.ClientID%>").value = document.getElementById("<%=txtKneewallHeight.ClientID%>").value;
                    document.getElementById("<%=hidKneewallType.ClientID%>").value = document.getElementById("<%=ddlKneewallType.ClientID%>").value;
                }
            }
            else {
                optionChecksPassed = false;
                //kneewall errors
            }

            //similar checks as above for transom, update hidden values
            if (document.getElementById("<%=txtTransomHeight.ClientID%>").value != "" &&
                document.getElementById("<%=ddlTransomType.ClientID%>").value != "") {

                //if not a number, its invalid, otherwise move to hidden fields
                if (isNaN(document.getElementById("<%=txtTransomHeight.ClientID%>").value)) {
                    console.log("Invalid transom height");
                }
                else {
                    document.getElementById("<%=hidTransomHeight.ClientID%>").value = document.getElementById("<%=txtTransomHeight.ClientID%>").value;
                    document.getElementById("<%=hidTransomType.ClientID%>").value = document.getElementById("<%=ddlTransomType.ClientID%>").value;
                }

            }
            else {
                optionChecksPassed = false;
                //transom error styling
            }

            //make sure skins and colours are selected, update hidden values
            if (document.getElementById("<%=ddlFramingColour.ClientID%>").value != "" &&
                document.getElementById("<%=ddlInteriorColour.ClientID%>").value != "" &&
                document.getElementById("<%=ddlInteriorSkin.ClientID%>").value != "" &&
                document.getElementById("<%=ddlExteriorColour.ClientID%>").value != "" &&
                document.getElementById("<%=ddlExteriorSkin.ClientID%>").value != "") {

                document.getElementById("<%=hidFramingColour.ClientID%>").value = document.getElementById("<%=ddlFramingColour.ClientID%>").value;
                document.getElementById("<%=hidInteriorColour.ClientID%>").value = document.getElementById("<%=ddlInteriorColour.ClientID%>").value;
                document.getElementById("<%=hidInteriorSkin.ClientID%>").value = document.getElementById("<%=ddlInteriorSkin.ClientID%>").value;
                document.getElementById("<%=hidExteriorColour.ClientID%>").value = document.getElementById("<%=ddlExteriorColour.ClientID%>").value;
                document.getElementById("<%=hidExteriorSkin.ClientID%>").value = document.getElementById("<%=ddlExteriorSkin.ClientID%>").value;
            }
            else {
                optionChecksPassed = false;
                //framing error styling
            }

            //if everything was valid it will say =true, so enable button and update pager
            if (optionChecksPassed) {
                document.getElementById('<%=btnQuestion4.ClientID%>').disabled = false;
                document.getElementById('<%=btnQuestion4Walls.ClientID%>').disabled = false;
                $('#<%=lblQuestion4PagerAnswer.ClientID%>').text("Entry Complete");
                document.getElementById('pagerFour').style.display = "inline";
            }

            //When 'walls only' is selected, this will need additional logic to skip the next few slides
            //we'll do this by having a duplicate button in the same spot that goes to the desired slide
            if ($('#<%=radProjectWalls.ClientID%>').is(':checked')) {
                document.getElementById('<%=btnQuestion4.ClientID%>').style.display="none";
                document.getElementById('<%=btnQuestion4Walls.ClientID%>').style.display="inline";
            }
            return false;
        }

        function newProjectCheckQuestion5() {
            document.getElementById('<%=btnQuestion5.ClientID%>').disabled = true;

            //confirm that an answer is selected, and update hidden values, and pager as needed
            if ($('#<%=radFoamProtectedYes.ClientID%>').is(':checked')) {
                document.getElementById('<%=btnQuestion5.ClientID%>').disabled = false;
                $('#<%=lblQuestion5PagerAnswer.ClientID%>').text("Yes");
                document.getElementById('pagerFive').style.display = "inline";
                document.getElementById("<%=hidFoamProtected.ClientID%>").value = "Yes";
            }
            else if ($('#<%=radFoamProtectedNo.ClientID%>').is(':checked')) {
                document.getElementById('<%=btnQuestion5.ClientID%>').disabled = false;
                $('#<%=lblQuestion5PagerAnswer.ClientID%>').text("No");
                document.getElementById('pagerFive').style.display = "inline";
                document.getElementById("<%=hidFoamProtected.ClientID%>").value = "No";
            }
            else {
                //no selection, errors
            }

            return false;
        }

        function newProjectCheckQuestion6() {
            document.getElementById('<%=btnQuestion6.ClientID%>').disabled = true;

            //confirm that an answer is selected, and update hidden values, and pager as needed
            if ($('#<%=radPrefabFloorYes.ClientID%>').is(':checked')) {
                document.getElementById('<%=btnQuestion6.ClientID%>').disabled = false;
                $('#<%=lblQuestion6PagerAnswer.ClientID%>').text("Yes");
                document.getElementById('pagerSix').style.display = "inline";
                document.getElementById("<%=hidPrefabFloor.ClientID%>").value = "Yes";
            }
            else if ($('#<%=radPrefabFloorNo.ClientID%>').is(':checked')) {
                document.getElementById('<%=btnQuestion6.ClientID%>').disabled = false;
                $('#<%=lblQuestion6PagerAnswer.ClientID%>').text("No");
                document.getElementById('pagerSix').style.display = "inline";
                document.getElementById("<%=hidPrefabFloor.ClientID%>").value = "No";
            }
            else {
                //no selection, errors
            }

            return false;
        }

        function newProjectCheckQuestion7() {
            document.getElementById('<%=btnQuestion7.ClientID%>').disabled = true;

            //confirm that an answer is selected, and update hidden values, and pager as needed
            if ($('#<%=radRoofNo.ClientID%>').is(':checked')) {
                document.getElementById('<%=btnQuestion7.ClientID%>').disabled = false;
                $('#<%=lblQuestion7PagerAnswer.ClientID%>').text("None");
                document.getElementById('pagerSeven').style.display = "inline";
                document.getElementById("<%=hidRoof.ClientID%>").value = "No";
            }
            else if ($('#<%=radRoofYes.ClientID%>').is(':checked')) {
                //If they want a roof, they must specify the type of roof
                if ($('#<%=radStudio.ClientID%>').is(':checked')) {
                    document.getElementById('<%=btnQuestion7.ClientID%>').disabled = false;
                    $('#<%=lblQuestion7PagerAnswer.ClientID%>').text("Studio");
                    document.getElementById('pagerSeven').style.display = "inline";
                    document.getElementById("<%=hidRoof.ClientID%>").value = "Yes";
                    document.getElementById("<%=hidRoofType.ClientID%>").value = "Studio";
                }
                else if ($('#<%=radDealerGable.ClientID%>').is(':checked')) {
                    document.getElementById('<%=btnQuestion7.ClientID%>').disabled = false;
                    $('#<%=lblQuestion7PagerAnswer.ClientID%>').text("Dealer Gable");
                    document.getElementById('pagerSeven').style.display = "inline";
                    document.getElementById("<%=hidRoof.ClientID%>").value = "Yes";
                    document.getElementById("<%=hidRoofType.ClientID%>").value = "Dealer Gable";
                }
                else if ($('#<%=radSunspaceGable.ClientID%>').is(':checked')) {
                    document.getElementById('<%=btnQuestion7.ClientID%>').disabled = false;
                    $('#<%=lblQuestion7PagerAnswer.ClientID%>').text("Sunspace Gable");
                    document.getElementById('pagerSeven').style.display = "inline";
                    document.getElementById("<%=hidRoof.ClientID%>").value = "Yes";
                    document.getElementById("<%=hidRoofType.ClientID%>").value = "Sunspace Gable";
                }
                else {
                    //no type selection, errors
                }

                if ($('#<%=txtSoffitLength.ClientID%>').val() == "")
                {

                }
            }
            else {
                //no selection, errors
            }

            return false;
        }

        function newProjectCheckQuestion8() {
            document.getElementById('<%=btnQuestion8.ClientID%>').disabled = true;

            //make sure at least one option is selected, update pager and hidden accordingly
            if ($('#<%=radPreset1.ClientID%>').is(':checked')) {
                document.getElementById('<%=btnQuestion8.ClientID%>').disabled = false;
                $('#<%=lblQuestion8PagerAnswer.ClientID%>').text("Preset 1");
                document.getElementById('pagerEight').style.display = "inline";
                document.getElementById("<%=hidLayoutSelection.ClientID%>").value = "1";
            }
            else if ($('#<%=radPreset2.ClientID%>').is(':checked')) {
                document.getElementById('<%=btnQuestion8.ClientID%>').disabled = false;
                $('#<%=lblQuestion8PagerAnswer.ClientID%>').text("Preset 2");
                document.getElementById('pagerEight').style.display = "inline";
                document.getElementById("<%=hidLayoutSelection.ClientID%>").value = "2";
            }
            else if ($('#<%=radPreset3.ClientID%>').is(':checked')) {
                document.getElementById('<%=btnQuestion8.ClientID%>').disabled = false;
                $('#<%=lblQuestion8PagerAnswer.ClientID%>').text("Preset 3");
                document.getElementById('pagerEight').style.display = "inline";
                document.getElementById("<%=hidLayoutSelection.ClientID%>").value = "3";
            }
            else if ($('#<%=radPreset4.ClientID%>').is(':checked')) {
                document.getElementById('<%=btnQuestion8.ClientID%>').disabled = false;
                $('#<%=lblQuestion8PagerAnswer.ClientID%>').text("Preset 4");
                document.getElementById('pagerEight').style.display = "inline";
                document.getElementById("<%=hidLayoutSelection.ClientID%>").value = "4";
            }
            else if ($('#<%=radPreset5.ClientID%>').is(':checked')) {
                document.getElementById('<%=btnQuestion8.ClientID%>').disabled = false;
                $('#<%=lblQuestion8PagerAnswer.ClientID%>').text("Preset 5");
                document.getElementById('pagerEight').style.display = "inline";
                document.getElementById("<%=hidLayoutSelection.ClientID%>").value = "5";
            }
            else if ($('#<%=radPreset6.ClientID%>').is(':checked')) {
                document.getElementById('<%=btnQuestion8.ClientID%>').disabled = false;
                $('#<%=lblQuestion8PagerAnswer.ClientID%>').text("Preset 6");
                document.getElementById('pagerEight').style.display = "inline";
                document.getElementById("<%=hidLayoutSelection.ClientID%>").value = "6";
            }
            else if ($('#<%=radPreset7.ClientID%>').is(':checked')) {
                document.getElementById('<%=btnQuestion8.ClientID%>').disabled = false;
                $('#<%=lblQuestion8PagerAnswer.ClientID%>').text("Preset 7");
                document.getElementById('pagerEight').style.display = "inline";
                document.getElementById("<%=hidLayoutSelection.ClientID%>").value = "7";
            }
            else if ($('#<%=radPreset8.ClientID%>').is(':checked')) {
                document.getElementById('<%=btnQuestion8.ClientID%>').disabled = false;
                $('#<%=lblQuestion8PagerAnswer.ClientID%>').text("Preset 8");
                document.getElementById('pagerEight').style.display = "inline";
                document.getElementById("<%=hidLayoutSelection.ClientID%>").value = "8";
            }
            else if ($('#<%=radPreset9.ClientID%>').is(':checked')) {
                document.getElementById('<%=btnQuestion8.ClientID%>').disabled = false;
                $('#<%=lblQuestion8PagerAnswer.ClientID%>').text("Preset 9");
                document.getElementById('pagerEight').style.display = "inline";
                document.getElementById("<%=hidLayoutSelection.ClientID%>").value = "9";
            }
            else if ($('#<%=radPreset10.ClientID%>').is(':checked')) {
                document.getElementById('<%=btnQuestion8.ClientID%>').disabled = false;
                $('#<%=lblQuestion8PagerAnswer.ClientID%>').text("Preset 10");
                document.getElementById('pagerEight').style.display = "inline";
                document.getElementById("<%=hidLayoutSelection.ClientID%>").value = "10";
            }
            else if ($('#<%=radPresetC1.ClientID%>').is(':checked')) {
                document.getElementById('<%=btnQuestion8.ClientID%>').disabled = false;
                $('#<%=lblQuestion8PagerAnswer.ClientID%>').text("Custom");
                document.getElementById('pagerEight').style.display = "inline";
                document.getElementById("<%=hidLayoutSelection.ClientID%>").value = "Custom";
            }
            else {
                //no selection, errors
            }

            return false;
        }

        //This function populates and changes the values of the dropdown lists containing framing colours and skins on slide 4
        //It is called for initial population
        function newProjectChangeColours() {
            console.log("new project change colours");
            
            modelNumber = document.getElementById("<%=hidModelNumber.ClientID%>");
            ddlFramingColour = document.getElementById("<%=ddlFramingColour.ClientID%>");
            ddlFramingColour.options.length = 0;

            //var blankOption = new Option("Choose a colour...", "Choose a colour...");
            //ddlFramingColour.options.add(blankOption);

            //Depending on model number we'll have different colours, so we use the corresponding serialized variable for that model's colours
            //retrieving it, and adding its values to the dropdowns
            switch (modelNumber.value) {
                case '100':
                    var anArray =  <%= model100FramingColoursJ %>;

                    for (var i=0;i<anArray.length;i++)
                    {
                        var anOption = new Option(anArray[i], anArray[i]);
                        ddlFramingColour.options.add(anOption);
                    }
                    break;

                case '200':
                    var anArray =  <%= model200FramingColoursJ %>;

                    for (var i=0;i<anArray.length;i++)
                    {
                        var anOption = new Option(anArray[i], anArray[i]);
                        ddlFramingColour.options.add(anOption);
                    }                    
                    break;

                case '300':
                    var anArray =  <%= model300FramingColoursJ %>;

                    for (var i=0;i<anArray.length;i++)
                    {
                        var anOption = new Option(anArray[i], anArray[i]);
                        ddlFramingColour.options.add(anOption);
                    }                    
                    break;

                case '400':
                    var anArray =  <%= model400FramingColoursJ %>;

                    for (var i=0;i<anArray.length;i++)
                    {
                        var anOption = new Option(anArray[i], anArray[i]);
                        ddlFramingColour.options.add(anOption);
                    }   
                    break;
            }
            
            //As this is on the same slide as kneewall and transom, we still need a way to populate those.
            //I didn't want to tack that on to this function, so I just made a new one and called it from here.
            //One function, one purpose.
            newProjectPopulateKneewallTransom();
            return true;
        }

        //this function is called whenever frame colour is changed, and will update the remaining dropdowns for interior/exterior colours and skins
        //corresponding to the chosen frame colour.
        function newProjectCascadeColours() {
            console.log("Cascading Colours");
            ddlFramingColour = document.getElementById("<%= ddlFramingColour.ClientID %>");
            
            if (ddlFramingColour.options[ddlFramingColour.selectedIndex].value == "White")
            {
                $("#<%=ddlInteriorColour.ClientID%>").val('White');
                $("#<%=ddlInteriorSkin.ClientID%>").val('White Aluminum Stucco');
                $("#<%=ddlExteriorColour.ClientID%>").val('White');
                $("#<%=ddlExteriorSkin.ClientID%>").val('White Aluminum Stucco');
            }
            else if (ddlFramingColour.options[ddlFramingColour.selectedIndex].value == "Driftwood")
            {
                $("#<%=ddlInteriorColour.ClientID%>").val('Driftwood');
                $("#<%=ddlInteriorSkin.ClientID%>").val('Driftwood Aluminum Stucco');
                $("#<%=ddlExteriorColour.ClientID%>").val('Driftwood');
                $("#<%=ddlExteriorSkin.ClientID%>").val('Driftwood Aluminum Stucco');
            }
            else if (ddlFramingColour.options[ddlFramingColour.selectedIndex].value == "Bronze")
            {
                $("#<%=ddlInteriorColour.ClientID%>").val('Bronze');
                $("#<%=ddlInteriorSkin.ClientID%>").val('Bronze Aluminum Stucco');
                $("#<%=ddlExteriorColour.ClientID%>").val('Bronze');
                $("#<%=ddlExteriorSkin.ClientID%>").val('Bronze Aluminum Stucco');
            }

            //now that colours have cascaded we still need to validate the slide
            newProjectCheckQuestion4();
        }

        //This function is used for initial population of the transom and kneewall type dropdowns
        function newProjectPopulateKneewallTransom() {
            console.log("populate kneewall transom");
            
            modelNumber = document.getElementById("<%=hidModelNumber.ClientID%>");
            ddlTransomTypes = document.getElementById("<%=ddlTransomType.ClientID%>");
            ddlTransomTypes.options.length = 0;
            
            //var blankOption = new Option("Choose a type...", "Choose a type...");
            //ddlTransomTypes.options.add(blankOption);

            //Like above, types are based on model, and will get the proper variable based on model
            switch (modelNumber.value) {
                case '100':
                    var anArray =  <%= model100TransomTypesJ %>;

                    for (var i=0;i<anArray.length;i++)
                    {
                        var anOption = new Option(anArray[i], anArray[i]);
                        ddlTransomTypes.options.add(anOption);
                    }
                    break;

                case '200':
                    var anArray =  <%= model200TransomTypesJ %>;

                    for (var i=0;i<anArray.length;i++)
                    {
                        var anOption = new Option(anArray[i], anArray[i]);
                        ddlTransomTypes.options.add(anOption);
                    }                    
                    break;

                case '300':
                    var anArray =  <%= model300TransomTypesJ %>;

                    for (var i=0;i<anArray.length;i++)
                    {
                        var anOption = new Option(anArray[i], anArray[i]);
                        ddlTransomTypes.options.add(anOption);
                    }                    
                    break;

                case '400':
                    var anArray =  <%= model400TransomTypesJ %>;

                    for (var i=0;i<anArray.length;i++)
                    {
                        var anOption = new Option(anArray[i], anArray[i]);
                        ddlTransomTypes.options.add(anOption);
                    }   
                    break;
            }
            return true;
        }

        //This function uses a regex value to validate email, returns true or false
        function emailValidation(){
            var anEmail = document.getElementById("<%=hidEmail.ClientID%>").value;
            //Regex for RFC 2822 email address validation.
            //var re = /[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?/;
            //Simpler, but less accurate string@string.string
            var re = /[^\s@]+@[^\s@]+\.[^\s@]+/;
            console.log(re.test(anEmail).toString());
            return re.test(anEmail);
        }
    </script>

    <div class="slide-window"  >

        <div class="slide-wrapper"> 
            <%-- Slide 1 - Select a Customer --%>           
            <div id="slide1" class="slide">
                <h1>
                    <asp:Label ID="lblQuestion1" runat="server" Text="Is this a new or existing customer?"></asp:Label>
                </h1>        
                              
                <ul class="toggleOptions">
                    <%--New Customer --%>
                    <li>
                        <asp:RadioButton ID="radNewCustomer" GroupName="question1" runat="server" OnClick="newProjectCheckQuestion1()" />
                        <asp:Label ID="lblNewCustomerRadio" AssociatedControlID="radNewCustomer" runat="server"></asp:Label>
                        <asp:Label ID="lblNewCustomer" AssociatedControlID="radNewCustomer" runat="server" Text="New customer"></asp:Label>
                        <%--New Customer Options --%>
                        <div class="toggleContent">
                            <ul>
                                <li>
                                    <h3>Enter customer details:</h3>

                                    <asp:Table ID="tblNewCustomerInfo" CssClass="tblTxtFields" runat="server">
                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblCustomerCountry" AssociatedControlID="ddlCustomerCountry" runat="server" Text="Country:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:DropDownList ID="ddlCustomerCountry" OnChange="newProjectCheckQuestion1()" runat="server" AutoPostBack="True"></asp:DropDownList>
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblCustomerFirstName" AssociatedControlID="txtCustomerFirstName" runat="server" Text="First Name:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:TextBox ID="txtCustomerFirstName" CssClass="txtField txtInput" onkeyup="newProjectCheckQuestion1()" OnChange="newProjectCheckQuestion1()" runat="server" MaxLength="25"></asp:TextBox>
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblCustomerLastName" AssociatedControlID="txtCustomerLastName" runat="server" Text="Last Name:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:TextBox ID="txtCustomerLastName" CssClass="txtField txtInput" onkeyup="newProjectCheckQuestion1()" OnChange="newProjectCheckQuestion1()" runat="server" MaxLength="25"></asp:TextBox>
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblCustomerAddress" AssociatedControlID="txtCustomerAddress" runat="server" Text="Address:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:TextBox ID="txtCustomerAddress" CssClass="txtField txtInput" onkeyup="newProjectCheckQuestion1()" OnChange="newProjectCheckQuestion1()" runat="server" MaxLength="50"></asp:TextBox>
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblCustomerProvState" AssociatedControlID="ddlCustomerProvState" runat="server" Text="Province:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:DropDownList ID="ddlCustomerProvState" runat="server" OnChange="newProjectCheckQuestion1()" ></asp:DropDownList>
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblCustomerCity" AssociatedControlID="txtCustomerCity" runat="server" Text="City:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:TextBox ID="txtCustomerCity" CssClass="txtField txtInput" onkeyup="newProjectCheckQuestion1()" OnChange="newProjectCheckQuestion1()" runat="server" MaxLength="30"></asp:TextBox>
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblCustomerZip" AssociatedControlID="txtCustomerZip" runat="server" Text="ZIP Code:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:TextBox ID="txtCustomerZip" CssClass="txtField txtZipPhone" onkeyup="newProjectCheckQuestion1()" OnChange="newProjectCheckQuestion1()" runat="server" MaxLength="5"></asp:TextBox>
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblCustomerEmail" AssociatedControlID="txtCustomerEmail" runat="server" Text="Email:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:TextBox ID="txtCustomerEmail" CssClass="txtField" onkeyup="newProjectCheckQuestion1()" OnChange="newProjectCheckQuestion1()" runat="server" MaxLength="50"></asp:TextBox>
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblCustomerPhone" AssociatedControlID="txtCustomerPhone" runat="server" Text="Phone Number:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:TextBox ID="txtCustomerPhone" CssClass="txtField txtZipPhone" onkeyup="newProjectCheckQuestion1()" OnChange="newProjectCheckQuestion1()" runat="server" MaxLength="10"></asp:TextBox>
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblCustomerCell" AssociatedControlID="txtCustomerCell" runat="server" Text="Cell Number:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:TextBox ID="txtCustomerCell" CssClass="txtField txtZipPhone" onkeyup="newProjectCheckQuestion1()" OnChange="newProjectCheckQuestion1()" runat="server" MaxLength="10"></asp:TextBox>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                    </asp:Table>
                                </li>
                            </ul>            
                        </div>
                    </li> 

                    <%-- Existing Customer --%>
                    <li>
                        <asp:RadioButton ID="radExistingCustomer" GroupName="question1" runat="server" OnClick="newProjectCheckQuestion1()" />
                        <asp:Label ID="lblExistingCustomerRadio" AssociatedControlID="radExistingCustomer" runat="server"></asp:Label>
                        <asp:Label ID="lblExistingCustomer" AssociatedControlID="radExistingCustomer" runat="server" Text="Existing customer"></asp:Label>

                        <%-- Existing Customer Options --%>
                        <div class="toggleContent">
                            <ul>
                                <li>
                                    <asp:DropDownList ID="ddlExistingCustomer" OnChange="newProjectCheckQuestion1()" GroupName="question1" runat="server" />
                                    <!-- DataTextField="percentage" DataValueField="id" DataSourceId="sds_Items" in case we decide to data-bind -->
                                </li>
                            </ul>            
                        </div> 
                    </li> 

                </ul> 

                <asp:Button ID="btnQuestion1" Enabled="false" CssClass="btnSubmit float-right slidePanel" data-slide="#slide2" runat="server" Text="Next Question" />

            </div>             

            <%-- Slide 2 - Project Name --%>
            <div id="slide2" class="slide">
                
                <h1>
                    <asp:Label ID="lblQuestion2" runat="server" Text="Enter a name for your project"></asp:Label>
                </h1> 

                <ul class="toggleOptions">
                    <li>
                        <asp:Table ID="tblProjectName" CssClass="tblTxtFields" runat="server">
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblProjectName" AssociatedControlID="txtProjectName" runat="server" Text="Project Name:"></asp:Label>
                                </asp:TableCell>

                                <asp:TableCell>
                                    <asp:TextBox ID="txtProjectName" CssClass="txtField txtInput" onkeyup="newProjectCheckQuestion2()" runat="server" MaxLength="50"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </li>

                </ul>

                <asp:Button ID="btnQuestion2" Enabled = "false" CssClass="btnSubmit float-right slidePanel" data-slide="#slide3" runat="server" Text="Next Question" />
                
            </div> 

            <%-- Slide 3 - Project Type --%>
            <div id="slide3" class="slide">
                <h1>
                    <asp:Label ID="lblQuestion3" runat="server" Text="What type of project would you like to create?"></asp:Label>
                </h1>         
                                
                <%-- Project Type Options--%>   
                <ul class="toggleOptions">
                    <%-- Sunroom --%>
                    <li>
                        <asp:RadioButton ID="radProjectSunroom" GroupName="projectType" runat="server" />
                        <asp:Label ID="lblProjectSunroomRadio" AssociatedControlID="radProjectSunroom" runat="server"></asp:Label>
                        <asp:Label ID="lblProjectSunroom" AssociatedControlID="radProjectSunroom" runat="server" Text="Complete Sunroom"></asp:Label>
           
                        <div class="toggleContent">
                            <ul>
                                <li>
                                    <asp:RadioButton ID="radSunroomModel100" OnClick="newProjectCheckQuestion3()" GroupName="sunroomModel" runat="server" />
                                    <asp:Label ID="lblSunroomModel100Radio" AssociatedControlID="radSunroomModel100" runat="server"></asp:Label>
                                    <asp:Label ID="lblSunroomModel100" AssociatedControlID="radSunroomModel100" runat="server" Text="Model 100"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="radSunroomModel200" OnClick="newProjectCheckQuestion3()" GroupName="sunroomModel" runat="server" />
                                    <asp:Label ID="lblSunroomModel200Radio" AssociatedControlID="radSunroomModel200" runat="server"></asp:Label>
                                    <asp:Label ID="lblSunroomModel200" AssociatedControlID="radSunroomModel200" runat="server" Text="Model 200"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="radSunroomModel300" OnClick="newProjectCheckQuestion3()" GroupName="sunroomModel" runat="server" />
                                    <asp:Label ID="lblSunroomModel300Radio" AssociatedControlID="radSunroomModel300" runat="server"></asp:Label>
                                    <asp:Label ID="lblSunroomModel300" AssociatedControlID="radSunroomModel300" runat="server" Text="Model 300"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="radSunroomModel400" OnClick="newProjectCheckQuestion3()" GroupName="sunroomModel" runat="server" />
                                    <asp:Label ID="lblSunroomModel400Radio" AssociatedControlID="radSunroomModel400" runat="server"></asp:Label>
                                    <asp:Label ID="lblSunroomModel400" AssociatedControlID="radSunroomModel400" runat="server" Text="Model 400"></asp:Label>
                                </li>
                            </ul>            
                        </div>
                    </li>

                    <%-- Walls --%>
                    <li>
                        <asp:RadioButton ID="radProjectWalls" GroupName="projectType" runat="server" />
                        <asp:Label ID="lblProjectWallsRadio" AssociatedControlID="radProjectWalls" runat="server"></asp:Label>
                        <asp:Label ID="lblProjectWalls" AssociatedControlID="radProjectWalls" runat="server" Text="Walls"></asp:Label>

                        <div class="toggleContent">
                            <ul class="checkboxes">
                                <li>
                                    <asp:RadioButton ID="radWallsModel100" OnClick="newProjectCheckQuestion3()" GroupName="sunroomModel" runat="server" />
                                    <asp:Label ID="lblWallsModel100Radio" AssociatedControlID="radWallsModel100" runat="server"></asp:Label>
                                    <asp:Label ID="lblWallsModel100" AssociatedControlID="radWallsModel100" runat="server" Text="Model 100"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="radWallsModel200" OnClick="newProjectCheckQuestion3()" GroupName="sunroomModel" runat="server" />
                                    <asp:Label ID="lblWallsModel200Radio" AssociatedControlID="radWallsModel200" runat="server"></asp:Label>
                                    <asp:Label ID="lblWallsModel200" AssociatedControlID="radWallsModel200" runat="server" Text="Model 200"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="radWallsModel300" OnClick="newProjectCheckQuestion3()" GroupName="sunroomModel" runat="server" />
                                    <asp:Label ID="lblWallsModel300Radio" AssociatedControlID="radWallsModel300" runat="server"></asp:Label>
                                    <asp:Label ID="lblWallsModel300" AssociatedControlID="radWallsModel300" runat="server" Text="Model 300"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="radWallsModel400" OnClick="newProjectCheckQuestion3()" GroupName="sunroomModel" runat="server" />
                                    <asp:Label ID="lblWallsModel400Radio" AssociatedControlID="radWallsModel400" runat="server"></asp:Label>
                                    <asp:Label ID="lblWallsModel400" AssociatedControlID="radWallsModel400" runat="server" Text="Model 400"></asp:Label>
                                </li>
                            </ul>            
                        </div>
                    </li> 

                    <%-- Window Only --%>
                    <li>
                        <asp:RadioButton ID="radProjectWindows" GroupName="projectType" runat="server" />
                        <asp:Label ID="lblProjectWindowsRadio" AssociatedControlID="radProjectWindows" runat="server"></asp:Label>
                        <asp:Label ID="lblProjectWindows" AssociatedControlID="radProjectWindows" runat="server" Text="Windows"></asp:Label>
                    </li> 
                    
                    <%-- Door only --%>
                    <li>
                        <asp:RadioButton ID="radProjectDoors" GroupName="projectType" runat="server" />
                        <asp:Label ID="lblProjectDoorsRadio" AssociatedControlID="radProjectDoors" runat="server"></asp:Label>
                        <asp:Label ID="lblProjectDoors" AssociatedControlID="radProjectDoors" runat="server" Text="Doors"></asp:Label>
                    </li>
                    
                    <%-- Floor only --%>
                    <li>
                        <asp:RadioButton ID="radProjectFlooring" GroupName="projectType" runat="server" />
                        <asp:Label ID="lblProjectFlooringRadio" AssociatedControlID="radProjectFlooring" runat="server"></asp:Label>
                        <asp:Label ID="lblProjectFlooring" AssociatedControlID="radProjectFlooring" runat="server" Text="Flooring"></asp:Label>
                    </li>
                    
                    <%-- Roof only --%>
                    <li>
                        <asp:RadioButton ID="radProjectRoof" GroupName="projectType" runat="server" />
                        <asp:Label ID="lblProjectRoofRadio" AssociatedControlID="radProjectRoof" runat="server"></asp:Label>
                        <asp:Label ID="lblProjectRoof" AssociatedControlID="radProjectRoof" runat="server" Text="Roof"></asp:Label>

                        <div class="toggleContent">
                            <ul class="checkboxes">
                                <li>
                                    <asp:RadioButton ID="radRoofIBeam" GroupName="roofType" runat="server" />
                                    <asp:Label ID="lblRoofIBeamRadio" AssociatedControlID="radRoofIBeam" runat="server"></asp:Label>
                                    <asp:Label ID="lblRoofIBeam" AssociatedControlID="radRoofIBeam" runat="server" Text="I-Beam"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="radRoofPressureCap" GroupName="roofType" runat="server" />
                                    <asp:Label ID="lblRoofPressureCapRadio" AssociatedControlID="radRoofPressureCap" runat="server"></asp:Label>
                                    <asp:Label ID="lblRoofPressureCap" AssociatedControlID="radRoofPressureCap" runat="server" Text="Pressure Cap"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="radRoofInterlocking" GroupName="roofType" runat="server" />
                                    <asp:Label ID="lblRoofInterlockingRadio" AssociatedControlID="radRoofInterlocking" runat="server"></asp:Label>
                                    <asp:Label ID="lblRoofInterlocking" AssociatedControlID="radRoofInterlocking" runat="server" Text="Interlocking"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="radRoofAcrylic" GroupName="roofType" runat="server" />
                                    <asp:Label ID="lblRoofAcrylicRadio" AssociatedControlID="radRoofAcrylic" runat="server"></asp:Label>
                                    <asp:Label ID="lblRoofAcrylic" AssociatedControlID="radRoofAcrylic" runat="server" Text="Acrylic"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="radRoofOSB" GroupName="roofType" runat="server" />
                                    <asp:Label ID="lblRoofOSBRadio" AssociatedControlID="radRoofOSB" runat="server"></asp:Label>
                                    <asp:Label ID="lblRoofOSB" AssociatedControlID="radRoofOSB" runat="server" Text="OSB/OSB"></asp:Label>
                                </li>
                            </ul>            
                        </div>
                    </li>  
                                        
                    <%-- Showroom --%>                 
                    <li>
                        <asp:RadioButton ID="radSunroomModelShowroom" OnClick="newProjectCheckQuestion3()" GroupName="projectType" runat="server" />
                        <asp:Label ID="lblSunroomModelShowroomRadio" AssociatedControlID="radSunroomModelShowroom" runat="server"></asp:Label>
                        <asp:Label ID="lblSunroomModelShowroom" AssociatedControlID="radSunroomModelShowroom" runat="server" Text="Showroom"></asp:Label>

                        <div class="toggleContent">
                            <ul class="checkboxes">
                                <li>
                                    <asp:RadioButton ID="radShowroomModel100" OnClick="newProjectCheckQuestion3()" GroupName="sunroomModel" runat="server" />
                                    <asp:Label ID="lblShowroomModel100" AssociatedControlID="radShowroomModel100" runat="server"></asp:Label>
                                    <asp:Label ID="lblShowroomModel100Radio" AssociatedControlID="radShowroomModel100" runat="server" Text="Model 100"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="radShowroomModel200" OnClick="newProjectCheckQuestion3()" GroupName="sunroomModel" runat="server" />
                                    <asp:Label ID="lblShowroomModel200" AssociatedControlID="radShowroomModel200" runat="server"></asp:Label>
                                    <asp:Label ID="lblShowroomModel200Radio" AssociatedControlID="radShowroomModel200" runat="server" Text="Model 200"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="radShowroomModel300" OnClick="newProjectCheckQuestion3()" GroupName="sunroomModel" runat="server" />
                                    <asp:Label ID="lblShowroomModel300" AssociatedControlID="radShowroomModel300" runat="server"></asp:Label>
                                    <asp:Label ID="lblShowroomModel300Radio" AssociatedControlID="radShowroomModel300" runat="server" Text="Model 300"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="radShowroomModel400" OnClick="newProjectCheckQuestion3()" GroupName="sunroomModel" runat="server" />
                                    <asp:Label ID="lblShowroomModel400" AssociatedControlID="radShowroomModel400" runat="server"></asp:Label>
                                    <asp:Label ID="lblShowroomModel400Radio" AssociatedControlID="radShowroomModel400" runat="server" Text="Model 400"></asp:Label>
                                </li>
                            </ul>            
                        </div>
                    </li>
                    
                    <%-- Component Order --%>
                    <li>
                        <asp:RadioButton ID="radProjectComponents" GroupName="projectType" runat="server"  OnClick="goComponents()"/>
                        <asp:Label ID="lblProjectComponentsRadio" AssociatedControlID="radProjectComponents" runat="server"></asp:Label>
                        <asp:Label ID="lblProjectComponents" AssociatedControlID="radProjectComponents" runat="server" Text="Components"></asp:Label>
                    </li> 
                </ul> 

                <asp:Button ID="btnQuestion3" Enabled="false" CssClass="btnSubmit float-right slidePanel" data-slide="#slide4" runat="server" Text="Next Question" />
            </div> 
            
            <%-- Slide 4 - Styling Options --%>
            <div id="slide4" class="slide">                
                <h1>
                    <asp:Label ID="lblQuestion4" runat="server" Text="Styling Options"></asp:Label>
                </h1> 

                <ul class="toggleOptions">
                    <%-- Kneewall --%>
                    <li>
                                    
                        <%--<asp:RadioButton ID="radKneewallOptions" GroupName="styling" runat="server" />
                        <asp:Label ID="lblKneewallOptionsRadio" AssociatedControlID="radKneewallOptions" runat="server"></asp:Label>
                        <asp:Label ID="lblKneewallOptions" AssociatedControlID="radKneewallOptions" runat="server" Text="Kneewall"></asp:Label>--%>
                        <asp:Label ID="lblKneewallOptions" runat="server" Text="Kneewall"></asp:Label>

                        <div class="toggleContent">
                            <ul>                                
                                <li>
                                    <asp:Table runat="server">
                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblKneewallHeight" AssociatedControlID="txtKneewallHeight" runat="server" Text="Height:" />
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:TextBox ID="txtKneewallHeight" onkeyup="newProjectCheckQuestion4()" OnChange="newProjectCheckQuestion4()" GroupName="styling" CssClass="txtField" runat="server" MaxLength="3" />
                                            </asp:TableCell>                                         
                                        </asp:TableRow>

                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblKneewallType" AssociatedControlID="txtKneewallHeight" runat="server" Text="Type:" />
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:DropDownList ID="ddlKneewallType" OnChange="newProjectCheckQuestion4()" GroupName="styling" runat="server" />
                                            </asp:TableCell>
                                        </asp:TableRow>
                                    </asp:Table>
                                </li>
                            </ul>   
                        </div> 

                    </li> 

                    <%-- Transom --%>
                    <li>
                
                        <%--<asp:RadioButton ID="radTransomOptions" GroupName="styling" runat="server" />
                        <asp:Label ID="lblTransomOptionsRadio" AssociatedControlID="radTransomOptions" runat="server"></asp:Label>
                        <asp:Label ID="lblTransomOptions" AssociatedControlID="radTransomOptions" runat="server" Text="Transom"></asp:Label>--%>
                        <asp:Label ID="lblTransomOptions" runat="server" Text="Transom"></asp:Label>

                        <div class="toggleContent">
                            <ul>                                
                                <li>
                                    <asp:Table runat="server">
                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblTransomHeight" AssociatedControlID="txtTransomHeight" runat="server" Text="Height:" />
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:TextBox ID="txtTransomHeight" onkeyup="newProjectCheckQuestion4()" OnChange="newProjectCheckQuestion4()" GroupName="styling" CssClass="txtField" runat="server" />
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblTransomType" AssociatedControlID="txtTransomHeight" runat="server" Text="Type:" />
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:DropDownList ID="ddlTransomType" OnChange="newProjectCheckQuestion4()" GroupName="styling" runat="server" />
                                            </asp:TableCell>
                                        </asp:TableRow>
                                    </asp:Table>
                                
                                </li>
                            </ul>
                        </div> 
                    </li> 
                    
                    <%-- Walls --%>            
                    <li>
                
                        <%--<asp:RadioButton ID="radFramingOptions" GroupName="styling" runat="server" />
                        <asp:Label ID="lblFramingOptionsRadio" AssociatedControlID="radFramingOptions" runat="server"></asp:Label>
                        <asp:Label ID="lblFramingOptions" AssociatedControlID="radFramingOptions" runat="server" Text="Framing"></asp:Label>--%>
                        <asp:Label ID="lblFramingOptions" runat="server" Text="Framing"></asp:Label>

                        <div class="toggleContent">
                            <ul>                                
                                <li>
                                    <asp:Table runat="server">
                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblFramingColour" AssociatedControlID="ddlFramingColour" runat="server" Text="Framing Colour:" />
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:DropDownList ID="ddlFramingColour" OnChange="newProjectCascadeColours()" GroupName="styling" runat="server" />
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblInteriorColour" AssociatedControlID="ddlInteriorColour" runat="server" Text="Interior Colour:" />
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:DropDownList ID="ddlInteriorColour" OnChange="newProjectCheckQuestion4()" GroupName="styling" runat="server" />
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblInteriorSkin" AssociatedControlID="ddlInteriorSkin" runat="server" Text="Interior Skin:" />
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:DropDownList ID="ddlInteriorSkin" OnChange="newProjectCheckQuestion4()" GroupName="styling" runat="server" />
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblExteriorColour" AssociatedControlID="ddlExteriorColour" runat="server" Text="Exterior Colour:" />
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:DropDownList ID="ddlExteriorColour" OnChange="newProjectCheckQuestion4()" GroupName="styling" runat="server" />
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblExteriorSkin" AssociatedControlID="ddlExteriorSkin" runat="server" Text="Exterior Skin:" />
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:DropDownList ID="ddlExteriorSkin" OnChange="newProjectCheckQuestion4()" GroupName="styling" runat="server" />
                                            </asp:TableCell>
                                        </asp:TableRow>  
                                    </asp:Table>                            
                                </li>
                            </ul>
                        </div>
                    </li>
                </ul> 

                <asp:Button ID="btnQuestion4" Enabled="false" CssClass="btnSubmit float-right slidePanel" data-slide="#slide5" runat="server" Text="Next Question" />
                <asp:Button ID="btnQuestion4Walls" Enabled="false" CssClass="btnSubmit float-right slidePanel" OnClick="btnQuestion4Walls_Click" runat="server" Text="Next Question" />
            </div> 

            <%-- Slide 5 - Foam Protected Panels --%>
            <div id="slide5" class="slide">                
                <h1>
                    <asp:Label ID="lblFoamProtected" runat="server" Text="Would you like foam protected panels?"></asp:Label>
                </h1> 

                <ul class="toggleOptions">
                    <li>
                        <asp:RadioButton ID="radFoamProtectedYes" OnClick="newProjectCheckQuestion5()" GroupName="foam" runat="server" />
                        <asp:Label ID="lblFoamProtectedYesRadio" AssociatedControlID="radFoamProtectedYes" runat="server"></asp:Label>
                        <asp:Label ID="lblFoamProtectedYes" AssociatedControlID="radFoamProtectedYes" runat="server" Text="Yes"></asp:Label>
                    </li>

                    <li>
                        <asp:RadioButton ID="radFoamProtectedNo" OnClick="newProjectCheckQuestion5()" GroupName="foam" runat="server" />
                        <asp:Label ID="lblFoamProtectedNoRadio" AssociatedControlID="radFoamProtectedNo" runat="server"></asp:Label>
                        <asp:Label ID="lblFoamProtectedNo" AssociatedControlID="radFoamProtectedNo" runat="server" Text="No"></asp:Label>
                    </li>

                </ul>

                <asp:Button ID="btnQuestion5" Enabled="false" CssClass="btnSubmit float-right slidePanel" data-slide="#slide6" runat="server" Text="Next Question" />
            </div> 

            <%-- Slide 6 - Prefabricated Floors --%>
            <div id="slide6" class="slide">                
                <h1>
                    <asp:Label ID="lblPrefabFloor" runat="server" Text="Would you like a prefabricated floor?"></asp:Label>
                </h1> 

                <ul class="toggleOptions">
                    <li>
                        <asp:RadioButton ID="radPrefabFloorYes" OnClick="newProjectCheckQuestion6()" GroupName="floor" runat="server" />
                        <asp:Label ID="lblPrefabFloorYesRadio" AssociatedControlID="radPrefabFloorYes" runat="server"></asp:Label>
                        <asp:Label ID="lblPrefabFloorYes" AssociatedControlID="radPrefabFloorYes" runat="server" Text="Yes"></asp:Label>
                    </li>

                    <li>
                        <asp:RadioButton ID="radPrefabFloorNo" OnClick="newProjectCheckQuestion6()" GroupName="floor" runat="server" />
                        <asp:Label ID="lblPrefabFloorNoRadio" AssociatedControlID="radPrefabFloorNo" runat="server"></asp:Label>
                        <asp:Label ID="lblPrefabFloorNo" AssociatedControlID="radPrefabFloorNo" runat="server" Text="No"></asp:Label>
                    </li>

                </ul>

                <asp:Button ID="btnQuestion6" Enabled="false" CssClass="btnSubmit float-right slidePanel" data-slide="#slide7" runat="server" Text="Next Question" />
            </div> 

            <%-- Slide 7 - Roof Choice --%>
            <div id="slide7" class="slide">                
                <h1>
                    <asp:Label ID="lblRoof" runat="server" Text="Would you like to include a roof?"></asp:Label>
                </h1> 

                <ul class="toggleOptions">
                    <li>
                        <asp:RadioButton ID="radRoofYes" GroupName="roof" runat="server" />
                        <asp:Label ID="lblRoofYesRadio" AssociatedControlID="radRoofYes" runat="server"></asp:Label>
                        <asp:Label ID="lblRoofYes" AssociatedControlID="radRoofYes" runat="server" Text="Yes"></asp:Label>

                        <div class="toggleContent">
                            <ul>
                                <li>
                                    <asp:RadioButton ID="radStudio" OnClick="newProjectCheckQuestion7()" GroupName="roofSub" runat="server" />
                                    <asp:Label ID="lblStudioRadio" AssociatedControlID="radStudio" runat="server"></asp:Label>
                                    <asp:Label ID="lblStudio" AssociatedControlID="radStudio" runat="server" Text="Studio"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="radDealerGable" OnClick="newProjectCheckQuestion7()" GroupName="roofSub" runat="server" />
                                    <asp:Label ID="lblDealerGableRadio" AssociatedControlID="radDealerGable" runat="server"></asp:Label>
                                    <asp:Label ID="lblDealerGable" AssociatedControlID="radDealerGable" runat="server" Text="Dealer gable"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="radSunspaceGable" OnClick="newProjectCheckQuestion7()" GroupName="roofSub" runat="server" />
                                    <asp:Label ID="lblSunspaceGableRadio" AssociatedControlID="radSunspaceGable" runat="server"></asp:Label>
                                    <asp:Label ID="lblSunspaceGable" AssociatedControlID="radSunspaceGable" runat="server" Text="Sunspace gable"></asp:Label>
                                </li>
                                <li>
                                    <asp:TextBox ID="txtSoffitLength" onkeyup="newProjectCheckQuestion7()" runat="server"></asp:TextBox>
                                    <asp:Label ID="lblSoffitLength" runat="server" Text="Soffit Length:"></asp:Label>
                                </li>
                            </ul>
                        </div>
                    </li>

                    <li>
                        <asp:RadioButton ID="radRoofNo" OnClick="newProjectCheckQuestion7()" GroupName="roof" runat="server" />
                        <asp:Label ID="lblRoofNoRadio" AssociatedControlID="radRoofNo" runat="server"></asp:Label>
                        <asp:Label ID="lblRoofNo" AssociatedControlID="radRoofNo" runat="server" Text="No"></asp:Label>
                    </li>

                </ul>

                <asp:Button ID="btnQuestion7" Enabled="false" CssClass="btnSubmit float-right slidePanel" data-slide="#slide8" runat="server" Text="Next Question" />
            </div> 

            <%-- Slide 8 - Layout --%>
            <div id="slide8" class="slide">                
                <h1>
                    <asp:Label ID="lblLayout" runat="server" Text="Please choose a sunroom layout."></asp:Label>
                </h1> 

                <ul class="toggleOptions">
                    <li>
                        <asp:Table runat="server" ID="tblSunroomLayout" CssClass="tblSunroomLayout">
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:RadioButton ID="radPreset1" OnClick="newProjectCheckQuestion8()" GroupName="layout" runat="server" />                        
                                    <asp:Label ID="lblPreset1Radio" AssociatedControlID="radPreset1" runat="server"></asp:Label>
                                    <asp:Image ID="imbPreset1" GroupName="layout" AssociatedControlID="radPreset1" AlternateText="missing preset image" ImageUrl="./images/layout/Preset1.png" runat="server" />  
                                </asp:TableCell>

                                <asp:TableCell>
                                    <asp:RadioButton ID="radPreset2" OnClick="newProjectCheckQuestion8()" GroupName="layout" runat="server" />                        
                                    <asp:Label ID="lblPreset2Radio" AssociatedControlID="radPreset2" runat="server"></asp:Label>
                                    <asp:Image ID="imbPreset2" GroupName="layout" AssociatedControlID="radPreset2" AlternateText="missing preset image" ImageUrl="./images/layout/Preset2.png" runat="server" /> 
                                </asp:TableCell>

                                <asp:TableCell>
                                    <asp:RadioButton ID="radPreset3" OnClick="newProjectCheckQuestion8()" GroupName="layout" runat="server" />                        
                                    <asp:Label ID="lblPreset3Radio" AssociatedControlID="radPreset3" runat="server"></asp:Label>
                                    <asp:Image ID="imbPreset3" GroupName="layout" AssociatedControlID="radPreset3" AlternateText="missing preset image" ImageUrl="./images/layout/Preset3.png" runat="server" />  
                                </asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:RadioButton ID="radPreset4" OnClick="newProjectCheckQuestion8()" GroupName="layout" runat="server" />                        
                                    <asp:Label ID="lblPreset4Radio" AssociatedControlID="radPreset4" runat="server"></asp:Label>
                                    <asp:Image ID="imbPreset4" GroupName="layout" AssociatedControlID="radPreset4" AlternateText="missing preset image" ImageUrl="./images/layout/Preset4.png" runat="server" />  
                                </asp:TableCell>

                                <asp:TableCell>
                                    <asp:RadioButton ID="radPreset5" OnClick="newProjectCheckQuestion8()" GroupName="layout" runat="server" />                        
                                    <asp:Label ID="lblPreset5Radio" AssociatedControlID="radPreset5" runat="server"></asp:Label>
                                    <asp:Image ID="imbPreset5" GroupName="layout" AssociatedControlID="radPreset5" AlternateText="missing preset image" ImageUrl="./images/layout/Preset5.png" runat="server" /> 
                                </asp:TableCell>

                                <asp:TableCell>
                                    <asp:RadioButton ID="radPreset6" OnClick="newProjectCheckQuestion8()" GroupName="layout" runat="server" />                        
                                    <asp:Label ID="lblPreset6Radio" AssociatedControlID="radPreset6" runat="server"></asp:Label>
                                    <asp:Image ID="imbPreset6" GroupName="layout" AssociatedControlID="radPreset6" AlternateText="missing preset image" ImageUrl="./images/layout/Preset6.png" runat="server" />                  
                                </asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:RadioButton ID="radPreset7" OnClick="newProjectCheckQuestion8()" GroupName="layout" runat="server" />                        
                                    <asp:Label ID="lblPreset7Radio" AssociatedControlID="radPreset7" runat="server"></asp:Label>
                                    <asp:Image ID="imbPreset7" GroupName="layout" AssociatedControlID="radPreset7" AlternateText="missing preset image" ImageUrl="./images/layout/Preset7.png" runat="server" />  
                                </asp:TableCell>

                                <asp:TableCell>
                                    <asp:RadioButton ID="radPreset8" OnClick="newProjectCheckQuestion8()" GroupName="layout" runat="server" />                        
                                    <asp:Label ID="lblPreset8Radio" AssociatedControlID="radPreset8" runat="server"></asp:Label>
                                    <asp:Image ID="imbPreset8" GroupName="layout" AssociatedControlID="radPreset8" AlternateText="missing preset image" ImageUrl="./images/layout/Preset8.png" runat="server" />  
                                </asp:TableCell>

                                <asp:TableCell>
                                     <asp:RadioButton ID="radPreset9" OnClick="newProjectCheckQuestion8()" GroupName="layout" runat="server" />                        
                                    <asp:Label ID="lblPreset9Radio" AssociatedControlID="radPreset9" runat="server"></asp:Label>
                                    <asp:Image ID="imbPreset9" GroupName="layout" AssociatedControlID="radPreset9" AlternateText="missing preset image" ImageUrl="./images/layout/Preset9.png" runat="server" />  
                                </asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:RadioButton ID="radPreset10" OnClick="newProjectCheckQuestion8()" GroupName="layout" runat="server" />                        
                                    <asp:Label ID="lblPreset10Radio" AssociatedControlID="radPreset10" runat="server"></asp:Label>
                                    <asp:Image ID="imbPreset10" GroupName="layout" AssociatedControlID="radPreset10" AlternateText="missing preset image" ImageUrl="./images/layout/Preset10.png" runat="server" />  
                                </asp:TableCell>

                                <asp:TableCell>
                                     <asp:RadioButton ID="radPresetC1" OnClick="newProjectCheckQuestion8()" GroupName="layout" runat="server" />                        
                                    <asp:Label ID="lblPresetC1Radio" AssociatedControlID="radPresetC1" runat="server"></asp:Label>
                                    <asp:Image ID="imbPresetC1" GroupName="layout" AssociatedControlID="radPresetC1" AlternateText="missing preset image" ImageUrl="./images/layout/PresetC1.png" runat="server" />
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>         
                    </li>

                    <asp:Button ID="btnQuestion8" Enabled="false" CssClass="btnSubmit float-right slidePanel" Text="Confirm all selections" runat="server" OnClientClick="newProjectCheckQuestion8()" OnClick="btnLayout_Click"/>

                </ul>
            </div> 
            
            <%-- Database Connection Source --%>
            <asp:SqlDataSource ID="sdsCustomers" runat="server" ConnectionString="<%$ ConnectionStrings:sunspaceDealerDesktopConnectionString %>" SelectCommand="SELECT * FROM [customers]"></asp:SqlDataSource>            
        </div>
    </div>     

    <%-- SLIDE PAGING (QUESTION NAVIGATION)
    ======================================== --%>
    <div id="sidebar">
        <div id="paging-wrapper">    
            <div id="paging"> 
                <h2>Project Specifications</h2>

                <ul>
                    <div style="display: none" id="pagerOne">
                        <li>
                                <a href="#" data-slide="#slide1" class="slidePanel">
                                    <asp:Label ID="lblSpecsProjectType" runat="server" Text="New/Existing Customer"></asp:Label>
                                    <asp:Label ID="lblSpecsProjectTypeAnswer" runat="server" Text="Customer Answer"></asp:Label>
                                </a>
                        </li>
                    </div>

                    <div style="display: none" id="pagerTwo">
                        <li>
                                <a href="#" data-slide="#slide2" class="slidePanel">
                                    <asp:Label ID="lblProjectNamePager" runat="server" Text="Project Name"></asp:Label>
                                    <asp:Label ID="lblProjectNameAnswer" runat="server" Text="Question 2 Answer"></asp:Label>
                                </a>
                        </li>
                    </div>

                    <div style="display: none" id="pagerThree">
                        <li>
                                <a href="#" data-slide="#slide3" class="slidePanel">
                                    <asp:Label ID="lblProjectType" runat="server" Text="Type of project"></asp:Label>
                                    <asp:Label ID="lblProjectTypeAnswer" runat="server" Text="Question 3 Answer"></asp:Label>
                                </a>
                        </li>
                    </div>

                    <div style="display: none" id="pagerFour">
                        <li>
                                <a href="#" data-slide="#slide4" class="slidePanel">
                                    <asp:Label ID="Label27" runat="server" Text="Styling options"></asp:Label>
                                    <asp:Label ID="lblQuestion4PagerAnswer" runat="server" Text="Question 4 Answer"></asp:Label>
                                </a>
                        </li>
                    </div>

                    <div style="display: none" id="pagerFive">
                        <li>
                                <a href="#" data-slide="#slide5" class="slidePanel">
                                    <asp:Label ID="Label31" runat="server" Text="Foam protection"></asp:Label>
                                    <asp:Label ID="lblQuestion5PagerAnswer" runat="server" Text="Question 5 Answer"></asp:Label>
                                </a>
                        </li>          
                    </div>    
                  
                    <div style="display: none" id="pagerSix">
                        <li>
                                <a href="#" data-slide="#slide6" class="slidePanel">
                                    <asp:Label ID="Label1" runat="server" Text="Prefab floor"></asp:Label>
                                    <asp:Label ID="lblQuestion6PagerAnswer" runat="server" Text="Question 6 Answer"></asp:Label>
                                </a>
                        </li>
                    </div>

                    <div style="display: none" id="pagerSeven">                
                        <li>
                                <a href="#" data-slide="#slide7" class="slidePanel">
                                    <asp:Label ID="Label3" runat="server" Text="Roof"></asp:Label>
                                    <asp:Label ID="lblQuestion7PagerAnswer" runat="server" Text="Question 7 Answer"></asp:Label>
                                </a>
                        </li>
                    </div>

                    <div style="display: none" id="pagerEight">
                        <li>
                                <a href="#" data-slide="#slide8" class="slidePanel">
                                    <asp:Label ID="Label5" runat="server" Text="Layout"></asp:Label>
                                    <asp:Label ID="lblQuestion8PagerAnswer" runat="server" Text="Question 8 Answer"></asp:Label>
                                </a>
                        </li>
                    </div>
                </ul>    
            </div> 
        </div>
    </div>

    <%-- Hidden input tags 
    ======================= --%>
    <input id="hidCountry" type="hidden" runat="server" />
    <input id="hidExisting" type="hidden" runat="server" />
    <input id="hidFirstName" type="hidden" runat="server" />
    <input id="hidLastName" type="hidden" runat="server" />
    <input id="hidAddress" type="hidden" runat="server" />
    <input id="hidProvState" type="hidden" runat="server" />
    <input id="hidCity" type="hidden" runat="server" />
    <input id="hidZip" type="hidden" runat="server" />
    <input id="hidPhone" type="hidden" runat="server" />
    <input id="hidCell" type="hidden" runat="server" />
    <input id="hidEmail" type="hidden" runat="server" />
   
    <input id="hidProjectName" type="hidden" runat="server" />
       
    <input id="hidProjectType" type="hidden" runat="server" />
    <input id="hidModelNumber" type="hidden" runat="server" />

    <input id="hidKneewallType" type="hidden" runat="server" />
    <input id="hidKneewallHeight" type="hidden" runat="server" />
    <input id="hidTransomType" type="hidden" runat="server" />
    <input id="hidTransomHeight" type="hidden" runat="server" />

    <input id="hidFramingColour" type="hidden" runat="server" />
    <input id="hidInteriorColour" type="hidden" runat="server" />
    <input id="hidInteriorSkin" type="hidden" runat="server" />
    <input id="hidExteriorColour" type="hidden" runat="server" />
    <input id="hidExteriorSkin" type="hidden" runat="server" />

    <input id="hidFoamProtected" type="hidden" runat="server" />

    <input id="hidPrefabFloor" type="hidden" runat="server" />

    <input id="hidRoof" type="hidden" runat="server" />
    <input id="hidRoofType" type="hidden" runat="server" />

    <input id="hidLayoutSelection" type="hidden" runat="server" />

    <%-- end hidden divs --%>    

    <script>
        $(function () {
            $('.ulNavMain').children('a').removeClass('active');
            $('#lnkMainNavNewProject').addClass('active');
        });
    </script>
</asp:Content>

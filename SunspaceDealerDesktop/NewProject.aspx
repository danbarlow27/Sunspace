<%@ Page Title="New Project - Project Details" EnableEventValidation="false" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewProject.aspx.cs" Inherits="SunspaceDealerDesktop.NewProject" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <script src="Scripts/Validation.js"></script>
  
    <script>
        function goComponents() {
            //changeme when component ordering is put into place
            window.location.replace("Home.aspx");
        }

        function toggleCountry(){

            var ddlCustomerCountry = document.getElementById("<%=ddlCustomerCountry.ClientID%>").value;
            var zipLabel = document.getElementById("<%=lblCustomerZip.ClientID%>");
            var zipText = document.getElementById("<%=txtCustomerZip.ClientID%>");
            var provStateLabel = document.getElementById("<%=lblCustomerProvState.ClientID%>");

            var country = document.getElementById("<%=ddlCustomerCountry.ClientID%>").value;

            if (country == "USA")
            {                
                var ddlProvState = document.getElementById("<%=ddlCustomerProvState.ClientID%>");
                var stateArray = <%= usStatesJ %>;
                var stateCodeArray = <%= usCodesJ %>;

                ddlProvState.options.length = 0;

                for (var i=0;i<stateArray.length;i++)
                {
                    var anOption = new Option(stateArray[i], stateCodeArray[i]);
                    ddlProvState.options.add(anOption);
                }

                provStateLabel.innerHTML = "State";

                zipText.setAttribute("MaxLength", "5");
                zipLabel.innerHTML = "Zip Code:";
            }
            else
            {
                var ddlProvState = document.getElementById("<%=ddlCustomerProvState.ClientID%>");
                var canProvArray = <%= canProvJ %>;
                var canCodeArray = <%= canCodesJ %>;

                ddlProvState.options.length = 0;

                for (var i=0;i<canProvArray.length;i++)
                {
                    var anOption = new Option(canProvArray[i], canCodeArray[i]);
                    ddlProvState.options.add(anOption);
                }

                var postalCode = document.getElementById("<%=hidZip.ClientID%>").value;
                var postCheck = checkPostalCode(postalCode);

                provStateLabel.innerHTML = "Province";

                zipText.setAttribute("MaxLength", "6");
                zipLabel.innerHTML = "Postal Code:";
            }
        }

        function newProjectCustomerSlide() 
        {
            document.getElementById('<%=btnQuestion3.ClientID%>').style.display="inline";
            document.getElementById('<%=btnQuestion3_OrderOnly.ClientID%>').style.display="none";
            var ddlCustomerCountry = document.getElementById("<%=ddlCustomerCountry.ClientID%>").value;
            var zipLabel = document.getElementById("<%=lblCustomerZip.ClientID%>");
            var zipText = document.getElementById("<%=txtCustomerZip.ClientID%>");
            var provStateLabel = document.getElementById("<%=lblCustomerProvState.ClientID%>");

            document.getElementById('<%=txtErrorMessage.ClientID%>').value = "";
            //disable 'next slide' button until after validation
            document.getElementById('<%=btnQuestion1.ClientID%>').disabled = true;
            //if they select new customer
            if ($('#<%=radNewCustomer.ClientID%>').is(':checked')) 
            {
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

                
                if (document.getElementById("<%=txtCustomerFirstName.ClientID%>").value == "")
                {
                    document.getElementById('<%=txtErrorMessage.ClientID%>').value += "Customer First Name is required.\n";
                }

                if (document.getElementById("<%=txtCustomerLastName.ClientID%>").value == "")
                {
                    document.getElementById('<%=txtErrorMessage.ClientID%>').value += "Customer Last Name is required.\n";
                }

                //check zipcode
                if (ddlCustomerCountry == "USA")
                {
                    var zipCode = document.getElementById("<%=hidZip.ClientID%>").value;
                    
                    if (zipCode.length > 0)
                    {
                        if (isNaN(zipCode) || zipCode.length < 5) {
                            document.getElementById('<%=txtErrorMessage.ClientID%>').value += "The Zip Code you entered is not valid.\n";
                        }
                    }
                }

                //check postal code
                if (ddlCustomerCountry == "CAN")
                {
                    if (document.getElementById("<%=txtCustomerZip.ClientID%>").value != "")
                    {
                        if (postCheck == false)
                        {
                            document.getElementById('<%=txtErrorMessage.ClientID%>').value += "The Postal Code you entered is not valid.\n";
                        }
                    }
                }

                //check to see if email is valid
                if (document.getElementById("<%=txtCustomerEmail.ClientID%>").value != "")
                {
                    if (emailValidation() == false)
                    {
                        document.getElementById('<%=txtErrorMessage.ClientID%>').value += "The Customer Email you entered is not valid.\n";
                    }
                }

                
                if (document.getElementById("<%=txtCustomerPhone.ClientID%>").value != "")
                {
                    //having troubles checking .value.length, so setting .value into a variable
                    var lengthCheck = document.getElementById("<%=txtCustomerPhone.ClientID%>").value;

                    //only check if a full 10digit number is entered
                    if (lengthCheck.length == 10) {
                        //validatePhone function returns an error message, blank if valid
                        var validPhone = validatePhone(document.getElementById("<%=txtCustomerPhone.ClientID%>").value);

                        if (validPhone != "")
                        {
                            document.getElementById('<%=txtErrorMessage.ClientID%>').value += validPhone;
                        }
                    }
                    else if (lengthCheck.length < 10)
                    {
                        document.getElementById('<%=txtErrorMessage.ClientID%>').value += "Customer Phone is incomplete.\n";
                    }
                }

                //having troubles checking .value.length, so setting .value into a variable
                var lengthCheck = document.getElementById("<%=hidCell.ClientID%>").value;

                //only check if a full 10digit number is entered
                if (lengthCheck.length == 10) 
                {
                    //validatePhone function returns an error message, blank if valid
                    var validCell = validatePhone(document.getElementById("<%=hidCell.ClientID%>").value);

                    if (validCell != "")
                    {
                        document.getElementById('<%=txtErrorMessage.ClientID%>').value += validCell;
                    }
                }

                if (document.getElementById("<%=txtCustomerFirstName.ClientID%>").value == "" &&
                    document.getElementById("<%=txtCustomerLastName.ClientID%>").value == "") 
                {

                    document.getElementById('<%=txtErrorMessage.ClientID%>').value = "Customer First and Last names are required.";
                }

                //isValid remains true if nothing became false
                if (document.getElementById('<%=txtErrorMessage.ClientID%>').value == "") 
                {
                    //Set answer to 'new' on side pager and enable button
                    $('#<%=lblSpecsProjectTypeAnswer.ClientID%>').text("New");
                    document.getElementById('pagerOne').style.display = "inline";
                    document.getElementById('<%=btnQuestion1.ClientID%>').disabled = false;
                }
            }
                //if they select existing customer
            else if ($('#<%=radExistingCustomer.ClientID%>').is(':checked')) 
            {
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
                    $('#<%=lblSpecsProjectTypeAnswer.ClientID%>').text("Existing - " + $('#<%=ddlExistingCustomer.ClientID%>').find('option:selected').text());
                    document.getElementById("<%=hidExisting.ClientID%>").value = $('#<%=ddlExistingCustomer.ClientID%>').val();
                    document.getElementById('pagerOne').style.display = "inline";
                    document.getElementById('<%=btnQuestion1.ClientID%>').disabled = false;
                }
            }

            else if ($('#<%=radNoCustomer.ClientID%>').is(':checked'))
            {
                //blank out new customer hiddens, just in case they did it first then came existing after
                document.getElementById("<%=hidFirstName.ClientID%>").value = "";
                document.getElementById("<%=hidLastName.ClientID%>").value = "";
                document.getElementById("<%=hidAddress.ClientID%>").value = "";
                document.getElementById("<%=hidCity.ClientID%>").value = "";
                document.getElementById("<%=hidZip.ClientID%>").value = "";
                document.getElementById("<%=hidPhone.ClientID%>").value = "";
                $('#<%=lblSpecsProjectTypeAnswer.ClientID%>').text("");

                
                $('#<%=lblSpecsProjectTypeAnswer.ClientID%>').text("No Customer");
                document.getElementById("<%=hidExisting.ClientID%>").value = -1;
                document.getElementById('pagerOne').style.display = "inline";
                document.getElementById('<%=btnQuestion1.ClientID%>').disabled = false;                
            }

            if(document.getElementById("<%=txtCustomerLastName.ClientID%>").value != "")
            {
                $('#<%=txtProjectName.ClientID%>').val(document.getElementById("<%=txtCustomerLastName.ClientID%>").value);
            }

            return false;
        }

        function newProjectTagSlide() {
            document.getElementById('<%=txtErrorMessage.ClientID%>').value = "";
            //disable 'next slide' button until after validation
            document.getElementById('<%=btnQuestion2.ClientID%>').disabled = true;

            //move project name to hidden field
            document.getElementById("<%=hidProjectName.ClientID%>").value = $('#<%=txtProjectName.ClientID%>').val();

            //if its not blank, its valid
            if (document.getElementById("<%=hidProjectName.ClientID%>").value != "") {
                var checkProjectName = true;
                var anArray =  <%= unavailableProjectNames %>;

                for (var i=0;i<anArray.length;i++)
                {
                    if (anArray[i] == document.getElementById("<%=hidProjectName.ClientID%>").value)
                    {
                        checkProjectName = false;
                    }
                }

                if (checkProjectName == true)
                {
                    //valid, so update pager and enable button
                    $('#<%=lblProjectNameAnswer.ClientID%>').text(document.getElementById("<%=hidProjectName.ClientID%>").value);
                    document.getElementById('pagerTwo').style.display = "inline";
                    document.getElementById('<%=btnQuestion2.ClientID%>').disabled = false;
                }
                else
                {
                    //error styling or something
                    document.getElementById('<%=txtErrorMessage.ClientID%>').value = "Project name either invalid, or is already chosen.";
                }
            }
            else {
                //error styling or something
                document.getElementById('<%=txtErrorMessage.ClientID%>').value = "You must enter a project name in order to proceed.";
            }
            return false;
        }

        function newProjectTypeSlide() {
            document.getElementById('<%=btnQuestion3.ClientID%>').disabled = true;
            //if they pick sunroom
            if ($('#<%=radProjectSunroom.ClientID%>').is(':checked')) {
                //They check one of 4 model types
                //update pager, enable button, and update hidden value
                //corresponding to selected model #
                if ($('#<%=radSunroomModel100.ClientID%>').is(':checked')) {
                    document.getElementById("<%=hidModelNumber.ClientID%>").value = "M100";
                    document.getElementById('pagerThree').style.display = "inline";
                    document.getElementById('<%=btnQuestion3.ClientID%>').disabled = false;
                }
                else if ($('#<%=radSunroomModel200.ClientID%>').is(':checked')) {
                    document.getElementById("<%=hidModelNumber.ClientID%>").value = "M200";
                    document.getElementById('pagerThree').style.display = "inline";
                    document.getElementById('<%=btnQuestion3.ClientID%>').disabled = false;
                }
                else if ($('#<%=radSunroomModel300.ClientID%>').is(':checked')) {
                    document.getElementById("<%=hidModelNumber.ClientID%>").value = "M300";
                    document.getElementById('pagerThree').style.display = "inline";
                    document.getElementById('<%=btnQuestion3.ClientID%>').disabled = false;
                }
                else if ($('#<%=radSunroomModel400.ClientID%>').is(':checked')) {
                    document.getElementById("<%=hidModelNumber.ClientID%>").value = "M400";
                    document.getElementById('pagerThree').style.display = "inline";
                    document.getElementById('<%=btnQuestion3.ClientID%>').disabled = false;
                }

                //update hidden value for type, and display pager message based on the now
                //two hidden values type and model#
                document.getElementById("<%=hidProjectType.ClientID%>").value = "Sunroom";
                $('#<%=lblProjectTypeAnswer.ClientID%>').text(document.getElementById("<%=hidProjectType.ClientID%>").value + " of Model " + document.getElementById("<%=hidModelNumber.ClientID%>").value);

                document.getElementById('<%=btnQuestion3.ClientID%>').style.display="inline";
                document.getElementById('<%=btnQuestion3_OrderOnly.ClientID%>').style.display="none";
            }
            else if ($('#<%=radProjectWalls.ClientID%>').is(':checked')) {
                document.getElementById('<%=btnQuestion3_OrderOnly.ClientID%>').disabled = true;
                //They check one of 4 model types
                //update pager, enable button, and update hidden value
                //corresponding to selected model #
                if ($('#<%=radWallsModel100.ClientID%>').is(':checked')) {
                    document.getElementById("<%=hidModelNumber.ClientID%>").value = "M100";
                    document.getElementById('pagerThree').style.display = "inline";
                    document.getElementById('<%=btnQuestion3_OrderOnly.ClientID%>').disabled = false;
                }
                else if ($('#<%=radWallsModel200.ClientID%>').is(':checked')) {
                    document.getElementById("<%=hidModelNumber.ClientID%>").value = "M200";
                    document.getElementById('pagerThree').style.display = "inline";
                    document.getElementById('<%=btnQuestion3_OrderOnly.ClientID%>').disabled = false;
                }
                else if ($('#<%=radWallsModel300.ClientID%>').is(':checked')) {
                    document.getElementById("<%=hidModelNumber.ClientID%>").value = "M300";
                    document.getElementById('pagerThree').style.display = "inline";
                    document.getElementById('<%=btnQuestion3_OrderOnly.ClientID%>').disabled = false;
                }
                else if ($('#<%=radWallsModel400.ClientID%>').is(':checked')) {
                    document.getElementById("<%=hidModelNumber.ClientID%>").value = "M400";
                    document.getElementById('pagerThree').style.display = "inline";
                    document.getElementById('<%=btnQuestion3_OrderOnly.ClientID%>').disabled = false;
                }                
                //update hidden value for type, and display pager message based on the now
                //two hidden values type and model#
                document.getElementById("<%=hidProjectType.ClientID%>").value = "Walls";
                $('#<%=lblProjectTypeAnswer.ClientID%>').text(document.getElementById("<%=hidProjectType.ClientID%>").value + " of Model " + document.getElementById("<%=hidModelNumber.ClientID%>").value);
                                
                document.getElementById('<%=btnQuestion3.ClientID%>').style.display="none";
                document.getElementById('<%=btnQuestion3_OrderOnly.ClientID%>').style.display="inline";

                document.getElementById("<%=hidWallNumber.ClientID%>").value = document.getElementById('<%=txtWallNumber.ClientID%>').value;

                if (document.getElementById('<%=txtWallNumber.ClientID%>').value == "" || document.getElementById('<%=txtWallNumber.ClientID%>').value < 1)
                {
                    document.getElementById('<%=btnQuestion3_OrderOnly.ClientID%>').disabled = true;
                    document.getElementById('<%=txtErrorMessage.ClientID%>').value = "You must have at least one wall.";
                }
                else
                {
                    document.getElementById('<%=btnQuestion3_OrderOnly.ClientID%>').disabled = false;
                    document.getElementById('<%=txtErrorMessage.ClientID%>').value = "";
                }
            }
            else{              
                document.getElementById('<%=btnQuestion3.ClientID%>').style.display="none";
                document.getElementById('<%=btnQuestion3_OrderOnly.ClientID%>').style.display="inline";
            }
            
            if ($('#<%=radProjectWindows.ClientID%>').is(':checked')) {
                document.getElementById("<%=hidProjectType.ClientID%>").value = "Windows";
            }
            else if ($('#<%=radProjectDoors.ClientID%>').is(':checked')) {
                document.getElementById("<%=hidProjectType.ClientID%>").value = "Door";
            }
            else if ($('#<%=radProjectFlooring.ClientID%>').is(':checked')) {
                document.getElementById("<%=hidProjectType.ClientID%>").value = "Flooring";
            }
            else if ($('#<%=radProjectRoof.ClientID%>').is(':checked')) {
                document.getElementById("<%=hidProjectType.ClientID%>").value = "Roof";
            }

            return false;
        }

        function newProjectFloorSlide() {
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

        function newProjectRoofSlide() {
            document.getElementById("<%=txtErrorMessage.ClientID%>").value = "";
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

                    //unhide studio-only
                    document.getElementById('<%=tbcPreset4.ClientID%>').style.display = "block";
                    document.getElementById('<%=tbcPreset7.ClientID%>').style.display = "block";

                    //set to studio images
                    if ($('#<%=chkMirrored.ClientID%>').is(':checked'))
                    {
                        document.getElementById("<%=imbPreset1.ClientID%>").setAttribute("src", "./images/layout/Preset1.png");
                        document.getElementById("<%=imbPreset2.ClientID%>").setAttribute("src", "./images/layout/Preset2.png");
                        document.getElementById("<%=imbPreset3.ClientID%>").setAttribute("src", "./images/layout/Preset3.png");
                        document.getElementById("<%=imbPreset4.ClientID%>").setAttribute("src", "./images/layout/Preset4M.png");
                        document.getElementById("<%=imbPreset5.ClientID%>").setAttribute("src", "./images/layout/Preset5M.png");
                        document.getElementById("<%=imbPreset6.ClientID%>").setAttribute("src", "./images/layout/Preset6M.png");
                        document.getElementById("<%=imbPreset7.ClientID%>").setAttribute("src", "./images/layout/Preset7M.png");
                        document.getElementById("<%=imbPreset8.ClientID%>").setAttribute("src", "./images/layout/Preset8M.png");
                        document.getElementById("<%=imbPreset9.ClientID%>").setAttribute("src", "./images/layout/Preset9M.png");
                        document.getElementById("<%=imbPreset10.ClientID%>").setAttribute("src", "./images/layout/Preset10.png");
                    }
                    else
                    {                      
                        document.getElementById("<%=imbPreset1.ClientID%>").setAttribute("src", "./images/layout/Preset1.png");
                        document.getElementById("<%=imbPreset2.ClientID%>").setAttribute("src", "./images/layout/Preset2.png");
                        document.getElementById("<%=imbPreset3.ClientID%>").setAttribute("src", "./images/layout/Preset3.png");
                        document.getElementById("<%=imbPreset4.ClientID%>").setAttribute("src", "./images/layout/Preset4.png");
                        document.getElementById("<%=imbPreset5.ClientID%>").setAttribute("src", "./images/layout/Preset5.png");
                        document.getElementById("<%=imbPreset6.ClientID%>").setAttribute("src", "./images/layout/Preset6.png");
                        document.getElementById("<%=imbPreset7.ClientID%>").setAttribute("src", "./images/layout/Preset7.png");
                        document.getElementById("<%=imbPreset8.ClientID%>").setAttribute("src", "./images/layout/Preset8.png");
                        document.getElementById("<%=imbPreset9.ClientID%>").setAttribute("src", "./images/layout/Preset9.png");
                        document.getElementById("<%=imbPreset10.ClientID%>").setAttribute("src", "./images/layout/Preset10.png");
                    }
                }
                else if ($('#<%=radDealerGable.ClientID%>').is(':checked')) {
                    document.getElementById('<%=btnQuestion7.ClientID%>').disabled = false;
                    $('#<%=lblQuestion7PagerAnswer.ClientID%>').text("Dealer Gable");
                    document.getElementById('pagerSeven').style.display = "inline";
                    document.getElementById("<%=hidRoof.ClientID%>").value = "Yes";
                    document.getElementById("<%=hidRoofType.ClientID%>").value = "Dealer Gable";

                    //hide studio-only
                    document.getElementById('<%=tbcPreset4.ClientID%>').style.display = "none";                    
                    document.getElementById('<%=tbcPreset7.ClientID%>').style.display = "none";

                    //set to gable images
                    if ($('#<%=chkMirrored.ClientID%>').is(':checked'))
                    {
                        document.getElementById("<%=imbPreset1.ClientID%>").setAttribute("src", "./images/layout/Preset1.png");
                        document.getElementById("<%=imbPreset2.ClientID%>").setAttribute("src", "./images/layout/Preset2.png");
                        document.getElementById("<%=imbPreset3.ClientID%>").setAttribute("src", "./images/layout/Preset3.png");
                        document.getElementById("<%=imbPreset4.ClientID%>").setAttribute("src", "./images/layout/Preset4M.png");
                        document.getElementById("<%=imbPreset5.ClientID%>").setAttribute("src", "./images/layout/Preset5MG.png");
                        document.getElementById("<%=imbPreset6.ClientID%>").setAttribute("src", "./images/layout/Preset6MG.png");
                        document.getElementById("<%=imbPreset7.ClientID%>").setAttribute("src", "./images/layout/Preset7M.png");
                        document.getElementById("<%=imbPreset8.ClientID%>").setAttribute("src", "./images/layout/Preset8MG.png");
                        document.getElementById("<%=imbPreset9.ClientID%>").setAttribute("src", "./images/layout/Preset9MG.png");
                        document.getElementById("<%=imbPreset10.ClientID%>").setAttribute("src", "./images/layout/Preset10.png");
                    }
                    else
                    {                        
                        document.getElementById("<%=imbPreset1.ClientID%>").setAttribute("src", "./images/layout/Preset1G.png");
                        document.getElementById("<%=imbPreset2.ClientID%>").setAttribute("src", "./images/layout/Preset2G.png");
                        document.getElementById("<%=imbPreset3.ClientID%>").setAttribute("src", "./images/layout/Preset3G.png");
                        document.getElementById("<%=imbPreset4.ClientID%>").setAttribute("src", "./images/layout/Preset4.png");
                        document.getElementById("<%=imbPreset5.ClientID%>").setAttribute("src", "./images/layout/Preset5G.png");
                        document.getElementById("<%=imbPreset6.ClientID%>").setAttribute("src", "./images/layout/Preset6G.png");
                        document.getElementById("<%=imbPreset7.ClientID%>").setAttribute("src", "./images/layout/Preset7.png");
                        document.getElementById("<%=imbPreset8.ClientID%>").setAttribute("src", "./images/layout/Preset8G.png");
                        document.getElementById("<%=imbPreset9.ClientID%>").setAttribute("src", "./images/layout/Preset9G.png");
                        document.getElementById("<%=imbPreset10.ClientID%>").setAttribute("src", "./images/layout/Preset10G.png");
                    }
                }
                else if ($('#<%=radSunspaceGable.ClientID%>').is(':checked')) {
                    document.getElementById('<%=btnQuestion7.ClientID%>').disabled = false;
                    $('#<%=lblQuestion7PagerAnswer.ClientID%>').text("Sunspace Gable");
                    document.getElementById('pagerSeven').style.display = "inline";
                    document.getElementById("<%=hidRoof.ClientID%>").value = "Yes";
                    document.getElementById("<%=hidRoofType.ClientID%>").value = "Sunspace Gable";

                    //hide studio-only
                    document.getElementById('<%=tbcPreset4.ClientID%>').style.display = "none";                    
                    document.getElementById('<%=tbcPreset7.ClientID%>').style.display = "none";
                    
                    //set to gable images
                    if ($('#<%=chkMirrored.ClientID%>').is(':checked'))
                    {
                        document.getElementById("<%=imbPreset1.ClientID%>").setAttribute("src", "./images/layout/Preset1.png");
                        document.getElementById("<%=imbPreset2.ClientID%>").setAttribute("src", "./images/layout/Preset2.png");
                        document.getElementById("<%=imbPreset3.ClientID%>").setAttribute("src", "./images/layout/Preset3.png");
                        document.getElementById("<%=imbPreset4.ClientID%>").setAttribute("src", "./images/layout/Preset4M.png");
                        document.getElementById("<%=imbPreset5.ClientID%>").setAttribute("src", "./images/layout/Preset5MG.png");
                        document.getElementById("<%=imbPreset6.ClientID%>").setAttribute("src", "./images/layout/Preset6MG.png");
                        document.getElementById("<%=imbPreset7.ClientID%>").setAttribute("src", "./images/layout/Preset7M.png");
                        document.getElementById("<%=imbPreset8.ClientID%>").setAttribute("src", "./images/layout/Preset8MG.png");
                        document.getElementById("<%=imbPreset9.ClientID%>").setAttribute("src", "./images/layout/Preset9MG.png");
                        document.getElementById("<%=imbPreset10.ClientID%>").setAttribute("src", "./images/layout/Preset10.png");
                    }
                    else
                    {                      
                        document.getElementById("<%=imbPreset1.ClientID%>").setAttribute("src", "./images/layout/Preset1G.png");
                        document.getElementById("<%=imbPreset2.ClientID%>").setAttribute("src", "./images/layout/Preset2G.png");
                        document.getElementById("<%=imbPreset3.ClientID%>").setAttribute("src", "./images/layout/Preset3G.png");
                        document.getElementById("<%=imbPreset4.ClientID%>").setAttribute("src", "./images/layout/Preset4.png");
                        document.getElementById("<%=imbPreset5.ClientID%>").setAttribute("src", "./images/layout/Preset5G.png");
                        document.getElementById("<%=imbPreset6.ClientID%>").setAttribute("src", "./images/layout/Preset6G.png");
                        document.getElementById("<%=imbPreset7.ClientID%>").setAttribute("src", "./images/layout/Preset7.png");
                        document.getElementById("<%=imbPreset8.ClientID%>").setAttribute("src", "./images/layout/Preset8G.png");
                        document.getElementById("<%=imbPreset9.ClientID%>").setAttribute("src", "./images/layout/Preset9G.png");
                        document.getElementById("<%=imbPreset10.ClientID%>").setAttribute("src", "./images/layout/Preset10G.png");
                    }
                }
                else {
                    document.getElementById('<%=btnQuestion7.ClientID%>').disabled = true;
                    document.getElementById("<%=txtErrorMessage.ClientID%>").value += "Please select a roof type.\n";
                }

                if ($('#<%=txtSoffitLength.ClientID%>').val() != "")
                {
                    if (isNaN($('#<%=txtSoffitLength.ClientID%>').val()))
                    {                        
                        document.getElementById('<%=btnQuestion7.ClientID%>').disabled = true;
                        document.getElementById('pagerSeven').style.display = "none";
                        document.getElementById("<%=txtErrorMessage.ClientID%>").value += "The soffit length you entered is not a valid number.";
                    }
                    else
                    { 
                        document.getElementById('<%=btnQuestion7.ClientID%>').disabled = false;                       
                        $('#<%=lblQuestion7PagerSecondAnswer.ClientID%>').text($('#<%=txtSoffitLength.ClientID%>').val());
                        document.getElementById('pagerSeven').style.display = "inline";
                        document.getElementById('<%=hidSoffitLength.ClientID%>').value = $('#<%=txtSoffitLength.ClientID%>').val();
                    }
                }
                else
                {
                    document.getElementById('<%=btnQuestion7.ClientID%>').disabled = true;
                    document.getElementById('pagerSeven').style.display = "none";
                    document.getElementById("<%=txtErrorMessage.ClientID%>").value = "Please enter a soffit length (enter 0 for no soffit).";
                }
            }

            return false;
        }

        function newProjectLayoutSlide() {
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

        //This function uses a regex value to validate email, returns true or false
        function emailValidation(){
            var anEmail = document.getElementById("<%=hidEmail.ClientID%>").value;
            //Regex for RFC 2822 email address validation.
            //var re = /[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?/;
            //Simpler, but less accurate string@string.string
            var re = /[^\s@]+@[^\s@]+\.[^\s@]+/;
            return re.test(anEmail);
        }

        function toggleMirrored(){
            var theImage;

            if ($('#<%=chkMirrored.ClientID%>').is(':checked'))
            {
                if ($('#<%=radDealerGable.ClientID%>').is(':checked') || $('#<%=radSunspaceGable.ClientID%>').is(':checked'))
                {                    
                    theImage = document.getElementById("<%=imbPreset4.ClientID%>");
                    theImage.setAttribute("src", "./images/layout/Preset4M.png");

                    theImage = document.getElementById("<%=imbPreset5.ClientID%>");
                    theImage.setAttribute("src", "./images/layout/Preset5MG.png");

                    theImage = document.getElementById("<%=imbPreset6.ClientID%>");
                    theImage.setAttribute("src", "./images/layout/Preset6MG.png");

                    theImage = document.getElementById("<%=imbPreset7.ClientID%>");
                    theImage.setAttribute("src", "./images/layout/Preset7M.png");

                    theImage = document.getElementById("<%=imbPreset8.ClientID%>");
                    theImage.setAttribute("src", "./images/layout/Preset8MG.png");

                    theImage = document.getElementById("<%=imbPreset9.ClientID%>");
                    theImage.setAttribute("src", "./images/layout/Preset9MG.png");
                }
                else
                {                    
                    theImage = document.getElementById("<%=imbPreset4.ClientID%>");
                    theImage.setAttribute("src", "./images/layout/Preset4M.png");

                    theImage = document.getElementById("<%=imbPreset5.ClientID%>");
                    theImage.setAttribute("src", "./images/layout/Preset5M.png");

                    theImage = document.getElementById("<%=imbPreset6.ClientID%>");
                    theImage.setAttribute("src", "./images/layout/Preset6M.png");

                    theImage = document.getElementById("<%=imbPreset7.ClientID%>");
                    theImage.setAttribute("src", "./images/layout/Preset7M.png");

                    theImage = document.getElementById("<%=imbPreset8.ClientID%>");
                    theImage.setAttribute("src", "./images/layout/Preset8M.png");

                    theImage = document.getElementById("<%=imbPreset9.ClientID%>");
                    theImage.setAttribute("src", "./images/layout/Preset9M.png");
                }
            }
            else
            {
                if ($('#<%=radDealerGable.ClientID%>').is(':checked') || $('#<%=radSunspaceGable.ClientID%>').is(':checked'))
                {
                    theImage = document.getElementById("<%=imbPreset4.ClientID%>");
                    theImage.setAttribute("src", "./images/layout/Preset4.png");

                    theImage = document.getElementById("<%=imbPreset5.ClientID%>");
                    theImage.setAttribute("src", "./images/layout/Preset5G.png");

                    theImage = document.getElementById("<%=imbPreset6.ClientID%>");
                    theImage.setAttribute("src", "./images/layout/Preset6G.png");

                    theImage = document.getElementById("<%=imbPreset7.ClientID%>");
                    theImage.setAttribute("src", "./images/layout/Preset7.png");

                    theImage = document.getElementById("<%=imbPreset8.ClientID%>");
                    theImage.setAttribute("src", "./images/layout/Preset8G.png");

                    theImage = document.getElementById("<%=imbPreset9.ClientID%>");
                    theImage.setAttribute("src", "./images/layout/Preset9G.png");
                }
                else
                {                 
                    theImage = document.getElementById("<%=imbPreset4.ClientID%>");
                    theImage.setAttribute("src", "./images/layout/Preset4.png");

                    theImage = document.getElementById("<%=imbPreset5.ClientID%>");
                    theImage.setAttribute("src", "./images/layout/Preset5.png");

                    theImage = document.getElementById("<%=imbPreset6.ClientID%>");
                    theImage.setAttribute("src", "./images/layout/Preset6.png");

                    theImage = document.getElementById("<%=imbPreset7.ClientID%>");
                    theImage.setAttribute("src", "./images/layout/Preset7.png");

                    theImage = document.getElementById("<%=imbPreset8.ClientID%>");
                    theImage.setAttribute("src", "./images/layout/Preset8.png");

                    theImage = document.getElementById("<%=imbPreset9.ClientID%>");
                    theImage.setAttribute("src", "./images/layout/Preset9.png");
                }
            }
        }

        function isFoamProtected()
        {
            console.log("Is foam protected?");
            if ($('#MainContent_radProjectSunroom').is(':checked'))
            {
                if ($('#MainContent_chkSunroomFoamPanels').is(':checked'))
                {
                    document.getElementById('<%=hidFoamProtected.ClientID%>').value = "Yes";
                }
                else
                {                    
                    document.getElementById('<%=hidFoamProtected.ClientID%>').value = "No";
                }
            }
            else if ($('#MainContent_radProjectWalls').is(':checked'))
            {
                if ($('#MainContent_chkWallFoamPanels').is(':checked'))
                {
                    document.getElementById('<%=hidFoamProtected.ClientID%>').value = "Yes";
                }
                else
                {                    
                    document.getElementById('<%=hidFoamProtected.ClientID%>').value = "No";
                }
            }
        }

        function checkProjectType()
        {
            
        }
    </script>

    <div class="slide-window"  >

        <div class="slide-wrapper"> 
            <%-- Slide 1 - Select a Customer --%>           
            <div id="customerSlide" class="slide">
                <h1>
                    <asp:Label ID="lblQuestion1" runat="server" Text="Customer Selection"></asp:Label>
                </h1>        
                              
                <ul class="toggleOptions">
                    <%--New Customer --%>
                    <li>
                        <asp:RadioButton ID="radNewCustomer" GroupName="question1" runat="server" OnClick="newProjectCustomerSlide()" />
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
                                                <asp:DropDownList ID="ddlCustomerCountry" OnChange="toggleCountry(); newProjectCustomerSlide()" runat="server"></asp:DropDownList>
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblCustomerFirstName" AssociatedControlID="txtCustomerFirstName" runat="server" Text="First Name:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:TextBox ID="txtCustomerFirstName" onkeydown="return (event.keyCode!=13);" CssClass="txtField txtInput" onkeyup="newProjectCustomerSlide()" OnChange="newProjectCustomerSlide()" runat="server" MaxLength="25"></asp:TextBox>
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblCustomerLastName" AssociatedControlID="txtCustomerLastName" runat="server" Text="Last Name:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:TextBox ID="txtCustomerLastName" onkeydown="return (event.keyCode!=13);" CssClass="txtField txtInput" onkeyup="newProjectCustomerSlide()" OnChange="newProjectCustomerSlide()" runat="server" MaxLength="25"></asp:TextBox>
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblCustomerAddress" AssociatedControlID="txtCustomerAddress" runat="server" Text="Address:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:TextBox ID="txtCustomerAddress" onkeydown="return (event.keyCode!=13);" CssClass="txtField txtInput" onkeyup="newProjectCustomerSlide()" OnChange="newProjectCustomerSlide()" runat="server" MaxLength="50"></asp:TextBox>
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblCustomerProvState" AssociatedControlID="ddlCustomerProvState" runat="server" Text="Province:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:DropDownList ID="ddlCustomerProvState" runat="server" OnChange=""></asp:DropDownList>
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblCustomerCity" AssociatedControlID="txtCustomerCity" runat="server" Text="City:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:TextBox ID="txtCustomerCity" onkeydown="return (event.keyCode!=13);" CssClass="txtField txtInput" onkeyup="newProjectCustomerSlide()" OnChange="newProjectCustomerSlide()" runat="server" MaxLength="30"></asp:TextBox>
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblCustomerZip" AssociatedControlID="txtCustomerZip" runat="server" Text="Postal Code:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:TextBox ID="txtCustomerZip" onkeydown="return (event.keyCode!=13);" CssClass="txtField txtZipPhone" onkeyup="newProjectCustomerSlide()" OnChange="newProjectCustomerSlide()" runat="server" MaxLength="5"></asp:TextBox>
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblCustomerEmail" AssociatedControlID="txtCustomerEmail" runat="server" Text="Email:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:TextBox ID="txtCustomerEmail" onkeydown="return (event.keyCode!=13);" CssClass="txtField" onkeyup="newProjectCustomerSlide()" OnChange="newProjectCustomerSlide()" runat="server" MaxLength="50"></asp:TextBox>
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblCustomerPhone" AssociatedControlID="txtCustomerPhone" runat="server" Text="Phone Number:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:TextBox ID="txtCustomerPhone" onkeydown="return (event.keyCode!=13);" CssClass="txtField txtZipPhone" onkeyup="newProjectCustomerSlide()" OnChange="newProjectCustomerSlide()" runat="server" MaxLength="10"></asp:TextBox>
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblCustomerCell" AssociatedControlID="txtCustomerCell" runat="server" Text="Cell Number:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:TextBox ID="txtCustomerCell" onkeydown="return (event.keyCode!=13);" CssClass="txtField txtZipPhone" onkeyup="newProjectCustomerSlide()" OnChange="newProjectCustomerSlide()" runat="server" MaxLength="10"></asp:TextBox>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                    </asp:Table>
                                </li>
                            </ul>            
                        </div>
                    </li> 

                    <%-- Existing Customer --%>
                    <li id="existingCustomerElement" runat="server">
                        <asp:RadioButton ID="radExistingCustomer" GroupName="question1" runat="server" OnClick="newProjectCustomerSlide()" />
                        <asp:Label ID="lblExistingCustomerRadio" AssociatedControlID="radExistingCustomer" runat="server"></asp:Label>
                        <asp:Label ID="lblExistingCustomer" AssociatedControlID="radExistingCustomer" runat="server" Text="Existing customer"></asp:Label>

                        <%-- Existing Customer Options --%>
                        <div class="toggleContent">
                            <ul>
                                <li>
                                    <asp:DropDownList ID="ddlExistingCustomer" OnChange="newProjectCustomerSlide()" GroupName="question1" runat="server" />
                                    <!-- DataTextField="percentage" DataValueField="id" DataSourceId="sds_Items" in case we decide to data-bind -->
                                </li>
                            </ul>            
                        </div> 
                    </li> 

                    <%-- No Customer --%>
                    <li>
                        <asp:RadioButton ID="radNoCustomer" GroupName="question1" runat="server" OnClick="newProjectCustomerSlide()" />
                        <asp:Label ID="lblNoCustomerRadio" AssociatedControlID="radNoCustomer" runat="server"></asp:Label>
                        <asp:Label ID="lblNoCustomer" AssociatedControlID="radNoCustomer" runat="server" Text="No customer"></asp:Label>                        
                    </li> 
                </ul> 

                <asp:Button ID="btnQuestion1" Enabled="false" CssClass="btnSubmit float-right slidePanel" data-slide="#tagSlide" runat="server" Text="Next Question" />

            </div>             

            <%-- Slide 2 - Project Name --%>
            <div id="tagSlide" class="slide">
                
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
                                    <asp:TextBox ID="txtProjectName" onkeydown="return (event.keyCode!=13);" CssClass="txtField txtInput" onkeyup="newProjectTagSlide()" runat="server" MaxLength="50"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </li>

                </ul>

                <asp:Button ID="btnQuestion2" Enabled = "false" CssClass="btnSubmit float-right slidePanel" data-slide="#typeSlide" runat="server" Text="Next Question" />
                
            </div> 

            <%-- Slide 3 - Project Type --%>
            <div id="typeSlide" class="slide">
                <h1>
                    <asp:Label ID="lblQuestion3" runat="server" Text="What type of project would you like to create?"></asp:Label>
                </h1>         
                                
                <%-- Project Type Options--%>   
                <ul class="toggleOptions">
                    <%-- Sunroom --%>
                    <li>
                        <asp:RadioButton ID="radProjectSunroom" GroupName="projectType" runat="server" />
                        <asp:Label ID="lblProjectSunroomRadio" AssociatedControlID="radProjectSunroom" runat="server"></asp:Label>
                        <asp:Label ID="lblProjectSunroom" AssociatedControlID="radProjectSunroom" runat="server" Text="Sunroom"></asp:Label>
           
                        <div class="toggleContent">
                            <ul>
                                <li>
                                    <asp:RadioButton ID="radSunroomModel100" OnClick="newProjectTypeSlide()" GroupName="sunroomModel" runat="server" />
                                    <asp:Label ID="lblSunroomModel100Radio" AssociatedControlID="radSunroomModel100" runat="server"></asp:Label>
                                    <asp:Label ID="lblSunroomModel100" AssociatedControlID="radSunroomModel100" runat="server" Text="Model 100"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="radSunroomModel200" OnClick="newProjectTypeSlide()" GroupName="sunroomModel" runat="server" />
                                    <asp:Label ID="lblSunroomModel200Radio" AssociatedControlID="radSunroomModel200" runat="server"></asp:Label>
                                    <asp:Label ID="lblSunroomModel200" AssociatedControlID="radSunroomModel200" runat="server" Text="Model 200"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="radSunroomModel300" OnClick="newProjectTypeSlide()" GroupName="sunroomModel" runat="server" />
                                    <asp:Label ID="lblSunroomModel300Radio" AssociatedControlID="radSunroomModel300" runat="server"></asp:Label>
                                    <asp:Label ID="lblSunroomModel300" AssociatedControlID="radSunroomModel300" runat="server" Text="Model 300"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="radSunroomModel400" OnClick="newProjectTypeSlide()" GroupName="sunroomModel" runat="server" />
                                    <asp:Label ID="lblSunroomModel400Radio" AssociatedControlID="radSunroomModel400" runat="server"></asp:Label>
                                    <asp:Label ID="lblSunroomModel400" AssociatedControlID="radSunroomModel400" runat="server" Text="Model 400"></asp:Label>
                                </li>
                                <li>
                                    <asp:CheckBox ID="chkSunroomFoamPanels" runat="server" onclick="isFoamProtected()" />
                                    <asp:Label ID="lblSunroomFoamPanelsCheck" AssociatedControlID="chkSunroomFoamPanels" runat="server"></asp:Label>
                                    <asp:Label ID="lblSunroomFoamPanels" AssociatedControlID="chkSunroomFoamPanels" runat="server" Text=" Foam Panels"></asp:Label>
                                </li>
                            </ul>            
                        </div>
                    </li>

                    <%-- Walls --%>
                    <li>
                        <asp:RadioButton ID="radProjectWalls" GroupName="projectType" runat="server" />
                        <asp:Label ID="lblProjectWallsRadio" AssociatedControlID="radProjectWalls" runat="server"></asp:Label>
                        <asp:Label ID="lblProjectWalls" AssociatedControlID="radProjectWalls" runat="server" Text="Enclosure System (Walls Only)"></asp:Label>

                        <div class="toggleContent">
                            <ul class="checkboxes">
                                <li>
                                    <asp:RadioButton ID="radWallsModel100" OnClick="newProjectTypeSlide()" GroupName="sunroomModel" runat="server" />
                                    <asp:Label ID="lblWallsModel100Radio" AssociatedControlID="radWallsModel100" runat="server"></asp:Label>
                                    <asp:Label ID="lblWallsModel100" AssociatedControlID="radWallsModel100" runat="server" Text="Model 100"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="radWallsModel200" OnClick="newProjectTypeSlide()" GroupName="sunroomModel" runat="server" />
                                    <asp:Label ID="lblWallsModel200Radio" AssociatedControlID="radWallsModel200" runat="server"></asp:Label>
                                    <asp:Label ID="lblWallsModel200" AssociatedControlID="radWallsModel200" runat="server" Text="Model 200"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="radWallsModel300" OnClick="newProjectTypeSlide()" GroupName="sunroomModel" runat="server" />
                                    <asp:Label ID="lblWallsModel300Radio" AssociatedControlID="radWallsModel300" runat="server"></asp:Label>
                                    <asp:Label ID="lblWallsModel300" AssociatedControlID="radWallsModel300" runat="server" Text="Model 300"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="radWallsModel400" OnClick="newProjectTypeSlide()" GroupName="sunroomModel" runat="server" />
                                    <asp:Label ID="lblWallsModel400Radio" AssociatedControlID="radWallsModel400" runat="server"></asp:Label>
                                    <asp:Label ID="lblWallsModel400" AssociatedControlID="radWallsModel400" runat="server" Text="Model 400"></asp:Label>
                                </li>
                                <li>
                                    <asp:Label ID="lblWallNumber" runat="server" Text="Number of walls:"></asp:Label>
                                    <asp:TextBox ID="txtWallNumber" runat="server" Text="1" onkeyup="newProjectTypeSlide()"></asp:TextBox>
                                </li>
                                <li>
                                    <asp:CheckBox ID="chkWallFoamPanels" runat="server" onclick="isFoamProtected()" />
                                    <asp:Label ID="lblWallFoamPanelsCheck" AssociatedControlID="chkWallFoamPanels" runat="server"></asp:Label>
                                    <asp:Label ID="lblWallFoamPanels" AssociatedControlID="chkWallFoamPanels" runat="server" Text=" Foam Panels"></asp:Label>
                                </li>
                            </ul>            
                        </div>
                    </li> 

                    <%-- Window Only --%>
                    <li>
                        <asp:RadioButton ID="radProjectWindows" OnClick="newProjectTypeSlide()" GroupName="projectType" runat="server" />
                        <asp:Label ID="lblProjectWindowsRadio" AssociatedControlID="radProjectWindows" runat="server"></asp:Label>
                        <asp:Label ID="lblProjectWindows" AssociatedControlID="radProjectWindows" runat="server" Text="Windows Only"></asp:Label>
                    </li> 
                    
                    <%-- Door only --%>
                    <li>
                        <asp:RadioButton ID="radProjectDoors" OnClick="newProjectTypeSlide()" GroupName="projectType" runat="server" />
                        <asp:Label ID="lblProjectDoorsRadio" AssociatedControlID="radProjectDoors" runat="server"></asp:Label>
                        <asp:Label ID="lblProjectDoors" AssociatedControlID="radProjectDoors" runat="server" Text="Doors Only"></asp:Label>
                    </li>
                    
                    <%-- Floor only --%>
                    <li>
                        <asp:RadioButton ID="radProjectFlooring" OnClick="newProjectTypeSlide()" GroupName="projectType" runat="server" />
                        <asp:Label ID="lblProjectFlooringRadio" AssociatedControlID="radProjectFlooring" runat="server"></asp:Label>
                        <asp:Label ID="lblProjectFlooring" AssociatedControlID="radProjectFlooring" runat="server" Text="Flooring"></asp:Label>
                    </li>
                    
                    <%-- Roof only --%>
                    <li>
                        <asp:RadioButton ID="radProjectRoof" OnClick="newProjectTypeSlide()" GroupName="projectType" runat="server" />
                        <asp:Label ID="lblProjectRoofRadio" AssociatedControlID="radProjectRoof" runat="server"></asp:Label>
                        <asp:Label ID="lblProjectRoof" AssociatedControlID="radProjectRoof" runat="server" Text="Roof System Only"></asp:Label>
                    </li>  
                                        
                    <%-- Showroom --%>                 
                    <%--<li>
                        <asp:RadioButton ID="radSunroomModelShowroom" OnClick="newProjectTypeSlide()" GroupName="projectType" runat="server" />
                        <asp:Label ID="lblSunroomModelShowroomRadio" AssociatedControlID="radSunroomModelShowroom" runat="server"></asp:Label>
                        <asp:Label ID="lblSunroomModelShowroom" AssociatedControlID="radSunroomModelShowroom" runat="server" Text="Display Room"></asp:Label>

                        <div class="toggleContent">
                            <ul class="checkboxes">
                                <li>
                                    <asp:RadioButton ID="radShowroomModel100" OnClick="newProjectTypeSlide()" GroupName="sunroomModel" runat="server" />
                                    <asp:Label ID="lblShowroomModel100" AssociatedControlID="radShowroomModel100" runat="server"></asp:Label>
                                    <asp:Label ID="lblShowroomModel100Radio" AssociatedControlID="radShowroomModel100" runat="server" Text="Model 100"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="radShowroomModel200" OnClick="newProjectTypeSlide()" GroupName="sunroomModel" runat="server" />
                                    <asp:Label ID="lblShowroomModel200" AssociatedControlID="radShowroomModel200" runat="server"></asp:Label>
                                    <asp:Label ID="lblShowroomModel200Radio" AssociatedControlID="radShowroomModel200" runat="server" Text="Model 200"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="radShowroomModel300" OnClick="newProjectTypeSlide()" GroupName="sunroomModel" runat="server" />
                                    <asp:Label ID="lblShowroomModel300" AssociatedControlID="radShowroomModel300" runat="server"></asp:Label>
                                    <asp:Label ID="lblShowroomModel300Radio" AssociatedControlID="radShowroomModel300" runat="server" Text="Model 300"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="radShowroomModel400" OnClick="newProjectTypeSlide()" GroupName="sunroomModel" runat="server" />
                                    <asp:Label ID="lblShowroomModel400" AssociatedControlID="radShowroomModel400" runat="server"></asp:Label>
                                    <asp:Label ID="lblShowroomModel400Radio" AssociatedControlID="radShowroomModel400" runat="server" Text="Model 400"></asp:Label>
                                </li>
                            </ul>            
                        </div>
                    </li>--%>
                    
                    <%-- Component Order --%>
                    <li>
                        <asp:RadioButton ID="radProjectComponents" GroupName="projectType" runat="server"  OnClick="goComponents()"/>
                        <asp:Label ID="lblProjectComponentsRadio" AssociatedControlID="radProjectComponents" runat="server"></asp:Label>
                        <asp:Label ID="lblProjectComponents" AssociatedControlID="radProjectComponents" runat="server" Text="Components"></asp:Label>
                    </li> 
                </ul> 

                <asp:Button ID="btnQuestion3" Enabled="true" CssClass="btnSubmit float-right slidePanel" data-slide="#floorSlide" runat="server" Text="Next Question" />
                <asp:Button ID="btnQuestion3_OrderOnly" Enabled="true" CssClass="btnSubmit float-right slidePanel" OnClick="btnQuestion3_OrderOnly_Click" runat="server" Text="Next Question" />
            </div>            

            <%-- Slide 5 - Prefabricated Floors --%>
            <div id="floorSlide" class="slide">                
                <h1>
                    <asp:Label ID="lblPrefabFloor" runat="server" Text="Would you like a prefabricated floor?"></asp:Label>
                </h1> 

                <ul class="toggleOptions">
                    <li>
                        <asp:RadioButton ID="radPrefabFloorYes" OnClick="newProjectFloorSlide()" GroupName="floor" runat="server" />
                        <asp:Label ID="lblPrefabFloorYesRadio" AssociatedControlID="radPrefabFloorYes" runat="server"></asp:Label>
                        <asp:Label ID="lblPrefabFloorYes" AssociatedControlID="radPrefabFloorYes" runat="server" Text="Yes"></asp:Label>
                    </li>

                    <li>
                        <asp:RadioButton ID="radPrefabFloorNo" OnClick="newProjectFloorSlide()" GroupName="floor" runat="server" />
                        <asp:Label ID="lblPrefabFloorNoRadio" AssociatedControlID="radPrefabFloorNo" runat="server"></asp:Label>
                        <asp:Label ID="lblPrefabFloorNo" AssociatedControlID="radPrefabFloorNo" runat="server" Text="No"></asp:Label>
                    </li>

                </ul>

                <asp:Button ID="btnQuestion6" Enabled="false" CssClass="btnSubmit float-right slidePanel" data-slide="#roofSlide" runat="server" Text="Next Question" />
            </div> 

            <%-- Slide 6 - Roof Choice --%>
            <div id="roofSlide" class="slide">                
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
                                    <asp:RadioButton ID="radStudio" OnClick="newProjectRoofSlide()" GroupName="roofSub" runat="server" />
                                    <asp:Label ID="lblStudioRadio" AssociatedControlID="radStudio" runat="server"></asp:Label>
                                    <asp:Label ID="lblStudio" AssociatedControlID="radStudio" runat="server" Text="Studio (Mono Slope)"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="radDealerGable" OnClick="newProjectRoofSlide()" GroupName="roofSub" runat="server" />
                                    <asp:Label ID="lblDealerGableRadio" AssociatedControlID="radDealerGable" runat="server"></asp:Label>
                                    <asp:Label ID="lblDealerGable" AssociatedControlID="radDealerGable" runat="server" Text="Traditional Gable (Dealer to supply lumber)"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="radSunspaceGable" OnClick="newProjectRoofSlide()" GroupName="roofSub" runat="server" />
                                    <asp:Label ID="lblSunspaceGableRadio" AssociatedControlID="radSunspaceGable" runat="server"></asp:Label>
                                    <asp:Label ID="lblSunspaceGable" AssociatedControlID="radSunspaceGable" runat="server" Text="Manufactured Gable (Dual Slope front wall)"></asp:Label>
                                </li>
                                <li>
                                    <asp:Label ID="lblSoffitLength" runat="server" Text="Soffit Length:"></asp:Label>
                                    <asp:TextBox ID="txtSoffitLength" onkeydown="return (event.keyCode!=13);" CssClass="txtField txtInput" Width="35" onkeyup="newProjectRoofSlide()" runat="server" Text="0"></asp:TextBox>
                                </li>
                            </ul>
                        </div>
                    </li>

                    <li>
                        <asp:RadioButton ID="radRoofNo" OnClick="newProjectRoofSlide()" GroupName="roof" runat="server" />
                        <asp:Label ID="lblRoofNoRadio" AssociatedControlID="radRoofNo" runat="server"></asp:Label>
                        <asp:Label ID="lblRoofNo" AssociatedControlID="radRoofNo" runat="server" Text="No"></asp:Label>
                    </li>

                </ul>

                <asp:Button ID="btnQuestion7" Enabled="false" CssClass="btnSubmit float-right slidePanel" data-slide="#layoutSlide" runat="server" Text="Next Question" />
            </div> 

            <%-- Slide 7 - Layout --%>
            <div id="layoutSlide" class="slide">                
                <h1>
                    <asp:Label ID="lblLayout" runat="server" Text="Please choose a sunroom layout."></asp:Label>
                </h1> 

                <ul class="toggleOptions">
                    <li>
                        <asp:Table runat="server" ID="tblSunroomLayout" CssClass="tblSunroomLayout">
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:RadioButton ID="radPreset1" OnClick="newProjectLayoutSlide()" GroupName="layout" runat="server" />                        
                                    <asp:Label ID="lblPreset1Radio" AssociatedControlID="radPreset1" runat="server"></asp:Label>
                                    <asp:Image ID="imbPreset1" GroupName="layout" AssociatedControlID="radPreset1" AlternateText="missing preset image" ImageUrl="./images/layout/Preset1.png" runat="server" />  
                                </asp:TableCell>

                                <asp:TableCell>
                                    <asp:RadioButton ID="radPreset2" OnClick="newProjectLayoutSlide()" GroupName="layout" runat="server" />                        
                                    <asp:Label ID="lblPreset2Radio" AssociatedControlID="radPreset2" runat="server"></asp:Label>
                                    <asp:Image ID="imbPreset2" GroupName="layout" AssociatedControlID="radPreset2" AlternateText="missing preset image" ImageUrl="./images/layout/Preset2.png" runat="server" /> 
                                </asp:TableCell>

                                <asp:TableCell>
                                    <asp:RadioButton ID="radPreset3" OnClick="newProjectLayoutSlide()" GroupName="layout" runat="server" />                        
                                    <asp:Label ID="lblPreset3Radio" AssociatedControlID="radPreset3" runat="server"></asp:Label>
                                    <asp:Image ID="imbPreset3" GroupName="layout" AssociatedControlID="radPreset3" AlternateText="missing preset image" ImageUrl="./images/layout/Preset3.png" runat="server" />  
                                </asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow>
                                <asp:TableCell ID="tbcPreset4" runat="server">
                                    <asp:RadioButton ID="radPreset4" OnClick="newProjectLayoutSlide()" GroupName="layout" runat="server" />                        
                                    <asp:Label ID="lblPreset4Radio" AssociatedControlID="radPreset4" runat="server"></asp:Label>
                                    <asp:Image ID="imbPreset4" GroupName="layout" AssociatedControlID="radPreset4" AlternateText="missing preset image" ImageUrl="./images/layout/Preset4.png" runat="server" />  
                                </asp:TableCell>

                                <asp:TableCell>
                                    <asp:RadioButton ID="radPreset5" OnClick="newProjectLayoutSlide()" GroupName="layout" runat="server" />                        
                                    <asp:Label ID="lblPreset5Radio" AssociatedControlID="radPreset5" runat="server"></asp:Label>
                                    <asp:Image ID="imbPreset5" GroupName="layout" AssociatedControlID="radPreset5" AlternateText="missing preset image" ImageUrl="./images/layout/Preset5.png" runat="server" /> 
                                </asp:TableCell>

                                <asp:TableCell>
                                    <asp:RadioButton ID="radPreset6" OnClick="newProjectLayoutSlide()" GroupName="layout" runat="server" />                        
                                    <asp:Label ID="lblPreset6Radio" AssociatedControlID="radPreset6" runat="server"></asp:Label>
                                    <asp:Image ID="imbPreset6" GroupName="layout" AssociatedControlID="radPreset6" AlternateText="missing preset image" ImageUrl="./images/layout/Preset6.png" runat="server" />                  
                                </asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow>
                                <asp:TableCell ID="tbcPreset7" runat="server">
                                    <asp:RadioButton ID="radPreset7" OnClick="newProjectLayoutSlide()" GroupName="layout" runat="server" />                        
                                    <asp:Label ID="lblPreset7Radio" AssociatedControlID="radPreset7" runat="server"></asp:Label>
                                    <asp:Image ID="imbPreset7" GroupName="layout" AssociatedControlID="radPreset7" AlternateText="missing preset image" ImageUrl="./images/layout/Preset7.png" runat="server" />  
                                </asp:TableCell>

                                <asp:TableCell>
                                    <asp:RadioButton ID="radPreset8" OnClick="newProjectLayoutSlide()" GroupName="layout" runat="server" />                        
                                    <asp:Label ID="lblPreset8Radio" AssociatedControlID="radPreset8" runat="server"></asp:Label>
                                    <asp:Image ID="imbPreset8" GroupName="layout" AssociatedControlID="radPreset8" AlternateText="missing preset image" ImageUrl="./images/layout/Preset8.png" runat="server" />  
                                </asp:TableCell>

                                <asp:TableCell>
                                     <asp:RadioButton ID="radPreset9" OnClick="newProjectLayoutSlide()" GroupName="layout" runat="server" />                        
                                    <asp:Label ID="lblPreset9Radio" AssociatedControlID="radPreset9" runat="server"></asp:Label>
                                    <asp:Image ID="imbPreset9" GroupName="layout" AssociatedControlID="radPreset9" AlternateText="missing preset image" ImageUrl="./images/layout/Preset9.png" runat="server" />  
                                </asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:RadioButton ID="radPreset10" OnClick="newProjectLayoutSlide()" GroupName="layout" runat="server" />                        
                                    <asp:Label ID="lblPreset10Radio" AssociatedControlID="radPreset10" runat="server"></asp:Label>
                                    <asp:Image ID="imbPreset10" GroupName="layout" AssociatedControlID="radPreset10" AlternateText="missing preset image" ImageUrl="./images/layout/Preset10.png" runat="server" />  
                                </asp:TableCell>

                                <asp:TableCell>
                                     <asp:RadioButton ID="radPresetC1" OnClick="newProjectLayoutSlide()" GroupName="layout" runat="server" />                        
                                    <asp:Label ID="lblPresetC1Radio" AssociatedControlID="radPresetC1" runat="server"></asp:Label>
                                    <asp:Image ID="imbPresetC1" GroupName="layout" AssociatedControlID="radPresetC1" AlternateText="missing preset image" ImageUrl="./images/layout/PresetC1.png" runat="server" />
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>         
                    </li>
                    <br />
                    <asp:CheckBox ID="chkMirrored" runat="server" onclick="toggleMirrored()" />
                    <asp:Label ID="lblMirroredCheck" AssociatedControlID="chkMirrored" runat="server"></asp:Label>
                    <asp:Label ID="lblMirrored" AssociatedControlID="chkMirrored" Text="Mirror images left to right" runat="server">

                    </asp:Label>
                    <br />
                    <asp:Label ID="lblFinished" Text="Sunroom details complete, next step: Walls." runat="server"></asp:Label>
                    <asp:Button ID="btnQuestion8" Enabled="false" CssClass="btnSubmit float-right slidePanel" Text="Confirm all selections" runat="server" OnClientClick="newProjectLayoutSlide()" OnClick="btnLayout_Click"/>

                </ul>
            </div> 
            
            <%-- Database Connection Source --%>
            <asp:SqlDataSource ID="sdsCustomers" runat="server" ConnectionString="<%$ ConnectionStrings:sunspaceDealerDesktopConnectionString %>" SelectCommand="SELECT * FROM [customers]"></asp:SqlDataSource>            
        </div>
    </div>     

    <%-- SLIDE PAGING (QUESTION NAVIGATION)
    ======================================== --%>
    <div id="sidebar">
  
            <div id="paging"> 
                <h2>Project Specifications</h2>
                Click data to return to that slide
                <ul>
                    <div style="display: none" id="pagerOne">
                        <li>
                                <a href="#" data-slide="#customerSlide" class="slidePanel">
                                    <asp:Label ID="lblSpecsProjectType" runat="server" Text="New/Existing Customer"></asp:Label>
                                    <asp:Label ID="lblSpecsProjectTypeAnswer" runat="server" Text="Customer Answer"></asp:Label>
                                </a>
                        </li>
                    </div>

                    <div style="display: none" id="pagerTwo">
                        <li>
                                <a href="#" data-slide="#tagSlide" class="slidePanel">
                                    <asp:Label ID="lblProjectNamePager" runat="server" Text="Project Name"></asp:Label>
                                    <asp:Label ID="lblProjectNameAnswer" runat="server" Text="Question 2 Answer"></asp:Label>
                                </a>
                        </li>
                    </div>

                    <div style="display: none" id="pagerThree">
                        <li>
                                <a href="#" data-slide="#typeSlide" class="slidePanel">
                                    <asp:Label ID="lblProjectType" runat="server" Text="Type of project"></asp:Label>
                                    <asp:Label ID="lblProjectTypeAnswer" runat="server" Text="Question 3 Answer"></asp:Label>
                                </a>
                        </li>
                    </div>
                  
                <div style="display: none" id="pagerSix">
                    <li>
                            <a href="#" data-slide="#floorSlide" class="slidePanel">
                                <asp:Label ID="Label1" runat="server" Text="Prefab floor"></asp:Label>
                                <asp:Label ID="lblQuestion6PagerAnswer" runat="server" Text="Question 6 Answer"></asp:Label>
                            </a>
                    </li>
                </div>

                <div style="display: none" id="pagerSeven">                
                    <li>
                            <a href="#" data-slide="#roofSlide" class="slidePanel">
                                <asp:Label ID="Label3" runat="server" Text="Roof"></asp:Label>
                                <asp:Label ID="lblQuestion7PagerAnswer" runat="server" Text="Question 7 Answer"></asp:Label>
                                <asp:Label ID="lblQuestion7PagerSecondAnswer" runat="server" Text=""></asp:Label>
                            </a>
                    </li>
                </div>

                <div style="display: none" id="pagerEight">
                    <li>
                            <a href="#" data-slide="#layoutSlide" class="slidePanel">
                                <asp:Label ID="Label5" runat="server" Text="Layout"></asp:Label>
                                <asp:Label ID="lblQuestion8PagerAnswer" runat="server" Text="Question 8 Answer"></asp:Label>
                            </a>
                    </li>
                </div>
            </ul>    
            </div> 


        <textarea id="txtErrorMessage" class="txtErrorMessage" disabled="disabled" rows="5" runat="server"></textarea>
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
    <input id="hidWallNumber" type="hidden" runat="server" />

    <input id="hidKneewallType" type="hidden" runat="server" />
    <input id="hidKneewallHeight" type="hidden" runat="server" />
    <input id="hidKneewallTint" type="hidden" runat="server" />
    <input id="hidTransomType" type="hidden" runat="server" />
    <input id="hidTransomHeight" type="hidden" runat="server" />
    <input id="hidTransomTint" type="hidden" runat="server" />

    <input id="hidFramingColour" type="hidden" runat="server" />
    <input id="hidInteriorColour" type="hidden" runat="server" />
    <input id="hidInteriorSkin" type="hidden" runat="server" />
    <input id="hidExteriorColour" type="hidden" runat="server" />
    <input id="hidExteriorSkin" type="hidden" runat="server" />

    <input id="hidFoamProtected" type="hidden" runat="server" value="No"/>

    <input id="hidPrefabFloor" type="hidden" runat="server" />

    <input id="hidRoof" type="hidden" runat="server" />
    <input id="hidRoofType" type="hidden" runat="server" />

    <input id="hidLayoutSelection" type="hidden" runat="server" />

    <input id="hidSoffitLength" type="hidden" runat="server" />

    <%-- end hidden divs --%>    

    <script>
        $(function () {
            $('.ulNavMain').children('a').removeClass('active');
            $('#lnkMainNavNewProject').addClass('active');
        });
    </script>
</asp:Content>

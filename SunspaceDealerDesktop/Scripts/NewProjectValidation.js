/*
    FileName: Validation.js
    Author: Kyle Brougham
    DateCreated: June 25, 2013

    This file contains client-side validation functions for New Project navigation.
*/

function newProjectCheckQuestion1() {
    //disable 'next slide' button until after validation
    document.getElementById('MainContent_btnQuestion1').disabled = true;

    //if they select new customer
    if ($('#MainContent_radNewCustomer').is(':checked')) {
        document.getElementById("MainContent_hidFirstName").value = $('#MainContent_txtCustomerFirstName').val();
        document.getElementById("MainContent_hidLastName").value = $('#MainContent_txtCustomerLastName').val();
        document.getElementById("MainContent_hidAddress").value = $('#MainContent_txtCustomerAddress').val();
        document.getElementById("MainContent_hidCity").value = $('#MainContent_txtCustomerCity').val();
        document.getElementById("MainContent_hidZip").value = $('#MainContent_txtCustomerZip').val();
        document.getElementById("MainContent_hidPhone").value = $('#MainContent_txtCustomerPhone').val();

        //Make sure the text boxes aren't blank before manually checking zip/postal and phone
        if (document.getElementById("MainContent_hidFirstName").value != "" &&
            document.getElementById("MainContent_hidLastName").value != "" &&
            document.getElementById("MainContent_hidAddress").value != "" &&
            document.getElementById("MainContent_hidCity").value != "") {

            //having troubles checking .value.length, so setting .value into a variable
            var lengthCheck = document.getElementById("MainContent_hidPhone").value;

            //only check if a full 10digit number is entered
            if (lengthCheck.length == 10) {
                //validatePhone function returns an error message, blank if valid
                console.log();
                var validPhone = validatePhone(document.getElementById("MainContent_hidPhone").value);
            }

            //same troubles as before, checking .value.length
            var zipCode = document.getElementById("MainContent_hidZip").value;

            //if zip code is not valid numeric, or it is not 5 digits, it is not valid
            if (isNaN(zipCode) || zipCode.length < 5) {

            }
            else {

            }

            //only fully valid if no error message was returned
            if (validPhone = "") {
                //Set answer to 'new' on side pager and enable button
                $('#MainContent_lblSpecsProjectTypeAnswer').text("New");
                document.getElementById('pagerOne').style.display = "inline";
                document.getElementById('MainContent_btnQuestion1').disabled = false;
            }
        }
        else {
            //error styling or something
        }
    }
    //if they select existing customer
    else if ($('#MainContent_radExistingCustomer').is(':checked')) {
        document.getElementById("MainContent_ddlExistingCustomer").value = $('#MainContent_ddlCustomerFirstName').val(); //what is this doing? ~Kyle

        //if selected value from dropdown is not the generic, it is a valid choice
        if (document.getElementById("MainContent_ddlExistingCustomer").value != "Choose a Customer...") {
            //valid, so update pager and enable button
            $('#MainContent_lblSpecsProjectTypeAnswer').text("Existing");
            document.getElementById('pagerOne').style.display = "inline";
            document.getElementById('MainContent_btnQuestion1').disabled = false;
        }
    }

    return false;
}

function newProjectCheckQuestion2() {
    //disable 'next slide' button until after validation
    document.getElementById('MainContent_btnQuestion2').disabled = true;

    document.getElementById("MainContent_hidProjectTag").value = $('#MainContent_txtProjectName').val();

    if (document.getElementById("MainContent_hidProjectTag").value != "") {
        //valid, so update pager and enable button
        $('#MainContent_lblProjectTagAnswer').text(document.getElementById("MainContent_hidProjectTag").value);
        document.getElementById('pagerTwo').style.display = "inline";
        document.getElementById('MainContent_btnQuestion2').disabled = false;
    }
    else {
        //error styling or something
    }
    return false;
}

function newProjectCheckQuestion3() {
    document.getElementById('MainContent_btnQuestion3').disabled = true;

    //if they pick sunroom
    if ($('#MainContent_radProjectSunroom').is(':checked')) {
        //They check one of 5 model types
        //update pager, enable button, and update hidden value
        //corresponding to selected model #
        if ($('#MainContent_radSunroomModel100').is(':checked')) {
            document.getElementById("MainContent_hidModelNumber").value = "100";
            document.getElementById('pagerThree').style.display = "inline";
            document.getElementById('MainContent_btnQuestion3').disabled = false;
        }
        else if ($('#MainContent_radSunroomModel200').is(':checked')) {
            document.getElementById("MainContent_hidModelNumber").value = "200";
            document.getElementById('pagerThree').style.display = "inline";
            document.getElementById('MainContent_btnQuestion3').disabled = false;
        }
        else if ($('#MainContent_radSunroomModel300').is(':checked')) {
            document.getElementById("MainContent_hidModelNumber").value = "300";
            document.getElementById('pagerThree').style.display = "inline";
            document.getElementById('MainContent_btnQuestion3').disabled = false;
        }
        else if ($('#MainContent_radSunroomModel400').is(':checked')) {
            document.getElementById("MainContent_hidModelNumber").value = "400";
            document.getElementById('pagerThree').style.display = "inline";
            document.getElementById('MainContent_btnQuestion3').disabled = false;
        }
        else if ($('#MainContent_radSunroomModelShowroom').is(':checked')) {
            document.getElementById("MainContent_hidModelNumber").value = "Showroom";
            document.getElementById('pagerThree').style.display = "inline";
            document.getElementById('MainContent_btnQuestion3').disabled = false;
        }

        //update hidden value for type, and display pager message based on the now
        //two hidden values type and model#
        document.getElementById("MainContent_hidProjectType").value = "Sunroom";
        $('#MainContent_lblProjectTypeAnswer').text(document.getElementById("MainContent_hidProjectType").value + " of Model " + document.getElementById("MainContent_hidModelNumber").value);
    }
    return false;
}

function newProjectCheckQuestion4() {
    document.getElementById('MainContent_btnQuestion4').disabled = true;
    //overall error check boolean
    var optionChecksPassed = false;

    //Only run validation if a number is entered and values selected
    if (document.getElementById("MainContent_txtKneewallHeight").value != "" &&
        document.getElementById("MainContent_ddlKneewallType").value != "" &&
        document.getElementById("MainContent_ddlKneewallColour").value != "") {

        //only requirement on height at this moment is that it is a valid number
        if (isNaN(document.getElementById("MainContent_txtKneewallHeight").value)) {
            //kneewall height error handling
        }
        else {
            //by default, preferences will populate a selected value, but as long as a number is entered, and
            //dropdowns have a selected value, its valid, set check bool to true, update hidden values
            document.getElementById("MainContent_hidKneewallHeight").value = document.getElementById("MainContent_txtKneewallHeight").value;
            document.getElementById("MainContent_hidKneewallType").value = document.getElementById("MainContent_ddlKneewallType").value;
            document.getElementById("MainContent_hidKneewallColour").value = document.getElementById("MainContent_ddlKneewallColour").value;
            optionChecksPassed = true;
        }
    }
    else {
        optionChecksPassed = false;
        //kneewall errors
    }

    //similar checks as above for transom, update hidden values
    if (document.getElementById("MainContent_txtTransomHeight").value != "" &&
        document.getElementById("MainContent_ddlTransomType").value != "" &&
        document.getElementById("MainContent_ddlTransomColour").value != "") {

        if (isNaN(document.getElementById("MainContent_txtTransomHeight").value)) {
            console.log("Invalid transom height");
        }
        else {
            document.getElementById("MainContent_hidTransomHeight").value = document.getElementById("MainContent_txtTransomHeight").value;
            document.getElementById("MainContent_hidTransomType").value = document.getElementById("MainContent_ddlTransomType").value;
            document.getElementById("MainContent_hidTransomColour").value = document.getElementById("MainContent_ddlTransomColour").value;
            optionChecksPassed = true;
        }

    }
    else {
        optionChecksPassed = false;
        //transom error styling
    }

    //make sure skins and colours are selected, update hidden values
    if (document.getElementById("MainContent_ddlInteriorColour").value != "" &&
        document.getElementById("MainContent_ddlInteriorSkin").value != "" &&
        document.getElementById("MainContent_ddlExteriorColour").value != "" &&
        document.getElementById("MainContent_ddlExteriorSkin").value != "") {

        document.getElementById("MainContent_hidInteriorColour").value = document.getElementById("MainContent_ddlInteriorColour").value;
        document.getElementById("MainContent_hidInteriorSkin").value = document.getElementById("MainContent_ddlInteriorSkin").value;
        document.getElementById("MainContent_hidExteriorColour").value = document.getElementById("MainContent_ddlExteriorColour").value;
        document.getElementById("MainContent_hidExteriorSkin").value = document.getElementById("MainContent_ddlExteriorSkin").value;
        optionChecksPassed = true;
    }
    else {
        optionChecksPassed = false;
        //framing error styling
    }

    if (optionChecksPassed) {
        document.getElementById('MainContent_btnQuestion4').disabled = false;
        $('#MainContent_lblQuestion4PagerAnswer').text("Entry Complete");
        document.getElementById('pagerFour').style.display = "inline";
    }
    document.getElementById('MainContent_btnQuestion4').disabled = false; //autoenable, remove when dropdowns are populated
    return false;
}

function newProjectCheckQuestion5() {
    document.getElementById('MainContent_btnQuestion5').disabled = true;

    //confirm that an answer is selected, and update hidden values, and pager as needed
    if ($('#MainContent_radFoamProtectedYes').is(':checked')) {
        document.getElementById('MainContent_btnQuestion5').disabled = false;
        $('#MainContent_lblQuestion5PagerAnswer').text("Yes");
        document.getElementById('pagerFive').style.display = "inline";
        document.getElementById("MainContent_hidFoamProtected").value = "Yes";
    }
    else if ($('#MainContent_radFoamProtectedNo').is(':checked')) {
        document.getElementById('MainContent_btnQuestion5').disabled = false;
        $('#MainContent_lblQuestion5PagerAnswer').text("No");
        document.getElementById('pagerFive').style.display = "inline";
        document.getElementById("MainContent_hidFoamProtected").value = "No";
    }
    else {
        //no selection, errors
    }

    return false;
}

function newProjectCheckQuestion6() {
    document.getElementById('MainContent_btnQuestion6').disabled = true;

    //confirm that an answer is selected, and update hidden values, and pager as needed
    if ($('#MainContent_radPrefabFloorYes').is(':checked')) {
        document.getElementById('MainContent_btnQuestion6').disabled = false;
        $('#MainContent_lblQuestion6PagerAnswer').text("Yes");
        document.getElementById('pagerSix').style.display = "inline";
        document.getElementById("MainContent_hidPrefabFloor").value = "Yes";
    }
    else if ($('#MainContent_radPrefabFloorNo').is(':checked')) {
        document.getElementById('MainContent_btnQuestion6').disabled = false;
        $('#MainContent_lblQuestion6PagerAnswer').text("No");
        document.getElementById('pagerSix').style.display = "inline";
        document.getElementById("MainContent_hidPrefabFloor").value = "No";
    }
    else {
        //no selection, errors
    }

    return false;
}

function newProjectCheckQuestion7() {
    document.getElementById('MainContent_btnQuestion7').disabled = true;

    //confirm that an answer is selected, and update hidden values, and pager as needed
    if ($('#MainContent_radRoofNo').is(':checked')) {
        document.getElementById('MainContent_btnQuestion7').disabled = false;
        $('#MainContent_lblQuestion7PagerAnswer').text("None");
        document.getElementById('pagerSeven').style.display = "inline";
        document.getElementById("MainContent_hidRoof").value = "No";
    }
    else if ($('#MainContent_radRoofYes').is(':checked')) {
        if ($('#MainContent_radStudio').is(':checked')) {
            document.getElementById('MainContent_btnQuestion7').disabled = false;
            $('#MainContent_lblQuestion7PagerAnswer').text("Studio");
            document.getElementById('pagerSeven').style.display = "inline";
            document.getElementById("MainContent_hidRoof").value = "Yes";
            document.getElementById("MainContent_hidRoofType").value = "Studio";
        }
        else if ($('#MainContent_radDealerGable').is(':checked')) {
            document.getElementById('MainContent_btnQuestion7').disabled = false;
            $('#MainContent_lblQuestion7PagerAnswer').text("Dealer Gable");
            document.getElementById('pagerSeven').style.display = "inline";
            document.getElementById("MainContent_hidRoof").value = "Yes";
            document.getElementById("MainContent_hidRoofType").value = "Dealer Gable";
        }
        else if ($('#MainContent_radSunspaceGable').is(':checked')) {
            document.getElementById('MainContent_btnQuestion7').disabled = false;
            $('#MainContent_lblQuestion7PagerAnswer').text("Sunspace Gable");
            document.getElementById('pagerSeven').style.display = "inline";
            document.getElementById("MainContent_hidRoof").value = "Yes";
            document.getElementById("MainContent_hidRoofType").value = "Sunspace Gable";
        }
        else {
            //no type selection, errors
        }
    }
    else {
        //no selection, errors
    }

    return false;
}

function newProjectCheckQuestion8() {
    document.getElementById('MainContent_btnQuestion8').disabled = true;

    //make sure at least one option is selected, update pager and hidden accordingly
    if ($('#MainContent_radPreset1').is(':checked')) {
        document.getElementById('MainContent_btnQuestion8').disabled = false;
        $('#MainContent_lblQuestion8PagerAnswer').text("Preset 1");
        document.getElementById('pagerEight').style.display = "inline";
        document.getElementById("MainContent_hidLayoutSelection").value = "1";
    }
    else if ($('#MainContent_radPreset2').is(':checked')) {
        document.getElementById('MainContent_btnQuestion8').disabled = false;
        $('#MainContent_lblQuestion8PagerAnswer').text("Preset 2");
        document.getElementById('pagerEight').style.display = "inline";
        document.getElementById("MainContent_hidLayoutSelection").value = "2";
    }
    else if ($('#MainContent_radPreset3').is(':checked')) {
        document.getElementById('MainContent_btnQuestion8').disabled = false;
        $('#MainContent_lblQuestion8PagerAnswer').text("Preset 3");
        document.getElementById('pagerEight').style.display = "inline";
        document.getElementById("MainContent_hidLayoutSelection").value = "3";
    }
    else if ($('#MainContent_radPreset4').is(':checked')) {
        document.getElementById('MainContent_btnQuestion8').disabled = false;
        $('#MainContent_lblQuestion8PagerAnswer').text("Preset 4");
        document.getElementById('pagerEight').style.display = "inline";
        document.getElementById("MainContent_hidLayoutSelection").value = "4";
    }
    else if ($('#MainContent_radPreset5').is(':checked')) {
        document.getElementById('MainContent_btnQuestion8').disabled = false;
        $('#MainContent_lblQuestion8PagerAnswer').text("Preset 5");
        document.getElementById('pagerEight').style.display = "inline";
        document.getElementById("MainContent_hidLayoutSelection").value = "5";
    }
    else if ($('#MainContent_radPreset6').is(':checked')) {
        document.getElementById('MainContent_btnQuestion8').disabled = false;
        $('#MainContent_lblQuestion8PagerAnswer').text("Preset 6");
        document.getElementById('pagerEight').style.display = "inline";
        document.getElementById("MainContent_hidLayoutSelection").value = "6";
    }
    else if ($('#MainContent_radPreset7').is(':checked')) {
        document.getElementById('MainContent_btnQuestion8').disabled = false;
        $('#MainContent_lblQuestion8PagerAnswer').text("Preset 7");
        document.getElementById('pagerEight').style.display = "inline";
        document.getElementById("MainContent_hidLayoutSelection").value = "7";
    }
    else if ($('#MainContent_radPreset8').is(':checked')) {
        document.getElementById('MainContent_btnQuestion8').disabled = false;
        $('#MainContent_lblQuestion8PagerAnswer').text("Preset 8");
        document.getElementById('pagerEight').style.display = "inline";
        document.getElementById("MainContent_hidLayoutSelection").value = "8";
    }
    else if ($('#MainContent_radPreset9').is(':checked')) {
        document.getElementById('MainContent_btnQuestion8').disabled = false;
        $('#MainContent_lblQuestion8PagerAnswer').text("Preset 9");
        document.getElementById('pagerEight').style.display = "inline";
        document.getElementById("MainContent_hidLayoutSelection").value = "9";
    }
    else if ($('#MainContent_radPreset10').is(':checked')) {
        document.getElementById('MainContent_btnQuestion8').disabled = false;
        $('#MainContent_lblQuestion8PagerAnswer').text("Preset 10");
        document.getElementById('pagerEight').style.display = "inline";
        document.getElementById("MainContent_hidLayoutSelection").value = "10";
    }
    else if ($('#MainContent_radPresetC1').is(':checked')) {
        document.getElementById('MainContent_btnQuestion8').disabled = false;
        $('#MainContent_lblQuestion8PagerAnswer').text("Custom");
        document.getElementById('pagerEight').style.display = "inline";
        document.getElementById("MainContent_hidLayoutSelection").value = "Custom";
    }
    else {
        //no selection, errors
    }

    return false;
}
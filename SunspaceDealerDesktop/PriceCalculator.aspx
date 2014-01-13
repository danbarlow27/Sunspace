﻿<%@ Page Title="Price Calculator" EnableEventValidation="false" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="PriceCalculator.aspx.cs" Inherits="SunspaceDealerDesktop.PriceCalculator" %>

<asp:Content runat="server" ID="SecondaryNavigation" ContentPlaceHolderID="SecondaryNavigation"> 
    
    <script>
        $(document).ready(function () {

            //Additional Charges
            var shipping = 0;
            var installation = 0;
            var deposit = 0;
            var shippingMethod = ""; // From drop down list
            var companyRep = "";
            var term = ""; // From drop down list
            var lead = ""; // From drop down list
            var percentDiscount = 0;
            var valueDiscount = 0;

            //Edit/Add invoice items
            var itemName = "";
            var itemDetails = "";
            var quantity = 0;
            var unitPrice = 0;
            var unitOfMeasurment = ""; // From drop down list
            var itemTotal = 0;
            //Additional edit/add variables
            var toEdit = false;
            var editRow; // This is hold the TR element reference that was double clicked for editing

            // Calulator variables
            var calculatorSubTotal = 0;
            var calculatorTotal = 0;
            var calculatorBalance = 0;
            var calculatorShipping = 0;
            var calculatorInstallation = 0;
            var calculatorDeposit = 0;
            var calculatorDiscount = 0;
            var calculatorDiscountPercent = 0;

            var errorMessage;            

            /********************************************
            BEGINNING OF ADDITIONAL CHARGES OVERLAY LOGIC
            ********************************************/

            //This function clears the fields in the additional charges
            function clearAdditionalCharges() {

                // Set all values to default
                $("#<%=txtShipping.ClientID%>").val(null);
                $("#<%=txtInstallation.ClientID%>").val(null);
                $("#<%=txtDeposit.ClientID%>").val(null);
                $("#<%=ddlShippingMethod.ClientID%>").val('0');
                $("#<%=txtCompanyRep.ClientID%>").val(null);
                $("#<%=ddlTerm.ClientID%>").val('0');
                $("#<%=ddlLead.ClientID%>").val('0');
                $("#<%=txtPercentDiscount.ClientID%>").val(null);
                $("#<%=txtValueDiscount.ClientID%>").val(null);

                // Remove the invalid class from all numerical items
                $("#<%=txtShipping.ClientID%>").removeClass("invalid");
                $("#<%=txtInstallation.ClientID%>").removeClass("invalid");
                $("#<%=txtDeposit.ClientID%>").removeClass("invalid");
                $("#<%=txtPercentDiscount.ClientID%>").removeClass("invalid");
                $("#<%=txtValueDiscount.ClientID%>").removeClass("invalid");
                $(".additionalChargesOverlay .accept").removeClass("invalid");

                return 1;
            }

            // This function uses the elements by ID for each of the fields in the additional charges overlay
            // If a field is invalid, the invalid class is added to the element, giving it a red border.
            // The accept button will not do anything with any invalid fields
            function validateAdditionalCharges() {
                
                var fltShipping = $("#<%=txtShipping.ClientID%>").val();
                var fltInstallation = $("#<%=txtInstallation.ClientID%>").val();
                var fltDeposit = $("#<%=txtDeposit.ClientID%>").val();
                var fltPercentDiscount = $("#<%=txtPercentDiscount.ClientID%>").val();
                var fltValueDiscount = $("#<%=txtValueDiscount.ClientID%>").val();

                // Remove the invalid class from each input field, if a is invalid, a red border is added
                $("#<%=txtShipping.ClientID%>").removeClass("invalid");
                $("#<%=txtInstallation.ClientID%>").removeClass("invalid");
                $("#<%=txtDeposit.ClientID%>").removeClass("invalid");
                $("#<%=txtPercentDiscount.ClientID%>").removeClass("invalid");
                $("#<%=txtValueDiscount.ClientID%>").removeClass("invalid");
                $(".additionalChargesOverlay .accept").removeClass("invalid");

                // Shipping needs to be numeric and above/equal to 0
                if (isNaN(fltShipping) || (!(isNaN(fltShipping)) && (fltShipping < 0))) {
                    $("#<%=txtShipping.ClientID%>").addClass("invalid");
                }

                // Installation needs to be numeric and above/equal to 0
                if (isNaN(fltInstallation) || (!(isNaN(fltInstallation)) && (fltInstallation < 0))) {
                    $("#<%=txtInstallation.ClientID%>").addClass("invalid");
                }

                // Deposit needs to be numeric and above/equal to 0
                if (isNaN(fltDeposit) || (!(isNaN(fltDeposit)) && (fltDeposit < 0))) {
                    $("#<%=txtDeposit.ClientID%>").addClass("invalid");
                }

                // Percent discount needs to be numeric and above/equal to 0 or below/equal to 100
                if (isNaN(fltPercentDiscount) || (!(isNaN(fltPercentDiscount)) && ((fltPercentDiscount < 0) || (fltPercentDiscount > 100)))) {
                    $("#<%=txtPercentDiscount.ClientID%>").addClass("invalid");
                }

                // Value discount needs to be numeric and above/equal to 0
                if (isNaN(fltValueDiscount) || (!(isNaN(fltValueDiscount)) && (fltValueDiscount < 0))) {
                    $("#<%=txtValueDiscount.ClientID%>").addClass("invalid");
                }

                // If anything is invalid, the accept button will be given the invalid class. This sets opacity to 50%
                if ($("#<%=txtShipping.ClientID%>").hasClass("invalid") ||
                 $("#<%=txtInstallation.ClientID%>").hasClass("invalid") ||
                 $("#<%=txtDeposit.ClientID%>").hasClass("invalid") ||
                 $("#<%=txtPercentDiscount.ClientID%>").hasClass("invalid") ||
                 $("#<%=txtValueDiscount.ClientID%>").hasClass("invalid"))
                {
                    $(".additionalChargesOverlay .accept").addClass("invalid");
                }
            }

            //Clicking the additional charges will display an overlay
            $(".additionalCharges").click(function () {
                clearAllItems();
                // Temp variables
                var tempDelivery = $("#<%=lblCalculatorDelivery.ClientID%>").text();
                tempDelivery = tempDelivery.replace("$", "");
                tempDelivery = parseFloat(tempDelivery);
                var tempInstallation = $("#<%=lblCalculatorInstallation.ClientID%>").text();
                tempInstallation = tempInstallation.replace("$", "");
                tempInstallation = parseFloat(tempInstallation);
                var tempDeposit = $("#<%=lblCalculatorDeposit.ClientID%>").text();
                tempDeposit = tempDeposit.replace("$", "");
                tempDeposit = parseFloat(tempDeposit);
                var tempDiscount = $("#<%=lblCalculatorDiscountValue.ClientID%>").text();
                tempDiscount = tempDiscount.replace("$", "");
                tempDiscount = parseFloat(tempDiscount);
                // If the overlay is already shown, hide it.
                if ($(".additionalChargesOverlay").is(":visible")) {
                    $(".additionalChargesOverlay").hide();
                }
                else {
                    $(".additionalChargesOverlay").show();
                    $(".editInvoiceItemOverlay").hide();

                    // Populate the text fields with what is already displayed, if there are values to set
                    if (tempDelivery > 0) {
                        $("#<%=txtShipping.ClientID%>").val(tempDelivery);
                    }
                    if (tempInstallation > 0) {
                        $("#<%=txtInstallation.ClientID%>").val(tempInstallation);
                    }
                    if (tempDeposit > 0) {
                        $("#<%=txtDeposit.ClientID%>").val(tempDeposit);
                    }
                    if (tempDiscount > 0) {
                        // If the discount percent is 0, the discount type is a solid value
                        if ($("#<%=lblCalculatorDiscountValue.ClientID%>").attr("data-percent") == 0) {
                            $("#<%=txtValueDiscount.ClientID%>").val(tempDiscount);
                        }
                        else {
                            console.log($("#<%=lblCalculatorDiscountValue.ClientID%>").data("percent"));
                            $("#<%=txtPercentDiscount.ClientID%>").val($("#<%=lblCalculatorDiscountValue.ClientID%>").attr("data-percent"));
                        }
                    }
                    $("#<%=txtShipping.ClientID%>").select();
                }
                resetClickedRow();
            });

            //Clicking the transparent overlay closes the additional charges overlays
            $("#additionalChargesBackground").on("click", function (e) {
                // If any child div's are clicked, do not hide anything
                if (e.target == this) {
                    $(".additionalChargesOverlay").hide();
                    clearAllItems();
                }
            });

            // OnKeyUp for each numerical field in the additional charges overlay will trigger a validation function
            $("#<%=txtShipping.ClientID%>,#<%=txtInstallation.ClientID%>,#<%=txtDeposit.ClientID%>,#<%=txtPercentDiscount.ClientID%>,#<%=txtValueDiscount.ClientID%>").keyup(function () {
                validateAdditionalCharges();
            });

            // Clicking percent discount clears the value discount and the invalid class
            $("#<%=txtPercentDiscount.ClientID%>").click(function () {
                $("#<%=txtValueDiscount.ClientID%>").removeClass("invalid");
                $("#<%=txtValueDiscount.ClientID%>").val("");
            });

            // Clicking value discount clears the percent discount and the invalid class
            $("#<%=txtValueDiscount.ClientID%>").click(function () {
                $("#<%=txtPercentDiscount.ClientID%>").removeClass("invalid");
                $("#<%=txtPercentDiscount.ClientID%>").val("");
                calculatorDiscountPercent = 0;
            });

            //Clicking the additional charges accept button will display the additional charges
            //If the additional charges are already displayed, the values are to change
            //The balance will also get recalculated
            $(".additionalChargesOverlay .accept").click(function () {
                
                var tempDiscount = 0;
                var tempPercent = 0;

                // Run validation 1 more time, because keyup event handler has it's down side. (While holding an invalid character then clicking the accept button will be valid)
                validateAdditionalCharges();
                // If the button doesn't have the class invalid, the content on the overlay is valid. Populate the price calculator.
                if (!($(this).hasClass("invalid")))
                {
                    if ($("#<%=txtValueDiscount.ClientID%>").val() != "") {
                        $("#<%=lblCalculatorDiscountValue.ClientID%>").attr("data-percent", "0");
                        calculatorDiscount = $("#<%=txtValueDiscount.ClientID%>").val();
                    }
                    else {
                        tempPercent = parseFloat($("#<%=txtPercentDiscount.ClientID%>").val()).toFixed(0) / 100;
                        tempDiscount = parseFloat(tempPercent * calculatorSubTotal).toFixed(2);
                        $("#<%=lblCalculatorDiscountValue.ClientID%>").attr("data-percent", (tempPercent * 100).toString());
                        calculatorDiscount = tempDiscount;
                        calculatorDiscountPercent = tempPercent;
                    }
                    // Store any remaining variables for calculating totals/balance later
                    calculatorShipping = $("#<%=txtShipping.ClientID%>").val();
                    calculatorInstallation = $("#<%=txtInstallation.ClientID%>").val();
                    calculatorDeposit = $("#<%=txtDeposit.ClientID%>").val();
                }

                $(".additionalChargesOverlay").hide();
                clearAllItems();
                resetClickedRow();
                calculateAndDisplayTotals();
            });

            /**************************************
            END OF ADDITIONAL CHARGES OVERLAY LOGIC
            **************************************/

            /***********************************************
            BEGINNING OF ADD/EDIT INVOICE ITEM OVERLAY LOGIC
            ***********************************************/

            //This function clears the fields in the add/edit invoice item overlay
            function clearEditInvoiceItem() {

                // Set all of the values to default
                $("#<%=txtItemName.ClientID%>").val(null);
                $("#<%=txtItemDetails.ClientID%>").val(null);
                $("#<%=txtQuantity.ClientID%>").val(null);
                $("#<%=txtUnitPrice.ClientID%>").val(null);
                $("#<%=ddlUnitOfMeasurment.ClientID%>").val('0');
                $("#<%=txtItemTotal.ClientID%>").val(null);
                toEdit = false;

                // Remove the invalid class from any numerical field
                $("#<%=txtQuantity.ClientID%>").removeClass("invalid");
                $("#<%=txtUnitPrice.ClientID%>").removeClass("invalid");
                $(".editInvoiceItemOverlay .accept").removeClass("invalid");

                return 1;
            }

            // This function uses the elements by ID for each of the fields in the edit invoice item overlay
            // If a field is invalid, the invalid class is added to the element, giving it a red border.
            // The accept button will not do anything with any invalid fields
            function validateEditInvoiceItem() {

                var intQuantity = $("#<%=txtQuantity.ClientID%>").val();
                var fltPricePerUnit = $("#<%=txtUnitPrice.ClientID%>").val();

                // Remove the invalid class from each input field, if a is invalid, a red border is added
                $("#<%=txtQuantity.ClientID%>").removeClass("invalid");
                $("#<%=txtUnitPrice.ClientID%>").removeClass("invalid");
                $(".editInvoiceItemOverlay .accept").removeClass("invalid");

                // Quantity needs to be integer and above/equal to 0
                if (isNaN(intQuantity) || (intQuantity % 1 === 1) && (intQuantity < 0)) {
                    $("#<%=txtQuantity.ClientID%>").addClass("invalid");
                }

                // Installation needs to be numeric and above/equal to 0
                if (isNaN(fltPricePerUnit) || (!(isNaN(fltPricePerUnit)) && (fltPricePerUnit < 0))) {
                    $("#<%=txtUnitPrice.ClientID%>").addClass("invalid");
                }            

                // If anything is invalid, the accept button will be given the invalid class. This sets opacity to 50%
                if ($("#<%=txtQuantity.ClientID%>").hasClass("invalid") ||
                 $("#<%=txtUnitPrice.ClientID%>").hasClass("invalid")) {
                    $(".editInvoiceItemOverlay .accept").addClass("invalid");
                }
            }

            //Clicking the Add Item will display an overlay
            $("#SecondaryNavigation_lnkAddItem").click(function () {
                // If the overlay is already shown, hide it.
                if ($(".editInvoiceItemOverlay").is(":visible"))
                {
                    $(".editInvoiceItemOverlay").hide();
                }
                else
                {
                    // Change the header for Add item
                    $(".editInvoiceItemOverlay h3:first").text("Add Invoice Item");
                    $(".editInvoiceItemOverlay").show();
                    $(".additionalChargesOverlay").hide();
                    $("#<%=txtItemName.ClientID%>").select();
                }
                clearAllItems();
                resetClickedRow();
            });

            //Clicking the Edit Item will display an overlay
            $("#SecondaryNavigation_lnkEditItem").click(function () {
                // temp variables
                var tempItemName;
                var tempItemDetails;
                var tempQuantity;
                var tempQuantitySub;
                var tempUnitPrice;
                var tempUnitOfMeasurment
                var tempPricePerUnit;
                var tempItemTotal;

                // If the overlay is already shown, hide it.
                if ($(".editInvoiceItemOverlay").is(":visible"))
                {
                    $(".editInvoiceItemOverlay").hide();
                }
                else if (editRow != null) // Only show if a row was clicked to edit
                {
                    // Change the header for Edit item
                    $(".editInvoiceItemOverlay h3:first").text("Edit Invoice Item");
                    $(".editInvoiceItemOverlay").show();
                    $(".additionalChargesOverlay").hide();

                    // Populate the fields with the clicked rows table row values
                    // For each columns' span elements 
                    jQuery.each($(editRow).children("td").children("span"), function (index) {
                        switch (index) {
                            case 0:
                                tempItemName = $(this).text();
                                break;
                            case 1:
                                tempItemDetails = $(this).text();
                                break;
                            case 2:
                                //Quantity and unit of measurment are in the same cell, must split the string
                                tempQuantitySub = $(this).text().split("/");
                                tempQuantity = tempQuantitySub[0];
                                tempUnitOfMeasurment = tempQuantitySub[1];
                                break;
                            case 3:
                                tempUnitPrice = $(this).text();
                                //Remove $ from the unitPrice
                                tempUnitPrice = tempUnitPrice.replace("$", "");
                                break;
                            case 4:
                                tempItemTotal = $(this).text();
                                //Remove $ from the itemTotal
                                tempItemTotal = tempItemTotal.replace("$", "");
                                break;
                            default:
                                console.log("Too many columns for the price calculator variable storage logic.");
                                break;
                        }
                    });

                    // Set the overlay textbox values with the content from the table row
                    $("#<%=txtItemName.ClientID%>").val(tempItemName);
                    $("#<%=txtItemDetails.ClientID%>").val(tempItemDetails);
                    $("#<%=txtQuantity.ClientID%>").val(tempQuantity);
                    $("#<%=txtUnitPrice.ClientID%>").val(tempUnitPrice);
                    $("#<%=ddlUnitOfMeasurment.ClientID%> option:contains(" + tempUnitOfMeasurment + ")").attr('selected', 'selected');
                    $("#<%=txtItemTotal.ClientID%>").val(tempItemTotal);

                    $("#<%=txtItemName.ClientID%>").select();
                }
                //clearAllItems();
                toEdit = true;
            });

            //Clicking the transparent overlay closes the edit invoice item overlays
            $("#editInvoiceItemBackground").on("click", function (e) {
                // If any child div's are clicked, do not hide anything &&
                // Only allow the user the hide the overlay if they are adding an item, editing must be closed by Cancel or X Close
                if (e.target == this && toEdit == false) {
                    $(".editInvoiceItemOverlay").hide();
                    clearAllItems();
                }
            });           

            //Changing the value of the quantity/unitprice will run validation and calculate the total value of the item
            $(".itemTotalField").keyup(function () {
                var tempQuantity = parseFloat($("#SecondaryNavigation_txtQuantity").val());
                var tempUnitPrice = parseFloat($("#SecondaryNavigation_txtUnitPrice").val());
                var tempItemTotal;

                // Display nothing before any calculations
                $("#<%=txtItemTotal.ClientID%>").val("");
                // Run validation
                validateEditInvoiceItem();

                if (!($(".editInvoiceItemOverlay .accept").hasClass("invalid"))) {
                    // Calculate and display the item total
                    if (tempQuantity >= 0 && tempUnitPrice >= 0) {
                        tempItemTotal = tempQuantity * tempUnitPrice;
                        $("#<%=txtItemTotal.ClientID%>").val(parseFloat(tempItemTotal).toFixed(2));
                    }
                }
            });

            //If the overlay is to be used to edit an item, the current values are to be stored in an array before changing the values on the spreadsheet
            //First array element will contain the row number that is getting edited
            //
            //If the overlay is to be used to add an item, a row will be added with the content from the overlay.
            //
            //For both adding and editing, there needs to be validation.
            $(".editInvoiceItemOverlay .accept").click(function () {
                var lastRowNumber = parseInt($("#<%=tblPriceCalculator.ClientID%> tr:last td:first span").data("row"));
                var tableRow;
                var tableCell;
                var tempUnitPrice = $("#<%=txtUnitPrice.ClientID%>").val();
                var tempItemTotal = $("#<%=txtItemTotal.ClientID%>").val();
                var tempQuantity = $("#<%=txtQuantity.ClientID%>").val();
                var tempQuantityAndUnit;

                // Run validation
                validateEditInvoiceItem();

                if (!($(this).hasClass("invalid")))
                {
                    tempUnitPrice = ((tempUnitPrice != "") ? ("$" + parseFloat(tempUnitPrice).toFixed(2)) : "");
                    // Concatenate the price per unit column
                    tempQuantityAndUnit = tempQuantity;

                    if ($("#<%=ddlUnitOfMeasurment.ClientID%>").val() != "")
                    {
                        // Display / if there is a unit price
                        tempQuantityAndUnit += ((tempQuantity != "") ? "/" : "") + $("#<%=ddlUnitOfMeasurment.ClientID%>").val();
                    }

                    // If the user double clicked a row, they are going to edit. Else they clicked Add Item
                    if (toEdit == true)
                    {
                        // Using the reference of the table row clicked, add the edited class
                        $(editRow).addClass("edited");                        
                        // For each columns' span elements of the row to edit
                        jQuery.each($(editRow).children("td").children("span"), function (index)
                        {
                            // If the data-original has not been set
                            if (!($(this).attr("data-original"))) {
                                // Store the original value in a data attribute
                                $(this).attr("data-original", $(this).text());
                            }

                            // Each index is to set page level variables
                            switch (index)
                            {
                                case 0:                                    
                                    $(this).text($("#<%=txtItemName.ClientID%>").val());
                                    break;
                                case 1:
                                    $(this).text($("#<%=txtItemDetails.ClientID%>").val());
                                    break;
                                case 2:
                                    $(this).text(tempQuantityAndUnit);
                                    break;
                                case 3:
                                    $(this).text(tempUnitPrice);
                                    break;
                                case 4:
                                    $(this).text(((tempItemTotal != "") ? ("$" + parseFloat(tempItemTotal).toFixed(2)) : ""));
                                    break;
                                default:
                                    console.log("Too many columns for the price calculator value set logic.");
                                    break;
                            }
                        });
                    }
                    else
                    {
                        // Item name cell - Beginning of row
                        tableCell = "<td><span data-row=\"" + (lastRowNumber + 1) + "\">" + $("#<%=txtItemName.ClientID%>").val() + "</span></td>";
                        tableRow = "<tr class=\"item additionalItem edited\">" + tableCell;

                        // Item details cell
                        tableCell = "<td><span>" + $("#<%=txtItemDetails.ClientID%>").val() + "</span></td>";
                        tableRow += tableCell;

                        // Item quantity cell
                        tableCell = "<td><span>" + tempQuantityAndUnit + "</span></td>";
                        tableRow += tableCell;

                        //Price per unit cell 
                        tableCell = "<td><span>" + tempUnitPrice + "</span></td>";
                        tableRow += tableCell;

                        //Price cell - End of row
                        tableCell = "<td><span>" + ((tempItemTotal != "") ? ("$" + parseFloat(tempItemTotal).toFixed(2) + "</span></td>") : "");
                        tableRow += tableCell + "</tr>";                        

                        // If there is no additional item's already added, 
                        if ($("#<%=tblPriceCalculator.ClientID%> tr.additionalItem").length == 0)
                        {
                            // Add a blank table row after the initial table rows before the new table row with content
                            $("#<%=tblPriceCalculator.ClientID%> tr.item:last").after("<tr><td colspan=\"5\"></td></tr>" + tableRow);                            
                        }
                        else
                        {
                            $("#<%=tblPriceCalculator.ClientID%> tr.additionalItem:last").after(tableRow);
                        }
                    }
                    $(".editInvoiceItemOverlay").hide();
                    clearAllItems();
                    resetClickedRow();
                    calculateAndDisplayTotals();
                }
            });

            /*****************************************
            END OF ADD/EDIT INVOICE ITEM OVERLAY LOGIC
            *****************************************/

            /***********************************
            BEGINNING OF UNIVERSAL OVERLAY LOGIC
            ***********************************/

            function resetVariables() {
                //Additional Charges
                shipping = 0;
                installation = 0;
                deposit = 0;
                shippingMethod = "Select"; // From drop down list
                companyRep = "";
                term = "Select"; // From drop down list
                lead = "Select"; // From drop down list
                percentDiscount = 0;
                valueDiscount = 0;

                //Edit/Add invoice items
                itemName = "";
                itemDetails = "";
                quantity = 0;
                unitPrice = 0;
                unitOfMeasurment = "Select"; // From drop down list
                itemTotal = 0;
                //Additional edit/add variables
                toEdit = false;
                editRowNumber = 0;
            }

            // This function just calls all of the clear functions, all in one place
            function clearAllItems() {

                clearAdditionalCharges();
                clearEditInvoiceItem();
                resetVariables();

                return 1;
            }

            //Clicking the X CLOSE, closes the overlays
            $(".priceCalculatorWrapper .close").click(function () {
                $(".additionalChargesOverlay").hide();
                $(".editInvoiceItemOverlay").hide();
                clearAllItems();
                resetClickedRow();
            });            

            /*****************************
            END OF UNIVERSAL OVERLAY LOGIC
            *****************************/

            /****************************
            BEGINNING OF REMOVE EDIT LOGIC
            *****************************/

            // Clicking the remove all edit will set the clicked table row with the edited class
            // back to it's original value, the original value is stored in the data-original 
            // attribute in each span element.
            $("#SecondaryNavigation_lnkRemoveEdit").click(function () {
                
                // Ifa row was clicked and it has been edited
                if ($(editRow).hasClass("clicked") && $(editRow).hasClass("additionalItem")) {
                    // Remove the additional item
                    $(editRow).remove();
                }
                // If a row was clicked and it has been edited
                else if ($(editRow).hasClass("clicked") && $(editRow).hasClass("edited"))
                {
                    $(editRow).removeClass("edited");

                    // For each columns' span elements of the row to edit
                    jQuery.each($(editRow).children("td").children("span"), function (index)
                    {
                        // Place the original value in the span element
                        $(this).text($(this).data("original"));
                        // Remove the original data from the element
                        $(this).removeData("original");
                    });

                }               

                resetClickedRow();
                calculateAndDisplayTotals();
            });

            // Clicking the remove all edit will set all table rows with the edited class
            // back to it's original value, the original value is stored in the data-original 
            // attribute in each span elements.
            $("#SecondaryNavigation_lnkRemoveAllEdits").click(function () {
                // For each edited row
                $(".tblPriceCalculator > tbody  > tr.edited").each(function (index) {
                    // Remove the edited class
                    $(this).removeClass("edited");
                    // For each columns' span elements of the row
                    jQuery.each($(this).children("td").children("span"), function (index)
                    {
                        // Place the original value in the span element
                        $(this).text($(this).data("original"));
                        // Remove the original data from the element
                        $(this).removeData("original");
                    });
                });
                // For each added row
                $(".tblPriceCalculator > tbody  > tr.additionalItem").each(function (index) {
                    // Remove the edited class
                    $(this).remove();   
                });
                calculateAndDisplayTotals();
            });

            /**************************
            END OF OF REMOVE EDIT LOGIC
            **************************/

            /**********************************************
            BEGINNING OF PRICE CALCULATOR SPREADSHEET LOGIC
            **********************************************/

            // Determine if the additional charges should be displayed on page loading
            if ($("#<%=lblCalculatorDiscountValue.ClientID%>").text() != 0) {
                $("#<%=trDiscount.ClientID%>").removeClass("displayNone");
            }
            if ($("#<%=lblCalculatorDelivery.ClientID%>").text() != 0) {
                $("#<%=trDelivery.ClientID%>").removeClass("displayNone");
            }
            if ($("#<%=lblCalculatorInstallation.ClientID%>").text() != 0) {
                $("#<%=trInstallation.ClientID%>").removeClass("displayNone");
            }
            if ($("#<%=lblCalculatorDeposit.ClientID%>").text() != 0) {
                $("#<%=trDeposit.ClientID%>").removeClass("displayNone");
                $("#<%=trBalance.ClientID%>").removeClass("displayNone");
            }
            
            // Store the variables of the calculator
            calculatorSubTotal = $("#<%=lblCalculatorSubTotal.ClientID%>").text();
            calculatorTotal = $("#<%=lblCalculatorTotal.ClientID%>").text();
            calculatorBalance = $("#<%=lblCalculatorBalance.ClientID%>").text();
            calculatorShipping = $("#<%=lblCalculatorDelivery.ClientID%>").text();
            calculatorInstallation = $("#<%=lblCalculatorInstallation.ClientID%>").text();
            calculatorDeposit = $("#<%=lblCalculatorDeposit.ClientID%>").text();
            calculatorDiscount = $("#<%=lblCalculatorDiscountValue.ClientID%>").text();

            function resetClickedRow() 
            {
                $(editRow).removeClass("clicked");
                editRow = null;
            }

            /*
              This function uses the calculator variables.
              Subtotal/total/balance is calculated based on additional charges and 
              all of the rows in the table
            */
            function calculateAndDisplayTotals()
            {
                var tempItemTotal;
                // Reset the calculator fields before reclaculations
                calculatorSubTotal = 0;

                // For each row
                $(".tblPriceCalculator > tbody  > tr.item").each(function (index) {
                    // For each columns' span elements of the row
                    jQuery.each($(this).children("td").children("span"), function (spanIndex) {
                        switch (spanIndex) {
                            // Index 4 is the total item price
                            case 4:
                                tempItemTotal = $(this).text();
                                // If there is a value to calculate with
                                if (tempItemTotal.length > 0) {
                                    //Remove $ from the itemTotal
                                    tempItemTotal = tempItemTotal.replace("$", "");
                                    calculatorSubTotal += parseFloat(tempItemTotal);                                    
                                }
                                break;
                            default:
                                break;
                        }
                    });
                });

                // Calculate total with any reductions or discounts
                calculatorTotal = parseFloat(calculatorSubTotal);
                if (calculatorShipping > 0) {
                    $("#<%=trDelivery.ClientID%>").removeClass("displayNone");
                    calculatorTotal += parseFloat(calculatorShipping);
                }
                else {
                    $("#<%=trDelivery.ClientID%>").addClass("displayNone");
                }
                if (calculatorInstallation > 0) {
                    $("#<%=trInstallation.ClientID%>").removeClass("displayNone");
                    calculatorTotal += parseFloat(calculatorInstallation);
                }
                else {
                    $("#<%=trInstallation.ClientID%>").addClass("displayNone");
                }
                if (calculatorDiscount > 0) {
                    $("#<%=trDiscount.ClientID%>").removeClass("displayNone");
                    // If there a discount percent, a recalculation is required for the discount
                    if (calculatorDiscountPercent > 0) {
                        calculatorDiscount = calculatorSubTotal * calculatorDiscountPercent;
                    }
                    calculatorTotal -= parseFloat(calculatorDiscount);
                }
                else {
                    $("#<%=trDiscount.ClientID%>").addClass("displayNone");
                }
                // If there is a deposit, calculate balance
                if (calculatorDeposit > 0) {
                    $("#<%=trDeposit.ClientID%>").removeClass("displayNone");
                    $("#<%=trBalance.ClientID%>").removeClass("displayNone");
                    calculatorBalance = calculatorTotal - calculatorDeposit;
                }
                else {
                    $("#<%=trDeposit.ClientID%>").addClass("displayNone");
                    $("#<%=trBalance.ClientID%>").addClass("displayNone");
                }

                // Repopulate the calculator fields
                $("#<%=lblCalculatorSubTotal.ClientID%>").text("$" + parseFloat(calculatorSubTotal).toFixed(2));
                $("#<%=lblCalculatorDiscountValue.ClientID%>").text("$" + parseFloat(calculatorDiscount).toFixed(2));
                $("#<%=lblCalculatorDelivery.ClientID%>").text("$" + parseFloat(calculatorShipping).toFixed(2));
                $("#<%=lblCalculatorInstallation.ClientID%>").text("$" + parseFloat(calculatorInstallation).toFixed(2));
                $("#<%=lblCalculatorTotal.ClientID%>").text("$" + parseFloat(calculatorTotal).toFixed(2));
                $("#<%=lblCalculatorDeposit.ClientID%>").text("$" + parseFloat(calculatorDeposit).toFixed(2));
                $("#<%=lblCalculatorBalance.ClientID%>").text("$" + parseFloat(calculatorBalance).toFixed(2));

            }
            // Run the function to filter out any invalid values
            calculateAndDisplayTotals();

            //This function is double clicking on a row cell, to populate the edit invoice item overlay
            $(".tblPriceCalculator").on("dblclick", "tr.item", function () {
                var rowNumber = $(this).children("td:first").children("span").data("row"); // The data-row value of the first table cells' span element
                var columns = $(this).children("td").children("span"); // Each table cells' span element in the row that was clicked
                var tempQuantitySub; // Splitting the unit price and unit of measurment (/ character)

                // For each columns' span elements 
                jQuery.each(columns, function (index) {
                    // Each index is to set page level variables
                    switch (index) {
                        case 0:
                            itemName = $(this).text();
                            break;
                        case 1:
                            itemDetails = $(this).text();
                            break;
                        case 2:
                            //Unit price and unit of measurment are in the same cell, must split the string
                            tempQuantitySub = $(this).text().split("/");
                            quantity = tempQuantitySub[0];
                            unitOfMeasurment = tempQuantitySub[1];
                            break;
                        case 3:                            
                            unitPrice = $(this).text();
                            //Remove $ from the unitPrice
                            unitPrice = unitPrice.replace("$", "");
                            break;
                        case 4:
                            itemTotal = $(this).text();
                            //Remove $ from the itemTotal
                            itemTotal = itemTotal.replace("$", "");
                            break;
                        default:
                            console.log("Too many columns for the price calculator variable storage logic.");
                            break;
                    }                    
                });

                // Set the overlay textbox values with the content from the table row
                $("#<%=txtItemName.ClientID%>").val(itemName);
                $("#<%=txtItemDetails.ClientID%>").val(itemDetails);
                $("#<%=txtQuantity.ClientID%>").val(quantity);
                $("#<%=txtUnitPrice.ClientID%>").val(unitPrice);
                $("#<%=ddlUnitOfMeasurment.ClientID%> option:contains(" + unitOfMeasurment + ")").attr('selected', 'selected');
                $("#<%=txtItemTotal.ClientID%>").val(itemTotal);
                // toEdit true allows for overlay accept button to update the current row
                toEdit = true;
                // Store a reference of the table row that is going to get edited
                editRow = $(this);
                // Show the overlay for allowing the user to edit
                $(".editInvoiceItemOverlay").show();
            });

            // Clicking on a table row sets the clicked class to the row and saves a reference to the table row
            $(".tblPriceCalculator").on("click", "tr.item", function () {
                // Remove the clicked class from the previous row clicked
                $(editRow).removeClass("clicked");
                // Store a reference of this table row clicked
                editRow = $(this);
                // Add clicked class
                $(editRow).addClass("clicked");                
            });

            /****************************************
            END OF PRICE CALCULATOR SPREADSHEET LOGIC
            ****************************************/            
        });

    </script>
     
    <div class="priceCalculatorWrapper">

        <nav class="navEditor">
            <ul class="ulNavEditor">
                <li><asp:HyperLink ID="lnkAdditionalCharges" CssClass="additionalCharges" runat="server">Additional Charges</asp:HyperLink></li>
                <li><asp:HyperLink ID="lnkAddItem" runat="server">Add Item</asp:HyperLink></li>
                <li><asp:HyperLink ID="lnkEditItem" CssClass="editItem disabled" runat="server">Edit Item</asp:HyperLink></li>
                <li><asp:HyperLink ID="lnkRemoveEdit" runat="server">Remove Edit</asp:HyperLink></li>
                <li><asp:HyperLink ID="lnkRemoveAllEdits" runat="server">Remove All Edits</asp:HyperLink></li>                
            </ul>
        </nav>
        
        <%--Overlay to display additional charges, the background is transparent. When clicked (jQuery), overlays close--%>
        <div id="additionalChargesBackground" class="additionalChargesOverlay">
            <div class="content">
                <div class="closeBar">
                    <div class="overlayClose close">CLOSE</div>
                </div>
                <h3>Additional Charges</h3>
                <%-- table for the additional charages--%>
                <asp:Table ID="tblAdditionalCharges" runat="server" CssClass="maxWidth">
                    <asp:TableRow>                            
                        <asp:TableCell>
                            <asp:Label ID="lblShipping" runat="server" style="padding:0 0 0 1em;" Text="Shipping: "></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtShipping" runat="server" CssClass="txtField" style="width:50%;" onkeydown="return (event.keyCode!=13);"></asp:TextBox>
                        </asp:TableCell>                          
                    </asp:TableRow>                    
                    <asp:TableRow>                            
                        <asp:TableCell>
                            <asp:Label ID="lblInstallation" runat="server" style="padding:0 0 0 1em;" Text="Installation: "></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtInstallation" runat="server" CssClass="txtField" style="width:50%;" onkeydown="return (event.keyCode!=13);"></asp:TextBox>
                        </asp:TableCell>                          
                    </asp:TableRow>
                    <asp:TableRow>                            
                        <asp:TableCell>
                            <asp:Label ID="lblDeposit" runat="server" style="padding:0 0 0 1em;" Text="Deposit: "></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtDeposit" runat="server" CssClass="txtField" style="width:50%;" onkeydown="return (event.keyCode!=13);"></asp:TextBox>
                        </asp:TableCell>                          
                    </asp:TableRow>
                    <asp:TableRow>                            
                        <asp:TableCell>
                            <asp:Label ID="lblShippingMethod" runat="server" style="padding:0 0 0 1em;" Text="Shipping Method: "></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:DropDownList ID="ddlShippingMethod" runat="server">
                                <asp:ListItem Text="Select Method" Value=""></asp:ListItem>
                                <asp:ListItem Text="Sunspace Truck" Value=""></asp:ListItem>
                                <asp:ListItem Text="UPS" Value=""></asp:ListItem>
                                <asp:ListItem Text="Common Carrier" Value=""></asp:ListItem>
                                <asp:ListItem Text="Pick Up" Value=""></asp:ListItem>
                                <asp:ListItem Text="Install Account" Value=""></asp:ListItem>
                                <asp:ListItem Text="Other" Value=""></asp:ListItem>
                            </asp:DropDownList>
                        </asp:TableCell>                          
                    </asp:TableRow> 
                    <asp:TableRow>                            
                        <asp:TableCell>
                            <asp:Label ID="lblCompanyRep" runat="server" style="padding:0 0 0 1em;" Text="Company Rep: "></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtCompanyRep" runat="server" CssClass="txtField" onkeydown="return (event.keyCode!=13);"></asp:TextBox>
                        </asp:TableCell>                          
                    </asp:TableRow> 
                    <asp:TableRow>                            
                        <asp:TableCell>
                            <asp:Label ID="lblTerm" runat="server" style="padding:0 0 0 1em;" Text="Term: "></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:DropDownList ID="ddlTerm" runat="server">
                                <asp:ListItem Text="Select" Value=""></asp:ListItem>
                                <asp:ListItem Text="C.O.D." Value=""></asp:ListItem>
                                <asp:ListItem Text="Net 15" Value=""></asp:ListItem>
                                <asp:ListItem Text="Net 30" Value=""></asp:ListItem>
                                <asp:ListItem Text="Net 45" Value=""></asp:ListItem>
                                <asp:ListItem Text="Net 60" Value=""></asp:ListItem>
                            </asp:DropDownList>
                        </asp:TableCell>                          
                    </asp:TableRow>
                    <asp:TableRow>                            
                        <asp:TableCell>
                            <asp:Label ID="lblLead" runat="server" style="padding:0 0 0 1em;" Text="Lead: "></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:DropDownList ID="ddlLead" runat="server">
                                <asp:ListItem Text="Select" Value=""></asp:ListItem>
                                <asp:ListItem Text="1-2 Weeks" Value=""></asp:ListItem>
                                <asp:ListItem Text="2-3 Weeks" Value=""></asp:ListItem>
                                <asp:ListItem Text="3-4 Weeks" Value=""></asp:ListItem>
                                <asp:ListItem Text="4-5 Weeks" Value=""></asp:ListItem>
                                <asp:ListItem Text="4-6 Weeks" Value=""></asp:ListItem>
                                <asp:ListItem Text="6-8 Weeks" Value=""></asp:ListItem>
                            </asp:DropDownList>
                        </asp:TableCell>                          
                    </asp:TableRow>    
                    <asp:TableRow>                            
                        <asp:TableCell>
                            <asp:Label ID="lblDiscount" runat="server" style="padding:0 0 0 1em;" Text="Discount: "></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtPercentDiscount" runat="server" CssClass="txtField" style="width:25%;" onkeydown="return (event.keyCode!=13);"></asp:TextBox>%
                        </asp:TableCell>  
                    </asp:TableRow> 
                    <asp:TableRow>                            
                        <asp:TableCell>
                            <div style="text-align:right;">$</div>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtValueDiscount" runat="server" CssClass="txtField" style="width:50%;" onkeydown="return (event.keyCode!=13);"></asp:TextBox>
                        </asp:TableCell>  
                    </asp:TableRow>  
                    <asp:TableRow>                            
                        <asp:TableCell ColumnSpan="2" CssClass="align-center">
                            <div class="button accept">ACCEPT</div>
                            <div class="button close">CANCEL</div>
                        </asp:TableCell>  
                    </asp:TableRow>                    
                </asp:Table>
            </div>
        </div>

        <%--Overlay to display add/edit invoice items, the background is transparent. When clicked (jQuery), overlays close--%>
        <div id="editInvoiceItemBackground" class="editInvoiceItemOverlay">
            <div class="content">
                <div class="closeBar">
                    <div class="overlayClose close">CLOSE</div>
                </div>
                <h3>Edit Invoice Item</h3>
                <%-- table for the add/edit invoice items--%>
                <asp:Table ID="tblEditInvoiceItem" runat="server" CssClass="maxWidth">
                    <asp:TableRow>                            
                        <asp:TableCell>
                            <asp:Label ID="lblItemName" runat="server" style="padding:0 0 0 1em;" Text="Item Name: "></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtItemName" runat="server" CssClass="txtField" style="width:90%;" onkeydown="return (event.keyCode!=13);"></asp:TextBox>
                        </asp:TableCell>                          
                    </asp:TableRow>    
                    <asp:TableRow>                            
                        <asp:TableCell>
                            <asp:Label ID="lblItemDetails" runat="server" style="padding:0 0 0 1em;" Text="Item Details: "></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtItemDetails" runat="server" CssClass="txtField" style="width:90%;" onkeydown="return (event.keyCode!=13);"></asp:TextBox>
                        </asp:TableCell>                          
                    </asp:TableRow>
                    <asp:TableRow>                            
                        <asp:TableCell>
                            <asp:Label ID="lblQuantity" runat="server" style="padding:0 0 0 1em;" Text="Quantity: "></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtQuantity" runat="server" CssClass="txtField itemTotalField" style="width:25%;" onkeydown="return (event.keyCode!=13);"></asp:TextBox>
                        </asp:TableCell>                          
                    </asp:TableRow>     
                    <asp:TableRow>                            
                        <asp:TableCell>
                            <asp:Label ID="lblUnitPrice" runat="server" style="padding:0 0 0 1em;" Text="Unit Price: "></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtUnitPrice" runat="server" CssClass="txtField itemTotalField" style="width:50%;" onkeydown="return (event.keyCode!=13);"></asp:TextBox>
                            <asp:DropDownList ID="ddlUnitOfMeasurment" runat="server">
                                <asp:ListItem Text="Select" Value=""></asp:ListItem>
                                <asp:ListItem Text="EA" Value="EA"></asp:ListItem>
                                <asp:ListItem Text="LF" Value="LF"></asp:ListItem>
                                <asp:ListItem Text="SF" Value="SF"></asp:ListItem>
                                <asp:ListItem Text="FT" Value="FT"></asp:ListItem>
                            </asp:DropDownList>
                        </asp:TableCell>                          
                    </asp:TableRow>       
                    <asp:TableRow>                            
                        <asp:TableCell>
                            <asp:Label ID="lblItemTotal" runat="server" style="padding:0 0 0 1em;" Text="Item Total: "></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtItemTotal" runat="server" CssClass="txtField" style="width:50%;" ReadOnly="true"></asp:TextBox>
                        </asp:TableCell>                          
                    </asp:TableRow> 
                     <asp:TableRow>                            
                        <asp:TableCell ColumnSpan="2" CssClass="align-center">
                            <div class="button accept">ACCEPT</div>
                            <div class="button close">CANCEL</div>
                        </asp:TableCell>  
                    </asp:TableRow>                           
                </asp:Table>
            </div>
        </div>

    </div>

</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:SqlDataSource ID="sdsDBConnection" runat="server" ConnectionString="<%$ ConnectionStrings:sunspaceDealerDesktopConnectionString %>" SelectCommand="SELECT * FROM [users]"></asp:SqlDataSource>
    <asp:Table ID="tblPriceCalculator" CssClass="tblPriceCalculator" runat="server">
        <asp:TableHeaderRow TableSection="TableHeader">                            
            <asp:TableCell>
                <asp:Label ID="lblTableItem" runat="server" Text="Item"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblTableDetails" runat="server" Text="Details"></asp:Label>
            </asp:TableCell>   
            <asp:TableCell>
                <asp:Label ID="lblTableQuantity" runat="server" Text="Quantity"></asp:Label>
            </asp:TableCell>   
            <asp:TableCell>
                <asp:Label ID="lblTablePricePerUnit" runat="server" Text="Price Per Unit"></asp:Label>
            </asp:TableCell> 
            <asp:TableCell>
                <asp:Label ID="lblTablePrice" runat="server" Text="Price"></asp:Label>
            </asp:TableCell>                      
        </asp:TableHeaderRow>
        <%--DUMMY DATA, REPLACE WITH PLACEHOLDER FOR INITIAL DATA --%>
        <asp:TableRow CssClass="item">
            <asp:TableCell CssClass="tdItem">
                <asp:Label runat="server" Text="Room Size" data-row="0"></asp:Label>
            </asp:TableCell>
            <asp:TableCell CssClass="tdDetails">
                <asp:Label runat="server" Text="16' 6&#34; Projection x 16' 6&#34; Width" data-row="0"></asp:Label>
            </asp:TableCell>   
            <asp:TableCell CssClass="tdQuantity">
                <asp:Label runat="server" Text="42/LF" data-row="0"></asp:Label>
            </asp:TableCell>   
            <asp:TableCell CssClass="tdPricePerUnit">
                <asp:Label runat="server" Text="$204.00" data-row="0"></asp:Label>
            </asp:TableCell> 
            <asp:TableCell CssClass="tdPrice">
                <asp:Label runat="server" Text="$8605.80" data-row="0"></asp:Label>
            </asp:TableCell>
        </asp:TableRow> 
        <asp:TableRow CssClass="item">
            <asp:TableCell CssClass="tdItem">
                <asp:Label runat="server" Text="Room Type" data-row="1"></asp:Label>
            </asp:TableCell>
            <asp:TableCell CssClass="tdDetails">
                <asp:Label runat="server" Text="Model 300 - Studio" data-row="1"></asp:Label>
            </asp:TableCell>   
            <asp:TableCell CssClass="tdQuantity">
                <asp:Label runat="server" Text="" data-row="1"></asp:Label>
            </asp:TableCell>   
            <asp:TableCell CssClass="tdPricePerUnit">
                <asp:Label runat="server" Text="" data-row="1"></asp:Label>
            </asp:TableCell> 
            <asp:TableCell CssClass="tdPrice">
                <asp:Label runat="server" Text="$1000.20" data-row="1"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow CssClass="item">
            <asp:TableCell CssClass="tdItem">
                <asp:Label runat="server" Text="Framing Color" data-row="2"></asp:Label>
            </asp:TableCell>
            <asp:TableCell CssClass="tdDetails">
                <asp:Label runat="server" Text="White" data-row="2"></asp:Label>
            </asp:TableCell>   
            <asp:TableCell CssClass="tdQuantity">
                <asp:Label runat="server" Text="" data-row="2"></asp:Label>
            </asp:TableCell>   
            <asp:TableCell CssClass="tdPricePerUnit">
                <asp:Label runat="server" Text="" data-row="2"></asp:Label>
            </asp:TableCell> 
            <asp:TableCell CssClass="tdPrice">
                <asp:Label runat="server" Text="" data-row="2"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <%--END OF DUMMY DATA, REPLACE WITH PLACEHOLDER FOR INITIAL DATA --%>  
        <asp:TableRow>
            <asp:TableCell ColumnSpan="4" CssClass="align-right">
                <asp:Label runat="server" Text="Sub Total"></asp:Label>
            </asp:TableCell> 
            <asp:TableCell CssClass="align-center">
                <asp:Label ID="lblCalculatorSubTotal" runat="server" Text="0"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>  
        <%--Each TrableRow with the class displayNone will be hidden until page loads and the text is anything other than 0. Then the class will get removed. The class will also get removed when values are added--%>
        <asp:TableRow ID="trDiscount" CssClass="displayNone">
            <asp:TableCell ColumnSpan="4" CssClass="align-right">
                <asp:Label ID="lblCalculatorDiscountLabel" runat="server" Text="Discount"></asp:Label>
            </asp:TableCell> 
            <asp:TableCell CssClass="align-center">
                <asp:Label ID="lblCalculatorDiscountValue" data-percent="0" runat="server" Text=""></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="trDelivery" CssClass="displayNone">
            <asp:TableCell ColumnSpan="4" CssClass="align-right">
                <asp:Label runat="server" Text="Delivery"></asp:Label>
            </asp:TableCell> 
            <asp:TableCell CssClass="align-center">
                <asp:Label ID="lblCalculatorDelivery" runat="server" Text="0"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="trInstallation" CssClass="displayNone">
            <asp:TableCell ColumnSpan="4" CssClass="align-right">
                <asp:Label runat="server" Text="Installation"></asp:Label>
            </asp:TableCell> 
            <asp:TableCell CssClass="align-center">
                <asp:Label ID="lblCalculatorInstallation" runat="server" Text=""></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="4" CssClass="align-right">
                <asp:Label runat="server" Text="TOTAL"></asp:Label>
            </asp:TableCell> 
            <asp:TableCell CssClass="align-center">
                <asp:Label ID="lblCalculatorTotal" runat="server" Text="0"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="trDeposit" CssClass="displayNone">
            <asp:TableCell ColumnSpan="4" CssClass="align-right">
                <asp:Label runat="server" Text="Deposit"></asp:Label>
            </asp:TableCell> 
            <asp:TableCell CssClass="align-center">
                <asp:Label ID="lblCalculatorDeposit" runat="server" Text=""></asp:Label>
            </asp:TableCell>
        </asp:TableRow>   
        <asp:TableRow ID="trBalance" CssClass="displayNone">
            <asp:TableCell ColumnSpan="4" CssClass="align-right">
                <asp:Label runat="server" Text="Balance"></asp:Label>
            </asp:TableCell> 
            <asp:TableCell CssClass="align-center">
                <asp:Label ID="lblCalculatorBalance" runat="server" Text="0"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
<%@ Page Title="Price Calculator" EnableEventValidation="false" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="PriceCalculator.aspx.cs" Inherits="SunspaceDealerDesktop.PriceCalculator" %>

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

            var errorMessage;            

            /********************************************
            BEGINNING OF ADDITIONAL CHARGES OVERLAY LOGIC
            ********************************************/

            //This function clears the fields in the additional charges
            function clearAdditionalCharges() {

                $("#<%=txtShipping.ClientID%>").val(null);
                $("#<%=txtInstallation.ClientID%>").val(null);
                $("#<%=txtDeposit.ClientID%>").val(null);
                $("#<%=ddlShippingMethod.ClientID%>").val('0');
                $("#<%=txtCompanyRep.ClientID%>").val(null);
                $("#<%=ddlTerm.ClientID%>").val('0');
                $("#<%=ddlLead.ClientID%>").val('0');
                $("#<%=txtPercentDiscount.ClientID%>").val(null);
                $("#<%=txtValueDiscount.ClientID%>").val(null);

                return 1;
            }

            // This function takes a parameter for each of the fields in the additional charges overlay
            // flt - Float
            // str - String
            // If all paramters are valid, this function returns (1/true)
            function validateAdditionalCharges(fltShipping, fltInstallation, fltDeposit, strShippingMethod, strCompanyRep, strTerm, strLead, fltPercentDiscount, fltValueDiscount) {
                var isValid = true;

                // Check if each float value is not a number, if true, the values are invalid
                if (isNaN(fltShipping) || isNaN(fltInstallation) || isNaN(fltDeposit) || isNaN(fltPercentDiscount) || isNaN(fltValueDiscount)) {
                    isValid = false;
                }

                return isValid;
            }

            //Clicking the additional charges will display an overlay
            $(".additionalCharges").click(function () {
                // If the overlay is already shown, hide it.
                if ($(".additionalChargesOverlay").is(":visible")) {
                    $(".additionalChargesOverlay").hide();
                }
                else {
                    $(".additionalChargesOverlay").show();
                    $(".editInvoiceItemOverlay").hide();
                    $("#<%=txtShipping.ClientID%>").select();
                }
                clearAllItems();
            });

            //Clicking the transparent overlay closes the additional charges overlays
            $("#additionalChargesBackground").on("click", function (e) {
                // If any child div's are clicked, do not hide anything
                if (e.target == this) {
                    $(".additionalChargesOverlay").hide();
                    clearAllItems();
                }
            });

            //Clicking the additional charges accept button will display the additional charges
            //If the additional charges are already displayed, the values are to change
            //The balance will also get recalculated
            $(".additionalChargesOverlay .accept").click(function () {
                var tempShipping = $("#<%=txtShipping.ClientID%>").val();
                var tempInstallation = $("#<%=txtInstallation.ClientID%>").val();
                var tempDeposit = $("#<%=txtDeposit.ClientID%>").val();
                var tempShippingMethod = $("#<%=ddlShippingMethod.ClientID%>").val();
                var tempCompanyRep = $("#<%=txtCompanyRep.ClientID%>").val();
                var tempTerm = $("#<%=ddlTerm.ClientID%>").val();
                var tempLead = $("#<%=ddlLead.ClientID%>").val();
                var tempPercentDiscount = $("#<%=txtPercentDiscount.ClientID%>").val();
                var tempValueDiscount = $("#<%=txtValueDiscount.ClientID%>").val();

                var isValid = validateAdditionalCharges(tempShipping, tempInstallation, tempDeposit, tempShippingMethod, tempCompanyRep, tempTerm, tempLead, tempPercentDiscount, tempValueDiscount);

                alert(isValid);
            });


            /**************************************
            END OF ADDITIONAL CHARGES OVERLAY LOGIC
            **************************************/

            /***********************************************
            BEGINNING OF ADD/EDIT INVOICE ITEM OVERLAY LOGIC
            ***********************************************/

            //This function clears the fields in the add/edit invoice item overlay
            function clearEditInvoiceItem() {

                $("#<%=txtItemName.ClientID%>").val(null);
                $("#<%=txtItemDetails.ClientID%>").val(null);
                $("#<%=txtQuantity.ClientID%>").val(null);
                $("#<%=txtUnitPrice.ClientID%>").val(null);
                $("#<%=ddlUnitOfMeasurment.ClientID%>").val('0');
                $("#<%=txtItemTotal.ClientID%>").val(null);
                toEdit = false;
                editRowNumber = 0;

                return 1;
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
                    $(".editInvoiceItemOverlay").show();
                    $(".additionalChargesOverlay").hide();
                    $("#<%=txtItemName.ClientID%>").select();
                }
                clearAllItems();
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

            //Changing the value of the quantity/unitprice will calculate the total value of the item
            $(".itemTotalField").keyup(function () {
                var tempQuantity = parseFloat($("#SecondaryNavigation_txtQuantity").val());
                var tempUnitPrice = parseFloat($("#SecondaryNavigation_txtUnitPrice").val());
                var tempItemTotal = 0;

                // Display 0 before any calculations
                $("#<%=txtItemTotal.ClientID%>").val(tempItemTotal);

                // Calculate and display the item total
                if (tempQuantity >= 0 && tempUnitPrice >= 0) {
                    tempItemTotal = tempQuantity * tempUnitPrice;
                    $("#<%=txtItemTotal.ClientID%>").val(tempItemTotal);
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

                // If the user double clicked a row, they are going to edit. Else they clicked Add Item
                if (toEdit == true) {
                    // Using the reference of the table row clicked, add the edited class
                    $(editRow).addClass("edited");
                }
                else {
                    // Item name cell - Beginning of row
                    tableCell = "<td><span data-row=\"" + (lastRowNumber + 1) + "\">" + $("#<%=txtItemName.ClientID%>").val() + "</span></td>";
                    tableRow = "<tr>" + tableCell;

                    // Item details cell
                    tableCell = "<td><span>" + $("#<%=txtItemDetails.ClientID%>").val() + "</span></td>";
                    tableRow += tableCell;

                    // Item quantity cell
                    tableCell = "<td><span>" + $("#<%=txtQuantity.ClientID%>").val() + "</span></td>";
                    tableRow += tableCell;

                    //Price per unit cell
                    tableCell = "<td><span>" + $("#<%=txtUnitPrice.ClientID%>").val() + "/" + $("#<%=ddlUnitOfMeasurment.ClientID%>").val() + "</span></td>";
                    tableRow += tableCell;

                    //Price cell - End of row
                    tableCell = "<td><span>" + $("#<%=txtItemTotal.ClientID%>").val() + "</span></td>";
                    tableRow += tableCell + "</tr>";

                    //Append the table row with all of the content after the last table row in the price calculator table
                    $("#<%=tblPriceCalculator.ClientID%> tr:last").after(tableRow);
                }

                $(".editInvoiceItemOverlay").hide();
                clearAllItems();
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
            });            

            /*****************************
            END OF UNIVERSAL OVERLAY LOGIC
            *****************************/            

            //This function is clicking on a row cell, to populate the edit invoice item overlay
            $(".tblPriceCalculator").on("dblclick", "tr", function () {
                var rowNumber = $(this).children("td:first").children("span").data("row"); // The data-row value of the first table cells' span element
                var columns = $(this).children("td").children("span"); // Each table cells' span element in the row that was clicked
                var tempPricePerUnitSub; // Splitting the unit price and unit of measurment (/ character)

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
                            quantity = $(this).text();
                            break;
                        case 3:
                            //Unit price and unit of measurment are in the same cell, must split the string
                            tempPricePerUnitSub = $(this).text().split("/");
                            unitPrice = tempPricePerUnitSub[0];
                            unitOfMeasurment = tempPricePerUnitSub[1];
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
            
        });
    </script>
     
    <div class="priceCalculatorWrapper">

        <nav class="navEditor">
            <ul class="ulNavEditor">
                <li><asp:HyperLink ID="lnkAdditionalCharges" CssClass="additionalCharges" runat="server">Additional Charges</asp:HyperLink></li>
                <li><asp:HyperLink ID="lnkAddItem" runat="server">Add Item</asp:HyperLink></li>
                <li><asp:HyperLink ID="lnkEditItem" CssClass="editItem" runat="server">Edit Item</asp:HyperLink></li>
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
                        <asp:TableCell ColumnSpan="2" style="padding:0 0 0 2em; font-size:75%; line-height:50%;">
                            <asp:Label ID="lblShippingNote" runat="server"  Text="Tax will be calculated on the Delivery Price of all Wholesale"></asp:Label>
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
                        <asp:TableCell ColumnSpan="2" CssClass="center">
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
                        <asp:TableCell ColumnSpan="2" CssClass="center">
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
        <asp:TableRow>
            <asp:TableCell CssClass="tdItem">
                <asp:Label runat="server" Text="Random item - long name" data-row="1"></asp:Label>
            </asp:TableCell>
            <asp:TableCell CssClass="tdDetails">
                <asp:Label runat="server" Text="Random item details - text can be long too" data-row="1"></asp:Label>
            </asp:TableCell>   
            <asp:TableCell CssClass="tdQuantity">
                <asp:Label runat="server" Text="12" data-row="1"></asp:Label>
            </asp:TableCell>   
            <asp:TableCell CssClass="tdPricePerUnit">
                <asp:Label runat="server" Text="$89.00/EA" data-row="1"></asp:Label>
            </asp:TableCell> 
            <asp:TableCell CssClass="tdPrice">
                <asp:Label runat="server" Text="$1068" data-row="1"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>        
    </asp:Table>
</asp:Content>
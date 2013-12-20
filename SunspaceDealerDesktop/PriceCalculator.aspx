<%@ Page Title="Price Calculator" EnableEventValidation="false" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="PriceCalculator.aspx.cs" Inherits="SunspaceDealerDesktop.PriceCalculator" %>

<asp:Content runat="server" ID="SecondaryNavigation" ContentPlaceHolderID="SecondaryNavigation"> 
    
    <script>
        $(document).ready(function () {

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

            //This function clears the fields in the add/edit invoice item overlay
            function clearEditInvoiceItem() {

                $("#<%=txtItemName.ClientID%>").val(null);
                $("#<%=txtItemDetails.ClientID%>").val(null);
                $("#<%=txtQuantity.ClientID%>").val(null);
                $("#<%=txtUnitPrice.ClientID%>").val(null);
                $("#<%=ddlUnitOfMeasurment.ClientID%>").val('0');
                $("#<%=txtItemTotal.ClientID%>").val(null);

                return 1;
            }

            //Clicking the additional charges will display an overlay
            $(".additionalCharges").click(function () {
                // If the overlay is already shown, hide it.
                if ($(".additionalChargesOverlay").is(":visible"))
                {
                    $(".additionalChargesOverlay").hide();
                    clearAdditionalCharges();
                }
                else
                {
                    $(".additionalChargesOverlay").show();
                    $(".editInvoiceItemOverlay").hide();

                   $("#<%=txtShipping.ClientID%>").select();
                }
            });

            //Clicking the Add Item will display an overlay
            $("#SecondaryNavigation_lnkAddItem").click(function () {
                // If the overlay is already shown, hide it.
                if ($(".editInvoiceItemOverlay").is(":visible"))
                {
                    $(".editInvoiceItemOverlay").hide();
                    clearEditInvoiceItem();
                }
                else
                {
                    $(".editInvoiceItemOverlay").show();
                    $(".additionalChargesOverlay").hide();

                    $("#<%=txtItemName.ClientID%>").select();
                }                
            });

            //Clicking the transparent overlay closes the additional charges overlays
            $("#additionalChargesBackground").on("click", function (e) {
                // If any child div's are clicked, do not hide anything
                if (e.target == this)
                {
                    $(".additionalChargesOverlay").hide();
                    clearAdditionalCharges();
                }
            });

            //Clicking the transparent overlay closes the edit invoice item overlays
            $("#editInvoiceItemBackground").on("click", function (e) {
                // If any child div's are clicked, do not hide anything
                if (e.target == this) {
                    $(".editInvoiceItemOverlay").hide();
                    clearEditInvoiceItem();
                }
            });

            //Clicking the X CLOSE, closes the overlays
            $(".overlayClose").click(function () {
                $(".additionalChargesOverlay").hide();
                $(".editInvoiceItemOverlay").hide();
                clearAdditionalCharges();
                clearEditInvoiceItem();
            });

            //Changing the value of the quantity/unitprice will calculate the total value of the item
            $(".itemTotalField").keyup(function () {
                var quantity = parseFloat($("#SecondaryNavigation_txtQuantity").val());
                var unitPrice = parseFloat($("#SecondaryNavigation_txtUnitPrice").val());
                var itemTotal = 0;

                // Display 0 before any calculations
                $("#<%=txtItemTotal.ClientID%>").val(itemTotal);

                // Calculate and display the item total
                if (quantity >= 0 && unitPrice >= 0)
                {
                    itemTotal = quantity * unitPrice;
                    $("#<%=txtItemTotal.ClientID%>").val(itemTotal);
                }
            });

        });
    </script>
     
    <div class="priceCalculatorWrapper">

        <nav class="navEditor">
            <ul class="ulNavEditor">
                <li><asp:HyperLink ID="lnkAdditionalCharges" CssClass="additionalCharges" runat="server">Additional Charges</asp:HyperLink></li>
                <li><asp:HyperLink ID="lnkDelivery" runat="server">Delivery</asp:HyperLink></li>
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
                    <div class="overlayClose">CLOSE</div>
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
                            <div class="button">ACCEPT</div>
                            <div class="button">CANCEL</div>
                        </asp:TableCell>  
                    </asp:TableRow>                    
                </asp:Table>
            </div>
        </div>

       <%--Overlay to display add/edit invoice items, the background is transparent. When clicked (jQuery), overlays close--%>
        <div id="editInvoiceItemBackground" class="editInvoiceItemOverlay">
            <div class="content">
                <div class="closeBar">
                    <div class="overlayClose">CLOSE</div>
                </div>
                <h3>Edit Invoice Item</h3>
                <%-- table for the add/edit invoice items--%>
                <asp:Table ID="tblEditInvoiceItem" runat="server" CssClass="maxWidth">
                    <asp:TableRow>                            
                        <asp:TableCell>
                            <asp:Label ID="lblItemName" runat="server" style="padding:0 0 0 1em;" Text="Item Name: "></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtItemName" runat="server" CssClass="txtField" onkeydown="return (event.keyCode!=13);"></asp:TextBox>
                        </asp:TableCell>                          
                    </asp:TableRow>    
                    <asp:TableRow>                            
                        <asp:TableCell>
                            <asp:Label ID="lblItemDetails" runat="server" style="padding:0 0 0 1em;" Text="Item Details: "></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtItemDetails" runat="server" CssClass="txtField" onkeydown="return (event.keyCode!=13);"></asp:TextBox>
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
                                <asp:ListItem Text="EA" Value=""></asp:ListItem>
                                <asp:ListItem Text="LF" Value=""></asp:ListItem>
                                <asp:ListItem Text="SF" Value=""></asp:ListItem>
                                <asp:ListItem Text="FT" Value=""></asp:ListItem>
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
                            <div class="button">ACCEPT</div>
                            <div class="button">CANCEL</div>
                        </asp:TableCell>  
                    </asp:TableRow>                           
                </asp:Table>
            </div>
        </div>

    </div>

</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:SqlDataSource ID="sdsDBConnection" runat="server" ConnectionString="<%$ ConnectionStrings:sunspaceDealerDesktopConnectionString %>" SelectCommand="SELECT * FROM [users]"></asp:SqlDataSource>
</asp:Content>
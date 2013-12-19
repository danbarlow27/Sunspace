<%@ Page Title="Price Calculator" EnableEventValidation="false" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="PriceCalculator.aspx.cs" Inherits="SunspaceDealerDesktop.PriceCalculator" %>

<asp:Content runat="server" ID="SecondaryNavigation" ContentPlaceHolderID="SecondaryNavigation"> 
    
    <script>
        $(document).ready(function () {
            //Clicking the additional charges will display an overlay
            $(".additionalCharges").click(function () {
                // If the overlay is already shown, hide it.
                if ($(".additionalChargesOverlay").is(":visible"))
                {
                    $(".additionalChargesOverlay").hide();
                }
                else
                {
                    $(".additionalChargesOverlay").show();
                }
            });

            //Clicking the transparent overlay closes all of the overlays
            $("#additionalChargesBackground").on("click", function (e) {
                // If any child div's are clicked, do not hide anything
                if (e.target == this)
                {
                    $(".additionalChargesOverlay").hide();
                }
            });

            //Clicking the X CLOSE, closes the overlays
            $(".overlayClose").click(function () {
                $(".additionalChargesOverlay").hide();
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
                 <%-- table for the additional charages, contains input fields for shipping, installation, deposit, and terms --%>
                <asp:Table ID="tblAdditionalCharges" runat="server" CssClass="maxWidth">
                    <asp:TableRow>                            
                        <asp:TableCell>
                            <asp:Label ID="lblShipping" runat="server" style="padding:0 0 0 1em;" Text="Shipping: "></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtShipping" runat="server" CssClass="txtField" style="width:50%;"></asp:TextBox>
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
                            <asp:TextBox ID="txtInstallation" runat="server" CssClass="txtField" style="width:50%;"></asp:TextBox>
                        </asp:TableCell>                          
                    </asp:TableRow>
                    <asp:TableRow>                            
                        <asp:TableCell>
                            <asp:Label ID="lblDeposit" runat="server" style="padding:0 0 0 1em;" Text="Deposit: "></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtDeposit" runat="server" CssClass="txtField" style="width:50%;"></asp:TextBox>
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
                            <asp:TextBox ID="txtCompanyRep" runat="server" CssClass="txtField"></asp:TextBox>
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
                            <asp:TextBox ID="txtPercentDiscount" runat="server" CssClass="txtField" style="width:25%;"></asp:TextBox>%
                        </asp:TableCell>  
                    </asp:TableRow> 
                    <asp:TableRow>                            
                        <asp:TableCell>
                            <div style="text-align:right;">$</div>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtValueDiscount" runat="server" CssClass="txtField" style="width:50%;"></asp:TextBox>
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
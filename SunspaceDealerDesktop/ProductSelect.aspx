<%@ Page Title="Sunspace | Select Catalogue Product" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductSelect.aspx.cs" Inherits="Sunspace.ProductSelect" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:SqlDataSource ID="datSelectDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:sunspaceDealerDesktopConnectionString %>" SelectCommand="SELECT * FROM [acrylic_panels]"></asp:SqlDataSource>
    
    <br class="clear">

    <div class="contentWrapper">

        <asp:Table ID="productSelectTable" CssClass="productSelectTable" runat="server">
            <%-- GENERAL/PRICING SELECTION --%>
            <asp:TableRow ID="radButtonRow">
                <asp:TableCell>&nbsp;</asp:TableCell>
                <asp:TableCell>
                    <asp:RadioButton ID="radUpdateGeneral" GroupName="update" TabIndex="1" Checked="True" runat="server" />
                    <asp:Label ID="lblUpdateGeneralRadio" AssociatedControlID="radUpdateGeneral" runat="server"></asp:Label>
                    <asp:Label ID="lblUpdateGeneral" AssociatedControlID="radUpdateGeneral" runat="server" Text="General Update"></asp:Label>

                    <asp:RadioButton ID="radUpdatePricing" runat="server" GroupName="update" TabIndex="2" />
                    <asp:Label ID="lblUpdatePricingRadio" AssociatedControlID="radUpdatePricing" runat="server"></asp:Label>
                    <asp:Label ID="lblUpdatePricing" AssociatedControlID="radUpdatePricing" runat="server" Text="Pricing Update"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <%-- CATEGORY/PRODUCT SELECTION --%>
            <asp:TableRow>
                <asp:TableCell CssClass="tdLblProductSelect">
                    <asp:Label ID="lblSelectCategory" CssClass="lblFieldSelectCategory" runat="server" Text="Select Category:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="ddlCategory" CssClass="ddlField" runat="server" Height="32" Width="250" TabIndex="3" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlPart" CssClass="hideElement" runat="server" Height="32" Width="280" TabIndex="4" OnSelectedIndexChanged="ddlPart_SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>

                    <asp:Button ID="btnGo" runat="server" Text="Go" Height="30" Width="60" TabIndex="5" CssClass="hideElement" OnClick="btnGo_Click" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>

</asp:Content>

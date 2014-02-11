<%@ Page Title="Sunspace" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ComponentMenu.aspx.cs" Inherits="Sunspace.MainMenu" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <br class="clear">
    <div class="contentWrapper">
        <div class="containerMainMenu">
            <h3>Select a Task</h3>

            <asp:Button ID="btnSelectUpdate" CssClass="btnMainMenu" runat="server" Text="Update Catalogue" TabIndex="1" OnClick="btnSelectUpdate_Click" />
            <asp:Button ID="btnSelectPricing" CssClass="btnMainMenu" runat="server" Text="Update Pricing" TabIndex="2" OnClick="btnSelectPricing_Click" />
            <asp:Button ID="btnSelectInsert" CssClass="btnMainMenu" runat="server" Text="Add Products to Catalogue" TabIndex="3" OnClick="btnSelectInsert_Click" />
            <asp:Button ID="btnSelectDisplay" CssClass="btnMainMenu" runat="server" Text="View Catalogue" TabIndex="4" OnClick="btnSelectDisplay_Click"/>
        </div>
    </div> <!-- end contentWrapper -->
</asp:Content>

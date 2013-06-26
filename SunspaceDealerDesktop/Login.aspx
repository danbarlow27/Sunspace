<%@ Page Title="Dealer Desktop Login" Language="C#" MasterPageFile="~/NoIcons.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SunspaceDealerDesktop.Login" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div>
        <asp:Label runat="server" ID="lblLogin" Text="Please Login: "></asp:Label>
        <asp:TextBox runat="server" ID="txtLogin" CssClass="txtField txtInput"></asp:TextBox>
        <asp:Button runat="server" ID="btnLogin" CssClass="btnSubmit" Text="Login" OnClick="btnLogin_Click"/>
    </div>
</asp:Content>

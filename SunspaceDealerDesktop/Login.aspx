<%@ Page Title="Dealer Desktop Login" Language="C#" MasterPageFile="~/NoIcons.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SunspaceDealerDesktop.Login" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div>
        <asp:Label runat="server" ID="lblError" Text= "" ></asp:Label>
        <br />
        <asp:Label runat="server" ID="lblUsername" Text="Username: "></asp:Label>
        <asp:TextBox runat="server" ID="txtUsername" CssClass="txtField txtInput"></asp:TextBox>
        <br />
        <asp:Label runat="server" ID="lblPassword" Text="Password: "></asp:Label>
        <asp:TextBox runat="server" ID="txtPassword" CssClass="txtField txtInput"></asp:TextBox>
        <br />
        <asp:Button runat="server" ID="btnLogin" CssClass="btnSubmit" Text="Login" OnClick="btnLogin_Click"/>
    </div>
    <asp:SqlDataSource ID="sdsLogin" runat="server" ConnectionString="<%$ ConnectionStrings:sunspaceDealerDesktopConnectionString %>" SelectCommand="SELECT * FROM [customers]"></asp:SqlDataSource>
</asp:Content>

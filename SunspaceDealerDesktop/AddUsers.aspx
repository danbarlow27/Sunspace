<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddUsers.aspx.cs" Inherits="SunspaceDealerDesktop.AddUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div id="UserTypeDiv" runat="server">
        <asp:Label ID="lblUserType" runat="server" Text="User type:"></asp:Label>
        <asp:DropDownList ID="ddlUserType" runat="server"></asp:DropDownList>
        <br /><br />
    </div>
    <div id="UserGroupDiv" runat="server">
        <asp:Label ID="lblUserGroup" runat="server" Text="User group:"></asp:Label>
        <asp:DropDownList ID="ddlUserGroup" runat="server"></asp:DropDownList>
        <br /><br />
    </div>
    <asp:Label ID="lblLogin" runat="server" Text="Login:"></asp:Label>
    <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox>
    <br /><br />
    <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label>
    <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
    <br /><br />
    <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
    <br /><br />
    <asp:Label ID="lblFirstName" runat="server" Text="First Name:"></asp:Label>
    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
    <br /><br />
    <asp:Label ID="lblLastName" runat="server" Text="Last Name:"></asp:Label>
    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
    <br /><br />
    <asp:Button id="btnSubmit" runat="server" Text="Submit" />
</asp:Content>

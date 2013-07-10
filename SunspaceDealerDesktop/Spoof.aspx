<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Spoof.aspx.cs" Inherits="SunspaceDealerDesktop.Spoof" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblDealers" runat="server"></asp:Label>
    <asp:DropDownList id="ddlDealers" runat="server"></asp:DropDownList>
    <br />
    <asp:Button ID="btnDealers" runat="server" Text="Spoof" OnClick="btnDealers_Click" />
    <asp:SqlDataSource ID="sdsDealers" runat="server" ConnectionString="<%$ ConnectionStrings:sunspaceDealerDesktopConnectionString %>" SelectCommand="SELECT * FROM [users]"></asp:SqlDataSource>
</asp:Content>

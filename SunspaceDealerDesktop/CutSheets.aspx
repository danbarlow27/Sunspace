<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CutSheets.aspx.cs" Inherits="SunspaceDealerDesktop.CutSheets" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SecondaryNavigation" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ModOverlay" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <h1>SUNSPACE MODULAR ENCLOSURES INC.</h1>
    <h2>Extrusion Cut Sheet</h2>
    <asp:Label ID="lblTag" runat="server" Text="Tag Name: TESTING"></asp:Label><br />
    <asp:Label ID="lblCustomer" runat="server" Text ="Customer: ABC"></asp:Label><br />
    <asp:Label ID="lblColour" runat="server" Text="Extrusion Colour: WHITE"></asp:Label><br />
    <asp:Label ID="lblExtrusion" runat="server" Text="Extrusion Type: 2&quot Aluminium"></asp:Label><br /><br />

    <asp:PlaceHolder ID="tblPlaceholder" runat="server"></asp:PlaceHolder>
</asp:Content>

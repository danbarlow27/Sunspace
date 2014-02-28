<%@ Page Title="" Language="C#" MasterPageFile="~/NoIcons.Master" AutoEventWireup="true" CodeBehind="ComponentCart.aspx.cs" Inherits="SunspaceDealerDesktop.ComponentCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:PlaceHolder ID="phMainTable" runat="server"></asp:PlaceHolder>
    <asp:Label ID="lblDebug" runat="server"></asp:Label>
</asp:Content>
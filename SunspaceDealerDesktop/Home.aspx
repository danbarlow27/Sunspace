﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="SunspaceDealerDesktop.Home1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">    
    <asp:Button ID="btnAddUsers" runat="server" Text="Add users" CssClass="btnSubmit" OnClick="btnAddUsers_Click" />
    <br />
    <asp:Button ID="btnPreferences" runat="server" Text="Preferences" CssClass="btnSubmit" OnClick="btnPreferences_Click" />
    <br />
    <asp:Button ID="btnSpoof" runat="server" Text="Spoofed Login" CssClass="btnSubmit" OnClick="btnSpoof_Click" />
</asp:Content>

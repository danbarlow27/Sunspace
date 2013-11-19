<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProjectPreview.aspx.cs" Inherits="SunspaceDealerDesktop.ProjectPreview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:PlaceHolder ID="phProjectTitle" runat="server"></asp:PlaceHolder>
        <asp:PlaceHolder ID="phProject" runat="server"></asp:PlaceHolder>
        <br /><br />
        <asp:PlaceHolder ID="phWallsTitle" runat="server"></asp:PlaceHolder>        
        <asp:PlaceHolder ID="phWalls" runat="server"></asp:PlaceHolder>
        <br /><br />
        <asp:PlaceHolder ID="phRoofTitle" runat="server"></asp:PlaceHolder>        
        <asp:PlaceHolder ID="phRoof" runat="server"></asp:PlaceHolder>
        <br /><br />
        <asp:PlaceHolder ID="phFloorTitle" runat="server"></asp:PlaceHolder>        
        <asp:PlaceHolder ID="phFloor" runat="server"></asp:PlaceHolder>
    </div>
    <div>
        <asp:Button ID="btnSubmit" runat="server" text="Build Project" OnClick="btnSubmit_Click"/>
    </div>
    <asp:SqlDataSource ID="sdsDBConnection" runat="server" ConnectionString="<%$ ConnectionStrings:sunspaceDealerDesktopConnectionString %>" SelectCommand="SELECT * FROM [users]"></asp:SqlDataSource>
</asp:Content>

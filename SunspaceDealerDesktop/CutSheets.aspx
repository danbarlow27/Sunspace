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
    <asp:DropDownList ID="ddlCutSheets" runat="server"></asp:DropDownList>
    <h1 style="text-align:center">SUNSPACE MODULAR ENCLOSURES INC.</h1>

    <div id="extrusionCutSheet" runat="server">
        <h2 style="text-align:center">Extrusion Cut Sheet</h2>
        <asp:Label ID="lblExtrusionTag" runat="server" Text="Tag Name: TESTING"></asp:Label><br />
        <asp:Label ID="lblExtrusionCustomer" runat="server" Text ="Customer: ABC"></asp:Label><br />
        <asp:Label ID="lblExtrusionColour" runat="server" Text="Extrusion Colour: WHITE"></asp:Label><br />
        <asp:Label ID="lblExtrusionType" runat="server" Text="Extrusion Type: 2&quot"></asp:Label><br /><br />

        <asp:PlaceHolder ID="tblExtrusionPlaceholder" runat="server"></asp:PlaceHolder>
    </div>

    <div id="panelCutSheet" runat="server">
        <h2 style="text-align:center">Panel Cut Sheet</h2>
        <asp:Label ID="lblPanelTag" runat="server" Text="Tag Name: TESTING"></asp:Label><br />
        <asp:Label ID="lblPanelCustomer" runat="server" Text ="Customer: ABC"></asp:Label><br />
        <asp:Label ID="lblPanelInterior" runat="server" Text="Panel Interior: WHITE"></asp:Label><br />
        <asp:Label ID="lblPanelExterior" runat="server" Text="Panel Exterior: WHITE"></asp:Label><br />
        <asp:Label ID="lblPanelType" runat="server" Text="Panel Type: 2&quot"></asp:Label><br /><br />

        <asp:PlaceHolder ID="tblPanelPlaceholder" runat="server"></asp:PlaceHolder>
    </div>
    <!-- style="visibility:hidden"-->
    <div id="roofCutSheet" runat="server">
        <h2 style="text-align:center">Roof Cut Sheet</h2>
        <asp:Label ID="lblRoofTag" runat="server" Text="Tag Name: TESTING"></asp:Label><br />
        <asp:Label ID="lblRoofCustomer" runat="server" Text ="Customer: ABC"></asp:Label><br />
        <asp:Label ID="lblRoofType" runat="server" Text="Roof Type: WHITE"></asp:Label><br />
        <asp:Label ID="lblRoofInterior" runat="server" Text="Panel Interior: WHITE"></asp:Label><br />
        <asp:Label ID="lblRoofExterior" runat="server" Text="Panel Exterior: WHITE CEDAR"></asp:Label><br />
        <asp:Label ID="lblRoofThickness" runat="server" Text="Thickness: 4&quot"></asp:Label><br /><br />

        <asp:PlaceHolder ID="tblRoofPlaceholder" runat="server"></asp:PlaceHolder>
    </div>
    
    <div id="boxCutSheet" runat="server">
        <h2 style="text-align:center">Box Prep Sheet</h2>
        <asp:Label ID="lblBoxTag" runat="server" Text="Tag Name: TESTING"></asp:Label><br />
        <asp:Label ID="lblBoxCustomer" runat="server" Text ="Customer: ABC"></asp:Label><br />
        <asp:Label ID="lblBoxWallType" runat="server" Text="Wall Type: Model 200 Studio"></asp:Label><br />
        <asp:Label ID="lblBoxFramingColour" runat="server" Text="Framing Colour: WHITE"></asp:Label><br />
        <asp:Label ID="lblBoxInterior" runat="server" Text="Panel Interior: White Aluminum Stucco"></asp:Label><br />
        <asp:Label ID="lblBoxExterior" runat="server" Text="Panel Exterior: White Aluminum Stucco"></asp:Label><br />
        <asp:Label ID="lblBoxRoofType" runat="server" Text="Roof Type: Pressure Cap OSB (4&quot x 1 lb x 0.024&quot)"></asp:Label><br />
        <asp:Label ID="lblBoxRoofSize" runat="server" Text="Roof Size: X&quot x Y&quot"></asp:Label><br /><br />

        <asp:PlaceHolder ID="tblBoxPlaceholder" runat="server"></asp:PlaceHolder>
    </div>
    
    <div id="vinylProduction" runat="server">
        <h2 style="text-align:center">Vinyl Window Production</h2>
        <asp:Label ID="lblVinylTag" runat="server" Text="Tag Name: TESTING"></asp:Label><br />
        <asp:Label ID="lblVinylCustomer" runat="server" Text ="Customer: ABC"></asp:Label><br />
        <asp:Label ID="lblVinylOrderType" runat="server" Text="Order Type: Sunroom Order"></asp:Label><br />
        <asp:Label ID="lblVinylShipDate" runat="server" Text="Ship Date: Nov 24th, 2020"></asp:Label><br />
        <asp:Label ID="lblVinylCompletedBy" runat="server" Text="Completed by: _________"></asp:Label><br />
        <asp:Label ID="lblVinylCompletedDate" runat="server" Text="Date Completed: _________"></asp:Label><br />><br />

        <asp:PlaceHolder ID="tblVinylProductionPlaceholder" runat="server"></asp:PlaceHolder>
    </div>

    <div id="sashCutSheet" runat="server">
        <h2 style="text-align:center">- Sash Cut Sheet - Vertical 4 Track -</h2>
        <asp:Label ID="lblSashTag" runat="server" Text="Tag Name: TESTING"></asp:Label><br />
        <asp:Label ID="lblSashCustomer" runat="server" Text ="Customer: ABC"></asp:Label><br />
        <asp:Label ID="lblSashOrderType" runat="server" Text="Order Type: Sunroom Order"></asp:Label><br />
        <asp:Label ID="lblSashShipDate" runat="server" Text="Ship Date: Nov 24th, 2020"></asp:Label><br />
        <asp:Label ID="lblSashCompletedBy" runat="server" Text="Completed by: _________"></asp:Label><br />
        <asp:Label ID="lblSashCompletedDate" runat="server" Text="Date Completed: _________"></asp:Label><br />><br />

        <asp:PlaceHolder ID="tblSashPlaceholder" runat="server"></asp:PlaceHolder>
    </div>

    <div id="frameCutSheet" runat="server">
        <h2 style="text-align:center">- Frame Cut Sheet - Vertical 4 Track -</h2>
        <asp:Label ID="lblFrameTag" runat="server" Text="Tag Name: TESTING"></asp:Label><br />
        <asp:Label ID="lblFrameCustomer" runat="server" Text ="Customer: ABC"></asp:Label><br />
        <asp:Label ID="lblFrameOrderType" runat="server" Text="Order Type: Sunroom Order"></asp:Label><br />
        <asp:Label ID="lblFrameShipDate" runat="server" Text="Ship Date: Nov 24th, 2020"></asp:Label><br />
        <asp:Label ID="lblFrameCompletedBy" runat="server" Text="Completed by: _________"></asp:Label><br />
        <asp:Label ID="lblFrameCompletedDate" runat="server" Text="Date Completed: _________"></asp:Label><br />><br />

        <asp:PlaceHolder ID="tblFramePlaceholder" runat="server"></asp:PlaceHolder>
    </div>
</asp:Content>

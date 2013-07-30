<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RoofWizard.aspx.cs" Inherits="SunspaceDealerDesktop.RoofWizard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <script>

    </script>

    <div class="slide-window"  >
        <div class="slide-wrapper"> 
            <%-- Slide 1 - Select a Customer --%>           
            <div id="slide1" class="slide">
                <h1>
                    <asp:Label ID="lblQuestion1" runat="server" Text="Would you like a roof overhang?"></asp:Label>
                </h1>        
                              
                <ul class="toggleOptions">
                    <%-- Overhang --%>
                    <li>
                        <asp:RadioButton ID="radOverhang" GroupName="question1" runat="server" />
                        <asp:Label ID="lblOverhangRadio" AssociatedControlID="radOverhang" runat="server"></asp:Label>
                        <asp:Label ID="lblOverhang" AssociatedControlID="radOverhang" runat="server" Text="Overhang"></asp:Label>
                    </li> 

                    <%-- No Overhang --%>
                    <li>
                        <asp:RadioButton ID="radNoOverhang" GroupName="question1" runat="server" />
                        <asp:Label ID="lblNoOverhangRadio" AssociatedControlID="radNoOverhang" runat="server"></asp:Label>
                        <asp:Label ID="lblNoOverhang" AssociatedControlID="radNoOverhang" runat="server" Text="No Overhang"></asp:Label>
                    </li> 
                </ul> 

                <asp:Button ID="btnQuestion1" CssClass="btnSubmit float-right slidePanel" data-slide="#slide2" runat="server" Text="Next Question" />

            </div>

            <%-- Slide 2 - Select a Skin --%>
            <div id="slide2" class="slide">
                <h1>
                    <asp:Label ID="lblSkins" runat="server" Text="Select roof skins"></asp:Label>
                </h1>

                <ul class="toggleOptions">
                    <li>
                        <asp:Label ID="lblInteriorRoofSkin" runat="server" Text="Interior Skin:"></asp:Label>
                        <asp:DropDownList ID="ddlInteriorRoofSkin" runat="server"></asp:DropDownList>
                    </li>
                    <li>
                        <asp:Label ID="lblExteriorRoofSkin" runat="server" Text="Exterior Skin:"></asp:Label>
                        <asp:DropDownList ID="ddlExteriorRoofSkin" runat="server"></asp:DropDownList>
                    </li>
                </ul>

                <asp:Button ID="btnQuestion2" CssClass="btnSubmit float-right slidePanel" data-slide="#slide3" runat="server" Text="Next Question" />
            </div>

            <%-- Slide 3 - Panel Splitting --%>
            <div id="slide3" class="slide">
                <h1>
                    
                </h1>
            </div>
        </div>
    </div>
</asp:Content>

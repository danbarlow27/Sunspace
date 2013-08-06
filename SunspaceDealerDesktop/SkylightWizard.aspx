<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SkylightWizard.aspx.cs" Inherits="SunspaceDealerDesktop.SkylightWizard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="slide-window"  >
        <div class="slide-wrapper"> 
            <%-- Slide 1 - Yes/no --%>
            <div id="slide1" class="slide">
                <h1>
                    <asp:Label ID="lblAsk" runat="server" Text="Would you like to include any skylights into your roof panels?"></asp:Label>
                </h1>

                <ul class="toggleOptions">
                    <li>
                        <asp:RadioButton ID="radSkylightsYes" GroupName="question1" runat="server" OnClick="skylightWizardCheckQuestion1()" />
                        <asp:Label ID="lblSkylightsYesRadio" AssociatedControlID="radSkylightsYes" runat="server"></asp:Label>
                        <asp:Label ID="lblSkylightsYes" AssociatedControlID="radSkylightsYes" runat="server" Text="Yes"></asp:Label>
                    </li>
                    <li>
                        <asp:RadioButton ID="radSkylightsNo" GroupName="question1" runat="server" OnClick="skylightWizardCheckQuestion1()" />
                        <asp:Label ID="lblSkylightsNoRadio" AssociatedControlID="radSkylightsNo" runat="server"></asp:Label>
                        <asp:Label ID="lblSkylightsNo" AssociatedControlID="radSkylightsNo" runat="server" Text="No"></asp:Label>
                    </li>
                </ul>
                
                <asp:Button ID="btnQuestion1" CssClass="btnSubmit float-right slidePanel" data-slide="#slide2" runat="server" Text="Next Question" Enabled="false" />
            </div>
        </div>
    </div>
</asp:Content>

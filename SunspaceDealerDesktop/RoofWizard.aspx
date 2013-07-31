<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RoofWizard.aspx.cs" Inherits="SunspaceDealerDesktop.RoofWizard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        function roofWizardCheckQuestion1() {
            if ($('#<%=txtOverhangLength.ClientID%>').val() == "") {
                //please enter a valid number
                document.getElementById('<%=btnQuestion1.ClientID%>').disabled = true;
            }
            else if (isNaN($('#<%=txtOverhangLength.ClientID%>').val())) {
                //please enter a valid number
                document.getElementById('<%=btnQuestion1.ClientID%>').disabled = true;
            }
            else {
                document.getElementById('<%=btnQuestion1.ClientID%>').disabled = false;
            }

            document.getElementById("<%=hidOverhang.ClientID%>").value = $('#<%=txtOverhangLength.ClientID%>').val();
        }

        function roofWizardCheckQuestion2() {
            //move to hidden interior/exterior
            document.getElementById("<%=hidInteriorRoofSkin.ClientID%>").value = $('#<%=ddlInteriorRoofSkin.ClientID%>').val();
            document.getElementById("<%=hidExteriorRoofSkin.ClientID%>").value = $('#<%=ddlExteriorRoofSkin.ClientID%>').val();
        }

        function roofWizardCheckQuestion3() {
            //move to hidden colour/presence/remove/pro
            document.getElementById("<%=hidExteriorRoofSkin.ClientID%>").value = $('#<%=ddlExteriorRoofSkin.ClientID%>').val();
        }
    </script>

    <div class="slide-window"  >
        <div class="slide-wrapper"> 
            <%-- Slide 1 - Select a Customer --%>           
            <div id="slide1" class="slide">
                <h1>
                    <asp:Label ID="lblQuestion1" runat="server" Text="Would you like a roof overhang?"></asp:Label>
                </h1>        
                              
                <ul class="toggleOptions">
                    <li>
                        <asp:Label ID="lblOverhangLength" runat="server" Text="Overhang Length"></asp:Label>
                        <asp:TextBox ID="txtOverhangLength" runat="server" onkeyup="roofWizardCheckQuestion1()"></asp:TextBox>
                        <br />
                        <asp:Label ID="lblOverhangWarning" runat="server" Text="Enter 0 for no overhang"></asp:Label>
                    </li>
                </ul>

                <asp:Button ID="btnQuestion1" CssClass="btnSubmit float-right slidePanel" data-slide="#slide2" runat="server" Text="Next Question" Enabled="false" />

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

            <%-- Slide 3 - Gutter --%>
            <div id="slide3" class="slide">
                <h1>
                    <asp:Label ID="lblGutterOptions" runat="server" Text="Would you like gutters?"></asp:Label>
                </h1>

                <ul class="toggleOptions">
                    <li>
                        <asp:Label ID="lblGutterColour" runat="server" Text="Gutter/Fascia Colour:"></asp:Label>
                        <asp:DropDownList ID="ddlGutterColour" runat="server" OnChange="roofWizardCheckQuestion3()"></asp:DropDownList>
                    </li>
                    <li>
                        <asp:RadioButton ID="radGutterPresenceYes" GroupName="question3" runat="server" OnClick="roofWizardCheckQuestion3()" />
                        <asp:Label ID="lblGutterPresenceYesRadio" AssociatedControlID="radGutterPresenceYes" runat="server"></asp:Label>
                        <asp:Label ID="lblGutterPresenceYes" AssociatedControlID="radGutterPresenceYes" runat="server" Text="Yes"></asp:Label>

                        <%--Gutter Options --%>
                        <div class="toggleContent">
                            <ul>
                                <li>
                                    <asp:CheckBox ID="chkGutterRemove" runat="server" OnClick="roofWizardCheckQuestion3()" />
                                    <asp:Label ID="lblGutterRemoveCheck" AssociatedControlID="chkGutterRemove" runat="server"></asp:Label>
                                    <asp:Label ID="lblGutterRemove" AssociatedControlID="chkGutterRemove" runat="server" Text="Remove from overhang to fit"></asp:Label>
                                </li>
                                <li>
                                    <asp:CheckBox ID="chkGutterPro" runat="server" OnClick="roofWizardCheckQuestion3()" />
                                    <asp:Label ID="lblGutterProCheck" AssociatedControlID="chkGutterPro" runat="server"></asp:Label>
                                    <asp:Label ID="lblGutterPro" AssociatedControlID="chkGutterPro" runat="server" Text="Gutter pro gutters"></asp:Label>
                                </li>
                            </ul>
                        </div>
                    </li>
                    <li>
                        <asp:RadioButton ID="radGutterPresenceNo" GroupName="question3" runat="server" OnClick="roofWizardCheckQuestion3()" />
                        <asp:Label ID="lblGutterPresenceNoRadio" AssociatedControlID="radGutterPresenceNo" runat="server"></asp:Label>
                        <asp:Label ID="lblGutterPresenceNo" AssociatedControlID="radGutterPresenceNo" runat="server" Text="No"></asp:Label>
                    </li>
                </ul>

                <asp:Button ID="btnFinalButton" CssClass="btnSubmit float-right slidePanel" runat="server" OnClick="btnFinalButton_Click" Text="Submit" />
            </div>
        </div>
    </div>

    <input id="hidOverhang" type="hidden" runat="server" />
    
    <input id="hidInteriorRoofSkin" type="hidden" runat="server" />
    <input id="hidExteriorRoofSkin" type="hidden" runat="server" />
    
    <input id="hidGutterColour" type="hidden" runat="server" />
    <input id="hidGutterPresence" type="hidden" runat="server" />
    <input id="hidGutterRemove" type="hidden" runat="server" />
    <input id="hidGutterPro" type="hidden" runat="server" />
</asp:Content>

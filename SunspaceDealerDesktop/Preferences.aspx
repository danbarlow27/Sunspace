<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Preferences.aspx.cs" Inherits="SunspaceDealerDesktop.Home" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <script>
        function preferencesCascadeColours(modelNumber) {
            console.log("Cascading Colours");

            if (modelNumber == 100) {
                ddlFramingColour = document.getElementById("<%= ddl100FrameColour.ClientID %>");
                if (ddlFramingColour.options[ddlFramingColour.selectedIndex].value == "White") {
                    $("#<%=ddl100InteriorPanelColour.ClientID%>").val('White');
                    $("#<%=ddl100InteriorPanelSkin.ClientID%>").val('White Aluminum Stucco');
                    $("#<%=ddl100ExteriorPanelColour.ClientID%>").val('White');
                    $("#<%=ddl100ExteriorPanelSkin.ClientID%>").val('White Aluminum Stucco');
                }
                else if (ddlFramingColour.options[ddlFramingColour.selectedIndex].value == "Driftwood") {
                    $("#<%=ddl100InteriorPanelColour.ClientID%>").val('Driftwood');
                    $("#<%=ddl100InteriorPanelSkin.ClientID%>").val('Driftwood Aluminum Stucco');
                    $("#<%=ddl100ExteriorPanelColour.ClientID%>").val('Driftwood');
                    $("#<%=ddl100ExteriorPanelSkin.ClientID%>").val('Driftwood Aluminum Stucco');
                }
                else if (ddlFramingColour.options[ddlFramingColour.selectedIndex].value == "Bronze") {
                    $("#<%=ddl100InteriorPanelColour.ClientID%>").val('Bronze');
                    $("#<%=ddl100InteriorPanelSkin.ClientID%>").val('Bronze Aluminum Stucco');
                    $("#<%=ddl100ExteriorPanelColour.ClientID%>").val('Bronze');
                    $("#<%=ddl100ExteriorPanelSkin.ClientID%>").val('Bronze Aluminum Stucco');
                }
            }
            else if (modelNumber == 200) {
                ddlFramingColour = document.getElementById("<%= ddl200FrameColour.ClientID %>");
                if (ddlFramingColour.options[ddlFramingColour.selectedIndex].value == "White") {
                    $("#<%=ddl200InteriorPanelColour.ClientID%>").val('White');
                    $("#<%=ddl200InteriorPanelSkin.ClientID%>").val('White Aluminum Stucco');
                    $("#<%=ddl200ExteriorPanelColour.ClientID%>").val('White');
                    $("#<%=ddl200ExteriorPanelSkin.ClientID%>").val('White Aluminum Stucco');
                }
                else if (ddlFramingColour.options[ddlFramingColour.selectedIndex].value == "Driftwood") {
                    $("#<%=ddl200InteriorPanelColour.ClientID%>").val('Driftwood');
                    $("#<%=ddl200InteriorPanelSkin.ClientID%>").val('Driftwood Aluminum Stucco');
                    $("#<%=ddl200ExteriorPanelColour.ClientID%>").val('Driftwood');
                    $("#<%=ddl200ExteriorPanelSkin.ClientID%>").val('Driftwood Aluminum Stucco');
                }
                else if (ddlFramingColour.options[ddlFramingColour.selectedIndex].value == "Bronze") {
                    $("#<%=ddl200InteriorPanelColour.ClientID%>").val('Bronze');
                    $("#<%=ddl200InteriorPanelSkin.ClientID%>").val('Bronze Aluminum Stucco');
                    $("#<%=ddl200ExteriorPanelColour.ClientID%>").val('Bronze');
                    $("#<%=ddl200ExteriorPanelSkin.ClientID%>").val('Bronze Aluminum Stucco');
                }
            }
            else if (modelNumber == 300) {
                ddlFramingColour = document.getElementById("<%= ddl300FrameColour.ClientID %>");
                if (ddlFramingColour.options[ddlFramingColour.selectedIndex].value == "White") {
                    $("#<%=ddl300InteriorPanelColour.ClientID%>").val('White');
                    $("#<%=ddl300InteriorPanelSkin.ClientID%>").val('White Aluminum Stucco');
                    $("#<%=ddl300ExteriorPanelColour.ClientID%>").val('White');
                    $("#<%=ddl300ExteriorPanelSkin.ClientID%>").val('White Aluminum Stucco');
                }
                else if (ddlFramingColour.options[ddlFramingColour.selectedIndex].value == "Driftwood") {
                    $("#<%=ddl300InteriorPanelColour.ClientID%>").val('Driftwood');
                    $("#<%=ddl300InteriorPanelSkin.ClientID%>").val('Driftwood Aluminum Stucco');
                    $("#<%=ddl300ExteriorPanelColour.ClientID%>").val('Driftwood');
                    $("#<%=ddl300ExteriorPanelSkin.ClientID%>").val('Driftwood Aluminum Stucco');
                }
                else if (ddlFramingColour.options[ddlFramingColour.selectedIndex].value == "Bronze") {
                    $("#<%=ddl300InteriorPanelColour.ClientID%>").val('Bronze');
                    $("#<%=ddl300InteriorPanelSkin.ClientID%>").val('Bronze Aluminum Stucco');
                    $("#<%=ddl300ExteriorPanelColour.ClientID%>").val('Bronze');
                    $("#<%=ddl300ExteriorPanelSkin.ClientID%>").val('Bronze Aluminum Stucco');
                }
            }
            else if (modelNumber == 400) {
                ddlFramingColour = document.getElementById("<%= ddl400FrameColour.ClientID %>");
                if (ddlFramingColour.options[ddlFramingColour.selectedIndex].value == "White") {
                    $("#<%=ddl400InteriorPanelColour.ClientID%>").val('White');
                    $("#<%=ddl400InteriorPanelSkin.ClientID%>").val('White Aluminum Stucco');
                    $("#<%=ddl400ExteriorPanelColour.ClientID%>").val('White');
                    $("#<%=ddl400ExteriorPanelSkin.ClientID%>").val('White Aluminum Stucco');
                }
                else if (ddlFramingColour.options[ddlFramingColour.selectedIndex].value == "Driftwood") {
                    $("#<%=ddl400InteriorPanelColour.ClientID%>").val('Driftwood');
                    $("#<%=ddl400InteriorPanelSkin.ClientID%>").val('Driftwood Aluminum Stucco');
                    $("#<%=ddl400ExteriorPanelColour.ClientID%>").val('Driftwood');
                    $("#<%=ddl400ExteriorPanelSkin.ClientID%>").val('Driftwood Aluminum Stucco');
                }
            }       

             //now that colours have cascading we still need to validate the slide
            //newProjectCheckQuestion4();
}
    </script>
    <div>
        <asp:Label Text ="Welcome " ID="lblWelcome" runat="server"></asp:Label>
        <asp:Label Text ="*Insert User Name*" ID="lblUser" runat="server"></asp:Label>
    </div>

    <div class="slide-window no-sidebar">

        <div class="slide-wrapper">
            <asp:Label ID="lblError" runat="server"></asp:Label>

            <div id="slide1" class="slide">
                <%-- fancy --%>
                <h1>
                    <asp:Label ID="lblPreferences" runat="server" Text="Set your preferences below"></asp:Label>
                </h1>        
                              
                <ul class="toggleOptions">

                    <%-- Sunroom Preferences --%>
                    <li>
                        <asp:RadioButton ID="radSunroomPref" GroupName="preferences" runat="server" />
                        <asp:Label ID="lblSunroomPrefRadio" AssociatedControlID="radSunroomPref" runat="server"></asp:Label>
                        <asp:Label ID="lblSunroomPref" AssociatedControlID="radSunroomPref" runat="server" Text="Sunroom Preferences"></asp:Label>
           
                        <div class="toggleContent">
                            <ul>
                                <li>
                                    <ul class="toggleOptions">
                                        <%-- General Preferences --%>
                                        <li>                                            
                                            <asp:RadioButton ID="radGeneralPref" GroupName="sunroomModels" runat="server" />
                                            <asp:Label ID="lblGeneralPrefRadio" AssociatedControlID="radGeneralPref" runat="server"></asp:Label>
                                            <asp:Label ID="lblGeneralPref" AssociatedControlID="radGeneralPref" runat="server" Text="General"></asp:Label>

                                            <%-- General Pref Inputs --%>
                                            <div class="toggleContent">
                                                <ul>
                                                    <li>
                                                        <%-- Installation Type --%>
                                                        <asp:Label ID="lblInstallationType" runat="server" Text="Installation Type:"></asp:Label>
                                                        <asp:DropDownList ID="ddlInstallationType" runat="server"></asp:DropDownList>
                                                    </li>
                                                    <li>
                                                        <%-- Model Type --%>
                                                        <asp:Label ID="lblModelNumber" runat="server" Text="Model Type:"></asp:Label>
                                                        <asp:DropDownList ID="ddlModelNumber" runat="server"></asp:DropDownList>
                                                    </li>
                                                    <li>
                                                        <%-- Layout --%>
                                                        <asp:Label ID="lblLayoutDefault" runat="server" Text="Layout Default:"></asp:Label>
                                                        <asp:DropDownList ID="ddlLayoutDefault" runat="server"></asp:DropDownList>
                                                    </li>                                                  
                                                    <li>
                                                        <%-- Cut Pitch Option --%>
                                                        <asp:CheckBox ID="chkCutPitch" runat="server" />
                                                        <asp:Label ID="lblCutPitchCheck" AssociatedControlID="chkCutPitch" runat="server"></asp:Label>
                                                        <asp:Label ID="lblCutPitch" AssociatedControlID="chkCutPitch" runat="server" Text="Cut Pitch"></asp:Label>                                                                
                                                    </li>
                                                </ul>
                                            </div>
                                        </li>

                                        <%-- Model 100 Preferences --%>
                                        <li>
                                            <asp:RadioButton ID="radSunroom100" GroupName="sunroomModels" runat="server" />
                                            <asp:Label ID="lblSunroom100Radio" AssociatedControlID="radSunroom100" runat="server"></asp:Label>
                                            <asp:Label ID="lblSunroom100" AssociatedControlID="radSunroom100" runat="server" Text="Model 100"></asp:Label>                                    
                                            
                                            <%-- Model 100 Inputs --%>
                                            <div class="toggleContent">
                                                <ul>
                                                    <li>
                                                        <ul class="toggleOptions">
                                                            <li>
                                                                <%-- Default Filler Option --%>
                                                                <asp:Label ID="lbl100DefaultFiller" runat="server" Text="Default Filler: "></asp:Label>
                                                                <asp:TextBox ID="txt100DefaultFiller" runat="server" CssClass="txtLengthInput"></asp:TextBox>
                                                                <asp:DropDownList ID="ddl100DefaultFiller" runat="server"></asp:DropDownList>
                                                            </li>                                                            
                                                            <li>
                                                                <%-- Markup --%>
                                                                <asp:Label ID="lbl100Markup" runat="server" Text="Markup:"></asp:Label>
                                                                <asp:TextBox ID="txt100Markup" runat="server"></asp:TextBox>
                                                            </li>  
                                                            <li>
                                                                <%-- Wall Colours --%>
                                                                <asp:RadioButton ID="rad100WallColours" GroupName="sunroomModel100" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl100WallColoursRadio" AssociatedControlID="rad100WallColours" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl100WallColours" AssociatedControlID="rad100WallColours" runat="server" Text="Wall Colours"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Frame Colour --%>
                                                                                    <asp:Label ID="lbl100FrameColour" runat="server" Text="Frame Colour:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100FrameColour" runat="server" OnChange="preferencesCascadeColours(100)"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Interior Panel Colour --%>
                                                                                    <asp:Label ID="lbl100InteriorPanelColour" runat="server" Text="Interior Panel Colour:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100InteriorPanelColour" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Interior Panel Skin --%>
                                                                                    <asp:Label ID="lbl100InteriorPanelSkin" runat="server" Text="Interior Panel Skin:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100InteriorPanelSkin" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Exterior Panel Colour --%>
                                                                                    <asp:Label ID="lbl100ExteriorPanelColour" runat="server" Text="Exterior Panel Colour:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100ExteriorPanelColour" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Exterior Panel Skin --%>
                                                                                    <asp:Label ID="lbl100ExteriorPanelSkin" runat="server" Text="Exterior Panel Skin:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100ExteriorPanelSkin" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Door options --%>
                                                                <asp:RadioButton ID="rad100DoorOptions" GroupName="sunroomModel100" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl100DoorOptionsRadio" AssociatedControlID="rad100DoorOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl100DoorOptions" AssociatedControlID="rad100DoorOptions" runat="server" Text="Door Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Door Type --%>
                                                                                    <asp:Label ID="lbl100DoorType" runat="server" Text="Door Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100DoorType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Style --%>
                                                                                    <asp:Label ID="lbl100DoorStyle" runat="server" Text="Door Style:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100DoorStyle" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Swing --%>
                                                                                    <asp:Label ID="lbl100DoorSwing" runat="server" Text="Door Swing:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100DoorSwing" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Hinge --%>
                                                                                    <asp:Label ID="lbl100DoorHinge" runat="server" Text="Door Hinge:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100DoorHinge" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Hardware --%>
                                                                                    <asp:Label ID="lbl100DoorHardware" runat="server" Text="Door Hardware:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100DoorHardware" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Colour --%>
                                                                                    <asp:Label ID="lbl100DoorColour" runat="server" Text="Door Colour:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100DoorColour" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Glass Tint --%>
                                                                                    <asp:Label ID="lbl100DoorGlassTint" runat="server" Text="Door Glass Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100DoorGlassTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Vinyl Tint --%>
                                                                                    <asp:Label ID="lbl100DoorVinylTint" runat="server" Text="Door Vinyl Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100DoorVinylTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Screen Type --%>
                                                                                    <asp:Label ID="lbl100DoorScreenType" runat="server" Text="Door Screen Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100DoorScreenType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Window options --%>
                                                                <asp:RadioButton ID="rad100WindowOptions" GroupName="sunroomModel100" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl100WindowOptionsRadio" AssociatedControlID="rad100WindowOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl100WindowOptions" AssociatedControlID="rad100WindowOptions" runat="server" Text="Window Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Window Type --%>
                                                                                    <asp:Label ID="lbl100WindowType" runat="server" Text="Window Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100WindowType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <%-- No Window colour for model 100, vinyl only --%>
                                                                                <li>
                                                                                    <%-- Window Glass Tint --%>
                                                                                    <asp:Label ID="lbl100WindowGlassTint" runat="server" Text="Window Glass Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100WindowGlassTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Window Vinyl Tint --%>
                                                                                    <asp:Label ID="lbl100WindowVinylTint" runat="server" Text="Window Vinyl Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100WindowVinylTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Window Screen Type --%>
                                                                                    <asp:Label ID="lbl100WindowScreenType" runat="server" Text="Window Screen Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100WindowScreenType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Sunshade options --%>
                                                                <asp:RadioButton ID="rad100SunshadeOptions" GroupName="sunroomModel100" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl100SunshadeOptionsRadio" AssociatedControlID="rad100SunshadeOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl100SunshadeOptions" AssociatedControlID="rad100SunshadeOptions" runat="server" Text="Sunshade Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Sunshade Valance Colour --%>
                                                                                    <asp:Label ID="lbl100SunshadeValanceColour" runat="server" Text="Sunshade Valance Colour:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100SunshadeValanceColour" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Sunshade Fabric --%>
                                                                                    <asp:Label ID="lbl100SunshadeFabricColour" runat="server" Text="Sunshade Fabric:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100SunshadeFabricColour" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Sunshade Openness --%>
                                                                                    <asp:Label ID="lbl100SunshadeOpenness" runat="server" Text="Sunshade Openness:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100SunshadeOpenness" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Roof options --%>
                                                                <asp:RadioButton ID="rad100RoofOptions" GroupName="sunroomModel100" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl100RoofOptionsRadio" AssociatedControlID="rad100RoofOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl100RoofOptions" AssociatedControlID="rad100RoofOptions" runat="server" Text="Roof Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Roof Type --%>
                                                                                    <asp:Label ID="lbl100RoofType" runat="server" Text="Roof Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100RoofType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Interior Skin --%>
                                                                                    <asp:Label ID="lbl100RoofInteriorSkin" runat="server" Text="Roof Interior Skin:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100RoofInteriorSkin" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Exterior Skin --%>
                                                                                    <asp:Label ID="lbl100RoofExteriorSkin" runat="server" Text="Roof Exterior Skin:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100RoofExteriorSkin" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Thickness --%>
                                                                                    <asp:Label ID="lbl100RoofThickness" runat="server" Text="Roof Thickness:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100RoofThickness" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Floor options --%>
                                                                <asp:RadioButton ID="rad100FloorOptions" GroupName="sunroomModel100" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl100FloorOptionsRadio" AssociatedControlID="rad100FloorOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl100FloorOptions" AssociatedControlID="rad100FloorOptions" runat="server" Text="Floor Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Thickness --%>
                                                                                    <asp:Label ID="lbl100FloorThickness" runat="server" Text="Floor Thickness:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100FloorThickness" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>                                                                                    
                                                                                    <%-- Metal Barrier --%>
                                                                                    <asp:CheckBox ID="chk100FloorMetalBarrier" runat="server" />
                                                                                    <asp:Label ID="lbl100FloorMetalBarrierCheck" AssociatedControlID="chk100FloorMetalBarrier" runat="server" ></asp:Label>
                                                                                    <asp:Label ID="lbl100FloorMetalBarrier" AssociatedControlID="chk100FloorMetalBarrier" runat="server" Text="Floor Metal Barrier:"></asp:Label>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Kneewall options --%>
                                                                <asp:RadioButton ID="rad100KneewallOptions" GroupName="sunroomModel100" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl100KneewallOptionsRadio" AssociatedControlID="rad100KneewallOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl100KneewallOptions" AssociatedControlID="rad100KneewallOptions" runat="server" Text="Kneewall Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Height --%>
                                                                                    <asp:Label ID="lbl100KneewallHeight" runat="server" Text="Kneewall Height:"></asp:Label>
                                                                                    <asp:TextBox ID="txt100KneewallHeight" runat="server"></asp:TextBox>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Type --%>
                                                                                    <asp:Label ID="lbl100KneewallType" runat="server" Text="Kneewall Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100KneewallType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Glass Tint --%>
                                                                                    <asp:Label ID="lbl100KneewallGlassTint" runat="server" Text="Kneewall Glass Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100KneewallGlassTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Transom options --%>
                                                                <asp:RadioButton ID="rad100TransomOptions" GroupName="sunroomModel100" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl100TransomOptionsRadio" AssociatedControlID="rad100TransomOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl100TransomOptions" AssociatedControlID="rad100TransomOptions" runat="server" Text="Transom Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Height --%>
                                                                                    <asp:Label ID="lbl100TransomHeight" runat="server" Text="Transom Height:"></asp:Label>
                                                                                    <asp:TextBox ID="txt100TransomHeight" runat="server"></asp:TextBox>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- style --%>
                                                                                    <asp:Label ID="lbl100TransomType" runat="server" Text="Transom Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100TransomType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- glass tint --%>
                                                                                    <asp:Label ID="lbl100TransomGlassTint" runat="server" Text="Transom Glass Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100TransomGlassTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- vinyl tint --%>
                                                                                    <asp:Label ID="lbl100TransomVinylTint" runat="server" Text="Transom Vinyl Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100TransomVinylTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- screen type --%>
                                                                                    <asp:Label ID="lbl100TransomScreenType" runat="server" Text="Transom Screen Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100TransomScreenType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                        </ul>
                                                        

                                                        <%--InteriorSkin
	                                                    ExteriorSkin
	                                                    DoorType/DoorSubtype/DoorOptions
	                                                    WindowType/WindowOptions
	                                                    PresetLayout
	                                                    InstallType
	                                                    Sunshades/SunshadeOptions
	                                                    RoofType/RoofOptions
	                                                    FloorType/FloorOptions
	                                                    KneewallOptions
	                                                    TransomOptions
	                                                    CutPitch
	                                                    DefaultFiller--%>
                                                    </li>                                            
                                                </ul>
                                            </div>
                                        </li>


                                        <%-- Model 200 Preferences --%>
                                        <li>
                                            <asp:RadioButton ID="radSunroom200" GroupName="sunroomModels" runat="server" />
                                            <asp:Label ID="lblSunroom200Radio" AssociatedControlID="radSunroom200" runat="server"></asp:Label>
                                            <asp:Label ID="lblSunroom200" AssociatedControlID="radSunroom200" runat="server" Text="Model 200"></asp:Label>
                                            
                                            <%-- Model 200 Inputs --%>
                                            <div class="toggleContent">
                                                <ul>
                                                    <li>
                                                        <ul class="toggleOptions">
                                                            <li>
                                                                <%-- Default Filler Option --%>
                                                                <asp:Label ID="lbl200DefaultFiller" runat="server" Text="Default Filler: "></asp:Label>
                                                                <asp:TextBox ID="txt200DefaultFiller" runat="server" CssClass="txtLengthInput"></asp:TextBox>
                                                                <asp:DropDownList ID="ddl200DefaultFiller" runat="server"></asp:DropDownList>
                                                            </li>                                                            
                                                            <li>
                                                                <%-- Markup --%>
                                                                <asp:Label ID="lbl200Markup" runat="server" Text="Markup:"></asp:Label>
                                                                <asp:TextBox ID="txt200Markup" runat="server"></asp:TextBox>
                                                            </li> 
                                                            <li>
                                                                <%-- Wall Colours --%>
                                                                <asp:RadioButton ID="rad200WallColours" GroupName="sunroomModel200" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl200WallColoursRadio" AssociatedControlID="rad200WallColours" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl200WallColours" AssociatedControlID="rad200WallColours" runat="server" Text="Wall Colours"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Frame Colour --%>
                                                                                    <asp:Label ID="lbl200FrameColour" runat="server" Text="Frame Colour:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200FrameColour" runat="server" OnChange="preferencesCascadeColours(200)"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Interior Panel Colour --%>
                                                                                    <asp:Label ID="lbl200InteriorPanelColour" runat="server" Text="Interior Panel Colour:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200InteriorPanelColour" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Interior Panel Skin --%>
                                                                                    <asp:Label ID="lbl200InteriorPanelSkin" runat="server" Text="Interior Panel Skin:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200InteriorPanelSkin" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Exterior Panel Colour --%>
                                                                                    <asp:Label ID="lbl200ExteriorPanelColour" runat="server" Text="Exterior Panel Colour:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200ExteriorPanelColour" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Exterior Panel Skin --%>
                                                                                    <asp:Label ID="lbl200ExteriorPanelSkin" runat="server" Text="Exterior Panel Skin:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200ExteriorPanelSkin" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Door options --%>
                                                                <asp:RadioButton ID="rad200DoorOptions" GroupName="sunroomModel200" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl200DoorOptionsRadio" AssociatedControlID="rad200DoorOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl200DoorOptions" AssociatedControlID="rad200DoorOptions" runat="server" Text="Door Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Door Type --%>
                                                                                    <asp:Label ID="lbl200DoorType" runat="server" Text="Door Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200DoorType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Style --%>
                                                                                    <asp:Label ID="lbl200DoorStyle" runat="server" Text="Door Style:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200DoorStyle" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Swing --%>
                                                                                    <asp:Label ID="lbl200DoorSwing" runat="server" Text="Door Swing:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200DoorSwing" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Hinge --%>
                                                                                    <asp:Label ID="lbl200DoorHinge" runat="server" Text="Door Hinge:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200DoorHinge" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Hardware --%>
                                                                                    <asp:Label ID="lbl200DoorHardware" runat="server" Text="Door Hardware:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200DoorHardware" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Colour --%>
                                                                                    <asp:Label ID="lbl200DoorColour" runat="server" Text="Door Colour:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200DoorColour" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Glass Tint --%>
                                                                                    <asp:Label ID="lbl200DoorGlassTint" runat="server" Text="Door Glass Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200DoorGlassTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Vinyl Tint --%>
                                                                                    <asp:Label ID="lbl200DoorVinylTint" runat="server" Text="Door Vinyl Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200DoorVinylTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Screen Type --%>
                                                                                    <asp:Label ID="lbl200DoorScreenType" runat="server" Text="Door Screen Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200DoorScreenType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Window options --%>
                                                                <asp:RadioButton ID="rad200WindowOptions" GroupName="sunroomModel200" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl200WindowOptionsRadio" AssociatedControlID="rad200WindowOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl200WindowOptions" AssociatedControlID="rad200WindowOptions" runat="server" Text="Window Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Window Type --%>
                                                                                    <asp:Label ID="lbl200WindowType" runat="server" Text="Window Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200WindowType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Window Colour --%>
                                                                                    <asp:Label ID="lbl200WindowColour" runat="server" Text="Window Colour:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200WindowColour" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Window Glass Tint --%>
                                                                                    <asp:Label ID="lbl200WindowGlassTint" runat="server" Text="Window Glass Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200WindowGlassTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Window Vinyl Tint --%>
                                                                                    <asp:Label ID="lbl200WindowVinylTint" runat="server" Text="Window Vinyl Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200WindowVinylTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Window Screen Type --%>
                                                                                    <asp:Label ID="lbl200WindowScreenType" runat="server" Text="Window Screen Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200WindowScreenType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Sunshade options --%>
                                                                <asp:RadioButton ID="rad200SunshadeOptions" GroupName="sunroomModel200" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl200SunshadeOptionsRadio" AssociatedControlID="rad200SunshadeOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl200SunshadeOptions" AssociatedControlID="rad200SunshadeOptions" runat="server" Text="Sunshade Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Sunshade Valance Colour --%>
                                                                                    <asp:Label ID="lbl200SunshadeValanceColour" runat="server" Text="Sunshade Valance Colour:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200SunshadeValanceColour" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Sunshade Fabric --%>
                                                                                    <asp:Label ID="lbl200SunshadeFabricColour" runat="server" Text="Sunshade Fabric:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200SunshadeFabricColour" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Sunshade Openness --%>
                                                                                    <asp:Label ID="lbl200SunshadeOpenness" runat="server" Text="Sunshade Openness:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200SunshadeOpenness" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Roof options --%>
                                                                <asp:RadioButton ID="rad200RoofOptions" GroupName="sunroomModel200" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl200RoofOptionsRadio" AssociatedControlID="rad200RoofOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl200RoofOptions" AssociatedControlID="rad200RoofOptions" runat="server" Text="Roof Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Roof Type --%>
                                                                                    <asp:Label ID="lbl200RoofType" runat="server" Text="Roof Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200RoofType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Interior Skin --%>
                                                                                    <asp:Label ID="lbl200RoofInteriorSkin" runat="server" Text="Roof Interior Skin:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200RoofInteriorSkin" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Exterior Skin --%>
                                                                                    <asp:Label ID="lbl200RoofExteriorSkin" runat="server" Text="Roof Exterior Skin:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200RoofExteriorSkin" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Thickness --%>
                                                                                    <asp:Label ID="lbl200RoofThickness" runat="server" Text="Roof Thickness:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200RoofThickness" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Floor options --%>
                                                                <asp:RadioButton ID="rad200FloorOptions" GroupName="sunroomModel200" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl200FloorOptionsRadio" AssociatedControlID="rad200FloorOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl200FloorOptions" AssociatedControlID="rad200FloorOptions" runat="server" Text="Floor Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Thickness --%>
                                                                                    <asp:Label ID="lbl200FloorThickness" runat="server" Text="Floor Thickness:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200FloorThickness" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>                                                                                    
                                                                                    <%-- Metal Barrier --%>
                                                                                    <asp:CheckBox ID="chk200FloorMetalBarrier" runat="server" />
                                                                                    <asp:Label ID="lbl200FloorMetalBarrierCheck" AssociatedControlID="chk200FloorMetalBarrier" runat="server" ></asp:Label>
                                                                                    <asp:Label ID="lbl200FloorMetalBarrier" AssociatedControlID="chk200FloorMetalBarrier" runat="server" Text="Floor Metal Barrier:"></asp:Label>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Kneewall options --%>
                                                                <asp:RadioButton ID="rad200KneewallOptions" GroupName="sunroomModel200" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl200KneewallOptionsRadio" AssociatedControlID="rad200KneewallOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl200KneewallOptions" AssociatedControlID="rad200KneewallOptions" runat="server" Text="Kneewall Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Height --%>
                                                                                    <asp:Label ID="lbl200KneewallHeight" runat="server" Text="Kneewall Height:"></asp:Label>
                                                                                    <asp:TextBox ID="txt200KneewallHeight" runat="server"></asp:TextBox>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Type --%>
                                                                                    <asp:Label ID="lbl200KneewallType" runat="server" Text="Kneewall Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200KneewallType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Glass Tint --%>
                                                                                    <asp:Label ID="lbl200KneewallGlassTint" runat="server" Text="Kneewall Glass Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200KneewallGlassTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Transom options --%>
                                                                <asp:RadioButton ID="rad200TransomOptions" GroupName="sunroomModel200" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl200TransomOptionsRadio" AssociatedControlID="rad200TransomOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl200TransomOptions" AssociatedControlID="rad200TransomOptions" runat="server" Text="Transom Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Height --%>
                                                                                    <asp:Label ID="lbl200TransomHeight" runat="server" Text="Transom Height:"></asp:Label>
                                                                                    <asp:TextBox ID="txt200TransomHeight" runat="server"></asp:TextBox>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- style --%>
                                                                                    <asp:Label ID="lbl200TransomType" runat="server" Text="Transom Style:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200TransomType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- glass tint --%>
                                                                                    <asp:Label ID="lbl200TransomGlassTint" runat="server" Text="Transom Glass Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200TransomGlassTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- vinyl tint --%>
                                                                                    <asp:Label ID="lbl200TransomVinylTint" runat="server" Text="Transom Vinyl Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200TransomVinylTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- screen type --%>
                                                                                    <asp:Label ID="lbl200TransomScreenType" runat="server" Text="Transom Screen Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200TransomScreenType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                        </ul>
                                                        

                                                        <%--InteriorSkin
	                                                    ExteriorSkin
	                                                    DoorType/DoorSubtype/DoorOptions
	                                                    WindowType/WindowOptions
	                                                    PresetLayout
	                                                    InstallType
	                                                    Sunshades/SunshadeOptions
	                                                    RoofType/RoofOptions
	                                                    FloorType/FloorOptions
	                                                    KneewallOptions
	                                                    TransomOptions
	                                                    CutPitch
	                                                    DefaultFiller--%>
                                                    </li>                                            
                                                </ul>
                                            </div>
                                        </li>


                                        <%-- Model 300 Preferences --%>
                                        <li>
                                            <asp:RadioButton ID="radSunroom300" GroupName="sunroomModels" runat="server" />
                                            <asp:Label ID="lblSunroom300Radio" AssociatedControlID="radSunroom300" runat="server"></asp:Label>
                                            <asp:Label ID="lblSunroom300" AssociatedControlID="radSunroom300" runat="server" Text="Model 300"></asp:Label>

                                            
                                            <%-- Model 300 Inputs --%>
                                            <div class="toggleContent">
                                                <ul>
                                                    <li>
                                                        <ul class="toggleOptions">
                                                            <li>
                                                                <%-- Default Filler Option --%>
                                                                <asp:Label ID="lbl300DefaultFiller" runat="server" Text="Default Filler: "></asp:Label>
                                                                <asp:TextBox ID="txt300DefaultFiller" runat="server" CssClass="txtLengthInput"></asp:TextBox>
                                                                <asp:DropDownList ID="ddl300DefaultFiller" runat="server"></asp:DropDownList>
                                                            </li>                                                            
                                                            <li>
                                                                <%-- Markup --%>
                                                                <asp:Label ID="lbl300Markup" runat="server" Text="Markup:"></asp:Label>
                                                                <asp:TextBox ID="txt300Markup" runat="server"></asp:TextBox>
                                                            </li> 
                                                            <li>
                                                                <%-- Wall Colours --%>
                                                                <asp:RadioButton ID="rad300WallColours" GroupName="sunroomModel300" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl300WallColoursRadio" AssociatedControlID="rad300WallColours" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl300WallColours" AssociatedControlID="rad300WallColours" runat="server" Text="Wall Colours"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Frame Colour --%>
                                                                                    <asp:Label ID="lbl300FrameColour" runat="server" Text="Frame Colour:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300FrameColour" runat="server" OnChange="preferencesCasecadeColours(300)"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Interior Panel Colour --%>
                                                                                    <asp:Label ID="lbl300InteriorPanelColour" runat="server" Text="Interior Panel Colour:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300InteriorPanelColour" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Interior Panel Skin --%>
                                                                                    <asp:Label ID="lbl300InteriorPanelSkin" runat="server" Text="Interior Panel Skin:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300InteriorPanelSkin" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Exterior Panel Colour --%>
                                                                                    <asp:Label ID="lbl300ExteriorPanelColour" runat="server" Text="Exterior Panel Colour:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300ExteriorPanelColour" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Exterior Panel Skin --%>
                                                                                    <asp:Label ID="lbl300ExteriorPanelSkin" runat="server" Text="Exterior Panel Skin:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300ExteriorPanelSkin" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Door options --%>
                                                                <asp:RadioButton ID="rad300DoorOptions" GroupName="sunroomModel300" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl300DoorOptionsRadio" AssociatedControlID="rad300DoorOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl300DoorOptions" AssociatedControlID="rad300DoorOptions" runat="server" Text="Door Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Door Type --%>
                                                                                    <asp:Label ID="lbl300DoorType" runat="server" Text="Door Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300DoorType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Style --%>
                                                                                    <asp:Label ID="lbl300DoorStyle" runat="server" Text="Door Style:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300DoorStyle" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Swing --%>
                                                                                    <asp:Label ID="lbl300DoorSwing" runat="server" Text="Door Swing:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300DoorSwing" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Hinge --%>
                                                                                    <asp:Label ID="lbl300DoorHinge" runat="server" Text="Door Hinge:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300DoorHinge" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Hardware --%>
                                                                                    <asp:Label ID="lbl300DoorHardware" runat="server" Text="Door Hardware:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300DoorHardware" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Colour --%>
                                                                                    <asp:Label ID="lbl300DoorColour" runat="server" Text="Door Colour:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300DoorColour" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Glass Tint --%>
                                                                                    <asp:Label ID="lbl300DoorGlassTint" runat="server" Text="Door Glass Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300DoorGlassTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Vinyl Tint --%>
                                                                                    <asp:Label ID="lbl300DoorVinylTint" runat="server" Text="Door Vinyl Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300DoorVinylTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Screen Type --%>
                                                                                    <asp:Label ID="lbl300DoorScreenType" runat="server" Text="Door Screen Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300DoorScreenType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Window options --%>
                                                                <asp:RadioButton ID="rad300WindowOptions" GroupName="sunroomModel300" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl300WindowOptionsRadio" AssociatedControlID="rad300WindowOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl300WindowOptions" AssociatedControlID="rad300WindowOptions" runat="server" Text="Window Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Window Type --%>
                                                                                    <asp:Label ID="lbl300WindowType" runat="server" Text="Window Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300WindowType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Window Colour --%>
                                                                                    <asp:Label ID="lbl300WindowColour" runat="server" Text="Window Colour:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300WindowColour" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Window Glass Tint --%>
                                                                                    <asp:Label ID="lbl300WindowGlassTint" runat="server" Text="Window Glass Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300WindowGlassTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Window Vinyl Tint --%>
                                                                                    <asp:Label ID="lbl300WindowVinylTint" runat="server" Text="Window Vinyl Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300WindowVinylTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Window Screen Type --%>
                                                                                    <asp:Label ID="lbl300WindowScreenType" runat="server" Text="Window Screen Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300WindowScreenType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Sunshade options --%>
                                                                <asp:RadioButton ID="rad300SunshadeOptions" GroupName="sunroomModel300" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl300SunshadeOptionsRadio" AssociatedControlID="rad300SunshadeOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl300SunshadeOptions" AssociatedControlID="rad300SunshadeOptions" runat="server" Text="Sunshade Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Sunshade Valance Colour --%>
                                                                                    <asp:Label ID="lbl300SunshadeValanceColour" runat="server" Text="Sunshade Valance Colour:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300SunshadeValanceColour" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Sunshade Fabric --%>
                                                                                    <asp:Label ID="lbl300SunshadeFabricColour" runat="server" Text="Sunshade Fabric:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300SunshadeFabricColour" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Sunshade Openness --%>
                                                                                    <asp:Label ID="lbl300SunshadeOpenness" runat="server" Text="Sunshade Openness:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300SunshadeOpenness" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Roof options --%>
                                                                <asp:RadioButton ID="rad300RoofOptions" GroupName="sunroomModel300" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl300RoofOptionsRadio" AssociatedControlID="rad300RoofOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl300RoofOptions" AssociatedControlID="rad300RoofOptions" runat="server" Text="Roof Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Roof Type --%>
                                                                                    <asp:Label ID="lbl300RoofType" runat="server" Text="Roof Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300RoofType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Interior Skin --%>
                                                                                    <asp:Label ID="lbl300RoofInteriorSkin" runat="server" Text="Roof Interior Skin:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300RoofInteriorSkin" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Exterior Skin --%>
                                                                                    <asp:Label ID="lbl300RoofExteriorSkin" runat="server" Text="Roof Exterior Skin:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300RoofExteriorSkin" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Thickness --%>
                                                                                    <asp:Label ID="lbl300RoofThickness" runat="server" Text="Roof Thickness:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300RoofThickness" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Floor options --%>
                                                                <asp:RadioButton ID="rad300FloorOptions" GroupName="sunroomModel300" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl300FloorOptionsRadio" AssociatedControlID="rad300FloorOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl300FloorOptions" AssociatedControlID="rad300FloorOptions" runat="server" Text="Floor Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Thickness --%>
                                                                                    <asp:Label ID="lbl300FloorThickness" runat="server" Text="Floor Thickness:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300FloorThickness" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>                                                                                    
                                                                                    <%-- Metal Barrier --%>
                                                                                    <asp:CheckBox ID="chk300FloorMetalBarrier" runat="server" />
                                                                                    <asp:Label ID="lbl300FloorMetalBarrierCheck" AssociatedControlID="chk300FloorMetalBarrier" runat="server" ></asp:Label>
                                                                                    <asp:Label ID="lbl300FloorMetalBarrier" AssociatedControlID="chk300FloorMetalBarrier" runat="server" Text="Floor Metal Barrier:"></asp:Label>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Kneewall options --%>
                                                                <asp:RadioButton ID="rad300KneewallOptions" GroupName="sunroomModel300" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl300KneewallOptionsRadio" AssociatedControlID="rad300KneewallOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl300KneewallOptions" AssociatedControlID="rad300KneewallOptions" runat="server" Text="Kneewall Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Height --%>
                                                                                    <asp:Label ID="lbl300KneewallHeight" runat="server" Text="Kneewall Height:"></asp:Label>
                                                                                    <asp:TextBox ID="txt300KneewallHeight" runat="server"></asp:TextBox>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Type --%>
                                                                                    <asp:Label ID="lbl300KneewallType" runat="server" Text="Kneewall Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300KneewallType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Glass Tint --%>
                                                                                    <asp:Label ID="lbl300KneewallGlassTint" runat="server" Text="Kneewall Glass Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300KneewallGlassTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Transom options --%>
                                                                <asp:RadioButton ID="rad300TransomOptions" GroupName="sunroomModel300" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl300TransomOptionsRadio" AssociatedControlID="rad300TransomOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl300TransomOptions" AssociatedControlID="rad300TransomOptions" runat="server" Text="Transom Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Height --%>
                                                                                    <asp:Label ID="lbl300TransomHeight" runat="server" Text="Transom Height:"></asp:Label>
                                                                                    <asp:TextBox ID="txt300TransomHeight" runat="server"></asp:TextBox>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- style --%>
                                                                                    <asp:Label ID="lbl300TransomType" runat="server" Text="Transom Style:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300TransomType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- glass tint --%>
                                                                                    <asp:Label ID="lbl300TransomGlassTint" runat="server" Text="Transom Glass Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300TransomGlassTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- vinyl tint --%>
                                                                                    <asp:Label ID="lbl300TransomVinylTint" runat="server" Text="Transom Vinyl Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300TransomVinylTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- screen type --%>
                                                                                    <asp:Label ID="lbl300TransomScreenType" runat="server" Text="Transom Screen Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300TransomScreenType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                        </ul>
                                                        

                                                        <%--InteriorSkin
	                                                    ExteriorSkin
	                                                    DoorType/DoorSubtype/DoorOptions
	                                                    WindowType/WindowOptions
	                                                    PresetLayout
	                                                    InstallType
	                                                    Sunshades/SunshadeOptions
	                                                    RoofType/RoofOptions
	                                                    FloorType/FloorOptions
	                                                    KneewallOptions
	                                                    TransomOptions
	                                                    CutPitch
	                                                    DefaultFiller--%>
                                                    </li>                                            
                                                </ul>
                                            </div>
                                        </li>


                                        <%-- Model 400 Preferences --%>
                                        <li>
                                            <asp:RadioButton ID="radSunroom400" GroupName="sunroomModels" runat="server" />
                                            <asp:Label ID="lblSunroom400Radio" AssociatedControlID="radSunroom400" runat="server"></asp:Label>
                                            <asp:Label ID="lblSunroom400" AssociatedControlID="radSunroom400" runat="server" Text="Model 400"></asp:Label>

                                            
                                            <%-- Model 400 Inputs --%>
                                            <div class="toggleContent">
                                                <ul>
                                                    <li>
                                                        <ul class="toggleOptions">
                                                            <li>
                                                                <%-- Default Filler Option --%>
                                                                <asp:Label ID="lbl400DefaultFiller" runat="server" Text="Default Filler: "></asp:Label>
                                                                <asp:TextBox ID="txt400DefaultFiller" runat="server" CssClass="txtLengthInput"></asp:TextBox>
                                                                <asp:DropDownList ID="ddl400DefaultFiller" runat="server"></asp:DropDownList>
                                                            </li>                                                            
                                                            <li>
                                                                <%-- Markup --%>
                                                                <asp:Label ID="lbl400Markup" runat="server" Text="Markup:"></asp:Label>
                                                                <asp:TextBox ID="txt400Markup" runat="server"></asp:TextBox>
                                                            </li> 
                                                            <li>
                                                                <%-- Wall Colours --%>
                                                                <asp:RadioButton ID="rad400WallColours" GroupName="sunroomModel400" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl400WallColoursRadio" AssociatedControlID="rad400WallColours" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl400WallColours" AssociatedControlID="rad400WallColours" runat="server" Text="Wall Colours"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Frame Colour --%>
                                                                                    <asp:Label ID="lbl400FrameColour" runat="server" Text="Frame Colour:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400FrameColour" runat="server" OnChange="preferencesCascadeColours(400)"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Interior Panel Colour --%>
                                                                                    <asp:Label ID="lbl400InteriorPanelColour" runat="server" Text="Interior Panel Colour:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400InteriorPanelColour" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Interior Panel Skin --%>
                                                                                    <asp:Label ID="lbl400InteriorPanelSkin" runat="server" Text="Interior Panel Skin:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400InteriorPanelSkin" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Exterior Panel Colour --%>
                                                                                    <asp:Label ID="lbl400ExteriorPanelColour" runat="server" Text="Exterior Panel Colour:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400ExteriorPanelColour" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Exterior Panel Skin --%>
                                                                                    <asp:Label ID="lbl400ExteriorPanelSkin" runat="server" Text="Exterior Panel Skin:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400ExteriorPanelSkin" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Door options --%>
                                                                <asp:RadioButton ID="rad400DoorOptions" GroupName="sunroomModel400" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl400DoorOptionsRadio" AssociatedControlID="rad400DoorOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl400DoorOptions" AssociatedControlID="rad400DoorOptions" runat="server" Text="Door Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Door Type --%>
                                                                                    <asp:Label ID="lbl400DoorType" runat="server" Text="Door Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400DoorType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Style --%>
                                                                                    <asp:Label ID="lbl400DoorStyle" runat="server" Text="Door Style:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400DoorStyle" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Swing --%>
                                                                                    <asp:Label ID="lbl400DoorSwing" runat="server" Text="Door Swing:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400DoorSwing" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Hinge --%>
                                                                                    <asp:Label ID="lbl400DoorHinge" runat="server" Text="Door Hinge:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400DoorHinge" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Hardware --%>
                                                                                    <asp:Label ID="lbl400DoorHardware" runat="server" Text="Door Hardware:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400DoorHardware" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Colour --%>
                                                                                    <asp:Label ID="lbl400DoorColour" runat="server" Text="Door Colour:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400DoorColour" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Glass Tint --%>
                                                                                    <asp:Label ID="lbl400DoorGlassTint" runat="server" Text="Door Glass Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400DoorGlassTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Vinyl Tint --%>
                                                                                    <asp:Label ID="lbl400DoorVinylTint" runat="server" Text="Door Vinyl Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400DoorVinylTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Screen Type --%>
                                                                                    <asp:Label ID="lbl400DoorScreenType" runat="server" Text="Door Screen Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400DoorScreenType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Window options --%>
                                                                <asp:RadioButton ID="rad400WindowOptions" GroupName="sunroomModel400" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl400WindowOptionsRadio" AssociatedControlID="rad400WindowOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl400WindowOptions" AssociatedControlID="rad400WindowOptions" runat="server" Text="Window Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Window Type --%>
                                                                                    <asp:Label ID="lbl400WindowType" runat="server" Text="Window Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400WindowType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Window Colour --%>
                                                                                    <asp:Label ID="lbl400WindowColour" runat="server" Text="Window Colour:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400WindowColour" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Window Glass Tint --%>
                                                                                    <asp:Label ID="lbl400WindowGlassTint" runat="server" Text="Window Glass Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400WindowGlassTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Window Vinyl Tint --%>
                                                                                    <asp:Label ID="lbl400WindowVinylTint" runat="server" Text="Window Vinyl Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400WindowVinylTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Window Screen Type --%>
                                                                                    <asp:Label ID="lbl400WindowScreenType" runat="server" Text="Window Screen Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400WindowScreenType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Sunshade options --%>
                                                                <asp:RadioButton ID="rad400SunshadeOptions" GroupName="sunroomModel400" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl400SunshadeOptionsRadio" AssociatedControlID="rad400SunshadeOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl400SunshadeOptions" AssociatedControlID="rad400SunshadeOptions" runat="server" Text="Sunshade Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Sunshade Valance Colour --%>
                                                                                    <asp:Label ID="lbl400SunshadeValanceColour" runat="server" Text="Sunshade Valance Colour:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400SunshadeValanceColour" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Sunshade Fabric --%>
                                                                                    <asp:Label ID="lbl400SunshadeFabricColour" runat="server" Text="Sunshade Fabric:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400SunshadeFabricColour" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Sunshade Openness --%>
                                                                                    <asp:Label ID="lbl400SunshadeOpenness" runat="server" Text="Sunshade Openness:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400SunshadeOpenness" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Roof options --%>
                                                                <asp:RadioButton ID="rad400RoofOptions" GroupName="sunroomModel400" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl400RoofOptionsRadio" AssociatedControlID="rad400RoofOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl400RoofOptions" AssociatedControlID="rad400RoofOptions" runat="server" Text="Roof Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Roof Type --%>
                                                                                    <asp:Label ID="lbl400RoofType" runat="server" Text="Roof Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400RoofType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Interior Skin --%>
                                                                                    <asp:Label ID="lbl400RoofInteriorSkin" runat="server" Text="Roof Interior Skin:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400RoofInteriorSkin" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Exterior Skin --%>
                                                                                    <asp:Label ID="lbl400RoofExteriorSkin" runat="server" Text="Roof Exterior Skin:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400RoofExteriorSkin" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Thickness --%>
                                                                                    <asp:Label ID="lbl400RoofThickness" runat="server" Text="Roof Thickness:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400RoofThickness" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Floor options --%>
                                                                <asp:RadioButton ID="rad400FloorOptions" GroupName="sunroomModel400" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl400FloorOptionsRadio" AssociatedControlID="rad400FloorOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl400FloorOptions" AssociatedControlID="rad400FloorOptions" runat="server" Text="Floor Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Thickness --%>
                                                                                    <asp:Label ID="lbl400FloorThickness" runat="server" Text="Floor Thickness:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400FloorThickness" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>                                                                                    
                                                                                    <%-- Metal Barrier --%>
                                                                                    <asp:CheckBox ID="chk400FloorMetalBarrier" runat="server" />
                                                                                    <asp:Label ID="lbl400FloorMetalBarrierCheck" AssociatedControlID="chk400FloorMetalBarrier" runat="server" ></asp:Label>
                                                                                    <asp:Label ID="lbl400FloorMetalBarrier" AssociatedControlID="chk400FloorMetalBarrier" runat="server" Text="Floor Metal Barrier:"></asp:Label>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Kneewall options --%>
                                                                <asp:RadioButton ID="rad400KneewallOptions" GroupName="sunroomModel400" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl400KneewallOptionsRadio" AssociatedControlID="rad400KneewallOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl400KneewallOptions" AssociatedControlID="rad400KneewallOptions" runat="server" Text="Kneewall Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Height --%>
                                                                                    <asp:Label ID="lbl400KneewallHeight" runat="server" Text="Kneewall Height:"></asp:Label>
                                                                                    <asp:TextBox ID="txt400KneewallHeight" runat="server"></asp:TextBox>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Type --%>
                                                                                    <asp:Label ID="lbl400KneewallType" runat="server" Text="Kneewall Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400KneewallType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Glass Tint --%>
                                                                                    <asp:Label ID="lbl400KneewallGlassTint" runat="server" Text="Kneewall Glass Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400KneewallGlassTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Transom options --%>
                                                                <asp:RadioButton ID="rad400TransomOptions" GroupName="sunroomModel400" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl400TransomOptionsRadio" AssociatedControlID="rad400TransomOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl400TransomOptions" AssociatedControlID="rad400TransomOptions" runat="server" Text="Transom Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Height --%>
                                                                                    <asp:Label ID="lbl400TransomHeight" runat="server" Text="Transom Height:"></asp:Label>
                                                                                    <asp:TextBox ID="txt400TransomHeight" runat="server"></asp:TextBox>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- style --%>
                                                                                    <asp:Label ID="lbl400TransomType" runat="server" Text="Transom Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400TransomType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- glass tint --%>
                                                                                    <asp:Label ID="lbl400TransomGlassTint" runat="server" Text="Transom Glass Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400TransomGlassTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- vinyl tint --%>
                                                                                    <asp:Label ID="lbl400TransomVinylTint" runat="server" Text="Transom Vinyl Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400TransomVinylTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- screen type --%>
                                                                                    <asp:Label ID="lbl400TransomScreenType" runat="server" Text="Transom Screen Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400TransomScreenType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                        </ul>
                                                        

                                                        <%--InteriorSkin
	                                                    ExteriorSkin
	                                                    DoorType/DoorSubtype/DoorOptions
	                                                    WindowType/WindowOptions
	                                                    PresetLayout
	                                                    InstallType
	                                                    Sunshades/SunshadeOptions
	                                                    RoofType/RoofOptions
	                                                    FloorType/FloorOptions
	                                                    KneewallOptions
	                                                    TransomOptions
	                                                    CutPitch
	                                                    DefaultFiller--%>
                                                    </li>                                            
                                                </ul>
                                            </div>
                                        </li>
                                    </ul>
                                </li>
                            </ul>
                        </div>
                    </li>

                    <%-- Company Details --%>
                    <li>
                        <asp:RadioButton ID="radCompanyDetails" GroupName="preferences" runat="server" />
                        <asp:Label ID="lblCompanyDetailsRadio" AssociatedControlID="radCompanyDetails" runat="server"></asp:Label>
                        <asp:Label ID="lblCompanyDetails" AssociatedControlID="radCompanyDetails" runat="server" Text="Company Details"></asp:Label>

                        <div class="toggleContent">
                            <ul>
                                <li>                                        
                                    <asp:Label ID="lblCompanyNameInput" runat="server" Text="Company Name Input: "></asp:Label>
                                    <asp:TextBox ID="txtCompanyNameInput" CssClass="txtField txtInput" runat="server"></asp:TextBox>
                                </li>
                            </ul>
                        </div>
                    </li>


                    <%-- Price Calculator Preferences --%>
                    <li>
                        <asp:RadioButton ID="radPriceCalc" GroupName="preferences" runat="server" />
                        <asp:Label ID="lblPriceCalcRadio" AssociatedControlID="radPriceCalc" runat="server"></asp:Label>
                        <asp:Label ID="lblPriceCalc" AssociatedControlID="radPriceCalc" runat="server" Text="Price Calculator Preferences"></asp:Label>
                    </li>


                    <%-- Shipping Address --%>
                    <li>
                        <asp:RadioButton ID="radShippingAddress" GroupName="preferences" runat="server" />
                        <asp:Label ID="lblShippingAddressRadio" AssociatedControlID="radShippingAddress" runat="server"></asp:Label>
                        <asp:Label ID="lblShippingAddress" AssociatedControlID="radShippingAddress" runat="server" Text="Shipping Address"></asp:Label>
                    </li>


                    <%-- Billing Address --%>
                    <li>
                        <asp:RadioButton ID="radBillingAddress" GroupName="preferences" runat="server" />
                        <asp:Label ID="lblBillingAddressRadio" AssociatedControlID="radBillingAddress" runat="server"></asp:Label>
                        <asp:Label ID="lblBillingAddress" AssociatedControlID="radBillingAddress" runat="server" Text="Billing Address"></asp:Label>
                    </li>


                    <%-- Invoice Data --%>
                    <li>
                        <asp:RadioButton ID="radInvoiceData" GroupName="preferences" runat="server" />
                        <asp:Label ID="lblInvoiceDataRadio" AssociatedControlID="radInvoiceData" runat="server"></asp:Label>
                        <asp:Label ID="lblInvoiceData" AssociatedControlID="radInvoiceData" runat="server" Text="Invoice Data (Sunspace CSR Only)"></asp:Label>
                    </li>
                </ul>
                
                <asp:Button ID="btnUpdate" runat="server" Text="Update Preferences" CssClass="btnSubmit float-right" OnClick="btnUpdate_Click"/>
                <asp:SqlDataSource ID="sdsUsers" runat="server" ConnectionString="<%$ ConnectionStrings:sunspaceDealerDesktopConnectionString %>" SelectCommand="SELECT * FROM [users]"></asp:SqlDataSource>

            </div> <%-- end #slide1 --%>

        </div> <%-- end .slide-wrapper --%>
        
    </div> <%-- end .slide-window --%>
    <%-- Hidden input tags 
    ======================= --%>
    <asp:Repeater ID="rptHiddens" runat="server" >
        <ItemTemplate>            
            <input id="hidInstallationType" type="hidden" runat="server" />
            <input id="hidModelType" type="hidden" runat="server" />
            <input id="hidLayout" type="hidden" runat="server" />
            <input id="hidMarkup" type="hidden" runat="server" />

            <input id="hidWallInteriorPanelColour" type="hidden" runat="server" />
            <input id="hidWallInteriorPanelSkin" type="hidden" runat="server" />
            <input id="hidWallExteriorPanelColour" type="hidden" runat="server" />
            <input id="hidWallExteriorPanelSkin" type="hidden" runat="server" />
            <input id="hidWallFrameColour" type="hidden" runat="server" />

            <input id="hidDoorType" type="hidden" runat="server" />
            <input id="hidDoorStyle" type="hidden" runat="server" />
            <input id="hidDoorSwing" type="hidden" runat="server" />
            <input id="hidDoorHinge" type="hidden" runat="server" />
            <input id="hidDoorHardware" type="hidden" runat="server" />
            <input id="hidDoorColour" type="hidden" runat="server" />
            <input id="hidDoorGlassTint" type="hidden" runat="server" />
            <input id="hidDoorVinylTint" type="hidden" runat="server" />
            <input id="hidDoorScreenType" type="hidden" runat="server" />
   
            <input id="hidWindowType" type="hidden" runat="server" />       
            <input id="hidWindowColour" type="hidden" runat="server" />
            <input id="hidWindowGlassTint" type="hidden" runat="server" />
            <input id="hidWindowVinylTint" type="hidden" runat="server" />
            <input id="hidWindowScreenType" type="hidden" runat="server" />
    
            <input id="hidSunshadeValanceColour" type="hidden" runat="server" />
            <input id="hidSunshadeFabric" type="hidden" runat="server" />
            <input id="hidSunshadeOpenness" type="hidden" runat="server" />
    
            <input id="hidRoofType" type="hidden" runat="server" />
            <input id="hidRoofInteriorSkin" type="hidden" runat="server" />
            <input id="hidRoofExteriorSkin" type="hidden" runat="server" />
            <input id="hidRoofThickness" type="hidden" runat="server" />
    
            <input id="hidFloorInteriorSkin" type="hidden" runat="server" />
            <input id="hidFloorExteriorSkin" type="hidden" runat="server" />
            <input id="hidFloorThickness" type="hidden" runat="server" />
            <input id="hidFloorMetalBarrier" type="hidden" runat="server" />
    
            <input id="hidKneewallHeight" type="hidden" runat="server" />
            <input id="hidKneewallType" type="hidden" runat="server" />
            <input id="hidKneewallGlassTint" type="hidden" runat="server" />
    
            <input id="hidTransomHeight" type="hidden" runat="server" />
            <input id="hidTransomType" type="hidden" runat="server" />
            <input id="hidTransomGlassTint" type="hidden" runat="server" />
            <input id="hidTransomVinylTint" type="hidden" runat="server" />
            <input id="hidTransomScreenType" type="hidden" runat="server" />
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>

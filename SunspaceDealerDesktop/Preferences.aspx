<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Preferences.aspx.cs" Inherits="SunspaceDealerDesktop.Home" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div>
        <asp:Label Text ="Welcome " ID="lblWelcome" runat="server"></asp:Label>
        <asp:Label Text ="*Insert User Name*" ID="lblUser" runat="server"></asp:Label>
    </div>

    <div class="slide-window no-sidebar">

        <div class="slide-wrapper">

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
                                                        <asp:Label ID="lblModelType" runat="server" Text="Model Type:"></asp:Label>
                                                        <asp:DropDownList ID="ddlModelType" runat="server"></asp:DropDownList>
                                                    </li>
                                                    <li>
                                                        <%-- Layout --%>
                                                        <asp:Label ID="lblLayoutDefault" runat="server" Text="Layout Default:"></asp:Label>
                                                        <asp:DropDownList ID="ddlLayoutDefault" runat="server"></asp:DropDownList>
                                                    </li>
                                                    <li>
                                                        <%-- Markup --%>
                                                        <asp:Label ID="lblMarkup" runat="server" Text="Installation Type:"></asp:Label>
                                                        <asp:TextBox ID="txtMarkup" runat="server"></asp:TextBox>
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
                                                                <%-- Cut Pitch Option --%>
                                                                <asp:CheckBox ID="chk100Cut" runat="server" />
                                                                <asp:Label ID="lbl100CutCheck" AssociatedControlID="chk100Cut" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl100Cut" AssociatedControlID="chk100Cut" runat="server" Text="Cut Pitch"></asp:Label>                                                                
                                                            </li>
                                                            <li>
                                                                <%-- Default Filler Option --%>
                                                                <asp:Label ID="lbl100DefaultFiller" runat="server" Text="Default Filler: "></asp:Label>
                                                                <asp:TextBox ID="txt100DefaultFiller" runat="server" CssClass="txtLengthInput"></asp:TextBox>
                                                                <asp:DropDownList ID="ddl100DefaultFiller" runat="server"></asp:DropDownList>
                                                            </li>
                                                            <li>
                                                                <%-- Wall Colours --%>
                                                                <asp:RadioButton ID="radWallColours" GroupName="sunroomModel100" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lblWallColoursRadio" AssociatedControlID="radWallColours" runat="server"></asp:Label>
                                                                <asp:Label ID="lblWallColours" AssociatedControlID="radWallColours" runat="server" Text="Wall Colours"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Interior Panel Colour --%>
                                                                                    <asp:Label ID="lblInteriorPanelColour" runat="server" Text="Interior Panel Colour:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddlInteriorPanelColour" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Interior Panel Skin --%>
                                                                                    <asp:Label ID="lblInteriorPanelSkin" runat="server" Text="Interior Panel Skin:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddlInteriorPanelSkin" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Exterior Panel Colour --%>
                                                                                    <asp:Label ID="lblExteriorPanelColour" runat="server" Text="Exterior Panel Colour:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddlExteriorPanelColour" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Exterior Panel Skin --%>
                                                                                    <asp:Label ID="lblExteriorPanelSkin" runat="server" Text="Exterior Panel Skin:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddlExteriorPanelSkin" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Frame Colour --%>
                                                                                    <asp:Label ID="lblFrameColour" runat="server" Text="Frame Colour:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddlFrameColour" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Door options --%>
                                                                <asp:RadioButton ID="radDoorOptions" GroupName="sunroomModel100" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lblDoorOptionsRadio" AssociatedControlID="radDoorOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lblDoorOptions" AssociatedControlID="radDoorOptions" runat="server" Text="Door Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Door Type --%>
                                                                                    <asp:Label ID="lblDoorType" runat="server" Text="Door Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddlDoorType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Style --%>
                                                                                    <asp:Label ID="lblDoorStyle" runat="server" Text="Door Style:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddlDoorStyle" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Swing --%>
                                                                                    <asp:Label ID="lblDoorSwing" runat="server" Text="Door Swing:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddlDoorSwing" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Hinge --%>
                                                                                    <asp:Label ID="lblDoorHinge" runat="server" Text="Door Hinge:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddlDoorHinge" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Hardware --%>
                                                                                    <asp:Label ID="lblDoorHardware" runat="server" Text="Door Hardware:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddlDoorHardware" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Colour --%>
                                                                                    <asp:Label ID="lblDoorColour" runat="server" Text="Door Colour:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddlDoorColour" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Glass Tint --%>
                                                                                    <asp:Label ID="lblDoorGlassTint" runat="server" Text="Door Glass Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddlDoorGlassTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Vinyl Tint --%>
                                                                                    <asp:Label ID="lblDoorVinylTint" runat="server" Text="Door Vinyl Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddlDoorVinylTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Screen Tint --%>
                                                                                    <asp:Label ID="lblDoorScreenTint" runat="server" Text="Door Screen Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddlDoorScreenTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Window options --%>
                                                                <asp:RadioButton ID="radWindowOptions" GroupName="sunroomModel100" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lblWindowOptionsRadio" AssociatedControlID="radWindowOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lblWindowOptions" AssociatedControlID="radWindowOptions" runat="server" Text="Window Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Window Type --%>
                                                                                    <asp:Label ID="lblWindowType" runat="server" Text="Window Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddlWindowType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Window Colour --%>
                                                                                    <asp:Label ID="lblWindowColour" runat="server" Text="Window Colour:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddlWindowColour" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Window Glass Tint --%>
                                                                                    <asp:Label ID="lblWindowGlassTint" runat="server" Text="Window Glass Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddlWindowGlassTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Window Vinyl Tint --%>
                                                                                    <asp:Label ID="lblWindowVinylTint" runat="server" Text="Window Vinyl Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddlWindowVinylTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Window Screen Type --%>
                                                                                    <asp:Label ID="lblWindowScreenType" runat="server" Text="Window Screen Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddlWindowScreenType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Sunshade options --%>
                                                                <asp:RadioButton ID="radSunshadeOptions" GroupName="sunroomModel100" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lblSunshadeOptionsRadio" AssociatedControlID="radSunshadeOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lblSunshadeOptions" AssociatedControlID="radSunshadeOptions" runat="server" Text="Sunshade Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Sunshade Valance Colour --%>
                                                                                    <asp:Label ID="lblSunshadeValanceColour" runat="server" Text="Sunshade Valance Colour:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddlSunshadeValanceColour" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Sunshade Fabric --%>
                                                                                    <asp:Label ID="lblSunshadeFabric" runat="server" Text="Sunshade Fabric:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddlSunshadeFabic" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Sunshade Openness --%>
                                                                                    <asp:Label ID="lblSunshadeOpenness" runat="server" Text="Sunshade Openness:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddlSunshadeOpenness" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Roof options --%>
                                                                <asp:RadioButton ID="radRoofOptions" GroupName="sunroomModel100" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lblRoofOptionsRadio" AssociatedControlID="radRoofOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lblRoofOptions" AssociatedControlID="radRoofOptions" runat="server" Text="Roof Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Roof Type --%>
                                                                                    <asp:Label ID="lblRoofType" runat="server" Text="Roof Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddlRoofType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Interior Skin --%>
                                                                                    <asp:Label ID="lblRoofInteriorSkin" runat="server" Text="Roof Interior Skin:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddlRoofInteriorSkin" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Exterior Skin --%>
                                                                                    <asp:Label ID="lblRoofExteriorSkin" runat="server" Text="Roof Exterior Skin:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddlRoofExteriorSkin" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Thickness --%>
                                                                                    <asp:Label ID="lblRoofThickness" runat="server" Text="Roof Thickness:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddlRoofThickness" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Floor options --%>
                                                                <asp:RadioButton ID="radFloorOptions" GroupName="sunroomModel100" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lblFloorOptionsRadio" AssociatedControlID="radFloorOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lblFloorOptions" AssociatedControlID="radFloorOptions" runat="server" Text="Floor Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Interior skin --%>
                                                                                    <asp:Label ID="lblFloorInteriorSkin" runat="server" Text="Floor Interior Skin:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddlFloorInteriorSkin" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Exterior Skin --%>
                                                                                    <asp:Label ID="lblFloorExteriorSkin" runat="server" Text="Floor Exterior Skin:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddlFloorExteriorSkin" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Thickness --%>
                                                                                    <asp:Label ID="lblFloorThickness" runat="server" Text="Floor Thickness:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddlFloorThickness" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Metal Barrier --%>
                                                                                    <asp:Label ID="lblFloorMetalBarrier" runat="server" Text="Floor Metal Barrier:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddlFloorMetalBarrier" runat="server"></asp:DropDownList> <%--checkbox? --%>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Kneewall options --%>
                                                                <asp:RadioButton ID="radKneewallOptions" GroupName="sunroomModel100" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lblKneewallOptionsRadio" AssociatedControlID="radKneewallOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lblKneewallOptions" AssociatedControlID="radKneewallOptions" runat="server" Text="Kneewall Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Height --%>
                                                                                    <asp:Label ID="lblKneewallHeight" runat="server" Text="Kneewall Height:"></asp:Label>
                                                                                    <asp:TextBox ID="txtKneewallHeight" runat="server"></asp:TextBox>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Type --%>
                                                                                    <asp:Label ID="lblKneewallType" runat="server" Text="Kneewall Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddlKneewallType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Glass Tint --%>
                                                                                    <asp:Label ID="lblKneewallGlassTint" runat="server" Text="Kneewall Glass Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddlKneewallGlassTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Transom options --%>
                                                                <asp:RadioButton ID="radTransomOptions" GroupName="sunroomModel100" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lblTransomOptionsRadio" AssociatedControlID="radTransomOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lblTransomOptions" AssociatedControlID="radTransomOptions" runat="server" Text="Transom Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Height --%>
                                                                                    <asp:Label ID="lblTransomHeight" runat="server" Text="Transom Height:"></asp:Label>
                                                                                    <asp:TextBox ID="txtTransomHeight" runat="server"></asp:TextBox>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- style --%>
                                                                                    <asp:Label ID="lblTransomStyle" runat="server" Text="Transom Style:"></asp:Label>
                                                                                    <asp:DropDownList ID="DropDownList21" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- glass tint --%>
                                                                                    <asp:Label ID="lblTransomGlassTint" runat="server" Text="Transom Glass Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddlTransomGlassTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- vinyl tint --%>
                                                                                    <asp:Label ID="lblTransomVinylTint" runat="server" Text="Transom Vinyl Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddlTransomVinylTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- screen type --%>
                                                                                    <asp:Label ID="Label24" runat="server" Text="Frame Colour:"></asp:Label>
                                                                                    <asp:DropDownList ID="DropDownList24" runat="server"></asp:DropDownList>
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
                                                        <asp:Label ID="lbl200Input" runat="server" Text="Model 200 Input: "></asp:Label>
                                                        <asp:TextBox ID="txt200Input" CssClass="txtField txtInput" runat="server"></asp:TextBox>
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
                                                        <asp:Label ID="lbl300Input" runat="server" Text="Model 300 Input: "></asp:Label>
                                                        <asp:TextBox ID="txt300Input" CssClass="txtField txtInput" runat="server"></asp:TextBox>
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
                                                        <asp:Label ID="lbl400Input" runat="server" Text="Model 400 Input: "></asp:Label>
                                                        <asp:TextBox ID="txt400Input" CssClass="txtField txtInput" runat="server"></asp:TextBox>
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

            </div> <%-- end #slide1 --%>

        </div> <%-- end .slide-wrapper --%>
        
    </div> <%-- end .slide-window --%>
    <%-- Hidden input tags 
    ======================= --%>
    <asp:Repeater runat="server">
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
    </asp:Repeater>
</asp:Content>

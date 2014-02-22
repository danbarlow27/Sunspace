<%@ Page Title="Sunspace | Catalogue" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Display.aspx.cs" Inherits="SunspaceDealerDesktop.Display" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <link href="/content/Components.css" rel="stylesheet" type="text/css" />
    <asp:SqlDataSource ID="datSelectDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:sunspaceDealerDesktopConnectionString %>" SelectCommand="SELECT * FROM [acrylic_panels]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="datDisplayDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:sunspaceDealerDesktopConnectionString %>" SelectCommand="SELECT * FROM [acrylic_panels]"></asp:SqlDataSource>
    <br class="clear">
    
    <div class="containerDisplay">
        <div class="contentWrapper">
            <!-- SCROLLING ARROWS -->
            <asp:Button ID="imgPrevArrow" CssClass="prevArrow" runat="server" OnClick="imgPrevArrow_Click" CausesValidation="False" TabIndex="7" />
            <asp:Button ID="imgNextArrow" CssClass="nextArrow" runat="server" OnClick="imgNextArrow_Click" CausesValidation="False" TabIndex="8" />
            <!-- end scrolling arrows -->

            <!-- NAVIGATION -->
            <div class="containerNavigation">
                <asp:DropDownList ID="ddlCategory" CssClass="ddlField" runat="server" Height="27" Width="200" TabIndex="4" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                <asp:DropDownList ID="ddlPart" CssClass="ddlField" runat="server" Height="27" Width="270" TabIndex="5" OnSelectedIndexChanged="ddlPart_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>

                <asp:Button ID="btnMainMenu" CssClass="float-right" runat="server" Text="Main Menu" CausesValidation="False" Height="27px" Width="105px" TabIndex="6" OnClick="btnMainMenu_Click"/>
            </div> <!-- end containerNavigation -->

            <!-- IMAGE -->
            <div class="containerImage">
                <div class="imageBoxDisplay">
                    <asp:HyperLink ID="imgPartLink"  runat="server" Target="_blank">
                        <asp:Image ID="imgPart"  runat="server" />
                    </asp:HyperLink>

                    <%--<lbimage:LightBoxImage ID="LightBoxImage1" runat="server" />--%>                                       
                </div>
                
                <!-- label is only displayed for Schematic Diagrams -->
                <asp:Label ID="lblViewImgLarger" runat="server" Text="Click Image to View Larger" Width="400"></asp:Label>
            </div> <!-- end containerImage -->

            <!-- RECORD -->
            <div class="containerRecord">
                
                <!-- PRODUCT PANEL -->
                <asp:Table ID="pnlProduct" CssClass="pnlProductDisplay" runat="server">
                    <%-- NB. textbox controls are set to ReadOnly="True" (user-disabled); css removes default textbox styling --%>

                    <%-- Part Number --%>
                    <asp:TableRow ID="rowPartNumber">
                        <asp:TableCell CssClass="tdDisplayLabel">
                            <asp:Label ID="lblPartNum" CssClass="displayLabel" runat="server" Text="Part Number:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdDisplayField">
                            <asp:TextBox ID="txtPartNum" CssClass="displayField" runat="server" Height="25" Width="200" ReadOnly="True">Part Number</asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Part Name --%>
                    <asp:TableRow ID="rowPartName">
                        <asp:TableCell CssClass="tdDisplayLabel valign-top">
                            <asp:Label ID="lblPartName" CssClass="displayLabel" runat="server" Text="Part Name:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdDisplayField">
                            <asp:TextBox ID="txtPartName" CssClass="displayField" runat="server" Width="260" TextMode="MultiLine" ReadOnly="True">Part Name</asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Part Key --%>
                    <asp:TableRow ID="rowLegend">
                        <asp:TableCell CssClass="tdDisplayLabel">
                            <asp:Label ID="lblLegend" CssClass="displayLabel" runat="server" Text="Legend:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdDisplayField">
                            <asp:TextBox ID="txtLegend" CssClass="displayField" runat="server" Height="75" Width="260" TextMode="MultiLine" ReadOnly="True">Legend</asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Description --%>
                    <asp:TableRow ID="rowDescription">
                        <asp:TableCell CssClass="tdDisplayLabel valign-top">
                            <asp:Label ID="lblPartDesc" CssClass="displayLabel" runat="server" Text="Description:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdDisplayField">
                            <asp:TextBox ID="txtPartDesc" CssClass="displayField" runat="server" Width="260" TextMode="MultiLine"  ReadOnly="True">Description</asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Composition --%>
                    <asp:TableRow ID="rowComposition">
                        <asp:TableCell CssClass="tdDisplayLabel">
                            <asp:Label ID="lblComposition" CssClass="displayLabel" runat="server" Text="Composition:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdDisplayField">
                            <asp:TextBox ID="txtComposition" CssClass="displayField" runat="server" Height="25" Width="200" ReadOnly="True">Composition</asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Standard --%>
                    <asp:TableRow ID="rowStandard">
                        <asp:TableCell CssClass="tdDisplayLabel">
                            <asp:Label ID="lblStandard" CssClass="displayLabel" runat="server" Text="Standard:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdDisplayField">
                            <asp:TextBox ID="txtStandard" CssClass="displayField" runat="server" Height="25" Width="200" ReadOnly="True">Standard</asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Pack Quantity --%>
                    <asp:TableRow ID="rowPackQuantity">
                        <asp:TableCell CssClass="tdDisplayLabel">
                            <asp:Label ID="lblPackQuantity" CssClass="displayLabel" runat="server" Text="Pack Quantity:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdDisplayField">
                            <asp:TextBox ID="txtPackQuantity" CssClass="displayField" runat="server" Height="25" Width="200" ReadOnly="True">Pack Quantity</asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Color --%>
                    <asp:TableRow ID="rowColor">
                        <asp:TableCell CssClass="tdDisplayLabel">
                            <asp:Label ID="lblColor" CssClass="displayLabel" runat="server" Text="Color:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdDisplayField">
                            <asp:TextBox ID="txtColor" CssClass="displayField" runat="server" Height="25" Width="200" ReadOnly="True">Color</asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table> <!-- end pnlProduct -->

                <!-- SCHEMATICS PANEL -->
                <asp:Table ID="pnlSchematicsDisplay" CssClass="schematicsTableDisplay" runat="server">
                    <%-- Schematics Part Selection --%>
                    <asp:TableRow ID="rowSelectSchem">
                        <asp:TableCell CssClass="tdDisplayLabelSchem" ColumnSpan="2">
                            <asp:Label ID="lblSelectSchem" CssClass="displayLabel" runat="server" Text="Select Schematic Part:"></asp:Label> <br>
                            <asp:DropDownList ID="ddlSchem" CssClass="ddlField" runat="server" Height="32" Width="250" TabIndex="1" OnSelectedIndexChanged="ddlSchem_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Schematics Part Number --%>
                    <asp:TableRow ID="rowSchemPartNum">
                        <asp:TableCell CssClass="tdDisplayLabel">
                            <asp:Label ID="lblSchemPartNum" CssClass="displayLabel" runat="server" Text="Part Number:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdDisplayField">
                            <asp:TextBox ID="txtSchemPartNum" CssClass="displayField" runat="server" Height="25" Width="200" ReadOnly="True">Part Number</asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Schematics Part Key --%>
                    <asp:TableRow ID="rowSchemPartKey">
                        <asp:TableCell CssClass="tdDisplayLabel">
                            <asp:Label ID="lblSchemPartKey" CssClass="displayLabel" runat="server" Text="Part Key:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdDisplayField">
                            <asp:TextBox ID="txtSchemPartKey" CssClass="displayField" runat="server" Height="25" Width="200" ReadOnly="True">Part Key</asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Schematics Part Name --%>
                    <asp:TableRow ID="rowSchemPartName">
                        <asp:TableCell CssClass="tdDisplayLabel">
                            <asp:Label ID="lblSchemPartName" CssClass="displayLabel" runat="server" Text="Part Name:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdDisplayField">
                            <asp:TextBox ID="txtSchemPartName" CssClass="displayField" runat="server" Height="25" Width="200" ReadOnly="True">Part Name</asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table> <!-- end pnlSchematics -->

                <!-- ACCESSORIES PANEL -->
                <asp:Table ID="pnlAccessories" CssClass="dimensionsTableDisplay" runat="server">
                    <%-- Size --%>
                    <asp:TableRow ID="rowAccessorySize">
                        <asp:TableCell CssClass="tdDisplayLabel">
                            <asp:Label ID="lblAccessorySize" CssClass="displayLabel" runat="server" Text="Size:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdDisplayField">
                            <asp:TextBox ID="txtAccessorySize" CssClass="displayField" runat="server" Height="25" Width="200" ReadOnly="True">Size</asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Max Width --%>
                    <asp:TableRow ID="rowAccessoryMaxWidth">
                        <asp:TableCell CssClass="tdDisplayLabel">
                            <asp:Label ID="lblAccessoryWidth" CssClass="displayLabel" runat="server" Text="Max Width:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdDisplayField">
                            <asp:TextBox ID="txtAccessoryWidth" CssClass="displayField" runat="server" Height="25" Width="200" ReadOnly="True">Max Width</asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Max Length --%>
                    <asp:TableRow ID="rowAccessoryMaxLength">
                        <asp:TableCell CssClass="tdDisplayLabel">
                            <asp:Label ID="lblAccessoryLength" CssClass="displayLabel" runat="server" Text="Max Length:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdDisplayField">
                            <asp:TextBox ID="txtAccessoryLength" CssClass="displayField" runat="server" Height="25" Width="200" ReadOnly="True">Max Length</asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table> <!-- end pnlAccessories -->

                <!-- SCREEN ROLL PANEL -->
                <asp:Table ID="pnlScreenRoll" CssClass="dimensionsTableDisplay" runat="server">
                    <%-- Roll Width --%>
                    <asp:TableRow ID="rowScreenRollWidth">
                        <asp:TableCell CssClass="tdDisplayLabel">
                            <asp:Label ID="lblScreenRollWidth" CssClass="displayLabel" runat="server" Text="Roll Width:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdDisplayField">
                            <asp:TextBox ID="txtScreenRollWidth" CssClass="displayField" runat="server" Height="25" Width="200" ReadOnly="True">Roll Width</asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Roll Length --%>
                    <asp:TableRow ID="rowScreenLength">
                        <asp:TableCell CssClass="tdDisplayLabel">
                            <asp:Label ID="lblScreenRollLength" CssClass="displayLabel" runat="server" Text="Roll Length:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdDisplayField">
                            <asp:TextBox ID="txtScreenRollLength" CssClass="displayField" runat="server" Height="25" Width="200" ReadOnly="True">Roll Length</asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table> <!-- end pnlScreenRoll -->
               
                <!-- VINYL ROLL PANEL -->
                <asp:Table ID="pnlVinylRoll" CssClass="dimensionsTableDisplay" runat="server">
                    <%-- Roll Width --%>
                    <asp:TableRow ID="rowVinylRollWidth">
                        <asp:TableCell CssClass="tdDisplayLabel">
                            <asp:Label ID="lblVinylRollWidth" CssClass="displayLabel" runat="server" Text="Roll Width:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdDisplayField">
                            <asp:TextBox ID="txtVinylRollWidth" CssClass="displayField" runat="server" Height="25" Width="200" ReadOnly="True">Roll Width</asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Roll Length --%>
                    <asp:TableRow ID="rowVinylRollLength">
                        <asp:TableCell CssClass="tdDisplayLabel">
                            <asp:Label ID="lblVinylRollLength" CssClass="displayLabel" runat="server" Text="Roll Length:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdDisplayField">
                            <asp:TextBox ID="txtVinylRollLength" CssClass="displayField" runat="server" Height="25" Width="200" ReadOnly="True">Roll Length</asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Roll Weight --%>
                    <asp:TableRow ID="rowVinylRollWeight">
                        <asp:TableCell CssClass="tdDisplayLabel">
                            <asp:Label ID="lblVinylRollWeight" CssClass="displayLabel" runat="server" Text="Roll Weight:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdDisplayField">
                            <asp:TextBox ID="txtVinylRollWeight" CssClass="displayField" runat="server" Height="25" Width="200" ReadOnly="True">Roll Weight</asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table> <!-- end pnlVinylRoll -->

                <!-- ROOF PANELS PANEL -->
                <asp:Table ID="pnlRoofPanels" CssClass="dimensionsTableDisplay" runat="server">
                    <%-- Size --%>
                    <asp:TableRow ID="rowRoofPanelsSize">
                        <asp:TableCell CssClass="tdDisplayLabel">
                            <asp:Label ID="lblRoofPnlSize" CssClass="displayLabel" runat="server" Text="Size:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdDisplayField">
                            <asp:TextBox ID="txtRoofPnlSize" CssClass="displayField" runat="server" Height="25" Width="200" ReadOnly="True">Size</asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Max Width --%>
                    <asp:TableRow ID="rowRoofPanelsMaxWidth">
                        <asp:TableCell CssClass="tdDisplayLabel">
                            <asp:Label ID="lblRoofPnlMaxWidth" CssClass="displayLabel" runat="server" Text="Max Width:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdDisplayField">
                            <asp:TextBox ID="txtRoofPnlMaxWidth" CssClass="displayField" runat="server" Height="25" Width="200" ReadOnly="True">Max Width</asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Max Length --%>
                    <asp:TableRow ID="rowRoofPanelsMaxLength">
                        <asp:TableCell CssClass="tdDisplayLabel">
                            <asp:Label ID="lblRoofPnlMaxLength" CssClass="displayLabel" runat="server" Text="Max Length:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdDisplayField">
                            <asp:TextBox ID="txtRoofPnlMaxLength" CssClass="displayField" runat="server" Height="25" Width="200" ReadOnly="True">Max Length</asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table> <!-- end pnlRoofPanels -->
                
                <!-- ROOF EXTRUSIONS PANEL -->
                <asp:Table ID="pnlRoofExtrusions" CssClass="dimensionsTableDisplay" runat="server">
                    <%-- Size --%>
                    <asp:TableRow ID="rowRoofExtSize">
                        <asp:TableCell CssClass="tdDisplayLabel">
                            <asp:Label ID="lblRoofExtSize" CssClass="displayLabel" runat="server" Text="Size:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdDisplayField">
                            <asp:TextBox ID="txtRoofExtSize" CssClass="displayField" runat="server" Height="25" Width="200" ReadOnly="True">Size</asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Angle A --%>
                    <asp:TableRow ID="rowRoofExtAngleA">
                        <asp:TableCell CssClass="tdDisplayLabel">
                            <asp:Label ID="lblRoofExtAngleA" CssClass="displayLabel" runat="server" Text="Angle A:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdDisplayField">
                            <asp:TextBox ID="txtRoofExtAngleA" CssClass="displayField" runat="server" Height="25" Width="200" ReadOnly="True">Angle A</asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Angle B --%>
                    <asp:TableRow ID="rowRoofExtAngleB">
                        <asp:TableCell CssClass="tdDisplayLabel">
                            <asp:Label ID="lblRoofExtAngleB" CssClass="displayLabel" runat="server" Text="Angle B:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdDisplayField">
                            <asp:TextBox ID="txtRoofExtAngleB" CssClass="displayField" runat="server" Height="25" Width="200" ReadOnly="True">Angle B</asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    
                    <%-- Angle C --%>
                    <asp:TableRow ID="rowRoofExtAngleC">
                        <asp:TableCell CssClass="tdDisplayLabel">
                            <asp:Label ID="lblRoofExtAngleC" CssClass="displayLabel" runat="server" Text="Angle C:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdDisplayField">
                            <asp:TextBox ID="txtRoofExtAngleC" CssClass="displayField" runat="server" Height="25" Width="200" ReadOnly="True">Angle C</asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Max Length --%>
                    <asp:TableRow ID="rowRoofExtMaxLength">
                        <asp:TableCell CssClass="tdDisplayLabel">
                            <asp:Label ID="lblRoofExtMaxLength" CssClass="displayLabel" runat="server" Text="Max Length:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdDisplayField">
                            <asp:TextBox ID="txtRoofExtMaxLength" CssClass="displayField" runat="server" Height="25" Width="200" ReadOnly="True">Max Length</asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table> <!-- end pnlRoofExt -->

                <!-- DECORATIVE COLUMN PANEL -->
                <asp:Table ID="pnlDecorativeColumn" CssClass="dimensionsTableDisplay" runat="server">
                    <%-- Length --%>
                    <asp:TableRow ID="rowDecColLength">
                        <asp:TableCell CssClass="tdDisplayLabel">
                            <asp:Label ID="lblDecColLength" CssClass="displayLabel" runat="server" Text="Length:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdDisplayField">
                            <asp:TextBox ID="txtDecColLength" CssClass="displayField" runat="server" Height="25" Width="200" ReadOnly="True">Length</asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table> <!-- end pnlDecorativeColumns -->               
                <!-- WALL PANELS PANEL -->
                <asp:Table ID="pnlWallPanel" CssClass="dimensionsTableDisplay" runat="server">
                    <%-- Size --%>
                    <asp:TableRow ID="rowWallPanelSize">
                        <asp:TableCell CssClass="tdDisplayLabel">
                            <asp:Label ID="lblWallPnlSize" CssClass="displayLabel" runat="server" Text="Size:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdDisplayField">
                            <asp:TextBox ID="txtWallPnlSize" CssClass="displayField" runat="server" Height="25" Width="200" ReadOnly="True">Size</asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Max Width --%>
                    <asp:TableRow ID="rowWallPanelMaxWidth">
                        <asp:TableCell CssClass="tdDisplayLabel">
                            <asp:Label ID="lblWallPnlMaxWidth" CssClass="displayLabel" runat="server" Text="Max Width:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdDisplayField">
                            <asp:TextBox ID="txtWallPnlMaxWidth" CssClass="displayField" runat="server" Height="25" Width="200" ReadOnly="True">Max Width</asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Max Length --%>
                    <asp:TableRow ID="rowWallPanelsMaxLength">
                        <asp:TableCell CssClass="tdDisplayLabel">
                            <asp:Label ID="lblWallPnlMaxLength" CssClass="displayLabel" runat="server" Text="Max Length:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdDisplayField">
                            <asp:TextBox ID="txtWallPnlMaxLength" CssClass="displayField" runat="server" Height="25" Width="200" ReadOnly="True">Max Length</asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table> <!-- end pnlWallPanel -->

                <!-- WALL EXTRUSIONS PANEL -->
                <asp:Table ID="pnlWallExtrusions" CssClass="dimensionsTableDisplay" runat="server">
                    <%-- Size --%>
                    <asp:TableRow ID="rowWallExtSize">
                        <asp:TableCell CssClass="tdDisplayLabel">
                            <asp:Label ID="lblWallExtSize" CssClass="displayLabel" runat="server" Text="Size:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdDisplayField">
                            <asp:TextBox ID="txtWallExtSize" CssClass="displayField" runat="server" Height="25" Width="200" ReadOnly="True">Size</asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Max Width --%>
                    <asp:TableRow ID="pnlWallExtMaxWidth">
                        <asp:TableCell CssClass="tdDisplayLabel">
                            <asp:Label ID="lblWallExtMaxWidth" CssClass="displayLabel" runat="server" Text="Max Width:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdDisplayField">
                            <asp:TextBox ID="txtWallExtMaxWidth" CssClass="displayField" runat="server" Height="25" Width="200" ReadOnly="True">Max Width</asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Max Length --%>
                    <asp:TableRow ID="pnlWallExtMaxLength">
                        <asp:TableCell CssClass="tdDisplayLabel">
                            <asp:Label ID="lblWallExtMaxLength" CssClass="displayLabel" runat="server" Text="Max Length:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdDisplayField">
                            <asp:TextBox ID="txtWallExtMaxLength" CssClass="displayField" runat="server" Height="25" Width="200" ReadOnly="True">Max Length</asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table> <!-- end pnlWallExtrusions -->
                
                <!-- INSULATED FLOORS PANEL -->
                <asp:Table ID="pnlInsulatedFloors" CssClass="dimensionsTableDisplay" runat="server">
                    <%-- Size --%>
                    <asp:TableRow ID="rowInsFloorSize">
                        <asp:TableCell CssClass="tdDisplayLabel">
                            <asp:Label ID="lblInsFloorSize" CssClass="displayLabel" runat="server" Text="Size:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdDisplayField">
                            <asp:TextBox ID="txtInsFloorSize" CssClass="displayField" runat="server" Height="25" Width="200" ReadOnly="True">Size</asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Max Width --%>
                    <asp:TableRow ID="rowInsFloorMaxWidth">
                        <asp:TableCell CssClass="tdDisplayLabel">
                            <asp:Label ID="lblInsFloorMaxWidth" CssClass="displayLabel" runat="server" Text="Max Width:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdDisplayField">
                            <asp:TextBox ID="txtInsFloorMaxWidth" CssClass="displayField" runat="server" Height="25" Width="200" ReadOnly="True">Max Width</asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Max Length (string value) --%>
                    <asp:TableRow ID="rowInsFloorMaxLength">
                        <asp:TableCell CssClass="tdDisplayLabel">
                            <asp:Label ID="lblInsFloorMaxLength" CssClass="displayLabel" runat="server" Text="Max Length:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdDisplayField">
                            <asp:TextBox ID="txtInsFloorMaxLength" CssClass="displayField" runat="server" Height="25" Width="200" ReadOnly="True">Max Length (String)</asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                </asp:Table> <!-- end pnlInsulatedFloors -->
                
                <!-- SUNCRYLIC ROOF PANEL -->
                <asp:Table ID="pnlSuncrylicRoof" CssClass="dimensionsTableDisplay" runat="server">
                    <%-- Max Width (string) --%>
                    <asp:TableRow ID="rowSunRoofMaxWidthStr">
                        <asp:TableCell CssClass="tdDisplayLabel">
                            <asp:Label ID="lblSunRoofMaxWidthStr" CssClass="displayLabel" runat="server" Text="Max Width:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdDisplayField">
                            <asp:TextBox ID="txtSunRoofMaxWidthStr" CssClass="displayField" runat="server" Height="25" Width="200" ReadOnly="True">Max Width (String)</asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Max Length (string) --%>
                    <asp:TableRow ID="rowSunRoofMaxLengthStr">
                        <asp:TableCell CssClass="tdDisplayLabel">
                            <asp:Label ID="lblSunRoofMaxLengthStr" CssClass="displayLabel" runat="server" Text="Max Length:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdDisplayField">
                            <asp:TextBox ID="txtSunRoofMaxLengthStr" CssClass="displayField" runat="server" Height="25" Width="200" ReadOnly="True">Max Length (String)</asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Max Length (integer) --%>
                    <asp:TableRow ID="rowSunRoofMaxLength">
                        <asp:TableCell CssClass="tdDisplayLabel">
                            <asp:Label ID="lblSunRoofMaxLength" CssClass="displayLabel" runat="server" Text="Max Length:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdDisplayField">
                            <asp:TextBox ID="txtSunRoofMaxLength" CssClass="displayField" runat="server" Height="25" Width="200" ReadOnly="True">Max Length (Integer)</asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table> <!-- end pnlSuncrylicRoof -->
                
                <!-- SUNRAIL300 PANEL -->
                <asp:Table ID="pnlSunrail300" CssClass="dimensionsTableDisplay" runat="server">
                    <%-- Max Length Feet/Inches --%>
                    <asp:TableRow ID="rowSun300MaxLength">
                        <asp:TableCell CssClass="tdDisplayLabel">
                            <asp:Label ID="lblSun300MaxLength" CssClass="displayLabel" runat="server" Text="Max Length:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdDisplayField">
                            <asp:TextBox ID="txtSun300MaxLength" CssClass="displayField" runat="server" Height="25" Width="200" ReadOnly="True">Max Length Feet In</asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table> <!-- end pnlSunrail300 -->
                                              
                <!-- SUNRAIL400 PANEL -->
                <asp:Table ID="pnlSunrail400" CssClass="dimensionsTableDisplay" runat="server">
                    <%-- Max Length Feet/Inches --%>
                    <asp:TableRow ID="rowSun400MaxLength">
                        <asp:TableCell CssClass="tdDisplayLabel">
                            <asp:Label ID="lblSun400MaxLength" CssClass="displayLabel" runat="server" Text="Max Length:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdDisplayField">
                            <asp:TextBox ID="txtSun400MaxLength" CssClass="displayField" runat="server" Height="25" Width="200" ReadOnly="True">Max Length Ft In</asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table> <!-- end pnlSunrail400 -->
                
                <!-- SUNRAIL1000 PANEL -->
                <asp:Table ID="pnlSunrail1000" CssClass="dimensionsTableDisplay" runat="server">
                    <%-- Max Length Feet/Inches --%>
                    <asp:TableRow ID="rowSun1000MaxLength">
                        <asp:TableCell CssClass="tdDisplayLabel">
                            <asp:Label ID="lblSun1000MaxLength" CssClass="displayLabel" runat="server" Text="Max Length:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdDisplayField">
                            <asp:TextBox ID="txtSun1000MaxLength" CssClass="displayField" runat="server" Height="25" Width="200" ReadOnly="True">Max Length Ft In</asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table> <!-- end pnlSunrail1000 -->
                
                <!-- DOOR FRAME EXTRUSIONS PANEL -->
                <asp:Table ID="pnlDoorFrameExtrusions" CssClass="dimensionsTableDisplay" runat="server">
                    <%-- Max Length Feet/Inches (Inches accepts null) --%>
                    <asp:TableRow ID="rowDoorFrExtMaxLength">
                        <asp:TableCell CssClass="tdDisplayLabel">
                            <asp:Label ID="lbloorFrExtMaxLength" CssClass="displayLabel" runat="server" Text="Max Length:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdDisplayField">
                            <asp:TextBox ID="txtDoorFrExtMaxLength" CssClass="displayField" runat="server" Height="25" Width="200" ReadOnly="True">Max Length</asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table> <!-- end pnlDoorFrameExtrusions -->
                

                <!-- PRICING PANEL -->
                <asp:Table ID="pnlPriceDisplay" CssClass="priceTableDisplay" runat="server">
                    <%-- US Price --%>
                    <asp:TableRow ID="rowCadPrice" CssClass="dimensionsTableDisplay">
                        <asp:TableCell CssClass="tdDisplayLabel">
                            <asp:Label ID="lblUsdPrice" CssClass="displayLabel" runat="server" Text="US Price:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdDisplayField">
                            <asp:TextBox ID="txtUsdPrice" CssClass="displayField" runat="server" Height="25" Width="70" ReadOnly="True">1.00</asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    <%-- CAN Price --%>
                    <asp:TableRow ID="rowUsdPrice" CssClass="dimensionsTableDisplay">
                        <asp:TableCell CssClass="tdDisplayLabel">
                            <asp:Label ID="lblCadPrice" CssClass="displayLabel" runat="server" Text="Canada Price:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdDisplayField">
                            <asp:TextBox ID="txtCadPrice" CssClass="displayField" runat="server" Height="25" Width="70" ReadOnly="True">1.00</asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table> <!-- end pnlPriceDisplay -->

            </div> <!-- end containerRecord -->   
                     
            <!-- BUTTONS -->
            <div class="divButtonsDisplay">
                <asp:Panel ID="pnlButtonsDisplay" runat="server">
                    <asp:Button ID="btnUpdate" runat="server" Text="Edit Product" Height="30px" Width="140" TabIndex="2" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnInsert" runat="server" Text="Add Another Product" Height="30px" Width="140" TabIndex="3" OnClick="btnInsert_Click"  />
                    <asp:Button ID="btnShop" runat="server" Text="Add To Cart" Height="30px" Width="140" TabIndex="4" OnClick="btnShop_Click" />
                </asp:Panel> <!-- end pnlButtons -->
            </div> <!-- end .divButtonsDisplay -->
            <br class="clear">
        </div> <!-- end contentWrapper -->
    </div> <!-- end containerDisplay -->



    <script type="text/javascript">
        window.onload = function () {
            var setHeight = document.getElementById("MainContent_txtPartDesc");
            var setHeight2 = document.getElementById("MainContent_txtPartName");
            setHeight.style.height = setHeight.scrollHeight + "px";
            setHeight2.style.height = setHeight2.scrollHeight + "px";
        }
    </script>
</asp:Content>


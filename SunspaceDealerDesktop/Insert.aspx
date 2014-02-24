<%@ Page Title="Sunspace | Add Products to Catalogue" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Insert.aspx.cs" Inherits="SunspaceDealerDesktop.Insert" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <link href="/content/Components.css" rel="stylesheet" type="text/css" />
    <asp:SqlDataSource ID="datInsertDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:sunspaceDealerDesktopConnectionString %>" SelectCommand="SELECT * FROM [acrylic_panels]"></asp:SqlDataSource>
    <br class="clear">

    <!-- PRODUCT PANEL -->
    <asp:Panel ID="pnlProduct" runat="server" CssClass="pnlProduct">
        <div class="contentWrapper">

            <!-- NAVIGATION -->
            <div class="containerNavigation">
                <asp:DropDownList ID="ddlTables" CssClass="ddlField" runat="server" Height="27" Width="200" AutoPostBack="True" TabIndex="69" OnSelectedIndexChanged="ddlTables_SelectedIndexChanged">
                    
                </asp:DropDownList>

                <asp:Button ID="btnMainMenu" CssClass="float-right" runat="server" Text="Main Menu" CausesValidation="False" Height="27px" Width="105px"  TabIndex="70" OnClick="btnMainMenu_Click"/>
            </div> <!-- end containerNavigation -->

 
            <!-- Image -->
            <div class="containerUpdateImage">
                <div class="imageBoxUpdate">
                    <asp:Image ID="imgPart" runat="server" Height="250" ImageUrl="~/Images/catalogue/placeholder.jpg" />
                </div>
                <asp:FileUpload ID="fupNewImage" runat="server"  TabIndex="8"/> <br />
                <asp:Button ID="btnUploadImg" CssClass="btnUploadImg" runat="server" Text="Upload Image" Height="25" Width="125" TabIndex="9" OnClick="btnUploadImg_Click" CausesValidation="False"/>
                <asp:Label ID="valFupNewImage" runat="server" CssClass="errorMsg"></asp:Label>
             </div>

            <!-- Part Number, Name, Key (user-disabled) -->
            <div class="containerPartId">
                <asp:Label ID="valPartExists" CssClass="errorMsg" runat="server" Text =""></asp:Label> <br>
                <asp:Label ID="lblPartNum" CssClass="lblField" runat="server" Text="Part Number:"></asp:Label> <br>
                <asp:TextBox ID="txtPartNum" CssClass="txtInputFieldText" runat="server" Height="20" Width="410" TextMode="SingleLine" TabIndex="1"></asp:TextBox>
                <br>
                <asp:RequiredFieldValidator ID="rfvPartNum" CssClass="errorMsgProductPanel" runat="server" ControlToValidate="txtPartNum" ErrorMessage="Please enter a part number."  Display="Dynamic" ValidationGroup="productInfo"></asp:RequiredFieldValidator>
                <br>
                <asp:Label ID="lblPartName" CssClass="lblField" runat="server" Text="Part Name:"></asp:Label> <br>
                <asp:TextBox ID="txtPartName" CssClass="txtInputFieldText" runat="server" Height="20" Width="410" TextMode="SingleLine" TabIndex="2"></asp:TextBox>
                <br>
                 <asp:RequiredFieldValidator ID="rfvPartName" CssClass="errorMsgProductPanel" runat="server" ControlToValidate="txtPartName" ErrorMessage="Please enter a part name."  Display="Dynamic" ValidationGroup="productInfo"></asp:RequiredFieldValidator>
            </div>

            <!-- DESCRIPTION PANEL -->
            <asp:Panel ID="pnlDescription" runat="server">
                <!-- Description -->
                <div class="containerDesc">
                    <asp:Label ID="lblPartDesc" CssClass="lblField" runat="server" Text="Part Description:"></asp:Label> <br>
                    <asp:TextBox ID="txtPartDesc" CssClass="txtInputFieldText" runat="server" Height="70px" Width="410" TextMode="MultiLine" MaxLength="250" TabIndex="3"></asp:TextBox>
                    <br>
                    <asp:RequiredFieldValidator ID="rfvDescription" CssClass="errorMsgProductPanel" runat="server" ControlToValidate="txtPartDesc" ErrorMessage="Please enter a description."  Display="Dynamic" ValidationGroup="productInfo"></asp:RequiredFieldValidator>
                </div>
            </asp:Panel>

            <!-- COMPOSITION PANEL -->
            <asp:Panel ID="pnlComposition" runat="server">
                <!-- Composition -->
                <div class="containerComposition">
                    <asp:Label ID="lblComposition" CssClass="lblField" runat="server" Text="Composition:"></asp:Label> <br>
                    <asp:TextBox ID="txtComposition" CssClass="txtInputFieldText" runat="server" Height="20" Width="410" TextMode="SingleLine" TabIndex="4"></asp:TextBox>
                    <br>
                    <asp:RequiredFieldValidator ID="rfvComposition" CssClass="errorMsgProductPanel" runat="server" ControlToValidate="txtComposition" ErrorMessage="Please enter composition." Display="Dynamic" ValidationGroup="compstand"></asp:RequiredFieldValidator>
                </div>
            </asp:Panel> <!-- end pnlComposition -->

            <!-- STANDARD PANEL -->
            <asp:Panel ID="pnlStandard" runat="server">
                <!-- Standard -->
                <div class="containerStandard">
                    <asp:Label ID="lblStandard" CssClass="lblField" runat="server" Text="Standard:"></asp:Label> <br>
                    <asp:TextBox ID="txtStandard" CssClass="txtInputFieldText" runat="server" Height="20" Width="410" TextMode="SingleLine" TabIndex="5"></asp:TextBox>
                    <br>
                    <asp:RequiredFieldValidator ID="rfvStandard" CssClass="errorMsgProductPanel" runat="server" ControlToValidate="txtStandard" ErrorMessage="Please enter standard." Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </asp:Panel> <!-- end pnlStandard -->

            <!-- PACK QUANTITY -->
            <asp:Panel ID="pnlPackQuantity" runat="server">
                <!-- Pack Quantity -->
                <div class="containerAccessories">
                    <asp:Label ID="lblPackQuantity" CssClass="lblField" runat="server" Text="Pack Quantity:"></asp:Label> <br>
                    <asp:TextBox ID="txtPackQuantity" CssClass="txtInputFieldText" runat="server" Height="20" Width="100" TabIndex="6"></asp:TextBox>
                    <br>
                    <%--<asp:RequiredFieldValidator ID="rfvPackQuantity" CssClass="errorMsgProductPanel" runat="server" ControlToValidate="txtPackQuantity" ErrorMessage="Please enter pack quantity." Display="Dynamic"></asp:RequiredFieldValidator>--%>
                    <asp:RegularExpressionValidator ID="revPackQuantity" CssClass="errorMsgProductPanel" runat="server" ControlToValidate="txtPackQuantity" ErrorMessage="Please only enter numbers."  ValidationExpression="\d+" Display="Dynamic" ValidationGroup="accessories"></asp:RegularExpressionValidator>
                </div>
            </asp:Panel> <!-- end pnlAccProduct -->

            <!-- COLOR PANEL -->
            <asp:Panel ID="pnlColor" runat="server">
                <!-- Color -->
                <div class="containerColor">
                    <asp:Label ID="lblColor" CssClass="lblFieldColor" runat="server" Text="Color:"></asp:Label>
                    <asp:DropDownList ID="ddlColors" CssClass="ddlField" runat="server" Height="32" Width="200" TabIndex="7">
                    </asp:DropDownList>
                </div>
            </asp:Panel> <!-- end pnlColor -->

        </div> <!-- end contentWrapper -->
    </asp:Panel> <!-- end pnlProduct -->

    <!-- DIMENSIONS PANEL -->
    <asp:Panel ID="pnlDimensions" runat="server" CssClass="pnlDimensions">
        <div class="contentWrapper">
            <h2>Dimensions</h2>

                <!-- NB. first <asp:TableRow> in each table must have class="firstRow" for IE8 and less (tr:nth-child() is not supported) -->

                <!-- ACCESSORIES PANEL -->
                <asp:Table ID="pnlAccessories" CssClass="dimensionsTable" runat="server">
                    <%-- Size --%>
                    <asp:TableRow ID="rowAccessorySize" CssClass="firstRow">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblAccessorySize" CssClass="lblField" runat="server" Text="Size:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtAccessorySize" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="10" ></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled">
                            <asp:DropDownList ID="ddlAccessorySizeUnits" CssClass="ddlField" runat="server" Height="32" Width="200" AutoPostBack="True" OnSelectedIndexChanged="ddlTables_SelectedIndexChanged" TabIndex="11">
                                <asp:ListItem>Inches</asp:ListItem>
                                <asp:ListItem>Feet</asp:ListItem>
                            </asp:DropDownList>

                            <%-- Validation --%>
                            <asp:RegularExpressionValidator ID="revAccessorySize" CssClass="errorMsg" ValidationGroup="accessories" runat="server" ControlToValidate="txtAccessorySize" ErrorMessage="Please only enter numbers."  ValidationExpression="\d+" Display="Dynamic"></asp:RegularExpressionValidator>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Max Width --%>
                    <asp:TableRow ID="rowAccessoryMaxWidth">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblAccessoryWidth" CssClass="lblField" runat="server" Text="Width:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtAccessoryWidth" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="12" ></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled">
                            <asp:DropDownList ID="ddlAccessoryWidthUnits" CssClass="ddlField" runat="server" Height="32" Width="200" AutoPostBack="True" OnSelectedIndexChanged="ddlTables_SelectedIndexChanged" TabIndex="13">
                                <asp:ListItem>Inches</asp:ListItem>
                                <asp:ListItem>Feet</asp:ListItem>
                            </asp:DropDownList>

                            <%-- Validation --%>
                            <%--<asp:RequiredFieldValidator ID="rfvAccessoryWidth" CssClass="errorMsg" runat="server" ControlToValidate="txtRoofPnlMaxWidth" ErrorMessage="Please enter a max width." ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                            <asp:RegularExpressionValidator ID="revAccessoryWidth" CssClass="errorMsg" ValidationGroup="accessories" runat="server" ControlToValidate="txtAccessoryWidth" ErrorMessage="Please only enter numbers."  ValidationExpression="\d+" Display="Dynamic"></asp:RegularExpressionValidator>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Max Length --%>
                    <asp:TableRow ID="rowAccessoryMaxLength">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblAccessoryLength" CssClass="lblField" runat="server" Text="Length:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtAccessoryLength" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="14"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled">
                            <asp:DropDownList ID="ddlAccessoryLengthUnits" CssClass="ddlField" runat="server" Height="32" Width="200" AutoPostBack="True" OnSelectedIndexChanged="ddlTables_SelectedIndexChanged" TabIndex="15">
                                <asp:ListItem>Feet</asp:ListItem>
                                <asp:ListItem>Inches</asp:ListItem>
                            </asp:DropDownList>

                            <%-- Validation --%>
                            <%--<asp:RequiredFieldValidator ID="rfvAccessoryLength" CssClass="errorMsg" runat="server" ControlToValidate="txtAccessoryLength" ErrorMessage="Please enter a max length." ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                            <asp:RegularExpressionValidator ID="revAccesoryLength" CssClass="errorMsg" ValidationGroup="accessories" runat="server" ControlToValidate="txtAccessoryLength" ErrorMessage="Please only enter numbers."  ValidationExpression="\d+" Display="Dynamic"></asp:RegularExpressionValidator>
                        </asp:TableCell>
                    </asp:TableRow>

                </asp:Table> <!-- end pnlAccessories -->

                <!-- SCREEN ROLL PANEL -->
                <asp:Table ID="pnlScreenRoll" CssClass="dimensionsTable" runat="server">
                    <%-- Roll Width --%>
                    <asp:TableRow ID="rowScreenRollWidth" CssClass="firstRow">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblScreenRollWidth" CssClass="lblField" runat="server" Text="Roll Width:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtScreenRollWidth" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="16"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled">
                            <asp:DropDownList ID="ddlScreenRollWidthUnits" CssClass="ddlField" runat="server" Height="32" Width="200" TabIndex="17" AutoPostBack="True" OnSelectedIndexChanged="ddlTables_SelectedIndexChanged">
                                <asp:ListItem>Inches</asp:ListItem>
                                <asp:ListItem>Feet</asp:ListItem>
                            </asp:DropDownList>

                            <%-- Validation --%>
                            <asp:RequiredFieldValidator ID="rfvScreenRollWidth" CssClass="errorMsg" ValidationGroup="screenroll" runat="server" ControlToValidate="txtScreenRollWidth" ErrorMessage="Please enter a roll width." ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revScreenRollWidth" CssClass="errorMsg" ValidationGroup="screenroll" runat="server" ControlToValidate="txtScreenRollWidth" ErrorMessage="Please only enter numbers."  ValidationExpression="\d+" Display="Dynamic"></asp:RegularExpressionValidator>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Roll Length --%>
                    <asp:TableRow ID="rowScreenRollLength">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblScreenRollLength" CssClass="lblField" runat="server" Text="Roll Length:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtScreenRollLength" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="18"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled">
                            <asp:DropDownList ID="ddlScreenRollLengthUnits" CssClass="ddlField" runat="server" Height="32" Width="200" TabIndex="19" AutoPostBack="True" OnSelectedIndexChanged="ddlTables_SelectedIndexChanged">
                                <asp:ListItem>Feet</asp:ListItem>
                                <asp:ListItem>Inches</asp:ListItem>
                            </asp:DropDownList>

                            <%-- Validation --%>
                            <asp:RequiredFieldValidator ID="rfvScreenRollLength" CssClass="errorMsg" runat="server" ValidationGroup="screenroll" ControlToValidate="txtScreenRollLength" ErrorMessage="Please enter a roll length." ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revScreenRollLength" CssClass="errorMsg" runat="server" ValidationGroup="screenroll" ControlToValidate="txtScreenRollLength" ErrorMessage="Please only enter numbers."  ValidationExpression="\d+" Display="Dynamic"></asp:RegularExpressionValidator>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table> <!-- end pnlScreenRoll -->

                <!-- VINYL ROLL PANEL -->
                <asp:Table ID="pnlVinylRoll" CssClass="dimensionsTable" runat="server">
                    <%-- Roll Width --%>
                    <asp:TableRow ID="rowVinylRollWidth" CssClass="firstRow">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblVinylRollWidth" CssClass="lblField" runat="server" Text="Roll Width:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtVinylRollWidth" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="20"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled">
                            <asp:DropDownList ID="ddlVinylRollWidthUnits" CssClass="ddlField" runat="server" Height="32" Width="200" TabIndex="21" AutoPostBack="True" OnSelectedIndexChanged="ddlTables_SelectedIndexChanged">
                                <asp:ListItem>Inches</asp:ListItem>
                                <asp:ListItem>Feet</asp:ListItem>
                            </asp:DropDownList>

                            <%-- Validation --%>
                            <asp:RequiredFieldValidator ID="rfvVinylRollWidth" CssClass="errorMsg" ValidationGroup="vinylroll" runat="server" ControlToValidate="txtVinylRollWidth" ErrorMessage="Please enter a roll width." ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revVinylRollWidth" CssClass="errorMsg" ValidationGroup="vinylroll" runat="server" ControlToValidate="txtVinylRollWidth" ErrorMessage="Please only enter numbers."  ValidationExpression="\d+" Display="Dynamic"></asp:RegularExpressionValidator>
                        </asp:TableCell>
                    </asp:TableRow>

                   <%-- Roll Weight --%>
                    <asp:TableRow ID="rowVinylRollWeight">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblVinylRollWeight" CssClass="lblField" runat="server" Text="Roll Weight:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtVinylRollWeight" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="22"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled">
                            <asp:DropDownList ID="ddlVinylRollWeightUnits" CssClass="ddlField" runat="server" Height="32" Width="200" TabIndex="23" AutoPostBack="True" OnSelectedIndexChanged="ddlTables_SelectedIndexChanged">
                                <asp:ListItem>Pounds</asp:ListItem>
                                <asp:ListItem>Ounces</asp:ListItem>
                            </asp:DropDownList>

                            <%-- Validation --%>
                            <asp:RequiredFieldValidator ID="rfvVinylRollWeight" CssClass="errorMsg" ValidationGroup="vinylroll" runat="server" ControlToValidate="txtVinylRollWeight" ErrorMessage="Please enter a roll weight." ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revVinylRollWeight" CssClass="errorMsg" ValidationGroup="vinylroll" runat="server" ControlToValidate="txtVinylRollWeight" ErrorMessage="Please only enter numbers."  ValidationExpression="\d+" Display="Dynamic"></asp:RegularExpressionValidator>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table> <!-- end pnlVinylRoll -->

                <!-- ROOF PANELS PANEL -->
                <asp:Table ID="pnlRoofPanels" CssClass="dimensionsTable" runat="server">
                    <%-- Size --%>
                    <asp:TableRow ID="rowRoofPanelsSize" CssClass="firstRow">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblRoofPnlSize" CssClass="lblField" runat="server" Text="Size:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtRoofPnlSize" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="24"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled">
                            <asp:DropDownList ID="ddlRoofPnlSizeUnits" CssClass="ddlField" runat="server" Height="32" Width="200" TabIndex="25" AutoPostBack="True" OnSelectedIndexChanged="ddlTables_SelectedIndexChanged">
                                <asp:ListItem>Inches</asp:ListItem>
                                <asp:ListItem>Feet</asp:ListItem>
                            </asp:DropDownList>

                            <%-- Validation --%>
                            <asp:RequiredFieldValidator ID="rfvRoofPnlSize" CssClass="errorMsg" runat="server" ValidationGroup ="roofPanel" ControlToValidate="txtRoofPnlSize" ErrorMessage="Please enter a size." ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revRoofPnlSize" CssClass="errorMsg" runat="server" ValidationGroup="roofPanel" ControlToValidate="txtRoofPnlSize" ErrorMessage="Please only enter numbers."  ValidationExpression="\d+" Display="Dynamic"></asp:RegularExpressionValidator>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Max Width --%>
                    <asp:TableRow ID="rowRoofPanelsMaxWidth">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblRoofPnlMaxWidth" CssClass="lblField" runat="server" Text="Max Width:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtRoofPnlMaxWidth" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="26"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled">
                            <asp:DropDownList ID="ddlRoofPnlMaxWidthUnits" CssClass="ddlField" runat="server" Height="32" Width="200" TabIndex="27" AutoPostBack="True" OnSelectedIndexChanged="ddlTables_SelectedIndexChanged">
                                <asp:ListItem>Inches</asp:ListItem>
                                <asp:ListItem>Feet</asp:ListItem>
                            </asp:DropDownList>

                            <%-- Validation --%>
                            <asp:RequiredFieldValidator ID="rfvRoofPnlMaxWidth" CssClass="errorMsg" runat="server" ValidationGroup ="roofPanel" ControlToValidate="txtRoofPnlMaxWidth" ErrorMessage="Please enter a max width." ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revRoofPnlMaxWidth" CssClass="errorMsg" runat="server" ValidationGroup ="roofPanel" ControlToValidate="txtRoofPnlMaxWidth" ErrorMessage="Please only enter numbers."  ValidationExpression="\d+" Display="Dynamic"></asp:RegularExpressionValidator>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Max Length --%>
                    <asp:TableRow ID="rowRoofPanelsMaxLength">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblRoofPnlMaxLength" CssClass="lblField" runat="server" Text="Max Length:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled" ColumnSpan="2">
                            <asp:textbox ID="txtRoofPanelMaxLength" CssClass="lblInputFieldDisabled" runat="server" value="Site Determined"  TabIndex="28"></asp:textbox>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table> <!-- end pnlRoofPanels -->

                <!-- ROOF EXTRUSIONS PANEL -->
                <asp:Table ID="pnlRoofExtrusions" CssClass="dimensionsTable" runat="server">
                    <%--Size--%>
                    <asp:TableRow ID="rowRoofExtSize" CssClass="firstRow">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblRoofExtSize" CssClass="lblField" runat="server" Text="Size:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtRoofExtSize" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="29"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled">
                            <asp:DropDownList ID="ddlRoofExtSizeUnits" CssClass="ddlField" runat="server" Height="32" Width="200" TabIndex="30" AutoPostBack="True" OnSelectedIndexChanged="ddlTables_SelectedIndexChanged">
                                <asp:ListItem>Inches</asp:ListItem>
                                <asp:ListItem>Feet</asp:ListItem>
                            </asp:DropDownList>

                            <%--Validation--%>
                            <asp:RequiredFieldValidator ID="rfvRoofExtSize" CssClass="errorMsg" ValidationGroup ="roofExtrusion" runat="server" ControlToValidate="txtRoofExtSize" ErrorMessage="Please enter a size." ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revRoofExtSize" CssClass="errorMsg" ValidationGroup ="roofExtrusion" runat="server" ControlToValidate="txtRoofExtSize" ErrorMessage="Please only enter numbers."  ValidationExpression="\d+" Display="Dynamic"></asp:RegularExpressionValidator>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Angle A --%>
                    <asp:TableRow ID="rowRoofExtAngleA">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblRoofExtAngleA" CssClass="lblField" runat="server" Text="Angle A:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtRoofExtAngleA" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="31"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled">
                            <asp:Label ID="lblRoofExtAngleAUnits" CssClass="lblInputFieldDisabled" runat="server" Text="Degrees"></asp:Label>

                            <%-- Validation --%>
                            <asp:RequiredFieldValidator ID="rfvRoofExtAngleA" CssClass="errorMsg" runat="server" ValidationGroup ="roofExtrusion" ControlToValidate="txtRoofExtAngleA" ErrorMessage="Please enter an Angle A."  Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revRoofExtAngleA" CssClass="errorMsg" runat="server" ValidationGroup ="roofExtrusion" ControlToValidate="txtRoofExtAngleA" ErrorMessage="Please only enter numbers."  ValidationExpression="\d+" Display="Dynamic"></asp:RegularExpressionValidator>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Angle B --%>
                    <asp:TableRow ID="rowRoofExtAngleB">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblRoofExtAngleB" CssClass="lblField" runat="server" Text="Angle B:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtRoofExtAngleB" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="32"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled">
                            <asp:Label ID="lblRoofExtAngleBUnits" CssClass="lblInputFieldDisabled" runat="server" Text="Degrees"></asp:Label>

                            <%-- Validation --%>
                            <asp:RequiredFieldValidator ID="rfvRoofExtAngleB" CssClass="errorMsg" ValidationGroup ="roofExtrusion" runat="server" ControlToValidate="txtRoofExtAngleB" ErrorMessage="Please enter an Angle B."  Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revRoofExtAngleB" CssClass="errorMsg" ValidationGroup ="roofExtrusion" runat="server" ControlToValidate="txtRoofExtAngleB" ErrorMessage="Please only enter numbers."  ValidationExpression="\d+" Display="Dynamic"></asp:RegularExpressionValidator>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Angle C --%>
                    <asp:TableRow ID="rowRoofExtAngleC" runat="server">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblRoofExtAngleC" CssClass="lblField" runat="server" Text="Angle C:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtRoofExtAngleC" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="33"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled">
                            <asp:Label ID="lblRoofExtAngleCUnits" CssClass="lblInputFieldDisabled" runat="server" Text="Degrees"></asp:Label>

                            <%-- Validation --%>
                            <asp:RequiredFieldValidator ID="rfvRoofExtAngleC" CssClass="errorMsg" runat="server" ValidationGroup ="roofExtrusion" ControlToValidate="txtRoofExtAngleC" ErrorMessage="Please enter an Angle C."  Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revRoofExtAngleC" CssClass="errorMsg" runat="server" ValidationGroup ="roofExtrusion" ControlToValidate="txtRoofExtAngleC" ErrorMessage="Please only enter numbers."  ValidationExpression="\d+" Display="Dynamic"></asp:RegularExpressionValidator>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Max Length --%>
                    <asp:TableRow ID="rowRoofExtMaxLength" runat="server">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblRoofExtMaxLength" CssClass="lblField" runat="server" Text="Max Length:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtRoofExtMaxLength" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="34"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled">
                            <asp:DropDownList ID="ddlRoofExtMaxLengtUnits" CssClass="ddlField" runat="server" Height="32" Width="200" TabIndex="35" AutoPostBack="True" OnSelectedIndexChanged="ddlTables_SelectedIndexChanged">
                                <asp:ListItem>Feet</asp:ListItem>
                                <asp:ListItem>Inches</asp:ListItem>
                            </asp:DropDownList>

                            <%-- Validation --%>
                            <asp:RequiredFieldValidator ID="rfvRoofExtMaxLength" CssClass="errorMsg" runat="server" ValidationGroup ="roofExtrusion" ControlToValidate="txtRoofExtMaxLength" ErrorMessage="Please enter a max length."  Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revRoofExtMaxLength" CssClass="errorMsg" runat="server" ValidationGroup ="roofExtrusion" ControlToValidate="txtRoofExtMaxLength" ErrorMessage="Please only enter numbers."  ValidationExpression="\d+" Display="Dynamic"></asp:RegularExpressionValidator>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table> <!-- end pnlRoofExtrusions -->

                <!-- DECORATIVE COLUMN PANEL -->
                <asp:Table ID="pnlDecorativeColumn" CssClass="dimensionsTable" runat="server">
                    <%-- Length --%>
                    <asp:TableRow ID="rowDecColLength" CssClass="firstRow">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblDecColLength" CssClass="lblField" runat="server" Text="Length:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtDecColLength" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="36"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled">
                            <asp:DropDownList ID="ddlDecColLengthUnits" CssClass="ddlField" runat="server" Height="32" Width="200" TabIndex="37" AutoPostBack="True" OnSelectedIndexChanged="ddlTables_SelectedIndexChanged">
                                <asp:ListItem>Feet</asp:ListItem>
                                <asp:ListItem>Inches</asp:ListItem>
                            </asp:DropDownList>

                            <%-- Validation --%>
                            <asp:RequiredFieldValidator ID="rfvDecColLength" CssClass="errorMsg" ValidationGroup ="decorativeColumn" runat="server" ControlToValidate="txtDecColLength" ErrorMessage="Please enter a length."  Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revDecColLength" CssClass="errorMsg" ValidationGroup ="decorativeColumn" runat="server" ControlToValidate="txtDecColLength" ErrorMessage="Please only enter numbers."  ValidationExpression="\d+" Display="Dynamic"></asp:RegularExpressionValidator>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table> <!-- end pnlDecorativeColumn -->

                <!-- WALL PANELS PANEL -->
                <asp:Table ID="pnlWallPanel" CssClass="dimensionsTable" runat="server">
                    <%-- Size --%>
                    <asp:TableRow ID="rowWallPanelSize" CssClass="firstRow">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblWallPnlSize" CssClass="lblField" runat="server" Text="Size:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtWallPnlSize" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="38"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled">
                            <asp:DropDownList ID="ddlWallPnlSizeUnits" CssClass="ddlField" runat="server" Height="32" Width="200" TabIndex="39" AutoPostBack="True" OnSelectedIndexChanged="ddlTables_SelectedIndexChanged">
                                <asp:ListItem>Inches</asp:ListItem>
                                <asp:ListItem>Feet</asp:ListItem>
                            </asp:DropDownList>

                            <%-- Validation --%>
                            <asp:RequiredFieldValidator ID="rfvWallPnlSize" CssClass="errorMsg" ValidationGroup ="wallPanel" runat="server" ControlToValidate="txtWallPnlSize" ErrorMessage="Please enter a size." ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revWallPnlSize" CssClass="errorMsg" ValidationGroup ="wallPanel" runat="server" ControlToValidate="txtWallPnlSize" ErrorMessage="Please only enter numbers."  ValidationExpression="\d+" Display="Dynamic"></asp:RegularExpressionValidator>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Max Width --%>
                    <asp:TableRow ID="rowWallPanelMaxWidth">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblWallPnlMaxWidth" CssClass="lblField" runat="server" Text="Max Width:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtWallPnlMaxWidth" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="40"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled">
                            <asp:DropDownList ID="ddlWallPnlMaxWidthUnits" CssClass="ddlField" runat="server" Height="32" Width="200" TabIndex="41" AutoPostBack="True" OnSelectedIndexChanged="ddlTables_SelectedIndexChanged">
                                <asp:ListItem>Inches</asp:ListItem>
                                <asp:ListItem>Feet</asp:ListItem>
                            </asp:DropDownList>

                            <%-- Validation --%>
                            <asp:RequiredFieldValidator ID="rfvWallPnlMaxWidth" CssClass="errorMsg" ValidationGroup ="wallPanel" runat="server" ControlToValidate="txtWallPnlMaxWidth" ErrorMessage="Please enter a max width." ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revWallPnlMaxWidth" CssClass="errorMsg" ValidationGroup ="wallPanel" runat="server" ControlToValidate="txtWallPnlMaxWidth" ErrorMessage="Please only enter numbers."  ValidationExpression="\d+" Display="Dynamic"></asp:RegularExpressionValidator>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Max Length --%>
                    <asp:TableRow ID="rowWallPanelMaxLength">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblWallPnlMaxLength" CssClass="lblField" runat="server" Text="Max Length:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtWallPnlMaxLength" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="42"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled">
                            <asp:DropDownList ID="ddlWallPnlMaxLengthUnits" CssClass="ddlField" runat="server" Height="32" Width="200" TabIndex="43" AutoPostBack="True" OnSelectedIndexChanged="ddlTables_SelectedIndexChanged">
                                <asp:ListItem>Feet</asp:ListItem>
                                <asp:ListItem>Inches</asp:ListItem>
                            </asp:DropDownList>

                            <%-- Validation --%>
                            <asp:RequiredFieldValidator ID="rfvWallPnlMaxLength" CssClass="errorMsg" ValidationGroup ="wallPanel" runat="server" ControlToValidate="txtWallPnlMaxLength" ErrorMessage="Please enter a max length." ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revWallPnlMaxLength" CssClass="errorMsg" ValidationGroup ="wallPanel" runat="server" ControlToValidate="txtWallPnlMaxLength" ErrorMessage="Please only enter numbers."  ValidationExpression="\d+" Display="Dynamic"></asp:RegularExpressionValidator>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table> <!-- end pnlWallPanel -->

                <!-- WALL EXTRUSIONS PANEL -->
                <asp:Table ID="pnlWallExtrusions" CssClass="dimensionsTable" runat="server">
                    <%-- Max Length --%>
                    <asp:TableRow ID="rowWallExtLength" CssClass="firstRow">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblWallExtLength" CssClass="lblField" runat="server" Text="Max Length:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtWallExtLength" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="44"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled">
                            <asp:DropDownList ID="ddlWallExtLengthUnits" CssClass="ddlField" runat="server" Height="32" Width="200" TabIndex="45" AutoPostBack="True" OnSelectedIndexChanged="ddlTables_SelectedIndexChanged">
                                <asp:ListItem>Inches</asp:ListItem>
                                <asp:ListItem>Feet</asp:ListItem>
                            </asp:DropDownList>

                            <%-- Validation --%>
                            <asp:RequiredFieldValidator ID="rfvWallExtLength" CssClass="errorMsg" ValidationGroup ="wallExtrusion" runat="server" ControlToValidate="txtWallExtLength" ErrorMessage="Please enter a size." ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revWallExtLength" CssClass="errorMsg" ValidationGroup ="wallExtrusion" runat="server" ControlToValidate="txtWallExtLength" ErrorMessage="Please only enter numbers."  ValidationExpression="\d+" Display="Dynamic"></asp:RegularExpressionValidator>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table> <!-- end pnlWallExtrusions -->

                <!-- INSULATED FLOORS PANEL -->
                <asp:Table ID="pnlInsulatedFloors" CssClass="dimensionsTable" runat="server">
                    <%-- Size --%>
                    <asp:TableRow ID="rowInsFloorSize" CssClass="firstRow">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblInsFloorSize" CssClass="lblField" runat="server" Text="Size:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtInsFloorSize" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="46"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled">
                            <asp:DropDownList ID="ddlInsFloorSizeUnits" CssClass="ddlField" runat="server" Height="32" Width="200" TabIndex="47" AutoPostBack="True" OnSelectedIndexChanged="ddlTables_SelectedIndexChanged">
                                <asp:ListItem>Inches</asp:ListItem>
                                <asp:ListItem>Feet</asp:ListItem>
                            </asp:DropDownList>

                            <%-- Validation --%>
                            <asp:RequiredFieldValidator ID="rfvInsFloorSize" CssClass="errorMsg" ValidationGroup ="insulatedFloor" runat="server" ControlToValidate="txtInsFloorSize" ErrorMessage="Please enter a size." ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revInsFloorSize" CssClass="errorMsg" ValidationGroup ="insulatedFloor" runat="server" ControlToValidate="txtInsFloorSize" ErrorMessage="Please only enter numbers."  ValidationExpression="\d+" Display="Dynamic"></asp:RegularExpressionValidator>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Max Width --%>
                    <asp:TableRow ID="rowInsFloorMaxWidth">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblInsFloorPnlMaxWidth" CssClass="lblField" runat="server" Text="Max Width:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtInsFloorPnlMaxWidth" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="48"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled">
                           <asp:DropDownList ID="ddlInsFloorPnlMaxWidthUnits" CssClass="ddlField" runat="server" Height="32" Width="200" TabIndex="49" AutoPostBack="True" OnSelectedIndexChanged="ddlTables_SelectedIndexChanged">
                                <asp:ListItem>Inches</asp:ListItem>
                                <asp:ListItem>Feet</asp:ListItem>
                            </asp:DropDownList>

                            <%-- Validation --%>
                            <asp:RequiredFieldValidator ID="rfvInsFloorPnlMaxWidth" CssClass="errorMsg" ValidationGroup ="insulatedFloor" runat="server" ControlToValidate="txtInsFloorPnlMaxWidth" ErrorMessage="Please enter a max width." ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revInsFloorPnlMaxWidth" CssClass="errorMsg" ValidationGroup ="insulatedFloor" runat="server" ControlToValidate="txtInsFloorPnlMaxWidth" ErrorMessage="Please only enter numbers."  ValidationExpression="\d+" Display="Dynamic"></asp:RegularExpressionValidator>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Max Length (string value) --%>
                    <asp:TableRow ID="rowInsFloorMaxLength">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblInsFloorPnlMaxLengthStr" CssClass="lblField" runat="server" Text="Max Length:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled" ColumnSpan="2">
                            <asp:textbox ID="txtInsulatedFloorMaxLength" CssClass="lblInputFieldDisabled" runat="server" Text="Site Determined" TabIndex="50"></asp:textbox>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table> <!-- end pnlInsulatedFloors -->

                <!-- SUNCRYLIC ROOF PANEL -->
                <asp:Table ID="pnlSuncrylicRoof" CssClass="dimensionsTable" runat="server">
                    <%-- Max Width (string)
                    <asp:TableRow ID="rowSunRoofMaxWidthStr" CssClass="firstRow">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblSunRoofMaxWidthStr" CssClass="lblField" runat="server" Text="Max Width:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled" ColumnSpan="2">
                            <asp:Label ID="lblSunRoofMaxWidthStrValue" CssClass="lblInputFieldDisabled" runat="server" Text="Varies" TabIndex="51"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow> --%>

                    <%-- Max Length (string) 
                    <asp:TableRow ID="rowSunRoofMaxLengthStr">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblSunRoofMaxLengthStr" CssClass="lblField" runat="server" Text="Max Length:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled" ColumnSpan="2">
                            <asp:Label ID="lblSunRoofMaxLengthStrValue" CssClass="lblInputFieldDisabled" runat="server" Text="Varies" TabIndex="52"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow> --%>

                    <%-- Max Length (integer) --%>
                    <asp:TableRow ID="rowSunRoofMaxLength" CssClass="firstRow">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblSunRoofMaxLength" CssClass="lblField" runat="server" Text="Max Length:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtSunRoofMaxLength" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="53"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled">
                            <asp:DropDownList ID="ddlSunRoofMaxLengthUnits" CssClass="ddlField" runat="server" Height="32" Width="200" TabIndex="54" AutoPostBack="True" OnSelectedIndexChanged="ddlTables_SelectedIndexChanged">
                                <asp:ListItem>Feet</asp:ListItem>
                                <asp:ListItem>Inches</asp:ListItem>
                            </asp:DropDownList>

                            <%-- Validation --%>
                            <asp:RequiredFieldValidator ID="rfvSunRoofMaxLength" CssClass="errorMsg" ValidationGroup ="suncrylicRoof" runat="server" ControlToValidate="txtSunRoofMaxLength" ErrorMessage="Please enter a max length." ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revSunRoofMaxLength" CssClass="errorMsg" ValidationGroup ="suncrylicRoof" runat="server" ControlToValidate="txtSunRoofMaxLength" ErrorMessage="Please only enter numbers."  ValidationExpression="\d+" Display="Dynamic"></asp:RegularExpressionValidator>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table> <!-- end pnlSuncrylicRoof -->

                <!-- SUNRAIL300 PANEL -->
                <asp:Table ID="pnlSunrail300" CssClass="dimensionsTable" runat="server">
                    <%-- Max Length Feet/Inches (Inches accepts null) --%>
                    <asp:TableRow ID="rowSun300MaxLength" CssClass="firstRow">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblSun300MaxLengthFt" CssClass="lblField" runat="server" Text="Max Length:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtSun300MaxLengthFt" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="55"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabledFeet">
                            <asp:Label ID="lblSun300MaxLengthFtUnits" CssClass="lblInputFieldDisabled" runat="server" Text="Feet"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtSun300PnlMaxLengthInch" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="56"></asp:TextBox>
                        </asp:TableCell>
                            <asp:TableCell CssClass="tdInputTxtDisabled">
                            <asp:Label ID="lblSun300PnlMaxLengthInchUnits" CssClass="lblInputFieldDisabled" runat="server" Text="Inches"></asp:Label>

                            <%-- Validation --%>
                            <asp:RequiredFieldValidator ID="rfvSun300MaxLengthFt" CssClass="errorMsg" ValidationGroup ="suncrylicRoof" runat="server" ControlToValidate="txtSun300MaxLengthFt" ErrorMessage="Please enter a max length in feet." ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revSun300MaxLengthFt" CssClass="errorMsg" ValidationGroup ="suncrylicRoof" runat="server" ControlToValidate="txtSun300MaxLengthFt" ErrorMessage="Please only enter numbers."  ValidationExpression="\d+" Display="Dynamic"></asp:RegularExpressionValidator>
                            <asp:RegularExpressionValidator ID="revSun300PnlMaxLengthInch" CssClass="errorMsg" ValidationGroup ="suncrylicRoof" runat="server" ControlToValidate="txtSun300PnlMaxLengthInch" ErrorMessage="Please only enter numbers."  ValidationExpression="\d+" Display="Dynamic"></asp:RegularExpressionValidator>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table> <!-- end pnlSunrail300 -->

                <!-- SUNRAIL400 PANEL -->
                <asp:Table ID="pnlSunrail400" CssClass="dimensionsTable" runat="server">
                    <%-- Max Length Feet/Inches (Inches accepts null) --%>
                    <asp:TableRow ID="rowSun400MaxLength" CssClass="firstRow">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblSun400MaxLengthFt" CssClass="lblField" runat="server" Text="Max Length:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtSun400MaxLengthFt" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="57"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabledFeet">
                            <asp:Label ID="lblSun400MaxLengthFtUnits" CssClass="lblInputFieldDisabled" runat="server" Text="Feet"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtSun400PnlMaxLengthInch" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="58"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled">
                            <asp:Label ID="lblSun400PnlMaxLengthInchUnits" CssClass="lblInputFieldDisabled" runat="server" Text="Inches"></asp:Label>

                            <%-- Validation --%>
                            <asp:RequiredFieldValidator ID="rfvSun400MaxLengthFt" ValidationGroup ="sunrail400" CssClass="errorMsg" runat="server" ControlToValidate="txtSun400MaxLengthFt" ErrorMessage="Please enter a max length in feet." ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revSun400MaxLengthFt" CssClass="errorMsg" ValidationGroup ="sunrail400" runat="server" ControlToValidate="txtSun400MaxLengthFt" ErrorMessage="Please only enter numbers."  ValidationExpression="\d+" Display="Dynamic"></asp:RegularExpressionValidator>
                            <asp:RegularExpressionValidator ID="revSun400PnlMaxLengthInch" CssClass="errorMsg" ValidationGroup ="sunrail400" runat="server" ControlToValidate="txtSun400PnlMaxLengthInch" ErrorMessage="Please only enter numbers."  ValidationExpression="\d+" Display="Dynamic"></asp:RegularExpressionValidator>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table> <!-- end pnlSunrail400 -->

                <!-- SUNRAIL1000 PANEL -->
                <asp:Table ID="pnlSunrail1000" CssClass="dimensionsTable" runat="server">
                    <%-- Max Length Feet/Inches (Inches accepts null) --%>
                    <asp:TableRow ID="rowSun1000MaxLength" CssClass="firstRow">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblSun1000MaxLengthFt" CssClass="lblField" runat="server" Text="Max Length:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtSun1000MaxLengthFt" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="59"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabledFeet">
                            <asp:Label ID="lblSun1000MaxLengthFtUnits" CssClass="lblInputFieldDisabled" runat="server" Text="Feet"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtSun1000PnlMaxLengthInch" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="60"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled">
                            <asp:Label ID="lblSun1000PnlMaxLengthInchUnits" CssClass="lblInputFieldDisabled" runat="server" Text="Inches"></asp:Label>

                            <%-- Validation --%>
                            <asp:RequiredFieldValidator ID="rfvSun1000MaxLengthFt" CssClass="errorMsg" ValidationGroup ="sunrail1000" runat="server" ControlToValidate="txtSun1000MaxLengthFt" ErrorMessage="Please enter a max length in feet." ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revSun1000MaxLengthFt" CssClass="errorMsg" ValidationGroup ="sunrail1000" runat="server" ControlToValidate="txtSun1000MaxLengthFt" ErrorMessage="Please only enter numbers."  ValidationExpression="\d+" Display="Dynamic"></asp:RegularExpressionValidator>
                            <asp:RegularExpressionValidator ID="revSun1000PnlMaxLengthInch" CssClass="errorMsg" ValidationGroup ="sunrail1000" runat="server" ControlToValidate="txtSun1000PnlMaxLengthInch" ErrorMessage="Please only enter numbers."  ValidationExpression="\d+" Display="Dynamic"></asp:RegularExpressionValidator>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table> <!-- end pnlSunrail1000 -->

                <!-- DOOR FRAME EXTRUSIONS PANEL -->
                <asp:Table ID="pnlDoorFrameExtrusions" CssClass="dimensionsTable" runat="server">
                    <%-- Max Length --%>
                    <asp:TableRow ID="rowDoorFrExtMaxLength" CssClass="firstRow">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblDoorFrExtMaxLength" CssClass="lblField" runat="server" Text="Max Length:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtDoorFrExtMaxLength" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="61"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled">
                            <asp:DropDownList ID="ddlDoorFrExtMaxLengthUnits" CssClass="ddlField" runat="server" Height="32" Width="200" TabIndex="62" AutoPostBack="True" OnSelectedIndexChanged="ddlTables_SelectedIndexChanged">
                                <asp:ListItem>Feet</asp:ListItem>
                                <asp:ListItem>Inches</asp:ListItem>
                            </asp:DropDownList>

                            <%-- Validation --%>
                            <asp:RequiredFieldValidator ID="rfvDoorFrExtMaxLength" CssClass="errorMsg" ValidationGroup ="doorFrameExtrusion" runat="server" ControlToValidate="txtDoorFrExtMaxLength" ErrorMessage="Please enter a max length." ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revDoorFrExtMaxLength" CssClass="errorMsg" ValidationGroup ="doorFrameExtrusion" runat="server" ControlToValidate="txtDoorFrExtMaxLength" ErrorMessage="Please only enter numbers."  ValidationExpression="\d+" Display="Dynamic"></asp:RegularExpressionValidator>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table> <!-- end pnlDoorFrameExtrusions -->

                <!-- SCHEMATICS PANEL -->
                <asp:Table ID="pnlSchematics" CssClass="dimensionsTable" runat="server">

                </asp:Table> <!-- end pnlSchematics -->

        </div> <!-- end contentWrapper -->
    </asp:Panel> <!-- end pnlDimensions -->

    <!-- PRICING PANEL -->
    <asp:Panel ID="pnlPricing" runat="server" CssClass="pnlPricing">
        <div class="contentWrapper">
            <h2>Pricing</h2>
            <asp:Table ID="pricingTable" CssClass="pricingTable" runat="server">
                <asp:TableRow ID="rowPrice" CssClass="trPrice">
                    <asp:TableCell CssClass="tdLabel">
                        <asp:Label ID="lblUsdPrice" CssClass="lblField" runat="server" Text="US Price:"></asp:Label>

</asp:TableCell>
                    <asp:TableCell CssClass="tdInputTxt">
                        <asp:TextBox ID="txtUsdPrice" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="63"></asp:TextBox>

</asp:TableCell>
                    <asp:TableCell CssClass="tdLabel">
                        <asp:Label ID="lblCadPrice" CssClass="lblField" runat="server" Text="Canada Price:"></asp:Label>

</asp:TableCell>
                    <asp:TableCell CssClass="tdInputTxt">
                        <asp:TextBox ID="txtCadPrice" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="64"></asp:TextBox>

</asp:TableCell>

                   
                </asp:TableRow>

                <%-- Validation --%>
                <asp:TableRow CssClass="trPrice">
                    <asp:TableCell CssClass="tdInputPriceError" ColumnSpan="2">
                        <asp:RequiredFieldValidator ID="rfvUsdPrice" CssClass="errorMsgPrice" ValidationGroup="pricing" runat="server" ControlToValidate="txtUsdPrice" ErrorMessage="Please enter a USD price."  Display="Dynamic"></asp:RequiredFieldValidator>
           <asp:CompareValidator id="cfvUsdPrice" CssClass="errorMsgPrice" runat="server" ValidationGroup="pricing" ControlToValidate="txtUsdPrice" Operator="DataTypeCheck"
            Type="Currency"  Display="Dynamic" ErrorMessage="Illegal format for currency" />

                    </asp:TableCell><asp:TableCell CssClass="tdInputPriceError" ColumnSpan="2">
                        <asp:RequiredFieldValidator ID="rfvCadPrice" CssClass="errorMsgPrice" ValidationGroup="pricing" runat="server" ControlToValidate="txtCadPrice" ErrorMessage="Please enter a CAD price."  Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:CompareValidator id="cfvCadPrice" CssClass="errorMsgPrice" runat="server" ValidationGroup="pricing" ControlToValidate="txtCadPrice" Operator="DataTypeCheck"
            Type="Currency"  Display="Dynamic" ErrorMessage="Illegal format for currency" />

                    </asp:TableCell></asp:TableRow></asp:Table><!-- end pricingTable --></div><!-- end contentWrapper --></asp:Panel><!-- end pnlPricing --><!-- STATUS PANEL --><asp:Panel ID="pnlStatus" runat="server" CssClass="pnlStatus">
        <div class="contentWrapper">
            <h2>Status</h2><asp:Table ID="statusTable" CssClass="statusTable" runat="server">
                <asp:TableRow ID="rowStatus">
                    <asp:TableCell CssClass="tdLabel">&nbsp;</asp:TableCell><asp:TableCell CssClass="tdInputRadio">
                        <asp:RadioButton ID="radActive" runat="server" GroupName="status" TabIndex="65" />
                    </asp:TableCell><asp:TableCell CssClass="tdLabelRadio">
                        <asp:Label ID="lblActive" CssClass="lblField" runat="server" Text="Active"></asp:Label>
                    </asp:TableCell><asp:TableCell CssClass="tdInputRadio">
                        <asp:RadioButton ID="radInactive" runat="server" GroupName="status" TabIndex="66" />
                    </asp:TableCell><asp:TableCell CssClass="tdLabelRadio">
                        <asp:Label ID="lblInactive" CssClass="lblField" runat="server" Text="Inactive"></asp:Label>
                    </asp:TableCell></asp:TableRow></asp:Table><!-- end statusTable --></div><!-- end contentWrapper --></asp:Panel><!-- end pnlStatus --><!-- BUTTONS PANEL --><asp:Panel ID="pnlButtons" runat="server" CssClass="pnlButtons">
        <div class="contentWrapper">
            <div class="containerButtons">
                <asp:Button ID="btnInsert" CssClass="btnInsert" runat="server" Text="Insert" Height="30" Width="125" OnClick="btnInsert_Click" TabIndex="68" CausesValidation="False" />
                <asp:Button ID="btnReset" CssClass="btnReset" runat="server" Text="Reset" Height="30" Width="125" CausesValidation="False" OnClick="btnReset_Click" TabIndex="67" />
            </div>
            <br class="clear" />
        </div> <!-- end contentWrapper -->
    </asp:Panel> <!-- end pnlButtons -->

</asp:Content>



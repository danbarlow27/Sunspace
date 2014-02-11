<%@ Page Title="Sunspace | Update Catalogue" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Update.aspx.cs" Inherits="Sunspace.Update" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:SqlDataSource ID="datUpdateDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:sunspaceDealerDesktopConnectionString %>" SelectCommand="SELECT * FROM [acrylic_panels]"></asp:SqlDataSource>
    
    <br class="clear">
    
    
    <asp:SqlDataSource ID="datSelectDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:sunspaceDealerDesktopConnectionString %>" SelectCommand="SELECT * FROM [acrylic_panels]"></asp:SqlDataSource>
    
    <!-- PRODUCT PANEL -->
    <asp:Panel ID="pnlProduct" runat="server" CssClass="pnlProduct">
        <div class="contentWrapper">
            <!-- SCROLLING ARROWS -->
            <asp:Button ID="imgPrevArrow" CssClass="prevArrow" runat="server" OnClick="imgPrevArrow_Click" CausesValidation="False" TabIndex="96"/>
            <asp:Button ID="imgNextArrow" CssClass="nextArrow" runat="server" OnClick="imgNextArrow_Click" CausesValidation="False" TabIndex="97"/>
            <!-- end scrolling arrows -->

            <!-- NAVIGATION -->
            <div class="containerNavigation">
                <asp:DropDownList ID="ddlCategory" CssClass="ddlField" runat="server" Height="27" Width="200" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" AutoPostBack="True"  TabIndex="93"></asp:DropDownList>
                <asp:DropDownList ID="ddlPart" CssClass="ddlField" runat="server" Height="27" Width="270" OnSelectedIndexChanged="ddlPart_SelectedIndexChanged" AutoPostBack="True" TabIndex="94"></asp:DropDownList>

                <asp:Button ID="btnMainMenu" CssClass="float-right" runat="server" Text="Main Menu" CausesValidation="False" Height="27px" Width="105px" OnClick="btnMainMenu_Click" TabIndex="95"/>
            </div> <!-- end containerNavigation -->

            <!-- Image -->
            <div class="containerUpdateImage">
                <div class="imageBoxUpdate">
                    <asp:Image ID="imgPart" runat="server"/> 
                </div>
                 
                <asp:FileUpload ID="fupNewImage" runat="server"  TabIndex="6"/> <br />
                <asp:Button ID="btnUploadImg" CssClass="btnUploadImg" runat="server" Text="Save Image" Height="25" Width="125" TabIndex="7" CausesValidation="False" OnClick="btnUploadImg_Click"/><br />
                <asp:Label ID="valFupNewImage" CssClass="errorMsg" runat="server" Width="250px"></asp:Label>
            </div>          
        
            <!-- Part Number, Name, Key (user-disabled) -->
            <div class="containerPartId">
                <asp:Label ID="lblPartNum" CssClass="lblProduct" runat="server" Text="Part Number"></asp:Label> <br>  
                <asp:Label ID="lblPartName" CssClass="lblProduct" runat="server" Text="Part Name"></asp:Label> <br>
                <asp:Label ID="lblPartKey" CssClass="lblProduct" runat="server" Text="Part Key"></asp:Label> 
            </div>
            
            <!-- DESCRIPTION PANEL -->
            <asp:Panel ID="pnlDescription" runat="server">
                <!-- Description -->
                <div class="containerDesc">
                    <asp:Label ID="lblPartDesc" CssClass="lblField" runat="server" Text="Part Description:"></asp:Label> <br>
                    <asp:TextBox ID="txtPartDesc" CssClass="txtInputFieldDesc" runat="server" Width="410" TextMode="MultiLine" MaxLength="250" TabIndex="1"></asp:TextBox>
                    <br>
                    <asp:RequiredFieldValidator ID="rfvDescription" CssClass="errorMsgProductPanel" runat="server" ControlToValidate="txtPartDesc" ErrorMessage="Please enter a description."  Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </asp:Panel>
            
            <!-- COMPOSITION PANEL -->
            <asp:Panel ID="pnlComposition" runat="server">
                <!-- Composition -->
                <div class="containerComposition">
                    <asp:Label ID="lblComposition" CssClass="lblField" runat="server" Text="Composition:"></asp:Label> <br>
                    <asp:TextBox ID="txtComposition" CssClass="txtInputField" runat="server" Height="20" Width="410" TextMode="SingleLine" TabIndex="2"></asp:TextBox>
                    <br>
                    <asp:RequiredFieldValidator ID="rfvComposition" CssClass="errorMsgProductPanel" runat="server" ControlToValidate="txtComposition" ErrorMessage="Please enter composition." Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </asp:Panel> <!-- end pnlComposition -->

            <!-- STANDARD PANEL -->
            <asp:Panel ID="pnlStandard" runat="server">
                <!-- Standard -->
                <div class="containerStandard">
                    <asp:Label ID="lblStandard" CssClass="lblField" runat="server" Text="Standard:"></asp:Label> <br>
                    <asp:TextBox ID="txtStandard" CssClass="txtInputField" runat="server" Height="20" Width="410" TextMode="SingleLine" TabIndex="3"></asp:TextBox>
                    <br>
                    <asp:RequiredFieldValidator ID="rfvStandard" CssClass="errorMsgProductPanel" runat="server" ControlToValidate="txtStandard" ErrorMessage="Please enter standard." Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </asp:Panel> <!-- end pnlStandard -->

            <!-- PACK QUANTITY -->
            <asp:Panel ID="pnlPackQuantity" runat="server">
                <!-- Pack Quantity -->
                <div class="containerAccessories">
                    <asp:Label ID="lblPackQuantity" CssClass="lblField" runat="server" Text="Pack Quantity:"></asp:Label> <br>
                    <asp:TextBox ID="txtPackQuantity" CssClass="txtInputField" runat="server" Height="20" Width="100" TabIndex="4"></asp:TextBox>
                    <br>
                    <asp:RequiredFieldValidator ID="rfvPackQuantity" CssClass="errorMsgProductPanel" runat="server" ControlToValidate="txtPackQuantity" ErrorMessage="Please enter pack quantity." Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cmpPackQuantity" CssClass="errorMsgProductPanel" runat="server" ControlToValidate="txtPackQuantity" ErrorMessage="Please enter only numbers."  Type="Integer" Operator="DataTypeCheck" Display="Dynamic"></asp:CompareValidator>
                </div>
            </asp:Panel> <!-- end pnlAccProduct -->

            <!-- COLOR PANEL -->
            <asp:Panel ID="pnlColor" runat="server">
                <!-- Color -->
                <div class="containerColor">
                    <asp:Label ID="lblColor" CssClass="lblFieldColor" runat="server" Text="Color:"></asp:Label> 
                    <asp:Label ID="lblColorInput" CssClass="lblInputFieldDisabled" runat="server" Text="Color"></asp:Label> 
                </div>
            </asp:Panel> <!-- end pnlColor -->

            <!-- SCHEMATICS PANEL -->
            <asp:Panel ID="pnlSchematics" runat="server">
                <%-- Schematics Part Selection --%>
                <div class="containerSchem">
                    <asp:Label ID="lblSelectSchem" CssClass="lblField" runat="server" Text="Select Schematic Part:"></asp:Label> <br>
                    <asp:DropDownList ID="ddlSchem" CssClass="ddlField" runat="server" Height="32" Width="250" AutoPostBack="True" TabIndex="5" OnSelectedIndexChanged="ddlSchem_SelectedIndexChanged"></asp:DropDownList>
                    </div>

                <%-- Schematics Part Number, Key, Name --%>
                <div class="containerSchem">
                    <asp:Label ID="lblSchemPartNum" CssClass="lblProduct" runat="server" Text="Part Number"></asp:Label> <br>  
                    <asp:Label ID="lblSchemPartKey" CssClass="lblProduct" runat="server" Text="Part Key:"></asp:Label> <asp:Label ID="lblSchemPartKeyNum" CssClass="lblProduct" runat="server" Text="Part Key Number"></asp:Label> <br>
                    <asp:Label ID="lblSchemPartName" CssClass="lblProduct" runat="server" Text="Part Name"></asp:Label>
                </div>
            </asp:Panel> <!-- end pnlSchematics -->

        </div> <!-- end contentWrapper -->
    </asp:Panel> <!-- end pnlProduct -->

    <!-- DIMENSIONS PANEL -->
    <asp:Panel ID="pnlDimensions" runat="server" CssClass="pnlDimensions"> 
        <div class="contentWrapper">
            <h2>Dimensions</h2>
                      
                <!-- ACCESSORIES PANEL -->
                <asp:Table ID="pnlAccessories" CssClass="dimensionsTable" runat="server">
                    <%-- Size --%> 
                    <asp:TableRow ID="rowAccessorySize">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblAccessorySize" CssClass="lblField" runat="server" Text="Size:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtAccessorySize" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="8" ></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled">
                            <asp:Label ID="lblAccessorySizeUnits" CssClass="lblInputFieldDisabled" runat="server" Text="Units"></asp:Label>
                            
                            <%-- Validation --%>
                            <asp:RequiredFieldValidator ID="rfvAccessorySize" CssClass="errorMsg" runat="server" ControlToValidate="txtAccessorySize" ErrorMessage="Please enter a size." ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cmpAccessorySize" CssClass="errorMsg" runat="server" ControlToValidate="txtAccessorySize" ErrorMessage="Please enter only numbers."  Type="Integer" Operator="DataTypeCheck" Display="Dynamic"></asp:CompareValidator>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Max Width --%>
                    <asp:TableRow ID="rowAccessoryMaxWidth">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblAccessoryWidth" CssClass="lblField" runat="server" Text="Width:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtAccessoryWidth" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="9" ></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled">
                            <asp:Label ID="lblAccessoryWidthUnits" CssClass="lblInputFieldDisabled" runat="server" Text="Units"></asp:Label>

                            <%-- Validation --%>
                            <asp:RequiredFieldValidator ID="rfvAccessoryWidth" CssClass="errorMsg" runat="server" ControlToValidate="txtAccessoryWidth" ErrorMessage="Please enter a max width." ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cmpAccessoryWidth" CssClass="errorMsg" runat="server" ControlToValidate="txtAccessoryWidth" ErrorMessage="Please enter only numbers." Type="Integer" Operator="DataTypeCheck" Display="Dynamic"></asp:CompareValidator>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Max Length --%>
                    <asp:TableRow ID="rowAccessoryMaxLength">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblAccessoryLength" CssClass="lblField" runat="server" Text="Length:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtAccessoryLength" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="10"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled">
                            <asp:Label ID="lblAccessoryLengthUnits" CssClass="lblInputFieldDisabled" runat="server" Text="Units"></asp:Label>

                            <%-- Validation --%>
                            <asp:RequiredFieldValidator ID="rfvAccessoryLength" CssClass="errorMsg" runat="server" ControlToValidate="txtAccessoryLength" ErrorMessage="Please enter a max length." ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cmpAccessoryLength" CssClass="errorMsg" runat="server" ControlToValidate="txtAccessoryLength" ErrorMessage="Please enter only numbers."  Type="Integer" Operator="DataTypeCheck" Display="Dynamic"></asp:CompareValidator>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table> <!-- end pnlAccessories -->
                
                <!-- SCREEN ROLL PANEL -->
                <asp:Table ID="pnlScreenRoll" CssClass="dimensionsTable" runat="server">
                    <%-- Roll Width --%>
                    <asp:TableRow ID="rowScreenRollWidth">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblScreenRollWidth" CssClass="lblField" runat="server" Text="Roll Width:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtScreenRollWidth" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="11"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled">
                            <asp:Label ID="lblScreenRollWidthUnits" CssClass="lblInputFieldDisabled" runat="server" Text="Units"></asp:Label>

                            <%-- Validation --%>
                            <asp:RequiredFieldValidator ID="rfvScreenRollWidth" CssClass="errorMsg" runat="server" ControlToValidate="txtScreenRollWidth" ErrorMessage="Please enter a roll width." ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cmpScreenRollWidth" CssClass="errorMsg" runat="server" ControlToValidate="txtScreenRollWidth" ErrorMessage="Please enter only numbers."  Type="Integer" Operator="DataTypeCheck" Display="Dynamic"></asp:CompareValidator>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Roll Length --%>
                    <asp:TableRow ID="rowScreenRollLength">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblScreenRollLength" CssClass="lblField" runat="server" Text="Roll Length:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtScreenRollLength" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="12"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled">
                            <asp:Label ID="lblScreenRollLengthUnits" CssClass="lblInputFieldDisabled" runat="server" Text="Units"></asp:Label>

                            <%-- Validation --%>
                            <asp:RequiredFieldValidator ID="rfvScreenRollLength" CssClass="errorMsg" runat="server" ControlToValidate="txtScreenRollLength" ErrorMessage="Please enter a roll length." ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cmpScreenRollLength" CssClass="errorMsg" runat="server" ControlToValidate="txtScreenRollLength" ErrorMessage="Please enter only numbers."  Type="Integer" Operator="DataTypeCheck" Display="Dynamic"></asp:CompareValidator>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table> <!-- end pnlScreenRoll -->
                         
                <!-- VINYL ROLL PANEL -->
                <asp:Table ID="pnlVinylRoll" CssClass="dimensionsTable" runat="server">
                    <%-- Roll Width --%>
                    <asp:TableRow ID="rowVinylRollWidth">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblVinylRollWidth" CssClass="lblField" runat="server" Text="Roll Width:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtVinylRollWidth" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="13"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled">
                            <asp:Label ID="lblVinylRollWidthUnits" CssClass="lblInputFieldDisabled" runat="server" Text="Units"></asp:Label>

                            <%-- Validation --%>
                            <asp:RequiredFieldValidator ID="rfvVinylRollWidth" CssClass="errorMsg" runat="server" ControlToValidate="txtVinylRollWidth" ErrorMessage="Please enter a roll width." ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cmpVinylRollWidth" CssClass="errorMsg" runat="server" ControlToValidate="txtVinylRollWidth" ErrorMessage="Please enter only numbers."  Type="Integer" Operator="DataTypeCheck" Display="Dynamic"></asp:CompareValidator>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Roll Length --%>
                    <asp:TableRow ID="rowVinylRollLength">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblVinylRollLength" CssClass="lblField" runat="server" Text="Roll Length:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtVinylRollLength" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="14"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled">
                            <asp:Label ID="lblVinylRollLengthUnits" CssClass="lblInputFieldDisabled" runat="server" Text="Units"></asp:Label>

                            <%-- Validation --%>
                            <asp:RequiredFieldValidator ID="rfvVinylRollLength" CssClass="errorMsg" runat="server" ControlToValidate="txtVinylRollLength" ErrorMessage="Please enter a roll length." ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revVinylRollLength" CssClass="errorMsg" runat="server" ControlToValidate="txtVinylRollLength" ErrorMessage="Please enter only numbers."  ValidationExpression="\d+" Display="Dynamic"></asp:RegularExpressionValidator>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Roll Weight --%>
                    <asp:TableRow ID="rowVinylRollWeight">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblVinylRollWeight" CssClass="lblField" runat="server" Text="Roll Weight:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtVinylRollWeight" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="15"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled">
                            <asp:Label ID="lblVinylRollWeightUnits" CssClass="lblInputFieldDisabled" runat="server" Text="Units"></asp:Label>

                            <%-- Validation --%>
                            <asp:RequiredFieldValidator ID="rfvVinylRollWeight" CssClass="errorMsg" runat="server" ControlToValidate="txtVinylRollWeight" ErrorMessage="Please enter a roll weight." ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cmpVinylRollWeight" CssClass="errorMsg" runat="server" ControlToValidate="txtVinylRollWeight" ErrorMessage="Please enter only numbers."  Type="Integer" Operator="DataTypeCheck" Display="Dynamic"></asp:CompareValidator>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table> <!-- end pnlVinylRoll -->

                <!-- ROOF PANELS PANEL -->
                <asp:Table ID="pnlRoofPanels" CssClass="dimensionsTable" runat="server">
                    <%-- Size --%> 
                    <asp:TableRow ID="rowRoofPanelsSize">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblRoofPnlSize" CssClass="lblField" runat="server" Text="Size:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtRoofPnlSize" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="16"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled">
                            <asp:Label ID="lblRoofPnlSizeUnits" CssClass="lblInputFieldDisabled" runat="server" Text="Units"></asp:Label>
                            
                            <%-- Validation --%>
                            <asp:RequiredFieldValidator ID="rfvRoofPnlSize" CssClass="errorMsg" runat="server" ControlToValidate="txtRoofPnlSize" ErrorMessage="Please enter a size." ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cmpRoofPnlSize" CssClass="errorMsg" runat="server" ControlToValidate="txtRoofPnlSize" ErrorMessage="Please enter only numbers."  Type="Integer" Operator="DataTypeCheck" Display="Dynamic"></asp:CompareValidator>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Max Width --%>
                    <asp:TableRow ID="rowRoofPanelsMaxWidth">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblRoofPnlMaxWidth" CssClass="lblField" runat="server" Text="Max Width:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtRoofPnlMaxWidth" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="17"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled">
                            <asp:Label ID="lblRoofPnlMaxWidthUnits" CssClass="lblInputFieldDisabled" runat="server" Text="Units"></asp:Label>

                            <%-- Validation --%>
                            <asp:RequiredFieldValidator ID="rfvRoofPnlMaxWidth" CssClass="errorMsg" runat="server" ControlToValidate="txtRoofPnlMaxWidth" ErrorMessage="Please enter a max width." ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cmpRoofPnlMaxWidth" CssClass="errorMsg" runat="server" ControlToValidate="txtRoofPnlMaxWidth" ErrorMessage="Please enter only numbers."  Type="Integer" Operator="DataTypeCheck" Display="Dynamic"></asp:CompareValidator>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Max Length (string) --%>
                    <asp:TableRow ID="rowRoofPanelsMaxLengthStr">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblRoofPnlMaxLengthStr" CssClass="lblField" runat="server" Text="Max Length:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled" ColumnSpan="2">
                            <asp:Label ID="lblRoofPnlMaxLengthStrValue" CssClass="lblInputFieldDisabled" runat="server" Text="Site Determined"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Max Length (integer) --%>
                    <asp:TableRow ID="rowRoofPanelsMaxLength">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblRoofPnlMaxLength" CssClass="lblField" runat="server" Text="Max Length:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtRoofPnlMaxLength" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="18"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled">
                            <asp:Label ID="lblRoofPnlMaxLengthUnits" CssClass="lblInputFieldDisabled" runat="server" Text="Units"></asp:Label>

                            <%-- Validation --%>
                            <asp:RequiredFieldValidator ID="rfvRoofPnlMaxLength" CssClass="errorMsg" runat="server" ControlToValidate="txtRoofPnlMaxLength" ErrorMessage="Please enter a max length." ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cmpRoofPnlMaxLength" CssClass="errorMsg" runat="server" ControlToValidate="txtRoofPnlMaxLength" ErrorMessage="Please enter only numbers."  Type="Integer" Operator="DataTypeCheck" Display="Dynamic"></asp:CompareValidator>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table> <!-- end pnlRoofPanels -->
                
                <!-- ROOF EXTRUSIONS PANEL -->
                <asp:Table ID="pnlRoofExtrusions" CssClass="dimensionsTable" runat="server">
                    <%--Size--%>
                    <asp:TableRow ID="rowRoofExtSize">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblRoofExtSize" CssClass="lblField" runat="server" Text="Size:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtRoofExtSize" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="19"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled">
                            <asp:Label ID="lblRoofExtSizeUnits" CssClass="lblInputFieldDisabled" runat="server" Text="Units"></asp:Label>
                        
                            <%--Validation--%>
                            <asp:RequiredFieldValidator ID="rfvRoofExtSize" CssClass="errorMsg" runat="server" ControlToValidate="txtRoofExtSize" ErrorMessage="Please enter a size." ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cmpRoofExtSize" CssClass="errorMsg" runat="server" ControlToValidate="txtRoofExtSize" ErrorMessage="Please enter only numbers."  Type="Integer" Operator="DataTypeCheck" Display="Dynamic"></asp:CompareValidator>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Angle A --%>
                    <asp:TableRow ID="rowRoofExtAngleA">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblRoofExtAngleA" CssClass="lblField" runat="server" Text="Angle A:"></asp:Label>   
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtRoofExtAngleA" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="20"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled">
                            <asp:Label ID="lblRoofExtAngleAUnits" CssClass="lblInputFieldDisabled" runat="server" Text="Units"></asp:Label>
                    
                            <%-- Validation --%>
                            <asp:RequiredFieldValidator ID="rfvRoofExtAngleA" CssClass="errorMsg" runat="server" ControlToValidate="txtRoofExtAngleA" ErrorMessage="Please enter an Angle A."  Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cmpRoofExtAngleA" CssClass="errorMsg" runat="server" ControlToValidate="txtRoofExtAngleA" ErrorMessage="Please enter only numbers."  Type="Integer" Operator="DataTypeCheck" Display="Dynamic"></asp:CompareValidator>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Angle B --%>
                    <asp:TableRow ID="rowRoofExtAngleB">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblRoofExtAngleB" CssClass="lblField" runat="server" Text="Angle B:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtRoofExtAngleB" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="21"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled">
                            <asp:Label ID="lblRoofExtAngleBUnits" CssClass="lblInputFieldDisabled" runat="server" Text="Units"></asp:Label>

                            <%-- Validation --%>
                            <asp:RequiredFieldValidator ID="rfvRoofExtAngleB" CssClass="errorMsg" runat="server" ControlToValidate="txtRoofExtAngleB" ErrorMessage="Please enter an Angle B."  Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cmpRoofExtAngleB" CssClass="errorMsg" runat="server" ControlToValidate="txtRoofExtAngleB" ErrorMessage="Please enter only numbers."  Type="Double" Operator="DataTypeCheck" Display="Dynamic"></asp:CompareValidator>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Angle C --%>
                    <asp:TableRow ID="rowRoofExtAngleC" runat="server">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblRoofExtAngleC" CssClass="lblField" runat="server" Text="Angle C:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtRoofExtAngleC" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="22"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled">
                            <asp:Label ID="lblRoofExtAngleCUnits" CssClass="lblInputFieldDisabled" runat="server" Text="Units"></asp:Label>
                    
                            <%-- Validation --%>
                            <asp:RequiredFieldValidator ID="rfvRoofExtAngleC" CssClass="errorMsg" runat="server" ControlToValidate="txtRoofExtAngleC" ErrorMessage="Please enter an Angle C."  Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cmpRoofExtAngleC" CssClass="errorMsg" runat="server" ControlToValidate="txtRoofExtAngleC" ErrorMessage="Please enter only numbers."  Type="Integer" Operator="DataTypeCheck" Display="Dynamic"></asp:CompareValidator>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Max Length --%>
                    <asp:TableRow ID="rowRoofExtMaxLength" runat="server">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblRoofExtMaxLength" CssClass="lblField" runat="server" Text="Max Length:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtRoofExtMaxLength" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="23"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled">
                            <asp:Label ID="lblRoofExtMaxLengthUnits" CssClass="lblInputFieldDisabled" runat="server" Text="Units"></asp:Label>
                    
                            <%-- Validation --%>
                            <asp:RequiredFieldValidator ID="rfvRoofExtMaxLength" CssClass="errorMsg" runat="server" ControlToValidate="txtRoofExtMaxLength" ErrorMessage="Please enter a max length."  Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cmpRoofExtMaxLength" CssClass="errorMsg" runat="server" ControlToValidate="txtRoofExtMaxLength" ErrorMessage="Please enter only numbers."  Type="Integer" Operator="DataTypeCheck" Display="Dynamic"></asp:CompareValidator>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table> <!-- end pnlRoofExtrusions -->
                
                <!-- DECORATIVE COLUMN PANEL -->
                <asp:Table ID="pnlDecorativeColumn" CssClass="dimensionsTable" runat="server">
                    <%-- Length --%>
                    <asp:TableRow ID="rowDecColLength">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblRoofDecColLength" CssClass="lblField" runat="server" Text="Length:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtRoofDecColLength" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="24"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled">
                            <asp:Label ID="lblRoofDecColLengthUnits" CssClass="lblInputFieldDisabled" runat="server" Text="Units"></asp:Label>
                    
                            <%-- Validation --%>
                            <asp:RequiredFieldValidator ID="rfvRoofDecColLength" CssClass="errorMsg" runat="server" ControlToValidate="txtRoofDecColLength" ErrorMessage="Please enter a length."  Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cmpRoofDecColLength" CssClass="errorMsg" runat="server" ControlToValidate="txtRoofDecColLength" ErrorMessage="Please enter only numbers."  Type="Integer" Operator="DataTypeCheck" Display="Dynamic"></asp:CompareValidator>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table> <!-- end pnlDecorativeColumn -->
                
                <!-- WALL PANELS PANEL -->
                <asp:Table ID="pnlWallPanel" CssClass="dimensionsTable" runat="server">
                    <%-- Size --%>
                    <asp:TableRow ID="rowWallPanelSize">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblWallPnlSize" CssClass="lblField" runat="server" Text="Size:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtWallPnlSize" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="25"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled">
                            <asp:Label ID="lblWallPnlSizeUnits" CssClass="lblInputFieldDisabled" runat="server" Text="Units"></asp:Label>
                            
                            <%-- Validation --%>
                            <asp:RequiredFieldValidator ID="rfvWallPnlSize" CssClass="errorMsg" runat="server" ControlToValidate="txtWallPnlSize" ErrorMessage="Please enter a size." ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revWallPnlSize" CssClass="errorMsg" runat="server" ControlToValidate="txtWallPnlSize" ErrorMessage="Please enter only numbers."  ValidationExpression="\d+" Display="Dynamic"></asp:RegularExpressionValidator>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Max Width --%>
                    <asp:TableRow ID="rowWallPanelMaxWidth">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblWallPnlMaxWidth" CssClass="lblField" runat="server" Text="Max Width:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtWallPnlMaxWidth" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="26"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled">
                            <asp:Label ID="lblWallPnlMaxWidthUnits" CssClass="lblInputFieldDisabled" runat="server" Text="Units"></asp:Label>

                            <%-- Validation --%>
                            <asp:RequiredFieldValidator ID="rfvWallPnlMaxWidth" CssClass="errorMsg" runat="server" ControlToValidate="txtWallPnlMaxWidth" ErrorMessage="Please enter a max width." ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revWallPnlMaxWidth" CssClass="errorMsg" runat="server" ControlToValidate="txtWallPnlMaxWidth" ErrorMessage="Please enter only numbers."  ValidationExpression="\d+" Display="Dynamic"></asp:RegularExpressionValidator>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Max Length --%>
                    <asp:TableRow ID="rowWallPanelMaxLength">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblWallPnlMaxLength" CssClass="lblField" runat="server" Text="Max Length:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtWallPnlMaxLength" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="27"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled">
                            <asp:Label ID="lblWallPnlMaxLengthUnits" CssClass="lblInputFieldDisabled" runat="server" Text="Units"></asp:Label>

                            <%-- Validation --%>
                            <asp:RequiredFieldValidator ID="rfvWallPnlMaxLength" CssClass="errorMsg" runat="server" ControlToValidate="txtWallPnlMaxLength" ErrorMessage="Please enter a max length." ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revWallPnlMaxLength" CssClass="errorMsg" runat="server" ControlToValidate="txtWallPnlMaxLength" ErrorMessage="Please enter only numbers."  ValidationExpression="\d+" Display="Dynamic"></asp:RegularExpressionValidator>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table> <!-- end pnlWallPanel -->
                
                <!-- WALL EXTRUSIONS PANEL -->
                <asp:Table ID="pnlWallExtrusions" CssClass="dimensionsTable" runat="server">
                    <%-- Max Length --%>
                    <asp:TableRow ID="rowWallExtMaxLength">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblWallExtMaxLength" CssClass="lblField" runat="server" Text="Max Length:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtWallExtMaxLength" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="28"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled">
                            <asp:Label ID="lblWallExtMaxLengthUnits" CssClass="lblInputFieldDisabled" runat="server" Text="Units"></asp:Label>

                            <%-- Validation --%>
                            <asp:RequiredFieldValidator ID="rfvWallExtMaxLength" CssClass="errorMsg" runat="server" ControlToValidate="txtWallExtMaxLength" ErrorMessage="Please enter a max length." ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cmpWallExtMaxLength" CssClass="errorMsg" runat="server" ControlToValidate="txtWallExtMaxLength" ErrorMessage="Please enter only numbers." Type="Integer" Operator="DataTypeCheck" Display="Dynamic"></asp:CompareValidator>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table> <!-- end pnlWallExtrusions -->

                <!-- INSULATED FLOORS PANEL -->
                <asp:Table ID="pnlInsulatedFloors" CssClass="dimensionsTable" runat="server">
                    <%-- Size --%>
                    <asp:TableRow ID="rowInsFloorSize">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblInsFloorSize" CssClass="lblField" runat="server" Text="Size:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtInsFloorSize" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="29"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled">
                            <asp:Label ID="lblInsFloorSizeUnits" CssClass="lblInputFieldDisabled" runat="server" Text="Units"></asp:Label>
                            
                            <%-- Validation --%>
                            <asp:RequiredFieldValidator ID="rfvInsFloorSize" CssClass="errorMsg" runat="server" ControlToValidate="txtInsFloorSize" ErrorMessage="Please enter a size." ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cmpInsFloorSize" CssClass="errorMsg" runat="server" ControlToValidate="txtInsFloorSize" ErrorMessage="Please enter only numbers."  Type="Double" Operator="DataTypeCheck" Display="Dynamic"></asp:CompareValidator>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Max Width --%>
                    <asp:TableRow ID="rowInsFloorMaxWidth">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblInsFloorPnlMaxWidth" CssClass="lblField" runat="server" Text="Max Width:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtInsFloorPnlMaxWidth" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="30"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled">
                            <asp:Label ID="lblInsFloorPnlMaxWidthUnits" CssClass="lblInputFieldDisabled" runat="server" Text="Units"></asp:Label>

                            <%-- Validation --%>
                            <asp:RequiredFieldValidator ID="rfvInsFloorPnlMaxWidth" CssClass="errorMsg" runat="server" ControlToValidate="txtInsFloorPnlMaxWidth" ErrorMessage="Please enter a max width." ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cmpInsFloorPnlMaxWidth" CssClass="errorMsg" runat="server" ControlToValidate="txtInsFloorPnlMaxWidth" ErrorMessage="Please enter only numbers." Type="Integer" Operator="DataTypeCheck" Display="Dynamic"></asp:CompareValidator>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Max Length (string value) --%>
                    <asp:TableRow ID="rowInsFloorMaxLength">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblInsFloorPnlMaxLengthStr" CssClass="lblField" runat="server" Text="Max Length:"></asp:Label>
                        </asp:TableCell>                     
                        <asp:TableCell CssClass="tdInputTxtDisabled" ColumnSpan="2">
                            <asp:Label ID="lblInsFloorPnlMaxLengthStrValue" CssClass="lblInputFieldDisabled" runat="server" Text="Site Determined"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table> <!-- end pnlInsulatedFloors -->

                <!-- SUNCRYLIC ROOF PANEL -->
                <asp:Table ID="pnlSuncrylicRoof" CssClass="dimensionsTable" runat="server">
                    <%-- Max Width (string) --%>
                    <asp:TableRow ID="rowSunRoofMaxWidthStr">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblSunRoofMaxWidthStr" CssClass="lblField" runat="server" Text="Max Width:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled" ColumnSpan="2">
                            <asp:Label ID="lblSunRoofMaxWidthStrValue" CssClass="lblInputFieldDisabled" runat="server" Text="Varies"></asp:Label>

                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Max Length (string) --%>
                    <asp:TableRow ID="rowSunRoofMaxLengthStr">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblSunRoofMaxLengthStr" CssClass="lblField" runat="server" Text="Max Length:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled" ColumnSpan="2">
                            <asp:Label ID="lblSunRoofMaxLengthStrValue" CssClass="lblInputFieldDisabled" runat="server" Text="Varies"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Max Length (integer) --%>
                    <asp:TableRow ID="rowSunRoofMaxLength">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblSunRoofMaxLength" CssClass="lblField" runat="server" Text="Max Length:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtSunRoofMaxLength" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="31"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled">
                            <asp:Label ID="lblSunRoofMaxLengthUnits" CssClass="lblInputFieldDisabled" runat="server" Text="Units"></asp:Label>

                            <%-- Validation --%>
                            <asp:RequiredFieldValidator ID="rfvSunRoofMaxLength" CssClass="errorMsg" runat="server" ControlToValidate="txtSunRoofMaxLength" ErrorMessage="Please enter a max length." ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cmpSunRoofMaxLength" CssClass="errorMsg" runat="server" ControlToValidate="txtSunRoofMaxLength" ErrorMessage="Please enter only numbers."  Type="Integer" Operator="DataTypeCheck" Display="Dynamic"></asp:CompareValidator>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table> <!-- end pnlSuncrylicRoof -->

                <!-- SUNRAIL300 PANEL -->
                <asp:Table ID="pnlSunrail300" CssClass="dimensionsTable" runat="server">
                    <%-- Max Length Feet/Inches (Inches accepts null) --%>
                    <asp:TableRow ID="rowSun300MaxLength">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblSun300MaxLengthFt" CssClass="lblField" runat="server" Text="Max Length:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtSun300MaxLengthFt" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="32"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabledFeet">
                            <asp:Label ID="lblSun300MaxLengthFtUnits" CssClass="lblInputFieldDisabled" runat="server" Text="Feet"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtSun300PnlMaxLengthInch" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="33"></asp:TextBox>
                        </asp:TableCell>
                            <asp:TableCell CssClass="tdInputTxtDisabled">
                            <asp:Label ID="lblSun300PnlMaxLengthInchUnits" CssClass="lblInputFieldDisabled" runat="server" Text="Inches"></asp:Label>

                            <%-- Validation --%>
                            <asp:RequiredFieldValidator ID="rfvSun300MaxLengthFt" CssClass="errorMsg" runat="server" ControlToValidate="txtSun300MaxLengthFt" ErrorMessage="Please enter a max length in feet." ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cmpSun300MaxLengthFt" CssClass="errorMsg" runat="server" ControlToValidate="txtSun300MaxLengthFt" ErrorMessage="Please enter only numbers." Type="Integer" Operator="DataTypeCheck" Display="Dynamic"></asp:CompareValidator>
                            <asp:CompareValidator ID="cmpSun300PnlMaxLengthInch" CssClass="errorMsg" runat="server" ControlToValidate="txtSun300PnlMaxLengthInch" ErrorMessage="Please enter only numbers." Type="Integer" Operator="DataTypeCheck" Display="Dynamic"></asp:CompareValidator>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table> <!-- end pnlSunrail300 -->

                <!-- SUNRAIL400 PANEL -->
                <asp:Table ID="pnlSunrail400" CssClass="dimensionsTable" runat="server">
                    <%-- Max Length Feet/Inches (Inches accepts null) --%>
                    <asp:TableRow ID="rowSun400MaxLength">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblSun400MaxLengthFt" CssClass="lblField" runat="server" Text="Max Length:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtSun400MaxLengthFt" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="34"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabledFeet">
                            <asp:Label ID="lblSun400MaxLengthFtUnits" CssClass="lblInputFieldDisabled" runat="server" Text="Feet"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtSun400PnlMaxLengthInch" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="35"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled">
                            <asp:Label ID="lblSun400PnlMaxLengthInchUnits" CssClass="lblInputFieldDisabled" runat="server" Text="Inches"></asp:Label>

                            <%-- Validation --%>
                            <asp:RequiredFieldValidator ID="rfvSun400MaxLengthFt" CssClass="errorMsg" runat="server" ControlToValidate="txtSun400MaxLengthFt" ErrorMessage="Please enter a max length in feet." ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cmpSun400MaxLengthFt" CssClass="errorMsg" runat="server" ControlToValidate="txtSun400MaxLengthFt" ErrorMessage="Please enter only numbers." Type="Integer" Operator="DataTypeCheck" Display="Dynamic"></asp:CompareValidator>
                            <asp:CompareValidator ID="cmpSun400PnlMaxLengthInch" CssClass="errorMsg" runat="server" ControlToValidate="txtSun400PnlMaxLengthInch" ErrorMessage="Please enter only numbers." Type="Integer" Operator="DataTypeCheck" Display="Dynamic"></asp:CompareValidator>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table> <!-- end pnlSunrail400 -->

                <!-- SUNRAIL1000 PANEL -->
                <asp:Table ID="pnlSunrail1000" CssClass="dimensionsTable" runat="server">
                    <%-- Max Length Feet/Inches (Inches accepts null) --%>
                    <asp:TableRow ID="rowSun1000MaxLength">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblSun1000MaxLengthFt" CssClass="lblField" runat="server" Text="Max Length:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtSun1000MaxLengthFt" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="36"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabledFeet">
                            <asp:Label ID="lblSun1000MaxLengthFtUnits" CssClass="lblInputFieldDisabled" runat="server" Text="Feet"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtSun1000PnlMaxLengthInch" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="37"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled">
                            <asp:Label ID="lblSun1000PnlMaxLengthInchUnits" CssClass="lblInputFieldDisabled" runat="server" Text="Inches"></asp:Label>

                            <%-- Validation --%>
                            <asp:RequiredFieldValidator ID="rfvSun1000MaxLengthFt" CssClass="errorMsg" runat="server" ControlToValidate="txtSun1000MaxLengthFt" ErrorMessage="Please enter a max length in feet." ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cmpSun1000MaxLengthFt" CssClass="errorMsg" runat="server" ControlToValidate="txtSun1000MaxLengthFt" ErrorMessage="Please enter only numbers." Type="Integer" Operator="DataTypeCheck" Display="Dynamic"></asp:CompareValidator>
                            <asp:CompareValidator ID="cmpSun1000PnlMaxLengthInch" CssClass="errorMsg" runat="server" ControlToValidate="txtSun1000PnlMaxLengthInch" ErrorMessage="Please enter only numbers." Type="Integer" Operator="DataTypeCheck" Display="Dynamic"></asp:CompareValidator>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table> <!-- end pnlSunrail1000 -->

                <!-- DOOR FRAME EXTRUSIONS PANEL -->
                <asp:Table ID="pnlDoorFrameExtrusions" CssClass="dimensionsTable" runat="server">
                    <%-- Max Length --%>
                    <asp:TableRow ID="rowDoorFrExtMaxLength">
                        <asp:TableCell CssClass="tdLabel">
                            <asp:Label ID="lblDoorFrExtMaxLength" CssClass="lblField" runat="server" Text="Max Length:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxt">
                            <asp:TextBox ID="txtDoorFrExtMaxLength" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="38"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tdInputTxtDisabled">
                            <asp:Label ID="lblDoorFrExtMaxLengthUnits" CssClass="lblInputFieldDisabled" runat="server" Text="Units"></asp:Label>

                            <%-- Validation --%>
                            <asp:RequiredFieldValidator ID="rfvDoorFrExtMaxLength" CssClass="errorMsg" runat="server" ControlToValidate="txtDoorFrExtMaxLength" ErrorMessage="Please enter a max length." ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cmpDoorFrExtMaxLength" CssClass="errorMsg" runat="server" ControlToValidate="txtDoorFrExtMaxLength" ErrorMessage="Please enter only numbers."  Type="Integer" Operator="DataTypeCheck" Display="Dynamic"></asp:CompareValidator>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table> <!-- end pnlDoorFrameExtrusions -->

     

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
                        <asp:TextBox ID="txtUsdPrice" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="39"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdLabel">
                        <asp:Label ID="lblCadPrice" CssClass="lblField" runat="server" Text="Canada Price:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdInputTxt">
                        <asp:TextBox ID="txtCadPrice" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="40"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>

                <%-- Validation --%>
                <asp:TableRow CssClass="trPrice">
                    <asp:TableCell CssClass="tdInputPriceError" ColumnSpan="2">
                        <asp:RequiredFieldValidator ID="rfvUsdPrice" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtUsdPrice" ErrorMessage="Please enter a USD price."  Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cmpUsdPrice" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtUsdPrice" ErrorMessage="Please enter a decimal value." Type="Currency" Operator="DataTypeCheck" Display="Dynamic"  ValidationGroup="pricing"></asp:CompareValidator>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdInputPriceError" ColumnSpan="2">
                        <asp:RequiredFieldValidator ID="rfvCadPrice" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtCadPrice" ErrorMessage="Please enter a CAD price."  Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cmpCadPrice" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtCadPrice" ErrorMessage="Please enter a decimal value." Type="Currency" Operator="DataTypeCheck" Display="Dynamic" ValidationGroup="pricing"></asp:CompareValidator>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table> <!-- end pricingTable -->
        </div> <!-- end contentWrapper -->
    </asp:Panel> <!-- end pnlPricing -->

    <!-- SCHEMATICS PRICING PANEL -->
    <asp:Panel ID="pnlPricingSchematics" runat="server" CssClass="pnlPricing">
        <div class="contentWrapper">
            <h2>Pricing</h2>
            <asp:Table ID="pricingSchemTable" CssClass="pricingTable" runat="server">
                <%-- Schematic Whole --%>
                <asp:TableRow ID="rowSchematicPrice" CssClass="trPriceSchem">
                    <asp:TableCell CssClass="tdLabel">
                        <asp:Label ID="lblSchematicPrice" CssClass="lblField" runat="server" Text="Total Price:"></asp:Label>
                    </asp:TableCell>
                    <%-- US Price --%>
                    <asp:TableCell CssClass="tdLabelPriceSchem">
                        <asp:Label ID="lblUsdPriceSchematic" CssClass="lblField" runat="server" Text="US Price:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdInputTxt">
                        <asp:TextBox ID="txtUsdPriceSchematic" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="41"></asp:TextBox>
                    </asp:TableCell>
                    <%-- CAD Price --%>
                    <asp:TableCell CssClass="tdLabel">
                        <asp:Label ID="lblCadPriceSchematic" CssClass="lblField" runat="server" Text="Canada Price:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdInputTxt">
                        <asp:TextBox ID="txtCadPriceSchematic" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="42"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdSchemLast">&nbsp;</asp:TableCell>
                </asp:TableRow> <%-- end rowSchematicPrice --%>

                <%-- Validation Schematic Whole --%>
                <asp:TableRow ID="rowSchematicPriceVal" CssClass="trPriceSchem">
                    <%-- US Price --%>
                    <asp:TableCell CssClass="tdInputPriceError" ColumnSpan="3">
                        <asp:RequiredFieldValidator ID="rfvSchemWholeUsd" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtUsdPriceSchematic" ErrorMessage="Please enter a USD price."  Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cmpSchemWholeUsd" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtUsdPriceSchematic" ErrorMessage="Please enter a decimal value."  Type="Currency" Operator="DataTypeCheck" Display="Dynamic"></asp:CompareValidator>
                    </asp:TableCell>
                    <%-- CAD Price --%>
                    <asp:TableCell CssClass="tdInputPriceError" ColumnSpan="2">
                        <asp:RequiredFieldValidator ID="rfvSchemWholeCad" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtCadPriceSchematic" ErrorMessage="Please enter a CAD price."  Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cmpSchemWholeCad" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtCadPriceSchematic" ErrorMessage="Please enter a decimal value."  Type="Currency" Operator="DataTypeCheck" Display="Dynamic"></asp:CompareValidator>
                    </asp:TableCell>
                </asp:TableRow> <%-- end validation rowSchematicPriceVal --%>
                <%-- end Schematic Whole --%>

                <%-- Schematic Part 1 --%>
                <asp:TableRow ID="rowPart1" CssClass="trPriceSchem">
                    <asp:TableCell CssClass="tdLabel">
                        <asp:Label ID="lblPartOne" CssClass="lblField" runat="server" Text="Part Key 1:"></asp:Label>
                    </asp:TableCell>
                    <%-- US Price --%>
                    <asp:TableCell CssClass="tdLabelPriceSchem">
                        <asp:Label ID="lblUsdPricePartOne" CssClass="lblField" runat="server" Text="US Price:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdInputTxt">
                        <asp:TextBox ID="txtUsdPricePartOne" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="43"></asp:TextBox>
                    </asp:TableCell>
                    <%-- CAD Price --%>
                    <asp:TableCell CssClass="tdLabel">
                        <asp:Label ID="lblCadPricePartOne" CssClass="lblField" runat="server" Text="Canada Price:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdInputTxt">
                        <asp:TextBox ID="txtCadPricePartOne" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="44"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdSchemLast">&nbsp;</asp:TableCell>
                </asp:TableRow> <%-- end rowPart1 --%>

                <%-- Validation Schematic Part 1 --%>
                <asp:TableRow ID="rowPart1Val" CssClass="trPriceSchem">
                    <%-- US Price --%>
                    <asp:TableCell CssClass="tdInputPriceError" ColumnSpan="3">
                        <asp:RequiredFieldValidator ID="rfvUsdPricePartOne" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtUsdPricePartOne" ErrorMessage="Please enter a USD price."  Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cmpUsdPricePartOne" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtUsdPricePartOne" ErrorMessage="Please enter a decimal value."  Type="Currency" Operator="DataTypeCheck" Display="Dynamic"></asp:CompareValidator>
                    </asp:TableCell>
                    <%-- CAD Price --%>
                    <asp:TableCell CssClass="tdInputPriceError" ColumnSpan="2">
                        <asp:RequiredFieldValidator ID="rfvCadPricePartOne" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtCadPricePartOne" ErrorMessage="Please enter a CAD price."  Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cmpCadPricePartOne" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtCadPricePartOne" ErrorMessage="Please enter a decimal value."  Type="Currency" Operator="DataTypeCheck" Display="Dynamic"></asp:CompareValidator>
                    </asp:TableCell>
                </asp:TableRow> <%-- end validation rowPart1Val --%>
                <%-- end Schematic Part 1 --%>

                <%-- Schematic Part 2 --%>
                <asp:TableRow ID="rowPart2" CssClass="trPriceSchem">
                    <asp:TableCell CssClass="tdLabel">
                        <asp:Label ID="lblPartTwo" CssClass="lblField" runat="server" Text="Part Key 2:"></asp:Label>
                    </asp:TableCell>
                    <%-- US Price --%>
                    <asp:TableCell CssClass="tdLabelPriceSchem">
                        <asp:Label ID="lblUsdPricePartTwo" CssClass="lblField" runat="server" Text="US Price:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdInputTxt">
                        <asp:TextBox ID="txtUsdPricePartTwo" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="45"></asp:TextBox>
                    </asp:TableCell>
                    <%-- CAD Price --%>
                    <asp:TableCell CssClass="tdLabel">
                        <asp:Label ID="lblCadPricePartTwo" CssClass="lblField" runat="server" Text="Canada Price:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdInputTxt">
                        <asp:TextBox ID="txtCadPricePartTwo" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="46"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdSchemLast">&nbsp;</asp:TableCell>
                </asp:TableRow> <%-- end rowPart2 --%>

                <%-- Validation Schematic Part 2 --%>
                <asp:TableRow ID="rowPart2Val" CssClass="trPriceSchem">
                    <%-- US Price --%>
                    <asp:TableCell CssClass="tdInputPriceError" ColumnSpan="3">
                        <asp:RequiredFieldValidator ID="rfvUsdPricePartTwo" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtUsdPricePartTwo" ErrorMessage="Please enter a USD price."  Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cmpUsdPricePartTwo" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtUsdPricePartTwo" ErrorMessage="Please enter a decimal value."  Type="Currency" Operator="DataTypeCheck" Display="Dynamic"></asp:CompareValidator>
                    </asp:TableCell>
                    <%-- CAD Price --%>
                    <asp:TableCell CssClass="tdInputPriceError" ColumnSpan="2">
                        <asp:RequiredFieldValidator ID="rfvCadPricePartTwo" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtCadPricePartTwo" ErrorMessage="Please enter a CAD price."  Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cmpCadPricePartTwo" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtCadPricePartTwo" ErrorMessage="Please enter a decimal value."  Type="Currency" Operator="DataTypeCheck" Display="Dynamic"></asp:CompareValidator>
                    </asp:TableCell>
                </asp:TableRow> <%-- end validation rowPart2Val --%>
                <%-- end Schematic Part 2 --%>

                <%-- Schematic Part 3 --%>
                <asp:TableRow ID="rowPart3" CssClass="trPriceSchem">
                    <asp:TableCell CssClass="tdLabel">
                        <asp:Label ID="lblPartThree" CssClass="lblField" runat="server" Text="Part Key 3:"></asp:Label>
                    </asp:TableCell>
                    <%-- US Price --%>
                    <asp:TableCell CssClass="tdLabelPriceSchem">
                        <asp:Label ID="lblUsdPricePartThree" CssClass="lblField" runat="server" Text="US Price:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdInputTxt">
                        <asp:TextBox ID="txtUsdPricePartThree" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="47"></asp:TextBox>
                    </asp:TableCell>
                    <%-- CAD Price --%>
                    <asp:TableCell CssClass="tdLabel">
                        <asp:Label ID="lblCadPricePartThree" CssClass="lblField" runat="server" Text="Canada Price:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdInputTxt">
                        <asp:TextBox ID="txtCadPricePartThree" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="48"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdSchemLast">&nbsp;</asp:TableCell>
                </asp:TableRow> <%-- end rowPart3 --%>

                <%-- Validation Schematic Part 3 --%>
                <asp:TableRow ID="rowPart3Val" CssClass="trPriceSchem">
                    <%-- US Price --%>
                    <asp:TableCell CssClass="tdInputPriceError" ColumnSpan="3">
                        <asp:RequiredFieldValidator ID="rfvUsdPricePartThree" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtUsdPricePartThree" ErrorMessage="Please enter a USD price."  Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cmpUsdPricePartThree" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtUsdPricePartThree" ErrorMessage="Please enter a decimal value."  Type="Currency" Operator="DataTypeCheck" Display="Dynamic"></asp:CompareValidator>
                    </asp:TableCell>
                    <%-- CAD Price --%>
                    <asp:TableCell CssClass="tdInputPriceError" ColumnSpan="2">
                        <asp:RequiredFieldValidator ID="rfvCadPricePartThree" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtCadPricePartThree" ErrorMessage="Please enter a CAD price."  Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cmpCadPricePartThree" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtCadPricePartThree" ErrorMessage="Please enter a decimal value."  Type="Currency" Operator="DataTypeCheck" Display="Dynamic"></asp:CompareValidator>
                    </asp:TableCell>
                </asp:TableRow> <%-- end validation rowPart3Val --%>
                <%-- end Schematic Part 3 --%>

                <%-- Schematic Part 4 --%>
                <asp:TableRow ID="rowPart4" CssClass="trPriceSchem">
                    <asp:TableCell CssClass="tdLabel">
                        <asp:Label ID="lblPartFour" CssClass="lblField" runat="server" Text="Part Key 4:"></asp:Label>
                    </asp:TableCell>
                    <%-- US Price --%>
                    <asp:TableCell CssClass="tdLabelPriceSchem">
                        <asp:Label ID="lblUsdPricePartFour" CssClass="lblField" runat="server" Text="US Price:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdInputTxt">
                        <asp:TextBox ID="txtUsdPricePartFour" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="49"></asp:TextBox>
                    </asp:TableCell>
                    <%-- CAD Price --%>
                    <asp:TableCell CssClass="tdLabel">
                        <asp:Label ID="lblCadPricePartFour" CssClass="lblField" runat="server" Text="Canada Price:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdInputTxt">
                        <asp:TextBox ID="txtCadPricePartFour" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="50"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdSchemLast">&nbsp;</asp:TableCell>
                </asp:TableRow> <%-- end rowPart4 --%>

                <%-- Validation Schematic Part 4 --%>
                <asp:TableRow ID="rowPart4Val" CssClass="trPriceSchem">
                    <%-- US Price --%>
                    <asp:TableCell CssClass="tdInputPriceError" ColumnSpan="3">
                        <asp:RequiredFieldValidator ID="rfvUsdPricePartFour" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtUsdPricePartFour" ErrorMessage="Please enter a USD price."  Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cmpUsdPricePartFour" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtUsdPricePartFour" ErrorMessage="Please enter a decimal value."  Type="Currency" Operator="DataTypeCheck" Display="Dynamic"></asp:CompareValidator>
                    </asp:TableCell>
                    <%-- CAD Price --%>
                    <asp:TableCell CssClass="tdInputPriceError" ColumnSpan="2">
                        <asp:RequiredFieldValidator ID="rfvCadPricePartFour" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtCadPricePartFour" ErrorMessage="Please enter a CAD price."  Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cmpCadPricePartFour" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtCadPricePartFour" ErrorMessage="Please enter a decimal value."  Type="Currency" Operator="DataTypeCheck" Display="Dynamic"></asp:CompareValidator>
                    </asp:TableCell>
                </asp:TableRow> <%-- end validation rowPart4Val --%>
                <%-- end Schematic Part 4 --%>

                <%-- Schematic Part 5 --%>
                <asp:TableRow ID="rowPart5" CssClass="trPriceSchem">
                    <asp:TableCell CssClass="tdLabel">
                        <asp:Label ID="lblPartFive" CssClass="lblField" runat="server" Text="Part Key 5:"></asp:Label>
                    </asp:TableCell>
                    <%-- US Price --%>
                    <asp:TableCell CssClass="tdLabelPriceSchem">
                        <asp:Label ID="lblUsdPricePartFive" CssClass="lblField" runat="server" Text="US Price:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdInputTxt">
                        <asp:TextBox ID="txtUsdPricePartFive" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="51"></asp:TextBox>
                    </asp:TableCell>
                    <%-- CAD Price --%>
                    <asp:TableCell CssClass="tdLabel">
                        <asp:Label ID="lblCadPricePartFive" CssClass="lblField" runat="server" Text="Canada Price:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdInputTxt">
                        <asp:TextBox ID="txtCadPricePartFive" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="52"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdSchemLast">&nbsp;</asp:TableCell>
                </asp:TableRow> <%-- end rowPart5 --%>

                <%-- Validation Schematic Part 5 --%>
                <asp:TableRow ID="rowPart5Val" CssClass="trPriceSchem">
                    <%-- US Price --%>
                    <asp:TableCell CssClass="tdInputPriceError" ColumnSpan="3">
                        <asp:RequiredFieldValidator ID="rfvUsdPricePartFive" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtUsdPricePartFive" ErrorMessage="Please enter a USD price."  Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cmpUsdPricePartFive" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtUsdPricePartFive" ErrorMessage="Please enter a decimal value."  Type="Currency" Operator="DataTypeCheck" Display="Dynamic"></asp:CompareValidator>
                    </asp:TableCell>
                    <%-- CAD Price --%>
                    <asp:TableCell CssClass="tdInputPriceError" ColumnSpan="2">
                        <asp:RequiredFieldValidator ID="rfvCadPricePartFive" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtCadPricePartFive" ErrorMessage="Please enter a CAD price."  Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cmpCadPricePartFive" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtCadPricePartFive" ErrorMessage="Please enter a decimal value."  Type="Currency" Operator="DataTypeCheck" Display="Dynamic"></asp:CompareValidator>
                    </asp:TableCell>
                </asp:TableRow> <%-- end validation rowPart5Val --%>
                <%-- end Schematic Part 5 --%>

                <%-- Schematic Part 6 --%>
                <asp:TableRow ID="rowPart6" CssClass="trPriceSchem">
                    <asp:TableCell CssClass="tdLabel">
                        <asp:Label ID="lblPartSix" CssClass="lblField" runat="server" Text="Part Key 6:"></asp:Label>
                    </asp:TableCell>
                    <%-- US Price --%>
                    <asp:TableCell CssClass="tdLabelPriceSchem">
                        <asp:Label ID="lblUsdPricePartSix" CssClass="lblField" runat="server" Text="US Price:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdInputTxt">
                        <asp:TextBox ID="txtUsdPricePartSix" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="53"></asp:TextBox>
                    </asp:TableCell>
                    <%-- CAD Price --%>
                    <asp:TableCell CssClass="tdLabel">
                        <asp:Label ID="lblCadPricePartSix" CssClass="lblField" runat="server" Text="Canada Price:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdInputTxt">
                        <asp:TextBox ID="txtCadPricePartSix" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="54"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdSchemLast">&nbsp;</asp:TableCell>
                </asp:TableRow> <%-- end rowPart6 --%>

                <%-- Validation Schematic Part 6 --%>
                <asp:TableRow ID="rowPart6Val" CssClass="trPriceSchem">
                    <%-- US Price --%>
                    <asp:TableCell CssClass="tdInputPriceError" ColumnSpan="3">
                        <asp:RequiredFieldValidator ID="rfvUsdPricePartSix" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtUsdPricePartSix" ErrorMessage="Please enter a USD price."  Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cmpUsdPricePartSix" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtUsdPricePartSix" ErrorMessage="Please enter a decimal value." Type="Currency" Operator="DataTypeCheck" Display="Dynamic"></asp:CompareValidator>
                    </asp:TableCell>
                    <%-- CAD Price --%>
                    <asp:TableCell CssClass="tdInputPriceError" ColumnSpan="2">
                        <asp:RequiredFieldValidator ID="rfvCadPricePartSix" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtCadPricePartSix" ErrorMessage="Please enter a CAD price."  Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cmpCadPricePartSix" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtCadPricePartSix" ErrorMessage="Please enter a decimal value."  Type="Currency" Operator="DataTypeCheck" Display="Dynamic"></asp:CompareValidator>
                    </asp:TableCell>
                </asp:TableRow> <%-- end validation rowPart6Val --%>
                <%-- end Schematic Part 6 --%>

                <%-- Schematic Part 7 --%>
                <asp:TableRow ID="rowPart7" CssClass="trPriceSchem">
                    <asp:TableCell CssClass="tdLabel">
                        <asp:Label ID="lblPartSeven" CssClass="lblField" runat="server" Text="Part Key 7:"></asp:Label>
                    </asp:TableCell>
                    <%-- US Price --%>
                    <asp:TableCell CssClass="tdLabelPriceSchem">
                        <asp:Label ID="lblUsdPricePartSeven" CssClass="lblField" runat="server" Text="US Price:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdInputTxt">
                        <asp:TextBox ID="txtUsdPricePartSeven" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="55"></asp:TextBox>
                    </asp:TableCell>
                    <%-- CAD Price --%>
                    <asp:TableCell CssClass="tdLabel">
                        <asp:Label ID="lblCadPricePartSeven" CssClass="lblField" runat="server" Text="Canada Price:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdInputTxt">
                        <asp:TextBox ID="txtCadPricePartSeven" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="56"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdSchemLast">&nbsp;</asp:TableCell>
                </asp:TableRow> <%-- end rowPart7 --%>

                <%-- Validation Schematic Part 7 --%>
                <asp:TableRow ID="rowPart7Val" CssClass="trPriceSchem">
                    <%-- US Price --%>
                    <asp:TableCell CssClass="tdInputPriceError" ColumnSpan="3">
                        <asp:RequiredFieldValidator ID="rfvUsdPricePartSeven" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtUsdPricePartSeven" ErrorMessage="Please enter a USD price."  Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cmpUsdPricePartSeven" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtUsdPricePartSeven" ErrorMessage="Please enter a decimal value."  Type="Currency" Operator="DataTypeCheck"  Display="Dynamic"></asp:CompareValidator>
                    </asp:TableCell>
                    <%-- CAD Price --%>
                    <asp:TableCell CssClass="tdInputPriceError" ColumnSpan="2">
                        <asp:RequiredFieldValidator ID="rfvCadPricePartSeven" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtCadPricePartSeven" ErrorMessage="Please enter a CAD price."  Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cmpCadPricePartSeven" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtCadPricePartSeven" ErrorMessage="Please enter a decimal value."  Type="Currency" Operator="DataTypeCheck"  Display="Dynamic"></asp:CompareValidator>
                    </asp:TableCell>
                </asp:TableRow> <%-- end validation rowPart7Val --%>
                <%-- end Schematic Part 7 --%>

                <%-- Schematic Part 8 --%>
                <asp:TableRow ID="rowPart8" CssClass="trPriceSchem">
                    <asp:TableCell CssClass="tdLabel">
                        <asp:Label ID="lblPartEight" CssClass="lblField" runat="server" Text="Part Key 8:"></asp:Label>
                    </asp:TableCell>
                    <%-- US Price --%>
                    <asp:TableCell CssClass="tdLabelPriceSchem">
                        <asp:Label ID="lblUsdPricePartEight" CssClass="lblField" runat="server" Text="US Price:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdInputTxt">
                        <asp:TextBox ID="txtUsdPricePartEight" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="57"></asp:TextBox>
                    </asp:TableCell>
                    <%-- CAD Price --%>
                    <asp:TableCell CssClass="tdLabel">
                        <asp:Label ID="lblCadPricePartEight" CssClass="lblField" runat="server" Text="Canada Price:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdInputTxt">
                        <asp:TextBox ID="txtCadPricePartEight" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="58"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdSchemLast">&nbsp;</asp:TableCell>
                </asp:TableRow> <%-- end rowPart8 --%>

                <%-- Validation Schematic Part 8 --%>
                <asp:TableRow ID="rowPart8Val" CssClass="trPriceSchem">
                    <%-- US Price --%>
                    <asp:TableCell CssClass="tdInputPriceError" ColumnSpan="3">
                        <asp:RequiredFieldValidator ID="rfvUsdPricePartEight" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtUsdPricePartEight" ErrorMessage="Please enter a USD price."  Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cmpUsdPricePartEight" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtUsdPricePartEight" ErrorMessage="Please enter a decimal value."  Type="Currency" Operator="DataTypeCheck"  Display="Dynamic"></asp:CompareValidator>
                    </asp:TableCell>
                    <%-- CAD Price --%>
                    <asp:TableCell CssClass="tdInputPriceError" ColumnSpan="2">
                        <asp:RequiredFieldValidator ID="rfvCadPricePartEight" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtCadPricePartEight" ErrorMessage="Please enter a CAD price."  Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cmpCadPricePartEight" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtCadPricePartEight" ErrorMessage="Please enter a decimal value."  Type="Currency" Operator="DataTypeCheck"  Display="Dynamic"></asp:CompareValidator>
                    </asp:TableCell>
                </asp:TableRow> <%-- end validation rowPart8Val --%>
                <%-- end Schematic Part 8 --%>

                <%-- Schematic Part 9 --%>
                <asp:TableRow ID="rowPart9" CssClass="trPriceSchem">
                    <asp:TableCell CssClass="tdLabel">
                        <asp:Label ID="lblPartNine" CssClass="lblField" runat="server" Text="Part Key 9:"></asp:Label>
                    </asp:TableCell>
                    <%-- US Price --%>
                    <asp:TableCell CssClass="tdLabelPriceSchem">
                        <asp:Label ID="lblUsdPricePartNine" CssClass="lblField" runat="server" Text="US Price:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdInputTxt">
                        <asp:TextBox ID="txtUsdPricePartNine" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="59"></asp:TextBox>
                    </asp:TableCell>
                    <%-- CAD Price --%>
                    <asp:TableCell CssClass="tdLabel">
                        <asp:Label ID="lblCadPricePartNine" CssClass="lblField" runat="server" Text="Canada Price:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdInputTxt">
                        <asp:TextBox ID="txtCadPricePartNine" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="60"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdSchemLast">&nbsp;</asp:TableCell>
                </asp:TableRow> <%-- end rowPart9 --%>

                <%-- Validation Schematic Part 9 --%>
                <asp:TableRow ID="rowPart9Val" CssClass="trPriceSchem">
                    <%-- US Price --%>
                    <asp:TableCell CssClass="tdInputPriceError" ColumnSpan="3">
                        <asp:RequiredFieldValidator ID="rfvUsdPricePartNine" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtUsdPricePartNine" ErrorMessage="Please enter a USD price."  Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cmpUsdPricePartNine" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtUsdPricePartNine" ErrorMessage="Please enter a decimal value."  Type="Currency" Operator="DataTypeCheck"  Display="Dynamic"></asp:CompareValidator>
                    </asp:TableCell>
                    <%-- CAD Price --%>
                    <asp:TableCell CssClass="tdInputPriceError" ColumnSpan="2">
                        <asp:RequiredFieldValidator ID="rfvCadPricePartNine" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtCadPricePartNine" ErrorMessage="Please enter a CAD price."  Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cmpCadPricePartNine" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtCadPricePartNine" ErrorMessage="Please enter a decimal value."  Type="Currency" Operator="DataTypeCheck"  Display="Dynamic"></asp:CompareValidator>
                    </asp:TableCell>
                </asp:TableRow> <%-- end validation rowPart9Val --%>
                <%-- end Schematic Part 9 --%>

                <%-- Schematic Part 10 --%>
                <asp:TableRow ID="rowPart10" CssClass="trPriceSchem">
                    <asp:TableCell CssClass="tdLabel">
                        <asp:Label ID="lblPartTen" CssClass="lblField" runat="server" Text="Part Key 10:"></asp:Label>
                    </asp:TableCell>
                    <%-- US Price --%>
                    <asp:TableCell CssClass="tdLabelPriceSchem">
                        <asp:Label ID="lblUsdPricePartTen" CssClass="lblField" runat="server" Text="US Price:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdInputTxt">
                        <asp:TextBox ID="txtUsdPricePartTen" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="61"></asp:TextBox>
                    </asp:TableCell>
                    <%-- CAD Price --%>
                    <asp:TableCell CssClass="tdLabel">
                        <asp:Label ID="lblCadPricePartTen" CssClass="lblField" runat="server" Text="Canada Price:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdInputTxt">
                        <asp:TextBox ID="txtCadPricePartTen" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="62"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdSchemLast">&nbsp;</asp:TableCell>
                </asp:TableRow> <%-- end rowPart10 --%>

                <%-- Validation Schematic Part 10 --%>
                <asp:TableRow ID="rowPart10Val" CssClass="trPriceSchem">
                    <%-- US Price --%>
                    <asp:TableCell CssClass="tdInputPriceError" ColumnSpan="3">
                        <asp:RequiredFieldValidator ID="rfvUsdPricePartTen" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtUsdPricePartTen" ErrorMessage="Please enter a USD price."  Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cmpUsdPricePartTen" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtUsdPricePartTen" ErrorMessage="Please enter a decimal value."  Type="Currency" Operator="DataTypeCheck"  Display="Dynamic"></asp:CompareValidator>
                    </asp:TableCell>
                    <%-- CAD Price --%>
                    <asp:TableCell CssClass="tdInputPriceError" ColumnSpan="2">
                        <asp:RequiredFieldValidator ID="rfvCadPricePartTen" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtCadPricePartTen" ErrorMessage="Please enter a CAD price."  Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cmpCadPricePartTen" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtCadPricePartTen" ErrorMessage="Please enter a decimal value."  Type="Currency" Operator="DataTypeCheck"  Display="Dynamic"></asp:CompareValidator>
                    </asp:TableCell>
                </asp:TableRow> <%-- end validation rowPart10Val --%>
                <%-- end Schematic Part 10 --%>

                <%-- Schematic Part 11 --%>
                <asp:TableRow ID="rowPart11" CssClass="trPriceSchem">
                    <asp:TableCell CssClass="tdLabel">
                        <asp:Label ID="lblPartEleven" CssClass="lblField" runat="server" Text="Part Key 11:"></asp:Label>
                    </asp:TableCell>
                    <%-- US Price --%>
                    <asp:TableCell CssClass="tdLabelPriceSchem">
                        <asp:Label ID="lblUsdPricePartEleven" CssClass="lblField" runat="server" Text="US Price:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdInputTxt">
                        <asp:TextBox ID="txtUsdPricePartEleven" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="63"></asp:TextBox>
                    </asp:TableCell>
                    <%-- CAD Price --%>
                    <asp:TableCell CssClass="tdLabel">
                        <asp:Label ID="lblCadPricePartEleven" CssClass="lblField" runat="server" Text="Canada Price:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdInputTxt">
                        <asp:TextBox ID="txtCadPricePartEleven" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="64"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdSchemLast">&nbsp;</asp:TableCell>
                </asp:TableRow> <%-- end rowPart11 --%>

                <%-- Validation Schematic Part 11 --%>
                <asp:TableRow ID="rowPart11Val" CssClass="trPriceSchem">
                    <%-- US Price --%>
                    <asp:TableCell CssClass="tdInputPriceError" ColumnSpan="3">
                        <asp:RequiredFieldValidator ID="rfvUsdPricePartEleven" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtUsdPricePartEleven" ErrorMessage="Please enter a USD price."  Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cmpUsdPricePartEleven" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtUsdPricePartEleven" ErrorMessage="Please enter a decimal value."  Type="Currency" Operator="DataTypeCheck"  Display="Dynamic"></asp:CompareValidator>
                    </asp:TableCell>
                    <%-- CAD Price --%>
                    <asp:TableCell CssClass="tdInputPriceError" ColumnSpan="2">
                        <asp:RequiredFieldValidator ID="rfvCadPricePartEleven" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtCadPricePartEleven" ErrorMessage="Please enter a CAD price."  Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cmpCadPricePartEleven" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtCadPricePartEleven" ErrorMessage="Please enter a decimal value."  Type="Currency" Operator="DataTypeCheck"  Display="Dynamic"></asp:CompareValidator>
                    </asp:TableCell>
                </asp:TableRow> <%-- end validation rowPart11Val --%>
                <%-- end Schematic Part 11 --%>

                <%-- Schematic Part 12 --%>
                <asp:TableRow ID="rowPart12" CssClass="trPriceSchem">
                    <asp:TableCell CssClass="tdLabel">
                        <asp:Label ID="lblPartTwelve" CssClass="lblField" runat="server" Text="Part Key 12:"></asp:Label>
                    </asp:TableCell>
                    <%-- US Price --%>
                    <asp:TableCell CssClass="tdLabelPriceSchem">
                        <asp:Label ID="lblUsdPricePartTwelve" CssClass="lblField" runat="server" Text="US Price:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdInputTxt">
                        <asp:TextBox ID="txtUsdPricePartTwelve" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="65"></asp:TextBox>
                    </asp:TableCell>
                    <%-- CAD Price --%>
                    <asp:TableCell CssClass="tdLabel">
                        <asp:Label ID="lblCadPricePartTwelve" CssClass="lblField" runat="server" Text="Canada Price:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdInputTxt">
                        <asp:TextBox ID="txtCadPricePartTwelve" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="66"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdSchemLast">&nbsp;</asp:TableCell>
                </asp:TableRow> <%-- end rowPart12 --%>

                <%-- Validation Schematic Part 12 --%>
                <asp:TableRow ID="rowPart12Val" CssClass="trPriceSchem">
                    <%-- US Price --%>
                    <asp:TableCell CssClass="tdInputPriceError" ColumnSpan="3">
                        <asp:RequiredFieldValidator ID="rfvUsdPricePartTwelve" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtUsdPricePartTwelve" ErrorMessage="Please enter a USD price."  Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cmpUsdPricePartTwelve" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtUsdPricePartTwelve" ErrorMessage="Please enter a decimal value."  Type="Currency" Operator="DataTypeCheck"  Display="Dynamic"></asp:CompareValidator>
                    </asp:TableCell>
                    <%-- CAD Price --%>
                    <asp:TableCell CssClass="tdInputPriceError" ColumnSpan="2">
                        <asp:RequiredFieldValidator ID="rfvCadPricePartTwelve" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtCadPricePartTwelve" ErrorMessage="Please enter a CAD price."  Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cmpCadPricePartTwelve" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtCadPricePartTwelve" ErrorMessage="Please enter a decimal value."  Type="Currency" Operator="DataTypeCheck"  Display="Dynamic"></asp:CompareValidator>
                    </asp:TableCell>
                </asp:TableRow> <%-- end validation rowPart12Val --%>
                <%-- end Schematic Part 12 --%>

                <%-- Schematic Part 13 --%>
                <asp:TableRow ID="rowPart13" CssClass="trPriceSchem">
                    <asp:TableCell CssClass="tdLabel">
                        <asp:Label ID="lblPartThirteen" CssClass="lblField" runat="server" Text="Part Key 13:"></asp:Label>
                    </asp:TableCell>
                    <%-- US Price --%>
                    <asp:TableCell CssClass="tdLabelPriceSchem">
                        <asp:Label ID="lblUsdPricePartThirteen" CssClass="lblField" runat="server" Text="US Price:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdInputTxt">
                        <asp:TextBox ID="txtUsdPricePartThirteen" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="67"></asp:TextBox>
                    </asp:TableCell>
                    <%-- CAD Price --%>
                    <asp:TableCell CssClass="tdLabel">
                        <asp:Label ID="lblCadPricePartThirteen" CssClass="lblField" runat="server" Text="Canada Price:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdInputTxt">
                        <asp:TextBox ID="txtCadPricePartThirteen" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="68"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdSchemLast">&nbsp;</asp:TableCell>
                </asp:TableRow> <%-- end rowPart13 --%>

                <%-- Validation Schematic Part 13 --%>
                <asp:TableRow ID="rowPart13Val" CssClass="trPriceSchem">
                    <%-- US Price --%>
                    <asp:TableCell CssClass="tdInputPriceError" ColumnSpan="3">
                        <asp:RequiredFieldValidator ID="rfvUsdPricePartThirteen" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtUsdPricePartThirteen" ErrorMessage="Please enter a USD price."  Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cmpUsdPricePartThirteen" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtUsdPricePartThirteen" ErrorMessage="Please enter a decimal value."  Type="Currency" Operator="DataTypeCheck"  Display="Dynamic"></asp:CompareValidator>
                    </asp:TableCell>
                    <%-- CAD Price --%>
                    <asp:TableCell CssClass="tdInputPriceError" ColumnSpan="2">
                        <asp:RequiredFieldValidator ID="rfvCadPricePartThirteen" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtCadPricePartThirteen" ErrorMessage="Please enter a CAD price."  Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cmpCadPricePartThirteen" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtCadPricePartThirteen" ErrorMessage="Please enter a decimal value."  Type="Currency" Operator="DataTypeCheck"  Display="Dynamic"></asp:CompareValidator>
                    </asp:TableCell>
                </asp:TableRow> <%-- end validation rowPart13Val --%>
                <%-- end Schematic Part 13 --%>

                <%-- Schematic Part 14 --%>
                <asp:TableRow ID="rowPart14" CssClass="trPriceSchem">
                    <asp:TableCell CssClass="tdLabel">
                        <asp:Label ID="lblPartFourteen" CssClass="lblField" runat="server" Text="Part Key 14:"></asp:Label>
                    </asp:TableCell>
                    <%-- US Price --%>
                    <asp:TableCell CssClass="tdLabelPriceSchem">
                        <asp:Label ID="lblUsdPricePartFourteen" CssClass="lblField" runat="server" Text="US Price:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdInputTxt">
                        <asp:TextBox ID="txtUsdPricePartFourteen" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="69"></asp:TextBox>
                    </asp:TableCell>
                    <%-- CAD Price --%>
                    <asp:TableCell CssClass="tdLabel">
                        <asp:Label ID="lblCadPricePartFourteen" CssClass="lblField" runat="server" Text="Canada Price:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdInputTxt">
                        <asp:TextBox ID="txtCadPricePartFourteen" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="70"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdSchemLast">&nbsp;</asp:TableCell>
                </asp:TableRow> <%-- end rowPart14 --%>

                <%-- Validation Schematic Part 14 --%>
                <asp:TableRow ID="rowPart14Val" CssClass="trPriceSchem">
                    <%-- US Price --%>
                    <asp:TableCell CssClass="tdInputPriceError" ColumnSpan="3">
                        <asp:RequiredFieldValidator ID="rfvUsdPricePartFourteen" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtUsdPricePartFourteen" ErrorMessage="Please enter a USD price."  Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cmpUsdPricePartFourteen" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtUsdPricePartFourteen" ErrorMessage="Please enter a decimal value."  Type="Currency" Operator="DataTypeCheck"  Display="Dynamic"></asp:CompareValidator>
                    </asp:TableCell>
                    <%-- CAD Price --%>
                    <asp:TableCell CssClass="tdInputPriceError" ColumnSpan="2">
                        <asp:RequiredFieldValidator ID="rfvCadPricePartFourteen" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtCadPricePartFourteen" ErrorMessage="Please enter a CAD price."  Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cmpCadPricePartFourteen" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtCadPricePartFourteen" ErrorMessage="Please enter a decimal value."  Type="Currency" Operator="DataTypeCheck"  Display="Dynamic"></asp:CompareValidator>
                    </asp:TableCell>
                </asp:TableRow> <%-- end validation rowPart14Val --%>
                <%-- end Schematic Part 14 --%>

                <%-- Schematic Part 15 --%>
                <asp:TableRow ID="rowPart15" CssClass="trPriceSchem">
                    <asp:TableCell CssClass="tdLabel">
                        <asp:Label ID="lblPartFifteen" CssClass="lblField" runat="server" Text="Part Key 15:"></asp:Label>
                    </asp:TableCell>
                    <%-- US Price --%>
                    <asp:TableCell CssClass="tdLabelPriceSchem">
                        <asp:Label ID="lblUsdPricePartFifteen" CssClass="lblField" runat="server" Text="US Price:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdInputTxt">
                        <asp:TextBox ID="txtUsdPricePartFifteen" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="71"></asp:TextBox>
                    </asp:TableCell>
                    <%-- CAD Price --%>
                    <asp:TableCell CssClass="tdLabel">
                        <asp:Label ID="lblCadPricePartFifteen" CssClass="lblField" runat="server" Text="Canada Price:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdInputTxt">
                        <asp:TextBox ID="txtCadPricePartFifteen" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="72"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdSchemLast">&nbsp;</asp:TableCell>
                </asp:TableRow> <%-- end rowPart15 --%>

                <%-- Validation Schematic Part 15 --%>
                <asp:TableRow ID="rowPart15Val" CssClass="trPriceSchem">
                    <%-- US Price --%>
                    <asp:TableCell CssClass="tdInputPriceError" ColumnSpan="3">
                        <asp:RequiredFieldValidator ID="rfvUsdPricePartFifteen" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtUsdPricePartFifteen" ErrorMessage="Please enter a USD price."  Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cmpUsdPricePartFifteen" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtUsdPricePartFifteen" ErrorMessage="Please enter a decimal value."  Type="Currency" Operator="DataTypeCheck"  Display="Dynamic"></asp:CompareValidator>
                    </asp:TableCell>
                    <%-- CAD Price --%>
                    <asp:TableCell CssClass="tdInputPriceError" ColumnSpan="2">
                        <asp:RequiredFieldValidator ID="rfvCadPricePartFifteen" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtCadPricePartFifteen" ErrorMessage="Please enter a CAD price."  Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cmpCadPricePartFifteen" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtCadPricePartFifteen" ErrorMessage="Please enter a decimal value."  Type="Currency" Operator="DataTypeCheck"  Display="Dynamic"></asp:CompareValidator>
                    </asp:TableCell>
                </asp:TableRow> <%-- end validation rowPart15Val --%>
                <%-- end Schematic Part 15 --%>

                <%-- Schematic Part 16 --%>
                <asp:TableRow ID="rowPart16" CssClass="trPriceSchem">
                    <asp:TableCell CssClass="tdLabel">
                        <asp:Label ID="lblPartSixteen" CssClass="lblField" runat="server" Text="Part Key 16:"></asp:Label>
                    </asp:TableCell>
                    <%-- US Price --%>
                    <asp:TableCell CssClass="tdLabelPriceSchem">
                        <asp:Label ID="lblUsdPricePartSixteen" CssClass="lblField" runat="server" Text="US Price:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdInputTxt">
                        <asp:TextBox ID="txtUsdPricePartSixteen" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="73"></asp:TextBox>
                    </asp:TableCell>
                    <%-- CAD Price --%>
                    <asp:TableCell CssClass="tdLabel">
                        <asp:Label ID="lblCadPricePartSixteen" CssClass="lblField" runat="server" Text="Canada Price:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdInputTxt">
                        <asp:TextBox ID="txtCadPricePartSixteen" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="74"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdSchemLast">&nbsp;</asp:TableCell>
                </asp:TableRow> <%-- end rowPart16 --%>

                <%-- Validation Schematic Part 16 --%>
                <asp:TableRow ID="rowPart16Val" CssClass="trPriceSchem">
                    <%-- US Price --%>
                    <asp:TableCell CssClass="tdInputPriceError" ColumnSpan="3">
                        <asp:RequiredFieldValidator ID="rfvUsdPricePartSixteen" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtUsdPricePartSixteen" ErrorMessage="Please enter a USD price."  Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cmpUsdPricePartSixteen" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtUsdPricePartSixteen" ErrorMessage="Please enter a decimal value."  Type="Currency" Operator="DataTypeCheck"  Display="Dynamic"></asp:CompareValidator>
                    </asp:TableCell>
                    <%-- CAD Price --%>
                    <asp:TableCell CssClass="tdInputPriceError" ColumnSpan="2">
                        <asp:RequiredFieldValidator ID="rfvCadPricePartSixteen" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtCadPricePartSixteen" ErrorMessage="Please enter a CAD price."  Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cmpCadPricePartSixteen" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtCadPricePartSixteen" ErrorMessage="Please enter a decimal value."  Type="Currency" Operator="DataTypeCheck"  Display="Dynamic"></asp:CompareValidator>
                    </asp:TableCell>
                </asp:TableRow> <%-- end validation rowPart16Val --%>
                <%-- end Schematic Part 16 --%>

                <%-- Schematic Part 17 --%>
                <asp:TableRow ID="rowPart17" CssClass="trPriceSchem">
                    <asp:TableCell CssClass="tdLabel">
                        <asp:Label ID="lblPartSeventeen" CssClass="lblField" runat="server" Text="Part Key 17:"></asp:Label>
                    </asp:TableCell>
                    <%-- US Price --%>
                    <asp:TableCell CssClass="tdLabelPriceSchem">
                        <asp:Label ID="lblUsdPricePartSeventeen" CssClass="lblField" runat="server" Text="US Price:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdInputTxt">
                        <asp:TextBox ID="txtUsdPricePartSeventeen" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="75"></asp:TextBox>
                    </asp:TableCell>
                    <%-- CAD Price --%>
                    <asp:TableCell CssClass="tdLabel">
                        <asp:Label ID="lblCadPricePartSeventeen" CssClass="lblField" runat="server" Text="Canada Price:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdInputTxt">
                        <asp:TextBox ID="txtCadPricePartSeventeen" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="76"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdSchemLast">&nbsp;</asp:TableCell>
                </asp:TableRow> <%-- end rowPart17 --%>

                <%-- Validation Schematic Part 17 --%>
                <asp:TableRow ID="rowPart17Val" CssClass="trPriceSchem">
                    <%-- US Price --%>
                    <asp:TableCell CssClass="tdInputPriceError" ColumnSpan="3">
                        <asp:RequiredFieldValidator ID="rfvUsdPricePartSeventeen" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtUsdPricePartSeventeen" ErrorMessage="Please enter a USD price."  Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cmpUsdPricePartSeventeen" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtUsdPricePartSeventeen" ErrorMessage="Please enter a decimal value."  Type="Currency" Operator="DataTypeCheck"  Display="Dynamic"></asp:CompareValidator>
                    </asp:TableCell>
                    <%-- CAD Price --%>
                    <asp:TableCell CssClass="tdInputPriceError" ColumnSpan="2">
                        <asp:RequiredFieldValidator ID="rfvCadPricePartSeventeen" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtCadPricePartSeventeen" ErrorMessage="Please enter a CAD price."  Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cmpCadPricePartSeventeen" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtCadPricePartSeventeen" ErrorMessage="Please enter a decimal value."  Type="Currency" Operator="DataTypeCheck"  Display="Dynamic"></asp:CompareValidator>
                    </asp:TableCell>
                </asp:TableRow> <%-- end validation rowPart17Val --%>
                <%-- end Schematic Part 17 --%>

                <%-- Schematic Part 18 --%>
                <asp:TableRow ID="rowPart18" CssClass="trPriceSchem">
                    <asp:TableCell CssClass="tdLabel">
                        <asp:Label ID="lblPartEighteen" CssClass="lblField" runat="server" Text="Part Key 18:"></asp:Label>
                    </asp:TableCell>
                    <%-- US Price --%>
                    <asp:TableCell CssClass="tdLabelPriceSchem">
                        <asp:Label ID="lblUsdPricePartEighteen" CssClass="lblField" runat="server" Text="US Price:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdInputTxt">
                        <asp:TextBox ID="txtUsdPricePartEighteen" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="77"></asp:TextBox>
                    </asp:TableCell>
                    <%-- CAD Price --%>
                    <asp:TableCell CssClass="tdLabel">
                        <asp:Label ID="lblCadPricePartEighteen" CssClass="lblField" runat="server" Text="Canada Price:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdInputTxt">
                        <asp:TextBox ID="txtCadPricePartEighteen" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="78"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdSchemLast">&nbsp;</asp:TableCell>
                </asp:TableRow> <%-- end rowPart18 --%>

                <%-- Validation Schematic Part 18 --%>
                <asp:TableRow ID="rowPart18Val" CssClass="trPriceSchem">
                    <%-- US Price --%>
                    <asp:TableCell CssClass="tdInputPriceError" ColumnSpan="3">
                        <asp:RequiredFieldValidator ID="rfvUsdPricePartEighteen" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtUsdPricePartEighteen" ErrorMessage="Please enter a USD price."  Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cmpUsdPricePartEighteen" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtUsdPricePartEighteen" ErrorMessage="Please enter a decimal value."  Type="Currency" Operator="DataTypeCheck"  Display="Dynamic"></asp:CompareValidator>
                    </asp:TableCell>
                    <%-- CAD Price --%>
                    <asp:TableCell CssClass="tdInputPriceError" ColumnSpan="2">
                        <asp:RequiredFieldValidator ID="rfvCadPricePartEighteen" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtCadPricePartEighteen" ErrorMessage="Please enter a CAD price."  Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cmpCadPricePartEighteen" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtCadPricePartEighteen" ErrorMessage="Please enter a decimal value."  Type="Currency" Operator="DataTypeCheck"  Display="Dynamic"></asp:CompareValidator>
                    </asp:TableCell>
                </asp:TableRow> <%-- end validation rowPart18Val --%>
                <%-- end Schematic Part 18 --%>

                <%-- Schematic Part 19 --%>
                <asp:TableRow ID="rowPart19" CssClass="trPriceSchem">
                    <asp:TableCell CssClass="tdLabel">
                        <asp:Label ID="lblPartNineteen" CssClass="lblField" runat="server" Text="Part Key 19:"></asp:Label>
                    </asp:TableCell>
                    <%-- US Price --%>
                    <asp:TableCell CssClass="tdLabelPriceSchem">
                        <asp:Label ID="lblUsdPricePartNineteen" CssClass="lblField" runat="server" Text="US Price:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdInputTxt">
                        <asp:TextBox ID="txtUsdPricePartNineteen" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="79"></asp:TextBox>
                    </asp:TableCell>
                    <%-- CAD Price --%>
                    <asp:TableCell CssClass="tdLabel">
                        <asp:Label ID="lblCadPricePartNineteen" CssClass="lblField" runat="server" Text="Canada Price:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdInputTxt">
                        <asp:TextBox ID="txtCadPricePartNineteen" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="80"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdSchemLast">&nbsp;</asp:TableCell>
                </asp:TableRow> <%-- end rowPart19 --%>

                <%-- Validation Schematic Part 19 --%>
                <asp:TableRow ID="rowPart19Val" CssClass="trPriceSchem">
                    <%-- US Price --%>
                    <asp:TableCell CssClass="tdInputPriceError" ColumnSpan="3">
                        <asp:RequiredFieldValidator ID="rfvUsdPricePartNineteen" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtUsdPricePartNineteen" ErrorMessage="Please enter a USD price."  Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cmpUsdPricePartNineteen" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtUsdPricePartNineteen" ErrorMessage="Please enter a decimal value."  Type="Currency" Operator="DataTypeCheck"  Display="Dynamic"></asp:CompareValidator>
                    </asp:TableCell>
                    <%-- CAD Price --%>
                    <asp:TableCell CssClass="tdInputPriceError" ColumnSpan="2">
                        <asp:RequiredFieldValidator ID="rfvCadPricePartNineteen" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtCadPricePartNineteen" ErrorMessage="Please enter a CAD price."  Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cmpCadPricePartNineteen" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtCadPricePartNineteen" ErrorMessage="Please enter a decimal value."  Type="Currency" Operator="DataTypeCheck"  Display="Dynamic"></asp:CompareValidator>
                    </asp:TableCell>
                </asp:TableRow> <%-- end validation rowPart19Val --%>
                <%-- end Schematic Part 19 --%>

                <%-- Schematic Part 20 --%>
                <asp:TableRow ID="rowPart20" CssClass="trPriceSchem">
                    <asp:TableCell CssClass="tdLabel">
                        <asp:Label ID="lblPartTwenty" CssClass="lblField" runat="server" Text="Part Key 20:"></asp:Label>
                    </asp:TableCell>
                    <%-- US Price --%>
                    <asp:TableCell CssClass="tdLabelPriceSchem">
                        <asp:Label ID="lblUsdPricePartTwenty" CssClass="lblField" runat="server" Text="US Price:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdInputTxt">
                        <asp:TextBox ID="txtUsdPricePartTwenty" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="81"></asp:TextBox>
                    </asp:TableCell>
                    <%-- CAD Price --%>
                    <asp:TableCell CssClass="tdLabel">
                        <asp:Label ID="lblCadPricePartTwenty" CssClass="lblField" runat="server" Text="Canada Price:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdInputTxt">
                        <asp:TextBox ID="txtCadPricePartTwenty" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="82"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdSchemLast">&nbsp;</asp:TableCell>
                </asp:TableRow> <%-- end rowPart20 --%>

                <%-- Validation Schematic Part 20 --%>
                <asp:TableRow ID="rowPart20Val" CssClass="trPriceSchem">
                    <%-- US Price --%>
                    <asp:TableCell CssClass="tdInputPriceError" ColumnSpan="3">
                        <asp:RequiredFieldValidator ID="rfvUsdPricePartTwenty" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtUsdPricePartTwenty" ErrorMessage="Please enter a USD price."  Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cmpUsdPricePartTwenty" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtUsdPricePartTwenty" ErrorMessage="Please enter a decimal value."  Type="Currency" Operator="DataTypeCheck"  Display="Dynamic"></asp:CompareValidator>
                    </asp:TableCell>
                    <%-- CAD Price --%>
                    <asp:TableCell CssClass="tdInputPriceError" ColumnSpan="2">
                        <asp:RequiredFieldValidator ID="rfvCadPricePartTwenty" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtCadPricePartTwenty" ErrorMessage="Please enter a CAD price."  Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cmpCadPricePartTwenty" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtCadPricePartTwenty" ErrorMessage="Please enter a decimal value."  Type="Currency" Operator="DataTypeCheck"  Display="Dynamic"></asp:CompareValidator>
                    </asp:TableCell>
                </asp:TableRow> <%-- end validation rowPart21 --%>
                <%-- end Schematic Part 20 --%>

                <%-- Schematic Part 21 --%>
                <asp:TableRow ID="rowPart21" CssClass="trPriceSchem">
                    <asp:TableCell CssClass="tdLabel">
                        <asp:Label ID="lblPartTwentyOne" CssClass="lblField" runat="server" Text="Part Key 21:"></asp:Label>
                    </asp:TableCell>
                    <%-- US Price --%>
                    <asp:TableCell CssClass="tdLabelPriceSchem">
                        <asp:Label ID="lblUsdPricePartTwentyOne" CssClass="lblField" runat="server" Text="US Price:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdInputTxt">
                        <asp:TextBox ID="txtUsdPricePartTwentyOne" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="83"></asp:TextBox>
                    </asp:TableCell>
                    <%-- CAD Price --%>
                    <asp:TableCell CssClass="tdLabel">
                        <asp:Label ID="lblCadPricePartTwentyOne" CssClass="lblField" runat="server" Text="Canada Price:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdInputTxt">
                        <asp:TextBox ID="txtCadPricePartTwentyOne" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="84"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdSchemLast">&nbsp;</asp:TableCell>
                </asp:TableRow> <%-- end rowPart21 --%>

                <%-- Validation Schematic Part 21 --%>
                <asp:TableRow ID="rowPart21Val" CssClass="trPriceSchem">
                    <%-- US Price --%>
                    <asp:TableCell CssClass="tdInputPriceError" ColumnSpan="3">
                        <asp:RequiredFieldValidator ID="rfvUsdPricePartTwentyOne" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtUsdPricePartTwentyOne" ErrorMessage="Please enter a USD price."  Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cmpUsdPricePartTwentyOne" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtUsdPricePartTwentyOne" ErrorMessage="Please enter a decimal value."  Type="Currency" Operator="DataTypeCheck"  Display="Dynamic"></asp:CompareValidator>
                    </asp:TableCell>
                    <%-- CAD Price --%>
                    <asp:TableCell CssClass="tdInputPriceError" ColumnSpan="2">
                        <asp:RequiredFieldValidator ID="rfvCadPricePartTwentyOne" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtCadPricePartTwentyOne" ErrorMessage="Please enter a CAD price."  Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cmpCadPricePartTwentyOne" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtCadPricePartTwentyOne" ErrorMessage="Please enter a decimal value."  Type="Currency" Operator="DataTypeCheck"  Display="Dynamic"></asp:CompareValidator>
                    </asp:TableCell>
                </asp:TableRow> <%-- end validation rowPart21Val --%>
                <%-- end Schematic Part 21 --%>

                <%-- Schematic Part 22 --%>
                <asp:TableRow ID="rowPart22" CssClass="trPriceSchem">
                    <asp:TableCell CssClass="tdLabel">
                        <asp:Label ID="lblPartTwentyTwo" CssClass="lblField" runat="server" Text="Part Key 22:"></asp:Label>
                    </asp:TableCell>
                    <%-- US Price --%>
                    <asp:TableCell CssClass="tdLabelPriceSchem">
                        <asp:Label ID="lblUsdPricePartTwentyTwo" CssClass="lblField" runat="server" Text="US Price:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdInputTxt">
                        <asp:TextBox ID="txtUsdPricePartTwentyTwo" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="85"></asp:TextBox>
                    </asp:TableCell>
                    <%-- CAD Price --%>
                    <asp:TableCell CssClass="tdLabel">
                        <asp:Label ID="lblCadPricePartTwentyTwo" CssClass="lblField" runat="server" Text="Canada Price:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdInputTxt">
                        <asp:TextBox ID="txtCadPricePartTwentyTwo" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="86"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdSchemLast">&nbsp;</asp:TableCell>
                </asp:TableRow> <%-- end rowPart22 --%>

                <%-- Validation Schematic Part 22 --%>
                <asp:TableRow ID="rowPart22Val" CssClass="trPriceSchem">
                    <%-- US Price --%>
                    <asp:TableCell CssClass="tdInputPriceError" ColumnSpan="3">
                        <asp:RequiredFieldValidator ID="rfvUsdPricePartTwentyTwo" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtUsdPricePartTwentyTwo" ErrorMessage="Please enter a USD price."  Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cmpUsdPricePartTwentyTwo" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtUsdPricePartTwentyTwo" ErrorMessage="Please enter a decimal value."  Type="Currency" Operator="DataTypeCheck"  Display="Dynamic"></asp:CompareValidator>
                    </asp:TableCell>
                    <%-- CAD Price --%>
                    <asp:TableCell CssClass="tdInputPriceError" ColumnSpan="2">
                        <asp:RequiredFieldValidator ID="rfvCadPricePartTwentyTwo" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtCadPricePartTwentyTwo" ErrorMessage="Please enter a CAD price."  Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cmpCadPricePartTwentyTwo" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtCadPricePartTwentyTwo" ErrorMessage="Please enter a decimal value."  Type="Currency" Operator="DataTypeCheck"  Display="Dynamic"></asp:CompareValidator>
                    </asp:TableCell>
                </asp:TableRow> <%-- end validation rowPart22Val --%>
                <%-- end Schematic Part 22 --%>

                <%-- Schematic Part 23 --%>
                <asp:TableRow ID="rowPart23" CssClass="trPriceSchem">
                    <asp:TableCell CssClass="tdLabel">
                        <asp:Label ID="lblPartTwentyThree" CssClass="lblField" runat="server" Text="Part Key 23:"></asp:Label>
                    </asp:TableCell>
                    <%-- US Price --%>
                    <asp:TableCell CssClass="tdLabelPriceSchem">
                        <asp:Label ID="lblUsdPricePartTwentyThree" CssClass="lblField" runat="server" Text="US Price:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdInputTxt">
                        <asp:TextBox ID="txtUsdPricePartTwentyThree" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="87"></asp:TextBox>
                    </asp:TableCell>
                    <%-- CAD Price --%>
                    <asp:TableCell CssClass="tdLabel">
                        <asp:Label ID="lblCadPricePartTwentyThree" CssClass="lblField" runat="server" Text="Canada Price:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdInputTxt">
                        <asp:TextBox ID="txtCadPricePartTwentyThree" CssClass="txtInputField" runat="server" Height="20" Width="70" TabIndex="88"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdSchemLast">&nbsp;</asp:TableCell>
                </asp:TableRow> <%-- end rowPart23 --%>

                <%-- Validation Schematic Part 23 --%>
                <asp:TableRow ID="rowPart23Val" CssClass="trPriceSchem">
                    <%-- US Price --%>
                    <asp:TableCell CssClass="tdInputPriceError" ColumnSpan="3">
                        <asp:RequiredFieldValidator ID="rfvUsdPricePartTwentyThree" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtUsdPricePartTwentyThree" ErrorMessage="Please enter a USD price."  Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cmpUsdPricePartTwentyThree" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtUsdPricePartTwentyThree" ErrorMessage="Please enter a decimal value."  Type="Currency" Operator="DataTypeCheck"  Display="Dynamic"></asp:CompareValidator>

                    </asp:TableCell>
                    <%-- CAD Price --%>
                    <asp:TableCell CssClass="tdInputPriceError" ColumnSpan="2">
                        <asp:RequiredFieldValidator ID="rfvCadPricePartTwentyThree" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtCadPricePartTwentyThree" ErrorMessage="Please enter a CAD price."  Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cmpCadPricePartTwentyThree" CssClass="errorMsgPrice" runat="server" ControlToValidate="txtCadPricePartTwentyThree" ErrorMessage="Please enter a decimal value."  Type="Currency" Operator="DataTypeCheck"  Display="Dynamic"></asp:CompareValidator>
                    </asp:TableCell>
                </asp:TableRow> <%-- end validation rowPart23Val --%>
                <%-- end Schematic Part 23 --%>

            </asp:Table> <!-- end pricingTable -->
        </div> <!-- end contentWrapper -->
    </asp:Panel> <!-- end pnlPricing -->

    <!-- STATUS PANEL -->
    <asp:Panel ID="pnlStatus" runat="server" CssClass="pnlStatus">
        <div class="contentWrapper">
            <h2>Status</h2>
            <asp:Table ID="statusTable" CssClass="statusTable" runat="server">
                <asp:TableRow ID="rowStatus">
                    <asp:TableCell CssClass="tdLabel">&nbsp;</asp:TableCell>
                    <asp:TableCell CssClass="tdInputRadio">
                        <asp:RadioButton ID="radActive" runat="server" GroupName="status" TabIndex="89" />
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdLabelRadio">
                        <asp:Label ID="lblActive" CssClass="lblField" runat="server" Text="Active"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdInputRadio">
                        <asp:RadioButton ID="radInactive" runat="server" GroupName="status" TabIndex="90" />   
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdLabelRadio">
                        <asp:Label ID="lblInactive" CssClass="lblField" runat="server" Text="Inactive"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table> <!-- end statusTable -->
        </div> <!-- end contentWrapper -->
    </asp:Panel> <!-- end pnlStatus -->

    <!-- BUTTONS PANEL -->
    <asp:Panel ID="pnlButtons" runat="server" CssClass="pnlButtons">
        <div class="contentWrapper">
            <div class="containerButtons">
                <asp:Button ID="btnUpdate" runat="server" Text="Update" Height="30" Width="125" OnClick="btnUpdate_Click" TabIndex="92" CausesValidation="False" />
                <asp:Button ID="btnReset" runat="server" Text="Reset Changes" Height="30" Width="125" CausesValidation="False" OnClick="btnReset_Click" TabIndex="91" />              
            </div>
            <br class="clear" />
        </div> <!-- end contentWrapper -->
    </asp:Panel> <!-- end pnlButtons -->



    <script type="text/javascript">
        window.onload = function() {
            //alert("update load");
            //document.body.addEventListener("click", reload);
            var upload = document.getElementById("MainContent_btnUploadImg");
            //upload.addEventListener("click", reload);
        }

        function reload() {
            window.location.reload();
            //alert("update reload");
        }
    </script>

</asp:Content>



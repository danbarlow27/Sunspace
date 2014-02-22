<%@ Page Title="Sunspace | Update Catalogue" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GlobalUpdate.aspx.cs" Inherits="SunspaceDealerDesktop.GlobalUpdate" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <link href="/content/Components.css" rel="stylesheet" type="text/css" />
    <asp:SqlDataSource ID="datSelectDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:sunspaceDealerDesktopConnectionString %>" SelectCommand="SELECT * FROM [acrylic_panels]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="datDisplayDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:sunspaceDealerDesktopConnectionString %>" SelectCommand="SELECT * FROM [acrylic_panels]"></asp:SqlDataSource>

    <br class="clear">
    
    <div class="containerGlobalUpdate">
        <div class="contentWrapper">
            
            <!-- NAVIGATION -->
            <div class="containerNavigation">

                <asp:Button ID="btnMainMenu" CssClass="float-right" runat="server" Text="Main Menu" CausesValidation="False" Height="27px" Width="105px" OnClick="btnMainMenu_Click"/>
                <asp:DropDownList ID="ddlCategory" CssClass="ddlField" runat="server" Height="27" Width="200" TabIndex="4" OnSelectedIndexChanged="ddlTables_SelectedIndexChanged" AutoPostBack="True" Visible="True">
                </asp:DropDownList>
            </div> <!-- end .containerNavigation -->

            <!-- RADIO SELECTIONS -->
            <div class="containerRadioPricing">
                <asp:RadioButtonList ID="radIncreaseDecrease" CssClass="radIncreaseDecrease" runat="server" OnSelectedIndexChanged="radIncreaseDecrease_OnSelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem>Price Increase</asp:ListItem>
                    <asp:ListItem>Price Decrease</asp:ListItem>
                </asp:RadioButtonList>

                <asp:RadioButtonList ID="radPercentDollar" CssClass="radPercentDollar" runat="server" OnSelectedIndexChanged="radPercentDollar_OnSelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem>Increase/Decrease by %</asp:ListItem>
                    <asp:ListItem>Increase/Decrease by $ Amount</asp:ListItem>
                </asp:RadioButtonList>
            </div>

            <!-- PRICING TABLE -->
            <asp:Table ID="tblPriceGrid" runat="server" CellSpacing="0" CellPadding="0">                
                <%--Header Row --%>
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>&nbsp;</asp:TableHeaderCell>
                    <asp:TableHeaderCell>
                        <asp:Label ID="lblHeaderPartNum" runat="server" Text="Part Number"></asp:Label>
                    </asp:TableHeaderCell>
                    <asp:TableHeaderCell>
                        <asp:Label ID="lblHeaderPartName" runat="server" Text="Part Name"></asp:Label>
                    </asp:TableHeaderCell>
                    <asp:TableHeaderCell ColumnSpan="2">
                        <asp:Label ID="lblHeaderCurrentPrice" runat="server" Text="Current Price"></asp:Label>
                    </asp:TableHeaderCell>
                    <asp:TableHeaderCell ColumnSpan="2" Wrap="false">
                        <asp:Label ID="lblHeaderPriceAdjust" runat="server" ></asp:Label>
                    </asp:TableHeaderCell>
                    <asp:TableHeaderCell ColumnSpan="2">
                        <asp:Label ID="lblHeaderNewPrice" runat="server" Text="New Price"></asp:Label>
                    </asp:TableHeaderCell>
                </asp:TableHeaderRow>

                <%-- Header Row - US/CAN Labels --%>
                <asp:TableRow CssClass="trHeader">
                    <asp:TableCell>&nbsp;</asp:TableCell>
                    <asp:TableCell>&nbsp;</asp:TableCell>
                    <asp:TableCell>&nbsp;</asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="lblHeaderCurrentPriceUS" runat="server" Text="$US"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="lblHeaderCurrentPriceCAN" runat="server" Text="$CAN"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="lblHeaderPriceAdjustUS" runat="server" Text="$US"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="lblHeaderPriceAdjustCAN" runat="server" Text="$CAN"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="lblHeaderNewPriceUS" runat="server" Text="$US"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="lblHeaderNewPriceCAN" runat="server" Text="$CAN"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>

                <%-- Apply to Selected Row --%>
                <asp:TableRow CssClass="trSelected">
                    <asp:TableCell>
                        <asp:CheckBox ID="chkApplyToSelected" runat="server" />
                    </asp:TableCell>
                    <asp:TableCell ColumnSpan="2">
                        <asp:Label ID="lblApplyToSelected" runat="server" Text="Apply to Selected"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell>
                    <asp:TableCell >
                        <asp:TextBox ID="txtPriceAdjustUS" CssClass="txtInputField" runat="server" Height="20" Width="70"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell >
                        <asp:TextBox ID="txtPriceAdjustCAN" CssClass="txtInputField" runat="server" Height="20" Width="70"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell>
                </asp:TableRow>

                <%-- Select All Checkbox Row --%>
                <asp:TableRow CssClass="trSelectAll">
                    <asp:TableCell>
                        <asp:CheckBox ID="chkSelectAll" runat="server" OnCheckedChanged="chkSelectAll_OnCheckedChanged" AutoPostBack="true"/>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="lblSelectAll" runat="server" Text="Select All"></asp:Label>
                    </asp:TableCell>                    
                </asp:TableRow>

                <%-- Product Rows 
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:CheckBox ID="chkProduct" runat="server" />
                    </asp:TableCell>
                    <asp:TableCell Wrap="False">
                        <asp:Label ID="lblPartNum" runat="server" Text="Part Number" ></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="lblPartName" runat="server" Text="Part Name"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="align-center" Wrap="False">
                        <asp:Label ID="lblCurrentPriceUS" runat="server" Text="US Price"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="align-center" Wrap="False">
                        <asp:Label ID="lblCurrentPriceCAN" runat="server" Text="Can Price"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdTxtInputUS">
                        <asp:TextBox ID="txtPriceAdjustUSEach" CssClass="txtInputField" runat="server" Height="20" Width="70"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdTxtInputCAN">
                        <asp:TextBox ID="txtPriceAdjustCANEach" CssClass="txtInputField" runat="server" Height="20" Width="70"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdTxtInputUS">
                        <asp:TextBox ID="txtNewPriceUS" CssClass="txtInputField" runat="server" Height="20" Width="70"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdTxtInputCAN">
                        <asp:TextBox ID="txtNewPriceCAN" CssClass="txtInputField" runat="server" Height="20" Width="70"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>



                <asp:TableRow>
                    <asp:TableCell>
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                    </asp:TableCell>
                    <asp:TableCell Wrap="False">
                        <asp:Label ID="Label1" runat="server" Text="Part Number" ></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="Label2" runat="server" Text="Part Name"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="align-center" Wrap="False">
                        <asp:Label ID="Label3" runat="server" Text="US Price"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="align-center" Wrap="False">
                        <asp:Label ID="Label4" runat="server" Text="Can Price"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdTxtInputUS">
                        <asp:TextBox ID="TextBox1" CssClass="txtInputField" runat="server" Height="20" Width="70"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdTxtInputCAN">
                        <asp:TextBox ID="TextBox2" CssClass="txtInputField" runat="server" Height="20" Width="70"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdTxtInputUS">
                        <asp:TextBox ID="TextBox3" CssClass="txtInputField" runat="server" Height="20" Width="70"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdTxtInputCAN">
                        <asp:TextBox ID="TextBox4" CssClass="txtInputField" runat="server" Height="20" Width="70"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow>
                    <asp:TableCell>
                        <asp:CheckBox ID="CheckBox2" runat="server" />
                    </asp:TableCell>
                    <asp:TableCell Wrap="False">
                        <asp:Label ID="Label5" runat="server" Text="Part Number" ></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="Label6" runat="server" Text="Part Name"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="align-center" Wrap="False">
                        <asp:Label ID="Label7" runat="server" Text="US Price"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="align-center" Wrap="False">
                        <asp:Label ID="Label8" runat="server" Text="Can Price"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdTxtInputUS">
                        <asp:TextBox ID="TextBox5" CssClass="txtInputField" runat="server" Height="20" Width="70"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdTxtInputCAN">
                        <asp:TextBox ID="TextBox6" CssClass="txtInputField" runat="server" Height="20" Width="70"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdTxtInputUS">
                        <asp:TextBox ID="TextBox7" CssClass="txtInputField" runat="server" Height="20" Width="70"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdTxtInputCAN">
                        <asp:TextBox ID="TextBox8" CssClass="txtInputField" runat="server" Height="20" Width="70"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow>
                    <asp:TableCell>
                        <asp:CheckBox ID="CheckBox3" runat="server" />
                    </asp:TableCell>
                    <asp:TableCell Wrap="False">
                        <asp:Label ID="Label9" runat="server" Text="Part Number" ></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="Label10" runat="server" Text="Part Name"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="align-center" Wrap="False">
                        <asp:Label ID="Label11" runat="server" Text="US Price"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="align-center" Wrap="False">
                        <asp:Label ID="Label12" runat="server" Text="Can Price"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdTxtInputUS">
                        <asp:TextBox ID="TextBox9" CssClass="txtInputField" runat="server" Height="20" Width="70"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdTxtInputCAN">
                        <asp:TextBox ID="TextBox10" CssClass="txtInputField" runat="server" Height="20" Width="70"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdTxtInputUS">
                        <asp:TextBox ID="TextBox11" CssClass="txtInputField" runat="server" Height="20" Width="70"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tdTxtInputCAN">
                        <asp:TextBox ID="TextBox12" CssClass="txtInputField" runat="server" Height="20" Width="70"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>--%>
            </asp:Table> <!-- end #tblPriceGrid -->

            <!-- BUTTONS -->
            <div class="containerButtonsPricing">
                <div class="containerButtons">
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" Height="30" Width="125" CausesValidation="False" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnPreview" runat="server" Text="Preview" Height="30" Width="125" CausesValidation="False" OnClick="btnPreview_Click" />
                    <asp:Button ID="btnReset" runat="server" Text="Reset Changes" Height="30" Width="125" CausesValidation="False"/>   
                </div>           
                <br class="clear" />
            </div> <!-- end containerButtonsPricing -->

        </div> <!-- end .contentWrapper -->
    </div> <!-- end .containerGlobalUpdate -->

</asp:Content>
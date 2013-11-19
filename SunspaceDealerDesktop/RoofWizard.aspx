<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RoofWizard.aspx.cs" Inherits="SunspaceDealerDesktop.RoofWizard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        function roofWizardCheckQuestion1() {
            if ($('#<%=radTraditional.ClientID%>').is(':checked') || $('#<%=radAcrylic.ClientID%>').is(':checked')) {
                document.getElementById('<%=btnQuestion1.ClientID%>').disabled = false;
            }

            if ($('#<%=radTraditional.ClientID%>').is(':checked')) {
                document.getElementById('<%=hidSystem.ClientID%>').value = "Traditional";
                document.getElementById('<%=hidThickness.ClientID%>').value = $('#<%=ddlThickness.ClientID%>').val();
                document.getElementById('<%=hidAcrylicColour.ClientID%>').value = "";
                document.getElementById('<%=hidStripeColour.ClientID%>').value = $('#<%=ddlStripeColour.ClientID%>').val();
                $('#<%=btnQuestion2.ClientID%>').show();
                $('#<%=btnQuestion2SkipNext.ClientID%>').hide();
            }
            else if ($('#<%=radAcrylic.ClientID%>').is(':checked')) {
                document.getElementById('<%=hidSystem.ClientID%>').value = "Acrylic";
                document.getElementById('<%=hidAcrylicColour.ClientID%>').value = $('#<%=ddlAcrylicColour.ClientID%>').val();
                document.getElementById('<%=hidThickness.ClientID%>').value = $('#<%=ddlAcrylicThickness.ClientID%>').val();
                $('#<%=btnQuestion2.ClientID%>').hide();
                $('#<%=btnQuestion2SkipNext.ClientID%>').show();
            }
            else {
                document.getElementById('<%=hidSystem.ClientID%>').value = "Thermadeck";
                document.getElementById('<%=hidAcrylicColour.ClientID%>').value = "";
                document.getElementById('<%=hidThickness.ClientID%>').value = $('#<%=ddlThermadeckThickness.ClientID%>').val();
                $('#<%=btnQuestion2.ClientID%>').hide();
                $('#<%=btnQuestion2SkipNext.ClientID%>').show();

                document.getElementById('<%=btnQuestion2.ClientID%>').disabled = true;                    
                document.getElementById('<%=btnQuestion2SkipNext.ClientID%>').disabled = true;

                var confirmValid = true;
                var error = "";

                if ($('#<%=txtLedgerSetback.ClientID%>').val() != "") {
                    if (isNaN($('#<%=txtLedgerSetback.ClientID%>').val())) {
                        confirmValid = false;
                        error += "Your ledger setback is invalid. Please enter a valid number of inches.<br/>";
                    }
                    else {
                        document.getElementById('<%=hidLedgerSetback.ClientID%>').value = parseFloat(document.getElementById('<%=txtLedgerSetback.ClientID%>').value) + parseFloat(document.getElementById('<%=ddlLedgerSetbackInches.ClientID%>').value);
                    }
                }
                else {
                    error += "Your ledger setback is empty. Please enter a ledger setback.<br/>";
                }

                if ($('#<%=txtFrontSetback.ClientID%>').val() != "") {
                    if (isNaN($('#<%=txtFrontSetback.ClientID%>').val())) {
                        confirmValid = false;
                        error += "Your front setback is invalid. Please enter a valid number of inches.<br/>";
                    }
                    else {
                        document.getElementById('<%=hidFrontSetback.ClientID%>').value = parseFloat(document.getElementById('<%=txtFrontSetback.ClientID%>').value) + parseFloat(document.getElementById('<%=ddlFrontSetbackInches.ClientID%>').value);
                    }
                }
                else {
                    error += "Your front setback is empty. Please enter a front setback.<br/>";
                }

                if ($('#<%=txtSidesSetback.ClientID%>').val() != "") {
                    if (isNaN($('#<%=txtSidesSetback.ClientID%>').val())) {
                        confirmValid = false;
                        error += "Your sides setback is invalid. Please enter a valid number of inches.<br/>";
                    }
                    else {
                        document.getElementById('<%=hidSidesSetback.ClientID%>').value = parseFloat(document.getElementById('<%=txtSidesSetback.ClientID%>').value) + parseFloat(document.getElementById('<%=ddlSidesSetbackInches.ClientID%>').value);                    }
                }
                else {
                    error += "Your side setbacks are empty. Please enter side setbacks.<br/>";
                }

                if ($('#<%=txtJointSetback.ClientID%>').val() != "") {
                    if (isNaN($('#<%=txtJointSetback.ClientID%>').val())) {
                        confirmValid = false;
                        error += "Your joint setback is invalid. Please enter a valid number of inches.<br/>";
                    }
                    else {
                        document.getElementById('<%=hidJointSetback.ClientID%>').value = parseFloat(document.getElementById('<%=txtJointSetback.ClientID%>').value) + parseFloat(document.getElementById('<%=ddlJointSetbackInches.ClientID%>').value);
                    }
                }
                else {
                    error += "Your joint setback is empty. Please enter a joint setback.<br/>";
                }

                if (confirmValid == true) {
                    document.getElementById('<%=btnQuestion2.ClientID%>').disabled = false;                    
                    document.getElementById('<%=btnQuestion2SkipNext.ClientID%>').disabled = false;
                }
                else {
                    document.getElementById('<%=lblPagerSetbackAnswer.ClientID%>').innerHTML = error;
                }
            }
        }

        function roofWizardCheckQuestion2() {
            var maxProjection;

            if ($('#<%=radTraditional.ClientID%>').is(':checked')) {
                maxProjection = <%= FOAM_PANEL_PROJECTION %>;
            }
            else if ($('#<%=radAcrylic.ClientID%>').is(':checked')) {
                maxProjection = <%= ACRYLIC_PANEL_PROJECTION %>;
            }
            else {
                maxProjection = <%= THERMADECK_PANEL_PROJECTION %>;
            }

            if ($('#<%=txtOverhangLength.ClientID%>').val() == "") {
                //please enter a valid number
                document.getElementById('<%=btnQuestion2.ClientID%>').disabled = true;
                document.getElementById('<%=btnQuestion2SkipNext.ClientID%>').disabled = true;
            }
            else if (isNaN($('#<%=txtOverhangLength.ClientID%>').val())) {
                //please enter a valid number
                document.getElementById('<%=btnQuestion2.ClientID%>').disabled = true;
                document.getElementById('<%=btnQuestion2SkipNext.ClientID%>').disabled = true;
            }
            else {
                document.getElementById('<%=btnQuestion2.ClientID%>').disabled = false;
                document.getElementById('<%=btnQuestion2SkipNext.ClientID%>').disabled = false;
            }

            document.getElementById("<%=hidOverhang.ClientID%>").value = parseFloat($('#<%=txtOverhangLength.ClientID%>').val()) + parseFloat($('#<%=ddlOverhangInches.ClientID%>').val());
        }

        function roofWizardCheckQuestion3() {
            //move to hidden interior/exterior
            document.getElementById("<%=hidPanelType.ClientID%>").value = $('#<%=ddlPanelType.ClientID%>').val();
            document.getElementById("<%=hidInteriorRoofSkin.ClientID%>").value = $('#<%=ddlInteriorRoofSkin.ClientID%>').val();
            document.getElementById("<%=hidExteriorRoofSkin.ClientID%>").value = $('#<%=ddlExteriorRoofSkin.ClientID%>').val();
        }

        function roofWizardCheckQuestion4() {
            document.getElementById("<%=hidGutterColour.ClientID%>").value = $('#<%=ddlGutterColour.ClientID%>').val();

            if ($('#<%=radGutterPresenceYes.ClientID%>').is(':checked')) {
                document.getElementById("<%=hidGutterPresence.ClientID%>").value = "Yes";
            }
            else {
                document.getElementById("<%=hidGutterPresence.ClientID%>").value = "No";
            }

            if ($('#<%=chkGutterRemove.ClientID%>').is(':checked')) {
                document.getElementById("<%=hidGutterRemove.ClientID%>").value = "Yes";
            }
            else {
                document.getElementById("<%=hidGutterRemove.ClientID%>").value = "No";
            }

            if ($('#<%=chkGutterPro.ClientID%>').is(':checked')) {
                document.getElementById("<%=hidGutterPro.ClientID%>").value = "Yes";
            }
            else {
                document.getElementById("<%=hidGutterPro.ClientID%>").value = "No";
            }
            
            document.getElementById("<%=hidExtraDownspouts.ClientID%>").value = $('#<%=ddlExtraDownspouts.ClientID%>').val();
        }
    </script>

    <div class="slide-window"  >
        <div class="slide-wrapper"> 
            <%-- Slide 1 - System Type --%>
            <div id="slide1" class="slide">
                <h1>
                    <asp:Label ID="lblType" runat="server" Text="What type of roof system would you like?"></asp:Label>
                </h1>

                <ul class="toggleOptions">
                    <li>
                        <asp:RadioButton ID="radTraditional" GroupName="question1" runat="server" OnClick="roofWizardCheckQuestion1()" />
                        <asp:Label ID="lblTraditionalRadio" AssociatedControlID="radTraditional" runat="server"></asp:Label>
                        <asp:Label ID="lblTraditional" AssociatedControlID="radTraditional" runat="server" Text="Alum. Skin or O.S.B."></asp:Label>

                        <%--Traditional-Only Options --%>
                        <div class="toggleContent">
                            <ul>
                                <li>
                                    <asp:Label ID="lblThickness" runat="server" Text="Panel Thickness:"></asp:Label>
                                    <asp:DropDownList ID="ddlThickness" runat="server" OnChange="roofWizardCheckQuestion1()"></asp:DropDownList>
                                </li>
                                <li>
                                    <asp:Label ID="lblStripeColour" runat="server" Text="Stripe Colour:"></asp:Label>
                                    <asp:DropDownList ID="ddlStripeColour" runat="server" OnChange="roofWizardCheckQuestion1()"></asp:DropDownList>
                                </li>
                            </ul>
                        </div>
                    </li>
                    <li>
                        <asp:RadioButton ID="radAcrylic" GroupName="question1" runat="server" OnClick="roofWizardCheckQuestion1()" />
                        <asp:Label ID="lblAcrylicRadio" AssociatedControlID="radAcrylic" runat="server"></asp:Label>
                        <asp:Label ID="lblAcrylic" AssociatedControlID="radAcrylic" runat="server" Text="Acrylic T-Bar System"></asp:Label>
                        
                        <%--Acrylic-Only Options --%>
                        <div class="toggleContent">
                            <ul>
                                <li>
                                    <asp:Label ID="lblAcrylicThickness" runat="server" Text="Panel Thickness:"></asp:Label>
                                    <asp:DropDownList ID="ddlAcrylicThickness" runat="server" OnChange="roofWizardCheckQuestion1()"></asp:DropDownList>
                                </li>
                                <li>
                                    <asp:Label ID="lblAcrylicColour" runat="server" Text="Acrylic Colour:"></asp:Label>
                                    <asp:DropDownList ID="ddlAcrylicColour" runat="server" OnChange ="roofWizardCheckQuestion1()"></asp:DropDownList>
                                </li>
                            </ul>
                        </div>
                    </li>
                    <li>
                        <asp:RadioButton ID="radThermadeck" GroupName="question1" runat="server" OnClick="roofWizardCheckQuestion1()" />
                        <asp:Label ID="lblThermadeckRadio" AssociatedControlID="radThermadeck" runat="server"></asp:Label>
                        <asp:Label ID="lblThermadeck" AssociatedControlID="radThermadeck" runat="server" Text="Thermadeck System"></asp:Label>

                        <%--Thermadeck-only options --%>
                        <div class="toggleContent">
                            <ul>
                                <li>
                                    <asp:CheckBox ID="chkBarrier" runat="server" OnClick="roofWizardCheckQuestion1()" />
                                    <asp:Label ID="lblBarrierCheck" runat="server" AssociatedControlID="chkBarrier"></asp:Label>
                                    <asp:Label ID="lblBarrier" runat="server" AssociatedControlID="chkBarrier" Text="Metal Vapour Barrier" ToolTip="A metal vapour barrier in a thermadeck system has increased fire protection."></asp:Label>
                                </li>
                                <li>
                                    <asp:Label ID="lblThermadeckThickness" runat="server" Text="Panel Thickness:"></asp:Label>
                                    <asp:DropDownList ID="ddlThermadeckThickness" runat="server" OnChange="roofWizardCheckQuestion1()"></asp:DropDownList>
                                </li>
                                <li>
                                    <asp:Table ID="tblSetback" CssClass="tblTxtFields" runat="server">
                                        <asp:TableRow style="display:inherit">
                                            <asp:TableCell>
                                                <asp:Label ID="lblLedger" Text="Ledger: " runat="server"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:TextBox ID="txtLedgerSetback" onkeyup="roofWizardCheckQuestion1()" runat="server"></asp:TextBox>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:DropDownList ID="ddlLedgerSetbackInches" OnChange="roofWizardCheckQuestion1()" runat="server"></asp:DropDownList>
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow style="display:inherit">
                                            <asp:TableCell>
                                                <asp:Label ID="lblFront" Text="Front: " runat="server"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:TextBox ID="txtFrontSetback" onkeyup="roofWizardCheckQuestion1()" runat="server"></asp:TextBox>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:DropDownList ID="ddlFrontSetbackInches" OnChange="roofWizardCheckQuestion1()" runat="server"></asp:DropDownList>
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow style="display:inherit">
                                            <asp:TableCell>
                                                <asp:Label ID="lblSides" Text="Sides: " runat="server"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:TextBox ID="txtSidesSetback" onkeyup="roofWizardCheckQuestion1()" runat="server"></asp:TextBox>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:DropDownList ID="ddlSidesSetbackInches" OnChange="roofWizardCheckQuestion1()" runat="server"></asp:DropDownList>
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow style="display:inherit">
                                            <asp:TableCell>
                                                <asp:Label ID="lblJoint" Text="Joint: " runat="server"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:TextBox ID="txtJointSetback" onkeyup="roofWizardCheckQuestion1()" runat="server"></asp:TextBox>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:DropDownList ID="ddlJointSetbackInches" OnChange="roofWizardCheckQuestion1()" runat="server"></asp:DropDownList>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                    </asp:Table>
                                </li>
                            </ul>
                        </div>
                    </li>
                </ul>
                
                <asp:Button ID="btnQuestion1" CssClass="btnSubmit float-right slidePanel" data-slide="#slide2" runat="server" Text="Next Question" Enabled="false" />
            </div>

            <%-- Slide 2 - Dimensions & Overhang --%>           
            <div id="slide2" class="slide">
                <h1>
                    <asp:Label ID="lblQuestion1" runat="server" Text="Please enter your roof overhang."></asp:Label>
                </h1>        
                              
                <ul class="toggleOptions">
                    <li>                                
                        <asp:Label ID="lblOverhangLength" runat="server" Text="Overhang Length"></asp:Label>
                        <asp:TextBox ID="txtOverhangLength" runat="server" onkeydown="return (event.keyCode!=13);" onkeyup="roofWizardCheckQuestion2()"></asp:TextBox>
                        <asp:DropDownList ID="ddlOverhangInches" runat="server" OnChange="roofWizardCheckQuestion2()" ></asp:DropDownList>
                        <br />
                        <asp:Label ID="lblOverhangWarning" runat="server" Text="Enter 0 for no overhang"></asp:Label>
                    </li>
                </ul>

                <asp:Button ID="btnQuestion2" CssClass="btnSubmit float-right slidePanel" data-slide="#slide3" runat="server" Text="Next Question" Enabled="false" />
                <asp:Button ID="btnQuestion2SkipNext" CssClass="btnSubmit float-right slidePanel" data-Slide="#slide4" runat="server" Text="Next Question"  Enabled="false" />
            </div>            

            <%-- Slide 3 - Select a Skin --%>
            <div id="slide3" class="slide">
                <h1>
                    <asp:Label ID="lblSkins" runat="server" Text="Select roof skins"></asp:Label>
                </h1>

                <ul class="toggleOptions">
                    <li>
                        <asp:Label ID="lblPanelType" runat="server" Text="Panel Type:"></asp:Label>
                        <asp:DropDownList ID="ddlPanelType" runat="server" OnChange="roofWizardCheckQuestion3()"></asp:DropDownList>
                    </li>
                    <li>
                        <asp:Label ID="lblInteriorRoofSkin" runat="server" Text="Interior Skin:"></asp:Label>
                        <asp:DropDownList ID="ddlInteriorRoofSkin" runat="server" OnChange="roofWizardCheckQuestion3()"></asp:DropDownList>
                    </li>
                    <li>
                        <asp:Label ID="lblExteriorRoofSkin" runat="server" Text="Exterior Skin:"></asp:Label>
                        <asp:DropDownList ID="ddlExteriorRoofSkin" runat="server" OnChange="roofWizardCheckQuestion3()"></asp:DropDownList>
                    </li>
                </ul>

                <asp:Button ID="btnQuestion3" CssClass="btnSubmit float-right slidePanel" data-slide="#slide4" runat="server" Text="Next Question" />
            </div>

            <%-- Slide 4 - Gutter --%>
            <div id="slide4" class="slide">
                <h1>
                    <asp:Label ID="lblGutterOptions" runat="server" Text="Would you like gutters?"></asp:Label>
                </h1>

                <ul class="toggleOptions">
                    <li>
                        <asp:Label ID="lblGutterColour" runat="server" Text="Gutter/Fascia Colour:"></asp:Label>
                        <asp:DropDownList ID="ddlGutterColour" runat="server" OnChange="roofWizardCheckQuestion4()"></asp:DropDownList>
                    </li>
                    <li>
                        <asp:RadioButton ID="radGutterPresenceYes" GroupName="question4" runat="server" OnClick="roofWizardCheckQuestion4()" />
                        <asp:Label ID="lblGutterPresenceYesRadio" AssociatedControlID="radGutterPresenceYes" runat="server"></asp:Label>
                        <asp:Label ID="lblGutterPresenceYes" AssociatedControlID="radGutterPresenceYes" runat="server" Text="Yes"></asp:Label>

                        <%--Gutter Options --%>
                        <div class="toggleContent">
                            <ul>
                                <li>
                                    <asp:CheckBox ID="chkGutterRemove" runat="server" OnClick="roofWizardCheckQuestion4()" />
                                    <asp:Label ID="lblGutterRemoveCheck" AssociatedControlID="chkGutterRemove" runat="server" ></asp:Label>
                                    <asp:Label ID="lblGutterRemove" AssociatedControlID="chkGutterRemove" runat="server" Text="Build into overhang" ToolTip="If checked, this will make the gutter inclusive in current roof dimensions, removing from overhang, rather than adding the dimensions of the gutter."></asp:Label>
                                </li>
                                <li>
                                    <asp:CheckBox ID="chkGutterPro" runat="server" OnClick="roofWizardCheckQuestion4()" />
                                    <asp:Label ID="lblGutterProCheck" AssociatedControlID="chkGutterPro" runat="server"></asp:Label>
                                    <asp:Label ID="lblGutterPro" AssociatedControlID="chkGutterPro" runat="server" Text="Gutter pro gutters" ToolTip="GutterPro is an addition to the gutter with the intent to keep out leaves and other blockage" ></asp:Label>
                                </li>
                                <li>
                                    <asp:Label ID="lblExtraDownspouts" runat="server" Text="Extra downspouts:"></asp:Label>
                                    <asp:DropDownList ID="ddlExtraDownspouts" runat="server" OnChange="roofWizardCheckQuestion4()" />
                                </li>
                            </ul>
                        </div>
                    </li>
                    <li>
                        <asp:RadioButton ID="radGutterPresenceNo" GroupName="question4" runat="server" OnClick="roofWizardCheckQuestion3()" />
                        <asp:Label ID="lblGutterPresenceNoRadio" AssociatedControlID="radGutterPresenceNo" runat="server"></asp:Label>
                        <asp:Label ID="lblGutterPresenceNo" AssociatedControlID="radGutterPresenceNo" runat="server" Text="No"></asp:Label>
                    </li>
                </ul>

                <asp:Button ID="btnFinalButton" CssClass="btnSubmit float-right slidePanel" runat="server" OnClick="btnFinalButton_Click" Text="Submit" />
            </div>
        </div>
    </div>
    
    <div id="sidebar">
        <div id="paging-wrapper">    
            <div id="paging"> 
                <h2>Floor Specifications</h2>

                <ul>
                    <%-- MINI CANVAS (HIGHLIGHTS CURRENT WALL)
                    ======================================== --%>
                    <div style="position:inherit; text-align:center; top:0px; right:0px;" id="mySunroom">

                    </div>
                    <div style="display: none" id="pagerOne">
                        <li>
                            <a href="#" data-slide="#slide1" class="slidePanel">
                                <asp:Label ID="lblPagerSquareFootage" runat="server" Text="Floor Square Footage"></asp:Label>
                                <asp:Label ID="lblPagerSquareFootageDisplay" runat="server" Text=""></asp:Label>
                            </a>
                        </li>
                    </div> 
                    
                    <div style="display: none" id="pagerTwo">
                        <li>
                            <a href="#" data-slide="#slide2" class="slidePanel">
                                <asp:Label ID="lblPagerSetbackAnswer" runat="server"></asp:Label>
                            </a>
                        </li>          
                    </div>                  
                </ul>    
            </div>    
        </div>
    </div>

    <input id="hidSystem" type="hidden" runat="server" />
    <input id="hidThickness" type="hidden" runat="server" />
    <input id="hidAcrylicColour" type="hidden" runat="server" />
    <input id="hidStripeColour" type="hidden" runat="server" />
    
    <input id="hidLedgerSetback" type="hidden" runat="server" />
    <input id="hidFrontSetback" type="hidden" runat="server" />
    <input id="hidSidesSetback" type="hidden" runat="server" />
    <input id="hidJointSetback" type="hidden" runat="server" />

    <input id="hidProjection" type="hidden" runat="server" />
    <input id="hidWidth" type="hidden" runat="server" />
    <input id="hidOverhang" type="hidden" runat="server" />
    
    <input id="hidPanelType" type="hidden" runat="server" />
    <input id="hidInteriorRoofSkin" type="hidden" runat="server" />
    <input id="hidExteriorRoofSkin" type="hidden" runat="server" />
    
    <input id="hidGutterColour" type="hidden" runat="server" />
    <input id="hidGutterPresence" type="hidden" runat="server" />
    <input id="hidGutterRemove" type="hidden" runat="server" />
    <input id="hidGutterPro" type="hidden" runat="server" />
    <input id="hidExtraDownspouts" type="hidden" runat="server" />
</asp:Content>

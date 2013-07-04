<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="SunspaceDealerDesktop.Home" %>

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
                                        
                                        <%-- Model 100 Preferences --%>
                                        <li>
                                            <asp:RadioButton ID="radSunroom100" GroupName="sunroomModels" runat="server" />
                                            <asp:Label ID="lblSunroom100Radio" AssociatedControlID="radSunroom100" runat="server"></asp:Label>
                                            <asp:Label ID="lblSunroom100" AssociatedControlID="radSunroom100" runat="server" Text="Model 100"></asp:Label>
                                    
                                            
                                            <%-- Model 100 Inputs --%>
                                            <div class="toggleContent">
                                                <ul>
                                                    <li>
                                                        <%-- Cut Pitch Option --%>
                                                        <asp:CheckBox ID="chk100Cut" runat="server" />
                                                        <asp:Label ID="lbl100CutCheck" AssociatedControlID="chk100Cut" runat="server"></asp:Label>
                                                        <asp:Label ID="lbl100Cut" AssociatedControlID="chk100Cut" runat="server" Text="Cut Pitch"></asp:Label>

                                                        <%-- Default Filler Option --%>
                                                        <asp:Label ID="lbl100DefaultFiller" runat="server" Text="Default Filler: "></asp:Label>
                                                        <asp:TextBox ID="txt100DefaultFiller" runat="server" CssClass="txtLengthInput"></asp:TextBox>
                                                        <asp:DropDownList ID="ddl100DefaultFiller" runat="server"></asp:DropDownList>



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

</asp:Content>

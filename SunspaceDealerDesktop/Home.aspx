<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="SunspaceDealerDesktop.Home" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div>
        <asp:Label Text ="Welcome " ID="lblWelcome" runat="server"></asp:Label>
        <asp:Label Text ="*Insert User Name*" ID="lblUser" runat="server"></asp:Label>
    </div>

    <div id="slide1" class="slide">

                <h1>
                    <asp:Label ID="lblPreferences" runat="server" Text="Set your preferences below"></asp:Label>
                </h1>        
                              
                <ul class="toggleOptions">

                    <%-- Sunroom Preferences --%>
                    <li>
                        <asp:RadioButton ID="radSunroomPref" GroupName="sunroomPreferences" runat="server" />
                        <asp:Label ID="lblSunroomPrefRadio" AssociatedControlID="radSunroomPref" runat="server"></asp:Label>
                        <asp:Label ID="lblSunroomPref" AssociatedControlID="radSunroomPref" runat="server" Text="Sunroom Preferences"></asp:Label>
           
                        <div class="toggleContent">
                            <ul>
                                <li>
                                    <asp:RadioButton ID="radSunroom100" GroupName="sunroomModels" runat="server" />
                                    <asp:Label ID="lblSunroom100Radio" AssociatedControlID="radSunroom100" runat="server"></asp:Label>
                                    <asp:Label ID="lblSunroom100" AssociatedControlID="radSunroom100" runat="server" Text="Model 100"></asp:Label>
                                        <div class="toggleContent">
                                        <ul class="toggleOptions">
                                            <li>
                                                <asp:Label ID="lbl100Input" runat="server" Text="Model 100 Input: "></asp:Label>
                                                <asp:TextBox ID="txt100Input" CssClass="txtField txtInput" runat="server"></asp:TextBox>
                                            </li>                                            
                                        </ul>
                                        </div>
                                </li>

                                <li>
                                    <asp:RadioButton ID="radSunroom200" GroupName="sunroomModels" runat="server" />
                                    <asp:Label ID="lblSunroom200Radio" AssociatedControlID="radSunroom200" runat="server"></asp:Label>
                                    <asp:Label ID="lblSunroom200" AssociatedControlID="radSunroom200" runat="server" Text="Model 200"></asp:Label>
                                </li>

                                <li>
                                    <asp:RadioButton ID="radSunroom300" GroupName="sunroomModels" runat="server" />
                                    <asp:Label ID="lblSunroom300Radio" AssociatedControlID="radSunroom300" runat="server"></asp:Label>
                                    <asp:Label ID="lblSunroom300" AssociatedControlID="radSunroom300" runat="server" Text="Model 300"></asp:Label>
                                </li>

                                <li>
                                    <asp:RadioButton ID="radSunroom400" GroupName="sunroomModels" runat="server" />
                                    <asp:Label ID="lblSunroom400Radio" AssociatedControlID="radSunroom400" runat="server"></asp:Label>
                                    <asp:Label ID="lblSunroom400" AssociatedControlID="radSunroom400" runat="server" Text="Model 400"></asp:Label>
                                </li>
                            </ul>
                        </div>
                    </li>
                </ul>

    </div>
</asp:Content>

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
                        <asp:RadioButton ID="radSunroomPref" GroupName="preferences" runat="server" />
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

                    <%-- Wall Preferences --%>
                    <li>
                        <asp:RadioButton ID="radWallsPref" GroupName="preferences" runat="server" />
                        <asp:Label ID="lblWallsPrefRadio" AssociatedControlID="radWallsPref" runat="server"></asp:Label>
                        <asp:Label ID="lblWallsPref" AssociatedControlID="radWallsPref" runat="server" Text="Wall Only"></asp:Label>

                        <div class="toggleContent">
                            <ul>
                                <li>
                                    <asp:RadioButton ID="radWalls100" GroupName="wallModels" runat="server" />
                                    <asp:Label ID="lblWalls100Radio" AssociatedControlID="radWalls100" runat="server"></asp:Label>
                                    <asp:Label ID="lblWalls100" AssociatedControlID="radWalls100" runat="server" Text="Model 100"></asp:Label>
                                        
                                    <div class="toggleContent">
                                        <ul class="toggleOptions">
                                            <li>
                                                <asp:Label ID="lblWalls100Input" runat="server" Text="Model 100 Input: "></asp:Label>
                                                <asp:TextBox ID="txtWalls100Input" CssClass="txtField txtInput" runat="server"></asp:TextBox>
                                            </li>                                            
                                        </ul>
                                    </div>
                                </li>

                                <li>
                                    <asp:RadioButton ID="radWalls200" GroupName="wallModels" runat="server" />
                                    <asp:Label ID="lblWalls200Radio" AssociatedControlID="radWalls200" runat="server"></asp:Label>
                                    <asp:Label ID="lblWalls200" AssociatedControlID="radWalls200" runat="server" Text="Model 200"></asp:Label>
                                </li>

                                <li>
                                    <asp:RadioButton ID="radWalls300" GroupName="wallModels" runat="server" />
                                    <asp:Label ID="lblWalls300Radio" AssociatedControlID="radWalls300" runat="server"></asp:Label>
                                    <asp:Label ID="lblWalls300" AssociatedControlID="radWalls300" runat="server" Text="Model 300"></asp:Label>
                                </li>

                                <li>
                                    <asp:RadioButton ID="radWalls400" GroupName="wallModels" runat="server" />
                                    <asp:Label ID="lblWalls400Radio" AssociatedControlID="radWalls400" runat="server"></asp:Label>
                                    <asp:Label ID="lblWalls400" AssociatedControlID="radWalls400" runat="server" Text="Model 400"></asp:Label>
                                </li>
                            </ul>
                        </div>
                    </li>


                    <%-- Window Preferences --%>
                    <li>
                        <asp:RadioButton ID="radWindows" GroupName="preferences" runat="server" />
                        <asp:Label ID="lblWindowsRadio" AssociatedControlID="radWindows" runat="server"></asp:Label>
                        <asp:Label ID="lblWindows" AssociatedControlID="radWindows" runat="server" Text="Window Only"></asp:Label>
                    </li>


                    <%-- Door Preferences --%>
                    <li>
                        <asp:RadioButton ID="radDoors" GroupName="preferences" runat="server" />
                        <asp:Label ID="lblDoorsRadio" AssociatedControlID="radDoors" runat="server"></asp:Label>
                        <asp:Label ID="lblDoors" AssociatedControlID="radDoors" runat="server" Text="Door Only"></asp:Label>
                    </li>


                    <%-- Floor Preferences --%>
                    <li>
                        <asp:RadioButton ID="radFloor" GroupName="preferences" runat="server" />
                        <asp:Label ID="lblFloorRadio" AssociatedControlID="radFloor" runat="server"></asp:Label>
                        <asp:Label ID="lblFloor" AssociatedControlID="radFloor" runat="server" Text="Floor Only"></asp:Label>
                    </li>


                    <%-- Roof Preferences --%>
                    <li>
                        <asp:RadioButton ID="radRoof" GroupName="preferences" runat="server" />
                        <asp:Label ID="lblRoofRadio" AssociatedControlID="radRoof" runat="server"></asp:Label>
                        <asp:Label ID="lblRoof" AssociatedControlID="radRoof" runat="server" Text="Roof Only"></asp:Label>
                    </li>
                </ul>
    </div>
</asp:Content>

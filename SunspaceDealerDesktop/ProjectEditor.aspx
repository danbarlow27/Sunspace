<%@ Page Title="Project Editor" Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProjectEditor.aspx.cs" Inherits="SunspaceDealerDesktop.ProjectEditor" %>


<asp:Content runat="server" ID="SecondaryNavigation" ContentPlaceHolderID="SecondaryNavigation">   
    <nav class="navEditor">
        <ul class="ulNavEditor">
            <li><asp:DropDownList ID="ddlSunroomObjects" Width="160" runat="server"></asp:DropDownList></li>
            <li><asp:HyperLink ID="lnkEditorNavMods" CssClass="editMods" runat="server">Edit Mods</asp:HyperLink></li>
            <li><asp:HyperLink ID="lnkEditorNavTools" runat="server">Tools</asp:HyperLink>
                <ul>
                    <li><asp:HyperLink ID="lnkEditorNavSave" runat="server">Save</asp:HyperLink></li>
                    <li><asp:HyperLink ID="lnkEditorNavUndo" runat="server">Undo</asp:HyperLink></li>
                    <li><asp:HyperLink ID="lnkEditorNavRedo" runat="server">Redo</asp:HyperLink></li>
                    <li><asp:HyperLink ID="lnkEditorNavAddMod" runat="server">Add</asp:HyperLink></li>
                    <li><asp:HyperLink ID="lnkEditorNavDeleteMod" runat="server">Delete</asp:HyperLink></li>
                    <li><asp:HyperLink ID="lnkEditorNavMoveLeft" runat="server">Left</asp:HyperLink></li>
                    <li><asp:HyperLink ID="lnkEditorNavMoveRight" runat="server">Right</asp:HyperLink></li>
                    <li><asp:HyperLink ID="lnkEditorNavPrint" runat="server">Print</asp:HyperLink></li>
                </ul>
            </li>
        </ul>
    </nav>
</asp:Content>

<asp:Content runat="server" ID="ModOverlay" ContentPlaceHolderID="ModOverlay">
    <%--<div class="overlayBg"></div>--%>
    <div class="overlayContainer">
        <div class="overlayClose"><a href="#"><span>X</span> Close Mods Editor</a></div>
        
        <ul class="toggleOptions">
            <%-- Mod 1 --%>
            <li>
                <asp:RadioButton ID="radProjectSunroom" GroupName="projectType" runat="server" />
                <asp:Label ID="lblProjectSunroomRadio" AssociatedControlID="radProjectSunroom" runat="server"></asp:Label>
                <asp:Label ID="lblProjectSunroom" AssociatedControlID="radProjectSunroom" runat="server" Text="Mod 1"></asp:Label>
           
                <div class="toggleContent">
                    <ul>
                        <li>
                            <asp:RadioButton ID="radSunroomModel100" OnClick="newProjectCheckQuestion3()" GroupName="sunroomModel" runat="server" />
                            <asp:Label ID="lblSunroomModel100Radio" AssociatedControlID="radSunroomModel100" runat="server"></asp:Label>
                            <asp:Label ID="lblSunroomModel100" AssociatedControlID="radSunroomModel100" runat="server" Text="Model 100"></asp:Label>
                        </li>
                        <li>
                            <asp:RadioButton ID="radSunroomModel200" OnClick="newProjectCheckQuestion3()" GroupName="sunroomModel" runat="server" />
                            <asp:Label ID="lblSunroomModel200Radio" AssociatedControlID="radSunroomModel200" runat="server"></asp:Label>
                            <asp:Label ID="lblSunroomModel200" AssociatedControlID="radSunroomModel200" runat="server" Text="Model 200"></asp:Label>
                        </li>
                        <li>
                            <asp:RadioButton ID="radSunroomModel300" OnClick="newProjectCheckQuestion3()" GroupName="sunroomModel" runat="server" />
                            <asp:Label ID="lblSunroomModel300Radio" AssociatedControlID="radSunroomModel300" runat="server"></asp:Label>
                            <asp:Label ID="lblSunroomModel300" AssociatedControlID="radSunroomModel300" runat="server" Text="Model 300"></asp:Label>
                        </li>
                        <li>
                            <asp:RadioButton ID="radSunroomModel400" OnClick="newProjectCheckQuestion3()" GroupName="sunroomModel" runat="server" />
                            <asp:Label ID="lblSunroomModel400Radio" AssociatedControlID="radSunroomModel400" runat="server"></asp:Label>
                            <asp:Label ID="lblSunroomModel400" AssociatedControlID="radSunroomModel400" runat="server" Text="Model 400"></asp:Label>
                        </li>
                    </ul>            
                </div>
            </li>

            <%-- Mod 2 --%>
            <li>
                <asp:RadioButton ID="radProjectWalls" GroupName="projectType" runat="server" />
                <asp:Label ID="lblProjectWallsRadio" AssociatedControlID="radProjectWalls" runat="server"></asp:Label>
                <asp:Label ID="lblProjectWalls" AssociatedControlID="radProjectWalls" runat="server" Text="Mod 2"></asp:Label>

                <div class="toggleContent">
                    <ul class="checkboxes">
                        <li>
                            <asp:RadioButton ID="radWallsModel100" OnClick="newProjectCheckQuestion3()" GroupName="sunroomModel" runat="server" />
                            <asp:Label ID="lblWallsModel100Radio" AssociatedControlID="radWallsModel100" runat="server"></asp:Label>
                            <asp:Label ID="lblWallsModel100" AssociatedControlID="radWallsModel100" runat="server" Text="Model 100"></asp:Label>
                        </li>
                        <li>
                            <asp:RadioButton ID="radWallsModel200" OnClick="newProjectCheckQuestion3()" GroupName="sunroomModel" runat="server" />
                            <asp:Label ID="lblWallsModel200Radio" AssociatedControlID="radWallsModel200" runat="server"></asp:Label>
                            <asp:Label ID="lblWallsModel200" AssociatedControlID="radWallsModel200" runat="server" Text="Model 200"></asp:Label>
                        </li>
                        <li>
                            <asp:RadioButton ID="radWallsModel300" OnClick="newProjectCheckQuestion3()" GroupName="sunroomModel" runat="server" />
                            <asp:Label ID="lblWallsModel300Radio" AssociatedControlID="radWallsModel300" runat="server"></asp:Label>
                            <asp:Label ID="lblWallsModel300" AssociatedControlID="radWallsModel300" runat="server" Text="Model 300"></asp:Label>
                        </li>
                        <li>
                            <asp:RadioButton ID="radWallsModel400" OnClick="newProjectCheckQuestion3()" GroupName="sunroomModel" runat="server" />
                            <asp:Label ID="lblWallsModel400Radio" AssociatedControlID="radWallsModel400" runat="server"></asp:Label>
                            <asp:Label ID="lblWallsModel400" AssociatedControlID="radWallsModel400" runat="server" Text="Model 400"></asp:Label>
                        </li>
                    </ul>            
                </div>
            </li>

            <%-- Mod 3 --%>
            <li>
                <asp:RadioButton ID="RadioButton1" GroupName="projectType" runat="server" />
                <asp:Label ID="Label1" AssociatedControlID="RadioButton1" runat="server"></asp:Label>
                <asp:Label ID="Label2" AssociatedControlID="RadioButton1" runat="server" Text="Mod 3"></asp:Label>

                <div class="toggleContent">
                    <ul class="checkboxes">
                        <li>
                            <asp:RadioButton ID="RadioButton2" OnClick="newProjectCheckQuestion3()" GroupName="sunroomModel" runat="server" />
                            <asp:Label ID="Label3" AssociatedControlID="RadioButton2" runat="server"></asp:Label>
                            <asp:Label ID="Label4" AssociatedControlID="RadioButton2" runat="server" Text="Model 100"></asp:Label>
                        </li>
                        <li>
                            <asp:RadioButton ID="RadioButton3" OnClick="newProjectCheckQuestion3()" GroupName="sunroomModel" runat="server" />
                            <asp:Label ID="Label5" AssociatedControlID="RadioButton3" runat="server"></asp:Label>
                            <asp:Label ID="Label6" AssociatedControlID="RadioButton3" runat="server" Text="Model 200"></asp:Label>
                        </li>
                        <li>
                            <asp:RadioButton ID="RadioButton4" OnClick="newProjectCheckQuestion3()" GroupName="sunroomModel" runat="server" />
                            <asp:Label ID="Label7" AssociatedControlID="RadioButton4" runat="server"></asp:Label>
                            <asp:Label ID="Label8" AssociatedControlID="RadioButton4" runat="server" Text="Model 300"></asp:Label>
                        </li>
                        <li>
                            <asp:RadioButton ID="RadioButton5" OnClick="newProjectCheckQuestion3()" GroupName="sunroomModel" runat="server" />
                            <asp:Label ID="Label9" AssociatedControlID="RadioButton5" runat="server"></asp:Label>
                            <asp:Label ID="Label10" AssociatedControlID="RadioButton5" runat="server" Text="Model 400"></asp:Label>
                        </li>
                    </ul>            
                </div>
            </li>
        </ul>

    </div>   

    <%--<asp:Label ID="lblError" runat="server"></asp:Label>--%>
    <input id="hidJsonObjects" type="hidden" runat="server" />
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
          <asp:SqlDataSource ID="sdsDBConnection" runat="server" ConnectionString="<%$ ConnectionStrings:sunspaceDealerDesktopConnectionString %>" SelectCommand="SELECT * FROM [users]"></asp:SqlDataSource>
</asp:Content>
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddUsers.aspx.cs" Inherits="SunspaceDealerDesktop.AddUsers" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        function updateUserGroups() {
            var ddlUserType = document.getElementById("<%=ddlUserType.ClientID%>");
            var ddlUserGroup = document.getElementById("<%=ddlUserGroup.ClientID%>");
            var ddlDealers = document.getElementById("<%=ddlDealers.ClientID%>");

            if ("<%=userType%>" == "S" && "<%=userGroup%>" == "A") {
                ddlUserGroup.options.length = 0;
                //if sunspace admin with sunspace selected
                if (ddlUserType.options[ddlUserType.selectedIndex].value == "Sunspace") {
                    document.getElementById("<%=DealerListDiv.ClientID%>").style.display = "none";
                    ddlUserGroup.options.add(new Option("Admin", "Admin"));
                    ddlUserGroup.options.add(new Option("Customer Service Rep", "Customer Service Rep"));
                }
                    //--with dealer selected
                else {
                    document.getElementById("<%=DealerListDiv.ClientID%>").style.display = "inline";
                    ddlUserGroup.options.add(new Option("Admin", "Admin"));
                    ddlUserGroup.options.add(new Option("Sales Rep", "Sales Rep"));
                }
            }
        }
    </script>

    <asp:Label ID="lblError" runat="server"></asp:Label>
    <br /><br />
    <div id="UserTypeDiv" runat="server">
        <asp:Label ID="lblUserType" runat="server" Text="User type:"></asp:Label>
        <asp:DropDownList ID="ddlUserType" runat="server" OnChange="updateUserGroups()"></asp:DropDownList>
        <br /><br />
    </div>
    <div id="UserGroupDiv" runat="server">
        <asp:Label ID="lblUserGroup" runat="server" Text="User group:"></asp:Label>
        <asp:DropDownList ID="ddlUserGroup" runat="server"></asp:DropDownList>
        <br /><br />
    </div>
    <div id="DealerListDiv" runat="server">
        <asp:Label ID="lblDealers" runat="server" Text="Dealer:"></asp:Label>
        <asp:DropDownList ID="ddlDealers" runat="server"></asp:DropDownList>
        <br /><br />
    </div>
    <asp:Label ID="lblLogin" runat="server" Text="Login:"></asp:Label>
    <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox>
    <br /><br />
    <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label>
    <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
    <br /><br />
    <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
    <br /><br />
    <asp:Label ID="lblFirstName" runat="server" Text="First Name:"></asp:Label>
    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
    <br /><br />
    <asp:Label ID="lblLastName" runat="server" Text="Last Name:"></asp:Label>
    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
    <br /><br />
    <asp:Button id="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
    <asp:SqlDataSource ID="sdsUsers" runat="server" ConnectionString="<%$ ConnectionStrings:sunspaceDealerDesktopConnectionString %>" SelectCommand="SELECT * FROM [users]"></asp:SqlDataSource>
</asp:Content>

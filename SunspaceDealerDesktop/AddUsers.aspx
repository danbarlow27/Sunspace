<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddUsers.aspx.cs" Inherits="SunspaceDealerDesktop.AddUsers" EnableEventValidation="false" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        /// This function will update the values of the usergroup dropdown list based on
        /// both the user type of the user on the page, and the selection for user type in
        /// the other dropdown.  This is to allow having one dropdown to 'select' from for both
        /// sunspace users and dealer users.

        function updateUserGroups() {
            //Get the dropdowns and set to a variable for easier use.
            var ddlUserType = document.getElementById("<%=ddlUserType.ClientID%>");
            var ddlUserGroup = document.getElementById("<%=ddlUserGroup.ClientID%>");

            if ("<%=userType%>" == "S" && "<%=userGroup%>" == "A") {
                ddlUserGroup.options.length = 0;
                //if sunspace admin with sunspace selected, add applicable list items
                if (ddlUserType.options[ddlUserType.selectedIndex].value == "Sunspace") {
                    document.getElementById("<%=DealerAdminDiv.ClientID%>").style.display = "none";
                    ddlUserGroup.options.add(new Option("Admin", "Admin"));
                    ddlUserGroup.options.add(new Option("Customer Service Rep", "Customer Service Rep"));
                }
                    //--with dealer selected, add applicable list items
                else {
                    document.getElementById("<%=DealerAdminDiv.ClientID%>").style.display = "inline";
                    ddlUserGroup.options.add(new Option("Admin", "Admin"));
                    ddlUserGroup.options.add(new Option("Sales Rep", "Sales Rep"));
                }
                //Now that the 'new' dropdown is built, we'll move the default selection into a hidden field so it can be accessed on post
                //(*This is required, because if they don't change this dropdown then it will never manage to get its data moved into hidden fields otherwise*)
                document.getElementById("<%=hidUserGroup.ClientID%>").value = $('#<%=ddlUserGroup.ClientID%>').val();
            }        
        }
    </script>

    <asp:Label ID="lblError" runat="server"></asp:Label>
    <br /><br />
    <!-- This div will be used to hide user type selection for non sunspace admins -->
    <div id="UserTypeDiv" runat="server">
        <asp:Label ID="lblUserType" runat="server" Text="User type:"></asp:Label>
        <asp:DropDownList ID="ddlUserType" runat="server" OnChange="updateUserGroups()"></asp:DropDownList>
        <br /><br />
    </div>
    <!-- This div will be used to hide user type selection for non sunspace users -->
    <div id="UserGroupDiv" runat="server">
        <asp:Label ID="lblUserGroup" runat="server" Text="User group:"></asp:Label>
        <asp:DropDownList ID="ddlUserGroup" runat="server" OnChange="toggleDealerDropdown()"></asp:DropDownList>
        <br /><br />
    </div>
    <!-- This div will be used to hide user type selection for non sunspace users -->
    <div id="DealerAdminDiv" runat="server">
        <asp:Label ID="lblDealershipName" runat="server" Text="Dealership Name:"></asp:Label>
        <asp:TextBox ID="txtDealershipName" runat="server"></asp:TextBox>
        <br /><br />
        <asp:Label ID="lblCountry" runat="server" Text="Country:"></asp:Label>
        <asp:DropDownList ID="ddlCountry" runat="server" ></asp:DropDownList>
        <br /><br />
        <asp:Label ID="lblMultiplier" runat="server" Text="Multiplier: "></asp:Label>
        <asp:TextBox ID="txtMultiplier" runat="server"></asp:TextBox>
        %
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
    <asp:Button id="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" UseSubmitBehavior="false" />
    <asp:SqlDataSource ID="sdsUsers" runat="server" ConnectionString="<%$ ConnectionStrings:sunspaceDealerDesktopConnectionString %>" SelectCommand="SELECT * FROM [users]"></asp:SqlDataSource>
    
    <input id="hidUserGroup" type="hidden" runat="server" />
</asp:Content>

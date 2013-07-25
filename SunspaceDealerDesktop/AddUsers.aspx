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

        function toggleDealerDropdown() {
            var ddlUserType = document.getElementById("<%=ddlUserType.ClientID%>");
            var ddlUserGroup = document.getElementById("<%=ddlUserGroup.ClientID%>");

            //if changed, move new value to hidden field
            document.getElementById("<%=hidUserGroup.ClientID%>").value = $('#<%=ddlUserGroup.ClientID%>').val();
            if (ddlUserType.value == "Dealer" && ddlUserGroup.value == "Admin") {
                document.getElementById("<%=DealerAdminDiv.ClientID%>").style.display = "inline";
            }
            else if (ddlUserType.value == "Dealer" && ddlUserGroup.value == "Sales Rep") {
                document.getElementById("<%=DealerAdminDiv.ClientID%>").style.display = "none";
            }
        }

        //This function is used to validate the user entered multiplier and email to make sure they are valid for database entry
        function validateInput() {
            //Getting the values of the constants for the range of valid multipliers
            var minMultiplier = parseFloat("<%=minMultiplier%>");
            var maxMultiplier = parseFloat("<%=maxMultiplier%>");
            var errorMessage = ""; //default error message to blank

            try {
                //Cast multiplier to float
                var multiplier = +($('#<%=txtMultiplier.ClientID%>').val()) + 0.0;

                //After countless tries to make parseFloat and float casts throw an error to the catch block, it just won't happen.
                //check if not a number and throw manually
                if (isNaN(multiplier)) {
                    throw Error;
                }
                //if valid float number, make sure its in range.
                if (multiplier < minMultiplier || multiplier > maxMultiplier) {
                    errorMessage += "Invalid multiplier, must be between <%=minMultiplier%> and <%=maxMultiplier%>.<br/>";
                }
            }
            catch (err) {
                //if it got here, it isn't numeric
                errorMessage += "Invalid multiplier, must be numeric.<br/>";
            }
            //lastly, check email validation using the emailvalidation function
            if (emailValidation() == false) {
                errorMessage += "Invalid email, please use format Something@something.something<br/>"
            }
            //update error label with our error
            $('#<%=lblError.ClientID%>').html(errorMessage) 
        }

        //This function uses a regex value to validate email, returns true or false
        function emailValidation() {
            var anEmail = $('#<%=txtEmail.ClientID%>').val();
            //Regex for RFC 2822 email address validation.
            //var re = /[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?/;
            //Simpler, but less accurate string@string.string
            var re = /[^\s@]+@[^\s@]+\.[^\s@]+/;
            return re.test(anEmail);
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
        <asp:TextBox ID="txtMultiplier" runat="server" onkeyup="validateInput()"></asp:TextBox>
        <br /><br />
    </div>
    <asp:Label ID="lblLogin" runat="server" Text="Login:"></asp:Label>
    <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox>
    <br /><br />
    <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label>
    <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
    <br /><br />
    <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
    <asp:TextBox ID="txtEmail" runat="server" onkeyup="validateInput()"></asp:TextBox>
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
    <input id="hidEmail" type="hidden" runat="server" />
</asp:Content>

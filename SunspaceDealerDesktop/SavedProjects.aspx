<%@ Page Title="Saved Projects" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SavedProjects.aspx.cs" Inherits="SunspaceWizard.SavedProjects" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    
    <%-- SEARCH FIELD
    ======================================== --%>
    <div class="search">
        <asp:TextBox ID="txtSearch" class="txtField txtSearch float-left" placeholder="Search Projects" runat="server"></asp:TextBox>
        <asp:Button ID="btnSearch" class="btnSubmit btnSearch" runat="server" Text="Search" />
    </div>


    <%-- PROJECTS TABLE - HEADER
    ======================================== --%>
<%--    <asp:Table ID="tblSavedProjectsHeader" class="tblSavedProjects" runat="server">
        <asp:TableHeaderRow TableSection="TableHeader">
            <asp:TableHeaderCell>Project Name</asp:TableHeaderCell>
            <asp:TableHeaderCell>Last Modified</asp:TableHeaderCell>
            <asp:TableHeaderCell>&nbsp;</asp:TableHeaderCell>
            <asp:TableHeaderCell>Add to Estimate</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>--%>


    <%-- PROJECTS TABLE - BODY
    ======================================== --%>
    <div class="scrollbox">

        <asp:Table ID="tblSavedProjects" class="tblSavedProjects sortable" runat="server">
            <asp:TableHeaderRow TableSection="TableHeader">
                <asp:TableHeaderCell CssClass="thSortable">Project Name</asp:TableHeaderCell>
                <asp:TableHeaderCell CssClass="thSortable">Last Modified</asp:TableHeaderCell>
                <asp:TableHeaderCell CssClass="sorttable_nosort">&nbsp;</asp:TableHeaderCell>
                <asp:TableHeaderCell CssClass="sorttable_nosort">Add to Estimate</asp:TableHeaderCell>
            </asp:TableHeaderRow>

            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblProjectName1" runat="server" Text="Project Name"></asp:Label>
                </asp:TableCell>
                <asp:TableCell sorttable_customkey="20130503">
                    <asp:Label ID="Label1" runat="server" Text="May 3, 2013"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:HyperLink ID="lnkDelete" CssClass="btnDelete" runat="server">Delete</asp:HyperLink>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:CheckBox ID="chkAddToEstimate1" runat="server" />
                    <asp:Label ID="lblAddToCartCheckbox" AssociatedControlID="chkAddToEstimate1" runat="server"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label2" runat="server" Text="Project Name 2"></asp:Label>
                </asp:TableCell>
                <asp:TableCell sorttable_customkey="20130531">
                    <asp:Label ID="Label3" runat="server" Text="May 31, 2013"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:HyperLink ID="HyperLink1" CssClass="btnDelete" runat="server">Delete</asp:HyperLink>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:CheckBox ID="chkAddToEstimate2" runat="server" />
                    <asp:Label ID="Label4" AssociatedControlID="chkAddToEstimate2" runat="server"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

        </asp:Table>
   
    </div> <%-- end .scrollBox --%>

    <asp:Button ID="btnAddToEstimate" CssClass="btnSubmit btnAddToEstimate" runat="server" Text="Add to Estimate" />

    <script>
        $(function () {
            // set 'active' status in main nav (highlight text)
            $('.ulNavMain').children('a').removeClass('active');
            $('#lnkMainNavSavedProjects').addClass('active');

            // hide 'close project' link in main nav
            $('#lnkMainNavCloseProject').hide();
        });
    </script>
            
</asp:Content>

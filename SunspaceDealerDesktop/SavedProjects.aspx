<%@ Page Title="Saved Projects" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SavedProjects.aspx.cs" Inherits="SunspaceWizard.SavedProjects" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    
    <%-- SEARCH FIELD
    ======================================== --%>
    <div class="search">
        <asp:TextBox ID="txtSearch" onkeydown="return (event.keyCode!=13);" class="txtField txtSearch float-left" placeholder="Search Projects" runat="server"></asp:TextBox>
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
    <asp:Table ID="Table1" runat="server">
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2" CssClass="tdErrorLogin">
                <asp:Label runat="server" ID="lblError" CssClass="lblErrorLogin" Text= "" ></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <div class="scrollbox">

        <asp:PlaceHolder ID="phProjectList" runat="server"></asp:PlaceHolder>
   
    </div> <%-- end .scrollBox --%>

    <asp:Button ID="btnAddToEstimate" CssClass="btnSubmit btnAddToEstimate" runat="server" Text="Add to Estimate" OnClick="btnAddToEstimate_Click" />

    <asp:SqlDataSource ID="sdsProjectList" runat="server" ConnectionString="<%$ ConnectionStrings:sunspaceDealerDesktopConnectionString %>"></asp:SqlDataSource>

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

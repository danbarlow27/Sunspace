<%@ Page Title="Finalize Order" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FinalizeEstimates.aspx.cs" Inherits="SunspaceWizard.FinalizeEstimates" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    
    <%-- SEARCH FIELD
    ======================================== --%>
    <div class="search">
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

        <asp:PlaceHolder ID="phFinalizeOrderList" runat="server"></asp:PlaceHolder>

        
   
    </div> <%-- end .scrollBox --%>
    <br />
    <div class="ordertotalbox">
        <asp:PlaceHolder ID="phFinalizeOrderTotal" runat="server"></asp:PlaceHolder>
    </div>

    

    <asp:Button ID="btnAddToEstimate" CssClass="btnSubmit btnAddToEstimate" runat="server" Text="Finalize Order" OnClick="btnAddToEstimate_Click" />

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

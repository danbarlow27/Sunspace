<%@ Page Title="Roof Only Order" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="WizardRoofOnly.aspx.cs" Inherits="SunspaceDealerDesktop.RoofOnlyOrder" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">    
    <script src="Scripts/GlobalFunctions.js"></script>
    <script src="Scripts/Validation.js"></script>
    <script>

    </script>

    <div class="slide-window" id="slide-window" >
        <div class="slide-wrapper">
            <%-- QUESTION 3 - ROOF OPTIONS/DETAILS
            ======================================== --%>

            <div id="slide3" class="slide">
                <h1>
                    <asp:Label ID="lblRoofDetails" runat="server" Text="Roof Details"></asp:Label>
                </h1>        
                              
                <ul class="toggleOptions">
                    <asp:PlaceHolder ID="RoofOptions" runat="server"></asp:PlaceHolder>
                </ul>            

                <asp:Button ID="btnRoof" Enabled="true" CssClass="btnSubmit float-right slidePanel" runat="server" Text="Done"/>

            </div>
            <%-- end #slide3 --%>

         </div>
    </div>

<%-- SLIDE PAGING (QUESTION NAVIGATION)
    ======================================== --%>
    <div id="sidebar">
        <div id="paging-wrapper">    
            <div id="paging"> 
                
                <h2>Roof Specifications</h2>
                
                <ul class="toggleOptions">
                    <asp:PlaceHolder ID="lblRoofPager" runat="server"></asp:PlaceHolder>
                </ul>
            </div> <%-- end #paging --%>      
        </div>

        <textarea id="txtErrorMessage" class="txtErrorMessage" disabled="disabled" rows="5" runat="server"></textarea>
    </div>
    <div id="hiddenFieldsDiv" runat="server"></div>
</asp:Content>
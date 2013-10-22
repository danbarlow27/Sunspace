<%@ Page Title="" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="DoorOnlyOrder.aspx.cs" Inherits="SunspaceDealerDesktop.DoorOnlyOrder" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
<div class="slide-window" id="slide-window" >

        <div class="slide-wrapper">
            
            <%-- QUESTION 3 - DOOR OPTIONS/DETAILS
            ======================================== --%>

            <div id="slide3" class="slide">
                <h1>
                    <asp:Label ID="lblDoorDetails" runat="server" Text="Door Details"></asp:Label>
                </h1>        
                              
                <ul class="toggleOptions">
                    <asp:PlaceHolder ID="DoorOptions" runat="server"></asp:PlaceHolder>                    
                </ul>            

                <asp:Button ID="btnQuestion3" Enabled="true" CssClass="btnSubmit float-right slidePanel" data-slide="#slide4" runat="server" Text="Next Question"/>

            </div>
            <%-- end #slide3 --%>

         </div>
    </div>

<%-- SLIDE PAGING (QUESTION NAVIGATION)
    ======================================== --%>
    <div id="sidebar">
        <div id="paging-wrapper">    
            <div id="paging"> 
                <h2>Door Specifications</h2>

                <ul>
                    <!--Div tag to hold the canvas/grid-->
                    <div style="position:inherit; text-align:center; top:0px; right:0px;" id="mySunroom"></div>
                    <%--==================================== --%>


                    <%-- div to display the answers for question 1 --%>
                    <%--<div style="display: none" id="pagerOne">
                        <li>
                                <a href="#" data-slide="#slide1" class="slidePanel">
                                    <asp:Label ID="" runat="server" Text=""></asp:Label>
                                    <asp:Label ID="" runat="server" Text=""></asp:Label>
                                </a>
                        </li>
                    </div>--%>
                </ul>    
            </div> <%-- end #paging --%>      
        </div>

        <%--<asp:Label ID="lblErrorMessage" CssClass="lblErrorMessage" runat="server" Text="Label">Oh hello, I am an error message.</asp:Label>--%>
        <textarea id="txtErrorMessage" class="txtErrorMessage" disabled="disabled" rows="5" runat="server"></textarea>
    </div>
</asp:Content>
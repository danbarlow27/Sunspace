<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeBehind="WizardFloors.aspx.cs" Inherits="SunspaceDealerDesktop.WizardFloors" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <%-- Hidden field populating scripts 
    =================================== --%>
    <script>
        
    </script>
    <%-- End hidden div populating scripts --%>

    <%-- SLIDES (QUESTIONS)
    ======================================== --%>
    <div class="slide-window" id="slide-window" >

        <div class="slide-wrapper">
            
            <%-- QUESTION 1 - Wall Lengths
            ======================================== --%>
            <div id="slide1" class="slide">

                <h1>
                    <%-- Label for question 1 (floor details) --%>
                    <asp:Label ID="lblQuestion1" runat="server" Text="Floor Details"></asp:Label>
                </h1>        

    
                <%-- button to go to the next question --%>
                <asp:Button ID="btnQuestion1" Enabled="true" CssClass="btnSubmit float-right slidePanel" data-slide="#slide2" runat="server" Text="Next Question" />

            </div> 
            <%-- end #slide1 --%>        

        </div> <%-- end .slide-wrapper --%>

    </div> 
    <%-- end .slide-window --%>
    

    <%-- SLIDE PAGING (QUESTION NAVIGATION)
    ======================================== --%>
    <div id="sidebar">
        <div id="paging-wrapper">    
            <div id="paging"> 
                <h2>Floor Specifications</h2>

                <ul>
                    <%-- MINI CANVAS (HIGHLIGHTS CURRENT WALL)
                    ======================================== --%>
                    <div style="position:inherit; text-align:center; top:0px; right:0px;" id="mySunroom">

                    </div>
                    <div style="display: none" id="pagerOne">
                        <li>
                            <a href="#" data-slide="#slide1" class="slidePanel">
                            </a>
                        </li>
                    </div>                   
                </ul>    
            </div>    
        </div>

        <asp:Label ID="lblErrorMessage" CssClass="lblErrorMessage" runat="server" Text="Label">Oh hello, I am an error message.</asp:Label> 
    </div>
    
<script src="Scripts/MiniCanvasFunctions.js"></script> 

</asp:Content>

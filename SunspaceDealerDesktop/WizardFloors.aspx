﻿<%@ Page Title="New Project - Floor Details" Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeBehind="WizardFloors.aspx.cs" Inherits="SunspaceDealerDesktop.WizardFloors" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <script>
        /****HARD CODED VALUES TO BE PASSED FROM PREVIOUS PAGES****/
        var walls = [];
        walls[4] = {
            "wallId": 4,
            "length": 200
        }
        walls[5] = {
            "wallId": 5,
            "length": 300
        }
        walls[6] = {
            "wallId": 6,
            "length": 150
        }

        /****Line information for walls****/
        var detailsOfAllLines = '<%= (string)Session["coordList"] %>'; //all the coordinates and details of all the lines, coming from the session
        var lineList = detailsOfAllLines.substr(0, detailsOfAllLines.length - 1).split("/");
        var coordList = [];
        var proposedList = [];
        //Creating array of lines
        for (var i = 0; i < lineList.length; i++)
            coordList[i] = lineList[i].split(",");

        //Creating array of lines that are proposed
        for (var i = 0; i < coordList.length; i++) {
            if (coordList[i][4] === "P") {
                proposedList.push(coordList[i]);
                proposedList[proposedList.length-1].splice(6, 0, (i + 1));
                //proposedList[proposedList.length - 1][6] = i+1;
            }
        }

        //Function calls to occur when the document is ready/loaded
        $(document).ready(function () {
            floorTypeDisplay();
            loadValues();
        });

        /**
        *floorTypeDisplay
        *This function displays the appropriate fields based on the selected type of floor
        */
        function floorTypeDisplay() {
            var selectedType = $('#MainContent_ddlFloorType').val();

            if (selectedType == 'Thermadeck') {
                document.getElementById('MainContent_rowVapourBarrier').style.display = "inherit";
            }
            else {
                document.getElementById('MainContent_rowVapourBarrier').style.display = "none";
            }
        }

        function loadValues()
        {
            $('#<%=txtWidthDisplay.ClientID%>').val(findFloorWidth());
            $('#<%=txtProjectionDisplay.ClientID%>').val(findFloorProjection());
            $('#<%=lblPagerSquareFootageDisplay.ClientID%>').text(findSquareFootage(findFloorWidth(), findFloorProjection()) + "\'");
            document.getElementById('pagerOne').style.display = 'inline';
            document.getElementById('<%=btnQuestion1.ClientID%>').disabled = false;
        }

        /**
        *findFloorProjection
        *This function finds the projection of the current sunroom layout
        */
        function findFloorProjection() {
            var largestDifference = 0;

            for (var k = 0; k < proposedList.length; k++) {

                var toCheck = proposedList[k][2];

                for (var i = 0; i < proposedList.length; i++) {

                    if (Math.abs(toCheck - proposedList[i][3]) > largestDifference) {
                        largestDifference = walls[proposedList[i][6]].length;
                    }

                    if (toCheck != proposedList[i][2]) {
                        if (Math.abs(toCheck - proposedList[i][2]) > largestDifference) {
                            largestDifference = walls[proposedList[i][6]].length;
                        }
                    }
                }
            }

            return largestDifference;
        }

        /**
        *findFloorWidth
        *This function finds the width of the current sunroom layout
        */
        function findFloorWidth() {

            var largestDifference = 0;

            for (var k = 0; k < proposedList.length; k++) {

                var toCheck = proposedList[k][0];

                for (var i = 0; i < proposedList.length; i++) {

                    if (Math.abs(toCheck - proposedList[i][1]) > largestDifference) {
                        largestDifference = walls[proposedList[i][6]].length;
                    }

                    if (toCheck != proposedList[i][0]) {
                        if (Math.abs(toCheck - proposedList[i][0]) > largestDifference) {
                            largestDifference = walls[proposedList[i][6]].length;
                        }
                    }
                }
            }

            return largestDifference;
        }

        /**
        *checkFloors
        *This function stores all the data into hidden fields and displays
        *an appropriate message to the pager
        */
        function checkFloors()
        {
            document.getElementById('<%=hidFloorBoolean.ClientID%>').value = true;
            document.getElementById('<%=hidFloorType.ClientID%>').value = $('#<%=ddlFloorType.ClientID%>').val();
            document.getElementById('<%=hidFloorThickness.ClientID%>').value = $('#<%=ddlFloorThickness.ClientID%>').val();

            if ($('#<%=chkVapourBarrier.ClientID%>').is(':checked'))
                document.getElementById('<%=hidFloorVapourBarrier.ClientID%>').value = true;
            else
                document.getElementById('<%=hidFloorVapourBarrier.ClientID%>').value = false;   

        }

        function findSquareFootage(width, projection)
        {
            var squareFootage = (parseFloat(width) / 12) * (parseFloat(projection) / 12);

            return squareFootage.toFixed(2);
        }
        function updateSquareFootage()
        {
            
            $('#<%=lblPagerSquareFootageDisplay.ClientID%>').text(findSquareFootage(parseFloat(document.getElementById("MainContent_txtWidthDisplay").value), parseFloat(document.getElementById("MainContent_txtProjectionDisplay").value)) + "\'");
        
        }

    </script>

    <%-- SLIDES (QUESTION)
    ======================================== --%>
    <div class="slide-window" id="slide-window" >

        <div class="slide-wrapper">
            
            <%-- QUESTION 1 - Floor Details
            ======================================== --%>
            <div id="slide1" class="slide">

                <h1>
                    <%-- Label for question 1 (floor details) --%>
                    <asp:Label ID="lblQuestion1" runat="server" Text="Floor Details"></asp:Label>
                </h1>
                        <div>
                            <ul class="toggleOptions">
                                <li>
                                    <asp:Table ID="tblFloors" CssClass="tblTxtFields" runat="server">
                                        
                                        <asp:TableRow style="display:inherit">
                                            <asp:TableCell>
                                                <asp:Label ID="lblFloorType" AssociatedControlID="ddlFloorType" runat="server" Text="Type:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:DropDownList ID="ddlFloorType" onchange="floorTypeDisplay(); checkFloors()" runat="server"></asp:DropDownList>
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow style="display:inherit">  
                                            <asp:TableCell>
                                                <asp:Label ID="lblWidth" runat="server" Text="Floor Width: "></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:TextBox ID="txtWidthDisplay" CssClass="txtField txtInput" Width="60" runat="server" Text="" onkeyup="updateSquareFootage()"></asp:TextBox>"
                                            </asp:TableCell>  
                                        </asp:TableRow>

                                        <asp:TableRow style="display:inherit">  
                                            <asp:TableCell>
                                                <asp:Label ID="lblPagerProjection" runat="server" Text="Floor Projection: "></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:TextBox ID="txtProjectionDisplay" CssClass="txtField txtInput" Width="60" runat="server" Text="" onkeyup="updateSquareFootage()"></asp:TextBox>"
                                            </asp:TableCell>  
                                        </asp:TableRow>
                                        
                                        <asp:TableRow style="display:inherit">
                                            <asp:TableCell>
                                                <asp:Label ID="lblFloorThickness" AssociatedControlID="ddlFloorThickness" runat="server" Text="Thickness:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:DropDownList ID="ddlFloorThickness" runat="server" onchange="checkFloors()"></asp:DropDownList>
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow ID="rowVapourBarrier">
                                            <asp:TableCell>
                                                <asp:Label ID="lblVapourBarrier" AssociatedControlID="chkVapourBarrier" runat="server" Text="Vapour Barrier:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:CheckBox ID="chkVapourBarrier" runat="server" Text=" " onchange="checkFloors()"/>
                                            </asp:TableCell>
                                        </asp:TableRow>

                                    </asp:Table>
                                </li>
                            </ul>
                        </div>
                <%-- button to go to the next question --%>
                <asp:Button ID="btnQuestion1" Enabled="false" CssClass="btnSubmit float-right slidePanel" runat="server" Text="Confirm" />

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
                                <asp:Label ID="lblPagerSquareFootage" runat="server" Text="Floor Square Footage"></asp:Label>
                                <asp:Label ID="lblPagerSquareFootageDisplay" runat="server" Text=""></asp:Label>
                            </a>
                        </li>
                    </div>                   
                </ul>    
            </div>    
        </div>
    </div>

    <input id="hidFloorBoolean" type="hidden" runat="server" />
    <input id="hidFloorType" type="hidden" runat="server" />
    <input id="hidFloorThickness" type="hidden" runat="server" />
    <input id="hidFloorVapourBarrier" type="hidden" runat="server" />

    <script>
        $(function () {
            $('.ulNavMain').children('a').removeClass('active');
            $('#lnkMainNavNewProject').addClass('active');
        });
    </script>
</asp:Content>

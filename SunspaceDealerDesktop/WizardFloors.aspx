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
        var detailsOfAllLines = '<%= wallCoordinates %>'; //all the coordinates and details of all the lines, coming from the session
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
            checkFloors();
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

            checkFloors();
        }

        function loadValues()
        {
            $('#<%=txtWidthDisplay.ClientID%>').val('<%= roomWidth%>');
            $('#<%=txtProjectionDisplay.ClientID%>').val('<%= roomProjection%>');
            $('#<%=lblPagerSquareFootageDisplay.ClientID%>').text(findSquareFootage('<%= roomWidth%>', '<%= roomProjection%>') + "\'");
            document.getElementById('pagerOne').style.display = 'inline';
            document.getElementById('<%=btnQuestion1.ClientID%>').disabled = false;
        }
               
        /**
        *checkFloors
        *This function stores all the data into hidden fields and displays
        *an appropriate message to the pager
        */
        function checkFloors()
        {
            document.getElementById('<%=hidFloorType.ClientID%>').value = $('#<%=ddlFloorType.ClientID%>').val();
            document.getElementById('<%=hidFloorThickness.ClientID%>').value = $('#<%=ddlFloorThickness.ClientID%>').val();

            if ($('#<%=chkVapourBarrier.ClientID%>').is(':checked'))
                document.getElementById('<%=hidFloorVapourBarrier.ClientID%>').value = true;
            else
                document.getElementById('<%=hidFloorVapourBarrier.ClientID%>').value = false;

            //Validate entry for width/projection
            //Only run validation if a number is entered and values selected
            if (document.getElementById("<%=txtWidthDisplay.ClientID%>").value != "") {
                //only requirement on height at this moment is that it is a valid number
                if (isNaN(document.getElementById("<%=txtWidthDisplay.ClientID%>").value)) {
                    //kneewall height error handling
                    //DANPLS "The kneewall height you entered is not a valid number.";
                }
                else {
                    //valid
                    document.getElementById('<%=hidFloorWidth.ClientID%>').value = document.getElementById('<%=txtWidthDisplay.ClientID%>').value;
                }
            }

            if (document.getElementById("<%=txtProjectionDisplay.ClientID%>").value != "") {
                //only requirement on height at this moment is that it is a valid number
                if (isNaN(document.getElementById("<%=txtProjectionDisplay.ClientID%>").value)) {
                    //kneewall height error handling
                    //DANPLS "The kneewall height you entered is not a valid number.";
                }
                else {
                    //valid
                    document.getElementById('<%=hidFloorProjection.ClientID%>').value = document.getElementById('<%=txtProjectionDisplay.ClientID%>').value;
                }
            }
        }

        function findSquareFootage(width, projection)
        {
            var squareFootage = (parseFloat(width) / 12) * (parseFloat(projection) / 12);

            return squareFootage.toFixed(2);
        }
        function updateSquareFootage()
        {
            document.getElementById('<%= btnQuestion1.ClientID%>').disabled = true;
            var widthTemp = parseFloat(document.getElementById("MainContent_txtWidthDisplay").value)
            var projectionTemp = parseFloat(document.getElementById("MainContent_txtProjectionDisplay").value)
            
            var error = "";
            if (isNaN(widthTemp)) {
                error += "Your width is invalid. Please enter a valid number of inches.<br/>";
            }
            if (isNaN(projectionTemp)) {
                error += "Your projection is invalid. Please enter a valid number of inches.<br/>";
            }

            if (error == "") {
                $('#<%=lblPagerSquareFootageDisplay.ClientID%>').text(findSquareFootage(widthTemp, projectionTemp) + "\ '");
                document.getElementById('<%= btnQuestion1.ClientID%>').disabled = false;
            }
            else {
                document.getElementById('<%=lblPagerSquareFootageDisplay.ClientID%>').innerHTML = error;
            }

            checkFloors();
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
                                                <asp:TextBox ID="txtWidthDisplay" CssClass="txtField txtInput" Width="60" runat="server" Text="" onkeyup="updateSquareFootage()" MaxLength="3"></asp:TextBox> "
                                            </asp:TableCell>  
                                        </asp:TableRow>

                                        <asp:TableRow style="display:inherit">  
                                            <asp:TableCell>
                                                <asp:Label ID="lblPagerProjection" runat="server" Text="Floor Projection: "></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:TextBox ID="txtProjectionDisplay" CssClass="txtField txtInput" Width="60" runat="server" Text="" onkeyup="updateSquareFootage()" MaxLength="3"></asp:TextBox> "
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


    <input id="hidFloorType" type="hidden" runat="server" />
    <input id="hidFloorWidth" type="hidden" runat="server" />
    <input id="hidFloorProjection" type="hidden" runat="server" />
    <input id="hidFloorThickness" type="hidden" runat="server" />
    <input id="hidFloorVapourBarrier" type="hidden" runat="server" />

    <script>
        $(function () {
            $('.ulNavMain').children('a').removeClass('active');
            $('#lnkMainNavNewProject').addClass('active');
        });
    </script>
</asp:Content>

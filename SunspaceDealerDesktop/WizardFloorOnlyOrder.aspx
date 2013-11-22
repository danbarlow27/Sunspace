<%@ Page Title="Floor Only Order" EnableEventValidation="false" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="WizardFloorOnlyOrder.aspx.cs" Inherits="SunspaceDealerDesktop.WizardFloorOnlyOrder" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <div class="slide-window" id="slide-window" >

        <div class="slide-wrapper">
            
            <%-- QUESTION 1 - Floor Details
            ======================================== --%>
            <div id="slide1" class="slide">

                <h1>
                    <%-- Label for question 1 (floor details) --%>
                    <asp:Label ID="lblQuestion1" runat="server" Text="Floor Details"></asp:Label>
                </h1>

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

                <asp:Button ID="btnQuestion1" Enabled = "True" CssClass="btnSubmit float-right slidePanel" data-slide="#slide2" runat="server" Text="Next Question" />
            </div> 
            <%-- end #slide1 --%>            

            <%-- QUESTION 2 - Set Back
            ======================================== --%>
            <div id="slide2" class="slide">
                <h1>
                    <asp:Label ID="lblSetBack" runat="server" Text="Set Back"></asp:Label>
                </h1>

                <div>
                    <ul class="toggleOptions">
                        <li>
                            <asp:Table ID="tblSetback" CssClass="tblTxtFields" runat="server">
                                <asp:TableRow style="display:inherit">
                                    <asp:TableCell>
                                        <asp:Label ID="lblLedger" Text="Ledger: " runat="server"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtLedgerSetback" onkeyup="wizardFloorsCheckQuestion2()" runat="server"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:DropDownList ID="ddlLedgerSetbackInches" OnChange="wizardFloorsCheckQuestion2()" runat="server"></asp:DropDownList>
                                    </asp:TableCell>
                                </asp:TableRow>

                                <asp:TableRow style="display:inherit">
                                    <asp:TableCell>
                                        <asp:Label ID="lblFront" Text="Front: " runat="server"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtFrontSetback" onkeyup="wizardFloorsCheckQuestion2()" runat="server"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:DropDownList ID="ddlFrontSetbackInches" OnChange="wizardFloorsCheckQuestion2()" runat="server"></asp:DropDownList>
                                    </asp:TableCell>
                                </asp:TableRow>

                                <asp:TableRow style="display:inherit">
                                    <asp:TableCell>
                                        <asp:Label ID="lblSides" Text="Sides: " runat="server"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtSidesSetback" onkeyup="wizardFloorsCheckQuestion2()" runat="server"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:DropDownList ID="ddlSidesSetbackInches" OnChange="wizardFloorsCheckQuestion2()" runat="server"></asp:DropDownList>
                                    </asp:TableCell>
                                </asp:TableRow>

                                <asp:TableRow style="display:inherit">
                                    <asp:TableCell>
                                        <asp:Label ID="lblJoint" Text="Joint: " runat="server"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtJointSetback" onkeyup="wizardFloorsCheckQuestion2()" runat="server"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:DropDownList ID="ddlJointSetbackInches" OnChange="wizardFloorsCheckQuestion2()" runat="server"></asp:DropDownList>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </li>
                    </ul>
                </div>
                <%-- button to go to the next question --%>
                <asp:Button ID="btnQuestion2" Enabled="false" CssClass="btnSubmit float-right slidePanel" runat="server" Text="Done" OnClick="btnQuestion1_Click" />
            </div>
            <%-- end #slide3 --%>
        </div> <%-- end .slide-wrapper --%>

    </div> 

    <script>
        $(function () {
            $('.ulNavMain').children('a').removeClass('active');
            $('#lnkMainNavNewProject').addClass('active');
        });
    </script>

</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SkylightWizard.aspx.cs" Inherits="SunspaceDealerDesktop.SkylightWizard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        function skylightWizardCheckQuestion1() {
            //If it gets set to false anywhere in check, we disable button
            var validInputs = true;
            var panelSizes = <%=panelSizes%>;
            for (var i=1;i<=<%=totalPanels%>;i++)
            {
                if ($('#MainContent_chkFanBeam'.concat(i)).is(':checked')){
                    document.getElementById('MainContent_hidHasBeam'.concat(i)).value = "Yes";

                    //Can't be <12, because can't be within a foot of the edges
                    //skylightwidth+12 >panelSizes-12 because, the ending point of a skylight must be more than 1ft from ending edge of a panel
                    if ($('#MainContent_txtFanBeam'+i).val() == "" || $('#MainContent_txtFanBeam'.concat(i)).val() < 12 || ($('#MainContent_txtFanBeam'.concat(i)).val()+<%=SKYLIGHT_WIDTH%>) > (panelSizes[i]-12)){
                        //invalid fanbeam entry
                        validInputs = false;
                    }
                }
                else{                    
                    document.getElementById('MainContent_hidHasBeam'.concat(i)).value = "No";
                }
                if ($('#MainContent_chkSkylight'.concat(i)).is(':checked')){
                    document.getElementById('MainContent_hidHasSkylight'.concat(i)).value = "Yes";

                    //Can't be <12, because can't be within a foot of the edges
                    if ($('#MainContent_txtSkylight'.concat(i)).val() == "" || $('#MainContent_txtSkylight'.concat(i)).val() < 12){
                        //invalid fanbeam entry
                        validInputs = false;
                    }
                }
                else{                    
                    document.getElementById('MainContent_hidHasSkylight'.concat(i)).value = "No";
                }
            }

            if (validInputs == true)
            {
                document.getElementById('<%=btnQuestion1.ClientID%>').disabled = false;
            }
            else
            {
                document.getElementById('<%=btnQuestion1.ClientID%>').disabled = true;
            }
        }

        function skylightWizardCenterFanBeam(){

        }

        function skylightWizardCenterSkylight(){

        }
    </script>
    <div class="slide-window"  >
        <div class="slide-wrapper"> 
            <%-- Slide 1 - Yes/no --%>
            <div id="slide1" class="slide">
                <h1>
                    <asp:Label ID="lblTitle" runat="server" Text="Panel Editing Wizard"></asp:Label>
                </h1>

                <ul class="toggleOptions">                    
                    <asp:PlaceHolder ID="panelOptionPlaceholder" runat="server"></asp:PlaceHolder> 
                </ul>
                
                <asp:Button ID="btnQuestion1" CssClass="btnSubmit float-right slidePanel" data-slide="#slide2" runat="server" Text="Next Question" Enabled="false" OnClick="btnQuestion1_Click" />
            </div>
        </div>
    </div>

    <asp:PlaceHolder ID="hiddenInputPlaceholder" runat="server"></asp:PlaceHolder>
</asp:Content>

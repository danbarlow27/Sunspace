<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Preferences.aspx.cs" Inherits="SunspaceDealerDesktop.Home" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <script>

        //Copied from NewProject.  When you select a frame colour, will update the interior and exterior colour dropdowns
        //Edited slightly for preferences use.
        function preferencesCascadeColours(modelNumber) {
            //There are four different sections of these, so I'll handle which to update based on modelNumber sent
            if (modelNumber == 100) {
                ddlFramingColour = document.getElementById("<%= ddl100FrameColour.ClientID %>");
                if (ddlFramingColour.options[ddlFramingColour.selectedIndex].value == "White") {
                    $("#<%=ddl100InteriorPanelSkin.ClientID%>").val('White Aluminum Stucco');
                    $("#<%=ddl100ExteriorPanelSkin.ClientID%>").val('White Aluminum Stucco');
                }
                else if (ddlFramingColour.options[ddlFramingColour.selectedIndex].value == "Driftwood") {
                    $("#<%=ddl100InteriorPanelSkin.ClientID%>").val('Driftwood Aluminum Stucco');
                    $("#<%=ddl100ExteriorPanelSkin.ClientID%>").val('Driftwood Aluminum Stucco');
                }
                else if (ddlFramingColour.options[ddlFramingColour.selectedIndex].value == "Bronze") {
                    $("#<%=ddl100InteriorPanelSkin.ClientID%>").val('Bronze Aluminum Stucco');
                    $("#<%=ddl100ExteriorPanelSkin.ClientID%>").val('Bronze Aluminum Stucco');
                }
            }
            else if (modelNumber == 200) {
                ddlFramingColour = document.getElementById("<%= ddl200FrameColour.ClientID %>");
                if (ddlFramingColour.options[ddlFramingColour.selectedIndex].value == "White") {
                    $("#<%=ddl200InteriorPanelSkin.ClientID%>").val('White Aluminum Stucco');
                    $("#<%=ddl200ExteriorPanelSkin.ClientID%>").val('White Aluminum Stucco');
                }
                else if (ddlFramingColour.options[ddlFramingColour.selectedIndex].value == "Driftwood") {
                    $("#<%=ddl200InteriorPanelSkin.ClientID%>").val('Driftwood Aluminum Stucco');
                    $("#<%=ddl200ExteriorPanelSkin.ClientID%>").val('Driftwood Aluminum Stucco');
                }
                else if (ddlFramingColour.options[ddlFramingColour.selectedIndex].value == "Bronze") {
                    $("#<%=ddl200InteriorPanelSkin.ClientID%>").val('Bronze Aluminum Stucco');
                    $("#<%=ddl200ExteriorPanelSkin.ClientID%>").val('Bronze Aluminum Stucco');
                }
            }
            else if (modelNumber == 300) {
                ddlFramingColour = document.getElementById("<%= ddl300FrameColour.ClientID %>");
                if (ddlFramingColour.options[ddlFramingColour.selectedIndex].value == "White") {
                    $("#<%=ddl300InteriorPanelSkin.ClientID%>").val('White Aluminum Stucco');
                    $("#<%=ddl300ExteriorPanelSkin.ClientID%>").val('White Aluminum Stucco');
                }
                else if (ddlFramingColour.options[ddlFramingColour.selectedIndex].value == "Driftwood") {
                    $("#<%=ddl300InteriorPanelSkin.ClientID%>").val('Driftwood Aluminum Stucco');
                    $("#<%=ddl300ExteriorPanelSkin.ClientID%>").val('Driftwood Aluminum Stucco');
                }
                else if (ddlFramingColour.options[ddlFramingColour.selectedIndex].value == "Bronze") {
                    $("#<%=ddl300InteriorPanelSkin.ClientID%>").val('Bronze Aluminum Stucco');
                    $("#<%=ddl300ExteriorPanelSkin.ClientID%>").val('Bronze Aluminum Stucco');
                }
            }
            else if (modelNumber == 400) {
                ddlFramingColour = document.getElementById("<%= ddl400FrameColour.ClientID %>");
                if (ddlFramingColour.options[ddlFramingColour.selectedIndex].value == "White") {
                    $("#<%=ddl400InteriorPanelSkin.ClientID%>").val('White Aluminum Stucco');
                    $("#<%=ddl400ExteriorPanelSkin.ClientID%>").val('White Aluminum Stucco');
                }
                else if (ddlFramingColour.options[ddlFramingColour.selectedIndex].value == "Driftwood") {
                    $("#<%=ddl400InteriorPanelSkin.ClientID%>").val('Driftwood Aluminum Stucco');
                    $("#<%=ddl400ExteriorPanelSkin.ClientID%>").val('Driftwood Aluminum Stucco');
                }
            }       

            //We've changed values so we need to move hidden values, which I already have a function for, instead of doing it manually
            MoveValuesToHiddenDivs();
        }

        //This function will move all values to hidden divs
        function MoveValuesToHiddenDivs()
        {
            console.log("Moving");
            //general
            document.getElementById("<%=hidInstallationType.ClientID%>").value = $('#<%=ddlInstallationType.ClientID%>').val();
            document.getElementById("<%=hidModelNumber.ClientID%>").value = $('#<%=ddlModelNumber.ClientID%>').val();
            document.getElementById("<%=hidLayout.ClientID%>").value = $('#<%=ddlLayout.ClientID%>').val();

            //100
            document.getElementById("<%=hid100DefaultFiller.ClientID%>").value = $('#<%=txt100DefaultFiller.ClientID%>').val();

            document.getElementById("<%=hid100WallInteriorPanelSkin.ClientID%>").value = $('#<%=ddl100InteriorPanelSkin.ClientID%>').val();
            document.getElementById("<%=hid100WallExteriorPanelSkin.ClientID%>").value = $('#<%=ddl100ExteriorPanelSkin.ClientID%>').val();
            document.getElementById("<%=hid100WallFrameColour.ClientID%>").value = $('#<%=ddl100FrameColour.ClientID%>').val();

            document.getElementById("<%=hid100DoorType.ClientID%>").value = $('#<%=ddl100DoorType.ClientID%>').val();
            document.getElementById("<%=hid100DoorStyle.ClientID%>").value = $('#<%=ddl100DoorStyle.ClientID%>').val();
            document.getElementById("<%=hid100DoorSwing.ClientID%>").value = $('#<%=ddl100DoorSwing.ClientID%>').val();
            document.getElementById("<%=hid100DoorHinge.ClientID%>").value = $('#<%=ddl100DoorHinge.ClientID%>').val();
            document.getElementById("<%=hid100DoorHardware.ClientID%>").value = $('#<%=ddl100DoorHardware.ClientID%>').val();
            document.getElementById("<%=hid100DoorColour.ClientID%>").value = $('#<%=ddl100DoorColour.ClientID%>').val();
            document.getElementById("<%=hid100DoorGlassTint.ClientID%>").value = $('#<%=ddl100DoorGlassTint.ClientID%>').val();
            document.getElementById("<%=hid100DoorVinylTint.ClientID%>").value = $('#<%=ddl100DoorVinylTint.ClientID%>').val();
            document.getElementById("<%=hid100DoorScreenType.ClientID%>").value = $('#<%=ddl100DoorScreenType.ClientID%>').val();

            document.getElementById("<%=hid100WindowType.ClientID%>").value = $('#<%=ddl100WindowType.ClientID%>').val();
            document.getElementById("<%=hid100WindowColour.ClientID%>").value = "None";
            document.getElementById("<%=hid100WindowGlassTint.ClientID%>").value = $('#<%=ddl100WindowGlassTint.ClientID%>').val();
            document.getElementById("<%=hid100WindowVinylTint.ClientID%>").value = $('#<%=ddl100WindowVinylTint.ClientID%>').val();
            document.getElementById("<%=hid100WindowScreenType.ClientID%>").value = $('#<%=ddl100WindowScreenType.ClientID%>').val();

            document.getElementById("<%=hid100SunshadeValanceColour.ClientID%>").value = $('#<%=ddl100SunshadeValanceColour.ClientID%>').val();
            document.getElementById("<%=hid100SunshadeFabricColour.ClientID%>").value = $('#<%=ddl100SunshadeFabricColour.ClientID%>').val();
            document.getElementById("<%=hid100SunshadeOpenness.ClientID%>").value = $('#<%=ddl100SunshadeOpenness.ClientID%>').val();

            document.getElementById("<%=hid100RoofType.ClientID%>").value = $('#<%=ddl100RoofType.ClientID%>').val();
            document.getElementById("<%=hid100RoofInteriorSkin.ClientID%>").value = $('#<%=ddl100RoofInteriorSkin.ClientID%>').val();
            document.getElementById("<%=hid100RoofExteriorSkin.ClientID%>").value = $('#<%=ddl100RoofExteriorSkin.ClientID%>').val();
            document.getElementById("<%=hid100RoofThickness.ClientID%>").value = $('#<%=ddl100RoofThickness.ClientID%>').val();

            document.getElementById("<%=hid100FloorThickness.ClientID%>").value = $('#<%=ddl100FloorThickness.ClientID%>').val();
            document.getElementById("<%=hid100FloorMetalBarrier.ClientID%>").value = $('#<%=chk100FloorMetalBarrier.ClientID%>').val();

            document.getElementById("<%=hid100KneewallHeight.ClientID%>").value = $('#<%=txt100KneewallHeight.ClientID%>').val();
            document.getElementById("<%=hid100KneewallType.ClientID%>").value = $('#<%=ddl100KneewallType.ClientID%>').val();
            document.getElementById("<%=hid100KneewallGlassTint.ClientID%>").value = $('#<%=ddl100KneewallGlassTint.ClientID%>').val();

            document.getElementById("<%=hid100TransomHeight.ClientID%>").value = $('#<%=txt100TransomHeight.ClientID%>').val();
            document.getElementById("<%=hid100TransomType.ClientID%>").value = $('#<%=ddl100TransomType.ClientID%>').val();
            document.getElementById("<%=hid100TransomGlassTint.ClientID%>").value = $('#<%=ddl100TransomGlassTint.ClientID%>').val();
            document.getElementById("<%=hid100TransomVinylTint.ClientID%>").value = $('#<%=ddl100TransomVinylTint.ClientID%>').val();
            document.getElementById("<%=hid100TransomScreenType.ClientID%>").value = $('#<%=ddl100TransomScreenType.ClientID%>').val();

            document.getElementById("<%=hid100Markup.ClientID%>").value = $('#<%=txt100Markup.ClientID%>').val();

            //200
            document.getElementById("<%=hid200DefaultFiller.ClientID%>").value = $('#<%=txt200DefaultFiller.ClientID%>').val();

            document.getElementById("<%=hid200WallInteriorPanelSkin.ClientID%>").value = $('#<%=ddl200InteriorPanelSkin.ClientID%>').val();
            document.getElementById("<%=hid200WallExteriorPanelSkin.ClientID%>").value = $('#<%=ddl200ExteriorPanelSkin.ClientID%>').val();
            document.getElementById("<%=hid200WallFrameColour.ClientID%>").value = $('#<%=ddl200FrameColour.ClientID%>').val();

            document.getElementById("<%=hid200DoorType.ClientID%>").value = $('#<%=ddl200DoorType.ClientID%>').val();
            document.getElementById("<%=hid200DoorStyle.ClientID%>").value = $('#<%=ddl200DoorStyle.ClientID%>').val();
            document.getElementById("<%=hid200DoorSwing.ClientID%>").value = $('#<%=ddl200DoorSwing.ClientID%>').val();
            document.getElementById("<%=hid200DoorHinge.ClientID%>").value = $('#<%=ddl200DoorHinge.ClientID%>').val();
            document.getElementById("<%=hid200DoorHardware.ClientID%>").value = $('#<%=ddl200DoorHardware.ClientID%>').val();
            document.getElementById("<%=hid200DoorColour.ClientID%>").value = $('#<%=ddl200DoorColour.ClientID%>').val();
            document.getElementById("<%=hid200DoorGlassTint.ClientID%>").value = $('#<%=ddl200DoorGlassTint.ClientID%>').val();
            document.getElementById("<%=hid200DoorVinylTint.ClientID%>").value = $('#<%=ddl200DoorVinylTint.ClientID%>').val();
            document.getElementById("<%=hid200DoorScreenType.ClientID%>").value = $('#<%=ddl200DoorScreenType.ClientID%>').val();

            document.getElementById("<%=hid200WindowType.ClientID%>").value = $('#<%=ddl200WindowType.ClientID%>').val();
            document.getElementById("<%=hid200WindowColour.ClientID%>").value = "None";
            document.getElementById("<%=hid200WindowGlassTint.ClientID%>").value = $('#<%=ddl200WindowGlassTint.ClientID%>').val();
            document.getElementById("<%=hid200WindowVinylTint.ClientID%>").value = $('#<%=ddl200WindowVinylTint.ClientID%>').val();
            document.getElementById("<%=hid200WindowScreenType.ClientID%>").value = $('#<%=ddl200WindowScreenType.ClientID%>').val();

            document.getElementById("<%=hid200SunshadeValanceColour.ClientID%>").value = $('#<%=ddl200SunshadeValanceColour.ClientID%>').val();
            document.getElementById("<%=hid200SunshadeFabricColour.ClientID%>").value = $('#<%=ddl200SunshadeFabricColour.ClientID%>').val();
            document.getElementById("<%=hid200SunshadeOpenness.ClientID%>").value = $('#<%=ddl200SunshadeOpenness.ClientID%>').val();

            document.getElementById("<%=hid200RoofType.ClientID%>").value = $('#<%=ddl200RoofType.ClientID%>').val();
            document.getElementById("<%=hid200RoofInteriorSkin.ClientID%>").value = $('#<%=ddl200RoofInteriorSkin.ClientID%>').val();
            document.getElementById("<%=hid200RoofExteriorSkin.ClientID%>").value = $('#<%=ddl200RoofExteriorSkin.ClientID%>').val();
            document.getElementById("<%=hid200RoofThickness.ClientID%>").value = $('#<%=ddl200RoofThickness.ClientID%>').val();

            document.getElementById("<%=hid200FloorThickness.ClientID%>").value = $('#<%=ddl200FloorThickness.ClientID%>').val();
            document.getElementById("<%=hid200FloorMetalBarrier.ClientID%>").value = $('#<%=chk200FloorMetalBarrier.ClientID%>').val();

            document.getElementById("<%=hid200KneewallHeight.ClientID%>").value = $('#<%=txt200KneewallHeight.ClientID%>').val();
            document.getElementById("<%=hid200KneewallType.ClientID%>").value = $('#<%=ddl200KneewallType.ClientID%>').val();
            document.getElementById("<%=hid200KneewallGlassTint.ClientID%>").value = $('#<%=ddl200KneewallGlassTint.ClientID%>').val();

            document.getElementById("<%=hid200TransomHeight.ClientID%>").value = $('#<%=txt200TransomHeight.ClientID%>').val();
            document.getElementById("<%=hid200TransomType.ClientID%>").value = $('#<%=ddl200TransomType.ClientID%>').val();
            document.getElementById("<%=hid200TransomGlassTint.ClientID%>").value = $('#<%=ddl200TransomGlassTint.ClientID%>').val();
            document.getElementById("<%=hid200TransomVinylTint.ClientID%>").value = $('#<%=ddl200TransomVinylTint.ClientID%>').val();
            document.getElementById("<%=hid200TransomScreenType.ClientID%>").value = $('#<%=ddl200TransomScreenType.ClientID%>').val();

            document.getElementById("<%=hid200Markup.ClientID%>").value = $('#<%=txt200Markup.ClientID%>').val();

            //300
            document.getElementById("<%=hid300DefaultFiller.ClientID%>").value = $('#<%=txt300DefaultFiller.ClientID%>').val();

            document.getElementById("<%=hid300WallInteriorPanelSkin.ClientID%>").value = $('#<%=ddl300InteriorPanelSkin.ClientID%>').val();
            document.getElementById("<%=hid300WallExteriorPanelSkin.ClientID%>").value = $('#<%=ddl300ExteriorPanelSkin.ClientID%>').val();
            document.getElementById("<%=hid300WallFrameColour.ClientID%>").value = $('#<%=ddl300FrameColour.ClientID%>').val();

            document.getElementById("<%=hid300DoorType.ClientID%>").value = $('#<%=ddl300DoorType.ClientID%>').val();
            document.getElementById("<%=hid300DoorStyle.ClientID%>").value = $('#<%=ddl300DoorStyle.ClientID%>').val();
            document.getElementById("<%=hid300DoorSwing.ClientID%>").value = $('#<%=ddl300DoorSwing.ClientID%>').val();
            document.getElementById("<%=hid300DoorHinge.ClientID%>").value = $('#<%=ddl300DoorHinge.ClientID%>').val();
            document.getElementById("<%=hid300DoorHardware.ClientID%>").value = $('#<%=ddl300DoorHardware.ClientID%>').val();
            document.getElementById("<%=hid300DoorColour.ClientID%>").value = $('#<%=ddl300DoorColour.ClientID%>').val();
            document.getElementById("<%=hid300DoorGlassTint.ClientID%>").value = $('#<%=ddl300DoorGlassTint.ClientID%>').val();
            document.getElementById("<%=hid300DoorVinylTint.ClientID%>").value = $('#<%=ddl300DoorVinylTint.ClientID%>').val();
            document.getElementById("<%=hid300DoorScreenType.ClientID%>").value = $('#<%=ddl300DoorScreenType.ClientID%>').val();

            document.getElementById("<%=hid300WindowType.ClientID%>").value = $('#<%=ddl300WindowType.ClientID%>').val();
            document.getElementById("<%=hid300WindowColour.ClientID%>").value = "None";
            document.getElementById("<%=hid300WindowGlassTint.ClientID%>").value = $('#<%=ddl300WindowGlassTint.ClientID%>').val();
            document.getElementById("<%=hid300WindowVinylTint.ClientID%>").value = $('#<%=ddl300WindowVinylTint.ClientID%>').val();
            document.getElementById("<%=hid300WindowScreenType.ClientID%>").value = $('#<%=ddl300WindowScreenType.ClientID%>').val();

            document.getElementById("<%=hid300SunshadeValanceColour.ClientID%>").value = $('#<%=ddl300SunshadeValanceColour.ClientID%>').val();
            document.getElementById("<%=hid300SunshadeFabricColour.ClientID%>").value = $('#<%=ddl300SunshadeFabricColour.ClientID%>').val();
            document.getElementById("<%=hid300SunshadeOpenness.ClientID%>").value = $('#<%=ddl300SunshadeOpenness.ClientID%>').val();

            document.getElementById("<%=hid300RoofType.ClientID%>").value = $('#<%=ddl300RoofType.ClientID%>').val();
            document.getElementById("<%=hid300RoofInteriorSkin.ClientID%>").value = $('#<%=ddl300RoofInteriorSkin.ClientID%>').val();
            document.getElementById("<%=hid300RoofExteriorSkin.ClientID%>").value = $('#<%=ddl300RoofExteriorSkin.ClientID%>').val();
            document.getElementById("<%=hid300RoofThickness.ClientID%>").value = $('#<%=ddl300RoofThickness.ClientID%>').val();

            document.getElementById("<%=hid300FloorThickness.ClientID%>").value = $('#<%=ddl300FloorThickness.ClientID%>').val();
            document.getElementById("<%=hid300FloorMetalBarrier.ClientID%>").value = $('#<%=chk300FloorMetalBarrier.ClientID%>').val();

            document.getElementById("<%=hid300KneewallHeight.ClientID%>").value = $('#<%=txt300KneewallHeight.ClientID%>').val();
            document.getElementById("<%=hid300KneewallType.ClientID%>").value = $('#<%=ddl300KneewallType.ClientID%>').val();
            document.getElementById("<%=hid300KneewallGlassTint.ClientID%>").value = $('#<%=ddl300KneewallGlassTint.ClientID%>').val();

            document.getElementById("<%=hid300TransomHeight.ClientID%>").value = $('#<%=txt300TransomHeight.ClientID%>').val();
            document.getElementById("<%=hid300TransomType.ClientID%>").value = $('#<%=ddl300TransomType.ClientID%>').val();
            document.getElementById("<%=hid300TransomGlassTint.ClientID%>").value = $('#<%=ddl300TransomGlassTint.ClientID%>').val();
            document.getElementById("<%=hid300TransomVinylTint.ClientID%>").value = $('#<%=ddl300TransomVinylTint.ClientID%>').val();
            document.getElementById("<%=hid300TransomScreenType.ClientID%>").value = $('#<%=ddl300TransomScreenType.ClientID%>').val();

            document.getElementById("<%=hid300Markup.ClientID%>").value = $('#<%=txt300Markup.ClientID%>').val();

            //400
            document.getElementById("<%=hid400DefaultFiller.ClientID%>").value = $('#<%=txt400DefaultFiller.ClientID%>').val();

            document.getElementById("<%=hid400WallInteriorPanelSkin.ClientID%>").value = $('#<%=ddl400InteriorPanelSkin.ClientID%>').val();
            document.getElementById("<%=hid400WallExteriorPanelSkin.ClientID%>").value = $('#<%=ddl400ExteriorPanelSkin.ClientID%>').val();
            document.getElementById("<%=hid400WallFrameColour.ClientID%>").value = $('#<%=ddl400FrameColour.ClientID%>').val();

            document.getElementById("<%=hid400DoorType.ClientID%>").value = $('#<%=ddl400DoorType.ClientID%>').val();
            document.getElementById("<%=hid400DoorStyle.ClientID%>").value = $('#<%=ddl400DoorStyle.ClientID%>').val();
            document.getElementById("<%=hid400DoorSwing.ClientID%>").value = $('#<%=ddl400DoorSwing.ClientID%>').val();
            document.getElementById("<%=hid400DoorHinge.ClientID%>").value = $('#<%=ddl400DoorHinge.ClientID%>').val();
            document.getElementById("<%=hid400DoorHardware.ClientID%>").value = $('#<%=ddl400DoorHardware.ClientID%>').val();
            document.getElementById("<%=hid400DoorColour.ClientID%>").value = $('#<%=ddl400DoorColour.ClientID%>').val();
            document.getElementById("<%=hid400DoorGlassTint.ClientID%>").value = $('#<%=ddl400DoorGlassTint.ClientID%>').val();
            document.getElementById("<%=hid400DoorVinylTint.ClientID%>").value = $('#<%=ddl400DoorVinylTint.ClientID%>').val();
            document.getElementById("<%=hid400DoorScreenType.ClientID%>").value = $('#<%=ddl400DoorScreenType.ClientID%>').val();

            document.getElementById("<%=hid400WindowType.ClientID%>").value = $('#<%=ddl400WindowType.ClientID%>').val();
            document.getElementById("<%=hid400WindowColour.ClientID%>").value = "None";
            document.getElementById("<%=hid400WindowGlassTint.ClientID%>").value = $('#<%=ddl400WindowGlassTint.ClientID%>').val();
            document.getElementById("<%=hid400WindowVinylTint.ClientID%>").value = $('#<%=ddl400WindowVinylTint.ClientID%>').val();
            document.getElementById("<%=hid400WindowScreenType.ClientID%>").value = $('#<%=ddl400WindowScreenType.ClientID%>').val();

            document.getElementById("<%=hid400SunshadeValanceColour.ClientID%>").value = $('#<%=ddl400SunshadeValanceColour.ClientID%>').val();
            document.getElementById("<%=hid400SunshadeFabricColour.ClientID%>").value = $('#<%=ddl400SunshadeFabricColour.ClientID%>').val();
            document.getElementById("<%=hid400SunshadeOpenness.ClientID%>").value = $('#<%=ddl400SunshadeOpenness.ClientID%>').val();

            document.getElementById("<%=hid400RoofType.ClientID%>").value = $('#<%=ddl400RoofType.ClientID%>').val();
            document.getElementById("<%=hid400RoofInteriorSkin.ClientID%>").value = $('#<%=ddl400RoofInteriorSkin.ClientID%>').val();
            document.getElementById("<%=hid400RoofExteriorSkin.ClientID%>").value = $('#<%=ddl400RoofExteriorSkin.ClientID%>').val();
            document.getElementById("<%=hid400RoofThickness.ClientID%>").value = $('#<%=ddl400RoofThickness.ClientID%>').val();

            document.getElementById("<%=hid400FloorThickness.ClientID%>").value = $('#<%=ddl400FloorThickness.ClientID%>').val();
            document.getElementById("<%=hid400FloorMetalBarrier.ClientID%>").value = $('#<%=chk400FloorMetalBarrier.ClientID%>').val();

            document.getElementById("<%=hid400KneewallHeight.ClientID%>").value = $('#<%=txt400KneewallHeight.ClientID%>').val();
            document.getElementById("<%=hid400KneewallType.ClientID%>").value = $('#<%=ddl400KneewallType.ClientID%>').val();
            document.getElementById("<%=hid400KneewallGlassTint.ClientID%>").value = $('#<%=ddl400KneewallGlassTint.ClientID%>').val();

            document.getElementById("<%=hid400TransomHeight.ClientID%>").value = $('#<%=txt400TransomHeight.ClientID%>').val();
            document.getElementById("<%=hid400TransomType.ClientID%>").value = $('#<%=ddl400TransomType.ClientID%>').val();
            document.getElementById("<%=hid400TransomGlassTint.ClientID%>").value = $('#<%=ddl400TransomGlassTint.ClientID%>').val();
            document.getElementById("<%=hid400TransomVinylTint.ClientID%>").value = $('#<%=ddl400TransomVinylTint.ClientID%>').val();
            document.getElementById("<%=hid400TransomScreenType.ClientID%>").value = $('#<%=ddl400TransomScreenType.ClientID%>').val();

            document.getElementById("<%=hid400Markup.ClientID%>").value = $('#<%=txt400Markup.ClientID%>').val();
        }

        //This is valid to check all numeric fields, rather than having several smaller ones.  Will be pre-populated before change with valid numbers so risk of error spam is low
        //and can really only happen by manually making it do that intentionally.
        function ValidateNumericInput() {
            //Need to have newest values, so move them again just in case.
            MoveValuesToHiddenDivs();

            //Make message empty for the start, if still empty at end, no errors
            var errorMessage = "";

            //For each numeric field's model, check to be sure its entered, and that entered value is numeric.
            
            //Default Filler
            //100
            var defaultFiller100 = document.getElementById("<%=hid100DefaultFiller.ClientID%>").value;
            if (defaultFiller100 == "") {
                errorMessage += "Model 100 - Default Filler - Must be entered.<br/>";
            }

            if (isNaN(defaultFiller100)) {
                errorMessage += "Model 100 - Default Filler - Must be numeric.<br/>";
            }

            //200
            var defaultFiller200 = document.getElementById("<%=hid200DefaultFiller.ClientID%>").value;
            if (defaultFiller200 == "") {
                errorMessage += "Model 200 - Default Filler - Must be entered.<br/>";
            }
            
            if (isNaN(defaultFiller100)) {
                errorMessage += "Model 200 - Default Filler - Must be numeric<br/>";
            }

            //300
            var defaultFiller300 = document.getElementById("<%=hid300DefaultFiller.ClientID%>").value;
            if (defaultFiller300 == "") {
                errorMessage += "Model 300 - Default Filler - Must be entered.<br/>";
            }

            if (isNaN(defaultFiller300)) {
                errorMessage += "Model 300 - Default Filler - Must be numeric.<br/>";
            }

            //400
            var defaultFiller400 = document.getElementById("<%=hid400DefaultFiller.ClientID%>").value;
            if (defaultFiller400 == "") {
                errorMessage += "Model 400 - Default Filler - Must be entered.<br/>";
            }

            if (isNaN(defaultFiller300)) {
                errorMessage += "Model 400 - Default Filler - Must be numeric.<br/>";
            }

            //markup
            //100
            var markup100 = document.getElementById("<%=hid100Markup.ClientID%>").value;
            if (markup100 == "") {
                errorMessage += "Model 100 - Markup - Must be entered.<br/>";
            }

            if (isNaN(markup100)) {
                errorMessage += "Model 100 - Markup - Must be numeric.<br/>";
            }

            //200
            var markup200 = document.getElementById("<%=hid200Markup.ClientID%>").value;
            if (markup200 == "") {
                errorMessage += "Model 200 - Markup - Must be entered.<br/>";
            }

            if (isNaN(markup200)) {
                errorMessage += "Model 200 - Markup - Must be numeric.<br/>";
            }

            //300
            var markup300 = document.getElementById("<%=hid300Markup.ClientID%>").value;
            if (markup300 == "") {
                errorMessage += "Model 300 - Markup - Must be entered.<br/>";
            }

            if (isNaN(markup300)) {
                errorMessage += "Model 300 - Markup - Must be numeric.<br/>";
            }

            //400
            var markup400 = document.getElementById("<%=hid400Markup.ClientID%>").value;
            if (markup400 == "") {
                errorMessage += "Model 400 - Markup - Must be entered.<br/>";
            }

            if (isNaN(markup400)) {
                errorMessage += "Model 400 - Markup - Must be numeric.<br/>";
            }
            
            //kneewall height
            //100
            var kneewallHeight100 = document.getElementById("<%=hid100KneewallHeight.ClientID%>").value;
            if (kneewallHeight100 == "") {
                errorMessage += "Model 100 - Kneewall Height - Must be entered.<br/>";
            }

            if (isNaN(kneewallHeight100)) {
                errorMessage += "Model 100 - Kneewall Height - Must be numeric.<br/>";
            }

            //200
            var kneewallHeight200 = document.getElementById("<%=hid200KneewallHeight.ClientID%>").value;
            if (kneewallHeight200 == "") {
                errorMessage += "Model 200 - Kneewall Height - Must be entered.<br/>";
            }

            if (isNaN(kneewallHeight200)) {
                errorMessage += "Model 200 - Kneewall Height - Must be numeric.<br/>";
            }

            //300
            var kneewallHeight300 = document.getElementById("<%=hid300KneewallHeight.ClientID%>").value;
            if (kneewallHeight300 == "") {
                errorMessage += "Model 300 - Kneewall Height - Must be entered.<br/>";
            }

            if (isNaN(kneewallHeight300)) {
                errorMessage += "Model 300 - Kneewall Height - Must be numeric.<br/>";
            }

            //400
            var kneewallHeight400 = document.getElementById("<%=hid400KneewallHeight.ClientID%>").value;
            if (kneewallHeight400 == "") {
                errorMessage += "Model 400 - Kneewall Height - Must be entered.<br/>";
            }

            if (isNaN(kneewallHeight400)) {
                errorMessage += "Model 400 - Kneewall Height - Must be numeric.<br/>";
            }
            
            //transom height
            //100
            var transomHeight100 = document.getElementById("<%=hid100TransomHeight.ClientID%>").value;
            if (transomHeight100 == "") {
                errorMessage += "Model 100 - Transom Height - Must be entered.<br/>";
            }

            if (isNaN(transomHeight100)) {
                errorMessage += "Model 100 - Transom Height - Must be numeric.<br/>";
            }

            //200
            var transomHeight200 = document.getElementById("<%=hid200TransomHeight.ClientID%>").value;
            if (transomHeight200 == "") {
                errorMessage += "Model 200 - Transom Height - Must be entered.<br/>";
            }

            if (isNaN(transomHeight200)) {
                errorMessage += "Model 200 - Transom Height - Must be numeric.<br/>";
            }

            //300
            var transomHeight300 = document.getElementById("<%=hid300TransomHeight.ClientID%>").value;
            if (transomHeight300 == "") {
                errorMessage += "Model 300 - Transom Height - Must be entered.<br/>";
            }

            if (isNaN(transomHeight300)) {
                errorMessage += "Model 300 - Transom Height - Must be numeric.<br/>";
            }

            //400
            var transomHeight400 = document.getElementById("<%=hid400TransomHeight.ClientID%>").value;
            if (transomHeight400 == "") {
                errorMessage += "Model 400 - Transom Height - Must be entered.<br/>";
            }

            if (isNaN(transomHeight400)) {
                errorMessage += "Model 400 - Transom Height - Must be numeric.<br/>";
            }

            $('#<%=lblError.ClientID%>').html = errorMessage;
        }
    </script>
    <div>
        <asp:Label Text ="Welcome " ID="lblWelcome" runat="server"></asp:Label>
        <asp:Label Text ="*Insert User Name*" ID="lblUser" runat="server"></asp:Label>
    </div>

    <div class="slide-window no-sidebar">

        <div class="slide-wrapper">

            <div id="slide1" class="slide">
                <%-- fancy --%>
                <h1>
                    <asp:Label ID="lblError" runat="server"></asp:Label>
                    <asp:Label ID="lblPreferences" runat="server" Text="Set your preferences below"></asp:Label>
                </h1>        
                              
                <ul class="toggleOptions">

                    <%-- Sunroom Preferences --%>
                    <li>
                        <asp:RadioButton ID="radSunroomPref" GroupName="preferences" runat="server" />
                        <asp:Label ID="lblSunroomPrefRadio" AssociatedControlID="radSunroomPref" runat="server"></asp:Label>
                        <asp:Label ID="lblSunroomPref" AssociatedControlID="radSunroomPref" runat="server" Text="Sunroom Preferences"></asp:Label>
           
                        <div class="toggleContent">
                            <ul>
                                <li>
                                    <ul class="toggleOptions">
                                        <%-- General Preferences --%>
                                        <li>                                            
                                            <asp:RadioButton ID="radGeneralPref" GroupName="sunroomModels" runat="server" />
                                            <asp:Label ID="lblGeneralPrefRadio" AssociatedControlID="radGeneralPref" runat="server"></asp:Label>
                                            <asp:Label ID="lblGeneralPref" AssociatedControlID="radGeneralPref" runat="server" Text="General"></asp:Label>

                                            <%-- General Pref Inputs --%>
                                            <div class="toggleContent">
                                                <ul>
                                                    <li>
                                                        <%-- Installation Type --%>
                                                        <asp:Label ID="lblInstallationType" runat="server" Text="Installation Type:"></asp:Label>
                                                        <asp:DropDownList ID="ddlInstallationType" runat="server"></asp:DropDownList>
                                                    </li>
                                                    <li>
                                                        <%-- Model Type --%>
                                                        <asp:Label ID="lblModelNumber" runat="server" Text="Model Type:"></asp:Label>
                                                        <asp:DropDownList ID="ddlModelNumber" runat="server"></asp:DropDownList>
                                                    </li>
                                                    <li>
                                                        <%-- Layout --%>
                                                        <asp:Label ID="lblLayout" runat="server" Text="Layout Default:"></asp:Label>
                                                        <asp:DropDownList ID="ddlLayout" runat="server"></asp:DropDownList>
                                                    </li>                                                  
                                                    <li>
                                                        <%-- Cut Pitch Option --%>
                                                        <asp:CheckBox ID="chkCutPitch" runat="server" />
                                                        <asp:Label ID="lblCutPitchCheck" AssociatedControlID="chkCutPitch" runat="server"></asp:Label>
                                                        <asp:Label ID="lblCutPitch" AssociatedControlID="chkCutPitch" runat="server" Text="Cut Pitch"></asp:Label>                                                                
                                                    </li>
                                                </ul>
                                            </div>
                                        </li>

                                        <%-- Model 100 Preferences --%>
                                        <li>
                                            <asp:RadioButton ID="radSunroom100" GroupName="sunroomModels" runat="server" />
                                            <asp:Label ID="lblSunroom100Radio" AssociatedControlID="radSunroom100" runat="server"></asp:Label>
                                            <asp:Label ID="lblSunroom100" AssociatedControlID="radSunroom100" runat="server" Text="Model 100"></asp:Label>                                    
                                            
                                            <%-- Model 100 Inputs --%>
                                            <div class="toggleContent">
                                                <ul>
                                                    <li>
                                                        <ul class="toggleOptions">
                                                            <li>
                                                                <%-- Default Filler Option --%>
                                                                <asp:Label ID="lbl100DefaultFiller" runat="server" Text="Default Filler: "></asp:Label>
                                                                <asp:TextBox ID="txt100DefaultFiller" runat="server" CssClass="txtLengthInput" onkeydown="return (event.keyCode!=13);" onkeyup="ValidateNumericInput()"></asp:TextBox>
                                                                <asp:DropDownList ID="ddl100DefaultFiller" runat="server"></asp:DropDownList>
                                                            </li>                                                            
                                                            <li>
                                                                <%-- Markup --%>
                                                                <asp:Label ID="lbl100Markup" runat="server" Text="Markup:"></asp:Label>
                                                                <asp:TextBox ID="txt100Markup" runat="server" onkeydown="return (event.keyCode!=13);" onkeyup="ValidateNumericInput()"></asp:TextBox>
                                                            </li>  
                                                            <li>
                                                                <%-- Wall Colours --%>
                                                                <asp:RadioButton ID="rad100WallColours" GroupName="sunroomModel100" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl100WallColoursRadio" AssociatedControlID="rad100WallColours" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl100WallColours" AssociatedControlID="rad100WallColours" runat="server" Text="Wall Colours"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Frame Colour --%>
                                                                                    <asp:Label ID="lbl100FrameColour" runat="server" Text="Frame Colour:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100FrameColour" runat="server" OnChange="preferencesCascadeColours(100)"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Interior Panel Skin --%>
                                                                                    <asp:Label ID="lbl100InteriorPanelSkin" runat="server" Text="Interior Panel Skin:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100InteriorPanelSkin" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Exterior Panel Skin --%>
                                                                                    <asp:Label ID="lbl100ExteriorPanelSkin" runat="server" Text="Exterior Panel Skin:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100ExteriorPanelSkin" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Door options --%>
                                                                <asp:RadioButton ID="rad100DoorOptions" GroupName="sunroomModel100" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl100DoorOptionsRadio" AssociatedControlID="rad100DoorOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl100DoorOptions" AssociatedControlID="rad100DoorOptions" runat="server" Text="Door Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Door Type --%>
                                                                                    <asp:Label ID="lbl100DoorType" runat="server" Text="Door Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100DoorType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Style --%>
                                                                                    <asp:Label ID="lbl100DoorStyle" runat="server" Text="Door Style:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100DoorStyle" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Swing --%>
                                                                                    <asp:Label ID="lbl100DoorSwing" runat="server" Text="Door Swing:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100DoorSwing" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Hinge --%>
                                                                                    <asp:Label ID="lbl100DoorHinge" runat="server" Text="Door Hinge:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100DoorHinge" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Hardware --%>
                                                                                    <asp:Label ID="lbl100DoorHardware" runat="server" Text="Door Hardware:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100DoorHardware" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Colour --%>
                                                                                    <asp:Label ID="lbl100DoorColour" runat="server" Text="Door Colour:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100DoorColour" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Glass Tint --%>
                                                                                    <asp:Label ID="lbl100DoorGlassTint" runat="server" Text="Door Glass Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100DoorGlassTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Vinyl Tint --%>
                                                                                    <asp:Label ID="lbl100DoorVinylTint" runat="server" Text="Door Vinyl Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100DoorVinylTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Screen Type --%>
                                                                                    <asp:Label ID="lbl100DoorScreenType" runat="server" Text="Door Screen Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100DoorScreenType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Window options --%>
                                                                <asp:RadioButton ID="rad100WindowOptions" GroupName="sunroomModel100" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl100WindowOptionsRadio" AssociatedControlID="rad100WindowOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl100WindowOptions" AssociatedControlID="rad100WindowOptions" runat="server" Text="Window Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Window Type --%>
                                                                                    <asp:Label ID="lbl100WindowType" runat="server" Text="Window Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100WindowType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <%-- No Window colour for model 100, vinyl only --%>
                                                                                <li>
                                                                                    <%-- Window Glass Tint --%>
                                                                                    <asp:Label ID="lbl100WindowGlassTint" runat="server" Text="Window Glass Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100WindowGlassTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Window Vinyl Tint --%>
                                                                                    <asp:Label ID="lbl100WindowVinylTint" runat="server" Text="Window Vinyl Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100WindowVinylTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Window Screen Type --%>
                                                                                    <asp:Label ID="lbl100WindowScreenType" runat="server" Text="Window Screen Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100WindowScreenType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Sunshade options --%>
                                                                <asp:RadioButton ID="rad100SunshadeOptions" GroupName="sunroomModel100" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl100SunshadeOptionsRadio" AssociatedControlID="rad100SunshadeOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl100SunshadeOptions" AssociatedControlID="rad100SunshadeOptions" runat="server" Text="Sunshade Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Sunshade Valance Colour --%>
                                                                                    <asp:Label ID="lbl100SunshadeValanceColour" runat="server" Text="Sunshade Valance Colour:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100SunshadeValanceColour" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Sunshade Fabric --%>
                                                                                    <asp:Label ID="lbl100SunshadeFabricColour" runat="server" Text="Sunshade Fabric:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100SunshadeFabricColour" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Sunshade Openness --%>
                                                                                    <asp:Label ID="lbl100SunshadeOpenness" runat="server" Text="Sunshade Openness:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100SunshadeOpenness" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Roof options --%>
                                                                <asp:RadioButton ID="rad100RoofOptions" GroupName="sunroomModel100" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl100RoofOptionsRadio" AssociatedControlID="rad100RoofOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl100RoofOptions" AssociatedControlID="rad100RoofOptions" runat="server" Text="Roof Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Roof Type --%>
                                                                                    <asp:Label ID="lbl100RoofType" runat="server" Text="Roof Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100RoofType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Interior Skin --%>
                                                                                    <asp:Label ID="lbl100RoofInteriorSkin" runat="server" Text="Roof Interior Skin:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100RoofInteriorSkin" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Exterior Skin --%>
                                                                                    <asp:Label ID="lbl100RoofExteriorSkin" runat="server" Text="Roof Exterior Skin:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100RoofExteriorSkin" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Thickness --%>
                                                                                    <asp:Label ID="lbl100RoofThickness" runat="server" Text="Roof Thickness:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100RoofThickness" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Floor options --%>
                                                                <asp:RadioButton ID="rad100FloorOptions" GroupName="sunroomModel100" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl100FloorOptionsRadio" AssociatedControlID="rad100FloorOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl100FloorOptions" AssociatedControlID="rad100FloorOptions" runat="server" Text="Floor Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Thickness --%>
                                                                                    <asp:Label ID="lbl100FloorThickness" runat="server" Text="Floor Thickness:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100FloorThickness" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>                                                                                    
                                                                                    <%-- Metal Barrier --%>
                                                                                    <asp:CheckBox ID="chk100FloorMetalBarrier" runat="server" />
                                                                                    <asp:Label ID="lbl100FloorMetalBarrierCheck" AssociatedControlID="chk100FloorMetalBarrier" runat="server" ></asp:Label>
                                                                                    <asp:Label ID="lbl100FloorMetalBarrier" AssociatedControlID="chk100FloorMetalBarrier" runat="server" Text="Floor Metal Barrier:"></asp:Label>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Kneewall options --%>
                                                                <asp:RadioButton ID="rad100KneewallOptions" GroupName="sunroomModel100" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl100KneewallOptionsRadio" AssociatedControlID="rad100KneewallOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl100KneewallOptions" AssociatedControlID="rad100KneewallOptions" runat="server" Text="Kneewall Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Height --%>
                                                                                    <asp:Label ID="lbl100KneewallHeight" runat="server" Text="Kneewall Height:"></asp:Label>
                                                                                    <asp:TextBox ID="txt100KneewallHeight" runat="server" onkeydown="return (event.keyCode!=13);" onkeyup="ValidateNumericInput()"></asp:TextBox>
                                                                                    <asp:DropDownList ID="ddl100KneewallHeight" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Type --%>
                                                                                    <asp:Label ID="lbl100KneewallType" runat="server" Text="Kneewall Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100KneewallType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Glass Tint --%>
                                                                                    <asp:Label ID="lbl100KneewallGlassTint" runat="server" Text="Kneewall Glass Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100KneewallGlassTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Transom options --%>
                                                                <asp:RadioButton ID="rad100TransomOptions" GroupName="sunroomModel100" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl100TransomOptionsRadio" AssociatedControlID="rad100TransomOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl100TransomOptions" AssociatedControlID="rad100TransomOptions" runat="server" Text="Transom Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Height --%>
                                                                                    <asp:Label ID="lbl100TransomHeight" runat="server" Text="Transom Height:"></asp:Label>
                                                                                    <asp:TextBox ID="txt100TransomHeight" runat="server" onkeydown="return (event.keyCode!=13);" onkeyup="ValidateNumericInput()"></asp:TextBox>
                                                                                    <asp:DropDownList ID="ddl100TransomHeight" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- style --%>
                                                                                    <asp:Label ID="lbl100TransomType" runat="server" Text="Transom Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100TransomType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- glass tint --%>
                                                                                    <asp:Label ID="lbl100TransomGlassTint" runat="server" Text="Transom Glass Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100TransomGlassTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- vinyl tint --%>
                                                                                    <asp:Label ID="lbl100TransomVinylTint" runat="server" Text="Transom Vinyl Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100TransomVinylTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- screen type --%>
                                                                                    <asp:Label ID="lbl100TransomScreenType" runat="server" Text="Transom Screen Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl100TransomScreenType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                        </ul>
                                                        

                                                        <%--InteriorSkin
	                                                    ExteriorSkin
	                                                    DoorType/DoorSubtype/DoorOptions
	                                                    WindowType/WindowOptions
	                                                    PresetLayout
	                                                    InstallType
	                                                    Sunshades/SunshadeOptions
	                                                    RoofType/RoofOptions
	                                                    FloorType/FloorOptions
	                                                    KneewallOptions
	                                                    TransomOptions
	                                                    CutPitch
	                                                    DefaultFiller--%>
                                                    </li>                                            
                                                </ul>
                                            </div>
                                        </li>


                                        <%-- Model 200 Preferences --%>
                                        <li>
                                            <asp:RadioButton ID="radSunroom200" GroupName="sunroomModels" runat="server" />
                                            <asp:Label ID="lblSunroom200Radio" AssociatedControlID="radSunroom200" runat="server"></asp:Label>
                                            <asp:Label ID="lblSunroom200" AssociatedControlID="radSunroom200" runat="server" Text="Model 200"></asp:Label>
                                            
                                            <%-- Model 200 Inputs --%>
                                            <div class="toggleContent">
                                                <ul>
                                                    <li>
                                                        <ul class="toggleOptions">
                                                            <li>
                                                                <%-- Default Filler Option --%>
                                                                <asp:Label ID="lbl200DefaultFiller" runat="server" Text="Default Filler: "></asp:Label>
                                                                <asp:TextBox ID="txt200DefaultFiller" runat="server" onkeydown="return (event.keyCode!=13);" CssClass="txtLengthInput" onkeyup="ValidateNumericInput()"></asp:TextBox>
                                                                <asp:DropDownList ID="ddl200DefaultFiller" runat="server"></asp:DropDownList>
                                                            </li>                                                            
                                                            <li>
                                                                <%-- Markup --%>
                                                                <asp:Label ID="lbl200Markup" runat="server" Text="Markup:"></asp:Label>
                                                                <asp:TextBox ID="txt200Markup" runat="server" onkeydown="return (event.keyCode!=13);" onkeyup="ValidateNumericInput()"></asp:TextBox>
                                                            </li> 
                                                            <li>
                                                                <%-- Wall Colours --%>
                                                                <asp:RadioButton ID="rad200WallColours" GroupName="sunroomModel200" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl200WallColoursRadio" AssociatedControlID="rad200WallColours" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl200WallColours" AssociatedControlID="rad200WallColours" runat="server" Text="Wall Colours"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Frame Colour --%>
                                                                                    <asp:Label ID="lbl200FrameColour" runat="server" Text="Frame Colour:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200FrameColour" runat="server" OnChange="preferencesCascadeColours(200)"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Interior Panel Skin --%>
                                                                                    <asp:Label ID="lbl200InteriorPanelSkin" runat="server" Text="Interior Panel Skin:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200InteriorPanelSkin" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Exterior Panel Skin --%>
                                                                                    <asp:Label ID="lbl200ExteriorPanelSkin" runat="server" Text="Exterior Panel Skin:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200ExteriorPanelSkin" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Door options --%>
                                                                <asp:RadioButton ID="rad200DoorOptions" GroupName="sunroomModel200" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl200DoorOptionsRadio" AssociatedControlID="rad200DoorOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl200DoorOptions" AssociatedControlID="rad200DoorOptions" runat="server" Text="Door Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Door Type --%>
                                                                                    <asp:Label ID="lbl200DoorType" runat="server" Text="Door Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200DoorType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Style --%>
                                                                                    <asp:Label ID="lbl200DoorStyle" runat="server" Text="Door Style:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200DoorStyle" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Swing --%>
                                                                                    <asp:Label ID="lbl200DoorSwing" runat="server" Text="Door Swing:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200DoorSwing" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Hinge --%>
                                                                                    <asp:Label ID="lbl200DoorHinge" runat="server" Text="Door Hinge:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200DoorHinge" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Hardware --%>
                                                                                    <asp:Label ID="lbl200DoorHardware" runat="server" Text="Door Hardware:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200DoorHardware" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Colour --%>
                                                                                    <asp:Label ID="lbl200DoorColour" runat="server" Text="Door Colour:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200DoorColour" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Glass Tint --%>
                                                                                    <asp:Label ID="lbl200DoorGlassTint" runat="server" Text="Door Glass Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200DoorGlassTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Vinyl Tint --%>
                                                                                    <asp:Label ID="lbl200DoorVinylTint" runat="server" Text="Door Vinyl Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200DoorVinylTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Screen Type --%>
                                                                                    <asp:Label ID="lbl200DoorScreenType" runat="server" Text="Door Screen Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200DoorScreenType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Window options --%>
                                                                <asp:RadioButton ID="rad200WindowOptions" GroupName="sunroomModel200" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl200WindowOptionsRadio" AssociatedControlID="rad200WindowOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl200WindowOptions" AssociatedControlID="rad200WindowOptions" runat="server" Text="Window Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Window Type --%>
                                                                                    <asp:Label ID="lbl200WindowType" runat="server" Text="Window Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200WindowType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Window Colour --%>
                                                                                    <asp:Label ID="lbl200WindowColour" runat="server" Text="Window Colour:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200WindowColour" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Window Glass Tint --%>
                                                                                    <asp:Label ID="lbl200WindowGlassTint" runat="server" Text="Window Glass Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200WindowGlassTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Window Vinyl Tint --%>
                                                                                    <asp:Label ID="lbl200WindowVinylTint" runat="server" Text="Window Vinyl Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200WindowVinylTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Window Screen Type --%>
                                                                                    <asp:Label ID="lbl200WindowScreenType" runat="server" Text="Window Screen Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200WindowScreenType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Sunshade options --%>
                                                                <asp:RadioButton ID="rad200SunshadeOptions" GroupName="sunroomModel200" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl200SunshadeOptionsRadio" AssociatedControlID="rad200SunshadeOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl200SunshadeOptions" AssociatedControlID="rad200SunshadeOptions" runat="server" Text="Sunshade Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Sunshade Valance Colour --%>
                                                                                    <asp:Label ID="lbl200SunshadeValanceColour" runat="server" Text="Sunshade Valance Colour:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200SunshadeValanceColour" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Sunshade Fabric --%>
                                                                                    <asp:Label ID="lbl200SunshadeFabricColour" runat="server" Text="Sunshade Fabric:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200SunshadeFabricColour" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Sunshade Openness --%>
                                                                                    <asp:Label ID="lbl200SunshadeOpenness" runat="server" Text="Sunshade Openness:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200SunshadeOpenness" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Roof options --%>
                                                                <asp:RadioButton ID="rad200RoofOptions" GroupName="sunroomModel200" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl200RoofOptionsRadio" AssociatedControlID="rad200RoofOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl200RoofOptions" AssociatedControlID="rad200RoofOptions" runat="server" Text="Roof Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Roof Type --%>
                                                                                    <asp:Label ID="lbl200RoofType" runat="server" Text="Roof Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200RoofType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Interior Skin --%>
                                                                                    <asp:Label ID="lbl200RoofInteriorSkin" runat="server" Text="Roof Interior Skin:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200RoofInteriorSkin" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Exterior Skin --%>
                                                                                    <asp:Label ID="lbl200RoofExteriorSkin" runat="server" Text="Roof Exterior Skin:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200RoofExteriorSkin" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Thickness --%>
                                                                                    <asp:Label ID="lbl200RoofThickness" runat="server" Text="Roof Thickness:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200RoofThickness" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Floor options --%>
                                                                <asp:RadioButton ID="rad200FloorOptions" GroupName="sunroomModel200" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl200FloorOptionsRadio" AssociatedControlID="rad200FloorOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl200FloorOptions" AssociatedControlID="rad200FloorOptions" runat="server" Text="Floor Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Thickness --%>
                                                                                    <asp:Label ID="lbl200FloorThickness" runat="server" Text="Floor Thickness:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200FloorThickness" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>                                                                                    
                                                                                    <%-- Metal Barrier --%>
                                                                                    <asp:CheckBox ID="chk200FloorMetalBarrier" runat="server" />
                                                                                    <asp:Label ID="lbl200FloorMetalBarrierCheck" AssociatedControlID="chk200FloorMetalBarrier" runat="server" ></asp:Label>
                                                                                    <asp:Label ID="lbl200FloorMetalBarrier" AssociatedControlID="chk200FloorMetalBarrier" runat="server" Text="Floor Metal Barrier:"></asp:Label>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Kneewall options --%>
                                                                <asp:RadioButton ID="rad200KneewallOptions" GroupName="sunroomModel200" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl200KneewallOptionsRadio" AssociatedControlID="rad200KneewallOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl200KneewallOptions" AssociatedControlID="rad200KneewallOptions" runat="server" Text="Kneewall Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Height --%>
                                                                                    <asp:Label ID="lbl200KneewallHeight" runat="server" Text="Kneewall Height:"></asp:Label>
                                                                                    <asp:TextBox ID="txt200KneewallHeight" runat="server" onkeydown="return (event.keyCode!=13);" onkeyup="ValidateNumericInput()"></asp:TextBox>
                                                                                    <asp:DropDownList ID="ddl200KneewallHeight" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Type --%>
                                                                                    <asp:Label ID="lbl200KneewallType" runat="server" Text="Kneewall Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200KneewallType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Glass Tint --%>
                                                                                    <asp:Label ID="lbl200KneewallGlassTint" runat="server" Text="Kneewall Glass Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200KneewallGlassTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Transom options --%>
                                                                <asp:RadioButton ID="rad200TransomOptions" GroupName="sunroomModel200" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl200TransomOptionsRadio" AssociatedControlID="rad200TransomOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl200TransomOptions" AssociatedControlID="rad200TransomOptions" runat="server" Text="Transom Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Height --%>
                                                                                    <asp:Label ID="lbl200TransomHeight" runat="server" Text="Transom Height:"></asp:Label>
                                                                                    <asp:TextBox ID="txt200TransomHeight" runat="server" onkeydown="return (event.keyCode!=13);" onkeyup="ValidateNumericInput()"></asp:TextBox>
                                                                                    <asp:DropDownList ID="ddl200TransomHeight" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- style --%>
                                                                                    <asp:Label ID="lbl200TransomType" runat="server" Text="Transom Style:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200TransomType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- glass tint --%>
                                                                                    <asp:Label ID="lbl200TransomGlassTint" runat="server" Text="Transom Glass Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200TransomGlassTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- vinyl tint --%>
                                                                                    <asp:Label ID="lbl200TransomVinylTint" runat="server" Text="Transom Vinyl Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200TransomVinylTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- screen type --%>
                                                                                    <asp:Label ID="lbl200TransomScreenType" runat="server" Text="Transom Screen Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl200TransomScreenType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                        </ul>
                                                        

                                                        <%--InteriorSkin
	                                                    ExteriorSkin
	                                                    DoorType/DoorSubtype/DoorOptions
	                                                    WindowType/WindowOptions
	                                                    PresetLayout
	                                                    InstallType
	                                                    Sunshades/SunshadeOptions
	                                                    RoofType/RoofOptions
	                                                    FloorType/FloorOptions
	                                                    KneewallOptions
	                                                    TransomOptions
	                                                    CutPitch
	                                                    DefaultFiller--%>
                                                    </li>                                            
                                                </ul>
                                            </div>
                                        </li>


                                        <%-- Model 300 Preferences --%>
                                        <li>
                                            <asp:RadioButton ID="radSunroom300" GroupName="sunroomModels" runat="server" />
                                            <asp:Label ID="lblSunroom300Radio" AssociatedControlID="radSunroom300" runat="server"></asp:Label>
                                            <asp:Label ID="lblSunroom300" AssociatedControlID="radSunroom300" runat="server" Text="Model 300"></asp:Label>

                                            
                                            <%-- Model 300 Inputs --%>
                                            <div class="toggleContent">
                                                <ul>
                                                    <li>
                                                        <ul class="toggleOptions">
                                                            <li>
                                                                <%-- Default Filler Option --%>
                                                                <asp:Label ID="lbl300DefaultFiller" runat="server" Text="Default Filler: "></asp:Label>
                                                                <asp:TextBox ID="txt300DefaultFiller" runat="server" onkeydown="return (event.keyCode!=13);" CssClass="txtLengthInput" onkeyup="ValidateNumericInput()"></asp:TextBox>
                                                                <asp:DropDownList ID="ddl300DefaultFiller" runat="server"></asp:DropDownList>
                                                            </li>                                                            
                                                            <li>
                                                                <%-- Markup --%>
                                                                <asp:Label ID="lbl300Markup" runat="server" Text="Markup:"></asp:Label>
                                                                <asp:TextBox ID="txt300Markup" runat="server" onkeydown="return (event.keyCode!=13);" onkeyup="ValidateNumericInput()"></asp:TextBox>
                                                            </li> 
                                                            <li>
                                                                <%-- Wall Colours --%>
                                                                <asp:RadioButton ID="rad300WallColours" GroupName="sunroomModel300" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl300WallColoursRadio" AssociatedControlID="rad300WallColours" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl300WallColours" AssociatedControlID="rad300WallColours" runat="server" Text="Wall Colours"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Frame Colour --%>
                                                                                    <asp:Label ID="lbl300FrameColour" runat="server" Text="Frame Colour:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300FrameColour" runat="server" OnChange="preferencesCasecadeColours(300)"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Interior Panel Skin --%>
                                                                                    <asp:Label ID="lbl300InteriorPanelSkin" runat="server" Text="Interior Panel Skin:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300InteriorPanelSkin" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Exterior Panel Skin --%>
                                                                                    <asp:Label ID="lbl300ExteriorPanelSkin" runat="server" Text="Exterior Panel Skin:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300ExteriorPanelSkin" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Door options --%>
                                                                <asp:RadioButton ID="rad300DoorOptions" GroupName="sunroomModel300" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl300DoorOptionsRadio" AssociatedControlID="rad300DoorOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl300DoorOptions" AssociatedControlID="rad300DoorOptions" runat="server" Text="Door Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Door Type --%>
                                                                                    <asp:Label ID="lbl300DoorType" runat="server" Text="Door Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300DoorType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Style --%>
                                                                                    <asp:Label ID="lbl300DoorStyle" runat="server" Text="Door Style:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300DoorStyle" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Swing --%>
                                                                                    <asp:Label ID="lbl300DoorSwing" runat="server" Text="Door Swing:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300DoorSwing" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Hinge --%>
                                                                                    <asp:Label ID="lbl300DoorHinge" runat="server" Text="Door Hinge:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300DoorHinge" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Hardware --%>
                                                                                    <asp:Label ID="lbl300DoorHardware" runat="server" Text="Door Hardware:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300DoorHardware" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Colour --%>
                                                                                    <asp:Label ID="lbl300DoorColour" runat="server" Text="Door Colour:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300DoorColour" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Glass Tint --%>
                                                                                    <asp:Label ID="lbl300DoorGlassTint" runat="server" Text="Door Glass Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300DoorGlassTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Vinyl Tint --%>
                                                                                    <asp:Label ID="lbl300DoorVinylTint" runat="server" Text="Door Vinyl Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300DoorVinylTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Screen Type --%>
                                                                                    <asp:Label ID="lbl300DoorScreenType" runat="server" Text="Door Screen Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300DoorScreenType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Window options --%>
                                                                <asp:RadioButton ID="rad300WindowOptions" GroupName="sunroomModel300" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl300WindowOptionsRadio" AssociatedControlID="rad300WindowOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl300WindowOptions" AssociatedControlID="rad300WindowOptions" runat="server" Text="Window Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Window Type --%>
                                                                                    <asp:Label ID="lbl300WindowType" runat="server" Text="Window Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300WindowType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Window Colour --%>
                                                                                    <asp:Label ID="lbl300WindowColour" runat="server" Text="Window Colour:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300WindowColour" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Window Glass Tint --%>
                                                                                    <asp:Label ID="lbl300WindowGlassTint" runat="server" Text="Window Glass Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300WindowGlassTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Window Vinyl Tint --%>
                                                                                    <asp:Label ID="lbl300WindowVinylTint" runat="server" Text="Window Vinyl Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300WindowVinylTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Window Screen Type --%>
                                                                                    <asp:Label ID="lbl300WindowScreenType" runat="server" Text="Window Screen Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300WindowScreenType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Sunshade options --%>
                                                                <asp:RadioButton ID="rad300SunshadeOptions" GroupName="sunroomModel300" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl300SunshadeOptionsRadio" AssociatedControlID="rad300SunshadeOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl300SunshadeOptions" AssociatedControlID="rad300SunshadeOptions" runat="server" Text="Sunshade Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Sunshade Valance Colour --%>
                                                                                    <asp:Label ID="lbl300SunshadeValanceColour" runat="server" Text="Sunshade Valance Colour:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300SunshadeValanceColour" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Sunshade Fabric --%>
                                                                                    <asp:Label ID="lbl300SunshadeFabricColour" runat="server" Text="Sunshade Fabric:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300SunshadeFabricColour" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Sunshade Openness --%>
                                                                                    <asp:Label ID="lbl300SunshadeOpenness" runat="server" Text="Sunshade Openness:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300SunshadeOpenness" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Roof options --%>
                                                                <asp:RadioButton ID="rad300RoofOptions" GroupName="sunroomModel300" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl300RoofOptionsRadio" AssociatedControlID="rad300RoofOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl300RoofOptions" AssociatedControlID="rad300RoofOptions" runat="server" Text="Roof Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Roof Type --%>
                                                                                    <asp:Label ID="lbl300RoofType" runat="server" Text="Roof Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300RoofType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Interior Skin --%>
                                                                                    <asp:Label ID="lbl300RoofInteriorSkin" runat="server" Text="Roof Interior Skin:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300RoofInteriorSkin" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Exterior Skin --%>
                                                                                    <asp:Label ID="lbl300RoofExteriorSkin" runat="server" Text="Roof Exterior Skin:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300RoofExteriorSkin" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Thickness --%>
                                                                                    <asp:Label ID="lbl300RoofThickness" runat="server" Text="Roof Thickness:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300RoofThickness" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Floor options --%>
                                                                <asp:RadioButton ID="rad300FloorOptions" GroupName="sunroomModel300" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl300FloorOptionsRadio" AssociatedControlID="rad300FloorOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl300FloorOptions" AssociatedControlID="rad300FloorOptions" runat="server" Text="Floor Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Thickness --%>
                                                                                    <asp:Label ID="lbl300FloorThickness" runat="server" Text="Floor Thickness:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300FloorThickness" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>                                                                                    
                                                                                    <%-- Metal Barrier --%>
                                                                                    <asp:CheckBox ID="chk300FloorMetalBarrier" runat="server" />
                                                                                    <asp:Label ID="lbl300FloorMetalBarrierCheck" AssociatedControlID="chk300FloorMetalBarrier" runat="server" ></asp:Label>
                                                                                    <asp:Label ID="lbl300FloorMetalBarrier" AssociatedControlID="chk300FloorMetalBarrier" runat="server" Text="Floor Metal Barrier:"></asp:Label>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Kneewall options --%>
                                                                <asp:RadioButton ID="rad300KneewallOptions" GroupName="sunroomModel300" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl300KneewallOptionsRadio" AssociatedControlID="rad300KneewallOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl300KneewallOptions" AssociatedControlID="rad300KneewallOptions" runat="server" Text="Kneewall Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Height --%>
                                                                                    <asp:Label ID="lbl300KneewallHeight" runat="server" Text="Kneewall Height:"></asp:Label>
                                                                                    <asp:TextBox ID="txt300KneewallHeight" runat="server" onkeydown="return (event.keyCode!=13);" onkeyup="ValidateNumericInput()"></asp:TextBox>
                                                                                    <asp:DropDownList ID="ddl300KneewallHeight" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Type --%>
                                                                                    <asp:Label ID="lbl300KneewallType" runat="server" Text="Kneewall Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300KneewallType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Glass Tint --%>
                                                                                    <asp:Label ID="lbl300KneewallGlassTint" runat="server" Text="Kneewall Glass Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300KneewallGlassTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Transom options --%>
                                                                <asp:RadioButton ID="rad300TransomOptions" GroupName="sunroomModel300" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl300TransomOptionsRadio" AssociatedControlID="rad300TransomOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl300TransomOptions" AssociatedControlID="rad300TransomOptions" runat="server" Text="Transom Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Height --%>
                                                                                    <asp:Label ID="lbl300TransomHeight" runat="server" Text="Transom Height:"></asp:Label>
                                                                                    <asp:TextBox ID="txt300TransomHeight" runat="server" onkeydown="return (event.keyCode!=13);" onkeyup="ValidateNumericInput()"></asp:TextBox>
                                                                                    <asp:DropDownList ID="ddl300TransomHeight" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- style --%>
                                                                                    <asp:Label ID="lbl300TransomType" runat="server" Text="Transom Style:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300TransomType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- glass tint --%>
                                                                                    <asp:Label ID="lbl300TransomGlassTint" runat="server" Text="Transom Glass Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300TransomGlassTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- vinyl tint --%>
                                                                                    <asp:Label ID="lbl300TransomVinylTint" runat="server" Text="Transom Vinyl Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300TransomVinylTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- screen type --%>
                                                                                    <asp:Label ID="lbl300TransomScreenType" runat="server" Text="Transom Screen Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl300TransomScreenType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                        </ul>
                                                        

                                                        <%--InteriorSkin
	                                                    ExteriorSkin
	                                                    DoorType/DoorSubtype/DoorOptions
	                                                    WindowType/WindowOptions
	                                                    PresetLayout
	                                                    InstallType
	                                                    Sunshades/SunshadeOptions
	                                                    RoofType/RoofOptions
	                                                    FloorType/FloorOptions
	                                                    KneewallOptions
	                                                    TransomOptions
	                                                    CutPitch
	                                                    DefaultFiller--%>
                                                    </li>                                            
                                                </ul>
                                            </div>
                                        </li>


                                        <%-- Model 400 Preferences --%>
                                        <li>
                                            <asp:RadioButton ID="radSunroom400" GroupName="sunroomModels" runat="server" />
                                            <asp:Label ID="lblSunroom400Radio" AssociatedControlID="radSunroom400" runat="server"></asp:Label>
                                            <asp:Label ID="lblSunroom400" AssociatedControlID="radSunroom400" runat="server" Text="Model 400"></asp:Label>

                                            
                                            <%-- Model 400 Inputs --%>
                                            <div class="toggleContent">
                                                <ul>
                                                    <li>
                                                        <ul class="toggleOptions">
                                                            <li>
                                                                <%-- Default Filler Option --%>
                                                                <asp:Label ID="lbl400DefaultFiller" runat="server" Text="Default Filler: "></asp:Label>
                                                                <asp:TextBox ID="txt400DefaultFiller" runat="server" CssClass="txtLengthInput" onkeydown="return (event.keyCode!=13);" onkeyup="ValidateNumericInput()"></asp:TextBox>
                                                                <asp:DropDownList ID="ddl400DefaultFiller" runat="server"></asp:DropDownList>
                                                            </li>                                                            
                                                            <li>
                                                                <%-- Markup --%>
                                                                <asp:Label ID="lbl400Markup" runat="server" Text="Markup:"></asp:Label>
                                                                <asp:TextBox ID="txt400Markup" runat="server" onkeydown="return (event.keyCode!=13);" onkeyup="ValidateNumericInput()"></asp:TextBox>
                                                            </li> 
                                                            <li>
                                                                <%-- Wall Colours --%>
                                                                <asp:RadioButton ID="rad400WallColours" GroupName="sunroomModel400" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl400WallColoursRadio" AssociatedControlID="rad400WallColours" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl400WallColours" AssociatedControlID="rad400WallColours" runat="server" Text="Wall Colours"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Frame Colour --%>
                                                                                    <asp:Label ID="lbl400FrameColour" runat="server" Text="Frame Colour:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400FrameColour" runat="server" OnChange="preferencesCascadeColours(400)"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Interior Panel Skin --%>
                                                                                    <asp:Label ID="lbl400InteriorPanelSkin" runat="server" Text="Interior Panel Skin:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400InteriorPanelSkin" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Exterior Panel Skin --%>
                                                                                    <asp:Label ID="lbl400ExteriorPanelSkin" runat="server" Text="Exterior Panel Skin:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400ExteriorPanelSkin" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Door options --%>
                                                                <asp:RadioButton ID="rad400DoorOptions" GroupName="sunroomModel400" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl400DoorOptionsRadio" AssociatedControlID="rad400DoorOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl400DoorOptions" AssociatedControlID="rad400DoorOptions" runat="server" Text="Door Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Door Type --%>
                                                                                    <asp:Label ID="lbl400DoorType" runat="server" Text="Door Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400DoorType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Style --%>
                                                                                    <asp:Label ID="lbl400DoorStyle" runat="server" Text="Door Style:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400DoorStyle" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Swing --%>
                                                                                    <asp:Label ID="lbl400DoorSwing" runat="server" Text="Door Swing:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400DoorSwing" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Hinge --%>
                                                                                    <asp:Label ID="lbl400DoorHinge" runat="server" Text="Door Hinge:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400DoorHinge" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Hardware --%>
                                                                                    <asp:Label ID="lbl400DoorHardware" runat="server" Text="Door Hardware:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400DoorHardware" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Colour --%>
                                                                                    <asp:Label ID="lbl400DoorColour" runat="server" Text="Door Colour:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400DoorColour" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Glass Tint --%>
                                                                                    <asp:Label ID="lbl400DoorGlassTint" runat="server" Text="Door Glass Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400DoorGlassTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Vinyl Tint --%>
                                                                                    <asp:Label ID="lbl400DoorVinylTint" runat="server" Text="Door Vinyl Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400DoorVinylTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Door Screen Type --%>
                                                                                    <asp:Label ID="lbl400DoorScreenType" runat="server" Text="Door Screen Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400DoorScreenType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Window options --%>
                                                                <asp:RadioButton ID="rad400WindowOptions" GroupName="sunroomModel400" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl400WindowOptionsRadio" AssociatedControlID="rad400WindowOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl400WindowOptions" AssociatedControlID="rad400WindowOptions" runat="server" Text="Window Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Window Type --%>
                                                                                    <asp:Label ID="lbl400WindowType" runat="server" Text="Window Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400WindowType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Window Colour --%>
                                                                                    <asp:Label ID="lbl400WindowColour" runat="server" Text="Window Colour:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400WindowColour" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Window Glass Tint --%>
                                                                                    <asp:Label ID="lbl400WindowGlassTint" runat="server" Text="Window Glass Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400WindowGlassTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Window Vinyl Tint --%>
                                                                                    <asp:Label ID="lbl400WindowVinylTint" runat="server" Text="Window Vinyl Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400WindowVinylTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Window Screen Type --%>
                                                                                    <asp:Label ID="lbl400WindowScreenType" runat="server" Text="Window Screen Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400WindowScreenType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Sunshade options --%>
                                                                <asp:RadioButton ID="rad400SunshadeOptions" GroupName="sunroomModel400" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl400SunshadeOptionsRadio" AssociatedControlID="rad400SunshadeOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl400SunshadeOptions" AssociatedControlID="rad400SunshadeOptions" runat="server" Text="Sunshade Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Sunshade Valance Colour --%>
                                                                                    <asp:Label ID="lbl400SunshadeValanceColour" runat="server" Text="Sunshade Valance Colour:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400SunshadeValanceColour" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Sunshade Fabric --%>
                                                                                    <asp:Label ID="lbl400SunshadeFabricColour" runat="server" Text="Sunshade Fabric:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400SunshadeFabricColour" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Sunshade Openness --%>
                                                                                    <asp:Label ID="lbl400SunshadeOpenness" runat="server" Text="Sunshade Openness:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400SunshadeOpenness" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Roof options --%>
                                                                <asp:RadioButton ID="rad400RoofOptions" GroupName="sunroomModel400" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl400RoofOptionsRadio" AssociatedControlID="rad400RoofOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl400RoofOptions" AssociatedControlID="rad400RoofOptions" runat="server" Text="Roof Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Roof Type --%>
                                                                                    <asp:Label ID="lbl400RoofType" runat="server" Text="Roof Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400RoofType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Interior Skin --%>
                                                                                    <asp:Label ID="lbl400RoofInteriorSkin" runat="server" Text="Roof Interior Skin:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400RoofInteriorSkin" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Exterior Skin --%>
                                                                                    <asp:Label ID="lbl400RoofExteriorSkin" runat="server" Text="Roof Exterior Skin:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400RoofExteriorSkin" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Thickness --%>
                                                                                    <asp:Label ID="lbl400RoofThickness" runat="server" Text="Roof Thickness:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400RoofThickness" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Floor options --%>
                                                                <asp:RadioButton ID="rad400FloorOptions" GroupName="sunroomModel400" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl400FloorOptionsRadio" AssociatedControlID="rad400FloorOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl400FloorOptions" AssociatedControlID="rad400FloorOptions" runat="server" Text="Floor Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Thickness --%>
                                                                                    <asp:Label ID="lbl400FloorThickness" runat="server" Text="Floor Thickness:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400FloorThickness" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>                                                                                    
                                                                                    <%-- Metal Barrier --%>
                                                                                    <asp:CheckBox ID="chk400FloorMetalBarrier" runat="server" />
                                                                                    <asp:Label ID="lbl400FloorMetalBarrierCheck" AssociatedControlID="chk400FloorMetalBarrier" runat="server" ></asp:Label>
                                                                                    <asp:Label ID="lbl400FloorMetalBarrier" AssociatedControlID="chk400FloorMetalBarrier" runat="server" Text="Floor Metal Barrier:"></asp:Label>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Kneewall options --%>
                                                                <asp:RadioButton ID="rad400KneewallOptions" GroupName="sunroomModel400" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl400KneewallOptionsRadio" AssociatedControlID="rad400KneewallOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl400KneewallOptions" AssociatedControlID="rad400KneewallOptions" runat="server" Text="Kneewall Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Height --%>
                                                                                    <asp:Label ID="lbl400KneewallHeight" runat="server" Text="Kneewall Height:"></asp:Label>
                                                                                    <asp:TextBox ID="txt400KneewallHeight" runat="server" onkeydown="return (event.keyCode!=13);" onkeyup="ValidateNumericInput()"></asp:TextBox>
                                                                                    <asp:DropDownList ID="ddl400KneewallHeight" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Type --%>
                                                                                    <asp:Label ID="lbl400KneewallType" runat="server" Text="Kneewall Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400KneewallType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- Glass Tint --%>
                                                                                    <asp:Label ID="lbl400KneewallGlassTint" runat="server" Text="Kneewall Glass Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400KneewallGlassTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <%-- Transom options --%>
                                                                <asp:RadioButton ID="rad400TransomOptions" GroupName="sunroomModel400" runat="server"></asp:RadioButton>
                                                                <asp:Label ID="lbl400TransomOptionsRadio" AssociatedControlID="rad400TransomOptions" runat="server"></asp:Label>
                                                                <asp:Label ID="lbl400TransomOptions" AssociatedControlID="rad400TransomOptions" runat="server" Text="Transom Options"></asp:Label>
                                                                <div class="toggleContent">
                                                                    <ul>
                                                                        <li>
                                                                            <ul class="toggleOptions">
                                                                                <li>
                                                                                    <%-- Height --%>
                                                                                    <asp:Label ID="lbl400TransomHeight" runat="server" Text="Transom Height:"></asp:Label>
                                                                                    <asp:TextBox ID="txt400TransomHeight" runat="server" onkeydown="return (event.keyCode!=13);" onkeyup="ValidateNumericInput()"></asp:TextBox>
                                                                                    <asp:DropDownList ID="ddl400TransomHeight" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- style --%>
                                                                                    <asp:Label ID="lbl400TransomType" runat="server" Text="Transom Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400TransomType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- glass tint --%>
                                                                                    <asp:Label ID="lbl400TransomGlassTint" runat="server" Text="Transom Glass Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400TransomGlassTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- vinyl tint --%>
                                                                                    <asp:Label ID="lbl400TransomVinylTint" runat="server" Text="Transom Vinyl Tint:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400TransomVinylTint" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                                <li>
                                                                                    <%-- screen type --%>
                                                                                    <asp:Label ID="lbl400TransomScreenType" runat="server" Text="Transom Screen Type:"></asp:Label>
                                                                                    <asp:DropDownList ID="ddl400TransomScreenType" runat="server"></asp:DropDownList>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </li>
                                                        </ul>
                                                        

                                                        <%--InteriorSkin
	                                                    ExteriorSkin
	                                                    DoorType/DoorSubtype/DoorOptions
	                                                    WindowType/WindowOptions
	                                                    PresetLayout
	                                                    InstallType
	                                                    Sunshades/SunshadeOptions
	                                                    RoofType/RoofOptions
	                                                    FloorType/FloorOptions
	                                                    KneewallOptions
	                                                    TransomOptions
	                                                    CutPitch
	                                                    DefaultFiller--%>
                                                    </li>                                            
                                                </ul>
                                            </div>
                                        </li>
                                    </ul>
                                </li>
                            </ul>
                        </div>
                    </li>

                    <%-- Company Details --%>
                    <li>
                        <asp:RadioButton ID="radCompanyDetails" GroupName="preferences" runat="server" />
                        <asp:Label ID="lblCompanyDetailsRadio" AssociatedControlID="radCompanyDetails" runat="server"></asp:Label>
                        <asp:Label ID="lblCompanyDetails" AssociatedControlID="radCompanyDetails" runat="server" Text="Company Details"></asp:Label>

                        <div class="toggleContent">
                            <ul>
                                <li>                                        
                                    <asp:Label ID="lblCompanyNameInput" runat="server" Text="Company Name Input: "></asp:Label>
                                    <asp:TextBox ID="txtCompanyNameInput" onkeydown="return (event.keyCode!=13);" CssClass="txtField txtInput" runat="server"></asp:TextBox>
                                </li>
                            </ul>
                        </div>
                    </li>


                    <%-- Price Calculator Preferences --%>
                    <li>
                        <asp:RadioButton ID="radPriceCalc" GroupName="preferences" runat="server" />
                        <asp:Label ID="lblPriceCalcRadio" AssociatedControlID="radPriceCalc" runat="server"></asp:Label>
                        <asp:Label ID="lblPriceCalc" AssociatedControlID="radPriceCalc" runat="server" Text="Price Calculator Preferences"></asp:Label>
                    </li>


                    <%-- Shipping Address --%>
                    <li>
                        <asp:RadioButton ID="radShippingAddress" GroupName="preferences" runat="server" />
                        <asp:Label ID="lblShippingAddressRadio" AssociatedControlID="radShippingAddress" runat="server"></asp:Label>
                        <asp:Label ID="lblShippingAddress" AssociatedControlID="radShippingAddress" runat="server" Text="Shipping Address"></asp:Label>
                    </li>


                    <%-- Billing Address --%>
                    <li>
                        <asp:RadioButton ID="radBillingAddress" GroupName="preferences" runat="server" />
                        <asp:Label ID="lblBillingAddressRadio" AssociatedControlID="radBillingAddress" runat="server"></asp:Label>
                        <asp:Label ID="lblBillingAddress" AssociatedControlID="radBillingAddress" runat="server" Text="Billing Address"></asp:Label>
                    </li>


                    <%-- Invoice Data --%>
                    <li>
                        <asp:RadioButton ID="radInvoiceData" GroupName="preferences" runat="server" />
                        <asp:Label ID="lblInvoiceDataRadio" AssociatedControlID="radInvoiceData" runat="server"></asp:Label>
                        <asp:Label ID="lblInvoiceData" AssociatedControlID="radInvoiceData" runat="server" Text="Invoice Data (Sunspace CSR Only)"></asp:Label>
                    </li>
                </ul>
                
                <asp:Button ID="btnUpdate" runat="server" Text="Update Preferences" CssClass="btnSubmit float-right" OnClick="btnUpdate_Click" UseSubmitBehavior="False"/>
                <asp:SqlDataSource ID="sdsUsers" runat="server" ConnectionString="<%$ ConnectionStrings:sunspaceDealerDesktopConnectionString %>" SelectCommand="SELECT * FROM [users]"></asp:SqlDataSource>

            </div> <%-- end #slide1 --%>

        </div> <%-- end .slide-wrapper --%>
        
    </div> <%-- end .slide-window --%>

    <%-- Hidden input tags 
    ======================= --%>       
    <!-- General Preferences -->
    <input id="hidInstallationType" type="hidden" runat="server" />
    <input id="hidModelNumber" type="hidden" runat="server" />
    <input id="hidLayout" type="hidden" runat="server" />

    <!-- Start: Model 100 Hiddens -->   
    <input id="hid100DefaultFiller" type="hidden" runat="server" />

    <input id="hid100WallInteriorPanelColour" type="hidden" runat="server" />
    <input id="hid100WallInteriorPanelSkin" type="hidden" runat="server" />
    <input id="hid100WallExteriorPanelColour" type="hidden" runat="server" />
    <input id="hid100WallExteriorPanelSkin" type="hidden" runat="server" />
    <input id="hid100WallFrameColour" type="hidden" runat="server" />

    <input id="hid100DoorType" type="hidden" runat="server" />
    <input id="hid100DoorStyle" type="hidden" runat="server" />
    <input id="hid100DoorSwing" type="hidden" runat="server" />
    <input id="hid100DoorHinge" type="hidden" runat="server" />
    <input id="hid100DoorHardware" type="hidden" runat="server" />
    <input id="hid100DoorColour" type="hidden" runat="server" />
    <input id="hid100DoorGlassTint" type="hidden" runat="server" />
    <input id="hid100DoorVinylTint" type="hidden" runat="server" />
    <input id="hid100DoorScreenType" type="hidden" runat="server" />
   
    <input id="hid100WindowType" type="hidden" runat="server" />       
    <input id="hid100WindowColour" type="hidden" runat="server" />
    <input id="hid100WindowGlassTint" type="hidden" runat="server" />
    <input id="hid100WindowVinylTint" type="hidden" runat="server" />
    <input id="hid100WindowScreenType" type="hidden" runat="server" />
    
    <input id="hid100SunshadeValanceColour" type="hidden" runat="server" />
    <input id="hid100SunshadeFabricColour" type="hidden" runat="server" />
    <input id="hid100SunshadeOpenness" type="hidden" runat="server" />
    
    <input id="hid100RoofType" type="hidden" runat="server" />
    <input id="hid100RoofInteriorSkin" type="hidden" runat="server" />
    <input id="hid100RoofExteriorSkin" type="hidden" runat="server" />
    <input id="hid100RoofThickness" type="hidden" runat="server" />
    
    <input id="hid100FloorThickness" type="hidden" runat="server" />
    <input id="hid100FloorMetalBarrier" type="hidden" runat="server" />
    
    <input id="hid100KneewallHeight" type="hidden" runat="server" />
    <input id="hid100KneewallType" type="hidden" runat="server" />
    <input id="hid100KneewallGlassTint" type="hidden" runat="server" />
    
    <input id="hid100TransomHeight" type="hidden" runat="server" />
    <input id="hid100TransomType" type="hidden" runat="server" />
    <input id="hid100TransomGlassTint" type="hidden" runat="server" />
    <input id="hid100TransomVinylTint" type="hidden" runat="server" />
    <input id="hid100TransomScreenType" type="hidden" runat="server" />

    <input id="hid100Markup" type="hidden" runat="server" />
    <!-- End: Model 100 Hiddens -->

    <!-- Start: Model 200 Hiddens -->   
    <input id="hid200DefaultFiller" type="hidden" runat="server" />

    <input id="hid200WallInteriorPanelColour" type="hidden" runat="server" />
    <input id="hid200WallInteriorPanelSkin" type="hidden" runat="server" />
    <input id="hid200WallExteriorPanelColour" type="hidden" runat="server" />
    <input id="hid200WallExteriorPanelSkin" type="hidden" runat="server" />
    <input id="hid200WallFrameColour" type="hidden" runat="server" />

    <input id="hid200DoorType" type="hidden" runat="server" />
    <input id="hid200DoorStyle" type="hidden" runat="server" />
    <input id="hid200DoorSwing" type="hidden" runat="server" />
    <input id="hid200DoorHinge" type="hidden" runat="server" />
    <input id="hid200DoorHardware" type="hidden" runat="server" />
    <input id="hid200DoorColour" type="hidden" runat="server" />
    <input id="hid200DoorGlassTint" type="hidden" runat="server" />
    <input id="hid200DoorVinylTint" type="hidden" runat="server" />
    <input id="hid200DoorScreenType" type="hidden" runat="server" />
   
    <input id="hid200WindowType" type="hidden" runat="server" />       
    <input id="hid200WindowColour" type="hidden" runat="server" />
    <input id="hid200WindowGlassTint" type="hidden" runat="server" />
    <input id="hid200WindowVinylTint" type="hidden" runat="server" />
    <input id="hid200WindowScreenType" type="hidden" runat="server" />
    
    <input id="hid200SunshadeValanceColour" type="hidden" runat="server" />
    <input id="hid200SunshadeFabricColour" type="hidden" runat="server" />
    <input id="hid200SunshadeOpenness" type="hidden" runat="server" />
    
    <input id="hid200RoofType" type="hidden" runat="server" />
    <input id="hid200RoofInteriorSkin" type="hidden" runat="server" />
    <input id="hid200RoofExteriorSkin" type="hidden" runat="server" />
    <input id="hid200RoofThickness" type="hidden" runat="server" />
    
    <input id="hid200FloorThickness" type="hidden" runat="server" />
    <input id="hid200FloorMetalBarrier" type="hidden" runat="server" />
    
    <input id="hid200KneewallHeight" type="hidden" runat="server" />
    <input id="hid200KneewallType" type="hidden" runat="server" />
    <input id="hid200KneewallGlassTint" type="hidden" runat="server" />
    
    <input id="hid200TransomHeight" type="hidden" runat="server" />
    <input id="hid200TransomType" type="hidden" runat="server" />
    <input id="hid200TransomGlassTint" type="hidden" runat="server" />
    <input id="hid200TransomVinylTint" type="hidden" runat="server" />
    <input id="hid200TransomScreenType" type="hidden" runat="server" />

    <input id="hid200Markup" type="hidden" runat="server" />
    <!-- End: Model 200 Hiddens -->

    <!-- Start: Model 300 Hiddens -->   
    <input id="hid300DefaultFiller" type="hidden" runat="server" />

    <input id="hid300WallInteriorPanelColour" type="hidden" runat="server" />
    <input id="hid300WallInteriorPanelSkin" type="hidden" runat="server" />
    <input id="hid300WallExteriorPanelColour" type="hidden" runat="server" />
    <input id="hid300WallExteriorPanelSkin" type="hidden" runat="server" />
    <input id="hid300WallFrameColour" type="hidden" runat="server" />

    <input id="hid300DoorType" type="hidden" runat="server" />
    <input id="hid300DoorStyle" type="hidden" runat="server" />
    <input id="hid300DoorSwing" type="hidden" runat="server" />
    <input id="hid300DoorHinge" type="hidden" runat="server" />
    <input id="hid300DoorHardware" type="hidden" runat="server" />
    <input id="hid300DoorColour" type="hidden" runat="server" />
    <input id="hid300DoorGlassTint" type="hidden" runat="server" />
    <input id="hid300DoorVinylTint" type="hidden" runat="server" />
    <input id="hid300DoorScreenType" type="hidden" runat="server" />
   
    <input id="hid300WindowType" type="hidden" runat="server" />       
    <input id="hid300WindowColour" type="hidden" runat="server" />
    <input id="hid300WindowGlassTint" type="hidden" runat="server" />
    <input id="hid300WindowVinylTint" type="hidden" runat="server" />
    <input id="hid300WindowScreenType" type="hidden" runat="server" />
    
    <input id="hid300SunshadeValanceColour" type="hidden" runat="server" />
    <input id="hid300SunshadeFabricColour" type="hidden" runat="server" />
    <input id="hid300SunshadeOpenness" type="hidden" runat="server" />
    
    <input id="hid300RoofType" type="hidden" runat="server" />
    <input id="hid300RoofInteriorSkin" type="hidden" runat="server" />
    <input id="hid300RoofExteriorSkin" type="hidden" runat="server" />
    <input id="hid300RoofThickness" type="hidden" runat="server" />
    
    <input id="hid300FloorThickness" type="hidden" runat="server" />
    <input id="hid300FloorMetalBarrier" type="hidden" runat="server" />
    
    <input id="hid300KneewallHeight" type="hidden" runat="server" />
    <input id="hid300KneewallType" type="hidden" runat="server" />
    <input id="hid300KneewallGlassTint" type="hidden" runat="server" />
    
    <input id="hid300TransomHeight" type="hidden" runat="server" />
    <input id="hid300TransomType" type="hidden" runat="server" />
    <input id="hid300TransomGlassTint" type="hidden" runat="server" />
    <input id="hid300TransomVinylTint" type="hidden" runat="server" />
    <input id="hid300TransomScreenType" type="hidden" runat="server" />

    <input id="hid300Markup" type="hidden" runat="server" />
    <!-- End: Model 300 Hiddens -->

    <!-- Start: Model 400 Hiddens -->   
    <input id="hid400DefaultFiller" type="hidden" runat="server" />

    <input id="hid400WallInteriorPanelColour" type="hidden" runat="server" />
    <input id="hid400WallInteriorPanelSkin" type="hidden" runat="server" />
    <input id="hid400WallExteriorPanelColour" type="hidden" runat="server" />
    <input id="hid400WallExteriorPanelSkin" type="hidden" runat="server" />
    <input id="hid400WallFrameColour" type="hidden" runat="server" />

    <input id="hid400DoorType" type="hidden" runat="server" />
    <input id="hid400DoorStyle" type="hidden" runat="server" />
    <input id="hid400DoorSwing" type="hidden" runat="server" />
    <input id="hid400DoorHinge" type="hidden" runat="server" />
    <input id="hid400DoorHardware" type="hidden" runat="server" />
    <input id="hid400DoorColour" type="hidden" runat="server" />
    <input id="hid400DoorGlassTint" type="hidden" runat="server" />
    <input id="hid400DoorVinylTint" type="hidden" runat="server" />
    <input id="hid400DoorScreenType" type="hidden" runat="server" />
   
    <input id="hid400WindowType" type="hidden" runat="server" />       
    <input id="hid400WindowColour" type="hidden" runat="server" />
    <input id="hid400WindowGlassTint" type="hidden" runat="server" />
    <input id="hid400WindowVinylTint" type="hidden" runat="server" />
    <input id="hid400WindowScreenType" type="hidden" runat="server" />
    
    <input id="hid400SunshadeValanceColour" type="hidden" runat="server" />
    <input id="hid400SunshadeFabricColour" type="hidden" runat="server" />
    <input id="hid400SunshadeOpenness" type="hidden" runat="server" />
    
    <input id="hid400RoofType" type="hidden" runat="server" />
    <input id="hid400RoofInteriorSkin" type="hidden" runat="server" />
    <input id="hid400RoofExteriorSkin" type="hidden" runat="server" />
    <input id="hid400RoofThickness" type="hidden" runat="server" />
    
    <input id="hid400FloorThickness" type="hidden" runat="server" />
    <input id="hid400FloorMetalBarrier" type="hidden" runat="server" />
    
    <input id="hid400KneewallHeight" type="hidden" runat="server" />
    <input id="hid400KneewallType" type="hidden" runat="server" />
    <input id="hid400KneewallGlassTint" type="hidden" runat="server" />
    
    <input id="hid400TransomHeight" type="hidden" runat="server" />
    <input id="hid400TransomType" type="hidden" runat="server" />
    <input id="hid400TransomGlassTint" type="hidden" runat="server" />
    <input id="hid400TransomVinylTint" type="hidden" runat="server" />
    <input id="hid400TransomScreenType" type="hidden" runat="server" />

    <input id="hid400Markup" type="hidden" runat="server" />
    <!-- End: Model 400 Hiddens -->
</asp:Content>

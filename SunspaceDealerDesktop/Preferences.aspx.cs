using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SunspaceDealerDesktop
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedIn"] == null)
            {
                //uncomment me when login functionality is working
                Response.Redirect("Login.aspx");
                //Session.Add("loggedIn", "userA");
            }

            #region Dropdown population

            ListItem lst0 = new ListItem("---", "", true);
            ListItem lst18 = new ListItem("1/8", ".125");
            ListItem lst14 = new ListItem("1/4", ".25");
            ListItem lst38 = new ListItem("3/8", ".375");
            ListItem lst12 = new ListItem("1/2", ".5");
            ListItem lst58 = new ListItem("5/8", ".625");
            ListItem lst34 = new ListItem("3/4", ".75");
            ListItem lst78 = new ListItem("7/8", ".875");

            ddl100DefaultFiller.Items.Add(lst0);
            ddl100DefaultFiller.Items.Add(lst18);
            ddl100DefaultFiller.Items.Add(lst14);
            ddl100DefaultFiller.Items.Add(lst38);
            ddl100DefaultFiller.Items.Add(lst12);
            ddl100DefaultFiller.Items.Add(lst58);
            ddl100DefaultFiller.Items.Add(lst34);
            ddl100DefaultFiller.Items.Add(lst78);

            #region General Preferences
            for (int i = 0; i < Constants.INSTALLATION_TYPES.Count(); i++)
            {
                ddlInstallationType.Items.Add(new ListItem(Constants.INSTALLATION_TYPES[i], Constants.INSTALLATION_TYPES[i]));
            }
            for (int i = 0; i < Constants.MODEL_NUMBERS.Count(); i++)
            {
                ddlModelNumber.Items.Add(new ListItem(Constants.MODEL_NUMBERS[i], Constants.MODEL_NUMBERS[i]));
            }
            #endregion

            #region Wall Colours
            #region 100
            for (int i = 0; i < Constants.INTERIOR_WALL_COLOURS.Count(); i++)
                {
                    ddl100InteriorPanelColour.Items.Add(new ListItem(Constants.INTERIOR_WALL_COLOURS[i], Constants.INTERIOR_WALL_COLOURS[i]));
                }

                for (int i = 0; i < Constants.INTERIOR_WALL_SKIN_TYPES.Count(); i++)
                {
                    ddl100InteriorPanelSkin.Items.Add(new ListItem(Constants.INTERIOR_WALL_SKIN_TYPES[i], Constants.INTERIOR_WALL_SKIN_TYPES[i]));
                }

                for (int i = 0; i < Constants.EXTERIOR_WALL_COLOURS.Count(); i++)
                {
                    ddl100ExteriorPanelColour.Items.Add(new ListItem(Constants.EXTERIOR_WALL_COLOURS[i], Constants.EXTERIOR_WALL_COLOURS[i]));
                }

                for (int i = 0; i < Constants.EXTERIOR_WALL_SKIN_TYPES.Count(); i++)
                {
                    ddl100ExteriorPanelSkin.Items.Add(new ListItem(Constants.EXTERIOR_WALL_SKIN_TYPES[i], Constants.EXTERIOR_WALL_SKIN_TYPES[i]));
                }

                for (int i = 0; i < Constants.MODEL_100_FRAMING_COLOURS.Count(); i++)
                {
                    ddl100FrameColour.Items.Add(new ListItem(Constants.MODEL_100_FRAMING_COLOURS[i], Constants.MODEL_100_FRAMING_COLOURS[i]));
                }
                #endregion

            #region 200
            for (int i = 0; i < Constants.INTERIOR_WALL_COLOURS.Count(); i++)
            {
                ddl200InteriorPanelColour.Items.Add(new ListItem(Constants.INTERIOR_WALL_COLOURS[i], Constants.INTERIOR_WALL_COLOURS[i]));
            }

            for (int i = 0; i < Constants.INTERIOR_WALL_SKIN_TYPES.Count(); i++)
            {
                ddl200InteriorPanelSkin.Items.Add(new ListItem(Constants.INTERIOR_WALL_SKIN_TYPES[i], Constants.INTERIOR_WALL_SKIN_TYPES[i]));
            }

            for (int i = 0; i < Constants.EXTERIOR_WALL_COLOURS.Count(); i++)
            {
                ddl200ExteriorPanelColour.Items.Add(new ListItem(Constants.EXTERIOR_WALL_COLOURS[i], Constants.EXTERIOR_WALL_COLOURS[i]));
            }

            for (int i = 0; i < Constants.EXTERIOR_WALL_SKIN_TYPES.Count(); i++)
            {
                ddl200ExteriorPanelSkin.Items.Add(new ListItem(Constants.EXTERIOR_WALL_SKIN_TYPES[i], Constants.EXTERIOR_WALL_SKIN_TYPES[i]));
            }

            for (int i = 0; i < Constants.MODEL_200_FRAMING_COLOURS.Count(); i++)
            {
                ddl200FrameColour.Items.Add(new ListItem(Constants.MODEL_200_FRAMING_COLOURS[i], Constants.MODEL_200_FRAMING_COLOURS[i]));
            }
            #endregion

            #region 300
            for (int i = 0; i < Constants.INTERIOR_WALL_COLOURS.Count(); i++)
            {
                ddl300InteriorPanelColour.Items.Add(new ListItem(Constants.INTERIOR_WALL_COLOURS[i], Constants.INTERIOR_WALL_COLOURS[i]));
            }

            for (int i = 0; i < Constants.INTERIOR_WALL_SKIN_TYPES.Count(); i++)
            {
                ddl300InteriorPanelSkin.Items.Add(new ListItem(Constants.INTERIOR_WALL_SKIN_TYPES[i], Constants.INTERIOR_WALL_SKIN_TYPES[i]));
            }

            for (int i = 0; i < Constants.EXTERIOR_WALL_COLOURS.Count(); i++)
            {
                ddl300ExteriorPanelColour.Items.Add(new ListItem(Constants.EXTERIOR_WALL_COLOURS[i], Constants.EXTERIOR_WALL_COLOURS[i]));
            }

            for (int i = 0; i < Constants.EXTERIOR_WALL_SKIN_TYPES.Count(); i++)
            {
                ddl300ExteriorPanelSkin.Items.Add(new ListItem(Constants.EXTERIOR_WALL_SKIN_TYPES[i], Constants.EXTERIOR_WALL_SKIN_TYPES[i]));
            }

            for (int i = 0; i < Constants.MODEL_300_FRAMING_COLOURS.Count(); i++)
            {
                ddl300FrameColour.Items.Add(new ListItem(Constants.MODEL_300_FRAMING_COLOURS[i], Constants.MODEL_300_FRAMING_COLOURS[i]));
            }
            #endregion

            #region 400
            for (int i = 0; i < Constants.INTERIOR_WALL_COLOURS.Count(); i++)
            {
                ddl400InteriorPanelColour.Items.Add(new ListItem(Constants.INTERIOR_WALL_COLOURS[i], Constants.INTERIOR_WALL_COLOURS[i]));
            }

            for (int i = 0; i < Constants.INTERIOR_WALL_SKIN_TYPES.Count(); i++)
            {
                ddl400InteriorPanelSkin.Items.Add(new ListItem(Constants.INTERIOR_WALL_SKIN_TYPES[i], Constants.INTERIOR_WALL_SKIN_TYPES[i]));
            }

            for (int i = 0; i < Constants.EXTERIOR_WALL_COLOURS.Count(); i++)
            {
                ddl400ExteriorPanelColour.Items.Add(new ListItem(Constants.EXTERIOR_WALL_COLOURS[i], Constants.EXTERIOR_WALL_COLOURS[i]));
            }

            for (int i = 0; i < Constants.EXTERIOR_WALL_SKIN_TYPES.Count(); i++)
            {
                ddl400ExteriorPanelSkin.Items.Add(new ListItem(Constants.EXTERIOR_WALL_SKIN_TYPES[i], Constants.EXTERIOR_WALL_SKIN_TYPES[i]));
            }

            for (int i = 0; i < Constants.MODEL_400_FRAMING_COLOURS.Count(); i++)
            {
                ddl400FrameColour.Items.Add(new ListItem(Constants.MODEL_400_FRAMING_COLOURS[i], Constants.MODEL_400_FRAMING_COLOURS[i]));
            }
            #endregion
            #endregion

            #region Door Options
            #region 100
            for (int i = 0; i < Constants.DOOR_TYPES.Count(); i++)
            {
                ddl100DoorType.Items.Add(new ListItem(Constants.DOOR_TYPES[i], Constants.DOOR_TYPES[i]));
            }
            for (int i = 0; i < Constants.DOOR_STYLES.Count(); i++)
            {
                ddl100DoorStyle.Items.Add(new ListItem(Constants.DOOR_STYLES[i], Constants.DOOR_STYLES[i]));
            }
            for (int i = 0; i < Constants.DOOR_HARDWARE.Count(); i++)
            {
                ddl100DoorHardware.Items.Add(new ListItem(Constants.DOOR_HARDWARE[i],Constants.DOOR_HARDWARE[i]));
            }
            for (int i = 0; i < Constants.DOOR_COLOURS.Count(); i++)
            {
                ddl100DoorColour.Items.Add(new ListItem(Constants.DOOR_COLOURS[i], Constants.DOOR_COLOURS[i]));
            }
            for (int i = 0; i < Constants.GLASS_DOOR_TINTS.Count(); i++)
            {
                ddl100DoorGlassTint.Items.Add(new ListItem(Constants.GLASS_DOOR_TINTS[i], Constants.GLASS_DOOR_TINTS[i]));
            }
            for (int i = 0; i < Constants.VINYL_TINTS.Count(); i++)
            {
                ddl100DoorVinylTint.Items.Add(new ListItem(Constants.VINYL_TINTS[i], Constants.VINYL_TINTS[i]));
            }
            //screen tints
            ddl100DoorSwing.Items.Add(new ListItem("In", "In"));
            ddl100DoorSwing.Items.Add(new ListItem("Out", "Out"));
            ddl100DoorHinge.Items.Add(new ListItem("Left", "Left"));
            ddl100DoorHinge.Items.Add(new ListItem("Right", "Right"));
            #endregion

            #region 200
            for (int i = 0; i < Constants.DOOR_TYPES.Count(); i++)
            {
                ddl200DoorType.Items.Add(new ListItem(Constants.DOOR_TYPES[i], Constants.DOOR_TYPES[i]));
            }
            for (int i = 0; i < Constants.DOOR_STYLES.Count(); i++)
            {
                ddl200DoorStyle.Items.Add(new ListItem(Constants.DOOR_STYLES[i], Constants.DOOR_STYLES[i]));
            }
            for (int i = 0; i < Constants.DOOR_HARDWARE.Count(); i++)
            {
                ddl200DoorHardware.Items.Add(new ListItem(Constants.DOOR_HARDWARE[i], Constants.DOOR_HARDWARE[i]));
            }
            for (int i = 0; i < Constants.DOOR_COLOURS.Count(); i++)
            {
                ddl200DoorColour.Items.Add(new ListItem(Constants.DOOR_COLOURS[i], Constants.DOOR_COLOURS[i]));
            }
            for (int i = 0; i < Constants.GLASS_DOOR_TINTS.Count(); i++)
            {
                ddl200DoorGlassTint.Items.Add(new ListItem(Constants.GLASS_DOOR_TINTS[i], Constants.GLASS_DOOR_TINTS[i]));
            }
            for (int i = 0; i < Constants.VINYL_TINTS.Count(); i++)
            {
                ddl200DoorVinylTint.Items.Add(new ListItem(Constants.VINYL_TINTS[i], Constants.VINYL_TINTS[i]));
            }
            ddl200DoorSwing.Items.Add(new ListItem("In", "In"));
            ddl200DoorSwing.Items.Add(new ListItem("Out", "Out"));
            ddl200DoorHinge.Items.Add(new ListItem("Left", "Left"));
            ddl200DoorHinge.Items.Add(new ListItem("Right", "Right"));
            #endregion

            #region 300
            for (int i = 0; i < Constants.DOOR_TYPES.Count(); i++)
            {
                ddl300DoorType.Items.Add(new ListItem(Constants.DOOR_TYPES[i], Constants.DOOR_TYPES[i]));
            }
            for (int i = 0; i < Constants.DOOR_STYLES.Count(); i++)
            {
                ddl300DoorStyle.Items.Add(new ListItem(Constants.DOOR_STYLES[i], Constants.DOOR_STYLES[i]));
            }
            for (int i = 0; i < Constants.DOOR_HARDWARE.Count(); i++)
            {
                ddl300DoorHardware.Items.Add(new ListItem(Constants.DOOR_HARDWARE[i], Constants.DOOR_HARDWARE[i]));
            }
            for (int i = 0; i < Constants.DOOR_COLOURS.Count(); i++)
            {
                ddl300DoorColour.Items.Add(new ListItem(Constants.DOOR_COLOURS[i], Constants.DOOR_COLOURS[i]));
            }
            for (int i = 0; i < Constants.GLASS_DOOR_TINTS.Count(); i++)
            {
                ddl300DoorGlassTint.Items.Add(new ListItem(Constants.GLASS_DOOR_TINTS[i], Constants.GLASS_DOOR_TINTS[i]));
            }
            for (int i = 0; i < Constants.VINYL_TINTS.Count(); i++)
            {
                ddl300DoorVinylTint.Items.Add(new ListItem(Constants.VINYL_TINTS[i], Constants.VINYL_TINTS[i]));
            }
            ddl300DoorSwing.Items.Add(new ListItem("In", "In"));
            ddl300DoorSwing.Items.Add(new ListItem("Out", "Out"));
            ddl300DoorHinge.Items.Add(new ListItem("Left", "Left"));
            ddl300DoorHinge.Items.Add(new ListItem("Right", "Right"));
            #endregion

            #region 400
            for (int i = 0; i < Constants.DOOR_TYPES.Count(); i++)
            {
                ddl400DoorType.Items.Add(new ListItem(Constants.DOOR_TYPES[i], Constants.DOOR_TYPES[i]));
            }
            for (int i = 0; i < Constants.DOOR_STYLES.Count(); i++)
            {
                ddl400DoorStyle.Items.Add(new ListItem(Constants.DOOR_STYLES[i], Constants.DOOR_STYLES[i]));
            }
            for (int i = 0; i < Constants.DOOR_HARDWARE.Count(); i++)
            {
                ddl400DoorHardware.Items.Add(new ListItem(Constants.DOOR_HARDWARE[i], Constants.DOOR_HARDWARE[i]));
            }
            for (int i = 0; i < Constants.DOOR_COLOURS.Count(); i++)
            {
                ddl400DoorColour.Items.Add(new ListItem(Constants.DOOR_COLOURS[i], Constants.DOOR_COLOURS[i]));
            }
            for (int i = 0; i < Constants.GLASS_DOOR_TINTS.Count(); i++)
            {
                ddl400DoorGlassTint.Items.Add(new ListItem(Constants.GLASS_DOOR_TINTS[i], Constants.GLASS_DOOR_TINTS[i]));
            }
            for (int i = 0; i < Constants.VINYL_TINTS.Count(); i++)
            {
                ddl400DoorVinylTint.Items.Add(new ListItem(Constants.VINYL_TINTS[i], Constants.VINYL_TINTS[i]));
            }
            ddl400DoorSwing.Items.Add(new ListItem("In", "In"));
            ddl400DoorSwing.Items.Add(new ListItem("Out", "Out"));
            ddl400DoorHinge.Items.Add(new ListItem("Left", "Left"));
            ddl400DoorHinge.Items.Add(new ListItem("Right", "Right"));
            #endregion
            #endregion

            #region Window Options
            #region 100
            //No window colours, only vinyl
            for (int i = 0; i < Constants.WINDOW_TYPES.Count(); i++)
            {
                ddl100WindowType.Items.Add(new ListItem(Constants.WINDOW_TYPES[i], Constants.WINDOW_TYPES[i]));
            }
            for (int i = 0; i < Constants.GLASS_WINDOW_TINTS.Count(); i++)
            {
                ddl100WindowGlassTint.Items.Add(new ListItem(Constants.GLASS_WINDOW_TINTS[i], Constants.GLASS_WINDOW_TINTS[i]));
            }
            for (int i = 0; i < Constants.VINYL_TINTS.Count(); i++)
            {
                ddl100WindowVinylTint.Items.Add(new ListItem(Constants.VINYL_TINTS[i], Constants.VINYL_TINTS[i]));
            }
            for (int i = 0; i < Constants.SCREEN_TYPES.Count(); i++)
            {
                ddl100WindowScreenType.Items.Add(new ListItem(Constants.SCREEN_TYPES[i], Constants.SCREEN_TYPES[i]));
            }
            #endregion

            #region 200
            for (int i = 0; i < Constants.WINDOW_TYPES.Count(); i++)
            {
                ddl200WindowType.Items.Add(new ListItem(Constants.WINDOW_TYPES[i], Constants.WINDOW_TYPES[i]));
            }
            for (int i = 0; i < Constants.MODEL_200_WINDOW_COLOURS.Count(); i++)
            {
                ddl200WindowColour.Items.Add(new ListItem(Constants.MODEL_200_WINDOW_COLOURS[i], Constants.MODEL_200_WINDOW_COLOURS[i]));
            }
            for (int i = 0; i < Constants.GLASS_WINDOW_TINTS.Count(); i++)
            {
                ddl200WindowGlassTint.Items.Add(new ListItem(Constants.GLASS_WINDOW_TINTS[i], Constants.GLASS_WINDOW_TINTS[i]));
            }
            for (int i = 0; i < Constants.VINYL_TINTS.Count(); i++)
            {
                ddl200WindowVinylTint.Items.Add(new ListItem(Constants.VINYL_TINTS[i], Constants.VINYL_TINTS[i]));
            }
            for (int i = 0; i < Constants.SCREEN_TYPES.Count(); i++)
            {
                ddl200WindowScreenType.Items.Add(new ListItem(Constants.SCREEN_TYPES[i], Constants.SCREEN_TYPES[i]));
            }
            #endregion

            #region 300
            for (int i = 0; i < Constants.WINDOW_TYPES.Count(); i++)
            {
                ddl300WindowType.Items.Add(new ListItem(Constants.WINDOW_TYPES[i], Constants.WINDOW_TYPES[i]));
            }
            for (int i = 0; i < Constants.MODEL_300_WINDOW_COLOURS.Count(); i++)
            {
                ddl300WindowColour.Items.Add(new ListItem(Constants.MODEL_300_WINDOW_COLOURS[i], Constants.MODEL_300_WINDOW_COLOURS[i]));
            }
            for (int i = 0; i < Constants.GLASS_WINDOW_TINTS.Count(); i++)
            {
                ddl300WindowGlassTint.Items.Add(new ListItem(Constants.GLASS_WINDOW_TINTS[i], Constants.GLASS_WINDOW_TINTS[i]));
            }
            for (int i = 0; i < Constants.VINYL_TINTS.Count(); i++)
            {
                ddl300WindowVinylTint.Items.Add(new ListItem(Constants.VINYL_TINTS[i], Constants.VINYL_TINTS[i]));
            }
            for (int i = 0; i < Constants.SCREEN_TYPES.Count(); i++)
            {
                ddl300WindowScreenType.Items.Add(new ListItem(Constants.SCREEN_TYPES[i], Constants.SCREEN_TYPES[i]));
            }
            #endregion

            #region 400
            for (int i = 0; i < Constants.WINDOW_TYPES.Count(); i++)
            {
                ddl400WindowType.Items.Add(new ListItem(Constants.WINDOW_TYPES[i], Constants.WINDOW_TYPES[i]));
            }
            for (int i = 0; i < Constants.MODEL_400_WINDOW_COLOURS.Count(); i++)
            {
                ddl400WindowColour.Items.Add(new ListItem(Constants.MODEL_400_WINDOW_COLOURS[i], Constants.MODEL_400_WINDOW_COLOURS[i]));
            }
            for (int i = 0; i < Constants.GLASS_WINDOW_TINTS.Count(); i++)
            {
                ddl400WindowGlassTint.Items.Add(new ListItem(Constants.GLASS_WINDOW_TINTS[i], Constants.GLASS_WINDOW_TINTS[i]));
            }
            for (int i = 0; i < Constants.VINYL_TINTS.Count(); i++)
            {
                ddl400WindowVinylTint.Items.Add(new ListItem(Constants.VINYL_TINTS[i], Constants.VINYL_TINTS[i]));
            }
            for (int i = 0; i < Constants.SCREEN_TYPES.Count(); i++)
            {
                ddl400WindowScreenType.Items.Add(new ListItem(Constants.SCREEN_TYPES[i], Constants.SCREEN_TYPES[i]));
            }
            #endregion
            #endregion

            #region Sunshade Options
            #region 100
            for (int i = 0; i < Constants.SUNSHADE_VALANCE_COLOURS.Count(); i++)
            {
                ddl100SunshadeValanceColour.Items.Add(new ListItem(Constants.SUNSHADE_VALANCE_COLOURS[i], Constants.SUNSHADE_VALANCE_COLOURS[i]));
            }
            for (int i = 0; i < Constants.SUNSHADE_FABRIC_COLOURS.Count(); i++)
            {
                ddl100SunshadeFabricColour.Items.Add(new ListItem(Constants.SUNSHADE_FABRIC_COLOURS[i], Constants.SUNSHADE_FABRIC_COLOURS[i]));
            }
            for (int i = 0; i < Constants.SUNSHADE_OPENNESS.Count(); i++)
            {
                ddl100SunshadeOpenness.Items.Add(new ListItem(Constants.SUNSHADE_OPENNESS[i], Constants.SUNSHADE_OPENNESS[i]));
            }
            #endregion

            #region 200
            for (int i = 0; i < Constants.SUNSHADE_VALANCE_COLOURS.Count(); i++)
            {
                ddl200SunshadeValanceColour.Items.Add(new ListItem(Constants.SUNSHADE_VALANCE_COLOURS[i], Constants.SUNSHADE_VALANCE_COLOURS[i]));
            }
            for (int i = 0; i < Constants.SUNSHADE_FABRIC_COLOURS.Count(); i++)
            {
                ddl200SunshadeFabricColour.Items.Add(new ListItem(Constants.SUNSHADE_FABRIC_COLOURS[i], Constants.SUNSHADE_FABRIC_COLOURS[i]));
            }
            for (int i = 0; i < Constants.SUNSHADE_OPENNESS.Count(); i++)
            {
                ddl200SunshadeOpenness.Items.Add(new ListItem(Constants.SUNSHADE_OPENNESS[i], Constants.SUNSHADE_OPENNESS[i]));
            }
            #endregion

            #region 300
            for (int i = 0; i < Constants.SUNSHADE_VALANCE_COLOURS.Count(); i++)
            {
                ddl300SunshadeValanceColour.Items.Add(new ListItem(Constants.SUNSHADE_VALANCE_COLOURS[i], Constants.SUNSHADE_VALANCE_COLOURS[i]));
            }
            for (int i = 0; i < Constants.SUNSHADE_FABRIC_COLOURS.Count(); i++)
            {
                ddl300SunshadeFabricColour.Items.Add(new ListItem(Constants.SUNSHADE_FABRIC_COLOURS[i], Constants.SUNSHADE_FABRIC_COLOURS[i]));
            }
            for (int i = 0; i < Constants.SUNSHADE_OPENNESS.Count(); i++)
            {
                ddl300SunshadeOpenness.Items.Add(new ListItem(Constants.SUNSHADE_OPENNESS[i], Constants.SUNSHADE_OPENNESS[i]));
            }
            #endregion

            #region 400
            for (int i = 0; i < Constants.SUNSHADE_VALANCE_COLOURS.Count(); i++)
            {
                ddl400SunshadeValanceColour.Items.Add(new ListItem(Constants.SUNSHADE_VALANCE_COLOURS[i], Constants.SUNSHADE_VALANCE_COLOURS[i]));
            }
            for (int i = 0; i < Constants.SUNSHADE_FABRIC_COLOURS.Count(); i++)
            {
                ddl400SunshadeFabricColour.Items.Add(new ListItem(Constants.SUNSHADE_FABRIC_COLOURS[i], Constants.SUNSHADE_FABRIC_COLOURS[i]));
            }
            for (int i = 0; i < Constants.SUNSHADE_OPENNESS.Count(); i++)
            {
                ddl400SunshadeOpenness.Items.Add(new ListItem(Constants.SUNSHADE_OPENNESS[i], Constants.SUNSHADE_OPENNESS[i]));
            }
            #endregion
            #endregion

            #region Roof Options
            #region 100
            for (int i = 0; i < Constants.ROOF_TYPES.Count(); i++)
            {
                ddl100RoofType.Items.Add(new ListItem(Constants.ROOF_TYPES[i], Constants.ROOF_TYPES[i]));
            }
            for (int i = 0; i < Constants.ROOF_INTERIOR_SKIN_TYPES.Count(); i++)
            {
                ddl100RoofInteriorSkin.Items.Add(new ListItem(Constants.ROOF_INTERIOR_SKIN_TYPES[i], Constants.ROOF_INTERIOR_SKIN_TYPES[i]));
            }
            for (int i = 0; i < Constants.ROOF_EXTERIOR_SKIN_TYPES.Count(); i++)
            {
                ddl100RoofExteriorSkin.Items.Add(new ListItem(Constants.ROOF_EXTERIOR_SKIN_TYPES[i], Constants.ROOF_EXTERIOR_SKIN_TYPES[i]));
            }
            for (int i = 0; i < Constants.ROOF_THICKNESSES.Count(); i++)
            {
                ddl100RoofThickness.Items.Add(new ListItem(Constants.ROOF_THICKNESSES[i], Constants.ROOF_THICKNESSES[i]));
            }
            #endregion
            #region 200
            for (int i = 0; i < Constants.ROOF_TYPES.Count(); i++)
            {
                ddl200RoofType.Items.Add(new ListItem(Constants.ROOF_TYPES[i], Constants.ROOF_TYPES[i]));
            }
            for (int i = 0; i < Constants.ROOF_INTERIOR_SKIN_TYPES.Count(); i++)
            {
                ddl200RoofInteriorSkin.Items.Add(new ListItem(Constants.ROOF_INTERIOR_SKIN_TYPES[i], Constants.ROOF_INTERIOR_SKIN_TYPES[i]));
            }
            for (int i = 0; i < Constants.ROOF_EXTERIOR_SKIN_TYPES.Count(); i++)
            {
                ddl200RoofExteriorSkin.Items.Add(new ListItem(Constants.ROOF_EXTERIOR_SKIN_TYPES[i], Constants.ROOF_EXTERIOR_SKIN_TYPES[i]));
            }
            for (int i = 0; i < Constants.ROOF_THICKNESSES.Count(); i++)
            {
                ddl200RoofThickness.Items.Add(new ListItem(Constants.ROOF_THICKNESSES[i], Constants.ROOF_THICKNESSES[i]));
            }
            #endregion
            #region 300
            for (int i = 0; i < Constants.ROOF_TYPES.Count(); i++)
            {
                ddl300RoofType.Items.Add(new ListItem(Constants.ROOF_TYPES[i], Constants.ROOF_TYPES[i]));
            }
            for (int i = 0; i < Constants.ROOF_INTERIOR_SKIN_TYPES.Count(); i++)
            {
                ddl300RoofInteriorSkin.Items.Add(new ListItem(Constants.ROOF_INTERIOR_SKIN_TYPES[i], Constants.ROOF_INTERIOR_SKIN_TYPES[i]));
            }
            for (int i = 0; i < Constants.ROOF_EXTERIOR_SKIN_TYPES.Count(); i++)
            {
                ddl300RoofExteriorSkin.Items.Add(new ListItem(Constants.ROOF_EXTERIOR_SKIN_TYPES[i], Constants.ROOF_EXTERIOR_SKIN_TYPES[i]));
            }
            for (int i = 0; i < Constants.ROOF_THICKNESSES.Count(); i++)
            {
                ddl300RoofThickness.Items.Add(new ListItem(Constants.ROOF_THICKNESSES[i], Constants.ROOF_THICKNESSES[i]));
            }
            #endregion
            #region 400
            for (int i = 0; i < Constants.ROOF_TYPES.Count(); i++)
            {
                ddl400RoofType.Items.Add(new ListItem(Constants.ROOF_TYPES[i], Constants.ROOF_TYPES[i]));
            }
            for (int i = 0; i < Constants.ROOF_INTERIOR_SKIN_TYPES.Count(); i++)
            {
                ddl400RoofInteriorSkin.Items.Add(new ListItem(Constants.ROOF_INTERIOR_SKIN_TYPES[i], Constants.ROOF_INTERIOR_SKIN_TYPES[i]));
            }
            for (int i = 0; i < Constants.ROOF_EXTERIOR_SKIN_TYPES.Count(); i++)
            {
                ddl400RoofExteriorSkin.Items.Add(new ListItem(Constants.ROOF_EXTERIOR_SKIN_TYPES[i], Constants.ROOF_EXTERIOR_SKIN_TYPES[i]));
            }
            for (int i = 0; i < Constants.ROOF_THICKNESSES.Count(); i++)
            {
                ddl400RoofThickness.Items.Add(new ListItem(Constants.ROOF_THICKNESSES[i], Constants.ROOF_THICKNESSES[i]));
            }
            #endregion
            #endregion

            //No floor db yet
            #region Floor Options
            #region 100
            #endregion
            #region 200
            #endregion
            #region 300
            #endregion
            #region 400
            #endregion
            #endregion

            #region Kneewall Options
            #region 100
            for (int i = 0; i < Constants.KNEEWALL_TYPES.Count(); i++)
            {
                ddl100KneewallType.Items.Add(new ListItem(Constants.KNEEWALL_TYPES[i], Constants.KNEEWALL_TYPES[i]));
            }
            for (int i = 0; i < Constants.KNEEWALL_GLASS_TINTS.Count(); i++)
            {
                ddl100KneewallGlassTint.Items.Add(new ListItem(Constants.KNEEWALL_GLASS_TINTS[i], Constants.KNEEWALL_GLASS_TINTS[i]));
            }
            #endregion
            #region 200
            for (int i = 0; i < Constants.KNEEWALL_TYPES.Count(); i++)
            {
                ddl200KneewallType.Items.Add(new ListItem(Constants.KNEEWALL_TYPES[i], Constants.KNEEWALL_TYPES[i]));
            }
            for (int i = 0; i < Constants.KNEEWALL_GLASS_TINTS.Count(); i++)
            {
                ddl200KneewallGlassTint.Items.Add(new ListItem(Constants.KNEEWALL_GLASS_TINTS[i], Constants.KNEEWALL_GLASS_TINTS[i]));
            }
            #endregion
            #region 300
            for (int i = 0; i < Constants.KNEEWALL_TYPES.Count(); i++)
            {
                ddl300KneewallType.Items.Add(new ListItem(Constants.KNEEWALL_TYPES[i], Constants.KNEEWALL_TYPES[i]));
            }
            for (int i = 0; i < Constants.KNEEWALL_GLASS_TINTS.Count(); i++)
            {
                ddl300KneewallGlassTint.Items.Add(new ListItem(Constants.KNEEWALL_GLASS_TINTS[i], Constants.KNEEWALL_GLASS_TINTS[i]));
            }
            #endregion
            #region 400
            for (int i = 0; i < Constants.KNEEWALL_TYPES.Count(); i++)
            {
                ddl400KneewallType.Items.Add(new ListItem(Constants.KNEEWALL_TYPES[i], Constants.KNEEWALL_TYPES[i]));
            }
            for (int i = 0; i < Constants.KNEEWALL_GLASS_TINTS.Count(); i++)
            {
                ddl400KneewallGlassTint.Items.Add(new ListItem(Constants.KNEEWALL_GLASS_TINTS[i], Constants.KNEEWALL_GLASS_TINTS[i]));
            }
            #endregion
            #endregion

            #region Transom Options
            #region 100
            for (int i = 0; i < Constants.TRANSOM_TYPES.Count(); i++)
            {
                ddl100TransomType.Items.Add(new ListItem(Constants.TRANSOM_TYPES[i], Constants.TRANSOM_TYPES[i]));
            }
            for (int i = 0; i < Constants.TRANSOM_GLASS_TINTS.Count(); i++)
            {
                ddl100TransomGlassTint.Items.Add(new ListItem(Constants.TRANSOM_GLASS_TINTS[i], Constants.TRANSOM_GLASS_TINTS[i]));
            }
            for (int i = 0; i < Constants.VINYL_TINTS.Count(); i++)
            {
                ddl100TransomVinylTint.Items.Add(new ListItem(Constants.VINYL_TINTS[i], Constants.VINYL_TINTS[i]));
            }
            #endregion
            #region 200
            for (int i = 0; i < Constants.TRANSOM_TYPES.Count(); i++)
            {
                ddl200TransomType.Items.Add(new ListItem(Constants.TRANSOM_TYPES[i], Constants.TRANSOM_TYPES[i]));
            }
            for (int i = 0; i < Constants.TRANSOM_GLASS_TINTS.Count(); i++)
            {
                ddl200TransomGlassTint.Items.Add(new ListItem(Constants.TRANSOM_GLASS_TINTS[i], Constants.TRANSOM_GLASS_TINTS[i]));
            }
            for (int i = 0; i < Constants.VINYL_TINTS.Count(); i++)
            {
                ddl200TransomVinylTint.Items.Add(new ListItem(Constants.VINYL_TINTS[i], Constants.VINYL_TINTS[i]));
            }
            #endregion
            #region 300
            for (int i = 0; i < Constants.TRANSOM_TYPES.Count(); i++)
            {
                ddl300TransomType.Items.Add(new ListItem(Constants.TRANSOM_TYPES[i], Constants.TRANSOM_TYPES[i]));
            }
            for (int i = 0; i < Constants.TRANSOM_GLASS_TINTS.Count(); i++)
            {
                ddl300TransomGlassTint.Items.Add(new ListItem(Constants.TRANSOM_GLASS_TINTS[i], Constants.TRANSOM_GLASS_TINTS[i]));
            }
            for (int i = 0; i < Constants.VINYL_TINTS.Count(); i++)
            {
                ddl300TransomVinylTint.Items.Add(new ListItem(Constants.VINYL_TINTS[i], Constants.VINYL_TINTS[i]));
            }
            #endregion
            #region 400
            for (int i = 0; i < Constants.TRANSOM_TYPES.Count(); i++)
            {
                ddl400TransomType.Items.Add(new ListItem(Constants.TRANSOM_TYPES[i], Constants.TRANSOM_TYPES[i]));
            }
            for (int i = 0; i < Constants.TRANSOM_GLASS_TINTS.Count(); i++)
            {
                ddl400TransomGlassTint.Items.Add(new ListItem(Constants.TRANSOM_GLASS_TINTS[i], Constants.TRANSOM_GLASS_TINTS[i]));
            }
            for (int i = 0; i < Constants.VINYL_TINTS.Count(); i++)
            {
                ddl400TransomVinylTint.Items.Add(new ListItem(Constants.VINYL_TINTS[i], Constants.VINYL_TINTS[i]));
            }
            #endregion
            #endregion

            #endregion
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
                //colours
                //door
                //window
                //sunshade
                //roof
                //floor
                //kneewall
                //transom
            //save all preferences
            //additional comment here
        }

        protected void btnAddUsers_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddUsers.aspx");
        }
    }
}
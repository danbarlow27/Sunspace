using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

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

            ddl200DefaultFiller.Items.Add(lst0);
            ddl200DefaultFiller.Items.Add(lst18);
            ddl200DefaultFiller.Items.Add(lst14);
            ddl200DefaultFiller.Items.Add(lst38);
            ddl200DefaultFiller.Items.Add(lst12);
            ddl200DefaultFiller.Items.Add(lst58);
            ddl200DefaultFiller.Items.Add(lst34);
            ddl200DefaultFiller.Items.Add(lst78);

            ddl300DefaultFiller.Items.Add(lst0);
            ddl300DefaultFiller.Items.Add(lst18);
            ddl300DefaultFiller.Items.Add(lst14);
            ddl300DefaultFiller.Items.Add(lst38);
            ddl300DefaultFiller.Items.Add(lst12);
            ddl300DefaultFiller.Items.Add(lst58);
            ddl300DefaultFiller.Items.Add(lst34);
            ddl300DefaultFiller.Items.Add(lst78);

            ddl400DefaultFiller.Items.Add(lst0);
            ddl400DefaultFiller.Items.Add(lst18);
            ddl400DefaultFiller.Items.Add(lst14);
            ddl400DefaultFiller.Items.Add(lst38);
            ddl400DefaultFiller.Items.Add(lst12);
            ddl400DefaultFiller.Items.Add(lst58);
            ddl400DefaultFiller.Items.Add(lst34);
            ddl400DefaultFiller.Items.Add(lst78);

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
            for (int i = 0; i < Constants.SCREEN_TYPES.Count(); i++)
            {
                ddl100DoorScreenType.Items.Add(new ListItem(Constants.SCREEN_TYPES[i], Constants.SCREEN_TYPES[i]));
            }
            //screen tints
            ddl100DoorSwing.Items.Add(new ListItem("In", "In"));
            ddl100DoorSwing.Items.Add(new ListItem("Out", "Out"));
            ddl100DoorHinge.Items.Add(new ListItem("L", "L"));
            ddl100DoorHinge.Items.Add(new ListItem("R", "R"));
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
            for (int i = 0; i < Constants.SCREEN_TYPES.Count(); i++)
            {
                ddl200DoorScreenType.Items.Add(new ListItem(Constants.SCREEN_TYPES[i], Constants.SCREEN_TYPES[i]));
            }

            ddl200DoorSwing.Items.Add(new ListItem("In", "In"));
            ddl200DoorSwing.Items.Add(new ListItem("Out", "Out"));
            ddl100DoorHinge.Items.Add(new ListItem("L", "L"));
            ddl100DoorHinge.Items.Add(new ListItem("R", "R"));
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
            for (int i = 0; i < Constants.SCREEN_TYPES.Count(); i++)
            {
                ddl300DoorScreenType.Items.Add(new ListItem(Constants.SCREEN_TYPES[i], Constants.SCREEN_TYPES[i]));
            }

            ddl300DoorSwing.Items.Add(new ListItem("In", "In"));
            ddl300DoorSwing.Items.Add(new ListItem("Out", "Out"));
            ddl100DoorHinge.Items.Add(new ListItem("L", "L"));
            ddl100DoorHinge.Items.Add(new ListItem("R", "R"));
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
            for (int i = 0; i < Constants.SCREEN_TYPES.Count(); i++)
            {
                ddl400DoorScreenType.Items.Add(new ListItem(Constants.SCREEN_TYPES[i], Constants.SCREEN_TYPES[i]));
            }

            ddl400DoorSwing.Items.Add(new ListItem("In", "In"));
            ddl400DoorSwing.Items.Add(new ListItem("Out", "Out"));
            ddl100DoorHinge.Items.Add(new ListItem("L", "L"));
            ddl100DoorHinge.Items.Add(new ListItem("R", "R"));
            #endregion
            #endregion

            #region Window Options
            #region 100
            //No window colours, only vinyl
            for (int i = 0; i < Constants.MODEL_100_WINDOW_TYPES.Count(); i++)
            {
                ddl100WindowType.Items.Add(new ListItem(Constants.MODEL_100_WINDOW_TYPES[i], Constants.MODEL_100_WINDOW_TYPES[i]));
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
            for (int i = 0; i < Constants.MODEL_200_WINDOW_TYPES.Count(); i++)
            {
                ddl200WindowType.Items.Add(new ListItem(Constants.MODEL_200_WINDOW_TYPES[i], Constants.MODEL_200_WINDOW_TYPES[i]));
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
            for (int i = 0; i < Constants.MODEL_300_WINDOW_TYPES.Count(); i++)
            {
                ddl300WindowType.Items.Add(new ListItem(Constants.MODEL_300_WINDOW_TYPES[i], Constants.MODEL_300_WINDOW_TYPES[i]));
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
            for (int i = 0; i < Constants.MODEL_400_WINDOW_TYPES.Count(); i++)
            {
                ddl400WindowType.Items.Add(new ListItem(Constants.MODEL_400_WINDOW_TYPES[i], Constants.MODEL_400_WINDOW_TYPES[i]));
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

            #region Floor Options
            #region 100
            for (int i = 0; i < Constants.FLOOR_THICKNESSES.Count(); i++)
            {
                ddl100FloorThickness.Items.Add(new ListItem(Constants.FLOOR_THICKNESSES[i], Constants.FLOOR_THICKNESSES[i]));
            }
            #endregion
            #region 200
            for (int i = 0; i < Constants.FLOOR_THICKNESSES.Count(); i++)
            {
                ddl200FloorThickness.Items.Add(new ListItem(Constants.FLOOR_THICKNESSES[i], Constants.FLOOR_THICKNESSES[i]));
            }
            #endregion
            #region 300
            for (int i = 0; i < Constants.FLOOR_THICKNESSES.Count(); i++)
            {
                ddl300FloorThickness.Items.Add(new ListItem(Constants.FLOOR_THICKNESSES[i], Constants.FLOOR_THICKNESSES[i]));
            }
            #endregion
            #region 400
            for (int i = 0; i < Constants.FLOOR_THICKNESSES.Count(); i++)
            {
                ddl400FloorThickness.Items.Add(new ListItem(Constants.FLOOR_THICKNESSES[i], Constants.FLOOR_THICKNESSES[i]));
            }
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
            for (int i = 0; i < Constants.SCREEN_TYPES.Count(); i++)
            {
                ddl100TransomScreenType.Items.Add(new ListItem(Constants.SCREEN_TYPES[i], Constants.SCREEN_TYPES[i]));
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
            for (int i = 0; i < Constants.SCREEN_TYPES.Count(); i++)
            {
                ddl200TransomScreenType.Items.Add(new ListItem(Constants.SCREEN_TYPES[i], Constants.SCREEN_TYPES[i]));
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
            for (int i = 0; i < Constants.SCREEN_TYPES.Count(); i++)
            {
                ddl300TransomScreenType.Items.Add(new ListItem(Constants.SCREEN_TYPES[i], Constants.SCREEN_TYPES[i]));
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
            for (int i = 0; i < Constants.SCREEN_TYPES.Count(); i++)
            {
                ddl400TransomScreenType.Items.Add(new ListItem(Constants.SCREEN_TYPES[i], Constants.SCREEN_TYPES[i]));
            }
            #endregion
            #endregion

            #endregion

            #region Temp Textbox Fills
            txt100DefaultFiller.Text = "20";
            txt100KneewallHeight.Text = "20";
            txt100Markup.Text = "20";
            txt100TransomHeight.Text = "20";
            txt200DefaultFiller.Text = "20";
            txt200KneewallHeight.Text = "20";
            txt200Markup.Text = "20";
            txt200TransomHeight.Text = "20";
            txt300DefaultFiller.Text = "20";
            txt300KneewallHeight.Text = "20";
            txt300Markup.Text = "20";
            txt300TransomHeight.Text = "20";
            txt400DefaultFiller.Text = "20";
            txt400KneewallHeight.Text = "20";
            txt400Markup.Text = "20";
            txt400TransomHeight.Text = "20";
            txtCompanyNameInput.Text = "20";
            #endregion
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection aConnection = new SqlConnection(sdsUsers.ConnectionString))
            {
                aConnection.Open();
                SqlCommand aCommand = aConnection.CreateCommand();
                SqlTransaction aTransaction;

                // Start a local transaction.
                aTransaction = aConnection.BeginTransaction("SampleTransaction");

                // Must assign both transaction object and connection 
                // to Command object for a pending local transaction
                aCommand.Connection = aConnection;
                aCommand.Transaction = aTransaction;

                try
                {                    
                    //Now add user
                    DateTime aDate = DateTime.Now;
                    char isChecked= '0';
                    if (chkCutPitch.Checked==true)
                    {
                        isChecked= '1';
                    }
                    aCommand.CommandText = "UPDATE preferences SET "
                                            + "installation_type='" + ddlInstallationType.SelectedValue + "', "
                                            + "model_type='" + ddlModelNumber.SelectedValue + "', "
                                            + "layout='" + "Preset 1" + "', "
                                            + "cut_pitch=" + isChecked + " "
                                            + "WHERE dealer_id=" + Convert.ToInt32(Session["dealer_id"]);
                    aCommand.ExecuteNonQuery();

                    
                    isChecked= '0';
                    if (chk100FloorMetalBarrier.Checked==true)
                    {
                        isChecked= '1';
                    }
                    //An entrance into the model preferences table, one entry for each model type
                    #region Model 100 preferences entry
                    aCommand.CommandText = "UPDATE model_preferences SET "
                                            + "default_filler=" + txt100DefaultFiller.Text + ", "
                                            + "interior_panel_skin='" + ddl100InteriorPanelSkin.SelectedValue + "', "
                                            + "exterior_panel_skin='" + ddl100ExteriorPanelSkin.SelectedValue + "', "
                                            + "frame_colour='" + ddl100FrameColour.SelectedValue + "', "
                                            + "door_type='" + ddl100DoorType.SelectedValue + "', "
                                            + "door_style='" + ddl100DoorStyle.SelectedValue + "', "
                                            + "door_swing='" + ddl100DoorSwing.SelectedValue + "', "
                                            + "door_hinge='" + ddl100DoorHinge.SelectedValue + "', "
                                            + "door_hardware='" + ddl100DoorHardware.SelectedValue + "', "
                                            + "door_colour='" + ddl100DoorColour.SelectedValue + "', "
                                            + "door_glass_tint='" + ddl100DoorGlassTint.SelectedValue + "', "
                                            + "door_vinyl_tint='" + ddl100DoorVinylTint.SelectedValue + "', "
                                            + "door_screen_type='" + ddl100DoorScreenType.SelectedValue + "', "
                        //window
                                            + "window_type='" + ddl100WindowType.SelectedValue + "', "
                                            + "window_colour='" + "None" + "', "
                                            + "window_glass_tint='" + ddl100WindowGlassTint.SelectedValue + "', "
                                            + "window_vinyl_tint='" + ddl100WindowVinylTint.SelectedValue + "', "
                                            + "window_screen_type='" + ddl100WindowScreenType.SelectedValue + "', "
                        //sunshade
                                            + "sunshade_valance_colour='" + ddl100SunshadeValanceColour.SelectedValue + "', "
                                            + "sunshade_fabric_colour='" + ddl100SunshadeFabricColour.SelectedValue + "', "
                                            + "sunshade_openness='" + ddl100SunshadeOpenness.SelectedValue + "', "
                        //roof
                                            + "roof_type='" + ddl100RoofType.SelectedValue + "', "
                                            + "roof_interior_skin='" + ddl100RoofInteriorSkin.SelectedValue + "', "
                                            + "roof_exterior_skin='" + ddl100ExteriorPanelSkin.SelectedValue + "', "
                                            + "roof_thickness='" + ddl100RoofThickness.SelectedValue + "', "
                        //floor
                                            + "floor_thickness='" + ddl100FloorThickness.SelectedValue + "', "
                                            + "floor_metal_barrier=" + isChecked + ", "
                        //kneewall
                                            + "kneewall_height=" + txt100KneewallHeight.Text + ", "
                                            + "kneewall_type='" + ddl100KneewallType.SelectedValue + "', "
                                            + "kneewall_glass_tint='" + ddl100KneewallGlassTint.SelectedValue + "', "
                        //transom
                                            + "transom_height=" + txt100TransomHeight.Text + ", "
                                            + "transom_style='" + ddl100TransomType.SelectedValue + "', "
                                            + "transom_glass_tint='" + ddl100TransomGlassTint.SelectedValue + "', "
                                            + "transom_vinyl_tint='" + ddl100TransomVinylTint.SelectedValue + "', "
                                            + "transom_screen_type='" + ddl100TransomScreenType.SelectedValue + "', "
                                            + "markup=" + Convert.ToDecimal(txt100Markup.Text) / 100
                                            + " WHERE dealer_id=" + Session["dealer_id"].ToString() + " AND model_type='100'";
                    aCommand.ExecuteNonQuery();
                    #endregion

                   
                    lblError.Text = "Successfully Added";

                    // Attempt to commit the transaction.
                    aTransaction.Commit();
                }
                catch (Exception ex)
                {
                    lblError.Text = "Commit Exception Type: " + ex.GetType();
                    lblError.Text += "  Message: " + ex.Message;

                    // Attempt to roll back the transaction. 
                    try
                    {
                        aTransaction.Rollback();
                    }
                    catch (Exception ex2)
                    {
                        // This catch block will handle any errors that may have occurred 
                        // on the server that would cause the rollback to fail, such as 
                        // a closed connection.
                        lblError.Text="Rollback Exception Type: " + ex2.GetType();
                        lblError.Text += "  Message: " + ex2.Message;
                    }
                }
            }
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
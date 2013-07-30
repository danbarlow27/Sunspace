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

            if (Session["user_type"].ToString() == "S" && Session["dealer_id"].ToString() == "-1")
            {
                //if a sunspace user hasn't spoofed, send them there, that is step one
                Response.Redirect("Spoof.aspx");
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

            #region Sub-inch DDL Fills
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

            ddl100KneewallHeight.Items.Add(lst0);
            ddl100KneewallHeight.Items.Add(lst18);
            ddl100KneewallHeight.Items.Add(lst14);
            ddl100KneewallHeight.Items.Add(lst38);
            ddl100KneewallHeight.Items.Add(lst12);
            ddl100KneewallHeight.Items.Add(lst58);
            ddl100KneewallHeight.Items.Add(lst34);
            ddl100KneewallHeight.Items.Add(lst78);

            ddl100TransomHeight.Items.Add(lst0);
            ddl100TransomHeight.Items.Add(lst18);
            ddl100TransomHeight.Items.Add(lst14);
            ddl100TransomHeight.Items.Add(lst38);
            ddl100TransomHeight.Items.Add(lst12);
            ddl100TransomHeight.Items.Add(lst58);
            ddl100TransomHeight.Items.Add(lst34);
            ddl100TransomHeight.Items.Add(lst78);

            ddl200KneewallHeight.Items.Add(lst0);
            ddl200KneewallHeight.Items.Add(lst18);
            ddl200KneewallHeight.Items.Add(lst14);
            ddl200KneewallHeight.Items.Add(lst38);
            ddl200KneewallHeight.Items.Add(lst12);
            ddl200KneewallHeight.Items.Add(lst58);
            ddl200KneewallHeight.Items.Add(lst34);
            ddl200KneewallHeight.Items.Add(lst78);

            ddl200TransomHeight.Items.Add(lst0);
            ddl200TransomHeight.Items.Add(lst18);
            ddl200TransomHeight.Items.Add(lst14);
            ddl200TransomHeight.Items.Add(lst38);
            ddl200TransomHeight.Items.Add(lst12);
            ddl200TransomHeight.Items.Add(lst58);
            ddl200TransomHeight.Items.Add(lst34);
            ddl200TransomHeight.Items.Add(lst78);

            ddl300KneewallHeight.Items.Add(lst0);
            ddl300KneewallHeight.Items.Add(lst18);
            ddl300KneewallHeight.Items.Add(lst14);
            ddl300KneewallHeight.Items.Add(lst38);
            ddl300KneewallHeight.Items.Add(lst12);
            ddl300KneewallHeight.Items.Add(lst58);
            ddl300KneewallHeight.Items.Add(lst34);
            ddl300KneewallHeight.Items.Add(lst78);

            ddl300TransomHeight.Items.Add(lst0);
            ddl300TransomHeight.Items.Add(lst18);
            ddl300TransomHeight.Items.Add(lst14);
            ddl300TransomHeight.Items.Add(lst38);
            ddl300TransomHeight.Items.Add(lst12);
            ddl300TransomHeight.Items.Add(lst58);
            ddl300TransomHeight.Items.Add(lst34);
            ddl300TransomHeight.Items.Add(lst78);

            ddl400KneewallHeight.Items.Add(lst0);
            ddl400KneewallHeight.Items.Add(lst18);
            ddl400KneewallHeight.Items.Add(lst14);
            ddl400KneewallHeight.Items.Add(lst38);
            ddl400KneewallHeight.Items.Add(lst12);
            ddl400KneewallHeight.Items.Add(lst58);
            ddl400KneewallHeight.Items.Add(lst34);
            ddl400KneewallHeight.Items.Add(lst78);

            ddl400TransomHeight.Items.Add(lst0);
            ddl400TransomHeight.Items.Add(lst18);
            ddl400TransomHeight.Items.Add(lst14);
            ddl400TransomHeight.Items.Add(lst38);
            ddl400TransomHeight.Items.Add(lst12);
            ddl400TransomHeight.Items.Add(lst58);
            ddl400TransomHeight.Items.Add(lst34);
            ddl400TransomHeight.Items.Add(lst78);
            #endregion

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
            ddl200DoorHinge.Items.Add(new ListItem("L", "L"));
            ddl200DoorHinge.Items.Add(new ListItem("R", "R"));
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
            ddl300DoorHinge.Items.Add(new ListItem("L", "L"));
            ddl300DoorHinge.Items.Add(new ListItem("R", "R"));
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
            ddl400DoorHinge.Items.Add(new ListItem("L", "L"));
            ddl400DoorHinge.Items.Add(new ListItem("R", "R"));
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

            #region Select User's Fields
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
                    //get general preferences
                    aCommand.CommandText = "SELECT installation_type, model_type, layout, cut_pitch FROM preferences WHERE dealer_id=" + Session["dealer_id"].ToString();
                    SqlDataReader aReader = aCommand.ExecuteReader();
                    aReader.Read();
                    //set general preferences
                    ddlInstallationType.SelectedValue = aReader[0].ToString();
                    ddlModelNumber.SelectedValue = aReader[1].ToString();
                    ddlLayout.SelectedValue = aReader[2].ToString();

                    //if cutpitch is true, check the checkbox
                    if (aReader[3].ToString() == "1")
                    {
                        chkCutPitch.Checked = true;
                    }

                    aReader.Close();

                    #region 100
                    aCommand.CommandText = "SELECT default_filler, interior_panel_skin, exterior_panel_skin, frame_colour, door_type, door_style, door_swing, door_hinge, door_hardware, door_colour, door_glass_tint, door_vinyl_tint, door_screen_type, window_type, window_colour, window_glass_tint, window_vinyl_tint, window_screen_type, sunshade_valance_colour, sunshade_fabric_colour, sunshade_openness, roof_type, roof_interior_skin, roof_exterior_skin, roof_thickness, floor_thickness, floor_metal_barrier, kneewall_height, kneewall_type, kneewall_glass_tint, transom_height, transom_style, transom_glass_tint, transom_vinyl_tint, transom_screen_type, markup FROM model_preferences WHERE dealer_id=" + Session["dealer_id"].ToString() + " AND model_type='100'";
                    aReader = aCommand.ExecuteReader();
                    aReader.Read();

                    txt100DefaultFiller.Text = aReader[0].ToString();
                    ddl100InteriorPanelSkin.SelectedValue = aReader[1].ToString();
                    ddl100ExteriorPanelSkin.SelectedValue = aReader[2].ToString();
                    ddl100FrameColour.SelectedValue = aReader[3].ToString();
                    //door
                    ddl100DoorType.SelectedValue = aReader[4].ToString();
                    ddl100DoorStyle.SelectedValue = aReader[5].ToString();
                    ddl100DoorSwing.SelectedValue = aReader[6].ToString();
                    ddl100DoorHinge.SelectedValue = aReader[7].ToString();
                    ddl100DoorHardware.SelectedValue = aReader[8].ToString();
                    ddl100DoorColour.SelectedValue = aReader[9].ToString();
                    ddl100DoorGlassTint.SelectedValue = aReader[10].ToString();
                    ddl100DoorVinylTint.SelectedValue = aReader[11].ToString();
                    ddl100DoorScreenType.SelectedValue = aReader[12].ToString();
                    //window
                    ddl100WindowType.SelectedValue = aReader[13].ToString();
                    //no window colour for model100, skip #14
                    ddl100WindowGlassTint.SelectedValue = aReader[15].ToString();
                    ddl100WindowVinylTint.SelectedValue = aReader[16].ToString();
                    ddl100WindowScreenType.SelectedValue = aReader[17].ToString();
                    //sunshade
                    ddl100SunshadeValanceColour.SelectedValue = aReader[18].ToString();
                    ddl100SunshadeFabricColour.SelectedValue = aReader[19].ToString();
                    ddl100SunshadeOpenness.SelectedValue = aReader[20].ToString();
                    //roof
                    ddl100RoofType.SelectedValue = aReader[21].ToString();
                    ddl100RoofInteriorSkin.SelectedValue = aReader[22].ToString();
                    ddl100RoofExteriorSkin.SelectedValue = aReader[23].ToString();
                    ddl100RoofThickness.SelectedValue = aReader[24].ToString();
                    //floor
                    ddl100FloorThickness.SelectedValue = aReader[25].ToString();

                    //if barrier is true, check the checkbox
                    if (aReader[26].ToString() == "1")
                    {
                        chk100FloorMetalBarrier.Checked = true;
                    }

                    //kneewall
                    txt100KneewallHeight.Text = aReader[27].ToString();
                    ddl100KneewallType.SelectedValue = aReader[28].ToString();
                    ddl100KneewallGlassTint.SelectedValue = aReader[29].ToString();
                    //transom
                    txt100TransomHeight.Text = aReader[30].ToString();
                    ddl100TransomType.SelectedValue = aReader[31].ToString();
                    ddl100TransomGlassTint.SelectedValue = aReader[32].ToString();
                    ddl100TransomVinylTint.SelectedValue = aReader[33].ToString();
                    ddl100TransomScreenType.SelectedValue = aReader[34].ToString();

                    txt100Markup.Text = (Convert.ToDecimal(aReader[35].ToString())*100).ToString();
                    aReader.Close();
                    #endregion

                    #region 200
                    aCommand.CommandText = "SELECT default_filler, interior_panel_skin, exterior_panel_skin, frame_colour, door_type, door_style, door_swing, door_hinge, door_hardware, door_colour, door_glass_tint, door_vinyl_tint, door_screen_type, window_type, window_colour, window_glass_tint, window_vinyl_tint, window_screen_type, sunshade_valance_colour, sunshade_fabric_colour, sunshade_openness, roof_type, roof_interior_skin, roof_exterior_skin, roof_thickness, floor_thickness, floor_metal_barrier, kneewall_height, kneewall_type, kneewall_glass_tint, transom_height, transom_style, transom_glass_tint, transom_vinyl_tint, transom_screen_type, markup FROM model_preferences WHERE dealer_id=" + Session["dealer_id"].ToString() + " AND model_type='200'";
                    aReader = aCommand.ExecuteReader();
                    aReader.Read();

                    txt200DefaultFiller.Text = aReader[0].ToString();
                    ddl200InteriorPanelSkin.SelectedValue = aReader[1].ToString();
                    ddl200ExteriorPanelSkin.SelectedValue = aReader[2].ToString();
                    ddl200FrameColour.SelectedValue = aReader[3].ToString();
                    //door
                    ddl200DoorType.SelectedValue = aReader[4].ToString();
                    ddl200DoorStyle.SelectedValue = aReader[5].ToString();
                    ddl200DoorSwing.SelectedValue = aReader[6].ToString();
                    ddl200DoorHinge.SelectedValue = aReader[7].ToString();
                    ddl200DoorHardware.SelectedValue = aReader[8].ToString();
                    ddl200DoorColour.SelectedValue = aReader[9].ToString();
                    ddl200DoorGlassTint.SelectedValue = aReader[10].ToString();
                    ddl200DoorVinylTint.SelectedValue = aReader[11].ToString();
                    ddl200DoorScreenType.SelectedValue = aReader[12].ToString();
                    //window
                    ddl200WindowType.SelectedValue = aReader[13].ToString();
                    //no window colour for model100, skip #14
                    ddl200WindowGlassTint.SelectedValue = aReader[15].ToString();
                    ddl200WindowVinylTint.SelectedValue = aReader[16].ToString();
                    ddl200WindowScreenType.SelectedValue = aReader[17].ToString();
                    //sunshade
                    ddl200SunshadeValanceColour.SelectedValue = aReader[18].ToString();
                    ddl200SunshadeFabricColour.SelectedValue = aReader[19].ToString();
                    ddl200SunshadeOpenness.SelectedValue = aReader[20].ToString();
                    //roof
                    ddl200RoofType.SelectedValue = aReader[21].ToString();
                    ddl200RoofInteriorSkin.SelectedValue = aReader[22].ToString();
                    ddl200RoofExteriorSkin.SelectedValue = aReader[23].ToString();
                    ddl200RoofThickness.SelectedValue = aReader[24].ToString();
                    //floor
                    ddl200FloorThickness.SelectedValue = aReader[25].ToString();

                    //if barrier is true, check the checkbox
                    if (aReader[26].ToString() == "1")
                    {
                        chk200FloorMetalBarrier.Checked = true;
                    }

                    //kneewall
                    txt200KneewallHeight.Text = aReader[27].ToString();
                    ddl200KneewallType.SelectedValue = aReader[28].ToString();
                    ddl200KneewallGlassTint.SelectedValue = aReader[29].ToString();
                    //transom
                    txt200TransomHeight.Text = aReader[30].ToString();
                    ddl200TransomType.SelectedValue = aReader[31].ToString();
                    ddl200TransomGlassTint.SelectedValue = aReader[32].ToString();
                    ddl200TransomVinylTint.SelectedValue = aReader[33].ToString();
                    ddl200TransomScreenType.SelectedValue = aReader[34].ToString();

                    txt200Markup.Text = (Convert.ToDecimal(aReader[35].ToString()) * 100).ToString();
                    aReader.Close();
                    #endregion

                    #region 300
                    aCommand.CommandText = "SELECT default_filler, interior_panel_skin, exterior_panel_skin, frame_colour, door_type, door_style, door_swing, door_hinge, door_hardware, door_colour, door_glass_tint, door_vinyl_tint, door_screen_type, window_type, window_colour, window_glass_tint, window_vinyl_tint, window_screen_type, sunshade_valance_colour, sunshade_fabric_colour, sunshade_openness, roof_type, roof_interior_skin, roof_exterior_skin, roof_thickness, floor_thickness, floor_metal_barrier, kneewall_height, kneewall_type, kneewall_glass_tint, transom_height, transom_style, transom_glass_tint, transom_vinyl_tint, transom_screen_type, markup FROM model_preferences WHERE dealer_id=" + Session["dealer_id"].ToString() + " AND model_type='300'";
                    aReader = aCommand.ExecuteReader();
                    aReader.Read();

                    txt300DefaultFiller.Text = aReader[0].ToString();
                    ddl300InteriorPanelSkin.SelectedValue = aReader[1].ToString();
                    ddl300ExteriorPanelSkin.SelectedValue = aReader[2].ToString();
                    ddl300FrameColour.SelectedValue = aReader[3].ToString();
                    //door
                    ddl300DoorType.SelectedValue = aReader[4].ToString();
                    ddl300DoorStyle.SelectedValue = aReader[5].ToString();
                    ddl300DoorSwing.SelectedValue = aReader[6].ToString();
                    ddl300DoorHinge.SelectedValue = aReader[7].ToString();
                    ddl300DoorHardware.SelectedValue = aReader[8].ToString();
                    ddl300DoorColour.SelectedValue = aReader[9].ToString();
                    ddl300DoorGlassTint.SelectedValue = aReader[10].ToString();
                    ddl300DoorVinylTint.SelectedValue = aReader[11].ToString();
                    ddl300DoorScreenType.SelectedValue = aReader[12].ToString();
                    //window
                    ddl300WindowType.SelectedValue = aReader[13].ToString();
                    //no window colour for model100, skip #14
                    ddl300WindowGlassTint.SelectedValue = aReader[15].ToString();
                    ddl300WindowVinylTint.SelectedValue = aReader[16].ToString();
                    ddl300WindowScreenType.SelectedValue = aReader[17].ToString();
                    //sunshade
                    ddl300SunshadeValanceColour.SelectedValue = aReader[18].ToString();
                    ddl300SunshadeFabricColour.SelectedValue = aReader[19].ToString();
                    ddl300SunshadeOpenness.SelectedValue = aReader[20].ToString();
                    //roof
                    ddl300RoofType.SelectedValue = aReader[21].ToString();
                    ddl300RoofInteriorSkin.SelectedValue = aReader[22].ToString();
                    ddl300RoofExteriorSkin.SelectedValue = aReader[23].ToString();
                    ddl300RoofThickness.SelectedValue = aReader[24].ToString();
                    //floor
                    ddl300FloorThickness.SelectedValue = aReader[25].ToString();

                    //if barrier is true, check the checkbox
                    if (aReader[26].ToString() == "1")
                    {
                        chk300FloorMetalBarrier.Checked = true;
                    }

                    //kneewall
                    txt300KneewallHeight.Text = aReader[27].ToString();
                    ddl300KneewallType.SelectedValue = aReader[28].ToString();
                    ddl300KneewallGlassTint.SelectedValue = aReader[29].ToString();
                    //transom
                    txt300TransomHeight.Text = aReader[30].ToString();
                    ddl300TransomType.SelectedValue = aReader[31].ToString();
                    ddl300TransomGlassTint.SelectedValue = aReader[32].ToString();
                    ddl300TransomVinylTint.SelectedValue = aReader[33].ToString();
                    ddl300TransomScreenType.SelectedValue = aReader[34].ToString();

                    txt300Markup.Text = (Convert.ToDecimal(aReader[35].ToString()) * 100).ToString();
                    aReader.Close();
                    #endregion

                    #region 400
                    aCommand.CommandText = "SELECT default_filler, interior_panel_skin, exterior_panel_skin, frame_colour, door_type, door_style, door_swing, door_hinge, door_hardware, door_colour, door_glass_tint, door_vinyl_tint, door_screen_type, window_type, window_colour, window_glass_tint, window_vinyl_tint, window_screen_type, sunshade_valance_colour, sunshade_fabric_colour, sunshade_openness, roof_type, roof_interior_skin, roof_exterior_skin, roof_thickness, floor_thickness, floor_metal_barrier, kneewall_height, kneewall_type, kneewall_glass_tint, transom_height, transom_style, transom_glass_tint, transom_vinyl_tint, transom_screen_type, markup FROM model_preferences WHERE dealer_id=" + Session["dealer_id"].ToString() + " AND model_type='400'";
                    aReader = aCommand.ExecuteReader();
                    aReader.Read();

                    txt400DefaultFiller.Text = aReader[0].ToString();
                    ddl400InteriorPanelSkin.SelectedValue = aReader[1].ToString();
                    ddl400ExteriorPanelSkin.SelectedValue = aReader[2].ToString();
                    ddl400FrameColour.SelectedValue = aReader[3].ToString();
                    //door
                    ddl400DoorType.SelectedValue = aReader[4].ToString();
                    ddl400DoorStyle.SelectedValue = aReader[5].ToString();
                    ddl400DoorSwing.SelectedValue = aReader[6].ToString();
                    ddl400DoorHinge.SelectedValue = aReader[7].ToString();
                    ddl400DoorHardware.SelectedValue = aReader[8].ToString();
                    ddl400DoorColour.SelectedValue = aReader[9].ToString();
                    ddl400DoorGlassTint.SelectedValue = aReader[10].ToString();
                    ddl400DoorVinylTint.SelectedValue = aReader[11].ToString();
                    ddl400DoorScreenType.SelectedValue = aReader[12].ToString();
                    //window
                    ddl400WindowType.SelectedValue = aReader[13].ToString();
                    //no window colour for model100, skip #14
                    ddl400WindowGlassTint.SelectedValue = aReader[15].ToString();
                    ddl400WindowVinylTint.SelectedValue = aReader[16].ToString();
                    ddl400WindowScreenType.SelectedValue = aReader[17].ToString();
                    //sunshade
                    ddl400SunshadeValanceColour.SelectedValue = aReader[18].ToString();
                    ddl400SunshadeFabricColour.SelectedValue = aReader[19].ToString();
                    ddl400SunshadeOpenness.SelectedValue = aReader[20].ToString();
                    //roof
                    ddl400RoofType.SelectedValue = aReader[21].ToString();
                    ddl400RoofInteriorSkin.SelectedValue = aReader[22].ToString();
                    ddl400RoofExteriorSkin.SelectedValue = aReader[23].ToString();
                    ddl400RoofThickness.SelectedValue = aReader[24].ToString();
                    //floor
                    ddl400FloorThickness.SelectedValue = aReader[25].ToString();

                    //if barrier is true, check the checkbox
                    if (aReader[26].ToString() == "1")
                    {
                        chk400FloorMetalBarrier.Checked = true;
                    }

                    //kneewall
                    txt400KneewallHeight.Text = aReader[27].ToString();
                    ddl400KneewallType.SelectedValue = aReader[28].ToString();
                    ddl400KneewallGlassTint.SelectedValue = aReader[29].ToString();
                    //transom
                    txt400TransomHeight.Text = aReader[30].ToString();
                    ddl400TransomType.SelectedValue = aReader[31].ToString();
                    ddl400TransomGlassTint.SelectedValue = aReader[32].ToString();
                    ddl400TransomVinylTint.SelectedValue = aReader[33].ToString();
                    ddl400TransomScreenType.SelectedValue = aReader[34].ToString();

                    txt400Markup.Text = (Convert.ToDecimal(aReader[35].ToString()) * 100).ToString();
                    aReader.Close();
                    #endregion

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
                        lblError.Text = "Rollback Exception Type: " + ex2.GetType();
                        lblError.Text += "  Message: " + ex2.Message;
                    }
                }
            }
            #endregion

            #region OnChange Binding
            #region General
            ddlInstallationType.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddlModelNumber.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddlLayout.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            #endregion          

            #region 100
            ddl100DefaultFiller.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");

            ddl100FrameColour.Attributes.Add("onChange", "return preferencesCascadeColours(100);");
            ddl100InteriorPanelColour.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl100InteriorPanelSkin.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl100ExteriorPanelColour.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl100ExteriorPanelSkin.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");

            ddl100DoorType.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl100DoorStyle.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl100DoorHinge.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl100DoorSwing.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl100DoorHardware.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl100DoorColour.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl100DoorGlassTint.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl100DoorVinylTint.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl100DoorScreenType.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");

            ddl100WindowType.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl100WindowGlassTint.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl100WindowVinylTint.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl100WindowScreenType.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");

            ddl100SunshadeValanceColour.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl100SunshadeFabricColour.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl100SunshadeOpenness.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");

            ddl100RoofType.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl100RoofThickness.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl100RoofInteriorSkin.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl100RoofExteriorSkin.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");

            ddl100FloorThickness.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");

            ddl100KneewallType.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl100KneewallHeight.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl100KneewallGlassTint.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");

            ddl100TransomType.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl100TransomHeight.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl100TransomScreenType.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl100TransomGlassTint.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl100TransomVinylTint.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            #endregion

            #region 200
            ddl200DefaultFiller.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");

            ddl200FrameColour.Attributes.Add("onChange", "return preferencesCascadeColours(200);");
            ddl200InteriorPanelColour.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl200InteriorPanelSkin.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl200ExteriorPanelColour.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl200ExteriorPanelSkin.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");

            ddl200DoorType.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl200DoorStyle.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl200DoorHinge.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl200DoorSwing.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl200DoorHardware.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl200DoorColour.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl200DoorGlassTint.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl200DoorVinylTint.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl200DoorScreenType.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");

            ddl200WindowType.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl200WindowGlassTint.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl200WindowVinylTint.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl200WindowScreenType.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");

            ddl200SunshadeValanceColour.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl200SunshadeFabricColour.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl200SunshadeOpenness.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");

            ddl200RoofType.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl200RoofThickness.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl200RoofInteriorSkin.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl200RoofExteriorSkin.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");

            ddl200FloorThickness.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");

            ddl200KneewallType.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl200KneewallHeight.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl200KneewallGlassTint.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");

            ddl200TransomType.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl200TransomHeight.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl200TransomScreenType.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl200TransomGlassTint.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl200TransomVinylTint.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            #endregion

            #region 300
            ddl300DefaultFiller.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");

            ddl300FrameColour.Attributes.Add("onChange", "return preferencesCascadeColours(300);");
            ddl300InteriorPanelColour.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl300InteriorPanelSkin.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl300ExteriorPanelColour.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl300ExteriorPanelSkin.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");

            ddl300DoorType.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl300DoorStyle.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl300DoorHinge.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl300DoorSwing.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl300DoorHardware.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl300DoorColour.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl300DoorGlassTint.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl300DoorVinylTint.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl300DoorScreenType.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");

            ddl300WindowType.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl300WindowGlassTint.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl300WindowVinylTint.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl300WindowScreenType.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");

            ddl300SunshadeValanceColour.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl300SunshadeFabricColour.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl300SunshadeOpenness.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");

            ddl300RoofType.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl300RoofThickness.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl300RoofInteriorSkin.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl300RoofExteriorSkin.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");

            ddl300FloorThickness.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");

            ddl300KneewallType.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl300KneewallHeight.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl300KneewallGlassTint.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");

            ddl300TransomType.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl300TransomHeight.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl300TransomScreenType.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl300TransomGlassTint.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl300TransomVinylTint.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            #endregion

            #region 400
            ddl400DefaultFiller.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");

            ddl400FrameColour.Attributes.Add("onChange", "return preferencesCascadeColours(400);");
            ddl400InteriorPanelColour.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl400InteriorPanelSkin.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl400ExteriorPanelColour.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl400ExteriorPanelSkin.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");

            ddl400DoorType.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl400DoorStyle.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl400DoorHinge.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl400DoorSwing.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl400DoorHardware.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl400DoorColour.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl400DoorGlassTint.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl400DoorVinylTint.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl400DoorScreenType.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");

            ddl400WindowType.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl400WindowGlassTint.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl400WindowVinylTint.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl400WindowScreenType.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");

            ddl400SunshadeValanceColour.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl400SunshadeFabricColour.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl400SunshadeOpenness.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");

            ddl400RoofType.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl400RoofThickness.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl400RoofInteriorSkin.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl400RoofExteriorSkin.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");

            ddl400FloorThickness.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");

            ddl400KneewallType.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl400KneewallHeight.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl400KneewallGlassTint.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");

            ddl400TransomType.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl400TransomHeight.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl400TransomScreenType.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl400TransomGlassTint.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            ddl400TransomVinylTint.Attributes.Add("onChange", "return MoveValuesToHiddenDivs();");
            #endregion
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
                    //Add to dealer table
                    int isChecked = 1;
                    if (chkCutPitch.Checked == false)
                    {
                        isChecked = 0;
                    }
                    aCommand.CommandText = "UPDATE preferences SET "
                                            + "installation_type='" + ddlInstallationType.SelectedValue + "', "
                                            + "model_type='" + ddlModelNumber.SelectedValue + "', "
                                            + "layout='" + "Preset 1" + "', "
                                            + "cut_pitch=" + isChecked
                                            + " WHERE dealer_id=" + Session["dealer_id"].ToString();
                    aCommand.ExecuteNonQuery(); //Execute a command that does not return anything

                    //An entrance into the model preferences table, one entry for each model type
                    #region 100
                    isChecked = 0;
                    if (chk100FloorMetalBarrier.Checked == true)
                    {
                        isChecked = 1;
                    }
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
                                            + "window_type='" + ddl100WindowType.SelectedValue + "', "
                                            + "window_colour='None',"
                                            + "window_glass_tint='" + ddl100WindowGlassTint.SelectedValue + "', "
                                            + "window_vinyl_tint='" + ddl100WindowVinylTint.SelectedValue + "', "
                                            + "window_screen_type='" + ddl100WindowScreenType.SelectedValue + "', "
                                            + "sunshade_valance_colour='" + ddl100SunshadeValanceColour.SelectedValue + "', "
                                            + "sunshade_fabric_colour='" + ddl100SunshadeFabricColour.SelectedValue + "', "
                                            + "sunshade_openness='" + ddl100SunshadeOpenness.SelectedValue + "', "
                                            + "roof_type='" + ddl100RoofType.SelectedValue + "', "
                                            + "roof_interior_skin='" + ddl100RoofInteriorSkin.SelectedValue + "', "
                                            + "roof_exterior_skin='" + ddl100RoofExteriorSkin.SelectedValue + "', "
                                            + "roof_thickness='" + ddl100RoofThickness.SelectedValue + "', "
                                            + "floor_thickness='" + ddl100FloorThickness.SelectedValue + "', "
                                            + "floor_metal_barrier='" + isChecked + "', "
                                            + "kneewall_height=" + txt100KneewallHeight.Text + ", "
                                            + "kneewall_type='" + ddl100KneewallType.SelectedValue + "', "
                                            + "kneewall_glass_tint='" + ddl100KneewallGlassTint.SelectedValue + "', "
                                            + "transom_height=" + txt100TransomHeight.Text + ", "
                                            + "transom_style='" + ddl100TransomType.SelectedValue + "', "
                                            + "transom_glass_tint='" + ddl100TransomGlassTint.SelectedValue + "', "
                                            + "transom_vinyl_tint='" + ddl100TransomVinylTint.SelectedValue + "', "
                                            + "transom_screen_type='" + ddl100TransomScreenType.SelectedValue + "', "
                                            + "markup=" + Convert.ToDecimal(txt100Markup.Text) / 100
                                            + " WHERE dealer_id=" + Session["dealer_id"].ToString() + " AND model_type='M100'";
                    aCommand.ExecuteNonQuery(); //Execute a command that does not return anything
                    #endregion

                    #region 200
                    isChecked = 0;
                    if (chk200FloorMetalBarrier.Checked == true)
                    {
                        isChecked = 1;
                    }
                    aCommand.CommandText = "UPDATE model_preferences SET "
                                            + "default_filler=" + txt200DefaultFiller.Text + ", "
                                            + "interior_panel_skin='" + ddl200InteriorPanelSkin.SelectedValue + "', "
                                            + "exterior_panel_skin='" + ddl200ExteriorPanelSkin.SelectedValue + "', "
                                            + "frame_colour='" + ddl200FrameColour.SelectedValue + "', "
                                            + "door_type='" + ddl200DoorType.SelectedValue + "', "
                                            + "door_style='" + ddl200DoorStyle.SelectedValue + "', "
                                            + "door_swing='" + ddl200DoorSwing.SelectedValue + "', "
                                            + "door_hinge='" + ddl200DoorHinge.SelectedValue + "', "
                                            + "door_hardware='" + ddl200DoorHardware.SelectedValue + "', "
                                            + "door_colour='" + ddl200DoorColour.SelectedValue + "', "
                                            + "door_glass_tint='" + ddl200DoorGlassTint.SelectedValue + "', "
                                            + "door_vinyl_tint='" + ddl200DoorVinylTint.SelectedValue + "', "
                                            + "door_screen_type='" + ddl200DoorScreenType.SelectedValue + "', "
                                            + "window_type='" + ddl200WindowType.SelectedValue + "', "
                                            + "window_colour='" + ddl200WindowColour.SelectedValue + "', "
                                            + "window_glass_tint='" + ddl200WindowGlassTint.SelectedValue + "', "
                                            + "window_vinyl_tint='" + ddl200WindowVinylTint.SelectedValue + "', "
                                            + "window_screen_type='" + ddl200WindowScreenType.SelectedValue + "', "
                                            + "sunshade_valance_colour='" + ddl200SunshadeValanceColour.SelectedValue + "', "
                                            + "sunshade_fabric_colour='" + ddl200SunshadeFabricColour.SelectedValue + "', "
                                            + "sunshade_openness='" + ddl200SunshadeOpenness.SelectedValue + "', "
                                            + "roof_type='" + ddl200RoofType.SelectedValue + "', "
                                            + "roof_interior_skin='" + ddl200RoofInteriorSkin.SelectedValue + "', "
                                            + "roof_exterior_skin='" + ddl200RoofExteriorSkin.SelectedValue + "', "
                                            + "roof_thickness='" + ddl200RoofThickness.SelectedValue + "', "
                                            + "floor_thickness='" + ddl200FloorThickness.SelectedValue + "', "
                                            + "floor_metal_barrier='" + isChecked + "', "
                                            + "kneewall_height=" + txt200KneewallHeight.Text + ", "
                                            + "kneewall_type='" + ddl200KneewallType.SelectedValue + "', "
                                            + "kneewall_glass_tint='" + ddl200KneewallGlassTint.SelectedValue + "', "
                                            + "transom_height=" + txt200TransomHeight.Text + ", "
                                            + "transom_style='" + ddl200TransomType.SelectedValue + "', "
                                            + "transom_glass_tint='" + ddl200TransomGlassTint.SelectedValue + "', "
                                            + "transom_vinyl_tint='" + ddl200TransomVinylTint.SelectedValue + "', "
                                            + "transom_screen_type='" + ddl200TransomScreenType.SelectedValue + "', "
                                            + "markup=" + Convert.ToDecimal(txt200Markup.Text) / 100
                                            + " WHERE dealer_id=" + Session["dealer_id"].ToString() + " AND model_type='M200'";
                    aCommand.ExecuteNonQuery(); //Execute a command that does not return anything
                    #endregion

                    #region 300
                    isChecked = 0;
                    if (chk300FloorMetalBarrier.Checked == true)
                    {
                        isChecked = 1;
                    }
                    aCommand.CommandText = "UPDATE model_preferences SET "
                                            + "default_filler=" + txt300DefaultFiller.Text + ", "
                                            + "interior_panel_skin='" + ddl300InteriorPanelSkin.SelectedValue + "', "
                                            + "exterior_panel_skin='" + ddl300ExteriorPanelSkin.SelectedValue + "', "
                                            + "frame_colour='" + ddl300FrameColour.SelectedValue + "', "
                                            + "door_type='" + ddl300DoorType.SelectedValue + "', "
                                            + "door_style='" + ddl300DoorStyle.SelectedValue + "', "
                                            + "door_swing='" + ddl300DoorSwing.SelectedValue + "', "
                                            + "door_hinge='" + ddl300DoorHinge.SelectedValue + "', "
                                            + "door_hardware='" + ddl300DoorHardware.SelectedValue + "', "
                                            + "door_colour='" + ddl300DoorColour.SelectedValue + "', "
                                            + "door_glass_tint='" + ddl300DoorGlassTint.SelectedValue + "', "
                                            + "door_vinyl_tint='" + ddl300DoorVinylTint.SelectedValue + "', "
                                            + "door_screen_type='" + ddl300DoorScreenType.SelectedValue + "', "
                                            + "window_type='" + ddl300WindowType.SelectedValue + "', "
                                            + "window_colour='" + ddl300WindowColour.SelectedValue + "', "
                                            + "window_glass_tint='" + ddl300WindowGlassTint.SelectedValue + "', "
                                            + "window_vinyl_tint='" + ddl300WindowVinylTint.SelectedValue + "', "
                                            + "window_screen_type='" + ddl300WindowScreenType.SelectedValue + "', "
                                            + "sunshade_valance_colour='" + ddl300SunshadeValanceColour.SelectedValue + "', "
                                            + "sunshade_fabric_colour='" + ddl300SunshadeFabricColour.SelectedValue + "', "
                                            + "sunshade_openness='" + ddl300SunshadeOpenness.SelectedValue + "', "
                                            + "roof_type='" + ddl300RoofType.SelectedValue + "', "
                                            + "roof_interior_skin='" + ddl300RoofInteriorSkin.SelectedValue + "', "
                                            + "roof_exterior_skin='" + ddl300RoofExteriorSkin.SelectedValue + "', "
                                            + "roof_thickness='" + ddl300RoofThickness.SelectedValue + "', "
                                            + "floor_thickness='" + ddl300FloorThickness.SelectedValue + "', "
                                            + "floor_metal_barrier='" + isChecked + "', "
                                            + "kneewall_height=" + txt300KneewallHeight.Text + ", "
                                            + "kneewall_type='" + ddl300KneewallType.SelectedValue + "', "
                                            + "kneewall_glass_tint='" + ddl300KneewallGlassTint.SelectedValue + "', "
                                            + "transom_height=" + txt300TransomHeight.Text + ", "
                                            + "transom_style='" + ddl300TransomType.SelectedValue + "', "
                                            + "transom_glass_tint='" + ddl300TransomGlassTint.SelectedValue + "', "
                                            + "transom_vinyl_tint='" + ddl300TransomVinylTint.SelectedValue + "', "
                                            + "transom_screen_type='" + ddl300TransomScreenType.SelectedValue + "', "
                                            + "markup=" + Convert.ToDecimal(txt300Markup.Text) / 100
                                            + " WHERE dealer_id=" + Session["dealer_id"].ToString() + " AND model_type='M300'";
                    aCommand.ExecuteNonQuery(); //Execute a command that does not return anything
                    #endregion

                    #region 400
                    isChecked = 0;
                    if (chk400FloorMetalBarrier.Checked == true)
                    {
                        isChecked = 1;
                    }
                    aCommand.CommandText = "UPDATE model_preferences SET "
                                            + "default_filler=" + txt400DefaultFiller.Text + ", "
                                            + "interior_panel_skin='" + ddl400InteriorPanelSkin.SelectedValue + "', "
                                            + "exterior_panel_skin='" + ddl400ExteriorPanelSkin.SelectedValue + "', "
                                            + "frame_colour='" + ddl400FrameColour.SelectedValue + "', "
                                            + "door_type='" + ddl400DoorType.SelectedValue + "', "
                                            + "door_style='" + ddl400DoorStyle.SelectedValue + "', "
                                            + "door_swing='" + ddl400DoorSwing.SelectedValue + "', "
                                            + "door_hinge='" + ddl400DoorHinge.SelectedValue + "', "
                                            + "door_hardware='" + ddl400DoorHardware.SelectedValue + "', "
                                            + "door_colour='" + ddl400DoorColour.SelectedValue + "', "
                                            + "door_glass_tint='" + ddl400DoorGlassTint.SelectedValue + "', "
                                            + "door_vinyl_tint='" + ddl400DoorVinylTint.SelectedValue + "', "
                                            + "door_screen_type='" + ddl400DoorScreenType.SelectedValue + "', "
                                            + "window_type='" + ddl400WindowType.SelectedValue + "', "
                                            + "window_colour='" + ddl400WindowColour.SelectedValue + "', "
                                            + "window_glass_tint='" + ddl400WindowGlassTint.SelectedValue + "', "
                                            + "window_vinyl_tint='" + ddl400WindowVinylTint.SelectedValue + "', "
                                            + "window_screen_type='" + ddl400WindowScreenType.SelectedValue + "', "
                                            + "sunshade_valance_colour='" + ddl400SunshadeValanceColour.SelectedValue + "', "
                                            + "sunshade_fabric_colour='" + ddl400SunshadeFabricColour.SelectedValue + "', "
                                            + "sunshade_openness='" + ddl400SunshadeOpenness.SelectedValue + "', "
                                            + "roof_type='" + ddl400RoofType.SelectedValue + "', "
                                            + "roof_interior_skin='" + ddl400RoofInteriorSkin.SelectedValue + "', "
                                            + "roof_exterior_skin='" + ddl400RoofExteriorSkin.SelectedValue + "', "
                                            + "roof_thickness='" + ddl400RoofThickness.SelectedValue + "', "
                                            + "floor_thickness='" + ddl400FloorThickness.SelectedValue + "', "
                                            + "floor_metal_barrier='" + isChecked + "', "
                                            + "kneewall_height=" + txt400KneewallHeight.Text + ", "
                                            + "kneewall_type='" + ddl400KneewallType.SelectedValue + "', "
                                            + "kneewall_glass_tint='" + ddl400KneewallGlassTint.SelectedValue + "', "
                                            + "transom_height=" + txt400TransomHeight.Text + ", "
                                            + "transom_style='" + ddl400TransomType.SelectedValue + "', "
                                            + "transom_glass_tint='" + ddl400TransomGlassTint.SelectedValue + "', "
                                            + "transom_vinyl_tint='" + ddl400TransomVinylTint.SelectedValue + "', "
                                            + "transom_screen_type='" + ddl400TransomScreenType.SelectedValue + "', "
                                            + "markup=" + Convert.ToDecimal(txt400Markup.Text) / 100
                                            + " WHERE dealer_id=" + Session["dealer_id"].ToString() + " AND model_type='M400'";
                    aCommand.ExecuteNonQuery(); //Execute a command that does not return anything
                    #endregion

                    lblError.Text = "Successfully Updated!\n\n";
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
                        lblError.Text = "Rollback Exception Type: " + ex2.GetType();
                        lblError.Text += "  Message: " + ex2.Message;
                    }
                }
            }
        }

        protected void btnAddUsers_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddUsers.aspx");
        }
    }
}
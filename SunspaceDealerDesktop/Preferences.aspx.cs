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
                #endregion
                #region 200
                #endregion
                #region 300
                #endregion
                #region 400
                #endregion
            #endregion

            #region Window Options
                #region 100
                #endregion
                #region 200
                #endregion
                #region 300
                #endregion
                #region 400
                #endregion
            #endregion

            #region Sunshade Options
                #region 100
                #endregion
                #region 200
                #endregion
                #region 300
                #endregion
                #region 400
                #endregion
            #endregion

            #region Roof Options
                #region 100
                #endregion
                #region 200
                #endregion
                #region 300
                #endregion
                #region 400
                #endregion
            #endregion

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
                #endregion
                #region 200
                #endregion
                #region 300
                #endregion
                #region 400
                #endregion
            #endregion

            #region Transom Options
                #region 100
                #endregion
                #region 200
                #endregion
                #region 300
                #endregion
                #region 400
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
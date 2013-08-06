using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SunspaceDealerDesktop
{
    public partial class RoofWizard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Temporary session declarations
                string[] tempArray = new String[27];
                tempArray[26] = "Studio";
                Session.Add("newProjectArray", tempArray);
                Session.Add("sunroomProjection", 120);
                Session.Add("sunroomWidth", 120);
                Session.Add("roofSlope", 10);
                Session.Add("soffitLength", 0);
                Session.Add("isStandalone", "false");

                //Create a temporary fake list of walls, will use a [ shape, W/S/E walls going from 120 backwall to 110 front wall, 120 projection, 120 width, to match other fake variables
                List<Wall> aListOfWalls = new List<Wall>();

                Wall aWall = new Wall();
                aWall.Length = 120;
                aWall.StartHeight = 120;
                aWall.EndHeight = 110;
                aWall.Orientation = "W";

                aListOfWalls.Add(aWall);

                aWall = new Wall();
                aWall.Length = 120;
                aWall.StartHeight = 110;
                aWall.EndHeight = 110;
                aWall.Orientation = "SW";

                aListOfWalls.Add(aWall);

                aWall = new Wall();
                aWall.Length = 120;
                aWall.StartHeight = 110;
                aWall.EndHeight = 110;
                aWall.Orientation = "SE";

                aListOfWalls.Add(aWall);

                aWall = new Wall();
                aWall.Length = 120;
                aWall.StartHeight = 110;
                aWall.EndHeight = 120;
                aWall.Orientation = "E";

                aListOfWalls.Add(aWall);
                Session.Add("listOfWalls", aListOfWalls);
                //slope
                //enter an overhang #
                //include gutter in overhang

                #region Dropdown Population
                //Thickness
                for (int i = 0; i < Constants.ROOF_THICKNESSES.Length; i++)
                {
                    ddlThickness.Items.Add(new ListItem(Constants.ROOF_THICKNESSES[i], Constants.ROOF_THICKNESSES[i]));
                }
                //Acrylic Colour
                for (int i = 0; i < Constants.ACRYLIC_COLOUR.Length; i++)
                {
                    ddlAcrylicColour.Items.Add(new ListItem(Constants.ACRYLIC_COLOUR[i], Constants.ACRYLIC_COLOUR[i]));
                }
                //Extrusion Type
                for (int i = 0; i < Constants.ROOF_EXTRUSION_TYPE.Length; i++)
                {
                    ddlExtrusionType.Items.Add(new ListItem(Constants.ROOF_EXTRUSION_TYPE[i], Constants.ROOF_EXTRUSION_TYPE[i]));
                }
                //Interior Skin
                for (int i = 0; i < Constants.ROOF_INTERIOR_SKIN_TYPES.Length; i++)
                {
                    ddlInteriorRoofSkin.Items.Add(new ListItem(Constants.ROOF_INTERIOR_SKIN_TYPES[i], Constants.ROOF_INTERIOR_SKIN_TYPES[i]));
                }
                //Exterior Skin
                for (int i = 0; i < Constants.ROOF_EXTERIOR_SKIN_TYPES.Length; i++)
                {
                    ddlExteriorRoofSkin.Items.Add(new ListItem(Constants.ROOF_EXTERIOR_SKIN_TYPES[i], Constants.ROOF_EXTERIOR_SKIN_TYPES[i]));
                }
                //gutter/fascia colour
                for (int i = 0; i < Constants.GUTTER_COLOUR.Length; i++)
                {
                    ddlGutterColour.Items.Add(new ListItem(Constants.GUTTER_COLOUR[i], Constants.GUTTER_COLOUR[i]));
                }
                #endregion
            }
        }

        protected void btnFinalButton_Click(object sender, EventArgs e)
        {
            //Check roof type, position 26
            string[] newProjectArray = (string[])Session["newProjectArray"];

            double roofProjection = Convert.ToDouble(Session["sunroomProjection"]);
            double roofWidth = Convert.ToDouble(Session["sunroomWidth"]);

            double roofSlope = Convert.ToDouble(Session["roofSlope"]);
            double soffitLength = Convert.ToDouble(Session["soffitLength"]);

            //if gable, we need two studio roof systems and additional logic
            if (newProjectArray[26] == "Dealer Gable" || newProjectArray[26] == "Sunspace Gable")
            {

            }
            //studio system
            else
            {
                if (Session["isStandalone"].ToString() == "true")
                {
                    //Subtract soffit length as that will be the true start point of the roof
                    roofProjection -= Convert.ToDouble(Session["soffitLength"]);

                    roofProjection += (Convert.ToDouble(hidOverhang.Value) * 2);
                    roofWidth += (Convert.ToDouble(hidOverhang.Value) * 2);
                    
                    //build roof objects
                }
                else
                {
                    
                }

                Session.Add("roofProjection", roofProjection);
                Session.Add("roofWidth", roofWidth);
                lblTest.Text = roofProjection.ToString() + " by " + roofWidth.ToString();
            }
        }
    }
}
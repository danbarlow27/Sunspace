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
                Session.Add("isStandalone", "true");

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
                aWall.Orientation = "S";

                aListOfWalls.Add(aWall);

                aWall = new Wall();
                aWall.Length = 120;
                aWall.StartHeight = 110;
                aWall.EndHeight = 120;
                aWall.Orientation = "E";

                aListOfWalls.Add(aWall);

                aWall = new Wall();
                aWall.Length = 120;
                aWall.StartHeight = 120;
                aWall.EndHeight = 120;
                aWall.Orientation = "N";

                aListOfWalls.Add(aWall);
                Session.Add("listOfWalls", aListOfWalls);
                //slope
                //enter an overhang #
                //include gutter in overhang

                //Fill skin dropdowns
                for (int i = 0; i < Constants.ROOF_INTERIOR_SKIN_TYPES.Length; i++)
                {
                    ddlInteriorRoofSkin.Items.Add(new ListItem(Constants.ROOF_INTERIOR_SKIN_TYPES[i], Constants.ROOF_INTERIOR_SKIN_TYPES[i]));
                }

                for (int i = 0; i < Constants.ROOF_EXTERIOR_SKIN_TYPES.Length; i++)
                {
                    ddlExteriorRoofSkin.Items.Add(new ListItem(Constants.ROOF_EXTERIOR_SKIN_TYPES[i], Constants.ROOF_EXTERIOR_SKIN_TYPES[i]));
                }

                //fill colour dropdown by model#
            }
        }

        protected void btnFinalButton_Click(object sender, EventArgs e)
        {
            //Check roof type, position 26
            string[] newProjectArray = (string[])Session["newProjectArray"];

            double roofProjection = (double)Session["sunroomProjection"];
            double roofWidth = (double)Session["sunroomWidth"];

            double roofSlope = (double)Session["roofSlope"];
            double soffitLength = (double)Session["soffitLength"];

            //if gable, we need two studio roof systems and additional logic
            if (newProjectArray[26] == "Dealer Gable" || newProjectArray[26] == "Sunspace Gable")
            {

            }
            //studio system
            else
            {
                if (Session["isStandalone"] == "true")
                {
                    roofProjection += (Convert.ToDouble(hidOverhang.Value) * 2);
                    roofWidth += (Convert.ToDouble(hidOverhang.Value) * 2);
                    
                    //build roof objects
                }
                else
                {
                    //N, S will add one overhang to projection each
                    //E, W, will add one overhang to width each
                    //NE, NW, SE, SW will add one overhang to projection AND width, each.
                    List<Wall> listOfWalls = (List<Wall>)Session["listOfWalls"];
                    string previousWallDirection;

                    for (int i = 0; i < listOfWalls.Count; i++)
                    {
                        if (listOfWalls[i].Orientation == "N" || listOfWalls[i].Orientation == "S")
                        {
                            roofProjection += Convert.ToDouble(hidOverhang.Value);
                            previousWallDirection = listOfWalls[i].Orientation;
                        }
                        else if (listOfWalls[i].Orientation == "E" || listOfWalls[i].Orientation == "W")
                        {
                            roofWidth += Convert.ToDouble(hidOverhang.Value);
                            previousWallDirection = listOfWalls[i].Orientation;
                        }
                        //NW and SE will effect projection using their start
                        else if (listOfWalls[i].Orientation == "NW" || listOfWalls[i].Orientation == "SE")
                        {
                            try
                            {
                                //If it goes from angled to angled we have special rules, if it goes from angled to flat, we disregard its effect, as its handled by the next wall 
                                if (listOfWalls[i + 1].Orientation == "NE" || listOfWalls[i + 1].Orientation == "NW" || listOfWalls[i + 1].Orientation == "SE" || listOfWalls[i + 1].Orientation == "SW")
                                {

                                }
                                else
                                {

                                }
                            }
                            //If error is thrown, its the last wall in the list
                            catch (Exception ex)
                            {
                            }
                        }
                    }
                }                
            }
        }
    }
}
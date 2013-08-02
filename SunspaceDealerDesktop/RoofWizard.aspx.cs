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
                    //Subtract soffit length as that will be the true start point of the roof
                    roofProjection -= (double)Session["soffitLength"];

                    //N, S will add one overhang to projection each
                    //E, W, will add one overhang to width each
                    //NE, NW, SE, SW will add one overhang to projection AND width, each.
                    List<Wall> listOfWalls = (List<Wall>)Session["listOfWalls"];

                    for (int i = 0; i < listOfWalls.Count; i++)
                    {
                        try
                        {
                            if (listOfWalls[i].Orientation == "N" || listOfWalls[i].Orientation == "S")
                            {
                                roofProjection += Convert.ToDouble(hidOverhang.Value);
                            }
                            else if (listOfWalls[i].Orientation == "E" || listOfWalls[i].Orientation == "W")
                            {
                                roofWidth += Convert.ToDouble(hidOverhang.Value);
                            }
                            else if (listOfWalls[i].Orientation == "NE")
                            {
                                //If next wall is angled we need special rules
                                if (listOfWalls[i + 1].Orientation == "SE")
                                {
                                    //if NE+SE corner, only add once to width
                                    roofWidth += Convert.ToDouble(hidOverhang.Value);
                                }
                                if (listOfWalls[i + 1].Orientation == "NW")
                                {
                                    //if NE+NW corner, only add once to projection
                                    roofProjection += Convert.ToDouble(hidOverhang.Value);
                                }
                            }
                            else if (listOfWalls[i].Orientation == "SE")
                            {
                                //If next wall is angled we need special rules
                                if (listOfWalls[i + 1].Orientation == "NE")
                                {
                                    //if NE+SE corner, only add once to width
                                    roofWidth += Convert.ToDouble(hidOverhang.Value);
                                }
                                if (listOfWalls[i + 1].Orientation == "SW")
                                {
                                    //if SE+SW corner, only add once to projection
                                    roofProjection += Convert.ToDouble(hidOverhang.Value);
                                }                                
                            }
                            else if (listOfWalls[i].Orientation == "SW")
                            {
                                //If next wall is angled we need special rules
                                if (listOfWalls[i + 1].Orientation == "SE")
                                {
                                    //if SE+SW corner, only add once to projection
                                    roofProjection += Convert.ToDouble(hidOverhang.Value);
                                }
                                if (listOfWalls[i + 1].Orientation == "NW")
                                {
                                    //if SW+NW  corner, only add once to width
                                    roofWidth += Convert.ToDouble(hidOverhang.Value);
                                }
                            }
                            else if (listOfWalls[i].Orientation == "NW")
                            {
                                //If next wall is angled we need special rules
                                if (listOfWalls[i + 1].Orientation == "NE")
                                {
                                    //if NE+NW corner, only add once to projection
                                    roofProjection += Convert.ToDouble(hidOverhang.Value);
                                }
                                if (listOfWalls[i + 1].Orientation == "SW")
                                {
                                    //if SW+NW  corner, only add once to width
                                    roofWidth += Convert.ToDouble(hidOverhang.Value);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            ////This means its the last wall and also angled. Now check its orientation to apply a special rule
                            //if (listOfWalls[i].Orientation == "NE")
                            //{
                            //    //if last wall is NE we add to projection
                            //    roofProjection += Convert.ToDouble(hidOverhang.Value);
                            //}
                            //else if (listOfWalls[i].Orientation == "SE")
                            //{
                            //    //If last wall is SE we add to width
                            //    roofWidth += Convert.ToDouble(hidOverhang.Value);
                            //}
                            //else if (listOfWalls[i].Orientation == "NW")
                            //{
                            //    //If last wall is NW we add to width
                            //    roofWidth += Convert.ToDouble(hidOverhang.Value);
                            //}
                            //else
                            //{
                            //    //if last wall is SW we add to projection
                            //    roofProjection += Convert.ToDouble(hidOverhang.Value);
                            //}
                        }
                    }
                }                
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace SunspaceDealerDesktop
{
    public partial class ProjEd : System.Web.UI.Page
    {        
        //fractions list for dropdowns
        protected List<ListItem> fractionList = GlobalFunctions.FractionOptions();

        //Model type list for dropdowns
        protected string[] modelNumbers = Constants.MODEL_NUMBERS;

        //roofstyle type list for dropdowns
        protected string[] roofTypes = Constants.ROOF_TYPES;

        //Framing Colours, Exterior/Interior Colours/Skins
        protected string[] model100FramingColours = Constants.MODEL_100_FRAMING_COLOURS;
        protected string[] model200FramingColours = Constants.MODEL_200_FRAMING_COLOURS;
        protected string[] model300FramingColours = Constants.MODEL_300_FRAMING_COLOURS;
        protected string[] model400FramingColours = Constants.MODEL_400_FRAMING_COLOURS;

        protected string[] interiorWallColours = Constants.INTERIOR_WALL_COLOURS;
        protected string[] exteriorWallColours = Constants.EXTERIOR_WALL_COLOURS;

        protected string[] interiorWallSkinTypes = Constants.INTERIOR_WALL_SKIN_TYPES;
        protected string[] exteriorWallSkinTypes = Constants.EXTERIOR_WALL_SKIN_TYPES;

        //protected int project_id = Session["newProjectProjectID"];
        


        protected void Page_Load(object sender, EventArgs e)
        {

            int project_id = 10;
            string project_type;
            string installation_type;
            string project_name;

            int wallCount;
            int wall_index;
            string wall_type;
            string model_type;
            float wall_length;
            string orientation;
            float set_back;
            string name;
            int first_item_index;
            int last_item_index;
            float wall_start_height;
            float wall_end_height;
            float soffit_length;
            float gable_peak;
            int obstructions;
            bool fire_protection;

            int linear_index = 0;
            string linear_type;
            float linear_start_height;
            float linear_end_height;
            float linear_length;
            string frame_colour;
            string sex;
            float fixed_location;
            bool attached_to;

            int module_index;
            string item_type;
            float module_start_height;
            float module_end_height;
            float module_length;

            
            #region attempt at hitting the database (not functional)
            
            //List<Wall> listOfWalls = (List<Wall>)Session["listOfWalls"];
            List<Wall> listOfWalls = new List<Wall>();


            using (SqlConnection aConnection = new SqlConnection(sdsDBConnection.ConnectionString))
            {
                aConnection.Open();
                SqlCommand aCommand = aConnection.CreateCommand();
                SqlTransaction aTransaction;
                SqlDataReader aReader;

                // Start a local transaction.
                aTransaction = aConnection.BeginTransaction("SampleTransaction");

                // Must assign both transaction object and connection 
                // to Command object for a pending local transaction
                aCommand.Connection = aConnection;
                aCommand.Transaction = aTransaction;

                try
                {                    

                    //get number of walls
                    aCommand.CommandText = "SELECT * FROM walls WHERE project_id = '" + project_id + "'";
                    aReader = aCommand.ExecuteReader();
                    
                    wallCount  = aReader.RecordsAffected; //get the number of walls in the project

                    aReader.Close();

                    for (int i = 0; i < wallCount; i++)
                    {
                        aCommand.CommandText = "SELECT wall_type, model_type, total_length, orientation, set_back, name, first_item_index, last_item_index, start_height, end_height, soffit_length, gable_peak, obstructions, fire_protection "
                        + "FROM walls WHERE project_id = '" + project_id + "' AND wall_index = '" + i + "'";

                        aReader = aCommand.ExecuteReader();
                        aReader.Read();

                        //create a new instance of a wall and set all its attributes from the db
                        Wall aWall = new Wall(); 
                        aWall.WallType = Convert.ToString(aReader[0]);
                        aWall.ModelType = Convert.ToString(aReader[1]);
                        aWall.Length = Convert.ToSingle(aReader[2]);
                        aWall.Orientation = Convert.ToString(aReader[3]);
                        aWall.SetBack = Convert.ToSingle(aReader[4]);
                        aWall.Name = Convert.ToString(aReader[5]);
                        aWall.FirstItemIndex = Convert.ToInt32(aReader[6]);
                        aWall.LastItemIndex = Convert.ToInt32(aReader[7]);
                        aWall.StartHeight = Convert.ToSingle(aReader[8]);
                        aWall.EndHeight = Convert.ToSingle(aReader[9]);
                        aWall.SoffitLength = Convert.ToSingle(aReader[10]);
                        aWall.GablePeak = Convert.ToSingle(aReader[11]);
                        //aWall.Obstructions = aReader[12]); how do we deal with obstructions
                        aWall.FireProtection = Convert.ToBoolean(aReader[13]);

                        aReader.Close();

                        List<LinearItem> listOfLinearItems = new List<LinearItem>();
                        

                        for (int j = aWall.FirstItemIndex; j < aWall.LastItemIndex; j++)
                        {
                            //Get linear items
                            aCommand.CommandText = "SELECT linear_index, linear_type, start_height, end_height, length, frame_colour, sex, fixed_location, attached_to "
                                                    + "FROM linear_items WHERE project_id = '" + project_id + "' AND linear_index = '" + j + "'";
                            aReader = aCommand.ExecuteReader();
                            aReader.Read();

                            LinearItem aLinearItem = new LinearItem();

                            aLinearItem.LinearIndex = Convert.ToInt32(aReader[0]);
                            aLinearItem.ItemType = Convert.ToString(aReader[1]);
                            aLinearItem.StartHeight = Convert.ToSingle(aReader[2]);
                            aLinearItem.EndHeight = Convert.ToSingle(aReader[3]);
                            aLinearItem.Length = Convert.ToSingle(aReader[4]);
                            aLinearItem.FrameColour = Convert.ToString(aReader[5]);
                            aLinearItem.Sex = Convert.ToString(aReader[6]);
                            aLinearItem.FixedLocation = Convert.ToSingle(aReader[7]);
                            aLinearItem.AttachedTo = Convert.ToBoolean(aReader[8]);

                            aReader.Close();

                            List<ModuleItem> listOfModuleItems = new List<ModuleItem>();

                            //get number of mods
                            aCommand.CommandText = "SELECT * FROM moduleItems WHERE project_id = '" + project_id + "' "
                                                                            + " AND linear_index = '" + aLinearItem.LinearIndex + "'";
                            aReader = aCommand.ExecuteReader();

                            int modCount = aReader.RecordsAffected; //get the number of walls in the project

                            aReader.Close();

                            for (int k = 0; k < modCount; k++)
                            {
                                //Get linear items
                                aCommand.CommandText = "SELECT module_index, item_type, start_height, end_height, length FROM moduleItems " 
                                                        + "WHERE project_id = '" + project_id + "' AND linear_index = '" + aLinearItem.LinearIndex + "' AND module_index = '" + k + "'";

                                aReader = aCommand.ExecuteReader();
                                aReader.Read();


                                ModuleItem aModuleItem = new ModuleItem();

                                aModuleItem.ModuleIndex = Convert.ToInt32(aReader[0]);
                                aModuleItem.ItemType = Convert.ToString(aReader[1]);
                                aModuleItem.FStartHeight = Convert.ToSingle(aReader[2]);
                                aModuleItem.FEndHeight = Convert.ToSingle(aReader[3]);
                                aModuleItem.FLength = Convert.ToSingle(aReader[4]);
                        
                                aReader.Close();


                                //different types of mods 



                                listOfModuleItems.Add(aModuleItem);


                            }

                            listOfLinearItems.Add(aLinearItem);
        
                        }

                        aWall.LinearItems = listOfLinearItems; 

                        listOfWalls.Add(aWall); //add the wall


                    }




                    //lblError.Text = "Successfully Updated!\n\n";
                    aTransaction.Commit();

                    Response.Redirect("SavedProjects.aspx", false);
                }
                catch (Exception ex)
                {
                    //lblError.Text = "Commit Exception Type: " + ex.GetType();
                    //lblError.Text += "  Message: " + ex.Message;

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
                        //lblError.Text = "Rollback Exception Type: " + ex2.GetType();
                        //lblError.Text += "  Message: " + ex2.Message;
                    }
                }
            }
            
            #endregion





            #region hardcode population
            //This info will all come from the database eventually            

            //List<Wall> listOfWalls = new List<Wall>();
            float backwall = 150.0f;
            float frontwall = 140.0f;
            float slope = 0.6f;
            string projectName = "Joey's Super Fantastic Sunroom";
            string modelType = "M200";
            string roofStyle = "Studio";
            bool cutPitch = true;
            string installType = "trailer";
            string framingColour = "Driftwood";
            string interiorColour = "Driftwood";
            string exteriorColour = "Driftwood";
            string interiorSkin = "Driftwood Aluminum Stucco";
            string exteriorSkin = "Driftwood Aluminum Stucco";

            Wall firstWall = new Wall();
            firstWall.Length = 200;
            firstWall.Orientation = "WEST";
            firstWall.Name = "Wall 1";
            firstWall.WallType = "Proposed";
            firstWall.ModelType = "M200";
            firstWall.StartHeight = 150;
            firstWall.EndHeight = 140;
            firstWall.SoffitLength = 0;
            firstWall.GablePeak = 0;
            firstWall.SoffitLength = 0;

            Wall secondWall = new Wall();
            secondWall.Length = 200;
            secondWall.Orientation = "SOUTH";
            secondWall.Name = "Wall 2";
            secondWall.WallType = "Proposed";
            secondWall.ModelType = "M200";
            secondWall.StartHeight = 140;
            secondWall.EndHeight = 140;
            secondWall.SoffitLength = 0;
            secondWall.GablePeak = 0;
            secondWall.SoffitLength = 0;

            Wall thirdWall = new Wall();
            thirdWall.Length = 200;
            thirdWall.Orientation = "EAST";
            thirdWall.Name = "Wall 3";
            thirdWall.WallType = "Proposed";
            thirdWall.ModelType = "M200";
            thirdWall.StartHeight = 140;
            thirdWall.EndHeight = 150;
            thirdWall.SoffitLength = 0;
            thirdWall.GablePeak = 0;
            thirdWall.SoffitLength = 0;

            listOfWalls.Add(firstWall);
            listOfWalls.Add(secondWall);
            listOfWalls.Add(thirdWall);
            #endregion  //hardcode population

            #region dynamic accordion population

                #region Project Wide
                accordion.Controls.Add(new LiteralControl("<h2>Project Wide Settings</h2>"));
                accordion.Controls.Add(new LiteralControl("<ul>"));

                    #region Tag Name
                    accordion.Controls.Add(new LiteralControl("<li>"));
                    Label tagName = new Label();
                    tagName.ID = "lblTagName";
                    tagName.Text = "Tag Name: ";
                    accordion.Controls.Add(tagName);

                    TextBox tagNameTextBox = new TextBox();
                    tagNameTextBox.ID = "txtTagName";
                    tagNameTextBox.Text = projectName.ToString();
                    tagNameTextBox.CssClass = "txtField txtInput";
                    tagNameTextBox.Attributes.Add("onkeydown", "return (event.keyCode!=13);");
                    tagNameTextBox.Attributes.Add("runat", "server");
                    accordion.Controls.Add(tagNameTextBox);
                    accordion.Controls.Add(new LiteralControl("</li>"));
                    #endregion //tag name

                    #region Model Type
                    accordion.Controls.Add(new LiteralControl("<li>"));
                    Label modelLabel = new Label();
                    modelLabel.ID = "lblModelLabel";
                    modelLabel.Text = "Model Type: ";
                    accordion.Controls.Add(modelLabel);

                    DropDownList modelDropDown = new DropDownList();
                    modelDropDown.ID = "ddlModel";

                    for (int i = 0; i < modelNumbers.Length; i++)
                    {
                        modelDropDown.Items.Add(modelNumbers[i].ToString());
                    }

                    modelDropDown.SelectedValue = modelType;
                    modelDropDown.Attributes.Add("runat", "server");
                    accordion.Controls.Add(modelDropDown);
                    accordion.Controls.Add(new LiteralControl("</li>"));
                    #endregion //model type

                    #region Roof Style
                    accordion.Controls.Add(new LiteralControl("<li>"));
                    Label styleLabel = new Label();
                    styleLabel.ID = "lblStyleLabel";
                    styleLabel.Text = "Roof Style: ";
                    accordion.Controls.Add(styleLabel);

                    DropDownList styleDropDown = new DropDownList();
                    styleDropDown.ID = "ddlStyle";

                    for (int i = 0; i < roofTypes.Length; i++)
                    {
                        styleDropDown.Items.Add(roofTypes[i].ToString());
                    }

                    styleDropDown.SelectedValue = roofStyle;
                    styleDropDown.Attributes.Add("runat", "server");
                    accordion.Controls.Add(styleDropDown);
                    accordion.Controls.Add(new LiteralControl("</li>"));
                    #endregion //roof style

                    #region Cut Pitch
                    accordion.Controls.Add(new LiteralControl("<li>"));
                    Label firstCutPitchLabel = new Label();
                    firstCutPitchLabel.ID = "lblFirstCutPitch";
                    firstCutPitchLabel.Text = "Cut Pitch";
                    accordion.Controls.Add(firstCutPitchLabel);

                    CheckBox cutPitchCheckBox = new CheckBox();
                    cutPitchCheckBox.ID = "chkCutPitch";
                    cutPitchCheckBox.Checked = cutPitch;
                    cutPitchCheckBox.Text = " ";
                    cutPitchCheckBox.Attributes.Add("runat", "server");
                    accordion.Controls.Add(cutPitchCheckBox);

                    Label secondCutPitchLabel = new Label();
                    secondCutPitchLabel.ID = "lblSecondCutPitch";
                    secondCutPitchLabel.AssociatedControlID = "chkCutPitch";
                    secondCutPitchLabel.Attributes.Add("runat", "server");
                    accordion.Controls.Add(secondCutPitchLabel);
                    accordion.Controls.Add(new LiteralControl("</li>"));
                    #endregion //cut pitch

                    #region Install Type
                    if (installType != "standAlone")
                    {
                        accordion.Controls.Add(new LiteralControl("<li>"));

                        accordion.Controls.Add(new LiteralControl("<br/>"));
                        Label installLabel = new Label();
                        installLabel.ID = "lblInstall";
                        installLabel.Text = "Install Type";
                        accordion.Controls.Add(installLabel);
                        accordion.Controls.Add(new LiteralControl("<br/>"));

                        RadioButton installHouseRadio = new RadioButton();
                        installHouseRadio.ID = "radInstallHouse";
                        installHouseRadio.Attributes.Add("runat", "server");
                        installHouseRadio.GroupName = "InstallType";
                        installHouseRadio.Text = " ";
                        accordion.Controls.Add(installHouseRadio);

                        Label firstInstallLabel = new Label();
                        firstInstallLabel.ID = "lblFirstInstallLabel";
                        firstInstallLabel.AssociatedControlID = "radInstallHouse";
                        accordion.Controls.Add(firstInstallLabel);

                        Label secondInstallLabel = new Label();
                        secondInstallLabel.ID = "lblSecondInstallLabel";
                        secondInstallLabel.AssociatedControlID = "radInstallHouse";
                        secondInstallLabel.Text = "House";
                        accordion.Controls.Add(secondInstallLabel);

                        accordion.Controls.Add(new LiteralControl("<br/>"));

                        RadioButton installTrailerRadio = new RadioButton();
                        installTrailerRadio.ID = "radInstallTrailer";
                        installTrailerRadio.Attributes.Add("runat", "server");
                        installTrailerRadio.GroupName = "InstallType";
                        installTrailerRadio.Text = " ";
                        accordion.Controls.Add(installTrailerRadio);

                        Label thirdInstallLabel = new Label();
                        thirdInstallLabel.ID = "lblThirdInstallLabel";
                        thirdInstallLabel.AssociatedControlID = "radInstallTrailer";
                        accordion.Controls.Add(thirdInstallLabel);

                        Label fourthInstallLabel = new Label();
                        fourthInstallLabel.ID = "lblFourthInstallLabel";
                        fourthInstallLabel.AssociatedControlID = "radInstallHouse";
                        fourthInstallLabel.Text = "Trailer";
                        accordion.Controls.Add(fourthInstallLabel);
                        accordion.Controls.Add(new LiteralControl("</li>"));

                        accordion.Controls.Add(new LiteralControl("</ul>"));

                        if (installType == "house")
                        {
                            installHouseRadio.Checked = true;
                        }
                        else if (installType == "trailer")
                        {
                            installTrailerRadio.Checked = true;
                        }
                    }
                    #endregion //Install Type

                    #region Framing Colours
                    accordion.Controls.Add(new LiteralControl("<li>"));

                    Label coloursTitleLabel = new Label();
                    coloursTitleLabel.ID = "lblWallColours";
                    coloursTitleLabel.Text = "Framing and Wall Colours";
                    accordion.Controls.Add(coloursTitleLabel);

                    accordion.Controls.Add(new LiteralControl("<br/>"));

                    Label framingColourLabel = new Label();
                    framingColourLabel.ID = "lblFramingColour";
                    framingColourLabel.Text = "Framing Colour: ";
                    accordion.Controls.Add(framingColourLabel);

                    DropDownList framingColoursDropDown = new DropDownList();
                    framingColoursDropDown.ID = "ddlFramingColours";
                    framingColoursDropDown.Attributes.Add("runat", "server");

                    if (modelType == "M100")
                    {
                        for (int i = 0; i < model100FramingColours.Length; i++)
                        {
                            framingColoursDropDown.Items.Add(model100FramingColours[i].ToString());
                        }
                    }
                    else if (modelType == "M200")
                    {
                        for (int i = 0; i < model200FramingColours.Length; i++)
                        {
                            framingColoursDropDown.Items.Add(model200FramingColours[i].ToString());
                        }
                    }
                    else if (modelType == "M300")
                    {
                        for (int i = 0; i < model300FramingColours.Length; i++)
                        {
                            framingColoursDropDown.Items.Add(model300FramingColours[i].ToString());
                        }
                    }
                    else
                    {
                        for (int i = 0; i < model400FramingColours.Length; i++)
                        {
                            framingColoursDropDown.Items.Add(model400FramingColours[i].ToString());
                        }
                    }

                    framingColoursDropDown.SelectedValue = framingColour;

                    accordion.Controls.Add(framingColoursDropDown);

                    accordion.Controls.Add(new LiteralControl("</li>"));
                    #endregion

                    #region Wall Colours
                    accordion.Controls.Add(new LiteralControl("<li>"));

                    Label wallColoursInteriorLabel = new Label();
                    wallColoursInteriorLabel.ID = "lblWallColoursInterior";
                    wallColoursInteriorLabel.Text = "Interior Colour: ";
                    accordion.Controls.Add(wallColoursInteriorLabel);

                    DropDownList wallColoursInteriorDropDown = new DropDownList();
                    wallColoursInteriorDropDown.ID = "ddlWallColoursInterior";
                    wallColoursInteriorDropDown.Attributes.Add("runat", "server");

                    for (int i = 0; i < interiorWallColours.Length; i++)
                    {
                        wallColoursInteriorDropDown.Items.Add(interiorWallColours[i].ToString());
                    }

                    wallColoursInteriorDropDown.SelectedValue = interiorColour;

                    accordion.Controls.Add(wallColoursInteriorDropDown);

                    accordion.Controls.Add(new LiteralControl("<br/>"));

                    Label wallColoursExteriorLabel = new Label();
                    wallColoursExteriorLabel.ID = "lblWallColoursExterior";
                    wallColoursExteriorLabel.Text = "Exterior Colour: ";
                    accordion.Controls.Add(wallColoursExteriorLabel);

                    DropDownList wallColoursExteriorDropDown = new DropDownList();
                    wallColoursExteriorDropDown.ID = "ddlWallColoursExterior";
                    wallColoursExteriorDropDown.Attributes.Add("runat", "server");

                    for (int i = 0; i < exteriorWallColours.Length; i++)
                    {
                        wallColoursExteriorDropDown.Items.Add(exteriorWallColours[i].ToString());
                    }

                    wallColoursExteriorDropDown.SelectedValue = exteriorColour;

                    accordion.Controls.Add(wallColoursExteriorDropDown);

                    accordion.Controls.Add(new LiteralControl("</li>"));
                    #endregion

                    #region Wall Textures
                    accordion.Controls.Add(new LiteralControl("<li>"));

                    Label wallTextureTitleLabel = new Label();
                    wallTextureTitleLabel.ID = "lblWallTexture";
                    wallTextureTitleLabel.Text = "Skin Types";
                    accordion.Controls.Add(wallTextureTitleLabel);

                    accordion.Controls.Add(new LiteralControl("<br/>"));

                    Label wallTextureInteriorLabel = new Label();
                    wallTextureInteriorLabel.ID = "lblWallTextureInterior";
                    wallTextureInteriorLabel.Text = "Interior: ";
                    accordion.Controls.Add(wallTextureInteriorLabel);

                    DropDownList wallTextureInteriorDropDown = new DropDownList();
                    wallTextureInteriorDropDown.ID = "ddlWallTextureInterior";
                    wallTextureInteriorDropDown.Attributes.Add("runat", "server");

                    for (int i = 0; i < interiorWallSkinTypes.Length; i++)
                    {
                        wallTextureInteriorDropDown.Items.Add(interiorWallSkinTypes[i].ToString());
                    }

                    wallTextureInteriorDropDown.SelectedValue = interiorSkin;

                    accordion.Controls.Add(wallTextureInteriorDropDown);

                    accordion.Controls.Add(new LiteralControl("<br/>"));

                    Label wallTextureExteriorLabel = new Label();
                    wallTextureExteriorLabel.ID = "lblWallTextureExterior";
                    wallTextureExteriorLabel.Text = "Exterior: ";
                    accordion.Controls.Add(wallTextureExteriorLabel);

                    DropDownList wallTextureExteriorDropDown = new DropDownList();
                    wallTextureExteriorDropDown.ID = "ddlWallTextureExterior";
                    wallTextureExteriorDropDown.Attributes.Add("runat", "server");

                    for (int i = 0; i < exteriorWallSkinTypes.Length; i++)
                    {
                        wallTextureExteriorDropDown.Items.Add(exteriorWallSkinTypes[i].ToString());
                    }

                    wallTextureExteriorDropDown.SelectedValue = exteriorSkin;

                    accordion.Controls.Add(wallTextureExteriorDropDown);

                    accordion.Controls.Add(new LiteralControl("</li>"));
                    #endregion

                #endregion //Project Wide

                #region Wall Height Entry
                accordion.Controls.Add(new LiteralControl("<h2>Wall Heights</h2>"));
                accordion.Controls.Add(new LiteralControl("<ul>"));

                    #region BackWall Height
                    accordion.Controls.Add(new LiteralControl("<li>"));
                    Label backwallHeight = new Label();
                    backwallHeight.ID = "lblBackwall";
                    backwallHeight.Text = "Back Wall Height: ";
                    accordion.Controls.Add(backwallHeight);

                    TextBox backwallTextBox = new TextBox();
                    backwallTextBox.ID = "txtBackwall";
                    backwallTextBox.Text = backwall.ToString();
                    backwallTextBox.CssClass = "txtField txtInput";
                    backwallTextBox.Attributes.Add("onkeydown", "return (event.keyCode!=13);");
                    backwallTextBox.Attributes.Add("runat", "server");
                    accordion.Controls.Add(backwallTextBox);

                    DropDownList backwallFractions = new DropDownList();
                    backwallFractions.ID = "ddlBackwallFractions";

                    for (int i = 0; i < fractionList.Count; i++)
                    {
                        backwallFractions.Items.Add(fractionList[i]);
                    }

                    backwallFractions.Attributes.Add("runat", "server");
                    accordion.Controls.Add(backwallFractions);
                    accordion.Controls.Add(new LiteralControl("</li>"));
                    #endregion //backwall height

                    #region FrontWall Height
                    accordion.Controls.Add(new LiteralControl("<li>"));
                    Label frontwallHeight = new Label();
                    frontwallHeight.ID = "lblFrontwall";
                    frontwallHeight.Text = "Front Wall Height: ";
                    accordion.Controls.Add(frontwallHeight);

                    TextBox frontwallTextBox = new TextBox();
                    frontwallTextBox.ID = "txtFrontwall";
                    frontwallTextBox.Text = frontwall.ToString();
                    frontwallTextBox.CssClass = "txtField txtInput";
                    frontwallTextBox.Attributes.Add("onkeydown", "return (event.keyCode!=13);");
                    frontwallTextBox.Attributes.Add("runat", "server");
                    accordion.Controls.Add(frontwallTextBox);

                    DropDownList frontwallFractions = new DropDownList();
                    frontwallFractions.ID = "ddlFrontwallFractions";

                    for (int i = 0; i < fractionList.Count; i++)
                    {
                        frontwallFractions.Items.Add(fractionList[i]);
                    }

                    frontwallFractions.Attributes.Add("runat", "server");
                    accordion.Controls.Add(frontwallFractions);
                    accordion.Controls.Add(new LiteralControl("</li>"));
                    #endregion //frontwall height

                    #region Slope
                    accordion.Controls.Add(new LiteralControl("<li>"));
                    Label slopeLabel = new Label();
                    slopeLabel.ID = "lblSlope";
                    slopeLabel.Text = "Slope: ";
                    accordion.Controls.Add(slopeLabel);

                    TextBox slopeTextBox = new TextBox();
                    slopeTextBox.ID = "txtSlope";
                    slopeTextBox.Text = slope.ToString();
                    slopeTextBox.CssClass = "txtField txtInput";
                    slopeTextBox.Attributes.Add("onkeydown", "return (event.keyCode!=13);");
                    slopeTextBox.Attributes.Add("runat", "server");
                    accordion.Controls.Add(slopeTextBox);

                    Label overTwelve = new Label();
                    overTwelve.ID = "lblOverTwelve";
                    overTwelve.Text = " / 12";
                    accordion.Controls.Add(overTwelve);
                    accordion.Controls.Add(new LiteralControl("</li>"));
                    #endregion //slope

                accordion.Controls.Add(new LiteralControl("</ul>"));
                #endregion //wall height entry

                #region Wall Width Entry
                accordion.Controls.Add(new LiteralControl("<ul class=\"toggleOptions\">"));
                accordion.Controls.Add(new LiteralControl("<h2>Wall Widths</h2>"));

                for (int i = 0; i < listOfWalls.Count; i++)
                {
                    //accordion.Controls.Add(new LiteralControl("<li onclick=alert("+(i+1)+");>"));
                    accordion.Controls.Add(new LiteralControl("<li onclick=drawWall(document.getElementById('MainContent_txtWidth" + (i + 1) + "').value,document.getElementById('MainContent_lblStartHeightDisplay" + (i + 1) + "').innerHTML,document.getElementById('MainContent_lblEndHeightDisplay" + (i + 1) + "').innerHTML," + (i + 1) + ");>"));
                    Label accordionLabel = new Label();
                    accordionLabel.ID = "lblWall" + (i + 1) + "Label";
                    accordionLabel.Text = listOfWalls[i].Name;
                    accordion.Controls.Add(accordionLabel);

                    accordion.Controls.Add(new LiteralControl("<div class=\"toggleContent\"><ul>"));

                        #region Wall Length
                        accordion.Controls.Add(new LiteralControl("<li>"));
                        Label width = new Label();
                        width.ID = "lblWidth" + (i + 1);
                        width.Text = "Width: ";
                        accordion.Controls.Add(width);

                        TextBox widthTextBox = new TextBox();
                        widthTextBox.ID = "txtWidth" + (i + 1);
                        widthTextBox.Text = listOfWalls[i].Length.ToString();
                        widthTextBox.CssClass = "txtField txtInput";
                        widthTextBox.Attributes.Add("onkeydown", "return (event.keyCode!=13);");
                        widthTextBox.Attributes.Add("runat", "server");
                        accordion.Controls.Add(widthTextBox);

                        DropDownList widthFractions = new DropDownList();
                        widthFractions.ID = "ddlWall" + (i + 1) + "Fractions";

                        for (int j = 0; j < fractionList.Count; j++)
                        {
                            widthFractions.Items.Add(fractionList[j]);
                        }

                        widthFractions.Attributes.Add("runat", "server");
                        accordion.Controls.Add(widthFractions);

                        accordion.Controls.Add(new LiteralControl("</li>"));
                        #endregion //wall length

                        #region Wall StartHeight
                        accordion.Controls.Add(new LiteralControl("<li>"));
                        Label startHeight = new Label();
                        startHeight.ID = "lblStartHeight" + (i + 1);
                        startHeight.Text = "Start Height: ";
                        accordion.Controls.Add(startHeight);

                        Label startHeightDisplay = new Label();
                        startHeightDisplay.ID = "lblStartHeightDisplay" + (i + 1);
                        startHeightDisplay.Text = listOfWalls[i].StartHeight.ToString();
                        startHeightDisplay.Attributes.Add("runat", "server");
                        accordion.Controls.Add(startHeightDisplay);

                        accordion.Controls.Add(new LiteralControl("</li>"));
                        #endregion //wall start height

                        #region Wall EndHeight
                        accordion.Controls.Add(new LiteralControl("<li>"));
                        Label endHeight = new Label();
                        endHeight.ID = "lblEndHeight" + (i + 1);
                        endHeight.Text = "End Height: ";
                        accordion.Controls.Add(endHeight);

                        Label endHeightDisplay = new Label();
                        endHeightDisplay.ID = "lblEndHeightDisplay" + (i + 1);
                        endHeightDisplay.Text = listOfWalls[i].EndHeight.ToString();
                        endHeightDisplay.Attributes.Add("runat", "server");
                        accordion.Controls.Add(endHeightDisplay);

                        accordion.Controls.Add(new LiteralControl("</li>"));
                        #endregion //wall endheight

                    accordion.Controls.Add(new LiteralControl("</ul></div></li>"));
                }

                accordion.Controls.Add(new LiteralControl("</ul>"));
                #endregion //wall width entry

            #endregion //dynamic accordion population
        }
    }
}
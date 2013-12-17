﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SunspaceDealerDesktop
{
    public partial class ProjectPreview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Wall> listOfWalls = (List<Wall>)Session["listOfWalls"];
            Table aTable = new Table();
            TableRow aTableRow = new TableRow();
            TableCell aTableCell = new TableCell();

            phProject.Controls.Add(new LiteralControl("<ul class=\"toggleOptions\">"));
            phProject.Controls.Add(new LiteralControl("<li>"));
            phProject.Controls.Add(new LiteralControl("<div class=\"toggleContent\">"));
            phProject.Controls.Add(new LiteralControl("<ul>"));
            phProject.Controls.Add(new LiteralControl("<li>"));
            phProject.Controls.Add(new LiteralControl("<h3>Project Details:</h3>"));
            //phProject.Controls.Add(aTableCell);
            //phProject.Controls.Add(aTableRow);
            phProject.Controls.Add(aTable);
            //<ul class="toggleOptions">
            //        <li>
            //            <div class="toggleContent">
            //                <ul>
            //                    <li>
            //                        <h3>Enter customer details:</h3>
            //                        <asp:Table ID="tblNewCustomerInfo" CssClass="tblTxtFields" runat="server">
            //                            <asp:TableRow>
            //                                <asp:TableCell>
            //                                    <asp:Label ID

              #region older
//            //maybe a large textarea
//            //project details
//            LiteralControl projectTitle = new LiteralControl();
//            projectTitle.Text = "<h1>Project Details:</h1>";
//            phProjectTitle.Controls.Add(projectTitle);

//            phProject.Controls.Add(new LiteralControl("<br/>"));

//            Label projectType = new Label();
//            projectType.Text = "Type: " + Session["newProjectProjectType"].ToString();
//            phProject.Controls.Add(projectType);

//            phProject.Controls.Add(new LiteralControl("<br/>"));

//            Label projectName = new Label();
//            projectName.Text = "Name: " + Session["newProjectProjectNAme"].ToString();
//            phProject.Controls.Add(projectName);

//            phProject.Controls.Add(new LiteralControl("<br/>"));

//            Label projectModel = new Label();
//            projectModel.Text = listOfWalls[0].ModelType;
//            phProject.Controls.Add(projectModel);

//            phProject.Controls.Add(new LiteralControl("<br/>"));

//            //wall details
//            LiteralControl wallTitle = new LiteralControl();
//            wallTitle.Text = "<h1>Wall Details:</h1>";
//            phWalls.Controls.Add(wallTitle);

//            phWalls.Controls.Add(new LiteralControl("<br/>"));

//            Label wallCount = new Label();
//            wallCount.Text = "# of walls: " + listOfWalls.Count.ToString();
//            phWalls.Controls.Add(wallCount);

//            phWalls.Controls.Add(new LiteralControl("<br/>"));

//            Table aTable = new Table();

//            for (int i = 0; i < listOfWalls.Count; i++)
//            {
//                TableRow aTableRow = new TableRow();
//                TableCell aTableCell = new TableCell();

//                LiteralControl wallHeader = new LiteralControl();
//                wallTitle.Text = "<h1>Wall " + (i+1) + ":</h1>";
//                aTableCell.Controls.Add(wallTitle);

//                aTableCell.Controls.Add(new LiteralControl("<br/>"));

//                Label wallType = new Label();
//                wallType.Text = "type: " + listOfWalls[i].WallType;
//                aTableCell.Controls.Add(wallType);

//                aTableCell.Controls.Add(new LiteralControl("<br/>"));

//                Label wallLength = new Label();
//                wallLength.Text = "length: " + listOfWalls[i].Length;
//                aTableCell.Controls.Add(wallLength);

//                aTableCell.Controls.Add(new LiteralControl("<br/>"));

//                Label wallOrientation = new Label();
//                wallOrientation.Text = "orientation: " + listOfWalls[i].Orientation;
//                aTableCell.Controls.Add(wallOrientation);

//                aTableCell.Controls.Add(new LiteralControl("<br/>"));

//                Label wallSoffit = new Label();
//                wallSoffit.Text = "soffit: " + listOfWalls[i].SoffitLength;
//                aTableCell.Controls.Add(wallSoffit);

//                aTableCell.Controls.Add(new LiteralControl("<br/>"));

//                LiteralControl wallLinearHeader = new LiteralControl();
//                wallLinearHeader.Text = "<h1>Wall " + (i + 1) + " items:</h1>";
//                aTableCell.Controls.Add(wallLinearHeader);

//                aTableCell.Controls.Add(new LiteralControl("<br/>"));

//                for (int j = 0; j < listOfWalls[i].LinearItems.Count; j++)
//                {
//                    Label wallItemType = new Label();
//                    wallItemType.Text = "type: " + listOfWalls[i].LinearItems[j].ItemType;
//                    phWalls.Controls.Add(wallItemType);

//                    phWalls.Controls.Add(new LiteralControl("<br/>"));

//                    Label wallItemLength = new Label();
//                    wallItemLength.Text = "length: " + listOfWalls[i].LinearItems[j].Length;
//                    phWalls.Controls.Add(wallItemLength);

//                    phWalls.Controls.Add(new LiteralControl("<br/>"));

//                    Label wallItemStartHeight = new Label();
//                    wallItemStartHeight.Text = "start height: " + listOfWalls[i].LinearItems[j].StartHeight;
//                    phWalls.Controls.Add(wallItemStartHeight);

//                    phWalls.Controls.Add(new LiteralControl("<br/>"));

//                    Label wallItemEndHeight = new Label();
//                    wallItemEndHeight.Text = "end height: " + listOfWalls[i].LinearItems[j].EndHeight;
//                    phWalls.Controls.Add(wallItemEndHeight);

//                    phWalls.Controls.Add(new LiteralControl("<br/>"));

//                    Label wallItemOrientation = new Label();
//                    wallItemOrientation.Text = "orientation: " + listOfWalls[i].LinearItems[j].FixedLocation;
//                    phWalls.Controls.Add(wallItemOrientation);

//                    phWalls.Controls.Add(new LiteralControl("<br/>"));
//                    phWalls.Controls.Add(new LiteralControl("<br/>"));

//                    // -->--> module item details
//                }
//            }

//            //floor details
//            if (Session["newProjectPrefabFloor"].ToString() == "Yes")
//            {
//                LiteralControl floorTitle = new LiteralControl();
//                floorTitle.Text = "<h1>Floor Details:</h1>";
//                phFloorTitle.Controls.Add(floorTitle);

//                phFloor.Controls.Add(new LiteralControl("<br/>"));

//                Label floorType = new Label();
//                floorType.Text = "Type: " + Session["floorType"].ToString();
//                phFloor.Controls.Add(floorType);

//                phFloor.Controls.Add(new LiteralControl("<br/>"));

//                Label floorProjection = new Label();
//                floorProjection.Text = "Projection: " + Session["floorProjection"].ToString();
//                phFloor.Controls.Add(floorProjection);

//                phFloor.Controls.Add(new LiteralControl("<br/>"));

//                Label floorWidth = new Label();
//                floorWidth.Text = "Width: " + Session["floorWidth"].ToString();
//                phFloor.Controls.Add(floorWidth);

//                phFloor.Controls.Add(new LiteralControl("<br/>"));

//                Label floorThickness = new Label();
//                floorThickness.Text = "Thickness: " + Session["floorThickness"].ToString();
//                phFloor.Controls.Add(floorThickness);

//                phFloor.Controls.Add(new LiteralControl("<br/>"));

//                Label floorVapourBarrier = new Label();
//                floorVapourBarrier.Text = "Vapour Barrier: " + Session["floorVapourBarrier"].ToString();
//                phFloor.Controls.Add(floorVapourBarrier);

//                phFloor.Controls.Add(new LiteralControl("<br/>"));

//                Label floorPanelNumber = new Label();
//                floorPanelNumber.Text = "# of panels: " + Session["floorPanelNumber"].ToString();
//                phFloor.Controls.Add(floorPanelNumber);

//                phFloor.Controls.Add(new LiteralControl("<br/>"));

//                Label floorLedgerSetback = new Label();
//                floorLedgerSetback.Text = "Ledger Setback: " + Session["floorLedgerSetback"].ToString();
//                phFloor.Controls.Add(floorLedgerSetback);

//                phFloor.Controls.Add(new LiteralControl("<br/>"));

//                Label floorFrontSetback = new Label();
//                floorFrontSetback.Text = "Front Setback: " + Session["floorFrontSetback"].ToString();
//                phFloor.Controls.Add(floorFrontSetback);

//                phFloor.Controls.Add(new LiteralControl("<br/>"));

//                Label floorSidesSetback = new Label();
//                floorSidesSetback.Text = "Sides Setback: " + Session["floorSidesSetback"].ToString();
//                phFloor.Controls.Add(floorSidesSetback);

//                phFloor.Controls.Add(new LiteralControl("<br/>"));

//                Label floorJointSetback = new Label();
//                floorJointSetback.Text = "Joint Setback: " + Session["floorJointSetback"].ToString();
//                phFloor.Controls.Add(floorJointSetback);

//                phFloor.Controls.Add(new LiteralControl("<br/>"));
//            }

//            //roof details
//            if (Session["newProjectHasRoof"].ToString() == "Yes")
//            {
//                Roof aRoof = (Roof) Session["completedRoof"];

//                LiteralControl roofTitle = new LiteralControl();
//                roofTitle.Text = "<h1>Roof Details:</h1>";
//                phRoofTitle.Controls.Add(roofTitle);

//                phRoof.Controls.Add(new LiteralControl("<br/>"));

//                Label roofType = new Label();
//                roofType.Text = "Type: " + aRoof.Type;
//                phRoof.Controls.Add(roofType);

//                phRoof.Controls.Add(new LiteralControl("<br/>"));

//                Label roofProjection = new Label();
//                roofProjection.Text = "Projection: " + aRoof.Projection;
//                phRoof.Controls.Add(roofProjection);

//                phRoof.Controls.Add(new LiteralControl("<br/>"));

//                Label roofWidth = new Label();
//                roofWidth.Text = "Width: " + aRoof.Width;
//                phRoof.Controls.Add(roofWidth);

//                phRoof.Controls.Add(new LiteralControl("<br/>"));

//                Label roofThickness = new Label();
//                roofThickness.Text = "Thickness: " + aRoof.Thickness;
//                phRoof.Controls.Add(roofThickness);

//                phRoof.Controls.Add(new LiteralControl("<br/>"));

//                Label roofGutters = new Label();
//                roofGutters.Text = "Gutters: " + aRoof.Gutters;
//                phRoof.Controls.Add(roofGutters);

//                phRoof.Controls.Add(new LiteralControl("<br/>"));

//                if (aRoof.Gutters == true)
//                {
//                    Label roofGuttersPro = new Label();
//                    roofGuttersPro.Text = "Gutter Pro: " + aRoof.GutterPro;
//                    phRoof.Controls.Add(roofGuttersPro);

//                    phRoof.Controls.Add(new LiteralControl("<br/>"));

//                    Label roofGutterColour = new Label();
//                    roofGutterColour.Text = "Gutter Colour: " + aRoof.GutterColour;
//                    phRoof.Controls.Add(roofGutterColour);

//                    phRoof.Controls.Add(new LiteralControl("<br/>"));
//                }
//            }
#endregion
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            List<Wall> listOfWalls = (List<Wall>)Session["listOfWalls"];
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
                    //Project
                    #region Project
                    aCommand.CommandText = "INSERT INTO projects(project_type, installation_type, project_name, customer_id, user_id, date_created, status, revised_date, revised_user_id, msrp, project_notes, "
                                            + "hidden, cut_pitch) VALUES ("
                                            + "'Sunroom', " //Will always be a sunroom to be at this point in wizard
                                            + "'House', "
                                            + "'" + Session["newProjectProjectName"] + "', "
                                            + "1, "
                                            + Session["user_id"] + ", "
                                            + "'" + DateTime.Now.ToString("yyyy/MM/dd") + "', "
                                            + "'" + "Active" + "', "
                                            + "'" + DateTime.Now.ToString("yyyy/MM/dd") + "', "
                                            + Session["user_id"] + ", "
                                            + 0 + ", "
                                            + 0 + ", "
                                            + 0 + ", "
                                            + 1
                                            + ");";
                    aCommand.ExecuteNonQuery(); //Execute a command that does not return anything
                    #endregion

                    //Get project_id for use in below statements
                    aCommand.CommandText = "SELECT project_id FROM projects WHERE project_name = '" + Session["newProjectProjectName"] + "'";
                    aReader = aCommand.ExecuteReader();
                    aReader.Read();

                    int project_id = Convert.ToInt32(aReader[0]);
                    aReader.Close();

                    #region Walls
                    for (int i = 0; i < listOfWalls.Count; i++)
                    {
                        //GET A PROJECT_ID
                        //setback for wall
                        //fire protection for wall
                        aCommand.CommandText = "INSERT INTO walls(project_id, wall_index, wall_type, model_type, total_length, orientation, set_back, name, first_item_index, "
                                                + "last_item_index, start_height, end_height, soffit_length, gable_peak, obstructions, fire_protection) VALUES("
                                                + project_id + ", "
                                                + i + ", '"
                                                + listOfWalls[i].WallType + "', '"
                                                + listOfWalls[i].ModelType + "', "
                                                + listOfWalls[i].Length + ", '"
                                                + listOfWalls[i].Orientation + "', "
                                                + 0 + ", '"
                                                + listOfWalls[i].Name + "', "
                                                + listOfWalls[i].FirstItemIndex + ", "
                                                + listOfWalls[i].LastItemIndex + ", "
                                                + listOfWalls[i].StartHeight + ", "
                                                + listOfWalls[i].EndHeight + ", "
                                                + listOfWalls[i].SoffitLength + ", "
                                                + listOfWalls[i].GablePeak + ", "
                                                + 0 + ", " //CHANGEME obstructions unhandled at this point
                                                + 0 
                                                + ");";
                        aCommand.ExecuteNonQuery(); //Execute a command that does not return anything
                    }
                    #endregion

                    #region Linear Items
                    int linearCounter = 0;
                    for (int i = 0; i < listOfWalls.Count; i++)
                    {
                        for (int j = 0; j < listOfWalls[i].LinearItems.Count; j++)
                        {
                            //frame_colour
                            //sex
                            //attached_to logic, Lboxhead to door, door to Rboxhead
                            aCommand.CommandText = "INSERT INTO linear_items(project_id, linear_index, linear_type, start_height, end_height, length, frame_colour, sex, fixed_location, attached_to) VALUES("
                                                    + project_id + ", "
                                                    + linearCounter + ", '"
                                                    + listOfWalls[i].LinearItems[j].ItemType + "', "
                                                    + listOfWalls[i].LinearItems[j].StartHeight + ", "
                                                    + listOfWalls[i].LinearItems[j].EndHeight + ", "
                                                    + listOfWalls[i].LinearItems[j].Length + ", '"
                                                    + Session["newProjectFramingColour"] + "', '"
                                                    + "MF" + "', "
                                                    + listOfWalls[i].LinearItems[j].FixedLocation + ", "
                                                    + 1 //Will start all as locked to avoid accidental changes in project editor before project submission
                                                    + ");";
                            aCommand.ExecuteNonQuery();
                            linearCounter++;
                        }
                    }
                    #endregion

                    #region Modular Items and Base Level Items
                    linearCounter = 0;

                    for (int i = 0; i < listOfWalls.Count; i++)
                    {
                        for (int j = 0; j < listOfWalls[i].LinearItems.Count; j++)
                        {
                            if (listOfWalls[i].LinearItems[j].ItemType == "Mod")
                            {                                
                                //Get the mod, then loop for all its items
                                Mod aMod = (Mod)listOfWalls[i].LinearItems[j];
                                int sunshadeBit;
                                if (aMod.Sunshade == true)
                                {
                                    sunshadeBit = 1;
                                }
                                else
                                {
                                    sunshadeBit = 0;
                                }
                                //We make a module entry for this module 
                                aCommand.CommandText = "INSERT INTO modules(project_id, linear_index, number_items, sunshade) VALUES("
                                                        + project_id + ", "
                                                        + linearCounter + ", "
                                                        + aMod.ModularItems.Count + ", "
                                                        + sunshadeBit
                                                        + ");";
                                aCommand.ExecuteNonQuery();
                                
                                //If sunshades are true, we make an entry there too
                                if (aMod.Sunshade == true)
                                {
                                    //We make a sunshade entry for this module 
                                    aCommand.CommandText = "INSERT INTO sunshade_items(project_id, linear_index, height, length, valance_colour, fabric_colour, openness, chain) VALUES("
                                                            + project_id + ", "
                                                            + linearCounter + ", "
                                                            //The height of the sunshade is equal to the highest of the two heights, minus the highest of the two heights of the transom. This places the sunshade below the transom at the top of the window
                                                            + (Math.Max(aMod.StartHeight, aMod.EndHeight) - Math.Max(aMod.ModularItems[aMod.ModularItems.Count-1].FStartHeight,aMod.ModularItems[aMod.ModularItems.Count-1].FEndHeight)) + ", "
                                                            + aMod.Length + ", '"
                                                            + aMod.SunshadeValance + "', '"
                                                            + aMod.SunshadeFabric + "', '"
                                                            + aMod.SunshadeOpenness + "', '"
                                                            + aMod.SunshadeChain
                                                            + "');";
                                    aCommand.ExecuteNonQuery();
                                }

                                for (int k = 0; k < aMod.ModularItems.Count; k++)
                                {
                                    //We make a module_items entry for this module item
                                    aCommand.CommandText = "INSERT INTO module_items(project_id, linear_index, module_index, item_type, start_height, end_height, length) VALUES("
                                                            + project_id + ", "
                                                            + linearCounter + ", "
                                                            + k + ", '"
                                                            + aMod.ModularItems[k].ItemType + "', "
                                                            + aMod.ModularItems[k].FStartHeight + ", "
                                                            + aMod.ModularItems[k].FEndHeight + ", "
                                                            + aMod.ModularItems[k].FLength
                                                            + ");";
                                    aCommand.ExecuteNonQuery();

                                    //We'll have to make different entries based on the type, so we have a switch
                                    switch (aMod.ModularItems[k].ItemType)
                                    {
                                        case "Kneewall":
                                            //First make the 'window' entry, as a kneewall is just a special window located at the bottom of a mod
                                            Kneewall aKneewall = (Kneewall)aMod.ModularItems[k];
                                            aCommand.CommandText = "INSERT INTO windows(project_id, linear_index, module_index, door_index, window_type, screen_type, start_height, end_height, length, window_colour, number_vents) VALUES("
                                                                    + project_id + ", "
                                                                    + linearCounter + ", "
                                                                    + k + ", "
                                                                    + 0 + ", '" //0 because this is a window from a module, not within a door
                                                                    + aKneewall.KneewallType + "', '"
                                                                    + "No Screen" + "', " //Kneewalls don't have a screen
                                                                    + aKneewall.FStartHeight + ", "
                                                                    + aKneewall.FEndHeight + ", "
                                                                    + aKneewall.FLength + ", '"
                                                                    + Session["newProjectFramingColour"].ToString() + "', " //Kneewalls use the overall sunroom framing colour
                                                                    + 0
                                                                    + ");";
                                            aCommand.ExecuteNonQuery();

                                            //Now that the window entry is complete, we need to go 'deeper' and enter the physical piece of panel or glass that is going to be used
                                            switch (aKneewall.KneewallType)
                                            {
                                                case "Solid Wall":
                                                    aCommand.CommandText = "INSERT INTO panels(project_id, linear_index, module_index, door_index, interior_skin, exterior_skin, start_height, end_height, length) VALUES("
                                                                            + project_id + ", "
                                                                            + linearCounter + ", "
                                                                            + k + ", "
                                                                            + -1 + ", '" //This is a kneewall, which is not a valid door_index, so we put -1
                                                                            + Session["newProjectInteriorSkin"].ToString() + "', '"
                                                                            + Session["newProjectExteriorSkin"].ToString() + "', "
                                                                            + aKneewall.FStartHeight + ", " //Since a solid wall panel doesn't have framing, we use the 'framing size' to include the whole thing
                                                                            + aKneewall.FEndHeight + ", "
                                                                            + aKneewall.FLength
                                                                            + ");";
                                                    aCommand.ExecuteNonQuery();
                                                    break;
                                                case "Glass":
                                                    aCommand.CommandText = "INSERT INTO glass_items(project_id, linear_index, module_index, vent_index, door_index, glass_type, start_height, end_height, length, glass_tint, tempered, operation) VALUES()"
                                                                            + project_id + ", "
                                                                            + linearCounter + ", "
                                                                            + k + ", "
                                                                            + -1 + ", " //This is not a vent, just solid glass
                                                                            + 0 + ", " //This is a window
                                                                            + "Single Glaze" + "', "
                                                                            + aKneewall.StartHeight + ", "
                                                                            + aKneewall.EndHeight + ", "
                                                                            + aKneewall.Length + ", '"
                                                                            + Session["newProjectKneewallTint"].ToString() + "', "
                                                                            + 1 + ", " //Glass kneewalls must always be tempered glass
                                                                            + 0
                                                                            + ");";
                                                    aCommand.ExecuteNonQuery();
                                                    break;
                                            }
                                            break;

                                        case "Window":
                                            //If it's a window
                                            Window aWindow = (Window)aMod.ModularItems[k];
                                            aCommand.CommandText = "INSERT INTO windows(project_id, linear_index, module_index, door_index, window_type, screen_type, start_height, end_height, length, window_colour, number_vents) VALUES("
                                                                    + project_id + ", "
                                                                    + linearCounter + ", "
                                                                    + k + ", "
                                                                    + 0 + ", '" //0 because this is a window from a module, not within a door
                                                                    + aWindow.WindowStyle + "', '"
                                                                    + aWindow.ScreenType + "', "
                                                                    + aWindow.FStartHeight + ", "
                                                                    + aWindow.FEndHeight + ", "
                                                                    + aWindow.FLength + ", '"
                                                                    + aWindow.FrameColour + "', "
                                                                    + aWindow.NumVents
                                                                    + ");";
                                            aCommand.ExecuteNonQuery();

                                            //Then make the specific base item entry based on type of window
                                            switch (aWindow.WindowStyle)
                                            {
                                                //Note, Vinyl and Glass are only accessible at this point as a transom
                                                //So we assume they're window entries
                                                case "Vinyl":
                                                    aCommand.CommandText = "INSERT INTO vinyl_items(project_id, linear_index, module_index, vent_index, door_index, start_height, end_height, length, vinyl_tint, spreader_bar) VALUES("
                                                                            + project_id + ", "
                                                                            + linearCounter + ", "
                                                                            + k + ", "
                                                                            + -1 + ", " //This is not in a vent, this is just solid vinyl
                                                                            + 0 + ", " //This is a window, so it is 0
                                                                            + aWindow.LeftHeight + ", "
                                                                            + aWindow.RightHeight + ", "
                                                                            + aWindow.Width + ", '"
                                                                            + aWindow.Colour + "', "
                                                                            + aWindow.SpreaderBar
                                                                            + ");";
                                                    aCommand.ExecuteNonQuery();
                                                    break;

                                                case "Glass":
                                                    aCommand.CommandText = "INSERT INTO glass_items(project_id, linear_index, module_index, vent_index, door_index, glass_type, start_height, end_height, length, glass_tint, tempered, operation) VALUES()"
                                                                            + project_id + ", "
                                                                            + linearCounter + ", "
                                                                            + k + ", "
                                                                            + -1 + ", " //This is not a vent, just solid glass
                                                                            + 0 + ", " //This is a window
                                                                            + "Single Glaze" + "', "
                                                                            + aWindow.LeftHeight + ", "
                                                                            + aWindow.RightHeight + ", "
                                                                            + aWindow.Width + ", '"
                                                                            + aWindow.Colour + "', "
                                                                            + 0 + ", "
                                                                            + 0
                                                                            + ");";
                                                    aCommand.ExecuteNonQuery();
                                                    break;

                                                case "Vertical 4 Track":
                                                    for (int vents = 0; vents < aWindow.NumVents; vents++)
                                                    {
                                                        string myColour = aWindow.Colour.Substring(vents, 1);
                                                        aCommand.CommandText = "INSERT INTO vinyl_items(project_id, linear_index, module_index, vent_index, door_index, start_height, end_height, length, vinyl_tint, spreader_bar) VALUES("
                                                                                + project_id + ", "
                                                                                + linearCounter + ", "
                                                                                + k + ", "
                                                                                + vents + ", " //This is not in a vent, this is just solid vinyl
                                                                                + 0 + ", " //This is a window, so it is 0
                                                                                + aWindow.LeftHeight + ", "
                                                                                + aWindow.RightHeight + ", "
                                                                                + aWindow.Width + ", '"
                                                                                + myColour + "', "
                                                                                + aWindow.SpreaderBar
                                                                                + ");";
                                                        aCommand.ExecuteNonQuery();
                                                    }
                                                    break;

                                                case "Horizontal 2 Track":
                                                case "Horizontal Roller":
                                                    for (int numVents = 0; numVents < aWindow.NumVents; numVents++)
                                                    {
                                                        aCommand.CommandText = "INSERT INTO vinyl_items(project_id, linear_index, module_index, vent_index, door_index, start_height, end_height, length, vinyl_tint, spreader_bar) VALUES("
                                                                                + project_id + ", "
                                                                                + linearCounter + ", "
                                                                                + k + ", "
                                                                                + numVents + ", " //This is not in a vent, this is just solid vinyl
                                                                                + 0 + ", " //This is a window, so it is 0
                                                                                + aWindow.LeftHeight + ", "
                                                                                + aWindow.RightHeight + ", "
                                                                                + aWindow.Width + ", '"
                                                                                + aWindow.Colour + "', "
                                                                                + aWindow.SpreaderBar
                                                                                + ");";
                                                        aCommand.ExecuteNonQuery();
                                                    }
                                                    break;

                                                //case "Single Slider":
                                                //    break;

                                                //case "Double Slider":
                                                //    break;

                                                case "Screen":
                                                    aCommand.CommandText = "INSERT INTO screen_items(project_id, linear_index, module_index, door_index, screen_type, start_height, end_height, length, mount) VALUES("
                                                                            + project_id + ", "
                                                                            + linearCounter + ", "
                                                                            + k + ", "
                                                                            + 0 + ", '" //This is a window, so 0
                                                                            + aWindow.ScreenType + "', "
                                                                            + aWindow.LeftHeight + ", "
                                                                            + aWindow.RightHeight + ", "
                                                                            + aWindow.Width + ", '"
                                                                            + "In" + "'" //A screen window is inside mount, whereas a screen on a window of another type is outside mounted (handled below)
                                                                            + ");";
                                                    aCommand.ExecuteNonQuery();
                                                    break;
                                            }

                                            //Then if required, a screen table entry
                                            if (aWindow.ScreenType != "No Screen" && aWindow.ScreenType.Length > 1 && aWindow.WindowStyle != "Screen")
                                            {
                                                aCommand.CommandText = "INSERT INTO screen_items(project_id, linear_index, module_index, door_index, screen_type, start_height, end_height, length, mount) VALUES("
                                                                        + project_id + ", "
                                                                        + linearCounter + ", "
                                                                        + k + ", "
                                                                        + 0 + ", '" //This is a window, so 0
                                                                        + aWindow.ScreenType + "', "
                                                                        + aWindow.LeftHeight + ", "
                                                                        + aWindow.RightHeight + ", "
                                                                        + aWindow.Width + ", '"
                                                                        + "Out" + "'" //This screen is a screen in addition to a window, so it will be an outside mounted screen on an inside mounted window
                                                                        + ");";
                                                aCommand.ExecuteNonQuery();
                                            }
                                            break;

                                        case "Door":
                                            Door aDoor = (Door)aMod.ModularItems[k];

                                            aCommand.CommandText = "INSERT INTO doors(project_id, linear_index, module_index, door_type, door_style, screen_type, height, length, door_colour, kick_plate) VALUES("
                                                                    + project_id + ", "
                                                                    + linearCounter + ", "
                                                                    + k + ", '"
                                                                    + aDoor.DoorType + "', '"
                                                                    + aDoor.DoorStyle + "', '"
                                                                    + aDoor.ScreenType + "', "
                                                                    + aDoor.FStartHeight + ", "
                                                                    + aDoor.FLength + ", '"
                                                                    + aDoor.Colour + "', "
                                                                    + aDoor.Kickplate
                                                                    + ");";
                                            aCommand.ExecuteNonQuery();
                                            //Now make entry for the door window
                                            if (aDoor.DoorType != "Patio")
                                            {
                                                for (int doorNum = 1; doorNum < 2; doorNum++)
                                                {
                                                    Window doorWindow = aDoor.DoorWindow;
                                                    switch (doorWindow.WindowStyle)
                                                    {
                                                        #region old by-door
                                                        //case "Full Screen":
                                                        //    break;
                                                        //case "Vertical Four Track":
                                                        //case "Vertical 4 Track":
                                                        //    break;
                                                        //case "Full View":
                                                        //    break;
                                                        //case "Full View Colonial":
                                                        //    break;
                                                        //case "Half Lite":
                                                        //    break;
                                                        //case "Half Lite Venting":
                                                        //    break;
                                                        //case "Half Lite with Mini Blinds":
                                                        //    break;
                                                        //case "Full View with Mini Blinds":
                                                        //    break;
                                                        #endregion

                                                        #region new by-window
                                                        case "Vinyl":
                                                            aCommand.CommandText = "INSERT INTO vinyl_items(project_id, linear_index, module_index, vent_index, door_index, start_height, end_height, length, vinyl_tint, spreader_bar) VALUES("
                                                                                    + project_id + ", "
                                                                                    + linearCounter + ", "
                                                                                    + k + ", "
                                                                                    + -1 + ", " //This is not in a vent, this is just solid vinyl
                                                                                    + doorNum + ", " //This is a window, so it is 0
                                                                                    + doorWindow.LeftHeight + ", "
                                                                                    + doorWindow.RightHeight + ", "
                                                                                    + doorWindow.Width + ", '"
                                                                                    + doorWindow.Colour + "', "
                                                                                    + doorWindow.SpreaderBar 
                                                                                    + ");";
                                                            aCommand.ExecuteNonQuery();
                                                            break;

                                                        case "Glass":
                                                            aCommand.CommandText = "INSERT INTO glass_items(project_id, linear_index, module_index, vent_index, door_index, glass_type, start_height, end_height, length, glass_tint, tempered, operation) VALUES()"
                                                                                    + project_id + ", "
                                                                                    + linearCounter + ", "
                                                                                    + k + ", "
                                                                                    + -1 + ", " //This is not a vent, just solid glass
                                                                                    + doorNum + ", '" //This is a window
                                                                                    + "Single Glaze" + "', "
                                                                                    + doorWindow.LeftHeight + ", "
                                                                                    + doorWindow.RightHeight + ", "
                                                                                    + doorWindow.Width + ", '"
                                                                                    + doorWindow.Colour + "', "
                                                                                    + 0 + ", "
                                                                                    + 0
                                                                                    + ");";
                                                            aCommand.ExecuteNonQuery();
                                                            break;

                                                        case "Vertical 4 Track":
                                                            for (int vents = 0; vents < doorWindow.NumVents; vents++)
                                                            {
                                                                aCommand.CommandText = "INSERT INTO vinyl_items(project_id, linear_index, module_index, vent_index, door_index, start_height, end_height, length, vinyl_tint, spreader_bar) VALUES("
                                                                                        + project_id + ", "
                                                                                        + linearCounter + ", "
                                                                                        + k + ", "
                                                                                        + vents + ", " //This is not in a vent, this is just solid vinyl
                                                                                        + doorNum + ", " //This is a window, so it is 0
                                                                                        + doorWindow.LeftHeight + ", "
                                                                                        + doorWindow.RightHeight + ", "
                                                                                        + doorWindow.Width + ", '"
                                                                                        + doorWindow.Colour.Substring(vents, 1) + "', "
                                                                                        + doorWindow.SpreaderBar
                                                                                        + ");";
                                                                aCommand.ExecuteNonQuery();
                                                            }
                                                            break;

                                                        case "Horizontal 2 Track":
                                                            aCommand.CommandText = "INSERT INTO vinyl_items(project_id, linear_index, module_index, vent_index, door_index, start_height, end_height, length, vinyl_tint, spreader_bar) VALUES("
                                                                                    + project_id + ", "
                                                                                    + linearCounter + ", "
                                                                                    + k + ", "
                                                                                    + -1 + ", " //This is not in a vent, this is just solid vinyl
                                                                                    + doorNum + ", " //This is a window, so it is 0
                                                                                    + doorWindow.LeftHeight + ", "
                                                                                    + doorWindow.RightHeight + ", "
                                                                                    + doorWindow.Width + ", '"
                                                                                    + doorWindow.Colour + "', "
                                                                                    + doorWindow.SpreaderBar 
                                                                                    + ");";
                                                            aCommand.ExecuteNonQuery();
                                                            break;

                                                        case "Horizontal Roller":
                                                            aCommand.CommandText = "INSERT INTO vinyl_items(project_id, linear_index, module_index, vent_index, door_index, start_height, end_height, length, vinyl_tint, spreader_bar) VALUES("
                                                                                    + project_id + ", "
                                                                                    + linearCounter + ", "
                                                                                    + k + ", "
                                                                                    + -1 + ", " //This is not in a vent, this is just solid vinyl
                                                                                    + doorNum + ", " //This is a window, so it is 0
                                                                                    + doorWindow.LeftHeight + ", "
                                                                                    + doorWindow.RightHeight + ", "
                                                                                    + doorWindow.Width + ", '"
                                                                                    + doorWindow.Colour + "', "
                                                                                    + doorWindow.SpreaderBar 
                                                                                    + ");";
                                                            aCommand.ExecuteNonQuery();
                                                            break;

                                                        //case "Single Slider":
                                                        //    break;

                                                        //case "Double Slider":
                                                        //    break;

                                                        case "Screen":
                                                            aCommand.CommandText = "INSERT INTO screen_items(project_id, linear_index, module_index, door_index, screen_type, start_height, end_height, length, mount) VALUES("
                                                                                    + project_id + ", "
                                                                                    + linearCounter + ", "
                                                                                    + k + ", "
                                                                                    + doorNum + ", '" //This is a window, so 0
                                                                                    + doorWindow.ScreenType + "', "
                                                                                    + doorWindow.LeftHeight + ", "
                                                                                    + doorWindow.RightHeight + ", "
                                                                                    + doorWindow.Width + ", '"
                                                                                    + "In" + "'" //A screen window is inside mount, whereas a screen on a window of another type is outside mounted (handled below)
                                                                                    + ");";
                                                            aCommand.ExecuteNonQuery();
                                                            break;                                                            
                                                        #endregion
                                                    }
                                                    //If not a french door, we'll only have 1 door, so just increment this to cheat out of the loop
                                                    if (aDoor.DoorType != "French")
                                                    {
                                                        doorNum++;
                                                    }
                                                }
                                            }
                                            else if (aDoor.DoorType == "Patio")
                                            {
                                                Window doorWindow = aDoor.DoorWindow;
                                                switch (aDoor.DoorStyle)
                                                {
                                                    case "Aluminum Storm Screen":
                                                        aCommand.CommandText = "INSERT INTO glass_items(project_id, linear_index, module_index, vent_index, door_index, glass_type, start_height, end_height, length, glass_tint, tempered, operation) VALUES()"
                                                                                + project_id + ", "
                                                                                + linearCounter + ", "
                                                                                + k + ", "
                                                                                + -1 + ", " //This is not a vent, just solid glass
                                                                                + 1 + ", " //This is a window
                                                                                + "Single Glaze" + "', "
                                                                                + doorWindow.LeftHeight + ", "
                                                                                + doorWindow.RightHeight + ", "
                                                                                + doorWindow.Width + ", '"
                                                                                + doorWindow.Colour + "', "
                                                                                + 0 + ", "
                                                                                + 0
                                                                                + ");";
                                                        aCommand.ExecuteNonQuery();
                                                        break;
                                                    case "Aluminum Storm Glass":
                                                        aCommand.CommandText = "INSERT INTO glass_items(project_id, linear_index, module_index, vent_index, door_index, glass_type, start_height, end_height, length, glass_tint, tempered, operation) VALUES()"
                                                                                + project_id + ", "
                                                                                + linearCounter + ", "
                                                                                + k + ", "
                                                                                + -1 + ", " //This is not a vent, just solid glass
                                                                                + 1 + ", " //This is a window
                                                                                + "Single Glaze" + "', "
                                                                                + doorWindow.LeftHeight + ", "
                                                                                + doorWindow.RightHeight + ", "
                                                                                + doorWindow.Width + ", '"
                                                                                + doorWindow.Colour + "', "
                                                                                + 0 + ", "
                                                                                + 0 
                                                                                + ");";
                                                        aCommand.ExecuteNonQuery();
                                                        break;
                                                    case "Vinyl Guard":
                                                        break;
                                                }
                                            }

                                        //End of door
                                        break;
                                    }
                                }
                            }
                            linearCounter++;
                        }
                    }
                    #endregion

                    #region Roof
                    if (Session["newProjectHasRoof"].ToString() == "Yes")
                    {
                        Roof aRoof = (Roof)Session["completedRoof"];

                        int fireProtection = 0;
                        if (aRoof.FireProtection == true)
                        {
                            fireProtection = 1;
                        }

                        int thermadeck = 0;
                        if (aRoof.Thermadeck == true)
                        {
                            thermadeck = 1;
                        }

                        int acrylicBool = 0;
                        if (aRoof.Type.Contains("Acrylic"))
                        {
                            acrylicBool = 1;
                        }

                        int gutterBool = 0;
                        if (aRoof.Gutters == true)
                        {
                            gutterBool = 1;
                        }

                        int gutterProBool = 0;
                        if (aRoof.GutterPro == true)
                        {
                            gutterProBool = 1;
                        }

                        string roofType = Session["newProjectRoofType"].ToString();
                        if (roofType.Contains("Gable"))
                        {
                            roofType = "Gable";
                        }
                        aCommand.CommandText = "INSERT INTO roofs(project_id, roof_index, roof_type, interior_skin, exterior_skin, thickness, fire_protection, thermadeck, acrylic, gutter, gutter_pro, gutter_colour, number_supports, stripe_colour, projection, width) VALUES("
                                                + project_id + ", "
                                                + 0 + ", '"
                                                + roofType + "', '"
                                                + aRoof.InteriorSkin + "', '" 
                                                + aRoof.ExteriorSkin + "', " 
                                                + aRoof.Thickness + ", "
                                                + fireProtection + ", "
                                                + thermadeck + ", "
                                                + acrylicBool + ", "
                                                + gutterBool + ", "
                                                + gutterProBool + ", '"
                                                + aRoof.GutterColour + "', "
                                                + aRoof.NumberSupports + ", '"
                                                + aRoof.StripeColour + "', "
                                                + aRoof.Projection + ", "
                                                + aRoof.Width
                                                + ");";
                        aCommand.ExecuteNonQuery();

                        //Now insert the needed roof modules

                        for (int roofModules=0; roofModules < aRoof.RoofModules.Count; roofModules++)
                        {
                            string roof_view;
                            if (Session["newProjectRoofType"].ToString() == "Studio")
                            {
                                //If it's a studio roof, we have a single studio roof module
                                roof_view = "S";
                            }
                            else if(roofModules ==0)
                            {
                                //If it's not studio, and it's the first module, it's gable left
                                roof_view = "GL";
                            }
                            else
                            {
                                //Otherwise it's gable right
                                roof_view = "GR";
                            }

                            aCommand.CommandText = "INSERT INTO roof_modules(project_id, roof_index, roof_view, interior_skin, exterior_skin, number_items, projection, width) VALUES("
                                                + project_id + ", "
                                                + 0 + ", '"
                                                + roof_view + "', '"
                                                + aRoof.InteriorSkin + "', '" 
                                                + aRoof.ExteriorSkin + "', " 
                                                + aRoof.RoofModules[roofModules].RoofItems.Count + ", "
                                                + aRoof.RoofModules[roofModules].Projection + ", "
                                                + aRoof.RoofModules[roofModules].Width
                                                + ");";
                            aCommand.ExecuteNonQuery();

                            //We also enter the roof items
                            for (int roofItems=0; roofItems < aRoof.RoofModules[roofModules].RoofItems.Count; roofItems++)
                            {
                                aCommand.CommandText = "INSERT INTO roof_items(project_id, roof_index, roof_view, item_index, roof_item, projection, width) VALUES("
                                                + project_id + ", "
                                                + 0 + ", '"
                                                + roof_view + "', "
                                                + roofItems + ", '"
                                                + aRoof.RoofModules[roofModules].RoofItems[roofItems].ItemType + "', "
                                                + aRoof.RoofModules[roofModules].RoofItems[roofItems].Projection + ", "
                                                + aRoof.RoofModules[roofModules].RoofItems[roofItems].Width
                                                + ");";
                                aCommand.ExecuteNonQuery();

                                if (aRoof.RoofModules[roofModules].RoofItems[roofItems].ItemType == "Foam Panel")
                                {
                                    aCommand.CommandText = "INSERT INTO foam_panels(project_id, roof_index, roof_view, item_index, interior_skin, exterior_skin, projection, width, set_back, skylight, fanbeam) VALUES("
                                                + project_id + ", "
                                                + 0 + ", '"
                                                + roof_view + "', "
                                                + roofItems + ", '"
                                                + aRoof.InteriorSkin + "', '"
                                                + aRoof.ExteriorSkin + "', "
                                                + aRoof.RoofModules[roofModules].RoofItems[roofItems].Projection + ", "
                                                + aRoof.RoofModules[roofModules].RoofItems[roofItems].Width + ", "
                                                + 0 + ", " //what is normal set_back?
                                                + aRoof.RoofModules[roofModules].RoofItems[roofItems].SkyLight + ", "
                                                + aRoof.RoofModules[roofModules].RoofItems[roofItems].FanBeam
                                                + ");";
                                    aCommand.ExecuteNonQuery();
                                }

                                if (aRoof.RoofModules[roofModules].RoofItems[roofItems].ItemType == "Acrylic Panel")
                                {
                                    aCommand.CommandText = "INSERT INTO acrylic_panels(project_id, roof_index, roof_view, item_index, panel_colour, projection, width, set_back) VALUES("
                                                + project_id + ", "
                                                + 0 + ", '"
                                                + roof_view + "', "
                                                + roofItems + ", '"
                                                + Session["roofAcrylicPanelColour"] + "', "
                                                + aRoof.RoofModules[roofModules].RoofItems[roofItems].Projection + ", "
                                                + aRoof.RoofModules[roofModules].RoofItems[roofItems].Width + ", "
                                                + 0 //what is normal set_back?
                                                + ");";
                                    aCommand.ExecuteNonQuery();
                                }

                                if (aRoof.RoofModules[roofModules].RoofItems[roofItems].ItemType == "Thermadeck Panel")
                                {
                                    float leftSetBack = Convert.ToSingle(Session["roofJointSetback"]);
                                    float rightSetBack = Convert.ToSingle(Session["roofJointSetback"]);

                                    if (roofItems == aRoof.RoofModules[roofModules].RoofItems.Count - 1)
                                    {
                                        rightSetBack = Convert.ToSingle(Session["roofSidesSetback"]);
                                    }

                                    if (roofItems == 0)
                                    {
                                        leftSetBack = Convert.ToSingle(Session["roofSidesSetback"]);
                                    }

                                    aCommand.CommandText = "INSERT INTO thermadeck_panels(project_id, roof_index, roof_view, item_index, projection, width, set_back, back_setback, front_setback, right_setback, left_setback) VALUES("
                                                        + project_id + ", "
                                                        + 0 + ", '"
                                                        + roof_view + "', "
                                                        + roofItems + ", "
                                                        + aRoof.RoofModules[roofModules].RoofItems[roofItems].Projection + ", "
                                                        + aRoof.RoofModules[roofModules].RoofItems[roofItems].Width + ", "
                                                        + 0 + ", " //What is normal set_back? Soffit length?
                                                        + Convert.ToSingle(Session["roofLedgerSetback"]) + ", "
                                                        + Convert.ToSingle(Session["roofFrontSetback"]) + ", "
                                                        + rightSetBack + ", "
                                                        + leftSetBack
                                                        + ");";
                                    aCommand.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                    #endregion

                    #region Floor
                    if (Session["newProjectPrefabFloor"] == "Yes")
                    {
                        if (Session["floorType"].ToString() == "Thermadeck")
                        {
                            int vapourBarrier = 0;
                            if (Session["floorVapourBarrier"].ToString() == "true")
                            {
                                vapourBarrier = 1;
                            }
                            aCommand.CommandText = "INSERT INTO floors(project_id, floor_index, floor_type, projection, width, thickness, number_items, vapor_barrier) VALUES("
                                                    + project_id + ", "
                                                    + 0 + ", "
                                                    + "'Thermadeck'" + ", "
                                                    + Convert.ToSingle(Session["floorProjection"]) + ", "
                                                    + Convert.ToSingle(Session["floorWidth"]) + ", "
                                                    + Convert.ToSingle(Session["floorThickness"]) + ", "
                                                    + Convert.ToInt32(Session["floorPanelNumber"]) + ", "
                                                    + vapourBarrier
                                                    + ");";
                            aCommand.ExecuteNonQuery();

                            for (int i = 0; i < Convert.ToInt32(Session["floorPanelNumber"]); i++)
                            {
                                float panelWidth = Constants.THERMADECK_PANEL_WIDTH;
                                float leftSetBack = Convert.ToSingle(Session["floorJointSetback"]);
                                float rightSetBack = Convert.ToSingle(Session["floorJointSetback"]);

                                if (i == Convert.ToInt32(Session["floorPanelNumber"])-1)
                                {
                                    panelWidth = Convert.ToSingle(Session["floorLastPanelSize"]);
                                    rightSetBack = Convert.ToSingle(Session["floorSidesSetback"]);
                                }

                                if (i == 0)
                                {
                                    leftSetBack = Convert.ToSingle(Session["floorSidesSetback"]);
                                }

                                aCommand.CommandText = "INSERT INTO thermadeck_panels(project_id, roof_index, roof_view, item_index, projection, width, set_back, back_setback, front_setback, right_setback, left_setback) VALUES("
                                                    + project_id + ", "
                                                    + 0 + ", "
                                                    + "'F'" + ", "
                                                    + i + ", "
                                                    + Convert.ToSingle(Session["floorProjection"]) + ", "
                                                    + panelWidth + ", "
                                                    + 0 + ", " //What is normal set_back? Soffit length?
                                                    + Convert.ToSingle(Session["floorLedgerSetback"]) + ", "
                                                    + Convert.ToSingle(Session["floorFrontSetback"]) + ", "
                                                    + rightSetBack + ", "
                                                    + leftSetBack
                                                    + ");";
                                aCommand.ExecuteNonQuery();
                            }
                        }
                            //Session.Add("floorType", ddlFloorType.SelectedValue);
                            //Session.Add("floorProjection", txtProjectionDisplay.Text);
                            //Session.Add("floorWidth", txtWidthDisplay.Text);
                            //Session.Add("floorThickness", ddlFloorThickness.SelectedValue);
                            //Session.Add("floorVapourBarrier", chkVapourBarrier.Checked);
                            //Session.Add("floorPanelNumber", panelNumber);
                            //Session.Add("floorLastPanelSize", lastPanelSize);
                        //Session.Add("floorLedgerSetback", txtLedgerSetback + ddlLedgerSetbackInches.SelectedValue);
                        //Session.Add("floorFrontSetback", txtFrontSetback + ddlFrontSetbackInches.SelectedValue);
                        //Session.Add("floorSidesSetback", txtSidesSetback + ddlSidesSetbackInches.SelectedValue);
                        //Session.Add("floorJointSetback", txtJointSetback + ddlJointSetbackInches.SelectedValue);
                    }
                    #endregion
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
        }
    }
}
using System;
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
            //maybe a large textarea
            //project deatils
            //wall details
            // --> linear item details
            // -->--> module item details
            //floor details
            //roof details
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            List<Wall> listOfWalls = (List<Wall>)Session["listOfWalls"];
            using (SqlConnection aConnection = new SqlConnection(sdsDBConnection.ConnectionString))
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
                    //Project
                    #region Project
                    aCommand.CommandText = "INSERT INTO projects(project_type, installation_type, project_name, customer_id, user_id, date_created, status, revised_date, revised_user_id, msrp, project_notes, "
                                            + "hidden, cut_pitch) VALUES ("
                                            + "project_type='Sunroom', " //Will always be a sunroom to be at this point in wizard
                                            + "installation_type='" + "House" + "', "
                                            + "project_name='" + Session["newProjectProjectName"] + "', "
                                            + "customer_id=" + 1 + ", "
                                            + "user_id=" + Session["user_id"] + ", "
                                            + "date_created='" + DateTime.Now.ToString("yyyy/MM/dd") + "', "
                                            + "status='" + "Active" + "', "
                                            + "revised_date='" + DateTime.Now.ToString("yyyy/MM/dd") + "', "
                                            + "revised_user_id=" + Session["user_id"] + ", "
                                            + "msrp=" + 0 + ", "
                                            + "project_notes=" +  0 + ", "
                                            + "hidden=" + false + ", "
                                            + "cut_pitch=" + 1
                                            + ");";
                    aCommand.ExecuteNonQuery(); //Execute a command that does not return anything
                    #endregion

                    //Get project_id for use in below statements
                    int project_id = 1;

                    #region Walls
                    for (int i = 0; i < listOfWalls.Count; i++)
                    {
                        //GET A PROJECT_ID
                        //setback for wall
                        //fire protection for wall
                        aCommand.CommandText = "INSERT INTO walls(project_id, wall_index, wall_type, model_type, total_length, orientation, set_back, name, first_item_index, "
                                                + "last_item_index, start_height, end_height, soffit_length, gable_peak, obstructions, fire_protection) VALUES("
                                                + "project_id=" + project_id + ", "
                                                + "wall_index=" + i + ", "
                                                + "wall_type='" + listOfWalls[i].WallType + "', "
                                                + "model_type='" + listOfWalls[i].ModelType + "', "
                                                + "total_length=" + listOfWalls[i].Length + ", "
                                                + "orientation='" + listOfWalls[i].Orientation + "', "
                                                + "set_back=" + 0 + ", "
                                                + "name='" + listOfWalls[i].Name + "', "
                                                + "first_item_index=" + listOfWalls[i].FirstItemIndex + ", "
                                                + "last_item_index=" + listOfWalls[i].LastItemIndex + ", "
                                                + "start_height=" + listOfWalls[i].StartHeight + ", "
                                                + "end_height=" + listOfWalls[i].EndHeight + ", "
                                                + "soffit_length=" + listOfWalls[i].SoffitLength + ", "
                                                + "gable_peak=" + listOfWalls[i].GablePeak + ", "
                                                + "obstructions=" + 0 + ", " //CHANGEME obstructions unhandled at this point
                                                + "fire_protection=" + 0 + ", "
                                                + ");";
                        aCommand.ExecuteNonQuery(); //Execute a command that does not return anything
                    }
                    #endregion

                    #region Linear Items
                    for (int i = 0; i < listOfWalls.Count; i++)
                    {
                        for (int j = 0; j < listOfWalls[i].LinearItems.Count; j++)
                        {
                            //frame_colour
                            //sex
                            //attached_to logic, Lboxhead to door, door to Rboxhead
                            aCommand.CommandText = "INSERT INTO linear_items(project_id, linear_index, linear_type, start_height, end_height, length, frame_colour, sex, fixed_location, attached_to) VALUES("
                                                    + "project_id=" + project_id + ", "
                                                    + "linear_index=" + j + ", "
                                                    + "linear_type='" + listOfWalls[i].LinearItems[j].ItemType + "', "
                                                    + "start_height=" + listOfWalls[i].LinearItems[j].StartHeight + ", "
                                                    + "end_height=" + listOfWalls[i].LinearItems[j].EndHeight + ", "
                                                    + "length=" + listOfWalls[i].LinearItems[j].Length + ", "
                                                    + "frame_colour='" + Session["newProjectFramingColour"] + "', "
                                                    + "sex='" + "MM" + "', "
                                                    + "fixed_location=" + listOfWalls[i].LinearItems[j].FixedLocation + ", "
                                                    + "attached_to=" + 1 + ", " //Will start all as locked to avoid accidental changes in project editor before project submission
                                                    + ");";
                            aCommand.ExecuteNonQuery();
                        }
                    }
                    #endregion

                    #region Modular Items and Base Level Items
                    for (int i = 0; i < listOfWalls.Count; i++)
                    {
                        for (int j = 0; j < listOfWalls[i].LinearItems.Count; j++)
                        {
                            //Get the mod, then loop for all its items
                            Mod aMod = (Mod)listOfWalls[i].LinearItems[j];
                            for (int k = 0; k < aMod.ModularItems.Count; k++)
                            {
                                aCommand.CommandText = "INSERT INTO module_items(project_id, linear_index, module_index, item_type, start_height, end_height, length) VALUES("
                                                        + "project_id=" + project_id + ", "
                                                        + "linear_index=" + j + ", "
                                                        + "module_index=" + k + ", "
                                                        + "item_type='" + aMod.ModularItems[k].ItemType + "', "
                                                        + "start_height=" + aMod.ModularItems[k].FStartHeight + ", "
                                                        + "end_height=" + aMod.ModularItems[k].FEndHeight + ", "
                                                        + "length=" + aMod.ModularItems[k].FLength
                                                        + ");";
                                aCommand.ExecuteNonQuery();

                                switch (aMod.ModularItems[k].ItemType)
                                {
                                    case "Kneewall":
                                        //First make the 'window' entry, as a kneewall is just a special window located at the bottom of a mod
                                        Kneewall aKneewall = (Kneewall)aMod.ModularItems[k];
                                        aCommand.CommandText = "INSERT INTO windows(project_id, linear_index, module_index, door_index, window_type, screen_type, start_height, end_height, length, window_colour, number_vents) VALUES("
                                                                + "project_id=" + project_id + ", "
                                                                + "linear_index=" + j + ", "
                                                                + "module_index=" + k + ", "
                                                                + "door_index=" + 0 + ", " //0 because this is a window from a module, not within a door
                                                                + "window_type='" + aKneewall.KneewallType + "', "
                                                                + "screen_type='" + "No Screen" + "', " //Kneewalls don't have a screen
                                                                + "start_height=" + aKneewall.FStartHeight + ", "
                                                                + "end_height=" + aKneewall.FEndHeight + ", "
                                                                + "length=" + aKneewall.FLength + ", "
                                                                + "window_colour='" + Session["newProjectFramingColour"].ToString() + "', " //Kneewalls use the overall sunroom framing colour
                                                                + "number_vents=" + 0
                                                                + ");";
                                        aCommand.ExecuteNonQuery();
                                        switch (aKneewall.KneewallType)
                                        {
                                            case "Solid Wall":
                                                aCommand.CommandText = "INSERT INTO panels(project_id, linear_index, module_index, door_index, interior_skin, exterior_skin, start_height, end_height, length) VALUES("
                                                                        + "project_id=" + project_id + ", "
                                                                        + "linear_index=" + j + ", "
                                                                        + "module_index=" + k + ", "
                                                                        + "door_index=" + -1 + ", " //This is a kneewall, which is not a valid door_index, so we put -1
                                                                        + "interior_skin='" + Session["newProjectInteriorSkin"].ToString() + "', "
                                                                        + "exterior_skin='" + Session["newProjectExteriorSkin"].ToString() + "', "
                                                                        + "start_height=" + aKneewall.FStartHeight + ", " //Since a solid wall panel doesn't have framing, we use the 'framing size' to include the whole thing
                                                                        + "end_height=" + aKneewall.FEndHeight + ", "
                                                                        + "length=" + aKneewall.FLength
                                                                        + ");";
                                                aCommand.ExecuteNonQuery();
                                                break;
                                            case "Glass":
                                                aCommand.CommandText = "INSERT INTO glass_items(project_id, linear_index, module_index, vent_index, door_index, glass_type, start_height, end_height, length, glass_tint, tempered, operation) VALUES()"
                                                                        + "project_id=" + project_id + ", "
                                                                        + "linear_index=" + j + ", "
                                                                        + "module_index=" + k + ", "
                                                                        + "vent_index=" + -1 + ", " //This is not a vent, just solid glass
                                                                        + "door_index=" + 0 + ", " //This is a window
                                                                        + "glass_type='" + "" + "', "
                                                                        + "start_height=" + aKneewall.StartHeight + ", "
                                                                        + "end_height=" + aKneewall.EndHeight + ", "
                                                                        + "length=" + aKneewall.Length + ", "
                                                                        + "glass_tint='" + Session["newProjectKneewallTint"].ToString() + "', "
                                                                        + "tempered=" + 0 + ", "
                                                                        + "operation=" + 0 + ", "
                                                                        + ");";
                                                aCommand.ExecuteNonQuery();
                                                break;
                                        }
                                        break;
                                    case "Window":
                                        //If it's a window
                                        Window aWindow = (Window)aMod.ModularItems[k];
                                        aCommand.CommandText = "INSERT INTO windows(project_id, linear_index, module_index, door_index, window_type, screen_type, start_height, end_height, length, window_colour, number_vents) VALUES("
                                                                + "project_id=" + project_id + ", "
                                                                + "linear_index=" + j + ", "
                                                                + "module_index=" + k + ", "
                                                                + "door_index=" + 0 + ", " //0 because this is a window from a module, not within a door
                                                                + "window_type='" + aWindow.WindowType + "', "
                                                                + "screen_type='" + aWindow.ScreenType + "', "
                                                                + "start_height=" + aWindow.FStartHeight + ", "
                                                                + "end_height=" + aWindow.FEndHeight + ", "
                                                                + "length=" + aWindow.FLength + ", "
                                                                + "window_colour='" + aWindow.FrameColour + "', "
                                                                + "number_vents=" + aWindow.NumVents
                                                                + ");";
                                        aCommand.ExecuteNonQuery();

                                        //Then make the specific base item entry based on type of window
                                        switch (aWindow.WindowType) 
                                        {
                                            //Note, Vinyl and Glass are only accessible at this point as a transom
                                            //So we assume they're window entries
                                            case "Vinyl":
                                                aCommand.CommandText = "INSERT INTO vinyl_items(project_id, linear_index, module_index, vent_index, door_index, start_height, end_height, length, vinyl_tint, spreader_bar) VALUES("
                                                                        + "project_id=" + project_id + ", "
                                                                        + "linear_index=" + j + ", "
                                                                        + "module_index=" + k + ", "
                                                                        + "vent_index=" + -1 + ", " //This is not in a vent, this is just solid vinyl
                                                                        + "door_index=" + 0 + ", " //This is a window, so it is 0
                                                                        + "start_height=" + aWindow.StartHeight + ", "
                                                                        + "end_height=" + aWindow.EndHeight + ", "
                                                                        + "length=" + aWindow.Length + ", "
                                                                        + "vinyl_tint='" + aWindow.Colour + "', "
                                                                        + "spreader_bar=" + aWindow.SpreaderBar + ", "
                                                                        + ");";
                                                aCommand.ExecuteNonQuery();
                                                break;

                                            case "Glass":
                                                aCommand.CommandText = "INSERT INTO glass_items(project_id, linear_index, module_index, vent_index, door_index, glass_type, start_height, end_height, length, glass_tint, tempered, operation) VALUES()"
                                                                        + "project_id=" + project_id + ", "
                                                                        + "linear_index=" + j + ", "
                                                                        + "module_index=" + k + ", "
                                                                        + "vent_index=" + -1 + ", " //This is not a vent, just solid glass
                                                                        + "door_index=" + 0 + ", " //This is a window
                                                                        + "glass_type='" + "" + "', "
                                                                        + "start_height=" + aWindow.StartHeight + ", "
                                                                        + "end_height=" + aWindow.EndHeight + ", "
                                                                        + "length=" + aWindow.Length + ", "
                                                                        + "glass_tint='" + aWindow.Colour + "', "
                                                                        + "tempered=" + 0 + ", "
                                                                        + "operation=" + 0 + ", "
                                                                        + ");";
                                                aCommand.ExecuteNonQuery();
                                                break;

                                            case "Vertical 4 Track":
                                                break;

                                            case "Horizontal 4 Track":
                                                aCommand.CommandText = "INSERT INTO vinyl_items(project_id, linear_index, module_index, vent_index, door_index, start_height, end_height, length, vinyl_tint, spreader_bar) VALUES("
                                                                        + "project_id=" + project_id + ", "
                                                                        + "linear_index=" + j + ", "
                                                                        + "module_index=" + k + ", "
                                                                        + "vent_index=" + -1 + ", " //This is not in a vent, this is just solid vinyl
                                                                        + "door_index=" + 0 + ", " //This is a window, so it is 0
                                                                        + "start_height=" + aWindow.StartHeight + ", "
                                                                        + "end_height=" + aWindow.EndHeight + ", "
                                                                        + "length=" + aWindow.Length + ", "
                                                                        + "vinyl_tint='" + aWindow.Colour + "', "
                                                                        + "spreader_bar=" + "" + ", "
                                                                        + ");";
                                                break;

                                            case "Horizontal Roller":
                                                aCommand.CommandText = "INSERT INTO vinyl_items(project_id, linear_index, module_index, vent_index, door_index, start_height, end_height, length, vinyl_tint, spreader_bar) VALUES("
                                                                        + "project_id=" + project_id + ", "
                                                                        + "linear_index=" + j + ", "
                                                                        + "module_index=" + k + ", "
                                                                        + "vent_index=" + -1 + ", " //This is not in a vent, this is just solid vinyl
                                                                        + "door_index=" + 0 + ", " //This is a window, so it is 0
                                                                        + "start_height=" + aWindow.StartHeight + ", "
                                                                        + "end_height=" + aWindow.EndHeight + ", "
                                                                        + "length=" + aWindow.Length + ", "
                                                                        + "vinyl_tint='" + aWindow.Colour + "', "
                                                                        + "spreader_bar=" + "" + ", "
                                                                        + ");";
                                                break;

                                            case "Single Slider":
                                                break;

                                            case "Double Slider":
                                                break;

                                            case "Screen":
                                                break;
                                        }

                                        //Then if required, a screen table entry
                                        break;
                                    case "Door":
                                        break;
                                }
                            }
                        }
                    }
                    #endregion

                    //lblError.Text = "Successfully Updated!\n\n";
                    aTransaction.Commit();
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
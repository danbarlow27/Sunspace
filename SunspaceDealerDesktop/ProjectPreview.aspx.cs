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
                    for (int i = 0; i < listOfWalls.Count; i++)
                    {
                        for (int j = 0; j < listOfWalls[i].LinearItems.Count; j++)
                        {
                            //frame_colour
                            //sex
                            //attached_to logic, Lboxhead to door, door to Rboxhead
                            aCommand.CommandText = "INSERT INTO linear_items(project_id, linear_index, linear_type, start_height, end_height, length, frame_colour, sex, fixed_location, attached_to) VALUES("
                                                    + project_id + ", "
                                                    + j + ", '"
                                                    + listOfWalls[i].LinearItems[j].ItemType + "', "
                                                    + listOfWalls[i].LinearItems[j].StartHeight + ", "
                                                    + listOfWalls[i].LinearItems[j].EndHeight + ", "
                                                    + listOfWalls[i].LinearItems[j].Length + ", '"
                                                    + Session["newProjectFramingColour"] + "', '"
                                                    + "MM" + "', "
                                                    + listOfWalls[i].LinearItems[j].FixedLocation + ", "
                                                    + 1 //Will start all as locked to avoid accidental changes in project editor before project submission
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
                            if (listOfWalls[i].LinearItems[j].ItemType == "Mod")
                            {
                                //Get the mod, then loop for all its items
                                Mod aMod = (Mod)listOfWalls[i].LinearItems[j];
                                //We make a module entry for this module 
                                aCommand.CommandText = "INSERT INTO module(project_id, linear_index, number_items, sunshade) VALUES("
                                                        + project_id + ", "
                                                        + j + ", "
                                                        + aMod.ModularItems.Count + ", "
                                                        + aMod.Sunshade
                                                        + ");";
                                aCommand.ExecuteNonQuery();
                                
                                //If sunshades are true, we make an entry there too
                                if (aMod.Sunshade == true)
                                {
                                    //We make a sunshade entry for this module 
                                    aCommand.CommandText = "INSERT INTO sunshade_items(project_id, linear_index, height, length, valance_colour, fabric_colour, openness, chain) VALUES("
                                                            + project_id + ", "
                                                            + j + ", "
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
                                                            + j + ", "
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
                                                                    + j + ", "
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
                                                                            + j + ", "
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
                                                                            + j + ", "
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
                                                                    + j + ", "
                                                                    + k + ", "
                                                                    + 0 + ", '" //0 because this is a window from a module, not within a door
                                                                    + aWindow.WindowType + "', '"
                                                                    + aWindow.ScreenType + "', "
                                                                    + aWindow.FStartHeight + ", "
                                                                    + aWindow.FEndHeight + ", "
                                                                    + aWindow.FLength + ", '"
                                                                    + aWindow.FrameColour + "', "
                                                                    + aWindow.NumVents
                                                                    + ");";
                                            aCommand.ExecuteNonQuery();

                                            //Then make the specific base item entry based on type of window
                                            switch (aWindow.WindowType)
                                            {
                                                //Note, Vinyl and Glass are only accessible at this point as a transom
                                                //So we assume they're window entries
                                                case "Vinyl":
                                                    aCommand.CommandText = "INSERT INTO vinyl_items(project_id, linear_index, module_index, vent_index, door_index, start_height, end_height, length, vinyl_tint, spreader_bar) VALUES("
                                                                            + project_id + ", "
                                                                            + j + ", "
                                                                            + k + ", "
                                                                            + -1 + ", " //This is not in a vent, this is just solid vinyl
                                                                            + 0 + ", " //This is a window, so it is 0
                                                                            + aWindow.StartHeight + ", "
                                                                            + aWindow.EndHeight + ", "
                                                                            + aWindow.Length + ", '"
                                                                            + aWindow.Colour + "', "
                                                                            + aWindow.SpreaderBar + ", "
                                                                            + ");";
                                                    aCommand.ExecuteNonQuery();
                                                    break;

                                                case "Glass":
                                                    aCommand.CommandText = "INSERT INTO glass_items(project_id, linear_index, module_index, vent_index, door_index, glass_type, start_height, end_height, length, glass_tint, tempered, operation) VALUES()"
                                                                            + project_id + ", "
                                                                            + j + ", "
                                                                            + k + ", "
                                                                            + -1 + ", " //This is not a vent, just solid glass
                                                                            + 0 + ", " //This is a window
                                                                            + "Single Glaze" + "', "
                                                                            + aWindow.StartHeight + ", "
                                                                            + aWindow.EndHeight + ", "
                                                                            + aWindow.Length + ", '"
                                                                            + aWindow.Colour + "', "
                                                                            + 0 + ", "
                                                                            + 0 + ", "
                                                                            + ");";
                                                    aCommand.ExecuteNonQuery();
                                                    break;

                                                case "Vertical 4 Track":
                                                    for (int vents = 0; vents < aWindow.NumVents; vents++)
                                                    {
                                                        aCommand.CommandText = "INSERT INTO vinyl_items(project_id, linear_index, module_index, vent_index, door_index, start_height, end_height, length, vinyl_tint, spreader_bar) VALUES("
                                                                                + project_id + ", "
                                                                                + j + ", "
                                                                                + k + ", "
                                                                                + vents + ", " //This is not in a vent, this is just solid vinyl
                                                                                + 0 + ", " //This is a window, so it is 0
                                                                                + aWindow.StartHeight + ", "
                                                                                + aWindow.EndHeight + ", "
                                                                                + aWindow.Length + ", '"
                                                                                + aWindow.Colour.Substring(vents, 1) + "', "
                                                                                + aWindow.SpreaderBar + ", "
                                                                                + ");";
                                                        aCommand.ExecuteNonQuery();
                                                    }
                                                    break;

                                                case "Horizontal 2 Track":
                                                    aCommand.CommandText = "INSERT INTO vinyl_items(project_id, linear_index, module_index, vent_index, door_index, start_height, end_height, length, vinyl_tint, spreader_bar) VALUES("
                                                                            + project_id + ", "
                                                                            + j + ", "
                                                                            + k + ", "
                                                                            + -1 + ", " //This is not in a vent, this is just solid vinyl
                                                                            + 0 + ", " //This is a window, so it is 0
                                                                            + aWindow.StartHeight + ", "
                                                                            + aWindow.EndHeight + ", "
                                                                            + aWindow.Length + ", '"
                                                                            + aWindow.Colour + "', "
                                                                            + aWindow.SpreaderBar + ", "
                                                                            + ");";
                                                    aCommand.ExecuteNonQuery();
                                                    break;

                                                case "Horizontal Roller":
                                                    aCommand.CommandText = "INSERT INTO vinyl_items(project_id, linear_index, module_index, vent_index, door_index, start_height, end_height, length, vinyl_tint, spreader_bar) VALUES("
                                                                            + project_id + ", "
                                                                            + j + ", "
                                                                            + k + ", "
                                                                            + -1 + ", " //This is not in a vent, this is just solid vinyl
                                                                            + 0 + ", " //This is a window, so it is 0
                                                                            + aWindow.StartHeight + ", "
                                                                            + aWindow.EndHeight + ", "
                                                                            + aWindow.Length + ", '"
                                                                            + aWindow.Colour + "', "
                                                                            + aWindow.SpreaderBar + ", "
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
                                                                            + j + ", "
                                                                            + k + ", "
                                                                            + 0 + ", '" //This is a window, so 0
                                                                            + aWindow.ScreenType + "', "
                                                                            + aWindow.StartHeight + ", "
                                                                            + aWindow.EndHeight + ", "
                                                                            + aWindow.Length + ", '"
                                                                            + "In" + "'" //A screen window is inside mount, whereas a screen on a window of another type is outside mounted (handled below)
                                                                            + ");";
                                                    aCommand.ExecuteNonQuery();
                                                    break;
                                            }

                                            //Then if required, a screen table entry
                                            if (aWindow.ScreenType != "No Screen")
                                            {
                                                aCommand.CommandText = "INSERT INTO screen_items(project_id, linear_index, module_index, door_index, screen_type, start_height, end_height, length, mount) VALUES("
                                                                        + project_id + ", "
                                                                        + j + ", "
                                                                        + k + ", "
                                                                        + 0 + ", '" //This is a window, so 0
                                                                        + aWindow.ScreenType + "', "
                                                                        + aWindow.StartHeight + ", "
                                                                        + aWindow.EndHeight + ", "
                                                                        + aWindow.Length + ", '"
                                                                        + "Out" + "'" //This screen is a screen in addition to a window, so it will be an outside mounted screen on an inside mounted window
                                                                        + ");";
                                                aCommand.ExecuteNonQuery();
                                            }
                                            break;

                                        case "Door":
                                            Door aDoor = (Door)aMod.ModularItems[k];

                                            aCommand.CommandText = "INSERT INTO doors(project_id, linear_index, module_index, door_type, door_style, screen_type, height, length, door_colour, kick_plate) VALUES("
                                                                    + project_id + ", "
                                                                    + j + ", "
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
                                                    switch (doorWindow.WindowType)
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
                                                                                    + j + ", "
                                                                                    + k + ", "
                                                                                    + -1 + ", " //This is not in a vent, this is just solid vinyl
                                                                                    + doorNum + ", " //This is a window, so it is 0
                                                                                    + doorWindow.StartHeight + ", "
                                                                                    + doorWindow.EndHeight + ", "
                                                                                    + doorWindow.Length + ", '"
                                                                                    + doorWindow.Colour + "', "
                                                                                    + doorWindow.SpreaderBar 
                                                                                    + ");";
                                                            aCommand.ExecuteNonQuery();
                                                            break;

                                                        case "Glass":
                                                            aCommand.CommandText = "INSERT INTO glass_items(project_id, linear_index, module_index, vent_index, door_index, glass_type, start_height, end_height, length, glass_tint, tempered, operation) VALUES()"
                                                                                    + project_id + ", "
                                                                                    + j + ", "
                                                                                    + k + ", "
                                                                                    + -1 + ", " //This is not a vent, just solid glass
                                                                                    + doorNum + ", '" //This is a window
                                                                                    + "Single Glaze" + "', "
                                                                                    + doorWindow.StartHeight + ", "
                                                                                    + doorWindow.EndHeight + ", "
                                                                                    + doorWindow.Length + ", '"
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
                                                                                        + j + ", "
                                                                                        + k + ", "
                                                                                        + vents + ", " //This is not in a vent, this is just solid vinyl
                                                                                        + doorNum + ", " //This is a window, so it is 0
                                                                                        + doorWindow.StartHeight + ", "
                                                                                        + doorWindow.EndHeight + ", "
                                                                                        + doorWindow.Length + ", '"
                                                                                        + doorWindow.Colour.Substring(vents, 1) + "', "
                                                                                        + doorWindow.SpreaderBar 
                                                                                        + ");";
                                                                aCommand.ExecuteNonQuery();
                                                            }
                                                            break;

                                                        case "Horizontal 2 Track":
                                                            aCommand.CommandText = "INSERT INTO vinyl_items(project_id, linear_index, module_index, vent_index, door_index, start_height, end_height, length, vinyl_tint, spreader_bar) VALUES("
                                                                                    + project_id + ", "
                                                                                    + j + ", "
                                                                                    + k + ", "
                                                                                    + -1 + ", " //This is not in a vent, this is just solid vinyl
                                                                                    + doorNum + ", " //This is a window, so it is 0
                                                                                    + doorWindow.StartHeight + ", "
                                                                                    + doorWindow.EndHeight + ", "
                                                                                    + doorWindow.Length + ", '"
                                                                                    + doorWindow.Colour + "', "
                                                                                    + doorWindow.SpreaderBar 
                                                                                    + ");";
                                                            aCommand.ExecuteNonQuery();
                                                            break;

                                                        case "Horizontal Roller":
                                                            aCommand.CommandText = "INSERT INTO vinyl_items(project_id, linear_index, module_index, vent_index, door_index, start_height, end_height, length, vinyl_tint, spreader_bar) VALUES("
                                                                                    + project_id + ", "
                                                                                    + j + ", "
                                                                                    + k + ", "
                                                                                    + -1 + ", " //This is not in a vent, this is just solid vinyl
                                                                                    + doorNum + ", " //This is a window, so it is 0
                                                                                    + doorWindow.StartHeight + ", "
                                                                                    + doorWindow.EndHeight + ", "
                                                                                    + doorWindow.Length + ", '"
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
                                                                                    + j + ", "
                                                                                    + k + ", "
                                                                                    + doorNum + ", '" //This is a window, so 0
                                                                                    + doorWindow.ScreenType + "', "
                                                                                    + doorWindow.StartHeight + ", "
                                                                                    + doorWindow.EndHeight + ", "
                                                                                    + doorWindow.Length + ", '"
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
                                                                                + j + ", "
                                                                                + k + ", "
                                                                                + -1 + ", " //This is not a vent, just solid glass
                                                                                + 1 + ", " //This is a window
                                                                                + "Single Glaze" + "', "
                                                                                + doorWindow.StartHeight + ", "
                                                                                + doorWindow.EndHeight + ", "
                                                                                + doorWindow.Length + ", '"
                                                                                + doorWindow.Colour + "', "
                                                                                + 0 + ", "
                                                                                + 0
                                                                                + ");";
                                                        aCommand.ExecuteNonQuery();
                                                        break;
                                                    case "Aluminum Storm Glass":
                                                        aCommand.CommandText = "INSERT INTO glass_items(project_id, linear_index, module_index, vent_index, door_index, glass_type, start_height, end_height, length, glass_tint, tempered, operation) VALUES()"
                                                                                + project_id + ", "
                                                                                + j + ", "
                                                                                + k + ", "
                                                                                + -1 + ", " //This is not a vent, just solid glass
                                                                                + 1 + ", " //This is a window
                                                                                + "Single Glaze" + "', "
                                                                                + doorWindow.StartHeight + ", "
                                                                                + doorWindow.EndHeight + ", "
                                                                                + doorWindow.Length + ", '"
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
                        }
                    }
                    #endregion

                    #region Roof
                    if (Session["newProjectHasRoof"].ToString() != "")
                    {
                        Roof aRoof = (Roof)Session["completedRoof"];
                        aCommand.CommandText = "INSERT INTO roofs(project_id, roof_index, roof_type, interior_skin, exterior_skin, thickness, fire_protection, thermadeck, acrylic, gutter, gutter_pro, gutter_colour, projection, width) VALUES()"
                                                + "project_id=" + project_id + ", "
                                                + "roof_index=" + 0 + ", "
                                                + "roof_type='" + Session["newProjectRoofType"] + "', "
                                                + "interior_skin='" + aRoof.InteriorSkin + "', " 
                                                + "exterior_skin='" + aRoof.ExteriorSkin + "', " 
                                                + "thickness=" + aRoof.Thickness + ", "
                                                + "fire_protection=" + aRoof.FireProtection + ", "
                                                + "thermadeck=" + aRoof.Thermadeck + ", "
                                                + "acrylic=" + 0 + ", " //CHANGEME
                                                + "gutter=" + aRoof.Gutters + ", "
                                                + "gutter_pro=" + aRoof.GutterPro + ", "
                                                + "gutter_colour='" + aRoof.GutterColour + "', "
                                                + "projection=" + aRoof.Projection + ", "
                                                + "width=" + aRoof.Width
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

                            aCommand.CommandText = "INSERT INTO roof_modules(project_id, roof_index, roof_view, interior_skin, exterior_skin, number_items, projection, width) VALUES()"
                                                + "project_id=" + project_id + ", "
                                                + "roof_index=" + 0 + ", "
                                                + "roof_view='" + roof_view + "', "
                                                + "interior_skin='" + aRoof.InteriorSkin + "', " 
                                                + "exterior_skin='" + aRoof.ExteriorSkin + "', " 
                                                + "number_items=" + aRoof.RoofModules[roofModules].RoofItems.Count + ", "
                                                + "projection=" + aRoof.RoofModules[roofModules].Projection + ", "
                                                + "width=" + aRoof.RoofModules[roofModules].Width
                                                + ");";
                            aCommand.ExecuteNonQuery();

                            //We also enter the roof items
                            for (int roofItems=0; roofItems < aRoof.RoofModules[roofModules].RoofItems.Count; roofItems++)
                            {
                                aCommand.CommandText = "INSERT INTO roof_items(project_id, roof_index, roof_view, item_index, roof_item, projection, width) VALUES()"
                                                + "project_id=" + project_id + ", "
                                                + "roof_index=" + 0 + ", "
                                                + "roof_view='" + roof_view + "', "
                                                + "item_index=" + roofItems + ", "
                                                + "roof_item='" + aRoof.RoofModules[roofModules].RoofItems[roofItems].ItemType + "', "
                                                + "projection=" + aRoof.RoofModules[roofModules].RoofItems[roofItems].Projection + ", "
                                                + "width=" + aRoof.RoofModules[roofModules].RoofItems[roofItems].Width
                                                + ");";
                                aCommand.ExecuteNonQuery();
                            }
                        }
                    }
                    #endregion

                    #region Floor
                    if (Session["newProjectPrefabFloor"] != "")
                    {

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
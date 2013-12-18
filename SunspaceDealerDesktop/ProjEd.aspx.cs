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

            int linearIndex;
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
            List<LinearItem> listOfLinearItems = new List<LinearItem>();
            List<ModuleItem> listOfModuleItems = new List<ModuleItem>();

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

                    aCommand.CommandText = "SELECT * FROM walls WHERE project_id = '" + project_id + "'";
                    aReader = aCommand.ExecuteReader();
                    
                    wallCount  = aReader.RecordsAffected;




                    //Get linear items
                    //aCommand.CommandText = "SELECT linear_type, start_height, end_height, length, frame_colour, sex, fixed_location, attached_to "
                    //                        + "FROM linear_items WHERE project_id = '" + project_id + "' AND linear_index = '" + linear_index + "'";
                    aReader = aCommand.ExecuteReader();
                    aReader.Read();

                    //int linear_index = Convert.ToInt32(aReader[0]);
                    linear_type = Convert.ToString(aReader[1]);
                    linear_start_height = Convert.ToSingle(aReader[2]);
                    linear_end_height = Convert.ToSingle(aReader[3]);
                    //length = Convert.ToSingle(aReader[4]);
                    frame_colour = Convert.ToString(aReader[5]);
                    sex = Convert.ToString(aReader[6]);
                    fixed_location = Convert.ToSingle(aReader[7]);
                    attached_to = Convert.ToBoolean(aReader[8]);
                    
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
                                                            + (Math.Max(aMod.StartHeight, aMod.EndHeight) - Math.Max(aMod.ModularItems[aMod.ModularItems.Count - 1].FStartHeight, aMod.ModularItems[aMod.ModularItems.Count - 1].FEndHeight)) + ", "
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

                        for (int roofModules = 0; roofModules < aRoof.RoofModules.Count; roofModules++)
                        {
                            string roof_view;
                            if (Session["newProjectRoofType"].ToString() == "Studio")
                            {
                                //If it's a studio roof, we have a single studio roof module
                                roof_view = "S";
                            }
                            else if (roofModules == 0)
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
                            for (int roofItems = 0; roofItems < aRoof.RoofModules[roofModules].RoofItems.Count; roofItems++)
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

                                if (i == Convert.ToInt32(Session["floorPanelNumber"]) - 1)
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
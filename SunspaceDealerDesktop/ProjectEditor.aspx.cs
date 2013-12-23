using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;


namespace SunspaceDealerDesktop
{
    public partial class ProjectEditor : System.Web.UI.Page
    {

        protected List<Wall> listOfWalls = new List<Wall>();
        protected Roof aRoof;
        protected Floor aFloor;
        protected int wallCount = 0;
        protected int floorCount = 0;
        protected int roofCount = 0;
        protected int project_id = 10; //get it from the session

        protected void Page_Load(object sender, EventArgs e)
        {
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
                    //get number of walls floors and roofs
                    aCommand.CommandText = "SELECT number_walls, number_floors, number_roofs FROM sunrooms WHERE project_id = '" + project_id + "'";
                    SqlDataReader projectReader = aCommand.ExecuteReader();

                    if (projectReader.HasRows)
                    {
                        projectReader.Read();

                        wallCount = Convert.ToInt32(projectReader[0]);
                        floorCount = Convert.ToInt32(projectReader[1]);
                        roofCount = Convert.ToInt32(projectReader[2]);
                    }
                    aReader.Close(); 

                    #region walls
                    //for each wall in the project
                    //for (int i = 0; i < wallCount; i++)
                    aCommand.CommandText = "SELECT wall_type, model_type, total_length, orientation, set_back, name, first_item_index, last_item_index, start_height, end_height, soffit_length, gable_peak, obstructions, fire_protection, wall_index "
                        + "FROM walls WHERE project_id = '" + project_id + "'";

                    SqlDataReader wallReader = aCommand.ExecuteReader();

                    if (wallReader.HasRows)
                    {
                        while (wallReader.Read())
                        {
                            //aCommand.CommandText = "SELECT wall_type, model_type, total_length, orientation, set_back, name, first_item_index, last_item_index, start_height, end_height, soffit_length, gable_peak, obstructions, fire_protection "
                            //+ "FROM walls WHERE project_id = '" + project_id + "' AND wall_index = '" + i + "'";

                            //aReader = aCommand.ExecuteReader();
                            //aReader.Read();

                            //create a new instance of a wall and set all its attributes from the db
                            Wall aWall = new Wall();
                            aWall.WallType = Convert.ToString(wallReader[0]);
                            aWall.ModelType = Convert.ToString(wallReader[1]);
                            aWall.Length = Convert.ToSingle(wallReader[2]);
                            aWall.Orientation = Convert.ToString(wallReader[3]);
                            aWall.SetBack = Convert.ToSingle(wallReader[4]);
                            aWall.Name = Convert.ToString(wallReader[5]);
                            aWall.FirstItemIndex = Convert.ToInt32(wallReader[6]);
                            aWall.LastItemIndex = Convert.ToInt32(wallReader[7]);
                            aWall.StartHeight = Convert.ToSingle(wallReader[8]);
                            aWall.EndHeight = Convert.ToSingle(wallReader[9]);
                            aWall.SoffitLength = Convert.ToSingle(wallReader[10]);
                            aWall.GablePeak = Convert.ToSingle(wallReader[11]);
                            aWall.FireProtection = Convert.ToBoolean(wallReader[13]);
                            int wallIndex = Convert.ToInt32(wallReader[0]);

                            //aReader.Close();

                            List<LinearItem> listOfLinearItems = new List<LinearItem>();

                            //Get linear items
                            aCommand.CommandText = "SELECT linear_index, linear_type, start_height, end_height, length, frame_colour, sex, fixed_location, attached_to "
                                                    + "FROM linear_items WHERE project_id = '" + project_id + "' AND last_item_index < '" + aWall.LastItemIndex + "' AND first_item_index > '" + aWall.FirstItemIndex + "'";
                            SqlDataReader listItemReader = aCommand.ExecuteReader();

                            //for each linear item/mod in the wall
                            //for (int j = aWall.FirstItemIndex; j < aWall.LastItemIndex; j++)
                            if (listItemReader.HasRows)
                            {
                                while (listItemReader.Read())
                                {
                                    //Get linear items
                                    //aCommand.CommandText = "SELECT linear_index, linear_type, start_height, end_height, length, frame_colour, sex, fixed_location, attached_to "
                                    //                        + "FROM linear_items WHERE project_id = '" + project_id + "' AND linear_index = '" + j + "'";
                                    //aReader = aCommand.ExecuteReader();
                                    //aReader.Read();


                                    int linearIndex = Convert.ToInt32(listItemReader[0]);
                                    string linearItemType = Convert.ToString(listItemReader[1]);
                                    float startHeight = Convert.ToSingle(listItemReader[2]);
                                    float endHeight = Convert.ToSingle(listItemReader[3]);
                                    float length = Convert.ToSingle(listItemReader[4]);
                                    string frameColour = Convert.ToString(listItemReader[5]);
                                    string sex = Convert.ToString(listItemReader[6]);
                                    float fixedLocation = Convert.ToSingle(listItemReader[7]);
                                    bool attachedTo = Convert.ToBoolean(listItemReader[8]);

                                    //aReader.Close();

                                    switch (linearItemType)
                                    {
                                        case "Mod":
                                            #region Mod

                                            List<ModuleItem> listOfModuleItems = new List<ModuleItem>();

                                            Mod aMod = new Mod();

                                            aMod.LinearIndex = linearIndex;
                                            aMod.ItemType = linearItemType;
                                            aMod.StartHeight = startHeight;
                                            aMod.EndHeight = endHeight;
                                            aMod.Length = length;
                                            aMod.FrameColour = frameColour;
                                            aMod.Sex = sex;
                                            aMod.FixedLocation = fixedLocation;
                                            aMod.AttachedTo = attachedTo;

                                            //get number of mods
                                            //aCommand.CommandText = "SELECT * FROM moduleItems WHERE project_id = '" + project_id + "' "
                                            //                                        + " AND linear_index = '" + aMod.LinearIndex + "'";
                                            //aReader = aCommand.ExecuteReader();

                                            //int modCount = aReader.RecordsAffected; //get the number of walls in the project

                                            //aReader.Close();

                                            aCommand.CommandText = "SELECT module_index, item_type, start_height, end_height, length FROM moduleItems "
                                                                + "WHERE project_id = '" + project_id + "' AND linear_index = '" + aMod.LinearIndex + "'";

                                            SqlDataReader moduleItemReader = aCommand.ExecuteReader();

                                            //for each modular item in the mod
                                            //for (int k = 0; k < modCount; k++)
                                            if (moduleItemReader.HasRows)
                                            {
                                                while (moduleItemReader.Read())
                                                {
                                                    //Get module items
                                                    // aCommand.CommandText = "SELECT module_index, item_type, start_height, end_height, length FROM moduleItems "
                                                    //                + "WHERE project_id = '" + project_id + "' AND linear_index = '" + aMod.LinearIndex + "' AND module_index = '" + k + "'";

                                                    //aReader = aCommand.ExecuteReader();
                                                    //aReader.Read();

                                                    int moduleIndex = Convert.ToInt32(moduleItemReader[0]);
                                                    string itemType = Convert.ToString(moduleItemReader[1]);
                                                    float fStartHeight = Convert.ToSingle(moduleItemReader[2]);
                                                    float fEndHeight = Convert.ToSingle(moduleItemReader[3]);
                                                    float fLength = Convert.ToSingle(moduleItemReader[4]);

                                                    //aReader.Close();


                                                    //different types of mods 
                                                    switch (itemType)
                                                    {
                                                        case "Window":
                                                            #region Window
                                                            //Get window
                                                            aCommand.CommandText = "SELECT window_type, screen_type, start_height, end_height, length, window_colour, number_vents FROM windows "
                                                                                    + "WHERE project_id = '" + project_id + "' AND linear_index = '" + aMod.LinearIndex + "' AND module_index = '" + moduleIndex + "'";

                                                            SqlDataReader windowReader = aCommand.ExecuteReader();

                                                            if (windowReader.HasRows)
                                                            {
                                                                windowReader.Read();

                                                                string windowStyle = Convert.ToString(windowReader[0]);
                                                                string screenType = Convert.ToString(windowReader[1]);
                                                                float windowStartHeight = Convert.ToSingle(windowReader[2]);
                                                                float windowEndHeight = Convert.ToSingle(windowReader[3]);
                                                                float windowLength = Convert.ToSingle(windowReader[4]);
                                                                string windowColour = Convert.ToString(windowReader[5]);
                                                                int numVents = Convert.ToInt32(windowReader[6]); //i assume this is also used for glass windows???

                                                                //aReader.Close();

                                                                //types of windows
                                                                switch (windowStyle)
                                                                {
                                                                    case "Vinyl":
                                                                        #region Vinyl Window

                                                                        VinylWindow aVinylWindow = new VinylWindow();
                                                                        aVinylWindow.ModuleIndex = moduleIndex;
                                                                        aVinylWindow.ItemType = itemType;
                                                                        aVinylWindow.FStartHeight = fStartHeight;
                                                                        aVinylWindow.FEndHeight = fEndHeight;
                                                                        aVinylWindow.FLength = fLength;
                                                                        //aVinylWindow.Colour = windowColour; //replaced by FrameColour
                                                                        aVinylWindow.WindowStyle = windowStyle;
                                                                        aVinylWindow.ScreenType = screenType;
                                                                        aVinylWindow.LeftHeight = windowStartHeight;
                                                                        aVinylWindow.RightHeight = windowEndHeight;
                                                                        aVinylWindow.Width = windowLength;
                                                                        aVinylWindow.FrameColour = windowColour; //
                                                                        aVinylWindow.VinylTint = ""; // tint of each vent will be concatenated
                                                                        aVinylWindow.NumVents = numVents;

                                                                        List<float> listOfVentHeights = new List<float>();

                                                                        //Get vinyl item
                                                                        aCommand.CommandText = "SELECT start_height, vinyl_tint, spreader_bar FROM vinyl_items "
                                                                                                + "WHERE project_id = '" + project_id + "' AND linear_index = '" + aMod.LinearIndex + "' AND module_index = '" + moduleIndex + "'";

                                                                        SqlDataReader vinylReader = aCommand.ExecuteReader();

                                                                        if (vinylReader.HasRows)
                                                                        {
                                                                            while (vinylReader.Read())
                                                                            //for each vinyl item in the in the vinyl window
                                                                            //for (int l = 0; l < numVents; l++)
                                                                            {


                                                                                listOfVentHeights.Add(Convert.ToSingle(vinylReader[0]));
                                                                                aVinylWindow.VinylTint += Convert.ToString(vinylReader[1]);
                                                                                aVinylWindow.SpreaderBar = Convert.ToSingle(vinylReader[2]);


                                                                            }
                                                                        }
                                                                        vinylReader.Close();

                                                                        aVinylWindow.VentHeights = listOfVentHeights;

                                                                        listOfModuleItems.Add(aVinylWindow);

                                                                        #endregion
                                                                        break;
                                                                    case "Screen":
                                                                        #region Screen Window

                                                                        Window aWindow = new Window();
                                                                        aWindow.ModuleIndex = moduleIndex;
                                                                        aWindow.ItemType = itemType;
                                                                        aWindow.FStartHeight = fStartHeight;
                                                                        aWindow.FEndHeight = fEndHeight;
                                                                        aWindow.FLength = fLength;
                                                                        //aWindow.Colour = windowColour; //replaced by FrameColour
                                                                        aWindow.WindowStyle = windowStyle;
                                                                        aWindow.ScreenType = screenType;
                                                                        aWindow.LeftHeight = windowStartHeight;
                                                                        aWindow.RightHeight = windowEndHeight;
                                                                        aWindow.Width = windowLength;
                                                                        aWindow.FrameColour = windowColour; //
                                                                        //aWindow.VinylTint = ""; // tint of each vent will be concatenated
                                                                        //aWindow.NumVents = numVents;

                                                                        listOfModuleItems.Add(aWindow);

                                                                        #endregion
                                                                        break;
                                                                    case "Glass":
                                                                        #region Glass Window

                                                                        GlassWindow aGlassWindow = new GlassWindow();
                                                                        aGlassWindow.ModuleIndex = moduleIndex;
                                                                        aGlassWindow.ItemType = itemType;
                                                                        aGlassWindow.FStartHeight = fStartHeight;
                                                                        aGlassWindow.FEndHeight = fEndHeight;
                                                                        aGlassWindow.FLength = fLength;
                                                                        //aGlassWindow.Colour = windowColour; //replaced by frameColour
                                                                        aGlassWindow.WindowStyle = windowStyle;
                                                                        aGlassWindow.ScreenType = screenType;
                                                                        aGlassWindow.LeftHeight = windowStartHeight;
                                                                        aGlassWindow.RightHeight = windowEndHeight;
                                                                        aGlassWindow.Width = windowLength;
                                                                        aGlassWindow.FrameColour = windowColour; // 
                                                                        aGlassWindow.GlassTint = ""; // tint of each vent will be concatenated
                                                                        aGlassWindow.Operation = ""; // XX, XO, OX will be concatenated
                                                                        aGlassWindow.NumVents = numVents;


                                                                        //Get glass item
                                                                        aCommand.CommandText = "SELECT glass_type, glass_tint, tempered, operation FROM glass_items "
                                                                                                + "WHERE project_id = '" + project_id + "' AND linear_index = '" + aMod.LinearIndex + "' AND module_index = '" + moduleIndex + "'";

                                                                        SqlDataReader glassReader = aCommand.ExecuteReader();

                                                                        //for (int l = 0; l < numVents; l++)

                                                                        if (glassReader.HasRows)
                                                                        {
                                                                            while (glassReader.Read())
                                                                            {
                                                                                aGlassWindow.GlassType = Convert.ToString(glassReader[0]);
                                                                                aGlassWindow.GlassTint += Convert.ToString(glassReader[1]);
                                                                                aGlassWindow.Tempered = Convert.ToBoolean(glassReader[2]);
                                                                                aGlassWindow.Operation += Convert.ToString(glassReader[3]);
                                                                            }
                                                                        }
                                                                        glassReader.Close();

                                                                        listOfModuleItems.Add(aGlassWindow);

                                                                        #endregion
                                                                        break;
                                                                    case "Open":
                                                                        #region Open Window
                                                                        Window openWindow = new Window();
                                                                        openWindow.ModuleIndex = moduleIndex;
                                                                        openWindow.ItemType = itemType;
                                                                        openWindow.FStartHeight = fStartHeight;
                                                                        openWindow.FEndHeight = fEndHeight;
                                                                        openWindow.FLength = fLength;

                                                                        listOfModuleItems.Add(openWindow); //add the modular item to the list
                                                                        #endregion
                                                                        break;
                                                                }
                                                            }
                                                            windowReader.Close();
                                                            #endregion
                                                            break;
                                                        case "Door":
                                                            #region Door
                                                            //Get door
                                                            aCommand.CommandText = "SELECT door_type, door_style, screen_type, height, length, door_colour, kick_plate FROM doors "
                                                                                    + "WHERE project_id = '" + project_id + "' AND linear_index = '" + aMod.LinearIndex + "' AND module_index = '" + moduleIndex + "'";

                                                            SqlDataReader doorReader = aCommand.ExecuteReader();

                                                            if (doorReader.HasRows)
                                                            {
                                                                while (doorReader.Read())
                                                                {

                                                                    string doorType = Convert.ToString(doorReader[0]);
                                                                    string doorStyle = Convert.ToString(doorReader[1]);
                                                                    string doorScreenType = Convert.ToString(doorReader[2]);
                                                                    float doorFrameHeight = Convert.ToSingle(doorReader[3]);
                                                                    float doorFrameLength = Convert.ToSingle(doorReader[4]);
                                                                    string doorColour = Convert.ToString(doorReader[5]);
                                                                    float doorKickPlate = Convert.ToSingle(doorReader[6]);
                                                                
                                                                    //doorReader.Close();

                                                                    //get the window in this door
                                                                    aCommand.CommandText = "SELECT door_index, window_type, screen_type, start_height, end_height, length, window_colour, number_vents FROM windows "
                                                                                            + "WHERE project_id = '" + project_id + "' AND linear_index = '" + aMod.LinearIndex + "' AND module_index = '" + moduleIndex + "'";

                                                                    SqlDataReader doorWindowReader = aCommand.ExecuteReader();

                                                                    VinylWindow aDoorWindow = new VinylWindow();

                                                                    if (doorWindowReader.HasRows)
                                                                    {
                                                                        while (doorWindowReader.Read())
                                                                        {
                                                                            //int doorIndex = Convert.ToInt32(doorWindowReader[0]);
                                                                            aDoorWindow.WindowStyle = Convert.ToString(doorWindowReader[1]);
                                                                            aDoorWindow.ScreenType = Convert.ToString(doorWindowReader[2]);
                                                                            aDoorWindow.LeftHeight = Convert.ToSingle(doorWindowReader[3]);
                                                                            aDoorWindow.RightHeight = Convert.ToSingle(doorWindowReader[4]);
                                                                            aDoorWindow.Width = Convert.ToSingle(doorWindowReader[5]);
                                                                            aDoorWindow.FrameColour = Convert.ToString(doorWindowReader[6]);
                                                                            aDoorWindow.NumVents = Convert.ToInt32(doorWindowReader[7]);
                                                                        }
                                                                    }
                                                                    doorWindowReader.Close();

                                                                    switch (aDoorWindow.WindowStyle) //door/window style
                                                                    {
                                                                        case "Full Screen": //screen
                                                                            break;
                                                                        case "Vertical Four Track": //vinyl
                                                                            #region V4T
                                                                            List<float> listOfV4TVentHeights = new List<float>();

                                                                            //for each vinyl item in the in the vinyl window
                                                                            //for (int l = 0; l < aDoorWindow.NumVents; l++)
                                                                            //Get vinyl item
                                                                            aCommand.CommandText = "SELECT start_height, vinyl_tint, spreader_bar FROM vinyl_items "
                                                                                                    + "WHERE project_id = '" + project_id + "' AND linear_index = '" + aMod.LinearIndex + "' AND module_index = '" + moduleIndex + "'";

                                                                            SqlDataReader vinylReader = aCommand.ExecuteReader();

                                                                            if (vinylReader.HasRows)
                                                                            {
                                                                                while (vinylReader.Read())
                                                                                {
                                                                                    listOfV4TVentHeights.Add(Convert.ToSingle(vinylReader[0]));
                                                                                    aDoorWindow.VinylTint += Convert.ToString(vinylReader[1]);
                                                                                    aDoorWindow.SpreaderBar = Convert.ToSingle(vinylReader[2]);
                                                                                }
                                                                            }
                                                                            vinylReader.Close();

                                                                            aDoorWindow.VentHeights = listOfV4TVentHeights;
                                                                            #endregion
                                                                            break;
                                                                        case "Full View": //glass
                                                                            break;
                                                                        case "Full View Colonial": //glass
                                                                            break;
                                                                        case "Half Lite": //glass
                                                                            break;
                                                                        case "Half Lite Venting": //glass
                                                                            break;
                                                                        case "Half Lite with Mini Blinds": //glass
                                                                            break;
                                                                        case "Full View with Mini Blinds": //glass
                                                                            break;
                                                                        case "Aluminum Storm Screen": //screen
                                                                            break;
                                                                        case "Aluminum Storm Glass": //glass
                                                                            break;
                                                                        case "Vinyl Guard": //vinyl
                                                                            break;
                                                                    }
                                                                    //types of doors
                                                                    switch (doorType)
                                                                    {
                                                                        case "Cabana Door":
                                                                            #region Cabana Door

                                                                            aCommand.CommandText = "SELECT glass_tint, hinge, swing, hardware_type FROM cabana_doors "
                                                                                            + "WHERE project_id = '" + project_id + "' AND linear_index = '" + aMod.LinearIndex + "' AND module_index = '" + moduleIndex + "'";

                                                                            SqlDataReader cabanaReader = aCommand.ExecuteReader();

                                                                            if (cabanaReader.HasRows)
                                                                            {
                                                                                cabanaReader.Read();

                                                                                CabanaDoor aCabanaDoor = new CabanaDoor();
                                                                                aCabanaDoor.ModuleIndex = moduleIndex;
                                                                                aCabanaDoor.ItemType = itemType;
                                                                                aCabanaDoor.FStartHeight = fStartHeight;
                                                                                aCabanaDoor.FEndHeight = fEndHeight;
                                                                                aCabanaDoor.FLength = fLength;
                                                                                aCabanaDoor.DoorType = doorType;
                                                                                aCabanaDoor.DoorStyle = doorStyle;
                                                                                aCabanaDoor.ScreenType = doorScreenType;
                                                                                aCabanaDoor.Height = doorFrameHeight;
                                                                                aCabanaDoor.Length = doorFrameLength;
                                                                                aCabanaDoor.Colour = doorColour; //
                                                                                aCabanaDoor.Kickplate = doorKickPlate; //
                                                                                aCabanaDoor.GlassTint = Convert.ToString(cabanaReader[0]);
                                                                                aCabanaDoor.Hinge = Convert.ToString(cabanaReader[1]);
                                                                                aCabanaDoor.Swing = Convert.ToString(cabanaReader[2]);
                                                                                aCabanaDoor.HardwareType = Convert.ToString(cabanaReader[3]);

                                                                                aCabanaDoor.DoorWindow = aDoorWindow;

                                                                                listOfModuleItems.Add(aCabanaDoor); //add the modular item to the list
                                                                            }
                                                                            cabanaReader.Close();

                                                                            #endregion
                                                                            break;
                                                                        case "French Door":
                                                                            #region French Door

                                                                            aCommand.CommandText = "SELECT glass_tint, swing, operator, hardware_type FROM french_doors "
                                                                                            + "WHERE project_id = '" + project_id + "' AND linear_index = '" + aMod.LinearIndex + "' AND module_index = '" + moduleIndex + "'";

                                                                            SqlDataReader frenchReader = aCommand.ExecuteReader();

                                                                            if (frenchReader.HasRows)
                                                                            {

                                                                                frenchReader.Read();

                                                                                FrenchDoor aFrenchDoor = new FrenchDoor();
                                                                                aFrenchDoor.ModuleIndex = moduleIndex;
                                                                                aFrenchDoor.ItemType = itemType;
                                                                                aFrenchDoor.FStartHeight = fStartHeight;
                                                                                aFrenchDoor.FEndHeight = fEndHeight;
                                                                                aFrenchDoor.FLength = fLength;
                                                                                aFrenchDoor.DoorType = doorType;
                                                                                aFrenchDoor.DoorStyle = doorStyle;
                                                                                aFrenchDoor.ScreenType = doorScreenType;
                                                                                aFrenchDoor.Height = doorFrameHeight;
                                                                                aFrenchDoor.Length = doorFrameLength;
                                                                                aFrenchDoor.Colour = doorColour; //
                                                                                aFrenchDoor.Kickplate = doorKickPlate; // 
                                                                                aFrenchDoor.GlassTint = Convert.ToString(frenchReader[0]);
                                                                                aFrenchDoor.Swing = Convert.ToString(frenchReader[1]);
                                                                                aFrenchDoor.OperatingDoor = Convert.ToString(frenchReader[2]); ///this needs to be fixed, operator in db is bool and C# is string
                                                                                aFrenchDoor.HardwareType = Convert.ToString(frenchReader[3]);

                                                                                aFrenchDoor.DoorWindow = aDoorWindow;

                                                                                listOfModuleItems.Add(aFrenchDoor); //add the modular item to the list
                                                                            }
                                                                            frenchReader.Close();

                                                                            #endregion
                                                                            break;
                                                                        case "Patio Door":
                                                                            #region Patio Door

                                                                            aCommand.CommandText = "SELECT glass_tint, moving_door FROM patio_doors "
                                                                                            + "WHERE project_id = '" + project_id + "' AND linear_index = '" + aMod.LinearIndex + "' AND module_index = '" + moduleIndex + "'"; //change k to moduleIndex. Couldn't compile other pages.

                                                                            SqlDataReader patioReader = aCommand.ExecuteReader();

                                                                            if (patioReader.HasRows)
                                                                            {
                                                                                patioReader.Read();

                                                                                PatioDoor aPatioDoor = new PatioDoor();
                                                                                aPatioDoor.ModuleIndex = moduleIndex;
                                                                                aPatioDoor.ItemType = itemType;
                                                                                aPatioDoor.FStartHeight = fStartHeight;
                                                                                aPatioDoor.FEndHeight = fEndHeight;
                                                                                aPatioDoor.FLength = fLength;
                                                                                aPatioDoor.DoorType = doorType;
                                                                                aPatioDoor.DoorStyle = doorStyle;
                                                                                aPatioDoor.ScreenType = doorScreenType;
                                                                                aPatioDoor.Height = doorFrameHeight;
                                                                                aPatioDoor.Length = doorFrameLength;
                                                                                aPatioDoor.Colour = doorColour; //
                                                                                aPatioDoor.Kickplate = doorKickPlate; // 
                                                                                aPatioDoor.GlassTint = Convert.ToString(patioReader[0]);
                                                                                aPatioDoor.MovingDoor = Convert.ToString(patioReader[1]); ///this needs to be fixed, operator in db is bool and C# is string

                                                                                aPatioDoor.DoorWindow = aDoorWindow;

                                                                                listOfModuleItems.Add(aPatioDoor); //add the modular item to the list
                                                                            }
                                                                            patioReader.Close();

                                                                            #endregion
                                                                            break;
                                                                        case "No Door":
                                                                            #region No Door

                                                                            Door aDoor = new Door();
                                                                            aDoor.ModuleIndex = moduleIndex;
                                                                            aDoor.ItemType = itemType;
                                                                            aDoor.FStartHeight = fStartHeight;
                                                                            aDoor.FEndHeight = fEndHeight;
                                                                            aDoor.FLength = fLength;
                                                                            aDoor.DoorType = doorType;
                                                                            //aDoor.DoorStyle = doorStyle;
                                                                            //aDoor.ScreenType = doorScreenType;
                                                                            aDoor.Height = doorFrameHeight;
                                                                            aDoor.Length = doorFrameLength;
                                                                            //aDoor.Colour = doorColour; //
                                                                            //aDoor.Kickplate = doorKickPlate; // 

                                                                            listOfModuleItems.Add(aDoor); //add the modular item to the list

                                                                            //aReader.Close();

                                                                            #endregion
                                                                            break;
                                                                    }
                                                                }
                                                            }
                                                            doorReader.Close();
                                                            #endregion
                                                            break;
                                                        case "Box Header": // 
                                                            #region H BoxHeader
                                                            HBoxHeader hBoxHeader = new HBoxHeader();
                                                            hBoxHeader.ModuleIndex = moduleIndex;
                                                            hBoxHeader.ItemType = itemType;
                                                            hBoxHeader.FStartHeight = fStartHeight;
                                                            hBoxHeader.FEndHeight = fEndHeight;
                                                            hBoxHeader.FLength = fLength;

                                                            listOfModuleItems.Add(hBoxHeader); //add the modular item to the list
                                                            #endregion
                                                            break; // 
                                                        case "Receiver": // 
                                                            #region H Receiver
                                                            HReceiver hReceiver = new HReceiver();
                                                            hReceiver.ModuleIndex = moduleIndex;
                                                            hReceiver.ItemType = itemType;
                                                            hReceiver.FStartHeight = fStartHeight;
                                                            hReceiver.FEndHeight = fEndHeight;
                                                            hReceiver.FLength = fLength;

                                                            listOfModuleItems.Add(hReceiver); //add the modular item to the list
                                                            #endregion
                                                            break;
                                                        case "Panel": // same as open wall window
                                                            #region Solid Wall Window
                                                            Window solid = new Window();
                                                            solid.ModuleIndex = moduleIndex;
                                                            solid.ItemType = itemType;
                                                            solid.FStartHeight = fStartHeight;
                                                            solid.FEndHeight = fEndHeight;
                                                            solid.FLength = fLength;

                                                            listOfModuleItems.Add(solid); //add the modular item to the list
                                                            #endregion
                                                            break;
                                                    }
                                                    aMod.ModularItems = listOfModuleItems;
                                                }
                                                listOfLinearItems.Add(aMod);//add the linear item to the list
                                            }
                                            moduleItemReader.Close();
                                            #endregion
                                            break;
                                        case "Receiver":
                                            #region Receiver
                                            BoxHeader aBoxHeader = new BoxHeader();
                                            aBoxHeader.LinearIndex = linearIndex;
                                            aBoxHeader.ItemType = linearItemType;
                                            aBoxHeader.StartHeight = startHeight;
                                            aBoxHeader.EndHeight = endHeight;
                                            aBoxHeader.Length = length;
                                            aBoxHeader.FrameColour = frameColour;
                                            aBoxHeader.Sex = sex;
                                            aBoxHeader.FixedLocation = fixedLocation;
                                            aBoxHeader.AttachedTo = attachedTo;
                                            aBoxHeader.IsReceiver = true;
                                            aBoxHeader.IsTwoPiece = false;

                                            listOfLinearItems.Add(aBoxHeader);//add the linear item to the list
                                            #endregion
                                            break;
                                        case "2 Piece Receiver":
                                            #region 2 Piece Receiver
                                            aBoxHeader = new BoxHeader();
                                            aBoxHeader.LinearIndex = linearIndex;
                                            aBoxHeader.ItemType = linearItemType;
                                            aBoxHeader.StartHeight = startHeight;
                                            aBoxHeader.EndHeight = endHeight;
                                            aBoxHeader.Length = length;
                                            aBoxHeader.FrameColour = frameColour;
                                            aBoxHeader.Sex = sex;
                                            aBoxHeader.FixedLocation = fixedLocation;
                                            aBoxHeader.AttachedTo = attachedTo;
                                            aBoxHeader.IsReceiver = true;
                                            aBoxHeader.IsTwoPiece = true;

                                            listOfLinearItems.Add(aBoxHeader);//add the linear item to the list
                                            #endregion
                                            break;
                                        case "Box Header": // 
                                            #region Box Header
                                            aBoxHeader = new BoxHeader();
                                            aBoxHeader.LinearIndex = linearIndex;
                                            aBoxHeader.ItemType = linearItemType;
                                            aBoxHeader.StartHeight = startHeight;
                                            aBoxHeader.EndHeight = endHeight;
                                            aBoxHeader.Length = length;
                                            aBoxHeader.FrameColour = frameColour;
                                            aBoxHeader.Sex = sex;
                                            aBoxHeader.FixedLocation = fixedLocation;
                                            aBoxHeader.AttachedTo = attachedTo;
                                            aBoxHeader.IsReceiver = false;
                                            //aBoxHeader.IsTwoPiece = false;

                                            listOfLinearItems.Add(aBoxHeader);//add the linear item to the list
                                            #endregion
                                            break;
                                        case "Box Header Receiver": // 
                                            #region Box Header Receiver
                                            aBoxHeader = new BoxHeader();
                                            aBoxHeader.LinearIndex = linearIndex;
                                            aBoxHeader.ItemType = linearItemType;
                                            aBoxHeader.StartHeight = startHeight;
                                            aBoxHeader.EndHeight = endHeight;
                                            aBoxHeader.Length = length;
                                            aBoxHeader.FrameColour = frameColour;
                                            aBoxHeader.Sex = sex;
                                            aBoxHeader.FixedLocation = fixedLocation;
                                            aBoxHeader.AttachedTo = attachedTo;
                                            aBoxHeader.IsReceiver = true;
                                            //aBoxHeader.IsTwoPiece = false;

                                            listOfLinearItems.Add(aBoxHeader);//add the linear item to the list
                                            #endregion
                                            break;
                                        case "Filler":
                                            #region Filler
                                            Filler aFiller = new Filler();
                                            aFiller.LinearIndex = linearIndex;
                                            aFiller.ItemType = linearItemType;
                                            aFiller.StartHeight = startHeight;
                                            aFiller.EndHeight = endHeight;
                                            aFiller.Length = length;
                                            //aFiller.FrameColour = frameColour;
                                            aFiller.Sex = "MM";
                                            aFiller.FixedLocation = fixedLocation;
                                            aFiller.AttachedTo = attachedTo;

                                            listOfLinearItems.Add(aFiller);//add the linear item to the list
                                            #endregion
                                            break;
                                        case "Corner Post":
                                            #region Corner Post
                                            Corner aCorner = new Corner();
                                            aCorner.LinearIndex = linearIndex;
                                            aCorner.ItemType = linearItemType;
                                            aCorner.StartHeight = startHeight;
                                            aCorner.EndHeight = endHeight;
                                            aCorner.Length = length;
                                            aCorner.FrameColour = frameColour;
                                            aCorner.Sex = sex;
                                            aCorner.FixedLocation = fixedLocation;
                                            aCorner.AttachedTo = attachedTo;
                                            //aCorner.AngleIs90 = true; //hard coded, because I don't know where its coming from
                                            //aCorner.OutsideCorner = true; // hard coded because I don't know where its coming from

                                            listOfLinearItems.Add(aCorner); //add the linear item to the list
                                            #endregion
                                            break;
                                        case "Electrical Chase":
                                            #region ElectricalChase
                                            ElectricalChase aElectricalChase = new ElectricalChase();
                                            aElectricalChase.LinearIndex = linearIndex;
                                            aElectricalChase.ItemType = linearItemType;
                                            aElectricalChase.StartHeight = startHeight;
                                            aElectricalChase.EndHeight = endHeight;
                                            aElectricalChase.Length = length;
                                            //aElectricalChase.FrameColour = frameColour;
                                            aElectricalChase.Sex = "MM";
                                            aElectricalChase.FixedLocation = fixedLocation;
                                            aElectricalChase.AttachedTo = attachedTo;

                                            listOfLinearItems.Add(aElectricalChase);//add the linear item to the list
                                            #endregion
                                            break;
                                        case "H Channel":
                                            #region H Channel
                                            HChannel aHChannel = new HChannel();
                                            aHChannel.LinearIndex = linearIndex;
                                            aHChannel.ItemType = linearItemType;
                                            aHChannel.StartHeight = startHeight;
                                            aHChannel.EndHeight = endHeight;
                                            aHChannel.Length = length;
                                            aHChannel.FrameColour = frameColour;
                                            aHChannel.Sex = sex;
                                            aHChannel.FixedLocation = fixedLocation;
                                            aHChannel.AttachedTo = attachedTo;

                                            listOfLinearItems.Add(aHChannel);//add the linear item to the list
                                            #endregion
                                            break;
                                    }
                                }

                                aWall.LinearItems = listOfLinearItems;

                                listOfWalls.Add(aWall); //add the wall to the list
                            }
                            listItemReader.Close();

                        }
                    }
                    wallReader.Close();
                    #endregion 

                    #region floors
                    if (floorCount != 0)
                    {

                    }
                    #endregion

                    #region roofs
                    //if there is a roof in the project

                    if (roofCount != 0)
                    {
                        aCommand.CommandText = "SELECT roof_type, interior_skin, exterior_skin, thickness, fire_protection, thermadeck, acrylic, gutter, gutter_pro, gutter_colour, number_supports, stripe_colour, projection, width, roof_index "
                                + "FROM roofs WHERE project_id = '" + project_id + "'";

                        SqlDataReader roofReader = aCommand.ExecuteReader();

                        if (roofReader.HasRows)
                        {
                            while (roofReader.Read())
                            {

                                //create a new instance of a wall and set all its attributes from the db
                                aRoof = new Roof();
                                aRoof.Type = Convert.ToString(aReader[0]);
                                aRoof.InteriorSkin = Convert.ToString(aReader[1]);
                                aRoof.ExteriorSkin = Convert.ToString(aReader[2]);
                                aRoof.Thickness = Convert.ToDouble(aReader[3]);
                                aRoof.FireProtection = Convert.ToBoolean(aReader[4]);
                                aRoof.Thermadeck = Convert.ToBoolean(aReader[5]);
                                aRoof.Acrylic = Convert.ToBoolean(aReader[6]);
                                aRoof.Gutters = Convert.ToBoolean(aReader[7]);
                                aRoof.GutterPro = Convert.ToBoolean(aReader[8]);
                                aRoof.GutterColour = Convert.ToString(aReader[9]);
                                aRoof.NumberSupports = Convert.ToInt32(aReader[10]);
                                aRoof.StripeColour = Convert.ToString(aReader[11]);
                                aRoof.Projection = Convert.ToDouble(aReader[12]); //how do we deal with obstructions
                                aRoof.Width = Convert.ToDouble(aReader[13]);
                                int roofIndex = Convert.ToInt32(aReader[14]);

                                List<RoofModule> listOfRoofModules = new List<RoofModule>();

                                aCommand.CommandText = "SELECT projection, width, interior_skin, exterior_skin, roof_view "
                                + "FROM roof_modules WHERE project_id = '" + project_id + "' AND roof_index = '" + roofIndex + "'";

                                SqlDataReader moduleReader = aCommand.ExecuteReader();

                                if (moduleReader.HasRows)
                                {
                                    while (moduleReader.Read())
                                    {
                                        RoofModule aModule = new RoofModule();
                                        aModule.Projection = Convert.ToDouble(aReader[0]);
                                        aModule.Width = Convert.ToDouble(aReader[1]);
                                        aModule.InteriorSkin = Convert.ToString(aReader[2]);
                                        aModule.ExteriorSkin = Convert.ToString(aReader[3]);
                                        int roofView = Convert.ToInt32(aReader[4]);

                                        List<RoofItem> listOfRoofItems = new List<RoofItem>();

                                        aCommand.CommandText = "SELECT roof_item, projection, width, item_index "
                                        + "FROM roof_modules WHERE project_id = '" + project_id + "' AND roof_index = '" + roofIndex + "' AND roof_view = '" + roofView + "'";

                                        SqlDataReader itemReader = aCommand.ExecuteReader();

                                        if (itemReader.HasRows)
                                        {
                                            while(itemReader.Read())
                                            {
                                                // store in an object
                                                RoofItem aRoofItem = new RoofItem();
                                                aRoofItem.ItemType = Convert.ToString(aReader[0]);
                                                aRoofItem.Projection = Convert.ToSingle(aReader[1]);
                                                aRoofItem.Width = Convert.ToSingle(aReader[2]);
                                                int itemIndex = Convert.ToInt32(aReader[3]);
                                                
                                                ///different types of roof items
                                                switch (aRoofItem.ItemType)
                                                {
                                                    case "Receiver": //no class.. what to do .. same as panel receiver? 
                                                        break;
                                                    case "Awning Track": //no class.. what to do
                                                        break;
                                                    case "I-Beam": //no class.. what to do
                                                        break;
                                                    case "Pressure Cap I-Beam": //no class.. what to do
                                                        break;
                                                    case "T-Bar": //no class.. what to do
                                                        break;
                                                    case "Acrylic Panel": //no class.. no class ... where is colour, width, setback, projection being stored?
                                                        break;
                                                    case "Foam Panel": //no class ... where is colour, width, setback, projection being stored?
                                                        //accordding the to db, this is the only item in which you can have fanbeams and skylight
                                                        //check for skylight in this roof item

                                                        //are all skylights the same? length/width etc? .. 
                                                        //there is no skylight object.. roof item should have a attribute for a skylight object

                                                        aCommand.CommandText = "SELECT skylight_type, set_back, operator "
                                                        + "FROM skylights WHERE project_id = '" + project_id + "' AND roof_index = '" + roofIndex + "' AND roof_view = '" + roofView + "' AND item_index '" + itemIndex + "'";

                                                        SqlDataReader skylightReader = aCommand.ExecuteReader();

                                                        if (skylightReader.HasRows)
                                                        {
                                                            while (skylightReader.Read())
                                                            {
                                                                //Skylight aSkylight = new Skylight(); //create object and set attribute if required
                                                                aRoofItem.SkyLight = Convert.ToSingle(skylightReader[1]);
                                                            }

                                                        }
                                                        else
                                                        {
                                                            aRoofItem.SkyLight = -1;
                                                        }
                                                        skylightReader.Close();


                                                        //check for fanbeams in this roof item
                                                        //no info in the db or in C#
                                                        aCommand.CommandText = "SELECT skylight_type, set_back, operator "
                                                        + "FROM fanbeams WHERE project_id = '" + project_id + "' AND roof_index = '" + roofIndex + "' AND roof_view = '" + roofView + "' AND item_index = '" + itemIndex + "'";

                                                        SqlDataReader fanbeamReader = aCommand.ExecuteReader();

                                                        if (fanbeamReader.HasRows)
                                                        {
                                                            while (fanbeamReader.Read())
                                                            {
                                                                //Skylight aSkylight = new Skylight(); //create object and set attribute if required
                                                                aRoofItem.FanBeam = Convert.ToSingle(skylightReader[1]);
                                                            }

                                                        }
                                                        else
                                                        {
                                                            aRoofItem.FanBeam = -1;
                                                        }
                                                        fanbeamReader.Close();
                                                        break;
                                                }

                                                listOfRoofItems.Add(aRoofItem);
                                            }
                                        }

                                        itemReader.Close();

                                        aModule.RoofItems = listOfRoofItems;

                                        listOfRoofModules.Add(aModule);
                                    }
                                }
                                moduleReader.Close();

                                aRoof.RoofModules = listOfRoofModules;
                            }
                        }
                        roofReader.Close();
                    }
                    
                    #endregion


                    aTransaction.Commit();

                    hidJsonObjects.Value = JsonConvert.SerializeObject(listOfWalls);
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
                         //This catch block will handle any errors that may have occurred 
                         //on the server that would cause the rollback to fail, such as 
                         //a closed connection.
                        //lblError.Text = "Rollback Exception Type: " + ex2.GetType();
                        //lblError.Text += "  Message: " + ex2.Message;
                    }
                }
            }
        }
    }
}
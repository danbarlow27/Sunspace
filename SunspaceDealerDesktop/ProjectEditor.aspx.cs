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
        protected int projectId = 88; //82 84 86 87 88 89 97 get it from the session (project_id)

        protected void Page_Load(object sender, EventArgs e)
        {
            //projectId = Convert.ToInt32(Session["project_id"].ToString());
            #region commented out hard coded data
            /*
            #region hard coded data
            #region wall 1
            Wall wall1 = new Wall();
            wall1.WallType = "Proposed";
            wall1.ModelType = "M200";
            wall1.Length = 60f;
            wall1.Orientation = "W";
            wall1.SetBack = 60f;
            wall1.Name = "Left Wall";
            wall1.FirstItemIndex = 0;
            wall1.LastItemIndex = 4;
            wall1.StartHeight = 84f;
            wall1.EndHeight = 78f;
            wall1.SoffitLength = 0f;
            wall1.GablePeak = 0f;
            wall1.FireProtection = false;
            //int wall1Index = 0;

            List<LinearItem> list1OfLinearItems = new List<LinearItem>();

            #region li1
            Corner aCorner2 = new Corner();
            aCorner2.LinearIndex = 0;
            aCorner2.ItemType = "Starter Post";
            aCorner2.StartHeight = 84f;
            aCorner2.EndHeight = 83.8f;
            aCorner2.Length = 2f;
            aCorner2.FrameColour = "White";
            aCorner2.Sex = "F";
            aCorner2.FixedLocation = 0f;
            aCorner2.AttachedTo = true;

            list1OfLinearItems.Add(aCorner2); //add the linear item to the list
            #endregion
            #region li2
            Filler aFiller2 = new Filler();
            aFiller2.LinearIndex = 1;
            aFiller2.ItemType = "Filler";
            aFiller2.StartHeight = 83.8f;
            aFiller2.EndHeight = 83.6f;
            aFiller2.Length = 2f;
            aFiller2.Sex = "MM";
            aFiller2.FixedLocation = 2f;
            aFiller2.AttachedTo = false;

            list1OfLinearItems.Add(aFiller2);//add the linear item to the list
            #endregion
            #region li3
            List<ModuleItem> list1OfModuleItems = new List<ModuleItem>();

            Mod aMod5 = new Mod();

            aMod5.LinearIndex = 2;
            aMod5.ItemType = "Mod";
            aMod5.StartHeight = 83.6f;
            aMod5.EndHeight = 78.4f;
            aMod5.Length = 52f;
            aMod5.FrameColour = "White";
            aMod5.Sex = "MF";
            aMod5.FixedLocation = 4f;
            aMod5.AttachedTo = false;

            #region mod1
            Window kneewall = new Window();
            kneewall.ModuleIndex = 0;
            kneewall.ItemType = "Panel";
            kneewall.FStartHeight = 0f;
            kneewall.FEndHeight = 10f;
            kneewall.FLength = 50f;
            kneewall.WindowStyle = "Solid";
            kneewall.ScreenType = "No Screen";
            kneewall.LeftHeight = 8f;
            kneewall.RightHeight = 8f;
            kneewall.Width = 48f;
            kneewall.FrameColour = "White"; //
            kneewall.NumVents = 0;

            list1OfModuleItems.Add(kneewall); //add the modular item to the list
            #endregion 
            #region mod2
            VinylWindow aVinylWindow5 = new VinylWindow();
            aVinylWindow5.ModuleIndex = 1;
            aVinylWindow5.ItemType = "Window";
            aVinylWindow5.FStartHeight = 10f;
            aVinylWindow5.FEndHeight = 70.5f;
            aVinylWindow5.FLength = 50f;
            //aVinylWindow.Colour = windowColour; //replaced by FrameColour
            aVinylWindow5.WindowStyle = "V4T";
            aVinylWindow5.ScreenType = "Better Vue Insect Screen";
            aVinylWindow5.LeftHeight = 58.5f;
            aVinylWindow5.RightHeight = 58.5f;
            aVinylWindow5.Width = 48f;
            aVinylWindow5.FrameColour = "White"; //
            aVinylWindow5.VinylTint = "CBGC"; // tint of each vent will be concatenated
            aVinylWindow5.NumVents = 4;

            List<float> list5OfVentHeights = new List<float>();
            list5OfVentHeights.Add(15.125f);
            list5OfVentHeights.Add(15.125f);
            list5OfVentHeights.Add(15.125f);
            list5OfVentHeights.Add(15.125f);
            aVinylWindow5.VentHeights = list5OfVentHeights;

            list1OfModuleItems.Add(aVinylWindow5);
            #endregion
            #region mod3
            Window transom = new Window();
            transom.ModuleIndex = 2;
            transom.ItemType = "Panel";
            transom.FStartHeight = 70.5f;
            transom.FEndHeight = 82.8f;
            transom.FLength = 50f;
            transom.WindowStyle = "Solid";
            transom.ScreenType = "No Screen";
            transom.LeftHeight = 10.3f;
            transom.RightHeight = 6.2f;
            transom.Width = 48f;
            transom.FrameColour = "White"; //
            transom.NumVents = 0;

            list1OfModuleItems.Add(transom); //add the modular item to the list
            #endregion
            aMod5.ModularItems = list1OfModuleItems;
            list1OfLinearItems.Add(aMod5);
            #endregion
            #region li4
            aFiller2 = new Filler();
            aFiller2.LinearIndex = 3;
            aFiller2.ItemType = "Filler";
            aFiller2.StartHeight = 78.4f;
            aFiller2.EndHeight = 78.2f;
            aFiller2.Length = 2f;
            aFiller2.Sex = "MM";
            aFiller2.FixedLocation = -1f;
            aFiller2.AttachedTo = false;

            list1OfLinearItems.Add(aFiller2);//add the linear item to the list
            #endregion
            #region li5
            aCorner2 = new Corner();
            aCorner2.LinearIndex = 4;
            aCorner2.ItemType = "Corner Post";
            aCorner2.StartHeight = 78.2f;
            aCorner2.EndHeight = 78f;
            aCorner2.Length = 2f;
            aCorner2.FrameColour = "White";
            aCorner2.Sex = "F";
            aCorner2.FixedLocation = 52f;
            aCorner2.AttachedTo = true;

            list1OfLinearItems.Add(aCorner2); //add the linear item to the list                 
            #endregion
            wall1.LinearItems = list1OfLinearItems;
            listOfWalls.Add(wall1); //add the wall to the list
            #endregion
            
            #region wall 2
            Wall wall2 = new Wall();
            wall2.WallType = "Proposed";
            wall2.ModelType = "M200";
            wall2.Length = 86f;
            wall2.Orientation = "S";
            wall2.SetBack = 0f;
            wall2.Name = "Front Wall";
            wall2.FirstItemIndex = 4;
            wall2.LastItemIndex = 9;
            wall2.StartHeight = 78f;
            wall2.EndHeight = 78f;
            wall2.SoffitLength = 0f;
            wall2.GablePeak = 0f;
            wall2.FireProtection = false;
            //int wall2Index = 1;

            List<LinearItem> list2OfLinearItems = new List<LinearItem>();

            #region li1
            aFiller2 = new Filler();
            aFiller2.LinearIndex = 5;
            aFiller2.ItemType = "Filler";
            aFiller2.StartHeight = 78;
            aFiller2.EndHeight = 78f;
            aFiller2.Length = 2f;
            aFiller2.Sex = "MM";
            aFiller2.FixedLocation = 2f;
            aFiller2.AttachedTo = false;

            list2OfLinearItems.Add(aFiller2);//add the linear item to the list
            #endregion
            #region li2
            List<ModuleItem> list2OfModuleItems = new List<ModuleItem>();

            Mod aMod2 = new Mod();

            aMod2.LinearIndex = 6;
            aMod2.ItemType = "Window";
            aMod2.StartHeight = 78f;
            aMod2.EndHeight = 78f;
            aMod2.Length = 52f;
            aMod2.FrameColour = "White";
            aMod2.Sex = "MF";
            aMod2.FixedLocation = 4f;
            aMod2.AttachedTo = false;

            #region mod1
            Window kneewall2 = new Window();
            kneewall2.ModuleIndex = 0;
            kneewall2.ItemType = "Panel";
            kneewall2.FStartHeight = 0f;
            kneewall2.FEndHeight = 10f;
            kneewall2.FLength = 52f;
            kneewall2.WindowStyle = "Solid";
            kneewall2.ScreenType = "No Screen";
            kneewall2.LeftHeight = 8f;
            kneewall2.RightHeight = 8f;
            kneewall2.Width = 50f;
            kneewall2.FrameColour = "White"; //
            kneewall2.NumVents = 0;

            list2OfModuleItems.Add(kneewall); //add the modular item to the list
            #endregion 
            #region mod2
            VinylWindow aVinylWindow2 = new VinylWindow();
            aVinylWindow2.ModuleIndex = 1;
            aVinylWindow2.ItemType = "Window";
            aVinylWindow2.FStartHeight = 10f;
            aVinylWindow2.FEndHeight = 70.5f;
            aVinylWindow2.FLength = 52f;
            //aVinylWindow.Colour = windowColour; //replaced by FrameColour
            aVinylWindow2.WindowStyle = "V4T";
            aVinylWindow2.ScreenType = "Better Vue Insect Screen";
            aVinylWindow2.LeftHeight = 58.5f;
            aVinylWindow2.RightHeight = 58.5f;
            aVinylWindow2.Width = 50f;
            aVinylWindow2.FrameColour = "White"; //
            aVinylWindow2.VinylTint = "CBGC"; // tint of each vent will be concatenated
            aVinylWindow2.NumVents = 4;

            List<float> list2OfVentHeights = new List<float>();
            list2OfVentHeights.Add(15.125f);
            list2OfVentHeights.Add(15.125f);
            list2OfVentHeights.Add(15.125f);
            list2OfVentHeights.Add(15.125f);
            aVinylWindow2.VentHeights = list2OfVentHeights;

            list2OfModuleItems.Add(aVinylWindow2);
            #endregion
            #region mod3
            Window transom2 = new Window();
            transom2.ModuleIndex = 3;
            transom2.ItemType = "Panel";
            transom2.FStartHeight = 7.5f;
            transom2.FEndHeight = 7.5f;
            transom2.FLength = 52f;
            transom2.WindowStyle = "Solid";
            transom2.ScreenType = "No Screen";
            transom2.LeftHeight = 7.5f;
            transom2.RightHeight = 7.5f;
            transom2.Width = 50f;
            transom2.FrameColour = "White"; //
            transom2.NumVents = 0;

            list2OfModuleItems.Add(transom2); //add the modular item to the list
            #endregion

            aMod2.ModularItems = list2OfModuleItems;
            list2OfLinearItems.Add(aMod2);
            #endregion
            #region li3
            List<ModuleItem> list3OfModuleItems = new List<ModuleItem>();

            aMod2 = new Mod();

            aMod2.LinearIndex = 7;
            aMod2.ItemType = "Door";
            aMod2.StartHeight = 78f;
            aMod2.EndHeight = 78f;
            aMod2.Length = 28f;
            aMod2.FrameColour = "White";
            aMod2.Sex = "MF";
            aMod2.FixedLocation = 4f;
            aMod2.AttachedTo = false;
            #region mod1
            Window aDoorWindow1 = new Window();
            aDoorWindow1.WindowStyle = "Glass";
            aDoorWindow1.ScreenType = "No Screen";
            aDoorWindow1.LeftHeight = 24f;
            aDoorWindow1.RightHeight = 24f;
            aDoorWindow1.Width = 22f;
            aDoorWindow1.FrameColour = "White";
            aDoorWindow1.NumVents = 0;



            CabanaDoor aCabanaDoor1 = new CabanaDoor();
            aCabanaDoor1.ModuleIndex = 0;
            aCabanaDoor1.ItemType = "Door";
            aCabanaDoor1.FStartHeight = 0f;
            aCabanaDoor1.FEndHeight = 62f;
            aCabanaDoor1.FLength = 26f;
            aCabanaDoor1.DoorType = "Cabana Door";
            aCabanaDoor1.DoorStyle = "Half Lite";
            aCabanaDoor1.ScreenType = "No Screen";
            aCabanaDoor1.Height = 60f;
            aCabanaDoor1.Length = 24;
            aCabanaDoor1.Colour = "White"; //
            aCabanaDoor1.Kickplate = 10f; //
            aCabanaDoor1.GlassTint = "Grey";
            aCabanaDoor1.Hinge = "Left";
            aCabanaDoor1.Swing = "Out";
            aCabanaDoor1.HardwareType = "Satin Silver";

            aCabanaDoor1.DoorWindow = aDoorWindow1;

            list3OfModuleItems.Add(aCabanaDoor1); //add the modular item to the list
            #endregion
            #region mod1
            transom2 = new Window();
            transom2.ModuleIndex = 1;
            transom2.ItemType = "Panel";
            transom2.FStartHeight = 62f;
            transom2.FEndHeight = 78f;
            transom2.FLength = 26f;
            transom2.WindowStyle = "Solid";
            transom2.ScreenType = "No Screen";
            transom2.LeftHeight = 16f;
            transom2.RightHeight = 16f;
            transom2.Width = 24f;
            transom2.FrameColour = "White"; //
            transom2.NumVents = 0;

            list3OfModuleItems.Add(transom2); //add the modular item to the list
            #endregion
            aMod2.ModularItems = list3OfModuleItems;
            list2OfLinearItems.Add(aMod2);
            #endregion
            #region li4
            aFiller2 = new Filler();
            aFiller2.LinearIndex = 8;
            aFiller2.ItemType = "Filler";
            aFiller2.StartHeight = 78f;
            aFiller2.EndHeight = 78f;
            aFiller2.Length = 2f;
            aFiller2.Sex = "MM";
            aFiller2.FixedLocation = 82f;
            aFiller2.AttachedTo = true;

            list2OfLinearItems.Add(aFiller2);//add the linear item to the list
            #endregion
            #region li5
            aCorner2 = new Corner();
            aCorner2.LinearIndex = 9;
            aCorner2.ItemType = "Corner Post";
            aCorner2.StartHeight = 78f;
            aCorner2.EndHeight = 78f;
            aCorner2.Length = 2f;
            aCorner2.FrameColour = "White";
            aCorner2.Sex = "F";
            aCorner2.FixedLocation = 84f;
            aCorner2.AttachedTo = false;

            list2OfLinearItems.Add(aCorner2); //add the linear item to the list                 
            #endregion
            wall2.LinearItems = list2OfLinearItems;
            listOfWalls.Add(wall2); //add the wall to the list
            #endregion

            #region wall 3
            Wall wall3 = new Wall();
            wall3.WallType = "Proposed";
            wall3.ModelType = "M200";
            wall3.Length = 60f;
            wall3.Orientation = "E";
            wall3.SetBack = 60f;
            wall3.Name = "Right Wall";
            wall3.FirstItemIndex = 9;
            wall3.LastItemIndex = 13;
            wall3.StartHeight = 78f;
            wall3.EndHeight = 84f;
            wall3.SoffitLength = 0f;
            wall3.GablePeak = 0f;
            wall3.FireProtection = false;
            //int wall1Index = 0;

            listOfWalls.Add(wall3); //add the wall to the list
            #endregion

            #endregion
            */
#endregion
            #region hit the DB

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
                    aCommand.CommandText = "SELECT number_walls, number_floors, number_roofs FROM sunrooms WHERE project_id = '" + projectId + "'";
                    aReader = aCommand.ExecuteReader();

                    if (aReader.HasRows)
                    {
                        aReader.Read();

                        wallCount = Convert.ToInt32(aReader[0]);
                        floorCount = Convert.ToInt32(aReader[1]);
                        roofCount = Convert.ToInt32(aReader[2]);
                    }
                    aReader.Close(); 

                    #region walls
                    //for each wall in the project
                    
                    //aCommand.CommandText = "SELECT wall_type, model_type, total_length, orientation, set_back, name, first_item_index, last_item_index, start_height, end_height, soffit_length, gable_peak, obstructions, fire_protection, wall_index "
                    //    + "FROM walls WHERE project_id = '" + projectId + "'";

                    //SqlDataReader wallReader = aCommand.ExecuteReader();

                    //if (wallReader.HasRows)
                    //{
                    //    while (wallReader.Read())
                    for (int i = 0; i < wallCount; i++)
                    {
                            aCommand.CommandText = "SELECT wall_type, model_type, total_length, orientation, set_back, name, first_item_index, last_item_index, start_height, end_height, soffit_length, gable_peak, obstructions, fire_protection, wall_index "
                            + "FROM walls WHERE project_id = '" + projectId + "' AND wall_index = '" + i + "'";

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
                            aWall.FireProtection = Convert.ToBoolean(aReader[13]);
                            int wallIndex = Convert.ToInt32(aReader[14]);

                            aReader.Close();

                            List<LinearItem> listOfLinearItems = new List<LinearItem>();

                            //Get linear items
                            //aCommand.CommandText = "SELECT linear_index, linear_type, start_height, end_height, length, frame_colour, sex, fixed_location, attached_to "
                            //                        + "FROM linear_items WHERE project_id = '" + projectId + "' AND last_item_index < '" + aWall.LastItemIndex + "' AND first_item_index > '" + aWall.FirstItemIndex + "'";
                            //aReader = aCommand.ExecuteReader();

                            //for each linear item/mod in the wall
                            
                            //if (linearItemReader.HasRows)
                            //{
                            //    while (linearItemReader.Read())
                            //    {
                        for (int j = aWall.FirstItemIndex; j < aWall.LastItemIndex; j++)
                        {
                                    //Get linear items
                                    aCommand.CommandText = "SELECT linear_index, linear_type, start_height, end_height, length, frame_colour, sex, fixed_location, attached_to "
                                                            + "FROM linear_items WHERE project_id = '" + projectId + "' AND linear_index = '" + j + "'";
                                    aReader = aCommand.ExecuteReader();
                                    aReader.Read();


                                    int linearIndex = Convert.ToInt32(aReader[0]);
                                    string linearItemType = Convert.ToString(aReader[1]);
                                    float startHeight = Convert.ToSingle(aReader[2]);
                                    float endHeight = Convert.ToSingle(aReader[3]);
                                    float length = Convert.ToSingle(aReader[4]);
                                    string frameColour = Convert.ToString(aReader[5]);
                                    string sex = Convert.ToString(aReader[6]);
                                    float fixedLocation = Convert.ToSingle(aReader[7]);
                                    bool attachedTo = Convert.ToBoolean(aReader[8]);

                                    aReader.Close();

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
                                            aCommand.CommandText = "SELECT COUNT(*) FROM module_items WHERE project_id = '" + projectId + "' "
                                                                                    + " AND linear_index = '" + aMod.LinearIndex + "'";
                                            aReader = aCommand.ExecuteReader();
                                            aReader.Read();
                                            int modCount = Convert.ToInt32(aReader[0]); //get the number of walls in the project

                                            aReader.Close();

                                            //aCommand.CommandText = "SELECT module_index, item_type, start_height, end_height, length FROM moduleItems "
                                            //                    + "WHERE project_id = '" + projectId + "' AND linear_index = '" + aMod.LinearIndex + "'";

                                            //SqlDataReader moduleItemReader = aCommand.ExecuteReader();

                                            //for each modular item in the mod
                                            
                                            //if (moduleItemReader.HasRows)
                                            //{
                                            //    while (moduleItemReader.Read())
                                            for (int k = 0; k < modCount; k++)
                                            {
                                                    //Get module items
                                                     aCommand.CommandText = "SELECT module_index, item_type, start_height, end_height, length FROM module_items "
                                                                    + "WHERE project_id = '" + projectId + "' AND linear_index = '" + aMod.LinearIndex + "' AND module_index = '" + k + "'";

                                                    aReader = aCommand.ExecuteReader();
                                                    aReader.Read();

                                                    int moduleIndex = Convert.ToInt32(aReader[0]);
                                                    string itemType = Convert.ToString(aReader[1]);
                                                    float fStartHeight = Convert.ToSingle(aReader[2]);
                                                    float fEndHeight = Convert.ToSingle(aReader[3]);
                                                    float fLength = Convert.ToSingle(aReader[4]);

                                                    aReader.Close();


                                                    //different types of mods 
                                                    switch (itemType)
                                                    {
                                                        case "Kneewall":
                                                        case "Window":
                                                            #region Window
                                                            //Get window
                                                            aCommand.CommandText = "SELECT window_type, screen_type, start_height, end_height, length, window_colour, number_vents FROM windows "
                                                                                    + "WHERE project_id = '" + projectId + "' AND linear_index = '" + aMod.LinearIndex + "' AND module_index = '" + moduleIndex + "'";

                                                            aReader = aCommand.ExecuteReader();

                                                            //if (windowReader.HasRows)
                                                            //{
                                                                aReader.Read();

                                                                string windowStyle = Convert.ToString(aReader[0]);
                                                                string screenType = Convert.ToString(aReader[1]);
                                                                float windowStartHeight = Convert.ToSingle(aReader[2]);
                                                                float windowEndHeight = Convert.ToSingle(aReader[3]);
                                                                float windowLength = Convert.ToSingle(aReader[4]);
                                                                string windowColour = Convert.ToString(aReader[5]);
                                                                int numVents = Convert.ToInt32(aReader[6]); 

                                                                aReader.Close();

                                                                //types of windows
                                                                switch (windowStyle)
                                                                {
                                                                    case "Double Slider": //glass model 300
                                                                    case "Single Slider": //glass model 400
                                                                    case "Horizontal Roller XX": //glass model 300
                                                                    case "Horizontal Roller":
                                                                    case "Horizontal 2 Track":
                                                                    case "H2T":
                                                                    case "Vertical 4 Track":
                                                                    case "Vertical Four Track":
                                                                    case "V4T":
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
                                                                        //numVents = (numVents == 0) ? 1 : numVents;
                                                                        aVinylWindow.NumVents = numVents;
                                                                        List<float> listOfVentHeights = new List<float>();

                                                                        //Get vinyl item
                                                                        //aCommand.CommandText = "SELECT start_height, vinyl_tint, spreader_bar FROM vinyl_items "
                                                                        //                        + "WHERE project_id = '" + projectId + "' AND linear_index = '" + aMod.LinearIndex + "' AND module_index = '" + moduleIndex + "'";

                                                                        //aReader = aCommand.ExecuteReader();

                                                                        //if (vinylReader.HasRows)
                                                                        //{
                                                                            //while (vinylReader.Read())
                                                                            //for each vinyl item in the in the vinyl window
                                                                            for (int l = 0; l < numVents; l++)
                                                                            {
                                                                                aCommand.CommandText = "SELECT start_height, vinyl_tint, spreader_bar FROM vinyl_items "
                                                                                                + "WHERE project_id = '" + projectId + "' AND linear_index = '" + aMod.LinearIndex + "' AND module_index = '" + moduleIndex + "' AND vent_index = '" + l + "'";

                                                                        aReader = aCommand.ExecuteReader();
                                                                        aReader.Read();

                                                                                listOfVentHeights.Add(Convert.ToSingle(aReader[0]));
                                                                                aVinylWindow.VinylTint += Convert.ToString(aReader[1]);
                                                                                aVinylWindow.SpreaderBar = Convert.ToSingle(aReader[2]);

                                                                        aReader.Close();
                                                                            }
                                                                        
                                                                        //vinylReader.Close();

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
                                                                    case "Fixed Glass 2\"":
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
                                                                        //aCommand.CommandText = "SELECT glass_type, glass_tint, tempered, operation FROM glass_items "
                                                                        //                        + "WHERE project_id = '" + projectId + "' AND linear_index = '" + aMod.LinearIndex + "' AND module_index = '" + moduleIndex + "'";

                                                                        //SqlDataReader glassReader = aCommand.ExecuteReader();

                                                                        for (int l = 0; l < numVents; l++)
                                                                        {
                                                                        //if (glassReader.HasRows)
                                                                        //{
                                                                        //    while (glassReader.Read())
                                                                        //    {

                                                                             aCommand.CommandText = "SELECT glass_type, glass_tint, tempered, operation FROM glass_items "
                                                                                                + "WHERE project_id = '" + projectId + "' AND linear_index = '" + aMod.LinearIndex + "' AND module_index = '" + moduleIndex + "' AND vent_index = '" + l + "'";

                                                                            aReader = aCommand.ExecuteReader();
                                                                            aReader.Read();
                                                                                aGlassWindow.GlassType = Convert.ToString(aReader[0]);
                                                                                aGlassWindow.GlassTint += Convert.ToString(aReader[1]);
                                                                                aGlassWindow.Tempered = Convert.ToBoolean(aReader[2]);
                                                                                aGlassWindow.Operation += Convert.ToString(aReader[3]);

                                                                            aReader.Close();
                                                                            }
                                                                        
                                                                        //glassReader.Close();

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
                                                                        openWindow.WindowStyle = windowStyle;
                                                                        openWindow.ScreenType = screenType;
                                                                        openWindow.LeftHeight = windowStartHeight;
                                                                        openWindow.RightHeight = windowEndHeight;
                                                                        openWindow.Width = windowLength;
                                                                        openWindow.FrameColour = windowColour;
                                                               

                                                                        listOfModuleItems.Add(openWindow); //add the modular item to the list
                                                                        #endregion
                                                                        break;
                                                                    case "Panel":
                                                                    case "Solid Wall":
                                                                        #region Open Window
                                                                        Window panel = new Window();
                                                                        panel.ModuleIndex = moduleIndex;
                                                                        panel.ItemType = itemType;
                                                                        panel.FStartHeight = fStartHeight;
                                                                        panel.FEndHeight = fEndHeight;
                                                                        panel.FLength = fLength;
                                                                        panel.WindowStyle = windowStyle;
                                                                        panel.ScreenType = screenType;
                                                                        panel.LeftHeight = windowStartHeight;
                                                                        panel.RightHeight = windowEndHeight;
                                                                        panel.Width = windowLength;
                                                                        panel.FrameColour = windowColour;

                                                                        listOfModuleItems.Add(panel); //add the modular item to the list
                                                                        #endregion
                                                                        break;
                                                                }
                                                            
                                                            //windowReader.Close();
                                                            #endregion
                                                            break;
                                                        case "Door":
                                                            #region Door
                                                            //Get door
                                                            //aCommand.CommandText = "SELECT door_type, door_style, screen_type, height, length, door_colour, kick_plate FROM doors "
                                                            //                        + "WHERE project_id = '" + projectId + "' AND linear_index = '" + aMod.LinearIndex + "' AND module_index = '" + moduleIndex + "'";

                                                            //SqlDataReader doorReader = aCommand.ExecuteReader();

                                                            //if (doorReader.HasRows)
                                                            //{
                                                            //    while (doorReader.Read())
                                                                
                                                                    aCommand.CommandText = "SELECT door_type, door_style, screen_type, height, length, door_colour, kick_plate FROM doors "
                                                                                    + "WHERE project_id = '" + projectId + "' AND linear_index = '" + aMod.LinearIndex + "' AND module_index = '" + moduleIndex + "'";

                                                                    aReader = aCommand.ExecuteReader();
                                                                    aReader.Read();

                                                                    string doorType = Convert.ToString(aReader[0]);
                                                                    string doorStyle = Convert.ToString(aReader[1]);
                                                                    string doorScreenType = Convert.ToString(aReader[2]);
                                                                    float doorFrameHeight = Convert.ToSingle(aReader[3]);
                                                                    float doorFrameLength = Convert.ToSingle(aReader[4]);
                                                                    string doorColour = Convert.ToString(aReader[5]);
                                                                    float doorKickPlate = Convert.ToSingle(aReader[6]);
                                                                
                                                                    aReader.Close();

                                                                    //get the window in this door
                                                                    aCommand.CommandText = "SELECT door_index, window_type, screen_type, start_height, end_height, length, window_colour, number_vents FROM windows "
                                                                                            + "WHERE project_id = '" + projectId + "' AND linear_index = '" + aMod.LinearIndex + "' AND module_index = '" + moduleIndex + "'";

                                                                    aReader = aCommand.ExecuteReader();

                                                                    VinylWindow aDoorWindow = new VinylWindow();

                                                                    if (aReader.HasRows)
                                                                    {
                                                                        while (aReader.Read())
                                                                        {
                                                                            //int doorIndex = Convert.ToInt32(aReader[0]);
                                                                            aDoorWindow.WindowStyle = Convert.ToString(aReader[1]);
                                                                            aDoorWindow.ScreenType = Convert.ToString(aReader[2]);
                                                                            aDoorWindow.LeftHeight = Convert.ToSingle(aReader[3]);
                                                                            aDoorWindow.RightHeight = Convert.ToSingle(aReader[4]);
                                                                            aDoorWindow.Width = Convert.ToSingle(aReader[5]);
                                                                            aDoorWindow.FrameColour = Convert.ToString(aReader[6]);
                                                                            aDoorWindow.NumVents = Convert.ToInt32(aReader[7]);
                                                                        }
                                                                    }
                                                                    aReader.Close();

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
                                                                                                    + "WHERE project_id = '" + projectId + "' AND linear_index = '" + aMod.LinearIndex + "' AND module_index = '" + moduleIndex + "'";

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
                                                                        case "Cabana":
                                                                        case "Cabana Door":
                                                                            #region Cabana Door

                                                                            aCommand.CommandText = "SELECT glass_tint, hinge, swing, hardware_type, screen_type FROM cabana_doors "
                                                                                            + "WHERE project_id = '" + projectId + "' AND linear_index = '" + aMod.LinearIndex + "' AND module_index = '" + moduleIndex + "'";

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
                                                                                aCabanaDoor.ScreenType = Convert.ToString(cabanaReader[4]);

                                                                                aCabanaDoor.DoorWindow = aDoorWindow;

                                                                                listOfModuleItems.Add(aCabanaDoor); //add the modular item to the list
                                                                            }
                                                                            cabanaReader.Close();

                                                                            #endregion
                                                                            break;
                                                                        case "French":
                                                                        case "French Door":
                                                                            #region French Door

                                                                            aCommand.CommandText = "SELECT glass_tint, swing, operator, hardware_type, screen_type FROM french_doors "
                                                                                            + "WHERE project_id = '" + projectId + "' AND linear_index = '" + aMod.LinearIndex + "' AND module_index = '" + moduleIndex + "'";

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
                                                                                aFrenchDoor.ScreenType = Convert.ToString(frenchReader[4]);

                                                                                aFrenchDoor.DoorWindow = aDoorWindow;

                                                                                listOfModuleItems.Add(aFrenchDoor); //add the modular item to the list
                                                                            }
                                                                            frenchReader.Close();

                                                                            #endregion
                                                                            break;
                                                                        case "Patio":
                                                                        case "Patio Door":
                                                                            #region Patio Door

                                                                            aCommand.CommandText = "SELECT glass_tint, moving_door FROM patio_doors "
                                                                                            + "WHERE project_id = '" + projectId + "' AND linear_index = '" + aMod.LinearIndex + "' AND module_index = '" + moduleIndex + "'"; //change k to moduleIndex. Couldn't compile other pages.

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
                                                                        case "NoDoor":
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
                                                                
                                                            
                                                            //doorReader.Close();
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
                                            
                                            //moduleItemReader.Close();
                                            #endregion
                                            break;
                                        case "Receiver":
                                        case "Receiever":
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
                                        case "2PieceReceiver":
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
                                        case "BoxHeader": // 
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
                                        case "BoxHeaderReceiver":
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
                                        case "Corner":
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
                                        case "ElectricalChase":
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
                                        case "HChannel":
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
                            //linearItemReader.Close();

                        
                    
                    //wallReader.Close();
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
                        for(int i = 0; i < roofCount; i++)
                        {
                        aCommand.CommandText = "SELECT roof_type, interior_skin, exterior_skin, thickness, fire_protection, thermadeck, acrylic, gutter, gutter_pro, gutter_colour, number_supports, stripe_colour, projection, width, roof_index "
                                + "FROM roofs WHERE project_id = '" + projectId + "' roof_index = '" + i + "'";

                        aReader = aCommand.ExecuteReader();
                        aReader.Read();

                        //if (roofReader.HasRows)
                        //{
                        //    while (roofReader.Read())
                        //    {

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

                            aReader.Close();
                                List<RoofModule> listOfRoofModules = new List<RoofModule>();

                                aCommand.CommandText = "SELECT COUNT(*) FROM roof_modules WHERE project_id = '" + projectId + "' AND roof_index = '" + roofIndex + "'";
                                aReader = aCommand.ExecuteReader();
                                aReader.Read();
                                int roofModCount = Convert.ToInt32(aReader[0]);


                                //aCommand.CommandText = "SELECT projection, width, interior_skin, exterior_skin, roof_view "
                                //+ "FROM roof_modules WHERE project_id = '" + projectId + "' AND roof_index = '" + roofIndex + "'";


                                //SqlDataReader moduleReader = aCommand.ExecuteReader();

                                //if (moduleReader.HasRows)
                                //{
                                //    while (moduleReader.Read())
                                    for(int j = 0; j < roofModCount; j++)
                                    {

                                        aCommand.CommandText = "SELECT projection, width, interior_skin, exterior_skin, roof_view "
                                                    + "FROM roof_modules WHERE project_id = '" + projectId + "' AND roof_index = '" + roofIndex + "'";


                                         aReader = aCommand.ExecuteReader();
                                         aReader.Read();

                                        RoofModule aModule = new RoofModule();
                                        aModule.Projection = Convert.ToDouble(aReader[0]);
                                        aModule.Width = Convert.ToDouble(aReader[1]);
                                        aModule.InteriorSkin = Convert.ToString(aReader[2]);
                                        aModule.ExteriorSkin = Convert.ToString(aReader[3]);
                                        int roofView = Convert.ToInt32(aReader[4]);

                                        aReader.Close();

                                        List<RoofItem> listOfRoofItems = new List<RoofItem>();


                                        aCommand.CommandText = "SELECT COUNT(*) FROM roof_modules WHERE project_id = '" + projectId + "' AND roof_index = '" + roofIndex + "' AND roof_view = '" + roofView + "'";
                                        aReader = aCommand.ExecuteReader();
                                        aReader.Read();
                                        int roofItemCount = Convert.ToInt32(aReader[0]);

                                        //aCommand.CommandText = "SELECT roof_item, projection, width, item_index "
                                        //+ "FROM roof_modules WHERE project_id = '" + projectId + "' AND roof_index = '" + roofIndex + "' AND roof_view = '" + roofView + "'";


                                        //SqlDataReader itemReader = aCommand.ExecuteReader();

                                        //if (itemReader.HasRows)
                                        //{
                                        //    while(itemReader.Read())
                                            for (int k = 0; k < roofItemCount; k++)
                                            {

                                                aCommand.CommandText = "SELECT roof_item, projection, width, item_index "
                                                    + "FROM roof_modules WHERE project_id = '" + projectId + "' AND roof_index = '" + roofIndex + "' AND roof_view = '" + roofView + "' AND item_index = '" + k + "'";


                                                aReader = aCommand.ExecuteReader();
                                                aReader.Read();


                                                // store in an object
                                                RoofItem aRoofItem = new RoofItem();
                                                aRoofItem.ItemType = Convert.ToString(aReader[0]);
                                                aRoofItem.Projection = Convert.ToSingle(aReader[1]);
                                                aRoofItem.Width = Convert.ToSingle(aReader[2]);
                                                int itemIndex = Convert.ToInt32(aReader[3]);
                                                
                                                aReader.Close();

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
                                                        + "FROM skylights WHERE project_id = '" + projectId + "' AND roof_index = '" + roofIndex + "' AND roof_view = '" + roofView + "' AND item_index '" + itemIndex + "'";


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
                                                        + "FROM fanbeams WHERE project_id = '" + projectId + "' AND roof_index = '" + roofIndex + "' AND roof_view = '" + roofView + "' AND item_index = '" + itemIndex + "'";


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
                                        

                                        //itemReader.Close();

                                        aModule.RoofItems = listOfRoofItems;

                                        listOfRoofModules.Add(aModule);
                                    }
                                
                                //moduleReader.Close();

                                aRoof.RoofModules = listOfRoofModules;
                            }
                        
                        //roofReader.Close();
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
              
            #endregion

            hidJsonObjects.Value = JsonConvert.SerializeObject(listOfWalls);
            PopulateDropdown(floorCount, roofCount);
            PopulateModOptions();
        }

        protected void PopulateDropdown(int floor = 0, int roof = 0)
        {
            ListItem liLayout = new ListItem("Room Layout", "-1");
            ddlSunroomObjects.Items.Add(liLayout);
            //if (roof != 0) //if there's a roof, add it 
            //{
                //ListItem liRoof = new ListItem("Roof", "Roof");
                //ddlSunroomObjects.Items.Add(liRoof);
            //}
            // add all the walls
            int i = 0;
            foreach (Wall wall in listOfWalls)
            {
                ListItem liWall = new ListItem(wall.Name, i.ToString());
                ddlSunroomObjects.Items.Add(liWall);
                i++;
            }
            //if (floor != 0) //if there's a floor, add it
            //{
            //    ListItem liFloor = new ListItem("Floor", "Floor");
            //    ddlSunroomObjects.Items.Add(liFloor);
            //}

            //add the onclick attribute
            ddlSunroomObjects.Attributes.Add("onclick", "sunroomObjectChanged(document.getElementById('SecondaryNavigation_ddlSunroomObjects').options[document.getElementById('SecondaryNavigation_ddlSunroomObjects').selectedIndex].value);");
        }

        protected void PopulateModOptions()
        {
            foreach (Wall wall in listOfWalls)
            {
                foreach (LinearItem li in wall.LinearItems)
                {
                    //li tag to hold linear item type radio button and all its content
                    ModOptions.Controls.Add(new LiteralControl("<li id=li"+li.LinearIndex+" style=\"display:none\">"));
                    
                    //Window type radio button
                    RadioButton typeRadio = new RadioButton();
                    typeRadio.ID = "radType" + li.LinearIndex; //Adding appropriate id to window type radio button
                    typeRadio.GroupName = "linearItemTypeRadios";         //Adding group name for all window types
                    //if (title == "Vinyl") typeRadio.Attributes.Add("onclick", "windowVinylStyleChanged(document.getElementById('MainContent_ddlWindowStyleVinyl').options[document.getElementById('MainContent_ddlWindowStyleVinyl').selectedIndex].value);");
                    //if (title == "Glass") typeRadio.Attributes.Add("onclick", "windowGlassStyleChanged(document.getElementById('MainContent_ddlWindowStyleGlass').options[document.getElementById('MainContent_ddlWindowStyleGlass').selectedIndex].value);");
                    //if (title == "Screen") typeRadio.Attributes.Add("onclick", "windowScreenStyleChanged(document.getElementById('MainContent_ddlWindowStyleScreen').options[document.getElementById('MainContent_ddlWindowStyleScreen').selectedIndex].value);");
                    //typeRadio.Attributes.Add("onclick", "typeRowsDisplayed('" + title + "')"); //On click event to display the proper fields/rows


                    //Window type radio button label for clickable area
                    Label typeLabelRadio = new Label();
                    typeLabelRadio.AssociatedControlID = "radType"+ li.LinearIndex;   //Tying this label to the radio button

                    //Window type radio button label text
                    Label typeLabel = new Label();
                    typeLabel.AssociatedControlID = "radType"+ li.LinearIndex;    //Tying this label to the radio button
                    typeLabel.Text = li.ItemType;     //Displaying the proper texted based on current title variable


                    ModOptions.Controls.Add(typeRadio);        //Adding radio button control to placeholder ModOptions
                    ModOptions.Controls.Add(typeLabelRadio);   //Adding label control to placeholder ModOptions
                    ModOptions.Controls.Add(typeLabel);        //Adding label control to placeholder ModOptions

                    
                    //New instance of a table for every window type
                    Table tblModDetails = new Table();

                    tblModDetails.ID = "tblWindowDetails" + li.LinearIndex; //Adding appropriate id to the table
                    //tblWindowDetails.CssClass = "tblTextFields";                  //Adding CssClass to the table for styling
                    //tblWindowDetails.Attributes.Add("style", "display: block");
                    tblModDetails.Style.Add("display", "table");




                    /////////////////////////////////////////////
                    // rows and cells go here
                    /////////////////////////////////////////////




                    //Adding literal control div tag to hold the table, add to ModOptions placeholder
                    ModOptions.Controls.Add(new LiteralControl("<div class=\"toggleContent\" id=\"div_" + li.LinearIndex + "\">"));

                    ModOptions.Controls.Add(new LiteralControl("<ul>"));

                    //Adding literal control li to keep proper page look and format
                    ModOptions.Controls.Add(new LiteralControl("<li>"));

                    //Adding table to placeholder ModOptions
                    ModOptions.Controls.Add(tblModDetails);

                    //Closing necessary tags
                    ModOptions.Controls.Add(new LiteralControl("</li>"));

                    ModOptions.Controls.Add(new LiteralControl("</ul>"));

                    ModOptions.Controls.Add(new LiteralControl("</div>"));

                    ModOptions.Controls.Add(new LiteralControl("</li>"));

                }
            }
        }
    }
}
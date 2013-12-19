﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SunspaceDealerDesktop
{
    public partial class ProjectEditor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int project_id = 10;
            int wallCount;
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

                    wallCount = aReader.RecordsAffected; //get the number of walls in the project

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
                                    aCommand.CommandText = "SELECT * FROM moduleItems WHERE project_id = '" + project_id + "' "
                                                                            + " AND linear_index = '" + aMod.LinearIndex + "'";
                                    aReader = aCommand.ExecuteReader();

                                    int modCount = aReader.RecordsAffected; //get the number of walls in the project

                                    aReader.Close();

                                    for (int k = 0; k < modCount; k++)
                                    {
                                        //Get linear items
                                         aCommand.CommandText = "SELECT module_index, item_type, start_height, end_height, length FROM moduleItems "
                                                        + "WHERE project_id = '" + project_id + "' AND linear_index = '" + aMod.LinearIndex + "' AND module_index = '" + k + "'";

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
                                            case "Window":
                                                #region Window
                                                //Get window
                                                aCommand.CommandText = "SELECT window_type, screen_type, start_height, end_height, length, window_colour, number_vents FROM windows "
                                                                        + "WHERE project_id = '" + project_id + "' AND linear_index = '" + aMod.LinearIndex + "' AND module_index = '" + k + "'";

                                                aReader = aCommand.ExecuteReader();
                                                aReader.Read();

                                                string windowStyle = Convert.ToString(aReader[0]);
                                                string screenType = Convert.ToString(aReader[1]);
                                                float windowStartHeight = Convert.ToSingle(aReader[2]);
                                                float windowEndHeight = Convert.ToSingle(aReader[3]);
                                                float windowLength = Convert.ToSingle(aReader[4]);
                                                string windowColour = Convert.ToString(aReader[5]);
                                                int numVents = Convert.ToInt32(aReader[6]); //i assume this is also used for glass windows???

                                                aReader.Close();

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

                                                        for (int l = 0; l < numVents; l++)
                                                        {

                                                            //Get vinyl item
                                                            aCommand.CommandText = "SELECT start_height, vinyl_tint, spreader_bar FROM vinyl_items "
                                                                                    + "WHERE project_id = '" + project_id + "' AND linear_index = '" + aMod.LinearIndex + "' AND module_index = '" + k + "' AND vent_index = '" + l + "'";

                                                            aReader = aCommand.ExecuteReader();
                                                            aReader.Read();

                                                            listOfVentHeights.Add(Convert.ToSingle(aReader[0]));
                                                            aVinylWindow.VinylTint += Convert.ToString(aReader[1]);
                                                            aVinylWindow.SpreaderBar = Convert.ToSingle(aReader[2]);

                                                            aReader.Close();
                                                        }

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

                                                        for (int l = 0; l < numVents; l++)
                                                        {

                                                            //Get glass item
                                                            aCommand.CommandText = "SELECT glass_type, glass_tint, tempered, operation FROM glass_items "
                                                                                    + "WHERE project_id = '" + project_id + "' AND linear_index = '" + aMod.LinearIndex + "' AND module_index = '" + k + "' AND vent_index = '" + l + "'";

                                                            aReader = aCommand.ExecuteReader();
                                                            aReader.Read();

                                                            aGlassWindow.GlassType = Convert.ToString(aReader[0]);
                                                            aGlassWindow.GlassTint += Convert.ToString(aReader[1]);
                                                            aGlassWindow.Tempered = Convert.ToBoolean(aReader[2]);
                                                            aGlassWindow.Operation += Convert.ToString(aReader[3]);

                                                            aReader.Close();
                                                        }

                                                        listOfModuleItems.Add(aGlassWindow);
                                                        
                                                        #endregion
                                                        break;
                                                }
                                                #endregion
                                                break;
                                            case "Door":
                                                #region
                                                //Get door
                                                aCommand.CommandText = "SELECT door_type, door_style, screen_type, height, length, door_colour, kick_plate FROM doors "
                                                                        + "WHERE project_id = '" + project_id + "' AND linear_index = '" + aMod.LinearIndex + "' AND module_index = '" + k + "'";

                                                aReader = aCommand.ExecuteReader();
                                                aReader.Read();

                                                string doorType = Convert.ToString(aReader[0]);
                                                string doorStyle = Convert.ToString(aReader[1]);
                                                string doorScreenType = Convert.ToString(aReader[2]);
                                                float doorHeight = Convert.ToSingle(aReader[3]);
                                                float doorLength = Convert.ToSingle(aReader[4]);
                                                string doorColour = Convert.ToString(aReader[5]);
                                                float doorKickPlate = Convert.ToSingle(aReader[6]); 

                                                aReader.Close();

                                                //types of windows
                                                switch (doorType)
                                                {
                                                    case "Cabana Door":
                                                        #region Cabana Door

                                                        aCommand.CommandText = "SELECT glass_tint, hinge, swing, hardware_type FROM cabana_doors "
                                                                        + "WHERE project_id = '" + project_id + "' AND linear_index = '" + aMod.LinearIndex + "' AND module_index = '" + k + "'";

                                                        aReader = aCommand.ExecuteReader();
                                                        aReader.Read();

                                                        CabanaDoor aCabanaDoor = new CabanaDoor();
                                                        aCabanaDoor.ModuleIndex = moduleIndex;
                                                        aCabanaDoor.ItemType = itemType;
                                                        aCabanaDoor.FStartHeight = fStartHeight;
                                                        aCabanaDoor.FEndHeight = fEndHeight;
                                                        aCabanaDoor.FLength = fLength;
                                                        aCabanaDoor.DoorType = doorType;
                                                        aCabanaDoor.DoorStyle = doorStyle;
                                                        aCabanaDoor.ScreenType = doorScreenType;
                                                        aCabanaDoor.Height = doorHeight;
                                                        aCabanaDoor.Length = doorLength;
                                                        aCabanaDoor.Colour = doorColour; //
                                                        aCabanaDoor.Kickplate = doorKickPlate; //
                                                        aCabanaDoor.GlassTint = Convert.ToString(aReader[0]);
                                                        aCabanaDoor.Hinge = Convert.ToString(aReader[1]);
                                                        aCabanaDoor.Swing = Convert.ToString(aReader[2]);
                                                        aCabanaDoor.HardwareType = Convert.ToString(aReader[3]);

                                                        listOfModuleItems.Add(aCabanaDoor);

                                                        aReader.Close();

                                                        #endregion
                                                        break;
                                                    case "French Door":
                                                        #region French Door

                                                        aCommand.CommandText = "SELECT glass_tint, swing, operator, hardware_type FROM french_doors "
                                                                        + "WHERE project_id = '" + project_id + "' AND linear_index = '" + aMod.LinearIndex + "' AND module_index = '" + k + "'";

                                                        aReader = aCommand.ExecuteReader();
                                                        aReader.Read();

                                                        FrenchDoor aFrenchDoor = new FrenchDoor();
                                                        aFrenchDoor.ModuleIndex = moduleIndex;
                                                        aFrenchDoor.ItemType = itemType;
                                                        aFrenchDoor.FStartHeight = fStartHeight;
                                                        aFrenchDoor.FEndHeight = fEndHeight;
                                                        aFrenchDoor.FLength = fLength;
                                                        aFrenchDoor.DoorType = doorType;
                                                        aFrenchDoor.DoorStyle = doorStyle;
                                                        aFrenchDoor.ScreenType = doorScreenType;
                                                        aFrenchDoor.Height = doorHeight;
                                                        aFrenchDoor.Length = doorLength;
                                                        aFrenchDoor.Colour = doorColour; //
                                                        aFrenchDoor.Kickplate = doorKickPlate; // 
                                                        aFrenchDoor.GlassTint = Convert.ToString(aReader[0]);
                                                        aFrenchDoor.Swing = Convert.ToString(aReader[1]);
                                                        aFrenchDoor.OperatingDoor = Convert.ToString(aReader[2]); ///this needs to be fixed, operator in db is bool and C# is string
                                                        aFrenchDoor.HardwareType = Convert.ToString(aReader[3]);

                                                        listOfModuleItems.Add(aFrenchDoor);

                                                        aReader.Close();

                                                        #endregion
                                                        break;
                                                    case "Patio Door":
                                                        #region Patio Door

                                                        aCommand.CommandText = "SELECT glass_tint, moving_door FROM patio_doors "
                                                                        + "WHERE project_id = '" + project_id + "' AND linear_index = '" + aMod.LinearIndex + "' AND module_index = '" + k + "'";

                                                        aReader = aCommand.ExecuteReader();
                                                        aReader.Read();

                                                        PatioDoor aPatioDoor = new PatioDoor();
                                                        aPatioDoor.ModuleIndex = moduleIndex;
                                                        aPatioDoor.ItemType = itemType;
                                                        aPatioDoor.FStartHeight = fStartHeight;
                                                        aPatioDoor.FEndHeight = fEndHeight;
                                                        aPatioDoor.FLength = fLength;
                                                        aPatioDoor.DoorType = doorType;
                                                        aPatioDoor.DoorStyle = doorStyle;
                                                        aPatioDoor.ScreenType = doorScreenType;
                                                        aPatioDoor.Height = doorHeight;
                                                        aPatioDoor.Length = doorLength;
                                                        aPatioDoor.Colour = doorColour; //
                                                        aPatioDoor.Kickplate = doorKickPlate; // 
                                                        aPatioDoor.GlassTint = Convert.ToString(aReader[0]);
                                                        aPatioDoor.MovingDoor = Convert.ToString(aReader[1]); ///this needs to be fixed, operator in db is bool and C# is string

                                                        listOfModuleItems.Add(aPatioDoor);

                                                        aReader.Close();

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
                                                        aDoor.Height = doorHeight;
                                                        aDoor.Length = doorLength;
                                                        //aDoor.Colour = doorColour; //
                                                        //aDoor.Kickplate = doorKickPlate; // 
                                                        
                                                        listOfModuleItems.Add(aDoor);

                                                        aReader.Close();

                                                        #endregion
                                                        break;
                                                }

                                                #endregion
                                                break;
                                            case "Box Header":
                                                //horizontal box header?
                                                break;
                                            case "Panel BoxHeader":
                                                //horizontal panel receiver?
                                                break;
                                            case "Open":
                                                Door openDoor = new Door();
                                                openDoor.ModuleIndex = moduleIndex;
                                                openDoor.ItemType = itemType;
                                                openDoor.FStartHeight = fStartHeight;
                                                openDoor.FEndHeight = fEndHeight;
                                                openDoor.FLength = fLength;
                                                        
                                                listOfModuleItems.Add(openDoor);        
                                                break;
                                            case "Screen":
                                                //same as screen window?
                                                break;
                                            case "Glass":
                                                //same as glass window?
                                                break;
                                            case "Vinyl":
                                                //same as vinyl window?
                                                break;
                                            case "Panel":
                                                // filler? 
                                                break;
                                        }

                                        aMod.ModularItems = listOfModuleItems;                                        
                                    }

                                    listOfLinearItems.Add(aMod);

                                    break;
                                case "1 Piece Receiver":
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

                                    listOfLinearItems.Add(aBoxHeader);
                                    break;
                                case "2 Piece Receiver":
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

                                    listOfLinearItems.Add(aBoxHeader);
                                    break;
                                case "Box Header":
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
                                    aBoxHeader.IsTwoPiece = false;

                                    listOfLinearItems.Add(aBoxHeader);

                                    break;
                                case "Filler":
                                    Filler aFiller = new Filler();
                                    aFiller.LinearIndex = linearIndex;
                                    aFiller.ItemType = linearItemType;
                                    aFiller.StartHeight = startHeight;
                                    aFiller.EndHeight = endHeight;
                                    aFiller.Length = length;
                                    aFiller.FrameColour = frameColour;
                                    aFiller.Sex = sex;
                                    aFiller.FixedLocation = fixedLocation; 
                                    aFiller.AttachedTo = attachedTo; 

                                    listOfLinearItems.Add(aFiller);

                                    break;
                                case "Corner Post":
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
                                    aCorner.AngleIs90 = true; //hard coded, because I don't know where its coming from
                                    aCorner.OutsideCorner = true; // hard coded because I don't know where its coming from

                                    listOfLinearItems.Add(aCorner);

                                    break;
                                case "Electrical Chase":
                                    //no class
                                    break;
                                case "H Channel":
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
 
                                    listOfLinearItems.Add(aHChannel);

                                    break;
                                case "Gable Post":
                                    //no class
                                    break;
                            }
                        }

                        aWall.LinearItems = listOfLinearItems;

                        listOfWalls.Add(aWall); //add the wall
                    }

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
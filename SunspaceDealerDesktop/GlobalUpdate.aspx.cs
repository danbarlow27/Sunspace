using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SunspaceDealerDesktop
{
    public partial class GlobalUpdate : System.Web.UI.Page
    {
        int totalElements;
        const int TEXTBOX_HEIGHT = 20;
        const int TEXTBOX_WIDTH = 70;
        const int NUMBER_OF_TABLES_INCLUDED = 15; 

        int[] tableStarts = new int[NUMBER_OF_TABLES_INCLUDED];
        int tableCounter = 0; // for use with tableStarts
        string[] tableNames = new string[NUMBER_OF_TABLES_INCLUDED];

        //will keep permanent track of each control for each record
        CheckBox[] checkboxArray; 
        Label[] partNumArray;
        Label[] partNameArray;
        Label[] currentUSArray;
        Label[] currentCanArray;
        TextBox[] priceUSArray;
        TextBox[] priceCanArray;
        TextBox[] previewUSArray;
        TextBox[] previewCanArray;
        string[] lastAdjustedUS;
        string[] lastAdjustedCan;
        string[] lastCalculatedUS;
        string[] lastCalculatedCan;

        protected void Page_Load(object sender, EventArgs e)
        {           
            if (!IsPostBack) //only on first load
            {
                //set default values to declared empty variables
                Session.Add("categoryIndex", 0);
                radIncreaseDecrease.SelectedIndex = 0;
                radPercentDollar.SelectedIndex = 0;
                totalElements = 0;
                lblHeaderPriceAdjust.Text = "Price Increase by %";

                //set up a dataview object to hold table names for the first drop down
                System.Data.DataView tableList = new System.Data.DataView();

                //select table names
                datSelectDataSource.SelectCommand = "SELECT name FROM sys.tables WHERE name != 'tblColor' AND name != 'tblSchematicParts' AND name != 'tblParts' "
                                                                        + " AND name != 'tblLengthUnits'  AND name != 'tblAudits' AND name != 'tblSalesOrders' AND name != 'tblSalesOrderItems' "
                                                                        + " AND SUBSTRING(name,1,3) = 'tbl' "
                                                                        + "ORDER BY name ASC"; tableList = (System.Data.DataView)datSelectDataSource.Select(System.Web.UI.DataSourceSelectArguments.Empty);

                //variable to determine amount of rows in the dataview object
                int rowCount = tableList.Count;

                ddlCategory.Items.Add("All");
                //populate first drop down
                for (int i = 0; i < rowCount; i++)
                {
                    string textString = tableList[i][0].ToString();
                    string newString = textString.Substring(3);
                    string outputString = "";
                    foreach (char character in newString)
                    {
                        if (char.IsUpper(character))
                        {
                            outputString += " " + character;
                        }
                        else if (character.ToString() == "1" || character.ToString() == "3" || character.ToString() == "4")
                        {
                            outputString += " " + character;
                        }
                        else
                        {
                            outputString += character;
                        }
                    }

                    ddlCategory.Items.Add(outputString.Trim());
                }

                //select category dropdown default value 
                ddlCategory.SelectedIndex = (int)Session["categoryIndex"];  
            }

                #region populateViews

            //Dataviews for each table
            System.Data.DataView tblAccessories = new System.Data.DataView();
            System.Data.DataView tblDecorativeColumn = new System.Data.DataView();
            System.Data.DataView tblDoorFrameExtrusion = new System.Data.DataView();
            System.Data.DataView tblInsulatedFloors = new System.Data.DataView();
            System.Data.DataView tblRoofExtrusions = new System.Data.DataView();
            System.Data.DataView tblRoofPanels = new System.Data.DataView();
            System.Data.DataView tblScreenRoll = new System.Data.DataView();
            System.Data.DataView tblSuncrylicRoof = new System.Data.DataView();
            System.Data.DataView tblSunrail1000 = new System.Data.DataView();
            System.Data.DataView tblSunrail300 = new System.Data.DataView();
            System.Data.DataView tblSunrail300Accessories = new System.Data.DataView();
            System.Data.DataView tblSunrail400 = new System.Data.DataView();
            System.Data.DataView tblVinylRoll = new System.Data.DataView();
            System.Data.DataView tblWallExtrusions = new System.Data.DataView();
            System.Data.DataView tblWallPanels = new System.Data.DataView();

            //If all, or specific table name (will display only this table)
            if (ddlCategory.SelectedValue == "Accessories" || ddlCategory.SelectedValue == "All")
            {
                datSelectDataSource.SelectCommand = "SELECT * FROM tblAccessories"; //select all data from table
                tblAccessories = (System.Data.DataView)datSelectDataSource.Select(System.Web.UI.DataSourceSelectArguments.Empty); //put data into the data view for later
                totalElements += tblAccessories.Count;//increase total counter
                tableStarts[tableCounter] = 0; //starts at 0 since first table
                tableNames[tableCounter] = "tblAccessories"; //set the table name in this array
                tableCounter++; //and increase amount of tables populated by one
            }

            if (ddlCategory.SelectedValue == "Decorative Column" || ddlCategory.SelectedValue == "All")
            {
                tableStarts[tableCounter] = totalElements;  //will start at the current # of elements
                datSelectDataSource.SelectCommand = "SELECT * FROM tblDecorativeColumn";
                tblDecorativeColumn = (System.Data.DataView)datSelectDataSource.Select(System.Web.UI.DataSourceSelectArguments.Empty);
                totalElements += tblDecorativeColumn.Count;
                tableNames[tableCounter] = "tblDecorativeColumn";
                tableCounter++;
            }

            if (ddlCategory.SelectedValue == "Door Frame Extrusion" || ddlCategory.SelectedValue == "All")
            {
                tableStarts[tableCounter] = totalElements;  //will start at the current # of elements
                datSelectDataSource.SelectCommand = "SELECT * FROM tblDoorFrameExtrusion";
                tblDoorFrameExtrusion = (System.Data.DataView)datSelectDataSource.Select(System.Web.UI.DataSourceSelectArguments.Empty);
                totalElements += tblDoorFrameExtrusion.Count;
                tableNames[tableCounter] = "tblDoorFrameExtrusion";
                tableCounter++;
            }

            if (ddlCategory.SelectedValue == "Insulated Floors" || ddlCategory.SelectedValue == "All")
            {
                tableStarts[tableCounter] = totalElements;  //will start at the current # of elements
                datSelectDataSource.SelectCommand = "SELECT * FROM tblInsulatedFloors";
                tblInsulatedFloors = (System.Data.DataView)datSelectDataSource.Select(System.Web.UI.DataSourceSelectArguments.Empty);
                totalElements += tblInsulatedFloors.Count;
                tableNames[tableCounter] = "tblInsulatedFloors";
                tableCounter++;
            }

            if (ddlCategory.SelectedValue == "Roof Extrusions" || ddlCategory.SelectedValue == "All")
            {
                tableStarts[tableCounter] = totalElements;  //will start at the current # of elements
                datSelectDataSource.SelectCommand = "SELECT * FROM tblRoofExtrusions";
                tblRoofExtrusions = (System.Data.DataView)datSelectDataSource.Select(System.Web.UI.DataSourceSelectArguments.Empty);
                totalElements += tblRoofExtrusions.Count;
                tableNames[tableCounter] = "tblRoofExtrusions";
                tableCounter++;
            }

            if (ddlCategory.SelectedValue == "Roof Panels" || ddlCategory.SelectedValue == "All")
            {
                tableStarts[tableCounter] = totalElements;  //will start at the current # of elements
                datSelectDataSource.SelectCommand = "SELECT * FROM tblRoofPanels";
                tblRoofPanels = (System.Data.DataView)datSelectDataSource.Select(System.Web.UI.DataSourceSelectArguments.Empty);
                totalElements += tblRoofPanels.Count;
                tableNames[tableCounter] = "tblRoofPanels";
                tableCounter++;
            }

            if (ddlCategory.SelectedValue == "Screen Roll" || ddlCategory.SelectedValue == "All")
            {
                tableStarts[tableCounter] = totalElements;  //will start at the current # of elements
                datSelectDataSource.SelectCommand = "SELECT * FROM tblScreenRoll";
                tblScreenRoll = (System.Data.DataView)datSelectDataSource.Select(System.Web.UI.DataSourceSelectArguments.Empty);
                totalElements += tblScreenRoll.Count;
                tableNames[tableCounter] = "tblScreenRoll";
                tableCounter++;
            }

            if (ddlCategory.SelectedValue == "Suncrylic Roof" || ddlCategory.SelectedValue == "All")
            {
                tableStarts[tableCounter] = totalElements;  //will start at the current # of elements
                datSelectDataSource.SelectCommand = "SELECT * FROM tblSuncrylicRoof";
                tblSuncrylicRoof = (System.Data.DataView)datSelectDataSource.Select(System.Web.UI.DataSourceSelectArguments.Empty);
                totalElements += tblSuncrylicRoof.Count;
                tableNames[tableCounter] = "tblSuncrylicRoof";
                tableCounter++;
            }

            if (ddlCategory.SelectedValue == "Sunrail 1000" || ddlCategory.SelectedValue == "All")
            {
                tableStarts[tableCounter] = totalElements;  //will start at the current # of elements
                datSelectDataSource.SelectCommand = "SELECT * FROM tblSunrail1000";
                tblSunrail1000 = (System.Data.DataView)datSelectDataSource.Select(System.Web.UI.DataSourceSelectArguments.Empty);
                totalElements += tblSunrail1000.Count;
                tableNames[tableCounter] = "tblSunrail1000";
                tableCounter++;
            }

            if (ddlCategory.SelectedValue == "Sunrail 300" || ddlCategory.SelectedValue == "All")
            {
                tableStarts[tableCounter] = totalElements;  //will start at the current # of elements
                datSelectDataSource.SelectCommand = "SELECT * FROM tblSunrail300";
                tblSunrail300 = (System.Data.DataView)datSelectDataSource.Select(System.Web.UI.DataSourceSelectArguments.Empty);
                totalElements += tblSunrail300.Count;
                //          CHANGETHISCODE, need to uncomment upon Sunrail300 fix
                 tableNames[tableCounter] = "tblSunrail300";
                 tableCounter++;
            }

            if (ddlCategory.SelectedValue == "Sunrail 300 Accessories" || ddlCategory.SelectedValue == "All")
            {
                tableStarts[tableCounter] = totalElements;  //will start at the current # of elements
                datSelectDataSource.SelectCommand = "SELECT * FROM tblSunrail300Accessories";
                tblSunrail300Accessories = (System.Data.DataView)datSelectDataSource.Select(System.Web.UI.DataSourceSelectArguments.Empty);
                totalElements += tblSunrail300Accessories.Count;
                tableNames[tableCounter] = "tblSunrail300Accessories";
                tableCounter++;
            }

            if (ddlCategory.SelectedValue == "Sunrail 400" || ddlCategory.SelectedValue == "All")
            {
                tableStarts[tableCounter] = totalElements;  //will start at the current # of elements
                datSelectDataSource.SelectCommand = "SELECT * FROM tblSunrail400";
                tblSunrail400 = (System.Data.DataView)datSelectDataSource.Select(System.Web.UI.DataSourceSelectArguments.Empty);
                totalElements += tblSunrail400.Count;
                tableNames[tableCounter] = "tblSunrail400";
                tableCounter++;
            }

            if (ddlCategory.SelectedValue == "Vinyl Roll" || ddlCategory.SelectedValue == "All")
            {
                tableStarts[tableCounter] = totalElements;  //will start at the current # of elements
                datSelectDataSource.SelectCommand = "SELECT * FROM tblVinylRoll";
                tblVinylRoll = (System.Data.DataView)datSelectDataSource.Select(System.Web.UI.DataSourceSelectArguments.Empty);
                totalElements += tblVinylRoll.Count;
                tableNames[tableCounter] = "tblVinylRoll";
                tableCounter++;
            }

            if (ddlCategory.SelectedValue == "Wall Extrusions" || ddlCategory.SelectedValue == "All")
            {
                tableStarts[tableCounter] = totalElements;  //will start at the current # of elements
                datSelectDataSource.SelectCommand = "SELECT * FROM tblWallExtrusions";
                tblWallExtrusions = (System.Data.DataView)datSelectDataSource.Select(System.Web.UI.DataSourceSelectArguments.Empty);
                totalElements += tblWallExtrusions.Count;
                tableNames[tableCounter] = "tblWallExtrusions";
                tableCounter++;
            }

            if (ddlCategory.SelectedValue == "Wall Panels" || ddlCategory.SelectedValue == "All")
            {
                tableStarts[tableCounter] = totalElements;  //will start at the current # of elements
                datSelectDataSource.SelectCommand = "SELECT * FROM tblWallPanels";
                tblWallPanels = (System.Data.DataView)datSelectDataSource.Select(System.Web.UI.DataSourceSelectArguments.Empty);
                totalElements += tblWallPanels.Count;
                tableNames[tableCounter] = "tblWallPanels";
                tableCounter++;
            }
                #endregion

                #region declareArrays
                //generate array based on total # of elements calculated
                checkboxArray = new CheckBox[totalElements];
                partNumArray = new Label[totalElements];
                partNameArray = new Label[totalElements];
                currentUSArray = new Label[totalElements];
                currentCanArray = new Label[totalElements];
                priceUSArray = new TextBox[totalElements];
                priceCanArray = new TextBox[totalElements];
                previewUSArray = new TextBox[totalElements];
                previewCanArray = new TextBox[totalElements];
                lastCalculatedUS = new string[totalElements];
                lastCalculatedCan = new string[totalElements];
                lastAdjustedUS = new string[totalElements];
                lastAdjustedCan = new string[totalElements];
            
                Session.Add("totalElements", totalElements);
                #endregion

                #region populateArrays
                //Need a class instantiated per table so call populate functions
                Accessories tempAccessory = new Accessories();
                DecorativeColumn tempDecorativeColumn = new DecorativeColumn();
                DoorFrameExtrusion tempDoorFrameExtrusion = new DoorFrameExtrusion();
                InsulatedFloors tempInsulatedFloors = new InsulatedFloors();
                RoofExtrusion tempRoofExtrusions = new RoofExtrusion();
                RoofPanels tempRoofPanels = new RoofPanels();
                ScreenRoll tempScreenRoll = new ScreenRoll();
                SuncrylicRoof tempSuncrylicRoof = new SuncrylicRoof();
                Sunrail1000 tempSunrail1000 = new Sunrail1000();
                Sunrail300 tempSunrail300 = new Sunrail300();
                Sunrail300Accessories tempSunrail300Accessories = new Sunrail300Accessories();
                Sunrail400 tempSunrail400 = new Sunrail400();
                VinylRoll tempVinylRoll = new VinylRoll();
                WallExtrusions tempWallExtrusions = new WallExtrusions();
                WallPanels tempWallPanels = new WallPanels();                

                //a temp data view for use with populate function
                System.Data.DataView tempDataView = new System.Data.DataView();
                int elementCounter = 0; //for use with keeping track of where we are in totalElements, while not resetting to 0 for each table
                int pastTablesTotal = 0; //used to make sure we access element 0 of at the start of each table, not the counter's value

                if (ddlCategory.SelectedValue == "Accessories" || ddlCategory.SelectedValue == "All")
                {
                    #region Accessories
                    for (int i = elementCounter; i < tblAccessories.Count; i++)
                    {
                        datSelectDataSource.SelectCommand = "SELECT * FROM tblAccessories WHERE accID=" + i; //select statement from database
                        tempDataView = (System.Data.DataView)datSelectDataSource.Select(System.Web.UI.DataSourceSelectArguments.Empty); //results from select command are placed in temp data view
                        tempAccessory.Populate(tempAccessory.SelectAll(datDisplayDataSource, "tblAccessories", tblAccessories[i][3].ToString())); //temp dataview calls populate from the class

                        checkboxArray[i] = new CheckBox(); //add a control for this record
                        checkboxArray[i].ID = "tblAccessoriesCheckBox" + i.ToString(); //give it an ID

                        partNumArray[i] = new Label();//add a control for this record
                        partNumArray[i].ID = "tblAccessoriesPartNumLabel" + i.ToString();//give it an ID
                        partNumArray[i].Text = tempAccessory.AccessoryNumber; //set it's default value based on data retrieved from class population

                        partNameArray[i] = new Label();//add a control for this record
                        partNameArray[i].ID = "tblAccessoriesPartNameLabel" + i.ToString();//give it an ID
                        partNameArray[i].Text = tempAccessory.AccessoryName; //set it's default value based on data retrieved from class population

                        currentUSArray[i] = new Label();//add a control for this record
                        currentUSArray[i].ID = "tblAccessoriesCurrentUSLabel" + i.ToString();//give it an ID
                        currentUSArray[i].Text = tempAccessory.AccessoryUsdPrice.ToString("N2"); //set it's default value based on data retrieved from class population

                        currentCanArray[i] = new Label();//add a control for this record
                        currentCanArray[i].ID = "tblAccessoriesCurrentCanLabel" + i.ToString();//give it an ID
                        currentCanArray[i].Text = tempAccessory.AccessoryCadPrice.ToString("N2"); //set it's default value based on data retrieved from class population

                        priceUSArray[i] = new TextBox();//add a control for this record
                        priceUSArray[i].ID = "tblAccessoriesPriceUSTextBox" + i.ToString();//give it an ID
                        priceUSArray[i].CssClass = "txtInputField"; //set CSS and height/width
                        priceUSArray[i].Height = TEXTBOX_HEIGHT;
                        priceUSArray[i].Width = TEXTBOX_WIDTH;

                        priceCanArray[i] = new TextBox();//add a control for this record
                        priceCanArray[i].ID = "tblAccessoriesPriceCanTextBox" + i.ToString();//give it an ID
                        priceCanArray[i].CssClass = "txtInputField";//set CSS and height/width
                        priceCanArray[i].Height = TEXTBOX_HEIGHT;
                        priceCanArray[i].Width = TEXTBOX_WIDTH;

                        previewUSArray[i] = new TextBox();//add a control for this record
                        previewUSArray[i].ID = "tblAccessoriesPreviewUSLabel" + i.ToString();//give it an ID
                        previewUSArray[i].CssClass = "txtInputField";//set CSS and height/width
                        previewUSArray[i].Height = TEXTBOX_HEIGHT;
                        previewUSArray[i].Width = TEXTBOX_WIDTH;

                        previewCanArray[i] = new TextBox();
                        previewCanArray[i].ID = "tblAccessoriesPreviewCanLabel" + i.ToString();//give it an ID
                        previewCanArray[i].CssClass = "txtInputField";//set CSS and height/width
                        previewCanArray[i].Height = TEXTBOX_HEIGHT;
                        previewCanArray[i].Width = TEXTBOX_WIDTH;

                        elementCounter++;
                    }
                    pastTablesTotal += tblAccessories.Count;
                    #endregion
                }

                if (ddlCategory.SelectedValue == "Decorative Column" || ddlCategory.SelectedValue == "All")
                {
                    #region DecorativeColumn
                    for (int i = elementCounter; i < (tblDecorativeColumn.Count + pastTablesTotal); i++) //adding elementCounter so that, if it starts above 0, will just do the .count value
                    {                                                                                    //past tables total is there so that the ending condition is in the proper # away from the start
                        datSelectDataSource.SelectCommand = "SELECT * FROM tblDecorativeColumn WHERE columnID=" + (i - pastTablesTotal);
                        tempDataView = (System.Data.DataView)datSelectDataSource.Select(System.Web.UI.DataSourceSelectArguments.Empty);
                        tempDecorativeColumn.Populate(tempDecorativeColumn.SelectAll(datDisplayDataSource, "tblDecorativeColumn", tblDecorativeColumn[i - pastTablesTotal][3].ToString()));

                        checkboxArray[i] = new CheckBox();
                        checkboxArray[i].ID = "tblDecorativeColumnCheckBox" + i.ToString();

                        partNumArray[i] = new Label();
                        partNumArray[i].ID = "tblDecorativeColumnPartNumLabel" + i.ToString();
                        partNumArray[i].Text = tempDecorativeColumn.PartNumber;

                        partNameArray[i] = new Label();
                        partNameArray[i].ID = "tblDecorativeColumnPartNameLabel" + i.ToString();
                        partNameArray[i].Text = tempDecorativeColumn.ColumnName;

                        currentUSArray[i] = new Label();
                        currentUSArray[i].ID = "tblDecorativeColumnCurrentUSLabel" + i.ToString();
                        currentUSArray[i].Text = tempDecorativeColumn.ColumnUsdPrice.ToString("N2");

                        currentCanArray[i] = new Label();
                        currentCanArray[i].ID = "tblDecorativeColumnCurrentCanLabel" + i.ToString();
                        currentCanArray[i].Text = tempDecorativeColumn.ColumnCadPrice.ToString("N2");

                        priceUSArray[i] = new TextBox();
                        priceUSArray[i].ID = "tblDecorativeColumnPriceUSTextBox" + i.ToString();
                        priceUSArray[i].CssClass = "txtInputField";
                        priceUSArray[i].Height = TEXTBOX_HEIGHT;
                        priceUSArray[i].Width = TEXTBOX_WIDTH;

                        priceCanArray[i] = new TextBox();
                        priceCanArray[i].ID = "tblDecorativeColumnPriceCanTextBox" + i.ToString();
                        priceCanArray[i].CssClass = "txtInputField";
                        priceCanArray[i].Height = TEXTBOX_HEIGHT;
                        priceCanArray[i].Width = TEXTBOX_WIDTH;

                        previewUSArray[i] = new TextBox();
                        previewUSArray[i].ID = "tblDecorativeColumnPreviewUSLabel" + i.ToString();
                        previewUSArray[i].CssClass = "txtInputField";
                        previewUSArray[i].Height = TEXTBOX_HEIGHT;
                        previewUSArray[i].Width = TEXTBOX_WIDTH;

                        previewCanArray[i] = new TextBox();
                        previewCanArray[i].ID = "tblDecorativeColumnPreviewCanLabel" + i.ToString();
                        previewCanArray[i].CssClass = "txtInputField";
                        previewCanArray[i].Height = TEXTBOX_HEIGHT;
                        previewCanArray[i].Width = TEXTBOX_WIDTH;

                        elementCounter++;
                    }
                    pastTablesTotal += tblDecorativeColumn.Count;
                    #endregion
                }

                if (ddlCategory.SelectedValue == "Door Frame Extrusion" || ddlCategory.SelectedValue == "All")
                {
                    #region DoorFrameExtrusion
                    for (int i = elementCounter; i < (tblDoorFrameExtrusion.Count + pastTablesTotal); i++) //adding elementCounter so that, if it starts above 0, will just do the .count value
                    {                                                                                    //past tables total is there so that the ending condition is in the proper # away from the start
                        datSelectDataSource.SelectCommand = "SELECT * FROM tblDoorFrameExtrusion WHERE dfeID=" + (i - pastTablesTotal);
                        tempDataView = (System.Data.DataView)datSelectDataSource.Select(System.Web.UI.DataSourceSelectArguments.Empty);
                        tempDoorFrameExtrusion.Populate(tempDoorFrameExtrusion.SelectAll(datDisplayDataSource, "tblDoorFrameExtrusion", tblDoorFrameExtrusion[i - pastTablesTotal][3].ToString()));

                        checkboxArray[i] = new CheckBox();
                        checkboxArray[i].ID = "tblDoorFrameExtrusionCheckBox" + i.ToString();

                        partNumArray[i] = new Label();
                        partNumArray[i].ID = "tblDoorFrameExtrusionPartNumLabel" + i.ToString();
                        partNumArray[i].Text = tempDoorFrameExtrusion.PartNumber;

                        partNameArray[i] = new Label();
                        partNameArray[i].ID = "tblDoorFrameExtrusionPartNameLabel" + i.ToString();
                        partNameArray[i].Text = tempDoorFrameExtrusion.DfeName;

                        currentUSArray[i] = new Label();
                        currentUSArray[i].ID = "tblDoorFrameExtrusionCurrentUSLabel" + i.ToString();
                        currentUSArray[i].Text = tempDoorFrameExtrusion.UsdPrice.ToString("N2");

                        currentCanArray[i] = new Label();
                        currentCanArray[i].ID = "tblDoorFrameExtrusionCurrentCanLabel" + i.ToString();
                        currentCanArray[i].Text = tempDoorFrameExtrusion.CadPrice.ToString("N2");

                        priceUSArray[i] = new TextBox();
                        priceUSArray[i].ID = "tblDoorFrameExtrusionPriceUSTextBox" + i.ToString();
                        priceUSArray[i].CssClass = "txtInputField";
                        priceUSArray[i].Height = TEXTBOX_HEIGHT;
                        priceUSArray[i].Width = TEXTBOX_WIDTH;

                        priceCanArray[i] = new TextBox();
                        priceCanArray[i].ID = "tblDoorFrameExtrusionPriceCanTextBox" + i.ToString();
                        priceCanArray[i].CssClass = "txtInputField";
                        priceCanArray[i].Height = TEXTBOX_HEIGHT;
                        priceCanArray[i].Width = TEXTBOX_WIDTH;

                        previewUSArray[i] = new TextBox();
                        previewUSArray[i].ID = "tblDoorFrameExtrusionPreviewUSLabel" + i.ToString();
                        previewUSArray[i].CssClass = "txtInputField";
                        previewUSArray[i].Height = TEXTBOX_HEIGHT;
                        previewUSArray[i].Width = TEXTBOX_WIDTH;

                        previewCanArray[i] = new TextBox();
                        previewCanArray[i].ID = "tblDoorFrameExtrusionPreviewCanLabel" + i.ToString();
                        previewCanArray[i].CssClass = "txtInputField";
                        previewCanArray[i].Height = TEXTBOX_HEIGHT;
                        previewCanArray[i].Width = TEXTBOX_WIDTH;

                        elementCounter++;
                    }
                    pastTablesTotal += tblDoorFrameExtrusion.Count;
                    #endregion
                }

                if (ddlCategory.SelectedValue == "Insulated Floors" || ddlCategory.SelectedValue == "All")
                {
                    #region InsulatedFloors
                    for (int i = elementCounter; i < (tblInsulatedFloors.Count + pastTablesTotal); i++) //adding elementCounter so that, if it starts above 0, will just do the .count value
                    {                                                                                    //past tables total is there so that the ending condition is in the proper # away from the start
                        datSelectDataSource.SelectCommand = "SELECT * FROM tblInsulatedFloors WHERE insulatedFloorID=" + (i - pastTablesTotal);
                        tempDataView = (System.Data.DataView)datSelectDataSource.Select(System.Web.UI.DataSourceSelectArguments.Empty);
                        tempInsulatedFloors.Populate(tempInsulatedFloors.SelectAll(datDisplayDataSource, "tblInsulatedFloors", tblInsulatedFloors[i - pastTablesTotal][4].ToString()));

                        checkboxArray[i] = new CheckBox();
                        checkboxArray[i].ID = "tblInsulatedFloorsCheckBox" + i.ToString();

                        partNumArray[i] = new Label();
                        partNumArray[i].ID = "tblInsulatedFloorsPartNumLabel" + i.ToString();
                        partNumArray[i].Text = tempInsulatedFloors.PartNumber;

                        partNameArray[i] = new Label();
                        partNameArray[i].ID = "tblInsulatedFloorsPartNameLabel" + i.ToString();
                        partNameArray[i].Text = tempInsulatedFloors.InsulatedFloorName;

                        currentUSArray[i] = new Label();
                        currentUSArray[i].ID = "tblInsulatedFloorsCurrentUSLabel" + i.ToString();
                        currentUSArray[i].Text = tempInsulatedFloors.InsulatedFloorUsdPrice.ToString("N2");

                        currentCanArray[i] = new Label();
                        currentCanArray[i].ID = "tblInsulatedFloorsCurrentCanLabel" + i.ToString();
                        currentCanArray[i].Text = tempInsulatedFloors.InsulatedFloorCadPrice.ToString("N2");

                        priceUSArray[i] = new TextBox();
                        priceUSArray[i].ID = "tblInsulatedFloorsPriceUSTextBox" + i.ToString();
                        priceUSArray[i].CssClass = "txtInputField";
                        priceUSArray[i].Height = TEXTBOX_HEIGHT;
                        priceUSArray[i].Width = TEXTBOX_WIDTH;

                        priceCanArray[i] = new TextBox();
                        priceCanArray[i].ID = "tblInsulatedFloorsPriceCanTextBox" + i.ToString();
                        priceCanArray[i].CssClass = "txtInputField";
                        priceCanArray[i].Height = TEXTBOX_HEIGHT;
                        priceCanArray[i].Width = TEXTBOX_WIDTH;

                        previewUSArray[i] = new TextBox();
                        previewUSArray[i].ID = "tblInsulatedFloorsPreviewUSLabel" + i.ToString();
                        previewUSArray[i].CssClass = "txtInputField";
                        previewUSArray[i].Height = TEXTBOX_HEIGHT;
                        previewUSArray[i].Width = TEXTBOX_WIDTH;

                        previewCanArray[i] = new TextBox();
                        previewCanArray[i].ID = "tblInsulatedFloorsPreviewCanLabel" + i.ToString();
                        previewCanArray[i].CssClass = "txtInputField";
                        previewCanArray[i].Height = TEXTBOX_HEIGHT;
                        previewCanArray[i].Width = TEXTBOX_WIDTH;

                        elementCounter++;
                    }
                    pastTablesTotal += tblInsulatedFloors.Count;
                    #endregion
                }

                if (ddlCategory.SelectedValue == "Roof Extrusions" || ddlCategory.SelectedValue == "All")
                {
                    #region RoofExtrusions
                    for (int i = elementCounter; i < (tblRoofExtrusions.Count + pastTablesTotal); i++) //adding elementCounter so that, if it starts above 0, will just do the .count value
                    {                                                                                    //past tables total is there so that the ending condition is in the proper # away from the start
                        datSelectDataSource.SelectCommand = "SELECT * FROM tblRoofExtrusions WHERE extrusionID=" + (i - pastTablesTotal);
                        tempDataView = (System.Data.DataView)datSelectDataSource.Select(System.Web.UI.DataSourceSelectArguments.Empty);
                        tempRoofExtrusions.Populate(tempRoofExtrusions.SelectAll(datDisplayDataSource, "tblRoofExtrusions", tblRoofExtrusions[i - pastTablesTotal][3].ToString()));

                        checkboxArray[i] = new CheckBox();
                        checkboxArray[i].ID = "tblRoofExtrusionsCheckBox" + i.ToString();

                        partNumArray[i] = new Label();
                        partNumArray[i].ID = "tblRoofExtrusionsPartNumLabel" + i.ToString();
                        partNumArray[i].Text = tempRoofExtrusions.ExtrusionNumber;

                        partNameArray[i] = new Label();
                        partNameArray[i].ID = "tblRoofExtrusionsPartNameLabel" + i.ToString();
                        partNameArray[i].Text = tempRoofExtrusions.ExtrusionName;

                        currentUSArray[i] = new Label();
                        currentUSArray[i].ID = "tblRoofExtrusionsCurrentUSLabel" + i.ToString();
                        currentUSArray[i].Text = tempRoofExtrusions.UsdPrice.ToString("N2");

                        currentCanArray[i] = new Label();
                        currentCanArray[i].ID = "tblRoofExtrusionsCurrentCanLabel" + i.ToString();
                        currentCanArray[i].Text = tempRoofExtrusions.CadPrice.ToString("N2");

                        priceUSArray[i] = new TextBox();
                        priceUSArray[i].ID = "tblRoofExtrusionsPriceUSTextBox" + i.ToString();
                        priceUSArray[i].CssClass = "txtInputField";
                        priceUSArray[i].Height = TEXTBOX_HEIGHT;
                        priceUSArray[i].Width = TEXTBOX_WIDTH;

                        priceCanArray[i] = new TextBox();
                        priceCanArray[i].ID = "tblRoofExtrusionsPriceCanTextBox" + i.ToString();
                        priceCanArray[i].CssClass = "txtInputField";
                        priceCanArray[i].Height = TEXTBOX_HEIGHT;
                        priceCanArray[i].Width = TEXTBOX_WIDTH;

                        previewUSArray[i] = new TextBox();
                        previewUSArray[i].ID = "tblRoofExtrusionsPreviewUSLabel" + i.ToString();
                        previewUSArray[i].CssClass = "txtInputField";
                        previewUSArray[i].Height = TEXTBOX_HEIGHT;
                        previewUSArray[i].Width = TEXTBOX_WIDTH;

                        previewCanArray[i] = new TextBox();
                        previewCanArray[i].ID = "tblRoofExtrusionsPreviewCanLabel" + i.ToString();
                        previewCanArray[i].CssClass = "txtInputField";
                        previewCanArray[i].Height = TEXTBOX_HEIGHT;
                        previewCanArray[i].Width = TEXTBOX_WIDTH;

                        elementCounter++;
                    }
                    pastTablesTotal += tblRoofExtrusions.Count;
                    #endregion
                }

                if (ddlCategory.SelectedValue == "Roof Panels" || ddlCategory.SelectedValue == "All")
                {
                    #region RoofPanels
                    for (int i = elementCounter; i < (tblRoofPanels.Count + pastTablesTotal); i++) //adding elementCounter so that, if it starts above 0, will just do the .count value
                    {                                                                                    //past tables total is there so that the ending condition is in the proper # away from the start
                        datSelectDataSource.SelectCommand = "SELECT * FROM tblRoofPanels WHERE panelId=" + (i - pastTablesTotal);
                        tempDataView = (System.Data.DataView)datSelectDataSource.Select(System.Web.UI.DataSourceSelectArguments.Empty);
                        tempRoofPanels.Populate(tempRoofPanels.SelectAll(datDisplayDataSource, "tblRoofPanels", tblRoofPanels[i - pastTablesTotal][6].ToString()));

                        checkboxArray[i] = new CheckBox();
                        checkboxArray[i].ID = "tblRoofPanelsCheckBox" + i.ToString();

                        partNumArray[i] = new Label();
                        partNumArray[i].ID = "tblRoofPanelsPartNumLabel" + i.ToString();
                        partNumArray[i].Text = tempRoofPanels.PartNumber;

                        partNameArray[i] = new Label();
                        partNameArray[i].ID = "tblRoofPanelsPartNameLabel" + i.ToString();
                        partNameArray[i].Text = tempRoofPanels.PanelName;

                        currentUSArray[i] = new Label();
                        currentUSArray[i].ID = "tblRoofPanelsCurrentUSLabel" + i.ToString();
                        currentUSArray[i].Text = tempRoofPanels.UsdPrice.ToString("N2");

                        currentCanArray[i] = new Label();
                        currentCanArray[i].ID = "tblRoofPanelsCurrentCanLabel" + i.ToString();
                        currentCanArray[i].Text = tempRoofPanels.CadPrice.ToString("N2");

                        priceUSArray[i] = new TextBox();
                        priceUSArray[i].ID = "tblRoofPanelsPriceUSTextBox" + i.ToString();
                        priceUSArray[i].CssClass = "txtInputField";
                        priceUSArray[i].Height = TEXTBOX_HEIGHT;
                        priceUSArray[i].Width = TEXTBOX_WIDTH;

                        priceCanArray[i] = new TextBox();
                        priceCanArray[i].ID = "tblRoofPanelsPriceCanTextBox" + i.ToString();
                        priceCanArray[i].CssClass = "txtInputField";
                        priceCanArray[i].Height = TEXTBOX_HEIGHT;
                        priceCanArray[i].Width = TEXTBOX_WIDTH;

                        previewUSArray[i] = new TextBox();
                        previewUSArray[i].ID = "tblRoofPanelsPreviewUSLabel" + i.ToString();
                        previewUSArray[i].CssClass = "txtInputField";
                        previewUSArray[i].Height = TEXTBOX_HEIGHT;
                        previewUSArray[i].Width = TEXTBOX_WIDTH;

                        previewCanArray[i] = new TextBox();
                        previewCanArray[i].ID = "tblRoofPanelsPreviewCanLabel" + i.ToString();
                        previewCanArray[i].CssClass = "txtInputField";
                        previewCanArray[i].Height = TEXTBOX_HEIGHT;
                        previewCanArray[i].Width = TEXTBOX_WIDTH;

                        elementCounter++;
                    }
                    pastTablesTotal += tblRoofPanels.Count;
                    #endregion
                }

                if (ddlCategory.SelectedValue == "Screen Roll" || ddlCategory.SelectedValue == "All")
                {
                    #region ScreenRoll
                    for (int i = elementCounter; i < (tblScreenRoll.Count + pastTablesTotal); i++) //adding elementCounter so that, if it starts above 0, will just do the .count value
                    {                                                                                    //past tables total is there so that the ending condition is in the proper # away from the start
                        datSelectDataSource.SelectCommand = "SELECT * FROM tblScreenRoll WHERE rollID=" + (i - pastTablesTotal);
                        tempDataView = (System.Data.DataView)datSelectDataSource.Select(System.Web.UI.DataSourceSelectArguments.Empty);
                        tempScreenRoll.Populate(tempScreenRoll.SelectAll(datDisplayDataSource, "tblScreenRoll", tblScreenRoll[i - pastTablesTotal][2].ToString()));

                        checkboxArray[i] = new CheckBox();
                        checkboxArray[i].ID = "tblScreenRollCheckBox" + i.ToString();

                        partNumArray[i] = new Label();
                        partNumArray[i].ID = "tblScreenRollPartNumLabel" + i.ToString();
                        partNumArray[i].Text = tempScreenRoll.PartNumber;

                        partNameArray[i] = new Label();
                        partNameArray[i].ID = "tblScreenRollPartNameLabel" + i.ToString();
                        partNameArray[i].Text = tempScreenRoll.ScreenRollName;

                        currentUSArray[i] = new Label();
                        currentUSArray[i].ID = "tblScreenRollCurrentUSLabel" + i.ToString();
                        currentUSArray[i].Text = tempScreenRoll.UsdPrice.ToString("N2");

                        currentCanArray[i] = new Label();
                        currentCanArray[i].ID = "tblScreenRollCurrentCanLabel" + i.ToString();
                        currentCanArray[i].Text = tempScreenRoll.CadPrice.ToString("N2");

                        priceUSArray[i] = new TextBox();
                        priceUSArray[i].ID = "tblScreenRollPriceUSTextBox" + i.ToString();
                        priceUSArray[i].CssClass = "txtInputField";
                        priceUSArray[i].Height = TEXTBOX_HEIGHT;
                        priceUSArray[i].Width = TEXTBOX_WIDTH;

                        priceCanArray[i] = new TextBox();
                        priceCanArray[i].ID = "tblScreenRollPriceCanTextBox" + i.ToString();
                        priceCanArray[i].CssClass = "txtInputField";
                        priceCanArray[i].Height = TEXTBOX_HEIGHT;
                        priceCanArray[i].Width = TEXTBOX_WIDTH;

                        previewUSArray[i] = new TextBox();
                        previewUSArray[i].ID = "tblScreenRollPreviewUSLabel" + i.ToString();
                        previewUSArray[i].CssClass = "txtInputField";
                        previewUSArray[i].Height = TEXTBOX_HEIGHT;
                        previewUSArray[i].Width = TEXTBOX_WIDTH;

                        previewCanArray[i] = new TextBox();
                        previewCanArray[i].ID = "tblScreenRollPreviewCanLabel" + i.ToString();
                        previewCanArray[i].CssClass = "txtInputField";
                        previewCanArray[i].Height = TEXTBOX_HEIGHT;
                        previewCanArray[i].Width = TEXTBOX_WIDTH;

                        elementCounter++;
                    }
                    pastTablesTotal += tblScreenRoll.Count;
                    #endregion
                }

                if (ddlCategory.SelectedValue == "Suncrylic Roof" || ddlCategory.SelectedValue == "All")
                {
                    #region SuncrylicRoof
                    for (int i = elementCounter; i < (tblSuncrylicRoof.Count + pastTablesTotal); i++) //adding elementCounter so that, if it starts above 0, will just do the .count value
                    {                                                                                    //past tables total is there so that the ending condition is in the proper # away from the start
                        datSelectDataSource.SelectCommand = "SELECT * FROM tblSuncrylicRoof WHERE suncrylicRoofID=" + (i - pastTablesTotal);
                        tempDataView = (System.Data.DataView)datSelectDataSource.Select(System.Web.UI.DataSourceSelectArguments.Empty);
                        tempSuncrylicRoof.Populate(tempSuncrylicRoof.SelectAll(datDisplayDataSource, "tblSuncrylicRoof", tblSuncrylicRoof[i - pastTablesTotal][3].ToString()));

                        checkboxArray[i] = new CheckBox();
                        checkboxArray[i].ID = "tblSuncrylicRoofCheckBox" + i.ToString();

                        partNumArray[i] = new Label();
                        partNumArray[i].ID = "tblSuncrylicRoofPartNumLabel" + i.ToString();
                        partNumArray[i].Text = tempSuncrylicRoof.PartNumber;

                        partNameArray[i] = new Label();
                        partNameArray[i].ID = "tblSuncrylicRoofPartNameLabel" + i.ToString();
                        partNameArray[i].Text = tempSuncrylicRoof.SuncrylicName;

                        currentUSArray[i] = new Label();
                        currentUSArray[i].ID = "tblSuncrylicRoofCurrentUSLabel" + i.ToString();
                        currentUSArray[i].Text = tempSuncrylicRoof.UsdPrice.ToString("N2");

                        currentCanArray[i] = new Label();
                        currentCanArray[i].ID = "tblSuncrylicRoofCurrentCanLabel" + i.ToString();
                        currentCanArray[i].Text = tempSuncrylicRoof.CadPrice.ToString("N2");

                        priceUSArray[i] = new TextBox();
                        priceUSArray[i].ID = "tblSuncrylicRoofPriceUSTextBox" + i.ToString();
                        priceUSArray[i].CssClass = "txtInputField";
                        priceUSArray[i].Height = TEXTBOX_HEIGHT;
                        priceUSArray[i].Width = TEXTBOX_WIDTH;

                        priceCanArray[i] = new TextBox();
                        priceCanArray[i].ID = "tblSuncrylicRoofPriceCanTextBox" + i.ToString();
                        priceCanArray[i].CssClass = "txtInputField";
                        priceCanArray[i].Height = TEXTBOX_HEIGHT;
                        priceCanArray[i].Width = TEXTBOX_WIDTH;

                        previewUSArray[i] = new TextBox();
                        previewUSArray[i].ID = "tblSuncrylicRoofPreviewUSLabel" + i.ToString();
                        previewUSArray[i].CssClass = "txtInputField";
                        previewUSArray[i].Height = TEXTBOX_HEIGHT;
                        previewUSArray[i].Width = TEXTBOX_WIDTH;

                        previewCanArray[i] = new TextBox();
                        previewCanArray[i].ID = "tblSuncrylicRoofPreviewCanLabel" + i.ToString();
                        previewCanArray[i].CssClass = "txtInputField";
                        previewCanArray[i].Height = TEXTBOX_HEIGHT;
                        previewCanArray[i].Width = TEXTBOX_WIDTH;

                        elementCounter++;
                    }
                    pastTablesTotal += tblSuncrylicRoof.Count;
                    #endregion
                }

                if (ddlCategory.SelectedValue == "Sunrail 1000" || ddlCategory.SelectedValue == "All")
                {
                    #region Sunrail1000
                    for (int i = elementCounter; i < (tblSunrail1000.Count + pastTablesTotal); i++) //adding elementCounter so that, if it starts above 0, will just do the .count value
                    {                                                                                    //past tables total is there so that the ending condition is in the proper # away from the start
                        datSelectDataSource.SelectCommand = "SELECT * FROM tblSunrail1000 WHERE sr1000ID=" + (i - pastTablesTotal);
                        tempDataView = (System.Data.DataView)datSelectDataSource.Select(System.Web.UI.DataSourceSelectArguments.Empty);
                        tempSunrail1000.Populate(tempSunrail1000.SelectAll(datDisplayDataSource, "tblSunrail1000", tblSunrail1000[i - pastTablesTotal][3].ToString()));

                        checkboxArray[i] = new CheckBox();
                        checkboxArray[i].ID = "tblSunrail1000CheckBox" + i.ToString();

                        partNumArray[i] = new Label();
                        partNumArray[i].ID = "tblSunrail1000PartNumLabel" + i.ToString();
                        partNumArray[i].Text = tempSunrail1000.PartNumber;

                        partNameArray[i] = new Label();
                        partNameArray[i].ID = "tblSunrail1000PartNameLabel" + i.ToString();
                        partNameArray[i].Text = tempSunrail1000.Sunrail1000Name;

                        currentUSArray[i] = new Label();
                        currentUSArray[i].ID = "tblSunrail1000CurrentUSLabel" + i.ToString();
                        currentUSArray[i].Text = tempSunrail1000.Sunrail1000UsdPrice.ToString("N2");

                        currentCanArray[i] = new Label();
                        currentCanArray[i].ID = "tblSunrail1000CurrentCanLabel" + i.ToString();
                        currentCanArray[i].Text = tempSunrail1000.Sunrail1000CadPrice.ToString("N2");

                        priceUSArray[i] = new TextBox();
                        priceUSArray[i].ID = "tblSunrail1000PriceUSTextBox" + i.ToString();
                        priceUSArray[i].CssClass = "txtInputField";
                        priceUSArray[i].Height = TEXTBOX_HEIGHT;
                        priceUSArray[i].Width = TEXTBOX_WIDTH;

                        priceCanArray[i] = new TextBox();
                        priceCanArray[i].ID = "tblSunrail1000PriceCanTextBox" + i.ToString();
                        priceCanArray[i].CssClass = "txtInputField";
                        priceCanArray[i].Height = TEXTBOX_HEIGHT;
                        priceCanArray[i].Width = TEXTBOX_WIDTH;

                        previewUSArray[i] = new TextBox();
                        previewUSArray[i].ID = "tblSunrail1000PreviewUSLabel" + i.ToString();
                        previewUSArray[i].CssClass = "txtInputField";
                        previewUSArray[i].Height = TEXTBOX_HEIGHT;
                        previewUSArray[i].Width = TEXTBOX_WIDTH;

                        previewCanArray[i] = new TextBox();
                        previewCanArray[i].ID = "tblSunrail1000PreviewCanLabel" + i.ToString();
                        previewCanArray[i].CssClass = "txtInputField";
                        previewCanArray[i].Height = TEXTBOX_HEIGHT;
                        previewCanArray[i].Width = TEXTBOX_WIDTH;

                        elementCounter++;
                    }
                    pastTablesTotal += tblSunrail1000.Count;
                    #endregion
                }

                if (ddlCategory.SelectedValue == "Sunrail 300" || ddlCategory.SelectedValue == "All")
                {
                    #region Sunrail300
                    
                    for (int i = elementCounter; i < (tblSunrail300.Count + pastTablesTotal); i++) //adding elementCounter so that, if it starts above 0, will just do the .count value
                    {                                                                                    //past tables total is there so that the ending condition is in the proper # away from the start
                        datSelectDataSource.SelectCommand = "SELECT * FROM tblSunrail300 WHERE sr300ID=" + (i - pastTablesTotal);
                        tempDataView = (System.Data.DataView)datSelectDataSource.Select(System.Web.UI.DataSourceSelectArguments.Empty);
                        tempSunrail300.Populate(tempSunrail300.SelectAll(datDisplayDataSource, "tblSunrail300", tblSunrail300[i - pastTablesTotal][3].ToString()));

                        checkboxArray[i] = new CheckBox();
                        checkboxArray[i].ID = "tblSunrail300CheckBox" + i.ToString();

                        partNumArray[i] = new Label();
                        partNumArray[i].ID = "tblSunrail300PartNumLabel" + i.ToString();
                        partNumArray[i].Text = tempSunrail300.PartNumber;

                        partNameArray[i] = new Label();
                        partNameArray[i].ID = "tblSunrail300PartNameLabel" + i.ToString();
                        partNameArray[i].Text = tempSunrail300.Sunrail300Name;

                        currentUSArray[i] = new Label();
                        currentUSArray[i].ID = "tblSunrail300CurrentUSLabel" + i.ToString();
                        currentUSArray[i].Text = tempSunrail300.Sunrail300UsdPrice.ToString("N2");

                        currentCanArray[i] = new Label();
                        currentCanArray[i].ID = "tblSunrail300CurrentCanLabel" + i.ToString();
                        currentCanArray[i].Text = tempSunrail300.Sunrail300CadPrice.ToString("N2");

                        priceUSArray[i] = new TextBox();
                        priceUSArray[i].ID = "tblSunrail300PriceUSTextBox" + i.ToString();
                            priceUSArray[i].CssClass = "txtInputField";
                            priceUSArray[i].Height = TEXTBOX_HEIGHT;
                            priceUSArray[i].Width = TEXTBOX_WIDTH;

                        priceCanArray[i] = new TextBox();
                        priceCanArray[i].ID = "tblSunrail300PriceCanTextBox" + i.ToString();
                            priceCanArray[i].CssClass = "txtInputField";
                            priceCanArray[i].Height = TEXTBOX_HEIGHT;
                            priceCanArray[i].Width = TEXTBOX_WIDTH;

                        previewUSArray[i] = new TextBox();
                        previewUSArray[i].ID = "tblSunrail300PreviewUSLabel" + i.ToString();
                            previewUSArray[i].CssClass = "txtInputField";
                            previewUSArray[i].Height = TEXTBOX_HEIGHT;
                            previewUSArray[i].Width = TEXTBOX_WIDTH;

                        previewCanArray[i] = new TextBox();
                        previewCanArray[i].ID = "tblSunrail300PreviewCanLabel" + i.ToString();
                            previewCanArray[i].CssClass = "txtInputField";
                            previewCanArray[i].Height = TEXTBOX_HEIGHT;
                            previewCanArray[i].Width = TEXTBOX_WIDTH;

                        elementCounter++;
                    }
                    pastTablesTotal += tblSunrail300.Count;
            
                    #endregion
                }

                if (ddlCategory.SelectedValue == "Sunrail 300 Accessories" || ddlCategory.SelectedValue == "All")
                {
                    #region Sunrail300Accessories
                    for (int i = elementCounter; i < (tblSunrail300Accessories.Count + pastTablesTotal); i++) //adding elementCounter so that, if it starts above 0, will just do the .count value
                    {                                                                                    //past tables total is there so that the ending condition is in the proper # away from the start
                        datSelectDataSource.SelectCommand = "SELECT * FROM tblSunrail300Accessories WHERE srAccID=" + (i - pastTablesTotal);
                        tempDataView = (System.Data.DataView)datSelectDataSource.Select(System.Web.UI.DataSourceSelectArguments.Empty);
                        tempSunrail300Accessories.Populate(tempSunrail300Accessories.SelectAll(datDisplayDataSource, "tblSunrail300Accessories", tblSunrail300Accessories[i - pastTablesTotal][3].ToString()));

                        checkboxArray[i] = new CheckBox();
                        checkboxArray[i].ID = "tblSunrail300AccessoriesCheckBox" + i.ToString();

                        partNumArray[i] = new Label();
                        partNumArray[i].ID = "tblSunrail300AccessoriesPartNumLabel" + i.ToString();
                        partNumArray[i].Text = tempSunrail300Accessories.PartNumber;

                        partNameArray[i] = new Label();
                        partNameArray[i].ID = "tblSunrail300AccessoriesPartNameLabel" + i.ToString();
                        partNameArray[i].Text = tempSunrail300Accessories.Sunrail300AccessoriesName;

                        currentUSArray[i] = new Label();
                        currentUSArray[i].ID = "tblSunrail300AccessoriesCurrentUSLabel" + i.ToString();
                        currentUSArray[i].Text = tempSunrail300Accessories.Sunrail300AccessoriesUsdPrice.ToString("N2");

                        currentCanArray[i] = new Label();
                        currentCanArray[i].ID = "tblSunrail300AccessoriesCurrentCanLabel" + i.ToString();
                        currentCanArray[i].Text = tempSunrail300Accessories.Sunrail300AccessoriesCadPrice.ToString("N2");

                        priceUSArray[i] = new TextBox();
                        priceUSArray[i].ID = "tblSunrail300AccessoriesPriceUSTextBox" + i.ToString();
                        priceUSArray[i].CssClass = "txtInputField";
                        priceUSArray[i].Height = TEXTBOX_HEIGHT;
                        priceUSArray[i].Width = TEXTBOX_WIDTH;

                        priceCanArray[i] = new TextBox();
                        priceCanArray[i].ID = "tblSunrail300AccessoriesPriceCanTextBox" + i.ToString();
                        priceCanArray[i].CssClass = "txtInputField";
                        priceCanArray[i].Height = TEXTBOX_HEIGHT;
                        priceCanArray[i].Width = TEXTBOX_WIDTH;

                        previewUSArray[i] = new TextBox();
                        previewUSArray[i].ID = "tblSunrail300AccessoriesPreviewUSLabel" + i.ToString();
                        previewUSArray[i].CssClass = "txtInputField";
                        previewUSArray[i].Height = TEXTBOX_HEIGHT;
                        previewUSArray[i].Width = TEXTBOX_WIDTH;

                        previewCanArray[i] = new TextBox();
                        previewCanArray[i].ID = "tblSunrail300AccessoriesPreviewCanLabel" + i.ToString();
                        previewCanArray[i].CssClass = "txtInputField";
                        previewCanArray[i].Height = TEXTBOX_HEIGHT;
                        previewCanArray[i].Width = TEXTBOX_WIDTH;

                        elementCounter++;
                    }
                    pastTablesTotal += tblSunrail300Accessories.Count;
                    #endregion
                }

                if (ddlCategory.SelectedValue == "Sunrail 400" || ddlCategory.SelectedValue == "All")
                {
                    #region Sunrail400
                    for (int i = elementCounter; i < (tblSunrail400.Count + pastTablesTotal); i++) //adding elementCounter so that, if it starts above 0, will just do the .count value
                    {                                                                                    //past tables total is there so that the ending condition is in the proper # away from the start
                        datSelectDataSource.SelectCommand = "SELECT * FROM tblSunrail400 WHERE sr400ID=" + (i - pastTablesTotal);
                        tempDataView = (System.Data.DataView)datSelectDataSource.Select(System.Web.UI.DataSourceSelectArguments.Empty);
                        tempSunrail400.Populate(tempSunrail400.SelectAll(datDisplayDataSource, "tblSunrail400", tblSunrail400[i - pastTablesTotal][3].ToString()));

                        checkboxArray[i] = new CheckBox();
                        checkboxArray[i].ID = "tblSunrail400CheckBox" + i.ToString();

                        partNumArray[i] = new Label();
                        partNumArray[i].ID = "tblSunrail400PartNumLabel" + i.ToString();
                        partNumArray[i].Text = tempSunrail400.PartNumber;

                        partNameArray[i] = new Label();
                        partNameArray[i].ID = "tblSunrail400PartNameLabel" + i.ToString();
                        partNameArray[i].Text = tempSunrail400.Sunrail400Name;

                        currentUSArray[i] = new Label();
                        currentUSArray[i].ID = "tblSunrail400CurrentUSLabel" + i.ToString();
                        currentUSArray[i].Text = tempSunrail400.Sunrail400UsdPrice.ToString("N2");

                        currentCanArray[i] = new Label();
                        currentCanArray[i].ID = "tblSunrail400CurrentCanLabel" + i.ToString();
                        currentCanArray[i].Text = tempSunrail400.Sunrail400CadPrice.ToString("N2");

                        priceUSArray[i] = new TextBox();
                        priceUSArray[i].ID = "tblSunrail400PriceUSTextBox" + i.ToString();
                        priceUSArray[i].CssClass = "txtInputField";
                        priceUSArray[i].Height = TEXTBOX_HEIGHT;
                        priceUSArray[i].Width = TEXTBOX_WIDTH;

                        priceCanArray[i] = new TextBox();
                        priceCanArray[i].ID = "tblSunrail400PriceCanTextBox" + i.ToString();
                        priceCanArray[i].CssClass = "txtInputField";
                        priceCanArray[i].Height = TEXTBOX_HEIGHT;
                        priceCanArray[i].Width = TEXTBOX_WIDTH;

                        previewUSArray[i] = new TextBox();
                        previewUSArray[i].ID = "tblSunrail400PreviewUSLabel" + i.ToString();
                        previewUSArray[i].CssClass = "txtInputField";
                        previewUSArray[i].Height = TEXTBOX_HEIGHT;
                        previewUSArray[i].Width = TEXTBOX_WIDTH;

                        previewCanArray[i] = new TextBox();
                        previewCanArray[i].ID = "tblSunrail400PreviewCanLabel" + i.ToString();
                        previewCanArray[i].CssClass = "txtInputField";
                        previewCanArray[i].Height = TEXTBOX_HEIGHT;
                        previewCanArray[i].Width = TEXTBOX_WIDTH;

                        elementCounter++;
                    }
                    pastTablesTotal += tblSunrail400.Count;
                    #endregion
                }

                if (ddlCategory.SelectedValue == "Vinyl Roll" || ddlCategory.SelectedValue == "All")
                {
                    #region VinylRoll
                    for (int i = elementCounter; i < (tblVinylRoll.Count + pastTablesTotal); i++) //adding elementCounter so that, if it starts above 0, will just do the .count value
                    {                                                                                    //past tables total is there so that the ending condition is in the proper # away from the start
                        datSelectDataSource.SelectCommand = "SELECT * FROM tblVinylRoll WHERE rollID=" + (i - pastTablesTotal);
                        tempDataView = (System.Data.DataView)datSelectDataSource.Select(System.Web.UI.DataSourceSelectArguments.Empty);
                        tempVinylRoll.Populate(tempVinylRoll.SelectAll(datDisplayDataSource, "tblVinylRoll", tblVinylRoll[i - pastTablesTotal][2].ToString()));

                        checkboxArray[i] = new CheckBox();
                        checkboxArray[i].ID = "tblVinylRollCheckBox" + i.ToString();

                        partNumArray[i] = new Label();
                        partNumArray[i].ID = "tblVinylRollPartNumLabel" + i.ToString();
                        partNumArray[i].Text = tempVinylRoll.PartNumber;

                        partNameArray[i] = new Label();
                        partNameArray[i].ID = "tblVinylRollPartNameLabel" + i.ToString();
                        partNameArray[i].Text = tempVinylRoll.VinylRollName;

                        currentUSArray[i] = new Label();
                        currentUSArray[i].ID = "tblVinylRollCurrentUSLabel" + i.ToString();
                        currentUSArray[i].Text = tempVinylRoll.UsdPrice.ToString("N2");

                        currentCanArray[i] = new Label();
                        currentCanArray[i].ID = "tblVinylRollCurrentCanLabel" + i.ToString();
                        currentCanArray[i].Text = tempVinylRoll.CadPrice.ToString("N2");

                        priceUSArray[i] = new TextBox();
                        priceUSArray[i].ID = "tblVinylRollPriceUSTextBox" + i.ToString();
                        priceUSArray[i].CssClass = "txtInputField";
                        priceUSArray[i].Height = TEXTBOX_HEIGHT;
                        priceUSArray[i].Width = TEXTBOX_WIDTH;

                        priceCanArray[i] = new TextBox();
                        priceCanArray[i].ID = "tblVinylRollPriceCanTextBox" + i.ToString();
                        priceCanArray[i].CssClass = "txtInputField";
                        priceCanArray[i].Height = TEXTBOX_HEIGHT;
                        priceCanArray[i].Width = TEXTBOX_WIDTH;

                        previewUSArray[i] = new TextBox();
                        previewUSArray[i].ID = "tblVinylRollPreviewUSLabel" + i.ToString();
                        previewUSArray[i].CssClass = "txtInputField";
                        previewUSArray[i].Height = TEXTBOX_HEIGHT;
                        previewUSArray[i].Width = TEXTBOX_WIDTH;

                        previewCanArray[i] = new TextBox();
                        previewCanArray[i].ID = "tblVinylRollPreviewCanLabel" + i.ToString();
                        previewCanArray[i].CssClass = "txtInputField";
                        previewCanArray[i].Height = TEXTBOX_HEIGHT;
                        previewCanArray[i].Width = TEXTBOX_WIDTH;

                        elementCounter++;
                    }
                    pastTablesTotal += tblVinylRoll.Count;
                    #endregion
                }

                if (ddlCategory.SelectedValue == "Wall Extrusions" || ddlCategory.SelectedValue == "All")
                {
                    #region WallExtrusions
                    for (int i = elementCounter; i < (tblWallExtrusions.Count + pastTablesTotal); i++) //adding elementCounter so that, if it starts above 0, will just do the .count value
                    {                                                                                    //past tables total is there so that the ending condition is in the proper # away from the start
                        datSelectDataSource.SelectCommand = "SELECT * FROM tblWallExtrusions WHERE wallExtrusionID=" + (i - pastTablesTotal);
                        tempDataView = (System.Data.DataView)datSelectDataSource.Select(System.Web.UI.DataSourceSelectArguments.Empty);
                        tempWallExtrusions.Populate(tempWallExtrusions.SelectAll(datDisplayDataSource, "tblWallExtrusions", tblWallExtrusions[i - pastTablesTotal][3].ToString()));

                        checkboxArray[i] = new CheckBox();
                        checkboxArray[i].ID = "tblWallExtrusionsCheckBox" + i.ToString();

                        partNumArray[i] = new Label();
                        partNumArray[i].ID = "tblWallExtrusionsPartNumLabel" + i.ToString();
                        partNumArray[i].Text = tempWallExtrusions.PartNumber;

                        partNameArray[i] = new Label();
                        partNameArray[i].ID = "tblWallExtrusionsPartNameLabel" + i.ToString();
                        partNameArray[i].Text = tempWallExtrusions.WallExtrusionName;

                        currentUSArray[i] = new Label();
                        currentUSArray[i].ID = "tblWallExtrusionsCurrentUSLabel" + i.ToString();
                        currentUSArray[i].Text = tempWallExtrusions.UsdPrice.ToString("N2");

                        currentCanArray[i] = new Label();
                        currentCanArray[i].ID = "tblVinylRollCurrentCanLabel" + i.ToString();
                        currentCanArray[i].Text = tempWallExtrusions.CadPrice.ToString("N2");

                        priceUSArray[i] = new TextBox();
                        priceUSArray[i].ID = "tblWallExtrusionsPriceUSTextBox" + i.ToString();
                        priceUSArray[i].CssClass = "txtInputField";
                        priceUSArray[i].Height = TEXTBOX_HEIGHT;
                        priceUSArray[i].Width = TEXTBOX_WIDTH;

                        priceCanArray[i] = new TextBox();
                        priceCanArray[i].ID = "tblWallExtrusionsPriceCanTextBox" + i.ToString();
                        priceCanArray[i].CssClass = "txtInputField";
                        priceCanArray[i].Height = TEXTBOX_HEIGHT;
                        priceCanArray[i].Width = TEXTBOX_WIDTH;

                        previewUSArray[i] = new TextBox();
                        previewUSArray[i].ID = "tblWallExtrusionsPreviewUSLabel" + i.ToString();
                        previewUSArray[i].CssClass = "txtInputField";
                        previewUSArray[i].Height = TEXTBOX_HEIGHT;
                        previewUSArray[i].Width = TEXTBOX_WIDTH;

                        previewCanArray[i] = new TextBox();
                        previewCanArray[i].ID = "tblWallExtrusionsPreviewCanLabel" + i.ToString();
                        previewCanArray[i].CssClass = "txtInputField";
                        previewCanArray[i].Height = TEXTBOX_HEIGHT;
                        previewCanArray[i].Width = TEXTBOX_WIDTH;

                        elementCounter++;
                    }
                    pastTablesTotal += tblWallExtrusions.Count;
                    #endregion
                }

                if (ddlCategory.SelectedValue == "Wall Panels" || ddlCategory.SelectedValue == "All")
                {
                    #region WallPanels
                    //
                    //
                    //
                    // CHANGETHISCODE - hardcoded for sunrail300 fixing
                    //
                    //totalElements = 440;
                    //
                    //
                    //
                    //
                    //
                    for (int i = elementCounter; i < totalElements; i++) //adding elementCounter so that, if it starts above 0, will just do the .count value
                    {                                                                                    //past tables total is there so that the ending condition is in the proper # away from the start
                        datSelectDataSource.SelectCommand = "SELECT * FROM tblWallPanels WHERE wallPanelID=" + (i - pastTablesTotal);
                        tempDataView = (System.Data.DataView)datSelectDataSource.Select(System.Web.UI.DataSourceSelectArguments.Empty);
                        tempWallPanels.Populate(tempWallPanels.SelectAll(datDisplayDataSource, "tblWallPanels", tblWallPanels[i - pastTablesTotal][6].ToString()));

                        checkboxArray[i] = new CheckBox();
                        checkboxArray[i].ID = "tblWallPanelsCheckBox" + i.ToString();

                        partNumArray[i] = new Label();
                        partNumArray[i].ID = "tblWallPanelsPartNumLabel" + i.ToString();
                        partNumArray[i].Text = tempWallPanels.WallPanelNumber;

                        partNameArray[i] = new Label();
                        partNameArray[i].ID = "tblWallPanelsPartNameLabel" + i.ToString();
                        partNameArray[i].Text = tempWallPanels.WallPanelName;

                        currentUSArray[i] = new Label();
                        currentUSArray[i].ID = "tblWallPanelsCurrentUSLabel" + i.ToString();
                        currentUSArray[i].Text = tempWallPanels.UsdPrice.ToString("N2");

                        currentCanArray[i] = new Label();
                        currentCanArray[i].ID = "tblWallPanelsCurrentCanLabel" + i.ToString();
                        currentCanArray[i].Text = tempWallPanels.CadPrice.ToString("N2");

                        priceUSArray[i] = new TextBox();
                        priceUSArray[i].ID = "tblWallPanelsPriceUSTextBox" + i.ToString();
                        priceUSArray[i].CssClass = "txtInputField";
                        priceUSArray[i].Height = TEXTBOX_HEIGHT;
                        priceUSArray[i].Width = TEXTBOX_WIDTH;

                        priceCanArray[i] = new TextBox();
                        priceCanArray[i].ID = "tblWallPanelsPriceCanTextBox" + i.ToString();
                        priceCanArray[i].CssClass = "txtInputField";
                        priceCanArray[i].Height = TEXTBOX_HEIGHT;
                        priceCanArray[i].Width = TEXTBOX_WIDTH;

                        previewUSArray[i] = new TextBox();
                        previewUSArray[i].ID = "tblWallPanelsPreviewUSLabel" + i.ToString();
                        previewUSArray[i].CssClass = "txtInputField";
                        previewUSArray[i].Height = TEXTBOX_HEIGHT;
                        previewUSArray[i].Width = TEXTBOX_WIDTH;

                        previewCanArray[i] = new TextBox();
                        previewCanArray[i].ID = "tblWallPanelsPreviewCanLabel" + i.ToString();
                        previewCanArray[i].CssClass = "txtInputField";
                        previewCanArray[i].Height = TEXTBOX_HEIGHT;
                        previewCanArray[i].Width = TEXTBOX_WIDTH;

                        elementCounter++;
                    }
                    pastTablesTotal += tblWallPanels.Count;
                    #endregion
                }
                #endregion

                #region generateRows

                //create table row and cells for adding record to the page
                TableRow tempRow;
                TableCell checkboxArrayCell;
                TableCell partNumArrayCell;
                TableCell partNameArrayCell;
                TableCell currentUSArrayCell;
                TableCell currentCanArrayCell;
                TableCell priceUSArrayCell;
                TableCell priceCanArrayCell;
                TableCell previewUSArrayCell;
                TableCell previewCanArrayCell;

                for (int i = 0; i < totalElements; i++) //hard coded 501 until Sunrail300 fixed CHANGETHISCODE
                {
                    tempRow = new TableRow(); //create a new row

                    //add each control by creating a new cell for the row, and adding to it.
                    checkboxArrayCell = new TableCell();
                    checkboxArrayCell.Controls.Add(checkboxArray[i]);
                    tempRow.Cells.Add(checkboxArrayCell);

                    partNumArrayCell = new TableCell();
                    partNumArrayCell.Controls.Add(partNumArray[i]);
                    tempRow.Cells.Add(partNumArrayCell);

                    partNameArrayCell = new TableCell();
                    partNameArrayCell.Controls.Add(partNameArray[i]);
                    tempRow.Cells.Add(partNameArrayCell);

                    currentUSArrayCell = new TableCell();
                    currentUSArrayCell.CssClass = "align-center";
                    currentUSArrayCell.Controls.Add(currentUSArray[i]);
                    tempRow.Cells.Add(currentUSArrayCell);

                    currentCanArrayCell = new TableCell();
                    currentCanArrayCell.CssClass = "align-center";
                    currentCanArrayCell.Controls.Add(currentCanArray[i]);
                    tempRow.Cells.Add(currentCanArrayCell);

                    priceUSArrayCell = new TableCell();
                    priceUSArrayCell.Controls.Add(priceUSArray[i]);
                    tempRow.CssClass = "tdTxtInputUS";
                    tempRow.Cells.Add(priceUSArrayCell);

                    priceCanArrayCell = new TableCell();
                    priceCanArrayCell.Controls.Add(priceCanArray[i]);
                    tempRow.CssClass = "tdTxtInputCAN";
                    tempRow.Cells.Add(priceCanArrayCell);

                    previewUSArrayCell = new TableCell();
                    previewUSArrayCell.Controls.Add(previewUSArray[i]);
                    tempRow.CssClass = "tdTxtInputUS";
                    tempRow.Cells.Add(previewUSArrayCell);

                    previewCanArrayCell = new TableCell();
                    previewCanArrayCell.Controls.Add(previewCanArray[i]);
                    tempRow.CssClass = "tdTxtInputCAN";
                    tempRow.Cells.Add(previewCanArrayCell);

                    tblPriceGrid.Controls.Add(tempRow);
                }
                #endregion

            for (int i = 0; i < totalElements; i++) //fill the 'last' arrays, which are used in checking for changes.  Blank for first time
            {
                lastAdjustedUS[i] = priceUSArray[i].Text;
                lastAdjustedCan[i] = priceCanArray[i].Text;
                lastCalculatedUS[i] = previewUSArray[i].Text;
                lastCalculatedCan[i] = previewCanArray[i].Text;
            }
        }
        
        //returns to main menu
        protected void btnMainMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("ComponentMenu.aspx");
        }

        //if update button is clicked, find partname and send to updateRecord
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (validatePrices() == "")
            {
                for (int i = 0; i < totalElements; i++) //loop for all elements
                {
                    if (checkboxArray[i].Checked == true) //only increase if checked (and not apply all)
                    {
                        updateRecord(i, partNumArray[i].Text);
                    }
                }
            }
            else
            {
                //
                //
                //
                // add code to display error message
                //
                //CHANGETHISCODE
                //
                //
                //
            }
        }

        /// <summary>
        /// Being given an integer number for location in #of elements, and part number, will update the table
        /// </summary>
        /// <param name="location"></param>
        /// The location in the arrays of records
        /// <param name="partName"></param>
        /// The name of the part
        protected void updateRecord(int location, string partNum)
        {
            int tablePosition=0; //will find which element of tableStarts it is held in, to find which table to update from tableNames
            if (ddlCategory.SelectedValue == "All")
            {
                for (int i = 0; i < tableStarts.Length; i++) //loop for each table
                {
                    if (location < tableStarts[i]) //if the location is lower (location is at 63, but this table starts at 85) you've gone too far, break loop and keep current position
                    {
                        break;
                    }
                    tablePosition = i;
                }
                           
                if (previewUSArray[location].Text != "") //if its a US entry, update usdprice and adjust on-screen controls
                {
                    datSelectDataSource.UpdateCommand = "UPDATE " + tableNames[tablePosition] + " SET usdPrice=" + Convert.ToDecimal(previewUSArray[location].Text) + " WHERE partNumber='" + partNum + "'";
                    datSelectDataSource.Update();
                    currentUSArray[location].Text = previewUSArray[location].Text;
                    priceUSArray[location].Text = "";
                    previewUSArray[location].Text = "";
                }
                if (previewCanArray[location].Text != "")//if its a Can entry, update usdprice and adjust on-screen controls
                {
                    datSelectDataSource.UpdateCommand = "UPDATE " + tableNames[tablePosition] + " SET cadPrice=" + Convert.ToDecimal(previewCanArray[location].Text) + " WHERE partNumber='" + partNum + "'";
                    datSelectDataSource.Update();
                    currentCanArray[location].Text = previewCanArray[location].Text;
                    priceCanArray[location].Text = "";
                    previewCanArray[location].Text = "";
                }
            }
            else //if only a single table is to be updated
            {
                string selectedTable = "";
                switch(ddlCategory.SelectedValue)
                {
                    case "Accessories":
                        {
                            selectedTable = "tblAccessories";
                            break;
                        }

                    case "Decorative Column":
                        {
                            selectedTable = "tblDecorativeColumn";
                            break;
                        }

                    case "Door Frame Extrusion":
                        {
                            selectedTable = "tblDoorFrameExtrusion";
                            break;
                        }

                    case "Insulated Floors":
                        {
                            selectedTable = "tblInsulatedFloors";
                            break;
                        }

                    case "Roof Extrusions":
                        {
                            selectedTable = "tblRoofExtrusions";
                            break;
                        }

                    case "Roof Panels":
                        {
                            selectedTable = "tblRoofPanels";
                            break;
                        }

                    case "Screen Roll":
                        {
                            selectedTable = "tblScreenRoll";
                            break;
                        }

                    case "Suncrylic Roof":
                        {
                            selectedTable = "tblSuncrylicRoof";
                            break;
                        }

                    case "Sunrail 1000":
                        {
                            selectedTable = "tblSunrail1000";
                            break;
                        }

                    case "Sunrail 300":
                        {
                            selectedTable = "tblSunrail300";
                            break;
                        }

                    case "Sunrail 300 Accessories":
                        {
                            selectedTable = "tblSunrail300Accessories";
                            break;
                        }

                    case "Sunrail 400":
                        {
                            selectedTable = "tblSunrail400";
                            break;
                        }

                    case "Vinyl Roll":
                        {
                            selectedTable = "tblVinylRoll";
                            break;
                        }

                    case "Wall Extrusions":
                        {
                            selectedTable = "tblWallExtrusions";
                            break;
                        }

                    case "Wall Panels":
                        {
                            selectedTable = "tblWallPanels";
                            break;
                        }
                }

                if (previewUSArray[location].Text != "") //if its a US entry, update usdprice and adjust on-screen controls
                {
                    datSelectDataSource.UpdateCommand = "UPDATE " + selectedTable + " SET usdPrice=" + Convert.ToDecimal(previewUSArray[location].Text) + " WHERE partNumber='" + partNum + "'";
                    datSelectDataSource.Update();
                    currentUSArray[location].Text = previewUSArray[location].Text;
                    priceUSArray[location].Text = "";
                    previewUSArray[location].Text = "";
                }
                if (previewCanArray[location].Text != "")//if its a Can entry, update usdprice and adjust on-screen controls
                {
                    datSelectDataSource.UpdateCommand = "UPDATE " + selectedTable + " SET cadPrice=" + Convert.ToDecimal(previewCanArray[location].Text) + " WHERE partNumber='" + partNum + "'";
                    datSelectDataSource.Update();
                    currentCanArray[location].Text = previewCanArray[location].Text;
                    priceCanArray[location].Text = "";
                    previewCanArray[location].Text = "";
                }
            }
        }

        /// <summary>
        /// This function will handle any code for calculating the preview text box numbers
        /// </summary>
        protected void btnPreview_Click(object sender, EventArgs e)
        {
            if (chkApplyToSelected.Checked == false) //if apply all, we go to else, to handle all
            {
                if (radPercentDollar.SelectedValue == "Increase/Decrease by %") //handle % increase calculation
                {
                    for (int i = 0; i < totalElements; i++) //loop for all elements
                    {
                        if (checkboxArray[i].Checked == true) //only increase if checked (and not apply all)
                        {
                            double priceUS = 0;
                            double adjustUS = 0;
                            double priceCan = 0;
                            double adjustCan = 0;

                            if (priceUSArray[i].Text != "")
                            {
                                priceUS = Convert.ToDouble(currentUSArray[i].Text);
                                adjustUS = Convert.ToDouble(priceUSArray[i].Text);
                            }
                            if (priceCanArray[i].Text != "")
                            {
                                priceCan = Convert.ToDouble(currentCanArray[i].Text);
                                adjustCan = Convert.ToDouble(priceCanArray[i].Text);
                            }

                            if (radIncreaseDecrease.SelectedValue == "Price Increase") //handle increase
                            {
                                if (priceUSArray[i].Text != "")
                                {
                                    previewUSArray[i].Text = (priceUS + (priceUS * (adjustUS / 100))).ToString("N2"); //Price + (Price * (Adjust/100)) (since %)
                                    lastCalculatedUS[i] = previewUSArray[i].Text; //also update newest 'last'
                                    lastAdjustedUS[i] = priceUSArray[i].Text;
                                }
                                if (priceCanArray[i].Text != "")
                                {
                                    previewCanArray[i].Text = (priceCan + (priceCan * (adjustCan / 100))).ToString("N2"); //Price + (Price * (Adjust/100)) (since %)
                                    lastCalculatedCan[i] = previewCanArray[i].Text; //also update newest 'last'
                                    lastAdjustedCan[i] = priceCanArray[i].Text;
                                }
                            }
                            else //handle decrease
                            {
                                if (priceUSArray[i].Text != "")
                                {
                                    if (adjustUS >= -100)
                                    {
                                        previewUSArray[i].Text = (priceUS - (priceUS * (adjustUS / 100))).ToString("N2"); //Price - (Price * (Adjust/100)) (since %)
                                        lastCalculatedUS[i] = previewUSArray[i].Text; //also update newest 'last'
                                        lastAdjustedUS[i] = priceUSArray[i].Text;
                                    }
                                    else
                                    {
                                        //CHANGETHISCODE - Error, can't be past -100%
                                    }
                                }
                                if (priceCanArray[i].Text != "")
                                {
                                    if (adjustCan >= -100)
                                    {
                                        previewCanArray[i].Text = (priceCan - (priceCan * (adjustCan / 100))).ToString("N2"); //Price - (Price * (Adjust/100)) (since %)
                                        lastCalculatedCan[i] = previewCanArray[i].Text; //also update newest 'last'
                                        lastAdjustedCan[i] = priceCanArray[i].Text;
                                    }
                                    else
                                    {
                                        //CHANGETHISCODE - Error, can't be past -100%
                                    }
                                }
                            }
                        }
                    }
                }
                else if (radPercentDollar.SelectedValue == "Increase/Decrease by $ Amount")//handle $ increase
                {
                    for (int i = 0; i < totalElements; i++)
                    {
                        if (checkboxArray[i].Checked == true) //only increase if checked (and not apply all)
                        {
                            double priceUS = 0;
                            double adjustUS = 0;
                            double priceCan = 0;
                            double adjustCan = 0;

                            if (priceUSArray[i].Text != "")
                            {
                                priceUS = Convert.ToDouble(currentUSArray[i].Text);
                                adjustUS = Convert.ToDouble(priceUSArray[i].Text);
                            }
                            if (priceCanArray[i].Text != "")
                            {
                                priceCan = Convert.ToDouble(currentCanArray[i].Text);
                                adjustCan = Convert.ToDouble(priceCanArray[i].Text);
                            }
                            if (radIncreaseDecrease.SelectedValue == "Price Increase")
                            {
                                if (priceUSArray[i].Text != "")
                                {
                                    previewUSArray[i].Text = (priceUS + adjustUS).ToString("N2"); //Price + Adjust (since $)
                                    lastCalculatedUS[i] = previewUSArray[i].Text; //also update newest 'last'
                                    lastAdjustedUS[i] = priceUSArray[i].Text;
                                }
                                if (priceCanArray[i].Text != "")
                                {
                                    previewCanArray[i].Text = (priceCan + adjustCan).ToString("N2"); //Price + Adjust (since $)
                                    lastCalculatedCan[i] = previewCanArray[i].Text; //also update newest 'last'
                                    lastAdjustedCan[i] = priceCanArray[i].Text;
                                }
                            }
                            else
                            {
                                if (priceUSArray[i].Text != "")
                                {
                                    if ((priceUS - adjustUS) >= 0)
                                    {
                                        previewUSArray[i].Text = (priceUS - adjustUS).ToString("N2"); //Price + Adjust (since $)
                                        lastCalculatedUS[i] = previewUSArray[i].Text; //also update newest 'last'
                                        lastAdjustedUS[i] = priceUSArray[i].Text;
                                    }
                                    else
                                    {
                                        //CHANGETHISCODE - Error, can't be below 0
                                    }
                                }
                                if (priceCanArray[i].Text != "")
                                {
                                    if ((priceCan - adjustCan) >= 0)
                                    {
                                        previewCanArray[i].Text = (priceCan - adjustCan).ToString("N2"); //Price + Adjust (since $)
                                        lastCalculatedCan[i] = previewCanArray[i].Text; //also update newest 'last'
                                        lastAdjustedCan[i] = priceCanArray[i].Text;
                                    }
                                    else
                                    {
                                        //CHANGETHISCODE - Error, can't be below 0
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    //
                    //
                    // CHANGETHISCODE
                    // error that no radio button selections
                    //
                    //
                }
            }
            else //apply to selected
            {
                double adjustUS = 0;
                double adjustCan = 0;
                if (txtPriceAdjustUS.Text != "")
                {
                    adjustUS = Convert.ToDouble(txtPriceAdjustUS.Text);
                }
                if (txtPriceAdjustCAN.Text != "")
                {
                    adjustCan = Convert.ToDouble(txtPriceAdjustCAN.Text);
                }

                if (radPercentDollar.SelectedValue == "Increase/Decrease by %") //handle % increase calculation
                {
                    for (int i = 0; i < totalElements; i++)
                    {
                        if (checkboxArray[i].Checked == true) //only increase if checked (and not apply all)
                        {
                            double priceUS=0;
                            double priceCan = 0;

                            if (txtPriceAdjustUS.Text != "")
                            {
                                priceUS = Convert.ToDouble(currentUSArray[i].Text);
                            }
                            if (txtPriceAdjustCAN.Text != "")
                            {
                                priceCan = Convert.ToDouble(currentCanArray[i].Text);
                            }

                            if (radIncreaseDecrease.SelectedValue == "Price Increase")
                            {
                                if (txtPriceAdjustUS.Text != "")
                                {
                                    previewUSArray[i].Text = (priceUS + (priceUS * (adjustUS / 100))).ToString("N2"); //Price + (Price * (Adjust/100)) (since %)
                                    lastCalculatedUS[i] = (priceUS + (priceUS * (adjustUS / 100))).ToString("N2"); //also update newest 'last'
                                    lastAdjustedUS[i] = priceUSArray[i].Text;
                                }
                                if (txtPriceAdjustCAN.Text != "")
                                {
                                    previewCanArray[i].Text = (priceCan + (priceCan * (adjustCan / 100))).ToString("N2"); //Price + (Price * (Adjust/100)) (since %)
                                    lastCalculatedCan[i] = (priceCan + (priceCan * (adjustCan / 100))).ToString("N2"); //also update newest 'last'
                                    lastAdjustedCan[i] = priceCanArray[i].Text;
                                }
                            }
                            else
                            {
                                if (txtPriceAdjustUS.Text != "")
                                {
                                    previewUSArray[i].Text = (priceUS - (priceUS * (adjustUS / 100))).ToString("N2"); //Price + (Price * (Adjust/100)) (since %)
                                    lastCalculatedUS[i] = (priceUS - (priceUS * (adjustUS / 100))).ToString("N2"); //also update newest 'last'
                                    lastAdjustedUS[i] = priceUSArray[i].Text;
                                }
                                if (txtPriceAdjustCAN.Text != "")
                                {
                                    previewCanArray[i].Text = (priceCan - (priceCan * (adjustCan / 100))).ToString("N2"); //Price + (Price * (Adjust/100)) (since %)
                                    lastCalculatedCan[i] = (priceCan - (priceCan * (adjustCan / 100))).ToString("N2"); //also update newest 'last'
                                    lastAdjustedCan[i] = priceCanArray[i].Text;
                                }
                            }
                        }
                    }
                }
                else if (radPercentDollar.SelectedValue == "Increase/Decrease by $ Amount")//handle $ increase
                {
                    for (int i = 0; i < totalElements; i++)
                    {
                        if (checkboxArray[i].Checked == true) //only increase if checked (and not apply all)
                        {
                            double priceUS = 0;
                            double priceCan = 0;

                            if (txtPriceAdjustUS.Text != "")
                            {
                                priceUS = Convert.ToDouble(currentUSArray[i].Text);
                            }
                            if (txtPriceAdjustCAN.Text != "")
                            {
                                priceCan = Convert.ToDouble(currentCanArray[i].Text);
                            }

                            if (radIncreaseDecrease.SelectedValue == "Price Increase")
                            {
                                if (txtPriceAdjustUS.Text != "")
                                {
                                    previewUSArray[i].Text = (priceUS + adjustUS).ToString("N2"); //Price + Adjust (since $)
                                    lastCalculatedUS[i] = (priceUS + adjustUS).ToString("N2"); //also update newest 'last'
                                    lastAdjustedUS[i] = priceUSArray[i].Text;
                                }
                                if (txtPriceAdjustCAN.Text != "")
                                {
                                    previewCanArray[i].Text = (priceCan + adjustCan).ToString("N2"); //Price + Adjust (since $)
                                    lastCalculatedCan[i] = (priceCan + adjustCan).ToString("N2"); //also update newest 'last'
                                    lastAdjustedCan[i] = priceCanArray[i].Text;
                                }
                            }
                            else
                            {
                                if (txtPriceAdjustUS.Text != "")
                                {
                                    previewUSArray[i].Text = (priceUS - adjustUS).ToString("N2"); //Price + Adjust (since $)
                                    lastCalculatedUS[i] = (priceUS - adjustUS).ToString("N2"); //also update newest 'last'
                                    lastAdjustedUS[i] = priceUSArray[i].Text;
                                }
                                if (txtPriceAdjustCAN.Text != "")
                                {
                                    previewCanArray[i].Text = (priceCan - adjustCan).ToString("N2"); //Price + Adjust (since $)
                                    lastCalculatedCan[i] = (priceCan - adjustCan).ToString("N2"); //also update newest 'last'
                                    lastAdjustedCan[i] = priceCanArray[i].Text;
                                }
                            }
                        }
                    }
                }
            }
        }    

        /// <summary>
        /// This function will validate the entered prices in the price text box columns, called
        /// before calculating changes.  Errors will be displayed.
        /// </summary>
        protected string validatePrices()
        {
            string errorMessage = "";
            double tempDouble = 0;

            if (chkApplyToSelected.Checked == false)
            {
                for (int i = 0; i < totalElements; i++)
                {
                    if (checkboxArray[i].Checked == true)
                    {
                        try //try converting each entered number to double, if error, catch and display error.
                        {
                            if (priceUSArray[i].Text != "" || priceCanArray[i].Text != "") //
                            {
                                if (priceUSArray[i].Text != "")
                                {
                                    tempDouble = Convert.ToDouble(priceUSArray[i].Text);
                                }

                                if (priceCanArray[i].Text != "")
                                {
                                    tempDouble = Convert.ToDouble(priceCanArray[i].Text);
                                }
                            }
                            else if (previewUSArray[i].Text != "" || previewCanArray[i].Text != "")
                            {
                                if (priceUSArray[i].Text != "")
                                {
                                    tempDouble = Convert.ToDouble(previewUSArray[i].Text);
                                }

                                if (priceUSArray[i].Text != "")
                                {
                                    tempDouble = Convert.ToDouble(previewCanArray[i].Text);
                                }
                            }
                            else
                            {
                                errorMessage += "Please ensure all checked records have price adjustments entered.\n";
                            }
                        }
                        catch (Exception e)
                        {
                            errorMessage += "Invalid price on part " + partNumArray[i] + ".\n";
                        }
                    }
                }                
            }
            else
            {
                try //try converting each entered number to double, if error, catch and display error.
                {
                    if (txtPriceAdjustUS.Text != "")
                    {
                        tempDouble = Convert.ToDouble(txtPriceAdjustUS.Text);
                    }
                    else if (txtPriceAdjustCAN.Text != "")
                    {
                        tempDouble = Convert.ToDouble(txtPriceAdjustCAN.Text);
                    }
                    else
                    {
                        errorMessage += "You must enter something to apply, if apply to selected is selected.\n";
                    }
                }
                catch (Exception e)
                {
                    errorMessage += "Invalid price on part adjust.\n";
                }
            }

            return errorMessage;
        }

        /// <summary>
        /// Will check all boxes in, or uncheck when unchecked
        /// </summary>
        protected void chkSelectAll_OnCheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectAll.Checked == true) //if it gets checked, check all, otherwise uncheck
            {
                for (int i = 0; i < totalElements; i++)
                {
                    checkboxArray[i].Checked = true;
                }
            }
            else
            {
                for (int i = 0; i < totalElements; i++)
                {
                    checkboxArray[i].Checked = false;
                }
            }
        }

        protected void ddlTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
            //post
            //
            //
        }

        protected void radIncreaseDecrease_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (radIncreaseDecrease.SelectedValue.Contains("Increase"))
            {
                lblHeaderPriceAdjust.Text = lblHeaderPriceAdjust.Text.Replace("Decrease", "Increase");
            }
            else
            {
                lblHeaderPriceAdjust.Text = lblHeaderPriceAdjust.Text.Replace("Increase", "Decrease");
            }
        }

        protected void radPercentDollar_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (radPercentDollar.SelectedValue.Contains('$'))
            {
                lblHeaderPriceAdjust.Text = lblHeaderPriceAdjust.Text.Replace('%', '$');
            }
            else
            {
                lblHeaderPriceAdjust.Text = lblHeaderPriceAdjust.Text.Replace('$', '%');
            }
        }
    }
}
/*
 * Shayne Quinton
 * December 3,2012
 * Insert.aspx version 1.1
 * 
 */ 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sunspace
{
    public partial class Insert : System.Web.UI.Page
    {

        protected Boolean Part_Exists(string tableName, string partNumber)
        {
            

            //Check to see if part number already exists in database
            string selectSql = "SELECT partNumber from " + tableName + " WHERE partNumber = '" + partNumber + "'";

            datInsertDataSource.SelectCommand = selectSql;
            datInsertDataSource.Select(DataSourceSelectArguments.Empty);
            System.Data.DataView selectResults = new System.Data.DataView();

            selectResults = (System.Data.DataView)datInsertDataSource.Select(System.Web.UI.DataSourceSelectArguments.Empty);

            if (selectResults.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
#region PanelControl
        protected void Hide_Panels()
        {
             //Hide selected 'product' panels
                    pnlPackQuantity.CssClass = "removeElement";
                    pnlComposition.CssClass = "removeElement";
                    pnlStandard.CssClass = "removeElement";

                    //Hide all 'dimension' panels
                    pnlAccessories.CssClass = "removeElement";
                    pnlDecorativeColumn.CssClass = "removeElement";
                    pnlDoorFrameExtrusions.CssClass = "removeElement";
                    pnlInsulatedFloors.CssClass = "removeElement";
                    pnlRoofExtrusions.CssClass = "removeElement";
                    pnlRoofPanels.CssClass = "removeElement";
                    //pnlSchematics.CssClass = "removeElement";
                    pnlScreenRoll.CssClass = "removeElement";
                    pnlSuncrylicRoof.CssClass = "removeElement";
                    pnlSunrail1000.CssClass = "removeElement";
                    pnlSunrail300.CssClass = "removeElement";
                    pnlSunrail400.CssClass = "removeElement";
                    pnlVinylRoll.CssClass = "removeElement";
                    pnlWallExtrusions.CssClass = "removeElement";
                    pnlWallPanel.CssClass = "removeElement";
        }

        protected void Show_Panels()
        {
            string tableName = Session["tableName"].ToString();
               //Switch statement for displaying according to selected product
                    switch (tableName)
                    {
                        //when tblRoofExtrusions is selected
                        #region Roof Extrusions
                        case "tblRoofExtrusions":
                            {

                                //show pnlRoofExtrusion
                                pnlRoofExtrusions.CssClass = "dimensionsTable";
                            }
                            break;
                        #endregion
                        //when tblAccessories is selected
                        #region Accessory
                        case "tblAccessories":
                            {

                                //show pnlAccessors
                                pnlDescription.CssClass = "showPanelNoClass";
                                pnlPackQuantity.CssClass = "showPanelNoClass";
                                pnlAccessories.CssClass = "dimensionsTable";

                                //create Accessories object
                                Accessories anAccessory = new Accessories();

                                //add Accessories Object to the session
                                Session.Add("accessories", anAccessory);
                            }

                            break;
#endregion
                        //when tblDecorativeColumn is selected
                        #region DecorativeColumn
                        case "tblDecorativeColumn":
                            {
                                //show pnlAccessors
                                pnlDecorativeColumn.CssClass = "dimensionsTable";
                                pnlPackQuantity.CssClass = "removeElement";

                                //create Accessories object
                                DecorativeColumn aColumn = new DecorativeColumn();

                                //add Accessories Object to the session
                                Session.Add("decorativeColumn", aColumn);
                            }
                            break;
                        #endregion
                        //when tblDoorFrameExtrusion is selected 
                        #region DoorFrameExtrusion
                        case "tblDoorFrameExtrusion":
                            {
                                //show pnlAccessors
                                pnlDoorFrameExtrusions.CssClass = "dimensionsTable";
                                pnlPackQuantity.CssClass = "removeElement";

                                //create Accessories object
                                DoorFrameExtrusion aFrameExtrusion = new DoorFrameExtrusion();

                                //add Accessories Object to the session
                                Session.Add("doorFrameExtrusion", aFrameExtrusion);
                            }

                            break;
                        #endregion
                        //when tblInsulatedFloors is selected
                        #region InsulatedFloors
                        case "tblInsulatedFloors":
                            {
                                //show pnlAccessors
                                pnlInsulatedFloors.CssClass = "dimensionsTable";
                                pnlComposition.CssClass = "showPanelNoClass";
                                pnlStandard.CssClass = "showPanelNoClass";

                                //create Accessories object
                                InsulatedFloors aFloor = new InsulatedFloors();
                            }


                            break;
                        #endregion
                        #region RoofPanels
                        //when tblRoofPanels is selected
                        case "tblRoofPanels":
                            {
                                //show pnlAccessors
                                pnlStandard.CssClass = "showPanelNoClass";
                                
                                pnlRoofPanels.CssClass = "dimensionsTable";
                                //pnlRoofPanels.CssClass = "showPanelNoClass";
                                pnlComposition.CssClass = "showPanelNoClass";
                            }

                            break;
                        #endregion
                        #region ScreenRoll
                        case "tblScreenRoll":
                            {
                                pnlScreenRoll.CssClass = "dimensionsTable";
                            }
                            break;
                        #endregion
                        #region SuncrylicRoof
                        case "tblSuncrylicRoof":
                            {
                                pnlSuncrylicRoof.CssClass = "dimensionsTable";
                            }
                            break;
                        #endregion
                        #region Sunrail1000
                        case "tblSunrail1000":
                            {
                                pnlSunrail1000.CssClass = "dimensionsTable";
                            }
                            break;
                        #endregion
                        #region Sunrail300
                        case "tblSunrail300":
                            {
                                pnlSunrail300.CssClass = "dimensionsTable";
                            }

                            break;
#endregion
                        #region Sunrail300Accessory
                        case "tblSunrail300Accessories":
                            {

                                pnlDimensions.CssClass = "removeElement";
                            }

                            break;
#endregion
                        #region Sunrail400
                        case "tblSunrail400":
                            {
                                pnlSunrail400.CssClass = "showPanelNoClass";
                            }
                            break;
                        #endregion
                        #region VinylRoll
                        case "tblVinylRoll":
                            {
                                pnlVinylRoll.CssClass = "dimensionsTable";
                                pnlDescription.CssClass = "removeElement";
                            }

                            break;
                        #endregion
                        #region WallExtrusions
                        case "tblWallExtrusions":
                            {
                                pnlWallExtrusions.CssClass = "dimensionsTable";
                            }
                            break;
                        #endregion
                        #region WallPanels
                        case "tblWallPanels":
                            {
                                pnlWallPanel.CssClass = "dimensionsTable";
                                pnlStandard.CssClass = "showPanelNoClass";
                                pnlComposition.CssClass = "showPanelNoClass";
                            }
                            break;
                        #endregion
                     
        }
        }
#endregion

        #region main
        protected void Page_Load(object sender, EventArgs e)
        {



            if(!Page.IsPostBack)
            {
                //Make product active by  default
                radActive.Checked = true;

                //Reset temp picture
                System.IO.File.Delete(Server.MapPath("Images/catalogue/temp.jpg"));
                //System.IO.File.Copy(Server.MapPath("Images/catalogue/placeholder.jpg"),Server.MapPath("Images/catalogue/temp.jpg"));

                System.Data.DataView tableList = new System.Data.DataView();
            //Load up the tables list
            datInsertDataSource.SelectCommand = "SELECT name FROM sys.tables WHERE name != 'tblColor' AND name != 'tblSchematicParts' AND name != 'tblParts' AND name != 'tblLengthUnits' and name!='tblSchematics' and name != 'tblAudits' and name!='tblSalesOrders' and name!= 'tblSalesOrderItems' ORDER BY name ASC";

            //assign the table names to the dataview object
            tableList = (System.Data.DataView)datInsertDataSource.Select(System.Web.UI.DataSourceSelectArguments.Empty);

            //variable to determine amount of rows in the dataview object
            
            //populate first drop down
            ddlTables.DataSource = tableList;
            ddlTables.DataTextField = "name";
            ddlTables.DataValueField = "name";
            ddlTables.DataBind();

            Session["tableName"] = "tblAccessories";
             Hide_Panels();
             Show_Panels();

                //populate colors dropdown
             //Populate Colors Drop Down
             System.Data.DataView colorTable = new System.Data.DataView();
             datInsertDataSource.SelectCommand = "SELECT colorName FROM tblColor ORDER BY colorName ASC";
             colorTable = (System.Data.DataView)datInsertDataSource.Select(System.Web.UI.DataSourceSelectArguments.Empty);


            
             //Bind colors to drop down list

            
            
             ddlColors.DataSource = colorTable;
             ddlColors.DataTextField = "colorName";
             ddlColors.DataValueField = "colorName";
             ddlColors.DataBind();
             ddlColors.Items.Insert(0,new ListItem("N/A",""));


            }

            if(Page.IsPostBack)
            {
                //just for testing purposes
                Session["tableName"] = ddlTables.SelectedValue;

                Hide_Panels();
                Show_Panels();
      
                //Populate Units Drop Downs

                System.Data.DataView unitsTable = new System.Data.DataView();
                datInsertDataSource.SelectCommand = "SELECT lengthUnitName FROM tblLengthUnits ORDER BY lengthUnitName ASC";
                unitsTable = (System.Data.DataView)datInsertDataSource.Select(System.Web.UI.DataSourceSelectArguments.Empty);

                //would populate all the units dropdowns here

  
                           
                    
                    /*//Clear updated object in session
                    if (Session["updatedObject"] != null)
                    {
                        Session.Remove("updatedObject");
                    }

                    //clear specific product in session
                    if (Session["roofExtrusion"] != null)
                    {
                        Session.Remove("roofExtrusion");
                    }*/
                    //else if
                    //{
                    //    remove more objects
                    //}

                   

                    //get table selected from session
                    

                 

         
     
          
                    
                }
            
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {

            string errorMessage ="";
            

           
            if (Page.IsPostBack)
            {
                                    //get selected table from the session
                    string tableName = Session["tableName"].ToString();

                    //select case statement for each possible objects
                    switch (tableName)
                    {
                        #region RoofExtrusions


                        //when roof extrusion is selected
                        case "tblRoofExtrusions":
                            {


                                Page.Validate("productInfo");
                                Page.Validate("pricing");
                                Page.Validate("roofExtrusion");

                                if (Page.IsValid == true)
                                {



                                    //create new object
                                    RoofExtrusion aRoofExtrusion = new RoofExtrusion();


                                    aRoofExtrusion.ExtrusionName = txtPartName.Text;
                                    aRoofExtrusion.ExtrusionNumber = txtPartNum.Text;
                                    aRoofExtrusion.ExtrusionDescription = txtPartDesc.Text;
                                    aRoofExtrusion.CadPrice = Convert.ToDecimal(txtCadPrice.Text);
                                    aRoofExtrusion.UsdPrice = Convert.ToDecimal(txtUsdPrice.Text);

                                    aRoofExtrusion.AngleA = Convert.ToInt32(txtRoofExtAngleA.Text);
                                    aRoofExtrusion.AngleAUnits = "Inches";
                                    aRoofExtrusion.AngleB = Convert.ToInt32(txtRoofExtAngleB.Text);
                                    aRoofExtrusion.AngleBUnits = "Inches";
                                    aRoofExtrusion.AngleC = Convert.ToInt32(txtRoofExtAngleC.Text);
                                    aRoofExtrusion.AngleCUnits = "Inches";



                                    aRoofExtrusion.ExtrusionColor = ddlColors.SelectedValue;

                                    aRoofExtrusion.ExtrusionMaxLength = Convert.ToInt32(txtRoofExtMaxLength.Text);
                                    aRoofExtrusion.MaxLengthUnits = ddlRoofExtMaxLengtUnits.SelectedValue;
                                    aRoofExtrusion.ExtrusionSize = Convert.ToInt32(txtRoofExtSize.Text);
                                    aRoofExtrusion.SizeUnits = ddlRoofExtSizeUnits.SelectedValue;



                                    if (Part_Exists("tblRoofExtrusions", aRoofExtrusion.ExtrusionNumber) == true)
                                    {

                                    }
                                    else
                                    {
                                        //Insert
                                        aRoofExtrusion.Insert(datInsertDataSource, "tblRoofExtrusions");

                                        //Set Session Variables for Display Page
                                        Session["categoryIndex"] = 5;
                                        Session["partIndex"] = 1;
                                        Session["partNumber"] = aRoofExtrusion.ExtrusionNumber;
                                        //whatever happens here
                                    }
                                }

                                break;

                                //more cases here


                            }
                        #endregion
                        #region Accessory
                        case "tblAccessories":
                            {

                                Page.Validate("productInfo");
                                Page.Validate("pricing");
                                Page.Validate("accessories");

                                if (Page.IsValid == true)
                                {



                                    TextBox tempTxt;
                                    Accessories anAccessory = new Accessories();

                                    Session.Add("Accessory", anAccessory);

                                    anAccessory.AccessoryName = txtPartName.Text;
                                    anAccessory.AccessoryNumber = txtPartNum.Text;
                                    anAccessory.AccessoryDescription = txtPartDesc.Text;
                                    anAccessory.AccessoryCadPrice = Convert.ToDecimal(txtCadPrice.Text);
                                    anAccessory.AccessoryUsdPrice = Convert.ToDecimal(txtUsdPrice.Text);



                                    //tempTxt = (TextBox)pnlColor.FindControl("txtColor");
                                    //anAccessory.AccessoryColor = tempTxt.Text;

                                    tempTxt = (TextBox)pnlAccessories.FindControl("txtAccessoryWidth");
                                    if (tempTxt.Text.Trim() != "")
                                    {
                                        anAccessory.AccessoryWidth = Convert.ToInt16(tempTxt.Text);
                                    }
                                    else
                                    {
                                        anAccessory.AccessoryWidth = 0;
                                    }

                                    if (txtPackQuantity.Text.Trim() != "")
                                    {
                                        anAccessory.AccessoryPackQuantity = Convert.ToInt16(txtPackQuantity.Text);
                                    }
                                    else
                                    {
                                        anAccessory.AccessoryPackQuantity = 0;
                                    }

                                    tempTxt = (TextBox)pnlAccessories.FindControl("txtAccessoryLength");
                                    if (tempTxt.Text.Trim() != "")
                                    {
                                        anAccessory.AccessoryLength = Convert.ToInt16(tempTxt.Text);
                                    }
                                    else
                                    {
                                        anAccessory.AccessoryLength = 0;
                                    }

                                    anAccessory.AccessoryColor = ddlColors.SelectedValue;
                                    anAccessory.AccessoryWidthUnits = ddlAccessoryWidthUnits.SelectedValue;
                                    anAccessory.AccessoryLengthUnits = ddlAccessoryLengthUnits.SelectedValue;
                                    tempTxt = (TextBox)pnlAccessories.FindControl("txtAccessorySize");


                                    //If they don't enter a size then make it 0
                                    if (tempTxt.Text.Trim() == "")
                                    {
                                        anAccessory.AccessorySize = 0;
                                    }
                                    else
                                    {
                                        anAccessory.AccessorySize = Convert.ToInt16(tempTxt.Text);
                                    }

                                    anAccessory.AccessorySizeUnits = ddlAccessorySizeUnits.SelectedValue;


                                    if (Part_Exists("tblAccessories", anAccessory.AccessoryNumber) == true)
                                    {
                                       
                                        
                                        //part does exist, set error message
                                        errorMessage = "Could not add" + anAccessory.AccessoryNumber + ". Part Number already exists.";
                                        valPartExists.Text = errorMessage;
                                    
                                    }
                                    else
                                    {
                                        //Insert
                                        anAccessory.Insert(datInsertDataSource, "tblAccessories");

                                        //Set Required Session Variables for Display Page
                                        Session["categoryIndex"] = 1;
                                        Session["partIndex"] = 1;
                                        Session["partNumber"] = anAccessory.AccessoryNumber;
                                    }
                                }


                            }
                            break;
                        #endregion
                        #region DecorativeColumn
                        case "tblDecorativeColumn":
                            {

                                Page.Validate("productInfo");
                                Page.Validate("pricing");
                                Page.Validate("decorativeColumn");

                                if (Page.IsValid == true)
                                {


                                    DecorativeColumn aDecorativeColumn = new DecorativeColumn();

                                    Session.Add("DecorativeColumn", aDecorativeColumn);

                                    aDecorativeColumn.ColumnLength = Convert.ToInt32(txtDecColLength.Text);
                                    aDecorativeColumn.ColumnName = txtPartName.Text;
                                    aDecorativeColumn.PartNumber = txtPartNum.Text;
                                    aDecorativeColumn.ColumnDescription = txtPartDesc.Text;
                                    aDecorativeColumn.ColumnCadPrice = Convert.ToDecimal(txtCadPrice.Text);
                                    aDecorativeColumn.ColumnUsdPrice = Convert.ToDecimal(txtUsdPrice.Text);

                                    aDecorativeColumn.ColumnLength = Convert.ToInt32(txtDecColLength.Text);
                                    aDecorativeColumn.ColumnLengthUnits = ddlDecColLengthUnits.SelectedValue;

                                    aDecorativeColumn.ColumnColor = ddlColors.SelectedValue;

                                    if (Part_Exists("tblDecorativeColumn", aDecorativeColumn.PartNumber) == true)
                                    {
                                        //part does not exist, set error message
                                        //part does exist, set error message
                                        errorMessage = "Could not add" + aDecorativeColumn.PartNumber + ". Part Number already exists.";
                                        valPartExists.Text = errorMessage;
                                    }
                                    else
                                    {
                                        //Insert
                                        aDecorativeColumn.Insert(datInsertDataSource, "tblDecorativeColumn");

                                        //Set Session Variables for Display Page
                                        Session["categoryIndex"] = 2;
                                        Session["partIndex"] = 1;
                                        Session["partNumber"] = aDecorativeColumn.PartNumber;
                                    }
                                }
                            }
                            break;
                        #endregion
                        #region DoorFrameExtrusion
                        case "tblDoorFrameExtrusion":
                            {

                                Page.Validate("productInfo");
                                Page.Validate("pricing");
                                Page.Validate("doorFrameExtrusion");

                                if (Page.IsValid == true)
                                {
                                    DoorFrameExtrusion aDfe = new DoorFrameExtrusion();

                                    Session.Add("DoorFrameExtrusion", aDfe);

                                    aDfe.DfeMaxLength = Convert.ToInt32(txtDoorFrExtMaxLength.Text);
                                    aDfe.DfeName = txtPartName.Text;


                                    aDfe.PartNumber = txtPartNum.Text;
                                    aDfe.DfeDescription = txtPartDesc.Text;
                                    aDfe.CadPrice = Convert.ToDecimal(txtCadPrice.Text);
                                    aDfe.UsdPrice = Convert.ToDecimal(txtUsdPrice.Text);

                                    aDfe.DfeColor = ddlColors.SelectedValue;
                                    aDfe.DfeMaxLength = Convert.ToInt32(txtDoorFrExtMaxLength.Text);
                                    aDfe.DfeMaxLengthUnits = ddlDoorFrExtMaxLengthUnits.SelectedValue;

                                    if (Part_Exists("tblDoorFrameExtrusion", aDfe.PartNumber) == true)
                                    {
                                        //part already exists, set error message
                                        //part does exist, set error message
                                        errorMessage = "Could not add" + aDfe.PartNumber + ". Part Number already exists.";
                                        valPartExists.Text = errorMessage;
                                    }
                                    else
                                    {
                                        //Insert
                                        aDfe.Insert(datInsertDataSource, "tblDoorFrameExtrusion");

                                        //Set required session variables for display page
                                        //Set Session Variables for Display Page
                                        Session["categoryIndex"] = 3;
                                        Session["partIndex"] = 1;
                                        Session["partNumber"] = aDfe.PartNumber;
                                    }
                                }
                            }
                            break;
                        #endregion
                        #region InsulatedFloors
                        case "tblInsulatedFloors":
                            {

                                Page.Validate("productInfo");
                                Page.Validate("pricing");
                                Page.Validate("insulatedFloor");
                                Page.Validate("compstand");

                                if (Page.IsValid == true)
                                {
                                    InsulatedFloors anInsulatedFloor = new InsulatedFloors();

                                    Session.Add("InsulatedFloor", anInsulatedFloor);

                                    anInsulatedFloor.InsulatedFloorName = txtPartName.Text;
                                    anInsulatedFloor.PartNumber = txtPartNum.Text;
                                    anInsulatedFloor.InsulatedFloorDescription = txtPartDesc.Text;
                                    anInsulatedFloor.InsulatedFloorCadPrice = Convert.ToDecimal(txtCadPrice.Text);
                                    anInsulatedFloor.InsulatedFloorUsdPrice = Convert.ToDecimal(txtUsdPrice.Text);

                                    anInsulatedFloor.InsulatedFloorComposition = txtComposition.Text;
                                    anInsulatedFloor.InsulatedFloorMaxLength = txtInsulatedFloorMaxLength.Text;
                                    anInsulatedFloor.InsulatedFloorMaxWidth = Convert.ToInt32(txtInsFloorPnlMaxWidth.Text);
                                    anInsulatedFloor.InsulatedFloorMaxWidthUnits = ddlInsFloorPnlMaxWidthUnits.SelectedValue;
                                    anInsulatedFloor.InsulatedFloorSize = Convert.ToInt32(txtInsFloorSize.Text);
                                    anInsulatedFloor.InsulatedFloorSizeUnits = ddlInsFloorSizeUnits.SelectedValue;
                                    if (Part_Exists("tblInsulatedFloors", anInsulatedFloor.PartNumber) == true)
                                    {
                                        //error messae would go here
                                        //part does exist, set error message
                                        errorMessage = "Could not add" + anInsulatedFloor.PartNumber + ". Part Number already exists.";
                                        valPartExists.Text = errorMessage;
                                    }
                                    else
                                    {
                                        //Insert
                                        anInsulatedFloor.Insert(datInsertDataSource, "tblInsulatedFloors");
                                        //Set Session Variables for Display Page
                                        Session["categoryIndex"] = 4;
                                        Session["partIndex"] = 1;
                                        Session["partNumber"] = anInsulatedFloor.PartNumber;
                                    }
                                }
                            }
                            break;
                        #endregion
                        #region aRoofPanel
                        case "tblRoofPanels":
                            {
                                Page.Validate("productInfo");
                                Page.Validate("pricing");
                                Page.Validate("roofPanel");
                                Page.Validate("compstand");

                                if (Page.IsValid == true)
                                {
                                    RoofPanels aRoofPanel = new RoofPanels();
                                    Session.Add("RoofPanel", aRoofPanel);

                                    aRoofPanel.PanelName = txtPartName.Text;
                                    aRoofPanel.PartNumber = txtPartNum.Text;
                                    aRoofPanel.PanelDescription = txtPartDesc.Text;
                                    aRoofPanel.CadPrice = Convert.ToDecimal(txtCadPrice.Text);
                                    aRoofPanel.UsdPrice = Convert.ToDecimal(txtUsdPrice.Text);

                                    aRoofPanel.PanelComposition = txtComposition.Text;
                                    //aRoofPanel.PanelMaxLength = txtRoofPnlMaxLength.Text;
                                    aRoofPanel.PanelMaxWidth = Convert.ToInt32(txtRoofPnlMaxWidth.Text);
                                    aRoofPanel.PanelMaxLength = txtRoofPanelMaxLength.Text;
                                    aRoofPanel.MaxWidthUnits = "Inches";
                                    aRoofPanel.PanelSize = Convert.ToInt32(txtRoofPnlSize.Text);
                                    aRoofPanel.PanelSizeUnits = "Inches";
                                    aRoofPanel.PanelColor = ddlColors.SelectedValue;
                                    aRoofPanel.PanelStandard = txtStandard.Text;




                                    if (Part_Exists("tblRoofPanels", aRoofPanel.PartNumber) == true)
                                    {
                                        //error message
                                        //part does exist, set error message
                                        errorMessage = "Could not add" + aRoofPanel.PartNumber + ". Part Number already exists.";
                                        valPartExists.Text = errorMessage;
                                    }
                                    else
                                    {
                                        aRoofPanel.Insert(datInsertDataSource, "tblRoofPanels");
                                        //Set Session Variables for Display Page
                                        Session["categoryIndex"] = 6;
                                        Session["partIndex"] = 1;
                                        Session["partNumber"] = aRoofPanel.PartNumber;
                                    }
                                }



                            }
                            break;
                        #endregion
                        #region ScreenRoll
                        case "tblScreenRoll":
                            {

                                Page.Validate("productInfo");
                                Page.Validate("pricing");
                                Page.Validate("screenroll");

                                if (Page.IsValid == true)
                                {
                                    ScreenRoll aScreenRoll = new ScreenRoll();

                                    Session.Add("ScreenRoll", aScreenRoll);

                                    aScreenRoll.ScreenRollName = txtPartName.Text;
                                    aScreenRoll.PartNumber = txtPartNum.Text;
                                    aScreenRoll.ScreenRollWidth = Convert.ToInt32(txtScreenRollWidth.Text);
                                    aScreenRoll.ScreenRollWidthUnits = ddlScreenRollWidthUnits.SelectedValue;
                                    aScreenRoll.ScreenRollLength = Convert.ToInt32(txtScreenRollLength.Text);
                                    aScreenRoll.ScreenRollLengthUnits = ddlScreenRollLengthUnits.SelectedValue;
                                    aScreenRoll.CadPrice = Convert.ToDecimal(txtCadPrice.Text);
                                    aScreenRoll.UsdPrice = Convert.ToDecimal(txtUsdPrice.Text);


                                    if (Part_Exists("tblScreenRoll", aScreenRoll.PartNumber) == true)
                                    {
                                        //error message
                                        //part does exist, set error message
                                        errorMessage = "Could not add" + aScreenRoll.PartNumber + ". Part Number already exists.";
                                        valPartExists.Text = errorMessage;
                                    }
                                    else
                                    {
                                        //insert
                                        aScreenRoll.Insert(datInsertDataSource, "tblScreenRoll");
                                        //Set Session Variables for Display Page
                                        Session["categoryIndex"] = 8;
                                        Session["partIndex"] = 1;
                                        Session["partNumber"] = aScreenRoll.PartNumber;
                                    }
                                }

                            }
                            break;
                        #endregion
                        #region SunrcylicRoof
                        case "tblSuncrylicRoof":
                            {

                                Page.Validate("productInfo");
                                Page.Validate("pricing");
                                Page.Validate("suncrylicroof");

                                if (Page.IsValid == true)
                                {
                                    SuncrylicRoof aSuncrylicRoof = new SuncrylicRoof();

                                    Session.Add("SunCrylicRoof", aSuncrylicRoof);

                                    aSuncrylicRoof.SuncrylicName = txtPartName.Text;
                                    aSuncrylicRoof.PartNumber = txtPartNum.Text;
                                    aSuncrylicRoof.SuncrylicDescription = txtPartDesc.Text;
                                    aSuncrylicRoof.CadPrice = Convert.ToDecimal(txtCadPrice.Text);
                                    aSuncrylicRoof.UsdPrice = Convert.ToDecimal(txtUsdPrice.Text);

                                    aSuncrylicRoof.SuncrylicColor = ddlColors.SelectedValue;
                                    aSuncrylicRoof.SuncrylicMaxLength = Convert.ToInt32(txtSunRoofMaxLength.Text);
                                    aSuncrylicRoof.SuncrylicLengthUnits = ddlSunRoofMaxLengthUnits.SelectedValue;


                                    if (Part_Exists("tblSuncrylicRoof", aSuncrylicRoof.PartNumber) == true)
                                    {
                                        //error message
                                        //part does exist, set error message
                                        errorMessage = "Could not add" + aSuncrylicRoof.PartNumber + ". Part Number already exists.";
                                        valPartExists.Text = errorMessage;
                                    }
                                    else
                                    {
                                        //Insert
                                        aSuncrylicRoof.Insert(datInsertDataSource, "tblSuncrylicRoof");

                                        //Set Session Variables for Display Page
                                        Session["categoryIndex"] = 9;
                                        Session["partIndex"] = 1;
                                        Session["partNumber"] = aSuncrylicRoof.PartNumber;
                                    }
                                }

                            }
                            break;
                        #endregion
                        #region Sunrail1000
                        case "tblSunrail1000":
                            {
                                Page.Validate("productInfo");
                                Page.Validate("pricing");
                                Page.Validate("sunrail1000");

                                if (Page.IsValid == true)
                                {
                                    Sunrail1000 aSunrail1000 = new Sunrail1000();

                                    Session.Add("Sunrail1000", aSunrail1000);

                                    aSunrail1000.Sunrail1000Name = txtPartName.Text;
                                    aSunrail1000.PartNumber = txtPartNum.Text;
                                    aSunrail1000.Sunrail1000Description = txtPartDesc.Text;
                                    aSunrail1000.Sunrail1000CadPrice = Convert.ToDecimal(txtCadPrice.Text);
                                    aSunrail1000.Sunrail1000UsdPrice = Convert.ToDecimal(txtUsdPrice.Text);

                                    aSunrail1000.Sunrail1000Color = ddlColors.SelectedValue;


                                    //Check if they entered a value
                                    //If not then insert null into the database
                                    if (((txtSun1000MaxLengthFt.Text.Trim()) == "") || Convert.ToInt32(txtSun1000MaxLengthFt.Text) == 0)
                                    {
                                        aSunrail1000.Sunrail1000MaxLengthFeet = 0;
                                        aSunrail1000.Sunrail1000MaxLengthFeetUnits = null;

                                    }
                                    else //insert data they entered
                                    {
                                        aSunrail1000.Sunrail1000MaxLengthFeet = Convert.ToInt32(txtSun1000MaxLengthFt.Text);
                                        aSunrail1000.Sunrail1000MaxLengthFeetUnits = "Feet";
                                    }

                                    if ((txtSun1000PnlMaxLengthInch.Text.Trim() == "") || (Convert.ToInt32(txtSun1000PnlMaxLengthInch.Text) == 0))
                                    {
                                        aSunrail1000.Sunrail1000MaxLengthInches = null;
                                        aSunrail1000.Sunrail1000MaxLengthInchesUnits = null;
                                    }
                                    else
                                    {
                                        aSunrail1000.Sunrail1000MaxLengthInches = Convert.ToInt32(txtSun1000PnlMaxLengthInch.Text);

                                        aSunrail1000.Sunrail1000MaxLengthInchesUnits = "Inches";
                                    }


                                    if (Part_Exists("tblSunrail1000", aSunrail1000.PartNumber) == true)
                                    {
                                        //error message
                                        //part does exist, set error message
                                        errorMessage = "Could not add" + aSunrail1000.PartNumber + ". Part Number already exists.";
                                        valPartExists.Text = errorMessage;
                                    }
                                    else
                                    {
                                        //insert
                                        aSunrail1000.Insert(datInsertDataSource, "tblSunrail1000");

                                        //Set Session Variables for Display Page
                                        Session["categoryIndex"] = 10;
                                        Session["partIndex"] = 1;
                                        Session["partNumber"] = aSunrail1000.PartNumber;
                                    }
                                }
                            }
                            break;
                        #endregion
                        #region Sunrail300
                        case "tblSunrail300":
                            {

                                Page.Validate("productInfo");
                                Page.Validate("pricing");
                                Page.Validate("sunrail300");

                                if (Page.IsValid == true)
                                {
                                    Sunrail300 aSunrail300 = new Sunrail300();

                                    Session.Add("Sunrail300", aSunrail300);

                                    //Name
                                    aSunrail300.Sunrail300Name = txtPartName.Text;
                                    //Part Number
                                    aSunrail300.PartNumber = txtPartNum.Text;
                                    //Descriptions
                                    aSunrail300.Sunrail300Description = txtPartDesc.Text;
                                    //Prices
                                    aSunrail300.Sunrail300CadPrice = Convert.ToDecimal(txtCadPrice.Text);
                                    aSunrail300.Sunrail300UsdPrice = Convert.ToDecimal(txtUsdPrice.Text);

                                    //Color
                                    aSunrail300.Sunrail300Color = ddlColors.SelectedValue;

                                    //Max Length Feet
                                    aSunrail300.Sunrail300MaxLengthFeet = Convert.ToInt32(txtSun300MaxLengthFt.Text);
                                    aSunrail300.Sunrail300MaxLengthFeetUnits = "Feet";


                                    //Max Length Inch

                                    //If user enters nothing or 0, place a null in the Inches field
                                    if (txtSun300PnlMaxLengthInch.Text == "" || Convert.ToInt32(txtSun300PnlMaxLengthInch.Text) == 0)
                                    {
                                        aSunrail300.Sunrail300MaxLengthInches = null;
                                        aSunrail300.Sunrail300MaxLengthInchesUnits = null;
                                        //place nulls
                                    }
                                    else
                                    {
                                        aSunrail300.Sunrail300MaxLengthInches = Convert.ToInt32(txtSun300PnlMaxLengthInch.Text);
                                        aSunrail300.Sunrail300MaxLengthInchesUnits = "Inches";
                                    }

                                    //Set Session Variables for Display Page

                                    if (Part_Exists("tblSunrail300", aSunrail300.PartNumber) == true)
                                    {
                                        //error message
                                        //part does exist, set error message
                                        errorMessage = "Could not add" + aSunrail300.PartNumber + ". Part Number already exists.";
                                        valPartExists.Text = errorMessage;

                                    }
                                    else
                                    {
                                        Session["categoryIndex"] = 11;
                                        Session["partIndex"] = 1;
                                        Session["tableName"] = "tblSunrail300";
                                        Session["partNumber"] = aSunrail300.PartNumber;


                                        aSunrail300.Insert(datInsertDataSource, "tblSunrail300");
                                    }
                                }



                            }
                            break;
                        #endregion
                        #region Sunrail300Accessory
                        case "tblSunrail300Accessories":
                            {


                                Page.Validate("productInfo");
                                Page.Validate("pricing");
                                Page.Validate("sunrail300accessories");

                                if (Page.IsValid == true)
                                {



                                    Sunrail300Accessories aSunrail300Accessory = new Sunrail300Accessories();

                                    Session.Add("Sunrail300Accessory", aSunrail300Accessory);

                                    aSunrail300Accessory.Sunrail300AccessoriesName = txtPartName.Text;
                                    aSunrail300Accessory.PartNumber = txtPartNum.Text;
                                    aSunrail300Accessory.Sunrail300AccessoriesDescription = txtPartDesc.Text;
                                    aSunrail300Accessory.Sunrail300AccessoriesCadPrice = Convert.ToDecimal(txtCadPrice.Text);
                                    aSunrail300Accessory.Sunrail300AccessoriesUsdPrice = Convert.ToDecimal(txtUsdPrice.Text);

                                    aSunrail300Accessory.Sunrail300AccessoriesColor = ddlColors.SelectedValue;

                                    if (Part_Exists("tblSunrail300Accessories", aSunrail300Accessory.PartNumber) == true)
                                    {
                                        //error message
                                        //part does exist, set error message
                                        errorMessage = "Could not add" + aSunrail300Accessory.PartNumber + ". Part Number already exists.";
                                        valPartExists.Text = errorMessage;
                                    }
                                    else
                                    {
                                        aSunrail300Accessory.Insert(datInsertDataSource, "tblSunrail300Accessories");

                                        //Set Session Variables for Display Page
                                        Session["categoryIndex"] = 12;
                                        Session["partIndex"] = 1;
                                        Session["partNumber"] = aSunrail300Accessory.PartNumber;
                                    }
                                }
                            }
                            break;
                        #endregion
                        #region Sunrail400
                        case "tblSunrail400":
                            {

                                Page.Validate("productInfo");
                                Page.Validate("pricing");
                                Page.Validate("sunrail400");

                                if (Page.IsValid == true)
                                {
                                    Sunrail400 aSunrail400 = new Sunrail400();

                                    Session.Add("Sunrail400", aSunrail400);

                                    //Name
                                    aSunrail400.Sunrail400Name = txtPartName.Text;
                                    //Number
                                    aSunrail400.PartNumber = txtPartNum.Text;
                                    //Description
                                    aSunrail400.Sunrail400Description = txtPartDesc.Text;
                                    //Prices
                                    aSunrail400.Sunrail400CadPrice = Convert.ToDecimal(txtCadPrice.Text);
                                    aSunrail400.Sunrail400UsdPrice = Convert.ToDecimal(txtUsdPrice.Text);

                                    //Max Length in Feet
                                    aSunrail400.Sunrail400MaxLengthFeet = Convert.ToInt32(txtSun400MaxLengthFt.Text);
                                    aSunrail400.Sunrail400MaxLengthFeetUnits = "Feet";

                                    //Color
                                    aSunrail400.Sunrail400Color = ddlColors.SelectedValue;


                                    //Max Length in Inches

                                    //If user enters 0 or nothiung for the inches, we don't want the display page to show it
                                    //So set both to null in the object.
                                    if ((txtSun400PnlMaxLengthInch.Text == "") || (Convert.ToInt32(txtSun400PnlMaxLengthInch.Text) == 0))
                                    {
                                        aSunrail400.Sunrail400MaxLengthInches = null;
                                        aSunrail400.Sunrail400MaxLengthInchesUnits = null;
                                    }
                                    else
                                    //Insert the values they entered for inches into the database
                                    {
                                        aSunrail400.Sunrail400MaxLengthInches = Convert.ToInt32(txtSun400PnlMaxLengthInch.Text);
                                        aSunrail400.Sunrail400MaxLengthInchesUnits = "Inches";
                                    }





                                    //Check if part number already exists
                                    if (Part_Exists("tblSunrail400", aSunrail400.PartNumber) == true)
                                    {
                                        //error message
                                        //part does exist, set error message
                                        errorMessage = "Could not add" + aSunrail400.PartNumber + ". Part Number already exists.";
                                        valPartExists.Text = errorMessage;
                                    }
                                    else
                                    {
                                        //Insert into the database
                                        aSunrail400.Insert(datInsertDataSource, "tblSunrail400");

                                        //Set Session Variables for Display Page
                                        Session["categoryIndex"] = 13;
                                        Session["partIndex"] = 1;
                                        Session["partNumber"] = aSunrail400.PartNumber;
                                    }
                                }


                            }
                            break;
                        #endregion
                        #region VinylRoll
                        case "tblVinylRoll":
                            {

                                Page.Validate("productInfo");
                                Page.Validate("pricing");
                                Page.Validate("vinylroll");

                                if (Page.IsValid == true)
                                {
                                    VinylRoll aVinylRoll = new VinylRoll();

                                    Session.Add("VinylRoll", aVinylRoll);


                                    //Name
                                    aVinylRoll.VinylRollName = txtPartName.Text;
                                    //Number
                                    aVinylRoll.PartNumber = txtPartNum.Text;
                                    //Prices
                                    aVinylRoll.CadPrice = Convert.ToDecimal(txtCadPrice.Text);
                                    aVinylRoll.UsdPrice = Convert.ToDecimal(txtUsdPrice.Text);



                                    //Length

                                    //Weight
                                    aVinylRoll.VinylRollWeight = Convert.ToInt32(txtVinylRollWeight.Text);
                                    aVinylRoll.VinylRollWeightUnits = ddlVinylRollWeightUnits.SelectedValue;

                                    //Width
                                    aVinylRoll.VinylRollWidth = Convert.ToInt32(txtVinylRollWidth.Text);
                                    aVinylRoll.VinylRollWidthUnits = ddlVinylRollWidthUnits.SelectedValue;



                                    //Color
                                    aVinylRoll.VinylRollColor = ddlColors.SelectedValue;


                                    //Check is part number is already in database
                                    if (Part_Exists("tblVinylRoll", aVinylRoll.PartNumber) == true)
                                    {
                                        //error message
                                        //part does exist, set error message
                                        errorMessage = "Could not add" + aVinylRoll.PartNumber + ". Part Number already exists.";
                                        valPartExists.Text = errorMessage;
                                    }
                                    else
                                    {
                                        //Insert into the database
                                        aVinylRoll.Insert(datInsertDataSource, "tblVinylRoll");
                                    }

                                    //Set Session Variables for Display Page
                                    Session["categoryIndex"] = 14;
                                    Session["partIndex"] = 1;
                                    Session["partNumber"] = aVinylRoll.PartNumber;

                                }
                            }
                            break;
                        #endregion
                        #region WallExtrusions
                        case "tblWallExtrusions":
                            {

                                Page.Validate("productInfo");
                                Page.Validate("pricing");
                                Page.Validate("wallExtrusion");

                                if (Page.IsValid == true)
                                {
                                    WallExtrusions aWallExtrusion = new WallExtrusions();

                                    Session.Add("WallExtrusions", aWallExtrusion);

                                    aWallExtrusion.WallExtrusionName = txtPartName.Text;
                                    aWallExtrusion.PartNumber = txtPartNum.Text;
                                    aWallExtrusion.WallExtrusionDescription = txtPartDesc.Text;
                                    aWallExtrusion.CadPrice = Convert.ToDecimal(txtCadPrice.Text);
                                    aWallExtrusion.UsdPrice = Convert.ToDecimal(txtUsdPrice.Text);

                                    aWallExtrusion.WallExtrusionColor = ddlColors.SelectedValue;
                                    aWallExtrusion.WallExtrusionMaxLength = Convert.ToInt32(txtWallExtLength.Text);
                                    aWallExtrusion.LengthUnits = ddlWallExtLengthUnits.SelectedValue;

                                    if (Part_Exists("tblWallExtrusions", aWallExtrusion.PartNumber) == true)
                                    {
                                        //error message
                                        //part does exist, set error message
                                        errorMessage = "Could not add" + aWallExtrusion.PartNumber + ". Part Number already exists.";
                                        valPartExists.Text = errorMessage;
                                    }
                                    else
                                    {
                                        //insert
                                        aWallExtrusion.Insert(datInsertDataSource, "tblWallExtrusions");

                                        //Set Session Variables for Display Page
                                        Session["categoryIndex"] = 15;
                                        Session["partIndex"] = 1;
                                        Session["partNumber"] = aWallExtrusion.PartNumber;
                                    }
                                }
                            }
                            break;
                        #endregion
                        #region WallPanels
                        case "tblWallPanels":
                            {


                                Page.Validate("productInfo");
                                Page.Validate("pricing");
                                Page.Validate("wallPanel");
                                Page.Validate("compstand");

                                if (Page.IsValid == true)
                                {
                                    WallPanels aWallPanel = new WallPanels();

                                    Session.Add("WallPanel", aWallPanel);

                                    //Name
                                    aWallPanel.WallPanelName = txtPartName.Text;

                                    //Number
                                    aWallPanel.WallPanelNumber = txtPartNum.Text;

                                    //Description
                                    aWallPanel.WallPanelDescription = txtPartDesc.Text;

                                    //Prices
                                    aWallPanel.CadPrice = Convert.ToDecimal(txtCadPrice.Text);
                                    aWallPanel.UsdPrice = Convert.ToDecimal(txtUsdPrice.Text);

                                    //Color
                                    aWallPanel.WallPanelColor = ddlColors.SelectedValue;

                                    //Composition
                                    aWallPanel.WallPanelComposition = txtComposition.Text;
                                    //Standard
                                    aWallPanel.WallPanelStandard = txtStandard.Text;

                                    //Size
                                    aWallPanel.WallPanelSize = Convert.ToInt32(txtWallPnlSize.Text);
                                    aWallPanel.SizeUnits = ddlWallPnlSizeUnits.SelectedValue;

                                    //Max Length
                                    aWallPanel.WallPanelMaxLength = Convert.ToInt32(txtWallPnlMaxLength.Text);
                                    aWallPanel.LengthUnits = ddlWallPnlMaxLengthUnits.SelectedValue;

                                    //Max Width
                                    aWallPanel.WallPanelMaxWidth = Convert.ToInt32(txtWallPnlMaxWidth.Text);
                                    aWallPanel.WidthUnits = ddlWallPnlMaxWidthUnits.SelectedValue;

                                    if (Part_Exists("tblWallPanels", aWallPanel.WallPanelNumber) == true)
                                    {
                                        //error
                                        //part does exist, set error message
                                        errorMessage = "Could not add" + aWallPanel.WallPanelNumber + ". Part Number already exists.";
                                        valPartExists.Text = errorMessage;
                                    }
                                    else
                                    {
                                        aWallPanel.Insert(datInsertDataSource, "tblWallPanels");

                                        //Set Session Variables for Display Page
                                        Session["categoryIndex"] = 16;
                                        Session["partIndex"] = 1;
                                        Session["partNumber"] = aWallPanel.WallPanelNumber;
                                    }

                                }

                                break;
                            }
                        #endregion
                           
                    }

                    if ((Page.IsValid == true) && (errorMessage==""))
                    {

                        //Check to see if temp picture exists
                        if (System.IO.File.Exists(Server.MapPath("Images/catalogue/temp.jpg")))
                        {
                            //Save picture
                            System.IO.File.Copy(Server.MapPath("Images/catalogue/temp.jpg"), Server.MapPath("Images/catalogue/" + Session["partNumber"].ToString() + ".jpg"), true);
                        }
                        //redirect to Display.aspx
                        Response.Redirect("Display.aspx");
                    }
                
            }
    
        }
        #endregion


        protected void btnReset_Click(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                //Re-initialize this page
                Response.Redirect("Insert.aspx");
            }
        }

        protected void btnMainMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainMenu.aspx");
        }

        protected void ddlTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            DropDownList dropdown;

            dropdown = (DropDownList)(pnlProduct.FindControl("ddlTables"));

            Session["tableName"] = ddlTables.SelectedValue.ToString();

            txtPartName.Text = "";

            foreach (Control ctrl in pnlProduct.Controls)
            {




                if (ctrl != dropdown)
                {
                    Reset(ctrl);
                }
            }

            foreach(Control ctrl in pnlDimensions.Controls)
            {
                Reset(ctrl);
            }

            

        }


        //Resets all input controls
        public void ResetInputs(Control form)
        {
            foreach (Control ctrl in Controls)
            {
                //if (ctrl.Controls.Count > 0)
                //{
                    //ResetFields(ctrl);
                //}
                Reset(ctrl);
            }
        }
        //Clears out input for a control
        public void Reset(Control ctrl)
        {
            if (ctrl is TextBox)
            {
                TextBox tb = (TextBox)ctrl;
                if (tb != null)
                {
                    tb.Text = "";
                }
            }
            else if (ctrl is DropDownList)
            {
                DropDownList dd = (DropDownList)ctrl;
                if (dd != null)
                {
                    dd.SelectedIndex = 0;
                }
            }
        }

        protected void btnUploadImg_Click(object sender, EventArgs e)
        {
             if (Page.IsPostBack)
            {
                if (fupNewImage.HasFile)
                {
                    if (fupNewImage.PostedFile.ContentType == "image/jpeg" || fupNewImage.PostedFile.ContentType == "image/png")
                    {
                        fupNewImage.SaveAs(System.IO.Path.Combine(Server.MapPath("Images/catalogue/temp.jpg")));
                        imgPart.ImageUrl = "Images/catalogue/temp.jpg";
                        Session.Add("updateChanged", "true");
                        Session.Add("picChanged", true);

                        
                    }
                    else
                    {
                        valFupNewImage.Text = "Must be an image of type jpeg or png";
                    }
                }
            }
        }
             
    }
}
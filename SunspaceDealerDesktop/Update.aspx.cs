/*
 * Dan Barlow
 * November 6, 2012
 * Update.aspx version 1.0
 */ 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sunspace
{
    public partial class Update : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label firstLabel = (Label)Master.FindControl("lblUpdate");
            if (firstLabel != null)
            {
                firstLabel.Text = "UPDATE";
            }

            Label secondLabel = (Label)Master.FindControl("lblPartNumTitle");
            if (secondLabel != null)
            {
                secondLabel.Text = Session["partNumber"].ToString();
            }
            if (!Page.IsPostBack)
            {
                //prevent backdoor
                if (Session["tableName"] == null)
                {
                    Response.Redirect("ProductSelect.aspx");
                }
                else
                {
                    //load dropdowns
                    if (!Page.IsPostBack)
                    {
                        //set up a dataview object to hold table names for the first drop down
                        System.Data.DataView tableList = new System.Data.DataView();

                        //select table names
                        datSelectDataSource.SelectCommand = "SELECT name FROM sys.tables WHERE name != 'tblColor' AND name != 'tblSchematicParts' AND name != 'tblParts' AND name != 'tblLengthUnits'  AND name != 'tblAudits' AND name != 'tblSalesOrders' AND name != 'tblSalesOrderItems' ORDER BY name ASC";                        //assign the table names to the dataview object
                        tableList = (System.Data.DataView)datSelectDataSource.Select(System.Web.UI.DataSourceSelectArguments.Empty);

                        //variable to determine amount of rows in the dataview object
                        int rowCount = tableList.Count;

                        ddlCategory.Items.Add("");
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

                        //load part list
                        if (ddlCategory.SelectedValue != "")
                        {
                            //get table name selected
                            string tableName = "tbl" + ddlCategory.SelectedValue.Replace(" ", "");

                            //set up a dataview object to hold part numbers for the second drop down
                            System.Data.DataView partsList = new System.Data.DataView();

                            if (tableName != "tblSchematics")
                            {
                                //select part numbers
                                datSelectDataSource.SelectCommand = "SELECT partNumber, partName FROM " + tableName + " ORDER BY partNumber ASC";
                            }
                            else
                            {
                                datSelectDataSource.SelectCommand = "SELECT schematicNumber, partName FROM " + tableName + " ORDER BY schematicNumber ASC";
                            }
                            //assign the table names to the dataview object
                            partsList = (System.Data.DataView)datSelectDataSource.Select(System.Web.UI.DataSourceSelectArguments.Empty);

                            //clear second drop down
                            ddlPart.Items.Clear();

                            //Insert empty string to first row of second drop down
                            ddlPart.Items.Add("");

                            rowCount = partsList.Count;
                            //populate second drop down
                            for (int i = 0; i < rowCount; i++)
                            {
                                ddlPart.Items.Add(partsList[i][0].ToString() + " (" + partsList[i][1].ToString() + ")");
                            }

                            Session.Add("updateChanged", "true");
                        }
                    }

                    //only run if the display has changed, to allow display postback changes
                    if (Session["updateChanged"] != null)
                    {
                        //we're running this, so the display has been updated, and is not set for change
                        Session.Remove("updateChanged");
                        //select part dropdown default value             
                        ddlPart.SelectedIndex = (int)Session["partIndex"];

                        //show navigation arrows
                        imgPrevArrow.CssClass = "prevArrow";
                        imgNextArrow.CssClass = "nextArrow";

                        if (ddlPart.SelectedIndex == (ddlPart.Items.Count - 1))
                        {
                            //if last item, don't show 'next' arrow
                            imgNextArrow.CssClass = "removeElement";
                        }
                        else if (ddlPart.SelectedIndex == 1)
                        {
                            //if first item, don't show 'prev' arrow
                            imgPrevArrow.CssClass = "removeElement";
                        }

                        //Clear updated object in session
                        if (Session["updatedObject"] != null)
                        {
                            Session.Remove("updatedObject");
                        }

                        //get table selected from session
                        string tableName = Session["tableName"].ToString();
                        #region Display Pricing Only
                        if (Session["pricingOnly"] != null)
                        {
                            lblPartKey.CssClass = "removeElement";
                            pnlPackQuantity.CssClass = "removeElement";
                            pnlComposition.CssClass = "removeElement";
                            pnlStandard.CssClass = "removeElement";
                            pnlDimensions.CssClass = "removeElement";
                            pnlStatus.CssClass = "removeElement";
                            btnUploadImg.CssClass = "removeElement";
                            txtPartDesc.CssClass = "txtInputFieldDisabled";
                            pnlSchematics.CssClass = "removeElement";
                            pnlPricingSchematics.CssClass = "removeElement";
                            //Switch statement for displaying according to selected product
                            
                            switch (tableName)
                            {
                                #region RoofExtrusion
                                //When Roof Extrusions is selected
                                case "tblRoofExtrusions":
                                    {
                                        //create RoofExtrusion object
                                        RoofExtrusion aRoofExtrusion = new RoofExtrusion();

                                        //call select all function to populate object
                                        aRoofExtrusion.Populate(aRoofExtrusion.SelectAll(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString()));

                                        //populate fields
                                        imgPart.ImageUrl = "Images/catalogue/" + Session["partNumber"].ToString() + ".jpg";
                                        lblPartName.Text = aRoofExtrusion.ExtrusionName;
                                        txtPartDesc.Text = aRoofExtrusion.ExtrusionDescription;
                                        lblPartNum.Text = aRoofExtrusion.ExtrusionNumber;
                                        lblColorInput.Text = aRoofExtrusion.ExtrusionColor;
                                        txtUsdPrice.Text = aRoofExtrusion.UsdPrice.ToString("N2");
                                        txtCadPrice.Text = aRoofExtrusion.CadPrice.ToString("N2");

                                        break;
                                    }
                                #endregion
                                #region Accessories
                                //When Accessories is selected
                                case "tblAccessories":
                                    {
                                        //create Accessories object
                                        Accessories anAccessory = new Accessories();

                                        //call select all function to populate object
                                        anAccessory.Populate(anAccessory.SelectAll(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString()));

                                        //add Accessories Object to the session
                                        Session.Add("accessories", anAccessory);

                                        //populate fields
                                        lblPartName.Text = anAccessory.AccessoryName;
                                        txtPartDesc.Text = anAccessory.AccessoryDescription;
                                        lblPartNum.Text = anAccessory.AccessoryNumber;
                                        txtUsdPrice.Text = anAccessory.AccessoryUsdPrice.ToString("N2");
                                        txtCadPrice.Text = anAccessory.AccessoryCadPrice.ToString("N2");
                                        imgPart.ImageUrl = "Images/catalogue/" + Session["partNumber"].ToString() + ".jpg";

                                        if (anAccessory.AccessoryColor != "")
                                        {
                                            lblColorInput.Text = anAccessory.AccessoryColor;
                                        }
                                        else
                                        {
                                            lblColorInput.CssClass = "removeElement";
                                            lblColor.CssClass = "removeElement";
                                        }


                                        break;
                                    }
                                #endregion

                                #region DecorativeColumn
                                //When Decorative Column is selected
                                case "tblDecorativeColumn":
                                    {
                                        //create DecorativeColumn object
                                        DecorativeColumn aColumn = new DecorativeColumn();

                                        //call select all function to populate object
                                        aColumn.Populate(aColumn.SelectAll(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString()));

                                        //add DecorativeColumn Object to the session
                                        Session.Add("decorativeColumn", aColumn);

                                        //populate fields
                                        lblPartName.Text = aColumn.ColumnName;
                                        txtPartDesc.Text = aColumn.ColumnDescription;
                                        lblPartNum.Text = aColumn.PartNumber;
                                        lblColorInput.Text = aColumn.ColumnColor;
                                        txtUsdPrice.Text = aColumn.ColumnUsdPrice.ToString("N2");
                                        txtCadPrice.Text = aColumn.ColumnCadPrice.ToString("N2");
                                        imgPart.ImageUrl = "Images/catalogue/" + Session["partNumber"].ToString() + ".jpg";

                                        break;
                                    }
                                #endregion

                                #region DoorFrameExtrusion
                                //When Door Frame Extrusion is selected
                                case "tblDoorFrameExtrusion":
                                    {
                                        //create DoorFrameExtrusion object
                                        DoorFrameExtrusion aFrameExtrusion = new DoorFrameExtrusion();

                                        //call select all function to populate object
                                        aFrameExtrusion.Populate(aFrameExtrusion.SelectAll(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString()));

                                        //populate fields

                                        lblPartName.Text = aFrameExtrusion.DfeName;
                                        txtPartDesc.Text = aFrameExtrusion.DfeDescription;
                                        lblPartNum.Text = aFrameExtrusion.PartNumber;
                                        lblColorInput.Text = aFrameExtrusion.DfeColor;
                                        txtUsdPrice.Text = aFrameExtrusion.UsdPrice.ToString("N2");
                                        txtCadPrice.Text = aFrameExtrusion.CadPrice.ToString("N2");
                                        imgPart.ImageUrl = "Images/catalogue/" + Session["partNumber"].ToString() + ".jpg";

                                        break;
                                    }
                                #endregion

                                #region InsulatedFloors
                                //When Insulated Floors is selected
                                case "tblInsulatedFloors":
                                    {
                                        lblColor.CssClass = "removeElement";
                                        lblColorInput.CssClass = "removeElement";

                                        //create InsulatedFloors object
                                        InsulatedFloors aFloor = new InsulatedFloors();

                                        //call select all function to populate object
                                        aFloor.Populate(aFloor.SelectAll(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString()));

                                        //populate fields
                                        lblPartName.Text = aFloor.InsulatedFloorName;
                                        txtPartDesc.Text = aFloor.InsulatedFloorDescription;
                                        lblPartNum.Text = aFloor.PartNumber;
                                        txtUsdPrice.Text = aFloor.InsulatedFloorUsdPrice.ToString("N2");
                                        txtCadPrice.Text = aFloor.InsulatedFloorCadPrice.ToString("N2");
                                        imgPart.ImageUrl = "Images/catalogue/" + Session["partNumber"].ToString() + ".jpg";

                                        break;
                                    }
                                #endregion

                                #region RoofPanels
                                //When Roof Panels is selected
                                case "tblRoofPanels":
                                    {
                                        //create RoofPanels object
                                        RoofPanels aPanel = new RoofPanels();

                                        //call select all function to populate object
                                        aPanel.Populate(aPanel.SelectAll(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString()));

                                        //populate fields
                                        lblPartName.Text = aPanel.PanelName;
                                        txtPartDesc.Text = aPanel.PanelDescription;
                                        lblPartNum.Text = aPanel.PartNumber;
                                        lblColorInput.Text = aPanel.PanelColor;

                                        txtUsdPrice.Text = aPanel.UsdPrice.ToString("N2");
                                        txtCadPrice.Text = aPanel.CadPrice.ToString("N2");
                                        imgPart.ImageUrl = "Images/catalogue/" + Session["partNumber"].ToString() + ".jpg";

                                        break;
                                    }
                                #endregion


                                #region ScreenRoll
                                //When Screen Roll is selected
                                case "tblScreenRoll":
                                    {
                                        lblColor.CssClass = "removeElement";
                                        lblColorInput.CssClass = "removeElement";

                                        //create ScreenRoll object
                                        ScreenRoll aScreenRoll = new ScreenRoll();

                                        //call select all function to populate object
                                        aScreenRoll.Populate(aScreenRoll.SelectAll(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString()));

                                        //populate fields
                                        imgPart.ImageUrl = "Images/catalogue/" + Session["partNumber"].ToString() + ".jpg";
                                        lblPartName.Text = aScreenRoll.ScreenRollName;
                                        lblPartNum.Text = aScreenRoll.PartNumber;

                                        txtUsdPrice.Text = aScreenRoll.UsdPrice.ToString("N2");
                                        txtCadPrice.Text = aScreenRoll.CadPrice.ToString("N2");
                                        break;
                                    }
                                #endregion


                                #region SuncrylicRoof
                                //When Suncrylic roof is selected
                                case "tblSuncrylicRoof":
                                    {
                                        //create ScreenRoll object
                                        SuncrylicRoof aSunRoof = new SuncrylicRoof();

                                        //call select all function to populate object
                                        aSunRoof.Populate(aSunRoof.SelectAll(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString()));

                                        //populate fields
                                        imgPart.ImageUrl = "Images/catalogue/" + Session["partNumber"].ToString() + ".jpg";
                                        lblPartName.Text = aSunRoof.SuncrylicName;
                                        lblPartNum.Text = aSunRoof.PartNumber;

                                        txtUsdPrice.Text = aSunRoof.UsdPrice.ToString("N2");
                                        txtCadPrice.Text = aSunRoof.CadPrice.ToString("N2");
                                        break;
                                    }
                                #endregion

                                #region VinylRoll
                                //When Vinyl Roll is selected
                                case "tblVinylRoll":
                                    {
                                        //create ScreenRoll object
                                        VinylRoll aVinylRoll = new VinylRoll();

                                        //call select all function to populate object
                                        aVinylRoll.Populate(aVinylRoll.SelectAll(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString()));

                                        //populate fields
                                        imgPart.ImageUrl = "Images/catalogue/" + Session["partNumber"].ToString() + ".jpg";
                                        lblPartName.Text = aVinylRoll.VinylRollName;
                                        lblPartNum.Text = aVinylRoll.PartNumber;
                                        lblColorInput.Text = aVinylRoll.VinylRollColor;
                                        txtUsdPrice.Text = aVinylRoll.UsdPrice.ToString("N2");
                                        txtCadPrice.Text = aVinylRoll.CadPrice.ToString("N2");

                                        break;
                                    }
                                #endregion

                                #region Sunrail300
                                //When Sunrail 300 is selected
                                case "tblSunrail300":
                                    {
                                        //create Sunrail300 object
                                        Sunrail300 aSunrail300 = new Sunrail300();

                                        //call select all function to populate object
                                        aSunrail300.Populate(aSunrail300.SelectAll(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString()));

                                        //populate fields
                                        imgPart.ImageUrl = "Images/catalogue/" + Session["partNumber"].ToString() + ".jpg";
                                        lblPartName.Text = aSunrail300.Sunrail300Name;
                                        lblPartNum.Text = aSunrail300.PartNumber;
                                        lblColorInput.Text = aSunrail300.Sunrail300Color;
                                        txtUsdPrice.Text = aSunrail300.Sunrail300UsdPrice.ToString("N2");
                                        txtCadPrice.Text = aSunrail300.Sunrail300CadPrice.ToString("N2");

                                        break;
                                    }
                                #endregion

                                #region Sunrail300Accessories
                                //When Sunrail 300 Accessories is selected
                                case "tblSunrail300Accessories":
                                    {
                                        //create Sunrail300Accessories object
                                        Sunrail300Accessories aSunrail300Accessories = new Sunrail300Accessories();

                                        //call select all function to populate object
                                        aSunrail300Accessories.Populate(aSunrail300Accessories.SelectAll(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString()));

                                        //populate fields
                                        imgPart.ImageUrl = "Images/catalogue/" + Session["partNumber"].ToString() + ".jpg";
                                        lblPartName.Text = aSunrail300Accessories.Sunrail300AccessoriesName;
                                        lblPartNum.Text = aSunrail300Accessories.PartNumber;
                                        lblColorInput.Text = aSunrail300Accessories.Sunrail300AccessoriesColor;
                                        txtUsdPrice.Text = aSunrail300Accessories.Sunrail300AccessoriesUsdPrice.ToString("N2");
                                        txtCadPrice.Text = aSunrail300Accessories.Sunrail300AccessoriesCadPrice.ToString("N2");

                                        break;
                                    }
                                #endregion


                                #region Sunrail400
                                //When Sunrail 400 is selected
                                case "tblSunrail400":
                                    {
                                        //create Sunrail400 object
                                        Sunrail400 aSunrail400 = new Sunrail400();

                                        //call select all function to populate object
                                        aSunrail400.Populate(aSunrail400.SelectAll(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString()));

                                        //populate fields
                                        imgPart.ImageUrl = "Images/catalogue/" + Session["partNumber"].ToString() + ".jpg";
                                        lblPartName.Text = aSunrail400.Sunrail400Name;
                                        lblPartNum.Text = aSunrail400.PartNumber;
                                        lblColorInput.Text = aSunrail400.Sunrail400Color;
                                        txtUsdPrice.Text = aSunrail400.Sunrail400UsdPrice.ToString("N2");
                                        txtCadPrice.Text = aSunrail400.Sunrail400CadPrice.ToString("N2");
                                        break;
                                    }
                                #endregion

                                #region Sunrail1000
                                //When Sunrail 1000 is selected
                                case "tblSunrail1000":
                                    {
                                        //create Sunrail1000 object
                                        Sunrail1000 aSunrail1000 = new Sunrail1000();

                                        //call select all function to populate object
                                        aSunrail1000.Populate(aSunrail1000.SelectAll(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString()));

                                        //populate fields
                                        imgPart.ImageUrl = "Images/catalogue/" + Session["partNumber"].ToString() + ".jpg";
                                        lblPartName.Text = aSunrail1000.Sunrail1000Name;
                                        lblPartNum.Text = aSunrail1000.PartNumber;
                                        lblColorInput.Text = aSunrail1000.Sunrail1000Color;
                                        txtUsdPrice.Text = aSunrail1000.Sunrail1000UsdPrice.ToString("N2");
                                        txtCadPrice.Text = aSunrail1000.Sunrail1000CadPrice.ToString("N2");
                                        break;
                                    }
                                #endregion

                                #region WallExtrusions
                                case "tblWallExtrusions":
                                    {
                                        //create Sunrail1000 object
                                        WallExtrusions aWallExtrusion = new WallExtrusions();

                                        //call select all function to populate object
                                        aWallExtrusion.Populate(aWallExtrusion.SelectAll(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString()));

                                        //populate fields
                                        imgPart.ImageUrl = "Images/catalogue/" + Session["partNumber"].ToString() + ".jpg";
                                        lblPartName.Text = aWallExtrusion.WallExtrusionName;
                                        lblPartNum.Text = aWallExtrusion.PartNumber;
                                        lblColorInput.Text = aWallExtrusion.WallExtrusionColor;
                                        txtUsdPrice.Text = aWallExtrusion.UsdPrice.ToString("N2");
                                        txtCadPrice.Text = aWallExtrusion.CadPrice.ToString("N2");
                                        break;
                                    }
                                #endregion


                                #region WallPanels
                                case "tblWallPanels":
                                    {
                                        //create Sunrail1000 object
                                        WallPanels aWallPanel = new WallPanels();

                                        //call select all function to populate object
                                        aWallPanel.Populate(aWallPanel.SelectAll(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString()));

                                        //populate fields
                                        imgPart.ImageUrl = "Images/catalogue/" + Session["partNumber"].ToString() + ".jpg";
                                        lblPartName.Text = aWallPanel.WallPanelName;
                                        lblPartNum.Text = aWallPanel.WallPanelNumber;
                                        lblColorInput.Text = aWallPanel.WallPanelColor;
                                        txtUsdPrice.Text = aWallPanel.UsdPrice.ToString("N2");
                                        txtCadPrice.Text = aWallPanel.CadPrice.ToString("N2");
                                        break;
                                    }
                                #endregion

                                #region Schematics
                                case "tblSchematics":
                                    {
                                        rowPart1.CssClass = "removeElement";
                                        rowPart1Val.CssClass = "removeElement";
                                        rowPart2.CssClass = "removeElement";
                                        rowPart2Val.CssClass = "removeElement";
                                        rowPart3.CssClass = "removeElement";
                                        rowPart3Val.CssClass = "removeElement";
                                        rowPart4.CssClass = "removeElement";
                                        rowPart4Val.CssClass = "removeElement";
                                        rowPart5.CssClass = "removeElement";
                                        rowPart5Val.CssClass = "removeElement";
                                        rowPart6.CssClass = "removeElement";
                                        rowPart6Val.CssClass = "removeElement";
                                        rowPart7.CssClass = "removeElement";
                                        rowPart7Val.CssClass = "removeElement";
                                        rowPart8.CssClass = "removeElement";
                                        rowPart8Val.CssClass = "removeElement";
                                        rowPart9.CssClass = "removeElement";
                                        rowPart9Val.CssClass = "removeElement";
                                        rowPart10.CssClass = "removeElement";
                                        rowPart10Val.CssClass = "removeElement";
                                        rowPart11.CssClass = "removeElement";
                                        rowPart11Val.CssClass = "removeElement";
                                        rowPart12.CssClass = "removeElement";
                                        rowPart12Val.CssClass = "removeElement";
                                        rowPart13.CssClass = "removeElement";
                                        rowPart13Val.CssClass = "removeElement";
                                        rowPart14.CssClass = "removeElement";
                                        rowPart14Val.CssClass = "removeElement";
                                        rowPart15.CssClass = "removeElement";
                                        rowPart15Val.CssClass = "removeElement";
                                        rowPart16.CssClass = "removeElement";
                                        rowPart16Val.CssClass = "removeElement";
                                        rowPart17.CssClass = "removeElement";
                                        rowPart17Val.CssClass = "removeElement";
                                        rowPart18.CssClass = "removeElement";
                                        rowPart18Val.CssClass = "removeElement";
                                        rowPart19.CssClass = "removeElement";
                                        rowPart19Val.CssClass = "removeElement";
                                        rowPart20.CssClass = "removeElement";
                                        rowPart20Val.CssClass = "removeElement";
                                        rowPart21.CssClass = "removeElement";
                                        rowPart21Val.CssClass = "removeElement";
                                        rowPart22.CssClass = "removeElement";
                                        rowPart22Val.CssClass = "removeElement";
                                        rowPart23.CssClass = "removeElement";
                                        rowPart23Val.CssClass = "removeElement";

                                        lblSchemPartNum.CssClass = "removeElement";
                                        lblSchemPartKey.CssClass = "removeElement";
                                        lblSchemPartKeyNum.CssClass = "removeElement";
                                        lblSchemPartName.CssClass = "removeElement";

                                        lblColor.CssClass = "removeElement";
                                        lblColorInput.CssClass = "removeElement";
                                        pnlDimensions.CssClass = "removeElement";
                                        pnlPricing.CssClass = "removeElement";

                                        //show pnlSchematics and pricingSchemTable
                                        pnlSchematics.CssClass = "showElementNoClass";
                                        pnlPricingSchematics.CssClass = "pnlPricing";

                                        imgPart.ImageUrl = "Images/catalogue/" + Session["partNumber"].ToString() + ".jpg";

                                        //create Schematics object
                                        Schematics aSchematic = new Schematics();

                                        //call select all function to populate object
                                        aSchematic.Populate(aSchematic.SelectAll(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString()));

                                        //add RoofPanels Object to the session
                                        Session.Add("schematic", aSchematic);

                                        //populate fields

                                        //set up a dataview object for object member data
                                        System.Data.DataView aPartsTable = new System.Data.DataView();

                                        //select row based on table name and part number
                                        datUpdateDataSource.SelectCommand = "SELECT partNumber FROM tblSchematicParts WHERE schematicNumber='" + Session["partNumber"] + "' ORDER BY keyNumber ASC";

                                        //assign the row to the dataview object
                                        aPartsTable = (System.Data.DataView)datUpdateDataSource.Select(System.Web.UI.DataSourceSelectArguments.Empty);

                                        ddlSchem.Items.Clear();
                                        ddlSchem.Items.Add("");

                                        for (int i = 0; i < aPartsTable.Count; i++)
                                        {
                                            ddlSchem.Items.Add(aPartsTable[i][0].ToString());
                                        }

                                        lblPartName.Text = aSchematic.SchematicName.ToString();
                                        txtPartDesc.Text = aSchematic.SchematicDescription.ToString();
                                        lblPartNum.Text = aSchematic.SchematicNumber.ToString();

                                        txtUsdPriceSchematic.Text = aSchematic.SchematicUsdPrice.ToString("N2");
                                        txtCadPriceSchematic.Text = aSchematic.SchematicCadPrice.ToString("N2");

                                        rfvSchemWholeUsd.ValidationGroup = "pricing";
                                        cmpSchemWholeUsd.ValidationGroup = "pricing";
                                        rfvSchemWholeCad.ValidationGroup = "pricing";
                                        cmpSchemWholeCad.ValidationGroup = "pricing";

                                        break;
                                    }
                                #endregion
                            }
                        }
                        #endregion
                        else
                        #region Display Pricing and Product Info
                        {
                            //Hide selected 'product' panels
                            lblPartKey.CssClass = "removeElement";
                            pnlPackQuantity.CssClass = "removeElement";
                            pnlComposition.CssClass = "removeElement";
                            pnlStandard.CssClass = "removeElement";
                            txtPartDesc.CssClass = "txtInputFieldDesc";
                            //Hide all 'dimension' panels
                            pnlAccessories.CssClass = "removeElement";
                            pnlDecorativeColumn.CssClass = "removeElement";
                            pnlDoorFrameExtrusions.CssClass = "removeElement";
                            pnlInsulatedFloors.CssClass = "removeElement";
                            pnlRoofExtrusions.CssClass = "removeElement";
                            pnlRoofPanels.CssClass = "removeElement";
                            pnlSchematics.CssClass = "removeElement";
                            pnlScreenRoll.CssClass = "removeElement";
                            pnlSuncrylicRoof.CssClass = "removeElement";
                            pnlSunrail1000.CssClass = "removeElement";
                            pnlSunrail300.CssClass = "removeElement";
                            pnlSunrail400.CssClass = "removeElement";
                            pnlVinylRoll.CssClass = "removeElement";
                            pnlWallExtrusions.CssClass = "removeElement";
                            pnlWallPanel.CssClass = "removeElement";
                            pnlPricingSchematics.CssClass = "removeElement";
                            //Switch statement for displaying according to selected product
                            switch (tableName)
                            {
                                #region RoofExtrusions
                                //when tblRoofExtrusions is selected                        
                                case "tblRoofExtrusions":

                                    if (Session["roofExtrusion"] != null)
                                    {
                                        Session.Remove("roofExtrusion");
                                    }

                                    //show pnlRoofExtrusion
                                    pnlRoofExtrusions.CssClass = "dimensionsTable";

                                    //create RoofExtrusion object
                                    RoofExtrusion aRoofExtrusion = new RoofExtrusion();

                                    //add RoofExtrusion Object to the session
                                    Session.Add("roofExtrusion", aRoofExtrusion);

                                    //call select all function to populate object
                                    aRoofExtrusion.Populate(aRoofExtrusion.SelectAll(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString()));

                                    //populate fields
                                    imgPart.ImageUrl = "Images/catalogue/" + Session["partNumber"].ToString() + ".jpg";
                                    
                                    lblPartName.Text = aRoofExtrusion.ExtrusionName;
                                    txtPartDesc.Text = aRoofExtrusion.ExtrusionDescription;
                                    lblPartNum.Text = aRoofExtrusion.ExtrusionNumber;
                                    lblColorInput.Text = aRoofExtrusion.ExtrusionColor;

                                    //conditional field display, based on whether members have default values or not
                                    if (aRoofExtrusion.ExtrusionSize != 0)
                                    {
                                        lblRoofExtSizeUnits.Text = aRoofExtrusion.SizeUnits.ToString();
                                        txtRoofExtSize.Text = aRoofExtrusion.ExtrusionSize.ToString();
                                        rfvRoofExtSize.ValidationGroup = "roofExtrusion";
                                        cmpRoofExtSize.ValidationGroup = "roofExtrusion";
                                    }
                                    else
                                    {
                                        rowRoofExtSize.CssClass = "removeElement";
                                    }

                                    if (aRoofExtrusion.AngleA != 0)
                                    {
                                        lblRoofExtAngleAUnits.Text = aRoofExtrusion.AngleAUnits.ToString();
                                        txtRoofExtAngleA.Text = aRoofExtrusion.AngleA.ToString();
                                        rfvRoofExtAngleA.ValidationGroup = "roofExtrusion";
                                        cmpRoofExtAngleA.ValidationGroup = "roofExtrusion";
                                    }
                                    else
                                    {
                                        rowRoofExtAngleA.CssClass = "removeElement";
                                    }

                                    if (aRoofExtrusion.AngleB != 0)
                                    {
                                        lblRoofExtAngleBUnits.Text = aRoofExtrusion.AngleBUnits.ToString();
                                        txtRoofExtAngleB.Text = aRoofExtrusion.AngleB.ToString();
                                        rfvRoofExtAngleB.ValidationGroup = "roofExtrusion";
                                        cmpRoofExtAngleB.ValidationGroup = "roofextrusion";
                                    }
                                    else
                                    {
                                        rowRoofExtAngleB.CssClass = "removeElement";
                                    }

                                    if (aRoofExtrusion.AngleC != 0)
                                    {
                                        lblRoofExtAngleCUnits.Text = aRoofExtrusion.AngleCUnits.ToString();
                                        txtRoofExtAngleC.Text = aRoofExtrusion.AngleC.ToString();
                                        rfvRoofExtAngleC.ValidationGroup = "roofExtrusion";
                                        cmpRoofExtAngleC.ValidationGroup = "roofExtrusion";
                                    }
                                    else
                                    {
                                        rowRoofExtAngleC.CssClass = "removeElement";
                                    }

                                    txtRoofExtMaxLength.Text = aRoofExtrusion.ExtrusionMaxLength.ToString();
                                    lblRoofExtMaxLengthUnits.Text = aRoofExtrusion.MaxLengthUnits.ToString();
                                    rfvRoofExtMaxLength.ValidationGroup = "roofExtrusion";
                                    cmpRoofExtMaxLength.ValidationGroup = "roofExtrusion";

                                    txtUsdPrice.Text = aRoofExtrusion.UsdPrice.ToString("N2");
                                    txtCadPrice.Text = aRoofExtrusion.CadPrice.ToString("N2");


                                    if (aRoofExtrusion.Status)
                                    {
                                        radActive.Checked = true;
                                    }
                                    else
                                    {
                                        radInactive.Checked = true;
                                    }

                                    break;
                                #endregion
                                #region Accessories
                                //when tblAccessories is selected
                                case "tblAccessories":

                                    if (Session["accessories"] != null)
                                    {
                                        Session.Remove("accessories");
                                    }

                                    //show pnlAccessories
                                    pnlPackQuantity.CssClass = "showPanelNoClass";
                                    pnlAccessories.CssClass = "dimensionsTable";

                                    //create Accessories object
                                    Accessories anAccessory = new Accessories();

                                    //call select all function to populate object
                                    anAccessory.Populate(anAccessory.SelectAll(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString()));

                                    //add Accessories Object to the session
                                    Session.Add("accessories", anAccessory);

                                    //populate fields
                                    imgPart.ImageUrl = "Images/catalogue/" + Session["partNumber"].ToString() + ".jpg";
                                    lblPartName.Text = anAccessory.AccessoryName;
                                    txtPartDesc.Text = anAccessory.AccessoryDescription;
                                    lblPartNum.Text = anAccessory.AccessoryNumber;

                                    //conditional field display, based on whether members have default values or not
                                    if (anAccessory.AccessoryColor != "")
                                    {
                                        lblColorInput.Text = anAccessory.AccessoryColor;
                                    }
                                    else
                                    {
                                        lblColorInput.CssClass = "removeElement";
                                        lblColor.CssClass = "removeElement";
                                    }

                                    if (anAccessory.AccessoryPackQuantity != 0)
                                    {
                                        txtPackQuantity.Text = anAccessory.AccessoryPackQuantity.ToString();
                                        rfvPackQuantity.ValidationGroup = "accessories";
                                        cmpPackQuantity.ValidationGroup = "accessories";
                                    }
                                    else
                                    {
                                        pnlPackQuantity.CssClass = "removeElement";
                                    }

                                    if (anAccessory.AccessoryWidth != 0)
                                    {
                                        lblAccessoryWidthUnits.Text = anAccessory.AccessoryWidthUnits;
                                        txtAccessoryWidth.Text = anAccessory.AccessoryWidth.ToString();
                                        rfvAccessoryWidth.ValidationGroup = "accessories";
                                        cmpAccessoryWidth.ValidationGroup = "accessories";
                                    }
                                    else
                                    {
                                        rowAccessoryMaxWidth.CssClass = "removeElement";
                                    }

                                    if (anAccessory.AccessoryLength != 0)
                                    {
                                        lblAccessoryLengthUnits.Text = anAccessory.AccessoryLengthUnits;
                                        txtAccessoryLength.Text = anAccessory.AccessoryLength.ToString();
                                        rfvAccessoryLength.ValidationGroup = "accessories";
                                        cmpAccessoryLength.ValidationGroup = "accessories";
                                    }
                                    else
                                    {
                                        rowAccessoryMaxLength.CssClass = "removeElement";
                                    }

                                    if (anAccessory.AccessorySize != 0)
                                    {
                                        lblAccessorySizeUnits.Text = anAccessory.AccessorySizeUnits;
                                        txtAccessorySize.Text = anAccessory.AccessorySize.ToString();
                                        rfvAccessorySize.ValidationGroup = "accessories";
                                        cmpAccessorySize.ValidationGroup = "accessories";
                                    }
                                    else
                                    {
                                        rowAccessorySize.CssClass = "removeElement";
                                    }

                                    txtUsdPrice.Text = anAccessory.AccessoryUsdPrice.ToString("N2");
                                    txtCadPrice.Text = anAccessory.AccessoryCadPrice.ToString("N2");

                                    if ((txtAccessoryLength.Text == "") && (txtAccessorySize.Text == "") && (txtAccessoryWidth.Text == ""))
                                    {
                                        pnlDimensions.CssClass = "removeElement";
                                    }

                                    if (anAccessory.AccessoryStatus)
                                    {
                                        radActive.Checked = true;
                                    }
                                    else
                                    {
                                        radInactive.Checked = true;
                                    }

                                    break;
                                #endregion
                                #region DecorativeColumn
                                //when tblDecorativeColumn is selected
                                case "tblDecorativeColumn":

                                    if (Session["decorativeColumn"] != null)
                                    {
                                        Session.Remove("decorativeColumn");
                                    }

                                    //show pnlDecorativeColumn
                                    pnlDecorativeColumn.CssClass = "dimensionsTable";

                                    //create DecorativeColumn object
                                    DecorativeColumn aColumn = new DecorativeColumn();

                                    //call select all function to populate object
                                    aColumn.Populate(aColumn.SelectAll(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString()));

                                    //add DecorativeColumn Object to the session
                                    Session.Add("decorativeColumn", aColumn);

                                    //populate fields
                                    imgPart.ImageUrl = "Images/catalogue/" + Session["partNumber"].ToString() + ".jpg";
                                    lblPartName.Text = aColumn.ColumnName;
                                    txtPartDesc.Text = aColumn.ColumnDescription;
                                    lblPartNum.Text = aColumn.PartNumber;
                                    lblColorInput.Text = aColumn.ColumnColor;
                                    txtRoofDecColLength.Text = aColumn.ColumnLength.ToString();
                                    lblRoofDecColLengthUnits.Text = aColumn.ColumnLengthUnits;

                                    rfvRoofDecColLength.ValidationGroup = "decorativeColumn";
                                    cmpRoofDecColLength.ValidationGroup = "decorativeColumn";

                                    txtUsdPrice.Text = aColumn.ColumnUsdPrice.ToString("N2");
                                    txtCadPrice.Text = aColumn.ColumnCadPrice.ToString("N2");

                                    if (aColumn.ColumnStatus)
                                    {
                                        radActive.Checked = true;
                                    }
                                    else
                                    {
                                        radInactive.Checked = true;
                                    }

                                    break;
                                #endregion
                                #region DoorFrameExtrusion
                                //when tblDoorFrameExtrusion is selected 
                                case "tblDoorFrameExtrusion":

                                    if (Session["doorFrameExtrusion"] != null)
                                    {
                                        Session.Remove("doorFrameExtrusion");
                                    }

                                    //show pnlDoorFrameExtrusions
                                    pnlDoorFrameExtrusions.CssClass = "dimensionsTable";

                                    //create DoorFrameExtrusion object
                                    DoorFrameExtrusion aFrameExtrusion = new DoorFrameExtrusion();

                                    //call select all function to populate object
                                    aFrameExtrusion.Populate(aFrameExtrusion.SelectAll(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString()));

                                    //add DoorFrameExtrusion Object to the session
                                    Session.Add("doorFrameExtrusion", aFrameExtrusion);

                                    //populate fields
                                    imgPart.ImageUrl = "Images/catalogue/" + Session["partNumber"].ToString() + ".jpg";
                                    txtDoorFrExtMaxLength.Text = aFrameExtrusion.DfeMaxLength.ToString();
                                    lblDoorFrExtMaxLengthUnits.Text = aFrameExtrusion.DfeMaxLengthUnits.ToString();

                                    rfvDoorFrExtMaxLength.ValidationGroup = "doorFrameExtrusion";
                                    cmpDoorFrExtMaxLength.ValidationGroup = "doorFrameExtrusion";

                                    lblPartName.Text = aFrameExtrusion.DfeName;
                                    txtPartDesc.Text = aFrameExtrusion.DfeDescription;
                                    lblPartNum.Text = aFrameExtrusion.PartNumber;
                                    lblColorInput.Text = aFrameExtrusion.DfeColor;

                                    txtUsdPrice.Text = aFrameExtrusion.UsdPrice.ToString("N2");
                                    txtCadPrice.Text = aFrameExtrusion.CadPrice.ToString("N2");

                                    if (aFrameExtrusion.DfeStatus)
                                    {
                                        radActive.Checked = true;
                                    }
                                    else
                                    {
                                        radInactive.Checked = true;
                                    }

                                    break;
                                #endregion
                                #region InsulatedFloors
                                //when tblInsulatedFloors is selected
                                case "tblInsulatedFloors":

                                    if (Session["insulatedFloors"] != null)
                                    {
                                        Session.Remove("insulatedFloors");
                                    }

                                    //show pnlInsulatedFloors and pnlComposition
                                    pnlInsulatedFloors.CssClass = "dimensionsTable";
                                    pnlComposition.CssClass = "showPanelNoClass";
                                    lblColor.CssClass = "removeElement";
                                    lblColorInput.CssClass = "removeElement";

                                    //create InsulatedFloors object
                                    InsulatedFloors aFloor = new InsulatedFloors();

                                    //call select all function to populate object
                                    aFloor.Populate(aFloor.SelectAll(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString()));

                                    //add InsulatedFloors Object to the session
                                    Session.Add("insulatedFloors", aFloor);

                                    //populate fields
                                    imgPart.ImageUrl = "Images/catalogue/" + Session["partNumber"].ToString() + ".jpg";
                                    lblPartName.Text = aFloor.InsulatedFloorName;
                                    txtPartDesc.Text = aFloor.InsulatedFloorDescription;
                                    lblPartNum.Text = aFloor.PartNumber;
                                    txtComposition.Text = aFloor.InsulatedFloorComposition;
                                    txtInsFloorSize.Text = aFloor.InsulatedFloorSize.ToString();
                                    lblInsFloorSizeUnits.Text = aFloor.InsulatedFloorSizeUnits;
                                    txtInsFloorPnlMaxWidth.Text = aFloor.InsulatedFloorMaxWidth.ToString();
                                    lblInsFloorPnlMaxWidthUnits.Text = aFloor.InsulatedFloorMaxWidthUnits;

                                    rfvInsFloorSize.ValidationGroup = "insulatedFloors";
                                    cmpInsFloorSize.ValidationGroup = "insulatedFloors";
                                    rfvInsFloorPnlMaxWidth.ValidationGroup = "insulatedFloors";
                                    cmpInsFloorPnlMaxWidth.ValidationGroup = "insulatedFloors";

                                    txtUsdPrice.Text = aFloor.InsulatedFloorUsdPrice.ToString("N2");
                                    txtCadPrice.Text = aFloor.InsulatedFloorCadPrice.ToString("N2");

                                    if (aFloor.InsulatedFloorStatus)
                                    {
                                        radActive.Checked = true;
                                    }
                                    else
                                    {
                                        radInactive.Checked = true;
                                    }
                                    break;
                                #endregion
                                #region RoofPanels
                                //when tblRoofPanels is selected
                                case "tblRoofPanels":

                                    if (Session["roofPanels"] != null)
                                    {
                                        Session.Remove("roofPanels");
                                    }

                                    //show pnlRoofPanels and pnlStandard
                                    pnlStandard.CssClass = "showPanelNoClass";
                                    pnlComposition.CssClass = "showPanelNoClass";
                                    pnlRoofPanels.CssClass = "dimensionsTable";
                                    rowRoofPanelsMaxLength.CssClass = "removeElement";

                                    //create RoofPanels object
                                    RoofPanels aPanel = new RoofPanels();

                                    //call select all function to populate object
                                    aPanel.Populate(aPanel.SelectAll(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString()));

                                    //add RoofPanels Object to the session
                                    Session.Add("roofPanels", aPanel);

                                    //populate fields
                                    imgPart.ImageUrl = "Images/catalogue/" + Session["partNumber"].ToString() + ".jpg";
                                    lblPartName.Text = aPanel.PanelName;
                                    txtPartDesc.Text = aPanel.PanelDescription;
                                    txtStandard.Text = aPanel.PanelStandard;
                                    txtComposition.Text = aPanel.PanelComposition;
                                    lblPartNum.Text = aPanel.PartNumber;
                                    lblColorInput.Text = aPanel.PanelColor;

                                    txtRoofPnlMaxWidth.Text = aPanel.PanelMaxWidth.ToString();
                                    lblRoofPnlMaxWidthUnits.Text = aPanel.MaxWidthUnits;

                                    rfvRoofPnlMaxWidth.ValidationGroup = "roofPanels";
                                    cmpRoofPnlMaxWidth.ValidationGroup = "roofPanels";
                                    rfvRoofPnlSize.ValidationGroup = "roofPanels";
                                    cmpRoofPnlSize.ValidationGroup = "roofPanels";

                                    txtRoofPnlSize.Text = aPanel.PanelSize.ToString();
                                    lblRoofPnlSizeUnits.Text = aPanel.PanelSizeUnits;

                                    if (aPanel.PanelMaxLength != "Site Determined")
                                    {
                                        rowRoofPanelsMaxLengthStr.CssClass = "removeElement";
                                        rowRoofPanelsMaxLength.CssClass = "showElementNoClass";
                                        rfvRoofPnlMaxLength.ValidationGroup = "roofPanels";
                                        cmpRoofPnlMaxLength.ValidationGroup = "roofPanels";
                                    }

                                    txtUsdPrice.Text = aPanel.UsdPrice.ToString("N2");
                                    txtCadPrice.Text = aPanel.CadPrice.ToString("N2");

                                    if (aPanel.Status)
                                    {
                                        radActive.Checked = true;
                                    }
                                    else
                                    {
                                        radInactive.Checked = true;
                                    }
                                    break;
                                #endregion
                                #region ScreenRoll
                                case "tblScreenRoll":
                                    {
                                        if (Session["screenRoll"] != null)
                                        {
                                            Session.Remove("screenRoll");
                                        }
                                        pnlScreenRoll.CssClass = "dimensionsTable";
                                        lblColor.CssClass = "removeElement";
                                        lblColorInput.CssClass = "removeElement";

                                        //create ScreenRoll object
                                        ScreenRoll aScreenRoll = new ScreenRoll();

                                        //call select all function to populate object
                                        aScreenRoll.Populate(aScreenRoll.SelectAll(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString()));

                                        //add RoofPanels Object to the session
                                        Session.Add("screenRoll", aScreenRoll);

                                        //populate fields
                                        imgPart.ImageUrl = "Images/catalogue/" + Session["partNumber"].ToString() + ".jpg";
                                        lblPartName.Text = aScreenRoll.ScreenRollName;
                                        lblPartNum.Text = aScreenRoll.PartNumber;
                                        txtScreenRollWidth.Text = aScreenRoll.ScreenRollWidth.ToString();
                                        lblScreenRollWidthUnits.Text = aScreenRoll.ScreenRollWidthUnits.ToString();
                                        txtScreenRollLength.Text = aScreenRoll.ScreenRollLength.ToString();
                                        lblScreenRollLengthUnits.Text = aScreenRoll.ScreenRollLengthUnits.ToString();

                                        rfvScreenRollWidth.ValidationGroup = "screenRoll";
                                        cmpScreenRollWidth.ValidationGroup = "screenRoll";

                                        rfvScreenRollLength.ValidationGroup = "screenRoll";
                                        cmpScreenRollLength.ValidationGroup = "screenRoll";

                                        txtUsdPrice.Text = aScreenRoll.UsdPrice.ToString("N2");
                                        txtCadPrice.Text = aScreenRoll.CadPrice.ToString("N2");

                                        if (aScreenRoll.Status)
                                        {
                                            radActive.Checked = true;
                                        }
                                        else
                                        {
                                            radInactive.Checked = true;
                                        }

                                        break;
                                    }
                                #endregion
                                #region SuncrylicRoof
                                case "tblSuncrylicRoof":
                                    {
                                        if (Session["suncrylicRoof"] != null)
                                        {
                                            Session.Remove("suncrylicRoof");
                                        }

                                        //show pnlRoofExtrusion
                                        pnlSuncrylicRoof.CssClass = "dimensionsTable";

                                        //create RoofExtrusion object
                                        SuncrylicRoof aSunRoof = new SuncrylicRoof();

                                        //add RoofExtrusion Object to the session
                                        Session.Add("suncrylicRoof", aSunRoof);

                                        //call select all function to populate object
                                        aSunRoof.Populate(aSunRoof.SelectAll(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString()));

                                        //populate fields
                                        imgPart.ImageUrl = "Images/catalogue/" + Session["partNumber"].ToString() + ".jpg";
                                        lblPartName.Text = aSunRoof.SuncrylicName;
                                        txtPartDesc.Text = aSunRoof.SuncrylicDescription;
                                        lblPartNum.Text = aSunRoof.PartNumber;
                                        lblColorInput.Text = aSunRoof.SuncrylicColor;

                                        rowSunRoofMaxWidthStr.CssClass = "removeElement";

                                        if (aSunRoof.SuncrylicMaxLength != 0)
                                        {
                                            rowSunRoofMaxLengthStr.CssClass = "removeElement";
                                            rowSunRoofMaxLength.CssClass = "showElementNoClass";
                                            txtSunRoofMaxLength.Text = aSunRoof.SuncrylicMaxLength.ToString();
                                            lblSunRoofMaxLengthUnits.Text = aSunRoof.SuncrylicLengthUnits;
                                            rfvSunRoofMaxLength.ValidationGroup = "suncrylicRoof";
                                            cmpSunRoofMaxLength.ValidationGroup = "suncrylicRoof";
                                        }

                                        txtUsdPrice.Text = aSunRoof.UsdPrice.ToString("N2");
                                        txtCadPrice.Text = aSunRoof.CadPrice.ToString("N2");

                                        if (aSunRoof.Status)
                                        {
                                            radActive.Checked = true;
                                        }
                                        else
                                        {
                                            radInactive.Checked = true;
                                        }
                                        break;
                                    }
                                #endregion
                                #region VinylRoll
                                case "tblVinylRoll":
                                    {
                                        if (Session["vinylRoll"] != null)
                                        {
                                            Session.Remove("vinylRoll");
                                        }

                                        pnlDescription.CssClass = "removeElement";
                                        //show pnlRoofExtrusion
                                        pnlVinylRoll.CssClass = "dimensionsTable";

                                        //create RoofExtrusion object
                                        VinylRoll aVinylRoll = new VinylRoll();

                                        //add RoofExtrusion Object to the session
                                        Session.Add("vinylRoll", aVinylRoll);

                                        //call select all function to populate object
                                        aVinylRoll.Populate(aVinylRoll.SelectAll(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString()));

                                        //populate fields
                                        imgPart.ImageUrl = "Images/catalogue/" + Session["partNumber"].ToString() + ".jpg";
                                        lblPartName.Text = aVinylRoll.VinylRollName;
                                        lblPartNum.Text = aVinylRoll.PartNumber;
                                        lblColorInput.Text = aVinylRoll.VinylRollColor;

                                        rowVinylRollLength.CssClass = "removeElement";

                                        txtVinylRollWeight.Text = aVinylRoll.VinylRollWeight.ToString();
                                        lblVinylRollWeightUnits.Text = aVinylRoll.VinylRollWeightUnits;
                                        txtVinylRollWidth.Text = aVinylRoll.VinylRollWidth.ToString();
                                        lblVinylRollWidthUnits.Text = aVinylRoll.VinylRollWidthUnits;

                                        rfvVinylRollWidth.ValidationGroup = "vinylRoll";
                                        cmpVinylRollWidth.ValidationGroup = "vinylRoll";
                                        rfvVinylRollWeight.ValidationGroup = "vinylRoll";
                                        cmpVinylRollWeight.ValidationGroup = "vinylRoll";

                                        txtUsdPrice.Text = aVinylRoll.UsdPrice.ToString("N2");
                                        txtCadPrice.Text = aVinylRoll.CadPrice.ToString("N2");

                                        if (aVinylRoll.Status)
                                        {
                                            radActive.Checked = true;
                                        }
                                        else
                                        {
                                            radInactive.Checked = true;
                                        }
                                        break;
                                    }
                                #endregion
                                #region Sunrail300
                                case "tblSunrail300":
                                    {
                                        if (Session["sunrail300"] != null)
                                        {
                                            Session.Remove("sunrail300");
                                        }

                                        //show pnlRoofExtrusion
                                        pnlSunrail300.CssClass = "dimensionsTable";

                                        //create RoofExtrusion object
                                        Sunrail300 aSunrail300 = new Sunrail300();

                                        //add RoofExtrusion Object to the session
                                        Session.Add("sunrail300", aSunrail300);

                                        //call select all function to populate object
                                        aSunrail300.Populate(aSunrail300.SelectAll(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString()));

                                        //populate fields
                                        imgPart.ImageUrl = "Images/catalogue/" + Session["partNumber"].ToString() + ".jpg";
                                        lblPartName.Text = aSunrail300.Sunrail300Name;
                                        txtPartDesc.Text = aSunrail300.Sunrail300Description;
                                        lblPartNum.Text = aSunrail300.PartNumber;
                                        lblColorInput.Text = aSunrail300.Sunrail300Color;

                                        txtSun300MaxLengthFt.Text = aSunrail300.Sunrail300MaxLengthFeet.ToString();
                                        lblSun300MaxLengthFtUnits.Text = aSunrail300.Sunrail300MaxLengthFeetUnits;
                                        txtSun300PnlMaxLengthInch.Text = aSunrail300.Sunrail300MaxLengthInches.ToString();
                                        lblSun300PnlMaxLengthInchUnits.Text = aSunrail300.Sunrail300MaxLengthInchesUnits;

                                        rfvSun300MaxLengthFt.ValidationGroup = "sunrail300";
                                        cmpSun300MaxLengthFt.ValidationGroup = "sunrail300";
                                        cmpSun300PnlMaxLengthInch.ValidationGroup = "sunrail300";

                                        txtUsdPrice.Text = aSunrail300.Sunrail300UsdPrice.ToString("N2");
                                        txtCadPrice.Text = aSunrail300.Sunrail300CadPrice.ToString("N2");

                                        if (aSunrail300.Sunrail300Status)
                                        {
                                            radActive.Checked = true;
                                        }
                                        else
                                        {
                                            radInactive.Checked = true;
                                        }
                                        break;
                                    }
                                #endregion
                                #region Sunrail300Accessories
                                case "tblSunrail300Accessories":
                                    {
                                        if (Session["sunrail300Acc"] != null)
                                        {
                                            Session.Remove("sunrail300Acc");
                                        }

                                        pnlDimensions.CssClass = "removeElement";

                                        //create RoofExtrusion object
                                        Sunrail300Accessories aSunrail300Acc = new Sunrail300Accessories();

                                        //add RoofExtrusion Object to the session
                                        Session.Add("sunrail300Acc", aSunrail300Acc);

                                        //call select all function to populate object
                                        aSunrail300Acc.Populate(aSunrail300Acc.SelectAll(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString()));

                                        //populate fields
                                        imgPart.ImageUrl = "Images/catalogue/" + Session["partNumber"].ToString() + ".jpg";
                                        lblPartName.Text = aSunrail300Acc.Sunrail300AccessoriesName;
                                        txtPartDesc.Text = aSunrail300Acc.Sunrail300AccessoriesDescription;
                                        lblPartNum.Text = aSunrail300Acc.PartNumber;
                                        lblColorInput.Text = aSunrail300Acc.Sunrail300AccessoriesColor;

                                        txtUsdPrice.Text = aSunrail300Acc.Sunrail300AccessoriesUsdPrice.ToString("N2");
                                        txtCadPrice.Text = aSunrail300Acc.Sunrail300AccessoriesCadPrice.ToString("N2");

                                        if (aSunrail300Acc.Sunrail300AccessoriesStatus)
                                        {
                                            radActive.Checked = true;
                                        }
                                        else
                                        {
                                            radInactive.Checked = true;
                                        }
                                        break;
                                    }
                                #endregion
                                #region Sunrail400
                                case "tblSunrail400":
                                    {
                                        if (Session["sunrail400"] != null)
                                        {
                                            Session.Remove("sunrail400");
                                        }

                                        //show pnlRoofExtrusion
                                        pnlSunrail400.CssClass = "dimensionsTable";

                                        //create RoofExtrusion object
                                        Sunrail400 aSunrail400 = new Sunrail400();

                                        //add RoofExtrusion Object to the session
                                        Session.Add("sunrail400", aSunrail400);

                                        //call select all function to populate object
                                        aSunrail400.Populate(aSunrail400.SelectAll(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString()));

                                        //populate fields
                                        imgPart.ImageUrl = "Images/catalogue/" + Session["partNumber"].ToString() + ".jpg";
                                        lblPartName.Text = aSunrail400.Sunrail400Name;
                                        txtPartDesc.Text = aSunrail400.Sunrail400Description;
                                        lblPartNum.Text = aSunrail400.PartNumber;
                                        lblColorInput.Text = aSunrail400.Sunrail400Color;

                                        txtSun400MaxLengthFt.Text = aSunrail400.Sunrail400MaxLengthFeet.ToString();
                                        lblSun400MaxLengthFtUnits.Text = aSunrail400.Sunrail400MaxLengthFeetUnits;
                                        txtSun400PnlMaxLengthInch.Text = aSunrail400.Sunrail400MaxLengthInches.ToString();
                                        lblSun400PnlMaxLengthInchUnits.Text = aSunrail400.Sunrail400MaxLengthInchesUnits;

                                        rfvSun400MaxLengthFt.ValidationGroup = "sunrail400";
                                        cmpSun400MaxLengthFt.ValidationGroup = "sunrail400";
                                        cmpSun400PnlMaxLengthInch.ValidationGroup = "sunrail400";

                                        txtUsdPrice.Text = aSunrail400.Sunrail400UsdPrice.ToString("N2");
                                        txtCadPrice.Text = aSunrail400.Sunrail400CadPrice.ToString("N2");

                                        if (aSunrail400.Sunrail400Status)
                                        {
                                            radActive.Checked = true;
                                        }
                                        else
                                        {
                                            radInactive.Checked = true;
                                        }
                                        break;
                                    }
                                #endregion
                                #region Sunrail1000
                                case "tblSunrail1000":
                                    {
                                        if (Session["sunrail1000"] != null)
                                        {
                                            Session.Remove("sunrail1000");
                                        }

                                        //show pnlRoofExtrusion
                                        pnlSunrail1000.CssClass = "dimensionsTable";

                                        //create RoofExtrusion object
                                        Sunrail1000 aSunrail1000 = new Sunrail1000();

                                        //add RoofExtrusion Object to the session
                                        Session.Add("sunrail1000", aSunrail1000);

                                        //call select all function to populate object
                                        aSunrail1000.Populate(aSunrail1000.SelectAll(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString()));

                                        //populate fields
                                        imgPart.ImageUrl = "Images/catalogue/" + Session["partNumber"].ToString() + ".jpg";
                                        lblPartName.Text = aSunrail1000.Sunrail1000Name;
                                        txtPartDesc.Text = aSunrail1000.Sunrail1000Description;
                                        lblPartNum.Text = aSunrail1000.PartNumber;
                                        lblColorInput.Text = aSunrail1000.Sunrail1000Color;

                                        txtSun1000MaxLengthFt.Text = aSunrail1000.Sunrail1000MaxLengthFeet.ToString();
                                        lblSun1000MaxLengthFtUnits.Text = aSunrail1000.Sunrail1000MaxLengthFeetUnits;
                                        txtSun1000PnlMaxLengthInch.Text = aSunrail1000.Sunrail1000MaxLengthInches.ToString();
                                        lblSun1000PnlMaxLengthInchUnits.Text = aSunrail1000.Sunrail1000MaxLengthInchesUnits;

                                        rfvSun1000MaxLengthFt.ValidationGroup = "sunrail1000";
                                        cmpSun1000MaxLengthFt.ValidationGroup = "sunrail1000";
                                        cmpSun1000PnlMaxLengthInch.ValidationGroup = "sunrail1000";

                                        txtUsdPrice.Text = aSunrail1000.Sunrail1000UsdPrice.ToString("N2");
                                        txtCadPrice.Text = aSunrail1000.Sunrail1000CadPrice.ToString("N2");

                                        if (aSunrail1000.Sunrail1000Status)
                                        {
                                            radActive.Checked = true;
                                        }
                                        else
                                        {
                                            radInactive.Checked = true;
                                        }
                                        break;
                                    }
                                #endregion
                                #region WallExtrusions
                                case "tblWallExtrusions":
                                    {
                                        if (Session["wallExtrusions"] != null)
                                        {
                                            Session.Remove("wallExtrusions");
                                        }

                                        //show pnlRoofExtrusion
                                        pnlWallExtrusions.CssClass = "dimensionsTable";

                                        //create RoofExtrusion object
                                        WallExtrusions aWallExtrusion = new WallExtrusions();

                                        //add RoofExtrusion Object to the session
                                        Session.Add("wallExtrusions", aWallExtrusion);

                                        //call select all function to populate object
                                        aWallExtrusion.Populate(aWallExtrusion.SelectAll(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString()));

                                        //populate fields
                                        imgPart.ImageUrl = "Images/catalogue/" + Session["partNumber"].ToString() + ".jpg";
                                        lblPartName.Text = aWallExtrusion.WallExtrusionName;
                                        txtPartDesc.Text = aWallExtrusion.WallExtrusionDescription;
                                        lblPartNum.Text = aWallExtrusion.PartNumber;
                                        lblColorInput.Text = aWallExtrusion.WallExtrusionColor;

                                        txtWallExtMaxLength.Text = aWallExtrusion.WallExtrusionMaxLength.ToString();
                                        lblWallExtMaxLengthUnits.Text = aWallExtrusion.LengthUnits;

                                        rfvWallExtMaxLength.ValidationGroup = "wallExtrusions";
                                        cmpWallExtMaxLength.ValidationGroup = "wallExtrusions";

                                        txtUsdPrice.Text = aWallExtrusion.UsdPrice.ToString("N2");
                                        txtCadPrice.Text = aWallExtrusion.CadPrice.ToString("N2");

                                        if (aWallExtrusion.Status)
                                        {
                                            radActive.Checked = true;
                                        }
                                        else
                                        {
                                            radInactive.Checked = true;
                                        }
                                        break;
                                    }
                                #endregion
                                #region WallPanels
                                case "tblWallPanels":
                                    {
                                        if (Session["wallPanels"] != null)
                                        {
                                            Session.Remove("wallPanels");
                                        }

                                        //show pnlRoofExtrusion
                                        pnlWallExtrusions.CssClass = "dimensionsTable";
                                        pnlComposition.CssClass = "showPanelNoClass";
                                        pnlStandard.CssClass = "showPanelNoClass";

                                        //create RoofExtrusion object
                                        WallPanels aWallPanel = new WallPanels();

                                        //add RoofExtrusion Object to the session
                                        Session.Add("wallPanels", aWallPanel);

                                        //call select all function to populate object
                                        aWallPanel.Populate(aWallPanel.SelectAll(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString()));

                                        //populate fields
                                        imgPart.ImageUrl = "Images/catalogue/" + Session["partNumber"].ToString() + ".jpg";
                                        lblPartName.Text = aWallPanel.WallPanelName;
                                        txtPartDesc.Text = aWallPanel.WallPanelDescription;
                                        txtStandard.Text = aWallPanel.WallPanelStandard;
                                        txtComposition.Text = aWallPanel.WallPanelComposition;
                                        lblPartNum.Text = aWallPanel.WallPanelNumber;
                                        lblColorInput.Text = aWallPanel.WallPanelColor;

                                        txtWallPnlSize.Text = aWallPanel.WallPanelSize.ToString();
                                        lblWallPnlSizeUnits.Text = aWallPanel.SizeUnits;

                                        txtWallPnlMaxLength.Text = aWallPanel.WallPanelMaxLength.ToString();
                                        lblWallPnlMaxLengthUnits.Text = aWallPanel.LengthUnits;

                                        txtWallPnlMaxWidth.Text = aWallPanel.WallPanelMaxWidth.ToString();
                                        lblWallPnlMaxWidthUnits.Text = aWallPanel.WidthUnits;

                                        txtUsdPrice.Text = aWallPanel.UsdPrice.ToString("N2");
                                        txtCadPrice.Text = aWallPanel.CadPrice.ToString("N2");

                                        if (aWallPanel.Status)
                                        {
                                            radActive.Checked = true;
                                        }
                                        else
                                        {
                                            radInactive.Checked = true;
                                        }
                                        break;
                                    }
                                #endregion
                                #region Schematics
                                case "tblSchematics":
                                    {
                                        if (Session["schematic"] != null)
                                        {
                                            Session.Remove("schematic");
                                        }

                                        if (Session["part"] != null)
                                        {
                                            Session.Remove("part");
                                        }

                                        rowPart1.CssClass = "removeElement";
                                        rowPart1Val.CssClass = "removeElement";
                                        rowPart2.CssClass = "removeElement";
                                        rowPart2Val.CssClass = "removeElement";
                                        rowPart3.CssClass = "removeElement";
                                        rowPart3Val.CssClass = "removeElement";
                                        rowPart4.CssClass = "removeElement";
                                        rowPart4Val.CssClass = "removeElement";
                                        rowPart5.CssClass = "removeElement";
                                        rowPart5Val.CssClass = "removeElement";
                                        rowPart6.CssClass = "removeElement";
                                        rowPart6Val.CssClass = "removeElement";
                                        rowPart7.CssClass = "removeElement";
                                        rowPart7Val.CssClass = "removeElement";
                                        rowPart8.CssClass = "removeElement";
                                        rowPart8Val.CssClass = "removeElement";
                                        rowPart9.CssClass = "removeElement";
                                        rowPart9Val.CssClass = "removeElement";
                                        rowPart10.CssClass = "removeElement";
                                        rowPart10Val.CssClass = "removeElement";
                                        rowPart11.CssClass = "removeElement";
                                        rowPart11Val.CssClass = "removeElement";
                                        rowPart12.CssClass = "removeElement";
                                        rowPart12Val.CssClass = "removeElement";
                                        rowPart13.CssClass = "removeElement";
                                        rowPart13Val.CssClass = "removeElement";
                                        rowPart14.CssClass = "removeElement";
                                        rowPart14Val.CssClass = "removeElement";
                                        rowPart15.CssClass = "removeElement";
                                        rowPart15Val.CssClass = "removeElement";
                                        rowPart16.CssClass = "removeElement";
                                        rowPart16Val.CssClass = "removeElement";
                                        rowPart17.CssClass = "removeElement";
                                        rowPart17Val.CssClass = "removeElement";
                                        rowPart18.CssClass = "removeElement";
                                        rowPart18Val.CssClass = "removeElement";
                                        rowPart19.CssClass = "removeElement";
                                        rowPart19Val.CssClass = "removeElement";
                                        rowPart20.CssClass = "removeElement";
                                        rowPart20Val.CssClass = "removeElement";
                                        rowPart21.CssClass = "removeElement";
                                        rowPart21Val.CssClass = "removeElement";
                                        rowPart22.CssClass = "removeElement";
                                        rowPart22Val.CssClass = "removeElement";
                                        rowPart23.CssClass = "removeElement";
                                        rowPart23Val.CssClass = "removeElement";

                                        lblSchemPartNum.CssClass = "removeElement";
                                        lblSchemPartKey.CssClass = "removeElement";
                                        lblSchemPartKeyNum.CssClass = "removeElement";
                                        lblSchemPartName.CssClass = "removeElement";

                                        lblColor.CssClass = "removeElement";
                                        lblColorInput.CssClass = "removeElement";
                                        pnlDimensions.CssClass = "removeElement";
                                        pnlPricing.CssClass = "removeElement";

                                        //show pnlSchematics and pricingSchemTable
                                        pnlSchematics.CssClass = "showElementNoClass";
                                        pnlPricingSchematics.CssClass = "pnlPricing";

                                        imgPart.ImageUrl = "Images/catalogue/" + Session["partNumber"].ToString() + ".jpg";

                                        //create Schematics object
                                        Schematics aSchematic = new Schematics();

                                        //call select all function to populate object
                                        aSchematic.Populate(aSchematic.SelectAll(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString()));

                                        //add RoofPanels Object to the session
                                        Session.Add("schematic", aSchematic);

                                        //populate fields

                                        //set up a dataview object for object member data
                                        System.Data.DataView aPartsTable = new System.Data.DataView();

                                        //select row based on table name and part number
                                        datUpdateDataSource.SelectCommand = "SELECT partNumber FROM tblSchematicParts WHERE schematicNumber='" + Session["partNumber"] + "' ORDER BY keyNumber ASC";

                                        //assign the row to the dataview object
                                        aPartsTable = (System.Data.DataView)datUpdateDataSource.Select(System.Web.UI.DataSourceSelectArguments.Empty);

                                        ddlSchem.Items.Clear();
                                        ddlSchem.Items.Add("");

                                        for (int i = 0; i < aPartsTable.Count; i++)
                                        {
                                            ddlSchem.Items.Add(aPartsTable[i][0].ToString());
                                        }

                                        lblPartName.Text = aSchematic.SchematicName.ToString();
                                        txtPartDesc.Text = aSchematic.SchematicDescription.ToString();
                                        lblPartNum.Text = aSchematic.SchematicNumber.ToString();

                                        txtUsdPriceSchematic.Text = aSchematic.SchematicUsdPrice.ToString("N2");
                                        txtCadPriceSchematic.Text = aSchematic.SchematicCadPrice.ToString("N2");
                                        rfvSchemWholeUsd.ValidationGroup = "pricing";
                                        cmpSchemWholeUsd.ValidationGroup = "pricing";
                                        rfvSchemWholeCad.ValidationGroup = "pricing";
                                        cmpSchemWholeCad.ValidationGroup = "pricing";

                                        if (aSchematic.SchematicStatus)
                                        {
                                            radActive.Checked = true;
                                        }
                                        else
                                        {
                                            radInactive.Checked = true;
                                        }
                                        break;
                                #endregion
                                    }

                            }
                        #endregion
                        }
                    }
                }
            }
            /*
            if (Session["backToUpdate"] != null)
            {
                imgPart.ImageUrl = "Images/catalogue/temp.jpg";
                System.IO.File.Delete(Server.MapPath("Images/catalogue/temp.jpg"));
                Session.Remove("backToUpdate");
            }
             * */
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                //get selected table from the session
                string tableName = Session["tableName"].ToString();

                if (Session["pricingOnly"] != null)
                {
                    Page.Validate("pricing");
                    
                    if(Page.IsValid)
                    {
                        switch (tableName)
                        {
                            #region Roof Extrusions
                            //when roof extrusion is selected
                            case "tblRoofExtrusions":
                                {
                                    //create new object
                                    RoofExtrusion aRoofExtrusion = (RoofExtrusion)Session["roofExtrusion"];

                                    if (aRoofExtrusion.CadPrice != Convert.ToDecimal(txtCadPrice.Text))
                                    {
                                        aRoofExtrusion.CadPrice = Convert.ToDecimal(txtCadPrice.Text);
                                    }

                                    if (aRoofExtrusion.UsdPrice != Convert.ToDecimal(txtUsdPrice.Text))
                                    {
                                        aRoofExtrusion.UsdPrice = Convert.ToDecimal(txtUsdPrice.Text);
                                    }

                                    //call update function
                                    aRoofExtrusion.Update(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString());

                                    //set session variable
                                    Session.Add("updatedObject", aRoofExtrusion);

                                    break;
                                }
                            #endregion
                            #region Accessories
                            case "tblAccessories":
                                {
                                    //create new object
                                    Accessories anAccessory = (Accessories)Session["accessories"];

                                    if (anAccessory.AccessoryCadPrice != Convert.ToDecimal(txtCadPrice.Text))
                                    {
                                        anAccessory.AccessoryCadPrice = Convert.ToDecimal(txtCadPrice.Text);
                                    }

                                    if (anAccessory.AccessoryUsdPrice != Convert.ToDecimal(txtUsdPrice.Text))
                                    {
                                        anAccessory.AccessoryUsdPrice = Convert.ToDecimal(txtUsdPrice.Text);
                                    }

                                    //call update function
                                    anAccessory.Update(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString());

                                    //set session variable
                                    Session.Add("updatedObject", anAccessory);

                                    break;
                                }
                            #endregion

                            #region Decorative Column
                            case "tblDecorativeColumn":
                                {

                                    //create new object
                                    DecorativeColumn aColumn = (DecorativeColumn)Session["decorativeColumn"];

                                    if (aColumn.ColumnCadPrice != Convert.ToDecimal(txtCadPrice.Text))
                                    {
                                        aColumn.ColumnCadPrice = Convert.ToDecimal(txtCadPrice.Text);
                                    }

                                    if (aColumn.ColumnUsdPrice != Convert.ToDecimal(txtUsdPrice.Text))
                                    {
                                        aColumn.ColumnUsdPrice = Convert.ToDecimal(txtUsdPrice.Text);
                                    }

                                    //call update function
                                    aColumn.Update(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString());

                                    //set session variable
                                    Session.Add("updatedObject", aColumn);

                                    break;
                                }
                            #endregion

                            #region Door Frame Extrusion
                            case "tblDoorFrameExtrusion":
                                {
                                    //create new object
                                    DoorFrameExtrusion aDoorExtrusion = (DoorFrameExtrusion)Session["doorFrameExtrusion"];

                                    if (aDoorExtrusion.CadPrice != Convert.ToDecimal(txtCadPrice.Text))
                                    {
                                        aDoorExtrusion.CadPrice = Convert.ToDecimal(txtCadPrice.Text);
                                    }

                                    if (aDoorExtrusion.UsdPrice != Convert.ToDecimal(txtUsdPrice.Text))
                                    {
                                        aDoorExtrusion.UsdPrice = Convert.ToDecimal(txtUsdPrice.Text);
                                    }

                                    //call update function
                                    aDoorExtrusion.Update(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString());

                                    //set session variable
                                    Session.Add("updatedObject", aDoorExtrusion);
                                    break;
                                }
                            #endregion

                            #region Insulated Floors
                            case "tblInsulatedFloors":
                                {
                                    //create new object
                                    InsulatedFloors anInsulatedFloor = (InsulatedFloors)Session["insulatedFloors"];

                                    if (anInsulatedFloor.InsulatedFloorCadPrice != Convert.ToDecimal(txtCadPrice.Text))
                                    {
                                        anInsulatedFloor.InsulatedFloorCadPrice = Convert.ToDecimal(txtCadPrice.Text);
                                    }

                                    if (anInsulatedFloor.InsulatedFloorUsdPrice != Convert.ToDecimal(txtUsdPrice.Text))
                                    {
                                        anInsulatedFloor.InsulatedFloorUsdPrice = Convert.ToDecimal(txtUsdPrice.Text);
                                    }

                                    //call update function
                                    anInsulatedFloor.Update(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString());

                                    //set session variable
                                    Session.Add("updatedObject", anInsulatedFloor);
                                    break;
                                }
                            #endregion

                            #region Roof Panels
                            case "tblRoofPanels":
                                {
                                    //create new object
                                    RoofPanels aRoofPanel = (RoofPanels)Session["roofPanels"];

                                    if (aRoofPanel.CadPrice != Convert.ToDecimal(txtCadPrice.Text))
                                    {
                                        aRoofPanel.CadPrice = Convert.ToDecimal(txtCadPrice.Text);
                                    }

                                    if (aRoofPanel.UsdPrice != Convert.ToDecimal(txtUsdPrice.Text))
                                    {
                                        aRoofPanel.UsdPrice = Convert.ToDecimal(txtUsdPrice.Text);
                                    }

                                    //call update function
                                    aRoofPanel.Update(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString());

                                    //set session variable
                                    Session.Add("updatedObject", aRoofPanel);
                                    break;
                                }
                            #endregion

                            #region Screen Roll
                            case "tblScreenRoll":
                                {
                                    //create new object
                                    ScreenRoll aScreenRoll = (ScreenRoll)Session["screenRoll"];

                                    if (aScreenRoll.CadPrice != Convert.ToDecimal(txtCadPrice.Text))
                                    {
                                        aScreenRoll.CadPrice = Convert.ToDecimal(txtCadPrice.Text);
                                    }

                                    if (aScreenRoll.UsdPrice != Convert.ToDecimal(txtUsdPrice.Text))
                                    {
                                        aScreenRoll.UsdPrice = Convert.ToDecimal(txtUsdPrice.Text);
                                    }

                                    //call update function
                                    aScreenRoll.Update(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString());

                                    //set session variable
                                    Session.Add("updatedObject", aScreenRoll);
                                    break;
                                }
                            #endregion

                            #region VinylRoll
                            case "tblVinylRoll":
                                {
                                    //create new object
                                    VinylRoll aVinylRoll = (VinylRoll)Session["vinylRoll"];

                                    if (aVinylRoll.CadPrice != Convert.ToDecimal(txtCadPrice.Text))
                                    {
                                        aVinylRoll.CadPrice = Convert.ToDecimal(txtCadPrice.Text);
                                    }

                                    if (aVinylRoll.UsdPrice != Convert.ToDecimal(txtUsdPrice.Text))
                                    {
                                        aVinylRoll.UsdPrice = Convert.ToDecimal(txtUsdPrice.Text);
                                    }

                                    //call update function
                                    aVinylRoll.Update(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString());

                                    //set session variable
                                    Session.Add("updatedObject", aVinylRoll);
                                    break;
                                }
                            #endregion

                            #region Sunrail300
                            case "tblSunrail300":
                                {
                                    //create new object
                                    Sunrail300 aSunrail300 = (Sunrail300)Session["sunrail300"];

                                    if (aSunrail300.Sunrail300CadPrice != Convert.ToDecimal(txtCadPrice.Text))
                                    {
                                        aSunrail300.Sunrail300CadPrice = Convert.ToDecimal(txtCadPrice.Text);
                                    }

                                    if (aSunrail300.Sunrail300UsdPrice != Convert.ToDecimal(txtUsdPrice.Text))
                                    {
                                        aSunrail300.Sunrail300UsdPrice = Convert.ToDecimal(txtUsdPrice.Text);
                                    }

                                    //call update function
                                    aSunrail300.Update(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString());

                                    //set session variable
                                    Session.Add("updatedObject", aSunrail300);
                                    break;
                                }
                            #endregion
                            #region Sunrail300Accessories
                            case "tblSunrail300Accessories":
                                {
                                    //create new object
                                    Sunrail300Accessories aSunrail300Accessory = (Sunrail300Accessories)Session["sunrail300Accessories"];

                                    if (aSunrail300Accessory.Sunrail300AccessoriesCadPrice != Convert.ToDecimal(txtCadPrice.Text))
                                    {
                                        aSunrail300Accessory.Sunrail300AccessoriesCadPrice = Convert.ToDecimal(txtCadPrice.Text);
                                    }

                                    if (aSunrail300Accessory.Sunrail300AccessoriesUsdPrice != Convert.ToDecimal(txtUsdPrice.Text))
                                    {
                                        aSunrail300Accessory.Sunrail300AccessoriesUsdPrice = Convert.ToDecimal(txtUsdPrice.Text);
                                    }

                                    //call update function
                                    aSunrail300Accessory.Update(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString());

                                    //set session variable
                                    Session.Add("updatedObject", aSunrail300Accessory);
                                    break;
                                }
                            #endregion
                            #region Sunrail400
                            case "tblSunrail400":
                                {
                                    //create new object
                                    Sunrail400 aSunrail400 = (Sunrail400)Session["sunrail400"];

                                    if (aSunrail400.Sunrail400CadPrice != Convert.ToDecimal(txtCadPrice.Text))
                                    {
                                        aSunrail400.Sunrail400CadPrice = Convert.ToDecimal(txtCadPrice.Text);
                                    }

                                    if (aSunrail400.Sunrail400UsdPrice != Convert.ToDecimal(txtUsdPrice.Text))
                                    {
                                        aSunrail400.Sunrail400UsdPrice = Convert.ToDecimal(txtUsdPrice.Text);
                                    }

                                    //call update function
                                    aSunrail400.Update(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString());

                                    //set session variable
                                    Session.Add("updatedObject", aSunrail400);
                                    break;
                                }
                            #endregion
                            #region  Sunrail1000
                            case "tblSunrail1000":
                                {
                                    //create new object
                                    Sunrail1000 aSunrail1000 = (Sunrail1000)Session["sunrail1000"];

                                    if (aSunrail1000.Sunrail1000CadPrice != Convert.ToDecimal(txtCadPrice.Text))
                                    {
                                        aSunrail1000.Sunrail1000CadPrice = Convert.ToDecimal(txtCadPrice.Text);
                                    }

                                    if (aSunrail1000.Sunrail1000UsdPrice != Convert.ToDecimal(txtUsdPrice.Text))
                                    {
                                        aSunrail1000.Sunrail1000UsdPrice = Convert.ToDecimal(txtUsdPrice.Text);
                                    }

                                    //call update function
                                    aSunrail1000.Update(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString());

                                    //set session variable
                                    Session.Add("updatedObject", aSunrail1000);
                                    break;
                                }
                            #endregion
                            #region Wall Panels
                            case "tblWallPanels":
                                {
                                    //create new object
                                    WallPanels aWallPanel = (WallPanels)Session["wallPanels"];

                                    if (aWallPanel.CadPrice != Convert.ToDecimal(txtCadPrice.Text))
                                    {
                                        aWallPanel.CadPrice = Convert.ToDecimal(txtCadPrice.Text);
                                    }

                                    if (aWallPanel.UsdPrice != Convert.ToDecimal(txtUsdPrice.Text))
                                    {
                                        aWallPanel.UsdPrice = Convert.ToDecimal(txtUsdPrice.Text);
                                    }

                                    //call update function
                                    aWallPanel.Update(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString());

                                    //set session variable
                                    Session.Add("updatedObject", aWallPanel);
                                    break;
                                }
                            #endregion
                            #region Suncrylic Roof
                            case "tblSuncrylicRoof":
                                {
                                    //create new object
                                    SuncrylicRoof aSunRoof = (SuncrylicRoof)Session["suncrylicRoof"];

                                    if (aSunRoof.CadPrice != Convert.ToDecimal(txtCadPrice.Text))
                                    {
                                        aSunRoof.CadPrice = Convert.ToDecimal(txtCadPrice.Text);
                                    }

                                    if (aSunRoof.UsdPrice != Convert.ToDecimal(txtUsdPrice.Text))
                                    {
                                        aSunRoof.UsdPrice = Convert.ToDecimal(txtUsdPrice.Text);
                                    }

                                    //call update function
                                    aSunRoof.Update(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString());

                                    //set session variable
                                    Session.Add("updatedObject", aSunRoof);
                                    break;
                                }
                            #endregion
                            #region Wall Extrusions
                            case "tblWallExtrusions":
                                {
                                    //create new object
                                    WallExtrusions aWallExtrusion = (WallExtrusions)Session["wallExtrusions"];

                                    if (aWallExtrusion.CadPrice != Convert.ToDecimal(txtCadPrice.Text))
                                    {
                                        aWallExtrusion.CadPrice = Convert.ToDecimal(txtCadPrice.Text);
                                    }

                                    if (aWallExtrusion.UsdPrice != Convert.ToDecimal(txtUsdPrice.Text))
                                    {
                                        aWallExtrusion.UsdPrice = Convert.ToDecimal(txtUsdPrice.Text);
                                    }

                                    //call update function
                                    aWallExtrusion.Update(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString());

                                    //set session variable
                                    Session.Add("updatedObject", aWallExtrusion);
                                    break;
                                }
                            #endregion
                            #region Schematics
                            case "tblSchematics":
                                {
                                    if (ddlSchem.SelectedValue != "")
                                    {
                                        Schematics aSchematic = (Schematics)Session["schematic"];
                                        Part aPart = new Part();

                                        if (Session["part"] != null)
                                        {
                                            aPart = (Part)Session["part"];
                                        }
                                        else
                                        {
                                            aPart.Populate(aPart.SelectAll(datUpdateDataSource, ddlSchem.SelectedValue, Session["partNumber"].ToString()));
                                            Session.Add("part", aPart);
                                        }

                                        //set member variables based on any changes made
                                        if (aSchematic.SchematicCadPrice != Convert.ToDecimal(txtCadPriceSchematic.Text))
                                        {
                                            aSchematic.SchematicCadPrice = Convert.ToDecimal(txtCadPriceSchematic.Text);
                                        }

                                        if (aSchematic.SchematicUsdPrice != Convert.ToDecimal(txtUsdPriceSchematic.Text))
                                        {
                                            aSchematic.SchematicUsdPrice = Convert.ToDecimal(txtUsdPriceSchematic.Text);
                                        }
                                        #region PartKeys
                                        if (aPart.PartKeyNumber == 1)
                                        {
                                            if (aPart.PartUsdPrice != Convert.ToDecimal(txtUsdPricePartOne.Text))
                                            {
                                                aPart.PartUsdPrice = Convert.ToDecimal(txtUsdPricePartOne.Text);
                                            }

                                            if (aPart.PartCadPrice != Convert.ToDecimal(txtCadPricePartOne.Text))
                                            {
                                                aPart.PartCadPrice = Convert.ToDecimal(txtCadPricePartOne.Text);
                                            }
                                        }

                                        else if (aPart.PartKeyNumber == 2)
                                        {
                                            if (aPart.PartUsdPrice != Convert.ToDecimal(txtUsdPricePartTwo.Text))
                                            {
                                                aPart.PartUsdPrice = Convert.ToDecimal(txtUsdPricePartTwo.Text);
                                            }

                                            if (aPart.PartCadPrice != Convert.ToDecimal(txtCadPricePartTwo.Text))
                                            {
                                                aPart.PartCadPrice = Convert.ToDecimal(txtCadPricePartTwo.Text);
                                            }
                                        }

                                        else if (aPart.PartKeyNumber == 3)
                                        {
                                            if (aPart.PartUsdPrice != Convert.ToDecimal(txtUsdPricePartThree.Text))
                                            {
                                                aPart.PartUsdPrice = Convert.ToDecimal(txtUsdPricePartThree.Text);
                                            }
                                            if (aPart.PartCadPrice != Convert.ToDecimal(txtCadPricePartThree.Text))
                                            {
                                                aPart.PartCadPrice = Convert.ToDecimal(txtCadPricePartThree.Text);
                                            }
                                        }

                                        else if (aPart.PartKeyNumber == 4)
                                        {
                                            if (aPart.PartUsdPrice != Convert.ToDecimal(txtUsdPricePartFour.Text))
                                            {
                                                aPart.PartUsdPrice = Convert.ToDecimal(txtUsdPricePartFour.Text);
                                            }
                                            if (aPart.PartCadPrice != Convert.ToDecimal(txtCadPricePartFour.Text))
                                            {
                                                aPart.PartCadPrice = Convert.ToDecimal(txtCadPricePartFour.Text);
                                            }
                                        }

                                        else if (aPart.PartKeyNumber == 5)
                                        {
                                            if (aPart.PartUsdPrice != Convert.ToDecimal(txtUsdPricePartFive.Text))
                                            {
                                                aPart.PartUsdPrice = Convert.ToDecimal(txtUsdPricePartFive.Text);
                                            }
                                            if (aPart.PartCadPrice != Convert.ToDecimal(txtCadPricePartFive.Text))
                                            {
                                                aPart.PartCadPrice = Convert.ToDecimal(txtCadPricePartFive.Text);
                                            }
                                        }

                                        else if (aPart.PartKeyNumber == 6)
                                        {
                                            if (aPart.PartUsdPrice != Convert.ToDecimal(txtUsdPricePartSix.Text))
                                            {
                                                aPart.PartUsdPrice = Convert.ToDecimal(txtUsdPricePartSix.Text);
                                            }
                                            if (aPart.PartCadPrice != Convert.ToDecimal(txtCadPricePartSix.Text))
                                            {
                                                aPart.PartCadPrice = Convert.ToDecimal(txtCadPricePartSix.Text);
                                            }
                                        }

                                        else if (aPart.PartKeyNumber == 7)
                                        {
                                            if (aPart.PartUsdPrice != Convert.ToDecimal(txtUsdPricePartSeven.Text))
                                            {
                                                aPart.PartUsdPrice = Convert.ToDecimal(txtUsdPricePartSeven.Text);
                                            }
                                            if (aPart.PartCadPrice != Convert.ToDecimal(txtCadPricePartSeven.Text))
                                            {
                                                aPart.PartCadPrice = Convert.ToDecimal(txtCadPricePartSeven.Text);
                                            }
                                        }

                                        else if (aPart.PartKeyNumber == 8)
                                        {
                                            if (aPart.PartUsdPrice != Convert.ToDecimal(txtUsdPricePartEight.Text))
                                            {
                                                aPart.PartUsdPrice = Convert.ToDecimal(txtUsdPricePartEight.Text);
                                            }
                                            if (aPart.PartCadPrice != Convert.ToDecimal(txtCadPricePartEight.Text))
                                            {
                                                aPart.PartCadPrice = Convert.ToDecimal(txtCadPricePartEight.Text);
                                            }
                                        }

                                        else if (aPart.PartKeyNumber == 9)
                                        {
                                            if (aPart.PartUsdPrice != Convert.ToDecimal(txtUsdPricePartNine.Text))
                                            {
                                                aPart.PartUsdPrice = Convert.ToDecimal(txtUsdPricePartNine.Text);
                                            }
                                            if (aPart.PartCadPrice != Convert.ToDecimal(txtCadPricePartNine.Text))
                                            {
                                                aPart.PartCadPrice = Convert.ToDecimal(txtCadPricePartNine.Text);
                                            }
                                        }

                                        else if (aPart.PartKeyNumber == 10)
                                        {
                                            if (aPart.PartUsdPrice != Convert.ToDecimal(txtUsdPricePartTen.Text))
                                            {
                                                aPart.PartUsdPrice = Convert.ToDecimal(txtUsdPricePartTen.Text);
                                            }
                                            if (aPart.PartCadPrice != Convert.ToDecimal(txtCadPricePartTen.Text))
                                            {
                                                aPart.PartCadPrice = Convert.ToDecimal(txtCadPricePartTen.Text);
                                            }
                                        }
                                        #region PartKey11
                                        else if (aPart.PartKeyNumber == 11)
                                        {
                                            if (aPart.PartUsdPrice != Convert.ToDecimal(txtUsdPricePartEleven.Text))
                                            {
                                                aPart.PartUsdPrice = Convert.ToDecimal(txtUsdPricePartEleven.Text);
                                            }
                                            if (aPart.PartCadPrice != Convert.ToDecimal(txtCadPricePartEleven.Text))
                                            {
                                                aPart.PartCadPrice = Convert.ToDecimal(txtCadPricePartEleven.Text);
                                            }
                                        }
#endregion
                                        #region PartKey12
                                        else if (aPart.PartKeyNumber == 12)
                                        {
                                            if (aPart.PartUsdPrice != Convert.ToDecimal(txtUsdPricePartTwelve.Text))
                                            {
                                                aPart.PartUsdPrice = Convert.ToDecimal(txtUsdPricePartTwelve.Text);
                                            }
                                            if (aPart.PartCadPrice != Convert.ToDecimal(txtCadPricePartTwelve.Text))
                                            {
                                                aPart.PartCadPrice = Convert.ToDecimal(txtCadPricePartTwelve.Text);
                                            }
                                        }
                                        #endregion
                                        #region PartKey13
                                        else if (aPart.PartKeyNumber == 13)
                                        {
                                            if (aPart.PartUsdPrice != Convert.ToDecimal(txtUsdPricePartThirteen.Text))
                                            {
                                                aPart.PartUsdPrice = Convert.ToDecimal(txtUsdPricePartThirteen.Text);
                                            }
                                            if (aPart.PartCadPrice != Convert.ToDecimal(txtCadPricePartThirteen.Text))
                                            {
                                                aPart.PartCadPrice = Convert.ToDecimal(txtCadPricePartThirteen.Text);
                                            }
                                        }
                                        #endregion
                                        #region PartKey14
                                        else if (aPart.PartKeyNumber == 14)
                                        {
                                            if (aPart.PartUsdPrice != Convert.ToDecimal(txtUsdPricePartFourteen.Text))
                                            {
                                                aPart.PartUsdPrice = Convert.ToDecimal(txtUsdPricePartFourteen.Text);
                                            }
                                            if (aPart.PartCadPrice != Convert.ToDecimal(txtCadPricePartFourteen.Text))
                                            {
                                                aPart.PartCadPrice = Convert.ToDecimal(txtCadPricePartFourteen.Text);
                                            }
                                        }
                                        #endregion
                                        #region PartKey15
                                        else if (aPart.PartKeyNumber == 15)
                                        {
                                            if (aPart.PartUsdPrice != Convert.ToDecimal(txtUsdPricePartFifteen.Text))
                                            {
                                                aPart.PartUsdPrice = Convert.ToDecimal(txtUsdPricePartFifteen.Text);
                                            }
                                            if (aPart.PartCadPrice != Convert.ToDecimal(txtCadPricePartFifteen.Text))
                                            {
                                                aPart.PartCadPrice = Convert.ToDecimal(txtCadPricePartFifteen.Text);
                                            }
                                        }
                                        #endregion
                                        #region PartKey16
                                        else if (aPart.PartKeyNumber == 16)
                                        {
                                            if (aPart.PartUsdPrice != Convert.ToDecimal(txtUsdPricePartSixteen.Text))
                                            {
                                                aPart.PartUsdPrice = Convert.ToDecimal(txtUsdPricePartSixteen.Text);
                                            }
                                            if (aPart.PartCadPrice != Convert.ToDecimal(txtCadPricePartSixteen.Text))
                                            {
                                                aPart.PartCadPrice = Convert.ToDecimal(txtCadPricePartSixteen.Text);
                                            }
                                        }
                                        #endregion
                                        #region PartKey17
                                        else if (aPart.PartKeyNumber == 17)
                                        {
                                            if (aPart.PartUsdPrice != Convert.ToDecimal(txtUsdPricePartSeventeen.Text))
                                            {
                                                aPart.PartUsdPrice = Convert.ToDecimal(txtUsdPricePartSeventeen.Text);
                                            }
                                            if (aPart.PartCadPrice != Convert.ToDecimal(txtCadPricePartSeventeen.Text))
                                            {
                                                aPart.PartCadPrice = Convert.ToDecimal(txtCadPricePartSeventeen.Text);
                                            }
                                        }
                                        #endregion
                                        #region PartKey18
                                        else if (aPart.PartKeyNumber == 18)
                                        {
                                            if (aPart.PartUsdPrice != Convert.ToDecimal(txtUsdPricePartEighteen.Text))
                                            {
                                                aPart.PartUsdPrice = Convert.ToDecimal(txtUsdPricePartEighteen.Text);
                                            }
                                            if (aPart.PartCadPrice != Convert.ToDecimal(txtCadPricePartEighteen.Text))
                                            {
                                                aPart.PartCadPrice = Convert.ToDecimal(txtCadPricePartEighteen.Text);
                                            }
                                        }
                                        #endregion
                                        #region PartKey19
                                        else if (aPart.PartKeyNumber == 19)
                                        {
                                            if (aPart.PartUsdPrice != Convert.ToDecimal(txtUsdPricePartNineteen.Text))
                                            {
                                                aPart.PartUsdPrice = Convert.ToDecimal(txtUsdPricePartNineteen.Text);
                                            }
                                            if (aPart.PartCadPrice != Convert.ToDecimal(txtCadPricePartNineteen.Text))
                                            {
                                                aPart.PartCadPrice = Convert.ToDecimal(txtCadPricePartNineteen.Text);
                                            }
                                        }
                                        #endregion
                                        #region PartKey20
                                        else if (aPart.PartKeyNumber == 20)
                                        {
                                            if (aPart.PartUsdPrice != Convert.ToDecimal(txtUsdPricePartTwenty.Text))
                                            {
                                                aPart.PartUsdPrice = Convert.ToDecimal(txtUsdPricePartTwenty.Text);
                                            }
                                            if (aPart.PartCadPrice != Convert.ToDecimal(txtCadPricePartTwenty.Text))
                                            {
                                                aPart.PartCadPrice = Convert.ToDecimal(txtCadPricePartTwenty.Text);
                                            }
                                        }
                                        #endregion
                                        #region PartKey21
                                        else if (aPart.PartKeyNumber == 21)
                                        {
                                            if (aPart.PartUsdPrice != Convert.ToDecimal(txtUsdPricePartTwentyOne.Text))
                                            {
                                                aPart.PartUsdPrice = Convert.ToDecimal(txtUsdPricePartTwentyOne.Text);
                                            }
                                            if (aPart.PartCadPrice != Convert.ToDecimal(txtCadPricePartTwentyOne.Text))
                                            {
                                                aPart.PartCadPrice = Convert.ToDecimal(txtCadPricePartTwentyOne.Text);
                                            }
                                        }
                                        #endregion
                                        #region PartKey22
                                        else if (aPart.PartKeyNumber == 22)
                                        {
                                            if (aPart.PartUsdPrice != Convert.ToDecimal(txtUsdPricePartTwentyTwo.Text))
                                            {
                                                aPart.PartUsdPrice = Convert.ToDecimal(txtUsdPricePartTwentyTwo.Text);
                                            }
                                            if (aPart.PartCadPrice != Convert.ToDecimal(txtCadPricePartTwentyTwo.Text))
                                            {
                                                aPart.PartCadPrice = Convert.ToDecimal(txtCadPricePartTwentyTwo.Text);
                                            }
                                        }
                                        #endregion
                                        #region PartKey23
                                        else if (aPart.PartKeyNumber == 23)
                                        {
                                            if (aPart.PartUsdPrice != Convert.ToDecimal(txtUsdPricePartTwentyThree.Text))
                                            {
                                                aPart.PartUsdPrice = Convert.ToDecimal(txtUsdPricePartTwentyThree.Text);
                                            }
                                            if (aPart.PartCadPrice != Convert.ToDecimal(txtCadPricePartTwentyThree.Text))
                                            {
                                                aPart.PartCadPrice = Convert.ToDecimal(txtCadPricePartTwentyThree.Text);
                                            }
                                        }
                                        #endregion
                                        #endregion


                                        //call update function
                                        aSchematic.Update(datUpdateDataSource, Session["partNumber"].ToString());
                                        aPart.Update(datUpdateDataSource, aPart.PartNumber.ToString());

                                        //set session variable
                                        Session.Add("updatedObject", aSchematic);
                                        Session.Add("updatedPart", aPart);

                                    }
                                    break;
                                }
                            #endregion
                        }

                    }
                    if (Page.IsValid)
                    {
                        //remove 1 from current index to get previous product
                        Session["partIndex"] = (int)Session["partIndex"] + 1;
                        //find partnumber at previous product to update info on page
                        Session["partNumber"] = ddlPart.Items[(int)Session["partIndex"]].Value;
                        //let page know it has to update info
                        Session.Add("updateChanged", "true");
                        Response.Redirect("update.aspx"); //post
                    }
                }

                else
                #region Product Info And Pricing

                {
                    //select case statement for each possible object
                    switch (tableName)
                    {
                        //when roof extrusion is selected
                        case "tblRoofExtrusions":
                            {
                                //create new object
                                RoofExtrusion aRoofExtrusion = (RoofExtrusion)Session["roofExtrusion"];
                                Page.Validate("roofExtrusion");
                                Page.Validate("pricing");

                                if (Page.IsValid)
                                {
                                    //set member variables based on any changes made
                                    if (aRoofExtrusion.ExtrusionDescription != txtPartDesc.Text)
                                    {
                                        aRoofExtrusion.ExtrusionDescription = txtPartDesc.Text;
                                    }

                                    if (aRoofExtrusion.ExtrusionSize != 0)
                                    {
                                        aRoofExtrusion.ExtrusionSize = Convert.ToInt32(txtRoofExtSize.Text);
                                    }

                                    if (aRoofExtrusion.AngleA != 0)
                                    {
                                        aRoofExtrusion.AngleA = Convert.ToInt32(txtRoofExtAngleA.Text);
                                    }

                                    if (aRoofExtrusion.AngleB != 0.0m)
                                    {
                                        aRoofExtrusion.AngleB = Convert.ToDecimal(txtRoofExtAngleB.Text);
                                    }

                                    if (aRoofExtrusion.AngleC != 0)
                                    {
                                        aRoofExtrusion.AngleC = Convert.ToInt32(txtRoofExtAngleC.Text);
                                    }

                                    if (aRoofExtrusion.ExtrusionMaxLength != Convert.ToInt32(txtRoofExtMaxLength.Text))
                                    {
                                        aRoofExtrusion.ExtrusionMaxLength = Convert.ToInt32(txtRoofExtMaxLength.Text);
                                    }
                                    if (aRoofExtrusion.CadPrice != Convert.ToDecimal(txtCadPrice.Text))
                                    {
                                        aRoofExtrusion.CadPrice = Convert.ToDecimal(txtCadPrice.Text);
                                    }

                                    if (aRoofExtrusion.UsdPrice != Convert.ToDecimal(txtUsdPrice.Text))
                                    {
                                        aRoofExtrusion.UsdPrice = Convert.ToDecimal(txtUsdPrice.Text);
                                    }

                                    if (radActive.Checked)
                                    {
                                        aRoofExtrusion.Status = true;
                                    }
                                    else if (radInactive.Checked)
                                    {
                                        aRoofExtrusion.Status = false;
                                    }

                                    //call update function
                                    aRoofExtrusion.Update(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString());

                                    //set session variable
                                    Session.Add("updatedObject", aRoofExtrusion);
                                }
                                break;
                            }

                        case "tblAccessories":
                            {
                                Page.Validate("accessories");
                                Page.Validate("pricing");

                                if (Page.IsValid)
                                {
                                    //create new object
                                    Accessories anAccessory = (Accessories)Session["accessories"];

                                    //set member variables based on any changes made
                                    if (anAccessory.AccessoryDescription != txtPartDesc.Text)
                                    {
                                        anAccessory.AccessoryDescription = txtPartDesc.Text;
                                    }

                                    if (anAccessory.AccessoryPackQuantity != 0)
                                    {
                                        anAccessory.AccessoryPackQuantity = Convert.ToInt32(txtPackQuantity.Text);
                                    }

                                    if (anAccessory.AccessoryWidth != 0)
                                    {
                                        anAccessory.AccessoryWidth = Convert.ToInt32(txtAccessoryWidth.Text);
                                    }

                                    if (anAccessory.AccessoryLength != 0)
                                    {
                                        anAccessory.AccessoryLength = Convert.ToInt32(txtAccessoryLength.Text);
                                    }

                                    if (anAccessory.AccessorySize != 0)
                                    {
                                        anAccessory.AccessorySize = Convert.ToInt32(txtAccessorySize.Text);
                                    }

                                    if (anAccessory.AccessoryCadPrice != Convert.ToDecimal(txtCadPrice.Text))
                                    {
                                        anAccessory.AccessoryCadPrice = Convert.ToDecimal(txtCadPrice.Text);
                                    }

                                    if (anAccessory.AccessoryUsdPrice != Convert.ToDecimal(txtUsdPrice.Text))
                                    {
                                        anAccessory.AccessoryUsdPrice = Convert.ToDecimal(txtUsdPrice.Text);
                                    }

                                    if (radActive.Checked)
                                    {
                                        anAccessory.AccessoryStatus = true;
                                    }
                                    else if (radInactive.Checked)
                                    {
                                        anAccessory.AccessoryStatus = false;
                                    }

                                    //call update function
                                    anAccessory.Update(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString());

                                    //set session variable
                                    Session.Add("updatedObject", anAccessory);
                                }

                                break;
                            }

                        case "tblDecorativeColumn":
                            {
                                Page.Validate("pricing");
                                Page.Validate("decorativeColumn");
                                if (Page.IsValid)
                                {
                                    //create new object
                                    DecorativeColumn aColumn = (DecorativeColumn)Session["decorativeColumn"];

                                    //set member variables based on any changes made
                                    if (aColumn.ColumnDescription != txtPartDesc.Text)
                                    {
                                        aColumn.ColumnDescription = txtPartDesc.Text;
                                    }

                                    if (aColumn.ColumnLength != 0)
                                    {
                                        aColumn.ColumnLength = Convert.ToInt32(txtRoofDecColLength.Text);
                                    }

                                    if (aColumn.ColumnCadPrice != Convert.ToDecimal(txtCadPrice.Text))
                                    {
                                        aColumn.ColumnCadPrice = Convert.ToDecimal(txtCadPrice.Text);
                                    }

                                    if (aColumn.ColumnUsdPrice != Convert.ToDecimal(txtUsdPrice.Text))
                                    {
                                        aColumn.ColumnUsdPrice = Convert.ToDecimal(txtUsdPrice.Text);
                                    }

                                    if (radActive.Checked)
                                    {
                                        aColumn.ColumnStatus = true;
                                    }
                                    else if (radInactive.Checked)
                                    {
                                        aColumn.ColumnStatus = false;
                                    }

                                    //call update function
                                    aColumn.Update(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString());

                                    //set session variable
                                    Session.Add("updatedObject", aColumn);
                                }
                                break;
                            }

                        case "tblWallExtrusions":
                            {
                                Page.Validate("wallExtrusions");
                                Page.Validate("pricing");

                                if (Page.IsValid)
                                {
                                    //create new object
                                    WallExtrusions aWallExtrusion = (WallExtrusions)Session["wallExtrusions"];

                                    //set member variables based on any changes made
                                    if (aWallExtrusion.WallExtrusionDescription != txtPartDesc.Text)
                                    {
                                        aWallExtrusion.WallExtrusionDescription = txtPartDesc.Text;
                                    }

                                    if (aWallExtrusion.WallExtrusionMaxLength != 0)
                                    {
                                        aWallExtrusion.WallExtrusionMaxLength = Convert.ToInt32(txtWallExtMaxLength.Text);
                                    }

                                    if (aWallExtrusion.CadPrice != Convert.ToDecimal(txtCadPrice.Text))
                                    {
                                        aWallExtrusion.CadPrice = Convert.ToDecimal(txtCadPrice.Text);
                                    }

                                    if (aWallExtrusion.UsdPrice != Convert.ToDecimal(txtUsdPrice.Text))
                                    {
                                        aWallExtrusion.UsdPrice = Convert.ToDecimal(txtUsdPrice.Text);
                                    }

                                    if (radActive.Checked)
                                    {
                                        aWallExtrusion.Status = true;
                                    }
                                    else if (radInactive.Checked)
                                    {
                                        aWallExtrusion.Status = false;
                                    }

                                    //call update function
                                    aWallExtrusion.Update(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString());

                                    //set session variable
                                    Session.Add("updatedObject", aWallExtrusion);
                                }

                                break;
                            }

                        case "tblWallPanels":
                            {
                                Page.Validate("wallPanels");
                                Page.Validate("pricing");

                                if (Page.IsValid)
                                {
                                    //create new object
                                    WallPanels aWallPanel = (WallPanels)Session["wallPanels"];

                                    //set member variables based on any changes made
                                    if (aWallPanel.WallPanelDescription != txtPartDesc.Text)
                                    {
                                        aWallPanel.WallPanelDescription = txtPartDesc.Text;
                                    }

                                    if (aWallPanel.WallPanelStandard != txtStandard.Text)
                                    {
                                        aWallPanel.WallPanelStandard = txtStandard.Text;
                                    }

                                    if (aWallPanel.WallPanelComposition != txtComposition.Text)
                                    {
                                        aWallPanel.WallPanelComposition = txtComposition.Text;
                                    }

                                    if (aWallPanel.WallPanelMaxWidth != Convert.ToInt32(txtWallPnlMaxWidth.Text))
                                    {
                                        aWallPanel.WallPanelMaxWidth = Convert.ToInt32(txtWallPnlMaxWidth.Text);
                                    }

                                    if (aWallPanel.WallPanelMaxLength != Convert.ToInt32(txtWallPnlMaxLength.Text))
                                    {
                                        aWallPanel.WallPanelMaxLength = Convert.ToInt32(txtWallPnlMaxLength.Text);
                                    }

                                    if (aWallPanel.WallPanelSize != Convert.ToInt32(txtWallPnlSize.Text))
                                    {
                                        aWallPanel.WallPanelSize = Convert.ToInt32(txtWallPnlSize.Text);
                                    }

                                    if (aWallPanel.CadPrice != Convert.ToDecimal(txtCadPrice.Text))
                                    {
                                        aWallPanel.CadPrice = Convert.ToDecimal(txtCadPrice.Text);
                                    }

                                    if (aWallPanel.UsdPrice != Convert.ToDecimal(txtUsdPrice.Text))
                                    {
                                        aWallPanel.UsdPrice = Convert.ToDecimal(txtUsdPrice.Text);
                                    }

                                    if (radActive.Checked)
                                    {
                                        aWallPanel.Status = true;
                                    }
                                    else if (radInactive.Checked)
                                    {
                                        aWallPanel.Status = false;
                                    }

                                    //call update function
                                    aWallPanel.Update(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString());

                                    //set session variable
                                    Session.Add("updatedObject", aWallPanel);
                                }

                                break;
                            }

                        case "tblDoorFrameExtrusion":
                            {
                                Page.Validate("pricing");
                                Page.Validate("doorFrameExtrusion");
                                
                                if (Page.IsValid)
                                {
                                    //create new object
                                    DoorFrameExtrusion aDoorExtrusion = (DoorFrameExtrusion)Session["doorFrameExtrusion"];

                                    //set member variables based on any changes made
                                    if (aDoorExtrusion.DfeDescription != txtPartDesc.Text)
                                    {
                                        aDoorExtrusion.DfeDescription = txtPartDesc.Text;
                                    }

                                    if (aDoorExtrusion.DfeMaxLength != Convert.ToInt32(txtDoorFrExtMaxLength.Text))
                                    {
                                        aDoorExtrusion.DfeMaxLength = Convert.ToInt32(txtDoorFrExtMaxLength.Text);
                                    }
                                    if (aDoorExtrusion.CadPrice != Convert.ToDecimal(txtCadPrice.Text))
                                    {
                                        aDoorExtrusion.CadPrice = Convert.ToDecimal(txtCadPrice.Text);
                                    }

                                    if (aDoorExtrusion.UsdPrice != Convert.ToDecimal(txtUsdPrice.Text))
                                    {
                                        aDoorExtrusion.UsdPrice = Convert.ToDecimal(txtUsdPrice.Text);
                                    }

                                    if (radActive.Checked)
                                    {
                                        aDoorExtrusion.DfeStatus = true;
                                    }
                                    else if (radInactive.Checked)
                                    {
                                        aDoorExtrusion.DfeStatus = false;
                                    }

                                    //call update function
                                    aDoorExtrusion.Update(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString());

                                    //set session variable
                                    Session.Add("updatedObject", aDoorExtrusion);
                                }
                                break;
                            }

                        case "tblInsulatedFloors":
                            {
                                Page.Validate("pricing");
                                Page.Validate("insulatedFloors");

                                if (Page.IsValid)
                                {
                                    //create new object
                                    InsulatedFloors anInsulatedFloor = (InsulatedFloors)Session["insulatedFloors"];

                                    //set member variables based on any changes made
                                    if (anInsulatedFloor.InsulatedFloorDescription != txtPartDesc.Text)
                                    {
                                        anInsulatedFloor.InsulatedFloorDescription = txtPartDesc.Text;
                                    }

                                    if (anInsulatedFloor.InsulatedFloorComposition != txtComposition.Text)
                                    {
                                        anInsulatedFloor.InsulatedFloorComposition = txtComposition.Text;
                                    }

                                    if (anInsulatedFloor.InsulatedFloorSize != Convert.ToInt32(txtInsFloorSize.Text))
                                    {
                                        anInsulatedFloor.InsulatedFloorSize = Convert.ToInt32(txtInsFloorSize.Text);
                                    }

                                    if (anInsulatedFloor.InsulatedFloorMaxWidth != Convert.ToInt32(txtInsFloorPnlMaxWidth.Text))
                                    {
                                        anInsulatedFloor.InsulatedFloorMaxWidth = Convert.ToInt32(txtInsFloorPnlMaxWidth.Text);
                                    }

                                    if (anInsulatedFloor.InsulatedFloorCadPrice != Convert.ToDecimal(txtCadPrice.Text))
                                    {
                                        anInsulatedFloor.InsulatedFloorCadPrice = Convert.ToDecimal(txtCadPrice.Text);
                                    }

                                    if (anInsulatedFloor.InsulatedFloorUsdPrice != Convert.ToDecimal(txtUsdPrice.Text))
                                    {
                                        anInsulatedFloor.InsulatedFloorUsdPrice = Convert.ToDecimal(txtUsdPrice.Text);
                                    }

                                    if (radActive.Checked)
                                    {
                                        anInsulatedFloor.InsulatedFloorStatus = true;
                                    }
                                    else if (radInactive.Checked)
                                    {
                                        anInsulatedFloor.InsulatedFloorStatus = false;
                                    }

                                    //call update function
                                    anInsulatedFloor.Update(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString());

                                    //set session variable
                                    Session.Add("updatedObject", anInsulatedFloor);
                                }
                                break;
                            }

                        case "tblRoofPanels":
                            {
                                Page.Validate("pricing");
                                Page.Validate("roofPanels");

                                if (Page.IsValid)
                                {
                                    //create new object
                                    RoofPanels aRoofPanel = (RoofPanels)Session["roofPanels"];

                                    //set member variables based on any changes made
                                    if (aRoofPanel.PanelDescription != txtPartDesc.Text)
                                    {
                                        aRoofPanel.PanelDescription = txtPartDesc.Text;
                                    }

                                    if (aRoofPanel.PanelComposition != txtComposition.Text)
                                    {
                                        aRoofPanel.PanelComposition = txtComposition.Text;
                                    }

                                    if (aRoofPanel.PanelStandard != txtStandard.Text)
                                    {
                                        aRoofPanel.PanelStandard = txtStandard.Text;
                                    }

                                    if (aRoofPanel.PanelSize != Convert.ToInt32(txtRoofPnlSize.Text))
                                    {
                                        aRoofPanel.PanelSize = Convert.ToInt32(txtRoofPnlSize.Text);
                                    }

                                    if (aRoofPanel.PanelMaxWidth != Convert.ToInt32(txtRoofPnlMaxWidth.Text))
                                    {
                                        aRoofPanel.PanelMaxWidth = Convert.ToInt32(txtRoofPnlMaxWidth.Text);
                                    }

                                    if (aRoofPanel.CadPrice != Convert.ToDecimal(txtCadPrice.Text))
                                    {
                                        aRoofPanel.CadPrice = Convert.ToDecimal(txtCadPrice.Text);
                                    }

                                    if (aRoofPanel.UsdPrice != Convert.ToDecimal(txtUsdPrice.Text))
                                    {
                                        aRoofPanel.UsdPrice = Convert.ToDecimal(txtUsdPrice.Text);
                                    }

                                    if (radActive.Checked)
                                    {
                                        aRoofPanel.Status = true;
                                    }
                                    else if (radInactive.Checked)
                                    {
                                        aRoofPanel.Status = false;
                                    }

                                    //call update function
                                    aRoofPanel.Update(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString());

                                    //set session variable
                                    Session.Add("updatedObject", aRoofPanel);
                                }
                                break;
                            }

                        case "tblScreenRoll":
                            {
                                Page.Validate("pricing");
                                Page.Validate("screenRoll");

                                if (Page.IsValid)
                                {
                                    //create new object
                                    ScreenRoll aScreenRoll = (ScreenRoll)Session["screenRoll"];

                                    //set member variables based on any changes made

                                    if (aScreenRoll.ScreenRollWidth != Convert.ToInt32(txtScreenRollWidth.Text))
                                    {
                                        aScreenRoll.ScreenRollWidth = Convert.ToInt32(txtScreenRollWidth.Text);
                                    }

                                    if (aScreenRoll.ScreenRollLength != Convert.ToInt32(txtScreenRollLength.Text))
                                    {
                                        aScreenRoll.ScreenRollLength = Convert.ToInt32(txtScreenRollLength.Text);
                                    }

                                    if (aScreenRoll.CadPrice != Convert.ToDecimal(txtCadPrice.Text))
                                    {
                                        aScreenRoll.CadPrice = Convert.ToDecimal(txtCadPrice.Text);
                                    }

                                    if (aScreenRoll.UsdPrice != Convert.ToDecimal(txtUsdPrice.Text))
                                    {
                                        aScreenRoll.UsdPrice = Convert.ToDecimal(txtUsdPrice.Text);
                                    }

                                    if (radActive.Checked)
                                    {
                                        aScreenRoll.Status = true;
                                    }
                                    else if (radInactive.Checked)
                                    {
                                        aScreenRoll.Status = false;
                                    }

                                    //call update function
                                    aScreenRoll.Update(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString());

                                    //set session variable
                                    Session.Add("updatedObject", aScreenRoll);
                                }
                                break;
                            }

                        case "tblVinylRoll":
                            {
                                Page.Validate("pricing");
                                Page.Validate("vinylRoll");
                                if (Page.IsValid)
                                {
                                    //create new object
                                    VinylRoll aVinylRoll = (VinylRoll)Session["vinylRoll"];

                                    //set member variables based on any changes made

                                    if (aVinylRoll.VinylRollWidth != Convert.ToInt32(txtVinylRollWidth.Text))
                                    {
                                        aVinylRoll.VinylRollWidth = Convert.ToInt32(txtVinylRollWidth.Text);
                                    }

                                    if (aVinylRoll.VinylRollWeight != Convert.ToInt32(txtVinylRollWeight.Text))
                                    {
                                        aVinylRoll.VinylRollWeight = Convert.ToInt32(txtVinylRollWeight.Text);
                                    }

                                    if (aVinylRoll.CadPrice != Convert.ToDecimal(txtCadPrice.Text))
                                    {
                                        aVinylRoll.CadPrice = Convert.ToDecimal(txtCadPrice.Text);
                                    }

                                    if (aVinylRoll.UsdPrice != Convert.ToDecimal(txtUsdPrice.Text))
                                    {
                                        aVinylRoll.UsdPrice = Convert.ToDecimal(txtUsdPrice.Text);
                                    }

                                    if (radActive.Checked)
                                    {
                                        aVinylRoll.Status = true;
                                    }
                                    else if (radInactive.Checked)
                                    {
                                        aVinylRoll.Status = false;
                                    }

                                    //call update function
                                    aVinylRoll.Update(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString());

                                    //set session variable
                                    Session.Add("updatedObject", aVinylRoll);
                                }
                                break;
                            }

                        case "tblSunrail300":
                            {
                                Page.Validate("sunrail300");
                                Page.Validate("pricing");

                                if (Page.IsValid)
                                {
                                    //create new object
                                    Sunrail300 aSunrail300 = (Sunrail300)Session["sunrail300"];

                                    //set member variables based on any changes made
                                    if (aSunrail300.Sunrail300Description != txtPartDesc.Text)
                                    {
                                        aSunrail300.Sunrail300Description = txtPartDesc.Text;
                                    }

                                    if (aSunrail300.Sunrail300MaxLengthFeet != Convert.ToInt32(txtSun300MaxLengthFt.Text))
                                    {
                                        aSunrail300.Sunrail300MaxLengthFeet = Convert.ToInt32(txtSun300MaxLengthFt.Text);
                                    }

                                    if (aSunrail300.Sunrail300MaxLengthInches != Convert.ToInt32(txtSun300PnlMaxLengthInch.Text))
                                    {
                                        aSunrail300.Sunrail300MaxLengthInches = Convert.ToInt32(txtSun300PnlMaxLengthInch.Text);
                                    }

                                    if (aSunrail300.Sunrail300CadPrice != Convert.ToDecimal(txtCadPrice.Text))
                                    {
                                        aSunrail300.Sunrail300CadPrice = Convert.ToDecimal(txtCadPrice.Text);
                                    }

                                    if (aSunrail300.Sunrail300UsdPrice != Convert.ToDecimal(txtUsdPrice.Text))
                                    {
                                        aSunrail300.Sunrail300UsdPrice = Convert.ToDecimal(txtUsdPrice.Text);
                                    }

                                    if (radActive.Checked)
                                    {
                                        aSunrail300.Sunrail300Status = true;
                                    }
                                    else if (radInactive.Checked)
                                    {
                                        aSunrail300.Sunrail300Status = false;
                                    }

                                    //call update function
                                    aSunrail300.Update(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString());

                                    //set session variable
                                    Session.Add("updatedObject", aSunrail300);
                                }
                                break;
                            }
                        #region Sunrail300Accessories
                        case "tblSunrail300Accessories":
                            {
                                Page.Validate("pricing");

                                if (Page.IsValid)
                                {
                                    //create new object
                                    Sunrail300Accessories aSunrail300Accessory = (Sunrail300Accessories)Session["sunrail300Acc"];

                                    //set member variables based on any changes made
                                    if (aSunrail300Accessory.Sunrail300AccessoriesDescription != txtPartDesc.Text)
                                    {
                                        aSunrail300Accessory.Sunrail300AccessoriesDescription = txtPartDesc.Text;
                                    }

                                    if (aSunrail300Accessory.Sunrail300AccessoriesCadPrice != Convert.ToDecimal(txtCadPrice.Text))
                                    {
                                        aSunrail300Accessory.Sunrail300AccessoriesCadPrice = Convert.ToDecimal(txtCadPrice.Text);
                                    }

                                    if (aSunrail300Accessory.Sunrail300AccessoriesUsdPrice != Convert.ToDecimal(txtUsdPrice.Text))
                                    {
                                        aSunrail300Accessory.Sunrail300AccessoriesUsdPrice = Convert.ToDecimal(txtUsdPrice.Text);
                                    }

                                    if (radActive.Checked)
                                    {
                                        aSunrail300Accessory.Sunrail300AccessoriesStatus = true;
                                    }
                                    else if (radInactive.Checked)
                                    {
                                        aSunrail300Accessory.Sunrail300AccessoriesStatus = false;
                                    }

                                    //call update function
                                    aSunrail300Accessory.Update(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString());

                                    //set session variable
                                    Session.Add("updatedObject", aSunrail300Accessory);
                                }
                                break;
                            }
                        #endregion
                        #region Sunrail400
                        case "tblSunrail400":
                            {
                                Page.Validate("sunrail400");
                                Page.Validate("pricing");

                                if (Page.IsValid)
                                {
                                    //create new object
                                    Sunrail400 aSunrail400 = (Sunrail400)Session["sunrail400"];

                                    //set member variables based on any changes made
                                    if (aSunrail400.Sunrail400Description != txtPartDesc.Text)
                                    {
                                        aSunrail400.Sunrail400Description = txtPartDesc.Text;
                                    }

                                    if (aSunrail400.Sunrail400MaxLengthFeet != Convert.ToInt32(txtSun400MaxLengthFt.Text))
                                    {
                                        aSunrail400.Sunrail400MaxLengthFeet = Convert.ToInt32(txtSun400MaxLengthFt.Text);
                                    }

                                    if (aSunrail400.Sunrail400MaxLengthInches != Convert.ToInt32(txtSun400PnlMaxLengthInch.Text))
                                    {
                                        aSunrail400.Sunrail400MaxLengthInches = Convert.ToInt32(txtSun400PnlMaxLengthInch.Text);
                                    }

                                    if (aSunrail400.Sunrail400CadPrice != Convert.ToDecimal(txtCadPrice.Text))
                                    {
                                        aSunrail400.Sunrail400CadPrice = Convert.ToDecimal(txtCadPrice.Text);
                                    }

                                    if (aSunrail400.Sunrail400UsdPrice != Convert.ToDecimal(txtUsdPrice.Text))
                                    {
                                        aSunrail400.Sunrail400UsdPrice = Convert.ToDecimal(txtUsdPrice.Text);
                                    }

                                    if (radActive.Checked)
                                    {
                                        aSunrail400.Sunrail400Status = true;
                                    }
                                    else if (radInactive.Checked)
                                    {
                                        aSunrail400.Sunrail400Status = false;
                                    }

                                    //call update function
                                    aSunrail400.Update(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString());

                                    //set session variable
                                    Session.Add("updatedObject", aSunrail400);
                                }
                                break;
                            }
                        #endregion
                        #region Sunrail1000
                        case "tblSunrail1000":
                            {
                                Page.Validate("sunrail1000");
                                Page.Validate("pricing");

                                if (Page.IsValid)
                                {
                                    //create new object
                                    Sunrail1000 aSunrail1000 = (Sunrail1000)Session["sunrail1000"];

                                    //set member variables based on any changes made
                                    if (aSunrail1000.Sunrail1000Description != txtPartDesc.Text)
                                    {
                                        aSunrail1000.Sunrail1000Description = txtPartDesc.Text;
                                    }

                                    if (aSunrail1000.Sunrail1000MaxLengthFeet != Convert.ToInt32(txtSun1000MaxLengthFt.Text))
                                    {
                                        aSunrail1000.Sunrail1000MaxLengthFeet = Convert.ToInt32(txtSun1000MaxLengthFt.Text);
                                    }

                                    if (aSunrail1000.Sunrail1000MaxLengthInches != Convert.ToInt32(txtSun1000PnlMaxLengthInch.Text))
                                    {
                                        aSunrail1000.Sunrail1000MaxLengthInches = Convert.ToInt32(txtSun1000PnlMaxLengthInch.Text);
                                    }

                                    if (aSunrail1000.Sunrail1000CadPrice != Convert.ToDecimal(txtCadPrice.Text))
                                    {
                                        aSunrail1000.Sunrail1000CadPrice = Convert.ToDecimal(txtCadPrice.Text);
                                    }

                                    if (aSunrail1000.Sunrail1000UsdPrice != Convert.ToDecimal(txtUsdPrice.Text))
                                    {
                                        aSunrail1000.Sunrail1000UsdPrice = Convert.ToDecimal(txtUsdPrice.Text);
                                    }

                                    if (radActive.Checked)
                                    {
                                        aSunrail1000.Sunrail1000Status = true;
                                    }
                                    else if (radInactive.Checked)
                                    {
                                        aSunrail1000.Sunrail1000Status = false;
                                    }

                                    //call update function
                                    aSunrail1000.Update(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString());

                                    //set session variable
                                    Session.Add("updatedObject", aSunrail1000);
                                }
                                break;
                            }
                        #endregion

                        #region SuncrylicRoof
                        case "tblSuncrylicRoof":
                            {
                                Page.Validate("pricing");
                                Page.Validate("suncrylicRoof");
                                if (Page.IsValid)
                                {
                                    //create new object
                                    SuncrylicRoof aSunRoof = (SuncrylicRoof)Session["suncrylicRoof"];

                                    //set member variables based on any changes made
                                    if (aSunRoof.SuncrylicDescription != txtPartDesc.Text)
                                    {
                                        aSunRoof.SuncrylicDescription = txtPartDesc.Text;
                                    }

                                    if (aSunRoof.SuncrylicMaxLength != Convert.ToInt32(txtSun1000PnlMaxLengthInch.Text))
                                    {
                                        aSunRoof.SuncrylicMaxLength = Convert.ToInt32(txtSun1000PnlMaxLengthInch.Text);
                                    }

                                    if (aSunRoof.CadPrice != Convert.ToDecimal(txtCadPrice.Text))
                                    {
                                        aSunRoof.CadPrice = Convert.ToDecimal(txtCadPrice.Text);
                                    }

                                    if (aSunRoof.UsdPrice != Convert.ToDecimal(txtUsdPrice.Text))
                                    {
                                        aSunRoof.UsdPrice = Convert.ToDecimal(txtUsdPrice.Text);
                                    }

                                    if (radActive.Checked)
                                    {
                                        aSunRoof.Status = true;
                                    }
                                    else if (radInactive.Checked)
                                    {
                                        aSunRoof.Status = false;
                                    }

                                    //call update function
                                    aSunRoof.Update(datUpdateDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString());

                                    //set session variable
                                    Session.Add("updatedObject", aSunRoof);
                                }
                                break;
                            }
                        #endregion
                        #region Schematics
                        case "tblSchematics":
                            {
                                Page.Validate("pricing");

                                if (ddlSchem.SelectedValue != "")
                                {
                                    Schematics aSchematic = (Schematics)Session["schematic"];
                                    Part aPart = new Part();                                    

                                    if (Page.IsValid)
                                    {

                                        if (Session["part"] != null)
                                        {
                                            aPart = (Part)Session["part"];
                                        }
                                        else
                                        {
                                            aPart.Populate(aPart.SelectAll(datUpdateDataSource, ddlSchem.SelectedValue, Session["partNumber"].ToString()));
                                            Session.Add("part", aPart);
                                        }

                                        //set member variables based on any changes made
                                        if (aSchematic.SchematicDescription != txtPartDesc.Text)
                                        {
                                            aSchematic.SchematicDescription = txtPartDesc.Text;
                                        }

                                        if (aSchematic.SchematicCadPrice != Convert.ToDecimal(txtCadPriceSchematic.Text))
                                        {
                                            aSchematic.SchematicCadPrice = Convert.ToDecimal(txtCadPriceSchematic.Text);
                                        }

                                        if (aSchematic.SchematicUsdPrice != Convert.ToDecimal(txtUsdPriceSchematic.Text))
                                        {
                                            aSchematic.SchematicUsdPrice = Convert.ToDecimal(txtUsdPriceSchematic.Text);
                                        }

                                        if (radActive.Checked)
                                        {
                                            aSchematic.SchematicStatus = true;
                                        }
                                        else if (radInactive.Checked)
                                        {
                                            aSchematic.SchematicStatus = false;
                                        }

                                        if (aPart.PartKeyNumber == 1)
                                        {
                                            if (aPart.PartUsdPrice != Convert.ToDecimal(txtUsdPricePartOne.Text))
                                            {
                                                aPart.PartUsdPrice = Convert.ToDecimal(txtUsdPricePartOne.Text);
                                            }

                                            if (aPart.PartCadPrice != Convert.ToDecimal(txtCadPricePartOne.Text))
                                            {
                                                aPart.PartCadPrice = Convert.ToDecimal(txtCadPricePartOne.Text);
                                            }
                                        }

                                        else if (aPart.PartKeyNumber == 2)
                                        {
                                            if (aPart.PartUsdPrice != Convert.ToDecimal(txtUsdPricePartTwo.Text))
                                            {
                                                aPart.PartUsdPrice = Convert.ToDecimal(txtUsdPricePartTwo.Text);
                                            }

                                            if (aPart.PartCadPrice != Convert.ToDecimal(txtCadPricePartTwo.Text))
                                            {
                                                aPart.PartCadPrice = Convert.ToDecimal(txtCadPricePartTwo.Text);
                                            }
                                        }

                                        else if (aPart.PartKeyNumber == 3)
                                        {
                                            if (aPart.PartUsdPrice != Convert.ToDecimal(txtUsdPricePartThree.Text))
                                            {
                                                aPart.PartUsdPrice = Convert.ToDecimal(txtUsdPricePartThree.Text);
                                            }
                                            if (aPart.PartCadPrice != Convert.ToDecimal(txtCadPricePartThree.Text))
                                            {
                                                aPart.PartCadPrice = Convert.ToDecimal(txtCadPricePartThree.Text);
                                            }
                                        }

                                        else if (aPart.PartKeyNumber == 4)
                                        {
                                            if (aPart.PartUsdPrice != Convert.ToDecimal(txtUsdPricePartFour.Text))
                                            {
                                                aPart.PartUsdPrice = Convert.ToDecimal(txtUsdPricePartFour.Text);
                                            }
                                            if (aPart.PartCadPrice != Convert.ToDecimal(txtCadPricePartFour.Text))
                                            {
                                                aPart.PartCadPrice = Convert.ToDecimal(txtCadPricePartFour.Text);
                                            }
                                        }

                                        else if (aPart.PartKeyNumber == 5)
                                        {
                                            if (aPart.PartUsdPrice != Convert.ToDecimal(txtUsdPricePartFive.Text))
                                            {
                                                aPart.PartUsdPrice = Convert.ToDecimal(txtUsdPricePartFive.Text);
                                            }
                                            if (aPart.PartCadPrice != Convert.ToDecimal(txtCadPricePartFive.Text))
                                            {
                                                aPart.PartCadPrice = Convert.ToDecimal(txtCadPricePartFive.Text);
                                            }
                                        }

                                        else if (aPart.PartKeyNumber == 6)
                                        {
                                            if (aPart.PartUsdPrice != Convert.ToDecimal(txtUsdPricePartSix.Text))
                                            {
                                                aPart.PartUsdPrice = Convert.ToDecimal(txtUsdPricePartSix.Text);
                                            }
                                            if (aPart.PartCadPrice != Convert.ToDecimal(txtCadPricePartSix.Text))
                                            {
                                                aPart.PartCadPrice = Convert.ToDecimal(txtCadPricePartSix.Text);
                                            }
                                        }

                                        else if (aPart.PartKeyNumber == 7)
                                        {
                                            if (aPart.PartUsdPrice != Convert.ToDecimal(txtUsdPricePartSeven.Text))
                                            {
                                                aPart.PartUsdPrice = Convert.ToDecimal(txtUsdPricePartSeven.Text);
                                            }
                                            if (aPart.PartCadPrice != Convert.ToDecimal(txtCadPricePartSeven.Text))
                                            {
                                                aPart.PartCadPrice = Convert.ToDecimal(txtCadPricePartSeven.Text);
                                            }
                                        }

                                        else if (aPart.PartKeyNumber == 8)
                                        {
                                            if (aPart.PartUsdPrice != Convert.ToDecimal(txtUsdPricePartEight.Text))
                                            {
                                                aPart.PartUsdPrice = Convert.ToDecimal(txtUsdPricePartEight.Text);
                                            }
                                            if (aPart.PartCadPrice != Convert.ToDecimal(txtCadPricePartEight.Text))
                                            {
                                                aPart.PartCadPrice = Convert.ToDecimal(txtCadPricePartEight.Text);
                                            }
                                        }

                                        else if (aPart.PartKeyNumber == 9)
                                        {
                                            if (aPart.PartUsdPrice != Convert.ToDecimal(txtUsdPricePartNine.Text))
                                            {
                                                aPart.PartUsdPrice = Convert.ToDecimal(txtUsdPricePartNine.Text);
                                            }
                                            if (aPart.PartCadPrice != Convert.ToDecimal(txtCadPricePartNine.Text))
                                            {
                                                aPart.PartCadPrice = Convert.ToDecimal(txtCadPricePartNine.Text);
                                            }
                                        }

                                        else if (aPart.PartKeyNumber == 10)
                                        {
                                            if (aPart.PartUsdPrice != Convert.ToDecimal(txtUsdPricePartTen.Text))
                                            {
                                                aPart.PartUsdPrice = Convert.ToDecimal(txtUsdPricePartTen.Text);
                                            }
                                            if (aPart.PartCadPrice != Convert.ToDecimal(txtCadPricePartTen.Text))
                                            {
                                                aPart.PartCadPrice = Convert.ToDecimal(txtCadPricePartTen.Text);
                                            }
                                        }

                                        else if (aPart.PartKeyNumber == 11)
                                        {
                                            if (aPart.PartUsdPrice != Convert.ToDecimal(txtUsdPricePartEleven.Text))
                                            {
                                                aPart.PartUsdPrice = Convert.ToDecimal(txtUsdPricePartEleven.Text);
                                            }
                                            if (aPart.PartCadPrice != Convert.ToDecimal(txtCadPricePartEleven.Text))
                                            {
                                                aPart.PartCadPrice = Convert.ToDecimal(txtCadPricePartEleven.Text);
                                            }
                                        }

                                        else if (aPart.PartKeyNumber == 12)
                                        {
                                            if (aPart.PartUsdPrice != Convert.ToDecimal(txtUsdPricePartTwelve.Text))
                                            {
                                                aPart.PartUsdPrice = Convert.ToDecimal(txtUsdPricePartTwelve.Text);
                                            }
                                            if (aPart.PartCadPrice != Convert.ToDecimal(txtCadPricePartTwelve.Text))
                                            {
                                                aPart.PartCadPrice = Convert.ToDecimal(txtCadPricePartTwelve.Text);
                                            }
                                        }

                                        else if (aPart.PartKeyNumber == 13)
                                        {
                                            if (aPart.PartUsdPrice != Convert.ToDecimal(txtUsdPricePartThirteen.Text))
                                            {
                                                aPart.PartUsdPrice = Convert.ToDecimal(txtUsdPricePartThirteen.Text);
                                            }
                                            if (aPart.PartCadPrice != Convert.ToDecimal(txtCadPricePartThirteen.Text))
                                            {
                                                aPart.PartCadPrice = Convert.ToDecimal(txtCadPricePartThirteen.Text);
                                            }
                                        }

                                        else if (aPart.PartKeyNumber == 14)
                                        {
                                            if (aPart.PartUsdPrice != Convert.ToDecimal(txtUsdPricePartFourteen.Text))
                                            {
                                                aPart.PartUsdPrice = Convert.ToDecimal(txtUsdPricePartFourteen.Text);
                                            }
                                            if (aPart.PartCadPrice != Convert.ToDecimal(txtCadPricePartFourteen.Text))
                                            {
                                                aPart.PartCadPrice = Convert.ToDecimal(txtCadPricePartFourteen.Text);
                                            }
                                        }

                                        else if (aPart.PartKeyNumber == 15)
                                        {
                                            if (aPart.PartUsdPrice != Convert.ToDecimal(txtUsdPricePartFifteen.Text))
                                            {
                                                aPart.PartUsdPrice = Convert.ToDecimal(txtUsdPricePartFifteen.Text);
                                            }
                                            if (aPart.PartCadPrice != Convert.ToDecimal(txtCadPricePartFifteen.Text))
                                            {
                                                aPart.PartCadPrice = Convert.ToDecimal(txtCadPricePartFifteen.Text);
                                            }
                                        }

                                        else if (aPart.PartKeyNumber == 16)
                                        {
                                            if (aPart.PartUsdPrice != Convert.ToDecimal(txtUsdPricePartSixteen.Text))
                                            {
                                                aPart.PartUsdPrice = Convert.ToDecimal(txtUsdPricePartSixteen.Text);
                                            }
                                            if (aPart.PartCadPrice != Convert.ToDecimal(txtCadPricePartSixteen.Text))
                                            {
                                                aPart.PartCadPrice = Convert.ToDecimal(txtCadPricePartSixteen.Text);
                                            }
                                        }

                                        else if (aPart.PartKeyNumber == 17)
                                        {
                                            if (aPart.PartUsdPrice != Convert.ToDecimal(txtUsdPricePartSeventeen.Text))
                                            {
                                                aPart.PartUsdPrice = Convert.ToDecimal(txtUsdPricePartSeventeen.Text);
                                            }
                                            if (aPart.PartCadPrice != Convert.ToDecimal(txtCadPricePartSeventeen.Text))
                                            {
                                                aPart.PartCadPrice = Convert.ToDecimal(txtCadPricePartSeventeen.Text);
                                            }
                                        }

                                        else if (aPart.PartKeyNumber == 18)
                                        {
                                            if (aPart.PartUsdPrice != Convert.ToDecimal(txtUsdPricePartEighteen.Text))
                                            {
                                                aPart.PartUsdPrice = Convert.ToDecimal(txtUsdPricePartEighteen.Text);
                                            }
                                            if (aPart.PartCadPrice != Convert.ToDecimal(txtCadPricePartEighteen.Text))
                                            {
                                                aPart.PartCadPrice = Convert.ToDecimal(txtCadPricePartEighteen.Text);
                                            }
                                        }

                                        else if (aPart.PartKeyNumber == 19)
                                        {
                                            if (aPart.PartUsdPrice != Convert.ToDecimal(txtUsdPricePartNineteen.Text))
                                            {
                                                aPart.PartUsdPrice = Convert.ToDecimal(txtUsdPricePartNineteen.Text);
                                            }
                                            if (aPart.PartCadPrice != Convert.ToDecimal(txtCadPricePartNineteen.Text))
                                            {
                                                aPart.PartCadPrice = Convert.ToDecimal(txtCadPricePartNineteen.Text);
                                            }
                                        }

                                        else if (aPart.PartKeyNumber == 20)
                                        {
                                            if (aPart.PartUsdPrice != Convert.ToDecimal(txtUsdPricePartTwenty.Text))
                                            {
                                                aPart.PartUsdPrice = Convert.ToDecimal(txtUsdPricePartTwenty.Text);
                                            }
                                            if (aPart.PartCadPrice != Convert.ToDecimal(txtCadPricePartTwenty.Text))
                                            {
                                                aPart.PartCadPrice = Convert.ToDecimal(txtCadPricePartTwenty.Text);
                                            }
                                        }

                                        else if (aPart.PartKeyNumber == 21)
                                        {
                                            if (aPart.PartUsdPrice != Convert.ToDecimal(txtUsdPricePartTwentyOne.Text))
                                            {
                                                aPart.PartUsdPrice = Convert.ToDecimal(txtUsdPricePartTwentyOne.Text);
                                            }
                                            if (aPart.PartCadPrice != Convert.ToDecimal(txtCadPricePartTwentyOne.Text))
                                            {
                                                aPart.PartCadPrice = Convert.ToDecimal(txtCadPricePartTwentyOne.Text);
                                            }
                                        }

                                        else if (aPart.PartKeyNumber == 22)
                                        {
                                            if (aPart.PartUsdPrice != Convert.ToDecimal(txtUsdPricePartTwentyTwo.Text))
                                            {
                                                aPart.PartUsdPrice = Convert.ToDecimal(txtUsdPricePartTwentyTwo.Text);
                                            }
                                            if (aPart.PartCadPrice != Convert.ToDecimal(txtCadPricePartTwentyTwo.Text))
                                            {
                                                aPart.PartCadPrice = Convert.ToDecimal(txtCadPricePartTwentyTwo.Text);
                                            }
                                        }

                                        else if (aPart.PartKeyNumber == 23)
                                        {
                                            if (aPart.PartUsdPrice != Convert.ToDecimal(txtUsdPricePartTwentyThree.Text))
                                            {
                                                aPart.PartUsdPrice = Convert.ToDecimal(txtUsdPricePartTwentyThree.Text);
                                            }
                                            if (aPart.PartCadPrice != Convert.ToDecimal(txtCadPricePartTwentyThree.Text))
                                            {
                                                aPart.PartCadPrice = Convert.ToDecimal(txtCadPricePartTwentyThree.Text);
                                            }
                                        }


                                        //call update function
                                        aSchematic.Update(datUpdateDataSource, Session["partNumber"].ToString());
                                        aPart.Update(datUpdateDataSource, aPart.PartNumber.ToString());

                                        //set session variable
                                        Session.Add("updatedObject", aSchematic);
                                        Session.Add("updatedPart", aPart);
                                    }
                        #endregion
                                }
                                break;
                            }
                #endregion

                    }
                }

                if (Page.IsValid)
                {
                    /*
                    List<string> keys = new List<string>();

                    // retrieve application Cache enumerator
                    System.Collections.IDictionaryEnumerator enumerator = Cache.GetEnumerator();

                    // copy all keys that currently exist in Cache
                    while (enumerator.MoveNext())
                    {
                        keys.Add(enumerator.Key.ToString());
                    }

                    // delete every key from cache
                    for (int i = 0; i < keys.Count; i++)
                    {
                        Cache.Remove(keys[i]);
                    }

                    System.IO.File.Copy(Server.MapPath("Images/catalogue/temp.jpg"), Server.MapPath("Images/catalogue/" + Session["partNumber"].ToString() + ".jpg"), true);                    
                    //redirect to Display.aspx
                     */
                    Session.Add("updateChanged", "true");
                    Response.Redirect("Display.aspx");
                }
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                //Re-initialize this page
                Response.Redirect("Update.aspx");
            }
        }

        protected void ddlSchem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Page.IsPostBack && ddlSchem.SelectedValue == "")
            {
                Response.Redirect("Update.aspx");
            }
            else
            {
                #region Part Validation Group
                rfvUsdPricePartOne.ValidationGroup = "";
                rfvCadPricePartOne.ValidationGroup = "";
                cmpUsdPricePartOne.ValidationGroup = "";
                cmpCadPricePartOne.ValidationGroup = "";

                rfvUsdPricePartTwo.ValidationGroup = "";
                rfvCadPricePartTwo.ValidationGroup = "";
                cmpUsdPricePartTwo.ValidationGroup = "";
                cmpCadPricePartTwo.ValidationGroup = "";

                rfvUsdPricePartThree.ValidationGroup = "";
                rfvCadPricePartThree.ValidationGroup = "";
                cmpUsdPricePartThree.ValidationGroup = "";
                cmpCadPricePartThree.ValidationGroup = "";

                rfvUsdPricePartFour.ValidationGroup = "";
                rfvCadPricePartFour.ValidationGroup = "";
                cmpUsdPricePartFour.ValidationGroup = "";
                cmpCadPricePartFour.ValidationGroup = "";

                rfvUsdPricePartFive.ValidationGroup = "";
                rfvCadPricePartFive.ValidationGroup = "";
                cmpUsdPricePartFive.ValidationGroup = "";
                cmpCadPricePartFive.ValidationGroup = "";

                rfvUsdPricePartSix.ValidationGroup = "";
                rfvCadPricePartSix.ValidationGroup = "";
                cmpUsdPricePartSix.ValidationGroup = "";
                cmpCadPricePartSix.ValidationGroup = "";

                rfvUsdPricePartSeven.ValidationGroup = "";
                rfvCadPricePartSeven.ValidationGroup = "";
                cmpUsdPricePartSeven.ValidationGroup = "";
                cmpCadPricePartSeven.ValidationGroup = "";

                rfvUsdPricePartEight.ValidationGroup = "";
                rfvCadPricePartEight.ValidationGroup = "";
                cmpUsdPricePartEight.ValidationGroup = "";
                cmpCadPricePartEight.ValidationGroup = "";

                rfvUsdPricePartNine.ValidationGroup = "";
                rfvCadPricePartNine.ValidationGroup = "";
                cmpUsdPricePartNine.ValidationGroup = "";
                cmpCadPricePartNine.ValidationGroup = "";

                rfvUsdPricePartTen.ValidationGroup = "";
                rfvCadPricePartTen.ValidationGroup = "";
                cmpUsdPricePartTen.ValidationGroup = "";
                cmpCadPricePartTen.ValidationGroup = "";

                rfvUsdPricePartEleven.ValidationGroup = "";
                rfvCadPricePartEleven.ValidationGroup = "";
                cmpUsdPricePartEleven.ValidationGroup = "";
                cmpCadPricePartEleven.ValidationGroup = "";

                rfvUsdPricePartTwelve.ValidationGroup = "";
                rfvCadPricePartTwelve.ValidationGroup = "";
                cmpUsdPricePartTwelve.ValidationGroup = "";
                cmpCadPricePartTwelve.ValidationGroup = "";

                rfvUsdPricePartThirteen.ValidationGroup = "";
                rfvCadPricePartThirteen.ValidationGroup = "";
                cmpUsdPricePartThirteen.ValidationGroup = "";
                cmpCadPricePartThirteen.ValidationGroup = "";

                rfvUsdPricePartFourteen.ValidationGroup = "";
                rfvCadPricePartFourteen.ValidationGroup = "";
                cmpUsdPricePartFourteen.ValidationGroup = "";
                cmpCadPricePartFourteen.ValidationGroup = "";

                rfvUsdPricePartFifteen.ValidationGroup = "";
                rfvCadPricePartFifteen.ValidationGroup = "";
                cmpUsdPricePartFifteen.ValidationGroup = "";
                cmpCadPricePartFifteen.ValidationGroup = "";

                rfvUsdPricePartSixteen.ValidationGroup = "";
                rfvCadPricePartSixteen.ValidationGroup = "";
                cmpUsdPricePartSixteen.ValidationGroup = "";
                cmpCadPricePartSixteen.ValidationGroup = "";

                rfvUsdPricePartSeventeen.ValidationGroup = "";
                rfvCadPricePartSeventeen.ValidationGroup = "";
                cmpUsdPricePartSeventeen.ValidationGroup = "";
                cmpCadPricePartSeventeen.ValidationGroup = "";

                rfvUsdPricePartEighteen.ValidationGroup = "";
                rfvCadPricePartEighteen.ValidationGroup = "";
                cmpUsdPricePartEighteen.ValidationGroup = "";
                cmpCadPricePartEighteen.ValidationGroup = "";

                rfvUsdPricePartNineteen.ValidationGroup = "";
                rfvCadPricePartNineteen.ValidationGroup = "";
                cmpUsdPricePartNineteen.ValidationGroup = "";
                cmpCadPricePartNineteen.ValidationGroup = "";

                rfvUsdPricePartTwenty.ValidationGroup = "";
                rfvCadPricePartTwenty.ValidationGroup = "";
                cmpUsdPricePartTwenty.ValidationGroup = "";
                cmpCadPricePartTwenty.ValidationGroup = "";

                rfvUsdPricePartTwentyOne.ValidationGroup = "";
                rfvCadPricePartTwentyOne.ValidationGroup = "";
                cmpUsdPricePartTwentyOne.ValidationGroup = "";
                cmpCadPricePartTwentyOne.ValidationGroup = "";

                rfvUsdPricePartTwentyTwo.ValidationGroup = "";
                rfvCadPricePartTwentyTwo.ValidationGroup = "";
                cmpUsdPricePartTwentyTwo.ValidationGroup = "";
                cmpCadPricePartTwentyTwo.ValidationGroup = "";

                rfvUsdPricePartTwentyThree.ValidationGroup = "";
                rfvCadPricePartTwentyThree.ValidationGroup = "";
                cmpUsdPricePartTwentyThree.ValidationGroup = "";
                cmpCadPricePartTwentyThree.ValidationGroup = "";
                #endregion

                lblSchemPartNum.CssClass = "lblProduct";
                lblSchemPartKey.CssClass = "lblProduct";
                lblSchemPartKeyNum.CssClass = "lblProduct";
                lblSchemPartName.CssClass = "lblProduct";
                pnlPricingSchematics.CssClass = "pnlPricing";
                #region RemoveElements
                rowPart1.CssClass = "removeElement";
                rowPart1Val.CssClass = "removeElement";
                rowPart2.CssClass = "removeElement";
                rowPart2Val.CssClass = "removeElement";
                rowPart3.CssClass = "removeElement";
                rowPart3Val.CssClass = "removeElement";
                rowPart4.CssClass = "removeElement";
                rowPart4Val.CssClass = "removeElement";
                rowPart5.CssClass = "removeElement";
                rowPart5Val.CssClass = "removeElement";
                rowPart6.CssClass = "removeElement";
                rowPart6Val.CssClass = "removeElement";
                rowPart7.CssClass = "removeElement";
                rowPart7Val.CssClass = "removeElement";
                rowPart8.CssClass = "removeElement";
                rowPart8Val.CssClass = "removeElement";
                rowPart9.CssClass = "removeElement";
                rowPart9Val.CssClass = "removeElement";
                rowPart10.CssClass = "removeElement";
                rowPart10Val.CssClass = "removeElement";
                rowPart11.CssClass = "removeElement";
                rowPart11Val.CssClass = "removeElement";
                rowPart12.CssClass = "removeElement";
                rowPart12Val.CssClass = "removeElement";
                rowPart13.CssClass = "removeElement";
                rowPart13Val.CssClass = "removeElement";
                rowPart14.CssClass = "removeElement";
                rowPart14Val.CssClass = "removeElement";
                rowPart15.CssClass = "removeElement";
                rowPart15Val.CssClass = "removeElement";
                rowPart16.CssClass = "removeElement";
                rowPart16Val.CssClass = "removeElement";
                rowPart17.CssClass = "removeElement";
                rowPart17Val.CssClass = "removeElement";
                rowPart18.CssClass = "removeElement";
                rowPart18Val.CssClass = "removeElement";
                rowPart19.CssClass = "removeElement";
                rowPart19Val.CssClass = "removeElement";
                rowPart20.CssClass = "removeElement";
                rowPart20Val.CssClass = "removeElement";
                rowPart21.CssClass = "removeElement";
                rowPart21Val.CssClass = "removeElement";
                rowPart22.CssClass = "removeElement";
                rowPart22Val.CssClass = "removeElement";
                rowPart23.CssClass = "removeElement";
                rowPart23Val.CssClass = "removeElement";
                #endregion

                Part aPart = new Part();
                aPart.Populate(aPart.SelectAll(datUpdateDataSource, ddlSchem.SelectedValue, Session["partNumber"].ToString()));
                Session.Add("part", aPart);

                imgPart.ImageUrl = "Images/catalogue/" + Session["partNumber"].ToString() + "-" + aPart.PartNumber.ToString() + "-" + aPart.PartKeyNumber.ToString() + ".jpg";

                if (aPart.PartKeyNumber == 1)
                {
                    rowPart1.CssClass = "trPriceSchem";
                    rowPart1Val.CssClass = "trPriceSchem";
                    txtUsdPricePartOne.Text = aPart.PartUsdPrice.ToString("N2");
                    txtCadPricePartOne.Text = aPart.PartCadPrice.ToString("N2");
                    rfvUsdPricePartOne.ValidationGroup = "pricing";
                    rfvCadPricePartOne.ValidationGroup = "pricing";
                    cmpUsdPricePartOne.ValidationGroup = "pricing";
                    cmpCadPricePartOne.ValidationGroup = "pricing";
                }
                else if (aPart.PartKeyNumber == 2)
                {
                    rowPart2.CssClass = "trPriceSchem";
                    rowPart2Val.CssClass = "trPriceSchem";
                    txtUsdPricePartTwo.Text = aPart.PartUsdPrice.ToString("N2");
                    txtCadPricePartTwo.Text = aPart.PartCadPrice.ToString("N2");
                    rfvUsdPricePartTwo.ValidationGroup = "pricing";
                    rfvCadPricePartTwo.ValidationGroup = "pricing";
                    cmpUsdPricePartTwo.ValidationGroup = "pricing";
                    cmpCadPricePartTwo.ValidationGroup = "pricing";
                }
                else if (aPart.PartKeyNumber == 3)
                {
                    rowPart3.CssClass = "trPriceSchem";
                    rowPart3Val.CssClass = "trPriceSchem";
                    txtUsdPricePartThree.Text = aPart.PartUsdPrice.ToString("N2");
                    txtCadPricePartThree.Text = aPart.PartCadPrice.ToString("N2");
                    rfvUsdPricePartThree.ValidationGroup = "pricing";
                    rfvCadPricePartThree.ValidationGroup = "pricing";
                    cmpUsdPricePartThree.ValidationGroup = "pricing";
                    cmpCadPricePartThree.ValidationGroup = "pricing";
                }
                else if (aPart.PartKeyNumber == 4)
                {
                    rowPart4.CssClass = "trPriceSchem";
                    rowPart4Val.CssClass = "trPriceSchem";
                    txtUsdPricePartFour.Text = aPart.PartUsdPrice.ToString("N2");
                    txtCadPricePartFour.Text = aPart.PartCadPrice.ToString("N2");
                    rfvUsdPricePartFour.ValidationGroup = "pricing";
                    rfvCadPricePartFour.ValidationGroup = "pricing";
                    cmpUsdPricePartFour.ValidationGroup = "pricing";
                    cmpCadPricePartFour.ValidationGroup = "pricing";
                }
                else if (aPart.PartKeyNumber == 5)
                {
                    rowPart5.CssClass = "trPriceSchem";
                    rowPart5Val.CssClass = "trPriceSchem";
                    txtUsdPricePartFive.Text = aPart.PartUsdPrice.ToString("N2");
                    txtCadPricePartFive.Text = aPart.PartCadPrice.ToString("N2");
                    rfvUsdPricePartFive.ValidationGroup = "pricing";
                    rfvCadPricePartFive.ValidationGroup = "pricing";
                    cmpUsdPricePartFive.ValidationGroup = "pricing";
                    cmpCadPricePartFive.ValidationGroup = "pricing";
                }
                else if (aPart.PartKeyNumber == 6)
                {
                    rowPart6.CssClass = "trPriceSchem";
                    rowPart6Val.CssClass = "trPriceSchem";
                    txtUsdPricePartSix.Text = aPart.PartUsdPrice.ToString("N2");
                    txtCadPricePartSix.Text = aPart.PartCadPrice.ToString("N2");
                    rfvUsdPricePartSix.ValidationGroup = "pricing";
                    rfvCadPricePartSix.ValidationGroup = "pricing";
                    cmpUsdPricePartSix.ValidationGroup = "pricing";
                    cmpCadPricePartSix.ValidationGroup = "pricing";
                }
                else if (aPart.PartKeyNumber == 7)
                {
                    rowPart7.CssClass = "trPriceSchem";
                    rowPart7Val.CssClass = "trPriceSchem";
                    txtUsdPricePartSeven.Text = aPart.PartUsdPrice.ToString("N2");
                    txtCadPricePartSeven.Text = aPart.PartCadPrice.ToString("N2");
                    rfvUsdPricePartSeven.ValidationGroup = "pricing";
                    rfvCadPricePartSeven.ValidationGroup = "pricing";
                    cmpUsdPricePartSeven.ValidationGroup = "pricing";
                    cmpCadPricePartSeven.ValidationGroup = "pricing";
                }
                else if (aPart.PartKeyNumber == 8)
                {
                    rowPart8.CssClass = "trPriceSchem";
                    rowPart8Val.CssClass = "trPriceSchem";
                    txtUsdPricePartEight.Text = aPart.PartUsdPrice.ToString("N2");
                    txtCadPricePartEight.Text = aPart.PartCadPrice.ToString("N2");
                    rfvUsdPricePartEight.ValidationGroup = "pricing";
                    rfvCadPricePartEight.ValidationGroup = "pricing";
                    cmpUsdPricePartEight.ValidationGroup = "pricing";
                    cmpCadPricePartEight.ValidationGroup = "pricing";
                }
                else if (aPart.PartKeyNumber == 9)
                {
                    rowPart9.CssClass = "trPriceSchem";
                    rowPart9Val.CssClass = "trPriceSchem";
                    txtUsdPricePartNine.Text = aPart.PartUsdPrice.ToString("N2");
                    txtCadPricePartNine.Text = aPart.PartCadPrice.ToString("N2");
                    rfvUsdPricePartNine.ValidationGroup = "pricing";
                    rfvCadPricePartNine.ValidationGroup = "pricing";
                    cmpUsdPricePartNine.ValidationGroup = "pricing";
                    cmpCadPricePartNine.ValidationGroup = "pricing";
                }
                else if (aPart.PartKeyNumber == 10)
                {
                    rowPart10.CssClass = "trPriceSchem";
                    rowPart10Val.CssClass = "trPriceSchem";
                    txtUsdPricePartTen.Text = aPart.PartUsdPrice.ToString("N2");
                    txtCadPricePartTen.Text = aPart.PartCadPrice.ToString("N2");
                    rfvUsdPricePartTen.ValidationGroup = "pricing";
                    rfvCadPricePartTen.ValidationGroup = "pricing";
                    cmpUsdPricePartTen.ValidationGroup = "pricing";
                    cmpCadPricePartTen.ValidationGroup = "pricing";
                }
                else if (aPart.PartKeyNumber == 11)
                {
                    rowPart11.CssClass = "trPriceSchem";
                    rowPart12Val.CssClass = "trPriceSchem";
                    txtUsdPricePartEleven.Text = aPart.PartUsdPrice.ToString("N2");
                    txtCadPricePartEleven.Text = aPart.PartCadPrice.ToString("N2");
                    rfvUsdPricePartEleven.ValidationGroup = "pricing";
                    rfvCadPricePartEleven.ValidationGroup = "pricing";
                    cmpUsdPricePartEleven.ValidationGroup = "pricing";
                    cmpCadPricePartEleven.ValidationGroup = "pricing";
                }
                else if (aPart.PartKeyNumber == 12)
                {
                    rowPart12.CssClass = "trPriceSchem";
                    rowPart12Val.CssClass = "trPriceSchem";
                    txtUsdPricePartTwelve.Text = aPart.PartUsdPrice.ToString("N2");
                    txtCadPricePartTwelve.Text = aPart.PartCadPrice.ToString("N2");
                    rfvUsdPricePartTwelve.ValidationGroup = "pricing";
                    rfvCadPricePartTwelve.ValidationGroup = "pricing";
                    cmpUsdPricePartTwelve.ValidationGroup = "pricing";
                    cmpCadPricePartTwelve.ValidationGroup = "pricing";
                }
                else if (aPart.PartKeyNumber == 13)
                {
                    rowPart13.CssClass = "trPriceSchem";
                    rowPart13Val.CssClass = "trPriceSchem";
                    txtUsdPricePartThirteen.Text = aPart.PartUsdPrice.ToString("N2");
                    txtCadPricePartThirteen.Text = aPart.PartCadPrice.ToString("N2");
                    rfvUsdPricePartThirteen.ValidationGroup = "pricing";
                    rfvCadPricePartThirteen.ValidationGroup = "pricing";
                    cmpUsdPricePartThirteen.ValidationGroup = "pricing";
                    cmpCadPricePartThirteen.ValidationGroup = "pricing";
                }
                else if (aPart.PartKeyNumber == 14)
                {
                    rowPart14.CssClass = "trPriceSchem";
                    rowPart14Val.CssClass = "trPriceSchem";
                    txtUsdPricePartFourteen.Text = aPart.PartUsdPrice.ToString("N2");
                    txtCadPricePartFourteen.Text = aPart.PartCadPrice.ToString("N2");
                    rfvUsdPricePartFourteen.ValidationGroup = "pricing";
                    rfvCadPricePartFourteen.ValidationGroup = "pricing";
                    cmpUsdPricePartFourteen.ValidationGroup = "pricing";
                    cmpCadPricePartFourteen.ValidationGroup = "pricing";
                }
                else if (aPart.PartKeyNumber == 15)
                {
                    rowPart15.CssClass = "trPriceSchem";
                    rowPart15Val.CssClass = "trPriceSchem";
                    txtUsdPricePartFifteen.Text = aPart.PartUsdPrice.ToString("N2");
                    txtCadPricePartFifteen.Text = aPart.PartCadPrice.ToString("N2");
                    rfvUsdPricePartFifteen.ValidationGroup = "pricing";
                    rfvCadPricePartFifteen.ValidationGroup = "pricing";
                    cmpUsdPricePartFifteen.ValidationGroup = "pricing";
                    cmpCadPricePartFifteen.ValidationGroup = "pricing";
                }
                else if (aPart.PartKeyNumber == 16)
                {
                    rowPart16.CssClass = "trPriceSchem";
                    rowPart16Val.CssClass = "trPriceSchem";
                    txtUsdPricePartSixteen.Text = aPart.PartUsdPrice.ToString("N2");
                    txtCadPricePartSixteen.Text = aPart.PartCadPrice.ToString("N2");
                    rfvUsdPricePartSixteen.ValidationGroup = "pricing";
                    rfvCadPricePartSixteen.ValidationGroup = "pricing";
                    cmpUsdPricePartSixteen.ValidationGroup = "pricing";
                    cmpCadPricePartSixteen.ValidationGroup = "pricing";
                }
                else if (aPart.PartKeyNumber == 17)
                {
                    rowPart17.CssClass = "trPriceSchem";
                    rowPart17Val.CssClass = "trPriceSchem";
                    txtUsdPricePartSeventeen.Text = aPart.PartUsdPrice.ToString("N2");
                    txtCadPricePartSeventeen.Text = aPart.PartCadPrice.ToString("N2");
                    rfvUsdPricePartSeventeen.ValidationGroup = "pricing";
                    rfvCadPricePartSeventeen.ValidationGroup = "pricing";
                    cmpUsdPricePartSeventeen.ValidationGroup = "pricing";
                    cmpCadPricePartSeventeen.ValidationGroup = "pricing";
                }
                else if (aPart.PartKeyNumber == 18)
                {
                    rowPart18.CssClass = "trPriceSchem";
                    rowPart18Val.CssClass = "trPriceSchem";
                    txtUsdPricePartEighteen.Text = aPart.PartUsdPrice.ToString("N2");
                    txtCadPricePartEighteen.Text = aPart.PartCadPrice.ToString("N2");
                    rfvUsdPricePartEighteen.ValidationGroup = "pricing";
                    rfvCadPricePartEighteen.ValidationGroup = "pricing";
                    cmpUsdPricePartEighteen.ValidationGroup = "pricing";
                    cmpCadPricePartEighteen.ValidationGroup = "pricing";
                }
                else if (aPart.PartKeyNumber == 19)
                {
                    rowPart19.CssClass = "trPriceSchem";
                    rowPart19Val.CssClass = "trPriceSchem";
                    txtUsdPricePartNineteen.Text = aPart.PartUsdPrice.ToString("N2");
                    txtCadPricePartNineteen.Text = aPart.PartCadPrice.ToString("N2");
                    rfvUsdPricePartNineteen.ValidationGroup = "pricing";
                    rfvCadPricePartNineteen.ValidationGroup = "pricing";
                    cmpUsdPricePartNineteen.ValidationGroup = "pricing";
                    cmpCadPricePartNineteen.ValidationGroup = "pricing";
                }
                else if (aPart.PartKeyNumber == 20)
                {
                    rowPart20.CssClass = "trPriceSchem";
                    rowPart20Val.CssClass = "trPriceSchem";
                    txtUsdPricePartTwenty.Text = aPart.PartUsdPrice.ToString("N2");
                    txtCadPricePartTwenty.Text = aPart.PartCadPrice.ToString("N2");
                    rfvUsdPricePartTwenty.ValidationGroup = "pricing";
                    rfvCadPricePartTwenty.ValidationGroup = "pricing";
                    cmpUsdPricePartTwenty.ValidationGroup = "pricing";
                    cmpCadPricePartTwenty.ValidationGroup = "pricing";
                }
                else if (aPart.PartKeyNumber == 21)
                {
                    rowPart21.CssClass = "trPriceSchem";
                    rowPart21Val.CssClass = "trPriceSchem";
                    txtUsdPricePartTwentyOne.Text = aPart.PartUsdPrice.ToString("N2");
                    txtCadPricePartTwentyOne.Text = aPart.PartCadPrice.ToString("N2");
                    rfvUsdPricePartTwentyOne.ValidationGroup = "pricing";
                    rfvCadPricePartTwentyOne.ValidationGroup = "pricing";
                    cmpUsdPricePartTwentyOne.ValidationGroup = "pricing";
                    cmpCadPricePartTwentyOne.ValidationGroup = "pricing";
                }
                else if (aPart.PartKeyNumber == 22)
                {
                    rowPart22.CssClass = "trPriceSchem";
                    rowPart22Val.CssClass = "trPriceSchem";
                    txtUsdPricePartTwentyTwo.Text = aPart.PartUsdPrice.ToString("N2");
                    txtCadPricePartTwentyTwo.Text = aPart.PartCadPrice.ToString("N2");
                    rfvUsdPricePartTwentyTwo.ValidationGroup = "pricing";
                    rfvCadPricePartTwentyTwo.ValidationGroup = "pricing";
                    cmpUsdPricePartTwentyTwo.ValidationGroup = "pricing";
                    cmpCadPricePartTwentyTwo.ValidationGroup = "pricing";
                }
                else if (aPart.PartKeyNumber == 23)
                {
                    rowPart23.CssClass = "trPriceSchem";
                    rowPart23Val.CssClass = "trPriceSchem";
                    txtUsdPricePartTwentyThree.Text = aPart.PartUsdPrice.ToString("N2");
                    txtCadPricePartTwentyThree.Text = aPart.PartCadPrice.ToString("N2");
                    rfvUsdPricePartTwentyThree.ValidationGroup = "pricing";
                    rfvCadPricePartTwentyThree.ValidationGroup = "pricing";
                    cmpUsdPricePartTwentyThree.ValidationGroup = "pricing";
                    cmpCadPricePartTwentyThree.ValidationGroup = "pricing";
                }

                lblSchemPartNum.Text = aPart.PartNumber.ToString();
                lblSchemPartKeyNum.Text = aPart.PartKeyNumber.ToString();
                lblSchemPartName.Text = aPart.PartName.ToString();
            }
        }

        protected void btnMainMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainMenu.aspx"); 
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCategory.SelectedValue != "")
            {
                //get table name selected
                string tableName = "tbl" + ddlCategory.SelectedValue.Replace(" ", "");

                //display second dropdown
                ddlPart.CssClass = "ddlField";

                //set up a dataview object to hold part numbers for the second drop down
                System.Data.DataView partsList = new System.Data.DataView();

                if (Session["partsList"] != null)
                {
                    Session["partsList"] = partsList;
                }
                else
                {
                    Session.Add("partsList", partsList);
                }

                if (tableName != "tblSchematics")
                {
                    //select part numbers
                    datSelectDataSource.SelectCommand = "SELECT partNumber, partName FROM " + tableName + " ORDER BY partNumber ASC";
                }
                else
                {
                    datSelectDataSource.SelectCommand = "SELECT schematicNumber, partName FROM " + tableName + " ORDER BY schematicNumber ASC";
                }
                //assign the table names to the dataview object
                partsList = (System.Data.DataView)datSelectDataSource.Select(System.Web.UI.DataSourceSelectArguments.Empty);

                //variable to determine amount of rows in the dataview object
                int rowCount = partsList.Count;

                //clear second drop down
                ddlPart.Items.Clear();

                //Insert empty string to first row of second drop down
                ddlPart.Items.Add("");

                //populate second drop down
                for (int i = 0; i < rowCount; i++)
                {
                    ddlPart.Items.Add(partsList[i][0].ToString() + " (" + partsList[i][1].ToString() + ")");
                }

                Session.Add("tableName", tableName);
                if (Session["categoryIndex"] != null)
                {
                    Session["categoryIndex"] = ddlCategory.SelectedIndex;
                }
                else
                {
                    Session.Add("categoryIndex", ddlCategory.SelectedIndex);
                }

                ddlPart.SelectedIndex = 1;
                ddlPart_SelectedIndexChanged(sender, e);
            }
        }

        protected void ddlPart_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPart.SelectedValue != "")
            {
                //get part number selected
                string referenceString = "";
                foreach (char character in ddlPart.SelectedValue)
                {
                    if (character.ToString() == " ")
                    {
                        break;
                    }
                    referenceString += character;
                }
                string partNumber = referenceString.Trim();

                //display go button

                //update part number in session
                Session["partNumber"] = partNumber;

                if (Session["partIndex"] != null)
                {
                    Session["partIndex"] = ddlPart.SelectedIndex;
                }
                else
                {
                    Session.Add("partIndex", ddlPart.SelectedIndex);
                }
            }

            Session.Add("updateChanged", "true");
            Response.Redirect("update.aspx"); //post
        }

        protected void imgPrevArrow_Click(object sender, EventArgs e)
        {
            //remove 1 from current index to get previous product
            Session["partIndex"] = (int)Session["partIndex"] - 1;
            string oldString = ddlPart.Items[(int)Session["partIndex"]].Value;
            string newString = "";
            foreach (char character in oldString)
            {
                if (character.ToString() == " ")
                {
                    break;
                }
                newString += character;
            }
            //find partnumber at previous product to update info on page
            Session["partNumber"] = newString;
            //let page know it has to update info
            Session.Add("updateChanged", "true");
            Response.Redirect("update.aspx"); //post
        }

        protected void imgNextArrow_Click(object sender, EventArgs e)
        {
            //remove 1 from current index to get previous product
            Session["partIndex"] = (int)Session["partIndex"] + 1;
            string oldString = ddlPart.Items[(int)Session["partIndex"]].Value;
            string newString = "";
            foreach (char character in oldString)
            {
                if (character.ToString() == " ")
                {
                    break;
                }
                newString += character;
            }
            //find partnumber at previous product to update info on page
            Session["partNumber"] = newString;
            //let page know it has to update info
            Session.Add("updateChanged", "true");
            Response.Redirect("update.aspx"); //post
        }

        protected void btnUploadImg_Click(object sender, EventArgs e)
        {            
            if (Page.IsPostBack)
            {
                if (fupNewImage.HasFile)
                {
                    if (fupNewImage.PostedFile.ContentType == "image/jpeg" || fupNewImage.PostedFile.ContentType == "image/png")
                    {
                        fupNewImage.SaveAs(System.IO.Path.Combine(Server.MapPath("Images/catalogue/" + Session["partNumber"].ToString() + ".jpg")));
                        imgPart.ImageUrl = "Images/catalogue/" + Session["partNumber"].ToString() + ".jpg";
                        Session.Add("updateChanged", "true");
                        Session.Add("picChanged", true);
                        valFupNewImage.Text = "Click your browser refresh button to view the updated image.";
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
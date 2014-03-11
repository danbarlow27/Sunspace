using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SunspaceDealerDesktop
{
    public partial class Display : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label firstLabel = (Label)Master.FindControl("lblUpdate");
            if (firstLabel != null)
            {
                firstLabel.Text = "VIEWING";
            }

            Label secondLabel = (Label)Master.FindControl("lblPartNumTitle");
            if (secondLabel != null)
            {
                secondLabel.Text = Session["partNumber"].ToString();
            }

            if (Session["updateSelected"] != null)
            {
                btnInsert.CssClass = "removeElement";
            }

            if (Session["user_type"].ToString() != "S")
            {
                btnUpdate.Visible = false;
                btnInsert.Visible = false;
            }

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
                    Session.Add("UpdatePartList", "true");
                    //set up a dataview object to hold table names for the first drop down
                    System.Data.DataView tableList = new System.Data.DataView();

                    //select table names
                    datSelectDataSource.SelectCommand = "SELECT name FROM sys.tables WHERE name != 'tblColor' AND name != 'tblSchematicParts' AND name != 'tblParts' "
                                                        + " AND name != 'tblLengthUnits'  AND name != 'tblAudits' AND name != 'tblSalesOrders' AND name != 'tblSalesOrderItems' "
                                                        + " AND SUBSTRING(name,1,3) = 'tbl' "
                                                        + "ORDER BY name ASC";                    //assign the table names to the dataview object
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

                        
                        Session.Add("displayChanged", "true");
                    }
                }

                //only run if the display has changed, to allow display postback changes
                if (Session["displayChanged"] != null)
                {
                    //we're running this, so the display has been updated, and is not set for change
                    Session.Remove("displayChanged");
                    //select part dropdown default value             
                    ddlPart.SelectedIndex = (int)Session["partIndex"];

                    //show navigation arrows
                    imgPrevArrow.CssClass = "prevArrow";
                    imgNextArrow.CssClass = "nextArrow";

                    if (ddlPart.SelectedIndex == (ddlPart.Items.Count-1))
                    {
                        //if last item, don't show 'next' arrow
                        imgNextArrow.CssClass = "removeElement";
                    }
                    else if (ddlPart.SelectedIndex == 1)
                    {
                        //if first item, don't show 'prev' arrow
                        imgPrevArrow.CssClass = "removeElement";
                    }
                
                    //load appropriate image
                    imgPart.ImageUrl = "Images/catalogue/" + Session["partNumber"].ToString() + ".jpg";
                    imgPartLink.NavigateUrl = "Images/catalogue/" + Session["partNumber"].ToString() + ".jpg";
                    //remove all non-product panels, whichw ill be shown on switch case below
                    pnlAccessories.CssClass = "removeElement";
                    pnlDecorativeColumn.CssClass = "removeElement";
                    pnlDoorFrameExtrusions.CssClass = "removeElement";
                    pnlInsulatedFloors.CssClass = "removeElement";
                    pnlRoofExtrusions.CssClass = "removeElement";
                    pnlRoofPanels.CssClass = "removeElement";
                    pnlScreenRoll.CssClass = "removeElement";
                    pnlSuncrylicRoof.CssClass = "removeElement";
                    pnlSunrail1000.CssClass = "removeElement";
                    pnlSunrail300.CssClass = "removeElement";
                    pnlSunrail400.CssClass = "removeElement";
                    pnlVinylRoll.CssClass = "removeElement";
                    pnlWallExtrusions.CssClass = "removeElement";
                    pnlWallPanel.CssClass = "removeElement";
                    pnlSchematicsDisplay.CssClass = "removeElement";

                    //Uncomment for checks with login
                    /*
                    if (Session["loggedCountry"] == null)
                    {
                        pnlPriceDisplay.CssClass = "removeElement";
                    }
                    else if (Session["loggedCountry"] == "US")
                    {
                        rowCadPrice.CssClass = "removeElement";
                    }
                    else
                    {
                        rowUsdPrice.CssClass = "removeElement";
                    }
                    */

                    //if value was changed on display page, we
                
                    string tableName = Session["tableName"].ToString();

                    switch (tableName)
                    {
                        #region Accessories
                        case "tblAccessories":
                            {
                                pnlAccessories.CssClass = "dimensionsTableDisplay";
                                rowLegend.CssClass = "removeElement";
                                rowComposition.CssClass = "removeElement";
                                rowStandard.CssClass = "removeElement";
                                lblPartName.Text = "Part Name:";
                                lblPartNum.Text = "Part Number:";
                                
                                Accessories anAccessory = new Accessories();

                                //call select all function to populate object
                                anAccessory.Populate(anAccessory.SelectAll(datDisplayDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString()));

                                txtPartNum.Text = anAccessory.AccessoryNumber;
                                txtPartName.Text = anAccessory.AccessoryName;
                                txtPartDesc.Text = anAccessory.AccessoryDescription;
                                txtColor.Text = anAccessory.AccessoryColor;
                                txtPackQuantity.Text = anAccessory.AccessoryPackQuantity.ToString();
                                txtAccessorySize.Text = anAccessory.AccessorySize.ToString() + " " + anAccessory.AccessorySizeUnits;
                                txtAccessoryWidth.Text = anAccessory.AccessoryWidth.ToString() + " " + anAccessory.AccessoryWidthUnits;
                                txtAccessoryLength.Text = anAccessory.AccessoryLength.ToString() + " " + anAccessory.AccessoryLengthUnits;

                                if (txtPackQuantity.Text == "0" || txtPackQuantity.Text == "")
                                {
                                    rowPackQuantity.CssClass = "removeElement";
                                }

                                if (anAccessory.AccessorySize == 0)//a space is added above, so check for one space, not blank
                                {
                                    rowAccessorySize.CssClass = "removeElement";
                                }

                                if (anAccessory.AccessoryLength == 0)
                                {
                                    rowAccessoryMaxLength.CssClass = "removeElement";
                                }

                                if (anAccessory.AccessoryWidth == 0)
                                {
                                    rowAccessoryMaxWidth.CssClass = "removeElement";
                                }

                                if (txtColor.Text == "")
                                {
                                    rowColor.CssClass = "removeElement";
                                }

                                txtUsdPrice.Text = anAccessory.AccessoryUsdPrice.ToString("N2");
                                txtCadPrice.Text = anAccessory.AccessoryCadPrice.ToString("N2");

                                break;
                            }
                        #endregion
                        #region DecorativeColumn
                        case "tblDecorativeColumn":
                            {
                                pnlDecorativeColumn.CssClass = "dimensionsTableDisplay";
                                rowLegend.CssClass = "removeElement";
                                rowComposition.CssClass = "removeElement";
                                rowStandard.CssClass = "removeElement";
                                rowPackQuantity.CssClass = "removeElement";

                                DecorativeColumn aColumn = new DecorativeColumn();

                                //call select all function to populate object
                                aColumn.Populate(aColumn.SelectAll(datDisplayDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString()));

                                txtPartName.Text = aColumn.ColumnName;
                                txtPartDesc.Text = aColumn.ColumnDescription;
                                txtPartNum.Text = aColumn.PartNumber;
                                txtColor.Text = aColumn.ColumnColor;
                                txtDecColLength.Text = aColumn.ColumnLength.ToString() + " " + aColumn.ColumnLengthUnits;

                                txtUsdPrice.Text = aColumn.ColumnUsdPrice.ToString("N2");
                                txtCadPrice.Text = aColumn.ColumnCadPrice.ToString("N2");

                                break;
                            }
                        #endregion
                        #region Door Frame Extrusion
                        case "tblDoorFrameExtrusion":
                            {
                                pnlDoorFrameExtrusions.CssClass = "dimensionsTableDisplay";
                                rowLegend.CssClass = "removeElement";
                                rowComposition.CssClass = "removeElement";
                                rowStandard.CssClass = "removeElement";
                                rowPackQuantity.CssClass = "removeElement";

                                DoorFrameExtrusion aFrameExtrusion = new DoorFrameExtrusion();

                                //call select all function to populate object
                                aFrameExtrusion.Populate(aFrameExtrusion.SelectAll(datDisplayDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString()));

                                txtPartName.Text = aFrameExtrusion.DfeName;
                                if (aFrameExtrusion.DfeDescription != "")
                                {
                                    txtPartDesc.Text = aFrameExtrusion.DfeDescription;
                                }
                                else
                                {
                                    rowDescription.CssClass = "removeElement";
                                }
                                txtPartNum.Text = aFrameExtrusion.PartNumber;
                                txtColor.Text = aFrameExtrusion.DfeColor;
                                txtDoorFrExtMaxLength.Text = aFrameExtrusion.DfeMaxLength.ToString() + " " + aFrameExtrusion.DfeMaxLengthUnits;

                                txtUsdPrice.Text = aFrameExtrusion.UsdPrice.ToString("N2");
                                txtCadPrice.Text = aFrameExtrusion.CadPrice.ToString("N2");

                                break;
                            }
                        #endregion
                        #region InsulatedFloors
                        case "tblInsulatedFloors":
                            {
                                pnlInsulatedFloors.CssClass = "dimensionsTableDisplay";
                                rowLegend.CssClass = "removeElement";
                                rowStandard.CssClass = "removeElement";
                                rowPackQuantity.CssClass = "removeElement";
                                rowColor.CssClass = "removeElement";

                                InsulatedFloors aFloor = new InsulatedFloors();

                                //call select all function to populate object
                                aFloor.Populate(aFloor.SelectAll(datDisplayDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString()));

                                txtPartName.Text = aFloor.InsulatedFloorName;
                                txtPartDesc.Text = aFloor.InsulatedFloorDescription;
                                txtPartNum.Text = aFloor.PartNumber;
                                txtInsFloorSize.Text = aFloor.InsulatedFloorSize.ToString() + " " + aFloor.InsulatedFloorSizeUnits;
                                txtInsFloorMaxWidth.Text = aFloor.InsulatedFloorMaxWidth.ToString() + " " + aFloor.InsulatedFloorMaxWidthUnits;
                                txtInsFloorMaxLength.Text = aFloor.InsulatedFloorMaxLength.ToString();

                                txtUsdPrice.Text = aFloor.InsulatedFloorUsdPrice.ToString("N2");
                                txtCadPrice.Text = aFloor.InsulatedFloorCadPrice.ToString("N2");

                                break;
                            }
                        #endregion
                        #region RoofPanels
                        case "tblRoofPanels":
                            {
                                pnlRoofPanels.CssClass = "dimensionsTableDisplay";
                                rowLegend.CssClass = "removeElement";
                                rowPackQuantity.CssClass = "removeElement";

                                RoofPanels aRoofPanel = new RoofPanels();

                                //call select all function to populate object
                                aRoofPanel.Populate(aRoofPanel.SelectAll(datDisplayDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString()));

                                txtPartName.Text = aRoofPanel.PanelName;
                                txtPartDesc.Text = aRoofPanel.PanelDescription;
                                txtPartNum.Text = aRoofPanel.PartNumber;
                                txtComposition.Text = aRoofPanel.PanelComposition;
                                txtStandard.Text = aRoofPanel.PanelStandard;




                                txtColor.Text = aRoofPanel.PanelColor;
                                txtRoofPnlSize.Text = aRoofPanel.PanelSize.ToString() + " " + aRoofPanel.PanelSizeUnits;
                                txtRoofPnlMaxWidth.Text = aRoofPanel.PanelMaxWidth.ToString() + " " + aRoofPanel.MaxWidthUnits;
                                txtRoofPnlMaxLength.Text = aRoofPanel.PanelMaxLength;

                                txtUsdPrice.Text = aRoofPanel.UsdPrice.ToString("N2");
                                txtCadPrice.Text = aRoofPanel.CadPrice.ToString("N2");

                                break;
                            }
                        #endregion
                        #region Schematics
                        case "tblSchematics":
                            {
                                pnlSchematicsDisplay.CssClass = "schematicsTableDisplay";
                                rowComposition.CssClass = "removeElement";
                                rowStandard.CssClass = "removeElement";
                                rowPackQuantity.CssClass = "removeElement";
                                rowColor.CssClass = "removeElement";
                                lblLegend.Text = "Legend:";
                                Schematics aSchematic = new Schematics();
                                Part aPart = new Part();

                                //call select all function to populate object
                                aSchematic.Populate(aSchematic.SelectAll(datDisplayDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString()));
                                
                                txtPartNum.Text = aSchematic.SchematicNumber;

                                if (Session["UpdatePartList"].ToString() == "true" || !Page.IsPostBack)
                                {
                                    UpdatePartsList();
                                    Session.Remove("UpdatePartList");
                                }

                                if (Session["part"] != null)
                                {
                                    aPart = (Part)Session["part"];
                                    txtSchemPartKey.Text = aPart.PartKeyNumber.ToString();
                                    txtSchemPartName.Text = aPart.PartName;
                                    txtSchemPartNum.Text = aPart.PartNumber;
                                }
                                else
                                {
                                    txtSchemPartKey.Text = "";
                                    txtSchemPartName.Text = "";
                                    txtSchemPartNum.Text = "";
                                }              

                                lblPartName.Text = "Schematic Name:";
                                txtPartName.Text = aSchematic.SchematicName.ToString();
                                txtPartDesc.Text = aSchematic.SchematicDescription.ToString();
                                lblPartNum.Text = "Schematic Number:";
                                txtPartNum.Text = aSchematic.SchematicNumber.ToString();

                                if (txtPartDesc.Text == "")
                                {
                                    txtPartDesc.Text = "No Description";
                                }

                                txtUsdPrice.Text = aSchematic.SchematicUsdPrice.ToString("N2");
                                txtCadPrice.Text = aSchematic.SchematicCadPrice.ToString("N2");

                                break;
                            }
                        #endregion
                        #region Screen Roll
                        case "tblScreenRoll":
                            {
                                pnlScreenRoll.CssClass = "dimensionsTableDisplay";
                                rowLegend.CssClass = "removeElement";
                                rowDescription.CssClass = "removeElement";
                                rowComposition.CssClass = "removeElement";
                                rowStandard.CssClass = "removeElement";
                                rowPackQuantity.CssClass = "removeElement";
                                rowColor.CssClass = "removeElement";

                                ScreenRoll aScreenRoll = new ScreenRoll();

                                //call select all function to populate object
                                aScreenRoll.Populate(aScreenRoll.SelectAll(datDisplayDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString()));

                                txtPartName.Text = aScreenRoll.ScreenRollName;
                                txtPartNum.Text = aScreenRoll.PartNumber;
                                txtScreenRollWidth.Text = aScreenRoll.ScreenRollWidth + " " + aScreenRoll.ScreenRollWidthUnits;
                                txtScreenRollLength.Text = aScreenRoll.ScreenRollLength + " " + aScreenRoll.ScreenRollLengthUnits;

                                txtUsdPrice.Text = aScreenRoll.UsdPrice.ToString("N2");
                                txtCadPrice.Text = aScreenRoll.CadPrice.ToString("N2");

                                break;
                            }
                        #endregion
                        #region Suncrylic Roof
                        case "tblSuncrylicRoof":
                            {
                                pnlSuncrylicRoof.CssClass = "dimensionsTableDisplay";
                                rowLegend.CssClass = "removeElement";
                                rowComposition.CssClass = "removeElement";
                                rowStandard.CssClass = "removeElement";
                                rowPackQuantity.CssClass = "removeElement";

                                SuncrylicRoof aSuncrylicRoof = new SuncrylicRoof();

                                //call select all function to populate object
                                aSuncrylicRoof.Populate(aSuncrylicRoof.SelectAll(datDisplayDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString()));

                                txtPartName.Text = aSuncrylicRoof.SuncrylicName;
                                txtPartDesc.Text = aSuncrylicRoof.SuncrylicDescription;
                                txtPartNum.Text = aSuncrylicRoof.PartNumber;
                                txtColor.Text = aSuncrylicRoof.SuncrylicColor;
                                txtSunRoofMaxLength.Text = aSuncrylicRoof.SuncrylicMaxLength + " " + aSuncrylicRoof.SuncrylicLengthUnits;
                                txtSunRoofMaxWidthStr.Text = "Varies";

                                txtUsdPrice.Text = aSuncrylicRoof.UsdPrice.ToString("N2");
                                txtCadPrice.Text = aSuncrylicRoof.CadPrice.ToString("N2");

                                break;
                            }
                        #endregion

                        #region Sunrail1000
                        case "tblSunrail1000":
                        {
                            pnlSunrail1000.CssClass = "dimensionsTableDisplay";
                            rowLegend.CssClass = "removeElement";
                            rowComposition.CssClass = "removeElement";
                            rowStandard.CssClass = "removeElement";
                            rowPackQuantity.CssClass = "removeElement";

                            Sunrail1000 aSunrail = new Sunrail1000();

                            //call select all function to populate object
                            aSunrail.Populate(aSunrail.SelectAll(datDisplayDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString()));

                            txtPartName.Text = aSunrail.Sunrail1000Name;
                            txtPartDesc.Text = aSunrail.Sunrail1000Description;
                            txtPartNum.Text = aSunrail.PartNumber;
                            txtColor.Text = aSunrail.Sunrail1000Color;
                            txtSun1000MaxLength.Text = aSunrail.Sunrail1000MaxLengthFeet.ToString() + " " + aSunrail.Sunrail1000MaxLengthFeetUnits + " "
                                + aSunrail.Sunrail1000MaxLengthInches.ToString() + " " + aSunrail.Sunrail1000MaxLengthInchesUnits;

                            txtUsdPrice.Text = aSunrail.Sunrail1000UsdPrice.ToString("N2");
                            txtCadPrice.Text = aSunrail.Sunrail1000CadPrice.ToString("N2");

                            break;
                        }
                        #endregion
                    #region Sunrail300
                        case "tblSunrail300":
                        {
                            pnlSunrail300.CssClass = "dimensionsTableDisplay";
                            rowLegend.CssClass = "removeElement";
                            rowComposition.CssClass = "removeElement";
                            rowStandard.CssClass = "removeElement";
                            rowPackQuantity.CssClass = "removeElement";

                            Sunrail300 aSunrail300 = new Sunrail300();

                            //call select all function to populate object
                            aSunrail300.Populate(aSunrail300.SelectAll(datDisplayDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString()));
                     
                            txtPartName.Text = aSunrail300.Sunrail300Name;
                            txtPartDesc.Text = aSunrail300.Sunrail300Description;
                            txtPartNum.Text = aSunrail300.PartNumber;
                            txtColor.Text = aSunrail300.Sunrail300Color;
                            txtSun300MaxLength.Text = aSunrail300.Sunrail300MaxLengthFeet.ToString() + " " + aSunrail300.Sunrail300MaxLengthFeetUnits + " "
                                                        + aSunrail300.Sunrail300MaxLengthInches.ToString() + " " + aSunrail300.Sunrail300MaxLengthInchesUnits;

                            txtUsdPrice.Text = aSunrail300.Sunrail300UsdPrice.ToString("N2");
                            txtCadPrice.Text = aSunrail300.Sunrail300CadPrice.ToString("N2");

                            break;
                        }
                    #endregion
                    #region Sunrail300Accessories
                    case "tblSunrail300Accessories":
                        {
                            rowLegend.CssClass = "removeElement";
                            rowComposition.CssClass = "removeElement";
                            rowStandard.CssClass = "removeElement";
                            rowPackQuantity.CssClass = "removeElement";

                            Sunrail300Accessories aSunrail300Accessory = new Sunrail300Accessories();

                            //call select all function to populate object
                            aSunrail300Accessory.Populate(aSunrail300Accessory.SelectAll(datDisplayDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString()));
                     
                            txtPartName.Text = aSunrail300Accessory.Sunrail300AccessoriesName;
                            txtPartDesc.Text = aSunrail300Accessory.Sunrail300AccessoriesDescription;
                            txtPartNum.Text = aSunrail300Accessory.PartNumber;
                            txtColor.Text = aSunrail300Accessory.Sunrail300AccessoriesColor;

                            txtUsdPrice.Text = aSunrail300Accessory.Sunrail300AccessoriesUsdPrice.ToString("N2");
                            txtCadPrice.Text = aSunrail300Accessory.Sunrail300AccessoriesCadPrice.ToString("N2");

                            break;
                        }
                    #endregion
                    #region Sunrail400
                    case "tblSunrail400":
                        {
                            pnlSunrail400.CssClass = "dimensionsTableDisplay";
                            rowLegend.CssClass = "removeElement";
                            rowComposition.CssClass = "removeElement";
                            rowStandard.CssClass = "removeElement";
                            rowPackQuantity.CssClass = "removeElement";

                            Sunrail400 aSunrail400 = new Sunrail400();

                            //call select all function to populate object
                            aSunrail400.Populate(aSunrail400.SelectAll(datDisplayDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString()));
                     
                            txtPartName.Text = aSunrail400.Sunrail400Name;
                            txtPartDesc.Text = aSunrail400.Sunrail400Description;
                            txtPartNum.Text = aSunrail400.PartNumber;
                            txtColor.Text = aSunrail400.Sunrail400Color;
                            txtSun400MaxLength.Text = aSunrail400.Sunrail400MaxLengthFeet.ToString() + " " + aSunrail400.Sunrail400MaxLengthFeetUnits + " "
                                                        + aSunrail400.Sunrail400MaxLengthInches.ToString() + " " + aSunrail400.Sunrail400MaxLengthInchesUnits;

                            txtUsdPrice.Text = aSunrail400.Sunrail400UsdPrice.ToString("N2");
                            txtCadPrice.Text = aSunrail400.Sunrail400CadPrice.ToString("N2");

                            break;
                        }
                    #endregion
                    #region VinylRoll
                    case "tblVinylRoll":
                            {
                                pnlVinylRoll.CssClass = "dimensionsTableDisplay";
                                rowLegend.CssClass = "removeElement";
                                rowDescription.CssClass = "removeElement";
                                rowComposition.CssClass = "removeElement";
                                rowStandard.CssClass = "removeElement";
                                rowPackQuantity.CssClass = "removeElement";

                                rowVinylRollLength.CssClass = "removeElement";

                                VinylRoll aVinylRoll = new VinylRoll();

                                //call select all function to populate object
                                aVinylRoll.Populate(aVinylRoll.SelectAll(datDisplayDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString()));

                                txtPartName.Text = aVinylRoll.VinylRollName;
                                txtPartNum.Text = aVinylRoll.PartNumber;
                                txtColor.Text = aVinylRoll.VinylRollColor;
                                txtVinylRollWeight.Text = aVinylRoll.VinylRollWeight.ToString() + " " + aVinylRoll.VinylRollWeightUnits;
                                txtVinylRollWidth.Text = aVinylRoll.VinylRollWidth.ToString() + " " + aVinylRoll.VinylRollWidthUnits;


                                txtUsdPrice.Text = aVinylRoll.UsdPrice.ToString("N2");
                                txtCadPrice.Text = aVinylRoll.CadPrice.ToString("N2");

                                break;
                            }
                    #endregion
                    #region WallExtrusions
                    case "tblWallExtrusions":
                            {
                                pnlWallExtrusions.CssClass = "dimensionsTableDisplay";
                                rowLegend.CssClass = "removeElement";
                                rowComposition.CssClass = "removeElement";
                                rowStandard.CssClass = "removeElement";
                                rowPackQuantity.CssClass = "removeElement";

                                WallExtrusions aWallExtrusion = new WallExtrusions();

                                //call select all function to populate object
                                aWallExtrusion.Populate(aWallExtrusion.SelectAll(datDisplayDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString()));

                                txtPartName.Text = aWallExtrusion.WallExtrusionName;
                                txtPartDesc.Text = aWallExtrusion.WallExtrusionDescription;
                                txtPartNum.Text = aWallExtrusion.PartNumber;
                                txtColor.Text = aWallExtrusion.WallExtrusionColor;
                                txtWallExtMaxLength.Text = aWallExtrusion.WallExtrusionMaxLength.ToString() + " " + aWallExtrusion.LengthUnits;

                                txtUsdPrice.Text = aWallExtrusion.UsdPrice.ToString("N2");
                                txtCadPrice.Text = aWallExtrusion.CadPrice.ToString("N2");

                                break;
                            }
                        #endregion
                    #region WallPanels
                        case "tblWallPanels":
                            {
                                pnlWallPanel.CssClass = "dimensionsTableDisplay";
                                rowLegend.CssClass = "removeElement";
                                rowPackQuantity.CssClass = "removeElement";

                                WallPanels aWallPanel = new WallPanels();

                                //call select all function to populate object
                                aWallPanel.Populate(aWallPanel.SelectAll(datDisplayDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString()));

                                txtPartName.Text = aWallPanel.WallPanelName;
                                txtPartDesc.Text = aWallPanel.WallPanelDescription;
                                txtComposition.Text = aWallPanel.WallPanelComposition;
                                txtStandard.Text = aWallPanel.WallPanelStandard;
                                txtPartNum.Text = aWallPanel.WallPanelNumber;
                                txtColor.Text = aWallPanel.WallPanelColor;
                                txtWallPnlSize.Text = aWallPanel.WallPanelSize.ToString() + " " + aWallPanel.SizeUnits;
                                txtWallPnlMaxWidth.Text = aWallPanel.WallPanelMaxWidth.ToString() + " " + aWallPanel.WidthUnits;
                                txtWallPnlMaxLength.Text = aWallPanel.WallPanelMaxLength.ToString() + " " + aWallPanel.LengthUnits;
                                
                                
                                txtUsdPrice.Text = aWallPanel.UsdPrice.ToString("N2");
                                txtCadPrice.Text = aWallPanel.CadPrice.ToString("N2");

                                break;
                            }
                        #endregion
                    #region RoofExtrusions
                        case "tblRoofExtrusions":
                            {
                                rowLegend.CssClass = "removeElement";
                                rowComposition.CssClass = "removeElement";
                                rowStandard.CssClass = "removeElement";
                                rowPackQuantity.CssClass = "removeElement";
                                pnlRoofExtrusions.CssClass = "dimensionsTableDisplay";

                                RoofExtrusion aRoofExtrusion = new RoofExtrusion();

                                //call select all function to populate object
                                aRoofExtrusion.Populate(aRoofExtrusion.SelectAll(datDisplayDataSource, Session["tableName"].ToString(), Session["partNumber"].ToString()));

                                txtPartNum.Text = aRoofExtrusion.ExtrusionNumber;
                                txtPartName.Text = aRoofExtrusion.ExtrusionName;
                                txtPartDesc.Text = aRoofExtrusion.ExtrusionDescription;
                                txtColor.Text = aRoofExtrusion.ExtrusionColor;
                                txtRoofExtSize.Text = aRoofExtrusion.ExtrusionSize.ToString() + " " + aRoofExtrusion.SizeUnits;

                                if (aRoofExtrusion.AngleA != 0)
                                {
                                    txtRoofExtAngleA.Text = aRoofExtrusion.AngleA.ToString() + " " + aRoofExtrusion.AngleAUnits;
                                }
                                else
                                {
                                    rowRoofExtAngleA.CssClass = "removeElement";
                                }

                                if (aRoofExtrusion.AngleB != 0)
                                {
                                    txtRoofExtAngleB.Text = aRoofExtrusion.AngleB.ToString() + " " + aRoofExtrusion.AngleBUnits;
                                }
                                else
                                {
                                    rowRoofExtAngleB.CssClass = "removeElement";
                                }

                                if (aRoofExtrusion.AngleC != 0)
                                {
                                    txtRoofExtAngleC.Text = aRoofExtrusion.AngleC.ToString() + " " + aRoofExtrusion.AngleCUnits;
                                }
                                else
                                {
                                    rowRoofExtAngleC.CssClass = "removeElement";
                                }

                                txtRoofExtMaxLength.Text = aRoofExtrusion.ExtrusionMaxLength.ToString() + " " + aRoofExtrusion.MaxLengthUnits;

                                txtUsdPrice.Text = aRoofExtrusion.UsdPrice.ToString("N2");
                                txtCadPrice.Text = aRoofExtrusion.CadPrice.ToString("N2");

                                break;
                            }
                        #endregion

                    }
                }
            }
            /*
            if (Session["picChanged"] != null)
            {
                imgPart.ImageUrl = "Images/catalogue/temp.jpg";
                Session.Remove("picChanged");
            }
             */
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductSelect.aspx");
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Session.Add("backToUpdate", true);
            Response.Redirect("Update.aspx");
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

            Session.Add("displayChanged", "true");
            Session.Add("UpdatePartList", "true");
            Response.Redirect("display.aspx"); //post            
        }

        protected void ddlSchem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSchem.SelectedValue != "")
            {
                if (Session["part"] != null)
                {
                    Session.Remove("part");
                }

                Part aPart = new Part();
                aPart.Populate(aPart.SelectAll(datDisplayDataSource, ddlSchem.SelectedValue, Session["partNumber"].ToString()));
                Session.Add("part", aPart);
                
                if (Session["ddlSchemSelected"] != null)
                {
                    Session.Remove("ddlSchemSelected");
                }

                Session.Add("ddlSchemSelected", ddlSchem.SelectedIndex);
                Response.Redirect("Display.aspx"); //post
            }     
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
            Session.Add("displayChanged", "true");
            Response.Redirect("display.aspx"); //post
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
            Session.Add("displayChanged", "true");
            Response.Redirect("display.aspx"); //post
        }

        protected void btnMainMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("ComponentMenu.aspx");
        }

        protected void UpdatePartsList()
        {
            //set up a dataview object for object member data
            System.Data.DataView aPartsTable = new System.Data.DataView();
            //select row based on table name and part number
            datDisplayDataSource.SelectCommand = "SELECT partNumber FROM tblSchematicParts WHERE schematicNumber='" + Session["partNumber"] + "' ORDER BY keyNumber ASC";
            //assign the row to the dataview object
            aPartsTable = (System.Data.DataView)datDisplayDataSource.Select(System.Web.UI.DataSourceSelectArguments.Empty);     
            ddlSchem.Items.Clear();
            ddlSchem.Items.Add("");

            txtLegend.Text = "";

            for (int i = 0; i < aPartsTable.Count; i++)
            {
                ddlSchem.Items.Add(aPartsTable[i][0].ToString());
                txtLegend.Text += (i + 1).ToString() + ": " + aPartsTable[i][0].ToString() + "\n";
            }

            if (Session["ddlSchemSelected"] != null)
            {
                ddlSchem.SelectedIndex = Convert.ToInt32(Session["ddlSchemSelected"]);
            }           
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            //Redirect back to Insert new product page

            Response.Redirect("Insert.aspx");
        }

        protected void btnShop_Click(object sender, EventArgs e)
        {
            List<string> componentCart;
            List<int> componentCartQty;

            try
            {
                componentCart = (List<string>)Session["componentCart"];
                componentCartQty = (List<int>)Session["componentCartQty"];

                bool existingCheck = true;
                for (int i = 0; i < componentCart.Count; i++)
                {
                    if (componentCart[i] == Session["componentCart"].ToString())
                    {
                        existingCheck = false;
                        componentCartQty[i]++;
                    }
                }

                if (existingCheck) //If there is no duplicate
                {
                    componentCart.Add(Session["partNumber"].ToString());
                    componentCartQty.Add(1);
                }

                Session["componentCart"] = componentCart;
                Session["componentCartQty"] = componentCartQty;
            }
            catch //if session object doesn't exist, we create it
            {
                componentCart = new List<string>(); 
                componentCartQty = new List<int>();

                componentCart.Add(Session["partNumber"].ToString());
                componentCartQty.Add(1);

                Session.Add("componentCart", componentCart);
                Session.Add("componentCartQty", componentCartQty);
            }
        }
    }
}
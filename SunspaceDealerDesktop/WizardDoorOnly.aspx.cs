﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SunspaceDealerDesktop
{
    public partial class DoorOnlyOrder : System.Web.UI.Page
    {
        protected ListItem lst0 = new ListItem("---", "0", true); //0, i.e. no decimal value, selected by default
        protected ListItem lst18 = new ListItem("1/8", ".125");
        protected ListItem lst14 = new ListItem("1/4", ".25");
        protected ListItem lst38 = new ListItem("3/8", ".375");//
        protected ListItem lst12 = new ListItem("1/2", ".5");
        protected ListItem lst58 = new ListItem("5/8", ".625");
        protected ListItem lst34 = new ListItem("3/4", ".75");
        protected ListItem lst78 = new ListItem("7/8", ".875");
        List<Door> doorsOrdered = new List<Door>();            

        protected void Page_Load(object sender, EventArgs e)
        {
            
            #region Loop to display door types as radio buttons

            //For loop to get through all the possible door types: Cabana, French, Patio, Opening Only (No Door)
            for (int typeCount = 0; typeCount < 4; typeCount++)
            {
                //Conditional operator to set the current door type with the right label
                string title = Constants.DOOR_TYPES[typeCount]; //(typeCount == 1) ? "Cabana" : (typeCount == 2) ? "French" : (typeCount == 3) ? "Patio" : "NoDoor";

                if (title == "NoDoor")
                {
                    continue;
                }
                else
                {
                    //li tag to hold door type radio button and all its content
                    DoorOptions.Controls.Add(new LiteralControl("<li>"));
                }

                //Door type radio button
                RadioButton typeRadio = new RadioButton();
                typeRadio.ID = "radType" + title; //Adding appropriate id to door type radio button
                typeRadio.GroupName = "doorTypeRadios";         //Adding group name for all door types
                typeRadio.Attributes.Add("onclick", "typeRowsDisplayed('" + title + "')"); //On click event to display the proper fields/rows
                if (title == "Cabana")
                    typeRadio.Checked = true;

                //Door type radio button label for clickable area
                Label typeLabelRadio = new Label();
                typeLabelRadio.AssociatedControlID = "radType" + title;   //Tying this label to the radio button

                //Door type radio button label text
                Label typeLabel = new Label();
                typeLabel.AssociatedControlID = "radType" + title;    //Tying this label to the radio button
                typeLabel.Text = title;     //Displaying the proper texted based on current title variable
                

                DoorOptions.Controls.Add(typeRadio);        //Adding radio button control to placeholder DoorOptions
                DoorOptions.Controls.Add(typeLabelRadio);   //Adding label control to placeholder DoorOptions
                DoorOptions.Controls.Add(typeLabel);        //Adding label control to placeholder DoorOptions

                //New instance of a table for every door type
                Table tblDoorDetails = new Table();

                tblDoorDetails.ID = "tblDoorDetails" + title; //Adding appropriate id to the table
                tblDoorDetails.CssClass = "tblTextFields";                  //Adding CssClass to the table for styling


                //Creating cells and controls for rows

                #region Table:Default Row Title Current Door (tblDoorDetails)

                TableRow doorTitleRow = new TableRow();
                doorTitleRow.ID = "rowDoorTitle" + title;
                doorTitleRow.Attributes.Add("style", "display:none;");
                TableCell doorTitleLBLCell = new TableCell();

                Label doorTitleLBL = new Label();
                doorTitleLBL.ID = "lblDoorTitle" + title;
                doorTitleLBL.Text = "Select door details:";
                doorTitleLBL.Attributes.Add("style", "font-weight:bold;");

                #endregion

                #region Table:Second Row Door Style (tblDoorDetails)

                TableRow doorStyleRow = new TableRow();
                doorStyleRow.ID = "rowDoorStyle" + title;
                doorStyleRow.Attributes.Add("style", "display:none;");
                TableCell doorStyleLBLCell = new TableCell();
                TableCell doorStyleDDLCell = new TableCell();

                Label doorStyleLBL = new Label();
                doorStyleLBL.ID = "lblDoorStyle" + title;
                doorStyleLBL.Text = "Style";

                DropDownList doorStyleDDL = new DropDownList();
                doorStyleDDL.ID = "ddlDoorStyle" + title;
                doorStyleDDL.Attributes.Add("onchange", "doorStyle('" + title + "')");
                if (title == "Patio")
                {
                    for (int j = 0; j < Constants.DOOR_ORDER_PATIO.Count(); j++)
                    {
                        doorStyleDDL.Items.Add(new ListItem(Constants.DOOR_ORDER_PATIO[j], Constants.DOOR_ORDER_PATIO[j]));
                    }
                }
                else
                {
                    for (int j = 0; j < Constants.DOOR_ORDER_ENTRY.Count(); j++)
                    {
                        doorStyleDDL.Items.Add(new ListItem(Constants.DOOR_ORDER_ENTRY[j], Constants.DOOR_ORDER_ENTRY[j]));
                    }
                }

                doorStyleLBL.AssociatedControlID = "ddlDoorStyle" + title;

                #endregion

                #region Table:Sixteenth Row Door V4T Vinyl Tint (tblDoorDetails)

                TableRow doorVinylTintRow = new TableRow();
                doorVinylTintRow.ID = "rowDoorVinylTint" + title;
                doorVinylTintRow.Attributes.Add("style", "display:none;");
                TableCell doorVinylTintLBLCell = new TableCell();
                TableCell doorVinylTintDDLCell = new TableCell();

                Label doorVinylTintLBL = new Label();
                doorVinylTintLBL.ID = "lblDoorVinylTint" + title;
                doorVinylTintLBL.Text = "V4T Vinyl Tint:";

                DropDownList doorVinylTintDDL = new DropDownList();
                doorVinylTintDDL.ID = "ddlDoorVinylTint" + title;
                doorVinylTintDDL.Attributes.Add("onchange", "displayMixedTint('" + title + "')");
                for (int j = 0; j < Constants.DOOR_V4T_VINYL_OPTIONS.Count(); j++)
                {
                    doorVinylTintDDL.Items.Add(new ListItem(Constants.DOOR_V4T_VINYL_OPTIONS[j], Constants.DOOR_V4T_VINYL_OPTIONS[j]));
                }
                doorVinylTintLBL.AssociatedControlID = "ddlDoorVinylTint" + title;

                #endregion

                #region Table:Twelfth Row Door V4T Number Of Vents (tblDoorDetails)

                TableRow doorNumberOfVentsRow = new TableRow();
                doorNumberOfVentsRow.ID = "rowDoorNumberOfVents" + title;
                doorNumberOfVentsRow.Attributes.Add("style", "display:none;");
                TableCell doorNumberOfVentsLBLCell = new TableCell();
                TableCell doorNumberOfVentsDDLCell = new TableCell();

                Label doorNumberOfVentsLBL = new Label();
                doorNumberOfVentsLBL.ID = "lblNumberOfVents" + title;
                doorNumberOfVentsLBL.Text = "V4T Number Of Vents:";

                DropDownList doorNumberOfVentsDDL = new DropDownList();
                doorNumberOfVentsDDL.ID = "ddlDoorNumberOfVents" + title;
                doorNumberOfVentsDDL.Attributes.Add("onchange", "displayMixedTint('" + title + "')");
                for (int j = 0; j < Constants.DOOR_NUMBER_OF_VENTS.Count(); j++)
                {
                    doorNumberOfVentsDDL.Items.Add(new ListItem(Constants.DOOR_NUMBER_OF_VENTS[j], Constants.DOOR_NUMBER_OF_VENTS[j]));
                }

                doorNumberOfVentsLBL.AssociatedControlID = "ddlDoorNumberOfVents" + title;

                #endregion

                #region Table:# Row Door Transom Vinyl (tblDoorDetails)

                TableRow doorTransomVinylRow = new TableRow();
                doorTransomVinylRow.ID = "rowDoorTransomVinyl" + title;
                doorTransomVinylRow.Attributes.Add("style", "display:none;");
                TableCell doorTransomVinylTypesLBLCell = new TableCell();
                TableCell doorTransomVinylTypesDDLCell = new TableCell();

                Label doorTransomVinylLBL = new Label();
                doorTransomVinylLBL.ID = "lblDoorTransomVinyl" + title;
                doorTransomVinylLBL.Text = "Transom Vinyl Types:";

                DropDownList doorTransomVinylDDL = new DropDownList();
                doorTransomVinylDDL.ID = "ddlDoorTransomVinyl" + title;
                for (int j = 0; j < Constants.VINYL_TINTS.Count(); j++)
                {
                    doorTransomVinylDDL.Items.Add(new ListItem(Constants.VINYL_TINTS[j], Constants.VINYL_TINTS[j]));
                }

                doorTransomVinylLBL.AssociatedControlID = "ddlDoorTransomVinyl" + title;

                #endregion

                #region Table:# Row Door Transom Glass Types (tblDoorDetails)

                TableRow doorTransomGlassRow = new TableRow();
                doorTransomGlassRow.ID = "rowDoorTransomGlass" + title;
                doorTransomGlassRow.Attributes.Add("style", "display:none;");
                TableCell doorTransomGlassTypesLBLCell = new TableCell();
                TableCell doorTransomGlassTypesDDLCell = new TableCell();

                Label doorTransomGlassLBL = new Label();
                doorTransomGlassLBL.ID = "lblDoorTransomGlass" + title;
                doorTransomGlassLBL.Text = "Transom Glass Types:";

                DropDownList doorTransomGlassDDL = new DropDownList();
                doorTransomGlassDDL.ID = "ddlDoorTransomGlass" + title;
                for (int j = 0; j < Constants.TRANSOM_GLASS_TINTS.Count(); j++)
                {
                    doorTransomGlassDDL.Items.Add(new ListItem(Constants.TRANSOM_GLASS_TINTS[j], Constants.TRANSOM_GLASS_TINTS[j]));
                }

                doorTransomGlassLBL.AssociatedControlID = "ddlDoorTransomGlass" + title;

                #endregion

                #region Table:# Row Door Kickplate (tblDoorDetails)

                TableRow doorKickplateRow = new TableRow();
                doorKickplateRow.ID = "rowDoorKickplate" + title;
                doorKickplateRow.Attributes.Add("style", "display:none;");
                TableCell doorKickplateLBLCell = new TableCell();
                TableCell doorKickplateDDLCell = new TableCell();

                Label doorKickplateLBL = new Label();
                doorKickplateLBL.ID = "lblDoorKickplate" + title;
                doorKickplateLBL.Text = "Kickplate Height:";

                DropDownList doorKickplateDDL = new DropDownList();
                doorKickplateDDL.ID = "ddlDoorKickplate" + title;
                doorKickplateDDL.Attributes.Add("onchange", "doorKickplateStyle('" + title + "','" + "')");
                for (int j = 0; j < Constants.KICKPLATE_SIZE_OPTIONS.Count(); j++)
                {
                    if (Constants.KICKPLATE_SIZE_OPTIONS[j] == "Custom")
                    {
                        doorKickplateDDL.Items.Add(new ListItem(Constants.KICKPLATE_SIZE_OPTIONS[j], "cKickplate"));
                    }
                    else
                    {
                        doorKickplateDDL.Items.Add(new ListItem(Constants.KICKPLATE_SIZE_OPTIONS[j] + "\"", Constants.KICKPLATE_SIZE_OPTIONS[j]));
                    }
                }

                #endregion

                #region Table:# Row Door Kickplate Custom (tblDoorDetails)

                TableRow doorCustomKickplateRow = new TableRow();
                doorCustomKickplateRow.ID = "rowDoorCustomKickplate" + title;
                doorCustomKickplateRow.Attributes.Add("style", "display:none;");
                TableCell doorCustomKickplateLBLCell = new TableCell();
                TableCell doorCustomKickplateTXTCell = new TableCell();
                TableCell doorCustomKickplateDDLCell = new TableCell();

                Label doorCustomKickplateLBL = new Label();
                doorCustomKickplateLBL.ID = "lblDoorCustomKickplate" + title;
                doorCustomKickplateLBL.Text = "Custom Kickplate (inches):";

                TextBox doorCustomKickplateTXT = new TextBox();
                doorCustomKickplateTXT.ID = "txtDoorKickplateCustom" + title;
                doorCustomKickplateTXT.CssClass = "txtField txtDoorInput";
                doorCustomKickplateTXT.Attributes.Add("maxlength", "3");
                doorCustomKickplateTXT.Attributes.Add("onkeydown", "return (event.keyCode!=13);");

                DropDownList inchCustomKickplate = new DropDownList();
                inchCustomKickplate.ID = "ddlDoorKickplateCustom" + title;
                inchCustomKickplate.Items.Add(lst0);
                inchCustomKickplate.Items.Add(lst18);
                inchCustomKickplate.Items.Add(lst14);
                inchCustomKickplate.Items.Add(lst38);
                inchCustomKickplate.Items.Add(lst12);
                inchCustomKickplate.Items.Add(lst58);
                inchCustomKickplate.Items.Add(lst34);
                inchCustomKickplate.Items.Add(lst78);

                doorCustomKickplateLBL.AssociatedControlID = "txtDoorKickplateCustom" + title;

                #endregion

                #region Table:Third Row Color of Door (tblDoorDetails)

                TableRow colourOfDoorRow = new TableRow();
                colourOfDoorRow.ID = "rowDoorColour" + title;
                colourOfDoorRow.Attributes.Add("style", "display:none;");
                TableCell colourOfDoorLBLCell = new TableCell();
                TableCell colourOfDoorDDLCell = new TableCell();

                Label colourOfDoorLBL = new Label();
                colourOfDoorLBL.ID = "lblDoorColour" + title;
                colourOfDoorLBL.Text = "Colour:";

                DropDownList colourOfDoorDDL = new DropDownList();
                colourOfDoorDDL.ID = "ddlDoorColour" + title;
                for (int j = 0; j < Constants.DOOR_COLOURS.Count(); j++)
                {
                    colourOfDoorDDL.Items.Add(new ListItem(Constants.DOOR_COLOURS[j], Constants.DOOR_COLOURS[j]));
                }

                colourOfDoorLBL.AssociatedControlID = "ddlDoorColour" + title;

                #endregion

                #region Table:Fourth Row Door Height (tblDoorDetails)

                TableRow doorHeightRow = new TableRow();
                doorHeightRow.ID = "rowDoorHeight" + title;
                doorHeightRow.Attributes.Add("style", "display:none;");
                TableCell doorHeightLBLCell = new TableCell();
                TableCell doorHeightDDLCell = new TableCell();

                Label doorHeightLBL = new Label();
                doorHeightLBL.ID = "lblDoorHeight" + title;
                doorHeightLBL.Text = "Height:";

                DropDownList doorHeightDDL = new DropDownList();
                doorHeightDDL.ID = "ddlDoorHeight" + title;
                doorHeightDDL.Attributes.Add("onchange", "customDimension('" + title + "','Height')");
                for (int j = 0; j < Constants.DOOR_HEIGHTS.Count(); j++)
                {
                    if (Constants.DOOR_HEIGHTS[j] == "Custom")
                    {
                        doorHeightDDL.Items.Add(new ListItem(Constants.DOOR_HEIGHTS[j], "cHeight"));
                    }
                    else
                    {
                        doorHeightDDL.Items.Add(new ListItem(Constants.DOOR_HEIGHTS[j] + "\"", Constants.DOOR_HEIGHTS[j]));
                    }
                }

                doorHeightLBL.AssociatedControlID = "ddlDoorHeight" + title;

                #endregion

                #region Table:Sixth Row Door Custom Height (tblDoorDetails)

                TableRow doorCustomHeightRow = new TableRow();
                doorCustomHeightRow.ID = "rowDoorCustomHeight" + title;
                doorCustomHeightRow.Attributes.Add("style", "display:none;");
                TableCell doorCustomHeightLBLCell = new TableCell();
                TableCell doorCustomHeightTXTCell = new TableCell();
                TableCell doorCustomHeightDDLCell = new TableCell();

                Label doorCustomHeightLBL = new Label();
                doorCustomHeightLBL.ID = "lblDoorCustomHeight" + title;
                doorCustomHeightLBL.Text = "Custom Height (inches):";

                TextBox doorCustomHeightTXT = new TextBox();
                doorCustomHeightTXT.ID = "txtDoorHeightCustom" + title;
                doorCustomHeightTXT.CssClass = "txtField txtDoorInput";
                doorCustomHeightTXT.Attributes.Add("maxlength", "3");
                doorCustomHeightTXT.Attributes.Add("onkeydown", "return (event.keyCode!=13);");

                DropDownList inchCustomHeight = new DropDownList();
                inchCustomHeight.ID = "ddlDoorHeightCustom" + title;
                inchCustomHeight.Items.Add(lst0);
                inchCustomHeight.Items.Add(lst18);
                inchCustomHeight.Items.Add(lst14);
                inchCustomHeight.Items.Add(lst38);
                inchCustomHeight.Items.Add(lst12);
                inchCustomHeight.Items.Add(lst58);
                inchCustomHeight.Items.Add(lst34);
                inchCustomHeight.Items.Add(lst78);

                doorCustomHeightLBL.AssociatedControlID = "txtDoorHeightCustom" + title;

                #endregion

                #region Table:Fifth Row Door Width (tblDoorDetails)

                TableRow doorWidthRow = new TableRow();
                doorWidthRow.ID = "rowDoorWidth" + title;
                doorWidthRow.Attributes.Add("style", "display:none;");
                TableCell doorWidthLBLCell = new TableCell();
                TableCell doorWidthDDLCell = new TableCell();

                Label doorWidthLBL = new Label();
                doorWidthLBL.ID = "lblDoorWidth" + title;
                doorWidthLBL.Text = "Width:";

                DropDownList doorWidthDDL = new DropDownList();
                doorWidthDDL.ID = "ddlDoorWidth" + title;
                doorWidthDDL.Attributes.Add("onchange", "customDimension('" + title + "','Width')");

                if (title == "Patio")
                {
                    for (int j = 0; j < Constants.DOOR_WIDTHS_PATIO.Count(); j++)
                    {
                        if (Constants.DOOR_WIDTHS_PATIO[j] == "Custom")
                        {
                            doorWidthDDL.Items.Add(new ListItem(Constants.DOOR_WIDTHS_PATIO[j], "cWidth"));
                        }
                        else
                        {
                            doorWidthDDL.Items.Add(new ListItem(Constants.DOOR_WIDTHS_PATIO[j] + "\'", Convert.ToString((Convert.ToInt32(Constants.DOOR_WIDTHS_PATIO[j]) * 12))));
                        }
                    }
                }
                else if (title == "French")
                {
                    for (int j = 0; j < Constants.DOOR_WIDTHS_FRENCH.Count(); j++)
                    {
                        if (Constants.DOOR_WIDTHS_FRENCH[j] == "Custom")
                        {
                            doorWidthDDL.Items.Add(new ListItem(Constants.DOOR_WIDTHS_FRENCH[j], "cWidth"));
                        }
                        else
                        {
                            doorWidthDDL.Items.Add(new ListItem(Constants.DOOR_WIDTHS_FRENCH[j] + "\"", Constants.DOOR_WIDTHS_FRENCH[j]));
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < Constants.DOOR_WIDTHS_CABANA_NODOOR.Count(); j++)
                    {
                        if (Constants.DOOR_WIDTHS_CABANA_NODOOR[j] == "Custom")
                        {
                            doorWidthDDL.Items.Add(new ListItem(Constants.DOOR_WIDTHS_CABANA_NODOOR[j], "cWidth"));
                        }
                        else
                        {
                            doorWidthDDL.Items.Add(new ListItem(Constants.DOOR_WIDTHS_CABANA_NODOOR[j] + "\"", Constants.DOOR_WIDTHS_CABANA_NODOOR[j]));
                        }
                    }
                }

                doorWidthLBL.AssociatedControlID = "ddlDoorWidth" + title;

                #endregion

                #region Table:Seventh Row Door Custom Width (tblDoorDetails)

                TableRow doorCustomWidthRow = new TableRow();
                doorCustomWidthRow.ID = "rowDoorCustomWidth" + title;
                doorCustomWidthRow.Attributes.Add("style", "display:none;");
                TableCell doorCustomWidthLBLCell = new TableCell();
                TableCell doorCustomWidthTXTCell = new TableCell();
                TableCell doorCustomWidthDDLCell = new TableCell();

                Label doorCustomWidthLBL = new Label();
                doorCustomWidthLBL.ID = "lblDoorCustomWidth" + title;
                doorCustomWidthLBL.Text = "Custom Width (inches):";

                TextBox doorCustomWidthTXT = new TextBox();
                doorCustomWidthTXT.ID = "txtDoorWidthCustom" + title;
                doorCustomWidthTXT.CssClass = "txtField txtDoorInput";
                doorCustomWidthTXT.Attributes.Add("maxlength", "3");
                doorCustomWidthTXT.Attributes.Add("onkeydown", "return (event.keyCode!=13);");

                DropDownList inchCustomWidth = new DropDownList();
                inchCustomWidth.ID = "ddlDoorWidthCustom" + title;
                inchCustomWidth.Items.Add(lst0);
                inchCustomWidth.Items.Add(lst18);
                inchCustomWidth.Items.Add(lst14);
                inchCustomWidth.Items.Add(lst38);
                inchCustomWidth.Items.Add(lst12);
                inchCustomWidth.Items.Add(lst58);
                inchCustomWidth.Items.Add(lst34);
                inchCustomWidth.Items.Add(lst78);

                doorCustomWidthLBL.AssociatedControlID = "txtDoorWidthCustom" + title;

                #endregion

                #region Table:Eight Row Door Primary Operator LHH (tblDoorDetails)

                TableRow doorOperatorLHHRow = new TableRow();
                doorOperatorLHHRow.ID = "rowDoorOperatorLHH" + title;
                doorOperatorLHHRow.Attributes.Add("style", "display:none;");
                TableCell doorOperatorLHHLBLCell = new TableCell();
                TableCell doorOperatorLHHRADCell = new TableCell();

                Label doorOperatorLHHLBLMain = new Label();
                doorOperatorLHHLBLMain.ID = "lblDoorOperatorLHHMain" + title;
                doorOperatorLHHLBLMain.Text = "Primary Operator:";

                Label doorOperatorLHHLBLRad = new Label();
                doorOperatorLHHLBLRad.ID = "lblDoorOperatorRadLHH" + title;

                Label doorOperatorLHHLBL = new Label();
                doorOperatorLHHLBL.ID = "lblDoorOperatorLHH" + title;
                doorOperatorLHHLBL.Text = "Left";

                RadioButton doorOperatorLHHRad = new RadioButton();
                doorOperatorLHHRad.ID = "radDoorOperator" + title;
                doorOperatorLHHRad.Attributes.Add("value", "Left");
                doorOperatorLHHRad.GroupName = "PrimaryOperator" + title;

                doorOperatorLHHLBLRad.AssociatedControlID = "radDoorOperator" + title;
                doorOperatorLHHLBL.AssociatedControlID = "radDoorOperator" + title;

                #endregion

                #region Table:Ninth Row Door Primary Operator RHH (tblDoorDetails)

                TableRow doorOperatorRHHRow = new TableRow();
                doorOperatorRHHRow.ID = "rowDoorOperatorRHH" + title;
                doorOperatorRHHRow.Attributes.Add("style", "display:none;");
                TableCell doorOperatorRHHLBLCell = new TableCell();
                TableCell doorOperatorRHHRADCell = new TableCell();

                Label doorOperatorRHHLBLRad = new Label();
                doorOperatorRHHLBLRad.ID = "lblDoorOperatorRadRHH" + title;

                Label doorOperatorRHHLBL = new Label();
                doorOperatorRHHLBL.ID = "lblDoorOperatorRHH" + title;
                doorOperatorRHHLBL.Text = "Right";

                RadioButton doorOperatorRHHRad = new RadioButton();
                doorOperatorRHHRad.ID = "radDoorOperatorRHH" + title;
                doorOperatorRHHRad.Attributes.Add("value", "Right");
                doorOperatorRHHRad.GroupName = "PrimaryOperator" + title;

                doorOperatorRHHLBLRad.AssociatedControlID = "radDoorOperatorRHH" + title;
                doorOperatorRHHLBL.AssociatedControlID = "radDoorOperatorRHH" + title;

                #endregion

                #region Table:Tenth Row Door Box Header (tblDoorDetails)

                TableRow doorBoxHeaderRow = new TableRow();
                doorBoxHeaderRow.ID = "rowDoorBoxHeader" + title;
                doorBoxHeaderRow.Attributes.Add("style", "display:none;");
                TableCell doorBoxHeaderLBLCell = new TableCell();
                TableCell doorBoxHeaderDDLCell = new TableCell();

                Label doorBoxHeaderLBL = new Label();
                doorBoxHeaderLBL.ID = "lblDoorBoxHeader" + title;
                doorBoxHeaderLBL.Text = "Box Header Position:";

                DropDownList doorBoxHeaderDDL = new DropDownList();
                doorBoxHeaderDDL.ID = "ddlDoorBoxHeader" + title;
                for (int j = 0; j < Constants.DOOR_BOXHEADER_POSITION.Count(); j++)
                {
                    doorBoxHeaderDDL.Items.Add(new ListItem(Constants.DOOR_BOXHEADER_POSITION[j], Constants.DOOR_BOXHEADER_POSITION[j]));
                }

                doorBoxHeaderLBL.AssociatedControlID = "ddlDoorBoxHeader" + title;

                #endregion

                #region Table:Thirteenth Row Door Glass Tint (tblDoorDetails)

                TableRow doorGlassTintRow = new TableRow();
                doorGlassTintRow.ID = "rowDoorGlassTint" + title;
                doorGlassTintRow.Attributes.Add("style", "display:none;");
                TableCell doorGlassTintLBLCell = new TableCell();
                TableCell doorGlassTintDDLCell = new TableCell();

                Label doorGlassTintLBL = new Label();
                doorGlassTintLBL.ID = "lblDoorGlassTint" + title;
                doorGlassTintLBL.Text = "Door Glass Tint:";

                DropDownList doorGlassTintDDL = new DropDownList();
                doorGlassTintDDL.ID = "ddlDoorGlassTint" + title;
                for (int j = 0; j < Constants.DOOR_GLASS_TINTS.Count(); j++)
                {
                    doorGlassTintDDL.Items.Add(new ListItem(Constants.DOOR_GLASS_TINTS[j], Constants.DOOR_GLASS_TINTS[j]));
                }

                doorGlassTintLBL.AssociatedControlID = "ddlDoorGlassTint" + title;

                #endregion

                #region Table:Tenth Row Door Hinge LHH (tblDoorDetails)

                TableRow doorHingeLHHRow = new TableRow();
                doorHingeLHHRow.ID = "rowDoorHingeLHH" + title;
                doorHingeLHHRow.Attributes.Add("style", "display:none;");
                TableCell doorHingeLHHLBLCell = new TableCell();
                TableCell doorHingeLHHRADCell = new TableCell();

                Label doorHingeLHHLBLMain = new Label();
                doorHingeLHHLBLMain.ID = "lblDoorHingeLHHMain" + title;
                doorHingeLHHLBLMain.Text = "Hinge Placement:";

                Label doorHingeLHHLBLRad = new Label();
                doorHingeLHHLBLRad.ID = "lblHingeLHHRad" + title;

                Label doorHingeLHHLBL = new Label();
                doorHingeLHHLBL.ID = "lblHingeLHH" + title;
                doorHingeLHHLBL.Text = "Left";

                RadioButton doorHingeLHHRad = new RadioButton();
                doorHingeLHHRad.ID = "radDoorHinge" + title;
                doorHingeLHHRad.Attributes.Add("value", "Left");
                doorHingeLHHRad.GroupName = "DoorHinge" + title;

                doorHingeLHHLBLRad.AssociatedControlID = "radDoorHinge" + title;
                doorHingeLHHLBL.AssociatedControlID = "radDoorHinge" + title;

                #endregion

                #region Table:Eleventh Row Door Hinge RHH (tblDoorDetails)

                TableRow doorHingeRHHRow = new TableRow();
                doorHingeRHHRow.ID = "rowDoorHingeRHH" + title;
                doorHingeRHHRow.Attributes.Add("style", "display:none;");
                TableCell doorHingeRHHLBLCell = new TableCell();
                TableCell doorHingeRHHRADCell = new TableCell();

                Label doorHingeRHHLBLRad = new Label();
                doorHingeRHHLBLRad.ID = "lblDoorHingeRHHRad" + title;

                Label doorHingeRHHLBL = new Label();
                doorHingeRHHLBL.ID = "lblDoorHingeRHH" + title;
                doorHingeRHHLBL.Text = "Right";

                RadioButton doorHingeRHHRad = new RadioButton();
                doorHingeRHHRad.ID = "radDoorHingeRHH" + title;
                doorHingeRHHRad.Attributes.Add("value", "Right");
                doorHingeRHHRad.GroupName = "DoorHinge" + title;

                doorHingeRHHLBLRad.AssociatedControlID = "radDoorHingeRHH" + title;
                doorHingeRHHLBL.AssociatedControlID = "radDoorHingeRHH" + title;

                #endregion

                #region Table:Fourteenth Row Door Screen Types (tblDoorDetails)

                TableRow doorScreenTypesRow = new TableRow();
                doorScreenTypesRow.ID = "rowDoorScreenTypes" + title;
                doorScreenTypesRow.Attributes.Add("style", "display:none;");
                TableCell doorScreenTypesLBLCell = new TableCell();
                TableCell doorScreenTypesDDLCell = new TableCell();

                Label doorScreenTypesLBL = new Label();
                doorScreenTypesLBL.ID = "lblDoorScreenTypes" + title;
                doorScreenTypesLBL.Text = "Door Screen Type:";

                DropDownList doorScreenTypesDDL = new DropDownList();
                doorScreenTypesDDL.ID = "ddlDoorScreenTypes" + title;
                for (int j = 0; j < Constants.SCREEN_TYPES.Count(); j++)
                {
                    doorScreenTypesDDL.Items.Add(new ListItem(Constants.SCREEN_TYPES[j], Constants.SCREEN_TYPES[j]));
                }

                doorScreenTypesLBL.AssociatedControlID = "ddlDoorScreenTypes" + title;

                #endregion

                #region Table:Fifteenth Row Door Hardware (tblDoorDetails)

                TableRow doorHardwareRow = new TableRow();
                doorHardwareRow.ID = "rowDoorHardware" + title;
                doorHardwareRow.Attributes.Add("style", "display:none;");
                TableCell doorHardwareLBLCell = new TableCell();
                TableCell doorHardwareDDLCell = new TableCell();

                Label doorHardwareLBL = new Label();
                doorHardwareLBL.ID = "lblDoorHardware" + title;
                doorHardwareLBL.Text = "Door Hardware";

                DropDownList doorHardwareDDL = new DropDownList();
                doorHardwareDDL.ID = "ddlDoorHardware" + title;
                for (int j = 0; j < Constants.DOOR_HARDWARE.Count(); j++)
                {
                    doorHardwareDDL.Items.Add(new ListItem(Constants.DOOR_HARDWARE[j], Constants.DOOR_HARDWARE[j]));
                }

                doorHardwareLBL.AssociatedControlID = "ddlDoorHardware" + title;

                #endregion

                #region Table:Eight Row Door Swing In (tblDoorDetails)

                TableRow doorSwingInRow = new TableRow();
                doorSwingInRow.ID = "rowDoorSwingIn" + title;
                doorSwingInRow.Attributes.Add("style", "display:none;");
                TableCell doorSwingInLBLCell = new TableCell();
                TableCell doorSwingInRADCell = new TableCell();

                Label doorSwingInLBLMain = new Label();
                doorSwingInLBLMain.ID = "lblDoorSwingMain" + title;
                doorSwingInLBLMain.Text = "Swing:";

                Label doorSwingInLBLRad = new Label();
                doorSwingInLBLRad.ID = "lblDoorSwingIn" + title;

                Label doorSwingInLBL = new Label();
                doorSwingInLBL.ID = "lblDoorSwingInRad" + title;
                doorSwingInLBL.Text = "In";

                RadioButton doorSwingInRAD = new RadioButton();
                doorSwingInRAD.ID = "radDoorSwing" + title;
                doorSwingInRAD.Attributes.Add("value", "In");
                doorSwingInRAD.GroupName = "SwingInOut" + title;

                doorSwingInLBLRad.AssociatedControlID = "radDoorSwing" + title;
                doorSwingInLBL.AssociatedControlID = "radDoorSwing" + title;

                #endregion

                #region Table:Ninth Row Door Swing Out (tblDoorDetails)

                TableRow doorSwingOutRow = new TableRow();
                doorSwingOutRow.ID = "rowDoorSwingOut" + title;
                doorSwingOutRow.Attributes.Add("style", "display:none;");
                TableCell doorSwingOutLBLCell = new TableCell();
                TableCell doorSwingOutRADCell = new TableCell();

                Label doorSwingOutLBLRad = new Label();
                doorSwingOutLBLRad.ID = "lblDoorSwingOutRad" + title;

                Label doorSwingOutLBL = new Label();
                doorSwingOutLBL.ID = "lblDoorSwingOut" + title;
                doorSwingOutLBL.Text = "Out";

                RadioButton doorSwingOutRAD = new RadioButton();
                doorSwingOutRAD.ID = "radDoorSwingOut" + title;
                doorSwingOutRAD.Attributes.Add("value", "Out");
                doorSwingOutRAD.GroupName = "SwingInOut" + title;

                doorSwingOutLBLRad.AssociatedControlID = "radDoorSwingOut" + title;
                doorSwingOutLBL.AssociatedControlID = "radDoorSwingOut" + title;

                #endregion

                #region Table:# Row Door Position DDL (tblDoorDetails)

                TableRow doorPositionDDLRow = new TableRow();
                doorPositionDDLRow.ID = "rowDoorPosition" + title;
                doorPositionDDLRow.Attributes.Add("style", "display:none;");
                TableCell doorPositionDDLLBLCell = new TableCell();
                TableCell doorPositionDDLDDLCell = new TableCell();

                Label doorPositionDDLLBL = new Label();
                doorPositionDDLLBL.ID = "lblDoorPositionDDL" + title;
                doorPositionDDLLBL.Text = "Position In Wall:";

                DropDownList doorPositionDDLDDL = new DropDownList();
                doorPositionDDLDDL.ID = "ddlDoorPosition" + title;
                doorPositionDDLDDL.Attributes.Add("onchange", "customDimension('" + title + "','Position')");
                for (int j = 0; j < Constants.DOOR_POSITION.Count(); j++)
                {
                    if (Constants.DOOR_POSITION[j] == "Custom")
                    {
                        doorPositionDDLDDL.Items.Add(new ListItem(Constants.DOOR_POSITION[j], "cPosition"));
                    }
                    else
                    {
                        doorPositionDDLDDL.Items.Add(new ListItem(Constants.DOOR_POSITION[j], Constants.DOOR_POSITION[j]));
                    }
                }

                doorPositionDDLLBL.AssociatedControlID = "ddlDoorPosition" + title;

                #endregion
            
                #region Table:# Row Add This Door (tblDoorDetails)

                TableRow doorButtonRow = new TableRow();
                doorButtonRow.ID = "rowAddDoor" + title;
                doorButtonRow.Attributes.Add("style", "display:inherit;");
                TableCell doorAddButtonCell = new TableCell();
                TableCell doorFillButtonCell = new TableCell();

                Button doorButton = new Button();
                doorButton.ID = "btnAdd" + title;
                doorButton.Text = "Add this " + title + " door";
                doorButton.CssClass = "btnSubmit";
                //doorButton.Attributes.Add("click", "addDoor(\"" + title + "\")");

                #endregion

                //Adding to table

                #region Table:Default Row Title Current Door Added To Table (tblDoorDetails)

                doorTitleLBLCell.Controls.Add(doorTitleLBL);

                tblDoorDetails.Rows.Add(doorTitleRow);

                doorTitleRow.Cells.Add(doorTitleLBLCell);

                #endregion

                #region Table:Second Row Style Of Door Added To Table (tblDoorDetails)

                doorStyleLBLCell.Controls.Add(doorStyleLBL);
                doorStyleDDLCell.Controls.Add(doorStyleDDL);

                tblDoorDetails.Rows.Add(doorStyleRow);

                doorStyleRow.Cells.Add(doorStyleLBLCell);
                doorStyleRow.Cells.Add(doorStyleDDLCell);

                #endregion

                #region Table:Twelfth Row Door V4T Number Of Vents Added To Table (tblDoorDetails)

                doorNumberOfVentsLBLCell.Controls.Add(doorNumberOfVentsLBL);
                doorNumberOfVentsDDLCell.Controls.Add(doorNumberOfVentsDDL);

                tblDoorDetails.Rows.Add(doorNumberOfVentsRow);

                doorNumberOfVentsRow.Cells.Add(doorNumberOfVentsLBLCell);
                doorNumberOfVentsRow.Cells.Add(doorNumberOfVentsDDLCell);

                #endregion

                #region Table:Sixteenth Row Door V4T Vinyl Tint (tblDoorDetails)

                doorVinylTintLBLCell.Controls.Add(doorVinylTintLBL);
                doorVinylTintDDLCell.Controls.Add(doorVinylTintDDL);

                tblDoorDetails.Rows.Add(doorVinylTintRow);

                doorVinylTintRow.Cells.Add(doorVinylTintLBLCell);
                doorVinylTintRow.Cells.Add(doorVinylTintDDLCell);
                
                addMixedTintDropdowns(title, tblDoorDetails);

                #endregion

                #region Table:# Row Door Transom Vinyl Types Added To Table (tblDoorDetails)

                doorTransomVinylTypesLBLCell.Controls.Add(doorTransomVinylLBL);
                doorTransomVinylTypesDDLCell.Controls.Add(doorTransomVinylDDL);

                tblDoorDetails.Rows.Add(doorTransomVinylRow);

                doorTransomVinylRow.Cells.Add(doorTransomVinylTypesLBLCell);
                doorTransomVinylRow.Cells.Add(doorTransomVinylTypesDDLCell);

                #endregion

                #region Table:# Row Door Transom Glass Types Added To Table (tblDoorDetails)

                doorTransomGlassTypesLBLCell.Controls.Add(doorTransomGlassLBL);
                doorTransomGlassTypesDDLCell.Controls.Add(doorTransomGlassDDL);

                tblDoorDetails.Rows.Add(doorTransomGlassRow);

                doorTransomGlassRow.Cells.Add(doorTransomGlassTypesLBLCell);
                doorTransomGlassRow.Cells.Add(doorTransomGlassTypesDDLCell);

                #endregion

                #region Table:# Row Door Kickplate (tblDoorDetails)

                doorKickplateLBLCell.Controls.Add(doorKickplateLBL);
                doorKickplateDDLCell.Controls.Add(doorKickplateDDL);

                tblDoorDetails.Rows.Add(doorKickplateRow);

                doorKickplateRow.Cells.Add(doorKickplateLBLCell);
                doorKickplateRow.Cells.Add(doorKickplateDDLCell);

                #endregion

                #region Table:# Row Door Kickplate Custom (tblDoorDetails)

                doorCustomKickplateLBLCell.Controls.Add(doorCustomKickplateLBL);
                doorCustomKickplateTXTCell.Controls.Add(doorCustomKickplateTXT);
                doorCustomKickplateDDLCell.Controls.Add(inchCustomKickplate);

                tblDoorDetails.Rows.Add(doorCustomKickplateRow);

                doorCustomKickplateRow.Cells.Add(doorCustomKickplateLBLCell);
                doorCustomKickplateRow.Cells.Add(doorCustomKickplateTXTCell);
                doorCustomKickplateRow.Cells.Add(doorCustomKickplateDDLCell);

                #endregion

                #region Table:Third Row Color of Door Added to Table (tblDoorDetails)

                colourOfDoorLBLCell.Controls.Add(colourOfDoorLBL);
                colourOfDoorDDLCell.Controls.Add(colourOfDoorDDL);

                tblDoorDetails.Rows.Add(colourOfDoorRow);

                colourOfDoorRow.Cells.Add(colourOfDoorLBLCell);
                colourOfDoorRow.Cells.Add(colourOfDoorDDLCell);

                #endregion

                #region Table:Fourth Row Height Of Door Added To Table (tblDoorDetails)

                doorHeightLBLCell.Controls.Add(doorHeightLBL);
                doorHeightDDLCell.Controls.Add(doorHeightDDL);

                tblDoorDetails.Rows.Add(doorHeightRow);

                doorHeightRow.Cells.Add(doorHeightLBLCell);
                doorHeightRow.Cells.Add(doorHeightDDLCell);

                #endregion

                #region Table:Sixth Row Custom Height Of Door Added To Table (tblDoorDetails)

                doorCustomHeightLBLCell.Controls.Add(doorCustomHeightLBL);
                doorCustomHeightTXTCell.Controls.Add(doorCustomHeightTXT);
                doorCustomHeightDDLCell.Controls.Add(inchCustomHeight);

                tblDoorDetails.Rows.Add(doorCustomHeightRow);

                doorCustomHeightRow.Cells.Add(doorCustomHeightLBLCell);
                doorCustomHeightRow.Cells.Add(doorCustomHeightTXTCell);
                doorCustomHeightRow.Cells.Add(doorCustomHeightDDLCell);

                #endregion

                #region Table:Fifth Row Width Of Door Added To Table (tblDoorDetails)

                doorWidthLBLCell.Controls.Add(doorWidthLBL);
                doorWidthDDLCell.Controls.Add(doorWidthDDL);

                tblDoorDetails.Rows.Add(doorWidthRow);

                doorWidthRow.Cells.Add(doorWidthLBLCell);
                doorWidthRow.Cells.Add(doorWidthDDLCell);

                #endregion

                #region Table:Seventh Row Custom Width Of Door Added To Table (tblDoorDetails)

                doorCustomWidthLBLCell.Controls.Add(doorCustomWidthLBL);
                doorCustomWidthTXTCell.Controls.Add(doorCustomWidthTXT);
                doorCustomWidthDDLCell.Controls.Add(inchCustomWidth);

                tblDoorDetails.Rows.Add(doorCustomWidthRow);

                doorCustomWidthRow.Cells.Add(doorCustomWidthLBLCell);
                doorCustomWidthRow.Cells.Add(doorCustomWidthTXTCell);
                doorCustomWidthRow.Cells.Add(doorCustomWidthDDLCell);

                #endregion

                #region Table:Eight Row Door Primary Operator LHH Added To Table (tblDoorDetails)

                doorOperatorLHHLBLCell.Controls.Add(doorOperatorLHHLBLMain);

                doorOperatorLHHRADCell.Controls.Add(doorOperatorLHHRad);
                doorOperatorLHHRADCell.Controls.Add(doorOperatorLHHLBLRad);
                doorOperatorLHHRADCell.Controls.Add(doorOperatorLHHLBL);

                tblDoorDetails.Rows.Add(doorOperatorLHHRow);

                doorOperatorLHHRow.Cells.Add(doorOperatorLHHLBLCell);
                doorOperatorLHHRow.Cells.Add(doorOperatorLHHRADCell);

                #endregion

                #region Table:Ninth Row Door Primary Operator RHH Added To Table (tblDoorDetails)

                doorOperatorRHHRADCell.Controls.Add(doorOperatorRHHRad);
                doorOperatorRHHRADCell.Controls.Add(doorOperatorRHHLBLRad);
                doorOperatorRHHRADCell.Controls.Add(doorOperatorRHHLBL);

                tblDoorDetails.Rows.Add(doorOperatorRHHRow);

                doorOperatorRHHRow.Cells.Add(doorOperatorRHHLBLCell);
                doorOperatorRHHRow.Cells.Add(doorOperatorRHHRADCell);

                #endregion

                #region Table:Tenth Row Door Box Header Position (tblDoorDetails)

                doorBoxHeaderLBLCell.Controls.Add(doorBoxHeaderLBL);
                doorBoxHeaderDDLCell.Controls.Add(doorBoxHeaderDDL);

                tblDoorDetails.Rows.Add(doorBoxHeaderRow);

                doorBoxHeaderRow.Cells.Add(doorBoxHeaderLBLCell);
                doorBoxHeaderRow.Cells.Add(doorBoxHeaderDDLCell);

                #endregion

                #region Table:Thirteenth Row Door Glass Tint Added To Table (tblDoorDetails)

                doorGlassTintLBLCell.Controls.Add(doorGlassTintLBL);
                doorGlassTintDDLCell.Controls.Add(doorGlassTintDDL);

                tblDoorDetails.Rows.Add(doorGlassTintRow);

                doorGlassTintRow.Cells.Add(doorGlassTintLBLCell);
                doorGlassTintRow.Cells.Add(doorGlassTintDDLCell);

                #endregion

                #region Table:Tenth Row Door Hinge LHH Added To Table (tblDoorDetails)

                doorHingeLHHLBLCell.Controls.Add(doorHingeLHHLBLMain);

                doorHingeLHHRADCell.Controls.Add(doorHingeLHHRad);
                doorHingeLHHRADCell.Controls.Add(doorHingeLHHLBLRad);
                doorHingeLHHRADCell.Controls.Add(doorHingeLHHLBL);

                tblDoorDetails.Rows.Add(doorHingeLHHRow);

                doorHingeLHHRow.Cells.Add(doorHingeLHHLBLCell);
                doorHingeLHHRow.Cells.Add(doorHingeLHHRADCell);

                #endregion

                #region Table:Eleventh Row Door Hinge RHH Added To Table (tblDoorDetails)

                doorHingeRHHRADCell.Controls.Add(doorHingeRHHRad);
                doorHingeRHHRADCell.Controls.Add(doorHingeRHHLBLRad);
                doorHingeRHHRADCell.Controls.Add(doorHingeRHHLBL);

                tblDoorDetails.Rows.Add(doorHingeRHHRow);

                doorHingeRHHRow.Cells.Add(doorHingeRHHLBLCell);
                doorHingeRHHRow.Cells.Add(doorHingeRHHRADCell);

                #endregion

                #region Table:Fourteenth Row Door Screen Options Added To Table (tblDoorDetails)

                doorScreenTypesLBLCell.Controls.Add(doorScreenTypesLBL);
                doorScreenTypesDDLCell.Controls.Add(doorScreenTypesDDL);

                tblDoorDetails.Rows.Add(doorScreenTypesRow);

                doorScreenTypesRow.Cells.Add(doorScreenTypesLBLCell);
                doorScreenTypesRow.Cells.Add(doorScreenTypesDDLCell);

                #endregion

                #region Table:Fifteenth Row Door Hardware Added To Table (tblDoorDetails)

                doorHardwareLBLCell.Controls.Add(doorHardwareLBL);
                doorHardwareDDLCell.Controls.Add(doorHardwareDDL);

                tblDoorDetails.Rows.Add(doorHardwareRow);

                doorHardwareRow.Cells.Add(doorHardwareLBLCell);
                doorHardwareRow.Cells.Add(doorHardwareDDLCell);

                #endregion

                #region Table:Eight Row Swing In Added To Table (tblDoorDetails)

                doorSwingInLBLCell.Controls.Add(doorSwingInLBLMain);

                doorSwingInRADCell.Controls.Add(doorSwingInRAD);
                doorSwingInRADCell.Controls.Add(doorSwingInLBLRad);
                doorSwingInRADCell.Controls.Add(doorSwingInLBL);

                tblDoorDetails.Rows.Add(doorSwingInRow);

                doorSwingInRow.Cells.Add(doorSwingInLBLCell);
                doorSwingInRow.Cells.Add(doorSwingInRADCell);

                #endregion

                #region Table:Ninth Row Swing Out Added To Table (tblDoorDetails)

                doorSwingOutRADCell.Controls.Add(doorSwingOutRAD);
                doorSwingOutRADCell.Controls.Add(doorSwingOutLBLRad);
                doorSwingOutRADCell.Controls.Add(doorSwingOutLBL);

                tblDoorDetails.Rows.Add(doorSwingOutRow);

                doorSwingOutRow.Cells.Add(doorSwingOutLBLCell);
                doorSwingOutRow.Cells.Add(doorSwingOutRADCell);

                #endregion

                #region Table:# Row Add This Door (tblDoorDetails)

                //doorAddButtonCell.Controls.Add(new LiteralControl("<input id='btnAddthisDoor" + title + "' type='button' onclick='addDoor(\"" + title + "\")' class='btnSubmit' style='display:inherit;' value='Add This " + title + " Door'/>"));
                doorAddButtonCell.Controls.Add(doorButton);

                tblDoorDetails.Rows.Add(doorButtonRow);

                doorButtonRow.Cells.Add(doorAddButtonCell);

                #endregion

                //Adding literal control div tag to hold the table, add to DoorOptions placeholder
                DoorOptions.Controls.Add(new LiteralControl("<div class=\"toggleContent\" id=\"div_" + title + "\">"));

                DoorOptions.Controls.Add(new LiteralControl("<ul>"));

                //Adding literal control li to keep proper page look and format
                DoorOptions.Controls.Add(new LiteralControl("<li>"));

                //Adding table to placeholder DoorOptions
                DoorOptions.Controls.Add(tblDoorDetails);

                //Closing necessary tags
                DoorOptions.Controls.Add(new LiteralControl("</li>"));

                DoorOptions.Controls.Add(new LiteralControl("</ul>"));

                DoorOptions.Controls.Add(new LiteralControl("</div>"));

                DoorOptions.Controls.Add(new LiteralControl("</li>"));

            }
            #endregion

            #region PostBack functionality to store doors
            if (IsPostBack)
            {
                if ((List<Door>)Session["doorsOrdered"] != null)
                {
                    doorsOrdered = (List<Door>)Session["doorsOrdered"];
                }
                
                if (Request.Form["ctl00$MainContent$doorTypeRadios"] == "radTypeCabana")
                {
                    Door aDoor = getCabanaDoorFromForm();
                    doorsOrdered.Add(aDoor);
                }
                else if (Request.Form["ctl00$MainContent$doorTypeRadios"] == "radTypeFrench")
                {
                    Door aDoor = getFrenchDoorFromForm();
                    doorsOrdered.Add(aDoor);
                }
                else if (Request.Form["ctl00$MainContent$doorTypeRadios"] == "radTypePatio")
                {
                    Door aDoor = getPatioDoorFromForm();
                    doorsOrdered.Add(aDoor);
                }
                Session.Add("doorsOrdered", doorsOrdered);
            }
            #endregion
            
            populateSideBar(findNumberOfDoorTypes());
        }

        /// <summary>
        /// This function creates rows in a table containing information
        /// on individual window tints for a Vertical 4 Track
        /// </summary>
        /// <param name="title"></param>
        /// <param name="tblDoorDetails"></param>
        protected void addMixedTintDropdowns(string title, Table tblDoorDetails)
        {
            for (int j = 0; j < 4; j++)
            {
                TableRow mixedDoorTintRow = new TableRow();
                //mixedDoorTintRow.Attributes.Add("style", "display: inherit;");
                mixedDoorTintRow.ID = "row" + j + "DoorTint" + title;
                mixedDoorTintRow.Attributes.Add("style", "display:none;");
                TableCell mixedDoorTintLabelCell = new TableCell();
                TableCell mixedDoorTintDropDownCell = new TableCell();

                Label mixedDoorTintLabel = new Label();
                mixedDoorTintLabel.ID = "lblDoorVinyl" + j + "Tint" + title;
                mixedDoorTintLabel.Text = "Vinyl Vent " + (j + 1) + " Tint : ";
                DropDownList ddlDoorTintOptions = new DropDownList();
                ddlDoorTintOptions.ID = "ddlDoorTint" + j + title;
                ListItem clearVinyl = new ListItem("Clear", "C");
                ListItem smokeGreyVinyl = new ListItem("Smoke Grey", "S");
                ListItem darkGreyVinyl = new ListItem("Dark Grey", "D");
                ListItem bronzeVinyl = new ListItem("Bronze", "B");

                ddlDoorTintOptions.Items.Add(clearVinyl);
                ddlDoorTintOptions.Items.Add(smokeGreyVinyl);
                ddlDoorTintOptions.Items.Add(darkGreyVinyl);
                ddlDoorTintOptions.Items.Add(bronzeVinyl);

                mixedDoorTintLabel.AssociatedControlID = "ddlDoorTint" + j + title;

                mixedDoorTintLabelCell.Controls.Add(mixedDoorTintLabel);
                mixedDoorTintDropDownCell.Controls.Add(ddlDoorTintOptions);

                tblDoorDetails.Rows.Add(mixedDoorTintRow);

                mixedDoorTintRow.Cells.Add(mixedDoorTintLabelCell);
                mixedDoorTintRow.Cells.Add(mixedDoorTintDropDownCell);
            }
        }

        /// <summary>
        /// This function creates a CabanaDoor object and stores the
        /// information entered on the page.
        /// </summary>
        /// <returns>CabanaDoor aDoor</returns>
        protected CabanaDoor getCabanaDoorFromForm()
        {
            CabanaDoor aDoor = new CabanaDoor();
            //moduleitem attributes
            aDoor.FEndHeight = aDoor.FStartHeight = 0;
            aDoor.FLength = 0;
            aDoor.Colour = Request.Form["ctl00$MainContent$ddlDoorColourCabana"];
            aDoor.ItemType = "Door";

            //base attributes
            aDoor.DoorType = "Cabana";
            aDoor.DoorStyle = Request.Form["ctl00$MainContent$ddlDoorStyleCabana"];
            aDoor.Kickplate = float.Parse(Request.Form["ctl00$MainContent$ddlDoorKickplateCabana"]);

            //cabana attributes
            aDoor.Height = float.Parse(Request.Form["ctl00$MainContent$ddlDoorHeightCabana"]);
            aDoor.Length = float.Parse(Request.Form["ctl00$MainContent$ddlDoorWidthCabana"]);
            aDoor.GlassTint = Request.Form["ctl00$MainContent$ddlDoorGlassTintCabana"];
            if (aDoor.DoorStyle == "Vertical 4 Track")
            {
                aDoor.VinylTint = Request.Form["ctl00$MainContent$ddlDoorVinylTintCabana"];
                aDoor.DoorWindow = new Window();
                aDoor.DoorWindow.NumVents = int.Parse(Request.Form["ctl00$MainContent$ddlDoorNumberOfVentsCabana"]);
                if (aDoor.VinylTint == "Mixed")
                {
                    if (aDoor.DoorWindow.NumVents == 2)
                    {
                        aDoor.VinylTint = Request.Form["ctl00$MainContent$ddlDoorTint0Cabana"] + Request.Form["ctl00$MainContent$ddlDoorTint1Cabana"];
                    }
                    else if (aDoor.DoorWindow.NumVents == 3)
                    {
                        aDoor.VinylTint = Request.Form["ctl00$MainContent$ddlDoorTint0Cabana"]
                            + Request.Form["ctl00$MainContent$ddlDoorTint1Cabana"]
                            + Request.Form["ctl00$MainContent$ddlDoorTint2Cabana"];
                    }
                    else if (aDoor.DoorWindow.NumVents == 4)
                    {
                        aDoor.VinylTint = Request.Form["ctl00$MainContent$ddlDoorTint0Cabana"]
                            + Request.Form["ctl00$MainContent$ddlDoorTint1Cabana"]
                            + Request.Form["ctl00$MainContent$ddlDoorTint2Cabana"]
                            + Request.Form["ctl00$MainContent$ddlDoorTint3Cabana"];
                    }
                }
            }
            else
            {
                aDoor.ScreenType = Request.Form["ctl00$MainContent$ddlDoorScreenOptionsCabana"];
            }
            aDoor.Hinge = Request.Form["ctl00$MainContent$DoorHingeCabana"];
            aDoor.Swing = Request.Form["ctl00$MainContent$SwingInOutCabana"];
            aDoor.HardwareType = Request.Form["ctl00$MainContent$ddlDoorHardwareCabana"];

            return aDoor;
        }

        /// <summary>
        /// This function creates a FrenchDoor object and stores the
        /// information entered on the page.
        /// </summary>
        /// <returns>FrenchDoor aDoor</returns>
        protected FrenchDoor getFrenchDoorFromForm()
        {
            FrenchDoor aDoor = new FrenchDoor();
            //moduleitem attributes
            aDoor.FEndHeight = aDoor.FStartHeight = 0;
            aDoor.FLength = 0;
            aDoor.Colour = Request.Form["ctl00$MainContent$ddlDoorColourFrench"];
            aDoor.ItemType = "Door";

            //base attributes
            aDoor.DoorType = "French";
            aDoor.DoorStyle = Request.Form["ctl00$MainContent$ddlDoorStyleFrench"];
            aDoor.Kickplate = float.Parse(Request.Form["ctl00$MainContent$ddlDoorKickplateFrench"]);

            //french attributes
            aDoor.Height = float.Parse(Request.Form["ctl00$MainContent$ddlDoorHeightFrench"]);
            aDoor.Length = float.Parse(Request.Form["ctl00$MainContent$ddlDoorWidthFrench"]);
            aDoor.GlassTint = Request.Form["ctl00$MainContent$ddlDoorGlassTintFrench"];
            if (aDoor.DoorStyle == "Vertical 4 Track")
            {
                aDoor.VinylTint = Request.Form["ctl00$MainContent$ddlDoorVinylTintFrench"];
                aDoor.DoorWindow = new Window();
                aDoor.DoorWindow.NumVents = int.Parse(Request.Form["ctl00$MainContent$ddlDoorNumberOfVentsFrench"]);
                if (aDoor.VinylTint == "Mixed")
                {
                    if (aDoor.DoorWindow.NumVents == 2)
                    {
                        aDoor.VinylTint = Request.Form["ctl00$MainContent$ddlDoorTint0French"]
                            + Request.Form["ctl00$MainContent$ddlDoorTint1French"];
                    }
                    else if (aDoor.DoorWindow.NumVents == 3)
                    {
                        aDoor.VinylTint = Request.Form["ctl00$MainContent$ddlDoorTint0French"]
                            + Request.Form["ctl00$MainContent$ddlDoorTint1French"]
                            + Request.Form["ctl00$MainContent$ddlDoorTint2French"];
                    }
                    else if (aDoor.DoorWindow.NumVents == 4)
                    {
                        aDoor.VinylTint = Request.Form["ctl00$MainContent$ddlDoorTint0French"]
                            + Request.Form["ctl00$MainContent$ddlDoorTint1French"]
                            + Request.Form["ctl00$MainContent$ddlDoorTint2French"]
                            + Request.Form["ctl00$MainContent$ddlDoorTint3French"];
                    }
                }
            }
            aDoor.ScreenType = Request.Form["ctl00$MainContent$ddlDoorScreenOptionsFrench"];
            aDoor.OperatingDoor = Request.Form["ctl00$MainContent$PrimaryOperatorFrench"]; 
            aDoor.Swing = Request.Form["ctl00$MainContent$SwingInOutFrench"];
            aDoor.HardwareType = Request.Form["ctl00$MainContent$ddlDoorHardwareFrench"];

            return aDoor;
        }

        /// <summary>
        /// This function creates a PatioDoor object and stores the
        /// information entered on the page.
        /// </summary>
        /// <returns>PatioDoor aDoor</returns>
        protected PatioDoor getPatioDoorFromForm()
        {
            PatioDoor aDoor = new PatioDoor();
            //moduleitem attributes
            aDoor.FEndHeight = aDoor.FStartHeight = 0;
            aDoor.FLength = 0;
            aDoor.Colour = Request.Form["ctl00$MainContent$ddlDoorColourPatio"];
            aDoor.ItemType = "Door";

            //base attributes
            aDoor.DoorType = "Patio";
            aDoor.DoorStyle = Request.Form["ctl00$MainContent$ddlDoorStylePatio"];
            //aDoor.ScreenType = ""; //CHANGEME
            aDoor.Kickplate = float.Parse(Request.Form["ctl00$MainContent$ddlDoorKickplatePatio"]);

            //patio attributes
            aDoor.Height = float.Parse(Request.Form["ctl00$MainContent$ddlDoorHeightPatio"]);
            aDoor.Length = float.Parse(Request.Form["ctl00$MainContent$ddlDoorWidthPatio"]);
            aDoor.GlassTint = Request.Form["ctl00$MainContent$ddlDoorGlassTintPatio"];
            //aDoor.ScreenType = ""; //CHANGEME
            aDoor.OperatingDoor = Request.Form["ctl00$MainContent$PrimaryOperatorPatio"];

            return aDoor;
        }
        
        /// <summary>
        /// This function is used to find the amount of each type of 
        /// door that has been ordered.
        /// </summary>
        /// <returns>Tuple<int,int,int>(cabanaCount,frenchCount,patioCount)</returns>
        /// NOTE Tuple items:
        /// Item1:Cabana door count
        /// Item2:French door count
        /// Item3:Patio door count
        private Tuple<int,int,int> findNumberOfDoorTypes() {
            int cabanaCount = 0, frenchCount = 0, patioCount = 0;
            doorsOrdered.ForEach(delegate(Door doorChecked)
            {
                if (doorChecked is CabanaDoor)
                    cabanaCount++;
                else if (doorChecked is FrenchDoor)
                    frenchCount++;
                else if (doorChecked is PatioDoor)
                    patioCount++;
            });
            //System.Diagnostics.Debug.Write("This is the cabana count: " + cabanaCount);
            return new Tuple<int,int,int>(cabanaCount,frenchCount,patioCount);
        }
        
        /// <summary>
        /// This function is used to populate the side bar which displays
        /// information regarding how many doors of each type have been ordered,
        /// along with individual door information. This is done in an accordion
        /// style to hide unneeded data.
        /// </summary>
        /// <param name="doorTypeCounts"></param>
        private void populateSideBar(Tuple<int,int,int> doorTypeCounts) {

            int count;

            lblDoorPager.Controls.Add(new LiteralControl("<ul class='toggleOptions'>"));

            if (doorTypeCounts.Item1 > 0)
            {
                lblDoorPager.Controls.Add(new LiteralControl("<li id='cabanaDoors'>"));
                
                Label cabanaLabel = new Label();
                cabanaLabel.ID = "lblCabanaDoors";
                cabanaLabel.Text = "Cabana Doors Ordered " + doorTypeCounts.Item1;
                lblDoorPager.Controls.Add(cabanaLabel);                

                count = 1;

                #region Creating Cabana door pager items
                foreach (Door aDoor in doorsOrdered){
                    if (aDoor.DoorType == "Cabana")
                    {
                        lblDoorPager.Controls.Add(new LiteralControl("<div class='toggleContent'>"));

                        CabanaDoor aCabana = (CabanaDoor)aDoor;

                        Label cabanaCurrentDoor = new Label();
                        cabanaCurrentDoor.ID = "lblCabanaCabana" + count;
                        cabanaCurrentDoor.Text = "Cabana Door " + count;
                        lblDoorPager.Controls.Add(cabanaCurrentDoor);

                        Label cabanaStyle = new Label();
                        cabanaStyle.ID = "lblCabanaStyle" + count;
                        cabanaStyle.Text = "Style: " + aCabana.DoorStyle;
                        lblDoorPager.Controls.Add(cabanaStyle);

                        Label cabanaColour = new Label();
                        cabanaColour.ID = "lblCabanaColour" + count;
                        cabanaColour.Text = "Colour: " + aCabana.Colour;
                        lblDoorPager.Controls.Add(cabanaColour);

                        Label cabanaKickplate = new Label();
                        cabanaKickplate.ID = "lblCabanaKickplate" + count;
                        cabanaKickplate.Text = "Kickplate: " + String.Format("{0}", aCabana.Kickplate);
                        lblDoorPager.Controls.Add(cabanaKickplate);

                        Label cabanaHeight = new Label();
                        cabanaHeight.ID = "lblCabanaHeight" + count;
                        cabanaHeight.Text = "Height: " + String.Format("{0}", aCabana.Height);
                        lblDoorPager.Controls.Add(cabanaHeight);

                        Label cabanaLength = new Label();
                        cabanaLength.ID = "lblCabanaLength" + count;
                        cabanaLength.Text = "Width: " + String.Format("{0}", aCabana.Length);
                        lblDoorPager.Controls.Add(cabanaLength);

                        Label cabanaGlassTint = new Label();
                        cabanaGlassTint.ID = "lblCabanaGlassTint" + count;
                        cabanaGlassTint.Text = "Glass Tint: " + aCabana.GlassTint;
                        lblDoorPager.Controls.Add(cabanaGlassTint);

                        if (aCabana.DoorStyle == "Vertical 4 Track")
                        {
                            Label cabanaNumVents = new Label();
                            cabanaNumVents.ID = "lblCabanaNumVents" + count;
                            cabanaNumVents.Text = "No. Vents: " + String.Format("{0}", aCabana.DoorWindow.NumVents);
                            lblDoorPager.Controls.Add(cabanaNumVents);

                            Label cabanaVinylTint = new Label();
                            cabanaVinylTint.ID = "lblCabanaVinylTint" + count;
                            cabanaVinylTint.Text = "Vinyl Tint: " + aCabana.VinylTint;
                            lblDoorPager.Controls.Add(cabanaVinylTint);
                        }
                        else
                        {
                            Label cabanaScreenType = new Label();
                            cabanaScreenType.ID = "lblCabanaScreenType" + count;
                            cabanaScreenType.Text = "Screen Type: " + aCabana.ScreenType;
                            lblDoorPager.Controls.Add(cabanaScreenType);
                        }

                        Label cabanaHinge = new Label();
                        cabanaHinge.ID = "lblCabanaHinge" + count;
                        cabanaHinge.Text = "Hinge: " + aCabana.Hinge;
                        lblDoorPager.Controls.Add(cabanaHinge);

                        Label cabanaSwing = new Label();
                        cabanaSwing.ID = "lblCabanaSwing" + count;
                        cabanaSwing.Text = "Swing: " + aCabana.Swing;
                        lblDoorPager.Controls.Add(cabanaSwing);

                        Label cabanaHardwareType = new Label();
                        cabanaHardwareType.ID = "lblCabanaHardwareType" + count;
                        cabanaHardwareType.Text = "Hardware: " + aCabana.HardwareType;
                        lblDoorPager.Controls.Add(cabanaHardwareType);


                        lblDoorPager.Controls.Add(new LiteralControl("</div>"));

                        count++;
                    }
                }
                #endregion

                lblDoorPager.Controls.Add(new LiteralControl("</li>"));
            }
            if (doorTypeCounts.Item2 > 0)
            {
                lblDoorPager.Controls.Add(new LiteralControl("<li id='frenchDoors'>"));

                Label frenchLabel = new Label();
                frenchLabel.ID = "lblFrenchDoors";
                frenchLabel.Text = "French Doors Ordered " + doorTypeCounts.Item2;
                lblDoorPager.Controls.Add(frenchLabel);
                
                count = 1;

                #region Creating French door pager items
                foreach (Door aDoor in doorsOrdered)
                {
                    if (aDoor.DoorType == "French")
                    {
                        lblDoorPager.Controls.Add(new LiteralControl("<div class='toggleContent'>"));

                        FrenchDoor aFrench = (FrenchDoor)aDoor;

                        Label frenchCurrentDoor = new Label();
                        frenchCurrentDoor.ID = "lblFrenchFrench" + count;
                        frenchCurrentDoor.Text = "French Door " + count;
                        lblDoorPager.Controls.Add(frenchCurrentDoor);

                        Label frenchStyle = new Label();
                        frenchStyle.ID = "lblFrenchStyle" + count;
                        frenchStyle.Text = "Style: " + aFrench.DoorStyle;
                        lblDoorPager.Controls.Add(frenchStyle);

                        Label frenchColour = new Label();
                        frenchColour.ID = "lblFrenchColour" + count;
                        frenchColour.Text = "Colour: " + aFrench.Colour;
                        lblDoorPager.Controls.Add(frenchColour);

                        Label frenchKickplate = new Label();
                        frenchKickplate.ID = "lblFrenchKickplate" + count;
                        frenchKickplate.Text = "Kickplate: " + String.Format("{0}", aFrench.Kickplate);
                        lblDoorPager.Controls.Add(frenchKickplate);

                        Label frenchHeight = new Label();
                        frenchHeight.ID = "lblFrenchHeight" + count;
                        frenchHeight.Text = "Height: " + String.Format("{0}", aFrench.Height);
                        lblDoorPager.Controls.Add(frenchHeight);

                        Label frenchLength = new Label();
                        frenchLength.ID = "lblFrenchLength" + count;
                        frenchLength.Text = "Width: " + String.Format("{0}", aFrench.Length);
                        lblDoorPager.Controls.Add(frenchLength);

                        Label frenchGlassTint = new Label();
                        frenchGlassTint.ID = "lblFrenchGlassTint" + count;
                        frenchGlassTint.Text = "Glass Tint: " + aFrench.GlassTint;
                        lblDoorPager.Controls.Add(frenchGlassTint);

                        if (aFrench.DoorStyle == "Vertical 4 Track")
                        {
                            Label frenchNumVents = new Label();
                            frenchNumVents.ID = "lblFrenchNumVents" + count;
                            frenchNumVents.Text = "No. Vents: " + String.Format("{0}", aFrench.DoorWindow.NumVents);
                            lblDoorPager.Controls.Add(frenchNumVents);

                            Label frenchVinylTint = new Label();
                            frenchVinylTint.ID = "lblFrenchVinylTint" + count;
                            frenchVinylTint.Text = "Vinyl Tint: " + aFrench.VinylTint;
                            lblDoorPager.Controls.Add(frenchVinylTint);
                        }
                        else
                        {
                            Label frenchScreenType = new Label();
                            frenchScreenType.ID = "lblFrenchScreenType" + count;
                            frenchScreenType.Text = "Screen Type: " + aFrench.ScreenType;
                            lblDoorPager.Controls.Add(frenchScreenType);
                        }

                        Label frenchOperatingDoor = new Label();
                        frenchOperatingDoor.ID = "lblFrenchOperatingDoor" + count;
                        frenchOperatingDoor.Text = "Operating Door: " + aFrench.OperatingDoor;
                        lblDoorPager.Controls.Add(frenchOperatingDoor);

                        Label frenchSwing = new Label();
                        frenchSwing.ID = "lblFrenchSwing" + count;
                        frenchSwing.Text = "Swing: " + aFrench.Swing;
                        lblDoorPager.Controls.Add(frenchSwing);

                        Label frenchHardwareType = new Label();
                        frenchHardwareType.ID = "lblFrenchHardwareType" + count;
                        frenchHardwareType.Text = "Hardware: " + aFrench.HardwareType;
                        lblDoorPager.Controls.Add(frenchHardwareType);

                        lblDoorPager.Controls.Add(new LiteralControl("</div>"));

                        count++;
                    }
                }
                #endregion

                lblDoorPager.Controls.Add(new LiteralControl("</li>"));
            }
            if (doorTypeCounts.Item3 > 0)
            {
                lblDoorPager.Controls.Add(new LiteralControl("<li id='patioDoors'>"));

                Label patioLabel = new Label();
                patioLabel.ID = "lblPatioDoors";
                patioLabel.Text = "Patio Doors Ordered " + doorTypeCounts.Item3;
                lblDoorPager.Controls.Add(patioLabel);
                
                count = 1;

                #region Creating Patio door pager items
                foreach (Door aDoor in doorsOrdered)
                {
                    if (aDoor.DoorType == "Patio")
                    {
                        lblDoorPager.Controls.Add(new LiteralControl("<div class='toggleContent'>"));

                        PatioDoor aPatio = (PatioDoor)aDoor;

                        Label patioCurrentDoor = new Label();
                        patioCurrentDoor.ID = "lblPatioPatio" + count;
                        patioCurrentDoor.Text = "Patio Door " + count;
                        lblDoorPager.Controls.Add(patioCurrentDoor);

                        Label patioStyle = new Label();
                        patioStyle.ID = "lblPatioStyle" + count;
                        patioStyle.Text = "Style: " + aPatio.DoorStyle;
                        lblDoorPager.Controls.Add(patioStyle);

                        Label patioColour = new Label();
                        patioColour.ID = "lblPatioColour" + count;
                        patioColour.Text = "Colour: " + aPatio.Colour;
                        lblDoorPager.Controls.Add(patioColour);

                        Label patioKickplate = new Label();
                        patioKickplate.ID = "lblPatioKickplate" + count;
                        patioKickplate.Text = "Kickplate: " + String.Format("{0}", aPatio.Kickplate);
                        lblDoorPager.Controls.Add(patioKickplate);

                        Label patioHeight = new Label();
                        patioHeight.ID = "lblPatioHeight" + count;
                        patioHeight.Text = "Height: " + String.Format("{0}", aPatio.Height);
                        lblDoorPager.Controls.Add(patioHeight);

                        Label patioLength = new Label();
                        patioLength.ID = "lblPatioLength" + count;
                        patioLength.Text = "Width: " + String.Format("{0}", aPatio.Length);
                        lblDoorPager.Controls.Add(patioLength);

                        Label patioGlassTint = new Label();
                        patioGlassTint.ID = "lblPatioGlassTint" + count;
                        patioGlassTint.Text = "Glass Tint: " + aPatio.GlassTint;
                        lblDoorPager.Controls.Add(patioGlassTint);

                        Label patioScreenType = new Label();
                        patioScreenType.ID = "lblPatioScreenType" + count;
                        patioScreenType.Text = "Screen Type: " + aPatio.ScreenType;
                        lblDoorPager.Controls.Add(patioScreenType);

                        Label patioOperatingDoor = new Label();
                        patioOperatingDoor.ID = "lblPatioOperatingDoor" + count;
                        patioOperatingDoor.Text = "Operating Door: " + aPatio.OperatingDoor;
                        lblDoorPager.Controls.Add(patioOperatingDoor);

                        lblDoorPager.Controls.Add(new LiteralControl("</div>"));

                        count++;
                    }
                }
                #endregion

                lblDoorPager.Controls.Add(new LiteralControl("</li>"));
            }

            lblDoorPager.Controls.Add(new LiteralControl("</ul>"));
            
        }
    }
}
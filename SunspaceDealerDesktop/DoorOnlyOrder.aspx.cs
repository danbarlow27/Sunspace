using System;
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

                ddlDoorTintOptions.Attributes.Add("onchange", "checkQuestion3()");

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

        protected void Page_Load(object sender, EventArgs e)
        {
            #region Loop to display door types as radio buttons

            //For loop to get through all the possible door types: Cabana, French, Patio, Opening Only (No Door)
            for (int typeCount = 0; typeCount < 4; typeCount++)
            {
                //Conditional operator to set the current door type with the right label
                string title = Constants.DOOR_TYPES[typeCount]; //(typeCount == 1) ? "Cabana" : (typeCount == 2) ? "French" : (typeCount == 3) ? "Patio" : "NoDoor";

                //li tag to hold door type radio button and all its content
                DoorOptions.Controls.Add(new LiteralControl("<li>"));

                //Door type radio button
                RadioButton typeRadio = new RadioButton();
                typeRadio.ID = "radType" + title; //Adding appropriate id to door type radio button
                typeRadio.GroupName = "doorTypeRadios";         //Adding group name for all door types
                typeRadio.Attributes.Add("onclick", "typeRowsDisplayed('" + title + "')"); //On click event to display the proper fields/rows


                //Door type radio button label for clickable area
                Label typeLabelRadio = new Label();
                typeLabelRadio.AssociatedControlID = "radType" + title;   //Tying this label to the radio button

                //Door type radio button label text
                Label typeLabel = new Label();
                typeLabel.AssociatedControlID = "radType" + title;    //Tying this label to the radio button
                if (title == "NoDoor")
                {
                    typeLabel.Text = "Opening Only (No Door)";
                }
                else
                {
                    typeLabel.Text = title;     //Displaying the proper texted based on current title variable
                }

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
                doorStyleDDL.Attributes.Add("onchange", "doorStyle('" + title + "','" + "'); checkQuestion3();");
                if (title == "Patio")
                {
                    for (int j = 0; j < Constants.DOOR_MODEL_100_PATIO_STYLES.Count(); j++)
                    {
                        doorStyleDDL.Items.Add(new ListItem(Constants.DOOR_MODEL_100_PATIO_STYLES[j], Constants.DOOR_MODEL_100_PATIO_STYLES[j]));
                    }
                }
                else
                {
                    for (int j = 0; j < Constants.DOOR_MODEL_100_STYLES.Count(); j++)
                    {
                        doorStyleDDL.Items.Add(new ListItem(Constants.DOOR_MODEL_100_STYLES[j], Constants.DOOR_MODEL_100_STYLES[j]));
                    }
                }
                if (title == "Patio")
                {
                    for (int j = 0; j < Constants.DOOR_MODEL_200_300_PATIO_STYLES.Count(); j++)
                    {
                        doorStyleDDL.Items.Add(new ListItem(Constants.DOOR_MODEL_200_300_PATIO_STYLES[j], Constants.DOOR_MODEL_200_300_PATIO_STYLES[j]));
                    }
                }
                else
                {
                    for (int j = 0; j < Constants.DOOR_MODEL_200_STYLES.Count(); j++)
                    {
                        doorStyleDDL.Items.Add(new ListItem(Constants.DOOR_MODEL_200_STYLES[j], Constants.DOOR_MODEL_200_STYLES[j]));
                    }
                }
                if (title == "Patio")
                {
                    for (int j = 0; j < Constants.DOOR_MODEL_200_300_PATIO_STYLES.Count(); j++)
                    {
                        doorStyleDDL.Items.Add(new ListItem(Constants.DOOR_MODEL_200_300_PATIO_STYLES[j], Constants.DOOR_MODEL_200_300_PATIO_STYLES[j]));
                    }
                }
                else
                {
                    for (int j = 0; j < Constants.DOOR_MODEL_300_STYLES.Count(); j++)
                    {
                        doorStyleDDL.Items.Add(new ListItem(Constants.DOOR_MODEL_300_STYLES[j], Constants.DOOR_MODEL_300_STYLES[j]));
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
                for (int j = 0; j < Constants.DOOR_V4T_VINYL_OPTIONS.Count(); j++)
                {
                    doorVinylTintDDL.Items.Add(new ListItem(Constants.DOOR_V4T_VINYL_OPTIONS[j], Constants.DOOR_V4T_VINYL_OPTIONS[j]));
                }

                doorVinylTintDDL.Attributes.Add("onchange", "checkQuestion3()");
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
                for (int j = 0; j < Constants.DOOR_NUMBER_OF_VENTS.Count(); j++)
                {
                    doorNumberOfVentsDDL.Items.Add(new ListItem(Constants.DOOR_NUMBER_OF_VENTS[j], Constants.DOOR_NUMBER_OF_VENTS[j]));
                }

                doorNumberOfVentsLBL.AssociatedControlID = "ddlDoorNumberOfVents" + title;

                doorNumberOfVentsDDL.Attributes.Add("onchange", "checkQuestion3()");

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
                doorHeightDDL.Attributes.Add("onchange", "customDimension('" + "','" + title + "','Height')");
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
                doorWidthDDL.Attributes.Add("onchange", "customDimension('" + "', '" + title + "','Width')");

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
                doorHingeLHHLBLMain.Text = "Hinge placement:";

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

                #region Table:Fourteenth Row Door Screen Options (tblDoorDetails)

                TableRow doorScreenOptionsRow = new TableRow();
                doorScreenOptionsRow.ID = "rowDoorScreenOptions" + title;
                doorScreenOptionsRow.Attributes.Add("style", "display:none;");
                TableCell doorScreenOptionsLBLCell = new TableCell();
                TableCell doorScreenOptionsDDLCell = new TableCell();

                Label doorScreenOptionsLBL = new Label();
                doorScreenOptionsLBL.ID = "lblDoorScreenOptions" + title;
                doorScreenOptionsLBL.Text = "Door Screen Option:";

                DropDownList doorScreenOptionsDDL = new DropDownList();
                doorScreenOptionsDDL.ID = "ddlDoorScreenOptions" + title;
                for (int j = 0; j < Constants.SCREEN_TYPES.Count(); j++)
                {
                    doorScreenOptionsDDL.Items.Add(new ListItem(Constants.SCREEN_TYPES[j], Constants.SCREEN_TYPES[j]));
                }

                doorScreenOptionsLBL.AssociatedControlID = "ddlDoorScreenOptions" + title;

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
                doorPositionDDLDDL.Attributes.Add("onchange", "customDimension('" + "', '" + title + "','Position')");
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

                #region Table:# Row Door Position Custom (tblDoorDetails)

                TableRow doorPositionRow = new TableRow();
                doorPositionRow.ID = "rowDoorCustomPosition" + title;
                doorPositionRow.Attributes.Add("style", "display:none;");
                TableCell doorPositionLBLCell = new TableCell();
                TableCell doorPositionTXTCell = new TableCell();
                TableCell doorPositionDDLCell = new TableCell();

                Label doorPositionLBL = new Label();
                doorPositionLBL.ID = "lblDoorCustomPosition" + title;
                doorPositionLBL.Text = "Door position from left side (inches):";

                TextBox doorPositionTXT = new TextBox();
                doorPositionTXT.ID = "txtDoorPositionCustom" + title;
                doorPositionTXT.CssClass = "txtField txtDoorInput";
                doorPositionTXT.Attributes.Add("maxlength", "3");
                doorPositionTXT.Attributes.Add("onkeydown", "return (event.keyCode!=13);");

                DropDownList inchSpecificLeft = new DropDownList();
                inchSpecificLeft.ID = "ddlDoorPositionCustom" + title;
                inchSpecificLeft.Items.Add(lst0);
                inchSpecificLeft.Items.Add(lst18);
                inchSpecificLeft.Items.Add(lst14);
                inchSpecificLeft.Items.Add(lst38);
                inchSpecificLeft.Items.Add(lst12);
                inchSpecificLeft.Items.Add(lst58);
                inchSpecificLeft.Items.Add(lst34);
                inchSpecificLeft.Items.Add(lst78);

                doorPositionLBL.AssociatedControlID = "txtDoorPositionCustom" + title;

                #endregion

                #region Table:# Row Add This Door (tblDoorDetails)

                TableRow doorButtonRow = new TableRow();
                doorButtonRow.ID = "rowAddDoor" + title;
                doorButtonRow.Attributes.Add("style", "display:inherit;");
                TableCell doorAddButtonCell = new TableCell();
                TableCell doorFillButtonCell = new TableCell();

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

                doorScreenOptionsLBLCell.Controls.Add(doorScreenOptionsLBL);
                doorScreenOptionsDDLCell.Controls.Add(doorScreenOptionsDDL);

                tblDoorDetails.Rows.Add(doorScreenOptionsRow);

                doorScreenOptionsRow.Cells.Add(doorScreenOptionsLBLCell);
                doorScreenOptionsRow.Cells.Add(doorScreenOptionsDDLCell);

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

                #region Table:# Row Door Position DDL Added To Table (tblDoorDetails)

                doorPositionDDLLBLCell.Controls.Add(doorPositionDDLLBL);
                doorPositionDDLDDLCell.Controls.Add(doorPositionDDLDDL);

                tblDoorDetails.Rows.Add(doorPositionDDLRow);


                doorPositionDDLRow.Cells.Add(doorPositionDDLLBLCell);
                doorPositionDDLRow.Cells.Add(doorPositionDDLDDLCell);

                #endregion

                #region Table:# Row Door Position Added To Table (tblDoorDetails)

                doorPositionLBLCell.Controls.Add(doorPositionLBL);
                doorPositionTXTCell.Controls.Add(doorPositionTXT);
                doorPositionDDLCell.Controls.Add(inchSpecificLeft);

                tblDoorDetails.Rows.Add(doorPositionRow);

                doorPositionRow.Cells.Add(doorPositionLBLCell);
                doorPositionRow.Cells.Add(doorPositionTXTCell);
                doorPositionRow.Cells.Add(doorPositionDDLCell);

                #endregion

                #region Table:# Row Add This Door (tblDoorDetails)

                if (title == "NoDoor")
                {
                    doorAddButtonCell.Controls.Add(new LiteralControl("<input id='btnAddthisDoor" + title + "' type='button' onclick='addDoor(\"" + "\", \"" + title + "\")' class='btnSubmit' style='display:inherit;' value='Add This Opening Only (No Door)'/>"));
                }
                else
                {
                    doorAddButtonCell.Controls.Add(new LiteralControl("<input id='btnAddthisDoor" + title + "' type='button' onclick='addDoor(\"" + "\", \"" + title + "\")' class='btnSubmit' style='display:inherit;' value='Add This " + title + " Door'/>"));
                }

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
        }
    }
}
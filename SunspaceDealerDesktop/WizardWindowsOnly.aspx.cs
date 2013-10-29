using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SunspaceDealerDesktop
{
    public partial class WizardWindowsOnly : System.Web.UI.Page
    {
        protected ListItem lst0 = new ListItem("---", "0", true); //0, i.e. no decimal value, selected by default
        protected ListItem lst18 = new ListItem("1/8", ".125");
        protected ListItem lst14 = new ListItem("1/4", ".25");
        protected ListItem lst38 = new ListItem("3/8", ".375");//
        protected ListItem lst12 = new ListItem("1/2", ".5");
        protected ListItem lst58 = new ListItem("5/8", ".625");
        protected ListItem lst34 = new ListItem("3/4", ".75");
        protected ListItem lst78 = new ListItem("7/8", ".875");

        protected void addMixedTintDropdowns(string title, Table tblWindowDetails)
        {
            for (int j = 0; j < 4; j++)
            {
                TableRow mixedWindowTintRow = new TableRow();
                //mixedWindowTintRow.Attributes.Add("style", "display: inherit;");
                mixedWindowTintRow.ID = "row" + j + "WindowTint" + title;
                mixedWindowTintRow.Attributes.Add("style", "display:none;");
                TableCell mixedWindowTintLabelCell = new TableCell();
                TableCell mixedWindowTintDropDownCell = new TableCell();

                Label mixedWindowTintLabel = new Label();
                mixedWindowTintLabel.ID = "lblWindowVinyl" + j + "Tint" + title;
                mixedWindowTintLabel.Text = "Vinyl Vent " + (j + 1) + " Tint : ";
                DropDownList ddlWindowTintOptions = new DropDownList();
                ddlWindowTintOptions.ID = "ddlWindowTint" + j + title;
                ListItem clearVinyl = new ListItem("Clear", "C");
                ListItem smokeGreyVinyl = new ListItem("Smoke Grey", "S");
                ListItem darkGreyVinyl = new ListItem("Dark Grey", "D");
                ListItem bronzeVinyl = new ListItem("Bronze", "B");

                ddlWindowTintOptions.Attributes.Add("onchange", "checkQuestion3()");

                ddlWindowTintOptions.Items.Add(clearVinyl);
                ddlWindowTintOptions.Items.Add(smokeGreyVinyl);
                ddlWindowTintOptions.Items.Add(darkGreyVinyl);
                ddlWindowTintOptions.Items.Add(bronzeVinyl);

                mixedWindowTintLabel.AssociatedControlID = "ddlWindowTint" + j + title;

                mixedWindowTintLabelCell.Controls.Add(mixedWindowTintLabel);
                mixedWindowTintDropDownCell.Controls.Add(ddlWindowTintOptions);

                tblWindowDetails.Rows.Add(mixedWindowTintRow);

                mixedWindowTintRow.Cells.Add(mixedWindowTintLabelCell);
                mixedWindowTintRow.Cells.Add(mixedWindowTintDropDownCell);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            #region Loop to display Window types as radio buttons

            //For loop to get through all the possible types of windows: Vinyl, Glass, Screen
            for (int typeCount = 0; typeCount < 3; typeCount++)
            {
                string title = typeCount == 0 ? "Vinyl" : typeCount == 1 ? "Glass" : "Screen";

                //li tag to hold window type radio button and all its content
                WindowOptions.Controls.Add(new LiteralControl("<li>"));
                
                //Window type radio button
                RadioButton typeRadio = new RadioButton();
                typeRadio.ID = "radType" + title; //Adding appropriate id to window type radio button
                typeRadio.GroupName = "windowTypeRadios";         //Adding group name for all window types
                typeRadio.Attributes.Add("onclick", "typeRowsDisplayed('" + title + "')"); //On click event to display the proper fields/rows


                //Window type radio button label for clickable area
                Label typeLabelRadio = new Label();
                typeLabelRadio.AssociatedControlID = "radType" + title;   //Tying this label to the radio button

                //Window type radio button label text
                Label typeLabel = new Label();
                typeLabel.AssociatedControlID = "radType" + title;    //Tying this label to the radio button
                typeLabel.Text = title;     //Displaying the proper texted based on current title variable


                WindowOptions.Controls.Add(typeRadio);        //Adding radio button control to placeholder WindowOptions
                WindowOptions.Controls.Add(typeLabelRadio);   //Adding label control to placeholder WindowOptions
                WindowOptions.Controls.Add(typeLabel);        //Adding label control to placeholder WindowOptions

                //New instance of a table for every window type
                Table tblWindowDetails = new Table();

                tblWindowDetails.ID = "tblWindowDetails" + title; //Adding appropriate id to the table
                tblWindowDetails.CssClass = "tblTextFields";                  //Adding CssClass to the table for styling


                //Creating cells and controls for rows

                #region Table:Default Row Title Current Window (tblWindowDetails)

                TableRow windowTitleRow = new TableRow();
                windowTitleRow.ID = "rowWindowTitle" + title;
                windowTitleRow.Attributes.Add("style", "display:none;");
                TableCell windowTitleLBLCell = new TableCell();

                Label windowTitleLBL = new Label();
                windowTitleLBL.ID = "lblWindowTitle" + title;
                windowTitleLBL.Text = "Select Window Details:";
                windowTitleLBL.Attributes.Add("style", "font-weight:bold;");

                #endregion

                #region Table:Second Row Window Style (tblWindowDetails)

                TableRow windowStyleRow = new TableRow();
                windowStyleRow.ID = "rowWindowStyle" + title;
                windowStyleRow.Attributes.Add("style", "display:none;");
                TableCell windowStyleLBLCell = new TableCell();
                TableCell windowStyleDDLCell = new TableCell();

                Label windowStyleLBL = new Label();
                windowStyleLBL.ID = "lblWindowStyle" + title;
                windowStyleLBL.Text = "Style";

                DropDownList windowStyleDDL = new DropDownList();
                windowStyleDDL.ID = "ddlWindowStyle" + title;
                windowStyleDDL.Attributes.Add("onchange", "windowStyle('" + title + "'); checkQuestion3();");
                if (title == "Patio")
                {
                    for (int j = 0; j < Constants.DOOR_ORDER_PATIO.Count(); j++)
                    {
                        windowStyleDDL.Items.Add(new ListItem(Constants.DOOR_ORDER_PATIO[j], Constants.DOOR_ORDER_PATIO[j]));
                    }
                }
                else
                {
                    for (int j = 0; j < Constants.DOOR_ORDER_ENTRY.Count(); j++)
                    {
                        windowStyleDDL.Items.Add(new ListItem(Constants.DOOR_ORDER_ENTRY[j], Constants.DOOR_ORDER_ENTRY[j]));
                    }
                }

                windowStyleLBL.AssociatedControlID = "ddlWindowStyle" + title;

                #endregion

                #region Table:Sixteenth Row Window V4T Vinyl Tint (tblWindowDetails)

                TableRow windowVinylTintRow = new TableRow();
                windowVinylTintRow.ID = "rowWindowVinylTint" + title;
                windowVinylTintRow.Attributes.Add("style", "display:none;");
                TableCell windowVinylTintLBLCell = new TableCell();
                TableCell windowVinylTintDDLCell = new TableCell();

                Label windowVinylTintLBL = new Label();
                windowVinylTintLBL.ID = "lblWindowVinylTint" + title;
                windowVinylTintLBL.Text = "V4T Vinyl Tint:";

                DropDownList windowVinylTintDDL = new DropDownList();
                windowVinylTintDDL.ID = "ddlWindowVinylTint" + title;
                for (int j = 0; j < Constants.DOOR_V4T_VINYL_OPTIONS.Count(); j++)
                {
                    windowVinylTintDDL.Items.Add(new ListItem(Constants.DOOR_V4T_VINYL_OPTIONS[j], Constants.DOOR_V4T_VINYL_OPTIONS[j]));
                }

                windowVinylTintDDL.Attributes.Add("onchange", "checkQuestion3()");
                windowVinylTintLBL.AssociatedControlID = "ddlWindowVinylTint" + title;

                #endregion

                #region Table:Twelfth Row Window V4T Number Of Vents (tblWindowDetails)

                TableRow windowNumberOfVentsRow = new TableRow();
                windowNumberOfVentsRow.ID = "rowWindowNumberOfVents" + title;
                windowNumberOfVentsRow.Attributes.Add("style", "display:none;");
                TableCell windowNumberOfVentsLBLCell = new TableCell();
                TableCell windowNumberOfVentsDDLCell = new TableCell();

                Label windowNumberOfVentsLBL = new Label();
                windowNumberOfVentsLBL.ID = "lblNumberOfVents" + title;
                windowNumberOfVentsLBL.Text = "V4T Number Of Vents:";

                DropDownList windowNumberOfVentsDDL = new DropDownList();
                windowNumberOfVentsDDL.ID = "ddlWindowNumberOfVents" + title;
                for (int j = 0; j < Constants.DOOR_NUMBER_OF_VENTS.Count(); j++)
                {
                    windowNumberOfVentsDDL.Items.Add(new ListItem(Constants.DOOR_NUMBER_OF_VENTS[j], Constants.DOOR_NUMBER_OF_VENTS[j]));
                }

                windowNumberOfVentsLBL.AssociatedControlID = "ddlWindowNumberOfVents" + title;

                windowNumberOfVentsDDL.Attributes.Add("onchange", "checkQuestion3()");

                #endregion

                #region Table:# Row Window Transom Vinyl (tblWindowDetails)

                TableRow windowTransomVinylRow = new TableRow();
                windowTransomVinylRow.ID = "rowWindowTransomVinyl" + title;
                windowTransomVinylRow.Attributes.Add("style", "display:none;");
                TableCell windowTransomVinylTypesLBLCell = new TableCell();
                TableCell windowTransomVinylTypesDDLCell = new TableCell();

                Label windowTransomVinylLBL = new Label();
                windowTransomVinylLBL.ID = "lblWindowTransomVinyl" + title;
                windowTransomVinylLBL.Text = "Transom Vinyl Types:";

                DropDownList windowTransomVinylDDL = new DropDownList();
                windowTransomVinylDDL.ID = "ddlWindowTransomVinyl" + title;
                for (int j = 0; j < Constants.VINYL_TINTS.Count(); j++)
                {
                    windowTransomVinylDDL.Items.Add(new ListItem(Constants.VINYL_TINTS[j], Constants.VINYL_TINTS[j]));
                }

                windowTransomVinylLBL.AssociatedControlID = "ddlWindowTransomVinyl" + title;

                #endregion

                #region Table:# Row Window Transom Glass Types (tblWindowDetails)

                TableRow windowTransomGlassRow = new TableRow();
                windowTransomGlassRow.ID = "rowWindowTransomGlass" + title;
                windowTransomGlassRow.Attributes.Add("style", "display:none;");
                TableCell windowTransomGlassTypesLBLCell = new TableCell();
                TableCell windowTransomGlassTypesDDLCell = new TableCell();

                Label windowTransomGlassLBL = new Label();
                windowTransomGlassLBL.ID = "lblWindowTransomGlass" + title;
                windowTransomGlassLBL.Text = "Transom Glass Types:";

                DropDownList windowTransomGlassDDL = new DropDownList();
                windowTransomGlassDDL.ID = "ddlWindowTransomGlass" + title;
                for (int j = 0; j < Constants.TRANSOM_GLASS_TINTS.Count(); j++)
                {
                    windowTransomGlassDDL.Items.Add(new ListItem(Constants.TRANSOM_GLASS_TINTS[j], Constants.TRANSOM_GLASS_TINTS[j]));
                }

                windowTransomGlassLBL.AssociatedControlID = "ddlWindowTransomGlass" + title;

                #endregion

                #region Table:# Row Window Kickplate (tblWindowDetails)

                TableRow windowKickplateRow = new TableRow();
                windowKickplateRow.ID = "rowWindowKickplate" + title;
                windowKickplateRow.Attributes.Add("style", "display:none;");
                TableCell windowKickplateLBLCell = new TableCell();
                TableCell windowKickplateDDLCell = new TableCell();

                Label windowKickplateLBL = new Label();
                windowKickplateLBL.ID = "lblWindowKickplate" + title;
                windowKickplateLBL.Text = "Kickplate Height:";

                DropDownList windowKickplateDDL = new DropDownList();
                windowKickplateDDL.ID = "ddlWindowKickplate" + title;
                windowKickplateDDL.Attributes.Add("onchange", "windowKickplateStyle('" + title + "','" + "')");
                for (int j = 0; j < Constants.KICKPLATE_SIZE_OPTIONS.Count(); j++)
                {
                    if (Constants.KICKPLATE_SIZE_OPTIONS[j] == "Custom")
                    {
                        windowKickplateDDL.Items.Add(new ListItem(Constants.KICKPLATE_SIZE_OPTIONS[j], "cKickplate"));
                    }
                    else
                    {
                        windowKickplateDDL.Items.Add(new ListItem(Constants.KICKPLATE_SIZE_OPTIONS[j] + "\"", Constants.KICKPLATE_SIZE_OPTIONS[j]));
                    }
                }

                #endregion

                #region Table:# Row Window Kickplate Custom (tblWindowDetails)

                TableRow windowCustomKickplateRow = new TableRow();
                windowCustomKickplateRow.ID = "rowWindowCustomKickplate" + title;
                windowCustomKickplateRow.Attributes.Add("style", "display:none;");
                TableCell windowCustomKickplateLBLCell = new TableCell();
                TableCell windowCustomKickplateTXTCell = new TableCell();
                TableCell windowCustomKickplateDDLCell = new TableCell();

                Label windowCustomKickplateLBL = new Label();
                windowCustomKickplateLBL.ID = "lblWindowCustomKickplate" + title;
                windowCustomKickplateLBL.Text = "Custom Kickplate (inches):";

                TextBox windowCustomKickplateTXT = new TextBox();
                windowCustomKickplateTXT.ID = "txtWindowKickplateCustom" + title;
                windowCustomKickplateTXT.CssClass = "txtField txtWindowInput";
                windowCustomKickplateTXT.Attributes.Add("maxlength", "3");
                windowCustomKickplateTXT.Attributes.Add("onkeydown", "return (event.keyCode!=13);");

                DropDownList inchCustomKickplate = new DropDownList();
                inchCustomKickplate.ID = "ddlWindowKickplateCustom" + title;
                inchCustomKickplate.Items.Add(lst0);
                inchCustomKickplate.Items.Add(lst18);
                inchCustomKickplate.Items.Add(lst14);
                inchCustomKickplate.Items.Add(lst38);
                inchCustomKickplate.Items.Add(lst12);
                inchCustomKickplate.Items.Add(lst58);
                inchCustomKickplate.Items.Add(lst34);
                inchCustomKickplate.Items.Add(lst78);

                windowCustomKickplateLBL.AssociatedControlID = "txtWindowKickplateCustom" + title;

                #endregion

                #region Table:Third Row Color of Window (tblWindowDetails)

                TableRow colourOfWindowRow = new TableRow();
                colourOfWindowRow.ID = "rowWindowColour" + title;
                colourOfWindowRow.Attributes.Add("style", "display:none;");
                TableCell colourOfWindowLBLCell = new TableCell();
                TableCell colourOfWindowDDLCell = new TableCell();

                Label colourOfWindowLBL = new Label();
                colourOfWindowLBL.ID = "lblWindowColour" + title;
                colourOfWindowLBL.Text = "Colour:";

                DropDownList colourOfWindowDDL = new DropDownList();
                colourOfWindowDDL.ID = "ddlWindowColour" + title;
                for (int j = 0; j < Constants.DOOR_COLOURS.Count(); j++)
                {
                    colourOfWindowDDL.Items.Add(new ListItem(Constants.DOOR_COLOURS[j], Constants.DOOR_COLOURS[j]));
                }

                colourOfWindowLBL.AssociatedControlID = "ddlWindowColour" + title;

                #endregion

                #region Table:Fourth Row Window Height (tblWindowDetails)

                TableRow windowHeightRow = new TableRow();
                windowHeightRow.ID = "rowWindowHeight" + title;
                windowHeightRow.Attributes.Add("style", "display:none;");
                TableCell windowHeightLBLCell = new TableCell();
                TableCell windowHeightDDLCell = new TableCell();

                Label windowHeightLBL = new Label();
                windowHeightLBL.ID = "lblWindowHeight" + title;
                windowHeightLBL.Text = "Height:";

                DropDownList windowHeightDDL = new DropDownList();
                windowHeightDDL.ID = "ddlWindowHeight" + title;
                windowHeightDDL.Attributes.Add("onchange", "customDimension('" + title + "','Height')");
                for (int j = 0; j < Constants.DOOR_HEIGHTS.Count(); j++)
                {
                    if (Constants.DOOR_HEIGHTS[j] == "Custom")
                    {
                        windowHeightDDL.Items.Add(new ListItem(Constants.DOOR_HEIGHTS[j], "cHeight"));
                    }
                    else
                    {
                        windowHeightDDL.Items.Add(new ListItem(Constants.DOOR_HEIGHTS[j] + "\"", Constants.DOOR_HEIGHTS[j]));
                    }
                }

                windowHeightLBL.AssociatedControlID = "ddlWindowHeight" + title;

                #endregion

                #region Table:Sixth Row Window Custom Height (tblWindowDetails)

                TableRow windowCustomHeightRow = new TableRow();
                windowCustomHeightRow.ID = "rowWindowCustomHeight" + title;
                windowCustomHeightRow.Attributes.Add("style", "display:none;");
                TableCell windowCustomHeightLBLCell = new TableCell();
                TableCell windowCustomHeightTXTCell = new TableCell();
                TableCell windowCustomHeightDDLCell = new TableCell();

                Label windowCustomHeightLBL = new Label();
                windowCustomHeightLBL.ID = "lblWindowCustomHeight" + title;
                windowCustomHeightLBL.Text = "Custom Height (inches):";

                TextBox windowCustomHeightTXT = new TextBox();
                windowCustomHeightTXT.ID = "txtWindowHeightCustom" + title;
                windowCustomHeightTXT.CssClass = "txtField txtWindowInput";
                windowCustomHeightTXT.Attributes.Add("maxlength", "3");
                windowCustomHeightTXT.Attributes.Add("onkeydown", "return (event.keyCode!=13);");

                DropDownList inchCustomHeight = new DropDownList();
                inchCustomHeight.ID = "ddlWindowHeightCustom" + title;
                inchCustomHeight.Items.Add(lst0);
                inchCustomHeight.Items.Add(lst18);
                inchCustomHeight.Items.Add(lst14);
                inchCustomHeight.Items.Add(lst38);
                inchCustomHeight.Items.Add(lst12);
                inchCustomHeight.Items.Add(lst58);
                inchCustomHeight.Items.Add(lst34);
                inchCustomHeight.Items.Add(lst78);

                windowCustomHeightLBL.AssociatedControlID = "txtWindowHeightCustom" + title;

                #endregion

                #region Table:Fifth Row Window Width (tblWindowDetails)

                TableRow windowWidthRow = new TableRow();
                windowWidthRow.ID = "rowWindowWidth" + title;
                windowWidthRow.Attributes.Add("style", "display:none;");
                TableCell windowWidthLBLCell = new TableCell();
                TableCell windowWidthDDLCell = new TableCell();

                Label windowWidthLBL = new Label();
                windowWidthLBL.ID = "lblWindowWidth" + title;
                windowWidthLBL.Text = "Width:";

                DropDownList windowWidthDDL = new DropDownList();
                windowWidthDDL.ID = "ddlWindowWidth" + title;
                windowWidthDDL.Attributes.Add("onchange", "customDimension('" + title + "','Width')");

                if (title == "Patio")
                {
                    for (int j = 0; j < Constants.DOOR_WIDTHS_PATIO.Count(); j++)
                    {
                        if (Constants.DOOR_WIDTHS_PATIO[j] == "Custom")
                        {
                            windowWidthDDL.Items.Add(new ListItem(Constants.DOOR_WIDTHS_PATIO[j], "cWidth"));
                        }
                        else
                        {
                            windowWidthDDL.Items.Add(new ListItem(Constants.DOOR_WIDTHS_PATIO[j] + "\'", Convert.ToString((Convert.ToInt32(Constants.DOOR_WIDTHS_PATIO[j]) * 12))));
                        }
                    }
                }
                else if (title == "French")
                {
                    for (int j = 0; j < Constants.DOOR_WIDTHS_FRENCH.Count(); j++)
                    {
                        if (Constants.DOOR_WIDTHS_FRENCH[j] == "Custom")
                        {
                            windowWidthDDL.Items.Add(new ListItem(Constants.DOOR_WIDTHS_FRENCH[j], "cWidth"));
                        }
                        else
                        {
                            windowWidthDDL.Items.Add(new ListItem(Constants.DOOR_WIDTHS_FRENCH[j] + "\"", Constants.DOOR_WIDTHS_FRENCH[j]));
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < Constants.DOOR_WIDTHS_CABANA_NODOOR.Count(); j++)
                    {
                        if (Constants.DOOR_WIDTHS_CABANA_NODOOR[j] == "Custom")
                        {
                            windowWidthDDL.Items.Add(new ListItem(Constants.DOOR_WIDTHS_CABANA_NODOOR[j], "cWidth"));
                        }
                        else
                        {
                            windowWidthDDL.Items.Add(new ListItem(Constants.DOOR_WIDTHS_CABANA_NODOOR[j] + "\"", Constants.DOOR_WIDTHS_CABANA_NODOOR[j]));
                        }
                    }
                }

                windowWidthLBL.AssociatedControlID = "ddlWindowWidth" + title;

                #endregion

                #region Table:Seventh Row Window Custom Width (tblWindowDetails)

                TableRow windowCustomWidthRow = new TableRow();
                windowCustomWidthRow.ID = "rowWindowCustomWidth" + title;
                windowCustomWidthRow.Attributes.Add("style", "display:none;");
                TableCell windowCustomWidthLBLCell = new TableCell();
                TableCell windowCustomWidthTXTCell = new TableCell();
                TableCell windowCustomWidthDDLCell = new TableCell();

                Label windowCustomWidthLBL = new Label();
                windowCustomWidthLBL.ID = "lblWindowCustomWidth" + title;
                windowCustomWidthLBL.Text = "Custom Width (inches):";

                TextBox windowCustomWidthTXT = new TextBox();
                windowCustomWidthTXT.ID = "txtWindowWidthCustom" + title;
                windowCustomWidthTXT.CssClass = "txtField txtWindowInput";
                windowCustomWidthTXT.Attributes.Add("maxlength", "3");
                windowCustomWidthTXT.Attributes.Add("onkeydown", "return (event.keyCode!=13);");

                DropDownList inchCustomWidth = new DropDownList();
                inchCustomWidth.ID = "ddlWindowWidthCustom" + title;
                inchCustomWidth.Items.Add(lst0);
                inchCustomWidth.Items.Add(lst18);
                inchCustomWidth.Items.Add(lst14);
                inchCustomWidth.Items.Add(lst38);
                inchCustomWidth.Items.Add(lst12);
                inchCustomWidth.Items.Add(lst58);
                inchCustomWidth.Items.Add(lst34);
                inchCustomWidth.Items.Add(lst78);

                windowCustomWidthLBL.AssociatedControlID = "txtWindowWidthCustom" + title;

                #endregion

                #region Table:Eight Row Window Primary Operator LHH (tblWindowDetails)

                TableRow windowOperatorLHHRow = new TableRow();
                windowOperatorLHHRow.ID = "rowWindowOperatorLHH" + title;
                windowOperatorLHHRow.Attributes.Add("style", "display:none;");
                TableCell windowOperatorLHHLBLCell = new TableCell();
                TableCell windowOperatorLHHRADCell = new TableCell();

                Label windowOperatorLHHLBLMain = new Label();
                windowOperatorLHHLBLMain.ID = "lblWindowOperatorLHHMain" + title;
                windowOperatorLHHLBLMain.Text = "Primary Operator:";

                Label windowOperatorLHHLBLRad = new Label();
                windowOperatorLHHLBLRad.ID = "lblWindowOperatorRadLHH" + title;

                Label windowOperatorLHHLBL = new Label();
                windowOperatorLHHLBL.ID = "lblWindowOperatorLHH" + title;
                windowOperatorLHHLBL.Text = "Left";

                RadioButton windowOperatorLHHRad = new RadioButton();
                windowOperatorLHHRad.ID = "radWindowOperator" + title;
                windowOperatorLHHRad.Attributes.Add("value", "Left");
                windowOperatorLHHRad.GroupName = "PrimaryOperator" + title;

                windowOperatorLHHLBLRad.AssociatedControlID = "radWindowOperator" + title;
                windowOperatorLHHLBL.AssociatedControlID = "radWindowOperator" + title;

                #endregion

                #region Table:Ninth Row Window Primary Operator RHH (tblWindowDetails)

                TableRow windowOperatorRHHRow = new TableRow();
                windowOperatorRHHRow.ID = "rowWindowOperatorRHH" + title;
                windowOperatorRHHRow.Attributes.Add("style", "display:none;");
                TableCell windowOperatorRHHLBLCell = new TableCell();
                TableCell windowOperatorRHHRADCell = new TableCell();

                Label windowOperatorRHHLBLRad = new Label();
                windowOperatorRHHLBLRad.ID = "lblWindowOperatorRadRHH" + title;

                Label windowOperatorRHHLBL = new Label();
                windowOperatorRHHLBL.ID = "lblWindowOperatorRHH" + title;
                windowOperatorRHHLBL.Text = "Right";

                RadioButton windowOperatorRHHRad = new RadioButton();
                windowOperatorRHHRad.ID = "radWindowOperatorRHH" + title;
                windowOperatorRHHRad.Attributes.Add("value", "Right");
                windowOperatorRHHRad.GroupName = "PrimaryOperator" + title;

                windowOperatorRHHLBLRad.AssociatedControlID = "radWindowOperatorRHH" + title;
                windowOperatorRHHLBL.AssociatedControlID = "radWindowOperatorRHH" + title;

                #endregion

                #region Table:Tenth Row Window Box Header (tblWindowDetails)

                TableRow windowBoxHeaderRow = new TableRow();
                windowBoxHeaderRow.ID = "rowWindowBoxHeader" + title;
                windowBoxHeaderRow.Attributes.Add("style", "display:none;");
                TableCell windowBoxHeaderLBLCell = new TableCell();
                TableCell windowBoxHeaderDDLCell = new TableCell();

                Label windowBoxHeaderLBL = new Label();
                windowBoxHeaderLBL.ID = "lblWindowBoxHeader" + title;
                windowBoxHeaderLBL.Text = "Box Header Position:";

                DropDownList windowBoxHeaderDDL = new DropDownList();
                windowBoxHeaderDDL.ID = "ddlWindowBoxHeader" + title;
                for (int j = 0; j < Constants.DOOR_BOXHEADER_POSITION.Count(); j++)
                {
                    windowBoxHeaderDDL.Items.Add(new ListItem(Constants.DOOR_BOXHEADER_POSITION[j], Constants.DOOR_BOXHEADER_POSITION[j]));
                }

                windowBoxHeaderLBL.AssociatedControlID = "ddlWindowBoxHeader" + title;

                #endregion

                #region Table:Thirteenth Row Window Glass Tint (tblWindowDetails)

                TableRow windowGlassTintRow = new TableRow();
                windowGlassTintRow.ID = "rowWindowGlassTint" + title;
                windowGlassTintRow.Attributes.Add("style", "display:none;");
                TableCell windowGlassTintLBLCell = new TableCell();
                TableCell windowGlassTintDDLCell = new TableCell();

                Label windowGlassTintLBL = new Label();
                windowGlassTintLBL.ID = "lblWindowGlassTint" + title;
                windowGlassTintLBL.Text = "Window Glass Tint:";

                DropDownList windowGlassTintDDL = new DropDownList();
                windowGlassTintDDL.ID = "ddlWindowGlassTint" + title;
                for (int j = 0; j < Constants.DOOR_GLASS_TINTS.Count(); j++)
                {
                    windowGlassTintDDL.Items.Add(new ListItem(Constants.DOOR_GLASS_TINTS[j], Constants.DOOR_GLASS_TINTS[j]));
                }

                windowGlassTintLBL.AssociatedControlID = "ddlWindowGlassTint" + title;

                #endregion

                #region Table:Tenth Row Window Hinge LHH (tblWindowDetails)

                TableRow windowHingeLHHRow = new TableRow();
                windowHingeLHHRow.ID = "rowWindowHingeLHH" + title;
                windowHingeLHHRow.Attributes.Add("style", "display:none;");
                TableCell windowHingeLHHLBLCell = new TableCell();
                TableCell windowHingeLHHRADCell = new TableCell();

                Label windowHingeLHHLBLMain = new Label();
                windowHingeLHHLBLMain.ID = "lblWindowHingeLHHMain" + title;
                windowHingeLHHLBLMain.Text = "Hinge placement:";

                Label windowHingeLHHLBLRad = new Label();
                windowHingeLHHLBLRad.ID = "lblHingeLHHRad" + title;

                Label windowHingeLHHLBL = new Label();
                windowHingeLHHLBL.ID = "lblHingeLHH" + title;
                windowHingeLHHLBL.Text = "Left";

                RadioButton windowHingeLHHRad = new RadioButton();
                windowHingeLHHRad.ID = "radWindowHinge" + title;
                windowHingeLHHRad.Attributes.Add("value", "Left");
                windowHingeLHHRad.GroupName = "WindowHinge" + title;

                windowHingeLHHLBLRad.AssociatedControlID = "radWindowHinge" + title;
                windowHingeLHHLBL.AssociatedControlID = "radWindowHinge" + title;

                #endregion

                #region Table:Eleventh Row Window Hinge RHH (tblWindowDetails)

                TableRow windowHingeRHHRow = new TableRow();
                windowHingeRHHRow.ID = "rowWindowHingeRHH" + title;
                windowHingeRHHRow.Attributes.Add("style", "display:none;");
                TableCell windowHingeRHHLBLCell = new TableCell();
                TableCell windowHingeRHHRADCell = new TableCell();

                Label windowHingeRHHLBLRad = new Label();
                windowHingeRHHLBLRad.ID = "lblWindowHingeRHHRad" + title;

                Label windowHingeRHHLBL = new Label();
                windowHingeRHHLBL.ID = "lblWindowHingeRHH" + title;
                windowHingeRHHLBL.Text = "Right";

                RadioButton windowHingeRHHRad = new RadioButton();
                windowHingeRHHRad.ID = "radWindowHingeRHH" + title;
                windowHingeRHHRad.Attributes.Add("value", "Right");
                windowHingeRHHRad.GroupName = "WindowHinge" + title;

                windowHingeRHHLBLRad.AssociatedControlID = "radWindowHingeRHH" + title;
                windowHingeRHHLBL.AssociatedControlID = "radWindowHingeRHH" + title;

                #endregion

                #region Table:Fourteenth Row Window Screen Options (tblWindowDetails)

                TableRow windowScreenOptionsRow = new TableRow();
                windowScreenOptionsRow.ID = "rowWindowScreenOptions" + title;
                windowScreenOptionsRow.Attributes.Add("style", "display:none;");
                TableCell windowScreenOptionsLBLCell = new TableCell();
                TableCell windowScreenOptionsDDLCell = new TableCell();

                Label windowScreenOptionsLBL = new Label();
                windowScreenOptionsLBL.ID = "lblWindowScreenOptions" + title;
                windowScreenOptionsLBL.Text = "Window Screen Option:";

                DropDownList windowScreenOptionsDDL = new DropDownList();
                windowScreenOptionsDDL.ID = "ddlWindowScreenOptions" + title;
                for (int j = 0; j < Constants.SCREEN_TYPES.Count(); j++)
                {
                    windowScreenOptionsDDL.Items.Add(new ListItem(Constants.SCREEN_TYPES[j], Constants.SCREEN_TYPES[j]));
                }

                windowScreenOptionsLBL.AssociatedControlID = "ddlWindowScreenOptions" + title;

                #endregion

                #region Table:Fifteenth Row Window Hardware (tblWindowDetails)

                TableRow windowHardwareRow = new TableRow();
                windowHardwareRow.ID = "rowWindowHardware" + title;
                windowHardwareRow.Attributes.Add("style", "display:none;");
                TableCell windowHardwareLBLCell = new TableCell();
                TableCell windowHardwareDDLCell = new TableCell();

                Label windowHardwareLBL = new Label();
                windowHardwareLBL.ID = "lblWindowHardware" + title;
                windowHardwareLBL.Text = "Window Hardware";

                DropDownList windowHardwareDDL = new DropDownList();
                windowHardwareDDL.ID = "ddlWindowHardware" + title;
                for (int j = 0; j < Constants.DOOR_HARDWARE.Count(); j++)
                {
                    windowHardwareDDL.Items.Add(new ListItem(Constants.DOOR_HARDWARE[j], Constants.DOOR_HARDWARE[j]));
                }

                windowHardwareLBL.AssociatedControlID = "ddlWindowHardware" + title;

                #endregion

                #region Table:Eight Row Window Swing In (tblWindowDetails)

                TableRow windowSwingInRow = new TableRow();
                windowSwingInRow.ID = "rowWindowSwingIn" + title;
                windowSwingInRow.Attributes.Add("style", "display:none;");
                TableCell windowSwingInLBLCell = new TableCell();
                TableCell windowSwingInRADCell = new TableCell();

                Label windowSwingInLBLMain = new Label();
                windowSwingInLBLMain.ID = "lblWindowSwingMain" + title;
                windowSwingInLBLMain.Text = "Swing:";

                Label windowSwingInLBLRad = new Label();
                windowSwingInLBLRad.ID = "lblWindowSwingIn" + title;

                Label windowSwingInLBL = new Label();
                windowSwingInLBL.ID = "lblWindowSwingInRad" + title;
                windowSwingInLBL.Text = "In";

                RadioButton windowSwingInRAD = new RadioButton();
                windowSwingInRAD.ID = "radWindowSwing" + title;
                windowSwingInRAD.Attributes.Add("value", "In");
                windowSwingInRAD.GroupName = "SwingInOut" + title;

                windowSwingInLBLRad.AssociatedControlID = "radWindowSwing" + title;
                windowSwingInLBL.AssociatedControlID = "radWindowSwing" + title;

                #endregion

                #region Table:Ninth Row Window Swing Out (tblWindowDetails)

                TableRow windowSwingOutRow = new TableRow();
                windowSwingOutRow.ID = "rowWindowSwingOut" + title;
                windowSwingOutRow.Attributes.Add("style", "display:none;");
                TableCell windowSwingOutLBLCell = new TableCell();
                TableCell windowSwingOutRADCell = new TableCell();

                Label windowSwingOutLBLRad = new Label();
                windowSwingOutLBLRad.ID = "lblWindowSwingOutRad" + title;

                Label windowSwingOutLBL = new Label();
                windowSwingOutLBL.ID = "lblWindowSwingOut" + title;
                windowSwingOutLBL.Text = "Out";

                RadioButton windowSwingOutRAD = new RadioButton();
                windowSwingOutRAD.ID = "radWindowSwingOut" + title;
                windowSwingOutRAD.Attributes.Add("value", "Out");
                windowSwingOutRAD.GroupName = "SwingInOut" + title;

                windowSwingOutLBLRad.AssociatedControlID = "radWindowSwingOut" + title;
                windowSwingOutLBL.AssociatedControlID = "radWindowSwingOut" + title;

                #endregion

                #region Table:# Row Window Position DDL (tblWindowDetails)

                TableRow windowPositionDDLRow = new TableRow();
                windowPositionDDLRow.ID = "rowWindowPosition" + title;
                windowPositionDDLRow.Attributes.Add("style", "display:none;");
                TableCell windowPositionDDLLBLCell = new TableCell();
                TableCell windowPositionDDLDDLCell = new TableCell();

                Label windowPositionDDLLBL = new Label();
                windowPositionDDLLBL.ID = "lblWindowPositionDDL" + title;
                windowPositionDDLLBL.Text = "Position In Wall:";

                DropDownList windowPositionDDLDDL = new DropDownList();
                windowPositionDDLDDL.ID = "ddlWindowPosition" + title;
                windowPositionDDLDDL.Attributes.Add("onchange", "customDimension('" + title + "','Position')");
                for (int j = 0; j < Constants.DOOR_POSITION.Count(); j++)
                {
                    if (Constants.DOOR_POSITION[j] == "Custom")
                    {
                        windowPositionDDLDDL.Items.Add(new ListItem(Constants.DOOR_POSITION[j], "cPosition"));
                    }
                    else
                    {
                        windowPositionDDLDDL.Items.Add(new ListItem(Constants.DOOR_POSITION[j], Constants.DOOR_POSITION[j]));
                    }
                }

                windowPositionDDLLBL.AssociatedControlID = "ddlWindowPosition" + title;

                #endregion

                #region Table:# Row Window Position Custom (tblWindowDetails)

                TableRow windowPositionRow = new TableRow();
                windowPositionRow.ID = "rowWindowCustomPosition" + title;
                windowPositionRow.Attributes.Add("style", "display:none;");
                TableCell windowPositionLBLCell = new TableCell();
                TableCell windowPositionTXTCell = new TableCell();
                TableCell windowPositionDDLCell = new TableCell();

                Label windowPositionLBL = new Label();
                windowPositionLBL.ID = "lblWindowCustomPosition" + title;
                windowPositionLBL.Text = "Window position from left side (inches):";

                TextBox windowPositionTXT = new TextBox();
                windowPositionTXT.ID = "txtWindowPositionCustom" + title;
                windowPositionTXT.CssClass = "txtField txtWindowInput";
                windowPositionTXT.Attributes.Add("maxlength", "3");
                windowPositionTXT.Attributes.Add("onkeydown", "return (event.keyCode!=13);");

                DropDownList inchSpecificLeft = new DropDownList();
                inchSpecificLeft.ID = "ddlWindowPositionCustom" + title;
                inchSpecificLeft.Items.Add(lst0);
                inchSpecificLeft.Items.Add(lst18);
                inchSpecificLeft.Items.Add(lst14);
                inchSpecificLeft.Items.Add(lst38);
                inchSpecificLeft.Items.Add(lst12);
                inchSpecificLeft.Items.Add(lst58);
                inchSpecificLeft.Items.Add(lst34);
                inchSpecificLeft.Items.Add(lst78);

                windowPositionLBL.AssociatedControlID = "txtWindowPositionCustom" + title;

                #endregion

                #region Table:# Row Add This Window (tblWindowDetails)

                TableRow windowButtonRow = new TableRow();
                windowButtonRow.ID = "rowAddWindow" + title;
                windowButtonRow.Attributes.Add("style", "display:inherit;");
                TableCell windowAddButtonCell = new TableCell();
                TableCell windowFillButtonCell = new TableCell();

                #endregion

                //Adding to table

                #region Table:Default Row Title Current Window Added To Table (tblWindowDetails)

                windowTitleLBLCell.Controls.Add(windowTitleLBL);

                tblWindowDetails.Rows.Add(windowTitleRow);

                windowTitleRow.Cells.Add(windowTitleLBLCell);

                #endregion

                #region Table:Second Row Style Of Window Added To Table (tblWindowDetails)

                windowStyleLBLCell.Controls.Add(windowStyleLBL);
                windowStyleDDLCell.Controls.Add(windowStyleDDL);

                tblWindowDetails.Rows.Add(windowStyleRow);

                windowStyleRow.Cells.Add(windowStyleLBLCell);
                windowStyleRow.Cells.Add(windowStyleDDLCell);

                #endregion

                #region Table:Twelfth Row Window V4T Number Of Vents Added To Table (tblWindowDetails)

                windowNumberOfVentsLBLCell.Controls.Add(windowNumberOfVentsLBL);
                windowNumberOfVentsDDLCell.Controls.Add(windowNumberOfVentsDDL);

                tblWindowDetails.Rows.Add(windowNumberOfVentsRow);

                windowNumberOfVentsRow.Cells.Add(windowNumberOfVentsLBLCell);
                windowNumberOfVentsRow.Cells.Add(windowNumberOfVentsDDLCell);

                #endregion

                #region Table:Sixteenth Row Window V4T Vinyl Tint (tblWindowDetails)

                windowVinylTintLBLCell.Controls.Add(windowVinylTintLBL);
                windowVinylTintDDLCell.Controls.Add(windowVinylTintDDL);

                tblWindowDetails.Rows.Add(windowVinylTintRow);

                windowVinylTintRow.Cells.Add(windowVinylTintLBLCell);
                windowVinylTintRow.Cells.Add(windowVinylTintDDLCell);

                addMixedTintDropdowns(title, tblWindowDetails);

                #endregion

                #region Table:# Row Window Transom Vinyl Types Added To Table (tblWindowDetails)

                windowTransomVinylTypesLBLCell.Controls.Add(windowTransomVinylLBL);
                windowTransomVinylTypesDDLCell.Controls.Add(windowTransomVinylDDL);

                tblWindowDetails.Rows.Add(windowTransomVinylRow);

                windowTransomVinylRow.Cells.Add(windowTransomVinylTypesLBLCell);
                windowTransomVinylRow.Cells.Add(windowTransomVinylTypesDDLCell);

                #endregion

                #region Table:# Row Window Transom Glass Types Added To Table (tblWindowDetails)

                windowTransomGlassTypesLBLCell.Controls.Add(windowTransomGlassLBL);
                windowTransomGlassTypesDDLCell.Controls.Add(windowTransomGlassDDL);

                tblWindowDetails.Rows.Add(windowTransomGlassRow);

                windowTransomGlassRow.Cells.Add(windowTransomGlassTypesLBLCell);
                windowTransomGlassRow.Cells.Add(windowTransomGlassTypesDDLCell);

                #endregion

                #region Table:# Row Window Kickplate (tblWindowDetails)

                windowKickplateLBLCell.Controls.Add(windowKickplateLBL);
                windowKickplateDDLCell.Controls.Add(windowKickplateDDL);

                tblWindowDetails.Rows.Add(windowKickplateRow);

                windowKickplateRow.Cells.Add(windowKickplateLBLCell);
                windowKickplateRow.Cells.Add(windowKickplateDDLCell);

                #endregion

                #region Table:# Row Window Kickplate Custom (tblWindowDetails)

                windowCustomKickplateLBLCell.Controls.Add(windowCustomKickplateLBL);
                windowCustomKickplateTXTCell.Controls.Add(windowCustomKickplateTXT);
                windowCustomKickplateDDLCell.Controls.Add(inchCustomKickplate);

                tblWindowDetails.Rows.Add(windowCustomKickplateRow);

                windowCustomKickplateRow.Cells.Add(windowCustomKickplateLBLCell);
                windowCustomKickplateRow.Cells.Add(windowCustomKickplateTXTCell);
                windowCustomKickplateRow.Cells.Add(windowCustomKickplateDDLCell);

                #endregion

                #region Table:Third Row Color of Window Added to Table (tblWindowDetails)

                colourOfWindowLBLCell.Controls.Add(colourOfWindowLBL);
                colourOfWindowDDLCell.Controls.Add(colourOfWindowDDL);

                tblWindowDetails.Rows.Add(colourOfWindowRow);

                colourOfWindowRow.Cells.Add(colourOfWindowLBLCell);
                colourOfWindowRow.Cells.Add(colourOfWindowDDLCell);

                #endregion

                #region Table:Fourth Row Height Of Window Added To Table (tblWindowDetails)

                windowHeightLBLCell.Controls.Add(windowHeightLBL);
                windowHeightDDLCell.Controls.Add(windowHeightDDL);

                tblWindowDetails.Rows.Add(windowHeightRow);

                windowHeightRow.Cells.Add(windowHeightLBLCell);
                windowHeightRow.Cells.Add(windowHeightDDLCell);

                #endregion

                #region Table:Sixth Row Custom Height Of Window Added To Table (tblWindowDetails)

                windowCustomHeightLBLCell.Controls.Add(windowCustomHeightLBL);
                windowCustomHeightTXTCell.Controls.Add(windowCustomHeightTXT);
                windowCustomHeightDDLCell.Controls.Add(inchCustomHeight);

                tblWindowDetails.Rows.Add(windowCustomHeightRow);

                windowCustomHeightRow.Cells.Add(windowCustomHeightLBLCell);
                windowCustomHeightRow.Cells.Add(windowCustomHeightTXTCell);
                windowCustomHeightRow.Cells.Add(windowCustomHeightDDLCell);

                #endregion

                #region Table:Fifth Row Width Of Window Added To Table (tblWindowDetails)

                windowWidthLBLCell.Controls.Add(windowWidthLBL);
                windowWidthDDLCell.Controls.Add(windowWidthDDL);

                tblWindowDetails.Rows.Add(windowWidthRow);

                windowWidthRow.Cells.Add(windowWidthLBLCell);
                windowWidthRow.Cells.Add(windowWidthDDLCell);

                #endregion

                #region Table:Seventh Row Custom Width Of Window Added To Table (tblWindowDetails)

                windowCustomWidthLBLCell.Controls.Add(windowCustomWidthLBL);
                windowCustomWidthTXTCell.Controls.Add(windowCustomWidthTXT);
                windowCustomWidthDDLCell.Controls.Add(inchCustomWidth);

                tblWindowDetails.Rows.Add(windowCustomWidthRow);

                windowCustomWidthRow.Cells.Add(windowCustomWidthLBLCell);
                windowCustomWidthRow.Cells.Add(windowCustomWidthTXTCell);
                windowCustomWidthRow.Cells.Add(windowCustomWidthDDLCell);

                #endregion

                #region Table:Eight Row Window Primary Operator LHH Added To Table (tblWindowDetails)

                windowOperatorLHHLBLCell.Controls.Add(windowOperatorLHHLBLMain);

                windowOperatorLHHRADCell.Controls.Add(windowOperatorLHHRad);
                windowOperatorLHHRADCell.Controls.Add(windowOperatorLHHLBLRad);
                windowOperatorLHHRADCell.Controls.Add(windowOperatorLHHLBL);

                tblWindowDetails.Rows.Add(windowOperatorLHHRow);

                windowOperatorLHHRow.Cells.Add(windowOperatorLHHLBLCell);
                windowOperatorLHHRow.Cells.Add(windowOperatorLHHRADCell);

                #endregion

                #region Table:Ninth Row Window Primary Operator RHH Added To Table (tblWindowDetails)

                windowOperatorRHHRADCell.Controls.Add(windowOperatorRHHRad);
                windowOperatorRHHRADCell.Controls.Add(windowOperatorRHHLBLRad);
                windowOperatorRHHRADCell.Controls.Add(windowOperatorRHHLBL);

                tblWindowDetails.Rows.Add(windowOperatorRHHRow);

                windowOperatorRHHRow.Cells.Add(windowOperatorRHHLBLCell);
                windowOperatorRHHRow.Cells.Add(windowOperatorRHHRADCell);

                #endregion

                #region Table:Tenth Row Window Box Header Position (tblWindowDetails)

                windowBoxHeaderLBLCell.Controls.Add(windowBoxHeaderLBL);
                windowBoxHeaderDDLCell.Controls.Add(windowBoxHeaderDDL);

                tblWindowDetails.Rows.Add(windowBoxHeaderRow);

                windowBoxHeaderRow.Cells.Add(windowBoxHeaderLBLCell);
                windowBoxHeaderRow.Cells.Add(windowBoxHeaderDDLCell);

                #endregion

                #region Table:Thirteenth Row Window Glass Tint Added To Table (tblWindowDetails)

                windowGlassTintLBLCell.Controls.Add(windowGlassTintLBL);
                windowGlassTintDDLCell.Controls.Add(windowGlassTintDDL);

                tblWindowDetails.Rows.Add(windowGlassTintRow);

                windowGlassTintRow.Cells.Add(windowGlassTintLBLCell);
                windowGlassTintRow.Cells.Add(windowGlassTintDDLCell);

                #endregion

                #region Table:Tenth Row Window Hinge LHH Added To Table (tblWindowDetails)

                windowHingeLHHLBLCell.Controls.Add(windowHingeLHHLBLMain);

                windowHingeLHHRADCell.Controls.Add(windowHingeLHHRad);
                windowHingeLHHRADCell.Controls.Add(windowHingeLHHLBLRad);
                windowHingeLHHRADCell.Controls.Add(windowHingeLHHLBL);

                tblWindowDetails.Rows.Add(windowHingeLHHRow);

                windowHingeLHHRow.Cells.Add(windowHingeLHHLBLCell);
                windowHingeLHHRow.Cells.Add(windowHingeLHHRADCell);

                #endregion

                #region Table:Eleventh Row Window Hinge RHH Added To Table (tblWindowDetails)

                windowHingeRHHRADCell.Controls.Add(windowHingeRHHRad);
                windowHingeRHHRADCell.Controls.Add(windowHingeRHHLBLRad);
                windowHingeRHHRADCell.Controls.Add(windowHingeRHHLBL);

                tblWindowDetails.Rows.Add(windowHingeRHHRow);

                windowHingeRHHRow.Cells.Add(windowHingeRHHLBLCell);
                windowHingeRHHRow.Cells.Add(windowHingeRHHRADCell);

                #endregion

                #region Table:Fourteenth Row Window Screen Options Added To Table (tblWindowDetails)

                windowScreenOptionsLBLCell.Controls.Add(windowScreenOptionsLBL);
                windowScreenOptionsDDLCell.Controls.Add(windowScreenOptionsDDL);

                tblWindowDetails.Rows.Add(windowScreenOptionsRow);

                windowScreenOptionsRow.Cells.Add(windowScreenOptionsLBLCell);
                windowScreenOptionsRow.Cells.Add(windowScreenOptionsDDLCell);

                #endregion

                #region Table:Fifteenth Row Window Hardware Added To Table (tblWindowDetails)

                windowHardwareLBLCell.Controls.Add(windowHardwareLBL);
                windowHardwareDDLCell.Controls.Add(windowHardwareDDL);

                tblWindowDetails.Rows.Add(windowHardwareRow);

                windowHardwareRow.Cells.Add(windowHardwareLBLCell);
                windowHardwareRow.Cells.Add(windowHardwareDDLCell);

                #endregion

                #region Table:Eight Row Swing In Added To Table (tblWindowDetails)

                windowSwingInLBLCell.Controls.Add(windowSwingInLBLMain);

                windowSwingInRADCell.Controls.Add(windowSwingInRAD);
                windowSwingInRADCell.Controls.Add(windowSwingInLBLRad);
                windowSwingInRADCell.Controls.Add(windowSwingInLBL);

                tblWindowDetails.Rows.Add(windowSwingInRow);

                windowSwingInRow.Cells.Add(windowSwingInLBLCell);
                windowSwingInRow.Cells.Add(windowSwingInRADCell);

                #endregion

                #region Table:Ninth Row Swing Out Added To Table (tblWindowDetails)

                windowSwingOutRADCell.Controls.Add(windowSwingOutRAD);
                windowSwingOutRADCell.Controls.Add(windowSwingOutLBLRad);
                windowSwingOutRADCell.Controls.Add(windowSwingOutLBL);

                tblWindowDetails.Rows.Add(windowSwingOutRow);

                windowSwingOutRow.Cells.Add(windowSwingOutLBLCell);
                windowSwingOutRow.Cells.Add(windowSwingOutRADCell);

                #endregion

                #region Table:# Row Window Position DDL Added To Table (tblWindowDetails)

                windowPositionDDLLBLCell.Controls.Add(windowPositionDDLLBL);
                windowPositionDDLDDLCell.Controls.Add(windowPositionDDLDDL);

                tblWindowDetails.Rows.Add(windowPositionDDLRow);


                windowPositionDDLRow.Cells.Add(windowPositionDDLLBLCell);
                windowPositionDDLRow.Cells.Add(windowPositionDDLDDLCell);

                #endregion

                #region Table:# Row Window Position Added To Table (tblWindowDetails)

                windowPositionLBLCell.Controls.Add(windowPositionLBL);
                windowPositionTXTCell.Controls.Add(windowPositionTXT);
                windowPositionDDLCell.Controls.Add(inchSpecificLeft);

                tblWindowDetails.Rows.Add(windowPositionRow);

                windowPositionRow.Cells.Add(windowPositionLBLCell);
                windowPositionRow.Cells.Add(windowPositionTXTCell);
                windowPositionRow.Cells.Add(windowPositionDDLCell);

                #endregion

                #region Table:# Row Add This Window (tblWindowDetails)

                windowAddButtonCell.Controls.Add(new LiteralControl("<input id='btnAddthisWindow" + title + "' type='button' onclick='addWindow(\"" + "\", \"" + title + "\")' class='btnSubmit' style='display:inherit;' value='Add This " + title + " Window'/>"));

                tblWindowDetails.Rows.Add(windowButtonRow);

                windowButtonRow.Cells.Add(windowAddButtonCell);

                #endregion

                //Adding literal control div tag to hold the table, add to WindowOptions placeholder
                WindowOptions.Controls.Add(new LiteralControl("<div class=\"toggleContent\" id=\"div_" + title + "\">"));

                WindowOptions.Controls.Add(new LiteralControl("<ul>"));

                //Adding literal control li to keep proper page look and format
                WindowOptions.Controls.Add(new LiteralControl("<li>"));

                //Adding table to placeholder WindowOptions
                WindowOptions.Controls.Add(tblWindowDetails);

                //Closing necessary tags
                WindowOptions.Controls.Add(new LiteralControl("</li>"));

                WindowOptions.Controls.Add(new LiteralControl("</ul>"));

                WindowOptions.Controls.Add(new LiteralControl("</div>"));

                WindowOptions.Controls.Add(new LiteralControl("</li>"));

            }
            #endregion
        }
    }
}
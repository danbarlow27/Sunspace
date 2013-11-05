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

                for (int k = 0; k < Constants.DOOR_V4T_VINYL_OPTIONS.Count() - 1; k++)
                {
                    ddlWindowTintOptions.Items.Add(new ListItem(Constants.DOOR_V4T_VINYL_OPTIONS[k], Constants.DOOR_V4T_VINYL_OPTIONS[k]));
                }
                
                mixedWindowTintLabel.AssociatedControlID = "ddlWindowTint" + j + title;

                mixedWindowTintLabelCell.Controls.Add(mixedWindowTintLabel);
                mixedWindowTintDropDownCell.Controls.Add(ddlWindowTintOptions);

                tblWindowDetails.Rows.Add(mixedWindowTintRow);

                mixedWindowTintRow.Cells.Add(mixedWindowTintLabelCell);
                mixedWindowTintRow.Cells.Add(mixedWindowTintDropDownCell);
            }
        }

        public void loadDetails(string obj)
        {
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

                tblWindowDetails.ID = "tbl" + obj + "Details" + title; //Adding appropriate id to the table
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

                windowTitleLBLCell.Controls.Add(windowTitleLBL);

                tblWindowDetails.Rows.Add(windowTitleRow);

                windowTitleRow.Cells.Add(windowTitleLBLCell);

                #endregion

                #region Table:Second Row Window Style (tblWindowDetails)


                #region Spreader bar Checkbox

                TableCell windowSpreaderBarCHKCell = new TableCell();
                windowSpreaderBarCHKCell.Attributes.Add("style", "display:none;");
                windowSpreaderBarCHKCell.ID = "cellWindowSpreaderBar" + title;

                Label windowSpreaderBarLBLChk = new Label();
                windowSpreaderBarLBLChk.ID = "lblWindowSpreaderBar" + title;

                Label windowSpreaderBarLBL = new Label();
                windowSpreaderBarLBL.ID = "lblWindowSpreaderBarRad" + title;
                windowSpreaderBarLBL.Text = " Spreader Bar";

                CheckBox windowSpreaderBarCHK = new CheckBox();
                windowSpreaderBarCHK.ID = "chkWindowSpreaderBar" + title;
                windowSpreaderBarCHK.Attributes.Add("value", "SpreaderBar");
                //windowSpreaderBarCHK.Attributes.Add("onclick", "windowStyle('" + title + "');");

                windowSpreaderBarLBLChk.AssociatedControlID = "chkWindowSpreaderBar" + title;
                windowSpreaderBarLBL.AssociatedControlID = "chkWindowSpreaderBar" + title;

                windowSpreaderBarCHKCell.Controls.Add(windowSpreaderBarCHK);
                windowSpreaderBarCHKCell.Controls.Add(windowSpreaderBarLBLChk);
                windowSpreaderBarCHKCell.Controls.Add(windowSpreaderBarLBL);

                #endregion

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

                if (title == "Vinyl")
                {
                    windowSpreaderBarCHKCell.Attributes.Add("style", "display:inherit;");

                    ListItem v4t = new ListItem("Vertical 4 Track", "Vertical 4 Track");
                    ListItem h2t = new ListItem("Horizontal 2 Track", "Horizontal 2 Track");
                    ListItem h3t = new ListItem("Horizontal 3 Track", "Horizontal 3 Track");
                    ListItem h4t = new ListItem("Horizontal 4 Track", "Horizontal 4 Track");
                    ListItem fixedLite = new ListItem("Vinyl Fixed Lite", "Vinyl Fixed Lite");
                    ListItem trap = new ListItem("Vinyl Trapezoid", "Vinyl Trapezoid");

                    windowStyleDDL.Items.Add(v4t);
                    windowStyleDDL.Items.Add(h2t);
                    windowStyleDDL.Items.Add(h3t);
                    windowStyleDDL.Items.Add(h4t);
                    windowStyleDDL.Items.Add(fixedLite);
                    windowStyleDDL.Items.Add(trap);
                }
                else if (title == "Glass")
                {
                    windowSpreaderBarCHKCell.Attributes.Add("style", "display:none;");

                    ListItem aluminumXXHorizontalRoller = new ListItem("Aluminum XX Horizontal Roller", "Aluminum XX Horizontal Roller");
                    ListItem aluminumFramedPicture = new ListItem("Aluminum Framed Picture", "Aluminum Framed Picture");
                    ListItem aluminumFramedTrapezoid = new ListItem("Aluminum Framed Trapezoid", "Aluminum Framed Trapezoid");
                    ListItem pvcXOSingleGlazedHorizontalRoller = new ListItem("PVC XO Single Glazed Horizontal Roller", "PVC XO Single Glazed Horizontal Roller");
                    ListItem pvcFramedSingleGlazedPicture = new ListItem("PVC Framed Single Glazed Picture", "PVC Framed Single Glazed Picture");
                    ListItem pvcFramedSingleGlazedTrapezoid = new ListItem("PVC Framed Single Glazed Trapezoid", "PVC Framed Single Glazed Trapezoid");

                    windowStyleDDL.Items.Add(aluminumXXHorizontalRoller);
                    windowStyleDDL.Items.Add(aluminumFramedPicture);
                    windowStyleDDL.Items.Add(aluminumFramedTrapezoid);
                    windowStyleDDL.Items.Add(pvcXOSingleGlazedHorizontalRoller);
                    windowStyleDDL.Items.Add(pvcFramedSingleGlazedPicture);
                    windowStyleDDL.Items.Add(pvcFramedSingleGlazedTrapezoid);
                }
                else if (title == "Screen")
                {
                    windowSpreaderBarCHKCell.Attributes.Add("style", "display:none;");

                    ListItem screenFixedLite = new ListItem("Screen Fixed Lite", "Screen Fixed Lite");
                    windowStyleDDL.Items.Add(screenFixedLite);
                }
                windowStyleLBL.AssociatedControlID = "ddlWindowStyle" + title;

                

                windowStyleLBLCell.Controls.Add(windowStyleLBL);
                windowStyleDDLCell.Controls.Add(windowStyleDDL);

                tblWindowDetails.Rows.Add(windowStyleRow);

                windowStyleRow.Cells.Add(windowStyleLBLCell);
                windowStyleRow.Cells.Add(windowStyleDDLCell);
                windowStyleRow.Cells.Add(windowSpreaderBarCHKCell);
                #endregion



                #region Table:Sixth Row Window Height (tblWindowDetails)

                TableRow windowHeightRow = new TableRow();
                windowHeightRow.ID = "rowWindowHeight" + title;
                //windowHeightRow.Attributes.Add("style", "display:none;");
                TableCell windowHeightLBLCell = new TableCell();
                TableCell windowHeightTXTCell = new TableCell();
                TableCell windowHeightDDLCell = new TableCell();

                Label windowHeightLBL = new Label();
                windowHeightLBL.ID = "lblWindowHeight" + title;
                windowHeightLBL.Text = "Height:";

                TextBox windowHeightTXT = new TextBox();
                windowHeightTXT.ID = "txtWindowHeight" + title;
                windowHeightTXT.CssClass = "txtField txtWindowInput";
                windowHeightTXT.Attributes.Add("maxlength", "3");
                windowHeightTXT.Attributes.Add("onkeydown", "return (event.keyCode!=13);");

                DropDownList inchHeight = new DropDownList();
                inchHeight.ID = "ddlWindowHeight" + title;
                inchHeight.Items.Add(lst0);
                inchHeight.Items.Add(lst18);
                inchHeight.Items.Add(lst14);
                inchHeight.Items.Add(lst38);
                inchHeight.Items.Add(lst12);
                inchHeight.Items.Add(lst58);
                inchHeight.Items.Add(lst34);
                inchHeight.Items.Add(lst78);

                windowHeightLBL.AssociatedControlID = "txtWindowHeight" + title;


                windowHeightLBLCell.Controls.Add(windowHeightLBL);
                windowHeightTXTCell.Controls.Add(windowHeightTXT);
                windowHeightDDLCell.Controls.Add(inchHeight);

                tblWindowDetails.Rows.Add(windowHeightRow);

                windowHeightRow.Cells.Add(windowHeightLBLCell);
                windowHeightRow.Cells.Add(windowHeightTXTCell);
                windowHeightRow.Cells.Add(windowHeightDDLCell);

                #endregion

                #region Table:Sixth Row Trapezoid Window Left Height (tblWindowDetails)

                TableRow windowLeftHeightRow = new TableRow();
                windowLeftHeightRow.ID = "rowWindowLeftHeight" + title;
                windowLeftHeightRow.Attributes.Add("style", "display:none;");
                TableCell windowLeftHeightLBLCell = new TableCell();
                TableCell windowLeftHeightTXTCell = new TableCell();
                TableCell windowLeftHeightDDLCell = new TableCell();

                Label windowLeftHeightLBL = new Label();
                windowLeftHeightLBL.ID = "lblWindowLeftHeight" + title;
                windowLeftHeightLBL.Text = "Left Height:";

                TextBox windowLeftHeightTXT = new TextBox();
                windowLeftHeightTXT.ID = "txtWindowLeftHeight" + title;
                windowLeftHeightTXT.CssClass = "txtField txtWindowInput";
                windowLeftHeightTXT.Attributes.Add("maxlength", "3");
                windowLeftHeightTXT.Attributes.Add("onkeydown", "return (event.keyCode!=13);");

                DropDownList inchLeftHeight = new DropDownList();
                inchLeftHeight.ID = "ddlWindowLeftHeight" + title;
                inchLeftHeight.Items.Add(lst0);
                inchLeftHeight.Items.Add(lst18);
                inchLeftHeight.Items.Add(lst14);
                inchLeftHeight.Items.Add(lst38);
                inchLeftHeight.Items.Add(lst12);
                inchLeftHeight.Items.Add(lst58);
                inchLeftHeight.Items.Add(lst34);
                inchLeftHeight.Items.Add(lst78);

                windowLeftHeightLBL.AssociatedControlID = "txtWindowLeftHeight" + title;


                windowLeftHeightLBLCell.Controls.Add(windowLeftHeightLBL);
                windowLeftHeightTXTCell.Controls.Add(windowLeftHeightTXT);
                windowLeftHeightDDLCell.Controls.Add(inchLeftHeight);

                tblWindowDetails.Rows.Add(windowLeftHeightRow);

                windowLeftHeightRow.Cells.Add(windowLeftHeightLBLCell);
                windowLeftHeightRow.Cells.Add(windowLeftHeightTXTCell);
                windowLeftHeightRow.Cells.Add(windowLeftHeightDDLCell);

                #endregion

                #region Table:Sixth Row Trapezoid Window Right Height (tblWindowDetails)

                TableRow windowRightHeightRow = new TableRow();
                windowRightHeightRow.ID = "rowWindowRightHeight" + title;
                windowRightHeightRow.Attributes.Add("style", "display:none;");
                TableCell windowRightHeightLBLCell = new TableCell();
                TableCell windowRightHeightTXTCell = new TableCell();
                TableCell windowRightHeightDDLCell = new TableCell();

                Label windowRightHeightLBL = new Label();
                windowRightHeightLBL.ID = "lblWindowRightHeight" + title;
                windowRightHeightLBL.Text = "Right Height:";

                TextBox windowRightHeightTXT = new TextBox();
                windowRightHeightTXT.ID = "txtWindowRightHeight" + title;
                windowRightHeightTXT.CssClass = "txtField txtWindowInput";
                windowRightHeightTXT.Attributes.Add("maxlength", "3");
                windowRightHeightTXT.Attributes.Add("onkeydown", "return (event.keyCode!=13);");

                DropDownList inchRightHeight = new DropDownList();
                inchRightHeight.ID = "ddlWindowRightHeight" + title;
                inchRightHeight.Items.Add(lst0);
                inchRightHeight.Items.Add(lst18);
                inchRightHeight.Items.Add(lst14);
                inchRightHeight.Items.Add(lst38);
                inchRightHeight.Items.Add(lst12);
                inchRightHeight.Items.Add(lst58);
                inchRightHeight.Items.Add(lst34);
                inchRightHeight.Items.Add(lst78);

                windowRightHeightLBL.AssociatedControlID = "txtWindowRightHeight" + title;


                windowRightHeightLBLCell.Controls.Add(windowRightHeightLBL);
                windowRightHeightTXTCell.Controls.Add(windowRightHeightTXT);
                windowRightHeightDDLCell.Controls.Add(inchRightHeight);

                tblWindowDetails.Rows.Add(windowRightHeightRow);

                windowRightHeightRow.Cells.Add(windowRightHeightLBLCell);
                windowRightHeightRow.Cells.Add(windowRightHeightTXTCell);
                windowRightHeightRow.Cells.Add(windowRightHeightDDLCell);

                #endregion


                #region Table:Seventh Row Window Width (tblWindowDetails)

                TableRow windowWidthRow = new TableRow();
                windowWidthRow.ID = "rowWindowWidth" + title;
                //windowWidthRow.Attributes.Add("style", "display:none;");
                TableCell windowWidthLBLCell = new TableCell();
                TableCell windowWidthTXTCell = new TableCell();
                TableCell windowWidthDDLCell = new TableCell();

                Label windowWidthLBL = new Label();
                windowWidthLBL.ID = "lblWindowWidth" + title;
                windowWidthLBL.Text = "Width:";

                TextBox windowWidthTXT = new TextBox();
                windowWidthTXT.ID = "txtWindowWidth" + title;
                windowWidthTXT.CssClass = "txtField txtWindowInput";
                windowWidthTXT.Attributes.Add("maxlength", "3");
                windowWidthTXT.Attributes.Add("onkeydown", "return (event.keyCode!=13);");

                DropDownList inchWidth = new DropDownList();
                inchWidth.ID = "ddlWindowWidth" + title;
                inchWidth.Items.Add(lst0);
                inchWidth.Items.Add(lst18);
                inchWidth.Items.Add(lst14);
                inchWidth.Items.Add(lst38);
                inchWidth.Items.Add(lst12);
                inchWidth.Items.Add(lst58);
                inchWidth.Items.Add(lst34);
                inchWidth.Items.Add(lst78);

                windowWidthLBL.AssociatedControlID = "txtWindowWidth" + title;


                windowWidthLBLCell.Controls.Add(windowWidthLBL);
                windowWidthTXTCell.Controls.Add(windowWidthTXT);
                windowWidthDDLCell.Controls.Add(inchWidth);

                tblWindowDetails.Rows.Add(windowWidthRow);

                windowWidthRow.Cells.Add(windowWidthLBLCell);
                windowWidthRow.Cells.Add(windowWidthTXTCell);
                windowWidthRow.Cells.Add(windowWidthDDLCell);

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
                windowNumberOfVentsDDL.Attributes.Add("onchange", "windowStyle('" + title + "');");
                //ListItem V2 = new ListItem("2", "2");
                ListItem V3 = new ListItem("3", "3");
                ListItem V4 = new ListItem("4", "4");
                ListItem V6S = new ListItem("6 Stereo", "6");
                ListItem V8S = new ListItem("8 Stereo", "8");
                ListItem V9S = new ListItem("9 Stereo", "9");
                ListItem V12S = new ListItem("12 Stereo", "12");

                windowNumberOfVentsDDL.Items.Add(V3);
                windowNumberOfVentsDDL.Items.Add(V4);
                windowNumberOfVentsDDL.Items.Add(V6S);
                windowNumberOfVentsDDL.Items.Add(V8S);
                windowNumberOfVentsDDL.Items.Add(V9S);
                windowNumberOfVentsDDL.Items.Add(V12S);

                windowNumberOfVentsLBL.AssociatedControlID = "ddlWindowNumberOfVents" + title;

                windowNumberOfVentsLBLCell.Controls.Add(windowNumberOfVentsLBL);
                windowNumberOfVentsDDLCell.Controls.Add(windowNumberOfVentsDDL);

                windowNumberOfVentsRow.Cells.Add(windowNumberOfVentsLBLCell);
                windowNumberOfVentsRow.Cells.Add(windowNumberOfVentsDDLCell);

                #region Uneven Vents Checkbox

                TableCell windowUnevenVentsCHKCell = new TableCell();
                windowUnevenVentsCHKCell.Attributes.Add("style", "display:none;");
                windowUnevenVentsCHKCell.ID = "cellWindowUnevenVents" + title;
                
                Label windowUnevenVentsLBLChk = new Label();
                windowUnevenVentsLBLChk.ID = "lblWindowUnevenVents" + title;

                Label windowUnevenVentsLBL = new Label();
                windowUnevenVentsLBL.ID = "lblWindowUnevenVentsRad" + title;
                windowUnevenVentsLBL.Text = " Uneven Vents";

                CheckBox windowUnevenVentsCHK = new CheckBox();
                windowUnevenVentsCHK.ID = "chkWindowUnevenVents" + title;
                windowUnevenVentsCHK.Attributes.Add("value", "UnevenVents");
                windowUnevenVentsCHK.Attributes.Add("onclick", "windowStyle('" + title + "');");

                windowUnevenVentsLBLChk.AssociatedControlID = "chkWindowUnevenVents" + title;
                windowUnevenVentsLBL.AssociatedControlID = "chkWindowUnevenVents" + title;

                windowUnevenVentsCHKCell.Controls.Add(windowUnevenVentsCHK);
                windowUnevenVentsCHKCell.Controls.Add(windowUnevenVentsLBLChk);
                windowUnevenVentsCHKCell.Controls.Add(windowUnevenVentsLBL);

                windowNumberOfVentsRow.Cells.Add(windowUnevenVentsCHKCell);

                #endregion

                tblWindowDetails.Rows.Add(windowNumberOfVentsRow);

                #endregion

                #region uneven vents textboxes


                #region edit

                TableCell windowUnevenVentsEditRADCell = new TableCell();

                Label windowUnevenVentsEditLBLRad = new Label();
                windowUnevenVentsEditLBLRad.ID = "lblWindowUnevenVentsEdit" + title;

                Label windowUnevenVentsEditLBL = new Label();
                windowUnevenVentsEditLBL.ID = "lblWindowUnevenVentsEditRad" + title;
                windowUnevenVentsEditLBL.Text = "Edit";

                RadioButton windowUnevenVentsEditRAD = new RadioButton();
                windowUnevenVentsEditRAD.ID = "radWindowUnevenVentsEdit" + title;
                windowUnevenVentsEditRAD.Attributes.Add("value", "Edit");
                windowUnevenVentsEditRAD.GroupName = "UnevenVents" + title;
                windowUnevenVentsEditRAD.Checked = true;
                windowUnevenVentsEditRAD.Attributes.Add("onclick", "windowStyle('" + title + "');");

                windowUnevenVentsEditLBLRad.AssociatedControlID = "radWindowUnevenVentsEdit" + title;
                windowUnevenVentsEditLBL.AssociatedControlID = "radWindowUnevenVentsEdit" + title;

                windowUnevenVentsEditRADCell.Controls.Add(windowUnevenVentsEditRAD);
                windowUnevenVentsEditRADCell.Controls.Add(windowUnevenVentsEditLBLRad);
                windowUnevenVentsEditRADCell.Controls.Add(windowUnevenVentsEditLBL);

                #endregion

                #region done

                TableCell windowUnevenVentsDoneRADCell = new TableCell();

                Label windowUnevenVentsDoneLBLRad = new Label();
                windowUnevenVentsDoneLBLRad.ID = "lblWindowUnevenVentsDone" + title;

                Label windowUnevenVentsDoneLBL = new Label();
                windowUnevenVentsDoneLBL.ID = "lblWindowUnevenVentsDoneRad" + title;
                windowUnevenVentsDoneLBL.Text = "Done";

                RadioButton windowUnevenVentsDoneRAD = new RadioButton();
                windowUnevenVentsDoneRAD.ID = "radWindowUnevenVentsDone" + title;
                windowUnevenVentsDoneRAD.Attributes.Add("value", "Done");
                windowUnevenVentsDoneRAD.GroupName = "UnevenVents" + title;
                windowUnevenVentsDoneRAD.Attributes.Add("onclick", "windowStyle('" + title + "');");

                windowUnevenVentsDoneLBLRad.AssociatedControlID = "radWindowUnevenVentsDone" + title;
                windowUnevenVentsDoneLBL.AssociatedControlID = "radWindowUnevenVentsDone" + title;

                windowUnevenVentsDoneRADCell.Controls.Add(windowUnevenVentsDoneRAD);
                windowUnevenVentsDoneRADCell.Controls.Add(windowUnevenVentsDoneLBLRad);
                windowUnevenVentsDoneRADCell.Controls.Add(windowUnevenVentsDoneLBL);

                #endregion


                #region top vent

                TableRow windowUnevenVentsRowTop = new TableRow();
                windowUnevenVentsRowTop.ID = "rowWindowUnevenVentsTop" + title;
                windowUnevenVentsRowTop.Attributes.Add("style", "display:none;");

                TableCell windowTopVentLBLCell = new TableCell();
                TableCell windowTopVentTXTCell = new TableCell();
                TableCell windowTopVentDDLCell = new TableCell();

                Label windowTopVentLBL = new Label();
                windowTopVentLBL.ID = "lblWindowTopVentHeight" + title;
                windowTopVentLBL.Text = "Top Vent Height:";

                TextBox windowTopVentTXT = new TextBox();
                windowTopVentTXT.ID = "txtWindowTopVentHeight" + title;
                windowTopVentTXT.CssClass = "txtField txtWindowInput";
                windowTopVentTXT.Attributes.Add("maxlength", "3");
                windowTopVentTXT.Attributes.Add("onkeydown", "return (event.keyCode!=13);");
                

                DropDownList inchTopVentDDL = new DropDownList();
                inchTopVentDDL.ID = "ddlWindowTopVentHeight" + title;
                inchTopVentDDL.Items.Add(lst0);
                inchTopVentDDL.Items.Add(lst18);
                inchTopVentDDL.Items.Add(lst14);
                inchTopVentDDL.Items.Add(lst38);
                inchTopVentDDL.Items.Add(lst12);
                inchTopVentDDL.Items.Add(lst58);
                inchTopVentDDL.Items.Add(lst34);
                inchTopVentDDL.Items.Add(lst78);

                windowTopVentLBL.AssociatedControlID = "txtWindowTopVentHeight" + title;

                windowTopVentLBLCell.Controls.Add(windowTopVentLBL);
                windowTopVentTXTCell.Controls.Add(windowTopVentTXT);
                windowTopVentDDLCell.Controls.Add(inchTopVentDDL);

                windowUnevenVentsRowTop.Cells.Add(windowTopVentLBLCell);
                windowUnevenVentsRowTop.Cells.Add(windowTopVentTXTCell);
                windowUnevenVentsRowTop.Cells.Add(windowTopVentDDLCell);
                windowUnevenVentsRowTop.Cells.Add(windowUnevenVentsEditRADCell);
 
                tblWindowDetails.Rows.Add(windowUnevenVentsRowTop);

                #endregion

                #region bottom vent

                TableRow windowUnevenVentsRowBottom = new TableRow();
                windowUnevenVentsRowBottom.ID = "rowWindowUnevenVentsBottom" + title;
                windowUnevenVentsRowBottom.Attributes.Add("style", "display:none;");

                TableCell windowBottomVentLBLCell = new TableCell();
                TableCell windowBottomVentTXTCell = new TableCell();
                TableCell windowBottomVentDDLCell = new TableCell();

                Label windowBottomVentLBL = new Label();
                windowBottomVentLBL.ID = "lblWindowBottomVentHeight" + title;
                windowBottomVentLBL.Text = "Bottom Vent Height:";

                TextBox windowBottomVentTXT = new TextBox();
                windowBottomVentTXT.ID = "txtWindowBottomVentHeight" + title;
                windowBottomVentTXT.CssClass = "txtField txtWindowInput";
                windowBottomVentTXT.Attributes.Add("maxlength", "3");
                windowBottomVentTXT.Attributes.Add("onkeydown", "return (event.keyCode!=13);");
                

                DropDownList inchBottomVentDDL = new DropDownList();
                inchBottomVentDDL.ID = "ddlWindowBottomVentHeight" + title;
                inchBottomVentDDL.Items.Add(lst0);
                inchBottomVentDDL.Items.Add(lst18);
                inchBottomVentDDL.Items.Add(lst14);
                inchBottomVentDDL.Items.Add(lst38);
                inchBottomVentDDL.Items.Add(lst12);
                inchBottomVentDDL.Items.Add(lst58);
                inchBottomVentDDL.Items.Add(lst34);
                inchBottomVentDDL.Items.Add(lst78);

                windowBottomVentLBL.AssociatedControlID = "txtWindowBottomVentHeight" + title;

                windowBottomVentLBLCell.Controls.Add(windowBottomVentLBL);
                windowBottomVentTXTCell.Controls.Add(windowBottomVentTXT);
                windowBottomVentDDLCell.Controls.Add(inchBottomVentDDL);

                windowUnevenVentsRowBottom.Cells.Add(windowBottomVentLBLCell);
                windowUnevenVentsRowBottom.Cells.Add(windowBottomVentTXTCell);
                windowUnevenVentsRowBottom.Cells.Add(windowBottomVentDDLCell);
                windowUnevenVentsRowBottom.Cells.Add(windowUnevenVentsDoneRADCell);

                tblWindowDetails.Rows.Add(windowUnevenVentsRowBottom);

                #endregion



                #endregion

                #region Table:Sixteenth Row Window V4T Vinyl Tint (tblWindowDetails)

                TableRow windowTintRow = new TableRow();
                windowTintRow.ID = "rowWindowTint" + title;
                windowTintRow.Attributes.Add("style", "display:none;");
                TableCell windowTintLBLCell = new TableCell();
                TableCell windowTintDDLCell = new TableCell();

                Label windowTintLBL = new Label();
                windowTintLBL.ID = "lblWindowTint" + title;
                windowTintLBL.Text = title + " Tint:";

                DropDownList windowTintDDL = new DropDownList();
                windowTintDDL.ID = "ddlWindowTint" + title;
                windowTintDDL.Attributes.Add("onchange", "windowStyle('" + title + "');");

                if (title == "Vinyl")
                {
                    for (int j = 0; j < Constants.DOOR_V4T_VINYL_OPTIONS.Count(); j++)
                    {
                        windowTintDDL.Items.Add(new ListItem(Constants.DOOR_V4T_VINYL_OPTIONS[j], Constants.DOOR_V4T_VINYL_OPTIONS[j]));
                    }
                }
                else if (title == "Glass")
                {
                    for (int j = 0; j < Constants.GLASS_TINTS.Count(); j++)
                    {
                        windowTintDDL.Items.Add(new ListItem(Constants.GLASS_TINTS[j], Constants.GLASS_TINTS[j]));
                    }
                }

                //windowTintDDL.Attributes.Add("onchange", "checkQuestion3()");
                windowTintLBL.AssociatedControlID = "ddlWindowTint" + title;

                windowTintLBLCell.Controls.Add(windowTintLBL);
                windowTintDDLCell.Controls.Add(windowTintDDL);

                tblWindowDetails.Rows.Add(windowTintRow);

                windowTintRow.Cells.Add(windowTintLBLCell);
                windowTintRow.Cells.Add(windowTintDDLCell);

                addMixedTintDropdowns(title, tblWindowDetails);


                #endregion

                #region Table:Third Row Color of Window (tblWindowDetails)

                TableRow colourOfWindowRow = new TableRow();
                colourOfWindowRow.ID = "rowWindowColour" + title;
                colourOfWindowRow.Attributes.Add("style", "display:none;");
                TableCell colourOfWindowLBLCell = new TableCell();
                TableCell colourOfWindowDDLCell = new TableCell();

                Label colourOfWindowLBL = new Label();
                colourOfWindowLBL.ID = "lblWindowColour" + title;
                colourOfWindowLBL.Text = "Frame Colour:";

                DropDownList colourOfWindowDDL = new DropDownList();
                colourOfWindowDDL.ID = "ddlWindowColour" + title;
                for (int j = 0; j < Constants.DOOR_COLOURS.Count(); j++)
                {
                    colourOfWindowDDL.Items.Add(new ListItem(Constants.DOOR_COLOURS[j], Constants.DOOR_COLOURS[j]));
                }

                colourOfWindowLBL.AssociatedControlID = "ddlWindowColour" + title;


                colourOfWindowLBLCell.Controls.Add(colourOfWindowLBL);
                colourOfWindowDDLCell.Controls.Add(colourOfWindowDDL);

                tblWindowDetails.Rows.Add(colourOfWindowRow);

                colourOfWindowRow.Cells.Add(colourOfWindowLBLCell);
                colourOfWindowRow.Cells.Add(colourOfWindowDDLCell);

                #endregion

                #region Table:Eight Row Window Inside Mount (tblWindowDetails)

                TableRow windowInsideMountRow = new TableRow();
                windowInsideMountRow.ID = "rowWindowInsideMount" + title;
                windowInsideMountRow.Attributes.Add("style", "display:none;");
                TableCell windowInsideMountLBLCell = new TableCell();
                TableCell windowInsideMountRADCell = new TableCell();

                Label windowMountLBLMain = new Label();
                windowMountLBLMain.ID = "lblWindowMountMain" + title;
                windowMountLBLMain.Text = "Mount:";

                Label windowInsideMountLBLRad = new Label();
                windowInsideMountLBLRad.ID = "lblWindowInsideMount" + title;

                Label windowInsideMountLBL = new Label();
                windowInsideMountLBL.ID = "lblWindowInsideMountRad" + title;
                windowInsideMountLBL.Text = "ISM";

                RadioButton windowInsideMountRAD = new RadioButton();
                windowInsideMountRAD.ID = "radWindowInsideMount" + title;
                windowInsideMountRAD.Attributes.Add("value", "ISM");
                windowInsideMountRAD.GroupName = "Mount" + title;
                windowInsideMountRAD.Attributes.Add("onclick", "windowStyle('" + title + "');");

                windowInsideMountLBLRad.AssociatedControlID = "radWindowInsideMount" + title;
                windowInsideMountLBL.AssociatedControlID = "radWindowInsideMount" + title;


                windowInsideMountLBLCell.Controls.Add(windowMountLBLMain);

                windowInsideMountRADCell.Controls.Add(windowInsideMountRAD);
                windowInsideMountRADCell.Controls.Add(windowInsideMountLBLRad);
                windowInsideMountRADCell.Controls.Add(windowInsideMountLBL);

                tblWindowDetails.Rows.Add(windowInsideMountRow);

                windowInsideMountRow.Cells.Add(windowInsideMountLBLCell);
                windowInsideMountRow.Cells.Add(windowInsideMountRADCell);

                #endregion

                #region Table:Ninth Row Window Outside Mount (tblWindowDetails)

                TableRow windowOutsideMountRow = new TableRow();
                windowOutsideMountRow.ID = "rowWindowOutsideMount" + title;
                windowOutsideMountRow.Attributes.Add("style", "display:none;");
                TableCell windowOutsideMountLBLCell = new TableCell();
                TableCell windowOutsideMountRADCell = new TableCell();

                Label windowOutsideMountLBLRad = new Label();
                windowOutsideMountLBLRad.ID = "lblWindowOutsideMountRad" + title;

                Label windowOutsideMountLBL = new Label();
                windowOutsideMountLBL.ID = "lblWindowOutsideMount" + title;
                windowOutsideMountLBL.Text = "OSM";

                RadioButton windowOutsideMountRAD = new RadioButton();
                windowOutsideMountRAD.ID = "radWindowOutsideMount" + title;
                windowOutsideMountRAD.Attributes.Add("value", "OSM");
                windowOutsideMountRAD.GroupName = "Mount" + title;
                windowOutsideMountRAD.Checked = true;
                windowOutsideMountRAD.Attributes.Add("onclick", "windowStyle('" + title + "');");

                windowOutsideMountLBLRad.AssociatedControlID = "radWindowOutsideMount" + title;
                windowOutsideMountLBL.AssociatedControlID = "radWindowOutsideMount" + title;


                windowOutsideMountRADCell.Controls.Add(windowOutsideMountRAD);
                windowOutsideMountRADCell.Controls.Add(windowOutsideMountLBLRad);
                windowOutsideMountRADCell.Controls.Add(windowOutsideMountLBL);

                tblWindowDetails.Rows.Add(windowOutsideMountRow);

                windowOutsideMountRow.Cells.Add(windowOutsideMountLBLCell);
                windowOutsideMountRow.Cells.Add(windowOutsideMountRADCell);

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

                ListItem standard = new ListItem("18 x 16 Mesh (Standard)", "18 x 16 Mesh (Standard)");
                ListItem noSeeUms = new ListItem("No-See-Ums 20 x 20 Mesh", "No-See-Ums 20 x 20 Mesh");
                ListItem betterVueInsect = new ListItem("Better Vue Insect Screen", "Better Vue Insect Screen");
                ListItem solarInsect = new ListItem("Solar Insect Screening", "Solar Insect Screening");
                ListItem tuff = new ListItem("Tuff Screen", "Tuff Screen");

                windowScreenOptionsDDL.Items.Add(standard);
                windowScreenOptionsDDL.Items.Add(noSeeUms);
                windowScreenOptionsDDL.Items.Add(betterVueInsect);
                windowScreenOptionsDDL.Items.Add(solarInsect);
                windowScreenOptionsDDL.Items.Add(tuff);

                //for (int j = 0; j < Constants.SCREEN_TYPES.Count(); j++)
                //{
                //    windowScreenOptionsDDL.Items.Add(new ListItem(Constants.SCREEN_TYPES[j], Constants.SCREEN_TYPES[j]));
                //}

                windowScreenOptionsLBL.AssociatedControlID = "ddlWindowScreenOptions" + title;


                windowScreenOptionsLBLCell.Controls.Add(windowScreenOptionsLBL);
                windowScreenOptionsDDLCell.Controls.Add(windowScreenOptionsDDL);

                tblWindowDetails.Rows.Add(windowScreenOptionsRow);

                windowScreenOptionsRow.Cells.Add(windowScreenOptionsLBLCell);
                windowScreenOptionsRow.Cells.Add(windowScreenOptionsDDLCell);

                #endregion



                #region Table:# Row Add This Window (tblWindowDetails)

                TableRow windowButtonRow = new TableRow();
                windowButtonRow.ID = "rowAddWindow" + title;
                windowButtonRow.Attributes.Add("style", "display:inherit;");
                TableCell windowAddButtonCell = new TableCell();
                TableCell windowFillButtonCell = new TableCell();

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
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            loadDetails("Window");
            #region Loop to display Window types as radio buttons
            /*
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

                windowTitleLBLCell.Controls.Add(windowTitleLBL);

                tblWindowDetails.Rows.Add(windowTitleRow);

                windowTitleRow.Cells.Add(windowTitleLBLCell);

                #endregion

                #region Table: First Row Window Orientation i.e. Horizontal or Vertical (tblWindowDetails)

                //RadioButton verticalRadio = new RadioButton();
                //RadioButton horizontalRadio = new RadioButton();

                //TableRow windowOrientationRow = new TableRow();
                //TableRow windowOrientationRow2 = new TableRow();
                //windowOrientationRow.ID = "rowWindowOrientation" + title;
                ////windowOrientationRow.Attributes.Add("style", "display:none;");
                //windowOrientationRow2.ID = "rowWindowOrientation2" + title;
                ////windowOrientationRow2.Attributes.Add("style", "display:none;");
                //TableCell windowOrientationLBLCell = new TableCell();
                //TableCell windowVerticalRADCell = new TableCell();
                //TableCell windowHorizontalRADCell = new TableCell();
                //TableCell windowOrientationBlank = new TableCell();

                //Label windowOrientationLBL = new Label();
                //windowOrientationLBL.ID = "lblWindowOrientation" + title;
                //windowOrientationLBL.Text = "Orientation";

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

                if (title == "Vinyl")
                {
                    ListItem v4t = new ListItem("Vertical 4 Track", "Vertical 4 Track");
                    ListItem h2t = new ListItem("Horizontal 2 Track", "Horizontal 2 Track");
                    ListItem h3t = new ListItem("Horizontal 3 Track", "Horizontal 3 Track");
                    ListItem h4t = new ListItem("Horizontal 4 Track", "Horizontal 4 Track");
                    ListItem fixedLite = new ListItem("Vinyl Fixed Lite", "Vinyl Fixed Lite");
                    ListItem trap = new ListItem("Vinyl Trapezoid", "Vinyl Trapezoid");

                    windowStyleDDL.Items.Add(v4t);
                    windowStyleDDL.Items.Add(h2t);
                    windowStyleDDL.Items.Add(h3t);
                    windowStyleDDL.Items.Add(h4t);
                    windowStyleDDL.Items.Add(fixedLite);
                    windowStyleDDL.Items.Add(trap);
                }
                else if (title == "Glass")
                {
                    ListItem aluminumXXHorizontalRoller = new ListItem("Aluminum XX Horizontal Roller", "Aluminum XX Horizontal Roller");
                    ListItem aluminumFramedPicture = new ListItem("Aluminum Framed Picture", "Aluminum Framed Picture");
                    ListItem aluminumFramedTrapezoid = new ListItem("Aluminum Framed Trapezoid", "Aluminum Framed Trapezoid");
                    ListItem pvcXOSingleGlazedHorizontalRoller = new ListItem("PVC XO Single Glazed Horizontal Roller", "PVC XO Single Glazed Horizontal Roller");
                    ListItem pvcFramedSingleGlazedPicture = new ListItem("PVC Framed Single Glazed Picture", "PVC Framed Single Glazed Picture");
                    ListItem pvcFramedSingleGlazedTrapezoid = new ListItem("PVC Framed Single Glazed Trapezoid", "PVC Framed Single Glazed Trapezoid");

                    windowStyleDDL.Items.Add(aluminumXXHorizontalRoller);
                    windowStyleDDL.Items.Add(aluminumFramedPicture);
                    windowStyleDDL.Items.Add(aluminumFramedTrapezoid);
                    windowStyleDDL.Items.Add(pvcXOSingleGlazedHorizontalRoller);
                    windowStyleDDL.Items.Add(pvcFramedSingleGlazedPicture);
                    windowStyleDDL.Items.Add(pvcFramedSingleGlazedTrapezoid);
                }
                else if (title == "Screen")
                {
                    ListItem screenFixedLite = new ListItem("Screen Fixed Lite", "Screen Fixed Lite");
                    windowStyleDDL.Items.Add(screenFixedLite);
                }
                windowStyleLBL.AssociatedControlID = "ddlWindowStyle" + title;

                windowStyleLBLCell.Controls.Add(windowStyleLBL);
                windowStyleDDLCell.Controls.Add(windowStyleDDL);

                tblWindowDetails.Rows.Add(windowStyleRow);

                windowStyleRow.Cells.Add(windowStyleLBLCell);
                windowStyleRow.Cells.Add(windowStyleDDLCell);



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
                windowNumberOfVentsDDL.Attributes.Add("onchange", "windowStyle('" + title + "');");
                ListItem V2 = new ListItem("2", "2");
                ListItem V3 = new ListItem("3", "3");
                ListItem V4 = new ListItem("4", "4");
                ListItem V6S = new ListItem("6 Stereo", "6");
                ListItem V8S = new ListItem("8 Stereo", "8");
                ListItem V9S = new ListItem("9 Stereo", "9");
                ListItem V12S = new ListItem("12 Stereo", "12");

                windowNumberOfVentsDDL.Items.Add(V2);
                windowNumberOfVentsDDL.Items.Add(V3);
                windowNumberOfVentsDDL.Items.Add(V4);
                windowNumberOfVentsDDL.Items.Add(V6S);
                windowNumberOfVentsDDL.Items.Add(V8S);
                windowNumberOfVentsDDL.Items.Add(V9S);
                windowNumberOfVentsDDL.Items.Add(V12S);

                //for (int j = 0; j < Constants.DOOR_NUMBER_OF_VENTS.Count(); j++)
                //{
                //    windowNumberOfVentsDDL.Items.Add(new ListItem(Constants.DOOR_NUMBER_OF_VENTS[j], Constants.DOOR_NUMBER_OF_VENTS[j]));
                //}

                windowNumberOfVentsLBL.AssociatedControlID = "ddlWindowNumberOfVents" + title;

                //windowNumberOfVentsDDL.Attributes.Add("onchange", "checkQuestion3()");

                windowNumberOfVentsLBLCell.Controls.Add(windowNumberOfVentsLBL);
                windowNumberOfVentsDDLCell.Controls.Add(windowNumberOfVentsDDL);


                windowNumberOfVentsRow.Cells.Add(windowNumberOfVentsLBLCell);
                windowNumberOfVentsRow.Cells.Add(windowNumberOfVentsDDLCell);

                #region Uneven Vents Checkbox
                //TableRow windowUnevenVentsRow = new TableRow();
                //windowUnevenVentsRow.ID = "rowWindowUnevenVents" + title;
                //windowUnevenVentsRow.Attributes.Add("style", "display:none;");
                //TableCell windowUnevenVentsLBLCell = new TableCell();
                TableCell windowUnevenVentsCHKCell = new TableCell();
                windowUnevenVentsCHKCell.Attributes.Add("style", "display:none;");
                windowUnevenVentsCHKCell.ID = "rowWindowUnevenVents" + title;
                //Label windowUnevenVentsLBLMain = new Label();
                //windowUnevenVentsLBLMain.ID = "lblWindowUnevenVentsMain" + title;
                //windowUnevenVentsLBLMain.Text = "Uneven Vents:";

                Label windowUnevenVentsLBLChk = new Label();
                windowUnevenVentsLBLChk.ID = "lblWindowUnevenVents" + title;

                Label windowUnevenVentsLBL = new Label();
                windowUnevenVentsLBL.ID = "lblWindowUnevenVentsRad" + title;
                windowUnevenVentsLBL.Text = " Uneven Vents";

                CheckBox windowUnevenVentsCHK = new CheckBox();
                windowUnevenVentsCHK.ID = "radWindowUnevenVents" + title;
                windowUnevenVentsCHK.Attributes.Add("value", "UnevenVents");
                //windowUnevenVentsRAD.GroupName = "Mount" + title;
                windowUnevenVentsCHK.Attributes.Add("onclick", "windowStyle('" + title + "');");

                windowUnevenVentsLBLChk.AssociatedControlID = "radWindowUnevenVents" + title;
                windowUnevenVentsLBL.AssociatedControlID = "radWindowUnevenVents" + title;


                //windowUnevenVentsLBLCell.Controls.Add(windowUnevenVentsLBLMain);

                windowUnevenVentsCHKCell.Controls.Add(windowUnevenVentsCHK);
                windowUnevenVentsCHKCell.Controls.Add(windowUnevenVentsLBLChk);
                windowUnevenVentsCHKCell.Controls.Add(windowUnevenVentsLBL);

                windowNumberOfVentsRow.Cells.Add(windowUnevenVentsCHKCell);
                //tblWindowDetails.Rows.Add(windowUnevenVentsRow);

                //windowUnevenVentsRow.Cells.Add(windowUnevenVentsLBLCell);
                //windowUnevenVentsRow.Cells.Add(windowUnevenVentsCHKCell);
                #endregion

                tblWindowDetails.Rows.Add(windowNumberOfVentsRow);

                #endregion


                #region Table:Sixteenth Row Window V4T Vinyl Tint (tblWindowDetails)


                TableRow windowVinylTintRow = new TableRow();
                windowVinylTintRow.ID = "rowWindowVinylTint" + title;
                windowVinylTintRow.Attributes.Add("style", "display:none;");
                TableCell windowVinylTintLBLCell = new TableCell();
                TableCell windowVinylTintDDLCell = new TableCell();

                Label windowVinylTintLBL = new Label();
                windowVinylTintLBL.ID = "lblWindowVinylTint" + title;
                windowVinylTintLBL.Text = "Vinyl Tint:";

                DropDownList windowVinylTintDDL = new DropDownList();
                windowVinylTintDDL.ID = "ddlWindowVinylTint" + title;
                windowVinylTintDDL.Attributes.Add("onchange", "windowStyle('" + title + "');");
                for (int j = 0; j < Constants.DOOR_V4T_VINYL_OPTIONS.Count(); j++)
                {
                    windowVinylTintDDL.Items.Add(new ListItem(Constants.DOOR_V4T_VINYL_OPTIONS[j], Constants.DOOR_V4T_VINYL_OPTIONS[j]));
                }

                //windowVinylTintDDL.Attributes.Add("onchange", "checkQuestion3()");
                windowVinylTintLBL.AssociatedControlID = "ddlWindowVinylTint" + title;

                windowVinylTintLBLCell.Controls.Add(windowVinylTintLBL);
                windowVinylTintDDLCell.Controls.Add(windowVinylTintDDL);

                tblWindowDetails.Rows.Add(windowVinylTintRow);

                windowVinylTintRow.Cells.Add(windowVinylTintLBLCell);
                windowVinylTintRow.Cells.Add(windowVinylTintDDLCell);

                addMixedTintDropdowns(title, tblWindowDetails);


                #endregion

                //TableRow windowTintMixedRow = new TableRow();
                //windowTintMixedRow.ID = "rowWindowTintMixed" + title;
                //windowTintMixedRow.Attributes.Add("style", "display:none;");
                //TableCell windowTintMixedLBLCell = new TableCell();
                //TableCell windowTintMixedRADCell = new TableCell();

                //DropDownList windowTintMixedDDL = new DropDownList();
                //windowTintMixedDDL.ID = "ddlWindowVinylTint" + title;
                //for (int j = 0; j < Constants.DOOR_V4T_VINYL_OPTIONS.Count(); j++)
                //{
                //    windowTintMixedDDL.Items.Add(new ListItem(Constants.DOOR_V4T_VINYL_OPTIONS[j], Constants.DOOR_V4T_VINYL_OPTIONS[j]));
                //}


                //windowOutsideMountRADCell.Controls.Add(windowOutsideMountRAD);
                //windowOutsideMountRADCell.Controls.Add(windowOutsideMountLBLRad);
                //windowOutsideMountRADCell.Controls.Add(windowOutsideMountLBL);

                //tblWindowDetails.Rows.Add(windowOutsideMountRow);

                //windowOutsideMountRow.Cells.Add(windowOutsideMountLBLCell);
                //windowOutsideMountRow.Cells.Add(windowOutsideMountRADCell);






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


                windowTransomVinylTypesLBLCell.Controls.Add(windowTransomVinylLBL);
                windowTransomVinylTypesDDLCell.Controls.Add(windowTransomVinylDDL);

                tblWindowDetails.Rows.Add(windowTransomVinylRow);

                windowTransomVinylRow.Cells.Add(windowTransomVinylTypesLBLCell);
                windowTransomVinylRow.Cells.Add(windowTransomVinylTypesDDLCell);

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


                windowTransomGlassTypesLBLCell.Controls.Add(windowTransomGlassLBL);
                windowTransomGlassTypesDDLCell.Controls.Add(windowTransomGlassDDL);

                tblWindowDetails.Rows.Add(windowTransomGlassRow);

                windowTransomGlassRow.Cells.Add(windowTransomGlassTypesLBLCell);
                windowTransomGlassRow.Cells.Add(windowTransomGlassTypesDDLCell);

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


                windowKickplateLBLCell.Controls.Add(windowKickplateLBL);
                windowKickplateDDLCell.Controls.Add(windowKickplateDDL);

                tblWindowDetails.Rows.Add(windowKickplateRow);

                windowKickplateRow.Cells.Add(windowKickplateLBLCell);
                windowKickplateRow.Cells.Add(windowKickplateDDLCell);

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


                windowCustomKickplateLBLCell.Controls.Add(windowCustomKickplateLBL);
                windowCustomKickplateTXTCell.Controls.Add(windowCustomKickplateTXT);
                windowCustomKickplateDDLCell.Controls.Add(inchCustomKickplate);

                tblWindowDetails.Rows.Add(windowCustomKickplateRow);

                windowCustomKickplateRow.Cells.Add(windowCustomKickplateLBLCell);
                windowCustomKickplateRow.Cells.Add(windowCustomKickplateTXTCell);
                windowCustomKickplateRow.Cells.Add(windowCustomKickplateDDLCell);

                #endregion

                #region Table:Third Row Color of Window (tblWindowDetails)

                TableRow colourOfWindowRow = new TableRow();
                colourOfWindowRow.ID = "rowWindowColour" + title;
                colourOfWindowRow.Attributes.Add("style", "display:none;");
                TableCell colourOfWindowLBLCell = new TableCell();
                TableCell colourOfWindowDDLCell = new TableCell();

                Label colourOfWindowLBL = new Label();
                colourOfWindowLBL.ID = "lblWindowColour" + title;
                colourOfWindowLBL.Text = "Frame Colour:";

                DropDownList colourOfWindowDDL = new DropDownList();
                colourOfWindowDDL.ID = "ddlWindowColour" + title;
                for (int j = 0; j < Constants.DOOR_COLOURS.Count(); j++)
                {
                    colourOfWindowDDL.Items.Add(new ListItem(Constants.DOOR_COLOURS[j], Constants.DOOR_COLOURS[j]));
                }

                colourOfWindowLBL.AssociatedControlID = "ddlWindowColour" + title;


                colourOfWindowLBLCell.Controls.Add(colourOfWindowLBL);
                colourOfWindowDDLCell.Controls.Add(colourOfWindowDDL);

                tblWindowDetails.Rows.Add(colourOfWindowRow);

                colourOfWindowRow.Cells.Add(colourOfWindowLBLCell);
                colourOfWindowRow.Cells.Add(colourOfWindowDDLCell);

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


                windowHeightLBLCell.Controls.Add(windowHeightLBL);
                windowHeightDDLCell.Controls.Add(windowHeightDDL);

                tblWindowDetails.Rows.Add(windowHeightRow);

                windowHeightRow.Cells.Add(windowHeightLBLCell);
                windowHeightRow.Cells.Add(windowHeightDDLCell);

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


                windowCustomHeightLBLCell.Controls.Add(windowCustomHeightLBL);
                windowCustomHeightTXTCell.Controls.Add(windowCustomHeightTXT);
                windowCustomHeightDDLCell.Controls.Add(inchCustomHeight);

                tblWindowDetails.Rows.Add(windowCustomHeightRow);

                windowCustomHeightRow.Cells.Add(windowCustomHeightLBLCell);
                windowCustomHeightRow.Cells.Add(windowCustomHeightTXTCell);
                windowCustomHeightRow.Cells.Add(windowCustomHeightDDLCell);

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


                windowWidthLBLCell.Controls.Add(windowWidthLBL);
                windowWidthDDLCell.Controls.Add(windowWidthDDL);

                tblWindowDetails.Rows.Add(windowWidthRow);

                windowWidthRow.Cells.Add(windowWidthLBLCell);
                windowWidthRow.Cells.Add(windowWidthDDLCell);

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


                windowCustomWidthLBLCell.Controls.Add(windowCustomWidthLBL);
                windowCustomWidthTXTCell.Controls.Add(windowCustomWidthTXT);
                windowCustomWidthDDLCell.Controls.Add(inchCustomWidth);

                tblWindowDetails.Rows.Add(windowCustomWidthRow);

                windowCustomWidthRow.Cells.Add(windowCustomWidthLBLCell);
                windowCustomWidthRow.Cells.Add(windowCustomWidthTXTCell);
                windowCustomWidthRow.Cells.Add(windowCustomWidthDDLCell);

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


                windowOperatorLHHLBLCell.Controls.Add(windowOperatorLHHLBLMain);

                windowOperatorLHHRADCell.Controls.Add(windowOperatorLHHRad);
                windowOperatorLHHRADCell.Controls.Add(windowOperatorLHHLBLRad);
                windowOperatorLHHRADCell.Controls.Add(windowOperatorLHHLBL);

                tblWindowDetails.Rows.Add(windowOperatorLHHRow);

                windowOperatorLHHRow.Cells.Add(windowOperatorLHHLBLCell);
                windowOperatorLHHRow.Cells.Add(windowOperatorLHHRADCell);

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

                windowOperatorRHHRADCell.Controls.Add(windowOperatorRHHRad);
                windowOperatorRHHRADCell.Controls.Add(windowOperatorRHHLBLRad);
                windowOperatorRHHRADCell.Controls.Add(windowOperatorRHHLBL);

                tblWindowDetails.Rows.Add(windowOperatorRHHRow);

                windowOperatorRHHRow.Cells.Add(windowOperatorRHHLBLCell);
                windowOperatorRHHRow.Cells.Add(windowOperatorRHHRADCell);

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


                windowBoxHeaderLBLCell.Controls.Add(windowBoxHeaderLBL);
                windowBoxHeaderDDLCell.Controls.Add(windowBoxHeaderDDL);

                tblWindowDetails.Rows.Add(windowBoxHeaderRow);

                windowBoxHeaderRow.Cells.Add(windowBoxHeaderLBLCell);
                windowBoxHeaderRow.Cells.Add(windowBoxHeaderDDLCell);

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


                windowGlassTintLBLCell.Controls.Add(windowGlassTintLBL);
                windowGlassTintDDLCell.Controls.Add(windowGlassTintDDL);

                tblWindowDetails.Rows.Add(windowGlassTintRow);

                windowGlassTintRow.Cells.Add(windowGlassTintLBLCell);
                windowGlassTintRow.Cells.Add(windowGlassTintDDLCell);


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


                windowHingeLHHLBLCell.Controls.Add(windowHingeLHHLBLMain);

                windowHingeLHHRADCell.Controls.Add(windowHingeLHHRad);
                windowHingeLHHRADCell.Controls.Add(windowHingeLHHLBLRad);
                windowHingeLHHRADCell.Controls.Add(windowHingeLHHLBL);

                tblWindowDetails.Rows.Add(windowHingeLHHRow);

                windowHingeLHHRow.Cells.Add(windowHingeLHHLBLCell);
                windowHingeLHHRow.Cells.Add(windowHingeLHHRADCell);

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


                windowHingeRHHRADCell.Controls.Add(windowHingeRHHRad);
                windowHingeRHHRADCell.Controls.Add(windowHingeRHHLBLRad);
                windowHingeRHHRADCell.Controls.Add(windowHingeRHHLBL);

                tblWindowDetails.Rows.Add(windowHingeRHHRow);

                windowHingeRHHRow.Cells.Add(windowHingeRHHLBLCell);
                windowHingeRHHRow.Cells.Add(windowHingeRHHRADCell);

                #endregion


                #region Table:Eight Row Window Inside Mount (tblWindowDetails)

                TableRow windowInsideMountRow = new TableRow();
                windowInsideMountRow.ID = "rowWindowInsideMount" + title;
                windowInsideMountRow.Attributes.Add("style", "display:none;");
                TableCell windowInsideMountLBLCell = new TableCell();
                TableCell windowInsideMountRADCell = new TableCell();

                Label windowMountLBLMain = new Label();
                windowMountLBLMain.ID = "lblWindowMountMain" + title;
                windowMountLBLMain.Text = "Mount:";

                Label windowInsideMountLBLRad = new Label();
                windowInsideMountLBLRad.ID = "lblWindowInsideMount" + title;

                Label windowInsideMountLBL = new Label();
                windowInsideMountLBL.ID = "lblWindowInsideMountRad" + title;
                windowInsideMountLBL.Text = "ISM";

                RadioButton windowInsideMountRAD = new RadioButton();
                windowInsideMountRAD.ID = "radWindowInsideMount" + title;
                windowInsideMountRAD.Attributes.Add("value", "ISM");
                windowInsideMountRAD.GroupName = "Mount" + title;
                windowInsideMountRAD.Attributes.Add("onclick", "windowStyle('" + title + "');");

                windowInsideMountLBLRad.AssociatedControlID = "radWindowInsideMount" + title;
                windowInsideMountLBL.AssociatedControlID = "radWindowInsideMount" + title;


                windowInsideMountLBLCell.Controls.Add(windowMountLBLMain);

                windowInsideMountRADCell.Controls.Add(windowInsideMountRAD);
                windowInsideMountRADCell.Controls.Add(windowInsideMountLBLRad);
                windowInsideMountRADCell.Controls.Add(windowInsideMountLBL);

                tblWindowDetails.Rows.Add(windowInsideMountRow);

                windowInsideMountRow.Cells.Add(windowInsideMountLBLCell);
                windowInsideMountRow.Cells.Add(windowInsideMountRADCell);

                #endregion

                #region Table:Ninth Row Window Outside Mount (tblWindowDetails)

                TableRow windowOutsideMountRow = new TableRow();
                windowOutsideMountRow.ID = "rowWindowOutsideMount" + title;
                windowOutsideMountRow.Attributes.Add("style", "display:none;");
                TableCell windowOutsideMountLBLCell = new TableCell();
                TableCell windowOutsideMountRADCell = new TableCell();

                Label windowOutsideMountLBLRad = new Label();
                windowOutsideMountLBLRad.ID = "lblWindowOutsideMountRad" + title;

                Label windowOutsideMountLBL = new Label();
                windowOutsideMountLBL.ID = "lblWindowOutsideMount" + title;
                windowOutsideMountLBL.Text = "OSM";

                RadioButton windowOutsideMountRAD = new RadioButton();
                windowOutsideMountRAD.ID = "radWindowOutsideMount" + title;
                windowOutsideMountRAD.Attributes.Add("value", "OSM");
                windowOutsideMountRAD.GroupName = "Mount" + title;
                windowOutsideMountRAD.Checked = true;
                windowOutsideMountRAD.Attributes.Add("onclick", "windowStyle('" + title + "');");

                windowOutsideMountLBLRad.AssociatedControlID = "radWindowOutsideMount" + title;
                windowOutsideMountLBL.AssociatedControlID = "radWindowOutsideMount" + title;


                windowOutsideMountRADCell.Controls.Add(windowOutsideMountRAD);
                windowOutsideMountRADCell.Controls.Add(windowOutsideMountLBLRad);
                windowOutsideMountRADCell.Controls.Add(windowOutsideMountLBL);

                tblWindowDetails.Rows.Add(windowOutsideMountRow);

                windowOutsideMountRow.Cells.Add(windowOutsideMountLBLCell);
                windowOutsideMountRow.Cells.Add(windowOutsideMountRADCell);

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

                ListItem standard = new ListItem("18 x 16 Mesh (Standard)", "18 x 16 Mesh (Standard)");
                ListItem noSeeUms = new ListItem("No-See-Ums 20 x 20 Mesh", "No-See-Ums 20 x 20 Mesh");
                ListItem betterVueInsect = new ListItem("Better Vue Insect Screen", "Better Vue Insect Screen");
                ListItem solarInsect = new ListItem("Solar Insect Screening", "Solar Insect Screening");
                ListItem tuff = new ListItem("Tuff Screen", "Tuff Screen");

                windowScreenOptionsDDL.Items.Add(standard);
                windowScreenOptionsDDL.Items.Add(noSeeUms);
                windowScreenOptionsDDL.Items.Add(betterVueInsect);
                windowScreenOptionsDDL.Items.Add(solarInsect);
                windowScreenOptionsDDL.Items.Add(tuff);

                //for (int j = 0; j < Constants.SCREEN_TYPES.Count(); j++)
                //{
                //    windowScreenOptionsDDL.Items.Add(new ListItem(Constants.SCREEN_TYPES[j], Constants.SCREEN_TYPES[j]));
                //}

                windowScreenOptionsLBL.AssociatedControlID = "ddlWindowScreenOptions" + title;


                windowScreenOptionsLBLCell.Controls.Add(windowScreenOptionsLBL);
                windowScreenOptionsDDLCell.Controls.Add(windowScreenOptionsDDL);

                tblWindowDetails.Rows.Add(windowScreenOptionsRow);

                windowScreenOptionsRow.Cells.Add(windowScreenOptionsLBLCell);
                windowScreenOptionsRow.Cells.Add(windowScreenOptionsDDLCell);

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


                windowHardwareLBLCell.Controls.Add(windowHardwareLBL);
                windowHardwareDDLCell.Controls.Add(windowHardwareDDL);

                tblWindowDetails.Rows.Add(windowHardwareRow);

                windowHardwareRow.Cells.Add(windowHardwareLBLCell);
                windowHardwareRow.Cells.Add(windowHardwareDDLCell);


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


                windowPositionDDLLBLCell.Controls.Add(windowPositionDDLLBL);
                windowPositionDDLDDLCell.Controls.Add(windowPositionDDLDDL);

                tblWindowDetails.Rows.Add(windowPositionDDLRow);


                windowPositionDDLRow.Cells.Add(windowPositionDDLLBLCell);
                windowPositionDDLRow.Cells.Add(windowPositionDDLDDLCell);

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

                windowPositionLBLCell.Controls.Add(windowPositionLBL);
                windowPositionTXTCell.Controls.Add(windowPositionTXT);
                windowPositionDDLCell.Controls.Add(inchSpecificLeft);

                tblWindowDetails.Rows.Add(windowPositionRow);

                windowPositionRow.Cells.Add(windowPositionLBLCell);
                windowPositionRow.Cells.Add(windowPositionTXTCell);
                windowPositionRow.Cells.Add(windowPositionDDLCell);

                #endregion

                #region Table: Window Mount (tblWindowDetails)

                ////Window insideMount radio button
                //RadioButton insideMountRadio = new RadioButton();
                //insideMountRadio.ID = "radInsideMount" + title; //Adding appropriate id to window insideMount radio button
                //insideMountRadio.GroupName = "windowMountRadios";         //Adding group name for all window insideMounts
                //insideMountRadio.Attributes.Add("onclick", "typeRowsDisplayed('" + title + "')"); //On click event to display the proper fields/rows


                ////Window insideMount radio button label for clickable area
                //Label insideMountLabelRadio = new Label();
                //insideMountLabelRadio.AssociatedControlID = "radInsideMount" + title;   //Tying this label to the radio button

                ////Window insideMount radio button label text
                //Label insideMountLabel = new Label();
                //insideMountLabel.AssociatedControlID = "radInsideMount" + title;    //Tying this label to the radio button
                //insideMountLabel.Text = "Inside Mount";     //Displaying the proper texted based on current title variable


                ////Window outsideMount radio button
                //RadioButton outsideMountRadio = new RadioButton();
                //outsideMountRadio.ID = "radOutsideMount" + title; //Adding appropriate id to window outsideMount radio button
                //outsideMountRadio.GroupName = "windowMountRadios";         //Adding group name for all window outsideMounts
                //outsideMountRadio.Attributes.Add("onclick", "typeRowsDisplayed('" + title + "')"); //On click event to display the proper fields/rows


                ////Window outsideMount radio button label for clickable area
                //Label outsideMountLabelRadio = new Label();
                //outsideMountLabelRadio.AssociatedControlID = "radOutsideMount" + title;   //Tying this label to the radio button

                ////Window outsideMount radio button label text
                //Label outsideMountLabel = new Label();
                //outsideMountLabel.AssociatedControlID = "radOutsideMount" + title;    //Tying this label to the radio button
                //outsideMountLabel.Text = "Outside Mount";     //Displaying the proper texted based on current title variable

                //Label mountLabel = new Label();
                //mountLabel.Text = "Window Mount:";

                //TableRow windowMountRow = new TableRow();
                //TableRow windowMountRow2 = new TableRow();
                //windowMountRow.ID = "rowWindowMount" + title;
                //windowMountRow.Attributes.Add("style", "display:none;");
                //windowMountRow2.ID = "rowWindowMount2" + title;
                //windowMountRow2.Attributes.Add("style", "display:none;");
                //TableCell windowMountLBLCell = new TableCell();
                //TableCell windowMountRADCell = new TableCell();
                //TableCell windowMountBlankCell = new TableCell();
                //TableCell windowMountRADCell2 = new TableCell();

                //windowMountBlankCell.Controls.Add(windowOrientationBlank);
                //windowMountLBLCell.Controls.Add(mountLabel);
                //windowMountRADCell.Controls.Add(insideMountRadio);
                //windowMountRADCell.Controls.Add(insideMountLabelRadio);
                //windowMountRADCell.Controls.Add(insideMountLabel);
                //windowMountRADCell2.Controls.Add(outsideMountRadio);
                //windowMountRADCell2.Controls.Add(outsideMountLabelRadio);
                //windowMountRADCell2.Controls.Add(outsideMountLabel);

                //windowMountRow.Cells.Add(windowMountLBLCell);
                //windowMountRow.Cells.Add(windowMountRADCell);
                //windowMountRow2.Cells.Add(windowMountBlankCell);
                //windowMountRow2.Cells.Add(windowMountRADCell2);


                //tblWindowDetails.Rows.Add(windowMountRow);
                //tblWindowDetails.Rows.Add(windowMountRow2);

                #endregion

                #region Table:# Row Add This Window (tblWindowDetails)

                TableRow windowButtonRow = new TableRow();
                windowButtonRow.ID = "rowAddWindow" + title;
                windowButtonRow.Attributes.Add("style", "display:inherit;");
                TableCell windowAddButtonCell = new TableCell();
                TableCell windowFillButtonCell = new TableCell();

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

            }*/
            #endregion
        }
    }
}
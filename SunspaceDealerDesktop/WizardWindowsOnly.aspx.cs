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
        List<Window> windowsOrdered = new List<Window>();

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
/*
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
                */
                #endregion

                #region done
                /*
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
                */
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
                //windowUnevenVentsRowTop.Cells.Add(windowUnevenVentsEditRADCell);
 
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
                //windowUnevenVentsRowBottom.Cells.Add(windowUnevenVentsDoneRADCell);

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

                Button windowButton = new Button();
                windowButton.ID = "btnAdd" + title;
                windowButton.Text = "Add this " + title + " window";
                windowButton.CssClass = "btnSubmit";

                windowAddButtonCell.Controls.Add(windowButton);

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


                #region PostBack functionality to store windows
                if (IsPostBack)
                {
                    if ((List<Window>)Session["windowsOrdered"] != null)
                    {
                        windowsOrdered = (List<Window>)Session["windowsOrdered"];
                    }

                    if (Request.Form["ctl00$MainContent$windowTypeRadios"] == "radTypeCabana")
                    {
                        //Window aWindow = getCabanaWindowFromForm();
                        //windowsOrdered.Add(aWindow);
                    }
                    else if (Request.Form["ctl00$MainContent$windowTypeRadios"] == "radTypeFrench")
                    {
                        //Window aWindow = getFrenchWindowFromForm();
                        //windowsOrdered.Add(aWindow);
                    }
                    else if (Request.Form["ctl00$MainContent$windowTypeRadios"] == "radTypePatio")
                    {
                        //Window aWindow = getPatioWindowFromForm();
                        //windowsOrdered.Add(aWindow);
                    }
                    Session.Add("windowsOrdered", windowsOrdered);
                }
                #endregion

                //populateSideBar(findNumberOfWindowTypes());


            }
        }


        #region getDoorFromForm methods
        /*
        /// <summary>
        /// This function creates a CabanaWindow object and stores the
        /// information entered on the page.
        /// </summary>
        /// <returns>CabanaWindow aWindow</returns>
        protected CabanaWindow getCabanaWindowFromForm()
        {
            CabanaWindow aWindow = new CabanaWindow();
            //moduleitem attributes
            aWindow.FEndHeight = aWindow.FStartHeight = 0;
            aWindow.FLength = 0;
            aWindow.Colour = Request.Form["ctl00$MainContent$ddlWindowColourCabana"];
            aWindow.ItemType = "Window";

            //base attributes
            aWindow.WindowType = "Cabana";
            aWindow.WindowStyle = Request.Form["ctl00$MainContent$ddlWindowStyleCabana"];
            aWindow.Kickplate = float.Parse(Request.Form["ctl00$MainContent$ddlWindowKickplateCabana"]);

            //cabana attributes
            aWindow.Height = float.Parse(Request.Form["ctl00$MainContent$ddlWindowHeightCabana"]);
            aWindow.Length = float.Parse(Request.Form["ctl00$MainContent$ddlWindowWidthCabana"]);
            aWindow.GlassTint = Request.Form["ctl00$MainContent$ddlWindowGlassTintCabana"];
            if (aWindow.WindowStyle == "Vertical 4 Track")
            {
                aWindow.VinylTint = Request.Form["ctl00$MainContent$ddlWindowVinylTintCabana"];
                aWindow.WindowWindow = new Window();
                aWindow.WindowWindow.NumVents = int.Parse(Request.Form["ctl00$MainContent$ddlWindowNumberOfVentsCabana"]);
                if (aWindow.VinylTint == "Mixed")
                {
                    if (aWindow.WindowWindow.NumVents == 2)
                    {
                        aWindow.VinylTint = Request.Form["ctl00$MainContent$ddlWindowTint0Cabana"] + Request.Form["ctl00$MainContent$ddlWindowTint1Cabana"];
                    }
                    else if (aWindow.WindowWindow.NumVents == 3)
                    {
                        aWindow.VinylTint = Request.Form["ctl00$MainContent$ddlWindowTint0Cabana"]
                            + Request.Form["ctl00$MainContent$ddlWindowTint1Cabana"]
                            + Request.Form["ctl00$MainContent$ddlWindowTint2Cabana"];
                    }
                    else if (aWindow.WindowWindow.NumVents == 4)
                    {
                        aWindow.VinylTint = Request.Form["ctl00$MainContent$ddlWindowTint0Cabana"]
                            + Request.Form["ctl00$MainContent$ddlWindowTint1Cabana"]
                            + Request.Form["ctl00$MainContent$ddlWindowTint2Cabana"]
                            + Request.Form["ctl00$MainContent$ddlWindowTint3Cabana"];
                    }
                }
            }
            else
            {
                aWindow.ScreenType = Request.Form["ctl00$MainContent$ddlWindowScreenOptionsCabana"];
            }
            aWindow.Hinge = Request.Form["ctl00$MainContent$WindowHingeCabana"];
            aWindow.Swing = Request.Form["ctl00$MainContent$SwingInOutCabana"];
            aWindow.HardwareType = Request.Form["ctl00$MainContent$ddlWindowHardwareCabana"];

            return aWindow;
        }

        /// <summary>
        /// This function creates a FrenchWindow object and stores the
        /// information entered on the page.
        /// </summary>
        /// <returns>FrenchWindow aWindow</returns>
        protected FrenchWindow getFrenchWindowFromForm()
        {
            FrenchWindow aWindow = new FrenchWindow();
            //moduleitem attributes
            aWindow.FEndHeight = aWindow.FStartHeight = 0;
            aWindow.FLength = 0;
            aWindow.Colour = Request.Form["ctl00$MainContent$ddlWindowColourFrench"];
            aWindow.ItemType = "Window";

            //base attributes
            aWindow.WindowType = "French";
            aWindow.WindowStyle = Request.Form["ctl00$MainContent$ddlWindowStyleFrench"];
            aWindow.Kickplate = float.Parse(Request.Form["ctl00$MainContent$ddlWindowKickplateFrench"]);

            //french attributes
            aWindow.Height = float.Parse(Request.Form["ctl00$MainContent$ddlWindowHeightFrench"]);
            aWindow.Length = float.Parse(Request.Form["ctl00$MainContent$ddlWindowWidthFrench"]);
            aWindow.GlassTint = Request.Form["ctl00$MainContent$ddlWindowGlassTintFrench"];
            if (aWindow.WindowStyle == "Vertical 4 Track")
            {
                aWindow.VinylTint = Request.Form["ctl00$MainContent$ddlWindowVinylTintFrench"];
                aWindow.WindowWindow = new Window();
                aWindow.WindowWindow.NumVents = int.Parse(Request.Form["ctl00$MainContent$ddlWindowNumberOfVentsFrench"]);
                if (aWindow.VinylTint == "Mixed")
                {
                    if (aWindow.WindowWindow.NumVents == 2)
                    {
                        aWindow.VinylTint = Request.Form["ctl00$MainContent$ddlWindowTint0French"]
                            + Request.Form["ctl00$MainContent$ddlWindowTint1French"];
                    }
                    else if (aWindow.WindowWindow.NumVents == 3)
                    {
                        aWindow.VinylTint = Request.Form["ctl00$MainContent$ddlWindowTint0French"]
                            + Request.Form["ctl00$MainContent$ddlWindowTint1French"]
                            + Request.Form["ctl00$MainContent$ddlWindowTint2French"];
                    }
                    else if (aWindow.WindowWindow.NumVents == 4)
                    {
                        aWindow.VinylTint = Request.Form["ctl00$MainContent$ddlWindowTint0French"]
                            + Request.Form["ctl00$MainContent$ddlWindowTint1French"]
                            + Request.Form["ctl00$MainContent$ddlWindowTint2French"]
                            + Request.Form["ctl00$MainContent$ddlWindowTint3French"];
                    }
                }
            }
            aWindow.ScreenType = Request.Form["ctl00$MainContent$ddlWindowScreenOptionsFrench"];
            aWindow.OperatingWindow = Request.Form["ctl00$MainContent$PrimaryOperatorFrench"];
            aWindow.Swing = Request.Form["ctl00$MainContent$SwingInOutFrench"];
            aWindow.HardwareType = Request.Form["ctl00$MainContent$ddlWindowHardwareFrench"];

            return aWindow;
        }

        /// <summary>
        /// This function creates a PatioWindow object and stores the
        /// information entered on the page.
        /// </summary>
        /// <returns>PatioWindow aWindow</returns>
        protected PatioWindow getPatioWindowFromForm()
        {
            PatioWindow aWindow = new PatioWindow();
            //moduleitem attributes
            aWindow.FEndHeight = aWindow.FStartHeight = 0;
            aWindow.FLength = 0;
            aWindow.Colour = Request.Form["ctl00$MainContent$ddlWindowColourPatio"];
            aWindow.ItemType = "Window";

            //base attributes
            aWindow.WindowType = "Patio";
            aWindow.WindowStyle = Request.Form["ctl00$MainContent$ddlWindowStylePatio"];
            //aWindow.ScreenType = ""; //CHANGEME
            aWindow.Kickplate = float.Parse(Request.Form["ctl00$MainContent$ddlWindowKickplatePatio"]);

            //patio attributes
            aWindow.Height = float.Parse(Request.Form["ctl00$MainContent$ddlWindowHeightPatio"]);
            aWindow.Length = float.Parse(Request.Form["ctl00$MainContent$ddlWindowWidthPatio"]);
            aWindow.GlassTint = Request.Form["ctl00$MainContent$ddlWindowGlassTintPatio"];
            //aWindow.ScreenType = ""; //CHANGEME
            aWindow.OperatingWindow = Request.Form["ctl00$MainContent$PrimaryOperatorPatio"];

            return aWindow;
        }
        */
        #endregion


        /// <summary>
        /// This function is used to find the amount of each type of 
        /// window that has been ordered.
        /// </summary>
        /// <returns>Tuple<int,int,int>(cabanaCount,frenchCount,patioCount)</returns>
        /// NOTE Tuple items:
        /// Item1:Cabana window count
        /// Item2:French window count
        /// Item3:Patio window count
        private Tuple<int, int, int> findNumberOfWindowTypes()
        {
            int vinylCount = 0, glassCount = 0, screenCount = 0;
            windowsOrdered.ForEach(delegate(Window windowChecked)
            {
                //if (windowChecked is CabanaWindow)
                    vinylCount++;
                //else if (windowChecked is FrenchWindow)
                    glassCount++;
                //else if (windowChecked is PatioWindow)
                    screenCount++;
            });
            //System.Diagnostics.Debug.Write("This is the cabana count: " + cabanaCount);
            return new Tuple<int, int, int>(vinylCount, glassCount, screenCount);
        }

        #region populate side bar
        /*
        /// <summary>
        /// This function is used to populate the side bar which displays
        /// information regarding how many windows of each type have been ordered,
        /// along with individual window information. This is done in an accordion
        /// style to hide unneeded data.
        /// </summary>
        /// <param name="windowTypeCounts"></param>
        private void populateSideBar(Tuple<int, int, int> windowTypeCounts)
        {

            int count;

            lblWindowPager.Controls.Add(new LiteralControl("<ul class='toggleOptions'>"));

            if (windowTypeCounts.Item1 > 0)
            {
                lblWindowPager.Controls.Add(new LiteralControl("<li id='cabanaWindows'>"));


                Label cabanaLabel = new Label();
                cabanaLabel.ID = "lblCabanaWindows";
                cabanaLabel.Text = "Cabana Windows Ordered " + windowTypeCounts.Item1;
                lblWindowPager.Controls.Add(cabanaLabel);

                count = 1;

                #region Creating Cabana window pager items
                foreach (Window aWindow in windowsOrdered)
                {
                    if (aWindow.WindowType == "Cabana")
                    {
                        lblWindowPager.Controls.Add(new LiteralControl("<div class='toggleContent'>"));

                        //CabanaWindow aCabana = (CabanaWindow)aWindow;

                        Label cabanaCurrentWindow = new Label();
                        cabanaCurrentWindow.ID = "lblCabanaCabana" + count;
                        cabanaCurrentWindow.Text = "Cabana Window " + count;
                        lblWindowPager.Controls.Add(cabanaCurrentWindow);

                        Label cabanaStyle = new Label();
                        cabanaStyle.ID = "lblCabanaStyle" + count;
                        //cabanaStyle.Text = "Style: " + aCabana.WindowStyle;
                        lblWindowPager.Controls.Add(cabanaStyle);

                        Label cabanaColour = new Label();
                        cabanaColour.ID = "lblCabanaColour" + count;
                        //cabanaColour.Text = "Colour: " + aCabana.Colour;
                        lblWindowPager.Controls.Add(cabanaColour);

                        Label cabanaKickplate = new Label();
                        cabanaKickplate.ID = "lblCabanaKickplate" + count;
                        //cabanaKickplate.Text = "Kickplate: " + String.Format("{0}", aCabana.Kickplate);
                        lblWindowPager.Controls.Add(cabanaKickplate);

                        Label cabanaHeight = new Label();
                        cabanaHeight.ID = "lblCabanaHeight" + count;
                        //cabanaHeight.Text = "Height: " + String.Format("{0}", aCabana.Height);
                        lblWindowPager.Controls.Add(cabanaHeight);

                        Label cabanaLength = new Label();
                        cabanaLength.ID = "lblCabanaLength" + count;
                        //cabanaLength.Text = "Width: " + String.Format("{0}", aCabana.Length);
                        lblWindowPager.Controls.Add(cabanaLength);

                        Label cabanaGlassTint = new Label();
                        cabanaGlassTint.ID = "lblCabanaGlassTint" + count;
                        //cabanaGlassTint.Text = "Glass Tint: " + aCabana.GlassTint;
                        lblWindowPager.Controls.Add(cabanaGlassTint);

                        //if (aCabana.WindowStyle == "Vertical 4 Track")
                        //{
                            Label cabanaNumVents = new Label();
                            cabanaNumVents.ID = "lblCabanaNumVents" + count;
                           // cabanaNumVents.Text = "No. Vents: " + String.Format("{0}", aCabana.WindowWindow.NumVents);
                            lblWindowPager.Controls.Add(cabanaNumVents);

                            Label cabanaVinylTint = new Label();
                            cabanaVinylTint.ID = "lblCabanaVinylTint" + count;
                            //cabanaVinylTint.Text = "Vinyl Tint: " + aCabana.VinylTint;
                            lblWindowPager.Controls.Add(cabanaVinylTint);
                        }
                        else
                        {
                            Label cabanaScreenType = new Label();
                            cabanaScreenType.ID = "lblCabanaScreenType" + count;
                            //cabanaScreenType.Text = "Screen Type: " + aCabana.ScreenType;
                            lblWindowPager.Controls.Add(cabanaScreenType);
                        }

                        Label cabanaHinge = new Label();
                        cabanaHinge.ID = "lblCabanaHinge" + count;
                        //cabanaHinge.Text = "Hinge: " + aCabana.Hinge;
                        lblWindowPager.Controls.Add(cabanaHinge);

                        Label cabanaSwing = new Label();
                        cabanaSwing.ID = "lblCabanaSwing" + count;
                        //cabanaSwing.Text = "Swing: " + aCabana.Swing;
                        lblWindowPager.Controls.Add(cabanaSwing);

                        Label cabanaHardwareType = new Label();
                        cabanaHardwareType.ID = "lblCabanaHardwareType" + count;
                        //cabanaHardwareType.Text = "Hardware: " + aCabana.HardwareType;
                        lblWindowPager.Controls.Add(cabanaHardwareType);


                        lblWindowPager.Controls.Add(new LiteralControl("</div>"));

                        count++;
                    }
                }
                #endregion

                lblWindowPager.Controls.Add(new LiteralControl("</li>"));
            }
        
            if (windowTypeCounts.Item2 > 0)
            {
                lblWindowPager.Controls.Add(new LiteralControl("<li id='frenchWindows'>"));

                Label frenchLabel = new Label();
                frenchLabel.ID = "lblFrenchWindows";
                frenchLabel.Text = "French Windows Ordered " + windowTypeCounts.Item2;
                lblWindowPager.Controls.Add(frenchLabel);

                count = 1;

                #region Creating French window pager items
                foreach (Window aWindow in windowsOrdered)
                {
                    if (aWindow.WindowType == "French")
                    {
                        lblWindowPager.Controls.Add(new LiteralControl("<div class='toggleContent'>"));

                        FrenchWindow aFrench = (FrenchWindow)aWindow;

                        Label frenchCurrentWindow = new Label();
                        frenchCurrentWindow.ID = "lblFrenchFrench" + count;
                        frenchCurrentWindow.Text = "French Window " + count;
                        lblWindowPager.Controls.Add(frenchCurrentWindow);

                        Label frenchStyle = new Label();
                        frenchStyle.ID = "lblFrenchStyle" + count;
                        frenchStyle.Text = "Style: " + aFrench.WindowStyle;
                        lblWindowPager.Controls.Add(frenchStyle);

                        Label frenchColour = new Label();
                        frenchColour.ID = "lblFrenchColour" + count;
                        frenchColour.Text = "Colour: " + aFrench.Colour;
                        lblWindowPager.Controls.Add(frenchColour);

                        Label frenchKickplate = new Label();
                        frenchKickplate.ID = "lblFrenchKickplate" + count;
                        frenchKickplate.Text = "Kickplate: " + String.Format("{0}", aFrench.Kickplate);
                        lblWindowPager.Controls.Add(frenchKickplate);

                        Label frenchHeight = new Label();
                        frenchHeight.ID = "lblFrenchHeight" + count;
                        frenchHeight.Text = "Height: " + String.Format("{0}", aFrench.Height);
                        lblWindowPager.Controls.Add(frenchHeight);

                        Label frenchLength = new Label();
                        frenchLength.ID = "lblFrenchLength" + count;
                        frenchLength.Text = "Width: " + String.Format("{0}", aFrench.Length);
                        lblWindowPager.Controls.Add(frenchLength);

                        Label frenchGlassTint = new Label();
                        frenchGlassTint.ID = "lblFrenchGlassTint" + count;
                        frenchGlassTint.Text = "Glass Tint: " + aFrench.GlassTint;
                        lblWindowPager.Controls.Add(frenchGlassTint);

                        if (aFrench.WindowStyle == "Vertical 4 Track")
                        {
                            Label frenchNumVents = new Label();
                            frenchNumVents.ID = "lblFrenchNumVents" + count;
                            frenchNumVents.Text = "No. Vents: " + String.Format("{0}", aFrench.WindowWindow.NumVents);
                            lblWindowPager.Controls.Add(frenchNumVents);

                            Label frenchVinylTint = new Label();
                            frenchVinylTint.ID = "lblFrenchVinylTint" + count;
                            frenchVinylTint.Text = "Vinyl Tint: " + aFrench.VinylTint;
                            lblWindowPager.Controls.Add(frenchVinylTint);
                        }
                        else
                        {
                            Label frenchScreenType = new Label();
                            frenchScreenType.ID = "lblFrenchScreenType" + count;
                            frenchScreenType.Text = "Screen Type: " + aFrench.ScreenType;
                            lblWindowPager.Controls.Add(frenchScreenType);
                        }

                        Label frenchOperatingWindow = new Label();
                        frenchOperatingWindow.ID = "lblFrenchOperatingWindow" + count;
                        frenchOperatingWindow.Text = "Operating Window: " + aFrench.OperatingWindow;
                        lblWindowPager.Controls.Add(frenchOperatingWindow);

                        Label frenchSwing = new Label();
                        frenchSwing.ID = "lblFrenchSwing" + count;
                        frenchSwing.Text = "Swing: " + aFrench.Swing;
                        lblWindowPager.Controls.Add(frenchSwing);

                        Label frenchHardwareType = new Label();
                        frenchHardwareType.ID = "lblFrenchHardwareType" + count;
                        frenchHardwareType.Text = "Hardware: " + aFrench.HardwareType;
                        lblWindowPager.Controls.Add(frenchHardwareType);

                        lblWindowPager.Controls.Add(new LiteralControl("</div>"));

                        count++;
                    }
                }
                #endregion

                lblWindowPager.Controls.Add(new LiteralControl("</li>"));
            }
          
            if (windowTypeCounts.Item3 > 0)
            {
                lblWindowPager.Controls.Add(new LiteralControl("<li id='patioWindows'>"));

                Label patioLabel = new Label();
                patioLabel.ID = "lblPatioWindows";
                patioLabel.Text = "Patio Windows Ordered " + windowTypeCounts.Item3;
                lblWindowPager.Controls.Add(patioLabel);

                count = 1;

                #region Creating Patio window pager items
                foreach (Window aWindow in windowsOrdered)
                {
                    if (aWindow.WindowType == "Patio")
                    {
                        lblWindowPager.Controls.Add(new LiteralControl("<div class='toggleContent'>"));

                        PatioWindow aPatio = (PatioWindow)aWindow;

                        Label patioCurrentWindow = new Label();
                        patioCurrentWindow.ID = "lblPatioPatio" + count;
                        patioCurrentWindow.Text = "Patio Window " + count;
                        lblWindowPager.Controls.Add(patioCurrentWindow);

                        Label patioStyle = new Label();
                        patioStyle.ID = "lblPatioStyle" + count;
                        patioStyle.Text = "Style: " + aPatio.WindowStyle;
                        lblWindowPager.Controls.Add(patioStyle);

                        Label patioColour = new Label();
                        patioColour.ID = "lblPatioColour" + count;
                        patioColour.Text = "Colour: " + aPatio.Colour;
                        lblWindowPager.Controls.Add(patioColour);

                        Label patioKickplate = new Label();
                        patioKickplate.ID = "lblPatioKickplate" + count;
                        patioKickplate.Text = "Kickplate: " + String.Format("{0}", aPatio.Kickplate);
                        lblWindowPager.Controls.Add(patioKickplate);

                        Label patioHeight = new Label();
                        patioHeight.ID = "lblPatioHeight" + count;
                        patioHeight.Text = "Height: " + String.Format("{0}", aPatio.Height);
                        lblWindowPager.Controls.Add(patioHeight);

                        Label patioLength = new Label();
                        patioLength.ID = "lblPatioLength" + count;
                        patioLength.Text = "Width: " + String.Format("{0}", aPatio.Length);
                        lblWindowPager.Controls.Add(patioLength);

                        Label patioGlassTint = new Label();
                        patioGlassTint.ID = "lblPatioGlassTint" + count;
                        patioGlassTint.Text = "Glass Tint: " + aPatio.GlassTint;
                        lblWindowPager.Controls.Add(patioGlassTint);

                        Label patioScreenType = new Label();
                        patioScreenType.ID = "lblPatioScreenType" + count;
                        patioScreenType.Text = "Screen Type: " + aPatio.ScreenType;
                        lblWindowPager.Controls.Add(patioScreenType);

                        Label patioOperatingWindow = new Label();
                        patioOperatingWindow.ID = "lblPatioOperatingWindow" + count;
                        patioOperatingWindow.Text = "Operating Window: " + aPatio.OperatingWindow;
                        lblWindowPager.Controls.Add(patioOperatingWindow);

                        lblWindowPager.Controls.Add(new LiteralControl("</div>"));

                        count++;
                    }
                }
                #endregion
        
                lblWindowPager.Controls.Add(new LiteralControl("</li>"));
            }

            lblWindowPager.Controls.Add(new LiteralControl("</ul>"));

        }
*/
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            loadDetails("Window");
        }
    }
}
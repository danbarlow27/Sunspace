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


        //protected ListItem lst116 = new ListItem("1/16", ".1667");
        //protected ListItem lst216 = new ListItem("1/8", ".125");
        //protected ListItem lst316 = new ListItem("3/16", ".1875");//
        //protected ListItem lst416 = new ListItem("1/4", ".25");
        //protected ListItem lst516 = new ListItem("5/16", ".3125");
        //protected ListItem lst616 = new ListItem("3/8", ".375");
        //protected ListItem lst716 = new ListItem("7/16", ".4375");
        //protected ListItem lst816 = new ListItem("1/2", ".5");
        //protected ListItem lst916 = new ListItem("9/16", ".5625");
        //protected ListItem lst1016 = new ListItem("5/8", ".625");//
        //protected ListItem lst1116 = new ListItem("11/16", ".6875");
        //protected ListItem lst1216 = new ListItem("3/4", ".75");
        //protected ListItem lst1316 = new ListItem("13/16", ".8125");
        //protected ListItem lst1416 = new ListItem("7/8", ".875");
        //protected ListItem lst1516 = new ListItem("15/16", ".9375");
        
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

        /// <summary>
        /// function to populate the door/window page on page load.
        /// </summary>
        /// <param name="obj"></param>
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
                //typeRadio.Attributes.Add("onclick", "typeRowsDisplayed('" + title + "')"); //On click event to display the proper fields/rows


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
                //tblWindowDetails.CssClass = "tblTextFields";                  //Adding CssClass to the table for styling
                //tblWindowDetails.Attributes.Add("style", "display: block");
                tblWindowDetails.Style.Add("display", "table");

                //Creating cells and controls for rows

                #region Title (including DLO/TipToTip and Deductions)

                TableRow windowTitleRow = new TableRow();
                windowTitleRow.ID = "rowWindowTitle" + title;
                //windowTitleRow.Attributes.Add("style", "display:none;");
                TableCell windowTitleLBLCell = new TableCell();
                TableCell windowDLOLBLCell = new TableCell();
                windowDLOLBLCell.HorizontalAlign = HorizontalAlign.Center;
                TableCell windowDeductionsLBLCell = new TableCell();
                windowDeductionsLBLCell.HorizontalAlign = HorizontalAlign.Center;

                Label windowTitleLBL = new Label();
                windowTitleLBL.ID = "lblWindowTitle" + title;
                windowTitleLBL.Text = "Select Window Details";
                windowTitleLBL.Attributes.Add("style", "font-weight:bold;");

                Label windowDLOLBL = new Label();
                windowDLOLBL.ID = "lblWindowDLO" + title;
                windowDLOLBL.Text = "DLO";
                windowDLOLBL.ForeColor = System.Drawing.Color.Blue;
                windowDLOLBL.Attributes.Add("onclick", "this.innerText = (this.innerText === 'DLO') ? 'Tip to Tip' : 'DLO'; dloClicked(this.innerText);");
                windowDLOLBL.Attributes.Add("onmouseover", "this.style.cursor='pointer'");
                windowDLOLBL.Attributes.Add("onmouseout", "this.style.cursor='auto'");

                Label windowDeductionsLBL = new Label();
                windowDeductionsLBL.ID = "lblWindowDeductions" + title;
                windowDeductionsLBL.Text = "No Deductions";
                windowDeductionsLBL.ForeColor = System.Drawing.Color.Blue;
                windowDeductionsLBL.Attributes.Add("onclick", "this.innerText = (this.innerText === 'No Deductions') ? 'Deduct 1/8\"' : (this.innerText === 'Deduct 1/8\"') ? 'Deduct 1/4\"' : (this.innerText === 'Deduct 1/4\"') ? 'Deduct 3/8\"' : (this.innerText === 'Deduct 3/8\"') ? 'Deduct 1/2\"' : 'No Deductions'; deductionsClicked(this.innerText);");
                windowDeductionsLBL.Attributes.Add("onmouseover", "this.style.cursor='pointer'");
                windowDLOLBL.Attributes.Add("onmouseout", "this.style.cursor='auto'");

                windowTitleLBLCell.Controls.Add(windowTitleLBL);
                windowDLOLBLCell.Controls.Add(windowDLOLBL);
                windowDeductionsLBLCell.Controls.Add(windowDeductionsLBL);

                tblWindowDetails.Rows.Add(windowTitleRow);

                windowTitleRow.Cells.Add(windowTitleLBLCell);
                windowTitleRow.Cells.Add(windowDLOLBLCell);
                windowTitleRow.Cells.Add(windowDeductionsLBLCell);
                #endregion

                #region Window Style

                TableRow windowStyleRow = new TableRow();
                windowStyleRow.ID = "rowWindowStyle" + title;
                //windowStyleRow.Attributes.Add("style", "display:none;");
                TableCell windowStyleLBLCell = new TableCell();
                TableCell windowStyleDDLCell = new TableCell();

                Label windowStyleLBL = new Label();
                windowStyleLBL.ID = "lblWindowStyle" + title;
                windowStyleLBL.Text = "Style:";

                DropDownList windowStyleDDL = new DropDownList();
                windowStyleDDL.ID = "ddlWindowStyle" + title;
                //windowStyleDDL.Attributes.Add("onchange", "windowStyleChanged();");

                if (title == "Vinyl")
                {
                    for (int j = 0; j < Constants.VINYL_WINDOW_TYPES_FOR_WINDOWS_ONLY_ORDER.Count(); j++)
                    {
                        windowStyleDDL.Items.Add(new ListItem(Constants.VINYL_WINDOW_TYPES_FOR_WINDOWS_ONLY_ORDER[j], Constants.VINYL_WINDOW_TYPES_FOR_WINDOWS_ONLY_ORDER[j]));
                        windowStyleDDL.Attributes.Add("onchange", "windowVinylStyleChanged(document.getElementById('MainContent_ddlWindowStyleVinyl').options[document.getElementById('MainContent_ddlWindowStyleVinyl').selectedIndex].value);");
                    }
                }
                else if (title == "Glass")
                {
                    for (int j = 0; j < Constants.GLASS_WINDOW_TYPES_FOR_WINDOWS_ONLY_ORDER.Count(); j++)
                    {
                        windowStyleDDL.Items.Add(new ListItem(Constants.GLASS_WINDOW_TYPES_FOR_WINDOWS_ONLY_ORDER[j], Constants.GLASS_WINDOW_TYPES_FOR_WINDOWS_ONLY_ORDER[j]));
                        windowStyleDDL.Attributes.Add("onchange", "windowGlassStyleChanged(document.getElementById('MainContent_ddlWindowStyleGlass').options[document.getElementById('MainContent_ddlWindowStyleGlass').selectedIndex].value);");
                    }
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

                #region Spreader bar Checkbox

                if (title == "Vinyl")
                {
                    TableCell windowSpreaderBarCHKCell = new TableCell();
                    windowSpreaderBarCHKCell.Attributes.Add("style", "display:none;");
                    windowSpreaderBarCHKCell.ID = "cellWindowSpreaderBar" + title;

                    Label windowSpreaderBarLBLChk = new Label();
                    windowSpreaderBarLBLChk.ID = "lblWindowSpreaderBar" + title;

                    Label windowSpreaderBarLBL = new Label();
                    windowSpreaderBarLBL.ID = "lblWindowSpreaderBarRad" + title;
                    windowSpreaderBarLBL.Text = " Spreader Bar:";

                    CheckBox windowSpreaderBarCHK = new CheckBox();
                    windowSpreaderBarCHK.ID = "chkWindowSpreaderBar" + title;
                    windowSpreaderBarCHK.Attributes.Add("value", "SpreaderBar");
                    windowSpreaderBarCHK.Attributes.Add("onclick", "spreaderBar();");

                    windowSpreaderBarLBLChk.AssociatedControlID = "chkWindowSpreaderBar" + title;
                    windowSpreaderBarLBL.AssociatedControlID = "chkWindowSpreaderBar" + title;

                    windowSpreaderBarCHKCell.Controls.Add(windowSpreaderBarCHK);
                    windowSpreaderBarCHKCell.Controls.Add(windowSpreaderBarLBLChk);
                    windowSpreaderBarCHKCell.Controls.Add(windowSpreaderBarLBL);
                    windowSpreaderBarCHKCell.Attributes.Add("style", "display:inherit;");

                    windowStyleRow.Cells.Add(windowSpreaderBarCHKCell);
                }

                #endregion

                #endregion

                #region Window Height

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
                windowHeightTXT.Attributes.Add("onblur", "recalculate();");

                DropDownList inchHeight = new DropDownList();
                inchHeight.ID = "ddlWindowHeight"   + title;
                inchHeight.Attributes.Add("onchange", "recalculate();");
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

                #region "As-if" Height 

                if (title == "Vinyl")
                {
                    TableRow windowAsIfHeightRow = new TableRow();
                    windowAsIfHeightRow.ID = "rowWindowAsIfHeight" + title;
                    windowAsIfHeightRow.Attributes.Add("style", "display:none;");
                    TableCell windowAsIfHeightLBLCell = new TableCell();
                    TableCell windowAsIfHeightTXTCell = new TableCell();
                    TableCell windowAsIfHeightDDLCell = new TableCell();

                    Label windowAsIfHeightLBL = new Label();
                    windowAsIfHeightLBL.ID = "lblWindowAsIfHeight" + title;
                    windowAsIfHeightLBL.Text = "Build As If:";

                    TextBox windowAsIfHeightTXT = new TextBox();
                    windowAsIfHeightTXT.ID = "txtWindowAsIfHeight" + title;
                    windowAsIfHeightTXT.CssClass = "txtField txtWindowInput";
                    windowAsIfHeightTXT.Attributes.Add("maxlength", "3");
                    windowAsIfHeightTXT.Attributes.Add("onkeydown", "return (event.keyCode!=13);");
                    windowAsIfHeightTXT.Attributes.Add("onblur", "recalculate();");

                    DropDownList inchAsIfHeight = new DropDownList();
                    inchAsIfHeight.ID = "ddlWindowAsIfHeight" + title;
                    inchAsIfHeight.Attributes.Add("onchange", "recalculate();");
                    inchAsIfHeight.Items.Add(lst0);
                    inchAsIfHeight.Items.Add(lst18);
                    inchAsIfHeight.Items.Add(lst14);
                    inchAsIfHeight.Items.Add(lst38);
                    inchAsIfHeight.Items.Add(lst12);
                    inchAsIfHeight.Items.Add(lst58);
                    inchAsIfHeight.Items.Add(lst34);
                    inchAsIfHeight.Items.Add(lst78);

                    windowAsIfHeightLBL.AssociatedControlID = "txtWindowAsIfHeight" + title;


                    windowAsIfHeightLBLCell.Controls.Add(windowAsIfHeightLBL);
                    windowAsIfHeightTXTCell.Controls.Add(windowAsIfHeightTXT);
                    windowAsIfHeightDDLCell.Controls.Add(inchAsIfHeight);

                    tblWindowDetails.Rows.Add(windowAsIfHeightRow);

                    windowAsIfHeightRow.Cells.Add(windowAsIfHeightLBLCell);
                    windowAsIfHeightRow.Cells.Add(windowAsIfHeightTXTCell);
                    windowAsIfHeightRow.Cells.Add(windowAsIfHeightDDLCell);
                }
                #endregion

                #region Left Height 

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

                #region Right Height 

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

                #region Window Width 

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
                windowWidthTXT.Attributes.Add("onblur", "recalculate();");

                DropDownList inchWidth = new DropDownList();
                inchWidth.ID = "ddlWindowWidth" + title;
                inchWidth.Attributes.Add("onchange", "recalculate();");
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

                #region V4T Number Of Vents

                if (title == "Vinyl")
                {
                    TableRow windowV4TNumberOfVentsRow = new TableRow();
                    windowV4TNumberOfVentsRow.ID = "rowWindowV4TNumberOfVents" + title;
                    //windowV4TNumberOfVentsRow.Attributes.Add("style", "display:none;");
                    TableCell windowV4TNumberOfVentsLBLCell = new TableCell();
                    TableCell windowV4TNumberOfVentsDDLCell = new TableCell();

                    Label windowV4TNumberOfVentsLBL = new Label();
                    windowV4TNumberOfVentsLBL.ID = "lblV4TNumberOfVents" + title;
                    windowV4TNumberOfVentsLBL.Text = "Number Of Vents:";

                    DropDownList windowV4TNumberOfVentsDDL = new DropDownList();
                    windowV4TNumberOfVentsDDL.ID = "ddlWindowV4TNumberOfVents" + title;
                    windowV4TNumberOfVentsDDL.Attributes.Add("onchange", "windowStyle('" + title + "');");
                    ListItem V3 = new ListItem("3", "3");
                    ListItem V4 = new ListItem("4", "4");
                    ListItem V6S = new ListItem("6 Stereo", "6");
                    ListItem V8S = new ListItem("8 Stereo", "8");
                    ListItem V9S = new ListItem("9 Stereo", "9");
                    ListItem V12S = new ListItem("12 Stereo", "12");

                    windowV4TNumberOfVentsDDL.Items.Add(V3);
                    windowV4TNumberOfVentsDDL.Items.Add(V4);
                    windowV4TNumberOfVentsDDL.Items.Add(V6S);
                    windowV4TNumberOfVentsDDL.Items.Add(V8S);
                    windowV4TNumberOfVentsDDL.Items.Add(V9S);
                    windowV4TNumberOfVentsDDL.Items.Add(V12S);

                    windowV4TNumberOfVentsLBL.AssociatedControlID = "ddlWindowV4TNumberOfVents" + title;

                    windowV4TNumberOfVentsLBLCell.Controls.Add(windowV4TNumberOfVentsLBL);
                    windowV4TNumberOfVentsDDLCell.Controls.Add(windowV4TNumberOfVentsDDL);

                    windowV4TNumberOfVentsRow.Cells.Add(windowV4TNumberOfVentsLBLCell);
                    windowV4TNumberOfVentsRow.Cells.Add(windowV4TNumberOfVentsDDLCell);


                    #region Uneven Vents Checkbox

                    TableCell windowUnevenVentsCHKCell = new TableCell();
                    //windowUnevenVentsCHKCell.Attributes.Add("style", "display:none;");
                    windowUnevenVentsCHKCell.ID = "cellWindowUnevenVents" + title;

                    Label windowUnevenVentsLBLChk = new Label();
                    windowUnevenVentsLBLChk.ID = "lblWindowUnevenVents" + title;

                    Label windowUnevenVentsLBL = new Label();
                    windowUnevenVentsLBL.ID = "lblWindowUnevenVentsRad" + title;
                    windowUnevenVentsLBL.Text = " Uneven Vents";

                    CheckBox windowUnevenVentsCHK = new CheckBox();
                    windowUnevenVentsCHK.ID = "chkWindowUnevenVents" + title;
                    windowUnevenVentsCHK.Attributes.Add("value", "UnevenVents");
                    windowUnevenVentsCHK.Attributes.Add("onclick", "unevenVentsChecked(this.checked);");

                    windowUnevenVentsLBLChk.AssociatedControlID = "chkWindowUnevenVents" + title;
                    windowUnevenVentsLBL.AssociatedControlID = "chkWindowUnevenVents" + title;

                    windowUnevenVentsCHKCell.Controls.Add(windowUnevenVentsCHK);
                    windowUnevenVentsCHKCell.Controls.Add(windowUnevenVentsLBLChk);
                    windowUnevenVentsCHKCell.Controls.Add(windowUnevenVentsLBL);

                    windowV4TNumberOfVentsRow.Cells.Add(windowUnevenVentsCHKCell);


                    tblWindowDetails.Rows.Add(windowV4TNumberOfVentsRow);

                    #endregion

                }
                #endregion
                
                #region H4T number of vents

                if (title == "Vinyl")
                {
                    ListItem V3 = new ListItem("3", "3");
                    ListItem V4 = new ListItem("4", "4");

                    TableRow windowH4TNumberOfVentsRow = new TableRow();
                    windowH4TNumberOfVentsRow.ID = "rowWindowH4TNumberOfVents" + title;
                    windowH4TNumberOfVentsRow.Attributes.Add("style", "display:none;");
                    TableCell windowH4TNumberOfVentsLBLCell = new TableCell();
                    TableCell windowH4TNumberOfVentsDDLCell = new TableCell();

                    Label windowH4TNumberOfVentsLBL = new Label();
                    windowH4TNumberOfVentsLBL.ID = "lblH4TNumberOfVents" + title;
                    windowH4TNumberOfVentsLBL.Text = "Number Of Vents:";

                    DropDownList windowH4TNumberOfVentsDDL = new DropDownList();
                    windowH4TNumberOfVentsDDL.ID = "ddlWindowH4TNumberOfVents" + title;
                    windowH4TNumberOfVentsDDL.Attributes.Add("onchange", "windowStyle('" + title + "');");

                    windowH4TNumberOfVentsDDL.Items.Add(V3);
                    windowH4TNumberOfVentsDDL.Items.Add(V4);

                    windowH4TNumberOfVentsLBL.AssociatedControlID = "ddlWindowH4TNumberOfVents" + title;

                    windowH4TNumberOfVentsLBLCell.Controls.Add(windowH4TNumberOfVentsLBL);
                    windowH4TNumberOfVentsDDLCell.Controls.Add(windowH4TNumberOfVentsDDL);

                    windowH4TNumberOfVentsRow.Cells.Add(windowH4TNumberOfVentsLBLCell);
                    windowH4TNumberOfVentsRow.Cells.Add(windowH4TNumberOfVentsDDLCell);

                    tblWindowDetails.Rows.Add(windowH4TNumberOfVentsRow);
                }

                #endregion

                #region Uneven Vents Top Bottom Both Rads

                if (title == "Vinyl")
                {
                    TableRow windowTopBottomBothRadRow = new TableRow();
                    windowTopBottomBothRadRow.ID = "rowWindowTopBottomBothRad" + title;
                    windowTopBottomBothRadRow.Attributes.Add("style", "display:none;");

                    #region Top

                    TableCell windowTopRadCell = new TableCell();

                    Label windowTopRadLBLRad = new Label();
                    windowTopRadLBLRad.ID = "lblWindowTopRad" + title;

                    Label windowTopRadLBL = new Label();
                    windowTopRadLBL.ID = "lblWindowTopRadRad" + title;
                    windowTopRadLBL.Text = "Top";

                    RadioButton windowTopRadRAD = new RadioButton();
                    windowTopRadRAD.ID = "radWindowTopRad" + title;
                    windowTopRadRAD.Attributes.Add("value", "top");
                    windowTopRadRAD.GroupName = "Uneven" + title;
                    windowTopRadRAD.Attributes.Add("onclick", "topOrBottomUnevenClicked();");

                    windowTopRadLBLRad.AssociatedControlID = "radWindowTopRad" + title;
                    windowTopRadLBL.AssociatedControlID = "radWindowTopRad" + title;

                    windowTopRadCell.Controls.Add(windowTopRadRAD);
                    windowTopRadCell.Controls.Add(windowTopRadLBLRad);
                    windowTopRadCell.Controls.Add(windowTopRadLBL);

                    #endregion

                    #region Bottom

                    TableCell windowBottomRadCell = new TableCell();

                    Label windowBottomRadLBLRad = new Label();
                    windowBottomRadLBLRad.ID = "lblWindowBottomRad" + title;

                    Label windowBottomRadLBL = new Label();
                    windowBottomRadLBL.ID = "lblWindowBottomRadRad" + title;
                    windowBottomRadLBL.Text = "Bottom";

                    RadioButton windowBottomRadRAD = new RadioButton();
                    windowBottomRadRAD.ID = "radWindowBottomRad" + title;
                    windowBottomRadRAD.Attributes.Add("value", "bottom");
                    windowBottomRadRAD.GroupName = "Uneven" + title;
                    windowBottomRadRAD.Attributes.Add("onclick", "topOrBottomUnevenClicked();");
                    windowBottomRadRAD.Checked = true;

                    windowBottomRadLBLRad.AssociatedControlID = "radWindowBottomRad" + title;
                    windowBottomRadLBL.AssociatedControlID = "radWindowBottomRad" + title;

                    windowBottomRadCell.Controls.Add(windowBottomRadRAD);
                    windowBottomRadCell.Controls.Add(windowBottomRadLBLRad);
                    windowBottomRadCell.Controls.Add(windowBottomRadLBL);

                    #endregion

                    #region Both

                    TableCell windowBothRadCell = new TableCell();

                    Label windowBothRadLBLRad = new Label();
                    windowBothRadLBLRad.ID = "lblWindowBothRad" + title;

                    Label windowBothRadLBL = new Label();
                    windowBothRadLBL.ID = "lblWindowBothRadRad" + title;
                    windowBothRadLBL.Text = "Both";

                    RadioButton windowBothRadRAD = new RadioButton();
                    windowBothRadRAD.ID = "radWindowBothRad" + title;
                    windowBothRadRAD.Attributes.Add("value", "both");
                    windowBothRadRAD.GroupName = "Uneven" + title;
                    windowBothRadRAD.Attributes.Add("onclick", "bothUnevenClicked()");

                    windowBothRadLBLRad.AssociatedControlID = "radWindowBothRad" + title;
                    windowBothRadLBL.AssociatedControlID = "radWindowBothRad" + title;

                    windowBothRadCell.Controls.Add(windowBothRadRAD);
                    windowBothRadCell.Controls.Add(windowBothRadLBLRad);
                    windowBothRadCell.Controls.Add(windowBothRadLBL);

                    #endregion

                    tblWindowDetails.Rows.Add(windowTopBottomBothRadRow);

                    windowTopBottomBothRadRow.Cells.Add(windowTopRadCell);
                    windowTopBottomBothRadRow.Cells.Add(windowBottomRadCell);
                    windowTopBottomBothRadRow.Cells.Add(windowBothRadCell);
                }

                #endregion

                #region Uneven Vents Textboxes

                if (title == "Vinyl")
                {
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

                    #region Top

                    TableRow windowUnevenVentsRowTop = new TableRow();
                    windowUnevenVentsRowTop.ID = "rowWindowUnevenVentsTop" + title;
                    windowUnevenVentsRowTop.Attributes.Add("style", "display:none;");

                    TableCell windowTopVentLBLCell = new TableCell();
                    TableCell windowTopVentTXTCell = new TableCell();
                    //TableCell windowTopVentDDLCell = new TableCell();

                    Label windowTopVentLBL = new Label();
                    windowTopVentLBL.ID = "lblWindowTopVentHeight" + title;
                    windowTopVentLBL.Text = "Top Vent Height:";

                    TextBox windowTopVentTXT = new TextBox();
                    windowTopVentTXT.ID = "txtWindowTopVentHeight" + title;
                    windowTopVentTXT.CssClass = "txtField txtWindowInput";
                    windowTopVentTXT.Attributes.Add("maxlength", "3");
                    windowTopVentTXT.Attributes.Add("onkeydown", "return (event.keyCode!=13);");
                    windowTopVentTXT.Attributes.Add("onblur", "recalculate();");


                    //DropDownList inchTopVentDDL = new DropDownList();
                    //inchTopVentDDL.ID = "ddlWindowTopVentHeight" + title;
                    //inchTopVentDDL.Items.Add(lst0);
                    //inchTopVentDDL.Items.Add(lst116);
                    //inchTopVentDDL.Items.Add(lst216);
                    //inchTopVentDDL.Items.Add(lst316);
                    //inchTopVentDDL.Items.Add(lst416);
                    //inchTopVentDDL.Items.Add(lst516);
                    //inchTopVentDDL.Items.Add(lst616);
                    //inchTopVentDDL.Items.Add(lst716);
                    //inchTopVentDDL.Items.Add(lst816);
                    //inchTopVentDDL.Items.Add(lst916);
                    //inchTopVentDDL.Items.Add(lst1016);
                    //inchTopVentDDL.Items.Add(lst1116);
                    //inchTopVentDDL.Items.Add(lst1216);
                    //inchTopVentDDL.Items.Add(lst1316);
                    //inchTopVentDDL.Items.Add(lst1416);
                    //inchTopVentDDL.Items.Add(lst1516);


                    windowTopVentLBL.AssociatedControlID = "txtWindowTopVentHeight" + title;

                    windowTopVentLBLCell.Controls.Add(windowTopVentLBL);
                    windowTopVentTXTCell.Controls.Add(windowTopVentTXT);
                    //windowTopVentDDLCell.Controls.Add(inchTopVentDDL);

                    windowUnevenVentsRowTop.Cells.Add(windowTopVentLBLCell);
                    windowUnevenVentsRowTop.Cells.Add(windowTopVentTXTCell);
                    //windowUnevenVentsRowTop.Cells.Add(windowTopVentDDLCell);

                    tblWindowDetails.Rows.Add(windowUnevenVentsRowTop);


                    #endregion

                    #region Bottom

                    TableRow windowUnevenVentsRowBottom = new TableRow();
                    windowUnevenVentsRowBottom.ID = "rowWindowUnevenVentsBottom" + title;
                    windowUnevenVentsRowBottom.Attributes.Add("style", "display:none;");

                    TableCell windowBottomVentLBLCell = new TableCell();
                    TableCell windowBottomVentTXTCell = new TableCell();
                    //TableCell windowBottomVentDDLCell = new TableCell();

                    Label windowBottomVentLBL = new Label();
                    windowBottomVentLBL.ID = "lblWindowBottomVentHeight" + title;
                    windowBottomVentLBL.Text = "Bottom Vent Height:";

                    TextBox windowBottomVentTXT = new TextBox();
                    windowBottomVentTXT.ID = "txtWindowBottomVentHeight" + title;
                    windowBottomVentTXT.CssClass = "txtField txtWindowInput";
                    windowBottomVentTXT.Attributes.Add("maxlength", "3");
                    windowBottomVentTXT.Attributes.Add("onkeydown", "return (event.keyCode!=13);");
                    windowBottomVentTXT.Attributes.Add("onblur", "recalculate();");

                    //DropDownList inchBottomVentDDL = new DropDownList();
                    //inchBottomVentDDL.ID = "ddlWindowBottomVentHeight" + title;
                    //inchBottomVentDDL.Items.Add(lst0);
                    //inchBottomVentDDL.Items.Add(lst116);
                    //inchBottomVentDDL.Items.Add(lst216);
                    //inchBottomVentDDL.Items.Add(lst316);
                    //inchBottomVentDDL.Items.Add(lst416);
                    //inchBottomVentDDL.Items.Add(lst516);
                    //inchBottomVentDDL.Items.Add(lst616);
                    //inchBottomVentDDL.Items.Add(lst716);
                    //inchBottomVentDDL.Items.Add(lst816);
                    //inchBottomVentDDL.Items.Add(lst916);
                    //inchBottomVentDDL.Items.Add(lst1016);
                    //inchBottomVentDDL.Items.Add(lst1116);
                    //inchBottomVentDDL.Items.Add(lst1216);
                    //inchBottomVentDDL.Items.Add(lst1316);
                    //inchBottomVentDDL.Items.Add(lst1416);
                    //inchBottomVentDDL.Items.Add(lst1516);

                    windowBottomVentLBL.AssociatedControlID = "txtWindowBottomVentHeight" + title;

                    windowBottomVentLBLCell.Controls.Add(windowBottomVentLBL);
                    windowBottomVentTXTCell.Controls.Add(windowBottomVentTXT);
                    //windowBottomVentDDLCell.Controls.Add(inchBottomVentDDL);

                    windowUnevenVentsRowBottom.Cells.Add(windowBottomVentLBLCell);
                    windowUnevenVentsRowBottom.Cells.Add(windowBottomVentTXTCell);
                    //windowUnevenVentsRowBottom.Cells.Add(windowBottomVentDDLCell);

                    tblWindowDetails.Rows.Add(windowUnevenVentsRowBottom);

                    #endregion
                }
                #endregion

                #region Tint Options

                if (title == "Vinyl" || title == "Glass")
                {
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
                    //windowTintDDL.Attributes.Add("onchange", "windowStyle('" + title + "');");

                    if (title == "Vinyl")
                    {
                        for (int j = 0; j < Constants.DOOR_V4T_VINYL_OPTIONS.Count(); j++)
                        {
                            windowTintDDL.Items.Add(new ListItem(Constants.DOOR_V4T_VINYL_OPTIONS[j], Constants.DOOR_V4T_VINYL_OPTIONS[j]));
                            windowTintDDL.Attributes.Add("onchange", "tintOptionsChanged();");
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
                }

                #endregion

                #region No Mixed Vinyl Tint Options

                if (title == "Vinyl")
                {
                    TableRow windowTintNoMixedRow = new TableRow();
                    windowTintNoMixedRow.ID = "rowWindowTintNoMixed" + title;
                    //windowTintNoMixedRow.Attributes.Add("style", "display:none;");
                    TableCell windowTintNoMixedLBLCell = new TableCell();
                    TableCell windowTintNoMixedDDLCell = new TableCell();

                    Label windowTintNoMixedLBL = new Label();
                    windowTintNoMixedLBL.ID = "lblWindowTintNoMixed" + title;
                    windowTintNoMixedLBL.Text = title + "Tint:";

                    DropDownList windowTintNoMixedDDL = new DropDownList();
                    windowTintNoMixedDDL.ID = "ddlWindowTintNoMixed" + title;
                    windowTintNoMixedDDL.Attributes.Add("onchange", "windowStyle('" + title + "');");

                    for (int j = 0; j < Constants.DOOR_V4T_VINYL_OPTIONS.Count() - 1; j++)
                    {
                        windowTintNoMixedDDL.Items.Add(new ListItem(Constants.DOOR_V4T_VINYL_OPTIONS[j], Constants.DOOR_V4T_VINYL_OPTIONS[j]));
                    }

                    //windowTintNoMixedDDL.Attributes.Add("onchange", "checkQuestion3()");
                    windowTintNoMixedLBL.AssociatedControlID = "ddlWindowTintNoMixed" + title;

                    windowTintNoMixedLBLCell.Controls.Add(windowTintNoMixedLBL);
                    windowTintNoMixedDDLCell.Controls.Add(windowTintNoMixedDDL);

                    tblWindowDetails.Rows.Add(windowTintNoMixedRow);

                    windowTintNoMixedRow.Cells.Add(windowTintNoMixedLBLCell);
                    windowTintNoMixedRow.Cells.Add(windowTintNoMixedDDLCell);
                }
                #endregion

                #region Frame Colour

                TableRow colourOfWindowRow = new TableRow();
                colourOfWindowRow.ID = "rowWindowColour" + title;
                //colourOfWindowRow.Attributes.Add("style", "display:none;");
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

                #region Inside Mount
                if (title == "Vinyl")
                {
                    TableRow windowInsideMountRow = new TableRow();
                    windowInsideMountRow.ID = "rowWindowInsideMount" + title;
                    //windowInsideMountRow.Attributes.Add("style", "display:none;");
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
                    windowInsideMountRAD.Attributes.Add("onclick", "document.getElementById('MainContent_rowWindowScreenOptionsVinyl').style.display = 'none';");

                    windowInsideMountLBLRad.AssociatedControlID = "radWindowInsideMount" + title;
                    windowInsideMountLBL.AssociatedControlID = "radWindowInsideMount" + title;


                    windowInsideMountLBLCell.Controls.Add(windowMountLBLMain);

                    windowInsideMountRADCell.Controls.Add(windowInsideMountRAD);
                    windowInsideMountRADCell.Controls.Add(windowInsideMountLBLRad);
                    windowInsideMountRADCell.Controls.Add(windowInsideMountLBL);

                    tblWindowDetails.Rows.Add(windowInsideMountRow);

                    windowInsideMountRow.Cells.Add(windowInsideMountLBLCell);
                    windowInsideMountRow.Cells.Add(windowInsideMountRADCell);
                }
                #endregion

                #region Outside Mount
                if (title == "Vinyl")
                {
                    TableRow windowOutsideMountRow = new TableRow();
                    windowOutsideMountRow.ID = "rowWindowOutsideMount" + title;
                    //windowOutsideMountRow.Attributes.Add("style", "display:none;");
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
                    windowOutsideMountRAD.Attributes.Add("onclick", "document.getElementById('MainContent_rowWindowScreenOptionsVinyl').style.display = 'inherit';;");

                    windowOutsideMountLBLRad.AssociatedControlID = "radWindowOutsideMount" + title;
                    windowOutsideMountLBL.AssociatedControlID = "radWindowOutsideMount" + title;


                    windowOutsideMountRADCell.Controls.Add(windowOutsideMountRAD);
                    windowOutsideMountRADCell.Controls.Add(windowOutsideMountLBLRad);
                    windowOutsideMountRADCell.Controls.Add(windowOutsideMountLBL);

                    tblWindowDetails.Rows.Add(windowOutsideMountRow);

                    windowOutsideMountRow.Cells.Add(windowOutsideMountLBLCell);
                    windowOutsideMountRow.Cells.Add(windowOutsideMountRADCell);
                }
                #endregion

                #region Screen Options

                TableRow windowScreenOptionsRow = new TableRow();
                windowScreenOptionsRow.ID = "rowWindowScreenOptions" + title;
                //windowScreenOptionsRow.Attributes.Add("style", "display:none;");
                TableCell windowScreenOptionsLBLCell = new TableCell();
                TableCell windowScreenOptionsDDLCell = new TableCell();

                Label windowScreenOptionsLBL = new Label();
                windowScreenOptionsLBL.ID = "lblWindowScreenOptions" + title;
                windowScreenOptionsLBL.Text = "Screen:";

                DropDownList windowScreenOptionsDDL = new DropDownList();
                windowScreenOptionsDDL.ID = "ddlWindowScreenOptions" + title;

                ListItem standard = new ListItem("18 x 16 Mesh (Standard)", "18 x 16 Mesh (Standard)");
                ListItem noSeeUms = new ListItem("No-See-Ums 20 x 20 Mesh", "No-See-Ums 20 x 20 Mesh");
                ListItem betterVueInsect = new ListItem("Better Vue Insect Screen", "Better Vue Insect Screen");
                ListItem solarInsect = new ListItem("Solar Insect Screening", "Solar Insect Screening");
                ListItem tuff = new ListItem("Tuff Screen", "Tuff Screen");
                ListItem noScreen = new ListItem("No Screen", "No Screen");

                windowScreenOptionsDDL.Items.Add(standard);
                windowScreenOptionsDDL.Items.Add(noSeeUms);
                windowScreenOptionsDDL.Items.Add(betterVueInsect);
                windowScreenOptionsDDL.Items.Add(solarInsect);
                windowScreenOptionsDDL.Items.Add(tuff);
                windowScreenOptionsDDL.Items.Add(noScreen);

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

                #region Add This Window Button 

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
                    System.Diagnostics.Debug.Write("This");
                    if ((List<Window>)Session["windowsOrdered"] != null)
                    {                        
                        windowsOrdered = (List<Window>)Session["windowsOrdered"];                        
                    }

                    if (Request.Form["ctl00$MainContent$windowTypeRadios"] == "radTypeVinyl")
                    {
                        Window aWindow = getVinylWindowFromForm();
                        windowsOrdered.Add(aWindow);
                    }
                    else if (Request.Form["ctl00$MainContent$windowTypeRadios"] == "radTypeGlass")
                    {
                        Window aWindow = getGlassWindowFromForm();
                        windowsOrdered.Add(aWindow);
                    }
                    else if (Request.Form["ctl00$MainContent$windowTypeRadios"] == "radTypeScreen")
                    {
                        Window aWindow = getScreenWindowFromForm();
                        windowsOrdered.Add(aWindow);
                    }
                    Session.Add("windowsOrdered", windowsOrdered);
                }
                #endregion

                populateSideBar(findNumberOfWindowTypes());
            }
        }


        #region getWindowFromForm methods
        /// <summary>
        /// This function creates a VinylWindow object and stores the
        /// information entered on the page.
        /// </summary>
        /// <returns>VinylWindow aWindow</returns>
        protected VinylWindow getVinylWindowFromForm()
        {
            VinylWindow aWindow = new VinylWindow();
            //moduleitem attributes
            aWindow.FEndHeight = aWindow.FStartHeight = 0;
            aWindow.FLength = 0;
            aWindow.Colour = Request.Form["ctl00$MainContent$ddlWindowColourVinyl"];
            aWindow.ItemType = "Vinyl Window";

            //base attributes
            //aWindow.WindowStyle = "Vinyl";
            aWindow.WindowStyle = Request.Form["ctl00$MainContent$ddlWindowStyleVinyl"];
            //aWindow.Kickplate = float.Parse(Request.Form["ctl00$MainContent$ddlWindowKickplateVinyl"]);

            //vinyl attributes
            if (aWindow.WindowStyle == "Vinyl Trapezoid")
            {
                aWindow.LeftHeight = float.Parse(Request.Form["ctl00$MainContent$ddlWindowLeftHeightVinyl"]);
                aWindow.RightHeight = float.Parse(Request.Form["ctl00$MainContent$ddlWindowRightHeightVinyl"]);
            }
            else
            {
                aWindow.LeftHeight = 
                    aWindow.RightHeight = float.Parse(Request.Form["ctl00$MainContent$ddlWindowHeightVinyl"]);
            }
            

            aWindow.Width = float.Parse(Request.Form["ctl00$MainContent$ddlWindowWidthVinyl"]);

            if (Request.Form["ctl100$MainContent$lblWindowDLOLBLVinyl"] == "DLO")
            {
                aWindow.RightHeight = aWindow.RightHeight + 2;
                aWindow.LeftHeight = aWindow.LeftHeight + 2;
                aWindow.Width = aWindow.Width + 2;
            }

            if (Request.Form["ctl100$MainContent$lblWindowDeductionsLBLVinyl"] == "Deduct 1/8\"")
            {
                aWindow.RightHeight = aWindow.RightHeight - 0.125F;
                aWindow.LeftHeight = aWindow.LeftHeight - 0.125F;
                aWindow.Width = aWindow.Width - 0.125F;
            }
            else if (Request.Form["ctl100$MainContent$lblWindowDeductionsLBLVinyl"] == "Deduct 1/4\"")
            {
                aWindow.RightHeight = aWindow.RightHeight - 0.25F;
                aWindow.LeftHeight = aWindow.LeftHeight - 0.25F;
                aWindow.Width = aWindow.Width - 0.25F;
            }
            else if (Request.Form["ctl100$MainContent$lblWindowDeductionsLBLVinyl"] == "Deduct 3/8\"")
            {
                aWindow.RightHeight = aWindow.RightHeight - 0.375F;
                aWindow.LeftHeight = aWindow.LeftHeight - 0.375F;
                aWindow.Width = aWindow.Width - 0.375F;
            }
            else if (Request.Form["ctl100$MainContent$lblWindowDeductionsLBLVinyl"] == "Deduct 1/2\"")
            {
                aWindow.RightHeight = aWindow.RightHeight - 0.5F;
                aWindow.LeftHeight = aWindow.LeftHeight - 0.5F;
                aWindow.Width = aWindow.Width - 0.5F;
            }

            //aWindow.GlassTint = Request.Form["ctl00$MainContent$ddlWindowGlassTintVinyl"];
            //if (aWindow.WindowStyle == "Vertical 4 Track")
            //{
            aWindow.VinylTint = Request.Form["ctl00$MainContent$ddlWindowVinylTintVinyl"];
                //aWindow.WindowWindow = new Window();


            aWindow.NumVents = (aWindow.WindowStyle == "Vertical 4 Track") ? int.Parse(Request.Form["ctl00$MainContent$ddlWindowV4TNumberOfVentsVinyl"]) :
                               (aWindow.WindowStyle == "Horizontal 4 Track") ? int.Parse(Request.Form["ctl00$MainContent$ddlWindowH4TNumberOfVentsVinyl"]) :
                               (aWindow.WindowStyle == "Horizontal 2 Track") ? 2 : 0;
            

            if (aWindow.VinylTint == "Mixed")
            {
                if (aWindow.NumVents == 2)
                {
                    aWindow.VinylTint = Request.Form["ctl00$MainContent$ddlWindowTint0Vinyl"] + Request.Form["ctl00$MainContent$ddlWindowTint1Vinyl"];
                }
                else if (aWindow.NumVents == 3)
                {
                    aWindow.VinylTint = Request.Form["ctl00$MainContent$ddlWindowTint0Vinyl"]
                        + Request.Form["ctl00$MainContent$ddlWindowTint1Vinyl"]
                        + Request.Form["ctl00$MainContent$ddlWindowTint2Vinyl"];
                }
                else if (aWindow.NumVents == 4)
                {
                    aWindow.VinylTint = Request.Form["ctl00$MainContent$ddlWindowTint0Vinyl"]
                        + Request.Form["ctl00$MainContent$ddlWindowTint1Vinyl"]
                        + Request.Form["ctl00$MainContent$ddlWindowTint2Vinyl"]
                        + Request.Form["ctl00$MainContent$ddlWindowTint3Vinyl"];
                }
            }
            //}
            //else
            //{
            aWindow.ScreenType = Request.Form["ctl00$MainContent$ddlWindowScreenOptionsVinyl"];
            //}
            //aWindow.Hinge = Request.Form["ctl00$MainContent$WindowHingeVinyl"];
            //aWindow.Swing = Request.Form["ctl00$MainContent$SwingInOutVinyl"];
            //aWindow.HardwareType = Request.Form["ctl00$MainContent$ddlWindowHardwareVinyl"];
            //aWindow.SpreaderBar = Request.Form["ctl00$MainContent$chkWindowHardwareVinyl"];

            return aWindow;
        }

        
        /// <summary>
        /// This function creates a GlassWindow object and stores the
        /// information entered on the page.
        /// </summary>
        /// <returns>GlassWindow aWindow</returns>
        protected GlassWindow getGlassWindowFromForm()
        {
            GlassWindow aWindow = new GlassWindow();
            //moduleitem attributes
            aWindow.FEndHeight = aWindow.FStartHeight = 0;
            aWindow.FLength = 0;
            aWindow.Colour = Request.Form["ctl00$MainContent$ddlWindowColourGlass"];
            aWindow.ItemType = "Glass Window";

            //base attributes
            //aWindow.WindowStyle = "Glass";
            aWindow.WindowStyle = Request.Form["ctl00$MainContent$ddlWindowStyleGlass"];
            //aWindow.Kickplate = float.Parse(Request.Form["ctl00$MainContent$ddlWindowKickplateGlass"]);

            //glass attributes

            if (aWindow.WindowStyle == "Aluminum Framed Trapezoid" || aWindow.WindowStyle == "PVC Framed Single Glazed Trapezoid")
            {
                aWindow.LeftHeight = float.Parse(Request.Form["ctl00$MainContent$ddlWindowLeftHeightGlass"]);
                aWindow.RightHeight = float.Parse(Request.Form["ctl00$MainContent$ddlWindowRightHeightGlass"]);
            }
            else
            {
                aWindow.LeftHeight = 
                    aWindow.RightHeight = float.Parse(Request.Form["ctl00$MainContent$ddlWindowHeightGlass"]);
            }
            
            aWindow.Width = float.Parse(Request.Form["ctl00$MainContent$ddlWindowWidthGlass"]);


            if (Request.Form["ctl100$MainContent$lblWindowDLOLBLGlass"] == "DLO")
            {
                aWindow.RightHeight = aWindow.RightHeight + 2;
                aWindow.LeftHeight = aWindow.LeftHeight + 2;
                aWindow.Width = aWindow.Width + 2;
            }

            if (Request.Form["ctl100$MainContent$lblWindowDeductionsLBLGlass"] == "Deduct 1/8\"")
            {
                aWindow.RightHeight = aWindow.RightHeight - 0.125F;
                aWindow.LeftHeight = aWindow.LeftHeight - 0.125F;
                aWindow.Width = aWindow.Width - 0.125F;
            }
            else if (Request.Form["ctl100$MainContent$lblWindowDeductionsLBLGlass"] == "Deduct 1/4\"")
            {
                aWindow.RightHeight = aWindow.RightHeight - 0.25F;
                aWindow.LeftHeight = aWindow.LeftHeight - 0.25F;
                aWindow.Width = aWindow.Width - 0.25F;
            }
            else if (Request.Form["ctl100$MainContent$lblWindowDeductionsLBLGlass"] == "Deduct 3/8\"")
            {
                aWindow.RightHeight = aWindow.RightHeight - 0.375F;
                aWindow.LeftHeight = aWindow.LeftHeight - 0.375F;
                aWindow.Width = aWindow.Width - 0.375F;
            }
            else if (Request.Form["ctl100$MainContent$lblWindowDeductionsLBLGlass"] == "Deduct 1/2\"")
            {
                aWindow.RightHeight = aWindow.RightHeight - 0.5F;
                aWindow.LeftHeight = aWindow.LeftHeight - 0.5F;
                aWindow.Width = aWindow.Width - 0.5F;
            }
            
            
            aWindow.GlassTint = Request.Form["ctl00$MainContent$ddlWindowGlassTintGlass"];

            aWindow.ScreenType = Request.Form["ctl00$MainContent$ddlWindowScreenOptionsGlass"];
            //aWindow.OperatingWindow = Request.Form["ctl00$MainContent$PrimaryOperatorGlass"];
            //aWindow.Swing = Request.Form["ctl00$MainContent$SwingInOutGlass"];
            //aWindow.HardwareType = Request.Form["ctl00$MainContent$ddlWindowHardwareGlass"];

            return aWindow;
        }

        
        /// <summary>
        /// This function creates a ScreenWindow object and stores the
        /// information entered on the page.
        /// </summary>
        /// <returns>ScreenWindow aWindow</returns>
        protected ScreenWindow getScreenWindowFromForm()
        {
            ScreenWindow aWindow = new ScreenWindow();
            //moduleitem attributes
            aWindow.FEndHeight = aWindow.FStartHeight = 0;
            aWindow.FLength = 0;
            aWindow.Colour = Request.Form["ctl00$MainContent$ddlWindowColourScreen"];
            aWindow.ItemType = "Screen Window";

            //base attributes
            aWindow.WindowStyle = "Screen";
            aWindow.WindowStyle = Request.Form["ctl00$MainContent$ddlWindowStyleScreen"];
            //aWindow.ScreenType = ""; //CHANGEME
            //aWindow.Kickplate = float.Parse(Request.Form["ctl00$MainContent$ddlWindowKickplateScreen"]);

            //screen attributes
            aWindow.LeftHeight = 
                aWindow.RightHeight = float.Parse(Request.Form["ctl00$MainContent$ddlWindowHeightScreen"]);
            
            aWindow.Width = float.Parse(Request.Form["ctl00$MainContent$ddlWindowWidthScreen"]);

            if (Request.Form["ctl100$MainContent$lblWindowDLOLBLScreen"] == "DLO")
            {
                aWindow.RightHeight = aWindow.RightHeight + 2;
                aWindow.LeftHeight = aWindow.LeftHeight + 2;
                aWindow.Width = aWindow.Width + 2;
            }

            if (Request.Form["ctl100$MainContent$lblWindowDeductionsLBLScreen"] == "Deduct 1/8\"")
            {
                aWindow.RightHeight = aWindow.RightHeight - 0.125F;
                aWindow.LeftHeight = aWindow.LeftHeight - 0.125F;
                aWindow.Width = aWindow.Width - 0.125F;
            }
            else if (Request.Form["ctl100$MainContent$lblWindowDeductionsLBLScreen"] == "Deduct 1/4\"")
            {
                aWindow.RightHeight = aWindow.RightHeight - 0.25F;
                aWindow.LeftHeight = aWindow.LeftHeight - 0.25F;
                aWindow.Width = aWindow.Width - 0.25F;
            }
            else if (Request.Form["ctl100$MainContent$lblWindowDeductionsLBLScreen"] == "Deduct 3/8\"")
            {
                aWindow.RightHeight = aWindow.RightHeight - 0.375F;
                aWindow.LeftHeight = aWindow.LeftHeight - 0.375F;
                aWindow.Width = aWindow.Width - 0.375F;
            }
            else if (Request.Form["ctl100$MainContent$lblWindowDeductionsLBLScreen"] == "Deduct 1/2\"")
            {
                aWindow.RightHeight = aWindow.RightHeight - 0.5F;
                aWindow.LeftHeight = aWindow.LeftHeight - 0.5F;
                aWindow.Width = aWindow.Width - 0.5F;
            }

            //aWindow.GlassTint = Request.Form["ctl00$MainContent$ddlWindowGlassTintScreen"];
            aWindow.ScreenType = Request.Form["ctl00$MainContent$ddlWindowScreenOptionsScreen"];
            //aWindow.OperatingWindow = Request.Form["ctl00$MainContent$PrimaryOperatorScreen"];

            return aWindow;
        }
        #endregion


        /// <summary>
        /// This function is used to find the amount of each type of 
        /// window that has been ordered.
        /// </summary>
        /// <returns>Tuple<int,int,int>(vinylCount,glassCount,screenCount)</returns>
        /// NOTE Tuple items:
        /// Item1:Vinyl window count
        /// Item2:Glass window count
        /// Item3:Screen window count
        private Tuple<int, int, int> findNumberOfWindowTypes()
        {
            int vinylCount = 0, glassCount = 0, screenCount = 0;
            windowsOrdered.ForEach(delegate(Window windowChecked)
            {
                if (windowChecked is VinylWindow)
                    vinylCount++;
                else if (windowChecked is GlassWindow)
                    glassCount++;
                else if (windowChecked is ScreenWindow)
                    screenCount++;
            });
            //System.Diagnostics.Debug.Write("This is the vinyl count: " + vinylCount);
            return new Tuple<int, int, int>(vinylCount, glassCount, screenCount);
        }

        #region populate side bar
        
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
                lblWindowPager.Controls.Add(new LiteralControl("<li id='vinylWindows'>"));


                Label vinylLabel = new Label();
                //vinylLabel.ID = "lblVinylWindows";
                vinylLabel.Text = "Vinyl Windows Ordered " + windowTypeCounts.Item1;
                lblWindowPager.Controls.Add(vinylLabel);

                count = 1;

                #region Creating Vinyl window pager items
                foreach (Window aWindow in windowsOrdered)
                {
                    if (aWindow.ItemType == "Vinyl Window")
                    {
                        lblWindowPager.Controls.Add(new LiteralControl("<div class='toggleContent'>"));

                        VinylWindow aVinyl = (VinylWindow)aWindow;

                        Label vinylCurrentWindow = new Label();
                        //vinylCurrentWindow.ID = "lblVinylVinyl" + count;
                        vinylCurrentWindow.Text = "Vinyl Window " + count;
                        lblWindowPager.Controls.Add(vinylCurrentWindow);

                        Label vinylStyle = new Label();
                        //vinylStyle.ID = "lblVinylStyle" + count;
                        vinylStyle.Text = "Style: " + aVinyl.WindowStyle;
                        lblWindowPager.Controls.Add(vinylStyle);

                        Label vinylColour = new Label();
                        //vinylColour.ID = "lblVinylColour" + count;
                        vinylColour.Text = "Frame Colour: " + aVinyl.Colour;
                        lblWindowPager.Controls.Add(vinylColour);

                        //Label vinylKickplate = new Label();
                        //vinylKickplate.ID = "lblVinylKickplate" + count;
                        //vinylKickplate.Text = "Kickplate: " + String.Format("{0}", aVinyl.Kickplate);
                        //lblWindowPager.Controls.Add(vinylKickplate);

                        if (aWindow.WindowStyle == "Vinyl Trapezoid")
                        {
                            Label vinylLeftHeight = new Label();
                            //vinylLeftHeight.ID = "lblVinylLeftHeight" + count;
                            vinylLeftHeight.Text = "Left Height: " + String.Format("{0}", aVinyl.LeftHeight);
                            lblWindowPager.Controls.Add(vinylLeftHeight);

                            Label vinylRightHeight = new Label();
                            //vinylRightHeight.ID = "lblVinylRightHeight" + count;
                            vinylRightHeight.Text = "Right Height: " + String.Format("{0}", aVinyl.RightHeight);
                            lblWindowPager.Controls.Add(vinylRightHeight);
                        }
                        else
                        {
                            Label vinylHeight = new Label();
                            //vinylHeight.ID = "lblVinylHeight" + count;
                            vinylHeight.Text = "Height: " + String.Format("{0}", aVinyl.LeftHeight);
                            lblWindowPager.Controls.Add(vinylHeight);
                        }

                        Label vinylLength = new Label();
                        //vinylLength.ID = "lblVinylLength" + count;
                        vinylLength.Text = "Width: " + String.Format("{0}", aVinyl.Width);
                        lblWindowPager.Controls.Add(vinylLength);

                        //Label vinylGlassTint = new Label();
                        //vinylGlassTint.ID = "lblVinylGlassTint" + count;
                        //vinylGlassTint.Text = "Glass Tint: " + aVinyl.GlassTint;
                        //lblWindowPager.Controls.Add(vinylGlassTint);

                        //if (aVinyl.WindowStyle == "Vertical 4 Track")
                        //{
                            Label vinylNumVents = new Label();
                            //vinylNumVents.ID = "lblVinylNumVents" + count;
                            vinylNumVents.Text = "No. Vents: " + String.Format("{0}", aVinyl.NumVents);
                            lblWindowPager.Controls.Add(vinylNumVents);
                        //}
                            Label vinylVinylTint = new Label();
                            //vinylVinylTint.ID = "lblVinylVinylTint" + count;
                            vinylVinylTint.Text = "Vinyl Tint: " + aVinyl.VinylTint;
                            lblWindowPager.Controls.Add(vinylVinylTint);
                        
                        //else
                        //{
                            Label vinylScreenType = new Label();
                            //vinylScreenType.ID = "lblVinylScreenType" + count;
                            vinylScreenType.Text = "Screen Type: " + aVinyl.ScreenType;
                            lblWindowPager.Controls.Add(vinylScreenType);
                        //}


                            Label vinylSpreaderBar = new Label();
                            //vinylSpreaderBar.ID = "lblVinylSpreaderBar" + count;
                            vinylSpreaderBar.Text = "Spreader Bar: " + aVinyl.SpreaderBar;
                            lblWindowPager.Controls.Add(vinylSpreaderBar);


                        //Label vinylHinge = new Label();
                        //vinylHinge.ID = "lblVinylHinge" + count;
                        //vinylHinge.Text = "Hinge: " + aVinyl.Hinge;
                        //lblWindowPager.Controls.Add(vinylHinge);

                        //Label vinylSwing = new Label();
                        //vinylSwing.ID = "lblVinylSwing" + count;
                        //vinylSwing.Text = "Swing: " + aVinyl.Swing;
                        //lblWindowPager.Controls.Add(vinylSwing);

                        //Label vinylHardwareType = new Label();
                        //vinylHardwareType.ID = "lblVinylHardwareType" + count;
                        //vinylHardwareType.Text = "Hardware: " + aVinyl.HardwareType;
                        //lblWindowPager.Controls.Add(vinylHardwareType);


                        lblWindowPager.Controls.Add(new LiteralControl("</div>"));

                        count++;
                    }
                }
                #endregion

                lblWindowPager.Controls.Add(new LiteralControl("</li>"));


                if (windowTypeCounts.Item2 > 0)
                {
                    lblWindowPager.Controls.Add(new LiteralControl("<li id='glassWindows'>"));

                    Label glassLabel = new Label();
                    glassLabel.ID = "lblGlassWindows";
                    glassLabel.Text = "Glass Windows Ordered " + windowTypeCounts.Item2;
                    lblWindowPager.Controls.Add(glassLabel);

                    count = 1;

                    #region Creating Glass window pager items
                    foreach (Window aWindow in windowsOrdered)
                    {
                        if (aWindow.ItemType == "Glass Window")
                        {
                            lblWindowPager.Controls.Add(new LiteralControl("<div class='toggleContent'>"));

                            GlassWindow aGlass = (GlassWindow)aWindow;

                            Label glassCurrentWindow = new Label();
                            glassCurrentWindow.ID = "lblGlassGlass" + count;
                            glassCurrentWindow.Text = "Glass Window " + count;
                            lblWindowPager.Controls.Add(glassCurrentWindow);

                            Label glassStyle = new Label();
                            glassStyle.ID = "lblGlassStyle" + count;
                            glassStyle.Text = "Style: " + aGlass.WindowStyle;
                            lblWindowPager.Controls.Add(glassStyle);

                            Label glassColour = new Label();
                            glassColour.ID = "lblGlassColour" + count;
                            glassColour.Text = "Frame Colour: " + aGlass.Colour;
                            lblWindowPager.Controls.Add(glassColour);

                            //Label glassKickplate = new Label();
                            //glassKickplate.ID = "lblGlassKickplate" + count;
                            //glassKickplate.Text = "Kickplate: " + String.Format("{0}", aGlass.Kickplate);
                            //lblWindowPager.Controls.Add(glassKickplate);

                            if (aWindow.WindowStyle == "Aluminum Framed Trapezoid" || aWindow.WindowStyle == "PVC Framed Single Glazed Trapezoid")
                            {
                                Label glassLeftHeight = new Label();
                                glassLeftHeight.ID = "lblGlassLeftHeight" + count;
                                glassLeftHeight.Text = "Left Height: " + String.Format("{0}", aGlass.LeftHeight);
                                lblWindowPager.Controls.Add(glassLeftHeight);

                                Label glassRightHeight = new Label();
                                glassRightHeight.ID = "lblGlassRightHeight" + count;
                                glassRightHeight.Text = "Right Height: " + String.Format("{0}", aGlass.RightHeight);
                                lblWindowPager.Controls.Add(glassRightHeight);
                            }
                            else
                            {
                                Label glassHeight = new Label();
                                glassHeight.ID = "lblGlassHeight" + count;
                                glassHeight.Text = "Height: " + String.Format("{0}", aGlass.LeftHeight);
                                lblWindowPager.Controls.Add(glassHeight);
                            }

                            Label glassLength = new Label();
                            glassLength.ID = "lblGlassLength" + count;
                            glassLength.Text = "Width: " + String.Format("{0}", aGlass.Width);
                            lblWindowPager.Controls.Add(glassLength);

                            Label glassGlassTint = new Label();
                            glassGlassTint.ID = "lblGlassGlassTint" + count;
                            glassGlassTint.Text = "Glass Tint: " + aGlass.GlassTint;
                            lblWindowPager.Controls.Add(glassGlassTint);

                            //if (aGlass.WindowStyle == "Vertical 4 Track")
                            //{
                            //Label glassNumVents = new Label();
                            //glassNumVents.ID = "lblGlassNumVents" + count;
                            //glassNumVents.Text = "No. Vents: " + String.Format("{0}", aGlass.NumVents);
                            //lblWindowPager.Controls.Add(glassNumVents);

                            //Label glassVinylTint = new Label();
                            //glassVinylTint.ID = "lblGlassVinylTint" + count;
                            //glassVinylTint.Text = "Glass Tint: " + aGlass.GlassTint;
                            //lblWindowPager.Controls.Add(glassVinylTint);
                            //}
                            //else
                            //{
                            Label glassScreenType = new Label();
                            glassScreenType.ID = "lblGlassScreenType" + count;
                            glassScreenType.Text = "Screen Type: " + aGlass.ScreenType;
                            lblWindowPager.Controls.Add(glassScreenType);
                            //}

                            //Label glassOperatingWindow = new Label();
                            //glassOperatingWindow.ID = "lblGlassOperatingWindow" + count;
                            //glassOperatingWindow.Text = "Operating Window: " + aGlass.OperatingWindow;
                            //lblWindowPager.Controls.Add(glassOperatingWindow);

                            //Label glassSwing = new Label();
                            //glassSwing.ID = "lblGlassSwing" + count;
                            //glassSwing.Text = "Swing: " + aGlass.Swing;
                            //lblWindowPager.Controls.Add(glassSwing);

                            //Label glassHardwareType = new Label();
                            //glassHardwareType.ID = "lblGlassHardwareType" + count;
                            //glassHardwareType.Text = "Hardware: " + aGlass.HardwareType;
                            //lblWindowPager.Controls.Add(glassHardwareType);

                            lblWindowPager.Controls.Add(new LiteralControl("</div>"));

                            count++;
                        }
                    }
                    #endregion

                    lblWindowPager.Controls.Add(new LiteralControl("</li>"));
                }

                if (windowTypeCounts.Item3 > 0)
                {
                    lblWindowPager.Controls.Add(new LiteralControl("<li id='screenWindows'>"));

                    Label screenLabel = new Label();
                    screenLabel.ID = "lblScreenWindows";
                    screenLabel.Text = "Screen Windows Ordered " + windowTypeCounts.Item3;
                    lblWindowPager.Controls.Add(screenLabel);

                    count = 1;

                    #region Creating Screen window pager items
                    foreach (Window aWindow in windowsOrdered)
                    {
                        if (aWindow.WindowStyle == "Screen")
                        {
                            lblWindowPager.Controls.Add(new LiteralControl("<div class='toggleContent'>"));

                            ScreenWindow aScreen = (ScreenWindow)aWindow;

                            Label screenCurrentWindow = new Label();
                            screenCurrentWindow.ID = "lblScreenScreen" + count;
                            screenCurrentWindow.Text = "Screen Window " + count;
                            lblWindowPager.Controls.Add(screenCurrentWindow);

                            Label screenStyle = new Label();
                            screenStyle.ID = "lblScreenStyle" + count;
                            screenStyle.Text = "Style: " + aScreen.WindowStyle;
                            lblWindowPager.Controls.Add(screenStyle);

                            Label screenColour = new Label();
                            screenColour.ID = "lblScreenColour" + count;
                            screenColour.Text = "Frame Colour: " + aScreen.Colour;
                            lblWindowPager.Controls.Add(screenColour);

                            //Label screenKickplate = new Label();
                            //screenKickplate.ID = "lblScreenKickplate" + count;
                            //screenKickplate.Text = "Kickplate: " + String.Format("{0}", aScreen.Kickplate);
                            //lblWindowPager.Controls.Add(screenKickplate);


                            Label screenHeight = new Label();
                            screenHeight.ID = "lblScreenHeight" + count;
                            screenHeight.Text = "Height: " + String.Format("{0}", aScreen.LeftHeight);
                            lblWindowPager.Controls.Add(screenHeight);


                            Label screenLength = new Label();
                            screenLength.ID = "lblScreenLength" + count;
                            screenLength.Text = "Width: " + String.Format("{0}", aScreen.Length);
                            lblWindowPager.Controls.Add(screenLength);

                            //Label screenGlassTint = new Label();
                            //screenGlassTint.ID = "lblScreenGlassTint" + count;
                            //screenGlassTint.Text = "Glass Tint: " + aScreen.GlassTint;
                            //lblWindowPager.Controls.Add(screenGlassTint);

                            Label screenScreenType = new Label();
                            screenScreenType.ID = "lblScreenScreenType" + count;
                            screenScreenType.Text = "Screen Type: " + aScreen.ScreenType;
                            lblWindowPager.Controls.Add(screenScreenType);

                            //Label screenOperatingWindow = new Label();
                            //screenOperatingWindow.ID = "lblScreenOperatingWindow" + count;
                            //screenOperatingWindow.Text = "Operating Window: " + aScreen.OperatingWindow;
                            //lblWindowPager.Controls.Add(screenOperatingWindow);

                            lblWindowPager.Controls.Add(new LiteralControl("</div>"));

                            count++;
                        }
                    }
                    #endregion

                    lblWindowPager.Controls.Add(new LiteralControl("</li>"));
                }

                lblWindowPager.Controls.Add(new LiteralControl("</ul>"));

            }

        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            loadDetails("Window");


            #region PostBack functionality to store windows
            if (IsPostBack)
            {
                if ((List<Window>)Session["windowsOrdered"] != null)
                {
                    windowsOrdered = (List<Window>)Session["windowsOrdered"];
                }

                if (Request.Form["ctl00$MainContent$windowTypeRadios"] == "radTypeVinyl")
                {
                    Window aWindow = getVinylWindowFromForm();
                    windowsOrdered.Add(aWindow);
                }
                else if (Request.Form["ctl00$MainContent$windowTypeRadios"] == "radTypeGlass")
                {
                    Window aWindow = getGlassWindowFromForm();
                    windowsOrdered.Add(aWindow);
                }
                else if (Request.Form["ctl00$MainContent$windowTypeRadios"] == "radTypeScreen")
                {
                    Window aWindow = getScreenWindowFromForm();
                    windowsOrdered.Add(aWindow);
                }
                Session.Add("windowsOrdered", windowsOrdered);
            }
            #endregion

            populateSideBar(findNumberOfWindowTypes());

        }
    }
}
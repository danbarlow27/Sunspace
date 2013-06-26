using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SunspaceDealerDesktop
{
    public partial class WizardWallsAndMods : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /***hard coded session variables***/
            Session["numberOfWalls"] = 4;
            Session["coordList"] = "125,387.5,162.5,162.5,E,S/187.5,187.5,162.5,275,P,W/187.5,300,275,275,P,S/300,300,275,162.5,P,E/";
            /**********************************/
            hiddenFieldsDiv.InnerHtml = createHiddenFields(); //create hidden fields on page load dynamically

            #region DropDownList Section
            DropDownList ddlInFrac = new DropDownList();
            ListItem lst0 = new ListItem("---", "", true);
            ListItem lst18 = new ListItem("1/8", ".125");
            ListItem lst14 = new ListItem("1/4", ".25");
            ListItem lst38 = new ListItem("3/8", ".375");
            ListItem lst12 = new ListItem("1/2", ".5");
            ListItem lst58 = new ListItem("5/8", ".625");
            ListItem lst34 = new ListItem("3/4", ".75");
            ListItem lst78 = new ListItem("7/8", ".875");
            ddlInFrac.Items.Add(lst0);
            ddlInFrac.Items.Add(lst18);
            ddlInFrac.Items.Add(lst14);
            ddlInFrac.Items.Add(lst38);
            ddlInFrac.Items.Add(lst12);
            ddlInFrac.Items.Add(lst58);
            ddlInFrac.Items.Add(lst34);
            ddlInFrac.Items.Add(lst78);
            //inchesSpecifics.Controls.Add(ddlInFrac);

            DropDownList ddlInFracBackWall = new DropDownList();
            ddlInFracBackWall.Items.Add(lst0);
            ddlInFracBackWall.Items.Add(lst18);
            ddlInFracBackWall.Items.Add(lst14);
            ddlInFracBackWall.Items.Add(lst38);
            ddlInFracBackWall.Items.Add(lst12);
            ddlInFracBackWall.Items.Add(lst58);
            ddlInFracBackWall.Items.Add(lst34);
            ddlInFracBackWall.Items.Add(lst78);
            phBackHeights.Controls.Add(ddlInFracBackWall);

            DropDownList ddlInFracFrontWall = new DropDownList();
            ddlInFracFrontWall.Items.Add(lst0);
            ddlInFracFrontWall.Items.Add(lst18);
            ddlInFracFrontWall.Items.Add(lst14);
            ddlInFracFrontWall.Items.Add(lst38);
            ddlInFracFrontWall.Items.Add(lst12);
            ddlInFracFrontWall.Items.Add(lst58);
            ddlInFracFrontWall.Items.Add(lst34);
            ddlInFracFrontWall.Items.Add(lst78);
            phFrontHeights.Controls.Add(ddlInFracFrontWall);
            #endregion

            //SLIDE 3 DOOR DETAILS PER WALL
            #region Slide 3: Onload dynamic loop to insert wall door options

            #region Wall #:Radio button section

            wallDoorOptions.Controls.Add(new LiteralControl("<li>"));

            RadioButton wallRadio = new RadioButton();
            wallRadio.ID = "radWall";

            Label wallLabelRadio = new Label();
            Label wallLabel = new Label();

            wallLabelRadio.AssociatedControlID = "radWall";
            wallLabel.AssociatedControlID = "radWall";
            wallLabel.Text = "Wall 1 Door Options";

            wallDoorOptions.Controls.Add(wallRadio);
            wallDoorOptions.Controls.Add(wallLabelRadio);
            wallDoorOptions.Controls.Add(wallLabel);            

            wallDoorOptions.Controls.Add(new LiteralControl("<div class='toggleContent'><ul><li>"));

            wallDoorOptions.Controls.Add(new LiteralControl("<h3>Select door details:</h3>"));

            Table tblDoorDetails = new Table();

            tblDoorDetails.ID = "tblDoorDetails";
            tblDoorDetails.CssClass = "tblTextFields";
            tblDoorDetails.Attributes.Add("runat", "server");

            #endregion

            //Creating cells and controls for rows

            #region Table:First Row Type of Door (tblDoorDetails)

            TableRow typeOfDoorRow = new TableRow();            
            TableCell typeOfDoorLBLCell = new TableCell();
            TableCell typeOfDoorDDLCell = new TableCell();

            Label typeOfDoorLBL = new Label();
            typeOfDoorLBL.ID = "lblDoorType";
            typeOfDoorLBL.Text = "Door Type:";

            DropDownList typeOfDoorDDL = new DropDownList();
            typeOfDoorDDL.ID = "ddlDoorType";
            ListItem cabana = new ListItem("Cabana", "cabana");
            ListItem french = new ListItem("French", "french");
            ListItem patio = new ListItem("Patio", "patio");
            ListItem noDoor = new ListItem("Opening Only (No Door)", "noDoor");
            typeOfDoorDDL.Items.Add(cabana);
            typeOfDoorDDL.Items.Add(french);
            typeOfDoorDDL.Items.Add(patio);
            typeOfDoorDDL.Items.Add(noDoor);

            typeOfDoorLBL.AssociatedControlID = "ddlDoorType";

            #endregion

            #region Table:Second Row Color of Door (tblDoorDetails)

            TableRow colorOfDoorRow = new TableRow();
            TableCell colorOfDoorLBLCell = new TableCell();
            TableCell colorOfDoorDDLCell = new TableCell();

            Label colorOfDoorLBL = new Label();
            colorOfDoorLBL.ID = "lblDoorColor";
            colorOfDoorLBL.Text = "Door Color:";

            DropDownList colorOfDoorDDL = new DropDownList();
            colorOfDoorDDL.ID = "ddlDoorColor";
            ListItem clear = new ListItem("Clear", "clear");
            ListItem grey = new ListItem("Grey", "grey");
            ListItem bronze = new ListItem("Bronze", "bronze");
            colorOfDoorDDL.Items.Add(clear);
            colorOfDoorDDL.Items.Add(grey);
            colorOfDoorDDL.Items.Add(bronze);

            colorOfDoorLBL.AssociatedControlID = "ddlDoorColor";

            #endregion

            #region Table:Third Row Door Height (tblDoorDetails)

            TableRow doorHeightRow = new TableRow();
            TableCell doorHeightLBLCell = new TableCell();
            TableCell doorHeightDDLCell = new TableCell();

            Label doorHeightLBL = new Label();
            doorHeightLBL.ID = "lblDoorHeight";
            doorHeightLBL.Text = "Height:";

            DropDownList doorHeightDDL = new DropDownList();
            doorHeightDDL.ID = "ddlDoorHeight";
            ListItem fiveFeet = new ListItem("5'", "5");
            ListItem sixFeet = new ListItem("6'", "6");
            ListItem sevenFeet = new ListItem("7'", "7");
            ListItem eightFeet = new ListItem("8'", "8");
            ListItem customHeight = new ListItem("Custom", "cHeight");
            doorHeightDDL.Items.Add(fiveFeet);
            doorHeightDDL.Items.Add(sixFeet);
            doorHeightDDL.Items.Add(sevenFeet);
            doorHeightDDL.Items.Add(eightFeet);
            doorHeightDDL.Items.Add(customHeight);

            doorHeightLBL.AssociatedControlID = "ddlDoorHeight";

            #endregion

            #region Table:Fourth Row Door Width (tblDoorDetails)

            TableRow doorWidthRow = new TableRow();
            TableCell doorWidthLBLCell = new TableCell();
            TableCell doorWidthDDLCell = new TableCell();

            Label doorWidthLBL = new Label();
            doorWidthLBL.ID = "lblDoorWidth";
            doorWidthLBL.Text = "Width:";

            DropDownList doorWidthDDL = new DropDownList();
            doorWidthDDL.ID = "ddlDoorWidth";
            ListItem thirty = new ListItem("30\"", "30");
            ListItem thirtyTwo = new ListItem("32\"", "32");
            ListItem thirtyFour = new ListItem("34\"", "34");
            ListItem thirtySix = new ListItem("36\"", "36");
            ListItem customWidth = new ListItem("Custom", "cWidth");
            doorWidthDDL.Items.Add(thirty);
            doorWidthDDL.Items.Add(thirtyTwo);
            doorWidthDDL.Items.Add(thirtyFour);
            doorWidthDDL.Items.Add(thirtySix);
            doorWidthDDL.Items.Add(customWidth);

            doorWidthLBL.AssociatedControlID = "ddlDoorWidth";

            #endregion

            #region Table:Fifth Row Door Custom Height (tblDoorDetails)

            TableRow doorCustomHeightRow = new TableRow();
            TableCell doorCustomHeightLBLCell = new TableCell();
            TableCell doorCustomHeightTXTCell = new TableCell();
            TableCell doorCustomHeightDDLCell = new TableCell();

            Label doorCustomHeightLBL = new Label();
            doorCustomHeightLBL.ID = "lblDoorCustomHeight";
            doorCustomHeightLBL.Text = "Custom Height (inches):";

            TextBox doorCustomHeightTXT = new TextBox();
            doorCustomHeightTXT.ID = "txtDoorCustomHeight";
            doorCustomHeightTXT.CssClass = "txtField txtDoorInput";

            DropDownList inchCustomHeight = new DropDownList();
            inchCustomHeight.ID = "ddlInchCustomHeight";
            inchCustomHeight.Items.Add(lst0);
            inchCustomHeight.Items.Add(lst18);
            inchCustomHeight.Items.Add(lst14);
            inchCustomHeight.Items.Add(lst38);
            inchCustomHeight.Items.Add(lst12);
            inchCustomHeight.Items.Add(lst58);
            inchCustomHeight.Items.Add(lst34);
            inchCustomHeight.Items.Add(lst78);

            doorCustomHeightLBL.AssociatedControlID = "txtDoorCustomHeight";

            #endregion

            #region Table:Sixth Row Door Custom Width (tblDoorDetails)

            TableRow doorCustomWidthRow = new TableRow();
            TableCell doorCustomWidthLBLCell = new TableCell();
            TableCell doorCustomWidthTXTCell = new TableCell();
            TableCell doorCustomWidthDDLCell = new TableCell();

            Label doorCustomWidthLBL = new Label();
            doorCustomWidthLBL.ID = "lblDoorCustomWidth";
            doorCustomWidthLBL.Text = "Custom Width (inches):";

            TextBox doorCustomWidthTXT = new TextBox();
            doorCustomWidthTXT.ID = "txtDoorCustomWidth";
            doorCustomWidthTXT.CssClass = "txtField txtDoorInput";

            DropDownList inchCustomWidth = new DropDownList();
            inchCustomWidth.ID = "ddlInchCustomWidth";
            inchCustomWidth.Items.Add(lst0);
            inchCustomWidth.Items.Add(lst18);
            inchCustomWidth.Items.Add(lst14);
            inchCustomWidth.Items.Add(lst38);
            inchCustomWidth.Items.Add(lst12);
            inchCustomWidth.Items.Add(lst58);
            inchCustomWidth.Items.Add(lst34);
            inchCustomWidth.Items.Add(lst78);

            doorCustomWidthLBL.AssociatedControlID = "txtDoorCustomWidth";

            #endregion

            #region Table:Seventh Row Door Swing In (tblDoorDetails)

            TableRow doorSwingInRow = new TableRow();
            TableCell doorSwingInLBLCell = new TableCell();
            TableCell doorSwingInRADCell = new TableCell();

            Label doorSwingInLBLMain = new Label();
            doorSwingInLBLMain.ID = "lblDoorSwingMain";
            doorSwingInLBLMain.Text = "Swing:";

            Label doorSwingInLBLRad = new Label();
            doorSwingInLBLRad.ID = "lblDoorSwingIn";

            Label doorSwingInLBL = new Label();
            doorSwingInLBL.ID = "lblDoorSwingInRad";
            doorSwingInLBL.Text = "In";            

            RadioButton doorSwingInRAD = new RadioButton();
            doorSwingInRAD.ID = "radDoorSwingIn";
            doorSwingInRAD.GroupName = "SwingInOut";

            doorSwingInLBLRad.AssociatedControlID = "radDoorSwingIn";
            doorSwingInLBL.AssociatedControlID = "radDoorSwingIn";

            #endregion            

            #region Table:Eight Row Door Swing Out (tblDoorDetails)

            TableRow doorSwingOutRow = new TableRow();
            TableCell doorSwingOutLBLCell = new TableCell();
            TableCell doorSwingOutRADCell = new TableCell();

            Label doorSwingOutLBLRad = new Label();
            doorSwingOutLBLRad.ID = "lblDoorSwingOutRad";

            Label doorSwingOutLBL = new Label();
            doorSwingOutLBL.ID = "lblDoorSwingOut";
            doorSwingOutLBL.Text = "Out";

            RadioButton doorSwingOutRAD = new RadioButton();
            doorSwingOutRAD.ID = "radDoorSwingOut";
            doorSwingOutRAD.GroupName = "SwingInOut";

            doorSwingOutLBLRad.AssociatedControlID = "radDoorSwingOut";
            doorSwingOutLBL.AssociatedControlID = "radDoorSwingOut";

            #endregion            

            #region Table:Ninth Row Door Hinge LHH (tblDoorDetails)

            TableRow doorLHHRow = new TableRow();
            TableCell doorLHHLBLCell = new TableCell();
            TableCell doorLHHRADCell = new TableCell();

            Label doorLHHLBLMain = new Label();
            doorLHHLBLMain.ID = "lblDoorLHHMain";
            doorLHHLBLMain.Text = "Hinge placement:";

            Label doorLHHLBLRad = new Label();
            doorLHHLBLRad.ID = "lblLHHRad";

            Label doorLHHLBL = new Label();
            doorLHHLBL.ID = "lblLHH";
            doorLHHLBL.Text = "LHH";

            RadioButton doorLHHRad = new RadioButton();
            doorLHHRad.ID = "radDoorLHH";
            doorLHHRad.GroupName = "DoorHinge";

            doorLHHLBLRad.AssociatedControlID = "radDoorLHH";
            doorLHHLBL.AssociatedControlID = "radDoorLHH";

            #endregion

            #region Table:Tenth Row Door Hinge RHH (tblDoorDetails)

            TableRow doorRHHRow = new TableRow();
            TableCell doorRHHLBLCell = new TableCell();
            TableCell doorRHHRADCell = new TableCell();

            Label doorRHHLBLRad = new Label();
            doorRHHLBLRad.ID = "lblDoorRHHRad";

            Label doorRHHLBL = new Label();
            doorRHHLBL.ID = "lblDoorRHH";
            doorRHHLBL.Text = "RHH";

            RadioButton doorRHHRad = new RadioButton();
            doorRHHRad.ID = "radDoorRHH";
            doorRHHRad.GroupName = "DoorHinge";

            doorRHHLBLRad.AssociatedControlID = "radDoorRHH";
            doorRHHLBL.AssociatedControlID = "radDoorRHH";

            #endregion

            #region Table:# Row Door Position (tblDoorDetails)

            TableRow doorPositionRow = new TableRow();
            TableCell doorPositionLBLCell = new TableCell();
            TableCell doorPositionTXTCell = new TableCell();
            TableCell doorPositionDDLCell = new TableCell();

            Label doorPositionLBL = new Label();
            doorPositionLBL.ID = "lblDoorPosition";
            doorPositionLBL.Text = "Door position from left side (inches):";

            TextBox doorPositionTXT = new TextBox();
            doorPositionTXT.ID = "txtDoorPosition";
            doorPositionTXT.CssClass = "txtField txtDoorInput";

            DropDownList inchSpecificLeft = new DropDownList();
            inchSpecificLeft.ID = "ddlInchSpecificLeft";
            inchSpecificLeft.Items.Add(lst0);
            inchSpecificLeft.Items.Add(lst18);
            inchSpecificLeft.Items.Add(lst14);
            inchSpecificLeft.Items.Add(lst38);
            inchSpecificLeft.Items.Add(lst12);
            inchSpecificLeft.Items.Add(lst58);
            inchSpecificLeft.Items.Add(lst34);
            inchSpecificLeft.Items.Add(lst78);

            doorPositionLBL.AssociatedControlID = "txtDoorPosition";

            #endregion
            
            //Adding to table

            #region Table:First Row Type of Door Added to Table (tblDoorDetails)
            typeOfDoorLBLCell.Controls.Add(typeOfDoorLBL);
            typeOfDoorDDLCell.Controls.Add(typeOfDoorDDL);
            
            tblDoorDetails.Rows.Add(typeOfDoorRow);

            typeOfDoorRow.Cells.Add(typeOfDoorLBLCell);
            typeOfDoorRow.Cells.Add(typeOfDoorDDLCell);
            #endregion

            #region Table:Second Row Color of Door Added to Table (tblDoorDetails)

            colorOfDoorLBLCell.Controls.Add(colorOfDoorLBL);
            colorOfDoorDDLCell.Controls.Add(colorOfDoorDDL);

            tblDoorDetails.Rows.Add(colorOfDoorRow);

            colorOfDoorRow.Cells.Add(colorOfDoorLBLCell);
            colorOfDoorRow.Cells.Add(colorOfDoorDDLCell);

            #endregion

            #region Table:Third Row Height Of Door Added To Table (tblDoorDetails)

            doorHeightLBLCell.Controls.Add(doorHeightLBL);
            doorHeightDDLCell.Controls.Add(doorHeightDDL);

            tblDoorDetails.Rows.Add(doorHeightRow);

            doorHeightRow.Cells.Add(doorHeightLBLCell);
            doorHeightRow.Cells.Add(doorHeightDDLCell);

            #endregion

            #region Table:Fourth Row Width Of Door Added To Table (tblDoorDetails)

            doorWidthLBLCell.Controls.Add(doorWidthLBL);
            doorWidthDDLCell.Controls.Add(doorWidthDDL);

            tblDoorDetails.Rows.Add(doorWidthRow);

            doorWidthRow.Cells.Add(doorWidthLBLCell);
            doorWidthRow.Cells.Add(doorWidthDDLCell);

            #endregion

            #region Table:Fifth Row Custom Height Of Door Added To Table (tblDoorDetails)

            doorCustomHeightLBLCell.Controls.Add(doorCustomHeightLBL);
            doorCustomHeightTXTCell.Controls.Add(doorCustomHeightTXT);
            doorCustomHeightDDLCell.Controls.Add(inchCustomHeight);

            tblDoorDetails.Rows.Add(doorCustomHeightRow);

            doorCustomHeightRow.Cells.Add(doorCustomHeightLBLCell);
            doorCustomHeightRow.Cells.Add(doorCustomHeightTXTCell);
            doorCustomHeightRow.Cells.Add(doorCustomHeightDDLCell);

            #endregion

            #region Table:Sixth Row Custom Width Of Door Added To Table (tblDoorDetails)

            doorCustomWidthLBLCell.Controls.Add(doorCustomWidthLBL);
            doorCustomWidthTXTCell.Controls.Add(doorCustomWidthTXT);
            doorCustomWidthDDLCell.Controls.Add(inchCustomWidth);

            tblDoorDetails.Rows.Add(doorCustomWidthRow);

            doorCustomWidthRow.Cells.Add(doorCustomWidthLBLCell);
            doorCustomWidthRow.Cells.Add(doorCustomWidthTXTCell);
            doorCustomWidthRow.Cells.Add(doorCustomWidthDDLCell);

            #endregion

            #region Table:Seventh Row Swing In Added To Table (tblDoorDetails)

            doorSwingInLBLCell.Controls.Add(doorSwingInLBLMain);

            doorSwingInRADCell.Controls.Add(doorSwingInRAD);
            doorSwingInRADCell.Controls.Add(doorSwingInLBLRad);
            doorSwingInRADCell.Controls.Add(doorSwingInLBL);

            tblDoorDetails.Rows.Add(doorSwingInRow);

            doorSwingInRow.Cells.Add(doorSwingInLBLCell);
            doorSwingInRow.Cells.Add(doorSwingInRADCell);

            #endregion

            #region Table:Eight Row Swing Out Added To Table (tblDoorDetails)

            doorSwingOutRADCell.Controls.Add(doorSwingOutRAD);
            doorSwingOutRADCell.Controls.Add(doorSwingOutLBLRad);
            doorSwingOutRADCell.Controls.Add(doorSwingOutLBL);

            tblDoorDetails.Rows.Add(doorSwingOutRow);

            doorSwingOutRow.Cells.Add(doorSwingOutLBLCell);
            doorSwingOutRow.Cells.Add(doorSwingOutRADCell);

            #endregion

            #region Table:Ninth Row Door Hinge LHH (tblDoorDetails)

            doorLHHLBLCell.Controls.Add(doorLHHLBLMain);

            doorLHHRADCell.Controls.Add(doorLHHRad);
            doorLHHRADCell.Controls.Add(doorLHHLBLRad);
            doorLHHRADCell.Controls.Add(doorLHHLBL);

            tblDoorDetails.Rows.Add(doorLHHRow);

            doorLHHRow.Cells.Add(doorLHHLBLCell);
            doorLHHRow.Cells.Add(doorLHHRADCell);

            #endregion

            #region Table:Tenth Row Door Hinge RHH (tblDoorDetails)

            doorRHHRADCell.Controls.Add(doorRHHRad);
            doorRHHRADCell.Controls.Add(doorRHHLBLRad);
            doorRHHRADCell.Controls.Add(doorRHHLBL);

            tblDoorDetails.Rows.Add(doorRHHRow);

            doorRHHRow.Cells.Add(doorRHHLBLCell);
            doorRHHRow.Cells.Add(doorRHHRADCell);

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

            wallDoorOptions.Controls.Add(tblDoorDetails);

            wallDoorOptions.Controls.Add(new LiteralControl("</li></ul></div>"));

            #endregion

            //DropDownList used in tables loaded to page
            

            #region For Loop for slide 1 and slide3
            //Used to dynamically add values to ddlWallDoorPlacement
            for (int i = 1; i <= (int)Session["numberOfWalls"]; i++)
            {
                ListItem numberOfWalls = new ListItem(Convert.ToString(i), Convert.ToString(i));
                //ddlWallDoorPlacement.Items.Add(numberOfWalls);
            }

            for (int i = 1; i <= (int)Session["numberOfWalls"]; i++) //numberOfWalls is hard-coded to be 4 right now
            {
                TableRow row = new TableRow();
                TableRow rowLeftFiller = new TableRow();
                TableRow rowRightFiller = new TableRow();

                TableCell cell1 = new TableCell();
                TableCell cell2 = new TableCell();
                TableCell cell3 = new TableCell();
                TableCell cell4 = new TableCell();
                TableCell cell5 = new TableCell();
                TableCell cell6 = new TableCell();
                TableCell cell7 = new TableCell();

                Label lblWallNumber = new Label();

                TextBox txtWallLength = new TextBox();
                TextBox txtLeftFiller = new TextBox();
                TextBox txtRightFiller = new TextBox();

                DropDownList ddlInchFractions = new DropDownList();
                DropDownList ddlLeftInchFractions = new DropDownList();
                DropDownList ddlRightInchFractions = new DropDownList();

                ddlInchFractions.Items.Add(lst0);
                ddlInchFractions.Items.Add(lst18);
                ddlInchFractions.Items.Add(lst14);
                ddlInchFractions.Items.Add(lst38);
                ddlInchFractions.Items.Add(lst12);
                ddlInchFractions.Items.Add(lst58);
                ddlInchFractions.Items.Add(lst34);
                ddlInchFractions.Items.Add(lst78);

                ddlLeftInchFractions.Items.Add(lst0);
                ddlLeftInchFractions.Items.Add(lst18);
                ddlLeftInchFractions.Items.Add(lst14);
                ddlLeftInchFractions.Items.Add(lst38);
                ddlLeftInchFractions.Items.Add(lst12);
                ddlLeftInchFractions.Items.Add(lst58);
                ddlLeftInchFractions.Items.Add(lst34);
                ddlLeftInchFractions.Items.Add(lst78);

                ddlRightInchFractions.Items.Add(lst0);
                ddlRightInchFractions.Items.Add(lst18);
                ddlRightInchFractions.Items.Add(lst14);
                ddlRightInchFractions.Items.Add(lst38);
                ddlRightInchFractions.Items.Add(lst12);
                ddlRightInchFractions.Items.Add(lst58);
                ddlRightInchFractions.Items.Add(lst34);
                ddlRightInchFractions.Items.Add(lst78);

                lblWallNumber.Text = "Wall " + i + " : ";
                lblWallNumber.ID = "lblWall" + i + "Length";
                lblWallNumber.AssociatedControlID = "txtWall" + i + "Length";

                txtWallLength.ID = "txtWall" + i + "Length";
                txtWallLength.CssClass = "txtField txtLengthInput";
                txtWallLength.MaxLength = 3;
                txtWallLength.Attributes.Add("onkeyup", "checkQuestion1()");
                txtWallLength.Attributes.Add("OnChange", "checkQuestion1()");
                txtWallLength.Attributes.Add("OnFocus", "highlightWallsLength()");
                txtWallLength.Attributes.Add("onblur", "resetWalls()");

                txtLeftFiller.ID = "txtWall" + i + "LeftFiller";
                txtLeftFiller.CssClass = "txtField txtLengthInput";
                txtLeftFiller.MaxLength = 3;
                txtLeftFiller.Attributes.Add("onkeyup", "checkQuestion1()");
                txtLeftFiller.Attributes.Add("OnChange", "checkQuestion1()");
                txtLeftFiller.Attributes.Add("OnFocus", "highlightWallsLength()");
                txtLeftFiller.Attributes.Add("onblur", "resetWalls()");

                txtRightFiller.ID = "txtWall" + i + "RightFiller";
                txtRightFiller.CssClass = "txtField txtLengthInput";
                txtRightFiller.MaxLength = 3;
                txtRightFiller.Attributes.Add("onkeyup", "checkQuestion1()");
                txtRightFiller.Attributes.Add("OnChange", "checkQuestion1()");
                txtRightFiller.Attributes.Add("OnFocus", "highlightWallsLength()");
                txtRightFiller.Attributes.Add("onblur", "resetWalls()");

                cell1.Controls.Add(lblWallNumber);
                cell2.Controls.Add(txtLeftFiller);
                cell3.Controls.Add(ddlLeftInchFractions);
                cell4.Controls.Add(txtWallLength);
                cell5.Controls.Add(ddlInchFractions);
                cell6.Controls.Add(txtRightFiller);
                cell7.Controls.Add(ddlRightInchFractions);

                tblWallLengths.Rows.Add(row);

                row.Cells.Add(cell1);
                row.Cells.Add(cell2);
                row.Cells.Add(cell3);
                row.Cells.Add(cell4);
                row.Cells.Add(cell5);
                row.Cells.Add(cell6);
                row.Cells.Add(cell7);
            }
            #endregion
        }
            

        protected void txtWallLengths_TextChanged(object sender, EventArgs e)
        { 
            
        }

        /// <summary>
        /// This method creates hidden fields dynamically on page load to store the values of wall lengths to be validated on client side
        /// </summary>
        /// <returns>html hidden field tags</returns>
        protected string createHiddenFields()
        {
            string html = "";

            for (int i = 1; i <= (int)Session["numberOfWalls"]; i++)
            {
                html += "<input id=\"hidWall" + i + "SetBack\" type=\"hidden\" runat=\"server\" />";
                html += "<input id=\"hidWall" + i + "LeftFiller\" type=\"hidden\" runat=\"server\" />";
                html += "<input id=\"hidWall" + i + "Length\" type=\"hidden\" runat=\"server\" />";
                html += "<input id=\"hidWall" + i + "RightFiller\" type=\"hidden\" runat=\"server\" />";
            }
            return html;
        }
    }
}
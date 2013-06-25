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
            typeOfDoorDDL.Items.Add(cabana);
            typeOfDoorDDL.Items.Add(french);
            typeOfDoorDDL.Items.Add(patio);

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
            colorOfDoorDDL.Items.Add(patio);

            colorOfDoorLBL.AssociatedControlID = "ddlDoorColor";

            #endregion

            #region Table:Third Row Door Height (tblDoorDetails)

            TableRow doorHeightRow = new TableRow();
            TableCell doorHeightLBLCell = new TableCell();
            TableCell doorHeightDDLCell = new TableCell();

            Label doorHeightLBL = new Label();
            doorHeightLBL.ID = "lblDoorHeight";
            doorHeightLBL.Text = "Door Height:";

            DropDownList doorHeightDDL = new DropDownList();
            doorHeightDDL.ID = "ddlDoorHeight";
            ListItem fiveFeet = new ListItem("5'", "5");
            ListItem sixFeet = new ListItem("6'", "6");
            ListItem sevenFeet = new ListItem("7'", "7");
            ListItem eightFeet = new ListItem("8'", "8");
            doorHeightDDL.Items.Add(fiveFeet);
            doorHeightDDL.Items.Add(sixFeet);
            doorHeightDDL.Items.Add(sevenFeet);
            doorHeightDDL.Items.Add(eightFeet);

            doorHeightLBL.AssociatedControlID = "ddlDoorHeight";

            #endregion

            #region Table:Fourth Row Door Swing In (tblDoorDetails)

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

            #region Table:Fifth Row Door Swing Out (tblDoorDetails)

            TableRow doorSwingOutRow = new TableRow();
            TableCell doorSwingOutLBLCell = new TableCell();
            TableCell doorSwingOutRADCell = new TableCell();

            Label doorSwingOutLBLRad = new Label();
            doorSwingOutLBLRad.ID = "lblDoorSwingOut";

            Label doorSwingOutLBL = new Label();
            doorSwingOutLBL.ID = "lblDoorSwingOutRad";
            doorSwingOutLBL.Text = "Out";

            RadioButton doorSwingOutRAD = new RadioButton();
            doorSwingOutRAD.ID = "radDoorSwingOut";
            doorSwingOutRAD.GroupName = "SwingInOut";

            doorSwingOutLBLRad.AssociatedControlID = "radDoorSwingOut";
            doorSwingOutLBL.AssociatedControlID = "radDoorSwingOut";

            #endregion


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

            #region Table:Fourth Row Swing In Added To Table (tblDoorDetails)

            doorSwingInLBLCell.Controls.Add(doorSwingInLBLMain);

            doorSwingInRADCell.Controls.Add(doorSwingInRAD);
            doorSwingInRADCell.Controls.Add(doorSwingInLBLRad);
            doorSwingInRADCell.Controls.Add(doorSwingInLBL);

            tblDoorDetails.Rows.Add(doorSwingInRow);

            doorSwingInRow.Cells.Add(doorSwingInLBLCell);
            doorSwingInRow.Cells.Add(doorSwingInRADCell);

            #endregion

            #region Table:Fifth Row Swing Out Added To Table (tblDoorDetails)

            doorSwingOutRADCell.Controls.Add(doorSwingOutRAD);
            doorSwingOutRADCell.Controls.Add(doorSwingOutLBLRad);
            doorSwingOutRADCell.Controls.Add(doorSwingOutLBL);

            tblDoorDetails.Rows.Add(doorSwingOutRow);

            doorSwingOutRow.Cells.Add(doorSwingOutLBLCell);
            doorSwingOutRow.Cells.Add(doorSwingOutRADCell);

            #endregion

            wallDoorOptions.Controls.Add(tblDoorDetails);

            wallDoorOptions.Controls.Add(new LiteralControl("</li></ul></div>"));

            #endregion

            //DropDownList used in tables loaded to page
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

            #region For Loop for slide 1 and slide3
            //Used to dynamically add values to ddlWallDoorPlacement
            for (int i = 1; i <= (int)Session["numberOfWalls"]; i++)
            {
                ListItem numberOfWalls = new ListItem(Convert.ToString(i), Convert.ToString(i));
                //ddlWallDoorPlacement.Items.Add(numberOfWalls);
            }

            for (int i = 1; i <= (int)Session["numberOfWalls"]; i++) //numberOfWalls is hard-coded to be 5 right now
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
                cell2.Controls.Add(txtWallLength);
                cell3.Controls.Add(ddlInchFractions);
                cell4.Controls.Add(txtLeftFiller);
                cell5.Controls.Add(ddlLeftInchFractions);
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
                html += "<input id=\"hidWall" + i + "Length\" type=\"hidden\" runat=\"server\" />";
            }
            return html;
        }
    }
}
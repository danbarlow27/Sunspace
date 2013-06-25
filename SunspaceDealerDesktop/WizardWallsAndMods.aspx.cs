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
            
            DropDownList ddlInFrac = new DropDownList();
            ddlInFrac.ID = "inFrac";
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
            inchesSpecifics.Controls.Add(ddlInFrac);

            //Used to dynamically add values to ddlWallDoorPlacement
            for (int i = 1; i <= (int)Session["numberOfWalls"]; i++)
            {
                ListItem numberOfWalls = new ListItem(Convert.ToString(i), Convert.ToString(i));
                ddlWallDoorPlacement.Items.Add(numberOfWalls);
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

                TableCell cellLabelLeftFiller = new TableCell();
                TableCell cellTextBoxLeftFiller = new TableCell();
                TableCell cellDropDownLeftFiller = new TableCell();

                TableCell cellLabelRightFiller = new TableCell();
                TableCell cellTextBoxRightFiller = new TableCell();
                TableCell cellDropDownRightFiller = new TableCell();

                Label lblWallNumber = new Label();
                //Label lblLeftFiller = new Label();
                //Label lblRightFiller = new Label();

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

                //lblLeftFiller.Text = "Left " + i + " Filler Length: ";
                //lblLeftFiller.ID = "lblWall" + i + "LeftFiller";
                //lblLeftFiller.AssociatedControlID = "txtWall" + i + "LeftFiller";

                //lblRightFiller.Text = "Right " + i + " Filler Length: ";
                //lblRightFiller.ID = "lblWall" + i + "RightFiller";
                //lblRightFiller.AssociatedControlID = "txtWall" + i + "RightFiller";

                txtWallLength.ID = "txtWall" + i + "Length";
                txtWallLength.CssClass = "txtField txtLengthInput";
                txtWallLength.MaxLength = 3;
                txtWallLength.Attributes.Add("onkeyup", "checkQuestion1()");
                txtWallLength.Attributes.Add("OnChange", "checkQuestion1()");
                txtWallLength.Attributes.Add("OnFocus", "highlightWall()");

                txtLeftFiller.ID = "txtWall" + i + "LeftFiller";
                txtLeftFiller.CssClass = "txtField txtLengthInput";
                txtLeftFiller.MaxLength = 3;
                txtLeftFiller.Attributes.Add("onkeyup", "checkQuestion1()");
                txtLeftFiller.Attributes.Add("OnChange", "checkQuestion1()");
                txtLeftFiller.Attributes.Add("OnFocus", "highlightWall()");

                txtRightFiller.ID = "txtWall" + i + "RightFiller";
                txtRightFiller.CssClass = "txtField txtLengthInput";
                txtRightFiller.MaxLength = 3;
                txtRightFiller.Attributes.Add("onkeyup", "checkQuestion1()");
                txtRightFiller.Attributes.Add("OnChange", "checkQuestion1()");
                txtRightFiller.Attributes.Add("OnFocus", "highlightWall()");

                cell1.Controls.Add(lblWallNumber);
                cell2.Controls.Add(txtWallLength);
                cell3.Controls.Add(ddlInchFractions);
                cell4.Controls.Add(txtLeftFiller);
                cell5.Controls.Add(ddlLeftInchFractions);
                cell6.Controls.Add(txtRightFiller);
                cell7.Controls.Add(ddlRightInchFractions);

                //cellLabelLeftFiller.Controls.Add(lblLeftFiller);
                //cellTextBoxLeftFiller.Controls.Add(txtLeftFiller);
                //cellDropDownLeftFiller.Controls.Add(ddlLeftInchFractions);

                //cellLabelRightFiller.Controls.Add(lblRightFiller);
                //cellTextBoxRightFiller.Controls.Add(txtRightFiller);
                //cellDropDownRightFiller.Controls.Add(ddlRightInchFractions);

                tblWallLengths.Rows.Add(row);
                //tblWallLengths.Rows.Add(rowLeftFiller);
                //tblWallLengths.Rows.Add(rowRightFiller);

                row.Cells.Add(cell1);
                row.Cells.Add(cell2);
                row.Cells.Add(cell3);
                row.Cells.Add(cell4);
                row.Cells.Add(cell5);
                row.Cells.Add(cell6);
                row.Cells.Add(cell7);

                //rowLeftFiller.Cells.Add(cellLabelLeftFiller);
                //rowLeftFiller.Cells.Add(cellTextBoxLeftFiller);
                //rowLeftFiller.Cells.Add(cellDropDownLeftFiller);

                //rowRightFiller.Cells.Add(cellLabelRightFiller);
                //rowRightFiller.Cells.Add(cellTextBoxRightFiller);
                //rowRightFiller.Cells.Add(cellDropDownRightFiller);
            }
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
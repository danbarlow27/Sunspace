using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
namespace SunspaceDealerDesktop
{
    public partial class WizardDoorOnlyEdit : System.Web.UI.Page
    {
        protected int projectId = 108; //get it from the session
        protected string json;
        protected ListItem lst0 = new ListItem("---", "0", true); //0, i.e. no decimal value, selected by default
        protected ListItem lst18 = new ListItem("1/8", ".125");
        protected ListItem lst14 = new ListItem("1/4", ".25");
        protected ListItem lst38 = new ListItem("3/8", ".375");//
        protected ListItem lst12 = new ListItem("1/2", ".5");
        protected ListItem lst58 = new ListItem("5/8", ".625");
        protected ListItem lst34 = new ListItem("3/4", ".75");
        protected ListItem lst78 = new ListItem("7/8", ".875");
        List<Door> doorsOrdered = new List<Door>();

        #region Validation constants

        protected int CUSTOM_DOOR_MIN_WIDTH = Constants.CUSTOM_DOOR_MIN_WIDTH;
        protected int CUSTOM_DOOR_MAX_WIDTH = Constants.CUSTOM_DOOR_MAX_WIDTH;
        protected int CUSTOM_DOOR_MIN_HEIGHT = Constants.CUSTOM_DOOR_MIN_HEIGHT;
        protected int CUSTOM_DOOR_MAX_HEIGHT = Constants.CUSTOM_DOOR_MAX_HEIGHT;

        #endregion

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

                #region Door Height

                TableRow doorHeightRow = new TableRow();
                doorHeightRow.ID = "rowDoorHeight" + title;
                //doorHeightRow.Attributes.Add("style", "display:none;");
                TableCell doorHeightLBLCell = new TableCell();
                TableCell doorHeightTXTCell = new TableCell();
                TableCell doorHeightDDLCell = new TableCell();

                Label doorHeightLBL = new Label();
                doorHeightLBL.ID = "lblDoorHeight" + title;
                doorHeightLBL.Text = "Height:";

                TextBox doorHeightTXT = new TextBox();
                doorHeightTXT.ID = "txtDoorHeight" + title;
                doorHeightTXT.CssClass = "txtField txtDoorInput";
                doorHeightTXT.Attributes.Add("maxlength", "3");
                doorHeightTXT.Attributes.Add("onkeydown", "return (event.keyCode!=13);");
                doorHeightTXT.Attributes.Add("onblur", "recalculate('" + title + "');");

                DropDownList inchHeight = new DropDownList();
                inchHeight.ID = "ddlDoorHeight" + title;
                inchHeight.Attributes.Add("onchange", "recalculate('" + title + "');");
                inchHeight.Items.Add(lst0);
                inchHeight.Items.Add(lst18);
                inchHeight.Items.Add(lst14);
                inchHeight.Items.Add(lst38);
                inchHeight.Items.Add(lst12);
                inchHeight.Items.Add(lst58);
                inchHeight.Items.Add(lst34);
                inchHeight.Items.Add(lst78);

                doorHeightLBL.AssociatedControlID = "txtDoorHeight" + title;

                #endregion

                #region "As-if" Height

                TableRow doorAsIfHeightRow = new TableRow();
                doorAsIfHeightRow.ID = "rowDoorAsIfHeight" + title;
                doorAsIfHeightRow.Attributes.Add("style", "display:none;");
                TableCell doorAsIfHeightLBLCell = new TableCell();
                TableCell doorAsIfHeightTXTCell = new TableCell();
                TableCell doorAsIfHeightDDLCell = new TableCell();

                Label doorAsIfHeightLBL = new Label();
                doorAsIfHeightLBL.ID = "lblDoorAsIfHeight" + title;
                doorAsIfHeightLBL.Text = "Build As If:";

                TextBox doorAsIfHeightTXT = new TextBox();
                doorAsIfHeightTXT.ID = "txtDoorAsIfHeight" + title;
                doorAsIfHeightTXT.CssClass = "txtField txtDoorInput";
                doorAsIfHeightTXT.Attributes.Add("maxlength", "3");
                doorAsIfHeightTXT.Attributes.Add("onkeydown", "return (event.keyCode!=13);");
                doorAsIfHeightTXT.Attributes.Add("onblur", "recalculate('" + title + "');");

                DropDownList inchAsIfHeight = new DropDownList();
                inchAsIfHeight.ID = "ddlDoorAsIfHeight" + title;
                inchAsIfHeight.Attributes.Add("onchange", "recalculate('" + title + "');");
                inchAsIfHeight.Items.Add(lst0);
                inchAsIfHeight.Items.Add(lst18);
                inchAsIfHeight.Items.Add(lst14);
                inchAsIfHeight.Items.Add(lst38);
                inchAsIfHeight.Items.Add(lst12);
                inchAsIfHeight.Items.Add(lst58);
                inchAsIfHeight.Items.Add(lst34);
                inchAsIfHeight.Items.Add(lst78);

                doorAsIfHeightLBL.AssociatedControlID = "txtDoorAsIfHeight" + title;

                #endregion

                #region Door Width

                TableRow doorWidthRow = new TableRow();
                doorWidthRow.ID = "rowDoorWidth" + title;
                //doorWidthRow.Attributes.Add("style", "display:none;");
                TableCell doorWidthLBLCell = new TableCell();
                TableCell doorWidthTXTCell = new TableCell();
                TableCell doorWidthDDLCell = new TableCell();

                Label doorWidthLBL = new Label();
                doorWidthLBL.ID = "lblDoorWidth" + title;
                doorWidthLBL.Text = "Width:";

                TextBox doorWidthTXT = new TextBox();
                doorWidthTXT.ID = "txtDoorWidth" + title;
                doorWidthTXT.CssClass = "txtField txtDoorInput";
                doorWidthTXT.Attributes.Add("maxlength", "3");
                doorWidthTXT.Attributes.Add("onkeydown", "return (event.keyCode!=13);");
                doorWidthTXT.Attributes.Add("onblur", "recalculate('" + title + "');");

                DropDownList inchWidth = new DropDownList();
                inchWidth.ID = "ddlDoorWidth" + title;
                inchWidth.Attributes.Add("onchange", "recalculate('" + title + "');");
                inchWidth.Items.Add(lst0);
                inchWidth.Items.Add(lst18);
                inchWidth.Items.Add(lst14);
                inchWidth.Items.Add(lst38);
                inchWidth.Items.Add(lst12);
                inchWidth.Items.Add(lst58);
                inchWidth.Items.Add(lst34);
                inchWidth.Items.Add(lst78);

                doorWidthLBL.AssociatedControlID = "txtDoorWidth" + title;

                #endregion

                #region V4T Number Of Vents

                TableRow doorV4TNumberOfVentsRow = new TableRow();
                doorV4TNumberOfVentsRow.ID = "rowDoorV4TNumberOfVents" + title;
                doorV4TNumberOfVentsRow.Attributes.Add("style", "display:inherit");
                //doorV4TNumberOfVentsRow.Attributes.Add("style", "display:none;");
                TableCell doorV4TNumberOfVentsLBLCell = new TableCell();
                TableCell doorV4TNumberOfVentsDDLCell = new TableCell();

                Label doorV4TNumberOfVentsLBL = new Label();
                doorV4TNumberOfVentsLBL.ID = "lblV4TNumberOfVents" + title;
                doorV4TNumberOfVentsLBL.Text = "Number Of Vents:";

                DropDownList doorV4TNumberOfVentsDDL = new DropDownList();
                doorV4TNumberOfVentsDDL.ID = "ddlDoorV4TNumberOfVents" + title;
                doorV4TNumberOfVentsDDL.Attributes.Add("onchange", "tintOptionsChanged('" + title + "'); displayMixedTint('" + title + "');");
                for (int j = 0; j < Constants.DOOR_NUMBER_OF_VENTS.Count(); j++)
                {
                    doorV4TNumberOfVentsDDL.Items.Add(new ListItem(Constants.DOOR_NUMBER_OF_VENTS[j], Constants.DOOR_NUMBER_OF_VENTS[j]));
                }

                doorV4TNumberOfVentsLBL.AssociatedControlID = "ddlDoorV4TNumberOfVents" + title;

                #region Uneven Vents Checkbox

                TableCell doorUnevenVentsCHKCell = new TableCell();
                //doorUnevenVentsCHKCell.Attributes.Add("style", "display:none;");
                doorUnevenVentsCHKCell.ID = "cellDoorUnevenVents" + title;

                Label doorUnevenVentsLBLChk = new Label();
                doorUnevenVentsLBLChk.ID = "lblDoorUnevenVents" + title;

                Label doorUnevenVentsLBL = new Label();
                doorUnevenVentsLBL.ID = "lblDoorUnevenVentsRad" + title;
                doorUnevenVentsLBL.Text = " Uneven Vents";

                CheckBox doorUnevenVentsCHK = new CheckBox();
                doorUnevenVentsCHK.ID = "chkDoorUnevenVents" + title;
                doorUnevenVentsCHK.Attributes.Add("value", "UnevenVents");
                doorUnevenVentsCHK.Attributes.Add("onclick", "unevenVentsChecked(this.checked,'" + title + "');");

                doorUnevenVentsLBLChk.AssociatedControlID = "chkDoorUnevenVents" + title;
                doorUnevenVentsLBL.AssociatedControlID = "chkDoorUnevenVents" + title;

                #endregion

                #endregion

                #region Uneven Vents Top Bottom Both Rads

                TableRow doorTopBottomBothRadRow = new TableRow();
                doorTopBottomBothRadRow.ID = "rowDoorTopBottomBothRad" + title;
                doorTopBottomBothRadRow.Attributes.Add("style", "display:none;");

                #region Top

                TableCell doorTopRadCell = new TableCell();

                Label doorTopRadLBLRad = new Label();
                doorTopRadLBLRad.ID = "lblDoorTopRad" + title;

                Label doorTopRadLBL = new Label();
                doorTopRadLBL.ID = "lblDoorTopRadRad" + title;
                doorTopRadLBL.Text = "Top";

                RadioButton doorTopRadRAD = new RadioButton();
                doorTopRadRAD.ID = "radDoorTopRad" + title;
                doorTopRadRAD.Attributes.Add("value", "top");
                doorTopRadRAD.GroupName = "Uneven" + title;
                doorTopRadRAD.Attributes.Add("onclick", "topOrBottomUnevenClicked('" + title + "');");

                doorTopRadLBLRad.AssociatedControlID = "radDoorTopRad" + title;
                doorTopRadLBL.AssociatedControlID = "radDoorTopRad" + title;

                doorTopRadCell.Controls.Add(doorTopRadRAD);
                doorTopRadCell.Controls.Add(doorTopRadLBLRad);
                doorTopRadCell.Controls.Add(doorTopRadLBL);

                #endregion

                #region Bottom

                TableCell doorBottomRadCell = new TableCell();

                Label doorBottomRadLBLRad = new Label();
                doorBottomRadLBLRad.ID = "lblDoorBottomRad" + title;

                Label doorBottomRadLBL = new Label();
                doorBottomRadLBL.ID = "lblDoorBottomRadRad" + title;
                doorBottomRadLBL.Text = "Bottom";

                RadioButton doorBottomRadRAD = new RadioButton();
                doorBottomRadRAD.ID = "radDoorBottomRad" + title;
                doorBottomRadRAD.Attributes.Add("value", "bottom");
                doorBottomRadRAD.GroupName = "Uneven" + title;
                doorBottomRadRAD.Attributes.Add("onclick", "('" + title + "');");
                doorBottomRadRAD.Checked = true;

                doorBottomRadLBLRad.AssociatedControlID = "radDoorBottomRad" + title;
                doorBottomRadLBL.AssociatedControlID = "radDoorBottomRad" + title;

                doorBottomRadCell.Controls.Add(doorBottomRadRAD);
                doorBottomRadCell.Controls.Add(doorBottomRadLBLRad);
                doorBottomRadCell.Controls.Add(doorBottomRadLBL);

                #endregion

                #region Both

                TableCell doorBothRadCell = new TableCell();

                Label doorBothRadLBLRad = new Label();
                doorBothRadLBLRad.ID = "lblDoorBothRad" + title;

                Label doorBothRadLBL = new Label();
                doorBothRadLBL.ID = "lblDoorBothRadRad" + title;
                doorBothRadLBL.Text = "Both";

                RadioButton doorBothRadRAD = new RadioButton();
                doorBothRadRAD.ID = "radDoorBothRad" + title;
                doorBothRadRAD.Attributes.Add("value", "both");
                doorBothRadRAD.GroupName = "Uneven" + title;
                doorBothRadRAD.Attributes.Add("onclick", "bothUnevenClicked('" + title + "')");

                doorBothRadLBLRad.AssociatedControlID = "radDoorBothRad" + title;
                doorBothRadLBL.AssociatedControlID = "radDoorBothRad" + title;

                doorBothRadCell.Controls.Add(doorBothRadRAD);
                doorBothRadCell.Controls.Add(doorBothRadLBLRad);
                doorBothRadCell.Controls.Add(doorBothRadLBL);

                #endregion

                #endregion

                #region Uneven Vents Textboxes

                #region Top

                TableRow doorUnevenVentsRowTop = new TableRow();
                doorUnevenVentsRowTop.ID = "rowDoorUnevenVentsTop" + title;
                doorUnevenVentsRowTop.Attributes.Add("style", "display:none;");

                TableCell doorTopVentLBLCell = new TableCell();
                TableCell doorTopVentTXTCell = new TableCell();
                //TableCell doorTopVentDDLCell = new TableCell();

                Label doorTopVentLBL = new Label();
                doorTopVentLBL.ID = "lblDoorTopVentHeight" + title;
                doorTopVentLBL.Text = "Top Vent Height:";

                TextBox doorTopVentTXT = new TextBox();
                doorTopVentTXT.ID = "txtDoorTopVentHeight" + title;
                doorTopVentTXT.CssClass = "txtField txtDoorInput";
                doorTopVentTXT.Attributes.Add("maxlength", "3");
                doorTopVentTXT.Attributes.Add("onkeydown", "return (event.keyCode!=13);");
                doorTopVentTXT.Attributes.Add("onblur", "adjustVentHeights(this.value, 'top');");

                doorTopVentLBL.AssociatedControlID = "txtDoorTopVentHeight" + title;

                doorTopVentLBLCell.Controls.Add(doorTopVentLBL);
                doorTopVentTXTCell.Controls.Add(doorTopVentTXT);

                #endregion

                #region Bottom

                TableRow doorUnevenVentsRowBottom = new TableRow();
                doorUnevenVentsRowBottom.ID = "rowDoorUnevenVentsBottom" + title;
                doorUnevenVentsRowBottom.Attributes.Add("style", "display:none;");

                TableCell doorBottomVentLBLCell = new TableCell();
                TableCell doorBottomVentTXTCell = new TableCell();
                //TableCell doorBottomVentDDLCell = new TableCell();

                Label doorBottomVentLBL = new Label();
                doorBottomVentLBL.ID = "lblDoorBottomVentHeight" + title;
                doorBottomVentLBL.Text = "Bottom Vent Height:";

                TextBox doorBottomVentTXT = new TextBox();
                doorBottomVentTXT.ID = "txtDoorBottomVentHeight" + title;
                doorBottomVentTXT.CssClass = "txtField txtDoorInput";
                doorBottomVentTXT.Attributes.Add("maxlength", "3");
                doorBottomVentTXT.Attributes.Add("onkeydown", "return (event.keyCode!=13);");
                doorBottomVentTXT.Attributes.Add("onblur", "adjustVentHeights(this.value, 'bottom');");

                //DropDownList inchBottomVentDDL = new DropDownList();
                //inchBottomVentDDL.ID = "ddlDoorBottomVentHeight" + title;
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

                doorBottomVentLBL.AssociatedControlID = "txtDoorBottomVentHeight" + title;

                doorBottomVentLBLCell.Controls.Add(doorBottomVentLBL);
                doorBottomVentTXTCell.Controls.Add(doorBottomVentTXT);
                //doorBottomVentDDLCell.Controls.Add(inchBottomVentDDL);



                #endregion

                #endregion

                #region Commented V4T
                /*                

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
                */
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

                #region Commented Height/Width
                /*
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
                */
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

                #region Comment V4T Stuff
                /*
                #region Table:Twelfth Row Door V4T Number Of Vents Added To Table (tblDoorDetails)

                doorNumberOfVentsLBLCell.Controls.Add(doorNumberOfVentsLBL);
                doorNumberOfVentsDDLCell.Controls.Add(doorNumberOfVentsDDL);

                tblDoorDetails.Rows.Add(doorNumberOfVentsRow);

                doorNumberOfVentsRow.Cells.Add(doorNumberOfVentsLBLCell);
                doorNumberOfVentsRow.Cells.Add(doorNumberOfVentsDDLCell);

                #endregion

                
                */
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

                #region Table:Height

                doorHeightLBLCell.Controls.Add(doorHeightLBL);
                doorHeightTXTCell.Controls.Add(doorHeightTXT);
                doorHeightDDLCell.Controls.Add(inchHeight);

                tblDoorDetails.Rows.Add(doorHeightRow);

                doorHeightRow.Cells.Add(doorHeightLBLCell);
                doorHeightRow.Cells.Add(doorHeightTXTCell);
                doorHeightRow.Cells.Add(doorHeightDDLCell);

                #endregion

                #region Table:Height AsIf

                doorAsIfHeightLBLCell.Controls.Add(doorAsIfHeightLBL);
                doorAsIfHeightTXTCell.Controls.Add(doorAsIfHeightTXT);
                doorAsIfHeightDDLCell.Controls.Add(inchAsIfHeight);

                tblDoorDetails.Rows.Add(doorAsIfHeightRow);

                doorAsIfHeightRow.Cells.Add(doorAsIfHeightLBLCell);
                doorAsIfHeightRow.Cells.Add(doorAsIfHeightTXTCell);
                doorAsIfHeightRow.Cells.Add(doorAsIfHeightDDLCell);

                #endregion

                #region Table:Width

                doorWidthLBLCell.Controls.Add(doorWidthLBL);
                doorWidthTXTCell.Controls.Add(doorWidthTXT);
                doorWidthDDLCell.Controls.Add(inchWidth);

                tblDoorDetails.Rows.Add(doorWidthRow);

                doorWidthRow.Cells.Add(doorWidthLBLCell);
                doorWidthRow.Cells.Add(doorWidthTXTCell);
                doorWidthRow.Cells.Add(doorWidthDDLCell);

                #endregion

                #region Table:V4T Number of Vents

                doorV4TNumberOfVentsLBLCell.Controls.Add(doorV4TNumberOfVentsLBL);
                doorV4TNumberOfVentsDDLCell.Controls.Add(doorV4TNumberOfVentsDDL);

                doorV4TNumberOfVentsRow.Cells.Add(doorV4TNumberOfVentsLBLCell);
                doorV4TNumberOfVentsRow.Cells.Add(doorV4TNumberOfVentsDDLCell);

                doorUnevenVentsCHKCell.Controls.Add(doorUnevenVentsCHK);
                doorUnevenVentsCHKCell.Controls.Add(doorUnevenVentsLBLChk);
                doorUnevenVentsCHKCell.Controls.Add(doorUnevenVentsLBL);

                doorV4TNumberOfVentsRow.Cells.Add(doorUnevenVentsCHKCell);

                tblDoorDetails.Rows.Add(doorV4TNumberOfVentsRow);

                #endregion

                #region Table:Uneven vents

                tblDoorDetails.Rows.Add(doorTopBottomBothRadRow);

                doorTopBottomBothRadRow.Cells.Add(doorTopRadCell);
                doorTopBottomBothRadRow.Cells.Add(doorBottomRadCell);
                doorTopBottomBothRadRow.Cells.Add(doorBothRadCell);

                doorUnevenVentsRowTop.Cells.Add(doorTopVentLBLCell);
                doorUnevenVentsRowTop.Cells.Add(doorTopVentTXTCell);

                tblDoorDetails.Rows.Add(doorUnevenVentsRowTop);

                doorUnevenVentsRowBottom.Cells.Add(doorBottomVentLBLCell);
                doorUnevenVentsRowBottom.Cells.Add(doorBottomVentTXTCell);
                //doorUnevenVentsRowBottom.Cells.Add(doorBottomVentDDLCell);

                tblDoorDetails.Rows.Add(doorUnevenVentsRowBottom);

                #endregion

                #region Commented Dimension Stuff
                /*
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
                 */
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

            populateSideBar(findNumberOfDoorTypes());

            using (SqlConnection aConnection = new SqlConnection(sdsDBConnection.ConnectionString))
            {

                aConnection.Open();
                SqlCommand aCommand = aConnection.CreateCommand();
                SqlTransaction aTransaction;
                //SqlDataReader aReader;

                // Start a local transaction.
                aTransaction = aConnection.BeginTransaction("SampleTransaction");

                // Must assign both transaction object and connection 
                // to Command object for a pending local transaction
                aCommand.Connection = aConnection;
                aCommand.Transaction = aTransaction;
                
                // Door variables
                string doorType;
                string doorStyle;
                string screenType;
                float height;
                float length;
                string doorColour;
                float kickPlate;

                // Specific Doors
                string vinylTint;
                string glassTint;
                string hinge;
                string swing;
                bool operatorBool;
                string hardwareType;
                bool movingDoor;

                try
                {
                    //get number of walls floors and roofs
                    aCommand.CommandText = "SELECT door_type, door_style, screen_type, height, length, door_colour, kick_plate FROM doors WHERE project_id = '" + projectId + "'";
                    SqlDataReader projectReader = aCommand.ExecuteReader();

                    // If the door is found
                    if (projectReader.HasRows)
                    {
                        projectReader.Read();

                        // Populate the door fields
                        doorType = Convert.ToString(projectReader[0]);
                        doorStyle = Convert.ToString(projectReader[1]);
                        screenType = Convert.ToString(projectReader[2]);
                        height = Convert.ToSingle(projectReader[3]);
                        length = Convert.ToSingle(projectReader[4]);
                        doorColour = Convert.ToString(projectReader[5]);
                        kickPlate = Convert.ToSingle(projectReader[6]);

                        projectReader.Close(); 

                        // Populate cabana fields
                        if (doorType == "Cabana")
                        {
                            aCommand.CommandText = "SELECT vinyl_tint, glass_tint, hinge, swing, hardware_type FROM cabana_doors WHERE project_id = '" + projectId + "' AND linear_index = 0 AND module_index = 0";
                            projectReader = aCommand.ExecuteReader();

                            // If the cabana door is found
                            if (projectReader.HasRows)
                            {
                                projectReader.Read();

                                // Create a cabana door for JSON
                                CabanaDoor tempDoor = new CabanaDoor();
                                tempDoor.DoorType = doorType;
                                tempDoor.DoorStyle = doorStyle;
                                tempDoor.ScreenType = screenType;
                                tempDoor.Height = height;
                                tempDoor.Length = length;
                                tempDoor.Colour = doorColour;
                                tempDoor.Kickplate = kickPlate;
                                tempDoor.VinylTint = Convert.ToString(projectReader[0]);
                                tempDoor.GlassTint = Convert.ToString(projectReader[1]);
                                tempDoor.Hinge = Convert.ToString(projectReader[2]);
                                tempDoor.Swing = Convert.ToString(projectReader[3]);
                                tempDoor.HardwareType = Convert.ToString(projectReader[4]);
                                // Create a JSON serialize object
                                json = JsonConvert.SerializeObject(tempDoor);
                                // Store the door in a hidden filed
                                hidRealHidden.Value = json;

                                projectReader.Close(); 
                                
                                //// Populate the door table fields
                                //DropDownList ddlDoorType = this.FindControl("ctl00$MainContent$ddlDoorStyleCabana") as DropDownList;
                                //ddlDoorType.SelectedValue = doorType;
                                //DropDownList ddlDoorStyle = this.FindControl("ctl00$MainContent$ddlDoorStyleCabana") as DropDownList;
                                //ddlDoorStyle.SelectedValue = doorStyle;
                                //DropDownList ddlScreenType = this.FindControl("ctl00$MainContent$ddlDoorScreenTypesCabana") as DropDownList;
                                //ddlScreenType.SelectedValue = screenType;
                                //TextBox txtHeight = this.FindControl("ctl00$MainContent$txtDoorHeightCabana") as TextBox;
                                //txtHeight.Text = Convert.ToString(height);
                                //TextBox txtLength = this.FindControl("ctl00$MainContent$txtDoorWidthCabana") as TextBox;
                                //txtLength.Text = Convert.ToString(length);
                                //DropDownList ddlDoorColour = this.FindControl("ctl00$MainContent$ddlDoorColourCabana") as DropDownList;
                                //ddlScreenType.SelectedValue = doorColour;
                                //DropDownList ddlKickPlate = this.FindControl("ctl00$MainContent$ddlDoorKickplateCabana") as DropDownList;
                                //ddlKickPlate.SelectedValue = Convert.ToString(kickPlate) + '"';
                                //// Populate the cabana door specified fields
                                //DropDownList ddlVinylTint = this.FindControl("ctl00$MainContent$ddlDoorVinylTintCabana") as DropDownList;
                                ////ddlVinylTint.SelectedValue = vinylTint;
                                //DropDownList ddlGlassTint = this.FindControl("ctl00$MainContent$ddlDoorGlassTintCabana") as DropDownList;
                                ////ddlGlassTint.SelectedValue = glassTint;
                                //DropDownList ddlHardwareType = this.FindControl("ctl00$MainContent$ddlDoorHardwareCabana") as DropDownList;
                                ////ddlHardwareType.SelectedValue = hardwareType;

                                //// Getting null from radio buttons / radio button list
                                //RadioButton radHinge = this.FindControl("ctl00$MainContent$DoorHingeCabana") as RadioButton;                              
                                
                            }
                        }
                        // Populate french fields
                        else if (doorType == "French")
                        {
                            aCommand.CommandText = "SELECT vinyl_tint, glass_tint, swing, operator, hardware_type FROM french_doors WHERE project_id = '" + projectId + "' AND linear_index = 0 AND module_index = 0";
                            projectReader = aCommand.ExecuteReader();

                            if (projectReader.HasRows)
                            {
                                projectReader.Read();

                                // Create a cabana door for JSON
                                FrenchDoor tempDoor = new FrenchDoor();
                                tempDoor.DoorType = doorType;
                                tempDoor.DoorStyle = doorStyle;
                                tempDoor.ScreenType = screenType;
                                tempDoor.Height = height;
                                tempDoor.Length = length;
                                tempDoor.Colour = doorColour;
                                tempDoor.Kickplate = kickPlate;
                                tempDoor.VinylTint = Convert.ToString(projectReader[0]);
                                tempDoor.GlassTint = Convert.ToString(projectReader[1]);
                                tempDoor.Swing = Convert.ToString(projectReader[2]);
                                tempDoor.OperatingDoor = Convert.ToString(projectReader[3]);
                                tempDoor.HardwareType = Convert.ToString(projectReader[4]);
                                // Create a JSON serialize object
                                json = JsonConvert.SerializeObject(tempDoor);
                                // Store the door in a hidden filed
                                hidRealHidden.Value = json;

                                projectReader.Close();

                                //// Populate the door table fields
                                //DropDownList ddlDoorType = this.FindControl("ctl00$MainContent$ddlDoorStyleFrench") as DropDownList;
                                //ddlDoorType.SelectedValue = doorType;
                                //DropDownList ddlDoorStyle = this.FindControl("ctl00$MainContent$ddlDoorStyleFrench") as DropDownList;
                                //ddlDoorStyle.SelectedValue = doorStyle;
                                //DropDownList ddlScreenType = this.FindControl("ctl00$MainContent$ddlDoorScreenTypesFrench") as DropDownList;
                                //ddlScreenType.SelectedValue = screenType;
                                //TextBox txtHeight = this.FindControl("ctl00$MainContent$txtDoorHeightFrench") as TextBox;
                                //txtHeight.Text = Convert.ToString(height);
                                //TextBox txtLength = this.FindControl("ctl00$MainContent$txtDoorWidthFrench") as TextBox;
                                //txtLength.Text = Convert.ToString(length);
                                //DropDownList ddlDoorColour = this.FindControl("ctl00$MainContent$ddlDoorColourFrench") as DropDownList;
                                //ddlScreenType.SelectedValue = doorColour;
                                //DropDownList ddlKickPlate = this.FindControl("ctl00$MainContent$ddlDoorKickplateFrench") as DropDownList;
                                //ddlKickPlate.SelectedValue = Convert.ToString(kickPlate) + '"';

                                //// Populate the french door fields
                                //DropDownList ddlVinylTint = this.FindControl("ctl00$MainContent$ddlDoorVinylTintFrench") as DropDownList;
                                //ddlVinylTint.SelectedValue = vinylTint;
                                //DropDownList ddlGlassTint = this.FindControl("ctl00$MainContent$ddlDoorGlassTintFrench") as DropDownList;
                                //ddlGlassTint.SelectedValue = glassTint;
                                //DropDownList ddlHardwareType = this.FindControl("ctl00$MainContent$ddlDoorHardwareFrench") as DropDownList;
                                //ddlHardwareType.SelectedValue = hardwareType;
                            }
                        }
                        // Populate patio doors
                        else
                        {
                            aCommand.CommandText = "SELECT glass_tint, moving_door FROM patio_doors WHERE project_id = '" + projectId + "' AND linear_index = 0 AND module_index = 0";
                            projectReader = aCommand.ExecuteReader();

                            if (projectReader.HasRows)
                            {
                                projectReader.Read();

                                // Create a cabana door for JSON
                                PatioDoor tempDoor = new PatioDoor();
                                tempDoor.DoorType = doorType;
                                tempDoor.DoorStyle = doorStyle;
                                tempDoor.ScreenType = screenType;
                                tempDoor.Height = height;
                                tempDoor.Length = length;
                                tempDoor.Colour = doorColour;
                                tempDoor.Kickplate = kickPlate;
                                tempDoor.GlassTint = Convert.ToString(projectReader[0]);
                                tempDoor.MovingDoor = Convert.ToString(projectReader[1]);
                                // Create a JSON serialize object
                                json = JsonConvert.SerializeObject(tempDoor);
                                // Store the door in a hidden filed
                                hidRealHidden.Value = json;

                                projectReader.Close();

                                //// Populate the door table fields
                                //DropDownList ddlDoorType = this.FindControl("ctl00$MainContent$ddlDoorStylePatio") as DropDownList;
                                //ddlDoorType.SelectedValue = doorType;
                                //DropDownList ddlDoorStyle = this.FindControl("ctl00$MainContent$ddlDoorStylePatio") as DropDownList;
                                //ddlDoorStyle.SelectedValue = doorStyle;
                                //DropDownList ddlScreenType = this.FindControl("ctl00$MainContent$ddlDoorScreenTypesPatio") as DropDownList;
                                //ddlScreenType.SelectedValue = screenType;
                                //TextBox txtHeight = this.FindControl("ctl00$MainContent$txtDoorHeightPatio") as TextBox;
                                //txtHeight.Text = Convert.ToString(height);
                                //TextBox txtLength = this.FindControl("ctl00$MainContent$txtDoorWidthPatio") as TextBox;
                                //txtLength.Text = Convert.ToString(length);
                                //DropDownList ddlDoorColour = this.FindControl("ctl00$MainContent$ddlDoorColourPatio") as DropDownList;
                                //ddlScreenType.SelectedValue = doorColour;
                                //DropDownList ddlKickPlate = this.FindControl("ctl00$MainContent$ddlDoorKickplatePatio") as DropDownList;
                                //ddlKickPlate.SelectedValue = Convert.ToString(kickPlate) + '"';

                                //// Populate the french door fields
                                //DropDownList ddlGlassTint = this.FindControl("ctl00$MainContent$ddlDoorGlassTintPatio") as DropDownList;
                                //ddlGlassTint.SelectedValue = glassTint;
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    //lblError.Text = "Commit Exception Type: " + ex.GetType();
                    //lblError.Text += "  Message: " + ex.Message;

                    // Attempt to roll back the transaction. 
                    try
                    {
                        aTransaction.Rollback();
                    }
                    catch (Exception ex2)
                    {
                        //This catch block will handle any errors that may have occurred 
                        //on the server that would cause the rollback to fail, such as 
                        //a closed connection.
                        //lblError.Text = "Rollback Exception Type: " + ex2.GetType();
                        //lblError.Text += "  Message: " + ex2.Message;
                    }
                }
            }
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
            aDoor.Height = float.Parse(Request.Form["ctl00$MainContent$txtDoorHeightCabana"]);
            aDoor.Length = float.Parse(Request.Form["ctl00$MainContent$txtDoorWidthCabana"]);
            aDoor.GlassTint = Request.Form["ctl00$MainContent$ddlDoorGlassTintCabana"];

            if (aDoor.DoorStyle == "Vertical 4 Track")
            {
                aDoor.VinylTint = Request.Form["ctl00$MainContent$ddlDoorVinylTintCabana"];
                aDoor.DoorWindow = new Window();
                aDoor.DoorWindow.NumVents = int.Parse(Request.Form["ctl00$MainContent$ddlDoorV4TNumberOfVentsCabana"]);
                if (aDoor.VinylTint == "Mixed")
                {
                    if (aDoor.DoorWindow.NumVents == 3)
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
                else
                {
                    aDoor.VinylTint = Request.Form["ctl00$MainContent$ddlDoorVinylTintCabana"];
                }
            }
            else if (aDoor.DoorStyle.Contains("Screen"))
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
            aDoor.Height = float.Parse(Request.Form["ctl00$MainContent$txtDoorHeightFrench"]);
            aDoor.Length = float.Parse(Request.Form["ctl00$MainContent$txtDoorWidthFrench"]);
            aDoor.GlassTint = Request.Form["ctl00$MainContent$ddlDoorGlassTintFrench"];
            if (aDoor.DoorStyle == "Vertical 4 Track")
            {
                aDoor.VinylTint = Request.Form["ctl00$MainContent$ddlDoorVinylTintFrench"];
                aDoor.DoorWindow = new Window();
                aDoor.DoorWindow.NumVents = int.Parse(Request.Form["ctl00$MainContent$ddlDoorV4TNumberOfVentsFrench"]);
                if (aDoor.VinylTint == "Mixed")
                {
                    if (aDoor.DoorWindow.NumVents == 3)
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
                else
                {
                    aDoor.VinylTint = Request.Form["ctl00$MainContent$ddlDoorVinylTintFrench"];
                }
            }
            else if (aDoor.DoorStyle.Contains("Screen"))
            {
                aDoor.ScreenType = Request.Form["ctl00$MainContent$ddlDoorScreenOptionsFrench"];
            }
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
        private Tuple<int, int, int> findNumberOfDoorTypes()
        {
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
            return new Tuple<int, int, int>(cabanaCount, frenchCount, patioCount);
        }

        /// <summary>
        /// This function is used to populate the side bar which displays
        /// information regarding how many doors of each type have been ordered,
        /// along with individual door information. This is done in an accordion
        /// style to hide unneeded data.
        /// </summary>
        /// <param name="doorTypeCounts"></param>
        private void populateSideBar(Tuple<int, int, int> doorTypeCounts)
        {

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
                foreach (Door aDoor in doorsOrdered)
                {
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
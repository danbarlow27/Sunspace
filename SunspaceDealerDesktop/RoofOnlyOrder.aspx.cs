using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SunspaceDealerDesktop
{
    public partial class RoofOnlyOrder : System.Web.UI.Page
    {
        List<Roof> roofsOrdered = new List<Roof>();

        protected void Page_Load(object sender, EventArgs e)
        {
            #region Loop to display roof types as radio buttons

            //For loop to get through all the possible roof types: Cabana, French, Patio, Opening Only (No Roof)
            for (int typeCount = 0; typeCount < Constants.ROOF_TYPES.Count(); typeCount++)
            {
                //Conditional operator to set the current roof type with the right label
                string title = Constants.ROOF_TYPES[typeCount]; //(typeCount == 1) ? "Cabana" : (typeCount == 2) ? "French" : (typeCount == 3) ? "Patio" : "NoRoof";
                                
                RoofOptions.Controls.Add(new LiteralControl("<li>"));
                
                //Roof type radio button
                RadioButton typeRadio = new RadioButton();
                typeRadio.ID = "radType" + title; //Adding appropriate id to roof type radio button
                typeRadio.GroupName = "roofTypeRadios";         //Adding group name for all roof types
                typeRadio.Attributes.Add("onclick", "typeRowsDisplayed('" + title + "')"); //On click event to display the proper fields/rows

                //Roof type radio button label for clickable area
                Label typeLabelRadio = new Label();
                typeLabelRadio.AssociatedControlID = "radType" + title;   //Tying this label to the radio button

                //Roof type radio button label text
                Label typeLabel = new Label();
                typeLabel.AssociatedControlID = "radType" + title;    //Tying this label to the radio button
                typeLabel.Text = title;     //Displaying the proper texted based on current title variable
                
                RoofOptions.Controls.Add(typeRadio);        //Adding radio button control to placeholder RoofOptions
                RoofOptions.Controls.Add(typeLabelRadio);   //Adding label control to placeholder RoofOptions
                RoofOptions.Controls.Add(typeLabel);        //Adding label control to placeholder RoofOptions               
                
                //Adding literal control div tag to hold the table, add to RoofOptions placeholder
                RoofOptions.Controls.Add(new LiteralControl("<div class=\"toggleContent\" id=\"div_" + title + "\">"));

                RoofOptions.Controls.Add(new LiteralControl("<ul>"));

                //Adding literal control li to keep proper page look and format
                RoofOptions.Controls.Add(new LiteralControl("<li>"));

                #region Roof Styles Loop
                RoofOptions.Controls.Add(new LiteralControl("<ul class='toggleOptions'>"));

                for (int roofStyle = 0; roofStyle < 3; roofStyle++)
                {
                    string radioTitle = Constants.ROOF_STYLE[roofStyle];                    

                    #region Studio Height and Width
                    if (roofStyle == 0 && title == "Studio")
                    {
                        RoofOptions.Controls.Add(new LiteralControl("<li>"));

                        Label widthLabel = new Label();
                        widthLabel.ID = "lblWidth" + title;
                        widthLabel.Text = "Width: ";
                        widthLabel.AssociatedControlID = "txtWidth" + title;
                        widthLabel.CssClass = "labelFormatting";

                        TextBox widthTextbox = new TextBox();
                        widthTextbox.ID = "txtWidth" + title;
                        widthTextbox.CssClass = "txtField txtInput";

                        RoofOptions.Controls.Add(widthLabel);
                        RoofOptions.Controls.Add(widthTextbox);                        
                                                
                        RoofOptions.Controls.Add(new LiteralControl("</li>"));

                        RoofOptions.Controls.Add(new LiteralControl("<li>"));

                        Label heightLabel = new Label();
                        heightLabel.ID = "lblHeight" + title;
                        heightLabel.Text = "Height: ";
                        heightLabel.AssociatedControlID = "txtHeight" + title;
                        heightLabel.CssClass = "labelFormatting";

                        TextBox heightTextbox = new TextBox();
                        heightTextbox.ID = "txtHeight" + title;
                        heightTextbox.CssClass = "txtField txtInput";

                        RoofOptions.Controls.Add(heightLabel);
                        RoofOptions.Controls.Add(heightTextbox);

                        RoofOptions.Controls.Add(new LiteralControl("</li>"));

                        RoofOptions.Controls.Add(new LiteralControl("<li>"));

                        Label soffitLabel = new Label();
                        soffitLabel.ID = "lblSoffit" + title;
                        soffitLabel.Text = "Soffit: ";
                        soffitLabel.AssociatedControlID = "txtSoffit" + title;
                        soffitLabel.CssClass = "labelFormatting";

                        TextBox soffitTextbox = new TextBox();
                        soffitTextbox.ID = "txtSoffit" + title;
                        soffitTextbox.CssClass = "txtField txtInput";

                        RoofOptions.Controls.Add(soffitLabel);
                        RoofOptions.Controls.Add(soffitTextbox);

                        RoofOptions.Controls.Add(new LiteralControl("</li>"));
                    }
                    #endregion
                    #region Gable Height and Width
                    else if (roofStyle == 0 && title == "Gable") 
                    {
                        RoofOptions.Controls.Add(new LiteralControl("<li>"));

                        Label widthLeftLabel = new Label();
                        widthLeftLabel.ID = "lblWidthLeft" + title;
                        widthLeftLabel.Text = "WidthLeft: ";
                        widthLeftLabel.AssociatedControlID = "txtWidthLeft" + title;
                        widthLeftLabel.CssClass = "labelFormatting";

                        TextBox widthLeftTextbox = new TextBox();
                        widthLeftTextbox.ID = "txtWidthLeft" + title;
                        widthLeftTextbox.CssClass = "txtField txtInput";

                        RoofOptions.Controls.Add(widthLeftLabel);
                        RoofOptions.Controls.Add(widthLeftTextbox);

                        RoofOptions.Controls.Add(new LiteralControl("</li>"));

                        RoofOptions.Controls.Add(new LiteralControl("<li>"));

                        Label heightLeftLabel = new Label();
                        heightLeftLabel.ID = "lblHeightLeft" + title;
                        heightLeftLabel.Text = "Height Left: ";
                        heightLeftLabel.AssociatedControlID = "txtHeightLeft" + title;
                        heightLeftLabel.CssClass = "labelFormatting";

                        TextBox heightLeftTextbox = new TextBox();
                        heightLeftTextbox.ID = "txtHeightLeft" + title;
                        heightLeftTextbox.CssClass = "txtField txtInput";

                        RoofOptions.Controls.Add(heightLeftLabel);
                        RoofOptions.Controls.Add(heightLeftTextbox);

                        RoofOptions.Controls.Add(new LiteralControl("</li>"));

                        RoofOptions.Controls.Add(new LiteralControl("<li>"));

                        Label gableLabel = new Label();
                        gableLabel.ID = "lblGable" + title;
                        gableLabel.Text = "Gable: ";
                        gableLabel.AssociatedControlID = "txtGable" + title;
                        gableLabel.CssClass = "labelFormatting";

                        TextBox gableTextbox = new TextBox();
                        gableTextbox.ID = "txtGable" + title;
                        gableTextbox.CssClass = "txtField txtInput";

                        RoofOptions.Controls.Add(gableLabel);
                        RoofOptions.Controls.Add(gableTextbox);

                        RoofOptions.Controls.Add(new LiteralControl("</li>"));

                        RoofOptions.Controls.Add(new LiteralControl("<li>"));

                        Label widthRightLabel = new Label();
                        widthRightLabel.ID = "lblWidthRight" + title;
                        widthRightLabel.Text = "WidthRight: ";
                        widthRightLabel.AssociatedControlID = "txtWidthRight" + title;
                        widthRightLabel.CssClass = "labelFormatting";

                        TextBox widthRightTextbox = new TextBox();
                        widthRightTextbox.ID = "txtWidthRight" + title;
                        widthRightTextbox.CssClass = "txtField txtInput";

                        RoofOptions.Controls.Add(widthRightLabel);
                        RoofOptions.Controls.Add(widthRightTextbox);

                        RoofOptions.Controls.Add(new LiteralControl("</li>"));

                        RoofOptions.Controls.Add(new LiteralControl("<li>"));

                        Label heightRightLabel = new Label();
                        heightRightLabel.ID = "lblHeightRight" + title;
                        heightRightLabel.Text = "Height Right: ";
                        heightRightLabel.AssociatedControlID = "txtHeightRight" + title;
                        heightRightLabel.CssClass = "labelFormatting";

                        TextBox heightRightTextbox = new TextBox();
                        heightRightTextbox.ID = "txtHeightRight" + title;
                        heightRightTextbox.CssClass = "txtField txtInput";

                        RoofOptions.Controls.Add(heightRightLabel);
                        RoofOptions.Controls.Add(heightRightTextbox);

                        RoofOptions.Controls.Add(new LiteralControl("</li>"));

                        RoofOptions.Controls.Add(new LiteralControl("<li>"));

                        Label soffitLabel = new Label();
                        soffitLabel.ID = "lblSoffit" + title;
                        soffitLabel.Text = "Soffit: ";
                        soffitLabel.AssociatedControlID = "txtSoffit" + title;
                        soffitLabel.CssClass = "labelFormatting";

                        TextBox soffitTextbox = new TextBox();
                        soffitTextbox.ID = "txtSoffit" + title;
                        soffitTextbox.CssClass = "txtField txtInput";

                        RoofOptions.Controls.Add(soffitLabel);
                        RoofOptions.Controls.Add(soffitTextbox);

                        RoofOptions.Controls.Add(new LiteralControl("</li>"));

                    }
                    #endregion

                    //New instance of a table for every roof type
                    Table tblRoofDetails = new Table();

                    tblRoofDetails.ID = "tblRoofDetails" + title + radioTitle; //Adding appropriate id to the table
                    tblRoofDetails.CssClass = "tblTextFields";                  //Adding CssClass to the table for styling   

                    RoofOptions.Controls.Add(new LiteralControl("<li>"));

                    //Roof style radio button
                    RadioButton styleRadio = new RadioButton();
                    styleRadio.ID = "radStyle" + title + radioTitle; //Adding appropriate id to roof style radio button
                    styleRadio.GroupName = "roofStyleRadios" + title;         //Adding group name for all roof styles
                    styleRadio.Attributes.Add("onclick", "styleRowsDisplayed('" + title + "')"); //On click event to display the proper fields/rows

                    //Roof style radio button label for clickable area
                    Label styleLabelRadio = new Label();
                    styleLabelRadio.AssociatedControlID = "radStyle" + title + radioTitle;   //Tying this label to the radio button

                    //Roof style radio button label text
                    Label styleLabel = new Label();
                    styleLabel.AssociatedControlID = "radStyle" + title + radioTitle;    //Tying this label to the radio button
                    styleLabel.Text = radioTitle;     //Displaying the proper texted based on current title variable

                    RoofOptions.Controls.Add(styleRadio);        //Adding radio button control to placeholder RoofOptions
                    RoofOptions.Controls.Add(styleLabelRadio);   //Adding label control to placeholder RoofOptions
                    RoofOptions.Controls.Add(styleLabel);        //Adding label control to placeholder RoofOptions

                    RoofOptions.Controls.Add(new LiteralControl("<div class='toggleContent'>"));

                    RoofOptions.Controls.Add(new LiteralControl("<ul>"));

                    RoofOptions.Controls.Add(new LiteralControl("<li>"));

                    //Creating cells and controls for rows
                    #region Table:Default Row Title Current Roof (tblRoofDetails)

                    TableRow roofTitleRow = new TableRow();
                    roofTitleRow.ID = "rowRoofTitle" + title + radioTitle;
                    roofTitleRow.Attributes.Add("style", "display:none;");
                    TableCell roofTitleLBLCell = new TableCell();

                    Label roofTitleLBL = new Label();
                    roofTitleLBL.ID = "lblRoofTitle" + title + radioTitle;
                    roofTitleLBL.Text = "Select roof details:";
                    roofTitleLBL.Attributes.Add("style", "font-weight:bold;");

                    roofTitleLBLCell.Controls.Add(roofTitleLBL);

                    tblRoofDetails.Rows.Add(roofTitleRow);

                    roofTitleRow.Cells.Add(roofTitleLBLCell);

                    #endregion

                    TableRow roofPanelThicknessRow = new TableRow();
                    TableCell roofPanelThicknessLBLCell = new TableCell();
                    TableCell roofPanelThicknessDDLCell = new TableCell();

                    Label roofPanelThicknessLBL = new Label();
                    roofPanelThicknessLBL.ID = "lblRoofPanelThickness" + title + radioTitle;
                    roofPanelThicknessLBL.Text = "Panel Thicknesses: ";

                    DropDownList roofPanelThicknessDDL = new DropDownList();
                    roofPanelThicknessDDL.ID = "ddlRoofPanelThickness" + title + radioTitle;

                    #region Alum. Skin or O.S.B. options
                    if (radioTitle == "Alum. Skin or O.S.B.") {
                        for (int i = 0; i < Constants.ROOF_TRADITIONAL_THICKNESSES.Count(); i++) { 
                            roofPanelThicknessDDL.Items.Add(new ListItem(Constants.ROOF_TRADITIONAL_THICKNESSES[i], Constants.ROOF_TRADITIONAL_THICKNESSES[i]));
                        }

                        TableRow roofStripeColourRow = new TableRow();
                        TableCell roofStripeColourLBLCell = new TableCell();
                        TableCell roofStripeColourDDLCell = new TableCell();

                        Label roofStripeColourLBL = new Label();
                        roofStripeColourLBL.ID = "lblRoofStripeColour" + title + radioTitle;
                        roofStripeColourLBL.Text = "Stripe Colour: ";

                        DropDownList roofStripeColourDDL = new DropDownList();
                        roofStripeColourDDL.ID = "ddlRoofStripeColour" + title + radioTitle;

                        roofStripeColourLBLCell.Controls.Add(roofStripeColourLBL);

                        roofStripeColourDDLCell.Controls.Add(roofStripeColourDDL);

                        tblRoofDetails.Rows.Add(roofStripeColourRow);

                        roofStripeColourRow.Cells.Add(roofStripeColourLBLCell);

                        roofStripeColourRow.Cells.Add(roofStripeColourDDLCell);

                        for (int i = 0; i < Constants.ROOF_STRIPE_COLOURS.Count(); i++)
                        {
                            roofStripeColourDDL.Items.Add(new ListItem(Constants.ROOF_STRIPE_COLOURS[i], Constants.ROOF_STRIPE_COLOURS[i]));
                        }

                    }
                    #endregion
                    #region Acrylic T-Bar System options
                    else if (radioTitle == "Acrylic T-Bar System"){

                        TableRow roofAcrylicColourRow = new TableRow();
                        TableCell roofAcrylicColourLBLCell = new TableCell();
                        TableCell roofAcrylicColourDDLCell = new TableCell();

                        Label roofAcrylicColourLBL = new Label();
                        roofAcrylicColourLBL.ID = "lblRoofAcrylicColour" + title + radioTitle;
                        roofAcrylicColourLBL.Text = "Acrylic Colour: ";

                        DropDownList roofAcrylicColourDDL = new DropDownList();
                        roofAcrylicColourDDL.ID = "ddlRoofAcrylicColour" + title + radioTitle;

                        for (int i = 0; i < Constants.ROOF_ACRYLIC_COLOURS.Count(); i++)
                        {
                            roofAcrylicColourDDL.Items.Add(new ListItem(Constants.ROOF_ACRYLIC_COLOURS[i], Constants.ROOF_ACRYLIC_COLOURS[i]));
                        }

                        roofAcrylicColourLBLCell.Controls.Add(roofAcrylicColourLBL);

                        roofAcrylicColourDDLCell.Controls.Add(roofAcrylicColourDDL);

                        tblRoofDetails.Rows.Add(roofAcrylicColourRow);

                        roofAcrylicColourRow.Cells.Add(roofAcrylicColourLBLCell);

                        roofAcrylicColourRow.Cells.Add(roofAcrylicColourDDLCell);

                        for (int i = 0; i < Constants.ROOF_ACRYLIC_THICKNESSES.Count(); i++) { 
                            roofPanelThicknessDDL.Items.Add(new ListItem(Constants.ROOF_ACRYLIC_THICKNESSES[i], Constants.ROOF_ACRYLIC_THICKNESSES[i]));
                        }
                    }
                    #endregion
                    #region Thermadeck Sytem options
                    else
                    {

                        TableRow roofBarrierRow = new TableRow();
                        TableCell roofBarrierCHKCell = new TableCell();

                        CheckBox roofBarrierCHK = new CheckBox();
                        roofBarrierCHK.ID = "chkRoofBarrier" + title + radioTitle;
                        Label roofBarrierLBLCheck = new Label();
                        roofBarrierLBLCheck.ID = "lblBarrierCheck" + title + radioTitle;
                        roofBarrierLBLCheck.AssociatedControlID = "chkRoofBarrier" + title + radioTitle;
                        Label roofBarrierLBL = new Label();
                        roofBarrierLBL.ID = "lblBarrier" + title + radioTitle;
                        roofBarrierLBL.AssociatedControlID = "chkRoofBarrier" + title + radioTitle;
                        roofBarrierLBL.Text = "Metal Vapour Barrier";
                        
                        roofBarrierCHKCell.Controls.Add(roofBarrierCHK);

                        roofBarrierCHKCell.Controls.Add(roofBarrierLBLCheck);

                        roofBarrierCHKCell.Controls.Add(roofBarrierLBL);

                        tblRoofDetails.Rows.Add(roofBarrierRow);

                        roofBarrierRow.Cells.Add(roofBarrierCHKCell);

                        for (int i = 0; i < Constants.ROOF_THERMADECK_THICKNESSES.Count(); i++) { 
                            roofPanelThicknessDDL.Items.Add(new ListItem(Constants.ROOF_THERMADECK_THICKNESSES[i], Constants.ROOF_THERMADECK_THICKNESSES[i]));
                        }
                    }
                    #endregion

                    roofPanelThicknessLBLCell.Controls.Add(roofPanelThicknessLBL);

                    roofPanelThicknessDDLCell.Controls.Add(roofPanelThicknessDDL);

                    tblRoofDetails.Rows.Add(roofPanelThicknessRow);

                    roofPanelThicknessRow.Cells.Add(roofPanelThicknessLBLCell);

                    roofPanelThicknessRow.Cells.Add(roofPanelThicknessDDLCell);

                    #region Table:# Row Add This Roof (tblRoofDetails)

                    TableRow roofButtonRow = new TableRow();
                    roofButtonRow.ID = "rowAddRoof" + title + radioTitle;
                    roofButtonRow.Attributes.Add("style", "display:inherit;");
                    TableCell roofAddButtonCell = new TableCell();
                    TableCell roofFillButtonCell = new TableCell();

                    Button roofButton = new Button();
                    roofButton.ID = "btnAdd" + title + radioTitle;
                    roofButton.Text = "Add this " + radioTitle + " roof";
                    roofButton.CssClass = "btnSubmit";

                    //roofAddButtonCell.Controls.Add(new LiteralControl("<input id='btnAddthisRoof" + title + "' type='button' onclick='addRoof(\"" + title + "\")' class='btnSubmit' style='display:inherit;' value='Add This " + title + " Roof'/>"));
                    roofAddButtonCell.Controls.Add(roofButton);

                    tblRoofDetails.Rows.Add(roofButtonRow);

                    roofButtonRow.Cells.Add(roofAddButtonCell);

                    #endregion

                    //Adding table to placeholder RoofOptions
                    RoofOptions.Controls.Add(tblRoofDetails);

                    RoofOptions.Controls.Add(new LiteralControl("</li>"));

                    RoofOptions.Controls.Add(new LiteralControl("</ul>"));

                    RoofOptions.Controls.Add(new LiteralControl("</div>"));

                    //Start of loop closing tags
                    RoofOptions.Controls.Add(new LiteralControl("</li>"));

                }

                RoofOptions.Controls.Add(new LiteralControl("</ul>"));
                #endregion                

                //Closing necessary tags
                RoofOptions.Controls.Add(new LiteralControl("</li>"));

                RoofOptions.Controls.Add(new LiteralControl("</ul>"));

                RoofOptions.Controls.Add(new LiteralControl("</div>"));

                RoofOptions.Controls.Add(new LiteralControl("</li>"));

            }
            #endregion

            getRoofFromForm();
        }

        private Roof getRoofFromForm()
        {
            Roof aRoof = new Roof();
            string roofType, roofStyle;

            roofType = Request.Form["ctl00$MainContent$roofTypeRadios"];

            if (roofType == "Studio")
            {
                aRoof.Type = roofType;
                aRoof.Width = float.Parse(Request.Form["ctl00$MainContent$txtWidthStudio"]);
                aRoof.Projection = float.Parse(Request.Form["ctl00$MainContent$txtHeightStudio"]);
                //aRoof.Soffit = float.Parse(Request.Form["ctl00$MainContent$txtSoffitStudio"]);        DOESN'T EXIST IN ROOF.CS
                
                roofStyle = Request.Form["ctl00$MainContent$roofStyleRadiosStudio"];

                if (roofStyle == "Alum. Skin or O.S.B.")
                {
                    aRoof.StripeColour = Request.Form["ctl00$MainContent$ddlRoofStripeColourStudioAlum. Skin or O.S.B."];
                    aRoof.Thickness = float.Parse(Request.Form["ctl00$MainContent$ddlRoofPanelThicknessStudioAlum. Skin or O.S.B."]);
                }
                else if (roofStyle == "Acrylic T-Bar System")
                {
                    //aRoof.AcrylicColour = Request.Form["ctl00$MainContent$ddlRoofAcrylicColourStudioAcrylic T-Bar System"];
                    aRoof.Thickness = float.Parse(Request.Form["ctl00$MainContent$ddlRoofPanelThicknessStudioAcrylic T-Bar System"]);
                }
                else
                {
                    //aRoof.MetalVapourBarrier = Request.Form["ctl00$MainContent$chkRoofBarrierStudioThermadeck System"];
                    aRoof.Thickness = float.Parse(Request.Form["ctl00$MainContent$ddlRoofPanelThicknessStudioThermadeck System"]);
                }
            }
            else if (roofType == "Gable")
            {
                aRoof.Type = roofType;
                aRoof.Width = float.Parse(Request.Form["ctl00$MainContent$txtWidthLeftGable"]);
                aRoof.Projection = float.Parse(Request.Form["ctl00$MainContent$txtHeightLeftGable"]);
                //aRoof.Gable = float.Parse(Request.Form["ctl00$MainContent$txtGableGable"]);               DOESN'T EXIST IN ROOF.CS
                //aRoof.Width = float.Parse(Request.Form["ctl00$MainContent$txtWidthRightGable"]);          RIGHT SIDE
                //aRoof.Projection = float.Parse(Request.Form["ctl00$MainContent$txtHeightRightGable"]);    RIGHT SIDE
                //aRoof.Soffit = float.Parse(Request.Form["ctl00$MainContent$txtSoffitStudio"]);            DOESN'T EXIST IN ROOF.CS

                roofStyle = Request.Form["ctl00$MainContent$roofStyleRadiosGable"];

                if (roofStyle == "Alum. Skin or O.S.B.")
                {
                    aRoof.StripeColour = Request.Form["ctl00$MainContent$ddlRoofStripeColourGableAlum. Skin or O.S.B."];
                    aRoof.Thickness = float.Parse(Request.Form["ctl00$MainContent$ddlRoofPanelThicknessGableAlum. Skin or O.S.B."]);
                }
                else if (roofStyle == "Acrylic T-Bar System")
                {
                    //aRoof.AcrylicColour = Request.Form["ctl00$MainContent$ddlRoofAcrylicColourGableAcrylic T-Bar System"];    DOESN'T EXIST IN ROOF.CS
                    aRoof.Thickness = float.Parse(Request.Form["ctl00$MainContent$ddlRoofPanelThicknessGableAcrylic T-Bar System"]);
                }
                else
                {
                    //aRoof.MetalVapourBarrier = Request.Form["ctl00$MainContent$chkRoofBarrierGableThermadeck System"];    DOESN'T EXIST IN ROOF.CS
                    aRoof.Thickness = float.Parse(Request.Form["ctl00$MainContent$ddlRoofPanelThicknessGableThermadeck System"]);
                }
            }


            return aRoof;
        }

        private void populateSideBar() {

            lblRoofPager.Controls.Add(new LiteralControl("<ul class='toggleOptions'>"));



            lblRoofPager.Controls.Add(new LiteralControl("</ul>"));
        }
    }
}
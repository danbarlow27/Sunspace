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

                        Label projectionLabel = new Label();
                        projectionLabel.ID = "lblProjection" + title;
                        projectionLabel.Text = "Projection: ";
                        projectionLabel.AssociatedControlID = "txtProjection" + title;
                        projectionLabel.CssClass = "labelFormatting";

                        TextBox projectionTextbox = new TextBox();
                        projectionTextbox.ID = "txtProjection" + title;
                        projectionTextbox.CssClass = "txtField txtInput";

                        RoofOptions.Controls.Add(projectionLabel);
                        RoofOptions.Controls.Add(projectionTextbox);

                        RoofOptions.Controls.Add(new LiteralControl("</li>"));

                        RoofOptions.Controls.Add(new LiteralControl("<li>"));

                        Label frontHeightLabel = new Label();
                        frontHeightLabel.ID = "lblFrontHeight" + title;
                        frontHeightLabel.Text = "Front Height: ";
                        frontHeightLabel.AssociatedControlID = "txtFrontHeight" + title;
                        frontHeightLabel.CssClass = "labelFormatting";

                        TextBox frontHeightTextbox = new TextBox();
                        frontHeightTextbox.ID = "txtFrontHeight" + title;
                        frontHeightTextbox.CssClass = "txtField txtInput";

                        RoofOptions.Controls.Add(frontHeightLabel);
                        RoofOptions.Controls.Add(frontHeightTextbox);

                        RoofOptions.Controls.Add(new LiteralControl("</li>"));

                        RoofOptions.Controls.Add(new LiteralControl("<li>"));

                        Label backHeightLabel = new Label();
                        backHeightLabel.ID = "lblBackHeight" + title;
                        backHeightLabel.Text = "Back Height: ";
                        backHeightLabel.AssociatedControlID = "txtBackHeight" + title;
                        backHeightLabel.CssClass = "labelFormatting";

                        TextBox backHeightTextbox = new TextBox();
                        backHeightTextbox.ID = "txtBackHeight" + title;
                        backHeightTextbox.CssClass = "txtField txtInput";

                        RoofOptions.Controls.Add(backHeightLabel);
                        RoofOptions.Controls.Add(backHeightTextbox);

                        RoofOptions.Controls.Add(new LiteralControl("</li>"));
                    }
                    #endregion

                    #region Gable Height and Width
                    else if (roofStyle == 0 && title == "Gable") 
                    {
                        RoofOptions.Controls.Add(new LiteralControl("<li>"));

                        Label leftProjectionLabel = new Label();
                        leftProjectionLabel.ID = "lblLeftProjection" + title;
                        leftProjectionLabel.Text = "Left Projection: ";
                        leftProjectionLabel.AssociatedControlID = "txtLeftProjection" + title;
                        leftProjectionLabel.CssClass = "labelFormatting";

                        TextBox leftProjectionTextbox = new TextBox();
                        leftProjectionTextbox.ID = "txtLeftProjection" + title;
                        leftProjectionTextbox.CssClass = "txtField txtInput";
                        leftProjectionTextbox.ToolTip = "Left projection is the width of wall section under the left side of the gable roof";

                        RoofOptions.Controls.Add(leftProjectionLabel);
                        RoofOptions.Controls.Add(leftProjectionTextbox);

                        RoofOptions.Controls.Add(new LiteralControl("</li>"));

                        RoofOptions.Controls.Add(new LiteralControl("<li>"));

                        Label rightProjectionLabel = new Label();
                        rightProjectionLabel.ID = "lblRightProjection" + title;
                        rightProjectionLabel.Text = "Right Projection: ";
                        rightProjectionLabel.AssociatedControlID = "txtRightProjection" + title;
                        rightProjectionLabel.CssClass = "labelFormatting";

                        TextBox rightProjectionTextbox = new TextBox();
                        rightProjectionTextbox.ID = "txtRightProjection" + title;
                        rightProjectionTextbox.CssClass = "txtField txtInput";
                        rightProjectionTextbox.ToolTip = "Right projection is the width of wall section under the right side of the gable roof";

                        RoofOptions.Controls.Add(rightProjectionLabel);
                        RoofOptions.Controls.Add(rightProjectionTextbox);

                        RoofOptions.Controls.Add(new LiteralControl("</li>"));

                        RoofOptions.Controls.Add(new LiteralControl("<li>"));

                        Label heightLeftLabel = new Label();
                        heightLeftLabel.ID = "lblHeightLeft" + title;
                        heightLeftLabel.Text = "Left Height: ";
                        heightLeftLabel.AssociatedControlID = "txtHeightLeft" + title;
                        heightLeftLabel.CssClass = "labelFormatting";

                        TextBox heightLeftTextbox = new TextBox();
                        heightLeftTextbox.ID = "txtHeightLeft" + title;
                        heightLeftTextbox.CssClass = "txtField txtInput";
                        heightLeftTextbox.ToolTip = "Left height is the distance between the ground and the bottom part of the left side of the roof";

                        RoofOptions.Controls.Add(heightLeftLabel);
                        RoofOptions.Controls.Add(heightLeftTextbox);

                        RoofOptions.Controls.Add(new LiteralControl("</li>"));

                        RoofOptions.Controls.Add(new LiteralControl("<li>"));

                        Label heightRightLabel = new Label();
                        heightRightLabel.ID = "lblHeightRight" + title;
                        heightRightLabel.Text = "Right Height: ";
                        heightRightLabel.AssociatedControlID = "txtHeightRight" + title;
                        heightRightLabel.CssClass = "labelFormatting";

                        TextBox heightRightTextbox = new TextBox();
                        heightRightTextbox.ID = "txtHeightRight" + title;
                        heightRightTextbox.CssClass = "txtField txtInput";
                        heightRightTextbox.ToolTip = "Right height is the distance between the ground and the bottom part of the right side of the roof";

                        RoofOptions.Controls.Add(heightRightLabel);
                        RoofOptions.Controls.Add(heightRightTextbox);

                        RoofOptions.Controls.Add(new LiteralControl("</li>"));

                        RoofOptions.Controls.Add(new LiteralControl("<li>"));

                        Label peakRightLabel = new Label();
                        peakRightLabel.ID = "lblPeakHeight" + title;
                        peakRightLabel.Text = "Peak Height: ";
                        peakRightLabel.AssociatedControlID = "txtPeak" + title;
                        peakRightLabel.CssClass = "labelFormatting";

                        TextBox peakRightTextbox = new TextBox();
                        peakRightTextbox.ID = "txtPeak" + title;
                        peakRightTextbox.CssClass = "txtField txtInput";
                        peakRightTextbox.ToolTip = "Peak height is the height of where the gable post would be";

                        RoofOptions.Controls.Add(peakRightLabel);
                        RoofOptions.Controls.Add(peakRightTextbox);

                        RoofOptions.Controls.Add(new LiteralControl("</li>"));

                        RoofOptions.Controls.Add(new LiteralControl("<li>"));

                        CheckBox roofSunspaceGableCHK = new CheckBox();
                        roofSunspaceGableCHK.ID = "chkRoofSunspaceGable" + title + radioTitle;
                        Label roofSunspaceGableLBLCheck = new Label();
                        roofSunspaceGableLBLCheck.ID = "lblSunspaceGableCheck" + title + radioTitle;
                        roofSunspaceGableLBLCheck.AssociatedControlID = "chkRoofSunspaceGable" + title + radioTitle;
                        Label roofSunspaceGableLBL = new Label();
                        roofSunspaceGableLBL.ID = "lblSunspaceGable" + title + radioTitle;
                        roofSunspaceGableLBL.AssociatedControlID = "chkRoofSunspaceGable" + title + radioTitle;
                        roofSunspaceGableLBL.Text = "Sunspace Gable";

                        RoofOptions.Controls.Add(roofSunspaceGableCHK);
                        RoofOptions.Controls.Add(roofSunspaceGableLBLCheck);
                        RoofOptions.Controls.Add(roofSunspaceGableLBL);

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

            #region PostBack functionality to store roofs
            if (IsPostBack)
            {
                if ((List<Roof>)Session["roofsOrdered"] != null)
                {
                    roofsOrdered = (List<Roof>)Session["roofsOrdered"];
                }

                if (Request.Form["ctl00$MainContent$roofTypeRadios"] == "radTypeStudio")
                {
                    Roof aRoof = getStudioFromForm();
                    roofsOrdered.Add(aRoof);
                }
                else if (Request.Form["ctl00$MainContent$roofTypeRadios"] == "radTypeGable") 
                {
                    Roof aRoof = getGableFromForm();
                    roofsOrdered.Add(aRoof);
                }

                System.Diagnostics.Debug.Write(roofsOrdered[0].Type);

                Session.Add("roofsOrdered", roofsOrdered);
            }
            #endregion
                        
            populateSideBar(findNumberOfRoofTypes());
        }

        private Roof getStudioFromForm()
        {
            Roof aRoof = new Roof();
            string roofStyle = Request.Form["ctl00$MainContent$roofStyleRadiosStudio"];

            aRoof.Type = "Studio";
            aRoof.Width = float.Parse(Request.Form["ctl00$MainContent$txtWidthStudio"]);
            aRoof.Projection = float.Parse(Request.Form["ctl00$MainContent$txtProjectionStudio"]);
            //aRoof.Soffit = float.Parse(Request.Form["ctl00$MainContent$txtSoffitStudio"]);        DOESN'T EXIST IN ROOF.CS            

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
            return aRoof;
        }
        
        private Roof getGableFromForm()
        {
            Roof aRoof = new Roof();
            string roofStyle  = Request.Form["ctl00$MainContent$roofStyleRadiosGable"];

            aRoof.Type = "Gable";
            aRoof.Width = float.Parse(Request.Form["ctl00$MainContent$txtWidthLeftGable"]);
            aRoof.Projection = float.Parse(Request.Form["ctl00$MainContent$txtHeightLeftGable"]);

            /*
             * To be made as 2 roof modules
             * */
            //aRoof.Gable = float.Parse(Request.Form["ctl00$MainContent$txtGableGable"]);               DOESN'T EXIST IN ROOF.CS
            //aRoof.Width = float.Parse(Request.Form["ctl00$MainContent$txtWidthRightGable"]);          RIGHT SIDE
            //aRoof.Projection = float.Parse(Request.Form["ctl00$MainContent$txtHeightRightGable"]);    RIGHT SIDE
            //aRoof.Soffit = float.Parse(Request.Form["ctl00$MainContent$txtSoffitStudio"]);            DOESN'T EXIST IN ROOF.CS
            
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

            return aRoof;
        }
                
        private Tuple<int, int> findNumberOfRoofTypes()
        {
            int studioCount = 0, gableCount = 0;
            roofsOrdered.ForEach(delegate(Roof roofChecked)
            {
                if (roofChecked.Type == "Studio")
                    studioCount++;
                else if (roofChecked.Type == "Gable")
                    gableCount++;
            });
            //System.Diagnostics.Debug.Write("This is the cabana count: " + cabanaCount);
            return new Tuple<int, int>(studioCount, gableCount);
        }

        private void populateSideBar(Tuple<int, int> roofTypeCounts)
        {

            int count;

            lblRoofPager.Controls.Add(new LiteralControl("<ul class='toggleOptions'>"));

            if (roofTypeCounts.Item1 > 0)
            {
                lblRoofPager.Controls.Add(new LiteralControl("<li id='studioRoofs'>"));

                Label studioLabel = new Label();
                studioLabel.ID = "lblStudioRoofs";
                studioLabel.Text = "Studio Roofs Ordered " + roofTypeCounts.Item1;
                lblRoofPager.Controls.Add(studioLabel);

                count = 1;

                #region Creating studio roof pager items
                foreach (Roof aRoof in roofsOrdered)
                {
                    if (aRoof.Type == "Studio")
                    {
                        lblRoofPager.Controls.Add(new LiteralControl("<div class='toggleContent'>"));

                        Label studioCurrentRoof = new Label();
                        studioCurrentRoof.ID = "lblRoof" + aRoof.Type + count;
                        studioCurrentRoof.Text = aRoof.Type + " Roof " + count;
                        lblRoofPager.Controls.Add(studioCurrentRoof);

                        Label studioStyle = new Label();
                        studioStyle.ID = "lbl" + aRoof.Type + "Type" + count;
                        studioStyle.Text = "Type: " + aRoof.Type;
                        lblRoofPager.Controls.Add(studioStyle);

                        lblRoofPager.Controls.Add(new LiteralControl("</div>"));

                        count++;
                    }
                }
                #endregion

                lblRoofPager.Controls.Add(new LiteralControl("</li>"));
            }

            lblRoofPager.Controls.Add(new LiteralControl("</ul>"));

        }
    }
}
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

                    //New instance of a table for every roof type
                    Table tblRoofDetails = new Table();

                    tblRoofDetails.ID = "tblRoofDetails" + title + radioTitle; //Adding appropriate id to the table
                    tblRoofDetails.CssClass = "tblTextFields";                  //Adding CssClass to the table for styling   

                    RoofOptions.Controls.Add(new LiteralControl("<li>"));

                    //Roof style radio button
                    RadioButton styleRadio = new RadioButton();
                    styleRadio.ID = "radStyle" + title + radioTitle; //Adding appropriate id to roof style radio button
                    styleRadio.GroupName = "roofStyleRadios";         //Adding group name for all roof styles
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

                        for (int i = 0; i < Constants.ROOF_STRIPE_COLOURS.Count(); i++)
                        {
                            roofStripeColourDDL.Items.Add(new ListItem(Constants.ROOF_STRIPE_COLOURS[i], Constants.ROOF_STRIPE_COLOURS[i]));
                        }

                        roofStripeColourLBLCell.Controls.Add(roofStripeColourLBL);

                        roofStripeColourDDLCell.Controls.Add(roofStripeColourDDL);

                        tblRoofDetails.Rows.Add(roofStripeColourRow);

                        roofStripeColourRow.Cells.Add(roofStripeColourLBLCell);
                        
                        roofStripeColourRow.Cells.Add(roofStripeColourDDLCell);
                    }
                    else if (radioTitle == "Acrylic T-Bar System"){
                        for (int i = 0; i < Constants.ROOF_ACRYLIC_THICKNESSES.Count(); i++) { 
                            roofPanelThicknessDDL.Items.Add(new ListItem(Constants.ROOF_ACRYLIC_THICKNESSES[i], Constants.ROOF_ACRYLIC_THICKNESSES[i]));
                        }
                    }
                    else{
                        for (int i = 0; i < Constants.ROOF_THERMADECK_THICKNESSES.Count(); i++) { 
                            roofPanelThicknessDDL.Items.Add(new ListItem(Constants.ROOF_THERMADECK_THICKNESSES[i], Constants.ROOF_THERMADECK_THICKNESSES[i]));
                        }
                    }

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

        }
    }
}
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
        //fractions list for dropdowns
        private List<ListItem> fractionList = GlobalFunctions.FractionOptions();
                
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
                //typeRadio.Attributes.Add("onclick", "typeRowsDisplayed('" + title + "')"); //On click event to display the proper fields/rows

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

                    #region Studio Dimensions and Specifics
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
                        widthTextbox.MaxLength = 3;
                        widthTextbox.Attributes.Add("onblur", "validateDimensions('" + title + "')");

                        DropDownList ddlWidthInchSpecific = new DropDownList();
                        ddlWidthInchSpecific.ID = "ddlWidthInchSpecific" + title;
                        ddlWidthInchSpecific.CssClass = "txtField txtInput";
                        ddlWidthInchSpecific.Attributes.Add("style", "width:50px");

                        for (int i = 0; i < fractionList.Count; i++)
                        {
                            ddlWidthInchSpecific.Items.Add(fractionList[i]);
                        }

                        RoofOptions.Controls.Add(widthLabel);
                        RoofOptions.Controls.Add(widthTextbox);
                        RoofOptions.Controls.Add(ddlWidthInchSpecific);
                                                
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
                        projectionTextbox.MaxLength = 3;
                        projectionTextbox.Attributes.Add("onblur", "validateDimensions('" + title + "')");

                        DropDownList ddlProjectionInchSpecific = new DropDownList();
                        ddlProjectionInchSpecific.ID = "ddlProjectionInchSpecific" + title;
                        ddlProjectionInchSpecific.CssClass = "txtField txtInput";
                        ddlProjectionInchSpecific.Attributes.Add("style", "width:50px");

                        for (int i = 0; i < fractionList.Count; i++)
                        {
                            ddlProjectionInchSpecific.Items.Add(fractionList[i]);
                        }

                        RoofOptions.Controls.Add(projectionLabel);
                        RoofOptions.Controls.Add(projectionTextbox);
                        RoofOptions.Controls.Add(ddlProjectionInchSpecific);

                        RoofOptions.Controls.Add(new LiteralControl("</li>"));                       

                    }
                    #endregion

                    #region Gable Dimensions and Specifics
                    else if (roofStyle == 0 && title == "Gable") 
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
                        widthTextbox.MaxLength = 3;
                        widthTextbox.Attributes.Add("onblur", "validateDimensions('" + title + "')");

                        DropDownList ddlWidthInchSpecific = new DropDownList();
                        ddlWidthInchSpecific.ID = "ddlWidthInchSpecific" + title;
                        ddlWidthInchSpecific.CssClass = "txtField txtInput";
                        ddlWidthInchSpecific.Attributes.Add("style", "width:50px");

                        for (int i = 0; i < fractionList.Count; i++)
                        {
                            ddlWidthInchSpecific.Items.Add(fractionList[i]);
                        }

                        RoofOptions.Controls.Add(widthLabel);
                        RoofOptions.Controls.Add(widthTextbox);
                        RoofOptions.Controls.Add(ddlWidthInchSpecific);

                        RoofOptions.Controls.Add(new LiteralControl("</li>"));

                        RoofOptions.Controls.Add(new LiteralControl("<li>"));

                        Label leftProjectionLabel = new Label();
                        leftProjectionLabel.ID = "lblLeftProjection" + title;
                        leftProjectionLabel.Text = "Left Projection: ";
                        leftProjectionLabel.AssociatedControlID = "txtLeftProjection" + title;
                        leftProjectionLabel.CssClass = "labelFormatting";

                        TextBox leftProjectionTextbox = new TextBox();
                        leftProjectionTextbox.ID = "txtLeftProjection" + title;
                        leftProjectionTextbox.CssClass = "txtField txtInput";
                        leftProjectionTextbox.MaxLength = 3;
                        leftProjectionTextbox.Attributes.Add("onblur", "validateDimensions('" + title + "')");
                        leftProjectionTextbox.ToolTip = "Left projection is the width of wall section under the left side of the gable roof";

                        DropDownList ddlProjectionLeftInchSpecific = new DropDownList();
                        ddlProjectionLeftInchSpecific.ID = "ddlProjectionLeftInchSpecific" + title;
                        ddlProjectionLeftInchSpecific.CssClass = "txtField txtInput";
                        ddlProjectionLeftInchSpecific.Attributes.Add("style", "width:50px");

                        for (int i = 0; i < fractionList.Count; i++)
                        {
                            ddlProjectionLeftInchSpecific.Items.Add(fractionList[i]);
                        }

                        RoofOptions.Controls.Add(leftProjectionLabel);
                        RoofOptions.Controls.Add(leftProjectionTextbox);
                        RoofOptions.Controls.Add(ddlProjectionLeftInchSpecific);

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
                        rightProjectionTextbox.MaxLength = 3;
                        rightProjectionTextbox.Attributes.Add("onblur", "validateDimensions('" + title + "')");
                        rightProjectionTextbox.ToolTip = "Right projection is the width of wall section under the right side of the gable roof";

                        DropDownList ddlProjectionRightInchSpecific = new DropDownList();
                        ddlProjectionRightInchSpecific.ID = "ddlProjectionRightInchSpecific" + title;
                        ddlProjectionRightInchSpecific.CssClass = "txtField txtInput";
                        ddlProjectionRightInchSpecific.Attributes.Add("style", "width:50px");

                        for (int i = 0; i < fractionList.Count; i++)
                        {
                            ddlProjectionRightInchSpecific.Items.Add(fractionList[i]);
                        }

                        RoofOptions.Controls.Add(rightProjectionLabel);
                        RoofOptions.Controls.Add(rightProjectionTextbox);
                        RoofOptions.Controls.Add(ddlProjectionRightInchSpecific);

                        RoofOptions.Controls.Add(new LiteralControl("</li>"));
                        
                    }
                    #endregion

                    #region Roof Number of Supports, Style Title, Gutter, and Fascia Options

                    if (roofStyle == 0)
                    {
                        RoofOptions.Controls.Add(new LiteralControl("<li id='liNumberOfSupports1" + title + "' style='display:inherit'>"));

                        Label numberOfSupportsLabel1 = new Label();
                        numberOfSupportsLabel1.ID = "lblNumberOfSupports1" + title;
                        numberOfSupportsLabel1.Text = "Number Of Supports: ";
                        numberOfSupportsLabel1.AssociatedControlID = "txtNumberOfSupports1" + title;
                        numberOfSupportsLabel1.CssClass = "labelFormatting";

                        TextBox numberOfSupportsTextbox1 = new TextBox();
                        numberOfSupportsTextbox1.ID = "txtNumberOfSupports1" + title;
                        numberOfSupportsTextbox1.Text = "0";
                        numberOfSupportsTextbox1.CssClass = "txtField txtInput";
                        numberOfSupportsTextbox1.MaxLength = 2;
                        numberOfSupportsTextbox1.Attributes.Add("style", "width:150px");
                        numberOfSupportsTextbox1.Attributes.Add("onkeyup", "displayButton('" + 1 + "','" + title + "')");
                        numberOfSupportsTextbox1.ToolTip = "This is the number of supports to hold up the studio roof";

                        DropDownList ddlRoofSupports1 = new DropDownList();
                        ddlRoofSupports1.ID = "ddlRoofSupports1" + title;
                        ddlRoofSupports1.CssClass = "txtField txtInput";
                        ddlRoofSupports1.Attributes.Add("style", "width:50px");
                        ddlRoofSupports1.Attributes.Add("onchange", "disableSelectedIndices('" + title + "')");

                        for (int i = 0; i < Constants.ROOF_SUPPORT_HEIGHTS.Length; i++)
                        {
                            ddlRoofSupports1.Items.Add(new ListItem(Constants.ROOF_SUPPORT_HEIGHTS[i] + "'", Constants.ROOF_SUPPORT_HEIGHTS[i]));
                        }

                        DropDownList ddlRoofSupportsType1 = new DropDownList();
                        ddlRoofSupportsType1.ID = "ddlRoofSupportsType1" + title;
                        ddlRoofSupportsType1.CssClass = "txtField txtInput";
                        ddlRoofSupportsType1.Attributes.Add("style", "width:100px");

                        for (int i = 0; i < Constants.ROOF_SUPPORT_TYPES.Length; i++)
                        {
                            ddlRoofSupportsType1.Items.Add(new ListItem(Constants.ROOF_SUPPORT_TYPES[i], Constants.ROOF_SUPPORT_TYPES[i]));
                        }

                        RoofOptions.Controls.Add(numberOfSupportsLabel1);
                        RoofOptions.Controls.Add(numberOfSupportsTextbox1);
                        RoofOptions.Controls.Add(ddlRoofSupports1);
                        RoofOptions.Controls.Add(ddlRoofSupportsType1);
                        RoofOptions.Controls.Add(new LiteralControl("<br/>"));
                        RoofOptions.Controls.Add(new LiteralControl("<input type='button' id='btnAddAnotherSize1" + title + "' value='Add Another Support Size' class='btnSubmit' style='display:none' onclick='displayMoreSizes(\"" + 2 + "\", \"" + title + "\")' title='This will open new textboxes for other sized supports'>"));                        

                        RoofOptions.Controls.Add(new LiteralControl("</li>"));

                        RoofOptions.Controls.Add(new LiteralControl("<li id='liNumberOfSupports2" + title + "' style='display:none'>"));

                        Label numberOfSupportsLabel2 = new Label();
                        numberOfSupportsLabel2.ID = "lblNumberOfSupports2" + title;
                        numberOfSupportsLabel2.Text = "Number Of Supports: ";
                        numberOfSupportsLabel2.AssociatedControlID = "txtNumberOfSupports2" + title;
                        numberOfSupportsLabel2.CssClass = "labelFormatting";

                        TextBox numberOfSupportsTextbox2 = new TextBox();
                        numberOfSupportsTextbox2.ID = "txtNumberOfSupports2" + title;
                        numberOfSupportsTextbox2.CssClass = "txtField txtInput";
                        numberOfSupportsTextbox2.MaxLength = 2;
                        numberOfSupportsTextbox2.Attributes.Add("style", "width:150px");
                        numberOfSupportsTextbox2.ToolTip = "This is the number of supports to hold up the studio roof";

                        DropDownList ddlRoofSupports2 = new DropDownList();
                        ddlRoofSupports2.ID = "ddlRoofSupports2" + title;
                        ddlRoofSupports2.CssClass = "txtField txtInput";
                        ddlRoofSupports2.Attributes.Add("style", "width:50px");
                        ddlRoofSupports2.Attributes.Add("onchange", "disableSelectedIndices('" + title + "')");

                        for (int i = 0; i < Constants.ROOF_SUPPORT_HEIGHTS.Length; i++)
                        {
                            ddlRoofSupports2.Items.Add(new ListItem(Constants.ROOF_SUPPORT_HEIGHTS[i] + "'", Constants.ROOF_SUPPORT_HEIGHTS[i]));
                        }

                        DropDownList ddlRoofSupportsType2 = new DropDownList();
                        ddlRoofSupportsType2.ID = "ddlRoofSupportsType2" + title;
                        ddlRoofSupportsType2.CssClass = "txtField txtInput";
                        ddlRoofSupportsType2.Attributes.Add("style", "width:100px");

                        for (int i = 0; i < Constants.ROOF_SUPPORT_TYPES.Length; i++)
                        {
                            ddlRoofSupportsType2.Items.Add(new ListItem(Constants.ROOF_SUPPORT_TYPES[i], Constants.ROOF_SUPPORT_TYPES[i]));
                        }

                        RoofOptions.Controls.Add(numberOfSupportsLabel2);
                        RoofOptions.Controls.Add(numberOfSupportsTextbox2);
                        RoofOptions.Controls.Add(ddlRoofSupports2);
                        RoofOptions.Controls.Add(ddlRoofSupportsType2);
                        RoofOptions.Controls.Add(new LiteralControl("<br/>"));
                        RoofOptions.Controls.Add(new LiteralControl("<input type='button' id='btnAddAnotherSize2" + title + "' value='Add Another Support Size' class='btnSubmit' onclick='displayMoreSizes(\"" + 3 + "\", \"" + title + "\")' title='This will open new textboxes for other sized supports'>"));
                        RoofOptions.Controls.Add(new LiteralControl("<input type='button' id='btnLessSizes2" + title + "' value='Less Support Sizes' class='btnSubmit' onclick='displayLessSizes(\"" + 2 + "\", \"" + title + "\"); disableSelectedIndices(\"" + title + "\")'>"));

                        RoofOptions.Controls.Add(new LiteralControl("</li>"));

                        RoofOptions.Controls.Add(new LiteralControl("<li id='liNumberOfSupports3" + title + "' style='display:none'>"));

                        Label numberOfSupportsLabel3 = new Label();
                        numberOfSupportsLabel3.ID = "lblNumberOfSupports3" + title;
                        numberOfSupportsLabel3.Text = "Number Of Supports: ";
                        numberOfSupportsLabel3.AssociatedControlID = "txtNumberOfSupports3" + title;
                        numberOfSupportsLabel3.CssClass = "labelFormatting";

                        TextBox numberOfSupportsTextbox3 = new TextBox();
                        numberOfSupportsTextbox3.ID = "txtNumberOfSupports3" + title;
                        numberOfSupportsTextbox3.CssClass = "txtField txtInput";
                        numberOfSupportsTextbox3.MaxLength = 2;
                        numberOfSupportsTextbox3.Attributes.Add("style", "width:150px");
                        numberOfSupportsTextbox3.ToolTip = "This is the number of supports to hold up the studio roof";

                        DropDownList ddlRoofSupports3 = new DropDownList();
                        ddlRoofSupports3.ID = "ddlRoofSupports3" + title;
                        ddlRoofSupports3.CssClass = "txtField txtInput";
                        ddlRoofSupports3.Attributes.Add("style", "width:50px");
                        ddlRoofSupports3.Attributes.Add("onchange", "disableSelectedIndices('" + title + "')");

                        for (int i = 0; i < Constants.ROOF_SUPPORT_HEIGHTS.Length; i++)
                        {
                            ddlRoofSupports3.Items.Add(new ListItem(Constants.ROOF_SUPPORT_HEIGHTS[i] + "'", Constants.ROOF_SUPPORT_HEIGHTS[i]));
                        }

                        DropDownList ddlRoofSupportsType3 = new DropDownList();
                        ddlRoofSupportsType3.ID = "ddlRoofSupportsType3" + title;
                        ddlRoofSupportsType3.CssClass = "txtField txtInput";
                        ddlRoofSupportsType3.Attributes.Add("style", "width:100px");

                        for (int i = 0; i < Constants.ROOF_SUPPORT_TYPES.Length; i++)
                        {
                            ddlRoofSupportsType3.Items.Add(new ListItem(Constants.ROOF_SUPPORT_TYPES[i], Constants.ROOF_SUPPORT_TYPES[i]));
                        }

                        RoofOptions.Controls.Add(numberOfSupportsLabel3);
                        RoofOptions.Controls.Add(numberOfSupportsTextbox3);
                        RoofOptions.Controls.Add(ddlRoofSupports3);
                        RoofOptions.Controls.Add(ddlRoofSupportsType3);
                        RoofOptions.Controls.Add(new LiteralControl("<br/>"));
                        RoofOptions.Controls.Add(new LiteralControl("<input type='button' id='btnAddAnotherSize3" + title + "' value='Add Another Support Size' class='btnSubmit' onclick='displayMoreSizes(\"" + 4 + "\", \"" + title + "\")' title='This will open new textboxes for other sized supports'>"));
                        RoofOptions.Controls.Add(new LiteralControl("<input type='button' id='btnLessSizes3" + title + "' value='Less Support Sizes' class='btnSubmit' onclick='displayLessSizes(\"" + 3 + "\", \"" + title + "\")'>"));

                        RoofOptions.Controls.Add(new LiteralControl("</li>"));

                        RoofOptions.Controls.Add(new LiteralControl("<li id='liNumberOfSupports4" + title + "' style='display:none'>"));

                        Label numberOfSupportsLabel4 = new Label();
                        numberOfSupportsLabel4.ID = "lblNumberOfSupports4" + title;
                        numberOfSupportsLabel4.Text = "Number Of Supports: ";
                        numberOfSupportsLabel4.AssociatedControlID = "txtNumberOfSupports4" + title;
                        numberOfSupportsLabel4.CssClass = "labelFormatting";

                        TextBox numberOfSupportsTextbox4 = new TextBox();
                        numberOfSupportsTextbox4.ID = "txtNumberOfSupports4" + title;
                        numberOfSupportsTextbox4.CssClass = "txtField txtInput";
                        numberOfSupportsTextbox4.MaxLength = 2;
                        numberOfSupportsTextbox4.Attributes.Add("style", "width:150px");
                        numberOfSupportsTextbox4.ToolTip = "This is the number of supports to hold up the studio roof";

                        DropDownList ddlRoofSupports4 = new DropDownList();
                        ddlRoofSupports4.ID = "ddlRoofSupports4" + title;
                        ddlRoofSupports4.CssClass = "txtField txtInput";
                        ddlRoofSupports4.Attributes.Add("style", "width:50px");
                        ddlRoofSupports4.Attributes.Add("onchange", "disableSelectedIndices('" + title + "')");

                        for (int i = 0; i < Constants.ROOF_SUPPORT_HEIGHTS.Length; i++)
                        {
                            ddlRoofSupports4.Items.Add(new ListItem(Constants.ROOF_SUPPORT_HEIGHTS[i] + "'", Constants.ROOF_SUPPORT_HEIGHTS[i]));
                        }

                        DropDownList ddlRoofSupportsType4 = new DropDownList();
                        ddlRoofSupportsType4.ID = "ddlRoofSupportsType4" + title;
                        ddlRoofSupportsType4.CssClass = "txtField txtInput";
                        ddlRoofSupportsType4.Attributes.Add("style", "width:100px");

                        for (int i = 0; i < Constants.ROOF_SUPPORT_TYPES.Length; i++)
                        {
                            ddlRoofSupportsType4.Items.Add(new ListItem(Constants.ROOF_SUPPORT_TYPES[i], Constants.ROOF_SUPPORT_TYPES[i]));
                        }

                        RoofOptions.Controls.Add(numberOfSupportsLabel4);
                        RoofOptions.Controls.Add(numberOfSupportsTextbox4);
                        RoofOptions.Controls.Add(ddlRoofSupports4);
                        RoofOptions.Controls.Add(ddlRoofSupportsType4);
                        RoofOptions.Controls.Add(new LiteralControl("<br/>"));
                        RoofOptions.Controls.Add(new LiteralControl("<input type='button' id='btnLessSizes4" + title + "' value='Less Support Sizes' class='btnSubmit' onclick='displayLessSizes(\"" + 4 + "\", \"" + title + "\")'>"));

                        RoofOptions.Controls.Add(new LiteralControl("</li>"));

                        RoofOptions.Controls.Add(new LiteralControl("<li>"));

                        Label gutterFasciaLabel = new Label();
                        gutterFasciaLabel.ID = "lblGutterFascia" + title;
                        gutterFasciaLabel.Text = "Gutter/Fascia Colours:";

                        RoofOptions.Controls.Add(gutterFasciaLabel);

                        RoofOptions.Controls.Add(new LiteralControl("</li>"));

                        RoofOptions.Controls.Add(new LiteralControl("<li>"));

                        DropDownList ddlGutterColours = new DropDownList();
                        ddlGutterColours.ID = "ddlGutterColours" + title;
                        ddlGutterColours.CssClass = "txtField txtInput";

                        for (int i = 0; i < Constants.GUTTER_COLOUR.Length; i++)
                        {
                            ddlGutterColours.Items.Add(new ListItem(Constants.GUTTER_COLOUR[i], Constants.GUTTER_COLOUR[i]));
                        }

                        RoofOptions.Controls.Add(ddlGutterColours);

                        RoofOptions.Controls.Add(new LiteralControl("</li>"));

                        RoofOptions.Controls.Add(new LiteralControl("<li>"));

                        RadioButton gutterYesRadio = new RadioButton();
                        gutterYesRadio.ID = "radGutterYes" + title;
                        gutterYesRadio.GroupName = "roofGutterRadios" + title;

                        Label gutterYesLabelRadio = new Label();
                        gutterYesLabelRadio.AssociatedControlID = "radGutterYes" + title;

                        Label gutterYesLabel = new Label();
                        gutterYesLabel.AssociatedControlID = "radGutterYes" + title;
                        gutterYesLabel.Text = "Yes";

                        RoofOptions.Controls.Add(gutterYesRadio);
                        RoofOptions.Controls.Add(gutterYesLabelRadio);
                        RoofOptions.Controls.Add(gutterYesLabel);

                        #region Gutter Options
                        RoofOptions.Controls.Add(new LiteralControl("<div class=\"toggleContent\">"));

                        RoofOptions.Controls.Add(new LiteralControl("<ul>"));

                        //RoofOptions.Controls.Add(new LiteralControl("<li>"));

                        //CheckBox roofBuiltIntoOverhangCHK = new CheckBox();
                        //roofBuiltIntoOverhangCHK.ID = "chkRoofBuiltIntoOverhang" + title;
                        //Label roofBuiltIntoOverhangLBLCheck = new Label();
                        //roofBuiltIntoOverhangLBLCheck.ID = "lblBuiltIntoOverhangCheck" + title;
                        //roofBuiltIntoOverhangLBLCheck.AssociatedControlID = "chkRoofBuiltIntoOverhang" + title;
                        //Label roofBuiltIntoOverhangLBL = new Label();
                        //roofBuiltIntoOverhangLBL.ID = "lblBuiltIntoOverhang" + title + radioTitle;
                        //roofBuiltIntoOverhangLBL.AssociatedControlID = "chkRoofBuiltIntoOverhang" + title;
                        //roofBuiltIntoOverhangLBL.Text = "Built Into Overhang";

                        //RoofOptions.Controls.Add(roofBuiltIntoOverhangCHK);
                        //RoofOptions.Controls.Add(roofBuiltIntoOverhangLBLCheck);
                        //RoofOptions.Controls.Add(roofBuiltIntoOverhangLBL);

                        //RoofOptions.Controls.Add(new LiteralControl("</li>"));

                        RoofOptions.Controls.Add(new LiteralControl("<li>"));

                        CheckBox roofGutterProGuttersCHK = new CheckBox();
                        roofGutterProGuttersCHK.ID = "chkRoofGutterProGutters" + title;
                        Label roofGutterProGuttersLBLCheck = new Label();
                        roofGutterProGuttersLBLCheck.ID = "lblGutterProGuttersCheck" + title;
                        roofGutterProGuttersLBLCheck.AssociatedControlID = "chkRoofGutterProGutters" + title;
                        Label roofGutterProGuttersLBL = new Label();
                        roofGutterProGuttersLBL.ID = "lblGutterProGutters" + title;
                        roofGutterProGuttersLBL.AssociatedControlID = "chkRoofGutterProGutters" + title;
                        roofGutterProGuttersLBL.Text = "Gutter Pro Gutters";

                        RoofOptions.Controls.Add(roofGutterProGuttersCHK);
                        RoofOptions.Controls.Add(roofGutterProGuttersLBLCheck);
                        RoofOptions.Controls.Add(roofGutterProGuttersLBL);

                        RoofOptions.Controls.Add(new LiteralControl("</li>"));

                        RoofOptions.Controls.Add(new LiteralControl("<li>"));

                        Label lblExtraDownspouts = new Label();
                        lblExtraDownspouts.ID = "lblExtraDownspouts" + title;
                        lblExtraDownspouts.Text = "Extra Downspouts: ";
                        lblExtraDownspouts.AssociatedControlID = "ddlExtraDownspouts" + title;

                        DropDownList ddlExtraDownspouts = new DropDownList();
                        ddlExtraDownspouts.ID = "ddlExtraDownspouts" + title;
                        ddlExtraDownspouts.CssClass = "txtField txtInput";

                        for (int i = 0; i <= 10; i++)
                        {
                            ddlExtraDownspouts.Items.Add(new ListItem(i.ToString(), i.ToString()));
                        }

                        RoofOptions.Controls.Add(lblExtraDownspouts);
                        RoofOptions.Controls.Add(ddlExtraDownspouts);

                        RoofOptions.Controls.Add(new LiteralControl("</li>"));

                        RoofOptions.Controls.Add(new LiteralControl("</ul>"));

                        RoofOptions.Controls.Add(new LiteralControl("</div>"));
                        #endregion

                        RoofOptions.Controls.Add(new LiteralControl("</li>"));

                        RoofOptions.Controls.Add(new LiteralControl("<li>"));

                        RadioButton gutterNoRadio = new RadioButton();
                        gutterNoRadio.ID = "radGutterNo" + title + radioTitle;
                        gutterNoRadio.GroupName = "roofGutterRadios" + title;
                        gutterNoRadio.Checked = true;

                        Label gutterNoLabelRadio = new Label();
                        gutterNoLabelRadio.AssociatedControlID = "radGutterNo" + title + radioTitle;

                        Label gutterNoLabel = new Label();
                        gutterNoLabel.AssociatedControlID = "radGutterNo" + title + radioTitle;
                        gutterNoLabel.Text = "No";

                        RoofOptions.Controls.Add(gutterNoRadio);
                        RoofOptions.Controls.Add(gutterNoLabelRadio);
                        RoofOptions.Controls.Add(gutterNoLabel);

                        RoofOptions.Controls.Add(new LiteralControl("</li>"));

                        RoofOptions.Controls.Add(new LiteralControl("<li>"));

                        Label styleTitleLabel = new Label();
                        styleTitleLabel.ID = "lblStyle" + title + radioTitle;
                        styleTitleLabel.Text = "Roof Styles:";

                        RoofOptions.Controls.Add(styleTitleLabel);

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

                    #region Panel Thickness DropDown, Cells, and Row Declarations
                    TableRow roofPanelThicknessRow = new TableRow();
                    TableCell roofPanelThicknessLBLCell = new TableCell();
                    TableCell roofPanelThicknessDDLCell = new TableCell();

                    Label roofPanelThicknessLBL = new Label();
                    roofPanelThicknessLBL.ID = "lblRoofPanelThickness" + title + radioTitle;
                    roofPanelThicknessLBL.Text = "Panel Thicknesses: ";

                    DropDownList roofPanelThicknessDDL = new DropDownList();
                    roofPanelThicknessDDL.ID = "ddlRoofPanelThickness" + title + radioTitle;
                    #endregion

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

                        TableRow roofPanelTypeRow = new TableRow();
                        TableCell roofPanelTypeLBLCell = new TableCell();
                        TableCell roofPanelTypeDDLCell = new TableCell();

                        Label panelTypeLabel = new Label();
                        panelTypeLabel.ID = "lblPanelType" + title;
                        panelTypeLabel.Text = "Panel Type: ";
                        panelTypeLabel.AssociatedControlID = "ddlPanelType" + title;
                        panelTypeLabel.CssClass = "labelFormatting";

                        DropDownList panelTypeDropDown = new DropDownList();
                        panelTypeDropDown.ID = "ddlPanelType" + title;
                        panelTypeDropDown.CssClass = "txtField txtInput";

                        for (int i = 0; i < Constants.ROOF_EXTRUSION_TYPE.Length; i++)
                        {
                            panelTypeDropDown.Items.Add(new ListItem(Constants.ROOF_EXTRUSION_TYPE[i], Constants.ROOF_EXTRUSION_TYPE[i]));
                        }

                        roofPanelTypeLBLCell.Controls.Add(panelTypeLabel);

                        roofPanelTypeDDLCell.Controls.Add(panelTypeDropDown);

                        tblRoofDetails.Rows.Add(roofPanelTypeRow);

                        roofPanelTypeRow.Cells.Add(roofPanelTypeLBLCell);

                        roofPanelTypeRow.Cells.Add(roofPanelTypeDDLCell);

                        TableRow roofInteriorSkinRow = new TableRow();
                        TableCell roofInteriorSkinLBLCell = new TableCell();
                        TableCell roofInteriorSkinDDLCell = new TableCell();

                        Label interiorSkinLabel = new Label();
                        interiorSkinLabel.ID = "lblInteriorSkin" + title;
                        interiorSkinLabel.Text = "Interior Skin: ";
                        interiorSkinLabel.AssociatedControlID = "ddlInteriorSkin" + title;
                        interiorSkinLabel.CssClass = "labelFormatting";

                        DropDownList interiorSkinDropDown = new DropDownList();
                        interiorSkinDropDown.ID = "ddlInteriorSkin" + title;
                        interiorSkinDropDown.CssClass = "txtField txtInput";

                        for (int i = 0; i < Constants.ROOF_INTERIOR_SKIN_TYPES.Length; i++)
                        {
                            interiorSkinDropDown.Items.Add(new ListItem(Constants.ROOF_INTERIOR_SKIN_TYPES[i], Constants.ROOF_INTERIOR_SKIN_TYPES[i]));
                        }

                        roofInteriorSkinLBLCell.Controls.Add(interiorSkinLabel);

                        roofInteriorSkinDDLCell.Controls.Add(interiorSkinDropDown);

                        tblRoofDetails.Rows.Add(roofInteriorSkinRow);

                        roofInteriorSkinRow.Cells.Add(roofInteriorSkinLBLCell);

                        roofInteriorSkinRow.Cells.Add(roofInteriorSkinDDLCell);

                        TableRow roofExteriorSkinRow = new TableRow();
                        TableCell roofExteriorSkinLBLCell = new TableCell();
                        TableCell roofExteriorSkinDDLCell = new TableCell();

                        Label exteriorSkinLabel = new Label();
                        exteriorSkinLabel.ID = "lblExteriorSkin" + title;
                        exteriorSkinLabel.Text = "Exterior Skin: ";
                        exteriorSkinLabel.AssociatedControlID = "ddlExteriorSkin" + title;
                        exteriorSkinLabel.CssClass = "labelFormatting";

                        DropDownList exteriorSkinDropDown = new DropDownList();
                        exteriorSkinDropDown.ID = "ddlExteriorSkin" + title;
                        exteriorSkinDropDown.CssClass = "txtField txtInput";

                        for (int i = 0; i < Constants.ROOF_EXTERIOR_SKIN_TYPES.Length; i++)
                        {
                            exteriorSkinDropDown.Items.Add(new ListItem(Constants.ROOF_EXTERIOR_SKIN_TYPES[i], Constants.ROOF_EXTERIOR_SKIN_TYPES[i]));
                        }

                        roofExteriorSkinLBLCell.Controls.Add(exteriorSkinLabel);

                        roofExteriorSkinDDLCell.Controls.Add(exteriorSkinDropDown);

                        tblRoofDetails.Rows.Add(roofExteriorSkinRow);

                        roofExteriorSkinRow.Cells.Add(roofExteriorSkinLBLCell);

                        roofExteriorSkinRow.Cells.Add(roofExteriorSkinDDLCell);

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

                    #region Panel Thickness DropDown, Cells, Row being added to the table
                    roofPanelThicknessLBLCell.Controls.Add(roofPanelThicknessLBL);

                    roofPanelThicknessDDLCell.Controls.Add(roofPanelThicknessDDL);

                    tblRoofDetails.Rows.Add(roofPanelThicknessRow);

                    roofPanelThicknessRow.Cells.Add(roofPanelThicknessLBLCell);

                    roofPanelThicknessRow.Cells.Add(roofPanelThicknessDDLCell);
                    #endregion

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
                Roof aRoof = new Roof();

                if (Request.Form["ctl00$MainContent$roofTypeRadios"] == "radTypeStudio")
                {
                    aRoof = buildStudioRoof();
                }
                else if (Request.Form["ctl00$MainContent$roofTypeRadios"] == "radTypeGable") 
                {
                    aRoof = buildGableRoof();
                }

                Session["completedRoof"] = aRoof;
            }
            #endregion
        }

        private List<RoofSupport> buildRoofSupports(int amount, int size, string type){
            List<RoofSupport> supportList = new List<RoofSupport>();

            int width = type == "Fluted" ? Constants.ROOF_SUPPORT_FLUTED_SIZE : Constants.ROOF_SUPPORT_RAILING_SIZE;

            RoofSupport aSupport = new RoofSupport(size, 3, type);

            for (int i = 0; i < amount; i++) {
                supportList.Add(aSupport);
            }

            return supportList;
        }

        private RoofModule buildStudioRoofModule(float roofProjection, float roofWidth)
        {
            //Variables that will be used to build the roof module
            float panelWidth;
            string panelBeamType;
            string panelType;
            float panelBeamWidth;
            float numberOfPanels;
            float itemWidthTotal;
            List<RoofItem> itemList = new List<RoofItem>();
            List<RoofModule> moduleList = new List<RoofModule>();
            string roofStyle = Request.Form["ctl00$MainContent$roofStyleRadiosStudio"];   
            //float roofFrontHeight = float.Parse(Request.Form["ctl00$MainContent$txtFrontHeightStudio"]);    //May not be needed since no slope is required
            //float roofBackHeight = float.Parse(Request.Form["ctl00$MainContent$txtBackHeightStudio"]);      //May not be needed since no slope is required
            string panelExteriorSkin;
            string panelInteriorSkin;

            if (roofStyle == "Alum. Skin or O.S.B.")
            {
                panelType = Request.Form["ctl00$MainContent$ddlPanelTypeStudio"];
                panelExteriorSkin = Request.Form["ctl00$MainContent$ddlExteriorSkinStudio"];
                panelInteriorSkin = Request.Form["ctl00$MainContent$ddlInteriorSkinStudio"];
            }
            else 
            {
                panelType = "Pressure Cap";
                if (roofStyle == "Thermadeck System")
                {
                    //Thermadeck systems must be osb/osb
                    panelExteriorSkin = "OSB";
                    panelInteriorSkin = "OSB";
                }
                else 
                {
                    panelExteriorSkin = Request.Form["ctl00$MainContent$ddlExteriorSkinStudio"];
                    panelInteriorSkin = Request.Form["ctl00$MainContent$ddlInteriorSkinStudio"];
                }
            }
                        
            if (panelType.Contains("I-Beam"))
            {
                panelBeamType = "I-Beam";
                panelBeamWidth = Constants.ROOF_IBEAM_WIDTH;
            }
            else if (panelType.Contains("Pressure Cap"))
            {
                panelBeamType = "Pressure Cap";
                panelBeamWidth = Constants.ROOF_PRESSURECAP_WIDTH;
            }
            else
            {
                panelBeamType = "Thermadeck";
                //Thermadeck uses wood underneath the panels, so there is essentially no width to seperator beams
                panelBeamWidth = 0f;
            }     

            if (roofStyle == "Alum. Skin or O.S.B.")
            {
                panelWidth = Constants.FOAM_PANEL_WIDTH;
                panelType = "Foam Panel";
            }
            else if (roofStyle == "Acrylic T-Bar System")
            {
                panelBeamType = "T-Bar";
                panelWidth = Constants.ACRYLIC_PANEL_WIDTH;
                panelType = "Acrylic Panel";
            }
            else
            {
                panelBeamType = "None";
                panelWidth = Constants.THERMADECK_PANEL_WIDTH;
                panelType = "Thermadeck Panel";
            }

            numberOfPanels = (float)Math.Ceiling(roofWidth / panelWidth); //If it requires 'part' of a panel, that is essentially another panel, just cut. Cut will be handled later.

            if (roofStyle != "Thermadeck System")
            {
                //Add the first panel, because if we loop adding panel+seperator, we will end with one extra
                itemList.Add(new RoofItem(panelType, roofProjection, panelWidth, -1f, -1f));

                //loop adding seperator then panels, minus one iteration because one panel is already added
                for (int i = 0; i < (numberOfPanels - 1); i++)
                {
                    itemList.Add(new RoofItem(panelBeamType, roofProjection, (float)panelBeamWidth, -1f, -1f));
                    itemList.Add(new RoofItem(panelType, roofProjection, panelWidth, -1f, -1f));
                }
            }
            //if it is thermadeck
            else
            {
                for (int i = 0; i < numberOfPanels; i++)
                {
                    itemList.Add(new RoofItem(panelType, roofProjection, panelWidth, -1f, -1f));
                }
            }

            itemWidthTotal = 0;

            //Total width of items
            for (int i = 0; i < itemList.Count; i++)
            {
                itemWidthTotal += itemList[i].Width;
            }

            //If this width doesn't fit perfectly (is more than roof width) we'll need to make a cut on the last panel
            if (itemWidthTotal > roofWidth)
            {
                //at .count-1 to get last item, which should be the final panel
                //We subtract the difference that the panel exceeds to make the 'cut'
                itemList[itemList.Count - 1].Width -= (itemWidthTotal - roofWidth);
            }

            RoofModule aModule = new RoofModule(roofProjection, roofWidth, panelInteriorSkin, panelExteriorSkin, itemList);

            return aModule;
        }

        private List<RoofModule> buildGableRoofModule(float roofLeftProjection, float roofRightProjection, float roofWidth)
        {
            //Variables that will be used to build the roof module
            float panelWidth;
            string panelBeamType;
            string panelType;
            float panelBeamWidth;
            float numberOfPanels;
            float itemWidthTotal;
            float projectionLeft = roofLeftProjection;
            float projectionRight = roofRightProjection;
            List<RoofItem> itemList = new List<RoofItem>();
            List<RoofItem> gableList = new List<RoofItem>();
            List<RoofModule> moduleList = new List<RoofModule>();
            string roofStyle = Request.Form["ctl00$MainContent$roofStyleRadiosStudio"];
            //float roofFrontHeight = float.Parse(Request.Form["ctl00$MainContent$txtFrontHeightStudio"]);    //May not be needed since no slope is required
            //float roofBackHeight = float.Parse(Request.Form["ctl00$MainContent$txtBackHeightStudio"]);      //May not be needed since no slope is required
            string panelExteriorSkin;
            string panelInteriorSkin;

            if (roofStyle == "Alum. Skin or O.S.B.")
            {
                panelType = Request.Form["ctl00$MainContent$ddlPanelTypeStudio"];
                panelExteriorSkin = Request.Form["ctl00$MainContent$ddlExteriorSkinStudio"];
                panelInteriorSkin = Request.Form["ctl00$MainContent$ddlInteriorSkinStudio"];
            }
            else
            {
                panelType = "Pressure Cap";
                if (roofStyle == "Thermadeck System")
                {
                    //Thermadeck systems must be osb/osb
                    panelExteriorSkin = "OSB";
                    panelInteriorSkin = "OSB";
                }
                else
                {
                    panelExteriorSkin = Request.Form["ctl00$MainContent$ddlExteriorSkinStudio"];
                    panelInteriorSkin = Request.Form["ctl00$MainContent$ddlInteriorSkinStudio"];
                }
            }

            if (panelType.Contains("I-Beam"))
            {
                panelBeamType = "I-Beam";
                panelBeamWidth = Constants.ROOF_IBEAM_WIDTH;
            }
            else if (panelType.Contains("Pressure Cap"))
            {
                panelBeamType = "Pressure Cap";
                panelBeamWidth = Constants.ROOF_PRESSURECAP_WIDTH;
            }
            else
            {
                panelBeamType = "Thermadeck";
                //Thermadeck uses wood underneath the panels, so there is essentially no width to seperator beams
                panelBeamWidth = 0f;
            }

            if (roofStyle == "Alum. Skin or O.S.B.")
            {
                panelWidth = Constants.FOAM_PANEL_WIDTH;
                panelType = "Foam Panel";
            }
            else if (roofStyle == "Acrylic T-Bar System")
            {
                panelBeamType = "T-Bar";
                panelWidth = Constants.ACRYLIC_PANEL_WIDTH;
                panelType = "Acrylic Panel";
            }
            else
            {
                panelBeamType = "None";
                panelWidth = Constants.THERMADECK_PANEL_WIDTH;
                panelType = "Thermadeck Panel";
            }

            //build roof objects
            numberOfPanels = (float)Math.Ceiling(roofWidth / panelWidth); //If it requires 'part' of a panel, that is essentially another panel, just cut. Cut will be handled later.
            
            if (roofStyle != "Thermadeck")
            {
                //Add the first panel, because if we loop adding panel+seperator, we will end with one extra
                //We use roofProjection / 2 for the following, because this is just one side of the gable roof, thus half the projection
                itemList.Add(new RoofItem(panelType, projectionLeft, panelWidth, -1f, -1f));

                //loop adding seperator then panels, minus one iteration because one panel is already added
                for (int i = 0; i < (numberOfPanels - 1); i++)
                {
                    itemList.Add(new RoofItem(panelBeamType, projectionLeft, (float)panelBeamWidth, -1f, -1f));
                    itemList.Add(new RoofItem(panelType, projectionLeft, panelWidth, -1f, -1f));
                }
            }
            //if it is thermadeck
            else
            {
                for (int i = 0; i < numberOfPanels; i++)
                {
                    itemList.Add(new RoofItem(panelType, projectionLeft, panelWidth, -1f, -1f));
                }
            }
            itemWidthTotal = 0;

            //Total width of items
            for (int i = 0; i < itemList.Count; i++)
            {
                itemWidthTotal += itemList[i].Width;
            }

            //If this width doesn't fit perfectly (is more than roof width) we'll need to make a cut on the last panel
            if (itemWidthTotal > roofWidth)
            {
                //at .count-1 to get last item, which should be the final panel
                //We subtract the difference that the panel exceeds to make the 'cut'
                itemList[itemList.Count - 1].Width -= (itemWidthTotal - roofWidth);
            }

            if (roofStyle == "Thermadeck")
            {
                //Thermadeck systems must be osb/osb
                panelExteriorSkin = "OSB";
                panelInteriorSkin = "OSB";
            }

            moduleList = new List<RoofModule>();
            RoofModule aModule = new RoofModule(projectionLeft, roofWidth, panelInteriorSkin, panelExteriorSkin, itemList);
            moduleList.Add(aModule);

            //We make a second module with the reverse roof items, because the gable is mirrored on the other side
            for (int i = (itemList.Count - 1); i >= 0; i--)
            {
                gableList.Add(itemList[i]);
            }

            //Now set the duplication to their actual projections
            for (int i = 0; i < gableList.Count; i++)
            {
                gableList[i].Projection = projectionRight;
            }

            RoofModule aSecondModule = new RoofModule(projectionRight, roofWidth, panelInteriorSkin, panelExteriorSkin, gableList);

            moduleList.Add(aSecondModule);

            return moduleList;
        }

        private Roof buildStudioRoof() {
            Roof aRoof;

            bool isFireProtected = false;
            bool isThermadeck = false;
            bool hasGutters = false;
            bool gutterPro = false;

            int extraDownSpouts = int.Parse(Request.Form["ctl00$MainContent$ddlExtraDownspoutsStudio"]);
            float roofWidth = float.Parse(Request.Form["ctl00$MainContent$txtWidthStudio"]);
            float roofProjection = float.Parse(Request.Form["ctl00$MainContent$txtProjectionStudio"]);

            string roofSupportType = Request.Form["ctl00$MainContent$txtProjectionStudio"];
            List<RoofSupport> supportList = new List<RoofSupport>();

            for (int i = 1; i <= 4; i++)
            {
                if (Request.Form["ctl00$MainContent$txtNumberOfSupports" + i + "Studio"] != "")
                {
                    int roofSupports = int.Parse(Request.Form["ctl00$MainContent$txtNumberOfSupports" + Convert.ToString(i) + "Studio"]);
                    int roofSupportsSize = int.Parse(Request.Form["ctl00$MainContent$ddlRoofSupports" + Convert.ToString(i) + "Studio"]);

                    if (roofSupports != 0)
                        supportList.AddRange(buildRoofSupports(roofSupports, roofSupportsSize, roofSupportType));
                }
            }

            //float overhang = float.Parse(Request.Form["ctl00$MainContent$txtOverhangStudio"]);

            string stripeColour;
            string acrylicColour;

            string gutter = Request.Form["ctl00$MainContent$roofGutterRadios"];
            string gutterProField = Request.Form["ctl00$MainContent$chkRoofGutterProGuttersStudio"];
            string gutterColour = Request.Form["ctl00$MainContent$ddlGutterColoursStudio"];

            string roofStyle = Request.Form["ctl00$MainContent$roofStyleRadiosStudio"];

            float panelThickness;
            string panelExteriorSkin;
            string panelInteriorSkin;
            string panelType;

            if (roofStyle == "Alum. Skin or O.S.B.")
            {
                stripeColour = Request.Form["ctl00$MainContent$ddlRoofStripeColourStudioAlum. Skin or O.S.B."];
                acrylicColour = "";
                panelType = Request.Form["ctl00$MainContent$ddlPanelTypeStudio"];
                panelExteriorSkin = Request.Form["ctl00$MainContent$ddlExteriorSkinStudio"];
                panelInteriorSkin = Request.Form["ctl00$MainContent$ddlInteriorSkinStudio"];
                panelThickness = Convert.ToSingle(Request.Form["ctl00$MainContent$ddlRoofPanelThicknessStudioAlum. Skin or O.S.B."]);
            }
            else if (roofStyle == "Acrylic T-Bar System") 
            {
                stripeColour = "";
                acrylicColour = Request.Form["ctl00$MainContent$ddlRoofAcrylicColourStudioAcrylic T-Bar System"];
                panelType = "Pressure Cap";
                panelExteriorSkin = Request.Form["ctl00$MainContent$ddlExteriorSkinStudio"];
                panelInteriorSkin = Request.Form["ctl00$MainContent$ddlInteriorSkinStudio"];
                panelThickness = Convert.ToSingle(Request.Form["ctl00$MainContent$ddlRoofPanelThicknessStudioAcrylic T-Bar System"]);
            }
            else
            {
                stripeColour = "";
                acrylicColour = "";
                panelType = "Pressure Cap";
                //Thermadeck systems must be osb/osb
                panelExteriorSkin = "OSB";
                panelInteriorSkin = "OSB";
                panelThickness = Convert.ToSingle(Request.Form["ctl00$MainContent$ddlRoofPanelThicknessStudioThermadeck System"]);
            }

            //Calculate actual width and projection based on overhang value
            //roofProjection += (overhang);
            //roofWidth += (overhang * 2);

            //Now that we have roof rojection and width, add it to session.
            Session.Add("roofProjection", roofProjection);
            Session.Add("roofWidth", roofWidth);

            //A studio roof will only have one list entry, while a gable will have two
            List<RoofModule> aModuleList = new List<RoofModule>();
            aModuleList.Add(buildStudioRoofModule(roofProjection, roofWidth));
            
            if (panelType.Contains("FP"))
            {
                isFireProtected = true;
            }

            if (roofStyle == "Thermadeck System")
            {
                isThermadeck = true;
            }

            if (gutter == "radGutterYesStudio")
            {
                hasGutters = true;
            }
            
            if (gutterProField == "on")
            {
                gutterPro = true;
            }
            
            if (hasGutters == false)
            {
                gutterColour = "NA";
                extraDownSpouts = 0;
            }
            
            aRoof = new Roof("Studio", panelInteriorSkin, panelExteriorSkin, panelThickness, isFireProtected, isThermadeck, hasGutters, gutterPro, gutterColour, stripeColour, acrylicColour, extraDownSpouts, roofProjection, roofWidth, supportList, aModuleList);
            Session.Add("completedRoof", aRoof);

            Response.Redirect("WizardRoofOnlySkylight.aspx");

            return aRoof;
        }

        private Roof buildGableRoof()
        {
            Roof aRoof;

            bool isFireProtected = false;
            bool isThermadeck = false;
            bool hasGutters = false;
            bool gutterPro = false;

            int extraDownSpouts = int.Parse(Request.Form["ctl00$MainContent$ddlExtraDownspoutsGable"]);
            float roofWidth = float.Parse(Request.Form["ctl00$MainContent$txtWidthGable"]);
            float roofLeftProjection = float.Parse(Request.Form["ctl00$MainContent$txtLeftProjectionGable"]);
            float roofRightProjection = float.Parse(Request.Form["ctl00$MainContent$txtRightProjectionGable"]);
            float roofProjection;

            string roofSupportType = Request.Form["ctl00$MainContent$txtProjectionGable"];
            List<RoofSupport> supportList = new List<RoofSupport>();

            for (int i = 1; i <= 4; i++)
            {
                if (Request.Form["ctl00$MainContent$txtNumberOfSupports" + i + "Gable"] != "")
                {
                    int roofSupports = int.Parse(Request.Form["ctl00$MainContent$txtNumberOfSupports" + Convert.ToString(i) + "Gable"]);
                    int roofSupportsSize = int.Parse(Request.Form["ctl00$MainContent$ddlRoofSupports" + Convert.ToString(i) + "Gable"]);

                    if (roofSupports != 0)
                        supportList.AddRange(buildRoofSupports(roofSupports, roofSupportsSize, roofSupportType));
                }
            }

            //float overhang = float.Parse(Request.Form["ctl00$MainContent$txtOverhangGable"]);

            string stripeColour;
            string acrylicColour;

            string gutter = Request.Form["ctl00$MainContent$roofGutterRadios"];
            string gutterProField = Request.Form["ctl00$MainContent$chkRoofGutterProGuttersGable"];
            string gutterColour = Request.Form["ctl00$MainContent$ddlGutterColoursGable"];

            string roofStyle = Request.Form["ctl00$MainContent$roofStyleRadiosGable"];

            float panelThickness;
            string panelExteriorSkin;
            string panelInteriorSkin;
            string panelType;

            if (roofStyle == "Alum. Skin or O.S.B.")
            {
                stripeColour = Request.Form["ctl00$MainContent$ddlRoofStripeColourGableAlum. Skin or O.S.B."];
                acrylicColour = "";
                panelType = Request.Form["ctl00$MainContent$ddlPanelTypeGable"];
                panelExteriorSkin = Request.Form["ctl00$MainContent$ddlExteriorSkinGable"];
                panelInteriorSkin = Request.Form["ctl00$MainContent$ddlInteriorSkinGable"];
                panelThickness = Convert.ToSingle(Request.Form["ctl00$MainContent$ddlRoofPanelThicknessGableAlum. Skin or O.S.B."]);
            }
            else if (roofStyle == "Acrylic T-Bar System")
            {
                stripeColour = "";
                acrylicColour = Request.Form["ctl00$MainContent$ddlRoofAcrylicColourGableAcrylic T-Bar System"];
                panelType = "Pressure Cap";
                panelExteriorSkin = Request.Form["ctl00$MainContent$ddlExteriorSkinGable"];
                panelInteriorSkin = Request.Form["ctl00$MainContent$ddlInteriorSkinGable"];
                panelThickness = Convert.ToSingle(Request.Form["ctl00$MainContent$ddlRoofPanelThicknessGableAcrylic T-Bar System"]);
            }
            else
            {
                stripeColour = "";
                acrylicColour = "";
                panelType = "Pressure Cap";
                //Thermadeck systems must be osb/osb
                panelExteriorSkin = "OSB";
                panelInteriorSkin = "OSB";
                panelThickness = Convert.ToSingle(Request.Form["ctl00$MainContent$ddlRoofPanelThicknessGableThermadeck System"]);
            }

            Session.Add("roofLeftProjection", roofLeftProjection);
            Session.Add("roofRightProjection", roofRightProjection);
            Session.Add("roofWidth", roofWidth);

            //A studio roof will only have one list entry, while a gable will have two
            List<RoofModule> gableModules = buildGableRoofModule(roofLeftProjection, roofRightProjection, roofWidth);

            if (panelType.Contains("FP"))
            {
                isFireProtected = true;
            }

            if (roofStyle == "Thermadeck System")
            {
                isThermadeck = true;
            }

            if (gutter == "radGutterYesGable")
            {
                hasGutters = true;
            }

            if (gutterProField == "on")
            {
                gutterPro = true;
            }

            if (hasGutters == false)
            {
                gutterColour = "NA";
                extraDownSpouts = 0;
            }

            roofProjection = roofLeftProjection + roofRightProjection;

            //changeme hardcoded supports to 0
            aRoof = new Roof("Gable", panelInteriorSkin, panelExteriorSkin, panelThickness, isFireProtected, isThermadeck, hasGutters, gutterPro, gutterColour, stripeColour, acrylicColour, extraDownSpouts, roofProjection, roofWidth, supportList, gableModules);
            Session.Add("completedRoof", aRoof);

            Response.Redirect("WizardRoofOnlySkylight.aspx");

            return aRoof;
        }
    }
}
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
        protected List<Wall> walls = new List<Wall>();

        protected const float DOOR_MAX_WIDTH = Constants.CUSTOM_DOOR_MAX_WIDTH;
        protected const float DOOR_MIN_WIDTH = Constants.CUSTOM_DOOR_MIN_WIDTH;
        protected const float DOOR_FRENCH_MIN_WIDTH = Constants.CUSTOM_FRENCH_DOOR_MIN_WIDTH;
        protected const float DOOR_FRENCH_MAX_WIDTH = Constants.CUSTOM_FRENCH_DOOR_MAX_WIDTH;

        //ListItems to be used in multiple dropdown lists for decimal points
        //This should eventually be stored in the constants file
        protected ListItem lst0 = new ListItem("---", "", true); //0, i.e. no decimal value, selected by default
        protected ListItem lst18 = new ListItem("1/8", ".125");
        protected ListItem lst14 = new ListItem("1/4", ".25");
        protected ListItem lst38 = new ListItem("3/8", ".375");
        protected ListItem lst12 = new ListItem("1/2", ".5");
        protected ListItem lst58 = new ListItem("5/8", ".625");
        protected ListItem lst34 = new ListItem("3/4", ".75");
        protected ListItem lst78 = new ListItem("7/8", ".875");


        protected string currentModel = "M200";
        protected float sofftLength = 0;

        protected const int SUGGESTED_DEFAULT_FILLER = 2;
        protected const int PREFERRED_DEFAULT_FILLER = 0;

        /***hard coded variables***/
        string coordList; //to store the string from the session and store it in a local variable for further use                                    
        char[] lineDelimiter = { '/' }; //character(s) that seperate lines in a session string variable
        char[] detailsDelimiter = { ',' }; //character(s) that seperate details of each line                                 
        string[] strWalls; //to split the string received from session and store it into an array of strings with individual line details
        string[,] wallDetails; //a two dimensional array to store the the details of each line individually as seperate elements ... 6 represents the number of detail items for each line

        protected void Page_Load(object sender, EventArgs e)
        {
            /***hard coded variables***/
            Session["coordList"] = "100,412.5,137.5,137.5,E,S/150,150,137.5,287.5,P,W/150,225,287.5,362.5,P,SW/225,312.5,362.5,362.5,P,S/312,387.5,362.5,287.5,P,SE/387.5,387.5,287.5,137.5,P,E/";
            //Session["coordList"] = "112.5,350,112.5,112.5,E,S/350,350,112.5,337.5,E,W/175,175,112.5,262.5,P,W/175,350,262.5,262.5,P,S/";
            coordList = (string)Session["coordList"]; //get the string from the session and store it in a local variable for further use                                    
            strWalls = coordList.Split(lineDelimiter, StringSplitOptions.RemoveEmptyEntries); //split the string received from session and store it into an array of strings with individual line details
            wallDetails = new string[strWalls.Count(),6]; //a two dimensional array to store the the details of each line individually as seperate elements ... 6 represents the number of detail items for each line
            
            int existingWallCount = 0; //used to determine how many existing walls are in a drawing 
            int proposedWallCount = 0; //used to determine how many proposed walls are in a drawing

            //populate the array with all the wall details for each wall
            for (int i = 0; i < strWalls.Count(); i++) //run through all the walls in the array
            {
                string[] tempDetails = strWalls[i].Split(detailsDelimiter, StringSplitOptions.RemoveEmptyEntries); //split the given wall string into its individual detail items and store it in temporary array

                for (int j = 0; j < tempDetails.Count(); j++) //for each item in the tempDetails array
                {
                    wallDetails[i, j] = tempDetails[j]; //store it in the appropriate spot for the appropriate line in the wallDetails array 
                }
            }
            
            hiddenFieldsDiv.InnerHtml = createHiddenFields(strWalls.Count()); //create hidden fields on page load dynamically, pass it number of walls

            #region DropDownList Section
            DropDownList ddlInFrac = new DropDownList(); //a dropdown list for length inch fractions
            DropDownList ddlInFracBackWall = new DropDownList(); //a dropdown list for back wall inch fractions
            DropDownList ddlInFracFrontWall = new DropDownList(); //a dropdown list for front wall inch fractions

            //add all the inch fraction list items to the lengths dropdown list 
            ddlInFrac.Items.Add(lst0);
            ddlInFrac.Items.Add(lst18);
            ddlInFrac.Items.Add(lst14);
            ddlInFrac.Items.Add(lst38);
            ddlInFrac.Items.Add(lst12);
            ddlInFrac.Items.Add(lst58);
            ddlInFrac.Items.Add(lst34);
            ddlInFrac.Items.Add(lst78);
            
            //add all the inch fraction list items to the back wall dropdown list 
            ddlInFracBackWall.Items.Add(lst0); 
            ddlInFracBackWall.Items.Add(lst18);
            ddlInFracBackWall.Items.Add(lst14);
            ddlInFracBackWall.Items.Add(lst38);
            ddlInFracBackWall.Items.Add(lst12);
            ddlInFracBackWall.Items.Add(lst58);
            ddlInFracBackWall.Items.Add(lst34);
            ddlInFracBackWall.Items.Add(lst78);
            ddlInFracBackWall.ID = "ddlBackInchFractions"; //give the dropdown list an ID
            ddlInFracBackWall.Attributes.Add("onchange", "checkQuestion2()"); //set its attributes to validate question2 when its changed
            phBackHeights.Controls.Add(ddlInFracBackWall); //add it to the placeholder field in the table

            //add all the inch fraction list items to the front wall dropdown list
            ddlInFracFrontWall.Items.Add(lst0);
            ddlInFracFrontWall.Items.Add(lst18);
            ddlInFracFrontWall.Items.Add(lst14);
            ddlInFracFrontWall.Items.Add(lst38);
            ddlInFracFrontWall.Items.Add(lst12);
            ddlInFracFrontWall.Items.Add(lst58);
            ddlInFracFrontWall.Items.Add(lst34);
            ddlInFracFrontWall.Items.Add(lst78);
            ddlInFracFrontWall.ID = "ddlFrontInchFractions"; //give the dropdown list an ID
            ddlInFracFrontWall.Attributes.Add("onchange", "checkQuestion2()"); //set its attributes to validate question2 when its changed
            phFrontHeights.Controls.Add(ddlInFracFrontWall);//add it to the placeholder field in the table
            #endregion

            
           
            

            #region For Loop for slide 1 and slide3            

            for (int i = 1; i <= strWalls.Count(); i++) //for each wall in walls 
            {
                #region Slide1/Question1 Table
                
                if (wallDetails[i - 1, 4] == "E") //wall type is existing
                {
                    existingWallCount++; //increment the existing wall counter
                    populateTblExisting(i, existingWallCount); //populate the existing walls table on slide 1
                }
                else //wall type is proposed
                {
                    proposedWallCount++; //increment the proposed wall counter
                    populateTblProposed(i, proposedWallCount); //populate the proposed walls table on slide 1
                }
                #endregion
            }
            #endregion

            

        }

        /// <summary>
        /// This method is used to dynamically populate the table for existing walls on slide/question 1.
        /// It creates table a table row and cells and appends appropriate input fields to each cell for user input,
        ///     and gives each input field appropriate values
        /// </summary>
        /// <param name="i">index of the given wall, used to give appropriate ID's to input fields</param>
        /// <param name="existingWallCount">used to give appropriate values to the wall name labels</param>
        protected void populateTblExisting(int i, int existingWallCount)
        {
            TableRow row = new TableRow(); //new table to to be appended to the table with all the appropriate fields in it
            
            TableCell cell1 = new TableCell(); //new table cell to store the wall name label
            TableCell cell2 = new TableCell(); //new table cell to store the textbox
            TableCell cell3 = new TableCell(); //new table cell to store the dropdown list
            
            Label lblWallNumber = new Label(); //new label to display the wall name/number

            TextBox txtWallLength = new TextBox(); //new textbox for user input for length
            
            DropDownList ddlInchFractions = new DropDownList(); //new dropdown list for length inch fractions

            //add the inch fraction list items to the dropdown list
            ddlInchFractions.Items.Add(lst0);
            ddlInchFractions.Items.Add(lst18);
            ddlInchFractions.Items.Add(lst14);
            ddlInchFractions.Items.Add(lst38);
            ddlInchFractions.Items.Add(lst12);
            ddlInchFractions.Items.Add(lst58);
            ddlInchFractions.Items.Add(lst34);
            ddlInchFractions.Items.Add(lst78);
            ddlInchFractions.Attributes.Add("onchange", "checkQuestion1()"); //give it an attribute to check question 1 on change

            lblWallNumber.Text = "Wall " + existingWallCount + " : "; //output wall name/number to the label
    
            ddlInchFractions.ID = "ddlWall" + i + "InchFractions"; //give an appropriate id to dropdown list
            lblWallNumber.ID = "lblWall" + i + "Length"; //give an appropriate id to the label
            lblWallNumber.AssociatedControlID = "txtWall" + i + "Length"; //set the label's associated control id

            txtWallLength.ID = "txtWall" + i + "Length"; //give an appropriate id to the textbox
            txtWallLength.CssClass = "txtField txtLengthInput"; //give the textbox a css class
            txtWallLength.MaxLength = 3; //set the max length of the textbox to prevent invalid input
            txtWallLength.Attributes.Add("onkeyup", "checkQuestion1()"); //set its attribute to check question 1 on key up
            txtWallLength.Attributes.Add("OnChange", "checkQuestion1()");//set its attribute to check question 1 on change
            txtWallLength.Attributes.Add("OnFocus", "highlightWallsLength()"); //set its attribute to highlight walls on focus
            txtWallLength.Attributes.Add("onblur", "resetWalls()"); //set its attribute to reset walls on blur

            cell1.Controls.Add(lblWallNumber); //append the label to cell 1
            cell2.Controls.Add(txtWallLength); //append the textbox to cell 2
            cell3.Controls.Add(ddlInchFractions); //append the dropdown to cell 3
            
            tblExistingWalls.Rows.Add(row); //append the row to the existing walls table

            //append all the cells to the row
            row.Cells.Add(cell1); 
            row.Cells.Add(cell2);
            row.Cells.Add(cell3);
        }

        /// <summary>
        /// This method is used to dynamically populate the table for proposed walls on slide/question 1.
        /// It creates table a table row and cells and appends appropriate input fields to each cell for user input,
        ///     and gives each input field appropriate values
        /// </summary>
        /// <param name="i">index of the given wall, used to give appropriate ID's to input fields</param>
        /// <param name="proposedWallCount">used to give appropriate values to the wall name labels</param>
        protected void populateTblProposed(int i, int proposedWallCount)
        {
            #region Table: Slide 1 Table Rows/Cells and Controls
            TableRow row = new TableRow();//new table to to be appended to the table with all the appropriate fields in it

            TableCell cell1 = new TableCell(); //new table cell to store the wall name label
            TableCell cell2 = new TableCell();//new table cell to store the textbox for left filler
            TableCell cell3 = new TableCell();//new table cell to store the dropdown list for left filler inch fractions
            TableCell cell4 = new TableCell();//new table cell to store the textbox length
            TableCell cell5 = new TableCell();//new table cell to store the dropdown list for length
            TableCell cell6 = new TableCell();//new table cell to store the textbox for right filler
            TableCell cell7 = new TableCell();//new table cell to store the dropdown list for right filler inch fractions

            Label lblWallNumber = new Label(); //new label to display the wall name/number

            TextBox txtWallLength = new TextBox(); //new textbox for user input for length
            TextBox txtLeftFiller = new TextBox(); //new textbox for user input for left filler
            TextBox txtRightFiller = new TextBox();//new textbox for user input for right filler

            DropDownList ddlInchFractions = new DropDownList(); //new dropdown list for length inch fractions
            DropDownList ddlLeftInchFractions = new DropDownList(); //new dropdown list for left filler inch fractions
            DropDownList ddlRightInchFractions = new DropDownList();//new dropdown list for right filler inch fractions

            //add the inch fraction list items to the dropdown list
            ddlInchFractions.Items.Add(lst0);
            ddlInchFractions.Items.Add(lst18);
            ddlInchFractions.Items.Add(lst14);
            ddlInchFractions.Items.Add(lst38);
            ddlInchFractions.Items.Add(lst12);
            ddlInchFractions.Items.Add(lst58);
            ddlInchFractions.Items.Add(lst34);
            ddlInchFractions.Items.Add(lst78);
            ddlInchFractions.Attributes.Add("onchange", "checkQuestion1()"); //give it an attribute to check question 1 on change

            //add the inch fraction list items to the dropdown list
            ddlLeftInchFractions.Items.Add(lst0);
            ddlLeftInchFractions.Items.Add(lst18);
            ddlLeftInchFractions.Items.Add(lst14);
            ddlLeftInchFractions.Items.Add(lst38);
            ddlLeftInchFractions.Items.Add(lst12);
            ddlLeftInchFractions.Items.Add(lst58);
            ddlLeftInchFractions.Items.Add(lst34);
            ddlLeftInchFractions.Items.Add(lst78);
            ddlLeftInchFractions.Attributes.Add("onchange", "checkQuestion1()"); //give it an attribute to check question 1 on change

            //add the inch fraction list items to the dropdown list
            ddlRightInchFractions.Items.Add(lst0);
            ddlRightInchFractions.Items.Add(lst18);
            ddlRightInchFractions.Items.Add(lst14);
            ddlRightInchFractions.Items.Add(lst38);
            ddlRightInchFractions.Items.Add(lst12);
            ddlRightInchFractions.Items.Add(lst58);
            ddlRightInchFractions.Items.Add(lst34);
            ddlRightInchFractions.Items.Add(lst78);
            ddlRightInchFractions.Attributes.Add("onchange", "checkQuestion1()"); //give it an attribute to check question 1 on change


            lblWallNumber.Text = "Wall " + proposedWallCount + " : "; //output wall name/number to the label

            ddlInchFractions.ID = "ddlWall" + i + "InchFractions"; //give an appropriate id to dropdown list for length
            lblWallNumber.ID = "lblWall" + i + "Length"; //give an appropriate id to label
            lblWallNumber.AssociatedControlID = "txtWall" + i + "Length"; //set the label's associated control id

            txtWallLength.ID = "txtWall" + i + "Length"; //give an appropriate id to the textbox
            txtWallLength.CssClass = "txtField txtLengthInput"; //give the textbox a css class
            txtWallLength.MaxLength = 3; //give the textbox a max length of 3 to prevent invalid input
            txtWallLength.Attributes.Add("onkeyup", "checkQuestion1()"); //set its attribute to check question 1 on key up
            txtWallLength.Attributes.Add("OnChange", "checkQuestion1()");//set its attribute to check question 1 on change
            txtWallLength.Attributes.Add("OnFocus", "highlightWallsLength()");//set its attribute to highlight walls on focus
            txtWallLength.Attributes.Add("onblur", "resetWalls()");//set its attribute to reset walls on blur

            ddlLeftInchFractions.ID = "ddlWall" + i + "LeftInchFractions"; //give an appropriate id to dropdown list for left filler
            ddlRightInchFractions.ID = "ddlWall" + i + "RightInchFractions";//give an appropriate id to dropdown list for right filler

            txtLeftFiller.ID = "txtWall" + i + "LeftFiller"; //give an appropriate id to the left filler textbox
            txtLeftFiller.CssClass = "txtField txtLengthInput"; //give the textbox a css class
            txtLeftFiller.MaxLength = 3; //set the max length of textbox to 3 to prevent invalid input
            txtLeftFiller.Text = SUGGESTED_DEFAULT_FILLER.ToString();
            txtLeftFiller.Attributes.Add("onkeyup", "checkQuestion1()"); //set its attribute to check question 1 on key up
            txtLeftFiller.Attributes.Add("OnChange", "checkQuestion1()");//set its attribute to check question 1 on change
            txtLeftFiller.Attributes.Add("OnFocus", "highlightWallsLength()");//set its attribute to highlight walls on focus
            txtLeftFiller.Attributes.Add("onblur", "resetWalls()");//set its attribute to reset walls on blur

            txtRightFiller.ID = "txtWall" + i + "RightFiller";//give an appropriate id to the right filler textbox
            txtRightFiller.CssClass = "txtField txtLengthInput"; //give the textbox a css class
            txtRightFiller.MaxLength = 3; //set the max length of textbox to 3 to prevent invalid input
            txtRightFiller.Text = SUGGESTED_DEFAULT_FILLER.ToString();
            txtRightFiller.Attributes.Add("onkeyup", "checkQuestion1()");//set its attribute to check question 1 on key up
            txtRightFiller.Attributes.Add("OnChange", "checkQuestion1()");//set its attribute to check question 1 on change
            txtRightFiller.Attributes.Add("OnFocus", "highlightWallsLength()");//set its attribute to highlight walls on focus
            txtRightFiller.Attributes.Add("onblur", "resetWalls()");//set its attribute to check reset walls on blur            

            cell1.Controls.Add(lblWallNumber); //append the wall number/name label to cell 1
            cell2.Controls.Add(txtLeftFiller); //append the left filler textbox in cell 2
            cell3.Controls.Add(ddlLeftInchFractions); //append the left filler dropdown list in cell 3
            cell4.Controls.Add(txtWallLength); //append the wall length textbox in cell 4
            cell5.Controls.Add(ddlInchFractions); //append the wall length dropdown list in cell 5
            cell6.Controls.Add(txtRightFiller); //append the right filler textbox in cell 6
            cell7.Controls.Add(ddlRightInchFractions); //append the right filler dropdown list in cell 7

            tblProposedWalls.Rows.Add(row); //append the row to the proposed walls table

            //append all the cells to the row
            row.Cells.Add(cell1); 
            row.Cells.Add(cell2);
            row.Cells.Add(cell3);
            row.Cells.Add(cell4);
            row.Cells.Add(cell5);
            row.Cells.Add(cell6);
            row.Cells.Add(cell7);
            #endregion

            //SLIDE 3 DOOR DETAILS PER WALL
            #region Slide 3: Onload dynamic loop to insert wall door options            

            #region Wall #:Radio button section
            //li tags created for every wall
            wallDoorOptions.Controls.Add(new LiteralControl("<li>"));

            //RadioButton created for every wall and its options
            RadioButton wallRadio = new RadioButton();
            wallRadio.ID = "radWall" + i;     //Giving an appropriate id to radio buttons based on current wall
            wallRadio.GroupName = "doorWallRadios";     //Giving an appropriate group name to all wall radio buttons

            //Label to create clickable area for radio button
            Label wallLabelRadio = new Label();
            wallLabelRadio.AssociatedControlID = "radWall" + i;   //Tying this label to the radio button

            Label wallLabel = new Label();
            wallLabel.AssociatedControlID = "radWall" + i;        //Tying this label to the radio button
            wallLabel.Text = "Proposed Wall " + proposedWallCount + " Door Options";       //Adding text to the radio button

            wallDoorOptions.Controls.Add(wallRadio);        //Adding radio button control to placeholder wallDoorOptions
            wallDoorOptions.Controls.Add(wallLabelRadio);   //Adding label control to placeholder wallDoorOptions
            wallDoorOptions.Controls.Add(wallLabel);        //Adding label control to placeholder wallDoorOptions

            //Creating div tag to hold all the current walls information (i.e. Cabana, French, Patio, Opening Only (No Door))
            wallDoorOptions.Controls.Add(new LiteralControl("<div id=\"doorDetails" + i + "\" class=\"toggleContent\">"));

            //Creating one ul tag to hold multiple li tags contain Cabana, French, Patio, Opening Only (No Door) options

            wallDoorOptions.Controls.Add(new LiteralControl("<ul><li><ul id='doorDetailsList" + i + "' class='toggleOptions'>"));


            #endregion

            #region Loop to display door types as radio buttons

            //For loop to get through all the possible door types: Cabana, French, Patio, Opening Only (No Door)
            for (int typeCount = 1; typeCount <= 4; typeCount++)
            {
                //Conditional operator to set the current door type with the right label
                string title = (typeCount == 1) ? "Cabana" : (typeCount == 2) ? "French" : (typeCount == 3) ? "Patio" : "OpeningOnly(NoDoor)";

                //If logic to handle model 400's which don't have french doors
                if (currentModel == "M400" && title == "French")
                {
                    //Do nothing
                }
                else
                {
                    //li tag to hold door type radio button and all its content
                    wallDoorOptions.Controls.Add(new LiteralControl("<li>"));

                    //Door type radio button
                    RadioButton typeRadio = new RadioButton();
                    typeRadio.ID = "radType" + i + title; //Adding appropriate id to door type radio button
                    typeRadio.GroupName = "doorTypeRadios";         //Adding group name for all door types
                    typeRadio.Attributes.Add("onclick", "typeRowsDisplayed()"); //On click event to display the proper fields/rows

                    //Door type radio button label for clickable area
                    Label typeLabelRadio = new Label();
                    typeLabelRadio.AssociatedControlID = "radType" + i + title;   //Tying this label to the radio button

                    //Door type radio button label text
                    Label typeLabel = new Label();
                    typeLabel.AssociatedControlID = "radType" + i + title;    //Tying this label to the radio button
                    if (title == "OpeningOnly(NoDoor)")
                    {
                        typeLabel.Text = "Opening Only (No Door)";
                    }
                    else
                    {
                        typeLabel.Text = title;     //Displaying the proper texted based on current title variable
                    }

                    wallDoorOptions.Controls.Add(typeRadio);        //Adding radio button control to placeholder wallDoorOptions
                    wallDoorOptions.Controls.Add(typeLabelRadio);   //Adding label control to placeholder wallDoorOptions
                    wallDoorOptions.Controls.Add(typeLabel);        //Adding label control to placeholder wallDoorOptions

                    //New instance of a table for every door type
                    Table tblDoorDetails = new Table();

                    tblDoorDetails.ID = "tblDoorDetails" + i + title; //Adding appropriate id to the table
                    tblDoorDetails.CssClass = "tblTextFields";                  //Adding CssClass to the table for styling
                    
                    
                    //Creating cells and controls for rows

                    #region Table:Default Row Title Current Door (tblDoorDetails)

                    TableRow doorTitleRow = new TableRow();
                    doorTitleRow.ID = "rowDoorTitle" + i + title;
                    doorTitleRow.Attributes.Add("style", "display:none;");
                    TableCell doorTitleLBLCell = new TableCell();

                    Label doorTitleLBL = new Label();
                    doorTitleLBL.ID = "lblDoorTitle" + i + title;
                    doorTitleLBL.Text = "Select door details:";
                    doorTitleLBL.Attributes.Add("style", "font-weight:bold;");

                    #endregion

                    #region Table:Second Row Door Style (tblDoorDetails)

                    TableRow doorStyleRow = new TableRow();
                    doorStyleRow.ID = "rowDoorStyle" + i + title;
                    doorStyleRow.Attributes.Add("style", "display:none;");
                    TableCell doorStyleLBLCell = new TableCell();
                    TableCell doorStyleDDLCell = new TableCell();

                    Label doorStyleLBL = new Label();
                    doorStyleLBL.ID = "lblDoorStyle" + i + title;
                    doorStyleLBL.Text = "Door Style";

                    DropDownList doorStyleDDL = new DropDownList();
                    doorStyleDDL.ID = "ddlDoorStyle" + i + title;
                    doorStyleDDL.Attributes.Add("onchange", "doorStyle('" + title + "')");
                    ListItem fullScreen = new ListItem("Full Screen", "fullScreen");
                    ListItem v4TCabana = new ListItem("Vertical Four Track", "v4TCabana");
                    ListItem fullView = new ListItem("Full View", "fullView");
                    ListItem fullViewColonial = new ListItem("Full View Colonial", "fullViewColonial");
                    ListItem halfLite = new ListItem("Half Lite", "halfLite");
                    ListItem halfLiteVenting = new ListItem("Half Lite Venting", "halfLiteVenting");
                    ListItem fullLite = new ListItem("Full Lite", "fullLite");
                    ListItem halfLiteWithMiniBlinds = new ListItem("Half Lite With Mini Blinds", "halfLiteWithMiniBlinds");
                    ListItem fullViewWithMiniBlinds = new ListItem("Full View With Mini Blinds", "fullViewWithMiniBlinds");
                    if (currentModel == "M100")
                    {
                        doorStyleDDL.Items.Add(fullScreen);
                        doorStyleDDL.Items.Add(v4TCabana);
                    }
                    else if (currentModel == "M200")
                    {
                        doorStyleDDL.Items.Add(fullScreen);
                        doorStyleDDL.Items.Add(v4TCabana);
                        doorStyleDDL.Items.Add(fullView);
                    }
                    else if (currentModel == "M300")
                    {
                        doorStyleDDL.Items.Add(fullScreen);
                        doorStyleDDL.Items.Add(fullView);
                        doorStyleDDL.Items.Add(fullViewColonial);
                    }
                    else
                    {

                        doorStyleDDL.Items.Add(halfLite);
                        doorStyleDDL.Items.Add(halfLiteVenting);
                        doorStyleDDL.Items.Add(fullLite);
                        doorStyleDDL.Items.Add(halfLiteWithMiniBlinds);
                        doorStyleDDL.Items.Add(fullViewWithMiniBlinds);
                    }

                    doorStyleLBL.AssociatedControlID = "ddlDoorStyle" + i + title;

                    #endregion

                    #region Table:Sixteenth Row Door V4T Vinyl Tint (tblDoorDetails)

                    TableRow doorVinylTintRow = new TableRow();
                    doorVinylTintRow.ID = "rowDoorVinylTint" + i + title;
                    doorVinylTintRow.Attributes.Add("style", "display:none;");
                    TableCell doorVinylTintLBLCell = new TableCell();
                    TableCell doorVinylTintDDLCell = new TableCell();

                    Label doorVinylTintLBL = new Label();
                    doorVinylTintLBL.ID = "lblDoorVinylTint" + i + title;
                    doorVinylTintLBL.Text = "Door Vinyl Tint:";

                    DropDownList doorVinylTintDDL = new DropDownList();
                    doorVinylTintDDL.ID = "ddlVinylTint" + i + title;
                    ListItem clearVinyl = new ListItem("Clear", "clear");
                    ListItem smokeGreyVinyl = new ListItem("Smoke Grey", "smokeGrey");
                    ListItem darkGreyVinyl = new ListItem("Dark Grey", "darkGrey");
                    ListItem bronzeVinyl = new ListItem("Bronze", "bronze");
                    ListItem mixedVinyl = new ListItem("Mixed", "mixed");
                    doorVinylTintDDL.Items.Add(clearVinyl);
                    doorVinylTintDDL.Items.Add(smokeGreyVinyl);
                    doorVinylTintDDL.Items.Add(darkGreyVinyl);
                    doorVinylTintDDL.Items.Add(bronzeVinyl);
                    doorVinylTintDDL.Items.Add(mixedVinyl);

                    doorVinylTintLBL.AssociatedControlID = "ddlVinylTint" + i + title;

                    #endregion

                    #region Table:Third Row Color of Door (tblDoorDetails)

                    TableRow colorOfDoorRow = new TableRow();
                    colorOfDoorRow.ID = "rowDoorColor" + i + title;
                    colorOfDoorRow.Attributes.Add("style", "display:none;");
                    TableCell colorOfDoorLBLCell = new TableCell();
                    TableCell colorOfDoorDDLCell = new TableCell();

                    Label colorOfDoorLBL = new Label();
                    colorOfDoorLBL.ID = "lblDoorColor" + i + title;
                    colorOfDoorLBL.Text = "Door Color:";

                    DropDownList colorOfDoorDDL = new DropDownList();
                    colorOfDoorDDL.ID = "ddlDoorColor" + i + title;
                    ListItem white = new ListItem("White", "white");
                    ListItem driftwood = new ListItem("Driftwood", "driftwood");
                    ListItem bronze = new ListItem("Bronze", "bronze");
                    ListItem green = new ListItem("Green", "green");
                    ListItem black = new ListItem("Black", "black");
                    ListItem ivory = new ListItem("Ivory", "ivory");
                    ListItem cherrywood = new ListItem("Cherrywood", "cherrywood");
                    ListItem grey = new ListItem("Grey", "grey");
                    colorOfDoorDDL.Items.Add(white);
                    colorOfDoorDDL.Items.Add(driftwood);
                    colorOfDoorDDL.Items.Add(bronze);
                    colorOfDoorDDL.Items.Add(green);
                    colorOfDoorDDL.Items.Add(black);
                    colorOfDoorDDL.Items.Add(ivory);
                    colorOfDoorDDL.Items.Add(cherrywood);
                    colorOfDoorDDL.Items.Add(grey);

                    colorOfDoorLBL.AssociatedControlID = "ddlDoorColor" + i + title;

                    #endregion

                    #region Table:Fourth Row Door Height (tblDoorDetails)

                    TableRow doorHeightRow = new TableRow();
                    doorHeightRow.ID = "rowDoorHeight" + i + title;
                    doorHeightRow.Attributes.Add("style", "display:none;");
                    TableCell doorHeightLBLCell = new TableCell();
                    TableCell doorHeightDDLCell = new TableCell();

                    Label doorHeightLBL = new Label();
                    doorHeightLBL.ID = "lblDoorHeight" + i + title;
                    doorHeightLBL.Text = "Height:";

                    DropDownList doorHeightDDL = new DropDownList();
                    doorHeightDDL.ID = "ddlDoorHeight" + i + title;
                    doorHeightDDL.Attributes.Add("onchange", "customDimension('" + title + "','Height')");
                    ListItem eighty = new ListItem("80\" (Default)", "80");
                    ListItem customHeight = new ListItem("Custom", "cHeight");
                    doorHeightDDL.Items.Add(eighty);
                    doorHeightDDL.Items.Add(customHeight);

                    doorHeightLBL.AssociatedControlID = "ddlDoorHeight" + i + title;

                    #endregion

                    #region Table:Sixth Row Door Custom Height (tblDoorDetails)

                    TableRow doorCustomHeightRow = new TableRow();
                    doorCustomHeightRow.ID = "rowDoorCustomHeight" + i + title;
                    doorCustomHeightRow.Attributes.Add("style", "display:none;");
                    TableCell doorCustomHeightLBLCell = new TableCell();
                    TableCell doorCustomHeightTXTCell = new TableCell();
                    TableCell doorCustomHeightDDLCell = new TableCell();

                    Label doorCustomHeightLBL = new Label();
                    doorCustomHeightLBL.ID = "lblDoorCustomHeight" + i + title;
                    doorCustomHeightLBL.Text = "Custom Height (inches):";

                    TextBox doorCustomHeightTXT = new TextBox();
                    doorCustomHeightTXT.ID = "txtDoorCustomHeight" + i + title;
                    doorCustomHeightTXT.CssClass = "txtField txtDoorInput";

                    DropDownList inchCustomHeight = new DropDownList();
                    inchCustomHeight.ID = "ddlInchCustomHeight" + i + title;
                    inchCustomHeight.Items.Add(lst0);
                    inchCustomHeight.Items.Add(lst18);
                    inchCustomHeight.Items.Add(lst14);
                    inchCustomHeight.Items.Add(lst38);
                    inchCustomHeight.Items.Add(lst12);
                    inchCustomHeight.Items.Add(lst58);
                    inchCustomHeight.Items.Add(lst34);
                    inchCustomHeight.Items.Add(lst78);

                    doorCustomHeightLBL.AssociatedControlID = "txtDoorCustomHeight" + i + title;

                    #endregion

                    #region Table:Fifth Row Door Width (tblDoorDetails)

                    TableRow doorWidthRow = new TableRow();
                    doorWidthRow.ID = "rowDoorWidth" + i + title;
                    doorWidthRow.Attributes.Add("style", "display:none;");
                    TableCell doorWidthLBLCell = new TableCell();
                    TableCell doorWidthDDLCell = new TableCell();

                    Label doorWidthLBL = new Label();
                    doorWidthLBL.ID = "lblDoorWidth" + i + title;
                    doorWidthLBL.Text = "Width:";

                    DropDownList doorWidthDDL = new DropDownList();
                    doorWidthDDL.ID = "ddlDoorWidth" + i + title;
                    doorWidthDDL.Attributes.Add("onchange", "customDimension('" + title + "','Width')");
                    ListItem thirty = new ListItem("30\"", "30");
                    ListItem thirtyTwo = new ListItem("32\"", "32");
                    ListItem thirtyFour = new ListItem("34\"", "34");
                    ListItem thirtySix = new ListItem("36\"", "36");
                    ListItem sixty = new ListItem("60\"", "30");
                    ListItem seventyTwo = new ListItem("72\"", "36");
                    ListItem fiveFeet = new ListItem("5'", "5");
                    ListItem sixFeet = new ListItem("6'", "6");
                    ListItem sevenFeet = new ListItem("7'", "7");
                    ListItem eightFeet = new ListItem("8'", "8");
                    ListItem customWidth = new ListItem("Custom", "cWidth");

                    if (title == "Patio")
                    {
                        doorWidthDDL.Items.Add(fiveFeet);
                        doorWidthDDL.Items.Add(sixFeet);
                        doorWidthDDL.Items.Add(sevenFeet);
                        doorWidthDDL.Items.Add(eightFeet);
                        doorWidthDDL.Items.Add(customWidth);
                    }
                    else if (title == "French")
                    {
                        doorWidthDDL.Items.Add(sixty);
                        doorWidthDDL.Items.Add(seventyTwo);
                        doorWidthDDL.Items.Add(customWidth);
                    }
                    else
                    {
                        doorWidthDDL.Items.Add(thirty);
                        doorWidthDDL.Items.Add(thirtyTwo);
                        doorWidthDDL.Items.Add(thirtyFour);
                        doorWidthDDL.Items.Add(thirtySix);
                        doorWidthDDL.Items.Add(customWidth);
                    }

                    doorWidthLBL.AssociatedControlID = "ddlDoorWidth" + i + title;

                    #endregion

                    #region Table:Seventh Row Door Custom Width (tblDoorDetails)

                    TableRow doorCustomWidthRow = new TableRow();
                    doorCustomWidthRow.ID = "rowDoorCustomWidth" + i + title;
                    doorCustomWidthRow.Attributes.Add("style", "display:none;");
                    TableCell doorCustomWidthLBLCell = new TableCell();
                    TableCell doorCustomWidthTXTCell = new TableCell();
                    TableCell doorCustomWidthDDLCell = new TableCell();

                    Label doorCustomWidthLBL = new Label();
                    doorCustomWidthLBL.ID = "lblDoorCustomWidth" + i + title;
                    doorCustomWidthLBL.Text = "Custom Width (inches):";

                    TextBox doorCustomWidthTXT = new TextBox();
                    doorCustomWidthTXT.ID = "txtDoorCustomWidth" + i + title;
                    doorCustomWidthTXT.CssClass = "txtField txtDoorInput";

                    DropDownList inchCustomWidth = new DropDownList();
                    inchCustomWidth.ID = "ddlInchCustomWidth" + i + title;
                    inchCustomWidth.Items.Add(lst0);
                    inchCustomWidth.Items.Add(lst18);
                    inchCustomWidth.Items.Add(lst14);
                    inchCustomWidth.Items.Add(lst38);
                    inchCustomWidth.Items.Add(lst12);
                    inchCustomWidth.Items.Add(lst58);
                    inchCustomWidth.Items.Add(lst34);
                    inchCustomWidth.Items.Add(lst78);

                    doorCustomWidthLBL.AssociatedControlID = "txtDoorCustomWidth" + i + title;

                    #endregion

                    #region Table:Eight Row Door Primary Operator LHH (tblDoorDetails)

                    TableRow doorOperatorLHHRow = new TableRow();
                    doorOperatorLHHRow.ID = "rowDoorOperatorLHH" + i + title;
                    doorOperatorLHHRow.Attributes.Add("style", "display:none;");
                    TableCell doorOperatorLHHLBLCell = new TableCell();
                    TableCell doorOperatorLHHRADCell = new TableCell();

                    Label doorOperatorLHHLBLMain = new Label();
                    doorOperatorLHHLBLMain.ID = "lblDoorOperatorLHHMain" + i + title;
                    doorOperatorLHHLBLMain.Text = "Primary Operator:";

                    Label doorOperatorLHHLBLRad = new Label();
                    doorOperatorLHHLBLRad.ID = "lblDoorOperatorRadLHH" + i + title;

                    Label doorOperatorLHHLBL = new Label();
                    doorOperatorLHHLBL.ID = "lblDoorOperatorLHH" + i + title;
                    doorOperatorLHHLBL.Text = "LHH";

                    RadioButton doorOperatorLHHRad = new RadioButton();
                    doorOperatorLHHRad.ID = "radDoorOperatorLHH" + i + title;
                    doorOperatorLHHRad.GroupName = "PrimaryOperator";

                    doorOperatorLHHLBLRad.AssociatedControlID = "radDoorOperatorLHH" + i + title;
                    doorOperatorLHHLBL.AssociatedControlID = "radDoorOperatorLHH" + i + title;

                    #endregion

                    #region Table:Ninth Row Door Primary Operator RHH (tblDoorDetails)

                    TableRow doorOperatorRHHRow = new TableRow();
                    doorOperatorRHHRow.ID = "rowDoorOperatorRHH" + i + title;
                    doorOperatorRHHRow.Attributes.Add("style", "display:none;");
                    TableCell doorOperatorRHHLBLCell = new TableCell();
                    TableCell doorOperatorRHHRADCell = new TableCell();

                    Label doorOperatorRHHLBLRad = new Label();
                    doorOperatorRHHLBLRad.ID = "lblDoorOperatorRadRHH" + i + title;

                    Label doorOperatorRHHLBL = new Label();
                    doorOperatorRHHLBL.ID = "lblDoorOperatorRHH" + i + title;
                    doorOperatorRHHLBL.Text = "RHH";

                    RadioButton doorOperatorRHHRad = new RadioButton();
                    doorOperatorRHHRad.ID = "radDoorOperatorRHH" + i + title;
                    doorOperatorRHHRad.GroupName = "PrimaryOperator";

                    doorOperatorRHHLBLRad.AssociatedControlID = "radDoorOperatorRHH" + i + title;
                    doorOperatorRHHLBL.AssociatedControlID = "radDoorOperatorRHH" + i + title;

                    #endregion

                    #region Table:Tenth Row Door Box Header (tblDoorDetails)

                    TableRow doorBoxHeaderRow = new TableRow();
                    doorBoxHeaderRow.ID = "rowDoorBoxHeader" + i + title;
                    doorBoxHeaderRow.Attributes.Add("style", "display:none;");
                    TableCell doorBoxHeaderLBLCell = new TableCell();
                    TableCell doorBoxHeaderDDLCell = new TableCell();

                    Label doorBoxHeaderLBL = new Label();
                    doorBoxHeaderLBL.ID = "lblDoorBoxHeader" + i + title;
                    doorBoxHeaderLBL.Text = "Box Header Position:";

                    DropDownList doorBoxHeaderDDL = new DropDownList();
                    doorBoxHeaderDDL.ID = "ddlDoorBoxHeader" + i + title;
                    ListItem Left = new ListItem("Left", "left");
                    ListItem Right = new ListItem("Right", "right");
                    ListItem Both = new ListItem("Both", "both");
                    ListItem None = new ListItem("None", "none");
                    doorBoxHeaderDDL.Items.Add(Left);
                    doorBoxHeaderDDL.Items.Add(Right);
                    doorBoxHeaderDDL.Items.Add(Both);
                    doorBoxHeaderDDL.Items.Add(None);

                    doorBoxHeaderLBL.AssociatedControlID = "ddlDoorBoxHeader" + i + title;

                    #endregion

                    #region Table:Twelfth Row Door Number Of Vents (tblDoorDetails)

                    TableRow doorNumberOfVentsRow = new TableRow();
                    doorNumberOfVentsRow.ID = "rowDoorNumberOfVents" + i + title;
                    doorNumberOfVentsRow.Attributes.Add("style", "display:none;");
                    TableCell doorNumberOfVentsLBLCell = new TableCell();
                    TableCell doorNumberOfVentsDDLCell = new TableCell();

                    Label doorNumberOfVentsLBL = new Label();
                    doorNumberOfVentsLBL.ID = "lblNumberOfVents" + i + title;
                    doorNumberOfVentsLBL.Text = "Number Of Vents:";

                    DropDownList doorNumberOfVentsDDL = new DropDownList();
                    doorNumberOfVentsDDL.ID = "ddlNumberOfVents" + i + title;
                    ListItem two = new ListItem("2", "2");
                    ListItem three = new ListItem("3", "3");
                    ListItem four = new ListItem("4", "4");
                    doorNumberOfVentsDDL.Items.Add(two);
                    doorNumberOfVentsDDL.Items.Add(three);
                    doorNumberOfVentsDDL.Items.Add(four);

                    doorNumberOfVentsLBL.AssociatedControlID = "ddlNumberOfVents" + i + title;

                    #endregion

                    #region Table:Thirteenth Row Door Glass Tint (tblDoorDetails)

                    TableRow doorGlassTintRow = new TableRow();
                    doorGlassTintRow.ID = "rowDoorGlassTint" + i + title;
                    doorGlassTintRow.Attributes.Add("style", "display:none;");
                    TableCell doorGlassTintLBLCell = new TableCell();
                    TableCell doorGlassTintDDLCell = new TableCell();

                    Label doorGlassTintLBL = new Label();
                    doorGlassTintLBL.ID = "lblDoorGlassTint" + i + title;
                    doorGlassTintLBL.Text = "Door Glass Tint:";

                    DropDownList doorGlassTintDDL = new DropDownList();
                    doorGlassTintDDL.ID = "ddlDoorGlassTint" + i + title;
                    ListItem clear = new ListItem("Clear", "clear");
                    ListItem greyTint = new ListItem("Grey", "grey");
                    ListItem bronzeTint = new ListItem("Bronze", "bronze");
                    doorGlassTintDDL.Items.Add(clear);
                    doorGlassTintDDL.Items.Add(grey);
                    doorGlassTintDDL.Items.Add(bronzeTint);

                    doorGlassTintLBL.AssociatedControlID = "ddlDoorGlassTint" + i + title;

                    #endregion

                    #region Table:Tenth Row Door Hinge LHH (tblDoorDetails)

                    TableRow doorLHHRow = new TableRow();
                    doorLHHRow.ID = "rowDoorLHH" + i + title;
                    doorLHHRow.Attributes.Add("style", "display:none;");
                    TableCell doorLHHLBLCell = new TableCell();
                    TableCell doorLHHRADCell = new TableCell();

                    Label doorLHHLBLMain = new Label();
                    doorLHHLBLMain.ID = "lblDoorLHHMain" + i + title;
                    doorLHHLBLMain.Text = "Hinge placement:";

                    Label doorLHHLBLRad = new Label();
                    doorLHHLBLRad.ID = "lblLHHRad" + i + title;

                    Label doorLHHLBL = new Label();
                    doorLHHLBL.ID = "lblLHH" + i + title;
                    doorLHHLBL.Text = "LHH";

                    RadioButton doorLHHRad = new RadioButton();
                    doorLHHRad.ID = "radDoorLHH" + i + title;
                    doorLHHRad.GroupName = "DoorHinge";

                    doorLHHLBLRad.AssociatedControlID = "radDoorLHH" + i + title;
                    doorLHHLBL.AssociatedControlID = "radDoorLHH" + i + title;

                    #endregion

                    #region Table:Eleventh Row Door Hinge RHH (tblDoorDetails)

                    TableRow doorRHHRow = new TableRow();
                    doorRHHRow.ID = "rowDoorRHH" + i + title;
                    doorRHHRow.Attributes.Add("style", "display:none;");
                    TableCell doorRHHLBLCell = new TableCell();
                    TableCell doorRHHRADCell = new TableCell();

                    Label doorRHHLBLRad = new Label();
                    doorRHHLBLRad.ID = "lblDoorRHHRad" + i + title;

                    Label doorRHHLBL = new Label();
                    doorRHHLBL.ID = "lblDoorRHH" + i + title;
                    doorRHHLBL.Text = "RHH";

                    RadioButton doorRHHRad = new RadioButton();
                    doorRHHRad.ID = "radDoorRHH" + i + title;
                    doorRHHRad.GroupName = "DoorHinge";

                    doorRHHLBLRad.AssociatedControlID = "radDoorRHH" + i + title;
                    doorRHHLBL.AssociatedControlID = "radDoorRHH" + i + title;

                    #endregion

                    #region Table:Fourteenth Row Door Screen Options (tblDoorDetails)

                    TableRow doorScreenOptionsRow = new TableRow();
                    doorScreenOptionsRow.ID = "rowDoorScreenOptions" + i + title;
                    doorScreenOptionsRow.Attributes.Add("style", "display:none;");
                    TableCell doorScreenOptionsLBLCell = new TableCell();
                    TableCell doorScreenOptionsDDLCell = new TableCell();

                    Label doorScreenOptionsLBL = new Label();
                    doorScreenOptionsLBL.ID = "lblDoorScreenOptions" + i + title;
                    doorScreenOptionsLBL.Text = "Door Screen Option:";

                    DropDownList doorScreenOptionsDDL = new DropDownList();
                    doorScreenOptionsDDL.ID = "ddlDoorScreenOptions" + i + title;
                    ListItem betterVueInsect = new ListItem("Better Vue Insect Screen (Default)", "betterVueInsectScreen");
                    ListItem noSeeUms = new ListItem("No See Ums 20x20 Mesh", "noSeeUms");
                    ListItem solarInsectScreening = new ListItem("Solar Insect Screening", "solarInsectScreening");
                    ListItem tuffScreen = new ListItem("Tuff Screen", "tuffScreen");
                    ListItem noScreen = new ListItem("No Screen", "noScreen");
                    doorScreenOptionsDDL.Items.Add(betterVueInsect);
                    doorScreenOptionsDDL.Items.Add(noSeeUms);
                    doorScreenOptionsDDL.Items.Add(solarInsectScreening);
                    doorScreenOptionsDDL.Items.Add(tuffScreen);
                    doorScreenOptionsDDL.Items.Add(noScreen);

                    doorScreenOptionsLBL.AssociatedControlID = "ddlDoorScreenOptions" + i + title;

                    #endregion

                    #region Table:Fifteenth Row Door Hardware (tblDoorDetails)

                    TableRow doorHardwareRow = new TableRow();
                    doorHardwareRow.ID = "rowDoorHardware" + i + title;
                    doorHardwareRow.Attributes.Add("style", "display:none;");
                    TableCell doorHardwareLBLCell = new TableCell();
                    TableCell doorHardwareDDLCell = new TableCell();

                    Label doorHardwareLBL = new Label();
                    doorHardwareLBL.ID = "lblDoorHardware" + i + title;
                    doorHardwareLBL.Text = "Door Hardware";

                    DropDownList doorHardwareDDL = new DropDownList();
                    doorHardwareDDL.ID = "ddlDoorHardware" + i + title;
                    ListItem satinSilver = new ListItem("Satin Silver", "satinSilver");
                    ListItem brightBrass = new ListItem("Bright Brass", "brightBrass");
                    ListItem antiqueBrass = new ListItem("Antique Brass", "antiqueBrass");
                    doorHardwareDDL.Items.Add(satinSilver);
                    doorHardwareDDL.Items.Add(brightBrass);
                    doorHardwareDDL.Items.Add(antiqueBrass);

                    doorHardwareLBL.AssociatedControlID = "ddlDoorHardware" + i + title;

                    #endregion



                    #region Table:Eight Row Door Swing In (tblDoorDetails)

                    TableRow doorSwingInRow = new TableRow();
                    doorSwingInRow.ID = "rowDoorSwingIn" + i + title;
                    doorSwingInRow.Attributes.Add("style", "display:none;");
                    TableCell doorSwingInLBLCell = new TableCell();
                    TableCell doorSwingInRADCell = new TableCell();

                    Label doorSwingInLBLMain = new Label();
                    doorSwingInLBLMain.ID = "lblDoorSwingMain" + i + title;
                    doorSwingInLBLMain.Text = "Swing:";

                    Label doorSwingInLBLRad = new Label();
                    doorSwingInLBLRad.ID = "lblDoorSwingIn" + i + title;

                    Label doorSwingInLBL = new Label();
                    doorSwingInLBL.ID = "lblDoorSwingInRad" + i + title;
                    doorSwingInLBL.Text = "In";

                    RadioButton doorSwingInRAD = new RadioButton();
                    doorSwingInRAD.ID = "radDoorSwingIn" + i + title;
                    doorSwingInRAD.GroupName = "SwingInOut";

                    doorSwingInLBLRad.AssociatedControlID = "radDoorSwingIn" + i + title;
                    doorSwingInLBL.AssociatedControlID = "radDoorSwingIn" + i + title;

                    #endregion

                    #region Table:Ninth Row Door Swing Out (tblDoorDetails)

                    TableRow doorSwingOutRow = new TableRow();
                    doorSwingOutRow.ID = "rowDoorSwingOut" + i + title;
                    doorSwingOutRow.Attributes.Add("style", "display:none;");
                    TableCell doorSwingOutLBLCell = new TableCell();
                    TableCell doorSwingOutRADCell = new TableCell();

                    Label doorSwingOutLBLRad = new Label();
                    doorSwingOutLBLRad.ID = "lblDoorSwingOutRad" + i + title;

                    Label doorSwingOutLBL = new Label();
                    doorSwingOutLBL.ID = "lblDoorSwingOut" + i + title;
                    doorSwingOutLBL.Text = "Out";

                    RadioButton doorSwingOutRAD = new RadioButton();
                    doorSwingOutRAD.ID = "radDoorSwingOut" + i + title;
                    doorSwingOutRAD.GroupName = "SwingInOut";

                    doorSwingOutLBLRad.AssociatedControlID = "radDoorSwingOut" + i + title;
                    doorSwingOutLBL.AssociatedControlID = "radDoorSwingOut" + i + title;

                    #endregion

                    #region Table:# Row Door Position DDL (tblDoorDetails)

                    TableRow doorPositionDDLRow = new TableRow();
                    doorPositionDDLRow.ID = "rowDoorPositionDDL" + i + title;
                    doorPositionDDLRow.Attributes.Add("style", "display:none;");
                    TableCell doorPositionDDLLBLCell = new TableCell();
                    TableCell doorPositionDDLDDLCell = new TableCell();

                    Label doorPositionDDLLBL = new Label();
                    doorPositionDDLLBL.ID = "lblDoorPositionDDL" + i + title;
                    doorPositionDDLLBL.Text = "PositionDDL:";

                    DropDownList doorPositionDDLDDL = new DropDownList();
                    doorPositionDDLDDL.ID = "ddlDoorPosition" + i + title;
                    doorPositionDDLDDL.Attributes.Add("onchange", "customPosition('" + title + "')");
                    ListItem PositionLeft = new ListItem("Left", "left");
                    ListItem PositionCenter = new ListItem("Center", "center");
                    ListItem PositionRight = new ListItem("Right", "right");
                    ListItem PositionCustom = new ListItem("Custom", "cPosition");
                    doorPositionDDLDDL.Items.Add(PositionLeft);
                    doorPositionDDLDDL.Items.Add(PositionCenter);
                    doorPositionDDLDDL.Items.Add(PositionRight);
                    doorPositionDDLDDL.Items.Add(PositionCustom);

                    doorPositionDDLLBL.AssociatedControlID = "ddlDoorPosition" + i + title;

                    #endregion

                    #region Table:# Row Door Position (tblDoorDetails)

                    TableRow doorPositionRow = new TableRow();
                    doorPositionRow.ID = "rowDoorPosition" + i + title;
                    doorPositionRow.Attributes.Add("style", "display:none;");
                    TableCell doorPositionLBLCell = new TableCell();
                    TableCell doorPositionTXTCell = new TableCell();
                    TableCell doorPositionDDLCell = new TableCell();

                    Label doorPositionLBL = new Label();
                    doorPositionLBL.ID = "lblDoorPosition" + i + title;
                    doorPositionLBL.Text = "Door position from left side (inches):";

                    TextBox doorPositionTXT = new TextBox();
                    doorPositionTXT.ID = "txtDoorPosition" + i + title;
                    doorPositionTXT.CssClass = "txtField txtDoorInput";

                    DropDownList inchSpecificLeft = new DropDownList();
                    inchSpecificLeft.ID = "ddlInchSpecificLeft" + i + title;
                    inchSpecificLeft.Items.Add(lst0);
                    inchSpecificLeft.Items.Add(lst18);
                    inchSpecificLeft.Items.Add(lst14);
                    inchSpecificLeft.Items.Add(lst38);
                    inchSpecificLeft.Items.Add(lst12);
                    inchSpecificLeft.Items.Add(lst58);
                    inchSpecificLeft.Items.Add(lst34);
                    inchSpecificLeft.Items.Add(lst78);

                    doorPositionLBL.AssociatedControlID = "txtDoorPosition" + i + title;

                    #endregion

                    #region Table:# Row Add This Door (tblDoorDetails)

                    TableRow doorButtonRow = new TableRow();
                    doorButtonRow.ID = "rowAddDoor" + i + title;
                    doorButtonRow.Attributes.Add("style", "display:inherit;");
                    TableCell doorAddButtonCell = new TableCell();
                    TableCell doorFillButtonCell = new TableCell();
                    TableCell doorUndoButtonCell = new TableCell();

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

                    #region Table:Sixteenth Row Door V4T Vinyl Tint (tblDoorDetails)

                    doorVinylTintLBLCell.Controls.Add(doorVinylTintLBL);
                    doorVinylTintDDLCell.Controls.Add(doorVinylTintDDL);

                    tblDoorDetails.Rows.Add(doorVinylTintRow);

                    doorVinylTintRow.Cells.Add(doorVinylTintLBLCell);
                    doorVinylTintRow.Cells.Add(doorVinylTintDDLCell);

                    #endregion

                    #region Table:Third Row Color of Door Added to Table (tblDoorDetails)

                    colorOfDoorLBLCell.Controls.Add(colorOfDoorLBL);
                    colorOfDoorDDLCell.Controls.Add(colorOfDoorDDL);

                    tblDoorDetails.Rows.Add(colorOfDoorRow);

                    colorOfDoorRow.Cells.Add(colorOfDoorLBLCell);
                    colorOfDoorRow.Cells.Add(colorOfDoorDDLCell);

                    #endregion

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

                    #region Table:Twelfth Row Door Number Of Vents Added To Table (tblDoorDetails)

                    doorNumberOfVentsLBLCell.Controls.Add(doorNumberOfVentsLBL);
                    doorNumberOfVentsDDLCell.Controls.Add(doorNumberOfVentsDDL);

                    tblDoorDetails.Rows.Add(doorNumberOfVentsRow);

                    doorNumberOfVentsRow.Cells.Add(doorNumberOfVentsLBLCell);
                    doorNumberOfVentsRow.Cells.Add(doorNumberOfVentsDDLCell);

                    #endregion

                    #region Table:Thirteenth Row Door Glass Tint Added To Table (tblDoorDetails)

                    doorGlassTintLBLCell.Controls.Add(doorGlassTintLBL);
                    doorGlassTintDDLCell.Controls.Add(doorGlassTintDDL);

                    tblDoorDetails.Rows.Add(doorGlassTintRow);

                    doorGlassTintRow.Cells.Add(doorGlassTintLBLCell);
                    doorGlassTintRow.Cells.Add(doorGlassTintDDLCell);

                    #endregion

                    #region Table:Tenth Row Door Hinge LHH Added To Table (tblDoorDetails)

                    doorLHHLBLCell.Controls.Add(doorLHHLBLMain);

                    doorLHHRADCell.Controls.Add(doorLHHRad);
                    doorLHHRADCell.Controls.Add(doorLHHLBLRad);
                    doorLHHRADCell.Controls.Add(doorLHHLBL);

                    tblDoorDetails.Rows.Add(doorLHHRow);

                    doorLHHRow.Cells.Add(doorLHHLBLCell);
                    doorLHHRow.Cells.Add(doorLHHRADCell);

                    #endregion

                    #region Table:Eleventh Row Door Hinge RHH Added To Table (tblDoorDetails)

                    doorRHHRADCell.Controls.Add(doorRHHRad);
                    doorRHHRADCell.Controls.Add(doorRHHLBLRad);
                    doorRHHRADCell.Controls.Add(doorRHHLBL);

                    tblDoorDetails.Rows.Add(doorRHHRow);

                    doorRHHRow.Cells.Add(doorRHHLBLCell);
                    doorRHHRow.Cells.Add(doorRHHRADCell);

                    #endregion

                    #region Table:Fourteenth Row Door Screen Options Added To Table (tblDoorDetails)

                    doorScreenOptionsLBLCell.Controls.Add(doorScreenOptionsLBL);
                    doorScreenOptionsDDLCell.Controls.Add(doorScreenOptionsDDL);

                    tblDoorDetails.Rows.Add(doorScreenOptionsRow);

                    doorScreenOptionsRow.Cells.Add(doorScreenOptionsLBLCell);
                    doorScreenOptionsRow.Cells.Add(doorScreenOptionsDDLCell);

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

                    #region Table:# Row Door Position DDL Added To Table (tblDoorDetails)

                    doorPositionDDLLBLCell.Controls.Add(doorPositionDDLLBL);
                    doorPositionDDLDDLCell.Controls.Add(doorPositionDDLDDL);

                    tblDoorDetails.Rows.Add(doorPositionDDLRow);


                    doorPositionDDLRow.Cells.Add(doorPositionDDLLBLCell);
                    doorPositionDDLRow.Cells.Add(doorPositionDDLDDLCell);

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

                    #region Table:# Row Add This Door (tblDoorDetails)

                    doorAddButtonCell.Controls.Add(new LiteralControl("<input id='btnAddthisDoor" + i + title + "' type='button' onclick='addDoor(\"" + title + "\")' class='btnSubmit' style='display:inherit;' value='Add This " + title + " Door'/>"));
                    doorFillButtonCell.Controls.Add(new LiteralControl("<input id='btnFillWallWithThisDoor" + i + title + "' type='button' onclick='addDoor(\"" + title + "\")' class='btnSubmit' style='display:inherit;' value='Fill Wall With " + title + " Doors'/>"));
                    doorUndoButtonCell.Controls.Add(new LiteralControl("<input id='btnUndoLastAddition" + i + title + "' type='button' onclick='addDoor(\"" + title + "\")' class='btnSubmit' style='display:inherit;' value='Undo Last Addition Doors'/>"));

                    tblDoorDetails.Rows.Add(doorButtonRow);

                    doorButtonRow.Cells.Add(doorAddButtonCell);
                    doorButtonRow.Cells.Add(doorFillButtonCell);
                    doorButtonRow.Cells.Add(doorUndoButtonCell);

                    #endregion

                    //Adding literal control div tag to hold the table, add to wallDoorOptions placeholder
                    wallDoorOptions.Controls.Add(new LiteralControl("<div class=\"toggleContent\" id=\"div_" + i + title + "\"><ul>"));

                    //Adding literal control li to keep proper page look and format
                    wallDoorOptions.Controls.Add(new LiteralControl("<li>"));

                    //Adding table to placeholder wallDoorOptions
                    wallDoorOptions.Controls.Add(tblDoorDetails);

                    //Closing necessary tags
                    wallDoorOptions.Controls.Add(new LiteralControl("</li></ul></div></li>"));
                }
            }

            #endregion
            //Closing more necessary tags
            wallDoorOptions.Controls.Add(new LiteralControl("</ul></li></ul></div></li>"));

            #endregion
        }

        protected void txtWallLengths_TextChanged(object sender, EventArgs e)
        { 
            
        }

        /// <summary>
        /// This method creates hidden fields dynamically on page load to store the values of wall lengths to be validated on client side
        /// </summary>
        /// <param name="number">the number of fields to create</param> 
        /// <returns>html hidden field tags</returns>
        protected string createHiddenFields(int number)
        {
            string html = ""; //empty string to store html hidden field tags

            for (int i = 1; i <= number; i++) //run through this loop as many times as the number of hidden fields to create
            {
                html += "<input id=\"hidWall" + i + "SetBack\" type=\"hidden\" runat=\"server\" />"; //hidden field for wall setback
                html += "<input id=\"hidWall" + i + "LeftFiller\" type=\"hidden\" runat=\"server\" />"; //hidden field for wall left filler
                html += "<input id=\"hidWall" + i + "Length\" type=\"hidden\" runat=\"server\" />"; //hidden field for wall length
                html += "<input id=\"hidWall" + i + "RightFiller\" type=\"hidden\" runat=\"server\" />"; //hidden field for wall right filler
                html += "<input id=\"hidWall" + i + "SoffitLength\" type=\"hidden\" runat=\"server\" />"; //hidden field for wall soffit length
                html += "<input id=\"hidWall" + i + "Slope\" type=\"hidden\" runat=\"server\" />"; //hidden field for wall slope
                
            }
            return html; //return the hidden field tags
        }

        /// <summary>
        /// This is an event, that is used to dynamically create wall objects with the appropriate details
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void createWallObjects(object sender, EventArgs e)
        {

            //there are issues with getting values from dynamically generated hidden fields
            //hard coded hidden fields work fine...
            //need to dynamically determine slope, and soffit length of each wall and store it in hidden fields



            float length, startHeight, endHeight, soffit, slope;
            string orientation, name, type, model;
            HiddenField wallLength, wallSoffit;
            for (int i = 0; i < strWalls.Count(); i++)
            {
                //find and store the dynamically created hidden fields
                wallLength = hiddenFieldsDiv.FindControl("hidWall" + i + "Length") as HiddenField; //wall length
                wallSoffit = hiddenFieldsDiv.FindControl("hidWall" + i + "SoffitLength") as HiddenField; //wall soffit length

                //length = wallLength.Value;
                //startHeight = Convert.ToSingle(hidBackWallHeight.Value);
                //endHeight = Convert.ToSingle(hidFrontWallHeight.Value);
                //soffit = Convert.ToSingle(wallSoffit.Value);
                slope = Convert.ToSingle(hidRoofSlope.Value);

                orientation = wallDetails[i, 5];
                name = "wall " + i;
                type = wallDetails[i, 4];
                model = currentModel;

                //string sof = wallSoffit.Value;
                //create a wall object with the appropriate values in the fields and attributes of it and add it to the walls list
                walls.Add(new Wall(Convert.ToSingle(wallLength.Value), wallDetails[i, 5], "Wall" + i, wallDetails[i, 4], Convert.ToSingle(hidBackWallHeight.Value), Convert.ToSingle(hidBackWallHeight.Value), /*Convert.ToSingle(wallSoffit.Value)*/ 0F, currentModel, Convert.ToSingle(hidRoofSlope.Value)));
            }
        }
    }
}
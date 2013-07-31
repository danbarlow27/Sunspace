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
        protected ListItem lst0 = new ListItem("---", "0", true); //0, i.e. no decimal value, selected by default
        protected ListItem lst18 = new ListItem("1/8", ".125");
        protected ListItem lst14 = new ListItem("1/4", ".25");
        protected ListItem lst38 = new ListItem("3/8", ".375");
        protected ListItem lst12 = new ListItem("1/2", ".5");
        protected ListItem lst58 = new ListItem("5/8", ".625");
        protected ListItem lst34 = new ListItem("3/4", ".75");
        protected ListItem lst78 = new ListItem("7/8", ".875");


        protected string currentModel;
        protected float sofftLength;

        protected const int SUGGESTED_DEFAULT_FILLER = 2;
        protected const int PREFERRED_DEFAULT_FILLER = 2;

        /***hard coded variables***/
        protected string coordList; //to store the string from the session and store it in a local variable for further use                                    
        protected char[] lineDelimiter = { '/' }; //character(s) that seperate lines in a session string variable
        protected char[] detailsDelimiter = { ',' }; //character(s) that seperate details of each line                                 
        protected string[] strWalls; //to split the string received from session and store it into an array of strings with individual line details
        protected string[,] wallDetails; //a two dimensional array to store the the details of each line individually as seperate elements ... 6 represents the number of detail items for each line

        protected void Page_Load(object sender, EventArgs e)
        {
            /***hard coded variables***/
            Session["model"] = "M200";
            Session["soffitLength"] = 0F;
            /****************diffrent sunroom layouts******************/
            //Session["coordList"] = "112.5,387.5,150,150,E,S/200,200,150,287.5,P,W/200,337.5,287.5,150,P,SE/";
            //Session["coordList"] = "75,425,150,150,E,S/150,150,150,250,P,W/150,350,250,250,P,S/350,350,250,150,P,E/";
            //Session["coordList"] = "62.5,362.5,162.5,162.5,E,S/362.5,175,162.5,350,E,NW/175,175,350,162.5,E,E/175,262.5,287.5,287.5,P,S/262.5,262.5,287.5,237.5,P,E/262.5,125,237.5,237.5,P,N/125,125,237.5,162.5,P,E/";
            //Session["coordList"] = "50,300,250,250,E,S/300,300,250,25,E,E/175,175,250,375,P,W/175,425,375,375,P,S/425,425,375,125,P,E/425,300,125,125,P,N/";
            Session["coordList"] = "75,262.5,175,175,E,S/262.5,262.5,175,200,E,W/262.5,425,200,200,E,S/150,150,175,300,P,W/150,350,300,300,P,S/350,350,300,200,P,E/";
            //Session["coordList"] = "100,412.5,137.5,137.5,E,S/150,150,137.5,287.5,P,W/150,225,287.5,362.5,P,SW/225,312.5,362.5,362.5,P,S/312,387.5,362.5,287.5,P,SE/387.5,387.5,287.5,137.5,P,E/";
            //Session["coordList"] = "112.5,350,112.5,112.5,E,S/350,350,112.5,337.5,E,W/175,175,112.5,262.5,P,W/175,350,262.5,262.5,P,S/";
            /**********************************************************/
            coordList = (string)Session["coordList"]; //get the string from the session and store it in a local variable for further use                                    
            strWalls = coordList.Split(lineDelimiter, StringSplitOptions.RemoveEmptyEntries); //split the string received from session and store it into an array of strings with individual line details
            wallDetails = new string[strWalls.Count(),6]; //a two dimensional array to store the the details of each line individually as seperate elements ... 6 represents the number of detail items for each line
            currentModel = (string)Session["model"];
            sofftLength = (float)Session["soffitLength"];
            //int existingWallCount = 0; //used to determine how many existing walls are in a drawing 
            int proposedWallCount = 0; //used to determine how many proposed walls are in a drawing

            //populate the array with all the wall details for each wall
            /***************************************************************************/
            /********************All of this can go to the page where ******************/
            /********************the coordList string is concatenated!******************/
            /***************************************************************************/
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

            
            for (int i = 1; i <= strWalls.Count(); i++) //for each wall in walls 
            {
                //if (wallDetails[i - 1, 4] == "E") //wall type is existing
                //{
                //    existingWallCount++; //increment the existing wall counter
                //    //populateTblExisting(i, existingWallCount); //populate the existing walls table on slide 1
                //}
                //else //wall type is proposed
                if (wallDetails[i - 1, 4] == "P")
                {
                    proposedWallCount++; //increment the proposed wall counter
                    populateTblProposed(i, proposedWallCount); //populate the proposed walls table on slide 1
                    populateWallDoorOptions(i, proposedWallCount); //populate slide 3 with appropriate proposed wall door options
                }
            }

            //do the windows stuff
            windowOptions();

        }

        /*
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
            
            //tblExistingWalls.Rows.Add(row); //append the row to the existing walls table

            //append all the cells to the row
            row.Cells.Add(cell1); 
            row.Cells.Add(cell2);
            row.Cells.Add(cell3);
        }
         */ 


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


            
        }

        protected void populateWallDoorOptions(int i, int proposedWallCount)
        {
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
            wallLabelRadio.ID = "lblRadioClickable" + i;
            wallLabelRadio.AssociatedControlID = "radWall" + i;   //Tying this label to the radio button

            Label wallLabel = new Label();
            wallLabel.ID = "lblTextArea" + i;
            wallLabel.AssociatedControlID = "radWall" + i;        //Tying this label to the radio button
            wallLabel.Text = "Proposed Wall " + proposedWallCount;       //Adding text to the radio button

            wallDoorOptions.Controls.Add(wallRadio);        //Adding radio button control to placeholder wallDoorOptions
            wallDoorOptions.Controls.Add(wallLabelRadio);   //Adding label control to placeholder wallDoorOptions
            wallDoorOptions.Controls.Add(wallLabel);        //Adding label control to placeholder wallDoorOptions

            //Creating div tag to hold all the current walls information (i.e. Cabana, French, Patio, Opening Only (No Door))
            wallDoorOptions.Controls.Add(new LiteralControl("<div id=\"doorDetails" + i + "\" class=\"toggleContent\">"));

            //Creating one ul tag to hold multiple li tags contain Cabana, French, Patio, Opening Only (No Door) options

            wallDoorOptions.Controls.Add(new LiteralControl("<ul>"));

            wallDoorOptions.Controls.Add(new LiteralControl("<li>"));

            wallDoorOptions.Controls.Add(new LiteralControl("<ul id='doorDetailsList" + i + "' class='toggleOptions'>"));

            #endregion

            //REGIONS WITHIN THIS REGION TO BE RENAMED APPROPRIATELY

            #region Loop to display door types as radio buttons

            //For loop to get through all the possible door types: Cabana, French, Patio, Opening Only (No Door)
            for (int typeCount = 1; typeCount <= 4; typeCount++)
            {
                //Conditional operator to set the current door type with the right label
                string title = (typeCount == 1) ? "Cabana" : (typeCount == 2) ? "French" : (typeCount == 3) ? "Patio" : "NoDoor";

                if (currentModel == "M400" && title == "French")
                {
                    wallDoorOptions.Controls.Add(new LiteralControl("<li style=\"display:none;\">"));
                }
                else
                {
                    //li tag to hold door type radio button and all its content
                    wallDoorOptions.Controls.Add(new LiteralControl("<li>"));
                }

                //Door type radio button
                RadioButton typeRadio = new RadioButton();
                typeRadio.ID = "radType" + i + title; //Adding appropriate id to door type radio button
                typeRadio.GroupName = "doorTypeRadios" + i;         //Adding group name for all door types
                typeRadio.Attributes.Add("onclick", "typeRowsDisplayed('" + title + "', '" + i + "')"); //On click event to display the proper fields/rows


                //Door type radio button label for clickable area
                Label typeLabelRadio = new Label();
                typeLabelRadio.AssociatedControlID = "radType" + i + title;   //Tying this label to the radio button

                //Door type radio button label text
                Label typeLabel = new Label();
                typeLabel.AssociatedControlID = "radType" + i + title;    //Tying this label to the radio button
                if (title == "NoDoor")
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
                doorStyleLBL.Text = "Style";

                DropDownList doorStyleDDL = new DropDownList();
                doorStyleDDL.ID = "ddlDoorStyle" + i + title;
                doorStyleDDL.Attributes.Add("onchange", "doorStyle('" + title + "','" + i + "')");
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
                    //doorStyleDDL.Items.Add(fullScreen);
                    doorStyleDDL.Items.Add(v4TCabana);
                    doorStyleDDL.Items.Add(fullView);
                    doorStyleDDL.Items.Add(fullViewColonial);
                }
                else if (currentModel == "M300")
                {
                    //doorStyleDDL.Items.Add(fullScreen);
                    doorStyleDDL.Items.Add(fullView);
                    doorStyleDDL.Items.Add(fullViewColonial);
                }
                else if (currentModel == "M400")
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
                doorVinylTintLBL.Text = "V4T Vinyl Tint:";

                DropDownList doorVinylTintDDL = new DropDownList();
                doorVinylTintDDL.ID = "ddlDoorVinylTint" + i + title;
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

                doorVinylTintLBL.AssociatedControlID = "ddlDoorVinylTint" + i + title;

                #endregion

                #region Table:Twelfth Row Door V4T Number Of Vents (tblDoorDetails)

                TableRow doorNumberOfVentsRow = new TableRow();
                doorNumberOfVentsRow.ID = "rowDoorNumberOfVents" + i + title;
                doorNumberOfVentsRow.Attributes.Add("style", "display:none;");
                TableCell doorNumberOfVentsLBLCell = new TableCell();
                TableCell doorNumberOfVentsDDLCell = new TableCell();

                Label doorNumberOfVentsLBL = new Label();
                doorNumberOfVentsLBL.ID = "lblNumberOfVents" + i + title;
                doorNumberOfVentsLBL.Text = "V4T Number Of Vents:";

                DropDownList doorNumberOfVentsDDL = new DropDownList();
                doorNumberOfVentsDDL.ID = "ddlDoorNumberOfVents" + i + title;
                ListItem two = new ListItem("2", "2");
                ListItem three = new ListItem("3", "3");
                ListItem four = new ListItem("4", "4");
                doorNumberOfVentsDDL.Items.Add(two);
                doorNumberOfVentsDDL.Items.Add(three);
                doorNumberOfVentsDDL.Items.Add(four);

                doorNumberOfVentsLBL.AssociatedControlID = "ddlDoorNumberOfVents" + i + title;

                #endregion

                #region Table:# Row Door Transom (tblDoorDetails)

                TableRow doorTransomRow = new TableRow();
                doorTransomRow.ID = "rowDoorTransom" + i + title;
                doorTransomRow.Attributes.Add("style", "display:none;");
                TableCell doorTransomLBLCell = new TableCell();
                TableCell doorTransomDDLCell = new TableCell();

                Label doorTransomLBL = new Label();
                doorTransomLBL.ID = "lblDoorTransom" + i + title;
                doorTransomLBL.Text = "Transom Type:";

                DropDownList doorTransomDDL = new DropDownList();
                doorTransomDDL.ID = "ddlDoorTransom" + i + title;
                doorTransomDDL.Attributes.Add("onchange", "doorTransomStyle('" + title + "','" + i + "')");
                ListItem transomVinyl = new ListItem("Vinyl", "vinyl");
                ListItem transomGlass = new ListItem("Glass", "glass");
                ListItem transomScreen = new ListItem("Screen", "screen");
                ListItem transomSolidWall = new ListItem("Solid Wall", "solidWall");

                doorTransomDDL.Items.Add(transomVinyl);

                if (currentModel == "M100")
                    doorTransomDDL.Items.Add(transomScreen);
                else
                    doorTransomDDL.Items.Add(transomGlass);

                doorTransomDDL.Items.Add(transomSolidWall);

                #endregion

                #region Table:# Row Door Transom Vinyl (tblDoorDetails)

                TableRow doorTransomVinylRow = new TableRow();
                doorTransomVinylRow.ID = "rowDoorTransomVinyl" + i + title;
                doorTransomVinylRow.Attributes.Add("style", "display:none;");
                TableCell doorTransomVinylTypesLBLCell = new TableCell();
                TableCell doorTransomVinylTypesDDLCell = new TableCell();

                Label doorTransomVinylLBL = new Label();
                doorTransomVinylLBL.ID = "lblDoorTransomVinyl" + i + title;
                doorTransomVinylLBL.Text = "Transom Vinyl Types:";

                DropDownList doorTransomVinylDDL = new DropDownList();
                doorTransomVinylDDL.ID = "ddlDoorTransomVinyl" + i + title;
                ListItem transomClearVinyl = new ListItem("Clear", "clear");
                ListItem transomSmokeGreyVinyl = new ListItem("Smoke Grey", "smokeGrey");
                ListItem transomDarkGreyVinyl = new ListItem("Dark Grey", "darkGrey");
                ListItem transomBronzeVinyl = new ListItem("Bronze", "bronze");
                ListItem transomMixedVinyl = new ListItem("Mixed", "mixed");
                doorTransomVinylDDL.Items.Add(transomClearVinyl);
                doorTransomVinylDDL.Items.Add(transomSmokeGreyVinyl);
                doorTransomVinylDDL.Items.Add(transomDarkGreyVinyl);
                doorTransomVinylDDL.Items.Add(transomBronzeVinyl);
                doorTransomVinylDDL.Items.Add(transomMixedVinyl);

                doorTransomVinylLBL.AssociatedControlID = "ddlDoorTransomVinyl" + i + title;

                #endregion

                #region Table:# Row Door Transom Glass Types (tblDoorDetails)

                TableRow doorTransomGlassRow = new TableRow();
                doorTransomGlassRow.ID = "rowDoorTransomGlass" + i + title;
                doorTransomGlassRow.Attributes.Add("style", "display:none;");
                TableCell doorTransomGlassTypesLBLCell = new TableCell();
                TableCell doorTransomGlassTypesDDLCell = new TableCell();

                Label doorTransomGlassLBL = new Label();
                doorTransomGlassLBL.ID = "lblDoorTransomGlass" + i + title;
                doorTransomGlassLBL.Text = "Transom Glass Types:";

                DropDownList doorTransomGlassDDL = new DropDownList();
                doorTransomGlassDDL.ID = "ddlDoorTransomGlass" + i + title;
                ListItem transomGrey = new ListItem("Grey", "grey");
                ListItem transomBronze = new ListItem("Bronze", "bronze");
                doorTransomGlassDDL.Items.Add(transomGrey);
                doorTransomGlassDDL.Items.Add(transomBronze);

                doorTransomGlassLBL.AssociatedControlID = "ddlDoorTransomGlass" + i + title;

                #endregion

                #region Table:# Row Door Kickplate (tblDoorDetails)

                TableRow doorKickplateRow = new TableRow();
                doorKickplateRow.ID = "rowDoorKickplate" + i + title;
                doorKickplateRow.Attributes.Add("style", "display:none;");
                TableCell doorKickplateLBLCell = new TableCell();
                TableCell doorKickplateDDLCell = new TableCell();

                Label doorKickplateLBL = new Label();
                doorKickplateLBL.ID = "lblDoorKickplate" + i + title;
                doorKickplateLBL.Text = "Kickplate Height:";

                DropDownList doorKickplateDDL = new DropDownList();
                doorKickplateDDL.ID = "ddlDoorKickplate" + i + title;
                doorKickplateDDL.Attributes.Add("onchange", "doorKickplateStyle('" + title + "','" + i + "')");
                ListItem KickplateSix = new ListItem("6\"", "6");
                ListItem KickplateSeven = new ListItem("7\"", "7");
                ListItem KickplateEight = new ListItem("8\"", "8");
                ListItem KickplateNine = new ListItem("9\"", "9");
                ListItem KickplateTen = new ListItem("10\"", "10");
                ListItem KickplateEleven = new ListItem("11\"", "11");
                ListItem KickplateTwelve = new ListItem("12\"", "12");
                ListItem KickplateThirteen = new ListItem("13\"", "13");
                ListItem KickplateFourteen = new ListItem("14\"", "14");
                ListItem KickplateFifteen = new ListItem("15\"", "15");
                ListItem KickplateSixteen = new ListItem("16\"", "16");
                ListItem KickplateSeventeen = new ListItem("17\"", "17");
                ListItem KickplateEighteen = new ListItem("18\"", "18");
                ListItem KickplateNineteen = new ListItem("19\"", "19");
                ListItem KickplateTwenty = new ListItem("20\"", "20");
                ListItem KickplateTwentyOne = new ListItem("21\"", "21");
                ListItem KickplateTwentyTwo = new ListItem("22\"", "22");
                ListItem KickplateTwentyThree = new ListItem("23\"", "23");
                ListItem KickplateTwentyFour = new ListItem("24\"", "24");
                ListItem KickplateCustom = new ListItem("Custom", "cKickplate");
                doorKickplateDDL.Items.Add(KickplateSix);
                doorKickplateDDL.Items.Add(KickplateSeven);
                doorKickplateDDL.Items.Add(KickplateEight);
                doorKickplateDDL.Items.Add(KickplateNine);
                doorKickplateDDL.Items.Add(KickplateTen);
                doorKickplateDDL.Items.Add(KickplateEleven);
                doorKickplateDDL.Items.Add(KickplateTwelve);
                doorKickplateDDL.Items.Add(KickplateThirteen);
                doorKickplateDDL.Items.Add(KickplateFourteen);
                doorKickplateDDL.Items.Add(KickplateFifteen);
                doorKickplateDDL.Items.Add(KickplateSixteen);
                doorKickplateDDL.Items.Add(KickplateSeventeen);
                doorKickplateDDL.Items.Add(KickplateEighteen);
                doorKickplateDDL.Items.Add(KickplateNineteen);
                doorKickplateDDL.Items.Add(KickplateTwenty);
                doorKickplateDDL.Items.Add(KickplateTwentyOne);
                doorKickplateDDL.Items.Add(KickplateTwentyTwo);
                doorKickplateDDL.Items.Add(KickplateTwentyThree);
                doorKickplateDDL.Items.Add(KickplateTwentyFour);
                doorKickplateDDL.Items.Add(KickplateCustom);

                #endregion

                #region Table:# Row Door Kickplate Custom (tblDoorDetails)

                TableRow doorCustomKickplateRow = new TableRow();
                doorCustomKickplateRow.ID = "rowDoorCustomKickplate" + i + title;
                doorCustomKickplateRow.Attributes.Add("style", "display:none;");
                TableCell doorCustomKickplateLBLCell = new TableCell();
                TableCell doorCustomKickplateTXTCell = new TableCell();
                TableCell doorCustomKickplateDDLCell = new TableCell();

                Label doorCustomKickplateLBL = new Label();
                doorCustomKickplateLBL.ID = "lblDoorCustomKickplate" + i + title;
                doorCustomKickplateLBL.Text = "Custom Kickplate (inches):";

                TextBox doorCustomKickplateTXT = new TextBox();
                doorCustomKickplateTXT.ID = "txtDoorKickplateCustom" + i + title;
                doorCustomKickplateTXT.CssClass = "txtField txtDoorInput";
                doorCustomKickplateTXT.Attributes.Add("maxlength", "3");

                DropDownList inchCustomKickplate = new DropDownList();
                inchCustomKickplate.ID = "ddlDoorKickplateCustom" + i + title;
                inchCustomKickplate.Items.Add(lst0);
                inchCustomKickplate.Items.Add(lst18);
                inchCustomKickplate.Items.Add(lst14);
                inchCustomKickplate.Items.Add(lst38);
                inchCustomKickplate.Items.Add(lst12);
                inchCustomKickplate.Items.Add(lst58);
                inchCustomKickplate.Items.Add(lst34);
                inchCustomKickplate.Items.Add(lst78);

                doorCustomKickplateLBL.AssociatedControlID = "txtDoorKickplateCustom" + i + title;

                #endregion

                #region Table:Third Row Color of Door (tblDoorDetails)

                TableRow colorOfDoorRow = new TableRow();
                colorOfDoorRow.ID = "rowDoorColor" + i + title;
                colorOfDoorRow.Attributes.Add("style", "display:none;");
                TableCell colorOfDoorLBLCell = new TableCell();
                TableCell colorOfDoorDDLCell = new TableCell();

                Label colorOfDoorLBL = new Label();
                colorOfDoorLBL.ID = "lblDoorColor" + i + title;
                colorOfDoorLBL.Text = "Color:";

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

                #region Table:# Row Door Internal Grills Yes(tblDoorDetails)

                TableRow doorInternalGrillsYesRow = new TableRow();
                doorInternalGrillsYesRow.ID = "rowDoorInternalGrillsYes" + i + title;
                doorInternalGrillsYesRow.Attributes.Add("style", "display:none;");
                TableCell doorInternalGrillsYesLBLCell = new TableCell();
                TableCell doorInternalGrillsYesRADCell = new TableCell();

                Label doorInternalGrillsYesLBLMain = new Label();
                doorInternalGrillsYesLBLMain.ID = "lblDoorInternalGrillsMain" + i + title;
                doorInternalGrillsYesLBLMain.Text = "Internal Grills:";

                Label doorInternalGrillsYesLBLRad = new Label();
                doorInternalGrillsYesLBLRad.ID = "lblDoorInternalGrillRadYes" + i + title;

                Label doorInternalGrillsYesLBL = new Label();
                doorInternalGrillsYesLBL.ID = "lblDoorInternalGrillsYes" + i + title;
                doorInternalGrillsYesLBL.Text = "Yes";

                RadioButton doorInternalGrillsYesRad = new RadioButton();
                doorInternalGrillsYesRad.ID = "radDoorInternalGrills" + i + title;
                doorInternalGrillsYesRad.Attributes.Add("value", "yes");
                doorInternalGrillsYesRad.GroupName = "InternalGrills" + i + title;

                doorInternalGrillsYesLBLRad.AssociatedControlID = "radDoorInternalGrills" + i + title;
                doorInternalGrillsYesLBL.AssociatedControlID = "radDoorInternalGrills" + i + title;

                #endregion

                #region Table:# Row Door Internal Grills No (tblDoorDetails)

                TableRow doorInternalGrillsNoRow = new TableRow();
                doorInternalGrillsNoRow.ID = "rowDoorInternalGrillsNo" + i + title;
                doorInternalGrillsNoRow.Attributes.Add("style", "display:none;");
                TableCell doorInternalGrillsNoLBLCell = new TableCell();
                TableCell doorInternalGrillsNoRADCell = new TableCell();

                Label doorInternalGrillsNoLBLRad = new Label();
                doorInternalGrillsNoLBLRad.ID = "lblDoorInternalGrillsRadNo" + i + title;

                Label doorInternalGrillsNoLBL = new Label();
                doorInternalGrillsNoLBL.ID = "lblDoorInternalGrillsNo" + i + title;
                doorInternalGrillsNoLBL.Text = "No";

                RadioButton doorInternalGrillsNoRad = new RadioButton();
                doorInternalGrillsNoRad.ID = "radDoorInternalGrillsNo" + i + title;
                doorInternalGrillsNoRad.Attributes.Add("value", "no");
                doorInternalGrillsNoRad.GroupName = "InternalGrills" + i + title;

                doorInternalGrillsNoLBLRad.AssociatedControlID = "radDoorInternalGrillsNo" + i + title;
                doorInternalGrillsNoLBL.AssociatedControlID = "radDoorInternalGrillsNo" + i + title;

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
                doorHeightDDL.Attributes.Add("onchange", "customDimension('" + i + "','" + title + "','Height')");
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
                doorCustomHeightTXT.ID = "txtDoorHeightCustom" + i + title;
                doorCustomHeightTXT.CssClass = "txtField txtDoorInput";
                doorCustomHeightTXT.Attributes.Add("maxlength", "3");

                DropDownList inchCustomHeight = new DropDownList();
                inchCustomHeight.ID = "ddlDoorHeightCustom" + i + title;
                inchCustomHeight.Items.Add(lst0);
                inchCustomHeight.Items.Add(lst18);
                inchCustomHeight.Items.Add(lst14);
                inchCustomHeight.Items.Add(lst38);
                inchCustomHeight.Items.Add(lst12);
                inchCustomHeight.Items.Add(lst58);
                inchCustomHeight.Items.Add(lst34);
                inchCustomHeight.Items.Add(lst78);

                doorCustomHeightLBL.AssociatedControlID = "txtDoorHeightCustom" + i + title;

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
                doorWidthDDL.Attributes.Add("onchange", "customDimension('" + i + "', '" + title + "','Width')");
                ListItem thirty = new ListItem("30\"", "30");
                ListItem thirtyTwo = new ListItem("32\"", "32");
                ListItem thirtyFour = new ListItem("34\"", "34");
                ListItem thirtySix = new ListItem("36\"", "36");
                ListItem sixty = new ListItem("60\"", "30");
                ListItem seventyTwo = new ListItem("72\"", "36");
                ListItem fiveFeet = new ListItem("5'", "60");
                ListItem sixFeet = new ListItem("6'", "72");
                ListItem sevenFeet = new ListItem("7'", "84");
                ListItem eightFeet = new ListItem("8'", "96");
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
                doorCustomWidthTXT.ID = "txtDoorWidthCustom" + i + title;
                doorCustomWidthTXT.CssClass = "txtField txtDoorInput";
                doorCustomWidthTXT.Attributes.Add("maxlength", "3");

                DropDownList inchCustomWidth = new DropDownList();
                inchCustomWidth.ID = "ddlDoorWidthCustom" + i + title;
                inchCustomWidth.Items.Add(lst0);
                inchCustomWidth.Items.Add(lst18);
                inchCustomWidth.Items.Add(lst14);
                inchCustomWidth.Items.Add(lst38);
                inchCustomWidth.Items.Add(lst12);
                inchCustomWidth.Items.Add(lst58);
                inchCustomWidth.Items.Add(lst34);
                inchCustomWidth.Items.Add(lst78);

                doorCustomWidthLBL.AssociatedControlID = "txtDoorWidthCustom" + i + title;

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
                doorOperatorLHHLBL.Text = "Left";

                RadioButton doorOperatorLHHRad = new RadioButton();
                doorOperatorLHHRad.ID = "radDoorOperator" + i + title;
                doorOperatorLHHRad.Attributes.Add("value", "left");
                doorOperatorLHHRad.GroupName = "PrimaryOperator" + i + title;

                doorOperatorLHHLBLRad.AssociatedControlID = "radDoorOperator" + i + title;
                doorOperatorLHHLBL.AssociatedControlID = "radDoorOperator" + i + title;

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
                doorOperatorRHHLBL.Text = "Right";

                RadioButton doorOperatorRHHRad = new RadioButton();
                doorOperatorRHHRad.ID = "radDoorOperatorRHH" + i + title;
                doorOperatorRHHRad.Attributes.Add("value", "right");
                doorOperatorRHHRad.GroupName = "PrimaryOperator" + i + title;

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

                TableRow doorHingeLHHRow = new TableRow();
                doorHingeLHHRow.ID = "rowDoorHingeLHH" + i + title;
                doorHingeLHHRow.Attributes.Add("style", "display:none;");
                TableCell doorHingeLHHLBLCell = new TableCell();
                TableCell doorHingeLHHRADCell = new TableCell();

                Label doorHingeLHHLBLMain = new Label();
                doorHingeLHHLBLMain.ID = "lblDoorHingeLHHMain" + i + title;
                doorHingeLHHLBLMain.Text = "Hinge placement:";

                Label doorHingeLHHLBLRad = new Label();
                doorHingeLHHLBLRad.ID = "lblHingeLHHRad" + i + title;

                Label doorHingeLHHLBL = new Label();
                doorHingeLHHLBL.ID = "lblHingeLHH" + i + title;
                doorHingeLHHLBL.Text = "Left";

                RadioButton doorHingeLHHRad = new RadioButton();
                doorHingeLHHRad.ID = "radDoorHinge" + i + title;
                doorHingeLHHRad.Attributes.Add("value", "left");
                doorHingeLHHRad.GroupName = "DoorHinge" + i + title;

                doorHingeLHHLBLRad.AssociatedControlID = "radDoorHinge" + i + title;
                doorHingeLHHLBL.AssociatedControlID = "radDoorHinge" + i + title;

                #endregion

                #region Table:Eleventh Row Door Hinge RHH (tblDoorDetails)

                TableRow doorHingeRHHRow = new TableRow();
                doorHingeRHHRow.ID = "rowDoorHingeRHH" + i + title;
                doorHingeRHHRow.Attributes.Add("style", "display:none;");
                TableCell doorHingeRHHLBLCell = new TableCell();
                TableCell doorHingeRHHRADCell = new TableCell();

                Label doorHingeRHHLBLRad = new Label();
                doorHingeRHHLBLRad.ID = "lblDoorHingeRHHRad" + i + title;

                Label doorHingeRHHLBL = new Label();
                doorHingeRHHLBL.ID = "lblDoorHingeRHH" + i + title;
                doorHingeRHHLBL.Text = "Right";

                RadioButton doorHingeRHHRad = new RadioButton();
                doorHingeRHHRad.ID = "radDoorHingeRHH" + i + title;
                doorHingeRHHRad.Attributes.Add("value", "right");
                doorHingeRHHRad.GroupName = "DoorHinge" + i + title;

                doorHingeRHHLBLRad.AssociatedControlID = "radDoorHingeRHH" + i + title;
                doorHingeRHHLBL.AssociatedControlID = "radDoorHingeRHH" + i + title;

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
                doorSwingInRAD.ID = "radDoorSwing" + i + title;
                doorSwingInRAD.Attributes.Add("value", "in");
                doorSwingInRAD.GroupName = "SwingInOut" + i + title;

                doorSwingInLBLRad.AssociatedControlID = "radDoorSwing" + i + title;
                doorSwingInLBL.AssociatedControlID = "radDoorSwing" + i + title;

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
                doorSwingOutRAD.Attributes.Add("value", "out");
                doorSwingOutRAD.GroupName = "SwingInOut" + i + title;

                doorSwingOutLBLRad.AssociatedControlID = "radDoorSwingOut" + i + title;
                doorSwingOutLBL.AssociatedControlID = "radDoorSwingOut" + i + title;

                #endregion

                #region Table:# Row Door Position DDL (tblDoorDetails)

                TableRow doorPositionDDLRow = new TableRow();
                doorPositionDDLRow.ID = "rowDoorPosition" + i + title;
                doorPositionDDLRow.Attributes.Add("style", "display:none;");
                TableCell doorPositionDDLLBLCell = new TableCell();
                TableCell doorPositionDDLDDLCell = new TableCell();

                Label doorPositionDDLLBL = new Label();
                doorPositionDDLLBL.ID = "lblDoorPositionDDL" + i + title;
                doorPositionDDLLBL.Text = "Position In Wall:";

                DropDownList doorPositionDDLDDL = new DropDownList();
                doorPositionDDLDDL.ID = "ddlDoorPosition" + i + title;
                doorPositionDDLDDL.Attributes.Add("onchange", "customDimension('" + i + "', '" + title + "','Position')");
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

                #region Table:# Row Door Position Custom (tblDoorDetails)

                TableRow doorPositionRow = new TableRow();
                doorPositionRow.ID = "rowDoorCustomPosition" + i + title;
                doorPositionRow.Attributes.Add("style", "display:none;");
                TableCell doorPositionLBLCell = new TableCell();
                TableCell doorPositionTXTCell = new TableCell();
                TableCell doorPositionDDLCell = new TableCell();

                Label doorPositionLBL = new Label();
                doorPositionLBL.ID = "lblDoorCustomPosition" + i + title;
                doorPositionLBL.Text = "Door position from left side (inches):";

                TextBox doorPositionTXT = new TextBox();
                doorPositionTXT.ID = "txtDoorPositionCustom" + i + title;
                doorPositionTXT.CssClass = "txtField txtDoorInput";
                doorPositionTXT.Attributes.Add("maxlength", "3");

                DropDownList inchSpecificLeft = new DropDownList();
                inchSpecificLeft.ID = "ddlDoorPositionCustom" + i + title;
                inchSpecificLeft.Items.Add(lst0);
                inchSpecificLeft.Items.Add(lst18);
                inchSpecificLeft.Items.Add(lst14);
                inchSpecificLeft.Items.Add(lst38);
                inchSpecificLeft.Items.Add(lst12);
                inchSpecificLeft.Items.Add(lst58);
                inchSpecificLeft.Items.Add(lst34);
                inchSpecificLeft.Items.Add(lst78);

                doorPositionLBL.AssociatedControlID = "txtDoorPositionCustom" + i + title;

                #endregion

                #region Table:# Row Add This Door (tblDoorDetails)

                TableRow doorButtonRow = new TableRow();
                doorButtonRow.ID = "rowAddDoor" + i + title;
                doorButtonRow.Attributes.Add("style", "display:inherit;");
                TableCell doorAddButtonCell = new TableCell();
                TableCell doorFillButtonCell = new TableCell();

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

                #region Table:Twelfth Row Door V4T Number Of Vents Added To Table (tblDoorDetails)

                doorNumberOfVentsLBLCell.Controls.Add(doorNumberOfVentsLBL);
                doorNumberOfVentsDDLCell.Controls.Add(doorNumberOfVentsDDL);

                tblDoorDetails.Rows.Add(doorNumberOfVentsRow);

                doorNumberOfVentsRow.Cells.Add(doorNumberOfVentsLBLCell);
                doorNumberOfVentsRow.Cells.Add(doorNumberOfVentsDDLCell);

                #endregion

                #region Table:# Row Door Transom Added To Table (tblDoorDetails)

                doorTransomLBLCell.Controls.Add(doorTransomLBL);
                doorTransomDDLCell.Controls.Add(doorTransomDDL);

                tblDoorDetails.Rows.Add(doorTransomRow);

                doorTransomRow.Cells.Add(doorTransomLBLCell);
                doorTransomRow.Cells.Add(doorTransomDDLCell);

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

                colorOfDoorLBLCell.Controls.Add(colorOfDoorLBL);
                colorOfDoorDDLCell.Controls.Add(colorOfDoorDDL);

                tblDoorDetails.Rows.Add(colorOfDoorRow);

                colorOfDoorRow.Cells.Add(colorOfDoorLBLCell);
                colorOfDoorRow.Cells.Add(colorOfDoorDDLCell);

                #endregion

                #region Table:# Row Door Internal Grills Yes Added To Table (tblDoorDetails)

                doorInternalGrillsYesLBLCell.Controls.Add(doorInternalGrillsYesLBLMain);

                doorInternalGrillsYesRADCell.Controls.Add(doorInternalGrillsYesRad);
                doorInternalGrillsYesRADCell.Controls.Add(doorInternalGrillsYesLBLRad);
                doorInternalGrillsYesRADCell.Controls.Add(doorInternalGrillsYesLBL);

                tblDoorDetails.Rows.Add(doorInternalGrillsYesRow);

                doorInternalGrillsYesRow.Cells.Add(doorInternalGrillsYesLBLCell);
                doorInternalGrillsYesRow.Cells.Add(doorInternalGrillsYesRADCell);

                #endregion

                #region Table:# Row Door Internal Grills No Added To Table (tblDoorDetails)

                doorInternalGrillsNoRADCell.Controls.Add(doorInternalGrillsNoRad);
                doorInternalGrillsNoRADCell.Controls.Add(doorInternalGrillsNoLBLRad);
                doorInternalGrillsNoRADCell.Controls.Add(doorInternalGrillsNoLBL);

                tblDoorDetails.Rows.Add(doorInternalGrillsNoRow);

                doorInternalGrillsNoRow.Cells.Add(doorInternalGrillsNoLBLCell);
                doorInternalGrillsNoRow.Cells.Add(doorInternalGrillsNoRADCell);

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

                if (title == "NoDoor")
                {
                    doorAddButtonCell.Controls.Add(new LiteralControl("<input id='btnAddthisDoor" + i + title + "' type='button' onclick='addDoor(\"" + i + "\", \"" + title + "\")' class='btnSubmit' style='display:inherit;' value='Add This Opening Only (No Door)'/>"));
                    doorFillButtonCell.Controls.Add(new LiteralControl("<input id='btnFillWallWithThisDoor" + i + title + "' type='button' onclick='fillWallWithDoorMods(\"" + title + "\", \"" + i + "\")' class='btnSubmit' style='display:inherit;' value='Fill Wall With Opening Only (No Doors)'/>"));
                }
                else
                {
                    doorAddButtonCell.Controls.Add(new LiteralControl("<input id='btnAddthisDoor" + i + title + "' type='button' onclick='addDoor(\"" + i + "\", \"" + title + "\")' class='btnSubmit' style='display:inherit;' value='Add This " + title + " Door'/>"));
                    doorFillButtonCell.Controls.Add(new LiteralControl("<input id='btnFillWallWithThisDoor" + i + title + "' type='button' onclick='fillWallWithDoorMods(\"" + title + "\", \"" + i + "\")' class='btnSubmit' style='display:inherit;' value='Fill Wall With " + title + " Doors'/>"));
                }

                tblDoorDetails.Rows.Add(doorButtonRow);

                doorButtonRow.Cells.Add(doorAddButtonCell);
                doorButtonRow.Cells.Add(doorFillButtonCell);

                #endregion

                //Adding literal control div tag to hold the table, add to wallDoorOptions placeholder
                wallDoorOptions.Controls.Add(new LiteralControl("<div class=\"toggleContent\" id=\"div_" + i + title + "\">"));

                wallDoorOptions.Controls.Add(new LiteralControl("<ul>"));

                //Adding literal control li to keep proper page look and format
                wallDoorOptions.Controls.Add(new LiteralControl("<li>"));

                //Adding table to placeholder wallDoorOptions
                wallDoorOptions.Controls.Add(tblDoorDetails);

                //Closing necessary tags
                wallDoorOptions.Controls.Add(new LiteralControl("</li>"));

                wallDoorOptions.Controls.Add(new LiteralControl("</ul>"));

                wallDoorOptions.Controls.Add(new LiteralControl("</div>"));

                wallDoorOptions.Controls.Add(new LiteralControl("</li>"));

            }

            #endregion
            //Closing more necessary tags
            wallDoorOptions.Controls.Add(new LiteralControl("</ul>"));

            wallDoorOptions.Controls.Add(new LiteralControl("</li>"));

            wallDoorOptions.Controls.Add(new LiteralControl("</ul>"));

            wallDoorOptions.Controls.Add(new LiteralControl("</div>"));

            wallDoorOptions.Controls.Add(new LiteralControl("</li>"));

            #endregion

            #region Slide 3: Create pager divs for each wall, one for space remaining and one for doors added

            #region Space Remaining LI Tag

            pager3Information.Controls.Add(new LiteralControl("<li id=\"wall" + i + "SpaceRemaining\" style='display:none;' >"));

            pager3Information.Controls.Add(new LiteralControl("<a href=\"#\" data-slide=\"#slide3\" class=\"slidePanel\">"));

            Label lblQuestion3SpaceInfo = new Label();
            lblQuestion3SpaceInfo.ID = "lblQuestion3SpaceInfoWall" + i;
            lblQuestion3SpaceInfo.Attributes.Add("runat", "server");
            lblQuestion3SpaceInfo.Text = "The Remaining Space In Wall " + proposedWallCount;

            Label lblQuestion3SpaceInfoAnswer = new Label();
            lblQuestion3SpaceInfoAnswer.ID = "lblQuestion3SpaceInfoWallAnswer" + i;
            lblQuestion3SpaceInfoAnswer.Attributes.Add("runat", "server");
            lblQuestion3SpaceInfoAnswer.Text = "";

            pager3Information.Controls.Add(lblQuestion3SpaceInfo);
            pager3Information.Controls.Add(lblQuestion3SpaceInfoAnswer);

            pager3Information.Controls.Add(new LiteralControl("</a>"));

            pager3Information.Controls.Add(new LiteralControl("</li>"));

            #endregion

            #region Doors Added LI Tag

            pager3Information.Controls.Add(new LiteralControl("<li id=\"wall" + i + "DoorsAdded\" style='display:none;' >"));

            pager3Information.Controls.Add(new LiteralControl("<a href=\"#\" data-slide=\"#slide3\" class=\"slidePanel\">"));

            Label lblQuestion3DoorsInfo = new Label();
            lblQuestion3DoorsInfo.ID = "lblQuestion3DoorsInfoWall" + i;
            lblQuestion3DoorsInfo.Attributes.Add("runat", "server");
            lblQuestion3DoorsInfo.Text = "";

            Label lblQuestion3DoorsInfoAnswer = new Label();
            lblQuestion3DoorsInfoAnswer.ID = "lblQuestion3DoorsInfoWallAnswer" + i;
            lblQuestion3DoorsInfoAnswer.Attributes.Add("runat", "server");
            lblQuestion3DoorsInfoAnswer.Text = "";

            pager3Information.Controls.Add(lblQuestion3DoorsInfo);
            pager3Information.Controls.Add(lblQuestion3DoorsInfoAnswer);

            pager3Information.Controls.Add(new LiteralControl("</a>"));

            pager3Information.Controls.Add(new LiteralControl("</li>"));

            #endregion

            #endregion
        }

        #region window stuff

        /*
         * fill all the usable space with largest size windows
         * if extra usable space left over, divide the window size in 2 and add a window
         * if some weird size of extra space left over, add filler 
         */


        /// <summary>
        /// This method creates radio buttons/dropdowns for window frame colour options for all models 
        /// </summary>
        /// <param name="bronze">true or false, if bronze is an option</param>
        /// <param name="white">true or false, if white is an option, true by default</param>
        /// <param name="driftwood">true or false, if driftwood is an option, true by default</param>
        /// <param name="green">true or false, if green is an option, false by default</param>
        /// <param name="black">true or false, if black is an option, false by default</param>
        /// <param name="ivory">true or false, if ivory is an option, false by default</param>
        /// <param name="cherrywood">true or false, if cherrywood is an option, false by default</param>
        /// <param name="grey">true or false, if grey is an option, false by default</param>
        protected void windowFramingColourOptions(bool bronze, bool white = true, bool driftwood = true, bool green = false, bool black = false, bool ivory = false, bool cherrywood = false, bool grey = false)
        {

            wallWindowOptions.Controls.Add(new LiteralControl("<br/><h2>Framing Colour: </h2>"));

            #region framing colour dropdown

            /*

            ////Creating div tag to hold all the current window type information 
            //wallWindowOptions.Controls.Add(new LiteralControl("<li><div id='framingWindowDetails' class='toggleContent'>"));

            //RadioButton frameRadio = new RadioButton();
            //frameRadio.ID = "radFrameColour";     //Giving an appropriate id to radio buttons based on current type of window
            //frameRadio.GroupName = "windowTypeRadios";     //Giving an appropriate group name to all windowtype radio buttons

            ////Label to create clickable area for radio button
            //Label frameLabelRadio = new Label();
            //frameLabelRadio.AssociatedControlID = "radFrameColour";   //Tying this label to the radio button

            //Label frameLabel = new Label();
            //frameLabel.AssociatedControlID = "radFrameColour";        //Tying this label to the radio button
            //frameLabel.Text = "radio";       //Adding text to the radio button

            //Creating one ul tag to hold multiple li tags containing vinyl tints
            //wallWindowOptions.Controls.Add(new LiteralControl("<ul><li><ul id='framingDetailsList' class='toggleOptions'>"));

            Table tblFrameColours = new Table(); //table to hold vinyl number labels and dropdown options

            //tblFrameColours.AssociatedControlID = "radFrameColour";
            tblFrameColours.ID = "tblWindowFramingColour"; //Adding appropriate id to the table
            tblFrameColours.CssClass = "tblTextFields";   //Adding CssClass to the table for styling

            TableRow mixedVinylTintRow = new TableRow();
            mixedVinylTintRow.ID = "rowWindowFramingColour";
            //mixedVinylTintRow.Attributes.Add("style", "display:none;");
            TableCell mixedVinylTintLabelCell = new TableCell();
            TableCell mixedVinylTintDropDownCell = new TableCell();

            Label mixedVinylTintLabel = new Label();
            mixedVinylTintLabel.ID = "lblWindowFramingColour";
            mixedVinylTintLabel.Text = "Window Framing Colour: ";
            DropDownList ddlVinylTintOptions = new DropDownList();
            ddlVinylTintOptions.ID = "ddlWindowFramingColour";

            if (bronze)
            {
                ListItem bronzeFrame = new ListItem("Bronze", "bronze");
                ddlVinylTintOptions.Items.Add(bronzeFrame);

            }
            if (white)
            {
                ListItem whiteFrame = new ListItem("White", "white");
                ddlVinylTintOptions.Items.Add(whiteFrame);
            }
            if (driftwood)
            {
                ListItem driftwoodFrame = new ListItem("Driftwood", "driftwood");
                ddlVinylTintOptions.Items.Add(driftwoodFrame);
            }
            if (green)
            {
                ListItem greenFrame = new ListItem("Green", "green");
                ddlVinylTintOptions.Items.Add(greenFrame);
            }
            if (black)
            {
                ListItem blackFrame = new ListItem("Black", "black");
                ddlVinylTintOptions.Items.Add(blackFrame);
            }
            if (ivory)
            {
                ListItem ivoryFrame = new ListItem("Ivory", "ivory");
                ddlVinylTintOptions.Items.Add(ivoryFrame);
            }
            if (cherrywood)
            {
                ListItem cherrywoodFrame = new ListItem("Cherrywood", "cherrywood");
                ddlVinylTintOptions.Items.Add(cherrywoodFrame);
            }
            if (grey)
            {
                ListItem greyFrame = new ListItem("Grey", "grey");
                ddlVinylTintOptions.Items.Add(greyFrame);
            }

            mixedVinylTintLabel.AssociatedControlID = "ddlWindowFramingColour";

            mixedVinylTintLabelCell.Controls.Add(mixedVinylTintLabel);
            mixedVinylTintDropDownCell.Controls.Add(ddlVinylTintOptions);

            tblFrameColours.Rows.Add(mixedVinylTintRow);

            mixedVinylTintRow.Cells.Add(mixedVinylTintLabelCell);
            mixedVinylTintRow.Cells.Add(mixedVinylTintDropDownCell);

            wallWindowOptions.Controls.Add(tblFrameColours);

            //wallWindowOptions.Controls.Add(new LiteralControl("</ul></li></ul></div></li>")); //close the previously opened tags

             * 
             */ 
            #endregion


            #region framing colour radios

            RadioButton frameRadio;
            Label frameLabelRadio, frameLabel;

            if (bronze)
            {
                #region Bronze

                //li tag to hold window type radio button and all its content
                wallWindowOptions.Controls.Add(new LiteralControl("<li>"));

                //Vinyl tint radio button
                frameRadio = new RadioButton();
                frameRadio.ID = "radFrameBronze"; //Adding appropriate id to window type radio button
                frameRadio.GroupName = "FrameColourRadios";         //Adding group name for all tint colours
                //frameRadio.Checked = (currentModel == "M200") ? true : false; //select/check the radio button if current select is defualt value
                //typeRadio.Attributes.Add("onclick", "typeRowsDisplayed()"); //On click event to display the proper fields/rows

                //Vinyl tint radio button label for clickable area
                frameLabelRadio = new Label();
                frameLabelRadio.AssociatedControlID = "radFrameBronze";  //Tying this label to the radio button

                //Vinyl tint radio button label text
                frameLabel = new Label();
                frameLabel.AssociatedControlID = "radFrameBronze";    //Tying this label to the radio button
                frameLabel.Text = "Bronze";

                wallWindowOptions.Controls.Add(frameRadio);        //Adding radio button control to placeholder wallWindowOptions
                wallWindowOptions.Controls.Add(frameLabelRadio);   //Adding label control to placeholder wallWindowOptions
                wallWindowOptions.Controls.Add(frameLabel);        //Adding label control to placeholder wallWindowOptions
                wallWindowOptions.Controls.Add(new LiteralControl("</li>"));

                #endregion
            }

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            if (white)
            {
                #region White

                //li tag to hold window type radio button and all its content
                wallWindowOptions.Controls.Add(new LiteralControl("<li>"));

                //Vinyl tint radio button
                frameRadio = new RadioButton();
                frameRadio.ID = "radFrameWhite"; //Adding appropriate id to window type radio button
                frameRadio.GroupName = "FrameColourRadios";         //Adding group name for all tint colours
                //typeRadio.Attributes.Add("onclick", "typeRowsDisplayed()"); //On click event to display the proper fields/rows

                //Vinyl tint radio button label for clickable area
                frameLabelRadio = new Label();
                frameLabelRadio.AssociatedControlID = "radFrameWhite";  //Tying this label to the radio button

                //Vinyl tint radio button label text
                frameLabel = new Label();
                frameLabel.AssociatedControlID = "radFrameWhite";    //Tying this label to the radio button
                frameLabel.Text = "White";

                wallWindowOptions.Controls.Add(frameRadio);        //Adding radio button control to placeholder wallWindowOptions
                wallWindowOptions.Controls.Add(frameLabelRadio);   //Adding label control to placeholder wallWindowOptions
                wallWindowOptions.Controls.Add(frameLabel);        //Adding label control to placeholder wallWindowOptions
                wallWindowOptions.Controls.Add(new LiteralControl("</li>"));

                #endregion
            }

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            if (driftwood)
            {
                #region Driftwood

                //li tag to hold window type radio button and all its content
                wallWindowOptions.Controls.Add(new LiteralControl("<li>"));

                //Vinyl tint radio button
                frameRadio = new RadioButton();
                frameRadio.ID = "radFrameDriftwood"; //Adding appropriate id to window type radio button
                frameRadio.GroupName = "FrameColourRadios";         //Adding group name for all tint colours
                //typeRadio.Attributes.Add("onclick", "typeRowsDisplayed()"); //On click event to display the proper fields/rows

                //Vinyl tint radio button label for clickable area
                frameLabelRadio = new Label();
                frameLabelRadio.AssociatedControlID = "radFrameDriftwood";  //Tying this label to the radio button

                //Vinyl tint radio button label text
                frameLabel = new Label();
                frameLabel.AssociatedControlID = "radFrameDriftwood";    //Tying this label to the radio button
                frameLabel.Text = "Driftwood";

                wallWindowOptions.Controls.Add(frameRadio);        //Adding radio button control to placeholder wallWindowOptions
                wallWindowOptions.Controls.Add(frameLabelRadio);   //Adding label control to placeholder wallWindowOptions
                wallWindowOptions.Controls.Add(frameLabel);        //Adding label control to placeholder wallWindowOptions
                wallWindowOptions.Controls.Add(new LiteralControl("</li>"));

                #endregion
            }

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            if (grey)
            {
                #region Grey

                //li tag to hold window type radio button and all its content
                wallWindowOptions.Controls.Add(new LiteralControl("<li>"));

                //Vinyl tint radio button
                frameRadio = new RadioButton();
                frameRadio.ID = "radFrameGrey"; //Adding appropriate id to window type radio button
                frameRadio.GroupName = "FrameColourRadios";         //Adding group name for all tint colours
                //typeRadio.Attributes.Add("onclick", "typeRowsDisplayed()"); //On click event to display the proper fields/rows

                //Vinyl tint radio button label for clickable area
                frameLabelRadio = new Label();
                frameLabelRadio.AssociatedControlID = "radFrameGrey";  //Tying this label to the radio button

                //Vinyl tint radio button label text
                frameLabel = new Label();
                frameLabel.AssociatedControlID = "radFrameGrey";    //Tying this label to the radio button
                frameLabel.Text = "Grey";

                wallWindowOptions.Controls.Add(frameRadio);        //Adding radio button control to placeholder wallWindowOptions
                wallWindowOptions.Controls.Add(frameLabelRadio);   //Adding label control to placeholder wallWindowOptions
                wallWindowOptions.Controls.Add(frameLabel);        //Adding label control to placeholder wallWindowOptions
                wallWindowOptions.Controls.Add(new LiteralControl("</li>"));

                #endregion
            }

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            if (green)
            {
                #region Green

                //li tag to hold window type radio button and all its content
                wallWindowOptions.Controls.Add(new LiteralControl("<li>"));

                //Vinyl tint radio button
                frameRadio = new RadioButton();
                frameRadio.ID = "radFrameGreen"; //Adding appropriate id to window type radio button
                frameRadio.GroupName = "FrameColourRadios";         //Adding group name for all tint colours
                //typeRadio.Attributes.Add("onclick", "typeRowsDisplayed()"); //On click event to display the proper fields/rows

                //Vinyl tint radio button label for clickable area
                frameLabelRadio = new Label();
                frameLabelRadio.AssociatedControlID = "radFrameGreen";  //Tying this label to the radio button

                //Vinyl tint radio button label text
                frameLabel = new Label();
                frameLabel.AssociatedControlID = "radFrameGreen";    //Tying this label to the radio button
                frameLabel.Text = "Green";

                wallWindowOptions.Controls.Add(frameRadio);        //Adding radio button control to placeholder wallWindowOptions
                wallWindowOptions.Controls.Add(frameLabelRadio);   //Adding label control to placeholder wallWindowOptions
                wallWindowOptions.Controls.Add(frameLabel);        //Adding label control to placeholder wallWindowOptions
                wallWindowOptions.Controls.Add(new LiteralControl("</li>"));

                #endregion
            }

            if (ivory)
            {
                #region Ivory

                //li tag to hold window type radio button and all its content
                wallWindowOptions.Controls.Add(new LiteralControl("<li>"));

                //Vinyl tint radio button
                frameRadio = new RadioButton();
                frameRadio.ID = "radFrameIvory"; //Adding appropriate id to window type radio button
                frameRadio.GroupName = "FrameColourRadios";         //Adding group name for all tint colours
                //typeRadio.Attributes.Add("onclick", "typeRowsDisplayed()"); //On click event to display the proper fields/rows

                //Vinyl tint radio button label for clickable area
                frameLabelRadio = new Label();
                frameLabelRadio.AssociatedControlID = "radFrameIvory";  //Tying this label to the radio button

                //Vinyl tint radio button label text
                frameLabel = new Label();
                frameLabel.AssociatedControlID = "radFrameIvory";    //Tying this label to the radio button
                frameLabel.Text = "Ivory";

                wallWindowOptions.Controls.Add(frameRadio);        //Adding radio button control to placeholder wallWindowOptions
                wallWindowOptions.Controls.Add(frameLabelRadio);   //Adding label control to placeholder wallWindowOptions
                wallWindowOptions.Controls.Add(frameLabel);        //Adding label control to placeholder wallWindowOptions
                wallWindowOptions.Controls.Add(new LiteralControl("</li>"));

                #endregion
            }
            if (cherrywood)
            {
                #region Cherrywood

                //li tag to hold window type radio button and all its content
                wallWindowOptions.Controls.Add(new LiteralControl("<li>"));

                //Vinyl tint radio button
                frameRadio = new RadioButton();
                frameRadio.ID = "radFrameCherrywood"; //Adding appropriate id to window type radio button
                frameRadio.GroupName = "FrameColourRadios";         //Adding group name for all tint colours
                //typeRadio.Attributes.Add("onclick", "typeRowsDisplayed()"); //On click event to display the proper fields/rows

                //Vinyl tint radio button label for clickable area
                frameLabelRadio = new Label();
                frameLabelRadio.AssociatedControlID = "radFrameCherrywood";  //Tying this label to the radio button

                //Vinyl tint radio button label text
                frameLabel = new Label();
                frameLabel.AssociatedControlID = "radFrameCherrywood";    //Tying this label to the radio button
                frameLabel.Text = "Cherrywood";

                wallWindowOptions.Controls.Add(frameRadio);        //Adding radio button control to placeholder wallWindowOptions
                wallWindowOptions.Controls.Add(frameLabelRadio);   //Adding label control to placeholder wallWindowOptions
                wallWindowOptions.Controls.Add(frameLabel);        //Adding label control to placeholder wallWindowOptions
                wallWindowOptions.Controls.Add(new LiteralControl("</li>"));

                #endregion
            }
            if (black)
            {
                #region Black

                //li tag to hold window type radio button and all its content
                wallWindowOptions.Controls.Add(new LiteralControl("<li>"));

                //Vinyl tint radio button
                frameRadio = new RadioButton();
                frameRadio.ID = "radFrameBlack"; //Adding appropriate id to window type radio button
                frameRadio.GroupName = "FrameColourRadios";         //Adding group name for all tint colours
                //typeRadio.Attributes.Add("onclick", "typeRowsDisplayed()"); //On click event to display the proper fields/rows

                //Vinyl tint radio button label for clickable area
                frameLabelRadio = new Label();
                frameLabelRadio.AssociatedControlID = "radFrameBlack";  //Tying this label to the radio button

                //Vinyl tint radio button label text
                frameLabel = new Label();
                frameLabel.AssociatedControlID = "radFrameBlack";    //Tying this label to the radio button
                frameLabel.Text = "Black";

                wallWindowOptions.Controls.Add(frameRadio);        //Adding radio button control to placeholder wallWindowOptions
                wallWindowOptions.Controls.Add(frameLabelRadio);   //Adding label control to placeholder wallWindowOptions
                wallWindowOptions.Controls.Add(frameLabel);        //Adding label control to placeholder wallWindowOptions
                wallWindowOptions.Controls.Add(new LiteralControl("</li>"));

                #endregion
            }

            #endregion

        }

        /// <summary>
        /// This method creates radio buttons for tint options for all different types of windows 
        /// </summary>
        /// <param name="windowTypeId">id of radio button, must be unique</param>
        /// <param name="windowTypeText">text of the label for the radio button</param>
        /// <param name="grey">true or false, if grey is an option</param>
        /// <param name="smokeGrey">true or false, if smokeGrey is an option</param>
        /// <param name="darkGrey">true or false, if darkGrey is an option</param>
        /// <param name="bronze">true or false, if bronze is an option</param>
        /// <param name="mixed">true or false, if mixed is an option, false by default</param>
        /// <param name="clear">true or false, if clear is an option, true by default</param>
        protected void tintOptions(string windowTypeId, string windowTypeText, bool grey, bool smokeGrey, bool darkGrey, bool bronze, bool mixed = false, bool clear = true)
        {

            RadioButton typeRadio, tintRadio;
            Label typeLabelRadio, typeLabel, tintLabelRadio, tintLabel;

            wallWindowOptions.Controls.Add(new LiteralControl("<li>"));

            //RadioButton created for every option
            typeRadio = new RadioButton();
            typeRadio.ID = "rad" + windowTypeId;     //Giving an appropriate id to radio buttons based on current type of window
            typeRadio.GroupName = "windowTypeRadios";     //Giving an appropriate group name to all windowtype radio buttons


            typeRadio.Checked = (windowTypeId == "V4T" && currentModel == "M200") ? true : //select/check the radio button if current selection is default value
                (windowTypeId == "SinglePaneHorizontalRollers" && currentModel == "M300") ? true : //select/check the radio button if current selection is default value
                (windowTypeId == "DoublePaneSingleSlider" && currentModel == "M400") ? true : false; //select/check the radio button if current selection is default value
            
            //screenRadio.Attributes.Add("onchange", "onWallRadioChange(\"" + i + "\")");

            //Label to create clickable area for radio button
            typeLabelRadio = new Label();
            typeLabelRadio.AssociatedControlID = "rad" + windowTypeId;   //Tying this label to the radio button

            typeLabel = new Label();
            typeLabel.AssociatedControlID = "rad" + windowTypeId;        //Tying this label to the radio button
            typeLabel.Text = windowTypeText;       //Adding text to the radio button

            wallWindowOptions.Controls.Add(typeRadio);        //Adding radio button control to placeholder wallWindowOptions
            wallWindowOptions.Controls.Add(typeLabelRadio);   //Adding label control to placeholder wallWindowOptions
            wallWindowOptions.Controls.Add(typeLabel);        //Adding label control to placeholder wallWindowOptions

            #region tint options collapsable div

            if (!grey && !darkGrey && !smokeGrey && !bronze && !clear && !mixed)
            {//if there are no tint options
                //do nothing
            }
            else
            {//make a collapsable div to tint options
                //Creating div tag to hold all the current window type information 
                wallWindowOptions.Controls.Add(new LiteralControl("<div id='" + windowTypeId + "WindowDetails' class='toggleContent'>"));

                //Creating one ul tag to hold multiple li tags containing vinyl tints
                wallWindowOptions.Controls.Add(new LiteralControl("<ul><li><ul id='" + windowTypeId + "DetailsList' class='toggleOptions'>"));
            }


            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            #region tint options

            if (clear)
            {
                #region Clear

                //li tag to hold window type radio button and all its content
                wallWindowOptions.Controls.Add(new LiteralControl("<li>"));

                //Vinyl tint radio button
                tintRadio = new RadioButton();
                tintRadio.ID = "rad" + windowTypeId + "Clear"; //Adding appropriate id to window type radio button
                tintRadio.GroupName = "Tint" + windowTypeId + "Radios";         //Adding group name for all tint colours
                tintRadio.Checked = (currentModel == "M200") ? true : false; //select/check the radio button if current select is defualt value
                //typeRadio.Attributes.Add("onclick", "typeRowsDisplayed()"); //On click event to display the proper fields/rows

                //Vinyl tint radio button label for clickable area
                tintLabelRadio = new Label();
                tintLabelRadio.AssociatedControlID = "rad" + windowTypeId + "Clear";  //Tying this label to the radio button

                //Vinyl tint radio button label text
                tintLabel = new Label();
                tintLabel.AssociatedControlID = "rad" + windowTypeId + "Clear";    //Tying this label to the radio button
                tintLabel.Text = "Clear";

                wallWindowOptions.Controls.Add(tintRadio);        //Adding radio button control to placeholder wallWindowOptions
                wallWindowOptions.Controls.Add(tintLabelRadio);   //Adding label control to placeholder wallWindowOptions
                wallWindowOptions.Controls.Add(tintLabel);        //Adding label control to placeholder wallWindowOptions
                wallWindowOptions.Controls.Add(new LiteralControl("</li>"));

                #endregion
            }
            
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            
            if (smokeGrey)
            {
                #region Smoke Grey

                //li tag to hold window type radio button and all its content
                wallWindowOptions.Controls.Add(new LiteralControl("<li>"));

                //Vinyl tint radio button
                tintRadio = new RadioButton();
                tintRadio.ID = "rad" + windowTypeId + "SmokeGrey"; //Adding appropriate id to window type radio button
                tintRadio.GroupName = "Tint" + windowTypeId + "Radios";         //Adding group name for all tint colours
                //typeRadio.Attributes.Add("onclick", "typeRowsDisplayed()"); //On click event to display the proper fields/rows

                //Vinyl tint radio button label for clickable area
                tintLabelRadio = new Label();
                tintLabelRadio.AssociatedControlID = "rad" + windowTypeId + "SmokeGrey";  //Tying this label to the radio button

                //Vinyl tint radio button label text
                tintLabel = new Label();
                tintLabel.AssociatedControlID = "rad" + windowTypeId + "SmokeGrey";    //Tying this label to the radio button
                tintLabel.Text = "Smoke Grey";

                wallWindowOptions.Controls.Add(tintRadio);        //Adding radio button control to placeholder wallWindowOptions
                wallWindowOptions.Controls.Add(tintLabelRadio);   //Adding label control to placeholder wallWindowOptions
                wallWindowOptions.Controls.Add(tintLabel);        //Adding label control to placeholder wallWindowOptions
                wallWindowOptions.Controls.Add(new LiteralControl("</li>"));

                #endregion
            }
            
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            
            if (darkGrey)
            {
                #region Dark Grey

                //li tag to hold window type radio button and all its content
                wallWindowOptions.Controls.Add(new LiteralControl("<li>"));

                //Vinyl tint radio button
                tintRadio = new RadioButton();
                tintRadio.ID = "rad" + windowTypeId + "DarkGrey"; //Adding appropriate id to window type radio button
                tintRadio.GroupName = "Tint" + windowTypeId + "Radios";         //Adding group name for all tint colours
                //typeRadio.Attributes.Add("onclick", "typeRowsDisplayed()"); //On click event to display the proper fields/rows

                //Vinyl tint radio button label for clickable area
                tintLabelRadio = new Label();
                tintLabelRadio.AssociatedControlID = "rad" + windowTypeId + "DarkGrey";  //Tying this label to the radio button

                //Vinyl tint radio button label text
                tintLabel = new Label();
                tintLabel.AssociatedControlID = "rad" + windowTypeId + "DarkGrey";    //Tying this label to the radio button
                tintLabel.Text = "Dark Grey";

                wallWindowOptions.Controls.Add(tintRadio);        //Adding radio button control to placeholder wallWindowOptions
                wallWindowOptions.Controls.Add(tintLabelRadio);   //Adding label control to placeholder wallWindowOptions
                wallWindowOptions.Controls.Add(tintLabel);        //Adding label control to placeholder wallWindowOptions
                wallWindowOptions.Controls.Add(new LiteralControl("</li>"));

                #endregion
            }
            
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            if (grey)
            {
                #region Grey

                //li tag to hold window type radio button and all its content
                wallWindowOptions.Controls.Add(new LiteralControl("<li>"));

                //Vinyl tint radio button
                tintRadio = new RadioButton();
                tintRadio.ID = "rad" + windowTypeId + "Grey"; //Adding appropriate id to window type radio button
                tintRadio.GroupName = "Tint" + windowTypeId + "Radios";         //Adding group name for all tint colours
                //typeRadio.Attributes.Add("onclick", "typeRowsDisplayed()"); //On click event to display the proper fields/rows

                //Vinyl tint radio button label for clickable area
                tintLabelRadio = new Label();
                tintLabelRadio.AssociatedControlID = "rad" + windowTypeId + "Grey";  //Tying this label to the radio button

                //Vinyl tint radio button label text
                tintLabel = new Label();
                tintLabel.AssociatedControlID = "rad" + windowTypeId + "Grey";    //Tying this label to the radio button
                tintLabel.Text = "Grey";

                wallWindowOptions.Controls.Add(tintRadio);        //Adding radio button control to placeholder wallWindowOptions
                wallWindowOptions.Controls.Add(tintLabelRadio);   //Adding label control to placeholder wallWindowOptions
                wallWindowOptions.Controls.Add(tintLabel);        //Adding label control to placeholder wallWindowOptions
                wallWindowOptions.Controls.Add(new LiteralControl("</li>"));

                #endregion
            }

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            if (bronze)
            {
                #region Bronze

                //li tag to hold window type radio button and all its content
                wallWindowOptions.Controls.Add(new LiteralControl("<li>"));

                //Vinyl tint radio button
                tintRadio = new RadioButton();
                tintRadio.ID = "rad" + windowTypeId + "Bronze"; //Adding appropriate id to window type radio button
                tintRadio.GroupName = "Tint" + windowTypeId + "Radios";         //Adding group name for all tint colours
                //typeRadio.Attributes.Add("onclick", "typeRowsDisplayed()"); //On click event to display the proper fields/rows

                //Vinyl tint radio button label for clickable area
                tintLabelRadio = new Label();
                tintLabelRadio.AssociatedControlID = "rad" + windowTypeId + "Bronze";  //Tying this label to the radio button

                //Vinyl tint radio button label text
                tintLabel = new Label();
                tintLabel.AssociatedControlID = "rad" + windowTypeId + "Bronze";    //Tying this label to the radio button
                tintLabel.Text = "Bronze";

                wallWindowOptions.Controls.Add(tintRadio);        //Adding radio button control to placeholder wallWindowOptions
                wallWindowOptions.Controls.Add(tintLabelRadio);   //Adding label control to placeholder wallWindowOptions
                wallWindowOptions.Controls.Add(tintLabel);        //Adding label control to placeholder wallWindowOptions
                wallWindowOptions.Controls.Add(new LiteralControl("</li>"));

                #endregion
            }

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            if (mixed)
            {
                #region Mixed

                //li tag to hold window type radio button and all its content
                wallWindowOptions.Controls.Add(new LiteralControl("<li>"));

                //Vinyl tint radio button
                tintRadio = new RadioButton();
                tintRadio.ID = "rad" + windowTypeId + "Mixed"; //Adding appropriate id to window type radio button
                tintRadio.GroupName = "Tint" + windowTypeId + "Radios";         //Adding group name for all tint colours
                //typeRadio.Attributes.Add("onclick", "typeRowsDisplayed()"); //On click event to display the proper fields/rows

                //Vinyl tint radio button label for clickable area
                tintLabelRadio = new Label();
                tintLabelRadio.AssociatedControlID = "rad" + windowTypeId + "Mixed";  //Tying this label to the radio button

                //Vinyl tint radio button label text
                tintLabel = new Label();
                tintLabel.AssociatedControlID = "rad" + windowTypeId + "Mixed";    //Tying this label to the radio button
                tintLabel.Text = "Mixed";

                wallWindowOptions.Controls.Add(tintRadio);        //Adding radio button control to placeholder wallWindowOptions
                wallWindowOptions.Controls.Add(tintLabelRadio);   //Adding label control to placeholder wallWindowOptions
                wallWindowOptions.Controls.Add(tintLabel);        //Adding label control to placeholder wallWindowOptions


                /****************************************************************************************/
                /**************************         MIXED OPTIONS          ******************************/
                /****************************************************************************************/


                //Creating div tag to hold all the V4T MIXED TINT information 
                wallWindowOptions.Controls.Add(new LiteralControl("<div id='" + windowTypeId + "mixedTintDetails' class='toggleContent'>"));

                //Creating one ul tag to hold multiple li tags containing vinyl tints
                wallWindowOptions.Controls.Add(new LiteralControl("<ul><li><ul id='" + windowTypeId + "mixedTintList' class='toggleOptions'>"));


                Table tblMixedTints = new Table(); //table to hold vinyl number labels and dropdown options

                tblMixedTints.ID = "tbl" + windowTypeId + "MixedTint"; //Adding appropriate id to the table
                tblMixedTints.CssClass = "tblTextFields";   //Adding CssClass to the table for styling

                for (int vinylCount = 1; vinylCount <= 4; vinylCount++) //4 = 4 vinyl pieces in V4T windows
                {
                    TableRow mixedVinylTintRow = new TableRow();
                    mixedVinylTintRow.ID = "row" + windowTypeId + "Vinyl" + vinylCount + "Tint";
                    //mixedVinylTintRow.Attributes.Add("style", "display:none;");
                    TableCell mixedVinylTintLabelCell = new TableCell();
                    TableCell mixedVinylTintDropDownCell = new TableCell();

                    Label mixedVinylTintLabel = new Label();
                    mixedVinylTintLabel.ID = "lbl" + windowTypeId + "Vinyl" + vinylCount + "Tint";
                    mixedVinylTintLabel.Text = "Vinyl " + vinylCount + " Tint : ";
                    DropDownList ddlVinylTintOptions = new DropDownList();
                    ddlVinylTintOptions.ID = "ddl" + windowTypeId + "VinylTint" + vinylCount;
                    ListItem clearVinyl = new ListItem("Clear", "clear");
                    ListItem smokeGreyVinyl = new ListItem("Smoke Grey", "smokeGrey");
                    ListItem darkGreyVinyl = new ListItem("Dark Grey", "darkGrey");
                    ListItem bronzeVinyl = new ListItem("Bronze", "bronze");

                    ddlVinylTintOptions.Items.Add(clearVinyl);
                    ddlVinylTintOptions.Items.Add(smokeGreyVinyl);
                    ddlVinylTintOptions.Items.Add(darkGreyVinyl);
                    ddlVinylTintOptions.Items.Add(bronzeVinyl);

                    mixedVinylTintLabel.AssociatedControlID = "ddl" + windowTypeId + "VinylTint" + vinylCount;

                    mixedVinylTintLabelCell.Controls.Add(mixedVinylTintLabel);
                    mixedVinylTintDropDownCell.Controls.Add(ddlVinylTintOptions);

                    tblMixedTints.Rows.Add(mixedVinylTintRow);

                    mixedVinylTintRow.Cells.Add(mixedVinylTintLabelCell);
                    mixedVinylTintRow.Cells.Add(mixedVinylTintDropDownCell);
                }

                wallWindowOptions.Controls.Add(tblMixedTints);

                wallWindowOptions.Controls.Add(new LiteralControl("</ul></li></ul></div>"));

                /****************************************************************************************/
                /*************************       END OF MIXED OPTIONS      ******************************/
                /****************************************************************************************/

                wallWindowOptions.Controls.Add(new LiteralControl("</li>"));

                #endregion
            }

            /////////////////////////////////////////////////////////////////////////////////////////////

            #endregion

            if (!grey && !darkGrey && !smokeGrey && !bronze && !clear && !mixed)
            {//if there are no tint options
                //do nothing
            }
            else
            {//there are tint options
                wallWindowOptions.Controls.Add(new LiteralControl("</ul></li></ul></div></li>")); //close the previously opened tags
            }

            #endregion
        }

        /// <summary>
        /// This method is used to call model specific method for window layouts
        /// </summary>
        protected void windowOptions()
        {
            wallWindowOptions.Controls.Add(new LiteralControl("<br/><h2>Window Type: </h2>"));

            switch (currentModel)
            {
                case "M100":
                    model100WindowOptions();
                    break;
                case "M200":
                    model200WindowOptions();
                    break;
                case "M300":
                    model300WindowOptions();
                    break;
                case "M400":
                    model400WindowOptions();
                    break;
            }
        }

        /// <summary>
        /// - screen (Default)
		///     - screen type (better vue insect screen, No See Ums 20x20 Mesh, Solar Insect Screening, Tuff Screen, No Screen)
        /// </summary>
        protected void model100WindowOptions()
        {
            screenWindowOptions();
        }
        
        /// <summary>
        ///	- V4T (Default)
		///    - V4T tints (clear, smoke grey, dark grey, bronze, Mixed)
		/// - Horizontal 2 Track[XX]
		///    - H2T (vinyl) tints (clear, smoke grey, dark grey, bronze)
		/// - fixed vinyl windows
		///	    - fixed window tints (clear, smoke grey, dark grey, bronze)
		/// - open wall
		/// - solid wall
		/// - screen type (better vue insect screen, No See Ums 20x20 Mesh, Solar Insect Screening, Tuff Screen, No Screen)
        /// •	Model 200 has the standard frame colors (white, bronze, driftwood) and also Custom Colors: Green, Black,  Ivory, Cherrywood and Grey
        /// </summary>
        protected void model200WindowOptions()
        {
            v4tWindowOptions();
            h2tWindowOptions();
            fixedVinylWindowOptions();
            openWall();
            solidWall();
            screenWindowOptions();

            windowFramingColourOptions(true, true, true, true, true, true, true, true);
        }

        /// <summary>
        /// - Single Pane Horizontal Rollers [XX] (Default)
		///	    - glass tint (grey, bronze, clear)
		/// - fixed windows
		///	    - fixed window tints (grey, bronze, clear)
		/// - open wall
		/// - solid wall
		/// - screen type (better vue insect screen, No See Ums 20x20 Mesh, Solar Insect Screening, Tuff Screen, No Screen) 
        /// •	Model 300 frame colours are White, Driftwood and Bronze.
        /// </summary>
        protected void model300WindowOptions()
        {            
            singlePaneHorizontalRollersWindowOptions();
            fixedGlassWindowOptions();
            openWall();
            solidWall();
            screenWindowOptions();

            windowFramingColourOptions(true);
        }

        /// <summary>
        /// - Double Pane Single Sliders[XO, OX] (Default): is there a default on XO or OX?
		///    - glass tint (grey, bronze, clear)
		/// - fixed windows
		///	   - fixed window tints (grey, bronze, clear)
		/// - open wall
		/// - solid wall
        /// •	Model 400 Windows frames come in White and Driftwood.
        /// </summary>
        protected void model400WindowOptions()
        {
            doublePaneSingleSliderWindowOptions();
            fixedGlassWindowOptions();
            openWall();
            solidWall();

            windowFramingColourOptions(false);
        }

        /// <summary>
        /// screen type (better vue insect screen, No See Ums 20x20 Mesh, Solar Insect Screening, Tuff Screen, No Screen)
        /// </summary>
        protected void screenWindowOptions()
        {
            RadioButton screenRadio, typeRadio;
            Label screenLabelRadio, screenLabel, typeLabelRadio, typeLabel;
            
            wallWindowOptions.Controls.Add(new LiteralControl("<li>"));

            //RadioButton created for every option
            screenRadio = new RadioButton();
            screenRadio.ID = "radScreen";     //Giving an appropriate id to radio buttons based on current type of window
            screenRadio.GroupName = "windowTypeRadios";     //Giving an appropriate group name to all windowtype radio buttons
            screenRadio.Checked = (currentModel == "M100") ? true : false; //select/check the radio button if current selection is default value
            //screenRadio.Attributes.Add("onchange", "onWallRadioChange(\"" + i + "\")");

            //Label to create clickable area for radio button
            screenLabelRadio = new Label();
            screenLabelRadio.AssociatedControlID = "radScreen";   //Tying this label to the radio button

            screenLabel = new Label();
            screenLabel.AssociatedControlID = "radScreen";        //Tying this label to the radio button
            screenLabel.Text = "Screen";       //Adding text to the radio button

            wallWindowOptions.Controls.Add(screenRadio);        //Adding radio button control to placeholder wallWindowOptions
            wallWindowOptions.Controls.Add(screenLabelRadio);   //Adding label control to placeholder wallWindowOptions
            wallWindowOptions.Controls.Add(screenLabel);        //Adding label control to placeholder wallWindowOptions

            //Creating div tag to hold all the current window type information 
            wallWindowOptions.Controls.Add(new LiteralControl("<div id=\"screenWindowDetails\" class=\"toggleContent\">"));

            //Creating one ul tag to hold multiple li tags containing screen window types
            wallWindowOptions.Controls.Add(new LiteralControl("<ul><li><ul id='screenDetailsList' class='toggleOptions'>"));

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            #region Better Vue Insect Screen

            //li tag to hold window type radio button and all its content
            wallWindowOptions.Controls.Add(new LiteralControl("<li>"));

            //Window type radio button
            typeRadio = new RadioButton();
            typeRadio.ID = "radBetterVueInsectScreen"; //Adding appropriate id to window type radio button
            typeRadio.GroupName = "ScreenRadios";         //Adding group name for all window types
            typeRadio.Checked = (currentModel == "M100") ? true : false; //select/check the radio button if current select is defualt value
            //typeRadio.Attributes.Add("onclick", "typeRowsDisplayed()"); //On click event to display the proper fields/rows

            //Window type radio button label for clickable area
            typeLabelRadio = new Label();
            typeLabelRadio.AssociatedControlID = "radBetterVueInsectScreen";  //Tying this label to the radio button

            //Window type radio button label text
            typeLabel = new Label();
            typeLabel.AssociatedControlID = "radBetterVueInsectScreen";    //Tying this label to the radio button
            typeLabel.Text = "Better Vue Insect Screen";

            wallWindowOptions.Controls.Add(typeRadio);        //Adding radio button control to placeholder wallWindowOptions
            wallWindowOptions.Controls.Add(typeLabelRadio);   //Adding label control to placeholder wallWindowOptions
            wallWindowOptions.Controls.Add(typeLabel);        //Adding label control to placeholder wallWindowOptions
            wallWindowOptions.Controls.Add(new LiteralControl("</li>"));

            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            #region No See Ums 20x20 Mesh

            //li tag to hold window type radio button and all its content
            wallWindowOptions.Controls.Add(new LiteralControl("<li>"));

            //window type radio button
            typeRadio = new RadioButton();
            typeRadio.ID = "radNoSeeUms20x20Mesh"; //Adding appropriate id to window type radio button
            typeRadio.GroupName = "ScreenRadios";         //Adding group name for all window types
            //typeRadio.Attributes.Add("onclick", "typeRowsDisplayed()"); //On click event to display the proper fields/rows

            //window type radio button label for clickable area
            typeLabelRadio = new Label();
            typeLabelRadio.AssociatedControlID = "radNoSeeUms20x20Mesh";  //Tying this label to the radio button

            //window type radio button label text
            typeLabel = new Label();
            typeLabel.AssociatedControlID = "radNoSeeUms20x20Mesh";    //Tying this label to the radio button
            typeLabel.Text = "No See Ums 20x20 Mesh";


            wallWindowOptions.Controls.Add(typeRadio);        //Adding radio button control to placeholder wallWindowOptions
            wallWindowOptions.Controls.Add(typeLabelRadio);   //Adding label control to placeholder wallWindowOptions
            wallWindowOptions.Controls.Add(typeLabel);        //Adding label control to placeholder wallWindowOptions
            wallWindowOptions.Controls.Add(new LiteralControl("</li>"));

            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            #region Solar Insect Screening

            //li tag to hold Window type radio button and all its content
            wallWindowOptions.Controls.Add(new LiteralControl("<li>"));

            //Window type radio button
            typeRadio = new RadioButton();
            typeRadio.ID = "radSolarInsectScreening"; //Adding appropriate id to Window type radio button
            typeRadio.GroupName = "ScreenRadios";         //Adding group name for all Window types
            //typeRadio.Attributes.Add("onclick", "typeRowsDisplayed()"); //On click event to display the proper fields/rows

            //Window type radio button label for clickable area
            typeLabelRadio = new Label();
            typeLabelRadio.AssociatedControlID = "radSolarInsectScreening";  //Tying this label to the radio button

            //Window type radio button label text
            typeLabel = new Label();
            typeLabel.AssociatedControlID = "radSolarInsectScreening";    //Tying this label to the radio button
            typeLabel.Text = "Solar Insect Screening";


            wallWindowOptions.Controls.Add(typeRadio);        //Adding radio button control to placeholder wallWindowOptions
            wallWindowOptions.Controls.Add(typeLabelRadio);   //Adding label control to placeholder wallWindowOptions
            wallWindowOptions.Controls.Add(typeLabel);        //Adding label control to placeholder wallWindowOptions
            wallWindowOptions.Controls.Add(new LiteralControl("</li>"));

            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            #region Tough Screen

            //li tag to hold Window type radio button and all its content
            wallWindowOptions.Controls.Add(new LiteralControl("<li>"));

            //Window type radio button
            typeRadio = new RadioButton();
            typeRadio.ID = "radToughScreen"; //Adding appropriate id to Window type radio button
            typeRadio.GroupName = "ScreenRadios";         //Adding group name for all Window types
            //typeRadio.Attributes.Add("onclick", "typeRowsDisplayed()"); //On click event to display the proper fields/rows

            //Window type radio button label for clickable area
            typeLabelRadio = new Label();
            typeLabelRadio.AssociatedControlID = "radToughScreen";  //Tying this label to the radio button

            //Window type radio button label text
            typeLabel = new Label();
            typeLabel.AssociatedControlID = "radToughScreen";    //Tying this label to the radio button
            typeLabel.Text = "Tough Screen";


            wallWindowOptions.Controls.Add(typeRadio);        //Adding radio button control to placeholder wallWindowOptions
            wallWindowOptions.Controls.Add(typeLabelRadio);   //Adding label control to placeholder wallWindowOptions
            wallWindowOptions.Controls.Add(typeLabel);        //Adding label control to placeholder wallWindowOptions
            wallWindowOptions.Controls.Add(new LiteralControl("</li>"));

            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            #region No Screen

            //li tag to hold Window type radio button and all its content
            wallWindowOptions.Controls.Add(new LiteralControl("<li>"));

            //Window type radio button
            typeRadio = new RadioButton();
            typeRadio.ID = "radNoScreen"; //Adding appropriate id to Window type radio button
            typeRadio.GroupName = "ScreenRadios";         //Adding group name for all Window types
            //typeRadio.Attributes.Add("onclick", "typeRowsDisplayed()"); //On click event to display the proper fields/rows

            //Window type radio button label for clickable area
            typeLabelRadio = new Label();
            typeLabelRadio.AssociatedControlID = "radNoScreen";  //Tying this label to the radio button

            //Window type radio button label text
            typeLabel = new Label();
            typeLabel.AssociatedControlID = "radNoScreen";    //Tying this label to the radio button
            typeLabel.Text = "No Screen";


            wallWindowOptions.Controls.Add(typeRadio);        //Adding radio button control to placeholder wallWindowOptions
            wallWindowOptions.Controls.Add(typeLabelRadio);   //Adding label control to placeholder wallWindowOptions
            wallWindowOptions.Controls.Add(typeLabel);        //Adding label control to placeholder wallWindowOptions
            wallWindowOptions.Controls.Add(new LiteralControl("</li>"));

            #endregion

            ////////////////////////////////////////////////

            wallWindowOptions.Controls.Add(new LiteralControl("</ul></li></ul></div></li>"));

        }

        /// <summary>
        /// - V4T tints (clear, smoke grey, dark grey, bronze, Mixed)
        /// </summary>
        protected void v4tWindowOptions()
        {
            tintOptions("V4T", "Vertical 4 Track", false, true, true, true, true);
        }

        /// <summary>
        /// H2T (vinyl) tints (clear, smoke grey, dark grey, bronze)
        /// </summary>
        protected void h2tWindowOptions()
        {
            tintOptions("H2T", "Horizontal 2 Track [XX]", false, true, true, true);
        }

        /// <summary>
        /// fixed window tints (clear, smoke grey, dark grey, bronze)
        /// </summary>
        protected void fixedVinylWindowOptions()
        {
            tintOptions("FixedVinyl", "Fixed Vinyl Windows", false, true, true, true);
        }

        /// <summary>
        /// glass tint (grey, bronze, clear)
        /// </summary>
        protected void singlePaneHorizontalRollersWindowOptions()
        {
            tintOptions("SinglePaneHorizontalRollers", "Single Pane Horizontal Rollers [XX]", true, false, false, true);
        }

        /// <summary>
        /// fixed glass window tints (grey, bronze, clear)
        /// </summary>
        protected void fixedGlassWindowOptions()
        {
            tintOptions("Fixed", "Fixed Window", true, false, false, true);
        }

        /// <summary>
        /// glass tint (grey, bronze, clear)
        /// </summary>
        protected void doublePaneSingleSliderWindowOptions()
        {
            tintOptions("DoublePaneSingleSlider", "Double Pane Single Slider [XO, OX]", true, false, false, true);
        }

        /// <summary>
        /// open wall in place of a window
        /// </summary>
        protected void openWall()
        {
            tintOptions("OpenWall", "Open Wall", false, false, false, false, false, false);
        }

        /// <summary>
        /// solid wall in place of a window
        /// </summary>
        protected void solidWall()
        {
            tintOptions("SolidWall", "Solid Wall", false, false, false, false, false, false);
        }

        #endregion

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



                html += "<div id=\"hidWall" + i + "Length\" style=\"display: none;\" runat=\"server\" />"; //hidden field for wall length
                html += "<div id=\"hidWall" + i + "LeftFiller\" style=\"display: none;\" runat=\"server\" />"; //hidden field for wall left filler
                html += "<div id=\"hidWall" + i + "RightFiller\" style=\"display: none;\" runat=\"server\" />"; //hidden field for wall right filler
                html += "<div id=\"hidWall" + i + "SetBack\" style=\"display: none;\" runat=\"server\" />"; //hidden field for wall setback
                html += "<div id=\"hidWall" + i + "SoffitLength\" style=\"display: none;\" runat=\"server\" />"; //hidden field for wall soffit length
                html += "<div id=\"hidWall" + i + "StartHeight\" style=\"display: none;\" runat=\"server\" />"; //hidden field for wall start height
                html += "<div id=\"hidWall" + i + "EndHeight\" style=\"display: none;\" runat=\"server\" />"; //hidden field for wall end height
                //html += "<input id=\"hidWall" + i + "Slope\" type=\"hidden\" runat=\"server\" />"; //hidden field for wall slope
                
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

            float length, startHeight, endHeight, soffit;//, slope;
            string orientation, name, type, model;
            HiddenField wallLength, wallSoffit;
            for (int i = 0; i < strWalls.Count(); i++)
            {
                //find and store the dynamically created hidden fields
                wallLength = hiddenFieldsDiv.FindControl("hidWall" + i + "Length") as HiddenField; //wall length
                wallSoffit = hiddenFieldsDiv.FindControl("hidWall" + i + "SoffitLength") as HiddenField; //wall soffit length

                

                //length = wallLength.Value;
                //startHeight = Convert.ToSingle(hidHeight.Value);
                //endHeight = Convert.ToSingle(hidFrontWallHeight.Value);
                //soffit = Convert.ToSingle(wallSoffit.Value);
               // slope = Convert.ToSingle(hidRoofSlope.Value);

                orientation = wallDetails[i, 5];
                name = "wall " + i;
                type = wallDetails[i, 4];
                model = currentModel;

                //string sof = wallSoffit.Value;
                //create a wall object with the appropriate values in the fields and attributes of it and add it to the walls list
                walls.Add(new Wall(Convert.ToSingle(wallLength.Value), wallDetails[i, 5], "Wall" + i, wallDetails[i, 4], Convert.ToSingle(hidBackWallHeight.Value), Convert.ToSingle(hidBackWallHeight.Value), /*Convert.ToSingle(wallSoffit.Value)*/ 0F, currentModel));
            }
        }

        protected void btnQuestion4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("This is working");
            System.Diagnostics.Debug.WriteLine(Request.Form["wallCount"]);
            System.Diagnostics.Debug.WriteLine(Request.Form["wall4DoorCount"]);
            System.Diagnostics.Debug.WriteLine(Request.Form["wall4Door0PropertyCount"]);
            System.Diagnostics.Debug.WriteLine(Request.Form["wall4Door0type"]);

            int wallCount = Convert.ToInt32(Request.Form["wallCount"]);

            for (int walls = 0; walls < wallCount; walls++) { 
                

                int doorCount = Convert.ToInt32(Request.Form["wall" + walls + "DoorCount"]);

                for (int doors = 0; doors < doorCount; doors++) {
                                        
                    int propertyCount = Convert.ToInt32(Request.Form["wall" + walls + "Door" + doors + "PropertyCount"]);
                    string doorType = Convert.ToString(Request.Form["wall" + walls + "Door" + doors + "type"]);
                    
                    //if (doorType == "Cabana")
                    //{
                    //    CabanaDoor thisDoor = new CabanaDoor();
                    //    //Load all properties
                        
                    //}
                    //else if (doorType == "French")
                    //{
                    //    FrenchDoor thisDoor = new FrenchDoor();
                    //    //Load all properties
                    //}
                    //else if (doorType == "Patio")
                    //{
                    //    PatioDoor thisDoor = new PatioDoor();
                    //    //Load all properties
                    //}
                    //else
                    //{
                    //    OpenSpaceDoor thisDoor = new OpenSpaceDoor();
                    //    //Load all properties
                    //}

                    //for (int properties = 0; properties < propertyCount; properties++) { 
                    

                    //}

                }

            }

        }
    }
}
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
        public const float FOAM_PANEL_PROJECTION = 264f;
        public const float ACRYLIC_PANEL_PROJECTION = 276f;
        public const float THERMADECK_PANEL_PROJECTION = 288f;

        protected List<Wall> walls = new List<Wall>();
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
        protected float soffitLength;

        /***hard coded variables***/
        protected string coordList; //to store the string from the session and store it in a local variable for further use                                    
        protected char[] lineDelimiter = { '/' }; //character(s) that seperate lines in a session string variable
        protected char[] detailsDelimiter = { ',' }; //character(s) that seperate details of each line                                 
        protected string[] strWalls; //to split the string received from session and store it into an array of strings with individual line details
        protected string[,] wallDetails; //a two dimensional array to store the the details of each line individually as seperate elements ... 6 represents the number of detail items for each line

        DropDownList ddlInFrac = new DropDownList(); //a dropdown list for length inch fractions

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.DefaultButton = "";

            if (Session["loggedIn"] == null)
            {
                //uncomment me when login functionality is working
                Response.Redirect("Login.aspx");
                //Session.Add("loggedIn", "userA");
            }

            /****VALIDATION CONSTANTS***/

            #region DOOR VALIDATION CONSTANTS
            Session["CABANA_MAX_WIDTH"] = Constants.CUSTOM_DOOR_MAX_WIDTH;
            Session["CABANA_MIN_WIDTH"] = Constants.CUSTOM_DOOR_MIN_WIDTH;
            Session["CABANA_MAX_HEIGHT"] = Constants.CUSTOM_DOOR_MAX_HEIGHT;
            Session["CABANA_MIN_HEIGHT"] = Constants.CUSTOM_DOOR_MIN_HEIGHT;
            Session["PATIO_DOOR_MAX_WIDTH"] = Constants.PATIO_DOOR_MAX_WIDTH;
            Session["PATIO_DOOR_MIN_WIDTH"] = Constants.PATIO_DOOR_MIN_WIDTH;
            Session["PATIO_DOOR_MAX_HEIGHT"] = Constants.PATIO_DOOR_MAX_HEIGHT;
            Session["PATIO_DOOR_MIN_HEIGHT"] = Constants.PATIO_DOOR_MIN_HEIGHT;
            Session["MODEL_100_200_300_TRANSOM_MINIMUM_SIZE"] = Constants.MODEL_100_200_300_TRANSOM_MINIMUM_SIZE;
            Session["MODEL_400_TRANSOM_MINIMUM_SIZE"] = Constants.MODEL_400_TRANSOM_MINIMUM_SIZE;
            #endregion
            #region WINDOW VALIDATION CONSTANTS

            #region MIN_WIDTH_WARRANTY
            //Session["V4T_2V_MIN_WIDTH_WARRANTY"] = Constants.V4T_2V_MIN_WIDTH_WARRANTY;
            Session["V4T_3V_MIN_WIDTH_WARRANTY"] = Constants.V4T_3V_MIN_WIDTH_WARRANTY;
            Session["V4T_4V_MIN_WIDTH_WARRANTY"] = Constants.V4T_4V_MIN_WIDTH_WARRANTY;
            Session["HORIZONTAL_ROLLER_MIN_WIDTH_WARRANTY"] = Constants.HORIZONTAL_ROLLER_MIN_WIDTH_WARRANTY;
            Session["VINYL_LITE_MIN_WIDTH_WARRANTY"] = Constants.VINYL_LITE_MIN_WIDTH_WARRANTY;
            Session["VINYL_TRAP_MIN_WIDTH_WARRANTY"] = Constants.VINYL_TRAP_MIN_WIDTH_WARRANTY;

            Session["DOUBLE_SLIDER_MIN_WIDTH_WARRANTY"] = Constants.DOUBLE_SLIDER_MIN_WIDTH_WARRANTY;
            Session["DOUBLE_SLIDER_LITE_MIN_WIDTH_WARRANTY"] = Constants.DOUBLE_SLIDER_LITE_MIN_WIDTH_WARRANTY;
            Session["DOUBLE_SLIDER_TRAP_MIN_WIDTH_WARRANTY"] = Constants.DOUBLE_SLIDER_TRAP_MIN_WIDTH_WARRANTY;

            Session["SINGLE_SLIDER_MIN_WIDTH_WARRANTY"] = Constants.SINGLE_SLIDER_MIN_WIDTH_WARRANTY;
            Session["SINGLE_SLIDER_LITE_MIN_WIDTH_WARRANTY"] = Constants.SINGLE_SLIDER_LITE_MIN_WIDTH_WARRANTY;
            Session["SINGLE_SLIDER_TRAP_MIN_WIDTH_WARRANTY"] = Constants.SINGLE_SLIDER_TRAP_MIN_WIDTH_WARRANTY;

            Session["SCREEN_MIN_WIDTH_WARRANTY"] = Constants.SCREEN_MIN_WIDTH_WARRANTY;
            #endregion
            #region MAX_WIDTH_WARRANTY
            //Session["V4T_2V_MAX_WIDTH_WARRANTY"] = Constants.V4T_2V_MAX_WIDTH_WARRANTY;
            Session["V4T_3V_MAX_WIDTH_WARRANTY"] = Constants.V4T_3V_MAX_WIDTH_WARRANTY;
            Session["V4T_4V_MAX_WIDTH_WARRANTY"] = Constants.V4T_4V_MAX_WIDTH_WARRANTY;
            Session["HORIZONTAL_ROLLER_MAX_WIDTH_WARRANTY"] = Constants.HORIZONTAL_ROLLER_MAX_WIDTH_WARRANTY;
            Session["VINYL_LITE_MAX_WIDTH_WARRANTY"] = Constants.VINYL_LITE_MAX_WIDTH_WARRANTY;
            Session["VINYL_TRAP_MAX_WIDTH_WARRANTY"] = Constants.VINYL_TRAP_MAX_WIDTH_WARRANTY;

            Session["DOUBLE_SLIDER_MAX_WIDTH_WARRANTY"] = Constants.DOUBLE_SLIDER_MAX_WIDTH_WARRANTY;
            Session["DOUBLE_SLIDER_LITE_MAX_WIDTH_WARRANTY"] = Constants.DOUBLE_SLIDER_LITE_MAX_WIDTH_WARRANTY;
            Session["DOUBLE_SLIDER_TRAP_MAX_WIDTH_WARRANTY"] = Constants.DOUBLE_SLIDER_TRAP_MAX_WIDTH_WARRANTY;

            Session["SINGLE_SLIDER_MAX_WIDTH_WARRANTY"] = Constants.SINGLE_SLIDER_MAX_WIDTH_WARRANTY;
            Session["SINGLE_SLIDER_LITE_MAX_WIDTH_WARRANTY"] = Constants.SINGLE_SLIDER_LITE_MAX_WIDTH_WARRANTY;
            Session["SINGLE_SLIDER_TRAP_MAX_WIDTH_WARRANTY"] = Constants.SINGLE_SLIDER_TRAP_MAX_WIDTH_WARRANTY;

            Session["SCREEN_MAX_WIDTH_WARRANTY"] = Constants.SCREEN_MAX_WIDTH_WARRANTY;
            #endregion

            #region MIN_HEIGHT_WARRANTY
            //Session["V4T_2V_MIN_HEIGHT_WARRANTY"] = Constants.V4T_2V_MIN_HEIGHT_WARRANTY;
            Session["V4T_3V_MIN_HEIGHT_WARRANTY"] = Constants.V4T_3V_MIN_HEIGHT_WARRANTY;
            Session["V4T_4V_MIN_HEIGHT_WARRANTY"] = Constants.V4T_4V_MIN_HEIGHT_WARRANTY;
            Session["HORIZONTAL_ROLLER_MIN_HEIGHT_WARRANTY"] = Constants.HORIZONTAL_ROLLER_MIN_HEIGHT_WARRANTY;
            Session["VINYL_LITE_MIN_HEIGHT_WARRANTY"] = Constants.VINYL_LITE_MIN_HEIGHT_WARRANTY;
            Session["VINYL_TRAP_MIN_HEIGHT_WARRANTY"] = Constants.VINYL_TRAP_MIN_HEIGHT_WARRANTY;

            Session["DOUBLE_SLIDER_MIN_HEIGHT_WARRANTY"] = Constants.DOUBLE_SLIDER_MIN_HEIGHT_WARRANTY;
            Session["DOUBLE_SLIDER_LITE_MIN_HEIGHT_WARRANTY"] = Constants.DOUBLE_SLIDER_LITE_MIN_HEIGHT_WARRANTY;
            Session["DOUBLE_SLIDER_TRAP_MIN_HEIGHT_WARRANTY"] = Constants.DOUBLE_SLIDER_TRAP_MIN_HEIGHT_WARRANTY;

            Session["SINGLE_SLIDER_MIN_HEIGHT_WARRANTY"] = Constants.SINGLE_SLIDER_MIN_HEIGHT_WARRANTY;
            Session["SINGLE_SLIDER_LITE_MIN_HEIGHT_WARRANTY"] = Constants.SINGLE_SLIDER_LITE_MIN_HEIGHT_WARRANTY;
            Session["SINGLE_SLIDER_TRAP_MIN_HEIGHT_WARRANTY"] = Constants.SINGLE_SLIDER_TRAP_MIN_HEIGHT_WARRANTY;

            Session["SCREEN_MIN_HEIGHT_WARRANTY"] = Constants.SCREEN_MIN_HEIGHT_WARRANTY;
            #endregion
            #region MAX_HEIGHT_WARRANTY
            //Session["V4T_2V_MAX_HEIGHT_WARRANTY"] = Constants.V4T_2V_MAX_HEIGHT_WARRANTY;
            Session["V4T_3V_MAX_HEIGHT_WARRANTY"] = Constants.V4T_3V_MAX_HEIGHT_WARRANTY;
            Session["V4T_4V_MAX_HEIGHT_WARRANTY"] = Constants.V4T_4V_MAX_HEIGHT_WARRANTY;
            Session["HORIZONTAL_ROLLER_MAX_HEIGHT_WARRANTY"] = Constants.HORIZONTAL_ROLLER_MAX_HEIGHT_WARRANTY;
            Session["VINYL_LITE_MAX_HEIGHT_WARRANTY"] = Constants.VINYL_LITE_MAX_HEIGHT_WARRANTY;
            Session["VINYL_TRAP_MAX_HEIGHT_WARRANTY"] = Constants.VINYL_TRAP_MAX_HEIGHT_WARRANTY;

            Session["DOUBLE_SLIDER_MAX_HEIGHT_WARRANTY"] = Constants.DOUBLE_SLIDER_MAX_HEIGHT_WARRANTY;
            Session["DOUBLE_SLIDER_LITE_MAX_HEIGHT_WARRANTY"] = Constants.DOUBLE_SLIDER_LITE_MAX_HEIGHT_WARRANTY;
            Session["DOUBLE_SLIDER_TRAP_MAX_HEIGHT_WARRANTY"] = Constants.DOUBLE_SLIDER_TRAP_MAX_HEIGHT_WARRANTY;

            Session["SINGLE_SLIDER_MAX_HEIGHT_WARRANTY"] = Constants.SINGLE_SLIDER_MAX_HEIGHT_WARRANTY;
            Session["SINGLE_SLIDER_LITE_MAX_HEIGHT_WARRANTY"] = Constants.SINGLE_SLIDER_LITE_MAX_HEIGHT_WARRANTY;
            Session["SINGLE_SLIDER_TRAP_MAX_HEIGHT_WARRANTY"] = Constants.SINGLE_SLIDER_TRAP_MAX_HEIGHT_WARRANTY;

            Session["SCREEN_MAX_HEIGHT_WARRANTY"] = Constants.SCREEN_MAX_HEIGHT_WARRANTY;
            #endregion

            #region SPREADER_BAR_NEEDED
            Session["V4T_SPREADER_BAR_NEEDED"] = Constants.V4T_SPREADER_BAR_NEEDED;
            Session["HORIZONTAL_ROLLER_SPREADER_BAR_NEEDED"] = Constants.HORIZONTAL_ROLLER_SPREADER_BAR_NEEDED;
            #endregion

            #endregion

            Session["DEFAULT_FILLER"] = Constants.PREFERRED_DEFAULT_FILLER;

            /***hard coded variables***/
            Session["model"] = "M100";
            Session["soffitLength"] = 0F;
            Session["model"] = "M300";
            Session["soffitLength"] = 10F;
            Session["kneewallType"] = "glass";
            Session["kneewallHeight"] = 20F;
            Session["transomType"] = "vinyl";
            Session["transomHeight"] = 20F;
            /****************diffrent sunroom layouts******************/
            //Session["coordList"] = "112.5,387.5,150,150,E,S/200,200,150,287.5,P,W/200,337.5,287.5,150,P,SE/";
            //Session["coordList"] = "75,425,150,150,E,S/150,150,150,250,P,W/150,350,250,250,P,S/350,350,250,150,P,E/";
            //Session["coordList"] = "62.5,362.5,162.5,162.5,E,S/362.5,175,162.5,350,E,NW/175,175,350,162.5,E,E/175,262.5,287.5,287.5,P,S/262.5,262.5,287.5,237.5,P,E/262.5,125,237.5,237.5,P,N/125,125,237.5,162.5,P,E/";
            //Session["coordList"] = "50,300,250,250,E,S/300,300,250,25,E,E/175,175,250,375,P,W/175,425,375,375,P,S/425,425,375,125,P,E/425,300,125,125,P,N/";
            //Session["coordList"] = "75,262.5,175,175,E,S/262.5,262.5,175,200,E,W/262.5,425,200,200,E,S/150,150,175,300,P,W/150,350,300,300,P,S/350,350,300,200,P,E/";
            //Session["coordList"] = "100,412.5,137.5,137.5,E,S/150,150,137.5,287.5,P,W/150,225,287.5,362.5,P,SW/225,312.5,362.5,362.5,P,S/312,387.5,362.5,287.5,P,SE/387.5,387.5,287.5,137.5,P,E/";
            //Session["coordList"] = "112.5,350,112.5,112.5,E,S/350,350,112.5,337.5,E,W/175,175,112.5,262.5,P,W/175,350,262.5,262.5,P,S/";
            //GABLE EXAMPLE BELOW
            Session["coordList"] = "200,275,300,300,G,S/100,375,150,150,E,S/100,100,150,300,P,W/100,200,300,300,P,S/275,375,300,300,P,S/375,375,300,150,P,E/";
            /**********************************************************/
            coordList = (string)Session["lineInfo"]; //get the string from the session and store it in a local variable for further use                                    
            strWalls = coordList.Split(lineDelimiter, StringSplitOptions.RemoveEmptyEntries); //split the string received from session and store it into an array of strings with individual line details
            wallDetails = new string[strWalls.Count(),6]; //a two dimensional array to store the the details of each line individually as seperate elements ... 6 represents the number of detail items for each line
            currentModel = (string)Session["model"];
            soffitLength = (float)Session["soffitLength"];
            int existingWallCount = 0; //used to determine how many existing walls are in a drawing 
            int displayedWallCount = 0; //used to determine how many proposed walls are in a drawing

            //populate the array with all the wall details for each wall
            /***************************************************************************/
            /********************All of this can go to the page where ******************/
            /********************the coordList string is concatenated!******************/
            /***************************************************************************/
            int hiddenDivWallRequirementNumber = 0;

            for (int i = 0; i < strWalls.Count(); i++) //run through all the walls in the array
            {
                string[] tempDetails = strWalls[i].Split(detailsDelimiter, StringSplitOptions.RemoveEmptyEntries); //split the given wall string into its individual detail items and store it in temporary array

                for (int j = 0; j < tempDetails.Count(); j++) //for each item in the tempDetails array
                {
                    wallDetails[i, j] = tempDetails[j]; //store it in the appropriate spot for the appropriate line in the wallDetails array 
                }
            }
                                    
            for (int i = 1; i <= strWalls.Count(); i++) //for each wall in walls 
            {
                //if (wallDetails[i - 1, 4] == "E") //wall type is existing
                //{
                //    existingWallCount++; //increment the existing wall counter
                //    populateTblExisting(i, existingWallCount); //populate the existing walls table on slide 1
                //}
                //else //wall type is proposed
                if (wallDetails[i - 1, 4] == "P")
                {
                    hiddenDivWallRequirementNumber++;
                    displayedWallCount++; //increment the proposed wall counter
                    populateTblProposed(i, displayedWallCount); //populate the proposed walls table on slide 1                    
                    populateWallDoorOptions(i, displayedWallCount); //populate slide 3 with appropriate proposed wall door options
                }
                else if (wallDetails[i - 1, 4] == "G")
                {
                    hiddenDivWallRequirementNumber++;
                    Session["isGable"] = true;
                    populateTblProposedGable(i, displayedWallCount); //populate the gable post table on slide 1
                }
            }

            hiddenFieldsDiv.InnerHtml = createHiddenFields(strWalls.Count()); //create hidden fields on page load dynamically, pass it number of walls
            
            populateTblWallHeights();

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
         */
        //protected void populateTblExisting(int i, int existingWallCount)
        //{
        //    TableRow row = new TableRow(); //new table to to be appended to the table with all the appropriate fields in it
            
        //    TableCell cell1 = new TableCell(); //new table cell to store the wall name label
        //    TableCell cell2 = new TableCell(); //new table cell to store the textbox
        //    TableCell cell3 = new TableCell(); //new table cell to store the dropdown list
            
        //    Label lblWallNumber = new Label(); //new label to display the wall name/number

        //    TextBox txtWallLength = new TextBox(); //new textbox for user input for length
            
        //    DropDownList ddlInchFractions = new DropDownList(); //new dropdown list for length inch fractions

        //    //add the inch fraction list items to the dropdown list
        //    ddlInchFractions.Items.Add(lst0);
        //    ddlInchFractions.Items.Add(lst18);
        //    ddlInchFractions.Items.Add(lst14);
        //    ddlInchFractions.Items.Add(lst38);
        //    ddlInchFractions.Items.Add(lst12);
        //    ddlInchFractions.Items.Add(lst58);
        //    ddlInchFractions.Items.Add(lst34);
        //    ddlInchFractions.Items.Add(lst78);
        //    ddlInchFractions.Attributes.Add("onchange", "checkQuestion1()"); //give it an attribute to check question 1 on change

        //    lblWallNumber.Text = "Existing Wall " + existingWallCount + " : "; //output wall name/number to the label
    
        //    ddlInchFractions.ID = "ddlWall" + i + "InchFractions"; //give an appropriate id to dropdown list
        //    lblWallNumber.ID = "lblWall" + i + "Length"; //give an appropriate id to the label
        //    lblWallNumber.AssociatedControlID = "txtWall" + i + "Length"; //set the label's associated control id

        //    txtWallLength.ID = "txtWall" + i + "Length"; //give an appropriate id to the textbox
        //    txtWallLength.CssClass = "txtField txtLengthInput"; //give the textbox a css class
        //    txtWallLength.MaxLength = 3; //set the max length of the textbox to prevent invalid input
        //    txtWallLength.Attributes.Add("onkeyup", "checkQuestion1()"); //set its attribute to check question 1 on key up
        //    txtWallLength.Attributes.Add("OnChange", "checkQuestion1()");//set its attribute to check question 1 on change
        //    txtWallLength.Attributes.Add("OnFocus", "highlightWallsLength()"); //set its attribute to highlight walls on focus
        //    txtWallLength.Attributes.Add("onblur", "resetWalls()"); //set its attribute to reset walls on blur

        //    cell1.Controls.Add(lblWallNumber); //append the label to cell 1
        //    cell2.Controls.Add(txtWallLength); //append the textbox to cell 2
        //    cell3.Controls.Add(ddlInchFractions); //append the dropdown to cell 3
            
        //    tblExistingWalls.Rows.Add(row); //append the row to the existing walls table

        //    //append all the cells to the row
        //    row.Cells.Add(cell1); 
        //    row.Cells.Add(cell2);
        //    row.Cells.Add(cell3);
        //}


        /// <summary>
        /// This method is used to dynamically populate the table for proposed walls on slide/question 1.
        /// It creates table a table row and cells and appends appropriate input fields to each cell for user input,
        ///     and gives each input field appropriate values
        /// </summary>
        /// <param name="i">index of the given wall, used to give appropriate ID's to input fields</param>
        /// <param name="displayedWallCount">used to give appropriate values to the wall name labels</param>
        protected void populateTblProposed(int i, int displayedWallCount)
        {
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


            lblWallNumber.Text = "Wall " + displayedWallCount + " : "; //output wall name/number to the label

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
            txtLeftFiller.Text = Constants.PREFERRED_DEFAULT_FILLER.ToString();
            txtLeftFiller.Attributes.Add("onkeyup", "checkQuestion1()"); //set its attribute to check question 1 on key up
            txtLeftFiller.Attributes.Add("OnChange", "checkQuestion1()");//set its attribute to check question 1 on change
            txtLeftFiller.Attributes.Add("OnFocus", "highlightWallsLength()");//set its attribute to highlight walls on focus
            txtLeftFiller.Attributes.Add("onblur", "resetWalls()");//set its attribute to reset walls on blur

            txtRightFiller.ID = "txtWall" + i + "RightFiller";//give an appropriate id to the right filler textbox
            txtRightFiller.CssClass = "txtField txtLengthInput"; //give the textbox a css class
            txtRightFiller.MaxLength = 3; //set the max length of textbox to 3 to prevent invalid input
            txtRightFiller.Text = Constants.PREFERRED_DEFAULT_FILLER.ToString();
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
            
        }

        protected void populateTblProposedGable(int i, int displayedWallCount)
        {
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


            lblWallNumber.Text = "Wall " + displayedWallCount + " (Gable Post): "; //output wall name/number to the label

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
            txtLeftFiller.Text = "0";
            txtLeftFiller.Attributes.Add("onkeyup", "checkQuestion1()"); //set its attribute to check question 1 on key up
            txtLeftFiller.Attributes.Add("OnChange", "checkQuestion1()");//set its attribute to check question 1 on change
            txtLeftFiller.Attributes.Add("OnFocus", "highlightWallsLength()");//set its attribute to highlight walls on focus
            txtLeftFiller.Attributes.Add("onblur", "resetWalls()");//set its attribute to reset walls on blur

            txtRightFiller.ID = "txtWall" + i + "RightFiller";//give an appropriate id to the right filler textbox
            txtRightFiller.CssClass = "txtField txtLengthInput"; //give the textbox a css class
            txtRightFiller.MaxLength = 3; //set the max length of textbox to 3 to prevent invalid input
            txtRightFiller.Text = "0";
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
            
        }

        protected void populateTblWallHeights()
        {
            bool isGable = false;

            for (int i = 1; i <= strWalls.Count(); i++) //for each wall in walls 
            {
                if (wallDetails[i - 1, 4] == "G")
                {
                    isGable = true;
                    break;
                }
            }

            if (isGable)
            {

                #region Table Row # Left Wall Height
                TableRow leftWallHeightRow = new TableRow();
                TableCell leftWallLabelCell = new TableCell();
                TableCell leftWallTextboxCell = new TableCell();
                TableCell leftWallDropDownInchesCell = new TableCell();
                TableCell leftWallRadioAutoFillCell = new TableCell();

                Label leftWallLabel = new Label();
                leftWallLabel.ID = "lblLeftWallHeight";
                leftWallLabel.Text = "Left Wall Height:";

                TextBox leftWallTextbox = new TextBox();
                leftWallTextbox.ID = "txtLeftWallHeight";
                leftWallTextbox.CssClass = "txtField txtInput";
                leftWallTextbox.Attributes.Add("onkeyup", "checkQuestion2('" + isGable + "')");
                leftWallTextbox.Attributes.Add("onblur", "resetWalls()");
                leftWallTextbox.Attributes.Add("OnFocus", "highlightWallsHeightGable()");
                leftWallTextbox.MaxLength = 3;

                DropDownList leftWallInchSpecific = new DropDownList();
                leftWallInchSpecific.ID = "leftWallInchSpecificDDL";
                leftWallInchSpecific.Attributes.Add("onchange", "checkQuestion2('" + isGable + "')");
                leftWallInchSpecific.Items.Add(lst0);
                leftWallInchSpecific.Items.Add(lst18);
                leftWallInchSpecific.Items.Add(lst14);
                leftWallInchSpecific.Items.Add(lst38);
                leftWallInchSpecific.Items.Add(lst12);
                leftWallInchSpecific.Items.Add(lst58);
                leftWallInchSpecific.Items.Add(lst34);
                leftWallInchSpecific.Items.Add(lst78);

                RadioButton leftWallRadioAutoFill = new RadioButton();
                leftWallRadioAutoFill.ID = "radAutoLeftWallHeight";
                leftWallRadioAutoFill.GroupName = "wallHeightsSlopes";

                Label leftWallRadioLabel = new Label();
                leftWallRadioLabel.ID = "lblRadioLeftWallClickable";
                leftWallRadioLabel.AssociatedControlID = "radAutoLeftWallHeight";

                Label leftWallRadioTextLabel = new Label();
                leftWallRadioTextLabel.ID = "lblRadioLeftWallText";
                leftWallRadioTextLabel.AssociatedControlID = "radAutoLeftWallHeight";
                leftWallRadioTextLabel.Text = "Auto Populate";

                leftWallLabel.AssociatedControlID = "txtLeftWallHeight";
                #endregion

                #region Table Row # Right Wall Height
                TableRow rightWallHeightRow = new TableRow();
                TableCell rightWallLabelCell = new TableCell();
                TableCell rightWallTextboxCell = new TableCell();
                TableCell rightWallDropDownInchesCell = new TableCell();
                TableCell rightWallRadioAutoFillCell = new TableCell();

                Label rightWallLabel = new Label();
                rightWallLabel.ID = "lblRightWallHeight";
                rightWallLabel.Text = "Right Wall Height:";

                TextBox rightWallTextbox = new TextBox();
                rightWallTextbox.ID = "txtRightWallHeight";
                rightWallTextbox.CssClass = "txtField txtInput";
                rightWallTextbox.Attributes.Add("onkeyup", "checkQuestion2('" + isGable + "')");
                rightWallTextbox.Attributes.Add("onblur", "resetWalls()");
                rightWallTextbox.Attributes.Add("OnFocus", "highlightWallsHeightGable()");
                rightWallTextbox.ID = "txtRightWallHeight";
                rightWallTextbox.MaxLength = 3;

                DropDownList rightWallInchSpecific = new DropDownList();
                rightWallInchSpecific.ID = "rightWallInchSpecificDDL";
                rightWallInchSpecific.Attributes.Add("onchange", "checkQuestion2('" + isGable + "')");
                rightWallInchSpecific.Items.Add(lst0);
                rightWallInchSpecific.Items.Add(lst18);
                rightWallInchSpecific.Items.Add(lst14);
                rightWallInchSpecific.Items.Add(lst38);
                rightWallInchSpecific.Items.Add(lst12);
                rightWallInchSpecific.Items.Add(lst58);
                rightWallInchSpecific.Items.Add(lst34);
                rightWallInchSpecific.Items.Add(lst78);

                RadioButton rightWallRadioAutoFill = new RadioButton();
                rightWallRadioAutoFill.ID = "radAutoRightWallHeight";
                rightWallRadioAutoFill.GroupName = "wallHeightsSlopes";

                Label rightWallRadioLabel = new Label();
                rightWallRadioLabel.ID = "lblRadioRightWallClickable";
                rightWallRadioLabel.AssociatedControlID = "radAutoRightWallHeight";

                Label rightWallRadioTextLabel = new Label();
                rightWallRadioTextLabel.ID = "lblRadioRightWallText";
                rightWallRadioTextLabel.AssociatedControlID = "radAutoRightWallHeight";
                rightWallRadioTextLabel.Text = "Auto Populate";

                rightWallLabel.AssociatedControlID = "txtRightWallHeight";
                #endregion

                #region Table Row # Gable Post Height
                TableRow gablePostHeightRow = new TableRow();
                TableCell gablePostLabelCell = new TableCell();
                TableCell gablePostTextboxCell = new TableCell();
                TableCell gablePostDropDownInchesCell = new TableCell();
                TableCell gablePostRadioAutoFillCell = new TableCell();

                Label gablePostLabel = new Label();
                gablePostLabel.ID = "lblGablePostHeight";
                gablePostLabel.Text = "Gable Post Height:";

                TextBox gablePostTextbox = new TextBox();
                gablePostTextbox.ID = "txtGablePostHeight";
                gablePostTextbox.CssClass = "txtField txtInput";
                gablePostTextbox.Attributes.Add("onkeyup", "checkQuestion2('" + isGable + "')");
                gablePostTextbox.Attributes.Add("onblur", "resetWalls()");
                gablePostTextbox.Attributes.Add("OnFocus", "highlightWallsHeightGable()");
                gablePostTextbox.ID = "txtGablePostHeight";
                gablePostTextbox.MaxLength = 3;

                DropDownList gablePostInchSpecific = new DropDownList();
                gablePostInchSpecific.ID = "gablePostInchSpecificDDL";
                gablePostInchSpecific.Attributes.Add("onchange", "checkQuestion2('" + isGable + "')");
                gablePostInchSpecific.Items.Add(lst0);
                gablePostInchSpecific.Items.Add(lst18);
                gablePostInchSpecific.Items.Add(lst14);
                gablePostInchSpecific.Items.Add(lst38);
                gablePostInchSpecific.Items.Add(lst12);
                gablePostInchSpecific.Items.Add(lst58);
                gablePostInchSpecific.Items.Add(lst34);
                gablePostInchSpecific.Items.Add(lst78);

                RadioButton gablePostRadioAutoFill = new RadioButton();
                gablePostRadioAutoFill.ID = "radAutoGablePostHeight";
                gablePostRadioAutoFill.GroupName = "wallHeightsSlopes";

                Label gablePostRadioLabel = new Label();
                gablePostRadioLabel.ID = "lblRadioGablePostClickable";
                gablePostRadioLabel.AssociatedControlID = "radAutoGablePostHeight";

                Label gablePostRadioTextLabel = new Label();
                gablePostRadioTextLabel.ID = "lblRadioGablePostText";
                gablePostRadioTextLabel.AssociatedControlID = "radAutoGablePostHeight";
                gablePostRadioTextLabel.Text = "Auto Populate";

                gablePostLabel.AssociatedControlID = "txtGablePostHeight";
                #endregion

                #region Table Row # Left Roof Slope
                TableRow leftRoofSlopeRow = new TableRow();
                TableCell leftRoofSlopeLabelCell = new TableCell();
                TableCell leftRoofSlopeTextboxCell = new TableCell();
                TableCell leftRoofSlopeRunLabelCell = new TableCell();
                TableCell leftRoofSlopeRadioAutoFillCell = new TableCell();
                leftRoofSlopeRadioAutoFillCell.RowSpan = 2;

                Label leftRoofSlopeLabel = new Label();
                leftRoofSlopeLabel.ID = "lblLeftRoofSlope";
                leftRoofSlopeLabel.Text = "Left Roof Slope:";

                TextBox leftRoofSlopeTextbox = new TextBox();
                leftRoofSlopeTextbox.ID = "txtLeftRoofSlope";
                leftRoofSlopeTextbox.CssClass = "txtField txtInput";
                leftRoofSlopeTextbox.Attributes.Add("onkeyup", "checkQuestion2('" + isGable + "')");
                leftRoofSlopeTextbox.Attributes.Add("onblur", "resetWalls()");
                leftRoofSlopeTextbox.Attributes.Add("OnFocus", "highlightWallsHeightGable()");
                leftRoofSlopeTextbox.MaxLength = 6;

                Label leftRoofSlopeRunLabel = new Label();
                leftRoofSlopeRunLabel.ID = "lblLeftRoofRunSlope";
                leftRoofSlopeRunLabel.Text = "/12";

                RadioButton leftRoofSlopeRadioAutoFill = new RadioButton();
                leftRoofSlopeRadioAutoFill.ID = "radAutoRoofSlope";
                leftRoofSlopeRadioAutoFill.GroupName = "wallHeightsSlopes";
                leftRoofSlopeRadioAutoFill.Checked = true;

                Label leftRoofSlopeRadioLabel = new Label();
                leftRoofSlopeRadioLabel.ID = "lblRadioRoofSlopeClickable";
                leftRoofSlopeRadioLabel.AssociatedControlID = "radAutoRoofSlope";

                Label leftRoofSlopeRadioTextLabel = new Label();
                leftRoofSlopeRadioTextLabel.ID = "lblRadioRoofSlopeText";
                leftRoofSlopeRadioTextLabel.AssociatedControlID = "radAutoRoofSlope";
                leftRoofSlopeRadioTextLabel.Text = "Auto Populate";

                leftRoofSlopeLabel.AssociatedControlID = "txtLeftRoofSlope";
                #endregion

                #region Table Row # Right Roof Slope
                TableRow rightRoofSlopeRow = new TableRow();
                TableCell rightRoofSlopeLabelCell = new TableCell();
                TableCell rightRoofSlopeTextboxCell = new TableCell();
                TableCell rightRoofSlopeRunLabelCell = new TableCell();
                TableCell rightRoofSlopeRadioAutoFillCell = new TableCell();

                Label rightRoofSlopeLabel = new Label();
                rightRoofSlopeLabel.ID = "lblRightRoofSlope";
                rightRoofSlopeLabel.Text = "Right Roof Slope:";

                TextBox rightRoofSlopeTextbox = new TextBox();
                rightRoofSlopeTextbox.ID = "txtRightRoofSlope";
                rightRoofSlopeTextbox.CssClass = "txtField txtInput";
                rightRoofSlopeTextbox.Attributes.Add("onkeyup", "checkQuestion2('" + isGable + "')");
                rightRoofSlopeTextbox.Attributes.Add("onblur", "resetWalls()");
                rightRoofSlopeTextbox.Attributes.Add("OnFocus", "highlightWallsHeightGable()");
                rightRoofSlopeTextbox.MaxLength = 6;

                Label rightRoofSlopeRunLabel = new Label();
                rightRoofSlopeRunLabel.ID = "lblRightRoofRunSlope";
                rightRoofSlopeRunLabel.Text = "/12";

                rightRoofSlopeLabel.AssociatedControlID = "txtRightRoofSlope";
                #endregion

                #region Table Row # Side Walls Same Height
                TableRow sideWallsRow = new TableRow();
                TableCell sideWallsLabelCell = new TableCell();
                TableCell sideWallsCheckAutoHeightCell = new TableCell();

                Label sideWallsLabel = new Label();
                sideWallsLabel.ID = "lblSideWalls";
                sideWallsLabel.Text = "Side Walls Same Height:";

                CheckBox sideWallsAutoHeight = new CheckBox();
                sideWallsAutoHeight.ID = "chkAutoWalls";
                sideWallsAutoHeight.Checked = false;
                sideWallsAutoHeight.Attributes.Add("onclick", "sameWallHeight()");

                Label sideWallsCheckLabel = new Label();
                sideWallsCheckLabel.ID = "lblCheckWallsSAmeClickable";
                sideWallsCheckLabel.AssociatedControlID = "chkAutoWalls";

                //Label sideWallsTextLabel = new Label();
                //sideWallsTextLabel.ID = "lblCheckWallsSameText";
                //sideWallsTextLabel.AssociatedControlID = "chkAutoWalls";
                //sideWallsTextLabel.Text = "Side Walls Same Height:";
                #endregion


                #region Table Row # Back Wall Height Added
                leftWallLabelCell.Controls.Add(leftWallLabel);
                leftWallTextboxCell.Controls.Add(leftWallTextbox);
                leftWallDropDownInchesCell.Controls.Add(leftWallInchSpecific);
                leftWallRadioAutoFillCell.Controls.Add(leftWallRadioAutoFill);
                leftWallRadioAutoFillCell.Controls.Add(leftWallRadioLabel);
                leftWallRadioAutoFillCell.Controls.Add(leftWallRadioTextLabel);

                tblWallHeights.Rows.Add(leftWallHeightRow);

                leftWallHeightRow.Cells.Add(leftWallLabelCell);
                leftWallHeightRow.Cells.Add(leftWallTextboxCell);
                leftWallHeightRow.Cells.Add(leftWallDropDownInchesCell);
                leftWallHeightRow.Cells.Add(leftWallRadioAutoFillCell);
                #endregion

                #region Table Row # Front Wall Height Added
                rightWallLabelCell.Controls.Add(rightWallLabel);
                rightWallTextboxCell.Controls.Add(rightWallTextbox);
                rightWallDropDownInchesCell.Controls.Add(rightWallInchSpecific);
                rightWallRadioAutoFillCell.Controls.Add(rightWallRadioAutoFill);
                rightWallRadioAutoFillCell.Controls.Add(rightWallRadioLabel);
                rightWallRadioAutoFillCell.Controls.Add(rightWallRadioTextLabel);

                tblWallHeights.Rows.Add(rightWallHeightRow);

                rightWallHeightRow.Cells.Add(rightWallLabelCell);
                rightWallHeightRow.Cells.Add(rightWallTextboxCell);
                rightWallHeightRow.Cells.Add(rightWallDropDownInchesCell);
                rightWallHeightRow.Cells.Add(rightWallRadioAutoFillCell);
                #endregion

                #region Table Row # Gable Post Height Added
                gablePostLabelCell.Controls.Add(gablePostLabel);
                gablePostTextboxCell.Controls.Add(gablePostTextbox);
                gablePostDropDownInchesCell.Controls.Add(gablePostInchSpecific);
                gablePostRadioAutoFillCell.Controls.Add(gablePostRadioAutoFill);
                gablePostRadioAutoFillCell.Controls.Add(gablePostRadioLabel);
                gablePostRadioAutoFillCell.Controls.Add(gablePostRadioTextLabel);

                tblWallHeights.Rows.Add(gablePostHeightRow);

                gablePostHeightRow.Cells.Add(gablePostLabelCell);
                gablePostHeightRow.Cells.Add(gablePostTextboxCell);
                gablePostHeightRow.Cells.Add(gablePostDropDownInchesCell);
                gablePostHeightRow.Cells.Add(gablePostRadioAutoFillCell);
                #endregion

                #region Table Row # Left Roof Slope Added
                leftRoofSlopeLabelCell.Controls.Add(leftRoofSlopeLabel);
                leftRoofSlopeTextboxCell.Controls.Add(leftRoofSlopeTextbox);
                leftRoofSlopeRunLabelCell.Controls.Add(leftRoofSlopeRunLabel);
                leftRoofSlopeRadioAutoFillCell.Controls.Add(leftRoofSlopeRadioAutoFill);
                leftRoofSlopeRadioAutoFillCell.Controls.Add(leftRoofSlopeRadioLabel);
                leftRoofSlopeRadioAutoFillCell.Controls.Add(leftRoofSlopeRadioTextLabel);

                tblWallHeights.Rows.Add(leftRoofSlopeRow);

                leftRoofSlopeRow.Cells.Add(leftRoofSlopeLabelCell);
                leftRoofSlopeRow.Cells.Add(leftRoofSlopeTextboxCell);
                leftRoofSlopeRow.Cells.Add(leftRoofSlopeRunLabelCell);
                leftRoofSlopeRow.Cells.Add(leftRoofSlopeRadioAutoFillCell);
                #endregion

                #region Table Row # Right Roof Slope Added
                rightRoofSlopeLabelCell.Controls.Add(rightRoofSlopeLabel);
                rightRoofSlopeTextboxCell.Controls.Add(rightRoofSlopeTextbox);
                rightRoofSlopeRunLabelCell.Controls.Add(rightRoofSlopeRunLabel);

                tblWallHeights.Rows.Add(rightRoofSlopeRow);

                rightRoofSlopeRow.Cells.Add(rightRoofSlopeLabelCell);
                rightRoofSlopeRow.Cells.Add(rightRoofSlopeTextboxCell);
                rightRoofSlopeRow.Cells.Add(rightRoofSlopeRunLabelCell);
                #endregion

                #region Table Row # Side Walls Same Height
                sideWallsLabelCell.Controls.Add(sideWallsLabel);
                sideWallsCheckAutoHeightCell.Controls.Add(sideWallsAutoHeight);
                sideWallsCheckAutoHeightCell.Controls.Add(sideWallsCheckLabel);
                //sideWallsCheckAutoHeightCell.Controls.Add(sideWallsTextLabel);

                tblWallHeights.Rows.Add(sideWallsRow);

                sideWallsRow.Cells.Add(sideWallsLabelCell);
                sideWallsRow.Cells.Add(sideWallsCheckAutoHeightCell);
                #endregion

                string hiddenString = "";
                hiddenString += "<input id=\"hidLeftWallHeight\" type=\"hidden\" runat=\"server\" />";
                hiddenString += "<input id=\"hidRightWallHeight\" type=\"hidden\" runat=\"server\" />";
                hiddenString += "<input id=\"hidGableWallHeight\" type=\"hidden\" runat=\"server\" />";
                hiddenString += "<input id=\"hidLeftRoofSlope\" type=\"hidden\" runat=\"server\" />";
                hiddenString += "<input id=\"hidRightRoofSlope\" type=\"hidden\" runat=\"server\" />";

                hiddenFieldsDiv.InnerHtml += hiddenString;
            }
            else {
                #region Table Row # Back Wall Height
                TableRow backWallHeightRow = new TableRow();
                TableCell backWallLabelCell = new TableCell();
                TableCell backWallTextboxCell = new TableCell();
                TableCell backWallDropDownInchesCell = new TableCell();
                TableCell backWallRadioAutoFillCell = new TableCell();

                Label backWallLabel = new Label();
                backWallLabel.ID = "lblBackWallHeight";
                backWallLabel.Text = "Back Wall Height:";

                TextBox backWallTextbox = new TextBox();
                backWallTextbox.ID = "txtBackWallHeight";
                backWallTextbox.CssClass = "txtField txtInput";
                backWallTextbox.Attributes.Add("onkeyup", "checkQuestion2('" + isGable + "')");
                backWallTextbox.Attributes.Add("onblur", "resetWalls()");
                //backWallTextbox.Attributes.Add("OnFocus", "highlightWallsHeight()");
                backWallTextbox.MaxLength = 3;

                DropDownList backWallInchSpecific = new DropDownList();
                backWallInchSpecific.ID = "backWallInchSpecificDDL";
                backWallInchSpecific.Attributes.Add("onchange", "checkQuestion2('" + isGable + "')");
                backWallInchSpecific.Items.Add(lst0);
                backWallInchSpecific.Items.Add(lst18);
                backWallInchSpecific.Items.Add(lst14);
                backWallInchSpecific.Items.Add(lst38);
                backWallInchSpecific.Items.Add(lst12);
                backWallInchSpecific.Items.Add(lst58);
                backWallInchSpecific.Items.Add(lst34);
                backWallInchSpecific.Items.Add(lst78);

                RadioButton backWallRadioAutoFill = new RadioButton();
                backWallRadioAutoFill.ID = "radAutoBackWallHeight";
                backWallRadioAutoFill.GroupName = "wallHeightsSlopes";

                Label backWallRadioLabel = new Label();
                backWallRadioLabel.ID = "lblRadioBackWallClickable";
                backWallRadioLabel.AssociatedControlID = "radAutoBackWallHeight";

                Label backWallRadioTextLabel = new Label();
                backWallRadioTextLabel.ID = "lblRadioBackWallText";
                backWallRadioTextLabel.AssociatedControlID = "radAutoBackWallHeight";
                backWallRadioTextLabel.Text = "Auto Populate";

                backWallLabel.AssociatedControlID = "txtBackWallHeight";
                #endregion

                #region Table Row # Front Wall Height
                TableRow frontWallHeightRow = new TableRow();
                TableCell frontWallLabelCell = new TableCell();
                TableCell frontWallTextboxCell = new TableCell();
                TableCell frontWallDropDownInchesCell = new TableCell();
                TableCell frontWallRadioAutoFillCell = new TableCell();

                Label frontWallLabel = new Label();
                frontWallLabel.ID = "lblFrontWallHeight";
                frontWallLabel.Text = "Front Wall Height:";

                TextBox frontWallTextbox = new TextBox();
                frontWallTextbox.ID = "txtFrontWallHeight";
                frontWallTextbox.CssClass = "txtField txtInput";
                frontWallTextbox.Attributes.Add("onkeyup", "checkQuestion2('" + isGable + "')");
                frontWallTextbox.Attributes.Add("onblur", "resetWalls()");
                //frontWallTextbox.Attributes.Add("OnFocus", "highlightWallsHeight()");
                frontWallTextbox.MaxLength = 3;

                DropDownList frontWallInchSpecific = new DropDownList();
                frontWallInchSpecific.ID = "frontWallInchSpecificDDL";
                frontWallInchSpecific.Attributes.Add("onchange", "checkQuestion2('" + isGable + "')");
                frontWallInchSpecific.Items.Add(lst0);
                frontWallInchSpecific.Items.Add(lst18);
                frontWallInchSpecific.Items.Add(lst14);
                frontWallInchSpecific.Items.Add(lst38);
                frontWallInchSpecific.Items.Add(lst12);
                frontWallInchSpecific.Items.Add(lst58);
                frontWallInchSpecific.Items.Add(lst34);
                frontWallInchSpecific.Items.Add(lst78);

                RadioButton frontWallRadioAutoFill = new RadioButton();
                frontWallRadioAutoFill.ID = "radAutoFrontWallHeight";
                frontWallRadioAutoFill.GroupName = "wallHeightsSlopes";

                Label frontWallRadioLabel = new Label();
                frontWallRadioLabel.ID = "lblRadioFrontWallClickable";
                frontWallRadioLabel.AssociatedControlID = "radAutoFrontWallHeight";

                Label frontWallRadioTextLabel = new Label();
                frontWallRadioTextLabel.ID = "lblRadioFrontWallText";
                frontWallRadioTextLabel.AssociatedControlID = "radAutoFrontWallHeight";
                frontWallRadioTextLabel.Text = "Auto Populate";

                frontWallLabel.AssociatedControlID = "txtFrontWallHeight";
                #endregion

                #region Table Row # Wall Slope
                TableRow roofSlopeRow = new TableRow();
                TableCell roofSlopeLabelCell = new TableCell();
                TableCell roofSlopeTextboxCell = new TableCell();
                TableCell roofSlopeRunLabelCell = new TableCell();
                TableCell roofSlopeRadioAutoFillCell = new TableCell();

                Label roofSlopeLabel = new Label();
                roofSlopeLabel.ID = "lblRoofSlope";
                roofSlopeLabel.Text = "Roof Slope:";

                TextBox roofSlopeTextbox = new TextBox();
                roofSlopeTextbox.ID = "txtRoofSlope";
                roofSlopeTextbox.CssClass = "txtField txtInput";
                roofSlopeTextbox.Attributes.Add("onkeyup", "checkQuestion2('" + isGable + "')");
                roofSlopeTextbox.Attributes.Add("onblur", "resetWalls()");
                //roofSlopeTextbox.Attributes.Add("OnFocus", "highlightWallsHeight()");
                frontWallTextbox.MaxLength = 6;

                Label roofSlopeRunLabel = new Label();
                roofSlopeRunLabel.ID = "lblWallRunSlope";
                roofSlopeRunLabel.Text = "/12";

                RadioButton roofSlopeRadioAutoFill = new RadioButton();
                roofSlopeRadioAutoFill.ID = "radAutoRoofSlope";
                roofSlopeRadioAutoFill.GroupName = "wallHeightsSlopes";
                roofSlopeRadioAutoFill.Checked = true;

                Label roofSlopeRadioLabel = new Label();
                roofSlopeRadioLabel.ID = "lblRadioRoofSlopeClickable";
                roofSlopeRadioLabel.AssociatedControlID = "radAutoRoofSlope";

                Label roofSlopeRadioTextLabel = new Label();
                roofSlopeRadioTextLabel.ID = "lblRadioRoofSlopeText";
                roofSlopeRadioTextLabel.AssociatedControlID = "radAutoRoofSlope";
                roofSlopeRadioTextLabel.Text = "Auto Populate";

                roofSlopeLabel.AssociatedControlID = "txtRoofSlope";
                #endregion


                #region Table Row # Back Wall Height Added
                backWallLabelCell.Controls.Add(backWallLabel);
                backWallTextboxCell.Controls.Add(backWallTextbox);
                backWallDropDownInchesCell.Controls.Add(backWallInchSpecific);
                backWallRadioAutoFillCell.Controls.Add(backWallRadioAutoFill);
                backWallRadioAutoFillCell.Controls.Add(backWallRadioLabel);
                backWallRadioAutoFillCell.Controls.Add(backWallRadioTextLabel);

                tblWallHeights.Rows.Add(backWallHeightRow);

                backWallHeightRow.Cells.Add(backWallLabelCell);
                backWallHeightRow.Cells.Add(backWallTextboxCell);
                backWallHeightRow.Cells.Add(backWallDropDownInchesCell);
                backWallHeightRow.Cells.Add(backWallRadioAutoFillCell);
                #endregion

                #region Table Row # Front Wall Height Added
                frontWallLabelCell.Controls.Add(frontWallLabel);
                frontWallTextboxCell.Controls.Add(frontWallTextbox);
                frontWallDropDownInchesCell.Controls.Add(frontWallInchSpecific);
                frontWallRadioAutoFillCell.Controls.Add(frontWallRadioAutoFill);
                frontWallRadioAutoFillCell.Controls.Add(frontWallRadioLabel);
                frontWallRadioAutoFillCell.Controls.Add(frontWallRadioTextLabel);

                tblWallHeights.Rows.Add(frontWallHeightRow);

                frontWallHeightRow.Cells.Add(frontWallLabelCell);
                frontWallHeightRow.Cells.Add(frontWallTextboxCell);
                frontWallHeightRow.Cells.Add(frontWallDropDownInchesCell);
                frontWallHeightRow.Cells.Add(frontWallRadioAutoFillCell);
                #endregion

                #region Table Row # Wall Slope Added
                roofSlopeLabelCell.Controls.Add(roofSlopeLabel);
                roofSlopeTextboxCell.Controls.Add(roofSlopeTextbox);
                roofSlopeRunLabelCell.Controls.Add(roofSlopeRunLabel);
                roofSlopeRadioAutoFillCell.Controls.Add(roofSlopeRadioAutoFill);
                roofSlopeRadioAutoFillCell.Controls.Add(roofSlopeRadioLabel);
                roofSlopeRadioAutoFillCell.Controls.Add(roofSlopeRadioTextLabel);

                tblWallHeights.Rows.Add(roofSlopeRow);

                roofSlopeRow.Cells.Add(roofSlopeLabelCell);
                roofSlopeRow.Cells.Add(roofSlopeTextboxCell);
                roofSlopeRow.Cells.Add(roofSlopeRunLabelCell);
                roofSlopeRow.Cells.Add(roofSlopeRadioAutoFillCell);
                #endregion

                string hiddenString = "";
                hiddenString += "<input id=\"hidFrontWallHeight\" type=\"hidden\" runat=\"server\" />";
                hiddenString += "<input id=\"hidBackWallHeight\" type=\"hidden\" runat=\"server\" />";
                hiddenString += "<input id=\"hidRoofSlope\" type=\"hidden\" runat=\"server\" />";

                hiddenFieldsDiv.InnerHtml += hiddenString;
            }
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
            for (int typeCount = 0; typeCount < 4; typeCount++)
            {
                //Conditional operator to set the current door type with the right label
                string title = Constants.DOOR_TYPES[typeCount]; //(typeCount == 1) ? "Cabana" : (typeCount == 2) ? "French" : (typeCount == 3) ? "Patio" : "NoDoor";

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
                if (currentModel == "M100")
                {
                    if (title == "Patio")
                    {
                        for (int j = 0; j < Constants.DOOR_MODEL_100_PATIO_STYLES.Count(); j++)
                        {
                            doorStyleDDL.Items.Add(new ListItem(Constants.DOOR_MODEL_100_PATIO_STYLES[j], Constants.DOOR_MODEL_100_PATIO_STYLES[j]));
                        }
                    }
                    else
                    {
                        for (int j = 0; j < Constants.DOOR_MODEL_100_STYLES.Count(); j++)
                        {
                            doorStyleDDL.Items.Add(new ListItem(Constants.DOOR_MODEL_100_STYLES[j], Constants.DOOR_MODEL_100_STYLES[j]));
                        }
                    }
                }
                else if (currentModel == "M200")
                {
                    if (title == "Patio")
                    {
                        for (int j = 0; j < Constants.DOOR_MODEL_200_300_PATIO_STYLES.Count(); j++)
                        {
                            doorStyleDDL.Items.Add(new ListItem(Constants.DOOR_MODEL_200_300_PATIO_STYLES[j], Constants.DOOR_MODEL_200_300_PATIO_STYLES[j]));
                        }
                    }
                    else
                    {
                        for (int j = 0; j < Constants.DOOR_MODEL_200_STYLES.Count(); j++)
                        {
                            doorStyleDDL.Items.Add(new ListItem(Constants.DOOR_MODEL_200_STYLES[j], Constants.DOOR_MODEL_200_STYLES[j]));
                        }
                    }
                }
                else if (currentModel == "M300")
                {
                    if (title == "Patio")
                    {
                        for (int j = 0; j < Constants.DOOR_MODEL_200_300_PATIO_STYLES.Count(); j++)
                        {
                            doorStyleDDL.Items.Add(new ListItem(Constants.DOOR_MODEL_200_300_PATIO_STYLES[j], Constants.DOOR_MODEL_200_300_PATIO_STYLES[j]));
                        }
                    }
                    else
                    {
                        for (int j = 0; j < Constants.DOOR_MODEL_300_STYLES.Count(); j++)
                        {
                            doorStyleDDL.Items.Add(new ListItem(Constants.DOOR_MODEL_300_STYLES[j], Constants.DOOR_MODEL_300_STYLES[j]));
                        }
                    }
                }
                else if (currentModel == "M400")
                {
                    if (title == "Patio")
                    {
                        for (int j = 0; j < Constants.DOOR_MODEL_400_PATIO_STYLES.Count(); j++)
                        {
                            doorStyleDDL.Items.Add(new ListItem(Constants.DOOR_MODEL_400_PATIO_STYLES[j], Constants.DOOR_MODEL_400_PATIO_STYLES[j]));
                        }
                    }
                    else
                    {
                        for (int j = 0; j < Constants.DOOR_MODEL_400_STYLES.Count(); j++)
                        {
                            doorStyleDDL.Items.Add(new ListItem(Constants.DOOR_MODEL_400_STYLES[j], Constants.DOOR_MODEL_400_STYLES[j]));
                        }
                    }
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
                for (int j = 0; j < Constants.DOOR_V4T_VINYL_OPTIONS.Count(); j++)
                {
                    doorVinylTintDDL.Items.Add(new ListItem(Constants.DOOR_V4T_VINYL_OPTIONS[j], Constants.DOOR_V4T_VINYL_OPTIONS[j]));
                }

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
                for (int j = 0; j < Constants.DOOR_NUMBER_OF_VENTS.Count(); j++)
                {
                    doorNumberOfVentsDDL.Items.Add(new ListItem(Constants.DOOR_NUMBER_OF_VENTS[j], Constants.DOOR_NUMBER_OF_VENTS[j]));
                }

                doorNumberOfVentsLBL.AssociatedControlID = "ddlDoorNumberOfVents" + i + title;

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
                for (int j = 0; j < Constants.VINYL_TINTS.Count(); j++)
                {
                    doorTransomVinylDDL.Items.Add(new ListItem(Constants.VINYL_TINTS[j], Constants.VINYL_TINTS[j]));
                }

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
                for (int j = 0; j < Constants.TRANSOM_GLASS_TINTS.Count(); j++)
                {
                    doorTransomGlassDDL.Items.Add(new ListItem(Constants.TRANSOM_GLASS_TINTS[j], Constants.TRANSOM_GLASS_TINTS[j]));
                }

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

                TableRow colourOfDoorRow = new TableRow();
                colourOfDoorRow.ID = "rowDoorColour" + i + title;
                colourOfDoorRow.Attributes.Add("style", "display:none;");
                TableCell colourOfDoorLBLCell = new TableCell();
                TableCell colourOfDoorDDLCell = new TableCell();

                Label colourOfDoorLBL = new Label();
                colourOfDoorLBL.ID = "lblDoorColour" + i + title;
                colourOfDoorLBL.Text = "Colour:";

                DropDownList colourOfDoorDDL = new DropDownList();
                colourOfDoorDDL.ID = "ddlDoorColour" + i + title;
                for (int j = 0; j < Constants.DOOR_COLOURS.Count(); j++)
                {
                    colourOfDoorDDL.Items.Add(new ListItem(Constants.DOOR_COLOURS[j], Constants.DOOR_COLOURS[j]));
                }

                colourOfDoorLBL.AssociatedControlID = "ddlDoorColour" + i + title;

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
                            if (currentModel == "M400" && Constants.DOOR_WIDTHS_PATIO[j] != "7")
                            {
                                //Do nothing, no 7' for patio doors
                            }
                            else {
                                doorWidthDDL.Items.Add(new ListItem(Constants.DOOR_WIDTHS_PATIO[j] + "\'", Convert.ToString((Convert.ToInt32(Constants.DOOR_WIDTHS_PATIO[j])*12))));
                            }
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
                doorOperatorLHHRad.Attributes.Add("value", "Left");
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
                doorOperatorRHHRad.Attributes.Add("value", "Right");
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
                for (int j = 0; j < Constants.DOOR_BOXHEADER_POSITION.Count(); j++)
                {
                    doorBoxHeaderDDL.Items.Add(new ListItem(Constants.DOOR_BOXHEADER_POSITION[j], Constants.DOOR_BOXHEADER_POSITION[j]));
                }

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
                for (int j = 0; j < Constants.DOOR_GLASS_TINTS.Count(); j++)
                {
                    doorGlassTintDDL.Items.Add(new ListItem(Constants.DOOR_GLASS_TINTS[j], Constants.DOOR_GLASS_TINTS[j]));
                }

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
                doorHingeLHHRad.Attributes.Add("value", "Left");
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
                doorHingeRHHRad.Attributes.Add("value", "Right");
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
                for (int j = 0; j < Constants.SCREEN_TYPES.Count(); j++)
                {
                    doorScreenOptionsDDL.Items.Add(new ListItem(Constants.SCREEN_TYPES[j], Constants.SCREEN_TYPES[j]));
                }

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
                for (int j = 0; j < Constants.DOOR_HARDWARE.Count(); j++)
                {
                    doorHardwareDDL.Items.Add(new ListItem(Constants.DOOR_HARDWARE[j], Constants.DOOR_HARDWARE[j]));
                }

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
                doorSwingInRAD.Attributes.Add("value", "In");
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
                doorSwingOutRAD.Attributes.Add("value", "Out");
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
                (windowTypeId == "DoubleSlider" && currentModel == "M300") ? true : //select/check the radio button if current selection is default value
                (windowTypeId == "SingleSlider" && currentModel == "M400") ? true : false; //select/check the radio button if current selection is default value

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
            screenOptions();
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
            v4tOptions();
            horizontalRollerOptions();
            fixedVinylOptions();
            openWall();
            solidWall();
            screenOptions();

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
            doubleSliderOptions();
            fixedGlassOptions();
            openWall();
            solidWall();
            screenOptions();

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
            singleSliderOptions();
            fixedGlassOptions();
            openWall();
            solidWall();

            windowFramingColourOptions(false);
        }

        /// <summary>
        /// screen type (better vue insect screen, No See Ums 20x20 Mesh, Solar Insect Screening, Tuff Screen, No Screen)
        /// </summary>
        protected void screenOptions()
        {
            RadioButton screenRadio, typeRadio;
            Label screenLabelRadio, screenLabel, typeLabelRadio, typeLabel;

            

            wallWindowOptions.Controls.Add(new LiteralControl("<li>"));

            //RadioButton created for every option
            screenRadio = new RadioButton();
            screenRadio.ID = "radScreen";     //Giving an appropriate id to radio buttons based on current type of window
            
            if (currentModel == "M100")
            {
                screenRadio.GroupName = "windowTypeRadios";     //Giving an appropriate group name to all windowtype radio buttons
                screenRadio.Checked = true;// (currentModel == "M100") ? true : false; //select/check the radio button if current selection is default value
            }
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

            if (currentModel != "M100")
            {
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
            }
            ////////////////////////////////////////////////

            wallWindowOptions.Controls.Add(new LiteralControl("</ul></li></ul></div></li>"));

        }

        /// <summary>
        /// - V4T tints (clear, smoke grey, dark grey, bronze, Mixed)
        /// </summary>
        protected void v4tOptions()
        {
            tintOptions("V4T", "Vertical 4 Track", false, true, true, true, true);
        }

        /// <summary>
        /// H2T (vinyl) tints (clear, smoke grey, dark grey, bronze)
        /// </summary>
        protected void horizontalRollerOptions()
        {
            tintOptions("HorizontalRoller", "Horizontal Roller", false, true, true, true);
        }

        /// <summary>
        /// fixed window tints (clear, smoke grey, dark grey, bronze)
        /// </summary>
        protected void fixedVinylOptions()
        {
            tintOptions("FixedVinyl", "Fixed Vinyl", false, true, true, true);
        }

        /// <summary>
        /// glass tint (grey, bronze, clear)
        /// </summary>
        protected void doubleSliderOptions()
        {
            tintOptions("DoubleSlider", "Double Slider", true, false, false, true);
        }

        /// <summary>
        /// fixed glass window tints (grey, bronze, clear)
        /// </summary>
        protected void fixedGlassOptions()
        {
            tintOptions("FixedGlass", "Fixed Glass", true, false, false, true);
        }

        /// <summary>
        /// glass tint (grey, bronze, clear)
        /// </summary>
        protected void singleSliderOptions()
        {
            tintOptions("SingleSlider", "Single Slider", true, false, false, true);
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
                html += "<input id=\"hidWall" + i + "Slope\" type=\"hidden\" runat=\"server\" />"; //hidden field for wall slope


                //html += "<div id=\"hidWall" + i + "Length\" style=\"display: none;\" runat=\"server\" />"; //hidden field for wall length
                //html += "<div id=\"hidWall" + i + "LeftFiller\" style=\"display: none;\" runat=\"server\" />"; //hidden field for wall left filler
                //html += "<div id=\"hidWall" + i + "RightFiller\" style=\"display: none;\" runat=\"server\" />"; //hidden field for wall right filler
                //html += "<div id=\"hidWall" + i + "SetBack\" style=\"display: none;\" runat=\"server\" />"; //hidden field for wall setback
                //html += "<div id=\"hidWall" + i + "SoffitLength\" style=\"display: none;\" runat=\"server\" />"; //hidden field for wall soffit length
                //html += "<div id=\"hidWall" + i + "StartHeight\" style=\"display: none;\" runat=\"server\" />"; //hidden field for wall start height
                //html += "<div id=\"hidWall" + i + "EndHeight\" style=\"display: none;\" runat=\"server\" />"; //hidden field for wall end height
                //html += "<input id=\"hidWall" + i + "Slope\" type=\"hidden\" runat=\"server\" />"; //hidden field for wall slope
                
            }
            return html; //return the hidden field tags
        }

        ///// <summary>
        ///// This is an event, that is used to dynamically create wall objects with the appropriate details
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void createWallObjects(object sender, EventArgs e)
        //{

        //    //there are issues with getting values from dynamically generated hidden fields
        //    //hard coded hidden fields work fine...
            
        //    //need to dynamically determine slope, and soffit length of each wall and store it in hidden fields

        //    float length, startHeight, endHeight, soffit;//, slope;
        //    string orientation, name, type, model;
        //    HiddenField wallLength, wallSoffit;
        //    for (int i = 0; i < strWalls.Count(); i++)
        //    {
        //        //find and store the dynamically created hidden fields
        //        wallLength = hiddenFieldsDiv.FindControl("hidWall" + i + "Length") as HiddenField; //wall length
        //        wallSoffit = hiddenFieldsDiv.FindControl("hidWall" + i + "SoffitLength") as HiddenField; //wall soffit length

                

        //        //length = wallLength.Value;
        //        //startHeight = Convert.ToSingle(hidHeight.Value);
        //        //endHeight = Convert.ToSingle(hidFrontWallHeight.Value);
        //        //soffit = Convert.ToSingle(wallSoffit.Value);
        //       // slope = Convert.ToSingle(hidRoofSlope.Value);

        //        orientation = wallDetails[i, 5];
        //        name = "wall " + i;
        //        type = wallDetails[i, 4];
        //        model = currentModel;

        //        //string sof = wallSoffit.Value;
        //        //create a wall object with the appropriate values in the fields and attributes of it and add it to the walls list
        //        //walls.Add(new Wall(Convert.ToSingle(wallLength.Value), wallDetails[i, 5], "Wall" + i, wallDetails[i, 4], Convert.ToSingle(hidBackWallHeight.Value), Convert.ToSingle(hidBackWallHeight.Value), /*Convert.ToSingle(wallSoffit.Value)*/ 0F, currentModel));
        //    }
        //}

        protected void btnQuestion4_Click(object sender, EventArgs e)
        {

            int wallCount = Convert.ToInt32(Request.Form["wallCount"]);
            int wallStartIndex = Convert.ToInt32(Request.Form["wallStartIndex"]);

            for (int walls = wallStartIndex; walls <= wallCount; walls++) {

                int doorCount = Convert.ToInt32(Request.Form["wall" + walls + "DoorCount"]);
                Session["Wall" + walls + "DoorCount" + walls] = Request.Form["wall" + walls + "DoorCount"];
                Door aDoor;

                for (int doors = 0; doors < doorCount; doors++) {

                    string doorType = Request.Form["wall" + walls + "Door" + doors + "type"];

                    aDoor = new Door();

                    if (doorType == "Cabana")
                    {
                        aDoor = new CabanaDoor();
                        
                        CabanaDoor newCabana = (CabanaDoor)aDoor;

                        newCabana.Height = Convert.ToSingle(Request.Form["wall" + walls + "Door" + doors + "Height"]);
                        newCabana.Length = Convert.ToSingle(Request.Form["wall" + walls + "Door" + doors + "Width"]);
                        newCabana.VinylTint = Request.Form["wall" + walls + "Door" + doors + "VinylTint"];
                        newCabana.ScreenType = Request.Form["wall" + walls + "Door" + doors + "ScreenOptions"];
                        newCabana.GlassTint = Request.Form["wall" + walls + "Door" + doors + "GlassTint"];
                        newCabana.Hinge = Request.Form["wall" + walls + "Door" + doors + "Hinge"];
                        newCabana.Swing = Request.Form["wall" + walls + "Door" + doors + "Swing"];
                        newCabana.HardwareType = Request.Form["wall" + walls + "Door" + doors + "Hardware"];
                    }
                    else if (doorType == "French")
                    {
                        aDoor = new FrenchDoor();

                        FrenchDoor newFrench = (FrenchDoor)aDoor;

                        newFrench.Height = Convert.ToSingle(Request.Form["wall" + walls + "Door" + doors + "Height"]);
                        newFrench.Length = Convert.ToSingle(Request.Form["wall" + walls + "Door" + doors + "Width"]);
                        newFrench.VinylTint = Request.Form["wall" + walls + "Door" + doors + "VinylTint"];
                        newFrench.ScreenType = Request.Form["wall" + walls + "Door" + doors + "ScreenOptions"];
                        newFrench.GlassTint = Request.Form["wall" + walls + "Door" + doors + "GlassTint"];
                        newFrench.Swing = Request.Form["wall" + walls + "Door" + doors + "Swing"];
                        newFrench.OperatingDoor = Request.Form["wall" + walls + "Door" + doors + "Operator"];
                        newFrench.HardwareType = Request.Form["wall" + walls + "Door" + doors + "Hardware"];
                    }
                    else if (doorType == "Patio")
                    {
                        aDoor = new PatioDoor();

                        PatioDoor newPatio = (PatioDoor)aDoor;

                        newPatio.Height = Convert.ToSingle(Request.Form["wall" + walls + "Door" + doors + "Height"]);
                        newPatio.Length = Convert.ToSingle(Request.Form["wall" + walls + "Door" + doors + "Width"]);
                        newPatio.ScreenType = Request.Form["wall" + walls + "Door" + doors + "ScreenOptions"];
                        newPatio.GlassTint = Request.Form["wall" + walls + "Door" + doors + "GlassTint"];
                        newPatio.MovingDoor = Request.Form["wall" + walls + "Door" + doors + "Operator"];
                    }
                    else
                    {
                        aDoor = new OpenSpaceDoor();

                        OpenSpaceDoor newOpenSpace = (OpenSpaceDoor)aDoor;

                        newOpenSpace.Height = Convert.ToSingle(Request.Form["wall" + walls + "Door" + doors + "Height"]);
                        newOpenSpace.Length = Convert.ToSingle(Request.Form["wall" + walls + "Door" + doors + "Width"]);
                    }

                    //Load all properties
                    aDoor.DoorType = doorType;
                    aDoor.DoorStyle = Request.Form["wall" + walls + "Door" + doors + "Style"];
                    aDoor.ScreenType = Request.Form["wall" + walls + "Door" + doors + "ScreenOptions"];
                    aDoor.FHeight = Convert.ToSingle(Request.Form["wall" + walls + "Door" + doors + "FHeight"]);
                    aDoor.FLength = Convert.ToSingle(Request.Form["wall" + walls + "Door" + doors + "FWidth"]);                    
                    aDoor.Colour = Request.Form["wall" + walls + "Door" + doors + "Colour"];
                    System.Diagnostics.Debug.WriteLine("This colour is: " + Request.Form["wall" + walls + "Door" + doors + "Colour"]);
                    aDoor.Kickplate = Convert.ToSingle(Request.Form["wall" + walls + "Door" + doors + "Kickplate"]);

                    Session["Wall" + walls + "Door" + doors] = aDoor;
                }
            }

            Session.Add("sunroomProjection", hidRoomProjection.Value);
            Session.Add("sunroomWidth", hidRoomWidth.Value);
            Response.Redirect("TestingHiddens.aspx");

        }
    }
}
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
        protected const float DOOR_MAX_WIDTH = Constants.CUSTOM_DOOR_MAX_WIDTH;
        protected const float DOOR_MIN_WIDTH = Constants.CUSTOM_DOOR_MIN_WIDTH;
        protected const float DOOR_FRENCH_MIN_WIDTH = Constants.CUSTOM_FRENCH_DOOR_MIN_WIDTH;
        protected const float DOOR_FRENCH_MAX_WIDTH = Constants.CUSTOM_FRENCH_DOOR_MAX_WIDTH;

        protected ListItem lst0 = new ListItem("---", "", true);
        protected ListItem lst18 = new ListItem("1/8", ".125");
        protected ListItem lst14 = new ListItem("1/4", ".25");
        protected ListItem lst38 = new ListItem("3/8", ".375");
        protected ListItem lst12 = new ListItem("1/2", ".5");
        protected ListItem lst58 = new ListItem("5/8", ".625");
        protected ListItem lst34 = new ListItem("3/4", ".75");
        protected ListItem lst78 = new ListItem("7/8", ".875");
        protected int currentModel = 200;

        protected void Page_Load(object sender, EventArgs e)
        {
            /***hard coded session variables***/
            
            Session["numberOfWalls"] = 4;
            //Session["numberOfWalls"] = 4;
            //Session["coordList"] = "100,412.5,137.5,137.5,E,S/150,150,137.5,287.5,P,W/150,225,287.5,362.5,P,SW/225,312.5,362.5,362.5,P,S/312,387.5,362.5,287.5,P,SE/387.5,387.5,287.5,137.5,P,E/";
            Session["coordList"] = "112.5,350,112.5,112.5,E,S/350,350,112.5,337.5,E,W/175,175,112.5,262.5,P,W/175,350,262.5,262.5,P,S/";
            string coordList = (string)Session["coordList"];                                    
            char[] lineDelimiter = { '/' };   
            char[] detailsDelimiter = { ',' };                                 
            string[] walls = coordList.Split(lineDelimiter, StringSplitOptions.RemoveEmptyEntries);
            string[,] wallDetails = new string[walls.Count(),6];
            //Dictionary<string, string>[] wallDetails = new Dictionary<string, string>[]{};
            int existingWallCount = 0;
            int proposedWallCount = 0;
            string[] tempDetails;

            for (int i = 0; i < walls.Count(); i++) //populate the array with all the wall details for each wall
            {
                tempDetails = walls[i].Split(detailsDelimiter, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < tempDetails.Count(); j++)
                {
                wallDetails[i, j] = tempDetails[j];
                //wallDetails[i] = new Dictionary<string, string>(); //trying associative array/dictionary
                
                //wallDetails[i].Add("x1", tempDetails[0]);
                //wallDetails[i].Add("x2", tempDetails[1]);
                //wallDetails[i].Add("y1", tempDetails[2]);
                //wallDetails[i].Add("y2", tempDetails[3]);
                //wallDetails[i].Add("type", tempDetails[4]);
                //wallDetails[i].Add("orientation", tempDetails[5]);
                }
            }
            /**********************************/
            hiddenFieldsDiv.InnerHtml = createHiddenFields(walls.Count()); //create hidden fields on page load dynamically, pass it number of walls

            #region DropDownList Section
            DropDownList ddlInFrac = new DropDownList();
            DropDownList ddlInFracBackWall = new DropDownList();
            DropDownList ddlInFracFrontWall = new DropDownList();

            //ListItem lst0 = new ListItem("---", "", true);
            //ListItem lst18 = new ListItem("1/8", ".125");
            //ListItem lst14 = new ListItem("1/4", ".25");
            //ListItem lst38 = new ListItem("3/8", ".375");
            //ListItem lst12 = new ListItem("1/2", ".5");
            //ListItem lst58 = new ListItem("5/8", ".625");
            //ListItem lst34 = new ListItem("3/4", ".75");
            //ListItem lst78 = new ListItem("7/8", ".875");


            ddlInFrac.Items.Add(lst0);
            ddlInFrac.Items.Add(lst18);
            ddlInFrac.Items.Add(lst14);
            ddlInFrac.Items.Add(lst38);
            ddlInFrac.Items.Add(lst12);
            ddlInFrac.Items.Add(lst58);
            ddlInFrac.Items.Add(lst34);
            ddlInFrac.Items.Add(lst78);
            
            ddlInFracBackWall.Items.Add(lst0);
            ddlInFracBackWall.Items.Add(lst18);
            ddlInFracBackWall.Items.Add(lst14);
            ddlInFracBackWall.Items.Add(lst38);
            ddlInFracBackWall.Items.Add(lst12);
            ddlInFracBackWall.Items.Add(lst58);
            ddlInFracBackWall.Items.Add(lst34);
            ddlInFracBackWall.Items.Add(lst78);
            ddlInFracBackWall.ID = "ddlBackInchFractions";
            ddlInFracBackWall.Attributes.Add("onchange", "checkQuestion2()");
            phBackHeights.Controls.Add(ddlInFracBackWall);

            ddlInFracFrontWall.Items.Add(lst0);
            ddlInFracFrontWall.Items.Add(lst18);
            ddlInFracFrontWall.Items.Add(lst14);
            ddlInFracFrontWall.Items.Add(lst38);
            ddlInFracFrontWall.Items.Add(lst12);
            ddlInFracFrontWall.Items.Add(lst58);
            ddlInFracFrontWall.Items.Add(lst34);
            ddlInFracFrontWall.Items.Add(lst78);
            ddlInFracFrontWall.ID = "ddlFrontInchFractions";
            ddlInFracFrontWall.Attributes.Add("onchange", "checkQuestion2()");
            phFrontHeights.Controls.Add(ddlInFracFrontWall);
            #endregion

            //SLIDE 3 DOOR DETAILS PER WALL
            #region Slide 3: Onload dynamic loop to insert wall door options            

            for (int currentWall = 1; currentWall <= walls.Count(); currentWall++) //numberOfWalls is hard-coded to be 4 right now
            {
                #region Wall #:Radio button section
                wallDoorOptions.Controls.Add(new LiteralControl("<li>"));

                RadioButton wallRadio = new RadioButton();
                wallRadio.ID = "radWall" + currentWall;
                wallRadio.GroupName = "doorWallRadios";

                Label wallLabelRadio = new Label();
                wallLabelRadio.AssociatedControlID = "radWall" + currentWall;

                Label wallLabel = new Label();
                wallLabel.AssociatedControlID = "radWall" + currentWall;
                wallLabel.Text = "Wall " + currentWall + " Door Options";

                wallDoorOptions.Controls.Add(wallRadio);
                wallDoorOptions.Controls.Add(wallLabelRadio);
                wallDoorOptions.Controls.Add(wallLabel);

                wallDoorOptions.Controls.Add(new LiteralControl("<div id='doorDetails' class='toggleContent'>"));

                //wallDoorOptions.Controls.Add(new LiteralControl("<button type='button' class='btnSubmit' onclick='onClickAddDoor(" + currentWall + ")'>Add Door To This Wall:</button>"));

                wallDoorOptions.Controls.Add(new LiteralControl("<ul><li><ul id='doorDetailsList' class='toggleOptions'>"));

                #endregion

                #region Loop to display door types as radio buttons

                for (int typeCount = 1; typeCount <= 4; typeCount++)
                {
                    string title = (typeCount == 1) ? "Cabana" : (typeCount == 2) ? "French" : (typeCount == 3) ? "Patio" : "Opening Only (No Door)";

                    if (currentModel == 400 && title == "French")
                    {
                        //Do nothing
                    }
                    else{
                        wallDoorOptions.Controls.Add(new LiteralControl("<li>"));

                        RadioButton typeRadio = new RadioButton();
                        typeRadio.ID = "radType" + currentWall + title;
                        typeRadio.GroupName = "doorTypeRadios";
                        typeRadio.Attributes.Add("onclick", "checkQuestion3()");

                        Label typeLabelRadio = new Label();
                        typeLabelRadio.AssociatedControlID = "radType" + currentWall + title;

                        Label typeLabel = new Label();
                        typeLabel.AssociatedControlID = "radType" + currentWall + title;
                        typeLabel.Text = title;

                        wallDoorOptions.Controls.Add(typeRadio);
                        wallDoorOptions.Controls.Add(typeLabelRadio);
                        wallDoorOptions.Controls.Add(typeLabel);

                        Table tblDoorDetails = new Table();

                        tblDoorDetails.ID = "tblDoorDetails";
                        tblDoorDetails.CssClass = "tblTextFields";
                        tblDoorDetails.Attributes.Add("runat", "server");

                        //Creating cells and controls for rows

                        #region Table:Default Row Title Current Door (tblDoorDetails)

                        TableRow doorTitleRow = new TableRow();
                        doorTitleRow.ID = "rowDoorTitle" + currentWall + title;
                        doorTitleRow.Attributes.Add("style", "display:none;");
                        TableCell doorTitleLBLCell = new TableCell();

                        Label doorTitleLBL = new Label();
                        doorTitleLBL.ID = "lblDoorTitle" + currentWall + title;
                        doorTitleLBL.Text = "Select door details:";
                        doorTitleLBL.Attributes.Add("style", "font-weight:bold;");

                        #endregion

                        #region Table:Second Row Door Style (tblDoorDetails)

                        TableRow doorStyleRow = new TableRow();
                        doorStyleRow.ID = "rowDoorStyle" + currentWall + title;
                        doorStyleRow.Attributes.Add("style", "display:none;");
                        TableCell doorStyleLBLCell = new TableCell();
                        TableCell doorStyleDDLCell = new TableCell();

                        Label doorStyleLBL = new Label();
                        doorStyleLBL.ID = "lblDoorStyle" + currentWall + title;
                        doorStyleLBL.Text = "Door Style";

                        DropDownList doorStyleDDL = new DropDownList();
                        doorStyleDDL.ID = "ddlDoorStyle" + currentWall + title;
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
                        if (currentModel == 100)
                        {
                            doorStyleDDL.Items.Add(fullScreen);
                            doorStyleDDL.Items.Add(v4TCabana);
                        }
                        else if (currentModel == 200)
                        {
                            doorStyleDDL.Items.Add(fullScreen);
                            doorStyleDDL.Items.Add(v4TCabana);
                            doorStyleDDL.Items.Add(fullView);
                        }
                        else if (currentModel == 300)
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
                        

                        #endregion

                        #region Table:Sixteenth Row Door V4T Vinyl Tint (tblDoorDetails)

                        TableRow doorVinylTintRow = new TableRow();
                        doorVinylTintRow.ID = "rowDoorVinylTint" + currentWall + title;
                        doorVinylTintRow.Attributes.Add("style", "display:none;");
                        TableCell doorVinylTintLBLCell = new TableCell();
                        TableCell doorVinylTintDDLCell = new TableCell();

                        Label doorVinylTintLBL = new Label();
                        doorVinylTintLBL.ID = "lblDoorVinylTint" + currentWall + title;
                        doorVinylTintLBL.Text = "Door Vinyl Tint:";

                        DropDownList doorVinylTintDDL = new DropDownList();
                        doorVinylTintDDL.ID = "ddlVinylTint" + currentWall + title;
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

                        #endregion

                        #region Table:Third Row Color of Door (tblDoorDetails)

                        TableRow colorOfDoorRow = new TableRow();
                        colorOfDoorRow.ID = "rowDoorColor" + currentWall + title;
                        colorOfDoorRow.Attributes.Add("style", "display:none;");
                        TableCell colorOfDoorLBLCell = new TableCell();
                        TableCell colorOfDoorDDLCell = new TableCell();

                        Label colorOfDoorLBL = new Label();
                        colorOfDoorLBL.ID = "lblDoorColor" + currentWall + title;
                        colorOfDoorLBL.Text = "Door Color:";

                        DropDownList colorOfDoorDDL = new DropDownList();
                        colorOfDoorDDL.ID = "ddlDoorColor" + currentWall + title;
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

                        colorOfDoorLBL.AssociatedControlID = "ddlDoorColor" + currentWall + title;

                        #endregion

                        #region Table:Fourth Row Door Height (tblDoorDetails)

                        TableRow doorHeightRow = new TableRow();
                        doorHeightRow.ID = "rowDoorHeight" + currentWall + title;
                        doorHeightRow.Attributes.Add("style", "display:none;");
                        TableCell doorHeightLBLCell = new TableCell();
                        TableCell doorHeightDDLCell = new TableCell();

                        Label doorHeightLBL = new Label();
                        doorHeightLBL.ID = "lblDoorHeight" + currentWall + title;
                        doorHeightLBL.Text = "Height:";

                        DropDownList doorHeightDDL = new DropDownList();
                        doorHeightDDL.ID = "ddlDoorHeight" + currentWall + title;
                        doorHeightDDL.Attributes.Add("onchange", "customDimension('" + title + "','Height')");
                        ListItem eighty = new ListItem("80\" (Default)", "80");
                        ListItem customHeight = new ListItem("Custom", "cHeight");
                        doorHeightDDL.Items.Add(eighty);
                        doorHeightDDL.Items.Add(customHeight);

                        doorHeightLBL.AssociatedControlID = "ddlDoorHeight" + currentWall + title;

                        #endregion

                        #region Table:Sixth Row Door Custom Height (tblDoorDetails)

                        TableRow doorCustomHeightRow = new TableRow();
                        doorCustomHeightRow.ID = "rowDoorCustomHeight" + currentWall + title;
                        doorCustomHeightRow.Attributes.Add("style", "display:none;");
                        TableCell doorCustomHeightLBLCell = new TableCell();
                        TableCell doorCustomHeightTXTCell = new TableCell();
                        TableCell doorCustomHeightDDLCell = new TableCell();

                        Label doorCustomHeightLBL = new Label();
                        doorCustomHeightLBL.ID = "lblDoorCustomHeight" + currentWall + title;
                        doorCustomHeightLBL.Text = "Custom Height (inches):";

                        TextBox doorCustomHeightTXT = new TextBox();
                        doorCustomHeightTXT.ID = "txtDoorCustomHeight" + currentWall + title;
                        doorCustomHeightTXT.CssClass = "txtField txtDoorInput";

                        DropDownList inchCustomHeight = new DropDownList();
                        inchCustomHeight.ID = "ddlInchCustomHeight" + currentWall + title;
                        inchCustomHeight.Items.Add(lst0);
                        inchCustomHeight.Items.Add(lst18);
                        inchCustomHeight.Items.Add(lst14);
                        inchCustomHeight.Items.Add(lst38);
                        inchCustomHeight.Items.Add(lst12);
                        inchCustomHeight.Items.Add(lst58);
                        inchCustomHeight.Items.Add(lst34);
                        inchCustomHeight.Items.Add(lst78);

                        doorCustomHeightLBL.AssociatedControlID = "txtDoorCustomHeight" + currentWall + title;

                        #endregion

                        #region Table:Fifth Row Door Width (tblDoorDetails)

                        TableRow doorWidthRow = new TableRow();
                        doorWidthRow.ID = "rowDoorWidth" + currentWall + title;
                        doorWidthRow.Attributes.Add("style", "display:none;");
                        TableCell doorWidthLBLCell = new TableCell();
                        TableCell doorWidthDDLCell = new TableCell();

                        Label doorWidthLBL = new Label();
                        doorWidthLBL.ID = "lblDoorWidth" + currentWall + title;
                        doorWidthLBL.Text = "Width:";

                        DropDownList doorWidthDDL = new DropDownList();
                        doorWidthDDL.ID = "ddlDoorWidth" + currentWall + title;
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

                        doorWidthLBL.AssociatedControlID = "ddlDoorWidth" + currentWall + title;

                        #endregion

                        #region Table:Seventh Row Door Custom Width (tblDoorDetails)

                        TableRow doorCustomWidthRow = new TableRow();
                        doorCustomWidthRow.ID = "rowDoorCustomWidth" + currentWall + title;
                        doorCustomWidthRow.Attributes.Add("style", "display:none;");
                        TableCell doorCustomWidthLBLCell = new TableCell();
                        TableCell doorCustomWidthTXTCell = new TableCell();
                        TableCell doorCustomWidthDDLCell = new TableCell();

                        Label doorCustomWidthLBL = new Label();
                        doorCustomWidthLBL.ID = "lblDoorCustomWidth" + currentWall + title;
                        doorCustomWidthLBL.Text = "Custom Width (inches):";

                        TextBox doorCustomWidthTXT = new TextBox();
                        doorCustomWidthTXT.ID = "txtDoorCustomWidth" + currentWall + title;
                        doorCustomWidthTXT.CssClass = "txtField txtDoorInput";

                        DropDownList inchCustomWidth = new DropDownList();
                        inchCustomWidth.ID = "ddlInchCustomWidth" + currentWall + title;
                        inchCustomWidth.Items.Add(lst0);
                        inchCustomWidth.Items.Add(lst18);
                        inchCustomWidth.Items.Add(lst14);
                        inchCustomWidth.Items.Add(lst38);
                        inchCustomWidth.Items.Add(lst12);
                        inchCustomWidth.Items.Add(lst58);
                        inchCustomWidth.Items.Add(lst34);
                        inchCustomWidth.Items.Add(lst78);

                        doorCustomWidthLBL.AssociatedControlID = "txtDoorCustomWidth" + currentWall + title;

                        #endregion

                        #region Table:Eight Row Door Primary Operator LHH (tblDoorDetails)

                        TableRow doorOperatorLHHRow = new TableRow();
                        doorOperatorLHHRow.ID = "rowDoorOperatorLHH" + currentWall + title;
                        doorOperatorLHHRow.Attributes.Add("style", "display:none;");
                        TableCell doorOperatorLHHLBLCell = new TableCell();
                        TableCell doorOperatorLHHRADCell = new TableCell();

                        Label doorOperatorLHHLBLMain = new Label();
                        doorOperatorLHHLBLMain.ID = "lblDoorOperatorLHHMain" + currentWall + title;
                        doorOperatorLHHLBLMain.Text = "Primary Operator:";

                        Label doorOperatorLHHLBLRad = new Label();
                        doorOperatorLHHLBLRad.ID = "lblDoorOperatorRadLHH" + currentWall + title;

                        Label doorOperatorLHHLBL = new Label();
                        doorOperatorLHHLBL.ID = "lblDoorOperatorLHH" + currentWall + title;
                        doorOperatorLHHLBL.Text = "LHH";

                        RadioButton doorOperatorLHHRad = new RadioButton();
                        doorOperatorLHHRad.ID = "radDoorOperatorLHH" + currentWall + title;
                        doorOperatorLHHRad.GroupName = "PrimaryOperator";

                        doorOperatorLHHLBLRad.AssociatedControlID = "radDoorOperatorLHH" + currentWall + title;
                        doorOperatorLHHLBL.AssociatedControlID = "radDoorOperatorLHH" + currentWall + title;

                        #endregion

                        #region Table:Ninth Row Door Primary Operator RHH (tblDoorDetails)

                        TableRow doorOperatorRHHRow = new TableRow();
                        doorOperatorRHHRow.ID = "rowDoorOperatorRHH" + currentWall + title;
                        doorOperatorRHHRow.Attributes.Add("style", "display:none;");
                        TableCell doorOperatorRHHLBLCell = new TableCell();
                        TableCell doorOperatorRHHRADCell = new TableCell();

                        Label doorOperatorRHHLBLRad = new Label();
                        doorOperatorRHHLBLRad.ID = "lblDoorOperatorRadRHH" + currentWall + title;

                        Label doorOperatorRHHLBL = new Label();
                        doorOperatorRHHLBL.ID = "lblDoorOperatorRHH" + currentWall + title;
                        doorOperatorRHHLBL.Text = "RHH";

                        RadioButton doorOperatorRHHRad = new RadioButton();
                        doorOperatorRHHRad.ID = "radDoorOperatorRHH" + currentWall + title;
                        doorOperatorRHHRad.GroupName = "PrimaryOperator";

                        doorOperatorRHHLBLRad.AssociatedControlID = "radDoorOperatorRHH" + currentWall + title;
                        doorOperatorRHHLBL.AssociatedControlID = "radDoorOperatorRHH" + currentWall + title;

                        #endregion

                        #region Table:Tenth Row Door Box Header LHH (tblDoorDetails)

                        TableRow doorBoxHeaderLHHRow = new TableRow();
                        doorBoxHeaderLHHRow.ID = "rowDoorBoxHeaderLHH" + currentWall + title;
                        doorBoxHeaderLHHRow.Attributes.Add("style", "display:none;");
                        TableCell doorBoxHeaderLHHLBLCell = new TableCell();
                        TableCell doorBoxHeaderLHHRADCell = new TableCell();

                        Label doorBoxHeaderLHHLBLMain = new Label();
                        doorBoxHeaderLHHLBLMain.ID = "lblDoorBoxHeaderLHHMain" + currentWall + title;
                        doorBoxHeaderLHHLBLMain.Text = "Box Header Position:";

                        Label doorBoxHeaderLHHLBLRad = new Label();
                        doorBoxHeaderLHHLBLRad.ID = "lblDoorBoxHeaderRadLHH" + currentWall + title;

                        Label doorBoxHeaderLHHLBL = new Label();
                        doorBoxHeaderLHHLBL.ID = "lblDoorBoxHeaderLHH" + currentWall + title;
                        doorBoxHeaderLHHLBL.Text = "LHH";

                        RadioButton doorBoxHeaderLHHRad = new RadioButton();
                        doorBoxHeaderLHHRad.ID = "radDoorBoxHeaderLHH" + currentWall + title;
                        doorBoxHeaderLHHRad.GroupName = "BoxHeader";

                        doorBoxHeaderLHHLBLRad.AssociatedControlID = "radDoorBoxHeaderLHH" + currentWall + title;
                        doorBoxHeaderLHHLBL.AssociatedControlID = "radDoorBoxHeaderLHH" + currentWall + title;

                        #endregion

                        #region Table:Eleventh Row Door Box Header RHH (tblDoorDetails)

                        TableRow doorBoxHeaderRHHRow = new TableRow();
                        doorBoxHeaderRHHRow.ID = "rowDoorBoxHeaderRHH" + currentWall + title;
                        doorBoxHeaderRHHRow.Attributes.Add("style", "display:none;");
                        TableCell doorBoxHeaderRHHLBLCell = new TableCell();
                        TableCell doorBoxHeaderRHHRADCell = new TableCell();

                        Label doorBoxHeaderRHHLBLRad = new Label();
                        doorBoxHeaderRHHLBLRad.ID = "lblDoorBoxHeaderRadRHH" + currentWall + title;

                        Label doorBoxHeaderRHHLBL = new Label();
                        doorBoxHeaderRHHLBL.ID = "lblDoorBoxHeaderRHH" + currentWall + title;
                        doorBoxHeaderRHHLBL.Text = "RHH";

                        RadioButton doorBoxHeaderRHHRad = new RadioButton();
                        doorBoxHeaderRHHRad.ID = "radDoorBoxHeaderRHH" + currentWall + title;
                        doorBoxHeaderRHHRad.GroupName = "BoxHeader";

                        doorBoxHeaderRHHLBLRad.AssociatedControlID = "radDoorBoxHeaderRHH" + currentWall + title;
                        doorBoxHeaderRHHLBL.AssociatedControlID = "radDoorBoxHeaderRHH" + currentWall + title;

                        #endregion

                        #region Table:Twelfth Row Door Box Header Both (tblDoorDetails)

                        TableRow doorBoxHeaderBothRow = new TableRow();
                        doorBoxHeaderBothRow.ID = "rowDoorBoxHeaderBoth" + currentWall + title;
                        doorBoxHeaderBothRow.Attributes.Add("style", "display:none;");
                        TableCell doorBoxHeaderBothLBLCell = new TableCell();
                        TableCell doorBoxHeaderBothRADCell = new TableCell();

                        Label doorBoxHeaderBothLBLRad = new Label();
                        doorBoxHeaderBothLBLRad.ID = "lblDoorBoxHeaderRadBoth" + currentWall + title;

                        Label doorBoxHeaderBothLBL = new Label();
                        doorBoxHeaderBothLBL.ID = "lblDoorBoxHeaderBoth" + currentWall + title;
                        doorBoxHeaderBothLBL.Text = "Both";

                        RadioButton doorBoxHeaderBothRad = new RadioButton();
                        doorBoxHeaderBothRad.ID = "radDoorBoxHeaderBoth" + currentWall + title;
                        doorBoxHeaderBothRad.GroupName = "BoxHeader";

                        doorBoxHeaderBothLBLRad.AssociatedControlID = "radDoorBoxHeaderBoth" + currentWall + title;
                        doorBoxHeaderBothLBL.AssociatedControlID = "radDoorBoxHeaderBoth" + currentWall + title;

                        #endregion

                        #region Table:Twelfth Row Door Box Header None (tblDoorDetails)

                        TableRow doorBoxHeaderNoneRow = new TableRow();
                        doorBoxHeaderNoneRow.ID = "rowDoorBoxHeaderNone" + currentWall + title;
                        doorBoxHeaderNoneRow.Attributes.Add("style", "display:none;");
                        TableCell doorBoxHeaderNoneLBLCell = new TableCell();
                        TableCell doorBoxHeaderNoneRADCell = new TableCell();

                        Label doorBoxHeaderNoneLBLRad = new Label();
                        doorBoxHeaderNoneLBLRad.ID = "lblDoorBoxHeaderRadNone" + currentWall + title;

                        Label doorBoxHeaderNoneLBL = new Label();
                        doorBoxHeaderNoneLBL.ID = "lblDoorBoxHeaderNone" + currentWall + title;
                        doorBoxHeaderNoneLBL.Text = "None";

                        RadioButton doorBoxHeaderNoneRad = new RadioButton();
                        doorBoxHeaderNoneRad.ID = "radDoorBoxHeaderNone" + currentWall + title;
                        doorBoxHeaderNoneRad.GroupName = "BoxHeader";

                        doorBoxHeaderNoneLBLRad.AssociatedControlID = "radDoorBoxHeaderNone" + currentWall + title;
                        doorBoxHeaderNoneLBL.AssociatedControlID = "radDoorBoxHeaderNone" + currentWall + title;

                        #endregion

                        #region Table:Twelfth Row Door Number Of Vents (tblDoorDetails)

                        TableRow doorNumberOfVentsRow = new TableRow();
                        doorNumberOfVentsRow.ID = "rowDoorNumberOfVents" + currentWall + title;
                        doorNumberOfVentsRow.Attributes.Add("style", "display:none;");
                        TableCell doorNumberOfVentsLBLCell = new TableCell();
                        TableCell doorNumberOfVentsDDLCell = new TableCell();

                        Label doorNumberOfVentsLBL = new Label();
                        doorNumberOfVentsLBL.ID = "lblNumberOfVents" + currentWall + title;
                        doorNumberOfVentsLBL.Text = "Number Of Vents:";

                        DropDownList doorNumberOfVentsDDL = new DropDownList();
                        doorNumberOfVentsDDL.ID = "ddlNumberOfVents" + currentWall + title;
                        ListItem two = new ListItem("2", "2");
                        ListItem three = new ListItem("3", "3");
                        ListItem four = new ListItem("4", "4");
                        doorNumberOfVentsDDL.Items.Add(two);
                        doorNumberOfVentsDDL.Items.Add(three);
                        doorNumberOfVentsDDL.Items.Add(four);

                        doorNumberOfVentsLBL.AssociatedControlID = "ddlNumberOfVents" + currentWall + title;

                        #endregion

                        #region Table:Thirteenth Row Door Glass Tint (tblDoorDetails)

                        TableRow doorGlassTintRow = new TableRow();
                        doorGlassTintRow.ID = "rowDoorGlassTint" + currentWall + title;
                        doorGlassTintRow.Attributes.Add("style", "display:none;");
                        TableCell doorGlassTintLBLCell = new TableCell();
                        TableCell doorGlassTintDDLCell = new TableCell();

                        Label doorGlassTintLBL = new Label();
                        doorGlassTintLBL.ID = "lblDoorGlassTint" + currentWall + title;
                        doorGlassTintLBL.Text = "Door Glass Tint:";

                        DropDownList doorGlassTintDDL = new DropDownList();
                        doorGlassTintDDL.ID = "ddlDoorGlassTint" + currentWall + title;
                        ListItem clear = new ListItem("Clear", "clear");
                        ListItem greyTint = new ListItem("Grey", "grey");
                        ListItem bronzeTint = new ListItem("Bronze", "bronze");
                        doorGlassTintDDL.Items.Add(clear);
                        doorGlassTintDDL.Items.Add(grey);
                        doorGlassTintDDL.Items.Add(bronzeTint);

                        #endregion

                        #region Table:Tenth Row Door Hinge LHH (tblDoorDetails)

                        TableRow doorLHHRow = new TableRow();
                        doorLHHRow.ID = "rowDoorLHH" + currentWall + title;
                        doorLHHRow.Attributes.Add("style", "display:none;");
                        TableCell doorLHHLBLCell = new TableCell();
                        TableCell doorLHHRADCell = new TableCell();

                        Label doorLHHLBLMain = new Label();
                        doorLHHLBLMain.ID = "lblDoorLHHMain" + currentWall + title;
                        doorLHHLBLMain.Text = "Hinge placement:";

                        Label doorLHHLBLRad = new Label();
                        doorLHHLBLRad.ID = "lblLHHRad" + currentWall + title;

                        Label doorLHHLBL = new Label();
                        doorLHHLBL.ID = "lblLHH" + currentWall + title;
                        doorLHHLBL.Text = "LHH";

                        RadioButton doorLHHRad = new RadioButton();
                        doorLHHRad.ID = "radDoorLHH" + currentWall + title;
                        doorLHHRad.GroupName = "DoorHinge";

                        doorLHHLBLRad.AssociatedControlID = "radDoorLHH" + currentWall + title;
                        doorLHHLBL.AssociatedControlID = "radDoorLHH" + currentWall + title;

                        #endregion

                        #region Table:Eleventh Row Door Hinge RHH (tblDoorDetails)

                        TableRow doorRHHRow = new TableRow();
                        doorRHHRow.ID = "rowDoorRHH" + currentWall + title;
                        doorRHHRow.Attributes.Add("style", "display:none;");
                        TableCell doorRHHLBLCell = new TableCell();
                        TableCell doorRHHRADCell = new TableCell();

                        Label doorRHHLBLRad = new Label();
                        doorRHHLBLRad.ID = "lblDoorRHHRad" + currentWall + title;

                        Label doorRHHLBL = new Label();
                        doorRHHLBL.ID = "lblDoorRHH" + currentWall + title;
                        doorRHHLBL.Text = "RHH";

                        RadioButton doorRHHRad = new RadioButton();
                        doorRHHRad.ID = "radDoorRHH" + currentWall + title;
                        doorRHHRad.GroupName = "DoorHinge";

                        doorRHHLBLRad.AssociatedControlID = "radDoorRHH" + currentWall + title;
                        doorRHHLBL.AssociatedControlID = "radDoorRHH" + currentWall + title;

                        #endregion

                        #region Table:Fourteenth Row Door Screen Options (tblDoorDetails)

                        TableRow doorScreenOptionsRow = new TableRow();
                        doorScreenOptionsRow.ID = "rowDoorScreenOptions" + currentWall + title;
                        doorScreenOptionsRow.Attributes.Add("style", "display:none;");
                        TableCell doorScreenOptionsLBLCell = new TableCell();
                        TableCell doorScreenOptionsDDLCell = new TableCell();

                        Label doorScreenOptionsLBL = new Label();
                        doorScreenOptionsLBL.ID = "lblDoorScreenOptions" + currentWall + title;
                        doorScreenOptionsLBL.Text = "Door Screen Option:";

                        DropDownList doorScreenOptionsDDL = new DropDownList();
                        doorScreenOptionsDDL.ID = "ddlDoorScreenOptions" + currentWall + title;
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

                        #endregion

                        #region Table:Fifteenth Row Door Hardware (tblDoorDetails)

                        TableRow doorHardwareRow = new TableRow();
                        doorHardwareRow.ID = "rowDoorHardware" + currentWall + title;
                        doorHardwareRow.Attributes.Add("style", "display:none;");
                        TableCell doorHardwareLBLCell = new TableCell();
                        TableCell doorHardwareDDLCell = new TableCell();

                        Label doorHardwareLBL = new Label();
                        doorHardwareLBL.ID = "lblDoorHardware" + currentWall + title;
                        doorHardwareLBL.Text = "Door Hardware";

                        DropDownList doorHardwareDDL = new DropDownList();
                        doorHardwareDDL.ID = "ddlDoorHardware" + currentWall + title;
                        ListItem satinSilver = new ListItem("Satin Silver", "satinSilver");
                        ListItem brightBrass = new ListItem("Bright Brass", "brightBrass");
                        ListItem antiqueBrass = new ListItem("Antique Brass", "antiqueBrass");
                        doorHardwareDDL.Items.Add(satinSilver);
                        doorHardwareDDL.Items.Add(brightBrass);
                        doorHardwareDDL.Items.Add(antiqueBrass);

                        #endregion



                        #region Table:Eight Row Door Swing In (tblDoorDetails)

                        TableRow doorSwingInRow = new TableRow();
                        doorSwingInRow.ID = "rowDoorSwingIn" + currentWall + title;
                        doorSwingInRow.Attributes.Add("style", "display:none;");
                        TableCell doorSwingInLBLCell = new TableCell();
                        TableCell doorSwingInRADCell = new TableCell();

                        Label doorSwingInLBLMain = new Label();
                        doorSwingInLBLMain.ID = "lblDoorSwingMain" + currentWall + title;
                        doorSwingInLBLMain.Text = "Swing:";

                        Label doorSwingInLBLRad = new Label();
                        doorSwingInLBLRad.ID = "lblDoorSwingIn" + currentWall + title;

                        Label doorSwingInLBL = new Label();
                        doorSwingInLBL.ID = "lblDoorSwingInRad" + currentWall + title;
                        doorSwingInLBL.Text = "In";

                        RadioButton doorSwingInRAD = new RadioButton();
                        doorSwingInRAD.ID = "radDoorSwingIn" + currentWall + title;
                        doorSwingInRAD.GroupName = "SwingInOut";

                        doorSwingInLBLRad.AssociatedControlID = "radDoorSwingIn" + currentWall + title;
                        doorSwingInLBL.AssociatedControlID = "radDoorSwingIn" + currentWall + title;

                        #endregion

                        #region Table:Ninth Row Door Swing Out (tblDoorDetails)

                        TableRow doorSwingOutRow = new TableRow();
                        doorSwingOutRow.ID = "rowDoorSwingOut" + currentWall + title;
                        doorSwingOutRow.Attributes.Add("style", "display:none;");
                        TableCell doorSwingOutLBLCell = new TableCell();
                        TableCell doorSwingOutRADCell = new TableCell();

                        Label doorSwingOutLBLRad = new Label();
                        doorSwingOutLBLRad.ID = "lblDoorSwingOutRad" + currentWall + title;

                        Label doorSwingOutLBL = new Label();
                        doorSwingOutLBL.ID = "lblDoorSwingOut" + currentWall + title;
                        doorSwingOutLBL.Text = "Out";

                        RadioButton doorSwingOutRAD = new RadioButton();
                        doorSwingOutRAD.ID = "radDoorSwingOut" + currentWall + title;
                        doorSwingOutRAD.GroupName = "SwingInOut";

                        doorSwingOutLBLRad.AssociatedControlID = "radDoorSwingOut" + currentWall + title;
                        doorSwingOutLBL.AssociatedControlID = "radDoorSwingOut" + currentWall + title;

                        #endregion

                        #region Table:# Row Door Position (tblDoorDetails)

                        TableRow doorPositionRow = new TableRow();
                        doorPositionRow.ID = "rowDoorPosition" + currentWall + title;
                        doorPositionRow.Attributes.Add("style", "display:none;");
                        TableCell doorPositionLBLCell = new TableCell();
                        TableCell doorPositionTXTCell = new TableCell();
                        TableCell doorPositionDDLCell = new TableCell();

                        Label doorPositionLBL = new Label();
                        doorPositionLBL.ID = "lblDoorPosition" + currentWall + title;
                        doorPositionLBL.Text = "Door position from left side (inches):";

                        TextBox doorPositionTXT = new TextBox();
                        doorPositionTXT.ID = "txtDoorPosition" + currentWall + title;
                        doorPositionTXT.CssClass = "txtField txtDoorInput";

                        DropDownList inchSpecificLeft = new DropDownList();
                        inchSpecificLeft.ID = "ddlInchSpecificLeft" + currentWall + title;
                        inchSpecificLeft.Items.Add(lst0);
                        inchSpecificLeft.Items.Add(lst18);
                        inchSpecificLeft.Items.Add(lst14);
                        inchSpecificLeft.Items.Add(lst38);
                        inchSpecificLeft.Items.Add(lst12);
                        inchSpecificLeft.Items.Add(lst58);
                        inchSpecificLeft.Items.Add(lst34);
                        inchSpecificLeft.Items.Add(lst78);

                        doorPositionLBL.AssociatedControlID = "txtDoorPosition" + currentWall + title;

                        #endregion

                        #region Table:# Row Add This Door (tblDoorDetails)

                        TableRow doorAddRow = new TableRow();
                        TableCell doorAddButtonCell = new TableCell();

                        Button doorAddButton = new Button();
                        doorAddButton.ID = "btnAddThisDoor" + currentWall + title;
                        doorAddButton.Text = "Add This " + title + " Door";
                        doorAddButton.CssClass = "btnSubmit";

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

                        #region Table:Tenth Row Door Box Header LHH Added To Table (tblDoorDetails)

                        doorBoxHeaderLHHLBLCell.Controls.Add(doorBoxHeaderLHHLBLMain);

                        doorBoxHeaderLHHRADCell.Controls.Add(doorBoxHeaderLHHRad);
                        doorBoxHeaderLHHRADCell.Controls.Add(doorBoxHeaderLHHLBLRad);
                        doorBoxHeaderLHHRADCell.Controls.Add(doorBoxHeaderLHHLBL);

                        tblDoorDetails.Rows.Add(doorBoxHeaderLHHRow);

                        doorBoxHeaderLHHRow.Cells.Add(doorBoxHeaderLHHLBLCell);
                        doorBoxHeaderLHHRow.Cells.Add(doorBoxHeaderLHHRADCell);

                        #endregion

                        #region Table:Eleventh Row Door Box Header RHH Added To Table (tblDoorDetails)

                        doorBoxHeaderRHHRADCell.Controls.Add(doorBoxHeaderRHHRad);
                        doorBoxHeaderRHHRADCell.Controls.Add(doorBoxHeaderRHHLBLRad);
                        doorBoxHeaderRHHRADCell.Controls.Add(doorBoxHeaderRHHLBL);

                        tblDoorDetails.Rows.Add(doorBoxHeaderRHHRow);

                        doorBoxHeaderRHHRow.Cells.Add(doorBoxHeaderRHHLBLCell);
                        doorBoxHeaderRHHRow.Cells.Add(doorBoxHeaderRHHRADCell);

                        #endregion

                        #region Table:Twelfth Row Door Box Header Both Added To Table (tblDoorDetails)

                        doorBoxHeaderBothRADCell.Controls.Add(doorBoxHeaderBothRad);
                        doorBoxHeaderBothRADCell.Controls.Add(doorBoxHeaderBothLBLRad);
                        doorBoxHeaderBothRADCell.Controls.Add(doorBoxHeaderBothLBL);

                        tblDoorDetails.Rows.Add(doorBoxHeaderBothRow);

                        doorBoxHeaderBothRow.Cells.Add(doorBoxHeaderBothLBLCell);
                        doorBoxHeaderBothRow.Cells.Add(doorBoxHeaderBothRADCell);

                        #endregion

                        #region Table:Twelfth Row Door Box Header None Added To Table (tblDoorDetails)

                        doorBoxHeaderNoneRADCell.Controls.Add(doorBoxHeaderNoneRad);
                        doorBoxHeaderNoneRADCell.Controls.Add(doorBoxHeaderNoneLBLRad);
                        doorBoxHeaderNoneRADCell.Controls.Add(doorBoxHeaderNoneLBL);

                        tblDoorDetails.Rows.Add(doorBoxHeaderNoneRow);

                        doorBoxHeaderNoneRow.Cells.Add(doorBoxHeaderNoneLBLCell);
                        doorBoxHeaderNoneRow.Cells.Add(doorBoxHeaderNoneRADCell);

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

                        doorAddButtonCell.Controls.Add(doorAddButton);

                        tblDoorDetails.Rows.Add(doorAddRow);

                        doorAddRow.Cells.Add(doorAddButtonCell);

                        #endregion

                        wallDoorOptions.Controls.Add(new LiteralControl("<div class='toggleContent' id='div_" + currentWall + title + "'><ul>"));

                        wallDoorOptions.Controls.Add(new LiteralControl("<li>"));

                        tblDoorDetails.ID = "tblDoorDetails" + currentWall + title;

                        wallDoorOptions.Controls.Add(tblDoorDetails);

                        wallDoorOptions.Controls.Add(new LiteralControl("</li></ul></div></li>"));
                    }
                }

                #endregion            

                wallDoorOptions.Controls.Add(new LiteralControl("</ul></li></li></ul></div>"));

            }
            #endregion

           
            //DropDownList used in tables loaded to page
            

            #region For Loop for slide 1 and slide3            

            for (int i = 1; i <= walls.Count(); i++) 
            {
                #region Slide1/Question1 Table
                
                if (wallDetails[i - 1, 4] == "E") //wall type is existing
                {
                    existingWallCount++;
                    populateTblExisting(i, existingWallCount);
                }
                else //wall type is proposed
                {
                    proposedWallCount++;
                    populateTblProposed(i, proposedWallCount);
                }
                #endregion

                #region Slide3/Question3 Quantity of Doors

                /*TableRow wallRow = new TableRow();
                TableCell wallLBLCell = new TableCell();
                TableCell wallDDLTypeCell = new TableCell();
                TableCell wallDDLQuantityCell = new TableCell();

                Label wallLBL = new Label();
                wallLBL.ID = "lblWallDoorId" + i;
                wallLBL.Text = "Amount of Doors In Wall " + i;

                DropDownList wallDDLType = new DropDownList();
                wallDDLType.ID = "ddlWallDoorType" + i;
                wallDDLType.Attributes.Add("OnChange", "checkQuestion3("+ i +")");
                ListItem zero = new ListItem("None", "0");
                ListItem cabana = new ListItem("Cabana", "cabana");
                ListItem french = new ListItem("French", "french");
                ListItem patio = new ListItem("Patio", "patio");
                ListItem noDoor = new ListItem("Opening Only (No Door)", "noDoor");
                wallDDLType.Items.Add(zero);
                wallDDLType.Items.Add(cabana);
                wallDDLType.Items.Add(french);
                wallDDLType.Items.Add(patio);
                wallDDLType.Items.Add(noDoor); 

                DropDownList wallDDLQuantity = new DropDownList();
                wallDDLQuantity.ID = "ddlWallDoorAmount" + i;
                wallDDLQuantity.Enabled = false;

                //for (int j = 0; j < calculatedMaxDoors; j++) { 

                //}

                wallLBLCell.Controls.Add(wallLBL);
                wallDDLTypeCell.Controls.Add(wallDDLType);
                wallDDLQuantityCell.Controls.Add(wallDDLQuantity);

                tblDoorQuantity.Rows.Add(wallRow);

                wallRow.Cells.Add(wallLBLCell);
                wallRow.Cells.Add(wallDDLTypeCell);
                wallRow.Cells.Add(wallDDLQuantityCell);*/

                #endregion
            }
            #endregion
        }

        protected void populateTblExisting(int i, int existingWallCount)
        {
            TableRow row = new TableRow();
            
            TableCell cell1 = new TableCell();
            TableCell cell2 = new TableCell();
            TableCell cell3 = new TableCell();
            
            Label lblWallNumber = new Label();

            TextBox txtWallLength = new TextBox();
            
            DropDownList ddlInchFractions = new DropDownList();

            ddlInchFractions.Items.Add(lst0);
            ddlInchFractions.Items.Add(lst18);
            ddlInchFractions.Items.Add(lst14);
            ddlInchFractions.Items.Add(lst38);
            ddlInchFractions.Items.Add(lst12);
            ddlInchFractions.Items.Add(lst58);
            ddlInchFractions.Items.Add(lst34);
            ddlInchFractions.Items.Add(lst78);
            ddlInchFractions.Attributes.Add("onchange", "checkQuestion1()");

            lblWallNumber.Text = "Wall " + existingWallCount + " : ";
    
            ddlInchFractions.ID = "ddlWall" + i + "InchFractions";
            lblWallNumber.ID = "lblWall" + i + "Length";
            lblWallNumber.AssociatedControlID = "txtWall" + i + "Length";

            txtWallLength.ID = "txtWall" + i + "Length";
            txtWallLength.CssClass = "txtField txtLengthInput";
            txtWallLength.MaxLength = 3;
            txtWallLength.Attributes.Add("onkeyup", "checkQuestion1()");
            txtWallLength.Attributes.Add("OnChange", "checkQuestion1()");
            txtWallLength.Attributes.Add("OnFocus", "highlightWallsLength()");
            txtWallLength.Attributes.Add("onblur", "resetWalls()");

            cell1.Controls.Add(lblWallNumber);
            cell2.Controls.Add(txtWallLength);
            cell3.Controls.Add(ddlInchFractions);
            
            tblExistingWalls.Rows.Add(row);
            
            row.Cells.Add(cell1);
            row.Cells.Add(cell2);
            row.Cells.Add(cell3);
        }

        protected void populateTblProposed(int i, int proposedWallCount)
        {
            TableRow row = new TableRow();
            
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
            ddlInchFractions.Attributes.Add("onchange", "checkQuestion1()");

            lblWallNumber.Text = "Wall " + proposedWallCount + " : ";
    
            ddlInchFractions.ID = "ddlWall" + i + "InchFractions";
            lblWallNumber.ID = "lblWall" + i + "Length";
            lblWallNumber.AssociatedControlID = "txtWall" + i + "Length";

            txtWallLength.ID = "txtWall" + i + "Length";
            txtWallLength.CssClass = "txtField txtLengthInput";
            txtWallLength.MaxLength = 3;
            txtWallLength.Attributes.Add("onkeyup", "checkQuestion1()");
            txtWallLength.Attributes.Add("OnChange", "checkQuestion1()");
            txtWallLength.Attributes.Add("OnFocus", "highlightWallsLength()");
            txtWallLength.Attributes.Add("onblur", "resetWalls()");

            ddlLeftInchFractions.Items.Add(lst0);
            ddlLeftInchFractions.Items.Add(lst18);
            ddlLeftInchFractions.Items.Add(lst14);
            ddlLeftInchFractions.Items.Add(lst38);
            ddlLeftInchFractions.Items.Add(lst12);
            ddlLeftInchFractions.Items.Add(lst58);
            ddlLeftInchFractions.Items.Add(lst34);
            ddlLeftInchFractions.Items.Add(lst78);
            ddlLeftInchFractions.Attributes.Add("onchange", "checkQuestion1()");
            ddlRightInchFractions.Items.Add(lst0);
            ddlRightInchFractions.Items.Add(lst18);
            ddlRightInchFractions.Items.Add(lst14);
            ddlRightInchFractions.Items.Add(lst38);
            ddlRightInchFractions.Items.Add(lst12);
            ddlRightInchFractions.Items.Add(lst58);
            ddlRightInchFractions.Items.Add(lst34);
            ddlRightInchFractions.Items.Add(lst78);
            ddlRightInchFractions.Attributes.Add("onchange", "checkQuestion1()");

            ddlLeftInchFractions.ID = "ddlWall" + i + "LeftInchFractions";
            ddlRightInchFractions.ID = "ddlWall" + i + "RightInchFractions";

            lblWallNumber.Text = "Wall " + proposedWallCount + " : ";
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

            cell2.Controls.Add(txtLeftFiller);
            cell3.Controls.Add(ddlLeftInchFractions);
            cell4.Controls.Add(txtWallLength);
            cell5.Controls.Add(ddlInchFractions);
            cell6.Controls.Add(txtRightFiller);
            cell7.Controls.Add(ddlRightInchFractions);
    
            ddlInchFractions.ID = "ddlWall" + i + "InchFractions";
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
            cell2.Controls.Add(txtLeftFiller);
            cell3.Controls.Add(ddlLeftInchFractions);
            cell4.Controls.Add(txtWallLength);
            cell5.Controls.Add(ddlInchFractions);
            cell6.Controls.Add(txtRightFiller);
            cell7.Controls.Add(ddlRightInchFractions);

            tblProposedWalls.Rows.Add(row);

            row.Cells.Add(cell1);
            row.Cells.Add(cell2);
            row.Cells.Add(cell3);
            row.Cells.Add(cell4);
            row.Cells.Add(cell5);
            row.Cells.Add(cell6);
            row.Cells.Add(cell7);
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
            string html = "";

            for (int i = 1; i <= number; i++)
            {
                html += "<input id=\"hidWall" + i + "SetBack\" type=\"hidden\" runat=\"server\" />";
                html += "<input id=\"hidWall" + i + "LeftFiller\" type=\"hidden\" runat=\"server\" />";
                html += "<input id=\"hidWall" + i + "Length\" type=\"hidden\" runat=\"server\" />";
                html += "<input id=\"hidWall" + i + "RightFiller\" type=\"hidden\" runat=\"server\" />";
            }
            return html;
        }
    }
}
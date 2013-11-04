using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SunspaceDealerDesktop
{
    public partial class ProjEd : System.Web.UI.Page
    {
        //fractions dropdown list items
        protected ListItem lst0 = new ListItem("---", "0", true);
        protected ListItem lst18 = new ListItem("1/8", ".125");
        protected ListItem lst14 = new ListItem("1/4", ".25");
        protected ListItem lst38 = new ListItem("3/8", ".375");
        protected ListItem lst12 = new ListItem("1/2", ".5");
        protected ListItem lst58 = new ListItem("5/8", ".625");
        protected ListItem lst34 = new ListItem("3/4", ".75");
        protected ListItem lst78 = new ListItem("7/8", ".875");

        protected void Page_Load(object sender, EventArgs e)
        {
            #region hardcode population
            //This info will all come from the database eventually            

            List<Wall> listOfWalls = new List<Wall>();

            float backwall = 150.0f;
            float frontwall = 140.0f;
            float slope = 0.6f;

            Wall firstWall = new Wall();
            firstWall.Length = 200;
            firstWall.Orientation = "WEST";
            firstWall.Name = "Wall 1";
            firstWall.WallType = "Proposed";
            firstWall.ModelType = "Model200";
            firstWall.StartHeight = 150;
            firstWall.EndHeight = 140;
            firstWall.SoffitLength = 0;
            firstWall.GablePeak = 0;
            firstWall.SoffitLength = 0;

            Wall secondWall = new Wall();
            secondWall.Length = 200;
            secondWall.Orientation = "SOUTH";
            secondWall.Name = "Wall 2";
            secondWall.WallType = "Proposed";
            secondWall.ModelType = "Model200";
            secondWall.StartHeight = 140;
            secondWall.EndHeight = 140;
            secondWall.SoffitLength = 0;
            secondWall.GablePeak = 0;
            secondWall.SoffitLength = 0;

            Wall thirdWall = new Wall();
            thirdWall.Length = 200;
            thirdWall.Orientation = "EAST";
            thirdWall.Name = "Wall 3";
            thirdWall.WallType = "Proposed";
            thirdWall.ModelType = "Model200";
            thirdWall.StartHeight = 140;
            thirdWall.EndHeight = 150;
            thirdWall.SoffitLength = 0;
            thirdWall.GablePeak = 0;
            thirdWall.SoffitLength = 0;

            listOfWalls.Add(firstWall);
            listOfWalls.Add(secondWall);
            listOfWalls.Add(thirdWall);
            #endregion

            #region dynamic accordion population

            #region Wall Height Entry
            accordion.Controls.Add(new LiteralControl("<h2>Wall Heights</h2>"));

            accordion.Controls.Add(new LiteralControl("<ul>"));

            accordion.Controls.Add(new LiteralControl("<li>"));
            Label backwallHeight = new Label();
            backwallHeight.ID = "lblBackwall";
            backwallHeight.Text = "Back Wall Height: ";
            accordion.Controls.Add(backwallHeight);

            TextBox backwallTextBox = new TextBox();
            backwallTextBox.ID = "txtBackwall";
            backwallTextBox.Text = backwall.ToString();
            backwallTextBox.CssClass = "txtField txtInput";
            backwallTextBox.Attributes.Add("onkeydown", "return (event.keyCode!=13);");
            accordion.Controls.Add(backwallTextBox);

            DropDownList backwallFractions = new DropDownList();
            backwallFractions.ID = "ddlBackwallFractions";
            backwallFractions.Items.Add(lst0);
            backwallFractions.Items.Add(lst12);
            backwallFractions.Items.Add(lst14);
            backwallFractions.Items.Add(lst18);
            backwallFractions.Items.Add(lst34);
            backwallFractions.Items.Add(lst38);
            backwallFractions.Items.Add(lst58);
            backwallFractions.Items.Add(lst78);
            accordion.Controls.Add(backwallFractions);
            accordion.Controls.Add(new LiteralControl("</li>"));

            accordion.Controls.Add(new LiteralControl("<li>"));
            Label frontwallHeight = new Label();
            frontwallHeight.ID = "lblFrontwall";
            frontwallHeight.Text = "Front Wall Height: ";
            accordion.Controls.Add(frontwallHeight);

            TextBox frontwallTextBox = new TextBox();
            frontwallTextBox.ID = "txtFrontwall";
            frontwallTextBox.Text = frontwall.ToString();
            frontwallTextBox.CssClass = "txtField txtInput";
            frontwallTextBox.Attributes.Add("onkeydown", "return (event.keyCode!=13);");
            accordion.Controls.Add(frontwallTextBox);

            DropDownList frontwallFractions = new DropDownList();
            frontwallFractions.ID = "ddlFrontwallFractions";
            frontwallFractions.Items.Add(lst0);
            frontwallFractions.Items.Add(lst12);
            frontwallFractions.Items.Add(lst14);
            frontwallFractions.Items.Add(lst18);
            frontwallFractions.Items.Add(lst34);
            frontwallFractions.Items.Add(lst38);
            frontwallFractions.Items.Add(lst58);
            frontwallFractions.Items.Add(lst78);
            accordion.Controls.Add(frontwallFractions);
            accordion.Controls.Add(new LiteralControl("</li>"));

            accordion.Controls.Add(new LiteralControl("<li>"));
            Label slopeLabel = new Label();
            slopeLabel.ID = "lblSlope";
            slopeLabel.Text = "Slope: ";
            accordion.Controls.Add(slopeLabel);

            TextBox slopeTextBox = new TextBox();
            slopeTextBox.ID = "txtSlope";
            slopeTextBox.Text = slope.ToString();
            slopeTextBox.CssClass = "txtField txtInput";
            slopeTextBox.Attributes.Add("onkeydown", "return (event.keyCode!=13);");
            accordion.Controls.Add(slopeTextBox);

            Label overTwelve = new Label();
            overTwelve.ID = "lblOverTwelve";
            overTwelve.Text = " / 12";
            accordion.Controls.Add(overTwelve);
            accordion.Controls.Add(new LiteralControl("</li>"));

            accordion.Controls.Add(new LiteralControl("</ul>"));
            #endregion

            #region Wall Width Entry
            accordion.Controls.Add(new LiteralControl("<ul class=\"toggleOptions\">"));
            accordion.Controls.Add(new LiteralControl("<h2>Wall Widths</h2>"));

            for (int i = 0; i < listOfWalls.Count; i++)
            {
                accordion.Controls.Add(new LiteralControl("<li>"));

                Label accordionLabel = new Label();
                accordionLabel.ID = "lblWall" + (i + 1) + "Label";
                accordionLabel.Text = listOfWalls[i].Name;
                accordion.Controls.Add(accordionLabel);

                accordion.Controls.Add(new LiteralControl("<div class=\"toggleContent\"><ul>"));

                #region Wall Length
                accordion.Controls.Add(new LiteralControl("<li>"));
                Label width = new Label();
                width.ID = "lblWidth" + (i + 1);
                width.Text = "Width: ";
                accordion.Controls.Add(width);

                TextBox widthTextBox = new TextBox();
                widthTextBox.ID = "txtWidth" + (i + 1);
                widthTextBox.Text = listOfWalls[i].Length.ToString();
                widthTextBox.CssClass = "txtField txtInput";
                widthTextBox.Attributes.Add("onkeydown", "return (event.keyCode!=13);");
                accordion.Controls.Add(widthTextBox);

                DropDownList widthFractions = new DropDownList();
                widthFractions.ID = "ddlWall" + (i + 1) + "Fractions";
                widthFractions.Items.Add(lst0);
                widthFractions.Items.Add(lst12);
                widthFractions.Items.Add(lst14);
                widthFractions.Items.Add(lst18);
                widthFractions.Items.Add(lst34);
                widthFractions.Items.Add(lst38);
                widthFractions.Items.Add(lst58);
                widthFractions.Items.Add(lst78);
                accordion.Controls.Add(widthFractions);

                accordion.Controls.Add(new LiteralControl("</li>"));
                #endregion

                #region Wall StartHeight
                accordion.Controls.Add(new LiteralControl("<li>"));
                Label startHeight = new Label();
                startHeight.ID = "lblStartHeight" + (i + 1);
                startHeight.Text = "Start Height: ";
                accordion.Controls.Add(startHeight);

                Label startHeightDisplay = new Label();
                startHeightDisplay.ID = "lblStartHeightDisplay" + (i + 1);
                startHeightDisplay.Text = listOfWalls[i].StartHeight.ToString();
                accordion.Controls.Add(startHeightDisplay);

                accordion.Controls.Add(new LiteralControl("</li>"));
                #endregion

                #region Wall EndHeight
                accordion.Controls.Add(new LiteralControl("<li>"));
                Label endHeight = new Label();
                endHeight.ID = "lblEndHeight" + (i + 1);
                endHeight.Text = "End Height: ";
                accordion.Controls.Add(endHeight);

                Label endHeightDisplay = new Label();
                endHeightDisplay.ID = "lblEndHeightDisplay" + (i + 1);
                endHeightDisplay.Text = listOfWalls[i].EndHeight.ToString();
                accordion.Controls.Add(endHeightDisplay);

                accordion.Controls.Add(new LiteralControl("</li>"));
                #endregion

                accordion.Controls.Add(new LiteralControl("</ul></div></li>"));
            }

            accordion.Controls.Add(new LiteralControl("</ul>"));
            #endregion

            #endregion
        }
    }
}
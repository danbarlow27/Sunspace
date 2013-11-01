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
        protected void Page_Load(object sender, EventArgs e)
        {
            #region hardcode population
            List<Wall> listOfWalls = new List<Wall>();

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

            listOfWalls.Add(firstWall);
            listOfWalls.Add(secondWall);
            listOfWalls.Add(thirdWall);
            #endregion

            #region dynamic accordion population
            accordion.Controls.Add(new LiteralControl("<ul class=\"toggleOptions\">"));

            #region Wall Heights and Widths
            accordion.Controls.Add(new LiteralControl("<h2>Wall Heights and Widths</h2>"));

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
                Label length = new Label();
                length.ID = "lblLength" + (i + 1);
                length.Text = "Length: ";
                accordion.Controls.Add(length);

                TextBox lengthTextBox = new TextBox();
                lengthTextBox.ID = "txtLength" + (i + 1);
                lengthTextBox.Text = listOfWalls[i].Length.ToString();
                accordion.Controls.Add(lengthTextBox);
                lengthTextBox.CssClass = "txtField txtInput";
                lengthTextBox.Attributes.Add("onkeydown", "return (event.keyCode!=13);");

                accordion.Controls.Add(new LiteralControl("</li>"));
                #endregion

                #region Wall StartHeight
                accordion.Controls.Add(new LiteralControl("<li>"));
                Label startHeight = new Label();
                startHeight.ID = "lblStartHeight" + (i + 1);
                startHeight.Text = "Start Height: ";
                accordion.Controls.Add(startHeight);

                TextBox startHeightTextBox = new TextBox();
                startHeightTextBox.ID = "txtStartHeight" + (i + 1);
                startHeightTextBox.Text = listOfWalls[i].StartHeight.ToString();
                accordion.Controls.Add(startHeightTextBox);
                startHeightTextBox.CssClass = "txtField txtInput";
                startHeightTextBox.Attributes.Add("onkeydown", "return (event.keyCode!=13);");

                accordion.Controls.Add(new LiteralControl("</li>"));
                #endregion

                #region Wall EndHeight
                accordion.Controls.Add(new LiteralControl("<li>"));
                Label endHeight = new Label();
                endHeight.ID = "lblEndHeight" + (i + 1);
                endHeight.Text = "End Height: ";
                accordion.Controls.Add(endHeight);

                TextBox endHeightTextBox = new TextBox();
                endHeightTextBox.ID = "txtEndHeight" + (i + 1);
                endHeightTextBox.Text = listOfWalls[i].EndHeight.ToString();
                accordion.Controls.Add(endHeightTextBox);
                endHeightTextBox.CssClass = "txtField txtInput";
                endHeightTextBox.Attributes.Add("onkeydown", "return (event.keyCode!=13);");

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
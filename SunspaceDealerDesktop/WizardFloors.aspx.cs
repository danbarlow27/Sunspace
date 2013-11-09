using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SunspaceDealerDesktop
{
    public partial class WizardFloors : System.Web.UI.Page
    {
        public string wallCoordinates;
        public float roomWidth;
        public float roomProjection;

        protected void Page_Load(object sender, EventArgs e)
        {
            //HARD CODED TO BE PASSED FROM OTHER PAGES
            wallCoordinates = Session["lineInfo"].ToString();
            //wallCoordinates = (string)Session["coordList"];
            roomWidth = Convert.ToSingle(Session["sunroomProjection"]);
            //roomWidth = (float)Session["roomWidth"];
            roomProjection = Convert.ToSingle(Session["sunroomProjection"]);
            //roomProjection = (float)Session["roomProjection"];

            //Loop to populate floor type drop down list
            for (int i = 0; i < Constants.FLOOR_TYPES.Count(); i++)
            {
                ddlFloorType.Items.Add(new ListItem(Constants.FLOOR_TYPES[i], Constants.FLOOR_TYPES[i]));
            }

            //Loop to populate floor thickness drop down list
            for (int i = 0; i < Constants.FLOOR_THICKNESSES.Count(); i++)
            {
                ddlFloorThickness.Items.Add(new ListItem(Constants.FLOOR_THICKNESSES[i], Constants.FLOOR_THICKNESSES[i]));
            }

            #region Inch dropdown population
            //ListItems to be used in multiple dropdown lists for decimal points
            //This should eventually be stored in the constants file
            ListItem lst0 = new ListItem("---", "0", true); //0, i.e. no decimal value, selected by default
            ListItem lst18 = new ListItem("1/8", ".125");
            ListItem lst14 = new ListItem("1/4", ".25");
            ListItem lst38 = new ListItem("3/8", ".375");//
            ListItem lst12 = new ListItem("1/2", ".5");
            ListItem lst58 = new ListItem("5/8", ".625");
            ListItem lst34 = new ListItem("3/4", ".75");
            ListItem lst78 = new ListItem("7/8", ".875");

            ddlLedgerSetbackInches.Items.Add(lst0);
            ddlLedgerSetbackInches.Items.Add(lst18);
            ddlLedgerSetbackInches.Items.Add(lst14);
            ddlLedgerSetbackInches.Items.Add(lst38);
            ddlLedgerSetbackInches.Items.Add(lst12);
            ddlLedgerSetbackInches.Items.Add(lst58);
            ddlLedgerSetbackInches.Items.Add(lst34);
            ddlLedgerSetbackInches.Items.Add(lst78);

            ddlSidesSetbackInches.Items.Add(lst0);
            ddlSidesSetbackInches.Items.Add(lst18);
            ddlSidesSetbackInches.Items.Add(lst14);
            ddlSidesSetbackInches.Items.Add(lst38);
            ddlSidesSetbackInches.Items.Add(lst12);
            ddlSidesSetbackInches.Items.Add(lst58);
            ddlSidesSetbackInches.Items.Add(lst34);
            ddlSidesSetbackInches.Items.Add(lst78);

            ddlJointSetbackInches.Items.Add(lst0);
            ddlJointSetbackInches.Items.Add(lst18);
            ddlJointSetbackInches.Items.Add(lst14);
            ddlJointSetbackInches.Items.Add(lst38);
            ddlJointSetbackInches.Items.Add(lst12);
            ddlJointSetbackInches.Items.Add(lst58);
            ddlJointSetbackInches.Items.Add(lst34);
            ddlJointSetbackInches.Items.Add(lst78);

            ddlFrontSetbackInches.Items.Add(lst0);
            ddlFrontSetbackInches.Items.Add(lst18);
            ddlFrontSetbackInches.Items.Add(lst14);
            ddlFrontSetbackInches.Items.Add(lst38);
            ddlFrontSetbackInches.Items.Add(lst12);
            ddlFrontSetbackInches.Items.Add(lst58);
            ddlFrontSetbackInches.Items.Add(lst34);
            ddlFrontSetbackInches.Items.Add(lst78);
            #endregion
        }

        protected void btnQuestion1_Click(object sender, EventArgs e)
        {
            Session.Add("floorType", ddlFloorType.SelectedValue);
            Session.Add("floorProjection", txtProjectionDisplay.Text);
            Session.Add("floorWidth", txtWidthDisplay.Text);
            Session.Add("floorThickness", ddlFloorThickness.SelectedValue);
            Session.Add("floorVapourBarrier", chkVapourBarrier.Checked);

            int panelNumber = 0;
            float lastPanelSize = 0f;

            if (ddlFloorType.SelectedValue == "Thermadeck")
            {
                panelNumber = Convert.ToInt32(Convert.ToSingle(txtWidthDisplay.Text) / Constants.THERMADECK_PANEL_WIDTH);
                float panelFloat = Convert.ToSingle(txtWidthDisplay.Text) / Constants.THERMADECK_PANEL_WIDTH;

                if (panelFloat > panelNumber)
                {
                    lastPanelSize = Convert.ToSingle(txtWidthDisplay.Text) - (panelNumber * Constants.THERMADECK_PANEL_WIDTH);
                    panelNumber++;
                }
            }

            if (ddlFloorType.SelectedValue == "Alumadeck")
            {
                //Change thermadeck constants to alumadeck constants, if required in the future

                //panelNumber = Convert.ToInt32(Convert.ToSingle(txtWidthDisplay.Text) / Constants.THERMADECK_PANEL_WIDTH);
                //float panelFloat = Convert.ToSingle(txtWidthDisplay.Text) / Constants.THERMADECK_PANEL_WIDTH;

                //if (panelFloat > panelNumber)
                //{
                //    lastPanelSize = Convert.ToSingle(txtWidthDisplay.Text) - (panelNumber * Constants.THERMADECK_PANEL_WIDTH);
                //    panelNumber++;
                //}
            }

            Session.Add("floorPanelNumber", panelNumber);
            Session.Add("floorLastPanelSize", lastPanelSize);

            Session.Add("floorLedgerSetback", txtLedgerSetback + ddlLedgerSetbackInches.SelectedValue);
            Session.Add("floorFrontSetback", txtFrontSetback + ddlFrontSetbackInches.SelectedValue);
            Session.Add("floorSidesSetback", txtSidesSetback + ddlSidesSetbackInches.SelectedValue);
            Session.Add("floorJointSetback", txtJointSetback + ddlJointSetbackInches.SelectedValue);

            //Now I know there's a column x row grid of panels
            Response.Redirect("ProjectPreview.aspx");
        }
    }
}
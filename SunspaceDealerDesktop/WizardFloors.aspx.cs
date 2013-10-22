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
        }

        protected void btnQuestion1_Click(object sender, EventArgs e)
        {
            Session.Add("floorType", ddlFloorType.SelectedValue);
            Session.Add("floorProjection", txtProjectionDisplay.Text);
            Session.Add("floorWidth", txtWidthDisplay.Text);
            Session.Add("floorThickness", ddlFloorThickness.SelectedValue);
            Session.Add("floorVapourBarrier", chkVapourBarrier.Checked);

            Response.Redirect("ProjectPreview.aspx");
        }
    }
}
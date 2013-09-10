﻿using System;
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
            wallCoordinates = "75,262.5,175,175,E,S/262.5,262.5,175,200,E,W/262.5,425,200,200,E,S/150,150,175,300,P,W/150,350,300,300,P,S/350,350,300,200,P,E/";
            //wallCoordinates = (string)Session["coordList"];
            roomWidth = 300;
            //roomWidth = (float)Session["roomWidth"];
            roomProjection = 200;
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
    }
}
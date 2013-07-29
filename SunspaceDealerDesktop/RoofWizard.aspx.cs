using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SunspaceDealerDesktop
{
    public partial class RoofWizard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Fill skin dropdowns
                for (int i = 0; i < Constants.ROOF_INTERIOR_SKIN_TYPES.Length; i++)
                {
                    ddlInteriorRoofSkin.Items.Add(new ListItem(Constants.ROOF_INTERIOR_SKIN_TYPES[i], Constants.ROOF_INTERIOR_SKIN_TYPES[i]));
                }

                for (int i = 0; i < Constants.ROOF_EXTERIOR_SKIN_TYPES.Length; i++)
                {
                    ddlExteriorRoofSkin.Items.Add(new ListItem(Constants.ROOF_EXTERIOR_SKIN_TYPES[i], Constants.ROOF_EXTERIOR_SKIN_TYPES[i]));
                }

                //Check roof type, position 26
                string[] newProjectArray = (string[])Session["newProjectArray"];

                //if gable, we need two studio roof systems
                if (newProjectArray[26] == "Dealer Gable" || newProjectArray[26] == "Sunspace Gable")
                {

                }
                //studio system
                else
                {

                }
            }
        }
    }
}
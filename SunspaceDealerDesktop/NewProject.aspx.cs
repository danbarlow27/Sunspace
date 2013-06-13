using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SunspaceWizard
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLayout_Click(object sender, EventArgs e)
        {
            Session.Add("hidFirstName", hidFirstName.Value);
            Session.Add("hidExisting", hidExisting.Value);
            Session.Add("hidFirstName", hidFirstName.Value);
            Session.Add("hidLastName", hidLastName.Value);
            Session.Add("hidAddress", hidAddress.Value);
            Session.Add("hidCity", hidCity.Value);
            Session.Add("hidZip", hidZip.Value);
            Session.Add("hidPhone", hidPhone.Value);

            Session.Add("hidProjectTag", hidProjectTag.Value);

            Session.Add("hidProjectType", hidProjectType.Value);
            Session.Add("hidModelNumber", hidModelNumber.Value);

            Session.Add("hidKneewallType", hidKneewallType.Value);
            Session.Add("hidKneewallColour", hidKneewallColour.Value);
            Session.Add("hidKneewallHeight", hidKneewallHeight.Value);
            Session.Add("hidTransomType", hidTransomType.Value);
            Session.Add("hidTransomColour", hidTransomColour.Value);
            Session.Add("hidTransomHeight", hidTransomHeight.Value);
            Session.Add("hidInteriorColour", hidInteriorColour.Value);
            Session.Add("hidInteriorSkin", hidInteriorSkin.Value);
            Session.Add("hidExteriorColour", hidExteriorColour.Value);
            Session.Add("hidExteriorSkin", hidExteriorSkin.Value);

            Session.Add("hidFoamProtected", hidFoamProtected.Value);

            Session.Add("hidPrefabFloor", hidPrefabFloor.Value);

            Session.Add("hidRoof", hidRoof.Value);
            Session.Add("hidRoofType", hidRoofType.Value);

            Session.Add("hidLayoutSelection", hidLayoutSelection.Value);
            
            //If custom btnLayout, Page 2, else, page3
            Response.Redirect("TestingHiddens.aspx");
        }
    }
}
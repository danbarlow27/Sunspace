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
           /* Session.Add("hidLastName", );
            Session.Add("hidAddress", );
            Session.Add("hidCity", );
            Session.Add("hidZip", );
            Session.Add("hidPhone", );
   
            Session.Add("hidProjectTag", );
       
            Session.Add("hidProjectType", );
            Session.Add("hidModelNumber", );

            Session.Add("hidKneewallType", );
            Session.Add("hidKneewallColour", );
            Session.Add("hidKneewallHeight", );
            Session.Add("hidTransomType", );
            Session.Add("hidTransomColour", );
            Session.Add("hidTransomHeight", );
            Session.Add("hidInteriorColour", );
            Session.Add("hidInteriorSkin", );
            Session.Add("hidExteriorColour", );
            Session.Add("hidExteriorSkin", );
            
            Session.Add("hidFoamProtected", );

            Session.Add("hidPrefabFloor", );

            Session.Add("hidRoof", );
            Session.Add("hidRoofType", );

            Session.Add("hidLayoutSelection", );
            */
            //If custom btnLayout, Page 2, else, page3
            Session.Add("testing2", "Second test worked");
            Response.Redirect("TestingHiddens.aspx");
        }
    }
}
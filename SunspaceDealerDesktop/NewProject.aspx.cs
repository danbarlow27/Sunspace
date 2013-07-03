using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SunspaceDealerDesktop
{
    public partial class NewProject : Page
    {
        //colour lists
        //NOTETOSELF change constants to have lists instead of arrays
        public string model100FramingColoursJ = new JavaScriptSerializer().Serialize(Constants.MODEL_100_FRAMING_COLOURS);
        public string model200FramingColoursJ = new JavaScriptSerializer().Serialize(Constants.MODEL_200_FRAMING_COLOURS);
        public string model300FramingColoursJ = new JavaScriptSerializer().Serialize(Constants.MODEL_300_FRAMING_COLOURS);
        public string model400FramingColoursJ = new JavaScriptSerializer().Serialize(Constants.MODEL_400_FRAMING_COLOURS);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedIn"] == null)
            {
                //uncomment me when login functionality is working
                //Response.Redirect("Login.aspx");
                Session.Add("loggedIn", "userA");
            }           

            //slide1
            #region Slide 1 pageload
            ddlExistingCustomer.Items.Add("Choose a Customer...");

            Customer aCustomer = new Customer();
            aCustomer.FirstName = "Kyle";
            aCustomer.LastName = "Brougham";

            ddlExistingCustomer.Items.Add(aCustomer.FirstName + " " + aCustomer.LastName);

            aCustomer = new Customer();
            aCustomer.FirstName = "Anthony";
            aCustomer.LastName = "Smeelen";

            ddlExistingCustomer.Items.Add(aCustomer.FirstName + " " + aCustomer.LastName);

            aCustomer = new Customer();
            aCustomer.FirstName = "Dan";
            aCustomer.LastName = "Barlow";

            ddlExistingCustomer.Items.Add(aCustomer.FirstName + " " + aCustomer.LastName);
            #endregion

            //slide4
            #region Slide 4 pageload
            ddlFramingColour.Items.Add("Choose a colour...");

            ddlInteriorColour.Items.Add("Choose a colour...");
            for (int i = 0; i < Constants.INTERIOR_WALL_COLOURS.Length; i++)
            {
                ddlInteriorColour.Items.Add(Constants.INTERIOR_WALL_COLOURS[i]);
            }

            ddlInteriorSkin.Items.Add("Choose a skin...");
            for (int i = 0; i < Constants.INTERIOR_WALL_SKIN_TYPES.Length; i++)
            {
                ddlInteriorSkin.Items.Add(Constants.INTERIOR_WALL_SKIN_TYPES[i]);
            }

            ddlExteriorColour.Items.Add("Choose a colour...");
            for (int i = 0; i < Constants.EXTERIOR_WALL_COLOURS.Length; i++)
            {
                ddlExteriorColour.Items.Add(Constants.EXTERIOR_WALL_COLOURS[i]);
            }

            ddlExteriorSkin.Items.Add("Choose a skin...");
            for (int i = 0; i < Constants.EXTERIOR_WALL_SKIN_TYPES.Length; i++)
            {
                ddlExteriorSkin.Items.Add(Constants.EXTERIOR_WALL_SKIN_TYPES[i]);
            }
            #endregion
        }
        
        protected void btnLayout_Click(object sender, EventArgs e)
        {
            //Session.Add("hidFirstName", hidFirstName.Value);
            //Session.Add("hidExisting", hidExisting.Value);
            //Session.Add("hidFirstName", hidFirstName.Value);
            //Session.Add("hidLastName", hidLastName.Value);
            //Session.Add("hidAddress", hidAddress.Value);
            //Session.Add("hidCity", hidCity.Value);
            //Session.Add("hidZip", hidZip.Value);
            //Session.Add("hidPhone", hidPhone.Value);

            //Session.Add("hidProjectTag", hidProjectTag.Value);

            //Session.Add("hidProjectType", hidProjectType.Value);
            //Session.Add("hidModelNumber", hidModelNumber.Value);

            //Session.Add("hidKneewallType", hidKneewallType.Value);
            //Session.Add("hidKneewallColour", hidKneewallColour.Value);
            //Session.Add("hidKneewallHeight", hidKneewallHeight.Value);
            //Session.Add("hidTransomType", hidTransomType.Value);
            //Session.Add("hidTransomColour", hidTransomColour.Value);
            //Session.Add("hidTransomHeight", hidTransomHeight.Value);
            //Session.Add("hidInteriorColour", hidInteriorColour.Value);
            //Session.Add("hidInteriorSkin", hidInteriorSkin.Value);
            //Session.Add("hidExteriorColour", hidExteriorColour.Value);
            //Session.Add("hidExteriorSkin", hidExteriorSkin.Value);

            //Session.Add("hidFoamProtected", hidFoamProtected.Value);

            //Session.Add("hidPrefabFloor", hidPrefabFloor.Value);

            //Session.Add("hidRoof", hidRoof.Value);
            //Session.Add("hidRoofType", hidRoofType.Value);

            //Session.Add("hidLayoutSelection", hidLayoutSelection.Value);

            string[] viewingArray = new string[24];

            //viewingArray[0] = hidFirstName.Value.ToString();
            //viewingArray[1] = hidLastName.Value.ToString();
            //viewingArray[2] = hidAddress.Value.ToString();
            //viewingArray[3] = hidCity.Value.ToString();
            //viewingArray[4] = hidZip.Value.ToString();
            //viewingArray[5] = hidPhone.Value.ToString();
            //viewingArray[6] = hidProjectTag.Value.ToString();
            //viewingArray[7] = hidProjectType.Value.ToString();
            //viewingArray[8] = hidModelNumber.Value.ToString();
            //viewingArray[9] = hidKneewallType.Value.ToString();
            //viewingArray[10] = hidKneewallColour.Value.ToString();
            //viewingArray[11] = hidKneewallHeight.Value.ToString();
            //viewingArray[12] = hidTransomType.Value.ToString();
            //viewingArray[13] = hidTransomColour.Value.ToString();
            //viewingArray[14] = hidTransomHeight.Value.ToString();
            //viewingArray[15] = hidInteriorColour.Value.ToString();
            //viewingArray[16] = hidInteriorSkin.Value.ToString();
            //viewingArray[17] = hidExteriorColour.Value.ToString();
            //viewingArray[18] = hidExteriorSkin.Value.ToString();
            //viewingArray[19] = hidFoamProtected.Value.ToString();
            //viewingArray[20] = hidPrefabFloor.Value.ToString();
            //viewingArray[21] = hidRoof.Value.ToString();
            //viewingArray[22] = hidRoofType.Value.ToString();
            //viewingArray[23] = hidLayoutSelection.Value.ToString();

            Session.Add("viewingArray", viewingArray);

            //If custom btnLayout, Page 2, else, page3
            Response.Redirect("TestingHiddens.aspx");
        }

        protected void btnQuestion3_Click(object sender, EventArgs e)
        {
            if (radProjectRoof.Checked)
            {
                Response.Redirect("Home.aspx");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SunspaceDealerDesktop
{
    public partial class NewProject : Page
    {
        //colour arrays generated as javascript usable objects
        //Used for population of corresponding dropdown lists
        public string model100FramingColoursJ = new JavaScriptSerializer().Serialize(Constants.MODEL_100_FRAMING_COLOURS);
        public string model200FramingColoursJ = new JavaScriptSerializer().Serialize(Constants.MODEL_200_FRAMING_COLOURS);
        public string model300FramingColoursJ = new JavaScriptSerializer().Serialize(Constants.MODEL_300_FRAMING_COLOURS);
        public string model400FramingColoursJ = new JavaScriptSerializer().Serialize(Constants.MODEL_400_FRAMING_COLOURS);

        public string model100TransomTypesJ = new JavaScriptSerializer().Serialize(Constants.MODEL_100_TRANSOM_TYPES);
        public string model200TransomTypesJ = new JavaScriptSerializer().Serialize(Constants.MODEL_200_TRANSOM_TYPES);
        public string model300TransomTypesJ = new JavaScriptSerializer().Serialize(Constants.MODEL_300_TRANSOM_TYPES);
        public string model400TransomTypesJ = new JavaScriptSerializer().Serialize(Constants.MODEL_400_TRANSOM_TYPES);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedIn"] == null)
            {
                Response.Redirect("Login.aspx");
            }           

            //slide1
            #region Slide 1 pageload
            //Add countries to country ddl
            if (!IsPostBack)
            {
                for (int i = 0; i < Constants.COUNTRY_LIST.Count; i++)
                {
                    ddlCustomerCountry.Items.Add(Constants.COUNTRY_LIST[i]);
                }
            }

            if (ddlCustomerCountry.SelectedValue == "CAN")
            {
                ddlCustomerProvState.Items.Clear();
                //Add provinces to the province/state ddl
                for (int i = 0; i < Constants.PROVINCE_LIST.Count; i++)
                {
                    ddlCustomerProvState.Items.Add(Constants.PROVINCE_LIST[i]);
                }
            }
            else
            {
                ddlCustomerProvState.Items.Clear();
                //Add states to the province/state ddl
                for (int i = 0; i < Constants.STATE_LIST.Count; i++)
                {
                    ddlCustomerProvState.Items.Add(Constants.STATE_LIST[i]);
                }
            }

            //Only on first load
            if (!IsPostBack)
            {
                if (Session["dealer_id"].ToString() == "-1")
                {
                    //If sunspace user is not spoofed, require them too
                    Response.Redirect("Spoof.aspx");
                }

                //Get list of customers that belong to this dealer
                sdsCustomers.SelectCommand = "SELECT first_name, last_name, email FROM customers WHERE dealer_id=" + Session["dealer_id"] + "ORDER BY last_name, first_name";                

                //assign the table names to the dataview object
                DataView dvExistingCustomers = (DataView)sdsCustomers.Select(System.Web.UI.DataSourceSelectArguments.Empty);

                //clear customer dropdownlist for start
                ddlExistingCustomer.Items.Clear();

                //loop through all results, adding each customer to the dropdown list
                for (int i = 0; i < dvExistingCustomers.Count; i++)
                {
                    ddlExistingCustomer.Items.Add(dvExistingCustomers[i][0].ToString() + " " + dvExistingCustomers[i][1].ToString() + "(" + dvExistingCustomers[i][2].ToString() + ")");
                }

                //add this customer list to the session so we don't have to constantly query on refreshes
                Session.Add("ddlExistingCustomer", ddlExistingCustomer);
            }
            else
            {
                ddlExistingCustomer = (DropDownList)Session["ddlExistingCustomer"];
            }
            

            #region Old Preset Customers
            //Customer aCustomer = new Customer();
            //aCustomer.FirstName = "Kyle";
            //aCustomer.LastName = "Brougham";

            //ddlExistingCustomer.Items.Add(aCustomer.FirstName + " " + aCustomer.LastName);

            //aCustomer = new Customer();
            //aCustomer.FirstName = "Anthony";
            //aCustomer.LastName = "Smeelen";

            //ddlExistingCustomer.Items.Add(aCustomer.FirstName + " " + aCustomer.LastName);

            //aCustomer = new Customer();
            //aCustomer.FirstName = "Dan";
            //aCustomer.LastName = "Barlow";

            //ddlExistingCustomer.Items.Add(aCustomer.FirstName + " " + aCustomer.LastName);
            #endregion
            #endregion

            //slide4
            #region Slide 4 pageload
            //ddlInteriorColour.Items.Add("Choose a colour...");
            for (int i = 0; i < Constants.INTERIOR_WALL_COLOURS.Length; i++)
            {
                ddlInteriorColour.Items.Add(Constants.INTERIOR_WALL_COLOURS[i]);
            }

            //ddlInteriorSkin.Items.Add("Choose a skin...");
            for (int i = 0; i < Constants.INTERIOR_WALL_SKIN_TYPES.Length; i++)
            {
                ddlInteriorSkin.Items.Add(Constants.INTERIOR_WALL_SKIN_TYPES[i]);
            }

            //ddlExteriorColour.Items.Add("Choose a colour...");
            for (int i = 0; i < Constants.EXTERIOR_WALL_COLOURS.Length; i++)
            {
                ddlExteriorColour.Items.Add(Constants.EXTERIOR_WALL_COLOURS[i]);
            }

            //ddlExteriorSkin.Items.Add("Choose a skin...");
            for (int i = 0; i < Constants.EXTERIOR_WALL_SKIN_TYPES.Length; i++)
            {
                ddlExteriorSkin.Items.Add(Constants.EXTERIOR_WALL_SKIN_TYPES[i]);
            }

            //ddlKneewallType.Items.Add("Choose a type...");
            for (int i = 0; i < Constants.KNEEWALL_TYPES.Length; i++)
            {
                ddlKneewallType.Items.Add(Constants.KNEEWALL_TYPES[i]);
            }

            //Must populate transom dropdown based on model#
            #endregion
        }

        protected void btnLayout_Click(object sender, EventArgs e)
        {
            if (hidExisting.Value == "")
            {
                insertNewCustomer();
            }

            //Move all hidden fields into this array, then put array on the session
            string[] newProjectArray = new string[28];

            newProjectArray[0] = hidCountry.Value.ToString();
            newProjectArray[1] = hidExisting.Value.ToString();
            newProjectArray[2] = hidFirstName.Value.ToString();
            newProjectArray[3] = hidLastName.Value.ToString();
            newProjectArray[4] = hidAddress.Value.ToString();
            newProjectArray[5] = hidProvState.Value.ToString();
            newProjectArray[6] = hidCity.Value.ToString();
            newProjectArray[7] = hidZip.Value.ToString();
            newProjectArray[8] = hidPhone.Value.ToString();
            newProjectArray[9] = hidCell.Value.ToString();
            newProjectArray[10] = hidEmail.Value.ToString();
            newProjectArray[11] = hidProjectName.Value.ToString();
            newProjectArray[12] = hidProjectType.Value.ToString();
            newProjectArray[13] = hidModelNumber.Value.ToString();
            newProjectArray[14] = hidKneewallType.Value.ToString();
            newProjectArray[15] = hidKneewallHeight.Value.ToString();
            newProjectArray[16] = hidTransomType.Value.ToString();
            newProjectArray[17] = hidTransomHeight.Value.ToString();
            newProjectArray[18] = hidFramingColour.Value.ToString();
            newProjectArray[19] = hidInteriorColour.Value.ToString();
            newProjectArray[20] = hidInteriorSkin.Value.ToString();
            newProjectArray[21] = hidExteriorColour.Value.ToString();
            newProjectArray[22] = hidExteriorSkin.Value.ToString();
            newProjectArray[23] = hidFoamProtected.Value.ToString();
            newProjectArray[24] = hidPrefabFloor.Value.ToString();
            newProjectArray[25] = hidRoof.Value.ToString();
            newProjectArray[26] = hidRoofType.Value.ToString();
            newProjectArray[27] = hidLayoutSelection.Value.ToString();

            Session.Add("newProjectArray", newProjectArray);

            //If custom is selected, send to drawing tool
            if (hidLayoutSelection.Value.ToString() == "Custom")
            {
                Response.Redirect("CustomDrawingTool.aspx");
            }
            //if sunroom or walls, send to wall building page
            else if (hidProjectType.Value.ToString() == "Sunroom" || hidProjectType.Value.ToString() == "Walls")
            {
                Response.Redirect("WizardWallsAndMods.aspx");
            }
            else
            {
                //Should never get here, some type of session error has occurred.
            }
        }

        protected void btnQuestion3_Click(object sender, EventArgs e)
        {
            if (radProjectRoof.Checked)
            {
                //if existing is blank, it must be a new customer
                if (hidExisting.Value == "")
                {
                    insertNewCustomer();
                }
                Response.Redirect("Home.aspx");
            }
        }

        protected void btnQuestion4Walls_Click(object sender, EventArgs e)
        {
            //if existing is blank, it must be a new customer
            if (hidExisting.Value == "")
            {
                insertNewCustomer();
            }
            //required session stuff before forwarding
            Response.Redirect("Home.aspx");
        }

        //This function will add a new user to the customer database at an applicable time when the page is completed and has been posted back.
        protected void insertNewCustomer()
        {
            sdsCustomers.SelectCommand = "SELECT * FROM customers"; ;
            DataView dvCustomers = (DataView)sdsCustomers.Select(System.Web.UI.DataSourceSelectArguments.Empty);

            //If new customer is selected, lets add this customer to our customer list
            //CHANGEME Uses logged in session number as dealerID, this is likely userID in the future, and needs to be changed

            string sqlInsert = "INSERT INTO customers (dealer_id,first_name,last_name,address,city,prov_city,country,zip_postal,main_phone,cell_phone,email,accept_email)"
            + "VALUES("
            + Convert.ToInt32(Session["dealer_id"].ToString()) + ",'" + hidFirstName.Value + "','" + hidLastName.Value + "','" + hidAddress.Value + "','" + hidCity.Value + "','"
            + hidProvState.Value + "','" + hidCountry.Value + "','" + hidZip.Value + "','" + hidPhone.Value + "','" + hidCell.Value + "','" + hidEmail.Value + "',"
            + 1 + ")";

            sdsCustomers.InsertCommand = sqlInsert;
            sdsCustomers.Insert();
        }
    }
}
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

        public string transomGlassTints = new JavaScriptSerializer().Serialize(Constants.TRANSOM_GLASS_TINTS);
        public string vinylTints = new JavaScriptSerializer().Serialize(Constants.VINYL_TINTS);

        public string usStatesJ = new JavaScriptSerializer().Serialize(Constants.STATE_LIST);
        public string usCodesJ = new JavaScriptSerializer().Serialize(Constants.STATE_CODES);
        public string canProvJ = new JavaScriptSerializer().Serialize(Constants.PROVINCE_LIST);
        public string canCodesJ = new JavaScriptSerializer().Serialize(Constants.PROVINCE_CODES);

        public string unavailableProjectNames;

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

            //if (ddlCustomerCountry.SelectedValue == "CAN")
            //{
            //    ddlCustomerProvState.Items.Clear();
            //    //Add provinces to the province/state ddl
            //    for (int i = 0; i < Constants.PROVINCE_LIST.Count; i++)
            //    {
            //        ddlCustomerProvState.Items.Add(Constants.PROVINCE_LIST[i]);
            //    }
            //}
            //else
            //{
            //    ddlCustomerProvState.Items.Clear();
            //    //Add states to the province/state ddl
            //    for (int i = 0; i < Constants.STATE_LIST.Count; i++)
            //    {
            //        ddlCustomerProvState.Items.Add(Constants.STATE_LIST[i]);
            //    }
            //}

            //Only on first load
            if (!IsPostBack)
            {
                if (Session["dealer_id"].ToString() == "-1")
                {
                    //If sunspace user is not spoofed, require them too
                    Response.Redirect("Spoof.aspx");
                }

                //Get list of customers that belong to this dealer
                sdsCustomers.SelectCommand = "SELECT first_name, last_name, email, customer_id FROM customers WHERE dealer_id=" + Session["dealer_id"] + "ORDER BY last_name, first_name";                

                //assign the table names to the dataview object
                DataView dvExistingCustomers = (DataView)sdsCustomers.Select(System.Web.UI.DataSourceSelectArguments.Empty);

                //clear customer dropdownlist for start
                ddlExistingCustomer.Items.Clear();

                //loop through all results, adding each customer to the dropdown list
                for (int i = 0; i < dvExistingCustomers.Count; i++)
                {
                    ListItem aListItem = new ListItem(dvExistingCustomers[i][1].ToString() + "(" + dvExistingCustomers[i][2].ToString() + ")", dvExistingCustomers[i][3].ToString());
                    ddlExistingCustomer.Items.Add(aListItem);
                }

                //add this customer list to the session so we don't have to constantly query on refreshes
                Session.Add("ddlExistingCustomer", ddlExistingCustomer);

                //Get list of projects that belong to this dealer
                sdsCustomers.SelectCommand = "SELECT project_name FROM projects WHERE user_id=" + Session["dealer_id"];

                //assign the table names to the dataview object
                DataView dvExistingProjects = (DataView)sdsCustomers.Select(System.Web.UI.DataSourceSelectArguments.Empty);

                //loop through all results, adding each customer to the dropdown list
                List<String> lstUnavailable = new List<String>();
                for (int i = 0; i < dvExistingProjects.Count; i++)
                {
                    lstUnavailable.Add(dvExistingProjects[i][0].ToString());
                }

                //add this customer list to the session so we don't have to constantly query on refreshes
                Session.Add("unavailableProjectNames", lstUnavailable);
                unavailableProjectNames = new JavaScriptSerializer().Serialize(lstUnavailable);
            }
            else
            {
                ddlExistingCustomer = (DropDownList)Session["ddlExistingCustomer"];
                unavailableProjectNames = new JavaScriptSerializer().Serialize((List<String>)Session["lstUnavailable"]);
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

            //ddlInteriorSkin.Items.Add("Choose a skin...");
            for (int i = 0; i < Constants.INTERIOR_WALL_SKIN_TYPES.Length; i++)
            {
                ddlInteriorSkin.Items.Add(Constants.INTERIOR_WALL_SKIN_TYPES[i]);
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

            for (int i = 0; i < Constants.KNEEWALL_GLASS_TINTS.Length; i++)
            {
                ddlKneewallTint.Items.Add(Constants.KNEEWALL_GLASS_TINTS[i]);
            }
            //Must populate transom dropdown based on model#
            #endregion


            ////Set based on preferences
            //#region Preferences

            ////Get preferences that belong to this dealer
            //sdsCustomers.SelectCommand = "SELECT model_type, layout FROM preferences WHERE dealer_id=" + Session["dealer_id"];

            ////assign the table names to the dataview object
            //DataView dvPreferences = (DataView)sdsCustomers.Select(System.Web.UI.DataSourceSelectArguments.Empty);

            ////Preclick model #
            //string dbModelNumber = dvPreferences[0][0].ToString();

            //switch (dbModelNumber)
            //{
            //    case "Model100":
            //        radSunroomModel100.Checked = true;
            //        radShowroomModel100.Checked = true;
            //        radWallsModel100.Checked = true;
            //        break;

            //    case "Model200":
            //        radSunroomModel200.Checked = true;
            //        radShowroomModel200.Checked = true;
            //        radWallsModel200.Checked = true;
            //        break;

            //    case "Model300":
            //        radSunroomModel300.Checked = true;
            //        radShowroomModel300.Checked = true;
            //        radWallsModel300.Checked = true;
            //        break;

            //    case "Model400":
            //        radSunroomModel400.Checked = true;
            //        radShowroomModel400.Checked = true;
            //        radWallsModel400.Checked = true;
            //        break;
            //}

            ////Preclick layout
            //string dbLayout = dvPreferences[0][1].ToString();

            //switch (dbLayout)
            //{
            //    //cases based on layout names we decide to save
            //}


            ////Get model preferences that belong to this dealer
            //sdsCustomers.SelectCommand = "SELECT kneewall_height, kneewall_type, transom_type, interior_frame_colour, exterior_frame_colour, interior_panel_skin, exterior_panel_skin, roof_type "
            //                            +"FROM model_preferences "
            //                            +"WHERE dealer_id=" + Session["dealer_id"];

            ////assign the table names to the dataview object
            //DataView dvModelPreferences = (DataView)sdsCustomers.Select(System.Web.UI.DataSourceSelectArguments.Empty);

            //txtKneewallHeight.Text = dvModelPreferences[0][0].ToString();
            //ddlKneewallType.SelectedValue = dvModelPreferences[0][1].ToString();
            //ddlTransomType.SelectedValue = dvModelPreferences[0][2].ToString();
            //ddlInteriorColour.SelectedValue = dvModelPreferences[0][3].ToString();
            //ddlExteriorColour.SelectedValue = dvModelPreferences[0][4].ToString();
            //ddlInteriorSkin.SelectedValue = dvModelPreferences[0][5].ToString();
            //ddlExteriorSkin.SelectedValue = dvModelPreferences[0][6].ToString();

            //switch (dvModelPreferences[0][7].ToString())
            //{
            //    case "Dealer Gable":
            //        radDealerGable.Checked = true;
            //        break;

            //    case "Sunspace Gable":
            //        radSunspaceGable.Checked = true;
            //        break;

            //    case "Studio":
            //        radStudio.Checked = true;
            //        break;
            //}
            //#endregion
        }

        protected void btnLayout_Click(object sender, EventArgs e)
        {
            if (hidExisting.Value == "")
            {
                insertNewCustomer();
            }

            //Move all hidden fields into this array, then put array on the session
            string[] newProjectArray = new string[28];

            newProjectArray[0] = GlobalFunctions.escapeSqlString(hidCountry.Value.ToString());
            newProjectArray[1] = GlobalFunctions.escapeSqlString(hidExisting.Value.ToString());
            Session.Add("customer_id", hidExisting.Value.ToString());
            newProjectArray[2] = GlobalFunctions.escapeSqlString(hidFirstName.Value.ToString());
            newProjectArray[3] = GlobalFunctions.escapeSqlString(hidLastName.Value.ToString());
            newProjectArray[4] = GlobalFunctions.escapeSqlString(hidAddress.Value.ToString());
            newProjectArray[5] = GlobalFunctions.escapeSqlString(hidProvState.Value.ToString());
            newProjectArray[6] = GlobalFunctions.escapeSqlString(hidCity.Value.ToString());
            newProjectArray[7] = GlobalFunctions.escapeSqlString(hidZip.Value.ToString());
            newProjectArray[8] = GlobalFunctions.escapeSqlString(hidPhone.Value.ToString());
            newProjectArray[9] = GlobalFunctions.escapeSqlString(hidCell.Value.ToString());
            newProjectArray[10] = GlobalFunctions.escapeSqlString(hidEmail.Value.ToString());
            newProjectArray[11] = GlobalFunctions.escapeSqlString(hidProjectName.Value.ToString());
            Session.Add("newProjectProjectName", GlobalFunctions.escapeSqlString(hidProjectName.Value.ToString()));
            newProjectArray[12] = GlobalFunctions.escapeSqlString(hidProjectType.Value.ToString());
            Session.Add("newProjectProjectType", GlobalFunctions.escapeSqlString(hidProjectType.Value.ToString()));
            newProjectArray[13] = GlobalFunctions.escapeSqlString(hidModelNumber.Value.ToString());
            newProjectArray[14] = GlobalFunctions.escapeSqlString(hidKneewallType.Value.ToString());
            Session.Add("newProjectKneewallType", GlobalFunctions.escapeSqlString(hidKneewallType.Value.ToString()));
            newProjectArray[15] = GlobalFunctions.escapeSqlString(hidKneewallHeight.Value.ToString());
            Session.Add("newProjectKneewallHeight", GlobalFunctions.escapeSqlString(hidKneewallHeight.Value.ToString()));
            Session.Add("newProjectKneewallTint", GlobalFunctions.escapeSqlString(hidKneewallTint.Value.ToString()));
            newProjectArray[16] = GlobalFunctions.escapeSqlString(hidTransomType.Value.ToString());
            Session.Add("newProjectTransomType", GlobalFunctions.escapeSqlString(hidTransomType.Value.ToString()));
            newProjectArray[17] = GlobalFunctions.escapeSqlString(hidTransomHeight.Value.ToString());
            newProjectArray[18] = GlobalFunctions.escapeSqlString(hidFramingColour.Value.ToString());
            Session.Add("newProjectFramingColour", GlobalFunctions.escapeSqlString(hidFramingColour.Value.ToString()));
            newProjectArray[19] = GlobalFunctions.escapeSqlString(hidInteriorColour.Value.ToString());
            newProjectArray[20] = GlobalFunctions.escapeSqlString(hidInteriorSkin.Value.ToString());
            Session.Add("newProjectInteriorSkin", GlobalFunctions.escapeSqlString(hidInteriorSkin.Value.ToString()));
            newProjectArray[21] = GlobalFunctions.escapeSqlString(hidExteriorColour.Value.ToString());
            newProjectArray[22] = GlobalFunctions.escapeSqlString(hidExteriorSkin.Value.ToString());
            Session.Add("newProjectExteriorSkin", GlobalFunctions.escapeSqlString(hidExteriorSkin.Value.ToString()));
            newProjectArray[23] = GlobalFunctions.escapeSqlString(hidFoamProtected.Value.ToString());
            newProjectArray[24] = GlobalFunctions.escapeSqlString(hidPrefabFloor.Value.ToString());
            Session.Add("newProjectPrefabFloor", GlobalFunctions.escapeSqlString(hidPrefabFloor.Value.ToString()));
            newProjectArray[25] = GlobalFunctions.escapeSqlString(hidRoof.Value.ToString());
            Session.Add("newProjectHasRoof", GlobalFunctions.escapeSqlString(hidRoof.Value.ToString()));
            newProjectArray[26] = GlobalFunctions.escapeSqlString(hidRoofType.Value.ToString());
            Session.Add("newProjectRoofType", GlobalFunctions.escapeSqlString(hidRoofType.Value.ToString()));
            newProjectArray[27] = GlobalFunctions.escapeSqlString(hidLayoutSelection.Value.ToString());
            Session.Add("newProjectTransomTint", GlobalFunctions.escapeSqlString(hidTransomTint.Value.ToString()));

            Session.Add("model", GlobalFunctions.escapeSqlString(hidModelNumber.Value.ToString()));
            Session.Add("kneewallType", GlobalFunctions.escapeSqlString(hidKneewallType.Value.ToString()));
            Session.Add("kneewallHeight", GlobalFunctions.escapeSqlString(hidKneewallHeight.Value.ToString()));
            Session.Add("transomType", GlobalFunctions.escapeSqlString(hidTransomType.Value.ToString()));
            Session.Add("transomHeight", GlobalFunctions.escapeSqlString(hidTransomHeight.Value.ToString()));
            Session.Add("transomColour", GlobalFunctions.escapeSqlString(hidTransomTint.Value.ToString()));

            Session.Add("floorVapourBarrier", "");

            Session.Add("newProjectArray", newProjectArray);

            if (hidRoof.Value.ToString() == "No")
            {
                Session.Add("soffitLength", 0);
            }
            else
            {
                Session.Add("soffitLength", GlobalFunctions.escapeSqlString(hidSoffitLength.Value.ToString()));
            }

            //If custom is selected, send to drawing tool
            if (hidLayoutSelection.Value.ToString() == "Custom")
            {
                Response.Redirect("CustomDrawingTool.aspx");
            }
            else
            {
                if (hidLayoutSelection.Value.ToString() == "1")
                {
                    Session.Add("lineInfo", "0,500,50,50,E,S/25,25,50,325,P,W/25,475,325,325,P,S/475,475,325,50,P,E/");
                }
                else if (hidLayoutSelection.Value.ToString() == "2")
                {
                    Session.Add("lineInfo", "0,500,50,50,E,S/25,25,50,325,P,W/25,100,325,400,P,SW/100,400,400,400,P,S/400,475,400,325,P,SE/475,475,325,50,P,E/");
                }
                else if (hidLayoutSelection.Value.ToString() == "3")
                {
                    Session.Add("lineInfo", "0,500,50,50,E,S/25,25,50,350,P,W/25,75,350,350,P,S/75,150,350,425,P,SW/150,350,425,425,P,S/350,425,425,350,P,SE/425,475,350,350,P,S/475,475,350,50,P,E/");
                }
                else if (hidLayoutSelection.Value.ToString() == "4")
                {
                    Session.Add("lineInfo", "0,450,50,50,E,S/450,450,50,450,E,W/50,50,50,400,P,W/50,450,400,400,P,S/");
                }
                else if (hidLayoutSelection.Value.ToString() == "5")
                {
                    Session.Add("lineInfo", "150,150,0,125,E,W/150,500,125,125,E,S/150,50,75,75,P,N/50,50,75,400,P,W/50,450,400,400,P,S/450,450,400,125,P,E/");
                }
                else if (hidLayoutSelection.Value.ToString() == "6")
                {
                    Session.Add("lineInfo", "0,500,50,50,E,S/450,450,50,400,P,W/450,150,400,400,P,N/150,150,400,350,P,E/150,50,350,350,P,N/50,50,350,50,P,E/");
                }
                else if (hidLayoutSelection.Value.ToString() == "7")
                {
                    Session.Add("lineInfo", "0,450,50,50,E,S/450,450,50,500,E,W/50,50,50,375,P,W/50,125,375,450,P,SW/125,450,450,450,P,S/");
                }
                else if (hidLayoutSelection.Value.ToString() == "8")
                {
                    Session.Add("lineInfo", "150,150,0,100,E,W/150,500,100,100,E,S/150,50,50,50,P,N/50,50,50,350,P,W/50,100,350,400,P,SW/100,450,400,400,P,S/450,450,400,100,P,E/");
                }
                else if (hidLayoutSelection.Value.ToString() == "9")
                {
                    Session.Add("lineInfo", "350,350,0,100,E,W/350,0,100,100,E,N/350,450,50,50,P,S/450,450,50,400,P,W/450,150,400,400,P,N/150,150,400,350,P,E/150,50,350,350,P,N/50,50,350,100,P,E/");
                }
                else if (hidLayoutSelection.Value.ToString() == "10")
                {
                    Session.Add("lineInfo", "50,450,50,50,P,S/450,450,50,450,P,W/450,50,450,450,P,N/50,50,450,50,P,E/");
                } 
                
                if (chkMirrored.Checked == true)
                {
                    if (hidLayoutSelection.Value.ToString() == "4")
                    {
                        Session.Add("lineInfo", "500,50,50,50,E,N/50,50,50,450,E,W/450,450,50,400,P,W/450,50,400,400,P,N/");
                    }
                    else if (hidLayoutSelection.Value.ToString() == "5")
                    {
                        Session.Add("lineInfo", "350,350,0,125,E,W/350,0,125,125,E,N/350,450,75,75,P,S/450,450,75,400,P,W/450,50,400,400,P,N/50,50,400,125,P,E/");
                    }
                    else if (hidLayoutSelection.Value.ToString() == "6")
                    {
                        Session.Add("lineInfo", "0,500,50,50,E,S/50,50,50,400,P,W/50,350,400,400,P,S/350,350,400,350,P,E/350,450,350,350,P,S/450,450,350,50,P,E/");
                    }
                    else if (hidLayoutSelection.Value.ToString() == "7")
                    {
                        Session.Add("lineInfo", "500,50,50,50,E,N/50,50,50,500,E,W/450,450,50,375,P,W/450,375,375,450,P,NW/375,50,450,450,P,N/");
                    }
                    else if (hidLayoutSelection.Value.ToString() == "8")
                    {
                        Session.Add("lineInfo", "350,350,0,100,E,W/350,0,100,100,E,N/350,450,50,50,P,S/450,450,50,350,P,W/450,400,350,400,P,NW/400,50,400,400,P,N/50,50,400,100,P,E/");
                    }
                    else if (hidLayoutSelection.Value.ToString() == "9")
                    {
                        Session.Add("lineInfo", "150,150,0,100,E,W/150,500,100,100,E,S/150,50,50,50,P,N/50,50,50,400,P,W/50,350,400,400,P,S/350,350,400,350,P,E/350,450,350,350,P,S/450,450,350,100,P,E/ ");
                    }
                }

                if (hidRoofType.Value.Contains("Gable"))
                {
                    if (hidLayoutSelection.Value.ToString() == "1")
                    {
                        Session.Add("lineInfo", "225,250,300,300,G,S/25,450,25,25,E,S/50,50,25,300,P,W/50,225,300,300,P,S/250,425,300,300,P,S/425,425,300,25,P,E");
                    }
                    else if (hidLayoutSelection.Value.ToString() == "2")
                    {
                        Session.Add("lineInfo", "225,250,300,300,G,S/25,450,25,25,E,S/50,50,25,250,P,W/50,100,250,300,P,SW/100,225,300,300,P,S/250,375,300,300,P,S/375,425,300,250,P,SE/425,425,250,25,P,E");
                    }
                    else if (hidLayoutSelection.Value.ToString() == "3")
                    {
                        Session.Add("lineInfo", "225,250,300,300,G,S/25,450,25,25,E,S/50,50,25,250,P,W/50,100,250,250,P,S/100,150,250,300,P,SW/150,225,300,300,P,S/250,325,300,300,P,S/325,375,300,250,P,SE/375,425,250,250,P,S/425,425,250,25,P,E");
                    }
                    else if (hidLayoutSelection.Value.ToString() == "5")
                    {
                    }
                    else if (hidLayoutSelection.Value.ToString() == "6")
                    {
                    }
                    else if (hidLayoutSelection.Value.ToString() == "8")
                    {
                    }
                    else if (hidLayoutSelection.Value.ToString() == "9")
                    {
                    }
                    else if (hidLayoutSelection.Value.ToString() == "10")
                    {
                    }

                    if (chkMirrored.Checked == true)
                    {
                        if (hidLayoutSelection.Value.ToString() == "5")
                        {
                        }
                        else if (hidLayoutSelection.Value.ToString() == "6")
                        {
                        }
                        else if (hidLayoutSelection.Value.ToString() == "8")
                        {
                        }
                        else if (hidLayoutSelection.Value.ToString() == "9")
                        {
                        }
                    }
                }

                Response.Redirect("WizardWallsAndMods.aspx");
            }
        }

        protected void btnQuestion3_OrderOnly_Click(object sender, EventArgs e)
        {            
            //if existing is blank, it must be a new customer
            if (hidExisting.Value == "")
            {
                insertNewCustomer();
            }

            if (hidProjectType.Value == "Windows") 
            {
                Response.Redirect("WizardWindowsOnly.aspx");
            }
            else if (hidProjectType.Value == "Door")
            {
                Response.Redirect("WizardDoorOnly.aspx");
            }
            else if (hidProjectType.Value == "Flooring")
            {
                Response.Redirect("WizardFloorOnlyOrder.aspx");
            }
            else if (hidProjectType.Value == "Roof")
            {
                Response.Redirect("WizardRoofOnly.aspx");
            }
        }

        protected void btnQuestion4Walls_Click(object sender, EventArgs e)
        {
            //if existing is blank, it must be a new customer
            if (hidExisting.Value == "")
            {
                insertNewCustomer();
            }

            Session.Add("model", hidModelNumber.Value.ToString());

            //required session stuff before forwarding
            Response.Redirect("WizardWallsOnly.aspx");
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
            + Convert.ToInt32(GlobalFunctions.escapeSqlString(Session["dealer_id"].ToString())) + ",'" + GlobalFunctions.escapeSqlString(hidFirstName.Value) + "','" + GlobalFunctions.escapeSqlString(hidLastName.Value)
            + "','" + GlobalFunctions.escapeSqlString(hidAddress.Value) + "','" + GlobalFunctions.escapeSqlString(hidCity.Value) + "','"
            + GlobalFunctions.escapeSqlString(hidProvState.Value) + "','" + GlobalFunctions.escapeSqlString(hidCountry.Value) + "','" + GlobalFunctions.escapeSqlString(hidZip.Value) + "','" + GlobalFunctions.escapeSqlString(hidPhone.Value)
            + "','" + GlobalFunctions.escapeSqlString(hidCell.Value) + "','" + GlobalFunctions.escapeSqlString(hidEmail.Value) + "',"
            + 1 + ")";

            sdsCustomers.InsertCommand = sqlInsert;
            sdsCustomers.Insert();
        }
    }
}
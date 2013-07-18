﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace SunspaceDealerDesktop
{
    public partial class AddUsers : System.Web.UI.Page
    {
        public string userType;
        public string userGroup;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["loggedIn"] == null)
            {
                //uncomment me when login functionality is working
                Response.Redirect("Login.aspx");
                //Session.Add("loggedIn", "1");
            }

            if (Session["user_type"].ToString() == "D" && Session["user_group"].ToString() == "S")
            {
                //don't allow sales reps to this page
                Response.Redirect("Home.aspx");
            }

            if (Session["user_type"].ToString() == "S" && Session["dealer_id"].ToString() == "-1")
            {
                //if a sunspace user hasn't spoofed, send them there, that is step one
                Response.Redirect("Spoof.aspx");
            }

            if (!IsPostBack)
            {
                //Add countries to country dropdown
                for (int i = 0; i < Constants.COUNTRY_LIST.Count; i++)
                {
                    ddlCountry.Items.Add(Constants.COUNTRY_LIST[i]);
                }

                //if dealer we hide controls accordingly
                if (Session["user_type"].ToString() == "D")
                {
                    UserTypeDiv.Visible = false;
                    UserGroupDiv.Visible = false;
                    DealerListDiv.Visible = false;
                    DealerAdminDiv.Visible = false;
                    userType = "D";
                }
                else
                {
                    //sunspace CSR
                    if (Session["user_type"].ToString() == "S" && Session["user_group"].ToString() == "C")
                    {
                        UserTypeDiv.Visible = false;
                        ddlUserGroup.Items.Add("Admin");
                        ddlUserGroup.Items.Add("Sales Rep");
                        userType = "S";
                    }
                    //sunspace admin
                    else
                    {
                        DealerListDiv.Attributes.Add("style", "display: none;");
                        DealerAdminDiv.Attributes.Add("style", "display: none;");
                        ddlUserType.Items.Add("Sunspace");
                        ddlUserType.Items.Add("Dealer");

                        //will alows land on sunspace by default, so we load with admin/csr on ddlusergroup
                        ddlUserGroup.Items.Add("Admin");
                        ddlUserGroup.Items.Add("Customer Service Rep");
                        userType = "S";
                    }
                    //sunspace user, so populate dealer list

                    //check to see if the list has already been retrieved
                    if (Session["ddlDealers"] == null)
                    {
                        //Get the customers assosciated with this dealer
                        sdsUsers.SelectCommand = "SELECT dealer_name, dealer_id FROM dealers ORDER BY dealer_name";

                        //assign the table names to the dataview object
                        DataView dvDealers = (DataView)sdsUsers.Select(System.Web.UI.DataSourceSelectArguments.Empty);

                        ddlDealers.Items.Clear();

                        for (int i = 0; i < dvDealers.Count; i++)
                        {
                            ddlDealers.Items.Add(new ListItem(dvDealers[i][0].ToString(), dvDealers[i][1].ToString()));
                        }

                        ddlDealers.SelectedValue = Session["dealer_id"].ToString(); //pick your spoofed user by default
                        Session.Add("ddlDealers", ddlDealers);
                    }
                    //if it exists, just populate from session
                    else
                    {
                        ddlDealers = (DropDownList)Session["ddlDealers"];
                        ddlDealers.SelectedValue = Session["dealer_id"].ToString(); //pick your spoofed user by default
                    }
                }
                // set usergroup for jscript access
                userGroup = Session["user_group"].ToString();

                //Set maxlength of textboxes based off constants
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text == "" ||
                txtPassword.Text == "" ||
                txtEmail.Text == "" ||
                txtFirstName.Text == "" ||
                txtLastName.Text == "")
            {
                lblError.Text = "Please enter data into all fields.";
            }
            else
            {
                #region Dealer Sales Rep
                //adding a dealer sales rep
                //Need to check hidden for usergroup as the ddl is built/cleared client side on change of ddlusertype
                if (ddlUserType.SelectedValue == "Dealer" && hidUserGroup.Value == "Sales Rep")
                {
                    DateTime aDate = DateTime.Now;
                    sdsUsers.InsertCommand = "INSERT INTO users (login, password, email_address, enrol_date, last_access, user_type, user_group, reference_id, first_name, last_name, status)"
                                            + "VALUES('"
                                            + txtLogin.Text + "', '"
                                            + GlobalFunctions.CalculateMD5Hash(txtPassword.Text) + "', '"
                                            + txtEmail.Text + "', '"
                                            + aDate.ToString("yyyy/MM/dd") + "', '"
                                            + aDate.ToString("yyyy/MM/dd") + "', '" //default to same-day
                                            + "D" + "', '" //Must be D-S because a dealer can only add users of his dealership
                                            + "S" + "', "
                                            + Convert.ToInt32(Session["dealer_id"].ToString()) + ", '" //reference ID is the dealer id in the dealer table they belong to
                                            + txtFirstName.Text + "', '"
                                            + txtLastName.Text + "', "
                                            + 1 + ")";
                    sdsUsers.Insert();
                    lblError.Text = "Successfully Added";
                }
                #endregion

                #region Dealer Admin
                //adding a head dealer
                else if (ddlUserType.SelectedValue == "Dealer" && hidUserGroup.Value == "Admin")
                {
                    using (SqlConnection aConnection = new SqlConnection(sdsUsers.ConnectionString))
                    {
                        aConnection.Open();
                        SqlCommand aCommand = aConnection.CreateCommand();
                        SqlTransaction aTransaction;

                        // Start a local transaction.
                        aTransaction = aConnection.BeginTransaction("SampleTransaction");

                        // Must assign both transaction object and connection 
                        // to Command object for a pending local transaction
                        aCommand.Connection = aConnection;
                        aCommand.Transaction = aTransaction;

                        try
                        {
                            //Add to dealer table
                            aCommand.CommandText = "INSERT INTO dealers (dealer_name, first_name, last_name, country, multiplier)"
                                                    + "VALUES('"
                                                    + txtDealershipName.Text + "', '"
                                                    + txtFirstName.Text + "', '"
                                                    + txtLastName.Text + "', '"
                                                    + ddlCountry.SelectedValue + "', "
                                                    + Convert.ToDecimal(txtMultiplier.Text)/100 + ")"; //user enters %, so 80% will become 0.8
                            aCommand.ExecuteNonQuery();

                            //Now add user
                            DateTime aDate = DateTime.Now;
                            aCommand.CommandText = "INSERT INTO users (login, password, email_address, enrol_date, last_access, user_type, user_group, reference_id, first_name, last_name, status)"
                                                    + "VALUES('"
                                                    + txtLogin.Text + "', '"
                                                    + GlobalFunctions.CalculateMD5Hash(txtPassword.Text) + "', '"
                                                    + txtEmail.Text + "', '"
                                                    + aDate.ToString("yyyy/MM/dd") + "', '"
                                                    + aDate.ToString("yyyy/MM/dd") + "', '" //default to same-day
                                                    + "D" + "', '" //Must be D-A within this block of logic
                                                    + "A" + "', "
                                                    + Convert.ToInt32(Session["dealer_id"].ToString()) + ", '" //reference ID is the dealer id in the dealer table they belong to
                                                    + txtFirstName.Text + "', '"
                                                    + txtLastName.Text + "', "
                                                    + 1 + ")";
                            aCommand.ExecuteNonQuery();

                            //An entrance into the model preferences table, one entry for each model type
                            #region Model 100 preferences entry
                            aCommand.CommandText = "INSERT INTO model_preferences (dealer_id, model_type, default_filler, interior_panel_skin, exterior_panel_skin, frame_colour, door_type, door_style, door_swing, door_hinge, door_hardware, door_colour, door_glass_tint, door_vinyl_tint, door_screen_type, window_type, window_colour, window_glass_tint, window_vinyl_tint, window_screen_type, sunshade_valance_colour, sunshade_fabric_colour, sunshade_openness, roof_type, roof_interior_skin, roof_exterior_skin, roof_thickness, floor_thickness, floor_metal_barrier, kneewall_height, kneewall_type, kneewall_glass_tint, transom_height, transom_style, transom_glass_tint, transom_vinyl_tint, transom_screen_type, markup)"
                                                    + "VALUES("
                                                    + Convert.ToInt32(Session["dealer_id"].ToString()) + ", "
                                                    + "'100',"
                                                    + "10,"
                                                    + "'White Aluminum Stucco',"
                                                    + "'White Aluminum Stucco',"
                                                    + "'White',"
                                                    //door
                                                    + "'Cabana',"
                                                    + "'Full Screen',"
                                                    + "'Out',"
                                                    + "'R',"
                                                    + "'Satin Silver',"
                                                    + "'White',"
                                                    + "'Clear',"
                                                    + "'Clear',"
                                                    + "'No Screen',"
                                                    //window
                                                    + "'Fixed Vinyl',"
                                                    + "'White',"
                                                    + "'Clear',"
                                                    + "'Clear',"
                                                    + "'No Screen',"
                                                    //sunshade
                                                    + "'White',"
                                                    + "'Chalk',"
                                                    + "'3%',"
                                                    //roof
                                                    + "'Studio',"
                                                    + "'White Aluminum Stucco',"
                                                    + "'White Aluminum Stucco',"
                                                    + "'3',"
                                                    //floor
                                                    + "'4.5',"
                                                    + "0,"
                                                    //kneewall
                                                    + 20d + ","
                                                    + "'Glass',"
                                                    + "'Clear',"
                                                    //transom
                                                    + 20d + ","
                                                    + "'Glass',"
                                                    + "'Clear',"
                                                    + "'Clear',"
                                                    + "'No Screen',"
                                                    + 0.25d
                                                    + ")";
                            aCommand.ExecuteNonQuery();
                            #endregion

                            #region Model 200 preferences entry
                            aCommand.CommandText = "INSERT INTO model_preferences (dealer_id, model_type, default_filler, interior_panel_skin, exterior_panel_skin, frame_colour, door_type, door_style, door_swing, door_hinge, door_hardware, door_colour, door_glass_tint, door_vinyl_tint, door_screen_type, window_type, window_colour, window_glass_tint, window_vinyl_tint, window_screen_type, sunshade_valance_colour, sunshade_fabric_colour, sunshade_openness, roof_type, roof_interior_skin, roof_exterior_skin, roof_thickness, floor_thickness, floor_metal_barrier, kneewall_height, kneewall_type, kneewall_glass_tint, transom_height, transom_style, transom_glass_tint, transom_vinyl_tint, transom_screen_type, markup)"
                                                    + "VALUES("
                                                    + Convert.ToInt32(Session["dealer_id"].ToString()) + ", "
                                                    + "'200',"
                                                    + "10,"
                                                    + "'White Aluminum Stucco',"
                                                    + "'White Aluminum Stucco',"
                                                    + "'White',"
                                //door
                                                    + "'Cabana',"
                                                    + "'Full Screen',"
                                                    + "'Out',"
                                                    + "'R',"
                                                    + "'Satin Silver',"
                                                    + "'White',"
                                                    + "'Clear',"
                                                    + "'Clear',"
                                                    + "'No Screen',"
                                //window
                                                    + "'Vertical 4 Track',"
                                                    + "'White',"
                                                    + "'Clear',"
                                                    + "'Clear',"
                                                    + "'No Screen',"
                                //sunshade
                                                    + "'White',"
                                                    + "'Chalk',"
                                                    + "'3%',"
                                //roof
                                                    + "'Studio',"
                                                    + "'White Aluminum Stucco',"
                                                    + "'White Aluminum Stucco',"
                                                    + "'3',"
                                //floor
                                                    + "'4.5',"
                                                    + "0,"
                                //kneewall
                                                    + 20d + ","
                                                    + "'Glass',"
                                                    + "'Clear',"
                                //transom
                                                    + 20d + ","
                                                    + "'Glass',"
                                                    + "'Clear',"
                                                    + "'Clear',"
                                                    + "'No Screen',"
                                                    + 0.25d
                                                    + ")";
                            aCommand.ExecuteNonQuery();
                            #endregion

                            #region Model 300 preferences entry
                            aCommand.CommandText = "INSERT INTO model_preferences (dealer_id, model_type, default_filler, interior_panel_skin, exterior_panel_skin, frame_colour, door_type, door_style, door_swing, door_hinge, door_hardware, door_colour, door_glass_tint, door_vinyl_tint, door_screen_type, window_type, window_colour, window_glass_tint, window_vinyl_tint, window_screen_type, sunshade_valance_colour, sunshade_fabric_colour, sunshade_openness, roof_type, roof_interior_skin, roof_exterior_skin, roof_thickness, floor_thickness, floor_metal_barrier, kneewall_height, kneewall_type, kneewall_glass_tint, transom_height, transom_style, transom_glass_tint, transom_vinyl_tint, transom_screen_type, markup)"
                                                    + "VALUES("
                                                    + Convert.ToInt32(Session["dealer_id"].ToString()) + ", "
                                                    + "'300',"
                                                    + "10,"
                                                    + "'White Aluminum Stucco',"
                                                    + "'White Aluminum Stucco',"
                                                    + "'White',"
                                //door
                                                    + "'Cabana',"
                                                    + "'Full Screen',"
                                                    + "'Out',"
                                                    + "'R',"
                                                    + "'Satin Silver',"
                                                    + "'White',"
                                                    + "'Clear',"
                                                    + "'Clear',"
                                                    + "'No Screen',"
                                //window
                                                    + "'Horizontal Roller',"
                                                    + "'White',"
                                                    + "'Clear',"
                                                    + "'Clear',"
                                                    + "'No Screen',"
                                //sunshade
                                                    + "'White',"
                                                    + "'Chalk',"
                                                    + "'3%',"
                                //roof
                                                    + "'Studio',"
                                                    + "'White Aluminum Stucco',"
                                                    + "'White Aluminum Stucco',"
                                                    + "'3',"
                                //floor
                                                    + "'4.5',"
                                                    + "0,"
                                //kneewall
                                                    + 20d + ","
                                                    + "'Glass',"
                                                    + "'Clear',"
                                //transom
                                                    + 20d + ","
                                                    + "'Glass',"
                                                    + "'Clear',"
                                                    + "'Clear',"
                                                    + "'No Screen',"
                                                    + 0.25d
                                                    + ")";
                            aCommand.ExecuteNonQuery();
                            #endregion

                            #region Model 400 preferences entry
                            aCommand.CommandText = "INSERT INTO model_preferences (dealer_id, model_type, default_filler, interior_panel_skin, exterior_panel_skin, frame_colour, door_type, door_style, door_swing, door_hinge, door_hardware, door_colour, door_glass_tint, door_vinyl_tint, door_screen_type, window_type, window_colour, window_glass_tint, window_vinyl_tint, window_screen_type, sunshade_valance_colour, sunshade_fabric_colour, sunshade_openness, roof_type, roof_interior_skin, roof_exterior_skin, roof_thickness, floor_thickness, floor_metal_barrier, kneewall_height, kneewall_type, kneewall_glass_tint, transom_height, transom_style, transom_glass_tint, transom_vinyl_tint, transom_screen_type, markup)"
                                                    + "VALUES("
                                                    + Convert.ToInt32(Session["dealer_id"].ToString()) + ", "
                                                    + "'400',"
                                                    + "10,"
                                                    + "'White Aluminum Stucco',"
                                                    + "'White Aluminum Stucco',"
                                                    + "'White',"
                                //door
                                                    + "'Cabana',"
                                                    + "'Full Screen',"
                                                    + "'Out',"
                                                    + "'R',"
                                                    + "'Satin Silver',"
                                                    + "'White',"
                                                    + "'Clear',"
                                                    + "'Clear',"
                                                    + "'No Screen',"
                                //window
                                                    + "'Horizontal Roller',"
                                                    + "'White',"
                                                    + "'Clear',"
                                                    + "'Clear',"
                                                    + "'No Screen',"
                                //sunshade
                                                    + "'White',"
                                                    + "'Chalk',"
                                                    + "'3%',"
                                //roof
                                                    + "'Studio',"
                                                    + "'White Aluminum Stucco',"
                                                    + "'White Aluminum Stucco',"
                                                    + "'3',"
                                //floor
                                                    + "'4.5',"
                                                    + "0,"
                                //kneewall
                                                    + 20d + ","
                                                    + "'Glass',"
                                                    + "'Clear',"
                                //transom
                                                    + 20d + ","
                                                    + "'Glass',"
                                                    + "'Clear',"
                                                    + "'Clear',"
                                                    + "'No Screen',"
                                                    + 0.25d
                                                    + ")";
                            aCommand.ExecuteNonQuery();
                            #endregion

                            //Lastly, a preferences table entry, with defaults
                            aCommand.CommandText = "INSERT INTO preferences (dealer_id, installation_type, model_type, layout, cut_pitch)"
                                                    + "VALUES("
                                                    + Convert.ToInt32(Session["dealer_id"].ToString()) + ", "
                                                    + "'House',"
                                                    + "'200',"
                                                    + "'preset 1',"
                                                    + "1"
                                                    +")";
                            aCommand.ExecuteNonQuery();

                            lblError.Text = "Successfully Added";

                            // Attempt to commit the transaction.
                            aTransaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            lblError.Text = "Commit Exception Type: " + ex.GetType();
                            lblError.Text += "  Message: " + ex.Message;

                            // Attempt to roll back the transaction. 
                            try
                            {
                                aTransaction.Rollback();
                            }
                            catch (Exception ex2)
                            {
                                // This catch block will handle any errors that may have occurred 
                                // on the server that would cause the rollback to fail, such as 
                                // a closed connection.
                                Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                                Console.WriteLine("  Message: {0}", ex2.Message);
                            }
                        }
                    }
                }
                #endregion

                #region Sunspace CSR
                //Sunspace CSR
                else if (ddlUserType.SelectedValue == "Sunspace" && ddlUserGroup.SelectedValue == "Customer Service Rep")
                {
                    //using (SqlConnection aConnection = new SqlConnection(sdsUsers.ConnectionString))
                    //{
                    //    aConnection.Open();
                    //    SqlCommand aCommand = aConnection.CreateCommand();
                    //    SqlTransaction aTransaction;

                    //    // Start a local transaction.
                    //    aTransaction = aConnection.BeginTransaction("SampleTransaction");

                    //    // Must assign both transaction object and connection 
                    //    // to Command object for a pending local transaction
                    //    aCommand.Connection = aConnection;
                    //    aCommand.Transaction = aTransaction;

                    //    try
                    //    {
                    //        //Add to dealer table
                    //        aCommand.CommandText = "INSERT INTO sunspace (dealer_name, first_name, last_name, country, multiplier)"
                    //                                + "VALUES('"
                    //                                + txtLogin.Text + "', '"
                    //                                + txtFirstName.Text + "', '"
                    //                                + txtLastName.Text + "', '"
                    //                                + ddlCountry.SelectedValue + "', "
                    //                                + Convert.ToDecimal(txtMultiplier.Text) / 10 + ")"; //need to change based on question to anthony
                    //        aCommand.ExecuteNonQuery();

                    //        //Now add user
                    //        DateTime aDate = DateTime.Now;
                    //        aCommand.CommandText = "INSERT INTO users (login, password, email_address, enrol_date, last_access, user_type, user_group, reference_id, first_name, last_name, status)"
                    //                                + "VALUES('"
                    //                                + txtLogin.Text + "', '"
                    //                                + GlobalFunctions.CalculateMD5Hash(txtPassword.Text) + "', '"
                    //                                + txtEmail.Text + "', '"
                    //                                + aDate.ToString("yyyy/MM/dd") + "', '"
                    //                                + aDate.ToString("yyyy/MM/dd") + "', '" //default to same-day
                    //                                + "D" + "', '" //Must be D-A within this block of logic
                    //                                + "A" + "', "
                    //                                + Convert.ToInt32(Session["dealer_id"].ToString()) + ", '" //reference ID is the dealer id in the dealer table they belong to
                    //                                + txtFirstName.Text + "', '"
                    //                                + txtLastName.Text + "', "
                    //                                + 1 + ")";
                    //        aCommand.ExecuteNonQuery();

                    //        lblError.Text = "Successfully Added";

                    //        // Attempt to commit the transaction.
                    //        aTransaction.Commit();
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        lblError.Text = "Commit Exception Type: " + ex.GetType();
                    //        lblError.Text += "  Message: " + ex.Message;

                    //        // Attempt to roll back the transaction. 
                    //        try
                    //        {
                    //            aTransaction.Rollback();
                    //        }
                    //        catch (Exception ex2)
                    //        {
                    //            // This catch block will handle any errors that may have occurred 
                    //            // on the server that would cause the rollback to fail, such as 
                    //            // a closed connection.
                    //            Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                    //            Console.WriteLine("  Message: {0}", ex2.Message);
                    //        }
                    //    }
                    //} 
                }
                #endregion

                #region Sunspace Admin
                //Sunspace Admin
                else
                {

                }
                #endregion
            }
        }
    }
}
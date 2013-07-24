using System;
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
        //Will hold the usertype and usergroup that will be accessed through javascript
        public string userType;
        public string userGroup;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedIn"] == null)
            {
                //Must login to view this page
                Response.Redirect("Login.aspx");
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

            //On first load only, not on posts
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
                    userType = "D";
                }
                else
                {
                    //sunspace CSR, so add initial values to dropdown list, and update usertype
                    if (Session["user_type"].ToString() == "S" && Session["user_group"].ToString() == "C")
                    {
                        UserTypeDiv.Visible = false;
                        ddlUserGroup.Items.Add("Admin");
                        ddlUserGroup.Items.Add("Sales Rep");
                        userType = "S";
                    }
                    //sunspace admin, so add initial values to dropdown list, and update usertype
                    else
                    {
                        ddlUserType.Items.Add("Sunspace");
                        ddlUserType.Items.Add("Dealer");

                        //will alows land on sunspace by default, so we load with admin/csr on ddlusergroup
                        ddlUserGroup.Items.Add("Admin");
                        ddlUserGroup.Items.Add("Customer Service Rep");
                        userType = "S";
                    }                    
                }
                // set usergroup for jscript access
                userGroup = Session["user_group"].ToString();

                //Set maxlength of textboxes based off constants
                txtDealershipName.MaxLength = Constants.MAX_LENGTH_DEALERSHIP_NAME;
                txtEmail.MaxLength = Constants.MAX_LENGTH_EMAIL;
                txtFirstName.MaxLength = Constants.MAX_LENGTH_FIRST_NAME;
                txtLastName.MaxLength = Constants.MAX_LENGTH_LAST_NAME;
                txtLogin.MaxLength = Constants.MAX_LENGTH_USER_LOGIN;
                txtMultiplier.MaxLength = Constants.MAX_LENGTH_DEALER_MULTIPLIER;
                txtPassword.MaxLength = Constants.MAX_LENGTH_USER_PASSWORD;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //If any of the textboxes required for all users are empty stop immediately
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
                                            + GlobalFunctions.CalculateSHAHash(txtPassword.Text) + "', '"
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
                    //Requires additional checks if adding a dealer
                    if (txtDealershipName.Text == "" ||
                        txtMultiplier.Text == "")
                    {
                        lblError.Text = "Please enter data into all fields.";
                    }
                    else
                    {
                        //open SQL connection for use with transaction
                        using (SqlConnection aConnection = new SqlConnection(sdsUsers.ConnectionString))
                        {
                            //Open connection, then create a command and a transaction that are linked to it
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
                                                        + (Convert.ToDecimal(txtMultiplier.Text) / 100) + 1 + ")"; //user enters %, so 80% will become 1.8 as a multiplier                               
                                aCommand.ExecuteNonQuery(); //Execute a command that does not return anything

                                aCommand.CommandText = "SELECT dealer_id FROM dealers WHERE dealer_name='" + txtDealershipName.Text + "'";
                                int newDealerId = Convert.ToInt32(aCommand.ExecuteScalar()); //ExecuteScalar returns the value in the first field of the first row of a query. Good for getting one piece of data immediately

                                //Now add user
                                DateTime aDate = DateTime.Now;
                                aCommand.CommandText = "INSERT INTO users (login, password, email_address, enrol_date, last_access, user_type, user_group, reference_id, first_name, last_name, status)"
                                                        + "VALUES('"
                                                        + txtLogin.Text + "', '"
                                                        + GlobalFunctions.CalculateSHAHash(txtPassword.Text) + "', '"
                                                        + txtEmail.Text + "', '"
                                                        + aDate.ToString("yyyy/MM/dd") + "', '"
                                                        + aDate.ToString("yyyy/MM/dd") + "', '" //default to same-day
                                                        + "D" + "', '" //Must be D-A within this block of logic
                                                        + "A" + "', "
                                                        + newDealerId + ", '" //reference ID is the dealer id in the dealer table they belong to
                                                        + txtFirstName.Text + "', '"
                                                        + txtLastName.Text + "', "
                                                        + 1 + ")";
                                aCommand.ExecuteNonQuery(); //Execute a command that does not return anything

                                //An entrance into the model preferences table, one entry for each model type
                                //These have hardcoded default values that any added dealer will have as their preferences.
                                //They can be edited here.

                                #region Model 100 preferences entry
                                aCommand.CommandText = "INSERT INTO model_preferences (dealer_id, model_type, default_filler, interior_panel_skin, exterior_panel_skin, frame_colour, door_type, door_style, door_swing, door_hinge, door_hardware, door_colour, door_glass_tint, door_vinyl_tint, door_screen_type, window_type, window_colour, window_glass_tint, window_vinyl_tint, window_screen_type, sunshade_valance_colour, sunshade_fabric_colour, sunshade_openness, roof_type, roof_interior_skin, roof_exterior_skin, roof_thickness, floor_thickness, floor_metal_barrier, kneewall_height, kneewall_type, kneewall_glass_tint, transom_height, transom_style, transom_glass_tint, transom_vinyl_tint, transom_screen_type, markup)"
                                                        + "VALUES("
                                                        + newDealerId + ", "
                                                        + "'M100',"
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
                                aCommand.ExecuteNonQuery(); //Execute a command that does not return anything
                                #endregion

                                #region Model 200 preferences entry
                                aCommand.CommandText = "INSERT INTO model_preferences (dealer_id, model_type, default_filler, interior_panel_skin, exterior_panel_skin, frame_colour, door_type, door_style, door_swing, door_hinge, door_hardware, door_colour, door_glass_tint, door_vinyl_tint, door_screen_type, window_type, window_colour, window_glass_tint, window_vinyl_tint, window_screen_type, sunshade_valance_colour, sunshade_fabric_colour, sunshade_openness, roof_type, roof_interior_skin, roof_exterior_skin, roof_thickness, floor_thickness, floor_metal_barrier, kneewall_height, kneewall_type, kneewall_glass_tint, transom_height, transom_style, transom_glass_tint, transom_vinyl_tint, transom_screen_type, markup)"
                                                        + "VALUES("
                                                        + newDealerId + ", "
                                                        + "'M200',"
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
                                aCommand.ExecuteNonQuery(); //Execute a command that does not return anything
                                #endregion

                                #region Model 300 preferences entry
                                aCommand.CommandText = "INSERT INTO model_preferences (dealer_id, model_type, default_filler, interior_panel_skin, exterior_panel_skin, frame_colour, door_type, door_style, door_swing, door_hinge, door_hardware, door_colour, door_glass_tint, door_vinyl_tint, door_screen_type, window_type, window_colour, window_glass_tint, window_vinyl_tint, window_screen_type, sunshade_valance_colour, sunshade_fabric_colour, sunshade_openness, roof_type, roof_interior_skin, roof_exterior_skin, roof_thickness, floor_thickness, floor_metal_barrier, kneewall_height, kneewall_type, kneewall_glass_tint, transom_height, transom_style, transom_glass_tint, transom_vinyl_tint, transom_screen_type, markup)"
                                                        + "VALUES("
                                                        + newDealerId + ", "
                                                        + "'M300',"
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
                                aCommand.ExecuteNonQuery(); //Execute a command that does not return anything
                                #endregion

                                #region Model 400 preferences entry
                                aCommand.CommandText = "INSERT INTO model_preferences (dealer_id, model_type, default_filler, interior_panel_skin, exterior_panel_skin, frame_colour, door_type, door_style, door_swing, door_hinge, door_hardware, door_colour, door_glass_tint, door_vinyl_tint, door_screen_type, window_type, window_colour, window_glass_tint, window_vinyl_tint, window_screen_type, sunshade_valance_colour, sunshade_fabric_colour, sunshade_openness, roof_type, roof_interior_skin, roof_exterior_skin, roof_thickness, floor_thickness, floor_metal_barrier, kneewall_height, kneewall_type, kneewall_glass_tint, transom_height, transom_style, transom_glass_tint, transom_vinyl_tint, transom_screen_type, markup)"
                                                        + "VALUES("
                                                        + newDealerId + ", "
                                                        + "'M400',"
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
                                aCommand.ExecuteNonQuery(); //Execute a command that does not return anything
                                #endregion

                                //Lastly, a preferences table entry, with defaults
                                aCommand.CommandText = "INSERT INTO preferences (dealer_id, installation_type, model_type, layout, cut_pitch)"
                                                        + "VALUES("
                                                        + newDealerId + ", "
                                                        + "'House',"
                                                        + "'M200',"
                                                        + "'preset 1',"
                                                        + "1"
                                                        + ")";
                                aCommand.ExecuteNonQuery(); //Execute a command that does not return anything

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
                }
                #endregion

                #region Sunspace CSR
                //Sunspace CSR
                else if (ddlUserType.SelectedValue == "Sunspace" && ddlUserGroup.SelectedValue == "Customer Service Rep")
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
                            aCommand.CommandText = "INSERT INTO sunspace (position, first_name, last_name)"
                                                    + "VALUES('"
                                                    + "CSR" + "', '" //can only be CSR at this point, can be changed to a variable later
                                                    + txtFirstName.Text + "', '"
                                                    + txtLastName.Text + "'"
                                                    + ")";
                            aCommand.ExecuteNonQuery(); //Execute a command that does not return anything

                            aCommand.CommandText = "SELECT sunspace_id FROM sunspace WHERE position='" + "CSR" + "' AND first_name='" + txtFirstName.Text + "' AND last_name='" + txtLastName.Text + "'";
                            int newSunspaceId = Convert.ToInt32(aCommand.ExecuteScalar()); //ExecuteScalar returns the value in the first field of the first row of a query. Good for getting one piece of data immediately

                            //Now add user
                            DateTime aDate = DateTime.Now;
                            aCommand.CommandText = "INSERT INTO users (login, password, email_address, enrol_date, last_access, user_type, user_group, reference_id, first_name, last_name, status)"
                                                    + "VALUES('"
                                                    + txtLogin.Text + "', '"
                                                    + GlobalFunctions.CalculateSHAHash(txtPassword.Text) + "', '"
                                                    + txtEmail.Text + "', '"
                                                    + aDate.ToString("yyyy/MM/dd") + "', '"
                                                    + aDate.ToString("yyyy/MM/dd") + "', '" //default to same-day
                                                    + "S" + "', '" //Must be S-C within this block of logic
                                                    + "C" + "', "
                                                    + newSunspaceId + ", '" //reference ID is the dealer id in the dealer table they belong to
                                                    + txtFirstName.Text + "', '"
                                                    + txtLastName.Text + "', "
                                                    + 1 + ")";
                            aCommand.ExecuteNonQuery(); //Execute a command that does not return anything

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

                #region Sunspace Admin
                //Sunspace Admin
                else
                {
                    //You currently may not add an admin in such a way.  Such a decision should come from high up and be done directly through a database query.
                }
                #endregion
            }
        }
    }
}
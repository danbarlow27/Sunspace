using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SunspaceDealerDesktop
{
    public partial class WizardFloorOnlyOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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

            #region Inch dropdown population
            //ListItems to be used in multiple dropdown lists for decimal points
            //This should eventually be stored in the constants file
            ListItem lst0 = new ListItem("---", "0", true); //0, i.e. no decimal value, selected by default
            ListItem lst18 = new ListItem("1/8", ".125");
            ListItem lst14 = new ListItem("1/4", ".25");
            ListItem lst38 = new ListItem("3/8", ".375");//
            ListItem lst12 = new ListItem("1/2", ".5");
            ListItem lst58 = new ListItem("5/8", ".625");
            ListItem lst34 = new ListItem("3/4", ".75");
            ListItem lst78 = new ListItem("7/8", ".875");

            ddlLedgerSetbackInches.Items.Add(lst0);
            ddlLedgerSetbackInches.Items.Add(lst18);
            ddlLedgerSetbackInches.Items.Add(lst14);
            ddlLedgerSetbackInches.Items.Add(lst38);
            ddlLedgerSetbackInches.Items.Add(lst12);
            ddlLedgerSetbackInches.Items.Add(lst58);
            ddlLedgerSetbackInches.Items.Add(lst34);
            ddlLedgerSetbackInches.Items.Add(lst78);

            ddlSidesSetbackInches.Items.Add(lst0);
            ddlSidesSetbackInches.Items.Add(lst18);
            ddlSidesSetbackInches.Items.Add(lst14);
            ddlSidesSetbackInches.Items.Add(lst38);
            ddlSidesSetbackInches.Items.Add(lst12);
            ddlSidesSetbackInches.Items.Add(lst58);
            ddlSidesSetbackInches.Items.Add(lst34);
            ddlSidesSetbackInches.Items.Add(lst78);

            ddlJointSetbackInches.Items.Add(lst0);
            ddlJointSetbackInches.Items.Add(lst18);
            ddlJointSetbackInches.Items.Add(lst14);
            ddlJointSetbackInches.Items.Add(lst38);
            ddlJointSetbackInches.Items.Add(lst12);
            ddlJointSetbackInches.Items.Add(lst58);
            ddlJointSetbackInches.Items.Add(lst34);
            ddlJointSetbackInches.Items.Add(lst78);

            ddlFrontSetbackInches.Items.Add(lst0);
            ddlFrontSetbackInches.Items.Add(lst18);
            ddlFrontSetbackInches.Items.Add(lst14);
            ddlFrontSetbackInches.Items.Add(lst38);
            ddlFrontSetbackInches.Items.Add(lst12);
            ddlFrontSetbackInches.Items.Add(lst58);
            ddlFrontSetbackInches.Items.Add(lst34);
            ddlFrontSetbackInches.Items.Add(lst78);
            #endregion            
        }

        protected void btnQuestion1_Click(object sender, EventArgs e)
        {
            Session.Add("floorType", ddlFloorType.SelectedValue);
            Session.Add("floorProjection", txtProjectionDisplay.Text);
            Session.Add("floorWidth", txtWidthDisplay.Text);
            Session.Add("floorThickness", ddlFloorThickness.SelectedValue);
            Session.Add("floorVapourBarrier", chkVapourBarrier.Checked);

            int panelNumber = 0;
            float lastPanelSize = 0f;

            if (ddlFloorType.SelectedValue == "Thermadeck")
            {
                float tempFloat = Convert.ToSingle(txtWidthDisplay.Text) / Constants.THERMADECK_PANEL_WIDTH;
                panelNumber = (int)tempFloat;
                float panelFloat = Convert.ToSingle(txtWidthDisplay.Text) / Constants.THERMADECK_PANEL_WIDTH;

                if (panelFloat > panelNumber)
                {
                    lastPanelSize = Convert.ToSingle(txtWidthDisplay.Text) - (panelNumber * Constants.THERMADECK_PANEL_WIDTH);
                    panelNumber++;
                }
                else
                {
                    lastPanelSize = Constants.THERMADECK_PANEL_WIDTH;
                }
            }

            if (ddlFloorType.SelectedValue == "Alumadeck")
            {
                //Change thermadeck constants to alumadeck constants, if required in the future

                //panelNumber = Convert.ToInt32(Convert.ToSingle(txtWidthDisplay.Text) / Constants.THERMADECK_PANEL_WIDTH);
                //float panelFloat = Convert.ToSingle(txtWidthDisplay.Text) / Constants.THERMADECK_PANEL_WIDTH;

                //if (panelFloat > panelNumber)
                //{
                //    lastPanelSize = Convert.ToSingle(txtWidthDisplay.Text) - (panelNumber * Constants.THERMADECK_PANEL_WIDTH);
                //    panelNumber++;
                //}
            }

            Session.Add("floorPanelNumber", panelNumber);
            Session.Add("floorLastPanelSize", lastPanelSize);

            Session.Add("floorLedgerSetback", (Convert.ToSingle(txtLedgerSetback.Text) + Convert.ToSingle(ddlLedgerSetbackInches.SelectedValue)));
            Session.Add("floorFrontSetback", (Convert.ToSingle(txtFrontSetback.Text) + Convert.ToSingle(ddlFrontSetbackInches.SelectedValue)));
            Session.Add("floorSidesSetback", (Convert.ToSingle(txtSidesSetback.Text) + Convert.ToSingle(ddlSidesSetbackInches.SelectedValue)));
            Session.Add("floorJointSetback", (Convert.ToSingle(txtJointSetback.Text) + Convert.ToSingle(ddlJointSetbackInches.SelectedValue)));

            //Now I know there's a column x row grid of panels
            //Response.Redirect("ProjectPreview.aspx");

            // Hit the database
            using (SqlConnection aConnection = new SqlConnection(sdsDBConnection.ConnectionString))
            {
                aConnection.Open();
                SqlCommand aCommand = aConnection.CreateCommand();
                SqlTransaction aTransaction;
                SqlDataReader aReader;

                // Start a local transaction.
                aTransaction = aConnection.BeginTransaction("SampleTransaction");

                // Must assign both transaction object and connection 
                // to Command object for a pending local transaction
                aCommand.Connection = aConnection;
                aCommand.Transaction = aTransaction;

                try
                {
                    //Project
                    #region Project

                    var newGuid = Guid.NewGuid();

                    aCommand.CommandText = "INSERT INTO projects(project_type, installation_type, project_name, customer_id, user_id, date_created, status, revised_date, revised_user_id, msrp, project_notes, "
                                            + "hidden, cut_pitch) VALUES ("
                                            + "'Floor', " 
                                            + "'None', "
                                            //+ "'" + Session["newProjectProjectName"] + "', "
                                            + "'" + newGuid + "', "
                                            //+ Session["customer_id"] + ", "
                                            + "1, "
                                            //+ Session["user_id"] + ", "
                                            + "1, "
                                            + "'" + DateTime.Now.ToString("yyyy/MM/dd") + "', "
                                            + "'" + "Active" + "', "
                                            + "'" + DateTime.Now.ToString("yyyy/MM/dd") + "', "
                                            //+ Session["user_id"] + ", "
                                            + "1, "
                                            + 0 + ", "
                                            + 0 + ", "
                                            + 0 + ", "
                                            + 1
                                            + ");";
                    aCommand.ExecuteNonQuery(); //Execute a command that does not return anything
                    #endregion

                    //Get project_id for use in below statements
                    aCommand.CommandText = "SELECT project_id FROM projects WHERE project_name = '" + newGuid + "'"; // Replace newGuid with Session["newProjectProjectName"]
                    aReader = aCommand.ExecuteReader();
                    aReader.Read();

                    int project_id = Convert.ToInt32(aReader[0]);
                    aReader.Close();

                    aTransaction.Commit();

                    #region Floor
                    if (Session["floorType"].ToString() == "Thermadeck")
                    {
                        int vapourBarrier = 0;
                        if (Session["floorVapourBarrier"].ToString() == "true")
                        {
                            vapourBarrier = 1;
                        }
                        aCommand.CommandText = "INSERT INTO floors(project_id, floor_index, floor_type, projection, width, thickness, number_items, vapor_barrier) VALUES("
                                                + project_id + ", "
                                                + 0 + ", "
                                                + "'Thermadeck'" + ", "
                                                + Convert.ToSingle(Session["floorProjection"]) + ", "
                                                + Convert.ToSingle(Session["floorWidth"]) + ", "
                                                + Convert.ToSingle(Session["floorThickness"]) + ", "
                                                + Convert.ToInt32(Session["floorPanelNumber"]) + ", "
                                                + vapourBarrier
                                                + ");";
                        aCommand.ExecuteNonQuery();

                        for (int i = 0; i < Convert.ToInt32(Session["floorPanelNumber"]); i++)
                        {
                            float panelWidth = Constants.THERMADECK_PANEL_WIDTH;
                            float leftSetBack = Convert.ToSingle(Session["floorJointSetback"]);
                            float rightSetBack = Convert.ToSingle(Session["floorJointSetback"]);

                            if (i == Convert.ToInt32(Session["floorPanelNumber"])-1)
                            {
                                panelWidth = Convert.ToSingle(Session["floorLastPanelSize"]);
                                rightSetBack = Convert.ToSingle(Session["floorSidesSetback"]);
                            }

                            if (i == 0)
                            {
                                leftSetBack = Convert.ToSingle(Session["floorSidesSetback"]);
                            }

                            aCommand.CommandText = "INSERT INTO thermadeck_panels(project_id, roof_index, roof_view, item_index, projection, width, set_back, back_setback, front_setback, right_setback, left_setback) VALUES("
                                                + project_id + ", "
                                                + 0 + ", "
                                                + "'F'" + ", "
                                                + i + ", "
                                                + Convert.ToSingle(Session["floorProjection"]) + ", "
                                                + panelWidth + ", "
                                                + 0 + ", " //What is normal set_back? Soffit length?
                                                + Convert.ToSingle(Session["floorLedgerSetback"]) + ", "
                                                + Convert.ToSingle(Session["floorFrontSetback"]) + ", "
                                                + rightSetBack + ", "
                                                + leftSetBack
                                                + ");";
                            aCommand.ExecuteNonQuery();
                        }
                    }
                    #endregion 
                }
                catch (Exception ex)
                {
                    int hi;
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    //lblError.Text = "Commit Exception Type: " + ex.GetType();
                    //lblError.Text += "  Message: " + ex.Message;

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
                        //lblError.Text = "Rollback Exception Type: " + ex2.GetType();
                        //lblError.Text += "  Message: " + ex2.Message;
                    }
                }
            }
        }

        //This function will add a new project, a new floor, and either Thermadeck or Alumadeck panels
        //This happens at an applicable time when the page is completed and has been posted back.
        protected void insertNewFloor()
        {
            //sdsFloors.SelectCommand = "SELECT * FROM customers"; 
            //DataView dvCustomers = (DataView)sdsFloors.Select(System.Web.UI.DataSourceSelectArguments.Empty);

            //If new customer is selected, lets add this customer to our customer list
            //CHANGEME Uses logged in session number as dealerID, this is likely userID in the future, and needs to be changed

            //string sqlInsert = "INSERT INTO customers (dealer_id,first_name,last_name,address,city,prov_city,country,zip_postal,main_phone,cell_phone,email,accept_email)"
            //+ "VALUES("
            //+ Convert.ToInt32(GlobalFunctions.escapeSqlString(Session["dealer_id"].ToString())) + ",'" + GlobalFunctions.escapeSqlString(hidFirstName.Value) + "','" + GlobalFunctions.escapeSqlString(hidLastName.Value)
            //+ "','" + GlobalFunctions.escapeSqlString(hidAddress.Value) + "','" + GlobalFunctions.escapeSqlString(hidCity.Value) + "','"
            //+ GlobalFunctions.escapeSqlString(hidProvState.Value) + "','" + GlobalFunctions.escapeSqlString(hidCountry.Value) + "','" + GlobalFunctions.escapeSqlString(hidZip.Value) + "','" + GlobalFunctions.escapeSqlString(hidPhone.Value)
            //+ "','" + GlobalFunctions.escapeSqlString(hidCell.Value) + "','" + GlobalFunctions.escapeSqlString(hidEmail.Value) + "',"
            //+ 1 + ")";

            //sdsFloors.InsertCommand = sqlInsert;
            //sdsFloors.Insert();
        }

    }
}
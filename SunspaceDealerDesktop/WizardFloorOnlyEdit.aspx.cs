using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SunspaceDealerDesktop
{
    public partial class WizardFloorOnlyEdit : System.Web.UI.Page
    {
        protected int projectId = 121; //get it from the session

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

            using (SqlConnection aConnection = new SqlConnection(sdsDBConnection.ConnectionString))
            {
                aConnection.Open();
                SqlCommand aCommand = aConnection.CreateCommand();
                SqlTransaction aTransaction;
                //SqlDataReader aReader;

                // Start a local transaction.
                aTransaction = aConnection.BeginTransaction("SampleTransaction");

                // Must assign both transaction object and connection 
                // to Command object for a pending local transaction
                aCommand.Connection = aConnection;
                aCommand.Transaction = aTransaction;
                
                // Floor variables
                string floorType = "";
                float projection;
                float width;
                float thickness;
                int numberItems;
                byte vaporBarrier;

                // Specific Panels
                float setBack;
                float backSetback;
                float frontSetback;
                float rightSetback;
                float leftSetback;

                try
                {
                    //get the door
                    aCommand.CommandText = "SELECT floor_type, projection, width, thickness, number_items, vapor_barrier FROM floors WHERE project_id = '" + projectId + "'";
                    SqlDataReader projectReader = aCommand.ExecuteReader();

                    // If the door is found
                    if (projectReader.HasRows)
                    {
                        projectReader.Read();

                        // Populate the door fields
                        floorType = Convert.ToString(projectReader[0]);
                        projection = Convert.ToSingle(projectReader[1]);
                        width = Convert.ToSingle(projectReader[2]);
                        thickness = Convert.ToSingle(projectReader[3]);
                        numberItems = Convert.ToInt32(projectReader[4]);
                        vaporBarrier = Convert.ToByte(projectReader[5]);

                        projectReader.Close();

                        ddlFloorType.SelectedValue = floorType;
                        txtWidthDisplay.Text = Convert.ToString(width);
                        txtProjectionDisplay.Text = Convert.ToString(projection);
                        ddlFloorThickness.Text = Convert.ToString(thickness);
                        chkVapourBarrier.Checked = Convert.ToBoolean(vaporBarrier);
                    }

                    if (floorType == "Thermadeck")
                    {
                        //thermadeck panel
                        aCommand.CommandText = "SELECT set_back, back_setback, front_setback, right_setback, left_setback FROM thermadeck_panels WHERE project_id = '" + projectId + "'";
                        projectReader = aCommand.ExecuteReader();

                        // If the door is found
                        if (projectReader.HasRows)
                        {
                            projectReader.Read();

                            // Populate the door fields
                            setBack = Convert.ToSingle(projectReader[0]);
                            backSetback = Convert.ToSingle(projectReader[1]);
                            frontSetback = Convert.ToSingle(projectReader[2]);
                            rightSetback = Convert.ToSingle(projectReader[3]);
                            leftSetback = Convert.ToSingle(projectReader[4]);

                            projectReader.Close();

                            txtLedgerSetback.Text = Convert.ToString(backSetback);
                            txtFrontSetback.Text = Convert.ToString(frontSetback);
                            txtSidesSetback.Text = Convert.ToString(rightSetback);
                        }
                    }
                }
                catch (Exception ex)
                {
                    //lblError.Text = "Commit Exception Type: " + ex.GetType();
                    //lblError.Text += "  Message: " + ex.Message;

                    // Attempt to roll back the transaction. 
                    try
                    {
                        aTransaction.Rollback();
                    }
                    catch (Exception ex2)
                    {
                        //This catch block will handle any errors that may have occurred 
                        //on the server that would cause the rollback to fail, such as 
                        //a closed connection.
                        //lblError.Text = "Rollback Exception Type: " + ex2.GetType();
                        //lblError.Text += "  Message: " + ex2.Message;
                    }
                }
            }
        }
    }
}
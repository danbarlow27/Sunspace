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
            
            if (Convert.ToInt32(Session["dealer_id"].ToString()) > -1 && Session["user_group"].ToString() == "S")
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
                //if dealer we hide controls accordingly
                if (Session["user_type"].ToString() == "D")
                {
                    UserTypeDiv.Visible = false;
                    UserGroupDiv.Visible = false;
                    DealerListDiv.Visible = false;
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
                        sdsUsers.SelectCommand = "SELECT dealer_name FROM dealers ORDER BY dealer_name";

                        //assign the table names to the dataview object
                        DataView dvDealers = (DataView)sdsUsers.Select(System.Web.UI.DataSourceSelectArguments.Empty);

                        ddlDealers.Items.Clear();

                        for (int i = 0; i < dvDealers.Count; i++)
                        {
                            ddlDealers.Items.Add(dvDealers[i][0].ToString());
                        }

                        Session.Add("ddlDealers", ddlDealers);
                    }
                    //if it exists, just populate from session
                    else
                    {
                        ddlDealers = (DropDownList)Session["ddlDealers"];
                    }
                }
                // set usergroup for jscript access
                userGroup = Session["user_group"].ToString();
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
                //adding a dealer sales rep
                if (ddlUserType.SelectedValue == "Dealer" && ddlUserGroup.SelectedValue == "Sales Rep")
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
                //adding a head dealer
                else if (ddlUserType.SelectedValue == "Dealer" && ddlUserGroup.SelectedValue == "Admin")
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
                            ////Add to dealer table
                            //aCommand.CommandText = "INSERT INTO dealers (dealer_name, first_name, last_name, country, multiplier)"
                            //                        + "VALUES('"
                            //                        + txtLogin.Text + "', '"
                            //                        + txtFirstName.Text + "', '"
                            //                        + txtLastName.Text + "', '"
                            //                        + ddlCountry.SelectedValue + "', "
                            //                        + Convert.ToInt32(txtMultiplier.Text) + ")";
                            //aCommand.ExecuteNonQuery();

                            ////Now add user
                            //DateTime aDate = DateTime.Now;
                            //sdsUsers.InsertCommand = "INSERT INTO users (login, password, email_address, enrol_date, last_access, user_type, user_group, reference_id, first_name, last_name, status)"
                            //                        + "VALUES('"
                            //                        + txtLogin.Text + "', '"
                            //                        + GlobalFunctions.CalculateMD5Hash(txtPassword.Text) + "', '"
                            //                        + txtEmail.Text + "', '"
                            //                        + aDate.ToString("yyyy/MM/dd") + "', '"
                            //                        + aDate.ToString("yyyy/MM/dd") + "', '" //default to same-day
                            //                        + "D" + "', '" //Must be D-S because a dealer can only add users of his dealership
                            //                        + "S" + "', "
                            //                        + Convert.ToInt32(Session["dealer_id"].ToString()) + ", '" //reference ID is the dealer id in the dealer table they belong to
                            //                        + txtFirstName.Text + "', '"
                            //                        + txtLastName.Text + "', "
                            //                        + 1 + ")";
                            //sdsUsers.Insert();
                            //lblError.Text = "Successfully Added";

                            // Attempt to commit the transaction.
                            //aTransaction.Commit();
                            //Console.WriteLine("Both records are written to database.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Commit Exception Type: {0}", ex.GetType());
                            Console.WriteLine("  Message: {0}", ex.Message);

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
                //Sunspace CSR
                else if (ddlUserType.SelectedValue == "Sunspace" && ddlUserGroup.SelectedValue == "Customer Service Rep")
                {

                }
                //Sunspace Admin
                else
                {

                }
            }
    //        div id="UserTypeDiv" runat="server">
    //    <asp:Label ID="lblUserType" runat="server" Text="User type:"></asp:Label>
    //    <asp:DropDownList ID="ddlUserType" runat="server"></asp:DropDownList>
    //    <br /><br />
    //</div>
    //<div id="UserGroupDiv" runat="server">
    //    <asp:Label ID="lblUserGroup" runat="server" Text="User group:"></asp:Label>
    //    <asp:DropDownList ID="ddlUserGroup" runat="server"></asp:DropDownList>
    //    <br /><br />
    //</div>
    //<asp:Label ID="lblLogin" runat="server" Text="Login:"></asp:Label>
    //<asp:TextBox ID="txtLogin" runat="server"></asp:TextBox>
    //<br /><br />
    //<asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label>
    //<asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
    //<br /><br />
    //<asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
    //<asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
    //<br /><br />
    //<asp:Label ID="lblFirstName" runat="server" Text="First Name:"></asp:Label>
    //<asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
    //<br /><br />
    //<asp:Label ID="lblLastName" runat="server" Text="Last Name:"></asp:Label>
    //<asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
    //<br /><br />
    //<asp:Button id="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

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

            if (!IsPostBack)
            {
                //if >-1 it cannot be a sunspace user, so we hide controls accordingly
                if (Convert.ToInt32(Session["dealer_id"].ToString()) > -1)
                {
                    UserTypeDiv.Visible = false;
                    UserGroupDiv.Visible = false;
                    DealerListDiv.Visible = false;
                    userType = "D";
                }
                else
                {
                    //sunspace CSR
                    if (Convert.ToInt32(Session["dealer_id"].ToString()) == -1 && Session["user_group"].ToString() == "C")
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
                //dealer can only enter users that belong to his dealership
                if (Convert.ToInt32(Session["dealer_id"].ToString()) > -1)
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
                //sunspace csr
                else if (Convert.ToInt32(Session["dealer_id"].ToString()) == -1 && userGroup == "C")
                {
                    if (ddlUserGroup.SelectedValue == "Admin")
                    {
                        //create new dealer in dealer table
                        //select new dealer
                        //add user with reference to dealer table
                    }
                    //sales rep

                }
                //sunspace admin
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
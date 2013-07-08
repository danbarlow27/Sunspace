﻿using System;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedIn"] == null)
            {
                //uncomment me when login functionality is working
                Response.Redirect("Login.aspx");
                //Session.Add("loggedIn", "1");
            }

            //if >-1 it cannot be a sunspace user, so we hide controls accordingly
            if (Convert.ToInt32(Session["dealer_id"].ToString()) > -1)
            {
                UserGroupDiv.Visible = false;
                UserTypeDiv.Visible = false;
            }
            else
            {
                //populate user type
                ddlUserType.Items.Add("Sunspace");
                ddlUserType.Items.Add("Dealer");

                //populate user group
                ddlUserGroup.Items.Add("Admin");
                ddlUserGroup.Items.Add("Sales Rep"); //CSR if sunspace selected, SR if dealer selected.
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
                    sdsUsers.InsertCommand = "INSERT INTO users (login, password, email, enrol_date, last_access, user_type, user_group, reference_id, first_name, last_name, status)"
                                            + "VALUES('"
                                            + txtLogin.Text + "', '"
                                            + txtPassword.Text + "', '"
                                            + txtEmail.Text + "', '"
                                            + aDate.ToString("yyyy/MM/dd") + "', "
                                            + null + ", '" //They havn't accessed as they havn't logged in before
                                            + "D" + "', '" //Must be D-S because a dealer can only add users of his dealership
                                            + "S" + "', "
                                            + Convert.ToInt32(Session["dealer_id"].ToString()) + ", '" //reference ID is the dealer id in the dealer table they belong to
                                            + txtFirstName.Text + "', '"
                                            + txtLastName.Text + "', "
                                            + 1;
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
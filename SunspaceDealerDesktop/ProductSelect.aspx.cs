/*
 * Dan Barlow
 * November 6, 2012
 * ProductSelect.aspx version 1.0
 */ 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sunspace
{
    public partial class ProductSelect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedIn"] != null)
            {
                if (Session["viewSelected"] != null)
                {
                    radButtonRow.CssClass = "hideElement";

                    Label firstLabel = (Label)Master.FindControl("lblUpdate");
                    if (firstLabel != null)
                    {
                        firstLabel.Text = "VIEW";
                    }

                    Label secondLabel = (Label)Master.FindControl("lblPartNumTitle");
                    if (secondLabel != null)
                    {
                        secondLabel.Text = "CATALOGUE";
                    }
                }
                else if (Session["updateSelected"] != null)
                {
                    radButtonRow.CssClass = "showElementNoClass";

                    Label firstLabel = (Label)Master.FindControl("lblUpdate");
                    if (firstLabel != null)
                    {
                        firstLabel.Text = "UPDATE";
                    }

                    Label secondLabel = (Label)Master.FindControl("lblPartNumTitle");
                    if (secondLabel != null)
                    {
                        secondLabel.Text = "CATALOGUE";
                    }
                }

                if (radUpdatePricing.Checked && Session["pricingOnly"] == null)
                {
                    Session.Add("pricingOnly", true);
                }
                else if (radUpdateGeneral.Checked && Session["pricingOnly"] != null)
                {
                    Session.Remove("pricingOnly");
                }

                if (!Page.IsPostBack)
                {
                    if (Session["pricingOnly"] != null)
                    {
                        radUpdatePricing.Checked = true;
                    }
                    //set up a dataview object to hold table names for the first drop down
                    System.Data.DataView tableList = new System.Data.DataView();

                    //select table names
                    datSelectDataSource.SelectCommand = "SELECT name FROM sys.tables WHERE name != 'tblColor' AND name != 'tblSchematicParts' AND name != 'tblParts' AND name != 'tblLengthUnits'  AND name != 'tblAudits' AND name != 'tblSalesOrders' AND name != 'tblSalesOrderItems' ORDER BY name ASC";

                    //assign the table names to the dataview object
                    tableList = (System.Data.DataView)datSelectDataSource.Select(System.Web.UI.DataSourceSelectArguments.Empty);

                    //variable to determine amount of rows in the dataview object
                    int rowCount = tableList.Count;

                    //populate first drop down
                    for (int i = 0; i < rowCount; i++)
                    {
                        string textString = tableList[i][0].ToString();
                        string newString = textString.Substring(3);
                        string outputString = "";
                        foreach (char character in newString)
                        {
                            if (char.IsUpper(character))
                            {
                                outputString += " " + character;
                            }
                            else if (character.ToString() == "1" || character.ToString() == "3" || character.ToString() == "4")
                            {
                                outputString += " " + character;
                            }
                            else
                            {
                                outputString += character;
                            }
                        }
                        
                        ddlCategory.Items.Add(outputString.Trim());
                    }
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCategory.SelectedValue != "")
            {
                //get table name selected
                string tableName = "tbl" + ddlCategory.SelectedValue.Replace(" ", "");

                //display second dropdown
                ddlPart.CssClass = "ddlField";

                //set up a dataview object to hold part numbers for the second drop down
                System.Data.DataView partsList = new System.Data.DataView();

                if (tableName != "tblSchematics")
                {
                    //select part numbers
                    datSelectDataSource.SelectCommand = "SELECT partNumber, partName FROM " + tableName + " ORDER BY partNumber ASC";
                }
                else
                {
                    datSelectDataSource.SelectCommand = "SELECT schematicNumber, partName FROM " + tableName + " ORDER BY schematicNumber ASC";
                }
                //assign the table names to the dataview object
                partsList = (System.Data.DataView)datSelectDataSource.Select(System.Web.UI.DataSourceSelectArguments.Empty);

                //variable to determine amount of rows in the dataview object
                int rowCount = partsList.Count;

                //clear second drop down
                ddlPart.Items.Clear();

                //Insert empty string to first row of second drop down
                ddlPart.Items.Add("");

                //populate second drop down
                for (int i = 0; i < rowCount; i++)
                {
                    ddlPart.Items.Add(partsList[i][0].ToString() + " (" + partsList[i][1].ToString() + ")");
                }

                //add table name to session
                Session.Add("tableName", tableName);

                if (Session["categoryIndex"] != null)
                {
                    Session["categoryIndex"] = ddlCategory.SelectedIndex;
                }
                else
                {
                    Session.Add("categoryIndex", ddlCategory.SelectedIndex);
                }
            }

        }

        protected void ddlPart_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPart.SelectedValue != "")
            {
                //get part number selected
                string referenceString = "";
                foreach (char character in ddlPart.SelectedValue)
                {
                    if (character.ToString() == " ")
                    {
                        break;
                    }
                    referenceString += character;
                }
                string partNumber = referenceString.Trim();

                //display go button
                btnGo.CssClass = ".original";

                //add part number to session
                Session.Add("partNumber", partNumber);

                if (Session["partIndex"] != null)
                {
                    Session["partIndex"] = ddlPart.SelectedIndex;
                }
                else
                {
                    Session.Add("partIndex", ddlPart.SelectedIndex);
                }
            }
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            //Add session variable for display changes
            Session.Add("displayChanged", "true");

            if (Session["updateSelected"] != null)
            {
                //redirect to update page
                Response.Redirect("Update.aspx");
            }
            
            if (Session["viewSelected"] != null)
            {
                //redirect to display page
                Response.Redirect("Display.aspx");
            }
        }
    }
}
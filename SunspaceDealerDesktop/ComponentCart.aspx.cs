using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SunspaceDealerDesktop
{
    public partial class ComponentCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<string> componentCart = new List<string>();
            List<int> componentCartQuantity = new List<int>();

            //Create table
            Table mainTable = new Table();
            mainTable.ID = "tblSavedProjects";
            mainTable.CssClass = "tblSavedProjects sortable";
            
            TableHeaderRow aTableRow = new TableHeaderRow();
            aTableRow.TableSection = TableRowSection.TableHeader;

            TableHeaderCell aTableCell = new TableHeaderCell();
            aTableCell.CssClass = "thSortable";
            aTableCell.Controls.Add(new LiteralControl("Part"));
            aTableRow.Controls.Add(aTableCell);

            TableHeaderCell aTableCell2 = new TableHeaderCell();
            aTableCell2.Controls.Add(new LiteralControl("Quantity"));
            aTableRow.Controls.Add(aTableCell2);

            TableHeaderCell aTableCell3 = new TableHeaderCell();
            aTableCell3.Controls.Add(new LiteralControl("Delete"));
            aTableRow.Controls.Add(aTableCell3);

            mainTable.Controls.Add(aTableRow);

            try
            {
                componentCart = (List<string>)Session["componentCart"];
                componentCartQuantity = (List<int>)Session["componentCartQty"];

                if (componentCart.Count == 0)
                {
                    throw new System.ArgumentNullException("Need products added to cart");
                }

                for (int i = 0; i < componentCart.Count; i++)
                {
                    TableRow aNormalRow = new TableRow();
                    TableCell aNormalCell = new TableCell();
                    Button aNormalButton = new Button();

                    aNormalCell.Controls.Add(new LiteralControl(componentCart[i]));
                    aNormalRow.Controls.Add(aNormalCell);
                    aNormalCell = new TableCell();

                    aNormalCell.Controls.Add(new LiteralControl(componentCartQuantity[i].ToString()));
                    aNormalRow.Controls.Add(aNormalCell);
                    aNormalCell = new TableCell();

                    aNormalButton.Text = "Delete";
                    aNormalCell.Controls.Add(aNormalButton);
                    aNormalRow.Controls.Add(aNormalCell);
                    aNormalCell = new TableCell();

                    mainTable.Controls.Add(aNormalRow);
                }

                lblDebug.Text = "Cart exists";
            }
            catch (Exception ex)
            {
                //Nothing added to cart
                TableCell aTableCellB = new TableCell();
                aTableCellB.Controls.Add(new LiteralControl("Nothing added to cart"));
                aTableCellB.ColumnSpan = 3;

                TableRow aTableRowB = new TableRow();
                aTableRowB.Controls.Add(aTableCellB);

                mainTable.Controls.Add(aTableRowB);
                lblDebug.Text = "No cart exists";
            }

            phMainTable.Controls.Add(mainTable);
        }
    }
}
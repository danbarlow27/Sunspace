using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SunspaceDealerDesktop
{
    public partial class CutSheets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    //        <asp:Table ID="tblPriceCalculator" CssClass="tblPriceCalculator" runat="server">
    //    <asp:TableHeaderRow TableSection="TableHeader">                            
    //        <asp:TableCell>
    //            <asp:Label ID="lblTableExtrusionType" runat="server" Text="Extrusion Type"></asp:Label>
    //        </asp:TableCell>
    //        <asp:TableCell>
    //            <asp:Label ID="lblTableQuantity" runat="server" Text="Quantity"></asp:Label>
    //        </asp:TableCell>   
    //        <asp:TableCell>
    //            <asp:Label ID="lblTableLength" runat="server" Text="Length"></asp:Label>
    //        </asp:TableCell>   
    //        <asp:TableCell>
    //            <asp:Label ID="lblTableQuantityCut" runat="server" Text="Qty Cut"></asp:Label>
    //        </asp:TableCell> 
    //        <asp:TableCell>
    //            <asp:Label ID="lblTableQuantityChk" runat="server" Text="Qty Chk'd"></asp:Label>
    //        </asp:TableCell>                      
    //    </asp:TableHeaderRow>

            Table tblPriceCalculator = new Table();
            tblPriceCalculator.CssClass = "tblPriceCalculator";
            TableHeaderRow thr = new TableHeaderRow();
            TableCell tc = new TableCell();
            Label aLabel = new Label();

            aLabel.Text = "Extrusion Type";
            tc.Controls.Add(aLabel);
            thr.Controls.Add(tc);
            aLabel = new Label();

            aLabel.Text = "Quantity";
            tc.Controls.Add(aLabel);
            thr.Controls.Add(tc);
            aLabel = new Label();

            aLabel.Text = "Length";
            tc.Controls.Add(aLabel);
            thr.Controls.Add(tc);
            aLabel = new Label();

            aLabel.Text = "Qty Cut";
            tc.Controls.Add(aLabel);
            thr.Controls.Add(tc);
            aLabel = new Label();

            aLabel.Text = "Qty Chk'd";
            tc.Controls.Add(aLabel);
            thr.Controls.Add(tc);

            tblPriceCalculator.Controls.Add(thr);
            tblPlaceholder.Controls.Add(tblPriceCalculator);
        }
    }
}
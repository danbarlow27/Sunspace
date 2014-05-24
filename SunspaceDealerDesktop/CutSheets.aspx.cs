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
        List<Wall> listOfWalls = new List<Wall>();

        protected void Page_Load(object sender, EventArgs e)
        {
            listOfWalls = (List<Wall>)Session["listOfWalls"];
            //.CssClass = "removeElement";
            TableRow aTableRow;
            TableHeaderCell aTableHeaderCell;
            TableCell aTableCell;
            Label aLabel;

            #region Room Cut Sheets

            #region Extrusion Cut Sheet
            ddlCutSheets.Items.Add("Extrusion Cut Sheet");
            Table extrusionTable = new Table();
            aTableRow = new TableRow();
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";
            aTableCell = new TableCell();

            extrusionTable.ID = "tblExtrusion";
            extrusionTable.CssClass = "CutSheet";

            aTableHeaderCell.Text = "Extrusion Type";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";
            aTableHeaderCell.Text = "Quantity";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";
            aTableHeaderCell.Text = "Length";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";
            aTableHeaderCell.Text = "Qty Cut";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";
            aTableHeaderCell.Text = "Qty Chk'd";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";

            extrusionTable.Controls.Add(aTableRow);
            #endregion

            #region Panel Cut Sheet
            ddlCutSheets.Items.Add("Panel Cut Sheet");
            Table panelTable = new Table();
            aTableRow = new TableRow();
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";
            aTableCell = new TableCell();

            panelTable.ID = "tblPanel";
            panelTable.CssClass = "CutSheet";

            aTableHeaderCell.Text = "Item ID";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";
            aTableHeaderCell.Text = "Quantity";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";
            aTableHeaderCell.Text = "Width";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";
            aTableHeaderCell.Text = "Height";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";
            aTableHeaderCell.Text = "Qty Cut";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";
            aTableHeaderCell.Text = "Qty Chk'd";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";

            panelTable.Controls.Add(aTableRow);   
            #endregion

            #region Roof Cut Sheet
            ddlCutSheets.Items.Add("Roof Cut Sheet");
            Table roofTable = new Table();
            aTableRow = new TableRow();
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";
            aTableCell = new TableCell();
            aTableCell.CssClass = "CutSheetCells";

            roofTable.ID = "tblRoof";
            roofTable.CssClass = "CutSheet";

            aTableHeaderCell.Text = "Roof Panels";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";
            aTableHeaderCell.Text = "Quantity";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";
            aTableHeaderCell.Text = "Length";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";
            aTableHeaderCell.Text = "Qty Cut";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";
            aTableHeaderCell.Text = "Qty Chk'd";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";

            roofTable.Controls.Add(aTableRow);

            //listofwalls.count
            for (int i = 0; i < 3; i++)
            {
                aTableRow = new TableRow();
                aTableHeaderCell = new TableHeaderCell();
                aTableHeaderCell.CssClass = "CutSheetHeaders";
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";

                //alternate colours on each row
                if (i % 2 != 0)
                {
                    aTableRow.CssClass = "CutSheetRowOdd";
                }
                else
                {
                    aTableRow.CssClass = "CutSheetRowEven";
                }

                aTableCell.Text = "Cut @ 30\"";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableCell.Text = "1";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableCell.Text = "136";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableCell.Text = "";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableCell.Text = "";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";

                roofTable.Controls.Add(aTableRow);
            }

            

            //roof extrusion
            Table roofExtrusionTable = new Table();
            aTableRow = new TableRow();
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";
            aTableCell = new TableCell();
            aTableCell.CssClass = "CutSheetCells";

            roofExtrusionTable.ID = "tblRoofExtrusion";
            roofExtrusionTable.CssClass = "CutSheet";

            aTableHeaderCell.Text = "Extrusion Type";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";
            aTableHeaderCell.Text = "Quantity";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";
            aTableHeaderCell.Text = "Length";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";
            aTableHeaderCell.Text = "Qty Cut";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";
            aTableHeaderCell.Text = "Qty Chk'd";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";

            roofExtrusionTable.Controls.Add(aTableRow);

            //listofwalls.count
            for (int i = 0; i < 3; i++)
            {
                aTableRow = new TableRow();
                aTableHeaderCell = new TableHeaderCell();
                aTableHeaderCell.CssClass = "CutSheetHeaders";
                aTableCell = new TableCell();

                //alternate colours on each row
                if (i % 2 != 0)
                {
                    aTableRow.CssClass = "CutSheetRowOdd";
                }
                else
                {
                    aTableRow.CssClass = "CutSheetRowEven";
                }

                aTableCell.Text = "Receiver";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableCell.Text = "1";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableCell.Text = "216";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableCell.Text = "";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableCell.Text = "";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";

                roofExtrusionTable.Controls.Add(aTableRow);
            }

            #endregion

            #region Box Prep Sheet
            ddlCutSheets.Items.Add("Box Prep Sheet");
            Table boxPrepTable = new Table();
            aTableRow = new TableRow();
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";
            aTableCell = new TableCell();
            aTableCell.CssClass = "CutSheetCells";

            boxPrepTable.ID = "tblBox";
            boxPrepTable.CssClass = "CutSheet";

            aTableHeaderCell.Text = "Box Prep Type";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";
            aTableHeaderCell.Text = "Quantity";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";
            aTableHeaderCell.Text = "Color";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";
            aTableHeaderCell.Text = "Qty Cut";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";
            aTableHeaderCell.Text = "Qty Chk'd";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";

            boxPrepTable.Controls.Add(aTableRow);

            //listofwalls.count
            for (int i = 0; i < 3; i++)
            {
                aTableRow = new TableRow();
                aTableHeaderCell = new TableHeaderCell();
                aTableHeaderCell.CssClass = "CutSheetHeaders";
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";

                //alternate colours on each row
                if (i % 2 != 0)
                {
                    aTableRow.CssClass = "CutSheetRowOdd";
                }
                else
                {
                    aTableRow.CssClass = "CutSheetRowEven";
                }

                aTableCell.Text = "Elbows";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableCell.Text = "6";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableCell.Text = "White";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableCell.Text = "";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableCell.Text = "";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";

                boxPrepTable.Controls.Add(aTableRow);
            }

            #endregion

            #endregion

            #region V4T Cut Sheets

            #region Vinyl Window Production
            ddlCutSheets.Items.Add("Vinyl Window Production");
            Table vinylTable = new Table();
            aTableRow = new TableRow();
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";
            aTableCell = new TableCell();
            aTableCell.CssClass = "CutSheetCells";

            vinylTable.ID = "tblVinyl";
            vinylTable.CssClass = "CutSheet";

            aTableHeaderCell.Text = "#";
            aTableHeaderCell.RowSpan = 2;
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";

            aTableHeaderCell.Text = "Size";
            aTableHeaderCell.ColumnSpan = 2;
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";

            aTableHeaderCell.Text = "DLO\nTip";
            aTableHeaderCell.RowSpan = 2;
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";

            aTableHeaderCell.Text = "Description";
            aTableHeaderCell.ColumnSpan = 2;
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";

            aTableHeaderCell.Text = "Frame\nColour";
            aTableHeaderCell.RowSpan = 2;
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";

            aTableHeaderCell.Text = "Vinyl Colour";
            aTableHeaderCell.ColumnSpan = 4;
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";

            aTableHeaderCell.Text = "# of\nVents";
            aTableHeaderCell.RowSpan = 2;
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";

            vinylTable.Controls.Add(aTableRow);

            aTableRow = new TableRow();
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";
            aTableCell = new TableCell();
            aTableCell.CssClass = "CutSheetCells";

            aTableHeaderCell.Text = "Width";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";

            aTableHeaderCell.Text = "Height";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";

            aTableHeaderCell.Text = "Win. Type";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";

            aTableHeaderCell.Text = "Mount";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";

            aTableHeaderCell.Text = "Top";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";

            aTableHeaderCell.Text = "2";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";

            aTableHeaderCell.Text = "3";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";

            aTableHeaderCell.Text = "4";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";

            vinylTable.Controls.Add(aTableRow);

            //listofwalls.count
            for (int i = 0; i < 3; i++)
            {
                aTableRow = new TableRow();
                aTableHeaderCell = new TableHeaderCell();
                aTableHeaderCell.CssClass = "CutSheetHeaders";
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";

                //alternate colours on each row
                if (i % 2 != 0)
                {
                    aTableRow.CssClass = "CutSheetRowOdd";
                }
                else
                {
                    aTableRow.CssClass = "CutSheetRowEven";
                }

                aTableCell.Text = "1";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableCell.Text = "22";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableCell.Text = "72";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableCell.Text = "DLO";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableCell.Text = "Vertical 4 Track";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableCell.Text = "OSM";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableCell.Text = "White";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableCell.Text = "SG";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableCell.Text = "SG";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableCell.Text = "SG";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableCell.Text = "SG";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableCell.Text = "4";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";

                vinylTable.Controls.Add(aTableRow);
            }

            #endregion

            #region Sash Cut Sheet
            ddlCutSheets.Items.Add("Sash Cut Sheet");
            Table sashTable = new Table();
            aTableRow = new TableRow();
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";
            aTableCell = new TableCell();
            aTableCell.CssClass = "CutSheetCells";

            sashTable.ID = "tblSash";
            sashTable.CssClass = "CutSheet";

            aTableHeaderCell.Text = "#";
            aTableHeaderCell.RowSpan = 2;
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";

            aTableHeaderCell.Text = "Description";
            aTableHeaderCell.ColumnSpan = 3;
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";

            aTableHeaderCell.Text = "HORIZONTAL";
            aTableHeaderCell.ColumnSpan = 3;
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";

            aTableHeaderCell.Text = "VERTICAL";
            aTableHeaderCell.ColumnSpan = 3;
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";

            aTableHeaderCell.Text = "Spreader";
            aTableHeaderCell.ColumnSpan = 2;
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";

            aTableHeaderCell.Text = "Vent Colour";
            aTableHeaderCell.ColumnSpan = 4;
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";

            sashTable.Controls.Add(aTableRow);

            aTableRow = new TableRow();
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";
            aTableCell = new TableCell();

            aTableHeaderCell.Text = "Colour";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";

            aTableHeaderCell.Text = "Win. Type";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";

            aTableHeaderCell.Text = "Mount";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";

            aTableHeaderCell.Text = "Qty";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";

            aTableHeaderCell.Text = "Push";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";

            aTableHeaderCell.Text = "Stop";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";

            aTableHeaderCell.Text = "Qty";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";

            aTableHeaderCell.Text = "Push";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";

            aTableHeaderCell.Text = "Stop";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";

            aTableHeaderCell.Text = "Qty";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";

            aTableHeaderCell.Text = "Length";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";
            sashTable.Controls.Add(aTableRow);

            aTableHeaderCell.Text = "Top";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";
            sashTable.Controls.Add(aTableRow);

            aTableHeaderCell.Text = "2";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";
            sashTable.Controls.Add(aTableRow);

            aTableHeaderCell.Text = "3";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";
            sashTable.Controls.Add(aTableRow);

            aTableHeaderCell.Text = "4";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";
            sashTable.Controls.Add(aTableRow);

            //listofwalls.count
            for (int i = 0; i < 3; i++)
            {
                aTableRow = new TableRow();
                aTableHeaderCell = new TableHeaderCell();
                aTableHeaderCell.CssClass = "CutSheetHeaders";
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";

                //alternate colours on each row
                if (i % 2 != 0)
                {
                    aTableRow.CssClass = "CutSheetRowOdd";
                }
                else
                {
                    aTableRow.CssClass = "CutSheetRowEven";
                }

                aTableCell.Text = "1";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableCell.Text = "White";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableCell.Text = "Win. Type";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableCell.Text = "OSM";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableCell.Text = "8";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableCell.Text = "21.111";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableCell.Text = "21.222";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableCell.Text = "8";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableCell.Text = "22.333";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableCell.Text = "22.444";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableCell.Text = "4";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableCell.Text = "16-5/16";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableCell.Text = "SG";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableCell.Text = "SG";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableCell.Text = "SG";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableCell.Text = "SG";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";

                sashTable.Controls.Add(aTableRow);
            }

            #endregion

            #region Frame Cut Sheet
            ddlCutSheets.Items.Add("Frame Cut Sheet");
            Table frameTable = new Table();
            aTableRow = new TableRow();
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";
            aTableCell = new TableCell();
            aTableCell.CssClass = "CutSheetCells";

            frameTable.ID = "tblSash";
            frameTable.CssClass = "CutSheet";

            aTableHeaderCell.Text = "#";
            aTableHeaderCell.RowSpan = 2;
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";

            aTableHeaderCell.Text = "DLO Size";
            aTableHeaderCell.ColumnSpan = 2;
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";

            aTableHeaderCell.Text = "Description";
            aTableHeaderCell.ColumnSpan = 3;
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";

            aTableHeaderCell.Text = "Horizontal";
            aTableHeaderCell.ColumnSpan = 2;
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";

            aTableHeaderCell.Text = "Vertical";
            aTableHeaderCell.ColumnSpan = 2;
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";

            aTableHeaderCell.Text = "Stereo Bar";
            aTableHeaderCell.ColumnSpan = 2;
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";

            frameTable.Controls.Add(aTableRow);

            aTableRow = new TableRow();
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";
            aTableCell = new TableCell();

            aTableHeaderCell.Text = "Width";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";

            aTableHeaderCell.Text = "Height";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";

            aTableHeaderCell.Text = "Colour";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";

            aTableHeaderCell.Text = "Win. Type";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";

            aTableHeaderCell.Text = "Mount";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";

            aTableHeaderCell.Text = "Sill";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";

            aTableHeaderCell.Text = "Header";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";

            aTableHeaderCell.Text = "Shallow";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";

            aTableHeaderCell.Text = "Deep";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";

            aTableHeaderCell.Text = "Length";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";
            frameTable.Controls.Add(aTableRow);

            aTableHeaderCell.Text = "Qty";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";

            //listofwalls.count
            for (int i = 0; i < 3; i++)
            {
                aTableRow = new TableRow();
                aTableHeaderCell = new TableHeaderCell();
                aTableHeaderCell.CssClass = "CutSheetHeaders";
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";

                //alternate colours on each row
                if (i % 2 != 0)
                {
                    aTableRow.CssClass = "CutSheetRowOdd";
                }
                else
                {
                    aTableRow.CssClass = "CutSheetRowEven";
                }

                aTableCell.Text = "1";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableCell.Text = "22";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableCell.Text = "72";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableCell.Text = "White";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableCell.Text = "Vertical 4 Track";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableCell.Text = "OSM";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableCell.Text = "24";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableCell.Text = "24";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableCell.Text = "72";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableCell.Text = "72";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableCell.Text = "";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableCell.Text = "";
                aTableRow.Controls.Add(aTableCell);

                frameTable.Controls.Add(aTableRow);
            }

            #endregion

            #endregion

            #region Populate Cut Sheets
            //In the following sections, Tuples are used to get the data that will be entered into the tables. We confirm whether or not
            //there will be an addition based on the item we check, then we create the tuple and add it to a list. Once we check all of
            //those specific items in the sunroom, we can output the list into the required tables. This helps replicate the ordering of
            //the items, as well as letting us confirm whether or not we will have multiple, or different sized entries of the same type

            #region Starter/Receiver
            //Loop for all walls
            List<Tuple<string, int, float>> starterList = new List<Tuple<string, int, float>>(); //eg: Starter, 1, 94 3/4
            for (int wallNumber = 0; wallNumber < listOfWalls.Count; wallNumber++)
            {
                for (int linearNumber = 0; linearNumber < listOfWalls[wallNumber].LinearItems.Count; linearNumber++)
                {
                    if (listOfWalls[wallNumber].LinearItems[linearNumber].ItemType == "Receiver")
                    {
                        if (starterList.Count==0)
                        {
                            starterList.Add(new Tuple<string, int, float>("Starter", 1, Math.Max(listOfWalls[wallNumber].LinearItems[linearNumber].StartHeight,listOfWalls[wallNumber].LinearItems[linearNumber].EndHeight)));
                        }
                        else
                        {
                            bool added = false;
                            for (int i = 0; i < starterList.Count; i++)
                            {
                                Tuple<string, int, float> aTuple = starterList[i];
                                if (aTuple.Item3 == Math.Max(listOfWalls[wallNumber].LinearItems[linearNumber].StartHeight, listOfWalls[wallNumber].LinearItems[linearNumber].EndHeight)) //If this height exists, we add one to quantity, instead of making a new entry
                                {
                                    starterList[i] = new Tuple<string,int,float>(aTuple.Item1, (aTuple.Item2 + 1), aTuple.Item3);
                                    added = true;
                                    break;
                                }
                            }

                            if (added==false)
                            {
                                starterList.Add(new Tuple<string, int, float>("Starter", 1, Math.Max(listOfWalls[wallNumber].LinearItems[linearNumber].StartHeight, listOfWalls[wallNumber].LinearItems[linearNumber].EndHeight)));
                            }
                        }
                    }
                }
            }

            //Now that we've found all starters, we can add them to the table
            for (int i = 0; i < starterList.Count; i++)
            {
                aTableRow = new TableRow();

                //alternate colours on each row
                if (i % 2 != 0)
                {
                    aTableRow.CssClass = "CutSheetRowOdd";
                }
                else
                {
                    aTableRow.CssClass = "CutSheetRowEven";
                }

                aTableCell = new TableCell();
                aLabel = new Label();
                aLabel.Text = starterList[i].Item1.ToString();
                aTableCell.Controls.Add(aLabel);
                aTableCell.CssClass = "CutSheetCells";
                aTableRow.Controls.Add(aTableCell);

                aTableCell = new TableCell();
                aLabel = new Label();
                aLabel.Text = starterList[i].Item2.ToString();
                aTableCell.Controls.Add(aLabel);
                aTableCell.CssClass = "CutSheetCells";
                aTableRow.Controls.Add(aTableCell);

                aTableCell = new TableCell();
                aLabel = new Label();
                aLabel.Text = starterList[i].Item3.ToString();
                aTableCell.Controls.Add(aLabel);
                aTableCell.CssClass = "CutSheetCells";
                aTableRow.Controls.Add(aTableCell);

                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableRow.Controls.Add(aTableCell);

                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableRow.Controls.Add(aTableCell);

                extrusionTable.Controls.Add(aTableRow);
            }
            #endregion
            #region Boxheader
            List<Tuple<string, int, float>> boxheaderList = new List<Tuple<string, int, float>>(); //eg: Starter, 1, 94 3/4
            for (int wallNumber = 0; wallNumber < listOfWalls.Count; wallNumber++)
            {
                for (int linearNumber = 0; linearNumber < listOfWalls[wallNumber].LinearItems.Count; linearNumber++)
                {
                    if (listOfWalls[wallNumber].LinearItems[linearNumber].ItemType == "BoxHeader")
                    {
                        if (boxheaderList.Count == 0)
                        {
                            boxheaderList.Add(new Tuple<string, int, float>("Box Header", 1, Math.Max(listOfWalls[wallNumber].StartHeight, listOfWalls[wallNumber].EndHeight)));
                        }
                        else
                        {
                            bool added = false;
                            for (int i = 0; i < boxheaderList.Count; i++)
                            {
                                Tuple<string, int, float> aTuple = boxheaderList[i];
                                if (aTuple.Item3 == Math.Max(listOfWalls[wallNumber].StartHeight, listOfWalls[wallNumber].EndHeight)) //If this height exists, we add one to quantity, instead of making a new entry
                                {
                                    boxheaderList[i] = new Tuple<string, int, float>(aTuple.Item1, (aTuple.Item2 + 1), aTuple.Item3);
                                    added = true;
                                    break;
                                }
                            }

                            if (added == false)
                            {
                                boxheaderList.Add(new Tuple<string, int, float>("Box Header", 1, Math.Max(listOfWalls[wallNumber].StartHeight, listOfWalls[wallNumber].EndHeight)));
                            }
                        }
                    }
                }
            }

            //Now that we've found all boxheaders, we can add them to the table
            for (int i = 0; i < boxheaderList.Count; i++)
            {
                aTableRow = new TableRow();

                //alternate colours on each row
                if (i % 2 != 0)
                {
                    aTableRow.CssClass = "CutSheetRowOdd";
                }
                else
                {
                    aTableRow.CssClass = "CutSheetRowEven";
                }

                aTableCell = new TableCell();
                aLabel = new Label();
                aLabel.Text = boxheaderList[i].Item1.ToString();
                aTableCell.Controls.Add(aLabel);
                aTableCell.CssClass = "CutSheetCells";
                aTableRow.Controls.Add(aTableCell);

                aTableCell = new TableCell();
                aLabel = new Label();
                aLabel.Text = boxheaderList[i].Item2.ToString();
                aTableCell.Controls.Add(aLabel);
                aTableCell.CssClass = "CutSheetCells";
                aTableRow.Controls.Add(aTableCell);

                aTableCell = new TableCell();
                aLabel = new Label();
                aLabel.Text = boxheaderList[i].Item3.ToString();
                aTableCell.Controls.Add(aLabel);
                aTableCell.CssClass = "CutSheetCells";
                aTableRow.Controls.Add(aTableCell);

                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableRow.Controls.Add(aTableCell);

                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableRow.Controls.Add(aTableCell);

                extrusionTable.Controls.Add(aTableRow);
            }
            #endregion
            #region HChannel
            List<Tuple<string, int, float>> hChannelList = new List<Tuple<string, int, float>>(); //eg: Starter, 1, 94 3/4
            for (int wallNumber = 0; wallNumber < listOfWalls.Count; wallNumber++)
            {
                for (int linearNumber = 0; linearNumber < listOfWalls[wallNumber].LinearItems.Count; linearNumber++)
                {
                    if (listOfWalls[wallNumber].LinearItems[linearNumber].ItemType == "HChannel")
                    {
                        if (hChannelList.Count == 0)
                        {
                            hChannelList.Add(new Tuple<string, int, float>("HChannel", 1, Math.Max(listOfWalls[wallNumber].StartHeight, listOfWalls[wallNumber].EndHeight)));
                        }
                        else
                        {
                            bool added = false;
                            for (int i = 0; i < hChannelList.Count; i++)
                            {
                                Tuple<string, int, float> aTuple = hChannelList[i];
                                if (aTuple.Item3 == Math.Max(listOfWalls[wallNumber].StartHeight, listOfWalls[wallNumber].EndHeight)) //If this height exists, we add one to quantity, instead of making a new entry
                                {
                                    hChannelList[i] = new Tuple<string, int, float>(aTuple.Item1, (aTuple.Item2 + 1), aTuple.Item3);
                                    added = true;
                                    break;
                                }
                            }

                            if (added == false)
                            {
                                hChannelList.Add(new Tuple<string, int, float>("HChanel", 1, Math.Max(listOfWalls[wallNumber].StartHeight, listOfWalls[wallNumber].EndHeight)));
                            }
                        }
                    }
                }
            }

            //Now that we've found all hchannels, we can add them to the table
            for (int i = 0; i < hChannelList.Count; i++)
            {
                aTableRow = new TableRow();

                //alternate colours on each row
                if (i % 2 != 0)
                {
                    aTableRow.CssClass = "CutSheetRowOdd";
                }
                else
                {
                    aTableRow.CssClass = "CutSheetRowEven";
                }

                aTableCell = new TableCell();
                aLabel = new Label();
                aLabel.Text = hChannelList[i].Item1.ToString();
                aTableCell.Controls.Add(aLabel);
                aTableCell.CssClass = "CutSheetCells";
                aTableRow.Controls.Add(aTableCell);

                aTableCell = new TableCell();
                aLabel = new Label();
                aLabel.Text = hChannelList[i].Item2.ToString();
                aTableCell.Controls.Add(aLabel);
                aTableCell.CssClass = "CutSheetCells";
                aTableRow.Controls.Add(aTableCell);

                aTableCell = new TableCell();
                aLabel = new Label();
                aLabel.Text = hChannelList[i].Item3.ToString();
                aTableCell.Controls.Add(aLabel);
                aTableCell.CssClass = "CutSheetCells";
                aTableRow.Controls.Add(aTableCell);

                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableRow.Controls.Add(aTableCell);

                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableRow.Controls.Add(aTableCell);

                extrusionTable.Controls.Add(aTableRow);
            }
            #endregion
            #region Electrical Chase
            List<Tuple<string, int, float>> electricalChaseList = new List<Tuple<string, int, float>>(); //eg: Starter, 1, 94 3/4
            for (int wallNumber = 0; wallNumber < listOfWalls.Count; wallNumber++)
            {
                for (int linearNumber = 0; linearNumber < listOfWalls[wallNumber].LinearItems.Count; linearNumber++)
                {
                    if (listOfWalls[wallNumber].LinearItems[linearNumber].ItemType == "EChase")
                    {
                        if (electricalChaseList.Count == 0)
                        {
                            electricalChaseList.Add(new Tuple<string, int, float>("Electrical Chase", 1, Math.Max(listOfWalls[wallNumber].StartHeight, listOfWalls[wallNumber].EndHeight)));
                        }
                        else
                        {
                            bool added = false;
                            for (int i = 0; i < electricalChaseList.Count; i++)
                            {
                                Tuple<string, int, float> aTuple = electricalChaseList[i];
                                if (aTuple.Item3 == Math.Max(listOfWalls[wallNumber].StartHeight, listOfWalls[wallNumber].EndHeight)) //If this height exists, we add one to quantity, instead of making a new entry
                                {
                                    electricalChaseList[i] = new Tuple<string, int, float>(aTuple.Item1, (aTuple.Item2 + 1), aTuple.Item3);
                                    added = true;
                                    break;
                                }
                            }

                            if (added == false)
                            {
                                electricalChaseList.Add(new Tuple<string, int, float>("Electrical Chase", 1, Math.Max(listOfWalls[wallNumber].StartHeight, listOfWalls[wallNumber].EndHeight)));
                            }
                        }
                    }
                }
            }

            //Now that we've found all electrical chases, we can add them to the table
            for (int i = 0; i < electricalChaseList.Count; i++)
            {
                aTableRow = new TableRow();

                //alternate colours on each row
                if (i % 2 != 0)
                {
                    aTableRow.CssClass = "CutSheetRowOdd";
                }
                else
                {
                    aTableRow.CssClass = "CutSheetRowEven";
                }

                aTableCell = new TableCell();
                aLabel = new Label();
                aLabel.Text = electricalChaseList[i].Item1.ToString();
                aTableCell.Controls.Add(aLabel);
                aTableCell.CssClass = "CutSheetCells";
                aTableRow.Controls.Add(aTableCell);

                aTableCell = new TableCell();
                aLabel = new Label();
                aLabel.Text = electricalChaseList[i].Item2.ToString();
                aTableCell.Controls.Add(aLabel);
                aTableCell.CssClass = "CutSheetCells";
                aTableRow.Controls.Add(aTableCell);

                aTableCell = new TableCell();
                aLabel = new Label();
                aLabel.Text = electricalChaseList[i].Item3.ToString();
                aTableCell.Controls.Add(aLabel);
                aTableCell.CssClass = "CutSheetCells";
                aTableRow.Controls.Add(aTableCell);

                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableRow.Controls.Add(aTableCell);

                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableRow.Controls.Add(aTableCell);

                extrusionTable.Controls.Add(aTableRow);
            }
            #endregion
            #region Filler
            List<Tuple<string, int, float>> fillerList = new List<Tuple<string, int, float>>(); //eg: Starter, 1, 94 3/4
            for (int wallNumber = 0; wallNumber < listOfWalls.Count; wallNumber++)
            {
                for (int linearNumber = 0; linearNumber < listOfWalls[wallNumber].LinearItems.Count; linearNumber++)
                {
                    
                }
            }
            #endregion
            #region Mod
            List<Tuple<string, int, float>> modList = new List<Tuple<string, int, float>>(); //eg: Starter, 1, 94 3/4
            for (int wallNumber = 0; wallNumber < listOfWalls.Count; wallNumber++)
            {
                for (int linearNumber = 0; linearNumber < listOfWalls[wallNumber].LinearItems.Count; linearNumber++)
                {
                    if (listOfWalls[wallNumber].LinearItems[linearNumber].ItemType == "Mod")
                    {
                        if (listOfWalls[wallNumber].LinearItems[linearNumber].Sex.Substring(0, 1) == "F")
                        {
                            if (modList.Count == 0)
                            {
                                modList.Add(new Tuple<string, int, float>("Female", 1, Math.Max(listOfWalls[wallNumber].StartHeight, listOfWalls[wallNumber].EndHeight)));
                            }
                            else
                            {
                                bool added = false;
                                for (int i = 0; i < modList.Count; i++)
                                {
                                    Tuple<string, int, float> aTuple = modList[i];
                                    if (aTuple.Item3 == Math.Max(listOfWalls[wallNumber].StartHeight, listOfWalls[wallNumber].EndHeight)) //If this height exists, we add one to quantity, instead of making a new entry
                                    {
                                        modList[i] = new Tuple<string, int, float>(aTuple.Item1, (aTuple.Item2 + 1), aTuple.Item3);
                                        added = true;
                                        break;
                                    }
                                }

                                if (added == false)
                                {
                                    modList.Add(new Tuple<string, int, float>("Female", 1, Math.Max(listOfWalls[wallNumber].StartHeight, listOfWalls[wallNumber].EndHeight)));
                                }
                            }
                        }

                        if (listOfWalls[wallNumber].LinearItems[linearNumber].Sex.Substring(0, 1) == "M")
                        {
                            if (modList.Count == 0)
                            {
                                modList.Add(new Tuple<string, int, float>("Male", 1, Math.Max(listOfWalls[wallNumber].StartHeight, listOfWalls[wallNumber].EndHeight)));
                            }
                            else
                            {
                                bool added = false;
                                for (int i = 0; i < modList.Count; i++)
                                {
                                    Tuple<string, int, float> aTuple = modList[i];
                                    if (aTuple.Item3 == Math.Max(listOfWalls[wallNumber].StartHeight, listOfWalls[wallNumber].EndHeight)) //If this height exists, we add one to quantity, instead of making a new entry
                                    {
                                        modList[i] = new Tuple<string, int, float>(aTuple.Item1, (aTuple.Item2 + 1), aTuple.Item3);
                                        added = true;
                                        break;
                                    }
                                }

                                if (added == false)
                                {
                                    modList.Add(new Tuple<string, int, float>("Male", 1, Math.Max(listOfWalls[wallNumber].StartHeight, listOfWalls[wallNumber].EndHeight)));
                                }
                            }
                        }

                        if (listOfWalls[wallNumber].LinearItems[linearNumber].Sex.Substring(1, 1) == "F")
                        {
                            if (modList.Count == 0)
                            {
                                modList.Add(new Tuple<string, int, float>("Female", 1, Math.Max(listOfWalls[wallNumber].StartHeight, listOfWalls[wallNumber].EndHeight)));
                            }
                            else
                            {
                                bool added = false;
                                for (int i = 0; i < modList.Count; i++)
                                {
                                    Tuple<string, int, float> aTuple = modList[i];
                                    if (aTuple.Item3 == Math.Max(listOfWalls[wallNumber].StartHeight, listOfWalls[wallNumber].EndHeight)) //If this height exists, we add one to quantity, instead of making a new entry
                                    {
                                        modList[i] = new Tuple<string, int, float>(aTuple.Item1, (aTuple.Item2 + 1), aTuple.Item3);
                                        added = true;
                                        break;
                                    }
                                }

                                if (added == false)
                                {
                                    modList.Add(new Tuple<string, int, float>("Female", 1, Math.Max(listOfWalls[wallNumber].StartHeight, listOfWalls[wallNumber].EndHeight)));
                                }
                            }
                        }

                        if (listOfWalls[wallNumber].LinearItems[linearNumber].Sex.Substring(1, 1) == "M")
                        {
                            if (modList.Count == 0)
                            {
                                modList.Add(new Tuple<string, int, float>("Male", 1, Math.Max(listOfWalls[wallNumber].StartHeight, listOfWalls[wallNumber].EndHeight)));
                            }
                            else
                            {
                                bool added = false;
                                for (int i = 0; i < modList.Count; i++)
                                {
                                    Tuple<string, int, float> aTuple = modList[i];
                                    if (aTuple.Item3 == Math.Max(listOfWalls[wallNumber].StartHeight, listOfWalls[wallNumber].EndHeight)) //If this height exists, we add one to quantity, instead of making a new entry
                                    {
                                        modList[i] = new Tuple<string, int, float>(aTuple.Item1, (aTuple.Item2 + 1), aTuple.Item3);
                                        added = true;
                                        break;
                                    }
                                }

                                if (added == false)
                                {
                                    modList.Add(new Tuple<string, int, float>("Male", 1, Math.Max(listOfWalls[wallNumber].StartHeight, listOfWalls[wallNumber].EndHeight)));
                                }
                            }
                        }
                    }
                }
            }
            #endregion
            #endregion

            #region Add tables to placeholders
            //Now that we've created and populated all the tables, we can add them to the page

            tblExtrusionPlaceholder.Controls.Add(extrusionTable);

            tblPanelPlaceholder.Controls.Add(panelTable);

            tblRoofPlaceholder.Controls.Add(roofTable);
            aLabel = new Label();
            aLabel.Text = "Extrusion Colour: White"; //Get extrusion colour
            tblRoofPlaceholder.Controls.Add(aLabel);

            tblRoofPlaceholder.Controls.Add(roofExtrusionTable);

            tblBoxPlaceholder.Controls.Add(boxPrepTable);

            tblVinylProductionPlaceholder.Controls.Add(vinylTable);

            tblSashPlaceholder.Controls.Add(sashTable);

            tblFramePlaceholder.Controls.Add(frameTable);
            #endregion
        }
    }
}
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
            //listOfWalls = (List<Wall>)Session["listOfWalls"];
            //.CssClass = "removeElement";
            Table aTable;
            TableRow aTableRow;
            TableHeaderCell aTableHeaderCell;
            TableCell aTableCell;
            Label aLabel;

            #region Room Cut Sheets

            #region Extrusion Cut Sheet
            ddlCutSheets.Items.Add("Extrusion Cut Sheet");
            aTable = new Table();
            aTableRow = new TableRow();
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";
            aTableCell = new TableCell();

            aTable.ID = "tblExtrusion";
            aTable.CssClass = "CutSheet";

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

            aTable.Controls.Add(aTableRow);            

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

                aTableCell.Text = "ext";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells"; 
                aTableCell.Text = "1";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableCell.Text = "20";
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

                aTable.Controls.Add(aTableRow);
            }

            tblExtrusionPlaceholder.Controls.Add(aTable); 
            #endregion

            #region Panel Cut Sheet
            ddlCutSheets.Items.Add("Panel Cut Sheet");
            aTable = new Table();
            aTableRow = new TableRow();
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";
            aTableCell = new TableCell();

            aTable.ID = "tblPanel";
            aTable.CssClass = "CutSheet";

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

            aTable.Controls.Add(aTableRow);

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

                aTableCell.Text = "F2";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableCell.Text = "1";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableCell.Text = "3-5/8";
                aTableRow.Controls.Add(aTableCell);
                aTableCell = new TableCell();
                aTableCell.CssClass = "CutSheetCells";
                aTableCell.Text = "95-3/4";
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

                aTable.Controls.Add(aTableRow);
            }

            tblPanelPlaceholder.Controls.Add(aTable);
            #endregion

            #region Roof Cut Sheet
            ddlCutSheets.Items.Add("Roof Cut Sheet");
            aTable = new Table();
            aTableRow = new TableRow();
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";
            aTableCell = new TableCell();
            aTableCell.CssClass = "CutSheetCells";

            aTable.ID = "tblRoof";
            aTable.CssClass = "CutSheet";

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

            aTable.Controls.Add(aTableRow);

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

                aTable.Controls.Add(aTableRow);
            }

            tblRoofPlaceholder.Controls.Add(aTable);
            aLabel = new Label();
            aLabel.Text = "Extrusion Colour: White";
            tblRoofPlaceholder.Controls.Add(aLabel);

            //roof extrusion
            aTable = new Table();
            aTableRow = new TableRow();
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";
            aTableCell = new TableCell();
            aTableCell.CssClass = "CutSheetCells";

            aTable.ID = "tblRoofExtrusion";
            aTable.CssClass = "CutSheet";

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

            aTable.Controls.Add(aTableRow);

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

                aTable.Controls.Add(aTableRow);
            }

            tblRoofPlaceholder.Controls.Add(aTable);
            #endregion

            #region Box Prep Sheet
            ddlCutSheets.Items.Add("Box Prep Sheet");
            aTable = new Table();
            aTableRow = new TableRow();
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";
            aTableCell = new TableCell();
            aTableCell.CssClass = "CutSheetCells";

            aTable.ID = "tblBox";
            aTable.CssClass = "CutSheet";

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

            aTable.Controls.Add(aTableRow);

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

                aTable.Controls.Add(aTableRow);
            }

            tblBoxPlaceholder.Controls.Add(aTable);
            #endregion

            #endregion

            #region V4T Cut Sheets

            #region Vinyl Window Production
            ddlCutSheets.Items.Add("Vinyl Window Production");
            aTable = new Table();
            aTableRow = new TableRow();
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";
            aTableCell = new TableCell();
            aTableCell.CssClass = "CutSheetCells";

            aTable.ID = "tblVinyl";
            aTable.CssClass = "CutSheet";

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

            aTable.Controls.Add(aTableRow);

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

            aTable.Controls.Add(aTableRow);

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

                aTable.Controls.Add(aTableRow);
            }

            tblVinylProductionPlaceholder.Controls.Add(aTable);
            #endregion

            #region Sash Cut Sheet
            ddlCutSheets.Items.Add("Sash Cut Sheet");
            aTable = new Table();
            aTableRow = new TableRow();
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";
            aTableCell = new TableCell();
            aTableCell.CssClass = "CutSheetCells";

            aTable.ID = "tblSash";
            aTable.CssClass = "CutSheet";

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

            aTable.Controls.Add(aTableRow);

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
            aTable.Controls.Add(aTableRow);

            aTableHeaderCell.Text = "Top";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";
            aTable.Controls.Add(aTableRow);

            aTableHeaderCell.Text = "2";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";
            aTable.Controls.Add(aTableRow);

            aTableHeaderCell.Text = "3";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";
            aTable.Controls.Add(aTableRow);

            aTableHeaderCell.Text = "4";
            aTableRow.Controls.Add(aTableHeaderCell);
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";
            aTable.Controls.Add(aTableRow);

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

                aTable.Controls.Add(aTableRow);
            }

            tblSashPlaceholder.Controls.Add(aTable);
            #endregion

            #region Frame Cut Sheet
            ddlCutSheets.Items.Add("Frame Cut Sheet");
            aTable = new Table();
            aTableRow = new TableRow();
            aTableHeaderCell = new TableHeaderCell();
            aTableHeaderCell.CssClass = "CutSheetHeaders";
            aTableCell = new TableCell();
            aTableCell.CssClass = "CutSheetCells";

            aTable.ID = "tblSash";
            aTable.CssClass = "CutSheet";

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

            aTable.Controls.Add(aTableRow);

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
            aTable.Controls.Add(aTableRow);

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

                aTable.Controls.Add(aTableRow);
            }

            tblFramePlaceholder.Controls.Add(aTable);
            #endregion

            #endregion
        }
    }
}
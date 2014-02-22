using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class DecorativeColumn
    {        
        private string columnName;
        private string columnDescription;
        private string partNumber;
        private string columnColor;
        private int columnLength;
        private string columnLengthUnits;
        private decimal columnUsdPrice;
        private decimal columnCadPrice;
        private bool columnStatus;

        public DecorativeColumn()
        {
            ColumnName = "";
            ColumnDescription = "";
            PartNumber = "";
            ColumnColor = "";
            ColumnLength = 0;
            ColumnLengthUnits = "";
            ColumnUsdPrice = 0.0m;
            ColumnCadPrice = 0.0m;
            ColumnStatus = true;
        }

        public DecorativeColumn(string name, string description, string number, string color, int length, string lengthUnits,
             decimal cadprice, decimal usdprice, bool status)
        {
            ColumnName = name;
            ColumnDescription = description;
            PartNumber = number;
            ColumnColor = color;
            ColumnLength = length;
            ColumnLengthUnits = lengthUnits;
            ColumnUsdPrice = usdprice;
            ColumnCadPrice = cadprice;
            ColumnStatus = status;
        }

        //Inserts a record into the database
        public void Insert(System.Web.UI.WebControls.SqlDataSource dataSource, string table)
        {
            string sqlCount;
            string sqlInsert;
            System.Data.DataView selectTable = new System.Data.DataView();
            int count;

            sqlCount = "SELECT * FROM " + table;

            dataSource.SelectCommand = sqlCount;
            selectTable = (System.Data.DataView)dataSource.Select(System.Web.UI.DataSourceSelectArguments.Empty);

            //find out how many records are in the table in order to set the primary key
            count = selectTable.Count;

            //Insert
            sqlInsert = "INSERT INTO " + table
            + "(columnID,partName,description,partNumber,color,columnLength,lengthUnits,usdPrice,cadPrice,status)"
            + "VALUES"
            + "(" + (count + 1) + ",'" + ColumnName + "','" + ColumnDescription + "','" + PartNumber + "','" + ColumnColor + "'," + ColumnLength + ",'"
            + ColumnLengthUnits + "'," + ColumnUsdPrice + "," + ColumnCadPrice + "," + 1 + ")";

            dataSource.InsertCommand = sqlInsert;
            dataSource.Insert();

        }

        //Database select all
        public System.Data.DataView SelectAll(System.Web.UI.WebControls.SqlDataSource dataSource, string table, string partNum)
        {
            //set up a dataview object for object member data
            System.Data.DataView anObjectTable = new System.Data.DataView();

            //select row based on table name and part number
            dataSource.SelectCommand = "SELECT partName, description, partNumber, color, columnLength, lengthUnits, "
                            + "usdPrice, cadPrice, status FROM "
                            + table
                            + " WHERE partNumber = '"
                            + partNum + "'";

            //assign the row to the dataview object
            anObjectTable = (System.Data.DataView)dataSource.Select(System.Web.UI.DataSourceSelectArguments.Empty);

            //return the DataView object
            return anObjectTable;
        }

        //Database update
        public void Update(System.Web.UI.WebControls.SqlDataSource dataSource, string table, string partNum)
        {
            int bitStatus;

            if (columnStatus)
            {
                bitStatus = 1;
            }
            else
            {
                bitStatus = 0;
            }

            dataSource.UpdateCommand = "UPDATE " + table
            + " SET description ='" + ColumnDescription + "', columnLength=" + ColumnLength + ", lengthUnits='" + ColumnLengthUnits
            + "', usdPrice=" + ColumnUsdPrice + ", cadPrice=" + ColumnCadPrice
            + ", status=" + bitStatus +
            " WHERE partNumber = '" + partNum + "'";

            dataSource.Update();
        }

        //Populate member variables from a DataView object
        public void Populate(System.Data.DataView anObjectTable)
        {
            //populate object
            ColumnName = anObjectTable[0][0].ToString();
            ColumnDescription = anObjectTable[0][1].ToString();
            PartNumber = anObjectTable[0][2].ToString();
            ColumnColor = anObjectTable[0][3].ToString();
            ColumnLength = Convert.ToInt32(anObjectTable[0][4]);
            ColumnLengthUnits = anObjectTable[0][5].ToString();
            ColumnUsdPrice = Convert.ToDecimal(anObjectTable[0][6]);
            ColumnCadPrice = Convert.ToDecimal(anObjectTable[0][7]);
            ColumnStatus = Convert.ToBoolean(anObjectTable[0][8]);
        }

        //setters and getters
        public string ColumnName
        {
            set
            {
                columnName = value;
            }

            get
            {
                return columnName;
            }
        }

        public string ColumnDescription
        {
            set
            {
                columnDescription = value;
            }

            get
            {
                return columnDescription;
            }
        }

        public string PartNumber
        {
            set
            {
                partNumber = value;
            }

            get
            {
                return partNumber;
            }
        }

        public string ColumnColor
        {
            set
            {
                columnColor = value;
            }

            get
            {
                return columnColor;
            }
        }

        public int ColumnLength
        {
            set
            {
                columnLength = value;
            }

            get
            {
                return columnLength;
            }
        }

        public string ColumnLengthUnits
        {
            set
            {
                columnLengthUnits = value;
            }

            get
            {
                return columnLengthUnits;
            }
        }

        public decimal ColumnCadPrice
        {
            set
            {
                columnCadPrice = value;
            }

            get
            {
                return columnCadPrice;
            }
        }

        public decimal ColumnUsdPrice
        {
            set
            {
                columnUsdPrice = value;
            }

            get
            {
                return columnUsdPrice;
            }
        }

        public bool ColumnStatus
        {
            set
            {
                columnStatus = value;
            }

            get
            {
                return columnStatus;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class Accessories
    {
        private string accessoryName;
        private string accessoryDescription;
        private string accessoryNumber;
        private string accessoryColor;
        private int accessoryPackQuantity;
        private int accessoryWidth;
        private string accessoryWidthUnits;
        private int accessoryLength;
        private string accessoryLengthUnits;
        private int accessorySize;
        private string accessorySizeUnits;
        private decimal accessoryCadPrice;
        private decimal accessoryUsdPrice;
        private bool accessoryStatus;

        public Accessories()
        {
            AccessoryName = "";
            AccessoryDescription = "";
            AccessoryNumber = "";
            AccessoryColor = "";

            AccessoryPackQuantity = 0;
            AccessoryWidth = 0;
            AccessoryWidthUnits = "";
            AccessoryLength = 0;
            AccessoryLengthUnits = "";
            AccessorySize = 0;
            AccessorySizeUnits = "";

            AccessoryUsdPrice = 0.0m;
            AccessoryCadPrice = 0.0m;

            AccessoryStatus = true;
        }

        public Accessories(string name, string description, string number, string color, 
                int packQuantity, int width, string widthUnits, int length, string lengthUnits, int size, string sizeUnits,
                    decimal cadprice, decimal usdprice, bool status)
        {
            AccessoryName = name;
            AccessoryDescription = description;
            AccessoryNumber = number;
            AccessoryColor = color;

            AccessoryPackQuantity = packQuantity;
            AccessoryWidth = width;
            AccessoryWidthUnits = widthUnits;
            AccessoryLength = length;
            AccessoryLengthUnits = lengthUnits;
            AccessorySize = size;
            AccessorySizeUnits = sizeUnits;

            AccessoryUsdPrice = usdprice;
            AccessoryCadPrice = cadprice;

            AccessoryStatus = status;
        }

        public void Insert(System.Web.UI.WebControls.SqlDataSource dataSource, string table)
        {
            string sqlCount;
            string sqlInsert;
            System.Data.DataView selectTable = new System.Data.DataView();
            int count;

            sqlCount = "SELECT * FROM " + table;

            dataSource.SelectCommand = sqlCount;
            selectTable = (System.Data.DataView)dataSource.Select(System.Web.UI.DataSourceSelectArguments.Empty);

            count = selectTable.Count;

            sqlInsert = "INSERT INTO " + table
            + "(accId,partName,description,partNumber,color,packQuantity,width,widthUnits,length,lengthUnits,size,sizeUnits,usdPrice,cadPrice,status)"
            + "VALUES"
            + "(" + (count + 1) + ",'" + AccessoryName + "','" + AccessoryDescription + "','" + AccessoryNumber + "','" + AccessoryColor + "'," + AccessoryPackQuantity + ","
            + AccessoryWidth + ",'" + AccessoryWidthUnits + "'," + AccessoryLength + ",'" + AccessoryLengthUnits + "'," + AccessorySize + ",'" + accessorySizeUnits + "',"
            + AccessoryUsdPrice + "," + AccessoryCadPrice + "," + 1 + ")";

            dataSource.InsertCommand = sqlInsert;
            dataSource.Insert();

        }

        //Database select all
        public System.Data.DataView SelectAll(System.Web.UI.WebControls.SqlDataSource dataSource, string table, string partNum)
        {
            //set up a dataview object for object member data
            System.Data.DataView anObjectTable = new System.Data.DataView();

            //select row based on table name and part number
            dataSource.SelectCommand = "SELECT partName, description, partNumber, color, packQuantity, width, widthUnits, length, lengthUnits, size, sizeUnits, "
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

            if (accessoryStatus)
            {
                bitStatus = 1;
            }
            else
            {
                bitStatus = 0;
            }

            dataSource.UpdateCommand = "UPDATE " + table
            + " SET description ='" + AccessoryDescription + "', packQuantity=" + AccessoryPackQuantity + ", width=" + AccessoryWidth
            + ", widthUnits='" + AccessoryWidthUnits + "', length=" + AccessoryLength + ", lengthUnits='" + AccessoryLengthUnits
            + "', size=" + AccessorySize + ", sizeUnits='" + AccessorySizeUnits  
            + "', usdPrice=" + AccessoryUsdPrice + ", cadPrice=" + AccessoryCadPrice 
            + ", status=" + bitStatus +
            " WHERE partNumber = '" + partNum + "'";

            dataSource.Update();
        }

        //Populate member variables from a DataView object
        public void Populate(System.Data.DataView anObjectTable)
        {
            //populate object
            AccessoryName = anObjectTable[0][0].ToString();
            AccessoryDescription = anObjectTable[0][1].ToString();
            AccessoryNumber = anObjectTable[0][2].ToString();
            AccessoryColor = anObjectTable[0][3].ToString();
            AccessoryUsdPrice = Convert.ToDecimal(anObjectTable[0][11]);
            AccessoryCadPrice = Convert.ToDecimal(anObjectTable[0][12]);
            AccessoryStatus = Convert.ToBoolean(anObjectTable[0][13]);

            //conditional field population, based on whether database value is null or not
            if (anObjectTable[0][4] != DBNull.Value)
            {
                AccessoryPackQuantity = Convert.ToInt32(anObjectTable[0][4]);
            }

            if (anObjectTable[0][5] != DBNull.Value)
            {
                AccessoryWidth = Convert.ToInt32(anObjectTable[0][5]);
                AccessoryWidthUnits = anObjectTable[0][6].ToString();
            }

            if (anObjectTable[0][7] != DBNull.Value)
            {
                AccessoryLength = Convert.ToInt32(anObjectTable[0][7]);
                AccessoryLengthUnits = anObjectTable[0][8].ToString();
            }

            if (anObjectTable[0][9] != DBNull.Value)
            {
                AccessorySize = Convert.ToInt32(anObjectTable[0][9]);
                AccessorySizeUnits = anObjectTable[0][10].ToString();
            }
        }

        //setters and getters
        public string AccessoryName
        {
            set
            {
                accessoryName = value;
            }

            get
            {
                return accessoryName;
            }
        }

        public string AccessoryDescription
        {
            set
            {
                accessoryDescription = value;
            }

            get
            {
                return accessoryDescription;
            }
        }

        public string AccessoryNumber
        {
            set
            {
                accessoryNumber = value;
            }

            get
            {
                return accessoryNumber;
            }
        }

        public string AccessoryColor
        {
            set
            {
                accessoryColor = value;
            }

            get
            {
                return accessoryColor;
            }
        }

        public int AccessoryPackQuantity
        {
            set
            {
                accessoryPackQuantity = value;
            }

            get
            {
                return accessoryPackQuantity;
            }
        }

        public int AccessoryWidth
        {
            set
            {
                accessoryWidth = value;
            }

            get
            {
                return accessoryWidth;
            }
        }

        public string AccessoryWidthUnits
        {
            set
            {
                accessoryWidthUnits = value;
            }

            get
            {
                return accessoryWidthUnits;
            }
        }

        public int AccessoryLength
        {
            set
            {
                accessoryLength = value;
            }

            get
            {
                return accessoryLength;
            }
        }

        public string AccessoryLengthUnits
        {
            set
            {
                accessoryLengthUnits = value;
            }

            get
            {
                return accessoryLengthUnits;
            }
        }

        public int AccessorySize
        {
            set
            {
                accessorySize = value;
            }

            get
            {
                return accessorySize;
            }
        }

        public string AccessorySizeUnits
        {
            set
            {
                accessorySizeUnits = value;
            }

            get
            {
                return accessorySizeUnits;
            }
        }

        public decimal AccessoryCadPrice
        {
            set
            {
                accessoryCadPrice = value;
            }

            get
            {
                return accessoryCadPrice;
            }
        }

        public decimal AccessoryUsdPrice
        {
            set
            {
                accessoryUsdPrice = value;
            }

            get
            {
                return accessoryUsdPrice;
            }
        }

        public bool AccessoryStatus
        {
            set
            {
                accessoryStatus = value;
            }

            get
            {
                return accessoryStatus;
            }
        }
    }
}
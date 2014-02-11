using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sunspace
{
    public class WallExtrusions
    {
         //Class members
        private string wallExtrusionName;
        private string wallExtrusionDescription;
        private string partNumber;
        private string wallExtrusionColor;
        private int wallExtrusionMaxLength;
        private string lengthUnits;
        private decimal usdPrice;
        private decimal cadPrice;
        private bool status;

        //Constructors

        //Default constructor
        public WallExtrusions()
        {
            WallExtrusionName = "";
            WallExtrusionDescription = "";
            PartNumber = "";
            WallExtrusionColor = "";
            wallExtrusionMaxLength = 0;
            LengthUnits = "";
            UsdPrice = 0.0m;
            CadPrice = 0.0m;
            Status = true;
        }

        //Parameterized constructor
        public WallExtrusions(string name, string description, string number, string color, int length, string lengthUnits, decimal usdPrice, decimal cadPrice, bool status)
        {
            WallExtrusionName = name;
            WallExtrusionDescription = description;
            PartNumber = number;
            WallExtrusionColor = color;
            wallExtrusionMaxLength = length;
            LengthUnits = lengthUnits;
            UsdPrice = usdPrice;
            CadPrice = cadPrice;
            Status = status;
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

            //find out how many records are in the table in order to set the primary key
            count = selectTable.Count;

            //Insert
            sqlInsert = "INSERT INTO " + table
            + "(wallExtrusionID,partName,description,partNumber,color,maxLength,lengthUnits,usdPrice,cadPrice,status)"
            + "VALUES"
            + "(" + (count + 1) + ",'" + WallExtrusionName + "','" + WallExtrusionDescription + "','" + PartNumber + "','" + WallExtrusionColor + "'," + WallExtrusionMaxLength + ",'"
            + LengthUnits + "',"
            + UsdPrice + "," + CadPrice + "," + 1 + ")";


            dataSource.InsertCommand = sqlInsert;
            dataSource.Insert();
        }

        //Database select all
        public System.Data.DataView SelectAll(System.Web.UI.WebControls.SqlDataSource dataSource, string table, string partNum)
        {
            //set up a dataview object for object member data
            System.Data.DataView anObjectTable = new System.Data.DataView();

            //select row based on table name and part number
            dataSource.SelectCommand = "SELECT partName, description, partNumber, color, maxLength, lengthUnits, usdPrice, cadPrice, status FROM "
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
            
            if (Status)
            {
                bitStatus = 1;
            }
            else
            {
                bitStatus = 0;
            }

            dataSource.UpdateCommand = "UPDATE " + table 
            + " SET description ='" + wallExtrusionDescription + "', maxLength=" + wallExtrusionMaxLength + ", lengthUnits='" + LengthUnits + "', usdPrice=" + UsdPrice 
            + ", cadPrice=" + CadPrice + ", status=" + bitStatus + 
            " WHERE partNumber = '" + partNum + "'";
            
            dataSource.Update();
        }

        //Populate member variables from a DataView object
        public void Populate(System.Data.DataView anObjectTable)
        {
            //populate object
            wallExtrusionName = anObjectTable[0][0].ToString();
            wallExtrusionDescription = anObjectTable[0][1].ToString();
            partNumber = anObjectTable[0][2].ToString();
            wallExtrusionColor = anObjectTable[0][3].ToString();
            wallExtrusionMaxLength = Convert.ToInt32(anObjectTable[0][4]);
            LengthUnits = anObjectTable[0][5].ToString();
            UsdPrice = Convert.ToDecimal(anObjectTable[0][6]);
            CadPrice = Convert.ToDecimal(anObjectTable[0][7]);
            Status = Convert.ToBoolean(anObjectTable[0][8]);
        }

        //Getters and Setters
        public string WallExtrusionName
        {
            set
            {
                wallExtrusionName = value;
            }

            get
            {
                return wallExtrusionName;
            }
        }
        public string WallExtrusionDescription
        {
            set
            {
                wallExtrusionDescription = value;
            }

            get
            {
                return wallExtrusionDescription;
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
        public string WallExtrusionColor
        {
            set
            {
                wallExtrusionColor = value;
            }

            get
            {
                return wallExtrusionColor;
            }
        }
        public int WallExtrusionMaxLength
        {
            set
            {
                wallExtrusionMaxLength = value;
            }

            get
            {
                return wallExtrusionMaxLength;
            }
        }
        public string LengthUnits
        {
            set
            {
                lengthUnits = value;
            }

            get
            {
                return lengthUnits;
            }
        }
        public decimal UsdPrice
        {
            set
            {
                usdPrice = value;
            }

            get
            {
                return usdPrice;
            }
        }
        public decimal CadPrice
        {
            set
            {
                cadPrice = value;
            }

            get
            {
                return cadPrice;
            }
        }
        public bool Status
        {
            set
            {
                status = value;
            }

            get
            {
                return status;
            }
        }
    }
}
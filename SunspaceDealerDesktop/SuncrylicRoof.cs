using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sunspace
{
    public class SuncrylicRoof
    {
         //Class members
        private string suncrylicName;
        private string suncrylicDescription;
        private string partNumber;
        private string suncrylicColor;
        private int suncrylicMaxLength;
        private string suncrylicLengthUnits;
        private decimal usdPrice;
        private decimal cadPrice;
        private bool status;

        //Constructors

        //Default constructor
        public SuncrylicRoof()
        {
            SuncrylicName = "";
            SuncrylicDescription = "";
            PartNumber = "";
            SuncrylicColor = "";
            SuncrylicMaxLength = 0;
            SuncrylicLengthUnits = "";
            UsdPrice = 0.0m;
            CadPrice = 0.0m;
            Status = true;
        }

        //Parameterized constructor
        public SuncrylicRoof(string name, string description, string number, string color, int maxLength, string maxLengthUnits, decimal usdPrice, decimal cadPrice, bool status)
        {
            SuncrylicName = name;
            SuncrylicDescription = description;
            PartNumber = number;
            SuncrylicColor = color;
            SuncrylicMaxLength = maxLength;
            SuncrylicLengthUnits = maxLengthUnits;
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
            + "(suncrylicRoofID,partName,description,partNumber,color,maxLength,lengthUnits,usdPrice,cadPrice,status)"
            + "VALUES"
            + "(" + (count + 1) + ",'" + SuncrylicName + "','" + SuncrylicDescription + "','" + PartNumber + "','" + SuncrylicColor + "'," + SuncrylicMaxLength + ",'" + SuncrylicLengthUnits + "',"
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
            dataSource.SelectCommand = "SELECT partName, description, partNumber, maxLength, lengthUnits, usdPrice, cadPrice, status FROM "
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
            + " SET description ='" + SuncrylicDescription
            + "', maxLength=" + SuncrylicMaxLength + ", lengthUnits='" + SuncrylicLengthUnits + "', usdPrice=" + UsdPrice 
            + ", cadPrice=" + CadPrice + ", status=" + bitStatus + 
            " WHERE partNumber = '" + partNum + "'";
            
            dataSource.Update();
        }

        //Populate member variables from a DataView object
        public void Populate(System.Data.DataView anObjectTable)
        {
            //populate object
            SuncrylicName = anObjectTable[0][0].ToString();
            SuncrylicDescription = anObjectTable[0][1].ToString();
            PartNumber = anObjectTable[0][2].ToString();
            SuncrylicMaxLength = Convert.ToInt32(anObjectTable[0][3]);
            SuncrylicLengthUnits = anObjectTable[0][4].ToString();
            UsdPrice = Convert.ToDecimal(anObjectTable[0][5]);
            CadPrice = Convert.ToDecimal(anObjectTable[0][6]);
            Status = Convert.ToBoolean(anObjectTable[0][7]);
        }

        //Getters and Setters
        public string SuncrylicName
        {
            set
            {
                suncrylicName = value;
            }

            get
            {
                return suncrylicName;
            }
        }

        public string SuncrylicDescription
        {
            set
            {
                suncrylicDescription = value;
            }

            get
            {
                return suncrylicDescription;
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

        public string SuncrylicColor
        {
            set
            {
                suncrylicColor = value;
            }

            get
            {
                return suncrylicColor;
            }
        }

        public int SuncrylicMaxLength
        {
            set
            {
                suncrylicMaxLength = value;
            }

            get
            {
                return suncrylicMaxLength;
            }
        }

        public string SuncrylicLengthUnits
        {
            set
            {
                suncrylicLengthUnits = value;
            }

            get
            {
                return suncrylicLengthUnits;
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
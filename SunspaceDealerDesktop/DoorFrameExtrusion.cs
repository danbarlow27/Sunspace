using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class DoorFrameExtrusion
    {
         //Class members
        private string dfeName;
        private string partNumber;
        private string dfeDescription;
        private string dfeColor;
        private int dfeMaxLength;
        private string dfeMaxLengthUnits;
        private decimal dfeUsdPrice;
        private decimal dfeCadPrice;
        private bool dfeStatus;

        //Constructors

        //Default constructor
        public DoorFrameExtrusion()
        {
            DfeName = "";
            PartNumber = "";
            DfeDescription = "";
            DfeColor = "";
            DfeMaxLength = 0;
            DfeMaxLengthUnits = "";
            UsdPrice = 0.0m;
            CadPrice = 0.0m;
            DfeStatus = true;
        }

        //Parameterized constructor
        public DoorFrameExtrusion(string name, string number, string description, string color, int maxLength, string maxLengthUnits, decimal cadPrice, decimal usdPrice, bool status)
        {
            DfeName = name;
            PartNumber = number;
            DfeDescription = description;
            DfeColor = color;
            DfeMaxLength = maxLength;
            DfeMaxLengthUnits = maxLengthUnits;
            UsdPrice = usdPrice;
            CadPrice = cadPrice;
            DfeStatus = status;
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
            + "(dfeID,partName,description,partNumber,color,maxLength,lengthUnits,usdPrice,cadPrice,status)"
            + "VALUES"
            + "(" + (count + 1) + ",'" + DfeName + "','" + DfeDescription + "','" + PartNumber + "','" + DfeColor + "'," + DfeMaxLength + ",'"
            + DfeMaxLengthUnits + "'," + UsdPrice + "," + CadPrice + "," + 1 + ")";

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
            
            if (dfeStatus)
            {
                bitStatus = 1;
            }
            else
            {
                bitStatus = 0;
            }

            dataSource.UpdateCommand = "UPDATE " + table
            + " SET description ='" + DfeDescription + "', maxLength=" + DfeMaxLength 
            + ", lengthUnits='" + DfeMaxLengthUnits + "', usdPrice=" + UsdPrice 
            + ", cadPrice=" + CadPrice + ", status=" + bitStatus + 
            " WHERE partNumber = '" + partNum + "'";
            
            dataSource.Update();
        }

        //Populate member variables from a DataView object
        public void Populate(System.Data.DataView anObjectTable)
        {
            //populate object
            DfeName = anObjectTable[0][0].ToString();
            PartNumber = anObjectTable[0][2].ToString();
            DfeColor = anObjectTable[0][3].ToString();
            DfeMaxLength = Convert.ToInt32(anObjectTable[0][4]);
            DfeMaxLengthUnits = anObjectTable[0][5].ToString();
            UsdPrice = Convert.ToDecimal(anObjectTable[0][6]);
            CadPrice = Convert.ToDecimal(anObjectTable[0][7]);
            DfeStatus = Convert.ToBoolean(anObjectTable[0][8]);

            //conditional field population, based on whether database value is null or not
            if (anObjectTable[0][1] != DBNull.Value)
            {
                DfeDescription = anObjectTable[0][1].ToString();
            }
        }

        //Getters and Setters
        public string DfeName
        {
            set
            {
                dfeName = value;
            }

            get
            {
                return dfeName;
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

        public string DfeDescription
        {
            set
            {
                dfeDescription = value;
            }

            get
            {
                return dfeDescription;
            }
        }

        public string DfeColor
        {
            set
            {
                dfeColor = value;
            }

            get
            {
                return dfeColor;
            }
        }

        public int DfeMaxLength
        {
            set
            {
                dfeMaxLength = value;
            }

            get
            {
                return dfeMaxLength;
            }
        }

        public string DfeMaxLengthUnits
        {
            set
            {
                dfeMaxLengthUnits = value;
            }

            get
            {
                return dfeMaxLengthUnits;
            }
        }

        public decimal CadPrice
        {
            set
            {
                dfeCadPrice = value;
            }

            get
            {
                return dfeCadPrice;
            }
        }

        public decimal UsdPrice
        {
            set
            {
                dfeUsdPrice = value;
            }

            get
            {
                return dfeUsdPrice;
            }
        }

        public bool DfeStatus
        {
            set
            {
                dfeStatus = value;
            }

            get
            {
                return dfeStatus;
            }
        }
    }
}
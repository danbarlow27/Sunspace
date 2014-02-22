using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class ScreenRoll
    {
        //Class members
        private string screenRollName;
        private string partNumber;
        private int screenRollWidth;
        private string screenRollWidthUnits;
        private int screenRollLength;
        private string screenRollLengthUnits;
        private decimal cadPrice;
        private decimal usdPrice;
        private bool status;

        //Constructors

        //Default constructor
        public ScreenRoll()
        {
            ScreenRollName = "";
            PartNumber = "";
            ScreenRollWidth = 0;
            ScreenRollWidthUnits = "";
            ScreenRollLength = 0;
            ScreenRollLengthUnits = "";
            CadPrice = 0.0m;
            UsdPrice = 0.0m;
            Status = true;
        }

        //Parameterized constructor
        public ScreenRoll(string name, string number, int width, string widthUnits, 
                        int length, string lengthUnits, decimal cad, decimal usd, bool status)
        {
            ScreenRollName = name;
            PartNumber = number;
            ScreenRollWidth = width;
            ScreenRollWidthUnits = widthUnits;
            ScreenRollLength = length;
            ScreenRollLengthUnits = lengthUnits;
            CadPrice = cad;
            UsdPrice = usd;
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
            + "(rollID,partName,partNumber,width,widthUnits,length,lengthUnits,usdPrice,cadPrice,status)"
            + "VALUES"
            + "(" + (count + 1) + ",'" + ScreenRollName + "','" + PartNumber + "'," + ScreenRollWidth + ",'" + ScreenRollWidthUnits + "',"
            + ScreenRollLength + ",'" + ScreenRollLengthUnits + "',"
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
            dataSource.SelectCommand = "SELECT partName, partNumber, width, widthUnits, "
                            + "length, lengthUnits, usdPrice, cadPrice, status FROM "
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
            + " SET width=" + ScreenRollWidth + ", widthUnits='" + ScreenRollWidthUnits
            + "', length=" + ScreenRollLength + ", lengthUnits='" + ScreenRollLengthUnits
            + "', usdPrice=" + UsdPrice + ", cadPrice=" + CadPrice + ", status=" + bitStatus + 
            " WHERE partNumber = '" + partNum + "'";
            
            dataSource.Update();
        }

        //Populate member variables from a DataView object
        public void Populate(System.Data.DataView anObjectTable)
        {
            //populate object
            ScreenRollName = anObjectTable[0][0].ToString();
            PartNumber = anObjectTable[0][1].ToString();
            ScreenRollWidth = Convert.ToInt32(anObjectTable[0][2]);
            ScreenRollWidthUnits = anObjectTable[0][3].ToString();
            ScreenRollLength = Convert.ToInt32(anObjectTable[0][4]);
            ScreenRollLengthUnits = anObjectTable[0][5].ToString();
            UsdPrice = Convert.ToDecimal(anObjectTable[0][6]);
            CadPrice = Convert.ToDecimal(anObjectTable[0][7]);
            Status = Convert.ToBoolean(anObjectTable[0][8]);           
        }

        //Getters and Setters
        public string ScreenRollName
        {
            set
            {
                screenRollName = value;
            }

            get
            {
                return screenRollName;
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

        public int ScreenRollWidth
        {
            set
            {
                screenRollWidth = value;
            }

            get
            {
                return screenRollWidth;
            }
        }

        public string ScreenRollWidthUnits
        {
            set
            {
                screenRollWidthUnits = value;
            }

            get
            {
                return screenRollWidthUnits;
            }
        }

        public int ScreenRollLength
        {
            set
            {
                screenRollLength = value;
            }

            get
            {
                return screenRollLength;
            }
        }

        public string ScreenRollLengthUnits
        {
            set
            {
                screenRollLengthUnits = value;
            }

            get
            {
                return screenRollLengthUnits;
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
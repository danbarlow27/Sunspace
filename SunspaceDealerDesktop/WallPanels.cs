using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class WallPanels
    {
        //Class members
        private string wallPanelName;
        private string wallPanelDescription;
        private string wallPanelComposition;
        private string wallPanelStandard;
        private string wallPanelColor;
        private string wallPanelNumber;
        private int wallPanelSize;
        private string sizeUnits;
        private int wallPanelMaxWidth;
        private string widthUnits;
        private int wallPanelMaxLength;
        private string lengthUnits;
        private decimal usdPrice;
        private decimal cadPrice;
        private bool status;

        //Constructors

        //Default constructor
        public WallPanels()
        {
            WallPanelName = "";
            WallPanelDescription = "";
            WallPanelComposition = "";
            WallPanelStandard = "";
            WallPanelColor = "";
            WallPanelNumber = "";
            WallPanelSize = 0;
            SizeUnits = "";
            WallPanelMaxWidth = 0;
            WidthUnits = "";
            WallPanelMaxLength = 0;
            LengthUnits = "";
            UsdPrice = 0.0m;
            CadPrice = 0.0m;
            Status = true;
        }

        //Parameterized constructor
        public WallPanels(string name, string description, string composition, string standard, string color, string number, int size, string sizeUnits,
                        int maxWidth, string widthUnits, int maxLength, string maxLengthUnits, decimal usdPrice, decimal cadPrice, bool status)
        {
            WallPanelName = name;
            WallPanelDescription = description;
            WallPanelComposition = composition;
            WallPanelStandard = standard;
            WallPanelColor = color;
            WallPanelNumber = number;
            WallPanelSize = size;
            SizeUnits = sizeUnits;
            WallPanelMaxWidth = maxWidth;
            WidthUnits = widthUnits;
            WallPanelMaxLength = maxLength;
            LengthUnits = maxLengthUnits;
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
            + "(wallPanelID,partName,description,composition,standard,color,partNumber,size,sizeUnits,maxWidth,widthUnits,maxLength,lengthUnits,usdPrice,cadPrice,status)"
            + "VALUES"
            + "(" + (count + 1) + ",'" + WallPanelName + "','" + WallPanelDescription + "','" + WallPanelComposition + "','" + WallPanelStandard + "','" + WallPanelColor + "','" + WallPanelNumber + "',"
            + WallPanelSize + ",'" + SizeUnits + "'," + WallPanelMaxWidth + ",'" + WidthUnits + "'," + WallPanelMaxLength + ",'" + LengthUnits + "',"
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
            dataSource.SelectCommand = "SELECT partName, description, composition, standard, color, partNumber, size, sizeUnits, " 
                            + "maxWidth, widthUnits, maxLength, lengthUnits, usdPrice, cadPrice, status FROM "
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
            + " SET description ='" + WallPanelDescription + "', composition='" + WallPanelComposition + "', standard='" + WallPanelStandard
            + "', size=" + WallPanelSize + ", sizeUnits='" + SizeUnits + "', maxWidth=" + WallPanelMaxWidth + ", widthUnits='" + WidthUnits
            + ", lengthUnits='" + lengthUnits + "', usdPrice=" + UsdPrice 
            + ", cadPrice=" + CadPrice + ", status=" + bitStatus + 
            " WHERE partNumber = '" + partNum + "'";
            
            dataSource.Update();
        }

        //Populate member variables from a DataView object
        public void Populate(System.Data.DataView anObjectTable)
        {
            //populate object
            WallPanelName = anObjectTable[0][0].ToString();
            WallPanelDescription = anObjectTable[0][1].ToString();
            WallPanelComposition = anObjectTable[0][2].ToString();
            WallPanelStandard = anObjectTable[0][3].ToString();
            WallPanelColor = anObjectTable[0][4].ToString();
            WallPanelNumber = anObjectTable[0][5].ToString();
            WallPanelSize = Convert.ToInt32(anObjectTable[0][6]);
            SizeUnits = anObjectTable[0][7].ToString();
            WallPanelMaxWidth = Convert.ToInt32(anObjectTable[0][8]);
            WidthUnits = anObjectTable[0][9].ToString();
            WallPanelMaxLength = Convert.ToInt32(anObjectTable[0][10]);
            LengthUnits = anObjectTable[0][11].ToString();
            UsdPrice = Convert.ToDecimal(anObjectTable[0][12]);
            CadPrice = Convert.ToDecimal(anObjectTable[0][13]);
            Status = Convert.ToBoolean(anObjectTable[0][14]);
        }

        //Getters and Setters
        public string WallPanelName
        {
            set
            {
                wallPanelName = value;
            }

            get
            {
                return wallPanelName;
            }
        }

        public string WallPanelNumber
        {
            set
            {
                wallPanelNumber = value;
            }

            get
            {
                return wallPanelNumber;
            }
        }

        public string WallPanelDescription
        {
            set
            {
                wallPanelDescription = value;
            }

            get
            {
                return wallPanelDescription;
            }
        }
        public string WallPanelComposition
        {
            set
            {
                wallPanelComposition = value;
            }

            get
            {
                return wallPanelComposition;
            }
        }
        public string WallPanelStandard
        {
            set
            {
                wallPanelStandard = value;
            }

            get
            {
                return wallPanelStandard;
            }
        }

        public string WallPanelColor
        {
            set
            {
                wallPanelColor = value;
            }

            get
            {
                return wallPanelColor;
            }
        }

        public int WallPanelSize
        {
            set
            {
                wallPanelSize = value;
            }

            get
            {
                return wallPanelSize;
            }
        }

        public string SizeUnits
        {
            set
            {
                sizeUnits = value;
            }

            get
            {
                return sizeUnits;
            }
        }

        public int WallPanelMaxWidth
        {
            set
            {
                wallPanelMaxWidth = value;
            }

            get
            {
                return wallPanelMaxWidth;
            }
        }

        public string WidthUnits
        {
            set
            {
                widthUnits = value;
            }

            get
            {
                return widthUnits;
            }
        }

        public int WallPanelMaxLength
        {
            set
            {
                wallPanelMaxLength = value;
            }

            get
            {
                return wallPanelMaxLength;
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
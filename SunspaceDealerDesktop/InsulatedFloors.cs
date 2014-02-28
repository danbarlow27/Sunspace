using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class InsulatedFloors
    {
         //Class members
        private string insulatedFloorName;
        private string insulatedFloorDescription;
        private string insulatedFloorComposition;
        private string partNumber;
        private int insulatedFloorSize;
        private string insulatedFloorSizeUnits;
        private int insulatedFloorMaxWidth;
        private string insulatedFloorMaxWidthUnits;
        private string insulatedFloorMaxLength;
        private decimal insulatedFloorUsdPrice;
        private decimal insulatedFloorCadPrice;
        private bool insulatedFloorStatus;

        //Constructors

        //Default constructor
        public InsulatedFloors()
        {
            InsulatedFloorName = "";
            PartNumber = "";
            InsulatedFloorDescription = "";
            InsulatedFloorComposition = "";
            InsulatedFloorSize = 0;
            InsulatedFloorSizeUnits = "";
            InsulatedFloorMaxWidth = 0;
            InsulatedFloorMaxWidthUnits = "";
            InsulatedFloorMaxLength = "";
            InsulatedFloorUsdPrice = 0.0m;
            InsulatedFloorCadPrice = 0.0m;
            InsulatedFloorStatus = true;
        }

        //Parameterized constructor
        public InsulatedFloors(string name, string number, string description, string composition, int size, string sizeUnits, int width, string widthUnits,
                                string maxLength, decimal usdPrice, decimal cadPrice, bool status)
        {
            InsulatedFloorName = name;
            PartNumber = number;
            InsulatedFloorDescription = description;
            InsulatedFloorComposition = composition;
            InsulatedFloorSize = size;
            InsulatedFloorSizeUnits = sizeUnits;
            InsulatedFloorMaxWidth = width;
            InsulatedFloorMaxWidthUnits = widthUnits;
            InsulatedFloorMaxLength = maxLength;
            InsulatedFloorUsdPrice = usdPrice;
            InsulatedFloorCadPrice = cadPrice;
            InsulatedFloorStatus = status;
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
            + "(insulatedFloorID,partName,description,composition,partNumber,size,sizeUnits,maxWidth,widthUnits,maxLength,usdPrice,cadPrice,status)"
            + "VALUES"
            + "(" + (count + 1) + ",'" + InsulatedFloorName + "','" + InsulatedFloorDescription + "','" + InsulatedFloorComposition + "','" + PartNumber + "'," + InsulatedFloorSize + ",'"
            + InsulatedFloorSizeUnits + "'," + InsulatedFloorMaxWidth + ",'" + InsulatedFloorMaxWidthUnits + "','" + InsulatedFloorMaxLength + "',"
            + InsulatedFloorUsdPrice + "," + InsulatedFloorCadPrice + "," + 1 + ")";

            dataSource.InsertCommand = sqlInsert;
            dataSource.Insert();
        }

        //Database select all
        public System.Data.DataView SelectAll(System.Web.UI.WebControls.SqlDataSource dataSource, string table, string partNum)
        {
            //set up a dataview object for object member data
            System.Data.DataView anObjectTable = new System.Data.DataView();

            //select row based on table name and part number
            dataSource.SelectCommand = "SELECT partName, description, composition, partNumber, " 
                            + "size, sizeUnits, maxWidth, widthUnits, maxLength, "
                            + "usdPrice, cadPrice,status FROM "
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

            if (InsulatedFloorStatus)
            {
                bitStatus = 1;
            }
            else
            {
                bitStatus = 0;
            }

            dataSource.UpdateCommand = "UPDATE " + table
            + " SET description ='" + InsulatedFloorDescription + "', composition='" + InsulatedFloorComposition
            + "', size=" + InsulatedFloorSize + ", sizeUnits='" + InsulatedFloorSizeUnits
            + "', maxWidth=" + InsulatedFloorMaxWidth + ", widthUnits='" + InsulatedFloorMaxWidthUnits
            + "', maxLength='" + InsulatedFloorMaxLength + "', usdPrice=" + InsulatedFloorUsdPrice
            +", cadPrice=" + InsulatedFloorCadPrice + ", status=" + bitStatus + 
            " WHERE partNumber = '" + partNum + "'";
            
            dataSource.Update();
        }

        //Populate member variables from a DataView object
        public void Populate(System.Data.DataView anObjectTable)
        {
            //populate object
            InsulatedFloorName = anObjectTable[0][0].ToString();
            PartNumber = anObjectTable[0][3].ToString();
            InsulatedFloorDescription = anObjectTable[0][1].ToString();
            InsulatedFloorComposition = anObjectTable[0][2].ToString();
            InsulatedFloorSize = Convert.ToInt32(anObjectTable[0][4]);
            InsulatedFloorSizeUnits = anObjectTable[0][5].ToString();
            InsulatedFloorMaxWidth = Convert.ToInt32(anObjectTable[0][6]);
            InsulatedFloorMaxWidthUnits = anObjectTable[0][7].ToString();
            InsulatedFloorMaxLength = anObjectTable[0][8].ToString();
            InsulatedFloorUsdPrice = Convert.ToDecimal(anObjectTable[0][9]);
            InsulatedFloorCadPrice = Convert.ToDecimal(anObjectTable[0][10]);
            InsulatedFloorStatus = Convert.ToBoolean(anObjectTable[0][11]);
        }

        //Getters and Setters
        public string InsulatedFloorName
        {
            set
            {
                insulatedFloorName = value;
            }

            get
            {
                return insulatedFloorName;
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

        public string InsulatedFloorDescription
        {
            set
            {
                insulatedFloorDescription = value;
            }

            get
            {
                return insulatedFloorDescription;
            }
        }

        public string InsulatedFloorComposition
        {
            set
            {
                insulatedFloorComposition = value;
            }

            get
            {
                return insulatedFloorComposition;
            }
        }

        public int InsulatedFloorSize
        {
            set
            {
                insulatedFloorSize = value;
            }

            get
            {
                return insulatedFloorSize;
            }
        }

        public string InsulatedFloorSizeUnits
        {
            set
            {
                insulatedFloorSizeUnits = value;
            }

            get
            {
                return insulatedFloorSizeUnits;
            }
        }

        public int InsulatedFloorMaxWidth
        {
            set
            {
                insulatedFloorMaxWidth = value;
            }

            get
            {
                return insulatedFloorMaxWidth;
            }
        }

        public string InsulatedFloorMaxWidthUnits
        {
            set
            {
                insulatedFloorMaxWidthUnits = value;
            }

            get
            {
                return insulatedFloorMaxWidthUnits;
            }
        }

        public string InsulatedFloorMaxLength
        {
            set
            {
                insulatedFloorMaxLength = value;
            }

            get
            {
                return insulatedFloorMaxLength;
            }
        }

        public decimal InsulatedFloorCadPrice
        {
            set
            {
                insulatedFloorCadPrice = value;
            }

            get
            {
                return insulatedFloorCadPrice;
            }
        }

        public decimal InsulatedFloorUsdPrice
        {
            set
            {
                insulatedFloorUsdPrice = value;
            }

            get
            {
                return insulatedFloorUsdPrice;
            }
        }

        public bool InsulatedFloorStatus
        {
            set
            {
                insulatedFloorStatus = value;
            }

            get
            {
                return insulatedFloorStatus;
            }
        }
    }
}
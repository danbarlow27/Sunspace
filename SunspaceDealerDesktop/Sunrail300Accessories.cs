using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class Sunrail300Accessories
    {
        //Class members
        private string sunrail300AccessoriesName;
        private string partNumber;
        private string sunrail300AccessoriesDescription;
        private string sunrail300AccessoriesColor;
        private decimal sunrail300AccessoriesUsdPrice;
        private decimal sunrail300AccessoriesCadPrice;
        private bool sunrail300AccessoriesStatus;

        //Constructors

        //Default constructor
        public Sunrail300Accessories()
        {
            Sunrail300AccessoriesName = "";
            PartNumber = "";
            Sunrail300AccessoriesDescription = "";
            Sunrail300AccessoriesColor = "";
            Sunrail300AccessoriesUsdPrice = 0.0m;
            Sunrail300AccessoriesCadPrice = 0.0m;
            Sunrail300AccessoriesStatus = true;
        }

        //Parameterized constructor
        public Sunrail300Accessories(string name, string number, string description, string color,
                                        decimal usdPrice, decimal cadPrice, bool status)
        {
            Sunrail300AccessoriesName = name;
            PartNumber = number;
            Sunrail300AccessoriesDescription = description;
            Sunrail300AccessoriesColor = color;
            Sunrail300AccessoriesUsdPrice = usdPrice;
            Sunrail300AccessoriesCadPrice = cadPrice;
            Sunrail300AccessoriesStatus = status;
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
            + "(srAccID,partName,description,partNumber,color,usdPrice,cadPrice,status)"
            + "VALUES"
            + "(" + (count + 1) + ",'" + Sunrail300AccessoriesName + "','" + Sunrail300AccessoriesDescription + "','" + PartNumber + "','"
            + Sunrail300AccessoriesColor + "',"
            + Sunrail300AccessoriesUsdPrice + "," + Sunrail300AccessoriesCadPrice + "," + 1 + ")";


            dataSource.InsertCommand = sqlInsert;
            dataSource.Insert();
        }

        //Database select all
        public System.Data.DataView SelectAll(System.Web.UI.WebControls.SqlDataSource dataSource, string table, string partNum)
        {
            //set up a dataview object for object member data
            System.Data.DataView anObjectTable = new System.Data.DataView();

            //select row based on table name and part number
            dataSource.SelectCommand = "SELECT partName, description, partNumber, color, usdPrice, cadPrice, status FROM "
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

            if (Sunrail300AccessoriesStatus)
            {
                bitStatus = 1;
            }
            else
            {
                bitStatus = 0;
            }

            dataSource.UpdateCommand = "UPDATE " + table
            + " SET description ='" + Sunrail300AccessoriesDescription + "', usdPrice=" + Sunrail300AccessoriesUsdPrice + ", cadPrice=" + Sunrail300AccessoriesCadPrice + ", status=" + bitStatus +
            " WHERE partNumber = '" + partNum + "'";

            dataSource.Update();
        }

        //Populate member variables from a DataView object
        public void Populate(System.Data.DataView anObjectTable)
        {
            //populate object
            Sunrail300AccessoriesName = anObjectTable[0][0].ToString();
            Sunrail300AccessoriesDescription = anObjectTable[0][1].ToString();
            PartNumber = anObjectTable[0][2].ToString();
            Sunrail300AccessoriesColor = anObjectTable[0][3].ToString();
            Sunrail300AccessoriesUsdPrice = Convert.ToDecimal(anObjectTable[0][4]);
            Sunrail300AccessoriesCadPrice = Convert.ToDecimal(anObjectTable[0][5]);
            Sunrail300AccessoriesStatus = Convert.ToBoolean(anObjectTable[0][6]);
        }

        //Getters and Setters
        public string Sunrail300AccessoriesName
        {
            set
            {
                sunrail300AccessoriesName = value;
            }

            get
            {
                return sunrail300AccessoriesName;
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

        public string Sunrail300AccessoriesDescription
        {
            set
            {
                sunrail300AccessoriesDescription = value;
            }

            get
            {
                return sunrail300AccessoriesDescription;
            }
        }

        public string Sunrail300AccessoriesColor
        {
            set
            {
                sunrail300AccessoriesColor = value;
            }

            get
            {
                return sunrail300AccessoriesColor;
            }
        }

        public decimal Sunrail300AccessoriesUsdPrice
        {
            set
            {
                sunrail300AccessoriesUsdPrice = value;
            }

            get
            {
                return sunrail300AccessoriesUsdPrice;
            }
        }

        public decimal Sunrail300AccessoriesCadPrice
        {
            set
            {
                sunrail300AccessoriesCadPrice = value;
            }

            get
            {
                return sunrail300AccessoriesCadPrice;
            }
        }

        public bool Sunrail300AccessoriesStatus
        {
            set
            {
                sunrail300AccessoriesStatus = value;
            }

            get
            {
                return sunrail300AccessoriesStatus;
            }
        }
    }
}
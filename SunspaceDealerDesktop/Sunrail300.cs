using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class Sunrail300
    {
        //Class members
        private string sunrail300Name;
        private string partNumber;
        private string sunrail300Description;
        private string sunrail300Color;
        private int sunrail300MaxLengthFeet;
        private string sunrail300MaxLengthFeetUnits;
        private int? sunrail300MaxLengthInches;
        private string sunrail300MaxLengthInchesUnits;
        private decimal sunrail300UsdPrice;
        private decimal sunrail300CadPrice;
        private bool sunrail300Status;

        //Constructors

        //Default constructor
        public Sunrail300()
        {
            Sunrail300Name = "";
            PartNumber = "";
            Sunrail300Description = "";
            Sunrail300Color = "";
            Sunrail300MaxLengthFeet = 0;
            Sunrail300MaxLengthFeetUnits = "";
            Sunrail300MaxLengthInches = 0;
            Sunrail300MaxLengthInchesUnits = "";
            Sunrail300UsdPrice = 0.0m;
            Sunrail300CadPrice = 0.0m;
            Sunrail300Status = true;
        }

        //Parameterized constructor
        public Sunrail300(string name, string number, string description, string color, int maxLengthFeet, string maxLengthFeetUnits, int maxLengthInches, string maxLengthInchesUnits,
                    decimal usdPrice, decimal cadPrice, bool status)
        {
            Sunrail300Name = name;
            PartNumber = number;
            Sunrail300Description = description;
            Sunrail300Color = color;
            Sunrail300MaxLengthFeet = maxLengthFeet;
            Sunrail300MaxLengthFeetUnits = maxLengthFeetUnits;
            Sunrail300MaxLengthInches = maxLengthInches;
            Sunrail300MaxLengthInchesUnits = maxLengthInchesUnits;
            Sunrail300UsdPrice = usdPrice;
            Sunrail300CadPrice = cadPrice;
            Sunrail300Status = status;
        }

        public void Insert(System.Web.UI.WebControls.SqlDataSource dataSource, string table)
        {
            string sqlCount;
            string sqlInsert;
            string inchesInsert;
            System.Data.DataView selectTable = new System.Data.DataView();
            int count;

            sqlCount = "SELECT * FROM " + table;

            dataSource.SelectCommand = sqlCount;
            selectTable = (System.Data.DataView)dataSource.Select(System.Web.UI.DataSourceSelectArguments.Empty);

            //find out how many records are in the table in order to set the primary key
            count = selectTable.Count;

            if (Sunrail300MaxLengthInches == null)
            {

                inchesInsert = "null,null,";
            }
            else
            {
                inchesInsert = Sunrail300MaxLengthInches + ",'" + Sunrail300MaxLengthInchesUnits + "',";
            }

            //Insert
            sqlInsert = "INSERT INTO " + table
            + "(sr300ID,partName,description,partNumber,color,maxLengthFeet,lengthFeetUnits,maxLengthInches,lengthInchesUnits,usdPrice,cadPrice,status)"
            + "VALUES"
            + "(" + (count + 1) + ",'" + Sunrail300Name + "','" + Sunrail300Description + "','" + PartNumber + "','" + Sunrail300Color + "'," + Sunrail300MaxLengthFeet + ",'"
            + Sunrail300MaxLengthFeetUnits + "'," + inchesInsert
            + Sunrail300UsdPrice + "," + Sunrail300CadPrice + "," + 1 + ")";

            


            dataSource.InsertCommand = sqlInsert;
            dataSource.Insert();
        }

        //Database select all
        public System.Data.DataView SelectAll(System.Web.UI.WebControls.SqlDataSource dataSource, string table, string partNum)
        {
            //set up a dataview object for object member data
            System.Data.DataView anObjectTable = new System.Data.DataView();

            //select row based on table name and part number
            dataSource.SelectCommand = "SELECT partName, description, partNumber, color, maxLengthFeet, lengthFeetUnits, maxLengthInches,"
                            + " lengthInchesUnits, usdPrice, cadPrice, status FROM "
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

            if (Sunrail300Status)
            {
                bitStatus = 1;
            }
            else
            {
                bitStatus = 0;
            }

            dataSource.UpdateCommand = "UPDATE " + table
            + " SET description ='" + Sunrail300Description + "', maxLengthFeet=" + Sunrail300MaxLengthFeet + ", maxLengthInches="
            + Sunrail300MaxLengthInches + ", usdPrice=" + Sunrail300UsdPrice + ", cadPrice=" + Sunrail300CadPrice + ", status=" + bitStatus + 
            " WHERE partNumber = '" + partNum + "'";
            
            dataSource.Update();
        }

        //Populate member variables from a DataView object
        public void Populate(System.Data.DataView anObjectTable)
        {
            //populate object
            Sunrail300Name = anObjectTable[0][0].ToString();
            Sunrail300Description = anObjectTable[0][1].ToString();
            PartNumber = anObjectTable[0][2].ToString();
            Sunrail300Color = anObjectTable[0][3].ToString();
            Sunrail300MaxLengthFeet = Convert.ToInt32(anObjectTable[0][4]);
            Sunrail300MaxLengthFeetUnits = anObjectTable[0][5].ToString();
            if (anObjectTable[0][6] == DBNull.Value)
            {
                Sunrail300MaxLengthInches = null;
            }
            else
            {
                Sunrail300MaxLengthInches = Convert.ToInt32(anObjectTable[0][6]);
            }
            Sunrail300MaxLengthInchesUnits = anObjectTable[0][7].ToString();
            Sunrail300UsdPrice = Convert.ToDecimal(anObjectTable[0][8]);
            Sunrail300CadPrice = Convert.ToDecimal(anObjectTable[0][9]);
            Sunrail300Status = Convert.ToBoolean(anObjectTable[0][10]);
        }

        //Getters and Setters
        public string Sunrail300Name
        {
            set
            {
                sunrail300Name = value;
            }

            get
            {
                return sunrail300Name;
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

        public string Sunrail300Description
        {
            set
            {
                sunrail300Description = value;
            }

            get
            {
                return sunrail300Description;
            }
        }

        public string Sunrail300Color
        {
            set
            {
                sunrail300Color = value;
            }

            get
            {
                return sunrail300Color;
            }
        }

        public int Sunrail300MaxLengthFeet
        {
            set
            {
                sunrail300MaxLengthFeet = value;
            }

            get
            {
                return sunrail300MaxLengthFeet;
            }
        }

        public string Sunrail300MaxLengthFeetUnits
        {
            set
            {
                sunrail300MaxLengthFeetUnits = value;
            }

            get
            {
                return sunrail300MaxLengthFeetUnits;
            }
        }

        public int? Sunrail300MaxLengthInches
        {
            set
            {
                sunrail300MaxLengthInches = value;
            }

            get
            {
                return sunrail300MaxLengthInches;
            }
        }

        public string Sunrail300MaxLengthInchesUnits
        {
            set
            {
                sunrail300MaxLengthInchesUnits = value;
            }

            get
            {
                return sunrail300MaxLengthInchesUnits;
            }
        }

        public decimal Sunrail300UsdPrice
        {
            set
            {
                sunrail300UsdPrice = value;
            }

            get
            {
                return sunrail300UsdPrice;
            }
        }

        public decimal Sunrail300CadPrice
        {
            set
            {
                sunrail300CadPrice = value;
            }

            get
            {
                return sunrail300CadPrice;
            }
        }

        public bool Sunrail300Status
        {
            set
            {
                sunrail300Status = value;
            }

            get
            {
                return sunrail300Status;
            }
        }
    }
}
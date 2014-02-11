using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sunspace
{
    public class Sunrail1000
    {
        //Class members
        private string sunrail1000Name;
        private string partNumber;
        private string sunrail1000Description;
        private string sunrail1000Color;
        private int sunrail1000MaxLengthFeet;
        private string sunrail1000MaxLengthFeetUnits;
        private int? sunrail1000MaxLengthInches;
        private string sunrail1000MaxLengthInchesUnits;
        private decimal sunrail1000UsdPrice;
        private decimal sunrail1000CadPrice;
        private bool sunrail1000Status;

        //Constructors

        //Default constructor
        public Sunrail1000()
        {
            Sunrail1000Name = "";
            PartNumber = "";
            Sunrail1000Description = "";
            Sunrail1000Color = "";
            Sunrail1000MaxLengthFeet = 0;
            Sunrail1000MaxLengthFeetUnits = "";
            Sunrail1000MaxLengthInches = 0;
            Sunrail1000MaxLengthInchesUnits = "";
            Sunrail1000UsdPrice = 0.0m;
            Sunrail1000CadPrice = 0.0m;
            Sunrail1000Status = true;
        }

        //Parameterized constructor
        public Sunrail1000(string name, string number, string description, string color, int maxLengthFeet, string maxLengthFeetUnits, int maxLengthInches, string maxLengthInchesUnits,
                    decimal usdPrice, decimal cadPrice, bool status)
        {
            Sunrail1000Name = name;
            PartNumber = number;
            Sunrail1000Description = description;
            Sunrail1000Color = color;
            Sunrail1000MaxLengthFeet = maxLengthFeet;
            Sunrail1000MaxLengthFeetUnits = maxLengthFeetUnits;
            Sunrail1000MaxLengthInches = maxLengthInches;
            Sunrail1000MaxLengthInchesUnits = maxLengthInchesUnits;
            Sunrail1000UsdPrice = usdPrice;
            Sunrail1000CadPrice = cadPrice;
            Sunrail1000Status = status;
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

            if (Sunrail1000MaxLengthInches == null)
            {

                inchesInsert = "null,null,";
            }
            else
            {
                inchesInsert = Sunrail1000MaxLengthInches + ",'" + Sunrail1000MaxLengthInchesUnits + "',";
            }


            //Insert
            sqlInsert = "INSERT INTO " + table
            + "(sr1000ID,partName,description,partNumber,color,maxLengthFeet,lengthFeetUnits,maxLengthInches,lengthInchesUnits,usdPrice,cadPrice,status)"
            + "VALUES"
            + "(" + (count + 1) + ",'" + Sunrail1000Name + "','" + Sunrail1000Description + "','" + PartNumber + "','" + Sunrail1000Color + "'," + Sunrail1000MaxLengthFeet + ",'"
            + Sunrail1000MaxLengthFeetUnits + "'," + inchesInsert
            + Sunrail1000UsdPrice + "," + Sunrail1000CadPrice + "," + 1 + ")";


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

            if (Sunrail1000Status)
            {
                bitStatus = 1;
            }
            else
            {
                bitStatus = 0;
            }

            dataSource.UpdateCommand = "UPDATE " + table
            + " SET description ='" + Sunrail1000Description + "', maxLengthFeet=" + Sunrail1000MaxLengthFeet + ", maxLengthInches="
            + Sunrail1000MaxLengthInches + ", usdPrice=" + Sunrail1000UsdPrice + ", cadPrice=" + Sunrail1000CadPrice + ", status=" + bitStatus + 
            " WHERE partNumber = '" + partNum + "'";
            
            dataSource.Update();
        }

        //Populate member variables from a DataView object
        public void Populate(System.Data.DataView anObjectTable)
        {
            //populate object
            Sunrail1000Name = anObjectTable[0][0].ToString();
            Sunrail1000Description = anObjectTable[0][1].ToString();
            PartNumber = anObjectTable[0][2].ToString();
            Sunrail1000Color = anObjectTable[0][3].ToString();
            Sunrail1000MaxLengthFeet = Convert.ToInt32(anObjectTable[0][4]);
            Sunrail1000MaxLengthFeetUnits = anObjectTable[0][5].ToString();

            if (anObjectTable[0][6] != DBNull.Value)
            {
                Sunrail1000MaxLengthInches = Convert.ToInt32(anObjectTable[0][6]);
                Sunrail1000MaxLengthInchesUnits = anObjectTable[0][7].ToString();
            }

            Sunrail1000UsdPrice = Convert.ToDecimal(anObjectTable[0][8]);
            Sunrail1000CadPrice = Convert.ToDecimal(anObjectTable[0][9]);
            Sunrail1000Status = Convert.ToBoolean(anObjectTable[0][10]);
        }

        //Getters and Setters
        public string Sunrail1000Name
        {
            set
            {
                sunrail1000Name = value;
            }

            get
            {
                return sunrail1000Name;
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

        public string Sunrail1000Description
        {
            set
            {
                sunrail1000Description = value;
            }

            get
            {
                return sunrail1000Description;
            }
        }

        public string Sunrail1000Color
        {
            set
            {
                sunrail1000Color = value;
            }

            get
            {
                return sunrail1000Color;
            }
        }

        public int Sunrail1000MaxLengthFeet
        {
            set
            {
                sunrail1000MaxLengthFeet = value;
            }

            get
            {
                return sunrail1000MaxLengthFeet;
            }
        }

        public string Sunrail1000MaxLengthFeetUnits
        {
            set
            {
                sunrail1000MaxLengthFeetUnits = value;
            }

            get
            {
                return sunrail1000MaxLengthFeetUnits;
            }
        }

        public int? Sunrail1000MaxLengthInches
        {
            set
            {
                sunrail1000MaxLengthInches = value;
            }

            get
            {
                return sunrail1000MaxLengthInches;
            }
        }

        public string Sunrail1000MaxLengthInchesUnits
        {
            set
            {
                sunrail1000MaxLengthInchesUnits = value;
            }

            get
            {
                return sunrail1000MaxLengthInchesUnits;
            }
        }

        public decimal Sunrail1000UsdPrice
        {
            set
            {
                sunrail1000UsdPrice = value;
            }

            get
            {
                return sunrail1000UsdPrice;
            }
        }

        public decimal Sunrail1000CadPrice
        {
            set
            {
                sunrail1000CadPrice = value;
            }

            get
            {
                return sunrail1000CadPrice;
            }
        }

        public bool Sunrail1000Status
        {
            set
            {
                sunrail1000Status = value;
            }

            get
            {
                return sunrail1000Status;
            }
        }
    }
}
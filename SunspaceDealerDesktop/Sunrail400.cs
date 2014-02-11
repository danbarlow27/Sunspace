using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sunspace
{
    public class Sunrail400
    {
        //Class members
        private string sunrail400Name;
        private string partNumber;
        private string sunrail400Description;
        private string sunrail400Color;
        private int sunrail400MaxLengthFeet;
        private string sunrail400MaxLengthFeetUnits;
        private int? sunrail400MaxLengthInches;
        private string sunrail400MaxLengthInchesUnits;
        private decimal sunrail400UsdPrice;
        private decimal sunrail400CadPrice;
        private bool sunrail400Status;

        //Constructors

        //Default constructor
        public Sunrail400()
        {
            Sunrail400Name = "";
            PartNumber = "";
            Sunrail400Description = "";
            Sunrail400Color = "";
            Sunrail400MaxLengthFeet = 0;
            Sunrail400MaxLengthFeetUnits = "";
            Sunrail400MaxLengthInches = 0;
            Sunrail400MaxLengthInchesUnits = "";
            Sunrail400UsdPrice = 0.0m;
            Sunrail400CadPrice = 0.0m;
            Sunrail400Status = true;
        }

        //Parameterized constructor
        public Sunrail400(string name, string number, string description, string color, int maxLengthFeet, string maxLengthFeetUnits, int maxLengthInches, string maxLengthInchesUnits,
                    decimal usdPrice, decimal cadPrice, bool status)
        {
            Sunrail400Name = name;
            PartNumber = number;
            Sunrail400Description = description;
            Sunrail400Color = color;
            Sunrail400MaxLengthFeet = maxLengthFeet;
            Sunrail400MaxLengthFeetUnits = maxLengthFeetUnits;
            Sunrail400MaxLengthInches = maxLengthInches;
            Sunrail400MaxLengthInchesUnits = maxLengthInchesUnits;
            Sunrail400UsdPrice = usdPrice;
            Sunrail400CadPrice = cadPrice;
            Sunrail400Status = status;
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
            + "(sr400ID,partName,description,partNumber,color,maxLengthFeet,lengthFeetUnits,maxLengthInches,lengthInchesUnits,usdPrice,cadPrice,status)"
            + "VALUES(" + (count + 1) + ",'" + Sunrail400Name + "','" + Sunrail400Description + "','" + PartNumber + "','" + Sunrail400Color + "'," + Sunrail400MaxLengthFeet + ",'"
            + Sunrail400MaxLengthFeetUnits + "'," + Sunrail400MaxLengthInches + ",'" + Sunrail400MaxLengthInchesUnits + "',"
            + Sunrail400UsdPrice + "," + Sunrail400CadPrice + "," + 1 + ")";

            if (Sunrail400MaxLengthInches== null)
            {
                sqlInsert = "INSERT INTO " + table
            + "(sr400ID,partName,description,partNumber,color,maxLengthFeet,lengthFeetUnits,maxLengthInches,lengthInchesUnits,usdPrice,cadPrice,status)"
            + "VALUES(" + (count + 1) + ",'" + Sunrail400Name + "','" + Sunrail400Description + "','" + PartNumber + "','" + Sunrail400Color + "'," + Sunrail400MaxLengthFeet + ",'"
            + Sunrail400MaxLengthFeetUnits + "',null,null,"
            + Sunrail400UsdPrice + "," + Sunrail400CadPrice + "," + 1 + ")";
            }


            //Null Insert

            
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

            if (Sunrail400Status)
            {
                bitStatus = 1;
            }
            else
            {
                bitStatus = 0;
            }

            dataSource.UpdateCommand = "UPDATE " + table
            + " SET description ='" + Sunrail400Description + "', maxLengthFeet=" + Sunrail400MaxLengthFeet + ", maxLengthInches="
            + Sunrail400MaxLengthInches + ", usdPrice=" + Sunrail400UsdPrice + ", cadPrice=" + Sunrail400CadPrice + ", status=" + bitStatus + 
            " WHERE partNumber = '" + partNum + "'";
            
            dataSource.Update();
        }

        //Populate member variables from a DataView object
        public void Populate(System.Data.DataView anObjectTable)
        {
            //populate object
            Sunrail400Name = anObjectTable[0][0].ToString();
            Sunrail400Description = anObjectTable[0][1].ToString();
            PartNumber = anObjectTable[0][2].ToString();
            Sunrail400Color = anObjectTable[0][3].ToString();
            Sunrail400MaxLengthFeet = Convert.ToInt32(anObjectTable[0][4]);
            Sunrail400MaxLengthFeetUnits = anObjectTable[0][5].ToString();
            if (anObjectTable[0][6] == DBNull.Value)
            {
                Sunrail400MaxLengthInches = null;
            }
            else
            {
                Sunrail400MaxLengthInches = Convert.ToInt32(anObjectTable[0][6]);
            }
            Sunrail400MaxLengthInchesUnits = anObjectTable[0][7].ToString();
            Sunrail400UsdPrice = Convert.ToDecimal(anObjectTable[0][8]);
            Sunrail400CadPrice = Convert.ToDecimal(anObjectTable[0][9]);
            Sunrail400Status = Convert.ToBoolean(anObjectTable[0][10]);
        }

        //Getters and Setters
        public string Sunrail400Name
        {
            set
            {
                sunrail400Name = value;
            }

            get
            {
                return sunrail400Name;
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

        public string Sunrail400Description
        {
            set
            {
                sunrail400Description = value;
            }

            get
            {
                return sunrail400Description;
            }
        }

        public string Sunrail400Color
        {
            set
            {
                sunrail400Color = value;
            }

            get
            {
                return sunrail400Color;
            }
        }

        public int Sunrail400MaxLengthFeet
        {
            set
            {
                sunrail400MaxLengthFeet = value;
            }

            get
            {
                return sunrail400MaxLengthFeet;
            }
        }

        public string Sunrail400MaxLengthFeetUnits
        {
            set
            {
                sunrail400MaxLengthFeetUnits = value;
            }

            get
            {
                return sunrail400MaxLengthFeetUnits;
            }
        }

        public int? Sunrail400MaxLengthInches
        {
            set
            {
                sunrail400MaxLengthInches = value;
            }

            get
            {
                return sunrail400MaxLengthInches;
            }
        }

        public string Sunrail400MaxLengthInchesUnits
        {
            set
            {
                sunrail400MaxLengthInchesUnits = value;
            }

            get
            {
                return sunrail400MaxLengthInchesUnits;
            }
        }

        public decimal Sunrail400UsdPrice
        {
            set
            {
                sunrail400UsdPrice = value;
            }

            get
            {
                return sunrail400UsdPrice;
            }
        }

        public decimal Sunrail400CadPrice
        {
            set
            {
                sunrail400CadPrice = value;
            }

            get
            {
                return sunrail400CadPrice;
            }
        }

        public bool Sunrail400Status
        {
            set
            {
                sunrail400Status = value;
            }

            get
            {
                return sunrail400Status;
            }
        }
    }
}
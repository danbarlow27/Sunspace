/*
 * Dan Barlow
 * November 6, 2012
 * RoofExtrusion.cs version 1.0
 */ 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Sunspace
{
    public class RoofExtrusion
    {
        //Class members
        private string extrusionName;
        private string extrusionNumber;
        private string extrusionDescription;
        private string extrusionColor;
        private int extrusionSize;
        private string sizeUnits;
        private int angleA;
        private string angleAUnits;
        private decimal angleB;
        private string angleBUnits;
        private int angleC;
        private string angleCUnits;
        private int extrusionMaxLength;
        private string maxLengthUnits;
        private decimal cadPrice;
        private decimal usdPrice;
        private bool status;

        //Constructors

        //Default constructor
        public RoofExtrusion()
        {
            ExtrusionName = "";
            ExtrusionNumber = "";
            ExtrusionDescription = "";
            ExtrusionColor = "";
            ExtrusionSize = 0;
            SizeUnits = "";
            AngleA = 0;
            AngleAUnits = "";
            AngleB = 0.0m;
            AngleBUnits = "";
            AngleC = 0;
            AngleCUnits = "";
            ExtrusionMaxLength = 0;
            MaxLengthUnits = "";
            CadPrice = 0.0m;
            UsdPrice = 0.0m;
            Status = true;
        }

        //Parameterized constructor
        public RoofExtrusion(string name, string number, string description, string color, int size, string sizeUnits, int angleA, string angleAUnits,
            decimal angleB, string angleBUnits, int angleC, string angleCUnits, int maxLength, string maxLengthUnits, decimal cadPrice, decimal usdPrice, bool status)
        {
            ExtrusionName = name;
            ExtrusionNumber = number;
            ExtrusionDescription = description;
            ExtrusionColor = color;
            ExtrusionSize = size;
            SizeUnits = sizeUnits;
            AngleA = angleA;
            AngleAUnits = angleAUnits;
            AngleB = angleB;
            AngleBUnits = angleBUnits;
            AngleC = angleC;
            AngleCUnits = angleCUnits;
            ExtrusionMaxLength = maxLength;
            MaxLengthUnits = maxLengthUnits;
            CadPrice = cadPrice;
            UsdPrice = usdPrice;
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
            + "(extrusionID,partName,description,partNumber,size,sizeUnits,color,extrusionAngleA,angleAUnits,extrusionAngleB,angleBUnits,extrusionAngleC,angleCUnits,maxLength,lengthUnits,usdPrice,cadPrice,status)"
            + "VALUES"
            + "(" + (count + 1) + ",'" + ExtrusionName + "','" + ExtrusionDescription + "','" + ExtrusionNumber + "'," + ExtrusionSize + ",'"
            + SizeUnits + "','" + ExtrusionColor + "'," + AngleA + ",'" + AngleAUnits + "'," + AngleB + ",'" + AngleBUnits + "'," + AngleC + ",'" + AngleCUnits + "'," + ExtrusionMaxLength + ",'" + MaxLengthUnits + "',"
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
            dataSource.SelectCommand = "SELECT partName, description, partNumber, color, size, sizeUnits, extrusionAngleA,"
                            + " angleAUnits, extrusionAngleB, angleBUnits, extrusionAngleC, angleCUnits, maxLength, lengthUnits, usdPrice, cadPrice, status FROM "
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
            + " SET description ='" + ExtrusionDescription + "', size=" + ExtrusionSize + ", sizeUnits='" + SizeUnits 
            + "', extrusionAngleA=" + AngleA + ", angleAUnits='" + AngleAUnits + "', extrusionAngleB=" + AngleB 
            + ", angleBUnits='" + AngleBUnits + "', extrusionAngleC=" + AngleC + ", angleCUnits='" + AngleCUnits
            + "', maxLength=" + ExtrusionMaxLength + ", lengthUnits='" + MaxLengthUnits + "', usdPrice=" + UsdPrice 
            + ", cadPrice=" + CadPrice + ", status=" + bitStatus + 
            " WHERE partNumber = '" + partNum + "'";
            
            dataSource.Update();
        }

        //Populate member variables from a DataView object
        public void Populate(System.Data.DataView anObjectTable)
        {
            //populate object
            ExtrusionName = anObjectTable[0][0].ToString();
            ExtrusionDescription = anObjectTable[0][1].ToString();
            ExtrusionNumber = anObjectTable[0][2].ToString();
            ExtrusionColor = anObjectTable[0][3].ToString();
            ExtrusionMaxLength = Convert.ToInt32(anObjectTable[0][12]);
            MaxLengthUnits = anObjectTable[0][13].ToString();
            UsdPrice = Convert.ToDecimal(anObjectTable[0][14]);
            CadPrice = Convert.ToDecimal(anObjectTable[0][15]);
            Status = Convert.ToBoolean(anObjectTable[0][16]);

            //conditional field population, based on whether database value is null or not
            if (anObjectTable[0][4] != DBNull.Value)
            {
                ExtrusionSize = Convert.ToInt32(anObjectTable[0][4]);
                SizeUnits = anObjectTable[0][5].ToString();
            }

            if (anObjectTable[0][6] != DBNull.Value)
            {
                AngleA = Convert.ToInt32(anObjectTable[0][6]);
                AngleAUnits = anObjectTable[0][7].ToString();
            }

            if (anObjectTable[0][8] != DBNull.Value)
            {
                AngleB = Convert.ToDecimal(anObjectTable[0][8]);
                AngleBUnits = anObjectTable[0][9].ToString();
            }

            if (anObjectTable[0][10] != DBNull.Value)
            {
                AngleC = Convert.ToInt32(anObjectTable[0][10]);
                AngleCUnits = anObjectTable[0][11].ToString();
            }
        }

        //Getters and Setters
        public string ExtrusionName
        {
            set
            {
                extrusionName = value;
            }

            get
            {
                return extrusionName;
            }
        }

        public string ExtrusionNumber
        {
            set
            {
                extrusionNumber = value;
            }

            get
            {
                return extrusionNumber;
            }
        }

        public string ExtrusionDescription
        {
            set
            {
                extrusionDescription = value;
            }

            get
            {
                return extrusionDescription;
            }
        }

        public string ExtrusionColor
        {
            set
            {
                extrusionColor = value;
            }

            get
            {
                return extrusionColor;
            }
        }

        public int ExtrusionSize
        {
            set
            {
                extrusionSize = value;
            }

            get
            {
                return extrusionSize;
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

        public int AngleA
        {
            set
            {
                angleA = value;
            }

            get
            {
                return angleA;
            }
        }

        public string AngleAUnits
        {
            set
            {
                angleAUnits = value;
            }

            get
            {
                return angleAUnits;
            }
        }

        public decimal AngleB
        {
            set
            {
                angleB = value;
            }

            get
            {
                return angleB;
            }
        }

        public string AngleBUnits
        {
            set
            {
                angleBUnits = value;
            }

            get
            {
                return angleBUnits;
            }
        }

        public int AngleC
        {
            set
            {
                angleC = value;
            }

            get
            {
                return angleC;
            }
        }

        public string AngleCUnits
        {
            set
            {
                angleCUnits = value;
            }

            get
            {
                return angleCUnits;
            }
        }

        public int ExtrusionMaxLength
        {
            set
            {
                extrusionMaxLength = value;
            }

            get
            {
                return extrusionMaxLength;
            }
        }

        public string MaxLengthUnits
        {
            set
            {
                maxLengthUnits = value;
            }

            get
            {
                return maxLengthUnits;
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
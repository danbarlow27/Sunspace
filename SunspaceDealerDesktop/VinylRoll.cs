using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sunspace
{
    public class VinylRoll
    {
        //Class members
        private string vinylRollName;
        private string partNumber;
        private string vinylRollColor;
        private int vinylRollWidth;
        private string vinylRollWidthUnits;
        private int vinylRollWeight;
        private string vinylRollWeightUnits;
        private decimal usdPrice;
        private decimal cadPrice;
        private bool status;

        //Constructors

        //Default constructor
        public VinylRoll()
        {
            VinylRollName = "";
            PartNumber = "";
            VinylRollColor = "";
            VinylRollWidth = 0;
            VinylRollWidthUnits = "";
            VinylRollWeight = 0;
            VinylRollWeightUnits = "";
            UsdPrice = 0.0m;
            CadPrice = 0.0m;
            Status = true;
        }

        //Parameterized constructor
        public VinylRoll(string name, string number, string color, int width, string widthUnits, 
                        int weight, string weightUnits, decimal usd, decimal cad, bool status)
        {
            VinylRollName = name;
            PartNumber = number;
            VinylRollColor = color;
            VinylRollWidth = width;
            VinylRollWidthUnits = widthUnits;
            VinylRollWeight = weight;
            VinylRollWeightUnits = weightUnits;
            UsdPrice = usd;
            CadPrice = cad;
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
            + "(rollID,partName,partNumber,color,width,widthUnits,weight,weightUnits,usdPrice,cadPrice,status)"
            + "VALUES"
            + "(" + (count + 1) + ",'" + VinylRollName + "','" + PartNumber + "','" + VinylRollColor + "'," + VinylRollWidth + ",'" + VinylRollWidthUnits + "',"
            + VinylRollWeight + ",'" + VinylRollWeightUnits + "',"
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
            dataSource.SelectCommand = "SELECT partName, partNumber, color, width, widthUnits, "
                            + "weight, weightUnits, usdPrice, cadPrice, status FROM "
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
            + " SET width =" + VinylRollWidth + ", widthUnits='" + VinylRollWidthUnits + "', weight=" + VinylRollWeight + ", weightUnits='" + VinylRollWeightUnits
            + "', usdPrice=" + UsdPrice + ", cadPrice=" + CadPrice + ", status=" + bitStatus + 
            " WHERE partNumber = '" + partNum + "'";
            
            dataSource.Update();
        }

        //Populate member variables from a DataView object
        public void Populate(System.Data.DataView anObjectTable)
        {
            //populate object
            VinylRollName = anObjectTable[0][0].ToString();
            PartNumber = anObjectTable[0][1].ToString();
            VinylRollColor = anObjectTable[0][2].ToString();
            VinylRollWidth = Convert.ToInt32(anObjectTable[0][3]);
            VinylRollWidthUnits = anObjectTable[0][4].ToString();
            VinylRollWeight = Convert.ToInt32(anObjectTable[0][5]);
            VinylRollWeightUnits = anObjectTable[0][6].ToString();
            UsdPrice = Convert.ToDecimal(anObjectTable[0][7]);
            CadPrice = Convert.ToDecimal(anObjectTable[0][8]);
            Status = Convert.ToBoolean(anObjectTable[0][9]);           
        }

        //Getters and Setters
        public string VinylRollName
        {
            set
            {
                vinylRollName = value;
            }

            get
            {
                return vinylRollName;
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

        public string VinylRollColor
        {
            set
            {
                vinylRollColor = value;
            }

            get
            {
                return vinylRollColor;
            }
        }

        public int VinylRollWidth
        {
            set
            {
                vinylRollWidth = value;
            }

            get
            {
                return vinylRollWidth;
            }
        }

        public string VinylRollWidthUnits
        {
            set
            {
                vinylRollWidthUnits = value;
            }

            get
            {
                return vinylRollWidthUnits;
            }
        }

        public int VinylRollWeight
        {
            set
            {
                vinylRollWeight = value;
            }

            get
            {
                return vinylRollWeight;
            }
        }

        public string VinylRollWeightUnits
        {
            set
            {
                vinylRollWeightUnits = value;
            }

            get
            {
                return vinylRollWeightUnits;
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
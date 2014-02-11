/*
 * Shayne Quinton
 * November 7, 2012
 * Schematics.cs version 1.0
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Sunspace
{

    public class Part
    {
        private string schematicNumber;
        private string partNumber;
        private int partKeyNumber;
        private string partName;
        private string partImage;
        private decimal partCadPrice;
        private decimal partUsdPrice;

        public Part()
        {
            schematicNumber = "";
            partNumber = "";
            partKeyNumber = 0;
            partName = "";
            partImage = "";
            partCadPrice = 1.00m;
            partUsdPrice = 1.00m;
        }
        public Part(string sNumber, string pNumber, int pkNumber, string pName, string pImage,
        decimal pCadPrice, decimal pUsdPrice)
        {
            SchematicNumber = sNumber;
            PartNumber = pNumber;
            PartKeyNumber = pkNumber;
            PartName = pName;
            PartImage = pImage;
            PartCadPrice = pCadPrice;
            PartUsdPrice = pUsdPrice;

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
        public string SchematicNumber
        {
            set
            {
                schematicNumber = value;
            }
            get
            {
                return schematicNumber;
            }

        }
        public int PartKeyNumber
        {
            set
            {
                partKeyNumber = value;
            }
            get
            {
                return partKeyNumber;
            }
        }

        public string PartName
        {
            set
            {
                partName = value;
            }
            get
            {
                return partName;
            }

        }

        public string PartImage
        {
            set
            {
                partImage = value;
            }
            get
            {
                return partImage;
            }
        }
        public decimal PartCadPrice
        {
            set
            {
                partCadPrice = value;
            }
            get
            {
                return partCadPrice;
            }
        }
        public decimal PartUsdPrice
        {
            set
            {
                partUsdPrice = value;
            }
            get
            {
                return partUsdPrice;
            }
        }

        //Database update
        public void Update(System.Web.UI.WebControls.SqlDataSource dataSource, string partNum)
        {
            dataSource.UpdateCommand = "UPDATE tblSchematicParts SET usdPrice=" + PartUsdPrice
            + ", cadPrice=" + PartCadPrice 
            + " WHERE partNumber = '" + partNum + "'";

            dataSource.Update();
        }

        //Select all parts from the database
        public System.Data.DataView SelectAll(System.Web.UI.WebControls.SqlDataSource dataSource, string partNum, string schematicNum)
        {
            //set up a dataview object for object member data
            System.Data.DataView anObjectTable = new System.Data.DataView();

            //select row based on table name and part number
            dataSource.SelectCommand = "SELECT tblParts.partNumber,tblParts.partName,tblSchematicParts.SchematicNumber, tblSchematicParts.usdPrice, tblSchematicParts.cadPrice, "+
                                        "tblSchematicParts.keyNumber "+
                                        "FROM tblParts "+
                                        "INNER JOIN tblSchematicParts "+
                                        "ON tblParts.partNumber = tblSchematicParts.partNumber "+
                                        "WHERE tblParts.partNumber = '" + partNum + "' AND tblSchematicParts.schematicNumber= '" + schematicNum + "'";
                                   
            //assign the row to the dataview object
            anObjectTable = (System.Data.DataView)dataSource.Select(System.Web.UI.DataSourceSelectArguments.Empty);

            //return the DataView object
            return anObjectTable;
        }

        //Populate member variables from a DataView object
        public void Populate(System.Data.DataView anObjectTable)
        {
            //populate object
            PartNumber = anObjectTable[0][0].ToString();
            PartName = anObjectTable[0][1].ToString();
            SchematicNumber = anObjectTable[0][2].ToString();
            PartUsdPrice = (Decimal)anObjectTable[0][3];
            PartCadPrice = (Decimal)anObjectTable[0][4];
            PartKeyNumber = Convert.ToInt32(anObjectTable[0][5]);
        }
    }

    public class Schematics
    {
        private string schematicNumber;
        private string schematicDescription;
        private string schematicName;
        private string schematicImage; //filename string
        private decimal schematicCadPrice;
        private decimal schematicUsdPrice;
        private bool schematicStatus;

        

        public Schematics()
        {
            SchematicName = "";
            schematicDescription = "";
            SchematicNumber="";
            SchematicImage ="";
            SchematicCadPrice = 1;
            SchematicUsdPrice = 1;
            SchematicStatus = true;
        }

        public Schematics(string name, string number,string image,
                    decimal cadprice, decimal usdprice, bool status)
        {
            SchematicName = name;
            SchematicNumber = number;
           
            SchematicImage = image;
            SchematicCadPrice = cadprice;
            SchematicUsdPrice = usdprice;
            SchematicStatus = status;
        }

        //Database update
        public void Update(System.Web.UI.WebControls.SqlDataSource dataSource, string partNum)
        {
            int bitStatus;

            if (SchematicStatus)
            {
                bitStatus = 1;
            }
            else
            {
                bitStatus = 0;
            }

            dataSource.UpdateCommand = "UPDATE tblSchematics SET description ='" + SchematicDescription + "', usdPrice=" + SchematicUsdPrice
            + ", cadPrice=" + SchematicCadPrice + ", status=" + bitStatus +
            " WHERE schematicNumber = '" + partNum + "'";

            dataSource.Update();
        }

        //Select all parts from the database
        public System.Data.DataView SelectAll(System.Web.UI.WebControls.SqlDataSource dataSource, string table, string partNum)
        {
            //set up a dataview object for object member data
            System.Data.DataView anObjectTable = new System.Data.DataView();

            //select row based on table name and part number
            dataSource.SelectCommand = "SELECT schematicNumber, description, partName, usdPrice, cadPrice, status FROM " + table + " WHERE schematicNumber='" + partNum + "'";

            //assign the row to the dataview object
            anObjectTable = (System.Data.DataView)dataSource.Select(System.Web.UI.DataSourceSelectArguments.Empty);

            //return the DataView object
            return anObjectTable;
        }

        //Populate member variables from a DataView object
        public void Populate(System.Data.DataView anObjectTable)
        {
            //populate object
            SchematicNumber = anObjectTable[0][0].ToString();
            SchematicDescription = anObjectTable[0][1].ToString();
            SchematicName = anObjectTable[0][2].ToString();
            SchematicUsdPrice = (Decimal)anObjectTable[0][3];
            SchematicCadPrice = (Decimal)anObjectTable[0][4];
            SchematicStatus = (Boolean)anObjectTable[0][5];
        }

        public string SchematicName
        {
            set
            {
                schematicName = value;
            }

            get
            {
                return schematicName;
            }
        }

        public string SchematicDescription
        {
            set
            {
                schematicDescription = value;
            }

            get
            {
                return schematicDescription;
            }
        }

        public string SchematicNumber
        {
            set
            {
                schematicNumber = value;
            }

            get
            {
                return schematicNumber;
            }
        }

       
     

        public string SchematicImage
        {
            set
            {
                schematicImage = value;
            }

            get
            {
                return schematicImage;
            }
        }


   
        public decimal SchematicCadPrice
        {
            set
            {
                schematicCadPrice = value;
            }

            get
            {
                return schematicCadPrice;
            }
        }

        public decimal SchematicUsdPrice
        {
            set
            {
                schematicUsdPrice = value;
            }

            get
            {
                return schematicUsdPrice;
            }
        }

        public bool SchematicStatus
        {
            set
            {
                schematicStatus = value;
            }

            get
            {
                return schematicStatus;
            }
        }
    }
}
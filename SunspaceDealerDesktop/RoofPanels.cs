using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sunspace
{
    public class RoofPanels
    {
        //Class members
        private string panelName;
        private string panelDescription;
        private string panelComposition;
        private string panelStandard;
        private string panelColor;
        private string partNumber;
        private int panelSize;
        private string panelSizeUnits;
        private int panelMaxWidth;
        private string maxWidthUnits;
        private string panelMaxLength;
        private decimal cadPrice;
        private decimal usdPrice;
        private bool status;

        //Constructors

        //Default constructor
        public RoofPanels()
        {
            PanelName = "";
            PanelDescription = "";
            PanelComposition = "";
            PanelStandard = "";
            PanelColor = "";
            PartNumber = "";
            PanelSize = 0;
            PanelSizeUnits = "";
            PanelMaxWidth = 0;
            PanelMaxLength = "";
            MaxWidthUnits = "";
            UsdPrice = 0.0m;
            CadPrice = 0.0m;
            Status = true;
        }

        //Parameterized constructor
        public RoofPanels(string name, string description, string composition, string standard, string color, string number, int size, string sizeUnits, int maxWidth, string maxWidthUnits,
                            string maxLength, decimal usdPrice, decimal cadPrice, bool status)
        {
            PanelName = name;
            PanelDescription = description;
            PanelComposition = composition;
            PanelStandard = standard;
            PanelColor = color;
            PartNumber = number;
            PanelSize = size;
            PanelSizeUnits = sizeUnits;
            PanelMaxWidth = maxWidth;
            MaxWidthUnits = maxWidthUnits;
            PanelMaxLength = maxLength;
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
            + "(panelID,partName,description,composition,standard,color,partNumber,size,sizeUnits,maxWidth,widthUnits,maxLength,usdPrice,cadPrice,status)"
            + "VALUES"
            + "(" + (count + 1) + ",'" + PanelName + "','" + PanelDescription + "','" + PanelComposition + "','" + PanelStandard + "','"
            + PanelColor + "','" + PartNumber + "'," + PanelSize + ",'" + PanelSizeUnits + "'," + PanelMaxWidth + ",'" + MaxWidthUnits + "','" + PanelMaxLength + "',"
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
            dataSource.SelectCommand = "SELECT partName, description, composition, standard, color, partNumber, size, sizeUnits,"
                            + " maxWidth, widthUnits, maxLength, usdPrice, cadPrice, status FROM "
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
            + " SET description ='" + PanelDescription + "', composition='" + PanelComposition + "', standard='" + PanelStandard + "', color='" + PanelColor + "', size=" + PanelSize 
            + ", sizeUnits='" + PanelSizeUnits
            + "', maxWidth=" + PanelMaxWidth + ", widthUnits='" + MaxWidthUnits + "', maxLength='" + PanelMaxLength + "', usdPrice=" + UsdPrice
            + ", cadPrice=" + CadPrice + ", status=" + bitStatus +
            " WHERE partNumber = '" + partNum + "'";
            
            dataSource.Update();
        }

        //Populate member variables from a DataView object
        public void Populate(System.Data.DataView anObjectTable)
        {
            //populate object
            PanelName = anObjectTable[0][0].ToString();
            PanelDescription = anObjectTable[0][1].ToString();
            PanelComposition = anObjectTable[0][2].ToString();
            panelStandard = anObjectTable[0][3].ToString();
            PanelColor = anObjectTable[0][4].ToString();
            PartNumber = anObjectTable[0][5].ToString();
            PanelSize = Convert.ToInt32(anObjectTable[0][6]);
            PanelSizeUnits = anObjectTable[0][7].ToString();
            PanelMaxWidth = Convert.ToInt32(anObjectTable[0][8]);
            MaxWidthUnits = anObjectTable[0][9].ToString();
            PanelMaxLength = anObjectTable[0][10].ToString();
            UsdPrice = Convert.ToDecimal(anObjectTable[0][11]);
            CadPrice = Convert.ToDecimal(anObjectTable[0][12]);
            Status = Convert.ToBoolean(anObjectTable[0][13]);
        }

        //Getters and Setters
        public string PanelName
        {
            set
            {
                panelName = value;
            }

            get
            {
                return panelName;
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

        public string PanelDescription
        {
            set
            {
                panelDescription = value;
            }

            get
            {
                return panelDescription;
            }
        }

        public string PanelStandard
        {
            set
            {
                panelStandard = value;
            }

            get
            {
                return panelStandard;
            }
        }

        public string PanelComposition
        {
            set
            {
                panelComposition = value;
            }

            get
            {
                return panelComposition;
            }
        }

        public string PanelColor
        {
            set
            {
                panelColor = value;
            }

            get
            {
                return panelColor;
            }
        }

        public int PanelSize
        {
            set
            {
                panelSize = value;
            }

            get
            {
                return panelSize;
            }
        }

        public string PanelSizeUnits
        {
            set
            {
                panelSizeUnits = value;
            }

            get
            {
                return panelSizeUnits;
            }
        }

        public int PanelMaxWidth
        {
            set
            {
                panelMaxWidth = value;
            }

            get
            {
                return panelMaxWidth;
            }
        }

        public string MaxWidthUnits
        {
            set
            {
                maxWidthUnits = value;
            }

            get
            {
                return maxWidthUnits;
            }
        }

        public string PanelMaxLength
        {
            set
            {
                panelMaxLength = value;
            }

            get
            {
                return panelMaxLength;
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
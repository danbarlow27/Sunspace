using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SunspaceDealerDesktop
{
    public partial class _Default : Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["newSession"];
            

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Session.Add("testing", hiddenVar.Value);

            string lineArrayInfo = hiddenVar.Value;

            char[] charDelimiter = { ',', '/' };

            string[] lineInfo = lineArrayInfo.Split(charDelimiter, StringSplitOptions.RemoveEmptyEntries);

            int numberOfElements = 6;

            int dimensions = lineInfo.Length / numberOfElements;

            string[,] newArray = new string[dimensions, numberOfElements];

            //int count = 0;

            for (int i = 0; i < dimensions; i++)
            {
                for (int j = 0; j < numberOfElements; j++)
                {
                    newArray[i, j] = lineInfo[(numberOfElements*i)+j];
                }
            }

            Session.Add("viewingArray", newArray[3, 5]);

            Response.Redirect("TestingHiddens.aspx");
        }
    }
}
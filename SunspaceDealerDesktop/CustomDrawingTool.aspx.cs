/*
 * File name: Default.aspx.cs
 * Version: 1.0
 * Date Last Modified:16/06/13
 * Notes: Changes may be needed to meet the structure of the wall class
 **/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SunspaceDealerDesktop
{
    public partial class CustomDrawingTool : Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["newSession"];
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            //Adds the concatenated string from the hidden field to the Session in C#
            Session.Add("testing", hiddenVar.Value);

            ////Character array to hold the delimiters to parse the string being passed from Javascript/Client-side
            //char[] charDelimiter = { ',', '/' };

            ////Array of values from the hidden field string without all the delimiters
            //string[] lineInfo = (hiddenVar.Value).Split(charDelimiter, StringSplitOptions.RemoveEmptyEntries);

            ////Number of elements per line
            //int numberOfElements = 6;

            ////Calculated amount of lines that are being passed
            //int numberOfWalls = lineInfo.Length / numberOfElements;

            ////Rectangular array to hold individual line information (i.e. newArray[0,0] to newArray[0,6] is all the information of the first line)
            //string[,] newArray = new string[numberOfWalls, numberOfElements];

            ////Outer loop to handle the amount of walls/lines being passed
            //for (int i = 0; i < numberOfWalls; i++)
            //{
            //    //Inner loop to handle the amount of variables arguments which belong to each line (6 variables to store, constant)
            //    for (int j = 0; j < numberOfElements; j++)
            //    {
            //        //Storing line information to their respective place in the array
            //        newArray[i, j] = lineInfo[(numberOfElements*i)+j];
            //    }
            //}

            //Session.Add("numberOfWalls", numberOfWalls);
            //Session.Add("numberOfElements", numberOfElements);
            ////Adding one element to the session for testing purposes
            //Session.Add("testArray", newArray);

            //Redirect to test page to see if information is being passed properly
            Response.Redirect("TestingHiddens.aspx");
        }
    }
}
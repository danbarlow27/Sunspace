﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SunspaceDealerDesktop
{
    public partial class TestNumMods : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Object> testList = new List<Object>();

            Wall aWall = new Wall();
            
            testList.Add(aWall);

            testList[0].ToString();

            aWall.ProposedLength = 178f;
            aWall.TotalCornerLength = 3.125f;
            aWall.TotalReceiverLength = 2;
            tester.InnerHtml = aWall.FindOptimalNumberOfMods();
            tester2.InnerHtml = aWall.FindOptimalSizeOfMods(10);
            //tester.InnerHtml += "\n" + "Proposed: " + aWall.ProposedLength + ", Actual: " + aWall.ActualLength; 
            tester.InnerHtml = testList[0].ToString();
        }
    }
}
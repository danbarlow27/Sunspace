﻿using System;
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
            Response.Redirect("TestingHiddens.aspx");
        }
    }
}
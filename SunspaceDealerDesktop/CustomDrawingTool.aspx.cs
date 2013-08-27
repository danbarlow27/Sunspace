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
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SunspaceDealerDesktop
{
    public partial class CustomDrawingTool : Page
    {
        public string gableStyle;
        public bool isStandalone;

        protected void Page_Load(object sender, EventArgs e)
        {
            isStandalone = false;
            if (Session["loggedIn"] == null)
            {
                //uncomment me when login functionality is working
                Response.Redirect("Login.aspx");
                //Session.Add("loggedIn", "userA");
            }

            //Session["newSession"];
            string[] newProjectArray = (string[])Session["newProjectArray"];
            gableStyle = newProjectArray[26].ToString();
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            //Adds the concatenated string from the hidden field to the Session in C#
            Session.Add("lineInfo", hiddenVar.Value);           

            //Redirect to test page to see if information is being passed properly
            Response.Redirect("WizardWallsAndMods.aspx");
        }
    }
}
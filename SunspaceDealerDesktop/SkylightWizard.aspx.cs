﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Script.Serialization;

namespace SunspaceDealerDesktop
{
    public partial class SkylightWizard : System.Web.UI.Page
    {
        public int totalPanels=0;
        public string panelSizes;
        public float SKYLIGHT_WIDTH = Constants.SKYLIGHT_WIDTH;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //for both
                List<RoofItem> testItems = new List<RoofItem>();
                testItems.Add(new RoofItem("Foam Panel", 276f, 48f));
                testItems.Add(new RoofItem("I-Beam", 276f, 0.5f));
                testItems.Add(new RoofItem("Foam Panel", 276f, 48f));
                testItems.Add(new RoofItem("I-Beam", 276f, 0.5f));
                testItems.Add(new RoofItem("Foam Panel", 276f, 48f));
                testItems.Add(new RoofItem("I-Beam", 276f, 0.5f));
                testItems.Add(new RoofItem("Foam Panel", 276f, 44.5f));

                //for gable
                List<RoofItem> testItems2 = new List<RoofItem>();
                testItems2.Add(new RoofItem("Foam Panel", 276f, 44.5f));
                testItems2.Add(new RoofItem("I-Beam", 276f, 0.5f));
                testItems2.Add(new RoofItem("Foam Panel", 276f, 48f));
                testItems2.Add(new RoofItem("I-Beam", 276f, 0.5f));
                testItems2.Add(new RoofItem("Foam Panel", 276f, 48f));
                testItems2.Add(new RoofItem("I-Beam", 276f, 0.5f));
                testItems2.Add(new RoofItem("Foam Panel", 276f, 48f));

                List<RoofModule> testModules = new List<RoofModule>();
                testModules.Add(new RoofModule(276, 190, "osb", "osb", testItems));
                testModules.Add(new RoofModule(276, 190, "osb", "osb", testItems2));

                //Roof testRoof = new Roof("Studio", "osb", "osb", 3, false, false, false, false, "White", "White", 0, 120, 120, testModules);
                Roof testRoof = new Roof("Dealer Gable", "osb", "osb", 3, false, false, false, false, "White", "White", 0, 120, 120, testModules);
                Session.Add("completedRoof", testRoof);

                Roof aRoof = (Roof)Session["completedRoof"];
                List<RoofModule> moduleList = aRoof.RoofModules;

                //Array of panel sizes which will be passed to javascript
                List<float> panelSizeArray = new List<float>();
                int panelsProcessed = 0;
                int numberOfPanels = 0;
                //Loop for each roof module
                for (int i=0;i<aRoof.RoofModules.Count;i++)
                {
                    //At i's roof module, loop for all roof items to find number of panels
                    for (int j = 0; j < aRoof.RoofModules[i].RoofItems.Count(); j++)
                    {
                        if (aRoof.RoofModules[i].RoofItems[j].ItemType.Contains("Panel"))
                        {
                            numberOfPanels++;
                            panelSizeArray.Add(aRoof.RoofModules[i].RoofItems[j].Width);
                        }
                    }
                    for (int j=0;j<numberOfPanels;j++)
                    {
                        panelsProcessed++;
                        //Add all the controls a panel will need
                        RadioButton aRadioButton = new RadioButton();
                        aRadioButton.ID = "radPanel" + (panelsProcessed);
                        aRadioButton.GroupName = "question1";
                        aRadioButton.Attributes.Add("OnClick", "skylightWizardCheckQuestion1()");

                        Label radioLabel = new Label();
                        radioLabel.ID = "lblPanel" + (panelsProcessed) + "Radio";
                        radioLabel.AssociatedControlID = "radPanel" + (panelsProcessed);

                        Label textLabel = new Label();
                        textLabel.ID = "lblPanel" + (panelsProcessed);
                        textLabel.AssociatedControlID = "radPanel" + (panelsProcessed);
                        textLabel.Text = "Panel " + (panelsProcessed);

                        panelOptionPlaceholder.Controls.Add(new LiteralControl("<li>"));
                        panelOptionPlaceholder.Controls.Add(aRadioButton);
                        panelOptionPlaceholder.Controls.Add(radioLabel);
                        panelOptionPlaceholder.Controls.Add(textLabel);

                        panelOptionPlaceholder.Controls.Add(new LiteralControl("<div class=\"toggleContent\">"));
                        panelOptionPlaceholder.Controls.Add(new LiteralControl("<ul>"));

                        //Add controls for each panel here, inside LI /LI tags
                        panelOptionPlaceholder.Controls.Add(new LiteralControl("<li>"));

                        CheckBox chkFanBeam = new CheckBox();
                        chkFanBeam.ID = "chkFanBeam" + panelsProcessed;
                        chkFanBeam.Attributes.Add("OnClick", "skylightWizardCheckQuestion1()");
                        panelOptionPlaceholder.Controls.Add(chkFanBeam);

                        Label lblFanBeamCheck = new Label();
                        lblFanBeamCheck.ID = "lblFanBeamCheck" + panelsProcessed;
                        lblFanBeamCheck.AssociatedControlID = "chkFanBeam" + panelsProcessed;
                        panelOptionPlaceholder.Controls.Add(lblFanBeamCheck);

                        Label lblFanBeam = new Label();
                        lblFanBeam.ID = "lblFanBeam" + panelsProcessed;
                        lblFanBeam.Text = "Fan Beam";
                        //lblFanBeam.ToolTip = "The fan beam, as the name implies, is a beam that runs along projection of the roof panel in order to have a fan attached. It may be anywhere along the width of the panel as long as it is 12 inches away from either edge.";
                        lblFanBeam.AssociatedControlID = "chkFanBeam" + panelsProcessed;
                        panelOptionPlaceholder.Controls.Add(lblFanBeam);
                        
                        panelOptionPlaceholder.Controls.Add(new LiteralControl("<br/>"));

                        Label lblFanBeamPosition = new Label();
                        lblFanBeamPosition.ID = "lblFanBeamPosition" + panelsProcessed;
                        lblFanBeamPosition.Text = "Start Width:";
                        panelOptionPlaceholder.Controls.Add(lblFanBeamPosition);

                        TextBox txtFanBeam = new TextBox();
                        txtFanBeam.ID = "txtFanBeam" + panelsProcessed;
                        txtFanBeam.Attributes.Add("onkeyup", "skylightWizardCheckQuestion1()");
                        txtFanBeam.Attributes.Add("onkeydown", "return (event.keyCode!=13);");
                        panelOptionPlaceholder.Controls.Add(txtFanBeam);

                        Button btnFanBeamCenter = new Button();
                        btnFanBeamCenter.ID = "btnFanBeamCenter" + panelsProcessed;
                        btnFanBeamCenter.Text = "Centered";
                        btnFanBeamCenter.Attributes.Add("OnClick", "skylightWizardCenterFanBeam()");
                        btnFanBeamCenter.CausesValidation = false;
                        btnFanBeamCenter.UseSubmitBehavior = false;

                        panelOptionPlaceholder.Controls.Add(btnFanBeamCenter);

                        panelOptionPlaceholder.Controls.Add(new LiteralControl("<br/><br/>"));

                        CheckBox chkSkylight = new CheckBox();
                        chkSkylight.ID = "chkSkylight" + panelsProcessed;
                        chkSkylight.Attributes.Add("OnClick", "skylightWizardCheckQuestion1()");
                        panelOptionPlaceholder.Controls.Add(chkSkylight);

                        Label lblSkylightCheck = new Label();
                        lblSkylightCheck.ID = "lblSkylightCheck" + panelsProcessed;
                        lblSkylightCheck.AssociatedControlID = "chkSkylight" + panelsProcessed;
                        panelOptionPlaceholder.Controls.Add(lblSkylightCheck);

                        Label lblSkylight = new Label();
                        lblSkylight.ID = "lblSkylight" + panelsProcessed;
                        lblSkylight.Text = "Skylight";
                        lblSkylight.AssociatedControlID = "chkSkylight" + panelsProcessed;
                        panelOptionPlaceholder.Controls.Add(lblSkylight);

                        panelOptionPlaceholder.Controls.Add(new LiteralControl("<br/>"));

                        Label lblSkylightPosition = new Label();
                        lblSkylightPosition.ID = "lblSkylightPosition" + panelsProcessed;
                        lblSkylightPosition.Text = "Start Width:";
                        panelOptionPlaceholder.Controls.Add(lblSkylightPosition);

                        TextBox txtSkylight = new TextBox();
                        txtSkylight.ID = "txtSkylight" + panelsProcessed;
                        txtSkylight.Attributes.Add("onkeyup", "skylightWizardCheckQuestion1()");
                        txtSkylight.Attributes.Add("onkeydown", "return (event.keyCode!=13);");
                        panelOptionPlaceholder.Controls.Add(txtSkylight);

                        Button btnSkylightCenter = new Button();
                        btnSkylightCenter.ID = "btnSkylightCenter" + panelsProcessed;
                        btnSkylightCenter.Text = "Centered";
                        btnSkylightCenter.Attributes.Add("OnClick", "skylightWizardCenterSkylight()");
                        btnSkylightCenter.CausesValidation = false;
                        btnSkylightCenter.UseSubmitBehavior = false;
                        panelOptionPlaceholder.Controls.Add(btnSkylightCenter);

                        HtmlInputHidden hidHasBeam = new HtmlInputHidden();
                        hidHasBeam.ID = "hidHasBeam" + panelsProcessed;
                        hiddenInputPlaceholder.Controls.Add(hidHasBeam);
                        
                        HtmlInputHidden hidBeamStart = new HtmlInputHidden();
                        hidBeamStart.ID = "hidBeamStart" + panelsProcessed;
                        hiddenInputPlaceholder.Controls.Add(hidBeamStart);

                        HtmlInputHidden hidHasSkylight = new HtmlInputHidden();
                        hidHasSkylight.ID = "hidHasSkylight" + panelsProcessed;
                        hiddenInputPlaceholder.Controls.Add(hidHasSkylight);

                        HtmlInputHidden hidSkylightStart = new HtmlInputHidden();
                        hidSkylightStart.ID = "hidSkylightStart" + panelsProcessed;
                        hiddenInputPlaceholder.Controls.Add(hidSkylightStart);

                        panelOptionPlaceholder.Controls.Add(new LiteralControl("</li>"));

                        panelOptionPlaceholder.Controls.Add(new LiteralControl("</ul>"));
                        panelOptionPlaceholder.Controls.Add(new LiteralControl("</div>"));
                        panelOptionPlaceholder.Controls.Add(new LiteralControl("</li>"));
                    }
                    totalPanels+= numberOfPanels;
                    numberOfPanels = 0;
                }

                panelSizes= new JavaScriptSerializer().Serialize(Constants.MODEL_100_FRAMING_COLOURS);
            }
        }

        protected void btnQuestion1_Click(object sender, EventArgs e)
        {
            //add db entry for each skylight
            //add db entry for each fanbeam
        }
    }
}
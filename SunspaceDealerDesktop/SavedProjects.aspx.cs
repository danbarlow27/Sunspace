using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Diagnostics; // For debug.write
using SunspaceDealerDesktop;
using System.Text.RegularExpressions;
using System.Web.Services;
using System.Text;
//using System.Runtime.Serialization.Json;

namespace SunspaceWizard
{
    public partial class SavedProjects : System.Web.UI.Page
    {
        // Instantiates in the Page_Load
        private Table tblSavedProjects;
        public string ClickEvents = "";


        //private int[] projectIdsArray;
        //private string[] projectTypeArray;

        // Moved to handle full project classes for future expansions (it's easier this way)
        private static Project[] projectArray;// = new Project();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedIn"] == null)
            {
                //uncomment me when login functionality is working
                Response.Redirect("Login.aspx");                
            }

            //Create table
            tblSavedProjects = new Table();
            tblSavedProjects.ID = "tblSavedProjects";
            tblSavedProjects.CssClass = "tblSavedProjects sortable";

            //Query DB to find row information
            //sdsProjectList.SelectCommand = "SELECT project_name, revised_date, project_id, project_type FROM projects WHERE user_id = '" + Session["user_id"] + "'";
            sdsProjectList.SelectCommand = "SELECT project_id, project_name, project_type, revised_date FROM projects WHERE user_id = '" + Session["user_id"] + "'";
            DataView dvProjectList = (DataView)sdsProjectList.Select(System.Web.UI.DataSourceSelectArguments.Empty);

            TableHeaderRow aTableRow = new TableHeaderRow();
            aTableRow.TableSection = TableRowSection.TableHeader;

            TableHeaderCell aTableCell = new TableHeaderCell();
            aTableCell.CssClass = "thSortable";
            aTableCell.Controls.Add(new LiteralControl("Project Name"));
            aTableRow.Controls.Add(aTableCell);

            TableHeaderCell aTableCell2 = new TableHeaderCell();
            aTableCell2.CssClass = "thSortable";
            aTableCell2.Controls.Add(new LiteralControl("Last Modified"));
            aTableRow.Controls.Add(aTableCell2);

            TableHeaderCell aTableCellA = new TableHeaderCell();
            aTableCellA.CssClass = "thSortable";
            aTableCellA.Controls.Add(new LiteralControl("&nbsp"));
            aTableRow.Controls.Add(aTableCellA);

            TableHeaderCell aTableCell3 = new TableHeaderCell();
            aTableCell3.CssClass = "sorttable_nosort";
            aTableCell3.Controls.Add(new LiteralControl("Add to Estimate"));
            aTableRow.Controls.Add(aTableCell3);

            tblSavedProjects.Controls.Add(aTableRow);

            // Initialize array
            projectArray = new Project[dvProjectList.Count];

            for (int i = 0; i < dvProjectList.Count; i++)
            {
                projectArray[i] = new Project();

                // Fill in project class
                projectArray[i].ProjectId   = (int)dvProjectList[i][0];
                projectArray[i].ProjectName = (string)dvProjectList[i][1];
                projectArray[i].ProjectType = (string)dvProjectList[i][2];
                projectArray[i].RevisedDate = (DateTime)dvProjectList[i][3];


                TableRow projectsTableRow = new TableRow();

                TableCell projectsNameCell = new TableCell();
                Button projectName = new Button();
                projectName.Text = projectArray[i].ProjectName;
                projectName.ID = "lblProjectName" + i;
                projectName.OnClientClick = "return false;";
                //projectName.Attributes["onclientclick"] = "return false;";
                //projectName.Click += btnProject_Click; // Add the event handler onto the button

                // Adds a jquery event handler onto the asp page.
                ClickEvents += "$(\"#MainContent_lblProjectName" + i + "\").click(function() { ProjectName_Click(\"" + projectArray[i].ProjectId.ToString() + "\",\"" + projectArray[i].ProjectType.ToString() + "\"); });\n\t\t";
                
                // Hidden label for ID
                Label projectID = new Label();
                projectID.ID = "lblProjectID" + i;
                projectID.Text = projectArray[i].ProjectId.ToString();
                projectID.Visible = false;
                //

                // Hidden type for ID
                Label projectType = new Label();
                projectType.ID = "lblProjectType" + i;
                projectType.Text = projectArray[i].ProjectType.ToString();
                projectType.Visible = false;
                //

                projectsNameCell.Controls.Add(projectName);
                projectsNameCell.Controls.Add(projectID);
                projectsNameCell.Controls.Add(projectType);
                projectsTableRow.Controls.Add(projectsNameCell);

                TableCell projectsDateCell = new TableCell();
                Label projectDate = new Label();
                projectDate.ID = "lblProjectDate" + i;
                projectDate.Text = projectArray[i].RevisedDate.ToString();
                projectsDateCell.Controls.Add(projectDate);
                projectsTableRow.Controls.Add(projectsDateCell);

                TableCell projectsDeleteCell = new TableCell();
                HyperLink lnkDelete = new HyperLink();
                lnkDelete.ID = "lnkDelete" + i;
                lnkDelete.CssClass = "btnDelete";
                lnkDelete.Text = "Delete";
                projectsDeleteCell.Controls.Add(lnkDelete);
                projectsTableRow.Controls.Add(projectsDeleteCell);

                TableCell projectsEstimateCell = new TableCell();
                CheckBox projectsEstimateCheck = new CheckBox();
                projectsEstimateCheck.ID = "chkAddToEstimate" + i;
                projectsEstimateCell.Controls.Add(projectsEstimateCheck);

                Label projectEstimate = new Label();
                projectEstimate.AssociatedControlID = "chkAddToEstimate" + i;
                //projectEstimate.Text = dvProjectList[i][0].ToString();
                projectsEstimateCell.Controls.Add(projectEstimate);
                projectsTableRow.Controls.Add(projectsEstimateCell);

                tblSavedProjects.Controls.Add(projectsTableRow);
                //phProjectList.Controls.Add(new LiteralControl("<br/>"));

                // Store project id (we'll go through it later on add to estimate click)
                //projectIdsArray[i] = (int)dvProjectList[i][2];

                // Store project type (We need this for the overlay on project name button click)
                //projectTypeArray[i] = dvProjectList[i][3].ToString();
            }

            //Finally add table to project placeholder
            phProjectList.Controls.Add(tblSavedProjects);

        //    <asp:Table ID="tblSavedProjects" class="tblSavedProjects sortable" runat="server">
        //    <asp:TableHeaderRow TableSection="TableHeader">
        //        <asp:TableHeaderCell CssClass="thSortable">Project Name</asp:TableHeaderCell>
        //        <asp:TableHeaderCell CssClass="thSortable">Last Modified</asp:TableHeaderCell>
        //        <asp:TableHeaderCell CssClass="sorttable_nosort">&nbsp;</asp:TableHeaderCell>
        //        <asp:TableHeaderCell CssClass="sorttable_nosort">Add to Estimate</asp:TableHeaderCell>
        //    </asp:TableHeaderRow>

        //    <asp:TableRow>
        //        <asp:TableCell>
        //            <asp:Label ID="lblProjectName1" runat="server" Text="Project Name"></asp:Label>
        //        </asp:TableCell>
        //        <asp:TableCell sorttable_customkey="20130503">
        //            <asp:Label ID="Label1" runat="server" Text="May 3, 2013"></asp:Label>
        //        </asp:TableCell>
        //        <asp:TableCell>
        //            <asp:HyperLink ID="lnkDelete" CssClass="btnDelete" runat="server">Delete</asp:HyperLink>
        //        </asp:TableCell>
        //        <asp:TableCell>
        //            <asp:CheckBox ID="chkAddToEstimate1" runat="server" />
        //            <asp:Label ID="lblAddToCartCheckbox" AssociatedControlID="chkAddToEstimate1" runat="server"></asp:Label>
        //        </asp:TableCell>
        //    </asp:TableRow>

        //    <asp:TableRow>
        //        <asp:TableCell>
        //            <asp:Label ID="Label2" runat="server" Text="Project Name 2"></asp:Label>
        //        </asp:TableCell>
        //        <asp:TableCell sorttable_customkey="20130531">
        //            <asp:Label ID="Label3" runat="server" Text="May 31, 2013"></asp:Label>
        //        </asp:TableCell>
        //        <asp:TableCell>
        //            <asp:HyperLink ID="HyperLink1" CssClass="btnDelete" runat="server">Delete</asp:HyperLink>
        //        </asp:TableCell>
        //        <asp:TableCell>
        //            <asp:CheckBox ID="chkAddToEstimate2" runat="server" />
        //            <asp:Label ID="Label4" AssociatedControlID="chkAddToEstimate2" runat="server"></asp:Label>
        //        </asp:TableCell>
        //    </asp:TableRow>

        //</asp:Table>
        }

        protected void btnAddToEstimate_Click(object sender, EventArgs e)
        {
            // 
            CheckBox chkAddToEstimate;
            // We'll throw active projectids in here.
            List<int> projectIdsToSave = new List<int>();

            // Grab active checkboxes
            for (int i = 0; i < projectArray.Count(); i++)
            {
                // Grab the current rows checkbox
                chkAddToEstimate = (CheckBox)tblSavedProjects.Rows[i].FindControl("chkAddToEstimate" + i); // slightly less evil than how it was before

#if DEBUG
                // Casting won't let me get text, so variables for debug writeline
                Button projectName = (Button)tblSavedProjects.Rows[i].FindControl("lblProjectName" + i);
                Label projectDate = (Label)tblSavedProjects.Rows[i].FindControl("lblProjectDate" + i);

                // debugdebugdebug project details
                Debug.WriteLine("[" + projectDate.Text + "] Project: " + projectName.Text);
#endif

                // Check if it's..checked
                if (chkAddToEstimate.Checked)
                    projectIdsToSave.Add(projectArray[i].ProjectId);   // Add to the list

            }

            // Check if they've selected anything
            if (projectIdsToSave.Count() > 0)
            {

                // Pretend to add the project ids into a estimates table. 
                Session.Add("projectIdsToSave", projectIdsToSave.ToArray());

                Response.Redirect("FinalizeEstimates.aspx");
            }
            else // Hey! They didn't select anything, that's no good. Show them an error. 
                lblError.Text = "You must select at least one project to create an estimate.";

            
        }

        // Is called on every project button click. 
        protected void btnProjectEditor_Click(object sender, EventArgs e)
        {
           
            HttpContext.Current.Response.Redirect("ProjectEditor.aspx");
#if false
            Button projectButton = (Button)sender;
            //Label hiddenProjectIDLabel;
            string labelID;
            int projectPosition;
            //string projectID;


            #region Find Project Position #
            // Super hacky! But can't find a better way to get the project_id from a button!
            labelID = (string)projectButton.ID;

            // Regular Expressions to return only digits
            labelID = Regex.Match(labelID, @"\d+").Value;

            projectPosition = int.Parse(labelID);
            /*
            hiddenProjectIDLabel = (Label)tblSavedProjects.FindControl("lblProjectID" + labelID);

            projectID = hiddenProjectIDLabel.Text;
            
#if DEBUG
            Debug.WriteLine("ProjectID is " + projectID);
#endif
            */
            #endregion

            switch (projectArray[projectPosition].ProjectType)
            {
                case ("Sunroom"):
                    break;
                default:
                    break;
            }
#endif
            
        }


        /// <summary>
        /// Example method! Yay.
        /// </summary>
        /// <param name="someParameter"></param>
        /// <returns></returns>
        [WebMethod]
        public static string GetDate(string someParameter)
        {
            return DateTime.Now.ToString();
        }

#if DEBUG
        [WebMethod]
        public static string DebugGetSession()
        {
            return HttpContext.Current.Session["project_id"].ToString();
        }
#endif


        /// <summary>
        /// Generates a Travel (Redirect) popup
        /// Will give various options on where the user will go when they select on a project.
        /// </summary>
        /// <param name="projectID">Project's ID</param>
        /// <param name="projectType">Project's Type</param>
        /// <returns></returns>
        [WebMethod]
        public static string GenerateTravelPopup(string projectID, string projectType)
        {
            // StringBuilder we'll be writing HTML to!
            StringBuilder aStringBuilder = new StringBuilder();
            // We'll render the Panels/Buttons/etc to this, which directs it to the StringBuilder above.
            HtmlTextWriter aHTMLTextWriter = new HtmlTextWriter(new System.IO.StringWriter(aStringBuilder));

            Panel aDialogPopup = new Panel();
            Panel aDialogContent = new Panel();


            // TEST TIME
            aDialogPopup.ID = "projectTransitBackground";
            aDialogPopup.CssClass = "projectTransitOverlay";
            aDialogPopup.Attributes["style"] = "display: none;";

            aDialogContent.CssClass = "content";
            aDialogPopup.Controls.Add(aDialogContent);

            // 
            Label aPopupDescription = new Label();


            aPopupDescription.Text = "Please select the following options:";


            // Close box
            Panel aCloseBar = new Panel();

            aCloseBar.CssClass = "closeBar";

            aDialogContent.Controls.Add(aCloseBar);

            Panel aCloseButton = new Panel();

            aCloseButton.CssClass = "overlayClose close";

            Label aCloseLabel = new Label();

            aCloseLabel.Text = "CLOSE";

            aCloseButton.Controls.Add(aCloseLabel);

            aCloseBar.Controls.Add(aCloseButton);

            // Create session for project editor
            HttpContext.Current.Session["project_id"] = projectID;

            Label aDirectionLabel = new Label();
            aDirectionLabel.Attributes["style"] = "margin-left: 25%";

            aDirectionLabel.Text = "\tPlease select one of the options: <br/><br/>";

            aDialogContent.Controls.Add(aDirectionLabel);

            Panel aProjectEditorButton = new Panel();
            Label aProjectEditorLabel = new Label();
            aProjectEditorLabel.Text = "Project Editor";
            aProjectEditorButton.ID = "btnProjectEditor";
            aProjectEditorButton.CssClass = "button";
            aProjectEditorButton.Attributes["style"] = "float:left;";
            aProjectEditorButton.Attributes["onClick"] = "window.location.replace(\"ProjectEditor.aspx\"); return false;";
            aProjectEditorButton.Controls.Add(aProjectEditorLabel);
            aDialogContent.Controls.Add(aProjectEditorButton);

            Panel aPriceCalculatorButton = new Panel();
            Label aPriceCalculatorLabel = new Label();
            aPriceCalculatorLabel.Text = "Price Calculator";
            aPriceCalculatorButton.ID = "btnPriceCalculator";
            aPriceCalculatorButton.CssClass = "button";
            aPriceCalculatorButton.Attributes["style"] = "float:right;";
            aPriceCalculatorButton.Attributes["onClick"] = "window.location.replace(\"PriceCalculator.aspx\"); return false;";
            aPriceCalculatorButton.Controls.Add(aPriceCalculatorLabel);
            aDialogContent.Controls.Add(aPriceCalculatorButton);

            Label LineBreaaaaak = new Label();
            LineBreaaaaak.Text = "<p>&nbsp;</p><br/><br/>";

            aDialogContent.Controls.Add(LineBreaaaaak);

            Panel aDuplicateButton = new Panel();
            Label aDuplicateLabel = new Label();
            aDuplicateLabel.Text = "Duplicate Project";
            aDuplicateButton.ID = "btnDuplicateProjectInitial";
            aDuplicateButton.CssClass = "button";
            aDuplicateButton.Attributes["style"] = "float:right;";

            aDuplicateButton.Attributes["onClick"] = "$(document).trigger( \"DuplicateProject_Click\", [ \"" + projectID + "\", \"" + projectType + "\" ] ); return false;";
            aDuplicateButton.Controls.Add(aDuplicateLabel);
            aDialogContent.Controls.Add(aDuplicateButton);
            

            // Render to HTMLTextWriter (so we can return StringBuilder..)
            aDialogPopup.RenderControl(aHTMLTextWriter);

#if DEBUG // Only compile this code if you're compiling for debug.
            Debug.WriteLine(aStringBuilder.ToString());

            Debug.WriteLine(projectType);
#endif
            return aStringBuilder.ToString();
        }


        /// <summary>
        /// Generate's HTML for a Duplicate Project Popup
        /// </summary>
        /// <param name="projectID">Project's ID</param>
        /// <param name="projectType">Project's Type</param>
        /// <returns></returns>
        [WebMethod]
        public static string GenerateDuplicatePopup(string projectID, string projectType)
        {
            // StringBuilder we'll be writing HTML to!
            StringBuilder aStringBuilder = new StringBuilder();
            // We'll render the Panels/Buttons/etc to this, which directs it to the StringBuilder above.
            HtmlTextWriter aHTMLTextWriter = new HtmlTextWriter(new System.IO.StringWriter(aStringBuilder));

            Panel aDialogPopup = new Panel();
            Panel aDialogContent = new Panel();

            


            aDialogPopup.ID = "projectTransitBackground";
            aDialogPopup.CssClass = "projectTransitOverlay";
            aDialogPopup.Attributes["style"] = "display: none;";

            aDialogContent.CssClass = "content";
            aDialogPopup.Controls.Add(aDialogContent);

            // 
            Label aPopupDescription = new Label();



            aPopupDescription.Text = "Please select dupe dis:";

            // Close box
            Panel aCloseBar = new Panel();

            aCloseBar.CssClass = "closeBar";

            aDialogContent.Controls.Add(aCloseBar);

            Panel aCloseButton = new Panel();

            aCloseButton.CssClass = "overlayClose close";

            Label aCloseLabel = new Label();

            aCloseLabel.Text = "CLOSE";

            aCloseButton.Controls.Add(aCloseLabel);

            aCloseBar.Controls.Add(aCloseButton);

            // Create session for project editor
            HttpContext.Current.Session["project_id"] = projectID;

            Label aDirectionLabel = new Label();
            aDirectionLabel.Attributes["style"] = "margin-left: 25%";

            aDirectionLabel.Text = "\tPlease rename your new project: <br/><br/>";

            aDialogContent.Controls.Add(aDirectionLabel);

            TextBox aProjectNameBox = new TextBox();
            aProjectNameBox.Attributes["placeholder"] = "Enter a project name";
            aProjectNameBox.CssClass = "txtField";

            aDialogContent.Controls.Add(aProjectNameBox);


            Panel aDuplicateButton = new Panel();
            Label aDuplicateLabel = new Label();
            aDuplicateLabel.Text = "Duplicate Project";
            aDuplicateButton.ID = "btnDuplicateProject";
            aDuplicateButton.CssClass = "button";
            aDuplicateButton.Attributes["style"] = "float:right;";
            aDuplicateButton.Attributes["onClick"] = "ActuallyDuplicateProject_Click(" + projectID + " ); return false;";
            aDuplicateButton.Controls.Add(aDuplicateLabel);
            aDialogContent.Controls.Add(aDuplicateButton);

            // Render to HTMLTextWriter (so we can return StringBuilder..)
            aDialogPopup.RenderControl(aHTMLTextWriter);

#if DEBUG // Only compile this code if you're compiling for debug.
            Debug.WriteLine(aStringBuilder.ToString());

            Debug.WriteLine(projectType);
#endif
            return aStringBuilder.ToString();
        }


        [WebMethod]
        public static bool DuplicateProject(string projectID, string projectNewName)
        {

            SqlDataSource dataSource = new SqlDataSource();
            // Super bad? Copy pasta from web.config
            dataSource.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\sunspace_db.mdf;Integrated Security=True;Connect Timeout=30";
            Project aProject = new Project();
            System.Data.DataView selectProject = new System.Data.DataView();
            string sqlSelect;
            string sqlInsert;
            List<string> tableNames = new List<string>();
            int newProjectID;   // New project ID for all the compenents of a project
            int tableCount;     // Number of tables

            // Select the project
            sqlSelect = "SELECT 	project_type," + 
		                            "installation_type," + 
		                            "customer_id," +
		                            "user_id," + 
		                            "date_created," +
		                            "status," +
		                            "revised_date," +
		                            "revised_user_id," +
		                            "msrp," +
		                            "project_notes," +
		                            "hidden," +
		                            "cut_pitch" +
                        " FROM Projects" +
                        " WHERE project_ID = " + projectID + ";";

            dataSource.SelectCommand = sqlSelect;
            selectProject = (System.Data.DataView)dataSource.Select(System.Web.UI.DataSourceSelectArguments.Empty);

            Debug.WriteLine(selectProject[0].Row[0]);

            // Insert the new project with the duplicated data!
            sqlInsert = "INSERT INTO Projects(project_type, " +
                     "installation_type, " +
                     "customer_id, " +
                     "user_id, " +
                     "date_created, " +
                     "status, " +
                     "revised_date, " +
                     "revised_user_id, " +
                     "msrp, " +
                     "project_notes, " +
                     "hidden, " +
                     "cut_pitch, " +
                     "project_name " +
            ") VALUES ( '" + selectProject[0].Row[0] + "'," +
                     "'" + selectProject[0].Row[1] + "'," +
                     "'" + selectProject[0].Row[2] + "'," +
                     "'" + selectProject[0].Row[3] + "'," +
                     "'" + selectProject[0].Row[4] + "'," +
                     "'" + selectProject[0].Row[5] + "'," +
                     "'" + selectProject[0].Row[6] + "'," +
                     "'" + selectProject[0].Row[7] + "'," +
                     "'" + selectProject[0].Row[8] + "'," +
                     "'" + selectProject[0].Row[9] + "'," +
                     "'" + selectProject[0].Row[10] + "'," +
                     "'" + selectProject[0].Row[11] + "'," +
                     "'" + projectNewName + "' ); "; //+
            //" WHERE project_ID = '" + projectID + "';";

            dataSource.InsertCommand = sqlInsert;
            dataSource.Insert();

            // Grab project id from the last insert!
            sqlSelect = "SELECT project_ID from Projects WHERE project_ID = IDENT_CURRENT('Projects');";


            dataSource.SelectCommand = sqlSelect;
            selectProject = (System.Data.DataView)dataSource.Select(System.Web.UI.DataSourceSelectArguments.Empty);

            // Set new project id
            newProjectID = (int)selectProject[0].Row[0];

            Debug.WriteLine(selectProject[0].Row[0]);

            // Get table count
            sqlSelect = "Select Count(*) From INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME LIKE 'project_id' AND TABLE_NAME <> 'projects'";

            dataSource.SelectCommand = sqlSelect;
            selectProject = (System.Data.DataView)dataSource.Select(System.Web.UI.DataSourceSelectArguments.Empty);

            // Set table count
            tableCount = (int)selectProject[0].Row[0];

            Debug.WriteLine(selectProject[0].Row[0]);

            // Essentially this gets a compenent table info and re-inserts it with the new project ID
            for (int index = 0; index < tableCount; index++)
            {
                // Get table names
                sqlSelect = "SELECT TABLE_NAME From INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME LIKE 'project_id' AND TABLE_NAME <> 'projects' ORDER BY TABLE_NAME ASC OFFSET "+ index +" ROWS FETCH NEXT 1 ROWS ONLY";
                dataSource.SelectCommand = sqlSelect;
                selectProject = (System.Data.DataView)dataSource.Select(System.Web.UI.DataSourceSelectArguments.Empty);

                tableNames.Add((string)selectProject[0].Row[0]);
                Debug.WriteLine("Table Name: " + selectProject[0].Row[0]);
                Debug.WriteLine("Table Count:" + tableNames.Count());

                // Select rows with the old project id
                sqlSelect = "SELECT * FROM " + selectProject[0].Row[0] + " WHERE project_ID = " + projectID;
                dataSource.SelectCommand = sqlSelect;
                selectProject = (System.Data.DataView)dataSource.Select(System.Web.UI.DataSourceSelectArguments.Empty);

                //
                // If we actually need this table..
                //
                if (selectProject.Count > 0)
                {
                    
                    Debug.WriteLine(selectProject[0].Row[0]);

                    // Start the insert statement
                    sqlInsert = "INSERT INTO " + tableNames[index] + " VALUES (";
                    
                    
                    
                    //
                    // TABLE ROW
                    //
                    // Inserts the values
                    for (int index2 = 0; index2 < selectProject[0].Row.ItemArray.Count(); index2++)
                    {
                        Debug.WriteLine(selectProject[0].Row[index2]);
                        if (index2 == 0)
                            sqlInsert += "'" + newProjectID + "', ";
                        else if (index2 != (selectProject[0].Row.ItemArray.Count() - 1))
                            sqlInsert += "'" + selectProject[0].Row[index2] + "', ";
                        else
                            sqlInsert += "'" + selectProject[0].Row[index2] + "'";
                        
                    }
                    // Close the insert
                    sqlInsert += ");";
                    Debug.WriteLine(sqlInsert);


                    // Actually insert the data
                    dataSource.InsertCommand = sqlInsert;
                    dataSource.Insert();

                }

            }

            return true;
        }
    }
}
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
namespace SunspaceWizard
{
    public partial class SavedProjects : System.Web.UI.Page
    {
        // Instantiates in the Page_Load
        private Table tblSavedProjects;


        //private int[] projectIdsArray;
        //private string[] projectTypeArray;

        // Moved to handle full project classes for future expansions (it's easier this way)
        private Project[] projectArray;// = new Project();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedIn"] == null)
            {
                //uncomment me when login functionality is working
                Response.Redirect("Login.aspx");                
            }

            //Create table
            tblSavedProjects = new Table();
            //tblSavedProjects.ID = "tblSavedProjects";
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

                projectName.Click += btnProject_Click; // Add the event handler onto the button

                // Hidden label for ID
                Label projectID = new Label();
                projectID.ID = "lblProjectID" + i;
                projectID.Text = projectArray[i].ProjectId.ToString();
                projectID.Visible = false;
                //

                projectsNameCell.Controls.Add(projectName);
                projectsNameCell.Controls.Add(projectID);
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
        protected void btnProject_Click(object sender, EventArgs e)
        {
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
        }
    }
}
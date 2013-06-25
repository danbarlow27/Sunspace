using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class Project
    {
        private int projectId;
        private string projectType;
        private string installType;
        private string projectName;
        private int customerId;
        private int userId;
        private DateTime dateCreated;
        private string status;
        private DateTime revisedDate;
        private int revisedUserId;
        private float msrp;
        private string projectNotes;

        public Project()
        {
            ProjectId = 0;
            ProjectType = "";
            InstallType = "";
            ProjectName = "";
            CustomerId = 0;
            UserId = 0;
            DateCreated = new DateTime();
            Status = "";
            RevisedDate = new DateTime();
            RevisedUserId = 0;
            Msrp = 0.0f;
            ProjectNotes = "";
        }

        public int ProjectId
        {
            get
            {
                return projectId;
            }
            set
            {
                projectId = value;
            }
        }

        public string ProjectType
        {
            get
            {
                return projectType;
            }
            set
            {
                projectType = value;
            }
        }

        public string InstallType
        {
            get
            {
                return installType;
            }
            set
            {
                installType = value;
            }
        }

        public string ProjectName
        {
            get
            {
                return projectName;
            }
            set
            {
                projectName = value;
            }
        }

        public int CustomerId
        {
            get
            {
                return customerId;
            }
            set
            {
                customerId = value;
            }
        }

        public int UserId
        {
            get
            {
                return userId;
            }
            set
            {
                userId = value;
            }
        }

        public DateTime DateCreated
        {
            get
            {
                return dateCreated;
            }
            set
            {
                dateCreated = value;
            }
        }

        public string Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }

        public DateTime RevisedDate
        {
            get
            {
                return revisedDate;
            }
            set
            {
                revisedDate = value;
            }
        }

        public int RevisedUserId
        {
            get
            {
                return revisedUserId;
            }
            set
            {
                revisedUserId = value;
            }
        }

        public float Msrp
        {
            get
            {
                return msrp;
            }
            set
            {
                msrp = value;
            }
        }

        public string ProjectNotes
        {
            get
            {
                return projectNotes;
            }
            set
            {
                projectNotes = value;
            }
        }
    }
}
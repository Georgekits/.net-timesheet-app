using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheet.Models
{
    public class Project
    {
        public long projectId { get; set; }
        public string projectName { get; set; }
        public ICollection<ProjectDepartment> projectDepartment { get; set; }

        public ICollection<Department> ownerDepartments { get; set; }

        public ICollection<Timesheet> relatedTimesheets { get; set; }

    }
}

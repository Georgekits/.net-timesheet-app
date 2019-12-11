using System.Collections.Generic;

namespace TimeSheet.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Department OwnerDept { get; set; }
        public ICollection<TimesheetEntry> RelatedTimesheet { get; set; }
        public ICollection<DepartmentProject> Departments { get; set; }
    }
}
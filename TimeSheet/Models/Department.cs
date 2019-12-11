using System.Collections.Generic;

namespace TimeSheet.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DepartmentHeadId { get; set; }
        public MyUser DepartmentHead { get; set; }
        public ICollection<MyUser> RelatedUsers { get; set; }
        public ICollection<DepartmentProject> Projects { get; set; }
    }
}
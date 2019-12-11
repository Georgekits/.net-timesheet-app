namespace TimeSheet.Models
{
    public class DepartmentProject
    {
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public Project Project { get; set; }
        public int ProjectId { get; set; }

    }
}
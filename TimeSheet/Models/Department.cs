using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheet.Models
{
    public class Department
    {
        public long departmentId { get; set; }
        public string departmentName { get; set; }
        //TODO change it to type user
        public string departmentUser { get; set; }

        public ICollection<ProjectDepartment> projectDepartment { get; set; }
        public Project project { get; set; }
    }
}

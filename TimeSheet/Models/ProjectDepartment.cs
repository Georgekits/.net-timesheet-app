using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheet.Models
{
    public class ProjectDepartment
    {
        public long projectId { get; set; }
        public Project project { get; set; }
        public long departmentId { get; set; }

        public Department department { get; set; }

    }
}

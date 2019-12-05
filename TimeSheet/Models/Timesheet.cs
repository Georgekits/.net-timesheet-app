using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheet.Models
{
    public class Timesheet
    {
        public long timesheetId { get; set; }
        public DateTime timesheetDate { get; set; }
        //TODO change it to type user
        public string relatedUser { get; set; }
        public Project relatedProject { get; set; }
        public int hoursWork { get; set; }
        
    }
}

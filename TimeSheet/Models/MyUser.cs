using Microsoft.AspNetCore.Identity;

namespace TimeSheet.Models
{
    public class MyUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Department Department { get; set; }
        public double CostPerHour { get; set; }
        public MyUser Manager { get; set; }
    }
}
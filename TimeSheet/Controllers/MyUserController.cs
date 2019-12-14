using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TimeSheet.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MyUserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
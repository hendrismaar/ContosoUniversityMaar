using Microsoft.AspNetCore.Mvc;

namespace ContosoUniversityMaar.Controllers
{
    public class InstructorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}

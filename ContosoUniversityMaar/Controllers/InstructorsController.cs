using ContosoUniversityMaar.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversityMaar.Controllers
{
    public class InstructorsController : Controller
    {
        private readonly SchoolContext _context;
        
        public InstructorsController(SchoolContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Instructors.ToListAsync());
        }
    }
}

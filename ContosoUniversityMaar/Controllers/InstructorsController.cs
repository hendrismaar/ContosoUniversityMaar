using ContosoUniversityMaar.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContosoUniversityMaar.Models;
using Microsoft.AspNetCore.Authorization;

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

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) { return NotFound(); }
            var instructor = await _context.Instructors
            .FirstOrDefaultAsync(i => i.ID == id);
            if (instructor == null) { return NotFound(); }
            return View(instructor);
        }

        public IActionResult Create() { return View(); }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(instructor);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(instructor);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) { return NotFound(); };

            var instructor = await _context.Instructors.FindAsync(id);
            if (instructor == null) { return NotFound(); }
            return View(instructor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Instructor instructor)
        {
            if (id != instructor.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instructor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstructorExists(instructor.ID))
                    {
                        return NotFound();
                    }
                    else { throw; }
                }
                return RedirectToAction("Index");
            }
            return View(instructor);
        }

        public async Task <IActionResult> Delete(int? id)
        {
            if (id == null) { return NotFound(); }

            var instructor = await _context.Instructors
                .FirstOrDefaultAsync(i => i.ID == id);
            if (instructor == null) { return NotFound(); }
            return View(instructor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Instructors == null)
            {
                return Problem("Entity set 'SchoolContext.Instructors' is null.");
            }
            var instructor = await _context.Instructors.FindAsync(id);
            if (instructor != null) { _context.Instructors.Remove(instructor); }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool InstructorExists(int id)
        {
            return _context.Instructors.Any(x => x.ID == id);
        }
    }
}

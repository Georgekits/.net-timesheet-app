using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TimeSheet.Data;
using TimeSheet.Models;

namespace TimeSheet.Controllers
{
    public class TimesheetEntriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TimesheetEntriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Timesheets
                .Include(x=>x.RelatedProject)
                .ToListAsync());
        }

        // GET: TimesheetEntries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timesheetEntry = await _context.Timesheets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timesheetEntry == null)
            {
                return NotFound();
            }

            return View(timesheetEntry);
        }
        public IList<SelectListItem> ProjectList = new List<SelectListItem>();
        // GET: TimesheetEntries/Create
        public IActionResult Create()
        {
            foreach (Project r in _context.Projects)
            {
                ProjectList.Add(new SelectListItem() { Value = r.Id.ToString(), Text = r.Name });
            }
            ViewBag.Project = ProjectList;
            return View();
        }

        // POST: TimesheetEntries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateCreated,HoursWorked,RelatedProjectId")] TimesheetEntry timesheetEntry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(timesheetEntry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(timesheetEntry);
        }

        // GET: TimesheetEntries/Edit/5
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timesheetEntry = await _context.Timesheets.FindAsync(id);
            if (timesheetEntry == null)
            {
                return NotFound();
            }
            return View(timesheetEntry);
        }

        // POST: TimesheetEntries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateCreated,HoursWorked")] TimesheetEntry timesheetEntry)
        {
            if (id != timesheetEntry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timesheetEntry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimesheetEntryExists(timesheetEntry.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(timesheetEntry);
        }

        // GET: TimesheetEntries/Delete/5
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timesheetEntry = await _context.Timesheets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timesheetEntry == null)
            {
                return NotFound();
            }

            return View(timesheetEntry);
        }

        // POST: TimesheetEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var timesheetEntry = await _context.Timesheets.FindAsync(id);
            _context.Timesheets.Remove(timesheetEntry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimesheetEntryExists(int id)
        {
            return _context.Timesheets.Any(e => e.Id == id);
        }
    }
}

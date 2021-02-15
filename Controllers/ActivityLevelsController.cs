using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DogKennel_Project.Data;
using DogKennel_Project.Models;

namespace DogKennel_Project.Controllers
{
    public class ActivityLevelsController : Controller
    {
        private readonly DogKennel_ProjectContext _context;

        public ActivityLevelsController(DogKennel_ProjectContext context)
        {
            _context = context;
        }

        // GET: ActivityLevels
        public async Task<IActionResult> Index()
        {
            return View(await _context.ActivityLevel.ToListAsync());
        }

        // GET: ActivityLevels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityLevel = await _context.ActivityLevel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (activityLevel == null)
            {
                return NotFound();
            }

            return View(activityLevel);
        }

        // GET: ActivityLevels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ActivityLevels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Activity_Level,Barking_Level")] ActivityLevel activityLevel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(activityLevel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(activityLevel);
        }

        // GET: ActivityLevels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityLevel = await _context.ActivityLevel.FindAsync(id);
            if (activityLevel == null)
            {
                return NotFound();
            }
            return View(activityLevel);
        }

        // POST: ActivityLevels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Activity_Level,Barking_Level")] ActivityLevel activityLevel)
        {
            if (id != activityLevel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activityLevel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActivityLevelExists(activityLevel.Id))
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
            return View(activityLevel);
        }

        // GET: ActivityLevels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityLevel = await _context.ActivityLevel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (activityLevel == null)
            {
                return NotFound();
            }

            return View(activityLevel);
        }

        // POST: ActivityLevels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activityLevel = await _context.ActivityLevel.FindAsync(id);
            _context.ActivityLevel.Remove(activityLevel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActivityLevelExists(int id)
        {
            return _context.ActivityLevel.Any(e => e.Id == id);
        }
    }
}

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
    public class DogGroupsController : Controller
    {
        private readonly DogKennel_ProjectContext _context;

        public DogGroupsController(DogKennel_ProjectContext context)
        {
            _context = context;
        }

        // GET: DogGroups
        public async Task<IActionResult> Index()
        {
            return View(await _context.DogGroup.ToListAsync());
        }

        // GET: DogGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dogGroup = await _context.DogGroup
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dogGroup == null)
            {
                return NotFound();
            }

            return View(dogGroup);
        }

        // GET: DogGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DogGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Group_Name,Coat_Type")] DogGroup dogGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dogGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dogGroup);
        }

        // GET: DogGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dogGroup = await _context.DogGroup.FindAsync(id);
            if (dogGroup == null)
            {
                return NotFound();
            }
            return View(dogGroup);
        }

        // POST: DogGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Group_Name,Coat_Type")] DogGroup dogGroup)
        {
            if (id != dogGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dogGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DogGroupExists(dogGroup.Id))
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
            return View(dogGroup);
        }

        // GET: DogGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dogGroup = await _context.DogGroup
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dogGroup == null)
            {
                return NotFound();
            }

            return View(dogGroup);
        }

        // POST: DogGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dogGroup = await _context.DogGroup.FindAsync(id);
            _context.DogGroup.Remove(dogGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DogGroupExists(int id)
        {
            return _context.DogGroup.Any(e => e.Id == id);
        }
    }
}

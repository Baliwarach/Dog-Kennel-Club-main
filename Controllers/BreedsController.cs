﻿using System;
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
    public class BreedsController : Controller
    {
        private readonly DogKennel_ProjectContext _context;

        public BreedsController(DogKennel_ProjectContext context)
        {
            _context = context;
        }

        // GET: Breeds
        public async Task<IActionResult> Index()
        {
            var dogKennel_ProjectContext = _context.Breed.Include(b => b.ActivityLevel).Include(b => b.DogGroup).Include(b => b.Size);
            return View(await dogKennel_ProjectContext.ToListAsync());
        }

        // GET: Breeds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var breed = await _context.Breed
                .Include(b => b.ActivityLevel)
                .Include(b => b.DogGroup)
                .Include(b => b.Size)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (breed == null)
            {
                return NotFound();
            }

            return View(breed);
        }

        // GET: Breeds/Create
        public IActionResult Create()
        {
            ViewData["ActivityLevelId"] = new SelectList(_context.ActivityLevel, "Id", "Activity_Level");
            ViewData["DogGroupId"] = new SelectList(_context.DogGroup, "Id", "Group_Name");
            ViewData["SizeId"] = new SelectList(_context.Size, "Id", "Size_Name");
            return View();
        }

        // POST: Breeds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Breed_Name,Age_Years,DogGroupId,ActivityLevelId,SizeId")] Breed breed)
        {
            if (ModelState.IsValid)
            {
                _context.Add(breed);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActivityLevelId"] = new SelectList(_context.ActivityLevel, "Id", "Activity_Level", breed.ActivityLevelId);
            ViewData["DogGroupId"] = new SelectList(_context.DogGroup, "Id", "Group_Name", breed.DogGroupId);
            ViewData["SizeId"] = new SelectList(_context.Size, "Id", "Size_Name", breed.SizeId);
            return View(breed);
        }

        // GET: Breeds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var breed = await _context.Breed.FindAsync(id);
            if (breed == null)
            {
                return NotFound();
            }
            ViewData["ActivityLevelId"] = new SelectList(_context.ActivityLevel, "Id", "Activity_Level", breed.ActivityLevelId);
            ViewData["DogGroupId"] = new SelectList(_context.DogGroup, "Id", "Group_Name", breed.DogGroupId);
            ViewData["SizeId"] = new SelectList(_context.Size, "Id", "Size_Name", breed.SizeId);
            return View(breed);
        }

        // POST: Breeds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Breed_Name,Age_Years,DogGroupId,ActivityLevelId,SizeId")] Breed breed)
        {
            if (id != breed.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(breed);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BreedExists(breed.Id))
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
            ViewData["ActivityLevelId"] = new SelectList(_context.ActivityLevel, "Id", "Activity_Level", breed.ActivityLevelId);
            ViewData["DogGroupId"] = new SelectList(_context.DogGroup, "Id", "Group_Name", breed.DogGroupId);
            ViewData["SizeId"] = new SelectList(_context.Size, "Id", "Size_Name", breed.SizeId);
            return View(breed);
        }

        // GET: Breeds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var breed = await _context.Breed
                .Include(b => b.ActivityLevel)
                .Include(b => b.DogGroup)
                .Include(b => b.Size)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (breed == null)
            {
                return NotFound();
            }

            return View(breed);
        }

        // POST: Breeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var breed = await _context.Breed.FindAsync(id);
            _context.Breed.Remove(breed);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BreedExists(int id)
        {
            return _context.Breed.Any(e => e.Id == id);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Musicians.Data;
using Musicians.Models;

namespace Musicians.Controllers
{
    public class MusiciansController : Controller
    {
        private readonly MusicContext _context;

        public MusiciansController(MusicContext context)
        {
            _context = context;
        }

        // GET: Musicians
        public async Task<IActionResult> Index()
        {
            return View(await _context.Musicians.ToListAsync());
        }

        // GET: Musicians/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musician = await _context.Musicians
                .SingleOrDefaultAsync(m => m.MusicianID == id);
            if (musician == null)
            {
                return NotFound();
            }

            return View(musician);
        }

        // GET: Musicians/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Musicians/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MusicianID,Ssn,Name")] Musician musician)
        {
            if (ModelState.IsValid)
            {
                _context.Add(musician);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(musician);
        }

        // GET: Musicians/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musician = await _context.Musicians.SingleOrDefaultAsync(m => m.MusicianID == id);
            if (musician == null)
            {
                return NotFound();
            }
            return View(musician);
        }

        // POST: Musicians/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MusicianID,Ssn,Name")] Musician musician)
        {
            if (id != musician.MusicianID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(musician);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MusicianExists(musician.MusicianID))
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
            return View(musician);
        }

        // GET: Musicians/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musician = await _context.Musicians
                .SingleOrDefaultAsync(m => m.MusicianID == id);
            if (musician == null)
            {
                return NotFound();
            }

            return View(musician);
        }

        // POST: Musicians/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var musician = await _context.Musicians.SingleOrDefaultAsync(m => m.MusicianID == id);
            _context.Musicians.Remove(musician);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MusicianExists(int id)
        {
            return _context.Musicians.Any(e => e.MusicianID == id);
        }
    }
}

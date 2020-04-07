using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Session4Projet.Models;

namespace Session4Projet.Controllers
{
    public class TeteesController : Controller
    {
        private readonly Session4ProjetContext _context;

        public TeteesController(Session4ProjetContext context)
        {
            _context = context;
        }

        // GET: Tetees
        public async Task<IActionResult> Index(string teteeType, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Tetee
                                            orderby m.Type
                                            select m.Type;

            var tetees = from m in _context.Tetee
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                tetees = tetees.Where(s => s.Title.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(teteeType))
            {
                tetees = tetees.Where(x => x.Type == teteeType);
            }

            var teteeGenreVM = new TeteeTypeViewModel
            {
                Types = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Tetees = await tetees.ToListAsync()
            };

            return View(teteeGenreVM);
        }

        // GET: Tetees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tetee = await _context.Tetee
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tetee == null)
            {
                return NotFound();
            }

            return View(tetee);
        }

        // GET: Tetees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tetees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Heure,Type,Technique,Commentaire")] Tetee tetee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tetee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tetee);
        }

        // GET: Tetees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tetee = await _context.Tetee.SingleOrDefaultAsync(m => m.Id == id);
            if (tetee == null)
            {
                return NotFound();
            }
            return View(tetee);
        }

        // POST: Tetees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Heure,Type,Technique,Commentaire")] Tetee tetee)
        {
            if (id != tetee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tetee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeteeExists(tetee.Id))
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
            return View(tetee);
        }

        // GET: Tetees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tetee = await _context.Tetee
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tetee == null)
            {
                return NotFound();
            }

            return View(tetee);
        }

        // POST: Tetees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tetee = await _context.Tetee.SingleOrDefaultAsync(m => m.Id == id);
            _context.Tetee.Remove(tetee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeteeExists(int id)
        {
            return _context.Tetee.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TorneioEF.Models;

namespace TorneioEF.Controllers
{
    public class PartidaequipesController : Controller
    {
        private readonly TorneioContext _context;

        public PartidaequipesController(TorneioContext context)
        {
            _context = context;
        }

        // GET: Partidaequipes
        public async Task<IActionResult> Index()
        {
            var torneioContext = _context
                .Partidaequipes
                .Include(p => p.Equipe)
                .Include(p => p.Partida)
                .OrderByDescending(p => p.PartidaId);
            return View(await torneioContext.ToListAsync());
        }

        // GET: Partidaequipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partidaequipe = await _context.Partidaequipes
                .Include(p => p.Equipe)
                .Include(p => p.Partida)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partidaequipe == null)
            {
                return NotFound();
            }

            return View(partidaequipe);
        }

        // GET: Partidaequipes/Create
        public IActionResult Create()
        {
            ViewData["EquipeId"] = new SelectList(_context.Equipes, "Id", "Id");
            ViewData["PartidaId"] = new SelectList(_context.Partida, "Id", "Id");
            return View();
        }

        // POST: Partidaequipes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PartidaId,EquipeId,Pontos,Vencedor")] Partidaequipe partidaequipe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(partidaequipe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EquipeId"] = new SelectList(_context.Equipes, "Id", "Id", partidaequipe.EquipeId);
            ViewData["PartidaId"] = new SelectList(_context.Partida, "Id", "Id", partidaequipe.PartidaId);
            return View(partidaequipe);
        }

        // GET: Partidaequipes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partidaequipe = await _context.Partidaequipes.FindAsync(id);
            if (partidaequipe == null)
            {
                return NotFound();
            }
            ViewData["EquipeId"] = new SelectList(_context.Equipes, "Id", "Id", partidaequipe.EquipeId);
            ViewData["PartidaId"] = new SelectList(_context.Partida, "Id", "Id", partidaequipe.PartidaId);
            return View(partidaequipe);
        }

        // POST: Partidaequipes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PartidaId,EquipeId,Pontos,Vencedor")] Partidaequipe partidaequipe)
        {
            if (id != partidaequipe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(partidaequipe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartidaequipeExists(partidaequipe.Id))
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
            ViewData["EquipeId"] = new SelectList(_context.Equipes, "Id", "Id", partidaequipe.EquipeId);
            ViewData["PartidaId"] = new SelectList(_context.Partida, "Id", "Id", partidaequipe.PartidaId);
            return View(partidaequipe);
        }

        // GET: Partidaequipes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partidaequipe = await _context.Partidaequipes
                .Include(p => p.Equipe)
                .Include(p => p.Partida)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partidaequipe == null)
            {
                return NotFound();
            }

            return View(partidaequipe);
        }

        // POST: Partidaequipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var partidaequipe = await _context.Partidaequipes.FindAsync(id);
            if (partidaequipe != null)
            {
                _context.Partidaequipes.Remove(partidaequipe);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartidaequipeExists(int id)
        {
            return _context.Partidaequipes.Any(e => e.Id == id);
        }
    }
}

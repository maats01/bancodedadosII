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
    public class EquipeAtletasController : Controller
    {
        private readonly TorneioContext _context;

        public EquipeAtletasController(TorneioContext context)
        {
            _context = context;
        }

        // GET: EquipeAtletas
        public async Task<IActionResult> Index()
        {
            var torneioContext = _context.Equipeatleta.Include(e => e.Atleta).Include(e => e.Equipe);
            return View(await torneioContext.ToListAsync());
        }

        // GET: EquipeAtletas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipeAtleta = await _context.Equipeatleta
                .Include(e => e.Atleta)
                .Include(e => e.Equipe)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipeAtleta == null)
            {
                return NotFound();
            }

            return View(equipeAtleta);
        }

        // GET: EquipeAtletas/Create
        public IActionResult Create()
        {
            ViewData["AtletaId"] = new SelectList(_context.Atleta, "Id", "Id");
            ViewData["EquipeId"] = new SelectList(_context.Equipes, "Id", "Id");
            return View();
        }

        // POST: EquipeAtletas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AtletaId,EquipeId")] EquipeAtleta equipeAtleta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipeAtleta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AtletaId"] = new SelectList(_context.Atleta, "Id", "Id", equipeAtleta.AtletaId);
            ViewData["EquipeId"] = new SelectList(_context.Equipes, "Id", "Id", equipeAtleta.EquipeId);
            return View(equipeAtleta);
        }

        // GET: EquipeAtletas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipeAtleta = await _context.Equipeatleta.FindAsync(id);
            if (equipeAtleta == null)
            {
                return NotFound();
            }
            ViewData["AtletaId"] = new SelectList(_context.Atleta, "Id", "Id", equipeAtleta.AtletaId);
            ViewData["EquipeId"] = new SelectList(_context.Equipes, "Id", "Id", equipeAtleta.EquipeId);
            return View(equipeAtleta);
        }

        // POST: EquipeAtletas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AtletaId,EquipeId")] EquipeAtleta equipeAtleta)
        {
            if (id != equipeAtleta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipeAtleta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipeAtletaExists(equipeAtleta.Id))
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
            ViewData["AtletaId"] = new SelectList(_context.Atleta, "Id", "Id", equipeAtleta.AtletaId);
            ViewData["EquipeId"] = new SelectList(_context.Equipes, "Id", "Id", equipeAtleta.EquipeId);
            return View(equipeAtleta);
        }

        // GET: EquipeAtletas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipeAtleta = await _context.Equipeatleta
                .Include(e => e.Atleta)
                .Include(e => e.Equipe)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipeAtleta == null)
            {
                return NotFound();
            }

            return View(equipeAtleta);
        }

        // POST: EquipeAtletas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equipeAtleta = await _context.Equipeatleta.FindAsync(id);
            if (equipeAtleta != null)
            {
                _context.Equipeatleta.Remove(equipeAtleta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipeAtletaExists(int id)
        {
            return _context.Equipeatleta.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFTransporteAereo.Models;

namespace EFTransporteAereo.Controllers
{
    public class PilotoesController : Controller
    {
        private readonly TransporteAereoContext _context;

        public PilotoesController(TransporteAereoContext context)
        {
            _context = context;
        }

        // GET: Pilotoes
        public async Task<IActionResult> Index()
        {
            var transporteAereoContext = _context.Pilotos.Include(p => p.IdPessoaNavigation);
            return View(await transporteAereoContext.ToListAsync());
        }

        // GET: Pilotoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var piloto = await _context.Pilotos
                .Include(p => p.IdPessoaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (piloto == null)
            {
                return NotFound();
            }

            return View(piloto);
        }

        // GET: Pilotoes/Create
        public IActionResult Create()
        {
            ViewData["IdPessoa"] = new SelectList(_context.Pessoas, "Id", "Id");
            return View();
        }

        // POST: Pilotoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdPessoa")] Piloto piloto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(piloto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPessoa"] = new SelectList(_context.Pessoas, "Id", "Id", piloto.IdPessoa);
            return View(piloto);
        }

        // GET: Pilotoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var piloto = await _context.Pilotos.FindAsync(id);
            if (piloto == null)
            {
                return NotFound();
            }
            ViewData["IdPessoa"] = new SelectList(_context.Pessoas, "Id", "Id", piloto.IdPessoa);
            return View(piloto);
        }

        // POST: Pilotoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdPessoa")] Piloto piloto)
        {
            if (id != piloto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(piloto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PilotoExists(piloto.Id))
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
            ViewData["IdPessoa"] = new SelectList(_context.Pessoas, "Id", "Id", piloto.IdPessoa);
            return View(piloto);
        }

        // GET: Pilotoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var piloto = await _context.Pilotos
                .Include(p => p.IdPessoaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (piloto == null)
            {
                return NotFound();
            }

            return View(piloto);
        }

        // POST: Pilotoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var piloto = await _context.Pilotos.FindAsync(id);
            if (piloto != null)
            {
                _context.Pilotos.Remove(piloto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PilotoExists(int id)
        {
            return _context.Pilotos.Any(e => e.Id == id);
        }
    }
}

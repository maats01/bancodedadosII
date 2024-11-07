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
    public class VoosEscalasController : Controller
    {
        private readonly TransporteAereoContext _context;

        public VoosEscalasController(TransporteAereoContext context)
        {
            _context = context;
        }

        // GET: VoosEscalas
        public async Task<IActionResult> Index()
        {
            var transporteAereoContext = _context.VoosEscalas.Include(v => v.IdEscalaNavigation).Include(v => v.IdVooNavigation);
            return View(await transporteAereoContext.ToListAsync());
        }

        // GET: VoosEscalas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voosEscala = await _context.VoosEscalas
                .Include(v => v.IdEscalaNavigation)
                .Include(v => v.IdVooNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (voosEscala == null)
            {
                return NotFound();
            }

            return View(voosEscala);
        }

        // GET: VoosEscalas/Create
        public IActionResult Create()
        {
            ViewData["IdEscala"] = new SelectList(_context.Escalas, "Id", "Id");
            ViewData["IdVoo"] = new SelectList(_context.Voos, "Id", "Id");
            return View();
        }

        // POST: VoosEscalas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdVoo,IdEscala,HorarioChegada,HorarioSaida")] VoosEscala voosEscala)
        {
            if (ModelState.IsValid)
            {
                _context.Add(voosEscala);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEscala"] = new SelectList(_context.Escalas, "Id", "Id", voosEscala.IdEscala);
            ViewData["IdVoo"] = new SelectList(_context.Voos, "Id", "Id", voosEscala.IdVoo);
            return View(voosEscala);
        }

        // GET: VoosEscalas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voosEscala = await _context.VoosEscalas.FindAsync(id);
            if (voosEscala == null)
            {
                return NotFound();
            }
            ViewData["IdEscala"] = new SelectList(_context.Escalas, "Id", "Id", voosEscala.IdEscala);
            ViewData["IdVoo"] = new SelectList(_context.Voos, "Id", "Id", voosEscala.IdVoo);
            return View(voosEscala);
        }

        // POST: VoosEscalas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdVoo,IdEscala,HorarioChegada,HorarioSaida")] VoosEscala voosEscala)
        {
            if (id != voosEscala.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(voosEscala);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VoosEscalaExists(voosEscala.Id))
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
            ViewData["IdEscala"] = new SelectList(_context.Escalas, "Id", "Id", voosEscala.IdEscala);
            ViewData["IdVoo"] = new SelectList(_context.Voos, "Id", "Id", voosEscala.IdVoo);
            return View(voosEscala);
        }

        // GET: VoosEscalas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voosEscala = await _context.VoosEscalas
                .Include(v => v.IdEscalaNavigation)
                .Include(v => v.IdVooNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (voosEscala == null)
            {
                return NotFound();
            }

            return View(voosEscala);
        }

        // POST: VoosEscalas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var voosEscala = await _context.VoosEscalas.FindAsync(id);
            if (voosEscala != null)
            {
                _context.VoosEscalas.Remove(voosEscala);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VoosEscalaExists(int id)
        {
            return _context.VoosEscalas.Any(e => e.Id == id);
        }
    }
}

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
    public class AssentosPassageirosVoosController : Controller
    {
        private readonly TransporteAereoContext _context;

        public AssentosPassageirosVoosController(TransporteAereoContext context)
        {
            _context = context;
        }

        // GET: AssentosPassageirosVoos
        public async Task<IActionResult> Index()
        {
            var transporteAereoContext = _context.AssentosPassageirosVoos.Include(a => a.IdAssentoNavigation).Include(a => a.IdPassageiroNavigation).Include(a => a.IdVooNavigation);
            return View(await transporteAereoContext.ToListAsync());
        }

        // GET: AssentosPassageirosVoos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assentosPassageirosVoo = await _context.AssentosPassageirosVoos
                .Include(a => a.IdAssentoNavigation)
                .Include(a => a.IdPassageiroNavigation)
                .Include(a => a.IdVooNavigation)
                .FirstOrDefaultAsync(m => m.IdVoo == id);
            if (assentosPassageirosVoo == null)
            {
                return NotFound();
            }

            return View(assentosPassageirosVoo);
        }

        // GET: AssentosPassageirosVoos/Create
        public IActionResult Create()
        {
            ViewData["IdAssento"] = new SelectList(_context.Assentos, "Id", "Id");
            ViewData["IdPassageiro"] = new SelectList(_context.Passageiros, "Id", "Id");
            ViewData["IdVoo"] = new SelectList(_context.Voos, "Id", "Id");
            return View();
        }

        // POST: AssentosPassageirosVoos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVoo,IdAssento,IdPassageiro")] AssentosPassageirosVoo assentosPassageirosVoo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assentosPassageirosVoo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAssento"] = new SelectList(_context.Assentos, "Id", "Id", assentosPassageirosVoo.IdAssento);
            ViewData["IdPassageiro"] = new SelectList(_context.Passageiros, "Id", "Id", assentosPassageirosVoo.IdPassageiro);
            ViewData["IdVoo"] = new SelectList(_context.Voos, "Id", "Id", assentosPassageirosVoo.IdVoo);
            return View(assentosPassageirosVoo);
        }

        // GET: AssentosPassageirosVoos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assentosPassageirosVoo = await _context.AssentosPassageirosVoos.FindAsync(id);
            if (assentosPassageirosVoo == null)
            {
                return NotFound();
            }
            ViewData["IdAssento"] = new SelectList(_context.Assentos, "Id", "Id", assentosPassageirosVoo.IdAssento);
            ViewData["IdPassageiro"] = new SelectList(_context.Passageiros, "Id", "Id", assentosPassageirosVoo.IdPassageiro);
            ViewData["IdVoo"] = new SelectList(_context.Voos, "Id", "Id", assentosPassageirosVoo.IdVoo);
            return View(assentosPassageirosVoo);
        }

        // POST: AssentosPassageirosVoos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVoo,IdAssento,IdPassageiro")] AssentosPassageirosVoo assentosPassageirosVoo)
        {
            if (id != assentosPassageirosVoo.IdVoo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assentosPassageirosVoo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssentosPassageirosVooExists(assentosPassageirosVoo.IdVoo))
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
            ViewData["IdAssento"] = new SelectList(_context.Assentos, "Id", "Id", assentosPassageirosVoo.IdAssento);
            ViewData["IdPassageiro"] = new SelectList(_context.Passageiros, "Id", "Id", assentosPassageirosVoo.IdPassageiro);
            ViewData["IdVoo"] = new SelectList(_context.Voos, "Id", "Id", assentosPassageirosVoo.IdVoo);
            return View(assentosPassageirosVoo);
        }

        // GET: AssentosPassageirosVoos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assentosPassageirosVoo = await _context.AssentosPassageirosVoos
                .Include(a => a.IdAssentoNavigation)
                .Include(a => a.IdPassageiroNavigation)
                .Include(a => a.IdVooNavigation)
                .FirstOrDefaultAsync(m => m.IdVoo == id);
            if (assentosPassageirosVoo == null)
            {
                return NotFound();
            }

            return View(assentosPassageirosVoo);
        }

        // POST: AssentosPassageirosVoos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assentosPassageirosVoo = await _context.AssentosPassageirosVoos.FindAsync(id);
            if (assentosPassageirosVoo != null)
            {
                _context.AssentosPassageirosVoos.Remove(assentosPassageirosVoo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssentosPassageirosVooExists(int id)
        {
            return _context.AssentosPassageirosVoos.Any(e => e.IdVoo == id);
        }
    }
}

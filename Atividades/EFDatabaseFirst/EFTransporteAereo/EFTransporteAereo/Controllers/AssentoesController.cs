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
    public class AssentoesController : Controller
    {
        private readonly TransporteAereoContext _context;

        public AssentoesController(TransporteAereoContext context)
        {
            _context = context;
        }

        // GET: Assentoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Assentos.ToListAsync());
        }

        // GET: Assentoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assento = await _context.Assentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assento == null)
            {
                return NotFound();
            }

            return View(assento);
        }

        // GET: Assentoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Assentoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Lado,Posicao,Linha")] Assento assento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(assento);
        }

        // GET: Assentoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assento = await _context.Assentos.FindAsync(id);
            if (assento == null)
            {
                return NotFound();
            }
            return View(assento);
        }

        // POST: Assentoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Lado,Posicao,Linha")] Assento assento)
        {
            if (id != assento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssentoExists(assento.Id))
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
            return View(assento);
        }

        // GET: Assentoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assento = await _context.Assentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assento == null)
            {
                return NotFound();
            }

            return View(assento);
        }

        // POST: Assentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assento = await _context.Assentos.FindAsync(id);
            if (assento != null)
            {
                _context.Assentos.Remove(assento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssentoExists(int id)
        {
            return _context.Assentos.Any(e => e.Id == id);
        }
    }
}

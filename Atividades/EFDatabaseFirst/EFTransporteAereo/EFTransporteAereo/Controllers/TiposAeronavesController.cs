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
    public class TiposAeronavesController : Controller
    {
        private readonly TransporteAereoContext _context;

        public TiposAeronavesController(TransporteAereoContext context)
        {
            _context = context;
        }

        // GET: TiposAeronaves
        public async Task<IActionResult> Index()
        {
            return View(await _context.TiposAeronaves.ToListAsync());
        }

        // GET: TiposAeronaves/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposAeronave = await _context.TiposAeronaves
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tiposAeronave == null)
            {
                return NotFound();
            }

            return View(tiposAeronave);
        }

        // GET: TiposAeronaves/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TiposAeronaves/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tipo,DescTipo")] TiposAeronave tiposAeronave)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiposAeronave);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tiposAeronave);
        }

        // GET: TiposAeronaves/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposAeronave = await _context.TiposAeronaves.FindAsync(id);
            if (tiposAeronave == null)
            {
                return NotFound();
            }
            return View(tiposAeronave);
        }

        // POST: TiposAeronaves/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tipo,DescTipo")] TiposAeronave tiposAeronave)
        {
            if (id != tiposAeronave.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiposAeronave);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiposAeronaveExists(tiposAeronave.Id))
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
            return View(tiposAeronave);
        }

        // GET: TiposAeronaves/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposAeronave = await _context.TiposAeronaves
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tiposAeronave == null)
            {
                return NotFound();
            }

            return View(tiposAeronave);
        }

        // POST: TiposAeronaves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tiposAeronave = await _context.TiposAeronaves.FindAsync(id);
            if (tiposAeronave != null)
            {
                _context.TiposAeronaves.Remove(tiposAeronave);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiposAeronaveExists(int id)
        {
            return _context.TiposAeronaves.Any(e => e.Id == id);
        }
    }
}

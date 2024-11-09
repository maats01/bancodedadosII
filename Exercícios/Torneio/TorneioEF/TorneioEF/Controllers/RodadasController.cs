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
    public class RodadasController : Controller
    {
        private readonly TorneioContext _context;

        public RodadasController(TorneioContext context)
        {
            _context = context;
        }

        // GET: Rodadas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rodada.ToListAsync());
        }

        // GET: Rodadas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rodada = await _context.Rodada
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rodada == null)
            {
                return NotFound();
            }

            return View(rodada);
        }

        // GET: Rodadas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rodadas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao,QtdEquipes,EquipesClassificadas")] Rodada rodada)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rodada);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rodada);
        }

        // GET: Rodadas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rodada = await _context.Rodada.FindAsync(id);
            if (rodada == null)
            {
                return NotFound();
            }
            return View(rodada);
        }

        // POST: Rodadas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao,QtdEquipes,EquipesClassificadas")] Rodada rodada)
        {
            if (id != rodada.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rodada);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RodadaExists(rodada.Id))
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
            return View(rodada);
        }

        // GET: Rodadas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rodada = await _context.Rodada
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rodada == null)
            {
                return NotFound();
            }

            return View(rodada);
        }

        // POST: Rodadas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rodada = await _context.Rodada.FindAsync(id);
            if (rodada != null)
            {
                _context.Rodada.Remove(rodada);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RodadaExists(int id)
        {
            return _context.Rodada.Any(e => e.Id == id);
        }
    }
}

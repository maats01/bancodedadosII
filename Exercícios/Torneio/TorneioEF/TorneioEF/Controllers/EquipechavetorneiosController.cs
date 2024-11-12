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
    public class EquipechavetorneiosController : Controller
    {
        private readonly TorneioContext _context;

        public EquipechavetorneiosController(TorneioContext context)
        {
            _context = context;
        }

        // GET: Equipechavetorneios
        public async Task<IActionResult> Index()
        {
            var torneioContext = _context
                .Equipechavetorneios
                .Include(e => e.Chave)
                .Include(e => e.Equipe)
                .Include(e => e.Torneio)
                .OrderBy(e => e.ChaveId)
                .ThenByDescending(e => e.Pontos);
            return View(await torneioContext.ToListAsync());
        }

        // GET: Equipechavetorneios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipechavetorneio = await _context.Equipechavetorneios
                .Include(e => e.Chave)
                .Include(e => e.Equipe)
                .Include(e => e.Torneio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipechavetorneio == null)
            {
                return NotFound();
            }

            return View(equipechavetorneio);
        }

        // GET: Equipechavetorneios/Create
        public IActionResult Create()
        {
            ViewData["ChaveId"] = new SelectList(_context.Chaves, "Id", "Id");
            ViewData["EquipeId"] = new SelectList(_context.Equipes, "Id", "Id");
            ViewData["TorneioId"] = new SelectList(_context.Torneios, "Id", "Id");
            return View();
        }

        // POST: Equipechavetorneios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TorneioId,ChaveId,EquipeId,Pontos")] Equipechavetorneio equipechavetorneio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipechavetorneio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChaveId"] = new SelectList(_context.Chaves, "Id", "Id", equipechavetorneio.ChaveId);
            ViewData["EquipeId"] = new SelectList(_context.Equipes, "Id", "Id", equipechavetorneio.EquipeId);
            ViewData["TorneioId"] = new SelectList(_context.Torneios, "Id", "Id", equipechavetorneio.TorneioId);
            return View(equipechavetorneio);
        }

        // GET: Equipechavetorneios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipechavetorneio = await _context.Equipechavetorneios.FindAsync(id);
            if (equipechavetorneio == null)
            {
                return NotFound();
            }
            ViewData["ChaveId"] = new SelectList(_context.Chaves, "Id", "Id", equipechavetorneio.ChaveId);
            ViewData["EquipeId"] = new SelectList(_context.Equipes, "Id", "Id", equipechavetorneio.EquipeId);
            ViewData["TorneioId"] = new SelectList(_context.Torneios, "Id", "Id", equipechavetorneio.TorneioId);
            return View(equipechavetorneio);
        }

        // POST: Equipechavetorneios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TorneioId,ChaveId,EquipeId,Pontos")] Equipechavetorneio equipechavetorneio)
        {
            if (id != equipechavetorneio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipechavetorneio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipechavetorneioExists(equipechavetorneio.Id))
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
            ViewData["ChaveId"] = new SelectList(_context.Chaves, "Id", "Id", equipechavetorneio.ChaveId);
            ViewData["EquipeId"] = new SelectList(_context.Equipes, "Id", "Id", equipechavetorneio.EquipeId);
            ViewData["TorneioId"] = new SelectList(_context.Torneios, "Id", "Id", equipechavetorneio.TorneioId);
            return View(equipechavetorneio);
        }

        // GET: Equipechavetorneios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipechavetorneio = await _context.Equipechavetorneios
                .Include(e => e.Chave)
                .Include(e => e.Equipe)
                .Include(e => e.Torneio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipechavetorneio == null)
            {
                return NotFound();
            }

            return View(equipechavetorneio);
        }

        // POST: Equipechavetorneios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equipechavetorneio = await _context.Equipechavetorneios.FindAsync(id);
            if (equipechavetorneio != null)
            {
                _context.Equipechavetorneios.Remove(equipechavetorneio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipechavetorneioExists(int id)
        {
            return _context.Equipechavetorneios.Any(e => e.Id == id);
        }
    }
}

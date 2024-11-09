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
    public class PartidasController : Controller
    {
        private readonly TorneioContext _context;

        public PartidasController(TorneioContext context)
        {
            _context = context;
        }

        // GET: Partidas
        public async Task<IActionResult> Index()
        {
            var torneioContext = _context.Partida.Include(p => p.Chave).Include(p => p.Modalidade).Include(p => p.Rodada).Include(p => p.Torneio);
            return View(await torneioContext.ToListAsync());
        }

        // GET: Partidas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partida = await _context.Partida
                .Include(p => p.Chave)
                .Include(p => p.Modalidade)
                .Include(p => p.Rodada)
                .Include(p => p.Torneio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partida == null)
            {
                return NotFound();
            }

            return View(partida);
        }

        // GET: Partidas/Create
        public IActionResult Create()
        {
            ViewData["ChaveId"] = new SelectList(_context.Chaves, "Id", "Id");
            ViewData["ModalidadeId"] = new SelectList(_context.Modalidades, "Id", "Id");
            ViewData["RodadaId"] = new SelectList(_context.Rodada, "Id", "Id");
            ViewData["TorneioId"] = new SelectList(_context.Torneios, "Id", "Id");
            return View();
        }

        // POST: Partidas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TorneioId,ChaveId,RodadaId,ModalidadeId,Empate,DataPartida")] Partida partida)
        {
            if (ModelState.IsValid)
            {
                _context.Add(partida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChaveId"] = new SelectList(_context.Chaves, "Id", "Id", partida.ChaveId);
            ViewData["ModalidadeId"] = new SelectList(_context.Modalidades, "Id", "Id", partida.ModalidadeId);
            ViewData["RodadaId"] = new SelectList(_context.Rodada, "Id", "Id", partida.RodadaId);
            ViewData["TorneioId"] = new SelectList(_context.Torneios, "Id", "Id", partida.TorneioId);
            return View(partida);
        }

        // GET: Partidas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partida = await _context.Partida.FindAsync(id);
            if (partida == null)
            {
                return NotFound();
            }
            ViewData["ChaveId"] = new SelectList(_context.Chaves, "Id", "Id", partida.ChaveId);
            ViewData["ModalidadeId"] = new SelectList(_context.Modalidades, "Id", "Id", partida.ModalidadeId);
            ViewData["RodadaId"] = new SelectList(_context.Rodada, "Id", "Id", partida.RodadaId);
            ViewData["TorneioId"] = new SelectList(_context.Torneios, "Id", "Id", partida.TorneioId);
            return View(partida);
        }

        // POST: Partidas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TorneioId,ChaveId,RodadaId,ModalidadeId,Empate,DataPartida")] Partida partida)
        {
            if (id != partida.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(partida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartidaExists(partida.Id))
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
            ViewData["ChaveId"] = new SelectList(_context.Chaves, "Id", "Id", partida.ChaveId);
            ViewData["ModalidadeId"] = new SelectList(_context.Modalidades, "Id", "Id", partida.ModalidadeId);
            ViewData["RodadaId"] = new SelectList(_context.Rodada, "Id", "Id", partida.RodadaId);
            ViewData["TorneioId"] = new SelectList(_context.Torneios, "Id", "Id", partida.TorneioId);
            return View(partida);
        }

        // GET: Partidas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partida = await _context.Partida
                .Include(p => p.Chave)
                .Include(p => p.Modalidade)
                .Include(p => p.Rodada)
                .Include(p => p.Torneio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partida == null)
            {
                return NotFound();
            }

            return View(partida);
        }

        // POST: Partidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var partida = await _context.Partida.FindAsync(id);
            if (partida != null)
            {
                _context.Partida.Remove(partida);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartidaExists(int id)
        {
            return _context.Partida.Any(e => e.Id == id);
        }
    }
}

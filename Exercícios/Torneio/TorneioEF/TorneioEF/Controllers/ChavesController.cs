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
    public class ChavesController : Controller
    {
        private readonly TorneioContext _context;

        public ChavesController(TorneioContext context)
        {
            _context = context;
        }

        // GET: Chaves
        public async Task<IActionResult> Index()
        {
            return View(await _context.Chaves.ToListAsync());
        }

        // GET: Chaves/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chave = await _context.Chaves
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chave == null)
            {
                return NotFound();
            }

            return View(chave);
        }

        // GET: Chaves/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Chaves/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Chave1")] Chave chave)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chave);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chave);
        }

        // GET: Chaves/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chave = await _context.Chaves.FindAsync(id);
            if (chave == null)
            {
                return NotFound();
            }
            return View(chave);
        }

        // POST: Chaves/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Chave1")] Chave chave)
        {
            if (id != chave.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chave);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChaveExists(chave.Id))
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
            return View(chave);
        }

        // GET: Chaves/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chave = await _context.Chaves
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chave == null)
            {
                return NotFound();
            }

            return View(chave);
        }

        // POST: Chaves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chave = await _context.Chaves.FindAsync(id);
            if (chave != null)
            {
                _context.Chaves.Remove(chave);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChaveExists(int id)
        {
            return _context.Chaves.Any(e => e.Id == id);
        }
    }
}

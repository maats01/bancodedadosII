using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AulaEntityFramework.Models;
using AulaEntityFramework.Repositories;

namespace AulaEntityFramework.Controllers
{
    public class PessoasController : Controller
    {
        private readonly MyDbContext _context;

        private IPessoaRepository _pessoaRepository;

        public PessoasController(MyDbContext context, IPessoaRepository pessoaRepository)
        {
            _context = context;
            _pessoaRepository = pessoaRepository;
        }

        // GET: Pessoas
        public IActionResult Index()
        {
            return View(_pessoaRepository.GetAll());
        }

        // GET: Pessoas/Details/5
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = _pessoaRepository.Get(id.Value);
            if (pessoa == null)
            {
                return NotFound();
            }

            return View(pessoa);
        }

        // GET: Pessoas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pessoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,BirthDate")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                _pessoaRepository.Insert(pessoa);
                return RedirectToAction(nameof(Index));
            }
            return View(pessoa);
        }

        // GET: Pessoas/Edit/5
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = _pessoaRepository.Get(id.Value);
            if (pessoa == null)
            {
                return NotFound();
            }
            return View(pessoa);
        }

        // POST: Pessoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, [Bind("Id,Name,BirthDate")] Pessoa pessoa)
        {
            if (id != pessoa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _pessoaRepository.Update(pessoa);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PessoaExists(pessoa.Id))
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
            return View(pessoa);
        }

        // GET: Pessoas/Delete/5
        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = _pessoaRepository.Get(id.Value);
            if (pessoa == null)
            {
                return NotFound();
            }

            return View(pessoa);
        }

        // POST: Pessoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long id)
        {
            _pessoaRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool PessoaExists(long id)
        {
            var pessoa = _pessoaRepository.Get(id);

            return !(pessoa is null);
        }
    }
}

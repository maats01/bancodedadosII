using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AulaEntityFramework.Models;
using AulaEntityFramework.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace AulaEntityFramework.Controllers
{
    public class PessoasController : Controller
    {
        private IPessoaRepository _pessoaRepository;

        public PessoasController(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        [HttpGet]
        public IActionResult Index(string bdt, int? gbm)
        {
            var repo = _pessoaRepository.GetAll();

            if (!bdt.IsNullOrEmpty())
                repo = _pessoaRepository.GetByBirthDate(Convert.ToDateTime(bdt));
            else if (gbm is not null && gbm != 0)
                repo = _pessoaRepository.GetByBirthMonth(gbm.Value);

            return View(repo);
        }

        [HttpGet]
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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

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

        [HttpGet]
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

        [HttpGet]
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

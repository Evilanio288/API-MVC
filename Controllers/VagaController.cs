using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Anuncios.mvc.Data;
using Anuncios.mvc.Models;

namespace Anuncios.mvc.Controllers
{
    public class VagaController : Controller
    {
        private readonly AnunciosmvcContext _context;

        public VagaController(AnunciosmvcContext context)
        {
            _context = context;
        }

        // GET: Vaga
        public async Task<IActionResult> Index()
        {
              return View(await _context.Vagas.ToListAsync());
        }

        // GET: Vaga/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vagas == null)
            {
                return NotFound();
            }

            var vagaModel = await _context.Vagas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vagaModel == null)
            {
                return NotFound();
            }

            return View(vagaModel);
        }

        // GET: Vaga/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vaga/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Descricacao,DataInclusao,DataEncerramento,Remuneracao,Anunciante,Rua,Bairro,Cidade,Estado,Email,Telefone")] VagaModel vagaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vagaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vagaModel);
        }

        // GET: Vaga/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vagas == null)
            {
                return NotFound();
            }

            var vagaModel = await _context.Vagas.FindAsync(id);
            if (vagaModel == null)
            {
                return NotFound();
            }
            return View(vagaModel);
        }

        // POST: Vaga/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Descricacao,DataInclusao,DataEncerramento,Remuneracao,Anunciante,Rua,Bairro,Cidade,Estado,Email,Telefone")] VagaModel vagaModel)
        {
            if (id != vagaModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vagaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VagaModelExists(vagaModel.Id))
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
            return View(vagaModel);
        }

        // GET: Vaga/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vagas == null)
            {
                return NotFound();
            }

            var vagaModel = await _context.Vagas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vagaModel == null)
            {
                return NotFound();
            }

            return View(vagaModel);
        }

        // POST: Vaga/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vagas == null)
            {
                return Problem("Entity set 'AnunciosmvcContext.VagaModel'  is null.");
            }
            var vagaModel = await _context.Vagas.FindAsync(id);
            if (vagaModel != null)
            {
                _context.Vagas.Remove(vagaModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VagaModelExists(int id)
        {
          return _context.Vagas.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Anuncios.mvc.Data;
using Anuncios.mvc.Models;

namespace Anuncios.mvc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VagasController : ControllerBase
    {
        private readonly AnunciosmvcContext _context;

        public VagasController(AnunciosmvcContext context)
        {
            _context = context;
        }

        // GET: api/Vagas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VagaModel>>> GetVagas()
        {
            return await _context.Vagas.ToListAsync();
        }

        // GET: api/Vagas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VagaModel>> GetVagaModel(int id)
        {
            var vagaModel = await _context.Vagas.FindAsync(id);

            if (vagaModel == null)
            {
                return NotFound();
            }

            return vagaModel;
        }

        // PUT: api/Vagas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVagaModel(int id, VagaModel vagaModel)
        {
            if (id != vagaModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(vagaModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VagaModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Vagas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VagaModel>> PostVagaModel(VagaModel vagaModel)
        {
            _context.Vagas.Add(vagaModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVagaModel", new { id = vagaModel.Id }, vagaModel);
        }

        // DELETE: api/Vagas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVagaModel(int id)
        {
            var vagaModel = await _context.Vagas.FindAsync(id);
            if (vagaModel == null)
            {
                return NotFound();
            }

            _context.Vagas.Remove(vagaModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VagaModelExists(int id)
        {
            return _context.Vagas.Any(e => e.Id == id);
        }
    }
}

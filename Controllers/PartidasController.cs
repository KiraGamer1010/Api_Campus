using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartidasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PartidasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Partidas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Partida>>> GetPartidas()
        {
            return await _context.Partidas.ToListAsync();
        }

        // GET: api/Partidas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Partida>> GetPartida(int id)
        {
            var partida = await _context.Partidas.FindAsync(id);

            if (partida == null)
            {
                return NotFound();
            }

            return partida;
        }

        // PUT: api/Partidas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPartida(int id, Partida partida)
        {
            if (id != partida.IdPartida)
            {
                return BadRequest();
            }

            _context.Entry(partida).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartidaExists(id))
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

        // POST: api/Partidas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Partida>> PostPartida(Partida partida)
        {
            _context.Partidas.Add(partida);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPartida", new { id = partida.IdPartida }, partida);
        }

        // DELETE: api/Partidas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePartida(int id)
        {
            var partida = await _context.Partidas.FindAsync(id);
            if (partida == null)
            {
                return NotFound();
            }

            _context.Partidas.Remove(partida);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PartidaExists(int id)
        {
            return _context.Partidas.Any(e => e.IdPartida == id);
        }
    }
}

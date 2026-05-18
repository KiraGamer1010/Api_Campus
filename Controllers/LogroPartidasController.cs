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
    public class LogroPartidasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LogroPartidasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/LogroPartidas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LogroPartida>>> GetLogrosPartidas()
        {
            return await _context.LogrosPartidas.ToListAsync();
        }

        // GET: api/LogroPartidas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LogroPartida>> GetLogroPartida(int id)
        {
            var logroPartida = await _context.LogrosPartidas.FindAsync(id);

            if (logroPartida == null)
            {
                return NotFound();
            }

            return logroPartida;
        }

        // PUT: api/LogroPartidas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLogroPartida(int id, LogroPartida logroPartida)
        {
            if (id != logroPartida.IdLogroPartida)
            {
                return BadRequest();
            }

            _context.Entry(logroPartida).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogroPartidaExists(id))
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

        // POST: api/LogroPartidas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LogroPartida>> PostLogroPartida(LogroPartida logroPartida)
        {
            _context.LogrosPartidas.Add(logroPartida);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLogroPartida", new { id = logroPartida.IdLogroPartida }, logroPartida);
        }

        // DELETE: api/LogroPartidas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLogroPartida(int id)
        {
            var logroPartida = await _context.LogrosPartidas.FindAsync(id);
            if (logroPartida == null)
            {
                return NotFound();
            }

            _context.LogrosPartidas.Remove(logroPartida);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LogroPartidaExists(int id)
        {
            return _context.LogrosPartidas.Any(e => e.IdLogroPartida == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApuestasShare.Modelos;
using sysApuestas__API;

namespace sysApuestas__API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialPagosController : ControllerBase
    {
        private readonly SysApuestasContext _context;

        public HistorialPagosController(SysApuestasContext context)
        {
            _context = context;
        }

        // GET: api/HistorialPagos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistorialPagos>>> GetHistorialPagos()
        {
            return await _context.HistorialPagos.ToListAsync();
        }

        // GET: api/HistorialPagos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HistorialPagos>> GetHistorialPagos(int id)
        {
            var historialPagos = await _context.HistorialPagos.FindAsync(id);

            if (historialPagos == null)
            {
                return NotFound();
            }

            return historialPagos;
        }

        // PUT: api/HistorialPagos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistorialPagos(int id, HistorialPagos historialPagos)
        {
            if (id != historialPagos.IdPago)
            {
                return BadRequest();
            }

            _context.Entry(historialPagos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistorialPagosExists(id))
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

        // POST: api/HistorialPagos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HistorialPagos>> PostHistorialPagos(HistorialPagos historialPagos)
        {
            _context.HistorialPagos.Add(historialPagos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHistorialPagos", new { id = historialPagos.IdPago }, historialPagos);
        }

        // DELETE: api/HistorialPagos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistorialPagos(int id)
        {
            var historialPagos = await _context.HistorialPagos.FindAsync(id);
            if (historialPagos == null)
            {
                return NotFound();
            }

            _context.HistorialPagos.Remove(historialPagos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HistorialPagosExists(int id)
        {
            return _context.HistorialPagos.Any(e => e.IdPago == id);
        }
    }
}

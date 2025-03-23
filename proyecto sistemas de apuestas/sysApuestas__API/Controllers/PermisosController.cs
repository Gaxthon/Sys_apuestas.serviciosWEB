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
    public class PermisosController : ControllerBase
    {
        private readonly SysApuestasContext _context;

        public PermisosController(SysApuestasContext context)
        {
            _context = context;
        }

        // GET: api/Permisos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Permisos>>> Getpermisos()
        {
            return await _context.permisos.ToListAsync();
        }

        // GET: api/Permisos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Permisos>> GetPermisos(int id)
        {
            var permisos = await _context.permisos.FindAsync(id);

            if (permisos == null)
            {
                return NotFound();
            }

            return permisos;
        }

        // PUT: api/Permisos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPermisos(int id, Permisos permisos)
        {
            if (id != permisos.idPermiso)
            {
                return BadRequest();
            }

            _context.Entry(permisos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PermisosExists(id))
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

        // POST: api/Permisos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Permisos>> PostPermisos(Permisos permisos)
        {
            _context.permisos.Add(permisos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPermisos", new { id = permisos.idPermiso }, permisos);
        }

        // DELETE: api/Permisos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePermisos(int id)
        {
            var permisos = await _context.permisos.FindAsync(id);
            if (permisos == null)
            {
                return NotFound();
            }

            _context.permisos.Remove(permisos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PermisosExists(int id)
        {
            return _context.permisos.Any(e => e.idPermiso == id);
        }
    }
}

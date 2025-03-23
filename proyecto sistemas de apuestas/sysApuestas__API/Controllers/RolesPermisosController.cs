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
    public class RolesPermisosController : ControllerBase
    {
        private readonly SysApuestasContext _context;

        public RolesPermisosController(SysApuestasContext context)
        {
            _context = context;
        }

        // GET: api/RolesPermisos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RolesPermisos>>> GetrolesPermisos()
        {
            return await _context.rolesPermisos.ToListAsync();
        }

        // GET: api/RolesPermisos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RolesPermisos>> GetRolesPermisos(int id)
        {
            var rolesPermisos = await _context.rolesPermisos.FindAsync(id);

            if (rolesPermisos == null)
            {
                return NotFound();
            }

            return rolesPermisos;
        }

        // PUT: api/RolesPermisos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRolesPermisos(int id, RolesPermisos rolesPermisos)
        {
            if (id != rolesPermisos.IdRol)
            {
                return BadRequest();
            }

            _context.Entry(rolesPermisos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolesPermisosExists(id))
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

        // POST: api/RolesPermisos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RolesPermisos>> PostRolesPermisos(RolesPermisos rolesPermisos)
        {
            _context.rolesPermisos.Add(rolesPermisos);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RolesPermisosExists(rolesPermisos.IdRol))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRolesPermisos", new { id = rolesPermisos.IdRol }, rolesPermisos);
        }

        // DELETE: api/RolesPermisos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRolesPermisos(int id)
        {
            var rolesPermisos = await _context.rolesPermisos.FindAsync(id);
            if (rolesPermisos == null)
            {
                return NotFound();
            }

            _context.rolesPermisos.Remove(rolesPermisos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RolesPermisosExists(int id)
        {
            return _context.rolesPermisos.Any(e => e.IdRol == id);
        }
    }
}

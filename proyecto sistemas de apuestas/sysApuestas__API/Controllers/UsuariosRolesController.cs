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
    public class UsuariosRolesController : ControllerBase
    {
        private readonly SysApuestasContext _context;

        public UsuariosRolesController(SysApuestasContext context)
        {
            _context = context;
        }

        // GET: api/UsuariosRoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuariosRoles>>> GetusuariosRoles()
        {
            return await _context.usuariosRoles.ToListAsync();
        }

        // GET: api/UsuariosRoles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuariosRoles>> GetUsuariosRoles(int id)
        {
            var usuariosRoles = await _context.usuariosRoles.FindAsync(id);

            if (usuariosRoles == null)
            {
                return NotFound();
            }

            return usuariosRoles;
        }

        // PUT: api/UsuariosRoles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuariosRoles(int id, UsuariosRoles usuariosRoles)
        {
            if (id != usuariosRoles.IdRol)
            {
                return BadRequest();
            }

            _context.Entry(usuariosRoles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuariosRolesExists(id))
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

        // POST: api/UsuariosRoles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UsuariosRoles>> PostUsuariosRoles(UsuariosRoles usuariosRoles)
        {
            _context.usuariosRoles.Add(usuariosRoles);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UsuariosRolesExists(usuariosRoles.IdRol))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUsuariosRoles", new { id = usuariosRoles.IdRol }, usuariosRoles);
        }

        // DELETE: api/UsuariosRoles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuariosRoles(int id)
        {
            var usuariosRoles = await _context.usuariosRoles.FindAsync(id);
            if (usuariosRoles == null)
            {
                return NotFound();
            }

            _context.usuariosRoles.Remove(usuariosRoles);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuariosRolesExists(int id)
        {
            return _context.usuariosRoles.Any(e => e.IdRol == id);
        }
    }
}

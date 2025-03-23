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
    public class NotificacionesController : ControllerBase
    {
        private readonly SysApuestasContext _context;

        public NotificacionesController(SysApuestasContext context)
        {
            _context = context;
        }

        // GET: api/Notificaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Notificaciones>>> GetNotificaciones()
        {
            return await _context.Notificaciones.ToListAsync();
        }

        // GET: api/Notificaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Notificaciones>> GetNotificaciones(int id)
        {
            var notificaciones = await _context.Notificaciones.FindAsync(id);

            if (notificaciones == null)
            {
                return NotFound();
            }

            return notificaciones;
        }

        // PUT: api/Notificaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotificaciones(int id, Notificaciones notificaciones)
        {
            if (id != notificaciones.IdNotificacion)
            {
                return BadRequest();
            }

            _context.Entry(notificaciones).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotificacionesExists(id))
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

        // POST: api/Notificaciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Notificaciones>> PostNotificaciones(Notificaciones notificaciones)
        {
            _context.Notificaciones.Add(notificaciones);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNotificaciones", new { id = notificaciones.IdNotificacion }, notificaciones);
        }

        // DELETE: api/Notificaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotificaciones(int id)
        {
            var notificaciones = await _context.Notificaciones.FindAsync(id);
            if (notificaciones == null)
            {
                return NotFound();
            }

            _context.Notificaciones.Remove(notificaciones);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NotificacionesExists(int id)
        {
            return _context.Notificaciones.Any(e => e.IdNotificacion == id);
        }
    }
}

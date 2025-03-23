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
    public class ConfiguracionController : ControllerBase
    {
        private readonly SysApuestasContext _context;

        public ConfiguracionController(SysApuestasContext context)
        {
            _context = context;
        }

        // GET: api/Configuracion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Configuracion>>> Getconfiguraciones()
        {
            return await _context.configuraciones.ToListAsync();
        }

        // GET: api/Configuracion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Configuracion>> GetConfiguracion(int id)
        {
            var configuracion = await _context.configuraciones.FindAsync(id);

            if (configuracion == null)
            {
                return NotFound();
            }

            return configuracion;
        }

        // PUT: api/Configuracion/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConfiguracion(int id, Configuracion configuracion)
        {
            if (id != configuracion.IdConfiguracion)
            {
                return BadRequest();
            }

            _context.Entry(configuracion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfiguracionExists(id))
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

        // POST: api/Configuracion
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Configuracion>> PostConfiguracion(Configuracion configuracion)
        {
            _context.configuraciones.Add(configuracion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConfiguracion", new { id = configuracion.IdConfiguracion }, configuracion);
        }

        // DELETE: api/Configuracion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConfiguracion(int id)
        {
            var configuracion = await _context.configuraciones.FindAsync(id);
            if (configuracion == null)
            {
                return NotFound();
            }

            _context.configuraciones.Remove(configuracion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConfiguracionExists(int id)
        {
            return _context.configuraciones.Any(e => e.IdConfiguracion == id);
        }
    }
}

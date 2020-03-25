using GestampPrueba2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestampPrueba2.Infrastructure
{
    public class PersonasServices: ControllerBase, IPersonasService
    {
        private readonly masterContext _context = null;

        public PersonasServices(masterContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Personas3>>> GetAllPersonas()
        {
            return await _context.Personas3.ToListAsync();

        }
        
        public async Task<ActionResult<Personas3>> GetById(int id)
        {
            var personas3 = await _context.Personas3.FindAsync(id);

            if (personas3 == null)
            {
                return NotFound();
            }

            return Ok(personas3);


        }
        
        public async Task<ActionResult<Personas3>> PostPersonas3([FromBody] Personas3 personas3)
        {
            _context.Personas3.Add(personas3);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonas3", new { id = personas3.Id }, personas3);

        }

        public async Task<ActionResult<Personas3>> PutPersonas3(int id,[FromBody] Personas3 personas3)
        {
            if (id != personas3.Id)
            {
                return BadRequest();
            }

            _context.Entry(personas3).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Personas3Exists(id))
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


        public async Task<ActionResult<Personas3>> DeletePersona(int id)
        {
            var personas3 = await _context.Personas3.FindAsync(id);
            if (personas3 == null)
            {
                return NotFound();
            }
            _context.Personas3.Remove(personas3);
            await _context.SaveChangesAsync();
            return personas3;
        }


        private bool Personas3Exists(int id)
        {
            return _context.Personas3.Any(e => e.Id == id);
        }
    }
}

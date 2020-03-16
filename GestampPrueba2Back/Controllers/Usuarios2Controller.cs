using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestampPrueba2.Models;

namespace GestampPrueba2.Controllers
{
    [Route("/usuarios")]
    //[ApiController]
    public class Usuarios2Controller : ControllerBase
    {
        private readonly masterContext _context;

        public Usuarios2Controller(masterContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios2
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuarios2>>> GetUsuarios2()
        {
            return await _context.Usuarios2.ToListAsync();
        }

        // GET: api/Usuarios2/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuarios2>> GetUsuarios2(int id)
        {
            var usuarios2 = await _context.Usuarios2.FindAsync(id);

            if (usuarios2 == null)
            {
                return NotFound();
            }

            return usuarios2;
        }

        // PUT: api/Usuarios2/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarios2(int id, [FromBody] Usuarios2 usuarios2)
        {
            if (id != usuarios2.Id)
            {
                return BadRequest();
            }

            _context.Entry(usuarios2).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Usuarios2Exists(id))
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

        // POST: api/Usuarios2
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Usuarios2>> PostUsuarios2([FromBody] Usuarios2 usuarios2)
        {
            _context.Usuarios2.Add(usuarios2);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuarios2", new { id = usuarios2.Id }, usuarios2);
        }

        // DELETE: api/Usuarios2/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuarios2>> DeleteUsuarios2(int id)
        {
            var usuarios2 = await _context.Usuarios2.FindAsync(id);
            if (usuarios2 == null)
            {
                return NotFound();
            }

            _context.Usuarios2.Remove(usuarios2);
            await _context.SaveChangesAsync();

            return usuarios2;
        }

        private bool Usuarios2Exists(int id)
        {
            return _context.Usuarios2.Any(e => e.Id == id);
        }
    }
}

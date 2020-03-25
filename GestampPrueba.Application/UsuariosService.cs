using GestampPrueba2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestampPrueba.Application
{
    public class UsuariosService: ControllerBase, IUsuariosService
    {
        private readonly masterContext _context = null;

        public UsuariosService(masterContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Usuarios2>>> GetAllUsuarios()
        {
            return await _context.Usuarios2.ToListAsync();

        }

        public async Task<ActionResult<Usuarios2>> GetById(int id)
        {
            var usuario = await _context.Usuarios2.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);


        }

        public async Task<ActionResult<Usuarios2>> PostUsuarios2([FromBody] Usuarios2 usuarios2)
        {
            _context.Usuarios2.Add(usuarios2);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuarios2", new { id = usuarios2.Id }, usuarios2);

        }

        public async Task<ActionResult<Usuarios2>> PutUsuario2(int id, [FromBody] Usuarios2 usuarios2)
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
                if (!Usuarios2Exist(id))
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


        public async Task<ActionResult<Usuarios2>> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios2.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            _context.Usuarios2.Remove(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }


        private bool Usuarios2Exist(int id)
        {
            return _context.Usuarios2.Any(e => e.Id == id);
        }
    }
}

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
    public class UsuariosRepository: ControllerBase, IUsuariosRepository
    {
        private readonly masterContext _context = null;

        public UsuariosRepository(masterContext context)
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

        public async Task<ActionResult<Usuarios2>> PostUsuario([FromBody] Usuarios2 usuarios2)
        {
            _context.Usuarios2.Add(usuarios2);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuarios2", new { id = usuarios2.Id }, usuarios2);

        }

        public async Task<ActionResult<Usuarios2>> PutUsuario(int id, [FromBody] Usuarios2 usuarios2)
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
                if (!UsuarioExist(id))
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
            _context.Usuarios2.Remove(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        private bool UsuarioExist(int id)
        {
            return _context.Usuarios2.Any(e => e.Id == id);
        }
    }
}

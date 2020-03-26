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
    public class UsuariosRepository: GenericRepository<Usuarios2>, IUsuariosRepository, IDisposable
    {
        private readonly masterContext _context = null;

        public UsuariosRepository(masterContext context) : base(context) {}

        public void metodoChorra()
        {
            Console.WriteLine("Este es un metodo chorra para comprobar el unit of work");
        }

        public void Save()
        {
            _context.SaveChanges();
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
    }
}










/*  public async Task<ActionResult<IEnumerable<Usuarios2>>> GetAllUsuarios()
  {
      return await _context.Usuarios2.ToListAsync();

  }*/

/*  public async Task<ActionResult<Usuarios2>> GetById(int id)
  {
      return _context.Usuarios2.Find(id);
  }*/

/*public async Task<ActionResult<Usuarios2>> PostUsuario([FromBody] Usuarios2 usuarios2)
{
    _context.Usuarios2.Add(usuarios2);
    await _context.SaveChangesAsync();
    return usuarios2;
}*/

/*  public async Task<ActionResult<Usuarios2>> PutUsuario(int id, [FromBody] Usuarios2 usuarios2)
  {
      _context.Entry(usuarios2).State = EntityState.Modified;
      await _context.SaveChangesAsync();
      return usuarios2;
  }*/


/*public async Task<ActionResult<Usuarios2>> DeleteUsuario(int id)
{
    Usuarios2 usuario = await _context.Usuarios2.FindAsync(id);
    _context.Usuarios2.Remove(usuario);
    await _context.SaveChangesAsync();
    return usuario;
}*/

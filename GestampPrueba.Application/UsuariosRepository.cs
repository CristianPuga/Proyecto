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
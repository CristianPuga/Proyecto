using GestampPrueba2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestampPrueba.Application
{
    public class UnitOfWork: IDisposable
    {
        private masterContext context = new masterContext();
        private GenericRepository<Usuarios2> usuariosRepository;
        private GenericRepository<Personas3> personasRepository;

        public GenericRepository<Usuarios2> UsuariosRepository
        {
            get
            {

                if (this.usuariosRepository == null)
                {
                    this.usuariosRepository = new GenericRepository<Usuarios2>(context);
                }
                return usuariosRepository;
            }
        }

        public GenericRepository<Personas3> PersonasRepository
        {
            get
            {

                if (this.personasRepository == null)
                {
                    this.personasRepository = new GenericRepository<Personas3>(context);
                }
                return personasRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
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

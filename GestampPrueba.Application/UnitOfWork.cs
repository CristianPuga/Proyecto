using GestampPrueba2.Infrastructure;
using GestampPrueba2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestampPrueba.Application
{
    public class UnitOfWork: IDisposable
    {
        private readonly masterContext context = new masterContext();
        private UsuariosRepository usuariosRepository;
        private PersonasRepository personasRepository;

        public UsuariosRepository UsuariosRepository
        {
            get
            {

                if (this.usuariosRepository == null)
                {
                    this.usuariosRepository = new UsuariosRepository(context);
                }
                return usuariosRepository;
            }
        }

        public PersonasRepository PersonasRepository
        {
            get
            {

                if (this.personasRepository == null)
                {
                    this.personasRepository = new PersonasRepository(context);
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

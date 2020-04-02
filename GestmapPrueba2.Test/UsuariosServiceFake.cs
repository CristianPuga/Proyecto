using AutoMapper;
using GestampPrueba.Application;
using GestampPrueba.Application.DTOs;
using GestampPrueba2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestmapPrueba2.Test
{
    public class UsuariosServiceFake: IUsuariosService
    {
        private readonly List<Usuarios2> _usuarios;
        private readonly IMapper _mapper;


        public UsuariosServiceFake(IMapper mapper)
        {
            _mapper = mapper;
            _usuarios = new List<Usuarios2>()
                {
                    new Usuarios2() {Id = 1, NombreUsuario = "Potato", Contrasena = "12345", Email = "Casero@gmail.com", Img = "imagen", Activo = true },
                    new Usuarios2() {Id = 2, NombreUsuario = "Carlos", Contrasena = "12345", Email = "Carlos@gmail.com", Img = "imagen", Activo = false  },
                    new Usuarios2() {Id = 3, NombreUsuario = "Juanjo", Contrasena = "12345", Email = "David@gmail.com", Img = "imagen", Activo = true  },
                    new Usuarios2() {Id = 4, NombreUsuario = "Maria", Contrasena = "12345", Email = "Ortega@gmail.com", Img = "imagen", Activo = false }
                };
        }

        public IEnumerable<UsuariosDTO> GetAll()
        {
            var usuarios = _mapper.Map<IEnumerable<UsuariosDTO>>(_usuarios);
            return usuarios;
        }

        public UsuariosDetailsDTO GetById(int id)
        {
            Console.WriteLine(id);
            var usuario = _usuarios.Where(a => a.Id == id).FirstOrDefault();
            return _mapper.Map<UsuariosDetailsDTO>(usuario);
        }

        public virtual void Delete(UsuariosDetailsDTO entitytoDelete)
        {
            var usuario = _usuarios.Where(a => a.Id == entitytoDelete.Id).FirstOrDefault();
            _usuarios.Remove(usuario);
        }
        public virtual void Delete(int id)
        {
            var existing = _usuarios.First(a => a.Id == id);
            _usuarios.Remove(existing);
        }

        public virtual void Update(UsuariosEditDTO entityToUpdate)
        {
            var usuario = _usuarios.First(a => a.Id == entityToUpdate.Id);
            var mapping = _mapper.Map<Usuarios2>(entityToUpdate);
            _usuarios.Remove(usuario);
            _usuarios.Add(mapping);
        }

        public void Insert(UsuariosPostDTO entity)
        {
            var mapping = _mapper.Map<Usuarios2>(entity);
            _usuarios.Add(mapping);
        }

        public void UpdateActivo(UsuariosActivoDTO modActivo)
        {
            throw new NotImplementedException();
        }

        public void MetodoChorra()
        {
            throw new NotImplementedException();
        }

        public bool UsuariosExist(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            //  context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    //context.Dispose();
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

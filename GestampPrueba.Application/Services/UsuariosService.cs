using GestampPrueba2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestampPrueba.Application
{
    public class UsuariosService: IUsuariosService
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        public void Insert(Usuarios2 newUsuario)
        {
           unitOfWork.UsuariosRepository.Insert(newUsuario);
            unitOfWork.Save();
        }

        public IEnumerable<Usuarios2> GetAll()
        {
            return unitOfWork.UsuariosRepository.Get();
        }

        public Usuarios2 GetById(int id)
        {
            return unitOfWork.UsuariosRepository.GetByID(id);
        }

        public void Delete(int id)
        {
            unitOfWork.UsuariosRepository.Delete(id);
            unitOfWork.Save();
        }

        public void Update(Usuarios2 modUsuario)
        {
            unitOfWork.UsuariosRepository.Update(modUsuario);
            unitOfWork.Save();
        }

        public void metodoChorra()
        {
            unitOfWork.UsuariosRepository.metodoChorra();
        }
    }
}

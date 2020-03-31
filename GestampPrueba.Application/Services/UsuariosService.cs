using AutoMapper;
using GestampPrueba2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestampPrueba.Application
{
    public class UsuariosService: IUsuariosService
    {
        private readonly UnitOfWork unitOfWork = new UnitOfWork();
      /*  private readonly IMapper _mapper;

        public UsuariosService(IMapper mapper)
        {
            _mapper = mapper;
        }*/

        public void Insert(Usuarios2 newUsuario)
        {
            unitOfWork.UsuariosRepository.Insert(newUsuario);
            unitOfWork.Save();
        }

        public IEnumerable<Usuarios2> GetAll()
        {
           /* var usuarios = unitOfWork.UsuariosRepository.Get();
            UsuariosShowDTO usuariosShowDTO = _mapper.Map<UsuariosShowDTO>(usuarios);
            return usuariosShowDTO;*/

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

        public void MetodoChorra()
        {
            unitOfWork.UsuariosRepository.metodoChorra();
        }

        /*private bool UsuarioExist(int id)
        {
            if (unitOfWork.UsuariosRepository.GetByID(id))
            {

            }
        }*/
    }
}

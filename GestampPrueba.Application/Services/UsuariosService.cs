using AutoMapper;
using GestampPrueba.Application.DTOs;
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
        private readonly IMapper _mapper;

        public UsuariosService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void Insert(UsuariosPostDTO newUsuario)
        { 
            var mapping = _mapper.Map<Usuarios2>(newUsuario);
            unitOfWork.UsuariosRepository.Insert(mapping);
            unitOfWork.Save();
        }

        public IEnumerable<UsuariosDTO> GetAll()
        {
            var usuarios = unitOfWork.UsuariosRepository.Get();
            var mapping = _mapper.Map<IEnumerable<UsuariosDTO>>(usuarios);
            return mapping.ToList();
        }

        public UsuariosDetailsDTO GetById(int id)
        {
            var usuario = unitOfWork.UsuariosRepository.GetByID(id);
            var mapping = _mapper.Map<UsuariosDetailsDTO>(usuario);
            return mapping;
        }

        public void Delete(int id)
        {
            unitOfWork.UsuariosRepository.Delete(id);
            unitOfWork.Save();
        }

        public void Update(UsuariosEditDTO modUsuario)
        {
            var mapping = _mapper.Map<Usuarios2>(modUsuario);
            unitOfWork.UsuariosRepository.Update(mapping);
            unitOfWork.Save();
        }

        public void UpdateActivo(UsuariosActivoDTO modActivo)
        {
            var mapping = _mapper.Map<Usuarios2>(modActivo);
            unitOfWork.UsuariosRepository.Update(mapping);
            unitOfWork.Save();
        }

        public void MetodoChorra()
        {
            unitOfWork.UsuariosRepository.metodoChorra();
        }

        public bool UsuariosExist(int id)
        {
            return unitOfWork.UsuariosRepository.UsuariosExist(id);
        }
    }
}

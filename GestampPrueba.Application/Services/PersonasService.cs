using AutoMapper;
using GestampPrueba.Application.DTOs;
using GestampPrueba2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestampPrueba.Application.Services
{
    public class PersonasService: IPersonasService
    {
        private readonly UnitOfWork unitOfWork = new UnitOfWork();
        private readonly IMapper _mapper;
        public PersonasService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public Personas3 Insert(Personas3 newPersona)
        {
            unitOfWork.PersonasRepository.Insert(newPersona);
            unitOfWork.Save();
            return newPersona;
        }

        public IEnumerable<PersonasDTO> GetAll()
        {
            var personas = unitOfWork.PersonasRepository.Get();
            var mapping = _mapper.Map<IEnumerable<PersonasDTO>>(personas);
            return mapping.ToList();
            //return unitOfWork.PersonasRepository.Get();
        }

        public PersonasDetailsDTO GetById(int id)
        {
            var persona = unitOfWork.PersonasRepository.GetByID(id);
            var mapping = _mapper.Map<PersonasDetailsDTO>(persona);
            return mapping;
        }

        public void Delete(int id)
        {
            unitOfWork.PersonasRepository.Delete(id);
            unitOfWork.Save();
        }

        public void Update(Personas3 modPersona)
        {
            unitOfWork.PersonasRepository.Update(modPersona);
            unitOfWork.Save();
        }

        public void metodoChorra()
        {
            unitOfWork.PersonasRepository.metodoChorra();
        }
    }
}

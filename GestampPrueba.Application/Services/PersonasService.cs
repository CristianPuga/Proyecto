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
        public Personas3 Insert(Personas3 newPersona)
        {
            unitOfWork.PersonasRepository.Insert(newPersona);
            unitOfWork.Save();
            return newPersona;
        }

        public IEnumerable<Personas3> GetAll()
        {
            return unitOfWork.PersonasRepository.Get();
        }

        public Personas3 GetById(int id)
        {
            return unitOfWork.PersonasRepository.GetByID(id);
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

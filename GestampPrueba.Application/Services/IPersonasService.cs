using GestampPrueba.Application.DTOs;
using GestampPrueba2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestampPrueba.Application.Services
{
    public interface IPersonasService
    {
        IEnumerable<PersonasDTO> GetAll();
        Personas3 Insert(Personas3 newPersona);
        PersonasDetailsDTO GetById(int id);
        void Delete(int id);
        void Update(Personas3 modPersona);
        void metodoChorra();
    }
}

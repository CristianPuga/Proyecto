using GestampPrueba2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestampPrueba.Application.Services
{
    public interface IPersonasService
    {
        IEnumerable<Personas3> GetAll();
        Personas3 Insert(Personas3 newPersona);
        Personas3 GetById(int id);
        void Delete(int id);
        void Update(Personas3 modPersona);
        void metodoChorra();
    }
}

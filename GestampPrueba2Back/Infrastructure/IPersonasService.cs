using GestampPrueba2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestampPrueba2.Infrastructure
{
    public interface IPersonasService
    {
        IEnumerable<Personas3> GetAllPersonas();
        Personas3 PostPersonas3(Personas3 newPersona);
        Personas3 GetById(int id);
        void Remove(int id);
    }
}

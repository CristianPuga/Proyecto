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
        Task<IEnumerable<Personas3>> GetAllPersonas();
        Task<ActionResult<Personas3>> PostPersonas3(Personas3 newPersona);
        Task<ActionResult<Personas3>> GetById(int id);
        Task<ActionResult<Personas3>> PutPersonas3(int id, Personas3 newPersona);
        Task<ActionResult<Personas3>> DeletePersona(int id);
    }
}

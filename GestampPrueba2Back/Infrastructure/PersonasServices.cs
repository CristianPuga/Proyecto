using GestampPrueba2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestampPrueba2.Infrastructure
{
    public class PersonasServices: IPersonasService
    {
        private readonly masterContext _context = null;

        public PersonasServices(masterContext context)
        {
            _context = context;
        }

        public IEnumerable<Personas3> GetAllPersonas()
        {
            //return await _context.Personas3.ToListAsync();
            throw new NotImplementedException();

        }

        public Personas3 GetById(int id)
        {
         /*   var personas3 = await _context.Personas3.FindAsync(id);

            if (personas3 == null)
            {
                return NotFound();
            }

            return personas3;*/
            throw new NotImplementedException();

        }

        public Personas3 PostPersonas3([FromBody] Personas3 personas3)
        {
            /*context.Personas3.Add(personas3);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonas3", new { id = personas3.Id }, personas3);*/

            throw new NotImplementedException();
        }

        private ActionResult<Personas3> CreatedAtAction(string v, object p, Personas3 personas3)
        {
            throw new NotImplementedException();
        }

        private ActionResult<Personas3> NotFound()
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}

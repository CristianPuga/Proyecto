using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GestampPrueba2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using GestampPrueba2.Infrastructure;

namespace GestampPrueba2.Controllers
{

    //[Authorize]
    [ApiVersion("1.0")]
    [Route("/personas")]
    public class Personas3Controller : ControllerBase
    {
        private readonly IPersonasService personasService;

        public Personas3Controller(IPersonasService service)
        { 
            personasService = service;
        }

        // GET: api/Personas3
        /// <summary>
        /// Busca personas en una base de datos
        /// </summary>
        /// <returns>Devuelve un listado de personas</returns>
        [HttpGet]
        public async Task<IEnumerable<Personas3>> GetPersonas3()
        {
            return await personasService.GetAllPersonas();

        }
        
        // GET: api/Personas3/5
        /// <summary>
        /// Busca una persona por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Devuelve a la persona que coincida con el id que se le pasa por parametro</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Personas3>> GetPersonas3(int id)
        {
            var personas3 = await personasService.GetById(id);

            if (personas3 == null)
                {
                    return NotFound();
                }
            return await personasService.GetById(id);
        }
       
        // PUT: api/Personas3/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        /// <summary>
        /// Modifica a una persona
        /// </summary>
        /// <param name="id"></param>
        /// <param name="personas3"></param>
        /// <returns>Devuelve a la persona modificada</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<Personas3>> PutPersonas3(int id, [FromBody] Personas3 personas3)
        {
            return await personasService.PutPersonas3(id, personas3);
        }

        // POST: api/Personas3
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        /// <summary>
        /// Añade a una persona a la base de datos
        /// </summary>
        /// <param name="personas3"></param>
        /// <returns>Devuelve a la persona que se ha introducido</returns>
        [HttpPost]
        public Task<ActionResult<Personas3>> PostPersonas3([FromBody] Personas3 personas3)
        {

            return personasService.PostPersonas3(personas3);
            /*_context.Personas3.Add(personas3);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonas3", new { id = personas3.Id }, personas3);*/
        }
        
        // DELETE: api/Personas3/5
        /// <summary>
        /// Borra a una persona por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Devuelve a la persona borrada</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Personas3>> DeletePersonas3(int id)
        {
            return await personasService.DeletePersona(id);
        }
    }
}

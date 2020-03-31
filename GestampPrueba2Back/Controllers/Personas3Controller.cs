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
using GestampPrueba.Application;
using GestampPrueba.Application.Services;

namespace GestampPrueba2.Controllers
{

    [Authorize]
    [ApiVersion("1.0")]
    [Route("/personas")]
    public class Personas3Controller : ControllerBase
    {
        //private UnitOfWork unitOfWork = new UnitOfWork();
        private readonly IPersonasService personasService;
        public Personas3Controller(IPersonasService personasService)
        {
            this.personasService = personasService;
        }

        // GET: api/Personas3
        /// <summary>
        /// Busca personas en una base de datos
        /// </summary>
        /// <returns>Devuelve un listado de personas</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Personas3>> GetPersonas3()
        {
            var personas = personasService.GetAll();
            personasService.metodoChorra();
            return Ok(personas);

        }
        
        // GET: api/Personas3/5
        /// <summary>
        /// Busca una persona por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Devuelve a la persona que coincida con el id que se le pasa por parametro</returns>
        [HttpGet("{id}")]
        public ActionResult<Personas3> GetPersonas3(int id)
        {
            Console.WriteLine(id);
            Personas3 persona = personasService.GetById(id);
            if (persona == null)
            {
                return NotFound();
            }
            Console.WriteLine(persona);
            return Ok(persona);
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
            Console.WriteLine(personas3);
            if (id != personas3.Id)
            {
                return BadRequest();
            }


            try
            {
                personasService.Update(personas3);
            }
            catch (DbUpdateConcurrencyException)
            {
                /*if (!UsuarioExist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }*/
            }

            return NoContent();
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
        public ActionResult PostPersonas3([FromBody] Personas3 personas3)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            personasService.Insert(personas3);
            return CreatedAtAction("GetPersonas3", new { id = personas3.Id }, personas3);
        }
        
        // DELETE: api/Personas3/5
        /// <summary>
        /// Borra a una persona por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Devuelve a la persona borrada</returns>
        [HttpDelete("{id}")]
        public ActionResult DeletePersonas3(int id)
        {

            Personas3 persona = personasService.GetById(id);

            if (persona == null)
            {
                return NotFound();
            }
            personasService.Delete(id);
            return Ok();
        }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GestampPrueba2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace GestampPrueba2.Controllers
{

    [Authorize]
    [ApiVersion("1.0")]
    [Route("/personas")]
    public class Personas3Controller : ControllerBase
    {
        private readonly masterContext _context;

        public Personas3Controller(masterContext context)
        {
            _context = context;
        }

        // GET: api/Personas3
        /// <summary>
        /// Busca personas en una base de datos
        /// </summary>
        /// <returns>Devuelve un listado de personas</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Personas3>>> GetPersonas3()
        {
            return await _context.Personas3.ToListAsync();
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
            var personas3 = await _context.Personas3.FindAsync(id);

            if (personas3 == null)
            {
                return NotFound();
            }

            return personas3;
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
        public async Task<IActionResult> PutPersonas3(int id, [FromBody] Personas3 personas3)
        {
            if (id != personas3.Id)
            {
                return BadRequest();
            }

            _context.Entry(personas3).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Personas3Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
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
        public async Task<ActionResult<Personas3>> PostPersonas3([FromBody] Personas3 personas3)
        {
            _context.Personas3.Add(personas3);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonas3", new { id = personas3.Id }, personas3);
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
            var personas3 = await _context.Personas3.FindAsync(id);
            if (personas3 == null)
            {
                return NotFound();
            }

            _context.Personas3.Remove(personas3);
            await _context.SaveChangesAsync();

            return personas3;
        }

        private bool Personas3Exists(int id)
        {
            return _context.Personas3.Any(e => e.Id == id);
        }
    }
}

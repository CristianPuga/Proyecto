using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestampPrueba2.Models;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.Swagger.Annotations;

namespace GestampPrueba2.Controllers
{

    [Authorize]
    [ApiVersion("2.0")]
    [Route("/usuarios")]
    public class Usuarios2Controller : ControllerBase
    {
        private readonly masterContext _context;

        public Usuarios2Controller(masterContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios2
        /// <summary>
        /// Metodo para buscar usuarios en una base de datos
        /// </summary>
        /// <returns>Devuelve un listado de usuarios</returns>
        /// 
        //[AllowAnonymous]
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<Usuarios2>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResult))]
        public async Task<ActionResult<IEnumerable<Usuarios2>>> GetUsuarios2()
        {
            return await _context.Usuarios2.ToListAsync();
        }

        // GET: api/Usuarios2/5
        /// <summary>
        /// Busca un usuario por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Devuelve al usuario que coincida con el id que se le pasa por parametro</returns>
        //[AllowAnonymous]
        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(Usuarios2))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "Object Not Found", Type = typeof(NotFoundResult))]
        public async Task<ActionResult<Usuarios2>> GetUsuarios2(int id)
        {
            var usuarios2 = await _context.Usuarios2.FindAsync(id);

            if (usuarios2 == null)
            {
                return NotFound();
            }

            return Ok(usuarios2);
        }

        // PUT: api/Usuarios2/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        /// <summary>
        /// Modifica a un usuario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="usuarios2"></param>
        /// <returns>Devuelve al usuario modificado</returns>
        [HttpPut("{id}")]
        [SwaggerResponse(StatusCodes.Status204NoContent, Description = "Updated Object", Type = typeof(NoContentResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "Object Not Found", Type = typeof(NotFoundResult))]
        public async Task<IActionResult> PutUsuarios2(int id, [FromBody] Usuarios2 usuarios2)
        {
            if (id != usuarios2.Id)
            {
                return BadRequest();
            }

            _context.Entry(usuarios2).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Usuarios2Exists(id))
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

        // POST: api/Usuarios2
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        /// <summary>
        /// Añade un usuario a la base de datos
        /// </summary>
        /// <param name="usuarios2"></param>
        /// <returns>Devuelve al usuario que se ha introducido</returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<Usuarios2>> PostUsuarios2([FromBody] Usuarios2 usuarios2)
        {
            _context.Usuarios2.Add(usuarios2);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuarios2", new { id = usuarios2.Id }, usuarios2);
        }

        // DELETE: api/Usuarios2/5
        /// <summary>
        /// Borra a un usuario por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Devuelve al usuario borrado</returns>
        [HttpDelete("{id}")]
        [SwaggerResponse(StatusCodes.Status204NoContent, Description = "Deleted Object", Type = typeof(NoContentResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "Object Not Found", Type = typeof(NotFoundResult))]
        public async Task<ActionResult<Usuarios2>> DeleteUsuarios2(int id)
        {
            var usuarios2 = await _context.Usuarios2.FindAsync(id);
            if (usuarios2 == null)
            {
                return NotFound();
            }

            _context.Usuarios2.Remove(usuarios2);
            await _context.SaveChangesAsync();

            return usuarios2;
        }

        private bool Usuarios2Exists(int id)
        {
            return _context.Usuarios2.Any(e => e.Id == id);
        }
    }
}

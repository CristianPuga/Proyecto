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
using GestampPrueba.Application;
using AutoMapper;

namespace GestampPrueba2.Controllers
{

    [Authorize]
    [ApiVersion("2.0")]
    [Route("/usuarios")]
    public class Usuarios2Controller : ControllerBase
    {
         private readonly IUsuariosService usuarioService;
        private readonly IMapper _mapper;

        public Usuarios2Controller(IUsuariosService usuariosService, IMapper mapper)
        {
            usuarioService = usuariosService;
            _mapper = mapper;
        }

        // GET: api/Usuarios2
        /// <summary>
        /// Metodo para buscard
        /// usuarios en una base de datos
        /// </summary>
        /// <returns>Devuelve un listado de usuarios</returns>
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<Usuarios2>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResult))]
        public IEnumerable<Usuarios2> GetUsuarios2()
        {
            var usuarios = usuarioService.GetAll();
            return usuarios.ToList();
        }

        // GET: api/Usuarios2/5
        /// <summary>
        /// Busca un usuario por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Devuelve al usuario que coincida con el id que se le pasa por parametro</returns>
        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(Usuarios2))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "Object Not Found", Type = typeof(NotFoundResult))]
        public async Task<ActionResult<Usuarios2>> GetUsuarios2(int id)
        {
            Usuarios2 usuario = usuarioService.GetById(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
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
        public async Task<ActionResult> PutUsuario(int id, [FromBody] Usuarios2 usuarios2)
        {
            Console.WriteLine(usuarios2);
            if (id != usuarios2.Id)
            {
                return BadRequest();
            }

            try
            {
                usuarioService.Update(usuarios2);
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
        public async Task<ActionResult<Usuarios2>> PostUsuario([FromBody] Usuarios2 usuarios2)
        {
            usuarioService.Insert(usuarios2);
            return usuarios2;
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
            Usuarios2 usuario = usuarioService.GetById(id);
            if (usuario == null)
            {
                return NotFound();
            }
            usuarioService.Delete(id);
            return usuario;
        }
    }
}

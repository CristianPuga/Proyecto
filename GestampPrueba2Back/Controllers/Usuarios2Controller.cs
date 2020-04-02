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
using GestampPrueba.Application.DTOs;

namespace GestampPrueba2.Controllers
{

    [Authorize]
    [ApiVersion("2.0")]
    [Route("/usuarios")]
    public class Usuarios2Controller : ControllerBase
    {
         private readonly IUsuariosService usuarioService;

        public Usuarios2Controller(IUsuariosService usuariosService)
        {
            usuarioService = usuariosService;
        }

        // GET: api/Usuarios2
        /// <summary>
        /// Metodo para buscard
        /// usuarios en una base de datos
        /// </summary>
        /// <returns>Devuelve un listado de usuarios</returns>
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<UsuariosDTO>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResult))]
        public ActionResult<IEnumerable<UsuariosDTO>> GetUsuarios2()
        {
            var usuarios = usuarioService.GetAll();
            return Ok(usuarios);
        }

        // GET: api/Usuarios2/5
        /// <summary>
        /// Busca un usuario por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Devuelve al usuario que coincida con el id que se le pasa por parametro</returns>
        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(UsuariosDetailsDTO))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "Object Not Found", Type = typeof(NotFoundResult))]
        public ActionResult<UsuariosDetailsDTO> GetUsuarios2(int id)
        {
            UsuariosDetailsDTO usuario = usuarioService.GetById(id);
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
        public ActionResult PutUsuario(int id, [FromBody] UsuariosEditDTO usuariosEditDTO)
        {
            Console.WriteLine(usuariosEditDTO.Id);
            Console.WriteLine(usuariosEditDTO.NombreUsuario);
            Console.WriteLine(usuariosEditDTO.Img);
            Console.WriteLine(usuariosEditDTO.Email);


            if (id != usuariosEditDTO.Id)
            {
                return BadRequest();
            }

            try
            {
                usuarioService.Update(usuariosEditDTO);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!usuarioService.UsuariosExist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(usuariosEditDTO);
        }

        [HttpPut("activo/{id}")]
        [SwaggerResponse(StatusCodes.Status204NoContent, Description = "Updated Object", Type = typeof(NoContentResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "Object Not Found", Type = typeof(NotFoundResult))]
        public ActionResult PutUsuarioActivo(int id, [FromBody] UsuariosActivoDTO usuariosActivoDTO)
        {
            if (id != usuariosActivoDTO.Id)
            {
                return BadRequest();
            }

            try
            {
                usuarioService.UpdateActivo(usuariosActivoDTO);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!usuarioService.UsuariosExist(id))
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
        public ActionResult PostUsuario([FromBody] UsuariosPostDTO usuariosPostDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            usuarioService.Insert(usuariosPostDTO);
            return CreatedAtAction("GetUsuarios2", new { id = usuariosPostDTO.Id }, usuariosPostDTO);
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
        public ActionResult DeleteUsuarios2(int id)
        {
            UsuariosDetailsDTO usuario = usuarioService.GetById(id);
            if (usuario == null)
            {
                return NotFound();
            }
            usuarioService.Delete(id);
            return Ok();
        }
    }
}

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

namespace GestampPrueba2.Controllers
{

    //[Authorize]
    [ApiVersion("2.0")]
    [Route("/usuarios")]
    public class Usuarios2Controller : ControllerBase
    {
        //private IUsuariosRepository usuariosRepository;
        private UnitOfWork unitOfWork = new UnitOfWork();

        public Usuarios2Controller()
        {
            //this.usuariosRepository = new UsuariosRepository(new masterContext());
        }

       /* public Usuarios2Controller(IUsuariosRepository usuariosRepository)
        {
            this.usuariosRepository = usuariosRepository;
        }*/

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
            var usuarios = unitOfWork.UsuariosRepository.Get();
            return usuarios.ToList();
            //return await usuariosRepository.GetAllUsuarios();
            //return await _context.Usuarios2.ToListAsync();
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
            Usuarios2 usuario = unitOfWork.UsuariosRepository.GetByID(id);
            return usuario;

            /*var usuarios2 = await usuariosRepository.GetById(id);

            if (usuarios2 == null)
            {
                return NotFound();
            }
            return await usuariosRepository.GetById(id);*/
            /*var usuarios2 = await _context.Usuarios2.FindAsync(id);

            if (usuarios2 == null)
            {
                return NotFound();
            }

            return Ok(usuarios2);*/
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
        public async Task<ActionResult<Usuarios2>> PutUsuario(int id, [FromBody] Usuarios2 usuarios2)
        {
            //return await usuariosRepository.PutUsuario(id, usuarios2);

            Console.WriteLine(usuarios2);
            if (id != usuarios2.Id)
            {
                return BadRequest();
            }


            unitOfWork.UsuariosRepository.Update(usuarios2);


            try
            {
                unitOfWork.Save();
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
            unitOfWork.UsuariosRepository.Insert(usuarios2);
            unitOfWork.Save();

            return usuarios2;
            //return usuariosRepository.PostUsuario(usuarios2);
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

            Usuarios2 usuario = unitOfWork.UsuariosRepository.GetByID(id);
            unitOfWork.UsuariosRepository.Delete(id);
            unitOfWork.Save();
            return usuario;

            /*var usuario = await usuariosRepository.GetById(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return await usuariosRepository.DeleteUsuario(id);*/

            /*var usuarios2 = await _context.Usuarios2.FindAsync(id);
            if (usuarios2 == null)
            {
                return NotFound();
            }

            _context.Usuarios2.Remove(usuarios2);
            await _context.SaveChangesAsync();

            return usuarios2;*/
        }

        /*protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }*/

    }
}

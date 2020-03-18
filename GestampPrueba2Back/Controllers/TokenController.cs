using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using GestampPrueba2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace GestampPrueba2.Controllers
{
    /// <summary>
    /// Ruta de acceso al controlador
    /// </summary>
    /// <remarks>
    /// Esta es la ruta por la que accedemos a este controlador
    /// Esto nos servira para hacer las llamadas al backend desde nuestro cliente
    /// </remarks>
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly masterContext _context;

        public TokenController(IConfiguration config, masterContext context)
        {
            _configuration = config;
            _context = context;
        }
        /// <summary>
        /// Metodo de validacion de usuario
        /// </summary>
        /// <param name="_userData"></param>
        /// <returns>Devuelve un token unico por usuario</returns>
        [HttpPost]
        public async Task<IActionResult> Post(Usuarios2 _userData)
        {
            Console.WriteLine("Estoy dentro");
            Console.WriteLine(_userData.NombreUsuario);
            Console.WriteLine(_userData.Contrasena);
            
            if (_userData != null && _userData.NombreUsuario != null && _userData.Contrasena != null)
            {
                var user = await GetUser(_userData.NombreUsuario, _userData.Contrasena);
                Console.WriteLine(user);

                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("Id", user.Id.ToString()),
                    new Claim("NombreUsuario", user.NombreUsuario),
                    new Claim("Email", user.Email)
                  //  new Claim("UserName", user.UserName),
                  //  new Claim("Email", user.Email)
                   };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

                    Console.WriteLine("Usuario Correcto, generando token...");
                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token)
                    });


                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Metodo para comprobar al usuario con la base de datos
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="contrasena"></param>
        /// <returns>Devuelve a un usuario si lo encuentra en nuestra base de datos</returns>
        private async Task<Usuarios2> GetUser(string usuario, string contrasena)
        {
            return await _context.Usuarios2.FirstOrDefaultAsync(u => u.NombreUsuario == usuario && u.Contrasena == contrasena);
        }
    }
}
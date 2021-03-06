﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using GestampPrueba2.Infrastructure;
using GestampPrueba2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.Swagger.Annotations;

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
        private readonly ITokenRepository _TokenRepository;
        private readonly masterContext _context;

        public TokenController(ITokenRepository TokenRepository, IConfiguration Configuration, masterContext context)
        {
            _TokenRepository = TokenRepository;
            _context = context;
            _configuration = Configuration;
        }
        /// <summary>
        /// Metodo de validacion de usuario
        /// </summary>
        /// <param name="_userData"></param>
        /// <returns>Devuelve un token unico por usuario</returns>
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(Usuarios2))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Type = typeof(UnauthorizedResult))]
        [HttpPost]
        public async Task<IActionResult> Post(Usuarios2 _userData)
        {
            Console.WriteLine("Estoy dentro");
            Console.WriteLine(_userData.NombreUsuario);
            Console.WriteLine(_userData.Contrasena);

            var prueba = await _TokenRepository.Authenticate(_userData.NombreUsuario, _userData.Contrasena);
            if (prueba == null)
                return Unauthorized(new { message = "Username or password is incorrect" });


            if (_userData != null && _userData.NombreUsuario != null && _userData.Contrasena != null)
            {
                var user = await _TokenRepository.Authenticate(_userData.NombreUsuario, _userData.Contrasena);
                Console.WriteLine(user.NombreUsuario);
                Console.WriteLine(user.Contrasena);

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
    }
}
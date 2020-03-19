using GestampPrueba2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestampPrueba2.Infrastructure
{
    public class TokenRepository: ITokenRepository
    {
        private readonly masterContext _context = null;

        public TokenRepository(masterContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Metodo para comprobar al usuario con la base de datos
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="contrasena"></param>
        /// <returns>Devuelve a un usuario si lo encuentra en nuestra base de datos</returns>
        public async Task<Usuarios2> Authenticate(string usuario, string contrasena)
        {
            return await _context.Usuarios2.FirstOrDefaultAsync(u => u.NombreUsuario == usuario && u.Contrasena == contrasena);
        }
    }
}

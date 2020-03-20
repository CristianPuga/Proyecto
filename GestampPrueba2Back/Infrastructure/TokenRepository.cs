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
        public async Task<Usuarios2> Authenticate(string usuario, string contrasena)
        {
            try
            {
                var user = await _context.Usuarios2.FirstOrDefaultAsync(u => u.NombreUsuario == usuario && u.Contrasena == contrasena);
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
    }
}

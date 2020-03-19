using GestampPrueba2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestampPrueba2.Infrastructure
{
    public interface ITokenRepository
    {
        Task<Usuarios2> Authenticate(string usuario, string contrasena);
    }
}

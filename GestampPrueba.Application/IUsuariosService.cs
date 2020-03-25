using GestampPrueba2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestampPrueba.Application
{
    public interface IUsuariosService
    {
        Task<ActionResult<IEnumerable<Usuarios2>>> GetAllUsuarios();
        Task<ActionResult<Usuarios2>> PostUsuarios2(Usuarios2 newUsuario);
        Task<ActionResult<Usuarios2>> GetById(int id);
        Task<ActionResult<Usuarios2>> PutUsuario2(int id, Usuarios2 newUsuario);
        Task<ActionResult<Usuarios2>> DeleteUsuario(int id);
    }
}

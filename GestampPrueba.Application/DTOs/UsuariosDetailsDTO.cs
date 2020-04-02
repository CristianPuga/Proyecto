using System;
using System.Collections.Generic;
using System.Text;

namespace GestampPrueba.Application.DTOs
{
   public partial class UsuariosDetailsDTO
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public string Email { get; set; }
        public bool? Activo { get; set; }
    }
}

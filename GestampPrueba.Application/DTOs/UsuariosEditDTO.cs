using System;
using System.Collections.Generic;
using System.Text;

namespace GestampPrueba.Application.DTOs
{
    public partial class UsuariosEditDTO
    {
        public int Id { get; set; }
        public virtual string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public virtual string Email { get; set; }
        public virtual string Img { get; set; }
    }
}

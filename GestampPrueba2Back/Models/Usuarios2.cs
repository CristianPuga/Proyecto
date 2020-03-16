using System;
using System.Collections.Generic;

namespace GestampPrueba2.Models
{
    public partial class Usuarios2
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public string Email { get; set; }
        public string Img { get; set; }
        public bool? Activo { get; set; }
    }
}

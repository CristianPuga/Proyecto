using System;
using System.Collections.Generic;
using System.Text;

namespace GestampPrueba.Models
{
   public class Usuarios2
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Email { get; set; }
        public string Img { get; set; }
        public bool? Activo { get; set; }
    }
}

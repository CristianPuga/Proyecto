using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestampPrueba2.Models
{
    public partial class Personas3
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public int Edad { get; set; }
    }
}

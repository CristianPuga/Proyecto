using System;
using System.Collections.Generic;
using System.Text;

namespace GestampPrueba.Application.DTOs
{
    public class PersonasDetailsDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string? Apellido { get; set; }
        public int Edad { get; set; }
    }
}

using GestampPrueba2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestampPrueba.Infrastructure
{
    public interface IMasterUsuariosContext
    {
        public DbSet<Usuarios2> Usuarios2 { get; }
    }
}

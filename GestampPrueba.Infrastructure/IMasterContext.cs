using GestampPrueba2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestampPrueba.Infrastructure
{
    public interface IMasterContext
    {
        public DbSet<Personas3> Personas3 { get; }
    }
}

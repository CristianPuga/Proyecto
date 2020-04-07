using GestampPrueba2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestampPrueba.Infrastructure
{
    public class PersonasConfiguration: IEntityTypeConfiguration<Personas3>
    {
        public void Configure(EntityTypeBuilder<Personas3> builder)
        {
            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Apellido)
                .HasColumnName("apellido")
                .HasMaxLength(50);

            builder.Property(e => e.Edad).HasColumnName("edad");

            builder.Property(e => e.Nombre)
                .HasColumnName("nombre")
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}

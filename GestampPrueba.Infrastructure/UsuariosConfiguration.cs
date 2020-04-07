using GestampPrueba2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestampPrueba.Infrastructure
{
    public class UsuariosConfiguration : IEntityTypeConfiguration<Usuarios2>
    {
        public void Configure(EntityTypeBuilder<Usuarios2> entity)
        {
            entity.ToTable("usuarios2");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Activo).HasColumnName("activo");

            entity.Property(e => e.Contrasena)
                .HasColumnName("contrasena")
                .HasMaxLength(50);

            entity.Property(e => e.Email)
                .HasColumnName("email")
                .HasMaxLength(50);

            entity.Property(e => e.Img).HasColumnName("img");

            entity.Property(e => e.NombreUsuario)
                .HasColumnName("nombre_usuario")
                .HasMaxLength(50);
        }
    }
}

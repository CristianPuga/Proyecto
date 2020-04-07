using System;
using GestampPrueba.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GestampPrueba2.Models
{
    public partial class masterContext : DbContext, IMasterContext, IMasterUsuariosContext
    {
        public masterContext() {}
        public masterContext(DbContextOptions<masterContext> options): base(options)
        {
        }
        public DbSet<Usuarios2> Usuarios2 { get; set; }
        public DbSet<Personas3> Personas3 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=master;Integrated Security=True");
            }
        } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UsuariosConfiguration());
            modelBuilder.ApplyConfiguration(new PersonasConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}









/*modelBuilder.Entity<Personas3>(entity =>
{
    entity.Property(e => e.Id).HasColumnName("id");

    entity.Property(e => e.Apellido)
        .HasColumnName("apellido")
        .HasMaxLength(50);

    entity.Property(e => e.Edad).HasColumnName("edad");

    entity.Property(e => e.Nombre)
        .HasColumnName("nombre")
        .HasMaxLength(50)
        .IsUnicode(false);
});*/

/* modelBuilder.Entity<Usuarios2>(entity =>
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
 });*/

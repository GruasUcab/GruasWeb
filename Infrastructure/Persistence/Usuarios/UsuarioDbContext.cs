using Microsoft.EntityFrameworkCore;
using GrúasUCAB.Core.Usuarios.Entities;

namespace GrúasUCAB.Infrastructure.Persistence.Usuarios
{
    public class UsuarioDbContext : DbContext
    {
        public UsuarioDbContext(DbContextOptions<UsuarioDbContext> options) : base(options)
        {
        }

        // DbSets para las entidades
        public required DbSet<Usuario> Usuarios { get; set; }
        public required DbSet<Departamento> Departamentos { get; set; }

        // Configuración de las entidades y sus mapeos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración para la entidad Usuario
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuario"); // Nombre de la tabla
                entity.HasKey(u => u.Id);  // Clave primaria

                entity.Property(u => u.Nombre)
                      .IsRequired()
                      .HasMaxLength(20);

                entity.Property(u => u.Apellido)
                      .IsRequired()
                      .HasMaxLength(20);

                entity.Property(u => u.Email)
                      .IsRequired()
                      .HasMaxLength(30);

                entity.Property(u => u.Clave)
                      .IsRequired()
                      .HasMaxLength(16);

                entity.Property(u => u.TipoUsuario)
                      .IsRequired()
                      .HasMaxLength(20);

                entity.Property(u => u.Activo)
                      .IsRequired();

                // Relación con Departamento (FK)
                entity.HasOne<Departamento>()
                      .WithMany()
                      .HasForeignKey(u => u.DepartamentoId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuración para la entidad Departamento
            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.ToTable("departamento"); // Nombre de la tabla
                entity.HasKey(d => d.Id);  // Clave primaria

                entity.Property(d => d.Nombre)
                      .IsRequired()
                      .HasMaxLength(20);

                entity.Property(d => d.Descripcion)
                      .HasMaxLength(100); // Campo opcional
            });
        }
    }
}

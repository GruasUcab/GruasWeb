using Microsoft.EntityFrameworkCore;
using GrúasUCAB.Core.Proveedores.Entities;

namespace GrúasUCAB.Infrastructure.Persistence.Proveedores
{
    public class ProveedorDbContext : DbContext
    {
        public ProveedorDbContext(DbContextOptions<ProveedorDbContext> options) : base(options)
        {
        }

        // DbSets para las entidades
        public required DbSet<Proveedor> Proveedores { get; set; }
        public required DbSet<Vehiculo> Vehiculos { get; set; }

        // Configuración de las entidades y sus mapeos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración para la entidad Proveedor
            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.ToTable("Proveedor");
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Nombre)
                      .IsRequired()
                      .HasMaxLength(20);

                entity.Property(p => p.Tipo)
                      .IsRequired()
                      .HasMaxLength(20);

                entity.Property(p => p.Direccion)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(p => p.Email)
                      .IsRequired()
                      .HasMaxLength(30);

                entity.Property(p => p.Activo)
                      .IsRequired();
            });

            // Configuración para la entidad Vehiculo
            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.ToTable("Vehiculo");
                entity.HasKey(v => v.Id);

                entity.Property(v => v.Placa)
                      .IsRequired()
                      .HasMaxLength(10);

                entity.Property(v => v.Modelo)
                      .IsRequired()
                      .HasMaxLength(15);

                entity.Property(v => v.Capacidad)
                      .IsRequired();

                entity.Property(v => v.Activo)
                      .IsRequired();

                // Relación con Proveedor
                //entity.HasOne(v => v.Proveedor)
                  //    .WithMany(p => p.Vehiculos)
                    //  .HasForeignKey(v => v.ProveedorId)
                      //.OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}

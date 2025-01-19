using Microsoft.EntityFrameworkCore;
using GrúasUCAB.Core.Proveedores.Entities;
using GrúasUCAB.Core.Ordenes.Entities;
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
        public required DbSet<Conductor> Conductores { get; set; }
        public required DbSet<OrdenDeServicio> OrdenesDeServicio { get; set; }

        


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
        entity.HasKey(v => v.Id);
        entity.ToTable("Vehiculo");

        entity.Property(v => v.Marca).IsRequired().HasMaxLength(100);
        entity.Property(v => v.Modelo).IsRequired().HasMaxLength(100);
        entity.Property(v => v.Placa).IsRequired().HasMaxLength(50);
        entity.Property(v => v.ProveedorId).IsRequired();
        entity.Property(v => v.Capacidad).IsRequired();
        entity.Property(v => v.Activo).IsRequired();

        // Configuración de relaciones
        entity.HasOne(v => v.Proveedor)
              .WithMany(p => p.Vehiculos)
              .HasForeignKey(v => v.ProveedorId)
              .OnDelete(DeleteBehavior.Cascade);

        // Ignorar navegaciones en el constructor
        entity.Ignore(v => v.Proveedor);
    });
             modelBuilder.Entity<Conductor>(entity =>
            {
                  entity.ToTable("Conductor");
                  entity.HasKey(c => c.Id);

                  entity.Property(c => c.Nombre)
                        .IsRequired()
                        .HasMaxLength(20);

                  entity.Property(c => c.Telefono)
                        .IsRequired()
                        .HasMaxLength(15);

                  entity.Property(c => c.Licencia)
                        .IsRequired()
                        .HasMaxLength(20);

                  entity.Property(c => c.Activo)
                        .IsRequired();

                  entity.Property(c => c.Sub)
                        .IsRequired();                  
                  


                  /*entity.HasMany(c => c.Ordenes)
                        .WithOne(o => o.Conductor)
                        .HasForeignKey(o => o.ConductorId)
                        .OnDelete(DeleteBehavior.Restrict);*/
            });
            
        }
    }
}

using Microsoft.EntityFrameworkCore;
using GrúasUCAB.Core.Ordenes.Entities;

namespace GrúasUCAB.Infrastructure.Persistence.Ordenes
{
    public class OrdenDbContext : DbContext
    {
        public OrdenDbContext(DbContextOptions<OrdenDbContext> options) : base(options)
        {
        }

        // DbSets para las entidades
        public required DbSet<Poliza> Polizas { get; set; }
        public required DbSet<Asegurado> Asegurados { get; set; }
        public required DbSet<OrdenDeServicio> OrdenDeServicios { get; set; }
        public required DbSet<CostoAdicional> CostosAdicionales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración para Poliza
            modelBuilder.Entity<Poliza>(entity =>
            {
                entity.ToTable("Poliza");
                entity.HasKey(p => p.Id);

                entity.Property(p => p.TipoCobertura)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(p => p.KilometrosIncluidos)
                      .IsRequired();
            });

            // Configuración para Asegurado
            modelBuilder.Entity<Asegurado>(entity =>
            {
                entity.ToTable("Asegurado");
                entity.HasKey(a => a.Id);

                entity.Property(a => a.Nombre)
                      .IsRequired()
                      .HasMaxLength(20);

                entity.Property(a => a.Telefono)
                      .IsRequired()
                      .HasMaxLength(15);

                entity.Property(a => a.Email)
                      .IsRequired()
                      .HasMaxLength(30);

                entity.HasOne(a => a.Poliza)
                      .WithMany()
                      .HasForeignKey(a => a.PolizaId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuración para OrdenServicio
            modelBuilder.Entity<OrdenDeServicio>(entity =>
    {
            entity.HasKey(o => o.Id);

            entity.Property(o => o.FechaCreacion)
              .IsRequired();

            entity.Property(o => o.Estado)
              .HasMaxLength(20)
              .IsRequired();
              

            entity.Property(o => o.UbicacionIncidente)
              .HasMaxLength(40)
              .IsRequired();

            entity.Property(o => o.UbicacionDestino)
              .HasMaxLength(40)
              .IsRequired();

            entity.Property(o => o.KilometrosRecorridos)
              .IsRequired();

            entity.Property(o => o.CostoTotal)
              .IsRequired();

            entity.HasOne(o => o.Conductor)
              .WithMany(c => c.OrdenesDeServicio)
              .HasForeignKey(o => o.ConductorId)
              .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(o => o.Proveedor)
              .WithMany(p => p.OrdenesDeServicio)
              .HasForeignKey(o => o.ProveedorId)
              .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(o => o.Vehiculo)
              .WithMany(v => v.OrdenesDeServicio)
              .HasForeignKey(o => o.VehiculoId)
              .OnDelete(DeleteBehavior.Restrict);
    });
        

            // Configuración para CostoAdicional
            modelBuilder.Entity<CostoAdicional>(entity =>
            {
                entity.ToTable("CostoAdicional");
                entity.HasKey(c => c.Id);

                entity.Property(c => c.Nombre)
                      .IsRequired()
                      .HasMaxLength(20);

                entity.Property(c => c.Monto)
                      .IsRequired();

                entity.HasOne(c => c.Orden)
                      .WithMany()
                      .HasForeignKey(c => c.OrdenId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}

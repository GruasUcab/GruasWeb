using Microsoft.EntityFrameworkCore;
using GrúasUCAB.Core.Proveedores.Entities;
using GrúasUCAB.Core.Ordenes.Entities;
using Npgsql.EntityFrameworkCore.PostgreSQL.Storage.Internal.Mapping;



namespace GrúasUCAB.Infrastructure.Persistence.Ordenes
{
    public class OrdenDbContext : DbContext
    {
        public required DbSet<OrdenDeServicio> OrdenesDeServicio { get; set; }
        public required DbSet<Poliza> Polizas { get; set; }
        public required DbSet<Asegurado> Asegurados { get; set; }
        public required DbSet<CostoAdicional> CostosAdicionales { get; set; }

        public OrdenDbContext(DbContextOptions<OrdenDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de OrdenDeServicio
            modelBuilder.Entity<OrdenDeServicio>(entity =>
            {
                entity.ToTable("OrdenDeServicio");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.FechaCreacion)
                      .IsRequired();

                entity.Property(e => e.Estado)
                      .IsRequired()
                      .HasMaxLength(20);

                entity.Property(e => e.UbicacionIncidente)
                      .IsRequired()
                      .HasMaxLength(40);

                entity.Property(e => e.UbicacionDestino)
                      .IsRequired()
                      .HasMaxLength(40);

                entity.Property(e => e.KilometrosRecorridos)
                      .IsRequired();

                entity.Property(e => e.CostoTotal)
                      .IsRequired();

                entity.Property(e => e.ConductorId)
                      .IsRequired();
                      

                entity.Property(e => e.ProveedorId)
                        .IsRequired();

                      

                entity.Property(e => e.VehiculoId)
                        .IsRequired();

                modelBuilder.Entity<CostoAdicional>().ToTable("CostosAdicionales");
                      
            });

            // Configuración de Poliza
            modelBuilder.Entity<Poliza>(entity =>
            {
                entity.ToTable("Poliza");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.TipoCobertura)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.KilometrosIncluidos)
                      .IsRequired();
            });

            // Configuración de Asegurado
            modelBuilder.Entity<Asegurado>(entity =>
            {
                entity.ToTable("Asegurado");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Nombre)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(e => e.Apellido)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(e => e.DocumentoIdentidad)
                      .IsRequired()
                      .HasMaxLength(15);

                entity.Property(e => e.Telefono)
                      .IsRequired();

                entity.Property(e => e.PolizaId)
                        .IsRequired();
                      
            });

            // Configuración de CostoAdicional
            
            modelBuilder.Entity<CostoAdicional>(entity =>
            {
                entity.ToTable("CostoAdicional");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Nombre)
                      .IsRequired()
                      .HasMaxLength(255);
                 entity.Property(e => e.Descripcion)
                       .IsRequired()
                       .HasMaxLength(100);

                entity.Property(e => e.Monto)
                      .IsRequired();

                entity.Property(e => e.OrdenId)
                      .IsRequired();

                modelBuilder.Entity<CostoAdicional>()
                .HasOne(c => c.Orden)
                .WithMany(o => o.CostosAdicionales)
                .HasForeignKey(c => c.OrdenId)
                .OnDelete(DeleteBehavior.Cascade);
                
            });
        }
    }
}

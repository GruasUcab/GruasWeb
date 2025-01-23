using Microsoft.EntityFrameworkCore;
using GrúasUCAB.Core.Ordenes.Entities;
using Npgsql.EntityFrameworkCore.PostgreSQL.Storage.Internal.Mapping;
using Microsoft.EntityFrameworkCore.Infrastructure;



namespace GrúasUCAB.Infrastructure.Persistence.Ordenes
{
    public class OrdenDbContext : DbContext
    {
        public required DbSet<OrdenDeServicio> OrdenesDeServicio { get; set; }
        public required DbSet<Poliza> Polizas { get; set; }
        public required DbSet<Asegurado> Asegurados { get; set; }
        public required DbSet<CostoAdicional> CostosAdicionales { get; set; }
        public required DbSet<VehiculoAsegurado> VehiculosAsegurados {get; set;}

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
                entity.ToTable("OrdenDeServicios");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.FechaCreacion);
                      

                entity.Property(e => e.Estado)
                        .HasConversion(
                v => v.ToString(), // Convierte el enum a string al guardar
                v => (EstadoOrden)Enum.Parse(typeof(EstadoOrden), v) // Convierte el string a enum al leer
            );

                entity.Property(e => e.UbicacionIncidente)
                      .IsRequired()
                      .HasMaxLength(40);

                  entity.Property(e=> e.LatitudConductor);

                  entity.Property(e=> e.LongitudConductor);


                entity.Property(e => e.UbicacionDestino)
                      .IsRequired()
                      .HasMaxLength(40);

                entity.Property(e => e.KilometrosRecorridos);
                      

                entity.Property(e => e.CostoTotal);
                      

                  entity.Property(e => e.CostoBase);
                        

                entity.Property(e => e.ConductorId);

                entity.Property(e => e.VehiculoAseguradoId)
                  .IsRequired();
                      
                      

                entity.Property(e => e.ProveedorId);
                        

                  entity.Property(e => e.AseguradoId);

                  entity.Property(e => e.LatitudDestino)
                        .IsRequired();

                  entity.Property(e => e.LongitudDestino)
                        .IsRequired();

                  entity.Property(e => e.LatitudIncidente)
                        .IsRequired();

                  entity.Property(e => e.LongitudIncidente)
                        .IsRequired();
                        

                      

                entity.Property(e => e.VehiculoId);
                        

                modelBuilder.Entity<CostoAdicional>().ToTable("CostosAdicionales");
                      
            });

            modelBuilder.Entity<VehiculoAsegurado>(entity =>
            {
                  entity.ToTable("VehiculoAsegurado");
                  entity.HasKey(e => e.Id);

                  entity.Property(e => e.Marca)
                        .IsRequired();

                  entity.Property(e => e.Modelo)
                        .IsRequired();
                  
                  entity.Property(e => e.Placa)
                        .IsRequired();
                  
                  entity.Property(e => e.Tipo)
                        .IsRequired();

                  entity.Property(e => e.AseguradoId)
                        .IsRequired();
                  
                  entity.Property(e => e.PolizaId)
                        .IsRequired();

                  /*modelBuilder.Entity<VehiculoAsegurado>()
                  .HasOne(c => c.Asegurado)
                  .WithMany(o => o.)
                  .HasForeignKey(c => c.aseguradoId)
                  .OnDelete(DeleteBehavior.Cascade);*/
            }      
            
            
            );

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

                  entity.Property(e => e.Nombre)
                        .IsRequired();

                  entity.Property(e => e.CostoXKilometro)
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

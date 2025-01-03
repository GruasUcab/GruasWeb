using GrúasUCAB.Infrastructure.Persistence.Usuarios;
using GrúasUCAB.Infrastructure.Persistence.Proveedores;
using GrúasUCAB.Core.Usuarios.Repositories;
using Microsoft.EntityFrameworkCore;
using GrúasUCAB.Infrastructure.Handlers.Usuarios;
using GrúasUCAB.Core.Proveedores.Repositories;
using AutoMapper;
using GrúasUCAB.Core.Proveedores.Entities;
using GrúasUCAB.Core.Proveedores.Dto;
using GrúasUCAB.Core.Ordenes.Repositories;
using GrúasUCAB.Infrastructure.Persistence.Ordenes;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using FirebaseAdmin;



var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Inyección de dependencias
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IProveedorRepository, ProveedorRepository>();
builder.Services.AddDbContext<UsuarioDbContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("UsuarioConnection")));
builder.Services.AddDbContext<ProveedorDbContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("ProveedorConnection")));
builder.Services.AddDbContext<OrdenDbContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("OrdenConnection")));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateUsuarioCommandHandler).Assembly));
builder.Services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
builder.Services.AddScoped<IVehiculoRepository, VehiculoRepository>();
builder.Services.AddScoped<IConductorRepository, ConductorRepository>();
builder.Services.AddScoped<IOrdenDeServicioRepository, OrdenDeServicioRepository>();
builder.Services.AddScoped<IPolizaRepository, PolizaRepository>();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddDbContext<ProveedorDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("ProveedorConnection"),
        b => b.MigrationsAssembly("Infrastructure") // Aquí se especifica el ensamblado
    ));


/*FirebaseApp.Create(new AppOptions
{
    Credential = GoogleCredential.FromFile("path/to/your-firebase-adminsdk.json") // Ruta al archivo JSON descargado de Firebase
});*/



// Configuración de bases de datos
builder.Services.AddDbContext<UsuarioDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("UsuarioConnection")));

// Construir la aplicación
var app = builder.Build();

// Configurar middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
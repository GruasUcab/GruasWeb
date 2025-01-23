using Microsoft.EntityFrameworkCore;
using GrúasUCAB.Core.Ordenes.Repositories;
using GrúasUCAB.Infrastructure.Persistence.Ordenes;
using GrúasUCAB.Infrastructure.Persistence.Asegurados;
using GrúasUCAB.Core.Ordenes.Commands;

using RabbitMQ;
using RabbitMQ.Client;





var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Inyección de dependencias

builder.Services.AddDbContext<OrdenDbContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("OrdenConnection")));

builder.Services.AddScoped<IVehiculoAseguradoRepository, VehiculoAseguradoRepository>();
builder.Services.AddScoped<IOrdenDeServicioRepository, OrdenDeServicioRepository>();
builder.Services.AddScoped<IPolizaRepository, PolizaRepository>();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IAseguradoRepository, AseguradoRepository>();
builder.Services.AddScoped<ICostoAdicionalRepository, CostoAdicionalRepository>();

builder.Services.AddScoped<EstadoOrdenMachine>();


builder.Services.AddSingleton<IConfiguration>(builder.Configuration);


builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "http://localhost:8080/realms/GruasUcab";
        options.RequireHttpsMetadata = false; // Solo para desarrollo. Habilitar HTTPS en producción.
        options.Audience = "account";
    });

builder.Services.AddAuthorization();
builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Debug);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
    typeof(CreateOrdenDeServicioCommandHandler).Assembly,  // Assembly del handler
    typeof(Program).Assembly                       // Assembly principal
));


builder.Services.AddHttpClient("ProveedoresClient", client =>
{
    client.BaseAddress = new Uri("http://localhost:5215/proveedores/api/"); // Cambia esta URL por la del microservicio de proveedores
});


builder.Services.AddHttpClient<ProveedoresService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5215/proveedores/api/"); // URL base del microservicio de proveedores
});












//Envio de solicitud al front
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:3000") // URL del frontend
              .AllowAnyHeader()
              .AllowAnyMethod();
    });

    
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.WithOrigins("*") // URL del frontend
              .AllowAnyHeader()
              .AllowAnyMethod();
    });

    
});

// Construir la aplicación
var app = builder.Build();




// Configurar middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowReactApp");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
using MediatR;
using FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;
using GrúasUCAB.Infrastructure.Persistence.Usuarios;
using GrúasUCAB.Infrastructure.Persistence.Proveedores;
using GrúasUCAB.Core.Usuarios.Repositories;
using Microsoft.EntityFrameworkCore;
using GrúasUCAB.Infrastructure.Persistence.Ordenes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using GrúasUCAB.Infrastructure.Handlers.Usuarios;
using GrúasUCAB.Core.Proveedores.Repositories;

/*var builder = WebApplication.CreateBuilder(args);

// Agregar servicios para los controladores
builder.Services.AddControllers();
builder.Services.AddDbContext<ProveedorDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ProveedorConnection")));

builder.Services.AddDbContext<UsuarioDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("UsuarioConnection")));;
    builder.Services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();


    
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var configuration = builder.Configuration; 
        var jwtKey = configuration["Jwt:Key"]; 

        if (string.IsNullOrEmpty(jwtKey)) 
        {
            throw new Exception("Jwt:Key configuration is missing."); 
        }

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuration["Jwt:Issuer"], 
            ValidAudience = configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)) 
        };
    });
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();


// Configuración de FluentValidation (si planeas usarla más tarde)
//builder.Services.AddFluentValidationAutoValidation()
  //              .AddFluentValidationClientsideAdapters(); // Habilitar validación en el cliente

// Configuración de Swagger para la documentación de la API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "GrúasUCAB API",
        Version = "v1",
        Description = "API para gestionar órdenes, usuarios y proveedores en GrúasUCAB",
        Contact = new OpenApiContact
        {
            Name = "Soporte GrúasUCAB",
            Email = "soporte@gruasucab.com"
        }
    });
});

// Configuración de MediatR para CQRS (Comandos y Consultas)
builder.Services.AddMediatR(typeof(Program).Assembly);

// Configuración de AutoMapper para mapear entre objetos de dominio y DTOs
//builder.Services.AddAutoMapper(typeof(Program).Assembly);

// Configuración de CORS (si necesitas acceso desde otros dominios)
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Construcción de la aplicación
var app = builder.Build();

// Configuración del pipeline de middleware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "GrúasUCAB API v1");
    });
}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy"); // Habilitar CORS

//app.UseAuthorization();

app.MapControllers(); // Mapear los controladores

app.Run();*/

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
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateUsuarioCommandHandler).Assembly));




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
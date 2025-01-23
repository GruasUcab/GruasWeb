using GrúasUCAB.Infrastructure.Persistence.Proveedores;
using Microsoft.EntityFrameworkCore;
using GrúasUCAB.Core.Proveedores.Repositories;
using GrúasUCAB.Core.Keycloak;
using GrúasUCAB.Infrastructure.Auth;
using GrúasUCAB.Infrastructure.Handlers;
using MassTransit;
using MassTransit.RabbitMqTransport;
using GrúasUCAB.Infrastructure.Handlers.Proveedores;






var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Inyección de dependencias

builder.Services.AddScoped<IProveedorRepository, ProveedorRepository>();

builder.Services.AddDbContext<ProveedorDbContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("ProveedorConnection")));


builder.Services.AddScoped<IVehiculoRepository, VehiculoRepository>();
builder.Services.AddScoped<IConductorRepository, ConductorRepository>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IKeycloakService, KeycloakService>();

builder.Services.AddHttpClient<IKeycloakService, KeycloakService>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
    typeof(GetAllVehiculosQueryHandler).Assembly,  // Assembly del handler
    typeof(Program).Assembly                       // Assembly principal
));

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddHttpClient<IKeycloakService, KeycloakService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["Keycloak:BaseUrl"]?? "");
});

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "http://localhost:8080/realms/GruasUcab";
        options.RequireHttpsMetadata = false; // Solo para desarrollo. Habilitar HTTPS en producción.
        options.Audience = "account";
    });


    builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("rabbitmq://localhost", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
    });
});

builder.Services.AddAuthorization();
builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Debug);







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
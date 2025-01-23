var builder = WebApplication.CreateBuilder(args);

// Agregar YARP Reverse Proxy
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        // Registrar cada microservicio en Swagger UI
        c.SwaggerEndpoint("/usuarios/swagger/v1/swagger.json", "Microservicio Usuarios");
        c.SwaggerEndpoint("/proveedores/swagger/v1/swagger.json", "Microservicio Proveedores");
        c.SwaggerEndpoint("/ordenes/swagger/v1/swagger.json", "Microservicio Ordenes");
    });
}

app.UseRouting();


// Usar el middleware de Reverse Proxy
app.MapReverseProxy();

app.Run();

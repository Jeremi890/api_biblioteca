var builder = WebApplication.CreateBuilder(args);

// Configurar servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar canal de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Biblioteca API v1");
        c.RoutePrefix = string.Empty; // Cargar Swagger directamente en la raíz "/"
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();

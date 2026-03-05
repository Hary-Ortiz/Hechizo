var builder = WebApplication.CreateBuilder(args);

// Configuración de servicios y middleware para la aplicación web, incluyendo la adición de controladores, la configuración de Swagger para la documentación de la API y el registro del servicio de pagos para manejar la lógica de negocio relacionada con los pagos.

// Servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<PagosService.Services.PagoService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
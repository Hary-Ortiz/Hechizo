var builder = WebApplication.CreateBuilder(args);
// Configuración de servicios y middleware para la aplicación web, incluyendo la adición de controladores, la configuración de Swagger para la documentación de la API y el registro del servicio de carrito para manejar la lógica de negocio relacionada con el carrito de compras.

// Servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrar servicio
builder.Services.AddSingleton<CarritoService.Services.CarritoService>();

var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
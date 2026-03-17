using Delivery.Application.Interfaces.AICourier;
using Delivery.Application.Services;
using Delivery.Domain.Interfaces.ICourier;
using Delivery.Infrastructure.Repositories;
using Delivery.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ICourierRepository, InMemoryCourierRepository>();
builder.Services.AddScoped<ICourierService, CourierService>();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseHttpsRedirection();

app.Run();

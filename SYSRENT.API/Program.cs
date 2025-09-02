using SYSRENT.Application;
using SYSRENT.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

//REGLA CORS
var MiReglasCors = "ReglasCors";

builder.Services.AddCors(option =>
option.AddPolicy(name: MiReglasCors,
builder =>
{
    builder.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod();
}));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddServicesApplication();
builder.Services.AddServicesInfrastructure(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(x => x.SwaggerEndpoint("/openapi/v1.json", "SYSRENT"));
}

//habilitar uso de CORS
app.UseCors(MiReglasCors);

app.UseAuthorization();

app.MapControllers();

app.Run();

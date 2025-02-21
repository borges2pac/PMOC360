using PMOC360.API.Service.Interfaces;
using PMOC360.API.Service;
using System.Text.Json.Serialization;
using PMOC360.Data;
using PMOC360.Domain.Interfaces;
using PMOC360.API.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "PMOC360.API", Version = "v1" });
});

builder.Services.AddScoped<ISqlExecutor, SqlExecutor>();

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

builder.Services.AddScoped<IClienteService, ClienteService>();

builder.Services.AddControllers().AddJsonOptions(x =>
									x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PMOC360.API v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

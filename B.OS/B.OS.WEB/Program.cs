using B.OS.WEB.Context;
using B.OS.WEB.Models.Services.Interface;
using B.OS.WEB.Models.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using B.OS.WEB.Models.Repository.Interfaces;
using B.OS.WEB.Models.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<OrdemServicoContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("acesso")));

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IFaturaRepository, FaturaRepository>();
builder.Services.AddScoped<IFaturaItemRepository, FaturaItemRepository>();
builder.Services.AddScoped<IOrdemServicoRepository, OrdemServicoRepository>();

builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IFaturaService, FaturaService>();
builder.Services.AddScoped<IFaturaItemService, FaturaItemService>();
builder.Services.AddScoped<IOrdemServicoService, OrdemServicoService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

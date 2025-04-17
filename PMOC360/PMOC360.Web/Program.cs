using PMOC360.Web.Models.Data;
using PMOC360.Web.Models.Repository;
using PMOC360.Web.Models.Repository.Interfaces;
using PMOC360.Web.Models.Services;
using PMOC360.Web.Models.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IEquipamentoRepository, EquipamentoRepository>();
builder.Services.AddScoped<ITecnicoRepository, TecnicoRepository>();
builder.Services.AddScoped<IPmocModeloRepository, PmocModeloRepository>();
builder.Services.AddScoped<IPmocModeloItensRepository, PmocModeloItensRepository>();
builder.Services.AddScoped<IPmocPlanoRepository, PmocPlanoRepository>();

builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IEquipamentoService, EquipamentoService>();
builder.Services.AddScoped<ITecnicoService, TecnicoService>();
builder.Services.AddScoped<IPmocModeloService, PmocModeloService>();
builder.Services.AddScoped<IPmocModeloItensService, PmocModeloItensService>();
builder.Services.AddScoped<IPmocPlanoService, PmocPlanoService>();
builder.Services.AddScoped<IPmocOperacaoService, PmocOperacaoService>();

builder.Services.AddScoped<IDapperRepository, DapperRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

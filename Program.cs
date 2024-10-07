using Microsoft.EntityFrameworkCore;
using netchallenge.Infrastructure.Context;
using netchallenge.Infrastructure.Repositories;
using netchallenge.Application.Interfaces;
using netchallenge.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(); // Habilitar MVC

// Configuração do DbContext para usar MySQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("MySqlConnection"),
        new MySqlServerVersion(new Version(8, 0, 21))); 
});


// Injeção de dependências para os repositórios
builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();
builder.Services.AddScoped<ITratamentoRepository, TratamentoRepository>();
builder.Services.AddScoped<ISinistroRepository, SinistroRepository>();
builder.Services.AddScoped<IRecomendacaoRepository, RecomendacaoRepository>();

// Injeção de dependências para os serviços
builder.Services.AddScoped<PacienteService>();
builder.Services.AddScoped<TratamentoService>();
builder.Services.AddScoped<SinistroService>();
builder.Services.AddScoped<RecomendacaoService>();

// Adicionar suporte ao Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuração do pipeline de requisições HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Usar o Swagger e Swagger UI para documentação da API
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Mapear as rotas para controllers usando MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

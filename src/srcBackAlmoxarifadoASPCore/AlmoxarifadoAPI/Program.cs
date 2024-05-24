using AlmoxarifadoAPI;
using AlmoxarifadoInfrastructure.Data;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using AlmoxarifadoInfrastructure.Data.Repositories;
using AlmoxarifadoServices;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
AddDbContextFlexivel(builder);

//Carregando Classes de Repositories
builder.Services.AddScoped<GrupoService>();
builder.Services.AddScoped<IGrupoRepository,GrupoRepository>();
builder.Services.AddScoped<NotaFiscalService>();
builder.Services.AddScoped<INotaFiscalRepository, NotaFiscalRepository>();
builder.Services.AddScoped<ItensNotaService>();
builder.Services.AddScoped<IItensNotaRepository, ItensNotaRepository>();
builder.Services.AddScoped<RequisicaoService>();
builder.Services.AddScoped<IRequisicaoRepository, RequisicaoRepository>();
builder.Services.AddScoped<ItensRequerimentoService>();
builder.Services.AddScoped<IItensRequerimentoRepository, ItensRequerimentoRepository>();
builder.Services.AddScoped<EstoqueService>();
builder.Services.AddScoped<IEstoqueRepository, EstoqueRepository>();
builder.Services.AddScoped<ProdutoService>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void AddDbContextFlexivel(WebApplicationBuilder builder)
{
    List<string> connectionStrings = builder.Configuration.GetSection("ConnectionStrings").GetChildren()
                                          .Select(cs => cs.Key).ToList();

    foreach (string connectionString in connectionStrings)
    {
        try
        {
            var optionsBuilder = new DbContextOptionsBuilder<ContextSQL>();
            optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString(connectionString));

            using (var context = (ContextSQL)Activator.CreateInstance(typeof(ContextSQL), optionsBuilder.Options))
            {
                if (context.Database.CanConnect())
                {
                    builder.Services.AddDbContext<ContextSQL>(options =>
                        options.UseSqlServer(builder.Configuration.GetConnectionString(connectionString)));
                    Console.WriteLine($"Conexão bem sucedida usando {connectionString}");
                    return;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Falha ao conectar usando {connectionString}: {ex.Message}");
        }
    }

    throw new Exception("Não foi possível conectar ao banco de dados usando as strings de conexão fornecidas.");
}
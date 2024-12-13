var builder = WebApplication.CreateBuilder(args);

// Configurar serviços
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrar dependências (exemplo: repositórios e MediatR)
builder.Services.AddScoped<LojaPedidos.Infrastructure.Repositories.IPedidoRepository, LojaPedidos.Infrastructure.Repositories.PedidoRepository>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(LojaPedidos.Application.Commands.IniciarPedidoCommand).Assembly));

var app = builder.Build();

// Configurar o pipeline de middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

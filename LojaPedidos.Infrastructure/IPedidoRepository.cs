using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaPedidos.Domain.Entities;

namespace LojaPedidos.Infrastructure.Repositories
{
    public interface IPedidoRepository
    {
        Task AdicionarAsync(Pedido pedido);
        Task<Pedido?> ObterPorIdAsync(Guid id);
        Task<List<Pedido>> ListarTodosAsync();
        Task SalvarAsync();
    }

    public class PedidoRepository : IPedidoRepository
    {
        private readonly List<Pedido> _pedidos = new();

        public Task AdicionarAsync(Pedido pedido)
        {
            _pedidos.Add(pedido);
            return Task.CompletedTask;
        }

        public Task<Pedido?> ObterPorIdAsync(Guid id)
        {
            return Task.FromResult(_pedidos.FirstOrDefault(p => p.Id == id));
        }

        public Task<List<Pedido>> ListarTodosAsync()
        {
            return Task.FromResult(_pedidos);
        }

        public Task SalvarAsync()
        {
            // Simular persistência
            return Task.CompletedTask;
        }
    }
}

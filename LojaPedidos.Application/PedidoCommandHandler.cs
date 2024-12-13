using LojaPedidos.Application.Commands;
using LojaPedidos.Domain.Entities;
using LojaPedidos.Infrastructure.Repositories;
using MediatR;

namespace LojaPedidos.Application.Handlers
{
    public class PedidoCommandHandler :
            IRequestHandler<IniciarPedidoCommand, Guid>,
            IRequestHandler<AdicionarProdutoCommand, Unit>,
            IRequestHandler<RemoverProdutoCommand, Unit>,
            IRequestHandler<FecharPedidoCommand, Unit>
    {
        private readonly IPedidoRepository _repository;

        public PedidoCommandHandler(IPedidoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(IniciarPedidoCommand request, CancellationToken cancellationToken)
        {
            var pedido = new Pedido();
            await _repository.AdicionarAsync(pedido);
            await _repository.SalvarAsync();
            return pedido.Id;
        }

        public async Task<Unit> Handle(AdicionarProdutoCommand request, CancellationToken cancellationToken)
        {
            var pedido = await _repository.ObterPorIdAsync(request.PedidoId)
                        ?? throw new KeyNotFoundException("Pedido não encontrado.");

            pedido.AdicionarProduto(new Produto(request.Nome, request.Preco));
            await _repository.SalvarAsync();
            return Unit.Value;
        }

        public async Task<Unit> Handle(RemoverProdutoCommand request, CancellationToken cancellationToken)
        {
            var pedido = await _repository.ObterPorIdAsync(request.PedidoId)
                        ?? throw new KeyNotFoundException("Pedido não encontrado.");

            pedido.RemoverProduto(request.ProdutoId);
            await _repository.SalvarAsync();
            return Unit.Value;
        }

        public async Task<Unit> Handle(FecharPedidoCommand request, CancellationToken cancellationToken)
        {
            var pedido = await _repository.ObterPorIdAsync(request.PedidoId)
                        ?? throw new KeyNotFoundException("Pedido não encontrado.");

            pedido.FecharPedido();
            await _repository.SalvarAsync();
            return Unit.Value;
        }
    }
}

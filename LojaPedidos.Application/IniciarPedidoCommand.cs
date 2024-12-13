using MediatR;

namespace LojaPedidos.Application.Commands
{
    public class IniciarPedidoCommand : IRequest<Guid>
    {
    }

    public class AdicionarProdutoCommand : IRequest<Unit>
    {
        public Guid PedidoId { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }

    public class RemoverProdutoCommand : IRequest<Unit>
    {
        public Guid PedidoId { get; set; }
        public Guid ProdutoId { get; set; }
    }

    public class FecharPedidoCommand : IRequest<Unit>
    {
        public Guid PedidoId { get; set; }
    }
}

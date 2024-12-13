using LojaPedidos.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LojaPedidos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PedidosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> IniciarPedido()
        {
            var id = await _mediator.Send(new IniciarPedidoCommand());
            return Ok(id);
        }

        [HttpPost("{id}/produtos")]
        public async Task<IActionResult> AdicionarProduto(Guid id, [FromBody] AdicionarProdutoCommand command)
        {
            command.PedidoId = id; // Convert Guid to string
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}/produtos/{produtoId}")]
        public async Task<IActionResult> RemoverProduto(Guid id, Guid produtoId)
        {
            await _mediator.Send(new RemoverProdutoCommand { PedidoId = id, ProdutoId = produtoId });
            return NoContent();
        }

        [HttpPost("{id}/fechar")]
        public async Task<IActionResult> FecharPedido(Guid id)
        {
            await _mediator.Send(new FecharPedidoCommand { PedidoId = id });
            return NoContent();
        }
    }
}

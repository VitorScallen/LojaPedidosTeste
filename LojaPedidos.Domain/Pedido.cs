using System;
using System.Collections.Generic;
using System.Linq;

namespace LojaPedidos.Domain.Entities
{
    public class Pedido
    {
        public Guid Id { get; private set; }
        public bool Fechado { get; private set; }
        private readonly List<Produto> _produtos = new();

        public IReadOnlyCollection<Produto> Produtos => _produtos.AsReadOnly();

        public Pedido()
        {
            Id = Guid.NewGuid();
        }

        public void AdicionarProduto(Produto produto)
        {
            if (Fechado)
                throw new InvalidOperationException("Não é possível adicionar produtos a um pedido fechado.");

            _produtos.Add(produto);
        }

        public void RemoverProduto(Guid produtoId)
        {
            if (Fechado)
                throw new InvalidOperationException("Não é possível remover produtos de um pedido fechado.");

            var produto = _produtos.FirstOrDefault(p => p.Id == produtoId);
            if (produto == null)
                throw new KeyNotFoundException("Produto não encontrado.");

            _produtos.Remove(produto);
        }

        public void FecharPedido()
        {
            if (!_produtos.Any())
                throw new InvalidOperationException("O pedido deve conter pelo menos um produto para ser fechado.");

            Fechado = true;
        }
    }
}
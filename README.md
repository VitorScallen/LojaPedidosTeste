# LojaPedidos Application

Este projeto implementa uma aplicação de gerenciamento de pedidos utilizando o padrão CQRS (Command Query Responsibility Segregation) com MediatR. O código foi desenvolvido em C# e utiliza práticas de arquitetura limpa para separação de responsabilidades.

## Tecnologias Utilizadas
- **.NET**: Plataforma de desenvolvimento.
- **C#**: Linguagem de programação.
- **MediatR**: Biblioteca para implementar CQRS e mediadores.

## Estrutura do Projeto
O projeto é dividido em três camadas principais:

1. **Application**: Contém comandos, handlers e lógica de aplicação.
2. **Domain**: Define as entidades e regras de negócio.
3. **Infrastructure**: Contém o repositório para acesso a dados (simulado com listas).

## Comandos Implementados

1. **IniciarPedidoCommand**
   - Responsável por criar um novo pedido.
   - Retorna o `Guid` do pedido criado.

2. **AdicionarProdutoCommand**
   - Adiciona um produto a um pedido existente.

3. **RemoverProdutoCommand**
   - Remove um produto de um pedido existente.

4. **FecharPedidoCommand**
   - Finaliza um pedido, tornando-o imutável.

## Como Rodar o Projeto

### 1. Clonar o Repositório
```bash
git clone https://github.com/seu-usuario/LojaPedidos.git
cd LojaPedidos
```

### 2. Configurar o Ambiente
Certifique-se de que você tenha o .NET SDK instalado. Para verificar, execute:
```bash
dotnet --version
```
Se não estiver instalado, baixe a versão mais recente em [dotnet.microsoft.com](https://dotnet.microsoft.com/).

### 3. Restaurar Dependências
Na raiz do projeto, execute:
```bash
dotnet restore
```

### 4. Rodar o Projeto
Inicie o projeto executando o comando:
```bash
dotnet run
```

### 5. Testar os Comandos
Utilize ferramentas como **Postman** ou **curl** para enviar comandos para os endpoints da aplicação (caso tenha sido configurada uma API) ou simule execuções chamando diretamente os handlers no código.

## Exemplo de Uso
### Criar um Pedido
```csharp
var command = new IniciarPedidoCommand();
var pedidoId = await _mediator.Send(command);
```

### Adicionar um Produto
```csharp
var command = new AdicionarProdutoCommand
{
    PedidoId = pedidoId,
    Nome = "Produto A",
    Preco = 100.0m
};
await _mediator.Send(command);
```

### Remover um Produto
```csharp
var command = new RemoverProdutoCommand
{
    PedidoId = pedidoId,
    ProdutoId = produtoId
};
await _mediator.Send(command);
```

### Fechar um Pedido
```csharp
var command = new FecharPedidoCommand
{
    PedidoId = pedidoId
};
await _mediator.Send(command);
```

## Estrutura de Código

### PedidoCommandHandler
Responsável por implementar os handlers para os comandos relacionados a pedidos. Os comandos estão localizados na pasta `Application/Commands`.

### Pedido e Produto
As entidades estão localizadas na pasta `Domain/Entities`. Elas contêm as regras de negócio relacionadas a pedidos e produtos.

### Repositório de Dados
O repositório está localizado na pasta `Infrastructure/Repositories`. Atualmente, utiliza listas em memória para simular o armazenamento de dados.

## Melhorias Futuras
- Implementar persistência em banco de dados.
- Adicionar validação mais robusta nos comandos.
- Criar uma API para expor os endpoints da aplicação.

## Contribuição
Sinta-se à vontade para contribuir com melhorias ou novos recursos. Para contribuir:
1. Faça um fork do repositório.
2. Crie uma branch para sua feature:
   ```bash
   git checkout -b feature/nova-feature
   ```
3. Envie suas modificações:
   ```bash
   git push origin feature/nova-feature
   ```
4. Abra um Pull Request.

## Licença
Este projeto está licenciado sob a Licença MIT. Consulte o arquivo `LICENSE` para mais detalhes.


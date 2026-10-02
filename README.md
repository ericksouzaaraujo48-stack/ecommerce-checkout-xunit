# EcommerceCheckout

Módulo de checkout de e-commerce em C#/.NET com regras de negócio para **código de rastreio**, **programa de fidelidade** e **frete grátis**, cobertas por testes automatizados com xUnit.

## Estrutura do projeto

```
EcommerceCheckout/
├── EcommerceCheckout/             # Projeto principal (regras de negócio)
│   └── PedidoService.cs
└── EcommerceCheckout.Tests/       # Projeto de testes (xUnit)
    └── PedidoServiceTests.cs
```

## Regras de negócio

### 1. `string GerarCodigoRastreio(string regiao, int numeroPedido)`

Retorna a região em **maiúsculas**, seguida de hífen e do número do pedido **preenchido com zeros à esquerda (4 dígitos)**.

| Entrada            | Saída            |
|--------------------|------------------|
| `"sudeste"`, `42`  | `"SUDESTE-0042"` |

### 2. `int CalcularPontosFidelidade(int valorTotal)`

A cada **R$ 10** em compras, o cliente ganha **2 pontos** de fidelidade.

| Entrada | Cálculo                 | Saída |
|---------|-------------------------|-------|
| `150`   | 150 / 10 = 15 → 15 × 2  | `30`  |

### 3. `bool TemDireitoAFreteGratis(int valorTotal, bool eClienteVIP)`

O frete é grátis se o valor total for **maior ou igual a R$ 200** **OU** se o comprador for **cliente VIP**.

| valorTotal | eClienteVIP | Saída   |
|------------|-------------|---------|
| `150`      | `true`      | `true`  |
| `150`      | `false`     | `false` |

## Testes

Os testes ficam no projeto `EcommerceCheckout.Tests`, na classe `PedidoServiceTests`, e usam o atributo `[Fact]` do xUnit.

| Teste                                   | Asserção                                  | Cenário                                |
|-----------------------------------------|-------------------------------------------|----------------------------------------|
| Geração do código de rastreio           | `Assert.Equal("SUDESTE-0042", resultado)` | Região `"sudeste"`, pedido `42`        |
| Cálculo de pontos de fidelidade         | `Assert.Equal(30, resultado)`             | Compra de R$ 150                       |
| Frete grátis para VIP abaixo de R$ 200  | `Assert.True(...)`                        | Cliente VIP, valor abaixo de R$ 200    |
| Sem frete grátis para não-VIP abaixo de R$ 200 | `Assert.False(...)`                | Cliente não-VIP, valor abaixo de R$ 200 |

## Como executar

### Pré-requisitos

- [.NET SDK](https://dotnet.microsoft.com/download) instalado (verifique com `dotnet --version`)

### Rodando a suíte de testes

Na raiz da solução, execute:

```bash
dotnet test
```

Saída esperada: todos os testes aprovados (`Passed!`).

## Tecnologias

- C# / .NET
- xUnit

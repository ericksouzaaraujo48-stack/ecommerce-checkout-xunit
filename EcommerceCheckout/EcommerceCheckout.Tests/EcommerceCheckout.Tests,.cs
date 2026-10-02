using EcommerceCheckout.App;
using Xunit;

namespace EcommerceCheckout.Tests
{
    public class PedidoServiceTests
    {
        private readonly PedidoService _pedidoService = new PedidoService();

        // Teste 1: Gerar código de rastreio
        [Fact]
        public void GerarCodigoRastreio_DeveGerarCodigoCorreto()
        {
            // Arrange
            string regiao = "sudeste";
            int numeroPedido = 42;

            // Act
            string resultado = _pedidoService.GerarCodigoRastreio(regiao, numeroPedido);

            // Assert
            Assert.Equal("SUDESTE-0042", resultado);
        }

        // Teste 2: Calcular pontos de fidelidade
        [Fact]
        public void CalcularPontosFidelidade_DeveCalcularCorretamente()
        {
            // Arrange
            int valorTotal = 150;

            // Act
            int resultado = _pedidoService.CalcularPontosFidelidade(valorTotal);

            // Assert
            Assert.Equal(30, resultado);
        }

        // Teste 3: Cliente VIP abaixo de R$ 200 tem frete grátis
        [Fact]
        public void TemDireitoAFreteGratis_ClienteVIPAbaixoDe200_DeveRetornarTrue()
        {
            // Arrange
            int valorTotal = 150;
            bool eClienteVIP = true;

            // Act
            bool resultado = _pedidoService.TemDireitoAFreteGratis(
                valorTotal,
                eClienteVIP
            );

            // Assert
            Assert.True(resultado);
        }

        // Teste 4: Cliente não VIP abaixo de R$ 200 não tem frete grátis
        [Fact]
        public void TemDireitoAFreteGratis_ClienteNaoVIPAbaixoDe200_DeveRetornarFalse()
        {
            // Arrange
            int valorTotal = 150;
            bool eClienteVIP = false;

            // Act
            bool resultado = _pedidoService.TemDireitoAFreteGratis(
                valorTotal,
                eClienteVIP
            );

            // Assert
            Assert.False(resultado);
        }
    }
}
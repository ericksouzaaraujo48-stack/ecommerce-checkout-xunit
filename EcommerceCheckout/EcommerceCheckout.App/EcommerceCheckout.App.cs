namespace EcommerceCheckout.App
{
    public class PedidoService
    {
        // 1. Gera o código de rastreio
        public string GerarCodigoRastreio(string regiao, int numeroPedido)
        {
            return $"{regiao.ToUpper()}-{numeroPedido:D4}";
        }

        // 2. Calcula os pontos de fidelidade
        public int CalcularPontosFidelidade(int valorTotal)
        {
            return (valorTotal / 10) * 2;
        }

        // 3. Verifica se o cliente tem direito a frete grátis
        public bool TemDireitoAFreteGratis(int valorTotal, bool eClienteVIP)
        {
            return valorTotal >= 200 || eClienteVIP;
        }
    }
}
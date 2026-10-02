using System;

namespace EcommerceCheckout.App
{
    public class PedidoService
    {
        // 1. Retorno string — GerarCodigoRastreio
        public string GerarCodigoRastreio(string regiao, int numeroPedido)
        {
            return $"{regiao.ToUpper()}-{numeroPedido:D4}";
        }

        // 2. Retorno int — CalcularPontosFidelidade
        public int CalcularPontosFidelidade(int valorTotal) 
        {
            return (valorTotal / 10) * 2;
        }

        // 3. Retorno bool — TemDireitoAFreteGratis
        public bool TemDireitoAFreteGratis(int valorTotal, bool eClienteVIP)
        {
            return valorTotal >= 200 || eClienteVIP; 
        }
    }
}

using System;
using Xunit;
using EcommerceCheckout.App;

namespace EcommerceCheckout.Tests
{
    public class PedidoServiceTests
    {
        [Fact]
        public void GerarCodigoRastreio()
        {
            var service = new PedidoService();
            string resultado = service.GerarCodigoRastreio("sudeste", 42);
            Assert.Equal("SUDESTE-0042", resultado);
        }

        [Fact]
        public void CalcularPontosFidelidade()
        {
            var service = new PedidoService();
            int resultado = service.CalcularPontosFidelidade(150);
            Assert.Equal(30, resultado); 
        }
       
        [Fact]
        public void TemDireitoAFreteGratis_VIP_AbaixoDe200()
        {
            var service = new PedidoService();
            bool resultado = service.TemDireitoAFreteGratis(150, eClienteVIP: true);
            Assert.True(resultado); 
        }

        [Fact]
        public void TemDireitoAFreteGratis_NaoVIP_AbaixoDe200()
        {
            var service = new PedidoService();
            bool resultado = service.TemDireitoAFreteGratis(150, eClienteVIP: false);
            Assert.False(resultado);
        }
    }
}

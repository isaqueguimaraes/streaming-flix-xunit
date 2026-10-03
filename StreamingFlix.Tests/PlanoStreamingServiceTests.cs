using StreamingFlix.App;

namespace StreamingFlix.Tests
{
    public class PlanoStreamingServiceTests
    {
        [Theory]
        [InlineData(1, "BÁSICO")]
        [InlineData(2, "PADRÃO")]
        [InlineData(4, "PREMIUM")]
        public void ObterClassificacaoPorQualidade_DeveRetornarClassificacaoCorreta(
            int telasSimultaneas, string resultadoEsperado)
        {
            PlanoStreamingService service = new PlanoStreamingService();

            string resultado = service.ObterClassificacaoPorQualidade(telasSimultaneas);

            Assert.Equal(resultadoEsperado, resultado);
        }

        [Theory]
        [InlineData(50, 1, 50)]
        [InlineData(50, 6, 45)]
        [InlineData(50, 12, 40)]
        public void CalcularMensalidadeComDesconto_DeveRetornarValorCorreto(
            int valorBase, int mesesContratados, int resultadoEsperado)
        {
            PlanoStreamingService service = new PlanoStreamingService();

            int resultado = service.CalcularMensalidadeComDesconto(
                valorBase, mesesContratados);

            Assert.Equal(resultadoEsperado, resultado);
        }

        [Theory]
        [InlineData(20, false, true)]
        [InlineData(20, true, false)]
        [InlineData(16, false, false)]
        public void PodeAcessarConteudoAdulto_DeveRetornarResultadoCorreto(
            int idade, bool controleParentalAtivo, bool resultadoEsperado)
        {
            PlanoStreamingService service = new PlanoStreamingService();

            bool resultado = service.PodeAcessarConteudoAdulto(
                idade, controleParentalAtivo);

            Assert.Equal(resultadoEsperado, resultado);
        }
    }
}
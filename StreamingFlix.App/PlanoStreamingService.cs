namespace StreamingFlix.App
{
    public class PlanoStreamingService
    {
        public string ObterClassificacaoPorQualidade(int telasSimultaneas)
        {
            if (telasSimultaneas == 1)
            {
                return "BÁSICO";
            }
            else if (telasSimultaneas == 2)
            {
                return "PADRÃO";
            }
            else if (telasSimultaneas >= 4)
            {
                return "PREMIUM";
            }

            return "PLANO INVÁLIDO";
        }

        public int CalcularMensalidadeComDesconto(int valorBase, int mesesContratados)
        {
            if (mesesContratados >= 12)
            {
                return valorBase - (valorBase * 20 / 100);
            }
            else if (mesesContratados >= 6)
            {
                return valorBase - (valorBase * 10 / 100);
            }

            return valorBase;
        }

        public bool PodeAcessarConteudoAdulto(int idade, bool controleParentalAtivo)
        {
            if (idade >= 18 && controleParentalAtivo == false)
            {
                return true;
            }

            return false;
        }
    }
}
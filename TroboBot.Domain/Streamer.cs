using OpenQA.Selenium.Chrome;

namespace TroboBot.Domain
{
    public abstract class Streamer
    {
        public bool Ativo { get; set; }
        public CancellationTokenSource CancellationToken = new();
        public abstract string? LinkUrl { get; }
        private PeriodicTimer? timer;

        public async Task Inicializar(ChromeDriver chromeDriver, string login, string senha)
        {
            CancellationToken.Dispose();
            CancellationToken = new CancellationTokenSource();

            Ativo = true;

            var trovoNavigation = new TrovoNavigation(chromeDriver);
                
            trovoNavigation.Navegar(this);
            trovoNavigation.AbrirTelaDeLogin();
            trovoNavigation.Logar(login, senha);

            CancellationToken.Token.ThrowIfCancellationRequested();

            Random random = new();
            double minutosAdiconais = random.NextDouble() * 2;

            var tempo = TimeSpan.FromMinutes(15 * minutosAdiconais);

            timer = new PeriodicTimer(tempo);

            Lurk lurks = new();

            while (await timer.WaitForNextTickAsync())
            {
                if(!Ativo)
                {
                    timer.Dispose();
                    chromeDriver.Close();
                    chromeDriver.Dispose();
                }

                lurks.Enviar(chromeDriver);
            }
        }
    }
}

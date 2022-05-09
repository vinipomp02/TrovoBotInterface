
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Keys = OpenQA.Selenium.Keys;

namespace TrovoBotInterface
{
    public partial class TrovoBot : Form
    {
        /// <summary>
        /// Variavel que Monitora Atividade do Bot do Ishi
        /// </summary>
        private static bool _botIshiActive { get; set; } = false;
        /// <summary>
        /// Variavel que Monitora Atividade do Bot da Bia
        /// </summary>
        private static bool _botBiaActive { get; set; } = false;
        /// <summary>
        /// Token de Cancelamento do Bot do Ishi
        /// </summary>
        private static CancellationTokenSource _cancellationTokenIshi = new CancellationTokenSource();
        /// <summary>
        /// Token de Cancelamento do Bot da Bia
        /// </summary>
        private static CancellationTokenSource _cancellationTokenBia = new CancellationTokenSource();
        /// <summary>
        /// Int que controla qual o Emote a Ser Enviado(1 - :Lurk 2 - :purpleheart)
        /// </summary>
        private static int _tipoLurk { get; set; } = 1;


        /// <summary>
        /// Inicializa os Componentes do bot
        /// </summary>
        public TrovoBot()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Configura o Driver para execução
        /// </summary>
        /// <returns>Retorna o driver configurado</returns>
        private ChromeDriver configuraDriver()
        {
            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            chromeDriverService.HideCommandPromptWindow = true;

            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("mute-audio");

            return new ChromeDriver(chromeDriverService, chromeOptions);
        }

        /// <summary>
        /// Conecta a página da Stream e permite o envio de Mensagens
        /// </summary>
        /// <param name="chromeDriver">driver que está sendo executado</param>
        /// <param name="login">login do usuário Trovo</param>
        /// <param name="senha">senha do usuário Trovo</param>
        /// <param name="streamer">indentificação de qual bot executar</param>
        /// <param name="cancellationToken">Token de Cancelamento</param>
        public static async Task conectaStreamAsync(ChromeDriver chromeDriver,string login, string senha,string streamer, CancellationTokenSource cancellationToken)
        {
            navegaUrl(chromeDriver,streamer);

            acessaLogin(chromeDriver);

            logar(chromeDriver,login, senha);

        }
        /// <summary>
        /// Acessa url com base no Streamer
        /// </summary>
        /// <param name="chromeDriver">driver que está sendo executado</param>
        /// <param name="streamer">Streamer que vai solicitar a Url</param>
        private static async void navegaUrl(ChromeDriver chromeDriver,string streamer)
        { 
            if (streamer == "ishi")
            {
                chromeDriver.Navigate().GoToUrl("https://trovo.live/Ishiro_Oninawa");
            }
            else
            {
                chromeDriver.Navigate().GoToUrl("https://trovo.live/FalaComBia");
            }

            chromeDriver.Manage().Window.Maximize();
        }
        /// <summary>
        /// Faz o Login na Trovo
        /// </summary>
        /// <param name="chromeDriver">driver que está sendo executado</param>
        /// <param name="login">login do usuário Trovo</param>
        /// <param name="senha">senha do usuário Trovo</param>
        private static async void logar(ChromeDriver chromeDriver, string login, string senha)
        {
            Thread.Sleep(2000);

            By userName = By.XPath("/html/body/div[4]/div/div[2]/div[3]/div[1]/div[1]/div/input");
            By passWord = By.XPath("/html/body/div[4]/div/div[2]/div[3]/div[1]/div[3]/div/input");
            By loginButton = By.XPath("/html/body/div[4]/div/div[2]/div[3]/div[1]/button");

            chromeDriver.FindElement(userName).SendKeys(login);
            chromeDriver.FindElement(passWord).SendKeys(senha);
            chromeDriver.FindElement(loginButton).Click();
        }
        /// <summary>
        /// Acessa a Tela de login
        /// </summary>
        /// <param name="chromeDriver">driver que está sendo executado</param>
        private static async void acessaLogin(ChromeDriver chromeDriver)
        {
            Thread.Sleep(6000);
            By iconeLogin = By.XPath("//*[@id='__layout']/div/nav/div[3]/div[4]/div/div/img");
            chromeDriver.FindElement(iconeLogin).Click();

            By botaoLogin = By.XPath("//*[@id='__layout']/div/nav/div[3]/div[4]/div[2]/div/ul/li[8]/button");
            chromeDriver.FindElement(botaoLogin).Click();
        }
        /// <summary>
        /// Envia o Emote no Chat
        /// </summary>
        /// <param name="chromeDriver">driver que está sendo executado</param>
        static async void enviaLurk(ChromeDriver chromeDriver)
        {
            habilitarLurk(chromeDriver);

            var isLiveOn = verificarLiveOn(chromeDriver);

            if (isLiveOn)
            {
                By chat = By.XPath("//*[@id='__layout']/div/div/div[2]/div/section/div[3]/div/section/div[1]/div[1]/div[1]");
                By lurk = By.XPath("//*[@id='__layout']/div/div/div[2]/div/section/div[3]/div/section/div[2]/div[1]/div[1]");

                Thread.Sleep(4000);
                if (_tipoLurk == 1)
                {
                    chromeDriver.FindElement(chat).SendKeys(":lurk");
                    _tipoLurk++;
                }
                else
                {
                    chromeDriver.FindElement(chat).SendKeys(":purpleheart");
                    _tipoLurk--;
                }
                
                chromeDriver.FindElement(lurk).SendKeys(Keys.Enter);
                chromeDriver.FindElement(lurk).SendKeys(Keys.Enter);
            }
        }
        /// <summary>
        /// Habilita a Transmissão e o Chat
        /// </summary>
        /// <param name="chromeDriver">driver que está sendo executado</param>
        static async void habilitarLurk(ChromeDriver chromeDriver)
        {
            Thread.Sleep(6000);

            By botaoChat = By.XPath("//*[@id='__layout']/div/div/div[2]/div/section/div[3]/div/section/section/div/button");
            if (isElementPresent(chromeDriver,botaoChat))
            {
                chromeDriver.FindElement(botaoChat).Click();
            }

            By botaoAdulto = By.XPath("/html/body/div[1]/div/div/div/div[2]/div/div/div[1]/div[1]/div[1]/div/div[2]/div[3]/section/div/button[2]");
            if (isElementPresent(chromeDriver, botaoAdulto))
            {
                chromeDriver.FindElement(botaoAdulto).Click();
            }

        }
        /// <summary>
        /// Verifica se um elemento existe dentro da página
        /// </summary>
        /// <param name="chromeDriver">driver que está sendo executado</param>
        /// <param name="by">Elemento a ser procurado</param>
        /// <returns>Retorna se o elemento existe ou não na página</returns>
        static bool isElementPresent(ChromeDriver chromeDriver, By by)
        {
            try
            {
                chromeDriver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException e)
            {
                return false;
            }
        }
        /// <summary>
        /// Verifica se o streamer está ao vivo
        /// </summary>
        /// <param name="chromeDriver">driver que está sendo executado</param>
        /// <returns>Retorna se o Streamer está ou não ao vivo</returns>
        private static bool verificarLiveOn(ChromeDriver chromeDriver)
        {
            By tagLive = By.XPath("//*[@id='live-fullscreen']/div[3]/div[3]/section/div[1]/span");
            if (isElementPresent(chromeDriver, tagLive))
            {
                return chromeDriver.FindElement(tagLive).Text.Equals("LIVE");
            }

            return false;
        }
        /// <summary>
        /// Inicia o Bot do Ishi
        /// </summary>
        private async void btnStartIshi_Click(object sender, EventArgs e)
        {
            lblActiveIshi.Text = "Ativo";
            lblActiveIshi.ForeColor = Color.White;

            ChromeDriver chromeDriver = configuraDriver();
               

            _cancellationTokenIshi.Dispose();
            _cancellationTokenIshi = new CancellationTokenSource();

            try
            {
                var login = txtLogin.Text;
                var senha = txtSenha.Text;

                _botIshiActive = true;

                conectaStreamAsync(chromeDriver, login, senha, "ishi", _cancellationTokenIshi);

                _cancellationTokenIshi.Token.ThrowIfCancellationRequested();

                while (_botIshiActive)
                {
                    enviaLurk(chromeDriver);

                    Random random = new Random();
                    double minutosAdiconais = random.NextDouble() * 2;

                    await Task.Delay((int)TimeSpan.FromMinutes(15 * minutosAdiconais).TotalMilliseconds, _cancellationTokenIshi.Token);

                }

            }
            catch (Exception ex)
            {
                lblActiveIshi.Text = "Inativo";
                lblActiveIshi.ForeColor = Color.Red;

                chromeDriver.Quit();
            }
        }
        /// <summary>
        /// Interrompe o Bot do Ishi
        /// </summary>
        private async void btnStopIshi_Click(object sender, EventArgs e)
        {

            _botIshiActive = false;
            _cancellationTokenIshi.Cancel();
        }
        /// <summary>
        /// Inicia o Bot da Bia
        /// </summary>
        private async void btnStartBia_Click(object sender, EventArgs e)
        {
            lblActiveBia.Text = "Ativo";
            lblActiveBia.ForeColor = Color.White;

            ChromeDriver chromeDriver = configuraDriver();

            _cancellationTokenBia.Dispose();
            _cancellationTokenBia = new CancellationTokenSource();

            try
            {
                var login = txtLogin.Text;
                var senha = txtSenha.Text;

                _botBiaActive = true;

                conectaStreamAsync(chromeDriver, login, senha, "Bia", _cancellationTokenBia);

                _cancellationTokenBia.Token.ThrowIfCancellationRequested();

                while (_botBiaActive)
                {
                    enviaLurk(chromeDriver);

                    Random random = new Random();
                    double minutosAdiconais = random.NextDouble() * 2;

                    await Task.Delay((int)TimeSpan.FromMinutes(15*minutosAdiconais).TotalMilliseconds, _cancellationTokenBia.Token);

                }

            }
            catch (Exception ex)
            {
                lblActiveBia.Text = "Inativo";
                lblActiveBia.ForeColor = Color.Red;

                chromeDriver.Quit();
            }
        }
        /// <summary>
        /// Interrompe o Bot da Bia
        /// </summary>
        private void btnStopBia_Click(object sender, EventArgs e)
        {
            _botBiaActive = false;
            _cancellationTokenBia.Cancel();
        }
    }
}
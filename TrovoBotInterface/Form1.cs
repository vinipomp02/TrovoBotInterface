using OpenQA.Selenium.Chrome;
using TroboBot.Domain;
using TroboBot.Domain.Enum;

namespace TrovoBotInterface
{
    public partial class TrovoBot : Form
    {
        /// <summary>
        /// Int que controla qual o Emote a Ser Enviado(1 - :Lurk 2 - :purpleheart)
        /// </summary>
        private static int _tipoLurk { get; set; } = 1;

        private DriverConfiguration driverConfiguration;
        private StreamerFactory streamerFactory;
        private Streamer streamer;

        public TrovoBot()
        {
            InitializeComponent();
            streamerFactory = new StreamerFactory();
            driverConfiguration = new DriverConfiguration();
        }

        public async Task Inicializar(StreamerEnum chaveStreamer, Label labelStreamer)
        {
            labelStreamer.Text = "Ativo";
            labelStreamer.ForeColor = Color.White;

            ChromeDriver chromeDriver = driverConfiguration.Obter();

            var login = txtLogin.Text;
            var senha = txtSenha.Text;

            try
            {
                streamer = streamerFactory?.Obter(chaveStreamer);

                if (streamer == null)
                    throw new Exception("Não foi encontrado streamer com as configurações.");
                
                await streamer.Inicializar(chromeDriver, login, senha);
            }
            catch
            {
                labelStreamer.Text = "Inativo";
                labelStreamer.ForeColor = Color.Red;

                chromeDriver.Quit();
                chromeDriver.Dispose();
            }
        }

        private async void btnStartIshi_Click(object sender, EventArgs e) => await Inicializar(StreamerEnum.Ishi, lblActiveIshi);
        
        private void Parar(Label labelStreamer)
        {
            labelStreamer.Text = "Inativo";
            labelStreamer.ForeColor = Color.Red;
            streamer.Ativo = false;
            streamer.CancellationToken.Cancel();
        }

        private async void btnStartBia_Click(object sender, EventArgs e) =>  await Inicializar(StreamerEnum.Bia, lblActiveBia);

        private void btnStopIshi_Click(object sender, EventArgs e) => Parar(lblActiveIshi);

        private void btnStopBia_Click(object sender, EventArgs e) => Parar(lblActiveBia);
        
    }
}
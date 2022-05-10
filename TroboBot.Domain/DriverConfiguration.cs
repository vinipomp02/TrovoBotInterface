using OpenQA.Selenium.Chrome;

namespace TroboBot.Domain
{
    public  class DriverConfiguration
    {
        public ChromeDriver Obter()
        {
            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            chromeDriverService.HideCommandPromptWindow = true;

            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("mute-audio");

            return new ChromeDriver(chromeDriverService, chromeOptions);
        }
    }
}

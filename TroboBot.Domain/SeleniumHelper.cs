using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TroboBot.Domain
{
    internal class SeleniumHelper
    {
        private ChromeDriver chromeDriver { get; }

        public SeleniumHelper(ChromeDriver chromeDriver)
        {
            this.chromeDriver = chromeDriver;
        }
        public void Habilitar(ChromeDriver chromeDriver)
        {
            //Isso precisa melhorar. Thread.Sleep significa que o código não está executando de forma correta. Precisa ter algo para esperar de fato acontecer. 
            Thread.Sleep(6000);

            By botaoChat = By.XPath("//*[@id='__layout']/div/div/div[2]/div/section/div[3]/div/section/section/div/button");
            By botaoAdulto = By.XPath("/html/body/div[1]/div/div/div/div[2]/div/div/div[1]/div[1]/div[1]/div/div[2]/div[3]/section/div/button[2]");

            if (ElementoEstaPresente(chromeDriver, botaoChat))
                chromeDriver.FindElement(botaoChat).Click();

            if (ElementoEstaPresente(chromeDriver, botaoAdulto))
                chromeDriver.FindElement(botaoAdulto).Click();
        }

        public bool ElementoEstaPresente(ChromeDriver chromeDriver, By by)
        {
            try
            {
                return chromeDriver.FindElement(by) != null;
            }
            catch
            {
                return false;
            }
        }

        public bool LiveEstaOn(ChromeDriver chromeDriver)
        {
            By tagLive = By.XPath("//*[@id='live-fullscreen']/div[3]/div[3]/section/div[1]/span");
            if (ElementoEstaPresente(chromeDriver, tagLive))
                return chromeDriver.FindElement(tagLive).Text.Equals("LIVE");
            

            return false;
        }
    }
}

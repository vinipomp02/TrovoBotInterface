using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TroboBot.Domain
{
    internal class Lurk
    {
        private List<string> lurks;
        private string selecionado;
        private SeleniumHelper seleniumHelper;

        public Lurk()
        {
            lurks = new List<string> { ":lurk", ":purpleheart" };
            selecionado = lurks.First();
        }

        public void Enviar(ChromeDriver chromeDriver)
        {
            seleniumHelper = new SeleniumHelper(chromeDriver);
            seleniumHelper.Habilitar(chromeDriver);

            var isLiveOn = seleniumHelper.LiveEstaOn(chromeDriver);

            if (isLiveOn)
            {
                By chat = By.XPath("//*[@id='__layout']/div/div/div[2]/div/section/div[3]/div/section/div[1]/div[1]/div[1]");
                By lurk = By.XPath("//*[@id='__layout']/div/div/div[2]/div/section/div[3]/div/section/div[2]/div[1]/div[1]");

                Thread.Sleep(4000);
                if (selecionado == lurks.First())
                {
                    chromeDriver.FindElement(chat).SendKeys(selecionado);
                    selecionado = lurks.Last();
                }
                else
                {
                    chromeDriver.FindElement(chat).SendKeys(":purpleheart");
                    selecionado = lurks.First();
                }

                chromeDriver.FindElement(lurk).SendKeys(Keys.Enter);
                chromeDriver.FindElement(lurk).SendKeys(Keys.Enter);
            }
        }
    }
}

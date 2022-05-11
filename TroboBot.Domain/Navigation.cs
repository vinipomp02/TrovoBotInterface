using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TroboBot.Domain
{
    public class TrovoNavigation
    {
        public ChromeDriver chromeDriver { get; }

        public TrovoNavigation(ChromeDriver chromeDriver)
        {
            this.chromeDriver = chromeDriver;
        }

        public void Navegar(Streamer streamer)
        {
            chromeDriver.Navigate().GoToUrl(streamer.LinkUrl);
            chromeDriver.Manage().Window.Maximize();
        }

        public void AbrirTelaDeLogin()
        {
            //Mesma coisa do comentário anterior. Ter thread.sleep significa que não está respeitando comportamento da página.
            Thread.Sleep(6000);
            By iconeLogin = By.XPath("//*[@id='__layout']/div/nav/div[3]/div[4]/div/div/img");
            By botaoLogin = By.XPath("//*[@id='__layout']/div/nav/div[3]/div[4]/div[2]/div/ul/li[8]/button");

            chromeDriver.FindElement(iconeLogin).Click();
            chromeDriver.FindElement(botaoLogin).Click();
        }

        public void Logar(string login, string senha)
        {
            Thread.Sleep(2000);

            By userName = By.XPath("/html/body/div[4]/div/div[2]/div[3]/div[1]/div[1]/div/input");
            By passWord = By.XPath("/html/body/div[4]/div/div[2]/div[3]/div[1]/div[3]/div/input");
            By loginButton = By.XPath("/html/body/div[4]/div/div[2]/div[3]/div[1]/button");

            chromeDriver.FindElement(userName).SendKeys(login);
            chromeDriver.FindElement(passWord).SendKeys(senha);
            chromeDriver.FindElement(loginButton).Click();
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace projetoMantis.features
{
    [Binding]
    public class LoginSteps
    {
        IWebDriver Browser;
        private string uri = "https://mantis-prova.base2.com.br/login_page.php";

        [BeforeScenario]
        public void Init()
        {
            this.Browser = new ChromeDriver();

        }

        [AfterScenario]
        public void Close()
        {
            this.Browser.Close();
            this.Browser.Dispose();
        }

        [Given(@"que estou na tela de login")]
        public void DadoQueEstouNaTelaDeLogin()
        {
            this.Browser.Navigate().GoToUrl(uri);
        }
        
        [When(@"eu preencho os campos de usuario e senha")]
        public void QuandoEuPreenchoOsCamposDeUsuarioESenha(Table table)
        {
            var userame = this.Browser.FindElement(By.Name("username"));
            userame.SendKeys(table.Rows[0][0].ToString());
            var password = this.Browser.FindElement(By.Name("password"));
            password.SendKeys(table.Rows[0][1].ToString());
        }
        
        [When(@"clico em entrar")]
        public void QuandoClicoEmEntrar()
        {
            var submit = this.Browser.FindElement(By.XPath("/html/body/div[3]/form/table/tbody/tr[6]/td/input"));
            submit.Click();

        }

        [When(@"eu preencho os campos de usuario e senha com dados invalidos")]
        public void QuandoEuPreenchoOsCamposDeUsuarioESenhaComDadosInvalidos(Table table)
        {
            var userame = this.Browser.FindElement(By.Name("username"));
            userame.SendKeys(table.Rows[0][0].ToString());
            var password = this.Browser.FindElement(By.Name("password"));
            password.SendKeys(table.Rows[0][1].ToString());
        }
        
        [When(@"eu não preencho os campos de usuario e senha")]
        public void QuandoEuNaoPreenchoOsCamposDeUsuarioESenha(Table table)
        {
            var userame = this.Browser.FindElement(By.Name("username"));
            userame.SendKeys(table.Rows[0][0].ToString());
            var password = this.Browser.FindElement(By.Name("password"));
            password.SendKeys(table.Rows[0][1].ToString());
        }
        
        [Then(@"sou direcionado para a tela principal")]
        public void EntaoSouDirecionadoParaATelaPrincipal()
        {
            try
            {
                var telaPrincipal = this.Browser.FindElement(By.XPath(".//span[contains(., 'raquel.dutra')]"));
                Assert.AreEqual("raquel.dutra", telaPrincipal.Text);
            }
            catch (NoSuchElementException)
            {
                Assert.Fail();
            }
        }
        
        [Then(@"vejo uma mensagem de usuario ou senha incorretos")]
        public void EntaoVejoUmaMensagemDeUsuarioOuSenhaIncorretos()
        {
            try
            {
                var mensagem = this.Browser.FindElement(By.XPath(".//div[contains(., 'Your account may be disabled or blocked or the username/password you entered is incorrect.')]"));
                Assert.AreEqual("Your account may be disabled or blocked or the username/password you entered is incorrect.", mensagem.Text);
            }
            catch (NoSuchElementException)
            {
                Assert.Fail();
            }
        }
    }
}

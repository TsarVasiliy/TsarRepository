using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using NUnit.Framework.Internal;

namespace automatic_tests.Pages
{
    class MainPage : AbstractPage
    {
        private const string BASE_URL = "http://kinokrad.co/";


        
        [FindsBy(How = How.Id, Using = "loginlink")]
        private IWebElement enter_main;

        [FindsBy(How = How.Id, Using = "login_name")]
        private IWebElement inputLogin;

        [FindsBy(How = How.Id, Using = "login_password")]
        private IWebElement inputPassword;

        [FindsBy(How = How.LinkText, Using = "Выход")]
        private IWebElement buttonExit;

        [FindsBy(How = How.Id, Using = "story")]
        private IWebElement inputSearch;

        [FindsBy(How = How.LinkText, Using = "Настроить аккаунт")]
        private IWebElement buttonEditAcc;


        IWebElement linkFilm;

        [FindsBy(How = How.Id, Using = "loginlink")]
        private IWebElement linkLoggedInUser;

        public MainPage(IWebDriver driver)
            : base(driver)
        {
            PageFactory.InitElements(this.driver, this);
        }

        public override void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
            
        }

        public void ClickButtonEditAcc()            //нажатие редактировать акаунт
        {
            buttonEditAcc.Click();
            System.Threading.Thread.Sleep(1000);

        }

        public void Login(string username, string password)
        {
            enter_main.Click();
            inputLogin.SendKeys(username);
            inputPassword.SendKeys(password);
            inputPassword.SendKeys(Keys.Enter);
            //buttonSubmit.Click();            
            System.Threading.Thread.Sleep(1000);
        }
        public void LogOff()
        {
          
            buttonExit.Click();

        }
        public string GetLoggedInUserName()
        {
            return linkLoggedInUser.Text;
        }
        public string GetAuthorizationError()
        {
            IWebElement textAuthorizationError = driver.FindElement(By.CssSelector(".berrors"));
            return textAuthorizationError.Text;
        }
        public bool isEnterButtonExists()
        {
            return enter_main.Text.Equals("Вход");
        }

        public string GoThroughPanel(string filmType)
        {
            IWebElement linkPanel = driver.FindElement(By.LinkText(filmType));
            Console.WriteLine(linkPanel.Text);
            linkPanel.Click();
            IWebElement pageHeader = driver.FindElement(By.ClassName("contenth1"));
            return pageHeader.Text;
        }

        public void Search(string text)                 //поиск фильма
        {
            inputSearch.SendKeys(text);
            inputSearch.SendKeys(Keys.Enter);
        }

        public string GetFindFilm(string film_name)             //проверка найденого фильма
        {
            linkFilm = driver.FindElement(By.LinkText(film_name));
            Console.WriteLine(linkFilm.Text);
            return linkFilm.Text;
        }
    }
}

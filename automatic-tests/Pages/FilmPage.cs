using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace automatic_tests.Pages
{
    class FilmPage : AbstractPage
    {
        private const string BASE_URL = "http://kinokrad.co/270478-boycovskiy-klub.html";
        private const string FILM_NAME = "Бойцовский клуб (2000)";
        

        [FindsBy(How = How.ClassName, Using = "favorfull_plus")]
        private IWebElement buttonAddToFavorite;

        [FindsBy(How = How.Id, Using = "comments")]
        private IWebElement inputComment;

        [FindsBy(How = How.ClassName, Using = "fbutton")]
        private IWebElement buttonAddComment;

        [FindsBy(How = How.ClassName, Using = "r10-unit")]
        private IWebElement button10Mark;
        

        public FilmPage(IWebDriver driver)
            : base(driver)
        {
            PageFactory.InitElements(this.driver, this);
        }

        public override void OpenPage()
        {
            System.Threading.Thread.Sleep(2000);
            driver.Navigate().GoToUrl(BASE_URL);
            
        }

        public int isFavourite()
        {
            System.Threading.Thread.Sleep(2000);
            IWebElement imgAddFavourite = driver.FindElement(By.XPath("//*[@id='fav-id-1078']/img"));
            return imgAddFavourite.GetAttribute("title").CompareTo("Удалить из закладок"); ;
        }
        public void Rate()
        {
            button10Mark.Click();
        }
        public bool isRated()
        {
            System.Threading.Thread.Sleep(1500);
            IWebElement imgCurrentRating= driver.FindElement(By.ClassName("current-rating"));
            return imgCurrentRating.Displayed;
        }
        public void AddCommentButtonClick()
        {
            buttonAddComment.Click();
            System.Threading.Thread.Sleep(1500);
        }
        public bool isCommentError()
        {
           IWebElement errorMessage = driver.FindElement(By.XPath("//*[@id='addcform']/div/b"));
           return errorMessage.Text.Equals("Гости");
        }


        public void WriteComment(string text)
        {
            inputComment.SendKeys(text);
        }
        public void ButtonAddClick()
        {
            buttonAddComment.Click();
            System.Threading.Thread.Sleep(1500);
        }
        public bool isCommentAdded()
        {
            IWebElement dd = driver.FindElement(By.Id("dlepopup"));
            
            return dd.Text.Equals("Ваш комментарий добавлен в базу. После проверки комментария администратором, он будет опубликован на сайте.");
        }


        public void AddFavouriteClick()
        {
         //   System.Threading.Thread.Sleep(1000);
            buttonAddToFavorite.Click();
        }

        public void AddFavouriteWithoutAuthorizationClick()
        {
            buttonAddToFavorite.Click();
        }
    }
}

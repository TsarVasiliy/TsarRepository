using System;
using OpenQA.Selenium;

namespace automatic_tests.Steps
{
    class Steps
    {
        IWebDriver driver;

        public void InitBrowser()
        {
            driver = Driver.DriverInstance.GetInstance();
        }

        public void CloseBrowser()
        {
            Driver.DriverInstance.CloseBrowser();
        }

        public void LoginKinokrad(string username, string password)
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            mainPage.Login(username, password);

        }

        public bool IsLoggedIn(string username)
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            //Console.WriteLine(mainPage.GetLoggedInUserName());
            return (mainPage.GetLoggedInUserName().Equals(username));
        }
        public void LogOffLoginKinokrad()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.LogOff();
        }
        public bool IsLoggedOff()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);

            return mainPage.isEnterButtonExists();
        }

        public void EditAcc()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.ClickButtonEditAcc();
        }


        public void ChangeName(string Name)
        {
            Pages.ProfilePage profilePage = new Pages.ProfilePage(driver);
           
            System.Threading.Thread.Sleep(1000);
            profilePage.EditProfileClick(Name);

            profilePage.CheckName();


        }

        public void SearchFilm(string filmName)
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            mainPage.Search(filmName);

        }

       
        public bool IsSearchedFilm(string filmName)
        {

            Pages.MainPage mainPage = new Pages.MainPage(driver);

            return mainPage.GetFindFilm(filmName).Trim().ToLower().Equals(filmName.Trim().ToLower());
        }



        public void CommentFilm(string text)
        {
            Pages.FilmPage filmPage = new Pages.FilmPage(driver);
            filmPage.OpenPage();
           // filmPage.AddCommentButtonClick();
            filmPage.WriteComment(text);
            filmPage.ButtonAddClick();
        }


        public void CommentFilm()
        {
            Pages.FilmPage filmPage = new Pages.FilmPage(driver);
            filmPage.OpenPage();
            filmPage.AddCommentButtonClick();
        }

        public bool IsCommentAdded()
        {
            Pages.FilmPage filmPage = new Pages.FilmPage(driver);
            return filmPage.isCommentAdded();
        }


        public void RateFilm()
        {
            Pages.FilmPage filmPage = new Pages.FilmPage(driver);
            filmPage.OpenPage();
            filmPage.Rate();
        }


        public void GoThroughPanel(string filmType)
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            //IWebElement linkPanel = driver.FindElement(By.LinkText(filmType));
           
            //linkPanel.Click();
            //System.Threading.Thread.Sleep(10000);
            mainPage.GoThroughPanel(filmType);

        }

        public bool IsHistoryPage(string filmType)
        {
            IWebElement pageHeader = driver.FindElement(By.XPath("/html/body/div/div/div/div/div/div/div/h1"));
            //Console.WriteLine(pageHeader.Text);
            return pageHeader.Text.Equals("Раздел с фильмами " + '\u0022' + filmType + '\u0022');
        }



        public void AddFavourite()
        {
            Pages.FilmPage filmPage = new Pages.FilmPage(driver);
            filmPage.OpenPage();
            filmPage.AddFavouriteClick();
        }


        public void DeleteFavorite()
        {
            Pages.FilmPage filmPage = new Pages.FilmPage(driver);
            filmPage.OpenPage();
            filmPage.DeleteFavouriteClick(); ;
        }

        public void AddFavouriteWithoutAuthorization()
        {
            Pages.FilmPage filmPage = new Pages.FilmPage(driver);
            filmPage.OpenPage();
            filmPage.AddFavouriteWithoutAuthorizationClick();
            System.Threading.Thread.Sleep(1000);
            System.Console.WriteLine(driver.Title);

        }

        public void ChangePassword(string oldPassword, string newPassword)
        {
            Pages.ProfilePage profilePage = new Pages.ProfilePage(driver);
            profilePage.OpenPage();
            profilePage.EditProfileClick(oldPassword, newPassword);
        }


        public int IsAddedToFavourites()
        {
            Pages.FilmPage filmPage = new Pages.FilmPage(driver);
            
            return filmPage.isFavourite();
        }



        public bool IsLoggedError()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            Console.WriteLine(mainPage.GetAuthorizationError());
            return (mainPage.GetAuthorizationError().Contains("Ошибка авторизации"));
        }


        public bool IsRated()
        {
            Pages.FilmPage filmPage = new Pages.FilmPage(driver);
            return filmPage.isRated();
        }

        public void ChangeAvatar()
        {
            Pages.ProfilePage profilePage = new Pages.ProfilePage(driver);
            profilePage.OpenPage();
            profilePage.EditProfileClick();
            profilePage.LoadPicture();
            profilePage.SubmitClick();

        }
        public bool IsDefaultAvatar()
        {
            System.Threading.Thread.Sleep(2000);
            Pages.ProfilePage profilePage = new Pages.ProfilePage(driver);
            return profilePage.isDefaultImg();
        }

        public void DeleteAvatar()
        {
            Pages.ProfilePage profilePage = new Pages.ProfilePage(driver);
            profilePage.OpenPage();
            profilePage.EditProfileClick();
            profilePage.SetCheckboxDeletePhoto();

        }


        public bool IsRegistryPage()
        {
           
           // System.Console.WriteLine(driver.Title);
            return driver.Title.Contains("Регистрация посетителя");
        }


        public bool IsNameChaged()
        {
            Pages.ProfilePage profilePage = new Pages.ProfilePage(driver);

            return profilePage.isNameChanged() ;
        }

        public int IsDeletedFavourite()
        {
            Pages.FavouritesPage favouritePage = new Pages.FavouritesPage(driver);
            return favouritePage.isDeletedFromFavourite();
        }

        public bool IsCommentError()
        {
            Pages.FilmPage filmPage = new Pages.FilmPage(driver);
            return filmPage.isCommentError();
        }

    }
}

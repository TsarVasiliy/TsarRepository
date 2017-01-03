using NUnit.Framework;


namespace automatic_tests.Tests
{
    [TestFixture]
    class Tests
    {
            private Steps.Steps steps = new Steps.Steps();
            private const string USERNAME = "epam_test";
            private const string PASSWORD = "12345qazWSX";
            private const string WRONG_PASSWORD = "1234";
            private const string TEXT_TO_SEARCH = "Бойцовский клуб (2000)";
            private const string NAVIGATION_LINK = "Исторические";
            private const string TEXT_COMMENT = "«Бойцовский клуб» — это шедевр, шедевр во всех смыслах.Кино будет актуально всегда.Вечные вопросы.которые поставлены тут изменят ваше представление о мире в целом.";
            private const string NEW_PASSWORD = "123456789";
            private const string Name = "Tsar";

            [SetUp]
            public void Init()
            {
                steps.InitBrowser();
            }

            [TearDown]

            public void Cleanup()
            {
                steps.CloseBrowser();
            }

            [Test]
            public void LoginKinokrad()
            {
                steps.LoginKinokrad(USERNAME, PASSWORD);
                Assert.True(steps.IsLoggedIn("Личный кабинет"));
            }
            [Test]
            public void LogOffLoginKinokrad()
            {
            steps.LoginKinokrad(USERNAME, PASSWORD);
            steps.LogOffLoginKinokrad();
            System.Threading.Thread.Sleep(1000);
            Assert.True(steps.IsLoggedOff());
            }

        [Test]
        public void WrongLoginKinokrad()
        {
            steps.LoginKinokrad(USERNAME, WRONG_PASSWORD);
            Assert.True(steps.IsLoggedError());
        }


        [Test]
        public void Change_Name()
        {
            steps.LoginKinokrad(USERNAME, PASSWORD);
            System.Threading.Thread.Sleep(1000);
            steps.EditAcc();
            System.Threading.Thread.Sleep(1000);
            steps.ChangeName(Name);
            System.Threading.Thread.Sleep(1000);

            Assert.True(steps.IsNameChaged());
        }

        [Test]
        public void Search()                        //поиск фильма
        {
            steps.SearchFilm(TEXT_TO_SEARCH);
            Assert.True(steps.IsSearchedFilm(TEXT_TO_SEARCH));
        }

        [Test]
        public void AddComment()
        {
            steps.LoginKinokrad(USERNAME, PASSWORD);
            steps.CommentFilm(TEXT_COMMENT);
            Assert.True(steps.IsCommentAdded());
        }


        [Test]
        public void RateFilmTest()
        {
            steps.RateFilm();
            Assert.True(steps.IsRated());
        }


        [Test]
        public void SelectGenre()
        {
            string type =  steps.GoThroughPanel(NAVIGATION_LINK);
            //Assert.True(type.Equals(NAVIGATION_LINK));
           
        }

        [Test]
        public void AddToFavourites()
        {
            steps.LoginKinokrad(USERNAME, PASSWORD);

            steps.AddFavourite();
            steps.DeleteFavorite();
            Assert.AreEqual(steps.IsDeletedFavourite(), 0);
            //steps.DeleteFavorite();
        }

        [Test]
        public void AddFavouritesWithoutAuthorization()
        {
            steps.AddFavouriteWithoutAuthorization();
            Assert.True(steps.IsRegistryPage());
        }

        [Test]
        public void ChangePassword()
        {
            steps.LoginKinokrad(USERNAME, PASSWORD);
            steps.ChangePassword(PASSWORD, NEW_PASSWORD);
            steps.LogOffLoginKinokrad();
            steps.LoginKinokrad(USERNAME, NEW_PASSWORD);
            Assert.True(steps.IsLoggedIn(USERNAME));
            steps.ChangePassword(NEW_PASSWORD, PASSWORD);
        }


        [Test]
        public void AddAvatar()
        {
            steps.LoginKinokrad(USERNAME, PASSWORD);
            steps.ChangeAvatar();
            Assert.False(steps.IsDefaultAvatar());
            steps.DeleteAvatar();
        }
        [Test]
        public void DeleteAvatar()
        {
            steps.LoginKinokrad(USERNAME, PASSWORD);
            steps.ChangeAvatar();
            steps.DeleteAvatar();
            Assert.True(steps.IsDefaultAvatar());
        }

        [Test]
        public void AddCommentWithoutAuthorization()
        {
            steps.CommentFilm();
            Assert.True(steps.IsCommentError());
        }

        
        [Test]
        public void DeleteFromFavourites()
        {
            steps.LoginKinokrad(USERNAME, PASSWORD);
            steps.AddFavourite();
            steps.DeleteFavorite();
            Assert.AreEqual(steps.IsDeletedFavourite(), 0);
        }




    }
}
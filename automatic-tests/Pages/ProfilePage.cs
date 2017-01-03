using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace automatic_tests.Pages
{
    class ProfilePage : AbstractPage
    {
        
        private const string BASE_URL = "http://kinokrad.co/user/epam_test/";

 
        [FindsBy(How = How.Name, Using = "fullname")]
        private IWebElement NameBox;

        [FindsBy(How = How.Name, Using = "password2")]
        private IWebElement RepeateBox;
        
        [FindsBy(How = How.XPath, Using = "//*[@id='userinfo']/div/div/div/div/img")]
        private IWebElement imgProfile;

        [FindsBy(How = How.Name, Using = "del_foto")]
        private IWebElement checkboxDeletePhoto;

        [FindsBy(How = How.LinkText, Using = "редактировать профиль")]
        private IWebElement buttonEditProfile;

        [FindsBy(How = How.Name, Using = "altpass")]
        private IWebElement oldPassword;

        [FindsBy(How = How.Name, Using = "password1")]
        private IWebElement newPassword;

        [FindsBy(How = How.LinkText, Using = "Отправить")]
        private IWebElement buttonSaveChange;

        [FindsBy(How = How.LinkText, Using = "Выход")]
        private IWebElement buttonExitAccount;

        [FindsBy(How = How.ClassName, Using = "ui-icon ui-icon-closethick")]
        private IWebElement buttonCloseCabinete;

        
        public ProfilePage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(this.driver, this);
        }

        public override void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
            
        }
        public void EditProfileClick(string Name)
        {
            buttonEditProfile.Click();
            System.Threading.Thread.Sleep(1000);
            NameBox.Clear();
            NameBox.SendKeys(Name);
            NameBox.SendKeys(Keys.Enter);
        }

        public bool isNameChanged()
        {
            return NameBox.Text.Equals("");
        }

        public void CheckName()
        {
            Console.WriteLine(NameBox.Text);
            
        }

        public void EditProfileClick(string oldPass, string newPass)
        {
            buttonEditProfile.Click();
            System.Threading.Thread.Sleep(2000);
            oldPassword.SendKeys(oldPass);
            newPassword.SendKeys(newPass);
            RepeateBox.SendKeys(newPass);
            newPassword.SendKeys(Keys.Enter);
            System.Threading.Thread.Sleep(5000);
            buttonExitAccount.Click();


        }


        public void EditProfileClick()
        {
            buttonEditProfile.Click();
            System.Threading.Thread.Sleep(2000);
        }

        public void LoadPicture()
        {
            IWebElement inputChooseFile = driver.FindElement(By.Name("image"));
            inputChooseFile.SendKeys(System.IO.Path.GetFullPath(@"img/images.jpg"));
            System.Threading.Thread.Sleep(2000);
            NameBox.SendKeys(Keys.Enter);
            
        }
        public void SubmitClick()
        {
            NameBox.SendKeys(Keys.Enter);
        }
        public bool isDefaultImg()
        {
            Console.WriteLine(imgProfile.GetAttribute("Src"));
            return imgProfile.GetAttribute("src").Equals("http://kinokrad.co/templates/kinok/dleimages/noavatar.png");
        }
        public void SetCheckboxDeletePhoto()
        {
            System.Threading.Thread.Sleep(2000);
            checkboxDeletePhoto.Click();
            NameBox.SendKeys(Keys.Enter);
            System.Threading.Thread.Sleep(2000);
        }

    }
}

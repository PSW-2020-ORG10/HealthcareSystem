using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatientWebAppSeleniumTests.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:3000/";
        private IWebElement EmailElement => driver.FindElement(By.Id("email"));
        private IWebElement PasswordElement => driver.FindElement(By.Id("password"));
        private IWebElement SubmitButtonElement => driver.FindElement(By.Id("submit"));
        public string Title => driver.Title;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool MessageElementDisplayed()
        {
            return EmailElement.Displayed;
        }

        public bool IsAnonymousElementDisplayed()
        {
            return PasswordElement.Displayed;
        }

        public bool SubmitButtonElementDisplayed()
        {
            return SubmitButtonElement.Displayed;
        }

        public void InsertEmail(string email)
        {
            EmailElement.SendKeys(email);
        }

        public void InsertPassword(string password)
        {
            PasswordElement.SendKeys(password);
        }

        public void SubmitForm()
        {
            SubmitButtonElement.Click();
        }

        public void WaitForFormSubmit()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe("http://localhost:3000/patient-homepage"));
        }

        public void WaitForFormSubmitAdmin()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe("http://localhost:3000/admin-feedback"));
        }

        public void Navigate() => driver.Navigate().GoToUrl(URI);
    }
}

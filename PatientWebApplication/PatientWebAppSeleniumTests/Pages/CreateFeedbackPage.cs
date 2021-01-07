using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatientWebAppSeleniumTests.Pages
{
    public class CreateFeedbackPage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:60198/create-feedback";
        private IWebElement MessageElement => driver.FindElement(By.Id("message"));
        private IWebElement IsAnonymousElement => driver.FindElement(By.Id("isAnonymous"));
        private IWebElement IsPublicElement => driver.FindElement(By.Id("isPublic"));
        private IWebElement SubmitButtonElement => driver.FindElement(By.Id("submit"));

        public string Title => driver.Title;

        public CreateFeedbackPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool MessageElementDisplayed()
        {
            return MessageElement.Displayed;
        }

        public bool IsAnonymousElementDisplayed()
        {
            return IsAnonymousElement.Displayed;
        }

        public bool IsPublicElementDisplayed()
        {
            return IsPublicElement.Displayed;
        }

        public bool SubmitButtonElementDisplayed()
        {
            return SubmitButtonElement.Displayed;
        }

        public void InsertMessage(string message)
        {
            MessageElement.SendKeys(message);
        }

        public void InsertIsAnonymous(string isAnonymous)
        {
            if (isAnonymous.Equals("true"))
            {
                IsAnonymousElement.Click();
            }
        }

        public void InsertIsPublic(string isPublic)
        {
            if (isPublic.Equals("true"))
            {
                IsPublicElement.Click();
            }
        }

        public void SubmitForm()
        {
            SubmitButtonElement.Click();
        }

        public void WaitForFormSubmit()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe(FeedbackPage.URI));
        }

        public void Navigate() => driver.Navigate().GoToUrl(URI);
    }
}

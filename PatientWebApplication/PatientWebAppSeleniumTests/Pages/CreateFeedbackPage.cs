using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PatientWebAppSeleniumTests.Pages
{
    public class CreateFeedbackPage
    {
        private readonly IWebDriver driver;
        public const string URI = "https://healthcare-system-org10.herokuapp.com/create-feedback";
        private IWebElement MessageElement => driver.FindElement(By.Id("message"));
        private IWebElement IsAnonymousElement => driver.FindElement(By.Id("isAnonymous"));
        private IWebElement IsPublicElement => driver.FindElement(By.Id("isPublic"));
        private IWebElement SubmitButtonElement => driver.FindElement(By.Id("submit"));
        private IWebElement LogoutButtonElement => driver.FindElement(By.Id("logout"));
        private ReadOnlyCollection<IWebElement> Rows => driver.FindElements(By.XPath("//span[@class='check-flag-label']"));
        private IWebElement LastItemName => driver.FindElement(By.XPath("(//span[@class='check-flag-label'])[last()]"));
        private IWebElement LastItemMessage => driver.FindElement(By.XPath("(//textarea[@class='check-flag-textarea'])[last()]"));

        public string Title => driver.Title;

        public void EnsurePageIsDisplayed()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
            wait.Until(condition =>
            {
                try
                {
                    return Rows.Count > 0;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }

        public CreateFeedbackPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string GetLastItemName()
        {
            return LastItemName.Text;
        }

        public string GetLastItemMessage()
        {
            return LastItemMessage.Text;
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

        public bool LogoutButtonElementDisplayed()
        {
            return LogoutButtonElement.Displayed;
        }

        public bool SubmitButtonElementEnabled()
        {
            return SubmitButtonElement.Enabled;
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

        public void Logout()
        {
            LogoutButtonElement.Click();
        }

        public void WaitForFormSubmit()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe("https://healthcare-system-org10.herokuapp.com/patient-homepage"));
        }

        public void Navigate() => driver.Navigate().GoToUrl(URI);
    }
}

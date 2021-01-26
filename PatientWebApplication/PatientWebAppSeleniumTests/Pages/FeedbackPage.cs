using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;

namespace PatientWebAppSeleniumTests.Pages
{
    public class FeedbackPage
    {
        private readonly IWebDriver driver;
        public const string URI = "https://healthcare-system-org10.herokuapp.com/admin-feedback";
        private IWebElement Table => driver.FindElement(By.Id("feedbackTable"));
        private ReadOnlyCollection<IWebElement> Rows => driver.FindElements(By.XPath("//table[@id='feedbackTable']/tbody/tr"));
        private IWebElement LastRowMessage => driver.FindElement(By.XPath("(//table[@id='feedbackTable']/tbody/tr)[last()]/td[1]"));
        private IWebElement LastRowDate => driver.FindElement(By.XPath("(//table[@id='feedbackTable']/tbody/tr)[last()]/td[2]"));
        private IWebElement LastRowIsAnonymous => driver.FindElement(By.XPath("(//table[@id='feedbackTable']/tbody/tr)[last()]/td[3]"));
        private IWebElement LastRowButton => driver.FindElement(By.XPath("(//table[@id='feedbackTable']/tbody/tr)[last()]/td[4]/button"));
        private IWebElement LogoutButtonElement => driver.FindElement(By.Id("logout"));
        public string Title => driver.Title;

        public void EnsurePageIsDisplayed()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 40));
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

        public void EnsurePageIsDisplayedSecond(int number)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 40));
            wait.Until(condition =>
            {
                try
                {
                    return Rows.Count > number;
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

        public FeedbackPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public int FeedbacksCount()
        {
            return Rows.Count;
        }

        public string GetLastRowMessage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//table[@id='feedbackTable']/tbody/tr)[last()]/td[1]")));
            return LastRowMessage.Text;
        }

        public string GetLastRowDate()
        {
            return LastRowDate.Text;
        }

        public string GetLastRowIsAnonymous()
        {
            return LastRowIsAnonymous.Text;
        }

        public bool LastPublishButtonDisplayed()
        {
            return LastRowButton.Displayed;
        }

        public bool LastPublishButtonEnabled()
        {
            return LastRowButton.Enabled;
        }

        public void LastPublishButtonClick()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            wait.Until(ExpectedConditions.ElementToBeClickable(LastRowButton));
            LastRowButton.Click();
        }

        public void Logout()
        {
            Thread.Sleep(1000);
            var toastButton = driver.FindElement(By.CssSelector("div[class='Toastify__toast-container Toastify__toast-container--top-right']"));
            toastButton.Click();
            Thread.Sleep(1000);
            LogoutButtonElement.Click();
        }

        public void LogoutWithoutToast()
        {
            LogoutButtonElement.Click();
        }

        public void Navigate() => driver.Navigate().GoToUrl(URI);
    }
}

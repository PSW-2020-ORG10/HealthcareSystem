using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PatientWebAppSeleniumTests.Pages
{
    public class FeedbackPage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:3000/admin-feedback";
        private IWebElement Table => driver.FindElement(By.Id("feedbackTable"));
        private ReadOnlyCollection<IWebElement> Rows => driver.FindElements(By.XPath("//table[@id='feedbackTable']/tbody/tr"));
        private IWebElement LastRowMessage => driver.FindElement(By.XPath("(//table[@id='feedbackTable']/tbody/tr)[last()]/td[1]"));
        private IWebElement LastRowDate => driver.FindElement(By.XPath("(//table[@id='feedbackTable']/tbody/tr)[last()]/td[2]"));
        private IWebElement LastRowIsAnonymous => driver.FindElement(By.XPath("(//table[@id='feedbackTable']/tbody/tr)[last()]/td[3]"));

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

        public void EnsurePageIsDisplayedSecond(int number)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
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

        public void Navigate() => driver.Navigate().GoToUrl(URI);
    }
}

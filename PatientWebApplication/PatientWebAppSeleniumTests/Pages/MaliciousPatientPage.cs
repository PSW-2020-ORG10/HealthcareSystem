using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;

namespace PatientWebAppSeleniumTests.Pages
{
    class MaliciousPatientPage
    {
        private readonly IWebDriver driver;
        public const string URI = "https://healthcare-system-org10.herokuapp.com/malicious-patient";
        private IWebElement Table => driver.FindElement(By.Id("maliciousPatientTable"));
        private ReadOnlyCollection<IWebElement> Rows => driver.FindElements(By.XPath("//table[@id='maliciousPatientTable']/tbody/tr"));
        private IWebElement SubmitButtonElement => driver.FindElement(By.XPath("(//table[@id='maliciousPatientTable']/tbody/tr)[last()]/td[4]/button"));
        public string Title => driver.Title;

        public MaliciousPatientPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void SubmitForm()
        {
            Thread.Sleep(3000);
            SubmitButtonElement.Click();
        }

        public void WaitForFormSubmit()
        {
            Thread.Sleep(1000);
        }

        public bool SubmitButtonElementDisplayed()
        {
            return SubmitButtonElement.Displayed;
        }
        public bool SubmitButtonElementEnabled()
        {
            return SubmitButtonElement.Enabled;
        }

        public void EnsurePageIsDisplayed()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 120));
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

        public void Navigate() => driver.Navigate().GoToUrl(URI);
    }
}

using BAMCIS.Util.Concurrent;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;

namespace PatientWebAppSeleniumTests.Pages
{
    class AppointmentsPage
    {
        private readonly IWebDriver driver;
        public const string URI = "https://healthcare-system-org10.herokuapp.com/my-appointments";
        private IWebElement Table => driver.FindElement(By.Id("appointmentTable"));
        private ReadOnlyCollection<IWebElement> Rows => driver.FindElements(By.XPath("//table[@id='appointmentTable']/tbody/tr"));
        private IWebElement elementOldPage => driver.FindElements(By.Name("cancelButton"))[1];
        private IWebElement SubmitButtonElement => driver.FindElements(By.Name("cancelButton"))[0];
        public string Title => driver.Title;

        public AppointmentsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public int AppointmentCount()
        {
            return Rows.Count;
        }

        public void SubmitForm()
        {
            SubmitButtonElement.Click();
        }
        public void WaitForFormSubmit()
        {
            Thread.Sleep(1000);
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

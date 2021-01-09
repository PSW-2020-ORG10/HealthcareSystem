using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PatientWebAppSeleniumTests
{
    public class BlockPatientTests : IDisposable
    {
        private readonly IWebDriver driver;
        private Pages.MaliciousPatientPage maliciousPatientPage;
        private Pages.LoginPage loginPage;
        private Pages.FeedbackPage feedbackPage;
        private int maliciousPatientCount = 0;

        public BlockPatientTests()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");
            options.AddArguments("disable-infobars");
            options.AddArguments("--disable-extensions");
            options.AddArguments("--disable-gpu");
            options.AddArguments("--disable-dev-shm-usage");
            options.AddArguments("--no-sandbox");
            options.AddArguments("--disable-notifications");

            driver = new ChromeDriver(options);

            loginPage = new Pages.LoginPage(driver);
            loginPage.Navigate();
            Assert.Equal(driver.Url, Pages.LoginPage.URI);


        }

        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Fact]
        public void TestSuccessfulBlock()
        {
            loginPage.InsertEmail("admin1@gmail.com");
            loginPage.InsertPassword("password");
            loginPage.SubmitForm();
            loginPage.WaitForFormSubmitAdmin();

            maliciousPatientPage = new Pages.MaliciousPatientPage(driver);
            maliciousPatientPage.Navigate();
            Assert.Equal(driver.Url, Pages.MaliciousPatientPage.URI);

            // maliciousPatientCount = maliciousPatientPage.MaliciousPatientCount();

            maliciousPatientPage.SubmitForm();
            maliciousPatientPage.WaitForFormSubmit();
            maliciousPatientPage.EnsurePageIsDisplayed();

            feedbackPage = new Pages.FeedbackPage(driver);
            feedbackPage.Navigate();
            Assert.Equal(driver.Url, Pages.FeedbackPage.URI);

            maliciousPatientPage = new Pages.MaliciousPatientPage(driver);
            maliciousPatientPage.Navigate();
            maliciousPatientPage.EnsurePageIsDisplayed();
            Assert.Equal(driver.Url, Pages.MaliciousPatientPage.URI);

            Assert.Equal(maliciousPatientPage.SubmitButtonElementEnabled(), false);
        }
    }
}

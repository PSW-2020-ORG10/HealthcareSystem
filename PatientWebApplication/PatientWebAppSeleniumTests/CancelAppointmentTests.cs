using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PatientWebAppSeleniumTests
{
    public class CancelAppointmentTests : IDisposable
    {
        private readonly IWebDriver driver;
        private Pages.AppointmentsPage appointmentsPage;
        private Pages.LoginPage loginPage;
        private Pages.CreateFeedbackPage createFeedbackPage;
        private int appointmentCount = 0;     

        public CancelAppointmentTests()
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
        public void TestSuccessfulCancel()
        {
            loginPage.InsertEmail("patient1@gmail.com");
            loginPage.InsertPassword("12345");
            loginPage.SubmitForm();
            loginPage.WaitForFormSubmit();

            appointmentsPage = new Pages.AppointmentsPage(driver);
            appointmentsPage.Navigate();
            appointmentsPage.EnsurePageIsDisplayed();
            Assert.Equal(driver.Url, Pages.AppointmentsPage.URI);

            appointmentCount = appointmentsPage.AppointmentCount();
            
            appointmentsPage.SubmitForm();
            appointmentsPage.WaitForFormSubmit();
            appointmentsPage.EnsurePageIsDisplayed();

            createFeedbackPage = new Pages.CreateFeedbackPage(driver);
            createFeedbackPage.Navigate();
            Assert.Equal(driver.Url, Pages.CreateFeedbackPage.URI);

            appointmentsPage = new Pages.AppointmentsPage(driver);
            appointmentsPage.Navigate();
            appointmentsPage.EnsurePageIsDisplayed();
            Assert.Equal(driver.Url, Pages.AppointmentsPage.URI);

            Assert.Equal(appointmentCount-1, appointmentsPage.AppointmentCount());
        }
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PatientWebAppSeleniumTests.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace PatientWebAppSeleniumTests
{
    public class PublishFeedbackTests : IDisposable
    {
        private readonly IWebDriver driver;
        private Pages.CreateFeedbackPage createFeedbackPage;
        private Pages.LoginPage loginPage;
        private Pages.FeedbackPage feedbackPage;

        public PublishFeedbackTests()
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
        public void TestSuccessfulPublish()
        {
            loginPage.InsertEmail("patient1@gmail.com");
            loginPage.InsertPassword("12345");
            loginPage.SubmitForm();
            loginPage.WaitForFormSubmit();

            createFeedbackPage = new CreateFeedbackPage(driver);
            createFeedbackPage.Navigate();
            Assert.Equal(driver.Url, CreateFeedbackPage.URI);

            createFeedbackPage.InsertMessage("Successful publish");
            createFeedbackPage.InsertIsAnonymous("true");
            createFeedbackPage.InsertIsPublic("true");
            createFeedbackPage.SubmitForm();
            createFeedbackPage.WaitForFormSubmit();

            createFeedbackPage.Logout();

            loginPage = new Pages.LoginPage(driver);
            Assert.Equal(driver.Url, Pages.LoginPage.URI);

            loginPage.InsertEmail("admin1@gmail.com");
            loginPage.InsertPassword("password");
            loginPage.SubmitForm();
            loginPage.WaitForFormSubmitAdmin();

            feedbackPage = new FeedbackPage(driver);
            feedbackPage.EnsurePageIsDisplayed();

            Assert.Equal("Successful publish", feedbackPage.GetLastRowMessage());
            Assert.Equal("ANONYMOUS", feedbackPage.GetLastRowIsAnonymous());
            Assert.True(feedbackPage.LastPublishButtonDisplayed());
            Assert.True(feedbackPage.LastPublishButtonEnabled());
        }

        [Fact]
        public void TestWhenIsPublicFalse()
        {
            loginPage.InsertEmail("marko_markovic@gmail.com");
            loginPage.InsertPassword("12345");
            loginPage.SubmitForm();
            loginPage.WaitForFormSubmit();

            createFeedbackPage = new CreateFeedbackPage(driver);
            createFeedbackPage.Navigate();
            Assert.Equal(driver.Url, CreateFeedbackPage.URI);

            createFeedbackPage.InsertMessage("Unsuccessful");
            createFeedbackPage.InsertIsAnonymous("true");
            createFeedbackPage.InsertIsPublic("false");
            createFeedbackPage.SubmitForm();
            createFeedbackPage.WaitForFormSubmit();

            createFeedbackPage.Logout();

            loginPage = new Pages.LoginPage(driver);
            loginPage.Navigate();
            Assert.Equal(driver.Url, Pages.LoginPage.URI);

            loginPage.InsertEmail("admin1@gmail.com");
            loginPage.InsertPassword("password");
            loginPage.SubmitForm();
            loginPage.WaitForFormSubmitAdmin();

            Pages.FeedbackPage newFeedbackPage = new Pages.FeedbackPage(driver);
            newFeedbackPage.EnsurePageIsDisplayed();

            Assert.Equal("Unsuccessful", newFeedbackPage.GetLastRowMessage());
            Assert.Equal("ANONYMOUS", newFeedbackPage.GetLastRowIsAnonymous());
            Assert.True(newFeedbackPage.LastPublishButtonDisplayed());
            Assert.False(newFeedbackPage.LastPublishButtonEnabled());
        }
    }
}
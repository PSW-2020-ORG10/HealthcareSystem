using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace PatientWebAppSeleniumTests
{
    public class CreateFeedbackTests : IDisposable
    {
        private readonly IWebDriver driver;
        private Pages.CreateFeedbackPage createFeedbackPage;
        private Pages.LoginPage loginPage;
        private int feedbackCount = 0;

        public CreateFeedbackTests()
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
        public void TestSuccessfulSubmit()
        {
            loginPage.InsertEmail("marko_markovic@gmail.com");
            loginPage.InsertPassword("12345");
            loginPage.SubmitForm();
            loginPage.WaitForFormSubmit();

            createFeedbackPage = new Pages.CreateFeedbackPage(driver);
            createFeedbackPage.Navigate();
            Assert.Equal(driver.Url, Pages.CreateFeedbackPage.URI);

            createFeedbackPage.InsertMessage("I will be anonymous");                    
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

            Pages.FeedbackPage newFeedbackPage = new Pages.FeedbackPage(driver);
            newFeedbackPage.EnsurePageIsDisplayedSecond(feedbackCount);
            feedbackCount = newFeedbackPage.FeedbacksCount();

            Assert.Equal(feedbackCount, newFeedbackPage.FeedbacksCount());
            Assert.Equal("I will be anonymous", newFeedbackPage.GetLastRowMessage());
            Assert.Equal("ANONYMOUS", newFeedbackPage.GetLastRowIsAnonymous());
        }

        [Fact]
        public void TestSuccessfulSubmitNotAnonymous()
        {
            loginPage.InsertEmail("marko_markovic@gmail.com");
            loginPage.InsertPassword("12345");
            loginPage.SubmitForm();
            loginPage.WaitForFormSubmit();

            createFeedbackPage = new Pages.CreateFeedbackPage(driver);
            createFeedbackPage.Navigate();
            Assert.Equal(driver.Url, Pages.CreateFeedbackPage.URI);

            createFeedbackPage.InsertMessage("Feedback not anonymous");
            createFeedbackPage.InsertIsAnonymous("false");
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

            Pages.FeedbackPage newFeedbackPage = new Pages.FeedbackPage(driver);
            newFeedbackPage.EnsurePageIsDisplayedSecond(feedbackCount);
            feedbackCount = newFeedbackPage.FeedbacksCount();

            Assert.Equal(feedbackCount, newFeedbackPage.FeedbacksCount());                  
            Assert.Equal("Feedback not anonymous", newFeedbackPage.GetLastRowMessage());                   
            Assert.NotEqual("ANONYMOUS", newFeedbackPage.GetLastRowIsAnonymous());                
        }

        [Fact]
        public void TestSuccessfulSubmitNotGoodMessage()
        {
            loginPage.InsertEmail("marko_markovic@gmail.com");
            loginPage.InsertPassword("12345");
            loginPage.SubmitForm();
            loginPage.WaitForFormSubmit();

            createFeedbackPage = new Pages.CreateFeedbackPage(driver);
            createFeedbackPage.Navigate();
            Assert.Equal(driver.Url, Pages.CreateFeedbackPage.URI);

            createFeedbackPage.InsertMessage("Not exact message");
            createFeedbackPage.InsertIsAnonymous("false");
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

            Pages.FeedbackPage newFeedbackPage = new Pages.FeedbackPage(driver);
            newFeedbackPage.EnsurePageIsDisplayedSecond(feedbackCount);
            feedbackCount = newFeedbackPage.FeedbacksCount();

            Assert.Equal(feedbackCount, newFeedbackPage.FeedbacksCount());             
            Assert.NotEqual("Another message", newFeedbackPage.GetLastRowMessage());                   
            Assert.NotEqual("ANONYMOUS", newFeedbackPage.GetLastRowIsAnonymous());                   
        }

        [Fact]
        public void TestNotSuccessfulSubmit()
        {
            loginPage.InsertEmail("marko_markovic@gmail.com");
            loginPage.InsertPassword("12345");
            loginPage.SubmitForm();
            loginPage.WaitForFormSubmit();

            createFeedbackPage = new Pages.CreateFeedbackPage(driver);
            createFeedbackPage.Navigate();
            Assert.Equal(driver.Url, Pages.CreateFeedbackPage.URI);

            createFeedbackPage.InsertIsAnonymous("false");
            createFeedbackPage.InsertIsPublic("true");
            Assert.Equal(createFeedbackPage.SubmitButtonElementEnabled(), false);

        }
    }
}

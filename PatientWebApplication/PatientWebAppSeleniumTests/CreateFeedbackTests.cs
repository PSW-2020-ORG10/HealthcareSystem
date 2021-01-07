using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PatientWebAppSeleniumTests
{
    public class CreateFeedbackTests : IDisposable
    {
        private readonly IWebDriver driver;
        private Pages.FeedbackPage feedbackPage;
        private Pages.CreateFeedbackPage createFeedbackPage;
        private int feedbackCount = 0;

        public CreateFeedbackTests()
        {
            // options for launching Google Chrome
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");            // open Browser in maximized mode
            options.AddArguments("disable-infobars");           // disabling infobars
            options.AddArguments("--disable-extensions");       // disabling extensions
            options.AddArguments("--disable-gpu");              // applicable to windows os only
            options.AddArguments("--disable-dev-shm-usage");    // overcome limited resource problems
            options.AddArguments("--no-sandbox");               // Bypass OS security model
            options.AddArguments("--disable-notifications");    // disable notifications

            driver = new ChromeDriver(options);

            feedbackPage = new Pages.FeedbackPage(driver);      // create ProductsPage
            feedbackPage.Navigate();                            // navigate to url
            feedbackPage.EnsurePageIsDisplayed();               // wait for table to populate
            feedbackCount = feedbackPage.FeedbacksCount();       // get number of table rows - after create successful sheck if number increased

            createFeedbackPage = new Pages.CreateFeedbackPage(driver);
            createFeedbackPage.Navigate();
            Assert.Equal(driver.Url, Pages.CreateFeedbackPage.URI);
        }

        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Fact]
        public void TestSuccessfulSubmit()
        {
            createFeedbackPage.InsertMessage("I will be anonymous");                     // insert all values except price
            createFeedbackPage.InsertIsAnonymous("true");
            createFeedbackPage.InsertIsPublic("true");
            createFeedbackPage.SubmitForm();
            createFeedbackPage.WaitForFormSubmit();

            Pages.FeedbackPage newFeedbackPage = new Pages.FeedbackPage(driver);        // create ProductsPage                            // check if correct title
            newFeedbackPage.EnsurePageIsDisplayedSecond(feedbackCount);

            Assert.Equal(feedbackCount + 1, newFeedbackPage.FeedbacksCount());           // check if number of rows increased       
            Assert.Equal("Message", newFeedbackPage.GetLastRowMessage());                   // check if last product name valid                 // check if last product color valid
            Assert.Equal("ANONYMOUS", newFeedbackPage.GetLastRowIsAnonymous());                   // check if last product price valid
        }

        [Fact]
        public void TestSuccessfulSubmitNotAnonymous()
        {
            createFeedbackPage.InsertMessage("Feedback not anonymous");                     // insert all values except price
            createFeedbackPage.InsertIsAnonymous("false");
            createFeedbackPage.InsertIsPublic("true");
            createFeedbackPage.SubmitForm();
            createFeedbackPage.WaitForFormSubmit();

            Pages.FeedbackPage newFeedbackPage = new Pages.FeedbackPage(driver);        // create ProductsPage                       // check if correct title
            newFeedbackPage.EnsurePageIsDisplayedSecond(feedbackCount);

            Assert.Equal(feedbackCount + 1, newFeedbackPage.FeedbacksCount());           // check if number of rows increased       
            Assert.Equal("Message", newFeedbackPage.GetLastRowMessage());                   // check if last product name valid                 // check if last product color valid
            Assert.NotEqual("ANONYMOUS", newFeedbackPage.GetLastRowIsAnonymous());                   // check if last product price valid
        }

        [Fact]
        public void TestSuccessfulSubmitNotGoodMessage()
        {
            createFeedbackPage.InsertMessage("Wrong message");                     // insert all values except price
            createFeedbackPage.InsertIsAnonymous("false");
            createFeedbackPage.InsertIsPublic("true");
            createFeedbackPage.SubmitForm();
            createFeedbackPage.WaitForFormSubmit();

            Pages.FeedbackPage newFeedbackPage = new Pages.FeedbackPage(driver);        // create ProductsPage                       // check if correct title
            newFeedbackPage.EnsurePageIsDisplayedSecond(feedbackCount);

            Assert.Equal(feedbackCount + 1, newFeedbackPage.FeedbacksCount());           // check if number of rows increased       
            Assert.NotEqual("Message", newFeedbackPage.GetLastRowMessage());                   // check if last product name valid                 // check if last product color valid
            Assert.NotEqual("ANONYMOUS", newFeedbackPage.GetLastRowIsAnonymous());                   // check if last product price valid
        }
    }
}

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
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");            
            options.AddArguments("disable-infobars");           
            options.AddArguments("--disable-extensions");      
            options.AddArguments("--disable-gpu");             
            options.AddArguments("--disable-dev-shm-usage");   
            options.AddArguments("--no-sandbox");               
            options.AddArguments("--disable-notifications");   

            driver = new ChromeDriver(options);

            feedbackPage = new Pages.FeedbackPage(driver);     
            feedbackPage.Navigate();                        
            feedbackPage.EnsurePageIsDisplayed();              
            feedbackCount = feedbackPage.FeedbacksCount();       

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
            createFeedbackPage.InsertMessage("I will be anonymous");                    
            createFeedbackPage.InsertIsAnonymous("true");
            createFeedbackPage.InsertIsPublic("true");
            createFeedbackPage.SubmitForm();
            createFeedbackPage.WaitForFormSubmit();

            Pages.FeedbackPage newFeedbackPage = new Pages.FeedbackPage(driver);        
            newFeedbackPage.EnsurePageIsDisplayedSecond(feedbackCount);

            Assert.Equal(feedbackCount + 1, newFeedbackPage.FeedbacksCount());                
            Assert.Equal("I will be anonymous", newFeedbackPage.GetLastRowMessage());                   
            Assert.Equal("ANONYMOUS", newFeedbackPage.GetLastRowIsAnonymous());                   
        }

        [Fact]
        public void TestSuccessfulSubmitNotAnonymous()
        {
            createFeedbackPage.InsertMessage("Feedback not anonymous");                     
            createFeedbackPage.InsertIsAnonymous("false");
            createFeedbackPage.InsertIsPublic("true");
            createFeedbackPage.SubmitForm();
            createFeedbackPage.WaitForFormSubmit();

            Pages.FeedbackPage newFeedbackPage = new Pages.FeedbackPage(driver);                              
            newFeedbackPage.EnsurePageIsDisplayedSecond(feedbackCount);

            Assert.Equal(feedbackCount + 1, newFeedbackPage.FeedbacksCount());                  
            Assert.Equal("Feedback not anonymous", newFeedbackPage.GetLastRowMessage());                   
            Assert.NotEqual("ANONYMOUS", newFeedbackPage.GetLastRowIsAnonymous());                
        }

        [Fact]
        public void TestSuccessfulSubmitNotGoodMessage()
        {
            createFeedbackPage.InsertMessage("Wrong message");                     
            createFeedbackPage.InsertIsAnonymous("false");
            createFeedbackPage.InsertIsPublic("true");
            createFeedbackPage.SubmitForm();
            createFeedbackPage.WaitForFormSubmit();

            Pages.FeedbackPage newFeedbackPage = new Pages.FeedbackPage(driver);        
            newFeedbackPage.EnsurePageIsDisplayedSecond(feedbackCount);

            Assert.Equal(feedbackCount + 1, newFeedbackPage.FeedbacksCount());             
            Assert.NotEqual("Another message", newFeedbackPage.GetLastRowMessage());                   
            Assert.NotEqual("ANONYMOUS", newFeedbackPage.GetLastRowIsAnonymous());                   
        }
    }
}

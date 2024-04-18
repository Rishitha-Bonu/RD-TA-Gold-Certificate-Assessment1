using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationProject.Framework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace AutomationProject.Tests.StepDefinitions
{
    [Binding]
    public class UITestSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;

        public UITestSteps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
        }

        [Given("I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            
            _driver.Navigate().GoToUrl("https://demoqa.com/login");

            
            var loginPage = new LoginPage(_driver);
        }

        [When("I enter valid user credentials")]
        public void WhenIEnterValidUserCredentials()
        {
            
            var userData = new Framework.Models.UserData
            {
                UserName = "example_user",
                Password = "example_password"
            };

            
            _driver.FindElement(By.Id("username")).SendKeys(userData.UserName);
            _driver.FindElement(By.Id("password")).SendKeys(userData.Password);
        }

        [When("click the login button")]
        public void WhenClickTheLoginButton()
        {
            
            _driver.FindElement(By.Id("loginBtn")).Click();
        }

        [Then("I should be redirected to the Books dashboard page")]
        public void ThenIShouldBeRedirectedToTheBooksDashboardPage()
        {
            
            Assert.AreEqual("https://demoqa.com/books", _driver.Url);
        }

        [Then("I should see the correct username displayed")]
        public void ThenIShouldSeeTheCorrectUsernameDisplayed()
        {
            
            var booksDashboardPage = new BooksDashboardPage(_driver);

            
            var displayedUsername = booksDashboardPage.GetDisplayedUsername();

            
            Assert.AreEqual("example_user", displayedUsername);
        }
    }
}

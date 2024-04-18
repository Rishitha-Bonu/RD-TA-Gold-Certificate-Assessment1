using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutomationProject.Framework;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using AutomationProject.Framework.Utills;
using AutomationProject.Framework.Models;
using RestSharp;

namespace AutomationProject.Tests.StepDefinitions
{
    [Binding]
    public class APITestSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public APITestSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("I have valid user credentials")]
        public void GivenIHaveValidUserCredentials()
        {

            var userData = new Framework.Models.UserData
            {
                UserName = "example_user",
                Password = "example_password"
            };
            _scenarioContext.Set(userData, "UserData");
        }

        [When("I make a POST request to the login endpoint")]
        public void WhenIMakeAPostRequestToTheLoginEndpoint()
        {

            var userData = _scenarioContext.Get<Framework.Models.UserData>("UserData");


            var requestBody = $"{{ \"userName\": \"{userData.UserName}\", \"password\": \"{userData.Password}\" }}";


            var response = ApiUtils.ExecutePostRequest("https://demoqa.com", "/Account/v1/User", requestBody);


            _scenarioContext.Set(response, "ApiResponse");
        }

        [Then("I should receive a valid response")]
        public void ThenIShouldReceiveAValidResponse()
        {

            var response = _scenarioContext.Get<RestSharp.RestResponse>("ApiResponse");


            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Then("the response should contain the correct user details")]
        public void ThenTheResponseShouldContainTheCorrectUserDetails()
        {



            var response = _scenarioContext.Get<RestResponse>("ApiResponse");


            var userResponse = JsonConvert.DeserializeObject<Framework.Models.UserData>(response.Content);



            var expectedUserData = _scenarioContext.Get<UserData>("UserData");


            Assert.AreEqual(expectedUserData.UserName, userResponse.UserName);

        }
    }
}

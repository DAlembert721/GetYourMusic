using System;
using GetYourMusic;
using GetYourMusic.Resources;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;
using System.Text;

namespace Testing.Steps
{
    [Binding]
    public class NewContractSteps
    {
        private WebApplicationFactory<TestStartup> _factory;
        private HttpClient _client { get; set; }
        protected HttpResponseMessage ResponseMessage { get; set; }

        public NewContractSteps(WebApplicationFactory<TestStartup> factory)
        {
            _factory = factory;
        }

        [Given(@"that the organizer want to send a contract to the musician")]
        public void GivenThatTheOrganizerWantToSendAContractToTheMusician()
        {
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri($"https://localhost/")
            });
        }
        
        [When(@"the organizer request to '(.*)' to contract for an avaible time, date and location with the following data '(.*)'")]
        public virtual async Task WhenTheOrganizerRequestToToContractForAnAvaibleTimeDateAndLocationWithTheFollowingData(string endpoint, string postDataJson)
        {
            var postRelativeUri = new Uri(endpoint, UriKind.Relative);
            var content = new StringContent(postDataJson, Encoding.UTF8, "application/json");
            ResponseMessage = await _client.PostAsync(postRelativeUri, content).ConfigureAwait(false);
        }
        
        [Then(@"the response status code for this new contract request is '(.*)'")]
        public void ThenTheResponseStatusCodeForThisNewContractRequestIs(int statusCode)
        {
            var expectedStatusCode = (HttpStatusCode)statusCode;
            Assert.Equal(expectedStatusCode, ResponseMessage.StatusCode);
        }
    }
}

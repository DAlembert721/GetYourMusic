using AutoMapper.Configuration.Annotations;
using GetYourMusic;
using GetYourMusic.Resources;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Ubiety.Dns.Core;
using Xunit;


namespace Testing.Steps
{
    [Binding]
    public class MusicianRegistrationSteps : IClassFixture<WebApplicationFactory<TestStartup>>
    {
        private WebApplicationFactory<TestStartup> _factory;
        private HttpClient _client { get; set; }
        protected HttpResponseMessage ResponseMessage { get; set; }
        protected HttpResponseMessage ResponseMessage2 { get; set; }

        public MusicianRegistrationSteps(WebApplicationFactory<TestStartup> factory)
        {
            _factory = factory;
        }
        [Given(@"I have entered my data correctly")]
        public void GivenIHaveEnteredMyDataCorrectly()
        {
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri($"https://localhost/")
            });
        }
        
        [When(@"I make a post request to '(.*)' with the following data '(.*)'")]
        public virtual async Task WhenIMakeAPostRequestToWithTheFollowingData(string resourceEndpoint, string postDataJson)
        {
            var postRelativeUri = new Uri(resourceEndpoint, UriKind.Relative);
            var content = new StringContent(postDataJson, Encoding.UTF8, "application/json");
            ResponseMessage = await _client.PostAsync(postRelativeUri, content).ConfigureAwait(false);
        }
        
        [When(@"also I make a post request to '(.*)' with the following data '(.*)'")]
        public virtual async Task WhenAlsoIMakeAPostRequestToWithTheFollowingData(string resourceEndpoint, string postDataJson)
        {
            var postRelativeUri = new Uri(resourceEndpoint, UriKind.Relative);
            var content = new StringContent(postDataJson, Encoding.UTF8, "application/json");
            ResponseMessage2 = await _client.PostAsync(postRelativeUri, content).ConfigureAwait(false);
        }
        
        
        [Then(@"the response should be a status code of '(.*)'")]
        public void ThenTheResponseShouldBeAStatusCodeOf(int statusCode)
        {
            var expectedStatusCode = (HttpStatusCode)statusCode;
            Assert.Equal(expectedStatusCode, ResponseMessage2.StatusCode);
        }

    }
}

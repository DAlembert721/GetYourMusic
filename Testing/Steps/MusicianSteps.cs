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

namespace Testing.Steps
{
    [Binding]
    public class MusicianSteps : IClassFixture<WebApplicationFactory<TestStartup>>
    {
        private WebApplicationFactory<TestStartup> _factory;
        private HttpClient _client { get; set; }
        protected HttpResponseMessage ResponseMessage { get; set; }

        public MusicianSteps(WebApplicationFactory<TestStartup> factory)
        {
            _factory = factory;
        }

        [Given(@"I am a musician")]
        public void GivenIAmAMusician()
        {
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri($"https://localhost/")
            });
        }
        
        [When(@"I make a get request to '(.*)' with the user id of '(.*)'")]
        public virtual async Task WhenIMakeAGetRequestToWithTheUserIdOf(string endpoint, int userId)
        {
            var postRelativeUri = new Uri(endpoint + userId, UriKind.Relative);
            ResponseMessage = await _client.GetAsync(postRelativeUri).ConfigureAwait(false);
        }

        [Then(@"the musician finded do not exist and the result should be a status code of '(.*)'")]
        public void ThenTheMusicianFindedDoNotExistAndTheResultShouldBeAStatusCodeOf(int statusCode)
        {
            var expectedStatusCode = (HttpStatusCode)statusCode;
            Assert.Equal(expectedStatusCode, ResponseMessage.StatusCode);
        }

        [Then(@"the result should be a status code of '(.*)'")]
        public void ThenTheResultShouldBeAStatusCodeOf(int statusCode)
        {
            var expectedStatusCode = (HttpStatusCode)statusCode;
            Assert.Equal(expectedStatusCode, ResponseMessage.StatusCode);
        }
        
        
        

    }
}

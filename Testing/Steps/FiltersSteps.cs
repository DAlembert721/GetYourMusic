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
    public class FiltersSteps : IClassFixture<WebApplicationFactory<TestStartup>>
    {
        private WebApplicationFactory<TestStartup> _factory;
        private HttpClient _client { get; set; }
        protected HttpResponseMessage ResponseMessage { get; set; }

        public FiltersSteps(WebApplicationFactory<TestStartup> factory)
        {
            _factory = factory;
        }

        [Given(@"I am an organizer")]
        public void GivenIAmAnOrganizer()
        {
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri($"https://localhost/")
            });
        }
        
        [When(@"I select a filter and make a request to '(.*)'")]
        public async Task WhenISelectAFilterAndMakeARequestTo(string endpoint)
        {
            var getRelativeUri = new Uri(endpoint , UriKind.Relative);
            ResponseMessage = await _client.GetAsync(getRelativeUri).ConfigureAwait(false);
        }
        
        [Then(@"the result list should be a status code of '(.*)'")]
        public void ThenTheResultListShouldBeAStatusCodeOf(int statusCode)
        {
            var expectedStatusCode = (HttpStatusCode)statusCode;
            Assert.Equal(expectedStatusCode, ResponseMessage.StatusCode);
        }
    }
}

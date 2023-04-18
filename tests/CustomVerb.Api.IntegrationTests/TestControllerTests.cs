using System.Net;
using System.Net.Http.Headers;
using System.Text;
using CustomVerb.Api.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;

namespace CustomVerb.Api.IntegrationTests
{
    public class TestControllerTests
    {
        private readonly WebApplicationFactory<Program> _webApplicationFactory;

        public TestControllerTests()
        {
            _webApplicationFactory = new WebApplicationFactory<Program>();
        }

        [Fact]
        public async Task CallingService_UsingNotifyVerb_IsSuccessful()
        {
            using var client = _webApplicationFactory.CreateClient();

            var method = new HttpMethod(Constants.HttpExtensions.DLNA.Verbs.Notify);

            var message = new HttpRequestMessage(method, $"{ Constants.Routes.TestRoutes.Prefix}/{Constants.Routes.TestRoutes.Notify}");

            var sut = await client.SendAsync(message);

            sut.IsSuccessStatusCode.Should().BeTrue();

            sut.StatusCode.Should().Be(HttpStatusCode.OK);

            sut.Content.Headers.ContentType?.MediaType.Should().Be(System.Net.Mime.MediaTypeNames.Application.Json);

        }

        [Fact]
        public async Task CallingService_UsingSubscribeVerb_IsSuccessful()
        {
            using var client = _webApplicationFactory.CreateClient();

            var method = new HttpMethod(Constants.HttpExtensions.DLNA.Verbs.Subscribe);

            var model = new SubscribeModel
            {
                Id = Guid.NewGuid().ToString("D")
            };

            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(model), Encoding.UTF8, new MediaTypeHeaderValue(System.Net.Mime.MediaTypeNames.Application.Json));

            var message = new HttpRequestMessage(method, $"{ Constants.Routes.TestRoutes.Prefix}/{Constants.Routes.TestRoutes.Subscribe}")
            {
                Content = content
            };

            var sut = await client.SendAsync(message);

            sut.IsSuccessStatusCode.Should().BeTrue();

            sut.StatusCode.Should().Be(HttpStatusCode.Accepted);

            sut.Content.Headers.ContentType?.MediaType.Should().Be(System.Net.Mime.MediaTypeNames.Application.Json);

        }

        ~TestControllerTests()
        {
            _webApplicationFactory.Dispose();
        }
    }
}
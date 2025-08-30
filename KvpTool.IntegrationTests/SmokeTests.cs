using KvpTool.Web;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KvpTool.IntegrationTests
{
    public class SmokeTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        // Der Testserver (Factory) wird einmal erzeugt und für alle Tests wiederverwendet.
        public SmokeTests(WebApplicationFactory<Program> factory) => _factory = factory;

        [Fact]
        public async Task Get_Root_ReturnsSuccessStatusCode()
        {
            // Arrange: HttpClient vom Teststerver anfordern
            var client = _factory.CreateClient();

            // Act: GET auf die Startseite "/"
            var response = await client.GetAsync("/");

            // Assert: Erwartet 200 OK
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}

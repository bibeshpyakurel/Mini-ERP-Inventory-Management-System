using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using MiniErp.Api.Middleware;

namespace MiniErp.IntegrationTests.ErrorHandling;

public sealed class ErrorHandlingEndpointTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public ErrorHandlingEndpointTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task UnknownRoute_Should_ReturnStandardizedNotFoundResponse()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("/api/unknown-route");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

        var payload = await response.Content.ReadFromJsonAsync<ApiErrorResponse>();
        Assert.NotNull(payload);
        Assert.Equal(404, payload.Status);
        Assert.Equal("Not Found", payload.Title);
    }
}

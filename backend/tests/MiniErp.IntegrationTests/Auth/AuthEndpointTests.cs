using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using MiniErp.Api.Middleware;

namespace MiniErp.IntegrationTests.Auth;

public sealed class AuthEndpointTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public AuthEndpointTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task Me_WithoutAuthentication_Should_ReturnUnauthorizedErrorPayload()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("/api/auth/me");

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);

        var payload = await response.Content.ReadFromJsonAsync<ApiErrorResponse>();
        Assert.NotNull(payload);
        Assert.Equal(401, payload.Status);
        Assert.Equal("Unauthorized", payload.Title);
    }

    [Fact]
    public async Task Login_WithMissingPassword_Should_ReturnValidationErrorPayload()
    {
        var client = _factory.CreateClient();

        var response = await client.PostAsJsonAsync("/api/auth/login", new
        {
            Email = "admin@minierp.local",
            Password = string.Empty
        });

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

        var payload = await response.Content.ReadFromJsonAsync<ApiErrorResponse>();
        Assert.NotNull(payload);
        Assert.Equal(400, payload.Status);
        Assert.Equal("Validation failed", payload.Title);
        Assert.NotNull(payload.Errors);
        Assert.Contains("Password", payload.Errors.Keys);
    }
}

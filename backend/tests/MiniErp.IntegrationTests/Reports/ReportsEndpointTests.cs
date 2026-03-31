using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;

namespace MiniErp.IntegrationTests.Reports;

public sealed class ReportsEndpointTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public ReportsEndpointTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetStockSummary_WithoutAuthentication_Should_ReturnUnauthorized()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("/api/reports/stock-summary");

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }
}

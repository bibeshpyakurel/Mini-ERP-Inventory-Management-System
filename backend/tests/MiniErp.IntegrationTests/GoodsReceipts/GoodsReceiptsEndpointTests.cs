using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;

namespace MiniErp.IntegrationTests.GoodsReceipts;

public sealed class GoodsReceiptsEndpointTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public GoodsReceiptsEndpointTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task PostGoodsReceipt_WithoutAuthentication_Should_ReturnUnauthorized()
    {
        var client = _factory.CreateClient();

        var response = await client.PostAsync("/api/goods-receipts", content: null);

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }
}

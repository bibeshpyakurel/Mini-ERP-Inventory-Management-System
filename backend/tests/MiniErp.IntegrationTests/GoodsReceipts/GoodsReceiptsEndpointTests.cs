using System.Net;
using MiniErp.IntegrationTests.Infrastructure;

namespace MiniErp.IntegrationTests.GoodsReceipts;

public sealed class GoodsReceiptsEndpointTests : IClassFixture<PostgresWebApplicationFactory>
{
    private readonly PostgresWebApplicationFactory _factory;

    public GoodsReceiptsEndpointTests(PostgresWebApplicationFactory factory)
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

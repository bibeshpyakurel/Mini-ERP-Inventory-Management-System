using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClearErp.Api.Middleware;
using ClearErp.Application.Common.Interfaces;

namespace ClearErp.Api.Controllers;

public sealed record LocationOption(Guid Id, string Name, string Code);
public sealed record WarehouseResponse(Guid Id, string Name, string Code, IReadOnlyList<LocationOption> Locations);

[ApiController]
[Route("api/[controller]")]
[ApiExplorerSettings(GroupName = "Warehouses")]
[Produces("application/json")]
[Authorize]
public sealed class WarehousesController(IApplicationDbContext db) : ControllerBase
{
    /// <summary>
    /// Returns all warehouses (with their locations) for the current tenant.
    /// </summary>
    [ProducesResponseType(typeof(IReadOnlyList<WarehouseResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status401Unauthorized)]
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<WarehouseResponse>>> GetAll(CancellationToken cancellationToken)
    {
        var warehouses = await db.Warehouses
            .Include(w => w.Locations)
            .OrderBy(w => w.Name)
            .ToListAsync(cancellationToken);

        var result = warehouses.Select(w => new WarehouseResponse(
            w.Id,
            w.Name,
            w.Code,
            w.Locations.OrderBy(l => l.Name).Select(l => new LocationOption(l.Id, l.Name, l.Code)).ToList()
        )).ToList();

        return Ok(result);
    }
}

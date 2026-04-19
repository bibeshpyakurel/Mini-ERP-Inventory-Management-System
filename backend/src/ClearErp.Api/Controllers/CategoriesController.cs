using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClearErp.Api.Middleware;
using ClearErp.Application.Common.Interfaces;

namespace ClearErp.Api.Controllers;

public sealed record CategoryResponse(Guid Id, string Name);

[ApiController]
[Route("api/[controller]")]
[ApiExplorerSettings(GroupName = "Categories")]
[Produces("application/json")]
[Authorize]
public sealed class CategoriesController(IApplicationDbContext db) : ControllerBase
{
    /// <summary>
    /// Returns all categories for the current tenant.
    /// </summary>
    [ProducesResponseType(typeof(IReadOnlyList<CategoryResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status401Unauthorized)]
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<CategoryResponse>>> GetAll(CancellationToken cancellationToken)
    {
        var categories = await db.Categories
            .OrderBy(c => c.Name)
            .Select(c => new CategoryResponse(c.Id, c.Name))
            .ToListAsync(cancellationToken);

        return Ok(categories);
    }
}

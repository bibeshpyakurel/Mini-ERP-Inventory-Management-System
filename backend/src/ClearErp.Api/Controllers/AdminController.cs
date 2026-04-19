using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ClearErp.Application.Common.Interfaces;
using ClearErp.Application.Common.Interfaces.Services;

namespace ClearErp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class AdminController(
    IDemoResetService demoResetService,
    ITenantContext tenantContext) : ControllerBase
{
    [HttpPost("reset-demo")]
    public async Task<IActionResult> ResetDemoData(CancellationToken cancellationToken)
    {
        var tenantId = tenantContext.TenantId;
        if (tenantId is null)
        {
            return Unauthorized(new { message = "Tenant context is required." });
        }

        await demoResetService.ResetTenantDataAsync(tenantId.Value, cancellationToken);

        return Ok(new { message = "Demo data has been reset. Please refresh the page." });
    }
}

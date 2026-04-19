using Microsoft.AspNetCore.Http;
using ClearErp.Application.Common.Interfaces;

namespace ClearErp.Infrastructure.Auth;

public sealed class TenantContext(IHttpContextAccessor httpContextAccessor) : ITenantContext
{
    public Guid? TenantId
    {
        get
        {
            var value = httpContextAccessor.HttpContext?.User.FindFirst("tenant_id")?.Value;
            return Guid.TryParse(value, out var id) ? id : null;
        }
    }
}

namespace ClearErp.Application.Common.Interfaces.Services;

public interface IDemoResetService
{
    Task ResetTenantDataAsync(Guid tenantId, CancellationToken cancellationToken = default);
}

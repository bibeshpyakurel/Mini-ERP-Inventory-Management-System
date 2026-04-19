namespace ClearErp.Application.Common.Interfaces;

public interface ICurrentUserService
{
    Guid? UserId { get; }
    string? Email { get; }
    IReadOnlyCollection<string> Roles { get; }
    bool IsAuthenticated { get; }
    Guid? TenantId { get; }
    string? Industry { get; }
    bool IsInRole(string role);
}

using Microsoft.EntityFrameworkCore;
using ClearErp.Application.Common.Interfaces;
using ClearErp.Application.Common.Interfaces.Repositories;
using ClearErp.Application.Common.Interfaces.Security;
using ClearErp.Application.Common.Interfaces.Services;
using ClearErp.Domain.Common;
using ClearErp.Domain.Entities;

namespace ClearErp.Infrastructure.Auth;

public sealed class AuthService(
    IPasswordHasher passwordHasher,
    IJwtTokenGenerator jwtTokenGenerator,
    IAuditLogRepository auditLogRepository,
    IApplicationDbContext dbContext) : IAuthService
{
    public async Task<AuthResult> LoginAsync(string email, string password, string tenantSlug, CancellationToken cancellationToken = default)
    {
        var tenant = await dbContext.Tenants
            .SingleOrDefaultAsync(t => t.Slug == tenantSlug.Trim().ToLowerInvariant() && t.IsActive, cancellationToken);

        if (tenant is null)
            throw new UnauthorizedException("Invalid credentials.");

        var normalizedEmail = email.Trim();
        var user = await dbContext.Users
            .IgnoreQueryFilters()
            .Include(u => u.UserRoles).ThenInclude(ur => ur.Role)
            .SingleOrDefaultAsync(u => u.Email == normalizedEmail && u.TenantId == tenant.Id && u.IsActive, cancellationToken);

        if (user is null || !passwordHasher.VerifyPassword(user.PasswordHash, password))
        {
            if (user is not null)
            {
                await auditLogRepository.AddAsync(
                    AuditLog.Create("LoginFailed", nameof(User), user.Id, $"Failed login attempt for {normalizedEmail}", user.Id),
                    cancellationToken);
                await dbContext.SaveChangesAsync(cancellationToken);
            }

            throw new UnauthorizedException("Invalid credentials.");
        }

        var roles = user.UserRoles
            .Select(x => x.Role?.Name)
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Cast<string>()
            .ToArray();

        var (accessToken, expiresAtUtc) = jwtTokenGenerator.GenerateToken(user, roles, user.TenantId, tenant.Industry);

        await auditLogRepository.AddAsync(
            AuditLog.Create("LoginSucceeded", nameof(User), user.Id, $"Successful login for {user.Email}", user.Id),
            cancellationToken);

        await dbContext.SaveChangesAsync(cancellationToken);

        return new AuthResult(
            accessToken,
            expiresAtUtc,
            user.Id,
            user.Email,
            user.FullName,
            roles,
            tenant.Id,
            tenant.Name,
            tenant.Industry);
    }
}

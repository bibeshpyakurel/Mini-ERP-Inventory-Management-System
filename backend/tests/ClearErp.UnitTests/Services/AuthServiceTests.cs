using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ClearErp.Application.Common.Interfaces;
using ClearErp.Domain.Common;
using ClearErp.Domain.Entities;
using ClearErp.Infrastructure.Auth;
using ClearErp.Infrastructure.Persistence;
using ClearErp.Infrastructure.Persistence.Repositories;
using ClearErp.Infrastructure.Persistence.Seeding;

namespace ClearErp.UnitTests.Services;

public sealed class AuthServiceTests
{
    [Fact]
    public async Task LoginAsync_Should_ReturnTokenRoles_AndCreateSuccessAuditLog()
    {
        await using var dbContext = CreateDbContext();
        var passwordHasher = new Pbkdf2PasswordHasher();

        var tenant = new Tenant
        {
            Id = SeedConstants.FurnitureTenantId,
            Name = "ClearFurniture Corp",
            Slug = "furniture",
            Industry = "Furniture",
            IsActive = true
        };

        var adminRole = new Role { Id = Guid.NewGuid(), Name = "Admin" };

        var user = new User
        {
            Id = SeedConstants.AdminUserId,
            TenantId = SeedConstants.FurnitureTenantId,
            Email = "admin@clearfurniture.local",
            PasswordHash = passwordHasher.HashPassword("Admin123!"),
            FullName = "Admin",
            IsActive = true
        };
        user.UserRoles.Add(new UserRole { UserId = user.Id, RoleId = adminRole.Id, Role = adminRole });

        dbContext.Tenants.Add(tenant);
        dbContext.Roles.Add(adminRole);
        dbContext.Users.Add(user);
        await dbContext.SaveChangesAsync();

        var authService = CreateAuthService(dbContext, passwordHasher);

        var result = await authService.LoginAsync("admin@clearfurniture.local", "Admin123!", "furniture");

        var auditLog = await dbContext.AuditLogs.SingleAsync();
        Assert.False(string.IsNullOrWhiteSpace(result.AccessToken));
        Assert.Equal("admin@clearfurniture.local", result.Email);
        Assert.Contains("Admin", result.Roles);
        Assert.Equal(SeedConstants.FurnitureTenantId, result.TenantId);
        Assert.Equal("LoginSucceeded", auditLog.Action);
    }

    [Fact]
    public async Task LoginAsync_Should_ThrowUnauthorized_AndCreateFailureAuditLog_WhenPasswordIsInvalid()
    {
        await using var dbContext = CreateDbContext();
        var passwordHasher = new Pbkdf2PasswordHasher();

        dbContext.Tenants.Add(new Tenant
        {
            Id = SeedConstants.FurnitureTenantId,
            Name = "ClearFurniture Corp",
            Slug = "furniture",
            Industry = "Furniture",
            IsActive = true
        });
        dbContext.Users.Add(new User
        {
            Id = SeedConstants.AdminUserId,
            TenantId = SeedConstants.FurnitureTenantId,
            Email = "admin@clearfurniture.local",
            PasswordHash = passwordHasher.HashPassword("Admin123!"),
            FullName = "Admin",
            IsActive = true
        });
        await dbContext.SaveChangesAsync();

        var authService = CreateAuthService(dbContext, passwordHasher);

        await Assert.ThrowsAsync<UnauthorizedException>(() =>
            authService.LoginAsync("admin@clearfurniture.local", "WrongPassword!", "furniture"));

        var auditLog = await dbContext.AuditLogs.SingleAsync();
        Assert.Equal("LoginFailed", auditLog.Action);
    }

    [Fact]
    public async Task LoginAsync_Should_ThrowUnauthorized_WhenTenantSlugIsInvalid()
    {
        await using var dbContext = CreateDbContext();
        var passwordHasher = new Pbkdf2PasswordHasher();

        var authService = CreateAuthService(dbContext, passwordHasher);

        await Assert.ThrowsAsync<UnauthorizedException>(() =>
            authService.LoginAsync("admin@clearfurniture.local", "Admin123!", "nonexistent-tenant"));
    }

    private static AuthService CreateAuthService(ApplicationDbContext dbContext, Pbkdf2PasswordHasher passwordHasher) =>
        new(
            passwordHasher,
            new JwtTokenGenerator(Options.Create(new JwtOptions
            {
                Issuer = "ClearErp",
                Audience = "ClearErp.Client",
                Key = "local-development-jwt-signing-key-change-before-production",
                ExpirationMinutes = 60
            })),
            new AuditLogRepository(dbContext),
            dbContext);

    private static ApplicationDbContext CreateDbContext()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        return new ApplicationDbContext(options, new NullTenantContext());
    }

    private sealed class NullTenantContext : ITenantContext
    {
        public Guid? TenantId => null;
    }
}

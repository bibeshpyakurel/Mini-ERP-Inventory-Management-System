namespace ClearErp.Api.Contracts.Auth;

/// <summary>
/// Login request for retrieving a JWT access token.
/// Example payload:
/// {
///   "email": "admin@clearfurniture.local",
///   "password": "Admin123!",
///   "tenantSlug": "furniture"
/// }
/// </summary>
public sealed record LoginRequest(string Email, string Password, string TenantSlug);

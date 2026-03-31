namespace MiniErp.Api.Contracts.Auth;

/// <summary>
/// Login request for retrieving a JWT access token.
/// Example payload:
/// {
///   "email": "admin@minierp.local",
///   "password": "Admin123!"
/// }
/// </summary>
public sealed record LoginRequest(string Email, string Password);

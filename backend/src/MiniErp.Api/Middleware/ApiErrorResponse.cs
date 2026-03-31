namespace MiniErp.Api.Middleware;

/// <summary>
/// Standard API error payload returned for validation, authorization, not-found, conflict, and unexpected-failure responses.
/// </summary>
public sealed record ApiErrorResponse(
    int Status,
    string Title,
    string Detail,
    string TraceId,
    IDictionary<string, string[]>? Errors = null);

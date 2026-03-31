using MiniErp.Domain.Entities;

namespace MiniErp.Application.Common.Interfaces.Security;

public interface IJwtTokenGenerator
{
    (string AccessToken, DateTime ExpiresAtUtc) GenerateToken(User user, IReadOnlyCollection<string> roles);
}

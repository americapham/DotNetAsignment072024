using Bosch.Events.Domain.Entities;

namespace Bosch.Events.Layered.Api.Jwt
{
    public interface ITokenManager
    {
        string GenerateToken(User user, string roleName);
    }
}

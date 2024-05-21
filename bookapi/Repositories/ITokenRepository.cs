using Microsoft.AspNetCore.Identity;

namespace bookapi.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}

using Atl.Domain;
using Atl.Domain.AppUser;

namespace AtlDemo.Infrastructure
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}

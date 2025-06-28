using SPC.core.Entities;

namespace SPC.Api.Autentication.Interface
{
    public interface ITokenService
    {
        string CreateToken(ApplicationUser user, IList<string> roles);
    }
}

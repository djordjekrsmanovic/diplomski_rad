using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Threading.Tasks;

namespace MicrosoftGraphSecurityApi.Authentication
{
    public interface IAuthenticationProvider
    {
        Task<AuthenticationResult> GetAccessToken();
    }
}

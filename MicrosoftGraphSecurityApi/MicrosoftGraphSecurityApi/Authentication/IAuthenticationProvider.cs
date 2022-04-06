using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicrosoftGraphSecurityApi.Authentication
{
    public interface IAuthenticationProvider
    {
        Task<AuthenticationResult> GetAccessToken();
    }
}

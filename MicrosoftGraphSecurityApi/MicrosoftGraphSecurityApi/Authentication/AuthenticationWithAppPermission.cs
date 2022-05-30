using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Threading.Tasks;

namespace MicrosoftGraphSecurityApi.Authentication
{
    public class AuthenticationWithAppPermission : IAuthenticationProvider
    {

        private static string TENNANT_ID = "9f6d426b-1a16-4f7f-a512-37666d0cc560";
        private static string APP_ID = "99e757b4-d3ee-4131-80ee-9144d2215c4f";
        private static string APP_SECRET = "IXm7Q~DubCkY5_v2VzBrMSvXHw.U6Yki46ng4";
        private static string AUTHORITY_URL = "https://login.microsoftonline.com/";
        private static string GRAPH_URL = string.Format("https://graph.microsoft.com/");

        private ClientCredential credential;
        private AuthenticationContext authenticationContext;
        

        public AuthenticationWithAppPermission()
        {
            this.authenticationContext = new AuthenticationContext(AUTHORITY_URL + TENNANT_ID);
            this.credential = new ClientCredential(APP_ID, APP_SECRET);
        }
        public async Task<AuthenticationResult> GetAccessToken()
        {
            try
            {
                AuthenticationResult result = await authenticationContext.AcquireTokenAsync(GRAPH_URL, credential);
                return result;

            }
            catch (Exception ex)
            {
                throw new Exception("Authentication error \n" + ex.Message);
            }

        }
    }
}

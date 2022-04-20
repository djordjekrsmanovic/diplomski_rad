using MicrosoftGraphSecurityApi.Authentication;
using MicrosoftGraphSecurityApi.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftGraphSecurityApi.Service
{
    public class GraphRequestService: IGraphRequestService
    {
        private readonly IAuthenticationProvider authenticationProvider;

        private static readonly String urlBase = "https://graph.microsoft.com/v1.0/security/";

        public GraphRequestService(IAuthenticationProvider authenticationProvider)
        {
            this.authenticationProvider = authenticationProvider;
        }


        public async Task<String> CreateRequest(String url,String content="")
        {
            var token = await this.authenticationProvider.GetAccessToken();


            string graphUrl = string.Format(urlBase+url);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, graphUrl);

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);

            request.Content = new StringContent(content, Encoding.UTF8, "application/json");

            HttpClient http = new HttpClient();

            var response = await http.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                string error = await response.Content.ReadAsStringAsync();
                object formatted = JsonConvert.DeserializeObject(error);
                throw new WebException("Error Calling the Graph API: \n" + JsonConvert.SerializeObject(formatted, Formatting.Indented));
            }

            string jsonResponse = await response.Content.ReadAsStringAsync();

            return jsonResponse;
        }
    }
}

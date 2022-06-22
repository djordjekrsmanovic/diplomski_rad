using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicrosoftGraphSecurityApi.Service
{
    public interface IGraphRequestService
    {
        Task<String> CreateRequest(String url, String content = "");
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MicrosoftGraphSecurityApi.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicrosoftGraphSecurityApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SecureScoreController : ControllerBase
    {
        private readonly IGraphRequestService service;

        public SecureScoreController(IGraphRequestService service)
        {
            this.service = service;
        }
        [HttpGet]
        public async Task<string> GetScore()
        {
            string ret="";

            ret =  await service.CreateRequest("secureScores");

            return ret;
        }
    }
}

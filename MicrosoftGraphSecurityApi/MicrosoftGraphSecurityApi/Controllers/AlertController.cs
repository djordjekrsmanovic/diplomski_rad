using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
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
using Microsoft.Extensions.Configuration.Json;
using MicrosoftGraphSecurityApi.Dto;
using MicrosoftGraphSecurityApi.Mapper;
using MicrosoftGraphSecurityApi.Service;

namespace MicrosoftGraphSecurityApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlertController : ControllerBase
    {

        private readonly IModelMapper<Alert, AlertTableDto> alertToAlertTableDtoMapper;

        private readonly IGraphRequestService graphRequestService;

        public AlertController(IGraphRequestService graphRequestService,IModelMapper<Alert,AlertTableDto> mapper)
        {
            this.graphRequestService = graphRequestService;
            this.alertToAlertTableDtoMapper = mapper;
        }
        

        [HttpGet]
        public async Task<List<AlertTableDto>> GetAlerts(string content = "")
        {

            String json = await graphRequestService.CreateRequest("alerts/");

            int n=json.IndexOf('[');

            String jsonAlertsArray = json.Substring(n, json.Length-n-1);

            var deptList = JsonConvert.DeserializeObject<List<Alert>>(jsonAlertsArray);

            List<AlertTableDto> alertTableDtos = alertToAlertTableDtoMapper.ToDtoList(deptList);

            return alertTableDtos;
        }
    }
}

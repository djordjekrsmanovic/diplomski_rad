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

        private readonly IModelMapper<Alert, AlertDetailsDto> alertToAlertDetailsDtoMapper;

        private readonly IAlertService alertService;

        private readonly IModelMapper<AlertFilter, AlertFilterDto> alertFilterDtoToAlertFilterModel;

        public AlertController(IAlertService alertService,IModelMapper<Alert,AlertTableDto> mapper,IModelMapper<Alert,AlertDetailsDto> alertMapper, IModelMapper<AlertFilter, AlertFilterDto> filterMapper)
        {
            this.alertService = alertService;
            this.alertToAlertTableDtoMapper = mapper;
            this.alertToAlertDetailsDtoMapper = alertMapper;
            this.alertFilterDtoToAlertFilterModel = filterMapper;
        }
        

        [HttpGet]
        [Route("/alerts")]
        public async Task<List<AlertTableDto>> GetAlerts()
        {

            List<Alert> alerts = alertService.getAlerts().Result;

            List<AlertTableDto> alertTableDtos = alertToAlertTableDtoMapper.ToDtoList(alerts);

            return alertTableDtos;
        }

        [HttpGet]
        [Route("/alerts/{alertId}")]
        public async Task<AlertDetailsDto> GetAlert(String alertId)
        {
            Alert alert = alertService.getAlert(alertId).Result;

            AlertDetailsDto alertDetailsDto = alertToAlertDetailsDtoMapper.ToDto(alert);

            return alertDetailsDto;
        }

        [HttpPost]
        [Route("/alerts/filter")]
        public async Task<List<AlertTableDto>> GetAlert(AlertFilterDto dto)
        {
            AlertFilter alertFilter = alertFilterDtoToAlertFilterModel.ToModel(dto);
            List<Alert> alerts = await alertService.FilterAlerts(alertFilter);

            List<AlertTableDto> alertTableDtos = alertToAlertTableDtoMapper.ToDtoList(alerts);

            return  alertTableDtos;
        }

        [HttpGet]
        [Route("/alerts/statistic/severity")]
        public async Task<List<StatisticDto>> GetAlertStatisticsBySeverity()
        {
            List<StatisticDto> alertStatistic =await alertService.GetStatisticBySeverity();
            return alertStatistic;
        }

        [HttpGet]
        [Route("/alerts/statistic/status")]
        public async Task<List<StatisticDto>> GetAlertStatisticsByStatus()
        {
            List<StatisticDto> alertStatistic = await alertService.GetStatisticByStatus();
            return alertStatistic;
        }
    }
}

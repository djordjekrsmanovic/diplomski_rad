using MicrosoftGraphSecurityApi.Dto;
using MicrosoftGraphSecurityApi.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicrosoftGraphSecurityApi.Service
{
    public class AlertService:IAlertService
    {
        private readonly IGraphRequestService graphRequestService;

        public AlertService(IGraphRequestService graphRequestService)
        {
            this.graphRequestService = graphRequestService;
        }

        public async Task<Alert> GetAlert(string alertId)
        {
            String json = await graphRequestService.CreateRequest("alerts/" + alertId);

            var alert = JsonConvert.DeserializeObject<Alert>(json);

            return alert;
        }

        public async Task<List<Alert>> GetAlerts()
        {
            String json = await graphRequestService.CreateRequest("alerts?$filter=(Status eq 'NewAlert') and (Severity eq 'High' or Severity eq 'Low')");

            int n = json.IndexOf('[');

            String jsonAlertsArray = json.Substring(n, json.Length - n - 1);

            var alerts = JsonConvert.DeserializeObject<List<Alert>>(jsonAlertsArray);

            return alerts;
        }

        public async Task<List<Alert>> FilterAlerts(AlertFilter filter)
        {
            String filterValues = filter.ConvertFilterToString();
            String json = await graphRequestService.CreateRequest("alerts?"+filterValues);

            int n = json.IndexOf('[');

            String jsonAlertsArray = json.Substring(n, json.Length - n - 1);

            var alerts = JsonConvert.DeserializeObject<List<Alert>>(jsonAlertsArray);

            return alerts;
        }

        public async Task<List<StatisticDto>> GetStatisticBySeverity()
        {
            String jsonHigh = await graphRequestService.CreateRequest("alerts?$filter=Severity eq 'High'&$count=true");
            String jsonMedium= await graphRequestService.CreateRequest("alerts?$filter=Severity eq 'Medium'&$count=true");
            String jsonLow=await graphRequestService.CreateRequest("alerts?$filter=Severity eq 'Low'&$count=true");
            String jsonInformational= await graphRequestService.CreateRequest("alerts?$filter=Severity eq 'Informational'&$count=true");
            int numOfHigh=ExtractCountValueFromJson(jsonHigh);
            int numOfMedium = ExtractCountValueFromJson(jsonMedium);
            int numOfLow = ExtractCountValueFromJson(jsonLow);
            int numOfInformational = ExtractCountValueFromJson(jsonInformational);
            List<StatisticDto> statisticDtoList=new List<StatisticDto>();
            statisticDtoList.Add(new StatisticDto { Name="High",Value=numOfHigh});
            statisticDtoList.Add(new StatisticDto { Name = "Medium", Value = numOfMedium });
            statisticDtoList.Add(new StatisticDto { Name = "Low", Value = numOfLow });
            statisticDtoList.Add(new StatisticDto { Name = "Informational", Value = numOfInformational });
            return statisticDtoList;
        }

        public async Task<List<StatisticDto>> GetStatisticByStatus()
        {
            String jsonNew = await graphRequestService.CreateRequest("alerts?$filter=Status eq 'NewAlert'&$count=true");
            String jsonInProgress = await graphRequestService.CreateRequest("alerts?$filter=Status eq 'InProgress'&$count=true");
            String jsonResolved = await graphRequestService.CreateRequest("alerts?$filter = Status eq 'Resolved' &$count = true");
            String jsonDismissed = await graphRequestService.CreateRequest("alerts?$filter = Status eq 'Dismissed' &$count = true");
            int numOfNew = ExtractCountValueFromJson(jsonNew);
            int numOfInProgress = ExtractCountValueFromJson(jsonInProgress);
            int numOfResolved = ExtractCountValueFromJson(jsonResolved);
            int numOfDismissed = ExtractCountValueFromJson(jsonDismissed);
            List<StatisticDto> statisticDtoList = new List<StatisticDto>();
            statisticDtoList.Add(new StatisticDto { Name = "NewAlert", Value = numOfNew });
            statisticDtoList.Add(new StatisticDto { Name = "InProgress", Value = numOfInProgress });
            statisticDtoList.Add(new StatisticDto { Name = "Resolved", Value = numOfResolved });
            statisticDtoList.Add(new StatisticDto { Name = "Dismissed", Value = numOfDismissed });
            return statisticDtoList;
        }

        private int ExtractCountValueFromJson(String json)
        {
            String[] splitedByComma=json.Split(",");
            String valuePart = splitedByComma[1];
            String[] splitedBySemi = valuePart.Split(":");
            return Int32.Parse(splitedBySemi[1]);
        }
    }
}

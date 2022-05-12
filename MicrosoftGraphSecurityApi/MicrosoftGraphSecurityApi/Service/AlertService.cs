using MicrosoftGraphSecurityApi.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Alert> getAlert(string alertId)
        {
            String json = await graphRequestService.CreateRequest("alerts/" + alertId);

            var alert = JsonConvert.DeserializeObject<Alert>(json);

            return alert;
        }

        public async Task<List<Alert>> getAlerts()
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
    }
}

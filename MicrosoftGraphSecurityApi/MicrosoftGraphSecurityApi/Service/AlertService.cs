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
            String json = await graphRequestService.CreateRequest("alerts");

            int n = json.IndexOf('[');

            String jsonAlertsArray = json.Substring(n, json.Length - n - 1);

            var alerts = JsonConvert.DeserializeObject<List<Alert>>(jsonAlertsArray);

            return alerts;
        }
    }
}

using MicrosoftGraphSecurityApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicrosoftGraphSecurityApi.Service
{
    public interface IAlertService
    {
        Task<List<Alert>> getAlerts();
        Task<Alert> getAlert(string alertId);
    }
}

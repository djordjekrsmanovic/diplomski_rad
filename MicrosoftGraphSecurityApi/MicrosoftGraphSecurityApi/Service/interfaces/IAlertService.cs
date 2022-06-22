using MicrosoftGraphSecurityApi.Dto;
using MicrosoftGraphSecurityApi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicrosoftGraphSecurityApi.Service
{
    public interface IAlertService
    {
        Task<List<Alert>> GetAlerts();
        Task<Alert> GetAlert(string alertId);
        Task<List<Alert>> FilterAlerts(AlertFilter filter);
        Task<List<StatisticDto>> GetStatisticBySeverity();
        Task<List<StatisticDto>> GetStatisticByStatus();
    }
}

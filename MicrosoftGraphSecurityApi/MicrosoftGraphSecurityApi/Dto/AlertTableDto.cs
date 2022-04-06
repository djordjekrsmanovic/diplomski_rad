using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicrosoftGraphSecurityApi.Dto
{
    public class AlertTableDto
    {
        public String Id { get; set; }
        public String Title { get; set; }
        public AlertSeverity Severity { get; set; }
        public AlertStatus Status { get; set; }
        public String Category { get; set; }
        public DateTimeOffset CreateDateTime { get; set; }
        public String AssignedTo { get; set; }
        public String Provider { get; set; }

    }
}

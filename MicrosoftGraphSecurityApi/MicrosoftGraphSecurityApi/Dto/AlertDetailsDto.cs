using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicrosoftGraphSecurityApi.Dto
{
    public class AlertDetailsDto
    {
        public String Id { get; set; }
        public String Title { get; set; }
        public AlertSeverity Severity { get; set; }
        public AlertStatus Status { get; set; }
        public String Category { get; set; }
        public String CreateDateTime { get; set; }
        public String AssignedTo { get; set; }
        public VendorInfromationDto VendorInformation { get; set; }
        public String AlertDescription { get; set; }
        public List<String> recommendedActions { get; set; }
    }
}

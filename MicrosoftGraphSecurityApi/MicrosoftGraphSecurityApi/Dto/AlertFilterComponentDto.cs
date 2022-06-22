using MicrosoftGraphSecurityApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicrosoftGraphSecurityApi.Dto
{
    public class AlertFilterComponentDto
    {
        public AlertFilterComponentType Type { get; set; }
        public List<String> FilterValues { get; set; }
    }
}

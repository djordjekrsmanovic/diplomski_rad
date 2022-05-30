using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MicrosoftGraphSecurityApi.Model
{
    public class AlertFilter
    {
        
        public AlertFilter()
        {
            Filters = new Dictionary<AlertFilterComponentType, List<AlertFilterComponent>>();
        }

        public Dictionary<AlertFilterComponentType,List<AlertFilterComponent>> Filters { get; set; }

        public String ConvertFilterToString()
        {

            StringBuilder sb = new StringBuilder("");
            String topPart = "";
            String severityPart = "";
            String statusPart = "";
            List<AlertFilterComponent> severityfilterComponents;
            List<AlertFilterComponent> statusFilterComponents;
            if (Filters.TryGetValue(AlertFilterComponentType.SEVERITY, out severityfilterComponents) == true)
            {
                severityPart = ExtractStringFromFilter(severityfilterComponents);
            }

            if (Filters.TryGetValue(AlertFilterComponentType.STATUS, out statusFilterComponents) == true)
            {
                statusPart = ExtractStringFromFilter(statusFilterComponents);
            }
            ExtractTopFilter(ref topPart);
            if (severityPart!="" && statusPart != "")
            {
                sb.Append("$filter=");
                sb.Append(severityPart);
                sb.Append(" and ");
                sb.Append(statusPart);
            }
            if ((severityPart=="" || statusPart == "") && (severityPart!="" || statusPart!=""))
            {
                sb.Append("$filter=");
                sb.Append(severityPart);
                sb.Append(statusPart);
            }
            sb.Append(topPart);
            return sb.ToString();
        }

        private String ExtractStringFromFilter(List<AlertFilterComponent> filterComponents)
        {
            if (filterComponents.Count == 0)
            {
                return "";
            }
            StringBuilder sb = new StringBuilder("");
            sb.Append("(");
            sb.Append(AlertFilterComponentTypeToString(filterComponents.ElementAt(0).FilterType));
            sb.Append(" ");
            for (int j = 0; j < filterComponents.Count; j++)
            {
                sb.Append(" eq ");
                sb.Append("'" + filterComponents[j].Value + "'");
                if (j != filterComponents.Count - 1)
                {
                    sb.Append(" or ");
                    sb.Append(AlertFilterComponentTypeToString(filterComponents.ElementAt(j).FilterType));
                }

            }
            sb.Append(" ) ");
            return sb.ToString();
        }

        private void ExtractTopFilter(ref string topPart)
        {
            List<AlertFilterComponent> filterComponents;
            if (Filters.TryGetValue(AlertFilterComponentType.TOP_ALERTS, out filterComponents) == true)
            {
                topPart += "&$top=";
                topPart += Filters[AlertFilterComponentType.TOP_ALERTS][0].Value;
                Filters.Remove(AlertFilterComponentType.TOP_ALERTS);
            }

        }

        public String AlertFilterComponentTypeToString(AlertFilterComponentType type)
        {
            String retValues = "";
            if (type == AlertFilterComponentType.STATUS)
            {
                retValues = "Status";
            }else if (type == AlertFilterComponentType.SEVERITY)
            {
                retValues = "Severity";
            }
            else
            {
                retValues = "$top";
            }

            return retValues;
        }
    }

   
}

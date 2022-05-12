using MicrosoftGraphSecurityApi.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            bool filterAppeared = false;
            List<AlertFilterComponent> filterComponents;
            ExtractTopFilter(ref topPart);

            for (int i = 0; i < Filters.Keys.Count; i++)
            {

                if (filterAppeared == false)
                {
                    filterAppeared = true;
                    sb.Append("$filter=");

                }

                if (Filters.TryGetValue(Filters.ElementAt(i).Key, out filterComponents) == true)
                {

                    var filtersValues = Filters[Filters.ElementAt(i).Key];
                    sb.Append("(");
                    sb.Append(AlertFilterComponentTypeToString(Filters.ElementAt(i).Key));
                    sb.Append(" ");
                    for (int j = 0; j < filtersValues.Count; j++)
                    {
                        sb.Append(" eq ");
                        sb.Append("'" + filtersValues[j].Value + "'");
                        if (j != filtersValues.Count - 1)
                        {
                            sb.Append(" or ");
                            sb.Append(AlertFilterComponentTypeToString(Filters.ElementAt(i).Key));
                        }

                    }
                    sb.Append(" ) ");
                }


                if (i != Filters.Count - 1)
                {
                    sb.Append(" and ");
                }

            }
            sb.Append(topPart);
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

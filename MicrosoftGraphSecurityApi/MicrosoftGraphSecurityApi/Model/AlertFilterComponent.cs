using System;
using System.Collections.Generic;

namespace MicrosoftGraphSecurityApi.Model
{
    public class AlertFilterComponent
    {
        

        public AlertFilterComponent(AlertFilterComponentType type, string value)
        {
            FilterType = type;
            Value = value;
        }

        public String Value { get; set; }
        public AlertFilterComponentType FilterType { get; set; }

        public static List<AlertFilterComponent> CreateAlertFilterComponentList(AlertFilterComponentType type,List<String> values)
        {
            List<AlertFilterComponent> alertFilterComponents = new List<AlertFilterComponent>();
            foreach (String value in values)
            {
                alertFilterComponents.Add(new AlertFilterComponent(type, value));
            }

            return alertFilterComponents;

        }
    }

   /* public enum FilterServerityValues
    {
        ANY,
        HIGH,
        MEDIUM,
        LOW,
        INFORMATIONAL
    }

    public enum FilterCategoryValues
    {
        ANY,
        NEW_ALERT,
        IN_PRORESS,
        RESOLVED,
        DISMISSED
    }*/
}

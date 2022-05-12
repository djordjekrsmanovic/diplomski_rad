using MicrosoftGraphSecurityApi.Dto;
using MicrosoftGraphSecurityApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicrosoftGraphSecurityApi.Mapper
{
    public class FilterDtoToFilterModel : IModelMapper<AlertFilter, AlertFilterDto>
    {
        public AlertFilterDto ToDto(AlertFilter model)
        {
            throw new NotImplementedException();
        }

        public AlertFilter ToModel(AlertFilterDto dto)
        {
            AlertFilter alertFilter = new AlertFilter();
            List<AlertFilterComponent> filterComponents;
            foreach (AlertFilterComponentDto componentDto in dto.Filter)
            {
                if (!alertFilter.Filters.TryGetValue(componentDto.Type, out filterComponents))
                {
                    alertFilter.Filters.Add(componentDto.Type, AlertFilterComponent.CreateAlertFilterComponentList(componentDto.Type, componentDto.FilterValues));
                }
            }

            return alertFilter;
        }
    }
}

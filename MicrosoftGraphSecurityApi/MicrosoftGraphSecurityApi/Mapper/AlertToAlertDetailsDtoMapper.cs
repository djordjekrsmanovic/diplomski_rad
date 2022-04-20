
using MicrosoftGraphSecurityApi.Dto;
using MicrosoftGraphSecurityApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicrosoftGraphSecurityApi.Mapper
{
    public class AlertToAlertDetailsDtoMapper : IModelMapper<Alert, AlertDetailsDto>
    {
        private readonly IModelMapper<Microsoft.Graph.SecurityVendorInformation, VendorInfromationDto> vendorMapper;

        public AlertToAlertDetailsDtoMapper(IModelMapper<Microsoft.Graph.SecurityVendorInformation, VendorInfromationDto> mapper)
        {
            vendorMapper = mapper;
        }
        public AlertDetailsDto ToDto(Alert model)
        {
            AlertDetailsDto detailsDto = new AlertDetailsDto();

            detailsDto.AlertDescription = model.Description;
            detailsDto.AssignedTo = model.AssignedTo;
            detailsDto.Category = model.Category;
            detailsDto.CreateDateTime = model.CreatedDateTime.Value;
            detailsDto.Id = model.Id;
            detailsDto.recommendedActions = model.RecommendedActions;
            detailsDto.Severity = model.Severity.Value;
            detailsDto.Status = model.Status.Value;
            detailsDto.Title = model.Title;
            detailsDto.VendorInformation = vendorMapper.ToDto(model.VendorInformation);

            return detailsDto;
          
        }

        public Alert ToModel(AlertDetailsDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

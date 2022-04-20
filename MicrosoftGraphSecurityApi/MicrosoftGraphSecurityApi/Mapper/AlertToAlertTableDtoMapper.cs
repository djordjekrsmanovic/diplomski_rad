using MicrosoftGraphSecurityApi.Dto;
using MicrosoftGraphSecurityApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicrosoftGraphSecurityApi.Mapper
{
    public class AlertToAlertTableDtoMapper : IModelMapper<Alert, AlertTableDto>
    {
        public AlertTableDto ToDto(Alert model)
        {
            AlertTableDto alertTableDto = new AlertTableDto();

            alertTableDto.Id = model.Id;
            alertTableDto.Title = model.Title.Substring(model.Title.IndexOf("]")+1);
            alertTableDto.Status = model.Status.Value;
            alertTableDto.Severity = model.Severity.Value;
            alertTableDto.Provider = model.VendorInformation.Provider;
            alertTableDto.CreateDateTime = model.CreatedDateTime.Value;
            alertTableDto.AssignedTo = model.AssignedTo;
            alertTableDto.Category = model.Category.Substring(model.Category.IndexOf("_")+1);
            return alertTableDto;
        }

        public Alert ToModel(AlertTableDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

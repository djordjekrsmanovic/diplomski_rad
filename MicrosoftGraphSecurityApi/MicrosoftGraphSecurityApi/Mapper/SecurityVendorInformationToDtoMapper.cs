using Microsoft.Graph;
using MicrosoftGraphSecurityApi.Dto;
using System;

namespace MicrosoftGraphSecurityApi.Mapper
{
    public class SecurityVendorInformationToDtoMapper : IModelMapper<SecurityVendorInformation, VendorInfromationDto>
    {
        public VendorInfromationDto ToDto(SecurityVendorInformation model)
        {
            VendorInfromationDto vendorInfromationDto = new VendorInfromationDto();
            vendorInfromationDto.Vendor = model.Vendor;
            vendorInfromationDto.Provider = model.Provider;
            vendorInfromationDto.SubProvider = model.SubProvider;
            return vendorInfromationDto;
        }

        public SecurityVendorInformation ToModel(VendorInfromationDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

using Microsoft.Graph;
using MicrosoftGraphSecurityApi.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

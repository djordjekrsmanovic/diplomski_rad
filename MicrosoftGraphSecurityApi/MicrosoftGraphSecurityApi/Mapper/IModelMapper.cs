using System.Collections.Generic;
using System.Linq;

namespace MicrosoftGraphSecurityApi.Mapper
{
    public interface IModelMapper<Model,Dto>
    {
        Dto ToDto(Model model);

        Model ToModel(Dto dto);

        List<Model> ToModelList(List<Dto> dtos)
        {
            List<Model> models = dtos.Select(dto => ToModel(dto)).ToList();
            return models;
        }

        List<Dto> ToDtoList(List<Model> models)
        {
            List<Dto> dtos = models.Select(model => ToDto(model)).ToList();
            return dtos;
        }
    }
}

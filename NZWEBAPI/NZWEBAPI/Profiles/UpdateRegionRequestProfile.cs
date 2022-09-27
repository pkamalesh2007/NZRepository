using AutoMapper;

namespace NZWEBAPI.Profiles

{
    public class UpdateRegionRequestProfile:Profile
    {
        public UpdateRegionRequestProfile()
        {
            CreateMap<Models.Domain.Region, Models.DTO.UpdateRegionRequest>().ReverseMap();
        }
    }
}

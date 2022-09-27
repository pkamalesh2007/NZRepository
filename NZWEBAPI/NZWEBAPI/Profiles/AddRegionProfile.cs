using AutoMapper;
using NZWEBAPI.Models.Domain;
using NZWEBAPI.Models.DTO;

namespace NZWEBAPI.Profiles
{
    public class AddRegionProfile:Profile
    {
        public AddRegionProfile()
        {
            CreateMap<Models.Domain.Region, AddRegionRequest>().ReverseMap();
        }
    }
}

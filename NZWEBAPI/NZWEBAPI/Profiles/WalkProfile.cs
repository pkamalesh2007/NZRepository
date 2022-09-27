using AutoMapper;

namespace NZWEBAPI.Profiles
{
    public class WalkProfile:Profile
    {
        public WalkProfile()
        {
            CreateMap<Models.Domain.Walk, Models.DTO.WalksRequestDTO>().ReverseMap();
        }
    }
}

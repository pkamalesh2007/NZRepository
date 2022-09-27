using AutoMapper;

namespace NZWEBAPI.Profiles
{
    public class WalkRequestProfile:Profile
    {
        public WalkRequestProfile()
        {
            CreateMap<Models.Domain.Walk, Models.DTO.WalksDTO>().ReverseMap();
        }
    }
}

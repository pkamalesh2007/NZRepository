using AutoMapper;

namespace NZWEBAPI.Profiles
{
    public class NationalParkProfile:Profile
    {
        public NationalParkProfile()
        {
            CreateMap<Models.Domain.NationalPark, Models.DTO.NationalParkDTO>().ReverseMap();
        }
    }
}

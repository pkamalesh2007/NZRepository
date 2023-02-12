using AutoMapper;

namespace ADONETAutoMapperExample.Profiles
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Models.Domain.Employee, Models.DTO.EmployeeDTO>().ReverseMap();
        }
    }
}

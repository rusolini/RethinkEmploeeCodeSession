using AutoMapper;
using Emploee.DataAccess.Models;
using Emploee.WebApi.Models;

namespace ITechArt.ExpApp.WebAPI.MappingProfiles
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
                //.ForMember(dst => dst.Id, src => src.MapFrom(m => m.Id))
                //.ForMember(dst => dst.FirstName, src => src.MapFrom(m => m.FirstName))
                //.ForMember(dst => dst.LastName, src => src.MapFrom(m => m.LastName))
                //.ForMember(dst => dst.Email, src => src.MapFrom(m => m.Email);
        }
    }
}
